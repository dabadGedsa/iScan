Namespace Entidades


    Public Class ClsCampoBarcode

        Dim idcampoBarcode As Integer
        Dim nombre As String
        Dim longitud As Integer
        Dim orden As Integer
        Dim idestructura As Integer


        Public Sub New(ByVal nombreCB As String, ByVal longitud As Integer, ByVal orden As Integer)
            nombre = nombreCB
            Me.longitud = longitud
            Me.orden = orden
        End Sub

        Public Property _idCampoBarcode() As Integer
            Get
                Return Me.idcampoBarcode
            End Get
            Set(ByVal value As Integer)
                Me.idcampoBarcode = value
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

        Public Property _longitud() As Integer
            Get
                Return Me.longitud
            End Get
            Set(ByVal value As Integer)
                Me.longitud = value
            End Set
        End Property

        Public Property _orden() As Integer
            Get
                Return Me.orden
            End Get
            Set(ByVal value As Integer)
                Me.orden = value
            End Set
        End Property

        Public Property _idestructura() As Integer
            Get
                Return idestructura
            End Get
            Set(ByVal value As Integer)
                Me.idestructura = value
            End Set
        End Property

    End Class

End Namespace