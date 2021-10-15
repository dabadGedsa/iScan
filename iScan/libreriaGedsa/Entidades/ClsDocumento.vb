
Namespace Entidades

    Public Class ClsDocumento

#Region "Variables privadas"

        Private historia As String
        Private numicu As String
        Private hospital As String
        Private id As Integer
        Private pagina As Integer
        Private idTipoDocumento As Integer
        Private nomArchivo As String
        Private proyecto As String

        Private fechaInicio As String
        Private fechaFin As String
        Private servicio As String
        Private tipoEpisodio As String
        Private rutaInicial As String
        Private codigoLote As String

        Private inicioDevice As Integer
        Private sizeDevice As Integer
        Private indizado As Integer
        Private tipoDocumento As ClsTipoDocumento

        Private cargado As Boolean
        Private rutaImagenTemporal As String
        Private imagen As System.IO.Stream

#End Region

#Region "Constructores y destructores"

        Public Sub New(ByVal historia As String, ByVal numicu As String, ByVal hospital As String)
            Me.historia = historia
            Me.numicu = numicu
            Me.hospital = hospital
        End Sub

        Public Sub New(ByVal historia As String, ByVal proyecto As String, _
                       ByVal id As Integer, ByVal pagina As Integer, ByVal tipoDocumento As Integer, _
                       ByVal nomArchivo As String)

            Me.historia = historia
            Me.hospital = hospital
            Me.id = id
            Me.pagina = pagina
            Me.idTipoDocumento = tipoDocumento
            Me.nomArchivo = nomArchivo

        End Sub

        Public Sub New(ByVal historia As String, ByVal numicu As String, ByVal id As Integer, _
            ByVal nomArchivo As String, ByVal inicioDevice As Integer, ByVal SizeDevize As Integer, _
            ByVal indizado As Integer, ByVal tipoDocumento As Integer, ByVal pagina As Integer)

            Me.historia = historia
            Me.numicu = numicu
            Me.id = id

            Me.nomArchivo = nomArchivo
            Me.inicioDevice = inicioDevice
            Me.sizeDevice = SizeDevize

            Me.indizado = indizado
            Me.idTipoDocumento = tipoDocumento
            Me.pagina = pagina

        End Sub

        Public Sub New(ByVal historia As String, ByVal numicu As String, ByVal hospital As String, _
                       ByVal id As Integer, ByVal pagina As Integer, ByVal tipoDocumento As Integer, _
                       ByVal nomArchivo As String)

            Me.historia = historia
            Me.numicu = numicu
            Me.hospital = hospital
            Me.id = id
            Me.pagina = pagina
            Me.idTipoDocumento = tipoDocumento
            Me.nomArchivo = nomArchivo

        End Sub

        Public Sub New(ByVal historia As String, ByVal proyecto As String, _
                       ByVal id As Integer, ByVal pagina As Integer, _
                       ByVal nomArchivo As String, ByVal codigolote As String)

            Me.historia = historia
            Me.proyecto = proyecto
            Me.id = id
            Me.pagina = pagina
            Me.nomArchivo = nomArchivo
            Me.codigoLote = codigolote

        End Sub

#End Region

#Region "Propiedades"

        Public Property _Proyecto() As String
            Get
                Return Me.proyecto
            End Get
            Set(ByVal value As String)
                Me.proyecto = value
            End Set
        End Property

        Public Property _Id() As String
            Get
                Return Me.id
            End Get
            Set(ByVal value As String)
                Me.id = value
            End Set
        End Property

        Public Property _NombreImagen() As String
            Get
                Return Me.nomArchivo
            End Get
            Set(ByVal value As String)
                Me.nomArchivo = value
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

        Public Property _historia() As String
            Get
                Return Me.historia
            End Get
            Set(ByVal value As String)
                Me.historia = value
            End Set
        End Property

        Public Property _idTipoDocumento() As Integer
            Get
                Return Me.idTipoDocumento
            End Get
            Set(ByVal value As Integer)
                Me.idTipoDocumento = value
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

        Public Property _servicio() As String
            Get
                Return Me.servicio
            End Get
            Set(ByVal value As String)
                Me.servicio = value
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

        Public Property _rutaInicial() As String
            Get
                Return Me.rutaInicial
            End Get
            Set(ByVal value As String)
                Me.rutaInicial = value
            End Set
        End Property

        Public Property _codigoLote() As String
            Get
                Return Me.codigoLote
            End Get
            Set(ByVal value As String)
                Me.codigoLote = value
            End Set
        End Property

        Public Property _tipoDocumento() As ClsTipoDocumento
            Get
                Return Me.tipoDocumento
            End Get
            Set(ByVal value As ClsTipoDocumento)
                Me.tipoDocumento = value
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

        Public Property _inicioDevice() As Integer
            Get
                Return inicioDevice
            End Get
            Set(ByVal value As Integer)
                inicioDevice = value
            End Set
        End Property

        Public Property _sizeDevice() As Integer
            Get
                Return sizeDevice
            End Get
            Set(ByVal value As Integer)
                sizeDevice = value
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

        Public Property _rutaImagenTemporal() As String
            Get
                Return Me.rutaImagenTemporal
            End Get
            Set(ByVal value As String)
                Me.rutaImagenTemporal = value
            End Set
        End Property

        Public Property _cargado() As Boolean
            Get
                Return Me.cargado
            End Get
            Set(ByVal value As Boolean)
                Me.cargado = value
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

#End Region

        ''' <summary>
        ''' Generacion dinámica de una carátula, en el caso de que algun dato no tenga valor, no se muestra
        ''' si deseamos poner el campo en question deberemos rellenar un espacio en blanco
        ''' 
        ''' ESTO SE PODRIA METER EN UNA CLASE PARA UN MEJOR TRATAMIENTO, CLSCARATULA
        ''' </summary>
        ''' <param name="cadenaConexion">Cadena de conexion, para realizar la consultas</param>
        ''' <param name="hospital_codigo">Codigo identificador del hospital, tabla: hospitales</param>
        ''' <param name="nombre_paciente">Codigo identificador del paciente en la tabla "fip"</param>
        ''' <param name="nhc">Numero historial clinicp</param>
        ''' <param name="episodio">Episodio para rellenar</param>
        ''' <param name="proyecto">Proyecto, necesario para mostrar codigo de barras, tabla configuracion</param>
        ''' <returns>Se devuelve un objeto IMAGE, con la carátula generada</returns>
        ''' <remarks></remarks>

        Public Shared Function generarCaratula(ByVal nombre_paciente As String, ByVal nhc As String, ByVal episodio As String, ByVal cadenaconexion As String) As Image

            'Variables de cursor
            Dim n As Integer = 0
            Dim n_sumatorio As Integer = 100

            'Variables de configuracion de margenes
            Dim margen_izquierdo As Integer = 70
            Dim margen_izquierdo_resultados As Integer = 200
            Dim espacio_ultimos_datos As Integer = 43

            'Variables que se van a mostrar en la carátula, se mostrarán únicamente 
            'Si están en la tabla.campo :  configuracionCaratulas.datosMostrados
            'Los identificadores se encuentran en la tabla: configuracionTipos
            'Por defecto no se muestra ninguna y segun aparecen ese campo se cambia a true
            'el valor booleano del campo_mostrar a true.

            Dim fecha_alta As String = "", fecha_alta_mostrar As Boolean = True 'Indica si se muestra el dato
            Dim fecha_ingreso As String = "", fecha_ingreso_mostrar As Boolean = True
            Dim hospital As String = "", hospital_mostrar As Boolean = True
            Dim servicio As String = "", servicio_mostrar As Boolean = True



            Dim nhc_mostrar As Boolean = True
            Dim codigo_barras As String = "", codigo_barras_mostrar As Boolean = False
            Dim nombre_paciente_mostrar As Boolean = True
            Dim episodio_mostrar As Boolean = True

            Dim datosEpisodios As Boolean = True



            'Se cargan los datos correspondientes al servicio, fecha_alta e ingreso en la tabla episodio
            Dim dtDatosEpisodios As DataTable = Datos.GeneralSQL.clsAccesoDatosSQL.ejecutarSQLDirecta("SELECT Abreviaturaservicio,fechaInicio,fechaTermino FROM episodios WHERE nhc='" & nhc & "' AND numIcu='" & episodio & "'", cadenaconexion).Tables(0)
            If dtDatosEpisodios IsNot Nothing Then
                If dtDatosEpisodios.Rows.Count > 0 Then
                    'Devolver

                    servicio = dtDatosEpisodios.Rows(0).Item("Abreviaturaservicio").ToString
                    fecha_alta = IIf(IsDBNull(dtDatosEpisodios.Rows(0).Item("fechaTermino")), "0", IsDBNull(dtDatosEpisodios.Rows(0).Item("fechaTermino")))
                    fecha_ingreso = IIf(IsDBNull(dtDatosEpisodios.Rows(0).Item("fechaInicio")), "0", IsDBNull(dtDatosEpisodios.Rows(0).Item("fechaInicio")))
                End If

            End If

            Dim b As Image = Nothing
            Try
                b = New Bitmap(775, 1099)
                Dim g As Graphics = Graphics.FromImage(b)

                Dim fnt_normal As New Font("Microsoft Sans Serif", 35, FontStyle.Regular, GraphicsUnit.Pixel)
                Dim fnt_boldsubrayada As New Font("Microsoft Sans Serif", 35, FontStyle.Bold + FontStyle.Underline, GraphicsUnit.Pixel)
                Dim fnt_bold As New Font("Microsoft Sans Serif", 35, FontStyle.Bold, GraphicsUnit.Pixel)
                Dim fnt_abajo As New Font("Microsoft Sans Serif", 25, FontStyle.Regular, GraphicsUnit.Pixel)

                Dim fnt_codigoBarras As New Font("IDAutomationHC39M", 18, FontStyle.Regular, GraphicsUnit.Pixel)

                g.Clear(Color.White)
                Dim p_fuente_normal As New System.Drawing.StringFormat

                p_fuente_normal.Alignment = StringAlignment.Center
                p_fuente_normal.LineAlignment = StringAlignment.Center

                n += n_sumatorio
                If hospital_mostrar Then g.DrawString(hospital, fnt_boldsubrayada, Brushes.Black, b.Width / 2, n, p_fuente_normal)
                n += n_sumatorio

                If nhc_mostrar Then g.DrawString("NºHC:", fnt_normal, Brushes.Black, b.Width / 2, n, p_fuente_normal)
                n += n_sumatorio
                If nhc_mostrar Then g.DrawString(nhc, fnt_bold, Brushes.Black, b.Width / 2, n, p_fuente_normal)
                n += n_sumatorio

                If codigo_barras_mostrar Then g.DrawString(codigo_barras, fnt_codigoBarras, Brushes.Black, b.Width / 2, n, p_fuente_normal)
                n += n_sumatorio
                If nombre_paciente_mostrar Then g.DrawString(nombre_paciente, fnt_normal, Brushes.Black, b.Width / 2, n, p_fuente_normal)

                n += (2 * n_sumatorio)

                'En el caso de que se muestren los datos de episodio

                If datosEpisodios Then

                    'Datos
                    Dim lapiz As Pen = New Pen(Color.Black, 1)
                    g.DrawRectangle(lapiz, New Rectangle(55, n, 650, 270))
                    n += 7
                    g.DrawString("DATOS EPISODIO:", fnt_boldsubrayada, Brushes.Black, margen_izquierdo, n)

                    n += espacio_ultimos_datos

                    If episodio_mostrar Then
                        g.DrawString("EPISODIO :", fnt_abajo, Brushes.Black, margen_izquierdo, n)
                        g.DrawString(episodio, fnt_abajo, Brushes.Black, margen_izquierdo + 160, n)
                    End If

                    n += espacio_ultimos_datos

                    If servicio_mostrar Then
                        g.DrawString("SERVICIO : ", fnt_abajo, Brushes.Black, margen_izquierdo, n)
                        g.DrawString(servicio, fnt_abajo, Brushes.Black, margen_izquierdo + 160, n)
                    End If

                    n += espacio_ultimos_datos

                    If fecha_ingreso_mostrar Then
                        g.DrawString("FECHA INGRESO : ", fnt_abajo, Brushes.Black, margen_izquierdo, n)
                        g.DrawString(fecha_ingreso, fnt_abajo, Brushes.Black, margen_izquierdo + 240, n)
                    End If

                    n += espacio_ultimos_datos

                    If fecha_alta_mostrar Then
                        g.DrawString("FECHA ALTA :", fnt_abajo, Brushes.Black, margen_izquierdo, n)
                        g.DrawString(fecha_alta, fnt_abajo, Brushes.Black, margen_izquierdo + 200, n)
                    End If

                End If

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Incidencia de aplicacion")
                b = Nothing
            End Try
            Return b
        End Function

    End Class


End Namespace
