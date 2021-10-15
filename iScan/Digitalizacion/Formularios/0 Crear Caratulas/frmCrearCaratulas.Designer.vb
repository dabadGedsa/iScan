<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCrearCaratulas
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCrearCaratulas))
        Me.gbCamposCaratula = New System.Windows.Forms.GroupBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.cmbCampoMemoria4 = New System.Windows.Forms.ComboBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.cmbCampoMemoria3 = New System.Windows.Forms.ComboBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.cmbCampoMemoria2 = New System.Windows.Forms.ComboBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.cmbcampomemoria1 = New System.Windows.Forms.ComboBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.txtCampoMemoria1 = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.txtCampoMemoria4 = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtCampoMemoria3 = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtCampoMemoria2 = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtMemoria = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.cmbSubtitulo2 = New System.Windows.Forms.ComboBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtSubtitulo2 = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.dgCodigoBarras = New System.Windows.Forms.DataGridView
        Me.Label12 = New System.Windows.Forms.Label
        Me.cmbSubtitulo1 = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtTituloCaratula = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtSubtitulo1 = New System.Windows.Forms.TextBox
        Me.gbConsultaDatosCaratula = New System.Windows.Forms.GroupBox
        Me.cmdGuardarConsulta = New LibreriaCadenaProduccion.Controles.Botones.CtrlBotonMediano
        Me.cmdEjecutarConsulta = New LibreriaCadenaProduccion.Controles.Botones.CtrlBotonMediano
        Me.dgDatosConsulta = New System.Windows.Forms.DataGridView
        Me.txtWHEREGenerarCaratula = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtFROMGenerarCaratula = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtSELECTGeneracionCaratula = New System.Windows.Forms.TextBox
        Me.cmbProyectosCrearCaratulas = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CtrlGenerarCaratulas = New LibreriaCadenaProduccion.Controles.Botones.CtrlBotonMediano
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Button6 = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.DataGridView2 = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtNumpaginas = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.cmdServicios = New System.Windows.Forms.ComboBox
        Me.gbEpisodios = New System.Windows.Forms.GroupBox
        Me.chk5 = New System.Windows.Forms.CheckBox
        Me.cmbEpisodios = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.chk20 = New System.Windows.Forms.CheckBox
        Me.chkall = New System.Windows.Forms.CheckBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbLote = New System.Windows.Forms.ComboBox
        Me.txtfechaactual = New System.Windows.Forms.TextBox
        Me.lblLonbarcode = New System.Windows.Forms.Label
        Me.cmLongBarCode = New System.Windows.Forms.ComboBox
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.cmdinsertarRegistro = New System.Windows.Forms.Button
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtNumhistoria = New System.Windows.Forms.TextBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.pgbCaratulas = New System.Windows.Forms.ProgressBar
        Me.CtrlBotonMediano3 = New LibreriaCadenaProduccion.Controles.Botones.CtrlBotonMediano
        Me.CrystalReportViewer2 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.crpCaratula1 = New Digitalización.crpCaratula
        Me.gbCamposCaratula.SuspendLayout()
        CType(Me.dgCodigoBarras, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbConsultaDatosCaratula.SuspendLayout()
        CType(Me.dgDatosConsulta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.gbEpisodios.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbCamposCaratula
        '
        Me.gbCamposCaratula.Controls.Add(Me.Label24)
        Me.gbCamposCaratula.Controls.Add(Me.cmbCampoMemoria4)
        Me.gbCamposCaratula.Controls.Add(Me.Label23)
        Me.gbCamposCaratula.Controls.Add(Me.cmbCampoMemoria3)
        Me.gbCamposCaratula.Controls.Add(Me.Label22)
        Me.gbCamposCaratula.Controls.Add(Me.cmbCampoMemoria2)
        Me.gbCamposCaratula.Controls.Add(Me.Label21)
        Me.gbCamposCaratula.Controls.Add(Me.cmbcampomemoria1)
        Me.gbCamposCaratula.Controls.Add(Me.Label20)
        Me.gbCamposCaratula.Controls.Add(Me.txtCampoMemoria1)
        Me.gbCamposCaratula.Controls.Add(Me.Label19)
        Me.gbCamposCaratula.Controls.Add(Me.txtCampoMemoria4)
        Me.gbCamposCaratula.Controls.Add(Me.Label18)
        Me.gbCamposCaratula.Controls.Add(Me.txtCampoMemoria3)
        Me.gbCamposCaratula.Controls.Add(Me.Label17)
        Me.gbCamposCaratula.Controls.Add(Me.txtCampoMemoria2)
        Me.gbCamposCaratula.Controls.Add(Me.Label16)
        Me.gbCamposCaratula.Controls.Add(Me.txtMemoria)
        Me.gbCamposCaratula.Controls.Add(Me.Label14)
        Me.gbCamposCaratula.Controls.Add(Me.cmbSubtitulo2)
        Me.gbCamposCaratula.Controls.Add(Me.Label15)
        Me.gbCamposCaratula.Controls.Add(Me.txtSubtitulo2)
        Me.gbCamposCaratula.Controls.Add(Me.Label13)
        Me.gbCamposCaratula.Controls.Add(Me.dgCodigoBarras)
        Me.gbCamposCaratula.Controls.Add(Me.Label12)
        Me.gbCamposCaratula.Controls.Add(Me.cmbSubtitulo1)
        Me.gbCamposCaratula.Controls.Add(Me.Label9)
        Me.gbCamposCaratula.Controls.Add(Me.txtTituloCaratula)
        Me.gbCamposCaratula.Controls.Add(Me.Label11)
        Me.gbCamposCaratula.Controls.Add(Me.txtSubtitulo1)
        Me.gbCamposCaratula.Enabled = False
        Me.gbCamposCaratula.Location = New System.Drawing.Point(12, 239)
        Me.gbCamposCaratula.Name = "gbCamposCaratula"
        Me.gbCamposCaratula.Size = New System.Drawing.Size(489, 366)
        Me.gbCamposCaratula.TabIndex = 12
        Me.gbCamposCaratula.TabStop = False
        Me.gbCamposCaratula.Text = "Campos"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(208, 337)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(27, 13)
        Me.Label24.TabIndex = 45
        Me.Label24.Text = "Item"
        '
        'cmbCampoMemoria4
        '
        Me.cmbCampoMemoria4.FormattingEnabled = True
        Me.cmbCampoMemoria4.Location = New System.Drawing.Point(239, 334)
        Me.cmbCampoMemoria4.Name = "cmbCampoMemoria4"
        Me.cmbCampoMemoria4.Size = New System.Drawing.Size(149, 21)
        Me.cmbCampoMemoria4.TabIndex = 44
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(208, 310)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(27, 13)
        Me.Label23.TabIndex = 43
        Me.Label23.Text = "Item"
        '
        'cmbCampoMemoria3
        '
        Me.cmbCampoMemoria3.FormattingEnabled = True
        Me.cmbCampoMemoria3.Location = New System.Drawing.Point(239, 307)
        Me.cmbCampoMemoria3.Name = "cmbCampoMemoria3"
        Me.cmbCampoMemoria3.Size = New System.Drawing.Size(149, 21)
        Me.cmbCampoMemoria3.TabIndex = 42
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(207, 283)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(27, 13)
        Me.Label22.TabIndex = 41
        Me.Label22.Text = "Item"
        '
        'cmbCampoMemoria2
        '
        Me.cmbCampoMemoria2.FormattingEnabled = True
        Me.cmbCampoMemoria2.Location = New System.Drawing.Point(238, 280)
        Me.cmbCampoMemoria2.Name = "cmbCampoMemoria2"
        Me.cmbCampoMemoria2.Size = New System.Drawing.Size(149, 21)
        Me.cmbCampoMemoria2.TabIndex = 40
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(208, 257)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(27, 13)
        Me.Label21.TabIndex = 39
        Me.Label21.Text = "Item"
        '
        'cmbcampomemoria1
        '
        Me.cmbcampomemoria1.FormattingEnabled = True
        Me.cmbcampomemoria1.Location = New System.Drawing.Point(239, 254)
        Me.cmbcampomemoria1.Name = "cmbcampomemoria1"
        Me.cmbcampomemoria1.Size = New System.Drawing.Size(149, 21)
        Me.cmbcampomemoria1.TabIndex = 38
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(18, 257)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(89, 13)
        Me.Label20.TabIndex = 37
        Me.Label20.Text = "Campo1 Memoria"
        '
        'txtCampoMemoria1
        '
        Me.txtCampoMemoria1.Location = New System.Drawing.Point(108, 255)
        Me.txtCampoMemoria1.Name = "txtCampoMemoria1"
        Me.txtCampoMemoria1.Size = New System.Drawing.Size(85, 20)
        Me.txtCampoMemoria1.TabIndex = 36
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(17, 337)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(89, 13)
        Me.Label19.TabIndex = 35
        Me.Label19.Text = "Campo4 Memoria"
        '
        'txtCampoMemoria4
        '
        Me.txtCampoMemoria4.Location = New System.Drawing.Point(107, 335)
        Me.txtCampoMemoria4.Name = "txtCampoMemoria4"
        Me.txtCampoMemoria4.Size = New System.Drawing.Size(85, 20)
        Me.txtCampoMemoria4.TabIndex = 34
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(17, 309)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(89, 13)
        Me.Label18.TabIndex = 33
        Me.Label18.Text = "Campo3 Memoria"
        '
        'txtCampoMemoria3
        '
        Me.txtCampoMemoria3.Location = New System.Drawing.Point(107, 307)
        Me.txtCampoMemoria3.Name = "txtCampoMemoria3"
        Me.txtCampoMemoria3.Size = New System.Drawing.Size(85, 20)
        Me.txtCampoMemoria3.TabIndex = 32
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(17, 282)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(89, 13)
        Me.Label17.TabIndex = 31
        Me.Label17.Text = "Campo2 Memoria"
        '
        'txtCampoMemoria2
        '
        Me.txtCampoMemoria2.Location = New System.Drawing.Point(107, 280)
        Me.txtCampoMemoria2.Name = "txtCampoMemoria2"
        Me.txtCampoMemoria2.Size = New System.Drawing.Size(85, 20)
        Me.txtCampoMemoria2.TabIndex = 30
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(18, 224)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(76, 13)
        Me.Label16.TabIndex = 29
        Me.Label16.Text = "Texto memoria"
        '
        'txtMemoria
        '
        Me.txtMemoria.Location = New System.Drawing.Point(108, 222)
        Me.txtMemoria.Name = "txtMemoria"
        Me.txtMemoria.Size = New System.Drawing.Size(85, 20)
        Me.txtMemoria.TabIndex = 28
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(208, 70)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(27, 13)
        Me.Label14.TabIndex = 27
        Me.Label14.Text = "Item"
        '
        'cmbSubtitulo2
        '
        Me.cmbSubtitulo2.FormattingEnabled = True
        Me.cmbSubtitulo2.Location = New System.Drawing.Point(239, 67)
        Me.cmbSubtitulo2.Name = "cmbSubtitulo2"
        Me.cmbSubtitulo2.Size = New System.Drawing.Size(149, 21)
        Me.cmbSubtitulo2.TabIndex = 26
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(15, 69)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(84, 13)
        Me.Label15.TabIndex = 25
        Me.Label15.Text = "Texto Subtitulo2"
        '
        'txtSubtitulo2
        '
        Me.txtSubtitulo2.Location = New System.Drawing.Point(105, 67)
        Me.txtSubtitulo2.Name = "txtSubtitulo2"
        Me.txtSubtitulo2.Size = New System.Drawing.Size(85, 20)
        Me.txtSubtitulo2.TabIndex = 24
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(17, 95)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(73, 13)
        Me.Label13.TabIndex = 23
        Me.Label13.Text = "Código Barras"
        '
        'dgCodigoBarras
        '
        Me.dgCodigoBarras.AllowUserToAddRows = False
        Me.dgCodigoBarras.AllowUserToDeleteRows = False
        Me.dgCodigoBarras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgCodigoBarras.Location = New System.Drawing.Point(18, 115)
        Me.dgCodigoBarras.MultiSelect = False
        Me.dgCodigoBarras.Name = "dgCodigoBarras"
        Me.dgCodigoBarras.Size = New System.Drawing.Size(438, 96)
        Me.dgCodigoBarras.TabIndex = 22
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(207, 47)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(27, 13)
        Me.Label12.TabIndex = 21
        Me.Label12.Text = "Item"
        '
        'cmbSubtitulo1
        '
        Me.cmbSubtitulo1.FormattingEnabled = True
        Me.cmbSubtitulo1.Location = New System.Drawing.Point(238, 44)
        Me.cmbSubtitulo1.Name = "cmbSubtitulo1"
        Me.cmbSubtitulo1.Size = New System.Drawing.Size(149, 21)
        Me.cmbSubtitulo1.TabIndex = 20
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(14, 20)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(62, 13)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Texto Tíulo"
        '
        'txtTituloCaratula
        '
        Me.txtTituloCaratula.Location = New System.Drawing.Point(104, 16)
        Me.txtTituloCaratula.Name = "txtTituloCaratula"
        Me.txtTituloCaratula.Size = New System.Drawing.Size(342, 20)
        Me.txtTituloCaratula.TabIndex = 18
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(14, 46)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(84, 13)
        Me.Label11.TabIndex = 17
        Me.Label11.Text = "Texto Subtitulo1"
        '
        'txtSubtitulo1
        '
        Me.txtSubtitulo1.Location = New System.Drawing.Point(104, 44)
        Me.txtSubtitulo1.Name = "txtSubtitulo1"
        Me.txtSubtitulo1.Size = New System.Drawing.Size(85, 20)
        Me.txtSubtitulo1.TabIndex = 16
        '
        'gbConsultaDatosCaratula
        '
        Me.gbConsultaDatosCaratula.Controls.Add(Me.cmdGuardarConsulta)
        Me.gbConsultaDatosCaratula.Controls.Add(Me.cmdEjecutarConsulta)
        Me.gbConsultaDatosCaratula.Controls.Add(Me.dgDatosConsulta)
        Me.gbConsultaDatosCaratula.Controls.Add(Me.txtWHEREGenerarCaratula)
        Me.gbConsultaDatosCaratula.Controls.Add(Me.Label8)
        Me.gbConsultaDatosCaratula.Controls.Add(Me.Label7)
        Me.gbConsultaDatosCaratula.Controls.Add(Me.txtFROMGenerarCaratula)
        Me.gbConsultaDatosCaratula.Controls.Add(Me.Label10)
        Me.gbConsultaDatosCaratula.Controls.Add(Me.txtSELECTGeneracionCaratula)
        Me.gbConsultaDatosCaratula.Enabled = False
        Me.gbConsultaDatosCaratula.Location = New System.Drawing.Point(6, 36)
        Me.gbConsultaDatosCaratula.Name = "gbConsultaDatosCaratula"
        Me.gbConsultaDatosCaratula.Size = New System.Drawing.Size(493, 200)
        Me.gbConsultaDatosCaratula.TabIndex = 11
        Me.gbConsultaDatosCaratula.TabStop = False
        Me.gbConsultaDatosCaratula.Text = "Consulta Datos Generación Carátula"
        '
        'cmdGuardarConsulta
        '
        Me.cmdGuardarConsulta.BackColor = System.Drawing.Color.Transparent
        Me.cmdGuardarConsulta.EnabledBoton = True
        Me.cmdGuardarConsulta.Location = New System.Drawing.Point(223, 91)
        Me.cmdGuardarConsulta.Name = "cmdGuardarConsulta"
        Me.cmdGuardarConsulta.pImagenMouseEnter = CType(resources.GetObject("cmdGuardarConsulta.pImagenMouseEnter"), System.Drawing.Image)
        Me.cmdGuardarConsulta.pImagenMouseLeave = CType(resources.GetObject("cmdGuardarConsulta.pImagenMouseLeave"), System.Drawing.Image)
        Me.cmdGuardarConsulta.pImagenMouseOver = CType(resources.GetObject("cmdGuardarConsulta.pImagenMouseOver"), System.Drawing.Image)
        Me.cmdGuardarConsulta.Size = New System.Drawing.Size(110, 28)
        Me.cmdGuardarConsulta.TabIndex = 21
        Me.cmdGuardarConsulta.TextoBoton = "Guardar Consulta"
        '
        'cmdEjecutarConsulta
        '
        Me.cmdEjecutarConsulta.BackColor = System.Drawing.Color.Transparent
        Me.cmdEjecutarConsulta.EnabledBoton = True
        Me.cmdEjecutarConsulta.Location = New System.Drawing.Point(352, 91)
        Me.cmdEjecutarConsulta.Name = "cmdEjecutarConsulta"
        Me.cmdEjecutarConsulta.pImagenMouseEnter = CType(resources.GetObject("cmdEjecutarConsulta.pImagenMouseEnter"), System.Drawing.Image)
        Me.cmdEjecutarConsulta.pImagenMouseLeave = CType(resources.GetObject("cmdEjecutarConsulta.pImagenMouseLeave"), System.Drawing.Image)
        Me.cmdEjecutarConsulta.pImagenMouseOver = CType(resources.GetObject("cmdEjecutarConsulta.pImagenMouseOver"), System.Drawing.Image)
        Me.cmdEjecutarConsulta.Size = New System.Drawing.Size(110, 28)
        Me.cmdEjecutarConsulta.TabIndex = 20
        Me.cmdEjecutarConsulta.TextoBoton = "Ejecutar Consulta"
        '
        'dgDatosConsulta
        '
        Me.dgDatosConsulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgDatosConsulta.Location = New System.Drawing.Point(4, 123)
        Me.dgDatosConsulta.Name = "dgDatosConsulta"
        Me.dgDatosConsulta.Size = New System.Drawing.Size(483, 69)
        Me.dgDatosConsulta.TabIndex = 12
        '
        'txtWHEREGenerarCaratula
        '
        Me.txtWHEREGenerarCaratula.Location = New System.Drawing.Point(78, 66)
        Me.txtWHEREGenerarCaratula.Name = "txtWHEREGenerarCaratula"
        Me.txtWHEREGenerarCaratula.Size = New System.Drawing.Size(368, 20)
        Me.txtWHEREGenerarCaratula.TabIndex = 19
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(19, 70)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 13)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "WHERE"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(19, 45)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 13)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "FROM"
        '
        'txtFROMGenerarCaratula
        '
        Me.txtFROMGenerarCaratula.Location = New System.Drawing.Point(78, 41)
        Me.txtFROMGenerarCaratula.Name = "txtFROMGenerarCaratula"
        Me.txtFROMGenerarCaratula.Size = New System.Drawing.Size(368, 20)
        Me.txtFROMGenerarCaratula.TabIndex = 16
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(18, 22)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 13)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "SELECT"
        '
        'txtSELECTGeneracionCaratula
        '
        Me.txtSELECTGeneracionCaratula.Location = New System.Drawing.Point(78, 16)
        Me.txtSELECTGeneracionCaratula.Name = "txtSELECTGeneracionCaratula"
        Me.txtSELECTGeneracionCaratula.Size = New System.Drawing.Size(368, 20)
        Me.txtSELECTGeneracionCaratula.TabIndex = 14
        '
        'cmbProyectosCrearCaratulas
        '
        Me.cmbProyectosCrearCaratulas.FormattingEnabled = True
        Me.cmbProyectosCrearCaratulas.Location = New System.Drawing.Point(67, 6)
        Me.cmbProyectosCrearCaratulas.Name = "cmbProyectosCrearCaratulas"
        Me.cmbProyectosCrearCaratulas.Size = New System.Drawing.Size(392, 21)
        Me.cmbProyectosCrearCaratulas.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Proyecto:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Button1)
        Me.GroupBox3.Controls.Add(Me.CrystalReportViewer1)
        Me.GroupBox3.Controls.Add(Me.CtrlGenerarCaratulas)
        Me.GroupBox3.Location = New System.Drawing.Point(515, 6)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(485, 599)
        Me.GroupBox3.TabIndex = 7
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Generar Caratulas"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(42, 566)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(125, 23)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "Insertar Datos FIP"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.DisplayGroupTree = False
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(6, 19)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(473, 538)
        Me.CrystalReportViewer1.TabIndex = 10
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'CtrlGenerarCaratulas
        '
        Me.CtrlGenerarCaratulas.BackColor = System.Drawing.Color.Transparent
        Me.CtrlGenerarCaratulas.EnabledBoton = True
        Me.CtrlGenerarCaratulas.Location = New System.Drawing.Point(370, 563)
        Me.CtrlGenerarCaratulas.Name = "CtrlGenerarCaratulas"
        Me.CtrlGenerarCaratulas.pImagenMouseEnter = CType(resources.GetObject("CtrlGenerarCaratulas.pImagenMouseEnter"), System.Drawing.Image)
        Me.CtrlGenerarCaratulas.pImagenMouseLeave = CType(resources.GetObject("CtrlGenerarCaratulas.pImagenMouseLeave"), System.Drawing.Image)
        Me.CtrlGenerarCaratulas.pImagenMouseOver = CType(resources.GetObject("CtrlGenerarCaratulas.pImagenMouseOver"), System.Drawing.Image)
        Me.CtrlGenerarCaratulas.Size = New System.Drawing.Size(117, 30)
        Me.CtrlGenerarCaratulas.TabIndex = 9
        Me.CtrlGenerarCaratulas.TextoBoton = "Generar Caratulas"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button6)
        Me.GroupBox2.Controls.Add(Me.Button5)
        Me.GroupBox2.Controls.Add(Me.Button4)
        Me.GroupBox2.Controls.Add(Me.Button3)
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Controls.Add(Me.DataGridView2)
        Me.GroupBox2.Controls.Add(Me.GroupBox1)
        Me.GroupBox2.Location = New System.Drawing.Point(15, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(522, 590)
        Me.GroupBox2.TabIndex = 14
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Consulta Datos Generación Carátula"
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(135, 525)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(57, 56)
        Me.Button6.TabIndex = 25
        Me.Button6.Text = "HC sin NHC"
        Me.Button6.UseVisualStyleBackColor = True
        Me.Button6.Visible = False
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(198, 525)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(57, 56)
        Me.Button5.TabIndex = 24
        Me.Button5.Text = "HC sin SIP FIP"
        Me.Button5.UseVisualStyleBackColor = True
        Me.Button5.Visible = False
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(44, 551)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(103, 23)
        Me.Button4.TabIndex = 23
        Me.Button4.Text = "Button4"
        Me.Button4.UseVisualStyleBackColor = True
        Me.Button4.Visible = False
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(389, 525)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(125, 23)
        Me.Button3.TabIndex = 22
        Me.Button3.Text = "Modificar Datos FIP"
        Me.Button3.UseVisualStyleBackColor = True
        Me.Button3.Visible = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(261, 525)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(125, 23)
        Me.Button2.TabIndex = 11
        Me.Button2.Text = "Buscar NHC"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(0, 227)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        Me.DataGridView2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DataGridView2.RowHeadersVisible = False
        Me.DataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView2.Size = New System.Drawing.Size(513, 278)
        Me.DataGridView2.TabIndex = 12
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtNumpaginas)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label28)
        Me.GroupBox1.Controls.Add(Me.cmdServicios)
        Me.GroupBox1.Controls.Add(Me.gbEpisodios)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmbLote)
        Me.GroupBox1.Controls.Add(Me.txtfechaactual)
        Me.GroupBox1.Controls.Add(Me.lblLonbarcode)
        Me.GroupBox1.Controls.Add(Me.cmLongBarCode)
        Me.GroupBox1.Controls.Add(Me.CheckBox2)
        Me.GroupBox1.Controls.Add(Me.cmdinsertarRegistro)
        Me.GroupBox1.Controls.Add(Me.CheckBox1)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtNumhistoria)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 19)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(507, 202)
        Me.GroupBox1.TabIndex = 21
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " "
        '
        'txtNumpaginas
        '
        Me.txtNumpaginas.Location = New System.Drawing.Point(445, 107)
        Me.txtNumpaginas.Name = "txtNumpaginas"
        Me.txtNumpaginas.Size = New System.Drawing.Size(47, 20)
        Me.txtNumpaginas.TabIndex = 67
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(357, 110)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 13)
        Me.Label4.TabIndex = 66
        Me.Label4.Text = "Num. paginas"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(281, 59)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(45, 13)
        Me.Label28.TabIndex = 64
        Me.Label28.Text = "Servicio"
        '
        'cmdServicios
        '
        Me.cmdServicios.FormattingEnabled = True
        Me.cmdServicios.Location = New System.Drawing.Point(339, 56)
        Me.cmdServicios.Name = "cmdServicios"
        Me.cmdServicios.Size = New System.Drawing.Size(153, 21)
        Me.cmdServicios.TabIndex = 63
        '
        'gbEpisodios
        '
        Me.gbEpisodios.Controls.Add(Me.chk5)
        Me.gbEpisodios.Controls.Add(Me.cmbEpisodios)
        Me.gbEpisodios.Controls.Add(Me.Label3)
        Me.gbEpisodios.Controls.Add(Me.chk20)
        Me.gbEpisodios.Controls.Add(Me.chkall)
        Me.gbEpisodios.Location = New System.Drawing.Point(19, 88)
        Me.gbEpisodios.Name = "gbEpisodios"
        Me.gbEpisodios.Size = New System.Drawing.Size(329, 69)
        Me.gbEpisodios.TabIndex = 62
        Me.gbEpisodios.TabStop = False
        Me.gbEpisodios.Text = "Episodio"
        '
        'chk5
        '
        Me.chk5.AutoSize = True
        Me.chk5.Checked = True
        Me.chk5.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk5.Location = New System.Drawing.Point(54, 46)
        Me.chk5.Name = "chk5"
        Me.chk5.Size = New System.Drawing.Size(94, 17)
        Me.chk5.TabIndex = 62
        Me.chk5.Text = "5 últimos días "
        Me.chk5.UseVisualStyleBackColor = True
        '
        'cmbEpisodios
        '
        Me.cmbEpisodios.FormattingEnabled = True
        Me.cmbEpisodios.Location = New System.Drawing.Point(10, 19)
        Me.cmbEpisodios.Name = "cmbEpisodios"
        Me.cmbEpisodios.Size = New System.Drawing.Size(306, 21)
        Me.cmbEpisodios.TabIndex = 43
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 61
        Me.Label3.Text = "Mostrar"
        '
        'chk20
        '
        Me.chk20.AutoSize = True
        Me.chk20.Location = New System.Drawing.Point(158, 47)
        Me.chk20.Name = "chk20"
        Me.chk20.Size = New System.Drawing.Size(98, 17)
        Me.chk20.TabIndex = 59
        Me.chk20.Text = "20 últmos días "
        Me.chk20.UseVisualStyleBackColor = True
        '
        'chkall
        '
        Me.chkall.AutoSize = True
        Me.chkall.Location = New System.Drawing.Point(265, 48)
        Me.chkall.Name = "chkall"
        Me.chkall.Size = New System.Drawing.Size(52, 17)
        Me.chkall.TabIndex = 60
        Me.chkall.Text = "todos"
        Me.chkall.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(376, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 13)
        Me.Label2.TabIndex = 58
        Me.Label2.Text = "Lote"
        '
        'cmbLote
        '
        Me.cmbLote.FormattingEnabled = True
        Me.cmbLote.Location = New System.Drawing.Point(415, 25)
        Me.cmbLote.Name = "cmbLote"
        Me.cmbLote.Size = New System.Drawing.Size(77, 21)
        Me.cmbLote.TabIndex = 57
        '
        'txtfechaactual
        '
        Me.txtfechaactual.Location = New System.Drawing.Point(136, 165)
        Me.txtfechaactual.Name = "txtfechaactual"
        Me.txtfechaactual.Size = New System.Drawing.Size(139, 20)
        Me.txtfechaactual.TabIndex = 56
        Me.txtfechaactual.Visible = False
        '
        'lblLonbarcode
        '
        Me.lblLonbarcode.AutoSize = True
        Me.lblLonbarcode.Location = New System.Drawing.Point(115, 26)
        Me.lblLonbarcode.Name = "lblLonbarcode"
        Me.lblLonbarcode.Size = New System.Drawing.Size(104, 13)
        Me.lblLonbarcode.TabIndex = 55
        Me.lblLonbarcode.Text = "Long.  código barras"
        '
        'cmLongBarCode
        '
        Me.cmLongBarCode.FormattingEnabled = True
        Me.cmLongBarCode.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6"})
        Me.cmLongBarCode.Location = New System.Drawing.Point(225, 23)
        Me.cmLongBarCode.Name = "cmLongBarCode"
        Me.cmLongBarCode.Size = New System.Drawing.Size(77, 21)
        Me.cmLongBarCode.TabIndex = 54
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(6, 178)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(111, 17)
        Me.CheckBox2.TabIndex = 53
        Me.CheckBox2.Text = "Seleccionar todos"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'cmdinsertarRegistro
        '
        Me.cmdinsertarRegistro.Location = New System.Drawing.Point(395, 158)
        Me.cmdinsertarRegistro.Name = "cmdinsertarRegistro"
        Me.cmdinsertarRegistro.Size = New System.Drawing.Size(106, 38)
        Me.cmdinsertarRegistro.TabIndex = 52
        Me.cmdinsertarRegistro.Text = "Insertar Registro"
        Me.cmdinsertarRegistro.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(19, 25)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(90, 17)
        Me.CheckBox1.TabIndex = 51
        Me.CheckBox1.Text = "Utilizar pistola"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "NHC"
        '
        'txtNumhistoria
        '
        Me.txtNumhistoria.Location = New System.Drawing.Point(79, 57)
        Me.txtNumhistoria.Name = "txtNumhistoria"
        Me.txtNumhistoria.Size = New System.Drawing.Size(156, 20)
        Me.txtNumhistoria.TabIndex = 21
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.pgbCaratulas)
        Me.GroupBox4.Controls.Add(Me.CtrlBotonMediano3)
        Me.GroupBox4.Controls.Add(Me.CrystalReportViewer2)
        Me.GroupBox4.Location = New System.Drawing.Point(543, 3)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(458, 599)
        Me.GroupBox4.TabIndex = 13
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Generar Caratulas"
        '
        'pgbCaratulas
        '
        Me.pgbCaratulas.Location = New System.Drawing.Point(10, 565)
        Me.pgbCaratulas.Name = "pgbCaratulas"
        Me.pgbCaratulas.Size = New System.Drawing.Size(289, 27)
        Me.pgbCaratulas.TabIndex = 11
        '
        'CtrlBotonMediano3
        '
        Me.CtrlBotonMediano3.BackColor = System.Drawing.Color.Transparent
        Me.CtrlBotonMediano3.EnabledBoton = True
        Me.CtrlBotonMediano3.Location = New System.Drawing.Point(322, 563)
        Me.CtrlBotonMediano3.Name = "CtrlBotonMediano3"
        Me.CtrlBotonMediano3.pImagenMouseEnter = CType(resources.GetObject("CtrlBotonMediano3.pImagenMouseEnter"), System.Drawing.Image)
        Me.CtrlBotonMediano3.pImagenMouseLeave = CType(resources.GetObject("CtrlBotonMediano3.pImagenMouseLeave"), System.Drawing.Image)
        Me.CtrlBotonMediano3.pImagenMouseOver = CType(resources.GetObject("CtrlBotonMediano3.pImagenMouseOver"), System.Drawing.Image)
        Me.CtrlBotonMediano3.Size = New System.Drawing.Size(117, 30)
        Me.CtrlBotonMediano3.TabIndex = 9
        Me.CtrlBotonMediano3.TextoBoton = "Generar Caratulas"
        '
        'CrystalReportViewer2
        '
        Me.CrystalReportViewer2.ActiveViewIndex = 0
        Me.CrystalReportViewer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer2.DisplayGroupTree = False
        Me.CrystalReportViewer2.Location = New System.Drawing.Point(8, 19)
        Me.CrystalReportViewer2.Name = "CrystalReportViewer2"
        Me.CrystalReportViewer2.ReportSource = "F:\aplicaciones\dairio\virgengracia\Digitalizacion\Informes\crpCaratula.rpt"
        Me.CrystalReportViewer2.Size = New System.Drawing.Size(444, 538)
        Me.CrystalReportViewer2.TabIndex = 10
        '
        'frmCrearCaratulas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 605)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox4)
        Me.Name = "frmCrearCaratulas"
        Me.Text = "frmCrearCaratulas"
        Me.gbCamposCaratula.ResumeLayout(False)
        Me.gbCamposCaratula.PerformLayout()
        CType(Me.dgCodigoBarras, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbConsultaDatosCaratula.ResumeLayout(False)
        Me.gbConsultaDatosCaratula.PerformLayout()
        CType(Me.dgDatosConsulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gbEpisodios.ResumeLayout(False)
        Me.gbEpisodios.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbCamposCaratula As System.Windows.Forms.GroupBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents cmbCampoMemoria4 As System.Windows.Forms.ComboBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents cmbCampoMemoria3 As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents cmbCampoMemoria2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents cmbcampomemoria1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtCampoMemoria1 As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtCampoMemoria4 As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtCampoMemoria3 As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtCampoMemoria2 As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtMemoria As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cmbSubtitulo2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtSubtitulo2 As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents dgCodigoBarras As System.Windows.Forms.DataGridView
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmbSubtitulo1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtTituloCaratula As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtSubtitulo1 As System.Windows.Forms.TextBox
    Friend WithEvents gbConsultaDatosCaratula As System.Windows.Forms.GroupBox
    Friend WithEvents cmdGuardarConsulta As LibreriaCadenaProduccion.Controles.Botones.CtrlBotonMediano
    Friend WithEvents cmdEjecutarConsulta As LibreriaCadenaProduccion.Controles.Botones.CtrlBotonMediano
    Friend WithEvents dgDatosConsulta As System.Windows.Forms.DataGridView
    Friend WithEvents txtWHEREGenerarCaratula As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtFROMGenerarCaratula As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtSELECTGeneracionCaratula As System.Windows.Forms.TextBox
    Friend WithEvents cmbProyectosCrearCaratulas As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CtrlGenerarCaratulas As LibreriaCadenaProduccion.Controles.Botones.CtrlBotonMediano
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents CrystalReportViewer2 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CtrlBotonMediano3 As LibreriaCadenaProduccion.Controles.Botones.CtrlBotonMediano
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNumhistoria As System.Windows.Forms.TextBox
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents crpCaratula1 As Digitalización.crpCaratula
    Friend WithEvents cmbEpisodios As System.Windows.Forms.ComboBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents cmdinsertarRegistro As System.Windows.Forms.Button
    Friend WithEvents pgbCaratulas As System.Windows.Forms.ProgressBar
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents lblLonbarcode As System.Windows.Forms.Label
    Friend WithEvents cmLongBarCode As System.Windows.Forms.ComboBox
    Friend WithEvents txtfechaactual As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbLote As System.Windows.Forms.ComboBox
    Friend WithEvents gbEpisodios As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chk20 As System.Windows.Forms.CheckBox
    Friend WithEvents chkall As System.Windows.Forms.CheckBox
    Friend WithEvents chk5 As System.Windows.Forms.CheckBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents cmdServicios As System.Windows.Forms.ComboBox
    Friend WithEvents txtNumpaginas As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
