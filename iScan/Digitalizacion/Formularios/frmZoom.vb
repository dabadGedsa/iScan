Public Class frmZoom

    Dim imagen As Image

    Sub New(ByRef tmpImagen As Image)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        imagen = tmpImagen
    End Sub

    Private Sub frmZoom_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ImageControl1.Image = imagen
    End Sub

    Private Sub ImageControl1_KeyDown(ByVal e As System.Windows.Forms.KeyEventArgs) Handles ImageControl1.control_KeyDowm
        Select Case e.KeyCode
            Case Keys.Add
                ImageControl1.ZoomIn()
            Case Keys.Subtract
                ImageControl1.ZoomOut()
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

    Private Sub ImageControl1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImageControl1.Load

    End Sub
End Class