Namespace Entidades

    Public Class ClsEpisodio


        Dim Codificado As Boolean
        Dim Hospital As String
        Dim CIP As String
        Dim Nombre As String
        Dim Apellidos As String
        Dim Reside As String
        Dim TipoEpisodio As Integer
        Dim RegFin As String

        '[...] Faltan bastantes


        'necesarias para fmrCodificacion
        Dim NHC As String
        Dim FechaNacimiento As Date
        Dim FechaIngreso As Date
        Dim FechaAlta As Date
        Dim NumIcu As String
        Dim Sexo As Integer
        Dim Servicio As String
        Dim ActMed As String
        Dim FechaInt As Date
        Dim TipoIngreso As String
        Dim TipoAlta As String
        Dim Medico As String
        Dim strNivelCodificacion As String
        Dim inactivo As Boolean

        Dim servicioAlta As String
        Dim servicioIngreso As String
        Dim anatomiaPatologica As Boolean
        Dim medicoAlta As String

        Dim listaDocumentos As New SortedList(Of String, ClsDocumento)()



#Region "Constructores"


        Public Sub New()

        End Sub

        Public Sub New(ByVal nhc As String, ByVal numicu As String, ByVal fechaIngreso As String, ByVal servicio As String, ByVal strnivelCodificacion As String)

            Me.NHC = nhc
            Me.NumIcu = numicu
            Me.FechaIngreso = fechaIngreso
            Me.Servicio = servicio
            Me.strNivelCodificacion = strnivelCodificacion

            Me.inactivo = False

        End Sub

        Public Sub New(ByVal NHC As String, ByVal FechaNac As Date, ByVal FechaIng As Date, ByVal Fechaalta As Date, ByVal NunIcu As String, ByVal sexo As Integer, ByVal servicio As String, ByVal actMEd As String, ByVal fechaInt As Date, ByVal TipoIngreso As String, ByVal TipoAlta As String, ByVal Medico As String)

            Me.NHC = NHC
            Me.FechaNacimiento = FechaNac
            Me.FechaIngreso = FechaIng
            Me.FechaAlta = Fechaalta
            Me.NumIcu = NunIcu
            Me.Sexo = sexo
            Me.Servicio = servicio
            Me.ActMed = actMEd
            Me.FechaInt = fechaInt
            Me.TipoAlta = TipoAlta
            Me.Medico = Medico

            Me.inactivo = False

        End Sub

        Public Sub New(ByVal NHC As String, ByVal numIcu As String, ByVal hospital As String)

            Me.NHC = NHC
            Me.Hospital = hospital
            Me.NumIcu = numIcu

            Me.inactivo = False

        End Sub


#End Region

#Region "Modificadores/consultores"

        Public Property valorNHC() As String

            Get
                Return Me.NHC
            End Get
            Set(ByVal value As String)
                Me.NHC = value
            End Set
        End Property

        Public Property _strNivelcodificacion() As String
            Get
                Return Me.strNivelCodificacion
            End Get
            Set(ByVal value As String)
                Me.strNivelCodificacion = value
            End Set
        End Property

        Public Property valorFechaNAciemiento() As Date
            Get
                Return Me.FechaNacimiento
            End Get
            Set(ByVal value As Date)
                FechaNacimiento = value
            End Set
        End Property
        Public Property valorFEchaALta() As Date
            Get
                Return Me.FechaAlta
            End Get
            Set(ByVal value As Date)
                Me.FechaAlta = value
            End Set
        End Property
        Public Property valorNumIcu() As String
            Get
                Return Me.NumIcu
            End Get
            Set(ByVal value As String)
                Me.NumIcu = value
            End Set
        End Property
        Public Property valorSexo() As Integer
            Get
                Return Me.Sexo
            End Get
            Set(ByVal value As Integer)
                Me.Sexo = value
            End Set
        End Property
        Public Property valorServicio() As String
            Get
                Return Me.Servicio
            End Get
            Set(ByVal value As String)
                Me.Servicio = value
            End Set
        End Property

        Public Property valorServicioAlta() As String
            Get
                Return Me.servicioAlta
            End Get
            Set(ByVal value As String)
                Me.servicioAlta = value
            End Set
        End Property

        Public Property valorServicioIngreso() As String
            Get
                Return Me.servicioIngreso
            End Get
            Set(ByVal value As String)
                Me.servicioIngreso = value
            End Set
        End Property

        Public Property valorActMEd() As String
            Get
                Return Me.ActMed
            End Get
            Set(ByVal value As String)
                Me.ActMed = value
            End Set
        End Property
        Public Property valorFechaInt() As Date
            Get
                Return Me.FechaInt
            End Get
            Set(ByVal value As Date)
                Me.FechaInt = value
            End Set
        End Property
        Public Property valorTipoAlta() As String
            Get
                Return Me.TipoAlta
            End Get
            Set(ByVal value As String)
                Me.TipoAlta = value
            End Set
        End Property
        Public Property valorTipoIngreso() As String
            Get
                Return Me.TipoIngreso
            End Get
            Set(ByVal value As String)
                Me.TipoIngreso = value
            End Set
        End Property
        Public Property valorMedico() As String
            Get
                Return Me.Medico
            End Get
            Set(ByVal value As String)
                Me.Medico = value
            End Set
        End Property
        Public Property valorFechaIng() As Date
            Get
                Return Me.FechaIngreso
            End Get
            Set(ByVal value As Date)
                Me.FechaIngreso = value
            End Set
        End Property

        Public Property valorHospital() As String
            Get
                Return Me.Hospital
            End Get
            Set(ByVal value As String)
                Me.Hospital = value
            End Set
        End Property

        Public Property valorInactivo() As Boolean
            Get
                Return Me.inactivo
            End Get
            Set(ByVal value As Boolean)
                Me.inactivo = value
            End Set
        End Property

        Public Property valorNombre() As String
            Get
                Return Me.Nombre
            End Get
            Set(ByVal value As String)
                Me.Nombre = value
            End Set
        End Property

        Public Property valorApellidos() As String
            Get
                Return Me.Apellidos
            End Get
            Set(ByVal value As String)
                Me.Apellidos = value
            End Set
        End Property

        Public Property valorAnatomiaPatologica() As Boolean
            Get
                Return Me.anatomiaPatologica
            End Get
            Set(ByVal value As Boolean)
                Me.anatomiaPatologica = value
            End Set
        End Property

        Public Property valorListaDocumentos() As SortedList(Of String, ClsDocumento)
            Get
                Return Me.listaDocumentos
            End Get
            Set(ByVal value As SortedList(Of String, ClsDocumento))
                Me.listaDocumentos = value
            End Set
        End Property

        Public Property valorMedicoAlta() As String
            Get
                Return Me.medicoAlta
            End Get
            Set(ByVal value As String)
                Me.medicoAlta = value
            End Set
        End Property

#End Region

    End Class

End Namespace
