Imports Digitalización.Entidades
Imports System.Data.SqlClient

Namespace accesoDatosNuevos

    Public Class clsAccesoDatosNUEVO

        Public Shared Function ejecutarSQLConTransaccion(ByVal consultas As String, ByVal cadenaConexion As String) As String

            Dim mensaje As String = ""
            ' ''Dim conexion As SqlConnection = Nothing
            Dim comando As SqlCommand
            Dim MyTrans As SqlTransaction = Nothing

            Try

                Using conexion = New SqlConnection(cadenaConexion)
                    conexion.Open()

                    MyTrans = conexion.BeginTransaction()

                    ' ''strSQL = "UPDATE " & basedatos & ".dbo.documentos set incidencia='0' WHERE iddocumento='" & idDocumento & "'" _
                    ' '' & ";DELETE from " & basedatos & ".dbo.documentosincidencias WHERE iddocumento='" & idDocumento & "'"
                    comando = New SqlCommand(consultas, conexion)
                    comando.Transaction = MyTrans
                    comando.ExecuteNonQuery()

                    MyTrans.Commit()
                End Using

            Catch ex As SqlException
                MyTrans.Rollback()
                Throw ex
            Finally
                ' ''If conexion.State = ConnectionState.Open Then
                ' ''    conexion.Close()
                ' ''End If
                ejecutarSQLConTransaccion = mensaje
            End Try

        End Function

        Public Shared Function ejecutaSQLEjecucion(ByVal sql As String, ByVal cadenaConexion As String, Optional ByRef filasAfectadas As Integer = -1, Optional ByVal muestraError As Boolean = True) As Boolean
            Dim correcto As Boolean = False
            ' ''Dim conexion As SqlConnection = Nothing

            Try
                Using conexion As New SqlConnection(cadenaConexion)
                    Using comando As New SqlCommand(sql, conexion)
                        ' ''conexion = New SqlConnection(cadenaConexion)
                        conexion.Open()
                        Dim cmd As SqlCommand = New SqlCommand(sql, conexion)
                        filasAfectadas = cmd.ExecuteNonQuery()
                    End Using
                End Using

                correcto = True

            Catch ex As Exception
                If muestraError Then
                    MessageBox.Show(ex.Message.ToString)
                Else
                    Throw ex
                End If

            Finally
                ' ''If conexion IsNot Nothing Then
                ' ''    If conexion.State = ConnectionState.Open Then conexion.Close()
                ' ''End If
            End Try

            Return correcto

        End Function

        Public Shared Function cargaDocumentos(ByVal cadenaConexion As String, ByVal consulta As String, ByVal codigoProyecto As String, ByVal rutaImagenes As String) As List(Of clsDocumentoE)
            Dim dr As SqlDataReader = Nothing
            Dim doc As clsDocumentoE
            Dim listaDoc As New List(Of clsDocumentoE)

            Try

                Using conexion As New SqlConnection(cadenaConexion)
                    Using comando As New SqlCommand(consulta, conexion)

                        conexion.Open()

                        dr = comando.ExecuteReader()

                        If dr.HasRows Then
                            Do While dr.Read()
                                doc = New clsDocumentoE

                                doc._idDocumento = dr("idDocumento")
                                doc._Lote = dr("idLote")
                                doc._pagina = dr("Pagina")
                                doc._nombreArchivo = dr("NomArchivoTIF").ToString.Trim

                                doc._TipoDocumento = New clsTipoDocumentoE()
                                If IsDBNull(dr("Descripcion")) Then doc._TipoDocumento._DescripcionTipoDocumento = Nothing Else doc._TipoDocumento._DescripcionTipoDocumento = dr("Descripcion").ToString.Trim
                                If IsDBNull(dr("idTipoDocumento")) Then doc._TipoDocumento._idTipoDocumento = Nothing Else doc._TipoDocumento._idTipoDocumento = dr("idTipoDocumento").ToString.Trim
                                If IsDBNull(dr("DefinicionCliente")) Then doc._TipoDocumento._DescripcionTipoDocumentoCliente = Nothing Else doc._TipoDocumento._DescripcionTipoDocumentoCliente = dr("DefinicionCliente").ToString.Trim
                                If IsDBNull(dr("idTipoDocumentoCliente")) Then doc._TipoDocumento._idTipoDocumentoCliente = Nothing Else doc._TipoDocumento._idTipoDocumentoCliente = dr("idTipoDocumentoCliente").ToString.Trim
                                If IsDBNull(dr("CodigoOrdenacion")) Then doc._TipoDocumento._codigoOrdenacion = Nothing Else doc._TipoDocumento._codigoOrdenacion = dr("CodigoOrdenacion").ToString.Trim

                                doc._fechaInicio = dr("FechaInicio").ToString.Trim
                                doc._fechaFin = dr("FechaTermino").ToString.Trim
                                doc._fechaDocumento = dr("FechaDocumento").ToString.Trim

                                doc._Servicio = New clsServicioE()
                                If IsDBNull(dr("idServicio")) Then doc._Servicio._idServicio = Nothing Else doc._Servicio._idServicio = dr("idServicio")
                                If IsDBNull(dr("cod_servicio")) Then doc._Servicio._codigoServicio = Nothing Else doc._Servicio._codigoServicio = dr("cod_servicio").ToString.Trim
                                If IsDBNull(dr("Descripcion")) Then doc._Servicio._descripcionServicio = Nothing Else doc._Servicio._descripcionServicio = dr("descripcion").ToString.Trim
                                If IsDBNull(dr("area")) Then doc._Servicio._area = Nothing Else doc._Servicio._area = dr("area").ToString.Trim
                                If IsDBNull(dr("Visible")) Then doc._Servicio._visible = Nothing Else doc._Servicio._visible = dr("Visible")

                                doc._tipoEpisodio = dr("TipoEpisodioPAED").ToString.Trim
                                doc._numIcu = dr("numIcu").ToString.Trim
                                If dr("NumHistoria").ToString.Trim <> "" Then
                                    doc._historia = dr("NumHistoria").ToString.Trim
                                End If
                                If IsDBNull(dr("indizado")) Then
                                    doc._Indizado = 0
                                Else
                                    doc._Indizado = dr("indizado")
                                End If
                                If IsDBNull(dr("BarCodeDet")) Then
                                    doc._BarCodeDet = 0
                                Else
                                    If dr("BarCodeDet") = 1 Then
                                        doc._BarCodeDet = 1
                                    Else
                                        doc._BarCodeDet = 0
                                    End If
                                End If
                                If IsDBNull(dr("Incidencia")) Then
                                    doc._Incidencia = 0
                                Else
                                    doc._Incidencia = dr("Incidencia")
                                End If
                                If IsDBNull(dr("Eliminada")) Then
                                    doc._Eliminado = 0
                                Else
                                    doc._Eliminado = dr("Eliminada")
                                End If
                                If IsDBNull(dr("documentoEnLocal")) Then
                                    doc._documentoEnLocal = False
                                    doc._rutaDocumento = rutaImagenes & "\" & Format(Val(codigoProyecto), "0000") & "\DIGI\" & Format(Val(codigoProyecto), "0000") & Format(Val(doc._Lote), "00000") & "\Imagen\" & doc._Lote & "\" & doc._nombreArchivo
                                Else
                                    If dr("documentoEnLocal") = 0 Then
                                        doc._documentoEnLocal = False
                                        doc._rutaDocumento = rutaImagenes & "\" & Format(Val(codigoProyecto), "0000") & "\DIGI\" & Format(Val(codigoProyecto), "0000") & Format(Val(doc._Lote), "00000") & "\Imagen\" & doc._Lote & "\" & doc._nombreArchivo
                                    Else
                                        doc._documentoEnLocal = True
                                        doc._rutaDocumento = My.Settings.DIGI_rutaLocalImagenes & "\" & Format(Val(codigoProyecto), "0000") & "\DIGI\" & Format(Val(codigoProyecto), "0000") & Format(Val(doc._Lote), "00000") & "\Imagen\" & doc._Lote & "\" & doc._nombreArchivo
                                    End If
                                End If
                                doc._documentoEnBD = True

                                listaDoc.Add(doc)
                            Loop
                        End If
                    End Using
                End Using

            Catch ex As Exception
                Throw ex

            Finally
                dr.Close()
                cargaDocumentos = listaDoc

            End Try
        End Function

        Public Shared Function ejecutarSQLDirectaTable(ByVal SQL As String, ByVal cadenaConexion As String) As DataTable

            Dim ds As New DataTable

            Try
                Using conexion = New SqlConnection(cadenaConexion)
                    Using cmd As New SqlCommand(SQL, conexion)
                        conexion.Open()

                        Dim daDatos As SqlDataAdapter = New SqlDataAdapter(cmd)
                        daDatos.Fill(ds)
                    End Using
                End Using

            Catch ex As Exception
                Throw ex

            Finally
                ' ''If conexion IsNot Nothing Then
                ' ''    If conexion.State = ConnectionState.Open Then conexion.Close()
                ' ''End If
            End Try
            Return ds
        End Function

        Public Shared Function ObtenerValor(ByVal CadenaConexion As String, ByVal StrSQL As String) As Object

            Dim ret As Object = Nothing

            Try
                Using conexion As New SqlConnection(CadenaConexion)
                    Using comando = New SqlCommand(StrSQL, conexion)
                        conexion.Open()
                        ret = comando.ExecuteScalar()
                    End Using
                End Using

                Return ret

            Catch ex As Exception
                ret = Nothing
                Throw ex

            Finally

            End Try
        End Function

        Public Shared Function DevuelveExcelEnDataTable(ByVal FileName As String, ByVal NombreHoja As String, ByVal filtro As String) As DataTable

            Dim sql As String = ""

            Using cnn As OleDb.OleDbConnection = New OleDb.OleDbConnection()

                Try

                    cnn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" &
                        "Extended Properties=Excel 8.0;" &
                        "Data Source=" + FileName

                    ' ''            cnn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" & _
                    ' ''"Extended Properties='Excel 8.0;HDR=Yes;';" & _
                    ' ''"Data Source=" + FileName

                    If filtro.ToString.Trim = "" Then
                        sql = "SELECT * FROM [" + NombreHoja & "$]"
                    Else
                        sql = "SELECT * FROM [" + NombreHoja & "$] WHERE [TIPO] = " & filtro
                    End If

                    Using da As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(sql, cnn)

                        Dim dt As DataTable = New DataTable(FileName)

                        da.Fill(dt)

                        Return dt
                    End Using


                Catch ex As Exception
                    Throw ex
                End Try

            End Using

        End Function

        Public Function marcaErrorLote_EnvioWS(ByVal idLote As Integer, ByVal CadenaConexion As String) As String
            Dim resultado As String = ""
            Dim lsSql As String

            Try
                'Borra la incidencia especificada
                lsSql = "UPDATA LOTES SET erroresEnvio=1 WHERE idLote=" & idLote

                ejecutaSQLEjecucion(lsSql, CadenaConexion)

                marcaErrorLote_EnvioWS = ""

            Catch ex As Exception
                marcaErrorLote_EnvioWS = ex.Message
            End Try
        End Function

        Public Function desmarcaErrorLote_EnvioWS(ByVal idLote As Integer, ByVal CadenaConexion As String) As String
            Dim resultado As String = ""
            Dim lsSql As String

            Try
                'Borra la incidencia especificada
                lsSql = "UPDATA LOTES SET erroresEnvio=NULL WHERE idLote=" & idLote

                ejecutaSQLEjecucion(lsSql, CadenaConexion)

                desmarcaErrorLote_EnvioWS = ""

            Catch ex As Exception
                desmarcaErrorLote_EnvioWS = ex.Message
            End Try
        End Function

    End Class
End Namespace