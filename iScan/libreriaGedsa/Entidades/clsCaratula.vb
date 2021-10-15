Public Class clsCaratula


    Sub New()

    End Sub

    'BORRARRRRR

    ''' <summary>
    ''' Generacion dinámica de una carátula, en el caso de que algun dato no tenga valor, no se muestra
    ''' si deseamos poner el campo en question deberemos rellenar un espacio en blanco
    ''' </summary>
    ''' <param name="cadenaConexion">Cadena de conexion, para realizar la consultas</param>
    ''' <param name="hospital_codigo">Codigo identificador del hospital, tabla: hospitales</param>
    ''' <param name="nombre_paciente">Codigo identificador del paciente en la tabla "fip"</param>
    ''' <param name="nhc">Numero historial clinicp</param>
    ''' <param name="episodio">Episodio para rellenar</param>
    ''' <param name="proyecto">Proyecto, necesario para mostrar codigo de barras, tabla configuracion</param>
    ''' <returns>Se devuelve un objeto IMAGE, con la carátula generada</returns>
    ''' <remarks></remarks>
    Public Shared Function generarCaratula(ByVal cadenaConexion As String, ByVal hospital_codigo As Integer, ByVal nombre_paciente As String, ByVal nhc As String, ByVal episodio As String, ByVal proyecto As String) As Image

        'Variables de cursor
        Dim n As Integer = 0
        Dim n_sumatorio As Integer = 100

        'Variables de configuracion de margenes
        Dim margen_izquierdo As Integer = 70
        Dim margen_izquierdo_resultados As Integer = 200
        Dim espacio_ultimos_datos As Integer = 43

        'Asignacion de los valores, se han de pasar por referencia
        Dim fecha_alta As String = "", fecha_alta_mostrar As Boolean = False 'Indica si se muestra el dato
        Dim fecha_ingreso As String = "", fecha_ingreso_mostrar As Boolean = False
        Dim hospital As String = "", hospital_mostrar As Boolean = False
        Dim servicio As String = "", servicio_mostrar As Boolean = False

        Dim datosEpisodios As Boolean = True

        Dim dt As DataTable = Datos.GeneralSQL.clsAccesoDatosSQL.ejecutarSQLDirecta("SELECT Descripcion, isnull((SELECT TOP 1 ISNULL(CONVERT(Varchar,FechaInicio,103),' ')+'#'+ISNULL(CONVERT(VARCHAR,fechaTermino),' ')+'#'+ISNULL(CONVERT(VARCHAR,Servicio),' ') Servicio from episodios WHERE hospital ='" & hospital_codigo & "' AND nhc='" & nhc & "' AND numIcu='" & servicio & "'),' # # ') as servicio from hospitales where codigo ='" & hospital_codigo & "'", cadenaConexion).Tables(0)
        If dt IsNot Nothing Then
            If dt.Rows.Count > 0 Then
                'Devolver
                hospital = dt.Rows(0).Item("descripcion").ToString
                Dim s() As String = dt.Rows(0).Item("servicio").ToString.Split("#")
                servicio = s(2)
                fecha_alta = s(1)
                fecha_ingreso = s(0)
            End If

        End If

        'buscamos de la tabla configuracion el barcode:
        Dim dt2 As DataTable = Datos.GeneralSQL.clsAccesoDatosSQL.ejecutarSQLDirecta("SELECT * from configuracionbarcode where proyecto = '" & proyecto & "'", cadenaConexion).Tables(0)
        If dt IsNot Nothing Then
            If dt.Rows.Count > 0 Then
                'Devolver
                hospital = dt.Rows(0).Item("descripcion").ToString
                Dim s() As String = dt.Rows(0).Item("servicio").ToString.Split("#")
                servicio = s(2)
                fecha_alta = s(1)
                fecha_ingreso = s(0)
            End If

        End If

        'Genero el codigo de Barras con los que obtengo de la base de datos
        Dim codigo_barras As String = "09091241"

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
            If hospital <> "" Then g.DrawString(hospital, fnt_boldsubrayada, Brushes.Black, b.Width / 2, n, p_fuente_normal)
            n += n_sumatorio

            If nhc <> "" Then g.DrawString("NºHC:", fnt_normal, Brushes.Black, b.Width / 2, n, p_fuente_normal)
            n += n_sumatorio
            If nhc <> "" Then g.DrawString(nhc, fnt_bold, Brushes.Black, b.Width / 2, n, p_fuente_normal)
            n += n_sumatorio

            If codigo_barras <> "" Then g.DrawString(codigo_barras, fnt_codigoBarras, Brushes.Black, b.Width / 2, n, p_fuente_normal)
            n += n_sumatorio
            If nombre_paciente <> "" Then g.DrawString(nombre_paciente, fnt_normal, Brushes.Black, b.Width / 2, n, p_fuente_normal)

            n += (2 * n_sumatorio)

            'En el caso de que se muestren los datos de episodio

            If datosEpisodios Then

                'Datos
                Dim lapiz As Pen = New Pen(Color.Black, 1)
                g.DrawRectangle(lapiz, New Rectangle(55, n, 650, 270))
                n += 7
                g.DrawString("DATOS EPISODIO:", fnt_boldsubrayada, Brushes.Black, margen_izquierdo, n)

                n += espacio_ultimos_datos

                If episodio Then
                    g.DrawString("EPISODIO :", fnt_abajo, Brushes.Black, margen_izquierdo, n)
                    g.DrawString(episodio, fnt_abajo, Brushes.Black, margen_izquierdo + 160, n)
                End If

                n += espacio_ultimos_datos

                If servicio <> "" Then
                    g.DrawString("SERVICIO : ", fnt_abajo, Brushes.Black, margen_izquierdo, n)
                    g.DrawString(servicio, fnt_abajo, Brushes.Black, margen_izquierdo + 160, n)
                End If

                n += espacio_ultimos_datos

                If fecha_ingreso <> "" Then
                    g.DrawString("FECHA INGRESO : ", fnt_abajo, Brushes.Black, margen_izquierdo, n)
                    g.DrawString(fecha_ingreso, fnt_abajo, Brushes.Black, margen_izquierdo + 240, n)
                End If

                n += espacio_ultimos_datos

                If fecha_alta <> "" Then
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
