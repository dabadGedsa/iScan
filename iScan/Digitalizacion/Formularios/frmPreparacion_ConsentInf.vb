Public Class frmPreparacion_ConsentInf

    Dim posiciones As Integer

    Private Sub frmPreparacion_ConsentInf_Load(sender As Object, e As EventArgs) Handles Me.Load

        cmdSeleccionar.Enabled = False

        Label1.Text = "Seleccionado lote " & frmContenedorMDI.oLote._idlote

        Label4.Text = ""

        txtArchivador.Text = ""
        txtSeparador.Text = ""

        txtArchivador.Focus()

    End Sub

    Private Sub localizaContenedorCliente(ByVal archivador As Integer, ByVal carpeta As Integer)

        Dim dt As DataTable
        Dim lsSql As String = "SELECT distinct(numHistoria), idLote FROM loteado_cinf WHERE Archivador=" & archivador & " AND Carpeta=" & carpeta

        dt = Digitalización.accesoDatosNuevos.clsAccesoDatosNUEVO.ejecutarSQLDirectaTable(lsSql, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto)

        posiciones = dt.Rows.Count
        frmContenedorMDI.oLote._posiciones = posiciones

        If posiciones > 0 Then
            If IsDBNull(dt.Rows(0).Item("idLote")) Then
                Label4.Text = "Localizado contenedor cliente con " & posiciones & " posiciones."
                Label4.ForeColor = Color.LimeGreen
                cmdSeleccionar.Enabled = True
                cmdSeleccionar.Focus()
            ElseIf dt.Rows(0).Item("idLote") = 0 Then
                Label4.Text = "Localizado contenedor cliente con " & posiciones & " posiciones."
                Label4.ForeColor = Color.LimeGreen
                cmdSeleccionar.Enabled = True
                cmdSeleccionar.Focus()
            Else
                Label4.Text = "El archivador y carpeta seleccionados ya están asignados al lote " & dt.Rows(0).Item("idLote") & "."
                Label4.ForeColor = Color.Red
                Button1.Enabled = False
                cmdSeleccionar.Enabled = False
                ''txtArchivador.Focus()
                ''txtArchivador.SelectAll()
            End If
        Else
            Label4.Text = "No ha sido localizado el contenedor del cliente."
            Label4.ForeColor = Color.Red
            ''txtArchivador.Focus()
            ''txtArchivador.SelectAll()
        End If

    End Sub

    Private Sub TxtArchivador_Leave(sender As Object, e As EventArgs) Handles txtArchivador.Leave

        If (txtArchivador.Text.ToString.Trim <> "" And Not IsNumeric(txtArchivador.Text)) Or (txtSeparador.Text.ToString.Trim <> "" And Not IsNumeric(txtSeparador.Text)) Then
            ''MessageBox.Show("Los campos archivador y carpeta deben ser numéricos.", "Campos numéricos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtArchivador.Focus()
            Exit Sub
        End If

        If txtArchivador.Text.ToString.Trim <> "" And txtSeparador.Text.ToString.Trim <> "" Then
            localizaContenedorCliente(txtArchivador.Text, txtSeparador.Text)
        End If

    End Sub

    Private Sub txtSeparador_Leave(sender As Object, e As EventArgs) Handles txtSeparador.Leave

        If (txtArchivador.Text.ToString.Trim <> "" And Not IsNumeric(txtArchivador.Text)) Or (txtSeparador.Text.ToString.Trim <> "" And Not IsNumeric(txtSeparador.Text)) Then
            ''MessageBox.Show("Los campos archivador y carpeta deben ser numéricos.", "Campos numéricos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtSeparador.Focus()
            Exit Sub
        End If

        If txtArchivador.Text.ToString.Trim <> "" And txtSeparador.Text.ToString.Trim <> "" Then
            localizaContenedorCliente(txtArchivador.Text, txtSeparador.Text)
        End If

    End Sub

    Private Sub CmdSeleccionar_Click(sender As Object, e As EventArgs) Handles cmdSeleccionar.Click

        Try
            Dim lsSql As String = "UPDATE LOTES SET numeroPosiciones=" & posiciones & " WHERE idLote=" & frmContenedorMDI.oLote._idlote &
                        ";UPDATE loteado_cinf SET idLote=" & frmContenedorMDI.oLote._idlote & " WHERE  Archivador=" & txtArchivador.Text.ToString.Trim & " AND Carpeta=" & txtSeparador.Text.ToString.Trim

            Digitalización.accesoDatosNuevos.clsAccesoDatosNUEVO.ejecutarSQLConTransaccion(lsSql, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto)

            Try
                frmContenedorMDI.oLote._posiciones = posiciones

            Catch ex As Exception

            End Try

            seleccionadaUbicacionCliente = 2

        Catch ex As Exception
            MessageBox.Show("Ocurríó un error al actualizar las posiciones y relacionar el archivador y la carpeta con el lote, no se ha realizado correctamente la operación." & vbLf & "ERROR:" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Me.Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        ''Dim lsSql As String = "UPDATE LOTES SET numeroPosiciones=0 WHERE idLote=" & frmContenedorMDI.oLote._idlote

        ''Digitalización.accesoDatosNuevos.clsAccesoDatosNUEVO.ejecutaSQLEjecucion(lsSql, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto,, False)

        seleccionadaUbicacionCliente = 1

        Me.Close()

    End Sub
End Class