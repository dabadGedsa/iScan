Namespace Entidades


    Public Class clsRegistroTXT


        Dim contador, NumeroHistoria, NombreImagenDocumento, FechaInicio As String
        Dim FechaFin, NombrePath, TipoDocumento, NumeroEpisodio, TipoEpisodio, CodigoServicio, OrigenDocumento As String


        Public Sub New(ByVal contador As Integer, ByVal NumeroHistoria As String, ByVal NombreImagenDocumento As String, ByVal FechaInicio As String, ByVal FechaFin As String, ByVal NombrePath As String, ByVal TipoDocumento As String, ByVal NumeroEpisodio As String, ByVal TipoEpisodio As String, ByVal CodigoServicio As String)

            Me.contador = contador
            Me.NumeroHistoria = NumeroHistoria
            Me.NombreImagenDocumento = NombreImagenDocumento
            Me.FechaInicio = FechaInicio
            Me.FechaFin = FechaFin
            Me.NombrePath = NombrePath
            Me.TipoDocumento = TipoDocumento
            Me.NumeroEpisodio = NumeroEpisodio
            Me.TipoEpisodio = TipoEpisodio
            Me.CodigoServicio = CodigoServicio

        End Sub

        Public ReadOnly Property pcontador() As Integer
            Get
                Return Me.contador
            End Get
        End Property

        Public Property pNumeroHistoria() As String
            Get
                Return Me.NumeroHistoria
            End Get
            Set(ByVal value As String)
                Me.NumeroHistoria = value
            End Set
        End Property

        Public Property pNombreImagenDocumento() As String
            Get
                Return Me.NombreImagenDocumento
            End Get
            Set(ByVal value As String)
                Me.NombreImagenDocumento = value
            End Set
        End Property

        Public Property pFechaInicio() As String
            Get
                Return Me.FechaInicio
            End Get
            Set(ByVal value As String)
                Me.FechaInicio = value
            End Set
        End Property

        Public Property pFechaFin() As String
            Get
                Return Me.FechaFin
            End Get
            Set(ByVal value As String)
                Me.FechaFin = value
            End Set
        End Property

        Public Property pNombrePath() As String
            Get
                Return Me.NombrePath
            End Get
            Set(ByVal value As String)
                Me.NombrePath = value
            End Set
        End Property


        Public Property pTipoDocumento() As String
            Get
                Return Me.TipoDocumento
            End Get
            Set(ByVal value As String)
                Me.TipoDocumento = value
            End Set
        End Property

        Public Property pNumeroEpisodio() As String
            Get
                Return Me.NumeroEpisodio
            End Get
            Set(ByVal value As String)
                Me.NumeroEpisodio = value
            End Set
        End Property

        Public Property pTipoEpisodio() As String
            Get
                Return Me.TipoEpisodio
            End Get
            Set(ByVal value As String)
                Me.TipoEpisodio = value
            End Set
        End Property

        Public Property pCodigoServicio() As String
            Get
                Return Me.CodigoServicio
            End Get
            Set(ByVal value As String)
                Me.CodigoServicio = value
            End Set
        End Property


    End Class

End Namespace