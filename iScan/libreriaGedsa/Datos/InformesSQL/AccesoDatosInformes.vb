Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports libreriacadenaproduccion.Entidades

Namespace Datos
    Namespace InformesSQL

        Public Class AccesoDatosInformes

            Public Enum estadoEpisodio

                sinCodificar = 0
                codificado = 1
                incompleto = 2
                inactivo = 3

            End Enum

            Public Shared Function obtenerEpisodiosMes(ByVal mes As Integer, ByVal año As Integer, ByVal hospital As String, ByVal estadoEpi As estadoEpisodio, ByVal cadenaConexion As String)

                Dim strSQL As String
                Dim conexion As SqlConnection
                Dim cmdSQL As SqlCommand

                Dim numRegs As Integer

                strSQL = "SELECT COUNT(*) "
                strSQL = strSQL & "FROM cmbdCodificacion c, datosCodificacion d "
                strSQL = strSQL & "WHERE c.HOSPITAL = d.hospital "
                strSQL = strSQL & "AND c.HISTORIA = d.historia "
                strSQL = strSQL & "AND c.NUMICU = d.numicu "
                strSQL = strSQL & "AND c.hospital = '" & hospital & "' "
                strSQL = strSQL & "AND MONTH(c.fecing) = " & mes & " "
                strSQL = strSQL & "AND YEAR(c.fecing) = " & año & " "

                Select Case estadoEpi

                    Case estadoEpisodio.sinCodificar
                        strSQL = strSQL & "AND d.nivelCodificacion = 0 "

                    Case estadoEpisodio.codificado
                        strSQL = strSQL & "AND d.nivelCodificacion = 1 "

                    Case estadoEpisodio.incompleto
                        strSQL = strSQL & "AND d.nivelCodificacion = 2 "

                    Case estadoEpisodio.inactivo
                        strSQL = strSQL & "AND d.inactivo = 1 "

                End Select

                conexion = New SqlConnection(cadenaConexion)
                cmdSQL = New SqlCommand(strSQL, conexion)

                Try
                    conexion.Open()

                    If Not Integer.TryParse(cmdSQL.ExecuteScalar().ToString(), numRegs) Then
                        numRegs = 0
                    End If

                Catch ex As Exception
                    numRegs = 0
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                End Try

                Return numRegs

            End Function

        End Class

    End Namespace
End Namespace
