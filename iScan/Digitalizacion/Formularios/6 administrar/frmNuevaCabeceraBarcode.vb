Imports datos = LibreriaCadenaProduccion.Datos.GeneralSQL.clsAccesoDatosSQL

Public Class frmNuevaCabeceraBarcode

    Public proyecto As LibreriaCadenaProduccion.Entidades.clsProyecto

    Private Sub cmdAceptar_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.eClick

        'comprobar que los datos son correctos 
        If Me.txtCabeceraBarcode.Text <> "" And Me.nudlongitudCodigoBarras.Value > 0 Then
            'insertar el registro correspondiente en la base de datos
            datos.ejecutarSQLDirecta("INSERT INTO configuracionbarcode (idProyecto,inicioBarcode,longitud) VALUES (" & Me.proyecto._CodigoProyecto & "," & Me.txtCabeceraBarcode.Text & "," & Me.nudlongitudCodigoBarras.Value & ")", My.Settings.cadenaConexion)
            Me.Close()
        Else
            MessageBox.Show("Los valores introducidos para la nueva cabecera del código de barras no son validos")
        End If

    End Sub


    Private Sub cmdCancelar_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.eClick
        'nos salimos sin insertar 
        Me.Close()
    End Sub



End Class