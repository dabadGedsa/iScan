Imports LibreriaCadenaProduccion.Entidades
Imports System.Data.SqlClient
Imports System.IO
Imports JRO
Imports System.Windows.Forms
Imports datosSql = LibreriaCadenaProduccion.Datos.GeneralSQL.clsAccesoDatosSQL
Imports datosMdb = LibreriaCadenaProduccion.Datos.GeneralAccess.ClsAccesoDatosAccess
Imports datosLote = LibreriaCadenaProduccion.Datos.Produccion.cadenaproduccion.clsAccesoDatosLote
Imports editor = LibreriaCadenaProduccion.TXT.clsFormato
Imports LibreriaCadenaProduccion.Module1


Namespace Entidades

    Namespace Operaciones


        Public Class clsOperacionesLoteExportacionPorDocumentos

            Public Shared Function exportarDatosLote(ByVal idlote As String, ByVal idproyecto As String, ByVal cadenaconexionAdministrativos As String, ByVal cadenaconexionProyecto As String, ByRef pizarra As RichTextBox, ByRef pgbDocumentos As ProgressBar, ByRef visor As AxImgeditLibCtl.AxImgEdit) As Integer

                Dim codigoServicotxt As String = ""
                Dim rutaPlantillaMdb As String          'ruta de la mdb donde vamos a copiar los datos 
                Dim rutaDestinoMdb As String            'ruta donde vamos a copiar la mdb (incluido nombre que tiene que tener el ficheor )
                Dim carpetaDestinoLote As String        'carpeta donde esta el lote (DAT + mdb), las imagenes estan en otro sitio 
                Dim clave As String                     'clave de la base de datos acces a la que accedemos 
                Dim rutaLotes As String                 'ruta de todos los lotes del proyecto 
                Dim abreviatura As String               'abrebviatura del proyecto 

                Dim dtConfiguracion As DataTable        'datos de configuracion del proyecto 
                Dim je As New JetEngine()               'llibreria paara poner clave a la base de datos acces 
                Dim cadConexionMdbDestino As String
                Dim traza As String
                Dim rutaimagenes As String
                Dim rutatraspasolote As String = ""
                Dim rutaPlantillaExportacion As String = ""
                Dim nomBaseDatosMDB As String = ""
                Dim metadatos As FileInfo
                Dim numerocoindidenciasiddonante As Integer
                Dim numeroImagenesImportadasSistema As Integer
                Dim blocdenotas As New RichTextBox
                Dim historiasLote As DataTable
                Dim datosAgrupacionDocumento As DataTable
                Dim paginasdocumentos As DataTable
                Dim carpetahistoria As String = ""
                Dim strSQLpaginasdocumentos As String = ""
                Dim contadorDocumentos As Integer = 1 'empezamos en el 1 para crear el listado de los docuemntos 
                Dim directoriodocumento As String = ""
                Dim contadorpagina As Integer = 1
                Dim nombredelarchivo As String
                Dim nombre, apellido1, apellido2, sip As String
                Dim strsqlDatosAdjuntosHistoria As String
                Dim datosadjuntosHsitoria As DataTable
                Dim linea As String
                Dim posbarra As Integer
                Dim directoriodocumentolinea As String
                Dim area As String = ""
                Dim tipodocumento As String = ""
                Dim episodio As String = ""
                Dim fechaepisodio As String = ""
                Dim fechadocumento As String = ""
                Dim nombrefichero As String = ""
                Dim numeroPaginas As Integer = 0
                Dim rutaguradarFichero As String
                Dim consultaCamposBlanco As String
                Dim consultaDiario As String
                Dim datosEnBlanco As DataTable
                Dim datosDiario As DataTable
                Dim numerohistoriasconsulta As Integer = 0
                Dim numerodocumentosconsulta As Integer = 0
                Dim numeropaginasconsulta As Integer = 0
                Dim totales As Integer = 0

                'Dim RegistroErrores As String = ""


                Try



                    editor.centrado(pizarra, "Inicio del proceso de exportación del lote" & idlote)


                    ' Obtenemos los campos que necesitamos de la tabla de configuración
                    dtConfiguracion = datosSql.ObtenerListadoParaValorParametro("CONFIGURACIONPROYECTO", "RutaPlantillaExportacion, rutalotes", "idproyecto", idproyecto, cadenaconexionAdministrativos)
                    'obtenemos el resto de campos necesarios 
                    'OBTENER LOS DATOS DE CONFIGURACION para la copia de las imagenes modificado el 8 de julio de 2009 

                    If Not obtenerDatosConfiguracionTraspaso(rutatraspasolote, rutaimagenes, nomBaseDatosMDB, clave, rutaPlantillaExportacion, idlote,
                                                             idproyecto, cadenaconexionAdministrativos, pizarra) Then
                        Exit Function
                    End If


                    ' Obtenemos la ruta de la plantilla mdb y la ruta destino del lote
                    rutaPlantillaMdb = dtConfiguracion.Rows(0)("RutaPlantillaExportacion").ToString()
                    rutaLotes = dtConfiguracion.Rows(0)("rutalotes").ToString()
                    carpetaDestinoLote = rutaLotes & Path.DirectorySeparatorChar & "lotes" & Path.DirectorySeparatorChar & "Lote" & idlote & Path.DirectorySeparatorChar


                    '#################### jgarijo 23/10/2019 ###############################
                    EscribirLog(rutaLotes, Now() & " -> " & "========== INICIO DE LOTE ==========")
                    EscribirLog(rutaLotes, Now() & " -> " & "Inicio del proceso de exportación del lote " & idlote)
                    '#######################################################################


                    'obtenemos la ruta de las imagenes a insertar en el dat


                    ' Copiamos la plantilla en la ruta del lote con el nombre y la clave correctas
                    abreviatura = datosSql.ObtenerListadoParaValorParametro("proyectos", "abreviatura", "idproyecto", idproyecto, cadenaconexionAdministrativos).Rows(0)(0).ToString()
                    ' clave = datosSql.ObtenerListadoParaValorParametro("configuracionproyecto", "contraseña", "idproyecto", idproyecto, cadenaconexionAdministrativos).Rows(0)(0)
                    'rutaDestinoMdb = carpetaDestinoLote & abreviatura & idlote.PadLeft(6, "0") & ".mdb"

                    'cadConexionMdbDestino = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & rutaDestinoMdb & ";Jet OLEDB:Database Password=" & clave & ";"

                    editor.escribir(pizarra, "Creando el fichero de texto correspondiente ." & vbCrLf & rutaDestinoMdb)


                    '################### JGARIJO 23/10/2019 ######################################
                    'NO UTIL. EL CODIGO FUENTE ESTA COMENTADO
                    'EscribirLog(rutaLotes, Now() & " -> " & "Creando el fichero de texto correspondiente ." & vbCrLf & rutaDestinoMdb)
                    '#############################################################################




                    ' Si el archivo mdb ya existiera, lo eliminamos
                    'File.Delete(rutaDestinoMdb)

                    ' Copiamos el nuevo archivo mdb y le asignamos un nombre y contraseña
                    'je.CompactDatabase("Data Source=" & rutaPlantillaMdb & "PlantillaExportacionLotes.mdb;" & "Jet OLEDB:Database Password=", cadConexionMdbDestino)

                    editor.escribir(pizarra, "Copia realizada con éxito.")

                    '################### JGARIJO 23/10/2019 ######################################
                    'NO UTIL. EL CODIGO FUENTE ESTA COMENTADO
                    'EscribirLog(rutaLotes, Now() & " -> " & "Copia realizada con éxito")
                    '#############################################################################

                    Application.DoEvents()

                    'Fin de la copia de la base de datos 


                    '**********************************************************************************
                    'CAMBIOS NECESARIOS PARA EMPEZAR A TRABAJAR CON PAPIROFELXIA 
                    '**********************************************************************************

                    'consultas utilizadas 


                    'control de que los datos que se van a introducir son correctos, vamos a controlar que hay 
                    'historia y codigo servicio paed para todos los registros  que no tienen el codigo de barras a 1 

                    consultaCamposBlanco = " SELECT * FROM DOCUMENTOS  WHERE (idlote = " & idlote & " )  AND (eliminada = 0 ) AND ((CodServicioPAED IS NULL) or (fechainicio is null) or (tipodocumento is null) or (NumHistoria IS NULL) ) "
                    datosEnBlanco = datosSql.ejecutarSQLDirectaTable(consultaCamposBlanco, cadenaconexionProyecto)

                    '################### JGARIJO 23/10/2019 ######################################
                    EscribirLog(rutaLotes, Now() & " -> " & "Select ejecutada: " & consultaCamposBlanco)
                    '#############################################################################

                    If datosEnBlanco.Rows.Count > 0 Then
                        '################## JGARIJO 23/10/2019 ###########################
                        'ELIMINAMOS LA LLAMADA AL MSGBOX PARA QUE EN CASO DE ERROR NO SEA NECESARIO PULSAR EL BOTON DE OK
                        'ESCRIBIMOS EL ERROR EN EL CAMPO PIZARRA
                        'MessageBox.Show("Hay registros en este lote que no tienen numero de historia o codigo de servicio, pase el lote a corrección y verifique que no se ha quedado ningún documento insertado sin indizar")
                        editor.escribir(pizarra, "ERROR: Hay registros en este lote que no tienen numero de historia o codigo de servicio, pase el lote a corrección y verifique que no se ha quedado ningún documento insertado sin indizar")

                        '################### JGARIJO 23/10/2019 ######################################
                        EscribirLog(rutaLotes, Now() & " -> " & "ERROR: Hay registros en el lote " & idlote & " que no tienen numero de historia o codigo de servicio, pase el lote a corrección y verifique que no se ha quedado ningún documento insertado sin indizar")
                        EscribirCSV(rutaLotes, "ERROR" & ";" & Now() & ";" & idlote & ";" & "" & ";" & "" & ";" & "Lote sin numero de historia o codigo de servicio")
                        '#############################################################################
                        RegistroErrores = RegistroErrores & "ERROR: Hay registros en el lote " & idlote & " que no tienen numero de historia o codigo de servicio, pase el lote a corrección y verifique que no se ha quedado ningún documento insertado sin indizar" & Chr(13) & Chr(10)
                        '################################################################
                        Return 0
                    End If


                    'copiar las imagenes 

                    '****************************************************************************************
                    'INICIO DEL PROCESO DE EXPORTACION DE LOS DOCUMENTOS Y CREANDO LA ESTRUCTURA DE DATOS 
                    '****************************************************************************************

                    'COPIAR LAS IMAGENES EN LA RUTA DE TRASPASO 
                    editor.escribir(pizarra, "Copiando imagenes en al ruta de traspaso...")

                    '################### JGARIJO 23/10/2019 ######################################
                    EscribirLog(rutaLotes, Now() & " -> " & "Copiando imagenes en la ruta de traspaso...")
                    '#############################################################################


                    blocdenotas.Clear()

                    historiasLote = datosSql.ejecutarSQLDirectaTable("select distinct numhistoria from documentos where idlote = " & idlote & " and ((eliminada <> 1) or (eliminada is null) )", cadenaconexionProyecto)

                    '################### JGARIJO 23/10/2019 ######################################
                    EscribirLog(rutaLotes, Now() & " -> " & "Select ejecutada: " & "select distinct numhistoria from documentos where idlote = " & idlote & " and ((eliminada <> 1) or (eliminada is null) )")
                    '#############################################################################

                    If historiasLote.Rows.Count > 0 Then

                        numerohistoriasconsulta = historiasLote.Rows.Count

                        'EN ESTE NIVEL ESTAMOS PROCESANDO POR HISTORIA 
                        For Each registro As DataRow In historiasLote.Rows

                            'proceso para cada historia y documento, en este caso el documento lo forma el servicio por lo que buscaremos los distintos servicios para 
                            'este historia en concreto 

                            editor.escribir(pizarra, "procesando historia " & registro.Item("numhistoria"))

                            '################### JGARIJO 23/10/2019 ######################################
                            EscribirLog(rutaLotes, Now() & " -> " & "Procesando la historia " & registro.Item("numhistoria"))
                            '#############################################################################


                            Application.DoEvents()


                            'creamos la carpeta para la historia dentro de la carpeta del lote 


                            carpetahistoria = carpetaDestinoLote & registro.Item("numhistoria").ToString


                            '####################### jgarijo 09/01/2020 #####################
                            'carpetahistoria = carpetahistoria.Replace("\\10.1.0.108", "c:")


                            Debug.Print(carpetahistoria)
                            If Not Directory.Exists(carpetahistoria) Then Directory.CreateDirectory(carpetahistoria)

                            'obtener los datos adjuntos de la historia nombre del paciente y sip lo hacemos aqui pq puede ser que estos datos no esten en la base de datos 
                            strsqlDatosAdjuntosHistoria = "SELECT nombre,apellido1,apellido2, sip FROM FIP where numhistoria = " & registro.Item("numhistoria")
                            datosadjuntosHsitoria = datosSql.ejecutarSQLDirectaTable(strsqlDatosAdjuntosHistoria, cadenaconexionProyecto)

                            '################### JGARIJO 23/10/2019 ######################################
                            EscribirLog(rutaLotes, Now() & " -> " & "Select ejecutada: " & strsqlDatosAdjuntosHistoria)
                            '#############################################################################


                            Debug.Print(registro.Item("numhistoria"))
                            If datosadjuntosHsitoria.Rows.Count > 0 Then
                                With datosadjuntosHsitoria.Rows(0)
                                    If IsDBNull(.Item("nombre")) Then
                                        nombre = ""
                                    Else
                                        nombre = .Item("nombre")
                                    End If

                                    If IsDBNull(.Item("apellido1")) Then
                                        apellido1 = ""
                                    Else
                                        apellido1 = .Item("apellido1")
                                    End If

                                    If IsDBNull(.Item("apellido2")) Then
                                        apellido2 = ""
                                    Else
                                        apellido2 = .Item("apellido2")
                                    End If
                                    If IsDBNull(.Item("sip")) Then
                                        sip = ""
                                    Else
                                        '##################### jgarijo 24/10/2019 ###################################
                                        'Modificación para evitar que, al no encontrar valor de SIP y retornar NONE se escriba en el fichero txt posterior.
                                        'Lo pasamos a mayuscula obligatoriamente para evitar discrepancias en la comparacion de los strings
                                        If Trim(UCase(.Item("sip"))) = "NONE" Then
                                            sip = ""
                                        Else
                                            sip = .Item("sip")
                                        End If
                                        '############################################################################

                                    End If
                                End With
                            Else
                                nombre = ""
                                apellido1 = ""
                                apellido2 = ""
                                sip = ""
                            End If

                            Dim strSQLdatosagrupaciondocumento As String = " SELECT numhistoria " _
                            & " FROM DOCUMENTOS " _
                            & " WHERE ((eliminada <> 1) OR " _
                            & " (eliminada IS NULL)) and idlote = " & idlote & " and  numhistoria = " & registro.Item("numhistoria") & " " _
                            & " GROUP BY numhistoria "

                            Debug.Print("SQL: " + strSQLdatosagrupaciondocumento)

                            datosAgrupacionDocumento = datosSql.ejecutarSQLDirectaTable(strSQLdatosagrupaciondocumento, cadenaconexionProyecto)

                            '################### JGARIJO 23/10/2019 ######################################
                            EscribirLog(rutaLotes, Now() & " -> " & "Select ejecutada: " & strSQLdatosagrupaciondocumento)
                            '#############################################################################

                            contadorDocumentos = 1
                            numerodocumentosconsulta = datosAgrupacionDocumento.Rows.Count

                            'EN ESTE NIVEL ESTAMOS TRABAJANDO A NIVEL DE DOCUMENTO AGRUPADO DENTRO DE UNA HISTORIA 
                            'para cada uno de los servicios que tenemos en este caso el criterio es este,
                            'vamos a buscar los documentos que forman un documento dentro de una historia 

                            'JANTONIO OJO
                            consultaDiario = " SELECT * FROM lotes  WHERE (idlote = " & idlote & " )"  'AND dat like 'Clinico'"
                            datosDiario = datosSql.ejecutarSQLDirectaTable(consultaDiario, cadenaconexionProyecto)

                            '################### JGARIJO 23/10/2019 ######################################
                            EscribirLog(rutaLotes, Now() & " -> " & "Select ejecutada: " & consultaDiario)
                            '#############################################################################

                            If datosDiario.Rows.Count > 0 Then

                                '***************************************************************************
                                '**************  HACEMOS UNA AGRUPACION DE TODA LA HISTORIA   **************
                                '***************************************************************************
                                For Each documento As DataRow In datosAgrupacionDocumento.Rows
                                    strSQLpaginasdocumentos = " select pagina,nomarchivotif from documentos " _
                                    & " where idlote = " & idlote & " " _
                                    & " and numhistoria = " & registro.Item("numhistoria") & "" _
                                    & " and ((eliminada =0)) order by pagina"
                                    'Sustituir esta línea por la anterior para que no se exporten las carátulas
                                    '& " and ((eliminada =1) OR (barcodedet <> 1) or (barcodedet is null)) order by pagina"


                                    Debug.Print("SQL: " + strSQLdatosagrupaciondocumento)

                                    paginasdocumentos = datosSql.ejecutarSQLDirectaTable(strSQLpaginasdocumentos, cadenaconexionProyecto)


                                    '################### JGARIJO 23/10/2019 ######################################
                                    EscribirLog(rutaLotes, Now() & " -> " & "Select ejecutada: " & strSQLpaginasdocumentos)
                                    '#############################################################################


                                    Dim datasetDocumentos As New DataSet
                                    Dim tablaDocumentos As DataTable
                                    Dim paginaInicial As Integer = 0
                                    Dim paginafinal As Integer = 1
                                    Dim expresion As String = ""

                                    'For Each tlbdocumentos As DataTable In datasetDocumentos.Tables

                                    directoriodocumento = carpetahistoria & "\DOCUMENTO" & contadorDocumentos
                                    Debug.Print(directoriodocumento)
                                    editor.escribir(pizarra, "copiando paginas para el DOCUMENTO" & contadorDocumentos)

                                    '################### JGARIJO 23/10/2019 ######################################
                                    EscribirLog(rutaLotes, Now() & " -> " & "Copiando paginas para el DOCUMENTO" & contadorDocumentos)
                                    '#############################################################################


                                    Application.DoEvents()

                                    '#########################################




                                    'directoriodocumento = Replace(directoriodocumento, "\\10.1.0.108", "c:")





                                    '##################### codigo eliminado 10/01/2020 #####################

                                    If Not Directory.Exists(directoriodocumento) Then Directory.CreateDirectory(directoriodocumento)

                                    contadorpagina = 1
                                    numeropaginasconsulta = datosAgrupacionDocumento.Rows.Count

                                    'EN ESTE NIVEL ESTAMOS TRABAJANDO A NIVEL DE PAGINA DENTRO DE UN DOCUMENTO DENTRO DE UNA HISTORIA 
                                    Dim strpaginas As String = ""


                                    '##################################
                                    'rutaimagenes = Replace(rutaimagenes, "\\172.21.100.190", "c:")


                                    '########################## JGARIJO 17/01/2020 ###############################

                                    'eliminamos el replace

                                    'rutaimagenes = Replace(rutaimagenes, "\\172.21.100.190", "\\10.8.0.6")








                                    For Each pagina As DataRow In paginasdocumentos.Rows

                                        nombredelarchivo = pagina.Item("nomarchivotif").ToString

                                        '##########################################################
                                        Dim origen As String = rutaimagenes & "\" & nombredelarchivo
                                        Dim destino As String = directoriodocumento & "\" & Format(contadorpagina, "0000000#") & ".TIF"

                                        File.Copy(origen, destino, True)

                                        '################### JGARIJO 23/10/2019 ######################################
                                        EscribirLog(rutaLotes, Now() & " -> " & "Copiando ficheros de " & origen & " a " & destino)
                                        '#############################################################################

                                        'aqui teneos los nombres de los documentos organizados por paginas esto es lo que se tiene que copiar 
                                        'en la carpeta lote 1 y aqui tenemos que emepezar a poner todos los datos een el fichero txt

                                        strpaginas &= "," & pagina.Item("pagina").ToString
                                        contadorpagina += 1
                                    Next






                                    '####################### fin de codigo eliminado ##########################################################





                                    Dim aux As Integer = contadorpagina - 1
                                    totales += aux
                                    'editor.escribir(pizarra, "copiadas -> " & aux & " paginas ->" & strpaginas)

                                    '################### JGARIJO 23/10/2019 ######################################
                                    'EscribirLog(rutaLotes, Now() & " -> " & "copiadas -> " & aux & " paginas ->" & strpaginas)
                                    '#############################################################################


                                    posbarra = InStrRev(directoriodocumento, "\")
                                    posbarra = InStrRev(directoriodocumento, "\", posbarra - 1)
                                    'posbarra = InStrRev(directoriodocumento, "\", posbarra - 1)
                                    directoriodocumentolinea = Mid(directoriodocumento, posbarra + 1)
                                    Debug.Print(directoriodocumentolinea)

                                    '###########################
                                    directoriodocumentolinea = Replace(directoriodocumentolinea, "\", "/")
                                    directoriodocumentolinea = idlote & "NHC" & Trim(registro.Item("numhistoria").ToString) & "/" & directoriodocumentolinea
                                    'modificacion para la asignacion del servicio 



                                    codigoServicotxt = ""
                                    area = ""
                                    tipodocumento = ""
                                    episodio = ""
                                    Debug.Print("codigo servicio ")
                                    Debug.Print("Tipo documento ")
                                    Debug.Print("episodio")

                                    fechaepisodio = "01/01/1900"


                                    Debug.Print(fechaepisodio.ToString)

                                    '###################### JGARIJO 07/01/2019 ##########################
                                    'MODIFICACION: SE ELIMINA LA LINEA "RESUMEN" DEL FICHERO TXT QUE SE ENVIA AL HOSPITAL. ESTA LINEA SIEMPRE ES LA PRIMERA DEL FICHERO DE TEXTO
                                    linea = Trim(registro.Item("numhistoria").ToString) & "|" & Trim(sip) & "|" & Trim(nombre) & "|" & Trim(apellido1) & "|" & Trim(apellido2) & "|" & directoriodocumentolinea & "|" & Trim(codigoServicotxt) & "|" & Trim(area) & "|" & Trim(tipodocumento) & "|" & "|" & fechaepisodio & "|" & idlote & "NHC" & Trim(registro.Item("numhistoria").ToString) & "|" & contadorpagina - 1 & "|"
                                    'linea = ""
                                    '####################################################################






                                    Debug.Print(linea)

                                    '####################### JGARIJO 08/01/2020 #########################
                                    'evitamos que se copie el contenido en bloc de notas para que no pase a fichero

                                    editor.escribir(blocdenotas, linea)

                                    '####################################################################




                                    '################### JGARIJO 23/10/2019 ######################################
                                    EscribirLog(rutaLotes, Now() & " -> " & "Linea a introducir en fichero: " & linea)
                                    '#############################################################################


                                    codigoServicotxt = ""
                                    directoriodocumentolinea = ""
                                    area = ""
                                    tipodocumento = ""
                                    episodio = ""
                                    fechaepisodio = ""
                                    fechadocumento = ""

                                    contadorDocumentos += 1
                                Next 'fin del recorrido por los documentos 
                                'Next


                                '***************************************************************************
                                '********* ENTREGAMOS SOLO LOS TIPOS IMPORTANTES *********
                                '***************************************************************************







                                '####################### JGARIJO 07/01/2020 ###########################
                                'MODIFICACION: SE CAMBIA LA SELECT DE AGRUPACION DE DOCUMENTOS PARA ADAPTARLA A LAS NUEVAS NECESIDADES 

                                'SE HACE UNA PRIMERA DIFERENCIA DE DOCUMENTOS
                                'Informe Clínico de Alta: TIPO DE DOCUMENTO 1
                                'Informes de Alta de Otros Hospitales: TIPO DE DOCUMENTO 2
                                'Consentimiento Informado: TIPO DE DOCUMENTO 120
                                'Protocolo quirúrgico: TIPO DE DOCUMENTO 302


                                'strSQLdatosagrupaciondocumento = "SELECT TipoDocumento, CodServicioPAED, NumIcu, FechaInicio " _
                                '& " FROM DOCUMENTOS " _
                                '& " WHERE ((eliminada <> 1) OR " _
                                '& " (eliminada IS NULL)) and idlote = " & idlote & " and tipodocumento in (1,4,302,120,11,12,15,230,5) and   numhistoria = " & registro.Item("numhistoria") & " " _
                                '& " GROUP BY TipoDocumento, CodServicioPAED, NumIcu, FechaInicio"
                                '######################################################################







                                'ESTA SELECT SE ENCARGA DE BUSCAR AQUELLOS REGISTROS DE LA TABLA DOCUMENTOS CUYO TIPO DE SERVICIO SEA 1, 2, 120 O 302 

                                strSQLdatosagrupaciondocumento = "SELECT TipoDocumento, CodServicioPAED, NumIcu, FechaInicio " _
                                & " FROM DOCUMENTOS " _
                                & " WHERE ((eliminada <> 1) OR " _
                                & " (eliminada IS NULL)) and idlote = " & idlote & " and tipodocumento in (1,2,4,302,120) and numhistoria = " & registro.Item("numhistoria") & " " _
                                & " GROUP BY TipoDocumento, CodServicioPAED, NumIcu, FechaInicio"


                                Debug.Print(strSQLdatosagrupaciondocumento)
                                datosAgrupacionDocumento = datosSql.ejecutarSQLDirectaTable(strSQLdatosagrupaciondocumento, cadenaconexionProyecto)

                                '################### JGARIJO 23/10/2019 ######################################
                                EscribirLog(rutaLotes, Now() & " -> " & "Select ejecutada: " & strSQLdatosagrupaciondocumento)
                                '#############################################################################

                                numerodocumentosconsulta = datosAgrupacionDocumento.Rows.Count

                                'EN ESTE NIVEL ESTAMOS TRABAJANDO A NIVEL DE DOCUMENTO AGRUPADO DENTRO DE UNA HISTORIA 
                                'para cada uno de los servicios que tenemos en este caso el criterio es este, 
                                'vamos a buscar los documentos que forman un documento dentro de una historia




                                '########################### cambios del 10/01/2020 #################

                                contadorDocumentos = contadorDocumentos - 1

                                '####################################################################










                                For Each documento As DataRow In datosAgrupacionDocumento.Rows
                                    strSQLpaginasdocumentos = " select pagina,nomarchivotif from documentos " _
                                    & " where idlote = " & idlote & " " _
                                    & " and numhistoria = " & registro.Item("numhistoria") & "" _
                                    & " and TipoDocumento  = " & documento.Item("TipoDocumento") & "" _
                                    & " and numicu  = " & documento.Item("numicu") & "" _
                                    & " and fechainicio = '" & documento.Item("fechainicio") & "' " _
                                    & " and codserviciopaed  = " & documento.Item("codserviciopaed") & "" _
                                    & " and ((eliminada =0)) order by pagina"
                                    'Sustituir esta línea por la anterior para que no se exporten las carátulas
                                    '& " and ((eliminada =1) OR (barcodedet <> 1) or (barcodedet is null)) order by pagina"


                                    Debug.Print(strSQLpaginasdocumentos)
                                    paginasdocumentos = datosSql.ejecutarSQLDirectaTable(strSQLpaginasdocumentos, cadenaconexionProyecto)

                                    '################### JGARIJO 23/10/2019 ######################################
                                    EscribirLog(rutaLotes, Now() & " -> " & "Select ejecutada: " & strSQLpaginasdocumentos)
                                    '#############################################################################

                                    Dim datasetDocumentos As New DataSet
                                    Dim tablaDocumentos As DataTable
                                    Dim paginaInicial As Integer = 0
                                    Dim paginafinal As Integer = 1
                                    Dim expresion As String = ""





                                    directoriodocumento = carpetahistoria & "\DOCUMENTO" & contadorDocumentos
                                    Debug.Print(directoriodocumento)
                                    editor.escribir(pizarra, "copiando paginas para el DOCUMENTO" & contadorDocumentos)


                                    '################### JGARIJO 23/10/2019 ######################################
                                    EscribirLog(rutaLotes, Now() & " -> " & "Copiando paginas para el DOCUMENTO" & contadorDocumentos)
                                    '#############################################################################

                                    Application.DoEvents()

                                    '############################


                                    'directoriodocumento = Replace(directoriodocumento, "\\10.1.0.108", "C:")

                                    If Not Directory.Exists(directoriodocumento) Then Directory.CreateDirectory(directoriodocumento)

                                    contadorpagina = 1
                                    numeropaginasconsulta = datosAgrupacionDocumento.Rows.Count

                                    'EN ESTE NIVEL ESTAMOS TRABAJANDO A NIVEL DE PAGINA DENTRO DE UN DOCUMENTO DENTRO DE UNA HISTORIA 
                                    Dim strpaginas As String = ""
                                    For Each pagina As DataRow In paginasdocumentos.Rows

                                        nombredelarchivo = pagina.Item("nomarchivotif").ToString

                                        File.Copy(rutaimagenes & "\" & nombredelarchivo, directoriodocumento & "\" & Format(contadorpagina, "0000000#") & ".TIF", True)
                                        'aqui teneos los nombres de los documentos organizados por paginas esto es lo que se tiene que copiar 
                                        'en la carpeta lote 1 y aqui tenemos que emepezar a poner todos los datos een el fichero txt

                                        '################### JGARIJO 23/10/2019 ######################################
                                        EscribirLog(rutaLotes, Now() & " -> " & "Imagen copiada de " & rutaimagenes & "\" & nombredelarchivo & " a " & directoriodocumento & "\" & Format(contadorpagina, "0000000#") & ".TIF")
                                        '#############################################################################

                                        strpaginas &= "," & pagina.Item("pagina").ToString
                                        contadorpagina += 1
                                    Next

                                    Dim aux As Integer = contadorpagina - 1
                                    totales += aux
                                    editor.escribir(pizarra, "copiadas -> " & aux & " paginas ->" & strpaginas)

                                    '################### JGARIJO 23/10/2019 ######################################
                                    EscribirLog(rutaLotes, Now() & " -> " & "copiadas -> " & aux & " paginas ->" & strpaginas)
                                    '#############################################################################


                                    posbarra = InStrRev(directoriodocumento, "\")
                                    posbarra = InStrRev(directoriodocumento, "\", posbarra - 1)
                                    'posbarra = InStrRev(directoriodocumento, "\", posbarra - 1)
                                    directoriodocumentolinea = Mid(directoriodocumento, posbarra + 1)
                                    Debug.Print(directoriodocumentolinea)


                                    '###############################################################
                                    directoriodocumentolinea = Replace(directoriodocumentolinea, "\", "/")
                                    directoriodocumentolinea = idlote & "NHC" & Trim(registro.Item("numhistoria").ToString) & "/" & directoriodocumentolinea
                                    'modificacion para la asignacion del servicio 

                                    Try

                                        If IsDBNull(documento.Item("codserviciopaed")) Then
                                            area = ""
                                            codigoServicotxt = ""
                                        Else
                                            If documento.Item("codserviciopaed") = "0" Or documento.Item("codserviciopaed") = "998" Then
                                                codigoServicotxt = ""
                                                area = ""
                                            Else
                                                'hay que calcular el episodio para el hospital 
                                                codigoServicotxt = documento.Item("codserviciopaed")

                                                Dim tablearea As DataTable = datosSql.ejecutarSQLDirectaTable("SELECT cod_servicio FROM SERVICIOSHOSPITAL WHERE idServicio = " & codigoServicotxt, cadenaconexionProyecto)

                                                '################### JGARIJO 23/10/2019 ######################################
                                                EscribirLog(rutaLotes, Now() & " -> " & "Select : " & "SELECT cod_servicio FROM SERVICIOSHOSPITAL WHERE idServicio = " & codigoServicotxt)
                                                '#############################################################################

                                                '############################## JGARIJO 23/10/2019 ###############################
                                                'DOS MODIFICACIONES. EL CONDICIONAL NO ES CORRECTO, CUANDO LA SELECT NO DEVUELVE RESULTADO 
                                                ' EL COUNT NO ES INFERIOR A 0, ES 0 DIRECTAMENTE.
                                                'ADEMAS, SE CAMBIA EL MSGBOX PARA EVITAR QUE SE DETENGA LA EJECUCION 

                                                'If tablearea.Rows.Count < 0 Then

                                                If tablearea.Rows.Count <= 0 Then
                                                    'MessageBox.Show("Error no se ha encontrado correspondencia tipo documento para historia " & registro.Item("numhistoria").ToString)
                                                    editor.escribir(pizarra, "Error no se ha encontrado correspondencia codigo de servicio para historia " & registro.Item("numhistoria").ToString)

                                                    '################### JGARIJO 23/10/2019 ######################################
                                                    EscribirLog(rutaLotes, Now() & " -> " & "ERROR: " & "Error no se ha encontrado correspondencia Código de servicio " & codigoServicotxt & " para historia " & registro.Item("numhistoria").ToString & " en el lote " & idlote)
                                                    EscribirCSV(rutaLotes, "ERROR" & ";" & Now() & ";" & idlote & ";" & registro.Item("numhistoria").ToString & ";" & codigoServicotxt & ";" & "Codigo de servicio erroneo")
                                                    '#############################################################################
                                                    RegistroErrores = RegistroErrores & "ERROR: " & "Error no se ha encontrado correspondencia Código de servicio " & codigoServicotxt & " para historia " & registro.Item("numhistoria").ToString & " en el lote " & idlote & Chr(13) & Chr(10)
                                                    Exit Function
                                                Else
                                                    codigoServicotxt = tablearea.Rows(0).Item(0)
                                                End If


                                                tablearea = datosSql.ejecutarSQLDirectaTable("SELECT seccion FROM SERVICIOSHOSPITAL WHERE idServicio = " & documento.Item("codserviciopaed"), cadenaconexionProyecto)
                                                If tablearea.Rows.Count <= 0 Then
                                                    'MessageBox.Show("Error no se ha encontrado correspondencia tipo documento para historia " & registro.Item("numhistoria").ToString)

                                                    '################### JGARIJO 23/10/2019 ######################################
                                                    EscribirLog(rutaLotes, Now() & " -> " & "ERROR: " & "Error no se ha encontrado correspondencia Código de servicio " & codigoServicotxt & " con seccion en el lote " & idlote)
                                                    EscribirCSV(rutaLotes, "ERROR" & ";" & Now() & ";" & idlote & ";" & registro.Item("numhistoria").ToString & ";" & codigoServicotxt & ";" & "Codigo de servicio erroneo sin seccion")
                                                    '#############################################################################
                                                    RegistroErrores = RegistroErrores & "ERROR: " & "Error no se ha encontrado correspondencia Código de servicio " & codigoServicotxt & " con seccion en el lote " & idlote & Chr(13) & Chr(10)
                                                    Exit Function
                                                Else
                                                    area = tablearea.Rows(0).Item(0)
                                                End If



















                                                '############################## FIN DE LA MODIFICACION ###########################

                                            End If
                                        End If
                                        Debug.Print("codigo servicio ")

                                        If IsDBNull(documento.Item("Tipodocumento")) Then
                                            tipodocumento = ""
                                        Else
                                            If documento.Item("Tipodocumento") = "0" Or documento.Item("Tipodocumento") = "99" Then
                                                tipodocumento = ""
                                            Else
                                                'hay que calcular el tipo de documeno para el hospital 
                                                tipodocumento = documento.Item("Tipodocumento")

                                                Dim tipodocumentobd As DataTable
                                                tipodocumentobd = datosSql.ejecutarSQLDirectaTable("select idtipodocumentohosopital from correspondenciatiposdocumentos where idtipodocumento = " & tipodocumento, cadenaconexionProyecto)

                                                '################### JGARIJO 23/10/2019 ######################################
                                                EscribirLog(rutaLotes, Now() & " -> " & "Select ejecutada: " & "select idtipodocumentohosopital from correspondenciatiposdocumentos where idtipodocumento = " & tipodocumento)
                                                '#############################################################################


                                                '####################### JGARIJO 23/10/2019 ########################
                                                'DOS MODIFICACIONES. EL CONDICIONAL NO ES CORRECTO, CUANDO LA SELECT NO DEVUELVE RESULTADO 
                                                ' EL COUNT NO ES INFERIOR A 0, ES 0 DIRECTAMENTE.
                                                'ADEMAS, SE CAMBIA EL MSGBOX PARA EVITAR QUE SE DETENGA LA EJECUCION
                                                'If tipodocumentobd.Rows.Count < 0 Then
                                                If tipodocumentobd.Rows.Count <= 0 Then
                                                    'MessageBox.Show("Error no se ha encontrado correspondencia tipo documento para historia " & registro.Item("numhistoria").ToString)
                                                    editor.escribir(pizarra, "Error no se ha encontrado correspondencia Tipo Documento para historia " & registro.Item("numhistoria").ToString)

                                                    '################### JGARIJO 23/10/2019 ######################################
                                                    EscribirLog(rutaLotes, Now() & " -> " & "ERROR: " & "Error no se ha encontrado correspondencia Tipo Documento " & tipodocumento & " para historia " & registro.Item("numhistoria").ToString & " en el lote " & idlote)
                                                    EscribirCSV(rutaLotes, "ERROR" & ";" & Now() & ";" & idlote & ";" & registro.Item("numhistoria").ToString & ";" & tipodocumento & ";" & "Tipo de Documento erroneo")
                                                    '#############################################################################
                                                    RegistroErrores = RegistroErrores & "ERROR: " & "Error no se ha encontrado correspondencia Tipo Documento " & tipodocumento & " para historia " & registro.Item("numhistoria").ToString & " en el lote " & idlote & Chr(13) & Chr(10)

                                                    Exit Function
                                                Else
                                                    tipodocumento = tipodocumentobd.Rows(0).Item(0)
                                                End If
                                                '############################### FIN DE LA MODIFICACION #####################
                                            End If
                                        End If

                                        Debug.Print("Tipo documento ")


                                        If IsDBNull(documento.Item("numicu")) Then
                                            episodio = ""
                                        Else
                                            If documento.Item("numicu") = "998" Then
                                                episodio = ""
                                            Else
                                                episodio = documento.Item("numicu")
                                            End If

                                        End If
                                        Debug.Print("episodio")

                                        If IsDBNull(documento.Item("fechainicio")) Then
                                            fechaepisodio = ""
                                        Else
                                            If documento.Item("fechainicio") = "01/01/1900" Then
                                                fechaepisodio = ""
                                            Else
                                                fechaepisodio = documento.Item("fechainicio")
                                            End If
                                        End If
                                        If episodio = "" Then
                                            fechadocumento = "|" & fechaepisodio
                                            fechaepisodio = ""
                                        End If
                                        Debug.Print(fechaepisodio.ToString)

                                    Catch ex As Exception
                                        editor.escribir(pizarra, "Error en la lectura de los datos de la base de datos ", Color.Red)
                                        '################### JGARIJO 23/10/2019 ######################################
                                        EscribirLog(rutaLotes, Now() & " -> " & "ERROR: " & "Error en la lectura de los datos de la base de datos ")
                                        EscribirCSV(rutaLotes, "ERROR" & ";" & Now() & ";" & "" & ";" & "" & ";" & "" & ";" & "Error en la lectura de los datos de la base de datos")
                                        '#############################################################################

                                        RegistroErrores = RegistroErrores & "ERROR: " & "Error en la lectura de los datos de la base de datos " & Chr(13) & Chr(10)
                                        Exit Function
                                    End Try













                                    '############################## JGARIJO 23/10/2019 #################################
                                    'Comprobamos si fechadocumento esta en blanco. Si episodio es blanco, la variable se ha inicializado con una barra vertical
                                    ' por lo que no tendrá más longitud de 1

                                    If fechadocumento.Trim.Length <= 1 Then
                                        linea = Trim(registro.Item("numhistoria").ToString) & "|" & Trim(sip) & "|" & Trim(nombre) & "|" & Trim(apellido1) & "|" & Trim(apellido2) & "|" & directoriodocumentolinea & "|" & Trim(codigoServicotxt) & "|" & Trim(area) & "|" & Trim(tipodocumento) & "|" & episodio & "|" & fechaepisodio & "|" & idlote & "NHC" & Trim(registro.Item("numhistoria").ToString) & "|" & contadorpagina - 1 & "|"
                                    Else
                                        linea = Trim(registro.Item("numhistoria").ToString) & "|" & Trim(sip) & "|" & Trim(nombre) & "|" & Trim(apellido1) & "|" & Trim(apellido2) & "|" & directoriodocumentolinea & "|" & Trim(codigoServicotxt) & "|" & Trim(area) & "|" & Trim(tipodocumento) & "|" & episodio & "|" & fechaepisodio & "|" & idlote & "NHC" & Trim(registro.Item("numhistoria").ToString) & "|" & contadorpagina - 1 & fechadocumento
                                    End If

                                    '######################### FIN DE LA MODIFICACION 23/10/2019 ######################


                                    Debug.Print(linea)
                                    editor.escribir(blocdenotas, linea)

                                    '################### JGARIJO 23/10/2019 ######################################
                                    EscribirLog(rutaLotes, Now() & " -> " & "Linea introducida: " & linea)
                                    '#############################################################################


                                    codigoServicotxt = ""
                                    directoriodocumentolinea = ""
                                    area = ""
                                    tipodocumento = ""
                                    episodio = ""
                                    fechaepisodio = "01/01/1900"
                                    fechadocumento = ""

                                    contadorDocumentos += 1
                                Next 'fin del recorrido por los documentos

                                'AQUÍ TERMINA EL BUCLE QUE RECORRE LOS REGISTROS DE LA TABLA DOCUMENTOS CON TIPO SERVICIO 1,2,302,120



                                'AQUI SE DEBERÍA DUPLICAR EL CODIGO ANTERIOR SELECCIONANDO AQUELLOS REGISTROS DE DOCUMENTOS QUE NO FUESEN NI 1, NI 2 NI 302 NI 120





                                'strSQLdatosagrupaciondocumento = "SELECT codserviciopaed " _
                                '& " FROM DOCUMENTOS " _
                                '& " WHERE ((eliminada <> 1) OR " _
                                '& " (eliminada IS NULL)) and idlote = " & idlote & " and tipodocumento NOT in (1,2,302,120) and numhistoria = " & registro.Item("numhistoria") & " " _
                                '& " GROUP BY CodServicioPAED"










                                'strSQLdatosagrupaciondocumento = "select '', cs.cod_servicio, '', '' from documentos d , SERVICIOSHOSPITAL cs where d.CodServicioPAED = cs.idServicio and d.idlote = " & idlote & " and d.numhistoria = " & registro.Item("numhistoria") & " and d.eliminada <> 1 and d.tipodocumento not in (1,2,302,120) group by cs.cod_servicio"

                                strSQLdatosagrupaciondocumento = "select '', cs.cod_servicio, cs.idservicio, '' from documentos d , SERVICIOSHOSPITAL cs where d.CodServicioPAED = cs.idServicio and d.idlote = " & idlote & " and d.numhistoria = " & registro.Item("numhistoria") & " and (d.eliminada <> 1 or d.eliminada is NULL) and d.tipodocumento not in (1,2,4,302,120) group by cs.cod_servicio,cs.idservicio"








                                Debug.Print(strSQLdatosagrupaciondocumento)
                                datosAgrupacionDocumento = datosSql.ejecutarSQLDirectaTable(strSQLdatosagrupaciondocumento, cadenaconexionProyecto)

                                '################### JGARIJO 23/10/2019 ######################################
                                EscribirLog(rutaLotes, Now() & " -> " & "Select ejecutada: " & strSQLdatosagrupaciondocumento)
                                '#############################################################################

                                numerodocumentosconsulta = datosAgrupacionDocumento.Rows.Count

                                'EN ESTE NIVEL ESTAMOS TRABAJANDO A NIVEL DE DOCUMENTO AGRUPADO DENTRO DE UNA HISTORIA 
                                'para cada uno de los servicios que tenemos en este caso el criterio es este, 
                                'vamos a buscar los documentos que forman un documento dentro de una historia

                                For Each documento As DataRow In datosAgrupacionDocumento.Rows


                                    'strSQLpaginasdocumentos = " select pagina,nomarchivotif from documentos " _
                                    '& " where idlote = " & idlote & " " _
                                    '& " and numhistoria = " & registro.Item("numhistoria") & "" _

                                    '& " and TipoDocumento  = " & documento.Item("TipoDocumento") & ""

                                    '& " and TipoDocumento NOT in (1,2,302,120) " & "" 

                                    '& " and numicu  = " & documento.Item("numicu") & ""

                                    '& " and fechainicio = '" & documento.Item("fechainicio") & "' " _
                                    '& " and codserviciopaed  = " & documento.Item("codserviciopaed") & "" _
                                    '& " and ((eliminada =0)) order by fechainicio"







                                    'strSQLpaginasdocumentos = "select pagina,nomarchivotif from documentos where idlote = " & idlote & " and numhistoria = " & registro.Item("numhistoria") & " and TipoDocumento NOT in (1,2,302,120) and codserviciopaed = " & documento.Item("codserviciopaed") & " and ((eliminada =0)) order by fechainicio,pagina"

                                    strSQLpaginasdocumentos = "select * from documentos where CodServicioPAED in (select idservicio from SERVICIOSHOSPITAL where cod_servicio = '" & documento.Item("cod_servicio") & "') and TipoDocumento NOT in (1,2,4,302,120) and idlote = " & idlote & " and numhistoria = " & registro.Item("numhistoria") & " and eliminada =0"



                                    'Sustituir esta línea por la anterior para que no se exporten las carátulas
                                    '& " and ((eliminada =1) OR (barcodedet <> 1) or (barcodedet is null)) order by pagina"


                                    Debug.Print(strSQLpaginasdocumentos)
                                    paginasdocumentos = datosSql.ejecutarSQLDirectaTable(strSQLpaginasdocumentos, cadenaconexionProyecto)

                                    '################### JGARIJO 23/10/2019 ######################################
                                    EscribirLog(rutaLotes, Now() & " -> " & "Select ejecutada: " & strSQLpaginasdocumentos)
                                    '#############################################################################

                                    Dim datasetDocumentos As New DataSet
                                    Dim tablaDocumentos As DataTable
                                    Dim paginaInicial As Integer = 0
                                    Dim paginafinal As Integer = 1
                                    Dim expresion As String = ""

                                    directoriodocumento = carpetahistoria & "\DOCUMENTO" & contadorDocumentos
                                    Debug.Print(directoriodocumento)
                                    editor.escribir(pizarra, "copiando paginas para el DOCUMENTO" & contadorDocumentos)


                                    '################### JGARIJO 23/10/2019 ######################################
                                    EscribirLog(rutaLotes, Now() & " -> " & "Copiando paginas para el DOCUMENTO" & contadorDocumentos)
                                    '#############################################################################

                                    Application.DoEvents()

                                    '############################
                                    'directoriodocumento = Replace(directoriodocumento, "\\10.1.0.108", "C:")

                                    If Not Directory.Exists(directoriodocumento) Then Directory.CreateDirectory(directoriodocumento)

                                    contadorpagina = 1
                                    numeropaginasconsulta = datosAgrupacionDocumento.Rows.Count

                                    'EN ESTE NIVEL ESTAMOS TRABAJANDO A NIVEL DE PAGINA DENTRO DE UN DOCUMENTO DENTRO DE UNA HISTORIA 
                                    Dim strpaginas As String = ""
                                    For Each pagina As DataRow In paginasdocumentos.Rows

                                        nombredelarchivo = pagina.Item("nomarchivotif").ToString

                                        File.Copy(rutaimagenes & "\" & nombredelarchivo, directoriodocumento & "\" & Format(contadorpagina, "0000000#") & ".TIF", True)
                                        'aqui teneos los nombres de los documentos organizados por paginas esto es lo que se tiene que copiar 
                                        'en la carpeta lote 1 y aqui tenemos que emepezar a poner todos los datos een el fichero txt

                                        '################### JGARIJO 23/10/2019 ######################################
                                        EscribirLog(rutaLotes, Now() & " -> " & "Imagen copiada de " & rutaimagenes & "\" & nombredelarchivo & " a " & directoriodocumento & "\" & Format(contadorpagina, "0000000#") & ".TIF")
                                        '#############################################################################

                                        strpaginas &= "," & pagina.Item("pagina").ToString
                                        contadorpagina += 1
                                    Next

                                    Dim aux As Integer = contadorpagina - 1
                                    totales += aux
                                    editor.escribir(pizarra, "copiadas -> " & aux & " paginas ->" & strpaginas)

                                    '################### JGARIJO 23/10/2019 ######################################
                                    EscribirLog(rutaLotes, Now() & " -> " & "copiadas -> " & aux & " paginas ->" & strpaginas)
                                    '#############################################################################


                                    posbarra = InStrRev(directoriodocumento, "\")
                                    posbarra = InStrRev(directoriodocumento, "\", posbarra - 1)
                                    'posbarra = InStrRev(directoriodocumento, "\", posbarra - 1)
                                    directoriodocumentolinea = Mid(directoriodocumento, posbarra + 1)
                                    Debug.Print(directoriodocumentolinea)


                                    '###############################################################
                                    directoriodocumentolinea = Replace(directoriodocumentolinea, "\", "/")
                                    directoriodocumentolinea = idlote & "NHC" & Trim(registro.Item("numhistoria").ToString) & "/" & directoriodocumentolinea
                                    'modificacion para la asignacion del servicio 

                                    '                    Try

                                    '            If IsDBNull(documento.Item("codserviciopaed")) Then
                                    'area = ""
                                    'codigoServicotxt = ""
                                    'Else
                                    'If documento.Item("codserviciopaed") = "0" Or documento.Item("codserviciopaed") = "998" Then
                                    'codigoServicotxt = ""
                                    'area = ""
                                    'Else
                                    'hay que calcular el episodio para el hospital 
                                    'codigoServicotxt = documento.Item("codserviciopaed")

                                    'Dim tablearea As DataTable = datosSql.ejecutarSQLDirectaTable("SELECT cod_servicio FROM SERVICIOSHOSPITAL WHERE idServicio = " & codigoServicotxt, cadenaconexionProyecto)

                                    ' '################### JGARIJO 23/10/2019 ######################################
                                    ' EscribirLog(rutaLotes, Now() & " -> " & "Select : " & "SELECT cod_servicio FROM SERVICIOSHOSPITAL WHERE idServicio = " & codigoServicotxt)
                                    '#############################################################################


                                    Dim tablearea As DataTable
                                    tablearea = datosSql.ejecutarSQLDirectaTable("SELECT seccion FROM SERVICIOSHOSPITAL WHERE idServicio = " & documento.Item("idservicio"), cadenaconexionProyecto)
                                    If tablearea.Rows.Count <= 0 Then
                                        'MessageBox.Show("Error no se ha encontrado correspondencia tipo documento para historia " & registro.Item("numhistoria").ToString)

                                        '################### JGARIJO 23/10/2019 ######################################
                                        EscribirLog(rutaLotes, Now() & " -> " & "ERROR: " & "Error no se ha encontrado correspondencia Código de servicio " & codigoServicotxt & " con seccion en el lote " & idlote)
                                        EscribirCSV(rutaLotes, "ERROR" & ";" & Now() & ";" & idlote & ";" & registro.Item("numhistoria").ToString & ";" & codigoServicotxt & ";" & "Codigo de servicio erroneo sin seccion")
                                        '#############################################################################
                                        RegistroErrores = RegistroErrores & "ERROR: " & "Error no se ha encontrado correspondencia Código de servicio " & codigoServicotxt & " con seccion en el lote " & idlote & Chr(13) & Chr(10)
                                        Exit Function
                                    Else
                                        area = tablearea.Rows(0).Item(0)
                                    End If
















                                    ' '############################## JGARIJO 23/10/2019 ###############################
                                    ' 'DOS MODIFICACIONES. EL CONDICIONAL NO ES CORRECTO, CUANDO LA SELECT NO DEVUELVE RESULTADO 
                                    ' ' EL COUNT NO ES INFERIOR A 0, ES 0 DIRECTAMENTE.
                                    ' 'ADEMAS, SE CAMBIA EL MSGBOX PARA EVITAR QUE SE DETENGA LA EJECUCION 

                                    ' 'If tablearea.Rows.Count < 0 Then

                                    'If tablearea.Rows.Count <= 0 Then
                                    ' 'MessageBox.Show("Error no se ha encontrado correspondencia tipo documento para historia " & registro.Item("numhistoria").ToString)
                                    ' editor.escribir(pizarra, "Error no se ha encontrado correspondencia codigo de servicio para historia " & registro.Item("numhistoria").ToString)

                                    '################### JGARIJO 23/10/2019 ######################################
                                    ' EscribirLog(rutaLotes, Now() & " -> " & "ERROR: " & "Error no se ha encontrado correspondencia Código de servicio " & codigoServicotxt & " para historia " & registro.Item("numhistoria").ToString & " en el lote " & idlote)
                                    ' EscribirCSV(rutaLotes, "ERROR" & ";" & Now() & ";" & idlote & ";" & registro.Item("numhistoria").ToString & ";" & codigoServicotxt & ";" & "Codigo de servicio erroneo")
                                    '#############################################################################
                                    ' RegistroErrores = RegistroErrores & "ERROR: " & "Error no se ha encontrado correspondencia Código de servicio " & codigoServicotxt & " para historia " & registro.Item("numhistoria").ToString & " en el lote " & idlote & Chr(13) & Chr(10)
                                    ' Exit Function
                                    ' Else
                                    ' codigoServicotxt = tablearea.Rows(0).Item(0)
                                    'End If

                                    '############################## FIN DE LA MODIFICACION ###########################

                                    ' End If
                                    ' End If
                                    ' Debug.Print("codigo servicio ")

                                    'If IsDBNull(documento.Item("Tipodocumento")) Then
                                    'tipodocumento = ""
                                    'Else
                                    'If documento.Item("Tipodocumento") = "0" Or documento.Item("Tipodocumento") = "99" Then
                                    'tipodocumento = ""
                                    'Else
                                    'hay que calcular el tipo de documeno para el hospital 
                                    'tipodocumento = documento.Item("Tipodocumento")

                                    'Dim tipodocumentobd As DataTable
                                    'tipodocumentobd = datosSql.ejecutarSQLDirectaTable("select idtipodocumentohosopital from correspondenciatiposdocumentos where idtipodocumento = " & tipodocumento, cadenaconexionProyecto)

                                    '################### JGARIJO 23/10/2019 ######################################
                                    'EscribirLog(rutaLotes, Now() & " -> " & "Select ejecutada: " & "select idtipodocumentohosopital from correspondenciatiposdocumentos where idtipodocumento = " & tipodocumento)
                                    '#############################################################################


                                    '  '####################### JGARIJO 23/10/2019 ########################
                                    '  'DOS MODIFICACIONES. EL CONDICIONAL NO ES CORRECTO, CUANDO LA SELECT NO DEVUELVE RESULTADO 
                                    '  ' EL COUNT NO ES INFERIOR A 0, ES 0 DIRECTAMENTE.
                                    ' 'ADEMAS, SE CAMBIA EL MSGBOX PARA EVITAR QUE SE DETENGA LA EJECUCION
                                    '  'If tipodocumentobd.Rows.Count < 0 Then
                                    '  If tipodocumentobd.Rows.Count <= 0 Then
                                    ' 'MessageBox.Show("Error no se ha encontrado correspondencia tipo documento para historia " & registro.Item("numhistoria").ToString)
                                    ' editor.escribir(pizarra, "Error no se ha encontrado correspondencia Tipo Documento para historia " & registro.Item("numhistoria").ToString)

                                    ' '################### JGARIJO 23/10/2019 ######################################
                                    'EscribirLog(rutaLotes, Now() & " -> " & "ERROR: " & "Error no se ha encontrado correspondencia Tipo Documento " & tipodocumento & " para historia " & registro.Item("numhistoria").ToString & " en el lote " & idlote)
                                    'EscribirCSV(rutaLotes, "ERROR" & ";" & Now() & ";" & idlote & ";" & registro.Item("numhistoria").ToString & ";" & tipodocumento & ";" & "Tipo de Documento erroneo")
                                    '#############################################################################
                                    'RegistroErrores = RegistroErrores & "ERROR: " & "Error no se ha encontrado correspondencia Tipo Documento " & tipodocumento & " para historia " & registro.Item("numhistoria").ToString & " en el lote " & idlote & Chr(13) & Chr(10)

                                    'Exit Function
                                    'Else
                                    'tipodocumento = tipodocumentobd.Rows(0).Item(0)
                                    'End If
                                    '############################### FIN DE LA MODIFICACION #####################
                                    ' End If
                                    ' End If

                                    'Debug.Print("Tipo documento ")


                                    'If IsDBNull(documento.Item("numicu")) Then
                                    'episodio = ""
                                    'Else
                                    'If documento.Item("numicu") = "998" Then
                                    'episodio = ""
                                    'Else
                                    'episodio = documento.Item("numicu")
                                    'End If

                                    'End If
                                    'Debug.Print("episodio")

                                    '                                    If IsDBNull(documento.Item("fechainicio")) Then
                                    'fechaepisodio = ""
                                    'Else
                                    'If documento.Item("fechainicio") = "01/01/1900" Then
                                    'fechaepisodio = ""
                                    'Else
                                    'fechaepisodio = documento.Item("fechainicio")
                                    'End If
                                    'End If
                                    'If episodio = "" Then
                                    'fechadocumento = "|" & fechaepisodio
                                    'fechaepisodio = ""
                                    'End If



                                    'If IsDBNull(registro.Item("fechainicio")) Then
                                    'fechaepisodio = ""
                                    'Else
                                    'If registro.Item("fechainicio") = "01/01/1900" Then
                                    'fechaepisodio = ""
                                    'Else
                                    'fechaepisodio = registro.Item("fechainicio")
                                    'End If
                                    'End If
                                    'If episodio = "" Then
                                    'fechadocumento = "|" & fechaepisodio
                                    'fechaepisodio = ""
                                    'End If












                                    'Debug.Print(fechaepisodio.ToString)

                                    'Catch ex As Exception
                                    '   editor.escribir(pizarra, "Error en la lectura de los datos de la base de datos ", Color.Red)
                                    '################### JGARIJO 23/10/2019 ######################################
                                    '   EscribirLog(rutaLotes, Now() & " -> " & "ERROR: " & "Error en la lectura de los datos de la base de datos ")
                                    '   EscribirCSV(rutaLotes, "ERROR" & ";" & Now() & ";" & "" & ";" & "" & ";" & "" & ";" & "Error en la lectura de los datos de la base de datos")
                                    '#############################################################################

                                    '  RegistroErrores = RegistroErrores & "ERROR: " & "Error en la lectura de los datos de la base de datos " & Chr(13) & Chr(10)
                                    ' Exit Function
                                    ' End Try


                                    '############################## JGARIJO 23/10/2019 #################################
                                    'Comprobamos si fechadocumento esta en blanco. Si episodio es blanco, la variable se ha inicializado con una barra vertical
                                    ' por lo que no tendrá más longitud de 1




                                    '########################### 14/01/2020 JGARIJO ###########################################

                                    'Dim CadBusquedaSeccion As String = ""
                                    'Dim ValorSeccion As DataTable

                                    'CadBusquedaSeccion = "Select seccion from SERVICIOSHOSPITAL WHERE cod_servicio='" & Trim(documento.Item("cod_servicio")) & "'"

                                    'ValorSeccion = datosSql.ejecutarSQLDirectaTable(CadBusquedaSeccion, cadenaconexionProyecto)

                                    'If ValorSeccion.Rows.Count <= 0 Then
                                    'EscribirLog(rutaLotes, Now() & " -> " & "ERROR: " & "Error no se ha encontrado correspondencia entre codigo servicio " & Trim(documento.Item("cod_servicio")) & " y su seccion en el lote " & idlote)
                                    'EscribirCSV(rutaLotes, "ERROR" & ";" & Now() & ";" & idlote & ";" & "" & ";" & Trim(documento.Item("cod_servicio")) & ";" & "Codigo de servicio sin seccion")
                                    ''#############################################################################
                                    'RegistroErrores = RegistroErrores & "ERROR: " & "Error no se ha encontrado correspondencia entre codigo servicio " & Trim(documento.Item("cod_servicio")) & " y su seccion en el lote " & idlote & Chr(13) & Chr(10)
                                    'area = ""
                                    ''Exit Function
                                    'Else
                                    'area = ValorSeccion.Rows(0).Item(0)
                                    'End If

                                    '##########################################################################################
















                                    fechaepisodio = ""


                                    If Trim(documento.Item("cod_servicio")) = "0" Then
                                        documento.Item("cod_servicio") = ""
                                    End If

                                    If fechadocumento.Trim.Length <= 1 Then
                                        linea = Trim(registro.Item("numhistoria").ToString) & "|" & Trim(sip) & "|" & Trim(nombre) & "|" & Trim(apellido1) & "|" & Trim(apellido2) & "|" & directoriodocumentolinea & "|" & Trim(documento.Item("cod_servicio")) & "|" & Trim(area) & "|" & Trim("6") & "|" & "|" & fechaepisodio & "|" & idlote & "NHC" & Trim(registro.Item("numhistoria").ToString) & "|" & contadorpagina - 1 & "|"
                                        'linea = Trim(registro.Item("numhistoria").ToString) & "|" & Trim(sip) & "|" & Trim(nombre) & "|" & Trim(apellido1) & "|" & Trim(apellido2) & "|" & directoriodocumentolinea & "|" & Trim(codigoServicotxt) & "|" & Trim(area) & "|" & Trim(tipodocumento) & "|" & "|" & fechaepisodio & "|" & idlote & "NHC" & Trim(registro.Item("numhistoria").ToString) & "|" & contadorpagina - 1 & "|"
                                    Else
                                        linea = Trim(registro.Item("numhistoria").ToString) & "|" & Trim(sip) & "|" & Trim(nombre) & "|" & Trim(apellido1) & "|" & Trim(apellido2) & "|" & directoriodocumentolinea & "|" & Trim(documento.Item("cod_servicio")) & "|" & Trim(area) & "|" & Trim("6") & "|" & "|" & fechaepisodio & "|" & idlote & "NHC" & Trim(registro.Item("numhistoria").ToString) & "|" & contadorpagina - 1 & fechadocumento
                                        'linea = Trim(registro.Item("numhistoria").ToString) & "|" & Trim(sip) & "|" & Trim(nombre) & "|" & Trim(apellido1) & "|" & Trim(apellido2) & "|" & directoriodocumentolinea & "|" & Trim(codigoServicotxt) & "|" & Trim(area) & "|" & Trim(tipodocumento) & "|" & "|" & fechaepisodio & "|" & idlote & "NHC" & Trim(registro.Item("numhistoria").ToString) & "|" & contadorpagina - 1 & fechadocumento
                                    End If



                                    '######################### FIN DE LA MODIFICACION 23/10/2019 ######################


                                    Debug.Print(linea)
                                    editor.escribir(blocdenotas, linea)

                                    '################### JGARIJO 23/10/2019 ######################################
                                    EscribirLog(rutaLotes, Now() & " -> " & "Linea introducida: " & linea)
                                    '#############################################################################


                                    codigoServicotxt = ""
                                    directoriodocumentolinea = ""
                                    area = ""
                                    tipodocumento = ""
                                    episodio = ""
                                    fechaepisodio = "01/01/1900"
                                    fechadocumento = ""

                                    contadorDocumentos += 1
                                Next 'fin del recorrido por los documentos
























                                '***************************************************************************
                                ' Fin procesar Historia completa
                                '***************************************************************************

                            Else
                                '***************************************************************************
                                '********* PROCESAMOS EL DIARIO *********
                                '***************************************************************************
                                strSQLdatosagrupaciondocumento = "SELECT TipoDocumento, CodServicioPAED, NumIcu, FechaInicio " _
                                & " FROM DOCUMENTOS " _
                                & " WHERE ((eliminada <> 1) OR " _
                                & " (eliminada IS NULL)) and idlote = " & idlote & " and   numhistoria = " & registro.Item("numhistoria") & " " _
                                & " GROUP BY TipoDocumento, CodServicioPAED, NumIcu, FechaInicio"

                                Debug.Print(strSQLdatosagrupaciondocumento)
                                datosAgrupacionDocumento = datosSql.ejecutarSQLDirectaTable(strSQLdatosagrupaciondocumento, cadenaconexionProyecto)


                                '################### JGARIJO 23/10/2019 ######################################
                                EscribirLog(rutaLotes, Now() & " -> " & "Select ejecutada: " & strSQLdatosagrupaciondocumento)
                                '#############################################################################


                                numerodocumentosconsulta = datosAgrupacionDocumento.Rows.Count

                                'EN ESTE NIVEL ESTAMOS TRABAJANDO A NIVEL DE DOCUMENTO AGRUPADO DENTRO DE UNA HISTORIA 
                                'para cada uno de los servicios que tenemos en este caso el criterio es este, 
                                'vamos a buscar los documentos que forman un documento dentro de una historia

                                For Each documento As DataRow In datosAgrupacionDocumento.Rows
                                    strSQLpaginasdocumentos = " select pagina,nomarchivotif from documentos " _
                                    & " where idlote = " & idlote & " " _
                                    & " and numhistoria = " & registro.Item("numhistoria") & "" _
                                    & " and TipoDocumento  = " & documento.Item("TipoDocumento") & "" _
                                    & " and numicu  = " & documento.Item("numicu") & "" _
                                    & " and fechainicio = '" & documento.Item("fechainicio") & "' " _
                                    & " and codserviciopaed  = " & documento.Item("codserviciopaed") & "" _
                                    & " and ((eliminada =0)) order by pagina"
                                    'Sustituir esta línea por la anterior para que no se exporten las carátulas
                                    '& " and ((eliminada =1) OR (barcodedet <> 1) or (barcodedet is null)) order by pagina"

                                    Debug.Print(strSQLpaginasdocumentos)

                                    '################### JGARIJO 23/10/2019 ######################################
                                    EscribirLog(rutaLotes, Now() & " -> " & "Select ejecutada: " & strSQLpaginasdocumentos)
                                    '#############################################################################


                                    paginasdocumentos = datosSql.ejecutarSQLDirectaTable(strSQLpaginasdocumentos, cadenaconexionProyecto)

                                    Dim datasetDocumentos As New DataSet
                                    Dim tablaDocumentos As DataTable
                                    Dim paginaInicial As Integer = 0
                                    Dim paginafinal As Integer = 1
                                    Dim expresion As String = ""


                                    'directoriodocumento = carpetahistoria & "/DOCUMENTO" & contadorDocumentos
                                    directoriodocumento = carpetahistoria & "\DOCUMENTO" & contadorDocumentos
                                    Debug.Print(directoriodocumento)
                                    editor.escribir(pizarra, "copiando paginas para el DOCUMENTO" & contadorDocumentos)

                                    '################### JGARIJO 23/10/2019 ######################################
                                    EscribirLog(rutaLotes, Now() & " -> " & "copiando paginas para el DOCUMENTO" & contadorDocumentos)
                                    '#############################################################################

                                    Application.DoEvents()


                                    If Not Directory.Exists(directoriodocumento) Then Directory.CreateDirectory(directoriodocumento)


                                    contadorpagina = 1
                                    numeropaginasconsulta = datosAgrupacionDocumento.Rows.Count


                                    'EN ESTE NIVEL ESTAMOS TRABAJANDO A NIVEL DE PAGINA DENTRO DE UN DOCUMENTO DENTRO DE UNA HISTORIA 
                                    Dim strpaginas As String = ""
                                    For Each pagina As DataRow In paginasdocumentos.Rows

                                        nombredelarchivo = pagina.Item("nomarchivotif").ToString
                                        '###########################################################
                                        'rutaimagenes = Replace(rutaimagenes, "\\172.21.100.190", "C:")
                                        '"\\172.21.100.190\gedsa\Digitalizacion\Proyectosdigi\7002\DIGI\700207925\IMAGEN\7925"
                                        'directoriodocumento = Replace(directoriodocumento, "\\172.21.100.190", "\\10.8.0.6")

                                        File.Copy(rutaimagenes & "\" & nombredelarchivo, directoriodocumento & "\" & Format(contadorpagina, "0000000#") & ".TIF", True)
                                        'aqui teneos los nombres de los documentos organizados por paginas esto es lo que se tiene que copiar 
                                        'en la carpeta lote 1 y aqui tenemos que emepezar a poner todos los datos een el fichero txt

                                        '################### JGARIJO 23/10/2019 ######################################
                                        EscribirLog(rutaLotes, Now() & " -> " & "Copiando imagen de " & rutaimagenes & "\" & nombredelarchivo & " a " & directoriodocumento & "\" & Format(contadorpagina, "0000000#") & ".TIF")
                                        '#############################################################################

                                        strpaginas &= "," & pagina.Item("pagina").ToString
                                        contadorpagina += 1
                                    Next

                                    Dim aux As Integer = contadorpagina - 1
                                    totales += aux
                                    editor.escribir(pizarra, "copiadas -> " & aux & " paginas ->" & strpaginas)

                                    '################### JGARIJO 23/10/2019 ######################################
                                    EscribirLog(rutaLotes, Now() & " -> " & "Copiadas -> " & aux & " paginas ->" & strpaginas)
                                    '#############################################################################

                                    posbarra = InStrRev(directoriodocumento, "\")
                                    posbarra = InStrRev(directoriodocumento, "\", posbarra - 1)
                                    'posbarra = InStrRev(directoriodocumento, "\", posbarra - 1)
                                    directoriodocumentolinea = Mid(directoriodocumento, posbarra + 1)

                                    '#####################################################################
                                    directoriodocumentolinea = Replace(directoriodocumentolinea, "\", "/")

                                    Debug.Print(directoriodocumentolinea)
                                    directoriodocumentolinea = idlote & "NHC" & Trim(registro.Item("numhistoria").ToString) & "/" & directoriodocumentolinea
                                    'modificacion para la asignacion del servicio 

                                    Try

                                        If IsDBNull(documento.Item("codserviciopaed")) Then
                                            area = ""
                                            codigoServicotxt = ""
                                        Else
                                            If documento.Item("codserviciopaed") = "0" Or documento.Item("codserviciopaed") = "998" Then
                                                codigoServicotxt = ""
                                                area = ""
                                            Else
                                                'hay que calcular el episodio para el hospital 
                                                codigoServicotxt = documento.Item("codserviciopaed")
                                                Dim tablearea As DataTable = datosSql.ejecutarSQLDirectaTable("SELECT cod_servicio FROM SERVICIOSHOSPITAL WHERE idServicio = " & codigoServicotxt, cadenaconexionProyecto)

                                                '################### JGARIJO 23/10/2019 ######################################
                                                EscribirLog(rutaLotes, Now() & " -> " & "SELECT cod_servicio FROM SERVICIOSHOSPITAL WHERE idServicio = " & codigoServicotxt)
                                                '#############################################################################


                                                '######################### JGARIJO 23/10/2019 #######################                                                                                               
                                                'DOS MODIFICACIONES: MODIFICAMOS EL IF AÑADIENDO EL SIMBOLO IGUAL 
                                                'Y QUITAMOS EL MSGBOX

                                                'If tablearea.Rows.Count < 0 Then
                                                'MessageBox.Show("Error no se ha encontrado correspondencia tipo documento para historia " & registro.Item("numhistoria").ToString)

                                                If tablearea.Rows.Count <= 0 Then
                                                    editor.escribir(pizarra, "ERROR: Error no se ha encontrado correspondencia codigo servicio para historia " & registro.Item("numhistoria").ToString & " en el lote " & idlote)
                                                    '################### JGARIJO 23/10/2019 ######################################
                                                    EscribirLog(rutaLotes, Now() & " -> " & "ERROR: Error no se ha encontrado correspondencia Codigo Servicio " & codigoServicotxt & " para historia " & registro.Item("numhistoria").ToString & " en el lote " & idlote)

                                                    EscribirCSV(rutaLotes, "ERROR" & ";" & Now() & ";" & idlote & ";" & registro.Item("numhistoria").ToString & ";" & codigoServicotxt & ";" & "Codigo de servicio erroneo")

                                                    '#############################################################################
                                                    RegistroErrores = RegistroErrores & "ERROR: Error no se ha encontrado correspondencia Codigo Servicio " & codigoServicotxt & " para historia " & registro.Item("numhistoria").ToString & Chr(13) & Chr(10)
                                                    Exit Function
                                                Else
                                                    codigoServicotxt = tablearea.Rows(0).Item(0)
                                                End If

                                                ' ########################## FIN DE LA MODIFICACION ################
                                            End If
                                        End If

                                        Debug.Print("codigo servicio ")

                                        If IsDBNull(documento.Item("Tipodocumento")) Then
                                            tipodocumento = ""
                                        Else
                                            If documento.Item("Tipodocumento") = "0" Or documento.Item("Tipodocumento") = "998" Then
                                                tipodocumento = ""
                                            Else
                                                'hay que calcular el tipo de documeno para el hospital 
                                                tipodocumento = documento.Item("Tipodocumento")

                                                Dim tipodocumentobd As DataTable
                                                tipodocumentobd = datosSql.ejecutarSQLDirectaTable("select idtipodocumentohosopital from correspondenciatiposdocumentos where idtipodocumento = " & tipodocumento, cadenaconexionProyecto)

                                                '################### JGARIJO 23/10/2019 ######################################
                                                EscribirLog(rutaLotes, Now() & " -> " & "select idtipodocumentohosopital from correspondenciatiposdocumentos where idtipodocumento = " & tipodocumento)
                                                '#############################################################################

                                                '########################## JGARIJO 23/10/2019 #########################
                                                'DOS MODIFICACIONES: AÑADIMOS SIMBOLO = AL IF Y CAMBIAMOS EL MSGBOX
                                                'If tipodocumentobd.Rows.Count < 0 Then
                                                'MessageBox.Show("Error no se ha encontrado correspondencia tipo documento para historia " & registro.Item("numhistoria").ToString)
                                                If tipodocumentobd.Rows.Count <= 0 Then


                                                    editor.escribir(pizarra, "ERROR: Error no se ha encontrado correspondencia Tipo Documento para historia " & registro.Item("numhistoria").ToString & " en el lote " & idlote)
                                                    '################### JGARIJO 23/10/2019 ######################################
                                                    EscribirLog(rutaLotes, Now() & " -> " & "ERROR: Error no se ha encontrado correspondencia Tipo Documento " & tipodocumento & " para historia " & registro.Item("numhistoria").ToString & " en el lote " & idlote)

                                                    EscribirCSV(rutaLotes, "ERROR" & ";" & Now() & ";" & idlote & ";" & registro.Item("numhistoria").ToString & ";" & tipodocumento & ";" & "Tipo de Documento erroneo")

                                                    '#############################################################################
                                                    RegistroErrores = RegistroErrores & "ERROR: Error no se ha encontrado correspondencia tipo documento " & tipodocumento & " para historia " & registro.Item("numhistoria").ToString + Chr(13) + Chr(10)
                                                    Exit Function

                                                Else
                                                    tipodocumento = tipodocumentobd.Rows(0).Item(0)
                                                End If
                                                '############################### FIN DE LA MODIFICACION ################
                                            End If
                                        End If


                                        Debug.Print("Tipo documento ")


                                        If IsDBNull(documento.Item("numicu")) Then
                                            episodio = ""
                                        Else
                                            If documento.Item("numicu") = "998" Then
                                                episodio = ""
                                            Else
                                                episodio = documento.Item("numicu")
                                            End If

                                        End If

                                        Debug.Print("episodio")


                                        If IsDBNull(documento.Item("fechainicio")) Then
                                            fechaepisodio = ""
                                        Else
                                            If documento.Item("fechainicio") = "01/01/1900" Then
                                                fechaepisodio = ""
                                            Else
                                                fechaepisodio = documento.Item("fechainicio")
                                            End If
                                        End If

                                        If episodio = "" Then
                                            fechadocumento = "|" & fechaepisodio
                                            fechaepisodio = ""
                                        End If

                                        Debug.Print(fechaepisodio.ToString)

                                    Catch ex As Exception
                                        editor.escribir(pizarra, "Error en la lectura de los datos de la base de datos ", Color.Red)
                                        '################### JGARIJO 23/10/2019 ######################################
                                        EscribirLog(rutaLotes, Now() & " -> " & "Error en la lectura de los datos de la base de datos ")
                                        '#############################################################################
                                        EscribirCSV(rutaLotes, "ERROR" & ";" & Now() & ";" & "" & ";" & "" & ";" & "" & ";" & "Error en la lectura de la base de datos")


                                        RegistroErrores = RegistroErrores & "ERROR: Error en la lectura de los datos de la base de datos " & Chr(13) + Chr(10)
                                        Exit Function
                                    End Try


                                    '############################## JGARIJO 23/10/2019 #################################
                                    'Comprobamos si fechadocumento esta en blanco. Si episodio es blanco, la variable se ha inicializado con una barra vertical
                                    ' por lo que no tendrá más longitud de 1

                                    If fechadocumento.Trim.Length <= 1 Then
                                        linea = Trim(registro.Item("numhistoria").ToString) & "|" & Trim(sip) & "|" & Trim(nombre) & "|" & Trim(apellido1) & "|" & Trim(apellido2) & "|" & directoriodocumentolinea & "|" & Trim(codigoServicotxt) & "|" & Trim(area) & "|" & Trim(tipodocumento) & "|" & "|" & fechaepisodio & "|" & idlote & "NHC" & Trim(registro.Item("numhistoria").ToString) & "|" & contadorpagina - 1 & "|"
                                    Else
                                        linea = Trim(registro.Item("numhistoria").ToString) & "|" & Trim(sip) & "|" & Trim(nombre) & "|" & Trim(apellido1) & "|" & Trim(apellido2) & "|" & directoriodocumentolinea & "|" & Trim(codigoServicotxt) & "|" & Trim(area) & "|" & Trim(tipodocumento) & "|" & "|" & fechaepisodio & "|" & idlote & "NHC" & Trim(registro.Item("numhistoria").ToString) & "|" & contadorpagina - 1 & fechadocumento
                                    End If

                                    '######################### FIN DE LA MODIFICACION 23/10/2019 ######################

                                    Debug.Print(linea)
                                    editor.escribir(blocdenotas, linea)

                                    '################### JGARIJO 23/10/2019 ######################################
                                    EscribirLog(rutaLotes, Now() & " -> " & "Linea insertada: " & linea)
                                    '#############################################################################

                                    codigoServicotxt = ""
                                    directoriodocumentolinea = ""
                                    area = ""
                                    tipodocumento = ""
                                    episodio = ""
                                    fechaepisodio = "01/01/1900"
                                    fechadocumento = ""

                                    contadorDocumentos += 1
                                Next 'fin del recorrido por los documentos 

                                '***************************************************************************
                                ' Fin procesar Historia completa
                                '***************************************************************************

                            End If


                            'aqui es donde podemos hacer la separacion de los ficheros por  historia 
                            rutaguradarFichero = rutaLotes & Path.DirectorySeparatorChar & "lotes" & Path.DirectorySeparatorChar & "lote" & idlote & "\" & idlote & "NHC" & registro.Item("numhistoria") & ".TXT"
                            Debug.Print(rutaguradarFichero)

                            '#############################################
                            'rutaguradarFichero = Replace(rutaguradarFichero, "\\10.1.0.108", "c:")

                            Try
                                If File.Exists(rutaguradarFichero) Then File.Delete(rutaguradarFichero)
                                blocdenotas.SaveFile(rutaguradarFichero, RichTextBoxStreamType.PlainText)
                                blocdenotas.Clear()
                            Catch ex As Exception
                                editor.escribir(pizarra, "Error al crear el fichero txt msgerr: " & ex.ToString)

                                '################### JGARIJO 23/10/2019 ######################################
                                EscribirLog(rutaLotes, Now() & " -> " & "ERROR: No se ha podido crear el fichero " & rutaguradarFichero & " con error " & ex.ToString)
                                EscribirCSV(rutaLotes, "ERROR" & ";" & Now() & ";" & "" & ";" & "" & ";" & "" & ";" & "No se ha podido crear el fichero " & rutaguradarFichero & " con error " & ex.ToString)
                                RegistroErrores = RegistroErrores & "ERROR: No se ha podido crear el fichero " & rutaguradarFichero & " con error " & ex.ToString & Chr(13) & Chr(10)

                                '#############################################################################

                                Return 0
                            End Try

                        Next ' fin del recorrido por las historias 


                    Else
                        '################## JGARIJO 23/10/2019 #########################
                        'ELIMINAMOS EL MSGBOX PARA QUE NO PARE LA EJECUCION
                        'MessageBox.Show("No se han encontrado historias para este lote")
                        editor.escribir(pizarra, "ERROR: No se han encontrado historias para este lote")

                        '################### JGARIJO 23/10/2019 ######################################
                        EscribirLog(rutaLotes, Now() & " -> " & "ERROR: No se han encontrado historias para el lote " & idlote)
                        EscribirCSV(rutaLotes, "ERROR" & ";" & Now() & ";" & idlote & ";" & "" & ";" & "" & ";" & "No se han encontrado historias para este lote")
                        '#############################################################################
                        RegistroErrores = RegistroErrores & "ERROR: No se han encontrado historias para el lote " & idlote & Chr(13) & Chr(10)

                        Return 0
                    End If

                    editor.escribir(pizarra, "Se han copiado correctamente " & totales & "paginas")
                    Debug.Print(numerohistoriasconsulta)
                    Debug.Print(numerodocumentosconsulta)
                    Debug.Print(numeropaginasconsulta)
                    '################### JGARIJO 23/10/2019 ######################################
                    EscribirLog(rutaLotes, Now() & " -> " & "OK: Se han copiado correctamente " & totales & " paginas. Historias: " & numerohistoriasconsulta & ", Documentos consulta: " & numerodocumentosconsulta & " y Paginas consulta: " & numeropaginasconsulta)
                    '#############################################################################

                    Return 1

                Catch ex As Exception
                    editor.escribir(pizarra, "Error no se ha podido exportar el lote " & idlote, Color.Red, 10)
                    '################### JGARIJO 23/10/2019 ######################################
                    EscribirLog(rutaLotes, Now() & " -> " & "ERROR: Error indeterminado. No se ha podido exportar el lote " & idlote & ". Descripción del error: " & Err.Description)
                    EscribirCSV(rutaLotes, "ERROR" & ";" & Now() & ";" & idlote & ";" & "" & ";" & "" & ";" & "Error indeterminado. No se ha podido exportar el lote " & idlote & ". Descripción del error: " & Err.Description)

                    RegistroErrores = RegistroErrores & "ERROR: Error no se ha podido exportar el lote " & idlote & Chr(13) & Chr(10)

                    '#############################################################################

                    Return 0
                End Try

            End Function


            Private Shared Function exportarDocumentos(ByVal idlote As String, ByVal idproyecto As String, ByVal cadenaConexionMdb As String, ByVal cadenaconexionproyecto As String, ByRef traza As String) As Integer


                Dim strMdb As String
                Dim dtDocs As DataTable = New DataTable()

                Dim proyecto, nomArchivoDat, origenDocumento As String
                Dim fechaInicio, fechaTermino As DateTime
                Dim id, codigoLote, pagina, inicioDevice, sizeDevice, _
                    tipoDocumento, codServicioPaed, codServicioIcu, codServicioUbicado, _
                    tipoEpisodioPaed, tipoEpisodioIcu, tipoEpisodioUbicado, _
                    numHistoria, vinculada, pagVinculada, barcodeDet, incidencia, _
                    documentoSinFechas, documentoMalEstado As Integer
                Dim nomArchivoTif, numIcu As String

                Try

                    ' Seleccionamos los documentos pertenecientes al proyecto y lote actuales
                    dtDocs = datosSql.ObtenerListadoParaValorParametro("documentos,lotes", "IdDocumento,NomArchivoTIF, documentos.idlote, pagina, tipoDocumento, numicu, numHistoria", _
                                      "documentos.idlote", idlote, cadenaconexionproyecto, "lotes.idlote", idlote, "pagina")

                    'si no se encuentran documentos 
                    If dtDocs.Rows.Count < 1 Then
                        traza = "Error no se han encontrado documentos para importar en la tabla documentos para este lote."
                        Return 0
                    End If

                    For Each doc As DataRow In dtDocs.Rows

                        ' Comprobamos cada campo para exportar
                        proyecto = idproyecto
                        codigoLote = idlote
                        origenDocumento = "PROPIO HOSPITAL"

                        id = doc("idDocumento")
                        pagina = doc("pagina")
                        'inicioDevice = doc("inicioDevice")
                        'sizeDevice = doc("sizeDevice")
                        'nomArchivoDat = doc("nomArchivoDat")
                        nomArchivoTif = doc("NomArchivoTIF")

                        tipoDocumento = doc("tipoDocumento")
                        'codServicioPaed = IIf(doc("codServicioPaed") Is DBNull.Value, 0, doc("CodServicioPaed"))
                        'tipoEpisodioPaed = IIf(doc("tipoEpisodioPaed") Is DBNull.Value, 0, doc("tipoEpisodioPaed"))

                        'conversion de los codigos a los codigos del hospital en cuestion 
                        'tipoDocumento = datosSql.ejecutarSQLDirectaDataRow("SELECT idtipodocumentohospital FROM correspondenciaTiposDocumentos WHERE idtipodocumento= " & doc("tipoDocumento"), cadenaconexionproyecto).Item("idtipodocumentohospital")
                        'codServicioPaed = datosSql.ejecutarSQLDirectaDataRow("SELECT idservicioServicioCliente FROM correspondenciaservicios WHERE idservicio = " & doc("codServicioPaed"), cadenaconexionproyecto).Item("idservicioServicioCliente")
                        'tipoEpisodioPaed = datosSql.ejecutarSQLDirectaDataRow("SELECT idTipoEpisodioHospital FROM correspondenciatipoepisodios WHERE idservicio = " & doc("tipoEpisodioPaed"), cadenaconexionproyecto).Item("idTipoEpisodioHospital")
                        ''fin de la conversion de los codigos 

                        numIcu = IIf(doc("numIcu") Is DBNull.Value, "0", doc("numIcu"))



                        'fechaInicio = IIf(doc("fechaInicio") Is DBNull.Value, DateTime.MinValue, doc("fechaInicio"))
                        'fechaTermino = IIf(doc("fechaTermino") Is DBNull.Value, DateTime.MinValue, doc("fechaTermino"))


                        numHistoria = doc("numHistoria")
                        'vinculada = IIf(doc("vinculada") Is DBNull.Value, 0, doc("vinculada"))
                        'pagVinculada = IIf(doc("pagVinculada") Is DBNull.Value, 0, doc("pagVinculada"))
                        'barcodeDet = IIf(doc("barcodeDet") Is DBNull.Value, 0, doc("barcodeDet"))
                        'incidencia = IIf(doc("incidencia") Is DBNull.Value, 0, doc("incidencia"))
                        'documentoSinFechas = IIf(doc("documentoSinFechas") Is DBNull.Value, 0, doc("documentoSinFechas"))
                        'documentoMalEstado = IIf(doc("documentoMalEstado") Is DBNull.Value, 0, doc("documentoMalEstado"))


                        ' insertamos los datos correspondientes a los registros de la tabla documentos
                        'strMdb = "INSERT INTO documentos(id, " _
                        '         & " id_lote, pagina, nomArchivoDat, " _
                        '         & "inicioDevice, sizeDevice, tipoDocumento, " _
                        '         & "fechaInicio, fechaTermino, codServicioPaed, codServicioIcu, " _
                        '         & "codServicioUbicado, tipoEpisodioPaed, " _
                        '         & "tipoEpisodioIcu, tipoEpisodioUbicado, numicu, " _
                        '         & "numHistoria, vinculada, pagVinculada, barCodeDet, incidencia, " _
                        '         & "documentoSinFechas, documentoMalEstado,NomArchivoTIF) VALUES (" & id & "," _
                        '         & pagina & ", " & pagina & ", '" _
                        '         & nomArchivoDat & "', " & inicioDevice & ", " & sizeDevice & ", " _
                        '         & tipoDocumento & ", '" & fechaInicio & "', '" _
                        '         & fechaTermino & "', " & codServicioPaed & ", " & codServicioIcu & ", " _
                        '         & codServicioUbicado & ", " _
                        '         & tipoEpisodioPaed & ", " & tipoEpisodioIcu & ", " & tipoEpisodioUbicado & ", '" _
                        '         & numIcu & "'," & numHistoria & ", " & vinculada & ", " _
                        '         & pagVinculada & ", " & barcodeDet & ", " & incidencia & ", " _
                        '         & documentoSinFechas & ", " & documentoMalEstado & ",'" & nomArchivoTif & "')"


                        'insertamos los datos correspondientes a los registros de la tabla documentos
                        strMdb = "INSERT INTO documentos (id, " _
                                 & " id_lote, pagina, " _
                                 & "tipoDocumento, " _
                                 & "numicu,numHistoria, vinculada, pagVinculada, barCodeDet," _
                                 & "NomArchivoTIF) VALUES (" & id & "," _
                                 & pagina & ", " & pagina & ", '" _
                                 & tipoDocumento & "','" _
                                 & numIcu & "'," & numHistoria & ", " & vinculada & ", " _
                                 & pagVinculada & ", " & barcodeDet & ", '" _
                                 & nomArchivoTif & "')"


                        Debug.Print(strMdb)

                        ' Ejecutamos la consulta
                        datosMdb.ejecutarSQLDirecta(strMdb, cadenaConexionMdb)



                        Application.DoEvents()

                    Next

                    'actualizamos los valores de proyeco e identificador de lote 
                    If datosMdb.ejecutarSQL("UPDATE documentos SET proyecto = " & idproyecto & ",codigolote = " & idlote, cadenaConexionMdb) = 0 Then
                        traza = "Error al actulizar los campos idproyeco y codigo lote en la base de datos "
                        Return 0
                    End If

                    Return 1

                Catch ex As Exception

                    traza = "Error al insertar la pagina nº" & pagina & " mensaje del error " & ex.Message
                    Return 0
                End Try

            End Function


            Private Shared Function exportarEpisodios(ByVal idlote As String, ByVal idproyecto As String, ByVal cadenaConexionMdb As String, ByVal cadenaconexionProyecto As String, ByRef traza As String) As Integer

                Dim dtNumIcus As DataTable = New DataTable()
                Dim dtEpis As DataTable = New DataTable()
                Dim strMdb As String
                Dim i As Integer = 0

                Dim nhc, numicu As Integer

                Try

                    ' Obtenemos los códigos de los episodios a exportar
                    dtNumIcus = datosSql.ObtenerListadoParaValorParametro("Documentos", "DISTINCT numicu, numHistoria", "idlote", idlote, cadenaconexionProyecto)

                    For Each filaNumIcu As DataRow In dtNumIcus.Rows

                        nhc = IIf(filaNumIcu.Item("numhistoria") Is DBNull.Value, 0, filaNumIcu.Item("numhistoria"))
                        numicu = IIf(filaNumIcu.Item("numicu") Is DBNull.Value, 999, filaNumIcu.Item("numicu"))

                        ' Montamos la consulta de inserción
                        strMdb = "INSERT INTO Episodios( NHC, numIcu) VALUES("
                        strMdb &= nhc & ", " & numicu & ")"

                        ' Ejecutamos la consulta
                        If datosMdb.ejecutarSQL(strMdb, cadenaConexionMdb) = 0 Then
                            Return 0
                        End If
                        Application.DoEvents()

                    Next

                    Return 1

                Catch ex As Exception
                    traza = "Error al insertar episodio " & numicu & " mensaje del error " & ex.Message
                    Return 0
                End Try


            End Function


            Private Shared Function exportarPacientes(ByVal idproyecto As Integer, ByVal idlote As Integer, ByVal nombreTablaFIP As String, ByVal cadenaConexionMdb As String, ByVal cadenaConexion As String, ByRef traza As String) As Integer

                Dim dtNumHistorias As DataTable = New DataTable()
                Dim dtHistorias As DataTable = New DataTable()
                Dim strMdb As String
                Dim i As Integer = 0

                Dim hospital, numHistoria As Integer
                Dim nombre, apellido1, apellido2, sexo, dni, sip, nombreCompleto As String
                Dim fechaNacimiento As DateTime

                Try


                    dtNumHistorias = datosSql.ObtenerListadoParaValorParametro("Documentos", "DISTINCT numHistoria", "idLote", "'" & idlote & "'", cadenaConexion)

                    For Each filaNumHistoria As DataRow In dtNumHistorias.Rows

                        dtHistorias = datosSql.ObtenerListadoParaValorParametro(nombreTablaFIP, "numhistoria, nombre, apellido1, apellido2, dni", "numhistoria", filaNumHistoria("numhistoria"), cadenaConexion)

                        If dtHistorias.Rows.Count > 0 Then

                            hospital = 6909
                            numHistoria = IIf(dtHistorias.Rows(0)("numHistoria") Is DBNull.Value, 0, dtHistorias.Rows(0)("numHistoria"))

                            nombre = IIf(dtHistorias.Rows(0)("nombre") Is DBNull.Value, "", Trim(dtHistorias.Rows(0)("nombre")))
                            apellido1 = IIf(dtHistorias.Rows(0)("apellido1") Is DBNull.Value, "", Trim(dtHistorias.Rows(0)("apellido1")))
                            apellido2 = IIf(dtHistorias.Rows(0)("apellido2") Is DBNull.Value, "", Trim(dtHistorias.Rows(0)("apellido2")))
                            sexo = 0
                            dni = IIf(dtHistorias.Rows(0)("dni") Is DBNull.Value, "", Trim(dtHistorias.Rows(0)("dni")))
                            sip = 0
                            nombreCompleto = nombre & " " & apellido1 & " " & apellido2
                            fechaNacimiento = DateTime.MinValue

                            ' Montamos la consulta de inserción
                            strMdb = "INSERT INTO fip(hospital, numhistoria, nombre, apellido1, apellido2, sexo, fechaNacimiento, dni, sip, nombreCompleto) VALUES("
                            strMdb &= hospital & ", " & numHistoria & ", '" & nombre & "', '" & apellido1 & "', '" & apellido2 & "', '"
                            strMdb &= sexo & "', '" & fechaNacimiento & "', '" & dni & "', '" & sip & "', '" & nombreCompleto & "')"

                            Debug.Print(strMdb)

                            If datosMdb.ejecutarSQL(strMdb, cadenaConexionMdb) = 0 Then
                                Return 0
                            End If
                        Else
                            'no se ha encontrado la historia en la tabla FIP esto hay que solucinarlo pq sino tenemos un error 

                            Try
                                numHistoria = IIf(filaNumHistoria("numhistoria") Is DBNull.Value, 0, filaNumHistoria("numhistoria").ToString)

                            Catch ex As Exception
                                traza = ex.ToString
                            End Try

                            traza = "La historia " & numHistoria & " no tienen un registro en la tabla FIP, por lo que este lote no se va a poder procesar."
                            Return 0
                        End If

                        i += 1

                        'MessageBox.Show(". Importando historias: " & i & " de " & dtNumHistorias.Rows.Count & " importadas.")

                        Application.DoEvents()

                    Next

                    Return 1
                Catch ex As Exception
                    traza = "Error al insertar la pagina FIP,  mensaje del error " & ex.Message
                    Return 0

                End Try

            End Function



            Private Shared Function obtenerDatosConfiguracionTraspaso(ByRef rutatraspasolote As String, ByRef rutaImagenes As String, ByRef nomBaseDatosMDB As String, ByRef contraseña As String, ByRef rutaPlantillaExportaciones As String, ByVal idlote As String, ByVal codigoProyecto As String, ByVal cadenaconexionAdministracion As String, ByRef pizarra As RichTextBox) As Boolean

                Dim datosConfiguracionLotes As DataRow

                Try


                    'obtenemos los datos de configuracion del proyecto 
                    datosConfiguracionLotes = datosSql.ObtenerListadoParaListaValoresParametrosLiteral("configuracionproyecto as conf,proyectos as pro", "conf.rutaimagenes,conf.contraseña,conf.rutaplantillaexportacion,pro.abreviatura,conf.Rutalotes", " pro.idproyecto = conf.idproyecto AND pro.idProyecto='" & codigoProyecto & "'", cadenaconexionAdministracion).Rows(0)

                    'Obtenemos la rua donde vamos a copiar las imagenes del lote y la base de datos Access 
                    If Not IsDBNull(datosConfiguracionLotes.Item("RutaLotes").ToString()) And Not IsDBNull(datosConfiguracionLotes.Item("rutaplantillaexportacion").ToString) Then
                        rutatraspasolote = datosConfiguracionLotes.Item("RutaLotes").ToString() & "\Lotes\Lote" & idlote & "\"
                        rutaPlantillaExportaciones = datosConfiguracionLotes.Item("rutaplantillaexportacion").ToString
                        contraseña = datosConfiguracionLotes.Item("contraseña").ToString
                        If Not Directory.Exists(rutatraspasolote) Then Directory.CreateDirectory(rutatraspasolote)
                    Else

                        editor.escribir(pizarra, "El proyecto no tiene configurada una ruta donde hacer el trasapaso de los datos, los lotes no se podrán traspasar", Color.Red)
                        Return False

                    End If

                    'obtenemos la ruta de las imagenes a insertar en el dat
                    rutaImagenes = datosConfiguracionLotes.Item("RutaImagenes").ToString & Path.DirectorySeparatorChar & datosConfiguracionLotes.Item("abreviatura").ToString & "\DIGI\" & datosConfiguracionLotes.Item("abreviatura").ToString & Format(Val(idlote), "0000#") & "\IMAGEN\" & idlote
                    'calculamos el nombre de la base de datos 
                    nomBaseDatosMDB = datosConfiguracionLotes.Item("abreviatura").ToString & Format(Val(idlote), "00000#") & ".mdb"


                    editor.centrado(pizarra, "Proceso de traspaso del lote " & idlote)
                    editor.escribir(pizarra, "rutaTraspasolote: " & rutatraspasolote)
                    editor.escribir(pizarra, "rutaImagenes: " & rutaImagenes)
                    editor.escribir(pizarra, "nomBaseDatosMDB: " & nomBaseDatosMDB)
                    editor.escribir(pizarra, "rutaPlantillaExportacion: " & rutaPlantillaExportaciones)


                    Return True

                Catch ex As Exception
                    editor.escribir(pizarra, ex.Message.ToString, Color.Red)
                    Return False
                End Try

            End Function
            Public Shared Function EscribirLog(ByVal rutalog As String, ByVal texto As String) As Boolean
                '############################# JGARIJO ##################################
                ' Esta function se encarga de escribir el texto que recibe por parametro en un fichero txt en el directorio que recibe por parametro
                Try
                    Dim fitxero As System.IO.StreamWriter
                    fitxero = My.Computer.FileSystem.OpenTextFileWriter(rutalog & "\LOG_EJECUCION_enpruebas_" & Replace(Today(), "/", "-") & ".txt", True)
                    fitxero.WriteLine(texto)
                    fitxero.Close()
                    Return True
                Catch ex As Exception
                    Return False
                End Try


            End Function
            Public Shared Function EscribirCSV(ByVal rutalog As String, ByVal texto As String) As Boolean
                '############################# JGARIJO ##################################
                ' Esta function se encarga de escribir el texto que recibe por parametro en un fichero CSV en el directorio que recibe por parametro
                Try
                    Dim fitxero As System.IO.StreamWriter
                    fitxero = My.Computer.FileSystem.OpenTextFileWriter(rutalog & "\LOG_EJECUCION_enpruebas_" & Replace(Today(), "/", "-") & ".csv", True)
                    fitxero.WriteLine(texto)
                    fitxero.Close()
                    Return True
                Catch ex As Exception
                    Return False
                End Try


            End Function













        End Class

    End Namespace

End Namespace

