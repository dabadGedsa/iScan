Namespace Entidades

    Public Class ClsTratamientoQuirurjico
        Inherits ClsTratamiento

        Public Sub New(ByVal codigo As String, ByVal descropcion As String, ByVal Cie As String, ByVal replicable As String, ByVal fech As String, ByVal nomicu As String, ByVal ord As Integer)

            Me.codigo = codigo
            Me.descripcion = descropcion
            Me.Cie = Cie
            Me.replicable = Boolean.Parse(replicable)
            If fech = "" Then
                Me.fecha = Date.Now
            Else
                Me.fecha = Date.Parse(fech)
            End If

            Me.NomICU = nomicu
            Me.orden = ord


        End Sub

    End Class

End Namespace
