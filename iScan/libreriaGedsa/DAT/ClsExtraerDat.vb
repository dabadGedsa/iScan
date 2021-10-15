Option Strict Off
Option Explicit On

Imports System.IO


Namespace DAT

    <System.Runtime.InteropServices.ProgId("ClsExtraerDat_NET.ClsExtraerDat")> Public Class ClsExtraerDat
        Dim tamanyoArchivo As Integer



        Const BLOQUE_IMAGEN As Short = 8192 * 2
        Const OF_READ As Integer = &H0

        Private Const SizeHeaderImagenDOC6 As Short = 256

        Private Declare Function lopen Lib "kernel32" Alias "_lopen" (ByVal lpPathName As String, ByVal iReadWrite As Integer) As Integer
        Private Declare Function lclose Lib "kernel32" Alias "_lclose" (ByVal hfile As Integer) As Integer
        Private Declare Function lcreat Lib "kernel32" Alias "_lcreat" (ByVal lpPathName As String, ByVal iAttribute As Integer) As Integer
        Private Declare Function lread Lib "kernel32" Alias "_lread" (ByVal hfile As Integer, ByVal lpBuffer As String, ByVal wBytes As Integer) As Integer
        Private Declare Function lwrite Lib "kernel32" Alias "_lwrite" (ByVal hfile As Integer, ByVal lpBuffer As String, ByVal wBytes As Integer) As Integer

        Private Declare Function GetTempFileName Lib "kernel32" Alias "GetTempFileNameA" (ByVal lpszPath As String, ByVal lpPrefixString As String, ByVal wUnique As Integer, ByVal lpTempFileName As String) As Integer
        Shared ContadorImg As Integer


        Public Shared Function ExtraerImagenDAT(ByRef sDispositivo As String, ByVal InicioDocumento As Integer, ByRef SizeDocumento As Integer, ByRef CadenaControl As String, ByRef DestinoImg As String) As String
            On Error Resume Next

            Dim sFicheroOut As String
            Dim hfile As Integer
            Dim buffer As String
            Dim BufControl As String
            Dim lFileSize As Integer
            Dim lPosFic As Integer
            Dim i As Short
            Dim lBytesPorLeer As Integer
            Dim lBytesLeidos As Integer
            Dim NFImp As Short
            'BLOQUE_IMAGEN = 32771
            Dim glTamañoImg As Integer

            Dim n1, ind As Short
            Dim R As Short

            ContadorImg = ContadorImg + 1
            sFicheroOut = DestinoImg & "\Img" & ContadorImg & ".tif"

            NFImp = FreeFile()

            Err.Clear()
            FileOpen(NFImp, sDispositivo, OpenMode.Binary, OpenAccess.Read)
            If Err.Number Then
                Err.Raise(Err.Number)
                Return ""
            End If

            'Tamaño imagen
            lFileSize = SizeDocumento
            lBytesPorLeer = lFileSize

            'Buffer de lectura
            If lFileSize < BLOQUE_IMAGEN Then
                buffer = Space(lFileSize)
            Else
                buffer = Space(BLOQUE_IMAGEN)
            End If

            'Abrir el fichero temporal
            hfile = lcreat(sFicheroOut, 0)

            'Inicio el el fichero de datos, de la imagen
            lPosFic = InicioDocumento
            Seek(NFImp, lPosFic)
            Err.Clear()
            'Quitar Cadena de control
            CadenaControl = Space(SizeHeaderImagenDOC6)
            FileGet(NFImp, CadenaControl)

            Do
                'Leer fichero de datos
                FileGet(NFImp, buffer)
                'Escribir en fichero temporal
                '  MsgBox Len(Buffer)
                If lFileSize < BLOQUE_IMAGEN Then
                    lBytesLeidos = lwrite(hfile, buffer, lFileSize)

                    Exit Do
                Else
                    lBytesLeidos = lwrite(hfile, buffer, BLOQUE_IMAGEN)
                End If
                'Por si error
                If lBytesLeidos = 0 Then Exit Do

                lBytesPorLeer = lBytesPorLeer - lBytesLeidos
                If lBytesPorLeer < BLOQUE_IMAGEN Then
                    buffer = Space(lBytesPorLeer)
                    'Ultima lectura
                    FileGet(NFImp, buffer)
                    'Escribir en fichero temporal
                    lBytesLeidos = lwrite(hfile, buffer, lBytesPorLeer)

                    Exit Do
                End If

            Loop

            FileClose(NFImp)

            ExtraerImagenDAT = sFicheroOut

            R = lclose(hfile)

        End Function



        Public Shared Function extraerImagenDatAMemoria(ByRef archivoDat As String, ByVal inicioDocumento As Integer, ByRef tamañoDocumento As Integer) As Byte()

            Dim frDat As FileStream = New FileStream(archivoDat, FileMode.Open, FileAccess.Read, FileShare.Read)
            Dim buffer(tamañoDocumento - 1) As Byte
            Dim bytesLeidos As Integer = 0
            Dim numBytesParaLeer As Integer

            ' Nos posicionamos en el inicio del documento
            frDat.Position = inicioDocumento + SizeHeaderImagenDOC6 - 1

            ' Especificamos los bytes a leer
            If tamañoDocumento < BLOQUE_IMAGEN Then
                numBytesParaLeer = tamañoDocumento
            Else
                numBytesParaLeer = BLOQUE_IMAGEN
            End If

            While numBytesParaLeer > 0

                ' Leemos el fichero dat
                frDat.Read(buffer, bytesLeidos, numBytesParaLeer)

                bytesLeidos += numBytesParaLeer

                ' Especificamos los siguientes bytes para leer
                If tamañoDocumento - bytesLeidos > BLOQUE_IMAGEN Then
                    numBytesParaLeer = BLOQUE_IMAGEN
                ElseIf tamañoDocumento - bytesLeidos > 0 Then
                    numBytesParaLeer = tamañoDocumento - bytesLeidos
                Else
                    numBytesParaLeer = 0
                End If

            End While

            frDat.Close()

            Return buffer

        End Function



        Public Shared Function AgregarImagen(ByVal pArchivo As String, ByRef pImg As String, ByRef pAnexar As Boolean) As String

            Dim hfile As Integer
            Dim buffer As String
            Dim iBytesLeidos As Short
            Dim lBytesRestantes As Integer
            Dim lFileSize As Integer
            Dim i As Integer
            Dim sFicheroDev As String
            Dim lPosFic As Integer
            Dim CadenaControl As String
            Dim nfOut As Short

            Debug.Print(pArchivo)
            nfOut = FreeFile()

            sFicheroDev = pArchivo

            FileOpen(nfOut, sFicheroDev, OpenMode.Binary, OpenAccess.Write)

            hfile = lopen(pImg, OF_READ)    'Abrir el fichero temporal
            lFileSize = FileLen(pImg)       'Obtener el Tamaño real a grabar


            lBytesRestantes = lFileSize

            'Adecuar el tamaño del buffer de lectura
            If lFileSize < BLOQUE_IMAGEN Then
                buffer = Space(lFileSize)
            Else
                buffer = Space(BLOQUE_IMAGEN)
            End If

            'Para anexar la imagen al archivo
            If pAnexar = True Then
                lPosFic = LOF(nfOut) + 1
                Seek(nfOut, lPosFic)
            Else
                lPosFic = 1
                Seek(nfOut, lPosFic)
            End If

            'Creamos la cadena de control 
            CadenaControl = New String("$", SizeHeaderImagenDOC6)


            FilePut(nfOut, CadenaControl)

            Do

                iBytesLeidos = lread(hfile, buffer, Len(buffer))      'Leer fichero temporal
                FilePut(nfOut, buffer)                                'Escribir fichero de datos
                System.Windows.Forms.Application.DoEvents()
                lBytesRestantes = lBytesRestantes - iBytesLeidos      'Bytes por leer
                If lBytesRestantes < BLOQUE_IMAGEN Then

                    buffer = Space(lBytesRestantes)                   'Ultima lectura y fin
                    iBytesLeidos = lread(hfile, buffer, Len(buffer))  'Leer fichero temporal
                    FilePut(nfOut, buffer)                            'Escribir fichero de datos
                    Exit Do
                End If
                System.Windows.Forms.Application.DoEvents()
            Loop


            i = lclose(hfile)                                           'Cerra fichero temporal

            FileClose(nfOut)

            AgregarImagen = lPosFic & "$" & lFileSize


        End Function


    End Class


End Namespace
