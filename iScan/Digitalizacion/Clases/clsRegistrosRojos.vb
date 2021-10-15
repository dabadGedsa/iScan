''' <summary>
''' Esta clase se utiliza para el movimiento de registros por la zona roja,
''' por defecto se le pasa por referencia la grid ¿? todavia por definir
''' </summary>
''' <remarks></remarks>
Public Class clsRegistrosRojos

    Dim rojos As System.Collections.Generic.List(Of DataRow) 'As IEnumerable(Of DataRow)
    Dim rojos_indice As Integer = 0

#Region "Constructores y Destuctores"

    Sub New()

    End Sub

    ''' <summary>
    ''' Reinciamos las propiedades de la clase 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub reincio(ByRef tmpRojos As System.Collections.Generic.List(Of DataRow))
        rojos = tmpRojos

        rojos_indice = 0
    End Sub

    ''' <summary>
    ''' Destrucción del objeto
    ''' </summary>
    ''' <remarks></remarks>
    Sub dispose()

    End Sub

#End Region

#Region "Funciones de Indice"

    Public Function RowCount() As Integer
        Return rojos.Count
    End Function


    ''' <summary>
    ''' Devuelve a partir de un datarow el indice donde se encuentra el elemento 
    ''' En el caso de no encontrarlo, devuelve -1
    ''' </summary>
    ''' <param name="registro">Datarow de registro que queremos buscar</param>
    ''' <returns>Indice del elemento buscado, -1 si no se encuentra</returns>
    ''' <remarks></remarks>
    Public Function indice_busca(ByRef registro As DataRow) As Integer
        Return rojos.IndexOf(registro)
    End Function

    ''' <summary>
    ''' Situamos en la posicion pasada por parámetro el indice de posicion, devolvemos
    ''' false si no se encuentra en el rango
    ''' </summary>
    ''' <param name="posicion"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function indice_situa(ByVal posicion As Integer) As Boolean
        If posicion < 0 Or posicion >= rojos.Count Then
            Return False
        Else
            rojos_indice = posicion
            Return True
        End If
    End Function

    ''' <summary>
    ''' Movimiento del indice del registro de los registros con incidencias
    ''' </summary>
    ''' <param name="direccion"></param>
    ''' <remarks></remarks>
    Public Function indice_mover(ByVal direccion As Integer) As Boolean

        'El registro puede moverse arriba o abajo, segun el indice
        If rojos.Count > 0 Then

            Select Case direccion
                Case 0
                    rojos_indice -= 1
                    If rojos_indice < 0 Then rojos_indice = 0
                Case 1
                    rojos_indice += 1
                    If rojos_indice > rojos.Count - 1 Then rojos_indice = rojos.Count - 1
                Case 2
                    rojos_indice -= 20
                    If rojos_indice < 0 Then rojos_indice = 0
                Case 3
                    rojos_indice += 20
                    If rojos_indice > rojos.Count - 1 Then rojos_indice = rojos.Count - 1
                Case 4
                    rojos_indice = 0
                Case 5
                    rojos_indice = rojos.Count - 1
            End Select

            Return True
        Else
            'Si no existen registros
            Return False
        End If

    End Function

    ''' <summary>
    ''' Devuelve el valor (string) del campo del registro que esté seleccionado en la clase
    ''' </summary>
    ''' <param name="campo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function indice_campo(ByVal campo As String) As String
        Try
            Return rojos.Item(rojos_indice).Item(campo).ToString()
        Catch ex As Exception
            MsgBox("Error en el campo: " & ex.Message, MsgBoxStyle.Critical, "Incidencia de aplicacion")
        End Try
        Return Nothing

    End Function

    ''' <summary>
    ''' Devuelve un conjunto a partir de un ID
    ''' </summary>
    ''' <param name="ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function registro_buscaID(ByVal ID As String)
        Return (From elemento As DataRow In rojos Where elemento.Item("ID").ToString = ID).ToList
    End Function


#End Region


End Class
