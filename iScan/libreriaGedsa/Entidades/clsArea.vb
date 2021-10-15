Namespace Entidades

    Public Class ClsArea

        Private idArea As Integer
        Private cod_area As String
        Private descripcion As String

        Public Sub New(ByVal idArea As Integer, ByVal cod_area As String)
            Me.idArea = idArea
            Me.cod_area = cod_area
        End Sub


        Property _idArea() As Integer
            Get
                Return Me.idArea
            End Get
            Set(ByVal value As Integer)
                Me.idArea = value
            End Set
        End Property

        Property _cod_area() As String
            Get
                Return Me.cod_area
            End Get
            Set(ByVal value As String)
                Me.cod_area = value
            End Set
        End Property


        Public Overrides Function ToString() As String
            Return Me.idArea & " - " & Me.cod_area
        End Function

    End Class

End Namespace