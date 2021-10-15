Namespace Entidades
    Public Class ClsTipoActo

        Private codigo As String
        Private descripcion As String

        Public Sub New(ByVal codActo As String, ByVal descripcion As String)
            Me.codigo = codActo
            Me.descripcion = descripcion
        End Sub

        Property _codActo() As String
            Get
                Return Me.codigo
            End Get
            Set(ByVal value As String)
                Me.codigo = value
            End Set
        End Property

        Property _descripcion() As String
            Get
                Return Me.descripcion
            End Get
            Set(ByVal value As String)
                Me.descripcion = value
            End Set
        End Property

        Public Overrides Function ToString() As String
            Return Me.codigo & " - " & Me.descripcion
        End Function

    End Class
End Namespace

