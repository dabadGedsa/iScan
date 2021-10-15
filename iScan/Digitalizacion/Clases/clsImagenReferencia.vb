''' <summary>
''' Esta clase sirve para poder pasar imagenes por referencia a un formulario
''' </summary>
''' <remarks></remarks>
Public Class clsImagenReferencia

    Public imagen As Image

    'Asignamos la direccion de memoria de la imagen a nuestra imagen de la clase
    Sub New(ByRef tmpImagen As Image)
        imagen = tmpImagen
    End Sub

End Class