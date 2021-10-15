Public Class ctrlPorcentajeCorreccion
    Private instancia As frmCorreccionEpidemiologia
    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        inicializarlista()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
    Public Sub anyadirInstancia(ByVal instancia As frmCorreccionEpidemiologia)
        Me.instancia = instancia
    End Sub
    Public Sub inicializarlista()
        Try
            For i As Integer = 1 To 100
                Me.ComboBox1.Items.Add(i)
            Next
            Me.ComboBox1.Text = 20
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Me.Visible = False
            Me.instancia.inicializarDataGrid(Me.ComboBox1.Text)
            Me.instancia.DataGridView1.Focus()
        Catch ex As Exception

        End Try
    End Sub
End Class
