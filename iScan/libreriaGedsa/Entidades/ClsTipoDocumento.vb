Namespace Entidades

    Public Class ClsTipoDocumento


        Private _codigo As Integer
        Private _hospital As Integer
        Private _definicion As String
        Private _descipcion As String


        Public Sub New()

        End Sub


        Public Sub New(ByVal codigo As Integer, ByVal descripcion As String)

            Me._codigo = codigo
            Me._descipcion = descripcion

        End Sub

        Public Sub New(ByVal codigo As Integer, ByVal definicion As String, ByVal descripcion As String)

            Me._codigo = codigo
            Me._definicion = definicion
            Me._descipcion = descripcion

        End Sub

        Public Property codigo() As Integer
            Get
                Return Me._codigo
            End Get
            Set(ByVal value As Integer)
                Me._codigo = value
            End Set
        End Property


        Public Property hospital() As Integer
            Get
                Return Me._hospital
            End Get
            Set(ByVal value As Integer)
                Me._hospital = value
            End Set
        End Property


        Public Property descripcion() As String
            Get
                Return Me._descipcion
            End Get
            Set(ByVal value As String)
                Me._descipcion = value
            End Set
        End Property

        Public Property definicion() As String
            Get
                Return Me._definicion
            End Get
            Set(ByVal value As String)
                Me._definicion = value
            End Set
        End Property

        Public Overrides Function ToString() As String
            Return Me.codigo & " - " & Me.descripcion
        End Function


    End Class

End Namespace
