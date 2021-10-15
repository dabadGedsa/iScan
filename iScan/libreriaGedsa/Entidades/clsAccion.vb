Namespace Entidades


    Public Class clsAccion


        Dim idAccion As Integer
        Dim descripcion As String

        Public Property _idAccion() As Integer
            Get
                Return Me.idAccion
            End Get
            Set(ByVal value As Integer)
                Me.idAccion = value
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
            Return Me.descripcion
        End Function

    End Class

End Namespace