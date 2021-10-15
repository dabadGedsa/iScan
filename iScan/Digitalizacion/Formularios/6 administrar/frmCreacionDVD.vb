Imports datosSQL = LibreriaCadenaProduccion.Datos.GeneralSQL.clsAccesoDatosSQL
Imports editor = LibreriaCadenaProduccion.TXT.clsFormato
Imports formateoTXT = LibreriaCadenaProduccion.TXT.ClsExtraerTXT
Imports accesodatoslotes = LibreriaCadenaProduccion.Datos.Produccion.cadenaproduccion.clsAccesoDatosLote
Imports System.IO
Imports System.Data.SqlClient

Public Class frmCreacionDVD

    Private cadenaConexionProyecto As String = ""
    Private cadenaconexionAdministrativos As String = ""
    Private codigoProyecto As String = ""
    Private idusuario As Integer = 0
    Private rutaLotes As String

    Public Sub New(ByVal conexionproy As String, ByVal codprod As String, ByVal iduser As Integer, ByVal cadenaconexionadmin As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        Me.cadenaConexionProyecto = conexionproy
        Me.cadenaconexionAdministrativos = cadenaconexionadmin
        Me.codigoProyecto = codprod
        Me.idusuario = iduser
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub frmCreacionDVD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Call inicializarDAtos()

    End Sub

    Private Sub inicializarDAtos()

        Dim strSQLLotesExpNocomp As String
        Dim dtConfiguracion As DataTable


        strSQLLotesExpNocomp = " SELECT lotes.idLote,FechaLote,Asignado " _
         & " FROM  Lotes, TrazabilidadLotes " _
         & " WHERE LOTES.IDLOTE = TRAZABILIDADlOTES.IDLOTE And (exportado = 0 Or exportado Is null) And Activo = 1 " _
         & " AND isnull(finalizado,0)=1 " _
         & " AND idProyecto= '" & Me.codigoProyecto & "'" _
         & " and not exists (select lotesvolumen.idlote from lotesvolumen where lotesvolumen.idlote = lotes.idlote) " _
         & " order by Lotes.idLote asc "

        Debug.Print(strSQLLotesExpNocomp)

        Me.dgvCompilacion.DataSource = datosSQL.ejecutarSQLDirectaTable(strSQLLotesExpNocomp, cadenaConexionProyecto)


        dtConfiguracion = datosSQL.ObtenerListadoParaValorParametro("CONFIGURACIONPROYECTO", "RutaPlantillaExportacion, rutalotes", "idproyecto", codigoProyecto, Me.cadenaconexionAdministrativos)
        
        rutaLotes = dtConfiguracion.Rows(0)("rutalotes").ToString() & "\lotes\"


    End Sub


    'Private Sub cmdGenerarDVD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGenerarDVD.Click


    '    Dim rutaCompilacionDVD As String
    '    Dim ficheroTXT As String
    '    Dim contenidoficheroTXT As String
    '    Dim contadorHistorias As Integer
    '    Dim contadordocumentos As Integer
    '    Dim contadorimagenes As Integer
    '    Dim intervalo As String
    '    Dim volumen As String                           'nombre de la carpeta donde se deja todo 
    '    Dim listalotes As String()                      'lista de los lotes que componen el volumen
    '    Dim historiasRepescomp As String                'numero de historias que estan en dos lotes distintos dentro del mismo volumen
    '    Dim espaciolibre As Long
    '    Dim espaciolibreGB As Long                      'espacio libre en el disco carpeta destino 
    '    Dim espacionecesario As Long                    'espacion necesario para las carpetas 
    '    Dim numhistorias As Integer                     'Lectura del servidor cuando se calcula espacio necesario
    '    Dim numdocumentos As Integer                    'Lectura del servidor cuando se calcula espacio necesario
    '    Dim numimagenes As Integer                      'Lectura del servidor cuando se calcula espacio necesario
    '    Dim mensajeErR As String
    '    Dim carpetaRaizDestino As String                'carpeta local donde se almacenan todos los datos 
    '    'Dim numhistoriascopiadas As Integer = 0         'copiados en local 
    '    'Dim numdocumentoscopiados As Integer = 0        'copiados en local 
    '    'Dim numimagenescopiados As Integer = 0          'copiados en local 
    '    Dim lineasTXT As Integer = 0                    'lineas que hay en un fichero txt agrupado
    '    Dim lineasFichero As Integer = 0                'lineas que hay en un fichero txt 
    '    Dim historiaslote As Integer = 0                'historias lote, son las historias que hay en la base de datos para los distintos lotes 
    '    Dim documentoslote As Integer = 0                'son los documentos que hay en la base de datos para ese lote 


    '    Try


    '        Me.pizarra.Clear()
    '        Me.rtbficheroTXT.Clear()


    '        editor.escribir(pizarra, "-= INICIO DEL PROCESO DE CREACIÓN DVD =-", Color.Black, 12)


    '        'obtener el nombre de la compilacion 
    '        obtenerNombreCompilacion(Me.dgvCompilacion, volumen, intervalo, listalotes)

    '        'este es realmente el nombre del volumen, utilizamos la fecha y hora para indicarlo.
    '        volumen = Replace(Date.Now.ToShortDateString, "/", "") & Replace(Date.Now.ToLongTimeString, ":", "")

    '        editor.escribir(Me.pizarra, vbCr & "Volumen: " & volumen)
    '        editor.escribir(Me.pizarra, "Lotes: " & intervalo)
    '        editor.escribir(Me.pizarra, vbCr & "Comp. no hay misma hist. en lotes distintos: " & volumen)

    '        'comprobar que no hay una misma historias en dos lotes diferentes de la compilacion
    '        'esto produciria un error en la creacion del txt 

    '        If comprobarnohaymismahistoriaslotesdistintos(intervalo, historiasRepescomp) Then
    '            editor.escribir(Me.pizarra, "OK", Color.Green)
    '        Else
    '            editor.escribir(Me.pizarra, "Error", Color.Red)
    '            editor.escribir(Me.pizarra, "Las siguientes historias estan en lotes distintos " & historiasRepescomp, Color.Red)
    '            Exit Sub
    '        End If


    '        'seleccionar la ruta donde se va a copiar, comprobar lo que ocupa 
    '        'ver si hay espacio 

    '        If Me.fbdRtuaDVD.ShowDialog = Windows.Forms.DialogResult.OK Then

    '            rutaCompilacionDVD = Me.fbdRtuaDVD.SelectedPath
    '            Dim directorioinfo As New DirectoryInfo(rutaCompilacionDVD)
    '            carpetaRaizDestino = rutaCompilacionDVD
    '            espaciolibre = LibreriaCadenaProduccion.FuncionesGlobales.Carpetas.clsCarpetas.espaciolibreUnidadMB(directorioinfo.Root.Name.ToString)
    '            espaciolibreGB = (espaciolibre / 1024) / 1024 / 1024


    '            For i As Integer = 0 To listalotes.Count - 1

    '                espacionecesario += obtenerTamañoCarpetaLoteMB(listalotes(i), numhistorias, numdocumentos, numimagenes)


    '            Next


    '            editor.escribir(pizarra, "Calculando espacio necesario:")
    '            editor.escribir(pizarra, "Espacio libre en disco: " & espaciolibreGB & " GB")
    '            editor.escribir(pizarra, "Espacio necesario en disco: " & espacionecesario & "MB")

    '            If espaciolibre - espacionecesario > 0 Then
    '                editor.escribir(pizarra, "OK", Color.Green)
    '            Else
    '                editor.escribir(pizarra, "Err, no hay espacio suficiente en disco para crear DVD", Color.Red)
    '                Exit Sub
    '            End If

    '            editor.escribir(pizarra, vbCr & "Carpetas  en servidor: ")
    '            editor.escribir(pizarra, "Num historias: " & numhistorias)
    '            editor.escribir(pizarra, "Num documentos: " & numdocumentos)
    '            editor.escribir(pizarra, "Num imagenes: " & numimagenes)

    '            editor.escribir(pizarra, vbCr & "ruta destino : ")
    '            editor.escribir(pizarra, carpetaRaizDestino, Color.Blue)
    '            editor.escribir(pizarra, "carpeta : ")
    '            editor.escribir(pizarra, volumen, Color.Blue)
    '        Else
    '            editor.escribir(Me.pizarra, "proceso cancelado ", Color.Red)
    '            Exit Sub
    '        End If

    '        With Me.pgbprogresolotes
    '            .Value = 0
    '            .Step = 1
    '            .Refresh()
    '            .Maximum = listalotes.Count
    '        End With


    '        rutaCompilacionDVD = rutaCompilacionDVD & "\" & volumen

    '        'comprobar si ya hay una carpeta con ese nombre de compilacion.
    '        If Directory.Exists(rutaCompilacionDVD) Then
    '            MessageBox.Show("Err. ya existe una carpeta " & rutaCompilacionDVD)
    '            Exit Sub
    '        End If

    '        'comprobar si ya existe este volumen en la base de datos 

    '        'copiar las imagenes 
    '        For i As Integer = 0 To listalotes.Count - 1

    '            Me.lblprogresolotes.Text = "Proceso compilación: copiando carpetas para lote " & listalotes(i).ToString
    '            Me.pgbprogresolotes.Increment(1)

    '            If Not copiarTodasLasCarpetas(listalotes(i), rutaCompilacionDVD, volumen, contadorHistorias, contadordocumentos, contadorimagenes, mensajeErR) Then
    '                editor.escribir(pizarra, "Error al copiar los datos elimine la carpeta correspondiente a la compilacion, e intente realizar nuevamente el proceso", Color.Red)
    '                editor.escribir(pizarra, "Error: " & mensajeErR, Color.Red)
    '                Exit Sub
    '            End If

    '        Next

    '        Me.lblprogresolotes.Text = "Proceso compilación:"

    '        editor.escribir(pizarra, vbCr & "Carpetas  copiadas en destino: ")
    '        editor.escribir(pizarra, "historias copiadas : " & contadorHistorias)
    '        editor.escribir(pizarra, "documentos copiados: " & contadordocumentos)
    '        editor.escribir(pizarra, "imagenes copiadas : " & contadorimagenes)

    '        If (numhistorias - contadorHistorias <> 0) Or (numdocumentos - contadordocumentos) <> 0 Or (numimagenes - contadorimagenes) <> 0 Then
    '            editor.escribir(pizarra, "Error, no se han copiado todos los documentos", Color.Red)
    '            Exit Sub
    '        Else
    '            editor.escribir(pizarra, "OK", Color.Green)

    '        End If






    '        'copiar los txt 
    '        'For i As Integer = 0 To listalotes.Count - 1

    '        '    ficheroTXT = "Lote" & listalotes(i) & ".TXT"
    '        '    ficheroTXT = rutaLotes & ficheroTXT
    '        '    Dim aux As String = "Lote" & listalotes(i)

    '        '    lineasFichero = 0

    '        '    Me.rtbficheroTXT.AppendText(formateoTXT.leerContenidoFichero(ficheroTXT, lineasFichero))
    '        '    lineasTXT += lineasFichero

    '        '    Me.rtbficheroTXT.Text = Me.rtbficheroTXT.Text.Replace(aux, volumen)

    '        '    Me.rtbficheroTXT.Refresh()

    '        '    Me.lblprogresolotes.Text = "Proceso compilación: generando TXT para lote " & listalotes(i).ToString
    '        '    Me.pgbprogresolotes.Increment(1)
    '        'Next

    '        'Try


    '        '    If File.Exists(carpetaRaizDestino & "\" & volumen & ".TXT") Then
    '        '        File.Delete(carpetaRaizDestino & "\" & volumen & ".TXT")
    '        '    End If
    '        '    'guardar el fichero TXT
    '        '    Me.rtbficheroTXT.SaveFile(carpetaRaizDestino & "\" & volumen & ".TXT", RichTextBoxStreamType.PlainText)
    '        'Catch ex As Exception
    '        '    editor.escribir(pizarra, "Error al generar el fichero TXT " & ex.Message, Color.Red)
    '        '    Exit Sub
    '        'End Try


    '        'guardar el fichero TXT log 'guardar el log de todo el proceso, hay que ver donde lo metemos
    '        Dim ruta As String = rutaLotes & "\volumen\" & Replace(Date.Now.ToShortDateString, "/", "") & Replace(Date.Now.ToLongTimeString, ":", "") & ".rtf"
    '        Try
    '            Me.pizarra.SaveFile(ruta, RichTextBoxStreamType.RichText)
    '        Catch ex As Exception                
    '            editor.escribir(pizarra, "ALERTA!! El volumen se ha creado correcatamente pero no se ha podido guardar el log, compruebe que existe la ruta " & ruta & ex.Message, Color.Red)
    '        End Try


    '        'hay que ver el numero de filas que tiene esto 
    '        'comprobar que todo coincide con las consultas de la base de datos 
    '        editor.escribir(pizarra, vbCr & "Datos obtenidos de la base de datos: ")
    '        'actualizar la base de datos con las compilaciones


    '        Dim strSQL As String = "select distinct numhistoria from documentos where idlote in (" & intervalo & ") and ((barcodedet <> 1) or (barcodedet is null))"
    '        historiaslote = datosSQL.ejecutarSQLDirectaTable(strSQL, cadenaConexionProyecto).Rows.Count
    '        editor.escribir(pizarra, "historias copiadas : " & historiaslote)

    '        'editor.escribir(pizarra, "Lineas fichero texto: " & lineasTXT)
    '        strSQL = "select count(*) documentos from documentos where idlote in (" & intervalo & ") and ((barcodedet <> 1) or (barcodedet is null))"

    '        documentoslote = datosSQL.ejecutarSQLDirectaTable(strSQL, cadenaConexionProyecto).Rows(0).Item(0)
    '        editor.escribir(pizarra, "imagenes copiadas : " & documentoslote)

    '        editor.escribir(pizarra, vbCr & "Actualizando valores en la base de datos... ")

    '        If ActualizarDAtosVolumenBD(volumen, listalotes) Then
    '            editor.escribir(pizarra, vbCr & "valores actualizados correctamente ")
    '        Else
    '            editor.escribir(pizarra, vbCr & "No se han podido actualizar los valores para el volumen en la base de datos ", Color.Red)
    '        End If


    '        If (historiaslote <> contadorHistorias) Or (contadorimagenes <> documentoslote) Then

    '            editor.escribir(pizarra, "Hay algun descuadre entre los datos obtnidos de la exportacion y de la base de datos. Borre las carpetas de la exportación, vuelva a exportar los lotes y genere de nuevo el volumen.", Color.Red)
    '        Else
    '            editor.escribir(pizarra, "Proceso finalizado correctamente ", Color.Green)

    '        End If


    '    Catch ex As Exception
    '        editor.escribir(pizarra, "Error al generar el fichero TXT " & ex.Message, Color.Red)
    '    End Try
    'End Sub


    Private Sub cmdGenerarDVD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGenerarDVD.Click


        Dim rutaCompilacionDVD As String
        Dim ficheroTXT As String
        Dim contenidoficheroTXT As String
        Dim contadorHistorias As Integer
        Dim contadordocumentos As Integer
        Dim contadorimagenes As Integer
        Dim intervalo As String
        Dim volumen As String                           'nombre de la carpeta donde se deja todo 
        Dim listalotes As String()                      'lista de los lotes que componen el volumen
        Dim historiasRepescomp As String                'numero de historias que estan en dos lotes distintos dentro del mismo volumen
        Dim espaciolibre As Long
        Dim espaciolibreGB As Long                      'espacio libre en el disco carpeta destino 
        Dim espacionecesario As Long                    'espacion necesario para las carpetas 
        Dim numhistorias As Integer                     'Lectura del servidor cuando se calcula espacio necesario
        Dim numdocumentos As Integer                    'Lectura del servidor cuando se calcula espacio necesario
        Dim numimagenes As Integer                      'Lectura del servidor cuando se calcula espacio necesario
        Dim mensajeErR As String
        Dim carpetaRaizDestino As String                'carpeta local donde se almacenan todos los datos 
        'Dim numhistoriascopiadas As Integer = 0         'copiados en local 
        'Dim numdocumentoscopiados As Integer = 0        'copiados en local 
        'Dim numimagenescopiados As Integer = 0          'copiados en local 
        Dim lineasTXT As Integer = 0                    'lineas que hay en un fichero txt agrupado
        Dim lineasFichero As Integer = 0                'lineas que hay en un fichero txt 
        Dim historiaslote As Integer = 0                'historias lote, son las historias que hay en la base de datos para los distintos lotes 
        Dim documentoslote As Integer = 0                'son los documentos que hay en la base de datos para ese lote 
        Dim historiasLoteEnIntervalo As DataTable
        Dim secuencialVolumen As Integer
        Dim contadorHistoriasVolumen As Integer = 0
        Dim agrupacionHistoriasVolumen As Integer = 10
        Dim ficheroTXThistoria As String
        Dim identificador As DataTable
        Dim idvolumen As Integer

        Try


            Me.pizarra.Clear()
            Me.rtbficheroTXT.Clear()


            editor.escribir(pizarra, "-= INICIO DEL PROCESO DE CREACIÓN DVD =-", Color.Black, 12)


            'obtener el nombre de la compilacion 
            obtenerNombreCompilacion(Me.dgvCompilacion, volumen, intervalo, listalotes)

           

            'If comprobarnohaymismahistoriaslotesdistintos(intervalo, historiasRepescomp) Then
            '    editor.escribir(Me.pizarra, "OK", Color.Green)
            'Else
            '    editor.escribir(Me.pizarra, "Error", Color.Red)
            '    editor.escribir(Me.pizarra, "Las siguientes historias estan en lotes distintos " & historiasRepescomp, Color.Red)
            '    Exit Sub
            'End If


            If comprobarcorrespondenciaepisodios(intervalo, historiasRepescomp) Then
                editor.escribir(Me.pizarra, "Epis OK ", Color.Green)
            Else
                editor.escribir(Me.pizarra, "Error", Color.Red)
                editor.escribir(Me.pizarra, "Las siguientes historias tienen un episodio que no se corresponde con los del cliente" & historiasRepescomp, Color.Red)
            End If

            'seleccionar la ruta donde se va a copiar, comprobar lo que ocupa 
            'ver si hay espacio 

            If Me.fbdRtuaDVD.ShowDialog = Windows.Forms.DialogResult.OK Then

                rutaCompilacionDVD = Me.fbdRtuaDVD.SelectedPath
                Dim directorioinfo As New DirectoryInfo(rutaCompilacionDVD)
                carpetaRaizDestino = rutaCompilacionDVD
                espaciolibre = LibreriaCadenaProduccion.FuncionesGlobales.Carpetas.clsCarpetas.espaciolibreUnidadMB(directorioinfo.Root.Name.ToString)
                espaciolibreGB = (espaciolibre / 1024) / 1024 / 1024


                For i As Integer = 0 To listalotes.Count - 1

                    espacionecesario += obtenerTamañoCarpetaLoteMB(listalotes(i), numhistorias, numdocumentos, numimagenes)


                Next


                editor.escribir(pizarra, "Calculando espacio necesario:")
                editor.escribir(pizarra, "Espacio libre en disco: " & espaciolibreGB & " GB")
                editor.escribir(pizarra, "Espacio necesario en disco: " & espacionecesario & "MB")

                If espaciolibre - espacionecesario > 0 Then
                    editor.escribir(pizarra, "OK", Color.Green)
                Else
                    editor.escribir(pizarra, "Err, no hay espacio suficiente en disco para crear DVD", Color.Red)
                    Exit Sub
                End If

                editor.escribir(pizarra, vbCr & "Carpetas  en servidor: ")
                editor.escribir(pizarra, "Num historias: " & numhistorias)
                editor.escribir(pizarra, "Num documentos: " & numdocumentos)
                editor.escribir(pizarra, "Num imagenes: " & numimagenes)

                editor.escribir(pizarra, vbCr & "ruta destino : ")
                editor.escribir(pizarra, carpetaRaizDestino, Color.Blue)
                editor.escribir(pizarra, "carpeta : ")
                editor.escribir(pizarra, volumen, Color.Blue)
            Else
                editor.escribir(Me.pizarra, "proceso cancelado ", Color.Red)
                Exit Sub
            End If

            With Me.pgbprogresolotes
                .Value = 0
                .Step = 1
                .Refresh()
                .Maximum = listalotes.Count
            End With

            '**************************************************************************************************************
            '       Aquí es donde esta todo cuadrado 
            '**************************************************************************************************************

            historiasLoteEnIntervalo = obtenerHistoriasIntervaloLotes(intervalo, historiasRepescomp)

            secuencialVolumen = 0
            contadorHistoriasVolumen = 0
            volumen = "C" & Replace(Date.Now.ToShortDateString, "/", "") & "_" & Format(secuencialVolumen, "00#")
            Debug.Print(volumen)
            ficheroTXT = volumen & ".TXT"
            Dim strsql As String = "INSERT INTO VOLUMEN (nombre,fechacreacion) values ('" & volumen & "',getdate())"
            datosSQL.ejecutaSQLEjecucion(strsql, cadenaConexionProyecto, , False)

            Me.rtbficheroTXT.Clear()

            If Directory.Exists(rutaCompilacionDVD & "\" & volumen) Then
                MessageBox.Show("Err. ya existe una carpeta " & rutaCompilacionDVD & " no se puede crear la carpeta para el volumen. Elimine ruta compilacion y reinicie el proceso")
                Exit Sub
            Else
                Directory.CreateDirectory(rutaCompilacionDVD & "\" & volumen)
            End If

            For Each historialote As DataRow In historiasLoteEnIntervalo.Rows

                If contadorHistoriasVolumen = agrupacionHistoriasVolumen Then
                    contadorHistoriasVolumen = 0
                    secuencialVolumen += 1
                    volumen = "C" & Replace(Date.Now.ToShortDateString, "/", "") & "_" & Format(secuencialVolumen, "00#")
                    Debug.Print(volumen)
                    strsql = "INSERT INTO VOLUMEN (nombre,fechacreacion) values ('" & volumen & "',getdate())"
                    datosSQL.ejecutaSQLEjecucion(strsql, cadenaConexionProyecto, , False)

                    ficheroTXT = "Lote" & volumen & ".TXT"
                    Me.rtbficheroTXT.Clear()

                    If Directory.Exists(rutaCompilacionDVD & "\" & volumen) Then
                        MessageBox.Show("Err. ya existe una carpeta " & rutaCompilacionDVD & " no se puede crear la carpeta para el volumen. Elimine ruta compilacion y reinicie el proceso")
                        Exit Sub
                    End If

                End If

                If Not copiarDocumentosHistoria(historialote.Item("idlote"), historialote.Item("numhistoria"), rutaCompilacionDVD, volumen, contadorHistorias, contadordocumentos, contadorimagenes, mensajeErR) Then
                    editor.escribir(pizarra, "Error al copiar los datos elimine la carpeta correspondiente a la compilacion, e intente realizar nuevamente el proceso", Color.Red)
                    editor.escribir(pizarra, "Error: " & mensajeErR, Color.Red)
                    Exit Sub
                Else
                    'aqui tenemos que empezar a copiar los datos del fichero txt 
                    lineasFichero = 0
                    ficheroTXThistoria = rutaLotes & "Lote" & historialote.Item("idlote") & "\" & historialote.Item("idlote") & "NHC" & historialote.Item("numhistoria") & ".TXT"
                    Me.rtbficheroTXT.AppendText(formateoTXT.leerContenidoFichero(ficheroTXThistoria, lineasFichero))
                    lineasTXT += lineasFichero
                    'If File.Exists(carpetaRaizDestino & "\" & volumen & ".TXT") Then
                    '    File.Delete(carpetaRaizDestino & "\" & volumen & ".TXT")
                    'End If
                    'guardar el fichero TXT

                    Me.rtbficheroTXT.Text = Me.rtbficheroTXT.Text.Replace(historialote.Item("idlote") & "NHC" & historialote.Item("numhistoria"), volumen)
                    Me.rtbficheroTXT.SaveFile(carpetaRaizDestino & "\" & volumen & ".TXT", RichTextBoxStreamType.PlainText)

                End If


                identificador = datosSQL.ejecutarSQLDirectaTable("select idvolumen from volumen where nombre like '" & volumen & "'", cadenaConexionProyecto)

                If identificador.Rows.Count > 0 Then
                    idVolumen = identificador.Rows(0).Item("idvolumen")

                    strsql = "INSERT INTO LOTESVOLUMEN (idvolumen,idlote,numhistoria) VALUES (" & idvolumen & "," & historialote.Item("idlote") & "," & historialote.Item("numhistoria") & ")"
                    datosSQL.ejecutaSQLEjecucion(strsql, cadenaConexionProyecto, , False)

                End If

                contadorHistoriasVolumen += 1
                Debug.Print(contadorHistoriasVolumen)
            Next


        Catch ex As Exception
            editor.escribir(pizarra, "Error al generar el fichero TXT " & ex.Message, Color.Red)
        End Try
    End Sub


    Private Function ActualizarDAtosVolumenBDHistoria(ByVal volumen As String, ByRef listalotes As String()) As Boolean

        Dim identificador As DataTable
        Dim idVolumen As Integer

        Dim strsql As String = "INSERT INTO VOLUMEN (nombre,fechacreacion) values ('" & volumen & "',getdate())"
        If datosSQL.ejecutaSQLEjecucion(strsql, cadenaConexionProyecto, , False) Then

            identificador = datosSQL.ejecutarSQLDirectaTable("select idvolumen from volumen where nombre like '" & volumen & "'", cadenaConexionProyecto)

            If identificador.Rows.Count > 0 Then
                idVolumen = identificador.Rows(0).Item("idvolumen")


                Dim conexion As SqlConnection = Nothing
                Dim cmdSQL As SqlCommand
                Dim Transaccion As SqlTransaction = Nothing

                Dim correcto As Boolean = False

                Try

                    conexion = New SqlConnection(cadenaConexionProyecto)
                    conexion.Open()

                    Transaccion = conexion.BeginTransaction()


                    For i As Integer = 0 To listalotes.Count - 1

                        strsql = "INSERT INTO LOTESVOLUMEN (idvolumen,idlote) VALUES (" & idVolumen & "," & listalotes(i) & ")"

                        cmdSQL = New SqlCommand(strsql, conexion)
                        cmdSQL.Transaction = Transaccion
                        cmdSQL.ExecuteNonQuery()

                    Next

                    Transaccion.Commit()
                    correcto = True
                Catch excep As SqlException
                    System.Windows.Forms.MessageBox.Show(excep.Message.ToString)
                    Transaccion.Rollback()
                Catch ex As Exception
                    System.Windows.Forms.MessageBox.Show(ex.Message.ToString)
                    Transaccion.Rollback()
                Finally
                    If conexion.State = ConnectionState.Open Then conexion.Close()
                End Try

                Return correcto
            Else
                Return False
            End If

        End If

    End Function

    Private Function comprobarnohaymismahistoriaslotesdistintos(ByVal intervalo As String, ByRef historias As String) As Boolean

        Dim strSQLLotesExpNocomp As String
        Dim datos As DataTable


        strSQLLotesExpNocomp = " SELECT DISTINCT NumHistoria, idlote " _
         & " FROM DOCUMENTOS d1 " _
         & " WHERE (idlote IN (" & intervalo & ")) AND EXISTS " _
         & "(SELECT  d2.numhistoria " _
         & " FROM documentos d2 " _
         & " WHERE  d1.numhistoria = d2.numhistoria AND d2.idlote IN (" & intervalo & ") AND d1.idlote <> d2.idlote)"

        Debug.Print(strSQLLotesExpNocomp)

        datos = datosSQL.ejecutarSQLDirectaTable(strSQLLotesExpNocomp, cadenaConexionProyecto)


        If datos.Rows.Count > 0 Then

            For Each registro As DataRow In datos.Rows

                historias &= vbCr & " nhc " & registro.Item("numhistoria").ToString & " lote " & registro.Item("idlote").ToString

            Next
            Return False

        Else
            Return True
        End If

    End Function


    

    Private Function comprobarcorrespondenciaepisodios(ByVal intervalo As String, ByRef historias As String) As Boolean

        Dim strSQLLotesExpNocomp As String
        Dim datos As DataTable


        
        strSQLLotesExpNocomp = "select * " _
                & " from documentos d " _
                & " where idlote in (" & intervalo & ")" _
                & " and not exists (select ec.numicu from episodiosC ec  where d.numhistoria = ec.numhistoria and d.numicu = ec.numicu ) " _
                & " and not exists (select eh.numicu from episodiosH eh  where d.numhistoria = eh.numhistoria and d.numicu = eh.numicu )" _
                & " and not exists (select eq.numicu from episodiosq eq  where d.numhistoria = eq.numhistoria and d.numicu = eq.numicu ) " _
                & " and not exists (select eu.numicu from episodiosu eu  where d.numhistoria = eu.numhistoria and d.numicu = eu.numicu ) " _
                & " And numicu <> 999"

        Debug.Print(strSQLLotesExpNocomp)

        datos = datosSQL.ejecutarSQLDirectaTable(strSQLLotesExpNocomp, cadenaConexionProyecto)


        If datos.Rows.Count > 0 Then

            For Each registro As DataRow In datos.Rows

                historias &= vbCr & " nhc " & registro.Item("numhistoria").ToString & " lote " & registro.Item("idlote").ToString

            Next
            Return False

        Else
            Return True
        End If

    End Function


    Private Function obtenerHistoriasIntervaloLotes(ByVal intervalo As String, ByRef historias As String) As DataTable

        Dim strSQLLotesExpNocomp As String
        Dim datos As DataTable


        strSQLLotesExpNocomp = " SELECT  NumHistoria, idlote " _
         & " FROM DOCUMENTOS " _
         & " WHERE idlote IN (" & intervalo & ") group by numhistoria,idlote order by idlote"

        Debug.Print(strSQLLotesExpNocomp)

        datos = datosSQL.ejecutarSQLDirectaTable(strSQLLotesExpNocomp, cadenaConexionProyecto)


        Return datos

    End Function




    Private Function obtenerTamañoCarpetaLoteMB(ByVal idlote As Integer, Optional ByRef contadorHistorias As Integer = 0, Optional ByRef contadordocumentos As Integer = 0, Optional ByRef contadorimagenes As Integer = 0) As String



        Dim datosarchivo As FileInfo
        Dim rutalote As String = ""
        Dim rutahistorias As String = ""
        Dim rutadocumento As String = ""
        Dim tamañoCarpeta As Long = 0

        Try

            rutalote = rutaLotes & "Lote" & idlote
            Debug.Print(rutalote)
            For Each historias As String In Directory.GetDirectories(rutalote)
                contadorHistorias += 1


                For Each documento As String In Directory.GetDirectories(historias)
                    contadordocumentos += 1

                    'Debug.Print(documento)
                    For Each imagen As String In Directory.GetFiles(documento)
                        contadorimagenes += 1

                        datosarchivo = New FileInfo(imagen)
                        tamañoCarpeta += datosarchivo.Length


                    Next

                Next
            Next

            tamañoCarpeta = (tamañoCarpeta / 1024) / 1024
        Catch ex As Exception
            editor.escribir(Me.pizarra, "Error al calcular el tamaño de las carpetas.", Color.Red)
        End Try

        Return tamañoCarpeta

    End Function


    Private Sub obtenerNombreCompilacion(ByVal lotes As DataGridView, ByRef volumen As String, ByRef intervalo As String, ByRef listalotes As String())


        volumen = "vol"
        intervalo = ""
        Dim contador As Integer = 0
        ReDim listalotes(lotes.SelectedRows.Count - 1)

        For Each lote As DataGridViewRow In lotes.SelectedRows


            volumen &= "_" & lote.Cells(0).Value
            If contador = 0 Then
                intervalo &= lote.Cells(0).Value
            Else
                intervalo &= "," & lote.Cells(0).Value
            End If
            listalotes(contador) = lote.Cells(0).Value
            contador += 1
        Next

    End Sub


    Private Function copiarTodasLasCarpetas(ByVal idlote As Integer, ByVal rutacompilacion As String, ByVal volumen As String, Optional ByRef contadorHistorias As Integer = 0, Optional ByRef contadordocumentos As Integer = 0, Optional ByRef contadorimagenes As Integer = 0, Optional ByRef mensajeERR As String = "") As Boolean

        'With Me.pgbProgreso
        '    .Value = 0
        '    .Step = 1
        '    .Refresh()
        '    .Maximum = 
        'End With


        Dim datosarchivo As FileInfo
        Dim rutalote As String = ""
        Dim rutahistoriasDestino As String = ""
        Dim rutadocumentoDestino As String = ""
        Dim tamañoCarpeta As Long = 0
        Dim rutadestino As String
        Dim infoDirectorio As DirectoryInfo
        'vamos a ver si tenemos creada la ruta de la compilación.
        Dim rutaimagendestino As String



        Try


            rutalote = rutaLotes & "Lote" & idlote
            Debug.Print(rutalote)
            For Each historia As String In Directory.GetDirectories(rutalote)
                contadorHistorias += 1
                infoDirectorio = New DirectoryInfo(historia)
                'modificado parar que copie en la carpeta con el nombre que toca 
                rutahistoriasDestino = rutacompilacion & "\" & idlote & "NHC" & infoDirectorio.Name
                If Not Directory.Exists(rutahistoriasDestino) Then

                    Directory.CreateDirectory(rutahistoriasDestino)
                    ''aqui añadimos la parte que copiamos el documentos txt 

                    Debug.Print(rutalote & "\" & idlote & "NHC" & infoDirectorio.Name & ".txt")
                    Debug.Print(rutacompilacion & "\" & idlote & "NHC" & infoDirectorio.Name & ".txt")
                    If File.Exists(rutalote & "\" & idlote & "NHC" & infoDirectorio.Name & ".txt") Then
                        File.Copy(rutalote & "\" & idlote & "NHC" & infoDirectorio.Name & ".txt", rutacompilacion & "\" & idlote & "NHC" & infoDirectorio.Name & ".txt")
                    Else
                        'error no se ha encontrado el fichero txt para este caso
                        MessageBox.Show("Error, los lotes no se han exportado correctamente faltan ficheros TXT con datos " & vbCr & rutalote & "\" & idlote & "NHC" & infoDirectorio.Name & ".txt")
                        mensajeERR = "Error, los lotes no se han exportado correctamente faltan ficheros TXT con datos " & vbCr & rutalote & "\" & idlote & "NHC" & infoDirectorio.Name & ".txt"
                        Return False
                    End If



                Else
                    'es imposible que la carpeta ya este creada puesto que ya se ha comprobado 
                    'que no hay una historia en dos lotes distintos pero por si las moscas
                    mensajeERR = "Se ha intentado crear la carpeta " & rutacompilacion & "\" & historia & " pero ya existía"
                    Return False
                End If

                For Each documento As String In Directory.GetDirectories(historia)
                    contadordocumentos += 1
                    infoDirectorio = New DirectoryInfo(documento)
                    rutadocumentoDestino = rutahistoriasDestino & "\" & infoDirectorio.Name
                    'Debug.Print(documento)
                    If Not Directory.Exists(rutadocumentoDestino) Then
                        Directory.CreateDirectory(rutadocumentoDestino)
                    Else
                        'es imposible que la carpeta ya este creada puesto que ya se ha comprobado 
                        'que no hay una historia en dos lotes distintos pero por si las moscas
                        mensajeERR = "Se ha intentado crear la carpeta " & rutadocumentoDestino & " pero ya existía"
                        Return False
                    End If

                    With Me.pgbProgreso
                        .Value = 0
                        .Step = 1
                        .Refresh()
                        .Maximum = Directory.GetFiles(documento).Count
                    End With

                    For Each imagen As String In Directory.GetFiles(documento)


                        contadorimagenes += 1
                        datosarchivo = New FileInfo(imagen)
                        rutaimagendestino = rutadocumentoDestino & "\" & datosarchivo.Name
                        File.Copy(imagen, rutaimagendestino, True)

                        Me.pgbProgreso.Increment(1)

                        Me.lblprogreso.Text = rutaimagendestino
                        Application.DoEvents()

                    Next

                    With Me.pgbProgreso
                        .Value = 0
                        .Refresh()
                    End With
                    Me.lblprogreso.Text = "Progreso compilación"

                Next
            Next


        Catch ex As Exception
            editor.escribir(Me.pizarra, "Error al copiar los documentos en la carpeta destino." & ex.Message, Color.Red)
            Return False
        End Try

        Return True

    End Function


    Private Function copiarDocumentosHistoria(ByVal idlote As Integer, ByVal historia As String, ByVal rutacompilacion As String, ByVal volumen As String, Optional ByRef contadorHistorias As Integer = 0, Optional ByRef contadordocumentos As Integer = 0, Optional ByRef contadorimagenes As Integer = 0, Optional ByRef mensajeERR As String = "") As Boolean

        'With Me.pgbProgreso
        '    .Value = 0
        '    .Step = 1
        '    .Refresh()
        '    .Maximum = 
        'End With


        Dim datosarchivo As FileInfo
        Dim rutalote As String = ""
        Dim rutahistoriasDestino As String = ""
        Dim rutadocumentoDestino As String = ""
        Dim tamañoCarpeta As Long = 0
        Dim rutadestino As String
        Dim infoDirectorio As DirectoryInfo
        'vamos a ver si tenemos creada la ruta de la compilación.
        Dim rutaimagendestino As String
        Dim rutahistoria As String



        Try


            rutalote = rutaLotes & "Lote" & idlote
            rutahistoria = rutalote & "\" & historia
            Debug.Print(rutalote)
            Debug.Print(rutahistoria)


            contadorHistorias += 1
            infoDirectorio = New DirectoryInfo(historia)
            'modificado parar que copie en la carpeta con el nombre que toca 
            rutahistoriasDestino = rutacompilacion & "\" & volumen & "\" & infoDirectorio.Name
            'con esto creas la carpeta para la historia que quieres copiar 

            If Not Directory.Exists(rutahistoriasDestino) Then
                Directory.CreateDirectory(rutahistoriasDestino)
                ''aqui añadimos la parte que copiamos el documentos txt 
            Else
                'es imposible que la carpeta ya este creada puesto que ya se ha comprobado 
                'que no hay una historia en dos lotes distintos pero por si las moscas
                mensajeERR = "Se ha intentado crear la carpeta " & rutacompilacion & "\" & historia & " pero ya existía"
                Return False
            End If

            'copiando todas las carpetad alias documentos de la historia en la carpeta de la historia destino 

            For Each documento As String In Directory.GetDirectories(rutahistoria)
                contadordocumentos += 1
                infoDirectorio = New DirectoryInfo(documento)
                rutadocumentoDestino = rutahistoriasDestino & "\" & infoDirectorio.Name
                'Debug.Print(documento)
                If Not Directory.Exists(rutadocumentoDestino) Then
                    Directory.CreateDirectory(rutadocumentoDestino)
                Else
                    'es imposible que la carpeta ya este creada puesto que ya se ha comprobado 
                    'que no hay una historia en dos lotes distintos pero por si las moscas
                    mensajeERR = "Se ha intentado crear la carpeta " & rutadocumentoDestino & " pero ya existía"
                    Return False
                End If

                With Me.pgbProgreso
                    .Value = 0
                    .Step = 1
                    .Refresh()
                    .Maximum = Directory.GetFiles(documento).Count
                End With

                For Each imagen As String In Directory.GetFiles(documento)


                    contadorimagenes += 1
                    datosarchivo = New FileInfo(imagen)
                    rutaimagendestino = rutadocumentoDestino & "\" & datosarchivo.Name
                    File.Copy(imagen, rutaimagendestino, True)

                    Me.pgbProgreso.Increment(1)

                    Me.lblprogreso.Text = rutaimagendestino
                    Application.DoEvents()

                Next

                With Me.pgbProgreso
                    .Value = 0
                    .Refresh()
                End With
                Me.lblprogreso.Text = "Progreso compilación"

            Next

            'Fin !! ya hemos copiado todas las carpetas y documentos de la historia. 

        Catch ex As Exception
            editor.escribir(Me.pizarra, "Error al copiar los documentos en la carpeta destino." & ex.Message, Color.Red)
            Return False
        End Try

        Return True

    End Function

    Private Sub cmbListado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbListado.Click
        Dim _frmconsultarvolumenes As New frmConsultarVolumenes(cadenaConexionProyecto)
        _frmconsultarvolumenes.ShowDialog()
    End Sub


End Class