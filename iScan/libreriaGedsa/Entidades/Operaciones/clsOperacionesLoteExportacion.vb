Imports LibreriaCadenaProduccion.Entidades
Imports System.Data.SqlClient
Imports System.IO
Imports JRO
Imports System.Windows.Forms
Imports datosSql = LibreriaCadenaProduccion.Datos.GeneralSQL.clsAccesoDatosSQL
Imports datosMdb = LibreriaCadenaProduccion.Datos.GeneralAccess.ClsAccesoDatosAccess
Imports datosLote = LibreriaCadenaProduccion.Datos.Produccion.cadenaproduccion.clsAccesoDatosLote
Imports editor = LibreriaCadenaProduccion.TXT.clsFormato
Imports datosORA = LibreriaCadenaProduccion.Datos.GeneralOracle.clsAccesoDatosOracle






Namespace Entidades

    Namespace Operaciones

        Public Class clsOperacionesLoteExportacion



            Private Class ClsHistoriaImp

                Dim idlote As Integer
                Dim numhistoria As String
                Dim codigo_cliente As Integer
                Dim documentosHistoria As New Collection
                Dim tipo_historia As Integer
                Dim estado_historia As Integer
                Dim coleccion_historia As Integer


                Public Property _tipo_historia() As Integer
                    Get
                        Return Me.tipo_historia
                    End Get
                    Set(ByVal value As Integer)
                        Me.tipo_historia = value
                    End Set
                End Property


                Public Property _estado_historia() As Integer
                    Get
                        Return Me.estado_historia
                    End Get
                    Set(ByVal value As Integer)
                        Me.estado_historia = value
                    End Set
                End Property


                Public Property _coleccion_historia() As Integer
                    Get
                        Return Me.coleccion_historia
                    End Get
                    Set(ByVal value As Integer)
                        Me.coleccion_historia = value
                    End Set
                End Property
                Public Sub New(ByVal idlote As Integer, ByVal numhistoria As String)
                    Me.idlote = idlote
                    Me.numhistoria = numhistoria
                End Sub


                Property _ColeccionDocumentosHistoria() As Collection
                    Get
                        Return Me.documentosHistoria
                    End Get
                    Set(ByVal value As Collection)
                        Me.documentosHistoria = value
                    End Set

                End Property


                Property _numhistoria() As Integer
                    Get
                        Return Me.numhistoria
                    End Get
                    Set(ByVal value As Integer)
                        Me.numhistoria = value
                    End Set
                End Property

                Property _idlote() As Integer
                    Get
                        Return Me.idlote
                    End Get
                    Set(ByVal value As Integer)
                        Me.idlote = value
                    End Set
                End Property

                Property _codigo_cliente() As Integer
                    Get
                        Return Me.codigo_cliente
                    End Get
                    Set(ByVal value As Integer)
                        Me.codigo_cliente = value
                    End Set
                End Property

            End Class

            Private Class ClsDocumentoImp

                Public Sub New(ByVal idlote As Integer, ByVal codigo_servicio As Integer, ByVal numhistoria As String, ByVal fechadocumento As String, ByVal fechatermino As String, ByVal episodio As Integer)

                    Me.codigo_servicio = codigo_servicio
                    Me.fechadocumento = fechadocumento
                    Me.numicu = episodio
                End Sub

                Public Sub New()

                End Sub


                Dim codigo_servicio As Integer
                Dim fechadocumento As String
                Dim fechatermino As String
                Dim numicu As Integer
                Dim episodio As Integer
                Dim tipoDocumento As Integer
                Dim nombreFichero As String


                Property _tipoDocumento() As Integer
                    Get
                        Return tipoDocumento
                    End Get
                    Set(ByVal value As Integer)
                        Me.tipoDocumento = value
                    End Set
                End Property


                Property _ICU() As String
                    Get
                        Return Me.numicu
                    End Get
                    Set(ByVal value As String)
                        Me.numicu = value
                    End Set
                End Property

                Property _Episodio() As String
                    Get
                        Return Me.episodio
                    End Get
                    Set(ByVal value As String)
                        Me.episodio = value
                    End Set
                End Property

                Property _fecdocu() As String
                    Get
                        Return Me.fechadocumento
                    End Get
                    Set(ByVal value As String)
                        Me.fechadocumento = value
                    End Set
                End Property


                Property _fechatermino() As String
                    Get
                        Return Me.fechatermino
                    End Get
                    Set(ByVal value As String)
                        Me.fechatermino = value
                    End Set
                End Property


                Property _codigo_servicio() As Integer
                    Get
                        Return codigo_servicio
                    End Get
                    Set(ByVal value As Integer)
                        codigo_servicio = value
                    End Set
                End Property

                Property _nombreFichero() As String
                    Get
                        Return Me.nombreFichero
                    End Get
                    Set(ByVal value As String)
                        Me.nombreFichero = value
                    End Set
                End Property

            End Class


            Public Shared Function exportarDatosLote(ByVal idlote As String, ByVal idproyecto As String, ByVal cadenaconexionAdministrativos As String, ByVal cadenaconexionProyecto As String, ByVal cadenaconxionHospital As String, ByVal rutaRepositorioHospital As String, ByRef pizarra As RichTextBox, ByRef pgbDocumentos As ProgressBar, ByRef visor As AxImgeditLibCtl.AxImgEdit) As Integer


                Dim rutaPlantillaMdb As String          'ruta de la mdb donde vamos a copiar los datos 
                Dim carpetaDestinoLote As String        'carpeta donde esta el lote (DAT + mdb), las imagenes estan en otro sitio 
                Dim clave As String                     'clave de la base de datos acces a la que accedemos 
                Dim rutaLotes As String                 'ruta de todos los lotes del proyecto 
                Dim abreviatura As String               'abrebviatura del proyecto 
                Dim dtConfiguracion As DataTable        'datos de configuracion del proyecto 
                Dim traza As String
                Dim rutaimagenes As String
                Dim rutatraspasolote As String = ""
                Dim rutaPlantillaExportacion As String = ""
                Dim nomBaseDatosMDB As String = ""
                Dim codigo_servicio As Integer = 47
                Dim historiasLote As New Collection
                Dim numDocumentosHistoria As Integer = 0


                Dim loteExportadoCompletamente As Boolean = True


                Try

                    editor.escribir(pizarra, "Comprobando conexión con base de datos Hospital")  'comprobar que nos podemos conectar a la base de datos del Hospital 

                    If datosORA.probarConexion(cadenaconxionHospital) Then
                        editor.escribir(pizarra, "Conectado correctamente", Color.Green)
                    Else
                        editor.escribir(pizarra, "No se ha podido establecer conexión con el servidor", Color.Red)
                        Exit Function
                    End If

                    editor.escribir(pizarra, "Comprobando accesdo repositorio documentos hospital")     'comprobar que podemos acceder al repositorio de imagenes 

                    If Directory.Exists(rutaRepositorioHospital) Then
                        editor.escribir(pizarra, "conectado correctamente", Color.Green)
                    Else
                        editor.escribir(pizarra, "No se ha podido acceder al repositorir docummentos", Color.Red)
                        Exit Function
                    End If

                    editor.centrado(pizarra, "Inicio del proceso de exportación del lote" & idlote)

                    Application.DoEvents()
                    ' Obtenemos los campos que necesitamos de la tabla de configuración
                    dtConfiguracion = datosSql.ObtenerListadoParaValorParametro("CONFIGURACIONPROYECTO", "RutaPlantillaExportacion, rutalotes", "idproyecto", idproyecto, cadenaconexionAdministrativos)
                    If Not obtenerDatosConfiguracionTraspaso(rutatraspasolote, rutaimagenes, nomBaseDatosMDB, clave, rutaPlantillaExportacion, idlote, _
                                                             idproyecto, cadenaconexionAdministrativos, pizarra) Then
                        Exit Function
                    End If


                    ' Obtenemos la ruta de la plantilla mdb y la ruta destino del lote
                    rutaPlantillaMdb = dtConfiguracion.Rows(0)("RutaPlantillaExportacion").ToString()
                    rutaLotes = dtConfiguracion.Rows(0)("rutalotes").ToString()
                    carpetaDestinoLote = rutaLotes & Path.DirectorySeparatorChar & "Lotes" & Path.DirectorySeparatorChar & "Lote" & idlote & Path.DirectorySeparatorChar
                    abreviatura = datosSql.ObtenerListadoParaValorParametro("proyectos", "abreviatura", "idproyecto", idproyecto, cadenaconexionAdministrativos).Rows(0)(0).ToString()
                    ' Copiamos la plantilla en la ruta del lote con el nombre y la clave correctas

                    Application.DoEvents()

                    editor.centrado(pizarra, "Selección de las historias del lote" & idlote)

                    'me guardo las historias del lote a importar en una coleccion para posteriormente ir obtener los documentos e ir importandoloes       
                    obtenerHistoriasLote(historiasLote, idlote, cadenaconexionProyecto, pizarra)



                    For Each historia As ClsHistoriaImp In historiasLote 'recorrido por cada una de las historias

                        editor.escribir(pizarra, "Exportando los documentos de la historia " & historia._numhistoria)

                        'obtener documentos de la historia de la tabladocumentos
                        numDocumentosHistoria = obtenerDocumentosHistoria(historia, cadenaconexionProyecto)

                        If numDocumentosHistoria = 0 Then
                            editor.escribir(pizarra, "ATENCION, No se han encontrado documentos para la histoira  " & historia._numhistoria, Color.Orange)
                            'loteExportadoCompletamente = False
                        End If

                        If numDocumentosHistoria = -1 Then
                            editor.escribir(pizarra, "Error, al leer los datos tabla documentos de la historia" & historia._numhistoria, Color.Red)
                            loteExportadoCompletamente = False
                        End If


                        editor.escribir(pizarra, numDocumentosHistoria & " documentos encontrados para la historia " & historia._numhistoria)

                        'obtener el codigo del cliente, nos lo guardamos en la propiedad de la historia.
                        obtener_codigo_cliente_historia(historia, cadenaconxionHospital)

                        editor.escribir(pizarra, " Código cliente historia  " & historia._numhistoria & " :" & historia._codigo_cliente & " Coleccion " & historia._coleccion_historia)

                        If historia._estado_historia = 9 Then
                            MessageBox.Show("Atención se va a digitalizar una historia que esta prestada " & historia._numhistoria & "notificar responsable UDCA")
                        End If


                        If historia._codigo_cliente <> 0 Then 'si encontramos el codigo del cliente

                            For Each documento As ClsDocumentoImp In historia._ColeccionDocumentosHistoria

                                If ExisteFichero(documento._nombreFichero, rutaimagenes, rutatraspasolote) Then 'comprobar si el documeno esta en el repositorio 
                                    editor.escribir(pizarra, "ATENCION, No se va a copiar el documento " & documento._nombreFichero & " historia " & historia._numhistoria & "este documento ya existe en el repositorio de documentos", Color.Orange)
                                Else
                                    If copiarFichero(documento._nombreFichero, rutaimagenes, rutatraspasolote) Then  'copiar el fichero en el destino
                                        editor.escribir(pizarra, "Copiado correctamente " & documento._nombreFichero & " historia " & historia._numhistoria)
                                    Else
                                        editor.escribir(pizarra, "ERROR, No se ha podido  copiar el documento " & documento._nombreFichero & " historia " & historia._numhistoria, Color.Red)
                                        loteExportadoCompletamente = False
                                    End If
                                End If

                                If ExistedocumentoBaseDatos(historia, documento, rutatraspasolote, cadenaconxionHospital) Then 'comprobar si el documeno esta en el repositorio 
                                    editor.escribir(pizarra, "ATENCION, No se va a insertar el registro para el documento " & documento._nombreFichero & " historia " & historia._numhistoria & "este documento ya tiene un registro asociado en la base de datos", Color.Orange)
                                Else
                                    If exportarDocumentos(historia, documento, cadenaconxionHospital, traza, pizarra, rutatraspasolote) Then  'copiar el fichero en el destino
                                        editor.escribir(pizarra, "Insertado correctamente " & documento._nombreFichero & " historia " & historia._numhistoria & vbCrLf & traza, Color.Red)
                                    Else
                                        editor.escribir(pizarra, "ERROR, No se ha podido  copiar el documento " & documento._nombreFichero & " historia " & historia._numhistoria, Color.Red)
                                        loteExportadoCompletamente = False
                                    End If
                                End If

                            Next 'fin del recorrido de los documentos de una historia
                            editor.escribir(pizarra, "SE ha importado correctamente la  historia " & historia._numhistoria)

                        Else 'si no hemos encontrado un codigo_cliente valido para insertar la historia 
                            editor.escribir(pizarra, "No se ha encontrado un codigo_cliente en la base de datos del hospital relacionado con la historia " & historia._numhistoria & ". La historia no se importará.", Color.Red)
                            loteExportadoCompletamente = False
                        End If

                    Next


                    If loteExportadoCompletamente = True Then
                        editor.escribir(pizarra, "El lote " & idlote & " se ha exportado con éxito", Color.Green, 10)
                        Application.DoEvents()
                        Return 1
                    Else

                        editor.escribir(pizarra, "El lote " & idlote & "  no se ha exportado completamente.", Color.Red, 10)
                        Application.DoEvents()

                        Return 0
                    End If


                Catch ex As Exception
                    editor.escribir(pizarra, "Error general. No se ha podio exportar el lote " & idlote, Color.Red, 10)
                    Return 0
                End Try

            End Function



            Private Shared Sub obtenerHistoriasLote(ByRef historiaslote As Collection, ByVal idlote As Integer, ByVal cadenaconexionproyecto As String, ByVal pizarra As RichTextBox)

                Dim strSQL As String
                Dim historia As ClsHistoriaImp

                Try


                    strSQL = "SELECT distinct NumHistoria  FROM [DOCUMENTOS] where idlote = " & idlote & "order by numhistoria"


                    For Each registro As DataRow In datosSql.ejecutarSQLDirectaTable(strSQL, cadenaconexionproyecto).Rows


                        'esto hay que cambiarlo para dejar el codigo del servicio fijo
                        historia = New ClsHistoriaImp(idlote, registro.Item("numhistoria"))
                        historiaslote.Add(historia)

                    Next


                Catch ex As Exception
                    editor.escribir(pizarra, "Error al leer los datos de la historias del lote " & idlote & " probalblemente faltaen datos para cumplimentar.")
                End Try

            End Sub


            Private Shared Function obtenerDocumentosHistoria(ByRef historia As ClsHistoriaImp, ByVal cadenaconexionProyecto As String, Optional ByVal codigo_servicio As Integer = 47) As Integer

                Dim NumDocumentos As Integer = 0
                Dim datosIndizacion As DataTable
                Dim documentoimp As ClsDocumentoImp
                Dim strSQl As String
                Try


                    strSQl = " SELECT [Pagina],[NomArchivoTIF],[TipoDocumento],[FechaInicio],[FechaTermino],[NumIcu],[codserviciopaed],[NumHistoria],[Eliminada] " _
                             & " FROM [DOCUMENTOS] where idlote = " & historia._idlote & " and numhistoria = " & historia._numhistoria & " and isnull(Eliminada,0)= 0 order by pagina "

                    datosIndizacion = datosSql.ejecutarSQLDirectaTable(strSQl, cadenaconexionProyecto)

                    'aqui se supone que se tiene que encontrar todo 
                    For Each registro As DataRow In datosIndizacion.Rows

                        documentoimp = New ClsDocumentoImp()
                        documentoimp._codigo_servicio = IIf(IsDBNull(registro.Item("codserviciopaed")), 0, registro.Item("codserviciopaed"))
                        documentoimp._fecdocu = registro.Item("fechainicio")
                        documentoimp._fechatermino = IIf(IsDBNull(registro.Item("fechatermino")), "01/01/1900", registro.Item("fechatermino"))
                        'documentoimp._ICU = registro.Item("Numicu")
                        documentoimp._Episodio = registro.Item("numicu")
                        documentoimp._tipoDocumento = registro.Item("tipodocumento")
                        documentoimp._nombreFichero = registro.Item("NomArchivoTIF")

                        historia._ColeccionDocumentosHistoria.Add(documentoimp)
                        NumDocumentos += 1
                    Next

                    Return NumDocumentos

                Catch ex As Exception
                    Return -1
                End Try

            End Function


            Private Shared Function ExistedocumentoBaseDatos(ByVal historia As ClsHistoriaImp, ByVal documento As ClsDocumentoImp, ByVal rutaTraspasolote As String, ByVal cadenaconexionhospital As String) As Boolean

                Try

                    Dim strOra As String
                    Dim datosCliente As DataTable

                    'comprobar si el documento estaba insertado ya en la base de datos dentro del mismo lote 
                    strOra = "SELECT *  FROM hce_doc_ext WHERE  codigo_cliente = " & historia._codigo_cliente & " and trim(nombre_doc) like '" & documento._nombreFichero & "' and path = '" & rutaTraspasolote & "'"
                    Debug.Print(strOra)
                    datosCliente = datosORA.EjecutarSqlDirecta(strOra, cadenaconexionhospital)

                    If datosCliente.Rows.Count <= 0 Then
                        Return False
                    Else
                        Return True
                    End If

                Catch ex As Exception
                    Return False
                End Try

            End Function


            Private Shared Function ExisteFichero(ByVal nombrefichero As String, ByVal rutaOrigenFichero As String, ByVal rutaTraspaso As String) As Boolean

                Try
                    If File.Exists(rutaTraspaso & nombrefichero) Then
                        Return True
                    Else
                        Return False
                    End If

                Catch ex As Exception
                    Return False
                End Try

            End Function

            Private Shared Function copiarFichero(ByVal nombrefichero As String, ByVal rutaOrigenFichero As String, ByVal rutaTraspaso As String) As Boolean

                Try
                    File.Copy(rutaOrigenFichero & "\" & nombrefichero, rutaTraspaso & nombrefichero)
                    Return True
                Catch ex As Exception
                    Return False
                End Try

            End Function


            Private Shared Function obtener_codigo_cliente_historia(ByRef historia As ClsHistoriaImp, ByVal cadenaConexionHospital As String) As Integer

                Try

                    Dim datosCliente As DataTable
                    datosCliente = datosORA.ObtenerListadoParaValorParametro("HC", "codigo_cliente,codigo_archivo_pk,cod_estadoss,codigo_tipo_hc", "nhc", "'" & historia._numhistoria & "'", cadenaConexionHospital)

                    If datosCliente.Rows.Count > 0 Then
                        historia._codigo_cliente = datosCliente.Rows(0).Item("codigo_cliente")
                        historia._coleccion_historia = datosCliente.Rows(0).Item("codigo_archivo_pk")
                        historia._estado_historia = datosCliente.Rows(0).Item("cod_estadoss")
                        historia._tipo_historia = datosCliente.Rows(0).Item("codigo_tipo_hc")
                    Else
                        historia._codigo_cliente = 0
                    End If
                Catch ex As Exception
                    historia._codigo_cliente = 0
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
                    'editor.escribir(pizarra, "nomBaseDatosMDB: " & nomBaseDatosMDB)
                    'editor.escribir(pizarra, "rutaPlantillaExportacion: " & rutaPlantillaExportaciones)


                    Return True

                Catch ex As Exception
                    editor.escribir(pizarra, ex.Message.ToString, Color.Red)
                    Return False
                End Try

            End Function




            Private Shared Sub generarficheroMultitif(ByVal idlote As Integer, ByVal numhistoria As String, ByVal servicio As String, ByVal fechainicio As String, ByVal episodio As String, ByVal rutaimagenes As String, ByVal rutatraspasolote As String, ByVal cadenaconexionproyecto As String, ByRef pizarra As RichTextBox, ByRef pgbDocumentos As ProgressBar, ByRef NonmbreFicheroMultif As String)

                'genera un archivo multitif con las imagenes de una historia y servicio de un lote 

                Dim vectorImagenes() As String
                Dim tablahistorias As DataTable
                Dim nombreFichero As String
                Dim coleccionNombresFicheros As DataTable

                Try

                    'seleccionar las distintas historias del lote 
                    nombreFichero = ""
                    nombreFichero = numhistoria & servicio & episodio & fechainicio.Replace("/", "") & ".tif"
                    Debug.Print(nombreFichero)
                    NonmbreFicheroMultif = nombreFichero

                    Dim contadorImagenes As Integer = 0 'contador para iterar por los items del vector 

                    coleccionNombresFicheros = datosSql.ejecutarSQLDirectaTable("select nomarchivotif from documentos where idlote = " & idlote & " and numhistoria = " & numhistoria & " and codservicioPaed = '" & servicio & "' and fechainicio = '" & fechainicio & "'", cadenaconexionproyecto)

                    ReDim vectorImagenes(coleccionNombresFicheros.Rows.Count - 1)
                    'generar el fichero multitif de las imagenes 
                    For Each registro As DataRow In coleccionNombresFicheros.Rows



                        vectorImagenes(contadorImagenes) = rutaimagenes & "\" & registro.Item("nomarchivotif").ToString

                        contadorImagenes += 1

                    Next




                Catch ex As Exception
                    editor.escribir(pizarra, "Error al generar el fichero multitif" & ex.ToString, Color.Red)
                    Exit Sub
                End Try


                'COPIAR LAS IMAGENES EN LA RUTA DE TRASPASO 
                ' editor.escribir(pizarra, "Comprobando que el fichero se ha generado correctamente...")

            End Sub




            Private Shared Function ComprobarFicheroGenerado(ByVal idlote As String, ByVal numhistoria As String, ByVal servicio As String, ByVal fechainicio As String, ByVal ficheromultitif As String, ByVal cadenaconexion As String, ByRef pizarra As RichTextBox, ByRef pgbDocumentos As ProgressBar, ByRef visor As AxImgeditLibCtl.AxImgEdit) As Boolean

                Dim numeroImagenesImportadasSistema As Integer

                Try

                    numeroImagenesImportadasSistema = datosSql.ejecutarSQLDirectaDataRow("SELECT count(*) from documentos where idlote = " & idlote & " and numhistoria = " & numhistoria & " and codservicioPAed = '" & servicio & "' and fechainicio = '" & fechainicio & "' ", cadenaconexion).Item(0)


                    If IO.File.Exists(ficheromultitif) Then

                        With visor
                            .ClearDisplay()
                            .Image = ""
                            .Image = ficheromultitif
                            .Page = 1
                            .FitTo(1)
                            .Display()
                            .Refresh()
                        End With


                        If numeroImagenesImportadasSistema = visor.PageCount Then

                            'visualizamos las imagenes para comprobar que se ven correctamente 
                            For i As Integer = visor.Page To visor.PageCount
                                With visor
                                    .Page = i
                                    Debug.Print(.Page)
                                    .Display()
                                    .Refresh()
                                End With
                                Application.DoEvents()
                            Next
                            editor.escribir(pizarra, "El fichero " & ficheromultitif & " se ha creado de forma correcta con " & numeroImagenesImportadasSistema & " imagenes ", Color.Green)
                        Else
                            editor.escribir(pizarra, "El numero de imagenes de la base de datos " & numeroImagenesImportadasSistema & " no coincide con el numero de imagenes del fichero" & ficheromultitif, Color.Red)
                            Return False
                        End If



                    Else
                        editor.escribir(pizarra, "No se ha encontrado la imagen en la ruta solicitada ", Color.Red)
                        Return False
                    End If

                Catch ex As Exception
                    editor.escribir(pizarra, "Incidencia al visualizar los documentos del vichero multitif  " & ex.Message.ToString, Color.Red)
                    Return False
                End Try

                Return True

            End Function




            'acuerdate del valor devuelto
            Private Shared Function exportarDocumentos(ByVal historia As ClsHistoriaImp, ByVal documento As ClsDocumentoImp, ByVal cadenaConexionHospital As String, ByRef traza As String, ByRef pizarra As RichTextBox, ByVal rutatraspasolote As String) As Integer

                Dim strSQL As String
                Dim conexion As New System.Data.OracleClient.OracleConnection(cadenaConexionHospital)
                Dim comando As System.Data.OracleClient.OracleCommand
                Dim trans As System.Data.OracleClient.OracleTransaction = Nothing



                Dim nhc, imagen, fecha_doc, path, pkepisodio, pkdocumento, pktipodoc, pkservicio, pkcliente As String
                Dim tabla As DataTable
                Dim iDdocumento As Integer
                Dim coleccionHistoria As Integer

                'el pkcliente se pasa como parametro

                Try


                    nhc = historia._numhistoria
                    imagen = documento._nombreFichero
                    fecha_doc = documento._fecdocu
                    fecha_doc = Replace(fecha_doc, "2020", Date.Now.Year)
                    path = rutatraspasolote
                    pkdocumento = documento._tipoDocumento
                    'pkepisodio = registro.pTipoEpisodio
                    If documento._Episodio = 998 Then
                        pkepisodio = "null"
                    Else
                        pkepisodio = documento._Episodio
                    End If
                    pkcliente = historia._codigo_cliente
                    pkservicio = documento._codigo_servicio

                    If documento._codigo_servicio = 0 Then
                        pkservicio = "1210"
                    Else
                        pkservicio = documento._codigo_servicio
                    End If

                    conexion.Open()
                    trans = conexion.BeginTransaction
                    'trans.Begin()

                    tabla = datosORA.ObtenerListadoParaValorParametro("descriptores", "contador", "descriptor", "'hce_doc_ext'", cadenaConexionHospital)
                    If tabla.Rows.Count > 0 Then
                        iDdocumento = tabla.Rows(0).Item(0)
                        iDdocumento = iDdocumento + 1
                    End If

                    'el tipo de documento siempre es el 13, tipo .tif
                    pktipodoc = 13



                    strSQL = "insert into hce_doc_ext(doc_ext_pk,nhc,nombre_doc,fecha_doc,path,tipo_doc_pk,epis_pk,documento_pk,observaciones,codigo_cliente,codigo_servicio)"
                    strSQL = strSQL & " values (" & iDdocumento & ",'" & nhc & "','" & imagen & "','" & fecha_doc & "','" & path & "'," & pktipodoc & "," & pkepisodio & "," & pkdocumento & ",''," & pkcliente & "," & pkservicio & ")"

                    Debug.Print(strSQL)
                    comando = New System.Data.OracleClient.OracleCommand(strSQL, conexion)
                    comando.Transaction = trans
                    comando.ExecuteNonQuery()
                    '---fin insertar registro

                    '---- actualizar contador de la tabla descriptores
                    strSQL = "update descriptores set contador=" & iDdocumento & " where descriptor='hce_doc_ext'"

                    comando = New System.Data.OracleClient.OracleCommand(strSQL, conexion)
                    comando.Transaction = trans
                    comando.ExecuteNonQuery()

                    Select Case historia._coleccion_historia
                        Case 47
                            coleccionHistoria = 31
                        Case 48
                            coleccionHistoria = 49
                        Case 50
                            coleccionHistoria = 51
                        Case 46
                            coleccionHistoria = 44
                        Case Else
                            coleccionHistoria = historia._coleccion_historia
                    End Select

                    '---- actualizar contador de la tabla descriptores
                    strSQL = "update hc set cod_estadoss= 1,codigo_tipo_hc=1,codigo_archivo_pk = " & coleccionHistoria & " where nhc= " & nhc

                    comando = New System.Data.OracleClient.OracleCommand(strSQL, conexion)
                    comando.Transaction = trans
                    comando.ExecuteNonQuery()
                    '---- fin actualizar descriptores

                    trans.Commit()

                Catch ex As Exception
                    MessageBox.Show("Error " & ex.Message.ToString)
                    MostraMensaje(ex.Message, historia, imagen, fecha_doc, pkepisodio, pkdocumento, pkservicio, rutatraspasolote)
                    trans.Rollback()
                    Return 0
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                End Try

                Return 1

            End Function


            Private Shared Sub MostraMensaje(ByVal msjerror As String, ByVal historia As ClsHistoriaImp, ByVal imagen As String, ByVal fechadoc As String, ByVal episodio As String, ByVal tipodocumento As String, ByVal servicio As String, ByVal rutaTraspasolote As String)

                Dim strMensaje As String


                strMensaje = "ERROR al insertar los datos de la historia " & historia._numhistoria & vbCr _
              & " imagen " & imagen & vbCr _
              & " fecha documento " & fechadoc & vbCr _
              & " tipo documento " & tipodocumento & vbCr _
              & " servicio " & servicio & vbCr _
              & " ruta traspaso lote " & rutaTraspasolote


                If msjerror.Contains("FK_SERV_HCDOCEXT") Then
                    strMensaje &= vbCr & "codigo servicio:" & servicio & "el codigo de servicio introducido es incorrecto "
                End If

                If msjerror.Contains("FK_DOC_DOCEXT") Then
                    strMensaje &= vbCr & "Tipo documento :" & tipodocumento & " el tipo documento introducido es incorrecto "
                End If

                If msjerror.Contains("FK_DOCEXT_EPIS") Then
                    strMensaje &= vbCr & "Episodio  :" & episodio & " el episodio introducido es incorrecto "
                End If




                MsgBox(strMensaje, MsgBoxStyle.OkOnly, "ERROR")

            End Sub



        End Class

    End Namespace

End Namespace
