Namespace Entidades

    Public Class ClsSexo

        Private _codigo As Integer
        Private _descripcion As String

        Public Sub New()

        End Sub

        Public Sub New(ByVal codigo As Integer, ByVal descripcion As String)

            Me._codigo = codigo
            Me._descripcion = descripcion

        End Sub

        Public Property codigo() As Integer
            Get
                Return Me._codigo
            End Get
            Set(ByVal value As Integer)
                Me._codigo = value
            End Set
        End Property

        Public Property descripcion() As String
            Get
                Return Me._descripcion
            End Get
            Set(ByVal value As String)
                Me._descripcion = value
            End Set
        End Property

        Public Overrides Function ToString() As String
            Return Me._descripcion
        End Function

    End Class

End Namespace
