Namespace Entidades

    Public Class clsProyecto


        Dim codigoProyecto As String
        Dim nombreProyecto As String
        Dim rutaConfiguracion As String
        Dim NumeroLotes As String
        Dim RutaLoteado As String
        Dim NecesitaComoprobarLoteado As Boolean
        Dim NecesitaComprobarIcus As Boolean
        Dim NecesitaComprobarHistorias As Boolean
        Dim rutalotes As String                         'ruta donde se encuentran los lotes
        Dim rutaImagenes As String
        Dim codigoHospital As String
        Dim CrearDAT As String
        Dim ServidorBaseDatos As String
        Dim usuarioBaseDAtos As String
        Dim ClaveBaseDAtos As String
        Dim NombreBAseDatos As String



#Region "constructores"

        Public Sub New()

        End Sub


        Public Sub New(ByVal codigoproyecto As String, ByVal nombreProyecto As String)

            Me.codigoProyecto = codigoproyecto
            Me.nombreProyecto = nombreProyecto

        End Sub


        Public Sub New(ByVal codigoproyecto As String, ByVal nombreProyecto As String, ByVal rutaImagenes As String, _
                       ByVal servidorBaseDAtos As String, ByVal userdbo As String, ByVal pasdbo As String, ByVal nombredbo As String)

            Me.codigoProyecto = codigoproyecto
            Me.nombreProyecto = nombreProyecto
            Me.rutaImagenes = rutaImagenes
            Me.ServidorBaseDatos = servidorBaseDAtos
            Me.usuarioBaseDAtos = userdbo
            Me.ClaveBaseDAtos = pasdbo
            Me.NombreBAseDatos = nombredbo

        End Sub

        Public Sub New(ByVal codigoproyecto As String, ByVal nombreProyecto As String, ByVal codigohospital As String, ByVal rutaImagenes As String)

            Me.codigoProyecto = codigoproyecto
            Me.nombreProyecto = nombreProyecto
            Me.codigoHospital = codigohospital
            Me.rutaImagenes = rutaImagenes

        End Sub

#End Region


#Region "propiedades de la clase proyectos"

        Property _rutaLotesProyecto() As String
            Get
                Return Me.rutalotes
            End Get
            Set(ByVal value As String)
                Me.rutalotes = value
            End Set
        End Property

        Property _rutaImagenes() As String
            Get
                Return Me.rutaImagenes
            End Get
            Set(ByVal value As String)
                Me.rutaImagenes = value
            End Set
        End Property


        Property _CodigoProyecto() As String
            Get
                Return Me.codigoProyecto
            End Get
            Set(ByVal value As String)
                Me.codigoProyecto = value
            End Set
        End Property

        'literal del proyecto 
        Property _nombreProyecto() As String
            Get
                Return Me.nombreProyecto
            End Get
            Set(ByVal value As String)
                Me.nombreProyecto = value
            End Set
        End Property

        Property _codigoHospital() As String
            Get
                Return Me.codigoHospital
            End Get
            Set(ByVal value As String)
                Me.codigoHospital = value
            End Set
        End Property

        Property _CrearDAT() As String
            Get
                Return Me.CrearDAT
            End Get
            Set(ByVal value As String)
                Me.CrearDAT = value
            End Set
        End Property

        Property _NombreBaseDatos() As String
            Get
                Return Me.NombreBAseDatos
            End Get
            Set(ByVal value As String)
                Me.NombreBAseDatos = value
            End Set
        End Property

        ReadOnly Property _obtenerCadenaConexionProyecto() As String
            Get
                If Me.ServidorBaseDatos = "NAN" Then
                    Return "NAN" 'cuando no encuentra una base de datos lo indica asi 
                Else
                    Return "server=" & Me.ServidorBaseDatos & ";uid=" & Me.usuarioBaseDAtos & ";pwd=" & Me.ClaveBaseDAtos & ";database=" & Me.NombreBAseDatos
                End If

            End Get
        End Property


#End Region





        Public Overrides Function ToString() As String
            Return Me.codigoProyecto & " - " & Me.nombreProyecto
        End Function


    End Class

End Namespace