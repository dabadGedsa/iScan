Namespace Entidades


   


    Public Class ClsEntradaCMBD

        Private Nombre As String
        Private Apellido1 As String
        Private Apellido2 As String
        Private NumIcu As String
        Private NHC As String
        Private FechaIngreso As Date
        Private FechaAlta As Date
      
      
        
#Region "Constructores"

        Public Sub New(ByVal NumIcu As String, ByVal NHC As String, ByVal fechaIng As Date, ByVal fecalt As Date, _
        ByVal Nombre As String, ByVal apellido1 As String, ByVal apellido2 As String)

            Me.NumIcu = NumIcu
            Me.NHC = NHC
            Me.FechaIngreso = fechaIng
            Me.FechaAlta = fecalt
            Me.Nombre = Nombre
            Me.Apellido1 = apellido1
            Me.Apellido2 = apellido2


        End Sub


#End Region




#Region "Propiedades"

        Public Property _Nombre() As String
            Get
                Return Nombre
            End Get
            Set(ByVal value As String)
                Nombre = value
            End Set
        End Property

        Public Property _Apellido1() As String
            Get
                Return Apellido1
            End Get
            Set(ByVal value As String)
                Apellido1 = value
            End Set
        End Property

        Public Property _Apellido2() As String
            Get
                Return Apellido2
            End Get
            Set(ByVal value As String)
                Apellido2 = value
            End Set
        End Property

        Public Property _NumIcu() As String
            Get
                Return NumIcu
            End Get
            Set(ByVal value As String)
                NumIcu = value
            End Set
        End Property

        Public Property _NHC() As String
            Get
                Return NHC
            End Get
            Set(ByVal value As String)
                NHC = value
            End Set
        End Property

        Public Property _FechaIngreso() As Date
            Get
                Return FechaIngreso
            End Get
            Set(ByVal value As Date)
                FechaIngreso = value
            End Set
        End Property

        Public Property _FechaAlta() As Date
            Get
                Return FechaAlta
            End Get
            Set(ByVal value As Date)
                FechaAlta = value
            End Set
        End Property

        Public ReadOnly Property _NombreCompleto() As String
            Get
                Return Me.Nombre & " " & Me.Apellido1 & " " & Me.Apellido2
            End Get
        End Property

#End Region

#Region "Funciones"



        Public Overrides Function ToString() As String

            Return Me.NHC


        End Function




#End Region


    End Class



End Namespace
