Imports System.IO


Namespace Entidades

    Namespace Operaciones

    
        Public Class clsOperacionesLoteRenombrar



            'esta funcion renombra los documentos de un lote , se utiliza antes de la importacion 
            'cuando se encuentran saltos entre los documentos 

            Public Shared Function estaelloteOrdenado(ByVal rutaimageneslote As String) As Boolean

                Dim metadatos As FileInfo
                Dim identificadorFichero As Integer
                Dim numeroImagen As Integer = 0


                For Each archivo As String In Directory.GetFiles(rutaimageneslote)
                    metadatos = New FileInfo(archivo)

                    numeroImagen += 1
                    identificadorFichero = CInt(Mid(metadatos.Name, 4, 5))

                    If identificadorFichero <> numeroImagen Then

                        Return renumerarLote(rutaimageneslote)

                    End If

                Next

                Return True

            End Function


            Private Shared Function renumerarLote(ByVal rutaimageneslote As String) As Boolean
                Try


                    If IO.Directory.Exists(rutaimageneslote) Then

                        Dim iFile As IO.FileInfo
                        Dim nombreFichero As String
                        Dim numeroUltimo As Integer = -1

                        Dim nombres() As String = IO.Directory.GetFiles(rutaimageneslote, "*.TIF")


                        For i As Integer = 0 To nombres.Length - 1
                            iFile = New IO.FileInfo(nombres(i))
                            nombreFichero = iFile.Name.Replace(iFile.Extension, "")
                            'convertimos a numerico el valor y comprobamos que sea igual 
                            numeroUltimo = CInt(nombreFichero.Substring(3))

                            If numeroUltimo <> (i + 1) Then
                                IO.File.Move(nombres(i), iFile.Directory.FullName & "\IML" & Format((i + 1), "00000") & iFile.Extension)
                            End If

                        Next
                       

                    End If
                Catch ex As Exception
                    Windows.Forms.MessageBox.Show(ex.Message.ToString)
                    Return False
                End Try

                Return True
            End Function

        End Class

    End Namespace
End Namespace
