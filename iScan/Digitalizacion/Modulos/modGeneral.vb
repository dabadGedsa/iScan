Imports accesoDatos = LibreriaCadenaProduccion.Datos.GeneralSQL.clsAccesoDatosSQL

Module modGeneral

    Public listaTipoLotes As List(Of Entidades.clsTipoLotesE)
    Public seleccionadaUbicacionCliente As Integer = 0 '0 = Cierra pantalla sin realizar acción, 1 = Continua sin realizar selección para una indización manual, 2 = Selecciona Archivador y carpeta

    Public listaHistoriasGECI As New List(Of Integer)
    Public listaHistoriasServicio_GECI As New List(Of String)

    Public Function EstaLoteCorregido(ByVal idlote As Integer, ByVal cadenaConexion As String) As Boolean

        Dim documentos As DataTable
        Dim strSQL As String

        strSQL = "select * from documentos d inner join documentosincidencias di on di.IdDocumento=d.IdDocumento where idlote = " & idlote & " and (incidencia=1) and (eliminada <> 1) and di.IdIncidencia<>2"
        documentos = accesoDatos.ejecutarSQLDirectaTable(strSQL, cadenaConexion)

        If documentos.Rows.Count > 0 Then
            Return False
        Else
            Return True
        End If

    End Function

    Public Sub cargaEjecucionAutomatas(ByVal lista As ListBox, ByVal cadenaConexion As String)

        Dim dt As DataTable
        Dim strSQL As String
        Dim resultado As String = ""
        Dim contador As Integer = 0

        Try
            lista.Items.Clear()

            strSQL = "select APLICACION from EJECUCION_AUTOMATAS GROUP BY APLICACION"
            dt = accesoDatos.ejecutarSQLDirectaTable(strSQL, cadenaConexion)

            If dt.Rows.Count > 0 Then
                For Each dr As DataRow In dt.Rows
                    strSQL = "SELECT TOP (1) * FROM EJECUCION_AUTOMATAS WHERE APLICACION='" & dr.Item("Aplicacion").ToString.Trim & "' ORDER BY FechaUltimaEjecucion DESC"
                    dt = accesoDatos.ejecutarSQLDirectaTable(strSQL, cadenaConexion)
                    If dt.Rows.Count > 0 Then
                        lista.Items.Add(dt.Rows(0).Item("Aplicacion").ToString.Trim & " -> Última ejec.: " & dt.Rows(0).Item("FechaUltimaEjecucion") & ". Próxima eje.: " & dt.Rows(0).Item("FechaProximaEjecucion"))
                    End If
                    contador += 1
                Next
            Else
                lista.Items.Add("No hay autómatas disponibles.")
            End If

        Catch ex As Exception
            lista.Items.Add("ERROR al cargar información de ejecución de los autómatas.")
        Finally

        End Try

    End Sub

    Public Function cargaTipoLotes(ByVal proyecto As String, ByVal cadenaConexionADM As String) As List(Of Entidades.clsTipoLotesE)
        Dim elemento As Entidades.clsTipoLotesE
        Dim lista As New List(Of Entidades.clsTipoLotesE)
        Dim strSQL As String = ""
        Dim dt As DataTable

        Try
            strSQL = "SELECT * FROM CONFIGURACION_TIPOLOTES WHERE IdProyecto='" & proyecto & "' ORDER BY Nombre"
            dt = accesoDatos.ejecutarSQLDirectaTable(strSQL, cadenaConexionADM)
            If dt.Rows.Count > 0 Then
                For Each dr As DataRow In dt.Rows
                    elemento = New Entidades.clsTipoLotesE(dr.Item("IdProyecto").ToString.Trim, dr.Item("Nombre").ToString.Trim, dr.Item("PrefijoVolumen").ToString.Trim, dr.Item("PrefijoCB").ToString.Trim)

                    lista.Add(elemento)
                Next
            End If

        Catch ex As Exception
            lista = Nothing

        Finally
            cargaTipoLotes = lista

        End Try

    End Function

    Public Sub EjecutarComandoSHELL(ByVal rutaEjecutable As String, ByVal parámetros As String)

        Dim comando As String

        Try

            comando = rutaEjecutable & " " & parámetros

            Shell(comando, AppWinStyle.Hide, True, -1)

        Catch ex As Exception

        End Try

    End Sub
End Module
