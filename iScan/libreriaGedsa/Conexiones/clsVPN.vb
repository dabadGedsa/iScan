Option Strict Off
Option Explicit On

Imports accesoDatosOracle = LibreriaCadenaProduccion.Datos.GeneralOracle.clsAccesoDatosOracle

Imports System.IO

Namespace VPN

    Public Class clsVPN

        Public Shared Function ConectarVPN(ByVal cadenaProfile As String, ByVal cadenaUser As String) As Boolean
            Dim cmd As System.Diagnostics.Process = New System.Diagnostics.Process
            cmd.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden
            cmd.StartInfo.CreateNoWindow = False
            cmd.StartInfo.UseShellExecute = True
            cmd.StartInfo.WorkingDirectory = "C:\Archivos de programa\Cisco Systems\VPN Client\"
            cmd.StartInfo.FileName = "vpnclient.exe"

            cmd.StartInfo.Arguments = " connect " & cadenaProfile & cadenaUser
            Try

                cmd.Start()

            Catch er1 As Exception
                MsgBox("Error, no se ha podido conectar al profile VPN." & vbCr & er1.Message.ToString)
                Return False
            End Try

            Return True

        End Function

        Public Shared Function DesconectarVPN(ByVal cadenaProfile As String) As Boolean

            Dim cmd As System.Diagnostics.Process = New System.Diagnostics.Process
            cmd.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden
            cmd.StartInfo.CreateNoWindow = False
            cmd.StartInfo.UseShellExecute = True
            cmd.StartInfo.WorkingDirectory = "C:\Archivos de programa\Cisco Systems\VPN Client\"
            cmd.StartInfo.FileName = "vpnclient.exe"

            cmd.StartInfo.Arguments = " disconnect " & cadenaProfile
            Try

                cmd.Start()

            Catch er1 As Exception
                MsgBox("Error, no se ha podido desconectar correctamente la conexión VPN" & vbCr & er1.Message.ToString)
                Return False
            End Try

            Return True

        End Function



    End Class

End Namespace
