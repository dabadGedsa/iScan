Imports AccesoDatos = LibreriaCadenaProduccion.Datos.GeneralSQL.clsAccesoDatosSQL
Imports accesoDatosNew = Digitalización.accesoDatosNuevos.clsAccesoDatosNUEVO
Imports AccesoDatosConexion = LibreriaCadenaProduccion.Entidades.clsProyecto
Imports AccesoDatosMySQL = LibreriaCadenaProduccion.Datos.GeneralMySQL.clsAccesoDatosMySQL
Imports modelo = LibreriaCadenaProduccion.Entidades


Public Class frmPreparacion

    Dim cajaActiva As String = ""
    Dim coleccionActiva As String = ""
    Dim loteActivo As String = ""

    Dim colorCaja As Color = Color.Blue
    Dim colorColeccion As Color = Color.Green
    Dim colorlote As Color = Color.Black
    Dim colorHistoria As Color = Color.Gray

    Dim loteAnterior As String = ""

    Dim historiaActiva As String = ""
    Dim Hist_Activa As String = ""

    Dim tablaPreparacion As String = ""
    Dim loteSql As String = ""
    Dim usuarioPreparacion As String = ""
    Dim fechaInicioPreparacion As String = ""
    Dim fechaFinPreparacion As String = ""

    Dim salir As Boolean = False

    Dim CajaCompleta As String = ""

    Dim CadenaConexionMySQL As String = ""

    Dim PathRecursivo As String = ""
    Dim CodExcepcion As String
    Dim Encontrado As Boolean = False


    Private Sub frmPreparacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        lblTipoLote.Text = ""
        lblUsuario.Text = frmContenedorMDI.oUsuario._apellidos & ", " & frmContenedorMDI.oUsuario._nombre & " (" & frmContenedorMDI.oUsuario._login & ")"

        splGeneral.SplitterDistance = splGeneral.Width / 2

        'Comprueba si está la configuración necesria para actualizar los lotes la base de datos de iScan con la información de preparación.
        Dim array As String() = My.Settings.PREP_Tabla_campos.Split(";")
        If array(0).ToString.Trim = "" Or array.Length <> 5 Then
            MsgBox("No existe información en la configuración de la aplicación o no está completa, debe crear la propiedad 'PREP_Tabla_campos' y asignarle los valores correspondientes para poder utilizar la funcionalidad de 'Preparación'.", MsgBoxStyle.Critical)
            salir = True
        Else
            tablaPreparacion = array(0).ToString.Trim
            loteSql = array(1).ToString.Trim
            usuarioPreparacion = array(2).ToString.Trim()
            fechaInicioPreparacion = array(3).ToString.Trim
            fechaFinPreparacion = array(4).ToString.Trim
        End If

        '*******************************

        cargaServicios()
        cargaDocumentos()

        inicializaControles()

        trvGeneral.Nodes.Clear()
        trvGeneral.Nodes.Add(0, frmContenedorMDI.oProyecto._CodigoProyecto & " - " & frmContenedorMDI.oProyecto._nombreProyecto)
        trvGeneral.Nodes.Item(0).BackColor = Color.Blue
        seleccionarNodo("0")

        cargaDatos()

        If My.Settings.cadenaConexionMySQL.Trim <> "" Then
            CadenaConexionMySQL = My.Settings.cadenaConexionMySQL
        Else
            'JANTONIO 'LIMITA CONEXION MYSQL
            'MessageBox.Show("No hay cadena de conexion para MySQL")
        End If
        Me.txtCodigo.Focus()

    End Sub

    Private Sub inicializaControles()

        trvGeneral.Width = splGeneral.Panel2.Width

        lblUsuario.Width = splGeneral.Panel1.Width
        txtCodigo.Width = splGeneral.Panel1.Width - 20

        lblCaja.ForeColor = colorCaja
        lblColeccion.ForeColor = colorColeccion
        lblLote.ForeColor = colorlote
        lblHistoria.ForeColor = colorHistoria

        If My.Settings.PREP_tipoLote_fijo.ToString.Trim <> "" Then
            lblTipoLote.Text = My.Settings.PREP_tipoLote_fijo.ToString.Trim
            chkBloquear.Checked = True
            chkBloquear.Enabled = False
        Else
            chkBloquear.Enabled = True
            chkBloquear.Checked = False
        End If

    End Sub

    Private Sub txtCodigo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigo.Click

        Timer1.Enabled = False

        If txtCodigo.Text.ToString.Trim = "Posicione el cursor" Then
            txtCodigo.Text = ""
        Else
            txtCodigo.SelectAll()
        End If

    End Sub

    Private Sub txtCodigo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigo.Leave

        If txtCodigo.Text.ToString.Trim = "" Then txtCodigo.Text = "Posicione el cursor"
        Timer1.Enabled = True
        Timer1.Start()

    End Sub

    Private Sub splGeneral_SplitterMoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.SplitterEventArgs) Handles splGeneral.SplitterMoved
        inicializaControles()
    End Sub

    Private Sub splGeneral_SplitterMoving(ByVal sender As System.Object, ByVal e As System.Windows.Forms.SplitterCancelEventArgs) Handles splGeneral.SplitterMoving
        inicializaControles()
    End Sub

    Private Sub txtCodigo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigo.KeyDown

        Dim lsSql As String = ""
        Dim elementoActivo As String = ""
        Dim indice As String = ""
        Dim tn As TreeNode = Nothing
        Dim NumCaja As String = ""
        Dim UserSelec As Boolean = False
        Dim Sentencia As String = ""

        Try

            If e.KeyData = Keys.Enter Then
                'JGARIJO 30/09/2019
                'Se incorpora la lectura del codigo de barras con el usuario que pistolea. Será el primer valor que se recibe

                If My.Settings.PREP_caracter_caja.ToString.Trim = "" Or My.Settings.PREP_caracter_Caja2.ToString.Trim = "" Or My.Settings.PREP_caracter_Lote.ToString.Trim = "" Or My.Settings.PREP_caracter_NHC.ToString.Trim = "" Or My.Settings.PREP_caracter_Usuario.ToString.Trim = "" Or My.Settings.PREP_caracter_RX.ToString.Trim = "" Or My.Settings.PREP_caracter_SinDoc.ToString.Trim = "" Or My.Settings.PREP_caracter_CD.ToString.Trim = "" Or My.Settings.PREP_caracter_ND.ToString.Trim = "" Or My.Settings.PREP_caracter_CI.ToString.Trim = "" Then
                    MsgBox("Compruebe la configuración de la aplicación relacionada con la preparación. No existe configuración para determinar el tipo de código de barras leído.", MsgBoxStyle.Critical)
                    EscribirLog("", "CONFIGURACION ERRONEA DE LA APLICACION", "PREPARACION")
                    Me.Close()
                End If

                'No se el motivo por el que el lector de código de barras lee una ñ en vez de ;
                txtCodigo.Text = txtCodigo.Text.Replace("ñ", ";")
                txtCodigo.Text = txtCodigo.Text.Replace("Ñ", ";")
                txtCodigo.Text = txtCodigo.Text.Replace("'", "")
                txtCodigo.Text = txtCodigo.Text.Trim

                CodExcepcion = txtCodigo.Text
                Dim clave = frmContenedorMDI.oProyecto._CodigoProyecto & " - " & frmContenedorMDI.oProyecto._nombreProyecto

                If lblCaja.Text.ToString.Trim <> "" Then clave = clave & "\" & lblCaja.Text.ToString.Trim
                If lblColeccion.Text.ToString.Trim <> "" Then clave = clave & "\" & lblColeccion.Text.ToString.Trim
                If lblLote.Text.ToString.Trim <> "" Then clave = clave & "\" & lblLote.Text.ToString.Trim

                '### JGARIJO 30/08/2019 -> COMPROBACION DE USUARIO
                'El usuario de preparacion puede ser diferente del usuario que se ha logado en la aplicacion. Para identificarse, escanean su nombre de usuario

                If txtCodigo.Text.ToString.Trim.Contains(My.Settings.PREP_caracter_Usuario.ToString.Trim) Then
                    lblUserPistoleado.Text = txtCodigo.Text.Trim.Replace(My.Settings.PREP_caracter_Usuario.ToString.Trim, "")
                    txtCodigo.Text = ""
                    QuitarError()
                    txtCodigo.Focus()
                    lblCaja.Text = ""
                    lblColeccion.Text = ""
                    lblLote.Text = ""
                    lblHistoria.Text = ""
                    If My.Settings.PREP_tipoLote_fijo.ToString.Trim = "" Then
                        lblTipoLote.Text = ""
                    Else
                        lblTipoLote.Text = My.Settings.PREP_tipoLote_fijo.ToString.Trim
                    End If

                    Me.Refresh()
                    Call EscribirLog(lblUserPistoleado.Text, "Usuario " & lblUserPistoleado.Text.Trim & " logado correctamente", "PREPARACION")
                    Exit Sub
                End If

                If lblUserPistoleado.Text.Trim = "" Then
                    'Se ha escaneado cualquier codigo que no es de usuario. Si no hay login de usuario, se acaba la ejecucion 
                    'txtCodigo.Text = ""
                    LanzarError("SELECCIONAR PRIMERO USUARIO")
                    EscribirLog("", "No se ha seleccionado un usuario válido", "PREPARACION")
                    Exit Sub
                End If

                '### JGARIJO 30/08/2019 -
                '> FIN COMPROBACION DE USUARIO

                '### JANTONIO 15-1-2020 -> INI COMPROBACION TIPO LOTE
                'Si no hay valores en la tabla "CONFIGURACION_TIPOLOTES" en la base de datos de ADMINISTRACION, comprobamos el valor de la propiedad "PREP_tipoLote_fijo", en caso contrario, localizamos el tipo de lote que se corresponde con el prefijo.
                If txtCodigo.Text.ToString.Trim.Contains(My.Settings.PREP_tipoLote.ToString.Trim) Then
                    If lblColeccion.Text.ToString.Trim <> "" And (lblLote.Text.ToString.Trim = "" And txtCodigo.Text.ToString.Contains(My.Settings.PREP_caracter_Lote.ToString.Trim)) Then
                        If lblTipoLote.Text.ToString.Trim = "" Then
                            MessageBox.Show("Debe indicar el tipo de lote de la caja activa.", "Indicar tipo de lote", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        End If
                    Else
                        If My.Settings.PREP_tipoLote_fijo.ToString.Trim <> "" Then
                            lblTipoLote.Text = My.Settings.PREP_tipoLote_fijo.ToString.Trim
                        Else
                            If Not IsNothing(listaTipoLotes) Then
                                If listaTipoLotes.Count = 0 Then
                                    lblTipoLote.Text = IIf(My.Settings.PREP_tipoLote.ToString.Trim <> "", My.Settings.PREP_tipoLote.ToString.Trim, "Historias")
                                Else
                                    For Each elemento As Entidades.clsTipoLotesE In listaTipoLotes
                                        If txtCodigo.Text.ToString.Trim.Contains(elemento._PrefijoCB) Then
                                            lblTipoLote.Text = elemento._Nombre
                                            lblLote.Text = ""
                                            lblHistoria.Text = ""
                                            Exit For
                                        End If
                                    Next
                                End If
                            Else
                                lblTipoLote.Text = IIf(My.Settings.PREP_tipoLote.ToString.Trim <> "", My.Settings.PREP_tipoLote.ToString.Trim, "Historias")
                            End If
                        End If

                        txtCodigo.Text = ""
                        Exit Sub
                    End If
                End If

                '### JGARIJO 30/08/2019 -> INI COMPROBACION DE CAJA
                'Sabemos que en los codigos de barras de las cajas unicamente los ultimos digitos son su clave identificativa
                If txtCodigo.Text.ToString.Trim.Contains(My.Settings.PREP_caracter_caja.ToString.Trim) Or txtCodigo.Text.ToString.Trim.Contains(My.Settings.PREP_caracter_Caja2.ToString.Trim) Then
                    'Se almacena en CajaCompleta el codigo completo leido para usarlo posteriormente como contenedor

                    If chkBloquear.Checked = False Then lblTipoLote.Text = ""

                    CajaCompleta = txtCodigo.Text.ToString.Trim
                    'podemos encontrarnos varias casuisticas: si es un cambio dinamico de usuario, la caja es posible que ya este leida.
                    ' Anexaremos todo su contenido en el arbol donde corresponda

                    Encontrado = False
                    Call posicionarNodo(frmContenedorMDI.oProyecto._CodigoProyecto & " - " & frmContenedorMDI.oProyecto._nombreProyecto & "\" & Mid(txtCodigo.Text.ToString.ToString.Trim, txtCodigo.Text.ToString.Trim.LastIndexOf(";") + 2, txtCodigo.Text.ToString.Length))

                    'Comprobamos el tipo de caja que estamos leyendo. Primero, las cajas CJ
                    '''If Mid(CajaCompleta, 1, 2) = My.Settings.PREP_caracter_Caja2 Then
                    If Mid(CajaCompleta, 1, 2) = My.Settings.PREP_caracter_caja Then

                        Dim ResultadoData As DataTable = Nothing
                        Sentencia = "Select nomcontenedor from Contenedores where nomcontenedor='" & CajaCompleta & "'"
                        ResultadoData = AccesoDatos.ejecutarSQLDirectaTable(Sentencia, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto)
                        If ResultadoData.Rows.Count <= 0 Then
                            Sentencia = "INSERT INTO Contenedores (nomcontenedor) VALUES ('" & CajaCompleta & "')"
                            If AccesoDatos.ejecutaSQLEjecucion(Sentencia, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto, , True) = False Then
                                LanzarError("ERROR AL INSERTAR CAJA")
                                Call EscribirLog(lblUserPistoleado.Text, "Usuario " & lblUserPistoleado.Text.Trim & " . Se produce error al insertar la caja " & CajaCompleta & " en tabla Contenedores", "PREPARACION")
                            Else
                                QuitarError()
                                Call EscribirLog(lblUserPistoleado.Text, "Usuario " & lblUserPistoleado.Text.Trim & " inserta caja " & CajaCompleta & " en tabla Contenedores", "PREPARACION")
                            End If
                        End If

                    Else
                        'Caja del tipo 15, 16, etc...
                        If Mid(CajaCompleta, CajaCompleta.IndexOf(";") + 2, 2) <> "50" Then
                            NumCaja = Mid(txtCodigo.Text.ToString.ToString.Trim, txtCodigo.Text.ToString.Trim.LastIndexOf(";") + 2, txtCodigo.Text.ToString.Length)

                            'JANTONIO 'LIMITA CONEXION MYSQL
                            If My.Settings.cadenaConexionMySQL.ToString.Trim <> "" Then
                                'Primero, consultamos si la caja esta en MySQL, en la tabla caja_ubicacion
                                Sentencia = "SELECT caja FROM caja_ubicacion where caja ='" + CajaCompleta & "'"

                                Dim ResultadoData As DataTable = Nothing
                                ResultadoData = AccesoDatosMySQL.ejecutarMySQLDirectaTable(Sentencia, My.Settings.cadenaConexionMySQL)

                                If ResultadoData.Rows.Count <= 0 Then
                                    'Como condicion indispensable, la caja debe haber sido registrada previamente en caja_ubicacion. 
                                    'Si no es así, no se continua con la ejecución ya que provocaría inconsistencia
                                    LanzarError("CAJA NO CREADA PREVIAMENTE EN CAJA_UBICACION")
                                    Call EscribirLog(lblUserPistoleado.Text, "Usuario " & lblUserPistoleado.Text.Trim & " .Caja " & lblCaja.Text.ToString.Trim & " no creada en caja_ubicacion", "PREPARACION")
                                    Exit Sub
                                Else
                                    'Sabemos que la caja está en la base de datos. Procedemos a actualizar el registro en la tabla caja_ubicacion de la bd de MySQL 

                                    'JANTONIO 'LIMITA CONEXION MYSQL
                                    If My.Settings.cadenaConexionMySQL.ToString.Trim <> "" Then
                                        Sentencia = "UPDATE caja_ubicacion SET ubicacion = 'SALA DIGI' WHERE caja = '" & CajaCompleta & "'"
                                        If AccesoDatosMySQL.ejecutaMySQLEjecucion(Sentencia, My.Settings.cadenaConexionMySQL, , True) = False Then
                                            LanzarError("ERROR DE ACTUALIZACION UBICACION DE CAJA")
                                            Call EscribirLog(lblUserPistoleado.Text, "Usuario " & lblUserPistoleado.Text.Trim & " . Error en la actualizacion de la caja " & lblCaja.Text.ToString.Trim, "PREPARACION")
                                            Exit Sub
                                        End If

                                        'Sentencia = "Select nomcontenedor from Contenedores where nomcontenedor='" & CajaCompleta & "'"

                                        'ResultadoData = AccesoDatos.ejecutarSQLDirectaTable(Sentencia, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto)

                                        'If ResultadoData.Rows.Count <= 0 Then
                                        'Sentencia = "INSERT INTO Contenedores (nomcontenedor) VALUES ('" & CajaCompleta & "')"
                                        'If AccesoDatos.ejecutaSQLEjecucion(Sentencia, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto, , True) = False Then
                                        'LanzarError("ERROR AL ACTUALIZAR")
                                        'Call EscribirLog(lblUserPistoleado.Text, "Usuario " & lblUserPistoleado.Text.Trim & " . Se produce error al insertar la caja " & CajaCompleta & " en tabla Contenedores", "")
                                        'Else
                                        'QuitarError()
                                        'Call EscribirLog(lblUserPistoleado.Text, "Usuario " & lblUserPistoleado.Text.Trim & " inserta caja " & CajaCompleta & " en tabla Contenedores", "")
                                        'End If
                                        'End If

                                        'Si la ejecución de codigo llega a este punto, es que  el update ha funcionado
                                        QuitarError()
                                        Call EscribirLog(lblUserPistoleado.Text, "Usuario " & lblUserPistoleado.Text.Trim & " actualiza ubicacion de caja" & lblCaja.Text.ToString.Trim, "PREPARACION")

                                        'Cambiamos tambien el estado de las historias que contiene esa caja

                                        Sentencia = "Select * from stock_hcs_act where caja = '" & CajaCompleta & "' and activo>0 and activo <> 3"
                                        ResultadoData = AccesoDatosMySQL.ejecutarMySQLDirectaTable(Sentencia, My.Settings.cadenaConexionMySQL)

                                        If ResultadoData.Rows.Count > 0 Then
                                            Sentencia = "UPDATE stock_hcs_act SET estado = 'SALA DIGI', activo = 2 WHERE caja = '" & CajaCompleta & "' and activo>0 and activo <> 3"
                                            If AccesoDatosMySQL.ejecutaMySQLEjecucion(Sentencia, My.Settings.cadenaConexionMySQL, , True) = False Then
                                                LanzarError("ERROR DE ACTUALIZACION UBICACION DE HISTORIAS")
                                                Call EscribirLog(lblUserPistoleado.Text, "Usuario " & lblUserPistoleado.Text.Trim & " error en la actualizacion de la ubicacion de historias" & lblCaja.Text.ToString.Trim, "PREPARACION")
                                                Exit Sub
                                            End If
                                        End If

                                        'Si la ejecución de codigo llega a este punto, es que  el update ha funcionado
                                        QuitarError()
                                        Call EscribirLog(lblUserPistoleado.Text, "Usuario " & lblUserPistoleado.Text.Trim & " actualiza ubicacion de historias " & lblCaja.Text.ToString.Trim, "PREPARACION")
                                    End If
                                End If
                            End If
                        Else
                            'Caja del tipo 50

                            Dim ResultadoData As DataTable = Nothing
                            Sentencia = "Select nomcontenedor from Contenedores where nomcontenedor='" & CajaCompleta & "'"

                            ResultadoData = AccesoDatos.ejecutarSQLDirectaTable(Sentencia, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto)

                            If ResultadoData.Rows.Count <= 0 Then
                                Sentencia = "INSERT INTO Contenedores (nomcontenedor) VALUES ('" & CajaCompleta & "')"
                                If AccesoDatos.ejecutaSQLEjecucion(Sentencia, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto, , True) = False Then
                                    LanzarError("ERROR AL INSERTAR CAJA")
                                    Call EscribirLog(lblUserPistoleado.Text, "Usuario " & lblUserPistoleado.Text.Trim & " . Se produce error al insertar la caja " & CajaCompleta & " en tabla Contenedores", "PREPARACION")
                                Else
                                    QuitarError()
                                    Call EscribirLog(lblUserPistoleado.Text, "Usuario " & lblUserPistoleado.Text.Trim & " inserta caja " & CajaCompleta & " en tabla Contenedores", "PREPARACION")
                                End If
                            End If

                        End If
                    End If

                    QuitarError()

                    If Mid(CajaCompleta, 1, 2) = My.Settings.PREP_caracter_caja Then
                        txtCodigo.Text = Mid(txtCodigo.Text.ToString.Trim, InStrRev(txtCodigo.Text.ToString.Trim, My.Settings.PREP_caracter_caja) + My.Settings.PREP_caracter_caja.ToString.Trim.Length, txtCodigo.Text.ToString.Trim.Length)
                    ElseIf Mid(CajaCompleta, 1, 2) = My.Settings.PREP_caracter_Caja2 Then
                        txtCodigo.Text = Mid(txtCodigo.Text.ToString.Trim, InStrRev(txtCodigo.Text.ToString.Trim, My.Settings.PREP_caracter_Caja2) + My.Settings.PREP_caracter_Caja2.ToString.Trim.Length, txtCodigo.Text.ToString.Trim.Length)
                    End If

                    cajaActiva = txtCodigo.Text.ToString.Trim
                    elementoActivo = cajaActiva

                    If Not Encontrado Then
                        If añadeALista("Caja", txtCodigo.Text.ToString.Trim) Then
                            txtCodigo.Text = ""
                            QuitarError()
                            Call EscribirLog(lblUserPistoleado.Text, "Usuario : " & lblUserPistoleado.Text.Trim & " añade caja " + cajaActiva.Trim, "PREPARACION")
                            Me.Refresh()

                            cargaDatos()
                            trvGeneral.ExpandAll()
                            posicionarNodo(elementoActivo.ToString.Trim)
                            seleccionarNodo(elementoActivo.ToString.Trim)
                            trvGeneral.Focus()
                            txtCodigo.Focus()
                            Exit Sub
                        End If
                    End If

                End If

                '### JGARIJO 30/08/2019 -> FIN COMPROBACION DE CAJA

                'La coleccion no es obligatoria y podemos encontrar el espacio en blanco
                ' INI: ESTA MODIFICACION ES POR SI LA COLECCION PASA VACIA
                '
                '### JGARIJO 30/08/2019 -> INI COMPROBACION DE COLECCION
                If My.Settings.PREP_caracter_Coleccion.ToString.Trim <> "" And txtCodigo.Text.Contains(My.Settings.PREP_caracter_Coleccion.ToString.Trim) Then

                    If chkBloquear.Checked = False Then lblTipoLote.Text = ""

                    'El codigo leido pertenece a una coleccion
                    txtCodigo.Text = Replace(txtCodigo.Text.Trim, My.Settings.PREP_caracter_Coleccion.ToString.Trim, "")

                    Encontrado = False

                    Call posicionarNodo(frmContenedorMDI.oProyecto._CodigoProyecto & " - " & frmContenedorMDI.oProyecto._nombreProyecto & "\" & lblCaja.Text.Trim & "\" & txtCodigo.Text)

                    If Not Encontrado Then

                        If lblCaja.Text.ToString.Trim() <> "" Then
                            coleccionActiva = txtCodigo.Text.ToString.Trim
                            elementoActivo = coleccionActiva
                            If añadeALista("Col", txtCodigo.Text.ToString.Trim) Then
                                txtCodigo.Text = ""
                                QuitarError()
                                Call EscribirLog(lblUserPistoleado.Text, "Usuario : " & lblUserPistoleado.Text.Trim & " añade coleccion " & coleccionActiva.Trim, "PREPARACION")
                            End If
                        Else
                            'Antes de leer la coleccion es obligatorio que se haya producido la lectura de la caja. Si no es así, se genera un error
                            LanzarError("ERROR LECTURA. CAJA VACIA")
                            Call EscribirLog(lblUserPistoleado.Text, "Usuario " & lblUserPistoleado.Text.Trim & " intenta añadir coleccion " & coleccionActiva.Trim & " en caja vacia", "PREPARACION")
                            Exit Sub
                        End If
                    End If
                End If
                '### JGARIJO 30/08/2019 -> FIN COMPROBACION DE COLECCION
                ' FIN: ESTA MODIFICACION ES POR SI LA COLECCION PASA VACIA

                If txtCodigo.Text.Contains(My.Settings.PREP_caracter_Lote.ToString.Trim) Then
                    'el codigo leido pertenece a un Lote

                    If lblTipoLote.Text.ToString.Trim = "" Then
                        'MessageBox.Show("Debe indicar el tipo de lote antes de identificar el lote.", "Indicar tipo lote", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        LanzarError("DEBE INDICAR EL TIPO DE LOTE ANTES DE IDENTIFICAR EL LOTE.")
                        lblLote.Text = ""
                        Exit Sub
                    End If

                    txtCodigo.Text = Replace(txtCodigo.Text.Trim, My.Settings.PREP_caracter_Lote.ToString.Trim, "")

                    Encontrado = False
                    Call posicionarNodo(frmContenedorMDI.oProyecto._CodigoProyecto & " - " & frmContenedorMDI.oProyecto._nombreProyecto & "\" & lblCaja.Text.Trim & "\" & lblColeccion.Text.Trim & "\" & txtCodigo.Text.Trim)

                    If Not Encontrado Then

                        If lblColeccion.Text.ToString.Trim <> "" Then

                            loteActivo = txtCodigo.Text.ToString.Trim
                            elementoActivo = loteActivo

                            'JANTONIO 'VALIDACION MISMO LOTE EN CAJAS DIFERENTES
                            Dim Sql As String = ""
                            Dim dt As DataTable
                            Sql = "SELECT * FROM loteado where NumLote = " & loteActivo & " AND NOT NumCaja=" & lblCaja.Text.Replace(";", "")
                            dt = AccesoDatos.ejecutarSQLDirectaTable(Sql, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto)
                            If dt.Rows.Count > 0 Then
                                LanzarError("MISMO LOTE EN DOS CAJAS DIFERENTES")
                                Call EscribirLog(lblUserPistoleado.Text, "Usuario " & lblUserPistoleado.Text.Trim & " . Mismo lote en dos cajas diferentes", "PREPARACION")
                                Exit Sub
                            End If
                            '***************************************************

                            If añadeALista("Lote", txtCodigo.Text.ToString.Trim) Then
                                loteAnterior = txtCodigo.Text.ToString.Trim()
                                txtCodigo.Text = ""
                                QuitarError()
                                Call EscribirLog(lblUserPistoleado.Text, "Usuario : " & lblUserPistoleado.Text.Trim & " añade lote " + loteActivo.Trim, "PREPARACION")

                                Dim SentenciaSQL As String = "SELECT * FROM LOTES WHERE idLote = " & loteAnterior
                                Dim ResultadoData As DataTable = Nothing

                                Dim momento_actual As String = CStr(Year(Now)) & "-" & CStr(Month(Now)) & "-" & CStr(Microsoft.VisualBasic.DateAndTime.Day(Now)) & " " & CStr(Hour(Now)) & ":" & CStr(Minute(Now)) & ":" & CStr(Second(Now))

                                ResultadoData = AccesoDatos.ejecutarSQLDirectaTable(SentenciaSQL, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto)

                                If ResultadoData.Rows.Count > 0 Then
                                    Dim sentenciaNueva As String = ""
                                    Dim elementoAnterior As String = ""
                                    Dim resultadoComprobacion As Boolean

                                    If lblTipoLote.Text.ToString.Trim <> "" Then SentenciaSQL = ", DAT='" & lblTipoLote.Text.ToString.Trim & "'" Else SentenciaSQL = ""
                                    'COMPRUEBA VALORES DE SERVICIO Y DOCUMENTO
                                    If cboServicio.Text.ToString.Trim <> "" Then
                                        resultadoComprobacion = compruebaSiMismoElemento(loteActivo, "Servicio", cboServicio.Text.ToString.Trim, elementoAnterior, sentenciaNueva)
                                        If sentenciaNueva <> "" And elementoAnterior <> "" And resultadoComprobacion = False Then
                                            'Nuevo valor, por tanto, pregunta si lo quiere cambiar.
                                            If MessageBox.Show("El lote tenía el servicio con código " & elementoAnterior & ", ahora lo cambiará por el valor " & cboServicio.Text.ToString.Trim & vbLf & " ¿desea cambiarlo?", "Cambiar servicio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                                                SentenciaSQL = SentenciaSQL & "," & sentenciaNueva
                                            End If
                                        ElseIf sentenciaNueva <> "" And elementoAnterior = "" And resultadoComprobacion = False Then
                                            'Antes no tenía valor, por tanto, lo actualiza sin preguntar.
                                            SentenciaSQL = SentenciaSQL & "," & sentenciaNueva
                                        End If
                                    End If

                                    If cboTipoDocumento.Text.ToString.Trim <> "" Then
                                        sentenciaNueva = ""
                                        resultadoComprobacion = compruebaSiMismoElemento(loteActivo, "Documento", cboTipoDocumento.Text.ToString.Trim, elementoAnterior, sentenciaNueva)
                                        If sentenciaNueva <> "" And elementoAnterior <> "" And resultadoComprobacion = False Then
                                            'Nuevo valor, por tanto, pregunta si lo quiere cambiar.
                                            If MessageBox.Show("El lote tenía el documento con código " & elementoAnterior & ", ahora lo cambiará por el valor " & cboTipoDocumento.Text.ToString.Trim & vbLf & " ¿desea cambiarlo?", "Cambiar documento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                                                SentenciaSQL = SentenciaSQL & "," & sentenciaNueva
                                            End If
                                        ElseIf sentenciaNueva <> "" And elementoAnterior = "" And resultadoComprobacion = False Then
                                            'Antes no tenía valor, por tanto, lo actualiza sin preguntar.
                                            SentenciaSQL = SentenciaSQL & "," & sentenciaNueva
                                        End If
                                    End If
                                    '***************************************

                                    '''SentenciaSQL = "UPDATE Lotes SET nomcontenedor='" & CajaCompleta & "',coleccion='" & lblColeccion.Text.ToString.Trim & "'" & SentenciaSQL & " WHERE idLote=" & loteActivo
                                    SentenciaSQL = "UPDATE Lotes SET nomcontenedor='" & cajaActiva & "',coleccion='" & lblColeccion.Text.ToString.Trim & "'" & SentenciaSQL & " WHERE idLote=" & loteActivo
                                    If AccesoDatos.ejecutaSQLEjecucion(SentenciaSQL, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto, , True) = False Then
                                        LanzarError("ERROR DE ACTUALIZACION DE LOTE")
                                        Call EscribirLog(lblUserPistoleado.Text, "Usuario " & lblUserPistoleado.Text.Trim & " intenta actualizar lote " & loteActivo.Trim, "PREPARACION")
                                        Exit Sub
                                    End If
                                Else
                                    LanzarError("LOTE NO GENERADO PREVIAMENTE")
                                    Call EscribirLog(lblUserPistoleado.Text, "Usuario " & lblUserPistoleado.Text.Trim & " intenta añadir lote " & loteActivo.Trim & " que no ha sido creado previamente en Lotes", "PREPARACION")
                                    Exit Sub
                                End If

                                'Si es diario crea el registro en loteado sin NHC.
                                If lblTipoLote.Text.ToString.Trim.ToUpper.Contains("DIARIO") Then
                                    SentenciaSQL = "INSERT INTO loteado (Proyecto, UsuarioLoteado, Codigo, NumCaja, NumLote, NHC, FechaLoteado) values ('"
                                    SentenciaSQL = SentenciaSQL & frmContenedorMDI.oProyecto._CodigoProyecto & "','" & lblUserPistoleado.Text & "',0," & lblCaja.Text.Replace(";", "") & "," & loteActivo & ",0,'" & Now.ToString & "')"
                                    If AccesoDatos.ejecutaSQLEjecucion(SentenciaSQL, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto, , True) = False Then
                                        LanzarError("ERROR AL INSERTAR")
                                        Call EscribirLog(lblUserPistoleado.Text, "Usuario " & lblUserPistoleado.Text.Trim & " . Se produce error al insertar " & historiaActiva & " en lote " & lblLote.Text, "PREPARACION")
                                        Exit Sub
                                    Else
                                        QuitarError()
                                        Call EscribirLog(lblUserPistoleado.Text, "Usuario " & lblUserPistoleado.Text.Trim & " . Historia " & historiaActiva & " introducida conrrectamente en lote " & lblLote.Text, "PREPARACION")
                                        Me.Refresh()
                                    End If

                                    'Actualiza fechaInicioPreparación y fechaFinPreparación en trazabilidadlotes
                                    SentenciaSQL = "UPDATE TrazabilidadLotes SET FechaInicioPreparado = '" & Now.ToString & "', "
                                    SentenciaSQL = SentenciaSQL & "FechaFinPreparado = '" & Now.ToString & "', "
                                    SentenciaSQL = SentenciaSQL & "UsuarioPreparado = '" & lblUserPistoleado.Text & "' "
                                    SentenciaSQL = SentenciaSQL & "WHERE IdLote = " & loteActivo
                                    AccesoDatos.ejecutaSQLEjecucion(SentenciaSQL, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto, , True)
                                    '****************************************************************************
                                End If
                            End If
                        End If
                    End If
                End If

                '### JGARIJO 30/08/2019 -> FIN COMPROBACION DE LOTE

                Dim oNodex As TreeNode
                Dim nombreCampo As String = ""
                Dim TextoExcepcion As String = ""

                '### JGARIJO 02/09/2019 -> INI DE COMPROBACION DE LAS EXCEPCIONES EN LAS HISTORIAS
                'Las excepciones se tratan siempre que ya se ha introducido la historia a la que hacen referencia en la base de datos
                'Comprobamos que el codigo leido sea uno de los codigos de excepcion controlados menos el de borrado (codigo ERROR)

                If CodExcepcion.Contains(My.Settings.PREP_caracter_RX.ToString.Trim) Or CodExcepcion.Contains(My.Settings.PREP_caracter_SinDoc.ToString.Trim) Or CodExcepcion.Contains(My.Settings.PREP_caracter_CD.ToString.Trim) Or CodExcepcion.Contains(My.Settings.PREP_caracter_ND.ToString.Trim) Or CodExcepcion.Contains(My.Settings.PREP_caracter_ERROR.ToString.Trim) Or CodExcepcion.Contains(My.Settings.PREP_caracter_ERROR.ToString.Trim) Or CodExcepcion.Contains(My.Settings.PREP_caracter_DESTRUIR.ToString.Trim) Or CodExcepcion.Contains(My.Settings.PREP_caracter_CI.ToString.Trim) Then



                    'comprobacion de excepciones. Historia marcada como Rayos X
                    indice = frmContenedorMDI.oProyecto._CodigoProyecto & " - " & frmContenedorMDI.oProyecto._nombreProyecto
                    If lblCaja.Text.ToString.Trim <> "" Then indice = indice & "\" & lblCaja.Text.ToString.Trim
                    If lblColeccion.Text.ToString.Trim <> "" Then indice = indice & "\" & lblColeccion.Text.ToString.Trim
                    'If lblTipoLote.Text.ToString.Trim <> "" Then indice = indice & "\" & lblTipoLote.Text.ToString.Trim
                    'If lblLote.Text.ToString.Trim <> "" Then indice = indice & "\" & lblLote.Text.ToString.Trim 
                    If lblLote.Text.ToString.Trim <> "" Then indice = indice & "\" & lblLote.Text.ToString.Trim & " - " & lblTipoLote.Text.ToString.Trim
                    If lblHistoria.Text.ToString.Trim <> "" Then indice = indice & "\" & lblHistoria.Text.ToString.Trim

                    oNodex = seleccionarNodo(indice)

                    oNodex.ForeColor = colorHistoria

                    Sentencia = ""

                    'comprobamos que tipo de excepcion es:
                    If CodExcepcion.Contains(My.Settings.PREP_caracter_RX.ToString.Trim) Then
                        'es una excepcion de rayos x
                        Sentencia = "UPDATE loteado SET ContieneRX = 1 WHERE NumCaja=" & lblCaja.Text.ToString.Trim & " AND NumLote=" & lblLote.Text.ToString.Trim & " AND NHC=" & lblHistoria.Text.ToString.Trim
                        TextoExcepcion = " (RAYOS X)"
                    Else
                        If CodExcepcion.Contains(My.Settings.PREP_caracter_SinDoc.ToString.Trim) Then
                            ' es una excepcion de sin documentacion
                            Sentencia = "UPDATE loteado SET SinDocumentos = 1 WHERE NumCaja=" & lblCaja.Text.ToString.Trim & " AND NumLote=" & lblLote.Text.ToString.Trim & " AND NHC=" & lblHistoria.Text.ToString.Trim
                            TextoExcepcion = " (SIN DOCUMENTACION)"
                        Else
                            If CodExcepcion.Contains(My.Settings.PREP_caracter_CD.ToString.Trim) Then
                                ' es una excepcion de cd
                                Sentencia = "UPDATE loteado SET ContieneCD = 1 WHERE NumCaja=" & lblCaja.Text.ToString.Trim & " AND NumLote=" & lblLote.Text.ToString.Trim & " AND NHC=" & lblHistoria.Text.ToString.Trim
                                TextoExcepcion = " (EN CD)"
                            Else
                                If CodExcepcion.Contains(My.Settings.PREP_caracter_ND.ToString.Trim) Then
                                    ' es una excepcion de no destruir 
                                    Sentencia = "UPDATE loteado SET NoTirar = 1 WHERE NumCaja=" & lblCaja.Text.ToString.Trim & " AND NumLote=" & lblLote.Text.ToString.Trim & " AND NHC=" & lblHistoria.Text.ToString.Trim
                                    TextoExcepcion = " (NO DESTRUIR)"
                                Else
                                    If CodExcepcion.Contains(My.Settings.PREP_caracter_DESTRUIR.ToString.Trim) Then
                                        ' es una excepcion de destruir 
                                        Sentencia = "UPDATE loteado SET Destruir = 1 WHERE NumCaja=" & lblCaja.Text.ToString.Trim & " AND NumLote=" & lblLote.Text.ToString.Trim & " AND NHC=" & lblHistoria.Text.ToString.Trim
                                        TextoExcepcion = " (DESTRUIR)"
                                    Else
                                        If CodExcepcion.Contains(My.Settings.PREP_caracter_CI.ToString.Trim) Then
                                            ' ############# JGARIJO 04/11/2019 ################## 
                                            Sentencia = "UPDATE LOTES SET consentimientoinformado = 1 WHERE nomcontenedor=" & lblCaja.Text.ToString.Trim & " AND idLote=" & lblLote.Text.ToString.Trim
                                            Sentencia = Sentencia & ";UPDATE loteado SET consentimientoinformado = 1 WHERE NumCaja=" & lblCaja.Text.ToString.Trim & " AND NumLote=" & lblLote.Text.ToString.Trim & " AND NHC=" & lblHistoria.Text.ToString.Trim
                                            'Sentencia = "UPDATE LOTES SET consentimientoinformado = 1 WHERE nomcontenedor='" & CajaCompleta & "' AND idLote=" & lblLote.Text.ToString.Trim
                                            TextoExcepcion = " (CON.INFORMADO)"
                                        Else
                                            Sentencia = ""
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                    If Sentencia <> "" Then
                        If AccesoDatos.ejecutaSQLEjecucion(Sentencia, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto, , True) = False Then
                            LanzarError("ERROR DE ACTUALIZACION")
                            Call EscribirLog(lblUserPistoleado.Text, "Error al actualizar estado de excepción de historia " & lblHistoria.Text.ToString.Trim & " del usuario " & lblUserPistoleado.Text.Trim & " en caja " & lblCaja.Text.ToString.Trim & ", lote " & lblLote.Text.ToString.Trim, "PREPARACION")
                            Exit Sub
                        Else
                            oNodex.Text = oNodex.Text & TextoExcepcion
                            txtCodigo.Text = ""
                            QuitarError()
                            Call EscribirLog(lblUserPistoleado.Text, "Actualizacion de estado de excepcion correcto de historia " & lblHistoria.Text.ToString.Trim & " en la caja " & lblCaja.Text.ToString.Trim & " por el usuario " & lblUserPistoleado.Text.Trim, "PREPARACION")
                        End If
                    End If
                End If

                'control del codigo de borrado "ERROR"
                If CodExcepcion.Contains(My.Settings.PREP_caracter_ERROR.ToString.Trim) Then

                    If lblCaja.Text.ToString.Trim = "" Or lblColeccion.Text.ToString.Trim = "" Or lblLote.Text.ToString.Trim = "" Or lblHistoria.Text.ToString.Trim = "" Then
                        LanzarError("SOLO SE PUEDEN BORRAR HISTORIAS")
                        Call EscribirLog(lblUserPistoleado.Text, "Error de borrado de usuario " & lblUserPistoleado.Text.Trim & " en caja " & lblCaja.Text.ToString.Trim & ", lote " & lblLote.Text.ToString.Trim & " e historia " & lblHistoria.Text.ToString.Trim, "PREPARACION")
                        Exit Sub
                    End If

                    'se ha equivocado a la hora de escanear el código. eliminamos la última historia
                    indice = frmContenedorMDI.oProyecto._CodigoProyecto & " - " & frmContenedorMDI.oProyecto._nombreProyecto
                    If lblCaja.Text.ToString.Trim <> "" Then indice = indice & "\" & lblCaja.Text.ToString.Trim
                    If lblColeccion.Text.ToString.Trim <> "" Then indice = indice & "\" & lblColeccion.Text.ToString.Trim
                    'If lblTipoLote.Text.ToString.Trim <> "" Then indice = indice & "\" & lblTipoLote.Text.ToString.Trim
                    'If lblLote.Text.ToString.Trim <> "" Then indice = indice & "\" & lblLote.Text.ToString.Trim
                    If lblLote.Text.ToString.Trim <> "" Then indice = indice & "\" & lblLote.Text.ToString.Trim & " - " & lblTipoLote.Text.ToString.Trim
                    If lblHistoria.Text.ToString.Trim <> "" Then indice = indice & "\" & lblHistoria.Text.ToString.Trim

                    Hist_Activa = lblHistoria.Text.ToString.Trim

                    oNodex = seleccionarNodo(indice)

                    oNodex.Nodes.Remove(oNodex)
                    Me.Refresh()

                    Sentencia = "DELETE FROM loteado WHERE "
                    Sentencia = Sentencia & "NumCaja = " & CInt(Replace(lblCaja.Text.ToString.Trim, ";", ""))
                    Sentencia = Sentencia & " AND NumLote = " & lblLote.Text.ToString.Trim
                    Sentencia = Sentencia & " AND NHC = " & Hist_Activa
                    Sentencia = Sentencia & " AND UsuarioLoteado = '" & lblUserPistoleado.Text & "'"

                    If AccesoDatos.ejecutaSQLEjecucion(Sentencia, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto, , True) = False Then
                        txtCodigo.Text = ""
                        LanzarError("ERROR DE BORRADO")
                        Call EscribirLog(lblUserPistoleado.Text, "Error de borrado de usuario " & lblUserPistoleado.Text.Trim & " en caja " & lblCaja.Text.ToString.Trim & ", lote " & lblLote.Text.ToString.Trim & " e historia " & lblHistoria.Text.ToString.Trim, "PREPARACION")
                        Exit Sub
                    Else
                        txtCodigo.Text = ""
                        QuitarError()
                        Call EscribirLog(lblUserPistoleado.Text, "Historia " & lblHistoria.Text.ToString.Trim & " borrada correctamente por el usuario " & lblUserPistoleado.Text.Trim & " en caja " & lblCaja.Text.ToString.Trim & ", lote " & lblLote.Text.ToString.Trim, "PREPARACION")
                        Me.Refresh()
                    End If

                    'LLAMADA A ACCION RECURSIVA PARA OBTENER TODOS LOS NODOS DEL TREEVIEW
                    Dim ColectArbol As TreeNodeCollection = trvGeneral.Nodes
                    'Se recorren los nodos principales
                    For Each n As TreeNode In ColectArbol
                        RecorrerTodosLosNodos(n)
                    Next
                    Dim clau As String = frmContenedorMDI.oProyecto._CodigoProyecto & " - " & frmContenedorMDI.oProyecto._nombreProyecto & PathRecursivo

                    'Vaciamos pathRecursivo
                    PathRecursivo = ""

                    lblHistoria.Text = Mid(clau, clau.LastIndexOf("/") + 2, clau.Length)
                    seleccionarNodo(clau)

                    historiaActiva = ""
                    Exit Sub

                End If

                '### JGARIJO 30/08/2019 -> INI COMPROBACION DE HISTORIAS

                'POR DEFECTO, SI NO HAY CARACTERES QUE CUMPLAN CON LAS CONDICIONES ANTERIORES, SERAN HISTORIAS

                If Not CodExcepcion.Contains(My.Settings.PREP_caracter_RX.ToString.Trim) And _
                    Not CodExcepcion.Contains(My.Settings.PREP_caracter_Caja.ToString.Trim) And _
                    Not CodExcepcion.Contains(My.Settings.PREP_caracter_Coleccion.ToString.Trim) And _
                    Not CodExcepcion.Contains(My.Settings.PREP_caracter_Lote.ToString.Trim) And _
                    Not CodExcepcion.Contains(My.Settings.PREP_caracter_NHC.ToString.Trim) And _
                    Not CodExcepcion.Contains(My.Settings.PREP_caracter_Usuario.ToString.Trim) And _
                    Not CodExcepcion.Contains(My.Settings.PREP_caracter_RX.ToString.Trim) And _
                    Not CodExcepcion.Contains(My.Settings.PREP_caracter_SinDoc.ToString.Trim) And _
                    Not CodExcepcion.Contains(My.Settings.PREP_caracter_CD.ToString.Trim) And _
                    Not CodExcepcion.Contains(My.Settings.PREP_caracter_ND.ToString.Trim) And _
                    Not CodExcepcion.Contains(My.Settings.PREP_caracter_DESTRUIR.ToString.Trim) And _
                    Not CodExcepcion.Contains(My.Settings.PREP_caracter_CI.ToString.Trim) Then

                    'el booleano nos indica que ha encontrado el valor en el array de valores
                    'NHC
                    'hemos almacenado qué valor del array es el que hemos encontrado. Reemplazamos el valor 

                    'Admitimos cualquier tipo de codigo para historiales menos aquellos que llevan letras o caracteres en mitad del codigo

                    Dim temporal As String = Replace(Replace(Replace(txtCodigo.Text.Trim, "H", ""), "C", ""), "*", "")
                    Dim HayCaracterError As Boolean = False

                    For i As Int16 = 1 To temporal.Length
                        If Asc(Mid(temporal, i, 1)) < 48 Or Asc(Mid(temporal, i, 1)) > 57 Then
                            'Sabemos que hay un caracter no numerico. La BD espera un integer. Si hay un caracter no numerico no podrá hacer la conversion
                            HayCaracterError = True
                        End If
                    Next

                    If HayCaracterError Then
                        LanzarError("FORMATO NO ADMITIDO ETIQUETA HISTORIA")
                        Call EscribirLog(lblUserPistoleado.Text, "Formato incorrecto en el número de la historia " & temporal & " por el usuario " & lblUserPistoleado.Text.Trim, "PREPARACION")
                        Exit Sub
                    End If

                    'txtCodigo.Text = CStr(CInt(temporal))  'JANTONIO 'eLIMINO PREFIJO NHC

                    If lblLote.Text.ToString.Trim() <> "" Then
                        'JANTONIO 'eLIMINO PREFIJO NHC
                        ' ''historiaActiva = txtCodigo.Text.ToString.Trim.Replace(My.Settings.PREP_elimina_prefijo_NHC, "").ToString.TrimStart("0")
                        'JANTONIO v 2.0.0.9 14-4-2020
                        If txtCodigo.Text.ToString.Trim.Substring(0, 3) = My.Settings.PREP_elimina_prefijo_NHC Then
                            historiaActiva = txtCodigo.Text.ToString.Trim.Substring(3)
                        Else
                            historiaActiva = txtCodigo.Text.ToString.Trim
                        End If
                        'historiaActiva = txtCodigo.Text.ToString.Trim
                        '*****************************

                        elementoActivo = historiaActiva

                        Dim numRegistros As Integer = 0
                        Dim SentenciaSQL As String = ""
                        Dim ResultadoData As DataTable = Nothing

                        'JANTONIO 'LIMITA CONEXION MYSQL
                        If My.Settings.cadenaConexionMySQL.ToString.Trim <> "" Then
                            SentenciaSQL = "SELECT * FROM stock_hcs_act where nhc = '" & historiaActiva & "'"
                            ResultadoData = AccesoDatosMySQL.ejecutarMySQLDirectaTable(SentenciaSQL, My.Settings.cadenaConexionMySQL)
                            If ResultadoData.Rows.Count = 0 Then
                                LanzarError("HISTORIA NO INVENTARIADA")
                                Call EscribirLog(lblUserPistoleado.Text, "Usuario " & lblUserPistoleado.Text.Trim & " . Historia no inventariada " & historiaActiva, "PREPARACION")
                                Exit Sub
                            End If
                        End If

                        'If Not historiaActiva.Contains(My.Settings.PREP_caracter_RX.ToString.Trim) And Not historiaActiva.Contains(My.Settings.PREP_caracter_CD.ToString.Trim) And Not historiaActiva.Contains(My.Settings.PREP_caracter_ND.ToString.Trim) And Not historiaActiva.Contains(My.Settings.PREP_caracter_SinDoc.ToString.Trim) And Not historiaActiva.Contains(My.Settings.PREP_caracter_ERROR.ToString.Trim) Then
                        If añadeALista("NHC", txtCodigo.Text.ToString.Trim) Then
                            txtCodigo.Text = ""
                            'lanzamos una consulta de SQL buscando en la tabla lotes si ya ha sido registrado. Asi evitamos que haya inconsistencia entre la tabla loteados y lotes
                            '### JAVIER 09/09/2019 INI COMPROBACION DE LOTE EN TABLA LOTES
                            'Dim numRegistros As Integer = 0
                            'Dim SentenciaSQL As String = ""
                            'Dim ResultadoData As DataTable = Nothing

                            '### JAVIER 09/09/2019 FIN COMROBACION DE LOTE EN TABLA LOTES

                            'JANTONIO 'VALIDACION MISMO LOTE EN CAJAS DIFERENTES
                            'SentenciaSQL = "SELECT * FROM loteado where NumLote = " & lblLote.Text & " AND NOT NumCaja=" & lblCaja.Text.Replace(";", "")
                            'ResultadoData = AccesoDatos.ejecutarSQLDirectaTable(SentenciaSQL, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto)
                            'If ResultadoData.Rows.Count > 0 Then
                            '    LanzarError("MISMO LOTE EN DOS CAJAS DIFERENTES")
                            '    Call EscribirLog(lblUserPistoleado.Text, "Usuario " & lblUserPistoleado.Text.Trim & " . Mismo lote en dos cajas diferentes", "PREPARACION")
                            '    Exit Sub
                            'End If
                            '***************************************************

                            'Revisamos si la historia ya ha sido escaneada con anterioridad. En caso positivo, lanzaremos un update sobre el registro en concreto
                            ''SentenciaSQL = "SELECT * FROM loteado where NHC = '" & historiaActiva & "'"
                            'Dim loteTem As String = lblLote.Text.Substring(0, lblLote.Text.IndexOf("-") - 1)
                            'lblLote.Text = loteTem.Substring(0, loteTem.IndexOf("-") - 1)
                            SentenciaSQL = "SELECT * FROM loteado where NumLote = " & Convert.ToInt32(lblLote.Text) & " AND NHC = '" & historiaActiva & "' AND Proyecto = '" & frmContenedorMDI.oProyecto._CodigoProyecto & "'"

                            ResultadoData = AccesoDatos.ejecutarSQLDirectaTable(SentenciaSQL, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto)

                            If ResultadoData.Rows.Count > 0 Then
                                If MessageBox.Show("Ya ha sido preparada la historia " & historiaActiva & " del lote " & Convert.ToInt32(lblLote.Text) & " en la caja " & ResultadoData.Rows(0).Item("NumCaja") & "." & vbLf & "¿Desea actualizar la información?", "Preparación ya existente", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.OK Then
                                    SentenciaSQL = "UPDATE loteado SET "
                                    SentenciaSQL = SentenciaSQL & "UsuarioLoteado = '" & lblUserPistoleado.Text & "', "
                                    SentenciaSQL = SentenciaSQL & "Codigo=0, "
                                    SentenciaSQL = SentenciaSQL & "NumCaja=" & lblCaja.Text.Replace(";", "") & ", "
                                    SentenciaSQL = SentenciaSQL & "FechaLoteado='" & Now.ToString & "' "
                                    SentenciaSQL = SentenciaSQL & "WHERE NumLote = " & Convert.ToInt32(lblLote.Text) & " AND NHC = '" & historiaActiva & "' AND Proyecto = '" & frmContenedorMDI.oProyecto._CodigoProyecto & "'"

                                    If AccesoDatos.ejecutaSQLEjecucion(SentenciaSQL, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto, , True) = False Then
                                        LanzarError("ERROR AL ACTUALIZAR")
                                        Call EscribirLog(lblUserPistoleado.Text, "Usuario " & lblUserPistoleado.Text.Trim & " . Se produce error al actualizar " & historiaActiva & " en lote " & lblLote.Text, "PREPARACION")
                                    Else
                                        QuitarError()
                                        Call EscribirLog(lblUserPistoleado.Text, "Usuario " & lblUserPistoleado.Text.Trim & " . Historia " & historiaActiva & " actualizada conrrectamente en lote " & lblLote.Text, "PREPARACION")
                                    End If
                                    'Actualiza fechaInicioPreparación y fechaFinPreparación en trazabilidadlotes
                                    SentenciaSQL = "UPDATE TrazabilidadLotes SET FechaFinPreparado = '" & Now.ToString & "', "
                                    SentenciaSQL = SentenciaSQL & "UsuarioPreparado = '" & lblUserPistoleado.Text & "' "
                                    SentenciaSQL = SentenciaSQL & "WHERE IdLote = " & Convert.ToInt32(lblLote.Text.Substring(0, lblLote.Text.IndexOf("-") - 1))
                                    AccesoDatos.ejecutaSQLEjecucion(SentenciaSQL, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto, , True)
                                Else
                                    Exit Sub
                                End If

                            Else
                                'Generamos la sentencia SQL con los datos recogidos
                                'Si la ejecucion de codigo llega hasta aquí sabemos que el lotes se ha introducido en la tabla lotes anteriormente de manera correcta
                                ' ''SentenciaSQL = "SELECT * FROM loteado where NumLote = " & lblLote.Text & " AND NHC = '" & historiaActiva & "'"
                                ' ''ResultadoData = AccesoDatos.ejecutarSQLDirectaTable(SentenciaSQL, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto)
                                '' ''Si el resultado del select es 0, hay que registrarlo en loteados como nuevo
                                ' ''If ResultadoData.Rows.Count <= 0 Then
                                SentenciaSQL = "INSERT INTO loteado (Proyecto, UsuarioLoteado, Codigo, Incidencia, NHC, NumCaja, NumLote, FechaLoteado) values ('"
                                SentenciaSQL = SentenciaSQL & frmContenedorMDI.oProyecto._CodigoProyecto & "','" & lblUserPistoleado.Text & "',0,0," & historiaActiva & "," & lblCaja.Text.Replace(";", "") & "," & lblLote.Text & ",'" & Now.ToString & "')"
                                If AccesoDatos.ejecutaSQLEjecucion(SentenciaSQL, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto, , True) = False Then
                                    LanzarError("ERROR AL INSERTAR")
                                    Call EscribirLog(lblUserPistoleado.Text, "Usuario " & lblUserPistoleado.Text.Trim & " . Se produce error al insertar " & historiaActiva & " en lote " & lblLote.Text, "PREPARACION")
                                    Exit Sub
                                Else
                                    QuitarError()
                                    Call EscribirLog(lblUserPistoleado.Text, "Usuario " & lblUserPistoleado.Text.Trim & " . Historia " & historiaActiva & " introducida conrrectamente en lote " & lblLote.Text, "PREPARACION")
                                    Me.Refresh()
                                End If
                                'Actualiza fechaInicioPreparación y fechaFinPreparación en trazabilidadlotes
                                SentenciaSQL = "UPDATE TrazabilidadLotes SET FechaInicioPreparado = '" & Now.ToString & "', "
                                SentenciaSQL = SentenciaSQL & "FechaFinPreparado = '" & Now.ToString & "', "
                                SentenciaSQL = SentenciaSQL & "UsuarioPreparado = '" & lblUserPistoleado.Text & "' "
                                SentenciaSQL = SentenciaSQL & "WHERE IdLote = " & Convert.ToInt32(lblLote.Text)
                                AccesoDatos.ejecutaSQLEjecucion(SentenciaSQL, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto, , True)
                                '****************************************************************************
                                ' ''Else
                                ' ''    'Si el resultado del if es negativo sabemos que los datos ya estan en la base de datos y hay que actualizar los valores
                                ' ''    SentenciaSQL = "UPDATE loteado SET Proyecto = " & frmContenedorMDI.oProyecto._CodigoProyecto & ", "
                                ' ''    SentenciaSQL = SentenciaSQL & "UsuarioLoteado = '" & lblUserPistoleado.Text & "', "
                                ' ''    SentenciaSQL = SentenciaSQL & "Codigo=0, NHC=" & historiaActiva & ", "
                                ' ''    SentenciaSQL = SentenciaSQL & "NumCaja=" & lblCaja.Text.Replace(";", "") & ", "
                                ' ''    SentenciaSQL = SentenciaSQL & "NumLote=" & lblLote.Text & ", FechaLoteado='" & Now.ToString & "' "
                                ' ''    SentenciaSQL = SentenciaSQL & "WHERE NumLote = " & lblLote.Text & " AND NHC = " & historiaActiva

                                ' ''    If AccesoDatos.ejecutaSQLEjecucion(SentenciaSQL, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto, , True) = False Then
                                ' ''        LanzarError("ERROR AL ACTUALIZAR")
                                ' ''        Call EscribirLog(lblUserPistoleado.Text, "Usuario " & lblUserPistoleado.Text.Trim & " . Se produce error al actualizar " & historiaActiva & " en lote " & lblLote.Text, "PREPARACION")
                                ' ''    Else
                                ' ''        QuitarError()
                                ' ''        Call EscribirLog(lblUserPistoleado.Text, "Usuario " & lblUserPistoleado.Text.Trim & " . Historia " & historiaActiva & " actualizada correctamente en lote " & lblLote.Text, "PREPARACION")
                                ' ''    End If
                                ' ''    'Actualiza fechaInicioPreparación y fechaFinPreparación en trazabilidadlotes
                                ' ''    SentenciaSQL = "UPDATE TrazabilidadLotes SET FechaFinPreparado = '" & Now.ToString & "', "
                                ' ''    SentenciaSQL = SentenciaSQL & "UsuarioPreparado = '" & lblUserPistoleado.Text & "' "
                                ' ''    SentenciaSQL = SentenciaSQL & "WHERE IdLote = " & lblLote.Text
                                ' ''    AccesoDatos.ejecutaSQLEjecucion(SentenciaSQL, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto, , True)

                                ' ''    'JANTONIO 'LIMITA CONEXION MYSQL
                                ' ''    If My.Settings.cadenaConexionMySQL.ToString.Trim <> "" Then
                                ' ''        SentenciaSQL = "UPDATE stock_hcs_act SET activo = '1',"
                                ' ''        SentenciaSQL = SentenciaSQL & "estado = 'SALA DIGI',"
                                ' ''        SentenciaSQL = SentenciaSQL & "caja='" & lblCaja.Text.Replace(";", "") & "',"
                                ' ''        SentenciaSQL = SentenciaSQL & "coleccion='" & lblColeccion.Text.Trim & "',"
                                ' ''        SentenciaSQL = SentenciaSQL & "WHERE NHC = " & historiaActiva & " AND activo>0"

                                ' ''        If AccesoDatosMySQL.ejecutaMySQLEjecucion(SentenciaSQL, My.Settings.cadenaConexionMySQL, , True) = False Then
                                ' ''            LanzarError("ERROR AL ACTUALIZAR")
                                ' ''            Call EscribirLog(lblUserPistoleado.Text, "Usuario " & lblUserPistoleado.Text.Trim & " . Se produce error al actualizar " & historiaActiva & " en lote " & lblLote.Text, "PREPARACION")
                                ' ''        Else
                                ' ''            QuitarError()
                                ' ''            Call EscribirLog(lblUserPistoleado.Text, "Usuario " & lblUserPistoleado.Text.Trim & " . Historia " & historiaActiva & " actualizada correctamente en lote " & lblLote.Text & " en la tabla stock_hcs_act", "PREPARACION")
                                ' ''        End If

                                ' ''    End If
                                ' ''End If
                            End If
                        End If
                    Else
                        LanzarError("ERROR LECTURA. LOTE VACIO")
                        Call EscribirLog(lblUserPistoleado.Text, "Usuario " & lblUserPistoleado.Text.Trim & " intenta añadir historia " & historiaActiva.Trim & " en lote vacio", "PREPARACION")
                        Exit Sub
                    End If
                End If

                '### JGARIJO 30/08/2019 -> FIN COMPROBACION DE HISTORIAS

                '### JGARIJO 02/09/2019 -> FIN DE COMPROBACION DE LAS EXCEPCIONES EN LAS HISTORIAS

                Me.Refresh()

                cargaDatos()
                trvGeneral.ExpandAll()
                posicionarNodo(elementoActivo.ToString.Trim)
                seleccionarNodo(elementoActivo.ToString.Trim)
                trvGeneral.Focus()
                txtCodigo.Focus()
            End If

            'End If

        Catch ex As Exception
            LanzarError("ERROR DE EJECUCION DE PROGRAMA")
            Call EscribirLog(lblUserPistoleado.Text, "ERROR DE EJECUCION DE PROGRAMA EN MODULO txtCodigo_KeyDown", "PREPARACION")
        Finally

        End Try
      
    End Sub

    Private Function añadeALista(ByVal tipo As String, ByVal codigo As String) As Boolean

        Dim result As Boolean = False
        Dim oNodex As TreeNode
        Dim clave As String = ""


        Select Case tipo
            Case "Caja"
                oNodex = seleccionarNodo(0)
                oNodex.Nodes.Add(oNodex.FullPath & "\" & codigo, codigo)
                oNodex.EnsureVisible()
                oNodex.Nodes.Item(oNodex.FullPath & "\" & codigo).ForeColor = colorCaja
                cajaActiva = codigo
                result = True


            Case "Col"
                clave = frmContenedorMDI.oProyecto._CodigoProyecto & " - " & frmContenedorMDI.oProyecto._nombreProyecto
                If lblCaja.Text.ToString.Trim <> "" Then clave = clave & "\" & lblCaja.Text.ToString.Trim
                oNodex = seleccionarNodo(clave)
                oNodex.Nodes.Add(oNodex.FullPath & "\" & codigo, codigo)
                oNodex.EnsureVisible()
                oNodex.Nodes.Item(oNodex.FullPath & "\" & codigo).ForeColor = colorColeccion
                coleccionActiva = codigo
                result = True


            Case "Lote"
                clave = frmContenedorMDI.oProyecto._CodigoProyecto & " - " & frmContenedorMDI.oProyecto._nombreProyecto
                If lblCaja.Text.ToString.Trim <> "" Then clave = clave & "\" & lblCaja.Text.ToString.Trim
                If lblColeccion.Text.ToString.Trim <> "" Then clave = clave & "\" & lblColeccion.Text.ToString.Trim
                oNodex = seleccionarNodo(clave)
                oNodex.Nodes.Add(oNodex.FullPath & "\" & codigo, codigo & " - " & lblTipoLote.Text.ToString.Trim)
                oNodex.EnsureVisible()
                oNodex.Nodes.Item(oNodex.FullPath & "\" & codigo).ForeColor = colorlote
                loteActivo = codigo
                result = True


            Case "NHC"
                'JANTONIO 'eLIMINO PREFIJO NHC
                ' ''codigo = codigo.ToString.Trim.Replace(My.Settings.PREP_elimina_prefijo_NHC, "").ToString.TrimStart("0")
                If codigo.ToString.Trim.Substring(0, 3) = My.Settings.PREP_elimina_prefijo_NHC Then
                    codigo = codigo.ToString.Trim.Substring(3)
                Else
                    codigo = codigo.ToString.Trim
                End If
                '*****************************
                clave = frmContenedorMDI.oProyecto._CodigoProyecto & " - " & frmContenedorMDI.oProyecto._nombreProyecto
                If lblCaja.Text.ToString.Trim <> "" Then clave = clave & "\" & lblCaja.Text.ToString.Trim
                If lblColeccion.Text.ToString.Trim <> "" Then clave = clave & "\" & lblColeccion.Text.ToString.Trim
                If lblLote.Text.ToString.Trim <> "" Then clave = clave & "\" & lblLote.Text.ToString.Trim 'lblLote.Text.Substring(0, lblLote.Text.IndexOf("-") - 1) 
                oNodex = seleccionarNodo(clave)
                oNodex.Nodes.Add(oNodex.FullPath & "\" & codigo, codigo)
                oNodex.EnsureVisible()
                oNodex.Nodes.Item(oNodex.FullPath & "\" & codigo).ForeColor = colorHistoria
                historiaActiva = codigo
                result = True

        End Select

        añadeALista = result

    End Function

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        If txtCodigo.Text = "Posicione el cursor" Then
            txtCodigo.Text = ""
        Else
            txtCodigo.Text = "Posicione el cursor"
        End If

    End Sub

    Private Function seleccionarNodo(ByVal sKey As String) As TreeNode
        Dim result As TreeNode = Nothing

        Dim tvn() As TreeNode = trvGeneral.Nodes.Find(sKey, True)
       

        If tvn IsNot Nothing AndAlso tvn.Length > 0 Then
            trvGeneral.SelectedNode = tvn(0)
            trvGeneral.ExpandAll()
            result = tvn(0)
        End If
        seleccionarNodo = result
    End Function

    Private Function existeClaveNodo(ByVal sKey As String, ByVal sElemento As String) As Boolean
        Dim result As Boolean = False
        Dim array As String()
        Dim indice As Integer = 0

        Try

            'Vuelve a construir la clave pero con el nuevo valor del elemento introducido sustituyendo al anterior.
            array = sKey.Split("\")

            'Necesito saber que tipo es para comprobar la clave
            If txtCodigo.Text.ToString.Trim.Contains(My.Settings.PREP_caracter_Caja.ToString.Trim) Then
                'Caja
                indice = 0
            End If
            If My.Settings.PREP_caracter_Coleccion.ToString.Trim <> "" And txtCodigo.Text.Contains(My.Settings.PREP_caracter_Coleccion.ToString.Trim) Then
                'Coleccion
                indice = 1
            End If
            If txtCodigo.Text.Contains(My.Settings.PREP_caracter_Lote.ToString.Trim) Then
                'Lote
                indice = 2

            End If
            If txtCodigo.Text <> "" And txtCodigo.Text.Contains(My.Settings.PREP_caracter_Caja.ToString.Trim) = False And txtCodigo.Text.Contains(My.Settings.PREP_caracter_Coleccion.ToString.Trim) = False And txtCodigo.Text.Contains(My.Settings.PREP_caracter_Lote.ToString.Trim) = False Then
                'NHC
                indice = 3
            End If
            '**************************************************

            sKey = "" 'Hago esto para contruir de nuevo la clave

            If array.Count > 1 Then
                For i As Integer = 0 To indice - 1
                    sKey = sKey & array(i) & "\"
                Next i

                sKey = sKey & sElemento
            Else
                sKey = array(0) & "\" & sElemento
            End If
            '***********************************************************************************************************

            Dim tvn() As TreeNode

            If indice = 0 Or indice = 1 Then
                'La colección y la historia si pueden repetirse, por tanto tengo en cuenta toda la clave o ruta de la jerarquía
                tvn = trvGeneral.Nodes.Find(sKey, True)
            Else
                'La caja y el lote si pueden repetirse, por tanto tengo en cuenta toda la clave o ruta de la jerarquía
                tvn = trvGeneral.Nodes.Find(sElemento, True)
            End If

            If tvn IsNot Nothing AndAlso tvn.Length > 0 Then
                result = True
            End If

            existeClaveNodo = result

        Catch ex As Exception
            LanzarError("ERROR DE EJECUCION DE PROGRAMA")
            Call EscribirLog(lblUserPistoleado.Text, "ERROR DE EJECUCION DE PROGRAMA EN MODULO EXISTECLAVENODO", "PREPARACION")
        Finally

        End Try

    End Function

    Private Sub posicionarNodo(ByVal sKey As String)
        Dim result As TreeNode = Nothing

        Dim tvn() As TreeNode = trvGeneral.Nodes.Find(sKey, True)
        If tvn IsNot Nothing AndAlso tvn.Length > 0 Then
            trvGeneral.SelectedNode = tvn(0)
            trvGeneral.ExpandAll()
            trvGeneral.Focus()
            Encontrado = True
        End If
    End Sub


    Private Sub txtCodigo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigo.GotFocus

        If salir Then Me.Close() 'Si no esta configurada en las propiedades se sale.

        Timer1.Enabled = False
        txtCodigo.Text = ""
    End Sub

    Private Sub cargaDatos()
        lblCaja.Text = cajaActiva
        lblColeccion.Text = coleccionActiva
        If loteActivo = "" Then
            lblLote.Text = ""
        Else
            If loteActivo.Contains(" - ") Then
                lblLote.Text = loteActivo.Substring(0, loteActivo.IndexOf("-") - 1)  'loteActivo
            Else
                lblLote.Text = loteActivo
            End If
        End If
        lblHistoria.Text = historiaActiva
    End Sub

    Private Sub trvGeneral_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles trvGeneral.AfterSelect

        Dim array As String()

        Try

            cajaActiva = ""
            coleccionActiva = ""
            loteActivo = ""
            historiaActiva = ""

            array = trvGeneral.SelectedNode.FullPath.Split("\")

            For i As Int16 = 1 To array.Length - 1

                Select Case i
                    Case 1
                        cajaActiva = array(i).ToString.Trim
                    Case 2
                        coleccionActiva = array(i).ToString.Trim
                    Case 3
                        loteActivo = array(i).ToString.Trim
                    Case 4
                        historiaActiva = array(i).ToString.Trim
                End Select
            Next

            cargaDatos()

            txtCodigo.Focus()

        Catch ex As Exception
            LanzarError("ERROR DE EJECUCION DE PROGRAMA")
            Call EscribirLog(lblUserPistoleado.Text, "ERROR DE EJECUCION DE PROGRAMA EN MODULO trvGeneral_AfterSelect", "PREPARACION")
        Finally

        End Try

    End Sub

    Private Sub trvGeneral_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles trvGeneral.KeyDown
        If e.KeyData = Keys.Delete Then
            '### JGARIJO 03/09/2019. Al habilitar el borrado mediante escaneo, deshabilitamos el borrado por pulsacion de tecla suprimir desde el teclado
            LanzarError("BORRADO SOLO POR ESCANEO")
            Call EscribirLog(lblUserPistoleado.Text, " Usuario " & lblUserPistoleado.Text & " intenta borrar registro utilizando tecla suprimir", "PREPARACION")
        End If
    End Sub


    '### JGARIJO. Accion encargada de escribir en el log cualquier accion realizada por el usuario

    Public Sub EscribirLog(ByVal persona As String, ByVal texto As String, ByVal tipo As String)
        'JANTONIO 'LIMITA CONEXION MYSQL
        If My.Settings.cadenaConexionMySQL.ToString.Trim <> "" Then
            Dim momento_actual As String = CStr(Year(Now)) & "-" & CStr(Month(Now)) & "-" & CStr(Microsoft.VisualBasic.DateAndTime.Day(Now)) & " " & CStr(Hour(Now)) & ":" & CStr(Minute(Now)) & ":" & CStr(Second(Now))
            Dim Sentencia As String = "INSERT INTO logs (usuario,descripcion,fecha_hora,tipo_mensaje) VALUES ('" & persona & "','" & texto & "','" & momento_actual & "','" & tipo & "')"
            Dim cadena As String = My.Settings.cadenaConexionMySQL.Trim

            If AccesoDatosMySQL.ejecutaMySQLEjecucion(Sentencia, My.Settings.cadenaConexionMySQL, , True) = False Then
                LanzarError("ERROR AL AÑADIR REGISTRO LOG")
            End If
        End If
    End Sub
    'Accion encargada de mostrar un error en pantalla. 
    Private Sub LanzarError(ByVal txtError As String)
        lblError.Text = txtError
        PB_KO.Visible = True
        PB_OK.Visible = False
        Me.txtCodigo.SelectAll()
        My.Computer.Audio.Play(My.Settings.PREP_rutaZumbido.Trim, AudioPlayMode.WaitToComplete)
        Me.Refresh()
    End Sub

    'Accion encargada de quitar los mensajes de error en la pantalla
    Private Sub QuitarError()
        lblError.Text = ""
        PB_KO.Visible = False
        PB_OK.Visible = True
        My.Computer.Audio.Play(My.Settings.PREP_rutaSonidoOK.Trim, AudioPlayMode.WaitToComplete)
        Me.Refresh()
    End Sub

    'accion recursiva encargada de ir nodo a nodo recogiendo el .text de cada rama.
    'Para recoger el valor utilizamos variable global que no pierde contenido al rellamar recursivamente a la accion
    'Una vez obtenido el valor deseado, se reinicializa PathRecursivo
    Private Sub RecorrerTodosLosNodos(ByVal treeNode As TreeNode)
        For Each rama As TreeNode In treeNode.Nodes
            PathRecursivo = PathRecursivo & "/" & rama.Text
            RecorrerTodosLosNodos(rama)
        Next
    End Sub

    Private Sub chkBloquear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkBloquear.Click
        txtCodigo.Focus()
    End Sub

    Private Sub cargaServicios()
        Dim servicio As LibreriaCadenaProduccion.Entidades.ClsServicio

        cboServicio.Items.Clear()
        Me.cboServicio.Items.Add("")
        'cargamos el comgo de servicio 
        For Each registro As DataRow In AccesoDatos.ejecutarSQLDirectaTable("SELECT idServicio, Descripcion FROM SERVICIOS where visible = 1 order by descripcion", frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto).Rows

            servicio = New modelo.ClsServicio(registro.Item("idservicio"), registro.Item("descripcion"))
            Me.cboServicio.Items.Add(servicio)

        Next

    End Sub

    Private Sub cargaDocumentos()
        Dim tipodocumento As LibreriaCadenaProduccion.Entidades.ClsTipoDocumento

        'cargamos el comgo de servicio 
        Me.cboTipoDocumento.Items.Clear()
        Me.cboTipoDocumento.Items.Add("")
        For Each registro As DataRow In AccesoDatos.ejecutarSQLDirectaTable("SELECT  idtipoDocumento, Descripcion FROM TIPOSDOCUMENTOS order by idtipodocumento", frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto).Rows

            tipodocumento = New modelo.ClsTipoDocumento(registro.Item("idtipodocumento"), registro.Item("descripcion"))
            Me.cboTipoDocumento.Items.Add(tipodocumento)
        Next

    End Sub

    Private Function compruebaSiMismoElemento(ByVal idLote As Integer, ByVal tipoElemento As String, ByVal elemento As String, ByRef elementoAnterior As String, ByRef sentencia As String) As Boolean
        Dim resultado As Boolean
        Dim valor As String = ""
        Dim tipoValor As String = ""

        Try
            If tipoElemento = "Servicio" Then
                valor = accesoDatosNew.ObtenerValor(frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto, "SELECT idServicio FROM LOTES WHERE idLote=" & idLote).ToString.Trim
                tipoValor = " idServicio"
            ElseIf tipoElemento = "Documento" Then
                valor = accesoDatosNew.ObtenerValor(frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto, "SELECT idTipoDocumento FROM LOTES WHERE idLote=" & idLote).ToString.Trim
                tipoValor = "idTipoDocumento"
            Else
                sentencia = ""
                resultado = False
                elementoAnterior = ""
                Exit Function
            End If

            If Not IsNumeric(elemento.Split(" - ")(0)) Then
                MessageBox.Show("El valor introducido en el " & tipoElemento & " no es correcto, no se acutalizará.", "Valor incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                sentencia = ""
                resultado = False
                elementoAnterior = ""
                Exit Function
            End If

            If valor = "" Or IsNothing(valor) Then
                'Si no tiene valor en este campo, los vamos a actualizar
                sentencia = tipoValor & " = " & elemento.Split(" - ")(0)
                elementoAnterior = ""
            Else
                If elemento.Split(" - ")(0) = valor Then
                    'Mismo servicio
                    sentencia = ""
                    resultado = True
                    elementoAnterior = valor
                Else
                    'Distinto servicio
                    sentencia = tipoValor & " = " & elemento.Split(" - ")(0)
                    resultado = False
                    elementoAnterior = valor
                End If
            End If

        Catch ex As Exception
            sentencia = ""
            resultado = False
            elementoAnterior = ""

        End Try

        Return resultado

    End Function
End Class