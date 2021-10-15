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

Public Class ctrlIndizacionEpidemiologia
    Private _frmIndizacionGeneral As frmIndizacionGeneral
    Private documento As ListViewItem
    Private incidencia As ClsIncidencia

    Dim CambioComboDocumento As Boolean = True
    Dim CambioComboServicio As Boolean = True

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

        CalcularEpi = 0
        Try
            Me.cmbIncidencias.Items.Clear()
            'Me.cmb_codigo_doc.Items.Clear()
            'Me.cmbTipoEpisodio.Items.Clear() ' area
            Me.cmbServicios.Items.Clear()


            'cargamos el combo de incidencias 
            For Each registro As DataRow In datos.ejecutarSQLDirectaTable("SELECT IdIncidencia , Descripcion , codigoASCII AS codigotecla FROM TIPOSINCIDENCIAS WHERE (Tipo LIKE 'DIGI') AND (codigoASCII IS NOT NULL)", frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto).Rows

                incidencia = New ClsIncidencia(registro.Item("idincidencia").ToString, registro.Item("descripcion").ToString, registro.Item("codigotecla").ToString)
                Me.cmbIncidencias.Items.Add(incidencia)

            Next


            'cargar el combo tipo documentos 
            Me.cmb_codigo_doc.Items.Clear()
            For Each registro As DataRow In datos.ejecutarSQLDirectaTable("SELECT  idtipoDocumento, Descripcion FROM TIPOSDOCUMENTOS order by idtipodocumento", frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto).Rows

                tipodocumento = New modelo.ClsTipoDocumento(registro.Item("idtipodocumento"), registro.Item("descripcion"))
                Me.cmb_codigo_doc.Items.Add(tipodocumento)
            Next

            'cargamos el comgo de servicio 
            For Each registro As DataRow In datos.ejecutarSQLDirectaTable("SELECT idServicio, Descripcion FROM SERVICIOS where visible = 1 order by descripcion", frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto).Rows

                servicio = New modelo.ClsServicio(registro.Item("idservicio"), registro.Item("descripcion"))
                Me.cmbServicios.Items.Add(servicio)


            Next

            ''cargamos el combo de area 
            'For Each registro As DataRow In datos.ejecutarSQLDirectaTable("SELECT IdArea, Descripcion FROM AREAS order by idarea", frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto).Rows
            '    area = New modelo.ClsArea(registro.Item("idarea"), registro.Item("Descripcion"))
            '    Me.cmbTipoEpisodio.Items.Add(area)
            'Next

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

            If e.KeyChar = "e" Then
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
            ElseIf e.KeyChar = "W" Then
                If ConInf.Checked = True Then
                    ConInf.Checked = False
                Else
                    ConInf.Checked = True
                End If
                Exit Sub
            ElseIf e.KeyChar = "w" Then
                If ConInf.Checked = True Then
                    ConInf.Checked = False
                Else
                    ConInf.Checked = True
                End If
                Exit Sub
            ElseIf e.KeyChar = "*" Then
                e.Handled = True
                Dim elementoanterior As ListViewItem
                elementoanterior = _frmIndizacionGeneral.ListView1.Items(Me.GetDocumentoActual.Index - 1)
                Me.mTxtFechaDia.Text = elementoanterior.SubItems("fechainicio").Text
                Me.txtNumicu.Text = elementoanterior.SubItems("numicu").Text
                Exit Sub
            ElseIf e.KeyChar = "t" Then
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
            ElseIf e.KeyChar = "T" Then
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
            ElseIf e.KeyChar = "r" Then
                e.Handled = True
                imagen_rota()
                Exit Sub
            ElseIf e.KeyChar = "R" Then
                e.Handled = True
                imagen_rota()
                Exit Sub
            ElseIf e.KeyChar = "q" Then
                e.Handled = True
                Me.txtNumicu.Text = "998"
                Me.txtServicio.Text = ""
                SinEpisodio = 1
                CalcularEpi = 1
                Me.txtServicio.Focus()
                Return
                Exit Sub
            ElseIf e.KeyChar = "Q" Then
                e.Handled = True
                Me.txtNumicu.Text = "998"
                Me.txtServicio.Text = ""
                SinEpisodio = 1
                CalcularEpi = 1
                Me.txtServicio.Focus()
                Exit Sub
            ElseIf e.KeyChar = "A" Then
                e.Handled = True
                Me.txtNumicu.Text = "998"
                Me.txtServicio.Text = "153"
                SinEpisodio = 1
                CalcularEpi = 1
                Me.txtServicio.Focus()
                Exit Sub
            ElseIf e.KeyChar = "a" Then
                e.Handled = True
                Me.txtNumicu.Text = "998"
                Me.txtServicio.Text = "153"
                SinEpisodio = 1
                CalcularEpi = 1
                Me.txtServicio.Focus()
                Exit Sub
            ElseIf e.KeyChar = "s" Then
                e.Handled = True
                If UCSI.Checked = True Then
                    UCSI.Checked = False
                Else
                    UCSI.Checked = True
                End If
                Exit Sub
            ElseIf e.KeyChar = "S" Then
                e.Handled = True
                If UCSI.Checked = True Then
                    UCSI.Checked = False
                Else
                    UCSI.Checked = True
                End If
                Exit Sub
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
                        If GetDocumentoActual.SubItems("indizado").Text = 1 And ModoEdicion = False Then
                            MsgBox("No es posible modificar un registro ya indizado sin entrar en Modo Edicion")
                            Exit Sub
                        End If
                    End If


                    Me._frmIndizacionGeneral.bajarAbajo()
                    If GetDocumentoActual.SubItems("indizado").Text = 1 Then
                        Me.mTxtFechaDia.Text = Me.mtxtFEchainicio.Text
                        Me.cmbServicios.SelectedIndex = Me.cmbServicios.FindString(GetDocumentoActual.SubItems("servicio").Text)
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
            If e.KeyChar = "º" Then
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
            ElseIf e.KeyChar = "W" Then
                e.Handled = True
                If ConInf.Checked = True Then
                    ConInf.Checked = False
                Else
                    ConInf.Checked = True
                    UCSI.Checked = False
                    SD.Checked = False
                End If
                Exit Sub
            ElseIf e.KeyChar = "w" Then
                e.Handled = True
                If ConInf.Checked = True Then
                    ConInf.Checked = False
                Else
                    ConInf.Checked = True
                    UCSI.Checked = False
                    SD.Checked = False
                End If
                Exit Sub
            ElseIf e.KeyChar = "*" Then
                'e.Handled = True
                '' Me.GetDocumentoActual.
                'Dim elementoanterior As ListViewItem
                'elementoanterior = _frmIndizacionGeneral.ListView1.Items(Me.GetDocumentoActual.Index - 1)
                'Me.mTxtFechaDia.Focus()
                'Me.mTxtFechaDia.Text = elementoanterior.SubItems("fechadocumento").Text
                'Me.txtNumicu.Text = elementoanterior.SubItems("numicu").Text
                'Exit Sub
                ''ElseIf e.KeyChar = "t" Then
                ''   e.Handled = True
                ''  DesEliminarDocumento()
                '' Exit Sub
                e.Handled = True
                Dim elementoanterior As ListViewItem
                elementoanterior = _frmIndizacionGeneral.ListView1.Items(Me.GetDocumentoActual.Index - 1)
                Me.mTxtFechaDia.Focus()
                Me.mTxtFechaDia.Text = elementoanterior.SubItems("fechadocumento").Text
                Me.txtNumicu.Text = elementoanterior.SubItems("numicu").Text
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
                Me.txtNumicu.Text = "998"
                Me.txtServicio.Text = ""
                Me.mtxtFEchainicio.Text = Me.mTxtFechaDia.Text
                Me.mtxtfechaTerminio.Text = Me.mTxtFechaDia.Text
                CalcularEpi = 1
                Exit Sub
            ElseIf e.KeyChar = "Q" Then
                e.Handled = True
                Me.txtNumicu.Text = "998"
                Me.txtServicio.Text = ""
                Me.mtxtFEchainicio.Text = Me.mTxtFechaDia.Text
                Me.mtxtfechaTerminio.Text = Me.mTxtFechaDia.Text
                CalcularEpi = 1
                Exit Sub
            ElseIf e.KeyChar = "a" Then
                e.Handled = True
                Me.txtNumicu.Text = "998"
                Me.txtServicio.Text = "153"
                Me.mtxtFEchainicio.Text = Me.mTxtFechaDia.Text
                Me.mtxtfechaTerminio.Text = Me.mTxtFechaDia.Text
                CalcularEpi = 1
                Exit Sub
            ElseIf e.KeyChar = "A" Then
                e.Handled = True
                Me.txtNumicu.Text = "998"
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
                    Else


                        '############# JGARIJO 11/11/2019 #################
                        'Modificacion para evitar que al pulsar la tecla + en este campo
                        'si el lote todavia no ha sido cerrado no es necesario que entren en modo de edicion
                        'y que las pulsaciones al + son para navegar, aunque se guarde el registro como indizado = 1
                        If LoteYaCerrado = True Then
                            'Sabemos que es un lote que se cerró y por lo tanto para cambiar valores se debe entrar en modo de edicion
                            If GetDocumentoActual.SubItems("indizado").Text = 1 And ModoEdicion = False Then
                                MsgBox("No es posible modificar un registro ya indizado sin entrar en Modo Edicion")
                                Exit Sub
                            End If
                        End If


                        Me._frmIndizacionGeneral.bajarAbajo()
                        If GetDocumentoActual.SubItems("indizado").Text = 1 Then
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

                If GetDocumentoActual.SubItems("indizado").Text <> 1 Then
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
                    Me.txtNumicu.Text = "998"
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


    Private Sub EliminarDocumento()
        accesoDatosDocumentos.EliminarDocumento(frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto, Me.GetDocumentoActual.SubItems("idlote").Text, Me.GetDocumentoActual.SubItems("pagina").Text)
        Me._frmIndizacionGeneral.actualizarDatosListView()

    End Sub


    Private Sub DesEliminarDocumento()
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

            Dim datosEpisodiosCex As DataTable
            Dim item As ListViewItem

            'inicializamos conjunto resultados
            Me.ListView1.Items.Clear()

            datosEpisodiosCex = idatosSip.obtenerEpisodiosArea(frmContenedorMDI.oLote._idlote, Me.txtNumHistoria.Text, Me.mTxtFechaDia.Text, "CEX", frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto)

            For Each registro As DataRow In datosEpisodiosCex.Rows
                With registro
                    item = New ListViewItem
                    item.Text = IIf(IsDBNull(.Item("numhistoria")), 0, .Item("numhistoria"))
                    item.SubItems.Add(IIf(IsDBNull(.Item("episodio")), 0, .Item("episodio"))).name = "Episodio"
                    item.SubItems.Add(IIf(IsDBNull(.Item("servicio")), 0, .Item("servicio"))).name = "litservicio"
                    item.SubItems.Add(IIf(IsDBNull(.Item("fechainicio")), "01/01/1900", .Item("fechainicio"))).name = "FechaInicio"
                    item.SubItems.Add(IIf(IsDBNull(.Item("fechafin")), "01/01/1900", .Item("fechafin"))).name = "FechaFin"
                    item.SubItems.Add(IIf(IsDBNull(.Item("idservicio")), 0, .Item("idservicio"))).name = "servicio"
                    ' ''item.SubItems.Add(.Item("area")).Name = "area"
                    ' ''item.SubItems.Add(IIf(IsDBNull(.Item("orion")), 0, .Item("orion"))).name = "orion"
                    'item.SubItems.Add(IIf(IsDBNull(.Item("codigo_servicio")), 0, .Item("codigo_servicio"))).name = "codigo_servicio"
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

                    Me.txtNumicu.Text = Me.ListView1.SelectedItems(0).SubItems("episodio").Text
                    Me.txtServicio.Text = Me.ListView1.SelectedItems(0).SubItems("servicio").Text

                    '################# JGARIJO 21/10/2019 ########################
                    CambiarServicio(txtServicio.Text)
                    '#############################################################

                    Me.mtxtFEchainicio.Text = Me.ListView1.SelectedItems(0).SubItems("fechainicio").Text
                    Me.mtxtfechaTerminio.Text = Me.ListView1.SelectedItems(0).SubItems("fechaFin").Text
                    Me.lblservicio_descripcion.Text = Me.ListView1.SelectedItems(0).SubItems("servicio").Text.ToUpper
                    Me.Area1.Text = Me.ListView1.SelectedItems(0).SubItems("area").Text
                    Me.txtICUOrion.Text = Me.ListView1.SelectedItems(0).SubItems("orion").Text
                    'Me.txtCodigoDoc.Focus()
                    'Me.txtCodigoDoc.SelectAll()
                    Me.txtServicio.Focus()
                End If

            Catch ex As Exception
                Debug.Print("Error al leer los datos del list view ")
            End Try
        End If

    End Sub


    Private Sub ListView1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.Leave
        Me.txtServicio.Focus()
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
        If SinEpisodio = 0 Then
            ObtenerEpisodios() 'Esto va a cargar los episodios que nos encontremos en el listview

            Select Case Me.ListView1.Items.Count
                Case 0

                    Me.txtNumicu.Text = "998" 'no tiene episodio
                    Me.mtxtFEchainicio.Text = Me.mTxtFechaDia.Text
                    Me.mtxtfechaTerminio.Text = Me.mTxtFechaDia.Text
                    Me.Area1.Text = "" ' no tiene area
                    Me.txtICUOrion.Text = ""
                    Me.txtServicio.Focus()
                    Me.txtServicio.SelectAll()

                Case 1
                    Try
                        If Not IsNothing(Me.ListView1.Items(0)) Then

                            Me.txtNumicu.Text = Me.ListView1.Items(0).SubItems("episodio").Text
                            Me.txtServicio.Text = Me.ListView1.Items(0).SubItems("servicio").Text

                            '################# JGARIJO 21/10/2019 ########################
                            CambiarServicio(txtServicio.Text)
                            '#############################################################

                            Me.mtxtFEchainicio.Text = Me.ListView1.Items(0).SubItems("fechainicio").Text
                            Me.mtxtfechaTerminio.Text = Me.ListView1.Items(0).SubItems("fechaFin").Text
                            ' ''Me.Area1.Text = Me.ListView1.Items(0).SubItems("area").Text
                            Me.lblservicio_descripcion.Text = Me.ListView1.Items(0).SubItems("servicio").Text.ToUpper

                            ' ''Me.txtICUOrion.Text = Me.ListView1.Items(0).SubItems("orion").Text
                            Me.ListView1.Refresh()
                            Me.ListView1.EnsureVisible(Me.ListView1.Items(0).Index)
                            'Me.txtCodigoDoc.Focus()
                            'Me.txtCodigoDoc.SelectAll()
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
                actualizarDatos(Me.mTxtFechaDia.Text)
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
            If e.KeyChar = "º" Then
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
            ElseIf e.KeyChar = "W" Then
                e.Handled = True
                If ConInf.Checked = True Then
                    ConInf.Checked = False
                Else
                    ConInf.Checked = True
                    UCSI.Checked = False
                    SD.Checked = False
                End If
                Exit Sub
            ElseIf e.KeyChar = "w" Then
                e.Handled = True
                If ConInf.Checked = True Then
                    ConInf.Checked = False
                Else
                    ConInf.Checked = True
                    UCSI.Checked = False
                    SD.Checked = False
                End If
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
                e.Handled = True
                ' Me.GetDocumentoActual.
                Dim elementoanterior As ListViewItem
                elementoanterior = _frmIndizacionGeneral.ListView1.Items(Me.GetDocumentoActual.Index - 1)
                Me.mTxtFechaDia.Focus()
                Me.mTxtFechaDia.Text = elementoanterior.SubItems("fechadocumento").Text
                Me.txtNumicu.Text = elementoanterior.SubItems("numicu").Text
                Exit Sub
                'ElseIf e.KeyChar = "t" Then
                '   e.Handled = True
                '  DesEliminarDocumento()
                ' Exit Sub
            ElseIf e.KeyChar = "q" Then
                e.Handled = True
                Me.txtNumicu.Text = "998"
                Me.txtServicio.Text = ""
                Me.mtxtFEchainicio.Text = Me.mTxtFechaDia.Text
                Me.mtxtfechaTerminio.Text = Me.mTxtFechaDia.Text
                CalcularEpi = 1
                Exit Sub
            ElseIf e.KeyChar = "Q" Then
                e.Handled = True
                Me.txtNumicu.Text = "998"
                Me.txtServicio.Text = ""
                Me.mtxtFEchainicio.Text = Me.mTxtFechaDia.Text
                Me.mtxtfechaTerminio.Text = Me.mTxtFechaDia.Text
                CalcularEpi = 1
                Exit Sub
            ElseIf e.KeyChar = "a" Then
                e.Handled = True
                Me.txtNumicu.Text = "998"
                Me.txtServicio.Text = "153"
                Me.mtxtFEchainicio.Text = Me.mTxtFechaDia.Text
                Me.mtxtfechaTerminio.Text = Me.mTxtFechaDia.Text
                CalcularEpi = 1
                Exit Sub
            ElseIf e.KeyChar = "A" Then
                e.Handled = True
                Me.txtNumicu.Text = "998"
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
                            If GetDocumentoActual.SubItems("indizado").Text = 1 And ModoEdicion = False Then
                                MsgBox("No es posible modificar un registro ya indizado sin entrar en Modo Edicion")
                                Exit Sub
                            End If
                        End If

                        Dim i As Integer = 0
                        Dim EleSeleccionado As Integer = 0

                        Me._frmIndizacionGeneral.bajarAbajo()

                        If GetDocumentoActual.SubItems("indizado").Text = 1 Then
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
                If GetDocumentoActual.SubItems("indizado").Text <> 1 Then
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

    Private Sub txtCodigoDoc_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigoDoc.TextChanged
        CambiarTipoDocumento(txtCodigoDoc.Text)
    End Sub

    Private Sub txtServicio_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtServicio.TextChanged
        CambiarServicio(txtServicio.Text)
    End Sub
End Class
