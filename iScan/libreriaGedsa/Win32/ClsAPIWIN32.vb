Imports System.IO
Imports System.Text
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace Win32

    Public Class ClsAPIWIN32

        <DllImport("kernel32.dll")> _
        Public Shared Function GetVolumeInformation(ByVal lpRootPathName As String, _
                                               ByVal lpVolumeNameBuffer As StringBuilder, _
                                               ByVal nVolumeNameSize As Integer, _
                                               ByRef lpVolumeSerialNumber As Integer, _
                                               ByRef lpMaximumComponentLength As Integer, _
                                               ByRef lpFileSystemFlags As Integer, _
                                               ByVal lpFileSystemNameBuffer As StringBuilder, _
                                               ByVal nFileSystemNameSize As Integer) As Boolean
        End Function

    End Class

End Namespace
