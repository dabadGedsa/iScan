Namespace Entidades

    Public Class ClsServicio

        Private idServicio As Integer
        Private idServicioHospital As String
        Private codServicio As String
        Private descripcion As String

        Public Sub New(ByVal idServicio As Integer, ByVal codServicio As String)
            Me.idServicio = idServicio
            Me.codServicio = codServicio
        End Sub

        Public Sub New(ByVal idServicio As Integer, ByVal idServicioHospital As String, ByVal codServicio As String)
            Me.idServicio = idServicio
            Me.idServicioHospital = idServicioHospital
            Me.codServicio = codServicio
        End Sub

        Property _idservicio() As Integer
            Get
                Return Me.idServicio
            End Get
            Set(ByVal value As Integer)
                Me.idServicio = value
            End Set
        End Property

        Property _idservicioHospital() As String
            Get
                Return Me.idServicioHospital
            End Get
            Set(ByVal value As String)
                Me.idServicioHospital = value
            End Set
        End Property

        Property _codServicio() As String
            Get
                Return Me.codServicio
            End Get
            Set(ByVal value As String)
                Me.codServicio = value
            End Set
        End Property


        Public Overrides Function ToString() As String
            Return Me.idServicio & " - " & Me.codServicio
        End Function

    End Class

End Namespace
