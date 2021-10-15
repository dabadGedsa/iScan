Public Class clsParametro
    Public var_parametro1 As String
    Public var_parametro2 As String

    Sub New(ByVal parametro1 As String, ByVal parametro2 As String)
        var_parametro1 = parametro1
        var_parametro2 = parametro2
    End Sub

    Sub New()
        var_parametro1 = ""
        var_parametro2 = ""
    End Sub

End Class
