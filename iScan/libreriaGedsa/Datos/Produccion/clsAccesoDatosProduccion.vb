Imports System.Data.SqlClient
Imports System.IO
Imports System.Transactions
Imports System.Data
Imports System.Windows.Forms
Imports libreriacadenaproduccion.Entidades

Namespace Datos
    Namespace Produccion

        Public Class clsAccesoDatosProduccion

            Public Shared Function ObtenerIdValidaDocumento(ByVal cadenaConexion As String) As Integer

                Dim strSQL1 As String = "Select max(id) from documentos"

                Dim datos As New DataTable
                Dim idBuena As Integer = 0

                Dim Transaccion As SqlTransaction = Nothing

                Dim conexion As New SqlConnection(cadenaConexion)
                Dim cmdSQL As New SqlCommand(strSQL1, conexion)
                Dim daDatos As New SqlDataAdapter(cmdSQL)


                Try

                    conexion.Open()
                    Transaccion = conexion.BeginTransaction()

                    cmdSQL.Transaction = Transaccion

                    daDatos.Fill(datos)
                    idBuena = CType(datos.Rows(0).Item(0), Integer)

                    libreriacadenaproduccion.Datos.GeneralSQL.clsAccesoDatosSQL.ejecutarSQLDirecta("INSERT INTO documentos", cadenaConexion)


                    Transaccion.Commit()


                Catch ex As Exception
                    Transaccion.Rollback()
                    'System.Windows.Forms.MessageBox.Show(ex.Message.ToString)
                    Return 0
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                End Try

                Return idBuena

            End Function

#Region "Operaciones sobre los Proyectos "


            ''' <summary> 
            '''Carga el listado de los proyectos, carga el listado de los proyectos con sus correspondientes configuraciones
            '''</summary>
            ''' <param name=" codigoCliente ">indica el cliente para el que se obtienen los proyectos</param>
            ''' <returns>Devuelve una datatable con todos los posibles proyectos </returns> 

            Public Shared Function CargarListadoProyectos(ByVal cadenaConexion As String, Optional ByVal codigoCliente As String = "") As DataTable

                Dim proyectos As New DataTable
                Dim strSQL As String

                If codigoCliente = "" Then
                    strSQL = "Select Proyectos.Proyecto as NumProyecto,Nombre from Proyectos,Configuracion where Proyectos.Activo=1 and Configuracion.Proyecto=Proyectos.Proyecto order by Proyectos.Proyecto asc"
                Else
                    strSQL = "Select Proyectos.Proyecto as NumProyecto,Nombre from Proyectos,Configuracion where Proyectos.Activo=1 and Configuracion.Proyecto=Proyectos.Proyecto and Proyectos.Hospital='" & codigoCliente & "' order by Proyectos.Proyecto asc"
                End If



                Dim conexion As New SqlConnection(cadenaConexion)
                Dim cmdSQL As New SqlCommand(strSQL, conexion)
                Dim daDatos As New SqlDataAdapter(cmdSQL)

                Try
                    conexion.Open()

                    daDatos.Fill(proyectos)

                Catch ex As Exception
                    System.Windows.Forms.MessageBox.Show(ex.Message.ToString)
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                End Try

                Return proyectos

            End Function


            ''' <summary> 
            '''devueve la clave para un proyecto 
            '''</summary>
            ''' <param name="proyecto ">Proyecto para el que se quiere obtener la contraseña </param>
            ''' <returns>contraseña para el codigoproyecto seleccionado </returns> 
            ''' <remarks> 
            '''mas comentarios 
            ''' </remarks> 
            Public Shared Function ObtenerContraseñaProyecto(ByVal proyecto As String, ByVal cadenaConexion As String) As String


                Dim strSQL As String = "Select contraseña from Configuracion where Proyecto='" & proyecto & "'"
                Dim contraseña As String = ""
                Dim conexion As New SqlConnection(cadenaConexion)
                Dim cmdSQL As New SqlCommand(strSQL, conexion)
                Dim dreader As SqlDataReader

                Try
                    conexion.Open()

                    dreader = cmdSQL.ExecuteReader

                    While dreader.Read
                        contraseña = dreader.Item("contraseña")
                    End While

                Catch ex As Exception
                    System.Windows.Forms.MessageBox.Show(ex.Message.ToString)
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                End Try

                Return contraseña

            End Function






#End Region

#Region "operaciones sobre los lotes "

            Public Shared Function obtenerLoteProyectoNoIndizados(ByVal numProyecto As String, ByVal todo As Boolean, ByVal strcadenaConexion As String) As DataTable

                Dim con As SqlConnection = Nothing
                Dim cmd As SqlCommand
                Dim data As New DataTable
                Dim dataAdapter As New SqlDataAdapter

                'data = Nothing

                Try

                    con = New SqlConnection
                    con.ConnectionString = strcadenaConexion

                    'traspasado ----> corregido: ese cambio NO
                    If todo Then
                        cmd = New SqlCommand("Select * from Lotes where (Traspasado=1 or traspasado is null) and Activo=1 and Asignado=0 and (Atributado=0 or Atributado is null) and Proyecto='" & numProyecto & "' order by Lote asc", con)
                    Else '
                        cmd = New SqlCommand("Select TOP 1 * from Lotes where (Traspasado=1 or traspasado is null) and Activo=1 and (Asignado=0 or asignado is null) and (Atributado=0 or Atributado is null) and Proyecto='" & numProyecto & "' order by Lote asc", con)
                    End If

                    dataAdapter.SelectCommand = cmd
                    con.Open()

                    dataAdapter.Fill(data)

                Catch oExcep As SqlException
                    MessageBox.Show("Error al conectar con datos" & ControlChars.CrLf & oExcep.Message & ControlChars.CrLf & oExcep.Server)

                Finally
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                End Try

                Return data

            End Function

            Public Shared Function AsignarUsuarioIndizacionLote(ByVal numProyecto As String, ByVal usuario As String, ByVal lote As libreriacadenaproduccion.Entidades.ClsLote, ByVal strcadenaConexion As String) As Boolean
                Dim con As SqlConnection = Nothing
                Dim cmd As SqlCommand


                Dim dataAdapter As New SqlDataAdapter
                Dim strSQL As String

                'usuarioA
                strSQL = "update Lotes set usuarioA='" & usuario & "', asignado=1 WHERE Proyecto='" & numProyecto & "' and lote ='" & lote._idlote & "'"

                Try

                    con = New SqlConnection()
                    con.ConnectionString = strcadenaConexion
                    cmd = New SqlCommand(strSQL, con)
                    con.Open()
                    cmd.ExecuteScalar()

                Catch oExcep As SqlException
                    MessageBox.Show(oExcep.Message)
                    Return False

                Finally
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                End Try

                Return True

            End Function


            Public Shared Function AsignarUsuarioIndizacionLoteCorreccion(ByVal numProyecto As String, ByVal usuario As String, ByVal lote As libreriacadenaproduccion.Entidades.ClsLote, ByVal strcadenaConexion As String) As Boolean
                ' qwewqe()

                Dim con As SqlConnection = Nothing
                Dim cmd As SqlCommand


                Dim dataAdapter As New SqlDataAdapter
                Dim strSQL As String

                'usuarioA
                strSQL = "update Lotes set usuarioA='" & usuario & "', asignado=1 WHERE Proyecto='" & numProyecto & "' and lote ='" & lote._idlote & "'"



                Try

                    con = New SqlConnection()

                    con.ConnectionString = strcadenaConexion


                    cmd = New SqlCommand(strSQL, con)

                    con.Open()

                    cmd.ExecuteScalar()



                Catch oExcep As SqlException
                    MessageBox.Show(oExcep.Message)
                    Return False

                Finally
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                End Try

                Return True




            End Function

            Public Shared Function obtenerLoteAsignadoUsuario(ByVal numProyecto As String, ByVal usuario As String, ByVal todo As Boolean, ByVal strcadenaConexion As String) As DataTable


                Dim con As SqlConnection = Nothing
                Dim cmd As SqlCommand
                Dim data As New DataTable
                Dim dataAdapter As New SqlDataAdapter

                Try

                    con = New SqlConnection()
                    con.ConnectionString = strcadenaConexion

                    If todo Then
                        cmd = New SqlCommand("Select * from Lotes where Traspasado=1 and Activo=1 and Asignado=1 and (Atributado=0 or Atributado is null) and Proyecto='" & numProyecto & "' and UsuarioA='" & usuario & "' order by Lote asc", con)
                    Else
                        cmd = New SqlCommand("Select TOP 1 * from Lotes where (Traspasado=1 or traspasado is null) and Activo=1 and Asignado=1 and (Atributado=0 or Atributado is null) and Proyecto='" & numProyecto & "' and UsuarioA='" & usuario & "' order by Lote asc", con)
                    End If

                    dataAdapter.SelectCommand = cmd

                    con.Open()

                    dataAdapter.Fill(data)


                Catch oExcep As SqlException
                    ' si se produce algún error lo capturamos mediante el objeto de excepciones particular para _
                    ' el proveedor de SQL Server

                    MessageBox.Show("Error al conectar con datos" & ControlChars.CrLf & oExcep.Message & ControlChars.CrLf & oExcep.Server)

                Finally
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                End Try


                Return data

            End Function


            Public Shared Function obtenerLoteAsignadoUsuarioCorreccion(ByVal numProyecto As String, ByVal usuario As String, ByVal todo As Boolean, ByVal strcadenaConexion As String) As DataTable
                'asd()

                Dim con As SqlConnection = Nothing
                Dim cmd As SqlCommand
                Dim data As New DataTable
                Dim dataAdapter As New SqlDataAdapter

                Try

                    con = New SqlConnection()
                    con.ConnectionString = strcadenaConexion

                    If todo Then
                        cmd = New SqlCommand("Select * from Lotes where Traspasado=1 and Activo=1 and Asignado=1 and (Atributado=0 or Atributado is null) and Proyecto='" & numProyecto & "' and UsuarioA='" & usuario & "' order by Lote asc", con)
                    Else
                        cmd = New SqlCommand("Select TOP 1 * from Lotes where (Traspasado=1 or traspasado is null) and Activo=1 and Asignado=1 and (Atributado=0 or Atributado is null) and Proyecto='" & numProyecto & "' and UsuarioA='" & usuario & "' order by Lote asc", con)
                    End If

                    dataAdapter.SelectCommand = cmd

                    con.Open()

                    dataAdapter.Fill(data)


                Catch oExcep As SqlException
                    ' si se produce algún error lo capturamos mediante el objeto de excepciones particular para _
                    ' el proveedor de SQL Server

                    MessageBox.Show("Error al conectar con datos" & ControlChars.CrLf & oExcep.Message & ControlChars.CrLf & oExcep.Server)

                Finally
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                End Try


                Return data

            End Function



            Public Shared Function InicioLote(ByVal user As ClsUsuario, ByVal lote As ClsLote, ByVal proyecto As clsProyecto, ByVal strcadenaConexion As String) As DataTable


                Dim con As SqlConnection = Nothing
                Dim cmd As SqlCommand


                Try

                    con = New SqlConnection()
                    con.ConnectionString = strcadenaConexion
                    cmd = New SqlCommand("update Lotes set FechaInicioA= getdate() ,HoraInicioA= getdate(),Asignado=1,UsuarioA='" & user._login & "' where lote=" & lote._idlote & " and Proyecto='" & proyecto._nombreProyecto & "' and FechaLote='" & lote._FechaLote & "' and TipoLote='" & lote._TipoLote & "'", con)

                    con.Open()

                    cmd.ExecuteNonQuery()


                Catch oExcep As SqlException
                    ' si se produce algún error lo capturamos mediante el objeto de excepciones particular para _
                    ' el proveedor de SQL Server

                    MessageBox.Show("Error al conectar con datos" & ControlChars.CrLf & oExcep.Message & ControlChars.CrLf & oExcep.Server)

                Finally
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                End Try

                Return Nothing

            End Function





            Public Shared Function InicioLoteCorreccion(ByVal user As ClsUsuario, ByVal lote As ClsLote, ByVal proyecto As clsProyecto, ByVal strcadenaConexion As String) As DataTable

                'qwe()
                Dim con As SqlConnection = Nothing
                Dim cmd As SqlCommand
                Dim data As DataTable = Nothing

                Try

                    con = New SqlConnection()
                    con.ConnectionString = strcadenaConexion
                    cmd = New SqlCommand("update Lotes set FechaInicioA= getdate() ,HoraInicioA= getdate(),Asignado=1,UsuarioA='" & user._login & "' where lote=" & lote._idlote & " and Proyecto='" & proyecto._nombreProyecto & "' and FechaLote='" & lote._FechaLote & "' and TipoLote='" & lote._TipoLote & "'", con)

                    con.Open()

                    cmd.ExecuteNonQuery()


                Catch oExcep As SqlException
                    ' si se produce algún error lo capturamos mediante el objeto de excepciones particular para _
                    ' el proveedor de SQL Server

                    MessageBox.Show("Error al conectar con datos" & ControlChars.CrLf & oExcep.Message & ControlChars.CrLf & oExcep.Server)

                Finally
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                End Try

                Return data

            End Function

            Public Shared Function ObtenerDatosParaVerificarIntegridadLote(ByVal proyecto As String, ByVal lote As Integer, ByVal cadenaConexion As String) As DataTable


                Dim datos As New DataTable
                Dim strSQL As String
                strSQL = "select id_lote,pagina, NomArchivoTif from Documentos where codigolote =" & lote & " and  Proyecto='" & proyecto & "'"

                Dim conexion As New SqlConnection(cadenaConexion)
                Dim cmdSQL As New SqlCommand(strSQL, conexion)
                Dim daDatos As New SqlDataAdapter(cmdSQL)

                Try
                    conexion.Open()

                    daDatos.Fill(datos)

                Catch ex As Exception
                    System.Windows.Forms.MessageBox.Show(ex.Message.ToString)
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                End Try

                Return datos

            End Function


            Public Shared Function MarcarLoteComoIndizado(ByVal numProyecto As String, ByVal lote As libreriacadenaproduccion.Entidades.ClsLote, ByVal strcadenaConexion As String) As Boolean
                Dim con As SqlConnection = Nothing
                Dim cmd As SqlCommand


                Dim dataAdapter As New SqlDataAdapter
                Dim strSQL As String

                'Si ponemos atributado=1, significa que ya esta indizado
                strSQL = "update Lotes set atributado=1 WHERE Proyecto='" & numProyecto & "' and lote ='" & lote._idlote & "'"
                Try
                    con = New SqlConnection()
                    con.ConnectionString = strcadenaConexion
                    cmd = New SqlCommand(strSQL, con)
                    con.Open()
                    cmd.ExecuteScalar()
                Catch oExcep As SqlException
                    MessageBox.Show(oExcep.Message)
                    Return False

                Finally
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                End Try

                Return True

            End Function
#End Region

#Region "obtener rutas propiedades de las imagenes"

            Public Shared Function ObtenerRaizRutaImagen(ByVal proyecto As String, ByVal cadenaConexion As String) As String

                Dim strSQL As String = "Select conf.rutaImagenes, pro.abreviatura from Configuracionproyecto as conf, proyectos as pro where pro.idProyecto='" & proyecto & "'" _
                & " AND pro.idProyecto = conf.idproyecto"

                Dim conexion As New SqlConnection(cadenaConexion)
                Dim cmdSQL As New SqlCommand(strSQL, conexion)
                Dim daDatos As New SqlDataAdapter(cmdSQL)
                Dim rutaImagenes = ""
                Dim dt As New DataTable

                Try
                    conexion.Open()
                    rutaImagenes = daDatos.Fill(dt)
                    rutaImagenes = dt.Rows(0).Item("rutaImagenes") & Path.DirectorySeparatorChar & dt.Rows(0).Item("abreviatura") & "\DIGI\" & dt.Rows(0).Item("abreviatura")
                Catch ex As Exception
                    System.Windows.Forms.MessageBox.Show(ex.Message.ToString)
                    rutaImagenes = "Error"

                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                End Try

                Return rutaImagenes

            End Function

            'obtener la ruta de las imagenes concatenando el nombre del fichero, imagen 
            Public Shared Function ObtenerRutaImagenes(ByVal proyecto As String, ByVal codigoLote As String, ByVal NombreArchivo As String, ByVal cadenaConexion As String) As String
                Try
                    Return ObtenerRaizRutaImagen(proyecto, cadenaConexion) & Format(Val(codigoLote), "00000") & Path.DirectorySeparatorChar & "Imagen" & Path.DirectorySeparatorChar & codigoLote & Path.DirectorySeparatorChar & NombreArchivo
                Catch ex As Exception
                    Return ""
                End Try
            End Function

            'obtener la ruta de las imagenes sin poner el nombre del fichero en cuestion 
            Public Shared Function ObtenerRutaImagenes(ByVal proyecto As String, ByVal codigoLote As String, ByVal cadenaConexion As String) As String
                Try
                    Return ObtenerRaizRutaImagen(proyecto, cadenaConexion) & Format(Val(codigoLote), "00000") & Path.DirectorySeparatorChar & "Imagen" & Path.DirectorySeparatorChar & codigoLote
                Catch ex As Exception
                    Return ""
                End Try
            End Function

            Public Shared Function ObtenerRutaImagenAPartirDeRaiz(ByVal rutaRaiz As String, ByVal codigoLote As String, ByVal NombreArchivo As String) As String

                Return rutaRaiz & Format(Val(codigoLote), "00000") & Path.DirectorySeparatorChar & "Imagen" & Path.DirectorySeparatorChar & codigoLote & Path.DirectorySeparatorChar & NombreArchivo

            End Function

            'Public Shared Function obtenerRutaDat(ByVal lote As ClsLote, ByVal numProyecto As String, ByVal ficherodat As String, ByVal strcadenaConexion As String) As Boolean


            '    Dim con As SqlConnection = Nothing
            '    Dim cmd As SqlCommand
            '    Dim ruta As String = ""
            '    Dim rutalocal As String = ""
            '    Dim rutaimagenes As String = ""
            '    Dim dataAdapter As New SqlDataAdapter
            '    Dim dReader As SqlDataReader
            '    Dim devuelve As Boolean

            '    If numProyecto <> "" And ficherodat <> "" Then

            '        Try
            '            con = New SqlConnection()
            '            con.ConnectionString = strcadenaConexion
            '            cmd = New SqlCommand("SELECT count(*) as ocurrencias, rutaimagenes from configuracion where proyecto=" & numProyecto & "", con)
            '            con.Open()

            '            dReader = cmd.ExecuteReader

            '            If dReader.Read() Then

            '            End If


            '        Catch oExcep As SqlException
            '            ' si se produce algún error lo capturamos mediante el objeto de excepciones particular para _
            '            ' el proveedor de SQL Server
            '            MessageBox.Show("Error al conectar con datos" & ControlChars.CrLf & oExcep.Message & ControlChars.CrLf & oExcep.Server)
            '            devuelve = False

            '        Finally
            '            If con.State = ConnectionState.Open Then
            '                con.Close()
            '            End If
            '        End Try

            '        Return devuelve

            '    End If



            'End Function

#End Region



#Region "operaciones sobre los documentos"

            Public Shared Function ActualizarDocumentoAPartirDeDataRow(ByVal fila As System.Windows.Forms.DataGridViewRow, ByVal tabla As String, ByVal cadenaConexion As String) As Integer

                Dim numero = 0
                Dim columna As String

                Dim sql As String = "Update " & tabla & " set "

                For Each celda As System.Windows.Forms.DataGridViewCell In fila.Cells



                    columna = fila.DataGridView.Columns(celda.ColumnIndex).HeaderText

                    If celda.ValueType.ToString() = "Int32" Then

                        sql = sql & columna & "=" & fila.Cells(columna).Value.ToString() & ", "

                    Else 'necesitara comillas
                        sql = sql & columna & "='" & fila.Cells(columna).Value.ToString() & "', "

                    End If
                Next

                'borramos el ultimo "', "

                sql = sql.Remove(sql.LastIndexOf(","))

                sql = sql & " Where id=" & fila.Cells("id").Value.ToString()


                Dim conexion As New SqlConnection(cadenaConexion)
                Dim cmdSQL As New SqlCommand(sql, conexion)


                Try
                    conexion.Open()

                    numero = cmdSQL.ExecuteNonQuery()



                Catch ex As Exception
                    System.Windows.Forms.MessageBox.Show(ex.Message.ToString)
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                End Try



                If Not IsNothing(numero) Then

                    Return numero
                Else
                    Return 0

                End If


            End Function


            Public Shared Function ActualizarTablaDocumentos(ByVal numeroIcu As String, ByVal NHC As String, ByVal id As Integer, ByVal strcadenaConexion As String) As Boolean

                Dim con As SqlConnection = Nothing
                Dim cmd As SqlCommand
                Dim numero As Integer
                Dim ok As Boolean = False
                Dim dataAdapter As New SqlDataAdapter
                Dim strSQL As String

                Try

                    con = New SqlConnection()

                    con.ConnectionString = strcadenaConexion

                    strSQL = "UPDATE documentos set numicu='" & numeroIcu & "', numHistoria='" & NHC & "' where id=" & id & ""

                    cmd = New SqlCommand(strSQL, con)

                    con.Open()

                    numero = cmd.ExecuteNonQuery()

                    'Falta actualizar pagina y modificar esta para que quede como atributada

                Catch oExcep As SqlException
                    MessageBox.Show("Error al conectar con datos" & ControlChars.CrLf & oExcep.Message & ControlChars.CrLf & oExcep.Server)
                    Return False

                Finally
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                End Try


                Return True

            End Function


            Public Shared Function ObtenerPaginasDocumentosLote(ByVal lote As libreriacadenaproduccion.Entidades.ClsLote, ByVal numProyecto As String, ByVal strcadenaConexion As String) As DataTable

                Dim con As SqlConnection = Nothing
                Dim cmd As SqlCommand

                Dim data As New DataTable
                Dim dataAdapter As New SqlDataAdapter
                Dim strSQL As String

                Try

                    con = New SqlConnection()

                    con.ConnectionString = strcadenaConexion

                    strSQL = "SELECT Id,NomArchivoTIF,InicioDevice,SizeDevice,Indizado,NumIcu,NumHistoria,TipoDocumento,Pagina"
                    strSQL = strSQL & " from Documentos where Proyecto='" & numProyecto & "' and CodigoLote=" & lote._idlote & " and TipoLote='" & lote._TipoLote & "' and FechaLote='" & lote._FechaLote & "'"
                    strSQL = strSQL & " ORDER BY id ASC"

                    cmd = New SqlCommand(strSQL, con)

                    dataAdapter.SelectCommand = cmd

                    con.Open()

                    dataAdapter.Fill(data)

                Catch oExcep As SqlException
                    ' si se produce algún error lo capturamos mediante el objeto de excepciones particular para _
                    ' el proveedor de SQL Server
                    MessageBox.Show("Error al conectar con datos" & ControlChars.CrLf & oExcep.Message & ControlChars.CrLf & oExcep.Server)
                    data = Nothing

                Finally
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                End Try


                Return data

            End Function

            Public Shared Function ObtenerPaginasDocumentosLoteTipo(ByVal lote As libreriacadenaproduccion.Entidades.ClsLote, ByVal numProyecto As String, ByVal strcadenaConexion As String, Optional ByVal tipo As Integer = 0) As DataTable

                Dim con As SqlConnection = Nothing
                Dim cmd As SqlCommand

                Dim data As New DataTable
                Dim dataAdapter As New SqlDataAdapter
                Dim strSQL As String = ""

                Try

                    con = New SqlConnection()

                    con.ConnectionString = strcadenaConexion

                    If tipo = 0 Then

                        strSQL = "SELECT Id,NomArchivoTIF,InicioDevice,SizeDevice,Indizado,NumIcu,NumHistoria,TipoDocumento,Pagina"
                        strSQL = strSQL & " from Documentos where Proyecto='" & numProyecto & "' and CodigoLote=" & lote._idlote & " and TipoLote='" & lote._TipoLote & "' and FechaLote='" & lote._FechaLote & "'"
                        strSQL = strSQL & " ORDER BY id ASC"

                    ElseIf tipo <> 0 Then

                        strSQL = "SELECT Id,NomArchivoTIF,InicioDevice,SizeDevice,Indizado,NumIcu,NumHistoria,TipoDocumento,Pagina"
                        strSQL = strSQL & " from Documentos where Proyecto='" & numProyecto & "' and CodigoLote=" & lote._idlote & "' and TipoDocumento=" & tipo & " and TipoLote='" & lote._TipoLote & "' and FechaLote='" & lote._FechaLote & "'"
                        strSQL = strSQL & " ORDER BY id ASC"

                    End If

                    cmd = New SqlCommand(strSQL, con)

                    dataAdapter.SelectCommand = cmd

                    con.Open()

                    dataAdapter.Fill(data)

                Catch oExcep As SqlException
                    ' si se produce algún error lo capturamos mediante el objeto de excepciones particular para _
                    ' el proveedor de SQL Server
                    MessageBox.Show("Error al conectar con datos" & ControlChars.CrLf & oExcep.Message & ControlChars.CrLf & oExcep.Server)
                    data = Nothing

                Finally
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                End Try


                Return data

            End Function


            Public Shared Function obtenerUltimaHojaVisitada(ByVal lote As libreriacadenaproduccion.Entidades.ClsLote, ByVal proy As String, ByVal strcadenaConexion As String) As Integer

                Dim con As SqlConnection = Nothing
                Dim cmd As SqlCommand

                Dim numero As Integer = 0
                Dim dataAdapter As New SqlDataAdapter
                Dim strSQL As String

                Try
                    strSQL = "Select ImgActual from lotes where Lote =" & lote._idlote & " and proyecto ='" & proy & "'"
                    con = New SqlConnection()
                    con.ConnectionString = strcadenaConexion

                    cmd = New SqlCommand(strSQL, con)
                    con.Open()

                    numero = CType(cmd.ExecuteScalar(), Integer)

                    'Falta actualizar pagina y modificar esta para que quede como atributada

                Catch oExcep As SqlException
                    MessageBox.Show(oExcep.Message)
                    Return 0

                Finally
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                End Try

                Return numero

            End Function

            Public Shared Function modificarUltimaHojaVisitada(ByVal lote As libreriacadenaproduccion.Entidades.ClsLote, ByVal proy As String, ByVal strcadenaConexion As String) As Boolean

                Dim con As SqlConnection = Nothing
                Dim cmd As SqlCommand


                Dim dataAdapter As New SqlDataAdapter
                Dim strSQL As String

                Try
                    strSQL = "Update lotes set ImgActual = " & lote._NumImgActual & " where Lote =" & lote._idlote & " and proyecto ='" & proy & "'"
                    con = New SqlConnection()
                    con.ConnectionString = strcadenaConexion
                    cmd = New SqlCommand(strSQL, con)
                    con.Open()
                    cmd.ExecuteScalar()
                Catch oExcep As SqlException
                    MessageBox.Show(oExcep.Message)
                    Return False

                Finally
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                End Try

                Return True

            End Function

            Public Shared Function ObtenerTiposDocumentosHospital(ByVal codigoHospital As String, ByVal cadenaConexion As String) As DataTable


                Dim datos As New DataTable
                Dim strSQL As String
                strSQL = "Select Codigo,Descripcion,CodigoAmpliado from TiposDocumentos where Cliente=" & codigoHospital & " order by Codigo asc"

                Dim conexion As New SqlConnection(cadenaConexion)
                Dim cmdSQL As New SqlCommand(strSQL, conexion)
                Dim daDatos As New SqlDataAdapter(cmdSQL)

                Try
                    conexion.Open()

                    daDatos.Fill(datos)

                Catch ex As Exception
                    System.Windows.Forms.MessageBox.Show(ex.Message.ToString)
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                End Try

                Return datos

            End Function

#End Region


















        End Class






    End Namespace
End Namespace
