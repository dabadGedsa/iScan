Imports consulta = LibreriaCadenaProduccion.Datos.GeneralSQL.clsAccesoDatosSQL

Namespace Entidades

    Public Class clsDocumentoE

#Region "Variables privadas"

        Private idDocumento As Long
        Private idLote As Integer
        Private pagina As Integer
        Private nomArchivo As String
        Private tipoDocumento As clsTipoDocumentoE
        Private fechaInicio As String
        Private fechaFin As String
        Private fechaDocumento As String
        Private Servicio As clsServicioE
        Private tipoEpisodio As String
        Private numIcu As String
        Private numHistoria As Long
        Private indizado As Integer
        Private barCodeDet As Integer
        Private Incidencia As Integer
        Private Eliminada As Integer
        Private DocumentoMalEstado As Integer
        Private Imagen As System.IO.Stream
        Private rutaDocumento As String
        Private documentoEnLocal As Boolean
        Private documentoEnBD As Boolean

#End Region

#Region "Constructores y destructores"

        Public Sub New()

        End Sub

        Public Sub New(ByVal idDocumento As Integer)

            Try
                'Hace consulta para cargar el objeto documento
                ' ''obtenerDatosDocumento(idDocumento)

            Catch ex As Exception
                Throw ex
            End Try

        End Sub

        Public Sub New(ByVal id As Long, ByVal lote As Integer, ByVal pagina As Integer, ByVal nombre As String, ByVal historia As String, ByVal rutadocumento As String)
            Me.idDocumento = id
            Me.idLote = lote
            Me.pagina = pagina
            Me.nomArchivo = nombre
            If historia = 0 Then Me.numHistoria = Nothing Else Me.numHistoria = historia
            Me.indizado = 0
            Me.barCodeDet = 0
            Me.Incidencia = 0
            Me.Eliminada = 0
            Me.documentoEnLocal = True
            Me.documentoEnBD = False
            Me.rutaDocumento = rutadocumento
        End Sub

#End Region

#Region "Propiedades"

        Public Property _idDocumento() As Long
            Get
                Return Me.idDocumento
            End Get
            Set(ByVal value As Long)
                Me.idDocumento = value
            End Set
        End Property

        Public Property _Lote() As Integer
            Get
                Return Me.idLote
            End Get
            Set(ByVal value As Integer)
                Me.idLote = value
            End Set
        End Property

        Public Property _pagina() As Integer
            Get
                Return Me.pagina
            End Get
            Set(ByVal value As Integer)
                Me.pagina = value
            End Set
        End Property

        Public Property _nombreArchivo() As String
            Get
                Return Me.nomArchivo
            End Get
            Set(ByVal value As String)
                Me.nomArchivo = value
            End Set
        End Property

        Public Property _TipoDocumento() As clsTipoDocumentoE
            Get
                Return Me.TipoDocumento
            End Get
            Set(ByVal value As clsTipoDocumentoE)
                Me.TipoDocumento = value
            End Set
        End Property

        Public Property _fechaInicio() As String
            Get
                Return Me.fechaInicio
            End Get
            Set(ByVal value As String)
                Me.fechaInicio = value
            End Set
        End Property

        Public Property _fechaFin() As String
            Get
                Return Me.fechaFin
            End Get
            Set(ByVal value As String)
                Me.fechaFin = value
            End Set
        End Property

        Public Property _fechaDocumento() As String
            Get
                Return Me.fechaDocumento
            End Get
            Set(ByVal value As String)
                Me.fechaDocumento = value
            End Set
        End Property

        Public Property _Servicio() As clsServicioE
            Get
                Return Me.Servicio
            End Get
            Set(ByVal value As clsServicioE)
                Me.Servicio = value
            End Set
        End Property

        Public Property _tipoEpisodio() As String
            Get
                Return Me.tipoEpisodio
            End Get
            Set(ByVal value As String)
                Me.tipoEpisodio = value
            End Set
        End Property

        Public Property _numIcu() As String
            Get
                Return Me.numicu
            End Get
            Set(ByVal value As String)
                Me.numicu = value
            End Set
        End Property

        Public Property _historia() As Long
            Get
                Return Me.numHistoria
            End Get
            Set(ByVal value As Long)
                Me.numHistoria = value
            End Set
        End Property

        Public Property _Indizado() As Integer
            Get
                Return indizado
            End Get
            Set(ByVal value As Integer)
                indizado = value
            End Set
        End Property

        Public Property _BarCodeDet() As Integer
            Get
                Return barCodeDet
            End Get
            Set(ByVal value As Integer)
                barCodeDet = value
            End Set
        End Property

        Public Property _Incidencia() As Integer
            Get
                Return Incidencia
            End Get
            Set(ByVal value As Integer)
                Incidencia = value
            End Set
        End Property

        Public Property _Eliminado() As Integer
            Get
                Return Eliminada
            End Get
            Set(ByVal value As Integer)
                Eliminada = value
            End Set
        End Property

        Public Property _DocumentoMalEstado() As Integer
            Get
                Return DocumentoMalEstado
            End Get
            Set(ByVal value As Integer)
                DocumentoMalEstado = value
            End Set
        End Property

        Public Property _imagen() As System.IO.Stream
            Get
                Return Me.imagen
            End Get
            Set(ByVal value As System.IO.Stream)
                Me.imagen = value
            End Set
        End Property

        Public Property _rutaDocumento() As String
            Get
                Return Me.rutaDocumento
            End Get
            Set(ByVal value As String)
                Me.rutaDocumento = value
            End Set
        End Property

        Public Property _documentoEnLocal() As Boolean
            Get
                Return Me.documentoEnLocal
            End Get
            Set(ByVal value As Boolean)
                Me.documentoEnLocal = value
            End Set
        End Property

        Public Property _documentoEnBD() As Boolean
            Get
                Return Me.documentoEnBD
            End Get
            Set(ByVal value As Boolean)
                Me.documentoEnBD = value
            End Set
        End Property
#End Region

        ' ''Private Sub obtenerDatosDocumento(ByVal idDocumento As Integer)
        ' ''    Dim lsSql As String = "SELECT * FROM DOCUMENTOS d LEFT JOIN TIPOSDOCUMENTOS td ON td.idTipoDocumento = d.TipoDocumento LEFT JOIN SERVICIOS s on s.idServicio = d.CodServicioPAED WHERE idDocumento=" & idDocumento
        ' ''    ' ''Dim lsSql As String = "SELECT * FROM DOCUMENTOS d LEFT JOIN TIPOSDOCUMENTOS td ON td.idTipoDocumento = d.TipoDocumento LEFT JOIN SERVICIOS s on s.idServicio = d.CodServicioPAED LEFT JOIN DOCUMENTOSINCIDENCIAS di on di.idDocumento = d.idDocumento WHERE di.Tipo='DIGI' AND di.IdIncidencia=2 AND d.idDocumento=" & idDocumento
        ' ''    Dim dt As DataTable

        ' ''    Try
        ' ''        dt = consulta.ejecutarSQLDirectaTable(lsSql, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto)
        ' ''        If dt.Rows.Count > 0 Then
        ' ''            Me.idDocumento = idDocumento
        ' ''            Me.idLote = dt.Rows(0).Item("idLote")
        ' ''            Me.pagina = dt.Rows(0).Item("Pagina")
        ' ''            Me.nomArchivo = dt.Rows(0).Item("NomArchivoTIF").ToString.Trim

        ' ''            Me.tipoDocumento = New clsTipoDocumentoE()
        ' ''            If IsDBNull(dt.Rows(0).Item("Descripcion")) Then Me.tipoDocumento._DescripcionTipoDocumento = Nothing Else Me.tipoDocumento._DescripcionTipoDocumento = dt.Rows(0).Item("Descripcion").ToString.Trim
        ' ''            If IsDBNull(dt.Rows(0).Item("idTipoDocumento")) Then Me.tipoDocumento._idTipoDocumento = Nothing Else Me.tipoDocumento._idTipoDocumento = dt.Rows(0).Item("idTipoDocumento").ToString.Trim
        ' ''            If IsDBNull(dt.Rows(0).Item("DefinicionCliente")) Then Me.tipoDocumento._DescripcionTipoDocumentoCliente = Nothing Else Me.tipoDocumento._DescripcionTipoDocumentoCliente = dt.Rows(0).Item("DefinicionCliente").ToString.Trim
        ' ''            If IsDBNull(dt.Rows(0).Item("idTipoDocumentoCliente")) Then Me.tipoDocumento._idTipoDocumentoCliente = Nothing Else Me.tipoDocumento._idTipoDocumentoCliente = dt.Rows(0).Item("idTipoDocumentoCliente").ToString.Trim
        ' ''            If IsDBNull(dt.Rows(0).Item("CodigoOrdenacion")) Then Me.tipoDocumento._codigoOrdenacion = Nothing Else Me.tipoDocumento._codigoOrdenacion = dt.Rows(0).Item("CodigoOrdenacion").ToString.Trim

        ' ''            Me.fechaInicio = dt.Rows(0).Item("FechaInicio").ToString.Trim
        ' ''            Me.fechaFin = dt.Rows(0).Item("FechaTermino").ToString.Trim
        ' ''            Me.fechaDocumento = dt.Rows(0).Item("FechaDocumento").ToString.Trim

        ' ''            Me.Servicio = New clsServicioE()
        ' ''            If IsDBNull(dt.Rows(0).Item("idServicio")) Then Me.Servicio._idServicio = Nothing Else Me.Servicio._idServicio = dt.Rows(0).Item("idServicio")
        ' ''            If IsDBNull(dt.Rows(0).Item("cod_servicio")) Then Me.Servicio._codigoServicio = Nothing Else Me.Servicio._codigoServicio = dt.Rows(0).Item("cod_servicio").ToString.Trim
        ' ''            If IsDBNull(dt.Rows(0).Item("Descripcion")) Then Me.Servicio._descripcionServicio = Nothing Else Me.Servicio._descripcionServicio = dt.Rows(0).Item("descripcion").ToString.Trim
        ' ''            If IsDBNull(dt.Rows(0).Item("area")) Then Me.Servicio._area = Nothing Else Me.Servicio._area = dt.Rows(0).Item("area").ToString.Trim
        ' ''            If IsDBNull(dt.Rows(0).Item("Visible")) Then Me.Servicio._visible = Nothing Else Me.Servicio._visible = dt.Rows(0).Item("Visible")

        ' ''            Me.tipoEpisodio = dt.Rows(0).Item("TipoEpisodioPAED").ToString.Trim
        ' ''            Me.numIcu = dt.Rows(0).Item("numIcu").ToString.Trim
        ' ''            If dt.Rows(0).Item("NumHistoria").ToString.Trim <> "" Then
        ' ''                Me.numHistoria = dt.Rows(0).Item("NumHistoria").ToString.Trim
        ' ''            Else
        ' ''                Me.numHistoria = Nothing
        ' ''            End If

        ' ''            If IsDBNull(dt.Rows(0).Item("indizado")) Then
        ' ''                Me.indizado = 0
        ' ''            Else
        ' ''                Me.indizado = dt.Rows(0).Item("indizado")
        ' ''            End If
        ' ''            If IsDBNull(dt.Rows(0).Item("BarCodeDet")) Then
        ' ''                Me.barCodeDet = 0
        ' ''            Else
        ' ''                Me.barCodeDet = dt.Rows(0).Item("BarCodeDet")
        ' ''            End If
        ' ''            If IsDBNull(dt.Rows(0).Item("Incidencia")) Then
        ' ''                Me.Incidencia = 0
        ' ''            Else
        ' ''                Me.Incidencia = dt.Rows(0).Item("Incidencia")
        ' ''            End If
        ' ''            If IsDBNull(dt.Rows(0).Item("Eliminada")) Then
        ' ''                Me.Eliminada = 0
        ' ''            Else
        ' ''                Me.Eliminada = dt.Rows(0).Item("Eliminada")
        ' ''            End If

        ' ''            ' ''If dt.Rows(0).Item("pagina") = 407 Then Stop

        ' ''            If IsDBNull(dt.Rows(0).Item("documentoEnLocal")) Then
        ' ''                Me.documentoEnLocal = False
        ' ''                Me.rutaDocumento = frmContenedorMDI.oProyecto._rutaImagenes & "\" & Format(Val(frmContenedorMDI.oProyecto._CodigoProyecto), "0000") & "\DIGI\" & Format(Val(frmContenedorMDI.oProyecto._CodigoProyecto), "0000") & Format(Val(Me._Lote), "00000") & "\Imagen\" & Me._Lote & "\" & Me._nombreArchivo
        ' ''            Else
        ' ''                If dt.Rows(0).Item("documentoEnLocal") = 0 Then
        ' ''                    Me.documentoEnLocal = False
        ' ''                    Me.rutaDocumento = frmContenedorMDI.oProyecto._rutaImagenes & "\" & Format(Val(frmContenedorMDI.oProyecto._CodigoProyecto), "0000") & "\DIGI\" & Format(Val(frmContenedorMDI.oProyecto._CodigoProyecto), "0000") & Format(Val(Me._Lote), "00000") & "\Imagen\" & Me._Lote & "\" & Me._nombreArchivo
        ' ''                Else
        ' ''                    Me.documentoEnLocal = True
        ' ''                    Me.rutaDocumento = My.Settings.DIGI_rutaLocalImagenes & "\" & Format(Val(frmContenedorMDI.oProyecto._CodigoProyecto), "0000") & "\DIGI\" & Format(Val(frmContenedorMDI.oProyecto._CodigoProyecto), "0000") & Format(Val(Me._Lote), "00000") & "\Imagen\" & Me._Lote & "\" & Me._nombreArchivo
        ' ''                End If

        ' ''            End If
        ' ''            Me.documentoEnBD = True

        ' ''        End If

        ' ''        dt.Clear()

        ' ''    Catch ex As Exception
        ' ''        Throw ex

        ' ''    Finally

        ' ''    End Try

        ' ''End Sub


    End Class


End Namespace
