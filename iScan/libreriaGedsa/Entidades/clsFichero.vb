Public Class clsFichero



    Dim nombre As String
    Dim nombreOriginal As String
    Dim rutaOriginal As String
    Dim id As Integer


    Public Sub New(ByVal rutaOriginal As String)

        Me.rutaOriginal = rutaOriginal
        Me.nombreOriginal = Mid(rutaOriginal, 1 + InStrRev(rutaOriginal, "\", -1))

    End Sub

    ReadOnly Property leerid() As Integer
        Get
            Return Me.id
        End Get
    End Property

    WriteOnly Property Asignarid() As Integer
        Set(ByVal value As Integer)
            Me.id = value
        End Set
    End Property

    ReadOnly Property leerNombre() As String
        Get
            Return Me.nombre
        End Get
    End Property

    WriteOnly Property AsignarNombre() As String
        Set(ByVal value As String)
            Me.nombre = value
        End Set
    End Property

    ReadOnly Property leerNombreOriginal() As String
        Get
            Return Me.nombreOriginal
        End Get
    End Property

    WriteOnly Property AsignarNombreOriginal() As String
        Set(ByVal value As String)
            Me.nombreOriginal = value
        End Set
    End Property


    Public Overrides Function ToString() As String
        Return Me.nombreOriginal
    End Function

End Class
