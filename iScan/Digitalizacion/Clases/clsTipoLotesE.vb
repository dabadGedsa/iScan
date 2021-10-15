Namespace Entidades

    Public Class clsTipoLotesE

        Private idProyecto As String
        Private Nombre As String
        Private PrefijoVolumen As String
        Private PrefijoCB As String

        Public Sub New(ByVal idProyecto As String, ByVal Nombre As String, ByVal PrefijoVolumen As String, ByVal PrefijoCB As String)
            Me.idProyecto = idProyecto
            Me.Nombre = Nombre
            Me.PrefijoVolumen = PrefijoVolumen
            Me.PrefijoCB = PrefijoCB
        End Sub


        Property _idProyecto() As String
            Get
                Return Me.idProyecto
            End Get
            Set(ByVal value As String)
                Me.idProyecto = value
            End Set
        End Property

        Property _Nombre() As String
            Get
                Return Me.Nombre
            End Get
            Set(ByVal value As String)
                Me.Nombre = value
            End Set
        End Property

        Property _PrefijoVolumen() As String
            Get
                Return Me.PrefijoVolumen
            End Get
            Set(ByVal value As String)
                Me.PrefijoVolumen = value
            End Set
        End Property

        Property _PrefijoCB() As String
            Get
                Return Me.PrefijoCB
            End Get
            Set(ByVal value As String)
                Me.PrefijoCB = value
            End Set
        End Property

        'Public Overrides Function ToString() As String
        '    Return Me.idArea & " - " & Me.cod_area
        'End Function

    End Class

End Namespace
