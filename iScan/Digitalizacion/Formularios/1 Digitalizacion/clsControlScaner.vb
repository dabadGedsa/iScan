Public Class clsControlScaner

    Private Shared scaner As AxScanLibCtl.AxImgScan



    Public Enum compresion
        CCITTGroup31D = ScanLibCtl.CompTypeConstants.CCITTGroup31D
        CCITTGroup42D = ScanLibCtl.CompTypeConstants.CCITTGroup42D
        JPEGCompression = ScanLibCtl.CompTypeConstants.JPEGCompression
        LZWCompression = ScanLibCtl.CompTypeConstants.LZWCompression
        TIFFPackbits = ScanLibCtl.CompTypeConstants.TIFFPackbits
        Uncompressed = ScanLibCtl.CompTypeConstants.Uncompressed
    End Enum


    Public Enum calidadExploracion
        MejorCalidad = ScanLibCtl.CompPreferenceConstants.BestDisplay
        Buena = ScanLibCtl.CompPreferenceConstants.GoodDisplay
        Borrador = ScanLibCtl.CompPreferenceConstants.SmallestFile
    End Enum

    Public Enum tipoArchivo
        TIFF = ScanLibCtl.FileTypeConstants.TIFF
        BMP = ScanLibCtl.FileTypeConstants.BMP_Bitmap
        JPF = ScanLibCtl.FileTypeConstants.JPG_File
        FAX = ScanLibCtl.FileTypeConstants.AWD_MicrosoftFax
    End Enum

    Public Enum tipoImagen
        BlancoNegro = ScanLibCtl.ImageTypeConstants.BlackAndWhite1Bit
        Gris4bits = ScanLibCtl.ImageTypeConstants.Gray4Bit
        Gris8bits = ScanLibCtl.ImageTypeConstants.Gray8Bit
        Color24Bits = ScanLibCtl.ImageTypeConstants.TrueColor24bitRGB
    End Enum

    Public Enum TipoPagina
        EscalaGris16bit = ScanLibCtl.PageTypeConstants.Gray16Shades
        EscalaGris256bits = ScanLibCtl.PageTypeConstants.Gray256Shades
        BlancoNegro = ScanLibCtl.PageTypeConstants.BlackAndWhite
        Color16bits = ScanLibCtl.PageTypeConstants.Color16Count
        Color256bits = ScanLibCtl.PageTypeConstants.Color256Count
        colorResaltado24bits = ScanLibCtl.PageTypeConstants.HighColor24bit
        ColorVerdadero24bits = ScanLibCtl.PageTypeConstants.TrueColor24bit
    End Enum


    'Public Enum infoCompresion
    '    G31DFax = ScanLibCtl.CompInfoConstants.G31DFax
    '    G31DFax = ScanLibCtl.CompInfoConstants.NoCompInfo
    '    G31DFax = ScanLibCtl.CompInfoConstants.G31DFax
    '    G31DFax = ScanLibCtl.CompInfoConstants.G31DFax
    '    G31DFax = ScanLibCtl.CompInfoConstants.G31DFax
    '    G31DFax = ScanLibCtl.CompInfoConstants.G31DFax
    '    G31DFax = ScanLibCtl.CompInfoConstants.G31DFax
    '    G31DFax = ScanLibCtl.CompInfoConstants.G31DFax
    '    G31DFax = ScanLibCtl.CompInfoConstants.G31DFax
    '    G31DFax = ScanLibCtl.CompInfoConstants.G31DFax
    '    G31DFax = ScanLibCtl.CompInfoConstants.G31DFax

    'End Enum

    'Public Shared scan_tipoArchivo As tipoArchivo
    'Public Shared scan_tipoimagen As TipoImagen
    'Public Shared scan_tipoPagina As TipoPagina
    'Public Shared scan_calidadExploracion As calidadExploracion
    'Public Shared scan_compresion As compresion




    Public Sub New(ByRef controlScaner As AxScanLibCtl.AxImgScan)

        Try
            scaner = controlScaner
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Public Shared Sub AplicarConfiguracion(ByVal scan_tipoArchivo As tipoArchivo, ByVal scan_tipoimagen As tipoImagen, _
                                            ByVal scan_tipoPagina As TipoPagina, ByVal scan_calidadExploracion As calidadExploracion, _
                                             ByVal scan_compresion As compresion)

        Try
            scaner.FileType = scan_tipoArchivo
            scaner.PageType = scan_tipoPagina
            scaner.SetPageTypeCompressionOpts(scan_calidadExploracion, scan_tipoimagen, scan_compresion, ScanLibCtl.CompInfoConstants.NoCompInfo)
        Catch ex As Exception
            MessageBox.Show("Error, configuracion del escaner no es correcta" & ex.ToString)
        End Try


    End Sub


End Class
