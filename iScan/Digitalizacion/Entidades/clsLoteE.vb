Imports System.IO
Imports System.Windows.Forms
Imports consulta = libreriacadenaproduccion.Datos.GeneralSQL.clsAccesoDatosSQL

Namespace Entidades

    Public Class clsLoteE

#Region "Variables privadas"

        Private idLote As Integer
        Private codigoProyecto As String
        Private fechaLote As String
        Private activo As Integer
        Private asignado As Integer
        Private totImagenes As Integer
        Private preparado As Integer
        Private digitalizado As Integer
        Private importado As Integer
        Private verificado As Integer
        Private corregido As Integer
        Private traspasado As Integer
        Private finalizado As Integer
        Private atributado As Integer
        Private corregidoatributado As Integer
        Private tipoLote As String
        Private grises As Integer
        Private nomContenedor As String
        Private rutaLote As String
        Private rutaLoteLocal As String

        Private ColeccionDocumentos As New List(Of clsDocumentoE)


#End Region

#Region "Constructores y destructores"

        Public Sub New()

        End Sub

        Public Sub New(ByVal lote As String, ByVal codigoproyecto As String)
            Try
                'Hace consulta para cargar el objeto lote
                obtenerDatosLote(lote, codigoproyecto)

                ' ''obtenerDocumentosLote(lote)

            Catch ex As Exception
                Throw ex
            End Try

        End Sub

        ''' <summary>
        ''' Constructor del objeto lote
        ''' </summary>
        ''' <param name="lote">nombre del lote, lote1 , lote2, lote3</param>
        ''' <param name="codigoproyecto ">Identifica al proyecto al que pertenece el lote </param> 
        ''' <param name="fechalote">es util para diferenciar los lotes dentro de un mism proyecto en años diferentes</param> 
        ''' <remarks> 
        '''se crea un lote con el codigo del proyecto 
        ''' </remarks> 
        Public Sub New(ByVal lote As String, ByVal codigoproyecto As String, ByVal fechalote As String)
            Me.codigoProyecto = codigoproyecto
            Me.idLote = lote
            Me.tipoLote = tipoLote
            Me.fechalote = fechalote
        End Sub

        Public Sub New(ByVal lote As Integer, ByVal proyecto As String)
            Me.idLote = lote
            Me.codigoProyecto = proyecto
        End Sub

#End Region

#Region "Propiedades"
        Public Property _Lote() As Integer
            Get
                Return idLote
            End Get
            Set(ByVal value As Integer)
                idLote = value
            End Set
        End Property

        Public Property _codigoProyecto() As String
            Get
                Return Me.codigoProyecto
            End Get
            Set(ByVal value As String)

                Me.codigoProyecto = value

            End Set
        End Property

        Public Property _FechaLote() As String
            Get
                Return Me.fechaLote
            End Get
            Set(ByVal value As String)

                Me.fechaLote = value

            End Set
        End Property

        Public Property _activo() As Integer
            Get
                Return Me.activo
            End Get
            Set(ByVal value As Integer)
                Me.activo = value
            End Set
        End Property

        Public Property _asignado() As Integer
            Get
                Return Me.asignado
            End Get
            Set(ByVal value As Integer)
                Me.asignado = value
            End Set
        End Property

        Public Property _TotalImagenes() As Integer
            Get
                Return Me.totImagenes
            End Get
            Set(ByVal value As Integer)
                Me.totImagenes = value
            End Set
        End Property

        Public Property _preparado() As Integer
            Get
                Return Me.preparado
            End Get
            Set(ByVal value As Integer)
                Me.preparado = value
            End Set
        End Property

        Public Property _digitalizado() As Integer
            Get
                Return Me.digitalizado
            End Get
            Set(ByVal value As Integer)
                Me.digitalizado = value
            End Set
        End Property

        Public Property _importado() As Integer
            Get
                Return Me.importado
            End Get
            Set(ByVal value As Integer)
                Me.importado = value
            End Set
        End Property

        Public Property _verificado() As Integer
            Get
                Return Me.verificado
            End Get
            Set(ByVal value As Integer)
                Me.verificado = value
            End Set
        End Property

        Public Property _corregido() As Integer
            Get
                Return Me.corregido
            End Get
            Set(ByVal value As Integer)
                Me.corregido = value
            End Set
        End Property

        Public Property _traspasado() As Integer
            Get
                Return Me.traspasado
            End Get
            Set(ByVal value As Integer)
                Me.traspasado = value
            End Set
        End Property

        Public Property _finalizado() As Integer
            Get
                Return Me.finalizado
            End Get
            Set(ByVal value As Integer)
                Me.finalizado = value
            End Set
        End Property

        Public Property _atributado() As Integer
            Get
                Return Me.atributado
            End Get
            Set(ByVal value As Integer)
                Me.atributado = value
            End Set
        End Property

        Public Property _corregidoatributado() As Integer
            Get
                Return Me.corregidoatributado
            End Get
            Set(ByVal value As Integer)
                Me.corregidoatributado = value
            End Set
        End Property

        Public Property _tipoLote() As String
            Get
                Return Me.tipoLote
            End Get
            Set(ByVal value As String)
                Me.tipoLote = value
            End Set
        End Property

        Public Property _grises() As Integer
            Get
                Return Me.grises
            End Get
            Set(ByVal value As Integer)
                Me.grises = value
            End Set
        End Property

        Public Property _nomContenedor() As String
            Get
                Return Me.nomContenedor
            End Get
            Set(ByVal value As String)
                Me.nomContenedor = value
            End Set
        End Property

        Public Property _rutaLote() As String
            Get
                Return Me.rutaLote
            End Get
            Set(ByVal value As String)
                Me.rutaLote = value
            End Set
        End Property

        Public Property _rutaLoteLocal() As String
            Get
                Return Me.rutaLoteLocal
            End Get
            Set(ByVal value As String)
                Me.rutaLoteLocal = value
            End Set

        End Property
        Public Property _ListaDocumentos() As List(Of clsDocumentoE)
            Get
                Return Me.ColeccionDocumentos
            End Get
            Set(ByVal value As List(Of clsDocumentoE))

                Me.ColeccionDocumentos = value
            End Set
        End Property

#End Region

#Region "Funciones de clase"
        Public Function verificarIntegridad(ByVal CadenaConexionServidor As String) As Boolean

            For Each documento As DataRow In LibreriaCadenaProduccion.Datos.Produccion.clsAccesoDatosProduccion.ObtenerDatosParaVerificarIntegridadLote(Me.codigoProyecto, Me.idLote, CadenaConexionServidor).Rows

                Dim cadena As String = documento.Item("NomArchivoTIF").ToString()
                Dim indiceImagen As Integer = Val(Mid(cadena, 4, 5))

                If Not (documento.Item("id_lote").ToString() = documento.Item("pagina").ToString() = indiceImagen.ToString()) Then
                    Return False
                End If
            Next

            Return True

        End Function

        Private Function obtenerDatosLote(ByVal idLote As Integer, ByVal proyecto As String) As clsLoteE
            Dim lsSql As String = "SELECT * FROM LOTES WHERE idProyecto='" & proyecto & "' AND idLote=" & idLote
            Dim dt As DataTable
            Dim resultado As New clsLoteE

            Try
                dt = consulta.ejecutarSQLDirectaTable(lsSql, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto)
                If dt.Rows.Count > 0 Then
                    Me.idLote = idLote
                    Me.codigoProyecto = proyecto
                    Me.fechaLote = dt.Rows(0).Item("FechaLote").ToString.Trim
                    If IsDBNull(dt.Rows(0).Item("Activo")) Then
                        Me.activo = 0
                    Else
                        Me.activo = dt.Rows(0).Item("Activo")
                    End If
                    If IsDBNull(dt.Rows(0).Item("Asignado")) Then
                        Me.asignado = 0
                    Else
                        Me.asignado = dt.Rows(0).Item("Asignado")
                    End If
                    If IsDBNull(dt.Rows(0).Item("TotalImg")) Then
                        Me.totImagenes = 0
                    Else
                        Me.totImagenes = dt.Rows(0).Item("TotalImg")
                    End If
                    If IsDBNull(dt.Rows(0).Item("Preparado")) Then
                        Me.preparado = 0
                    Else
                        Me.preparado = dt.Rows(0).Item("Preparado")
                    End If
                    If IsDBNull(dt.Rows(0).Item("Digitalizado")) Then
                        Me.digitalizado = 0
                    Else
                        Me.digitalizado = dt.Rows(0).Item("Digitalizado")
                    End If
                    If IsDBNull(dt.Rows(0).Item("Importado")) Then
                        Me.importado = 0
                    Else
                        Me.importado = dt.Rows(0).Item("Importado")
                    End If
                    If IsDBNull(dt.Rows(0).Item("Verificado")) Then
                        Me.verificado = 0
                    Else
                        Me.verificado = dt.Rows(0).Item("Verificado")
                    End If
                    If IsDBNull(dt.Rows(0).Item("Corregido")) Then
                        Me.corregido = 0
                    Else
                        Me.corregido = dt.Rows(0).Item("Corregido")
                    End If
                    If IsDBNull(dt.Rows(0).Item("Traspasado")) Then
                        Me.traspasado = 0
                    Else
                        Me.traspasado = dt.Rows(0).Item("Traspasado")
                    End If
                    If IsDBNull(dt.Rows(0).Item("Finalizado")) Then
                        Me.finalizado = 0
                    Else
                        Me.finalizado = dt.Rows(0).Item("Finalizado")
                    End If
                    If IsDBNull(dt.Rows(0).Item("Atributado")) Then
                        Me.atributado = 0
                    Else
                        Me.atributado = dt.Rows(0).Item("Atributado")
                    End If
                    If IsDBNull(dt.Rows(0).Item("CorregidoAtributado")) Then
                        Me.corregidoatributado = 0
                    Else
                        Me.corregidoatributado = dt.Rows(0).Item("CorregidoAtributado")
                    End If
                    If IsDBNull(dt.Rows(0).Item("DAT")) Then
                        Me.tipoLote = ""
                    Else
                        Me.tipoLote = dt.Rows(0).Item("DAT").ToString.Trim
                    End If
                    If IsDBNull(dt.Rows(0).Item("Grises")) Then
                        Me.grises = 0
                    Else
                        Me.grises = dt.Rows(0).Item("Grises")
                    End If
                    If IsDBNull(dt.Rows(0).Item("nomcontenedor")) Then
                        Me.nomContenedor = ""
                    Else
                        Me.nomContenedor = dt.Rows(0).Item("nomcontenedor").ToString.Trim
                    End If

                    Me.rutaLote = ObtenerRutaImagenes(frmContenedorMDI.oProyecto._rutaImagenes, Me.codigoProyecto, Me.idLote)
                    Me.rutaLoteLocal = ObtenerRutaImagenesLocal(Me.codigoProyecto, Me.idLote)

                End If

                dt.Clear()

            Catch ex As Exception
                resultado = Nothing
                Throw ex

            Finally
                obtenerDatosLote = resultado

            End Try

        End Function

        Private Sub obtenerDocumentosLote(ByVal idLote As Integer)
            Dim lsSql As String = "SELECT * FROM DOCUMENTOS WHERE idLote=" & idLote & " ORDER BY Pagina"
            Dim dt As DataTable
            Dim documento As clsDocumentoE

            Try
                dt = consulta.ejecutarSQLDirectaTable(lsSql, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto)
                If dt.Rows.Count > 0 Then
                    For Each fila As DataRow In dt.Rows
                        documento = New clsDocumentoE(fila.Item("idDocumento"))

                        Me._ListaDocumentos.Add(documento)

                    Next
                End If

            Catch ex As Exception
                Throw ex

            End Try
        End Sub

        Public Function obtenerLoteado(ByVal idLote As Integer) As List(Of clsLoteadoE)
            Dim lsSql As String = "SELECT * FROM LOTEADO WHERE numLote=" & idLote & " ORDER BY NHC"
            Dim dt As DataTable
            Dim loteado As clsLoteadoE
            Dim resultado As New List(Of clsLoteadoE)

            Try
                dt = consulta.ejecutarSQLDirectaTable(lsSql, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto)
                If dt.Rows.Count > 0 Then
                    For Each fila As DataRow In dt.Rows
                        loteado = New clsLoteadoE()

                        If IsDBNull(fila.Item("Proyecto")) Then loteado._codigoProyecto = Nothing Else loteado._codigoProyecto = fila.Item("Proyecto").ToString.Trim
                        If IsDBNull(fila.Item("NHC")) Then loteado._NumeroHistoria = Nothing Else loteado._NumeroHistoria = fila.Item("NHC")
                        If IsDBNull(fila.Item("NumCaja")) Then loteado._Caja = Nothing Else loteado._Caja = fila.Item("NumCaja")
                        If IsDBNull(fila.Item("NumLote")) Then loteado._Lote = Nothing Else loteado._Lote = fila.Item("NumLote")
                        If IsDBNull(fila.Item("FechaLoteado")) Then loteado._FechaLoteado = Nothing Else loteado._FechaLoteado = fila.Item("FechaLoteado").ToString.Trim
                        If IsDBNull(fila.Item("UsuarioLoteado")) Then loteado._UsuarioLoteado = Nothing Else loteado._UsuarioLoteado = fila.Item("UsuarioLoteado").ToString.Trim
                        If IsDBNull(fila.Item("SinDocumentos")) Then loteado._sinDocumentos = Nothing Else loteado._sinDocumentos = fila.Item("SinDocumentos")
                        If IsDBNull(fila.Item("Incidencia")) Then loteado._incidencia = Nothing Else loteado._incidencia = fila.Item("Incidencia")
                        If IsDBNull(fila.Item("Coleccion")) Then loteado._coleccion = Nothing Else loteado._coleccion = fila.Item("Coleccion")

                        resultado.Add(loteado)

                    Next
                End If

            Catch ex As Exception
                Throw ex

            Finally
                obtenerLoteado = resultado

            End Try
        End Function

        'Public Function ObtenerDocumentoColec(ByVal historia As Integer, ByVal numicu As Integer) As clsDocumento
        ''Public Function ObtenerDocumentoColec(ByVal pagina As Integer) As ClsDocumento
        ''    'Dim documento As New clsDocumento(historia, numicu)
        ''    Dim documento As clsDocumento = Nothing
        ''    Dim encontrado As Boolean = False
        ''    Dim i As Integer = 1

        ''    While i <= Me.ColeccionDocumentos.Count And encontrado = False

        ''        'documento = New ClsDocumento

        ''        documento = Me.ColeccionDocumentos.Item(i)
        ''        'If documento._historia = historia And documento._numicu = numicu Then
        ''        If documento._pagina = pagina + 1 Then
        ''            encontrado = True
        ''        End If
        ''        i = i + 1
        ''    End While

        ''    If pagina = Me.ColeccionDocumentos.Count Then

        ''        documento = Me.ColeccionDocumentos.Item(Me.ColeccionDocumentos.Count)
        ''        encontrado = True
        ''    End If

        ''    If encontrado = False Then
        ''        documento = Nothing
        ''    End If


        ''    Return documento
        ''End Function

        Public Shared Sub CargarImagenesLoteListview(ByVal rutaImagenesLote As String, ByRef lstImagenes As ListView, ByRef imagelist1 As ImageList)
            Dim metadatos As FileInfo
            Dim imagen As Image

            lstImagenes.Items.Clear()
            lstImagenes.Refresh()


            For Each archivo As String In Directory.GetFiles(rutaImagenesLote)
                metadatos = New FileInfo(archivo)

                'visualizar la imagen
                If metadatos.Extension.ToLower = ".tif" Then
                    imagen = Image.FromFile(metadatos.FullName)
                    Application.DoEvents()
                    imagelist1.Images.Add(metadatos.Name, imagen)
                    Application.DoEvents()
                    lstImagenes.Items.Add(metadatos.Name, metadatos.Name)
                    Application.DoEvents()
                End If

            Next

        End Sub

#End Region

#Region "Metodos Shared"


        '''''' <summary>
        '''''' Obtencion de los documentos de un lote
        '''''' </summary>
        '''''' <param name="proyecto"></param>
        '''''' <param name="fecha"></param>
        '''''' <remarks></remarks>
        ' ''Public Shared Function obtenerDocumentos(ByVal cadenaConexion As String, ByVal proyecto As Integer, ByVal codigoLote As Integer, Optional ByVal fecha As String = "", Optional ByVal rutacompleta As Boolean = True, Optional ByVal condicion_adicional As String = "", Optional ByVal select_condicional As String = "", Optional ByVal orderby_condicional As String = "") As DataTable

        ' ''    'Obtenemos la ruta de las imagenes con las que vamos a tratar
        ' ''    Dim ruta As String = ""
        ' ''    Dim sqlWHERE As String = ""

        ' ''    If rutacompleta Then

        ' ''        ruta = ObtenerRutaImagenes(cadenaConexion, proyecto, codigoLote)

        ' ''        'En el caso que no exista la ultima barra, se añade
        ' ''        If ruta.Length > 0 Then
        ' ''            If ruta.Chars(ruta.Length - 1) <> "\" Then ruta &= "\"
        ' ''        Else
        ' ''            MsgBox("La ruta de imagenes se encuentra vacia", MsgBoxStyle.Critical)
        ' ''        End If

        ' ''    End If

        ' ''    If fecha <> "" Then
        ' ''        If IsDate(fecha) Then
        ' ''            Dim tmpFecha As Date = fecha
        ' ''            sqlWHERE &= " AND fechaLote='" & Format(tmpFecha, "dd/MM/yyyy").ToString & "'"
        ' ''        Else
        ' ''            MsgBox("La fecha seleccionada no es correcta", MsgBoxStyle.Critical, "Incidencia en aplicacion")
        ' ''        End If

        ' ''    End If

        ' ''    If rutacompleta Then
        ' ''        If Not Directory.Exists(ruta) Then
        ' ''            MsgBox("La carpeta correspondiente a las imagenes del lote no existe", MsgBoxStyle.Critical, "Incidencia de aplicacion")
        ' ''            Return Nothing
        ' ''        End If
        ' ''    End If

        ' ''    sqlWHERE &= condicion_adicional

        ' ''    'En el caso de que exista , procedemos a listar los ficheros
        ' ''    Dim sql As String = "SELECT '" & ruta & "'+nomArchivoTIF as documentos" & select_condicional & " from documentos WHERE proyecto = '" & proyecto & "' and codigolote='" & codigoLote & "'" & sqlWHERE
        ' ''    Dim ds As DataSet = consulta.ejecutarSQLDirecta(sql, cadenaConexion)
        ' ''    If ds.Tables.Count > 0 Then
        ' ''        Return ds.Tables(0)
        ' ''    Else
        ' ''        MsgBox("La consulta de ficheros no devolvio registros", MsgBoxStyle.Critical, "Incidencia de aplicacion")
        ' ''    End If

        ' ''    ' documentos SET corregida=0 WHERE proyecto = '9999' and codigolote=8


        ' ''    Return Nothing

        ' ''End Function

        Public Shared Function ObtenerRutaImagenes(ByVal ruta As String, ByVal proyecto As String, ByVal codigoLote As String) As String
            Try
                Return ruta & Path.DirectorySeparatorChar & Format(Val(proyecto), "0000") & "\DIGI\" & Format(Val(proyecto), "0000") & Format(Val(codigoLote), "00000") & "\Imagen\" & codigoLote
            Catch ex As Exception
                Return ""
            End Try
        End Function

        Public Shared Function ObtenerRaizRutaImagen(ByVal proyecto As String, ByVal cadenaConexion As String) As String

            Dim strSQL As String = "Select conf.rutaImagenes, pro.abreviatura from ConfiguracionProyectos as conf, proyectos as pro where pro.Proyecto='" & proyecto & "'" _
            & " AND pro.Proyecto = conf.proyecto"

            Dim rutaImagenes = ""
            Dim dt As DataTable = consulta.ejecutarSQLDirecta(strSQL, cadenaConexion).Tables(0)

            Try
                If dt.Rows.Count > 0 Then
                    Return dt.Rows(0).Item("rutaImagenes").ToString & Path.DirectorySeparatorChar & dt.Rows(0).Item("abreviatura").ToString & "\DIGI\" & dt.Rows(0).Item("abreviatura").ToString
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString)
            End Try

            Return ""

        End Function

        Public Shared Function ObtenerRutaImagenesLocal(ByVal proyecto As String, ByVal codigoLote As String) As String
            Try
                Return My.Settings.DIGI_rutaLocalImagenes & Path.DirectorySeparatorChar & Format(Val(proyecto), "0000") & "\DIGI\" & Format(Val(proyecto), "0000") & Format(Val(codigoLote), "00000") & "\Imagen\" & codigoLote

            Catch ex As Exception
                Return ""
            End Try
        End Function

#End Region


    End Class

End Namespace