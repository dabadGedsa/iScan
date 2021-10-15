Public Class clsEstado


    Private idEstado As Integer
    Private descripcion As String

    Public Sub New(ByVal idestado As Integer, ByVal descripcion As String)
        Me.idEstado = idestado
        Me.descripcion = descripcion
    End Sub


    Property _idEstado() As Integer
        Get
            Return Me.idEstado
        End Get
        Set(ByVal value As Integer)
            Me.idEstado = value
        End Set
    End Property

    Property _Descripcion() As String
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
