
Imports LibreriaCadenaProduccion.Entidades.ClsLote
Imports LibreriaCadenaProduccion.Controles.Formularios.FormMensajeBarraIndeterminada
Imports System.Windows.Forms
Imports System.IO
Imports accesoDatos = LibreriaCadenaProduccion.Datos.GeneralSQL.clsAccesoDatosSQL
Imports accesoDatosProduccion = LibreriaCadenaProduccion.Datos.Produccion.clsAccesoDatosProduccion
Imports accesoDatosLotes = LibreriaCadenaProduccion.Datos.Produccion.cadenaproduccion.clsAccesoDatosLote
Imports accesoDatosDocumentos = LibreriaCadenaProduccion.Datos.Produccion.cadenaproduccion.clsAccesoDatosDocumento

Imports entidades = LibreriaCadenaProduccion.Entidades
Imports System.Drawing.Imaging

Public Class frmVerificacion

#Region "Eventos y metodos"

    ''' <summary>
    ''' Evento que indica la finalizacion de carga de Imagen en memoria del Thread
    ''' </summary>
    ''' <remarks></remarks>
    Event cargadoImagen(ByRef imagen As Image)

    'Sub fnc_imagenFinalizada(ByRef imagen As Image) Handles Me.cargadoImagen
    '    'Mostramos
    '    'ImageControlFunciones1.cargarImagen(imagen.imagen)
    '    'PictureBox1.Image = imagen.imagen
    '    If imagen Is Nothing Then
    '        'En el caso de que no la encuentre (o cargamos una por defecto
    '        'o creamos una del tamaño de la pantalla negra utilizando GDI
    '        imagen = New Bitmap(PanelImagen1.Width, PanelImagen1.Height)
    '        Dim g As Graphics = Graphics.FromImage(imagen)
    '        g.Clear(Color.White)
    '        Dim fuente As New System.Drawing.Font("Arial", 13, FontStyle.Bold, GraphicsUnit.Pixel, 1)
    '        g.DrawString("IMAGEN NO ENCONTRADA: " & grdDocumentos.CurrentRow.Cells("NomArchivo").Value.ToString, fuente, Brushes.Black, 100, 100)

    '    End If
    '    PanelImagen1.panel_imagen = imagen
    '    imagen.Dispose()
    '    imagen = Nothing
    '    'PictureBox1.Image = imagen
    '    'imagen.Dispose()
    '    ' imagen = Nothing
    'End Sub

    ''' <summary>
    ''' Cargamos en el hilo de ejecucion la carga de la imagen que luego, lanzaremos con el evento
    ''' </summary>
    ''' <remarks></remarks>
    Sub fnc_hiloFuncion()
        Dim imagen2 As Image = Nothing
        imagen2 = Image.FromFile(imagen_visualizada_ruta)

        'If IO.File.Exists(imagen_visualizada_ruta) Then
        '    Try
        '        Dim imagen As Image = Image.FromFile(imagen_visualizada_ruta)
        '        imagen2 = fnc_imagenLibera(imagen)

        '        'Liberamos la imagen referenciada a fichero
        '        imagen.Dispose()
        '        imagen = Nothing
        '    Catch ex As Exception

        '    End Try

        'End If

        RaiseEvent cargadoImagen(imagen2)
        imagen2 = Nothing
    End Sub

    ''' <summary>
    ''' Metodo para realizar una copia de una imagen asociada a un fichero sin el enlace
    ''' </summary>
    ''' <param name="imagen"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Function fnc_imagenLibera(ByRef imagen As Image) As Image
        Dim imagen2 As Image = New Bitmap(imagen.Width, imagen.Height)
        Dim g As Graphics = Graphics.FromImage(imagen2)
        g.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
        Dim rec As New Rectangle(0, 0, imagen.Width, imagen.Height)
        g.DrawImage(imagen, rec)

        imagen.Dispose()
        imagen = Nothing

        Return imagen2
    End Function





    ''' <summary>
    ''' Cuando salta el evento de imagen cargada habilitamos el movimiento de documento
    ''' </summary>
    ''' <remarks></remarks>
    Sub fnc_releaseTeclado()
        documento_cambio = True
    End Sub

    ''' <summary>
    ''' Evento de cambio de modo. Se activa en el cambio de modo del visor de imagenes
    ''' retorna el foco a la grid de Documentos
    ''' </summary>
    ''' <param name="modo"></param>
    ''' <remarks></remarks>
    Sub cambioModo(ByVal modo As Integer)
        'Cuando hacemos un cambio de modo en el control cambiamos el modo a la grid
        grdDocumentos.Focus()
    End Sub

#End Region

    Public Event e_cambia_texto(ByVal texto As String)

    Dim imagenes_ruta As String
    Dim imagen_visualizada_ruta As String
    Dim imagenes_ruta_servidor As String

    Dim documento_id As Integer
    Dim documento_cambio As Boolean
    Dim teclas_marcarIncidencias As DataTable

    Dim imagen_rotada As Boolean

    Dim dt_documentos As DataTable
    Dim WithEvents imagen_hilo As Threading.Thread

    Dim imagen_ruta_actual As String

    Dim tmpTemporal As String = "C:\temp\tmp.tif"

    Dim incidencias_tipo As String = "DIGI"

    Public Sub New()

        'Creamos la imagen temporal blanca
        If Not IO.File.Exists(tmpTemporal) Then
            Dim imagen As New Bitmap(200, 300)
            Dim g As Graphics = Graphics.FromImage(imagen)
            g.Clear(Color.White)
            imagen.Save(tmpTemporal, System.Drawing.Imaging.ImageFormat.Tiff)
        End If

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

    End Sub

    Private Sub Form_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Call inicializarDatos()
        'En la carga inicial comprobamos si hay que girar algunas fotos, en el caso de que haya
    End Sub

    Private Sub inicializarDatos()

        PictureBox1.Image = tmpTemporal

        Try
            'ponemos el numero del lote
            Me.Text = Me.Text & "- Lote " & frmContenedorMDI.oLote._idlote

            'poner la cadena de teclas de acceso rapido 
            Dim cadenaTeclasAccesoRapido As String = "F1  Rotar Imágen; F2 y ""+/-"" Zoom; F5 y ""+/-"" Brillo;F6 y ""+/-"" Contraste; Esc para salir todos los modos"
            RaiseEvent e_cambia_texto(cadenaTeclasAccesoRapido)
            'frmContenedorMDI.ArchivoToolStripMenuItem.Text = cadenaTeclasAccesoRapido

            'obtener la ruta de las imagenes del lote 
            imagenes_ruta = accesoDatosProduccion.ObtenerRutaImagenes(frmContenedorMDI.oProyecto._CodigoProyecto, _
                                    frmContenedorMDI.oLote._idlote, My.Settings.cadenaConexion)

            'imagenes_ruta_servidor = accesoDatosProduccion.ObtenerRutaImagenes(oProyecto._CodigoProyecto, _
            '                        oLote._idlote, My.Settings.cadenaConexion)
            grdDocumentos.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige

            'Eliminamos la carpeta
            'IO.Directory.Delete("c:\temp\" & oProyecto._CodigoProyecto & oLote._idloteCompleto, True)
            'My.Computer.FileSystem.DeleteDirectory("c:\temp\" & oProyecto._CodigoProyecto & oLote._idloteCompleto, FileIO.DeleteDirectoryOption.DeleteAllContents)
            'Copiamos la carpeta del servidor a nuestra ruta local
            'My.Computer.FileSystem.CopyDirectory(imagenes_ruta_servidor, "c:\temp\" & oProyecto._CodigoProyecto & oLote._idloteCompleto, True)

            'imagenes_ruta = "c:\temp\" & oProyecto._CodigoProyecto & oLote._idloteCompleto

            'Cambiamos el control imagen a modo rotacion
            'PanelImagen1.cambiaModo(1)

            'obtenemos el codigo de las incidencias y el codigo de la tecla asociada
            teclas_marcarIncidencias = accesoDatos.ejecutarSQLDirecta("select idincidencia as Codigo, codigoAscii from tiposincidencias where letraaccesorapido is not null and (tipo = 'digi' or idincidencia=0)", frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto).Tables(0)

            'actualiza el grid con la consulta 
            fnc_actualizaGrid()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try

    End Sub



#Region "Grid"

    'contienen la consulta de los registros a mostrar para verificar
    Sub fnc_actualizaGrid(Optional ByVal registroId As Integer = 0)

        Try
            Dim consultaSQL As String = "SELECT dc.idlote as id_lote,dc.pagina,dc.NumHistoria as NHC,dc.eliminada,ti.descripcion, (select TOP 1 NOMBRE from fip where numhistoria=dc.numhistoria) as nombre,(select TOP 1 APELLIDO1 from fip where numhistoria=dc.numhistoria) as APELLIDO1,(select TOP 1 APELLIDO2 from fip where numhistoria=dc.numhistoria) as APELLIDO2,dc.NomArchivoTIF as NomArchivo, " _
            & "isnull(dc.girado,'0') girado,dc.VerificadoDigi,isnull(dc.Incidencia ,'0') Incidencia," _
            & "isnull(dc.CorregidoDigi ,'0') Corregida," _
            & "dc.iddocumento as ID,isnull(dc.BarcodeDet,0) BarcodeDet, " _
            & "isnull(dc.CorregidoDigi ,'0') CorregidoDigi, ti.idincidencia as codigo,Isnull(ti.idincidencia,'0') as ID_incidencia " _
            & "from DOCUMENTOS dc LEFT OUTER JOIN " _
            & "DOCUMENTOSINCIDENCIAS di ON dc.IdDocumento = di.IdDocumento LEFT OUTER JOIN " _
            & "TIPOSINCIDENCIAS ti ON di.IdIncidencia = ti.IdIncidencia AND ti.tipo = 'DIGI' " _
            & "WHERE     (dc.idlote = " & frmContenedorMDI.oLote._idlote & ") ORDER BY dc.pagina asc "

            'Dim consultaSQL As String = "SELECT documentos.id_lote as id_lote,documentos.Pagina, documentos.NomArchivoTIF as NomArchivo, documentos.NumHistoria as NHC  ,isnull(documentos.girado,'0') girado,documentos.VerificadoDigi, tipoincidencias.descripcion, isnull(documentos.Incidencia ,'0') Incidencia,documentos.NumICU as ICU, " _
            '& "isnull(documentos.CorregidoDigi ,'0') Corregida,  " _
            '& "documentos.CodServicioUbicado as Servicio, isnull(hospital,'') hospital, " _
            '& "documentos.ID, isnull(documentos.BarcodeDet,0) BarcodeDet, isnull(documentos.tipodocumento,'') tipodocumento, " _
            '& " isnull((SELECT top 1 fip.nombrecompleto from fip where documentos.numhistoria=numhistoria and documentos.hospital =hospital ),'Sin nombre') as nombre, " _
            '& " isnull(documentos.CorregidoDigi ,'0') CorregidoDigi, tipoincidencias.Codigo " _
            '& " from ( " _
            '& " SELECT id," _
            '& "	Isnull((SELECT TOP 1 ID_incidencia from docsincidencias where ID_documento=documentos.ID),'0') as ID_incidencia" _
            '& "	from documentos where Hospital=" & oProyecto._codigoHospital & " and CodigoLote=" & oLote._nombreCompleto & " and FechaLote='" & oLote._FechaLote & "' and Tipolote='" & oLote._TipoLote & "' and Proyecto='" & oProyecto._CodigoProyecto & "'" _
            '& ") as SQL " _
            '& "LEFT JOIN documentos on documentos.id = sql.id " _
            '& "LEFT JOIN tipoincidencias on tipoincidencias.Codigo=sql.ID_Incidencia " _
            '& " ORDER BY id_lote asc "

            'Dim consultaSQL As String = " Select isnull(girado,'0') girado,VerificadoDigi,Pagina, isnull(Incidencia ,'0') Incidencia, NumHistoria as NHC, NumICU as ICU, NomArchivoTIF as NomArchivo, " _
            '& "isnull(CorregidoDigi ,'0') Corregida, " _
            '& "IncidenciaHist, CodServicioUbicado as Servicio, " _
            '& "ID , ID_lote, CodigoLote, BarcodeDet,  " _
            '& " isnull(CorregidoDigi ,'0') CorregidoDigi" _
            '& " from Documentos LEFT JOIN tipoincidencias on Documentos.codigo = tipoincidencias.codigo " _
            '& " where Hospital=" & oProyecto._codigoHospital & " and CodigoLote=" & oLote._nombreCompleto & " and FechaLote='" & oLote._FechaLote & "' and Tipolote='" & oLote._TipoLote & "' and Proyecto='" & oProyecto._CodigoProyecto & "'"

            dt_documentos = accesoDatos.ejecutarSQLDirecta(consultaSQL, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto).Tables(0)
            grdDocumentos.DataSource = dt_documentos

            Me.Text = frmContenedorMDI.Text & frmContenedorMDI.oLote._nombreCompleto & " Número Documentos " & dt_documentos.Rows.Count.ToString


            'Columnas visibles

            grdDocumentos.Columns("id_lote").Visible = True
            grdDocumentos.Columns("id_lote").Width = "40"

            grdDocumentos.Columns("Pagina").Visible = True
            grdDocumentos.Columns("Pagina").Width = "40"

            grdDocumentos.Columns("eliminada").Visible = True
            grdDocumentos.Columns("eliminada").Width = "40"

            grdDocumentos.Columns("NomArchivo").Visible = True
            grdDocumentos.Columns("NomArchivo").Width = "83"
            'grdDocumentos.Columns("VerificadoDigi").Visible = True

            grdDocumentos.Columns("NHC").Visible = True
            grdDocumentos.Columns("NHC").Width = "80"

            grdDocumentos.Columns("nombre").Visible = True
            grdDocumentos.Columns("nombre").Width = "100"

            grdDocumentos.Columns("apellido1").Visible = True
            grdDocumentos.Columns("apellido1").Width = "100"

            grdDocumentos.Columns("apellido2").Visible = True
            grdDocumentos.Columns("apellido2").Width = "100"

            grdDocumentos.Columns("Girado").Visible = True
            grdDocumentos.Columns("Girado").Width = "20"

            grdDocumentos.Columns("Id").Visible = True
            grdDocumentos.Columns("Id").Width = "20"

            grdDocumentos.Columns("Incidencia").Visible = False

            grdDocumentos.Columns("Descripcion").Visible = True
            grdDocumentos.Columns("Descripcion").Width = 90

            ' grdDocumentos.Columns("nombre").Visible = False
            'grdDocumentos.Columns("nombre").Width = 160

            'Columnas ocultas
            grdDocumentos.Columns("BarcodeDet").Visible = False
            ' grdDocumentos.Columns("Servicio").Visible = True

            'grdDocumentos.Columns("IncidenciaHist").Visible = False
            grdDocumentos.Columns("Corregida").Visible = False

            grdDocumentos.Columns("Codigo").Visible = False
            'grdDocumentos.Columns("Insertado").Visible = False

            'Asignamos propiedades a las columnas y tamaños
            If grdDocumentos.Columns.Count - 1 > 0 Then
                For i As Integer = 0 To grdDocumentos.Columns.Count - 1
                    grdDocumentos.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                Next
            End If

            If grdDocumentos.RowCount > 0 Then
                'Mandamos el foco al registro
                If registroId <= grdDocumentos.RowCount - 1 Then
                    grdDocumentos.CurrentCell = grdDocumentos.Item(0, registroId)
                Else
                    grdDocumentos.CurrentCell = grdDocumentos.Item(0, 0)
                End If

                'Mostramos imagen
                fnc_seleccionRegistro()
                Me.grdDocumentos.Focus()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try

    End Sub

    'marca el documento como verificaco = 1 en la tabla documentos y muestra 
    'la imagen correspondiente al registro 
    Sub fnc_seleccionRegistro()

        'Cuando seleccionamos el registro en el caso de que sea, una

        If grdDocumentos.RowCount > 0 Then ' controlamos que hay registros par el lote 

            fnc_cargaImagen()

            'Si el campo de verificado es 0 lo actualizamos a 1, actualizamos el registro (Si va lento tread)
            If dt_documentos.Rows(grdDocumentos.CurrentRow.Index).Item("verificadoDigi").ToString = "0" Then

                Dim consultaSQL As String = "UPDATE " & frmContenedorMDI.oProyecto._NombreBaseDatos & ".dbo.documentos  SET verificadoDigi='1',fechaVerificadoDigi=getdate(),usuarioVerificadoDigi='" & frmContenedorMDI.oUsuario._login & "' WHERE ID='" & dt_documentos.Rows(grdDocumentos.CurrentRow.Index).Item("ID").ToString & "'"

                'Actualizamos el campo verificado digi del datarow si la actualizacion en la base 
                'de datos se hace de forma correcta
                If accesoDatos.ejecutaSQLEjecucion(consultaSQL, My.Settings.cadenaConexion) Then
                    dt_documentos.Rows(grdDocumentos.CurrentRow.Index).Item("verificadoDigi") = "1"

                End If

            End If

        End If
    End Sub

    Sub imagen_libera()
        'If PictureBox1.Image IsNot Nothing Then PictureBox1.Image.Dispose()
        PictureBox1.Image = Nothing
    End Sub

    ''' <summary>
    ''' Este metodo muestra en cuadro de visualizacion la imagen seleccionada
    ''' </summary>
    ''' <remarks></remarks>
    Sub fnc_cargaImagen()
        Try

            If grdDocumentos.CurrentRow.Cells IsNot Nothing Then

                imagen_rotada = False

                'Dim imagen2 As Image = Nothing
                'imagen_ruta_actual = imagenes_ruta & "\" & grdDocumentos.CurrentRow.Cells("NomArchivo").Value.ToString

                'If IO.File.Exists(nombreFichero) Then
                '    imagen2 = Image.FromFile(nombreFichero)

                '    'Try
                '    '    Dim imagen As Image = Image.FromFile(nombreFichero)
                '    '    'Application.DoEvents()
                '    '    imagen2 = fnc_imagenLibera(imagen)
                '    '    'Application.DoEvents()
                '    '    'Liberamos la imagen referenciada a fichero
                '    '    imagen.Dispose()
                '    '    imagen = Nothing
                '    'Catch ex As Exception

                '    'End Try
                'End If

                'Si no existe imagen la generamos
                'If imagen2 Is Nothing Then
                '    imagen2 = New Bitmap(PictureBox1.Width, PictureBox1.Height)
                '    Dim g As Graphics = Graphics.FromImage(imagen2)
                '    g.Clear(Color.White)
                '    Dim fuente As New System.Drawing.Font("Arial", 13, FontStyle.Bold, GraphicsUnit.Pixel, 1)
                '    g.DrawString("IMAGEN NO ENCONTRADA: " & grdDocumentos.CurrentRow.Cells("NomArchivo").Value.ToString, fuente, Brushes.Black, 100, 100)
                'End If


                If IO.File.Exists(imagenes_ruta & "\" & grdDocumentos.CurrentRow.Cells("NomArchivo").Value.ToString) Then
                    'imagen2.Save(tmp, System.Drawing.Imaging.ImageFormat.Gif)
                    'PictureBox1.ClearDisplay()
                    imagen_muestra(imagenes_ruta & "\" & grdDocumentos.CurrentRow.Cells("NomArchivo").Value.ToString)
                Else
                    PictureBox1.ClearDisplay()
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Incidencia de aplicacion")
        End Try

    End Sub


    '''' <summary>
    '''' Este metodo muestra en cuadro de visualizacion la imagen seleccionada
    '''' </summary>
    '''' <remarks></remarks>
    'Sub fnc_cargaImagen()
    '    Try

    '        If grdDocumentos.CurrentRow.Cells IsNot Nothing Then

    '            'grdDocumentos.Enabled = False

    '            imagen_visualizada_ruta = imagenes_ruta & "\" & grdDocumentos.CurrentRow.Cells("NomArchivo").Value.ToString
    '            imagen_hilo = New Threading.Thread(AddressOf fnc_hiloFuncion)
    '            imagen_hilo.Start()
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Incidencia de aplicacion")
    '    End Try

    'End Sub




    ''' <summary>
    ''' Metodo de repintado de la grid, para los colores de las casillas
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DataGridView1_RowPrePaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles grdDocumentos.RowPrePaint
        'TODO: Repintado de GRID

        Dim theRow As DataGridViewRow

        Try
            If e.RowIndex < sender.rows.count Then
                theRow = Me.grdDocumentos.Rows(e.RowIndex)

                If theRow IsNot Nothing Then

                    If theRow.Cells("Incidencia").Value.ToString() = "1" Then
                        theRow.DefaultCellStyle.BackColor = Color.Red

                        Dim font As New System.Drawing.Font("Microsoft Sans Serif", 8, FontStyle.Bold)
                        theRow.Cells("Descripcion").Style.Font = font

                    ElseIf theRow.Cells("BarcodeDet").Value.ToString = "1" Then
                        theRow.DefaultCellStyle.BackColor = Color.LightGreen
                    ElseIf theRow.Cells("eliminada").Value.ToString = "1" Then
                        theRow.DefaultCellStyle.BackColor = Color.DarkBlue
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try

    End Sub

    Sub imagen_muestra(ByVal ruta As String)
        PictureBox1.ClearDisplay()
        PictureBox1.Image = ""
        PictureBox1.Image = ruta
        'Hacemos la seleccion de la imagen
        'PictureBox1.SelectionRectangle = True
        'PictureBox1.Select()
        'PictureBox1.ZoomToSelection()
        PictureBox1.FitTo(0)
        'PictureBox1.ImageScaleWidth = PictureBox1.Width
        PictureBox1.Display()
        PictureBox1.Refresh()
    End Sub

    ''' <summary>
    ''' Funcion para rotar la imagen actual
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function imagen_rota() As Boolean
        imagen_rotada = True
        Try
            'Cogemos la imagen de la ruta seleccionada y la giramos 90 grados
            'Si existe la imagen 
            'Dim ruta As String = imagenes_ruta & "\" & grdDocumentos.CurrentRow.Cells("NomArchivo").Value.ToString
            'If IO.File.Exists(ruta) Then
            'Dim imagen As Image = Image.FromFile(ruta)
            'imagen.RotateFlip(RotateFlipType.Rotate90FlipNone)
            'PictureBox1.Image = tmpTemporal
            'imagen.Save(ruta, System.Drawing.Imaging.ImageFormat.Tiff)
            'imagen_muestra(ruta)
            'Application.DoEvents()
            'imagen_muestra(ruta)
            'Dim filtro As New filtrados.RotateBilinear(90 * var_posicion_filtro, True)
            'Return filtro.Apply(var_imagen_resizeada)

            'PictureBox1.Display()
            'PictureBox1.FitTo(0)

            PictureBox1.RotateRight()
            PictureBox1.Save()
            PictureBox1.FitTo(0)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Incidencia de aplicacion")
            imagen_rotada = False
        End Try

    End Function

    '''' <summary>
    '''' Salvamos la imagen actual en la ruta seleccionada
    '''' </summary>
    '''' <param name="ruta"></param>
    '''' <remarks></remarks>
    'Function imagen_salva(ByVal ruta As String) As Boolean
    '    Dim imagen As Image = fnc_imagenLibera(PictureBox1.Image)
    '    PictureBox1.Image = Nothing
    '    Try
    '        If IO.File.Exists(ruta) Then IO.File.Delete(ruta)
    '        imagen.Save(ruta, System.Drawing.Imaging.ImageFormat.Tiff)
    '        PictureBox1.Image = imagen
    '        Return True
    '    Catch ex As Exception
    '        PictureBox1.Image = imagen
    '        MsgBox("La imagen se esta cargando, espere un poco para salvar" & vbCrLf & ex.Message, MsgBoxStyle.Exclamation, "Incidencia de aplicacion")
    '        Return False
    '    End Try
    'End Function

    'aqui en funcion de la tecla que presione el usuario marcamos las distientas incidencias 
    'F1  Rotar Imágen
    'F2 y "+/-"" Zoom
    'F5 y ""+/-"" Brillo
    'F6 y ""+/-"" Contraste
    'Esc para salir todos los modos
    'Falta Indexar       P
    'Doc. Mal Estado     Z
    'Fuera de sitio      F
    'Sin caratula        x
    'Para girar          G
    'Para Borrar         B
    'Mal digitalizada    M
    'FIP incorrecto      W
    'Docs Solapados      J
    'Caratulas Cambiadas N
    'Docs Desordenados   E
    'Barcode Erroneo     U
    'Formato no valido   V
    'Ins. Fuera de sitio Ñ
    Private Sub grdDocumentos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdDocumentos.KeyDown
        e.Handled = True

        'si marcamos cualquier tecla que no es la de girado mismo 
        'si en el paso anterior hemos marcado rotacion guardamos la imagen rotada
        If e.KeyCode <> 107 Then Call GuardarImagenRotada()


        Select Case e.KeyCode
            '*******************************************
            'control del desplazamiento de los registros 
            '*******************************************
            Case Keys.Up
                'If documento_cambio Then
                'documento_cambio = False
                moverRegistro(0)
                'fnc_seleccionRegistro()
                'End If
            Case Keys.Down

                'If documento_cambio Then
                'documento_cambio = False
                moverRegistro(1)
                'fnc_seleccionRegistro()
                'End If

                '*******************************************

            Case Keys.Home
                'If documento_cambio Then
                'documento_cambio = False
                moverRegistro(4)
                'fnc_seleccionRegistro()
                'End If

            Case Keys.End
                'If documento_cambio Then
                'documento_cambio = False
                moverRegistro(5)
                'fnc_seleccionRegistro()
                'End If
            Case Keys.PageUp
                ' If documento_cambio Then
                'documento_cambio = False
                moverRegistro(2)
                'fnc_seleccionRegistro()
                ' End If

            Case Keys.PageDown
                'If documento_cambio Then
                'documento_cambio = False
                moverRegistro(3)
                'fnc_seleccionRegistro()
                'End If

            Case 96
                'Desmarcar
                accesoDatosDocumentos.DesmarcarInicidencia(dt_documentos.Rows(grdDocumentos.CurrentRow.Index).Item("ID").ToString, My.Settings.cadenaConexion, frmContenedorMDI.oProyecto._NombreBaseDatos)
                fnc_actualizaGrid(grdDocumentos.CurrentRow.Index)

            Case Keys.NumPad4

                accesoDatosDocumentos.EliminarDocumento(frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto, dt_documentos.Rows(grdDocumentos.CurrentRow.Index).Item("id_lote").ToString, dt_documentos.Rows(grdDocumentos.CurrentRow.Index).Item("pagina").ToString)
                fnc_actualizaGrid(grdDocumentos.CurrentRow.Index)

            Case 106
                'Asterisco = Zoom
                'Muestra la ventana de zoom

                Dim ruta As String = imagenes_ruta & "\" & grdDocumentos.CurrentRow.Cells("NomArchivo").Value.ToString

                If grdDocumentos.CurrentRow IsNot Nothing Then
                    If IO.File.Exists(ruta) Then
                        Dim imagen As Image = Image.FromFile(ruta)
                        Dim ventana As New frmZoom(imagen)
                        ventana.ShowDialog()
                        imagen.Dispose()

                    End If

                End If

                'With ventana
                '.ShowDialog()
                'End With

            Case 107
                'Girar documento
                If grdDocumentos.CurrentRow IsNot Nothing Then imagen_rota()

                'Case Keys.Enter
                '    'Solo en el caso de que esté modificada, salvamos el estado
                '    'If PanelImagen1.imagen_isModificada Then
                '    If imagen_salva(imagenes_ruta & "\" & grdDocumentos.CurrentRow.Cells("NomArchivo").Value.ToString) Then
                '        Dim consultaSQL As String

                '        consultaSQL = "UPDATE documentos SET girado='1',fechaGirado=getdate(),usuarioGirado='" _
                '        & oUsuario._login & "' where ID='" & dt_documentos.Rows(grdDocumentos.CurrentRow.Index).Item("ID").ToString & "'"

                '        If accesoDatos.ejecutaSQLEjecucion(consultaSQL, My.Settings.cadenaConexion) Then
                '            dt_documentos.Rows(grdDocumentos.CurrentRow.Index).Item("girado") = "1"
                '        End If

                '    End If
                'End If
            Case Else
                'MARCAR INCIDENCIA 
                'Buscamos si la tecla se encuentra en los tipos de errores
                'Si la encuentra lanzamos la funcion
                accesoDatosDocumentos.MarcarIndidenciaDocumento(CInt(e.KeyCode), dt_documentos.Rows(grdDocumentos.CurrentRow.Index).Item("ID").ToString, teclas_marcarIncidencias, My.Settings.cadenaConexion, "PAED", frmContenedorMDI.oProyecto._NombreBaseDatos)
                fnc_actualizaGrid(grdDocumentos.CurrentRow.Index)
        End Select
    End Sub


    Private Sub GuardarImagenRotada()

        'Antes de mover el registro, si hay cambios se guarda la imagen
        If imagen_rotada Then

            'Solo en el caso de que esté modificada, salvamos el estado
            'If PanelImagen1.imagen_isModificada Then
            'If imagen_salva(imagenes_ruta & "\" & grdDocumentos.CurrentRow.Cells("NomArchivo").Value.ToString) Then
            Dim consultaSQL As String

            consultaSQL = "UPDATE " & frmContenedorMDI.oProyecto._NombreBaseDatos & ".dbo.documentos SET girado='1' where iddocumento='" & dt_documentos.Rows(grdDocumentos.CurrentRow.Index).Item("ID").ToString & "'"

            If accesoDatos.ejecutaSQLEjecucion(consultaSQL, My.Settings.cadenaConexion) Then
                dt_documentos.Rows(grdDocumentos.CurrentRow.Index).Item("girado") = "1"
            End If

            'End If

        End If

    End Sub
    ''' <summary>
    ''' Movimiento de registro en la grid
    ''' </summary>
    ''' <param name="direccion"></param>
    ''' <remarks></remarks>

    Sub moverRegistro(ByVal direccion As Integer)

        'El registro puede moverse arriba o abajo, segun el indice
        If grdDocumentos.CurrentRow IsNot Nothing Then


            If grdDocumentos.RowCount > 0 Then
                Select Case direccion
                    Case -1
                        grdDocumentos.CurrentCell = grdDocumentos.Item(0, grdDocumentos.CurrentRow.Index)
                    Case 0
                        If grdDocumentos.CurrentRow.Index > 0 Then grdDocumentos.CurrentCell = grdDocumentos.Item(0, grdDocumentos.CurrentRow.Index - 1)
                    Case 1
                        If grdDocumentos.CurrentRow.Index < grdDocumentos.RowCount - 1 Then grdDocumentos.CurrentCell = grdDocumentos.Item(0, grdDocumentos.CurrentRow.Index + 1)
                    Case 2
                        If grdDocumentos.CurrentRow.Index > 20 Then
                            grdDocumentos.CurrentCell = grdDocumentos.Item(0, grdDocumentos.CurrentRow.Index - 20)
                        Else
                            grdDocumentos.CurrentCell = grdDocumentos.Item(0, 0)
                        End If
                    Case 3
                        If grdDocumentos.CurrentRow.Index < grdDocumentos.RowCount - 1 - 20 Then
                            grdDocumentos.CurrentCell = grdDocumentos.Item(0, grdDocumentos.CurrentRow.Index + 20)
                        Else
                            grdDocumentos.CurrentCell = grdDocumentos.Item(0, grdDocumentos.RowCount - 1)
                        End If
                    Case 4
                        grdDocumentos.CurrentCell = grdDocumentos.Item(0, 0)
                    Case 5
                        grdDocumentos.CurrentCell = grdDocumentos.Item(0, grdDocumentos.RowCount - 1)
                End Select


                'If grdDocumentos.CurrentRow.Index = 0 Then
                '    btnAnt.Enabled = False
                '    btnSig.Enabled = True
                'ElseIf grdDocumentos.CurrentRow.Index = grdDocumentos.RowCount - 1 Then
                '    btnAnt.Enabled = True
                '    btnSig.Enabled = False
                'Else
                '    btnAnt.Enabled = True
                '    btnSig.Enabled = True
                'End If

                'grdDocumentos.CurrentCell = seleccionaRegistro( rojos.Item(rojos_indice).Item("ID").ToString)
                fnc_seleccionRegistro()
            End If
        End If

    End Sub

    ''' <summary>
    ''' Busqueda de un ID en la grid, se busca en la columna ID el parametro expecificado
    ''' y se devuelve el cell correspondiente para luego asignarlo al currentCell 
    ''' de la Grid y posicionarlo
    ''' 
    ''' </summary>
    ''' <param name="nombre"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Function seleccionaRegistro(ByVal nombre As String) As DataGridViewCell
        Dim busqueda As System.Collections.Generic.List(Of DataGridViewRow) = (From grid As DataGridViewRow In grdDocumentos.Rows Where grid.Cells("ID").Value.ToString = nombre).ToList
        If busqueda.Count > 0 Then
            Return busqueda(0).Cells(0)
        Else
            Return Nothing
        End If
    End Function


    Private Sub grdDocumentos_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles grdDocumentos.MouseClick
        moverRegistro(-1)
    End Sub

#End Region

#Region "Botones de panel inferior"

    Private Sub btnSig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSig.Click
        moverRegistro(1)
        fnc_seleccionRegistro()
    End Sub

    Private Sub btnAnt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnt.Click
        moverRegistro(0)
        fnc_seleccionRegistro()
    End Sub

    Private Sub cmdCerrarlote_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CtrlBotonGrande1.eClick
        Try
            If accesoDatosLotes.CerrarLoteVerificacion(frmContenedorMDI.oUsuario._login, frmContenedorMDI.oLote._idlote, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto) = 0 Then
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


#End Region


  
  
End Class
