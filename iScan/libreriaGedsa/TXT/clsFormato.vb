Imports System.Windows.Forms

Namespace TXT


    Public Class clsFormato


        Public Shared Sub centrado(ByRef editor As RichTextBox, ByVal texto As String)

            editor.SelectionAlignment = HorizontalAlignment.Center
            editor.AppendText(texto & vbCr)
            editor.ScrollToCaret()
            editor.Refresh()

        End Sub

        Public Shared Sub escribir(ByRef editor As RichTextBox, ByVal texto As String)

            editor.SelectionAlignment = HorizontalAlignment.Left
            editor.AppendText(texto & vbCr)
            editor.ScrollToCaret()
            editor.Refresh()

        End Sub

        Public Shared Sub escribir(ByRef editor As RichTextBox, ByVal texto As String, ByVal Color As Color)

            editor.SelectionColor = Color
            editor.SelectionAlignment = HorizontalAlignment.Left
            editor.SelectedText = texto & vbCr
            editor.ScrollToCaret()
            editor.Refresh()

        End Sub

        Public Shared Sub escribir(ByRef editor As RichTextBox, ByVal texto As String, ByVal Color As Color, ByVal tama�o As Integer)

            Dim fuente As New System.Drawing.Font(FontFamily.GenericSerif, tama�o)
            editor.SelectionFont = fuente
            editor.SelectionColor = Color
            editor.SelectionAlignment = HorizontalAlignment.Left
            editor.SelectedText = texto & vbCr
            editor.ScrollToCaret()
            editor.Refresh()

        End Sub

        Public Shared Sub escribirEnLogExplotacion(ByVal texto As String)

            Dim sw As New System.IO.StreamWriter(My.Application.Info.DirectoryPath & "\LOG".ToString.Trim & "\LARIBERA_EXPLOT_" & Replace(Format(Today, "dd/MM/yyyy"), "/", "_") & ".txt", True)
            sw.WriteLine(texto)
            sw.Close()

        End Sub

    End Class

End Namespace
