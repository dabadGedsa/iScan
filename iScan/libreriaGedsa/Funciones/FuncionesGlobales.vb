Imports System.IO

Namespace FuncionesGlobales

    Namespace Carpetas

        Public Class clsCarpetas

            Public Shared Sub borrarImagenesDirectorioTemporal()

                Dim dirTemp As DirectoryInfo

                dirTemp = New DirectoryInfo("c:\\temp")

                If dirTemp.Exists Then

                    ' elimino los archivos tipo "tif"
                    For Each archivo As FileInfo In dirTemp.GetFiles()
                        If archivo.Extension.ToLower() = ".tif" Then

                            Try
                                archivo.Delete()
                            Catch
                            End Try

                        End If
                    Next

                End If

            End Sub

            ''' <summary>
            ''' Este metodo devuelve un array de strings. El array esta compuesto por las rutas
            ''' completas de los archivos que coinciden con el filtro en la ruta especificada y en 
            ''' sus subcarpetas.
            ''' </summary>
            ''' <param name="ruta">
            ''' La ruta de la carpeta que queremos analizar( se analizaran subdirectorios tambien )
            ''' </param>            ''' 
            ''' <param name="filtro">
            ''' Filtro a aplicar en la busqueda, debe ser del tipo: *.mdb, *.doc, *.exe .... y buscara todos
            ''' los archivos con esa estension. Tambien se puede buecar el nombre de un archivo (sin testear)
            ''' de manera de "prueba.c" 
            ''' </param>


            Public Shared Function obtenerListaDeArchivosEnUnaCarpeta(ByVal ruta As String, ByVal filtro As String) As ArrayList

                Dim arrayDeRutasArchivo As New ArrayList

                obtenerRutasArchivos(ruta, arrayDeRutasArchivo, filtro)

                Return arrayDeRutasArchivo



            End Function

            Private Shared Function obtenerRutasArchivos(ByVal ruta As String, ByRef arrayDeRutas As ArrayList, ByVal filtro As String) As ArrayList
                'funcion recursiva

                If Not Directory.GetDirectories(ruta).Length > 0 Then

                    'si no tiene directorios, se añaden todos los mdbs y hace return(caso base)
                    For Each Archivo As String In System.IO.Directory.GetFiles(ruta, filtro)
                        arrayDeRutas.Add(Archivo)
                    Next

                    Return arrayDeRutas




                Else
                    'si tiene directorios, se añaden todos los mdbs, y se hace una llamada a 
                    'obtenerRutasDeMDB(ByVal ruta As String, ByRef arrayDeRutas As ArrayList)
                    'de cada una de sus carpetas
                    For Each Archivo As String In System.IO.Directory.GetFiles(ruta, filtro)
                        arrayDeRutas.Add(Archivo)
                    Next


                    For Each directorio As String In Directory.GetDirectories(ruta)
                        obtenerRutasArchivos(directorio, arrayDeRutas, filtro)
                    Next



                End If

                Return Nothing
            End Function

            Public Shared Function tieneDirectorios(ByVal path As String) As Boolean

                If Directory.GetDirectories(path).Length > 0 Then

                    Return True
                Else
                    Return False
                End If


            End Function

            Public Shared Function EliminarFichero(ByVal ruta As String) As Boolean
                Try
                    If IO.File.Exists(ruta) Then IO.File.Delete(ruta)

                Catch ex As Exception
                    Return False
                End Try

                Return True
            End Function

            Public Shared Function MoverFichero(ByVal rutaFichero As String, ByVal rutaficherodestino As String) As Boolean

                Try
                    If IO.File.Exists(rutaFichero) Then
                        If IO.File.Exists(rutaficherodestino) Then IO.File.Delete(rutaficherodestino)
                        IO.File.Move(rutaFichero, rutaficherodestino)
                        Return True
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                Return False
            End Function

            Public Shared Function CopiarFichero(ByVal rutaFichero As String, ByVal rutaficherodestino As String) As Boolean
                Try
                    IO.File.Copy(rutaFichero, rutaficherodestino, True)
                    Return True
                Catch ex As Exception
                    MsgBox("Incidencia copiando: '" & rutaFichero & "' en '" & rutaficherodestino & "'" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Incidencia de aplicacion")
                End Try
                Return False

            End Function

            Public Shared Function espacionLibreUnidad() As String

                Dim resultado As String = ""

                For Each drive_info As DriveInfo In DriveInfo.GetDrives()
                    resultado &= drive_info.Name & "  " & drive_info.RootDirectory.ToString

                    If drive_info.IsReady() Then
                        resultado &= "Espacio discponible " & Val((drive_info.AvailableFreeSpace().ToString / 1024) / 1024 / 1024)
                    Else
                        resultado &= "0 MGB"
                    End If
                Next

                Return resultado

            End Function


            Public Shared Function espaciolibreUnidadMB(ByVal unidad As String)

                Dim espacio As Long = 0





                For Each drive_info As DriveInfo In DriveInfo.GetDrives()
                    If drive_info.Name = unidad Then
                        espacio = (drive_info.AvailableFreeSpace().ToString)
                    End If
                Next


                Return espacio

            End Function

        End Class

    End Namespace

    Namespace TratamientoFechas

        Public Class clsTratamientoFechas
            Public Shared Function convertirFecha(ByVal strFecha As String) As String

                Dim fecha As Date

                If DateTime.TryParse(strFecha, fecha) Then
                    Return fecha
                Else
                    Return Date.MinValue
                End If

            End Function
        End Class

    End Namespace

    Namespace ResolucionPantalla

        'Public Class clsResolucionPantalla

        '    Private Shared Direct As New DirectX.DirectX7
        '    Private Shared DirectD As DirectX.DirectDraw7

        '    Public Shared Sub cambiarResolucionPantalla(ByVal ancho As Integer, ByVal alto As Integer)

        '        DirectD = Direct.DirectDrawCreate("")
        '        DirectD.SetDisplayMode(ancho, alto, 0, 0, DirectX.CONST_DDSDMFLAGS.DDSDM_DEFAULT)
        '    End Sub
        'End Class

    End Namespace

End Namespace