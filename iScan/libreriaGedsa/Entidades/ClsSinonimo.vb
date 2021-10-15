Namespace Entidades

    Public Class ClsSinonimo

        Dim codigo As String
        Dim descripcion As String


        Public Sub New(ByVal codi As String, ByVal dscr As String)

            codigo = codi
            Me.descripcion = dscr


        End Sub


        Public Function getCodigo()
            Return Me.codigo
        End Function

        Public Function getDescripcion()
            Return Me.descripcion
        End Function


        Public Sub setCodigo(ByVal valor As String)
            Me.codigo = valor
        End Sub

        Public Sub gsetDescripcion(ByVal valor As String)
            Me.descripcion = valor
        End Sub

        Public Overrides Function ToString() As String

            Return Me.codigo ' & " " & Me.descripcion



        End Function


    End Class



End Namespace
