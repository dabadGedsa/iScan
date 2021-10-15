Namespace Entidades

    Public Class ClsTarea

        Private id As Integer
        Private nombre As String
        Private descripcion As String


        Public Sub New()

        End Sub

        Public Sub New(ByVal id As Integer, ByVal nombre As String)

            Me.id = id
            Me.nombre = nombre

        End Sub


        Public Property _id() As Integer
            Get
                Return Me.id
            End Get
            Set(ByVal value As Integer)
                Me.id = value
            End Set
        End Property

        Public Property _nombre() As String
            Get
                Return Me.nombre
            End Get
            Set(ByVal value As String)
                Me.nombre = value
            End Set
        End Property

        Public Property _descripcion() As String
            Get
                Return Me.descripcion
            End Get
            Set(ByVal value As String)
                Me.descripcion = value
            End Set
        End Property


        Public Overrides Function ToString() As String
            Return Me.nombre
        End Function

    End Class

End Namespace
