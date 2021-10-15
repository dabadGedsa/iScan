Namespace Entidades

    Public Class clsNivelesCodificacion


        Dim idNivelCod As Integer
        Dim descripcion As String


        Public Sub New(ByVal idNivel As Integer, ByVal descripcion As String)
            Me.idNivelCod = idNivel
            Me.descripcion = descripcion
        End Sub

        Property _idNivelCod() As Integer
            Get
                Return Me.idNivelCod
            End Get
            Set(ByVal value As Integer)
                Me.idNivelCod = value
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

        Public Overrides Function tostring() As String
            Return Me.descripcion
        End Function




    End Class

End Namespace

