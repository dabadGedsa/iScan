Imports libreriacadenaproduccion.Entidades
Imports System.Windows.Forms

Imports System.Data.OleDb


Namespace Datos
    Namespace AccesCIE

        Public Class AccesoDatosCIE


#Region "Funciones de carga de las tablas de la CIE"

            Public Shared Function cargarTablaDiagnosticos(ByVal strCadenaConexion As String) As DataTable


                Dim listado As New DataTable()
                Dim strSQL As String
                Dim cmdSQL As OleDbCommand
                Dim conexion As OleDbConnection
                Dim daDatos As OleDbDataAdapter




                strSQL = "Select * from Diagnosticos"

                conexion = New OleDbConnection(strCadenaConexion)
                cmdSQL = New OleDbCommand(strSQL, conexion)
                daDatos = New OleDbDataAdapter(cmdSQL)

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

            Public Shared Function cargarTablaMorfologias(ByVal strCadenaConexion As String) As DataTable



                Dim listado As New DataTable()
                Dim strSQL As String
                Dim cmdSQL As OleDbCommand
                Dim conexion As OleDbConnection
                Dim daDatos As OleDbDataAdapter




                strSQL = "Select * from MorfologiasNeoplasias"

                conexion = New OleDbConnection(strCadenaConexion)
                cmdSQL = New OleDbCommand(strSQL, conexion)
                daDatos = New OleDbDataAdapter(cmdSQL)

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

            Public Shared Function cargarTablaProcedimientos(ByVal strCadenaConexion As String) As DataTable



                Dim listado As New DataTable()
                Dim strSQL As String
                Dim cmdSQL As OleDbCommand
                Dim conexion As OleDbConnection
                Dim daDatos As OleDbDataAdapter




                strSQL = "Select * from Procedimientos"

                conexion = New OleDbConnection(strCadenaConexion)
                cmdSQL = New OleDbCommand(strSQL, conexion)
                daDatos = New OleDbDataAdapter(cmdSQL)

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


#End Region



#Region "Consultas Basicas para la CIE (Access). Faltan por cambiar el nombre de las tablas en las consultas"
            Public Shared Function ObtenerCieDeCodigo(ByVal codigo As String, ByVal strCadenaConexion As String) As String

                Dim listado As New DataTable()
                Dim strSQL As String
                Dim cmdSQL As OleDbCommand
                Dim conexion As OleDbConnection = Nothing
                Dim daDatos As OleDbDataAdapter


                Try
                    conexion = New OleDbConnection(strCadenaConexion)




                    If (codigo.IndexOf(".") = 2) Or (codigo.Length = 2) Then 'es un PROCEDIMIENTO pues todo siguen el patron XX.XX, y ningun diagnostico ni morfologia lo sigue


                        strSQL = "Select * from Procedimientos where Codigo='" & codigo & "'"


                    Else 'es una morfologia o un diagnostico normal


                        If codigo.StartsWith("M") Or codigo.StartsWith("m") Then ' va a la tabla  morfologias

                            strSQL = "Select * from MorfologiasNEoplasias where Codigo='" & codigo & "'"

                        Else ' va la la tabla Diagnostios

                            strSQL = "Select * from Diagnosticos where Codigo='" & codigo & "'"
                        End If

                    End If

                    cmdSQL = New OleDbCommand(strSQL, conexion)



                    daDatos = New OleDbDataAdapter(cmdSQL)


                    conexion.Open()

                    daDatos.Fill(listado)

                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString)
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                End Try


                Try
                    Return listado.Rows(0).Item("Descripcion").ToString()
                Catch ex As Exception
                    Return "Sin descripcion."
                End Try




            End Function

            Public Shared Function existeCodigo(ByVal codigo As String, ByVal strCadenaConexion As String) As Boolean


                Dim listado As New DataTable()
                Dim strSQL As String
                Dim cmdSQL As OleDbCommand
                Dim conexion As OleDbConnection
                Dim objetoEncontrado As Object = Nothing


                conexion = New OleDbConnection(strCadenaConexion)




                If (codigo.IndexOf(".") = 2) Or (codigo.Length = 2) Then '"XX.XX"

                    strSQL = "Select * from Procedimientos where Codigo = '" & codigo & "'"

                Else

                    If codigo.StartsWith("M") Or codigo.StartsWith("m") Then ' va a la tabla episodios morfologias

                        strSQL = "Select * from MorfologiasNeoplasias where Codigo = '" & codigo & "'"

                    Else ' va la la tabla episodiosDiagnostios

                        strSQL = "Select * from Diagnosticos where Codigo = '" & codigo & "'"
                    End If

                    'Puede que falte comprobar si se modifica un codigo de diagnostico a uno de morfologia y viceversa. 
                End If


                conexion = New OleDbConnection(strCadenaConexion)
                cmdSQL = New OleDbCommand(strSQL, conexion)


                Try

                    conexion.Open()
                    objetoEncontrado = cmdSQL.ExecuteScalar() 'comporbar que la consulta devuelve algo


                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString)
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                End Try

                If Not IsNothing(objetoEncontrado) Then
                    Return True

                Else
                    Return False

                End If


            End Function


#End Region



















        End Class



    End Namespace
End Namespace