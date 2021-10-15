Option Strict Off
Option Explicit On

Imports clsExtraerTXT = libreriacadenaproduccion.TXT.ClsExtraerTXT
Imports clsLote = libreriacadenaproduccion.Entidades.ClsLote
Imports clsUsuario = libreriacadenaproduccion.Entidades.ClsUsuario
Imports accesoDatosOracle = libreriacadenaproduccion.Datos.GeneralOracle.clsAccesoDatosOracle

Imports System.IO

Namespace RAR

    Public Class clsRAR

        Public Shared Function SentenciaDescomprimir(ByVal origen As String, ByVal destino As String, ByVal params As String) As Boolean
            Dim cmd As System.Diagnostics.Process = New System.Diagnostics.Process
            cmd.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden
            cmd.StartInfo.CreateNoWindow = False
            cmd.StartInfo.UseShellExecute = True
            cmd.StartInfo.WorkingDirectory = "C:\Archiv~1\WinRAR\"
            cmd.StartInfo.FileName = "rar.exe"

            'cmd.StartInfo.Arguments = " a -ep " & origen & lote._idloteCompleto & ".zip " & lote._archivoMdb & " " & lote._archivoDat
            'los params son x -p<password>  
            'Muy importante para que no se quede bloqueado esperando parametros de entrada 
            'hay que poner los siguientes parametros  o+ y x -phlp02 
            cmd.StartInfo.Arguments = params & origen & " " & destino
            Try

                cmd.Start()

                If cmd.WaitForExit(4000) Then

                Else
                    cmd.Kill()
                    cmd.Close()
                End If


            Catch er As ExecutionEngineException
                MsgBox("Error,no se ha podido descomprimir el fichero en el destino." & vbCr & er.Message.ToString)
                Return False
            Catch er1 As Exception
                MsgBox("Error, no se ha podido descomprimir el fichero en el destino." & vbCr & er1.Message.ToString)
                Return False
            End Try

            Return True

        End Function

        Public Shared Function SentenciaComprimir(ByVal fichero As String, ByVal dirimagenes As String, ByVal params As String) As Boolean

            Dim cmd As System.Diagnostics.Process = New System.Diagnostics.Process
            cmd.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden
            cmd.StartInfo.CreateNoWindow = False
            cmd.StartInfo.UseShellExecute = True
            cmd.StartInfo.WorkingDirectory = "C:\Archiv~1\WinRAR\"
            cmd.StartInfo.FileName = "rar.exe"

            'los params son a -ep
            cmd.StartInfo.Arguments = params & fichero & " " & dirimagenes
            Try

                cmd.Start()

            Catch er As ExecutionEngineException
                MsgBox("Error,no se ha podido comprimir el fichero en el destino." & vbCr & er.Message.ToString)
                Return False
            Catch er1 As Exception
                MsgBox("Error, no se ha podido comprimir el fichero en el destino." & vbCr & er1.Message.ToString)
                Return False
            End Try

            Return True

        End Function

        Public Shared Function SentenciaFirma(ByVal fichero As String, ByVal dirimagenes As String, ByVal params As String) As Boolean

            Dim cmd As System.Diagnostics.Process = New System.Diagnostics.Process
            cmd.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal
            cmd.StartInfo.CreateNoWindow = False
            cmd.StartInfo.UseShellExecute = True
            'cmd.StartInfo.RedirectStandardOutput = True
            cmd.StartInfo.WorkingDirectory = "C:\temp\"
            cmd.StartInfo.FileName = "C:\Users\usuario4\Downloads\Opaef\Cuadrado\OPAEF_Cuadrado.bat"

            'los params son a -ep
            ' cmd.StartInfo.Arguments = " -crop 330x125+140+1010 -format ""%[kurtosis]""  c:\temp\iml00001.tif "
            Try

                cmd.Start()
            
                'Dim str As String = cmd.StandardOutput.ReadToEnd
                If cmd.WaitForExit(40000) Then

                Else
                    cmd.Kill()
                    cmd.Close()
                End If

            Catch er As ExecutionEngineException
                MsgBox("Error,no se ha podido comprimir el fichero en el destino." & vbCr & er.Message.ToString)
                Return False
            Catch er1 As Exception
                MsgBox("Error, no se ha podido comprimir el fichero en el destino." & vbCr & er1.Message.ToString)
                Return False
            End Try

            Return True

        End Function



    End Class






End Namespace
