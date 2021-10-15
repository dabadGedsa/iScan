Namespace Entidades

    Public Class ClsColectivo

        Private _cia As String
        Private _codigo As String
        Private _descripcion As String

        Public Sub New()

        End Sub

        Public Sub New(ByVal cia As String, ByVal codigo As Integer, ByVal descripcion As String)

            Me._cia = cia
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

        Public Property cia() As Integer
            Get
                Return Me._cia
            End Get
            Set(ByVal value As Integer)
                Me._cia = value
            End Set
        End Property

        Public Overrides Function ToString() As String
            Return Me._descripcion
        End Function

    End Class

End Namespace
