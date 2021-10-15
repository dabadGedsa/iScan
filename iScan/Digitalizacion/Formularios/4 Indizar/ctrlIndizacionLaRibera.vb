Imports datos = LibreriaCadenaProduccion.Datos.GeneralSQL.clsAccesoDatosSQL
Imports datosdocumento = LibreriaCadenaProduccion.Datos.Produccion.cadenaproduccion.clsAccesoDatosDocumento
Imports editor = LibreriaCadenaProduccion.TXT.clsFormato
Imports modelo = LibreriaCadenaProduccion.Entidades
Imports accesoDatos = LibreriaCadenaProduccion.Datos.GeneralSQL.clsAccesoDatosSQL
Imports accesoDatosDocumentos = LibreriaCadenaProduccion.Datos.Produccion.cadenaproduccion.clsAccesoDatosDocumento
Imports System.Data.SqlClient
Imports LibreriaCadenaProduccion.Module1

Public Module Globales

    Public SinEpisodio As Integer

End Module

Public Class ctrlIndizacionLaRibera
    Private _frmIndizacionGeneral As frmIndizacionGeneral
    Private documento As ListViewItem
    Private incidencia As ClsIncidencia

    Dim CambioComboDocumento As Boolean = True
    Dim CambioComboServicio As Boolean = True
    Dim CambioComboTipoActo As Boolean = True

    Dim tmpFechaDoc As String
    Dim tmpNumHistoria As String
    Dim tmpDni As String
    Dim tmpCip As String
    Dim tmpPaciente As String
    Dim tmpTipoActo As String
    Dim tmpNumIcu As String
    Dim tmpFechaIni As String
    Dim tmpFechaFin As String
    Dim tmpServicio As String
    Dim tmpTipoDoc As String

    Dim continua As Boolean = True

    Public ReadOnly Property GetDocumentoActual() As ListViewItem
        Get
            Return documento
        End Get
    End Property


    Public WriteOnly Property SetDocumentoActual() As ListViewItem
        Set(ByVal value As ListViewItem)
            documento = value
        End Set
    End Property


    Public Sub agregarInstancia(ByVal indizacion As frmIndizacionGeneral)
        Me._frmIndizacionGeneral = indizacion
    End Sub


    Public CalcularEpi As String

    Private Sub ctrlIndizacionEpidemiologia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim tipodocumento As LibreriaCadenaProduccion.Entidades.ClsTipoDocumento
        Dim servicio As LibreriaCadenaProduccion.Entidades.ClsServicio
        Dim tipoacto As LibreriaCadenaProduccion.Entidades.ClsTipoActo

        CalcularEpi = 0
        Try
            Me.cmbIncidencias.Items.Clear()
            'Me.cmb_codigo_doc.Items.Clear()
            'Me.cmbTipoEpisodio.Items.Clear() ' area
            Me.cmbServicios.Items.Clear()
            Me.cmbTipoActo.Items.Clear()

            'cargamos el combo de incidencias 
            For Each registro As DataRow In datos.ejecutarSQLDirectaTable("SELECT IdIncidencia , Descripcion , codigoASCII AS codigotecla FROM TIPOSINCIDENCIAS WHERE (Tipo LIKE 'DIGI') AND (codigoASCII IS NOT NULL)", frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto).Rows
                incidencia = New ClsIncidencia(registro.Item("idincidencia").ToString, registro.Item("descripcion").ToString, registro.Item("codigotecla").ToString)
                Me.cmbIncidencias.Items.Add(incidencia)
            Next

            'cargar el combo tipo documentos 
            Me.cmb_codigo_doc.Items.Clear()
            Dim lsSql As String = ""
            If My.Settings.WS_tipoDocumentoATratar.ToString.Trim = "DocumentoClinico" Then
                lsSql = "SELECT  idtipoDocumento, Definicion, Descripcion FROM TIPOSDOCUMENTOS WHERE Tipo='Clinico' " & IIf(My.Settings.tipoDocumentoEnUso.ToString.Trim = "", "", " AND idTipoDocumento in (" & My.Settings.tipoDocumentoEnUso.Replace(";", ",") & ")") & " order by idtipodocumento"

            ElseIf My.Settings.WS_tipoDocumentoATratar.ToString.Trim = "DocumentoAdministrativo" Then
                lsSql = "SELECT  idtipoDocumento, Definicion, Descripcion FROM TIPOSDOCUMENTOS WHERE Tipo='Administrativo' " & IIf(My.Settings.tipoDocumentoEnUso.ToString.Trim = "", "", " AND idTipoDocumento in (" & My.Settings.tipoDocumentoEnUso.Replace(";", ",") & ")") & " order by idtipodocumento"
            Else
                lsSql = "SELECT  idtipoDocumento, Definicion, Descripcion FROM TIPOSDOCUMENTOS WHERE 1=1 " & IIf(My.Settings.tipoDocumentoEnUso.ToString.Trim = "", "", " AND idTipoDocumento in (" & My.Settings.tipoDocumentoEnUso.Replace(";", ",") & ")") & " order by idtipodocumento"
            End If

            For Each registro As DataRow In datos.ejecutarSQLDirectaTable(lsSql, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto).Rows
                tipodocumento = New modelo.ClsTipoDocumento(registro.Item("idtipodocumento"), registro.Item("definicion"), registro.Item("descripcion"))
                Me.cmb_codigo_doc.Items.Add(tipodocumento)
            Next
            If frmContenedorMDI.oLote._tipoDocumento <> "" Then
                Me.txtCodigoDoc.Text = frmContenedorMDI.oLote._tipoDocumento
                CambiarTipoDocumento(Me.txtCodigoDoc.Text)
                Me.txtCodigoDoc.Enabled = False
                Me.cmb_codigo_doc.Enabled = False
            Else
                Me.txtCodigoDoc.Enabled = True
                Me.cmb_codigo_doc.Enabled = True
            End If

            'cargamos el comgo de servicio 
            For Each registro As DataRow In datos.ejecutarSQLDirectaTable("SELECT idServicio, idServicioHospital, Descripcion FROM SERVICIOS where visible = 1 order by descripcion", frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto).Rows
                servicio = New modelo.ClsServicio(registro.Item("idservicio"), registro.Item("idServicioHospital"), registro.Item("descripcion"))
                Me.cmbServicios.Items.Add(servicio)
            Next
            If frmContenedorMDI.oLote._servicio <> "" Then
                Me.txtServicio.Text = frmContenedorMDI.oLote._servicio
                CambiarServicio(Me.txtServicio.Text)
                Me.txtServicio.Enabled = False
                Me.cmbServicios.Enabled = False
            Else
                Me.txtServicio.Enabled = True
                Me.cmbServicios.Enabled = True
            End If

            'cargamos el comgo de Tipo de acto
            For Each registro As DataRow In datos.ejecutarSQLDirectaTable("SELECT codigo, Descripcion FROM TIPOSACTOS order by codigo", frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto).Rows
                tipoacto = New modelo.ClsTipoActo(registro.Item("codigo"), registro.Item("descripcion"))
                Me.cmbTipoActo.Items.Add(tipoacto)
            Next

        Catch ex As Exception
            ' MessageBox.Show("Error en el load del panel,posiblemente faltan datos combos. Mensaje err:  " & ex.Message.ToString)
        End Try
        'actualizar_datos()
        'If Me.txtNumHistoria.Text = "" Then
        ''Else
        'Me.txtCodigoDoc.Focus()
        'End If

        Me.mTxtFechaDia.Focus()
        'Me.mTxtFechaDia.Select()
        'Me.DateTimePicker1.Focus()
        'Me.DateTimePicker1.Select()

    End Sub


    Private Sub cmbTipoDocumento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_codigo_doc.SelectedIndexChanged

        If CambioComboDocumento = True Then
            If Not IsNothing(Me.cmb_codigo_doc.SelectedItem) Then
                Me.txtCodigoDoc.Text = CType(Me.cmb_codigo_doc.SelectedItem, modelo.ClsTipoDocumento).codigo
            End If
        End If
    End Sub


    'este controla el cambio de servicio
    Private Sub cmbservicio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbServicios.SelectedIndexChanged
        If CambioComboServicio = True Then
            If Not IsNothing(Me.cmbServicios.SelectedItem) Then
                Me.txtServicio.Text = CType(Me.cmbServicios.SelectedItem, modelo.ClsServicio)._idservicio
                CambiarServicio(txtServicio.Text)
            End If
        End If
    End Sub



    Private Sub txtTipoEpisodio_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'Dim encontrado As Boolean = False

        'If Me.txtTipoEpisodio.Text <> "" Then


        '    For Each tipoepisodio As modelo.ClsArea In Me.cmbTipoEpisodio.Items

        '        If tipoepisodio._idArea = Me.txtTipoEpisodio.Text Then
        '            encontrado = True
        '            'esto no le da el foco a otro componente por lo que no hay que 
        '            'gestionarlo
        '            Me.cmbTipoEpisodio.SelectedItem = tipoepisodio
        '            Exit For
        '        End If
        '    Next

        '    If encontrado Then

        '        Me.txtServicio.Focus()
        '        Me.txtServicio.SelectAll()
        '        Application.DoEvents()
        '    Else
        '        MessageBox.Show("El tipo episodio introducido no es valido")
        '        Me.txtTipoEpisodio.Text = ""
        '        Me.txtTipoEpisodio.Focus()
        '        Me.txtTipoEpisodio.SelectAll()
        '    End If
        'End If

    End Sub

    Private Sub txtFechaDiakeypress_(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles mTxtFechaDia.KeyPress
        Try

            ''If e.KeyChar = "m" Or e.KeyChar = "M" Then
            If e.KeyChar = "/" Then
                'Marca el registro como primero de la historia
                e.Handled = True
                Dim i As Integer = 0
                Dim EleSeleccionado As Integer = -1
                For i = 0 To (Me._frmIndizacionGeneral.ListView1.Items.Count - 1)
                    If Me._frmIndizacionGeneral.ListView1.Items(i).Selected Then
                        EleSeleccionado = i
                    End If
                Next
                If i > -1 Then
                    If Me._frmIndizacionGeneral.ListView1.Items(EleSeleccionado).SubItems("BarcodeDet").Text = "0" Then
                        Me._frmIndizacionGeneral.ListView1.Items(EleSeleccionado).SubItems("BarcodeDet").Text = "1"
                        Me._frmIndizacionGeneral.ListView1.Items(EleSeleccionado).SubItems("Primera").Text = "1"

                        Me._frmIndizacionGeneral.ListView1.Items(EleSeleccionado).Font = New Font(ListView1.Font, FontStyle.Bold)
                        Me._frmIndizacionGeneral.ListView1.Items(EleSeleccionado).ForeColor = Drawing.Color.DarkRed
                    Else
                        Me._frmIndizacionGeneral.ListView1.Items(EleSeleccionado).SubItems("BarcodeDet").Text = "0"
                        Me._frmIndizacionGeneral.ListView1.Items(EleSeleccionado).SubItems("Primera").Text = "0"

                        Me._frmIndizacionGeneral.ListView1.Items(EleSeleccionado).Font = New Font(ListView1.Font, FontStyle.Regular)
                        Me._frmIndizacionGeneral.ListView1.Items(EleSeleccionado).ForeColor = Drawing.Color.Black
                    End If
                End If

            ElseIf e.KeyChar = "e" Or e.KeyChar = "E" Then
                'e.Handled = True
                'EliminarDocumento()
                'Exit Sub
                e.Handled = True

                Dim i As Integer = 0
                Dim EleSeleccionado As Integer = -1
                For i = 0 To (Me._frmIndizacionGeneral.ListView1.Items.Count - 1)
                    If Me._frmIndizacionGeneral.ListView1.Items(i).Selected Then
                        EleSeleccionado = i
                    End If
                Next
                If i > -1 Then
                    Me._frmIndizacionGeneral.ListView1.Items(EleSeleccionado).SubItems("eliminada").Text = "1"
                End If
                EliminarDocumento()
                Me._frmIndizacionGeneral.bajarAbajo()
                Exit Sub

            ElseIf e.KeyChar = "º" Then
                e.Handled = True
                Me.mTxtFechaDia.Text = ""
                Me.mTxtFechaDia.SelectionStart = 0
                Exit Sub
                ''ElseIf e.KeyChar = "E" Then
                ''    'e.Handled = True
                ''    'EliminarDocumento()
                ''    'Exit Sub
                ''    e.Handled = True
                ''    Dim i As Integer = 0
                ''    Dim EleSeleccionado As Integer = -1
                ''    For i = 0 To (Me._frmIndizacionGeneral.ListView1.Items.Count - 1)
                ''        If Me._frmIndizacionGeneral.ListView1.Items(i).Selected Then
                ''            EleSeleccionado = i
                ''        End If
                ''    Next
                ''    If i > -1 Then
                ''        Me._frmIndizacionGeneral.ListView1.Items(EleSeleccionado).SubItems("eliminada").Text = "1"
                ''    End If
                ''    EliminarDocumento()
                ''    Me._frmIndizacionGeneral.bajarAbajo()
                ''    Exit Sub
                ''ElseIf e.KeyChar = "W" Or e.KeyChar = "w" Then
                ''    If ConInf.Checked = True Then
                ''        ConInf.Checked = False
                ''    Else
                ''        ConInf.Checked = True
                ''    End If
                ''    Exit Sub
                ''ElseIf e.KeyChar = "w" Then
                ''    If ConInf.Checked = True Then
                ''        ConInf.Checked = False
                ''    Else
                ''        ConInf.Checked = True
                ''    End If
                ''    Exit Sub
            ElseIf e.KeyChar = "*" Then

                If continua Then    'Esto lo hago porque cuando pulsabas rápido el *, se le iba la pinza al indice de la lista de documentos.

                    continua = False

                    Dim elementoanterior As ListViewItem

                    elementoanterior = _frmIndizacionGeneral.ListView1.Items(Me._frmIndizacionGeneral.indice - 1)

                    ''Me.mTxtFechaDia.Focus()

                    copiarDatos_Anterior(elementoanterior)

                    pegarDatos()
                    pulsaMas()

                    continua = True

                    e.Handled = True
                End If

                Exit Sub

                ElseIf e.KeyChar = "t" Or e.KeyChar = "T" Then
                    'e.Handled = True
                    'DesEliminarDocumento()
                    'Exit Sub
                    e.Handled = True
                    Dim i As Integer = 0
                    Dim EleSeleccionado As Integer = -1
                    For i = 0 To (Me._frmIndizacionGeneral.ListView1.Items.Count - 1)
                        If Me._frmIndizacionGeneral.ListView1.Items(i).Selected Then
                            EleSeleccionado = i
                        End If
                    Next
                    If i > -1 Then
                        Me._frmIndizacionGeneral.ListView1.Items(EleSeleccionado).SubItems("eliminada").Text = "0"
                    End If
                    DesEliminarDocumento()
                    Me._frmIndizacionGeneral.bajarAbajo()
                    Exit Sub
                    ''ElseIf e.KeyChar = "T" Then
                    ''    'e.Handled = True
                    ''    'DesEliminarDocumento()
                    ''    'Exit Sub
                    ''    e.Handled = True
                    ''    Dim i As Integer = 0
                    ''    Dim EleSeleccionado As Integer = -1
                    ''    For i = 0 To (Me._frmIndizacionGeneral.ListView1.Items.Count - 1)
                    ''        If Me._frmIndizacionGeneral.ListView1.Items(i).Selected Then
                    ''            EleSeleccionado = i
                    ''        End If
                    ''    Next
                    ''    If i > -1 Then
                    ''        Me._frmIndizacionGeneral.ListView1.Items(EleSeleccionado).SubItems("eliminada").Text = "0"
                    ''    End If
                    ''    DesEliminarDocumento()
                    ''    Me._frmIndizacionGeneral.bajarAbajo()
                    ''    Exit Sub
                ElseIf e.KeyChar = "r" Or e.KeyChar = "R" Then
                    e.Handled = True
                    imagen_rota()
                    Exit Sub
                    ''ElseIf e.KeyChar = "R" Then
                    ''    e.Handled = True
                    ''    imagen_rota()
                    ''    Exit Sub
                ElseIf e.KeyChar = "q" Or e.KeyChar = "Q" Then
                    e.Handled = True
                    ''Me.txtNumicu.Text = "998"
                    Me.txtNumicu.Text = ""
                    Me.txtServicio.Text = ""
                    SinEpisodio = 1
                    CalcularEpi = 1
                    Me.txtServicio.Focus()
                    Return
                    Exit Sub
                    ''ElseIf e.KeyChar = "Q" Then
                    ''    e.Handled = True
                    ''    Me.txtNumicu.Text = "998"
                    ''    Me.txtServicio.Text = ""
                    ''    SinEpisodio = 1
                    ''    CalcularEpi = 1
                    ''    Me.txtServicio.Focus()
                    ''    Exit Sub
                ElseIf e.KeyChar = "A" Or e.KeyChar = "a" Then
                    e.Handled = True
                    ''Me.txtNumicu.Text = "998"
                    Me.txtNumicu.Text = ""
                    Me.txtServicio.Text = "153"
                    SinEpisodio = 1
                    CalcularEpi = 1
                    Me.txtServicio.Focus()
                    Exit Sub
                    ''ElseIf e.KeyChar = "a" Then
                    ''    e.Handled = True
                    ''    Me.txtNumicu.Text = "998"
                    ''    Me.txtServicio.Text = "153"
                    ''    SinEpisodio = 1
                    ''    CalcularEpi = 1
                    ''    Me.txtServicio.Focus()
                    ''    Exit Sub
                ElseIf e.KeyChar = "s" Or e.KeyChar = "S" Then
                    e.Handled = True
                    If UCSI.Checked = True Then
                        UCSI.Checked = False
                    Else
                        UCSI.Checked = True
                    End If
                    Exit Sub
                    ''ElseIf e.KeyChar = "S" Then
                    ''    e.Handled = True
                    ''    If UCSI.Checked = True Then
                    ''        UCSI.Checked = False
                    ''    Else
                    ''        UCSI.Checked = True
                    ''    End If
                    ''    Exit Sub
                ElseIf (e.KeyChar = "+") Then
                    'e.Handled = True
                    'Dim auxHistoriaAnterior As String = Me.txtNumHistoria.Text
                    'Dim encontrado As Boolean = False
                    'If Me.txtServicio.Text <> "" Then
                    '    Me._frmIndizacionGeneral.bajarAbajo()
                    '    If GetDocumentoActual.SubItems("indizado").Text = 1 Then
                    '        Me.mTxtFechaDia.Text = GetDocumentoActual.SubItems("fechadocumento").Text

                    '        Me.cmbServicios.SelectedIndex = Me.cmbServicios.FindString(GetDocumentoActual.SubItems("servicio").Text)
                    '        'Me.txtServicio.Focus()
                    '    Else
                    '        actualizarDatos(Me.mTxtFechaDia.Text)
                    '        If auxHistoriaAnterior <> Me.txtNumHistoria.Text Then
                    '            Me._frmIndizacionGeneral.escribirCambioHistoria(auxHistoriaAnterior, Me.txtNumHistoria.Text)
                    '            Me.pnlCambio.BackColor = Color.Red
                    '            Me.mTxtFechaDia.Focus()
                    '            Me.mTxtFechaDia.SelectAll()
                    '        Else
                    '            Me._frmIndizacionGeneral.escribirHistoria(auxHistoriaAnterior, Me.txtNumHistoria.Text)
                    '            Me.pnlCambio.BackColor = Color.Lime
                    '            Me.mTxtFechaDia.Focus()
                    '            'Me.mTxtFechaDia.SelectionStart = 0
                    '            'Me.mTxtFechaDia.SelectionLength = Me.mTxtFechaDia.Text.Length
                    '            Me.mTxtFechaDia.SelectAll()
                    '        End If


                    '    End If

                    'End If

                    'Me.ListView1.Items.Clear()

                    'If Me.pnlCambio.BackColor = Color.Lime Then
                    '    'Me.txtServicio.Focus()
                    '    'Me.txtServicio.SelectAll()
                    'Else
                    '    Me.mTxtFechaDia.Focus()
                    'End If
                    ''Me.mTxtFechaDia.Focus()
                    ''Me.mTxtFechaDia.SelectAll()
                    e.Handled = True

                    pulsaMas()


                ElseIf (e.KeyChar = "-") Then
                    e.Handled = True
                Me._frmIndizacionGeneral.subirArriba()
            End If

            'If My.Settings.ModoDepuracion = "True" Then
            '    If Not IsNothing(GetDocumentoActual) Then
            '        Me.RichTextBox1.Visible = True
            '        Me.RichTextBox1.Text = MostrarInformacionElementoLista(GetDocumentoActual)
            '    End If
            'End If

        Catch ex As Exception
            MessageBox.Show("Error al guardar el dato")
        End Try
    End Sub

    Function imagen_rota() As Boolean
        Try
            _frmIndizacionGeneral.IMGeditPrincipal.RotateRight()
            _frmIndizacionGeneral.IMGeditPrincipal.Save()
            _frmIndizacionGeneral.IMGeditPrincipal.FitTo(0)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Incidencia de aplicacion")
        End Try

    End Function

    Private Sub txtservicio_keypress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtServicio.KeyPress
        Try
            ''If e.KeyChar = "m" Or e.KeyChar = "M" Then
            If e.KeyChar = "/" Then
                'Marca el registro como primero de la historia
                e.Handled = True
                Dim i As Integer = 0
                Dim EleSeleccionado As Integer = -1
                For i = 0 To (Me._frmIndizacionGeneral.ListView1.Items.Count - 1)
                    If Me._frmIndizacionGeneral.ListView1.Items(i).Selected Then
                        EleSeleccionado = i
                    End If
                Next
                If i > -1 Then
                    If Me._frmIndizacionGeneral.ListView1.Items(EleSeleccionado).SubItems("BarcodeDet").Text = "0" Then
                        Me._frmIndizacionGeneral.ListView1.Items(EleSeleccionado).SubItems("BarcodeDet").Text = "1"
                        Me._frmIndizacionGeneral.ListView1.Items(EleSeleccionado).SubItems("Primera").Text = "1"

                        Me._frmIndizacionGeneral.ListView1.Items(EleSeleccionado).Font = New Font(ListView1.Font, FontStyle.Bold)
                        Me._frmIndizacionGeneral.ListView1.Items(EleSeleccionado).ForeColor = Drawing.Color.DarkRed
                    Else
                        Me._frmIndizacionGeneral.ListView1.Items(EleSeleccionado).SubItems("BarcodeDet").Text = "0"
                        Me._frmIndizacionGeneral.ListView1.Items(EleSeleccionado).SubItems("Primera").Text = "0"

                        Me._frmIndizacionGeneral.ListView1.Items(EleSeleccionado).Font = New Font(ListView1.Font, FontStyle.Regular)
                        Me._frmIndizacionGeneral.ListView1.Items(EleSeleccionado).ForeColor = Drawing.Color.Black
                    End If
                End If

            ElseIf e.KeyChar = "º" Then
                e.Handled = True
                Me.mTxtFechaDia.Focus()
                Me.mTxtFechaDia.SelectAll()
                Exit Sub
                'ElseIf e.KeyChar = ChrW(Keys.Return) Then
                '    If IsNumeric(txtServicio.Text) = 0 Then
                '        e.Handled = True
                '        Dim conexion As SqlConnection = Nothing
                '        Dim Servicios As DataTable
                '        conexion = New SqlConnection("Data Source=ACUARIO;Initial Catalog=PRODUCCIONPESET2014;User ID=sa;password=sa2003#")
                '        Dim cmd As New SqlCommand
                '        Dim returnValue As Object

                '        cmd.CommandText = "select idservicio from servicios where descripcion like '" & txtServicio.Text & "%'"
                '        cmd.CommandType = CommandType.Text
                '        cmd.Connection = conexion
                '        conexion.Open()
                '        returnValue = cmd.ExecuteScalar()
                '        txtServicio.Text = returnValue
                '        cmbServicios.SelectedIndex = returnValue
                '        conexion.Close()
                '    End If
                '    Exit Sub

            ElseIf e.KeyChar = "E" Then
                'e.Handled = True
                'EliminarDocumento()
                'Exit Sub
                e.Handled = True
                Dim i As Integer = 0
                Dim EleSeleccionado As Integer = -1
                For i = 0 To (Me._frmIndizacionGeneral.ListView1.Items.Count - 1)
                    If Me._frmIndizacionGeneral.ListView1.Items(i).Selected Then
                        EleSeleccionado = i
                    End If
                Next
                If i > -1 Then
                    Me._frmIndizacionGeneral.ListView1.Items(EleSeleccionado).SubItems("eliminada").Text = "1"
                End If
                EliminarDocumento()
                Me._frmIndizacionGeneral.bajarAbajo()
                Exit Sub
            ElseIf e.KeyChar = "e" Then
                'e.Handled = True
                'EliminarDocumento()
                'Exit Sub
                e.Handled = True
                Dim i As Integer = 0
                Dim EleSeleccionado As Integer = -1
                For i = 0 To (Me._frmIndizacionGeneral.ListView1.Items.Count - 1)
                    If Me._frmIndizacionGeneral.ListView1.Items(i).Selected Then
                        EleSeleccionado = i
                    End If
                Next
                If i > -1 Then
                    Me._frmIndizacionGeneral.ListView1.Items(EleSeleccionado).SubItems("eliminada").Text = "1"
                End If
                EliminarDocumento()
                Me._frmIndizacionGeneral.bajarAbajo()
                Exit Sub
                ''ElseIf e.KeyChar = "W" Then
                ''    e.Handled = True
                ''    If ConInf.Checked = True Then
                ''        ConInf.Checked = False
                ''    Else
                ''        ConInf.Checked = True
                ''        UCSI.Checked = False
                ''        SD.Checked = False
                ''    End If
                ''    Exit Sub
                ''ElseIf e.KeyChar = "w" Then
                ''    e.Handled = True
                ''    If ConInf.Checked = True Then
                ''        ConInf.Checked = False
                ''    Else
                ''        ConInf.Checked = True
                ''        UCSI.Checked = False
                ''        SD.Checked = False
                ''    End If
                ''    Exit Sub
            ElseIf e.KeyChar = "*" Then
                If continua Then    'Esto lo hago porque cuando pulsabas rápido el *, se le iba la pinza al indice de la lista de documentos.

                    continua = False

                    Dim elementoanterior As ListViewItem

                    elementoanterior = _frmIndizacionGeneral.ListView1.Items(Me._frmIndizacionGeneral.indice - 1)

                    ''Me.mTxtFechaDia.Focus()

                    copiarDatos_Anterior(elementoanterior)

                    pegarDatos()
                    pulsaMas()

                    continua = True

                    e.Handled = True
                End If

                Exit Sub

            ElseIf e.KeyChar = "T" Then
                e.Handled = True
                Dim i As Integer = 0
                Dim EleSeleccionado As Integer = -1
                For i = 0 To (Me._frmIndizacionGeneral.ListView1.Items.Count - 1)
                    If Me._frmIndizacionGeneral.ListView1.Items(i).Selected Then
                        EleSeleccionado = i
                    End If
                Next
                If i > -1 Then
                    Me._frmIndizacionGeneral.ListView1.Items(EleSeleccionado).SubItems("eliminada").Text = "0"
                End If
                DesEliminarDocumento()
                Me._frmIndizacionGeneral.bajarAbajo()
                Exit Sub

            ElseIf e.KeyChar = "t" Then
                e.Handled = True
                Dim i As Integer = 0
                Dim EleSeleccionado As Integer = -1
                For i = 0 To (Me._frmIndizacionGeneral.ListView1.Items.Count - 1)
                    If Me._frmIndizacionGeneral.ListView1.Items(i).Selected Then
                        EleSeleccionado = i
                    End If
                Next
                If i > -1 Then
                    Me._frmIndizacionGeneral.ListView1.Items(EleSeleccionado).SubItems("eliminada").Text = "0"
                End If
                DesEliminarDocumento()
                Me._frmIndizacionGeneral.bajarAbajo()
                Exit Sub
            ElseIf e.KeyChar = "q" Then
                e.Handled = True
                ''Me.txtNumicu.Text = "998"
                Me.txtNumicu.Text = ""
                Me.txtServicio.Text = ""
                Me.mtxtFEchainicio.Text = Me.mTxtFechaDia.Text
                Me.mtxtfechaTerminio.Text = Me.mTxtFechaDia.Text
                CalcularEpi = 1
                Exit Sub
            ElseIf e.KeyChar = "Q" Then
                e.Handled = True
                ''Me.txtNumicu.Text = "998"
                Me.txtNumicu.Text = ""
                Me.txtServicio.Text = ""
                Me.mtxtFEchainicio.Text = Me.mTxtFechaDia.Text
                Me.mtxtfechaTerminio.Text = Me.mTxtFechaDia.Text
                CalcularEpi = 1
                Exit Sub
            ElseIf e.KeyChar = "a" Then
                e.Handled = True
                ''Me.txtNumicu.Text = "998"
                Me.txtNumicu.Text = ""
                Me.txtServicio.Text = "153"
                Me.mtxtFEchainicio.Text = Me.mTxtFechaDia.Text
                Me.mtxtfechaTerminio.Text = Me.mTxtFechaDia.Text
                CalcularEpi = 1
                Exit Sub
            ElseIf e.KeyChar = "A" Then
                e.Handled = True
                ''Me.txtNumicu.Text = "998"
                Me.txtNumicu.Text = ""
                Me.txtServicio.Text = "153"
                Me.mtxtFEchainicio.Text = Me.mTxtFechaDia.Text
                Me.mtxtfechaTerminio.Text = Me.mTxtFechaDia.Text
                CalcularEpi = 1
                Exit Sub
            ElseIf e.KeyChar = "r" Then
                e.Handled = True
                imagen_rota()
                Exit Sub
            ElseIf e.KeyChar = "R" Then
                e.Handled = True
                imagen_rota()
                Exit Sub
            ElseIf e.KeyChar = "s" Then
                e.Handled = True
                If UCSI.Checked = True Then
                    UCSI.Checked = False
                Else
                    UCSI.Checked = True
                    SD.Checked = False
                    ConInf.Checked = False
                End If
                Exit Sub
            ElseIf e.KeyChar = "S" Then
                e.Handled = True
                If UCSI.Checked = True Then
                    UCSI.Checked = False
                Else
                    UCSI.Checked = True
                    SD.Checked = False
                    ConInf.Checked = False
                End If
                Exit Sub
            ElseIf (e.KeyChar = "+") Then
                'e.Handled = True
                'Dim auxHistoriaAnterior As String = Me.txtNumHistoria.Text
                'Dim encontrado As Boolean = False

                'If Me.txtServicio.Text <> "" Then


                '    'For Each tipodocumento As modelo.ClsTipoDocumento In Me.cmb_codigo_doc.Items

                '    '    If tipodocumento.codigo = Me.txtCodigoDoc.Text Then
                '    '        encontrado = True
                '    '        'esto no le da el foco a otro componente por lo que no hay que 
                '    '        'gestionarlo
                '    '        Me.cmb_codigo_doc.SelectedItem = tipodocumento
                '    '        Exit For
                '    '    End If
                '    'Next

                '    'If Not encontrado Then

                '    '    MessageBox.Show("El tipo de documento no es valido")
                '    '    Me.txtCodigoDoc.Text = ""
                '    '    Me.txtCodigoDoc.Focus()
                '    '    Me.txtCodigoDoc.SelectAll()
                '    'Else
                '    Me._frmIndizacionGeneral.bajarAbajo()
                '    If GetDocumentoActual.SubItems("indizado").Text = 1 Then
                '        Me.txtServicio.Focus()
                '    Else
                '        'actualizarDatos(Me.DateTimePicker1.Text)

                '        actualizarDatos(Me.mTxtFechaDia.Text)
                '        If auxHistoriaAnterior <> Me.txtNumHistoria.Text Then
                '            Me._frmIndizacionGeneral.escribirCambioHistoria(auxHistoriaAnterior, Me.txtNumHistoria.Text)
                '            Me.pnlCambio.BackColor = Color.Red
                '            Me.mTxtFechaDia.Focus()
                '            Me.mTxtFechaDia.SelectAll()

                '            Debug.Print("hemos llegado hasta aqui ")
                '        Else
                '            Me._frmIndizacionGeneral.escribirHistoria(auxHistoriaAnterior, Me.txtNumHistoria.Text)
                '            Me.pnlCambio.BackColor = Color.Lime
                '            Me.txtServicio.Focus()
                '            Me.txtServicio.SelectAll()
                '        End If
                '        'End If
                '    End If

                '    Me.ListView1.Items.Clear()

                '    If Me.pnlCambio.BackColor = Color.Lime Then
                '        Me.txtServicio.Focus()
                '        Me.txtServicio.SelectAll()
                '    Else
                '        Me.mTxtFechaDia.Focus()
                '        Me.mTxtFechaDia.SelectAll()
                '    End If

                '    'Nuevo
                '    Me.mTxtFechaDia.Focus()
                '    Me.mTxtFechaDia.SelectAll()
                'End If
                e.Handled = True
                Dim auxHistoriaAnterior As String = Me.txtNumHistoria.Text
                Dim encontrado As Boolean = False


                Dim ValorTipoDoc As String = ""
                Dim ValorServicio As String = ""
                Dim ValorFecha As String = ""
                Dim ValorFechaINI As String = ""
                Dim ValorFechaFIN As String = ""
                Dim ValorICU As String = ""


                ValorTipoDoc = Me.txtCodigoDoc.Text
                ValorServicio = Me.txtServicio.Text
                ValorFecha = Me.mTxtFechaDia.Text
                ValorFechaINI = Me.mtxtFEchainicio.Text
                ValorFechaFIN = Me.mtxtfechaTerminio.Text
                ValorICU = Me.txtNumicu.Text

                PasarASiguiente = True

                If Me.txtServicio.Text <> "" Then


                    For Each tipodocumento As modelo.ClsTipoDocumento In Me.cmb_codigo_doc.Items
                        If tipodocumento.codigo.ToString.Trim = Me.txtCodigoDoc.Text.ToString.Trim Then
                            encontrado = True
                            'esto no le da el foco a otro componente por lo que no hay que 
                            'gestionarlo
                            Me.cmb_codigo_doc.SelectedItem = tipodocumento
                            Exit For
                        End If
                    Next

                    If Not encontrado Then
                        MessageBox.Show("El tipo de documento no es valido")
                        Me.txtCodigoDoc.Focus()
                        Me.txtCodigoDoc.SelectAll()
                        Exit Sub
                    End If

                    encontrado = False

                    For Each codigoservicio As modelo.ClsServicio In Me.cmbServicios.Items

                        If codigoservicio._idservicio = Me.txtServicio.Text Then
                            encontrado = True
                            'esto no le da el foco a otro componente por lo que no hay que 
                            'gestionarlo
                            Me.cmbServicios.SelectedItem = codigoservicio
                            Exit For
                        End If
                    Next

                    If Not encontrado Then
                        MessageBox.Show("El codido de servicio no es valido")
                        'Me.txtCodigoDoc.Text = ""
                        Me.txtServicio.Focus()
                        Me.txtServicio.SelectAll()
                        Exit Sub
                    Else


                        '############# JGARIJO 11/11/2019 #################
                        'Modificacion para evitar que al pulsar la tecla + en este campo
                        'si el lote todavia no ha sido cerrado no es necesario que entren en modo de edicion
                        'y que las pulsaciones al + son para navegar, aunque se guarde el registro como indizado = 1
                        If LoteYaCerrado = True Then
                            'Sabemos que es un lote que se cerró y por lo tanto para cambiar valores se debe entrar en modo de edicion
                            If GetDocumentoActual.SubItems("indizada").Text = 1 And ModoEdicion = False Then
                                MsgBox("No es posible modificar un registro ya indizado sin entrar en Modo Edicion")
                                Exit Sub
                            End If
                        End If


                        Me._frmIndizacionGeneral.bajarAbajo()
                        If GetDocumentoActual.SubItems("indizada").Text = 1 Then
                            Me.txtServicio.Focus()
                        Else
                            'actualizarDatos(Me.DateTimePicker1.Text)
                            actualizarDatos(Me.mTxtFechaDia.Text)
                            If auxHistoriaAnterior <> Me.txtNumHistoria.Text Then
                                Me._frmIndizacionGeneral.escribirCambioHistoria(auxHistoriaAnterior, Me.txtNumHistoria.Text)
                                Me.pnlCambio.BackColor = Color.Red
                                Me.txtCodigoDoc.Focus()
                                Me.txtCodigoDoc.SelectAll()

                                Debug.Print("hemos llegado hasta aqui ")
                            Else
                                Me._frmIndizacionGeneral.escribirHistoria(auxHistoriaAnterior, Me.txtNumHistoria.Text)
                                Me.pnlCambio.BackColor = Color.Lime
                                'Me.txtCodigoDoc.Focus()
                                'Me.txtCodigoDoc.SelectAll()
                                Me.txtServicio.Focus()
                                Me.txtServicio.SelectAll()
                            End If
                        End If
                    End If
                End If

                Me.ListView1.Items.Clear()

                If Me.pnlCambio.BackColor = Color.Lime Then
                    Me.txtCodigoDoc.Focus()
                    Me.txtCodigoDoc.SelectAll()
                Else
                    Me.txtCodigoDoc.Focus()
                    Me.txtCodigoDoc.SelectAll()
                End If

                If GetDocumentoActual.SubItems("indizada").Text <> 1 Then
                    Me.txtCodigoDoc.Text = ValorTipoDoc
                    Me.txtServicio.Text = ValorServicio
                    Me.mTxtFechaDia.Text = ValorFecha
                    Me.mtxtFEchainicio.Text = ValorFechaINI
                    Me.mtxtfechaTerminio.Text = ValorFechaFIN
                    Me.txtNumicu.Text = ValorICU
                End If

                'Nuevo
                Me.txtCodigoDoc.Focus()
                Me.txtCodigoDoc.SelectAll()
            ElseIf (e.KeyChar = "-") Then
                e.Handled = True
                Me.mtxtFEchainicio.Text = Me.mTxtFechaDia.Text
                Me._frmIndizacionGeneral.subirArriba()


                'Me.txtNumicu.Focus()
                'Me.txtNumicu.SelectAll()
                'If Trim(Replace(Me.txtFecha.Text, "/", "")) <> "" Then
                '    Me.txtCodigoDoc.Focus()
                'Else
                '    Me.txtFecha.Focus()
                'End If
                'Me.mtxtFEchainicio.Focus()
                ' Me.mtxtFEchainicio.SelectAll()
            Else
                ''Me.txtNumicu.Text = "998"
                ''Me.txtNumicu.Text = ""
                CambiarServicio(e.KeyChar)
                Return
            End If

            'If My.Settings.ModoDepuracion = "True" Then
            '    If Not IsNothing(GetDocumentoActual) Then
            '        Me.RichTextBox1.Visible = True
            '        Me.RichTextBox1.Text = MostrarInformacionElementoLista(GetDocumentoActual)
            '    End If
            'End If

        Catch ex As Exception
            MessageBox.Show("Error al guardar el dato")
        End Try
    End Sub



#Region "cosas que sobran pero que luego te pueden venir bien "
    Public Function MostrarInformacionElementoLista(ByVal ElementoLista As ListViewItem) As String

        Dim info As String

        With ElementoLista
            info = "Nombre: " & .Name
            If .Index = ElementoLista.Index Then
                info &= "Es Indice Lista: " & .Index.ToString
            Else
                info &= "Indice: " & .Index.ToString
            End If

            info &= "Posicion " & .Position.ToString
            info &= " Texto" & .Text.ToString

            For Each Subelemento As ListViewItem.ListViewSubItem In ElementoLista.SubItems

                With Subelemento
                    info &= " Nombre col " & .Name.ToString
                    info &= " valor  " & .Text & vbCr
                End With
            Next

        End With


        Return info

    End Function

    'Private Sub cmbArea_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If Not IsNothing(cmbTipoEpisodio.SelectedItem) Then
    '        Me.cmbTipoEpisodio.Text = CType(Me.cmbTipoEpisodio.SelectedItem, modelo.ClsArea)._idArea
    '    End If
    'End Sub


    Private Sub buttonincidencia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim incidenciaSeleccionada As ClsIncidencia

        If Not IsNothing(Me.cmbIncidencias.SelectedItem) Then

            incidenciaSeleccionada = CType(Me.cmbIncidencias.SelectedItem, ClsIncidencia)

            If incidenciaSeleccionada.Getidincidencia = 0 Then

                datosdocumento.DesmarcarInicidencia(GetDocumentoActual.Text, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto, frmContenedorMDI.oProyecto._NombreBaseDatos)
                'editor.escribir(Me._frmIndizacionGeneral.RichTextBox1, "Eliminada la incidencia del documento " & GetDocumentoActual.SubItems("nomarchivotif").ToString)
            Else
                ' datosdocumento.MarcarIndidenciaDocumento( incidenciaSeleccionada.Getidincidencia, GetDocumentoActual.Text, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto)
                'editor.escribir(Me._frmIndizacionGeneral.RichTextBox1, "Marcada la incidencia (idIncidencia: " & incidenciaSeleccionada.Getidincidencia & ") del documento " & GetDocumentoActual.SubItems("nomarchivotif").ToString)
            End If


        End If



    End Sub

    'Private Sub actualizar_datos()

    '    Dim strsql As String = "SELECT NumHistoria FROM DOCUMENTOS GROUP BY NumHistoria ORDER BY NumHistoria"

    '    'For Each registro As DataRow In datos.ejecutarSQLDirectaTable(strsql, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto).Rows
    '    '    Me.cmb_codigo_doc.Items.Add(registro.Item(0).ToString.ToUpper)
    '    'Next



    'End Sub

    'Private Sub txtCodigoDoc_leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigoDoc.LostFocus

    '    Dim encontrado As Boolean = False

    '    If Me.txtCodigoDoc.Text <> "" Then


    '        For Each tipodocumento As modelo.ClsTipoDocumento In Me.cmb_codigo_doc.Items

    '            If tipodocumento.codigo = Me.txtCodigoDoc.Text Then
    '                encontrado = True
    '                'esto no le da el foco a otro componente por lo que no hay que 
    '                'gestionarlo
    '                Me.cmb_codigo_doc.SelectedItem = tipodocumento
    '                Exit For
    '            End If
    '        Next

    '        If encontrado Then

    '            Me.txtFechaIni.Focus()
    '            Me.txtFechaIni.SelectAll()
    '            Application.DoEvents()
    '        Else
    '            MessageBox.Show("El tipo de documento no es valido")
    '            Me.txtCodigoDoc.Text = ""
    '            Me.txtCodigoDoc.Focus()
    '            Me.txtCodigoDoc.SelectAll()
    '        End If
    '    End If
    'End Sub

#End Region


    Public Sub EliminarDocumento()
        accesoDatosDocumentos.EliminarDocumento(frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto, Me.GetDocumentoActual.SubItems("idlote").Text, Me.GetDocumentoActual.SubItems("pagina").Text)
        Me._frmIndizacionGeneral.actualizarDatosListView()

    End Sub


    Public Sub DesEliminarDocumento()
        accesoDatosDocumentos.DesEliminarDocumento(frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto, Me.GetDocumentoActual.SubItems("idlote").Text, Me.GetDocumentoActual.SubItems("pagina").Text)
        Me._frmIndizacionGeneral.actualizarDatosListView()

    End Sub


    Private Sub MaskedTextBox1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mtxtFEchainicio.Leave
        Dim fecha As Date
        Try
            If Not Me.mtxtFEchainicio.Text = "  /  /" Then
                If IsDate(Me.mtxtFEchainicio.Text) Then
                    fecha = CDate(Me.mtxtFEchainicio.Text)
                    If fecha.Year > Date.Now.Year Then
                        MessageBox.Show("La fecha introducida es del futuro!!!")
                        Me.mtxtFEchainicio.Mask = "00/00/0000"
                        Me.mtxtFEchainicio.Focus()
                        Exit Sub
                    End If
                    Me.mtxtFEchainicio.Mask = "00/00/0000"
                    Me.mtxtFEchainicio.Text = Format(fecha, "dd/MM/yyyy")
                Else
                    MessageBox.Show("El formato de fecha no es correcto")
                    Me.mtxtFEchainicio.Mask = "00/00/0000"
                    Me.mtxtFEchainicio.Focus()
                    Exit Sub
                End If
                Me.BackColor = Nothing
            Else
                MessageBox.Show("Te has dejado la fecha en blanco")
                Me.mtxtFEchainicio.Mask = "00/00/0000"
                Me.mtxtFEchainicio.Focus()
                Exit Sub
            End If
            Me.mtxtfechaTerminio.Focus()

        Catch ex As Exception
            MessageBox.Show("Algo has introducido mal")
        End Try
    End Sub

    Private Sub mtxtfechaTerminio_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mtxtfechaTerminio.Leave
        Dim fecha As Date
        Dim fechainicio As Date

        If Not Me.mtxtfechaTerminio.Text = "  /  /" Then
            If IsDate(Me.mtxtfechaTerminio.Text) Then
                fecha = CDate(Me.mtxtfechaTerminio.Text)
                fechainicio = CDate(Me.mtxtFEchainicio.Text)
                If fecha.Year > Date.Now.Year Then
                    MessageBox.Show("La fecha introducida es del futuro!!!")
                    Me.mtxtfechaTerminio.Mask = "00/00/0000"
                    Me.mtxtfechaTerminio.Focus()
                    Exit Sub
                End If

                If DateDiff(DateInterval.Day, fechainicio, fecha) < 0 Then
                    MessageBox.Show("La fecha de alta es menor que la del ingreso")
                    Me.mtxtfechaTerminio.Mask = "00/00/0000"
                    Me.mtxtfechaTerminio.Focus()
                    Exit Sub
                End If

                Me.mtxtfechaTerminio.Mask = "00/00/0000"
                Me.mtxtfechaTerminio.Text = Format(fecha, "dd/MM/yyyy")
            Else
                MessageBox.Show("El formato de fecha no es correcto")
                Me.mtxtfechaTerminio.Mask = "00/00/0000"
                Me.mtxtfechaTerminio.Focus()
                Exit Sub
            End If
            Me.BackColor = Nothing
        Else
            MessageBox.Show("Te has dejado la fecha en blanco")
            Me.mtxtfechaTerminio.Mask = "00/00/0000"
            Me.mtxtfechaTerminio.Focus()
            Exit Sub
        End If

    End Sub

    Private Sub mtxtFEchainicio_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mtxtFEchainicio.GotFocus
        Me.mtxtFEchainicio.SelectAll()
    End Sub


    Private Sub mtxtfechaTerminio_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mtxtfechaTerminio.GotFocus
        Me.mtxtfechaTerminio.SelectAll()
    End Sub

    'Private Sub mtxtfechaDia_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mTxtFechaDia.GotFocus
    '    If Me.mtxtFEchainicio.Text <> Me.mTxtFechaDia.Text Then
    '        Me.mTxtFechaDia.Text = Me.mtxtFEchainicio.Text
    '    End If
    'Me.mTxtFechaDia.SelectAll()
    'End Sub

    Private Sub ObtenerEpisodios()

        Try

            Dim idatosSip As IdatosSIPSQL
            idatosSip = New ClsDAtosSipSQL
            Dim sip As New ClsSIP(0)

            Dim idServicioGEDSA As String = ""
            Dim idServicio As String = ""
            Dim litServicio As String = ""

            Dim datosEpisodiosCex As DataTable
            Dim item As ListViewItem

            'inicializamos conjunto resultados
            Me.ListView1.Items.Clear()

            'Localiza servicio de GECI para mostrar en caso de episodio EPX
            If listaHistoriasServicio_GECI.Count > 0 Then
                For Each elemento As String In listaHistoriasServicio_GECI
                    If elemento.Contains(txtNumHistoria.Text.ToString.Trim & "#") Then

                        idServicio = Split(elemento, "#")(1).ToString.Trim
                        idServicioGEDSA = Split(elemento, "#")(2).ToString.Trim
                        litServicio = Split(elemento, "#")(3).ToString.Trim

                        Exit For

                    End If
                Next
            End If
            '************************************************************

            'Añade episodio genérico cuando no sabemos a donde va
            item = New ListViewItem
            item.Text = "EP"
            item.SubItems.Add("EPX").Name = "codigoActo"
            item.SubItems.Add("EPX").Name = "Episodio"
            ''item.SubItems.Add("").Name = "litservicio"
            item.SubItems.Add(litServicio).Name = "litservicio"
            item.SubItems.Add(mTxtFechaDia.Text).Name = "FechaInicio"
            item.SubItems.Add(mTxtFechaDia.Text).Name = "FechaFin"
            item.SubItems.Add("").Name = "servicio"
            ''item.SubItems.Add("").Name = "idServicio"
            item.SubItems.Add(idServicio).Name = "idServicio"
            ''item.SubItems.Add("").Name = "servicioGEDSA"
            item.SubItems.Add(idServicioGEDSA).Name = "servicioGEDSA"

            Me.ListView1.Items.Add(item)
            '****************************************************
            Dim codigoDocHospital As String = ""
            If Not IsNothing(Me.cmb_codigo_doc.SelectedItem) Then
                codigoDocHospital = CType(Me.cmb_codigo_doc.SelectedItem, modelo.ClsTipoDocumento).definicion
            End If

            datosEpisodiosCex = idatosSip.obtenerEpisodiosCIP(frmContenedorMDI.oLote._idlote, Me.txtCIP.Text, Me.mTxtFechaDia.Text, codigoDocHospital, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto)

            For Each registro As DataRow In datosEpisodiosCex.Rows
                With registro
                    item = New ListViewItem
                    item.Text = IIf(IsDBNull(.Item("tipoActo")), "", .Item("tipoActo"))
                    item.SubItems.Add(IIf(IsDBNull(.Item("codigoActo")), "", .Item("codigoActo"))).name = "codigoActo"
                    item.SubItems.Add(IIf(IsDBNull(.Item("episodio")), "", .Item("episodio"))).name = "Episodio"
                    item.SubItems.Add(IIf(IsDBNull(.Item("litServicio")), "", .Item("litServicio"))).name = "litservicio"
                    If IsDBNull(.Item("fechainicio")) Then
                        item.SubItems.Add("").Name = "fechainicio"
                    Else
                        item.SubItems.Add(IIf(IsDBNull(.Item("fechainicio")), "01/01/1900", Format(.Item("fechainicio"), "dd/MM/yyyy"))).name = "fechainicio"
                    End If
                    If IsDBNull(.Item("fechafin")) Then
                        'Si es nula la fecha fin, pone la del documento
                        item.SubItems.Add(mTxtFechaDia.Text).Name = "FechaFin"

                        'Si es nula la fechafin, pone la fecha inicio
                        ''If IsDBNull(.Item("fechainicio")) Then
                        ''    item.SubItems.Add("").Name = "FechaFin"
                        ''Else
                        ''    item.SubItems.Add(.Item("fechainicio")).Name = "FechaFin"
                        ''End If
                    Else
                        item.SubItems.Add(IIf(IsDBNull(.Item("fechafin")), "01/01/1900", Format(.Item("fechafin"), "dd/MM/yyyy"))).name = "FechaFin"
                    End If
                    item.SubItems.Add(IIf(IsDBNull(.Item("servicio")), "", .Item("servicio"))).name = "servicio"
                    item.SubItems.Add(IIf(IsDBNull(.Item("area")), "", .Item("area"))).name = "area"
                    item.SubItems.Add(IIf(IsDBNull(.Item("idservicio")), "", .Item("idservicio"))).name = "idservicio"
                    item.SubItems.Add(IIf(IsDBNull(.Item("numhistoria")), 0, .Item("numhistoria"))).name = "numHistoria"
                    item.SubItems.Add(IIf(IsDBNull(.Item("servicioGEDSA")), "", .Item("servicioGEDSA"))).name = "servicioGEDSA"

                End With

                Me.ListView1.Items.Add(item)

            Next

        Catch ex As Exception
            Me.txtServicio.Focus()
        End Try

    End Sub

    Private Sub ListView1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListView1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                If Not IsNothing(Me.ListView1.SelectedItems(0)) Then

                    cargaDatosAlSeleccionarEpisodio()

                    '''Me.txtNumicu.Text = Me.ListView1.SelectedItems(0).SubItems("codigoacto").Text
                    '''CambiarTipoActo(Me.ListView1.SelectedItems(0).Text)

                    '''Me.txtServicio.Text = Me.ListView1.SelectedItems(0).SubItems("idservicio").Text
                    '''CambiarServicio(txtServicio.Text)

                    '''Me.mtxtFEchainicio.Text = Me.ListView1.SelectedItems(0).SubItems("fechainicio").Text
                    '''Me.mtxtfechaTerminio.Text = Me.ListView1.SelectedItems(0).SubItems("fechaFin").Text

                    '''Me.txtCodigoDoc.Focus()
                    '''Me.txtCodigoDoc.SelectAll()
                End If

            Catch ex As Exception
                Debug.Print("Error al leer los datos del list view ")
            End Try
        End If

    End Sub


    Private Sub ListView1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.Leave
        ''Me.txtServicio.Focus()
    End Sub

    Private Sub actualizarDatos(ByVal fechaDigitalizacion As String)
        'hay que calcular los episodios que estan en el rango de fechas
        'tienes que ver todas las posibilidades 

        'si no tienes ningun episodio, 998 y lo pasas al servicio que 
        'la vida es asi

        'si solo obtienes un episodio en este caso rellenas y lo pasas a 
        'tipo de documentos 

        'si tienes mas de uno lo metes en el listado y le pasas el foco al datagrid 
        Me.ListView1.Items.Clear()

        If GetDocumentoActual.SubItems("indizada").Text = 1 Then Exit Sub

        If SinEpisodio = 0 Then
            If Me.txtCIP.Text.ToString.Trim <> "" Then
                ObtenerEpisodios() 'Esto va a cargar los episodios que nos encontremos en el listview
            End If

            Select Case Me.ListView1.Items.Count
                Case 0

                    Me.txtNumicu.Text = "EPX" 'no tiene episodio
                    Me.mtxtFEchainicio.Text = Me.mTxtFechaDia.Text
                    Me.mtxtfechaTerminio.Text = Me.mTxtFechaDia.Text
                    ''Me.cmbTipoActo.Text = ""
                    CambiarTipoActo("EP")

                    If txtServicio.Enabled Then
                        Me.txtServicio.Focus()
                        Me.txtServicio.SelectAll()
                    ElseIf txtCodigoDoc.Enabled Then
                        Me.txtCodigoDoc.Focus()
                        Me.txtCodigoDoc.SelectAll()
                    Else
                        Me.mTxtFechaDia.Focus()
                        Me.mTxtFechaDia.SelectAll()
                    End If
                    ''Me.txtNumHistoria.Focus()
                    ''Me.txtNumHistoria.SelectAll()

                Case 1
                    Try
                        If Not IsNothing(Me.ListView1.Items(0)) Then

                            Me.txtNumicu.Text = Me.ListView1.Items(0).SubItems("episodio").Text
                            CambiarTipoActo(cmbTipoActo.Text.Split(" - ")(0).ToString.Trim)

                            Me.txtServicio.Text = Me.ListView1.Items(0).SubItems("servicio").Text
                            '################# JGARIJO 21/10/2019 ########################
                            CambiarServicio(txtServicio.Text)
                            '#############################################################

                            Me.mtxtFEchainicio.Text = Me.ListView1.Items(0).SubItems("fechainicio").Text
                            Me.mtxtfechaTerminio.Text = Me.ListView1.Items(0).SubItems("fechaFin").Text
                            Me.lblservicio_descripcion.Text = Me.ListView1.Items(0).SubItems("servicio").Text.ToUpper

                            ' ''Me.txtICUOrion.Text = Me.ListView1.Items(0).SubItems("orion").Text
                            ''Me.ListView1.Refresh()
                            ''Me.ListView1.EnsureVisible(Me.ListView1.Items(0).Index)
                            'Me.txtCodigoDoc.Focus()
                            'Me.txtCodigoDoc.SelectAll()

                            If txtServicio.Enabled Then
                                Me.txtServicio.Focus()
                                Me.txtServicio.SelectAll()
                            ElseIf txtCodigoDoc.Enabled Then
                                Me.txtCodigoDoc.Focus()
                                Me.txtCodigoDoc.SelectAll()
                            Else
                                Me.mTxtFechaDia.Focus()
                                Me.mTxtFechaDia.SelectAll()
                            End If
                        End If

                    Catch ex As Exception
                        Debug.Print("Error al leer los datos del list view ")
                    End Try
                Case Is > 1
                    Me.ListView1.Focus()
                    Me.ListView1.Items(0).Selected = True
            End Select
        ElseIf SinEpisodio = 1 Then
            Me.mtxtFEchainicio.Text = Me.mTxtFechaDia.Text
            Me.mtxtfechaTerminio.Text = Me.mTxtFechaDia.Text
            Me.cmbTipoActo.Text = ""
            Me.txtNumicu.Text = ""
            SinEpisodio = 0
        End If

    End Sub



    Private Sub mTxtFechaDia_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mTxtFechaDia.Leave
        Dim fecha As Date

        If SinEpisodio = 0 Then
            Try
                If Not Me.mTxtFechaDia.Text = "  /  /" Then
                    If IsDate(Me.mTxtFechaDia.Text) Then
                        fecha = CDate(Me.mTxtFechaDia.Text)
                        If fecha.Year > Date.Now.Year Then
                            MessageBox.Show("La fecha introducida es del futuro!!!")
                            Me.mTxtFechaDia.Mask = "00/00/0000"
                            Me.mTxtFechaDia.Focus()
                            Me.mTxtFechaDia.SelectAll()
                            Exit Sub
                        End If
                        Me.mTxtFechaDia.Mask = "00/00/0000"
                        Me.mTxtFechaDia.Text = Format(fecha, "dd/MM/yyyy")
                    Else
                        MessageBox.Show("El formato de fecha no es correcto")
                        Me.mTxtFechaDia.Mask = "00/00/0000"
                        Me.mTxtFechaDia.Focus()
                        Me.mTxtFechaDia.SelectAll()
                        Exit Sub
                    End If
                    Me.BackColor = Nothing
                Else
                    'MessageBox.Show("Te has dejado la fecha en blanco")
                    Me.mTxtFechaDia.Mask = "00/00/0000"
                    Me.mTxtFechaDia.Focus()
                    Me.mTxtFechaDia.SelectAll()
                    Exit Sub
                End If
                ''actualizarDatos(Me.mTxtFechaDia.Text)

                ''Me.txtNumHistoria.Focus()
                ''Me.txtNumHistoria.SelectAll()
                Me.txtCodigoDoc.Focus()
                Me.txtCodigoDoc.SelectAll()

                'Me._frmIndizacionGeneral.escribirPierdeFocoFecha()
            Catch ex As Exception
                MessageBox.Show("Algo has introducido mal")
            End Try
        ElseIf SinEpisodio = 1 Then
            SinEpisodio = 0
            Try
                If Not Me.mTxtFechaDia.Text = "  /  /" Then
                    If IsDate(Me.mTxtFechaDia.Text) Then
                        fecha = CDate(Me.mTxtFechaDia.Text)
                        If fecha.Year > Date.Now.Year Then
                            MessageBox.Show("La fecha introducida es del futuro!!!")
                            Me.mTxtFechaDia.Mask = "00/00/0000"
                            Me.mTxtFechaDia.Focus()
                            Me.mTxtFechaDia.SelectAll()
                            Exit Sub
                        End If
                        Me.mTxtFechaDia.Mask = "00/00/0000"
                        Me.mTxtFechaDia.Text = Format(fecha, "dd/MM/yyyy")
                    Else
                        MessageBox.Show("El formato de fecha no es correcto")
                        Me.mTxtFechaDia.Mask = "00/00/0000"
                        Me.mTxtFechaDia.Focus()
                        Me.mTxtFechaDia.SelectAll()
                        Exit Sub
                    End If
                    Me.BackColor = Nothing
                Else
                    'MessageBox.Show("Te has dejado la fecha en blanco")
                    Me.mTxtFechaDia.Mask = "00/00/0000"
                    Me.mTxtFechaDia.Focus()
                    Me.mTxtFechaDia.SelectAll()
                    Exit Sub
                End If
                Me.mtxtFEchainicio.Text = Me.mTxtFechaDia.Text
                Me.mtxtfechaTerminio.Text = Me.mTxtFechaDia.Text
                'Me._frmIndizacionGeneral.escribirPierdeFocoFecha()
            Catch ex As Exception
                MessageBox.Show("Algo has introducido mal")
            End Try
        Else
            SinEpisodio = 0
            Try
                If Not Me.mTxtFechaDia.Text = "  /  /" Then
                    If IsDate(Me.mTxtFechaDia.Text) Then
                        fecha = CDate(Me.mTxtFechaDia.Text)
                        If fecha.Year > Date.Now.Year Then
                            MessageBox.Show("La fecha introducida es del futuro!!!")
                            Me.mTxtFechaDia.Mask = "00/00/0000"
                            Me.mTxtFechaDia.Focus()
                            Me.mTxtFechaDia.SelectAll()
                            Exit Sub
                        End If
                        Me.mTxtFechaDia.Mask = "00/00/0000"
                        Me.mTxtFechaDia.Text = Format(fecha, "dd/MM/yyyy")
                    Else
                        MessageBox.Show("El formato de fecha no es correcto")
                        Me.mTxtFechaDia.Mask = "00/00/0000"
                        Me.mTxtFechaDia.Focus()
                        Me.mTxtFechaDia.SelectAll()
                        Exit Sub
                    End If
                    Me.BackColor = Nothing
                Else
                    'MessageBox.Show("Te has dejado la fecha en blanco")
                    Me.mTxtFechaDia.Mask = "00/00/0000"
                    Me.mTxtFechaDia.Focus()
                    Me.mTxtFechaDia.SelectAll()
                    Exit Sub
                End If
                Me.mtxtFEchainicio.Text = Me.mTxtFechaDia.Text
                Me.mtxtfechaTerminio.Text = Me.mTxtFechaDia.Text
                'Me._frmIndizacionGeneral.escribirPierdeFocoFecha()
            Catch ex As Exception
                MessageBox.Show("Algo has introducido mal")
            End Try
        End If
    End Sub

    Private Sub ConInf_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConInf.CheckedChanged
        If ConInf.Checked = True Then
            UCSI.Checked = False
            SD.Checked = False
        End If
    End Sub

    Private Sub UCSI_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UCSI.CheckedChanged
        If UCSI.Checked = True Then
            ConInf.Checked = False
            SD.Checked = False
        End If
    End Sub

    Private Sub SD_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SD.CheckedChanged
        If SD.Checked = True Then
            ConInf.Checked = False
            UCSI.Checked = False
        End If
    End Sub


    Private Sub txtCodigoDoc_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigoDoc.Leave
        If txtCodigoDoc.Text.ToString.Trim() <> "" Then Me.cmb_codigo_doc.SelectedIndex = Me.cmb_codigo_doc.FindString(txtCodigoDoc.Text.ToString.Trim() & " - ")
        If Me.cmb_codigo_doc.SelectedIndex = -1 Then
            txtCodigoDoc.Text = ""
        End If
        Me._frmIndizacionGeneral.escribirPierdeFoco()
    End Sub

    Private Sub txtServicio_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtServicio.Leave
        If txtServicio.Text.ToString.Trim() <> "" Then Me.cmbServicios.SelectedIndex = Me.cmbServicios.FindString(txtServicio.Text.ToString.Trim() & " - ")
        If Me.cmbServicios.SelectedIndex = -1 Then
            txtServicio.Text = ""
        End If

        Me.txtCodigoDoc.Focus()
        Me.txtCodigoDoc.SelectAll()
    End Sub

    Private Sub txtCodigoDoc_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoDoc.KeyPress
        Try
            'If e.KeyChar = "m" Or e.KeyChar = "M" Then
            If e.KeyChar = "/" Then
                'Marca el registro como primero de la historia
                e.Handled = True
                Dim i As Integer = 0
                Dim EleSeleccionado As Integer = -1
                For i = 0 To (Me._frmIndizacionGeneral.ListView1.Items.Count - 1)
                    If Me._frmIndizacionGeneral.ListView1.Items(i).Selected Then
                        EleSeleccionado = i
                    End If
                Next
                If i > -1 Then
                    If Me._frmIndizacionGeneral.ListView1.Items(EleSeleccionado).SubItems("BarcodeDet").Text = "0" Then
                        Me._frmIndizacionGeneral.ListView1.Items(EleSeleccionado).SubItems("BarcodeDet").Text = "1"
                        Me._frmIndizacionGeneral.ListView1.Items(EleSeleccionado).SubItems("Primera").Text = "1"

                        Me._frmIndizacionGeneral.ListView1.Items(EleSeleccionado).Font = New Font(ListView1.Font, FontStyle.Bold)
                        Me._frmIndizacionGeneral.ListView1.Items(EleSeleccionado).ForeColor = Drawing.Color.DarkRed
                    Else
                        Me._frmIndizacionGeneral.ListView1.Items(EleSeleccionado).SubItems("BarcodeDet").Text = "0"
                        Me._frmIndizacionGeneral.ListView1.Items(EleSeleccionado).SubItems("Primera").Text = "0"

                        Me._frmIndizacionGeneral.ListView1.Items(EleSeleccionado).Font = New Font(ListView1.Font, FontStyle.Regular)
                        Me._frmIndizacionGeneral.ListView1.Items(EleSeleccionado).ForeColor = Drawing.Color.Black
                    End If
                End If

            ElseIf e.KeyChar = "º" Then
                e.Handled = True
                Me.mTxtFechaDia.Focus()
                Me.mTxtFechaDia.SelectAll()
                Exit Sub
                'ElseIf e.KeyChar = ChrW(Keys.Return) Then
                '    If IsNumeric(txtServicio.Text) = 0 Then
                '        e.Handled = True
                '        Dim conexion As SqlConnection = Nothing
                '        Dim Servicios As DataTable
                '        conexion = New SqlConnection("Data Source=ACUARIO;Initial Catalog=PRODUCCIONPESET2014;User ID=sa;password=sa2003#")
                '        Dim cmd As New SqlCommand
                '        Dim returnValue As Object

                '        cmd.CommandText = "select idservicio from servicios where descripcion like '" & txtServicio.Text & "%'"
                '        cmd.CommandType = CommandType.Text
                '        cmd.Connection = conexion
                '        conexion.Open()
                '        returnValue = cmd.ExecuteScalar()
                '        txtServicio.Text = returnValue
                '        cmbServicios.SelectedIndex = returnValue
                '        conexion.Close()
                '    End If
                '    Exit Sub

            ElseIf e.KeyChar = "E" Then
                'e.Handled = True
                'EliminarDocumento()
                'Exit Sub
                e.Handled = True
                Dim i As Integer = 0
                Dim EleSeleccionado As Integer = -1
                For i = 0 To (Me._frmIndizacionGeneral.ListView1.Items.Count - 1)
                    If Me._frmIndizacionGeneral.ListView1.Items(i).Selected Then
                        EleSeleccionado = i
                    End If
                Next
                If i > -1 Then
                    Me._frmIndizacionGeneral.ListView1.Items(EleSeleccionado).SubItems("eliminada").Text = "1"
                End If
                EliminarDocumento()
                Me._frmIndizacionGeneral.bajarAbajo()
                Exit Sub
            ElseIf e.KeyChar = "e" Then
                'e.Handled = True
                'EliminarDocumento()
                'Exit Sub
                e.Handled = True
                Dim i As Integer = 0
                Dim EleSeleccionado As Integer = -1
                For i = 0 To (Me._frmIndizacionGeneral.ListView1.Items.Count - 1)
                    If Me._frmIndizacionGeneral.ListView1.Items(i).Selected Then
                        EleSeleccionado = i
                    End If
                Next
                If i > -1 Then
                    Me._frmIndizacionGeneral.ListView1.Items(EleSeleccionado).SubItems("eliminada").Text = "1"
                End If
                EliminarDocumento()
                Me._frmIndizacionGeneral.bajarAbajo()
                Exit Sub
                ''ElseIf e.KeyChar = "W" Then
                ''    e.Handled = True
                ''    If ConInf.Checked = True Then
                ''        ConInf.Checked = False
                ''    Else
                ''        ConInf.Checked = True
                ''        UCSI.Checked = False
                ''        SD.Checked = False
                ''    End If
                ''    Exit Sub
                ''ElseIf e.KeyChar = "w" Then
                ''    e.Handled = True
                ''    If ConInf.Checked = True Then
                ''        ConInf.Checked = False
                ''    Else
                ''        ConInf.Checked = True
                ''        UCSI.Checked = False
                ''        SD.Checked = False
                ''    End If
                ''    Exit Sub
            ElseIf e.KeyChar = "t" Then
                e.Handled = True
                Dim i As Integer = 0
                Dim EleSeleccionado As Integer = -1
                For i = 0 To (Me._frmIndizacionGeneral.ListView1.Items.Count - 1)
                    If Me._frmIndizacionGeneral.ListView1.Items(i).Selected Then
                        EleSeleccionado = i
                    End If
                Next
                If i > -1 Then
                    Me._frmIndizacionGeneral.ListView1.Items(EleSeleccionado).SubItems("eliminada").Text = "0"
                End If
                DesEliminarDocumento()
                Me._frmIndizacionGeneral.bajarAbajo()
                Exit Sub
            ElseIf e.KeyChar = "T" Then
                e.Handled = True
                Dim i As Integer = 0
                Dim EleSeleccionado As Integer = -1
                For i = 0 To (Me._frmIndizacionGeneral.ListView1.Items.Count - 1)
                    If Me._frmIndizacionGeneral.ListView1.Items(i).Selected Then
                        EleSeleccionado = i
                    End If
                Next
                If i > -1 Then
                    Me._frmIndizacionGeneral.ListView1.Items(EleSeleccionado).SubItems("eliminada").Text = "0"
                End If
                DesEliminarDocumento()
                Me._frmIndizacionGeneral.bajarAbajo()
                Exit Sub
            ElseIf e.KeyChar = "r" Then
                e.Handled = True
                imagen_rota()
                Exit Sub
            ElseIf e.KeyChar = "R" Then
                e.Handled = True
                imagen_rota()
                Exit Sub
            ElseIf e.KeyChar = "*" Then
                If continua Then    'Esto lo hago porque cuando pulsabas rápido el *, se le iba la pinza al indice de la lista de documentos.

                    continua = False

                    Dim elementoanterior As ListViewItem

                    elementoanterior = _frmIndizacionGeneral.ListView1.Items(Me._frmIndizacionGeneral.indice - 1)

                    ''Me.mTxtFechaDia.Focus()

                    copiarDatos_Anterior(elementoanterior)

                    pegarDatos()
                    pulsaMas()

                    continua = True

                    e.Handled = True
                End If

                Exit Sub

            ElseIf e.KeyChar = "q" Then
                e.Handled = True
                '''Me.txtNumicu.Text = "998"
                Me.txtNumicu.Text = ""
                Me.txtServicio.Text = ""
                Me.mtxtFEchainicio.Text = Me.mTxtFechaDia.Text
                Me.mtxtfechaTerminio.Text = Me.mTxtFechaDia.Text
                CalcularEpi = 1
                Exit Sub
            ElseIf e.KeyChar = "Q" Then
                e.Handled = True
                ''Me.txtNumicu.Text = "998"
                Me.txtNumicu.Text = ""
                Me.txtServicio.Text = ""
                Me.mtxtFEchainicio.Text = Me.mTxtFechaDia.Text
                Me.mtxtfechaTerminio.Text = Me.mTxtFechaDia.Text
                CalcularEpi = 1
                Exit Sub
            ElseIf e.KeyChar = "a" Then
                e.Handled = True
                ''Me.txtNumicu.Text = "998"
                Me.txtNumicu.Text = ""
                Me.txtServicio.Text = "153"
                Me.mtxtFEchainicio.Text = Me.mTxtFechaDia.Text
                Me.mtxtfechaTerminio.Text = Me.mTxtFechaDia.Text
                CalcularEpi = 1
                Exit Sub
            ElseIf e.KeyChar = "A" Then
                e.Handled = True
                ''Me.txtNumicu.Text = "998"
                Me.txtNumicu.Text = ""
                Me.txtServicio.Text = "153"
                Me.mtxtFEchainicio.Text = Me.mTxtFechaDia.Text
                Me.mtxtfechaTerminio.Text = Me.mTxtFechaDia.Text
                CalcularEpi = 1
                Exit Sub
            ElseIf e.KeyChar = "s" Then
                e.Handled = True
                If UCSI.Checked = True Then
                    UCSI.Checked = False
                Else
                    UCSI.Checked = True
                    SD.Checked = False
                    ConInf.Checked = False
                End If
                Exit Sub
            ElseIf e.KeyChar = "S" Then
                e.Handled = True
                If UCSI.Checked = True Then
                    UCSI.Checked = False
                Else
                    UCSI.Checked = True
                    SD.Checked = False
                    ConInf.Checked = False
                End If
                Exit Sub
            ElseIf e.KeyChar = "d" Then
                e.Handled = True
                If SD.Checked = True Then
                    SD.Checked = False
                Else
                    SD.Checked = True
                    UCSI.Checked = False
                    ConInf.Checked = False
                End If
                Exit Sub
            ElseIf e.KeyChar = "D" Then
                e.Handled = True
                If SD.Checked = True Then
                    SD.Checked = False
                Else
                    SD.Checked = True
                    UCSI.Checked = False
                    ConInf.Checked = False
                End If
                Exit Sub
            ElseIf (e.KeyChar = "+") Then
                'e.Handled = True
                'Dim auxHistoriaAnterior As String = Me.txtNumHistoria.Text
                'Dim encontrado As Boolean = False

                'If Me.txtServicio.Text <> "" Then

                '    For Each tipodocumento As modelo.ClsTipoDocumento In Me.cmb_codigo_doc.Items

                '        If tipodocumento.codigo = Me.txtCodigoDoc.Text Then
                '            encontrado = True
                '            'esto no le da el foco a otro componente por lo que no hay que 
                '            'gestionarlo
                '            Me.cmb_codigo_doc.SelectedItem = tipodocumento
                '            Exit For
                '        ElseIf Me.txtCodigoDoc.Text = "0" Then
                '            encontrado = True
                '            'esto no le da el foco a otro componente por lo que no hay que 
                '            'gestionarlo
                '            Me.cmb_codigo_doc.SelectedItem = tipodocumento
                '            Exit For
                '        End If
                '    Next

                '    If Not encontrado Then

                '        MessageBox.Show("El tipo de documento no es valido")
                '        Me.txtCodigoDoc.Text = ""
                '        Me.txtCodigoDoc.Focus()
                '        Me.txtCodigoDoc.SelectAll()
                '    Else
                '        Me._frmIndizacionGeneral.bajarAbajo()
                '        If GetDocumentoActual.SubItems("indizado").Text = 1 Then
                '            Me.txtServicio.Focus()
                '        Else
                '            'actualizarDatos(Me.DateTimePicker1.Text)

                '            actualizarDatos(Me.mTxtFechaDia.Text)
                '            If auxHistoriaAnterior <> Me.txtNumHistoria.Text Then
                '                Me._frmIndizacionGeneral.escribirCambioHistoria(auxHistoriaAnterior, Me.txtNumHistoria.Text)
                '                Me.pnlCambio.BackColor = Color.Red
                '                Me.mTxtFechaDia.Focus()
                '                Me.mTxtFechaDia.SelectAll()

                '                Debug.Print("hemos llegado hasta aqui ")
                '            Else
                '                Me._frmIndizacionGeneral.escribirHistoria(auxHistoriaAnterior, Me.txtNumHistoria.Text)
                '                Me.pnlCambio.BackColor = Color.Lime
                '                Me.txtServicio.Focus()
                '                Me.txtServicio.SelectAll()
                '            End If
                '            'End If
                '        End If

                '        Me.ListView1.Items.Clear()

                '        If Me.pnlCambio.BackColor = Color.Lime Then
                '            Me.txtServicio.Focus()
                '            Me.txtServicio.SelectAll()
                '        Else
                '            Me.mTxtFechaDia.Focus()
                '            Me.mTxtFechaDia.SelectAll()
                '        End If

                '        'Nuevo
                '        Me.mTxtFechaDia.Focus()
                '        Me.mTxtFechaDia.SelectAll()
                '    End If
                'End If
                e.Handled = True

                Dim ValorTipoDoc As String = ""
                Dim ValorServicio As String = ""
                Dim ValorFecha As String = ""
                Dim ValorFechaINI As String = ""
                Dim ValorFechaFIN As String = ""
                Dim ValorICU As String = ""


                ValorTipoDoc = Me.txtCodigoDoc.Text
                ValorServicio = Me.txtServicio.Text
                ValorFecha = Me.mTxtFechaDia.Text
                ValorFechaINI = Me.mtxtFEchainicio.Text
                ValorFechaFIN = Me.mtxtfechaTerminio.Text
                ValorICU = Me.txtNumicu.Text

                PasarASiguiente = True

                Dim auxHistoriaAnterior As String = Me.txtNumHistoria.Text
                Dim encontrado As Boolean = False

                If Me.txtCodigoDoc.Text <> "" Then

                    For Each codigoservicio As modelo.ClsServicio In Me.cmbServicios.Items

                        If codigoservicio._idservicio = Me.txtServicio.Text Then
                            encontrado = True
                            'esto no le da el foco a otro componente por lo que no hay que 
                            'gestionarlo
                            Me.cmbServicios.SelectedItem = codigoservicio
                            Exit For
                        End If
                    Next

                    If Not encontrado Then
                        MessageBox.Show("El codido de servicio no es valido")
                        Me.txtServicio.Focus()
                        Me.txtServicio.SelectAll()
                        Exit Sub
                    End If

                    encontrado = False

                    For Each tipodocumento As modelo.ClsTipoDocumento In Me.cmb_codigo_doc.Items

                        If tipodocumento.codigo = Me.txtCodigoDoc.Text Then
                            encontrado = True
                            'esto no le da el foco a otro componente por lo que no hay que 
                            'gestionarlo
                            Me.cmb_codigo_doc.SelectedItem = tipodocumento
                            Exit For
                        End If
                    Next

                    If Not encontrado Then
                        MessageBox.Show("El tipo de documento no es valido")
                        'Me.txtCodigoDoc.Text = ""
                        Me.txtCodigoDoc.Focus()
                        Me.txtCodigoDoc.SelectAll()
                    Else

                        '############# JGARIJO 11/11/2019 #################
                        'Modificacion para evitar que al pulsar la tecla + en este campo
                        'si el lote todavia no ha sido cerrado no es necesario que entren en modo de edicion
                        'y que las pulsaciones al + son para navegar, aunque se guarde el registro como indizado = 1

                        If LoteYaCerrado = True Then
                            'Sabemos que es un lote que se cerró y por lo tanto para cambiar valores se debe entrar en modo de edicion
                            If GetDocumentoActual.SubItems("indizadA").Text = 1 And ModoEdicion = False Then
                                MsgBox("No es posible modificar un registro ya indizado sin entrar en Modo Edicion")
                                Exit Sub
                            End If
                        End If

                        Dim i As Integer = 0
                        Dim EleSeleccionado As Integer = 0

                        Me._frmIndizacionGeneral.bajarAbajo()

                        If GetDocumentoActual.SubItems("indizada").Text = 1 Then
                            Me.txtCodigoDoc.Focus()
                        Else
                            'actualizarDatos(Me.DateTimePicker1.Text)
                            actualizarDatos(Me.mTxtFechaDia.Text)
                            If auxHistoriaAnterior <> Me.txtNumHistoria.Text Then
                                Me._frmIndizacionGeneral.escribirCambioHistoria(auxHistoriaAnterior, Me.txtNumHistoria.Text)
                                Me.pnlCambio.BackColor = Color.Red
                                Me.txtCodigoDoc.Focus()
                                Me.txtCodigoDoc.SelectAll()
                            Else
                                Me._frmIndizacionGeneral.escribirHistoria(auxHistoriaAnterior, Me.txtNumHistoria.Text)
                                Me.pnlCambio.BackColor = Color.Lime
                                Me.txtCodigoDoc.Focus()
                                Me.txtCodigoDoc.SelectAll()
                            End If
                        End If

                    End If
                Else
                    Exit Sub

                End If

                Me.ListView1.Items.Clear()

                'frmIndizacionGeneral.lblModoEdicion.Visible = False
                'frmIndizacionGeneral.Button1.Visible = True

                If Me.pnlCambio.BackColor = Color.Lime Then
                    Me.txtCodigoDoc.Focus()
                    Me.txtCodigoDoc.SelectAll()
                Else
                    Me.txtCodigoDoc.Focus()
                    Me.txtCodigoDoc.SelectAll()
                End If

                'Nuevo
                If GetDocumentoActual.SubItems("indizada").Text <> 1 Then
                    Me.txtCodigoDoc.Text = ValorTipoDoc
                    Me.txtServicio.Text = ValorServicio
                    Me.mTxtFechaDia.Text = ValorFecha
                    Me.mtxtFEchainicio.Text = ValorFechaINI
                    Me.mtxtfechaTerminio.Text = ValorFechaFIN
                    Me.txtNumicu.Text = ValorICU
                End If

                Me.txtCodigoDoc.Focus()
                Me.txtCodigoDoc.SelectAll()
            ElseIf (e.KeyChar = "-") Then
                e.Handled = True
                Me.mtxtFEchainicio.Text = Me.mTxtFechaDia.Text
                Me._frmIndizacionGeneral.subirArriba()
            Else
                CambiarTipoDocumento(e.KeyChar)
                Return
            End If

            'If My.Settings.ModoDepuracion = "True" Then
            '    If Not IsNothing(GetDocumentoActual) Then
            '        Me.RichTextBox1.Visible = True
            '        Me.RichTextBox1.Text = MostrarInformacionElementoLista(GetDocumentoActual)
            '    End If
            'End If

        Catch ex As Exception
            MessageBox.Show("Error al guardar el dato")
        End Try
    End Sub

    Public Sub CambiarServicio(ByVal Servicio As String)
        CambioComboServicio = False
        Dim encontrado As Boolean = False

        If Servicio.ToString.Trim <> "" Then
            If IsNumeric(Servicio) Then

                For Each Serv As modelo.ClsServicio In Me.cmbServicios.Items

                    'If Serv._idservicio = Me.txtServicio.Text & Servicio Then
                    'If Serv._idservicio = Me.txtServicio.Text Then
                    If Serv._idservicio = Servicio Then
                        encontrado = True
                        'esto no le da el foco a otro componente por lo que no hay que 
                        'gestionarlo
                        Me.cmbServicios.SelectedItem = Serv
                        Return
                        Exit For
                    End If
                Next
            Else
                For Each Serv As modelo.ClsServicio In Me.cmbServicios.Items
                    If CStr(Serv._idservicio) = Me.txtServicio.Text Then
                        encontrado = True
                        'esto no le da el foco a otro componente por lo que no hay que 
                        'gestionarlo
                        Me.cmbServicios.SelectedItem = Serv
                        Return
                        Exit For
                    End If
                Next
            End If

            If Not encontrado Then

            End If
            CambioComboServicio = True
        End If
    End Sub

    Public Sub CambiarServicioHospital(ByVal ServicioHospital As String)
        CambioComboServicio = False
        Dim encontrado As Boolean = False

        If SERVICIO.ToString.Trim <> "" Then
            If IsNumeric(SERVICIO) Then

                For Each Serv As modelo.ClsServicio In Me.cmbServicios.Items

                    'If Serv._idservicio = Me.txtServicio.Text & Servicio Then
                    'If Serv._idservicio = Me.txtServicio.Text Then
                    If Serv._idservicioHospital = ServicioHospital Then
                        encontrado = True
                        'esto no le da el foco a otro componente por lo que no hay que 
                        'gestionarlo
                        Me.cmbServicios.SelectedItem = Serv
                        Return
                        Exit For
                    End If
                Next
            Else
                For Each Serv As modelo.ClsServicio In Me.cmbServicios.Items
                    If CStr(Serv._idservicioHospital) = ServicioHospital Then
                        encontrado = True
                        'esto no le da el foco a otro componente por lo que no hay que 
                        'gestionarlo
                        Me.cmbServicios.SelectedItem = Serv
                        Return
                        Exit For
                    End If
                Next
            End If

            If Not encontrado Then

            End If
            CambioComboServicio = True
        End If
    End Sub

    Public Sub CambiarTipoDocumento(ByVal Tipo As String)
        CambioComboDocumento = False
        Dim encontrado As Boolean = False

        Try

            If Tipo.ToString.Trim <> "" Then
                If IsNumeric(Tipo) Then

                    For Each tipodocumento As modelo.ClsTipoDocumento In Me.cmb_codigo_doc.Items
                        'If tipodocumento.codigo = Me.txtCodigoDoc.Text & Tipo Then
                        If Me.txtCodigoDoc.Text.Trim <> "" Then

                            'If tipodocumento.codigo = CDbl(Me.txtCodigoDoc.Text) Then
                            If tipodocumento.codigo = CDbl(Tipo) Then
                                encontrado = True
                                'esto no le da el foco a otro componente por lo que no hay que 
                                'gestionarlo
                                Me.cmb_codigo_doc.SelectedItem = tipodocumento
                                Return
                                Exit For
                            End If
                        End If
                    Next
                Else
                    For Each tipodocumento As modelo.ClsTipoDocumento In Me.cmb_codigo_doc.Items
                        If CStr(tipodocumento.codigo) = Me.txtCodigoDoc.Text Then
                            encontrado = True
                            'esto no le da el foco a otro componente por lo que no hay que 
                            'gestionarlo
                            Me.cmb_codigo_doc.SelectedItem = tipodocumento
                            Return
                            Exit For
                        End If
                    Next
                End If

                If Not encontrado Then

                End If
                CambioComboDocumento = True
            End If

        Catch ex As Exception
            MessageBox.Show("Algo has introducido mal")
        End Try

    End Sub

    Public Sub CambiarTipoActo(ByVal TipoActo As String)
        CambioComboTipoActo = False
        Dim encontrado As Boolean = False

        If TipoActo.ToString.Trim <> "" Then
            For Each acto As modelo.ClsTipoActo In Me.cmbTipoActo.Items
                If CStr(acto._codActo) = TipoActo Then
                    encontrado = True
                    Me.cmbTipoActo.SelectedItem = acto
                    Return
                    Exit For
                End If
            Next
            ''End If

            If Not encontrado Then

            End If
            CambioComboTipoActo = True
        End If
    End Sub
    Private Sub txtCodigoDoc_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigoDoc.TextChanged
        CambiarTipoDocumento(txtCodigoDoc.Text)
    End Sub

    Private Sub txtServicio_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtServicio.TextChanged
        CambiarServicio(txtServicio.Text)
    End Sub

    Private Sub TxtNumHistoria_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNumHistoria.KeyPress
        Try
            ''If e.KeyChar = "d" Or e.KeyChar = "D" Then
            ''    'Se posiciona en el campo DNI
            ''    e.Handled = True
            ''    Me.txtDNI.Focus()
            ''    Me.txtDNI.SelectAll()
            ''    Exit Sub

            ''ElseIf e.KeyChar = "c" Or e.KeyChar = "C" Then
            ''    'Se posiciona en el campo CIP
            ''    e.Handled = True
            ''    Me.txtCIP.Focus()
            ''    Me.txtCIP.SelectAll()
            ''    Exit Sub

            ''ElseIf e.KeyChar = "n" Or e.KeyChar = "N" Then
            ''    'Se posiciona en el campo Nombre Paciente
            ''    e.Handled = True
            ''    Me.txtPaciente.Focus()
            ''    Me.txtPaciente.SelectAll()
            ''    Exit Sub

            ''End If

        Catch ex As Exception
            MessageBox.Show("Error:" & ex.Message)
        End Try

    End Sub

    Private Sub TxtDNI_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDNI.KeyPress
        Try
            ''If e.KeyChar = "n" Or e.KeyChar = "N" Then
            ''    'Se posiciona en el campo NHC
            ''    e.Handled = True
            ''    Me.txtNumHistoria.Focus()
            ''    Me.txtNumHistoria.SelectAll()
            ''    Exit Sub

            ''ElseIf e.KeyChar = "c" Or e.KeyChar = "C" Then
            ''    'Se posiciona en el campo CIP
            ''    e.Handled = True
            ''    Me.txtCIP.Focus()
            ''    Me.txtCIP.SelectAll()
            ''    Exit Sub

            ''ElseIf e.KeyChar = "n" Or e.KeyChar = "N" Then
            ''    'Se posiciona en el campo Nombre Paciente
            ''    e.Handled = True
            ''    Me.txtPaciente.Focus()
            ''    Me.txtPaciente.SelectAll()
            ''    Exit Sub

            ''End If

        Catch ex As Exception
            MessageBox.Show("Error:" & ex.Message)
        End Try
    End Sub

    Private Sub TxtCIP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCIP.KeyPress
        Try
            ''If e.KeyChar = "n" Or e.KeyChar = "N" Then
            ''    'Se posiciona en el campo NHC
            ''    e.Handled = True
            ''    Me.txtNumHistoria.Focus()
            ''    Me.txtNumHistoria.SelectAll()
            ''    Exit Sub

            ''ElseIf e.KeyChar = "d" Or e.KeyChar = "D" Then
            ''    'Se posiciona en el campo DNI
            ''    e.Handled = True
            ''    Me.txtDNI.Focus()
            ''    Me.txtDNI.SelectAll()
            ''    Exit Sub

            ''ElseIf e.KeyChar = "n" Or e.KeyChar = "N" Then
            ''    'Se posiciona en el campo Nombre Paciente
            ''    e.Handled = True
            ''    Me.txtPaciente.Focus()
            ''    Me.txtPaciente.SelectAll()
            ''    Exit Sub

            ''End If

        Catch ex As Exception
            MessageBox.Show("Error:" & ex.Message)
        End Try
    End Sub

    Private Sub TxtPaciente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPaciente.KeyPress
        Try
            ''If e.KeyChar = "n" Or e.KeyChar = "N" Then
            ''    'Se posiciona en el campo NHC
            ''    e.Handled = True
            ''    Me.txtNumHistoria.Focus()
            ''    Me.txtNumHistoria.SelectAll()
            ''    Exit Sub

            ''ElseIf e.KeyChar = "d" Or e.KeyChar = "D" Then
            ''    'Se posiciona en el campo DNI
            ''    e.Handled = True
            ''    Me.txtDNI.Focus()
            ''    Me.txtDNI.SelectAll()
            ''    Exit Sub

            ''ElseIf e.KeyChar = "c" Or e.KeyChar = "C" Then
            ''    'Se posiciona en el campo Nombre CIP
            ''    e.Handled = True
            ''    Me.txtCIP.Focus()
            ''    Me.txtCIP.SelectAll()
            ''    Exit Sub

            ''Else
            ''If e.KeyChar = "/" Then
            ''    e.Handled = True
            ''    If lvwPacientes.Visible Then
            ''        lvwPacientes.Visible = False
            ''    Else
            ''        lvwPacientes.Visible = True

            ''        'Carga lista pacientes
            ''        inicializarListaPacientes("", "")
            ''        '*********************
            ''        If lvwPacientes.Items.Count > 0 Then
            ''            Me.lvwPacientes.Refresh()
            ''            Me.lvwPacientes.EnsureVisible(Me.lvwPacientes.Items(0).Index)

            ''            lvwPacientes.Focus()
            ''        ElseIf lvwPacientes.Items.Count = 1 Then
            ''            cargaCamposPaciente()
            ''        End If

            ''    End If
            ''    Exit Sub
            ''End If

        Catch ex As Exception
            MessageBox.Show("Error:" & ex.Message)
        End Try
    End Sub

    Public Sub inicializarListaPacientes(ByVal nhc As String, ByVal cip As String, ByVal nombre As String, ByVal dni As String)
        Dim fila As ListViewItem
        Dim lsSql As String = ""

        Try
            lvwPacientes.Items.Clear()

            Me.DNI = New System.Windows.Forms.ColumnHeader
            Me.HISTORIA = New System.Windows.Forms.ColumnHeader
            Me.NOMBRE = New System.Windows.Forms.ColumnHeader
            Me.CIP = New System.Windows.Forms.ColumnHeader

            Me.lvwPacientes.Columns.Clear()
            Me.lvwPacientes.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.HISTORIA, Me.NOMBRE, Me.DNI, Me.CIP})
            Me.lvwPacientes.FullRowSelect = True
            Me.lvwPacientes.UseCompatibleStateImageBehavior = False
            Me.lvwPacientes.View = System.Windows.Forms.View.Details
            Me.lvwPacientes.View = System.Windows.Forms.View.Details
            Me.lvwPacientes.View = System.Windows.Forms.View.Details

            Me.DNI.Text = "HISTORIA"
            Me.DNI.Width = 60

            Me.NOMBRE.Text = "Nombre"
            Me.NOMBRE.Width = 200

            Me.DNI.Text = "DNI"
            Me.DNI.Width = 60

            Me.CIP.Text = "CIP"
            Me.CIP.Width = 0

            If nhc.ToString.Trim = "" And cip.ToString.Trim = "" And nombre.ToString.Trim <> "" Then
                If nombre.Contains("-") Then
                    lsSql = "SELECT * FROM FIP WHERE Apellido1 LIKE '%" & nombre.Split("-")(0).ToString.Trim & "%' AND Apellido2 LIKE '%" & nombre.Split("-")(1).ToString.Trim & "%' ORDER BY Apellido1, Apellido2, Nombre"
                Else
                    lsSql = "SELECT * FROM FIP WHERE Nombre LIKE '%" & txtPaciente.Text.ToString.Trim & "%' OR Apellido1 LIKE '%" & txtPaciente.Text.ToString.Trim & "%' OR Apellido2 LIKE '%" & txtPaciente.Text.ToString.Trim & "%' ORDER BY Apellido1, Apellido2, Nombre"
                End If

            ElseIf nhc.ToString.Trim <> "" Then
                lsSql = "SELECT * FROM FIP WHERE numHistoria=" & Convert.ToInt32(nhc)
            ElseIf cip.ToString.Trim <> "" Then
                lsSql = "SELECT * FROM FIP WHERE CIP='" & cip & "'"
            ElseIf dni.ToString.Trim <> "" Then
                lsSql = "SELECT * FROM FIP WHERE DNI='" & dni & "'"
            End If

            For Each reg As DataRow In datos.ejecutarSQLDirectaTable(lsSql, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto).Rows
                fila = New ListViewItem(reg.Item("numHistoria").ToString)

                With fila
                    fila.SubItems.Add(reg.Item("Apellido1").ToString & " " & reg.Item("Apellido2").ToString & ", " & reg.Item("Nombre").ToString).Name = "Nombre"
                    fila.SubItems.Add(reg.Item("CIP").ToString).Name = "CIP"
                    fila.SubItems.Add(reg.Item("DNI").ToString).Name = "DNI"

                End With
                Me.lvwPacientes.Items.Add(fila)
            Next


        Catch ex As Exception

        End Try

    End Sub

    Private Function cargaCamposPaciente(ByVal indice As Integer) As Boolean

        Dim resultado As Boolean = False

        If lvwPacientes.Items.Count > 0 Then

            txtNumHistoria.Text = lvwPacientes.Items(indice).Text

            If frmIndizacionGeneral.listaHistoriasGECI.Count > 0 Then
                If frmIndizacionGeneral.listaHistoriasGECI.FindIndex(Function(numHistoria)
                                                                         Return (numHistoria = Convert.ToInt32(txtNumHistoria.Text))
                                                                     End Function) > -1 Then
                    resultado = True

                End If
            Else

                resultado = True

            End If

            If resultado Then
                txtDNI.Text = lvwPacientes.Items(indice).SubItems("DNI").Text
                txtCIP.Text = lvwPacientes.Items(indice).SubItems("CIP").Text
                txtPaciente.Text = lvwPacientes.Items(indice).SubItems("Nombre").Text
            End If
        End If

        cargaCamposPaciente = resultado

    End Function

    Private Sub LvwPacientes_KeyPress(sender As Object, e As KeyPressEventArgs) Handles lvwPacientes.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If cargaCamposPaciente(lvwPacientes.SelectedItems(0).Index) Then
                If Me.txtCIP.Text.ToString.Trim <> "" Then
                    ObtenerEpisodios() 'Esto va a cargar los episodios que nos encontremos en el listview
                End If
                If Me.ListView1.Items.Count = 0 Then
                    cmbTipoActo.Focus()
                Else
                    Me.ListView1.Focus()
                End If
            Else
                MessageBox.Show("No existe el número de historia " & txtNumHistoria.Text.ToString.Trim & " en GECI.", "Historia no válida", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub LvwPacientes_DoubleClick(sender As Object, e As EventArgs) Handles lvwPacientes.DoubleClick
        If cargaCamposPaciente(lvwPacientes.SelectedItems(0).Index) Then
            If Me.txtCIP.Text.ToString.Trim <> "" Then
                ObtenerEpisodios() 'Esto va a cargar los episodios que nos encontremos en el listview
            End If
            If Me.ListView1.Items.Count = 0 Then
                cmbTipoActo.Focus()
            Else
                Me.ListView1.Focus()
            End If
        Else
            MessageBox.Show("No existe el número de historia " & txtNumHistoria.Text.ToString.Trim & " en GECI.", "Historia no válida", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim i As Integer = 0

        Dim ItemSel_idLote As String = ""
        Dim ItemSel_pagina As String = ""
        Dim ItemSel_nomArchivoTIF As String = ""
        Dim ItemSel_numHistoria As String = ""
        Dim ItemSel_tipoDocumento As String = ""
        Dim ItemSel_fechaDocumento As String = ""
        Dim ItemSel_fechainicio As String = ""
        Dim ItemSel_fechaTermino As String = ""
        Dim ItemSel_codservicioPAED As String = ""
        ''Dim ItemSel_TipoEpisodioPAED As String = ""
        Dim ItemSel_Numicu As String = ""
        Dim ItemSel_Incidencia As String = ""
        Dim ItemSel_vinculada As String = ""
        Dim ItemSel_Indizado As String = ""
        Dim ItemSel_Eliminada As String = ""
        Dim ItemSel_Paciente As String = ""
        Dim ItemSel_Dni As String = ""
        Dim ItemSel_Cip As String = ""
        Dim ItemSel_TipoActo As String = ""

        ''Dim ItemSel_nombre As String = ""
        ''Dim ItemSel_apellido1 As String = ""
        ''Dim ItemSel_apellido2 As String = ""
        Dim ItemSel_servicio As String = ""

        Dim cadenaSQL As String = ""

        Dim EleSeleccionado As Integer = -1

        For i = 0 To frmIndizacionGeneral.ListView1.Items.Count - 1
            ''If frmIndizacionGeneral.ListView1.Items(i).Selected = True Then
            If frmIndizacionGeneral.ListView1.Items(i).SubItems("pagina").Text.ToString.Trim = lblpagina.Text.ToString.Trim Then
                EleSeleccionado = i
                Exit For
            End If
        Next

        If EleSeleccionado < "0" Then
            MsgBox("Debe seleccionar un elemento antes de editarlo")
        Else

            frmIndizacionGeneral.indice = EleSeleccionado
            'MsgBox("Indice seleccionado: " + CStr(EleSeleccionado))

            ItemSel_idLote = frmIndizacionGeneral.ListView1.Items(EleSeleccionado).SubItems("idLote").Text
            ItemSel_pagina = frmIndizacionGeneral.ListView1.Items(EleSeleccionado).SubItems("pagina").Text
            ItemSel_nomArchivoTIF = frmIndizacionGeneral.ListView1.Items(EleSeleccionado).SubItems("nomArchivoTIF").Text
            ItemSel_numHistoria = frmIndizacionGeneral.ListView1.Items(EleSeleccionado).SubItems("numhistoria").Text.ToString.Trim
            ItemSel_tipoDocumento = frmIndizacionGeneral.ListView1.Items(EleSeleccionado).SubItems("TipoDocumento").Text.ToString.Trim
            ItemSel_fechainicio = frmIndizacionGeneral.ListView1.Items(EleSeleccionado).SubItems("fechainicio").Text.ToString.Trim
            ItemSel_fechaTermino = frmIndizacionGeneral.ListView1.Items(EleSeleccionado).SubItems("fechaTermino").Text.ToString.Trim
            ItemSel_fechaDocumento = frmIndizacionGeneral.ListView1.Items(EleSeleccionado).SubItems("fechaDocumento").Text.ToString.Trim
            ItemSel_codservicioPAED = frmIndizacionGeneral.ListView1.Items(EleSeleccionado).SubItems("codServicioPAED").Text.ToString.Trim
            ItemSel_Numicu = frmIndizacionGeneral.ListView1.Items(EleSeleccionado).SubItems("codigoActo").Text.ToString.Trim
            ItemSel_Incidencia = frmIndizacionGeneral.ListView1.Items(EleSeleccionado).SubItems("Incidencia").Text
            ItemSel_Indizado = frmIndizacionGeneral.ListView1.Items(EleSeleccionado).SubItems("indizada").Text
            ItemSel_Eliminada = frmIndizacionGeneral.ListView1.Items(EleSeleccionado).SubItems("eliminada").Text
            ItemSel_Paciente = frmIndizacionGeneral.ListView1.Items(EleSeleccionado).SubItems("paciente").Text.ToString.Trim
            ItemSel_Dni = frmIndizacionGeneral.ListView1.Items(EleSeleccionado).SubItems("DNI").Text.ToString.Trim
            ItemSel_Cip = frmIndizacionGeneral.ListView1.Items(EleSeleccionado).SubItems("CIP").Text.ToString.Trim
            ItemSel_TipoActo = frmIndizacionGeneral.ListView1.Items(EleSeleccionado).SubItems("tipoActo").Text.ToString.Trim

            ''ItemSel_nombre = frmIndizacionGeneral.ListView1.Items(EleSeleccionado).SubItems("nombre").Text
            ''ItemSel_apellido1 = frmIndizacionGeneral.ListView1.Items(EleSeleccionado).SubItems("apellido1").Text
            ''ItemSel_apellido2 = frmIndizacionGeneral.ListView1.Items(EleSeleccionado).SubItems("apellido2").Text

            If ItemSel_idLote.Trim <> "" And ItemSel_pagina.Trim <> "" Then

                'Creamos la select para comprobar si este registro concreto tiene el campo indizado a 1. Si no, no dejamos actuar
                cadenaSQL = "SELECT * FROM DOCUMENTOS WHERE idLote = " & ItemSel_idLote & " AND Pagina = " & ItemSel_pagina

                Dim resultado As DataRow = datos.ejecutarSQLDirectaDataRow(cadenaSQL, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto)

                'MsgBox("Valor de indizado: " & resultado(11).ToString)

                If resultado("Indizado").ToString() <> "" And resultado("Indizado").ToString() <> "0" Then
                    'el registro ya ha sido indexado por lo que podemos continuar con la modificacion

                    Me.lblModoEdicion.Visible = True
                    Me.Button1.Visible = False
                    frmIndizacionGeneral.ListView1.Enabled = False

                    ModoEdicion = True

                    txtNumHistoria.Text = ItemSel_numHistoria
                    txtNumicu.Text = ItemSel_Numicu

                    txtServicio.Text = ItemSel_codservicioPAED
                    If ItemSel_codservicioPAED.Trim <> "" Then
                        'Cuando le asignemos contenido al campo, ademas de rellenar el valor del propio campo, 
                        'lanzará un evento que refrescará el contenido del desplegable
                        txtServicio.Text = ItemSel_codservicioPAED
                        CambiarServicio(ItemSel_codservicioPAED)
                    End If

                    txtNumHistoria.Text = ItemSel_numHistoria
                    txtPaciente.Text = ItemSel_Paciente

                    mTxtFechaDia.Text = ItemSel_fechaDocumento
                    mtxtFEchainicio.Text = ItemSel_fechainicio
                    mtxtfechaTerminio.Text = ItemSel_fechaTermino

                    If ItemSel_Incidencia.Trim <> "" Then
                        cmbIncidencias.SelectedValue = ItemSel_Incidencia
                    End If

                    txtCodigoDoc.Text = ItemSel_tipoDocumento
                    If ItemSel_tipoDocumento.Trim <> "" Then
                        cmb_codigo_doc.SelectedValue = ItemSel_tipoDocumento
                        CambiarTipoDocumento(ItemSel_tipoDocumento)
                    End If

                    If ItemSel_TipoActo.Trim <> "" Then
                        cmbTipoActo.SelectedValue = ItemSel_TipoActo
                        CambiarTipoActo(ItemSel_TipoActo)
                    End If

                    txtDNI.Text = ItemSel_Dni
                    txtCIP.Text = ItemSel_Cip

                Else
                    'El registro no se ha indizado. No se permite la edicion de registros sin indizar
                    MsgBox("Este registro no se puede alterar ya que todavía no ha sido indizado")
                End If

            End If

            'MsgBox(ItemSel_idLote + "|" + ItemSel_pagina + "|" + ItemSel_nomArchivoTIF + "|" + ItemSel_numHistoria + "|" + ItemSel_tipoDocumento + "|" + ItemSel_fechainicio + "|" + ItemSel_fechaTermino + "|" + ItemSel_codservicioPAED + "|" + ItemSel_TipoEpisodioPAED + "|" + ItemSel_Numicu + "|" + ItemSel_Incidencia + "|" + ItemSel_vinculada + "|" + ItemSel_Indizado + "|" + ItemSel_Eliminada + "|" + ItemSel_nombre + "|" + ItemSel_apellido1 + "|" + ItemSel_apellido2 + "|" + ItemSel_servicio)

        End If
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        If Not IsNothing(Me.ListView1.SelectedItems(0)) Then

            cargaDatosAlSeleccionarEpisodio()

            '''Me.txtNumicu.Text = Me.ListView1.SelectedItems(0).SubItems("codigoacto").Text
            '''CambiarTipoActo(Me.ListView1.SelectedItems(0).Text)

            '''If IsNothing(Me.ListView1.SelectedItems(0).SubItems("idservicio").Text) Then
            '''    Me.txtServicio.Text = ""
            '''    Me.cmbServicios.SelectedIndex = -1
            '''Else
            '''    Me.txtServicio.Text = Me.ListView1.SelectedItems(0).SubItems("idservicio").Text
            '''    CambiarServicio(txtServicio.Text)
            '''End If

            '''Me.mtxtFEchainicio.Text = Me.ListView1.SelectedItems(0).SubItems("fechainicio").Text
            '''Me.mtxtfechaTerminio.Text = Me.ListView1.SelectedItems(0).SubItems("fechaFin").Text

            '''Me.txtCodigoDoc.Focus()
            '''Me.txtCodigoDoc.SelectAll()
        End If
    End Sub

    'Copia datos de la pantalla temporalmente para luego pegarlos
    Public Sub copiarDatos()

        tmpFechaDoc = mTxtFechaDia.Text.ToString.Trim
        tmpNumHistoria = txtNumHistoria.Text.ToString.Trim
        tmpDni = txtDNI.Text.ToString.Trim
        tmpCip = txtCIP.Text.ToString.Trim
        tmpPaciente = txtPaciente.Text.ToString.Trim
        If cmbTipoActo.Text.ToString.Trim <> "" Then
            tmpTipoActo = cmbTipoActo.Text.ToString.Trim
        Else
            tmpTipoActo = ""
        End If
        tmpNumIcu = txtNumicu.Text.ToString.Trim
        tmpFechaIni = mtxtFEchainicio.Text.ToString.Trim
        tmpFechaFin = mtxtfechaTerminio.Text.ToString.Trim
        tmpServicio = txtServicio.Text.ToString.Trim
        tmpTipoDoc = txtCodigoDoc.Text.ToString.Trim

    End Sub

    Public Sub copiarDatos_Anterior(ByVal elementoanterior As ListViewItem)

        tmpFechaDoc = elementoanterior.SubItems("fechadocumento").Text ''mTxtFechaDia.Text.ToString.Trim
        tmpNumHistoria = elementoanterior.SubItems("numhistoria").Text.ToString.Trim    '' txtNumHistoria.Text.ToString.Trim
        tmpDni = elementoanterior.SubItems("DNI").Text.ToString.Trim    '' txtDNI.Text.ToString.Trim
        tmpCip = elementoanterior.SubItems("CIP").Text.ToString.Trim    '' txtCIP.Text.ToString.Trim
        tmpPaciente = elementoanterior.SubItems("paciente").Text.ToString.Trim    '' txtPaciente.Text.ToString.Trim
        If elementoanterior.SubItems("tipoActo").Text.ToString.Trim <> "" Then
            tmpTipoActo = elementoanterior.SubItems("tipoActo").Text.ToString.Trim
        Else
            tmpTipoActo = ""
        End If
        tmpNumIcu = elementoanterior.SubItems("codigoActo").Text.ToString.Trim    '' txtNumicu.Text.ToString.Trim
        tmpFechaIni = elementoanterior.SubItems("fechainicio").Text.ToString.Trim    '' mtxtFEchainicio.Text.ToString.Trim
        tmpFechaFin = elementoanterior.SubItems("fechatermino").Text.ToString.Trim    '' mtxtfechaTerminio.Text.ToString.Trim
        tmpServicio = elementoanterior.SubItems("codserviciopaed").Text.ToString.Trim    '' txtServicio.Text.ToString.Trim
        tmpTipoDoc = elementoanterior.SubItems("tipodocumento").Text.ToString.Trim    '' txtCodigoDoc.Text.ToString.Trim

    End Sub

    'Pega datos temporales a la pantalla
    Public Sub pegarDatos()

        mTxtFechaDia.Text = tmpFechaDoc.ToString.Trim
        txtNumHistoria.Text = tmpNumHistoria.ToString.Trim
        txtDNI.Text = tmpDni.ToString.Trim
        txtCIP.Text = tmpCip.ToString.Trim
        txtPaciente.Text = tmpPaciente.ToString.Trim
        ''CambiarTipoActo(tmpTipoActo.Split(" - ")(0).ToString.Trim)
        CambiarTipoActo(tmpTipoActo.ToString.Trim)
        txtNumicu.Text = tmpNumIcu.ToString.Trim
        mtxtFEchainicio.Text = tmpFechaIni.ToString.Trim
        mtxtfechaTerminio.Text = tmpFechaFin.ToString.Trim
        txtServicio.Text = tmpServicio.ToString.Trim
        txtCodigoDoc.Text = tmpTipoDoc.ToString.Trim

    End Sub

    Private Sub mTxtFechaDia_KeyDown(sender As Object, e As KeyEventArgs) Handles mTxtFechaDia.KeyDown




        ''If e.KeyData = Keys.Control + Keys.C Then
        ''    copiarDatos()
        ''    pulsaMas()

        ''ElseIf e.KeyData = Keys.Control + Keys.V Then
        ''    pegarDatos()
        ''    pulsaMas()

        ''End If

    End Sub

    Public Sub pulsaMas()

        Dim auxHistoriaAnterior As String = Me.txtNumHistoria.Text
        Dim encontrado As Boolean = False

        Dim ValorTipoDoc As String = ""
        Dim ValorServicio As String = ""
        Dim ValorFecha As String = ""
        Dim ValorFechaINI As String = ""
        Dim ValorFechaFIN As String = ""
        Dim ValorICU As String = ""

        ValorTipoDoc = Me.txtCodigoDoc.Text
        ValorServicio = Me.txtServicio.Text
        ValorFecha = Me.mTxtFechaDia.Text
        ValorFechaINI = Me.mtxtFEchainicio.Text
        ValorFechaFIN = Me.mtxtfechaTerminio.Text
        ValorICU = Me.txtNumicu.Text

        PasarASiguiente = True

        If Me.txtServicio.Text <> "" Then


            For Each tipodocumento As modelo.ClsTipoDocumento In Me.cmb_codigo_doc.Items
                If tipodocumento.codigo = Me.txtCodigoDoc.Text Then
                    encontrado = True
                    'esto no le da el foco a otro componente por lo que no hay que 
                    'gestionarlo
                    Me.cmb_codigo_doc.SelectedItem = tipodocumento
                    Exit For
                End If
            Next

            If Not encontrado Then
                MessageBox.Show("El tipo de documento no es valido")
                Me.txtCodigoDoc.Focus()
                Me.txtCodigoDoc.SelectAll()
                Exit Sub
            End If

            encontrado = False

            For Each codigoservicio As modelo.ClsServicio In Me.cmbServicios.Items

                If codigoservicio._idservicio = Me.txtServicio.Text Then
                    encontrado = True
                    'esto no le da el foco a otro componente por lo que no hay que 
                    'gestionarlo
                    Me.cmbServicios.SelectedItem = codigoservicio
                    Exit For
                End If
            Next

            If Not encontrado Then
                MessageBox.Show("El codido de servicio no es valido")
                'Me.txtCodigoDoc.Text = ""
                Me.txtServicio.Focus()
                Me.txtServicio.SelectAll()
                Exit Sub
            End If


            '############# JGARIJO 11/11/2019 #################
            'Modificacion para evitar que al pulsar la tecla + en este campo
            'si el lote todavia no ha sido cerrado no es necesario que entren en modo de edicion
            'y que las pulsaciones al + son para navegar, aunque se guarde el registro como indizado = 1
            If LoteYaCerrado = True Then
                'Sabemos que es un lote que se cerró y por lo tanto para cambiar valores se debe entrar en modo de edicion
                If GetDocumentoActual.SubItems("indizada").Text = 1 And ModoEdicion = False Then
                    MsgBox("No es posible modificar un registro ya indizado sin entrar en Modo Edicion")
                    Exit Sub
                End If
            End If


            Me._frmIndizacionGeneral.bajarAbajo()
            If GetDocumentoActual.SubItems("indizada").Text = 1 Then
                Me.mTxtFechaDia.Text = Me.mtxtFEchainicio.Text
                Me.cmbServicios.SelectedIndex = Me.cmbServicios.FindString(GetDocumentoActual.SubItems("codservicioPAED").Text)
                'Me.txtServicio.Focus()
            Else
                actualizarDatos(Me.mTxtFechaDia.Text)
                If auxHistoriaAnterior <> Me.txtNumHistoria.Text Then
                    Me._frmIndizacionGeneral.escribirCambioHistoria(auxHistoriaAnterior, Me.txtNumHistoria.Text)
                    Me.pnlCambio.BackColor = Color.Red
                    Me.txtCodigoDoc.Focus()
                    Me.txtCodigoDoc.SelectAll()
                Else
                    Me._frmIndizacionGeneral.escribirHistoria(auxHistoriaAnterior, Me.txtNumHistoria.Text)
                    Me.pnlCambio.BackColor = Color.Lime
                    Me.txtCodigoDoc.Focus()
                    Me.txtCodigoDoc.SelectAll()
                End If
            End If

        End If

        Me.ListView1.Items.Clear()

        If Me.pnlCambio.BackColor = Color.Lime Then
            'Me.txtServicio.Focus()
            'Me.txtServicio.SelectAll()
        Else
            Me.mTxtFechaDia.Focus()
        End If


        Me.txtCodigoDoc.Text = ValorTipoDoc
        Me.txtServicio.Text = ValorServicio
        Me.mTxtFechaDia.Text = ValorFecha
        Me.mtxtFEchainicio.Text = ValorFechaINI
        Me.mtxtfechaTerminio.Text = ValorFechaFIN
        Me.txtNumicu.Text = ValorICU

    End Sub

    Private Sub txtNumHistoria_Leave(sender As Object, e As EventArgs) Handles txtNumHistoria.Leave

        If txtNumHistoria.Text.ToString.Trim = "" Or txtNumHistoria.Text.ToString.Trim = "0" Then
            txtDNI.Focus()
            Exit Sub
        Else
            If frmIndizacionGeneral.listaHistoriasGECI.Count > 0 Then
                If frmIndizacionGeneral.listaHistoriasGECI.FindIndex(Function(numHistoria)
                                                                         Return (numHistoria = Convert.ToInt32(txtNumHistoria.Text.ToString.Trim))
                                                                     End Function) = -1 Then
                    MessageBox.Show("No existe el número de historia " & txtNumHistoria.Text.ToString.Trim & " en GECI.", "Historia no válida", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtNumHistoria.Focus()
                    txtNumHistoria.SelectAll()
                    Exit Sub
                End If
            End If
        End If

        If tmpNumHistoria <> txtNumHistoria.Text.ToString.Trim Or tmpTipoDoc <> txtCodigoDoc.Text.ToString.Trim Then
            inicializarListaPacientes(txtNumHistoria.Text.ToString.Trim, "", "", "")
            If lvwPacientes.Items.Count > 0 Then
                lvwPacientes.Visible = True
                Me.lvwPacientes.Focus()
                Me.lvwPacientes.Refresh()
                Me.lvwPacientes.EnsureVisible(Me.lvwPacientes.Items(0).Index)

                If lvwPacientes.Items.Count = 1 Then
                    '''actualizarDatos(Me.mTxtFechaDia.Text)
                    If cargaCamposPaciente(0) Then
                        If Me.txtCIP.Text.ToString.Trim <> "" Then
                            ObtenerEpisodios() 'Esto va a cargar los episodios que nos encontremos en el listview
                        End If
                        If Me.ListView1.Items.Count = 0 Then
                            ''cmbTipoActo.Focus()
                        Else
                            ''Me.ListView1.Focus()
                        End If
                    Else
                        MessageBox.Show("No existe el número de historia " & txtNumHistoria.Text.ToString.Trim & " en GECI.", "Historia no válida", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
                Else
                txtNumHistoria.Text = ""
                txtDNI.Text = ""
                txtCIP.Text = ""
                txtPaciente.Text = ""
                lvwPacientes.Visible = False
            End If
        End If

    End Sub

    Private Sub TxtCIP_Leave(sender As Object, e As EventArgs) Handles txtCIP.Leave

        If txtCIP.Text.ToString.Trim = "" Or txtCIP.Text.ToString.Trim = "0" Then Exit Sub

        If tmpCip <> txtCIP.Text.ToString.Trim Then
            inicializarListaPacientes("", txtCIP.Text.ToString.Trim, "", "")
            If lvwPacientes.Items.Count > 0 Then
                lvwPacientes.Visible = True
                Me.lvwPacientes.Refresh()
                Me.lvwPacientes.EnsureVisible(Me.lvwPacientes.Items(0).Index)

                lvwPacientes.Focus()

                If lvwPacientes.Items.Count = 1 Then
                    If cargaCamposPaciente(0) = False Then
                        MessageBox.Show("No existe el número de historia " & txtNumHistoria.Text.ToString.Trim & " en GECI.", "Historia no válida", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            Else
                txtNumHistoria.Text = ""
                txtDNI.Text = ""
                txtCIP.Text = ""
                txtPaciente.Text = ""
                lvwPacientes.Visible = False
            End If
        End If

    End Sub

    Private Sub TxtPaciente_Leave(sender As Object, e As EventArgs) Handles txtPaciente.Leave

        If txtPaciente.Text.ToString.Trim = "," Or txtPaciente.Text.ToString.Trim = "" Then Exit Sub

        Me.Cursor = Cursors.WaitCursor

        If tmpPaciente <> txtPaciente.Text.ToString.Trim Then
            inicializarListaPacientes("", "", txtPaciente.Text.ToString.Trim, "")
            If lvwPacientes.Items.Count > 0 Then
                lvwPacientes.Visible = True
                Me.lvwPacientes.Refresh()
                Me.lvwPacientes.EnsureVisible(Me.lvwPacientes.Items(0).Index)

                lvwPacientes.Focus()

                If lvwPacientes.Items.Count = 1 Then
                    If cargaCamposPaciente(0) = False Then
                        MessageBox.Show("No existe el número de historia " & txtNumHistoria.Text.ToString.Trim & " en GECI.", "Historia no válida", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            Else
                txtNumHistoria.Text = ""
                txtDNI.Text = ""
                txtCIP.Text = ""
                txtPaciente.Text = ""
                lvwPacientes.Visible = False
            End If
        End If

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub cargaDatosAlSeleccionarEpisodio()

        Me.txtNumicu.Text = Me.ListView1.SelectedItems(0).SubItems("codigoacto").Text
        CambiarTipoActo(Me.ListView1.SelectedItems(0).Text)

        If Me.ListView1.SelectedItems(0).SubItems("servicioGEDSA").Text = "" Then
            Me.txtServicio.Text = ""
            Me.cmbServicios.SelectedIndex = -1
        Else
            ''Dim serviciosGEDSA As Integer
            ''If Not IsNothing(Me.cmbServicios.SelectedItem) Then
            ''    serviciosGEDSA = CType(Me.cmbServicios.SelectedItem, modelo.ClsServicio)._idservicio
            ''End If

            Me.txtServicio.Text = Me.ListView1.SelectedItems(0).SubItems("servicioGEDSA").Text '' Me.ListView1.SelectedItems(0).SubItems("idservicio").Text
            CambiarServicioHospital(Me.txtServicio.Text)
        End If

        If Me.ListView1.SelectedItems(0).SubItems("fechainicio").Text.ToString.Trim = "" Then
            Me.mtxtFEchainicio.Text = mTxtFechaDia.Text
        Else
            Me.mtxtFEchainicio.Text = Me.ListView1.SelectedItems(0).SubItems("fechainicio").Text
        End If

        If Me.ListView1.SelectedItems(0).SubItems("fechaFin").Text.ToString.Trim = "" Then
            Me.mtxtfechaTerminio.Text = mTxtFechaDia.Text
        Else
            Me.mtxtfechaTerminio.Text = Me.ListView1.SelectedItems(0).SubItems("fechaFin").Text
        End If

        If txtServicio.Enabled Then
            Me.txtServicio.Focus()
            Me.txtServicio.SelectAll()
        ElseIf txtCodigoDoc.Enabled Then
            Me.txtCodigoDoc.Focus()
            Me.txtCodigoDoc.SelectAll()
        Else
            Me.mTxtFechaDia.Focus()
            Me.mTxtFechaDia.SelectAll()
        End If

        ''Me.txtCodigoDoc.Focus()
        ''Me.txtCodigoDoc.SelectAll()

    End Sub

    Private Sub CmdActo_Click(sender As Object, e As EventArgs) Handles cmdActo.Click

        Me.Cursor = Cursors.WaitCursor

        If Me.txtCIP.Text.ToString.Trim <> "" Then
            ObtenerEpisodios() 'Esto va a cargar los episodios que nos encontremos en el listview
        End If
        If Me.ListView1.Items.Count = 0 Then
            cmbTipoActo.Focus()
        Else
            Me.ListView1.Focus()
        End If

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub LvwPacientes_Leave(sender As Object, e As EventArgs) Handles lvwPacientes.Leave
        ListView1.Focus()
    End Sub

    Private Sub TxtServicio_KeyDown(sender As Object, e As KeyEventArgs) Handles txtServicio.KeyDown
        ''If e.KeyData = Keys.Control + Keys.C Then
        ''    copiarDatos()
        ''    pulsaMas()

        ''ElseIf e.KeyData = Keys.Control + Keys.V Then
        ''    pegarDatos()
        ''    pulsaMas()

        ''End If
    End Sub

    Private Sub TxtCodigoDoc_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigoDoc.KeyDown
        ''If e.KeyData = Keys.Control + Keys.C Then
        ''    copiarDatos()
        ''    pulsaMas()

        ''ElseIf e.KeyData = Keys.Control + Keys.V Then
        ''    pegarDatos()
        ''    pulsaMas()

        ''End If
    End Sub

    Private Sub TxtNumHistoria_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNumHistoria.KeyDown
        ''If e.KeyData = Keys.Control + Keys.C Then
        ''    copiarDatos()
        ''    pulsaMas()

        ''ElseIf e.KeyData = Keys.Control + Keys.V Then
        ''    pegarDatos()
        ''    pulsaMas()

        ''End If
    End Sub

    Private Sub TxtDNI_Leave(sender As Object, e As EventArgs) Handles txtDNI.Leave

        If txtDNI.Text.ToString.Trim = "" Or txtDNI.Text.ToString.Trim = "0" Then Exit Sub

        If tmpDni <> txtDNI.Text.ToString.Trim Then
            inicializarListaPacientes("", "", "", txtDNI.Text.ToString.Trim)
            If lvwPacientes.Items.Count > 0 Then
                lvwPacientes.Visible = True
                Me.lvwPacientes.Focus()
                Me.lvwPacientes.Refresh()
                Me.lvwPacientes.EnsureVisible(Me.lvwPacientes.Items(0).Index)

                If lvwPacientes.Items.Count = 1 Then
                    '''actualizarDatos(Me.mTxtFechaDia.Text)
                    If cargaCamposPaciente(0) Then
                        If Me.txtCIP.Text.ToString.Trim <> "" Then
                            ObtenerEpisodios() 'Esto va a cargar los episodios que nos encontremos en el listview
                        End If
                        If Me.ListView1.Items.Count = 0 Then
                            ''cmbTipoActo.Focus()
                        Else
                            ''Me.ListView1.Focus()
                        End If
                    Else
                        MessageBox.Show("No existe el número de historia " & txtNumHistoria.Text.ToString.Trim & " en GECI.", "Historia no válida", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
                Else
                txtNumHistoria.Text = ""
                txtDNI.Text = ""
                txtCIP.Text = ""
                txtPaciente.Text = ""
                lvwPacientes.Visible = False
            End If
        End If
    End Sub

End Class
