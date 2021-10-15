Namespace Entidades

    Public Class ClsTratamiento

        Protected codigo As String
        Public Property valorCodigo() As String
            Get
                Return codigo
            End Get
            Set(ByVal value As String)
                codigo = value
            End Set
        End Property

        Protected descripcion As String
        Public Property valorDescripcion() As String
            Get
                Return descripcion
            End Get
            Set(ByVal value As String)
                descripcion = value
            End Set
        End Property
        Protected Cie As String
        Public Property valorCie() As String
            Get
                Return Cie
            End Get
            Set(ByVal value As String)
                Cie = value
            End Set
        End Property
        Protected replicable As Boolean
        Public Property valorReplicable() As Boolean
            Get
                Return replicable
            End Get
            Set(ByVal value As Boolean)
                replicable = value
            End Set
        End Property

        Protected fecha As Date
        Public Property valorFecha() As Date
            Get
                Return Me.fecha
            End Get
            Set(ByVal value As Date)
                Me.fecha = value
            End Set
        End Property

        Protected NomICU As String
        Public Property valorNomICU() As String
            Get
                Return NomICU
            End Get
            Set(ByVal value As String)
                NomICU = value
            End Set
        End Property
        Protected orden As Integer
        Public Property valorOrden() As Integer
            Get
                Return orden
            End Get
            Set(ByVal value As Integer)
                orden = value
            End Set
        End Property

    End Class

End Namespace