Imports System.Data.OracleClient
Imports System.Windows.Forms
Imports libreriacadenaproduccion.Entidades

Namespace Datos
    Namespace GeneralOracle


        Public Class clsAccesoDatosOracle

            Public Shared Function ObtenerListado(ByVal tabla As String, ByVal parametros As String, ByVal cadenaConexion As String, Optional ByVal parametroPorelqueseordena As String = Nothing) As DataTable

                Dim listado As New DataTable
                Dim strSQL As String

                strSQL = "SELECT " & parametros & " FROM " & tabla

                If IsNothing(parametroPorelqueseordena) = False Then strSQL = strSQL & " order by " & parametroPorelqueseordena

                Dim conexion As New OracleConnection(cadenaConexion)
                Dim cmdSQL As New OracleCommand(strSQL, conexion)
                Dim daDatos As New OracleDataAdapter(cmdSQL)

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

                Dim conexion As New OracleConnection(cadenaConexion)
                Dim cmdSQL As New OracleCommand(strSQL, conexion)
                Dim daDatos As New OracleDataAdapter(cmdSQL)

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


            Public Shared Function ObtenerListadoParaValorParametro(ByVal tabla As String, ByVal parametros As String, ByVal parametroIgualaValor As String, ByVal valor As String, ByVal cadenaConexion As String, ByVal parametroIgualavalor2 As String, ByVal valor2 As String, ByVal parametroIgualavalor3 As String, ByVal valor3 As String, Optional ByVal parametroPorelqueseordena As String = Nothing) As DataTable

                Dim listado As New DataTable
                Dim strSQL As String

                strSQL = "SELECT " & parametros & " FROM " & tabla & " WHERE " & parametroIgualaValor & " = " & valor

                If IsNothing(parametroIgualavalor2) = False Then strSQL = strSQL & " and " & parametroIgualavalor2 & " = " & valor2
                If IsNothing(parametroIgualavalor3) = False Then strSQL = strSQL & " and " & parametroIgualavalor3 & " = " & valor3


                If IsNothing(parametroPorelqueseordena) = False Then strSQL = strSQL & " order by " & parametroPorelqueseordena

                Dim conexion As New OracleConnection(cadenaConexion)
                Dim cmdSQL As New OracleCommand(strSQL, conexion)
                Dim daDatos As New OracleDataAdapter(cmdSQL)

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


            Public Shared Function EjecutarSqlDirecta(ByVal strSQL As String, ByVal cadenaConexion As String) As DataTable

                Dim listado As New DataTable

                Dim conexion As New OracleConnection(cadenaConexion)
                Dim cmdSQL As New OracleCommand(strSQL, conexion)
                Dim daDatos As New OracleDataAdapter(cmdSQL)

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



            'Public Shared Function insertarRegistro(ByVal tabla As String, ByVal listaValores As Collection, ByVal cadenaConexion As String) As Boolean

            '    Dim strSQL As String
            '    Dim conexion As New OleDb.OleDbConnection(cadenaConexion)
            '    Dim comando As OleDb.OleDbCommand

            '    Try

            '        strSQL = "INSERT INTO " & tabla & "("

            '        For Each campo As String In listaValores.Item(0)
            '            strSQL = strSQL & campo & ", "
            '        Next

            '        strSQL = strSQL.TrimEnd(New Char() {" ", ","})
            '        strSQL = strSQL & ") VALUES("

            '        For Each param As clsItem In listaValores.Item(1)
            '            strSQL = strSQL & "'" & param._valor & "', "
            '        Next

            '        strSQL = strSQL.TrimEnd(New Char() {" ", ","})
            '        strSQL = strSQL & ")"

            '        conexion.Open()
            '        comando = New OleDb.OleDbCommand(strSQL, conexion)

            '        comando.ExecuteNonQuery()



            '    Catch ex As Exception
            '        Return False
            '    Finally
            '        If conexion.State = ConnectionState.Open Then
            '            conexion.Close()
            '        End If

            '    End Try

            '    Return True

            'End Function



            ' Comprueba que existe conectividad con el servidor y la base de datos pasados como parámetros
            Public Shared Function probarConexion(ByVal cadenaConexion As String, Optional ByRef _error As String = "") As Boolean

                Dim conexion As OracleConnection
                Dim conexionCorrecta As Boolean = True

                conexion = New OracleConnection

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
            


        End Class


    End Namespace
End Namespace

