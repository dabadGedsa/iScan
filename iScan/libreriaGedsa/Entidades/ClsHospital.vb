Namespace Entidades

    Public Class ClsHospital

        Private codigo As Integer
        Dim Descripcion As String
        Dim RutaConfiguraciones As String
        Dim RutaBuzonDestinoPeticiones As String
        Dim UsuarioNetUse As String
        Dim PWDNetUse As String
        Dim ServidorFTP As String
        Dim UsuarioFTP As String
        Dim ContraseñaFTP As String
        Dim BuzonDestinoFTP As String
        Dim DiasVigencia As String
        Dim BuzonPeticionesManuales As String
        Dim DireccionPostal As String
        Dim CP As String
        Dim Poblacion As String
        Dim Provincia As String
        Dim NumHospital As String


        Public Sub New(ByVal codigo As String)
            Me.codigo = codigo

        End Sub

        Public Property codigoHospital() As Integer
            Get
                Return codigo
            End Get
            Set(ByVal value As Integer)
                codigo = value
            End Set
        End Property


    End Class
End Namespace
