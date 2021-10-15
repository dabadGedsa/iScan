Public Class frmLicencia



    Private Sub frmLicencia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ObtenerCodigoProducto()
        

    End Sub


    Private Sub cmbActivar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbActivar.Click
        Try

        
            If libCifrado.clsCifrado.leerMac = libCifrado.clsCifrado.desencriptarCadenaConFormato(Me.txtLicencia.Text, "vecGedsa", "claGedsa") Then
                libCifrado.clsCifrado.escribirCodigoXML("cd.xml", Me.txtLicencia.Text)
                MessageBox.Show("Licencia activada correctamente")
                Me.Close()
            Else
                Me.lbllicencia.Visible = True
            End If
        Catch ex As Exception
            Me.lbllicencia.Visible = True
        End Try

    End Sub

    Private Sub ObtenerCodigoProducto()
        Dim codigoProducto As String

        codigoProducto = libCifrado.clsCifrado.encriptarConFormato(libCifrado.clsCifrado.leerMac, "vecPubli", "claPubli")
        Me.txtcodigoProducto.Text = codigoProducto

    End Sub



    Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        Me.Close()
    End Sub
End Class