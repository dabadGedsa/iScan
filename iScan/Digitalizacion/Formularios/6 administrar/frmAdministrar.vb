Imports AccesoDatos = LibreriaCadenaProduccion.Datos.GeneralSQL.clsAccesoDatosSQL
Imports AccesoDatosSQL = LibreriaCadenaProduccion.Datos.AdministrativosSQL
Imports accesoDAtosLotes = LibreriaCadenaProduccion.Datos.Produccion.cadenaproduccion.clsAccesoDatosLote
Imports accesoDatospro = LibreriaCadenaProduccion.Datos.Produccion.clsAccesoDatosProduccion
Imports System.IO
Imports GenCode128
Imports operacionesLote = LibreriaCadenaProduccion.Entidades.Operaciones.clsOperacionesLote
Imports editor = LibreriaCadenaProduccion.TXT.clsFormato
Imports LibreriaCadenaProduccion.Module1



Public Class frmAdministrar

    Private Sub frmAdministrar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.TabControl1.SelectedTab = Me.tabControlProcesos

    End Sub


    Private Sub TabControl1_TabIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged

        Dim Pestañas As TabControl

        Pestañas = sender

        Select Case Pestañas.SelectedTab.Name

            Case Me.tabConfiguracionProyectos.Name.ToString

                Me.cmbProyecto.Items.Clear()
                Me.cmbProyecto.Text = ""
                inicializarDatos()

                Dim proyecto As LibreriaCadenaProduccion.Entidades.clsProyecto

                Try
                    For Each registro As DataRow In AccesoDatos.ObtenerListadoParaValorParametro("Proyectos p,configuracionproyecto cp", " p.idProyecto, p.Nombre,cp.rutaimagenes, ISNULL(ServidorBaseDatos,'NAN') AS ServidorBaseDatos, ISNULL(UsuarioBaseDatos,'NAN') AS UsuarioBaseDatos,  ISNULL(ClaveBaseDatos,'NAN') AS ClaveBaseDatos, ISNULL( NombreBaseDatos,'NAN') AS NombreBaseDatos", "Activo", 1, My.Settings.cadenaConexion, "p.idProyecto", "cp.idProyecto", "p.idProyecto").Rows
                        proyecto = New LibreriaCadenaProduccion.Entidades.clsProyecto(registro.Item("idproyecto").ToString(), registro.Item("nombre").ToString(), registro.Item("rutaimagenes").ToString, libCifrado.clsCifrado.desencriptarCadenaConFormato(registro.Item("ServidorBaseDAtos").ToString, "vecGedsa", "claGedsa"), libCifrado.clsCifrado.desencriptarCadenaConFormato(registro.Item("UsuarioBaseDatos").ToString, "vecGedsa", "claGedsa"), libCifrado.clsCifrado.desencriptarCadenaConFormato(registro.Item("ClaveBaseDatos").ToString, "vecGedsa", "claGedsa"), libCifrado.clsCifrado.desencriptarCadenaConFormato(registro.Item("NombreBaseDatos").ToString, "vecGedsa", "claGedsa"))

                        If proyecto._CodigoProyecto = My.Settings.proyecto Then
                            Me.cmbProyecto.Items.Add(proyecto)
                            Me.cmbProyecto.SelectedItem = proyecto
                        End If
                    Next

                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString)
                End Try

                'Case Me.tabCrearCaratulas.Name.ToString

                '    Me.cmbProyectosCrearCaratulas.Items.Clear()
                '    Me.cmbProyectosCrearCaratulas.Text = ""

                '    Dim proyecto As LibreriaCadenaProduccion.Entidades.clsProyecto

                '    Try
                '        For Each registro As DataRow In AccesoDatos.ObtenerListadoParaValorParametro("Proyectos p,configuracionproyecto cp", " p.idProyecto, p.Nombre,cp.rutaimagenes, ISNULL(ServidorBaseDatos,'NAN') AS ServidorBaseDatos, ISNULL(UsuarioBaseDatos,'NAN') AS UsuarioBaseDatos,  ISNULL(ClaveBaseDatos,'NAN') AS ClaveBaseDatos, ISNULL( NombreBaseDatos,'NAN') AS NombreBaseDatos", "Activo", 1, My.Settings.cadenaConexion, "p.idProyecto", "cp.idProyecto", "p.idProyecto").Rows
                '            proyecto = New LibreriaCadenaProduccion.Entidades.clsProyecto(registro.Item("idproyecto").ToString(), registro.Item("nombre").ToString(), registro.Item("rutaimagenes").ToString, registro.Item("ServidorBaseDAtos").ToString, registro.Item("UsuarioBaseDatos").ToString, registro.Item("ClaveBaseDatos").ToString, registro.Item("NombreBaseDatos").ToString)
                '            Me.cmbProyectosCrearCaratulas.Items.Add(proyecto)
                '        Next

                '    Catch ex As Exception
                '        MessageBox.Show(ex.Message.ToString)

                '    End Try

            Case Me.tabControlProcesos.Name.ToString

                Me.CmbProyectosControlProcesos.Items.Clear()
                Me.CmbProyectosControlProcesos.Text = ""

                Dim proyecto As LibreriaCadenaProduccion.Entidades.clsProyecto

                Try
                    For Each registro As DataRow In AccesoDatos.ObtenerListadoParaValorParametro("Proyectos p,configuracionproyecto cp", " p.idProyecto, p.Nombre,cp.rutaimagenes, ISNULL(ServidorBaseDatos,'NAN') AS ServidorBaseDatos, ISNULL(UsuarioBaseDatos,'NAN') AS UsuarioBaseDatos,  ISNULL(ClaveBaseDatos,'NAN') AS ClaveBaseDatos, ISNULL( NombreBaseDatos,'NAN') AS NombreBaseDatos", "Activo", 1, My.Settings.cadenaConexion, "p.idProyecto", "cp.idProyecto", "p.idProyecto").Rows
                        proyecto = New LibreriaCadenaProduccion.Entidades.clsProyecto(registro.Item("idproyecto").ToString(), registro.Item("nombre").ToString(), registro.Item("rutaimagenes").ToString, libCifrado.clsCifrado.desencriptarCadenaConFormato(registro.Item("ServidorBaseDAtos").ToString, "vecGedsa", "claGedsa"), libCifrado.clsCifrado.desencriptarCadenaConFormato(registro.Item("UsuarioBaseDatos").ToString, "vecGedsa", "claGedsa"), libCifrado.clsCifrado.desencriptarCadenaConFormato(registro.Item("ClaveBaseDatos").ToString, "vecGedsa", "claGedsa"), libCifrado.clsCifrado.desencriptarCadenaConFormato(registro.Item("NombreBaseDatos").ToString, "vecGedsa", "claGedsa"))

                        If proyecto._CodigoProyecto = My.Settings.proyecto Then

                            Me.CmbProyectosControlProcesos.Items.Add(proyecto)
                            Me.CmbProyectosControlProcesos.SelectedItem = proyecto
                        End If
                    Next

                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString)

                End Try

        End Select

    End Sub

#Region "Configuracion Proyectos"


    Private Sub cmbProyecto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbProyecto.SelectedIndexChanged

        Dim estructura As LibreriaCadenaProduccion.Entidades.clsEstructuraBarcode

        inicializarDatos()

        Try
            'inicializar los varlores de lote inicial a crear y ultimo lote a crear 

            Me.txtLoteInicial.Text = ""
            Me.txtLotefinal.Text = ""

            'comprobar que el proyecto tiene definida la cadena de conexion a la base de datos del proyecto 
            If cmbProyecto.SelectedItem._obtenerCadenaConexionProyecto = "NAN" Then
                MessageBox.Show("No hay una base de datos definida para este proyecto")
                Exit Sub
            End If

            'calcular el ultimo lote del proyeto +1 , el primer lote a partir del q se van a crear los futuros 
            'lotes del proyecto

            If IsDBNull(AccesoDatos.ejecutarSQLDirectaDataRow("Select max(idLote) as ultimoid From lotes Where idProyecto = " & cmbProyecto.SelectedItem._CodigoProyecto(), cmbProyecto.SelectedItem._obtenerCadenaConexionProyecto).Item("ultimoid")) Then

                Me.txtLoteInicial.Text = 1
                Me.txtLotefinal.Text = Me.txtLoteInicial.Text + 1
            Else
                Me.txtLoteInicial.Text = AccesoDatos.ejecutarSQLDirectaDataRow("Select max(idLote) as ultimoid From lotes Where idProyecto = " & cmbProyecto.SelectedItem._CodigoProyecto(), cmbProyecto.SelectedItem._obtenerCadenaConexionProyecto).Item("ultimoid") + 1
                Me.txtLotefinal.Text = Me.txtLoteInicial.Text + 1
            End If

            Me.GroupBox1.Enabled = True

            'inicializamos la configuracion de los codigos de barras 

            'obtenemos los campos de la tabla documentos para el proyecto dado 
            For Each registro As DataRow In AccesoDatosSQL.clsAccesoDatosMetaDatosSQL.ObtenerColumnasTablaBD("Documentos", Me.cmbProyecto.SelectedItem._obtenerCadenaConexionProyecto).Rows

                'rellenamos el listviews con los campos ,con la primera columna que es 
                'la que contiene el nombre de las columnas de la tabla documentos 
                Me.lstvCamposTablaDocumentos.Items.Add(registro.Item(0))
            Next




            For Each registro As DataRow In AccesoDatos.ejecutarSQLDirectaTable("SELECT inicioBarcode,idestructura FROM configuracionbarcode WHERE idproyecto =" & Me.cmbProyecto.SelectedItem._codigoproyecto & " AND inicioBarcode is not null", My.Settings.cadenaConexion).Rows

                'cargamos las cabeceras de los codigos de barras en el desplegable 
                estructura = New LibreriaCadenaProduccion.Entidades.clsEstructuraBarcode
                estructura._idEstructura = registro.Item("idestructura")
                estructura._inicioBarcode = registro.Item("inicioBarcode")
                estructura._idproyecto = Me.cmbProyecto.SelectedItem._codigoproyecto
                Me.cmbCabeceraBarcode.Items.Add(estructura)

            Next

            Me.GroupBox2.Enabled = True

        Catch ex As Exception
            MessageBox.Show("Error al seleccionar el proyecto del desplegable. mensaje " & ex.Message)
        End Try
    End Sub


    Private Sub cmdCrearlotes_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCrearLotes.eClick

        'comprobar que hay un proyecto seleccionado 
        If IsNothing(Me.cmbProyecto.SelectedItem) Then
            MessageBox.Show("No ha seleccionado un proyecto, seleccione un proyecto de la lista.")
        End If
        'comprobar que el indice del lote final no es inferior al del lote inicial 
        If Me.txtLoteInicial.Text > Me.txtLotefinal.Text Then
            MessageBox.Show("El identificador del lote final no puede ser inferior al identificador del lote inicial.")
        End If

        'crear los registros correspondientes 
        For i As Integer = CInt(Me.txtLoteInicial.Text) To CInt(Me.txtLotefinal.Text) Step 1
            AccesoDatos.ejecutarSQLDirecta("INSERT INTO LOTES (idproyecto,idlote,FechaLote,Activo,Asignado,TotalImg,imgActual) VALUES ('" & cmbProyecto.SelectedItem._CodigoProyecto & "'," & i & ",getdate(),1,0,0,0)", cmbProyecto.SelectedItem._obtenerCadenaConexionProyecto)
            AccesoDatos.ejecutarSQLDirecta("INSERT INTO TRAZABILIDADLOTES (idlote) VALUES (" & i & ")", cmbProyecto.SelectedItem._obtenerCadenaConexionProyecto)
        Next

        Me.txtLoteInicial.Text = Me.txtLotefinal.Text + 1
        Me.txtLotefinal.Text = Me.txtLoteInicial.Text + 1


    End Sub


    Private Sub lstvCamposTablaDocumentos_ItemCheck(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstvCamposTablaDocumentos.SelectedIndexChanged

        Dim cont As Integer = 0

        'comprobar que hay una estructura, cabecera codigo barras seleccioanada 
        If IsNothing(Me.cmbCabeceraBarcode.SelectedItem) Then
            MessageBox.Show("No ha seleccionado un cabecera de codigo de barras a la que asociar los campos, seleccione una y vuelva a intentarlo")
            Exit Sub
        End If

        Try


            If Not IsNothing(Me.lstvCamposTablaDocumentos.SelectedItems) And Me.lstvCamposTablaDocumentos.SelectedItems.Count > 0 Then

                'comprobar que el campo no se ha introducido con anteriridad 

                If Me.dgCamposCodigoBarras.Rows.Count > 0 Then
                    For Each nommbre As DataGridViewRow In Me.dgCamposCodigoBarras.Rows
                        If nommbre.Cells(0).Value = lstvCamposTablaDocumentos.SelectedItems(0).Text Then
                            MessageBox.Show("Este campo ya esta dentro de la lista de campos que forman el Código de barras")
                            Exit Sub
                        End If
                    Next
                End If

                cont = Me.dgCamposCodigoBarras.Rows.Count + 1
                Me.dgCamposCodigoBarras.Rows.Add(lstvCamposTablaDocumentos.SelectedItems(0).Text, Nothing, cont)

            End If



        Catch ex As Exception
            MessageBox.Show("Error al seleccionar el campo de la tabla documentos para incorporar en el codigo de barras ")
        End Try

    End Sub


    Private Sub cmbCabeceraBarcode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCabeceraBarcode.SelectedIndexChanged

        Me.dgCamposCodigoBarras.Rows.Clear()
        Me.dgCamposCodigoBarras.Refresh()

        If Not IsNothing(Me.cmbCabeceraBarcode.SelectedItem) Then

            'selecionamos los campos para le estructura dada y los cargamos en el datagrid 

            For Each registro As DataRow In AccesoDatos.ejecutarSQLDirecta("SELECT nombre,longitud,orden,idestructura FROM campobarcode WHERE idEstructura =" & Me.cmbCabeceraBarcode.SelectedItem._idestructura, My.Settings.cadenaConexion).Tables(0).Rows

                Me.dgCamposCodigoBarras.Rows.Add(registro.Item("nombre").ToString, registro.Item("longitud").ToString, registro.Item("orden").ToString)
            Next


        End If


    End Sub


    Private Sub cmbNuevaCabecera_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNuevaCabecera.eClick

        Dim estructura As LibreriaCadenaProduccion.Entidades.clsEstructuraBarcode

        'comprobar que hay un proyecto seleccionado 
        If IsNothing(Me.cmbProyecto.SelectedItem) Then
            MessageBox.Show("No ha seleccionado un proyecto, seleccione un proyecto de la lista.")
            Exit Sub
        End If

        'mostrar formulario para crear nueva cabecera 
        Dim _frmNuevaCabeceraBarcode As New frmNuevaCabeceraBarcode
        _frmNuevaCabeceraBarcode.proyecto = Me.cmbProyecto.SelectedItem
        _frmNuevaCabeceraBarcode.ShowDialog()


        Me.cmbCabeceraBarcode.Items.Clear()
        Me.cmbCabeceraBarcode.Refresh()

        For Each registro As DataRow In AccesoDatos.ejecutarSQLDirectaTable("SELECT inicioBarcode,idestructura FROM configuracionbarcode WHERE idproyecto =" & Me.cmbProyecto.SelectedItem._codigoproyecto & " AND inicioBarcode is not null", My.Settings.cadenaConexion).Rows

            'cargamos las cabeceras de los codigos de barras en el desplegable 
            estructura = New LibreriaCadenaProduccion.Entidades.clsEstructuraBarcode
            estructura._idEstructura = registro.Item("idestructura")
            estructura._inicioBarcode = registro.Item("inicioBarcode")
            estructura._idproyecto = Me.cmbProyecto.SelectedItem._codigoproyecto
            Me.cmbCabeceraBarcode.Items.Add(estructura)


        Next

    End Sub


    Private Sub cmbGuardarEstructura_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbGuardarEstructura.eClick

        Dim coleccionCamposCodigoBarras As New Collection
        Dim sumalongitudesCampos As Integer = 0
        Dim encontrado As Boolean = False
        Dim campoBarcode As LibreriaCadenaProduccion.Entidades.ClsCampoBarcode

        'comprobar que hay una estructura, cabecera codigo barras seleccioanada 
        If IsNothing(Me.cmbCabeceraBarcode.SelectedItem) Then
            MessageBox.Show("No ha seleccionado un cabecera de codigo de barras a la que asociar los campos, seleccione una y vuelva a intentarlo")
            Exit Sub
        End If

        Try


            'comprobar que los datos seleccionados para el codigo de barras son correctos 
            'tienen longitud, orden y la longitud de todos ellos no es mayor que la longitud del codigo de barras 
            'los campos que han introducido estan en las columnas de las tablas documentos

            For Each registro As DataGridViewRow In Me.dgCamposCodigoBarras.Rows
                'miramos que el nombre no se ha modificado, el campo nombre tiene que estar en la 
                'tabla documentos 

                encontrado = False
                For Each item As ListViewItem In Me.lstvCamposTablaDocumentos.Items
                    If item.Text = registro.Cells(0).Value Then
                        encontrado = True
                        Exit For
                    End If
                Next
                'si no se ha encontrado el campo en la tablad documentos nos vamos a quejar y le vamos 
                'a decir que lo escriba otra vez 
                If encontrado = False Then
                    MessageBox.Show("El campo " & registro.Cells(0).Value & " no corresponde con un campo de la tabla documentos, modifiquelo y reinicie la operación")
                    Exit Sub
                End If


                If IsNothing(registro.Cells(1).Value) Or registro.Cells(1).Value = 0 Then
                    MessageBox.Show("El campo " & registro.Cells(0).Value & " no tienen una longitud definida, introduzca una longitud para este campo ")
                    Exit Sub
                End If

                If IsNothing(registro.Cells(2).Value) Or registro.Cells(2).Value = 0 Then
                    MessageBox.Show("El campo " & registro.Cells(0).Value & " no tienen un orden definido, introduzca el orden para este campo ")
                    Exit Sub
                End If

                Try


                    'añadimos el campobarcode a la lista de los campos que forma el codigo de barras 
                    campoBarcode = New LibreriaCadenaProduccion.Entidades.ClsCampoBarcode(registro.Cells(0).Value, registro.Cells(1).Value, registro.Cells(2).Value)
                    coleccionCamposCodigoBarras.Add(campoBarcode, campoBarcode._orden, Nothing, campoBarcode._orden - 1)
                Catch ex As Exception
                    MessageBox.Show("Error el orden de los campos no es correcto ")
                End Try
            Next

            'Borrar los campos que hay en la tabla campobarcode asociados a esa estructura 

            AccesoDatos.ejecutarSQLDirecta("DELETE FROM campoBarcode WHERE idestructura = " & Me.cmbCabeceraBarcode.SelectedItem._idestructura, My.Settings.cadenaConexion)

            'actualizar la base de datos con los nuevos campos 
            For Each campoBarcodeIns As LibreriaCadenaProduccion.Entidades.ClsCampoBarcode In coleccionCamposCodigoBarras
                AccesoDatos.ejecutarSQLDirecta("INSERT INTO campobarcode (nombre,longitud,orden,idEstructura) VALUES ('" & campoBarcodeIns._nombre & "'," & campoBarcodeIns._longitud & "," & campoBarcodeIns._orden & "," & Me.cmbCabeceraBarcode.SelectedItem._idestructura & ")", My.Settings.cadenaConexion)
            Next
            MessageBox.Show("La estructura del codigo de barras se ha actualizado correctamente")

        Catch ex As Exception
            MessageBox.Show("Error al guardar los datos de la estructura del codigo de barras")
        End Try


    End Sub


    Private Sub cmbBorrarestructura_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBorrarestructura.eClick

        'comprobar que hay una estructura, cabecera codigo barras seleccioanada 
        If IsNothing(Me.cmbCabeceraBarcode.SelectedItem) Then
            MessageBox.Show("No ha seleccionado un cabecera de codigo de barras a la que asociar los campos, seleccione una y vuelva a intentarlo")
            Exit Sub
        End If

        Try
            AccesoDatos.ejecutarSQLDirecta("DELETE FROM campoBarcode WHERE idestructura = " & Me.cmbCabeceraBarcode.SelectedItem._idestructura, My.Settings.cadenaConexion)
        Catch ex As Exception
            MessageBox.Show("Error al itentar eliminar la estructura.")
        End Try

    End Sub


    Private Sub inicializarDatos()
        Me.txtLotefinal.Text = ""
        Me.txtLoteInicial.Text = ""
        Me.lstvCamposTablaDocumentos.Items.Clear()
        Me.lstvCamposTablaDocumentos.Refresh()
        Me.cmbCabeceraBarcode.Items.Clear()
        Me.cmbCabeceraBarcode.Text = ""
        Me.cmbCabeceraBarcode.Refresh()
        Me.dgCamposCodigoBarras.Rows.Clear()
        Me.dgCamposCodigoBarras.Refresh()
    End Sub


#End Region

#Region "Crear Caratulas"


    'Private Sub cmbProyectosCrearCaratulas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    Dim tablaCadenasConsultaCaratulas As DataTable
    '    'comprobar que el proyecto tiene definida la cadena de conexion a la base de datos del proyecto 
    '    If cmbProyectosCrearCaratulas.SelectedItem._obtenerCadenaConexionProyecto = "NAN" Then
    '        MessageBox.Show("No hay una base de datos definida para este proyecto")
    '        Me.cmbProyectosCrearCaratulas.Text = ""
    '        Exit Sub
    '    End If


    '    'habilitar el groupbox para hacer las consultas 
    '    Me.gbConsultaDatosCaratula.Enabled = True

    '    'miramos a ver si hay una cosulta para este proyecto, si la hay la mosmtramos  
    '    tablaCadenasConsultaCaratulas = AccesoDatos.ejecutarSQLDirectaTable("SELECT selectCamposCaratula,FromCamposCaratula,WhereCamposCaratula FROM configuracionProyecto WHERE idproyecto = " & CType(Me.cmbProyectosCrearCaratulas.SelectedItem, LibreriaCadenaProduccion.Entidades.clsProyecto)._CodigoProyecto, My.Settings.cadenaConexion)

    '    If tablaCadenasConsultaCaratulas.Rows.Count > 0 Then

    '        Me.txtSELECTGeneracionCaratula.Text = AccesoDatos.ponerCaracterEnBlanco(tablaCadenasConsultaCaratulas.Rows(0).Item("selectCamposCaratula"))
    '        Me.txtFROMGenerarCaratula.Text = AccesoDatos.ponerCaracterEnBlanco(tablaCadenasConsultaCaratulas.Rows(0).Item("FromCamposCaratula"))
    '        Me.txtWHEREGenerarCaratula.Text = AccesoDatos.ponerCaracterEnBlanco(tablaCadenasConsultaCaratulas.Rows(0).Item("WhereCamposCaratula"))
    '    End If


    'End Sub


    'Private Sub cmdEjecutarConsulta_eclick(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    Dim strSQL As String = ""
    '    'comprobar que hay un proyecto seleccionado 
    '    If IsNothing(Me.cmbProyectosCrearCaratulas.SelectedItem) Then
    '        MessageBox.Show("No ha seleccionado un proyecto, seleccione un proyecto de la lista.")
    '        Exit Sub
    '    End If

    '    strSQL = "SELECT " & Me.txtSELECTGeneracionCaratula.Text & " FROM " & Me.txtFROMGenerarCaratula.Text
    '    If Me.txtWHEREGenerarCaratula.Text <> "" Then
    '        strSQL = strSQL & " WHERE " & Me.txtWHEREGenerarCaratula.Text
    '    End If


    '    Me.dgDatosConsulta.DataSource = AccesoDatos.ejecutarSQLDirectaTable(strSQL, cmbProyectosCrearCaratulas.SelectedItem._obtenerCadenaConexionProyecto)

    '    If Me.dgDatosConsulta.RowCount > 0 Then
    '        inicializarDatosCaratula()
    '    End If
    'End Sub


    'Private Sub inicializarDatosCaratula()
    '    Dim coleccionItemsCaratula As New Collection
    '    Dim comboboxColumn As New DataGridViewComboBoxColumn
    '    Dim campos As String = ""



    '    Me.gbCamposCaratula.Enabled = True
    '    Me.txtTituloCaratula.Text = CType(Me.cmbProyectosCrearCaratulas.SelectedItem, LibreriaCadenaProduccion.Entidades.clsProyecto).ToString


    '    With comboboxColumn
    '        .DataPropertyName = "items"
    '        .HeaderText = "items"
    '        .DropDownWidth = 160
    '        .Width = 90
    '        .MaxDropDownItems = 10
    '        .FlatStyle = FlatStyle.Standard
    '    End With


    '    'limpiamos los elementos de la lista por si le dan a la consulta mas de una vez 

    '    coleccionItemsCaratula.Clear()


    '    'aqui estas creando una lista de los campos que has sacado de la consulta inicial 
    '    For Each columna As DataColumn In CType(Me.dgDatosConsulta.DataSource, DataTable).Columns

    '        coleccionItemsCaratula.Add(columna.ColumnName())
    '    Next




    '    comboboxColumn.DataSource = coleccionItemsCaratula

    '    rellenarCombo(cmbSubtitulo1, coleccionItemsCaratula)
    '    rellenarCombo(cmbSubtitulo2, coleccionItemsCaratula)
    '    rellenarCombo(cmbcampomemoria1, coleccionItemsCaratula)
    '    rellenarCombo(cmbCampoMemoria2, coleccionItemsCaratula)
    '    rellenarCombo(cmbCampoMemoria3, coleccionItemsCaratula)
    '    rellenarCombo(cmbCampoMemoria4, coleccionItemsCaratula)


    '    Try


    '        Me.dgCodigoBarras.DataSource = Nothing
    '        Me.dgCodigoBarras.DataSource = AccesoDatos.ejecutarSQLDirectaTable("SELECT nombre,orden,cb.longitud FROM campobarcode cb,configuracionBarcode cf  WHERE cb.idestructura= cf.idestructura AND idProyecto =" & CType(Me.cmbProyectosCrearCaratulas.SelectedItem, LibreriaCadenaProduccion.Entidades.clsProyecto)._CodigoProyecto & " ORDER BY orden ASC", My.Settings.cadenaConexion)





    '        For Each Columna As DataGridViewColumn In Me.dgCodigoBarras.Columns
    '            Debug.Print(Columna.GetType.ToString)
    '            Debug.Print(Columna.Index)
    '            If Columna.GetType.ToString = "System.Windows.Forms.DataGridViewComboBoxColumn" Then
    '                Me.dgCodigoBarras.Columns.RemoveAt(Columna.Index)
    '                Exit For
    '            End If
    '        Next


    '        Me.dgCodigoBarras.Columns.Add(comboboxColumn)

    '    Catch ex As Exception

    '        MessageBox.Show("La consulta no se ha efectuado correctamente")
    '    End Try


    'End Sub


    'Private Sub rellenarCombo(ByRef combo As ComboBox, ByVal coleccionItems As Collection)
    '    For Each item As Object In coleccionItems
    '        combo.Items.Add(item)
    '    Next
    'End Sub


    'Private Sub cmdGuardarConsulta_click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    '    Dim ListaValores As String = ""
    '    Dim condiciones As String = ""
    '    'comprobar que hay un proyecto seleccionado 
    '    If IsNothing(Me.cmbProyectosCrearCaratulas.SelectedItem) Then
    '        MessageBox.Show("No ha seleccionado un proyecto, seleccione un proyecto de la lista.")
    '        Exit Sub
    '    End If


    '    ListaValores = "SelectCamposCaratula ='" & Me.txtSELECTGeneracionCaratula.Text & "',FromCamposCaratula='" & Me.txtFROMGenerarCaratula.Text & "',WhereCamposCAratula='" & Me.txtWHEREGenerarCaratula.Text & "'"
    '    condiciones = "idproyecto = " & CType(cmbProyectosCrearCaratulas.SelectedItem, LibreriaCadenaProduccion.Entidades.clsProyecto)._CodigoProyecto

    '    If AccesoDatos.actualizarTablaLiteral("configuracionProyecto", ListaValores, condiciones, My.Settings.cadenaConexion) Then
    '        MessageBox.Show("La consulta se ha guardado correctamente.")
    '    End If

    'End Sub

    'Private Sub CtrlGenerarCaratulas_click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    Dim cr As New crpCaratula
    '    Dim informe As New dts_cabecera
    '    Dim tablaInforme As DataTable = informe.Tables(0)
    '    Dim titulo As String
    '    Dim subtitulo1 As String = ""
    '    Dim subtitulo2 As String = ""
    '    Dim codigoBarras As Image = Code128Rendering.MakeBarcodeImage("01033239200700651130", 3, True)
    '    Dim cadenaCodigoBarras As String = ""
    '    Dim memoria As String = ""
    '    Dim campo1memoria As String = "", campo2memoria As String = "", campo3memoria As String = "", campo4memoria As String = ""


    '    Try


    '        Dim cabeceraCodigoBarras As String

    '        cabeceraCodigoBarras = AccesoDatos.ponerCaracterEnBlanco(AccesoDatos.ejecutarSQLDirectaDataRow("SELECT inicioBarcode FROM  configuracionBarcode where idproyecto = " & CType(Me.cmbProyectosCrearCaratulas.SelectedItem, LibreriaCadenaProduccion.Entidades.clsProyecto)._CodigoProyecto, My.Settings.cadenaConexion).Item(0))

    '        'Creamos la caratual para cada uno de los datos de la consulta 
    '        For Each registro As DataRow In CType(dgDatosConsulta.DataSource, DataTable).Rows

    '            titulo = ""

    '            If cmbSubtitulo1.Text <> "" Then
    '                subtitulo1 = Trim(Me.txtSubtitulo1.Text & " " & AccesoDatos.ponerCaracterEnBlanco(registro.Item(cmbSubtitulo1.Text)))
    '            End If

    '            If cmbSubtitulo2.Text <> "" Then
    '                subtitulo2 = Trim(Me.txtSubtitulo2.Text & " " & AccesoDatos.ponerCaracterEnBlanco(registro.Item(cmbSubtitulo2.Text)))
    '            End If

    '            'los campos estan en orden ascendente por lo que no tiene que haber problemas 
    '            'para crear la cadena de los codigos de barras.
    '            If CType(dgCodigoBarras.DataSource, DataTable).Rows.Count > 0 Then

    '                cadenaCodigoBarras = cabeceraCodigoBarras
    '                For Each campoBarcode As DataGridViewRow In dgCodigoBarras.Rows
    '                    cadenaCodigoBarras = cadenaCodigoBarras & AccesoDatos.ponerCaracterEnBlanco(registro.Item(campoBarcode.Cells(3).Value)).ToString.PadLeft(campoBarcode.Cells("longitud").Value, "0")

    '                Next

    '            End If

    '            codigoBarras = Code128Rendering.MakeBarcodeImage(cadenaCodigoBarras, 3, True)

    '            memoria = txtMemoria.Text

    '            If cmbcampomemoria1.Text <> "" Then
    '                campo1memoria = Trim(Me.txtCampoMemoria1.Text & " " & AccesoDatos.ponerCaracterEnBlanco(registro.Item(cmbcampomemoria1.Text)))
    '            End If
    '            If cmbCampoMemoria2.Text <> "" Then
    '                campo2memoria = Trim(Me.txtCampoMemoria2.Text & " " & AccesoDatos.ponerCaracterEnBlanco(registro.Item(cmbCampoMemoria2.Text)))
    '            End If
    '            If cmbCampoMemoria3.Text <> "" Then
    '                campo3memoria = Trim(Me.txtCampoMemoria3.Text & " " & AccesoDatos.ponerCaracterEnBlanco(registro.Item(cmbCampoMemoria3.Text)))
    '            End If
    '            If cmbCampoMemoria4.Text <> "" Then
    '                campo4memoria = Trim(Me.txtCampoMemoria4.Text & " " & AccesoDatos.ponerCaracterEnBlanco(registro.Item(cmbCampoMemoria4.Text)))
    '            End If


    '            tablaInforme.Rows.Add(titulo, subtitulo1, ImageToByte(codigoBarras), cadenaCodigoBarras, subtitulo2, campo1memoria, campo2memoria, campo3memoria, campo4memoria)
    '        Next





    '        cr.SetDataSource(tablaInforme)
    '        CrystalReportViewer1.ReportSource = cr


    '    Catch ex As Exception
    '        MessageBox.Show(ex.ToString)
    '    End Try


    'End Sub

    


    'Esta función convierte la imagen a Byte
    Public Shared Function ImageToByte(ByVal img As Image) As Byte()
        Dim sTemp As String = Path.GetTempFileName()
        Dim fs As New System.IO.FileStream(sTemp, FileMode.OpenOrCreate, FileAccess.ReadWrite)
        img.Save(fs, System.Drawing.Imaging.ImageFormat.Png)
        fs.Position = 0
        '
        Dim imgLength As Integer = CInt(fs.Length)
        Dim bytes(0 To imgLength - 1) As Byte
        fs.Read(bytes, 0, imgLength)
        fs.Close()
        Return bytes



    End Function

    'Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    Dim reporte As New crpCaratula

    '    Me.CrystalReportViewer1.ReportSource = reporte
    '    Me.CrystalReportViewer1.Zoom(1)
    'End Sub


#End Region

  
#Region "Control de procesos"

    Private Sub CmbProyectosControlProcesos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbProyectosControlProcesos.SelectedIndexChanged


        If Not IsNothing(Me.CmbProyectosControlProcesos.SelectedItem) Then


            inicializarDatosControlProcesos()

            'comprobar que el proyecto tiene definida la cadena de conexion a la base de datos del proyecto 
            If Me.CmbProyectosControlProcesos.SelectedItem._obtenerCadenaConexionProyecto = "NAN" Then
                MessageBox.Show("No hay una base de datos definida para este proyecto")
                Me.CmbProyectosControlProcesos.Text = ""
                Exit Sub
            End If

            obtenerlotesParaProceso()

        End If


    End Sub

    Private Sub obtenerlotesParaProceso()

        Me.dgvDigitalizacion.DataSource = accesoDAtosLotes.ObtenerLoteParaDigitalizar(CmbProyectosControlProcesos.SelectedItem._CodigoProyecto, CmbProyectosControlProcesos.SelectedItem._obtenerCadenaConexionProyecto)
        Me.Label26.Text = "Digitalización (" & Me.dgvDigitalizacion.Rows.Count & ")"
        Me.dgvImportacion.DataSource = accesoDAtosLotes.ObtenerLoteParaImportar(CmbProyectosControlProcesos.SelectedItem._CodigoProyecto, CmbProyectosControlProcesos.SelectedItem._obtenerCadenaConexionProyecto)
        Me.Label27.Text = "Importación (" & Me.dgvImportacion.Rows.Count & ")"
        Me.dgvVerificación.DataSource = accesoDAtosLotes.ObtenerLoteParaVerificar(CmbProyectosControlProcesos.SelectedItem._CodigoProyecto, CmbProyectosControlProcesos.SelectedItem._obtenerCadenaConexionProyecto)
        Me.Verificación.Text = "Verificación (" & Me.dgvVerificación.Rows.Count & ")"
        Me.dgvCorreccionDigi.DataSource = accesoDAtosLotes.ObtenerLoteParaCorregirDIGI(CmbProyectosControlProcesos.SelectedItem._CodigoProyecto, CmbProyectosControlProcesos.SelectedItem._obtenerCadenaConexionProyecto)
        Me.Label28.Text = "Corrección Digi(" & Me.dgvCorreccionDigi.Rows.Count & ")"
        Me.dgvTraspaso.DataSource = accesoDAtosLotes.ObtenerLoteParaTraspaso(CmbProyectosControlProcesos.SelectedItem._CodigoProyecto, CmbProyectosControlProcesos.SelectedItem._obtenerCadenaConexionProyecto)
        Me.Label29.Text = " Traspaso (" & Me.dgvTraspaso.Rows.Count & ")"
        Me.dgvIndizacion.DataSource = accesoDAtosLotes.ObtenerLoteParaIndizacion(CmbProyectosControlProcesos.SelectedItem._CodigoProyecto, CmbProyectosControlProcesos.SelectedItem._obtenerCadenaConexionProyecto)
        Me.Label30.Text = "Indizacion ( " & Me.dgvIndizacion.Rows.Count & " )"
        Me.dgvCorreccionPAED.DataSource = accesoDAtosLotes.ObtenerLoteParaCorreccionPAED(CmbProyectosControlProcesos.SelectedItem._CodigoProyecto, CmbProyectosControlProcesos.SelectedItem._obtenerCadenaConexionProyecto)
        Me.Label31.Text = "Correccion ( " & Me.dgvCorreccionPAED.Rows.Count & " )"
        Me.dgvFinalizacion.DataSource = accesoDAtosLotes.ObtenerLoteParaFinalizar(CmbProyectosControlProcesos.SelectedItem._CodigoProyecto, False, CmbProyectosControlProcesos.SelectedItem._obtenerCadenaConexionProyecto)
        Me.Label32.Text = " Finalización (" & Me.dgvFinalizacion.Rows.Count & ")"
        Me.dgvExportados.DataSource = accesoDAtosLotes.obtenerLotesExportados(CmbProyectosControlProcesos.SelectedItem._obtenerCadenaConexionProyecto, CmbProyectosControlProcesos.SelectedItem._CodigoProyecto)
        Me.Label33.Text = " Exportación(" & Me.dgvExportados.Rows.Count & ")"
        Me.dgvEnviados.DataSource = accesoDAtosLotes.obtenerLotesEnviados(CmbProyectosControlProcesos.SelectedItem._obtenerCadenaConexionProyecto, CmbProyectosControlProcesos.SelectedItem._CodigoProyecto)
        Me.Label6.Text = " Enviados(" & Me.dgvEnviados.Rows.Count & ")"

    End Sub

    Private Sub inicializarDatosControlProcesos()
        Try

   
            For Each controlProceso As Control In Me.gbControlProcesos.Controls
                If controlProceso.GetType.ToString = "System.Windows.Forms.DataGridView" Then
                    If CType(controlProceso, System.Windows.Forms.DataGridView).Rows.Count > 0 Then
                        CType(controlProceso, System.Windows.Forms.DataGridView).DataSource = ""
                    End If
                End If

            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
    End Sub

#End Region
   

#Region "Menus asociados a los datgrigs"


#Region "contextmenu digitalizacion"

    Private Sub EnviarAIMPORTACIÓNLosLotesSeleccionadosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnviarAIMPORTACIÓNLosLotesSeleccionadosToolStripMenuItem.Click
        Try


            If Me.dgvDigitalizacion.SelectedRows.Count > 0 Then

                'Hacemos la insercion para cada uno de los lotes seleccionados 
                For Each loteSeleccionado As DataGridViewRow In Me.dgvDigitalizacion.SelectedRows

                    accesoDAtosLotes.CerrarLoteParaDigitalizar(frmContenedorMDI.oUsuario._login, loteSeleccionado.Cells("idlote").Value, Me.CmbProyectosControlProcesos.SelectedItem._obtenerCadenaConexionProyecto())

                Next

                obtenerlotesParaProceso()

                MsgBox("Proceso finalizado con éxito", MsgBoxStyle.Information, "Correcto")
            Else
                MessageBox.Show("No hay lotes seleccionados.")
            End If

        Catch ex As Exception
            MsgBox("Error al pasar los lotes" & ex.Message.ToString)
        Finally

        End Try
    End Sub

#End Region


#Region "contextmenu importación"

    Private Sub EnviarADigitalizarLosLotesSeleccionadosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnviarADigitalizarLosLotesSeleccionadosToolStripMenuItem.Click
        Try


            If Me.dgvImportacion.SelectedRows.Count > 0 Then

                'Hacemos la insercion para cada uno de los lotes seleccionados 
                For Each loteSeleccionado As DataGridViewRow In Me.dgvImportacion.SelectedRows

                    accesoDAtosLotes.EnviarDeImportarDigitalizar(loteSeleccionado.Cells("idlote").Value, Me.CmbProyectosControlProcesos.SelectedItem._obtenerCadenaConexionProyecto())

                Next


                obtenerlotesParaProceso()

                MsgBox("Proceso finalizado con éxito", MsgBoxStyle.Information, "Correcto")
            Else
                MessageBox.Show("No hay lotes seleccionados.")
            End If

        Catch ex As Exception
            MsgBox("Error al pasar los lotes" & ex.Message.ToString)
        Finally

        End Try
    End Sub

    Private Sub ImportarLosLotesSeleccionadosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnviarAVERIFICARLosLotesSeleccionadosToolStripMenuItem.Click
        With Me.pgbProcesoslotes
            .Maximum = Me.dgvTraspaso.Rows.Count
            .Minimum = 0
            .Value = 0
            .Step = 1
        End With


        Try


            If Me.dgvImportacion.SelectedRows.Count > 0 Then


                MessageBox.Show("Esta operación la realizará el Autómata Importador.", "No es posible realizar operación", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Exit Sub


                'Hacemos la insercion para cada uno de los lotes seleccionados 
                For Each loteSeleccionado As DataGridViewRow In Me.dgvImportacion.SelectedRows

                    pgbProcesoslotes.PerformStep()

                    Application.DoEvents()



                    operacionesLote.ImportarLoteBD(loteSeleccionado.Cells("idlote").Value, Me.CmbProyectosControlProcesos.SelectedItem._CodigoProyecto, My.Settings.cadenaConexion, Me.CmbProyectosControlProcesos.SelectedItem._obtenercadenaconexionproyecto, pgbProcesoslotes, rbtMensajes)

                    'aqui vamos a colgar la actualizacion de los datos para las consultas del hospital

                    Me.rbtMensajes.AppendText("Cargando datos del sip")
                    actualizarDatosSip(loteSeleccionado.Cells("idlote").Value)
                    Me.rbtMensajes.AppendText("Fin de la actualizaciónn datos sip")

                Next



                obtenerlotesParaProceso()

            Else
                MessageBox.Show("No hay lotes para trastasar.")
            End If

        Catch ex As Exception
            MsgBox("Error en el proceso de importación de los lotes " & ex.Message.ToString)
        Finally
            Me.pgbProcesoslotes.Value = 0
            Me.pgbProcesoslotes.Refresh()
        End Try
    End Sub


    Private Sub actualizarDatosSip(ByVal idlote As Integer)

        Dim coleccionSips As DataTable
        Dim DatosSip As ClsSIP
        Dim iobtenerdatossip As IdatosSIPOracle
        Dim iactualizardatossip As IdatosSIPSQL
        iobtenerdatossip = New clsDatosSipOracle
        iactualizardatossip = New ClsDAtosSipSQL

        'consulta para sacar los distintos sips del lote
        coleccionSips = AccesoDatos.ejecutarSQLDirectaTable("Select distinct sip from documentos where idlote = " & idlote, Me.CmbProyectosControlProcesos.SelectedItem._obtenercadenaconexionproyecto)

        If coleccionSips.Rows.Count > 0 Then


            For Each sip As DataRow In coleccionSips.Rows

                Try

                    ''AQUI ES DONDE OBTENEMOS LOS DATOS A PARTIR DEL SIP HASTA EL MOMENTO SACABAMOS LOS DATOS 
                    ''DEL ULTIMO EPISODIO PERO LO QUE VAMOS A HACER AHORA ES SACAR LOS DATOS DEL PACIENTE EN LA 
                    ''FASE DE TRASPASO OBTENDREMOS TODOS LOS DATOS DE LOS EPISODIOS 


                    DatosSip = New ClsSIP(sip.Item("sip").ToString) 'En este objeto  nos vamos a guardar todos los datos del paciente
                    Debug.Print(sip.Item("sip").ToString)

                    iobtenerdatossip.obtenerdatosFip(DatosSip, DatosSip._sip, My.Settings.cadenaConexionOracle)

                    If DatosSip._numhistoria <> 0 Then

                        iactualizardatossip.actualizarDatosFIPProduccion(idlote, DatosSip, Me.CmbProyectosControlProcesos.SelectedItem._obtenercadenaconexionproyecto)
                    End If

                Catch ex As Exception
                    Debug.Print("Error al leer los datos del sip ")
                End Try
            Next

        End If

    End Sub

    Private Sub VisualizarDocumentosLoteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VisualizarDocumentosLoteToolStripMenuItem.Click
        Try


            If Me.dgvImportacion.SelectedRows.Count = 1 Then

                'Hacemos la insercion para cada uno de los lotes seleccionados 
                For Each loteSeleccionado As DataGridViewRow In Me.dgvImportacion.SelectedRows

                    visualizarlote(Me.CmbProyectosControlProcesos.SelectedItem._codigoproyecto, loteSeleccionado.Cells("idlote").Value, Me.CmbProyectosControlProcesos.SelectedItem._obtenerCadenaConexionProyecto())
                Next


                MsgBox("Proceso finalizado con éxito", MsgBoxStyle.Information, "Correcto")
            Else
                MessageBox.Show("Seleccione un único lote para visualizar los documentos.")
            End If

        Catch ex As Exception
            MsgBox("Error al pasar los lotes" & ex.Message.ToString)
        Finally

        End Try

    End Sub


#End Region


#Region "contextmenu verificación"

    Private Sub EnviarAIPORTACIÓNLosLotesSeleccionadosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnviarAIPORTACIÓNLosLotesSeleccionadosToolStripMenuItem.Click


        Try


            If Me.dgvVerificación.SelectedRows.Count > 0 Then

                If MessageBox.Show("Al enviar los lotes a importación se perderan todos los datos asocidos a los documentos. " & vbCrLf & " ¿Realmente deseas realizar esta operación? ", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    'Hacemos la insercion para cada uno de los lotes seleccionados 
                    For Each loteSeleccionado As DataGridViewRow In Me.dgvVerificación.SelectedRows

                        pgbProcesoslotes.PerformStep()

                        Application.DoEvents()



                        accesoDAtosLotes.EnviarDeVerificarAImportar(loteSeleccionado.Cells("idlote").Value, Me.CmbProyectosControlProcesos.SelectedItem._obtenerCadenaConexionProyecto())

                    Next

                    obtenerlotesParaProceso()

                    MsgBox("Proceso finalizado con éxito", MsgBoxStyle.Information, "Correcto")
                Else
                    Exit Sub
                End If

            Else
                MessageBox.Show("No hay lotes para trastasar.")
            End If

        Catch ex As Exception
            MsgBox("Error en el proceso de importación de los lotes " & ex.Message.ToString)
        Finally
            Me.pgbProcesoslotes.Value = 0
            Me.pgbProcesoslotes.Refresh()
        End Try

    End Sub

    Private Sub EnviarACORRECCIÓNLosLotesSeleccionadosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnviarACORRECCIÓNLosLotesSeleccionadosToolStripMenuItem.Click

        Try


            If Me.dgvVerificación.SelectedRows.Count > 0 Then

                'Hacemos la insercion para cada uno de los lotes seleccionados 
                For Each loteSeleccionado As DataGridViewRow In Me.dgvVerificación.SelectedRows

                    pgbProcesoslotes.PerformStep()

                    Application.DoEvents()

                    accesoDAtosLotes.CerrarLoteVerificacion(frmContenedorMDI.oUsuario._login, loteSeleccionado.Cells("idlote").Value, Me.CmbProyectosControlProcesos.SelectedItem._obtenerCadenaConexionProyecto())

                Next

                obtenerlotesParaProceso()

                MsgBox("Proceso finalizado con éxito", MsgBoxStyle.Information, "Correcto")
            Else
                MessageBox.Show("No hay lotes para trastasar.")
            End If

        Catch ex As Exception
            MsgBox("Error en el proceso de importación de los lotes " & ex.Message.ToString)
        Finally
            Me.pgbProcesoslotes.Value = 0
            Me.pgbProcesoslotes.Refresh()
        End Try


    End Sub

    Private Sub VisualizarDocumentosLoteToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VisualizarDocumentosLoteToolStripMenuItem2.Click
        Try


            If Me.dgvVerificación.SelectedRows.Count = 1 Then

                'Hacemos la insercion para cada uno de los lotes seleccionados 
                For Each loteSeleccionado As DataGridViewRow In Me.dgvVerificación.SelectedRows

                    visualizarlote(Me.CmbProyectosControlProcesos.SelectedItem._codigoproyecto, loteSeleccionado.Cells("idlote").Value, Me.CmbProyectosControlProcesos.SelectedItem._obtenerCadenaConexionProyecto())
                Next


                MsgBox("Proceso finalizado con éxito", MsgBoxStyle.Information, "Correcto")
            Else
                MessageBox.Show("Seleccione un único lote para visualizar los documentos.")
            End If

        Catch ex As Exception
            MsgBox("Error al pasar los lotes" & ex.Message.ToString)
        Finally

        End Try
    End Sub

#End Region


#Region "contextmenu correccion DIGI"

    Private Sub EnviarAVERIFICACIÓNLosLotesSeleccionadosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnviarAVERIFICACIÓNLosLotesSeleccionadosToolStripMenuItem.Click
        Try


            If Me.dgvCorreccionDigi.SelectedRows.Count > 0 Then

                'Hacemos la insercion para cada uno de los lotes seleccionados 
                For Each loteSeleccionado As DataGridViewRow In Me.dgvCorreccionDigi.SelectedRows

                    pgbProcesoslotes.PerformStep()

                    Application.DoEvents()

                    accesoDAtosLotes.EnviarDeCorreccionDigiAVerificar(loteSeleccionado.Cells("idlote").Value, Me.CmbProyectosControlProcesos.SelectedItem._obtenerCadenaConexionProyecto())

                Next

                obtenerlotesParaProceso()

                MsgBox("Proceso finalizado con éxito", MsgBoxStyle.Information, "Correcto")
            Else
                MessageBox.Show("No hay lotes para trastasar.")
            End If

        Catch ex As Exception
            MsgBox("Error en el proceso de importación de los lotes " & ex.Message.ToString)
        Finally
            Me.pgbProcesoslotes.Value = 0
            Me.pgbProcesoslotes.Refresh()
        End Try
    End Sub

    Private Sub EnviarATRASPASOLosLotesSeleccionadosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnviarATRASPASOLosLotesSeleccionadosToolStripMenuItem.Click
        Try


            If Me.dgvCorreccionDigi.SelectedRows.Count > 0 Then

                'Hacemos la insercion para cada uno de los lotes seleccionados 
                For Each loteSeleccionado As DataGridViewRow In Me.dgvCorreccionDigi.SelectedRows

                    pgbProcesoslotes.PerformStep()

                    Application.DoEvents()

                    accesoDAtosLotes.CerrarLoteCorreccionDIGI(frmContenedorMDI.oUsuario._login, loteSeleccionado.Cells("idlote").Value, Me.CmbProyectosControlProcesos.SelectedItem._obtenerCadenaConexionProyecto())

                Next

                obtenerlotesParaProceso()

                MsgBox("Proceso finalizado con éxito", MsgBoxStyle.Information, "Correcto")
            Else
                MessageBox.Show("No hay lotes para trastasar.")
            End If

        Catch ex As Exception
            MsgBox("Error en el proceso de importación de los lotes " & ex.Message.ToString)
        Finally
            Me.pgbProcesoslotes.Value = 0
            Me.pgbProcesoslotes.Refresh()
        End Try
    End Sub

    Private Sub VisualizarDocumentosLoteToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VisualizarDocumentosLoteToolStripMenuItem3.Click
        Try


            If Me.dgvCorreccionDigi.SelectedRows.Count = 1 Then

                'Hacemos la insercion para cada uno de los lotes seleccionados 
                For Each loteSeleccionado As DataGridViewRow In Me.dgvCorreccionDigi.SelectedRows

                    visualizarlote(Me.CmbProyectosControlProcesos.SelectedItem._codigoproyecto, loteSeleccionado.Cells("idlote").Value, Me.CmbProyectosControlProcesos.SelectedItem._obtenerCadenaConexionProyecto())
                Next


                MsgBox("Proceso finalizado con éxito", MsgBoxStyle.Information, "Correcto")
            Else
                MessageBox.Show("Seleccione un único lote para visualizar los documentos.")
            End If

        Catch ex As Exception
            MsgBox("Error al pasar los lotes" & ex.Message.ToString)
        Finally

        End Try
    End Sub

#End Region


#Region "contextmenu traspaso"



    Private Sub EnviarACORRECCIÓNDIGILosLotesSeleccionadosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnviarACORRECCIÓNDIGILosLotesSeleccionadosToolStripMenuItem.Click
        Try


            If Me.dgvTraspaso.SelectedRows.Count > 0 Then

                'Hacemos la insercion para cada uno de los lotes seleccionados 
                For Each loteSeleccionado As DataGridViewRow In Me.dgvTraspaso.SelectedRows

                    pgbProcesoslotes.PerformStep()

                    Application.DoEvents()

                    accesoDAtosLotes.EnviarDeTraspasoACorreccionDIGI(loteSeleccionado.Cells("idlote").Value, Me.CmbProyectosControlProcesos.SelectedItem._obtenerCadenaConexionProyecto())

                Next

                obtenerlotesParaProceso()

                MsgBox("Proceso finalizado con éxito", MsgBoxStyle.Information, "Correcto")
            Else
                MessageBox.Show("No hay lotes para enviar a corrección.")
            End If

        Catch ex As Exception
            MsgBox("Error en el proceso de importación de los lotes " & ex.Message.ToString)
        Finally
            Me.pgbProcesoslotes.Value = 0
            Me.pgbProcesoslotes.Refresh()
        End Try
    End Sub


    Private Sub CrearDATEnviarAIandizaciónLosLotesSeleccionadosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrearDATEnviarAIandizaciónLosLotesSeleccionadosToolStripMenuItem.Click

        Dim rutaLotes As String
        Dim rutatraspaso As String
        Dim rutaImagenes As String
        Dim datosConfiguracionLotes As DataRow
        'Dim numeroDocumentos As Integer
        Dim documentos As DataTable
        Dim NomDat As String = ""

        Dim pBytes As String


        With Me.pgbProcesoslotes
            .Maximum = Me.dgvTraspaso.Rows.Count
            .Minimum = 0
            .Value = 0
            .Step = 1
        End With


        Try


            If Me.dgvTraspaso.SelectedRows.Count > 0 Then

                'Hacemos la insercion para cada uno de los lotes seleccionados 
                For Each loteSeleccionado As DataGridViewRow In Me.dgvTraspaso.SelectedRows

                    pgbProcesoslotes.PerformStep()

                    Application.DoEvents()

                    Me.rbtMensajes.AppendText("Cargando datos de los episodios")
                    'actualizarDatosEpisodios(loteSeleccionado.Cells("idlote").Value)
                    'actualizarDatosSip(loteSeleccionado.Cells("idlote").Value)
                    Me.rbtMensajes.AppendText("Fin de la actualizaciónn datos ep ")
                    accesoDAtosLotes.CerrarLoteTraspaso("lulu", frmContenedorMDI.oUsuario._login, loteSeleccionado.Cells("idlote").Value, Me.CmbProyectosControlProcesos.SelectedItem._obtenerCadenaConexionProyecto())


                Next

                obtenerlotesParaProceso()

                MsgBox("Proceso finalizado con éxito", MsgBoxStyle.Information, "Correcto")
            Else
                MessageBox.Show("No hay lotes para traspasar.")
            End If

        Catch ex As Exception
            MsgBox("Error al crear el DAT " & ex.Message.ToString)
        Finally

        End Try

    End Sub


    Private Sub actualizarDatosEpisodios(ByVal idlote As Integer)

        Dim coleccionSips As DataTable

        Dim iobtenerdatossip As IdatosSIPOracle
        Dim iactualizardatossip As IdatosSIPSQL

        iactualizardatossip = New ClsDAtosSipSQL

        Dim idatosSip As IdatosSIPOracle
        idatosSip = New clsDatosSipOracle
        Dim sip As New ClsSIP(0)
        Dim datosConsultas As DataTable
        Dim datosHospitalizacion As DataTable
        Dim datosUrgencias As DataTable
        Dim item As ListViewItem
        Dim numhistoria As Integer


        'consulta para sacar los distintos sips del lote
        coleccionSips = AccesoDatos.ejecutarSQLDirectaTable("Select distinct numhistoria from documentos where idlote = " & idlote, Me.CmbProyectosControlProcesos.SelectedItem._obtenercadenaconexionproyecto)

        If coleccionSips.Rows.Count > 0 Then


            For Each historia As DataRow In coleccionSips.Rows
                Try
                    'aqui empezamos con todo

                    numhistoria = historia.Item("numhistoria")

                    datosConsultas = idatosSip.obtenerdatosEpisodiosConsultas(numhistoria, My.Settings.cadenaConexionOracle)
                    datosHospitalizacion = idatosSip.obtenerdatosEpisodiosHospitalizacion(numhistoria, My.Settings.cadenaConexionOracle)
                    datosUrgencias = idatosSip.obtenerdatosEpisodiosUrgencias(numhistoria, My.Settings.cadenaConexionOracle)

                    iactualizardatossip.actualizarEpisodiosProduccion(idlote, datosConsultas, "CEX", frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto, Me.rbtMensajes, Me.pbprocesosDocumentos)
                    iactualizardatossip.actualizarEpisodiosProduccion(idlote, datosHospitalizacion, "HOSP", frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto, Me.rbtMensajes, Me.pbprocesosDocumentos)
                    iactualizardatossip.actualizarEpisodiosProduccion(idlote, datosUrgencias, "URG", frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto, Me.rbtMensajes, Me.pbprocesosDocumentos)


                Catch ex As Exception
                    Debug.Print("excepcion esto pasa cuando pilla la cadena null como sip ")
                End Try
            Next

        End If



    End Sub



    Private Sub VisualizarDocumentosLoteToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VisualizarDocumentosLoteToolStripMenuItem4.Click
        Try


            If Me.dgvTraspaso.SelectedRows.Count = 1 Then

                'Hacemos la insercion para cada uno de los lotes seleccionados 
                For Each loteSeleccionado As DataGridViewRow In Me.dgvTraspaso.SelectedRows

                    visualizarlote(Me.CmbProyectosControlProcesos.SelectedItem._codigoproyecto, loteSeleccionado.Cells("idlote").Value, Me.CmbProyectosControlProcesos.SelectedItem._obtenerCadenaConexionProyecto())
                Next


                MsgBox("Proceso finalizado con éxito", MsgBoxStyle.Information, "Correcto")
            Else
                MessageBox.Show("Seleccione un único lote para visualizar los documentos.")
            End If

        Catch ex As Exception
            MsgBox("Error al pasar los lotes" & ex.Message.ToString)
        Finally

        End Try
    End Sub




#End Region

    Private Sub EnviarATraspasoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnviarATraspasoToolStripMenuItem.Click
        Try


            If Me.dgvExportados.SelectedRows.Count > 0 Then

                'Hacemos la insercion para cada uno de los lotes seleccionados 
                For Each loteSeleccionado As DataGridViewRow In Me.dgvExportados.SelectedRows

                    pgbProcesoslotes.PerformStep()

                    Application.DoEvents()

                    accesoDAtosLotes.EnviarDeIndizacionATraspaso(loteSeleccionado.Cells("idlote").Value, Me.CmbProyectosControlProcesos.SelectedItem._obtenerCadenaConexionProyecto())

                Next

                obtenerlotesParaProceso()

                MsgBox("Proceso finalizado con éxito", MsgBoxStyle.Information, "Correcto")
            Else
                MessageBox.Show("No hay lotes para enviar a corrección.")
            End If

        Catch ex As Exception
            MsgBox("Error en el proceso de importación de los lotes " & ex.Message.ToString)
        Finally
            Me.pgbProcesoslotes.Value = 0
            Me.pgbProcesoslotes.Refresh()
        End Try
    End Sub
#Region "contextmenu indizacion"

    Private Sub EnviarATRASPASOLosLotesSeleccinadosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnviarATRASPASOLosLotesSeleccinadosToolStripMenuItem.Click
        Try


            If Me.dgvIndizacion.SelectedRows.Count > 0 Then

                'Hacemos la insercion para cada uno de los lotes seleccionados 
                For Each loteSeleccionado As DataGridViewRow In Me.dgvIndizacion.SelectedRows

                    pgbProcesoslotes.PerformStep()

                    Application.DoEvents()

                    accesoDAtosLotes.EnviarDeIndizacionATraspaso(loteSeleccionado.Cells("idlote").Value, Me.CmbProyectosControlProcesos.SelectedItem._obtenerCadenaConexionProyecto())

                Next

                obtenerlotesParaProceso()

                MsgBox("Proceso finalizado con éxito", MsgBoxStyle.Information, "Correcto")
            Else
                MessageBox.Show("No hay lotes para enviar a corrección.")
            End If

        Catch ex As Exception
            MsgBox("Error en el proceso de importación de los lotes " & ex.Message.ToString)
        Finally
            Me.pgbProcesoslotes.Value = 0
            Me.pgbProcesoslotes.Refresh()
        End Try
    End Sub

    Private Sub EnviarACORRECCIÓNPAEDLosLotesSeleccionadosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnviarACORRECCIÓNPAEDLosLotesSeleccionadosToolStripMenuItem.Click
        Try


            If Me.dgvIndizacion.SelectedRows.Count > 0 Then

                'Hacemos la insercion para cada uno de los lotes seleccionados 
                For Each loteSeleccionado As DataGridViewRow In Me.dgvIndizacion.SelectedRows

                    pgbProcesoslotes.PerformStep()

                    Application.DoEvents()

                    accesoDAtosLotes.CerrarLoteIndizacion(frmContenedorMDI.oUsuario._login, loteSeleccionado.Cells("idlote").Value, Me.CmbProyectosControlProcesos.SelectedItem._obtenerCadenaConexionProyecto())

                Next

                obtenerlotesParaProceso()

                MsgBox("Proceso finalizado con éxito", MsgBoxStyle.Information, "Correcto")
            Else
                MessageBox.Show("No hay lotes para trastasar.")
            End If

        Catch ex As Exception
            MsgBox("Error en el proceso de importación de los lotes " & ex.Message.ToString)
        Finally
            Me.pgbProcesoslotes.Value = 0
            Me.pgbProcesoslotes.Refresh()
        End Try
    End Sub

    Private Sub VisualizarDocumentosLoteToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VisualizarDocumentosLoteToolStripMenuItem5.Click
        Try


            If Me.dgvIndizacion.SelectedRows.Count = 1 Then

                'Hacemos la insercion para cada uno de los lotes seleccionados 
                For Each loteSeleccionado As DataGridViewRow In Me.dgvIndizacion.SelectedRows

                    visualizarlote(Me.CmbProyectosControlProcesos.SelectedItem._codigoproyecto, loteSeleccionado.Cells("idlote").Value, Me.CmbProyectosControlProcesos.SelectedItem._obtenerCadenaConexionProyecto())
                Next


                MsgBox("Proceso finalizado con éxito", MsgBoxStyle.Information, "Correcto")
            Else
                MessageBox.Show("Seleccione un único lote para visualizar los documentos.")
            End If

        Catch ex As Exception
            MsgBox("Error al pasar los lotes" & ex.Message.ToString)
        Finally

        End Try
    End Sub

#End Region


#Region "contextmenu correccionPAED"


    Private Sub EnviarAINDIZACIÓNLosLotesSeleccionadosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnviarAINDIZACIÓNLosLotesSeleccionadosToolStripMenuItem.Click

        Try


            If Me.dgvCorreccionPAED.SelectedRows.Count > 0 Then

                'Hacemos la insercion para cada uno de los lotes seleccionados 
                For Each loteSeleccionado As DataGridViewRow In Me.dgvCorreccionPAED.SelectedRows

                    pgbProcesoslotes.PerformStep()

                    Application.DoEvents()

                    accesoDAtosLotes.EnviarDeCorreccionPAEDAIndizacion(loteSeleccionado.Cells("idlote").Value, Me.CmbProyectosControlProcesos.SelectedItem._obtenerCadenaConexionProyecto())

                Next

                obtenerlotesParaProceso()

                MsgBox("Proceso finalizado con éxito", MsgBoxStyle.Information, "Correcto")
            Else
                MessageBox.Show("No hay lotes para enviar a corrección.")
            End If

        Catch ex As Exception
            MsgBox("Error en el proceso de importación de los lotes " & ex.Message.ToString)
        Finally
            Me.pgbProcesoslotes.Value = 0
            Me.pgbProcesoslotes.Refresh()
        End Try
    End Sub

    Private Sub EnviarAFinalizaciónLosLotesSeleccionadosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnviarAFinalizaciónLosLotesSeleccionadosToolStripMenuItem.Click
        Try


            If Me.dgvCorreccionPAED.SelectedRows.Count > 0 Then

                'Hacemos la insercion para cada uno de los lotes seleccionados 
                For Each loteSeleccionado As DataGridViewRow In Me.dgvCorreccionPAED.SelectedRows

                    pgbProcesoslotes.PerformStep()

                    Application.DoEvents()

                    accesoDAtosLotes.CerrarLoteCorreccionPAED(frmContenedorMDI.oUsuario._login, loteSeleccionado.Cells("idlote").Value, Me.CmbProyectosControlProcesos.SelectedItem._obtenerCadenaConexionProyecto())

                Next

                obtenerlotesParaProceso()

                MsgBox("Proceso finalizado con éxito", MsgBoxStyle.Information, "Correcto")
            Else
                MessageBox.Show("No hay lotes para trastasar.")
            End If

        Catch ex As Exception
            MsgBox("Error en el proceso de importación de los lotes " & ex.Message.ToString)
        Finally
            Me.pgbProcesoslotes.Value = 0
            Me.pgbProcesoslotes.Refresh()
        End Try
    End Sub

    Private Sub VisualizarDocumentosLoteToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VisualizarDocumentosLoteToolStripMenuItem6.Click
        Try


            If Me.dgvCorreccionPAED.SelectedRows.Count = 1 Then

                'Hacemos la insercion para cada uno de los lotes seleccionados 
                For Each loteSeleccionado As DataGridViewRow In Me.dgvCorreccionPAED.SelectedRows

                    visualizarlote(Me.CmbProyectosControlProcesos.SelectedItem._codigoproyecto, loteSeleccionado.Cells("idlote").Value, Me.CmbProyectosControlProcesos.SelectedItem._obtenerCadenaConexionProyecto())
                Next


                MsgBox("Proceso finalizado con éxito", MsgBoxStyle.Information, "Correcto")
            Else
                MessageBox.Show("Seleccione un único lote para visualizar los documentos.")
            End If

        Catch ex As Exception
            MsgBox("Error al pasar los lotes" & ex.Message.ToString)
        Finally

        End Try
    End Sub

#End Region

#Region "contextmenuFinalizacion"



    Private Sub EnviarACORRECCIONPAEDLosLotesSeleccionadosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnviarACORRECCIONPAEDLosLotesSeleccionadosToolStripMenuItem.Click
        Try


            If Me.dgvFinalizacion.SelectedRows.Count > 0 Then

                'Hacemos la insercion para cada uno de los lotes seleccionados 
                For Each loteSeleccionado As DataGridViewRow In Me.dgvFinalizacion.SelectedRows

                    pgbProcesoslotes.PerformStep()

                    Application.DoEvents()

                    accesoDAtosLotes.EnviarDeFinalizacionACorreccionPAED(loteSeleccionado.Cells("idlote").Value, Me.CmbProyectosControlProcesos.SelectedItem._obtenerCadenaConexionProyecto())

                Next

                obtenerlotesParaProceso()

                MsgBox("Proceso finalizado con éxito", MsgBoxStyle.Information, "Correcto")
            Else
                MessageBox.Show("No hay lotes para enviar a corrección.")
            End If

        Catch ex As Exception
            MsgBox("Error en el proceso de importación de los lotes " & ex.Message.ToString)
        Finally
            Me.pgbProcesoslotes.Value = 0
            Me.pgbProcesoslotes.Refresh()
        End Try
    End Sub

    Private Sub EXPORTARLosLotesSeleccionadosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FINALIZARLosLotesSeleccionadosToolStripMenuItem.Click
        '    Try

        '        Dim ioperacionesORACLE As IdatosSIPOracle
        '        Dim ioperacionesSQL As IdatosSIPSQL
        '        Dim mensaje As String = ""
        '        Dim mensajesERror As String = ""
        '        Dim historias As New Collection

        '        ioperacionesORACLE = New clsDatosSipOracle
        '        ioperacionesSQL = New ClsDAtosSipSQL

        '        If Me.dgvFinalizacion.SelectedRows.Count > 0 Then

        '            'Hacemos la insercion para cada uno de los lotes seleccionados 
        '            For Each loteSeleccionado As DataGridViewRow In Me.dgvFinalizacion.SelectedRows

        '                pgbProcesoslotes.PerformStep()

        '                Application.DoEvents()

        '                '

        '                If LibreriaCadenaProduccion.Datos.GeneralSQL.clsAccesoDatosSQL.ObtenerListadoParaValorParametro("documentos", "count(*)", "indizado!", "1 or indizado is null", Me.CmbProyectosControlProcesos.SelectedItem._obtenerCadenaConexionProyecto(), "idlote", loteSeleccionado.Cells("idlote").Value).Rows(0).Item(0) = 0 Then

        '                    'controlando el tema del estado de las historias en el his para cada lote 
        '                    'todas las historias tienen que tener 
        '                    ' cod_estatoss = 1 disponible 
        '                    ' cod_tipo_hc = 2 con carpeta 
        '                    'y la coleccion tiene que estar en 46,47,48,50

        '                    ioperacionesSQL.obtenerHistoriasLote(historias, loteSeleccionado.Cells("idlote").Value, Me.CmbProyectosControlProcesos.SelectedItem._obtenerCadenaConexionProyecto, Me.rbtMensajes)

        '                    ioperacionesORACLE.comprobarEstadoIncialHistorias(historias, mensajesERror, My.Settings.cadenaConexionOracle)


        '                    'If mensajesERror <> "" Then
        '                    'editor.escribir(Me.rbtMensajes, mensajesERror, Color.Red)
        '                    'Exit Sub
        '                    'End If

        '                    If LibreriaCadenaProduccion.Entidades.Operaciones.clsOperacionesLoteExportacion.exportarDatosLote(loteSeleccionado.Cells("idlote").Value, Me.CmbProyectosControlProcesos.SelectedItem._codigoproyecto, My.Settings.cadenaConexion, Me.CmbProyectosControlProcesos.SelectedItem._obtenerCadenaConexionProyecto, My.Settings.cadenaConexionOracle, My.Settings.rutaRepositorioHospital, Me.rbtMensajes, Me.pbprocesosDocumentos, Me.AxImgEdit1) = 1 Then


        '                        accesoDAtosLotes.CerrarLoteFinalizacion(frmContenedorMDI.oUsuario._login, loteSeleccionado.Cells("idlote").Value, Me.CmbProyectosControlProcesos.SelectedItem._obtenerCadenaConexionProyecto())

        '                    Else

        '                        ' MsgBox("Error en el proceso de importación de los lotes ")

        '                    End If

        '                Else
        '                    MsgBox("¡No se puede EXPORTAR! El lote = " & loteSeleccionado.Cells("idlote").Value & " contiene documentos sin indizar")
        '                End If

        '            Next

        '            MsgBox("Finalizo el proceso de exportación")
        '            obtenerlotesParaProceso()


        '        Else
        '            MessageBox.Show("No hay lotes para trastasar.")
        '        End If

        '    Catch ex As Exception
        '        MsgBox("Error en el proceso de importación de los lotes " & ex.Message.ToString)
        '    Finally
        '        Me.pgbProcesoslotes.Value = 0
        '        Me.pgbProcesoslotes.Refresh()
        '    End Try
        'End Sub

        Try

            If Me.dgvFinalizacion.SelectedRows.Count > 0 Then

                MessageBox.Show("Esta operación la realizará el Autómata Exportador.", "No es posible realizar operación", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Exit Sub



                RegistroErrores = ""

                'Hacemos la insercion para cada uno de los lotes seleccionados 
                For Each loteSeleccionado As DataGridViewRow In Me.dgvFinalizacion.SelectedRows

                    pgbProcesoslotes.PerformStep()

                    Application.DoEvents()

                    'If LibreriaCadenaProduccion.Datos.GeneralSQL.clsAccesoDatosSQL.ObtenerListadoParaValorParametro("documentos", "count(*)", "indizado!", "1 or indizado is null", Me.CmbProyectosControlProcesos.SelectedItem._obtenerCadenaConexionProyecto(), "idlote", loteSeleccionado.Cells("idlote").Value).Rows(0).Item(0) = 0 Then

                    If LibreriaCadenaProduccion.Entidades.Operaciones.clsOperacionesLoteExportacionPorDocumentos.exportarDatosLote(loteSeleccionado.Cells("idlote").Value, Me.CmbProyectosControlProcesos.SelectedItem._codigoproyecto, My.Settings.cadenaConexion, Me.CmbProyectosControlProcesos.SelectedItem._obtenerCadenaConexionProyecto, Me.rbtMensajes, Me.pbprocesosDocumentos, Me.AxImgEdit1) = 1 Then

                        accesoDAtosLotes.CerrarLoteFinalizacion(frmContenedorMDI.oUsuario._login, loteSeleccionado.Cells("idlote").Value, Me.CmbProyectosControlProcesos.SelectedItem._obtenerCadenaConexionProyecto())

                        ' MsgBox("Proceso finalizado con éxito", MsgBoxStyle.Information, "Correcto")

                    Else

                        'MsgBox("Error en el proceso de exportación de los lotes ")
                    End If
                    'Else
                    ' MsgBox("¡No se puede EXPORTAR! El lote = " & loteSeleccionado.Cells("idlote").Value & " contiene documentos sin indizar")
                    'End If

                Next

                obtenerlotesParaProceso()

            Else
                MessageBox.Show("No hay lotes para trastasar.")
            End If

            If RegistroErrores.Trim <> "" Then
                MessageBox.Show("Se han producido errores durante la ejecución. Por favor, revise el log")
            End If

        Catch ex As Exception
            'MsgBox("Error en el proceso de importación de los lotes " & ex.Message.ToString)
        Finally
            Me.pgbProcesoslotes.Value = 0
            Me.pgbProcesoslotes.Refresh()
        End Try
    End Sub


    Private Sub VisualizarDocumentosLotesSelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VisualizarDocumentosLotesSelToolStripMenuItem.Click
        Try

            If Me.dgvFinalizacion.SelectedRows.Count = 1 Then

                'Hacemos la insercion para cada uno de los lotes seleccionados 
                For Each loteSeleccionado As DataGridViewRow In Me.dgvFinalizacion.SelectedRows

                    visualizarlote(Me.CmbProyectosControlProcesos.SelectedItem._codigoproyecto, loteSeleccionado.Cells("idlote").Value, Me.CmbProyectosControlProcesos.SelectedItem._obtenerCadenaConexionProyecto())
                Next


                MsgBox("Proceso finalizado con éxito", MsgBoxStyle.Information, "Correcto")
            Else
                MessageBox.Show("Seleccione un único lote para visualizar los documentos.")
            End If

        Catch ex As Exception
            MsgBox("Error al pasar los lotes" & ex.Message.ToString)
        Finally

        End Try
    End Sub
#End Region




    Private Sub visualizarlote(ByVal codigoProyecto As String, ByVal idlote As String, ByVal cadenaconexionpro As String)
        Dim rutaimagenes As String

        rutaimagenes = accesoDatospro.ObtenerRutaImagenes(codigoProyecto, idlote, My.Settings.cadenaConexion)

        Dim _frmvisualizacion As New frmVisualizarlote(idlote, cadenaconexionpro, rutaimagenes)
        _frmvisualizacion.Show()


    End Sub

#End Region



    Private Sub CtrlGenerarCaratulas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


        'If Not IsNothing(cmbProyectosCrearCaratulas.SelectedItem) Then

        '    'Dim _frmInseratarDatosFip As New frmInsertarDatosFIP(cmbProyectosCrearCaratulas.SelectedItem._obtenerCadenaConexionProyecto.ToString)
        '    ' _frmInseratarDatosFip.ShowDialog()

        'Else
        '    MessageBox.Show("Tienen que seleccionar algun proyecto antes de ejecutar esta instruccion")
        'End If


    End Sub

    Private Sub ExportarLoteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportarLoteToolStripMenuItem.Click

        Try
            RegistroErrores = ""

            If Me.dgvTraspaso.SelectedRows.Count > 0 Then

                'Hacemos la insercion para cada uno de los lotes seleccionados 
                For Each loteSeleccionado As DataGridViewRow In Me.dgvTraspaso.SelectedRows

                    pgbProcesoslotes.PerformStep()

                    Application.DoEvents()

                    'If LibreriaCadenaProduccion.Datos.GeneralSQL.clsAccesoDatosSQL.ObtenerListadoParaValorParametro("documentos", "count(*)", "indizado!", "1 or indizado is null", Me.CmbProyectosControlProcesos.SelectedItem._obtenerCadenaConexionProyecto(), "idlote", loteSeleccionado.Cells("idlote").Value).Rows(0).Item(0) = 0 Then

                    If LibreriaCadenaProduccion.Entidades.Operaciones.clsOperacionesLoteExportacion.exportarDatosLote(loteSeleccionado.Cells("idlote").Value, Me.CmbProyectosControlProcesos.SelectedItem._codigoproyecto, My.Settings.cadenaConexion, Me.CmbProyectosControlProcesos.SelectedItem._obtenerCadenaConexionProyecto, My.Settings.cadenaConexionOracle, My.Settings.rutaRepositorioHospital, Me.rbtMensajes, Me.pbprocesosDocumentos, Me.AxImgEdit1) = 1 Then

                        accesoDAtosLotes.CerrarLoteFinalizacion(frmContenedorMDI.oUsuario._login, loteSeleccionado.Cells("idlote").Value, Me.CmbProyectosControlProcesos.SelectedItem._obtenerCadenaConexionProyecto())

                        'si pongo esto se vera para cada lote la mierda de mensajito 
                        '  MsgBox("Proceso finalizado con éxito", MsgBoxStyle.Information, "Correcto")

                    Else

                        'MsgBox("Error en el proceso de exportación de los lotes, el lote no se ha exportado complemamente ")
                    End If


                Next

                obtenerlotesParaProceso()


            Else
                MessageBox.Show("No hay lotes para trastasar.")
            End If

            If RegistroErrores.Trim <> "" Then
                MessageBox.Show("Se han producido errores durante la ejecución. Por favor, revise el log")
                RegistroErrores = ""
            End If

        Catch ex As Exception
            'MsgBox("Error general en el proceso de Exportación de los lotes. El proceso será detenido " & ex.Message.ToString)
        Finally
            Me.pgbProcesoslotes.Value = 0
            Me.pgbProcesoslotes.Refresh()
        End Try

    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        If Not IsNothing(CmbProyectosControlProcesos.SelectedItem) Then

            Dim _frmCreacionDVD As New frmCreacionDVD(CmbProyectosControlProcesos.SelectedItem._obtenerCadenaConexionProyecto.ToString, CmbProyectosControlProcesos.SelectedItem._CodigoProyecto, frmContenedorMDI.oUsuario._id, My.Settings.cadenaConexion)
            _frmCreacionDVD.ShowDialog()
        Else
            MessageBox.Show("Tienen que seleccionar algun proyecto antes de ejecutar esta instruccion")
        End If

    End Sub

    Private Sub tabConfiguracionProyectos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabConfiguracionProyectos.Click

    End Sub

    Private Sub tabControlProcesos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabControlProcesos.Click

    End Sub

    Private Sub gbControlProcesos_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gbControlProcesos.Enter

    End Sub

    Private Sub GroupBox5_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox5.Enter

    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


    Private Sub EnviarAFinalizaciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnviarAFinalizaciónToolStripMenuItem.Click
        Try
            If Me.dgvExportados.SelectedRows.Count > 0 Then

                'Hacemos la insercion para cada uno de los lotes seleccionados 
                For Each loteSeleccionado As DataGridViewRow In Me.dgvExportados.SelectedRows

                    pgbProcesoslotes.PerformStep()

                    Application.DoEvents()

                    accesoDAtosLotes.EnviarDeExportadosAFinalizacion(loteSeleccionado.Cells("idlote").Value, Me.CmbProyectosControlProcesos.SelectedItem._obtenerCadenaConexionProyecto())

                Next

                obtenerlotesParaProceso()

                MsgBox("Proceso finalizado con éxito", MsgBoxStyle.Information, "Correcto")
            Else
                MessageBox.Show("No hay lotes para enviar a corrección.")
            End If

        Catch ex As Exception
            MsgBox("Error en el proceso de importación de los lotes " & ex.Message.ToString)
        Finally
            Me.pgbProcesoslotes.Value = 0
            Me.pgbProcesoslotes.Refresh()
        End Try
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click

        Dim mensaje As String = ""
        Dim lsSql As String = "select * from lotes where (Atributado=1) and (CorregidoAtributado=0 or CorregidoAtributado is null)"
        Dim dt As DataTable

        dt = AccesoDatos.ejecutarSQLDirectaTable(lsSql, Me.CmbProyectosControlProcesos.SelectedItem._obtenerCadenaConexionProyecto())
        For Each fila As DataRow In dt.Rows
            mensaje = compruebaHistorias(fila.Item("idlote"))
        Next

        Exit Sub







        ''INSERTA INVENTARIO EN TABLA LOTEADO_CINF

        Dim cadenaconexionorigen As String = "Persist Security Info=False;User=sa ;Password=sa2017_gedsa;Initial Catalog=IMPORTACION_LARIBERA;Data Source=LAPTOP-7S2ALCMQ\SQLEXPRESS2017”

        Dim cadenaconexiondestino As String = "Persist Security Info=False;User=sa ;Password=sa2016_gedsa;Initial Catalog=PRODUCCIONLARIBERA;Data Source=LAPTOP-7S2ALCMQ\SQLS2016_LOCAL”


        ''Dim lsSql As String = ""
        Dim filas As DataTable
        Dim valores As String = ""
        Dim dsPropuestasEX As DataTable
        Dim contador As Integer = 1


        dsPropuestasEX = Digitalización.accesoDatosNuevos.clsAccesoDatosNUEVO.DevuelveExcelEnDataTable("E:\JANTONIO\La_Ribera_Alzira\Documentación\Inventarios\292.01_Hospital La Ribera_Consentimientos Informados_rev03_1.xlsx", "292.1 Inventario", " 'Documento'")
        For Each registro As DataRow In dsPropuestasEX.Rows
            'Construye cadena updadate
            lsSql = "INSERT INTO loteado_cinf (archivador, carpeta, orden, numHistoria, idServicioHospital) " &
                            " VALUES (" &
            IIf(registro.Item("CAJA_CLIENTE").ToString.Trim = "", "NULL", registro.Item("CAJA_CLIENTE")) & "," & IIf(registro.Item("NUMERO").ToString.Trim = "", "NULL", registro.Item("NUMERO")) & "," & IIf(registro.Item("POSICION").ToString.Trim = "", "NULL", registro.Item("POSICION")) & "," & IIf(registro.Item("DOCUMENTO").ToString.Trim = "", "NULL", registro.Item("DOCUMENTO")) & ",'" & registro.Item("TEXTO") & "')"
            AccesoDatos.ejecutaSQLEjecucion(lsSql, cadenaconexiondestino, , False)

            contador += 1
        Next


        ''IMPORTA TIPOS DE DOCUMENTOS
        ''Dim cadenaconexionorigen As String = "Persist Security Info=False;User=sa ;Password=sa2017_gedsa;Initial Catalog=IMPORTACION_LARIBERA;Data Source=LAPTOP-7S2ALCMQ\SQLEXPRESS2017”

        ''Dim cadenaconexiondestino As String = "Persist Security Info=False;User=sa ;Password=sa2016_gedsa;Initial Catalog=PRODUCCIONLARIBERA;Data Source=LAPTOP-7S2ALCMQ\SQLS2016_LOCAL”


        ''Dim lsSql As String = ""
        ''Dim filas As DataTable
        ''Dim valores As String = ""
        ''Dim dsPropuestasEX As DataTable
        ''Dim contador As Integer = 1


        ''dsPropuestasEX = Digitalización.accesoDatosNuevos.clsAccesoDatosNUEVO.DevuelveExcelEnDataTable("E:\JANTONIO\La_Ribera_Alzira\Documentación\CoreDocPublicacionCodificacion28102020.xlsx", "Tipos Documentos Administrativo", "")
        ''For Each registro As DataRow In dsPropuestasEX.Rows
        ''    'Construye cadena updadate
        ''    lsSql = "INSERT INTO TIPOSDOCUMENTOS (idTipoDocumento, Descripcion, Definicion, Tipo, Categoria) " &
        ''                    " VALUES (" &
        ''    contador & ",'" & registro.Item("TipoDocumento") & "','" & registro.Item("CodTipoDocumento") & "','Administrativo','" & registro.Item("Categoría") & "')"
        ''    AccesoDatos.ejecutaSQLEjecucion(lsSql, cadenaconexiondestino, , False)

        ''    contador += 1
        ''Next

        ''''contador = 1

        ''dsPropuestasEX = Digitalización.accesoDatosNuevos.clsAccesoDatosNUEVO.DevuelveExcelEnDataTable("E:\JANTONIO\La_Ribera_Alzira\Documentación\CoreDocPublicacionCodificacion28102020.xlsx", "Tipos Documentos Clínicos", "")
        ''For Each registro As DataRow In dsPropuestasEX.Rows
        ''    'Construye cadena updadate
        ''    lsSql = "INSERT INTO TIPOSDOCUMENTOS (idTipoDocumento, Descripcion, Definicion, Tipo, Categoria) " &
        ''                    " VALUES (" &
        ''    contador & ",'" & registro.Item("TipoDocumento") & "','" & registro.Item("CodTipoDocumento") & "','Clinico','" & registro.Item("Categoría") & "')"
        ''    AccesoDatos.ejecutaSQLEjecucion(lsSql, cadenaconexiondestino, , False)

        ''    contador += 1
        ''Next




    End Sub

    Private Function compruebaHistorias(ByVal idLote As Integer) As String

        Dim lsSql As String = ""
        Dim mensaje As String = ""
        Dim lotes As String = ""
        Dim dt As DataTable

        Try

            ''If idLote = 33 Then Stop

            'Comprueba historias que están indizadas y no en GECI
            lsSql = "select distinct(numhistoria) from documentos where idlote=" & idLote & " and (eliminada is null or Eliminada = 0) " &
                        " EXCEPT " &
                " SELECT distinct(numHistoria) FROM [PRODUCCIONLARIBERA].[dbo].[loteado_cinf] where idlote=" & idLote
            dt = AccesoDatos.ejecutarSQLDirectaTable(lsSql, Me.CmbProyectosControlProcesos.SelectedItem._obtenerCadenaConexionProyecto())
            For Each fila As DataRow In dt.Rows
                lotes = lotes & ", " & fila.Item("numHistoria")
            Next

            If lotes.ToString.Trim <> "" Then
                mensaje = "Las historias " & lotes.Substring(1).ToString.Trim & " se han indizado pero no existen en GECI."
                lotes = ""
                editor.escribirEnLogExplotacion(idLote & "#" & mensaje)
            End If

            'Comprueba historias que están en GECI pero no se han indizado
            lsSql = "SELECT distinct(numHistoria) FROM [PRODUCCIONLARIBERA].[dbo].[loteado_cinf] where idlote=" & idLote &
                            " EXCEPT " &
                    "select distinct(numhistoria) from documentos where idlote=" & idLote & " and (eliminada is null or Eliminada = 0)"
            dt = AccesoDatos.ejecutarSQLDirectaTable(lsSql, Me.CmbProyectosControlProcesos.SelectedItem._obtenerCadenaConexionProyecto())
            For Each fila As DataRow In dt.Rows
                lotes = lotes & ", " & fila.Item("numHistoria")
            Next

            If lotes.ToString.Trim <> "" Then
                mensaje = "Las historias " & lotes.Substring(1).ToString.Trim & " si existen en GECI pero no se han indizado."
                editor.escribirEnLogExplotacion(idLote & "#" & mensaje)
            End If

        Catch ex As Exception
            mensaje = "FALLO"

        End Try

        Return mensaje

    End Function

    Private Sub DgvCorreccionPAED_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles dgvCorreccionPAED.RowPrePaint

        Try
            If e.RowIndex < sender.rows.count Then
                Dim fila As DataGridViewRow

                fila = Me.dgvCorreccionPAED.Rows(e.RowIndex)

                If fila IsNot Nothing Then

                    ''Marca la fila en rojo si es documento en mal estado
                    If fila.Cells(3).Value.ToString.Trim = "1" Then
                        fila.DefaultCellStyle.ForeColor = Color.Red
                    End If

                End If
            End If
        Catch ex As Exception
            ''    MessageBox.Show(ex.Message.ToString)
        End Try

    End Sub

End Class