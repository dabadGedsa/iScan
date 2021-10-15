Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports datosSQL = LibreriaCadenaProduccion.Datos.GeneralSQL.clsAccesoDatosSQL
Imports GenCode128
Imports accesodatos = LibreriaCadenaProduccion.Datos.GeneralSQL.clsAccesoDatosSQL
Imports System.IO


Public Class frmCrearCaratulas

    'estrucutura utilizada para crear la consulta de busqueda 
    Public Structure elementoBusqueda
        Public Nombre As String
        Public valor As String
        Public valor2 As String
        Public texto As Integer
        Public Fecha As Integer
        'rangofecha sera 0 no 1 es rango 2 anterior 3 posterior
        Public RangoFecha As Integer
    End Structure


#Region "Definicion de clases internas"



    'clase para cargar los datos de indizacion con los datos de la base de datos de Plana
    Private Class EpisodioPlana

        Private episodio As String
        Private servicio As String
        Private fechaTermino As String 'la longitud  de la fecha es de 10 
        Private fechaInicio As String

        Public Sub New(ByVal fechaInicio As String, ByVal FechaTermino As String, ByVal episodio As Integer, ByVal servicio As String)

            Me.episodio = episodio
            Me.servicio = servicio
            Me.fechaInicio = fechaInicio
            Me.fechaTermino = FechaTermino

        End Sub


        Public Sub New(ByVal fechaInicio As String, ByVal FechaTermino As String, ByVal episodio As Integer)

            Me.episodio = episodio
            Me.fechaInicio = fechaInicio
            Me.fechaTermino = FechaTermino

        End Sub

        Public Overrides Function ToString() As String

            Return Me.episodio & " - " & fechaInicio & " " & fechaTermino
        End Function


        Public Property _episodio() As String
            Get
                Return Me.episodio
            End Get
            Set(ByVal value As String)
                Me.episodio = value
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


        Public Property _fechaTermino() As String
            Get
                Return Me.fechaTermino
            End Get
            Set(ByVal value As String)
                Me.fechaTermino = value
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

    End Class

#End Region


    'Dim cadenaconexioncaratulas As String = "Data Source=KRONIKO;Initial Catalog=produccionvgdiario;User ID=sa;password=cd2009g"
    Dim cadenaconexioncaratulas As String = "Data Source=KRONIKO;Initial Catalog=PRODUCCIONVGDIARIO ;User ID=sa;password=cd2009g"
    Dim proyecto As String = "6909"

    Dim fechaActual As Date


    Private Sub frmCrearCaratulas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        Dim strSQL As String
        Dim datos As DataTable

        Dim loteCaratula As LibreriaCadenaProduccion.Entidades.ClsLote
        Dim servicio As LibreriaCadenaProduccion.Entidades.ClsServicio

        strSQL = "SELECT idlote from trazabilidadlotes where fechainiciodigitalizado is null order by idlote "

        Try

        

            datos = accesodatos.ejecutarSQLDirectaTable(strSQL, cadenaconexioncaratulas)

            If datos.Rows.Count > 0 Then
                For Each registro As DataRow In datos.Rows

                    loteCaratula = New LibreriaCadenaProduccion.Entidades.ClsLote(CInt(registro.Item("idlote")), proyecto)

                    Me.cmbLote.Items.Add(loteCaratula)

                Next
            Else
                MessageBox.Show("No hay lotes libres para crear lotes, cree lotes y repita la operación.")
            End If

        Catch ex As Exception
            MessageBox.Show("Error al cargar los lotes libres para el proyecto.")
        End Try



        'inicializar el combo con los servicios 

        For Each registro As DataRow In accesodatos.ejecutarSQLDirectaTable("SELECT  [idServicio],[Abreviatura] FROM [produccionvgdiario].[dbo].[SERVICIOS] order by [Abreviatura]", cadenaconexioncaratulas).Rows


            servicio = New LibreriaCadenaProduccion.Entidades.ClsServicio(registro.Item("idServicio"), registro.Item("Abreviatura"))
            Me.cmdServicios.Items.Add(servicio)


        Next


        'Me.txtFechainicio.Text = Date.Now.ToShortDateString
        Me.txtfechaactual.Text = Date.Now.ToShortDateString
        actualizarconjuntoResultados()

    End Sub




#Region "CRYSTAL REPORT"

    Private Sub CrystalReportViewer2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer2.Load
        Dim reporte As New crpCaratula

        Me.CrystalReportViewer2.ReportSource = reporte
        Me.CrystalReportViewer2.Zoom(2)


    End Sub

    'crear las caratulas 
    Private Sub CtrlBotonMediano3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CtrlBotonMediano3.eClick
        Dim cr As New crpCaratula
        Dim informe As New dts_cabecera
        Dim tablaInforme As DataTable = informe.Tables(0)
        Dim titulo As String
        Dim subtitulo1 As String = ""
        Dim subtitulo2 As String = ""
        Dim codigoBarras As Image = Code128Rendering.MakeBarcodeImage("01033239200700651130", 3, True)
        Dim cadenaCodigoBarras As String = ""
        Dim memoria As String = ""
        Dim campo1memoria As String = "", campo2memoria As String = "", campo3memoria As String = "", campo4memoria As String = ""
        Dim primerapagina, ultimapagina As String
        Dim codigo_servicio As String
        Dim numeroRegistros As Integer
        Dim servicio As String

        Try


            Dim cabeceraCodigoBarras As String

            cabeceraCodigoBarras = accesodatos.ponerCaracterEnBlanco(accesodatos.ejecutarSQLDirectaDataRow("SELECT inicioBarcode FROM  configuracionBarcode where idproyecto = 6908", My.Settings.cadenaConexion).Item(0))
            If Me.DataGridView2.SelectedRows.Count = 0 Then
                MessageBox.Show("No ha seleccionado ningún registro para crear la caratula correspondiente ")
                Exit Sub
            Else

                numeroRegistros = Me.DataGridView2.SelectedRows.Count

                With Me.pgbCaratulas
                    .Maximum = numeroRegistros
                    .Value = 0
                    .Refresh()
                End With

            End If
            'If Me.DataGridView2.Rows.Count > 1 Then
            '    MessageBox.Show("Tiene que seleccionar solo un registro para generar la caratula, filtre más el resultado ")
            '    Exit Sub
            'End If



            'Creamos la caratual para cada uno de los datos de la consulta 
            'For Each registro As DataRow In CType(Me.DataGridView2.DataSource, DataTable).Rows
            For Each registro As DataGridViewRow In Me.DataGridView2.SelectedRows

                titulo = ""

                subtitulo1 = "CTR. ESP. VIRGEN DE GRACIA"

                'If cmbSubtitulo1.Text <> "" Then
                '    subtitulo1 = Trim(Me.txtSubtitulo1.Text & " " & accesodatos.ponerCaracterEnBlanco(registro.Item(cmbSubtitulo1.Text)))
                'End If

                'If cmbSubtitulo2.Text <> "" Then
                '    subtitulo2 = Trim(Me.txtSubtitulo2.Text & " " & accesodatos.ponerCaracterEnBlanco(registro.Item(cmbSubtitulo2.Text)))
                'End If

                'los campos estan en orden ascendente por lo que no tiene que haber problemas 
                ''para crear la cadena de los codigos de barras.
                'If CType(dgCodigoBarras.DataSource, DataTable).Rows.Count > 0 Then

                '    cadenaCodigoBarras = cabeceraCodigoBarras
                '    For Each campoBarcode As DataGridViewRow In dgCodigoBarras.Rows
                '        cadenaCodigoBarras = cadenaCodigoBarras & accesodatos.ponerCaracterEnBlanco(registro.Item(campoBarcode.Cells(3).Value)).ToString.PadLeft(campoBarcode.Cells("longitud").Value, "0")

                '    Next

                'End If

                'aqui es donde metemos los datos para hacer 



                If IsDBNull(registro.Cells("numhistoria")) Or registro.Cells("numhistoria").Value.ToString = "" Or IsDBNull(registro.Cells("servicio")) Or registro.Cells("servicio").ToString = "" Or IsDBNull(registro.Cells("FechaInicio")) Or registro.Cells("FechaInicio").ToString = "" Or IsDBNull(registro.Cells("Fechatermino")) Or registro.Cells("FechaTermino").ToString = "" Or IsDBNull(registro.Cells("NumIcu")) Or registro.Cells("NumIcu").ToString = "" Then

                    MessageBox.Show("No se puede crear una caratula para este registro, para poder crear la caratula tienen que tener un numero de historia y servicio asignados ")
                    Exit Sub
                Else

                    'esto se hace para luego saber que historias tenemos retiradas del hospital 
                    accesodatos.ejecutarSQLDirecta("INSERT INTO fipcaratulasgeneradas (Numhistoria,servicio,idUsuario,identificador,fechacreacion) values ('" & registro.Cells("numhistoria").Value.ToString & "','" & registro.Cells("servicio").Value.ToString & "'," & frmContenedorMDI.oUsuario._id & ",'" & registro.Cells("identificador").Value.ToString & "',getdate())", cadenaconexioncaratulas)

                End If

                codigo_servicio = accesodatos.ejecutarSQLDirectaDataRow("SELECT idServicio FROM  SERVICIOS  WHERE (LTRIM(RTRIM(Abreviatura)) = '" & registro.Cells("servicio").Value.ToString & "')", cadenaconexioncaratulas).Item("idservicio")
                servicio = accesodatos.ejecutarSQLDirectaDataRow("SELECT descripcion FROM  SERVICIOS  WHERE (LTRIM(RTRIM(Abreviatura)) = '" & registro.Cells("servicio").Value.ToString & "')", cadenaconexioncaratulas).Item("descripcion")

                cadenaCodigoBarras = "09" & Format(registro.Cells("numhistoria").Value, "0000000000#") & Format(CInt(codigo_servicio), "000#") & Format(registro.Cells("Fechainicio").Value, "dd/MM/yyyy") & Format(registro.Cells("FechaTermino").Value, "dd/MM/yyyy") & Format(registro.Cells("numicu").Value, "00000000000000#")

                codigoBarras = Code128Rendering.MakeBarcodeImage(cadenaCodigoBarras, 3, True)

                memoria = txtMemoria.Text

                'If cmbcampomemoria1.Text <> "" Then
                '    campo1memoria = Trim(Me.txtCampoMemoria1.Text & " " & accesodatos.ponerCaracterEnBlanco(registro.Item(cmbcampomemoria1.Text)))
                'End If
                'If cmbCampoMemoria2.Text <> "" Then
                '    campo2memoria = Trim(Me.txtCampoMemoria2.Text & " " & accesodatos.ponerCaracterEnBlanco(registro.Item(cmbCampoMemoria2.Text)))
                'End If
                'If cmbCampoMemoria3.Text <> "" Then
                '    campo3memoria = Trim(Me.txtCampoMemoria3.Text & " " & accesodatos.ponerCaracterEnBlanco(registro.Item(cmbCampoMemoria3.Text)))
                'End If
                'If cmbCampoMemoria4.Text <> "" Then
                '    campo4memoria = Trim(Me.txtCampoMemoria4.Text & " " & accesodatos.ponerCaracterEnBlanco(registro.Item(cmbCampoMemoria4.Text)))
                'End If

                campo1memoria = Trim(" NHC " & accesodatos.ponerCaracterEnBlanco(registro.Cells("numhistoria").Value))
                campo2memoria = "Servicio " & Trim(servicio)
                campo3memoria = Trim("Episodio " & accesodatos.ponerCaracterEnBlanco(registro.Cells("numicu").Value))
                campo4memoria = Trim(" Fecha " & Format(registro.Cells("Fechainicio").Value, "dd/MM/yyyy")) & " - " & Trim(Format(registro.Cells("FechaTermino").Value, "dd/MM/yyyy"))

                tablaInforme.Rows.Add(titulo, subtitulo1, ImageToByte(codigoBarras), cadenaCodigoBarras, subtitulo2, campo1memoria, campo2memoria, campo3memoria, campo4memoria)

                Me.pgbCaratulas.Increment(1)
                Application.DoEvents()
            Next


            cr.SetDataSource(tablaInforme)

            CrystalReportViewer2.ReportSource = cr

            CrystalReportViewer2.Zoom(1)

            'cr.PrintToPrinter(1, False, 1, 1)



        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try


        With Me.pgbCaratulas
            .Value = 0
            .Refresh()
        End With

    End Sub


    Public Shared Function ImageToByte(ByVal img As Image) As Byte()
        Dim sTemp As String = Path.GetTempFileName()
        Dim fs As New System.IO.FileStream(sTemp, FileMode.OpenOrCreate, FileAccess.ReadWrite)
        img.Save(fs, System.Drawing.Imaging.ImageFormat.Png)
        fs.Position = 0
        '
        Dim imgLength As Integer = CInt(fs.Length)
        Dim bytes(0 To imgLength - 1) As Byte
        fs.Read(bytes, 0, imgLength)
        fs.Close()
        Return bytes



    End Function


#End Region


#Region "BUSQUEDA ACTUALIZACION CONJUNTO RESULTADOS "


    'realizar la busqueda
    Private Sub actualizarconjuntoResultados()
        Dim parametros As New Collection
        Dim elemento As elementoBusqueda = Nothing
        Dim datos3 As DataTable
        Dim registro As DataRow
        Dim datos5 As DataTable



        elemento = leerParametroEntrada(Me.txtNumhistoria, "Numhistoria", 0, 0)
        If Not IsNothing(elemento.valor) Then parametros.Add(elemento)
        elemento = Nothing




        elemento = leerParametroEntrada(Me.txtfechaactual, "fechaCaratula", 1, 1)
        If Not IsNothing(elemento.valor) Then parametros.Add(elemento)
        elemento = Nothing



        'elemento = leerParametroEntrada(Me.txtt, "telefono", 1, 0)
        'If Not IsNothing(elemento.valor) Then parametros.Add(elemento)
        'elemento = Nothing


        elemento = leerParametroEntrada(Me.cmdServicios, "servicio", 1, 0)
        If Not IsNothing(elemento.valor) Then parametros.Add(elemento)
        elemento = Nothing

        Call obtenerResultadosBusqueda(parametros)

        'si obtenemos un solo registro vamos a consultar el estado de la historia



    End Sub


    Private Function leerParametroEntrada(ByVal control As System.Windows.Forms.TextBox, ByVal nombreColTablaBD As String, ByVal texto As Integer, ByVal fecha As Integer)

        Dim elemento As elementoBusqueda

        If control.Text <> "" Then
            With elemento
                .Nombre = nombreColTablaBD
                .valor = control.Text
                .texto = texto
                .Fecha = fecha
            End With
            Return elemento
        Else
            Return Nothing
        End If

    End Function


    Private Function leerParametroEntrada(ByVal control As System.Windows.Forms.ComboBox, ByVal nombreColTablaBD As String, ByVal texto As Integer, ByVal fecha As Integer)

        Dim elemento As elementoBusqueda

        If Not IsNothing(control.SelectedItem) And control.Text <> "" Then
            With elemento
                .Nombre = nombreColTablaBD
                .valor = control.Text
                .texto = texto
                .Fecha = fecha
            End With
            Return elemento
        Else
            Return Nothing
        End If

    End Function


    Private Sub obtenerResultadosBusqueda(ByVal param As Collection)


        Try


            'MUY IMPORTANTE 
            'para que funcione bien la funcion de busqueda si no se ha seleccionado ningún parametro para 
            'la consulta tendremos que liberar el espacio de memoria del vector parametros para la 
            'funcon seleccionDocumentos detecte que no hay ningún parámetro 
            If param.Count = 0 Then param = Nothing

            Application.DoEvents()

            'inicializar el listview de los documentos

            If Me.DataGridView2.Rows.Count > 0 Then
                '  Me.DataGridView2.Rows.Clear()
            Else
                Me.DataGridView2.Refresh()
            End If



            seleccionHistorias(Me.DataGridView2, param)

            Me.DataGridView2.Refresh()
            Application.DoEvents()

        Catch ex As Exception
            MessageBox.Show("Error " & ex.Message)
        End Try

    End Sub


    Private Sub seleccionHistorias(ByRef resultados As DataGridView, ByVal parametros As Collection)

        Dim dtDocumentos As New DataTable
        Dim strSQL As String


        Dim contador As Integer = 0
        Dim cont As Integer = 0
        Dim algunaCoincidencia As Integer = 0
        Dim año As String

        Try


            If IsNothing(parametros) = True Then 'no hay parametros para la busqueda, lo seleccionamos absolutamente todo 
                ' 
                strSQL = "SELECT [NumHistoria],[numicu],[FechaInicio],[FechaTermino],[servicio],[fechaCaratula],[identificador],[idlote] FROM [PRODUCCIONVGDIARIO].[dbo].[FIP]"

            Else
                strSQL = "SELECT [NumHistoria],[numicu],[FechaInicio],[FechaTermino],[servicio],[fechaCaratula],[identificador],[idlote] FROM [PRODUCCIONVGDIARIO].[dbo].[FIP] WHERE "
                'iniciamos el recorrido del vector para añadir parametros a la busqueda 

                For Each item As elementoBusqueda In parametros

                    If cont = 0 Then 'solo hay un parametro para la busqueda y no hay que poner un and 

                        If item.texto = 0 Then 'el parametro que introduciomos es un entero 
                            strSQL = strSQL & item.Nombre & " = " & item.valor
                        Else
                            If item.Fecha = 0 Then 'el parametro que introduciomos es texto 
                                strSQL = strSQL & item.Nombre & " like '%" & item.valor & "%' "
                            Else 'el parametro que introduciomos es una fecha
                                If IsNothing(item.RangoFecha) = False Then
                                    Select Case item.RangoFecha
                                        'las instrucciones comentadas son las correctas para un servidor SQL 
                                        Case 0 'igual 
                                            strSQL = strSQL & " Left(Convert(varchar, " & item.Nombre & ", 103), 10)  = '" & item.valor & "' "
                                            'strSQL = strSQL & " date( " & item.Nombre & ") = '" & Mid(item.valor, 7, 4) & "-" & Mid(item.valor, 4, 2) & "-" & Mid(item.valor, 1, 2) & "'"
                                        Case 1 'entre
                                            'strSQL = strSQL & " Left(Convert(varchar, " & item.Nombre & ", 103), 10)  >= '" & item.valor & "' and"
                                            'strSQL = strSQL & " Left(Convert(varchar, " & item.Nombre & ", 103), 10)  <= '" & item.valor2 & "'"
                                            strSQL = strSQL & " date( " & item.Nombre & ") >= '" & Mid(item.valor, 7, 4) & "-" & Mid(item.valor, 4, 2) & "-" & Mid(item.valor, 1, 2) & "' and "
                                            strSQL = strSQL & " date( " & item.Nombre & ") <= '" & Mid(item.valor2, 7, 4) & "-" & Mid(item.valor2, 4, 2) & "-" & Mid(item.valor2, 1, 2) & "'"
                                        Case 2 'anterior
                                            'strSQL = strSQL & " Left(Convert(varchar, " & item.Nombre & ", 103), 10) <= '" & item.valor & "'"
                                            strSQL = strSQL & " date( " & item.Nombre & ") <= '" & Mid(item.valor, 7, 4) & "-" & Mid(item.valor, 4, 2) & "-" & Mid(item.valor, 1, 2) & " '"
                                        Case 3 'posterior
                                            'strSQL = strSQL & " Left(Convert(varchar, " & item.Nombre & ", 103), 10) >= '" & item.valor & "'"
                                            strSQL = strSQL & " date( " & item.Nombre & ") >= '" & Mid(item.valor, 7, 4) & "-" & Mid(item.valor, 4, 2) & "-" & Mid(item.valor, 1, 2) & " '"
                                    End Select
                                Else
                                    strSQL = strSQL & " LEFT(CONVERT(varchar," & item.Nombre & ",103),10) = '" & item.valor & "'"
                                End If

                            End If
                        End If
                        cont += 1 'incrementamos el contador para indicar que hay más de un parámetro 
                    Else 'hay mas de un parametro para la busqueda
                        If item.texto = 0 Then
                            strSQL = strSQL & " and " & item.Nombre & " = " & item.valor
                        Else
                            If item.Fecha = 0 Then
                                strSQL = strSQL & " and " & item.Nombre & " like '%" & item.valor & "%'"
                            Else
                                If IsNothing(item.RangoFecha) = False Then
                                    Select Case item.RangoFecha
                                        'las instrucciones comentadas son las correctas para un servidor SQL 
                                        Case 0 'igual 
                                            strSQL = strSQL & " and " & " Left(Convert(varchar, " & item.Nombre & ", 103), 10)  = '" & item.valor & "' "
                                            'strSQL = strSQL & " and date( " & item.Nombre & ") = '" & Mid(item.valor, 7, 4) & "-" & Mid(item.valor, 4, 2) & "-" & Mid(item.valor, 1, 2) & "'"
                                        Case 1 'entre
                                            'strSQL = strSQL & " Left(Convert(varchar, " & item.Nombre & ", 103), 10)  >= '" & item.valor & "' and"
                                            'strSQL = strSQL & " Left(Convert(varchar, " & item.Nombre & ", 103), 10)  <= '" & item.valor2 & "'"
                                            strSQL = strSQL & " and date( " & item.Nombre & ") >= '" & Mid(item.valor, 7, 4) & "-" & Mid(item.valor, 4, 2) & "-" & Mid(item.valor, 1, 2) & "' and "
                                            strSQL = strSQL & " date( " & item.Nombre & ") <= '" & Mid(item.valor2, 7, 4) & "-" & Mid(item.valor2, 4, 2) & "-" & Mid(item.valor2, 1, 2) & "'"
                                        Case 2 'anterior
                                            'strSQL = strSQL & " Left(Convert(varchar, " & item.Nombre & ", 103), 10) <= '" & item.valor & "'"
                                            strSQL = strSQL & " and date( " & item.Nombre & ") <= '" & Mid(item.valor, 7, 4) & "-" & Mid(item.valor, 4, 2) & "-" & Mid(item.valor, 1, 2) & " '"
                                        Case 3 'posterior
                                            'strSQL = strSQL & " Left(Convert(varchar, " & item.Nombre & ", 103), 10) >= '" & item.valor & "'"
                                            strSQL = strSQL & " and date( " & item.Nombre & ") >= '" & Mid(item.valor, 7, 4) & "-" & Mid(item.valor, 4, 2) & "-" & Mid(item.valor, 1, 2) & " '"
                                    End Select
                                End If
                            End If
                        End If
                    End If

                Next

            End If



            strSQL = strSQL & " order by identificador"

            Debug.Print(strSQL)

            Me.DataGridView2.DataSource = datosSQL.ejecutarSQLDirectaTable(strSQL, "Data Source=kroniko;Initial Catalog=PRODUCCIONVGDIARIO;User ID=sa;password=cd2009g")

            If Not IsNothing(Me.DataGridView2.Columns("identificador")) Then
                Me.DataGridView2.Columns("identificador").Visible = False
            End If

        Catch ex As Exception
            MessageBox.Show("Error " & ex.Message.ToString)
        End Try



    End Sub

#End Region

#Region "CONTROLOES"

    Private Sub modificarDatos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click


        If Me.DataGridView2.SelectedRows.Count = 1 Then
            Dim _frmEditarDatosFIP As New frmEditarFIP(CInt(Me.DataGridView2.SelectedRows(0).Cells("identificador").Value), cadenaconexioncaratulas)
            _frmEditarDatosFIP.ShowDialog(Me)

            actualizarconjuntoResultados()

        Else

            MessageBox.Show(" Seleccione un registro para modificar. ")

        End If


    End Sub



    'buscar documentos 

    Private Sub cmdBuscarDocumentos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click



        Dim _frmBuscarDatosFip As New frmBuscarDatosFIPBD(cadenaconexioncaratulas)
        _frmBuscarDatosFip.ShowDialog(Me)
        actualizarconjuntoResultados()

    End Sub

    Private Sub cmbServicios_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbEpisodios.SelectedIndexChanged
        Me.txtNumhistoria.Focus()
    End Sub


    'pistolear nhc
    Private Sub txtNumhistoria_cambiatexto(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumhistoria.TextChanged

        Dim barcode As String


        If Me.CheckBox1.Checked = True Then 'estamos en modo pistoleo si tiene los datos lo insertaremos


            If Me.txtNumhistoria.Text = "" Then
                ' e.Handled = True
                actualizarconjuntoResultados()
                Me.txtNumhistoria.Focus()
                Exit Sub
            End If

            If Me.cmLongBarCode.Text = "" Then
                MessageBox.Show("Tiene que seleccionar la longitud del codigo de barras.")
                Exit Sub
            End If
            If Len(Me.txtNumhistoria.Text) = CInt(Me.cmLongBarCode.Text) Then

                If Me.cmdServicios.Text <> "" And Me.cmbLote.Text <> "" Then

                    If Me.txtNumhistoria.Text <> "" Then ' si ya lo se esto es una tonteria pero como nunca puedes saber si no van a poner long de barcode ....

                        'barcode = Mid(Me.txtNumhistoria.Text, Len(My.Settings.cabeceraBarcodeHistoria) + 1, My.Settings.lenNHCBarcode)
                        barcode = Me.txtNumhistoria.Text

                        Me.ConsultarEpisodio(barcode)




                    Else
                        MessageBox.Show("No se puede insertar el registro, faltan datos. Compruebe que el numero de lote  y servicio esten asignados.")
                    End If
                Else
                    MessageBox.Show("No se puede insertar el registro, faltan datos. Compruebe que el numero de lote  y servicio esten asignados.")
                End If

            End If 'solo miramos cuando la longitud del codigo de barras coincide con el dato introducido

        End If



    End Sub


    Private Sub txtNumhistoria_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumhistoria.KeyDown

        If e.KeyCode = Keys.Enter Then
            Dim barcode As String

            If Me.CheckBox1.Checked = False Then
                If Me.cmdServicios.Text <> "" And Me.cmbLote.Text <> "" Then

                    If Me.txtNumhistoria.Text <> "" Then ' si ya lo se esto es una tonteria pero como nunca puedes saber si no van a poner long de barcode ....

                        'barcode = Mid(Me.txtNumhistoria.Text, Len(My.Settings.cabeceraBarcodeHistoria) + 1, My.Settings.lenNHCBarcode)
                        barcode = Me.txtNumhistoria.Text

                        Me.ConsultarEpisodio(barcode)


                    Else
                        MessageBox.Show("No se puede insertar el registro, faltan datos. Compruebe que el numero de lote  y servicio esten asignados")
                    End If
                Else
                    MessageBox.Show("No se puede insertar el registro, faltan datos. Compruebe que el numero de lote  y servicio esten asignados")
                End If
            End If
        End If
    End Sub




    'insertar nhc
    Private Sub cmdinsertarregistro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdinsertarRegistro.Click


        Try
            Dim icu As EpisodioPlana
        

            If Me.txtNumhistoria.Text <> "" And Me.cmbEpisodios.Text <> "" And Me.cmdServicios.Text <> "" And Me.cmbLote.Text <> "" And Me.txtNumpaginas.Text <> "" Then

                If Not IsNothing(Me.cmbEpisodios.SelectedItem) Then

                    icu = Me.cmbEpisodios.SelectedItem

                Else
                    'esto no puede pasar nunca a no ser que escriban algo el combo, y ni aun asi pero por si las moscas 
                    'que le vamoa a hacer estoy paranoico 
                End If


                If insetarRegistro(Me.txtNumhistoria.Text, Me.cmdServicios.Text, icu._episodio, icu._fechaInicio, icu._fechaTermino, Me.cmbLote.Text, Me.txtNumpaginas.Text) Then

                    Me.txtNumhistoria.Text = ""
                    Me.cmbEpisodios.Items.Clear()

                    actualizarconjuntoResultados()


                End If

                Me.txtNumhistoria.Text = ""
                Me.txtNumhistoria.Focus()
                actualizarconjuntoResultados()
            Else
                MessageBox.Show("No se puede insertar el registro, faltan datos. Compruebe que la fecha,lote,num paginas y servicio esten cumplimentados.")
            End If

        Catch ex As Exception
            MessageBox.Show("Error al insertar el registro." & ex.ToString)
        End Try

    End Sub

    'permutar jejeje entre indizacion pistoleada y a manubrio
    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If sender.checked = True Then
            ' Me.cmdinsertarRegistro.Visible = False
            Me.lblLonbarcode.Visible = True
            Me.cmLongBarCode.Visible = True
        Else
            'Me.cmdinsertarRegistro.Visible = True
            Me.lblLonbarcode.Visible = False
            Me.cmLongBarCode.Visible = False
        End If
    End Sub


    'permite seleccionar los ultimos dias que se tienen que mostrar en el desplegable de los episodios 
    Private Sub dias_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk5.CheckedChanged, chk20.CheckedChanged, chkall.CheckedChanged



        Dim chkaux As Windows.Forms.CheckBox

        chkaux = CType(sender, Windows.Forms.CheckBox)

        If chkaux.Checked = True Then

            Select Case chkaux.Name

                Case "chk5"
                    Me.chk20.Checked = False
                    Me.chkall.Checked = False
                Case "chk20"
                    Me.chk5.Checked = False
                    Me.chkall.Checked = False
                Case "chkall"
                    Me.chk5.Checked = False
                    Me.chk20.Checked = False
            End Select
        End If

    End Sub


    'permutar entre seleccion total y parcial 
    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged

        If sender.checked = True Then

            Me.DataGridView2.SelectAll()

        Else

            For i As Integer = 0 To Me.DataGridView2.Rows.Count - 1 Step 1
                Me.DataGridView2.Rows(i).Selected = False
            Next

            Me.DataGridView2.Refresh()


        End If

    End Sub

#End Region




#Region "ACCESO DATOS INSERCION REGISTRO- ESTO NO TENDRIA QUE ESTAR AQUI PERO... LAS PRISAS SON LAS PRISAS"


    Private Function insetarRegistro(ByVal numhistoria As String, ByVal servicio As String, ByVal episodio As String, ByVal fechainicio As String, ByVal fechatermino As String, ByVal lote As String, ByVal numdocs As String) As Boolean
        Dim strSQL As String
        Dim conexion As SqlConnection = Nothing
        Dim comando As SqlCommand
        Dim MyTrans As SqlTransaction = Nothing
        Dim correcto As Boolean = True

        Dim fechaactual As Date = Date.Now.ToShortDateString

        'determinar los campos obligatorios 



        Try


            conexion = New SqlConnection(cadenaconexioncaratulas)
            conexion.Open()

            MyTrans = conexion.BeginTransaction()


            strSQL = "Insert into FIP (NumHistoria,servicio,FechaInicio,FechaTermino,FechaCaratula,numicu,idlote,numdocs) values ('" & numhistoria & "','" & servicio & "','" & fechainicio & "','" & fechatermino & "','" & fechaactual & "'," & episodio & "," & lote & "," & numdocs & ")"
            Debug.Print(strSQL)
            comando = New SqlCommand(strSQL, conexion)
            comando.Transaction = MyTrans
            comando.ExecuteNonQuery()


            strSQL = "Insert into FIPINSERTADOS (NumHistoria,idusuario) values ('" & numhistoria & "','" & frmContenedorMDI.oUsuario._id & "')"
            comando = New SqlCommand(strSQL, conexion)
            comando.Transaction = MyTrans
            comando.ExecuteNonQuery()

            MyTrans.Commit()

        Catch ex As SqlException
            MessageBox.Show("ERROR los datos no se han modificado, compruebe que los datos introducidos son correctos ." & ex.Message.ToString, "ERROR")

            If Not IsNothing(MyTrans) Then
                MyTrans.Rollback()
            End If

            correcto = False
        Finally
            If conexion.State = ConnectionState.Open Then
                conexion.Close()
            End If

        End Try

        Return correcto


    End Function

    Public Sub ConsultarEpisodio(ByVal numeroHistoria As String)

        'inicializamos el combo 
        Me.cmbEpisodios.Items.Clear()
        Dim datos As New DataTable
        Dim epiplana As EpisodioPlana
        Dim numRegistros As String = " "
        Dim codigoServicio As LibreriaCadenaProduccion.Entidades.ClsServicio
        Dim contadorEpisodios As Integer = 0


        If Not IsNothing(Me.cmdServicios.SelectedItem) Then
            codigoServicio = Me.cmdServicios.SelectedItem
        Else
            MessageBox.Show("No ha seleccionado un servicio, seleccione un servicio y vuelva a introducir el número de historia")
            Exit Sub
        End If




        For Each Control As Windows.Forms.Control In Me.gbEpisodios.Controls

            Dim aux As System.Windows.Forms.CheckBox
            Debug.Print(Control.GetType.ToString)

            If Control.GetType.ToString = "System.Windows.Forms.CheckBox" Then

                aux = CType(Control, System.Windows.Forms.CheckBox)

                If aux.Checked Then

                    Select Case aux.Name
                        Case "chk5"
                            numRegistros = " TOP 5 "
                        Case "chk20"
                            numRegistros = " TOP 20 "
                        Case "chkall"
                            numRegistros = " "
                    End Select
                End If

            End If

        Next



        Dim strSQL As String

        Try


            'strSQL = "SELECT " & numRegistros & " ep.epis_apertura_fech,ep.epis_cierre_fecha,ep.epis_pk, serv.servicio"
            'strSQL &= " FROM hc, episodios AS ep, cex, servicios AS serv "
            'strSQL &= " WHERE hc.nhc = '" & numeroHistoria & "' and hc.codigo_cliente = ep.codigo_cliente and cex.codigo_cliente = hc.codigo_cliente and cex.codigo_servicio1 = " & codigoServicio._idservicio & " and cex.codigo_servicio1= serv.codigo_servicio and ep.referencia_id= cex.cex_pk"
            'strSQL &= " ORDER BY ep.epis_cierre_fecha DESC;"

            strSQL = "SELECT ep.epis_apertura_fech,ep.epis_cierre_fecha,ep.epis_pk, serv.servicio"
            strSQL &= " FROM hc, episodios  ep, cex, servicios serv "
            strSQL &= " WHERE hc.nhc = '" & numeroHistoria & "' and hc.codigo_cliente = ep.codigo_cliente and cex.codigo_cliente = hc.codigo_cliente and cex.codigo_servicio1 = " & codigoServicio._idservicio & " and cex.codigo_servicio1= serv.codigo_servicio and ep.referencia_id= cex.cex_pk"
            strSQL &= " ORDER BY ep.epis_cierre_fecha DESC;"



            Debug.Print("mega consulta ==>" & strSQL)

            Dim conexion As Odbc.OdbcConnection = Nothing


            Try
                conexion = New Odbc.OdbcConnection(My.Settings.cadenaConexionOracle)
                conexion.Open()

                Dim daDatos As Odbc.OdbcDataAdapter = New Odbc.OdbcDataAdapter(strSQL, conexion)
                daDatos.Fill(datos)
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString)
            Finally
                If conexion IsNot Nothing Then
                    If conexion.State = ConnectionState.Open Then conexion.Close()
                End If
            End Try




            If datos.Rows.Count > 0 Then

                For Each registro As DataRow In datos.Rows

                    epiplana = New EpisodioPlana(registro.Item("epis_apertura_fech"), registro.Item("epis_cierre_fecha"), registro.Item("epis_pk"))
                    cmbEpisodios.Items.Add(epiplana)
                    If contadorEpisodios = 0 Then cmbEpisodios.SelectedItem = epiplana
                    contadorEpisodios += 1
                Next

            Else

                cmbEpisodios.Text = ""
                cmbEpisodios.Items.Clear()
                Application.DoEvents()
                MessageBox.Show("No se han encontrado registros para este numero de historia.")
            End If

        Catch ex As Exception
            MessageBox.Show("Error al consultar los datos episodio en la base de datos hospital" & ex.ToString)
        End Try


    End Sub

#End Region





   
End Class