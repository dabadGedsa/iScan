Imports System
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Windows.Forms


Public Class ImageControlFunciones


    Public Function cargarImagen(ByVal imagen As Image) As Boolean

        Try

            Me.ImageControl1.Image = imagen
            Me.ImageControl1.BringToFront()


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Function


    Public Function cargarImagen(ByVal path As String) As Boolean

        Try

            Me.ImageControl1.Image = Image.FromFile(path)
            Me.ImageControl1.BringToFront()


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Function

    Public Function recuperarImagen() As Image

        Try
            Return Me.ImageControl1.Image
        Catch ex As Exception

        End Try
        Return Nothing
    End Function

    Public Sub liberaImagen()

        Try
            ImageControl1.Image = Nothing
            'ImageControl1.Image.Dispose()
        Catch ex As Exception

        End Try

    End Sub

#Region "Eventos de los botones"



    Private Sub btnRotarIzquierda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRotarIzquierda.Click
        Me.ImageControl1.RotateFlip(RotateFlipType.Rotate270FlipNone)

    End Sub

    Private Sub btnRotarDerecha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRotarDerecha.Click
        Me.ImageControl1.RotateFlip(RotateFlipType.Rotate90FlipNone)
    End Sub

    Private Sub btnAumentarBrillo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAumentarBrillo.Click
        Me.brillo(Me.ImageControl1.Image, 5)
    End Sub

    Private Sub btnDecrementarBrillo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDecrementarBrillo.Click
        Me.brillo(Me.ImageControl1.Image, -5)
    End Sub

    Private Sub btnAumentarContraste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAumentarContraste.Click
        Me.contraste(Me.ImageControl1.Image, 5)
    End Sub

    Private Sub btnDecrementarContraste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDecrementarContraste.Click

        Me.contraste(Me.ImageControl1.Image, -5)

    End Sub



#End Region

#Region "Filtros"

    Private Function brillo(ByRef b As System.Drawing.Bitmap, ByVal nBrightness As Integer) As Boolean







    End Function



    Private Function contraste(ByRef b As System.Drawing.Bitmap, ByVal contra As Integer) As Boolean







    End Function



#End Region







   
End Class
