Imports system.Data.OleDb
Imports libreriacadenaproduccion.Entidades

Namespace Datos
    Namespace GeneralAccess

        Public Class ClsAccesoDatosAccess


            Public Shared Function AbrirBaseDatosAccess() As String

                Dim ofdAbrirBaseDatos As New System.Windows.Forms.OpenFileDialog
                Dim ficheroMDB As String = ""

                ofdAbrirBaseDatos.DefaultExt = "mdb"
                ofdAbrirBaseDatos.Filter = "Documentos Acc (*.mdb)|*.mdb"

                Try
                    ofdAbrirBaseDatos.ShowDialog()
                Catch err As Exception
                    System.Windows.Forms.MessageBox.Show("Error, no se ha podido abrir el fichero access :" & err.Message)
                End Try

                ficheroMDB = ofdAbrirBaseDatos.FileName

                Return ficheroMDB

            End Function




            ' Comprueba que existe conectividad con el servidor y la base de datos pasados como parámetros
            Public Shared Function probarConexion(ByVal cadenaConexion As String, Optional ByRef _error As String = "") As Boolean

                Dim conexion As OleDbConnection
                Dim conexionCorrecta As Boolean = True

                conexion = New OleDbConnection()

                Try

                    conexion.ConnectionString = cadenaConexion

                    conexion.Open()

                Catch ex As Exception
                    conexionCorrecta = False

                    _error = ex.Message

                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                End Try

                Return conexionCorrecta

            End Function


            Public Shared Function OtenerTablasBDAccess(ByVal strCadenaConexion As String) As DataTable

                Dim conexion As OleDbConnection = Nothing
                Dim daTabla As OleDbDataAdapter
                Dim dataTable As DataTable
                Dim dbNull As DBNull = Nothing
                Dim restrictions() As Object = {dbNull, dbNull, dbNull, "TABLE"}


                Try

                    conexion = New OleDbConnection
                    daTabla = New OleDbDataAdapter


                    conexion.ConnectionString = strCadenaConexion


                    conexion.Open()
                    dataTable = conexion.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, restrictions)

                    conexion.Close()
                    'las tablase se quedan almacenadas en la columana "TABLE_NAME"
                    Return dataTable

                Catch err As OleDbException
                    System.Windows.Forms.MessageBox.Show(err.ErrorCode.ToString & err.Message.ToString)

                Catch err2 As Exception
                    System.Windows.Forms.MessageBox.Show(err2.Message.ToString)

                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                End Try
                Return Nothing
            End Function


            '********************************************************************************************************
            '  Construcción Instrucción Actualización con X campos
            '********************************************************************************************************
            Public Shared Function insertarRegistro(ByVal tabla As String, ByVal listaValores As SortedList(Of String, clsItem), ByVal cadenaConexion As String) As Boolean

                Dim strSQL As String
                Dim conexion As New OleDbConnection(cadenaConexion)
                Dim comando As OleDbCommand

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
                    comando = New OleDbCommand(strSQL, conexion)

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


            Public Shared Function ObtenerListado(ByVal tabla As String, ByVal parametros As String, ByVal cadenaConexion As String, Optional ByVal parametroPorelqueseordena As String = Nothing, Optional ByRef _error As String = "") As DataTable

                Dim listado As New DataTable
                Dim strSQL As String

                strSQL = "SELECT " & parametros & " FROM " & tabla

                If IsNothing(parametroPorelqueseordena) = False Then strSQL = strSQL & " order by " & parametroPorelqueseordena

                Dim conexion As New OleDbConnection(cadenaConexion)
                Dim cmdSQL As New OleDbCommand(strSQL, conexion)
                Dim daDatos As New OleDbDataAdapter(cmdSQL)

                Try
                    conexion.Open()

                    daDatos.Fill(listado)

                Catch ex As Exception
                    _error = ex.Message

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

                If IsNothing(parametroIgualavalor2) = False Then strSQL = strSQL & " and " & parametroIgualavalor2 & " = '" & valor2 & "'"


                If IsNothing(parametroPorelqueseordena) = False Then strSQL = strSQL & " order by " & parametroPorelqueseordena

                Dim conexion As New OleDb.OleDbConnection(cadenaConexion)
                Dim cmdSQL As New OleDb.OleDbCommand(strSQL, conexion)
                Dim daDatos As New OleDb.OleDbDataAdapter(cmdSQL)

                Try
                    conexion.Open()

                    daDatos.Fill(listado)

                Catch ex As Exception
                    'MessageBox.Show(ex.Message.ToString)
                    MsgBox(ex.Message.ToString)
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                End Try

                Return listado

            End Function



            '********************************************************************************************************
            '  Construcción Instrucción Actualización con X campos
            '********************************************************************************************************
            Public Shared Function actualizarTabla(ByVal tabla As String, ByVal listaValores As SortedList(Of String, Entidades.clsItem), ByVal listaFiltros As SortedList(Of String, clsItem), ByVal cadenaConexion As String) As Boolean

                Dim strSQL As String
                Dim conexion As New OleDbConnection(cadenaConexion)
                Dim comando As OleDbCommand

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
                    comando = New OleDbCommand(strSQL, conexion)
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



            Public Shared Function ejecutarSQL(ByVal strSQL As String, ByVal cadenaConexion As String) As Integer

                Dim conexion As New OleDbConnection(cadenaConexion)
                Dim comando As OleDbCommand


                Try

                    conexion.Open()
                    comando = New OleDbCommand(strSQL, conexion)
                    comando.ExecuteScalar()


                Catch ex As Exception
                    Return 0
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If

                End Try

                Return 1

            End Function



            Public Shared Function ejecutarSQLDirecta(ByVal SQL As String, ByVal cadenaConexion As String) As DataSet

                Dim strSQL As String
                Dim conexion As New OleDbConnection(cadenaConexion)
                Dim comando As OleDbCommand
                Dim daDatos As OleDbDataAdapter
                Dim ds As New DataSet()

                Try

                    strSQL = SQL


                    conexion.Open()
                    comando = New OleDbCommand(strSQL, conexion)
                    daDatos = New OleDbDataAdapter(comando)

                    daDatos.Fill(ds)

                Catch ex As Exception
                    MsgBox(ex.Message.ToString)
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If

                End Try

                Return ds




            End Function


        End Class

    End Namespace
End Namespace