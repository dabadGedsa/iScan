Option Strict Off
Option Explicit On
Imports libreriacadenaproduccion.Entidades.clsRegistroTXT
Imports System.IO

Namespace TXT

    Public Class ClsExtraerTXT

        Dim tamanyoArchivo As Integer


        Public Shared Function ExtraerCamposTXT(ByRef rutaOrigen As String, ByVal separador As String) As Collection
            'Funcion para separar campos separados por | de un txt (puede ser cualquier separador)
            Dim intSecuencia As Integer = 0
            Dim registrosTXT As New Collection
            Dim registroTXT As libreriacadenaproduccion.Entidades.clsRegistroTXT
            Dim cadena As String()

            'estructura de una linea del TXT 
            'contador|NumeroHistoria|NombreImagenDocumento|FechaInicio|FechaFin|NombrePath|TipoDocumento|NumeroEpisodio|TipoEpisodio|CodigoServicio|OrigenDocumento

            If rutaOrigen = "" Then
                MsgBox("Error, faltan datos", MsgBoxStyle.Critical, "Error")
            End If

            Try

                Dim PunteroArchivo As Integer = FreeFile()          ' Apuntador libre a archivo
                Dim LineaTexto As String                            ' Variable donde guardamos cada línea de texto



                FileOpen(PunteroArchivo, rutaOrigen, OpenMode.Input, OpenAccess.Read)                   ' Abrimos el archivo y lo recorremos hasta el final línea por línea

                Do While Not EOF(PunteroArchivo)

                    LineaTexto = LineInput(PunteroArchivo)  ' Leemos la línea de texto del archivo

                    If LineaTexto <> "" Then
                        cadena = Split(LineaTexto, separador)
                        registroTXT = New libreriacadenaproduccion.Entidades.clsRegistroTXT(cadena.GetValue(0), cadena.GetValue(1), cadena.GetValue(2), cadena.GetValue(3), cadena.GetValue(4), cadena.GetValue(5), cadena.GetValue(6), cadena.GetValue(7), cadena.GetValue(8), cadena.GetValue(9))
                        registrosTXT.Add(registroTXT, intSecuencia)

                    End If

                    intSecuencia = intSecuencia + 1

                Loop

                FileClose(PunteroArchivo)

            Catch ex1 As Exception
                MsgBox("Error " & ex1.Message.ToString)
                Return Nothing
            End Try

            Return registrosTXT

        End Function


        Public Shared Function LineasTXT(ByRef rutaOrigen As String) As Integer
            'Funcion para separar campos separados por | de un txt (puede ser cualquier separador)
            Dim intSecuencia As Integer = 0
            Dim registrosTXT As New Collection
            'Dim registroTXT As libreriacadenaproduccion.Entidades.clsRegistroTXT
            'Dim cadena As String()

            If rutaOrigen = "" Then
                MsgBox("Error, faltan datos", MsgBoxStyle.Critical, "Error")
            End If

            Try

                Dim PunteroArchivo As Integer = FreeFile()          ' Apuntador libre a archivo
                Dim LineaTexto As String                            ' Variable donde guardamos cada línea de texto



                FileOpen(PunteroArchivo, rutaOrigen, OpenMode.Input, OpenAccess.Read)                   ' Abrimos el archivo y lo recorremos hasta el final línea por línea

                Do While Not EOF(PunteroArchivo)

                    LineaTexto = LineInput(PunteroArchivo)  ' Leemos la línea de texto del archivo

                    If LineaTexto <> "" Then
                        intSecuencia = intSecuencia + 1
                    End If

                Loop

                FileClose(PunteroArchivo)

            Catch ex1 As Exception
                MsgBox("Error " & ex1.Message.ToString)
                Return 0
            End Try

            Return intSecuencia

        End Function

        Public Shared Function leerContenidoFichero(ByVal fichero As String, Optional ByRef lineas As Integer = 0) As String

            Dim sContent As String = ""

            Try

                With My.Computer.FileSystem
                    ' verifica si existe el path
                    If .FileExists(fichero) Then
                        ' lee todo el contenido
                        sContent = .ReadAllText(fichero)
                        lineas = Split(sContent, vbCr).Count - 1
                    Else
                        MsgBox("ruta inválida, no se ha encontrado el fichero " & fichero, MsgBoxStyle.Critical, "error")
                    End If
                End With


                ' errores
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try

            Return sContent

        End Function

    End Class


End Namespace

