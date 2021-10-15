Imports System.Data.SqlClient
Imports libreriacadenaproduccion.Entidades
Imports System.Windows.Forms
'Imports vg = EDC10_NET.VariablesGlobales

Namespace Datos


    Namespace CodificacionSQL


        Public Class AccesoDatosSeleccionEpisodios



            Public Shared Sub asignarEpisodio(ByVal episodio As ClsEpisodio, ByVal usuario As ClsUsuario, ByVal strCadenaConexion As String)

                Dim strSQL As String
                Dim conexion As SqlConnection
                Dim cmdSQL As SqlCommand
                Dim cont As Integer = 0

                strSQL = "UPDATE datosCodificacion SET fechaAsignacion = '" & DateTime.Now.ToShortDateString() & "', asignadoA = '" & usuario._login & "'"
                strSQL = strSQL & " WHERE hospital = '" & episodio.valorHospital & "' AND numicu = '" & episodio.valorNumIcu & "' AND historia = '" & episodio.valorNHC & "'"

                conexion = New SqlConnection(strCadenaConexion)
                cmdSQL = New SqlCommand(strSQL, conexion)

                Try
                    conexion.Open()

                    cmdSQL.ExecuteReader()

                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString)
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                End Try

            End Sub


            Public Shared Function seleccionEpisodios(ByRef lstvdocumentos As ListView, ByVal strCadenaConexion As String, Optional ByVal parametros As Collection = Nothing) As Integer

                Dim epiAux As ClsEpisodio
                Dim dtDocumentos As New DataTable
                Dim strSQL As String
                Dim datos As SqlDataReader
                Dim lstitem As ListViewItem
                Dim contador As Integer = 0
                Dim cont As Integer = 0
                Dim algunaCoincidencia As Integer = 0

                If IsNothing(parametros) = True Then
                    'no hay parametros para la busqueda 

                    strSQL = " SELECT DISTINCT datosCodificacion.historia, datosCodificacion.hospital, CMBDCodificacion.NUMICU AS Episodio, Left(Convert(varchar, CMBDCodificacion.FECING , 103), 10) AS FechaIngreso, CMBDCodificacion.SERVIC AS Servicio, datosCodificacion.asignadoA AS Asignado, NivelesCodificacion.descripcion As NivelCodificacion, datosCodificacion.inactivo, Left(Convert(varchar, CMBDCodificacion.FECALT , 103), 10) AS FechaAlta "
                    strSQL = strSQL & " FROM CMBDCodificacion  INNER JOIN"
                    strSQL = strSQL & " datosCodificacion  ON CMBDCodificacion.HOSPITAL = datosCodificacion.hospital AND CMBDCodificacion.HISTORIA = datosCodificacion.historia AND CMBDCodificacion.NUMICU = datosCodificacion.numICU "
                    strSQL = strSQL & " left JOIN NivelesCodificacion ON datosCodificacion.nivelcodificacion = nivelesCodificacion.idnivelcod "

                Else
                    'hay que tener en cuenta los paramentros para la busqueda 
                    strSQL = " SELECT DISTINCT datosCodificacion.historia, datosCodificacion.hospital, CMBDCodificacion.NUMICU AS Episodio, Left(Convert(varchar, CMBDCodificacion.FECING , 103), 10) AS FechaIngreso, CMBDCodificacion.SERVIC AS Servicio, datosCodificacion.asignadoA AS Asignado, NivelesCodificacion.descripcion As NivelCodificacion , datosCodificacion.inactivo, Left(Convert(varchar, CMBDCodificacion.FECALT , 103), 10) AS FechaAlta "
                    strSQL = strSQL & " FROM CMBDCodificacion  INNER JOIN"
                    strSQL = strSQL & " datosCodificacion  ON CMBDCodificacion.HOSPITAL = datosCodificacion.hospital AND CMBDCodificacion.HISTORIA = datosCodificacion.historia AND CMBDCodificacion.NUMICU = datosCodificacion.numICU"
                    strSQL = strSQL & " left JOIN NivelesCodificacion ON datosCodificacion.nivelcodificacion = nivelesCodificacion.idnivelcod "
                    strSQL = strSQL & " WHERE  "

                    'iniciamos el recorrido del vector para añadir parametros a la busqueda 

                    For Each item As libreriacadenaproduccion.Entidades.clsItem In parametros

                        If cont = 0 Then 'solo hay un parametro para la busqueda y no hay que poner un and 
                            If item.texto = 0 Then 'el parametro que introduciomos es un entero 
                                strSQL = strSQL & item.Nombre & " = " & item.valor
                            Else
                                If item.Fecha = 0 Then 'el parametro que introduciomos es texto 
                                    strSQL = strSQL & item.Nombre & " like '%" & item.valor & "%' "
                                Else 'el parametro que introduciomos es una fecha
                                    If IsNothing(item.RangoFecha) = False Then
                                        Select Case item.RangoFecha
                                            'las instrucciones comentadas son las correctas para un servidor SQL 
                                            Case 0 'igual 
                                                strSQL = strSQL & item.Nombre & " = '" & item.valor & "' "
                                                'strSQL = strSQL & " Left(Convert(varchar, " & item.Nombre & ", 103), 10)  = '" & item.valor & "'"
                                                'strSQL = strSQL & " date( " & item.Nombre & ") = '" & Mid(item.valor, 7, 4) & "-" & Mid(item.valor, 4, 2) & "-" & Mid(item.valor, 1, 2) & "'"
                                            Case 1 'entre
                                                strSQL = strSQL & item.Nombre & " >= '" & item.valor & "' and "
                                                strSQL = strSQL & item.Nombre & " <= '" & item.valor2 & "' "
                                                'strSQL = strSQL & " Left(Convert(varchar, " & item.Nombre & ", 103), 10)  >= '" & item.valor & "' and"
                                                'strSQL = strSQL & " Left(Convert(varchar, " & item.Nombre & ", 103), 10)  <= '" & item.valor2 & "'"
                                                'strSQL = strSQL & " date( " & item.Nombre & ") >= '" & Mid(item.valor, 7, 4) & "-" & Mid(item.valor, 4, 2) & "-" & Mid(item.valor, 1, 2) & "' and "
                                                'strSQL = strSQL & " date( " & item.Nombre & ") <= '" & Mid(item.valor2, 7, 4) & "-" & Mid(item.valor2, 4, 2) & "-" & Mid(item.valor2, 1, 2) & "'"
                                            Case 2 'anterior
                                                strSQL = strSQL & item.Nombre & " <= '" & item.valor & "' "
                                                'strSQL = strSQL & " Left(Convert(varchar, " & item.Nombre & ", 103), 10) <= '" & item.valor & "'"
                                                'strSQL = strSQL & " date( " & item.Nombre & ") <= '" & Mid(item.valor, 7, 4) & "-" & Mid(item.valor, 4, 2) & "-" & Mid(item.valor, 1, 2) & " '"
                                            Case 3 'posterior
                                                strSQL = strSQL & item.Nombre & " >= '" & item.valor & "' "
                                                'strSQL = strSQL & " Left(Convert(varchar, " & item.Nombre & ", 103), 10) >= '" & item.valor & "'"
                                                'strSQL = strSQL & " date( " & item.Nombre & ") >= '" & Mid(item.valor, 7, 4) & "-" & Mid(item.valor, 4, 2) & "-" & Mid(item.valor, 1, 2) & " '"
                                        End Select
                                        'Else
                                        '  strSQL = strSQL & " LEFT(CONVERT(varchar," & item.Nombre & ",103),10) = '" & item.valor & "'"
                                    End If


                                End If
                            End If
                            cont += 1 'incrementamos el contador para indicar que hay más de un parámetro 
                        Else 'hay mas de un parametro para la busqueda
                            If item.texto = 0 Then
                                strSQL = strSQL & " and " & item.Nombre & " = " & item.valor
                            Else
                                If item.Fecha = 0 Then
                                    strSQL = strSQL & " and " & item.Nombre & " like '%" & item.valor & "%'"
                                Else
                                    If IsNothing(item.RangoFecha) = False Then
                                        Select Case item.RangoFecha
                                            'las instrucciones comentadas son las correctas para un servidor SQL 
                                            Case 0 'igual 
                                                strSQL = strSQL & " and " & item.Nombre & " = '" & item.valor & "'"
                                                'strSQL = strSQL & " Left(Convert(varchar, " & item.Nombre & ", 103), 10)  = '" & item.valor & "'"
                                                'strSQL = strSQL & " and date( " & item.Nombre & ") = '" & Mid(item.valor, 7, 4) & "-" & Mid(item.valor, 4, 2) & "-" & Mid(item.valor, 1, 2) & "'"
                                            Case 1 'entre
                                                strSQL = strSQL & " and " & item.Nombre & " >= '" & item.valor & "' and "
                                                strSQL = strSQL & item.Nombre & " <= '" & item.valor2 & "' "
                                                'strSQL = strSQL & " Left(Convert(varchar, " & item.Nombre & ", 103), 10)  >= '" & item.valor & "' and"
                                                'strSQL = strSQL & " Left(Convert(varchar, " & item.Nombre & ", 103), 10)  <= '" & item.valor2 & "'"
                                                'strSQL = strSQL & " and date( " & item.Nombre & ") >= '" & Mid(item.valor, 7, 4) & "-" & Mid(item.valor, 4, 2) & "-" & Mid(item.valor, 1, 2) & "' and "
                                                'strSQL = strSQL & " date( " & item.Nombre & ") <= '" & Mid(item.valor2, 7, 4) & "-" & Mid(item.valor2, 4, 2) & "-" & Mid(item.valor2, 1, 2) & "'"
                                            Case 2 'anterior
                                                strSQL = strSQL & item.Nombre & " <= '" & item.valor & "' "
                                                'strSQL = strSQL & " Left(Convert(varchar, " & item.Nombre & ", 103), 10) <= '" & item.valor & "'"
                                                'strSQL = strSQL & " and date( " & item.Nombre & ") <= '" & Mid(item.valor, 7, 4) & "-" & Mid(item.valor, 4, 2) & "-" & Mid(item.valor, 1, 2) & " '"
                                            Case 3 'posterior
                                                strSQL = strSQL & " and " & item.Nombre & " >= '" & item.valor & "' "
                                                'strSQL = strSQL & " Left(Convert(varchar, " & item.Nombre & ", 103), 10) >= '" & item.valor & "'"
                                                'strSQL = strSQL & " and date( " & item.Nombre & ") >= '" & Mid(item.valor, 7, 4) & "-" & Mid(item.valor, 4, 2) & "-" & Mid(item.valor, 1, 2) & " '"
                                        End Select
                                    End If
                                End If
                            End If
                        End If


                    Next

                End If

                strSQL = strSQL & " order by datosCodificacion.historia"


                Dim conexion As New SqlConnection(strCadenaConexion)
                Dim cmdSQL As New SqlCommand(strSQL, conexion)


                Try
                    conexion.Open()

                    lstvdocumentos.Items.Clear()

                    datos = cmdSQL.ExecuteReader

                    While datos.Read
                        'rellenamos los valores del listview


                        lstitem = New ListViewItem

                        lstitem.Name = "historia"
                        lstitem.Text = libreriacadenaproduccion.Datos.GeneralSQL.clsAccesoDatosSQL.ponerCaracterEnBlanco(datos.Item("historia").ToString, "")
                        lstitem.SubItems.Add(libreriacadenaproduccion.Datos.GeneralSQL.clsAccesoDatosSQL.ponerCaracterEnBlanco(datos.Item("episodio").ToString, "")).Name = "episodio"
                        lstitem.SubItems.Add(libreriacadenaproduccion.Datos.GeneralSQL.clsAccesoDatosSQL.ponerCaracterEnBlanco(datos.Item("FechaIngreso").ToString, "")).Name = "FechaIngreso"
                        lstitem.SubItems.Add(libreriacadenaproduccion.Datos.GeneralSQL.clsAccesoDatosSQL.ponerCaracterEnBlanco(datos.Item("FechaAlta").ToString, "")).Name = "FechaAlta"
                        lstitem.SubItems.Add(libreriacadenaproduccion.Datos.GeneralSQL.clsAccesoDatosSQL.ponerCaracterEnBlanco(datos.Item("servicio").ToString, "")).Name = "servicio"
                        lstitem.SubItems.Add(libreriacadenaproduccion.Datos.GeneralSQL.clsAccesoDatosSQL.ponerCaracterEnBlanco(datos.Item("asignado").ToString, "")).Name = "asignado"
                        lstitem.SubItems.Add(libreriacadenaproduccion.Datos.GeneralSQL.clsAccesoDatosSQL.ponerCaracterEnBlanco(datos.Item("NivelCodificacion").ToString, "")).Name = "NivelCodificacion"
                        lstitem.SubItems.Add(libreriacadenaproduccion.Datos.GeneralSQL.clsAccesoDatosSQL.ponerCaracterEnBlanco(datos.Item("inActivo").ToString, "")).Name = "inActivo"

                        epiAux = New ClsEpisodio(datos.Item("historia").ToString(), datos.Item("episodio").ToString(), datos.Item("Hospital").ToString())

                        If lstitem.SubItems("inActivo").Text = "True" Then
                            lstitem.BackColor = Color.Red
                            epiAux.valorInactivo = True
                        End If

                        lstitem.Tag = epiAux

                        lstvdocumentos.Items.Add(lstitem)

                        contador += 1

                    End While

                Catch excp As SqlException
                    MessageBox.Show(excp.Message.ToString & excp.Number)
                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString)
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                End Try

                Return contador

            End Function




            Public Shared Function episodiosAExportar(ByVal hospital As String, ByVal fechaini As Date, ByVal fechafin As Date, ByVal strCadenaConexion As String) As DataTable

                Dim listado As New DataTable()
                Dim strSQL As String
                Dim cmdSQL As SqlCommand
                Dim conexion As SqlConnection
                Dim daDatos As SqlDataAdapter


                strSQL = "Select * from CMBDCodificacion where  FECING > '" & fechaini.ToShortDateString & "' AND FECING < '" & fechafin.ToShortDateString & "' And Hospital ='" & hospital & "'"


                conexion = New SqlConnection(strCadenaConexion)
                cmdSQL = New SqlCommand(strSQL, conexion)
                daDatos = New SqlDataAdapter(cmdSQL)

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



        End Class
    End Namespace

End Namespace
