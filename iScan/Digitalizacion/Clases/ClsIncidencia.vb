Public Class ClsIncidencia



    Dim idIncidenia As Integer
    Dim descripcion As String
    Dim codigoTecla As Integer


    Public Sub New()

    End Sub

    Public Sub New(ByVal idincidencia As Integer, ByVal descripcion As String, ByVal codigotecla As Integer)
        Me.idIncidenia = idincidencia
        Me.descripcion = descripcion
        Me.codigoTecla = codigotecla
    End Sub

    Public ReadOnly Property Getidincidencia() As Integer
        Get
            Return Me.idIncidenia
        End Get
    End Property

    Public WriteOnly Property SetidIncidencia() As Integer
        Set(ByVal value As Integer)
            Me.idIncidenia = value
        End Set
    End Property


    Public ReadOnly Property GetDescripcion() As String
        Get
            Return Me.descripcion
        End Get
    End Property


    Public WriteOnly Property SetDescripcion() As String
        Set(ByVal value As String)
            Me.descripcion = value
        End Set
    End Property


    Public ReadOnly Property GetCodigoTecla() As Integer
        Get
            Return Me.codigoTecla
        End Get
    End Property


    Public WriteOnly Property SEtcodigotecla() As Integer
        Set(ByVal value As Integer)
            Me.codigoTecla = value
        End Set
    End Property



    Public Overrides Function ToString() As String
        Return Me.descripcion
    End Function


End Class
