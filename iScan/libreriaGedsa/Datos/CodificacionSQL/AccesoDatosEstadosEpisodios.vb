Imports System.Data.SqlClient
Imports libreriacadenaproduccion.Entidades
Imports System.Windows.Forms


Namespace Datos


    Namespace CodificacionSQL

        Public Class AccesoDatosEstadosEpisodios

            Public Shared Function obtenerNivelCodificacionEspisodio(ByVal epi As ClsEpisodio, ByVal strCadenaConexion As String)


                Dim numero = Nothing

                Dim strSQL As String
                Dim cmdSQL As SqlCommand
                Dim conexion As SqlConnection

                Dim hosp As String = epi.valorHospital
                Dim nunICU As String = epi.valorNumIcu
                Dim NHC As String = epi.valorNHC


                strSQL = "select nivelCodificacion from datosCodificacion where hospital='" & hosp & "' and  historia='" & NHC & "' and  numICU='" & nunICU & "'"

                conexion = New SqlConnection(strCadenaConexion)
                cmdSQL = New SqlCommand(strSQL, conexion)


                Try
                    conexion.Open()
                    numero = cmdSQL.ExecuteScalar()

                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString)
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                End Try

                Return numero


            End Function


            Public Shared Function obtenerEstadoActivoEspisodio(ByVal epi As ClsEpisodio, ByVal strCadenaConexion As String) As Integer


                Dim numero = Nothing

                Dim strSQL As String
                Dim cmdSQL As SqlCommand
                Dim conexion As SqlConnection

                Dim hosp As String = epi.valorHospital
                Dim nunICU As String = epi.valorNumIcu
                Dim NHC As String = epi.valorNHC


                strSQL = "select activo from datosCodificacion where hospital='" & hosp & "' and  historia='" & NHC & "' and  numICU='" & nunICU & "'"

                conexion = New SqlConnection(strCadenaConexion)
                cmdSQL = New SqlCommand(strSQL, conexion)


                Try
                    conexion.Open()
                    numero = cmdSQL.ExecuteScalar()

                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString)
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                End Try

                Return numero


            End Function


            'Public Shared Function iniciarCodificacion(ByVal epi As ClsEpisodio, ByVal strCadenaConexion As String)


            '    Dim numero As Integer


            '    Dim strSQL As String
            '    Dim cmdSQL As SqlCommand
            '    Dim conexion As SqlConnection

            '    Dim hosp As String = epi.valorHospital
            '    Dim nunICU As String = epi.valorNumIcu
            '    Dim NHC As String = epi.valorNHC




            '    strSQL = "update datosCodificacion set nivelCodificacion = 0 , fechaInicioCodificacion='" & Date.Parse(Date.Now.ToShortDateString()) & "' where hospital='" & hosp & "' and historia='" & NHC & "'and  numICU='" & nunICU & "'"




            '    conexion = New SqlConnection(strCadenaConexion)
            '    cmdSQL = New SqlCommand(strSQL, conexion)


            '    Try
            '        conexion.Open()
            '        numero = cmdSQL.ExecuteNonQuery

            '    Catch ex As Exception
            '        MessageBox.Show(ex.Message.ToString)
            '    Finally
            '        If conexion.State = ConnectionState.Open Then
            '            conexion.Close()
            '        End If
            '    End Try


            '    If numero > 0 Then ' resultado del update
            '        Return True
            '    Else
            '        Return False
            '    End If




            'End Function


            'Public Shared Function obtenerUsuarioDeEpisodio(ByVal epi As ClsEpisodio, ByVal strCadenaConexion As String) As String

            '    Dim usu As String = ""

            '    Dim strSQL As String
            '    Dim cmdSQL As SqlCommand
            '    Dim conexion As SqlConnection

            '    Dim hosp As String = epi.valorHospital
            '    Dim nunICU As String = epi.valorNumIcu
            '    Dim NHC As String = epi.valorNHC


            '    strSQL = "select asignadoA from datosCodificacion where hospital='" & hosp & "' and historia='" & NHC & "' and numICU='" & nunICU & "'"

            '    conexion = New SqlConnection(strCadenaConexion)
            '    cmdSQL = New SqlCommand(strSQL, conexion)


            '    Try
            '        conexion.Open()
            '        usu = IIf(cmdSQL.ExecuteScalar() Is DBNull.Value, "", cmdSQL.ExecuteScalar())

            '    Catch ex As Exception
            '        MessageBox.Show(ex.Message.ToString)
            '    Finally
            '        If conexion.State = ConnectionState.Open Then
            '            conexion.Close()
            '        End If
            '    End Try

            '    Return usu


            'End Function


            Public Shared Function modificarNivelCodificacionEspisodio(ByVal epi As ClsEpisodio, ByVal estado As Integer, ByVal strCadenaConexion As String) As Boolean


                Dim numero = Nothing

                Dim estadoFinalizado As Integer = 1 'lo declaro qui por si luego cambia en numero que representa el estado Codificacion Completa
                Dim strSQL As String
                Dim cmdSQL As SqlCommand
                Dim conexion As SqlConnection

                Dim hosp As String = epi.valorHospital
                Dim nunICU As String = epi.valorNumIcu
                Dim NHC As String = epi.valorNHC



                If estado = estadoFinalizado Then 'lo acaban de finalizar
                    strSQL = "update datosCodificacion set nivelCodificacion =" & estado & ", codificado=1, fechaFinCodificacion='" & Date.Parse(Date.Now.ToShortDateString()) & "' where hospital='" & hosp & "' and  historia='" & NHC & "' and  numICU='" & nunICU & "'"
                Else
                    strSQL = "update datosCodificacion set nivelCodificacion =" & estado & "  where hospital='" & hosp & "' and  historia='" & NHC & "' and  numICU='" & nunICU & "'"
                End If


                conexion = New SqlConnection(strCadenaConexion)
                cmdSQL = New SqlCommand(strSQL, conexion)


                Try
                    conexion.Open()
                    numero = cmdSQL.ExecuteNonQuery

                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString)
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                End Try


                If numero > 0 Then ' resultado del update
                    Return True
                Else
                    Return False
                End If


            End Function




            Public Shared Function modificarEstadoActivoCodificacionEpisodio(ByVal epi As ClsEpisodio, ByVal estadoActivo As Integer, ByVal strCadenaConexion As String)


                Dim numero = Nothing

                Dim strSQL As String
                Dim cmdSQL As SqlCommand
                Dim conexion As SqlConnection

                Dim hosp As String = epi.valorHospital
                Dim nunICU As String = epi.valorNumIcu
                Dim NHC As String = epi.valorNHC


                strSQL = "update datosCodificacion set activo =" & estadoActivo & "  where hospital='" & hosp & "' and  historia='" & NHC & "' and  numICU='" & nunICU & "'"

                conexion = New SqlConnection(strCadenaConexion)
                cmdSQL = New SqlCommand(strSQL, conexion)


                Try
                    conexion.Open()
                    numero = cmdSQL.ExecuteNonQuery

                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString)
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                End Try


                If numero > 0 Then ' resultado del update
                    Return True
                Else
                    Return False
                End If


            End Function


            'Public Shared Function verificarSiIniciado(ByVal epi As ClsEpisodio, ByVal strCadenaConexion As String) As Boolean
            '    'comprueba si una codificacion tiene fecha de inicio, es decir, si ya ha sido iniciada anteriormente

            '    Dim fechainicio

            '    Dim strSQL As String
            '    Dim cmdSQL As SqlCommand
            '    Dim conexion As SqlConnection

            '    Dim hosp As String = epi.valorHospital
            '    Dim nunICU As String = epi.valorNumIcu
            '    Dim NHC As String = epi.valorNHC


            '    strSQL = "select fechaInicioCodificacion from datosCodificacion where hospital='" & hosp & "' and  historia='" & NHC & "' and  numICU='" & nunICU & "'"

            '    conexion = New SqlConnection(strCadenaConexion)
            '    cmdSQL = New SqlCommand(strSQL, conexion)


            '    Try
            '        conexion.Open()
            '        fechainicio = cmdSQL.ExecuteScalar()

            '    Catch ex As Exception
            '        MessageBox.Show(ex.Message.ToString)
            '    Finally
            '        If conexion.State = ConnectionState.Open Then
            '            conexion.Close()
            '        End If
            '    End Try

            '    If TypeOf (fechainicio) Is DBNull Then ' si no tiene fecha de inicio, es la primera vez
            '        Return True
            '    Else 'ya ha sido "empezado" antes
            '        Return False
            '    End If


            'End Function


            'Public Shared Function verificarSiCompleto(ByVal epi As ClsEpisodio, ByVal strcadenaconexion As String) As Boolean
            '    'comprueba si una codificacion tiene fecha de inicio, es decir, si ya ha sido iniciada anteriormente

            '    Dim codificado As Boolean = False

            '    Dim strSQL As String
            '    Dim cmdSQL As SqlCommand
            '    Dim conexion As SqlConnection

            '    Dim hosp As String = epi.valorHospital
            '    Dim nunICU As String = epi.valorNumIcu
            '    Dim NHC As String = epi.valorNHC


            '    strSQL = "select codificado from datosCodificacion where hospital='" & hosp & "' and  historia='" & NHC & "' and  numICU='" & nunICU & "'"

            '    conexion = New SqlConnection(strcadenaconexion)
            '    cmdSQL = New SqlCommand(strSQL, conexion)


            '    Try
            '        conexion.Open()
            '        codificado = IIf(cmdSQL.ExecuteScalar() Is DBNull.Value, False, cmdSQL.ExecuteScalar())

            '    Catch ex As Exception
            '        MessageBox.Show(ex.Message.ToString)
            '    Finally
            '        If conexion.State = ConnectionState.Open Then
            '            conexion.Close()
            '        End If
            '    End Try

            '    Return codificado


            'End Function





            'Public Shared Function verificarSiActivo(ByVal epi As ClsEpisodio, ByVal strCadenaConexion As String) As Boolean


            '    Dim activo As Boolean = False

            '    Dim strSQL As String
            '    Dim cmdSQL As SqlCommand
            '    Dim conexion As SqlConnection

            '    Dim hosp As String = epi.valorHospital
            '    Dim nunICU As String = epi.valorNumIcu
            '    Dim NHC As String = epi.valorNHC


            '    strSQL = "select activo from datosCodificacion where hospital='" & hosp & "' and  historia='" & NHC & "' and  numICU='" & nunICU & "'"

            '    conexion = New SqlConnection(strCadenaConexion)
            '    cmdSQL = New SqlCommand(strSQL, conexion)


            '    Try
            '        conexion.Open()
            '        activo = IIf(cmdSQL.ExecuteScalar() Is DBNull.Value, False, cmdSQL.ExecuteScalar())

            '    Catch ex As Exception
            '        MessageBox.Show(ex.Message.ToString)
            '    Finally
            '        If conexion.State = ConnectionState.Open Then
            '            conexion.Close()
            '        End If
            '    End Try

            '    Return activo


            'End Function



            Public Shared Function actualizarEpisodio(ByVal epiAtiguo As ClsEpisodio, ByVal epiNuevo As ClsEpisodio, ByVal strCadenaConexion As String)


                Dim numero = Nothing

                Dim strSQL As String
                Dim cmdSQL As SqlCommand
                Dim conexion As SqlConnection



                strSQL = "update CMBDCodificacion set fecing ='" & epiNuevo.valorFechaIng & "',fecalt ='" & epiNuevo.valorFEchaALta & "',fecint ='" & epiNuevo.valorFechaInt & "'  where hospital='" & epiAtiguo.valorHospital & "' and  historia='" & epiAtiguo.valorNHC & "' and  numICU='" & epiAtiguo.valorNumIcu & "'"

                conexion = New SqlConnection(strCadenaConexion)
                cmdSQL = New SqlCommand(strSQL, conexion)


                Try
                    conexion.Open()
                    numero = cmdSQL.ExecuteNonQuery

                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString)
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                End Try


                If numero > 0 Then ' resultado del update
                    Return True
                Else
                    Return False
                End If









            End Function




            Public Shared Function modificarInactivo(ByVal epi As ClsEpisodio, ByVal Inactivo As Integer, ByVal strCadenaConexion As String) As Boolean


                Dim numero = Nothing

                Dim strSQL As String
                Dim cmdSQL As SqlCommand
                Dim conexion As SqlConnection

                Dim hosp As String = epi.valorHospital
                Dim nunICU As String = epi.valorNumIcu
                Dim NHC As String = epi.valorNHC



               
                strSQL = "update datosCodificacion set Inactivo =" & Inactivo & "  where hospital='" & hosp & "' and  historia='" & NHC & "' and  numICU='" & nunICU & "'"



                conexion = New SqlConnection(strCadenaConexion)
                cmdSQL = New SqlCommand(strSQL, conexion)


                Try
                    conexion.Open()
                    numero = cmdSQL.ExecuteNonQuery

                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString)
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                End Try


                If numero > 0 Then ' resultado del update
                    Return True
                Else
                    Return False
                End If


            End Function








        End Class

    End Namespace

End Namespace