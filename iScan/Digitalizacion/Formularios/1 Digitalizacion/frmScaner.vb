Imports System.IO
Imports GenCode128
Imports editor = LibreriaCadenaProduccion.TXT.clsFormato
Imports fg = LibreriaCadenaProduccion.FuncionesGlobales.Carpetas.clsCarpetas
Imports accesoDatosLotes = LibreriaCadenaProduccion.Datos.Produccion.cadenaproduccion.clsAccesoDatosLote
Imports accesoDatos = LibreriaCadenaProduccion.Datos.GeneralSQL.clsAccesoDatosSQL
Public Class frmScaner

    Private digi_proyecto As String = ""
    Private digi_lote As String = ""
    Private digi_usuario As String = ""
    Private digi_rutaimagenes As String = ""
    Private digi_pagina_actual As Integer = 1
    Private primera As Boolean = True
    Private digi_sustitucion As Boolean = False

    Dim WithEvents aplicacion_scan As Process


    Public Sub New(ByVal proyecto As String, ByVal lote As String, ByVal usuario As String, ByVal rutaimagenes As String)

        Dim datos As DataTable
        ' Llamada necesaria para el Disenyador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicializacion despu?s de la llamada a InitializeComponent().


        Me.digi_proyecto = proyecto
        
        Me.digi_usuario = usuario
        Me.digi_lote = lote
        Try
            datos = accesoDatos.ejecutarSQLDirectaTable("SELECT UnidadREd, RutaImagenes FROM CONFIGURACIONPROYECTO WHERE     (idProyecto = " & digi_proyecto & ")", My.Settings.cadenaConexion)
            Me.digi_rutaimagenes = rutaimagenes.Replace(datos.Rows(0).Item("RutaImagenes").ToString, datos.Rows(0).Item("UnidadREd").ToString)

            If Not Directory.Exists(Me.digi_rutaimagenes) Then
                Directory.CreateDirectory(Me.digi_rutaimagenes)
            End If
        Catch ex As Exception
            MessageBox.Show("Error no hay una unidad definida para este proyecto")
            Me.digi_rutaimagenes = rutaimagenes 'para que no de error al cargar, no podr? digitalizar 
        End Try

    End Sub

    Private Sub frmScaner_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If primera Then inicializarLista()
        inicializarEscaner()
        escribirInicioSesion()

    End Sub

    Private Sub inicializarLista()

        Dim metadatosFichero As FileInfo

        For Each fichero As String In Directory.GetFiles(digi_rutaimagenes, "*.tif")

            metadatosFichero = New FileInfo(fichero)

            digi_insertarItemListview(digi_pagina_actual, metadatosFichero.FullName)

            digi_pagina_actual += 1
        Next

        If Directory.GetFiles(digi_rutaimagenes, "*.tif").Count > 0 Then
            Me.ListView1.Items(Me.ListView1.Items.Count - 1).Selected = True
            Me.ListView1.Items(Me.ListView1.Items.Count - 1).EnsureVisible()
        End If
        Me.lblPaginaActual.Text = digi_pagina_actual
        primera = False

    End Sub

    Private Sub actualizarLista(ByVal indice As Integer)

        digi_pagina_actual = 1
        Me.ListView1.Items.Clear()
        'Me.RtbMensajes.Clear()

        Dim metadatosFichero As FileInfo

        For Each fichero As String In Directory.GetFiles(digi_rutaimagenes, "*.tif")

            metadatosFichero = New FileInfo(fichero)

            digi_insertarItemListview(digi_pagina_actual, metadatosFichero.FullName)

            digi_pagina_actual += 1
        Next

        If Directory.GetFiles(digi_rutaimagenes, "*.tif").Count > 0 Then
            Me.ListView1.Items(indice).Selected = True
            Me.ListView1.Items(indice).EnsureVisible()
        End If
        Me.lblPaginaActual.Text = digi_pagina_actual


    End Sub



    Private Sub inicializarEscaner()

        Try

            If Not IO.Directory.Exists(Me.digi_rutaimagenes) Then
                IO.Directory.CreateDirectory(Me.digi_rutaimagenes)
            End If

            With AxImgScan1
                .ScanTo = ScanLibCtl.ScanToConstants.DisplayAndUseFileTemplate

                .Image = Me.digi_rutaimagenes & "\IML*"
                .FileType = 1
                .ScannerAvailable()
                .MultiPage = False
                .ShowSetupBeforeScan = True
                '.OpenScanner()
            End With


        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try




    End Sub

    Private Sub digi_insertarItemListview(ByVal pagina As String, ByVal nomarchivo As String)

        Dim item As New ListViewItem
        Dim subitem As New ListViewItem.ListViewSubItem

        item.Text = digi_pagina_actual

        item.SubItems(0).Text = pagina
        subitem.Text = nomarchivo
        subitem.Name = "NomArchivoTif"
        item.SubItems.Add(subitem)
        Me.ListView1.Items.Add(item)
        Me.ListView1.Refresh()


    End Sub

    Private Sub digi_mostrarImagenListView(ByVal ruta As String)

        Try

        
            Me.AxImgEdit1.Image = ruta
            Me.AxImgEdit1.FitTo(0)

            Me.AxImgEdit1.Display()
            Me.AxImgEdit1.Refresh()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub AxImgScan1_PageDone(ByVal sender As System.Object, ByVal e As AxScanLibCtl._DImgScanEvents_PageDoneEvent) Handles AxImgScan1.PageDone
        Debug.Print("Estoy imprimiento la pagina " & e.pageNumber)
        Try

            If digi_sustitucion = False Then
                digi_mostrarImagenListView(digi_rutaimagenes & "\IML" & Format(digi_pagina_actual, "0000#") & ".tif")

                digi_insertarItemListview(digi_pagina_actual, digi_rutaimagenes & "\IML" & Format(digi_pagina_actual, "0000#") & ".tif")

                digi_pagina_actual += 1
                Me.lblPaginaActual.Text = digi_pagina_actual
            End If

        Catch ex As Exception
            MessageBox.Show("Incidencia I02, ha ocurrido el siguiente error tras digitalizar la imagen  " & ex.ToString)
        End Try
    End Sub

    Private Sub AxImgScan1_ScanDone(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AxImgScan1.ScanDone
        Debug.Print("Estoy imprimiento la pagina ")
    End Sub





#Region " CONTROLES DEL PANEL "

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click

        Dim caracteristicas As ScanLibCtl.CompTypeConstants
        Dim compresion As ScanLibCtl.CompTypeConstants
        Try
            If Me.chkDesplzIncidencia.Checked Then
                AxImgScan1.ShowSelectScanner()
            End If
            AxImgScan1.OpenScanner()
            AxImgScan1.StartScan()
            Me.ListView1.Items(Me.ListView1.Items.Count - 1).Selected = True
            Me.ListView1.Items(Me.ListView1.Items.Count - 1).EnsureVisible()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Try

            AxImgScan1.CloseScanner()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        Try

            AxImgScan1.StopScan()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub tscmbConfigurar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tscmbConfigurar.Click
        'Try
        '    Dim frmmandoSaner As New frmMandoScaner(Me.AxImgScan1)
        '    frmmandoSaner.ShowDialog()
        'Catch ex As Exception
        '    MessageBox.Show(ex.ToString)
        'End Try
        MessageBox.Show("Esta opcion no esta habilitada para este proyecto.")
    End Sub

#End Region


    'generar caratula 
    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click

        'Dim ruta As String = Application.StartupPath & "\caratula.tif"
        'Dim nombre As String = "sin Nombre"
        'Dim apellido As String = "Sin apellido"
        'Dim nhc As String = "000"
        'Dim episodio As String = "999"
        'Dim aux As String = ""


        'Try
        '    Dim imagen As Image = clsCaratulaDigitalizacion.generarCaratula(My.Settings.cadenaConexion, frmContenedorMDI.oProyecto._codigoHospital, nombre, nhc, episodio, frmContenedorMDI.oProyecto._CodigoProyecto)
        '    'Dim finfo As New IO.FileInfo(ruta)
        '    'If finfo.Directory.Exists Then finfo.Directory.Create()
        '    AxImgScan1.Image = ""

        '    'If IO.File.Exists(ruta) Then IO.File.Delete(ruta)
        '    imagen.Save(digi_rutaimagenes & "\IML" & Format(digi_pagina_actual, "0000#") & ".tif", System.Drawing.Imaging.ImageFormat.Tiff)
        '    digi_insertarItemListview(digi_pagina_actual, digi_rutaimagenes & "\IML" & Format(digi_pagina_actual, "0000#") & ".tif")


        '    aux = digi_rutaimagenes & "\IML" & Format(digi_pagina_actual, "0000#") & ".tif"

        '    With AxImgEdit1
        '        .ClearDisplay()
        '        'PictureBox1.Refresh()
        '        .Image = aux
        '        .Display()
        '        .FitTo(1)
        '    End With

        '    digi_pagina_actual += 1

        'Catch ex As Exception
        '    MsgBox("No se pudo escribir la imagen en la ruta seleccionada" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Incidencia de aplicacion")
        'End Try

        Try
            Dim frmVentanaIndizacion As New frmIndizacionLote

            frmIndizacionLote.WindowState = FormWindowState.Normal

            frmIndizacionLote.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try

    End Sub

    
    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        Try
            If Not IsNothing(Me.ListView1.SelectedItems) Then

                digi_mostrarImagenListView(Me.ListView1.SelectedItems(0).SubItems(1).Text)
            End If
        Catch ex As Exception

        End Try
    End Sub



    Function imagen_rota() As Boolean
        'imagen_rotada = True
        Try

            With AxImgEdit1
                .RotateRight()
                .Save()
                .FitTo(0)
                '   If accesoDatosDocumentos.AtualizarEstadoDocumentoGirado(dt_documentos.Rows(grdDocumentos.CurrentRow.Index).Item("ID").ToString(), frmContenedorMDI.oUsuario._login, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto, frmContenedorMDI.oProyecto._NombreBaseDatos) Then
                'actulizamos el datagrid con valor 1 para que se vea que se ha girado 
                'dt_documentos.Rows(grdDocumentos.CurrentRow.Index).Item("girado") = "1"
                'dt_documentos.Rows(grdDocumentos.CurrentRow.Index).Item("Corregida") = "1"
                'End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Incidencia de aplicacion")
        End Try

    End Function


#Region "CONTROL DEL INICIO Y FIN DE LA SESION"


    Private Sub escribirInicioSesion()
        Dim stringInicioSescion As String = "=======INICIO DEL PROCESO DE CORRECCION=========" & vbCr

        stringInicioSescion &= "Usuario: " & digi_usuario & vbCr
        stringInicioSescion &= "Fecha: " & Date.Now.ToLongDateString & vbCr
        stringInicioSescion &= "Hora: " & Date.Now.ToLongTimeString & vbCr
        stringInicioSescion &= "======================================================" & vbCr

        editor.centrado(Me.RtbMensajes, stringInicioSescion)
    End Sub


    Private Sub escribirFinSesion()
        Dim stringInicioSescion As String = "=======fin del proceso correccion=========" & vbCr

        stringInicioSescion &= "Usuario: " & digi_usuario & vbCr
        stringInicioSescion &= "Fecha: " & Date.Now.ToLongDateString & vbCr
        stringInicioSescion &= "Hora: " & Date.Now.ToLongTimeString & vbCr
        stringInicioSescion &= "======================================================" & vbCr

        editor.centrado(Me.RtbMensajes, stringInicioSescion)
    End Sub


    Private Sub frmCorreccion_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        escribirFinSesion()
        Dim ruta As String = digi_rutaimagenes & "\digitalizacon" & digi_usuario & Replace(Date.Now.ToShortDateString, "/", "") & Replace(Date.Now.ToLongTimeString, ":", "") & ".rtf"
        Me.RtbMensajes.SaveFile(ruta, RichTextBoxStreamType.RichText)
        ' Me.RtbMensajes.SaveFile(ruta, RichTextBoxStreamType.UnicodePlainText)
        ' Me.RtbMensajes.SaveFile(ruta, RichTextBoxStreamType.PlainText)
    End Sub

#End Region

#Region "OPERACIONES ELIMINAR INSERTAR SUSTITUIR UN DOCUMENTO"

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        ToolStripButton1_Click(Nothing, Nothing)

    End Sub

    Private Sub btRedigi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btRedigi.Click



        Try

            editor.centrado(Me.RtbMensajes, "INICIO PROCESO REDIGITALIZACIon")
            editor.escribir(Me.RtbMensajes, "Reescaneando imagen " & Me.ListView1.SelectedItems(0).SubItems(1).Text)
            digi_sustitucion = True

            With AxImgScan1
                .ScanTo = ScanLibCtl.ScanToConstants.FileOnly

                .Image = Me.digi_rutaimagenes & "\" & New FileInfo(Me.ListView1.SelectedItems(0).SubItems(1).Text).Name
                .FileType = 1
                '.ScannerAvailable()
                '.MultiPage = False
                .PageOption = ScanLibCtl.PageOptionConstants.OverwritePages
                .ShowSetupBeforeScan = True
                '.OpenScanner()
            End With
            AxImgScan1.OpenScanner()
            AxImgScan1.StartScan()
            AxImgScan1.StopScan()



            With AxImgScan1
                .ScanTo = ScanLibCtl.ScanToConstants.DisplayAndUseFileTemplate

                .Image = Me.digi_rutaimagenes & "\IML*"
                .FileType = 1
                .PageOption = ScanLibCtl.PageOptionConstants.PromptToCreateNewFile
                .ScannerAvailable()
                .MultiPage = False
                .ShowSetupBeforeScan = True
                '.OpenScanner()
            End With



            Me.ListView1.SelectedItems(0).Selected = True
            'Me.ListView1.SelectedItems(0).EnsureVisible()
            digi_mostrarImagenListView(Me.ListView1.SelectedItems(0).SubItems(1).Text)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            digi_sustitucion = False
        End Try
    End Sub

    Private Sub cmbEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click

        Dim imagenActual As String = ""
        Dim rutaImagenActual As String = ""
        Dim numFicheros As Integer = 0
        Dim IndiceRegistroSEl As Integer = 0
        Dim indiceRegistros As Integer = 0
        Dim ficheros() As String
        Dim idlote As Integer = 0
        Dim pagina As Integer = 0
        Dim consultaSQL As String

        Dim pagIni As Integer
        Dim pagFin As Integer

        Dim ficheroOriginalNombreCompleto As String = ""
        Dim ficheroDestinoNombreCompleto As String = ""
        Dim ficheroOriginalNombre As String = ""
        Dim ficheroDestinoNombre As String = ""
        Dim metadatos As FileInfo

        Try

            If Not IsNothing(Me.ListView1.SelectedItems(0)) Then

                idlote = digi_lote
                pagina = Me.ListView1.SelectedItems(0).SubItems(0).Text
                pagIni = pagina
                imagenActual = New FileInfo(Me.ListView1.SelectedItems(0).SubItems(1).Text).Name
                rutaImagenActual = digi_rutaimagenes & "\" & imagenActual
                IndiceRegistroSEl = Me.ListView1.SelectedItems(0).Index

                'bloquearTodo(False)

                If MsgBox("Desea realmente eliminar el documento?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Atencion") = MsgBoxResult.Yes Then


                    numFicheros = Me.ListView1.Items.Count - (Me.ListView1.SelectedItems(0).Index + 1)
                    ReDim ficheros(numFicheros)

                    If numFicheros <> 0 Then  'si es 0 estamos en el ultimo elemento de la lista 
                        indiceRegistros = Me.ListView1.SelectedItems(0).Index + 1
                        For i As Integer = 0 To numFicheros - 1 'empiezas en el 0 
                            Debug.Print(Me.ListView1.Items(indiceRegistros).SubItems(1).Text)
                            metadatos = New FileInfo(Me.ListView1.Items(indiceRegistros).SubItems(1).Text)
                            ficheros(i) = metadatos.Name
                            Debug.Print(ficheros(i).ToString)
                            pagFin = Me.ListView1.Items(indiceRegistros).SubItems(0).Text
                            indiceRegistros += 1
                        Next

                    End If
                    editor.centrado(Me.RtbMensajes, "ELIMINANDO DOC " & imagenActual.ToUpper)



                    If fg.EliminarFichero(rutaImagenActual) Then

                        editor.escribir(Me.RtbMensajes, "eliminado doc." & imagenActual.ToUpper, Color.Green)

                    Else
                        editor.escribir(Me.RtbMensajes, "No se ha podido elimninar el documento ." & imagenActual.ToUpper, Color.Red)
                        editor.escribir(Me.RtbMensajes, "No se completado el proceso", Color.Red)
                        'GUARDAR LOG 
                        Exit Sub
                    End If


                    Application.DoEvents()
                    If numFicheros <> 0 Then 'si es 0 es el ultimo elemento de la lista 



                        'RENOMBRANDO FICHEROS 
                        editor.escribir(Me.RtbMensajes, "Renombrando ficheros", Color.Blue)

                        With pgOperaciones
                            .Minimum = 0
                            .Maximum = numFicheros - 1
                            .Value = 0
                        End With

                        For i As Integer = 0 To numFicheros - 1

                            ficheroOriginalNombre = ficheros(i)
                            ficheroDestinoNombre = "IML" & Format(Val(Mid(ficheroOriginalNombre, 4, 5)) - 1, "0000#") & ".tif"

                            ficheroOriginalNombreCompleto = digi_rutaimagenes & "\" & ficheroOriginalNombre
                            ficheroDestinoNombreCompleto = digi_rutaimagenes & "\" & ficheroDestinoNombre

                            editor.escribir(Me.RtbMensajes, ficheroOriginalNombre & "->" & ficheroDestinoNombre)


                            If Not fg.MoverFichero(ficheroOriginalNombreCompleto, ficheroDestinoNombreCompleto) Then

                                editor.escribir(Me.RtbMensajes, "Error al renombrar " & ficheroOriginalNombre & "->" & ficheroDestinoNombre, Color.Red)
                                Exit For

                            End If

                            pgOperaciones.Increment(1)
                            Application.DoEvents()

                        Next

                        Application.DoEvents()




                        pgOperaciones.Value = 0



                    End If

                    If Me.ListView1.SelectedItems(0).Index + 1 = Me.ListView1.Items.Count Then
                        actualizarLista(Me.ListView1.SelectedItems(0).Index - 1)
                    Else
                        actualizarLista(Me.ListView1.SelectedItems(0).Index)
                    End If

                    'Me.lista.avanzar()
                End If
                'bloquearTodo(True)
            Else
                MessageBox.Show("No ha seleccionado el registro a eliminar")
            End If
        Catch ex As Exception
            editor.escribir(Me.RtbMensajes, ex.Message.ToString, Color.Red)
        End Try


    End Sub

    Private Sub cmdSustituir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSustituir.Click

        Dim cargaImagen As New OpenFileDialog
        Dim ficheroOrigenNombre As String = ""
        Dim ficheroDestinoNombre As String = ""
        Dim ficheroOrigenNombreCompleto As String = ""
        Dim ficheroDestinoNombreCompleto As String = ""
        Dim metadatosFicheroOrigen As FileInfo = Nothing
        Dim metadatosFicheroDestino As FileInfo = Nothing
        Dim pagina As Integer = 0
        Dim indiceSel As Integer = 0

        cargaImagen.Title = "Seleccione una imagen para mostrar"
        cargaImagen.Filter = "Archivo TIF|*.TIF"
        cargaImagen.Multiselect = False

        Try


            If cargaImagen.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then

                metadatosFicheroOrigen = New FileInfo(cargaImagen.FileName)

                editor.centrado(Me.RtbMensajes, "INICIO PROCESO SUSTITUCION")

                ficheroOrigenNombre = metadatosFicheroOrigen.Name
                ficheroOrigenNombreCompleto = metadatosFicheroOrigen.FullName
                ficheroDestinoNombre = New FileInfo(Me.ListView1.SelectedItems(0).SubItems(1).Text).Name
                ficheroDestinoNombreCompleto = New FileInfo(Me.ListView1.SelectedItems(0).SubItems(1).Text).FullName
                pagina = Me.ListView1.SelectedItems(0).SubItems(0).Text
                indiceSel = Me.ListView1.SelectedItems(0).Index

                editor.escribir(Me.RtbMensajes, "Renommbrando " & ficheroOrigenNombre & "->" & ficheroDestinoNombre & " en la pagina " & pagina)

                If fg.CopiarFichero(ficheroOrigenNombreCompleto, ficheroDestinoNombreCompleto) Then
                    editor.escribir(Me.RtbMensajes, "proceso finalizado correctamente", Color.Green)
                Else
                    editor.escribir(Me.RtbMensajes, "error al sustituir no se ha podido reemplazar la imagen", Color.Red)
                End If
            Else
                MsgBox("No ha seleccionado una imagen", MsgBoxStyle.Critical, "Incidencia de aplicacion")

            End If


            Me.ListView1.SelectedItems(0).Selected = True
            'Me.ListView1.SelectedItems(0).EnsureVisible()
            digi_mostrarImagenListView(Me.ListView1.SelectedItems(0).SubItems(1).Text)



        Catch ex As Exception
            editor.escribir(Me.RtbMensajes, "Excep. sustituit: " & ex.Message.ToString)
        End Try

    End Sub

    ''isertar documento 
    Private Sub cmdAnyadir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bntAnyadir.Click

        Dim imagenActual As String = ""
        Dim rutaImagenActual As String = ""
        Dim rutaImagenInsertar As String = ""
        Dim numFicheros As Integer = 0
        Dim IndiceRegistroSEl As Integer = 0
        Dim indiceRegistros As Integer = 0
        Dim ficheros() As String
        Dim idlote As Integer = 0
        Dim pagina As Integer = 0
        Dim consultaSQL As String
        Dim metadatosFicheroOrigen As FileInfo

        Dim pagIni As Integer
        Dim pagFin As Integer

        Dim ficheroOriginalNombreCompleto As String = ""
        Dim ficheroDestinoNombreCompleto As String = ""
        Dim ficheroOriginalNombre As String = ""
        Dim ficheroDestinoNombre As String = ""


        Dim registro As DataRow
        Dim strSQl As String
        Dim strSQl2 As String

        Dim ficheroDestionInfo As FileInfo


        Try

            If Not IsNothing(Me.ListView1.SelectedItems(0)) Then

                idlote = digi_lote
                pagina = Me.ListView1.SelectedItems(0).SubItems(0).Text
                pagIni = pagina
                imagenActual = New FileInfo(Me.ListView1.SelectedItems(0).SubItems(1).Text).Name
                rutaImagenActual = New FileInfo(Me.ListView1.SelectedItems(0).SubItems(1).Text).FullName
                IndiceRegistroSEl = Me.ListView1.SelectedItems(0).Index

                'bloquearTodo(False)


                Dim cargaImagen As New OpenFileDialog

                cargaImagen.Title = "Seleccione imagen a insertar "
                cargaImagen.Filter = "Archivo TIF|*.TIF"
                cargaImagen.Multiselect = False

                If cargaImagen.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then
                    rutaImagenInsertar = cargaImagen.FileName
                    metadatosFicheroOrigen = New FileInfo(rutaImagenInsertar)
                Else
                    'bloquearTodo(True)
                    Exit Sub
                    'editor.escribir(Me.RtbMensajes, "Proceso cancelado por el usuario", Color.Red)
                End If


                numFicheros = (Me.ListView1.Items.Count - Me.ListView1.SelectedItems(0).Index)
                ReDim ficheros(numFicheros)

                If numFicheros <> 0 Then  'si es 0 estamos en el primer elemento de la lista 
                    indiceRegistros = Me.ListView1.SelectedItems(0).Index
                    For i As Integer = 0 To numFicheros - 1 'empiezas en el 0 
                        ficheroDestionInfo = New FileInfo(Me.ListView1.Items(indiceRegistros).SubItems(1).Text)
                        ficheros(i) = ficheroDestionInfo.Name
                        Debug.Print(ficheros(i).ToString)
                        pagFin = Me.ListView1.Items(indiceRegistros).SubItems(0).Text
                        indiceRegistros += 1
                    Next

                End If
                editor.centrado(Me.RtbMensajes, "INSERTANDO  DOC " & rutaImagenInsertar.ToUpper)



                Application.DoEvents()
                If numFicheros <> 0 Then 'si es 0 es el ultimo elemento de la lista 



                    'RENOMBRANDO FICHEROS 
                    editor.escribir(Me.RtbMensajes, "Renombrando ficheros", Color.Blue)

                    With pgOperaciones
                        .Minimum = 0
                        .Maximum = numFicheros - 1
                        .Value = 0
                    End With

                    For i As Integer = numFicheros - 1 To 0 Step -1

                        ficheroOriginalNombre = ficheros(i)
                        ficheroDestinoNombre = "IML" & Format(Val(Mid(ficheroOriginalNombre, 4, 5)) + 1, "0000#") & ".tif"

                        ficheroOriginalNombreCompleto = digi_rutaimagenes & "\" & ficheroOriginalNombre
                        ficheroDestinoNombreCompleto = digi_rutaimagenes & "\" & ficheroDestinoNombre

                        editor.escribir(Me.RtbMensajes, ficheroOriginalNombre & "->" & ficheroDestinoNombre)


                        If Not fg.MoverFichero(ficheroOriginalNombreCompleto, ficheroDestinoNombreCompleto) Then

                            editor.escribir(Me.RtbMensajes, "Error al renombrar " & ficheroOriginalNombre & "->" & ficheroDestinoNombre, Color.Red)
                            Exit For

                        End If

                        pgOperaciones.Increment(1)
                        Application.DoEvents()

                    Next

                    Application.DoEvents()


                    'RENOMBRANDO REGISTROS BASE DE DATOS 



                    pgOperaciones.Value = 0



                End If

                ficheroOriginalNombre = metadatosFicheroOrigen.Name
                ficheroDestinoNombre = imagenActual
                ficheroDestinoNombreCompleto = digi_rutaimagenes & "\" & ficheroDestinoNombre
                ficheroOriginalNombreCompleto = metadatosFicheroOrigen.FullName


                'COPIANDO EL FIHCERO EN EL DESTINO CORRESPONDIENTE 
                If fg.CopiarFichero(ficheroOriginalNombreCompleto, ficheroDestinoNombreCompleto) Then

                    editor.escribir(Me.RtbMensajes, "copianado  doc: " & ficheroOriginalNombre.ToUpper & " como " & ficheroDestinoNombre, Color.Green)

                Else
                    editor.escribir(Me.RtbMensajes, "No se ha podido copiar el documento ." & imagenActual.ToUpper, Color.Red)
                    editor.escribir(Me.RtbMensajes, "No se ha completado el proceso", Color.Red)
                    'GUARDAR LOG 

                    Exit Sub
                End If

                If Me.ListView1.SelectedItems(0).Index + 1 = Me.ListView1.Items.Count Then
                    actualizarLista(Me.ListView1.SelectedItems(0).Index - 1)
                Else
                    actualizarLista(Me.ListView1.SelectedItems(0).Index)
                End If
            Else
                MessageBox.Show("No ha seleccionado el registro a insertar")
            End If
        Catch ex As Exception
            editor.escribir(Me.RtbMensajes, ex.Message.ToString, Color.Red)
        End Try

    End Sub

#End Region

    Private Sub CtrlBotonGrande1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CtrlBotonGrande1.eClick

       

        Try


            If accesoDatosLotes.CerrarLoteParaDigitalizar(digi_usuario, digi_lote, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto) = 0 Then
                Exit Sub
            Else
                MessageBox.Show("El lote se ha cerrado correctamente")

            End If

            'inicializamos los datos 
            If Not IsNothing(frmContenedorMDI.oDocumento) Then frmContenedorMDI.oDocumento = Nothing
            If Not IsNothing(frmContenedorMDI.oFuncionAplicacion) Then frmContenedorMDI.oFuncionAplicacion = Nothing
            If Not IsNothing(frmContenedorMDI.oLote) Then frmContenedorMDI.oLote = Nothing
            If Not IsNothing(frmContenedorMDI.oProyecto) Then frmContenedorMDI.oProyecto = Nothing

            frmContenedorMDI.numeroHojaMaxima = 0

            Me.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try


    End Sub

    Private Sub cmbRotar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbRotar.Click
        imagen_rota()
    End Sub

    Private Sub chkDesplzIncidencia_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDesplzIncidencia.CheckedChanged

    End Sub
End Class