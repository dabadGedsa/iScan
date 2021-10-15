Imports accesodatos = LibreriaCadenaProduccion.Datos.GeneralSQL.clsAccesoDatosSQL

Public Class frmModificarRango

    Private idlote As Integer

    Public Sub New(ByVal pagina As Integer, ByVal idlote As Integer)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.txtDesde.Value = pagina
        Me.txtHasta.Value = pagina
        Me.idlote = idlote
    End Sub

    Private Sub frmModificarRango_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


    End Sub

    Private Sub modificar_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CtrlBotonPequenyo1.eClick

        Dim mensaje As String = ""
        Dim correcto As Boolean = True
        Dim strSQL As String
        Dim filasafectadas As Integer

        If Me.txtNHC.Text = "" Then
            correcto = False
        End If

        If Not correcto Then
            MessageBox.Show("Error faltan campos por cumplimentar : " & mensaje)
        Else

            strSQL = "update documentos set numhistoria = '" & Me.txtNHC.Text & "' where idlote = " & idlote & " and pagina between " & Me.txtDesde.Value.ToString & " and " & Me.txtHasta.Value.ToString
            accesodatos.ejecutaSQLEjecucion(strSQL, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto, filasafectadas, True)
            Me.Close()
        End If


    End Sub
End Class