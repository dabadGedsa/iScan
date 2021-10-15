Namespace Entidades

    Public Class ClsMorfologia

        Private codigo As String
        Public Property valorCodigo() As String
            Get
                Return codigo
            End Get
            Set(ByVal value As String)
                codigo = value
            End Set
        End Property

        Private descripcion As String
        Public Property valorDescripcion() As String
            Get
                Return descripcion
            End Get
            Set(ByVal value As String)
                descripcion = value
            End Set
        End Property
        Private Cie As String
        Public Property valorCie() As String
            Get
                Return Cie
            End Get
            Set(ByVal value As String)
                Cie = value
            End Set
        End Property
        Private replicable As Boolean
        Public Property valorReplicable() As Boolean
            Get
                Return replicable
            End Get
            Set(ByVal value As Boolean)
                replicable = value
            End Set
        End Property

        Private NomICU As String
        Public Property valorNomICU() As String
            Get
                Return NomICU
            End Get
            Set(ByVal value As String)
                NomICU = value
            End Set
        End Property

        Private orden As Integer
        Public Property valorOrden() As Integer
            Get
                Return orden
            End Get
            Set(ByVal value As Integer)
                orden = value
            End Set
        End Property

        Private esPrincipal As Boolean
        Public Property valorEsPrincipal() As Boolean
            Get
                Return Me.esPrincipal
            End Get
            Set(ByVal value As Boolean)
                Me.esPrincipal = value
            End Set
        End Property

        Public Sub New(ByVal codigo As String, ByVal descropcion As String, ByVal Cie As String, ByVal replicable As String, ByVal nomicu As String, ByVal orden As Integer)

            Me.codigo = codigo
            Me.descripcion = descropcion
            Me.Cie = Cie
            Me.replicable = Boolean.Parse(replicable)
            Me.NomICU = nomicu
            Me.orden = orden

        End Sub

        Public Sub New(ByVal codigo As String, ByVal descropcion As String, ByVal Cie As String, ByVal replicable As String, ByVal nomicu As String, ByVal orden As Integer, ByVal esPrincipal As Boolean)

            Me.New(codigo, descropcion, Cie, replicable, nomicu, orden)
            Me.esPrincipal = esPrincipal

        End Sub

    End Class
End Namespace