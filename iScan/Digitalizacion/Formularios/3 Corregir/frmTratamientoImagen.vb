Public Class frmTratamientoImagen

    Dim imagen_tmp As Image
    Dim imagen As clsImagenReferencia

    Dim valorMaximo As Integer = 15
    Dim valorIncial As Integer
    Dim valorIncremento As Double = 0.1

    Sub New(ByRef tmpImagen As clsImagenReferencia)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        imagen = tmpImagen

        'Clonamos la imagen principal por si hay que reiniar
        imagen_tmp = imagen.imagen.Clone

    End Sub

    Private Sub frmTratamientoImagen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ImageControl1.Image = imagen_tmp

        'TrackBar1.Maximum = valorMaximo
        TrackBar2.Maximum = valorMaximo

        valorIncial = valorMaximo / 2

        'Situamos en el valores de las barras en el incial
        'TrackBar1.Value = valorIncial
        TrackBar2.Value = valorIncial

    End Sub

    Function fnc_brillo() As Integer
        Return TrackBar2.Value - valorIncial
    End Function

   
    ''' <summary>
    ''' Devuelve la trasformacion de la imagen principal
    ''' </summary>
    ''' <remarks></remarks>
    Sub fnc_imagen_trasforma()

        'Aplicamos los filtros
        imagen.imagen = imagen_tmp.Clone

        If fnc_brillo() <> valorIncial Then
            Dim filtro As New AForge.Imaging.Filters.BrightnessCorrection(fnc_brillo() * valorIncremento)
            filtro.ApplyInPlace(imagen.imagen)
        End If

        ImageControl1.Image = imagen.imagen
        
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If MsgBox("Se perderan todos los cambios efectuados a la imagen", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Atención") = MsgBoxResult.Yes Then
            imagen.imagen = imagen_tmp.Clone

            ImageControl1.Image = Nothing
            ImageControl1.Image = imagen.imagen
        End If
    End Sub

    Private Sub TrackBar2_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar2.Scroll
        fnc_imagen_trasforma()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If MsgBox("Se perderan todos los cambios efectuados a la imagen", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Atención") = MsgBoxResult.Yes Then
            imagen.imagen = Nothing
            Me.Close()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        imagen.imagen = ImageControl1.Image
        Me.Close()
    End Sub

   

End Class