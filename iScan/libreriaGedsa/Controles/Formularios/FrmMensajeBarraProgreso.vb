
Namespace Controles
    Namespace Formularios

        Public Class FrmMensajeBarraProgreso


            Public Sub New(ByVal numPasos As Integer, ByVal mensaje As String)

                ' Llamada necesaria para el Diseñador de Windows Forms.
                InitializeComponent()

                ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

                Me.progressBarAsignacion.Maximum = numPasos
                Me.LabelMensaje.Text = mensaje

            End Sub

            Public Sub _AumentarBarraProgreso()

                Me.progressBarAsignacion.PerformStep()

                If Me.progressBarAsignacion.Maximum <> 0 Then
                    Me.LabelPorcentaje.Text = (Me.progressBarAsignacion.Value * 100) \ Me.progressBarAsignacion.Maximum & " % completado"
                End If

                Me.Refresh()

            End Sub

        End Class


    End Namespace
End Namespace
