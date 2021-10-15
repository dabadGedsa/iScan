Imports System.IO
Imports AccesoDAtosProd = LibreriaCadenaProduccion.Datos.Produccion.clsAccesoDatosProduccion
Imports AccesoDAtos = LibreriaCadenaProduccion.Datos.GeneralSQL.clsAccesoDatosSQL
Imports accesoDatosLote = LibreriaCadenaProduccion.Datos.Produccion.cadenaproduccion.clsAccesoDatosLote
Imports operaciones = LibreriaCadenaProduccion.Entidades.Operaciones.clsOperacionesLote



Public Class frmDigitalizacion

    Dim WithEvents aplicacion_scan As Process
    Dim rutaimagenes As String
    Dim numeroImagenesLote As Integer = 0
    Dim nombreUltimoArchivo As String


    Private Sub frmDigitalizacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Call inicializarDAtos()

    End Sub


    Private Sub inicializarDAtos()


        Me.cmbCerrarLote.Enabled = False

        rutaimagenes = AccesoDAtosProd.ObtenerRutaImagenes(frmContenedorMDI.oProyecto._CodigoProyecto, frmContenedorMDI.oLote._idlote, My.Settings.cadenaConexion)
        'Estos argumentos son para un numero indefinido de documentos

        'comprobar que la ruta existe 

        Dim mINI As New LibreriaCadenaProduccion.INI.clsIniArray
        mINI.IniWrite(My.Settings.pathArchivoConfigEscaner, "BatchScaning", "SaveDir", RutaImagenes)

        Dim argumentos As String = "" ' "/one /batchscan=(IML,1,1,5,1," & RutaImagenes & ",tif,0)"

        'Estos argumentos son para un solo documento
        'argumentos = "/one /scanhidden /convert=c:\IMG0000.tif"
        proceso_arrancar(My.Settings.rutaAplicacionEscaner, argumentos)

        
    End Sub


    Sub proceso_arrancar(ByVal rutaEjecutable As String, Optional ByVal argumentos As String = "")

        'Incializamos las aplicaciones 
        aplicacion_scan = New Process

        With aplicacion_scan
            .EnableRaisingEvents = True
            .StartInfo.UseShellExecute = False
            .StartInfo.WindowStyle = ProcessWindowStyle.Normal
            .StartInfo.Arguments = argumentos
            .StartInfo.FileName = rutaEjecutable
        End With
        aplicacion_scan.Start()
        aplicacion_scan.WaitForExit()
        aplicacion_scan.Close()



        'preguntamos si quiere cerrar el lote al usuario, en caso afirmativo el lote se cerrara pasará a la 
        'fase de importación, en caso negativo el usuario pasará a seleccionar un nuevo lote y el lote quedará 
        'en la lista de lotes a digitalizar 

        Dim counter = My.Computer.FileSystem.GetFiles(rutaimagenes, FileIO.SearchOption.SearchTopLevelOnly, "*.tif")

        MsgBox("La carpeta contiene " & CStr(counter.Count) & " imágenes.")

        If MessageBox.Show("Desea cerrar el lote  " & frmContenedorMDI.oLote._idlote & ". Si cierra el lote, éste pasará a la siguiente fase y no podrá continuar digitalizando documentos dentro del lote. En el caso contrario podrá seleccionarlo nuevamente para continuar con el proceso de digitalización.", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

            accesoDatosLote.CerrarLoteParaDigitalizar(frmContenedorMDI.oUsuario._login, frmContenedorMDI.oLote._idlote, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto)



            'Dim e As System.EventArgs
            '            frmContenedorMDI.CerrarSesiónToolStripMenuItem_Click((Nothing), e)
            Call inicializarDAtos()

            Me.BackgroundWorker1.RunWorkerAsync()

        Else
            'Dim e As System.EventArgs
            '           frmContenedorMDI.CerrarSesiónToolStripMenuItem_Click((Nothing), e)
            Call inicializarDAtos()

        End If

    End Sub



    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork


        operaciones.ImportarLoteBD(frmContenedorMDI.oLote._idlote, frmContenedorMDI.oProyecto._CodigoProyecto, My.Settings.cadenaConexion, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto, Nothing, Nothing)

    End Sub


End Class