Namespace Entidades


    Public Class clsEstructuraBarcode

        Dim idproyecto As String
        Dim inicioBarcode As String
        Dim idEstrucra As Integer


        Public Property _idproyecto() As String
            Get
                Return Me.idproyecto
            End Get
            Set(ByVal value As String)
                Me.idproyecto = value
            End Set
        End Property

        Public Property _inicioBarcode() As String
            Get
                Return Me.inicioBarcode
            End Get
            Set(ByVal value As String)
                Me.inicioBarcode = value
            End Set
        End Property

        Public Property _idEstructura() As Integer
            Get
                Return Me.idEstrucra
            End Get
            Set(ByVal value As Integer)
                Me.idEstrucra = value
            End Set
        End Property

        Public Overrides Function ToString() As String
            Return Me.inicioBarcode
        End Function


    End Class

End Namespace
