Imports Digitalización.Entidades
Imports accesoDatosDocumentos = LibreriaCadenaProduccion.Datos.Produccion.cadenaproduccion.clsAccesoDatosDocumento
Imports accesoDatosNew = Digitalización.accesoDatosNuevos.clsAccesoDatosNUEVO
Imports System.IO
Imports System.Drawing.Drawing2D
Imports fg = LibreriaCadenaProduccion.FuncionesGlobales.Carpetas
Imports System.Drawing.Imaging

Public Class frmDigitalizacionTwain

    Dim oLote As Entidades.clsLoteE
    Dim oDocumentoActivo As Entidades.clsDocumentoE
    Dim oListaDocumentos As List(Of clsDocumentoE)
    Dim anchoForm As Integer

    Dim cargandoGrid As Boolean = False

    Dim rutaDirSustitucion As String = My.Settings.DIGI_rutaLocalImagenes & "\SUSTITUCION"

    Dim listaDocBd As New List(Of String)
    Dim listaDocDir As New List(Of String)

    Dim digitalizando As Boolean = False

    Dim xMiniatura As Integer = 0
    Dim yMiniatura As Integer = 0
    Dim yAltoMaximoLinea As Integer = 0

    Dim m_gp As GraphicsPath
    Dim m_imagen As Bitmap

    Dim recargaMiniaturas As Boolean = False
    ''Dim obligaRecargaMiniaturas As Boolean = True  'Tiene función parecida a recargaMiniatura, la cree nueva porque utilizar recargaMiniatura me supondría revisar todo el código fuente y el funcionamiento podría variar.
    Dim giraGrados As Boolean = False

    Dim cargadasImagenesBlancas As Boolean = False

    Dim imagenOriginal As Image    '' FileStream
    ' ''Dim imagenOriginal As Bitmap

    Dim WithEvents pb As PictureBox

    Dim cadenaConexionProyecto As String = ""
    Dim rutaImagenes As String = ""
    Dim codigoProyecto As String = ""
    Dim loginUsuario As String = ""
    Dim idLote As String = ""

    Private Sub frmDigitalizacionTwain_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        ' ''Me.Refresh()

        ' ''Dim mensaje As String = compruebaDocServidorSinBD()

        ' ''If mensaje.ToString.Trim <> "" Then
        ' ''    MessageBox.Show("Existen más documentos en el servidor que los insertados en base de datos. Revíse las siguientes páginas:" & vbCrLf & mensaje, "Ficheros en servidor sin grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ' ''    ' ''ToolStripStatusLabel1.Text = "Existe más documentos digitalizados de los que hay grabados en base de datos."
        ' ''    ' ''ToolStripStatusLabel1.ForeColor = Color.Red
        ' ''End If

    End Sub

    Private Sub frmDigitalizacionTwain_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            'Descargo controles para que no se saturen los Objetos de Usuario y muestre el eror de "Error al crear identificador de ventana"
            For Each png As PictureBox In pnlPresentacion3.Controls()
                png.Dispose()
            Next

            GC.Collect()
            GC.WaitForPendingFinalizers()

            cerrarProcesoActivo(aplicacionEscaneo)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmDigitalizacionTwain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            Me.Cursor = Cursors.WaitCursor

            inicializaControles()
            inicializaCampos()

            configuraGrid()

            cargaComboTipoLote(codigoProyecto, cboTipoLote)

            cargarDatosLote()

            compruebCreaDirectoriosNecesarios()

            cargarListaDocumentos(1)

            
            tsbImagen1_Click(tsbImagen1, Nothing)
            tsbAjuste1_Click(tsbAjuste1, Nothing)

            Me.Cursor = Cursors.Default

        Catch ex As Exception
            Dim mensajeEX As String = ""
            'Excepción interna
            If ex.InnerException IsNot Nothing Then
                mensajeEX = " Inner exception: " & ex.InnerException.Message
            End If
            escribirEnLog("*** ERROR USUARIO. " & Now & ". Lote " & lblLote.Text & ". Ocurrió un error al cargar el formulario de digitalización." & vbLf & ex.Message & vbLf & mensajeEX & vbLf & ex.StackTrace)

            MessageBox.Show("Ocurrió un error al cargar el formulario de digitalización." & vbLf & vbCr & ex.Message, "Error al cargar formulario", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End
        End Try

    End Sub

    Private Sub inicializaControles()

        Dim toolTip1 As ToolTip = New System.Windows.Forms.ToolTip()
        toolTip1.SetToolTip(cmdDigitalizar, "Digitalizar documentos")
        toolTip1.SetToolTip(cmdGuardar, "Guardar número de historia en documento/s seleccionado/s")
        toolTip1.SetToolTip(cmdPorcentajeNegro, "Establecer porcentaje de negro de la imagen seleccionada.")
        toolTip1.SetToolTip(lstNHC, "Nº de historias preparadas en el lote. Haga doble click en cualquier de ellas y la llevará al campo NHC.")
        toolTip1.SetToolTip(nudGrados, "Gira la imagen los grados especificados.")
        toolTip1.SetToolTip(cmdAyuda, "Mostrar guía rápida de ayuda.")

        'Panel1.Top = IMGeditPrincipal.Top
        Panel1.Left = IMGeditPrincipal.Left + IMGeditPrincipal.Width + 50

        pnlPresentacion1.Height = Me.Height - (tstTipoPresentacion.Height + 40) '''(StatusStrip1.Height + 60)
        pnlPresentacion1.Width = Me.Width - (Panel1.Width + 20)   ' + 10)
        IMGeditPrincipal.Height = pnlPresentacion1.Height - 10 '- 50
        IMGeditPrincipal.Width = pnlPresentacion1.Width - 50
        IMGeditPrincipal.Top = 5 '' pnlPresentacion1.Top
        IMGeditPrincipal.Left = 0 '' pnlPresentacion1.Left

        pnlPresentacion2.Height = Me.Height - (StatusStrip1.Height + 60)
        pnlPresentacion2.Width = Me.Width - (Panel1.Width + 10)
        pnlPresentacion2.Top = pnlPresentacion1.Top
        pnlPresentacion2.Left = pnlPresentacion1.Left
        ImgEditIzquierda.Width = (pnlPresentacion2.Width / 2) '- 50
        ImgEditIzquierda.Height = pnlPresentacion2.Height - 10
        imgEditDerecha.Width = (pnlPresentacion2.Width / 2) '- 50
        imgEditDerecha.Height = pnlPresentacion2.Height - 10
        ImgEditIzquierda.Top = 5
        ImgEditIzquierda.Left = 0
        imgEditDerecha.Top = 5
        imgEditDerecha.Left = ImgEditIzquierda.Width

        pnlPresentacion3.Height = pnlPresentacion1.Height
        pnlPresentacion3.Width = pnlPresentacion1.Width
        pnlPresentacion3.Top = pnlPresentacion1.Top
        pnlPresentacion3.Left = pnlPresentacion1.Left

        dgv.Height = Panel1.Height - (dgv.Top + cmdCerrarLote.Height + ToolStripStatusLabel1.Height + 20)

        cmdCerrarLote.Top = dgv.Top + dgv.Height + 10
        cmdCerrarLote.Left = dgv.Left + dgv.Width - cmdCerrarLote.Width

        cmdGuardarDocumentos.Top = cmdCerrarLote.Top
        cmdSincronizar.Top = cmdCerrarLote.Top

        ToolStripStatusLabel1.Width = Panel1.Width / 1.5
        ToolStripStatusLabel1.Text = ""

        ToolStripProgressBar1.Width = Panel1.Width - ToolStripStatusLabel1.Width

        tstMoverRegistros.Left = Me.Width - (Panel1.Width + tstMoverRegistros.Width + 30)

        ProgressBar1.Left = tstTipoAjuste.Left + tstTipoAjuste.Width + 100
        ProgressBar1.Width = tstMoverRegistros.Left - (ProgressBar1.Left + 100)
        lblProgressBar.Left = ProgressBar1.Left
        lblProgressBar.Width = ProgressBar1.Width
        ProgressBar1.Visible = False
        lblProgressBar.Visible = False


        If My.Settings.DIGI_modificar_NHC Then
            txtNHC.Visible = True
            cmdGuardar.Visible = True
            Label6.Visible = True
            lstNHC.Visible = True
            Label7.Visible = True
        Else
            txtNHC.Visible = False
            cmdGuardar.Visible = False
            Label6.Visible = False
            lstNHC.Visible = False
            Label7.Visible = False
        End If

        If My.Settings.DIGI_TIPOLOTE_modificar Then
            cboTipoLote.Enabled = True
        Else
            cboTipoLote.Enabled = False
        End If

        If My.Settings.DIGI_Muestra_Perfiles Then
            chkPerfiles.Checked = True
        Else
            chkPerfiles.Checked = False
        End If

    End Sub

    Private Sub inicializaCampos()

        'Carga campos del formulario general MDI
        cadenaConexionProyecto = frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto
        rutaImagenes = frmContenedorMDI.oProyecto._rutaImagenes
        codigoProyecto = frmContenedorMDI.oProyecto._CodigoProyecto
        loginUsuario = frmContenedorMDI.oUsuario._login
        idLote = frmContenedorMDI.oLote._idlote
        '****************************************

        lblLotesUsuario.Text = ""

        lblLote.Text = ""
        cboTipoLote.Text = ""
        lblPaginasLote.Text = ""

        lblIdDocumento.Text = ""
        lblPaginaDocumento.Text = ""
        lblNombreDocumento.Text = ""
        txtNHC.Text = ""

        tstPorcentajeNegro.Text = My.Settings.DIGI_porcentaje_pixel_negro

        lstNHC.Items.Clear()
        dgv.Rows.Clear()

    End Sub

    Private Sub frmDigitalizacionTwain_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize

        inicializaControles()

    End Sub

    Private Sub mostrarImagen(ByVal control As PictureBox, ByVal ruta As String)
        Dim timeOut As Integer = 5
        Dim horaInicio As DateTime = Now

        If ruta = "" Then
            ruta = My.Application.Info.DirectoryPath & "\ImagenDocumentoNocargado.TIF"
        End If

        Dim generacionCorrecta As Boolean = False

        'Hago este bucle porque cuando se digitalizan imágenes a color, el programa va más rápido que la creación de un fichero 
        'grande a color y daba error de memoria insuficiente pero realmente el error era que ya se estaba utilizando el fichero del parámetro sPath
        Do
            Try
                Using fs As New System.IO.FileStream(ruta, System.IO.FileMode.Open, System.IO.FileAccess.Read)

                    imagenOriginal = Image.FromStream(fs)

                    control.Image = Image.FromStream(fs)

                End Using

                generacionCorrecta = True

            Catch ex As Exception
                '' '' ''Dim fs2 As System.IO.FileStream = New System.IO.FileStream(My.Application.Info.DirectoryPath & "\ImagenDocumentoNocargado.TIF", System.IO.FileMode.Open)
                ' ''Using fs2 As New System.IO.FileStream(My.Application.Info.DirectoryPath & "\ImagenDocumentoNocargado.TIF", System.IO.FileMode.Open, System.IO.FileAccess.Read)
                ' ''    imagenOriginal = Image.FromStream(fs2)
                ' ''    control.Image = Image.FromStream(fs2)
                ' ''End Using
            Finally
                'Si han pasado los segundos indicados en la variable timeOut, salgo del bucle para que no se haga infinito y muestro la imagen comodín.
                If horaInicio.AddSeconds(timeOut) < Now Then
                    generacionCorrecta = True

                    Using fs As New System.IO.FileStream(My.Application.Info.DirectoryPath & "\ImagenDocumentoNocargado.TIF", System.IO.FileMode.Open, System.IO.FileAccess.Read)

                        imagenOriginal = Image.FromStream(fs)

                        control.Image = Image.FromStream(fs)

                    End Using
                End If
            End Try
        Loop Until generacionCorrecta = True

    End Sub

    Private Sub mostrarImagen_ANTES_20200529(ByVal control As PictureBox, ByVal ruta As String)
        Dim fs As System.IO.FileStream

        Try
            If ruta = "" Then
                fs = New System.IO.FileStream(My.Application.Info.DirectoryPath & "\ImagenDocumentoNocargado.TIF", System.IO.FileMode.Open)
            Else
                Try
                    fs = New System.IO.FileStream(ruta, System.IO.FileMode.Open)
                Catch ex As Exception
                    fs = New System.IO.FileStream(My.Application.Info.DirectoryPath & "\ImagenDocumentoNocargado.TIF", System.IO.FileMode.Open)
                End Try
            End If

            imagenOriginal = Image.FromStream(fs)   ''New Bitmap(oDocumentoActivo._rutaDocumento)

            control.Image = Image.FromStream(fs)

            fs.Close()

        Catch ex As Exception

            ''ToolStripStatusLabel1.ForeColor = Color.Red
            ''ToolStripStatusLabel1.Text = "Error al mostrar imagen"
        End Try

    End Sub

    Private Sub cargarDatosLote()

        oLote = New Entidades.clsLoteE(idLote, codigoProyecto)

        lblLote.Text = oLote._Lote
        cboTipoLote.Text = oLote._tipoLote
        lblPaginasLote.Text = oLote._TotalImagenes

        oListaDocumentos = oLote._ListaDocumentos

        lstNHC.Items.Clear()

        For Each loteado As clsLoteadoE In oLote.obtenerLoteado(oLote._Lote)
            lstNHC.Items.Add(loteado._NumeroHistoria)
        Next

        If lstNHC.Items.Count = 0 Then
            ToolStripStatusLabel1.ForeColor = Color.Red
            ToolStripStatusLabel1.Text = "El lote no está preparado."
            StatusStrip1.Refresh()
            Application.DoEvents()
        End If

    End Sub

    Private Sub cargarDatosDocumento()

        If IsNothing(oDocumentoActivo) Then
            lblIdDocumento.Text = ""
            lblPaginaDocumento.Text = ""
            lblNombreDocumento.Text = ""
            txtNHC.Text = ""
        Else
            lblIdDocumento.Text = oDocumentoActivo._idDocumento
            lblPaginaDocumento.Text = oDocumentoActivo._pagina

            If oDocumentoActivo._pagina <> lblPaginaDocumento.Text Then
                nudGrados.Value = 0
            End If

            lblNombreDocumento.Text = oDocumentoActivo._nombreArchivo
            txtNHC.Text = IIf(oDocumentoActivo._historia.ToString.Trim = 0, "", oDocumentoActivo._historia.ToString.Trim)
        End If

        giraGrados = False

        giraGrados = True

    End Sub

    Private Sub cargarListaDocumentos(ByVal posicionaEnPagina As Integer)
        Dim lsSqlCargaDocumentos As String = "SELECT * FROM DOCUMENTOS d LEFT JOIN TIPOSDOCUMENTOS td ON td.idTipoDocumento = d.TipoDocumento LEFT JOIN SERVICIOS s on s.idServicio = d.CodServicioPAED WHERE idLote=" & lblLote.Text.ToString.Trim & " ORDER BY PAGINA"
        Dim contador As Integer
        Dim lista As List(Of clsDocumentoE)
        Try

            oListaDocumentos.Clear()

            oListaDocumentos = accesoDatosNuevos.clsAccesoDatosNUEVO.cargaDocumentos(cadenaConexionProyecto, lsSqlCargaDocumentos, codigoProyecto, rutaImagenes)

            oLote._ListaDocumentos = oListaDocumentos

            cargandoGrid = True

            dgv.Rows.Clear()

            'Comprueba si hay documentos en el servidor pero no están en la base de datos.
            Dim mensaje As String = compruebaDocServidorSinBD()
            If mensaje.ToString.Trim <> "" Then
                'MessageBox.Show("Existen más documentos en el servidor que los insertados en base de datos. Revíse las siguientes páginas:" & vbCrLf & mensaje, "Ficheros en servidor sin grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ' ''ToolStripStatusLabel1.Text = "Existe más documentos digitalizados de los que hay grabados en base de datos."
                ' ''ToolStripStatusLabel1.ForeColor = Color.Red
            End If

            If Not IsNothing(oListaDocumentos) Then
                For Each doc As clsDocumentoE In oListaDocumentos

                    dgv.Rows.Add()
                    dgv.Rows(contador).Cells(0).Value = doc._idDocumento
                    dgv.Rows(contador).Cells(1).Value = doc._pagina
                    dgv.Rows(contador).Cells(2).Value = doc._nombreArchivo
                    dgv.Rows(contador).Cells(3).Value = IIf(doc._historia = 0, "", doc._historia)

                    contador += 1
                Next
            End If

            'Comprueba si hay documentos en local digitalizados pero no guardados en BD
            lista = compruebaDocLocalSinBD()

            If Not IsNothing(lista) Then
                For Each doc As clsDocumentoE In lista

                    dgv.Rows.Add()
                    dgv.Rows(contador).Cells(0).Value = doc._idDocumento
                    dgv.Rows(contador).Cells(1).Value = doc._pagina
                    dgv.Rows(contador).Cells(2).Value = doc._nombreArchivo
                    dgv.Rows(contador).Cells(3).Value = IIf(doc._historia = 0, "", doc._historia)

                    'Añade elemento a lista general
                    oListaDocumentos.Add(doc)

                    contador += 1
                Next
            End If
            '****************************************************************************

            oLote._TotalImagenes = contador
            lblPaginasLote.Text = oLote._TotalImagenes

            cargandoGrid = False
            cargadasImagenesBlancas = False
            digitalizando = False

            'Posiciona el grid según el parámetro indicado
            If dgv.Rows.Count > 0 Then
                BuscarEnGridLINQ(posicionaEnPagina.ToString.Trim, "Pagina", dgv)
                If Not IsNothing(dgv.CurrentRow) Then
                    If dgv.CurrentRow.Index >= 0 Then
                        posicionarRegistro(dgv.CurrentRow.Index)
                    Else
                        posicionarRegistro(0)
                    End If
                Else
                    posicionarRegistro(0)
                End If
            Else
                pnlPresentacion1.Visible = False
                pnlPresentacion2.Visible = False
                pnlPresentacion3.Visible = False
            End If
            '*********************************************

            lblLotesUsuario.Text = obtenerLotesImagenesPorUsuarioHoy()

            Label9.Text = dgv.Rows.Count & " páginas."

        Catch ex As Exception
            Dim mensajeEX As String = ""
            'Excepción interna
            If ex.InnerException IsNot Nothing Then
                mensajeEX = " Inner exception: " & ex.InnerException.Message
            End If
            escribirEnLog("*** ERROR. " & Now & ". Ocurrió un error en cargarListaDocumentos." & vbLf & vbLf & ex.Message & vbLf & mensajeEX & vbLf & ex.StackTrace)

            Throw ex
        End Try

    End Sub

    Private Sub cargarListaDocumentosBlancos()
        Dim contador As Integer

        Try

            cargandoGrid = True

            dgv.Rows.Clear()

            If Not IsNothing(oListaDocumentos) Then
                For Each doc As clsDocumentoE In oListaDocumentos

                    dgv.Rows.Add()
                    dgv.Rows(contador).Cells(0).Value = doc._idDocumento
                    dgv.Rows(contador).Cells(1).Value = doc._pagina
                    dgv.Rows(contador).Cells(2).Value = doc._nombreArchivo
                    dgv.Rows(contador).Cells(3).Value = IIf(doc._historia = 0, "", doc._historia)

                    contador += 1
                Next
            End If

            cargandoGrid = False
            digitalizando = False
            cargadasImagenesBlancas = True

            'Posiciona el grid según el parámetro indicado
            If dgv.Rows.Count > 0 Then
                BuscarEnGridLINQ(1, "Pagina", dgv)
                posicionarRegistro(dgv.CurrentRow.Index)
            Else
                pnlPresentacion1.Visible = False
                pnlPresentacion2.Visible = False
                pnlPresentacion3.Visible = False
            End If
            '*********************************************

            Label9.Text = dgv.Rows.Count & " páginas."

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub configuraGrid()

        dgv.AllowUserToAddRows = False
        dgv.AllowUserToDeleteRows = True
        dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None
        dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing

        ' ''dgv.Location = New System.Drawing.Point(6, 19)
        dgv.Name = "dgv"
        dgv.ReadOnly = True
        ' ''dgv.Size = New System.Drawing.Size(540, 206)
        dgv.TabIndex = 2

        'colID
        colidDocumento.HeaderText = "id Documento"
        colidDocumento.DataPropertyName = "_idDocumento"
        colidDocumento.Name = "idDocumento"
        colidDocumento.ReadOnly = True
        colidDocumento.Visible = True
        colidDocumento.Width = 0 ' 100
        ' ''dgv.Columns.Add(colidDocumento)

        colPagina.HeaderText = "Nº Pag"
        colPagina.DataPropertyName = "_pagina"
        colPagina.Name = "pagina"
        colPagina.SortMode = DataGridViewColumnSortMode.Automatic
        colPagina.ReadOnly = True
        colPagina.Visible = True
        colPagina.Width = 75
        ' ''dgv.Columns.Add(colPagina)

        colNombre.HeaderText = "Nombre"
        colNombre.DataPropertyName = "_nombreArchivo"
        colNombre.Name = "nomArchivo"
        colNombre.SortMode = DataGridViewColumnSortMode.Automatic
        colNombre.ReadOnly = True
        colNombre.Visible = True
        colNombre.Width = 150
        ' ''dgv.Columns.Add(colNombre)

        'colPatientName
        colNHC.HeaderText = "NHC"
        colNHC.DataPropertyName = "_historia"
        colNHC.Name = "numHistoria"
        colNHC.SortMode = DataGridViewColumnSortMode.Automatic
        colNHC.ReadOnly = True
        colNHC.Visible = True
        colNHC.Width = 100
        ' ''dgv.Columns.Add(colNHC)

    End Sub

    Private Sub dgv_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv.Click
        Me.Cursor = Cursors.WaitCursor

        If dgv.Rows.Count > 0 And dgv.SelectedRows.Count = 1 Then

            posicionarRegistro(dgv.CurrentRow.Index)

        End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmdCerrarLote_eClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCerrarLote.eClick
        Dim mensaje As String = ""
        Dim listaDoc As List(Of clsDocumentoE)

        Try
            Me.Cursor = Cursors.WaitCursor

            'Realiza comprobaciones
            If My.Settings.DIGI_modificar_NHC Then
                'Comprueba si todas las páginas tienen NHC
                listaDoc = (From documento As clsDocumentoE In oListaDocumentos Where CInt(documento._historia) > 0).ToList
                If listaDoc.Count > 0 Then
                    If listaDoc.Count <> oListaDocumentos.Count Then
                        MessageBox.Show("Es obligatorio que todas las páginas tengan el número de historia para cerrar el lote." & vbCrLf & mensaje, "Cerrar Lote", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                End If
            End If

            If My.Settings.DIGI_TIPOLOTE_validar_al_cerrar_lote Then
                If cboTipoLote.Text.ToString.Trim = "" Then
                    MessageBox.Show("Es obligatorio especificar el tipo de lote para cerrar el lote." & vbCrLf & mensaje, "Cerrar Lote", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If
            '**********************

            Try
                guardaEnBdDocumentos()

                refrescarLista(1)

                marcaInicioHistorias()

                refrescarLista(1)

            Catch ex As Exception
                Dim mensajeEX As String = ""
                'Excepción interna
                If ex.InnerException IsNot Nothing Then
                    mensajeEX = " Inner exception: " & ex.InnerException.Message
                End If
                escribirEnLog("*** ERROR USUARIO. " & Now & ". Lote " & lblLote.Text & ". Ocurrió un error al guardar los documentos al cerrar el lote." & vbLf & ex.Message & vbLf & mensajeEX & vbLf & ex.StackTrace)
                refrescarLista(1)
                MessageBox.Show("Ocurrió un error al guardar los documentos." & vbCrLf & ex.Message, "Error al cerrar lote", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

            mensaje = repaginar()

            If mensaje.ToString.Trim = "" Then

                refrescarLista(1)

                'Sincronizar
                Try
                    sincronizar()

                Catch ex As Exception
                    Dim mensajeEX As String = ""
                    'Excepción interna
                    If ex.InnerException IsNot Nothing Then
                        mensajeEX = " Inner exception: " & ex.InnerException.Message
                    End If
                    escribirEnLog("*** ERROR USUARIO. " & Now & ". Lote " & lblLote.Text & ". Ocurrió un error al sincronizar los documentos con el servidor." & vbLf & ex.Message & vbLf & mensajeEX & vbLf & ex.StackTrace)

                    MessageBox.Show("Ocurrió un error al sincronizar los documentos con el servidor." & vbCrLf & ex.Message, "Cerrar Lote", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End Try

                mensaje = compruebaIntegridadParaCerrar()
                If mensaje.ToString.Trim <> "" Then
                    MessageBox.Show("La integridad del lote no es correcta. El lote no puede cerrarse por el/los siguiente/s motivo/s:" & vbLf & mensaje, "Cerrar Lote", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                'Cierra lote
                If MessageBox.Show("Desea cerrar el lote  " & lblLote.Text.ToString.Trim & ". Si cierra el lote, éste pasará a la siguiente fase y no podrá continuar digitalizando documentos dentro del lote. En el caso contrario podrá seleccionarlo nuevamente para continuar con el proceso de digitalización.", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                    LibreriaCadenaProduccion.Datos.Produccion.cadenaproduccion.clsAccesoDatosLote.CerrarLoteParaDigitalizar(loginUsuario, lblLote.Text.ToString.Trim, cadenaConexionProyecto)

                    'Borrar miniaturas de local y del servidor
                    borrarMiniaturas(1)

                    'Borra directorio miniaturas del servidor
                    Try
                        If Directory.Exists(rutaImagenes & "\" & Format(Val(oLote._codigoProyecto), "0000") & "\DIGI\" & Format(Val(oLote._codigoProyecto), "0000") & Format(Val(oLote._Lote), "00000") & "\Imagen\" & idLote & "\MINIATURAS") Then
                            Directory.Delete(rutaImagenes & "\" & Format(Val(oLote._codigoProyecto), "0000") & "\DIGI\" & Format(Val(oLote._codigoProyecto), "0000") & Format(Val(oLote._Lote), "00000") & "\Imagen\" & idLote & "\MINIATURAS", True)
                        End If
                    Catch ex As Exception

                    End Try

                    'Borra directorio local del lote
                    If Directory.Exists(My.Settings.DIGI_rutaLocalImagenes & "\" & Format(Val(oLote._codigoProyecto), "0000") & "\DIGI\" & Format(Val(oLote._codigoProyecto), "0000") & Format(Val(oLote._Lote), "00000")) Then
                        Try
                            Directory.Delete(My.Settings.DIGI_rutaLocalImagenes & "\" & Format(Val(oLote._codigoProyecto), "0000") & "\DIGI\" & Format(Val(oLote._codigoProyecto), "0000") & Format(Val(oLote._Lote), "00000"), True)
                        Catch ex As Exception
                            Directory.Delete(My.Settings.DIGI_rutaLocalImagenes & "\" & Format(Val(oLote._codigoProyecto), "0000") & "\DIGI\" & Format(Val(oLote._codigoProyecto), "0000") & Format(Val(oLote._Lote), "00000"), True)
                        End Try
                    End If

                    MessageBox.Show("Lote cerrado.", "Cerrar Lote", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Me.Close()

                End If
                ''**********************************************************************

            Else
                MessageBox.Show("Ocurrió un error al repaginar antes de cerrar el lote. El lote no puede cerrarse. Contacte con el servicio de informática." & vbCrLf & mensaje, "Error al cerrar lote", MessageBoxButtons.OK, MessageBoxIcon.Error)
                escribirEnLog("*** ERROR USUARIO. " & Now & ". Lote " & lblLote.Text & ". Ocurrió un error al repaginar antes de cerrar el lote." & vbCrLf & mensaje)
            End If

        Catch ex As Exception
            Dim mensajeEX As String = ""
            'Excepción interna
            If ex.InnerException IsNot Nothing Then
                mensajeEX = " Inner exception: " & ex.InnerException.Message
            End If
            escribirEnLog("*** ERROR USUARIO. " & Now & ". Lote " & lblLote.Text & ". Ocurrió un error al cerrar el lote." & vbLf & ex.Message & vbLf & mensajeEX & vbLf & ex.StackTrace)

            MessageBox.Show("Ocurrió un error al cerrar el lote." & vbCrLf & ex.Message, "Error al cerrar lote", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub dgv_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgv.MouseDown
        Try
            ' verifica que se presionó el botón derecho   
            If e.Button = Windows.Forms.MouseButtons.Right Then
                If (Me.dgv.SelectedRows.Count > 0) Then
                    Me.menuDocumentos.Show(Me.dgv, e.Location)
                End If

            End If
        Catch ex As Exception
            MessageBox.Show("Ocurrio un error al mostar el menu contextual")
        End Try
    End Sub

    Private Sub mnuRotaImagen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRotaImagen.Click
        tsbAccion3_Click(Nothing, Nothing)
    End Sub

    Private Sub dgv_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgv.KeyDown

        ' ''Me.Cursor = Cursors.WaitCursor

        ' ''e.Handled = True

        ' ''Select Case e.KeyCode

        ' ''    Case Keys.Home
        ' ''        tsbRegistroPrimero_Click(dgv, Nothing)

        ' ''    Case Keys.End
        ' ''        tsbRegistroUltimo_Click(dgv, Nothing)

        ' ''        '''LAS TECLAS DE LAS FLECHAS ARRIBA Y ABAJO ESTÁN EN EL EVENTO KEYUP

        ' ''    Case Keys.S     'Sustituir imagen
        ' ''        tsbAccion1_Click(Nothing, Nothing)

        ' ''    Case Keys.I     'Insertar imagen
        ' ''        tsbAccion5_Click(Nothing, Nothing)

        ' ''    Case Keys.NumPad4   'Borrar documento
        ' ''        'Eliminar documento FISICAMENTE
        ' ''        tsbAccion2_Click(Nothing, Nothing)

        ' ''    Case Keys.NumPad2   'Documento en mal estado
        ' ''        tsbAccion4_Click(Nothing, Nothing)

        ' ''    Case Keys.Add   'Rotar 90 derecha
        ' ''        tsbAccion3_Click(Nothing, Nothing)

        ' ''    Case Keys.Subtract   'Rotar 90 izquierda
        ' ''        tsbAccion7_Click(Nothing, Nothing)

        ' ''    Case Keys.F5  'Rfrescar
        ' ''        cmdRecargarLista_Click(Nothing, Nothing)

        ' ''End Select

        ' ''e.Handled = False

        ' ''Me.Cursor = Cursors.Default

    End Sub

    Private Sub cargarMiniaturas(ByVal listaDoc As List(Of clsDocumentoE))

        Dim x As Integer = 3
        Dim y As Integer = 3
        Dim anchoAcumulado As Integer = 0
        Dim altoAcumulado As Integer = 0
        Dim altoMaximoLinea As Integer = 0
        Dim rutaPng As String = ""
        Dim nuevaLinea As Boolean = False
        ' ''Dim img As System.Drawing.Image
        Dim ancho, alto As Integer
        Dim contador As Integer = 0
        Dim bordePicture As Integer = 5
        Dim toolTip1 As ToolTip = New System.Windows.Forms.ToolTip()
        Dim imgHeight As Integer = 0
        Dim imgWidth As Integer = 0

        Try
            If Not IsNothing(listaDoc) Then

                ''If obligaRecargaMiniaturas = False Then Exit Sub

                ToolStripProgressBar1.Maximum = listaDoc.Count
                ToolStripProgressBar1.Value = 0

                ProgressBar1.Visible = True
                lblProgressBar.Visible = True
                lblProgressBar.Text = "Cargando miniaturas..."
                ProgressBar1.Maximum = listaDoc.Count
                Application.DoEvents()

                If pnlPresentacion3.Controls.Count <> dgv.Rows.Count Or anchoForm <> Me.Width Or recargaMiniaturas Then
                    'En este caso no continua porque es el caso de que están cargadas las imagenes en blanco.
                    ' ''If cargadasImagenesBlancas = True And recargaMiniaturas = False Then Exit Sub

                    compruebCreaDirectoriosNecesarios()

                    'Descargo controles para que no se saturen los Objetos de Usuario y muestre el eror de "Error al crear identificador de ventana"
                    For Each png As PictureBox In pnlPresentacion3.Controls()
                        png.Parent = Nothing
                        png.Dispose()
                        png = Nothing
                    Next

                    pnlPresentacion3.Controls.Clear()

                    For Each doc As clsDocumentoE In listaDoc

                        contador += 1
                        ProgressBar1.Value = contador

                        rutaPng = doc._rutaDocumento.Replace("\" & doc._Lote.ToString.Trim, "\" & doc._Lote.ToString.Trim & "\MINIATURAS").ToUpper.Replace(".TIF", ".png")

                        pb = New PictureBox

                        ' ''Try
                        If IO.File.Exists(rutaPng) Then
                            Using fs As New System.IO.FileStream(rutaPng, System.IO.FileMode.Open, System.IO.FileAccess.Read)

                                Using img As Image = Image.FromStream(fs)
                                    nuevaLinea = CInt(x + (img.Width) + bordePicture) + 20 > CInt(pnlPresentacion3.Width)

                                    imgHeight = img.Height
                                    imgWidth = img.Width
                                End Using

                            End Using
                        Else
                            ancho = 200
                            alto = 200
                            ' ''Using fs As New System.IO.FileStream(rutaPng, System.IO.FileMode.Open, System.IO.FileAccess.Read)
                            Using img As Image = generaMiniatura(doc._rutaDocumento, ancho, alto)

                                img.Save(rutaPng, System.Drawing.Imaging.ImageFormat.Png)
                                nuevaLinea = CInt(x + (ancho)) + 20 > CInt(pnlPresentacion3.Width)

                                imgHeight = img.Height
                                imgWidth = img.Width
                            End Using

                            ' ''Catch ex As Exception
                            'Si da error es que no existe la miniatura, por tanto, la crea.
                            ' ''ancho = 200
                            ' ''alto = 200
                            ' ''img = generaMiniatura(doc._rutaDocumento, ancho, alto)
                            ' ''img.Save(rutaPng, System.Drawing.Imaging.ImageFormat.Png)
                            ' ''nuevaLinea = CInt(x + (ancho)) + 20 > CInt(pnlPresentacion3.Width)
                        End If
                        ''End Try

                        If nuevaLinea Then
                            x = 3
                            y = 5 + y + altoMaximoLinea
                            altoMaximoLinea = alto
                        Else
                            If altoMaximoLinea < imgHeight + bordePicture Then
                                altoMaximoLinea = imgHeight + bordePicture
                            End If
                        End If

                        pb.Location = New Point(x, y)

                        Try
                            x = 5 + x + (imgWidth + bordePicture)
                        Catch ex As Exception
                            ''x = 5 + x + Image.FromFile(My.Application.Info.DirectoryPath & "\ImagenDocumentoNocargado.TIF").Width
                            x = 5 + x + 755
                        End Try

                        pb.Size = New Size(imgWidth + bordePicture, imgHeight + bordePicture)
                        pb.Name = doc._pagina

                        ' ''img.Dispose()

                        mostrarImagen(pb, rutaPng)

                        pb.SizeMode = PictureBoxSizeMode.CenterImage '.StretchImage
                        Me.pnlPresentacion3.Controls.Add(pb)

                        AddHandler pb.MouseClick, AddressOf pb_MouseClick

                        toolTip1.SetToolTip(pb, doc._nombreArchivo)

                        Application.DoEvents()
                    Next

                    xMiniatura = x
                    yMiniatura = y
                    yAltoMaximoLinea = altoMaximoLinea

                    ToolStripProgressBar1.Value = 0

                    recargaMiniaturas = False

                    GC.Collect()
                    GC.WaitForPendingFinalizers()
                End If

            End If


        Catch ex As Exception
            Dim mensajeEX As String = ""
            'Excepción interna
            If ex.InnerException IsNot Nothing Then
                mensajeEX = " Inner exception: " & ex.InnerException.Message
            End If
            escribirEnLog("*** ERROR. " & Now & ". Ocurrió un error en cargaMiniatura." & vbLf & ex.Message & vbLf & mensajeEX & vbLf & ex.StackTrace)

            Throw ex

        Finally
            ProgressBar1.Visible = False
            lblProgressBar.Visible = False
            lblProgressBar.Text = ""
            Application.DoEvents()

        End Try
    End Sub

    Private Sub cargarMiniaturas_OLD20200629(ByVal listaDoc As List(Of clsDocumentoE))

        Dim x As Integer = 3
        Dim y As Integer = 3
        Dim anchoAcumulado As Integer = 0
        Dim altoAcumulado As Integer = 0
        Dim altoMaximoLinea As Integer = 0
        Dim rutaPng As String = ""
        Dim nuevaLinea As Boolean = False
        Dim img As System.Drawing.Image
        Dim ancho, alto As Integer
        Dim contador As Integer = 0
        Dim bordePicture As Integer = 5
        Dim toolTip1 As ToolTip = New System.Windows.Forms.ToolTip()

        Try
            If Not IsNothing(listaDoc) Then

                ToolStripProgressBar1.Maximum = listaDoc.Count
                ToolStripProgressBar1.Value = 0

                ProgressBar1.Visible = True
                lblProgressBar.Visible = True
                lblProgressBar.Text = "Cargando miniaturas..."
                ProgressBar1.Maximum = listaDoc.Count
                Application.DoEvents()

                If pnlPresentacion3.Controls.Count <> dgv.Rows.Count Or anchoForm <> Me.Width Or recargaMiniaturas Then
                    'En este caso no continua porque es el caso de que están cargadas las imagenes en blanco.
                    ' ''If cargadasImagenesBlancas = True And recargaMiniaturas = False Then Exit Sub

                    compruebCreaDirectoriosNecesarios()

                    'Descargo controles para que no se saturen los Objetos de Usuario y muestre el eror de "Error al crear identificador de ventana"
                    For Each png As PictureBox In pnlPresentacion3.Controls()
                        png.Dispose()
                    Next

                    pnlPresentacion3.Controls.Clear()

                    For Each doc As clsDocumentoE In listaDoc

                        contador += 1
                        ProgressBar1.Value = contador

                        rutaPng = doc._rutaDocumento.Replace("\" & doc._Lote.ToString.Trim, "\" & doc._Lote.ToString.Trim & "\MINIATURAS").ToUpper.Replace(".TIF", ".png")

                        pb = New PictureBox

                        Try
                            img = System.Drawing.Image.FromFile(rutaPng)
                            nuevaLinea = CInt(x + (img.Width) + bordePicture) + 20 > CInt(pnlPresentacion3.Width)
                        Catch ex As Exception
                            'Si da error es que no existe la miniatura, por tanto, la crea.
                            ancho = 200
                            alto = 200
                            img = generaMiniatura(doc._rutaDocumento, ancho, alto)
                            img.Save(rutaPng, System.Drawing.Imaging.ImageFormat.Png)
                            nuevaLinea = CInt(x + (ancho)) + 20 > CInt(pnlPresentacion3.Width)
                        End Try

                        If nuevaLinea Then
                            x = 3
                            y = 5 + y + altoMaximoLinea
                            altoMaximoLinea = alto
                        Else
                            If altoMaximoLinea < img.Height + bordePicture Then
                                altoMaximoLinea = img.Height + bordePicture
                            End If
                        End If

                        pb.Location = New Point(x, y)

                        Try
                            x = 5 + x + (img.Width + bordePicture)
                        Catch ex As Exception
                            x = 5 + x + Image.FromFile(My.Application.Info.DirectoryPath & "ImagenDocumentoNocargado.TIF").Width
                        End Try

                        pb.Size = New Size(img.Width + bordePicture, img.Height + bordePicture)
                        pb.Name = doc._pagina

                        img.Dispose()

                        mostrarImagen(pb, rutaPng)

                        pb.SizeMode = PictureBoxSizeMode.CenterImage '.StretchImage
                        Me.pnlPresentacion3.Controls.Add(pb)

                        AddHandler pb.MouseClick, AddressOf pb_MouseClick

                        toolTip1.SetToolTip(pb, doc._nombreArchivo)

                        Application.DoEvents()
                    Next

                    xMiniatura = x
                    yMiniatura = y
                    yAltoMaximoLinea = altoMaximoLinea

                    ToolStripProgressBar1.Value = 0

                    recargaMiniaturas = False

                    GC.Collect()
                    GC.WaitForPendingFinalizers()
                End If
            End If

        Catch ex As Exception
            Dim mensajeEX As String = ""
            'Excepción interna
            If ex.InnerException IsNot Nothing Then
                mensajeEX = " Inner exception: " & ex.InnerException.Message
            End If
            escribirEnLog("*** ERROR. " & Now & ". Ocurrió un error en cargaMiniatura." & vbLf & ex.Message & vbLf & mensajeEX & vbLf & ex.StackTrace)

            Throw ex

        Finally
            ProgressBar1.Visible = False
            lblProgressBar.Visible = False
            lblProgressBar.Text = ""
            Application.DoEvents()

        End Try
    End Sub

    Private Sub cargarMiniaturaUna(ByVal rutaDocumento As String, ByVal nombrePagina As String, ByVal sustituye As Boolean)

        Dim x As Integer = xMiniatura
        Dim y As Integer = 0 ' yMiniatura
        Dim anchoAcumulado As Integer = 0
        Dim altoAcumulado As Integer = 0
        Dim altoMaximoLinea As Integer = yAltoMaximoLinea
        Dim rutaPng As String = ""
        Dim nuevaLinea As Boolean = False
        ''Dim img As System.Drawing.Image
        Dim ancho, alto As Integer
        Dim contador As Integer = 0
        Dim bordePicture As Integer = 5
        Dim toolTip1 As ToolTip = New System.Windows.Forms.ToolTip()
        Dim ysustituye, xsustituye As Integer
        Dim pagina As String
        Dim imgHeight As Integer = 0
        Dim imgWidth As Integer = 0

        Try
            If sustituye Then
                pagina = (Convert.ToInt32(nombrePagina.ToUpper.Replace("IML", "").ToUpper.Replace(".TIF", ""))).ToString.Trim
            Else
                pagina = (Convert.ToInt32(nombrePagina.ToUpper.Replace("IML", "").ToUpper.Replace(".TIF", "")) - 1).ToString.Trim
            End If

            ''For Each pic As PictureBox In pnlPresentacion3.Controls.Find((Convert.ToInt32(nombrePagina.ToUpper.Replace("IML", "").ToUpper.Replace(".TIF", "")) - 1).ToString.Trim, True)
            For Each pic As PictureBox In pnlPresentacion3.Controls.Find(pagina, True)
                y = pic.Top
                ysustituye = pic.Top
                xsustituye = pic.Left
                If sustituye Then
                    pnlPresentacion3.Controls.RemoveByKey(pic.Name)

                    pnlPresentacion3.Refresh()
                End If

                Exit For
            Next

            rutaPng = rutaDocumento.Replace("\" & lblLote.Text.ToString.Trim, "\" & lblLote.Text.ToString.Trim & "\MINIATURAS").ToUpper.Replace(".TIF", ".png")

            pb = New PictureBox

            ' ''Try
            If IO.File.Exists(rutaPng) Then
                Using fs As New System.IO.FileStream(rutaPng, System.IO.FileMode.Open, System.IO.FileAccess.Read)

                    Using img As Image = Image.FromStream(fs)
                        ' ''img = System.Drawing.Image.FromFile(rutaPng)

                        imgHeight = img.Height
                        imgWidth = img.Width

                        nuevaLinea = CInt(x + (img.Width) + bordePicture) + 20 > CInt(pnlPresentacion3.Width)
                    End Using
                End Using
            Else

                ' ''Catch ex As Exception
                'Si da error es que no existe la miniatura, por tanto, la crea.
                ancho = 200
                alto = 200

                '' '' ''System.Threading.Thread.Sleep(100)   '(3000) 3000 son 3 segundos. Con esto da tiempo a que se creen las imágenes digitalizadas, sobre todo si son de color.

                ' ''img = generaMiniatura(rutaDocumento, ancho, alto)

                ' ''img.Save(rutaPng, System.Drawing.Imaging.ImageFormat.Png)
                ' ''nuevaLinea = CInt(x + (ancho)) + 20 > CInt(pnlPresentacion3.Width)

                Using img As Image = generaMiniatura(rutaDocumento, ancho, alto)

                    img.Save(rutaPng, System.Drawing.Imaging.ImageFormat.Png)
                    nuevaLinea = CInt(x + (ancho)) + 20 > CInt(pnlPresentacion3.Width)

                    imgHeight = img.Height
                    imgWidth = img.Width
                End Using

            End If

            ' ''End Try

            If nuevaLinea Then
                x = 3
                y = 5 + y + altoMaximoLinea
                altoMaximoLinea = alto
            Else
                If altoMaximoLinea < imgHeight + bordePicture Then
                    altoMaximoLinea = imgHeight + bordePicture
                End If
            End If

            If sustituye Then
                x = xsustituye
                y = ysustituye
            End If

            pb.Location = New Point(x, y)

            Try
                x = 5 + x + (imgWidth + bordePicture)
            Catch ex As Exception
                ''x = 5 + x + Image.FromFile(My.Application.Info.DirectoryPath & "\ImagenDocumentoNocargado.TIF").Width
                x = 5 + x + 755
            End Try

            pb.Size = New Size(imgWidth + bordePicture, imgHeight + bordePicture)
            pb.Name = Convert.ToInt32(nombrePagina.ToUpper.Replace("IML", "").ToUpper.Replace(".TIF", ""))

            ' ''img.Dispose()

            mostrarImagen(pb, rutaPng)

            pb.SizeMode = PictureBoxSizeMode.CenterImage '.StretchImage
            Me.pnlPresentacion3.Controls.Add(pb)

            pnlPresentacion3.ScrollControlIntoView(pb)

            AddHandler pb.MouseClick, AddressOf pb_MouseClick

            toolTip1.SetToolTip(pb, nombrePagina)

            Application.DoEvents()

            xMiniatura = x
            yMiniatura = y
            yAltoMaximoLinea = altoMaximoLinea

            recargaMiniaturas = False


        Catch ex As Exception
            Dim mensajeEX As String = ""
            'Excepción interna
            If ex.InnerException IsNot Nothing Then
                mensajeEX = " Inner exception: " & ex.InnerException.Message
            End If
            escribirEnLog("*** ERROR. " & Now & ". Ocurrió un error en cargaMiniaturaUna." & vbLf & ex.Message & vbLf & mensajeEX & vbLf & ex.StackTrace)

            Throw ex

        Finally
            ProgressBar1.Visible = False
            lblProgressBar.Visible = False
            lblProgressBar.Text = ""
            Application.DoEvents()

        End Try
    End Sub

    Private Sub cargarMiniaturaUna_OLD20200629(ByVal rutaDocumento As String, ByVal nombrePagina As String, ByVal sustituye As Boolean)

        Dim x As Integer = xMiniatura
        Dim y As Integer = 0 ' yMiniatura
        Dim anchoAcumulado As Integer = 0
        Dim altoAcumulado As Integer = 0
        Dim altoMaximoLinea As Integer = yAltoMaximoLinea
        Dim rutaPng As String = ""
        Dim nuevaLinea As Boolean = False
        Dim img As System.Drawing.Image
        Dim ancho, alto As Integer
        Dim contador As Integer = 0
        Dim bordePicture As Integer = 5
        Dim toolTip1 As ToolTip = New System.Windows.Forms.ToolTip()
        Dim ysustituye, xsustituye As Integer
        Dim pagina As String

        Try
            If sustituye Then
                pagina = (Convert.ToInt32(nombrePagina.ToUpper.Replace("IML", "").ToUpper.Replace(".TIF", ""))).ToString.Trim
            Else
                pagina = (Convert.ToInt32(nombrePagina.ToUpper.Replace("IML", "").ToUpper.Replace(".TIF", "")) - 1).ToString.Trim
            End If

            ''For Each pic As PictureBox In pnlPresentacion3.Controls.Find((Convert.ToInt32(nombrePagina.ToUpper.Replace("IML", "").ToUpper.Replace(".TIF", "")) - 1).ToString.Trim, True)
            For Each pic As PictureBox In pnlPresentacion3.Controls.Find(pagina, True)
                y = pic.Top
                ysustituye = pic.Top
                xsustituye = pic.Left
                If sustituye Then
                    pnlPresentacion3.Controls.RemoveByKey(pic.Name)

                    pnlPresentacion3.Refresh()
                End If

                Exit For
            Next

            rutaPng = rutaDocumento.Replace("\" & lblLote.Text.ToString.Trim, "\" & lblLote.Text.ToString.Trim & "\MINIATURAS").ToUpper.Replace(".TIF", ".png")

            pb = New PictureBox

            Try
                img = System.Drawing.Image.FromFile(rutaPng)

                nuevaLinea = CInt(x + (img.Width) + bordePicture) + 20 > CInt(pnlPresentacion3.Width)
            Catch ex As Exception
                'Si da error es que no existe la miniatura, por tanto, la crea.
                ancho = 200
                alto = 200

                ' ''System.Threading.Thread.Sleep(100)   '(3000) 3000 son 3 segundos. Con esto da tiempo a que se creen las imágenes digitalizadas, sobre todo si son de color.

                img = generaMiniatura(rutaDocumento, ancho, alto)

                img.Save(rutaPng, System.Drawing.Imaging.ImageFormat.Png)
                nuevaLinea = CInt(x + (ancho)) + 20 > CInt(pnlPresentacion3.Width)
            End Try

            If nuevaLinea Then
                x = 3
                y = 5 + y + altoMaximoLinea
                altoMaximoLinea = alto
            Else
                If altoMaximoLinea < img.Height + bordePicture Then
                    altoMaximoLinea = img.Height + bordePicture
                End If
            End If

            If sustituye Then
                x = xsustituye
                y = ysustituye
            End If

            pb.Location = New Point(x, y)

            Try
                x = 5 + x + (img.Width + bordePicture)
            Catch ex As Exception
                x = 5 + x + Image.FromFile(My.Application.Info.DirectoryPath & "ImagenDocumentoNocargado.TIF").Width
            End Try

            pb.Size = New Size(img.Width + bordePicture, img.Height + bordePicture)
            pb.Name = Convert.ToInt32(nombrePagina.ToUpper.Replace("IML", "").ToUpper.Replace(".TIF", ""))

            img.Dispose()

            mostrarImagen(pb, rutaPng)

            pb.SizeMode = PictureBoxSizeMode.CenterImage '.StretchImage
            Me.pnlPresentacion3.Controls.Add(pb)

            pnlPresentacion3.ScrollControlIntoView(pb)

            AddHandler pb.MouseClick, AddressOf pb_MouseClick

            toolTip1.SetToolTip(pb, nombrePagina)

            Application.DoEvents()

            xMiniatura = x
            yMiniatura = y
            yAltoMaximoLinea = altoMaximoLinea

            recargaMiniaturas = False


        Catch ex As Exception
            Dim mensajeEX As String = ""
            'Excepción interna
            If ex.InnerException IsNot Nothing Then
                mensajeEX = " Inner exception: " & ex.InnerException.Message
            End If
            escribirEnLog("*** ERROR. " & Now & ". Ocurrió un error en cargaMiniaturaUna." & vbLf & ex.Message & vbLf & mensajeEX & vbLf & ex.StackTrace)

            Throw ex

        Finally
            ProgressBar1.Visible = False
            lblProgressBar.Visible = False
            lblProgressBar.Text = ""
            Application.DoEvents()

        End Try
    End Sub

    Private Sub sutituyeMiniatura(ByVal rutaDocumento As String, ByVal nombrePagina As String)

        Dim x As Integer = xMiniatura
        Dim y As Integer = 0 ' yMiniatura
        Dim anchoAcumulado As Integer = 0
        Dim altoAcumulado As Integer = 0
        Dim altoMaximoLinea As Integer = yAltoMaximoLinea
        Dim rutaPng As String = ""
        Dim nuevaLinea As Boolean = False
        Dim img As System.Drawing.Image
        Dim ancho, alto As Integer
        Dim contador As Integer = 0
        Dim bordePicture As Integer = 5
        Dim toolTip1 As ToolTip = New System.Windows.Forms.ToolTip()
        ' ''Dim punto As Point

        Try
            For Each pic As PictureBox In pnlPresentacion3.Controls.Find((Convert.ToInt32(nombrePagina.ToUpper.Replace("IML", "").ToUpper.Replace(".TIF", "")) - 1).ToString.Trim, True)
                ' ''If pic.Name = Convert.ToInt32(nombrePagina.ToUpper.Replace("IML", "").ToUpper.Replace(".TIF", "")) - 1 Then
                ' ''punto = pic.PointToScreen(New Point(pic.Top, pic.Left)) '' Me.pnlPresentacion3.Controls(Convert.ToInt32(nombrePagina.ToUpper.Replace("IML", "").ToUpper.Replace(".TIF", ""))).PointToScreen()
                x = pic.Top
                y = pic.Top
                ancho = pic.Width
                alto = pic.Height
                Exit For
                ' ''End If
            Next

            rutaPng = rutaDocumento.Replace("\" & lblLote.Text.ToString.Trim, "\" & lblLote.Text.ToString.Trim & "\MINIATURAS").ToUpper.Replace(".TIF", ".png")

            pb = New PictureBox

            Try
                img = System.Drawing.Image.FromFile(rutaPng)

            Catch ex As Exception
                'Si da error es que no existe la miniatura, por tanto, la crea.
                ' ''img = System.Drawing.Image.FromFile(doc._rutaDocumento)
                ' ''ancho = 200
                ' ''alto = 200
                img = generaMiniatura(rutaDocumento, ancho, alto)

                img.Save(rutaPng, System.Drawing.Imaging.ImageFormat.Png)
            End Try

            pb.Location = New Point(x, y)

            pb.Size = New Size(img.Width + bordePicture, img.Height + bordePicture)
            pb.Name = Convert.ToInt32(nombrePagina.ToUpper.Replace("IML", "").ToUpper.Replace(".TIF", ""))

            img.Dispose()

            pb.SizeMode = PictureBoxSizeMode.CenterImage '.StretchImage

            ' ''Me.pnlPresentacion3.Controls.RemoveByKey(pb.Name)

            mostrarImagen(pb, rutaPng)

            pb.Refresh()
            pnlPresentacion3.Refresh()

            ' ''Me.pnlPresentacion3.Controls.Add(pb)

            ' ''pnlPresentacion3.ScrollControlIntoView(pb)

            AddHandler pb.MouseClick, AddressOf pb_MouseClick

            toolTip1.SetToolTip(pb, nombrePagina)

            Application.DoEvents()

            recargaMiniaturas = False


        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Sub

    Private Sub cargarMiniaturas_VA_PERFECTO(ByVal listaDoc As List(Of clsDocumentoE))

        Dim x As Integer = 3
        Dim y As Integer = 3
        Dim anchoAcumulado As Integer = 0
        Dim altoAcumulado As Integer = 0
        Dim altoMaximoLinea As Integer = 0
        Dim rutaPng As String = ""
        Dim nuevaLinea As Boolean = False
        Dim img As System.Drawing.Image
        Dim ancho, alto As Integer

        Try
            If Not IsNothing(listaDoc) Then

                ToolStripProgressBar1.Maximum = listaDoc.Count
                ToolStripProgressBar1.Value = 0

                If pnlPresentacion3.Controls.Count <> oLote._TotalImagenes Or anchoForm <> Me.Width Then
                    If digitalizando = False Then
                        pnlPresentacion3.Controls.Clear()
                    Else
                        'Carga la x e y para añadir a continuación nueva miniatura
                        For Each pic As PictureBox In pnlPresentacion3.Controls
                            x = pic.Location.X + 5 + pic.Width
                            y = pic.Location.Y
                        Next

                        altoMaximoLinea = yAltoMaximoLinea
                    End If

                    For Each doc As clsDocumentoE In listaDoc

                        rutaPng = doc._rutaDocumento.Replace("\" & doc._Lote.ToString.Trim, "\" & doc._Lote.ToString.Trim & "\MINIATURAS").ToUpper.Replace(".TIF", ".png")

                        pb = New PictureBox

                        Try
                            img = System.Drawing.Image.FromFile(rutaPng)
                            nuevaLinea = CInt(x + (img.Width)) + 20 > CInt(pnlPresentacion3.Width)
                        Catch ex As Exception
                            'Si da error es que no existe la miniatura, por tanto, la crea.
                            img = System.Drawing.Image.FromFile(doc._rutaDocumento)
                            ancho = 200
                            alto = 200
                            img = generaMiniatura(doc._rutaDocumento, ancho, alto)
                            img.Save(rutaPng, System.Drawing.Imaging.ImageFormat.Png)
                            nuevaLinea = CInt(x + (ancho)) + 20 > CInt(pnlPresentacion3.Width)
                        End Try

                        If nuevaLinea Then
                            x = 3
                            y = 5 + y + altoMaximoLinea
                            altoMaximoLinea = alto
                        Else
                            If altoMaximoLinea < img.Height Then
                                altoMaximoLinea = img.Height
                            End If
                        End If

                        pb.Location = New Point(x, y)

                        Try
                            x = 5 + x + img.Width
                        Catch ex As Exception
                            x = 5 + x + Image.FromFile(My.Application.Info.DirectoryPath & "ImagenDocumentoNocargado.TIF").Width
                        End Try

                        pb.Size = New Size(img.Width, img.Height)
                        pb.Name = doc._pagina
                        pb.Image = img
                        pb.SizeMode = PictureBoxSizeMode.StretchImage
                        Me.pnlPresentacion3.Controls.Add(pb)

                        ' ''AddHandler pb.Click, AddressOf pb_Click
                        AddHandler pb.MouseClick, AddressOf pb_MouseClick
                        ' ''AddHandler pb.MouseLeave, AddressOf pb_MouseLEave

                        ' ''ToolStripProgressBar1.Value = doc._pagina

                        Application.DoEvents()
                    Next

                    xMiniatura = x
                    yMiniatura = y
                    yAltoMaximoLinea = altoMaximoLinea

                    ToolStripProgressBar1.Value = 0

                    GC.Collect()
                    GC.WaitForPendingFinalizers()
                End If

                ' ''pnlPresentacion3.ResumeLayout()

                'Desplaza scroll del frame
                If digitalizando Then
                    pnlPresentacion3.AutoScrollPosition = New Point(Math.Abs(pnlPresentacion3.AutoScrollPosition.X), Math.Abs(y + altoMaximoLinea))
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub compruebCreaDirectoriosNecesarios()

        'Directorio del lote en servidor
        If IO.Directory.Exists(oLote._rutaLote) = False Then
            IO.Directory.CreateDirectory(oLote._rutaLote)
        End If
        'Directorio de miniaturas del lote en servidor
        If IO.Directory.Exists(oLote._rutaLote & "\MINIATURAS") = False Then
            IO.Directory.CreateDirectory(oLote._rutaLote & "\MINIATURAS")
        End If

        'Directorio del lote en local
        If IO.Directory.Exists(oLote._rutaLoteLocal) = False Then
            IO.Directory.CreateDirectory(oLote._rutaLoteLocal)
        End If
        'Directorio de miniaturas del lote en local
        If IO.Directory.Exists(oLote._rutaLoteLocal & "\MINIATURAS") = False Then
            IO.Directory.CreateDirectory(oLote._rutaLoteLocal & "\MINIATURAS")
        End If

        'Directorio local de sustitución de imágenes
        If IO.Directory.Exists(rutaDirSustitucion) = False Then
            IO.Directory.CreateDirectory(rutaDirSustitucion)
        End If

    End Sub

    ' ''Private Sub pb_MouseClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Private Sub pb_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        ' ''sender.borderstyle = BorderStyle.FixedSingle
        Try
            ' verifica que se presionó el botón derecho   
            If e.Button = Windows.Forms.MouseButtons.Right Then
                sender.borderstyle = BorderStyle.FixedSingle

                Dim obj As IEnumerable(Of DataGridViewRow) = From row As DataGridViewRow In dgv.Rows.Cast(Of DataGridViewRow)() Where (row.Cells("Pagina").Value = sender.name.ToString.Trim) Select row
                If obj.Any() Then
                    If dgv.Rows(obj.FirstOrDefault().Index).Selected Then
                        dgv.Rows(obj.FirstOrDefault().Index).Selected = False
                        sender.BackColor = Color.White
                    Else
                        dgv.Rows(obj.FirstOrDefault().Index).Selected = True
                        sender.BackColor = Color.Blue
                    End If
                End If
            Else
                For Each cont As PictureBox In pnlPresentacion3.Controls
                    cont.BorderStyle = BorderStyle.None
                    cont.BackColor = Color.White
                Next

                If Not IsNothing(oListaDocumentos) Then
                    If oListaDocumentos.Count > 0 And dgv.Rows.Count > 0 Then
                        sender.borderstyle = BorderStyle.FixedSingle
                        sender.BackColor = Color.Blue
                        BuscarEnGridLINQ(sender.name.ToString.Trim, "Pagina", dgv)
                        posicionarRegistro(dgv.CurrentRow.Index)
                    End If
                End If
            End If

        Catch ex As Exception
            ' ''MessageBox.Show("Ocurrio un error al mostar el menu contextual")
        End Try
    End Sub

    Private Sub controlBotonesPresentacion(ByVal nombreControl As String)

        Try
            tsbAjuste1.Enabled = True
            tsbAjuste2.Enabled = True
            tsbAjuste3.Enabled = True
            tsbAjuste4.Enabled = True

            Select Case nombreControl
                Case nombreControlImagen1

                    Application.DoEvents()

                    pnlPresentacion1.Visible = True
                    pnlPresentacion2.Visible = False
                    pnlPresentacion3.Visible = False

                    tsbImagen1.CheckState = CheckState.Checked
                    tsbImagen2.CheckState = CheckState.Unchecked
                    tsbImagenMini.CheckState = CheckState.Unchecked

                    tstTipoAjuste.Enabled = True
                    nudGrados.Enabled = True

                Case nombreControlImagen2
                    pnlPresentacion2.Visible = True
                    pnlPresentacion1.Visible = False
                    pnlPresentacion3.Visible = False

                    tsbImagen2.CheckState = CheckState.Checked
                    tsbImagen1.CheckState = CheckState.Unchecked
                    tsbImagenMini.CheckState = CheckState.Unchecked

                    tstTipoAjuste.Enabled = True
                    tsbAjuste1.CheckState = CheckState.Checked
                    tsbAjuste2.CheckState = CheckState.Unchecked
                    tsbAjuste3.CheckState = CheckState.Unchecked
                    tsbAjuste4.CheckState = CheckState.Unchecked
                    tsbAjuste2.Enabled = False
                    tsbAjuste3.Enabled = False
                    tsbAjuste4.Enabled = False

                    nudGrados.Enabled = False

                Case nombreControlImagenMini
                    pnlPresentacion3.Visible = True
                    pnlPresentacion1.Visible = False
                    pnlPresentacion2.Visible = False

                    tsbImagenMini.CheckState = CheckState.Checked
                    tsbImagen1.CheckState = CheckState.Unchecked
                    tsbImagen2.CheckState = CheckState.Unchecked

                    tstTipoAjuste.Enabled = False

                    nudGrados.Enabled = False
            End Select

        Catch ex As Exception
            Dim mensajeEX As String = ""
            'Excepción interna
            If ex.InnerException IsNot Nothing Then
                mensajeEX = " Inner exception: " & ex.InnerException.Message
            End If

            escribirEnLog("*** ERROR. " & Now & ". Ocurrió un error en controlBotonesPresentacion." & vbLf & ex.Message & vbLf & mensajeEX & vbLf & ex.StackTrace)

            Throw ex

        End Try

    End Sub

    Private Sub controlBotonesAjustes(ByVal nombreControl As String)

        Try
            Select Case nombreControl
                Case nombreControlAjuste1
                    tsbAjuste1.CheckState = CheckState.Checked
                    tsbAjuste2.CheckState = CheckState.Unchecked
                    tsbAjuste3.CheckState = CheckState.Unchecked
                    tsbAjuste4.CheckState = CheckState.Unchecked

                Case nombreControlAjuste2
                    tsbAjuste2.CheckState = CheckState.Checked
                    tsbAjuste1.CheckState = CheckState.Unchecked
                    tsbAjuste3.CheckState = CheckState.Unchecked
                    tsbAjuste4.CheckState = CheckState.Unchecked

                Case nombreControlAjuste3
                    tsbAjuste3.CheckState = CheckState.Checked
                    tsbAjuste2.CheckState = CheckState.Unchecked
                    tsbAjuste1.CheckState = CheckState.Unchecked
                    tsbAjuste4.CheckState = CheckState.Unchecked

                Case nombreControlAjuste4
                    tsbAjuste4.CheckState = CheckState.Checked
                    tsbAjuste2.CheckState = CheckState.Unchecked
                    tsbAjuste3.CheckState = CheckState.Unchecked
                    tsbAjuste1.CheckState = CheckState.Unchecked
            End Select

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub controlAccionesPresentacion(ByVal controlImagen As PictureBox, ByVal nombreControl As String)

        Try
            Me.Cursor = Cursors.WaitCursor

            Select Case nombreControl
                Case nombreControlImagen1
                    If Not IsNothing(oListaDocumentos) Then
                        If oListaDocumentos.Count > 0 And dgv.Rows.Count > 0 Then
                            If dgv.Rows(dgv.CurrentRow.Index).Cells("idDocumento").Value > 0 Then
                                oDocumentoActivo = oListaDocumentos.Find(Function(obj As clsDocumentoE) obj._pagina = dgv.Rows(dgv.CurrentRow.Index).Cells("pagina").Value)
                                cargarDatosDocumento()
                                If IsNothing(oDocumentoActivo) Then
                                    mostrarImagen(controlImagen, "")
                                Else
                                    mostrarImagen(controlImagen, oDocumentoActivo._rutaDocumento)
                                    dgv.Select()
                                End If
                            End If
                        Else
                            mostrarImagen(controlImagen, "")
                        End If
                    End If

                Case nombreControlImagen2
                    If Not IsNothing(oListaDocumentos) Then
                        If oListaDocumentos.Count > 0 And dgv.Rows.Count > 0 Then
                            If dgv.Rows(dgv.CurrentRow.Index).Cells("idDocumento").Value > 0 Then
                                oDocumentoActivo = oListaDocumentos.Find(Function(obj As clsDocumentoE) obj._idDocumento = dgv.Rows(dgv.CurrentRow.Index).Cells("idDocumento").Value)
                                cargarDatosDocumento()
                                If IsNothing(oDocumentoActivo) Then
                                    mostrarImagen(ImgEditIzquierda, "")
                                    mostrarImagen(imgEditDerecha, "")
                                Else
                                    If dgv.CurrentRow.Index = 0 Or dgv.CurrentRow.Index < dgv.RowCount - 1 Then
                                        mostrarImagen(ImgEditIzquierda, oDocumentoActivo._rutaDocumento)
                                        If dgv.RowCount > 1 Then
                                            mostrarImagen(imgEditDerecha, oListaDocumentos.Find(Function(obj As clsDocumentoE) obj._idDocumento = dgv.Rows(dgv.CurrentRow.Index + 1).Cells("idDocumento").Value)._rutaDocumento)
                                        Else
                                            mostrarImagen(imgEditDerecha, "")
                                        End If
                                    Else
                                        'igual a rowCount
                                        mostrarImagen(imgEditDerecha, oDocumentoActivo._rutaDocumento)
                                        If dgv.RowCount > 1 Then
                                            mostrarImagen(ImgEditIzquierda, oListaDocumentos.Find(Function(obj As clsDocumentoE) obj._idDocumento = dgv.Rows(dgv.CurrentRow.Index - 1).Cells("idDocumento").Value)._rutaDocumento)
                                        Else
                                            mostrarImagen(ImgEditIzquierda, "")
                                        End If
                                    End If
                                    dgv.Select()
                                End If
                            End If
                        Else
                            mostrarImagen(imgEditDerecha, "")
                            mostrarImagen(ImgEditIzquierda, "")
                        End If
                    End If

                Case nombreControlImagenMini
                    ' ''Me.Refresh()

                    ' ''Me.WindowState = FormWindowState.Maximized

                    If digitalizando = False Then cargarMiniaturas(oListaDocumentos)

                    'Posiciona miniatura
                    For Each pic As PictureBox In pnlPresentacion3.Controls
                        If dgv.Rows.Count > 0 Then
                            If pic.Name = dgv.SelectedRows(0).Cells("Pagina").Value Then
                                pic.BackColor = Color.Blue
                                cargarDatosDocumento()
                                pnlPresentacion3.ScrollControlIntoView(pic)
                            Else
                                pic.BackColor = Color.White
                            End If
                        Else
                            pnlPresentacion3.Controls.Clear()
                        End If
                    Next

                    'Esto lo hago porque dentro de cargar miniaturas compruebo que si ha cambiado el tamaño del form, vuelvo a cargar las miniaturas para que ocupen todo el ancho libre.
                    anchoForm = Me.Width
            End Select

        Catch ex As Exception
            Dim mensajeEX As String = ""
            'Excepción interna
            If ex.InnerException IsNot Nothing Then
                mensajeEX = " Inner exception: " & ex.InnerException.Message
            End If

            escribirEnLog("*** ERROR. " & Now & ". Ocurrió un error en controlAccionesPresentacion." & vbLf & ex.Message & vbLf & mensajeEX & vbLf & ex.StackTrace)

            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub controlAccionesAjustes(ByVal nombreControl As String)
        ''Dim valorFit As Integer = 0

        Try


            Me.Cursor = Cursors.WaitCursor

            If pnlPresentacion1.Visible Then
                IMGeditPrincipal.SizeMode = PictureBoxSizeMode.Zoom
                Select Case nombreControl
                    Case nombreControlAjuste1
                        'Ajuste de la imagen dinamica según ancho y alto
                        If IMGeditPrincipal.Image.Width > IMGeditPrincipal.Image.Height Then
                            'Si es más ancho, ajusta a lo ancho
                            If IMGeditPrincipal.Width > IMGeditPrincipal.Height Then
                                IMGeditPrincipal.Width = pnlPresentacion1.Width - 5
                                'IMGeditPrincipal.Height = (IMGeditPrincipal.Width * (IMGeditPrincipal.Image.Height / IMGeditPrincipal.Image.Width)) - 5
                            Else
                                IMGeditPrincipal.Height = pnlPresentacion1.Height - 5    '''(IMGeditPrincipal.Width * (IMGeditPrincipal.Image.Height / IMGeditPrincipal.Image.Width)) - 5
                                IMGeditPrincipal.Width = pnlPresentacion1.Width - 5
                            End If
                        Else
                            'Si es mas alto, ajusta a lo alto
                            IMGeditPrincipal.Height = pnlPresentacion1.Height - 5
                            IMGeditPrincipal.Width = (IMGeditPrincipal.Height * (IMGeditPrincipal.Image.Width / IMGeditPrincipal.Image.Height)) - 5
                        End If
                    Case nombreControlAjuste2
                        'Ajuste a lo ancho
                        IMGeditPrincipal.Width = pnlPresentacion1.Width - 5
                        IMGeditPrincipal.Height = (IMGeditPrincipal.Width * (IMGeditPrincipal.Image.Height / IMGeditPrincipal.Image.Width)) - 5
                    Case nombreControlAjuste3
                        'Ajuste a lo alto
                        IMGeditPrincipal.Height = pnlPresentacion1.Height - 5
                        IMGeditPrincipal.Width = (IMGeditPrincipal.Height * (IMGeditPrincipal.Image.Width / IMGeditPrincipal.Image.Height)) - 5
                    Case nombreControlAjuste4
                        'Ajuste al  tamaño real
                        IMGeditPrincipal.Height = IMGeditPrincipal.Image.Height
                        IMGeditPrincipal.Width = IMGeditPrincipal.Image.Width
                        IMGeditPrincipal.SizeMode = PictureBoxSizeMode.StretchImage

                End Select

                ' ''IMGeditPrincipal.FitTo(valorFit)
                ' ''IMGeditPrincipal.Display()
                ' ''IMGeditPrincipal.Refresh()
            ElseIf pnlPresentacion2.Visible Then
                ImgEditIzquierda.SizeMode = PictureBoxSizeMode.Zoom
                imgEditDerecha.SizeMode = PictureBoxSizeMode.Zoom
                Select Case nombreControl
                    Case nombreControlAjuste1
                        'Ajuste de la imagen dinamica según ancho y alto
                        If ImgEditIzquierda.Image.Width > ImgEditIzquierda.Image.Height Then
                            'Si es más ancho, ajusta a lo ancho
                            ImgEditIzquierda.Width = (pnlPresentacion2.Width / 2) - 5
                            ImgEditIzquierda.Height = (ImgEditIzquierda.Width * (ImgEditIzquierda.Image.Height / ImgEditIzquierda.Image.Width)) - 5
                        Else
                            'Si es mas alto, ajusta a lo alto
                            ImgEditIzquierda.Height = pnlPresentacion2.Height - 5
                            ImgEditIzquierda.Width = (ImgEditIzquierda.Height * (ImgEditIzquierda.Image.Width / ImgEditIzquierda.Image.Height)) - 5
                        End If
                        If imgEditDerecha.Image.Width > imgEditDerecha.Image.Height Then
                            'Si es más ancho, ajusta a lo ancho
                            imgEditDerecha.Width = (pnlPresentacion2.Width / 2) - 5
                            imgEditDerecha.Height = (imgEditDerecha.Width * (imgEditDerecha.Image.Height / imgEditDerecha.Image.Width)) - 5
                        Else
                            'Si es mas alto, ajusta a lo alto
                            imgEditDerecha.Height = pnlPresentacion2.Height - 5
                            imgEditDerecha.Width = (imgEditDerecha.Height * (imgEditDerecha.Image.Width / imgEditDerecha.Image.Height)) - 5
                        End If
                    Case nombreControlAjuste2
                        'Ajuste a lo ancho
                        ImgEditIzquierda.Width = (pnlPresentacion2.Width / 2) - 5
                        ImgEditIzquierda.Height = (ImgEditIzquierda.Width * (ImgEditIzquierda.Image.Height / ImgEditIzquierda.Image.Width)) - 5
                        imgEditDerecha.Width = (pnlPresentacion2.Width / 2) - 5
                        imgEditDerecha.Height = (imgEditDerecha.Width * (imgEditDerecha.Image.Height / imgEditDerecha.Image.Width)) - 5
                    Case nombreControlAjuste3
                        'Ajuste a lo alto
                        ImgEditIzquierda.Height = pnlPresentacion2.Height - 5
                        ImgEditIzquierda.Width = (ImgEditIzquierda.Height * (ImgEditIzquierda.Image.Width / ImgEditIzquierda.Image.Height)) - 5
                        imgEditDerecha.Height = pnlPresentacion2.Height - 5
                        imgEditDerecha.Width = (imgEditDerecha.Height * (imgEditDerecha.Image.Width / imgEditDerecha.Image.Height)) - 5
                    Case nombreControlAjuste4
                        'Ajuste al  tamaño real
                        ImgEditIzquierda.Height = ImgEditIzquierda.Image.Height
                        ImgEditIzquierda.Width = ImgEditIzquierda.Image.Width / 2
                        ImgEditIzquierda.SizeMode = PictureBoxSizeMode.StretchImage
                        imgEditDerecha.Height = imgEditDerecha.Image.Height
                        imgEditDerecha.Width = imgEditDerecha.Image.Width / 2
                        imgEditDerecha.SizeMode = PictureBoxSizeMode.StretchImage

                End Select
            End If

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub tsbImagen1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImagen1.Click

        Try
            Me.Refresh()

            controlBotonesPresentacion(sender.name)
            controlAccionesPresentacion(IMGeditPrincipal, sender.name)

        Catch ex As Exception

            Dim mensajeEX As String = ""
            'Excepción interna
            If ex.InnerException IsNot Nothing Then
                mensajeEX = " Inner exception: " & ex.InnerException.Message
            End If
            escribirEnLog("*** ERROR. " & Now & ". Ocurrió un error al ir a la presentación de una página." & vbLf & ex.Message & vbLf & mensajeEX & vbLf & ex.StackTrace)

        End Try

    End Sub

    Private Sub tsbImagen2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImagen2.Click

        Try

            controlBotonesPresentacion(sender.name)
            controlAccionesPresentacion(imgEditDerecha, sender.name)

        Catch ex As Exception

            Dim mensajeEX As String = ""
            'Excepción interna
            If ex.InnerException IsNot Nothing Then
                mensajeEX = " Inner exception: " & ex.InnerException.Message
            End If
            escribirEnLog("*** ERROR. " & Now & ". Ocurrió un error al ir a la presentación de dos páginas." & vbLf & ex.Message & vbLf & mensajeEX & vbLf & ex.StackTrace)

        End Try

    End Sub

    Private Sub tsbImagenMini_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImagenMini.Click

        Try
            controlBotonesPresentacion(sender.name)
            controlAccionesPresentacion(Nothing, sender.name)

        Catch ex As Exception
            Dim mensajeEX As String = ""
            'Excepción interna
            If ex.InnerException IsNot Nothing Then
                mensajeEX = " Inner exception: " & ex.InnerException.Message
            End If
            escribirEnLog("*** ERROR. " & Now & ". Ocurrió un error al ajustar la imagen a su proporción correspondiente." & vbLf & ex.Message & vbLf & mensajeEX & vbLf & ex.StackTrace)

        End Try

    End Sub

    Private Sub tsbAjuste1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAjuste1.Click

        Try

            controlBotonesAjustes(sender.name)
            If dgv.Rows.Count > 0 Then
                controlAccionesAjustes(sender.name)
            End If

        Catch ex As Exception

            Dim mensajeEX As String = ""
            'Excepción interna
            If ex.InnerException IsNot Nothing Then
                mensajeEX = " Inner exception: " & ex.InnerException.Message
            End If
            escribirEnLog("*** ERROR. " & Now & ". Ocurrió un error al ir a la presentación de miniaturas." & vbLf & ex.Message & vbLf & mensajeEX & vbLf & ex.StackTrace)

        End Try
    End Sub

    Private Sub tsbAjuste2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAjuste2.Click

        Try
            controlBotonesAjustes(sender.name)
            controlAccionesAjustes(sender.name)

        Catch ex As Exception

            Dim mensajeEX As String = ""
            'Excepción interna
            If ex.InnerException IsNot Nothing Then
                mensajeEX = " Inner exception: " & ex.InnerException.Message
            End If
            escribirEnLog("*** ERROR. " & Now & ". Ocurrió un error al ajustar la imagen a lo ancho." & vbLf & ex.Message & vbLf & mensajeEX & vbLf & ex.StackTrace)

        End Try

    End Sub

    Private Sub tsbAjuste3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAjuste3.Click

        Try
            controlBotonesAjustes(sender.name)
            controlAccionesAjustes(sender.name)

        Catch ex As Exception

            Dim mensajeEX As String = ""
            'Excepción interna
            If ex.InnerException IsNot Nothing Then
                mensajeEX = " Inner exception: " & ex.InnerException.Message
            End If
            escribirEnLog("*** ERROR. " & Now & ". Ocurrió un error al ajustar la imagen a lo alto." & vbLf & ex.Message & vbLf & mensajeEX & vbLf & ex.StackTrace)

        End Try

    End Sub

    Private Sub tsbAjuste4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAjuste4.Click

        Try
            controlBotonesAjustes(sender.name)
            controlAccionesAjustes(sender.name)

        Catch ex As Exception

            Dim mensajeEX As String = ""
            'Excepción interna
            If ex.InnerException IsNot Nothing Then
                mensajeEX = " Inner exception: " & ex.InnerException.Message
            End If
            escribirEnLog("*** ERROR. " & Now & ". Ocurrió un error al ajustar la imagen a su proporción real." & vbLf & ex.Message & vbLf & mensajeEX & vbLf & ex.StackTrace)

        End Try

    End Sub

    Private Sub tsbAccion3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAccion3.Click
        'ROTAR imagen 90 grados a la derecha
        ''Dim bm As Bitmap
        Dim documento As clsDocumentoE

        Dim myImageCodecInfo As ImageCodecInfo
        Dim myEncoder As Encoder
        Dim myEncoderParameter As EncoderParameter
        Dim myEncoderParameters As EncoderParameters

        Try
            Me.Cursor = Cursors.WaitCursor
            If dgv.SelectedRows.Count > 0 Then

                Dim mapaBytes As Byte()

                For Each fila As DataGridViewRow In dgv.SelectedRows
                    documento = obtieneDocumento(fila.Cells("idDocumento").Value)
                    If Not IsNothing(documento) Then
                        myImageCodecInfo = GetEncoderInfo("image/tiff")
                        myEncoder = Encoder.Compression
                        myEncoderParameters = New EncoderParameters(1)

                        ' ''Using bm As Bitmap = System.Drawing.Image.FromFile(documento._rutaDocumento)
                        ' ''    bm.RotateFlip(RotateFlipType.Rotate90FlipNone)
                        ' ''    Me.IMGeditPrincipal.Image = bm

                        ' ''    myEncoderParameter = New EncoderParameter(myEncoder, Fix(EncoderValue.CompressionLZW))
                        ' ''    myEncoderParameters.Param(0) = myEncoderParameter
                        ' ''    bm.Save(documento._rutaDocumento, myImageCodecInfo, myEncoderParameters)
                        ' ''End Using

                        mapaBytes = System.IO.File.ReadAllBytes(documento._rutaDocumento)
                        Using ms As System.IO.MemoryStream = New System.IO.MemoryStream(mapaBytes)
                            Using bm As Bitmap = System.Drawing.Image.FromStream(ms)
                                bm.RotateFlip(RotateFlipType.Rotate90FlipNone)

                                myEncoderParameter = New EncoderParameter(myEncoder, Fix(EncoderValue.CompressionLZW))
                                myEncoderParameters.Param(0) = myEncoderParameter
                                bm.Save(documento._rutaDocumento, myImageCodecInfo, myEncoderParameters)

                                ''Me.IMGeditPrincipal.Image = bm
                            End Using
                        End Using

                        mostrarImagen(Me.IMGeditPrincipal, documento._rutaDocumento)

                        'borra miniaturas
                        If File.Exists(documento._rutaDocumento.Replace("\IML", "\MINIATURAS\IML").ToUpper.Replace("TIF", "PNG")) Then
                            mapaBytes = System.IO.File.ReadAllBytes(documento._rutaDocumento.Replace("\IML", "\MINIATURAS\IML").ToUpper.Replace("TIF", "PNG"))
                            Using ms As System.IO.MemoryStream = New System.IO.MemoryStream(mapaBytes)
                                Using bm As Bitmap = System.Drawing.Image.FromStream(ms)
                                    bm.RotateFlip(RotateFlipType.Rotate90FlipNone)

                                    myEncoderParameter = New EncoderParameter(myEncoder, Fix(EncoderValue.CompressionLZW))
                                    myEncoderParameters.Param(0) = myEncoderParameter
                                    bm.Save(documento._rutaDocumento.Replace("\IML", "\MINIATURAS\IML").ToUpper.Replace("TIF", "PNG"), myImageCodecInfo, myEncoderParameters)
                                End Using
                            End Using

                            cargarMiniaturaUna(documento._rutaDocumento, documento._pagina, True)
                            ' ''File.Delete(documento._rutaDocumento.Replace("\IML", "\MINIATURAS\IML").ToUpper.Replace("TIF", "PNG"))
                        End If
                    Else
                        MessageBox.Show("Error al identificar página " & fila.Cells("Pagina").Value & " del lote " & fila.Cells("Lote").Value & " para rotar, contacte con el servicio de informática.", "Rotar páginas", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        escribirEnLog("*** ERROR USUARIO. " & Now & ". Lote " & lblLote.Text & " Error al identificar página " & fila.Cells("Pagina").Value & " del lote " & fila.Cells("Lote").Value & " para rotar, contacte con el servicio de informática.")
                    End If
                Next

                'Al no refrescar, posiciono en la lista para que resalte la miniatura
                'Posiciona el grid según el parámetro indicado
                If dgv.Rows.Count > 0 Then
                    BuscarEnGridLINQ(documento._pagina.ToString.Trim, "Pagina", dgv)
                    posicionarRegistro(dgv.CurrentRow.Index)
                Else
                    pnlPresentacion1.Visible = False
                    pnlPresentacion2.Visible = False
                    pnlPresentacion3.Visible = False
                End If
                '*********************************************


                ' ''recargaMiniaturas = True

                '' '' ''Application.DoEvents()

                ' ''If Not IsNothing(documento) Then
                ' ''    refrescarLista(documento._pagina)
                ' ''Else
                ' ''    refrescarLista(1)
                ' ''End If
            Else
                MessageBox.Show("No hay páginas seleccionadas para rotar.", "Rotar páginas", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            Dim mensajeEX As String = ""
            'Excepción interna
            If ex.InnerException IsNot Nothing Then
                mensajeEX = " Inner exception: " & ex.InnerException.Message
            End If
            escribirEnLog("*** ERROR. " & Now & ". Ocurrió un error al rotar las páginas a la derecha." & vbLf & ex.Message & vbLf & mensajeEX & vbLf & ex.StackTrace)

            ' ''MessageBox.Show("Ocurrió un error al rotar las páginas a la derecha." & vbCrLf & ex.Message, "Error al rotar", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Function digitalizar(ByVal batch As Boolean, ByVal insertar As Boolean) As String

        Dim mensaje As String = ""
        Dim mensajeEX As String = ""
        Dim oDoc As New clsDocumentoE
        Dim pagina As Integer = 0
        Dim fechaIni As Date
        Dim mINI As New LibreriaCadenaProduccion.INI.clsIniArray
        Dim NewProcess As Process = New Process
        Dim listaDocResultante As New List(Of String)
        Dim digitalizaAlgo As Boolean = False
        Dim ruta As String = ""
        Dim horaInicial As Date
        Dim segundosIni As Integer = 0

        Try
            Try
                mensajeEX = "Antes de borrar ficheros de la ruta de sustitución."

                For Each fichero As String In Directory.GetFiles(rutaDirSustitucion, "*.*", SearchOption.TopDirectoryOnly)  'Directory.GetFiles(oLote._rutaLoteLocal, "*.TIF", SearchOption.TopDirectoryOnly)
                    File.Delete(fichero)
                Next

            Catch ex As Exception
                escribirEnLog("*** ERROR. " & Now & ". No ha sido posible borrar los ficheros en el directorio temporal de sustitución" & rutaDirSustitucion & "." & ". ERROR: " & ex.Message)
            End Try

            oDoc = obtieneDocumentoUltimo()
            If Not IsNothing(oDoc) Then pagina = oDoc._pagina Else pagina = 0

            NewProcess.StartInfo.WindowStyle = ProcessWindowStyle.Maximized
            NewProcess.StartInfo.FileName = My.Settings.rutaAplicacionEscaner

            mINI.IniWrite(My.Settings.pathArchivoConfigEscaner, "TIFF", "Save Compression", 1)
            mINI.IniWrite(My.Settings.pathArchivoConfigEscaner, "TIFF", "SaveAllPages", 0)
            mINI.IniWrite(My.Settings.pathArchivoConfigEscaner, "TIFF", "GrayPalette", 0)

            mensajeEX = mensajeEX & "#Después de actualizar configuración genérica de compresión de Irfanview."

            Dim scanHidden As String = ""
            If chkPerfiles.Checked = False Then
                'Si no debe mostrar los perfiles, aplica el parámetro a Ifranview para que no aparezcan.
                scanHidden = " /scanhidden"
            End If

            If batch Then
                'Digitalizar
                mINI.IniWrite(My.Settings.pathArchivoConfigEscaner, "BatchScaning", "SaveDir", oLote._rutaLoteLocal)
                mINI.IniWrite(My.Settings.pathArchivoConfigEscaner, "BatchScaning", "StartingIndex", pagina + 1)

                mensajeEX = mensajeEX & "#Después de actualizar configuración de ruta e índice de Irfanview al escanear en batch."

                NewProcess.StartInfo.Arguments = " /batchscan=(IML," & pagina + 1 & ",1,5,0," & oLote._rutaLoteLocal & ",TIF,0)" & scanHidden
                ' ''nProceso = OpenProcess(PROCESS_QUERY_INFORMATION, False, Shell(My.Settings.rutaAplicacionEscaner & " /batchscan=(IMG," & pagina + 1 & ",1,5,0," & oLote._rutaLoteLocal & ",TIF,0) /scanhiden", vbMaximizedFocus))
            Else
                If insertar Then
                    'Insertar página
                    ' ''ruta = oLote._rutaLoteLocal
                    ruta = rutaDirSustitucion
                    mINI.IniWrite(My.Settings.pathArchivoConfigEscaner, "BatchScaning", "SaveDir", ruta) ' oLote._rutaLoteLocal)

                    mensajeEX = mensajeEX & "#Después de actualizar configuración de ruta de Irfanview al escanear para insertar."

                Else
                    'Sustituir página
                    ruta = rutaDirSustitucion
                    mINI.IniWrite(My.Settings.pathArchivoConfigEscaner, "BatchScaning", "SaveDir", ruta) ' "C:\temp\gScandocs")

                    mensajeEX = mensajeEX & "#Después de actualizar configuración de ruta de Irfanview al escanear para sustituir."

                End If
                mINI.IniWrite(My.Settings.pathArchivoConfigEscaner, "BatchScaning", "StartingIndex", pagina + 1)
                ' ''mINI.IniWrite(My.Settings.pathArchivoConfigEscaner, "BatchScaning", "StartingIndex", 1)

                mensajeEX = mensajeEX & "#Después de actualizar configuración de índice de Irfanview al escanear para insertar o sustituir."

                NewProcess.StartInfo.Arguments = " /batchscan=(TMP,1,1,5,0," & ruta & ",TIF,0)" & scanHidden
                ' ''nProceso = OpenProcess(PROCESS_QUERY_INFORMATION, False, Shell(My.Settings.rutaAplicacionEscaner & " /batchscan=(TMP,1,1,5,0," & My.Settings.DIGI_rutaLocalImagenes & ",TIF,0) /scanhiden", vbMaximizedFocus))
            End If

            NewProcess.Start()
            NewProcess.PriorityClass = ProcessPriorityClass.High

            mensajeEX = mensajeEX & "#Después de lanzar llamada a Irfanview."

            listaDocBd.Clear()
            listaDocDir.Clear()

            listaDocBd = cargaListaDocBd()
            listaDocDir = cargaListaDocDir()

            fechaIni = Now
            horaInicial = Now

            mensajeEX = mensajeEX & "#Antes de comenzar bucle."

            While Not NewProcess.HasExited
                ' ''digitalizando = True
                listaDocResultante.Clear()

                listaDocResultante = listaDocDir.Except(listaDocBd).ToList()    'Añade a la colección resultante las que están en listaDocDir y no en listaDocBd

                If listaDocResultante.Count > 0 Then
                    digitalizando = True
                    For Each nombre As String In listaDocResultante
                        If batch = False And insertar = False Then Exit For ''Si es sustituir no entra en el bucle, solo lo hace si es digitalizar o insertar.
                        If nombre <> "TMP00002.TIF" Then    'Si está en modo duplex, no trata la segunda página que digitaliza al insertar o sustituir.
                            listaDocBd.Add(nombre)   'Añade el valor a la lista de bd para que al comparar no detecte que falta.

                            ' ''System.Threading.Thread.Sleep(30)   '(3000) 3000 son 3 segundos.

                            If batch Then
                                oDocumentoActivo = añadeDocumento(nombre, insertar) 'Añade el documento a la lista principal y al grid, solo si es batch, para insertar lo hace en insertarPagina.
                                If pnlPresentacion3.Visible Then cargarMiniaturaUna(oDocumentoActivo._rutaDocumento, oDocumentoActivo._nombreArchivo, False)
                            End If

                            If insertar = False Then posicionarRegistro(dgv.RowCount - 1) 'Si es insertar no posiciona registro, ya está posicionado

                            oLote._TotalImagenes += 1
                            lblPaginasLote.Text = oLote._TotalImagenes

                            digitalizaAlgo = True
                            horaInicial = Now
                        End If
                    Next

                    If batch = False Then
                        digitalizaAlgo = True
                        Exit While ''Si no es batch no debe esperar a cerra Twain, puesto que solo debe insertar o sustituir una imagen.
                    End If
                Else
                    digitalizando = False
                    'If batch Then
                    '    'Si está más tiempo del configurado sin digitalizar, se sale del bucle
                    '    If horaInicial.AddSeconds(My.Settings.DIGI_timeout_sin_escanear) < Now Then
                    '        Exit While
                    '    End If
                    'End If
                    listaDocDir = cargaListaDocDir()
                End If

                If compruebaProcesoActivo(aplicacionEscaneo) = False Then Exit While

                Application.DoEvents()
            End While

            ' ''MsgBox(NewProcess.StartTime)

            mensajeEX = mensajeEX & "#Al salir del bucle."

            NewProcess.Close()
            NewProcess.Dispose()

            mensajeEX = mensajeEX & "#Después de cerrar proceso Irfanview."

            'Sustituye documento
            If batch = False Then
                If IO.File.Exists(rutaDirSustitucion & "\TMP00001.TIF") = False Then
                    Exit Function
                End If

                If digitalizaAlgo Then

                    recargaMiniaturas = True

                    ' ''System.Threading.Thread.Sleep(1000) '3000 son 3 segundos. Paro por si sale demasiado rápido del bucle 

                    ' ''While File.Exists(rutaDirSustitucion & "\TMP00001.TIF") = False
                    ' ''    'Se queda en el bucle mientras que no exista el fichero, ya que no se crea hasta que no pasa el tiempo de espera del escaner.
                    ' ''End While
                    If esperaDesbloqueoFichero(rutaDirSustitucion & "\TMP00001.TIF") = False Then
                        System.Threading.Thread.Sleep(1000)
                    End If

                    If insertar Then
                        'Borra la segunda página por si está en modo duplex y digitaliza algo.
                        If IO.File.Exists(rutaDirSustitucion & "\TMP00002.TIF") Then
                            IO.File.Delete(rutaDirSustitucion & "\TMP00002.TIF")
                        End If

                        guardaEnBdDocumentos()

                        mensaje = insertaPagina(dgv.SelectedRows(0).Cells("pagina").Value)
                        If mensaje <> "" Then
                            escribirEnLog("*** ERROR USUARIO. " & Now & ". Lote " & lblLote.Text & ". Ocurrió un error al insertar página." & vbLf & "Mensaje capturado: " & mensaje & vbLf & mensajeEX)
                            MessageBox.Show("Ocurrió un error al insertar página." & vbLf & mensaje, "Error al insertar página", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    Else
                        Rename(oDocumentoActivo._rutaDocumento, oDocumentoActivo._rutaDocumento.ToUpper.Replace(".TIF", ".ISC"))

                        FileCopy(rutaDirSustitucion & "\TMP00001.TIF", oDocumentoActivo._rutaDocumento)

                        File.Delete(oDocumentoActivo._rutaDocumento.ToUpper.Replace(".TIF", ".ISC"))

                        If File.Exists(oDocumentoActivo._rutaDocumento.Replace("\IML", "\MINIATURAS\IML").ToUpper.Replace("TIF", "PNG")) Then
                            File.Delete(oDocumentoActivo._rutaDocumento.Replace("\IML", "\MINIATURAS\IML").ToUpper.Replace("TIF", "PNG"))
                        End If
                    End If
                End If

                mensajeEX = mensajeEX & "#Después de gestionar si sustituye o inserta."

                'Borra documentos temporales
                For Each fichero As String In Directory.GetFiles(rutaDirSustitucion, "*.*", SearchOption.TopDirectoryOnly)  'Directory.GetFiles(oLote._rutaLoteLocal, "*.TIF", SearchOption.TopDirectoryOnly)
                    File.Delete(fichero)
                Next

                mensajeEX = mensajeEX & "#Después de borrar documentos temporales."

                If insertar Then
                    recargaMiniaturas = True
                    digitalizando = False
                    refrescarLista(dgv.SelectedRows(0).Cells("pagina").Value)
                Else
                    ' ''recargaMiniaturas = True
                    recargaMiniaturas = False
                    If pnlPresentacion3.Visible Then cargarMiniaturaUna(oDocumentoActivo._rutaDocumento, oDocumentoActivo._pagina, True)

                    digitalizando = False
                    dgv_Click(Nothing, Nothing)

                End If

                mensajeEX = mensajeEX & "#Después de recargar."

                'Cierra irfanview para forzar a iniciar el bucle la próxima vez que se abra.
                Try
                    cerrarProcesoActivo(aplicacionEscaneo)

                Catch ex As Exception

                End Try

                mensajeEX = mensajeEX & "#Después de cerrar Irfanview."

            End If

            digitalizando = False

            mensajeEX = mensajeEX & "#Termina proceso digitalizar."

        Catch ex As Exception
            ' ''Dim mensajeEX As String = ""
            'Excepción interna
            If ex.InnerException IsNot Nothing Then
                mensajeEX = mensajeEX & vbLf & " Inner exception: " & ex.InnerException.Message
            End If
            escribirEnLog("*** ERROR. " & Now & ". Ocurrió un error al digitalizar documentos." & vbLf & "Mensaje capturado: " & mensaje & vbLf & ex.Message & vbLf & mensajeEX & vbLf & ex.StackTrace)

            Throw ex

        Finally
            digitalizar = mensajeEX
        End Try

    End Function

    Private Function obtieneDocumentoUltimo() As clsDocumentoE
        Dim oDoc As New clsDocumentoE

        Try
            oDoc = oListaDocumentos.LastOrDefault()

        Catch ex As Exception
            Throw ex
        Finally
            obtieneDocumentoUltimo = oDoc
        End Try

    End Function

    Private Function obtieneDocumento(ByVal idDocumento As Long) As clsDocumentoE

        Dim oDoc As New clsDocumentoE

        Try
            oDoc = oListaDocumentos.Find(Function(obj As clsDocumentoE) obj._idDocumento = Convert.ToInt64(idDocumento))

        Catch ex As Exception
            Throw ex
        Finally
            obtieneDocumento = oDoc
        End Try

    End Function

    Private Function obtieneDocumento_Por_Pagina(ByVal idPagina As Integer) As clsDocumentoE

        Dim oDoc As New clsDocumentoE

        Try
            oDoc = oListaDocumentos.Find(Function(obj As clsDocumentoE) obj._pagina = Convert.ToInt32(idPagina))

        Catch ex As Exception
            Throw ex
        Finally
            obtieneDocumento_Por_Pagina = oDoc
        End Try

    End Function

    Private Function obtieneFicheroDeLaRuta(ByVal ruta As String) As String

        Dim coleccion As String()

        coleccion = ruta.Split("\")

        obtieneFicheroDeLaRuta = coleccion(coleccion.Count - 1)

    End Function

    Private Function compruebaDocServidorSinBD() As String

        Dim ficheroConExtension As String = ""
        Dim ficheroSinExtension As String = ""
        Dim doc As New List(Of clsDocumentoE)
        Dim oDoc As New clsDocumentoE
        Dim listaDoc As New List(Of clsDocumentoE)
        Dim resultado As String = ""

        Dim ficherosEnDirServidor As Integer = Directory.GetFiles(oLote._rutaLote.ToUpper, "*.TIF", SearchOption.TopDirectoryOnly).Count
        Dim ficherosEnBdServidor As Integer = (From documento As clsDocumentoE In oListaDocumentos Where documento._documentoEnLocal = False).ToList.Count

        Try

            If ficherosEnDirServidor <> ficherosEnBdServidor Then
                If ficherosEnDirServidor > ficherosEnBdServidor Then
                    For Each Fichero As String In Directory.GetFiles(oLote._rutaLote.ToUpper, "*.TIF", SearchOption.TopDirectoryOnly)
                        ficheroConExtension = obtieneFicheroDeLaRuta(Fichero)
                        ficheroSinExtension = ficheroConExtension.Substring(0, ficheroConExtension.Length - 4).ToString.Trim

                        doc = (From documento As clsDocumentoE In oListaDocumentos Where documento._nombreArchivo.ToUpper = ficheroConExtension.ToUpper).ToList

                        If doc.Count = 0 Then
                            oDoc = New clsDocumentoE(CInt("99999" & CInt(ficheroSinExtension.Substring(3))), oLote._Lote, CInt(ficheroSinExtension.Substring(3)), ficheroConExtension.ToUpper, 0, _
                                                     rutaImagenes & "\" & Format(Val(oLote._codigoProyecto), "0000") & "\DIGI\" & Format(Val(oLote._codigoProyecto), "0000") & Format(Val(oLote._Lote), "00000") & "\Imagen\" & oLote._Lote & "\" & ficheroConExtension)

                            oDoc._documentoEnLocal = False

                            resultado = resultado & ", " & oDoc._pagina

                            oListaDocumentos.Add(oDoc)

                        End If
                    Next
                    If resultado.ToString.Trim <> "" Then resultado = resultado.Substring(1).ToString.Trim
                End If
            End If

        Catch ex As Exception
            Throw ex

        Finally
            compruebaDocServidorSinBD = resultado
        End Try

    End Function

    Private Function compruebaDocLocalSinBD() As List(Of clsDocumentoE)

        Dim pagina
        Dim ficheroConExtension As String = ""
        Dim ficheroSinExtension As String = ""
        Dim listaDoc As New List(Of clsDocumentoE)

        'Comprueba en local si hay mas documentos digitalizados que no hayan sido grabados en base de datos, si los hay, los carga y avisa.
        Dim oDoc As clsDocumentoE = obtieneDocumentoUltimo()

        Try
            If Not IsNothing(oDoc) Then
                pagina = oDoc._nombreArchivo.Substring(3).ToString.Trim
                pagina = CInt(pagina.Substring(0, pagina.Length - 4))
            Else
                pagina = 0
            End If

            For Each Fichero As String In Directory.GetFiles(oLote._rutaLoteLocal, "*.TIF", SearchOption.TopDirectoryOnly)
                ficheroConExtension = obtieneFicheroDeLaRuta(Fichero)
                ficheroSinExtension = ficheroConExtension.Substring(0, ficheroConExtension.Length - 4).ToString.Trim

                If CInt(ficheroSinExtension.Substring(3)) > CInt(pagina) Then
                    oDoc = New clsDocumentoE(CInt("99999" & CInt(ficheroSinExtension.Substring(3))), oLote._Lote, CInt(ficheroSinExtension.Substring(3)), ficheroConExtension.ToUpper, 0, _
                                             My.Settings.DIGI_rutaLocalImagenes & "\" & Format(Val(oLote._codigoProyecto), "0000") & "\DIGI\" & Format(Val(oLote._codigoProyecto), "0000") & Format(Val(oLote._Lote), "00000") & "\Imagen\" & oLote._Lote & "\" & ficheroConExtension)

                    oDoc._documentoEnBD = False

                    ' ''oDoc._idDocumento = CInt("99999" & CInt(ficheroSinExtension.Substring(3)))
                    ' ''oDoc._Lote = oLote._Lote
                    ' ''oDoc._pagina = CInt(ficheroSinExtension.Substring(3))
                    ' ''oDoc._nombreArchivo = ficheroConExtension.ToUpper
                    ' ''oDoc._Indizado = 0
                    ' ''oDoc._BarCodeDet = 0
                    ' ''oDoc._Incidencia = 0
                    ' ''oDoc._Eliminado = 0
                    ' ''oDoc._documentoEnLocal = True
                    ' ''oDoc._rutaDocumento = My.Settings.DIGI_rutaLocalImagenes & "\" & Format(Val(oLote._codigoProyecto), "0000") & "\DIGI\" & Format(Val(oLote._codigoProyecto), "0000") & Format(Val(oLote._Lote), "00000") & "\Imagen\" & oLote._Lote & "\" & ficheroConExtension

                    listaDoc.Add(oDoc)
                End If
            Next

        Catch ex As Exception

        Finally
            compruebaDocLocalSinBD = listaDoc
        End Try
    End Function

    Private Sub mnuSustituirImagen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSustituirImagen.Click
        tsbAccion1_Click(Nothing, Nothing)
    End Sub

    Private Sub mnuEliminarImagen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEliminarImagen.Click
        tsbAccion2_Click(Nothing, Nothing)
    End Sub

    Private Sub mnuOriginalMalEstado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuOriginalMalEstado.Click
        tsbAccion4_Click(Nothing, Nothing)
    End Sub

    Private Sub cmdDigitalizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDigitalizar.Click
        Dim mensaje As String = ""

        Try
            'Cierra irfanview si está activo
            ' ''cerrarProcesoActivo(aplicacionEscaneo)

            ' ''If tsbImagenMini.Checked Then
            ' ''    posicionarRegistro(dgv.Rows.Count - 1)
            ' ''    tsbImagen1_Click(tsbImagen1, Nothing)
            ' ''End If

            mensaje = digitalizar(True, False)

        Catch ex As Exception
            Dim mensajeEX As String = ""
            'Excepción interna
            If ex.InnerException IsNot Nothing Then
                mensajeEX = " Inner exception: " & ex.InnerException.Message
            End If

            If mensaje.ToUpper.Contains("ACCESO DENEGADO") Or ex.Message.ToUpper.Contains("ACCESO DENEGADO") Or mensaje.ToUpper.Contains("DENIED") Or ex.Message.ToUpper.Contains("DENIED") Then
                escribirEnLog("*** ERROR USUARIO. " & Now & ". Lote " & lblLote.Text & ". Ocurrió un error al digitalizar documentos. Error de comunicación con el escáner" & vbLf & "Mensaje capturado: " & mensaje & vbLf & ex.Message & vbLf & mensajeEX & vbLf & ex.StackTrace)
                MessageBox.Show("Ocurrió un error de comunicación con el escáner, por favor, apáguelo, vuelva a encenderlo y pruebe a realizar de nuevo la operación." & vbCrLf & ex.Message, "Error de comunicación con escáner", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                escribirEnLog("*** ERROR USUARIO. " & Now & ". Lote " & lblLote.Text & ". Ocurrió un error al digitalizar documentos." & vbLf & "Mensaje capturado: " & mensaje & vbLf & ex.Message & vbLf & mensajeEX & vbLf & ex.StackTrace)
                MessageBox.Show("Ocurrió un error al digitalizar documentos." & vbCrLf & ex.Message, "Error al digitalizar", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        End Try

    End Sub

    Private Function cargaListaDocBd() As List(Of String)
        Dim lista As New List(Of String)

        Try
            For Each doc As clsDocumentoE In oListaDocumentos
                lista.Add(doc._nombreArchivo.ToUpper)
            Next

        Catch ex As Exception
            Throw ex

        Finally
            cargaListaDocBd = lista

        End Try

    End Function

    Private Function cargaListaDocDir() As List(Of String)
        Dim lista As New List(Of String)

        Try
            For Each Fichero As String In Directory.GetFiles(oLote._rutaLote, "*.TIF", SearchOption.TopDirectoryOnly)
                lista.Add(obtieneFicheroDeLaRuta(Fichero).ToUpper)
            Next

            For Each Fichero As String In Directory.GetFiles(oLote._rutaLoteLocal, "*.TIF", SearchOption.TopDirectoryOnly)
                lista.Add(obtieneFicheroDeLaRuta(Fichero).ToUpper)
            Next

            For Each Fichero As String In Directory.GetFiles(rutaDirSustitucion, "*1.TIF", SearchOption.TopDirectoryOnly)
                lista.Add(obtieneFicheroDeLaRuta(Fichero).ToUpper)
            Next

        Catch ex As Exception
            Throw ex

        Finally
            cargaListaDocDir = lista

        End Try

    End Function

    Private Function añadeDocumento(ByVal nombreFichero As String, ByVal inserta As Boolean) As clsDocumentoE

        Dim ficheroSinExtension As String = nombreFichero.Substring(0, nombreFichero.Length - 4).ToString.Trim
        Dim pagina As Integer
        Dim ruta As String = ""

        If inserta Then
            pagina = dgv.SelectedRows(0).Cells("pagina").Value
            ruta = rutaDirSustitucion & "\" & ficheroSinExtension & ".TIF"
        Else
            pagina = CInt(ficheroSinExtension.Substring(3))
            ruta = My.Settings.DIGI_rutaLocalImagenes & "\" & Format(Val(oLote._codigoProyecto), "0000") & "\DIGI\" & Format(Val(oLote._codigoProyecto), "0000") & Format(Val(oLote._Lote), "00000") & "\Imagen\" & oLote._Lote & "\" & ficheroSinExtension & ".TIF"
        End If

        Dim Doc As clsDocumentoE = New clsDocumentoE(CInt("99999" & CInt(ficheroSinExtension.Substring(3))), oLote._Lote, pagina, ficheroSinExtension & ".TIF", 0, _
                                     ruta)
        Doc._documentoEnBD = False

        oListaDocumentos.Add(Doc)

        dgv.Rows.Add()
        dgv.Rows(dgv.RowCount - 1).Cells(0).Value = Doc._idDocumento
        dgv.Rows(dgv.RowCount - 1).Cells(1).Value = Doc._pagina
        dgv.Rows(dgv.RowCount - 1).Cells(2).Value = Doc._nombreArchivo
        dgv.Rows(dgv.RowCount - 1).Cells(3).Value = IIf(Doc._historia = 0, "", Doc._historia)

        añadeDocumento = Doc

    End Function

    Private Function eliminarImagen(ByVal documento As clsDocumentoE) As String
        Dim mensaje As String = ""

        Try
            If IO.File.Exists(documento._rutaDocumento) Then
                IO.File.Delete(documento._rutaDocumento)
            Else
                mensaje = "*** ERROR. Ocurrió un error al eliminar la página " & documento._pagina & " del lote " & documento._Lote & ". No existe la imagen en el disco."
                ' ''Exit Function
            End If

        Catch ex As Exception
            mensaje = "*** ERROR. Ocurrió un error al eliminar la página " & documento._pagina & " del lote " & documento._Lote & " del disco." & vbLf & ex.Message
            Throw ex
        Finally
            eliminarImagen = mensaje
        End Try

        Try
            If IO.File.Exists(documento._rutaDocumento.Replace("\IML", "\MINIATURAS\IML").ToUpper.Replace("TIF", "PNG")) Then
                IO.File.Delete(documento._rutaDocumento.Replace("\IML", "\MINIATURAS\IML").ToUpper.Replace("TIF", "PNG"))
                ' ''Else
                ' ''    mensaje = "*** ERROR. Ocurrió un error al eliminar la miniatura de la pagina " & documento._pagina & " del lote " & documento._Lote & ". No existe la imagen en el disco."
                ' ''    Exit Function
            End If

        Catch ex As Exception
            mensaje = "*** ERROR. Ocurrió un error al eliminar la miniatura de la pagina " & documento._pagina & " del lote " & documento._Lote & " del disco." & vbLf & ex.Message
            Throw ex
        Finally
            eliminarImagen = mensaje
        End Try

        Try
            If documento._documentoEnBD Then
                Dim lsSql As String = "DELETE FROM Documentos WHERE idLote=" & lblLote.Text.ToString.Trim & " AND Pagina=" & documento._pagina
                accesoDatosNew.ejecutaSQLEjecucion(lsSql, cadenaConexionProyecto, , False)
            End If

        Catch ex As Exception
            mensaje = "*** ERROR. Ocurrió un error al eliminar la página " & documento._pagina & " del lote " & documento._Lote & " de base de datos." & vbLf & ex.Message
        Finally
            eliminarImagen = mensaje
        End Try

    End Function

    Private Sub tsbAccion2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAccion2.Click
        'ELIMINAR PAGINAS SELECCIONADAS
        Dim mensaje As String = ""
        Dim documento As clsDocumentoE
        Dim posicionaEnPagina As Integer = 1000
        Dim grid As DataGridViewSelectedRowCollection = dgv.SelectedRows

        Me.Cursor = Cursors.WaitCursor

        Try
            If dgv.SelectedRows.Count > 0 Then
                If MessageBox.Show("Ha seleccionado " & dgv.SelectedRows.Count & " página/s para borrar. ¿Desea continuar con la operación?", "Borrar páginas", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.OK Then
                    posicionaEnPagina = dgv.CurrentRow.Index

                    recargaMiniaturas = False

                    guardaEnBdDocumentos()

                    ''obligaRecargaMiniaturas = False

                    If dgv.CurrentRow.Index >= 0 Then
                        refrescarLista(dgv.Rows(dgv.CurrentRow.Index).Cells("Pagina").Value)
                    Else
                        refrescarLista(1)
                    End If

                    ''obligaRecargaMiniaturas = True
                    recargaMiniaturas = True

                    ' ''For Each fila As DataGridViewRow In dgv.SelectedRows
                    For Each fila As DataGridViewRow In grid
                        documento = obtieneDocumento_Por_Pagina(fila.Cells(1).Value)
                        If Not IsNothing(documento) Then
                            mensaje = eliminarImagen(documento)
                        Else
                            MessageBox.Show("Error al identificar página " & fila.Cells(1).Value & " del lote " & lblLote.Text & " para borrar, contacte con el servicio de informática.", "Borrar páginas", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            escribirEnLog("*** ERROR USUARIO. " & Now & ". Lote " & lblLote.Text & " Error al identificar página " & fila.Cells(1).Value & " del lote " & lblLote.Text & " para borrar, contacte con el servicio de informática." & vbLf & mensaje)
                        End If
                    Next
                Else
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If

                If mensaje.ToString.Trim <> "" Then
                    MessageBox.Show("Ocurrió un error al borrar alguna de las páginas seleccionadas." & vbLf & mensaje, "Error al borrar", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    escribirEnLog("*** ERROR USUARIO. " & Now & ". Lote " & lblLote.Text & " Ocurrió un error al borrar alguna de las páginas seleccionadas." & vbLf & mensaje)
                Else
                    MessageBox.Show("Las páginas seleccionadas se borraron correctamente.", "Borrado correcto", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

                recargaMiniaturas = False

                ' ''guardaEnBdDocumentos()

                ''Recarga lista general de documentos después de borrar y antes de repaginar.
                Dim lsSqlCargaDocumentos As String = "SELECT * FROM DOCUMENTOS d LEFT JOIN TIPOSDOCUMENTOS td ON td.idTipoDocumento = d.TipoDocumento LEFT JOIN SERVICIOS s on s.idServicio = d.CodServicioPAED WHERE idLote=" & lblLote.Text.ToString.Trim & " ORDER BY PAGINA"
                oListaDocumentos.Clear()
                oListaDocumentos = accesoDatosNuevos.clsAccesoDatosNUEVO.cargaDocumentos(cadenaConexionProyecto, lsSqlCargaDocumentos, codigoProyecto, rutaImagenes)
                oLote._ListaDocumentos = oListaDocumentos

                mensaje = repaginar()

                ' ''If mensaje.ToString.Trim <> "" Then
                ' ''    MessageBox.Show("Ocurrió un error al repaginar después de borrar la/s página/s.", "Brrar páginas", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ' ''End If

                marcaInicioHistorias()

                'Vuelvo a recargar después de repaginar
                If posicionaEnPagina = 0 Then posicionaEnPagina = 1 'ESto lo hago para que el valor no sea 0
                recargaMiniaturas = True

                Try
                    ' ''refrescarLista(dgv.Rows(posicionaEnPagina - 1).Cells("Pagina").Value)    'Refresca lista
                    refrescarLista(dgv.Rows(posicionaEnPagina - 1).Cells("Pagina").Value)    'Refresca lista
                Catch ex As Exception
                    refrescarLista(1)    'Refresca lista
                End Try

                'Recarga las listas para comparar si se está digitalizando, por si se utiliza el twain abierto
                listaDocBd = cargaListaDocBd()
                listaDocDir = cargaListaDocDir()
            Else
                MessageBox.Show("No hay páginas seleccionadas para borrar.", "Borrar páginas", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            Dim mensajeEX As String = ""
            'Excepción interna
            If ex.InnerException IsNot Nothing Then
                mensajeEX = " Inner exception: " & ex.InnerException.Message
            End If
            escribirEnLog("*** ERROR USUARIO. " & Now & ". Lote " & lblLote.Text & " Ocurrió un error al borrar las páginas seleccionadas." & vbLf & ex.Message & vbLf & mensajeEX & vbLf & ex.StackTrace)

            MessageBox.Show("Ocurrió un error al borrar las páginas seleccionadas." & vbLf & mensaje & vbLf & ex.Message, "Error al borrar", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub


    Private Sub refrescarLista(ByVal posicionaEnPagina As Integer)
        Try
            cargarDatosDocumento()

            cargarListaDocumentos(posicionaEnPagina)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub



    Private Function _funcionEstandard() As String
        Dim mensaje As String = ""

        Try

        Catch ex As Exception
            mensaje = "*** ERROR. " & Now & "  "
            Throw ex
        Finally
            _funcionEstandard = mensaje
        End Try

    End Function

    Private Sub _procedimientoEstandard()
        Dim mensaje As String = ""

        Try

        Catch ex As Exception
            mensaje = "*** ERROR. " & Now & "  "
            Throw ex
        Finally

        End Try

    End Sub

    Private Sub tsbRegistroAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRegistroAnterior.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            If dgv.Rows.Count > 0 And dgv.CurrentRow.Index > 0 Then
                posicionarRegistro(dgv.CurrentRow.Index - 1)
            End If

        Catch ex As Exception
            Dim mensajeEX As String = ""
            'Excepción interna
            If ex.InnerException IsNot Nothing Then
                mensajeEX = " Inner exception: " & ex.InnerException.Message
            End If
            escribirEnLog("*** ERROR. " & Now & ". Ocurrió un error al ir a la página anterior." & vbLf & ex.Message & vbLf & mensajeEX & vbLf & ex.StackTrace)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub tsbRegistroUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRegistroUltimo.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            If dgv.Rows.Count > 0 And dgv.CurrentRow.Index < (dgv.RowCount - 1) Then
                posicionarRegistro(dgv.RowCount - 1)
            End If

        Catch ex As Exception
            Dim mensajeEX As String = ""
            'Excepción interna
            If ex.InnerException IsNot Nothing Then
                mensajeEX = " Inner exception: " & ex.InnerException.Message
            End If
            escribirEnLog("*** ERROR. " & Now & ". Ocurrió un error al ir a la última página." & vbLf & ex.Message & vbLf & mensajeEX & vbLf & ex.StackTrace)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub stsBuscaPagina_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles stsBuscaPagina.KeyDown

        Try
            e.Handled = True

            Me.Cursor = Cursors.WaitCursor

            Select Case e.KeyCode
                Case Keys.Enter     'buscar página
                    If IsNumeric(stsBuscaPagina.Text.ToString.Trim) Then
                        If dgv.Rows.Count >= Convert.ToInt32(stsBuscaPagina.Text.ToString.Trim) Then
                            BuscarEnGridLINQ(stsBuscaPagina.Text.ToString.Trim, "Pagina", dgv)
                            posicionarRegistro(dgv.CurrentRow.Index)

                        Else
                            MessageBox.Show("El lote solo tiene " & dgv.Rows.Count & " páginas.", "Buscar página", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    Else
                        MessageBox.Show("El número de página debe ser numérico.", "Buscar página", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                    stsBuscaPagina.Text = ""
            End Select

        Catch ex As Exception
            Dim mensajeEX As String = ""
            'Excepción interna
            If ex.InnerException IsNot Nothing Then
                mensajeEX = " Inner exception: " & ex.InnerException.Message
            End If
            escribirEnLog("*** ERROR. " & Now & ". Ocurrió un error al ir a la página indicada." & vbLf & ex.Message & vbLf & mensajeEX & vbLf & ex.StackTrace)

        Finally
            Me.Cursor = Cursors.Default
            e.Handled = False

        End Try


    End Sub

    Private Sub tsbRegistroPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRegistroPrimero.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            If dgv.Rows.Count > 0 Then
                posicionarRegistro(0)
            End If

        Catch ex As Exception
            Dim mensajeEX As String = ""
            'Excepción interna
            If ex.InnerException IsNot Nothing Then
                mensajeEX = " Inner exception: " & ex.InnerException.Message
            End If
            escribirEnLog("*** ERROR. " & Now & ". Ocurrió un error al ir a la primera página." & vbLf & ex.Message & vbLf & mensajeEX & vbLf & ex.StackTrace)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub tsbRegistroSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRegistroSiguiente.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            If dgv.Rows.Count > 1 And dgv.CurrentRow.Index < dgv.RowCount - 1 Then
                posicionarRegistro(dgv.CurrentRow.Index + 1)
            End If

        Catch ex As Exception
            Dim mensajeEX As String = ""
            'Excepción interna
            If ex.InnerException IsNot Nothing Then
                mensajeEX = " Inner exception: " & ex.InnerException.Message
            End If
            escribirEnLog("*** ERROR. " & Now & ". Ocurrió un error al ir a la página siguiente." & vbLf & ex.Message & vbLf & mensajeEX & vbLf & ex.StackTrace)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub posicionarRegistro(ByVal posicion As Integer)
        Try
            Dim objetoPicture As PictureBox
            Dim nombreBoton As String

            If pnlPresentacion1.Visible Then
                objetoPicture = IMGeditPrincipal
                nombreBoton = nombreControlImagen1
            ElseIf pnlPresentacion2.Visible Then
                objetoPicture = imgEditDerecha
                nombreBoton = nombreControlImagen2
            Else
                objetoPicture = Nothing
                nombreBoton = nombreControlImagenMini
            End If

            dgv.Rows(posicion).Selected = True
            dgv.CurrentCell = dgv.Item(0, posicion)
            oDocumentoActivo = obtieneDocumento(dgv.Rows(posicion).Cells("idDocumento").Value)
            controlAccionesPresentacion(objetoPicture, nombreBoton)

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub dgv_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgv.KeyUp

        Select Case e.KeyCode
            Case Keys.Up
                If dgv.Rows.Count > 0 Then
                    dgv_Click(dgv, Nothing)
                End If

            Case Keys.Down
                If dgv.Rows.Count > 0 Then
                    dgv_Click(dgv, Nothing)
                End If
        End Select
    End Sub

    Private Function obtenerLotesImagenesPorUsuarioHoy() As String
        Dim resultado As String = ""
        Dim fecha As Date = Now
        Dim lsSql As String = "SELECT tl.idLote, count(*) as numDocumentos FROM DOCUMENTOS d LEFT JOIN TRAZABILIDADLOTES tl ON tl.idLote = D.idlote WHERE convert(date,tl.FechaFinDigitalizado)='" & Format(fecha, "dd-MM-yyyy") & "' AND UsuarioDigitalizado='" & loginUsuario & "' group by tl.idLote "
        Dim contador As Integer = 0
        Dim numDocs As Integer = 0

        Try
            For Each registro As DataRow In accesoDatosNew.ejecutarSQLDirectaTable(lsSql, cadenaConexionProyecto).Rows

                numDocs = numDocs + registro.Item("numDocumentos")
                contador += 1

            Next

            resultado = loginUsuario & " ha digitalizado hoy " & contador & " lotes con un total de " & Format(numDocs, "#,##0") & " documentos."

        Catch ex As Exception
            Throw ex
        End Try

        Return resultado

    End Function

    Private Sub tsbAccion1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAccion1.Click
        'SUSTITUIR PAGINAS
        Dim mensaje As String = ""

        Try
            Me.Cursor = Cursors.WaitCursor

            If dgv.SelectedRows.Count = 1 Then
                'Cierra irfanview si está activo
                ' ''cerrarProcesoActivo(aplicacionEscaneo)

                mensaje = digitalizar(False, False)
            Else
                MessageBox.Show("Solo se puede sustituir una página.", "Sustituir páginas", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            Dim mensajeEX As String = ""
            'Excepción interna
            If ex.InnerException IsNot Nothing Then
                mensajeEX = " Inner exception: " & ex.InnerException.Message
            End If

            If mensaje.ToUpper.Contains("ACCESO DENEGADO") Or ex.Message.ToUpper.Contains("ACCESO DENEGADO") Or mensaje.ToUpper.Contains("DENIED") Or ex.Message.ToUpper.Contains("DENIED") Then
                escribirEnLog("*** ERROR USUARIO. " & Now & ". Lote " & lblLote.Text & ". Ocurrió un error al sustituir la página. Error de comunicación con el escáner" & vbLf & "Mensaje capturado: " & mensaje & vbLf & ex.Message & vbLf & mensajeEX & vbLf & ex.StackTrace)
                MessageBox.Show("Ocurrió un error de comunicación con el escáner, por favor, apáguelo, vuelva a encenderlo y pruebe a realizar de nuevo la operación." & vbCrLf & ex.Message, "Error de comunicación con escáner", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                escribirEnLog("*** ERROR USUARIO. " & Now & ". Lote " & lblLote.Text & ". Ocurrió un error al sustituir la página." & vbLf & "Mensaje capturado: " & mensaje & vbLf & ex.Message & vbLf & mensajeEX & vbLf & ex.StackTrace)
                MessageBox.Show("Ocurrió un error al sustituir la página." & vbCrLf & ex.Message, "Error al sustituir página", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            ' ''escribirEnLog("*** ERROR USUARIO. " & Now & ". Lote " & lblLote.Text & ". Ocurrió un error al sustituir la página." & vbLf & "Mensaje capturado: " & mensaje & vbLf & ex.Message & vbLf & mensajeEX & vbLf & ex.StackTrace)
            ' ''MessageBox.Show("Ocurrió un error al sustituir la página." & vbCrLf & ex.Message, "Error al sustituir", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub cmdGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGuardar.Click
        'Guardar NHC de páginas seleccionadas.
        Dim mensaje As String = ""
        Dim documento As clsDocumentoE
        Dim lsSql As String = ""
        Dim paciente As String = ""
        Dim grid As DataGridViewSelectedRowCollection = dgv.SelectedRows

        Try
            If txtNHC.Text.ToString.Trim <> "" And Not IsNumeric(txtNHC.Text.ToString.Trim) Then
                MessageBox.Show("El número de historia debe ser numérico.", "Guardar Nº historia", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            ' ''If txtNHC.Text.ToString.Trim = "" Or Not IsNumeric(txtNHC.Text.ToString.Trim) Then
            ' ''    MessageBox.Show("El número de historia debe ser numérico y no estar vacío.", "Guardar Nº historia", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ' ''    Exit Sub
            ' ''Else
            If txtNHC.Text.ToString.Trim <> "" And IsNumeric(txtNHC.Text.ToString.Trim) Then
                paciente = accesoDatosNew.ObtenerValor(cadenaConexionProyecto, "SELECT NOMBRE + '  ' + APELLIDO1 + '  ' + APELLIDO2 AS PACIENTE FROM FIP WHERE numhistoria=" & txtNHC.Text.ToString.Trim)
                If paciente = "" Then

                    If My.Settings.DIGI_validar_NHC Then
                        MessageBox.Show("El número de historia " & txtNHC.Text.ToString.Trim & " no corresponde a ningún paciente, la operación no se realizará.", "Guardar Nº historia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    Else
                        MessageBox.Show("Aunque el número de historia " & txtNHC.Text.ToString.Trim & " no corresponde a ningún paciente se realizará la operación." & vbLf & " Revise que no existe un error de transcripción.", "Guardar Nº historia", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            End If

            'paciente
            'If txtNHC.Text.ToString.Trim = "" Or Not IsNumeric(txtNHC.Text.ToString.Trim) Then
            '    MessageBox.Show("El número de historia debe ser numérico y no estar vacío.", "Guardar Nº historia", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    Exit Sub
            'End If

            Dim nHistoria As String = txtNHC.Text.ToString.Trim

            Me.Cursor = Cursors.WaitCursor

            If dgv.SelectedRows.Count > 0 Then
                If paciente Is Nothing Then paciente = "DESCONOCIDO"
                If MessageBox.Show("Ha seleccionado " & dgv.SelectedRows.Count & " página/s para guardar número el de historia " & nHistoria & " correspondiente al paciente " & paciente.ToUpper & ". ¿Desea continuar con la operación?", "Guardar Nº historia", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.OK Then

                    guardaEnBdDocumentos()

                    refrescarLista(dgv.Rows(dgv.CurrentRow.Index).Cells("Pagina").Value)

                    ' ''For Each fila As DataGridViewRow In dgv.SelectedRows
                    For Each fila As DataGridViewRow In grid
                        documento = obtieneDocumento_Por_Pagina(fila.Cells(1).Value)
                        ' ''documento = obtieneDocumento(fila.Cells(0).Value)
                        If Not IsNothing(documento) Then
                            If documento._documentoEnBD Then
                                If nHistoria <> "" Then
                                    lsSql = lsSql & "; UPDATE DOCUMENTOS SET numHistoria=" & nHistoria & " WHERE idDocumento=" & documento._idDocumento
                                Else
                                    lsSql = lsSql & "; UPDATE DOCUMENTOS SET numHistoria=NULL, BarcodeDet=NULL WHERE idDocumento=" & documento._idDocumento
                                End If
                            Else
                                If txtNHC.Text.ToString.Trim <> "" Then
                                    lsSql = lsSql & "; INSERT INTO DOCUMENTOS (idLote, Pagina, NomArchivoTIF, numHistoria, documentoEnLocal) VALUES (" & lblLote.Text & ", " & documento._pagina & ", '" & documento._nombreArchivo & "', " & nHistoria & ", " & IIf(documento._documentoEnLocal, 1, 0) & ")"
                                Else
                                    lsSql = lsSql & "; INSERT INTO DOCUMENTOS (idLote, Pagina, NomArchivoTIF, documentoEnLocal) VALUES (" & lblLote.Text & ", " & documento._pagina & ", '" & documento._nombreArchivo & ", " & IIf(documento._documentoEnLocal, 1, 0) & ")"
                                End If
                            End If
                        Else
                            MessageBox.Show("Error al identificar página " & documento._pagina & " del lote " & lblLote.Text & " para guardar número de historia, contacte con el servicio de informática.", "Guardar Nº historia", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            escribirEnLog("*** ERROR USUARIO. " & Now & ". Lote " & lblLote.Text & ". Error al identificar página " & documento._pagina & " del lote " & lblLote.Text & " para guardar número de historia, contacte con el servicio de informática.")
                        End If
                    Next
                    lsSql = lsSql.Substring(1).ToString.Trim
                    lsSql = lsSql & ";UPDATE LOTES SET DAT='" & cboTipoLote.Text.ToString.Trim & "', TotalImg=" & lblPaginasLote.Text & " WHERE idLote=" & lblLote.Text
                    mensaje = accesoDatosNew.ejecutarSQLConTransaccion(lsSql, cadenaConexionProyecto)

                    marcaInicioHistorias()

                    dgv.Refresh()

                    If dgv.CurrentRow.Index >= 0 Then
                        refrescarLista(dgv.Rows(dgv.CurrentRow.Index).Cells("Pagina").Value)
                    Else
                        refrescarLista(1)
                    End If
                Else
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
            Else
                MessageBox.Show("No hay páginas seleccionadas para rotar.", "Rotar páginas", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If


        Catch ex As Exception
            Dim mensajeEX As String = ""
            'Excepción interna
            If ex.InnerException IsNot Nothing Then
                mensajeEX = " Inner exception: " & ex.InnerException.Message
            End If
            escribirEnLog("*** ERROR USUARIO. " & Now & ". Lote " & lblLote.Text & ". Ocurrió un error al guardar número de historia de las páginas." & vbLf & ex.Message & vbLf & mensajeEX & vbLf & ex.StackTrace)

            MessageBox.Show("Ocurrió un error al guardar número de historia de las páginas." & vbCrLf & ex.Message, "Error al Guardar Nº historia", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub lstNHC_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstNHC.DoubleClick
        If lstNHC.Items.Count > 0 Then
            txtNHC.Text = sender.SelectedItem.ToString.Trim
        End If
    End Sub

    Private Sub rotarGradosImagen(ByVal angulo As Integer)
        Dim bm As Bitmap
        ' ''Dim documento As clsDocumentoE

        Dim myImageCodecInfo As ImageCodecInfo
        Dim myEncoder As Encoder
        Dim myEncoderParameter As EncoderParameter
        Dim myEncoderParameters As EncoderParameters

        Try
            If giraGrados = False Then Exit Sub

            If dgv.SelectedRows.Count = 1 Then
                ''//Load an image in from a file
                Dim image As Image = New Bitmap(oDocumentoActivo._rutaDocumento)
                Dim m_centro As PointF = New PointF(IMGeditPrincipal.ClientSize.Width \ 2, IMGeditPrincipal.ClientSize.Height \ 2)

                ' ''Dim encoderParams As New EncoderParameters()
                ' ''encoderParams = imagenOriginal.GetEncoderParameterList(Encoder.ColorDepth)

                ' ''Dim fi As New FileInfo(oDocumentoActivo._rutaDocumento)
                ' ''Dim atributes As New FileAttributes 'FileAttributes
                ' ''atributes. = FileAttributes.Compressed '.Attributes
                ' ''atributes.

                If angulo = 0 Then
                    bm = rotarGrados(imagenOriginal, m_centro, angulo)
                Else
                    bm = rotarGrados(image, m_centro, angulo)
                End If

                ' ''MsgBox(bm.PixelFormat.ToString)

                image.Dispose()

                'Compresion LZW
                myImageCodecInfo = GetEncoderInfo("image/tiff")
                myEncoder = Encoder.Compression
                myEncoderParameters = New EncoderParameters(2)

                myEncoderParameter = New EncoderParameter(myEncoder, Fix(EncoderValue.CompressionLZW))
                myEncoderParameters.Param(0) = myEncoderParameter
                '****************

                'Profundidad de bits
                myEncoder = Encoder.ColorDepth
                myEncoderParameter = New EncoderParameter(myEncoder, 1)
                myEncoderParameters.Param(1) = myEncoderParameter
                '*******************

                ' ''myImageCodecInfo = GetEncoderInfo("image/tiff")
                ' ''myEncoder = Encoder.Compression
                ' ''myEncoderParameters = New EncoderParameters(1)

                ' ''myEncoderParameter = New EncoderParameter(myEncoder, Fix(EncoderValue.CompressionLZW))
                ' ''myEncoderParameters.Param(0) = myEncoderParameter

                If angulo = 0 Then
                    bm.Save(oDocumentoActivo._rutaDocumento, myImageCodecInfo, myEncoderParameters)
                Else
                    bm.Save(oDocumentoActivo._rutaDocumento, myImageCodecInfo, myEncoderParameters)
                End If

                IMGeditPrincipal.Image = bm

                'borra miniaturas
                If File.Exists(oDocumentoActivo._rutaDocumento.Replace("\IML", "\MINIATURAS\IML").ToUpper.Replace("TIF", "PNG")) Then
                    File.Delete(oDocumentoActivo._rutaDocumento.Replace("\IML", "\MINIATURAS\IML").ToUpper.Replace("TIF", "PNG"))
                End If

            Else
                MessageBox.Show("Solo puede seleccionar una página para rotar.", "Rotar grados", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If


            ' ''myImageCodecInfo = GetEncoderInfo("image/tiff")
            ' ''myEncoder = Encoder.Compression
            ' ''myEncoderParameters = New EncoderParameters(1)

            ' ''bm = System.Drawing.Image.FromFile(documento._rutaDocumento)
            ' ''bm.RotateFlip(RotateFlipType.Rotate90FlipNone)
            ' ''Me.IMGeditPrincipal.Image = bm

            ' ''myEncoderParameter = New EncoderParameter(myEncoder, Fix(EncoderValue.CompressionLZW))
            ' ''myEncoderParameters.Param(0) = myEncoderParameter
            ' ''bm.Save(documento._rutaDocumento, myImageCodecInfo, myEncoderParameters)

            '' ''borra miniaturas
            ' ''If File.Exists(documento._rutaDocumento.Replace("\IML", "\MINIATURAS\IML").ToUpper.Replace("TIF", "PNG")) Then
            ' ''    File.Delete(documento._rutaDocumento.Replace("\IML", "\MINIATURAS\IML").ToUpper.Replace("TIF", "PNG"))
            ' ''End If

        Catch ex As Exception
            MessageBox.Show("Error al rotar " & angulo & " grados.", "Rotar grados", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub IMGeditPrincipal_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles IMGeditPrincipal.Paint
        ' ''Dim pts As PointF() = New PointF(2) {m_gp.PathPoints(0), m_gp.PathPoints(1), m_gp.PathPoints(3)}

        ' ''e.Graphics.DrawImage(m_imagen, pts)
    End Sub

    ''insertaEnPagina = Indica la página que se ha seleccionado en la lista a partir de la que se insertará la/s nueva/as páginas. Si es 0 significa que no es inserción, simplemente se renombra.
    Private Function insertaPagina(ByVal insertaEnPagina As Integer) As String
        Dim mensaje As String = ""
        Dim paginaReal As Integer = 0
        Dim paginaAnterior As Integer = 0
        Dim listaDoc As List(Of clsDocumentoE)
        Dim RutaDocumento As String = ""
        Dim RutaDestinoDocumento As String = ""
        Dim dicDocumento As New Dictionary(Of Integer, String)
        Dim correcto As Boolean = False
        Dim contador As Integer = 0

        Try
            ' ''docs = (From documento As DataRow In var_frmAnterior.dt_documentos Where CInt(documento.Item("pagina")) >= var_pagina Order By CInt(documento.Item("pagina")) Descending).ToList
            listaDoc = (From documento As clsDocumentoE In oListaDocumentos Where CInt(documento._pagina) >= insertaEnPagina Order By CInt(documento._pagina) Descending).ToList

            If listaDoc.Count > 0 Then
                ProgressBar1.Visible = True
                lblProgressBar.Visible = True
                lblProgressBar.Text = "Repaginando para insertar..."
                ProgressBar1.Maximum = listaDoc.Count
                Application.DoEvents()

                For Each documento As clsDocumentoE In listaDoc
                    contador += 1
                    ProgressBar1.Value = contador

                    RutaDocumento = documento._rutaDocumento '''.Replace(documento._nombreArchivo, "") & "IML" & Format(CInt(documento._pagina), "00000").ToString & ".tif"
                    RutaDestinoDocumento = documento._rutaDocumento.ToUpper.Replace(documento._nombreArchivo, "") & "IML" & Format(CInt(documento._pagina.ToString) + 1, "00000") & ".tif"

                    Application.DoEvents()

                    'En la insercion eliminamos el posible fichero que haya antes de la insercion
                    If IO.File.Exists(RutaDestinoDocumento) Then IO.File.Delete(RutaDestinoDocumento)

                    Try
                        Rename(RutaDocumento, RutaDestinoDocumento)
                    Catch ex As Exception
                        mensaje = mensaje & vbLf & "No se ha podido mover la página " & RutaDocumento & " para insertar nueva página en " & RutaDestinoDocumento & "."
                        Exit Function
                    End Try

                    ' ''If Not fg.clsCarpetas.MoverFichero(RutaDocumento, RutaDestinoDocumento) Then
                    ' ''    mensaje = mensaje & vbLf & "No se ha podido mover la página " & RutaDocumento & " para insertar nueva página en " & RutaDestinoDocumento & "."
                    ' ''    Exit Function
                    ' ''Else
                    ' ''    'Creo un diccionario para saber el nombre original del documento antes de cambiarlo para insertar
                    ' ''    dicDocumento.Add(documento._idDocumento, documento._rutaDocumento)

                    ' ''End If

                    'Borra miniaturas
                    If File.Exists(RutaDocumento.Replace("\IML", "\MINIATURAS\IML").ToUpper.Replace("TIF", "PNG")) Then
                        File.Delete(RutaDocumento.Replace("\IML", "\MINIATURAS\IML").ToUpper.Replace("TIF", "PNG"))
                    End If
                    '****************
                Next

                oDocumentoActivo = añadeDocumento("TMP00001.TIF", True)  'Añade el documento a la lista principal y al grid

                If RutaDocumento.Contains(My.Settings.DIGI_rutaLocalImagenes) Then
                    oDocumentoActivo._documentoEnLocal = True
                Else
                    oDocumentoActivo._documentoEnLocal = False
                End If

                FileCopy(rutaDirSustitucion & "\TMP00001.TIF", RutaDocumento)

                If IO.File.Exists(RutaDocumento) Then
                    correcto = actualizarPaginaNombrePaginaRango(cadenaConexionProyecto, oLote._Lote, insertaEnPagina, "", True)
                    If correcto = False Then
                        'Debiera volver a cambiar los nombre de los ficheros como estaban

                        mensaje = mensaje & vbLf & "No se ha podido mover la página " & RutaDocumento & " para insertar nueva página en " & RutaDestinoDocumento & "."
                        Exit Function
                    Else
                        Dim lsSql As String = "INSERT INTO DOCUMENTOS (idLote, Pagina, NomArchivoTIF,  documentoEnLocal) VALUES (" & lblLote.Text & ", " & oDocumentoActivo._pagina & ", '" & "IML" & Format(CInt(oDocumentoActivo._pagina), "00000") & ".TIF', " & IIf(oDocumentoActivo._documentoEnLocal, 1, 0) & ")"
                        mensaje = accesoDatosNew.ejecutarSQLConTransaccion(lsSql, cadenaConexionProyecto)
                    End If
                Else
                    mensaje = mensaje & vbLf & "No se ha podido copiar la página escaneada a su destino en " & RutaDestinoDocumento & "."
                    Exit Function
                End If
            End If


        Catch ex As Exception
            mensaje = "*** ERROR. " & Now & ". Error al insertar página " & oDocumentoActivo._pagina & " en el lote " & lblLote.Text & vbLf & ex.Message
            Throw ex
        Finally
            ProgressBar1.Visible = False
            lblProgressBar.Visible = False
            lblProgressBar.Text = ""
            Application.DoEvents()

            insertaPagina = mensaje
        End Try

    End Function

    ''' <summary>
    ''' Modificacion en un punto o X de las paginas de registros
    ''' OJO que tambien debemos de modificar la tabla de docs incidencias
    ''' </summary>
    ''' <param name="cadenaConexion"></param>
    ''' <param name="proyecto"></param>
    ''' <param name="lote"></param>
    ''' <param name="pagina"></param>
    ''' <param name="UltimaPagina"></param>
    ''' <param name="icrementar"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function actualizarPaginaNombrePaginaRango(ByVal cadenaConexion As String, ByVal lote As String, ByVal pagina As String, ByVal UltimaPagina As String, ByVal icrementar As Boolean) As Boolean

        Dim correcto As Boolean

        Dim consultaSQL As String

        'El incremento para no es el mismo para las carátulas que para los documentos
        'Para las carátulas 

        Dim SQL_rango As String
        If UltimaPagina = "" Then
            SQL_rango = ">= " & pagina
        Else
            SQL_rango = "between " & pagina & " and " & UltimaPagina
        End If

        Dim signo As String = "+"
        If Not icrementar Then signo = " -"

        consultaSQL = "UPDATE documentos SET pagina=pagina" & signo & "1 , NomArchivoTIF='IML'+RIGHT('00000'+CONVERT(VARCHAR,Pagina" & signo & "1),5)+'.TIF' " _
        & " WHERE idLote=" & lote & " " _
        & " and pagina " & SQL_rango

        correcto = accesoDatosNew.ejecutaSQLEjecucion(consultaSQL, cadenaConexion, , True)

        Return correcto

    End Function

    Public Shared Function actualizarPaginaNombrePagina(ByVal cadenaConexion As String, ByVal lote As Integer, ByVal pagina As Integer, ByVal idDocumento As Long) As Boolean

        Dim correcto As Boolean = False

        Dim consultaSQL As String

        Try
            consultaSQL = "UPDATE documentos SET pagina=" & pagina & ", NomArchivoTIF='" & "IML" & Format(Val(pagina), "00000") & ".TIF" & "'" _
            & " WHERE idLote=" & lote & " " _
            & " and idDocumento = " & idDocumento

            correcto = accesoDatosNew.ejecutaSQLEjecucion(consultaSQL, cadenaConexion, , False)

        Catch ex As Exception
            Throw ex

        Finally
            actualizarPaginaNombrePagina = correcto
        End Try


    End Function

    Public Shared Function actualizarUbicacionPagina(ByVal cadenaConexion As String, ByVal enLocal As Boolean, ByVal idDocumento As Long) As Boolean

        Dim correcto As Boolean = False

        Dim consultaSQL As String

        Try
            consultaSQL = "UPDATE documentos SET documentoEnLocal=" & IIf(enLocal = True, 1, 0) & _
                             " WHERE idDocumento = " & idDocumento

            correcto = accesoDatosNew.ejecutaSQLEjecucion(consultaSQL, cadenaConexion, , True)

        Catch ex As Exception
            Throw ex

        Finally
            actualizarUbicacionPagina = correcto
        End Try


    End Function

    Private Sub tsbAccion5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAccion5.Click
        'Insertar página digitalizada
        Dim mensaje As String = ""

        Try
            Me.Cursor = Cursors.WaitCursor

            If dgv.SelectedRows.Count = 1 Then
                'Cierra irfanview si está activo
                ''cerrarProcesoActivo(aplicacionEscaneo)

                mensaje = digitalizar(False, True)
            Else
                MessageBox.Show("Debe seleccionar una sola página donde insertar.", "Insertar página", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            Dim mensajeEX As String = ""
            'Excepción interna
            If ex.InnerException IsNot Nothing Then
                mensajeEX = " Inner exception: " & ex.InnerException.Message
            End If
            If mensaje.ToUpper.Contains("ACCESO DENEGADO") Or ex.Message.ToUpper.Contains("ACCESO DENEGADO") Or mensaje.ToUpper.Contains("DENIED") Or ex.Message.ToUpper.Contains("DENIED") Then
                escribirEnLog("*** ERROR USUARIO. " & Now & ". Lote " & lblLote.Text & ". Ocurrió un error al insertar la página. Error de comunicación con el escáner" & vbLf & "Mensaje capturado: " & mensaje & vbLf & ex.Message & vbLf & mensajeEX & vbLf & ex.StackTrace)
                MessageBox.Show("Ocurrió un error de comunicación con el escáner, por favor, apáguelo, vuelva a encenderlo y pruebe a realizar de nuevo la operación." & vbCrLf & ex.Message, "Error de comunicación con escáner", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                escribirEnLog("*** ERROR USUARIO. " & Now & ". Lote " & lblLote.Text & ". Ocurrió un error al insertar la página." & vbLf & "Mensaje capturado: " & mensaje & vbLf & ex.Message & vbLf & mensajeEX & vbLf & ex.StackTrace)
                MessageBox.Show("Ocurrió un error al insertar la página." & vbCrLf & ex.Message, "Error al insertar página", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            ' ''escribirEnLog("*** ERROR USUARIO. " & Now & ". Lote " & lblLote.Text & ". Ocurrió un error al insertar la página." & vbLf & "Mensaje capturado: " & mensaje & vbLf & ex.Message & vbLf & mensajeEX & vbLf & ex.StackTrace)
            ' ''MessageBox.Show("Ocurrió un error al insertar la página." & vbCrLf & ex.Message, "Error al insertar", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Function guardaEnBdDocumentos() As String
        Dim resultado As String = ""
        Dim lsSql As String = ""
        Dim contador As Integer = 0

        Try

            Dim listaDoc As List(Of clsDocumentoE) = (From documento As clsDocumentoE In oListaDocumentos Where documento._documentoEnBD = False Order By CInt(documento._pagina)).ToList

            If listaDoc.Count > 0 Then
                ProgressBar1.Visible = True
                lblProgressBar.Visible = True
                lblProgressBar.Text = "Guardando documentos..."
                ProgressBar1.Maximum = listaDoc.Count
                Application.DoEvents()

                For Each documento As clsDocumentoE In listaDoc
                    contador += 1
                    ProgressBar1.Value = contador

                    lsSql = lsSql & "; INSERT INTO DOCUMENTOS (idLote, Pagina, NomArchivoTIF, numHistoria, documentoEnLocal) VALUES (" & lblLote.Text & ", " & documento._pagina & ", '" & documento._nombreArchivo.ToUpper & "', " & IIf(documento._historia = 0, "NULL", documento._historia) & ", " & IIf(documento._documentoEnLocal, 1, 0) & ")"
                Next
                lsSql = lsSql.Substring(1).ToString.Trim
                lsSql = lsSql & ";UPDATE LOTES SET DAT='" & cboTipoLote.Text.ToString.Trim & "', TotalImg=" & lblPaginasLote.Text & " WHERE idLote=" & lblLote.Text
                resultado = accesoDatosNew.ejecutarSQLConTransaccion(lsSql, cadenaConexionProyecto)
            End If

        Catch ex As Exception
            Dim mensajeEX As String = ""
            'Excepción interna
            If ex.InnerException IsNot Nothing Then
                mensajeEX = " Inner exception: " & ex.InnerException.Message
            End If
            escribirEnLog("*** ERROR. " & Now & ". Ocurrió un error guardaEnBdDocumentos." & vbLf & ex.Message & vbLf & mensajeEX & vbLf & ex.StackTrace)

            Throw ex

        Finally
            ProgressBar1.Visible = False
            lblProgressBar.Visible = False
            lblProgressBar.Text = ""
            Application.DoEvents()

            guardaEnBdDocumentos = resultado

        End Try

    End Function

    Private Sub cmdGuardarDocumentos_eClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGuardarDocumentos.eClick
        Dim mensaje As String = ""

        Try
            Me.Cursor = Cursors.WaitCursor

            Try
                guardaEnBdDocumentos()

                ' ''refrescarLista(dgv.SelectedRows(0).Cells("pagina").Value)
                If dgv.CurrentRow.Index >= 0 Then
                    refrescarLista(dgv.Rows(dgv.CurrentRow.Index).Cells("Pagina").Value)
                Else
                    refrescarLista(1)
                End If

            Catch ex As Exception
                MessageBox.Show("Ocurrió un error al guardar los documentos." & vbCrLf & ex.Message, "Error al guardar documentos", MessageBoxButtons.OK, MessageBoxIcon.Error)
                escribirEnLog("*** ERROR USUARIO. " & Now & ". Lote " & lblLote.Text & ". Ocurrió un error al guardar los documentos en cmdGuardarDocumentos." & vbCrLf & ex.Message)
            End Try

            ''mensaje = repaginar()

            ''If mensaje.ToString.Trim = "" Then

            recargaMiniaturas = True

            If dgv.SelectedRows.Count > 0 Then
                refrescarLista(dgv.SelectedRows(0).Cells("pagina").Value)
            Else
                refrescarLista(1)
            End If

            MessageBox.Show("Documentos guardados.", "Guardar documentos", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ''Else
            ''    MessageBox.Show("Ocurrió un error al repaginar antes de guardar documentos. Contacte con el servicio de informática." & vbCrLf & mensaje, "Error al guardar documentos", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ''    escribirEnLog("*** ERROR USUARIO. " & Now & ". Lote " & lblLote.Text & ". Ocurrió un error al repaginar antes de guardar documentos." & vbCrLf & mensaje)
            ''End If


        Catch ex As Exception
            Dim mensajeEX As String = ""
            'Excepción interna
            If ex.InnerException IsNot Nothing Then
                mensajeEX = " Inner exception: " & ex.InnerException.Message
            End If
            escribirEnLog("*** ERROR USUARIO. " & Now & ". Lote " & lblLote.Text & ". Ocurrió un error al guardar los documentos." & vbLf & ex.Message & vbLf & mensajeEX & vbLf & ex.StackTrace)

            MessageBox.Show("Ocurrió un error al guardar los documentos." & vbCrLf & ex.Message, "Error al guardar documentos", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub marcarDocMalEstado(ByVal documento As clsDocumentoE)
        Dim resultado As String = ""
        Dim lsSql As String = ""

        Try
            If documento._Incidencia Then
                lsSql = "UPDATE documentos SET incidencia='0' WHERE IdDocumento=" & documento._idDocumento & "" _
                                            & ";DELETE from documentosincidencias WHERE IDdocumento =" & documento._idDocumento & ""
            Else
                lsSql = "UPDATE documentos SET incidencia='1' WHERE IdDocumento=" & documento._idDocumento & "" _
                                            & ";DELETE from documentosincidencias WHERE IDdocumento =" & documento._idDocumento & "" _
                                            & ";INSERT into documentosincidencias (IDDocumento,IDIncidencia,Corregida,Tipo) " _
                                            & " VALUES (" & documento._idDocumento & ",2,0,'DIGI')"
            End If

            resultado = accesoDatosNew.ejecutarSQLConTransaccion(lsSql, cadenaConexionProyecto)

        Catch ex As Exception
            Throw ex

        Finally

        End Try

    End Sub

    Private Sub tsbAccion4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAccion4.Click
        'Marcar mal estado
        Dim grid As DataGridViewSelectedRowCollection = dgv.SelectedRows
        Dim documento As clsDocumentoE

        Try
            ' ''escribirEnLog(Now & "  Inicio marcar doc en mal estado.")

            Me.Cursor = Cursors.WaitCursor
            If dgv.SelectedRows.Count > 0 Then
                ' ''escribirEnLog(Now & ". Antes de guardar.")
                guardaEnBdDocumentos()
                ' ''escribirEnLog("Después de guardar.")

                refrescarLista(dgv.SelectedRows(0).Cells("pagina").Value)
                ' ''escribirEnLog("Después de refrescar.")

                ' ''For Each fila As DataGridViewRow In dgv.SelectedRows
                For Each fila As DataGridViewRow In grid '' dgv.SelectedRows
                    ' ''escribirEnLog(Now & ". Empieza con documento " & fila.Cells(0).Value)
                    Application.DoEvents()
                    documento = obtieneDocumento_Por_Pagina(fila.Cells(1).Value)
                    If Not IsNothing(documento) Then
                        ' ''escribirEnLog("Antes de marcar documento.")
                        marcarDocMalEstado(documento)
                        ' ''escribirEnLog("Después de marcar documento.")
                    Else
                        MessageBox.Show("Error al identificar página " & documento._pagina & " del lote " & lblLote.Text & " para marcar como original en mal estado, contacte con el servicio de informática.", "Rotar páginas", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        escribirEnLog("*** ERROR USUARIO. " & Now & ". Lote " & lblLote.Text & ". Error al identificar página " & documento._pagina & " del lote " & lblLote.Text & " para marcar como original en mal estado, contacte con el servicio de informática.")
                    End If
                Next
                ' ''escribirEnLog("Antes de refrescar.")
                refrescarLista(dgv.SelectedRows(0).Cells("pagina").Value)
                ' ''escribirEnLog("Después de refrescar.")
            Else
                MessageBox.Show("No hay páginas seleccionadas para marcar.", "Marcar páginas", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            Dim mensajeEX As String = ""
            'Excepción interna
            If ex.InnerException IsNot Nothing Then
                mensajeEX = " Inner exception: " & ex.InnerException.Message
            End If
            escribirEnLog("*** ERROR USUARIO. " & Now & ". Lote " & lblLote.Text & ". Ocurrió un error al marcar las páginas como original en mal estado." & vbLf & ex.Message & vbLf & mensajeEX & vbLf & ex.StackTrace)

            MessageBox.Show("Ocurrió un error al marcar las páginas como original en mal estado." & vbCrLf & ex.Message, "Error al marcar", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            Me.Cursor = Cursors.Default
            ' ''escribirEnLog(Now & "  Fin marcar doc en mal estado.")
            ' ''escribirEnLog("***************")
        End Try

    End Sub

    Private Sub dgv_RowPrePaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dgv.RowPrePaint
        'TODO: Repintado de GRID

        Dim theRow As DataGridViewRow

        Try
            If e.RowIndex < sender.rows.count Then
                theRow = Me.dgv.Rows(e.RowIndex)

                If theRow IsNot Nothing Then
                    Dim documento As clsDocumentoE = obtieneDocumento(theRow.Cells("idDocumento").Value)
                    If Not IsNothing(documento) Then
                        'Marca la fila en rojo si es documento en mal estado
                        If documento._Incidencia = 1 Then
                            theRow.DefaultCellStyle.ForeColor = Color.Red
                        End If
                        'Marca la fila en verde si es principio de historia
                        If documento._BarCodeDet = 1 Then
                            theRow.DefaultCellStyle.BackColor = Color.GreenYellow
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub tsbAccion6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAccion6.Click
        'Localizar imagenes en blanco
        Try
            Me.Cursor = Cursors.WaitCursor

            ' ''MessageBox.Show("Funcionalidad no disponible.", "Localizar página blanca", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ' ''Exit Sub

            If tstPorcentajeNegro.Text.ToString.Trim = "" Or tstPorcentajeNegro.Text.ToString.Trim = "0" Then
                MessageBox.Show("Debe informar el porcentaje de píxeles negros para realizar la operación.", "Localizar página blanca", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                recargaMiniaturas = False

                guardaEnBdDocumentos()

                If IsNothing(dgv.CurrentRow) Then
                    refrescarLista(1)
                Else
                    refrescarLista(dgv.Rows(dgv.CurrentRow.Index).Cells("Pagina").Value)
                End If

                recargaMiniaturas = True

                oListaDocumentos = localizarImagenesEnBlanco(True, 0)

                ' ''borrarMiniaturas()

                recargaMiniaturas = True
                cargarListaDocumentosBlancos()
                recargaMiniaturas = False
            End If


        Catch ex As Exception
            Dim mensajeEX As String = ""
            'Excepción interna
            If ex.InnerException IsNot Nothing Then
                mensajeEX = " Inner exception: " & ex.InnerException.Message
            End If
            escribirEnLog("*** ERROR USUARIO. " & Now & ". Lote " & lblLote.Text & ". Ocurrió un error al localizar imágenes en blanco." & vbLf & ex.Message & vbLf & mensajeEX & vbLf & ex.StackTrace)

            MessageBox.Show("Ocurrió un error al localizar imágenes en blanco." & vbCrLf & ex.Message, "Error al localizar blancos", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Function repaginar() As String
        Dim mensaje As String = ""
        Dim paginaReal As Integer = 0
        Dim paginaAnterior As Integer = 0
        Dim listaDoc As List(Of clsDocumentoE)
        Dim contador As Integer = 0
        Dim errorBorraMiniaturas As Boolean = False

        Try
            ProgressBar1.Visible = True
            lblProgressBar.Visible = True
            lblProgressBar.Text = "Repaginando..."
            Application.DoEvents()

            'Localiza a partir de la página que renombrará
            For Each doc As clsDocumentoE In oListaDocumentos
                paginaReal += 1
                If paginaReal <> doc._pagina Then
                    paginaAnterior = doc._pagina
                    Exit For
                End If
            Next

            ' si paginaAnterior = 0 significa que no es necesario repaginar.
            If paginaAnterior > 0 Then
                listaDoc = (From documento As clsDocumentoE In oListaDocumentos Where CInt(documento._pagina) >= paginaAnterior Order By CInt(documento._pagina) Ascending).ToList
                ProgressBar1.Maximum = listaDoc.Count

                If listaDoc.Count > 0 Then
                    'Renombra temporalmente ficheros implicados
                    Try
                        For Each documento As clsDocumentoE In listaDoc
                            contador += 1
                            ProgressBar1.Value = contador
                            Application.DoEvents()

                            'Renombra ficheros
                            If File.Exists(documento._rutaDocumento) Then
                                Rename(documento._rutaDocumento, documento._rutaDocumento.ToUpper.Replace(".TIF", ".ISC"))
                            End If

                            Try
                                'Renombra miniaturas
                                If File.Exists(documento._rutaDocumento.ToUpper.Replace("\IML", "\MINIATURAS\IML").ToUpper.Replace(".TIF", ".PNG")) Then
                                    Rename(documento._rutaDocumento.ToUpper.Replace("\IML", "\MINIATURAS\IML").ToUpper.Replace(".TIF", ".PNG"), documento._rutaDocumento.ToUpper.Replace("\IML", "\MINIATURAS\IML").ToUpper.Replace(".TIF", ".PNG").ToUpper.Replace(".PNG", ".ISC")) ' documento._rutaDocumento.ToUpper.Replace(".TIF", ".ISC"))
                                End If
                            Catch ex As Exception

                            End Try
                        Next

                        contador = 0

                    Catch ex As Exception
                        'Vuelve a renombrar ficheros a su nombre original, tanto en la carpeta local como en servidor
                        For Each fichero As String In IO.Directory.GetFiles(oLote._rutaLote, "*.ISC", SearchOption.TopDirectoryOnly)
                            Rename(fichero, fichero.ToUpper.Replace(".ISC", ".TIF"))
                        Next
                        For Each fichero As String In IO.Directory.GetFiles(oLote._rutaLoteLocal, "*.ISC", SearchOption.TopDirectoryOnly)
                            Rename(fichero, fichero.ToUpper.Replace(".ISC", ".TIF"))
                        Next
                        Dim mensajeEX As String = ""
                        'Excepción interna
                        If ex.InnerException IsNot Nothing Then
                            mensajeEX = " Inner exception: " & ex.InnerException.Message
                        End If
                        mensaje = "*** ERROR. " & Now & "Ocurrió un error al renombar temporalmente los ficheros para repaginar en el fichero " & contador & ", se ha restablecido su nombre pero se ha cancelado la operación." & vbLf & ex.Message & vbLf & mensajeEX & vbLf & ex.StackTrace

                        ' ''mensaje = "Ocurrió un error al renombar temporalmente los ficheros para repaginar en el fichero " & contador & ", se ha restablecido su nombre pero se ha cancelado la operación."
                        Exit Function
                    End Try
                    '*****************************

                    'Cambia nombre en base de datos y renombra ficheros con nombre definitivo
                    For Each documento As clsDocumentoE In listaDoc
                        contador += 1
                        ProgressBar1.Value = contador
                        ' ''Application.DoEvents()

                        'Renombra ficheros a su estado original
                        Try
                            Rename(documento._rutaDocumento.ToUpper.Replace(".TIF", ".ISC"), documento._rutaDocumento.ToUpper.Replace(documento._nombreArchivo, "IML" & Format(Val(paginaReal), "00000") & ".TIF"))

                        Catch ex As Exception
                            mensaje = "Ocurrió un error al renombar los ficheros para repaginar, se ha restablecido su nombre pero se ha cancelado la operación." & vbLf & ex.Message
                            Exit Function
                        End Try

                        'Renombra miniaturas a su estado original
                        Try
                            If File.Exists(documento._rutaDocumento.ToUpper.Replace("\IML", "\MINIATURAS\IML").ToUpper.Replace("TIF", "ISC").ToUpper.Replace(".PNG", ".ISC")) Then
                                Rename(documento._rutaDocumento.ToUpper.Replace("\IML", "\MINIATURAS\IML").ToUpper.Replace("TIF", "ISC").ToUpper.Replace(".PNG", ".ISC"), documento._rutaDocumento.ToUpper.Replace("\IML", "\MINIATURAS\IML").ToUpper.Replace(documento._nombreArchivo, "IML" & Format(Val(paginaReal), "00000") & ".PNG"))
                            End If

                        Catch ex As Exception
                            errorBorraMiniaturas = True
                        End Try

                        Try
                            If actualizarPaginaNombrePagina(cadenaConexionProyecto, lblLote.Text.ToString.Trim, paginaReal, documento._idDocumento) = False Then
                                Throw New Exception()
                            End If

                        Catch ex As Exception
                            'Se restablece el nombre del fichero porque fue renombrado correctamente
                            Rename(documento._rutaDocumento.ToUpper.Replace(documento._nombreArchivo, "IML" & Format(Val(paginaReal + 1), "00000") & ".TIF"), documento._rutaDocumento)
                            mensaje = "Ocurrió un error al renombar, en base de datos, los ficheros para repaginar, se ha restablecido su nombre pero se ha cancelado la operación."
                            Exit Function
                        End Try

                        paginaReal += 1

                    Next

                    contador = 0
                    ' ''ProgressBar1.Maximum = Directory.GetFiles(oLote._rutaLote & "\MINIATURAS", "*.PNG", SearchOption.TopDirectoryOnly).Count
                    lblProgressBar.Text = "Borrando miniaturas..."

                    'Si ha dado error al renombrar miniaturas, las borra.
                    If errorBorraMiniaturas Then borrarMiniaturas(paginaAnterior)

                    '' ''Borra todas las miniaturas del servidor
                    ' ''For Each dir As String In Directory.GetFiles(oLote._rutaLote & "\MINIATURAS", "*.PNG", SearchOption.TopDirectoryOnly)
                    ' ''    contador += 1
                    ' ''    ProgressBar1.Value = contador
                    ' ''    Application.DoEvents()

                    ' ''    File.Delete(dir)
                    ' ''Next

                    ' ''contador = 0
                    ' ''ProgressBar1.Maximum = Directory.GetFiles(oLote._rutaLoteLocal & "\MINIATURAS", "*.PNG", SearchOption.TopDirectoryOnly).Count
                    ' ''lblProgressBar.Text = "Borrando miniaturas de la ubicación local..."

                    '' ''Borra todas las miniaturas de local
                    ' ''For Each Dir As String In Directory.GetFiles(oLote._rutaLoteLocal & "\MINIATURAS", "*.PNG", SearchOption.TopDirectoryOnly)
                    ' ''    contador += 1
                    ' ''    ProgressBar1.Value = contador
                    ' ''    Application.DoEvents()

                    ' ''    File.Delete(Dir)
                    ' ''Next
                End If
            End If

        Catch ex As Exception
            mensaje = "*** ERROR. " & Now & "  ocurrió un error al repaginar. " & vbLf & ex.Message
            Dim mensajeEX As String = ""
            'Excepción interna
            If ex.InnerException IsNot Nothing Then
                mensajeEX = " Inner exception: " & ex.InnerException.Message
            End If
            escribirEnLog("*** ERROR. " & Now & ". Ocurrió un error en repaginar." & vbLf & ex.Message & vbLf & mensajeEX & vbLf & ex.StackTrace)

            Throw ex
        Finally
            ProgressBar1.Visible = False
            lblProgressBar.Visible = False
            lblProgressBar.Text = ""
            Application.DoEvents()

            repaginar = mensaje
        End Try

    End Function

    Private Sub cmdSincronizar_eClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSincronizar.eClick
        Dim mensaje As String = ""

        Try
            Me.Cursor = Cursors.WaitCursor

            Try
                guardaEnBdDocumentos()

                refrescarLista(dgv.SelectedRows(0).Cells("pagina").Value)

            Catch ex As Exception
                MessageBox.Show("Ocurrió un error al guardar los documentos antes de sincronizar los documentos con el servidor." & vbCrLf & ex.Message, "Sincronizar documentos", MessageBoxButtons.OK, MessageBoxIcon.Error)
                escribirEnLog("*** ERROR USUARIO. " & Now & ". Lote " & lblLote.Text & ". Ocurrió un error al sincronizar los documentos con el servidor." & vbCrLf & ex.Message)
            End Try

            mensaje = repaginar()

            If mensaje.ToString.Trim = "" Then

                refrescarLista(dgv.SelectedRows(0).Cells("pagina").Value)

                Try
                    'Sincronizar
                    sincronizar()

                    refrescarLista(1)

                    MessageBox.Show("Documentos sincronizados.", "Sincronizar documentos", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Catch ex As Exception
                    MessageBox.Show("Ocurrió un error al sincronizar los documentos con el servidor." & vbCrLf & ex.Message, "Sincronizar documentos", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    escribirEnLog("*** ERROR USUARIO. " & Now & ". Lote " & lblLote.Text & ". Ocurrió un error al sincronizar los documentos con el servidor." & vbCrLf & ex.Message)
                End Try
            Else
                MessageBox.Show("Ocurrió un error al repaginar antes de sincronizar los documentos con el servidor. Contacte con el servicio de informática." & vbCrLf & mensaje, "Sincronizar documentos", MessageBoxButtons.OK, MessageBoxIcon.Error)
                escribirEnLog("*** ERROR USUARIO. " & Now & ". Lote " & lblLote.Text & ". Ocurrió un error al repaginar antes de sincronizar los documentos con el servidors." & vbCrLf & mensaje)
            End If


        Catch ex As Exception
            Dim mensajeEX As String = ""
            'Excepción interna
            If ex.InnerException IsNot Nothing Then
                mensajeEX = " Inner exception: " & ex.InnerException.Message
            End If
            escribirEnLog("*** ERROR USUARIO. " & Now & ". Lote " & lblLote.Text & ". Ocurrió un error al sincronizar los documentos con el servidor." & vbLf & ex.Message & vbLf & mensajeEX & vbLf & ex.StackTrace)

            MessageBox.Show("Ocurrió un error al sincronizar los documentos con el servidor." & vbCrLf & ex.Message, "Sincronizar documentos", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Function sincronizar() As String
        Dim mensaje As String = ""
        Dim listaDoc As List(Of clsDocumentoE)
        Dim RutaDestinoDocumento As String = ""
        Dim contador As Integer = 0

        Try
            listaDoc = (From documento As clsDocumentoE In oListaDocumentos Where CInt(documento._documentoEnLocal) = True Order By CInt(documento._pagina) Ascending).ToList

            If listaDoc.Count > 0 Then

                ProgressBar1.Visible = True
                lblProgressBar.Visible = True
                lblProgressBar.Text = "Llevando ficheros al servidor..."
                ProgressBar1.Maximum = listaDoc.Count
                Application.DoEvents()

                Try
                    For Each documento As clsDocumentoE In listaDoc
                        contador += 1
                        ProgressBar1.Value = contador

                        RutaDestinoDocumento = rutaImagenes & "\" & Format(Val(oLote._codigoProyecto), "0000") & "\DIGI\" & Format(Val(oLote._codigoProyecto), "0000") & Format(Val(oLote._Lote), "00000") & "\Imagen\" & oLote._Lote & "\" & documento._nombreArchivo.ToUpper

                        If Not fg.clsCarpetas.MoverFichero(documento._rutaDocumento, RutaDestinoDocumento) Then
                            mensaje = "*** ERROR. " & Now & "No se ha podido sincronizar la pagina " & documento._rutaDocumento & " en su nuevo destino del servidor " & RutaDestinoDocumento & "."
                            Throw New Exception(mensaje)
                        Else
                            actualizarUbicacionPagina(cadenaConexionProyecto, False, documento._idDocumento)
                        End If
                    Next

                Catch ex As Exception
                    Throw ex
                Finally
                    sincronizar = mensaje
                End Try
            End If

        Catch ex As Exception
            escribirEnLog("*** ERROR. " & Now & ". Ocurrió un error al sincronizar los documentos con el servidor." & vbCrLf & ex.Message)
            Throw ex

        Finally
            ProgressBar1.Visible = False
            lblProgressBar.Visible = False
            lblProgressBar.Text = ""
            Application.DoEvents()

            sincronizar = mensaje

        End Try
    End Function

    Private Function compruebaIntegridadParaCerrar() As String
        Dim mensaje As String = ""
        Dim numFicherosEnDirServidor As Integer = Directory.GetFiles(oLote._rutaLote.ToUpper, "*.TIF", SearchOption.TopDirectoryOnly).Count
        Dim numFicherosEnBdServidor As Integer = oListaDocumentos.Count
        Dim ultimaPagina As Integer = 0
        Dim listaDoc As List(Of clsDocumentoE) = (From documento As clsDocumentoE In oListaDocumentos Order By CInt(documento._pagina) Descending).ToList

        Try
            'Compruebas si el número de páginas en directorio y base de datos es el mismo,
            If numFicherosEnBdServidor <> numFicherosEnDirServidor Then
                mensaje = " - El número de ficheros en el servidor no coincide con los guardados en la base de datos."
            Else
                If listaDoc.Count > 0 Then
                    'Comprueba si el número de la última páginas es también el mismo.
                    If numFicherosEnBdServidor <> listaDoc(0)._pagina Then
                        mensaje = " - El número de ficheros no coincide con el número de la última página."
                    End If
                Else
                    mensaje = " - No se han localizado documentos en el lote."
                End If
            End If

        Catch ex As Exception
            ' ''mensaje = "*** ERROR. " & Now & "  "
            Throw ex
        Finally
            compruebaIntegridadParaCerrar = mensaje
        End Try

    End Function

    Private Sub InsertarPáginaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InsertarPáginaToolStripMenuItem.Click
        tsbAccion5_Click(Nothing, Nothing)
    End Sub

    Private Shared Function GetEncoderInfo(ByVal mimeType As String) As ImageCodecInfo
        Dim j As Integer
        Dim encoders() As ImageCodecInfo
        encoders = ImageCodecInfo.GetImageEncoders()

        j = 0
        While j < encoders.Length
            If encoders(j).MimeType = mimeType Then
                Return encoders(j)
            End If
            j += 1
        End While
        Return Nothing

    End Function 'GetEncoderInfo

    Private Function localizarImagenesEnBlanco(ByVal todas As Boolean, ByRef porcentaje As Double) As List(Of clsDocumentoE)
        Dim lista As New List(Of clsDocumentoE)
        Dim listaTodas As New List(Of clsDocumentoE)
        Dim mensaje As String = ""
        Dim img As Bitmap
        Dim X, y As Integer
        Dim contadorTotal As Long = 0
        Dim contadorBlanco As Long = 0
        Dim contadorNegro As Long = 0
        ''Dim porcentaje As Integer = 0
        Dim ColorPixel As Color
        Dim contador As Integer = 0

        Try
            If todas Then
                listaTodas = oListaDocumentos
            Else
                listaTodas = (From _documento As clsDocumentoE In oListaDocumentos Where CInt(_documento._pagina) = oDocumentoActivo._pagina).ToList
            End If

            If listaTodas.Count > 0 Then
                ProgressBar1.Visible = True
                lblProgressBar.Visible = True
                lblProgressBar.Text = "Calculando porcentaje de negro ..."
                ProgressBar1.Maximum = listaTodas.Count
                Application.DoEvents()

                compruebCreaDirectoriosNecesarios()

                For Each documento As clsDocumentoE In listaTodas

                    contador += 1
                    ProgressBar1.Value = contador
                    Application.DoEvents()

                    contadorBlanco = 0
                    contadorNegro = 0
                    contadorTotal = 0

                    ' ''img = New Bitmap(documento._rutaDocumento)
                    Try
                        img = New Bitmap(documento._rutaDocumento.Replace("\IML", "\MINIATURAS\IML").ToUpper.Replace("TIF", "PNG"))
                    Catch ex As Exception
                        'Si da error es que no existe la miniatura, por tanto, la crea.
                        img = System.Drawing.Image.FromFile(documento._rutaDocumento)
                        img = generaMiniatura(documento._rutaDocumento, 200, 200)
                        img.Save(documento._rutaDocumento.Replace("\IML", "\MINIATURAS\IML").ToUpper.Replace("TIF", "PNG"), System.Drawing.Imaging.ImageFormat.Png)
                    End Try

                    contadorTotal = (img.Width - 1) * img.Height - 1
                    For X = 1 To img.Width - 1
                        For y = 1 To img.Height - 1
                            ColorPixel = img.GetPixel(X, y)
                            If ColorPixel.A = 255 And ColorPixel.R = 255 And ColorPixel.G = 255 And ColorPixel.B = 255 Then
                                contadorBlanco += 1
                                ' ''If todas Then
                                ' ''    porcentaje = (contadorBlanco * 100) / contadorTotal
                                ' ''    If CInt(porcentaje) > 100 - CInt(tstPorcentajeNegro.Text) Then
                                ' ''        Exit For
                                ' ''    End If
                                ' ''End If
                            Else
                                contadorNegro += 1
                                ' ''If todas Then
                                ' ''    porcentaje = (contadorNegro * 100) / contadorTotal
                                ' ''    If CDbl(porcentaje) > CDbl(tstPorcentajeNegro.Text) Then
                                ' ''        Exit For
                                ' ''    End If
                                ' ''End If
                            End If
                        Next y
                    Next X

                    ' ''porcentaje = 100 - ((contadorBlanco * 100) / contadorTotal)
                    porcentaje = (contadorNegro * 100) / contadorTotal

                    If CDbl(porcentaje) <= CDbl(tstPorcentajeNegro.Text) Then
                        lista.Add(documento)
                    End If

                    img.Dispose()

                Next
            End If

        Catch ex As Exception
            mensaje = "*** ERROR. " & Now & "  "
            Throw ex
        Finally
            ProgressBar1.Visible = False
            lblProgressBar.Visible = False
            lblProgressBar.Text = ""
            Application.DoEvents()

            localizarImagenesEnBlanco = lista

        End Try

    End Function

    Private Sub cmdPorcentajeNegro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPorcentajeNegro.Click
        Dim porcentaje As Integer = 0

        Me.Cursor = Cursors.WaitCursor

        Try
            If dgv.SelectedRows.Count = 1 Then
                localizarImagenesEnBlanco(False, porcentaje)

                tstPorcentajeNegro.Text = porcentaje + 1
            Else
                MessageBox.Show("Solo puede seleccionar una página para calcular el porcentaje de negro que contiene.", "Calcular porcentaje", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            Dim mensajeEX As String = ""
            'Excepción interna
            If ex.InnerException IsNot Nothing Then
                mensajeEX = " Inner exception: " & ex.InnerException.Message
            End If
            escribirEnLog("*** ERROR USUARIO. " & Now & ". Lote " & lblLote.Text & ". Ocurrió un error al calcular el porcentaje de negros de la imágen seleccionada." & vbLf & ex.Message & vbLf & mensajeEX & vbLf & ex.StackTrace)

            MessageBox.Show("Ocurrió un error al calcular el porcentaje de negros de la imágen seleccionada." & vbCrLf & ex.Message, "Error al calcular porcentaje", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cmdRecargarLista_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRecargarLista.Click
        Dim pagina As Integer = 1

        Try
            Me.Cursor = Cursors.WaitCursor

            If dgv.SelectedRows.Count > 0 Then
                pagina = dgv.SelectedRows(0).Cells("Pagina").Value
            End If

            refrescarLista(pagina)

            If tsbImagen1.Checked Then tsbImagen1_Click(tsbImagen1, Nothing)
            If tsbImagen2.Checked Then tsbImagen2_Click(tsbImagen2, Nothing)
            If tsbImagenMini.Checked Then tsbImagenMini_Click(tsbImagenMini, Nothing)

        Catch ex As Exception
            Dim mensajeEX As String = ""
            'Excepción interna
            If ex.InnerException IsNot Nothing Then
                mensajeEX = " Inner exception: " & ex.InnerException.Message
            End If
            escribirEnLog("*** ERROR. " & Now & ". Ocurrió un error al recargar lista." & vbLf & ex.Message & vbLf & mensajeEX & vbLf & ex.StackTrace)

        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    ' ''Marca el campo BarcodeDet para el primer documento de la historia
    Private Function marcaInicioHistorias() As String
        Dim lsSqlCargaDocumentos As String = "SELECT * FROM DOCUMENTOS d LEFT JOIN TIPOSDOCUMENTOS td ON td.idTipoDocumento = d.TipoDocumento LEFT JOIN SERVICIOS s on s.idServicio = d.CodServicioPAED WHERE idLote=" & lblLote.Text.ToString.Trim & " ORDER BY PAGINA"
        Dim mensaje As String = ""
        Dim lsSql As String = ""
        ' ''Dim listaDoc As List(Of clsDocumentoE) = (From documento As clsDocumentoE In oListaDocumentos Where documento._historia > 0 Order By CInt(documento._pagina) Ascending).ToList
        Dim nhcAnterior As String = ""

        Try
            oListaDocumentos.Clear()

            oListaDocumentos = accesoDatosNuevos.clsAccesoDatosNUEVO.cargaDocumentos(cadenaConexionProyecto, lsSqlCargaDocumentos, codigoProyecto, rutaImagenes)

            oLote._ListaDocumentos = oListaDocumentos

            If oListaDocumentos.Count > 0 Then
                lsSql = lsSql & "UPDATE DOCUMENTOS SET BarcodeDet=NULL WHERE idLote=" & lblLote.Text
            End If

            For Each doc As clsDocumentoE In oListaDocumentos
                If nhcAnterior.ToString.Trim <> doc._historia.ToString.Trim Then
                    lsSql = lsSql & ";UPDATE DOCUMENTOS SET BarcodeDet=1 WHERE idDocumento=" & doc._idDocumento
                End If
                nhcAnterior = doc._historia.ToString.Trim
            Next

            If lsSql.ToString.Trim <> "" Then
                ' ''lsSql = lsSql.Substring(1)
                accesoDatosNew.ejecutarSQLConTransaccion(lsSql, cadenaConexionProyecto)
            End If

        Catch ex As Exception
            Dim mensajeEX As String = ""
            'Excepción interna
            If ex.InnerException IsNot Nothing Then
                mensajeEX = " Inner exception: " & ex.InnerException.Message
            End If
            mensaje = "*** ERROR. " & Now & " al marcar el primer documento de la historia (BarcodeDet)."
            escribirEnLog(mensaje & vbLf & ex.Message & vbLf & mensajeEX & vbLf & ex.StackTrace)
            Throw ex
        Finally
            marcaInicioHistorias = mensaje
        End Try

    End Function

    Public Shared Function rotarGrados(ByVal image As Image, ByVal offset As PointF, ByVal angle As Single) As Bitmap
        Dim rotatedBmp As Bitmap = New Bitmap(image.Width, image.Height)

        Try
            rotatedBmp.SetResolution(image.HorizontalResolution, image.VerticalResolution)
            Dim g As Graphics = Graphics.FromImage(rotatedBmp)
            g.TranslateTransform(offset.X, offset.Y)
            g.RotateTransform(angle)
            g.TranslateTransform(-offset.X, -offset.Y)
            g.DrawImage(image, New PointF(0, 0))

        Catch ex As Exception
            Throw ex

        Finally
            rotarGrados = rotatedBmp

        End Try
    End Function

    Private Sub nudGrados_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudGrados.ValueChanged

        Dim coeficiente As Integer = 1

        Try
            If pnlPresentacion3.Visible Then
                MessageBox.Show("Funcionalidad no disponible cuando se visualizan las miniaturas.", "Rotar grados", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If IsNumeric(nudGrados.Value) Then
                'Esto es para el caso que haya girado varios grados a la derecha y vaya otra vez girándolos en sentido contrario
                If nudGrados.Text > nudGrados.Value And nudGrados.Value > 0 Then
                    coeficiente = -1
                End If
                'Lo mismo pero a la izquierda.
                If nudGrados.Text < nudGrados.Value And nudGrados.Value < 0 Then
                    coeficiente = -1
                End If

                ' ''rotarGradosImagen(nudGrados.Value * coeficiente)

                Dim parametros = oDocumentoActivo._rutaDocumento & " -rotate " & nudGrados.Value * coeficiente & " " & oDocumentoActivo._rutaDocumento

                EjecutarComandoSHELL("" & My.Application.Info.DirectoryPath & "\convert.exe" & " ", parametros)

                posicionarRegistro(dgv.CurrentRow.Index)

            Else
                MessageBox.Show("El valor introducido debe ser numérico.", "Rotar grados", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            Dim mensajeEX As String = ""
            'Excepción interna
            If ex.InnerException IsNot Nothing Then
                mensajeEX = " Inner exception: " & ex.InnerException.Message
            End If
            escribirEnLog("*** ERROR USUARIO. " & Now & ". Lote " & lblLote.Text & ". Ocurrió un error al rotar " & nudGrados.Value & " grados." & vbLf & ex.Message & vbLf & mensajeEX & vbLf & ex.StackTrace)

            MessageBox.Show("Error al rotar " & nudGrados.Value & " grados." & vbLf & ex.Message, "Rotar grados", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub borrarMiniaturas(ByVal borrarDesdePagina As Integer)
        Dim fichero As String = ""

        If borrarDesdePagina > 1 Then borrarDesdePagina -= 1

        'Borra miniaturas del servidor
        If Directory.Exists(oLote._rutaLote.ToUpper & "\MINIATURAS") Then
            For Each directorio As String In Directory.GetFiles(oLote._rutaLote.ToUpper & "\MINIATURAS", "*.PNG", SearchOption.TopDirectoryOnly)
                fichero = obtieneFicheroDeLaRuta(directorio)
                If Convert.ToInt32(fichero.ToUpper.Replace("IML", "").Replace(".PNG", "")) >= borrarDesdePagina Then
                    Try
                        File.Delete(directorio)
                    Catch ex As Exception
                    End Try
                End If
            Next
        End If

        'Borra miniaturas de local
        If Directory.Exists(oLote._rutaLoteLocal.ToUpper & "\MINIATURAS") Then
            For Each directorio As String In Directory.GetFiles(oLote._rutaLoteLocal.ToUpper & "\MINIATURAS", "*.PNG", SearchOption.TopDirectoryOnly)
                fichero = obtieneFicheroDeLaRuta(directorio)
                If Convert.ToInt32(fichero.ToUpper.Replace("IML", "").Replace(".PNG", "")) >= borrarDesdePagina Then
                    Try
                        File.Delete(directorio)
                    Catch ex As Exception
                    End Try
                End If
            Next
        End If
    End Sub

    Private Sub borrarMiniaturas_OLD()

        'Borra miniaturas del servidor
        If Directory.Exists(oLote._rutaLote & "\MINIATURAS") Then
            Try
                Directory.Delete(oLote._rutaLote & "\MINIATURAS", True)
            Catch ex As Exception
                Directory.Delete(oLote._rutaLote & "\MINIATURAS", True)
            End Try
        End If

        'Borra miniaturas de local
        If Directory.Exists(oLote._rutaLoteLocal & "\MINIATURAS") Then
            Try
                Directory.Delete(oLote._rutaLoteLocal & "\MINIATURAS", True)
            Catch ex As Exception
                Directory.Delete(oLote._rutaLoteLocal & "\MINIATURAS", True)
            End Try
        End If
    End Sub

    Private Sub tsbAccion7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAccion7.Click
        'ROTAR imagen 0 grados a la izquierda
        ' ''Dim bm As Bitmap
        Dim documento As clsDocumentoE

        Dim myImageCodecInfo As ImageCodecInfo
        Dim myEncoder As Encoder
        Dim myEncoderParameter As EncoderParameter
        Dim myEncoderParameters As EncoderParameters

        Try
            Me.Cursor = Cursors.WaitCursor
            If dgv.SelectedRows.Count > 0 Then

                Dim mapaBytes As Byte()

                For Each fila As DataGridViewRow In dgv.SelectedRows
                    documento = obtieneDocumento(fila.Cells("idDocumento").Value)
                    If Not IsNothing(documento) Then
                        myImageCodecInfo = GetEncoderInfo("image/tiff")
                        myEncoder = Encoder.Compression
                        myEncoderParameters = New EncoderParameters(1)

                        ''Using bm As Bitmap = System.Drawing.Image.FromFile(documento._rutaDocumento)
                        ''    bm.RotateFlip(RotateFlipType.Rotate270FlipNone)
                        ''    Me.IMGeditPrincipal.Image = bm

                        ''    myEncoderParameter = New EncoderParameter(myEncoder, Fix(EncoderValue.CompressionLZW))
                        ''    myEncoderParameters.Param(0) = myEncoderParameter
                        ''    bm.Save(documento._rutaDocumento, myImageCodecInfo, myEncoderParameters)
                        ''End Using

                        mapaBytes = System.IO.File.ReadAllBytes(documento._rutaDocumento)
                        Using ms As System.IO.MemoryStream = New System.IO.MemoryStream(mapaBytes)
                            Using bm As Bitmap = System.Drawing.Image.FromStream(ms)
                                bm.RotateFlip(RotateFlipType.Rotate270FlipNone)

                                myEncoderParameter = New EncoderParameter(myEncoder, Fix(EncoderValue.CompressionLZW))
                                myEncoderParameters.Param(0) = myEncoderParameter
                                bm.Save(documento._rutaDocumento, myImageCodecInfo, myEncoderParameters)

                                ' ''Me.IMGeditPrincipal.Image = bm
                            End Using
                        End Using

                        mostrarImagen(Me.IMGeditPrincipal, documento._rutaDocumento)

                        'borra miniaturas
                        If File.Exists(documento._rutaDocumento.Replace("\IML", "\MINIATURAS\IML").ToUpper.Replace("TIF", "PNG")) Then
                            mapaBytes = System.IO.File.ReadAllBytes(documento._rutaDocumento.Replace("\IML", "\MINIATURAS\IML").ToUpper.Replace("TIF", "PNG"))
                            Using ms As System.IO.MemoryStream = New System.IO.MemoryStream(mapaBytes)
                                Using bm As Bitmap = System.Drawing.Image.FromStream(ms)
                                    bm.RotateFlip(RotateFlipType.Rotate270FlipNone)

                                    myEncoderParameter = New EncoderParameter(myEncoder, Fix(EncoderValue.CompressionLZW))
                                    myEncoderParameters.Param(0) = myEncoderParameter
                                    bm.Save(documento._rutaDocumento.Replace("\IML", "\MINIATURAS\IML").ToUpper.Replace("TIF", "PNG"), myImageCodecInfo, myEncoderParameters)
                                End Using
                            End Using

                            cargarMiniaturaUna(documento._rutaDocumento, documento._pagina, True)
                            ' ''File.Delete(documento._rutaDocumento.Replace("\IML", "\MINIATURAS\IML").ToUpper.Replace("TIF", "PNG"))
                        End If
                    Else
                        MessageBox.Show("Error al identificar página " & fila.Cells("Pagina").Value & " del lote " & fila.Cells("Lote").Value & " para rotar, contacte con el servicio de informática.", "Rotar páginas izquierda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        escribirEnLog("*** ERROR USUARIO. " & Now & ". Lote " & lblLote.Text & " Error al identificar página " & fila.Cells("Pagina").Value & " del lote " & fila.Cells("Lote").Value & " para rotar, contacte con el servicio de informática.")
                    End If
                Next

                'Al no refrescar, posiciono en la lista para que resalte la miniatura
                'Posiciona el grid según el parámetro indicado
                If dgv.Rows.Count > 0 Then
                    BuscarEnGridLINQ(documento._pagina.ToString.Trim, "Pagina", dgv)
                    posicionarRegistro(dgv.CurrentRow.Index)
                Else
                    pnlPresentacion1.Visible = False
                    pnlPresentacion2.Visible = False
                    pnlPresentacion3.Visible = False
                End If
                '*********************************************

                ' ''recargaMiniaturas = True

                '' '' ''Application.DoEvents()

                ' ''If Not IsNothing(documento) Then
                ' ''    refrescarLista(documento._pagina)
                ' ''Else
                ' ''    refrescarLista(1)
                ' ''End If
            Else
                MessageBox.Show("No hay páginas seleccionadas para rotar.", "Rotar páginas izquierda", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            Dim mensajeEX As String = ""
            'Excepción interna
            If ex.InnerException IsNot Nothing Then
                mensajeEX = " Inner exception: " & ex.InnerException.Message
            End If
            escribirEnLog("*** ERROR. " & Now & ". Ocurrió un error al rotar las páginas a la izquierda." & vbLf & ex.Message & vbLf & mensajeEX & vbLf & ex.StackTrace)

            ' ''MessageBox.Show("Ocurrió un error al rotar las páginas a la izquierda." & vbCrLf & ex.Message, "Error al rotar izquierda", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub RotarPágina90ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RotarPágina90ToolStripMenuItem.Click
        tsbAccion7_Click(Nothing, Nothing)
    End Sub

    Private Sub frmDigitalizacionTwain_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Me.Cursor = Cursors.WaitCursor

        e.Handled = True

        Select Case e.KeyCode

            Case Keys.Home
                tsbRegistroPrimero_Click(dgv, Nothing)

            Case Keys.End
                tsbRegistroUltimo_Click(dgv, Nothing)

                '''LAS TECLAS DE LAS FLECHAS ARRIBA Y ABAJO ESTÁN EN EL EVENTO KEYUP de la lista

            Case Keys.S     'Sustituir imagen
                tsbAccion1_Click(Nothing, Nothing)

            Case Keys.I     'Insertar imagen
                tsbAccion5_Click(Nothing, Nothing)

            Case Keys.NumPad4   'Borrar documento
                'Eliminar documento FISICAMENTE
                tsbAccion2_Click(Nothing, Nothing)

            Case Keys.D4   'Borrar documento
                'Eliminar documento FISICAMENTE
                tsbAccion2_Click(Nothing, Nothing)

            Case Keys.NumPad2   'Documento en mal estado
                tsbAccion4_Click(Nothing, Nothing)

            Case Keys.D2   'Documento en mal estado
                tsbAccion4_Click(Nothing, Nothing)

            Case Keys.Add   'Rotar 90 derecha
                tsbAccion3_Click(Nothing, Nothing)

            Case Keys.Subtract   'Rotar 90 izquierda
                tsbAccion7_Click(Nothing, Nothing)

            Case Keys.F5  'Rfrescar
                cmdRecargarLista_Click(Nothing, Nothing)

        End Select

        e.Handled = False

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub txtNHC_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNHC.Leave
        Me.KeyPreview = True
    End Sub

    Private Sub txtNHC_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNHC.Enter
        Me.KeyPreview = False
    End Sub

    Private Sub tstPorcentajeNegro_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tstPorcentajeNegro.Enter
        Me.KeyPreview = False
    End Sub

    Private Sub tstPorcentajeNegro_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tstPorcentajeNegro.Leave
        Me.KeyPreview = True
    End Sub

    Private Sub nudGrados_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudGrados.Leave
        Me.KeyPreview = True
    End Sub

    Private Sub nudGrados_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudGrados.Enter
        Me.KeyPreview = False
    End Sub

    Private Sub stsBuscaPagina_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stsBuscaPagina.Enter
        Me.KeyPreview = False
    End Sub

    Private Sub stsBuscaPagina_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stsBuscaPagina.Leave
        Me.KeyPreview = True
    End Sub

    Private Function esperaDesbloqueoFichero(ByVal ruta As String) As Boolean
        Dim timeOut As Integer = 8
        Dim horaInicio As DateTime = Now
        Dim desbloqueado As Boolean = False
        Dim resultado As Boolean = False

        Do
            Try
                Using fs As New System.IO.FileStream(ruta, System.IO.FileMode.Open, System.IO.FileAccess.Read)

                End Using

                desbloqueado = True
                resultado = True

            Catch ex As Exception

            Finally
                'Si han pasado los segundos indicados en la variable timeOut, salgo del bucle para que no se haga infinito y muestro la imagen comodín.
                If horaInicio.AddSeconds(timeOut) < Now Then
                    desbloqueado = True
                End If

            End Try

        Loop Until desbloqueado = True

        esperaDesbloqueoFichero = resultado

    End Function

    Private Sub cmdAyuda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAyuda.Click

        Try
            Dim proc As New Process
            proc.StartInfo.FileName = My.Application.Info.DirectoryPath & "\Ayuda_digitalizacion.pdf"
            proc.Start()

        Catch ex As Exception
            MessageBox.Show("No ha sido posible abrir el fichero de ayuda " & My.Application.Info.DirectoryPath & "\Ayuda_digitalizacion.pdf" & ".", "Ayuda", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

End Class