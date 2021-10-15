Namespace Entidades

    Public Class ClsUsuario

        Private id As Integer
        Private nombre As String
        Private apellidos As String
        Private login As String
        Private clave As String
        Private cargo As Integer
        Private esExterno As Boolean
        Private idRol As Integer
        Private idUltimaAccion As Integer

        Private episodiosAsignados As ArrayList

        Public Sub New(ByVal id As Integer, ByVal login As String)
            Me.id = id
            Me.login = login

            Me.episodiosAsignados = New ArrayList()
        End Sub
        Public Sub New(ByVal id As Integer, ByVal nombre As String, ByVal apellidos As String, ByVal login As String, ByVal clave As String, ByVal cargo As Integer)
            Me.id = id
            Me.login = login
            Me.nombre = nombre
            Me.apellidos = apellidos
            Me.clave = clave
            Me.cargo = cargo

            Me.episodiosAsignados = New ArrayList()
        End Sub



        Public Overrides Function ToString() As String
            Return login
        End Function

        Public Property _login() As String
            Get
                Return Me.login
            End Get
            Set(ByVal value As String)
                Me.login = value
            End Set
        End Property

        Public Property _id() As Integer
            Get
                Return Me.id
            End Get
            Set(ByVal value As Integer)
                Me.id = value
            End Set
        End Property


        Public Property _idRol() As Integer
            Get
                Return Me.idRol
            End Get
            Set(ByVal value As Integer)
                Me.idRol = value
            End Set
        End Property


        Public Property _idUltimaAccion() As Integer
            Get
                Return Me.idUltimaAccion
            End Get
            Set(ByVal value As Integer)
                Me.idUltimaAccion = value
            End Set
        End Property

        Public Property _cargo() As Integer
            Get
                Return Me.cargo
            End Get
            Set(ByVal value As Integer)
                Me.cargo = value
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

        Public Property _apellidos() As String
            Get
                Return Me.apellidos
            End Get
            Set(ByVal value As String)
                Me.apellidos = value
            End Set
        End Property

        Public Property _clave() As String
            Get
                Return Me.clave
            End Get
            Set(ByVal value As String)
                Me.clave = value
            End Set
        End Property

        Public Property _episodiosAsignados() As ArrayList
            Get
                Return Me.episodiosAsignados
            End Get
            Set(ByVal value As ArrayList)
                Me.episodiosAsignados = value
            End Set
        End Property

    End Class

End Namespace
