Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.io


Namespace Datos
    Namespace AdministrativosSQL

        Public Class clsAccesoDatosMetaDatosSQL



            Public Shared Function ObtenerInstanciasInstaladas() As String()
                Dim rk As Microsoft.Win32.RegistryKey
                rk = Microsoft.Win32.Registry.LocalMachine.OpenSubKey( _
                            "SOFTWARE\Microsoft\Microsoft SQL Server", False)
                Dim s() As String
                s = CType(rk.GetValue("InstalledInstances"), String())
                Return s


            End Function


            Public Shared Function ObtenerBaseDatosServidores(ByVal servidor As String, ByVal usuario As String, ByVal Clave As String) As DataTable

                Dim conexion As New SqlConnection("server=" & servidor & ";uid=" & usuario & ";pwd= " & Clave & ";database=Master")
                Dim cmd As New SqlCommand("sp_helpdb", conexion)
                Dim da As New SqlDataAdapter
                Dim dt As New DataTable("DataBases")
                Dim dscampos As New DataSet


                cmd.CommandType = CommandType.StoredProcedure
                da.SelectCommand = cmd

                Try
                    conexion.Open()

                    da.Fill(dt)

                Catch ex1 As OleDb.OleDbException
                    MessageBox.Show(ex1.Message.ToString)
                Catch ex2 As Exception
                    MessageBox.Show(ex2.Message.ToString)
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                        conexion.Dispose()
                    End If
                End Try

                Return dt

            End Function


            Public Shared Function ObtenerTablasBD(ByVal servidor As String, ByVal usuario As String, ByVal Clave As String, ByVal database As String) As DataTable


                Dim conexion As New SqlConnection("server=" & servidor & ";uid=" & usuario & ";pwd= " & Clave & ";database=Master")
                Dim cmd As New SqlCommand
                Dim da As New SqlDataAdapter
                Dim dt As New DataTable("DataBases")
                Dim dscampos As New DataSet


                'Asignación de propiedades
                cmd.Connection = conexion
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "Use [" & database & "] Select  TABLE_NAME From INFORMATION_SCHEMA.TABLES Where TABLE_TYPE = 'BASE TABLE'"
                da.SelectCommand = cmd

                'Intento de llenado de datos hacia la variable dt “DataTable”
                Try
                    da.Fill(dt)
                Catch ex1 As OleDb.OleDbException
                    MessageBox.Show(ex1.Message.ToString)
                Catch ex2 As Exception
                    MessageBox.Show(ex2.Message.ToString)
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                        conexion.Dispose()
                    End If
                End Try

                'Retorno de resultado
                Return dt

            End Function


            Public Shared Function ObtenerColumnasTablaBD(ByVal proveedor As String, ByVal servidor As String, ByVal usuario As String, ByVal Clave As String, ByVal basedatos As String, ByVal tabla As String) As DataTable


                Dim conexion As New SqlConnection("provider=SQLOLEDB;server=" & servidor & ";uid=" & usuario & ";pwd= " & Clave & ";database= " & basedatos & ";")
                Dim cmd As New SqlCommand
                Dim da As New SqlDataAdapter
                Dim dt As New DataTable("DataBases")
                Dim dscampos As New DataSet


                'Asignación de propiedades
                cmd.Connection = conexion
                cmd.CommandType = CommandType.Text

                cmd.CommandText = "Use [" & basedatos & "] SELECT * FROM  INFORMATION_SCHEMA.COLUMNS WHERE(table_Name = '" & tabla & "')"
                da.SelectCommand = cmd

                'Intento de llenado de datos hacia la variable dt “DataTable”
                Try
                    da.Fill(dt)
                Catch ex1 As OleDb.OleDbException
                    MessageBox.Show(ex1.Message.ToString)
                Catch ex2 As Exception
                    MessageBox.Show(ex2.Message.ToString)
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                        conexion.Dispose()
                    End If
                End Try

                'Retorno de resultado
                Return dt

            End Function


            Public Shared Function ObtenerColumnasTablaBD(ByVal tabla As String, ByVal cadenaConexion As String) As DataTable

                Dim conexion As New SqlConnection

                Dim cmd As New SqlCommand
                Dim da As New SqlDataAdapter
                Dim dt As New DataTable("DataBases")
                Dim dscampos As New DataSet

                conexion = New SqlConnection(cadenaConexion)


                'Asignación de propiedades
                With cmd
                    cmd.Connection = conexion
                    cmd.CommandType = CommandType.Text
                End With

                cmd.CommandText = "Use [" & conexion.Database & "] SELECT Column_Name FROM  INFORMATION_SCHEMA.COLUMNS WHERE(table_Name = '" & tabla & "')"
                da.SelectCommand = cmd

                'Intento de llenado de datos hacia la variable dt “DataTable”
                Try
                    da.Fill(dt)
                Catch ex1 As OleDb.OleDbException
                    MessageBox.Show(ex1.Message.ToString)
                Catch ex2 As Exception
                    MessageBox.Show(ex2.Message.ToString)
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                        conexion.Dispose()
                    End If
                End Try

                'Retorno de resultado
                Return dt

            End Function


#Region "Funciones de Restauracion y copia de seguridad"

            '********************************************************************************************************************
            '           GenerarPuntoRestauracion
            '********************************************************************************************************************
            Public Shared Function GenerarPuntoRestauracion(ByVal ArchivoBak As String, ByVal cadenaConexion As String) As Boolean
                Dim i As Integer
                Dim Array_Dir As Object
                Dim Sub_Dir As String
                Dim El_Path As String
                


                If Dir(ArchivoBak.Substring(0, ArchivoBak.LastIndexOf(Path.DirectorySeparatorChar)), FileAttribute.Directory) = vbNullString Then

                    ' si no existe lo crea
                    Array_Dir = Split(ArchivoBak.Substring(0, ArchivoBak.LastIndexOf(Path.DirectorySeparatorChar)), "\")

                    El_Path = vbNullString

                    'Recorre el vector anterior para ir creando uno por uno comenzando obviamente desde el directorio de primer nivel  
                    For i = LBound(Array_Dir) To UBound(Array_Dir)
                        Sub_Dir = Array_Dir(i)
                        If Sub_Dir <> vbNullString Then
                            El_Path = El_Path & Sub_Dir & "\"
                            If Right$(Sub_Dir, 1) <> ":" Then
                                ' Verificamos que no exista  
                                If Dir(El_Path, vbDirectory) = vbNullString Then
                                    'Crea la carpeta  
                                    Call MkDir(El_Path)
                                End If
                            End If
                        End If
                    Next



                End If




                Dim strSQL As String
                Dim DB As String = ""
                Dim exito As Boolean = True

                DB = cadenaConexion.Remove(0, cadenaConexion.IndexOf("database=")).Remove(0, 9)
                DB = DB.TrimEnd(";")
                strSQL = "backup database " & DB & " to disk= '" & ArchivoBak & "'" & _
                " WITH NOFORMAT, NOINIT, NAME =N'" & DB & _
                " -Full Database Backup',SKIP, STATS = 10"


                Dim conexion As New SqlConnection(cadenaConexion)
                Dim cmdSQL As New SqlCommand(strSQL, conexion)




                Try
                    conexion.Open()

                    cmdSQL.ExecuteNonQuery()

                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString)
                    exito = False
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                End Try

                Return exito

            End Function


            '********************************************************************************************************************
            '           RecuperarPuntoRestauracion
            '********************************************************************************************************************
            Public Shared Function RecuperarPuntoRestauracion(ByVal ArchivoBak As String, ByVal cadenaConexion As String) As Boolean
                Dim strSQL As String
                Dim DB As String = ""
                Dim exito As Boolean = True
                Dim servidor As String = ""



                DB = cadenaConexion.Remove(0, cadenaConexion.IndexOf("database=")).Remove(0, 9)
                DB = DB.TrimEnd(";")
                'servidor = cadenaConexion.Remove(0, cadenaConexion.IndexOf("server=")).Remove(0, 7)
                'servidor = DB.TrimEnd(";")


                cadenaConexion = cadenaConexion.Replace("database=" & DB, "database=Master")


                strSQL = "RESTORE DATABASE " & DB & " from disk= '" & ArchivoBak & _
               "' WITH REPLACE"



                Dim conexion As New SqlConnection(cadenaConexion)
                Dim cmdSQL As New SqlCommand(strSQL, conexion)

                Try
                    conexion.Open()

                    cmdSQL.ExecuteNonQuery()

                Catch ex As Exception
                    exito = False
                    MessageBox.Show(ex.Message.ToString)
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                End Try

                Return exito

            End Function
#End Region



#Region "Ejecucion de Scripts '.sql' "

            Public Shared Function ejecutarScript(ByVal rutaDelFicheroSQL As String, ByVal cadenaConexion As String) As Integer

                Dim errores As Integer = 0



                Dim sr As StreamReader
                Dim sContent As String

                Dim conexion As New SqlConnection()
                Dim cmdScript As SqlCommand

                'se crea un data table para almacenar las instrucciones
                Dim instruccionesSQL As New DataTable()
                instruccionesSQL.Columns.Add("Instruccion")

                Try
                    'tratamos de abrir el fichero
                    sr = File.OpenText(rutaDelFicheroSQL)




                Catch ex As Exception

                    MessageBox.Show("No se ha podido abrir el archivo, se ha producido el siguiente error: " & ex.Message, "Error al abrir el archivo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Function

                End Try





                While Not sr.EndOfStream 'lo leemos liena a linea obteniendo todas las instrucciones sql

                    sContent = sr.ReadLine()
                    instruccionesSQL.Rows.Add(sContent)

                End While





                Try 'para cada entrada del data table (instruccion) tratamos de ejecutarla

                    conexion.ConnectionString = cadenaConexion
                    cmdScript = New SqlCommand("", conexion)

                    conexion.Open()

                    For Each instruccion As DataRow In instruccionesSQL.Rows 'ejecucion de los comandos uno a uno


                        cmdScript.CommandText = instruccion.Item(0)


                        If cmdScript.CommandText <> "" Then
                            cmdScript.ExecuteNonQuery()
                        End If



                    Next

                Catch ex As Exception

                    MessageBox.Show(ex.Message.ToString)
                    errores += 1

                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                End Try



                'si no ha habido errores se muestra un mensaje
                If errores = 0 Then
                    MessageBox.Show("Script ejecutado con éxito.", "Ejecución de script", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If



                'se devuelve el numero de errores para su posible tratamiento
                Return errores

            End Function

#End Region





        End Class

    End Namespace
End Namespace

