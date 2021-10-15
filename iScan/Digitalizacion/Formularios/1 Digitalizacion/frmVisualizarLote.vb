Imports System.IO
Imports AccesoDAtosProd = LibreriaCadenaProduccion.Datos.Produccion.clsAccesoDatosProduccion
Imports AccesoDAtos = LibreriaCadenaProduccion.Datos.GeneralSQL.clsAccesoDatosSQL
Imports accesoDatosLote = LibreriaCadenaProduccion.Datos.Produccion.cadenaproduccion.clsAccesoDatosLote

Public Class frmVisualizarlote


    Public Sub New(ByVal idloteMostrar As Integer, ByVal cadenaconexionPro As String, ByVal rutaimagenes As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.idlote = idloteMostrar
        Me.cadenaconexionproyecto = cadenaconexionPro
        Me.rutaimagenes = rutaimagenes
    End Sub


    Dim idlote As Integer
    Dim cadenaconexionproyecto As String
    Dim rutaimagenes As String


    Private Sub frmVisualizar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Call inicilizarDAtos()


    End Sub

    Private Sub inicilizarDAtos()

        Me.DataGridView1.DataSource = AccesoDAtos.ejecutarSQLDirectaTable("SELECT * FROM lotes WHERE idlote = " & Me.idlote, cadenaconexionproyecto)
        Me.DataGridView2.DataSource = AccesoDAtos.ejecutarSQLDirectaTable("SELECT * FROM trazabilidadlotes WHERE idlote = " & Me.idlote, cadenaconexionproyecto)
        Me.DataGridView3.DataSource = AccesoDAtos.ejecutarSQLDirectaTable("SELECT * FROM documentos WHERE idlote = " & Me.idlote & " ORDER BY pagina ASC ", cadenaconexionproyecto)

        Application.DoEvents()

        LibreriaCadenaProduccion.Entidades.ClsLote.CargarImagenesLoteListview(rutaImagenes, Me.ListView1, Me.ImageList1)
    End Sub






    Private Sub frmVisualizarlote_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint

    End Sub
End Class