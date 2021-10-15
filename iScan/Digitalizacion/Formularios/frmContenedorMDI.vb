Imports Datos = libreriacadenaproduccion.Datos.GeneralSQL.clsAccesoDatosSQL
Imports DatosMDB = libreriacadenaproduccion.Datos.GeneralAccess.ClsAccesoDatosAccess
Imports datosPlana = LibreriaCadenaProduccion.Datos.Produccion.Plana.AccesoDatosProduccionPlana
Imports System.IO
Imports AccesoDAtosProd = LibreriaCadenaProduccion.Datos.Produccion.clsAccesoDatosProduccion
Imports AccesoDAtos = LibreriaCadenaProduccion.Datos.GeneralSQL.clsAccesoDatosSQL
Imports accesoDatosLote = LibreriaCadenaProduccion.Datos.Produccion.cadenaproduccion.clsAccesoDatosLote
Imports LibreriaCadenaProduccion.Configuracion

Imports Spring
Imports Spring.Context
Imports Spring.Context.Support

'Imports vg = Proyectogenerico.mdlVariablesGlobales


Public Class frmContenedorMDI



    Dim WithEvents aplicacion_scan As Process

    Private fechaFinLicencia As DateTime

    Public Shared Sub main()

        Try


            'CARGAMOS EL FORMULARIO DE PRESENTACION.
            'Dim _Splash As New frmSplash
            Dim _Splash As New frmSplash
            Dim _frmPrincipal As New frmContenedorMDI


            'CARGAR CONFIGURACION DE LA APLICACION
            frmContenedorMDI.oSettings = New clsConfiguracion(Application.ExecutablePath & ".config")


            'SOLICITAR CLAVE VALIDAR USUARIO 
            If _Splash.ShowDialog() <> Windows.Forms.DialogResult.OK Then
                'si el resultado es diferente de DialogResult.OK es que el usuario no se ha validado correctamente 
                'y ha cerrado la pantalla de presentacion, por lo que no podemos dejar que inicie sesion 
                Application.Exit()
            Else

                'SELECCION DEL PROYECTO *******
                'si no se quiere seleccionar proyecto solo hay que comentar estas dos lineas 
                Dim _frmSeleccionProyecto As New frmSeleccionProyecto
                _frmSeleccionProyecto.StartPosition = FormStartPosition.CenterParent
                _frmSeleccionProyecto.ShowDialog()

                If frmContenedorMDI.oFuncionAplicacion <> Accion.administrar And frmContenedorMDI.oFuncionAplicacion <> Accion.crearcaratula And frmContenedorMDI.oFuncionAplicacion <> Accion.buscarpeticiones And frmContenedorMDI.oFuncionAplicacion <> Accion.preparar Then
                    If frmContenedorMDI.oProyecto Is Nothing OrElse frmContenedorMDI.oLote Is Nothing Then
                        Application.Exit()
                        Exit Sub
                    End If
                End If


                'SELECCION DEL LOTE - ASIGNACION AUTOMATICA *************
                'se seleccina el lote, en este caso para correccion 
                'Dim _frmSeleccionLote As New frm
                '_frmSeleccionLote.ShowDialog()
                'If IsNothing(frmContenedorMDI.oLote) Then
                '    Application.Exit()
                '    Exit Sub
                'End If


                'INICIO DE LA APLICACION *******
                'inicializamos la aplicacion, en estos momentos ya se ha creado el objeto usuario 
                'y se le ha pasado al formulario principal 

                _frmPrincipal.ShowDialog()


            End If

        Catch ex As Exception

            MessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()

        End Try



    End Sub

    'DECLARACION DE LAS VARIABLES GLOBALES ***************************************************************************

    Public Enum Accion
        digitalizar = 1
        verificar = 2
        corregir = 3
        indizar = 4
        corregirPAED = 5
        administrar = 6
        preparar = 7
        crearcaratula = 8
        buscarpeticiones = 9
    End Enum


    Public Shared oUsuario As LibreriaCadenaProduccion.Entidades.ClsUsuario
    Public Shared oSettings As LibreriaCadenaProduccion.Configuracion.clsConfiguracion
    Public Shared oProyecto As LibreriaCadenaProduccion.Entidades.clsProyecto
    Public Shared oDocumento As LibreriaCadenaProduccion.Entidades.ClsDocumento
    Public Shared oLote As LibreriaCadenaProduccion.Entidades.ClsLote
    Public Shared oFuncionAplicacion As Accion
    Public Shared numeroHojaMaxima As Integer        'esta es la ultima pagina a la que se ha accedido para indizar
    Dim WithEvents notifymnuItem As ToolStripMenuItem

    Private Sub frmContenedorMDI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus


    End Sub
    ' Dim ctx As IApplicationContext


    '******************************************************************************************************************



    Private Sub frmContenedorMDI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'crear la carpeta temporal 
        Dim directorio As New System.IO.DirectoryInfo("C:\temp")

        If Not directorio.Exists() Then
            directorio.Create()
        End If

        Call inicializarPrimerFormularioMostrar(frmContenedorMDI.oFuncionAplicacion)

        '********************************************************************************************************************
        ' Si la licencia no es correcta, iniciamos el timer con el mensaje tocawebs
        Me.TimerFinLicencia.Enabled = Not Me.comprobarLicencia()
    End Sub


    Public Sub inicializarPrimerFormularioMostrar(ByVal accion As frmContenedorMDI.Accion)
        'INICIALIZAR EL PIE DE PAGINA Y EL PRIMER FORMULARIO A MOSTRAR *************************************************
        Select Case accion

            Case accion.digitalizar 'digitalizar

                Me.Text = oProyecto._CodigoProyecto.ToString & " :: " & oProyecto._nombreProyecto.ToString & " Usuario: " & oUsuario._nombre.ToString

                seleccionadaUbicacionCliente = 0

                'Comprueba si el lote tiene posiciones, si las tiene, es que ya ha sido asignado a una ubicación del cliente y va directo a la digitalización
                'en caso contrato, muestra pantalla para relacionar ubicación
                If oLote._posiciones > 0 Then
                    seleccionadaUbicacionCliente = 2
                Else
                    frmPreparacion_ConsentInf.ShowDialog(Me)
                End If

                If seleccionadaUbicacionCliente > 0 Then    'Selecciona o continua sin seleccionar
                    Dim _frmDigitalizacion As New frmDigitalizacionTwain

                    With _frmDigitalizacion
                        .MdiParent = Me
                        .Show()
                        .WindowState = FormWindowState.Maximized
                    End With
                Else
                    'libera el lote seleccionado cuando ha pulsado cerrar el formulario
                    accesoDatosNuevos.clsAccesoDatosNUEVO.ejecutaSQLEjecucion("UPDATE LOTES SET Asignado=0 WHERE idLote=" & oLote._idlote, oProyecto._obtenerCadenaConexionProyecto,, False)
                End If

                '' ''Me.Text = oProyecto._CodigoProyecto.ToString & " :: " & oProyecto._nombreProyecto.ToString & " Usuario: " & oUsuario._nombre.ToString
                '' ''Dim _frmDigitalizacion As New frmDigitalizacion


                '' ''With _frmDigitalizacion
                '' ''    .MdiParent = Me
                '' ''    .WindowState = FormWindowState.Maximized
                '' ''    .Show()
                '' ''End With

                ' ''Dim rutaimagenes As String
                ' ''Dim numeroImagenesLote As Integer = 0


                ' ''rutaimagenes = AccesoDAtosProd.ObtenerRutaImagenes(frmContenedorMDI.oProyecto._CodigoProyecto, frmContenedorMDI.oLote._idlote, My.Settings.cadenaConexion)

                '' ''Me.Text = oProyecto._CodigoProyecto.ToString & " :: " & oProyecto._nombreProyecto.ToString & " Usuario: " & oUsuario._nombre.ToString
                '' ''Dim _frmScaner As New frmScaner(frmContenedorMDI.oProyecto._CodigoProyecto, frmContenedorMDI.oLote._idlote, frmContenedorMDI.oUsuario._id, rutaimagenes)


                '' ''With _frmScaner
                '' ''    .Text = "Lote " & oLote._idlote
                '' ''    .MdiParent = Me
                '' ''    .WindowState = FormWindowState.Maximized
                '' ''    .Show()
                '' ''End With
                '' ''rutaimagenes = AccesoDAtosProd.ObtenerRutaImagenes(frmContenedorMDI.oProyecto._CodigoProyecto, frmContenedorMDI.oLote._idlote, My.Settings.cadenaConexion)


                '' ''comprobar que la ruta existe 

                ' ''Dim mINI As New LibreriaCadenaProduccion.INI.clsIniArray
                ' ''mINI.IniWrite(My.Settings.pathArchivoConfigEscaner, "BatchScaning", "SaveDir", rutaimagenes)
                ' ''mINI.IniWrite(My.Settings.pathArchivoConfigEscaner, "Copy-Move", "SaveDir", rutaimagenes)
                ' ''mINI.IniWrite(My.Settings.pathArchivoConfigEscaner, "Open", "OpenDir", rutaimagenes)
                ' ''mINI.IniWrite(My.Settings.pathArchivoConfigEscaner, "Copy-Move", "CopyDir", rutaimagenes)
                '' ''mINI.IniWrite(My.Settings.pathArchivoConfigEscaner, "Open", "OpenDir", rutaimagenes)
                ' ''mINI.IniWrite(My.Settings.pathArchivoConfigEscaner, "Thumbnails", "MRUD1=", rutaimagenes)

                '' ''Incializamos las aplicaciones 
                ' ''aplicacion_scan = New Process

                ' ''With aplicacion_scan
                ' ''    .EnableRaisingEvents = True
                ' ''    .StartInfo.UseShellExecute = False
                ' ''    .StartInfo.WindowStyle = ProcessWindowStyle.Normal
                ' ''    .StartInfo.Arguments = "" '"/one /batchscan=(IML,1,1,5,1," & rutaimagenes & ",tif,0)"

                ' ''    .StartInfo.FileName = My.Settings.rutaAplicacionEscaner
                ' ''End With
                ' ''aplicacion_scan.Start()
                ' ''aplicacion_scan.WaitForExit()
                ' ''aplicacion_scan.Close()

                ' ''Dim counter = My.Computer.FileSystem.GetFiles(rutaimagenes, FileIO.SearchOption.SearchTopLevelOnly, "*.tif")

                ' ''MsgBox("La carpeta contiene " & CStr(counter.Count) & " imágenes.")

                '' ''preguntamos si quiere cerrar el lote al usuario, en caso afirmativo el lote se cerrara pasará a la 
                '' ''fase de importación, en caso negativo el usuario pasará a seleccionar un nuevo lote y el lote quedará 
                '' ''en la lista de lotes a digitalizar 
                ' ''If MessageBox.Show("Desea cerrar el lote  " & frmContenedorMDI.oLote._idlote & ". Si cierra el lote, éste pasará a la siguiente fase y no podrá continuar digitalizando documentos dentro del lote. En el caso contrario podrá seleccionarlo nuevamente para continuar con el proceso de digitalización.", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                ' ''    accesoDatosLote.CerrarLoteParaDigitalizar(frmContenedorMDI.oUsuario._login, frmContenedorMDI.oLote._idlote, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto)

                ' ''End If
                '' ''CerrarSesiónToolStripMenuItem_Click(Me, Nothing)

            Case accion.verificar 'verificar
                Me.Text = oProyecto._CodigoProyecto.ToString & " :: " & oProyecto._nombreProyecto.ToString & " Usuario: " & oUsuario._nombre.ToString
                Dim _frmVerificacion As New frmVerificacion


                With _frmVerificacion
                    .MdiParent = Me
                    .WindowState = FormWindowState.Maximized
                    .Show()
                End With

            Case accion.corregir 'corregir

                Me.Text = oProyecto._CodigoProyecto.ToString & " :: " & oProyecto._nombreProyecto.ToString & " Usuario: " & oUsuario._nombre.ToString
                Dim _frmCorreccion As New frmCorreccion


                With _frmCorreccion
                    .MdiParent = Me
                    .WindowState = FormWindowState.Maximized
                    .Show()
                End With

            Case accion.crearcaratula


                Dim _frmcrearcaratulas As New frmCrearCaratulas


                With _frmcrearcaratulas
                    .MdiParent = Me
                    .WindowState = FormWindowState.Maximized
                    .Show()
                End With

            Case accion.buscarpeticiones

                Dim _frmConsultarEstadosCartulas As New frmConsultarEstadosCartulas

                With _frmConsultarEstadosCartulas
                    .MdiParent = Me
                    .WindowState = FormWindowState.Maximized
                    .Show()
                End With



            Case accion.indizar

                'If (frmContenedorMDI.oProyecto._CodigoProyecto = My.Settings.codigoEpidemiologia) Then
                Dim _frmIndizacion As New frmIndizacionGeneral()
                With _frmIndizacion
                    .MdiParent = Me
                    .WindowState = FormWindowState.Maximized
                    .Show()
                End With

                'Else
                '    Me.Text = oProyecto._CodigoProyecto.ToString & " :: " & oProyecto._nombreProyecto.ToString & " Usuario: " & oUsuario._nombre.ToString
                '    Dim _frmIndizacion As New frmIndizacionCorreccion



                '    Dim nombreClasePanelIndizacion As String = "PanelIndizacionGeneral"

                '    If Not IsNothing(ctx) Then
                '        ctx.Dispose()
                '        ctx = Nothing
                '    End If

                '    ctx = ContextRegistry.GetContext()


                '    'MVC para el Panel

                '    'creamos el panel VISTA
                '    _frmIndizacion.PanelIndizacion = ctx.GetObject(nombreClasePanelIndizacion.ToString)

                '    'crear la varable operaciones panel MODELO
                '    Dim var_operacionesPanel As IoperacionesPanel = New clsOperacionesPanelGenerico()

                '    'crear el controlador del panel, esto tendria que ser una interfaz  CONTROLADOR
                '    Dim var_controladorPanel As IControladorPanel = New clsControladorPanel(_frmIndizacion.PanelIndizacion, var_operacionesPanel)

                '    'referencia del controlardor en el panel 
                '    _frmIndizacion.PanelIndizacion.controladorPanel = var_controladorPanel

                '    'inicializa el panel de indizacion 
                '    _frmIndizacion.PanelIndizacion.InicializaPanel()

                '    'MVC para el formulario 
                '    'crear la variable operaciones panel MODELO
                '    Dim var_opercionesFormulario As IoperacionesFormulario = New clsOperacionesFormularioIndizacion()

                '    'crear el controlador del panel, esto tendria que ser una interfaz  CONTROLADOR
                '    Dim var_controladorFormulario As IControladorFormulario = New clsControladorFormularioIndizacion(_frmIndizacion, var_opercionesFormulario)

                '    'referencia al controlador 
                '    _frmIndizacion.controladorFormulario = var_controladorFormulario



                '    'referencias cruzadas entre controladores 
                '    var_controladorFormulario.controladorPanel = var_controladorPanel
                '    var_controladorPanel.controladorFormulario = var_controladorFormulario

                '    _frmIndizacion.Controls.Add(_frmIndizacion.PanelIndizacion)



                'With _frmIndizacion
                '    .MdiParent = Me
                '    .WindowState = FormWindowState.Maximized
                '    .Show()
                'End With
                'End If

            Case accion.corregirPAED

                'If (frmContenedorMDI.oProyecto._CodigoProyecto = My.Settings.codigoEpidemiologia) Then
                Me.Text = oProyecto._CodigoProyecto.ToString & " :: " & oProyecto._nombreProyecto.ToString & " Usuario: " & oUsuario._nombre.ToString
                Dim _frmCorreccion As New frmCorreccionEpidemiologia()
                With _frmCorreccion
                    .MdiParent = Me
                    .WindowState = FormWindowState.Maximized
                    .Show()
                End With

                'Else
                '    Me.Text = oProyecto._CodigoProyecto.ToString & " :: " & oProyecto._nombreProyecto.ToString & " Usuario: " & oUsuario._nombre.ToString
                '    Dim _frmIndizacion As New frmIndizacionCorreccion



                '    Dim nombreClasePanelIndizacion As String = "PanelIndizacionGeneral"

                '    If Not IsNothing(ctx) Then
                '        ctx.Dispose()
                '        ctx = Nothing
                '    End If

                '    ctx = ContextRegistry.GetContext()


                ''MVC para el Panel

                ''creamos el panel VISTA
                '_frmIndizacion.PanelIndizacion = ctx.GetObject(nombreClasePanelIndizacion.ToString)

                ''crear la varable operaciones panel MODELO
                'Dim var_operacionesPanel As IoperacionesPanel = New clsOperacionesPanelGenerico()

                ''crear el controlador del panel, esto tendria que ser una interfaz  CONTROLADOR
                'Dim var_controladorPanel As IControladorPanel = New clsControladorPanel(_frmIndizacion.PanelIndizacion, var_operacionesPanel)

                ''referencia del controlardor en el panel 
                '_frmIndizacion.PanelIndizacion.controladorPanel = var_controladorPanel

                ''inicializa el panel de indizacion 
                '_frmIndizacion.PanelIndizacion.InicializaPanel()

                ''MVC para el formulario 
                ''crear la variable operaciones panel MODELO
                'Dim var_opercionesFormulario As IoperacionesFormulario = New clsOperacionesFormularioIndizacion()

                ''crear el controlador del panel, esto tendria que ser una interfaz  CONTROLADOR
                'Dim var_controladorFormulario As IControladorFormulario = New clsControladorFormularioIndizacion(_frmIndizacion, var_opercionesFormulario)

                ''referencia al controlador 
                '_frmIndizacion.controladorFormulario = var_controladorFormulario



                ''referencias cruzadas entre controladores 
                'var_controladorFormulario.controladorPanel = var_controladorPanel
                'var_controladorPanel.controladorFormulario = var_controladorFormulario

                '_frmIndizacion.Controls.Add(_frmIndizacion.PanelIndizacion)



                'With _frmIndizacion
                '    .MdiParent = Me
                '    .WindowState = FormWindowState.Maximized
                '    .Show()
                'End With
                'End If




            Case accion.administrar

                Dim _frmAdministrar As New frmAdministrar

                With _frmAdministrar
                    .MdiParent = Me
                    .WindowState = FormWindowState.Maximized
                    .Show()
                End With


            Case accion.preparar

                Dim _frmPreparacion As New frmPreparacion

                With _frmPreparacion
                    .MdiParent = Me
                    .WindowState = FormWindowState.Maximized
                    .Show()
                End With


        End Select

    End Sub


#Region "Controles del menú principal de la aplicacion"


    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click

        Try
            Application.Exit()
        Catch ex As Exception

        End Try

        Me.Close()
    End Sub


    Private Sub CorreccionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CorreccionToolStripMenuItem.Click
        Dim _frmCorreccion As New frmCorreccion
        With _frmCorreccion
            .MdiParent = Me
            .WindowState = FormWindowState.Maximized
            .Show()
        End With
    End Sub


#End Region

#Region "funciones para el control de ventanas "


    Private Sub MinimizarTodasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        For i As Integer = 0 To Me.MdiChildren.Length - 1
            Me.MdiChildren(i).WindowState = FormWindowState.Minimized
        Next

    End Sub

    Private Sub ReestablecerTodasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Formularios As Form

        'Recorre todos los Formularios en un For-Each
        For Each Formularios In Me.MdiChildren

            'si no es el MDI entonces reestablece la ventana
            If Not (Formularios Is Me) Then
                Formularios.WindowState = vbNormal
            End If

        Next
    End Sub

    Private Sub CerrarTodasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Formularios As Form

        For Each Formularios In Me.MdiChildren

            'Si no es el MDI lo decarga
            If Not Formularios Is Me Then
                Formularios.Close()
            End If

        Next
    End Sub

    Private Sub CascadaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub MosaicoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


        Me.LayoutMdi(MdiLayout.TileHorizontal)


    End Sub

    Private Sub MosaicoVerticalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

#End Region

    Private Sub frmContenedorMDI_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        For Each form As Windows.Forms.Form In Me.MdiChildren

            form.Close()

        Next


    End Sub


    Public Sub CerrarSesiónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CerrarSesiónToolStripMenuItem.Click

        'inicializamos los datos 
        If Not IsNothing(frmContenedorMDI.oDocumento) Then frmContenedorMDI.oDocumento = Nothing
        If Not IsNothing(frmContenedorMDI.oFuncionAplicacion) Then frmContenedorMDI.oFuncionAplicacion = Nothing
        If Not IsNothing(frmContenedorMDI.oLote) Then frmContenedorMDI.oLote = Nothing
        If Not IsNothing(frmContenedorMDI.oProyecto) Then frmContenedorMDI.oProyecto = Nothing
        numeroHojaMaxima = 0

        For Each Formularios As Form In Me.MdiChildren

            'Si no es el MDI lo decarga
            If Not Formularios Is Me Then
                Formularios.Close()
            End If

        Next

        Dim _frmSeleccionProyecto As New frmSeleccionProyecto
        _frmSeleccionProyecto.StartPosition = FormStartPosition.CenterParent
        _frmSeleccionProyecto.ShowDialog(Me)

        If frmContenedorMDI.oFuncionAplicacion <> Accion.administrar And frmContenedorMDI.oFuncionAplicacion <> Accion.crearcaratula Then
            If frmContenedorMDI.oProyecto Is Nothing OrElse frmContenedorMDI.oLote Is Nothing Then
                Application.Exit()
                Exit Sub
            End If
        End If


        Call inicializarPrimerFormularioMostrar(frmContenedorMDI.oFuncionAplicacion)


    End Sub

    Private Function comprobarLicencia() As Boolean

        Dim fechaDesencriptada As String
        Dim licenciaCorrecta As Boolean = True

        Try
            fechaDesencriptada = libCifrado.clsCifrado.desencriptarCadenaConFormato(My.Settings.fecha, "vecGedsa", "claGedsa")
        Catch
            fechaDesencriptada = ""
        End Try

        If DateTime.TryParse(fechaDesencriptada, fechaFinLicencia) Then
            If DateTime.Now > fechaFinLicencia Then
                licenciaCorrecta = False
            End If
        Else
            licenciaCorrecta = False
        End If

        Return licenciaCorrecta

    End Function


    Private Sub TimerFinLicencia_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerFinLicencia.Tick

        Me.TimerFinLicencia.Enabled = False
        MessageBox.Show("Su licencia ha caducado, por favor, póngase en contacto con un responsable de GEDSA.", "Fin de licencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Me.TimerFinLicencia.Enabled = True

    End Sub
   
    Private Sub MenuStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub
End Class