Namespace Entidades

    Public Class ClsParto

        Private NumParto As Integer
        Private fechaParto As DateTime
        Private hora As String
        Private semanasGestacion As Integer
        Private sexo As Integer
        Private peso As Integer
        Private situacion As Integer
        Private hospital As String
        Private NHC As String
        Private episodio As String

        Public Sub New(ByVal numParto As Integer, ByVal fechaParto As Date, ByVal hora As String, ByVal semanasGestacion As Integer, _
                       ByVal sexo As Integer, ByVal peso As Integer, ByVal situacion As Integer, ByVal hospital As String, _
                       ByVal nhc As String, ByVal episodio As String)

            Me.NumParto = numParto
            Me.fechaParto = fechaParto
            Me.hora = hora
            Me.semanasGestacion = semanasGestacion
            Me.sexo = sexo
            Me.peso = peso
            Me.situacion = situacion
            Me.hospital = hospital
            Me.NHC = nhc
            Me.episodio = episodio

        End Sub

        Public Property valorNumParto() As Integer
            Get
                Return NumParto
            End Get
            Set(ByVal value As Integer)
                NumParto = value
            End Set
        End Property


        Public Property valorFechaParto() As DateTime
            Get
                Return fechaParto
            End Get
            Set(ByVal value As DateTime)
                fechaParto = value
            End Set
        End Property


        Public Property valorHoraNacimiento() As String
            Get
                Return hora
            End Get
            Set(ByVal value As String)
                hora = value
            End Set
        End Property

        Public Property valorSemanasGestacion() As Integer
            Get
                Return semanasGestacion
            End Get
            Set(ByVal value As Integer)
                semanasGestacion = value
            End Set
        End Property


        Public Property valorSexo() As Integer
            Get
                Return sexo
            End Get
            Set(ByVal value As Integer)
                sexo = value
            End Set
        End Property


        Public Property valorPeso() As Integer
            Get
                Return peso
            End Get
            Set(ByVal value As Integer)
                peso = value
            End Set
        End Property

        Public Property valorSituacion() As Integer
            Get
                Return situacion
            End Get
            Set(ByVal value As Integer)
                situacion = value
            End Set
        End Property


        Public Property valorHospital() As String
            Get
                Return hospital
            End Get
            Set(ByVal value As String)
                hospital = value
            End Set
        End Property


        Public Property valorNHC() As String
            Get
                Return NHC
            End Get
            Set(ByVal value As String)
                NHC = value
            End Set
        End Property

        Public Property valorEpisodio() As String
            Get
                Return episodio
            End Get
            Set(ByVal value As String)
                episodio = value
            End Set
        End Property


        Public Function validar() As Boolean

            Dim esValido As Boolean = True


            'validar un parto!!!!

            Return esValido

        End Function


    End Class

End Namespace
