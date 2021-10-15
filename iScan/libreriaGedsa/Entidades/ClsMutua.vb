Namespace Entidades

    Public Class ClsMutua

        Private _cia As String
        Private _mutua As String

        Public Sub New()

        End Sub

        Public Sub New(ByVal cia As Integer, ByVal mutua As String)

            Me._cia = cia
            Me._mutua = mutua

        End Sub

        Public Property cia() As Integer
            Get
                Return Me._cia
            End Get
            Set(ByVal value As Integer)
                Me._cia = value
            End Set
        End Property

        Public Property mutua() As String
            Get
                Return Me._mutua
            End Get
            Set(ByVal value As String)
                Me._mutua = value
            End Set
        End Property

        Public Overrides Function ToString() As String
            Return Me._mutua
        End Function

    End Class

End Namespace