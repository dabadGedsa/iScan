Imports accesoDatos = LibreriaCadenaProduccion.Datos.GeneralSQL.clsAccesoDatosSQL
Imports accesoDAtosLote = LibreriaCadenaProduccion.Datos.Produccion.cadenaproduccion.clsAccesoDatosLote
Imports System.IO
Imports System.Windows.Forms
Imports AccesoDAtosProd = LibreriaCadenaProduccion.Datos.Produccion.clsAccesoDatosProduccion
Imports editor = LibreriaCadenaProduccion.TXT.clsFormato
Imports System.Data.Sql
Imports System.Data.SqlClient


Namespace Entidades

    Namespace Operaciones


        Public Class clsOperacionesLote


#Region "Importar lote"


            Shared barcode As SoftekBarcodeLib2.BarcodeReader


            Private Shared Sub InitBarcode()

                ' Turn on the barcode types you want to read.
                ' Turn off the barcode types you don't want to read (this will increase the speed of your application)
                barcode.ReadCode128 = True
                barcode.ReadCode39 = True
                barcode.ReadCode25 = True
                barcode.ReadEAN13 = True
                barcode.ReadEAN8 = True
                barcode.ReadUPCA = True
                barcode.ReadUPCE = True
                barcode.ReadCodabar = False
                barcode.ReadPDF417 = True

                barcode.MultipleRead = False

                ' Noise reduction takes longer but can make it possible to read some difficult barcodes
                ' When using noise reduction a typical value is 10 - the smaller the value the more effect it has.
                ' A zero value turns off noise reduction. 
                ' If you use NoiseReduction then the ScanDirection mask must be either only horizontal or only
                ' vertical (i.e 1, 2, 4, 8, 5 or 10).
                ' barcode.NoiseReduction = 0

                ' You may need to set a small quiet zone if your barcodes are close to text and pictures in the image.
                ' A value of zero uses the default.
                barcode.QuietZoneSize = 0

                ' LineJump controls the frequency at which scan lines in an image are sampled.
                ' The default is 9 - decrease this for difficult barcodes.
                barcode.LineJump = 1

                ' You can restrict your search to a particular area of the image if you wish.
                ' barcode.SetScanRect(TopLeftX, TopLeftY, BottomRightX, BottomRightY, 0)

                ' Set the direction that the barcode reader should scan for barcodes
                ' The value is a mask where 1 = Left to Right, 2 = Top to Bottom, 3 = Right To Left, 4 = Bottom to Top
                barcode.ScanDirection = 1

                ' SkewTolerance controls the angle of skew that the barcode toolkit will tolerate. By default
                ' the toolkit checks for barcodes along horizontal and vertical lines in an image. This works 
                ' OK for most barcodes because even at an angle it is possible to pass a line through the entire
                ' length. SkewTolerance can range from 0 to 5 and allows for barcodes skewed to an angle of 45
                ' degrees.
                ' barcode.SkewTolerance = 0

                ' ColorThreshold is used by the toolkit to determine whether a pixel in a color image should be
                ' considered as black or white. This property can range in value from 0 to 255, with a 
                ' default of 128. Use a low value for dark images and a high value for bright images.
                barcode.ColorThreshold = 128

                ' MaxLength and MinLength can be used to specify the number of characters you expect to
                ' find in a barcode. This can be useful to increase accuracy or if you wish to ignore some
                ' barcodes in an image.
                barcode.MinLength = 4
                barcode.MaxLength = 999

                ' When the toolkit scans an image it records the number of hits it gets for each barcode that
                ' MIGHT be in the image. If the hits recorded for any of the barcodes are >= PrefOccurrence
                ' then only these barcodes are returned. Otherwise, any barcode whose hits are >= MinOccurrence
                ' are reported. If you have a very poor quality image then try setting MinOccurrence to 1, but you
                ' may find that some false positive results are returned.
                'barcode.MinOccurrence = 2
                'barcode.PrefOccurrence = 4

                ' barcode.Pattern = "^F[0-9][0-9][0-9][0-9][0-9][0-9]$"
                ' barcode.ExtendedCode39 = True
            End Sub



            Shared Function ImportarLoteBD(ByVal idLoteCerrar As Integer, ByVal idproyecto As String, ByVal cadenaconexionAdministrativos As String, ByVal cadenaconexionProyecto As String, ByRef pbCerrarLote As ProgressBar, ByRef pizarra As RichTextBox) As Boolean

                Dim NumCodBarrasEncontrados As Integer
                Dim coleccionItemsInsertar As New Collection
                Dim coleccionItemsInsertarCodigoBarras As New Collection
                Dim utilizaCaratulas As Boolean = False
                Dim contadorPagina As Integer = 0
                Dim metadatos As FileInfo
                Dim estructuraBarCode As DataTable
                Dim camposEstructuraBarCode As DataTable
                'Dim cabeceraBarcode As String
                'Dim imagen As Image
                Dim rutaimagenes As String
                Dim datatable As String
                Dim arrastras As Boolean = True

                Dim idlote As New LibreriaCadenaProduccion.Entidades.clsItem
                Dim pagina As New LibreriaCadenaProduccion.Entidades.clsItem
                Dim NomarchivoTif As New LibreriaCadenaProduccion.Entidades.clsItem
                Dim marcaBarcodeDetectado As New LibreriaCadenaProduccion.Entidades.clsItem
                Dim nomFicheroTif As String
                '

                Try

                    barcode = New SoftekBarcodeLib2.BarcodeReader
                    InitBarcode()

                    editor.centrado(pizarra, "inicio proceso de importación del lote " & idLoteCerrar)

                    rutaimagenes = AccesoDAtosProd.ObtenerRutaImagenes(idproyecto, idLoteCerrar, cadenaconexionAdministrativos)

                    'miramos que los documetnos no tengan saltos, dicese de que alguien ha metido la mano y 
                    'ha eliminado una imagen 
                    'clsOperacionesLoteRenombrar.estaelloteOrdenado(rutaimagenes)
                    editor.escribir(pizarra, "El lote esta ordenado")

                    'Eliminamos todos los registros de la tabla documentos si ya hay registros insertados para este lote 
                    accesoDatos.ejecutaSQLEjecucion("DELETE FROM DOCUMENTOSINCIDENCIAS WHERE (IdDocumento IN (SELECT iddocumento FROM documentos WHERE  idLote= " & idLoteCerrar & "))", cadenaconexionProyecto)
                    accesoDatos.ejecutaSQLEjecucion("DELETE documentos  WHERE  idLote= " & idLoteCerrar & "", cadenaconexionProyecto)


                    'Obtener los datos de la esctructura del codigo de barras, si no tiene el proyecto no utiliza caratulas 
                    estructuraBarCode = accesoDatos.ejecutarSQLDirectaTable("SELECT confB.idestructura,confB.inicioBarcode,confB.cortarCAbecera FROM configuracionbarcode confB WHERE confB.idproyecto =" & idproyecto, cadenaconexionAdministrativos)

                    'identificamos si el proyecto utiliza o no caraturalas o codigos de barras 
                    If estructuraBarCode.Rows.Count > 0 Then

                        'marcamos que el proyecto utiliza codigos barras 
                        utilizaCaratulas = True

                        'Inicializar los datos del codigo de barras, si tiene estructura definida 
                        incializarDAtosCodigoBarras(coleccionItemsInsertarCodigoBarras, estructuraBarCode)

                    End If


                    'Inicializar los datos del registro

                    idlote = New LibreriaCadenaProduccion.Entidades.clsItem

                    idlote.Nombre = "idLote"
                    idlote.valor = idLoteCerrar
                    idlote.texto = 0

                    coleccionItemsInsertar.Add(idlote)

                    contadorPagina = 0

                    pbCerrarLote.Value = 0
                    pbCerrarLote.Minimum = 0
                    pbCerrarLote.Maximum = Directory.GetFiles(rutaimagenes, "*.TIF").Count
                    pbCerrarLote.Step = 1

                    For Each archivo As String In Directory.GetFiles(rutaimagenes, "*.TIF")
                        metadatos = New FileInfo(archivo)


                        Application.DoEvents()
                        pbCerrarLote.Increment(1)

                        'inicializamos la pagina 
                        pagina = New LibreriaCadenaProduccion.Entidades.clsItem
                        pagina.Nombre = "pagina"
                        pagina.texto = 0
                        pagina.valor = contadorPagina + 1
                        Debug.Print("pagina" & pagina.valor)


                        coleccionItemsInsertar.Add(pagina, pagina.Nombre)

                        NomarchivoTif = New LibreriaCadenaProduccion.Entidades.clsItem
                        NomarchivoTif.Nombre = "NomArchivoTIF"
                        NomarchivoTif.texto = 1


                        nomFicheroTif = "IML" & Format(Val(pagina.valor), "0000#") & ".TIF"
                        Debug.Print(nomFicheroTif.ToUpper)
                        Debug.Print(metadatos.Name.ToUpper)

                        If metadatos.Name.ToUpper <> nomFicheroTif.ToUpper Then

                            File.Move(rutaimagenes & "\" & metadatos.Name, rutaimagenes & "\" & nomFicheroTif)
                            NomarchivoTif.valor = nomFicheroTif

                        Else
                            NomarchivoTif.valor = metadatos.Name
                        End If

                        If contadorPagina = 107 Then
                            Debug.Print(contadorPagina)
                        End If



                        coleccionItemsInsertar.Add(NomarchivoTif, NomarchivoTif.Nombre)

                        'si utiliza codigos de barras 
                        If utilizaCaratulas Then
                            'detectar los codigos de barras 
                            Try


                                NumCodBarrasEncontrados = barcode.ScanBarCode(archivo)

                            Catch ex As Exception
                                NumCodBarrasEncontrados = 0
                            End Try

                            Debug.Print(NumCodBarrasEncontrados)

                            'si el numero de codigos de barras encontrados no es igual a 1 no estamos con una caratula 
                            'comprobamos que la cabecera del codigo de barras coincida con la del codigo de barras encontrado

                            ' If NumCodBarrasEncontrados = 1 And Trim(estructuraBarCode.Rows(0).Item("inicioBarcode").ToString) = Mid(barcode.GetBarString(1), 1, Len(Trim(estructuraBarCode.Rows(0).Item("inicioBarcode").ToString))) Then

                            If NumCodBarrasEncontrados >= 1 Then

                                'elimina los items del caso anterior esto puede ser una putada si detecta codigos de barras que no son 
                                'ten en cuenta que sin detecta un solo codigo de barras copia de lo anterior 
                                'coleccionItemsInsertarCodigoBarras.Clear()

                                For contador As Integer = 1 To NumCodBarrasEncontrados 'recorridio por cada uno de los codigos de barras encontrados en los documentos 

                                    Debug.Print(barcode.GetBarString(contador))

                                    For Each estructuraBC As DataRow In estructuraBarCode.Rows 'recorrido por cada una de las estructuras del codigo de barras 

                                        Debug.Print(Trim(estructuraBC.Item("inicioBarcode").ToString))
                                        Debug.Print(Mid(barcode.GetBarString(contador), 1, Len(Trim(estructuraBC.Item("inicioBarcode").ToString))))

                                        If Trim(estructuraBC.Item("inicioBarcode").ToString) = Mid(barcode.GetBarString(contador), 1, Len(Trim(estructuraBC.Item("inicioBarcode").ToString))) Then

                                            'modificacion para que no se eliminen los datos del codigo de barras anterior al detectar un codigo de barras que no es 
                                            'de la caratula 
                                            If Not arrastras Then 'lo vamos a modificar para el caso en el que tiene que detectar dos codigos de barras y arrastrar los valores 
                                                coleccionItemsInsertarCodigoBarras.Clear() 'esto se puso aqui para que no se elimine el bc al detectar un bc que no es de la estructura 
                                            End If


                                            'se ha encontrado un codigo de barras que coincide con una de las estructuras de codigo de barras definidas para este proyecto 
                                            editor.escribir(pizarra, "detectado BC: " & barcode.GetBarString(contador).ToString)
                                            Application.DoEvents()
                                            'actualizar los datos del codigo de barras con los nuevos valores,                                            
                                            'calculamos los codigos de barras obtenidos para cada documento 



                                            camposEstructuraBarCode = accesoDatos.ejecutarSQLDirectaTable("SELECT CB.idCampoBarcode,CB.nombre,CB.longitud,CB.orden,CB.idestructura,confB.inicioBarcode,confB.cortarCAbecera FROM campobarcode CB,configuracionbarcode confB WHERE Cb.idestructura = " & estructuraBC.Item("idestructura") & " AND confB.idproyecto =" & idproyecto & "  and  confb.inicioBArcode like '" & Trim(estructuraBC.Item("inicioBarcode").ToString) & "' ORDER BY CB.orden ASC ", cadenaconexionAdministrativos)

                                            If obtenerItemsInsertarCodigoBarras(coleccionItemsInsertarCodigoBarras, camposEstructuraBarCode, barcode.GetBarString(contador), cadenaconexionProyecto) = 0 Then
                                                editor.escribir(pizarra, "Error la estructura de codigo de barras definida para este proyecto no es correcta para los codigos de barras encontrados", Color.Red)
                                                Exit Function

                                            End If
                                            Application.DoEvents()
                                            If IsNothing(marcaBarcodeDetectado.Nombre) Then
                                                marcaBarcodeDetectado = New LibreriaCadenaProduccion.Entidades.clsItem
                                                marcaBarcodeDetectado.Nombre = "BarcodeDet"
                                                marcaBarcodeDetectado.texto = 0
                                                marcaBarcodeDetectado.valor = 1
                                                coleccionItemsInsertar.Add(marcaBarcodeDetectado, marcaBarcodeDetectado.Nombre)
                                            End If
                                        End If 'fin de la comprobacion si coinciden las cabeceras codigos de barras 

                                    Next 'bucle por todas las estructurasd el codigo de barras para el proyecto 

                                Next 'bucle por todos los codigos de barras 

                            End If 'fin de si el numero de codigo de barras detectado es mayor que uno 
                        End If 'fin de si utiliza caratulas 


                        'prerprocesamiento de los datos,aqui podemos establecer valores para los datos no encontrados 
                        'en este caso vamoa a hacer que el codigo de la donacion tenga un valor si no se encuentra el codigo de 
                        'barras de donacion y si el del donan


                        'hacer la insercion en la base de datos en la tabla documentos
                        If Not insertarItemsTablaDocumentos(coleccionItemsInsertar, coleccionItemsInsertarCodigoBarras, cadenaconexionProyecto, pizarra) Then
                            Exit Function
                        End If

                        'inicializamos el vector de items a insertar 
                        coleccionItemsInsertar.Remove(pagina.Nombre)
                        coleccionItemsInsertar.Remove(NomarchivoTif.Nombre)

                        If Not IsNothing(marcaBarcodeDetectado.Nombre) Then
                            If coleccionItemsInsertar.Contains(marcaBarcodeDetectado.Nombre) Then
                                coleccionItemsInsertar.Remove(marcaBarcodeDetectado.Nombre)
                                marcaBarcodeDetectado.Nombre = Nothing
                            End If
                        End If

                        contadorPagina += 1

                        If contadorPagina Mod 2 = 0 Then 'si la pagina esta en una posicion par la rotamos a la derecha 

                            ' picturebox.RotateRight()
                            ' picturebox.Save( rutaimagenes  & "\" & nomarchivotif.nombre )
                            ' picturebox.FitTo(0)

                            'girarImagenAplicandoOCR(rutaimagenes & "\" & NomarchivoTif.valor, rutaimagenes & "\")


                        End If

                    Next

                    If accesoDAtosLote.CerrarLoteParaImportar(idLoteCerrar, contadorPagina, cadenaconexionProyecto) = 1 Then
                        editor.escribir(pizarra, "El lote se ha importado correctamente", Color.Green)
                    Else
                        MessageBox.Show("Error al cerrar el lote. ")
                    End If

                Catch ex As Exception
                    MessageBox.Show("Error al cerrar el lote. " & ex.Message.ToString)
                End Try


            End Function


            'inserta los valores en los registros de la tabla documentos 
            Private Shared Function insertarItemsTablaDocumentos(ByVal coleccionItemsInsertar As Collection, ByVal coleccionItemsIsertarCodigoBarras As Collection, ByVal cadenaconexion As String, ByRef pizarra As RichTextBox) As Boolean
                Dim listaValores As String = ""
                Dim listaCampos As String = ""

                'Añadido para interceptar SIP o NHC
                Dim conexion As SqlConnection = Nothing
                Dim cmm As SqlCommand
                Dim x As Integer
                'Fin añadido


                'comprobar que existe un re


                'insertamos los items correspondientes a los identificadores de pagina, fichero,lote
                For Each item As LibreriaCadenaProduccion.Entidades.clsItem In coleccionItemsInsertar

                    listaCampos = listaCampos & "," & item.Nombre

                    If item.texto = 1 Then
                        listaValores = listaValores & ",'" & item._valor & "'"
                    Else
                        listaValores = listaValores & "," & item._valor
                    End If

                Next

                'insertamos los items correspondientes a los items que encontramos en la base de datos 
                For Each item As LibreriaCadenaProduccion.Entidades.clsItem In coleccionItemsIsertarCodigoBarras

                    listaCampos = listaCampos & "," & item.Nombre

                    'Añadido para interceptar SIP o NHC
                    'If item.Nombre = "Numhistoria" Then
                    '
                    'MessageBox.Show("He de cambiar el valor por el de la historia")
                    'If Len(item._valor) = 7 And Left(item._valor, 2) <> "09" Then
                    ' conexion = New SqlConnection(cadenaconexion)
                    'conexion.Open()
                    'cmm = New SqlCommand("SELECT numhistoria FROM fip WHERE sip=" & item._valor)
                    'cmm.Connection = conexion
                    'x = cmm.ExecuteScalar
                    'item._valor = x
                    'End If
                    'End If
                    'Fin añadido



                    If item.texto = 1 Then
                        listaValores = listaValores & ",'" & item._valor & "'"
                    Else
                        listaValores = listaValores & "," & item._valor
                    End If

                Next

                'elimianr la primera coma 
                listaCampos = Trim(Replace(listaCampos, ",", "", 1, 1))
                listaValores = Trim(Replace(listaValores, ",", "", 1, 1))

                If accesoDatos.insertarRegistroLiteral("documentos", listaCampos, listaValores, cadenaconexion) Then
                    editor.escribir(pizarra, "Se ha insertado el registro correctamente con los datos del codigo de barras", Color.Green)
                    editor.escribir(pizarra, "Lista de campos : " & listaCampos & " valores : " & listaValores)
                    Return True
                Else
                    'si se produce un error al escribir el dodigo de barras escribimos solo los datos correspondientes al documento 
                    'y no los extraidos del codigo de barras 

                    editor.escribir(pizarra, "Error al insertar los siguientes valores", Color.Red)
                    editor.escribir(pizarra, "Lista de campos : " & listaCampos & " valores : " & listaValores)

                    listaValores = ""
                    listaCampos = ""

                    'insertamos los items correspondientes a los identificadores de pagina, fichero,lote
                    For Each item As LibreriaCadenaProduccion.Entidades.clsItem In coleccionItemsInsertar

                        listaCampos = listaCampos & "," & item.Nombre

                        If item.texto = 1 Then
                            listaValores = listaValores & ",'" & item._valor & "'"
                        Else
                            listaValores = listaValores & "," & item._valor
                        End If

                    Next

                    'elimianr la primera coma 
                    listaCampos = Trim(Replace(listaCampos, ",", "", 1, 1))
                    listaValores = Trim(Replace(listaValores, ",", "", 1, 1))

                    If accesoDatos.insertarRegistroLiteral("documentos", listaCampos, listaValores, cadenaconexion) Then
                        editor.escribir(pizarra, "Se ha encontrado un codigo de barras para el documento pero no  se ha podido insertar se han insertado solo los datos del documento", Color.Red)
                        editor.escribir(pizarra, "Lista de campos : " & listaCampos & " valores : " & listaValores)
                        Return True
                    Else
                        'no se ha podido introducir el registro en la base de datos 

                        editor.escribir(pizarra, "Se ha encontrado un codigo de barras para el documento pero no se ha podido insertar ningún dato", Color.Red, 14)
                        editor.escribir(pizarra, "Lista de campos : " & listaCampos & " valores : " & listaValores)
                        Return False
                    End If
                End If

            End Function

            'obtiene los items del codigo de barras que se tienen que insertar en la tabla 
            'documentos 
            Private Shared Function obtenerItemsInsertarCodigoBarras(ByRef coleccionItemsInsertarCodigoBarras As Collection, ByVal estructuraBarCode As DataTable, ByVal barcode As String, ByVal cadenaconexion As String) As Integer

                Dim codigoBarrasSinCabecera As String
                Dim itemCodigoBarras As LibreriaCadenaProduccion.Entidades.clsItem
                Dim esFecha As Boolean = False
                Dim quitarMascara As Boolean = False

                Try

                    'eliminar la cabecera del codigo de barras

                    If estructuraBarCode.Rows(0).Item("cortarCabecera") Then
                        codigoBarrasSinCabecera = Mid(barcode, Len(Trim(estructuraBarCode.Rows(0).Item("inicioBarcode").ToString)) + 1)
                    Else
                        codigoBarrasSinCabecera = barcode
                    End If

                    For Each registro As DataRow In estructuraBarCode.Rows



                        itemCodigoBarras = New LibreriaCadenaProduccion.Entidades.clsItem

                        With itemCodigoBarras
                            .Nombre = registro.Item("nombre")


                            .texto = obtenerTipoCampoTabladocumentos(registro.Item("nombre"), esFecha, cadenaconexion)

                            If esFecha Then
                                'Dim aux As String = (Mid(codigoBarrasSinCabecera, 1, registro.Item("longitud")))
                                '.valor = Format(aux, "dd/MM/yyyy 00:00:00")
                                .valor = Mid(codigoBarrasSinCabecera, 1, registro.Item("longitud"))
                                Debug.Print(.valor)
                            Else
                                .valor = Val(Mid(codigoBarrasSinCabecera, 1, registro.Item("longitud")))
                                'Dim cont As Integer = 0
                                'For Each caracter As Char In .valor
                                '    If caracter = "0" Then
                                '        cont += 1
                                '    End If
                                'Next
                            End If

                        End With
                        codigoBarrasSinCabecera = Mid(codigoBarrasSinCabecera, registro.Item("longitud") + 1)

                        Try
                            coleccionItemsInsertarCodigoBarras.Remove(itemCodigoBarras.Nombre)
                        Catch ex As Exception

                        End Try

                        coleccionItemsInsertarCodigoBarras.Add(itemCodigoBarras, itemCodigoBarras.Nombre)
                    Next

                    Return 1

                Catch ex As Exception
                    MessageBox.Show("Error par obtener items para insertar en el codigo de barras, compruebe que esta bien definida la longirtud del codigo de barras." & ex.Message)
                    Return 0
                End Try

            End Function


            Public Shared Function obtenerTipoCampoTabladocumentos(ByVal nombrecampo As String, ByRef esFEcha As Boolean, ByVal cadenaConexion As String) As Integer

                Dim tipo As String
                tipo = accesoDatos.ejecutarSQLDirectaDataRow("SELECT DATA_TYPE FROM  INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'documentos' AND COLUMN_NAME = '" & nombrecampo & "'", cadenaConexion).Item(0)



                If tipo = "nvarchar" Or tipo = "datetime" Or tipo = "varchar" Or tipo = "text" Or tipo = "ntext" Or tipo = "nchar" Then

                    If tipo = "datetime" Then
                        esFEcha = True
                    End If
                    'modificacion por el tema de que no se entera de que este campo se ha cambiado en la base de datos 


                    Return 1
                End If



                Return 0

            End Function


            Private Shared Sub incializarDAtosCodigoBarras(ByRef coleccionItemsInsertarCodigoBarras As Collection, ByVal estructuraBarCode As DataTable)

                'aqui hariamos un tratamiento especial para los datos iniciales del codigo de barras de momento 
                'no vamos a hacer nada y los datos se van a quedar a null hasta que no encuentre un codigo de barras 

            End Sub

#End Region


        End Class


    End Namespace
End Namespace
