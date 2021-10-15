Imports datos = LibreriaCadenaProduccion.Datos.GeneralSQL.clsAccesoDatosSQL
Module modDigitalizacionTwain

    Public Const nombreControlImagen1 = "tsbImagen1"
    Public Const nombreControlImagen2 = "tsbImagen2"
    Public Const nombreControlImagenMini = "tsbImagenMini"

    Public Const nombreControlAjuste1 = "tsbAjuste1"
    Public Const nombreControlAjuste2 = "tsbAjuste2"
    Public Const nombreControlAjuste3 = "tsbAjuste3"
    Public Const nombreControlAjuste4 = "tsbAjuste4"

    Public Const aplicacionEscaneo = "i_view32"

    Public Sub cargaComboTipoLote(ByVal proyecto As String, ByRef combo As ComboBox)
        Try
            Dim lsSql As String = "SELECT Nombre FROM CONFIGURACION_TIPOLOTES WHERE idProyecto='" & proyecto & "' ORDER BY Nombre"

            combo.Items.Clear()
            For Each registro As DataRow In datos.ejecutarSQLDirectaTable(lsSql, My.Settings.cadenaConexion).Rows

                combo.Items.Add(registro.Item("Nombre"))
            Next
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Function generaMiniatura(ByVal sPath As String, ByRef Ancho As Integer, ByRef Alto As Integer) As System.Drawing.Image

        Dim CallBack As New Image.GetThumbnailImageAbort(AddressOf MycallBack)
        ' ''Dim Imagen As Image
        Dim miniatura As Image = Nothing
        Dim generacionCorrecta As Boolean = False
        Dim timeOut As Integer = 5
        Dim horaInicio As DateTime = Now
        Dim mensajeEX As String = ""
        Dim cierraSiguientePasada As Boolean = False

        'Hago este bucle porque cuando se digitalizan imágenes a color, el programa va más rápido que la creación de un fichero 
        'grande a color y daba error de memoria insuficiente pero realmente el error era que ya se estaba utilizando el fichero del parámetro sPath
        Do
            Try
                'Si no existe el fichero TIF, muestra el comodín
                If IO.File.Exists(sPath) = False Then sPath = My.Application.Info.DirectoryPath & "\ImagenDocumentoNocargado.TIF"
                '***********************************************

                'Si la ruta es la imagen comodín, es que ha pasado el timeOut y va a mostra la imagen comodín.
                If sPath = My.Application.Info.DirectoryPath & "\ImagenDocumentoNocargado.TIF" Then
                    generacionCorrecta = True
                End If

                Using fs As New System.IO.FileStream(sPath.ToString, System.IO.FileMode.Open, IO.FileAccess.Read)

                    Using Imagen = Image.FromStream(fs)

                        ' Para calcular la escala  
                        Dim HScale As Double = Ancho / Imagen.Width
                        Dim VScale As Double = Alto / Imagen.Height

                        Dim escala As Double

                        If (VScale >= HScale) Then
                            escala = HScale
                        Else
                            escala = VScale
                        End If

                        ' ''escala = escala * 0.75

                        ' si la imagen es mas chica (ancho y alto ) que el picture .. se deja del tamaño real  
                        If (Imagen.Width < Ancho) And (Imagen.Height < Alto) Then
                            escala = 1
                            ' ''escala = 0.75
                            Ancho = Imagen.Width
                            Alto = Imagen.Height
                        End If

                        ' retornar la imagen  
                        miniatura = Imagen.GetThumbnailImage(
                                            (CInt(Imagen.Width * escala)),
                                            (CInt(Imagen.Height * escala)),
                                             CallBack,
                                             IntPtr.Zero)
                    End Using
                End Using

                generacionCorrecta = True

            Catch exOm As OutOfMemoryException
                ' ''Dim mensajeEX As String = ""
                'Excepción interna
                If exOm.InnerException IsNot Nothing Then
                    mensajeEX = " Inner exception: " & exOm.InnerException.Message
                End If
                mensajeEX = "*** ERROR. " & Now & " Ocurrió un error de memoria al generar miniaturas." & vbLf & exOm.Message & vbLf & mensajeEX & vbLf & exOm.StackTrace
                ' ''Throw exOm


            Catch ex As Exception
                ' ''Dim mensajeEX As String = ""
                'Excepción interna
                If ex.InnerException IsNot Nothing Then
                    mensajeEX = " Inner exception: " & ex.InnerException.Message
                End If
                mensajeEX = "*** ERROR. " & Now & " Ocurrió un error al generar miniaturas." & vbLf & ex.Message & vbLf & mensajeEX & vbLf & ex.StackTrace
                ' ''Throw ex

            Finally
                ' ''generaMiniatura = miniatura
                ' ''miniatura.Dispose()

                'Si han pasado los segundos indicados en la variable timeOut, salgo del bucle para que no se haga infinito y muestro la imagen comodín.
                If horaInicio.AddSeconds(timeOut) < Now Then
                    escribirEnLog("*** ERROR. " & Now & " Ocurrió un error al generar la miniaturas. la imagen " & sPath & " es posible que esté en uso." & vbLf & mensajeEX)
                    ' ''generacionCorrecta = True
                    sPath = My.Application.Info.DirectoryPath & "\ImagenDocumentoNocargado.TIF"

                    If cierraSiguientePasada Then generacionCorrecta = True
                    cierraSiguientePasada = True

                End If
            End Try
        Loop Until generacionCorrecta = True

        generaMiniatura = miniatura

    End Function

    Public Function generaMiniatura_ANTES_20200529(ByVal sPath As String, ByRef Ancho As Integer, ByRef Alto As Integer) As System.Drawing.Image

        Dim CallBack As New Image.GetThumbnailImageAbort(AddressOf MycallBack)
        Dim Imagen As Image

        Try
            Try
                Imagen = Image.FromFile(sPath.ToString)

            Catch ex As Exception
                Imagen = Image.FromFile(My.Application.Info.DirectoryPath & "\ImagenDocumentoNocargado.TIF")

            End Try

            ' Para calcular la escala  
            Dim HScale As Double = Ancho / Imagen.Width
            Dim VScale As Double = Alto / Imagen.Height

            Dim escala As Double

            If (VScale >= HScale) Then
                escala = HScale
            Else
                escala = VScale
            End If

            ' ''escala = escala * 0.75

            ' si la imagen es mas chica (ancho y alto ) que el picture .. se deja del tamaño real  
            If (Imagen.Width < Ancho) And (Imagen.Height < Alto) Then
                escala = 1
                ' ''escala = 0.75
                Ancho = Imagen.Width
                Alto = Imagen.Height
            End If

            ' retornar la imagen  
            Return Imagen.GetThumbnailImage( _
                                (CInt(Imagen.Width * escala)), _
                                (CInt(Imagen.Height * escala)), _
                                 CallBack, _
                                 IntPtr.Zero)

        Catch exOm As OutOfMemoryException
            Dim mensajeEX As String = ""
            'Excepción interna
            If exOm.InnerException IsNot Nothing Then
                mensajeEX = " Inner exception: " & exOm.InnerException.Message
            End If
            escribirEnLog("*** ERROR. " & Now & " Ocurrió un error de memoria al generar miniaturas." & vbLf & exOm.Message & vbLf & mensajeEX & vbLf & exOm.StackTrace)
            Throw exOm

        Catch ex As Exception
            Dim mensajeEX As String = ""
            'Excepción interna
            If ex.InnerException IsNot Nothing Then
                mensajeEX = " Inner exception: " & ex.InnerException.Message
            End If
            escribirEnLog("*** ERROR. " & Now & " Ocurrió un error de memoria al generar miniaturas." & vbLf & ex.Message & vbLf & mensajeEX & vbLf & ex.StackTrace)
            Throw ex

        End Try

        Return Nothing

    End Function

    Public Function generaMiniatura_OLD20200423(ByVal ruta As String, ByVal lote As String) As String
        Dim parametros As String = ""
        Dim resultado As String = ""
        Dim img As Image

        Try

            parametros = ruta & " -resize 30% " & ruta.Replace("\" & lote, "\" & lote & "\MINIATURAS").ToUpper.Replace("TIF", "PNG")

            EjecutarComandoSHELL("" & My.Application.Info.DirectoryPath & "\convert.exe" & " ", parametros)

        Catch ex As Exception
            resultado = ex.Message
            Throw ex

        Finally
            generaMiniatura_OLD20200423 = resultado

        End Try

    End Function

    Public Function BuscarEnGridLINQ(ByVal TextoABuscar As String, ByVal Columna As String, ByRef grid As DataGridView) As Boolean
        Dim encontrado As Boolean = False

        Try
            If TextoABuscar = String.Empty Then Return False
            If grid.RowCount = 0 Then Return False
            grid.ClearSelection()
            If Columna = String.Empty Then
                Dim obj As IEnumerable(Of DataGridViewRow) = From row As DataGridViewRow In grid.Rows.Cast(Of DataGridViewRow)() From celda As DataGridViewCell In row.Cells() Where (celda.OwningRow.Equals(row) And celda.Value = TextoABuscar) Select row
                If obj.Any() Then
                    grid.Rows(obj.FirstOrDefault().Index).Selected = True
                    grid.CurrentCell = grid.Rows(obj.FirstOrDefault().Index).Cells(0)
                    encontrado = True
                End If
            Else
                Dim obj As IEnumerable(Of DataGridViewRow) = From row As DataGridViewRow In grid.Rows.Cast(Of DataGridViewRow)() Where (row.Cells(Columna).Value = TextoABuscar) Select row
                If obj.Any() Then
                    grid.Rows(obj.FirstOrDefault().Index).Selected = True
                    grid.CurrentCell = grid.Rows(obj.FirstOrDefault().Index).Cells(0)
                    encontrado = True
                End If
            End If

        Catch ex As Exception
            Throw ex

        Finally
            BuscarEnGridLINQ = encontrado

        End Try

    End Function

    Public Function RotateImage(ByVal image As Image, ByVal offset As PointF, ByVal angle As Single) As Bitmap
        Dim rotatedBmp As Bitmap = New Bitmap(image.Width, image.Height)

        Try
            If image Is Nothing Then Throw New ArgumentNullException("image")
            'rotatedBmp = New Bitmap(image.Width, image.Height)
            rotatedBmp.SetResolution(image.HorizontalResolution, image.VerticalResolution)
            Dim g As Graphics = Graphics.FromImage(rotatedBmp)
            g.TranslateTransform(offset.X, offset.Y)
            g.RotateTransform(angle)
            g.TranslateTransform(-offset.X, -offset.Y)
            g.DrawImage(image, New PointF(0, 0))

        Catch ex As Exception
            Throw ex

        Finally
            RotateImage = rotatedBmp

        End Try

    End Function

    Public Sub escribirEnLog(ByVal texto As String)

        If IO.Directory.Exists(Application.StartupPath & "\LOG") = False Then
            IO.Directory.CreateDirectory(Application.StartupPath & "\LOG")
        End If

        Dim sw As New System.IO.StreamWriter(Application.StartupPath & "\LOG\iScan_" & Replace(Format(Today, "dd/MM/yyyy"), "/", "_") & ".txt", True)
        sw.WriteLine(Environment.MachineName & " - " & frmContenedorMDI.oUsuario._login & " " & texto)
        sw.Close()

    End Sub

    Public Function cerrarProcesoActivo(ByVal StrNombreProceso As String) As Boolean
        Dim resultado As Boolean = False

        Try
            Dim procesos() As Process = Process.GetProcessesByName(StrNombreProceso)

            If procesos.Length > 0 Then
                For i As Integer = 0 To procesos.Length - 1
                    procesos(i).CloseMainWindow()
                    If procesos(i).HasExited = False Then
                        procesos(i).Kill()
                        procesos(i).Close()
                        resultado = True
                    End If
                Next
            End If

        Catch ex As Exception
            Throw ex

        Finally
            cerrarProcesoActivo = resultado

        End Try


    End Function


    Public Function compruebaProcesoActivo(ByVal StrNombreProceso As String) As Boolean
        Dim resultado As Boolean = False

        Try
            Dim procesos() As Process = Process.GetProcessesByName(StrNombreProceso)

            If procesos.Length > 0 Then
                For i As Integer = 0 To procesos.Length - 1
                    If procesos(i).HasExited = False Then
                        resultado = True
                    Else
                        If procesos(i).MainWindowHandle <> 0 Then
                            resultado = True
                            Exit Function
                        End If
                    End If
                Next
            End If

        Catch ex As Exception
            ' ''Throw ex

        Finally
            compruebaProcesoActivo = resultado

        End Try

    End Function

    Function MycallBack() As Boolean
        Return False
    End Function
End Module
