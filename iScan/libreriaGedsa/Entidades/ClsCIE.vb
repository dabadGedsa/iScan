Namespace Entidades

    Public Class ClsCIE

        Private codigo As String
        Private descripcion As String

        Public Sub New(ByVal codigo As String, ByVal desc As String)

            Me.codigo = codigo
            Me.descripcion = desc

        End Sub

        Public Property _Codigo() As String
            Get
                Return Me.codigo
            End Get
            Set(ByVal value As String)
                Me.codigo = value
            End Set
        End Property

        Public Property _Descripcion() As String
            Get
                Return Me.descripcion
            End Get
            Set(ByVal value As String)
                Me.descripcion = value
            End Set
        End Property

        Public Overrides Function ToString() As String

            Return Me.codigo & "   " & Me.descripcion

        End Function

    End Class

End Namespace
