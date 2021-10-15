Imports datos = LibreriaCadenaProduccion.Datos.GeneralSQL.clsAccesoDatosSQL
Public Class frmEdicionFip

    Dim var_nuevo As Boolean = True
    Dim var_hospital As String = ""
    Dim var_numHistoria As String = ""


    Sub New(ByVal hospital As String, ByVal numHistoria As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        var_hospital = hospital
        var_numHistoria = numHistoria

    End Sub

    Sub cargaDatos()

        Dim dt As DataTable = datos.ejecutarSQLDirectaTable("SELECT * from fip where numhistoria='" & var_numHistoria & "' and hospital='" & var_hospital & "' ", My.Settings.cadenaConexion)
        'en el caso de que no encuentre datos se supone que es un nuevo registro

        If dt IsNot Nothing Then
            If dt.Rows.Count > 0 Then

                txtNombre.Text = dt.Rows(0).Item("Nombre").ToString
                txtApellido1.Text = dt.Rows(0).Item("Apellido1").ToString
                txtApellido2.Text = dt.Rows(0).Item("Apellido2").ToString
                
                'Guardamos los datos
                var_nuevo = False

            End If
        End If


    End Sub

    Sub salvaDatos()
        Dim correcto As Boolean = True
        'Creamos un nuevo registro o actualizamos el actual

        If var_nuevo Then
            If datos.ejecutaSQLEjecucion("INSERT into fip (hospital, numhistoria,nombre, apellido1,apellido2) VALUES ('" & var_hospital & "', '" & var_numHistoria & "','" & txtNombre.Text & "', '" & txtApellido1.Text & "','" & txtApellido2.Text & "')", My.Settings.cadenaConexion) Then correcto = False
            'si es correco salimos de la ventana
        Else
            If Not datos.ejecutaSQLEjecucion("UPDATE fip SET nombre='" & txtNombre.Text & "', apellido1='" & txtApellido1.Text & "', apellido2='" & txtApellido2.Text & "' WHERE hospital='" & var_hospital & "' and numhistoria='" & var_numHistoria & "'", My.Settings.cadenaConexion) Then correcto = False
        End If
        If correcto Then Me.Close()
    End Sub

    Private Sub frmEdicionFip_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargaDatos()
        muestraNombre()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub txtNombre_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNombre.GotFocus
        CType(sender, TextBox).SelectAll()
    End Sub

    Private Sub txtNombre_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNombre.KeyDown, txtApellido1.KeyDown, txtApellido2.KeyDown, txtNombre.KeyDown
        If e.KeyCode = Keys.Enter Then

            Select Case sender.name
                Case "txtNombre"
                    e.Handled = True
                    txtApellido1.Focus()
                Case "txtApellido1"
                    e.Handled = True
                    txtApellido2.Focus()
                Case "txtApellido2"
                    e.Handled = True
                    Button1.Focus()
            End Select
            'Enviamos la tecla de tabulacion
        End If
    End Sub

    Private Sub txtNombre_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNombre.LostFocus

    End Sub

    Sub muestraNombre()
        txtNombreCompleto.Text = txtApellido1.Text & " " & txtApellido2.Text & ", " & txtNombre.Text
    End Sub

    Private Sub txtNombre_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtNombre.MouseClick, txtApellido1.MouseClick, txtApellido2.MouseClick
        CType(sender, TextBox).SelectAll()
    End Sub

    Private Sub txtNumEpisodio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombre.TextChanged
        muestraNombre()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        salvaDatos()
    End Sub

    Private Sub txtApellido2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtApellido2.TextChanged

    End Sub
End Class