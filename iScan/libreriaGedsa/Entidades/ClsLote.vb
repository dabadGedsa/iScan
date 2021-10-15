Imports System.IO
Imports System.Windows.Forms
Imports consulta = libreriacadenaproduccion.Datos.GeneralSQL.clsAccesoDatosSQL

Namespace Entidades

    Public Class ClsLote

#Region "Variables privadas"


        Private idlote As Integer
        Private nombreCompleto As String
        Private archivoDAT As FileInfo
        Private archivoMDB As FileInfo
        Private codigoProyecto As String
        Private tipoLote As String
        Private fechalote As String
        Private rutaMDB As String
        Private rutaDAT As String
        Private rutaRaizimagenes As String
        Private abreviaturaProyecto As String
        Private numPaginaActual As Integer
        Private TotImagenes As Integer
        Private ImgActual As Integer
        Private UsuarioA As String
        Private ColeccionDocumentos As New Collection
        Private asignado As String
        Private servicio As String
        Private tipoDocumento As String
        Private posiciones As Integer


#End Region

#Region "Constructores y destructores"

        Public Sub New()

        End Sub

        ''' <summary>
        ''' Constructor del objeto lote
        ''' </summary>
        ''' <param name="lote">nombre del lote, lote1 , lote2, lote3</param>
        ''' <param name="codigoproyecto ">Identifica al proyecto al que pertenece el lote </param> 
        ''' <param name="fechalote">es util para diferenciar los lotes dentro de un mism proyecto en años diferentes</param> 
        ''' <remarks> 
        '''se crea un lote con el codigo del proyecto 
        ''' </remarks> 
        Public Sub New(ByVal lote As String, ByVal codigoproyecto As String, ByVal fechalote As String) '', Optional servicio As String = "", Optional tipoDocumento As String = "")
            Me.codigoProyecto = codigoproyecto
            Me.nombreCompleto = "Lote" & lote
            Me.idlote = lote
            Me.tipoLote = tipoLote
            Me.fechalote = fechalote
            ''Me.servicio = servicio
            ''Me.tipoDocumento = tipoDocumento
        End Sub

        Public Sub New(ByVal nombre As String, ByVal loteCompleto As String, ByVal dat As FileInfo, ByVal mdb As FileInfo)

            Me.idlote = nombre
            Me.nombreCompleto = nombreCompleto
            Me.archivoDAT = dat
            Me.archivoMDB = mdb

        End Sub

        Public Sub New(ByVal nombre As String, ByVal nombreCompleto As String)
            Me.idlote = nombre
            Me.nombreCompleto = nombreCompleto
        End Sub

        Public Sub New(ByVal id As Integer, ByVal proyecto As String)
            Me.idlote = id
            Me.codigoProyecto = proyecto
        End Sub

#End Region

#Region "Propiedades"
        Public Property colDocumentos() As Collection
            Get
                Return Me.ColeccionDocumentos
            End Get
            Set(ByVal value As Collection)

                Me.ColeccionDocumentos = value
            End Set
        End Property

        Public Property _NumImgActual() As Integer
            Get
                Return Me.numPaginaActual
            End Get
            Set(ByVal value As Integer)
                Me.numPaginaActual = value
            End Set
        End Property

        Public Property _TotalImg() As Integer
            Get
                Return Me.TotImagenes
            End Get
            Set(ByVal value As Integer)
                Me.TotImagenes = value
            End Set
        End Property


        'Public Property _IdLote() As Integer
        '    Get
        '        Return id
        '    End Get
        '    Set(ByVal value As Integer)
        '        id = value
        '    End Set
        'End Property


        Public Property _idlote() As String
            Get
                Return Me.idlote
            End Get
            Set(ByVal value As String)
                Me.idlote = value
            End Set
        End Property

        Public Property _asignado() As String
            Get
                Return Me.asignado
            End Get
            Set(ByVal value As String)
                Me.asignado = value
            End Set
        End Property

        Public Property _nombreCompleto() As String
            Get
                Return Me.nombreCompleto
            End Get
            Set(ByVal value As String)
                Me.nombreCompleto = value
            End Set
        End Property

        Public Property _archivoDat() As FileInfo
            Get
                Return Me.archivoDAT
            End Get
            Set(ByVal value As FileInfo)
                Me.archivoDAT = value
            End Set
        End Property

        Public Property _archivoMdb() As FileInfo
            Get
                Return Me.archivoMDB
            End Get
            Set(ByVal value As FileInfo)
                Me.archivoMDB = value
            End Set
        End Property


        Public Property _codigoproyecto() As String
            Get
                Return Me.codigoProyecto
            End Get
            Set(ByVal value As String)

                Me.codigoProyecto = value

            End Set
        End Property


        Public Property _TipoLote() As String
            Get
                Return Me.tipoLote
            End Get
            Set(ByVal value As String)

                Me.tipoLote = value

            End Set
        End Property

        Public Property _FechaLote() As String
            Get
                Return Me.fechalote
            End Get
            Set(ByVal value As String)

                Me.fechalote = value

            End Set
        End Property

        Public Property _UsuarioAsignado() As String
            Get
                Return Me.UsuarioA
            End Get
            Set(ByVal value As String)
                Me.UsuarioA = value
            End Set
        End Property


        Public Property _rutaMDB() As String
            Get
                Return Me.rutaMDB
            End Get
            Set(ByVal value As String)
                Me.rutaMDB = value
            End Set
        End Property

        Public Property _rutaDAT() As String
            Get
                Return Me.rutaDAT
            End Get
            Set(ByVal value As String)
                Me.rutaDAT = value
            End Set
        End Property

        Public Property _rutaRaizimagenes() As String
            Get
                Return Me.rutaRaizimagenes
            End Get
            Set(ByVal value As String)
                Me.rutaRaizimagenes = value
            End Set
        End Property

        Public Property _abreviaturaProyecto() As String
            Get
                Return Me.abreviaturaProyecto
            End Get
            Set(ByVal value As String)
                Me.abreviaturaProyecto = value
            End Set
        End Property


        Public Property _rutaOrigenImagenesLote() As String
            Get
                Dim pos As Integer
                Dim fichero, loteactivoRed As String

                pos = InStrRev(Me.rutaMDB, "\")
                fichero = Mid(rutaMDB, pos + 1)
                loteactivoRed = Mid(fichero, 1, Len(fichero) - 4)

                Return Me.rutaRaizimagenes & "\" & Me.abreviaturaProyecto & "\DIGI\" & loteactivoRed & "\IMAGEN\" & Me._idlote

            End Get
            Set(ByVal value As String)

            End Set
        End Property

        Public Property _servicio() As String
            Get
                Return Me.servicio
            End Get
            Set(ByVal value As String)
                Me.servicio = value
            End Set
        End Property

        Public Property _tipoDocumento() As String
            Get
                Return Me.tipoDocumento
            End Get
            Set(ByVal value As String)
                Me.tipoDocumento = value
            End Set
        End Property

        Public Property _posiciones() As Integer
            Get
                Return Me.posiciones
            End Get
            Set(ByVal value As Integer)
                Me.posiciones = value
            End Set
        End Property

#End Region

#Region "Funciones de clase"
        Public Function verificarIntegridad(ByVal CadenaConexionServidor As String) As Boolean

            For Each documento As DataRow In LibreriaCadenaProduccion.Datos.Produccion.clsAccesoDatosProduccion.ObtenerDatosParaVerificarIntegridadLote(Me.codigoProyecto, Me._idlote, CadenaConexionServidor).Rows

                Dim cadena As String = documento.Item("NomArchivoTIF").ToString()
                Dim indiceImagen As Integer = Val(Mid(cadena, 4, 5))

                If Not (documento.Item("id_lote").ToString() = documento.Item("pagina").ToString() = indiceImagen.ToString()) Then
                    Return False
                End If
            Next

            Return True

        End Function

        'cumplimenta la coleccion de documentos en una coleccion. Copn los datos botenidos en una tabla
        Public Sub obtenerColDocumentos(ByVal tablaDocumentos As DataTable)
            Dim colDocumentos As New Collection
            Dim documento As ClsDocumento
            Dim vindizado As Integer = 0
            Dim vnumicu As String = ""
            Dim vnumhistoria As Integer = 0

            Try

                For Each documentos As DataRow In tablaDocumentos.Rows
                    If Not IsDBNull(documentos.Item("Indizado")) Then

                        If documentos.Item("Indizado").ToString().Replace(" ", "") <> "" Then
                            'hay algunos registro asi (no nulos y sin numero), de esta manera 
                            'evitamos el fallo

                            vindizado = (documentos.Item("Indizado"))

                        End If

                    Else
                        vindizado = 0
                    End If

                    '-----------------
                    If Not IsDBNull(documentos.Item("NumHistoria")) Then
                        vnumhistoria = (documentos.Item("NumHistoria"))
                    Else
                        vnumhistoria = 0
                    End If

                    '-----------------
                    If Not IsDBNull(documentos.Item("NumIcu")) Then
                        vnumicu = (documentos.Item("NumIcu"))
                    Else
                        vnumicu = ""
                    End If


                    'vindizado = (IIf(IsDBNull(documentos.Item("Indizado")), documentos.Item("Indizado"), 0))
                    'vnumhistoria = IIf(IsDBNull(documentos.Item("NumHistoria")), documentos.Item("NumHistoria"), 0)

                    IIf(IsDBNull(documentos.Item("SizeDevice")), 0, documentos.Item("SizeDevice"))



                    documento = New libreriacadenaproduccion.Entidades.ClsDocumento(vnumhistoria, _
                    vnumicu, _
                    documentos.Item("id"), _
                    documentos.Item("NomArchivoTIF"), _
                    IIf(IsDBNull(documentos.Item("InicioDevice")), 0, documentos.Item("InicioDevice")), _
                    IIf(IsDBNull(documentos.Item("SizeDevice")), 0, documentos.Item("SizeDevice")), _
                    vindizado, _
                    IIf(IsDBNull(documentos.Item("TipoDocumento")), 0, documentos.Item("TipoDocumento")), _
                    IIf(IsDBNull(documentos.Item("Pagina")), 0, documentos.Item("Pagina")) _
                    )



                    Me.ColeccionDocumentos.Add(documento, documento._Id) 'introducimos el documento con el identificador como clave 
                Next

            Catch ex As Exception
                MessageBox.Show("Error al cargar la lista de documentos " & ex.Message)
            End Try

        End Sub

        Public Sub obtenerColDocumentosCorreccion(ByVal tablaDocumentos As DataTable, ByVal porcentaje As Integer)
            Dim colDocumentos As New Collection
            Dim documento As ClsDocumento
            Dim vindizado As Integer = 0
            Dim vnumicu As String = ""
            Dim vnumhistoria As Integer = 0
            Dim Random As New Random()
            Dim numeroFilasBorrar As Integer
            Dim numeroFilasFinal As Integer

            Try
                numeroFilasBorrar = ((100 - porcentaje) * (tablaDocumentos.Rows.Count)) \ 100
                numeroFilasFinal = (tablaDocumentos.Rows.Count) - numeroFilasBorrar

                While (tablaDocumentos.Rows.Count) > numeroFilasFinal
                    Randomize()
                    Dim numero As Integer = Random.Next(0, tablaDocumentos.Rows.Count - 1)
                    tablaDocumentos.Rows(numero).Delete()

                End While

            Catch ex As Exception
                MessageBox.Show("Error en el random " & ex.Message)

            End Try


            Try

                For Each documentos As DataRow In tablaDocumentos.Rows


                    If Not IsDBNull(documentos.Item("Indizado")) Then

                        If documentos.Item("Indizado").ToString().Replace(" ", "") <> "" Then
                            'hay algunos registro asi (no nulos y sin numero), de esta manera 
                            'evitamos el fallo

                            vindizado = (documentos.Item("Indizado"))

                        End If

                    Else
                        vindizado = 0
                    End If
                    '-----------------
                    If Not IsDBNull(documentos.Item("NumHistoria")) Then
                        vnumhistoria = (documentos.Item("NumHistoria"))
                    Else
                        vnumhistoria = 0
                    End If
                    '-----------------
                    If Not IsDBNull(documentos.Item("NumIcu")) Then
                        vnumicu = (documentos.Item("NumIcu"))
                    Else
                        vnumicu = ""
                    End If


                    'vindizado = (IIf(IsDBNull(documentos.Item("Indizado")), documentos.Item("Indizado"), 0))
                    'vnumhistoria = IIf(IsDBNull(documentos.Item("NumHistoria")), documentos.Item("NumHistoria"), 0)

                    IIf(IsDBNull(documentos.Item("SizeDevice")), 0, documentos.Item("SizeDevice"))



                    documento = New libreriacadenaproduccion.Entidades.ClsDocumento(vnumhistoria, _
                    vnumicu, _
                    documentos.Item("id"), _
                    documentos.Item("NomArchivoTIF"), _
                    IIf(IsDBNull(documentos.Item("InicioDevice")), 0, documentos.Item("InicioDevice")), _
                    IIf(IsDBNull(documentos.Item("SizeDevice")), 0, documentos.Item("SizeDevice")), _
                    vindizado, _
                    IIf(IsDBNull(documentos.Item("TipoDocumento")), 0, documentos.Item("TipoDocumento")), _
                    IIf(IsDBNull(documentos.Item("Pagina")), 0, documentos.Item("Pagina")) _
                    )



                    Me.ColeccionDocumentos.Add(documento, documento._Id) 'introducimos el documento con el identificador como clave 
                Next

            Catch ex As Exception
                MessageBox.Show("Error al cargar la lista de documentos " & ex.Message)
            End Try

        End Sub

        'Public Function ObtenerDocumentoColec(ByVal historia As Integer, ByVal numicu As Integer) As clsDocumento
        Public Function ObtenerDocumentoColec(ByVal pagina As Integer) As ClsDocumento
            'Dim documento As New clsDocumento(historia, numicu)
            Dim documento As ClsDocumento = Nothing
            Dim encontrado As Boolean = False
            Dim i As Integer = 1

            While i <= Me.ColeccionDocumentos.Count And encontrado = False

                'documento = New ClsDocumento

                documento = Me.ColeccionDocumentos.Item(i)
                'If documento._historia = historia And documento._numicu = numicu Then
                If documento._pagina = pagina + 1 Then
                    encontrado = True
                End If
                i = i + 1
            End While

            If pagina = Me.ColeccionDocumentos.Count Then

                documento = Me.ColeccionDocumentos.Item(Me.ColeccionDocumentos.Count)
                encontrado = True
            End If

            If encontrado = False Then
                documento = Nothing
            End If


            Return documento
        End Function

        Public Overrides Function ToString() As String
            Return Me._idlote
        End Function


        Public Shared Sub CargarImagenesLoteListview(ByVal rutaImagenesLote As String, ByRef lstImagenes As ListView, ByRef imagelist1 As ImageList)
            Dim metadatos As FileInfo
            Dim imagen As Image

            lstImagenes.Items.Clear()
            lstImagenes.Refresh()


            For Each archivo As String In Directory.GetFiles(rutaImagenesLote)
                metadatos = New FileInfo(archivo)

                'visualizar la imagen
                If metadatos.Extension.ToLower = ".tif" Then
                    imagen = Image.FromFile(metadatos.FullName)
                    Application.DoEvents()
                    imagelist1.Images.Add(metadatos.Name, imagen)
                    Application.DoEvents()
                    lstImagenes.Items.Add(metadatos.Name, metadatos.Name)
                    Application.DoEvents()
                End If

            Next

        End Sub

#End Region

#Region "Metodos Shared"

        ''' <summary>
        ''' Este metodo inserta un documento en un lote expecificado
        ''' </summary>
        ''' <param name="proyecto"></param>
        ''' <param name="lote"></param>
        ''' <remarks></remarks>
        Public Shared Function insercionDocumento(ByVal cadenaConexion As String, ByVal proyecto As Integer, ByVal lote As Integer, ByRef pagina As Integer) As Boolean

            'Variable que nos define si el proceso lo realiza correctamente
            Dim correcto As Boolean = True

            'Obtenemos la ruta de los ficheros del lote
            Dim ruta_carpeta As String = ObtenerRutaImagenes(cadenaConexion, proyecto, lote)

            If ruta_carpeta.Length - 1 > 0 Then

                'Si el ultimo caracter de la ruta de documentos no es una \, se lo añadimos
                If ruta_carpeta.Chars(ruta_carpeta.Length - 1) = "\"c Then ruta_carpeta &= "\"

                'Obtenemos los nombres de los ficheros, la columna 'documentos' tiene los nombres
                'de los documento origen, y 'documentos_d' el nombre destino
                'como es insercion ordenamos de forma DESC (De más alto a más bajo)
                'para que cuando recorra el bucle y renombre no se machaquen los ficheros
                Dim ficheros As DataTable = obtenerDocumentos(cadenaConexion, proyecto, lote, , False, , ",pagina, 'IML'+RIGHT('00000'+CONVERT(VARCHAR,Pagina+1),5)+'.TIF' documentos_d", " ORDER BY pagina DESC")

                If ficheros IsNot Nothing Then

                    'Si no ha dado error de conexion y se ha ejecutado correctamente el procedimiento
                    If consulta.ejecutaSQLEjecucion("EXECUTE documentos_insercion '" & proyecto & "'," & lote & "," & pagina, cadenaConexion) Then

                        'Si existen filas por encima, se renombran
                        If ficheros.Rows.Count - 1 > 0 Then
                            For i As Integer = 0 To ficheros.Rows.Count - 1
                                Try
                                    If IO.File.Exists(ruta_carpeta & ficheros.Rows(i).Item("documentos").ToString) Then
                                        'Si existe algun fichero con el nombre destino, lo eliminamos
                                        If IO.File.Exists(ruta_carpeta & ficheros.Rows(i).Item("documentos_d").ToString) Then IO.File.Delete(ruta_carpeta & ficheros.Rows(i).Item("documentos").ToString)
                                        IO.File.Move(ruta_carpeta & ficheros.Rows(i).Item("documentos").ToString, ruta_carpeta & ficheros.Rows(i).Item("documentos_d").ToString)
                                    End If
                                Catch ex As Exception
                                    correcto = False 'Alguna imagen puede estar cogida por algun usuario/proceso y no se puede mover
                                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Incidencia de aplicacion")
                                End Try
                            Next
                        Else
                            MsgBox("No existe el fichero seleccionado", MsgBoxStyle.Critical, "Incidencia de aplicacion")
                            correcto = False 'No existe un fichero de copiado en la ruta, pero el proceso se completa
                        End If
                    Else
                        correcto = False 'Fallo en la ejecución del procedimiento
                    End If 'EXECUTE documentos_insercion
                Else
                    correcto = False 'Error en la conexion obteniendo ficheros
                End If 'ficheros IsNot Nothing
            Else
                correcto = False 'No se ha obtenido el nombre de las imagenes
            End If

            Return correcto

        End Function

        ''' <summary>
        ''' Eliminacion de un documento, unicamente mediante su Identificador
        ''' </summary>
        ''' <param name="proyecto"></param>
        ''' <param name="lote"></param>
        ''' <remarks></remarks>
        Public Shared Function eliminacionDocumento(ByVal cadenaConexion As String, ByVal proyecto As Integer, ByVal lote As Integer, ByVal pagina As Integer) As Boolean
            'Variable que nos define si el proceso lo realiza correctamente
            Dim correcto As Boolean = True

            'Obtenemos la ruta de los ficheros del lote
            Dim ruta_carpeta As String = ObtenerRutaImagenes(cadenaConexion, proyecto, lote)

            If ruta_carpeta.Length - 1 > 0 Then

                'Si el ultimo caracter de la ruta de documentos no es una \, se lo añadimos
                If ruta_carpeta.Chars(ruta_carpeta.Length - 1) = "\"c Then ruta_carpeta &= "\"

                'Obtenemos los nombres de los ficheros, la columna 'documentos' tiene los nombres
                'de los documento origen, y 'documentos_d' el nombre destino
                'como es insercion ordenamos de forma ASC (De más bajo a más alto)
                Dim ficheros As DataTable = obtenerDocumentos(cadenaConexion, proyecto, lote, , False, , ",pagina, 'IML'+RIGHT('00000'+CONVERT(VARCHAR,Pagina+1),5)+'.TIF' documentos_d", " ORDER BY pagina ASC")

                If ficheros IsNot Nothing Then

                    'Si no ha dado error de conexion y se ha ejecutado correctamente el procedimiento
                    If consulta.ejecutaSQLEjecucion("EXECUTE documentos_eliminacion '" & proyecto & "'," & lote & "," & pagina, cadenaConexion) Then

                        'Si existen filas por encima, se renombran
                        If ficheros.Rows.Count - 1 > 0 Then
                            For i As Integer = 0 To ficheros.Rows.Count - 1
                                Try
                                    If IO.File.Exists(ruta_carpeta & "\" & ficheros.Rows(i).Item("documentos").ToString) Then
                                        'Si existe algun fichero con el nombre destino, lo eliminamos
                                        If IO.File.Exists(ruta_carpeta & "\" & ficheros.Rows(i).Item("documentos_d").ToString) Then IO.File.Delete(ruta_carpeta & ficheros.Rows(i).Item("documentos_d").ToString)
                                        IO.File.Move(ruta_carpeta & "\" & ficheros.Rows(i).Item("documentos").ToString, ruta_carpeta & "\" & ficheros.Rows(i).Item("documentos_d").ToString)
                                    End If
                                Catch ex As Exception
                                    correcto = False 'Alguna imagen puede estar cogida por algun usuario/proceso y no se puede mover
                                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Incidencia de aplicacion")
                                End Try
                            Next
                        Else
                            MsgBox("No existe el fichero seleccionado", MsgBoxStyle.Critical, "Incidencia de aplicacion")
                            correcto = False 'No existe un fichero de copiado en la ruta, pero el proceso se completa
                        End If
                    Else
                        correcto = False 'Fallo en la ejecución del procedimiento
                    End If 'EXECUTE documentos_insercion
                Else
                    correcto = False 'Error en la conexion obteniendo ficheros
                End If 'ficheros IsNot Nothing
            Else
                correcto = False 'No se ha obtenido el nombre de las imagenes
            End If

            Return correcto
        End Function

        ''' <summary>
        ''' Obtencion de los documentos de un lote
        ''' </summary>
        ''' <param name="proyecto"></param>
        ''' <param name="fecha"></param>
        ''' <remarks></remarks>
        Public Shared Function obtenerDocumentos(ByVal cadenaConexion As String, ByVal proyecto As Integer, ByVal codigoLote As Integer, Optional ByVal fecha As String = "", Optional ByVal rutacompleta As Boolean = True, Optional ByVal condicion_adicional As String = "", Optional ByVal select_condicional As String = "", Optional ByVal orderby_condicional As String = "") As DataTable

            'Obtenemos la ruta de las imagenes con las que vamos a tratar
            Dim ruta As String = ""
            Dim sqlWHERE As String = ""

            If rutacompleta Then

                ruta = ObtenerRutaImagenes(cadenaConexion, proyecto, codigoLote)

                'En el caso que no exista la ultima barra, se añade
                If ruta.Length > 0 Then
                    If ruta.Chars(ruta.Length - 1) <> "\" Then ruta &= "\"
                Else
                    MsgBox("La ruta de imagenes se encuentra vacia", MsgBoxStyle.Critical)
                End If

            End If

            If fecha <> "" Then
                If IsDate(fecha) Then
                    Dim tmpFecha As Date = fecha
                    sqlWHERE &= " AND fechaLote='" & Format(tmpFecha, "dd/MM/yyyy").ToString & "'"
                Else
                    MsgBox("La fecha seleccionada no es correcta", MsgBoxStyle.Critical, "Incidencia en aplicacion")
                End If

            End If

            If rutacompleta Then
                If Not Directory.Exists(ruta) Then
                    MsgBox("La carpeta correspondiente a las imagenes del lote no existe", MsgBoxStyle.Critical, "Incidencia de aplicacion")
                    Return Nothing
                End If
            End If

            sqlWHERE &= condicion_adicional

            'En el caso de que exista , procedemos a listar los ficheros
            Dim sql As String = "SELECT '" & ruta & "'+nomArchivoTIF as documentos" & select_condicional & " from documentos WHERE proyecto = '" & proyecto & "' and codigolote='" & codigoLote & "'" & sqlWHERE
            Dim ds As DataSet = consulta.ejecutarSQLDirecta(sql, cadenaConexion)
            If ds.Tables.Count > 0 Then
                Return ds.Tables(0)
            Else
                MsgBox("La consulta de ficheros no devolvio registros", MsgBoxStyle.Critical, "Incidencia de aplicacion")
            End If

            ' documentos SET corregida=0 WHERE proyecto = '9999' and codigolote=8


            Return Nothing

        End Function

        Public Shared Function ObtenerRutaImagenes(ByVal cadenaConexion As String, ByVal proyecto As String, ByVal codigoLote As String) As String
            Try
                Return ObtenerRaizRutaImagen(proyecto, cadenaConexion) & Format(Val(codigoLote), "00000") & Path.DirectorySeparatorChar & "Imagen" & Path.DirectorySeparatorChar & codigoLote
            Catch ex As Exception
                Return ""
            End Try
        End Function

        Public Shared Function ObtenerRaizRutaImagen(ByVal proyecto As String, ByVal cadenaConexion As String) As String

            Dim strSQL As String = "Select conf.rutaImagenes, pro.abreviatura from Configuracion as conf, proyectos as pro where pro.Proyecto='" & proyecto & "'" _
            & " AND pro.Proyecto = conf.proyecto"

            Dim rutaImagenes = ""
            Dim dt As DataTable = consulta.ejecutarSQLDirecta(strSQL, cadenaConexion).Tables(0)

            Try
                If dt.Rows.Count > 0 Then
                    Return dt.Rows(0).Item("rutaImagenes").ToString & Path.DirectorySeparatorChar & dt.Rows(0).Item("abreviatura").ToString & "\DIGI\" & dt.Rows(0).Item("abreviatura").ToString
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString)
            End Try

            Return ""

        End Function

#End Region


    End Class

End Namespace