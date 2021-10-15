Imports System.IO
Imports System.Windows.Forms
Imports consulta = libreriacadenaproduccion.Datos.GeneralSQL.clsAccesoDatosSQL
Imports datosdocumento = libreriacadenaproduccion.Datos.Produccion.cadenaproduccion.clsAccesoDatosDocumento
Imports fg = libreriacadenaproduccion.FuncionesGlobales.Carpetas

Namespace Entidades

    Public Class ClsOperacionesDigitalizacion


        '''' <summary>
        '''' Inserción de documentos, pasandole una coleccion de documentos, ORDENADOS INVERSAMENTE
        '''' EN LA CONSULTA LINQ
        '''' </summary>
        '''' <param name="cadenaConexion"></param>
        '''' <param name="pagina"></param>
        '''' <param name="documentos"></param>
        '''' <returns></returns>
        '''' <remarks></remarks>
        'Shared Function documento_insercion(ByVal cadenaConexion As String, ByRef pgBar As ProgressBar, ByVal rutaDocumento As String, ByVal proyecto As String, ByVal lote As String, ByVal pagina As String, ByVal rutaFicheros As String, ByRef documentos As System.Collections.Generic.List(Of DataRow), ByVal caratula As Boolean, ByVal ultimo As Boolean)

        '    Dim rutadocumentoOrigen As String, rutadocumentoDestino As String

        '    Try

        '        For Each documento As DataRow In documentos
        '            'mover la siguiente imagen incrementando en uno el indice 
        '            rutadocumentoOrigen = rutaFicheros & "\IML" & Format(CInt(documento.Item("pagina")), "00000").ToString & ".TIF"
        '            rutadocumentoDestino = rutaFicheros & "\IML" & Format(CInt(documento.Item("pagina").ToString) + 1, "00000") & ".TIF"

        '            If fg.clsCarpetas.MoverFichero(rutadocumentoOrigen, rutadocumentoDestino) Then
        '                If Not datosdocumento.ActualizarIdentificadoresNumericos(cadenaConexion, proyecto, lote, documento.Item("pagina").ToString, "", True) Then
        '                    'nos ha dado un error la actualizacion de los datos por lo que nos salimos de la funcion 
        '                    Return False

        '                End If
        '            Else 'no puede copiar el documento en el destino 
        '                Return False
        '            End If
        '        Next

        '        If fg.clsCarpetas.CopiarFichero(rutaDocumento, rutaFicheros & "\IML" & Format(CInt(pagina), "00000") & ".TIF") Then
        '            'insertar el documento 
        '            If datosdocumento.InsertarDocumento(cadenaConexion, proyecto, lote, pagina, caratula, ultimo) Then Return True
        '        End If
        '        Return False
        '    Catch ex As Exception
        '        MsgBox(ex.Message)
        '    End Try


        '    Return True

        'End Function


        ''' <summary>
        ''' Funcion para la eliminacion de un documento
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared Function documento_insercion(ByVal cadenaConexion As String, ByVal baseDatos As String, ByRef pgBar As ProgressBar, ByVal imagen_insertada As String, ByVal proyecto As String, ByVal lote As String, ByVal pagina As String, ByVal rutaFicheros As String, ByRef documentos As System.Collections.Generic.List(Of DataRow), ByVal caratula As Boolean, ByVal ultimo As Boolean, Optional ByVal nhc As String = "", Optional ByVal icu As String = "", Optional ByVal serv As String = "") As Boolean

            Dim RutaDestinoDocumento As String
            Dim RutaDocumento As String = ""
            Dim paginaUltimaImagenRenombrada As Integer

            Try


                'Primero realizamos el renombramiento de ficheros
                If documentos.Count > 0 Then

                    With pgBar
                        .Minimum = 0
                        .Maximum = documentos.Count
                        .Value = 1
                    End With

                    Application.DoEvents()


                    For Each documento As DataRow In documentos
                        'mover la siguiente imagen decrementando en uno el indice 
                        RutaDocumento = rutaFicheros & "\IML" & Format(CInt(documento.Item("pagina")), "00000").ToString & ".TIF"
                        RutaDestinoDocumento = rutaFicheros & "\IML" & Format(CInt(documento.Item("pagina").ToString) + 1, "00000") & ".TIF"

                        Application.DoEvents()

                        'En la insercion eliminamos el posible fichero que haya antes de la insercion
                        If IO.File.Exists(RutaDestinoDocumento) Then IO.File.Delete(RutaDestinoDocumento)

                        If Not fg.clsCarpetas.MoverFichero(RutaDocumento, RutaDestinoDocumento) Then
                            'si no se ha copiado correctamente la imagen nos guardamos 
                            'el numero de la ultima pagina modificada, nos salimos del for de renobrar 
                            'y actualizamos los registros en la base de datos desde 
                            'pagina hasta paginaUltimaImagenRenombrada -1

                            paginaUltimaImagenRenombrada = documento.Item("pagina") + 1 'le quitamos una pq la ultima es la que ha dado el error y no se renobra 
                            MessageBox.Show("Error al intentar renombrar la imagen IML" & Format(CInt(documento.Item("pagina")), "00000").ToString & ".TIF a la pagina " & " IML" & Format(CInt(documento.Item("pagina").ToString) + 1, "00000") & ".TIF ")
                            Exit For

                        End If

                        pgBar.Increment(1)
                        Application.DoEvents()
                        'nos guardamos la ultima pagina renobrada 
                        paginaUltimaImagenRenombrada = documento.Item("pagina")

                    Next

                    'Actualizamos los registros
                    If Not datosdocumento.ActualizarIdentificadoresNumericos(cadenaConexion, baseDatos, proyecto, lote, pagina, "", True) Then
                        'nos ha dado un error la actualizacion de los datos por lo que 
                        'renombramos los registros que habimos cambiado (los dejamos como estaban) y nos salimos de la funcion 

                        'esto queda pendiente 
                        pgBar.Value = pgBar.Minimum

                        Return False

                    End If



                End If

                'Pruebassss
                'Copiamos el fichero
                If fg.clsCarpetas.CopiarFichero(imagen_insertada, rutaFicheros & "\IML" & Format(CInt(pagina), "00000") & ".TIF") Then
                    'insertar el documento 
                    If documentos.Count = 0 Then ultimo = True
                    If datosdocumento.InsertarDocumento(cadenaConexion, baseDatos, proyecto, lote, pagina, caratula, ultimo, nhc, icu, serv) Then Return True
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

            'ponemos aqui el return false para el caso en el que da algun error inicial en la funcion que no 
            'esta controlado 
            Return False

        End Function



        ''' <summary>
        ''' Funcion para la eliminacion de un documento
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared Function documento_eliminacion(ByVal cadenaConexion As String, ByVal baseDatos As String, ByRef pgBar As ProgressBar, ByVal proyecto As String, ByVal lote As String, ByVal pagina As String, ByVal rutaFicheros As String, ByRef documentos As System.Collections.Generic.List(Of DataRow)) As Boolean

            Dim RutaDestinoDocumento As String
            Dim RutaDocumento As String
            Dim paginaUltimaImagenRenombrada As Integer

            Try

                'Eliminamos el registro actual
                If fg.clsCarpetas.EliminarFichero(rutaFicheros & "\IML" & Format(CInt(pagina), "00000").ToString & ".TIF") Then

                    Application.DoEvents()

                    'Actualizamos el registro correspondiente a la imagen eliminada en la tabla documentos 
                    If datosdocumento.EliminarDocumento(cadenaConexion, lote, pagina) Then

                        If documentos.Count > 0 Then

                            With pgBar
                                .Minimum = 0
                                .Maximum = documentos.Count
                                .Value = 1
                            End With

                            Application.DoEvents()


                            For Each documento As DataRow In documentos
                                'mover la siguiente imagen decrementando en uno el indice 
                                RutaDocumento = rutaFicheros & "\IML" & Format(CInt(documento.Item("pagina")), "00000").ToString & ".TIF"
                                RutaDestinoDocumento = rutaFicheros & "\IML" & Format(CInt(documento.Item("pagina").ToString) - 1, "00000") & ".TIF"

                                Application.DoEvents()

                                If Not fg.clsCarpetas.MoverFichero(RutaDocumento, RutaDestinoDocumento) Then
                                    'si no se ha copiado correctamente la imagen nos guardamos 
                                    'el numero de la ultima pagina modificada, nos salimos del for de renobrar 
                                    'y actualizamos los registros en la base de datos desde 
                                    'pagina hasta paginaUltimaImagenRenombrada -1

                                    paginaUltimaImagenRenombrada = documento.Item("pagina") - 1 'le quitamos una pq la ultima es la que ha dado el error y no se renobra 
                                    MessageBox.Show("Error al intentar renombrar la imagen IML" & Format(CInt(documento.Item("pagina")), "00000").ToString & ".TIF a la pagina " & " IML" & Format(CInt(documento.Item("pagina").ToString) - 1, "00000") & ".TIF ")
                                    Exit For

                                End If

                                pgBar.Increment(1)
                                Application.DoEvents()
                                'nos guardamos la ultima pagina renobrada 
                                paginaUltimaImagenRenombrada = documento.Item("pagina")

                            Next

                            'cuando terminamos de renombrar 

                            If Not datosdocumento.ActualizarIdentificadoresNumericos(cadenaConexion, baseDatos, proyecto, lote, pagina, paginaUltimaImagenRenombrada, False) Then
                                'nos ha dado un error la actualizacion de los datos por lo que 
                                'renombramos los registros que habimos cambiado (los dejamos como estaban) y nos salimos de la funcion 

                                'esto queda pendiente 
                                pgBar.Value = pgBar.Minimum

                                Return False
                            End If

                            'cuando terminamos de hacer toda la actulizacion de los registros devolvemos true 
                            pgBar.Value = pgBar.Minimum

                        End If 'fin de si es el ulitimo registro del lote

                        Return True
                    Else
                        MsgBox("No se ha podido eliminar el fichero " & "IML" & Format(CInt(pagina), "00000").ToString & ".TIF", MsgBoxStyle.Critical, "Incidencia de aplicacion")
                        pgBar.Value = pgBar.Minimum

                        Return False

                    End If
                End If



            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

            'ponemos aqui el return false para el caso en el que da algun error inicial en la funcion que no 
            'esta controlado 
            Return False

        End Function


        ''' <summary>
        ''' Funcion para sustituir un documento 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared Function documento_sustitucion(ByVal cadenaConexion As String, ByVal proyecto As String, ByVal lote As String, ByVal pagina As String, ByVal rutaFicheros As String) As Boolean

            Dim cargaImagen As New OpenFileDialog

            cargaImagen.Title = "Seleccione una imagen para mostrar"
            cargaImagen.Filter = "Archivo TIF|*.TIF"
            cargaImagen.Multiselect = False

            If cargaImagen.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then
                Return fg.clsCarpetas.CopiarFichero(cargaImagen.FileName, rutaFicheros & "\IML" & Format(CInt(pagina), "00000") & ".TIF")
            Else
                MsgBox("No ha seleccionado una imagen", MsgBoxStyle.Critical, "Incidencia de aplicacion")
                Return False
            End If


        End Function


    End Class


End Namespace
