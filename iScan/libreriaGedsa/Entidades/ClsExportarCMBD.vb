Imports ADOX
Imports System
Imports System.Windows.Forms

Namespace Entidades

    Public Class ClsExportarCMBD


        Public Shared Sub exportarCMBDAccess(ByVal hospital As String, ByVal fechaIni As Date, ByVal fechaFin As Date, ByVal ruta As String, ByVal CadenaConexion As String, Optional ByVal numeroDeCodificacionesAExportar As Integer = -1, Optional ByRef barraDeProgreso As ProgressBar = Nothing)



            Dim numeroDeCodificaciones = numeroDeCodificacionesAExportar
            Dim numeroActual As Integer = 0
            Dim numeroRegistros As Integer
            Dim numeroActualDeRegistros = 0



            'creacion de la bd en blanco, y posterior creacion de tablas y columnas-------------------------



            Dim bd As New Catalog()

            bd.Create("Provider=" & "Microsoft.Jet.OLEDB.4.0" & ";" & _
           "Data Source=" & ruta & "\" & Date.Now.ToShortDateString().Replace("/", "") & ".mdb" & ";")



            'Tabla CMBDCodificacion. Tabla:
            Dim tablaCMBDCodificacion As New ADOX.Table()
            tablaCMBDCodificacion.Name = "CMBDCodificacion"

            'Columnas
            tablaCMBDCodificacion.Columns.Append("HOSPITAL", ADOX.DataTypeEnum.adWChar, 10)
            tablaCMBDCodificacion.Columns.Append("HISTORIA", ADOX.DataTypeEnum.adWChar, 10)
            tablaCMBDCodificacion.Columns.Append("NUMICU", ADOX.DataTypeEnum.adWChar, 10)
            tablaCMBDCodificacion.Columns.Append("TipoEpisodio", ADOX.DataTypeEnum.adWChar, 8)
            tablaCMBDCodificacion.Columns.Append("CIP", ADOX.DataTypeEnum.adWChar, 16)
            tablaCMBDCodificacion.Columns.Append("RESIDE", ADOX.DataTypeEnum.adWChar, 10)
            tablaCMBDCodificacion.Columns.Append("REGFIN", ADOX.DataTypeEnum.adWChar, 10)
            tablaCMBDCodificacion.Columns.Append("FECING", ADOX.DataTypeEnum.adDate, 8)
            tablaCMBDCodificacion.Columns.Append("TIPING", ADOX.DataTypeEnum.adWChar, 10)
            tablaCMBDCodificacion.Columns.Append("SERVIC", ADOX.DataTypeEnum.adWChar, 10)
            tablaCMBDCodificacion.Columns.Append("SECCION", ADOX.DataTypeEnum.adWChar, 10)
            tablaCMBDCodificacion.Columns.Append("FECALT", ADOX.DataTypeEnum.adDate, 8)
            tablaCMBDCodificacion.Columns.Append("MEDICO", ADOX.DataTypeEnum.adWChar, 10)
            tablaCMBDCodificacion.Columns.Append("TIPALT", ADOX.DataTypeEnum.adWChar, 10)
            tablaCMBDCodificacion.Columns.Append("FECINT", ADOX.DataTypeEnum.adDate, 8)
            tablaCMBDCodificacion.Columns.Append("CIAS_PRO", ADOX.DataTypeEnum.adWChar, 50)
            tablaCMBDCodificacion.Columns.Append("AreaCLN", ADOX.DataTypeEnum.adWChar, 10)
            tablaCMBDCodificacion.Columns.Append("ActoMedico", ADOX.DataTypeEnum.adWChar, 250)
            tablaCMBDCodificacion.Columns.Append("Enviado", ADOX.DataTypeEnum.adInteger, 10)
            tablaCMBDCodificacion.Columns.Append("Estado", ADOX.DataTypeEnum.adInteger, 10)
            tablaCMBDCodificacion.Columns.Append("TieneError", ADOX.DataTypeEnum.adInteger, 10)
            tablaCMBDCodificacion.Columns.Append("Observaciones", ADOX.DataTypeEnum.adWChar, 250)





            'Tabla EpisodiosDiagnosticos. Tabla:
            Dim tablaEpisodiosDiagnosticos As New ADOX.Table()
            tablaEpisodiosDiagnosticos.Name = "EpisodiosDiagnosticos"

            'Columnas
            tablaEpisodiosDiagnosticos.Columns.Append("HOSPITAL", ADOX.DataTypeEnum.adWChar, 6)
            tablaEpisodiosDiagnosticos.Columns.Append("HISTORIA", ADOX.DataTypeEnum.adWChar, 8)
            tablaEpisodiosDiagnosticos.Columns.Append("NUMICU", ADOX.DataTypeEnum.adWChar, 12)
            tablaEpisodiosDiagnosticos.Columns.Append("C", ADOX.DataTypeEnum.adWChar, 7)
            tablaEpisodiosDiagnosticos.Columns.Append("REPLICAR", DataTypeEnum.adBinary)
            tablaEpisodiosDiagnosticos.Columns.Append("Orden", DataTypeEnum.adInteger, 4)





            'Tabla EpisodiosMorfologias. Tabla:
            Dim tablaEpisodiosMorfologias As New ADOX.Table()
            tablaEpisodiosMorfologias.Name = "EpisodiosMorfologias"

            'Columnas
            tablaEpisodiosMorfologias.Columns.Append("HOSPITAL", ADOX.DataTypeEnum.adWChar, 6)
            tablaEpisodiosMorfologias.Columns.Append("HISTORIA", ADOX.DataTypeEnum.adWChar, 8)
            tablaEpisodiosMorfologias.Columns.Append("NUMICU", ADOX.DataTypeEnum.adWChar, 12)
            tablaEpisodiosMorfologias.Columns.Append("M", ADOX.DataTypeEnum.adWChar, 7)
            tablaEpisodiosMorfologias.Columns.Append("REPLICAR", DataTypeEnum.adBinary)
            tablaEpisodiosMorfologias.Columns.Append("Orden", DataTypeEnum.adInteger, 4)



            'Tabla EpisodiosProcedimientos. Tabla:
            Dim tablaEpisodiosProcedimientos As New ADOX.Table()
            tablaEpisodiosProcedimientos.Name = "EpisodiosProcedimientos"

            'Columnas
            tablaEpisodiosProcedimientos.Columns.Append("HOSPITAL", ADOX.DataTypeEnum.adWChar, 6)
            tablaEpisodiosProcedimientos.Columns.Append("HISTORIA", ADOX.DataTypeEnum.adWChar, 8)
            tablaEpisodiosProcedimientos.Columns.Append("NUMICU", ADOX.DataTypeEnum.adWChar, 12)
            tablaEpisodiosProcedimientos.Columns.Append("P", ADOX.DataTypeEnum.adWChar, 7)
            tablaEpisodiosProcedimientos.Columns.Append("REPLICAR", DataTypeEnum.adBinary)
            tablaEpisodiosProcedimientos.Columns.Append("Orden", DataTypeEnum.adInteger, 4)



            'Tabla EpisodiosTratamientos. Tabla:
            Dim tablaEpisodiosTratamientos As New ADOX.Table()
            tablaEpisodiosTratamientos.Name = "EpisodiosTratamientos"

            'Columnas
            tablaEpisodiosTratamientos.Columns.Append("HOSPITAL", ADOX.DataTypeEnum.adWChar, 6)
            tablaEpisodiosTratamientos.Columns.Append("HISTORIA", ADOX.DataTypeEnum.adWChar, 8)
            tablaEpisodiosTratamientos.Columns.Append("NUMICU", ADOX.DataTypeEnum.adWChar, 12)
            tablaEpisodiosTratamientos.Columns.Append("T", ADOX.DataTypeEnum.adWChar, 7)
            tablaEpisodiosTratamientos.Columns.Append("REPLICAR", DataTypeEnum.adBinary)
            tablaEpisodiosTratamientos.Columns.Append("Orden", DataTypeEnum.adInteger, 4)



            'se añaden las tablas a la BD
            bd.Tables.Append(tablaCMBDCodificacion)
            bd.Tables.Append(tablaEpisodiosDiagnosticos)
            bd.Tables.Append(tablaEpisodiosMorfologias)
            bd.Tables.Append(tablaEpisodiosProcedimientos)
            bd.Tables.Append(tablaEpisodiosTratamientos)



            '-------------------------------------------------------------------------------------
            '------------------------------------------------ Fin de creacion de la nueva BD Acces



            '-------------------------------------------------------------Inicio de la exportacion
            '-------------------------------------------------------------------------------------

            Dim cn = bd.ActiveConnection



            Dim parametros As New SortedList

            parametros.Add("Hospital", hospital)
            parametros.Add("fechaInicioCodificacion", fechaIni.ToShortDateString())
            parametros.Add("fechaFinCodificacion", fechaFin.ToShortDateString())


            If Not IsNothing(barraDeProgreso) Then

                numeroRegistros = totalRegistrosAExportar(hospital, fechaIni, fechaFin, CadenaConexion)


            End If




            For Each registroCodificado As DataRow In Datos.CodificacionSQL.AccesoDatosSeleccionEpisodios.episodiosAExportar(hospital, fechaIni, fechaFin, CadenaConexion).Rows

                ' Para cada registro entre esas dos fechas en, exportamos todos sus Datos de CMBDCodificacion,
                'diagnosticos, morfologias, tratamientos y procedimientos


                Dim parametrosDeCodificacion As New SortedList 'El hospital, historia y numicu de esta codificacion
                parametrosDeCodificacion.Add("Hospital", hospital)
                parametrosDeCodificacion.Add("Historia", registroCodificado.Item("Historia"))
                parametrosDeCodificacion.Add("NumIcu", registroCodificado.Item("NumIcu"))



                '################################################################################################

                'los de cmbdCodificacion  AKIIIIIIIIII
                For Each registro As DataRow In Datos.GeneralSQL.clsAccesoDatosSQL.ObtenerListadoParaListaValoresParametros("CMBDCodificacion", "*", parametrosDeCodificacion, CadenaConexion).Rows 'hacer la consulta
                    Dim auxEnviado As Integer = 0 'para el tryparse de los enteros
                    Dim auxTieneError As Integer = 0 'para el tryparse de los enteros
                    Dim auxEstado As Integer = 0 'para el tryparse de los enteros

                    Dim auxFechaAlta As New Date(1900, 1, 1)
                    Dim auxFechaIntervencion As New Date(1900, 1, 1)
                    Dim auxFechaIngreso As New Date(1900, 1, 1)






                    Try
                        Integer.TryParse((registro.Item("Enviado")), auxEnviado)

                    Catch ex As Exception

                    End Try

                    Try
                        Integer.TryParse(registro.Item("Estado"), auxEstado)
                    Catch ex As Exception

                    End Try

                    Try
                        Integer.TryParse(registro.Item("TieneError"), auxTieneError)
                    Catch ex As Exception

                    End Try

                    '------------------------------------------FECHAS

                    Try
                        auxFechaIngreso = Date.Parse(registro.Item("FECING"))
                    Catch ex As Exception

                    End Try



                    Try
                        auxFechaIntervencion = Date.Parse(registro.Item("FECINT"))
                    Catch ex As Exception

                    End Try



                    Try
                        auxFechaAlta = Date.Parse(registro.Item("FECALT"))
                    Catch ex As Exception

                    End Try









                    'Solo esto de aki
                    '################################################################################################
                    Dim sqlInsert = "INSERT INTO CMBDCodificacion ( HOSPITAL,HISTORIA ,NUMICU,TipoEpisodio ,CIP ," & _
                    "RESIDE ,REGFIN , FECING," & _
                     "TIPING, SERVIC,SECCION ,FECALT, MEDICO,TIPALT , FECINT,CIAS_PRO ,AreaCLN ," & _
                     "actomedico , Enviado , estado, TieneError, observaciones  )VALUES ('" & _
                     IIf(Not TypeOf registro.Item("HOSPITAL") Is System.DBNull, registro.Item("HOSPITAL").ToString(), "") & "', '" & _
                    IIf(Not TypeOf registro.Item("HISTORIA") Is System.DBNull, registro.Item("HISTORIA").ToString(), "") & "', '" & _
                    IIf(Not TypeOf registro.Item("NUMICU") Is System.DBNull, registro.Item("NUMICU").ToString(), "") & "', '" & _
                     IIf(Not TypeOf registro.Item("TipoEpisodio") Is System.DBNull, registro.Item("TipoEpisodio").ToString(), "") & "', '" & _
                    IIf(Not TypeOf registro.Item("CIP") Is System.DBNull, registro.Item("CIP").ToString(), "") & "', '" & _
                     IIf(Not TypeOf registro.Item("RESIDE") Is System.DBNull, registro.Item("RESIDE").ToString(), "") & "', '" & _
                     IIf(Not TypeOf registro.Item("REGFIN") Is System.DBNull, registro.Item("REGFIN").ToString(), "") & "', '" & _
                     auxFechaIngreso.ToShortDateString() & "', '" & _
                    IIf(Not TypeOf registro.Item("TIPING") Is System.DBNull, registro.Item("TIPING").ToString(), "") & "', '" & _
                    IIf(Not TypeOf registro.Item("SERVIC") Is System.DBNull, registro.Item("SERVIC").ToString(), "") & "', '" & _
                     IIf(Not TypeOf registro.Item("SECCION") Is System.DBNull, registro.Item("SECCION").ToString(), "") & "', '" & _
                     auxFechaAlta.ToShortDateString() & "', '" & _
                     IIf(Not TypeOf registro.Item("MEDICO") Is System.DBNull, registro.Item("MEDICO").ToString(), "") & "', '" & _
                     IIf(Not TypeOf registro.Item("TIPALT") Is System.DBNull, registro.Item("TIPALT").ToString(), "") & "', '" & _
                     auxFechaIntervencion.ToShortDateString & "', '" & _
                     IIf(Not TypeOf registro.Item("CIAS_PRO") Is System.DBNull, registro.Item("CIAS_PRO").ToString(), "") & "', '" & _
                     IIf(Not TypeOf registro.Item("AreaCLN") Is System.DBNull, registro.Item("AreaCLN").ToString(), "") & "', '" & _
                     IIf((Not TypeOf registro.Item("ActoMedico") Is System.DBNull), registro.Item("ActoMedico").ToString(), "") & "', " & _
                     auxEnviado.ToString() & ", " & _
                     auxEstado.ToString() & ", " & _
                     auxTieneError.ToString() & ", '" & _
                      IIf(Not TypeOf registro.Item("Observaciones") Is System.DBNull, registro.Item("Observaciones").ToString(), "") & "')"
                    Try

                        cn.execute(sqlInsert)
                        numeroActualDeRegistros += 1

                    Catch ex As Exception

                    End Try



                    If Not IsNothing(barraDeProgreso) Then
                        barraDeProgreso.Value = ((numeroActualDeRegistros * 100) \ numeroRegistros)
                        barraDeProgreso.Refresh()
                        Application.DoEvents()
                    End If

                    '################################################################################################



                Next



                'los de diagnosticos

                numeroActual = 0
                For Each diagnostico As DataRow In Datos.GeneralSQL.clsAccesoDatosSQL.ObtenerListadoParaListaValoresParametros("EpisodiosDiagnosticos", "*", parametrosDeCodificacion, CadenaConexion).Rows 'hacer la consulta
                    Dim sqlInsert = "INSERT INTO " & Trim$("EpisodiosDiagnosticos") & " (HOSPITAL,HISTORIA,NUMICU,C,REPLICAR,Orden) VALUES ('" & _
                 IIf(Not TypeOf diagnostico.Item("HOSPITAL") Is System.DBNull, diagnostico.Item("HOSPITAL"), "") & "', '" & _
                 IIf(Not TypeOf diagnostico.Item("HISTORIA") Is System.DBNull, diagnostico.Item("HISTORIA"), "") & "', '" & _
                 IIf(Not TypeOf diagnostico.Item("NUMICU") Is System.DBNull, diagnostico.Item("NUMICU"), "") & "', '" & _
                 IIf(Not TypeOf diagnostico.Item("C") Is System.DBNull, diagnostico.Item("C"), "") & "', '" & _
                 IIf(Not TypeOf diagnostico.Item("REPLICAR") Is System.DBNull, diagnostico.Item("REPLICAR"), "") & "', '" & _
                 IIf(Not TypeOf diagnostico.Item("Orden") Is System.DBNull, diagnostico.Item("Orden"), "") & "')"


                    Try

                        cn.execute(sqlInsert)
                        numeroActual += 1
                    Catch ex As Exception

                    End Try



                    If numeroDeCodificaciones <> -1 Then 'Hay limitaciones del numero de diagnosticos a exportar

                        If numeroActual = numeroDeCodificaciones Then 'Ha alcanzado ya el numero maximo de diagnostico a exportar
                            Exit For 'sale del for each
                        End If

                    End If


                Next






                'los de morfologias
                numeroActual = 0
                For Each morfo As DataRow In Datos.GeneralSQL.clsAccesoDatosSQL.ObtenerListadoParaListaValoresParametros("EpisodiosMorfologias", "*", parametrosDeCodificacion, CadenaConexion).Rows 'hacer la consulta
                    Dim sqlInsert = "INSERT INTO " & Trim$("EpisodiosMorfologias") & " (HOSPITAL,HISTORIA,NUMICU,M,REPLICAR,Orden) VALUES ('" & _
                              IIf(Not TypeOf morfo.Item("HOSPITAL") Is System.DBNull, morfo.Item("HOSPITAL"), "") & "', '" & _
                              IIf(Not TypeOf morfo.Item("HISTORIA") Is System.DBNull, morfo.Item("HISTORIA"), "") & "', '" & _
                              IIf(Not TypeOf morfo.Item("NUMICU") Is System.DBNull, morfo.Item("NUMICU"), "") & "', '" & _
                              IIf(Not TypeOf morfo.Item("M") Is System.DBNull, morfo.Item("M"), "") & "', '" & _
                              IIf(Not TypeOf morfo.Item("REPLICAR") Is System.DBNull, morfo.Item("REPLICAR"), "") & "', '" & _
                              IIf(Not TypeOf morfo.Item("Orden") Is System.DBNull, morfo.Item("Orden"), "") & "')"


                    Try
                        cn.execute(sqlInsert)
                        numeroActual += 1
                    Catch ex As Exception

                    End Try



                    If numeroDeCodificaciones <> -1 Then 'Hay limitaciones del numero de morfologias a exportar

                        If numeroActual = numeroDeCodificaciones Then 'Ha alcanzado ya el numero maximo de morfologias a exportar
                            Exit For 'sale del for each
                        End If

                    End If



                Next









                'los de tratamientos
                numeroActual = 0
                For Each tratamiento As DataRow In Datos.GeneralSQL.clsAccesoDatosSQL.ObtenerListadoParaListaValoresParametros("EpisodiosTratamientos", "*", parametrosDeCodificacion, CadenaConexion).Rows 'hacer la consulta
                    Dim sqlInsert = "INSERT INTO " & Trim$("EpisodiosTratamientos") & "(HOSPITAL,HISTORIA,NUMICU,T,REPLICAR,Orden) VALUES ('" & _
                                             IIf(Not TypeOf tratamiento.Item("HOSPITAL") Is System.DBNull, tratamiento.Item("HOSPITAL"), "") & "', '" & _
                                             IIf(Not TypeOf tratamiento.Item("HISTORIA") Is System.DBNull, tratamiento.Item("HISTORIA"), "") & "', '" & _
                                             IIf(Not TypeOf tratamiento.Item("NUMICU") Is System.DBNull, tratamiento.Item("NUMICU"), "") & "', '" & _
                                             IIf(Not TypeOf tratamiento.Item("T") Is System.DBNull, tratamiento.Item("T"), "") & "', '" & _
                                             IIf(Not TypeOf tratamiento.Item("REPLICAR") Is System.DBNull, tratamiento.Item("REPLICAR"), "") & "', '" & _
                                             IIf(Not TypeOf tratamiento.Item("Orden") Is System.DBNull, tratamiento.Item("Orden"), "") & "')"




                    Try
                        cn.execute(sqlInsert)
                        numeroActual += 1
                    Catch ex As Exception

                    End Try



                    If numeroDeCodificaciones <> -1 Then 'Hay limitaciones del numero de tratamientos a exportar

                        If numeroActual = numeroDeCodificaciones Then 'Ha alcanzado ya el numero maximo de tratamientos a exportar
                            Exit For 'sale del for each
                        End If

                    End If





                Next








                'los de procedimientos
                numeroActual = 0
                For Each procedimiento As DataRow In Datos.GeneralSQL.clsAccesoDatosSQL.ObtenerListadoParaListaValoresParametros("EpisodiosProcedimientos", "*", parametrosDeCodificacion, CadenaConexion).Rows 'hacer la consulta
                    Dim sqlInsert = "INSERT INTO " & Trim$("EpisodiosProcedimientos") & " (HOSPITAL,HISTORIA,NUMICU,P,REPLICAR,Orden) VALUES ('" & _
                                                             IIf(Not TypeOf procedimiento.Item("HOSPITAL") Is System.DBNull, procedimiento.Item("HOSPITAL"), "") & "', '" & _
                                                             IIf(Not TypeOf procedimiento.Item("HISTORIA") Is System.DBNull, procedimiento.Item("HISTORIA"), "") & "', '" & _
                                                             IIf(Not TypeOf procedimiento.Item("NUMICU") Is System.DBNull, procedimiento.Item("NUMICU"), "") & "', '" & _
                                                             IIf(Not TypeOf procedimiento.Item("P") Is System.DBNull, procedimiento.Item("P"), "") & "', '" & _
                                                             IIf(Not TypeOf procedimiento.Item("REPLICAR") Is System.DBNull, procedimiento.Item("REPLICAR"), "") & "', '" & _
                                                             IIf(Not TypeOf procedimiento.Item("Orden") Is System.DBNull, procedimiento.Item("Orden"), "") & "')"




                    Try
                        cn.execute(sqlInsert)
                        numeroActual += 1
                    Catch ex As Exception

                    End Try



                    If numeroDeCodificaciones <> -1 Then 'Hay limitaciones del numero de procedimientos a exportar

                        If numeroActual = numeroDeCodificaciones Then 'Ha alcanzado ya el numero maximo de procedimientos a exportar
                            Exit For 'sale del for each
                        End If

                    End If




                Next








            Next




            cn.Close()

            cn = Nothing

            tablaEpisodiosProcedimientos = Nothing
            tablaEpisodiosTratamientos = Nothing
            tablaEpisodiosMorfologias = Nothing
            tablaEpisodiosDiagnosticos = Nothing
            tablaCMBDCodificacion = Nothing

            bd = Nothing
            '-------------------------------------------------------------------------------------
            '------------------------------------------ Fin de creacion de la exportacion a Access


        End Sub

        Public Shared Sub exportarCMBD_VDepur(ByVal hospital As String, ByVal fechaIni As Date, ByVal fechaFin As Date, ByVal ruta As String, ByVal CadenaConexion As String)

        End Sub



        Public Shared Function totalRegistrosAExportar(ByVal hospital As String, ByVal fechaini As Date, ByVal fechafin As Date, ByVal CadenaConexion As String) As Integer


            Return Datos.CodificacionSQL.AccesoDatosSeleccionEpisodios.episodiosAExportar(hospital, fechaini, fechafin, CadenaConexion).Rows.Count



        End Function


    End Class

End Namespace
