Imports LibreriaCadenaProduccion.Controles.Botones.CtrlBotonGrande
Imports datos = LibreriaCadenaProduccion.Datos.GeneralSQL.clsAccesoDatosSQL
Imports accesoDatosProduccion = LibreriaCadenaProduccion.Datos.Produccion.clsAccesoDatosProduccion
Imports accesoDatosLotes = LibreriaCadenaProduccion.Datos.Produccion.cadenaproduccion.clsAccesoDatosLote
Imports editor = LibreriaCadenaProduccion.TXT.clsFormato
Imports LibreriaCadenaProduccion.Module1

Public Class frmIndizacionGeneral


    Private idDocumentoActual As Integer = 0
    Private rutaImagenes As String = ""
    Private listaContenidoEn As String = ""
    Public indice As Integer = 0

    Public listaHistoriasGECI As New List(Of Integer)

    Dim rutaImg As String = ""


#Region "Inicializacion del formulario"


    Public Sub New()

        ' Llamada necesaria para el Disenyador de Windows Forms.
        InitializeComponent()

        ''marcaPrimeraPaginaBloque(frmContenedorMDI.oLote._idlote)

        Me.rutaImagenes = accesoDatosProduccion.ObtenerRutaImagenes(frmContenedorMDI.oProyecto._CodigoProyecto,
                          frmContenedorMDI.oLote._idlote, My.Settings.cadenaConexion)
        inicializarListView() ' aqui empieza la fiesta carga los datos y pone el indice del primero

        Me.CtrlIndizacionEpidemiologia1.agregarInstancia(Me)



        'Me.CtrlIndizacionEpidemiologia1.txtCodigoDoc.Focus()

        'Me.CtrlIndizacionEpidemiologia1.txtNumReferencia.Focus()
        ' Agregue cualquier inicializacion despu?s de la llamada a InitializeComponent().
        'Me.CtrlBotonGrande1.Focus()
    End Sub

    Private Sub frmIndizacionEpidemiologia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Text = Me.Text & "- " & frmContenedorMDI.oLote._nombreCompleto
        RutaCompletaCadenaConexion = frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto
        QuiereCerrarLote = False
        escribirInicioSesion()

        cargaHistoriasGECI()

        ''inicializarListView() ' aqui empieza la fiesta carga los datos y pone el indice del primero

        ''If ListView1.Items.Count > 0 Then
        ''    'Se posiciona en el listview y lanza el evento al cambiar de linea del listveiw
        ''    Me.ListView1.Items(indice).Selected = True
        ''    Me.ListView1.Items(indice).EnsureVisible()
        ''End If

        'inicializarControles()

    End Sub



#End Region



    ''' <summary>
    ''' M?todo que nos permite inicializar los datos del listview
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub inicializarListView()
        Dim lsSql As String = ""
        Dim data As DataTable

        Try

            Me.idDocumento = New System.Windows.Forms.ColumnHeader
            Me.idLote = New System.Windows.Forms.ColumnHeader
            Me.Pagina = New System.Windows.Forms.ColumnHeader
            Me.nomArchivoTIF = New System.Windows.Forms.ColumnHeader
            Me.Numhistoria = New System.Windows.Forms.ColumnHeader
            Me.FechaDoc = New System.Windows.Forms.ColumnHeader
            Me.BarCodeDet = New System.Windows.Forms.ColumnHeader
            Me.Serv = New System.Windows.Forms.ColumnHeader
            Me.Numicu = New System.Windows.Forms.ColumnHeader
            Me.tipoDocumento = New System.Windows.Forms.ColumnHeader
            Me.incidencia = New System.Windows.Forms.ColumnHeader
            Me.Indizada = New System.Windows.Forms.ColumnHeader
            Me.nombre = New System.Windows.Forms.ColumnHeader
            Me.apellido1 = New System.Windows.Forms.ColumnHeader
            Me.apellido2 = New System.Windows.Forms.ColumnHeader
            Me.Servicio = New System.Windows.Forms.ColumnHeader
            Me.CIP = New System.Windows.Forms.ColumnHeader
            Me.DNI = New System.Windows.Forms.ColumnHeader
            Me.tipoActo = New System.Windows.Forms.ColumnHeader
            Me.primera = New System.Windows.Forms.ColumnHeader
            Me.ContenidoEn = New System.Windows.Forms.ColumnHeader
            Me.ErrorEnvio = New System.Windows.Forms.ColumnHeader
            Me.SIP = New System.Windows.Forms.ColumnHeader

            Me.ListView1.Columns.Clear()
            Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.idDocumento, Me.idLote, Me.Pagina, Me.nomArchivoTIF, Me.Numhistoria,
                                            Me.FechaDoc, Me.fechaInicio, Me.fechaTermino, Me.Serv, Me.tipoDocumento, Me.CIP, Me.DNI, Me.Paciente,
                                            Me.tipoActo, Me.Numicu, Me.BarCodeDet, Me.incidencia, Me.Eliminada, Me.Indizada, Me.primera, Me.ContenidoEn, Me.ErrorEnvio, Me.nombre, Me.apellido1, Me.apellido2, Me.SIP})

            Me.ListView1.FullRowSelect = True
            Me.ListView1.UseCompatibleStateImageBehavior = False
            Me.ListView1.View = System.Windows.Forms.View.Details

            Me.idDocumento.Text = "idDocumento"
            Me.idDocumento.Width = 0

            Me.idLote.Text = "Lote"
            Me.idLote.Width = 0

            Me.Pagina.Text = "Pagina"
            Me.Pagina.Width = 30

            Me.nomArchivoTIF.Text = "Nombre Archivo"
            Me.nomArchivoTIF.Width = 0

            Me.Numhistoria.Text = "NHC"
            Me.Numhistoria.Width = 60

            Me.FechaDoc.Text = "F. Doc"
            Me.FechaDoc.Width = 100

            Me.fechaInicio.Text = "F. Ini"
            Me.fechaInicio.Width = 0

            Me.fechaTermino.Text = "F. Fin"
            Me.fechaTermino.Width = 0

            Me.Serv.Text = "Servicio"
            Me.Serv.Width = 40

            Me.tipoDocumento.Text = "Documento"
            Me.tipoDocumento.Width = 40

            Me.CIP.Text = "CIP"
            Me.CIP.Width = 0

            Me.DNI.Text = "DNI"
            Me.DNI.Width = 0

            Me.Paciente.Text = "Paciente"
            Me.Paciente.Width = 170

            Me.tipoActo.Text = "Acto"
            Me.tipoActo.Width = 30

            Me.Numicu.Text = "Codigo acto"
            Me.Numicu.Width = 120

            Me.BarCodeDet.Text = "BarCodeDet"
            Me.BarCodeDet.Width = 0

            Me.incidencia.Text = "Incidencia"
            Me.incidencia.Width = 0

            Me.Eliminada.Text = "Eliminada"
            Me.Eliminada.Width = 0

            Me.Indizada.Text = "Indizado"
            Me.Indizada.Width = 0

            Me.primera.Text = "primera"
            Me.primera.Width = 0

            Me.ContenidoEn.Text = "ContenidoEn"
            Me.ContenidoEn.Width = 50

            Me.ErrorEnvio.Text = "ErrorEnvio"
            Me.ErrorEnvio.Width = 50

            Me.nombre.Text = "nombre"
            Me.nombre.Width = 0

            Me.apellido1.Text = "apellido1"
            Me.apellido1.Width = 0

            Me.apellido2.Text = "apellido2"
            Me.apellido2.Width = 0

            Me.SIP.Text = "sip"
            Me.SIP.Width = 0

            Dim cont As Integer = 0
            Dim cont2 As Integer = 0
            Dim cont3 As Integer = 0
            Dim fila As ListViewItem
            Dim LoteAProcesar As String = ""

            'For Each reg As DataRow In datos.ObtenerListadoParaValorParametro("documentos", "iddocumento,idlote,pagina,nomarchivotif,numhistoria,numicu,tipodocumento,codserviciopaed,tipoepisodiopaed,fechainicio,fechaTermino,isnull(eliminada,0) as eliminada, isnull(indizado,0) as indizado,isnull(incidencia,0) as incidencia,servicio,icuorion,fechadocumento", "idlote", frmContenedorMDI.oLote._idlote, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto, , , "pagina").Rows
            'For Each reg As DataRow In datos.ObtenerListadoParaValorParametro("documentos d, FIP f", "iddocumento,d.idlote,pagina,nomarchivotif,d.numhistoria,numicu,tipodocumento,codserviciopaed,tipoepisodiopaed,fechainicio,fechaTermino,isnull(eliminada,0) as eliminada, isnull(indizado,0) as indizado,isnull(incidencia,0) as incidencia,d.servicio,icuorion,fechadocumento, f.nombre, f.apellido1, f.apellido2", "d.numhistoria =  f.numHistoria and d.idlote", frmContenedorMDI.oLote._idlote, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto, , , "pagina").Rows
            ''For Each reg As DataRow In datos.ObtenerListadoParaValorParametro("documentos d left join fip f on d.NumHistoria = f.numhistoria ", "iddocumento,d.idlote,pagina,nomarchivotif,d.numhistoria,numicu,tipodocumento,codserviciopaed,fechainicio,fechaTermino,isnull(eliminada,0) as eliminada, isnull(indizado,0) as indizado,isnull(incidencia,0) as incidencia,isnull(BarCodeDet,0) as BarCodeDet, d.servicio,fechadocumento, tipoActo, f.nombre, f.apellido1, f.apellido2, f.CIP, f.DNI", " d.idlote", frmContenedorMDI.oLote._idlote, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto, , , "pagina").Rows

            lsSql = "SELECT iddocumento,d.idlote,pagina,nomarchivotif,d.numhistoria,numicu,tipodocumento,codserviciopaed,fechainicio,fechaTermino,isnull(eliminada,0) as eliminada, isnull(indizado,0) as indizado,isnull(incidencia,0) as incidencia,isnull(BarCodeDet,0) as BarCodeDet, isnull(primera,0) as primera,  d.servicio,fechadocumento, tipoActo, f.nombre, f.apellido1, f.apellido2, f.CIP, f.DNI, f.SIP, ContenidoEn, ErrorDevuelto" &
                            " FROM documentos d left join fip f on d.CIP = f.CIP " &
                    " WHERE d.idLote=" & frmContenedorMDI.oLote._idlote &
                    " ORDER BY Pagina"
            '''" AND (BarCodeDet = 0 or BarCodeDet is null) " &
            data = datos.ejecutarSQLDirectaTable(lsSql, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto)
            For Each reg As DataRow In data.Rows
                fila = New ListViewItem(reg.Item("idDocumento").ToString)

                With fila
                    fila.SubItems.Add(reg.Item("idLote").ToString).Name = "idLote"
                    fila.SubItems.Add(reg.Item("pagina").ToString).Name = "pagina"
                    fila.SubItems.Add(reg.Item("nomArchivoTIF").ToString).Name = "nomArchivoTIF"
                    fila.SubItems.Add(reg.Item("numHistoria").ToString).Name = "numHistoria"
                    If IsDBNull(reg.Item("fechadocumento")) Then
                        fila.SubItems.Add("").Name = "fechadocumento"
                    Else
                        fila.SubItems.Add(Format(reg.Item("fechadocumento"), "dd/MM/yyyy")).Name = "fechadocumento"
                    End If
                    If IsDBNull(reg.Item("fechainicio")) Then
                        fila.SubItems.Add("").Name = "fechainicio"
                    Else
                        fila.SubItems.Add(Format(reg.Item("fechainicio"), "dd/MM/yyyy")).Name = "fechainicio"
                    End If
                    ''fila.SubItems.Add(reg.Item("fechainicio").ToString).Name = "fechainicio"
                    If IsDBNull(reg.Item("fechaTermino")) Then
                        fila.SubItems.Add("").Name = "fechaTermino"
                    Else
                        fila.SubItems.Add(Format(reg.Item("fechaTermino"), "dd/MM/yyyy")).Name = "fechaTermino"
                    End If
                    'fila.SubItems.Add(reg.Item("fechaTermino").ToString).Name = "fechaTermino"
                    fila.SubItems.Add(reg.Item("codservicioPAED").ToString).Name = "codservicioPAED"
                    fila.SubItems.Add(reg.Item("TipoDocumento").ToString).Name = "TipoDocumento"
                    fila.SubItems.Add(reg.Item("CIP").ToString).Name = "CIP"
                    fila.SubItems.Add(reg.Item("DNI").ToString).Name = "DNI"
                    fila.SubItems.Add(reg.Item("apellido1").ToString.Trim & " " & reg.Item("apellido2").ToString.Trim & ", " & reg.Item("nombre").ToString).Name = "paciente"
                    fila.SubItems.Add(reg.Item("tipoActo").ToString).Name = "tipoActo"
                    fila.SubItems.Add(reg.Item("numicu").ToString).Name = "codigoActo"
                    fila.SubItems.Add(reg.Item("BarCodeDet").ToString).Name = "BarCodeDet"
                    fila.SubItems.Add(reg.Item("Incidencia").ToString).Name = "Incidencia"
                    fila.SubItems.Add(reg.Item("eliminada").ToString).Name = "Eliminada"
                    fila.SubItems.Add(reg.Item("Indizado").ToString).Name = "Indizada"
                    fila.SubItems.Add(reg.Item("Primera").ToString).Name = "primera"
                    fila.SubItems.Add(reg.Item("ContenidoEn").ToString).Name = "ContenidoEn"
                    fila.SubItems.Add(reg.Item("ErrorDevuelto").ToString).Name = "ErrorEnvio"
                    fila.SubItems.Add(reg.Item("nombre").ToString).Name = "nombre"
                    fila.SubItems.Add(reg.Item("apellido1").ToString).Name = "apellido1"
                    fila.SubItems.Add(reg.Item("apellido2").ToString).Name = "apellido2"
                    fila.SubItems.Add(reg.Item("sip").ToString).Name = "sip"

                End With

                If reg.Item("Indizado") = 1 Then
                    Me.ListView1.Items.Add(fila).BackColor = Drawing.Color.LightBlue
                    cont += 1
                Else
                    Me.ListView1.Items.Add(fila).BackColor = Drawing.Color.GreenYellow
                    If cont2 = 0 And reg.Item("Eliminada") <> 1 Then
                        cont2 = cont3
                        cont2 += 1
                    End If
                End If

                '######### JGARIJO 11/11/2019 ###########
                'Almacenamos en la var global el valor del lote que se va a procesar
                LoteAProcesar = reg.Item("idLote").ToString
                '########################################

                If reg.Item("Incidencia") = 1 Then fila.BackColor = Drawing.Color.Red
                If reg.Item("Eliminada") = 1 Then fila.BackColor = Color.DarkBlue

                If Not IsDBNull(reg.Item("BarCodeDet")) Then
                    If reg.Item("BarCodeDet") = 1 Then
                        fila.ForeColor = Drawing.Color.DarkRed
                        fila.Font = New Font(ListView1.Font, FontStyle.Bold)
                    End If
                End If

                cont3 += 1
            Next

            MaxRegistros = cont

            '######### JGARIJO 11/11/2019 ###########
            If LoteAProcesar <> "" Then
                'Realizamos la select a la tabla de "trazabilidadlotes" para saber si tiene valor el campo FechaFinFinalizado.
                'Si es que sí, significa que es un lote que se ha tirado para atras desde Administrar. Si no tiene fecha, no ha sigo cerrado por lo que no es necesario 
                'entrar en modo de edicion para modificar valores

                Dim CadConsultaSQL As String = ""

                CadConsultaSQL = "Select FechaFinAtributado from trazabilidadLotes where idLote = " & LoteAProcesar
                Dim resultado As DataRow = datos.ejecutarSQLDirectaDataRow(CadConsultaSQL, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto)

                If resultado(0).ToString.Trim() <> "" And resultado(0).ToString.Trim() <> "NULL" Then
                    'La Fecha ya ha sido rellenada
                    LoteYaCerrado = True
                Else
                    LoteYaCerrado = False
                End If
            Else
                LoteYaCerrado = False
            End If
            '########################################

            'Me.indice = cont
            Me.indice = cont2 - 1 'inicializmos el indice de la aplicacion 
            'Me.CtrlIndizacionEpidemiologia1.lblpagina.Text = indice + 1
            Me.CtrlIndizacionEpidemiologia1.lblpagina.Text = indice + 1

            Dim rutaImagen As String = ""

            If indice > 0 Then
                'rutaImagen = Me.rutaImagenes & "\" & Me.ListView1.Items(indice - 1).SubItems("nomArchivoTIF").Text
                rutaImagen = Me.rutaImagenes & "\" & Me.ListView1.Items(indice).SubItems("nomArchivoTIF").Text
                'rutaImagen = rutaImagen.Replace("\\172.21.100.190", "c:")
            Else
                Me.CtrlIndizacionEpidemiologia1.lblpagina.Text = 1
                If indice < 0 Then

                    rutaImagen = Me.rutaImagenes & "\" & Me.ListView1.Items(0).SubItems("nomArchivoTIF").Text
                    'rutaImagen = "C:\gedsa\Digitalizacion\ProyectosDigi\7002\DIGI\700203168\Imagen\3168" & "\" & Me.ListView1.Items(indice).SubItems("nomArchivoTIF").Text
                    'rutaImagen = rutaImagen.Replace("\\172.21.100.190", "c:")

                Else
                    rutaImagen = Me.rutaImagenes & "\" & Me.ListView1.Items(indice).SubItems("nomArchivoTIF").Text
                    'rutaImagen = "C:\gedsa\Digitalizacion\ProyectosDigi\7002\DIGI\700203168\Imagen\3168" & "\" & Me.ListView1.Items(indice).SubItems("nomArchivoTIF").Text
                    'rutaImagen = rutaImagen.Replace("\\172.21.100.190", "c:")

                End If

            End If

            'Se posiciona en el listview y lanza el evento al cambiar de linea del listveiw
            'Me.ListView1.Items(indice).Selected = True
            'Me.ListView1.Focus()
            'Me.ListView1.Select()
            'Me.ListView1.Items(indice).Focused = True
            'Me.ListView1.EnsureVisible(indice)

            Me.mostrarImagen(rutaImagen)
            Me.cargarDatosImagenActual()

        Catch ex As Exception
            MsgBox(Err.Description)
            MessageBox.Show("Error al inicializar el listview")
        End Try
    End Sub


    ''' <summary>
    ''' M?todo que permite actualizar los datos del listview con los cambios realizados en la
    ''' tabla documentos dependiendo de los datos de indizacion
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub actualizarDatosListView()
        Dim IndiceActual As Integer = 0

        Dim contador As Integer = 0

        Try

            'Me.ListView1.Items.Clear()

            Dim fila As ListViewItem
            IndiceActual = Me.indice

            'For Each reg As DataRow In datos.ObtenerListadoIndizacion("documentos", "iddocumento,idlote,pagina,nomarchivotif,isnull(tipodocumento,0) as tipodocumento,numicu,codserviciopaed,tipoepisodiopaed,numhistoria,fechainicio,fechaTermino,isnull(eliminada,0) as eliminada, isnull(indizado,0) as indizado,isnull(incidencia,0) as incidencia,servicio,icuorion, fechadocumento", "idlote", frmContenedorMDI.oLote._idlote, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto, "Pagina").Rows

            '    fila = New ListViewItem(reg.Item("idDocumento").ToString)

            '    With fila
            '        fila.SubItems.Add(reg.Item("idLote").ToString).Name = "idLote"
            '        fila.SubItems.Add(reg.Item("pagina").ToString).Name = "pagina"
            '        fila.SubItems.Add(reg.Item("nomArchivoTIF").ToString).Name = "nomArchivoTIF"
            '        fila.SubItems.Add(reg.Item("numHistoria").ToString).Name = "numHistoria"
            '        fila.SubItems.Add(reg.Item("fechainicio").ToString).Name = "fechainicio"
            '        fila.SubItems.Add(reg.Item("fechaTermino").ToString).Name = "fechaTermino"
            '        fila.SubItems.Add(reg.Item("codservicioPAED").ToString).Name = "codservicioPAED"
            '        fila.SubItems.Add(reg.Item("TipoEpisodioPAED").ToString).Name = "TipoEpisodioPAED"
            '        fila.SubItems.Add(reg.Item("Numicu").ToString).Name = "Numicu"
            '        fila.SubItems.Add(reg.Item("tipodocumento").ToString).Name = "tipodocumento"
            '        fila.SubItems.Add(reg.Item("Incidencia").ToString).Name = "Incidencia"
            '        fila.SubItems.Add(reg.Item("indizado").ToString).Name = "Indizado"
            '        fila.SubItems.Add(reg.Item("eliminada").ToString).Name = "Eliminada"
            '        fila.SubItems.Add(reg.Item("servicio").ToString).Name = "servicio"
            '        fila.SubItems.Add(reg.Item("icuorion").ToString).Name = "orion"
            '        fila.SubItems.Add(reg.Item("fechadocumento").ToString).Name = "fechadocumento"
            '    End With



            '    If reg.Item("Indizado") = 1 Then
            '        Me.ListView1.Items.Add(fila).BackColor = Drawing.Color.LightBlue
            '    Else
            '        Me.ListView1.Items.Add(fila).BackColor = Drawing.Color.GreenYellow
            '    End If

            '    If reg.Item("Incidencia") = 1 Then fila.BackColor = Drawing.Color.Red
            '    If reg.Item("Eliminada") = 1 Then fila.BackColor = Color.DarkBlue
            'Next

            Dim i As Integer = 0

            Dim prueba0 As String = ""
            Dim prueba1 As String = ""
            Dim prueba2 As String = ""
            Dim prueba3 As String = ""
            Dim prueba4 As String = ""
            Dim prueba5 As String = ""
            Dim prueba6 As String = ""
            Dim prueba7 As String = ""
            Dim prueba8 As String = ""
            Dim prueba9 As String = ""
            Dim prueba10 As String = ""
            Dim prueba11 As String = ""
            Dim prueba12 As String = ""
            Dim prueba13 As String = ""
            Dim prueba14 As String = ""
            Dim prueba15 As String = ""
            Dim prueba16 As String = ""
            Dim prueba17 As String = ""
            Dim prueba18 As String = ""
            Dim prueba19 As String = ""
            Dim prueba20 As String = ""


            For i = 0 To ListView1.Items.Count - 1

                prueba0 = ListView1.Items(i).SubItems("idLote").Text
                prueba1 = ListView1.Items(i).SubItems("pagina").Text
                prueba2 = ListView1.Items(i).SubItems("nomArchivoTIF").Text
                prueba3 = ListView1.Items(i).SubItems("numHistoria").Text
                prueba4 = ListView1.Items(i).SubItems("tipoDocumento").Text
                prueba5 = ListView1.Items(i).SubItems("fechainicio").Text
                prueba6 = ListView1.Items(i).SubItems("fechaTermino").Text
                prueba7 = ListView1.Items(i).SubItems("codservicioPAED").Text
                'prueba8 = ListView1.Items(i).SubItems("TipoEpisodioPAED").Text
                prueba9 = ListView1.Items(i).SubItems("codigoActo").Text
                prueba10 = ListView1.Items(i).SubItems("Incidencia").Text
                prueba12 = ListView1.Items(i).SubItems("Indizada").Text
                prueba13 = ListView1.Items(i).SubItems("eliminada").Text
                prueba14 = ListView1.Items(i).SubItems("paciente").Text
                prueba15 = ListView1.Items(i).SubItems("BarCodeDet").Text
                ''prueba16 = ListView1.Items(i).SubItems("apellido2").Text
                prueba17 = ListView1.Items(i).SubItems("codservicioPAED").Text
                prueba18 = ListView1.Items(i).SubItems("CIP").Text
                prueba19 = ListView1.Items(i).SubItems("DNI").Text
                prueba20 = ListView1.Items(i).SubItems("tipoActo").Text

                If prueba12 = 1 Then
                    'Me.ListView1.Items.Add(i).BackColor = Drawing.Color.LightBlue
                    Me.ListView1.Items(i).BackColor = Drawing.Color.LightBlue
                    If prueba15 <> 1 Then
                        Me.ListView1.Items(i).ForeColor = Drawing.Color.Black
                    End If
                Else
                    'Me.ListView1.Items.Add(i).BackColor = Drawing.Color.GreenYellow
                    Me.ListView1.Items(i).BackColor = Drawing.Color.GreenYellow
                    If prueba15 <> 1 Then
                        Me.ListView1.Items(i).ForeColor = Drawing.Color.Black
                    End If
                End If
                'If prueba10 = 1 Then Me.ListView1.Items.Add(i).BackColor = Drawing.Color.Red
                'If prueba13 = 1 Then Me.ListView1.Items.Add(i).BackColor = Color.DarkBlue

                If prueba10 = 1 Then Me.ListView1.Items(i).BackColor = Drawing.Color.Red
                If prueba13 = 1 Then
                    Me.ListView1.Items(i).BackColor = Color.DarkBlue
                    Me.ListView1.Items(i).ForeColor = Drawing.Color.White
                End If


            Next

            If IndiceActual >= Me.ListView1.Items.Count - 1 Then
                Me.ListView1.Items(Me.ListView1.Items.Count - 1).Selected = True
            Else
                Me.ListView1.Items(IndiceActual).Selected = True
            End If

            ''Me.ListView1.SelectedItems.Clear()
            'If Me.indice < Me.ListView1.Items.Count Then 'si estamos en el ultimo registro no lo vamos a actulizar la siguiente posicion
            '    Me.ListView1.Items(Me.indice).Selected = True
            '    Me.ListView1.Items(Me.indice).EnsureVisible()
            'Else
            '    Me.ListView1.Items(Me.indice - 1).Selected = True
            '    Me.ListView1.Items(Me.indice - 1).EnsureVisible()
            'End If

        Catch ex As Exception
            MessageBox.Show("Error al actualizar el listado")
        End Try
    End Sub



    ''' <summary>
    ''' M?todo que nos permite acceder a la siguiente p?gina del listado
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' 
    Public Sub bajarAbajo()
        Try
            ' ''LibreriaCadenaProduccion.TXT.clsFormato.escribirEnLog("Inicio bajar abajo.")

            If Me.guardarRegistro() Then
                'Ahora marcamos el ultimo registro del listview
                Me.indice += 1

                'Me.ListView1.Items(Me.indice).Selected = True

                If indice > (Me.ListView1.Items.Count - 1) Then
                    Me.indice = (Me.ListView1.Items.Count - 1)
                    Me.CtrlIndizacionEpidemiologia1.lblpagina.Text = Me.ListView1.Items.Count
                    'actualizarDatosListView()
                    MessageBox.Show("Fin del lote")
                    Exit Sub
                Else
                    Me.CtrlIndizacionEpidemiologia1.lblpagina.Text = indice + 1
                End If

                If Me.ListView1.Items(Me.ListView1.Items.Count - 1).Selected And Me.CtrlIndizacionEpidemiologia1.GetDocumentoActual.SubItems("Indizada").Text = 1 And ModoEdicion = True Then
                    ModoEdicion = False
                    Me.CtrlIndizacionEpidemiologia1.lblModoEdicion.Visible = False
                    CtrlIndizacionEpidemiologia1.Button1.Visible = True
                    Me.ListView1.Enabled = True
                End If

                If Me.CtrlIndizacionEpidemiologia1.lblpagina.Text > Me.ListView1.Items.Count Then
                    Me.CtrlIndizacionEpidemiologia1.lblpagina.Text = Me.ListView1.Items.Count
                End If

                Me.actualizarDatosListView() 'esto solo actualiza la consulta 

                Dim i As Integer
                Dim contador As Integer = 0
                For i = 0 To Me.ListView1.Items.Count - 1
                    If Me.ListView1.Items(i).SubItems("Indizada").Text = "1" Then
                        contador = contador + 1
                    End If
                Next

                If contador >= Me.ListView1.Items.Count And LoteYaCerrado = False Then
                    If Me.ListView1.Items(Me.ListView1.Items.Count - 1).Selected Then
                        MsgBox("Fin de Lote")
                        Exit Sub
                    End If
                End If

                'If Me.ListView1.Items.Count >= indice Then
                'If (Me.ListView1.Items.Count - 1) = indice Then
                'MessageBox.Show("Fin del lote")
                'Me.indice = Me.indice - 1 'dejamos el indice en la ultima posicion
                'Me.CtrlIndizacionEpidemiologia1.lblpagina.Text = indice + 1
                'End If

                'Else

                'si esta eliminada incrementas guardas para marcar que esta indizada 
                'incrementas indices y cargas los datos de la siguiente
                If Me.ListView1.Items(Me.indice).SubItems("Eliminada").Text = 1 Then
                    bajarAbajo()
                Else
                    Dim rutaImagen As String = Me.rutaImagenes & "\" & Me.ListView1.Items(Me.indice).SubItems("nomArchivoTIF").Text

                    'Dim rutaImagen As String = Me.rutaImagenes & "\" & Me.ListView1.Items(Me.indice).SubItems("nomArchivoTIF").Text
                    '################# JGARIJO ###################
                    'rutaImagen = rutaImagen.Replace("\\172.21.100.190", "C:")


                    If UCase(IMGeditPrincipal.Image) <> UCase(rutaImagen) Then
                        Me.mostrarImagen(rutaImagen)
                    End If

                    Me.cargarDatosImagenActual()
                End If

                'End If
            End If

            ' ''LibreriaCadenaProduccion.TXT.clsFormato.escribirEnLog("Fin bajar abajo.")

        Catch ex As Exception
            MessageBox.Show("Ocurrio un error al pasar a la siguiente pagina")
        End Try
    End Sub

    Public Sub bajarAbajo_OLD20191126()
        Try
            If Me.guardarRegistro() Then
                'Ahora marcamos el ultimo registro del listview

                Me.indice += 1

                Me.CtrlIndizacionEpidemiologia1.lblpagina.Text = indice + 1

                Me.actualizarDatosListView() 'esto solo actualiza la consulta 


                If Me.ListView1.Items.Count = indice Then
                    Me.indice = Me.indice - 1 'dejamos el indice en la ultima posicion
                    Me.CtrlIndizacionEpidemiologia1.lblpagina.Text = indice + 1
                    MessageBox.Show("Fin del lote")

                Else

                    'si esta eliminada incrementas guardas para marcar que esta indizada 
                    'incrementas indices y cargas los datos de la siguiente
                    If Me.ListView1.Items(Me.indice).SubItems("Eliminada").Text = 1 Then
                        'bajarAbajo()
                        Do While Me.ListView1.Items(Me.indice).SubItems("Eliminada").Text = 1
                            Dim sql As String = "UPDATE documentos SET  indizado = 1 where iddocumento='" & Me.ListView1.Items(Me.indice).SubItems(0).Text & "'"
                            Debug.Print(sql)
                            Me.indice += 1
                            Me.CtrlIndizacionEpidemiologia1.lblpagina.Text = indice + 1
                            Dim filasAfectatadas As Integer = 0
                            Debug.Print(sql)
                            If Not datos.ejecutaSQLEjecucion(sql, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto, filasAfectatadas) Then
                            Else
                            End If
                            If Me.ListView1.Items.Count = indice Then
                                Me.indice = Me.indice - 1 'dejamos el indice en la ultima posicion
                                Me.CtrlIndizacionEpidemiologia1.lblpagina.Text = indice + 1
                                MessageBox.Show("Fin del lote")
                                Exit Sub
                            End If
                        Loop
                        Me.actualizarDatosListView() 'esto solo actualiza la consulta 
                        Dim rutaImagen As String = Me.rutaImagenes & "\" & Me.ListView1.Items(Me.indice).SubItems("nomArchivoTIF").Text
                        Me.mostrarImagen(rutaImagen)
                        Me.cargarDatosImagenActual()
                        Me.CtrlIndizacionEpidemiologia1.mTxtFechaDia.SelectAll()
                    Else
                        Dim rutaImagen As String = Me.rutaImagenes & "\" & Me.ListView1.Items(Me.indice).SubItems("nomArchivoTIF").Text
                        Me.mostrarImagen(rutaImagen)
                        Me.cargarDatosImagenActual()
                    End If

                End If
            End If



        Catch ex As Exception
            MessageBox.Show("Ocurrio un error al pasar a la siguiente página")
        End Try
    End Sub

    Public Sub subirArriba()
        'If Me.guardarRegistro() Then
        'te guardas el indice por el que vas 

        Dim mensaje As String = ""

        Try
            mensaje = "+++++++++++++++++"
            mensaje = mensaje & vbLf & "    Inicio subirArriba."

            'cuando se actualiza el listado el ulitimo imtem que se queda seleccionado es el actual
            'lo tenemos tb en el caso de que sea 
            If Me.ListView1.SelectedItems.Count > 0 Then
                Me.idDocumentoActual = Me.ListView1.SelectedItems(0).Index
            Else
                Me.idDocumentoActual = indice
            End If

            If Me.idDocumentoActual = 0 Then
                MessageBox.Show("Estas en el primer documento del lote.")
                Exit Sub
            End If
            'Ahora marcamos el ultimo registro del listview
            'actualizar el list view con los ultimos datos que metas con la funcion 
            'guardar registro 

            mensaje = mensaje & vbLf & "    Antes de actualizar listview. Inidice= " & indice

            Me.actualizarDatosListView()

            mensaje = mensaje & vbLf & "    Después de actualizar listview. Inidice= " & indice

            'reduces el indice de los listview  puesto que vas al registro anterior 

            Me.idDocumentoActual -= 1
            Me.indice = idDocumentoActual
            Me.CtrlIndizacionEpidemiologia1.lblpagina.Text = indice + 1

            mensaje = mensaje & vbLf & "    Inidice= " & indice & ", página= " & Me.CtrlIndizacionEpidemiologia1.lblpagina.Text

            'If Me.ListView1.Items(Me.indice).SubItems("Eliminada").Text = 1 Then
            'subirArriba()
            'Else
            Me.ListView1.Items(Me.idDocumentoActual).Selected = True
            Me.ListView1.Items(Me.idDocumentoActual).EnsureVisible()

            Dim rutaImagen As String = Me.rutaImagenes & "\" & Me.ListView1.SelectedItems(0).SubItems("nomArchivoTIF").Text

            '############### jgarijo ###############
            'rutaImagen = rutaImagen.Replace("\\172.21.100.190", "c:")

            If UCase(IMGeditPrincipal.Image) <> UCase(rutaImagen) Then
                Me.mostrarImagen(rutaImagen)
            End If

            Me.cargarDatosImagenActual()
            'End If

            CtrlIndizacionEpidemiologia1.txtCodigoDoc.Focus()

            mensaje = mensaje & vbLf & "    Fin subir."
            mensaje = mensaje & vbLf & "+++++++++++++++++"

        Catch ex As Exception
            ' ''LibreriaCadenaProduccion.TXT.clsFormato.escribirEnLog("ERROR en subirArriba a las: " & Now & ". ERROR: " & ex.Message)
            ' ''LibreriaCadenaProduccion.TXT.clsFormato.escribirEnLog(mensaje)
            MessageBox.Show("Ocurrio un error al pasar a la anterior página")
        End Try
    End Sub

    Public Sub subirArriba_OLD20191126()
        'If Me.guardarRegistro() Then
        'te guardas el indice por el que vas 


        'cuando se actualiza el listado el ulitimo imtem que se queda seleccionado es el actual
        'lo tenemos tb en el caso de que sea 
        Me.idDocumentoActual = Me.ListView1.SelectedItems(0).Index

        If Me.idDocumentoActual = 0 Then
            MessageBox.Show("Estas en el primer documento del lote no puedes consult")
            Exit Sub
        End If
        'Ahora marcamos el ultimo registro del listview
        'actualizar el list view con los ultimos datos que metas con la funcion 
        'guardar registro 
        Me.actualizarDatosListView()
        'reduces el indice de los listview  puesto que vas al registro anterior 

        Me.idDocumentoActual -= 1
        Me.indice = idDocumentoActual
        Me.CtrlIndizacionEpidemiologia1.lblpagina.Text = indice + 1

        'If Me.ListView1.Items(Me.indice).SubItems("Eliminada").Text = 1 Then
        'subirArriba()
        'Else
        Me.ListView1.Items(Me.idDocumentoActual).Selected = True
        Me.ListView1.Items(Me.idDocumentoActual).EnsureVisible()

        Dim rutaImagen As String = Me.rutaImagenes & "\" & Me.ListView1.SelectedItems(0).SubItems("nomArchivoTIF").Text
        Me.mostrarImagen(rutaImagen)
        Me.cargarDatosImagenActual()
        'Me.CtrlIndizacionEpidemiologia1.mTxtFechaDia.Text = Me.CtrlIndizacionEpidemiologia1.mtxtFEchainicio.Text
        'End If
    End Sub


    ''' <summary>
    ''' M?todo que guarda cada registro como indizado si es correcto dentro de la tabla documentos
    ''' </summary>
    ''' <remarks></remarks>
    Public Function guardarRegistro() As Boolean
        Dim set_sql As String = ""
        Dim indizacionCorrecta As Boolean = True
        Dim mensaje As String = ""
        Dim filasAfectatadas As Integer = 0

        'LibreriaCadenaProduccion.TXT.clsFormato.escribirEnLog("Inicio guardarRegistro.")

        Try
            If Me.indice > Me.ListView1.Items.Count - 1 Then
                Me.indice = Me.ListView1.Items.Count - 1
            End If

            If Me.ListView1.Items(Me.indice).SubItems("Eliminada").Text = 1 Then
                'Dim sql As String = "UPDATE documentos SET  indizado = 1 where iddocumento='" & Me.ListView1.Items(Me.indice).SubItems(0).Text & "'"
                'Debug.Print(sql)

                'If Not datos.ejecutaSQLEjecucion(sql, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto, filasAfectatadas) Then

                '    If filasAfectatadas = -2146232060 Then
                '        MessageBox.Show("Algunos de los campos introducidos no son correctos.")
                '    End If
                '    Return False
                'Else
                '    Return True
                'End If

            End If

            If Not comprobarDatosCumplimentados(mensaje) Then
                MessageBox.Show(mensaje)
                Return False
            Else

                'Si no coincide el n? de historia del textbox con el del listview
                If Me.CtrlIndizacionEpidemiologia1.txtNumHistoria.Text <> Me.ListView1.Items(Me.indice).SubItems("Numhistoria").Text Then
                    set_sql &= " NumHistoria='" & Me.CtrlIndizacionEpidemiologia1.txtNumHistoria.Text & "'"

                End If

                If Me.CtrlIndizacionEpidemiologia1.txtServicio.Text <> Me.ListView1.Items(Me.indice).SubItems("codserviciopaed").Text Then
                    If (set_sql <> "") Then
                        set_sql &= ", "
                    End If
                    set_sql &= " codserviciopaed ='" & Me.CtrlIndizacionEpidemiologia1.txtServicio.Text & "'"
                End If

                If Me.CtrlIndizacionEpidemiologia1.mtxtFEchainicio.Text <> Me.ListView1.Items(Me.indice).SubItems("fechainicio").Text Then
                    If (set_sql <> "") Then
                        set_sql &= ", "
                    End If
                    set_sql &= " fechainicio='" & Me.CtrlIndizacionEpidemiologia1.mtxtFEchainicio.Text & "'"
                End If

                If Me.CtrlIndizacionEpidemiologia1.mtxtfechaTerminio.Text <> Me.ListView1.Items(Me.indice).SubItems("fechaTermino").Text Then
                    If (set_sql <> "") Then
                        set_sql &= ", "
                    End If
                    set_sql &= " fechaTermino='" & Me.CtrlIndizacionEpidemiologia1.mtxtfechaTerminio.Text & "'"
                End If

                If Val(Me.CtrlIndizacionEpidemiologia1.txtCodigoDoc.Text) <> Val(Me.ListView1.Items(Me.indice).SubItems("tipodocumento").Text) Then
                    If (set_sql <> "") Then
                        set_sql &= ", "
                    End If
                    set_sql &= " tipodocumento ='" & Val(Me.CtrlIndizacionEpidemiologia1.txtCodigoDoc.Text) & "'"
                End If

                If Me.CtrlIndizacionEpidemiologia1.mTxtFechaDia.Text <> Me.ListView1.Items(Me.indice).SubItems("fechadocumento").Text Then
                    If (set_sql <> "") Then
                        set_sql &= ", "
                    End If
                    set_sql &= " fechadocumento='" & Me.CtrlIndizacionEpidemiologia1.mTxtFechaDia.Text & "'"
                End If

                If (set_sql <> "") Then
                    set_sql &= ", "
                End If

                'Dim sql As String = "UPDATE documentos SET " & set_sql & " indizado = 1 where iddocumento='" & Me.ListView1.Items(Me.indice).SubItems(0).Text & "'"
                'Debug.Print(sql)

                'If Not datos.ejecutaSQLEjecucion(sql, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto, filasAfectatadas) Then

                '    If filasAfectatadas = -2146232060 Then
                '        MessageBox.Show("Algunos de los campos introducidos no son correctos.")
                '    End If
                '    Return False
                'End If

                Me.CtrlIndizacionEpidemiologia1.copiarDatos()

                Me.ListView1.Items(Me.indice).SubItems("fechadocumento").Text = Me.CtrlIndizacionEpidemiologia1.mTxtFechaDia.Text
                Me.ListView1.Items(Me.indice).SubItems("Numhistoria").Text = Me.CtrlIndizacionEpidemiologia1.txtNumHistoria.Text
                Me.ListView1.Items(Me.indice).SubItems("DNI").Text = Me.CtrlIndizacionEpidemiologia1.txtDNI.Text
                Me.ListView1.Items(Me.indice).SubItems("CIP").Text = Me.CtrlIndizacionEpidemiologia1.txtCIP.Text
                Me.ListView1.Items(Me.indice).SubItems("Paciente").Text = Me.CtrlIndizacionEpidemiologia1.txtPaciente.Text
                If Me.CtrlIndizacionEpidemiologia1.cmbTipoActo.Text.ToString.Trim <> "" Then
                    Me.ListView1.Items(Me.indice).SubItems("TipoActo").Text = Me.CtrlIndizacionEpidemiologia1.cmbTipoActo.Text.Split(" - ")(0).ToString.Trim
                Else
                    Me.ListView1.Items(Me.indice).SubItems("TipoActo").Text = ""
                End If
                Me.ListView1.Items(Me.indice).SubItems("codigoActo").Text = Me.CtrlIndizacionEpidemiologia1.txtNumicu.Text
                Me.ListView1.Items(Me.indice).SubItems("fechainicio").Text = Me.CtrlIndizacionEpidemiologia1.mtxtFEchainicio.Text
                Me.ListView1.Items(Me.indice).SubItems("fechaTermino").Text = Me.CtrlIndizacionEpidemiologia1.mtxtfechaTerminio.Text
                Me.ListView1.Items(Me.indice).SubItems("tipodocumento").Text = Me.CtrlIndizacionEpidemiologia1.txtCodigoDoc.Text
                Me.ListView1.Items(Me.indice).SubItems("codserviciopaed").Text = Me.CtrlIndizacionEpidemiologia1.txtServicio.Text
                Me.ListView1.Items(Me.indice).SubItems("Indizada").Text = 1

                If Me.ListView1.Items(Me.indice).SubItems("ContenidoEn").Text.ToString.Trim <> "" Then
                    If listaContenidoEn.Contains(Me.ListView1.Items(Me.indice).SubItems("ContenidoEn").Text.ToString.Trim) = False Then
                        listaContenidoEn = listaContenidoEn & ", '" & Me.ListView1.Items(Me.indice).SubItems("ContenidoEn").Text.ToString.Trim & "'"
                    End If
                End If

                Me.ListView1.Items(Me.indice).SubItems("ContenidoEn").Text = ""
                Me.ListView1.Items(Me.indice).SubItems("ErrorEnvio").Text = ""

            End If

            'LibreriaCadenaProduccion.TXT.clsFormato.escribirEnLog("Fin guardarRegistro.")

            Return True

        Catch ex As Exception
            MessageBox.Show("Error al guardar los datos de indizacion del documento")
            Return False
        End Try
    End Function


    Public Function comprobarDatosCumplimentados(ByRef mensaje As String) As Boolean
        Try


            Dim resultado As Boolean = True
            mensaje = ""


            If Me.CtrlIndizacionEpidemiologia1.txtNumicu.Text = "" Then
                mensaje = " Episodio "
                resultado = False
            End If


            If Trim(Replace(Me.CtrlIndizacionEpidemiologia1.mtxtFEchainicio.Text, "/", "")) = "" Then
                mensaje = " Fecha documento"
                resultado = False
            End If

            'If Me.CtrlIndizacionEpidemiologia1.txtServicio.Text = "" Then
            '    mensaje = " Servicio "
            '    resultado = False
            'End If


            If Me.CtrlIndizacionEpidemiologia1.txtNumHistoria.Text = "" Then
                mensaje = " Numhistoria "
                resultado = False
            End If
            'If Me.CtrlIndizacionEpidemiologia1.txtidArea.Text = "" Then
            '    mensaje = "area "
            '    resultado = False
            'End If

            mensaje = "Falta por cumplimentar los siguientes campos: " & vbCr & mensaje
            Return resultado

        Catch ex As Exception
            MessageBox.Show("Ocurrio un error al comprobar datos cumplimentados.")
            Return True
        End Try
    End Function


    ''' <summary>
    ''' M?todo que permite cargar los datos de indizacion de la imagen actual 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub cargarDatosImagenActual()
        'Dim dt_documentos As DataTable
        'Dim consultaSQL As String

        Dim mensaje As String = ""

        mensaje = "*******************************"
        mensaje = mensaje & vbLf & "    Inicio cargarDatosImagenActual."

        Try
            'cargamos el documento actual en el panel 
            If Me.indice < 0 Then
                mensaje = mensaje & vbLf & "    Indice menor que cero: " & indice
                Me.indice = 0
            Else
                mensaje = mensaje & vbLf & "    Indice mayor que cero: " & indice
                If ListView1.Items.Count - 1 >= Me.indice Then
                    If Me.indice = 0 Then
                        Me.indice = 0
                    Else
                        'PasarASiguiente = True
                        If PasarASiguiente = True Then
                            If (ListView1.Items.Count - 1) = Me.indice Then
                                'significa que estamos en el ultimo registro
                                Me.indice = Me.indice
                                PasarASiguiente = False
                            Else
                                Me.indice = Me.indice
                                PasarASiguiente = False
                            End If
                            'Me.indice = Me.indice + 1
                            'PasarASiguiente = False
                        Else
                            'Me.indice = Me.indice - 1
                        End If

                    End If

                Else
                    mensaje = mensaje & vbLf & "    MaxRegistros: " & MaxRegistros & ", Indice: " & Me.indice & ", LoteYaCerrado: " & LoteYaCerrado
                    If MaxRegistros = Me.indice And LoteYaCerrado = True Then
                        Me.indice = Me.indice - 1
                    Else
                        If MaxRegistros = Me.indice Then
                            Me.indice = Me.indice - 1
                        Else
                            Me.indice = Me.indice
                        End If

                    End If
                End If
            End If

            mensaje = mensaje & vbLf & "    Establece documento actual. Indice: " & Me.indice
            Me.CtrlIndizacionEpidemiologia1.SetDocumentoActual = Me.ListView1.Items(Me.indice)
            'Me.CtrlIndizacionEpidemiologia1.lblNHC.Text = Trim(Me.ListView1.Items(Me.indice).SubItems("numhistoria").Text)

            If Trim(Me.ListView1.Items(Me.indice).SubItems("Indizada").Text) = "1" Then
                CtrlIndizacionEpidemiologia1.lvwPacientes.Clear()
                CtrlIndizacionEpidemiologia1.lvwPacientes.Visible = False
                CtrlIndizacionEpidemiologia1.ListView1.Items.Clear()

                mensaje = mensaje & vbLf & "    Ya indizado"
                Me.CtrlIndizacionEpidemiologia1.txtNumHistoria.Text = Me.ListView1.Items(Me.indice).SubItems("numhistoria").Text

                ''JANTONIO v 2.0.0.0 15-11-2019
                'consultaSQL = "select nombre, apellido1, apellido2 from fip where numhistoria=" & Me.CtrlIndizacionEpidemiologia1.txtNumHistoria.Text.ToString.Trim
                'dt_documentos = datos.ejecutarSQLDirecta(consultaSQL, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto).Tables(0)
                'If dt_documentos.Rows.Count > 0 Then Me.CtrlIndizacionEpidemiologia1.txtPaciente.Text = dt_documentos.Rows(0)("nombre").ToString & " " & dt_documentos.Rows(0)("apellido1").ToString & " " & dt_documentos.Rows(0)("apellido2").ToString
                'dt_documentos.Dispose()
                ''******************************
                mensaje = mensaje & vbLf & "    Despues de NHC."
                Me.CtrlIndizacionEpidemiologia1.mtxtFEchainicio.Text = Me.ListView1.Items(Me.indice).SubItems("fechainicio").Text.ToString.Trim
                mensaje = mensaje & vbLf & "    Despues de 1."
                Me.CtrlIndizacionEpidemiologia1.mtxtfechaTerminio.Text = Me.ListView1.Items(Me.indice).SubItems("fechatermino").Text.ToString.Trim
                mensaje = mensaje & vbLf & "    Despues de 2."
                Me.CtrlIndizacionEpidemiologia1.mTxtFechaDia.Text = Me.ListView1.Items(Me.indice).SubItems("fechadocumento").Text.ToString.Trim
                mensaje = mensaje & vbLf & "    Despues de 3."
                Me.CtrlIndizacionEpidemiologia1.txtServicio.Text = Me.ListView1.Items(Me.indice).SubItems("codserviciopaed").Text.ToString.Trim
                mensaje = mensaje & vbLf & "    Despues de 4."
                Me.CtrlIndizacionEpidemiologia1.txtNumicu.Text = Me.ListView1.Items(Me.indice).SubItems("codigoActo").Text.ToString.Trim
                mensaje = mensaje & vbLf & "    Despues de 5."
                ''Me.CtrlIndizacionEpidemiologia1.Area1.Text = Me.ListView1.Items(Me.indice).SubItems("tipoepisodiopaed").Text.ToString.Trim
                mensaje = mensaje & vbLf & "    Despues de 6."
                ' ''Me.CtrlIndizacionEpidemiologia1.txtICUOrion.Text = Me.ListView1.Items(Me.indice).SubItems("orion").Text.ToString.Trim
                mensaje = mensaje & vbLf & "    Despues de 7."
                Me.CtrlIndizacionEpidemiologia1.txtCodigoDoc.Text = Me.ListView1.Items(Me.indice).SubItems("tipodocumento").Text.ToString.Trim
                mensaje = mensaje & vbLf & "    Despues de 8."
                Me.CtrlIndizacionEpidemiologia1.txtPaciente.Text = Me.ListView1.Items(Me.indice).SubItems("paciente").Text.ToString.Trim '' Trim(Me.ListView1.Items(Me.indice).SubItems("nombre").Text.ToString.Trim) & "," & Me.ListView1.Items(Me.indice).SubItems("apellido1").Text.ToString.Trim & " " & Me.ListView1.Items(Me.indice).SubItems("apellido2").Text.ToString.Trim
                mensaje = mensaje & vbLf & "    Despues de 9."
                If Me.ListView1.Items(Me.indice).SubItems("tipoDOCUMENTO").Text.ToString.Trim = "120" Then
                    Me.CtrlIndizacionEpidemiologia1.ConInf.Checked = True
                ElseIf Me.ListView1.Items(Me.indice).SubItems("tipoDOCUMENTO").Text.ToString.Trim = "121" Then
                    Me.CtrlIndizacionEpidemiologia1.UCSI.Checked = True
                Else
                    Me.CtrlIndizacionEpidemiologia1.ConInf.Checked = False
                    Me.CtrlIndizacionEpidemiologia1.UCSI.Checked = False
                End If
                mensaje = mensaje & vbLf & "    Despues de 10."
                'JANTONIO v 2.0.0.0 15-11-2019
                If Me.CtrlIndizacionEpidemiologia1.txtServicio.Text.ToString.Trim() <> "" Then Me.CtrlIndizacionEpidemiologia1.cmbServicios.SelectedIndex = Me.CtrlIndizacionEpidemiologia1.cmbServicios.FindString(Me.CtrlIndizacionEpidemiologia1.txtServicio.Text.ToString.Trim() & " - ")
                Me.CtrlIndizacionEpidemiologia1.lblservicio.Text = ""
                mensaje = mensaje & vbLf & "    Despues de 11."
                If Me.CtrlIndizacionEpidemiologia1.txtCodigoDoc.Text.ToString.Trim() <> "" Then Me.CtrlIndizacionEpidemiologia1.cmb_codigo_doc.SelectedIndex = Me.CtrlIndizacionEpidemiologia1.cmb_codigo_doc.FindString(Me.CtrlIndizacionEpidemiologia1.txtCodigoDoc.Text.ToString.Trim() & " - ")
                mensaje = mensaje & vbLf & "    Despues de 12."

                Me.CtrlIndizacionEpidemiologia1.txtDNI.Text = Me.ListView1.Items(Me.indice).SubItems("DNI").Text.ToString.Trim
                Me.CtrlIndizacionEpidemiologia1.txtCIP.Text = Me.ListView1.Items(Me.indice).SubItems("CIP").Text.ToString.Trim
                Me.CtrlIndizacionEpidemiologia1.CambiarTipoActo(Me.ListView1.Items(Me.indice).SubItems("tipoActo").Text.ToString.Trim)
                '*********************************************

                If Me.ListView1.Items(Me.indice).SubItems("ErrorEnvio").Text.ToString.Trim = "NO" Then
                    'lblErrorEnvio.Text = ""
                    RichTextBox1.Text = ""
                Else
                    'lblErrorEnvio.Text = Me.ListView1.Items(Me.indice).SubItems("ErrorEnvio").Text.ToString.Trim
                    RichTextBox1.Text = Me.ListView1.Items(Me.indice).SubItems("ErrorEnvio").Text.ToString.Trim
                End If

            Else
                mensaje = mensaje & vbLf & "    No indizado"
                If Me.ListView1.Items(Me.indice).SubItems("BarcodeDet").Text = 1 Then
                    ''Aqui detecto si es otro número de historia
                    CtrlIndizacionEpidemiologia1.mTxtFechaDia.Text = ""
                    CtrlIndizacionEpidemiologia1.txtNumHistoria.Text = ""
                    CtrlIndizacionEpidemiologia1.txtDNI.Text = ""
                    CtrlIndizacionEpidemiologia1.txtCIP.Text = ""
                    CtrlIndizacionEpidemiologia1.txtPaciente.Text = ""
                    CtrlIndizacionEpidemiologia1.lvwPacientes.Visible = False
                    CtrlIndizacionEpidemiologia1.cmbTipoActo.Text = ""
                    CtrlIndizacionEpidemiologia1.txtNumicu.Text = ""
                    CtrlIndizacionEpidemiologia1.mtxtFEchainicio.Text = ""
                    CtrlIndizacionEpidemiologia1.mtxtfechaTerminio.Text = ""
                    CtrlIndizacionEpidemiologia1.txtCodigoDoc.Text = ""
                    CtrlIndizacionEpidemiologia1.cmb_codigo_doc.Text = ""
                    CtrlIndizacionEpidemiologia1.txtServicio.Text = ""
                    CtrlIndizacionEpidemiologia1.cmbServicios.Text = ""

                    ''lblErrorEnvio.Text = ""
                    If Me.ListView1.Items(Me.indice).SubItems("ErrorEnvio").Text.ToString.Trim = "NO" Then
                        ''lblErrorEnvio.Text = ""
                        RichTextBox1.Text = ""
                    Else
                        ''lblErrorEnvio.Text = Me.ListView1.Items(Me.indice).SubItems("ErrorEnvio").Text.ToString.Trim
                        RichTextBox1.Text = Me.ListView1.Items(Me.indice).SubItems("ErrorEnvio").Text.ToString.Trim
                    End If

                    CtrlIndizacionEpidemiologia1.mTxtFechaDia.Focus()
                Else
                    Me.CtrlIndizacionEpidemiologia1.txtNumHistoria.Text = Me.ListView1.Items(Me.indice).SubItems("numhistoria").Text
                    Me.CtrlIndizacionEpidemiologia1.mtxtFEchainicio.Text = Me.ListView1.Items(Me.indice).SubItems("fechainicio").Text.ToString.Trim
                    Me.CtrlIndizacionEpidemiologia1.mtxtfechaTerminio.Text = Me.ListView1.Items(Me.indice).SubItems("fechatermino").Text.ToString.Trim
                    Me.CtrlIndizacionEpidemiologia1.mTxtFechaDia.Text = Me.ListView1.Items(Me.indice).SubItems("fechadocumento").Text.ToString.Trim
                    If Me.CtrlIndizacionEpidemiologia1.txtServicio.Enabled Then
                        Me.CtrlIndizacionEpidemiologia1.txtServicio.Text = Me.ListView1.Items(Me.indice).SubItems("codserviciopaed").Text.ToString.Trim
                        If Me.CtrlIndizacionEpidemiologia1.txtServicio.Text.ToString.Trim() <> "" Then
                            Me.CtrlIndizacionEpidemiologia1.cmbServicios.SelectedIndex = Me.CtrlIndizacionEpidemiologia1.cmbServicios.FindString(Me.CtrlIndizacionEpidemiologia1.txtServicio.Text.ToString.Trim() & " - ")
                        Else
                            Me.CtrlIndizacionEpidemiologia1.cmbServicios.SelectedIndex = -1
                        End If
                    End If

                    Me.CtrlIndizacionEpidemiologia1.txtNumicu.Text = Me.ListView1.Items(Me.indice).SubItems("codigoActo").Text.ToString.Trim
                    If Me.CtrlIndizacionEpidemiologia1.txtCodigoDoc.Enabled Then
                        Me.CtrlIndizacionEpidemiologia1.txtCodigoDoc.Text = Me.ListView1.Items(Me.indice).SubItems("tipodocumento").Text.ToString.Trim
                        If Me.CtrlIndizacionEpidemiologia1.txtCodigoDoc.Text.ToString.Trim() <> "" Then
                            Me.CtrlIndizacionEpidemiologia1.cmb_codigo_doc.SelectedIndex = Me.CtrlIndizacionEpidemiologia1.cmb_codigo_doc.FindString(Me.CtrlIndizacionEpidemiologia1.txtCodigoDoc.Text.ToString.Trim() & " - ")
                        Else
                            Me.CtrlIndizacionEpidemiologia1.cmb_codigo_doc.SelectedIndex = -1
                        End If
                    End If

                    Me.CtrlIndizacionEpidemiologia1.txtPaciente.Text = Me.ListView1.Items(Me.indice).SubItems("paciente").Text.ToString.Trim '' Trim(Me.ListView1.Items(Me.indice).SubItems("nombre").Text.ToString.Trim) & "," & Me.ListView1.Items(Me.indice).SubItems("apellido1").Text.ToString.Trim & " " & Me.ListView1.Items(Me.indice).SubItems("apellido2").Text.ToString.Trim
                    If Me.ListView1.Items(Me.indice).SubItems("tipoDOCUMENTO").Text.ToString.Trim = "120" Then
                        Me.CtrlIndizacionEpidemiologia1.ConInf.Checked = True
                    ElseIf Me.ListView1.Items(Me.indice).SubItems("tipoDOCUMENTO").Text.ToString.Trim = "121" Then
                        Me.CtrlIndizacionEpidemiologia1.UCSI.Checked = True
                    Else
                        Me.CtrlIndizacionEpidemiologia1.ConInf.Checked = False
                        Me.CtrlIndizacionEpidemiologia1.UCSI.Checked = False
                    End If

                    Me.CtrlIndizacionEpidemiologia1.lblservicio.Text = ""

                    Me.CtrlIndizacionEpidemiologia1.txtDNI.Text = Me.ListView1.Items(Me.indice).SubItems("DNI").Text.ToString.Trim
                    Me.CtrlIndizacionEpidemiologia1.txtCIP.Text = Me.ListView1.Items(Me.indice).SubItems("CIP").Text.ToString.Trim
                    If Me.ListView1.Items(Me.indice).SubItems("tipoActo").Text.ToString.Trim = "" Then
                        Me.CtrlIndizacionEpidemiologia1.cmbTipoActo.SelectedIndex = -1
                    Else
                        Me.CtrlIndizacionEpidemiologia1.CambiarTipoActo(Me.ListView1.Items(Me.indice).SubItems("tipoActo").Text.ToString.Trim)
                    End If

                    If Me.ListView1.Items(Me.indice).SubItems("ErrorEnvio").Text.ToString.Trim = "NO" Then
                        ''lblErrorEnvio.Text = ""
                        RichTextBox1.Text = ""
                    Else
                        ''lblErrorEnvio.Text = Me.ListView1.Items(Me.indice).SubItems("ErrorEnvio").Text.ToString.Trim
                        RichTextBox1.Text = Me.ListView1.Items(Me.indice).SubItems("ErrorEnvio").Text.ToString.Trim
                    End If

                End If

                ''Me.CtrlIndizacionEpidemiologia1.txtNumHistoria.Text = Me.ListView1.Items(Me.indice).SubItems("numhistoria").Text
                ''Me.CtrlIndizacionEpidemiologia1.txtPaciente.Text = Trim(Me.ListView1.Items(Me.indice).SubItems("nombre").Text) & "," & Me.ListView1.Items(Me.indice).SubItems("apellido1").Text & " " & Me.ListView1.Items(Me.indice).SubItems("apellido2").Text

                'JANTONIO v 2.0.0.0 15-11-2019
                'Dim dt_documentos As DataTable
                ' ''consultaSQL = "SELECT dc.idlote as id_lote,dc.icuorion,dc.pagina,dc.NumHistoria as NHC,dc.eliminada,ti.descripcion, (select TOP 1 NOMBRE from fip where numhistoria=dc.numhistoria) as nombre,(select TOP 1 APELLIDO1 from fip where numhistoria=dc.numhistoria) as APELLIDO1,(select TOP 1 APELLIDO2 from fip where numhistoria=dc.numhistoria) as APELLIDO2,dc.NomArchivoTIF as NomArchivo, " _
                ' ''& "isnull(dc.girado,'0') girado,isnull(dc.tipodocumento,'0') tipodocumento,dc.VerificadoDigi,isnull(dc.Incidencia ,'0') Incidencia," _
                ' ''& "isnull(dc.CorregidoDigi ,'0') Corregida," _
                ' ''& "dc.iddocumento as ID,isnull(dc.BarcodeDet,0) BarcodeDet, " _
                ' ''& "isnull(dc.CorregidoDigi ,'0') CorregidoDigi, ti.idincidencia as codigo,Isnull(ti.idincidencia,'0') as ID_incidencia " _
                ' ''& "from DOCUMENTOS dc LEFT OUTER JOIN " _
                ' ''& "DOCUMENTOSINCIDENCIAS di ON dc.IdDocumento = di.IdDocumento LEFT OUTER JOIN " _
                ' ''& "TIPOSINCIDENCIAS ti ON di.IdIncidencia = ti.IdIncidencia AND ti.tipo = 'DIGI' " _
                ' ''& "WHERE     (dc.idlote = " & frmContenedorMDI.oLote._idlote & ") ORDER BY dc.pagina asc "

                ' ''dt_documentos = datos.ejecutarSQLDirecta(consultaSQL, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto).Tables(0)
                '''************************************
                ''' 
                'si esta en la base de datos lo vamos a cargar y si no esta lo cargaremos en blanco


                'JANTONIO v 2.0.0.0 15-11-2019
                'consultaSQL = "select nombre, apellido1, apellido2 from fip where numhistoria=" & Me.CtrlIndizacionEpidemiologia1.txtNumHistoria.Text.ToString.Trim
                'dt_documentos = datos.ejecutarSQLDirecta(consultaSQL, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto).Tables(0)
                'If dt_documentos.Rows.Count > 0 Then Me.CtrlIndizacionEpidemiologia1.txtPaciente.Text = dt_documentos.Rows(0)("nombre").ToString & " " & dt_documentos.Rows(0)("apellido1").ToString & " " & dt_documentos.Rows(0)("apellido2").ToString
                'dt_documentos.Dispose()
                ' ''Me.CtrlIndizacionEpidemiologia1.txtPaciente.Text = dt_documentos.Rows(0)("nombre").ToString & " " & dt_documentos.Rows(0)("apellido1").ToString & " " & dt_documentos.Rows(0)("apellido2").ToString '& Trim(Me.ListView1.Items(Me.indice).SubItems("nombre").Text) & "," & Me.ListView1.Items(Me.indice).SubItems("apellido1").Text & " " & Me.ListView1.Items(Me.indice).SubItems("apellido2").Text
                '*******************
                'COMENTO ESTO PARA QUE ARRASTRE LOS VALORES DEL ANTERIOR DOCUMENTO
                'Me.CtrlIndizacionEpidemiologia1.mtxtFEchainicio.Text = Me.ListView1.Items(Me.indice).SubItems("fechainicio").Text
                'Me.CtrlIndizacionEpidemiologia1.mtxtfechaTerminio.Text = Me.ListView1.Items(Me.indice).SubItems("fechatermino").Text
                'Me.CtrlIndizacionEpidemiologia1.mTxtFechaDia.Text = Me.ListView1.Items(Me.indice).SubItems("fechadocumento").Text
                'Me.CtrlIndizacionEpidemiologia1.txtServicio.Text = Me.ListView1.Items(Me.indice).SubItems("codserviciopaed").Text
                'Me.CtrlIndizacionEpidemiologia1.txtNumicu.Text = Me.ListView1.Items(Me.indice).SubItems("numicu").Text
                'Me.CtrlIndizacionEpidemiologia1.txtCodigoDoc.Text = Me.ListView1.Items(Me.indice).SubItems("tipodocumento").Text

                'Me.CtrlIndizacionEpidemiologia1.lblservicio.Text = Trim(Me.ListView1.Items(Me.indice).SubItems("servicio").Text)
                '*****************************************************************

                mensaje = mensaje & vbLf & "    antes de..."

                ' Me.CtrlIndizacionEpidemiologia1.lblservicio.Text = Trim(Me.ListView1.Items(Me.indice).SubItems("servicio").Text)
                If Me.indice <> 0 Then
                    If Me.ListView1.Items(Me.indice - 1).SubItems("eliminada").Text = 0 Then
                        ''If Me.ListView1.Items(Me.indice - 1).SubItems("numicu").Text = "'998'" Then
                        ''    Me.CtrlIndizacionEpidemiologia1.txtNumicu.Text = "'998'"
                        ''End If
                    End If
                End If

                mensaje = mensaje & vbLf & "    después de..."

                Me.CtrlIndizacionEpidemiologia1.ConInf.Checked = False
                Me.CtrlIndizacionEpidemiologia1.UCSI.Checked = False
                Me.CtrlIndizacionEpidemiologia1.SD.Checked = False
            End If

            mensaje = mensaje & vbLf & "Fin cargarDatosImagenActual."
            mensaje = mensaje & vbLf & "*******************************"

        Catch ex As Exception
            ' ''LibreriaCadenaProduccion.TXT.clsFormato.escribirEnLog("ERROR en cargarDatosImagenActual a las " & Now & ". ERROR: " & ex.Message)
            ' ''LibreriaCadenaProduccion.TXT.clsFormato.escribirEnLog(mensaje)
            MessageBox.Show("Ocurrio un error al cargar los datos del documento")
        End Try
    End Sub

    ''' <summary>
    ''' M?todo que permite cerrar el lote comprobando que todos los documentos eston indizados
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CtrlBotonGrande1_eClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CtrlBotonGrande1.eClick
        Dim dt As DataTable
        Dim paginas As String = ""
        Dim mensaje As String = ""
        Dim forzarCierre As Boolean = True

        Try
            GuardarEnBasedeDatos(RutaCompletaCadenaConexion)

            'Comprueba si hay errores pendientes de arreglar de anteriores envíos del lote al WS del cliente.
            mensaje = compruebaErroresEnvioWSCliente(frmContenedorMDI.oLote._idlote)
            If mensaje.ToString.Trim <> "" Then
                MessageBox.Show("Existen errores pendientes de arreglar de anteriores envíos del lote al cliente. Revise errores de las página: " & vbLf & mensaje, "Lote con errores envío", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If (datos.ObtenerListadoParaValorParametro("documentos", "count(*)", "(indizado is null or indizado <> 1) and Eliminada <> 1 and idlote", frmContenedorMDI.oLote._idlote, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto).Rows(0).Item(0) > 0) Then
                MessageBox.Show("Para cerrar el lote debe de indizar todos los documentos")
            Else
                If (datos.ObtenerListadoParaValorParametro("documentos", "count(*)", "(numHistoria is null or CIP is null or CIP='' or numHistoria=0 or codserviciopaed is null or codserviciopaed=0 or fechainicio is null or tipoDocumento is null or tipoDocumento =0 or tipoActo is null or tipoacto = '') and Eliminada <> 1 and idlote", frmContenedorMDI.oLote._idlote, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto).Rows(0).Item(0) > 0) Then
                    MessageBox.Show("Hay algún documento que no se ha indizado el número de historia, el servicio, la fecha de incio o el tipo de documento.")

                    dt = datos.ejecutarSQLDirecta("SELECT * FROM DOCUMENTOS WHERE (numHistoria is null or numHistoria=0 or CIP is null or CIP='' or codserviciopaed is null or codserviciopaed=0 or fechainicio is null or tipoDocumento is null or tipoDocumento =0  or tipoActo is null or tipoacto = '')and Eliminada <> 1 and idLote=" & frmContenedorMDI.oLote._idlote, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto).Tables(0)
                    For Each fila As DataRow In dt.Rows
                        paginas = paginas + fila.Item("pagina").ToString.Trim & ", "
                    Next

                    If paginas.ToString.Trim <> "" Then
                        MessageBox.Show("Revise las páginas " & paginas & " tienen incidencias.", "Páginas con incidencias", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Else
                    'Comprueba lote indizado en GECI
                    mensaje = compruebaHistorias(frmContenedorMDI.oLote._idlote)

                    If mensaje.ToString.Trim = "FALLO" Then
                        MessageBox.Show("Ha ocurrido un error no controlado al cerrar el lote, contacte con soporte.", "Lote con incidencias", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        forzarCierre = False
                    ElseIf mensaje.ToString.Trim <> "" Then
                        If MessageBox.Show("La integridad del lote no es correcta:" & vbLf & mensaje & vbLf & vbLf & "¿Desea forzar el cierre del lote?", "Lote con incidencias", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) = vbYes Then
                            forzarCierre = True
                        Else
                            forzarCierre = False
                        End If
                    End If

                    If forzarCierre Then
                        'Comprueba si existen el mismo número de posiciones en el lote que historias en la carpeta
                        Dim numPacientes As Integer = 0
                        Dim numPosiciones As String = datos.ObtenerListadoParaValorParametro("lotes", "numeroPosiciones", " idlote", frmContenedorMDI.oLote._idlote, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto).Rows(0).Item(0)

                        If numPosiciones.ToString.Trim = "" Or numPosiciones.ToString.Trim = "0" Then
                            numPacientes = 0
                        Else
                            ''numPacientes = datos.ObtenerListadoParaValorParametro("documentos", "count(*)", "BarCodeDet = 1 and Eliminada <> 1 and idlote", frmContenedorMDI.oLote._idlote, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto).Rows(0).Item(0)
                            numPacientes = datos.ObtenerListadoParaValorParametro("documentos", "distinct(numHistoria)", "Eliminada <> 1 and idlote", frmContenedorMDI.oLote._idlote, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto).Rows.Count '.Rows(0).Item(0)
                        End If

                        If (numPacientes <> numPosiciones) Then
                            If MessageBox.Show("Se han indizado " & numPacientes & " pacientes de " & numPosiciones & "." & vbLf & "¿Desea forzar el cierre del lote?", "Lote con incidencias", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = vbYes Then
                                forzarCierre = True
                            Else
                                forzarCierre = False
                            End If
                        End If

                        If forzarCierre Then
                            accesoDatosLotes.CerrarLoteIndizacion(frmContenedorMDI.oUsuario._login, frmContenedorMDI.oLote._idlote, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto)
                            'Ahora procedemos a cerrar el lote y volver a elegir el lote a indizar
                            If Not IsNothing(frmContenedorMDI.oDocumento) Then frmContenedorMDI.oDocumento = Nothing
                            If Not IsNothing(frmContenedorMDI.oFuncionAplicacion) Then frmContenedorMDI.oFuncionAplicacion = Nothing
                            If Not IsNothing(frmContenedorMDI.oLote) Then frmContenedorMDI.oLote = Nothing
                            If Not IsNothing(frmContenedorMDI.oProyecto) Then frmContenedorMDI.oProyecto = Nothing

                            QuiereCerrarLote = True

                            Me.Close()
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show("Ocurrio un error al cerrar el lote")
        End Try
    End Sub

#Region "Tratamiento de las imagenes"
    'mostramos la imagen de la ruta solicitada 
    Public Sub mostrarImagen(ByVal ruta As String)
        Dim mensaje As String = ""

        mensaje = "--------------------------------------"
        mensaje = mensaje & vbLf & "    Inicio mostrarImagen. Ruta.-" & ruta

        Try
            If rutaImg <> ruta Then 'Con esto solo cargo una vez la imagen
                If IO.File.Exists(ruta) Then
                    With Me.IMGeditPrincipal
                        .ClearDisplay()
                        .Image = ""
                        .Image = ruta
                        .FitTo(0)
                        .Display()
                        .Refresh()
                    End With

                    With Me.ImgEditLupa
                        .ClearDisplay()
                        .Image = ""
                        .Image = ruta
                        .FitTo(3)
                        .Display()
                        .Refresh()
                    End With

                    rutaImg = ruta
                Else
                    MessageBox.Show("No se ha encontrado la imagen en la ruta solicitada ")
                End If

                mensaje = mensaje & vbLf & "Fin mostrarImagen."
                mensaje = mensaje & vbLf & "--------------------------------------"
            End If


        Catch ex As Exception
            ' ''LibreriaCadenaProduccion.TXT.clsFormato.escribirEnLog("ERROR en mostrarImagen a las " & Now & ". ERROR: " & ex.Message)
            ' ''LibreriaCadenaProduccion.TXT.clsFormato.escribirEnLog(mensaje)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Incidencia de aplicacion")
        End Try

    End Sub

    Public Sub mostrarImagen_OLD20191209(ByRef var_ImgEditPrincipal As AxImgeditLibCtl.AxImgEdit, ByRef var_imgEditlupa As AxImgeditLibCtl.AxImgEdit, ByVal ruta As String)

        Try
            If IO.File.Exists(ruta) Then
                With Me.IMGeditPrincipal
                    .ClearDisplay()
                    .Image = ""
                    .Image = ruta
                    .FitTo(0)
                    .Display()
                    .Refresh()
                End With

                With Me.ImgEditLupa
                    .ClearDisplay()
                    .Image = ""
                    .Image = ruta
                    .FitTo(0)
                    .Display()
                    .Refresh()
                End With

            Else
                MessageBox.Show("No se ha encontrado la imagen en la ruta solicitada ")
            End If

            'End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Incidencia de aplicacion")
        End Try

    End Sub

#End Region

    Private Sub escribirInicioSesion()
        Dim stringInicioSescion As String = "=======INICIO DEL PROCESO DE INDIZACION=========" & vbCr

        stringInicioSescion &= "Usuario: " & frmContenedorMDI.oUsuario._login.ToString & vbCr
        stringInicioSescion &= "Fecha: " & Date.Now.ToLongDateString & vbCr
        stringInicioSescion &= "Hora: " & Date.Now.ToLongTimeString & vbCr
        stringInicioSescion &= "======================================================" & vbCr

        'editor.centrado(Me.RichTextBox1, stringInicioSescion)
    End Sub

    Private Sub escribirFinSesion()
        Dim stringInicioSescion As String = "=======fin del procesoindizacion=========" & vbCr

        stringInicioSescion &= "Usuario: " & frmContenedorMDI.oUsuario._login.ToString & vbCr
        stringInicioSescion &= "Fecha: " & Date.Now.ToLongDateString & vbCr
        stringInicioSescion &= "Hora: " & Date.Now.ToLongTimeString & vbCr
        stringInicioSescion &= "======================================================" & vbCr

        'editor.centrado(Me.RichTextBox1, stringInicioSescion)
    End Sub

    Public Sub escribirPierdeFoco()
        Dim stringInicioSescion As String = "Pierde foco el tipo documento"
        'editor.centrado(Me.RichTextBox1, stringInicioSescion)
    End Sub

    Public Sub escribirPierdeFocoFecha()
        Dim stringInicioSescion As String = "Pierde foco el tipo documento"
        'editor.centrado(Me.RichTextBox1, stringInicioSescion)
    End Sub
    Public Sub escribirCambioHistoria(ByVal historia1 As String, ByVal historia2 As String)
        Dim stringInicioSescion As String = "Cambio de historia (" & historia1 & "," & historia2 & ")=> pasamos foco a la fecha  " & vbCr
        'editor.centrado(Me.RichTextBox1, stringInicioSescion)
    End Sub

    Public Sub escribirHistoria(ByVal historia1 As String, ByVal historia2 As String)
        Dim stringInicioSescion As String = "Nos mantenemos en la historia (" & historia1 & "," & historia2 & ")=> pasamos foco al tipo documento" & vbCr
        'editor.centrado(Me.RichTextBox1, stringInicioSescion)
    End Sub

    Private Sub frmIndizacionGeneral_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Dim respuesta As String = ""
        If QuiereCerrarLote = False Then
            If MessageBox.Show("¿Desea guardar los cambios antes de salir?", "Indizacion", MessageBoxButtons.YesNo) = 6 Then
                GuardarEnBasedeDatos(RutaCompletaCadenaConexion)
            End If
        End If

        escribirFinSesion()

        'Dim ruta As String = Me.rutaImagenes & "\indizacion" & frmContenedorMDI.oUsuario._login & Replace(Date.Now.ToShortDateString, "/", "") & Replace(Date.Now.ToLongTimeString, ":", "") & ".rtf"
        'Me.RichTextBox1.SaveFile(ruta, RichTextBoxStreamType.RichText)

    End Sub

    Public Sub GuardarEnBasedeDatos(ByVal ruta As String)
        Dim indice As Integer = 0
        Dim contador As Integer = 0
        Dim filasAfectatadas As Integer = 0

        Dim cadenaSQL As String = ""

        Dim SentenciaSQL As String = ""

        Try

            For indice = 0 To ListView1.Items.Count - 1

                If Me.ListView1.Items(indice).SubItems("Indizada").Text = 1 Then

                    cadenaSQL = ""

                    'If Me.ListView1.Items(indice).SubItems("Eliminada").Text = "True" Then
                    'SentenciaSQL = "UPDATE documentos SET  indizado = 1 where iddocumento='" & Me.ListView1.Items(indice).SubItems(0).Text & "'"
                    'If Not datos.ejecutaSQLEjecucion(SentenciaSQL, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto, filasAfectatadas) Then
                    'If filasAfectatadas = -2146232060 Then
                    'MessageBox.Show("Algunos de los campos introducidos no son correctos.")
                    'End If
                    'End If
                    'End If

                    cadenaSQL &= " NumHistoria='" & Me.ListView1.Items(indice).SubItems("Numhistoria").Text & "'"

                    If (cadenaSQL <> "") Then
                        cadenaSQL &= ", "
                    End If

                    cadenaSQL &= " numicu='" & Me.ListView1.Items(indice).SubItems("codigoActo").Text & "'"

                    If (cadenaSQL <> "") Then
                        cadenaSQL &= ", "
                    End If

                    cadenaSQL &= " codserviciopaed ='" & Me.ListView1.Items(indice).SubItems("codserviciopaed").Text & "'"

                    If (cadenaSQL <> "") Then
                        cadenaSQL &= ", "
                    End If
                    cadenaSQL &= " fechainicio='" & Me.ListView1.Items(indice).SubItems("fechainicio").Text & "'"

                    If (cadenaSQL <> "") Then
                        cadenaSQL &= ", "
                    End If
                    cadenaSQL &= " fechaTermino='" & Me.ListView1.Items(indice).SubItems("fechaTermino").Text & "'"

                    If (cadenaSQL <> "") Then
                        cadenaSQL &= ", "
                    End If
                    cadenaSQL &= " fechadocumento='" & Me.ListView1.Items(indice).SubItems("fechadocumento").Text & "'"

                    If (cadenaSQL <> "") Then
                        cadenaSQL &= ", "
                    End If
                    cadenaSQL &= " tipodocumento ='" & Val(Me.ListView1.Items(indice).SubItems("tipodocumento").Text) & "'"

                    If (cadenaSQL <> "") Then
                        cadenaSQL &= ", "
                    End If
                    cadenaSQL &= " tipoActo='" & Me.ListView1.Items(indice).SubItems("tipoActo").Text & "'"

                    If (cadenaSQL <> "") Then
                        cadenaSQL &= ", "
                    End If
                    cadenaSQL &= " CIP='" & Me.ListView1.Items(indice).SubItems("CIP").Text & "'"

                    If (cadenaSQL <> "") Then
                        cadenaSQL &= ", "
                    End If
                    cadenaSQL &= " indizado ='1'"

                    If (cadenaSQL <> "") Then
                        cadenaSQL &= ", "
                    End If
                    cadenaSQL &= " BarCodeDet ='" & Me.ListView1.Items(indice).SubItems("BarCodeDet").Text & "'"

                    If (cadenaSQL <> "") Then
                        cadenaSQL &= ", "
                    End If
                    cadenaSQL &= " Primera ='" & Me.ListView1.Items(indice).SubItems("Primera").Text & "'"

                    If (cadenaSQL <> "") Then
                        cadenaSQL &= ", "
                    End If
                    cadenaSQL &= " Nombre ='" & Me.ListView1.Items(indice).SubItems("nombre").Text & "'"

                    If (cadenaSQL <> "") Then
                        cadenaSQL &= ", "
                    End If
                    cadenaSQL &= " Apellido1 ='" & Me.ListView1.Items(indice).SubItems("Apellido1").Text & "'"

                    If (cadenaSQL <> "") Then
                        cadenaSQL &= ", "
                    End If
                    cadenaSQL &= " Apellido2 ='" & Me.ListView1.Items(indice).SubItems("apellido2").Text & "'"

                    If (cadenaSQL <> "") Then
                        cadenaSQL &= ", "
                    End If
                    cadenaSQL &= " SIP ='" & Me.ListView1.Items(indice).SubItems("sip").Text & "'"

                    If (cadenaSQL <> "") Then
                        cadenaSQL &= ", "
                    End If
                    If Me.ListView1.Items(indice).SubItems("ContenidoEn").Text.ToString.Trim = "" Then
                        cadenaSQL &= " ContenidoEn = NULL"
                    Else
                        cadenaSQL &= " ContenidoEn = '" & Me.ListView1.Items(indice).SubItems("ContenidoEn").Text.ToString.Trim & "'"
                    End If

                    If (cadenaSQL <> "") Then
                        cadenaSQL &= ", "
                    End If
                    ''cadenaSQL &= " ErrorDevuelto ='" & IIf(Me.ListView1.Items(indice).SubItems("ErrorEnvio").Text = "", "NULL", Me.ListView1.Items(indice).SubItems("ErrorEnvio").Text.ToString.Trim) & "'"
                    If Me.ListView1.Items(indice).SubItems("ErrorEnvio").Text.ToString.Trim = "" Then
                        cadenaSQL &= " ErrorDevuelto = NULL"
                    Else
                        cadenaSQL &= " ErrorDevuelto ='" & Me.ListView1.Items(indice).SubItems("ErrorEnvio").Text.ToString.Trim & "'"
                    End If

                    SentenciaSQL = "UPDATE documentos SET " & cadenaSQL & " where iddocumento='" & Me.ListView1.Items(indice).SubItems(0).Text & "'"

                    If Not datos.ejecutaSQLEjecucion(SentenciaSQL, ruta, filasAfectatadas) Then
                        If filasAfectatadas = -2146232060 Then
                            MessageBox.Show("Algunos de los campos introducidos no son correctos.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End If

                    contador = contador + 1
                End If

            Next

            If contador <> 0 Then
                'Si los registros modificados ya habían sido exportados, los desmarca para volver a exportarlos
                If listaContenidoEn.ToString.Trim <> "" Then
                    SentenciaSQL = "UPDATE documentos SET ContenidoEn=NULL, EnviadoEl=NULL where ContenidoEn IN (" & listaContenidoEn.Substring(1).ToString.Trim & ") and idLote = " & frmContenedorMDI.oLote._idlote
                    datos.ejecutaSQLEjecucion(SentenciaSQL, ruta, filasAfectatadas)
                    listaContenidoEn = ""
                End If
                '**********************************************************************************************

                MessageBox.Show("Se han actualizado " & contador.ToString & " registros correctamente.", "Actualización", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show("Se ha producido un error al intentar actualizar los registros.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim i As Integer = 0

        Dim ItemSel_idLote As String = ""
        Dim ItemSel_pagina As String = ""
        Dim ItemSel_nomArchivoTIF As String = ""
        Dim ItemSel_numHistoria As String = ""
        Dim ItemSel_tipoDocumento As String = ""
        Dim ItemSel_fechainicio As String = ""
        Dim ItemSel_fechaTermino As String = ""
        Dim ItemSel_codservicioPAED As String = ""
        Dim ItemSel_TipoEpisodioPAED As String = ""
        Dim ItemSel_Numicu As String = ""
        Dim ItemSel_Incidencia As String = ""
        Dim ItemSel_vinculada As String = ""
        Dim ItemSel_Indizado As String = ""
        Dim ItemSel_Eliminada As String = ""
        Dim ItemSel_nombre As String = ""
        Dim ItemSel_apellido1 As String = ""
        Dim ItemSel_apellido2 As String = ""
        Dim ItemSel_servicio As String = ""

        Dim cadenaSQL As String = ""

        Dim EleSeleccionado As Integer = -1

        For i = 0 To ListView1.Items.Count - 1
            If ListView1.Items(i).Selected = True Then
                EleSeleccionado = i
            End If
        Next

        If EleSeleccionado < "0" Then
            MsgBox("Debe seleccionar un elemento antes de editarlo")
        Else

            Me.indice = EleSeleccionado
            'MsgBox("Indice seleccionado: " + CStr(EleSeleccionado))

            'Sabemos que ya ha seleccionado un elemento. Podemos recuperar todos sus valores y printearlos en pantalla
            ItemSel_idLote = ListView1.Items(EleSeleccionado).SubItems("idLote").Text
            ItemSel_pagina = ListView1.Items(EleSeleccionado).SubItems("pagina").Text
            ItemSel_nomArchivoTIF = ListView1.Items(EleSeleccionado).SubItems("nomArchivoTIF").Text
            ItemSel_numHistoria = ListView1.Items(EleSeleccionado).SubItems("numhistoria").Text
            ItemSel_tipoDocumento = ListView1.Items(EleSeleccionado).SubItems("TipoDocumento").Text
            ItemSel_fechainicio = ListView1.Items(EleSeleccionado).SubItems("fechainicio").Text
            ItemSel_fechaTermino = ListView1.Items(EleSeleccionado).SubItems("fechaTermino").Text
            ItemSel_codservicioPAED = ListView1.Items(EleSeleccionado).SubItems("codservicioPAED").Text
            ItemSel_TipoEpisodioPAED = ListView1.Items(EleSeleccionado).SubItems("TipoEpisodioPAED").Text
            ItemSel_Numicu = ListView1.Items(EleSeleccionado).SubItems("Numicu").Text
            ItemSel_Incidencia = ListView1.Items(EleSeleccionado).SubItems("Incidencia").Text
            'ItemSel_vinculada = ListView1.Items(EleSeleccionado).SubItems(12).Text
            ItemSel_Indizado = ListView1.Items(EleSeleccionado).SubItems("Indizada").Text
            ItemSel_Eliminada = ListView1.Items(EleSeleccionado).SubItems("eliminada").Text
            ItemSel_nombre = ListView1.Items(EleSeleccionado).SubItems("nombre").Text
            ItemSel_apellido1 = ListView1.Items(EleSeleccionado).SubItems("apellido1").Text
            ItemSel_apellido2 = ListView1.Items(EleSeleccionado).SubItems("apellido2").Text
            ItemSel_servicio = ListView1.Items(EleSeleccionado).SubItems("codservicioPAED").Text

            If ItemSel_idLote.Trim <> "" And ItemSel_pagina.Trim <> "" Then

                'Creamos la select para comprobar si este registro concreto tiene el campo indizado a 1. Si no, no dejamos actuar
                cadenaSQL = "SELECT * FROM DOCUMENTOS WHERE idLote = " & ItemSel_idLote & " AND Pagina = " & ItemSel_pagina

                Dim resultado As DataRow = datos.ejecutarSQLDirectaDataRow(cadenaSQL, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto)

                'MsgBox("Valor de indizado: " & resultado(11).ToString)

                If resultado("Indizado").ToString() <> "" And resultado("Indizado").ToString() <> "0" Then
                    'el registro ya ha sido indexado por lo que podemos continuar con la modificacion

                    Me.CtrlIndizacionEpidemiologia1.lblModoEdicion.Visible = True
                    CtrlIndizacionEpidemiologia1.Button1.Visible = False
                    Me.ListView1.Enabled = False
                    ModoEdicion = True

                    Me.CtrlIndizacionEpidemiologia1.txtCodigoDoc.Text = ItemSel_tipoDocumento
                    Me.CtrlIndizacionEpidemiologia1.txtNumicu.Text = ItemSel_Numicu

                    If ItemSel_codservicioPAED.Trim <> "" Then
                        'Cuando le asignemos contenido al campo, ademas de rellenar el valor del propio campo, 
                        'lanzará un evento que refrescará el contenido del desplegable
                        Me.CtrlIndizacionEpidemiologia1.txtServicio.Text = ItemSel_codservicioPAED
                        Me.CtrlIndizacionEpidemiologia1.CambiarServicio(ItemSel_codservicioPAED)
                    End If

                    Me.CtrlIndizacionEpidemiologia1.txtNumHistoria.Text = ItemSel_numHistoria
                    Me.CtrlIndizacionEpidemiologia1.txtPaciente.Text = ItemSel_nombre & " " & ItemSel_apellido1 & " " & ItemSel_apellido2

                    Me.CtrlIndizacionEpidemiologia1.mtxtFEchainicio.Text = ItemSel_fechainicio
                    Me.CtrlIndizacionEpidemiologia1.mtxtfechaTerminio.Text = ItemSel_fechaTermino

                    If ItemSel_Incidencia.Trim <> "" Then
                        Me.CtrlIndizacionEpidemiologia1.cmbIncidencias.SelectedValue = ItemSel_Incidencia
                    End If
                    If ItemSel_tipoDocumento.Trim <> "" Then
                        Me.CtrlIndizacionEpidemiologia1.cmb_codigo_doc.SelectedValue = ItemSel_tipoDocumento
                        Me.CtrlIndizacionEpidemiologia1.CambiarTipoDocumento(ItemSel_tipoDocumento)
                    End If

                Else
                    'El registro no se ha indizado. No se permite la edicion de registros sin indizar
                    MsgBox("Este registro no se puede alterar ya que todavía no ha sido indizado")
                End If

            End If

            'MsgBox(ItemSel_idLote + "|" + ItemSel_pagina + "|" + ItemSel_nomArchivoTIF + "|" + ItemSel_numHistoria + "|" + ItemSel_tipoDocumento + "|" + ItemSel_fechainicio + "|" + ItemSel_fechaTermino + "|" + ItemSel_codservicioPAED + "|" + ItemSel_TipoEpisodioPAED + "|" + ItemSel_Numicu + "|" + ItemSel_Incidencia + "|" + ItemSel_vinculada + "|" + ItemSel_Indizado + "|" + ItemSel_Eliminada + "|" + ItemSel_nombre + "|" + ItemSel_apellido1 + "|" + ItemSel_apellido2 + "|" + ItemSel_servicio)

        End If
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        Dim i As Integer = 0
        Dim rutaImagen As String = ""
        Dim Encontrado As Boolean = False

        Dim mensaje As String = ""

        Try
            mensaje = "..............................."
            mensaje = mensaje & "INICIO ListView1_SelectedIndexChanged"

            Encontrado = False

            While i <= (Me.ListView1.Items.Count - 1)
                If Me.ListView1.Items(i).Selected = True Then
                    Me.indice = i
                    Encontrado = True
                End If
                i = i + 1
            End While

            mensaje = mensaje & "   Indice= " & Me.indice & ", Encontrado= " & Encontrado

            If Not Encontrado Then
                mensaje = mensaje & "   Indice= " & Me.indice & ", Elementos lista= " & Me.ListView1.Items.Count - 1
                If Me.indice < (Me.ListView1.Items.Count - 1) Then
                    Me.indice = Me.indice
                    mensaje = mensaje & "   Indice menor que elementos de la lista."
                Else
                    Me.indice = (Me.ListView1.Items.Count - 1)
                    mensaje = mensaje & "   Indice mayor o igual que elementos de la lista."
                End If
            End If

            rutaImagen = Me.rutaImagenes & "\" & Me.ListView1.Items(Me.indice).SubItems("nomArchivoTIF").Text
            'rutaImagen = "C:\gedsa\Digitalizacion\ProyectosDigi\7002\DIGI\700203168\Imagen\3168" & "\" & Me.ListView1.Items(indice).SubItems("nomArchivoTIF").Text

            mensaje = mensaje & "   Ruta imagen= " & rutaImagen

            '################# JGARIJO ################

            'rutaImagen = rutaImagen.Replace("\\172.21.100.190", "c:")

            '##########################################

            'Dim rutaImagen As String = Me.rutaImagenes & "\" & Me.ListView1.Items(indice).SubItems("nomArchivoTIF").Text

            Me.CtrlIndizacionEpidemiologia1.lblpagina.Text = Me.indice + 1

            mensaje = mensaje & "   Página= " & Me.indice + 1

            Me.CtrlIndizacionEpidemiologia1.lblModoEdicion.Visible = False
            CtrlIndizacionEpidemiologia1.Button1.Visible = True
            Me.ListView1.Enabled = True
            ModoEdicion = False

            'If UCase(IMGeditPrincipal.Image) <> UCase(rutaImagen) Then
            ''If UCase(IMGeditPrincipal.Image) <> UCase(rutaImagen) And Me.ListView1.Items(Me.indice).SubItems("Eliminada").Text <> 1 Then
            mensaje = mensaje & "   Antes de mostrar imagen."
            Me.mostrarImagen(rutaImagen)
            mensaje = mensaje & "   Después de mostrar imagen."
            ''End If
            mensaje = mensaje & "   Antes de cargarDatosImagenActua."
            Me.cargarDatosImagenActual()
            mensaje = mensaje & "   Después de cargarDatosImagenActua."

            ''Me.CtrlIndizacionEpidemiologia1.txtServicio.Focus()

            mensaje = mensaje & "FIN ListView1_SelectedIndexChanged"
            mensaje = mensaje & "..............................."

        Catch ex As Exception
            ' ''LibreriaCadenaProduccion.TXT.clsFormato.escribirEnLog("ERROR en ListView1_SelectedIndexChanged a las " & Now & ". ERROR: " & ex.Message)
            ' ''LibreriaCadenaProduccion.TXT.clsFormato.escribirEnLog(mensaje)
            MessageBox.Show("ERROR al cambiar de elemento en la lista. ERROR: " & ex.Message)

        End Try
    End Sub

    Private Sub CtrlBotonGrande2_eClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CtrlBotonGrande2.eClick
        GuardarEnBasedeDatos(RutaCompletaCadenaConexion)
    End Sub

    Private Sub frmIndizacionGeneral_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        ''inicializarControles()
    End Sub

    Private Sub insertaEpìsodiosHistorias(ByVal idLote As Long)
        Dim lsSql As String = ""

        Try
            lsSql = " insert into produccionelda.dbo.episodios" &
                         " select * from produccionelda.dbo.episodios_orig e where numhistoria in" &
                          " (select distinct numhistoria from produccionelda.dbo.documentos d, lotes l" &
                           " where d.idLote = " & idLote & " and d.numhistoria Is Not null And d.numhistoria > 0 And d.idlote=l.idlote And dat Not Like '%diario%' and (atributado is null OR atributado=0))" &
                            " And Not exists (select * from produccionelda.dbo.episodios where episodio=e.episodio)"
            datos.ejecutaSQLEjecucion(lsSql, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub frmIndizacionGeneral_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated

        ''If ListView1.Items.Count > 0 Then
        ''    'Se posiciona en el listview y lanza el evento al cambiar de linea del listveiw
        ''    Me.ListView1.Items(indice).Selected = True
        ''    Me.ListView1.Items(indice).EnsureVisible()
        ''    Me.ListView1.Focus()
        ''End If

    End Sub

    'Marca la primera página del bloque para saber primera página válida del bloque
    Private Sub marcaPrimeraPaginaBloque(ByVal idLote As Integer)
        'Si el registro tiene barcodedet=1 y primera=1, hay una pegatina en la primera página válida.
        'Si el registro tiene barcodedet=1 y primera=0, hay una carátula separando los bloques

        Dim lsSql As String = ""
        Dim dt As DataTable
        Dim marcaPrimera As Boolean
        Dim barcodedet As Integer

        lsSql = "UPDATE DOCUMENTOS SET primera=0 where idLote=" & idLote
        datos.ejecutaSQLEjecucion(lsSql, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto)

        lsSql = "SELECT * FROM DOCUMENTOS WITH (nolock) WHERE idLote=" & idLote & " ORDER BY Pagina"
        dt = datos.ejecutarSQLDirectaTable(lsSql, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto)
        For Each fila As DataRow In dt.Rows
            If My.Settings.separadorCaratula Then
                If IsDBNull(fila.Item("BarCodeDet")) Then barcodedet = 0 Else barcodedet = fila.Item("BarCodeDet")

                If barcodedet = 1 Then
                    marcaPrimera = True
                Else
                    If marcaPrimera Then
                        lsSql = "UPDATE DOCUMENTOS set primera=1 WHERE idDocumento=" & fila.Item("idDocumento")
                        datos.ejecutaSQLEjecucion(lsSql, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto)
                    End If
                    marcaPrimera = False
                End If
            Else


            End If
        Next

    End Sub

    Private Sub ListView1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ListView1.KeyPress

        ''If e.KeyChar = "m" Or e.KeyChar = "M" Then
        If e.KeyChar = "/" Then
            'Marca el registro como primero de la historia
            e.Handled = True
            Dim i As Integer = 0
            Dim EleSeleccionado As Integer = -1
            For i = 0 To (Me.ListView1.Items.Count - 1)
                If Me.ListView1.Items(i).Selected Then
                    EleSeleccionado = i
                End If
            Next
            If i > -1 Then
                If Me.ListView1.Items(EleSeleccionado).SubItems("BarcodeDet").Text = "0" Then
                    Me.ListView1.Items(EleSeleccionado).SubItems("BarcodeDet").Text = "1"
                    Me.ListView1.Items(EleSeleccionado).SubItems("Primera").Text = "1"

                    Me.ListView1.Items(EleSeleccionado).Font = New Font(ListView1.Font, FontStyle.Bold)
                    Me.ListView1.Items(EleSeleccionado).ForeColor = Drawing.Color.DarkRed
                Else
                    Me.ListView1.Items(EleSeleccionado).SubItems("BarcodeDet").Text = "0"
                    Me.ListView1.Items(EleSeleccionado).SubItems("Primera").Text = "0"

                    Me.ListView1.Items(EleSeleccionado).Font = New Font(ListView1.Font, FontStyle.Regular)
                    Me.ListView1.Items(EleSeleccionado).ForeColor = Drawing.Color.Black
                End If
            End If

        ElseIf e.KeyChar = "º" Then
            e.Handled = True
            Me.CtrlIndizacionEpidemiologia1.mTxtFechaDia.Focus()
            Me.CtrlIndizacionEpidemiologia1.mTxtFechaDia.SelectAll()
            Exit Sub

        ElseIf e.KeyChar = "*" Then
            ''Copia datos del elemento anterior
            'e.Handled = True
            'Dim elementoanterior As ListViewItem
            'elementoanterior = ListView1.Items(Me.CtrlIndizacionEpidemiologia1.GetDocumentoActual.Index - 1)
            'Me.CtrlIndizacionEpidemiologia1.mTxtFechaDia.Focus()

            'Me.CtrlIndizacionEpidemiologia1.copiarDatos_Anterior(elementoanterior)

            'Me.CtrlIndizacionEpidemiologia1.pegarDatos()
            'Me.CtrlIndizacionEpidemiologia1.pulsaMas()

            'Exit Sub

        ElseIf e.KeyChar = "E" Or e.KeyChar = "e" Then
            'e.Handled = True
            'EliminarDocumento()
            'Exit Sub
            e.Handled = True
            Dim i As Integer = 0
            Dim EleSeleccionado As Integer = -1
            For i = 0 To (Me.ListView1.Items.Count - 1)
                If Me.ListView1.Items(i).Selected Then
                    EleSeleccionado = i
                End If
            Next
            If i > -1 Then
                Me.ListView1.Items(EleSeleccionado).SubItems("eliminada").Text = "1"
            End If
            Me.CtrlIndizacionEpidemiologia1.EliminarDocumento()
            Me.bajarAbajo()
            Exit Sub

        ElseIf e.KeyChar = "t" Or e.KeyChar = "T" Then
            e.Handled = True
            Dim i As Integer = 0
            Dim EleSeleccionado As Integer = -1
            For i = 0 To (Me.ListView1.Items.Count - 1)
                If Me.ListView1.Items(i).Selected Then
                    EleSeleccionado = i
                End If
            Next
            If i > -1 Then
                Me.ListView1.Items(EleSeleccionado).SubItems("eliminada").Text = "0"
            End If
            Me.CtrlIndizacionEpidemiologia1.DesEliminarDocumento()
            Me.bajarAbajo()
            Exit Sub

        End If
    End Sub

    Private Sub ListView1_KeyDown(sender As Object, e As KeyEventArgs) Handles ListView1.KeyDown

        ''If e.KeyData = Keys.Control + Keys.C Then
        ''    CtrlIndizacionEpidemiologia1.copiarDatos()
        ''    CtrlIndizacionEpidemiologia1.pulsaMas()

        ''ElseIf e.KeyData = Keys.Control + Keys.V Then
        ''    CtrlIndizacionEpidemiologia1.pegarDatos()
        ''    CtrlIndizacionEpidemiologia1.pulsaMas()

        ''End If

    End Sub

    'Carga los número de historias diferentes de GECI
    Private Sub cargaHistoriasGECI()
        'Dim lsSql As String = "SELECT numHistoria, Archivador, Carpeta FROM loteado_cinf where idLote = " & frmContenedorMDI.oLote._idlote & " ORDER BY numHistoria"
        Dim lssql As String = "SELECT numHistoria, Archivador, Carpeta, l.idServicioHospital, s.idServicio, s.Descripcion" &
                                " FROM loteado_cinf l left join SERVICIOS s on s.idServicioHospital=l.idServicioHospital where idLote = " & frmContenedorMDI.oLote._idlote & " ORDER BY numHistoria"

        listaHistoriasGECI.Clear()
        listaHistoriasServicio_GECI.Clear()

        'cargamos el comgo de servicio 
        For Each registro As DataRow In datos.ejecutarSQLDirectaTable(lsSql, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto).Rows
            If listaHistoriasGECI.FindIndex(Function(numHistoria)
                                                Return (numHistoria = registro.Item("numHistoria").ToString.Trim)
                                            End Function) = -1 Then

                ''If listaHistoriasGECI.Find(registro.Item("numHistoria")) = False Then
                If Not IsDBNull(registro.Item("numHistoria")) Then
                    listaHistoriasGECI.Add(registro.Item("numHistoria").ToString.Trim)
                End If
            End If

            'Lo hago fuera del if porque también necesito recuperar el servicio aunque no exista en la base de datos de GECI pero si físicamente.
            If Not IsDBNull(registro.Item("numHistoria")) Then
                listaHistoriasServicio_GECI.Add(registro.Item("numHistoria").ToString.Trim & "#" & registro.Item("idServicioHospital").ToString.Trim & "#" & registro.Item("idServicio").ToString.Trim & "#" & registro.Item("Descripcion").ToString.Trim)
            End If

            Me.CtrlIndizacionEpidemiologia1.lblGECI.Text = "Archivador: " & registro.Item("Archivador") & ", Carpteta: " & registro.Item("carpeta")
        Next

    End Sub

    Private Function compruebaHistorias(ByVal idLote As Integer) As String

        Dim lsSql As String = ""
        Dim mensaje As String = ""
        Dim lotes As String = ""
        Dim dt As DataTable

        Try
            'Comprueba historias que están indizadas y no en GECI
            lsSql = "select distinct(numhistoria) from documentos where idlote=" & idLote & " and (eliminada is null or Eliminada = 0) " &
                        " EXCEPT " &
                " SELECT distinct(numHistoria) FROM [PRODUCCIONLARIBERA].[dbo].[loteado_cinf] where idlote=" & idLote
            dt = datos.ejecutarSQLDirectaTable(lsSql, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto)
            For Each fila As DataRow In dt.Rows
                lotes = lotes & ", " & fila.Item("numHistoria")
            Next

            If lotes.ToString.Trim <> "" Then
                mensaje = "Las historias " & lotes.Substring(1).ToString.Trim & " se han indizado pero no existen en GECI."
                lotes = ""
            End If

            'Comprueba historias que están en GECI pero no se han indizado
            lsSql = "SELECT distinct(numHistoria) FROM [PRODUCCIONLARIBERA].[dbo].[loteado_cinf] where idlote=" & idLote &
                            " EXCEPT " &
                    "select distinct(numhistoria) from documentos where idlote=" & idLote & " and (eliminada is null or Eliminada = 0)"
            dt = datos.ejecutarSQLDirectaTable(lsSql, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto)
            For Each fila As DataRow In dt.Rows
                lotes = lotes & ", " & fila.Item("numHistoria")
            Next

            If lotes.ToString.Trim <> "" Then
                If mensaje.ToString.Trim <> "" Then
                    mensaje = mensaje & vbLf & "Las historias " & lotes.Substring(1).ToString.Trim & " existen en GECI pero no se han indizado."
                Else
                    mensaje = "Las historias " & lotes.Substring(1).ToString.Trim & " si existen en GECI pero no se han indizado."
                End If
            End If

        Catch ex As Exception
            mensaje = "FALLO"

        End Try

        Return mensaje

    End Function

    Private Function compruebaErroresEnvioWSCliente(ByVal idLote As Integer) As String

        Dim lsSql As String = ""
        Dim mensaje As String = ""
        Dim paginas As String = ""
        Dim dt As DataTable

        Try
            'Comprueba páginas con errores
            lsSql = "select pagina from documentos where idlote=" & idLote & " and ErrorDevuelto is not null and ErrorDevuelto<>'NO' and ErrorDevuelto<>'' and ErrorDevuelto<>'NULL'"
            dt = datos.ejecutarSQLDirectaTable(lsSql, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto)
            For Each fila As DataRow In dt.Rows
                paginas = paginas & ", " & fila.Item("pagina")
            Next

            If paginas.ToString.Trim <> "" Then
                mensaje = paginas.Substring(1).ToString.Trim
            End If

        Catch ex As Exception
            mensaje = "FALLO"

        End Try

        Return mensaje

    End Function

    Private Sub IMGeditPrincipal_SelectionRectDrawn(sender As Object, e As AxImgeditLibCtl._DImgEditEvents_SelectionRectDrawnEvent) Handles IMGeditPrincipal.SelectionRectDrawn
        Dim izq As Integer
        Dim arr As Integer
        Dim anc As Integer
        Dim alt As Integer
        Dim zoomAnterior As Integer
        Try
            izq = e.left / 3
            arr = e.top / 3
            anc = e.width / 3
            alt = e.height / 3

            'AMPLIO LA IMAGEN
            Me.ImgEditLupa.Zoom = 10
            Me.ImgEditLupa.Display()
            Me.ImgEditLupa.DrawSelectionRect(izq, arr, anc, alt)
            Me.ImgEditLupa.ZoomToSelection()
            Me.ImgEditLupa.Refresh()
            Me.ImgEditLupa.DrawSelectionRect(0, 0, 0, 0) 'PARA BORRAR EL CUADRADO
            zoomAnterior = Me.ImgEditLupa.Zoom
        Catch ex As Exception
            MessageBox.Show("Ocurrio un error al mostrar la imagen de la seleccion")
        End Try
    End Sub

End Class