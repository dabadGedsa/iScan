Public Class clsDocumento

    ''' <summary>
    ''' Funcion para comprobar si todas las imagenes existen 
    ''' </summary>
    ''' <param name="pagina"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function imagenes_comprueba(ByRef dt_documentos As DataTable, ByVal imagenes_ruta As String, Optional ByVal pagina As Integer = 0) As Integer
        Dim correcto As Boolean = True
        If pagina < dt_documentos.Rows.Count - 1 AndAlso pagina >= 0 AndAlso dt_documentos.Rows.Count - 1 > 0 Then
            For i As Integer = pagina To dt_documentos.Rows.Count - 1
                If Not IO.File.Exists(imagenes_ruta & "\" & dt_documentos(i).Item("NomArchivo").ToString()) Then
                    'Devuelve el numero de pagina que falta
                    Return i
                End If
            Next
            'Devolvemos que todas las imagenes existen
            Return -1

        End If
        'No ha cumplido las condiciones
        Return -2

    End Function

End Class
