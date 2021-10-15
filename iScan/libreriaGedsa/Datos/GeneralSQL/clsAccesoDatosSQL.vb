Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports libreriacadenaproduccion.Entidades

Namespace Datos
    Namespace GeneralSQL

        Public Class clsAccesoDatosSQL

            Public Shared Function ObtenerListado(ByVal tabla As String, ByVal parametros As String, ByVal cadenaConexion As String, Optional ByVal parametroPorelqueseordena As String = Nothing) As DataTable

                Dim listado As New DataTable
                Dim strSQL As String

                strSQL = "SELECT " & parametros & " FROM " & tabla

                If IsNothing(parametroPorelqueseordena) = False Then strSQL = strSQL & " order by " & parametroPorelqueseordena

                Dim conexion As New SqlConnection(cadenaConexion)
                Dim cmdSQL As New SqlCommand(strSQL, conexion)
                Dim daDatos As New SqlDataAdapter(cmdSQL)

                Try
                    conexion.Open()
                    daDatos.Fill(listado)
                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString)
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                End Try

                Return listado

            End Function


            Public Shared Function ObtenerListadoParaValorParametro(ByVal tabla As String, ByVal parametros As String, ByVal parametroIgualaValor As String, ByVal valor As String, ByVal cadenaConexion As String, Optional ByVal parametroIgualavalor2 As String = Nothing, Optional ByVal valor2 As String = Nothing, Optional ByVal parametroPorelqueseordena As String = Nothing) As DataTable

                Dim listado As New DataTable
                Dim strSQL As String

                strSQL = "SELECT " & parametros & " FROM " & tabla & " WHERE " & parametroIgualaValor & " = " & valor

                If IsNothing(parametroIgualavalor2) = False Then strSQL = strSQL & " and " & parametroIgualavalor2 & " = " & valor2


                If IsNothing(parametroPorelqueseordena) = False Then strSQL = strSQL & " order by " & parametroPorelqueseordena

                Dim conexion As New SqlConnection(cadenaConexion)
                Dim cmdSQL As New SqlCommand(strSQL, conexion)
                Dim daDatos As New SqlDataAdapter(cmdSQL)

                Try
                    conexion.Open()
                    daDatos.Fill(listado)

                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString)
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                End Try

                Return listado

            End Function

            Public Shared Function ObtenerDataSet(ByVal lote As String, ByVal cadenaConexion As String, Optional ByVal parametroIgualavalor2 As String = Nothing, Optional ByVal valor2 As String = Nothing, Optional ByVal parametroPorelqueseordena As String = Nothing) As DataSet

                Dim listado As New DataTable
                Dim strSQL As String
                Dim conjuntoDatos As DataSet

                strSQL = "select  iddocumento,tipodocumento, numhistoria,codserviciopaed,numicu,fechainicio,fechatermino,nomarchivotif,pagina from documentos where  idlote = " & lote
                conjuntoDatos = New DataSet()
                If IsNothing(parametroIgualavalor2) = False Then strSQL = strSQL & " and " & parametroIgualavalor2 & " = " & valor2


                If IsNothing(parametroPorelqueseordena) = False Then strSQL = strSQL & " order by " & parametroPorelqueseordena

                Dim conexion As New SqlConnection(cadenaConexion)
                Dim cmdSQL As New SqlCommand(strSQL, conexion)
                Dim daDatos As New SqlDataAdapter(cmdSQL)

                Try
                    conexion.Open()
                    daDatos.Fill(conjuntoDatos, "Documentos")

                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString)
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                End Try

                Return conjuntoDatos

            End Function

            Public Shared Function ObtenerTopValorParametro(ByVal tabla As String, ByVal parametros As String, ByVal parametroIgualaValor As String, ByVal valor As String, ByVal cadenaConexion As String, Optional ByVal parametroPorelqueseordena As String = Nothing, Optional ByVal torden As String = Nothing) As DataTable

                Dim listado As New DataTable
                Dim strSQL As String

                strSQL = "SELECT TOP 1 " & parametros & " FROM " & tabla & " WHERE " & parametroIgualaValor & " = " & valor

                If IsNothing(parametroPorelqueseordena) = False Then strSQL = strSQL & " order by " & parametroPorelqueseordena & " " & torden

                Dim conexion As New SqlConnection(cadenaConexion)
                Dim cmdSQL As New SqlCommand(strSQL, conexion)
                Dim daDatos As New SqlDataAdapter(cmdSQL)

                Try
                    conexion.Open()
                    daDatos.Fill(listado)
                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString)
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                End Try

                Return listado

            End Function


            Public Shared Function ObtenerListadoParaValorParametro(ByVal tabla As String, ByVal parametros As String, ByVal parametroIgualaValor As String, ByVal valor As String, ByVal cadenaConexion As String, ByVal parametroIgualavalor2 As String, ByVal valor2 As String, ByVal parametroIgualavalor3 As String, ByVal valor3 As String, Optional ByVal parametroPorelqueseordena As String = Nothing) As DataTable

                Dim listado As New DataTable
                Dim strSQL As String

                strSQL = "SELECT " & parametros & " FROM " & tabla & " WHERE " & parametroIgualaValor & " = " & valor

                If IsNothing(parametroIgualavalor2) = False Then strSQL = strSQL & " and " & parametroIgualavalor2 & " = " & valor2
                If IsNothing(parametroIgualavalor3) = False Then strSQL = strSQL & " and " & parametroIgualavalor3 & " = " & valor3


                If IsNothing(parametroPorelqueseordena) = False Then strSQL = strSQL & " order by " & parametroPorelqueseordena

                Dim conexion As New SqlConnection(cadenaConexion)
                Dim cmdSQL As New SqlCommand(strSQL, conexion)
                Dim daDatos As New SqlDataAdapter(cmdSQL)

                Try
                    conexion.Open()

                    daDatos.Fill(listado)

                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString)
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                End Try

                Return listado

            End Function


            Public Shared Function eliminarRegistroParaValorParametro(ByVal tabla As String, ByVal listaFiltros As SortedList(Of String, Entidades.clsItem), ByVal cadenaConexion As String) As Boolean

                Dim strSQL As String
                Dim conexion As SqlConnection
                Dim cmdSQL As SqlCommand

                Dim exito As Boolean = True

                strSQL = "DELETE FROM " & tabla & " "

                If (listaFiltros IsNot Nothing) AndAlso (listaFiltros.Count > 0) Then

                    strSQL = strSQL & " WHERE "

                    For Each param As clsItem In listaFiltros.Values
                        strSQL = strSQL & param.ToString() & "AND"
                    Next

                    ' Eliminamos el último AND añadido
                    strSQL = strSQL.Remove(strSQL.Length - 4)

                End If

                conexion = New SqlConnection(cadenaConexion)
                cmdSQL = New SqlCommand(strSQL, conexion)

                Try

                    conexion.Open()
                    cmdSQL.ExecuteNonQuery()

                Catch
                    exito = False
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If

                End Try

                Return exito

            End Function



            Public Shared Function eliminarRegistro(ByVal tabla As String, ByVal parametroIgualaValor As String, ByVal valor As String, ByVal cadenaConexion As String, Optional ByVal parametroIgualavalor2 As String = Nothing, Optional ByVal valor2 As String = Nothing) As Boolean

                Dim strSQL As String
                Dim conexion As SqlConnection
                Dim cmdSQL As SqlCommand

                strSQL = "DELETE FROM " & tabla & " WHERE " & parametroIgualaValor & " = " & valor

                If parametroIgualavalor2 IsNot Nothing Then
                    strSQL = strSQL & " AND " & parametroIgualavalor2 & " = " & valor2
                End If

                conexion = New SqlConnection(cadenaConexion)
                cmdSQL = New SqlCommand(strSQL, conexion)

                Try

                    conexion.Open()
                    cmdSQL.ExecuteNonQuery()

                Catch ex As Exception
                    Return False
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If

                End Try

                Return True

            End Function

            '********************************************************************************************************************
            '           Poner a nulos, si el parameto de entrada no tiene valor pome un devuelve 'null' o texto altenernativo  
            '********************************************************************************************************************

            Public Shared Function PonerNulo(ByVal parametro As String, Optional ByVal textoalternativo As String = "null") As String
                If parametro = "" Then
                    If textoalternativo <> "null" Then
                        parametro = "'" & textoalternativo & "'"
                    Else
                        parametro = textoalternativo
                    End If
                Else
                    parametro = "'" & parametro & "'"
                End If

                Return parametro

            End Function

            '********************************************************************************************************
            '  Construcción Instrucción Actualización
            '********************************************************************************************************

            Public Shared Function InstruccionActualizacionParaValorParametro(ByVal tabla As String, ByVal listaValores As SortedList(Of String, Entidades.clsItem), ByVal ValorParametroActualizado() As String, ByVal cadenaConexion As String, Optional ByVal ParametroCondicion As String = "", Optional ByVal valorParametroCondicion As String = "") As Boolean

                Dim strSQL As String
                Dim conexion As New SqlConnection(cadenaConexion)
                Dim comando As SqlCommand

                Try

                    conexion.Open()


                    strSQL = "UPDATE " & tabla & " SET "

                    For Each param As clsItem In listaValores.Values
                        strSQL = strSQL & param._Campo & " = '" & param._valor & "', "
                    Next

                    strSQL = strSQL.TrimEnd(New Char() {" ", ","})


                    If ParametroCondicion <> "" Then
                        strSQL = strSQL & " where " & ParametroCondicion & " = " & valorParametroCondicion
                    End If

                    comando = New SqlCommand(strSQL, conexion)
                    comando.ExecuteNonQuery()

                Catch ex As SqlException
                    Return False
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If

                End Try

                Return True
            End Function

            '********************************************************************************************************
            '  Construcción Instrucción Actualización
            '********************************************************************************************************

            Public Shared Function construccionInstruccionActualizacion(ByVal tabla As String, ByVal parametroActualizado As String, ByVal ValorParametroActualizado As String, ByVal cadenaConexion As String, Optional ByVal ParametroCondicion As String = "", Optional ByVal valorParametroCondicion As String = "") As Boolean

                Dim strSQL As String
                Dim conexion As New SqlConnection(cadenaConexion)
                Dim comando As SqlCommand

                Try

                    conexion.Open()

                    strSQL = "UPDATE " & tabla & " SET " & parametroActualizado & " = " & ValorParametroActualizado

                    If ParametroCondicion <> "" Then
                        strSQL = strSQL & " where " & ParametroCondicion & " = " & valorParametroCondicion
                    End If

                    comando = New SqlCommand(strSQL, conexion)
                    comando.ExecuteNonQuery()

                Catch ex As SqlException
                    Return False
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If

                End Try

                Return True
            End Function



            '********************************************************************************************************************
            '           Poner Caracter en Blanco, si el parameto de entrada no tiene valor pome un devuelve 'null' o texto altenernativo  
            '********************************************************************************************************************
            ''' <summary> 
            '''ponercaracterenblanco, comprueba si el parametro es DBnull caso que lo sea lo sustituye por "" o texto alternativo si se ha introducido  
            '''</summary>
            ''' <param name=" parametro ">parametro que comprobamos que no sea nulo</param>
            ''' <param name=" textoAlternativo "> texto para sustituir si parametro es nulo por defecto ""</param> 
            ''' <returns>cadena para visualizar </returns> 
            Public Shared Function ponerCaracterEnBlanco(ByVal parametro As Object, Optional ByVal textoAlternativo As String = "") As String

                If IsNothing(parametro) = True Or IsDBNull(parametro) Then
                    If textoAlternativo <> "" Then
                        parametro = textoAlternativo
                    Else
                        parametro = ""
                    End If
                Else
                    parametro = parametro
                End If

                Return parametro

            End Function


            '********************************************************************************************************
            '  Construcción Instrucción Actualización con X campos
            '********************************************************************************************************
            Public Shared Function actualizarTabla(ByVal tabla As String, ByVal listaValores As SortedList(Of String, Entidades.clsItem), ByVal listaFiltros As SortedList(Of String, clsItem), ByVal cadenaConexion As String) As Boolean

                Dim strSQL As String
                Dim conexion As New SqlConnection(cadenaConexion)
                Dim comando As SqlCommand

                Try

                    strSQL = "UPDATE " & tabla & " SET "

                    For Each param As clsItem In listaValores.Values
                        strSQL = strSQL & param._Campo & " = '" & param._valor & "', "
                    Next

                    strSQL = strSQL.TrimEnd(New Char() {" ", ","})

                    If listaFiltros IsNot Nothing Then

                        strSQL = strSQL & " WHERE "

                        For Each param As clsItem In listaFiltros.Values
                            strSQL = strSQL & param.ToString() & "AND"
                        Next

                        ' Eliminamos el último AND añadido
                        strSQL = strSQL.Remove(strSQL.Length - 4)

                    End If

                    conexion.Open()
                    comando = New SqlCommand(strSQL, conexion)
                    comando.ExecuteNonQuery()


                Catch ex As Exception
                    Return False
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If

                End Try

                Return True

            End Function

            Public Shared Function actualizarTablaLiteral(ByVal tabla As String, ByVal listaValores As String, ByVal listaFiltros As String, ByVal cadenaConexion As String) As Boolean

                Dim strSQL As String
                Dim conexion As New SqlConnection(cadenaConexion)
                Dim comando As SqlCommand

                Try

                    strSQL = "UPDATE " & tabla & " SET "

                    strSQL = strSQL & listaValores


                    strSQL = strSQL & " WHERE "

                    strSQL = strSQL & listaFiltros


                    conexion.Open()
                    comando = New SqlCommand(strSQL, conexion)
                    comando.ExecuteNonQuery()


                Catch ex As Exception
                    Return False
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If

                End Try

                Return True

            End Function


            '********************************************************************************************************
            '  Construcción Instrucción Actualización con X campos
            '********************************************************************************************************
            Public Shared Function insertarRegistro(ByVal tabla As String, ByVal listaValores As SortedList(Of String, clsItem), ByVal cadenaConexion As String) As Boolean

                Dim strSQL As String
                Dim conexion As New SqlConnection(cadenaConexion)
                Dim comando As SqlCommand

                Try

                    strSQL = "INSERT INTO " & tabla & "("

                    For Each campo As String In listaValores.Keys
                        strSQL = strSQL & campo & ", "
                    Next

                    strSQL = strSQL.TrimEnd(New Char() {" ", ","})
                    strSQL = strSQL & ") VALUES("

                    For Each param As clsItem In listaValores.Values
                        strSQL = strSQL & "'" & param._valor & "', "
                    Next

                    strSQL = strSQL.TrimEnd(New Char() {" ", ","})
                    strSQL = strSQL & ")"


                    conexion.Open()
                    comando = New SqlCommand(strSQL, conexion)

                    comando.ExecuteNonQuery()

                Catch ex As Exception
                    Return False
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If

                End Try

                Return True

            End Function

            Public Shared Function insertarRegistroLiteral(ByVal tabla As String, ByVal listaCampos As String, ByVal listaValores As String, ByVal cadenaConexion As String) As Boolean

                Dim strSQL As String
                Dim conexion As New SqlConnection(cadenaConexion)
                Dim comando As SqlCommand

                Try

                    strSQL = "INSERT INTO " & tabla & "("

                    strSQL = strSQL & listaCampos & ") VALUES("

                    
                    strSQL = strSQL & listaValores & ")"

                    conexion.Open()
                    comando = New SqlCommand(strSQL, conexion)

                    comando.ExecuteNonQuery()

                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                    Return False
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If

                End Try

                Return True

            End Function



            '********************************************************************************************************
            '  Construcción Instrucción Listado con X condiciones AND
            '********************************************************************************************************

            Public Shared Function ObtenerListadoParaListaValoresParametros(ByVal tabla As String, ByVal parametros As String, ByVal ListaParametro_Valor As SortedList, ByVal cadenaConexion As String) As DataTable

                Dim listado As New DataTable
                Dim strSQL As String

                strSQL = "Select " & parametros & " from " & tabla & " Where "

                For Each elemento As DictionaryEntry In ListaParametro_Valor

                    If TypeOf elemento.Value Is Integer Then
                        strSQL += elemento.Key.ToString() & " = " & elemento.Value & " AND "


                    ElseIf TypeOf elemento.Value Is Boolean Then

                        If elemento.Value Then
                            strSQL += elemento.Key.ToString() & " = 1 AND "
                        Else
                            strSQL += elemento.Key.ToString() & " = 0 AND "
                        End If

                    Else
                        strSQL += elemento.Key.ToString() & " = '" & elemento.Value & "' AND "
                    End If
                Next

                ' Eliminamos el último AND añadido
                strSQL = strSQL.Remove(strSQL.Length - 5)

                Dim conexion As New SqlConnection(cadenaConexion)
                Dim cmdSQL As New SqlCommand(strSQL, conexion)
                Dim daDatos As New SqlDataAdapter(cmdSQL)

                Try
                    conexion.Open()
                    daDatos.Fill(listado)

                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString)
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                End Try

                Return listado


            End Function

            Public Shared Function ObtenerListadoIndizacion(ByVal tabla As String, ByVal parametros As String, ByVal parametroIgualaValor As String, ByVal valor As String, ByVal cadenaConexion As String, Optional ByVal parametroPorelqueseordena As String = Nothing) As DataTable

                Dim listado As New DataTable
                Dim strSQL As String

                strSQL = "SELECT " & parametros & " FROM " & tabla & " WHERE " & parametroIgualaValor & " = " & valor


                If IsNothing(parametroPorelqueseordena) = False Then strSQL = strSQL & " order by " & parametroPorelqueseordena

                Dim conexion As New SqlConnection(cadenaConexion)
                Dim cmdSQL As New SqlCommand(strSQL, conexion)
                Dim daDatos As New SqlDataAdapter(cmdSQL)

                Try
                    conexion.Open()
                    daDatos.Fill(listado)

                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString)
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                End Try

                Return listado

            End Function

            '********************************************************************************************************
            '  Construcción Instrucción Listado con X condiciones AND
            '********************************************************************************************************

            Public Shared Function ObtenerListadoParaListaValoresParametros(ByVal tabla As String, ByVal parametros As String, ByVal ListaParametro_Valor As SortedList(Of String, clsItem), ByVal cadenaConexion As String, Optional ByVal parametroPorelqueseordena As String = Nothing) As DataTable

                Dim strSQL As String
                Dim conexion As New SqlConnection(cadenaConexion)
                Dim comando As SqlCommand
                Dim daDatos As SqlDataAdapter
                Dim dt As New DataTable()

                Try

                    strSQL = "SELECT " & parametros & " "
                    strSQL = strSQL & "FROM " & tabla & " "
                    strSQL = strSQL & "WHERE "

                    For Each item As clsItem In ListaParametro_Valor.Values
                        strSQL = strSQL & item.ToString() & " AND "
                    Next

                    ' Quitamos el ultimo and
                    strSQL = strSQL.Substring(0, strSQL.Length - 5)

                    If parametroPorelqueseordena IsNot Nothing Then
                        strSQL = strSQL & " ORDER BY " & parametroPorelqueseordena
                    End If

                    conexion.Open()
                    comando = New SqlCommand(strSQL, conexion)
                    daDatos = New SqlDataAdapter(comando)

                    daDatos.Fill(dt)

                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString)
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If

                End Try

                Return dt

            End Function

            Public Shared Function ObtenerListadoParaListaValoresParametrosLiteral(ByVal tabla As String, ByVal parametros As String, ByVal ListaParametro_Valor As String, ByVal cadenaConexion As String, Optional ByVal parametroPorelqueseordena As String = Nothing) As DataTable

                Dim conexion As SqlConnection = Nothing
                Dim dt As New DataTable

                Try
                    conexion = New SqlConnection(cadenaConexion)
                    Dim comando As SqlCommand
                    Dim daDatos As SqlDataAdapter

                  
                    Dim strSQL As String = "SELECT " & parametros & " "
                    strSQL = strSQL & "FROM " & tabla & " "
                    strSQL = strSQL & "WHERE " & ListaParametro_Valor & " "

                    ' Quitamos el ultimo and
                    'strSQL = strSQL.Substring(0, strSQL.Length - 5)

                    If parametroPorelqueseordena IsNot Nothing Then
                        strSQL = strSQL & " ORDER BY " & parametroPorelqueseordena
                    End If

                    conexion.Open()
                    comando = New SqlCommand(strSQL, conexion)
                    daDatos = New SqlDataAdapter(comando)

                    daDatos.Fill(dt)

                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString)
                Finally
                    If conexion IsNot Nothing Then
                        If conexion.State = ConnectionState.Open Then conexion.Close()
                    End If
                End Try

                Return dt

            End Function

            '********************************************************************************************************************
            '           ObtenerUltimoID
            '********************************************************************************************************************
            Public Shared Function obtenerUltimoID(ByVal campoid As String, ByVal tabla As String, ByVal cadenaConexion As String) As Integer

                Dim id As Integer
                Dim strSQL As String

                strSQL = "Select max(" & campoid & ")from " & tabla

                Dim conexion As SqlConnection = Nothing
                Try
                    conexion = New SqlConnection(cadenaConexion)
                    conexion.Open()
                    Dim cmdSQL As New SqlCommand(strSQL, conexion)
                    If IsDBNull(cmdSQL.ExecuteScalar) Then
                        'Caso para el cual no hay ningún registro y la consulta no devuelve nada 
                        'como tenemos que incrementar en uno el contador en cada iteracion el id
                        'inicial tiene que ser 0 y tiene que ser incrementado en la primera pasada 
                        id = 0
                    Else
                        id = cmdSQL.ExecuteScalar
                    End If

                Catch ex As Exception
                    id = 0
                    MessageBox.Show(ex.Message.ToString)
                Finally
                    If conexion IsNot Nothing Then
                        If conexion.State = ConnectionState.Open Then
                            conexion.Close()
                        End If
                    End If
                End Try

                Return id
            End Function

            ' Comprueba que existe conectividad con el servidor y la base de datos pasados como parámetros
            Public Shared Function probarConexion(ByVal cadenaConexion As String) As Boolean

                Dim conexion As SqlConnection = Nothing
                Dim conexionCorrecta As Boolean = True

                Try
                    conexion = New SqlConnection(cadenaConexion)
                    conexion.Open()
                Catch ex As Exception
                    conexionCorrecta = False
                Finally
                    If conexion IsNot Nothing Then
                        If conexion.State = ConnectionState.Open Then conexion.Close()
                    End If
                End Try

                Return conexionCorrecta
            End Function

            ''' <summary>
            ''' Este metodo ejecuta una instruccion SQL que no devuelve filas (INSERT, UPDATE, DELETE...)
            ''' Realizado para casos de SQL complejos (INSERTS creados a partir de SELECTS de varias tablas)
            ''' para el pobrecito de J.Medrano, que le gusta complicarse la vida.
            ''' El procedimiento devuelve si lo ha ejecutado correctamente, y como parámetro
            ''' opcional devuelve el numero de filas aceptadas
            ''' </summary>
            ''' <param name="sql"></param>
            ''' <param name="cadenaConexion"></param>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Shared Function ejecutaSQLEjecucion(ByVal sql As String, ByVal cadenaConexion As String, Optional ByRef filasAfectadas As Integer = -1, Optional ByVal muestraError As Boolean = True) As Boolean
                Dim correcto As Boolean = False
                Dim conexion As SqlConnection = Nothing

                Try
                    conexion = New SqlConnection(cadenaConexion)
                    conexion.Open()
                    Dim cmd As SqlCommand = New SqlCommand(sql, conexion)
                    filasAfectadas = cmd.ExecuteNonQuery()
                    correcto = True
                Catch ex As Exception
                    If muestraError Then MessageBox.Show(ex.Message.ToString)
                Finally
                    If conexion IsNot Nothing Then
                        If conexion.State = ConnectionState.Open Then conexion.Close()
                    End If
                End Try

                Return correcto

            End Function

            Public Shared Function ejecutarSQLDirecta(ByVal SQL As String, ByVal cadenaConexion As String) As DataSet
                Dim conexion As SqlConnection = Nothing
                Dim ds As New DataSet

                Try
                    conexion = New SqlConnection(cadenaConexion)
                    conexion.Open()

                    Dim daDatos As SqlDataAdapter = New SqlDataAdapter(SQL, conexion)
                    daDatos.Fill(ds)
                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString)
                Finally
                    If conexion IsNot Nothing Then
                        If conexion.State = ConnectionState.Open Then conexion.Close()
                    End If
                End Try
                Return ds
            End Function

            Public Shared Function ejecutarSQLDirectaTable(ByVal SQL As String, ByVal cadenaConexion As String) As DataTable

                Dim conexion As SqlConnection = Nothing
                Dim ds As New DataTable

                Try
                    conexion = New SqlConnection(cadenaConexion)
                    conexion.Open()

                    Dim daDatos As SqlDataAdapter = New SqlDataAdapter(SQL, conexion)
                    daDatos.SelectCommand.CommandTimeout = 180
                    daDatos.Fill(ds)


                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString)
                Finally
                    If conexion IsNot Nothing Then
                        If conexion.State = ConnectionState.Open Then conexion.Close()
                    End If
                End Try
                Return ds
            End Function

            Public Shared Function ejecutarSQLDirectaDataRow(ByVal SQL As String, ByVal cadenaConexion As String) As DataRow

                Dim conexion As SqlConnection = Nothing
                Dim dr As DataRow = Nothing

                Try
                    conexion = New SqlConnection(cadenaConexion)
                    conexion.Open()

                    Dim dt As New DataTable

                    Dim daDatos As SqlDataAdapter = New SqlDataAdapter(SQL, conexion)
                    daDatos.Fill(dt)

                    If dt.Rows.Count > 0 Then dr = dt.Rows(0)
                    
                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString)
                Finally
                    If conexion IsNot Nothing Then
                        If conexion.State = ConnectionState.Open Then conexion.Close()
                    End If
                End Try

                Return dr
            End Function


        End Class
    End Namespace
End Namespace

