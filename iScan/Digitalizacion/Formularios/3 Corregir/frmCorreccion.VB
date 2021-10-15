Imports LibreriaCadenaProduccion.Entidades.ClsLote
Imports LibreriaCadenaProduccion.Controles.Formularios.FormMensajeBarraIndeterminada
Imports System.Windows.Forms
Imports System.IO
Imports accesoDatos = LibreriaCadenaProduccion.Datos.GeneralSQL.clsAccesoDatosSQL
Imports accesoDatosProduccion = LibreriaCadenaProduccion.Datos.Produccion.clsAccesoDatosProduccion
Imports accesoDatosLotes = LibreriaCadenaProduccion.Datos.Produccion.cadenaproduccion.clsAccesoDatosLote
Imports accesoDatosDocumentos = LibreriaCadenaProduccion.Datos.Produccion.cadenaproduccion.clsAccesoDatosDocumento
Imports operacionesDigi = LibreriaCadenaProduccion.Entidades.ClsOperacionesDigitalizacion

Imports entidades = LibreriaCadenaProduccion.Entidades
Imports System.Drawing.Imaging

Public Class frmCorreccion

    Public Event e_cambia_texto(ByVal texto As String)

    Public imagenes_ruta As String              'ruta raiz del lote 
    Dim imagen_visualizada_ruta As String       'ruta de la imagen que se esta visualizando 

    Dim documento_id As Integer
    Dim documento_cambio As Boolean
    Dim teclas_marcarIncidencias As DataTable
    Dim incidencias_tipo As String = "DIGI"
    'Dim imagen_rotada As Boolean

    Public dt_documentos As DataTable

    Dim documentos_incidencia As clsRegistrosRojos

    Dim imagen_ruta_actual As String

    Dim tmpTemporal As String = "C:\temp\tmp.tif"

    'Aplicaciones residentes
    Dim WithEvents aplicacion_diseno As Process
    Dim WithEvents aplicacion_scan As Process


    Sub cerrado() Handles aplicacion_diseno.Exited, aplicacion_scan.Exited
        ' MsgBox("Salio aplicacion")
        bloquearTodo(True)
        imagen_muestra(imagenes_ruta & "\" & grdDocumentos.CurrentRow.Cells("NomArchivo").Value.ToString) 'cargamos la imagen correspondiente al registro 
    End Sub


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

        CheckForIllegalCrossThreadCalls = False

        Call inicializarDatos()
        'En la carga inicial comprobamos si hay que girar algunas fotos, en el caso de que haya

    End Sub

    Private Sub inicializarDatos()

     
        Dim servicio As LibreriaCadenaProduccion.Entidades.ClsServicio

        PictureBox1.Image = tmpTemporal
        documentos_incidencia = New clsRegistrosRojos

        Try
            'ponemos el numero del lote
            Me.Text = Me.Text & "- Lote " & frmContenedorMDI.oLote._nombreCompleto

            'obtenemos el codigo de las incidencias y el codigo de la tecla asociada
            teclas_marcarIncidencias = accesoDatos.ejecutarSQLDirecta("select idincidencia Codigo, codigoAscii,descripcion from tiposincidencias where codigoAscii is not null and tipo = '" & incidencias_tipo & "'", frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto).Tables(0)

            'poner la cadena de teclas de acceso rapido 
            Dim cadenaTeclasAccesoRapido As String = "F1  Rotar Imágen; F2 y ""+/-"" Zoom; F5 y ""+/-"" Brillo;F6 y ""+/-"" Contraste; Esc para salir todos los modos"
            RaiseEvent e_cambia_texto(cadenaTeclasAccesoRapido)

            'obtener la ruta de las imagenes del lote 
            imagenes_ruta = accesoDatosProduccion.ObtenerRutaImagenes(frmContenedorMDI.oProyecto._CodigoProyecto, _
                                    frmContenedorMDI.oLote._idlote, My.Settings.cadenaConexion)

            grdDocumentos.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige


         
        
            fnc_actualizaGrid()


            'Incializamos las aplicaciones 
            aplicacion_diseno = New Process
            aplicacion_scan = New Process

            aplicacion_diseno.EnableRaisingEvents = True
            aplicacion_scan.EnableRaisingEvents = True

            'obtiene el nuemero de incidencias, registros en rojo, existentes 
            If documentos_incidencia.RowCount > 0 Then
                'selecciona el primer indice del vector de indices de registros en rojo (incidencias )
                'el vector que contiene los indices se llama rojos y esta dentro de la clase documentos_incidencia
                documentos_incidencia.indice_situa(0)

                'seleccionamos el registro del datagrid correspindiente a la coleccion de indices de rojos
                'y lo seleccionamos 
                Dim busqueda As System.Collections.Generic.List(Of DataGridViewRow) = (From grid As DataGridViewRow In grdDocumentos.Rows Where grid.Cells("ID").Value.ToString = documentos_incidencia.indice_campo("ID")).ToList
                If busqueda.Count > 0 Then
                    grdDocumentos.CurrentCell = busqueda(0).Cells(0)
                End If
                moverRegistro(-1)
            End If

            'actualiza el grid con la consulta 

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

            dt_documentos = accesoDatos.ejecutarSQLDirecta(consultaSQL, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto).Tables(0)
            grdDocumentos.DataSource = dt_documentos

            Me.Text = frmContenedorMDI.Text & frmContenedorMDI.oLote._nombreCompleto & " Número Documentos " & dt_documentos.Rows.Count.ToString


            'Columnas visibles

            grdDocumentos.Columns("id_lote").Visible = True
            grdDocumentos.Columns("id_lote").Width = "40"

            grdDocumentos.Columns("Pagina").Visible = True
            grdDocumentos.Columns("Pagina").Width = "40"

            grdDocumentos.Columns("eliminada").Visible = True
            grdDocumentos.Columns("eliminada").Width = "30"

            grdDocumentos.Columns("NomArchivo").Visible = True
            grdDocumentos.Columns("NomArchivo").Width = "83"

            grdDocumentos.Columns("NHC").Visible = True
            grdDocumentos.Columns("NHC").Width = "60"

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
            grdDocumentos.Columns("Descripcion").Width = "60"

            'Columnas ocultas
            grdDocumentos.Columns("BarcodeDet").Visible = False

            grdDocumentos.Columns("Corregida").Visible = False

            grdDocumentos.Columns("Codigo").Visible = False


            'Asignamos propiedades a las columnas y tamaños
            If grdDocumentos.Columns.Count - 1 > 0 Then
                For i As Integer = 0 To grdDocumentos.Columns.Count - 1
                    grdDocumentos.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                Next
            End If

            If grdDocumentos.RowCount > 0 Then

                documentos_incidencia.reincio((From elemento As DataRow In dt_documentos.Rows Where elemento.Item("Incidencia").ToString = "1" AndAlso elemento.Item("corregidoDigi").ToString <> "1").ToList)

                'Mandamos el foco al registro
                If registroId <= grdDocumentos.RowCount - 1 Then
                    grdDocumentos.CurrentCell = grdDocumentos.Item(0, registroId)
                Else
                    grdDocumentos.CurrentCell = grdDocumentos.Item(0, 0)
                End If
                imagen_muestra(imagenes_ruta & "\" & grdDocumentos.CurrentRow.Cells("NomArchivo").Value.ToString) 'cargamos la imagen correspondiente al registro 
                btnEliminar.Enabled = True
            Else

                btnEliminar.Enabled = False
                PictureBox1.ClearDisplay()
                'Mostramos imagen
                'fnc_seleccionRegistro()
                Me.grdDocumentos.Focus()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try

    End Sub


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
                    ElseIf theRow.Cells("barcodedet").Value.ToString = "1" Then
                        theRow.DefaultCellStyle.BackColor = Color.LightGreen
                    ElseIf theRow.Cells("Corregida").Value.ToString = "1" Then
                        theRow.DefaultCellStyle.BackColor = Color.LightBlue
                    ElseIf theRow.Cells("eliminada").Value.ToString = "1" Then
                        theRow.DefaultCellStyle.BackColor = Color.DarkBlue
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try

    End Sub

    ''' <summary>
    ''' Esta funcion arranca un ejecutable asociado a un proceso o lo para
    ''' </summary>
    ''' <param name="proceso"></param>
    ''' <param name="arrancado"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function proceso_arrancar(ByRef proceso As Process, ByVal arrancado As Boolean, ByVal rutaEjecutable As String, Optional ByVal argumentos As String = "")
        'Si lo arrancan

        If arrancado Then
            Dim ifile As New FileInfo(rutaEjecutable)
            Dim abrir As Boolean = False
            If ifile.Exists Then
                Try
                    If Not proceso.HasExited Then
                        'Cerramos la aplicacion si se encuentra abierta
                        If MsgBox("Se ha detectado la aplicacion abierta, desea cerrarla?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Atención") = MsgBoxResult.Yes Then

                            Try
                                'aplicacion_diseno.Close()
                                proceso.CloseMainWindow()
                            Catch ex As Exception
                            End Try
                            abrir = True
                        Else
                            proceso.StartInfo.WindowStyle = ProcessWindowStyle.Maximized
                        End If
                    Else
                        abrir = True
                    End If

                Catch ex As Exception
                    abrir = True
                End Try

                If abrir Then

                    If argumentos <> "" Then proceso.StartInfo.Arguments = argumentos

                    proceso.StartInfo.WorkingDirectory = ifile.Directory.FullName
                    proceso.StartInfo.FileName = rutaEjecutable
                    proceso.Start()
                End If

            Else
                MsgBox("Se ha eliminado de la ruta el programa, seleccione otro en el menu de configuracion de aplicacion", MsgBoxStyle.Critical, "Incidencia de aplicación")
            End If

            'Devuelve si lo ha abierto
            Return abrir
        Else

            Try
                'aplicacion_diseno.Close()
                proceso.CloseMainWindow()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End If


    End Function

    Private Sub grdDocumentos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdDocumentos.KeyDown
        e.Handled = True

        Select Case e.KeyCode
            '*******************************************
            'TODO: control del desplazamiento de los registros 
            '*******************************************
            Case Keys.Up
                moverRegistro(0)
            Case Keys.Down
                moverRegistro(1)

                '*******************************************

            Case Keys.Home
                moverRegistro(4)
            Case Keys.End
                moverRegistro(5)
            Case Keys.PageUp
                moverRegistro(2)
            Case Keys.PageDown
                moverRegistro(3)

            Case Keys.M

                'Mover Registro
                fnc_registro_mover()

            Case Keys.C

                If Not IO.Directory.Exists(My.Settings.RutaDescargaImagenes) Then
                    MsgBox("No existe la ruta seleccionada, por favor reconfigurela en la  configuración", MsgBoxStyle.Critical, "Incidencia de aplicación")
                Else

                    Dim origen As String = imagenes_ruta & "\" & grdDocumentos.CurrentRow.Cells("NomArchivo").Value.ToString
                    Dim destion As String = My.Settings.RutaDescargaImagenes & "\" & grdDocumentos.CurrentRow.Cells("NomArchivo").Value.ToString
                    If Not IO.File.Exists(origen) Then
                        MsgBox("No existe la imagen en la ruta seleccionada", MsgBoxStyle.Critical, "Incidencia de aplicación")
                    Else
                        Try
                            If IO.File.Exists(destion) Then
                                If MsgBox("El fichero ya existe en la ruta destino, desea sobreescribirlo?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Atención") = MsgBoxResult.Yes Then
                                    IO.File.Delete(destion)
                                    IO.File.Copy(origen, destion)
                                End If
                            Else
                                IO.File.Copy(origen, destion)
                            End If
                        Catch ex As Exception
                            MsgBox("Incidencia copiando imagen localmente: " & ex.Message, MsgBoxStyle.Critical, "Incidencia de aplicacion")
                        End Try
                    End If
                End If
            Case Keys.F5

                If grdDocumentos.CurrentRow IsNot Nothing Then
                    fnc_actualizaGrid(grdDocumentos.CurrentRow.Index)
                Else
                    fnc_actualizaGrid()
                End If

            Case Keys.Insert
                fnc_registro_anadir(2)
            Case Keys.Delete
                'If grdDocumentos.CurrentRow IsNot Nothing Then

                '    'comprueba que hay una imagen asociada a cada una de las imagenes 
                '    Dim paginaErronea As Integer = fnc_imagenes_comprueba(dt_documentos, imagenes_ruta, grdDocumentos.CurrentRow.Index)

                '    'Si la comprobación de imagenes es correcta
                '    If paginaErronea = -1 Then
                '        bloquearTodo(False)

                '        fnc_registro_eliminar()
                '        bloquearTodo(True)
                '        grdDocumentos.Focus()
                '    Else
                '        MsgBox("La página " & dt_documentos(paginaErronea).Item("pagina").ToString & " no tiene imágen, revísela", MsgBoxStyle.Critical, "Incidencia de aplicacion")
                '        'Situamos el registro en la pagina que da error
                '        grdDocumentos.CurrentCell = grdDocumentos.Item(0, paginaErronea)
                '        imagen_muestra(imagenes_ruta & "\" & grdDocumentos.CurrentRow.Cells("NomArchivo").Value.ToString) 'cargamos la imagen correspondiente al registro 
                '    End If


                'End If
                accesoDatosDocumentos.EliminarDocumento(frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto, dt_documentos.Rows(grdDocumentos.CurrentRow.Index).Item("id_lote").ToString, dt_documentos.Rows(grdDocumentos.CurrentRow.Index).Item("pagina").ToString)
                fnc_actualizaGrid(grdDocumentos.CurrentRow.Index)

            Case Keys.S
                        bloquearTodo(False)
                        proceso_arrancar(aplicacion_scan, True, My.Settings.rutaAplicacionEscaner, "/one /scan /convert=" & imagenes_ruta & "\" & grdDocumentos.CurrentRow.Cells("NomArchivo").Value.ToString)
            Case Keys.Enter
                        If grdDocumentos.CurrentRow IsNot Nothing Then
                            Dim consultaSQL As String
                    consultaSQL = "UPDATE documentos SET corregidoDigi=case isnull(corregidoDigi,0) WHEN 1 THEN 0 ELSE 1 END where IDdocumento='" & grdDocumentos.CurrentRow.Cells("ID").Value & "'"
                    accesoDatos.ejecutaSQLEjecucion(consultaSQL, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto)
                            fnc_actualizaGrid(grdDocumentos.CurrentRow.Index)
                        End If
            Case Keys.E
                        bloquearTodo(False)
                        proceso_arrancar(aplicacion_diseno, True, My.Settings.RutaEjecutableRetoque, imagenes_ruta & "\" & grdDocumentos.CurrentRow.Cells("NomArchivo").Value.ToString)
            Case 96
                        'Desmarcar
                        accesoDatosDocumentos.DesmarcarInicidencia(dt_documentos.Rows(grdDocumentos.CurrentRow.Index).Item("ID").ToString, My.Settings.cadenaConexion, frmContenedorMDI.oProyecto._NombreBaseDatos)
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

            Case 107
                        'Girar documento
                        If grdDocumentos.CurrentRow IsNot Nothing Then imagen_rota()
            Case Keys.F
                        'FIP - Editar
                        If grdDocumentos.CurrentRow IsNot Nothing Then
                            Dim pantalla As New frmEdicionFip(grdDocumentos.CurrentRow.Cells("Hospital").Value, grdDocumentos.CurrentRow.Cells("NHC").Value)
                            pantalla.ShowDialog()
                            'Refrescamos la grid
                            fnc_actualizaGrid(grdDocumentos.CurrentRow.Index)
                        End If
            Case Else
                        'MARCAR INCIDENCIA 
                        'Buscamos si la tecla se encuentra en los tipos de errores
                        'Si la encuentra lanzamos la funcion
                        If grdDocumentos.CurrentRow IsNot Nothing Then
                            accesoDatosDocumentos.MarcarIndidenciaDocumento(CInt(e.KeyCode), dt_documentos.Rows(grdDocumentos.CurrentRow.Index).Item("ID").ToString, teclas_marcarIncidencias, My.Settings.cadenaConexion, incidencias_tipo, frmContenedorMDI.oProyecto._NombreBaseDatos)
                            fnc_actualizaGrid(grdDocumentos.CurrentRow.Index)
                        End If

        End Select
    End Sub

    ''' <summary>
    ''' Movimiento de registro en la grid, este se llama desde el grdDocumentos_keydown para desplazarnos 
    ''' hasta el siguiente registro 
    ''' </summary>
    ''' <param name="direccion">si direccion = 1 up si direccion = 0 down </param>
    ''' <remarks> </remarks>
    Sub moverRegistro(ByVal direccion As Integer)

        Dim busqueda As System.Collections.Generic.List(Of DataGridViewRow)


        'El registro puede moverse arriba o abajo, segun el indice
        If grdDocumentos.CurrentRow IsNot Nothing Then

            'para indicar si existe un registro "rojo" que le preceda en la lista de "rojos", 
            'con incidencia en el sentido de la direccion seleccionada 0 down y 1 up, si no 
            'lo hay no nos podemos desplazar y el cursor se queda parado

            If documentos_incidencia.indice_mover(direccion) Then

                If direccion = -1 Then 'caso en el que pinchamos con el raton 

                    'Si ha pinchado en el caso de que sea rojo , situamos el indice rojo en el correspondiente
                    If grdDocumentos.CurrentRow.Cells("Incidencia").Value.ToString = "1" Then
                        Dim tmp As System.Collections.Generic.List(Of DataRow) = documentos_incidencia.registro_buscaID(grdDocumentos.CurrentRow.Cells("ID").Value.ToString)
                        'Si lo encuentra
                        If tmp.Count > 0 Then
                            Dim nuevoIndiceRojo As Integer = documentos_incidencia.indice_busca(tmp(0))
                            If nuevoIndiceRojo >= 0 Then documentos_incidencia.indice_situa(nuevoIndiceRojo)
                        End If

                    End If

                Else 'caso en el que estamos pulsando una tecla 

                    'seleccionamos el registro del datagrid correspindiente a la coleccion de rojos
                    'y lo seleccionamos 
                    busqueda = (From grid As DataGridViewRow In grdDocumentos.Rows Where grid.Cells("ID").Value.ToString = documentos_incidencia.indice_campo("ID")).ToList
                    If busqueda.Count > 0 Then
                        grdDocumentos.CurrentCell = busqueda(0).Cells(0)
                    End If

                End If

            End If

            'se muestra aqui pq si no encuentra nada estamos en el caso de seleccionamos registro 
            'con el raton y no con una tecla 
            imagen_muestra(imagenes_ruta & "\" & grdDocumentos.CurrentRow.Cells("NomArchivo").Value.ToString) 'cargamos la imagen correspondiente al registro 
            fnc_rellenaPanelDatosCodigoBarras()
        End If

    End Sub



    Private Sub grdDocumentos_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles grdDocumentos.MouseClick
        moverRegistro(-1)
    End Sub

#End Region


#Region "Tratamiento de la imagen "

    Sub imagen_muestra(ByVal ruta As String)

        Try
            If IO.File.Exists(ruta) Then

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

            Else
                MessageBox.Show("No se ha encontrado la imagen en la ruta solicitada ")
                PictureBox1.ClearDisplay()
            End If

            'End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Incidencia de aplicacion")
        End Try



    End Sub

    Function imagen_rota() As Boolean
        'imagen_rotada = True
        Try

            PictureBox1.RotateRight()
            PictureBox1.Save()
            PictureBox1.FitTo(0)
            If accesoDatosDocumentos.AtualizarEstadoDocumentoGirado(dt_documentos.Rows(grdDocumentos.CurrentRow.Index).Item("ID").ToString(), frmContenedorMDI.oUsuario._login, My.Settings.cadenaConexion, frmContenedorMDI.oProyecto._NombreBaseDatos) Then
                'actulizamos el datagrid con valor 1 para que se vea que se ha girado 
                dt_documentos.Rows(grdDocumentos.CurrentRow.Index).Item("girado") = "1"
                dt_documentos.Rows(grdDocumentos.CurrentRow.Index).Item("Corregida") = "1"
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Incidencia de aplicacion")
        End Try

    End Function


#End Region

    ''' <summary>
    ''' Rellenamos el registro que estamos visualizando
    ''' </summary>
    ''' <remarks></remarks>
    Sub fnc_rellenaPanelDatosCodigoBarras()

        Dim servicio As LibreriaCadenaProduccion.Entidades.ClsServicio

        'Sólamente si existen registros y existe el cell seleccionado
        If grdDocumentos.RowCount > 0 Then

            If grdDocumentos.CurrentRow IsNot Nothing Then
                pnl_registro.Enabled = True
            Else
                pnl_registro.Enabled = False
            End If

            'Dim registroactual As DataRow  = 
            'Rellenamos los campos correspondientes al registro seleccionado 
            Try

                Me.txtNHC.Text = grdDocumentos.CurrentRow.Cells("NHC").Value.ToString()
                ' Me.txtNumIcu.Text = grdDocumentos.CurrentRow.Cells("ICU").Value.ToString()
                ' Me.txtFechaInicio.Text = Format(grdDocumentos.CurrentRow.Cells("Fechainicio").Value, "dd/MM/yyyy")
                ' Me.txtFechaFin.Text = Format(grdDocumentos.CurrentRow.Cells("Fechatermino").Value, "dd/MM/yyyy")
                'Me.txtServicio.Text = grdDocumentos.CurrentRow.Cells("Servicio").Value.ToString()

                ''Me.cmbServicios.SelectedItem
                'For Each registro As DataRow In accesoDatos.ejecutarSQLDirectaTable("SELECT  [idServicio],[Abreviatura] FROM [produccionvgdiario].[dbo].[SERVICIOS] order by [Abreviatura]", frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto).Rows


                '    servicio = New LibreriaCadenaProduccion.Entidades.ClsServicio(registro.Item("idServicio"), registro.Item("Abreviatura"))
                '    Me.cmbServicios.Items.Add(servicio)

                '    If Trim(grdDocumentos.CurrentRow.Cells("servicio").Value) = servicio._codServicio Then
                '        Me.cmbServicios.SelectedItem = servicio
                '    End If

                'Next


            Catch ex As Exception
                MessageBox.Show("Falta alguno de los campos de indización.")
            End Try

        Else
            pnl_registro.Enabled = False
        End If

    End Sub


    Private Sub CtrlModificarPanelClick(ByVal sender As Object, ByVal e As System.EventArgs)
        'Salvamos la modificacion del registro

        'Dim dt As DataTable = accesoDatosDocumentos.GeneraDatatableDocumentos
        ''Generamos un datatable con los valores que vamos a modificar del documento, 
        ''en el datatable metemmos el par campo de la tabla documetnos valor a modificar para el registro correspondiente

        ''hay que mirar que los datos esten cumplimentados 


        ''Campo y nuevo valor
        'dt.Rows.Add("NumHistoria", txtNHC.Text)
        'dt.Rows.Add("NumIcu", txtNumIcu.Text)
        'dt.Rows.Add("CodServicioPaed", "'" & cmbServicios.SelectedItem._idservicio & "'")
        'dt.Rows.Add("FechaInicio", "'" & txtFechaInicio.Text & "'")
        'dt.Rows.Add("Fechatermino", "'" & txtfechaFin.Text & "'")

        ''If tipodocumento Then

        ''Convertimos el 1-0 del tipo de documento a la caratula
        'Dim caratula As Boolean = False
        'If grdDocumentos.CurrentRow.Cells("BarcodeDet").Value.ToString = "1" Then caratula = True

        'If caratula Then

        '    'en el caso de que sea una caratula podemos calcular el siguiente id con barcode det, actulizar los datos y volver al estado 
        '    'inicial 
        '    '       accesoDatosDocumentos.ActualizaCamposCaratula(My.Settings.cadenaConexion, oProyecto._CodigoProyecto, _
        '    '                                                      oLote._nombreCompleto


        'End If

        ''En el caso de que realize la actualizacion del documento se modifica la grid
        'If accesoDatosDocumentos.ActualizaCamposDocumento(frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto, grdDocumentos.CurrentRow.Cells("ID").Value.ToString, dt) Then

        '    'Dim valor As DBNull = Nothing

        '    'aqui hay que tner cuidado con las actualizaciones tener en cuenta el tipo para no tener excepciones 

        '    Try
        '        If txtNHC.Text <> "" Then
        '            dt_documentos.Rows(grdDocumentos.CurrentRow.Index).Item("NHC") = CInt(txtNHC.Text)
        '        Else
        '            dt_documentos.Rows(grdDocumentos.CurrentRow.Index).Item("NHC") = 0
        '        End If
        '        If txtNumIcu.Text <> "" Then
        '            dt_documentos.Rows(grdDocumentos.CurrentRow.Index).Item("ICU") = CInt(txtNumIcu.Text)
        '        Else
        '            dt_documentos.Rows(grdDocumentos.CurrentRow.Index).Item("ICU") = 0
        '        End If

        '        If txtFechaInicio.Text <> "" Then
        '            dt_documentos.Rows(grdDocumentos.CurrentRow.Index).Item("fechainicio") = txtFechaInicio.Text
        '        Else
        '            dt_documentos.Rows(grdDocumentos.CurrentRow.Index).Item("fechainicio") = 0
        '        End If

        '        If txtFechaInicio.Text <> "" Then
        '            dt_documentos.Rows(grdDocumentos.CurrentRow.Index).Item("fechaTermino") = txtfechaFin.Text
        '        Else
        '            dt_documentos.Rows(grdDocumentos.CurrentRow.Index).Item("fechaTermino") = 0
        '        End If

        '        If cmbServicios.Text <> "" Then
        '            dt_documentos.Rows(grdDocumentos.CurrentRow.Index).Item("Servicio") = cmbServicios.Text
        '        Else
        '            dt_documentos.Rows(grdDocumentos.CurrentRow.Index).Item("Servicio") = 0
        '        End If

        '    Catch ex As Exception
        '        MsgBox("Incidencia: " & ex.Message, MsgBoxStyle.Critical, "Incidencia de aplicacion")
        '    End Try



        'End If

        ''pasando de todo actulizamos los datos 
        'If grdDocumentos.CurrentRow IsNot Nothing Then
        '    fnc_actualizaGrid(grdDocumentos.CurrentRow.Index)
        'Else
        '    fnc_actualizaGrid()
        'End If

    End Sub



#Region "Botones de panel inferior"


    Private Sub cmdCerrarlote_click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim _frmSeleccionarlote As frmSeleccionProyecto
        Dim _frmVerificacion As frmCorreccion

        Try
            'accesoDatosLotes.CerrarLoteCorreccion(oProyecto._CodigoProyecto, oUsuario._login, oLote._nombreCompleto, oLote._TipoLote, oLote._FechaLote, My.Settings.cadenaConexion)
            'cerramos el lote  y damos opcion de seleccionar otro 

            frmContenedorMDI.oLote = Nothing
            _frmSeleccionarlote = New frmSeleccionProyecto
            _frmSeleccionarlote.ShowDialog()
            If frmContenedorMDI.oLote Is Nothing OrElse frmContenedorMDI.oProyecto Is Nothing Then
                'controlamos que no se salga del formulario de seleccion de lote 
                'sin seleccionar un lote
                Application.ExitThread()
                Exit Sub                'nos salimos sin seleccionar nada 
            End If

            _frmVerificacion = New frmCorreccion
            _frmVerificacion.Text = frmContenedorMDI.oProyecto._CodigoProyecto.ToString & " :: " & frmContenedorMDI.oProyecto._nombreProyecto.ToString & " Usuario: " & frmContenedorMDI.oUsuario._nombre.ToString

            With _frmVerificacion
                .MdiParent = frmContenedorMDI
                .WindowState = FormWindowState.Maximized
                .Show()
            End With

            'cerramos esta ventana 
            Me.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try

    End Sub


    'funcion generica para insertar en funcion del paramentro tipo inicia proceso de insercion de plantilla o 
    'de document 
    Sub fnc_registro_anadir(ByVal tipo As frmInsercionDocumento.tipoInsercion)

        ' If grdDocumentos.CurrentRow IsNot Nothing Then
        'insercion tipo documento 
        Dim ventana As New frmInsercionDocumento(Me, tipo)
        ventana.ShowDialog()


        'Actualizamos la grid por prosibles cambios y situamos en
        If grdDocumentos.CurrentRow IsNot Nothing Then
            fnc_actualizaGrid(grdDocumentos.CurrentRow.Index)
        Else
            fnc_actualizaGrid()
        End If
    End Sub


    ''' <summary>
    ''' Funcion para comprobar si todas las imagenes existen 
    ''' </summary>
    ''' <param name="pagina"></param>
    ''' <returns>i el numero de la pagina que no tiene documento
    ''' -2 con esto indicamos que no hay documentos 
    ''' -1 no se ha producido un error 
    ''' </returns>
    ''' <remarks></remarks>
    Public Function fnc_imagenes_comprueba(ByRef dt_documentos As DataTable, ByVal imagenes_ruta As String, Optional ByVal pagina As Integer = 0) As Integer

        If pagina <= dt_documentos.Rows.Count - 1 AndAlso pagina >= 0 Then
            For i As Integer = pagina To dt_documentos.Rows.Count - 1
                If Not IO.File.Exists(imagenes_ruta & "\" & dt_documentos(i).Item("NomArchivo").ToString()) Then
                    'Situamos en la cell correspondiente
                    grdDocumentos.CurrentCell = grdDocumentos.Item(0, i)
                    'Situamos el registro en la pagina que da error
                    imagen_muestra(imagenes_ruta & "\" & grdDocumentos.CurrentRow.Cells("NomArchivo").Value.ToString) 'cargamos la imagen correspondiente al registro 
                    Return i 'el numero de la pagina que no tiene documento
                End If
            Next

        Else
            Return -2 ' con esto indicamos que no hay documentos 
        End If
        'No ha cumplido las condiciones, para que se de un error existen imagenes para todos los registros 
        Return -1

    End Function

    'isertar documento 
    Private Sub cmdAnyadir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bntAnyadir.Click

        Dim numpagina As Integer

        If grdDocumentos.CurrentRow IsNot Nothing Then
            'Si la comprobación de imagenes es correcta

            numpagina = fnc_imagenes_comprueba(dt_documentos, imagenes_ruta, grdDocumentos.CurrentRow.Index)

            If numpagina = -1 Then
                fnc_registro_anadir(frmInsercionDocumento.tipoInsercion.Documento)
            Else
                MessageBox.Show("Hay documentos sin imagenes asociadas." & numpagina, "Alerta")
            End If

        End If

    End Sub

    Sub fnc_registro_mover()
        Dim msg As String = InputBox("Seleccione la página donde desea mover el documento seleccionado", "Mover documento")
        If msg = "" Then
            MsgBox("Selecciono cancelar")
        Else
            MsgBox(msg)
            'Primero sacamos cual de los dos numeros es mas bajo para empezar la 
            ' comprobación de que todas las imagenes existen



        End If
    End Sub

    'eliminar 
    Sub fnc_registro_eliminar()

        If MsgBox("Desea realmente eliminar el documento?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Atención") = MsgBoxResult.Yes Then
            If grdDocumentos.CurrentRow IsNot Nothing Then 'Comprobamos que esté alguna fila seleccionada
                Dim docs As System.Collections.Generic.List(Of DataRow)
                docs = (From documento As DataRow In dt_documentos Where CInt(documento.Item("pagina")) > grdDocumentos.CurrentRow.Cells("pagina").Value.ToString Order By CInt(documento.Item("pagina")) Ascending).ToList

                operacionesDigi.documento_eliminacion(frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto, frmContenedorMDI.oProyecto._NombreBaseDatos, Me.pgOperaciones, frmContenedorMDI.oProyecto._CodigoProyecto, frmContenedorMDI.oLote._idlote, grdDocumentos.CurrentRow.Cells("pagina").Value.ToString, imagenes_ruta, docs)
                If grdDocumentos.CurrentRow.Index < grdDocumentos.RowCount - 1 Then
                    fnc_actualizaGrid(grdDocumentos.CurrentRow.Index)
                Else
                    fnc_actualizaGrid()
                End If


            End If
        End If

    End Sub

    Sub fnc_registro_sustituir()
        operacionesDigi.documento_sustitucion(My.Settings.cadenaConexion, frmContenedorMDI.oProyecto._CodigoProyecto, frmContenedorMDI.oLote._nombreCompleto, grdDocumentos.CurrentRow.Cells("pagina").Value.ToString, imagenes_ruta)
    End Sub

    Sub bloquearTodo(ByVal aceptar As Boolean)
        grdDocumentos.Enabled = aceptar
        pnl_registro.Enabled = aceptar
        GroupBox1.Enabled = aceptar
        GroupBox2.Enabled = aceptar
        GroupBox4.Enabled = aceptar
        PictureBox2.Enabled = aceptar
    End Sub

    Private Sub cmbEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click

        ''Comprobamos que existan las imagenes 

        'If grdDocumentos.CurrentRow IsNot Nothing Then

        '    'comprueba que hay una imagen asociada a cada una de las imagenes 
        '    Dim paginaErronea As Integer = fnc_imagenes_comprueba(dt_documentos, imagenes_ruta, grdDocumentos.CurrentRow.Index)

        '    'Si la comprobación de imagenes es correcta
        '    If paginaErronea = -1 Then
        '        bloquearTodo(False)
        '        fnc_registro_eliminar()
        '        bloquearTodo(True)
        '        grdDocumentos.Focus()
        '    Else
        '        MsgBox("La página " & dt_documentos(paginaErronea).Item("pagina").ToString & " no tiene imágen, revísela", MsgBoxStyle.Critical, "Incidencia de aplicacion")
        '        'Situamos el registro en la pagina que da error
        '        grdDocumentos.CurrentCell = grdDocumentos.Item(0, paginaErronea)
        '        imagen_muestra(imagenes_ruta & "\" & grdDocumentos.CurrentRow.Cells("NomArchivo").Value.ToString) 'cargamos la imagen correspondiente al registro 
        '    End If


        'End If
        accesoDatosDocumentos.EliminarDocumento(frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto, dt_documentos.Rows(grdDocumentos.CurrentRow.Index).Item("id_lote").ToString, dt_documentos.Rows(grdDocumentos.CurrentRow.Index).Item("pagina").ToString)
        fnc_actualizaGrid(grdDocumentos.CurrentRow.Index)

    End Sub


    Private Sub cmdSustituir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSustituir.Click

        fnc_registro_sustituir()
        imagen_muestra(imagenes_ruta & "\" & grdDocumentos.CurrentRow.Cells("NomArchivo").Value.ToString)
    End Sub

    Private Sub btnSig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSig.Click
        moverRegistro(1)
    End Sub

    Private Sub btnAnt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnt.Click
        moverRegistro(0)
    End Sub

#End Region

    Private Sub CtrlCerrarlote_eClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles CtrlBotonGrande1.eClick

        'Dim strSQLpruebas As String
        'Dim strSQLpruebasdiglot As String
        'Dim strSQLcprobIndz As String
        'Dim strSQLcontpaginas As String
        'Dim datosComprobaciones As DataTable = Nothing
        'Dim datosComprobacionesDigLot As DataTable = Nothing
        'Dim datosNumpaginas As DataTable = Nothing
        'Dim paginasNoindizadas As DataTable = Nothing
        'Dim _frmAviso As frmAviso
        Dim strSQLnhcProvisionales As String
        Dim datosNhcProvisionales As DataTable = Nothing
       
        Try

            'comprobar que los documentos estan indizados 
            'strSQLcprobIndz = "Select Pagina FROM DOCUMENTOS WHERE (NumHistoria IS NULL) OR (FechaInicio IS NULL)  OR (NumIcu IS NULL)"
            ' Debug.Print(strSQLcprobIndz)

            ''comprobar que el loteado y lo digitalizado se corresponden 
            'strSQLpruebas = "SELECT NumHistoria FROM FIP f "
            'strSQLpruebas &= "WHERE idlote = " & frmContenedorMDI.oLote._idlote & " and NOT EXISTS "
            'strSQLpruebas &= " (SELECT d.numhistoria FROM documentos d "
            'strSQLpruebas &= " WHERE d.numhistoria = f.numhistoria AND d.idlote = f.idlote)"
            'Debug.Print(strSQLpruebas)

            'strSQLpruebasdiglot = "Select NumHistoria  FROM DOCUMENTOS d "
            'strSQLpruebasdiglot &= "where idlote = " & frmContenedorMDI.oLote._idlote & " and NOT EXISTS "
            'strSQLpruebasdiglot &= " (SELECT f.numhistoria FROM fip f "
            'strSQLpruebasdiglot &= " WHERE d.numhistoria = f.numhistoria AND d.idlote = f.idlote)"

            'comprobar que el numero de documentos contados y digitalizados son correctos 


            'strSQLcontpaginas = "SELECT DISTINCT D.NumHistoria,(SELECT COUNT(*) "
            'strSQLcontpaginas &= " FROM documentos d1 WHERE d1.idlote = d.idlote AND d1.numhistoria = d.numhistoria) AS documentos, f.NumDocs "
            'strSQLcontpaginas &= " FROM DOCUMENTOS D INNER JOIN"
            'strSQLcontpaginas &= " FIP f ON D.idlote = f.idlote AND D.NumHistoria = f.NumHistoria "
            'strSQLcontpaginas &= " WHERE (D.idlote = " & frmContenedorMDI.oLote._idlote & ") AND (f.NumDocs <> "
            'strSQLcontpaginas &= "(SELECT COUNT(*) FROM documentos d1 "
            'strSQLcontpaginas &= " WHERE d1.idlote = d.idlote AND d1.numhistoria = d.numhistoria))"



            'paginasNoindizadas = accesoDatos.ejecutarSQLDirectaTable(strSQLcprobIndz, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto)
            'datosComprobaciones = accesoDatos.ejecutarSQLDirectaTable(strSQLpruebas, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto)
            'datosComprobacionesDigLot = accesoDatos.ejecutarSQLDirectaTable(strSQLpruebasdiglot, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto)
            'datosNumpaginas = accesoDatos.ejecutarSQLDirectaTable(strSQLcontpaginas, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto)

            ' If paginasNoindizadas.Rows.Count > 0 Then

            'se ha dado el caso de que hay la misma historia servicio y fechas distintas dentro del mismo lote 
            ' _frmAviso = New frmAviso(datosComprobaciones, paginasNoindizadas, datosComprobacionesDigLot, datosNumpaginas)
            '  _frmAviso.ShowDialog()


            ' Exit Sub ' no permitimos que se cierre el lote 

            'End If

            '17/06/2016 - DIEGO - EN CASO DE QUE EN EL LOTE HAYA NHCs PROVISIONALES
            ' HAGO LA TRADUCCIÓN DE LA TABLA FUSIONES A LOS NÚMEROS DE HISTORIA DEFINITIVOS
            strSQLnhcProvisionales = "select * from fusiones where exists (select numhistoria from documentos where idlote = " & _
            frmContenedorMDI.oLote._idlote & " and documentos.numhistoria = fusiones.nhcprovis)"

            datosNhcProvisionales = accesoDatos.ejecutarSQLDirectaTable(strSQLnhcProvisionales, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto)
            For Each row As DataRow In datosNhcProvisionales.Rows
                accesoDatos.ejecutaSQLEjecucion("update documentos set numhistoria = " & row.Item("nhcdef") & _
                                                " where idlote = " & frmContenedorMDI.oLote._idlote & " and numhistoria = " & row.Item("nhcprovis"), frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto)
            Next

            If accesoDatosLotes.CerrarLoteCorreccionDIGI(frmContenedorMDI.oUsuario._login, frmContenedorMDI.oLote._idlote, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto) = 0 Then
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

    Private Sub PictureBox1_MouseUpEvent(ByVal sender As Object, ByVal e As AxImgeditLibCtl._DImgEditEvents_MouseUpEvent) Handles PictureBox1.MouseUpEvent
        If e.button = 1 Then
            ' MsgBox("Boton izquierdo")
            'Seleeccionado el area de zoom 

            'AMPLIO LA IMAGEN
            'PictureBox1.Zoom = 10
            'PictureBox1.Display()
            'PictureBox1.DrawSelectionRect(, arr, anc, alt)

            'PictureBox1.DrawSelectionRect(0, 0, 0, 0) 'PARA BORRAR EL CUADRADO
            'ZoomAnterior = Me.ImgEditAmpliacion.Zoom
            PictureBox1.ZoomToSelection()
            PictureBox1.DrawSelectionRect(0, 0, 0, 0)
            'PictureBox1.Refresh()
            'PictureBox1.Display()
        ElseIf e.button = 2 Then
            PictureBox1.FitTo(0)
            PictureBox1.Display()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click


        Dim respuesta As String = InputBox("Reasigne el nuevo numero de pagina al documento seleccionado", "Mover documento seleccionado")
        If respuesta <> "" Then
            If IsNumeric(respuesta) Then
                'Esta funcion realiza primero un proceso de borrado de registro
                'Que se guarda previamente, luego realiza la inserción 


            Else
                MsgBox("El valor introducido no es un valor numerico correcto", MsgBoxStyle.Critical, "Incidencia de aplicación")
            End If

        Else
            MsgBox("Debe de escribir un nuevo numero de página para el documento", MsgBoxStyle.Critical, "Incidencia de aplicación")
        End If

    End Sub


    Private Sub CtrlModificarRango_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CtrlBotonPequenyo2.eClick

        Dim _frmModificarRango As New frmModificarRango(dt_documentos.Rows(grdDocumentos.CurrentRow.Index).Item("pagina"), dt_documentos.Rows(grdDocumentos.CurrentRow.Index).Item("id_lote"))
        _frmModificarRango.ShowDialog()

        If grdDocumentos.CurrentRow IsNot Nothing Then
            fnc_actualizaGrid(grdDocumentos.CurrentRow.Index)
        Else
            fnc_actualizaGrid()
        End If


    End Sub



    Private Sub pnl_registro_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnl_registro.Enter

    End Sub

    Private Sub CtrlBotonPequenyo2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CtrlBotonPequenyo2.Load

    End Sub

    Private Sub pnl_registro_Layout(ByVal sender As Object, ByVal e As System.Windows.Forms.LayoutEventArgs) Handles pnl_registro.Layout

    End Sub
End Class
