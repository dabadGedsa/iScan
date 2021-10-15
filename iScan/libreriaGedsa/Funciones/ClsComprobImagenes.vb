Imports System.IO

Namespace Funciones

    Public Class ClsComprobImagenes

        Public Function ComprobarImagenes(ByVal cadenaconexion As String, ByVal tablaimg As String, ByVal columimg As String) As Boolean
            'Recorrido Calidad, vuelve a comprobar que todos los insertados se encuentran
            'también copiados en el fichero destino

            Dim estaok As Boolean = True
            Dim strSQL As String
            Dim listado As New DataTable

            strSQL = "select " & columimg & " from " & tablaimg & ""

            Dim conexion As New OleDb.OleDbConnection(cadenaconexion)
            Dim cmdSQL As New OleDb.OleDbCommand(strSQL, conexion)
            Dim daDatos As New OleDb.OleDbDataAdapter(cmdSQL)

            Try
                conexion.Open()

                daDatos.Fill(listado)

                For Each registro As DataRow In listado.Rows
                    Dim pathimg As String
                    pathimg = registro.Item(columimg)

                    'comprobar si existe la imagen en el path seleccionado
                    If Not File.Exists(pathimg) Then
                        'existe
                        estaok = False
                        MsgBox("No se ha encontrado la imagen en la ruta " & pathimg)
                    End If

                Next

            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            Finally
                If conexion.State = ConnectionState.Open Then
                    conexion.Close()
                End If
            End Try

            Return estaok
        End Function


    End Class

End Namespace
