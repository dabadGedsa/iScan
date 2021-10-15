<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdministrar
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAdministrar))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tabConfiguracionProyectos = New System.Windows.Forms.TabPage()
        Me.cmbNuevoProyecto = New LibreriaCadenaProduccion.Controles.Botones.CtrlBotonMediano()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dgCamposCodigoBarras = New System.Windows.Forms.DataGridView()
        Me.NombreCampo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Longitud = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Orden = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbBorrarestructura = New LibreriaCadenaProduccion.Controles.Botones.CtrlBotonMediano()
        Me.cmbGuardarEstructura = New LibreriaCadenaProduccion.Controles.Botones.CtrlBotonMediano()
        Me.cmbCabeceraBarcode = New System.Windows.Forms.ComboBox()
        Me.cmbNuevaCabecera = New LibreriaCadenaProduccion.Controles.Botones.CtrlBotonMediano()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lstvCamposTablaDocumentos = New System.Windows.Forms.ListView()
        Me.Columna = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtLotefinal = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtLoteInicial = New System.Windows.Forms.TextBox()
        Me.cmdCrearLotes = New LibreriaCadenaProduccion.Controles.Botones.CtrlBotonMediano()
        Me.cmbProyecto = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tabControlProcesos = New System.Windows.Forms.TabPage()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.pbprocesosDocumentos = New System.Windows.Forms.ProgressBar()
        Me.pgbProcesoslotes = New System.Windows.Forms.ProgressBar()
        Me.AxImgEdit1 = New AxImgeditLibCtl.AxImgEdit()
        Me.rbtMensajes = New System.Windows.Forms.RichTextBox()
        Me.gbControlProcesos = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dgvEnviados = New System.Windows.Forms.DataGridView()
        Me.cmsExportacion = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EnviarATraspasoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EnviarAFinalizaciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.dgvExportados = New System.Windows.Forms.DataGridView()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.dgvImportacion = New System.Windows.Forms.DataGridView()
        Me.cmsImportacion = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EnviarADigitalizarLosLotesSeleccionadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EnviarAVERIFICARLosLotesSeleccionadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VisualizarDocumentosLoteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Verificación = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.dgvFinalizacion = New System.Windows.Forms.DataGridView()
        Me.cmsFinalizacion = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EnviarACORRECCIONPAEDLosLotesSeleccionadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FINALIZARLosLotesSeleccionadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VisualizarDocumentosLotesSelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.dgvCorreccionPAED = New System.Windows.Forms.DataGridView()
        Me.cmscorreccionPAED = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EnviarAINDIZACIÓNLosLotesSeleccionadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EnviarAFinalizaciónLosLotesSeleccionadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VisualizarDocumentosLoteToolStripMenuItem6 = New System.Windows.Forms.ToolStripMenuItem()
        Me.dgvIndizacion = New System.Windows.Forms.DataGridView()
        Me.cmsInidizacion = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EnviarATRASPASOLosLotesSeleccinadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EnviarACORRECCIÓNPAEDLosLotesSeleccionadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VisualizarDocumentosLoteToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.dgvTraspaso = New System.Windows.Forms.DataGridView()
        Me.cmsTraspaso = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EnviarACORRECCIÓNDIGILosLotesSeleccionadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CrearDATEnviarAIandizaciónLosLotesSeleccionadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VisualizarDocumentosLoteToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportarLoteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.dgvCorreccionDigi = New System.Windows.Forms.DataGridView()
        Me.cmsCorreccionDigi = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EnviarAVERIFICACIÓNLosLotesSeleccionadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EnviarATRASPASOLosLotesSeleccionadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VisualizarDocumentosLoteToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.dgvVerificación = New System.Windows.Forms.DataGridView()
        Me.cmsVerificacion = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EnviarAIPORTACIÓNLosLotesSeleccionadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EnviarACORRECCIÓNLosLotesSeleccionadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VisualizarDocumentosLoteToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.dgvDigitalizacion = New System.Windows.Forms.DataGridView()
        Me.cmsDigitalizacion = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EnviarAIMPORTACIÓNLosLotesSeleccionadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VisualizarDocumentosLoteToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CmbProyectosControlProcesos = New System.Windows.Forms.ComboBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.crpCaratula1 = New Digitalización.crpCaratula()
        Me.TabControl1.SuspendLayout()
        Me.tabConfiguracionProyectos.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgCamposCodigoBarras, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.txtLotefinal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabControlProcesos.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.AxImgEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbControlProcesos.SuspendLayout()
        CType(Me.dgvEnviados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsExportacion.SuspendLayout()
        CType(Me.dgvExportados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvImportacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsImportacion.SuspendLayout()
        CType(Me.dgvFinalizacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsFinalizacion.SuspendLayout()
        CType(Me.dgvCorreccionPAED, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmscorreccionPAED.SuspendLayout()
        CType(Me.dgvIndizacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsInidizacion.SuspendLayout()
        CType(Me.dgvTraspaso, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsTraspaso.SuspendLayout()
        CType(Me.dgvCorreccionDigi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsCorreccionDigi.SuspendLayout()
        CType(Me.dgvVerificación, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsVerificacion.SuspendLayout()
        CType(Me.dgvDigitalizacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsDigitalizacion.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tabConfiguracionProyectos)
        Me.TabControl1.Controls.Add(Me.tabControlProcesos)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1095, 639)
        Me.TabControl1.TabIndex = 0
        '
        'tabConfiguracionProyectos
        '
        Me.tabConfiguracionProyectos.Controls.Add(Me.cmbNuevoProyecto)
        Me.tabConfiguracionProyectos.Controls.Add(Me.GroupBox2)
        Me.tabConfiguracionProyectos.Controls.Add(Me.GroupBox1)
        Me.tabConfiguracionProyectos.Controls.Add(Me.cmbProyecto)
        Me.tabConfiguracionProyectos.Controls.Add(Me.Label1)
        Me.tabConfiguracionProyectos.Location = New System.Drawing.Point(4, 22)
        Me.tabConfiguracionProyectos.Name = "tabConfiguracionProyectos"
        Me.tabConfiguracionProyectos.Padding = New System.Windows.Forms.Padding(3)
        Me.tabConfiguracionProyectos.Size = New System.Drawing.Size(1087, 613)
        Me.tabConfiguracionProyectos.TabIndex = 0
        Me.tabConfiguracionProyectos.Text = "Configuración Proyectos"
        Me.tabConfiguracionProyectos.UseVisualStyleBackColor = True
        '
        'cmbNuevoProyecto
        '
        Me.cmbNuevoProyecto.BackColor = System.Drawing.Color.Transparent
        Me.cmbNuevoProyecto.EnabledBoton = True
        Me.cmbNuevoProyecto.Location = New System.Drawing.Point(490, 36)
        Me.cmbNuevoProyecto.Name = "cmbNuevoProyecto"
        Me.cmbNuevoProyecto.pImagenMouseEnter = CType(resources.GetObject("cmbNuevoProyecto.pImagenMouseEnter"), System.Drawing.Image)
        Me.cmbNuevoProyecto.pImagenMouseLeave = CType(resources.GetObject("cmbNuevoProyecto.pImagenMouseLeave"), System.Drawing.Image)
        Me.cmbNuevoProyecto.pImagenMouseOver = CType(resources.GetObject("cmbNuevoProyecto.pImagenMouseOver"), System.Drawing.Image)
        Me.cmbNuevoProyecto.Size = New System.Drawing.Size(104, 22)
        Me.cmbNuevoProyecto.TabIndex = 5
        Me.cmbNuevoProyecto.TextoBoton = "Nuevo Proyecto"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dgCamposCodigoBarras)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.cmbBorrarestructura)
        Me.GroupBox2.Controls.Add(Me.cmbGuardarEstructura)
        Me.GroupBox2.Controls.Add(Me.cmbCabeceraBarcode)
        Me.GroupBox2.Controls.Add(Me.cmbNuevaCabecera)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.lstvCamposTablaDocumentos)
        Me.GroupBox2.Controls.Add(Me.PictureBox1)
        Me.GroupBox2.Enabled = False
        Me.GroupBox2.Location = New System.Drawing.Point(20, 151)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(581, 371)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Establecer estructuras codigos de barras "
        '
        'dgCamposCodigoBarras
        '
        Me.dgCamposCodigoBarras.AllowUserToAddRows = False
        Me.dgCamposCodigoBarras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgCamposCodigoBarras.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NombreCampo, Me.Longitud, Me.Orden})
        Me.dgCamposCodigoBarras.Location = New System.Drawing.Point(178, 130)
        Me.dgCamposCodigoBarras.MultiSelect = False
        Me.dgCamposCodigoBarras.Name = "dgCamposCodigoBarras"
        Me.dgCamposCodigoBarras.Size = New System.Drawing.Size(397, 178)
        Me.dgCamposCodigoBarras.TabIndex = 9
        '
        'NombreCampo
        '
        Me.NombreCampo.HeaderText = "Nombre Campo"
        Me.NombreCampo.Name = "NombreCampo"
        Me.NombreCampo.Width = 150
        '
        'Longitud
        '
        Me.Longitud.HeaderText = "Longitud"
        Me.Longitud.Name = "Longitud"
        '
        'Orden
        '
        Me.Orden.HeaderText = "Orden"
        Me.Orden.Name = "Orden"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(198, 106)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Cabecera"
        '
        'cmbBorrarestructura
        '
        Me.cmbBorrarestructura.BackColor = System.Drawing.Color.Transparent
        Me.cmbBorrarestructura.EnabledBoton = True
        Me.cmbBorrarestructura.Location = New System.Drawing.Point(294, 332)
        Me.cmbBorrarestructura.Name = "cmbBorrarestructura"
        Me.cmbBorrarestructura.pImagenMouseEnter = CType(resources.GetObject("cmbBorrarestructura.pImagenMouseEnter"), System.Drawing.Image)
        Me.cmbBorrarestructura.pImagenMouseLeave = CType(resources.GetObject("cmbBorrarestructura.pImagenMouseLeave"), System.Drawing.Image)
        Me.cmbBorrarestructura.pImagenMouseOver = CType(resources.GetObject("cmbBorrarestructura.pImagenMouseOver"), System.Drawing.Image)
        Me.cmbBorrarestructura.Size = New System.Drawing.Size(117, 30)
        Me.cmbBorrarestructura.TabIndex = 7
        Me.cmbBorrarestructura.TextoBoton = "Borrar estructura"
        '
        'cmbGuardarEstructura
        '
        Me.cmbGuardarEstructura.BackColor = System.Drawing.Color.Transparent
        Me.cmbGuardarEstructura.EnabledBoton = True
        Me.cmbGuardarEstructura.Location = New System.Drawing.Point(428, 332)
        Me.cmbGuardarEstructura.Name = "cmbGuardarEstructura"
        Me.cmbGuardarEstructura.pImagenMouseEnter = CType(resources.GetObject("cmbGuardarEstructura.pImagenMouseEnter"), System.Drawing.Image)
        Me.cmbGuardarEstructura.pImagenMouseLeave = CType(resources.GetObject("cmbGuardarEstructura.pImagenMouseLeave"), System.Drawing.Image)
        Me.cmbGuardarEstructura.pImagenMouseOver = CType(resources.GetObject("cmbGuardarEstructura.pImagenMouseOver"), System.Drawing.Image)
        Me.cmbGuardarEstructura.Size = New System.Drawing.Size(117, 30)
        Me.cmbGuardarEstructura.TabIndex = 6
        Me.cmbGuardarEstructura.TextoBoton = "Guardar estructura"
        '
        'cmbCabeceraBarcode
        '
        Me.cmbCabeceraBarcode.FormattingEnabled = True
        Me.cmbCabeceraBarcode.Location = New System.Drawing.Point(257, 102)
        Me.cmbCabeceraBarcode.Name = "cmbCabeceraBarcode"
        Me.cmbCabeceraBarcode.Size = New System.Drawing.Size(105, 21)
        Me.cmbCabeceraBarcode.TabIndex = 5
        '
        'cmbNuevaCabecera
        '
        Me.cmbNuevaCabecera.BackColor = System.Drawing.Color.Transparent
        Me.cmbNuevaCabecera.EnabledBoton = True
        Me.cmbNuevaCabecera.Location = New System.Drawing.Point(411, 102)
        Me.cmbNuevaCabecera.Name = "cmbNuevaCabecera"
        Me.cmbNuevaCabecera.pImagenMouseEnter = CType(resources.GetObject("cmbNuevaCabecera.pImagenMouseEnter"), System.Drawing.Image)
        Me.cmbNuevaCabecera.pImagenMouseLeave = CType(resources.GetObject("cmbNuevaCabecera.pImagenMouseLeave"), System.Drawing.Image)
        Me.cmbNuevaCabecera.pImagenMouseOver = CType(resources.GetObject("cmbNuevaCabecera.pImagenMouseOver"), System.Drawing.Image)
        Me.cmbNuevaCabecera.Size = New System.Drawing.Size(104, 22)
        Me.cmbNuevaCabecera.TabIndex = 4
        Me.cmbNuevaCabecera.TextoBoton = "Nueva Cabecera"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(22, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(148, 42)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Campos de la tabla documentos a buscar en el codigo de barras "
        '
        'lstvCamposTablaDocumentos
        '
        Me.lstvCamposTablaDocumentos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Columna})
        Me.lstvCamposTablaDocumentos.FullRowSelect = True
        Me.lstvCamposTablaDocumentos.HideSelection = False
        Me.lstvCamposTablaDocumentos.Location = New System.Drawing.Point(23, 69)
        Me.lstvCamposTablaDocumentos.MultiSelect = False
        Me.lstvCamposTablaDocumentos.Name = "lstvCamposTablaDocumentos"
        Me.lstvCamposTablaDocumentos.Size = New System.Drawing.Size(147, 296)
        Me.lstvCamposTablaDocumentos.TabIndex = 2
        Me.lstvCamposTablaDocumentos.UseCompatibleStateImageBehavior = False
        Me.lstvCamposTablaDocumentos.View = System.Windows.Forms.View.Details
        '
        'Columna
        '
        Me.Columna.Text = "Columna"
        Me.Columna.Width = 142
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Digitalización.My.Resources.Resources.Code_128_Barcode_Graphic
        Me.PictureBox1.Location = New System.Drawing.Point(192, 19)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(356, 60)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtLotefinal)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtLoteInicial)
        Me.GroupBox1.Controls.Add(Me.cmdCrearLotes)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Location = New System.Drawing.Point(19, 73)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(581, 75)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Crear Lotes"
        '
        'txtLotefinal
        '
        Me.txtLotefinal.Location = New System.Drawing.Point(215, 41)
        Me.txtLotefinal.Maximum = New Decimal(New Integer() {1316134912, 2328, 0, 0})
        Me.txtLotefinal.Name = "txtLotefinal"
        Me.txtLotefinal.Size = New System.Drawing.Size(120, 20)
        Me.txtLotefinal.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(212, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Lote Final"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(24, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Lote Inicial"
        '
        'txtLoteInicial
        '
        Me.txtLoteInicial.Location = New System.Drawing.Point(27, 40)
        Me.txtLoteInicial.Name = "txtLoteInicial"
        Me.txtLoteInicial.ReadOnly = True
        Me.txtLoteInicial.Size = New System.Drawing.Size(111, 20)
        Me.txtLoteInicial.TabIndex = 3
        '
        'cmdCrearLotes
        '
        Me.cmdCrearLotes.BackColor = System.Drawing.Color.Transparent
        Me.cmdCrearLotes.EnabledBoton = True
        Me.cmdCrearLotes.Location = New System.Drawing.Point(401, 35)
        Me.cmdCrearLotes.Name = "cmdCrearLotes"
        Me.cmdCrearLotes.pImagenMouseEnter = CType(resources.GetObject("cmdCrearLotes.pImagenMouseEnter"), System.Drawing.Image)
        Me.cmdCrearLotes.pImagenMouseLeave = CType(resources.GetObject("cmdCrearLotes.pImagenMouseLeave"), System.Drawing.Image)
        Me.cmdCrearLotes.pImagenMouseOver = CType(resources.GetObject("cmdCrearLotes.pImagenMouseOver"), System.Drawing.Image)
        Me.cmdCrearLotes.Size = New System.Drawing.Size(90, 30)
        Me.cmdCrearLotes.TabIndex = 2
        Me.cmdCrearLotes.TextoBoton = "Crear Lotes"
        '
        'cmbProyecto
        '
        Me.cmbProyecto.FormattingEnabled = True
        Me.cmbProyecto.Location = New System.Drawing.Point(74, 37)
        Me.cmbProyecto.Name = "cmbProyecto"
        Me.cmbProyecto.Size = New System.Drawing.Size(392, 21)
        Me.cmbProyecto.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Proyecto:"
        '
        'tabControlProcesos
        '
        Me.tabControlProcesos.Controls.Add(Me.Button3)
        Me.tabControlProcesos.Controls.Add(Me.GroupBox5)
        Me.tabControlProcesos.Controls.Add(Me.gbControlProcesos)
        Me.tabControlProcesos.Controls.Add(Me.CmbProyectosControlProcesos)
        Me.tabControlProcesos.Controls.Add(Me.Label25)
        Me.tabControlProcesos.Location = New System.Drawing.Point(4, 22)
        Me.tabControlProcesos.Name = "tabControlProcesos"
        Me.tabControlProcesos.Size = New System.Drawing.Size(1087, 613)
        Me.tabControlProcesos.TabIndex = 2
        Me.tabControlProcesos.Text = "Control Procesos"
        Me.tabControlProcesos.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.Location = New System.Drawing.Point(870, 3)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(92, 65)
        Me.Button3.TabIndex = 7
        Me.Button3.Text = "CREAR DVD"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Button1)
        Me.GroupBox5.Controls.Add(Me.pbprocesosDocumentos)
        Me.GroupBox5.Controls.Add(Me.pgbProcesoslotes)
        Me.GroupBox5.Controls.Add(Me.AxImgEdit1)
        Me.GroupBox5.Controls.Add(Me.rbtMensajes)
        Me.GroupBox5.Location = New System.Drawing.Point(35, 469)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(1037, 136)
        Me.GroupBox5.TabIndex = 5
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Mensajes"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(723, 79)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(30, 24)
        Me.Button1.TabIndex = 104
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'pbprocesosDocumentos
        '
        Me.pbprocesosDocumentos.Location = New System.Drawing.Point(463, 46)
        Me.pbprocesosDocumentos.Name = "pbprocesosDocumentos"
        Me.pbprocesosDocumentos.Size = New System.Drawing.Size(291, 21)
        Me.pbprocesosDocumentos.TabIndex = 103
        '
        'pgbProcesoslotes
        '
        Me.pgbProcesoslotes.Location = New System.Drawing.Point(463, 19)
        Me.pgbProcesoslotes.Name = "pgbProcesoslotes"
        Me.pgbProcesoslotes.Size = New System.Drawing.Size(291, 21)
        Me.pgbProcesoslotes.TabIndex = 102
        '
        'AxImgEdit1
        '
        Me.AxImgEdit1.Location = New System.Drawing.Point(773, 16)
        Me.AxImgEdit1.Name = "AxImgEdit1"
        Me.AxImgEdit1.OcxState = CType(resources.GetObject("AxImgEdit1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxImgEdit1.Size = New System.Drawing.Size(251, 114)
        Me.AxImgEdit1.TabIndex = 101
        Me.AxImgEdit1.TabStop = False
        Me.AxImgEdit1.Tag = "100"
        '
        'rbtMensajes
        '
        Me.rbtMensajes.Location = New System.Drawing.Point(6, 19)
        Me.rbtMensajes.Name = "rbtMensajes"
        Me.rbtMensajes.Size = New System.Drawing.Size(441, 114)
        Me.rbtMensajes.TabIndex = 0
        Me.rbtMensajes.Text = ""
        '
        'gbControlProcesos
        '
        Me.gbControlProcesos.Controls.Add(Me.Label6)
        Me.gbControlProcesos.Controls.Add(Me.dgvEnviados)
        Me.gbControlProcesos.Controls.Add(Me.Label33)
        Me.gbControlProcesos.Controls.Add(Me.dgvExportados)
        Me.gbControlProcesos.Controls.Add(Me.Label27)
        Me.gbControlProcesos.Controls.Add(Me.dgvImportacion)
        Me.gbControlProcesos.Controls.Add(Me.Label32)
        Me.gbControlProcesos.Controls.Add(Me.Label31)
        Me.gbControlProcesos.Controls.Add(Me.Label30)
        Me.gbControlProcesos.Controls.Add(Me.Label29)
        Me.gbControlProcesos.Controls.Add(Me.Label28)
        Me.gbControlProcesos.Controls.Add(Me.Verificación)
        Me.gbControlProcesos.Controls.Add(Me.Label26)
        Me.gbControlProcesos.Controls.Add(Me.dgvFinalizacion)
        Me.gbControlProcesos.Controls.Add(Me.dgvCorreccionPAED)
        Me.gbControlProcesos.Controls.Add(Me.dgvIndizacion)
        Me.gbControlProcesos.Controls.Add(Me.dgvTraspaso)
        Me.gbControlProcesos.Controls.Add(Me.dgvCorreccionDigi)
        Me.gbControlProcesos.Controls.Add(Me.dgvVerificación)
        Me.gbControlProcesos.Controls.Add(Me.dgvDigitalizacion)
        Me.gbControlProcesos.Location = New System.Drawing.Point(35, 68)
        Me.gbControlProcesos.Name = "gbControlProcesos"
        Me.gbControlProcesos.Size = New System.Drawing.Size(1037, 392)
        Me.gbControlProcesos.TabIndex = 4
        Me.gbControlProcesos.TabStop = False
        Me.gbControlProcesos.Text = "Procesos"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(949, 33)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 13)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Enviados"
        '
        'dgvEnviados
        '
        Me.dgvEnviados.AllowUserToAddRows = False
        Me.dgvEnviados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEnviados.Location = New System.Drawing.Point(942, 52)
        Me.dgvEnviados.Name = "dgvEnviados"
        Me.dgvEnviados.RowHeadersVisible = False
        Me.dgvEnviados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvEnviados.Size = New System.Drawing.Size(82, 334)
        Me.dgvEnviados.TabIndex = 19
        '
        'cmsExportacion
        '
        Me.cmsExportacion.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EnviarATraspasoToolStripMenuItem, Me.EnviarAFinalizaciónToolStripMenuItem})
        Me.cmsExportacion.Name = "cmsExportacion"
        Me.cmsExportacion.Size = New System.Drawing.Size(181, 70)
        '
        'EnviarATraspasoToolStripMenuItem
        '
        Me.EnviarATraspasoToolStripMenuItem.Name = "EnviarATraspasoToolStripMenuItem"
        Me.EnviarATraspasoToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.EnviarATraspasoToolStripMenuItem.Text = "Enviar a Traspaso"
        '
        'EnviarAFinalizaciónToolStripMenuItem
        '
        Me.EnviarAFinalizaciónToolStripMenuItem.Name = "EnviarAFinalizaciónToolStripMenuItem"
        Me.EnviarAFinalizaciónToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.EnviarAFinalizaciónToolStripMenuItem.Text = "Enviar a Finalización"
        Me.EnviarAFinalizaciónToolStripMenuItem.Visible = False
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(852, 33)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(60, 13)
        Me.Label33.TabIndex = 18
        Me.Label33.Text = "Exportados"
        '
        'dgvExportados
        '
        Me.dgvExportados.AllowUserToAddRows = False
        Me.dgvExportados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvExportados.ContextMenuStrip = Me.cmsExportacion
        Me.dgvExportados.Location = New System.Drawing.Point(845, 52)
        Me.dgvExportados.Name = "dgvExportados"
        Me.dgvExportados.RowHeadersVisible = False
        Me.dgvExportados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvExportados.Size = New System.Drawing.Size(82, 334)
        Me.dgvExportados.TabIndex = 17
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(126, 33)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(62, 13)
        Me.Label27.TabIndex = 16
        Me.Label27.Text = "Importación"
        '
        'dgvImportacion
        '
        Me.dgvImportacion.AllowUserToAddRows = False
        Me.dgvImportacion.AllowUserToDeleteRows = False
        Me.dgvImportacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvImportacion.ContextMenuStrip = Me.cmsImportacion
        Me.dgvImportacion.Location = New System.Drawing.Point(118, 52)
        Me.dgvImportacion.Name = "dgvImportacion"
        Me.dgvImportacion.ReadOnly = True
        Me.dgvImportacion.RowHeadersVisible = False
        Me.dgvImportacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvImportacion.Size = New System.Drawing.Size(82, 334)
        Me.dgvImportacion.TabIndex = 14
        '
        'cmsImportacion
        '
        Me.cmsImportacion.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EnviarADigitalizarLosLotesSeleccionadosToolStripMenuItem, Me.EnviarAVERIFICARLosLotesSeleccionadosToolStripMenuItem, Me.VisualizarDocumentosLoteToolStripMenuItem})
        Me.cmsImportacion.Name = "cmsImportacion"
        Me.cmsImportacion.Size = New System.Drawing.Size(308, 70)
        '
        'EnviarADigitalizarLosLotesSeleccionadosToolStripMenuItem
        '
        Me.EnviarADigitalizarLosLotesSeleccionadosToolStripMenuItem.Name = "EnviarADigitalizarLosLotesSeleccionadosToolStripMenuItem"
        Me.EnviarADigitalizarLosLotesSeleccionadosToolStripMenuItem.Size = New System.Drawing.Size(307, 22)
        Me.EnviarADigitalizarLosLotesSeleccionadosToolStripMenuItem.Text = "Enviar a DIGITALIZAR los lotes seleccionados"
        '
        'EnviarAVERIFICARLosLotesSeleccionadosToolStripMenuItem
        '
        Me.EnviarAVERIFICARLosLotesSeleccionadosToolStripMenuItem.Name = "EnviarAVERIFICARLosLotesSeleccionadosToolStripMenuItem"
        Me.EnviarAVERIFICARLosLotesSeleccionadosToolStripMenuItem.Size = New System.Drawing.Size(307, 22)
        Me.EnviarAVERIFICARLosLotesSeleccionadosToolStripMenuItem.Text = "IMPORTAR los lotes seleccionados"
        '
        'VisualizarDocumentosLoteToolStripMenuItem
        '
        Me.VisualizarDocumentosLoteToolStripMenuItem.Name = "VisualizarDocumentosLoteToolStripMenuItem"
        Me.VisualizarDocumentosLoteToolStripMenuItem.Size = New System.Drawing.Size(307, 22)
        Me.VisualizarDocumentosLoteToolStripMenuItem.Text = "Visualizar documentos lote"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(759, 33)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(62, 13)
        Me.Label32.TabIndex = 13
        Me.Label32.Text = "Finalización"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(640, 33)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(90, 13)
        Me.Label31.TabIndex = 12
        Me.Label31.Text = "Corrección PAED"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(554, 33)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(55, 13)
        Me.Label30.TabIndex = 11
        Me.Label30.Text = "Indización"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(448, 33)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(51, 13)
        Me.Label29.TabIndex = 10
        Me.Label29.Text = "Traspaso"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(328, 33)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(82, 13)
        Me.Label28.TabIndex = 9
        Me.Label28.Text = "Corrección Digi."
        '
        'Verificación
        '
        Me.Verificación.AutoSize = True
        Me.Verificación.Location = New System.Drawing.Point(227, 33)
        Me.Verificación.Name = "Verificación"
        Me.Verificación.Size = New System.Drawing.Size(62, 13)
        Me.Verificación.TabIndex = 8
        Me.Verificación.Text = "Verificación"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(26, 33)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(69, 13)
        Me.Label26.TabIndex = 7
        Me.Label26.Text = "Digitalización"
        '
        'dgvFinalizacion
        '
        Me.dgvFinalizacion.AllowUserToAddRows = False
        Me.dgvFinalizacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFinalizacion.ContextMenuStrip = Me.cmsFinalizacion
        Me.dgvFinalizacion.Location = New System.Drawing.Point(748, 52)
        Me.dgvFinalizacion.Name = "dgvFinalizacion"
        Me.dgvFinalizacion.RowHeadersVisible = False
        Me.dgvFinalizacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvFinalizacion.Size = New System.Drawing.Size(82, 334)
        Me.dgvFinalizacion.TabIndex = 6
        '
        'cmsFinalizacion
        '
        Me.cmsFinalizacion.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EnviarACORRECCIONPAEDLosLotesSeleccionadosToolStripMenuItem, Me.FINALIZARLosLotesSeleccionadosToolStripMenuItem, Me.VisualizarDocumentosLotesSelToolStripMenuItem})
        Me.cmsFinalizacion.Name = "cmsFinalizacion"
        Me.cmsFinalizacion.Size = New System.Drawing.Size(350, 70)
        '
        'EnviarACORRECCIONPAEDLosLotesSeleccionadosToolStripMenuItem
        '
        Me.EnviarACORRECCIONPAEDLosLotesSeleccionadosToolStripMenuItem.Name = "EnviarACORRECCIONPAEDLosLotesSeleccionadosToolStripMenuItem"
        Me.EnviarACORRECCIONPAEDLosLotesSeleccionadosToolStripMenuItem.Size = New System.Drawing.Size(349, 22)
        Me.EnviarACORRECCIONPAEDLosLotesSeleccionadosToolStripMenuItem.Text = "Enviar a CORRECCION PAED los lotes seleccionados "
        '
        'FINALIZARLosLotesSeleccionadosToolStripMenuItem
        '
        Me.FINALIZARLosLotesSeleccionadosToolStripMenuItem.Name = "FINALIZARLosLotesSeleccionadosToolStripMenuItem"
        Me.FINALIZARLosLotesSeleccionadosToolStripMenuItem.Size = New System.Drawing.Size(349, 22)
        Me.FINALIZARLosLotesSeleccionadosToolStripMenuItem.Text = "EXPORTAR los lotes seleccionados"
        '
        'VisualizarDocumentosLotesSelToolStripMenuItem
        '
        Me.VisualizarDocumentosLotesSelToolStripMenuItem.Name = "VisualizarDocumentosLotesSelToolStripMenuItem"
        Me.VisualizarDocumentosLotesSelToolStripMenuItem.Size = New System.Drawing.Size(349, 22)
        Me.VisualizarDocumentosLotesSelToolStripMenuItem.Text = "Visualizar documentos lote"
        '
        'dgvCorreccionPAED
        '
        Me.dgvCorreccionPAED.AllowUserToAddRows = False
        Me.dgvCorreccionPAED.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCorreccionPAED.ContextMenuStrip = Me.cmscorreccionPAED
        Me.dgvCorreccionPAED.Location = New System.Drawing.Point(643, 52)
        Me.dgvCorreccionPAED.Name = "dgvCorreccionPAED"
        Me.dgvCorreccionPAED.RowHeadersVisible = False
        Me.dgvCorreccionPAED.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCorreccionPAED.Size = New System.Drawing.Size(82, 334)
        Me.dgvCorreccionPAED.TabIndex = 5
        '
        'cmscorreccionPAED
        '
        Me.cmscorreccionPAED.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EnviarAINDIZACIÓNLosLotesSeleccionadosToolStripMenuItem, Me.EnviarAFinalizaciónLosLotesSeleccionadosToolStripMenuItem, Me.VisualizarDocumentosLoteToolStripMenuItem6})
        Me.cmscorreccionPAED.Name = "ContextMenuStrip1"
        Me.cmscorreccionPAED.Size = New System.Drawing.Size(321, 70)
        '
        'EnviarAINDIZACIÓNLosLotesSeleccionadosToolStripMenuItem
        '
        Me.EnviarAINDIZACIÓNLosLotesSeleccionadosToolStripMenuItem.Name = "EnviarAINDIZACIÓNLosLotesSeleccionadosToolStripMenuItem"
        Me.EnviarAINDIZACIÓNLosLotesSeleccionadosToolStripMenuItem.Size = New System.Drawing.Size(320, 22)
        Me.EnviarAINDIZACIÓNLosLotesSeleccionadosToolStripMenuItem.Text = "Enviar a INDIZACIÓN los lotes seleccionados"
        '
        'EnviarAFinalizaciónLosLotesSeleccionadosToolStripMenuItem
        '
        Me.EnviarAFinalizaciónLosLotesSeleccionadosToolStripMenuItem.Name = "EnviarAFinalizaciónLosLotesSeleccionadosToolStripMenuItem"
        Me.EnviarAFinalizaciónLosLotesSeleccionadosToolStripMenuItem.Size = New System.Drawing.Size(320, 22)
        Me.EnviarAFinalizaciónLosLotesSeleccionadosToolStripMenuItem.Text = "Enviar a FINALIZACIÓN los lotes seleccionados"
        '
        'VisualizarDocumentosLoteToolStripMenuItem6
        '
        Me.VisualizarDocumentosLoteToolStripMenuItem6.Name = "VisualizarDocumentosLoteToolStripMenuItem6"
        Me.VisualizarDocumentosLoteToolStripMenuItem6.Size = New System.Drawing.Size(320, 22)
        Me.VisualizarDocumentosLoteToolStripMenuItem6.Text = "Visualizar documentos lote"
        '
        'dgvIndizacion
        '
        Me.dgvIndizacion.AllowUserToAddRows = False
        Me.dgvIndizacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvIndizacion.ContextMenuStrip = Me.cmsInidizacion
        Me.dgvIndizacion.Location = New System.Drawing.Point(538, 52)
        Me.dgvIndizacion.Name = "dgvIndizacion"
        Me.dgvIndizacion.RowHeadersVisible = False
        Me.dgvIndizacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvIndizacion.Size = New System.Drawing.Size(82, 334)
        Me.dgvIndizacion.TabIndex = 4
        '
        'cmsInidizacion
        '
        Me.cmsInidizacion.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EnviarATRASPASOLosLotesSeleccinadosToolStripMenuItem, Me.EnviarACORRECCIÓNPAEDLosLotesSeleccionadosToolStripMenuItem, Me.VisualizarDocumentosLoteToolStripMenuItem5})
        Me.cmsInidizacion.Name = "cmsInidizacion"
        Me.cmsInidizacion.Size = New System.Drawing.Size(347, 70)
        '
        'EnviarATRASPASOLosLotesSeleccinadosToolStripMenuItem
        '
        Me.EnviarATRASPASOLosLotesSeleccinadosToolStripMenuItem.Name = "EnviarATRASPASOLosLotesSeleccinadosToolStripMenuItem"
        Me.EnviarATRASPASOLosLotesSeleccinadosToolStripMenuItem.Size = New System.Drawing.Size(346, 22)
        Me.EnviarATRASPASOLosLotesSeleccinadosToolStripMenuItem.Text = "Enviar a TRASPASO los lotes seleccinados"
        '
        'EnviarACORRECCIÓNPAEDLosLotesSeleccionadosToolStripMenuItem
        '
        Me.EnviarACORRECCIÓNPAEDLosLotesSeleccionadosToolStripMenuItem.Name = "EnviarACORRECCIÓNPAEDLosLotesSeleccionadosToolStripMenuItem"
        Me.EnviarACORRECCIÓNPAEDLosLotesSeleccionadosToolStripMenuItem.Size = New System.Drawing.Size(346, 22)
        Me.EnviarACORRECCIÓNPAEDLosLotesSeleccionadosToolStripMenuItem.Text = "Enviar a CORRECCIÓN PAED los lotes seleccionados"
        '
        'VisualizarDocumentosLoteToolStripMenuItem5
        '
        Me.VisualizarDocumentosLoteToolStripMenuItem5.Name = "VisualizarDocumentosLoteToolStripMenuItem5"
        Me.VisualizarDocumentosLoteToolStripMenuItem5.Size = New System.Drawing.Size(346, 22)
        Me.VisualizarDocumentosLoteToolStripMenuItem5.Text = "Visualizar documentos lote"
        '
        'dgvTraspaso
        '
        Me.dgvTraspaso.AllowUserToAddRows = False
        Me.dgvTraspaso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTraspaso.ContextMenuStrip = Me.cmsTraspaso
        Me.dgvTraspaso.Location = New System.Drawing.Point(433, 52)
        Me.dgvTraspaso.Name = "dgvTraspaso"
        Me.dgvTraspaso.RowHeadersVisible = False
        Me.dgvTraspaso.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvTraspaso.Size = New System.Drawing.Size(82, 334)
        Me.dgvTraspaso.TabIndex = 3
        '
        'cmsTraspaso
        '
        Me.cmsTraspaso.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EnviarACORRECCIÓNDIGILosLotesSeleccionadosToolStripMenuItem, Me.CrearDATEnviarAIandizaciónLosLotesSeleccionadosToolStripMenuItem, Me.VisualizarDocumentosLoteToolStripMenuItem4, Me.ExportarLoteToolStripMenuItem})
        Me.cmsTraspaso.Name = "cmsTraspaso"
        Me.cmsTraspaso.Size = New System.Drawing.Size(372, 92)
        '
        'EnviarACORRECCIÓNDIGILosLotesSeleccionadosToolStripMenuItem
        '
        Me.EnviarACORRECCIÓNDIGILosLotesSeleccionadosToolStripMenuItem.Name = "EnviarACORRECCIÓNDIGILosLotesSeleccionadosToolStripMenuItem"
        Me.EnviarACORRECCIÓNDIGILosLotesSeleccionadosToolStripMenuItem.Size = New System.Drawing.Size(371, 22)
        Me.EnviarACORRECCIÓNDIGILosLotesSeleccionadosToolStripMenuItem.Text = "Enviar a CORRECCIÓN DIGI los lotes seleccionados"
        '
        'CrearDATEnviarAIandizaciónLosLotesSeleccionadosToolStripMenuItem
        '
        Me.CrearDATEnviarAIandizaciónLosLotesSeleccionadosToolStripMenuItem.Name = "CrearDATEnviarAIandizaciónLosLotesSeleccionadosToolStripMenuItem"
        Me.CrearDATEnviarAIandizaciónLosLotesSeleccionadosToolStripMenuItem.Size = New System.Drawing.Size(371, 22)
        Me.CrearDATEnviarAIandizaciónLosLotesSeleccionadosToolStripMenuItem.Text = "CREAR DAT Enviar a INDIZACIÓN los lotes seleccionados"
        '
        'VisualizarDocumentosLoteToolStripMenuItem4
        '
        Me.VisualizarDocumentosLoteToolStripMenuItem4.Name = "VisualizarDocumentosLoteToolStripMenuItem4"
        Me.VisualizarDocumentosLoteToolStripMenuItem4.Size = New System.Drawing.Size(371, 22)
        Me.VisualizarDocumentosLoteToolStripMenuItem4.Text = "visualizar documentos lote"
        '
        'ExportarLoteToolStripMenuItem
        '
        Me.ExportarLoteToolStripMenuItem.Name = "ExportarLoteToolStripMenuItem"
        Me.ExportarLoteToolStripMenuItem.Size = New System.Drawing.Size(371, 22)
        Me.ExportarLoteToolStripMenuItem.Text = "Exportar lote "
        Me.ExportarLoteToolStripMenuItem.Visible = False
        '
        'dgvCorreccionDigi
        '
        Me.dgvCorreccionDigi.AllowUserToAddRows = False
        Me.dgvCorreccionDigi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCorreccionDigi.ContextMenuStrip = Me.cmsCorreccionDigi
        Me.dgvCorreccionDigi.Location = New System.Drawing.Point(328, 52)
        Me.dgvCorreccionDigi.Name = "dgvCorreccionDigi"
        Me.dgvCorreccionDigi.RowHeadersVisible = False
        Me.dgvCorreccionDigi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCorreccionDigi.Size = New System.Drawing.Size(82, 334)
        Me.dgvCorreccionDigi.TabIndex = 2
        '
        'cmsCorreccionDigi
        '
        Me.cmsCorreccionDigi.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EnviarAVERIFICACIÓNLosLotesSeleccionadosToolStripMenuItem, Me.EnviarATRASPASOLosLotesSeleccionadosToolStripMenuItem, Me.VisualizarDocumentosLoteToolStripMenuItem3})
        Me.cmsCorreccionDigi.Name = "cmsCorreccionDigi"
        Me.cmsCorreccionDigi.Size = New System.Drawing.Size(322, 70)
        '
        'EnviarAVERIFICACIÓNLosLotesSeleccionadosToolStripMenuItem
        '
        Me.EnviarAVERIFICACIÓNLosLotesSeleccionadosToolStripMenuItem.Name = "EnviarAVERIFICACIÓNLosLotesSeleccionadosToolStripMenuItem"
        Me.EnviarAVERIFICACIÓNLosLotesSeleccionadosToolStripMenuItem.Size = New System.Drawing.Size(321, 22)
        Me.EnviarAVERIFICACIÓNLosLotesSeleccionadosToolStripMenuItem.Text = "Enviar a VERIFICACIÓN los lotes seleccionados."
        '
        'EnviarATRASPASOLosLotesSeleccionadosToolStripMenuItem
        '
        Me.EnviarATRASPASOLosLotesSeleccionadosToolStripMenuItem.Name = "EnviarATRASPASOLosLotesSeleccionadosToolStripMenuItem"
        Me.EnviarATRASPASOLosLotesSeleccionadosToolStripMenuItem.Size = New System.Drawing.Size(321, 22)
        Me.EnviarATRASPASOLosLotesSeleccionadosToolStripMenuItem.Text = "Enviar a TRASPASO los lotes seleccionados"
        '
        'VisualizarDocumentosLoteToolStripMenuItem3
        '
        Me.VisualizarDocumentosLoteToolStripMenuItem3.Name = "VisualizarDocumentosLoteToolStripMenuItem3"
        Me.VisualizarDocumentosLoteToolStripMenuItem3.Size = New System.Drawing.Size(321, 22)
        Me.VisualizarDocumentosLoteToolStripMenuItem3.Text = "Visualizar documentos lote"
        '
        'dgvVerificación
        '
        Me.dgvVerificación.AllowUserToAddRows = False
        Me.dgvVerificación.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvVerificación.ContextMenuStrip = Me.cmsVerificacion
        Me.dgvVerificación.Location = New System.Drawing.Point(223, 52)
        Me.dgvVerificación.Name = "dgvVerificación"
        Me.dgvVerificación.RowHeadersVisible = False
        Me.dgvVerificación.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvVerificación.Size = New System.Drawing.Size(82, 334)
        Me.dgvVerificación.TabIndex = 1
        '
        'cmsVerificacion
        '
        Me.cmsVerificacion.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EnviarAIPORTACIÓNLosLotesSeleccionadosToolStripMenuItem, Me.EnviarACORRECCIÓNLosLotesSeleccionadosToolStripMenuItem, Me.VisualizarDocumentosLoteToolStripMenuItem2})
        Me.cmsVerificacion.Name = "cmsVerificacion"
        Me.cmsVerificacion.Size = New System.Drawing.Size(320, 70)
        '
        'EnviarAIPORTACIÓNLosLotesSeleccionadosToolStripMenuItem
        '
        Me.EnviarAIPORTACIÓNLosLotesSeleccionadosToolStripMenuItem.Name = "EnviarAIPORTACIÓNLosLotesSeleccionadosToolStripMenuItem"
        Me.EnviarAIPORTACIÓNLosLotesSeleccionadosToolStripMenuItem.Size = New System.Drawing.Size(319, 22)
        Me.EnviarAIPORTACIÓNLosLotesSeleccionadosToolStripMenuItem.Text = "Enviar a IMPORTACIÓN los lotes seleccionados"
        '
        'EnviarACORRECCIÓNLosLotesSeleccionadosToolStripMenuItem
        '
        Me.EnviarACORRECCIÓNLosLotesSeleccionadosToolStripMenuItem.Name = "EnviarACORRECCIÓNLosLotesSeleccionadosToolStripMenuItem"
        Me.EnviarACORRECCIÓNLosLotesSeleccionadosToolStripMenuItem.Size = New System.Drawing.Size(319, 22)
        Me.EnviarACORRECCIÓNLosLotesSeleccionadosToolStripMenuItem.Text = "Enviar a CORRECCIÓN los lotes seleccionados"
        '
        'VisualizarDocumentosLoteToolStripMenuItem2
        '
        Me.VisualizarDocumentosLoteToolStripMenuItem2.Name = "VisualizarDocumentosLoteToolStripMenuItem2"
        Me.VisualizarDocumentosLoteToolStripMenuItem2.Size = New System.Drawing.Size(319, 22)
        Me.VisualizarDocumentosLoteToolStripMenuItem2.Text = "Visualizar documentos lote"
        '
        'dgvDigitalizacion
        '
        Me.dgvDigitalizacion.AllowUserToAddRows = False
        Me.dgvDigitalizacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDigitalizacion.ContextMenuStrip = Me.cmsDigitalizacion
        Me.dgvDigitalizacion.Location = New System.Drawing.Point(13, 52)
        Me.dgvDigitalizacion.Name = "dgvDigitalizacion"
        Me.dgvDigitalizacion.RowHeadersVisible = False
        Me.dgvDigitalizacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDigitalizacion.Size = New System.Drawing.Size(82, 334)
        Me.dgvDigitalizacion.TabIndex = 0
        '
        'cmsDigitalizacion
        '
        Me.cmsDigitalizacion.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EnviarAIMPORTACIÓNLosLotesSeleccionadosToolStripMenuItem, Me.VisualizarDocumentosLoteToolStripMenuItem1})
        Me.cmsDigitalizacion.Name = "ContextMenuStrip2"
        Me.cmsDigitalizacion.Size = New System.Drawing.Size(320, 48)
        '
        'EnviarAIMPORTACIÓNLosLotesSeleccionadosToolStripMenuItem
        '
        Me.EnviarAIMPORTACIÓNLosLotesSeleccionadosToolStripMenuItem.Name = "EnviarAIMPORTACIÓNLosLotesSeleccionadosToolStripMenuItem"
        Me.EnviarAIMPORTACIÓNLosLotesSeleccionadosToolStripMenuItem.Size = New System.Drawing.Size(319, 22)
        Me.EnviarAIMPORTACIÓNLosLotesSeleccionadosToolStripMenuItem.Text = "Enviar a IMPORTACIÓN los lotes seleccionados"
        '
        'VisualizarDocumentosLoteToolStripMenuItem1
        '
        Me.VisualizarDocumentosLoteToolStripMenuItem1.Name = "VisualizarDocumentosLoteToolStripMenuItem1"
        Me.VisualizarDocumentosLoteToolStripMenuItem1.Size = New System.Drawing.Size(319, 22)
        Me.VisualizarDocumentosLoteToolStripMenuItem1.Text = "Visualizar documentos lote"
        '
        'CmbProyectosControlProcesos
        '
        Me.CmbProyectosControlProcesos.FormattingEnabled = True
        Me.CmbProyectosControlProcesos.Location = New System.Drawing.Point(90, 25)
        Me.CmbProyectosControlProcesos.Name = "CmbProyectosControlProcesos"
        Me.CmbProyectosControlProcesos.Size = New System.Drawing.Size(392, 21)
        Me.CmbProyectosControlProcesos.TabIndex = 3
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(32, 28)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(52, 13)
        Me.Label25.TabIndex = 2
        Me.Label25.Text = "Proyecto:"
        '
        'frmAdministrar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1095, 639)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frmAdministrar"
        Me.Text = "frmAdministrar"
        Me.TabControl1.ResumeLayout(False)
        Me.tabConfiguracionProyectos.ResumeLayout(False)
        Me.tabConfiguracionProyectos.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgCamposCodigoBarras, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.txtLotefinal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabControlProcesos.ResumeLayout(False)
        Me.tabControlProcesos.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.AxImgEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbControlProcesos.ResumeLayout(False)
        Me.gbControlProcesos.PerformLayout()
        CType(Me.dgvEnviados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsExportacion.ResumeLayout(False)
        CType(Me.dgvExportados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvImportacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsImportacion.ResumeLayout(False)
        CType(Me.dgvFinalizacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsFinalizacion.ResumeLayout(False)
        CType(Me.dgvCorreccionPAED, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmscorreccionPAED.ResumeLayout(False)
        CType(Me.dgvIndizacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsInidizacion.ResumeLayout(False)
        CType(Me.dgvTraspaso, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsTraspaso.ResumeLayout(False)
        CType(Me.dgvCorreccionDigi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsCorreccionDigi.ResumeLayout(False)
        CType(Me.dgvVerificación, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsVerificacion.ResumeLayout(False)
        CType(Me.dgvDigitalizacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsDigitalizacion.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabConfiguracionProyectos As System.Windows.Forms.TabPage
    Friend WithEvents cmbProyecto As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdCrearLotes As LibreriaCadenaProduccion.Controles.Botones.CtrlBotonMediano
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtLoteInicial As System.Windows.Forms.TextBox
    Friend WithEvents txtLotefinal As System.Windows.Forms.NumericUpDown
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lstvCamposTablaDocumentos As System.Windows.Forms.ListView
    Friend WithEvents cmbBorrarestructura As LibreriaCadenaProduccion.Controles.Botones.CtrlBotonMediano
    Friend WithEvents cmbGuardarEstructura As LibreriaCadenaProduccion.Controles.Botones.CtrlBotonMediano
    Friend WithEvents cmbCabeceraBarcode As System.Windows.Forms.ComboBox
    Friend WithEvents cmbNuevaCabecera As LibreriaCadenaProduccion.Controles.Botones.CtrlBotonMediano
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dgCamposCodigoBarras As System.Windows.Forms.DataGridView
    Friend WithEvents NombreCampo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Longitud As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Orden As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Columna As System.Windows.Forms.ColumnHeader
    Friend WithEvents cmbNuevoProyecto As LibreriaCadenaProduccion.Controles.Botones.CtrlBotonMediano
    Friend WithEvents tabControlProcesos As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents gbControlProcesos As System.Windows.Forms.GroupBox
    Friend WithEvents CmbProyectosControlProcesos As System.Windows.Forms.ComboBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents rbtMensajes As System.Windows.Forms.RichTextBox
    Friend WithEvents dgvCorreccionPAED As System.Windows.Forms.DataGridView
    Friend WithEvents dgvIndizacion As System.Windows.Forms.DataGridView
    Friend WithEvents dgvTraspaso As System.Windows.Forms.DataGridView
    Friend WithEvents dgvCorreccionDigi As System.Windows.Forms.DataGridView
    Friend WithEvents dgvVerificación As System.Windows.Forms.DataGridView
    Friend WithEvents dgvDigitalizacion As System.Windows.Forms.DataGridView
    Friend WithEvents dgvFinalizacion As System.Windows.Forms.DataGridView
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Verificación As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents AxImgEdit1 As AxImgeditLibCtl.AxImgEdit
    Friend WithEvents pbprocesosDocumentos As System.Windows.Forms.ProgressBar
    Friend WithEvents pgbProcesoslotes As System.Windows.Forms.ProgressBar
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents dgvImportacion As System.Windows.Forms.DataGridView
    Friend WithEvents cmsImportacion As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsDigitalizacion As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EnviarADigitalizarLosLotesSeleccionadosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EnviarAVERIFICARLosLotesSeleccionadosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VisualizarDocumentosLoteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EnviarAIMPORTACIÓNLosLotesSeleccionadosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VisualizarDocumentosLoteToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsVerificacion As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EnviarAIPORTACIÓNLosLotesSeleccionadosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EnviarACORRECCIÓNLosLotesSeleccionadosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VisualizarDocumentosLoteToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsCorreccionDigi As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsTraspaso As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsInidizacion As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsFinalizacion As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmscorreccionPAED As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EnviarAVERIFICACIÓNLosLotesSeleccionadosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EnviarATRASPASOLosLotesSeleccionadosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VisualizarDocumentosLoteToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EnviarACORRECCIÓNDIGILosLotesSeleccionadosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CrearDATEnviarAIandizaciónLosLotesSeleccionadosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VisualizarDocumentosLoteToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EnviarATRASPASOLosLotesSeleccinadosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EnviarACORRECCIÓNPAEDLosLotesSeleccionadosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VisualizarDocumentosLoteToolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EnviarAINDIZACIÓNLosLotesSeleccionadosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EnviarAFinalizaciónLosLotesSeleccionadosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EnviarACORRECCIONPAEDLosLotesSeleccionadosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FINALIZARLosLotesSeleccionadosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VisualizarDocumentosLotesSelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VisualizarDocumentosLoteToolStripMenuItem6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents dgvExportados As System.Windows.Forms.DataGridView
    Friend WithEvents crpCaratula1 As Digitalización.crpCaratula
    Friend WithEvents ExportarLoteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsExportacion As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EnviarATraspasoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents EnviarAFinalizaciónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button1 As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents dgvEnviados As DataGridView
End Class
