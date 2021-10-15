Namespace Entidades


    Public Class clsHistoriaClinica


        Dim NHC As String



        Public Property NumeroHistoria() As String
            Get
                Return Me.NHC
            End Get
            Set(ByVal value As String)
                Me.NHC = value
            End Set
        End Property

    End Class

End Namespace

