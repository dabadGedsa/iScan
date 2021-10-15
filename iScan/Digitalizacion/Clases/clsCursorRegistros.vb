''' <summary>
''' Esta clase se utiliza para el movimiento de registros por la zona roja,
''' por defecto se le pasa por referencia la grid ¿? todavia por definir
''' </summary>
''' <remarks></remarks>
Public Class clsCursorRegistros

    Dim totalRegistros As DataTable

    Dim tipo As Integer

    Dim registros As System.Collections.Generic.List(Of DataRow) 'As IEnumerable(Of DataRow)
    Dim registros_indice As Integer

    Public registro_aleatorio_porcentaje As Integer

#Region "Constructores y Destuctores"

    Sub New()
        registros_indice = 0
        registro_aleatorio_porcentaje = 30
    End Sub

    Function registros_devuelve(ByVal tipo As Integer) As System.Collections.Generic.List(Of DataRow)
        'Dim registros As System.Collections.Generic.List(Of DataRow) = (From reg As DataRow In totalRegistros).ToList
        Select Case tipo
            Case 1
                'Listado Normal, todos los registros
                Return registros_aleatorio(totalRegistros, registro_aleatorio_porcentaje)
            Case 2
                'Listado documentos críticos
                'TipoDocumento=1 or TipoDocumento=2 or TipoDocumento=4 or TipoDocumento=110
                Return (From reg As DataRow In totalRegistros Where reg.Item("TipoDocumento").ToString = "1" OrElse reg.Item("TipoDocumento").ToString = "2" OrElse reg.Item("TipoDocumento").ToString = "4" OrElse reg.Item("TipoDocumento").ToString = "110" Order By reg.Item("pagina")).ToList
            Case Else
                'Caso 0, todos los registros
                Return (From reg As DataRow In totalRegistros Order By reg.Item("pagina")).ToList
        End Select

    End Function


    Function registros_aleatorio(ByRef coleccion As DataTable, ByVal porcentaje As Integer)

        'Numero de registros que se han de buscar en el porcentaje
        Dim numeroRegistros As Integer = coleccion.Rows.Count - ((coleccion.Rows.Count * porcentaje) / 100)
        Dim rnd As New Random(Now.Second)
        Dim nuevo As System.Collections.Generic.List(Of DataRow) = (From reg As DataRow In totalRegistros Order By reg.Item("pagina")).ToList

        For i As Integer = 0 To numeroRegistros - 1
            nuevo.RemoveAt(rnd.Next(0, nuevo.Count - 1))
        Next

        'Ordeno los elementos
        Return nuevo

    End Function

    ''' <summary>
    ''' Reinciamos las propiedades de la clase 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub reinicio(ByRef tmpRegistros As DataTable, ByVal tmpTipo As Integer)
        tipo = tmpTipo
        totalRegistros = tmpRegistros
        registros = registros_devuelve(tipo)
        registros_indice = 0
    End Sub

    ''' <summary>
    ''' Destrucción del objeto
    ''' </summary>
    ''' <remarks></remarks>
    Sub dispose()

    End Sub

#End Region

#Region "Funciones de Indice"

    Public Function Row(ByVal item As Integer) As DataRow
        Return registros(item)
    End Function

    Public Function CurrentRow() As DataRow
        Return registros(registros_indice)
    End Function

    Public Function CurrentID() As Integer
        Return registros_indice
    End Function

    Public Function RowCount() As Integer
        Try
            Return registros.Count
        Catch ex As Exception
            MsgBox("Incidencia RowCount(), La clase registros no se ha incializado." & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Incidencia de aplicacion")
            Return -1
        End Try

    End Function


    ''' <summary>
    ''' Devuelve a partir de un datarow el indice donde se encuentra el elemento 
    ''' En el caso de no encontrarlo, devuelve -1
    ''' </summary>
    ''' <param name="registro">Datarow de registro que queremos buscar</param>
    ''' <returns>Indice del elemento buscado, -1 si no se encuentra</returns>
    ''' <remarks></remarks>
    Public Function indice_busca(ByRef registro As DataRow) As Integer
        Return registros.IndexOf(registro)
    End Function

    Public Sub indice_situa(ByVal posicion As Integer)
        If posicion >= 0 Or posicion < registros.Count Then registros_indice = posicion
    End Sub

    ''' <summary>
    ''' Situamos en la posicion pasada por parámetro el indice de posicion, devolvemos
    ''' false si no se encuentra en el rango
    ''' </summary>
    ''' <param name="posicion"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function indice_situa(ByVal posicion As Integer, ByRef grd As DataGridView) As Boolean
        If posicion >= 0 Or posicion < registros.Count Then
            Dim encontrado As DataGridViewRow = registro_buscaPagina(registros(posicion).Item("pagina").ToString, grd)
            If encontrado IsNot Nothing Then
                registros_indice = posicion
                If grd IsNot Nothing Then grd.CurrentCell = encontrado.Cells("pagina")
                Return True
            End If
        End If
        Return False
    End Function

    Public Function indice_situa(ByRef grd As DataGridView) As Boolean
        Dim encontrado As DataGridViewRow = registro_buscaPagina(registros(registros_indice).Item("pagina").ToString, grd)
        If encontrado IsNot Nothing Then
            If grd IsNot Nothing Then grd.CurrentCell = encontrado.Cells("pagina")
            Return True
        End If
        Return False
    End Function

    ''' <summary>
    ''' Movimiento del indice del registro de los registros con incidencias
    ''' </summary>
    ''' <param name="direccion"></param>
    ''' <remarks></remarks>
    Public Function indice_mover(ByVal direccion As Integer, Optional ByRef grd As DataGridView = Nothing) As Boolean

        'El registro puede moverse arriba o abajo, segun el indice
        If registros.Count > 0 Then

            Select Case direccion
                Case 0
                    registros_indice -= 1
                    If registros_indice < 0 Then registros_indice = 0
                Case 1
                    registros_indice += 1
                    If registros_indice > registros.Count - 1 Then registros_indice = registros.Count - 1
                Case 2
                    registros_indice -= 20
                    If registros_indice < 0 Then registros_indice = 0
                Case 3
                    registros_indice += 20
                    If registros_indice > registros.Count - 1 Then registros_indice = registros.Count - 1
                Case 4
                    registros_indice = 0
                Case 5
                    registros_indice = registros.Count - 1
            End Select

            If grd IsNot Nothing Then Return indice_situa(registros_indice, grd)
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
            Return registros.Item(registros_indice).Item(campo).ToString()
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
    Public Function registro_buscaID(ByVal ID As String) As DataRow
        Dim coleccion As System.Collections.Generic.List(Of DataRow) = (From elemento As DataRow In registros Where elemento.Item("ID").ToString = ID).ToList
        If coleccion.Count > 0 Then
            Return coleccion(0)
        Else
            Return Nothing
        End If
    End Function

    Public Function registro_buscaPagina(ByVal pagina As Integer, ByRef grd As DataGridView, Optional ByVal posicionar As Boolean = False) As DataGridViewRow
        Dim encontrado As System.Collections.Generic.List(Of DataGridViewRow) = (From selec As DataGridViewRow In grd.Rows Where selec.Cells("Pagina").Value.ToString = pagina).ToList
        If encontrado.Count > 0 Then
            If posicionar Then grd.CurrentCell = encontrado(0).Cells("Pagina")
            Return encontrado(0)
        Else
            Return Nothing
        End If
    End Function


#End Region


End Class
