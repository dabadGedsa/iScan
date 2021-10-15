Imports System.IO
Imports System.Windows.Forms
Imports system.Data.OleDb

Namespace EntradaSAlida




    Public Class ClsEntradaSalida


        Public Shared Function SolicitarRuta(Optional ByVal mensajeTitulo As String = "") As String

            Dim ofdObtenerRuta As New System.Windows.Forms.FolderBrowserDialog
            Dim ruta As String = ""


            Try
                ofdObtenerRuta.RootFolder = Environment.SpecialFolder.MyComputer
                ofdObtenerRuta.Description = mensajeTitulo
                ofdObtenerRuta.ShowDialog()
                ruta = ofdObtenerRuta.SelectedPath

            Catch err As Exception
                System.Windows.Forms.MessageBox.Show("Error, no se ha podido encontrar la ruta especificada :" & err.Message)
            End Try

            Return ruta

        End Function

        Public Shared Function CopiarFicheros(ByVal origen As String, ByVal destino As String, Optional ByRef mensajeSalida As String = "") As Boolean

            Try

                My.Computer.FileSystem.CopyFile(origen, destino, FileIO.UIOption.AllDialogs, FileIO.UICancelOption.ThrowException)

            Catch ex As Exception
                mensajeSalida = ex.Message
                Return False
            End Try

            Return True

        End Function

        Public Shared Function CopiarFicherosAutomatico(ByVal origen As String, ByVal destino As String, Optional ByRef mensajeSalida As String = "") As Boolean

            Try

                My.Computer.FileSystem.CopyFile(origen, destino, True)

            Catch ex As Exception
                mensajeSalida = ex.Message
                Return False
            End Try

            Return True

        End Function

       




    End Class


End Namespace