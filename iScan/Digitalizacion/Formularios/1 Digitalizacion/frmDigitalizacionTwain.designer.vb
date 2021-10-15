<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDigitalizacionTwain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDigitalizacionTwain))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmdSincronizar = New LibreriaCadenaProduccion.Controles.Botones.CtrlBotonGrande()
        Me.cmdGuardarDocumentos = New LibreriaCadenaProduccion.Controles.Botones.CtrlBotonGrande()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.cmdCerrarLote = New LibreriaCadenaProduccion.Controles.Botones.CtrlBotonGrande()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkPerfiles = New System.Windows.Forms.CheckBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.nudGrados = New System.Windows.Forms.NumericUpDown()
        Me.cmdRecargarLista = New System.Windows.Forms.Button()
        Me.cmdPorcentajeNegro = New System.Windows.Forms.Button()
        Me.cmdGuardar = New System.Windows.Forms.Button()
        Me.tstAccionesDocumentos = New System.Windows.Forms.ToolStrip()
        Me.tsbAccion5 = New System.Windows.Forms.ToolStripButton()
        Me.tsbAccion1 = New System.Windows.Forms.ToolStripButton()
        Me.tsbAccion2 = New System.Windows.Forms.ToolStripButton()
        Me.tsbAccion3 = New System.Windows.Forms.ToolStripButton()
        Me.tsbAccion7 = New System.Windows.Forms.ToolStripButton()
        Me.tsbAccion4 = New System.Windows.Forms.ToolStripButton()
        Me.tsbAccion6 = New System.Windows.Forms.ToolStripButton()
        Me.tstPorcentajeNegro = New System.Windows.Forms.ToolStripTextBox()
        Me.cmdDigitalizar = New System.Windows.Forms.Button()
        Me.lblNombreDocumento = New System.Windows.Forms.Label()
        Me.lblPaginaDocumento = New System.Windows.Forms.Label()
        Me.lblIdDocumento = New System.Windows.Forms.Label()
        Me.lstNHC = New System.Windows.Forms.ListBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtNHC = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblLotesUsuario = New System.Windows.Forms.Label()
        Me.lblPaginasLote = New System.Windows.Forms.Label()
        Me.lblLote = New System.Windows.Forms.Label()
        Me.cboTipoLote = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdAyuda = New System.Windows.Forms.Button()
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.colidDocumento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPagina = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNHC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.menuDocumentos = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuSustituirImagen = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEliminarImagen = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRotaImagen = New System.Windows.Forms.ToolStripMenuItem()
        Me.RotarPágina90ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOriginalMalEstado = New System.Windows.Forms.ToolStripMenuItem()
        Me.InsertarPáginaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.tstTipoPresentacion = New System.Windows.Forms.ToolStrip()
        Me.tsbImagen1 = New System.Windows.Forms.ToolStripButton()
        Me.tsbImagen2 = New System.Windows.Forms.ToolStripButton()
        Me.tsbImagenMini = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tstTipoAjuste = New System.Windows.Forms.ToolStrip()
        Me.tsbAjuste1 = New System.Windows.Forms.ToolStripButton()
        Me.tsbAjuste2 = New System.Windows.Forms.ToolStripButton()
        Me.tsbAjuste3 = New System.Windows.Forms.ToolStripButton()
        Me.tsbAjuste4 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.pnlPresentacion1 = New System.Windows.Forms.Panel()
        Me.IMGeditPrincipal = New System.Windows.Forms.PictureBox()
        Me.pnlPresentacion2 = New System.Windows.Forms.Panel()
        Me.imgEditDerecha = New System.Windows.Forms.PictureBox()
        Me.ImgEditIzquierda = New System.Windows.Forms.PictureBox()
        Me.pnlPresentacion3 = New System.Windows.Forms.Panel()
        Me.tstMoverRegistros = New System.Windows.Forms.ToolStrip()
        Me.tsbRegistroPrimero = New System.Windows.Forms.ToolStripButton()
        Me.tsbRegistroAnterior = New System.Windows.Forms.ToolStripButton()
        Me.stsBuscaPagina = New System.Windows.Forms.ToolStripTextBox()
        Me.tsbRegistroSiguiente = New System.Windows.Forms.ToolStripButton()
        Me.tsbRegistroUltimo = New System.Windows.Forms.ToolStripButton()
        Me.tsbImagenUna = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton6 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton8 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton9 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton10 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton11 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton12 = New System.Windows.Forms.ToolStripButton()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.lblProgressBar = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.nudGrados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tstAccionesDocumentos.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menuDocumentos.SuspendLayout()
        Me.tstTipoPresentacion.SuspendLayout()
        Me.tstTipoAjuste.SuspendLayout()
        Me.pnlPresentacion1.SuspendLayout()
        CType(Me.IMGeditPrincipal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPresentacion2.SuspendLayout()
        CType(Me.imgEditDerecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImgEditIzquierda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tstMoverRegistros.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.cmdSincronizar)
        Me.Panel1.Controls.Add(Me.cmdGuardarDocumentos)
        Me.Panel1.Controls.Add(Me.StatusStrip1)
        Me.Panel1.Controls.Add(Me.cmdCerrarLote)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.dgv)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(800, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(618, 737)
        Me.Panel1.TabIndex = 2
        '
        'cmdSincronizar
        '
        Me.cmdSincronizar.BackColor = System.Drawing.Color.Transparent
        Me.cmdSincronizar.EnabledBoton = True
        Me.cmdSincronizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSincronizar.Location = New System.Drawing.Point(182, 693)
        Me.cmdSincronizar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmdSincronizar.Name = "cmdSincronizar"
        Me.cmdSincronizar.pImagenMouseEnter = CType(resources.GetObject("cmdSincronizar.pImagenMouseEnter"), System.Drawing.Image)
        Me.cmdSincronizar.pImagenMouseLeave = CType(resources.GetObject("cmdSincronizar.pImagenMouseLeave"), System.Drawing.Image)
        Me.cmdSincronizar.pImagenMouseOver = CType(resources.GetObject("cmdSincronizar.pImagenMouseOver"), System.Drawing.Image)
        Me.cmdSincronizar.Size = New System.Drawing.Size(175, 30)
        Me.cmdSincronizar.TabIndex = 56
        Me.cmdSincronizar.Tag = "50"
        Me.cmdSincronizar.TextoBoton = "Sincronizar con servidor"
        '
        'cmdGuardarDocumentos
        '
        Me.cmdGuardarDocumentos.BackColor = System.Drawing.Color.Transparent
        Me.cmdGuardarDocumentos.EnabledBoton = True
        Me.cmdGuardarDocumentos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGuardarDocumentos.Location = New System.Drawing.Point(11, 693)
        Me.cmdGuardarDocumentos.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmdGuardarDocumentos.Name = "cmdGuardarDocumentos"
        Me.cmdGuardarDocumentos.pImagenMouseEnter = CType(resources.GetObject("cmdGuardarDocumentos.pImagenMouseEnter"), System.Drawing.Image)
        Me.cmdGuardarDocumentos.pImagenMouseLeave = CType(resources.GetObject("cmdGuardarDocumentos.pImagenMouseLeave"), System.Drawing.Image)
        Me.cmdGuardarDocumentos.pImagenMouseOver = CType(resources.GetObject("cmdGuardarDocumentos.pImagenMouseOver"), System.Drawing.Image)
        Me.cmdGuardarDocumentos.Size = New System.Drawing.Size(153, 30)
        Me.cmdGuardarDocumentos.TabIndex = 55
        Me.cmdGuardarDocumentos.Tag = "50"
        Me.cmdGuardarDocumentos.TextoBoton = "Guardar documentos"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.AutoSize = False
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripProgressBar1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 715)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode
        Me.StatusStrip1.Size = New System.Drawing.Size(618, 22)
        Me.StatusStrip1.TabIndex = 54
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.AutoSize = False
        Me.ToolStripStatusLabel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ToolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.Raised
        Me.ToolStripStatusLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripStatusLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolStripStatusLabel1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(119, 17)
        Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolStripStatusLabel1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.AutoSize = False
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(100, 16)
        Me.ToolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        '
        'cmdCerrarLote
        '
        Me.cmdCerrarLote.BackColor = System.Drawing.Color.Transparent
        Me.cmdCerrarLote.EnabledBoton = True
        Me.cmdCerrarLote.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCerrarLote.Location = New System.Drawing.Point(530, 693)
        Me.cmdCerrarLote.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmdCerrarLote.Name = "cmdCerrarLote"
        Me.cmdCerrarLote.pImagenMouseEnter = CType(resources.GetObject("cmdCerrarLote.pImagenMouseEnter"), System.Drawing.Image)
        Me.cmdCerrarLote.pImagenMouseLeave = CType(resources.GetObject("cmdCerrarLote.pImagenMouseLeave"), System.Drawing.Image)
        Me.cmdCerrarLote.pImagenMouseOver = CType(resources.GetObject("cmdCerrarLote.pImagenMouseOver"), System.Drawing.Image)
        Me.cmdCerrarLote.Size = New System.Drawing.Size(78, 30)
        Me.cmdCerrarLote.TabIndex = 52
        Me.cmdCerrarLote.Tag = "50"
        Me.cmdCerrarLote.TextoBoton = "Cerrar lote"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkPerfiles)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.nudGrados)
        Me.GroupBox2.Controls.Add(Me.cmdRecargarLista)
        Me.GroupBox2.Controls.Add(Me.cmdPorcentajeNegro)
        Me.GroupBox2.Controls.Add(Me.cmdGuardar)
        Me.GroupBox2.Controls.Add(Me.tstAccionesDocumentos)
        Me.GroupBox2.Controls.Add(Me.cmdDigitalizar)
        Me.GroupBox2.Controls.Add(Me.lblNombreDocumento)
        Me.GroupBox2.Controls.Add(Me.lblPaginaDocumento)
        Me.GroupBox2.Controls.Add(Me.lblIdDocumento)
        Me.GroupBox2.Controls.Add(Me.lstNHC)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtNHC)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(11, 94)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(598, 199)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = " Datos Documento "
        '
        'chkPerfiles
        '
        Me.chkPerfiles.AutoSize = True
        Me.chkPerfiles.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPerfiles.Location = New System.Drawing.Point(10, 104)
        Me.chkPerfiles.Name = "chkPerfiles"
        Me.chkPerfiles.Size = New System.Drawing.Size(174, 20)
        Me.chkPerfiles.TabIndex = 68
        Me.chkPerfiles.Text = "Muestra perfiles escaner"
        Me.chkPerfiles.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Blue
        Me.Label9.Location = New System.Drawing.Point(499, 179)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(82, 17)
        Me.Label9.TabIndex = 67
        Me.Label9.Text = "Label9"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'nudGrados
        '
        Me.nudGrados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nudGrados.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
        Me.nudGrados.Location = New System.Drawing.Point(253, 103)
        Me.nudGrados.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.nudGrados.Minimum = New Decimal(New Integer() {10, 0, 0, -2147483648})
        Me.nudGrados.Name = "nudGrados"
        Me.nudGrados.Size = New System.Drawing.Size(41, 29)
        Me.nudGrados.TabIndex = 66
        Me.nudGrados.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmdRecargarLista
        '
        Me.cmdRecargarLista.BackColor = System.Drawing.SystemColors.Control
        Me.cmdRecargarLista.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRecargarLista.ForeColor = System.Drawing.Color.SteelBlue
        Me.cmdRecargarLista.Location = New System.Drawing.Point(488, 151)
        Me.cmdRecargarLista.Name = "cmdRecargarLista"
        Me.cmdRecargarLista.Size = New System.Drawing.Size(104, 25)
        Me.cmdRecargarLista.TabIndex = 65
        Me.cmdRecargarLista.Text = "Recargar lista"
        Me.cmdRecargarLista.UseVisualStyleBackColor = False
        '
        'cmdPorcentajeNegro
        '
        Me.cmdPorcentajeNegro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdPorcentajeNegro.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack
        Me.cmdPorcentajeNegro.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdPorcentajeNegro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPorcentajeNegro.ForeColor = System.Drawing.Color.SteelBlue
        Me.cmdPorcentajeNegro.Location = New System.Drawing.Point(408, 106)
        Me.cmdPorcentajeNegro.Name = "cmdPorcentajeNegro"
        Me.cmdPorcentajeNegro.Size = New System.Drawing.Size(25, 22)
        Me.cmdPorcentajeNegro.TabIndex = 64
        Me.cmdPorcentajeNegro.Text = "%"
        Me.cmdPorcentajeNegro.UseVisualStyleBackColor = True
        '
        'cmdGuardar
        '
        Me.cmdGuardar.BackgroundImage = Global.Digitalización.My.Resources.Resources.guardar_32_bmp
        Me.cmdGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdGuardar.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack
        Me.cmdGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdGuardar.Location = New System.Drawing.Point(210, 70)
        Me.cmdGuardar.Name = "cmdGuardar"
        Me.cmdGuardar.Size = New System.Drawing.Size(37, 34)
        Me.cmdGuardar.TabIndex = 15
        Me.cmdGuardar.UseVisualStyleBackColor = True
        '
        'tstAccionesDocumentos
        '
        Me.tstAccionesDocumentos.AutoSize = False
        Me.tstAccionesDocumentos.BackColor = System.Drawing.SystemColors.Control
        Me.tstAccionesDocumentos.Dock = System.Windows.Forms.DockStyle.None
        Me.tstAccionesDocumentos.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbAccion5, Me.tsbAccion1, Me.tsbAccion2, Me.tsbAccion3, Me.tsbAccion7, Me.tsbAccion4, Me.tsbAccion6, Me.tstPorcentajeNegro})
        Me.tstAccionesDocumentos.Location = New System.Drawing.Point(86, 131)
        Me.tstAccionesDocumentos.Margin = New System.Windows.Forms.Padding(5)
        Me.tstAccionesDocumentos.Name = "tstAccionesDocumentos"
        Me.tstAccionesDocumentos.Size = New System.Drawing.Size(414, 62)
        Me.tstAccionesDocumentos.Stretch = True
        Me.tstAccionesDocumentos.TabIndex = 61
        Me.tstAccionesDocumentos.Text = "ToolStrip1"
        '
        'tsbAccion5
        '
        Me.tsbAccion5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbAccion5.Image = Global.Digitalización.My.Resources.Resources.insertar_48
        Me.tsbAccion5.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbAccion5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAccion5.Name = "tsbAccion5"
        Me.tsbAccion5.Size = New System.Drawing.Size(52, 59)
        Me.tsbAccion5.Text = "ToolStripButton13"
        Me.tsbAccion5.ToolTipText = "Insertar página digitalizada"
        '
        'tsbAccion1
        '
        Me.tsbAccion1.CheckOnClick = True
        Me.tsbAccion1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbAccion1.Image = Global.Digitalización.My.Resources.Resources.sustituir_48
        Me.tsbAccion1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbAccion1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAccion1.Name = "tsbAccion1"
        Me.tsbAccion1.Size = New System.Drawing.Size(52, 59)
        Me.tsbAccion1.Text = "ToolStripButton13"
        Me.tsbAccion1.ToolTipText = "Sustituir página seleccionada"
        '
        'tsbAccion2
        '
        Me.tsbAccion2.CheckOnClick = True
        Me.tsbAccion2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbAccion2.Image = Global.Digitalización.My.Resources.Resources.eliminar_48
        Me.tsbAccion2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbAccion2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAccion2.Name = "tsbAccion2"
        Me.tsbAccion2.Size = New System.Drawing.Size(52, 59)
        Me.tsbAccion2.Text = "ToolStripButton13"
        Me.tsbAccion2.ToolTipText = "Eliminar páginas seleccionadas"
        '
        'tsbAccion3
        '
        Me.tsbAccion3.CheckOnClick = True
        Me.tsbAccion3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbAccion3.Image = Global.Digitalización.My.Resources.Resources.rotar_48
        Me.tsbAccion3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbAccion3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAccion3.Name = "tsbAccion3"
        Me.tsbAccion3.Size = New System.Drawing.Size(52, 59)
        Me.tsbAccion3.Text = "ToolStripButton13"
        Me.tsbAccion3.ToolTipText = "Rotar páginas seleccionadas 90 grados a la derecha"
        '
        'tsbAccion7
        '
        Me.tsbAccion7.CheckOnClick = True
        Me.tsbAccion7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbAccion7.Image = Global.Digitalización.My.Resources.Resources.rotar_48
        Me.tsbAccion7.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbAccion7.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAccion7.Name = "tsbAccion7"
        Me.tsbAccion7.Size = New System.Drawing.Size(52, 59)
        Me.tsbAccion7.Text = "ToolStripButton13"
        Me.tsbAccion7.ToolTipText = "Rotar páginas seleccionadas 90 grados a la izquierda"
        Me.tsbAccion7.Visible = False
        '
        'tsbAccion4
        '
        Me.tsbAccion4.CheckOnClick = True
        Me.tsbAccion4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbAccion4.Image = Global.Digitalización.My.Resources.Resources.Docmal_48
        Me.tsbAccion4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbAccion4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAccion4.Name = "tsbAccion4"
        Me.tsbAccion4.Size = New System.Drawing.Size(52, 59)
        Me.tsbAccion4.Text = "ToolStripButton13"
        Me.tsbAccion4.ToolTipText = "Marcar como original en mal estado"
        '
        'tsbAccion6
        '
        Me.tsbAccion6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbAccion6.Image = Global.Digitalización.My.Resources.Resources.hojablanco_48
        Me.tsbAccion6.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbAccion6.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAccion6.Name = "tsbAccion6"
        Me.tsbAccion6.Size = New System.Drawing.Size(52, 59)
        Me.tsbAccion6.Text = "ToolStripButton13"
        Me.tsbAccion6.ToolTipText = "Localizar páginas en blanco"
        '
        'tstPorcentajeNegro
        '
        Me.tstPorcentajeNegro.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tstPorcentajeNegro.Name = "tstPorcentajeNegro"
        Me.tstPorcentajeNegro.Size = New System.Drawing.Size(25, 62)
        Me.tstPorcentajeNegro.Text = "1"
        Me.tstPorcentajeNegro.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tstPorcentajeNegro.ToolTipText = "Porcentaje de pixeles negros para localizar páginas sin contenido"
        '
        'cmdDigitalizar
        '
        Me.cmdDigitalizar.BackgroundImage = Global.Digitalización.My.Resources.Resources.escaner_48
        Me.cmdDigitalizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdDigitalizar.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack
        Me.cmdDigitalizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdDigitalizar.Location = New System.Drawing.Point(6, 127)
        Me.cmdDigitalizar.Name = "cmdDigitalizar"
        Me.cmdDigitalizar.Size = New System.Drawing.Size(72, 66)
        Me.cmdDigitalizar.TabIndex = 60
        Me.cmdDigitalizar.UseVisualStyleBackColor = True
        '
        'lblNombreDocumento
        '
        Me.lblNombreDocumento.BackColor = System.Drawing.Color.White
        Me.lblNombreDocumento.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblNombreDocumento.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreDocumento.Location = New System.Drawing.Point(463, 38)
        Me.lblNombreDocumento.Name = "lblNombreDocumento"
        Me.lblNombreDocumento.Size = New System.Drawing.Size(118, 22)
        Me.lblNombreDocumento.TabIndex = 59
        Me.lblNombreDocumento.Text = "Label9"
        Me.lblNombreDocumento.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPaginaDocumento
        '
        Me.lblPaginaDocumento.BackColor = System.Drawing.Color.White
        Me.lblPaginaDocumento.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblPaginaDocumento.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPaginaDocumento.Location = New System.Drawing.Point(269, 37)
        Me.lblPaginaDocumento.Name = "lblPaginaDocumento"
        Me.lblPaginaDocumento.Size = New System.Drawing.Size(77, 22)
        Me.lblPaginaDocumento.TabIndex = 58
        Me.lblPaginaDocumento.Text = "Label9"
        Me.lblPaginaDocumento.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblIdDocumento
        '
        Me.lblIdDocumento.BackColor = System.Drawing.Color.White
        Me.lblIdDocumento.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblIdDocumento.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdDocumento.Location = New System.Drawing.Point(106, 38)
        Me.lblIdDocumento.Name = "lblIdDocumento"
        Me.lblIdDocumento.Size = New System.Drawing.Size(95, 22)
        Me.lblIdDocumento.TabIndex = 57
        Me.lblIdDocumento.Text = "Label9"
        Me.lblIdDocumento.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lstNHC
        '
        Me.lstNHC.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstNHC.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstNHC.FormattingEnabled = True
        Me.lstNHC.ItemHeight = 20
        Me.lstNHC.Items.AddRange(New Object() {"30512", "59654"})
        Me.lstNHC.Location = New System.Drawing.Point(499, 85)
        Me.lstNHC.Name = "lstNHC"
        Me.lstNHC.Size = New System.Drawing.Size(82, 60)
        Me.lstNHC.TabIndex = 16
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(378, 88)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(115, 16)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "NHC Preparadas:"
        '
        'txtNHC
        '
        Me.txtNHC.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtNHC.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNHC.Location = New System.Drawing.Point(102, 76)
        Me.txtNHC.Name = "txtNHC"
        Me.txtNHC.Size = New System.Drawing.Size(99, 22)
        Me.txtNHC.TabIndex = 14
        Me.txtNHC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(15, 78)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 20)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "NHC:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(396, 41)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 16)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Nombre:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(204, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 16)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Página:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(15, 41)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 16)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "IdDocumento:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblLotesUsuario)
        Me.GroupBox1.Controls.Add(Me.lblPaginasLote)
        Me.GroupBox1.Controls.Add(Me.lblLote)
        Me.GroupBox1.Controls.Add(Me.cboTipoLote)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmdAyuda)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(11, 11)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(598, 77)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " Datos Lote "
        '
        'lblLotesUsuario
        '
        Me.lblLotesUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.lblLotesUsuario.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblLotesUsuario.Location = New System.Drawing.Point(102, 0)
        Me.lblLotesUsuario.Name = "lblLotesUsuario"
        Me.lblLotesUsuario.Size = New System.Drawing.Size(456, 26)
        Me.lblLotesUsuario.TabIndex = 11
        Me.lblLotesUsuario.Text = "Label9"
        '
        'lblPaginasLote
        '
        Me.lblPaginasLote.BackColor = System.Drawing.Color.White
        Me.lblPaginasLote.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblPaginasLote.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPaginasLote.Location = New System.Drawing.Point(463, 33)
        Me.lblPaginasLote.Name = "lblPaginasLote"
        Me.lblPaginasLote.Size = New System.Drawing.Size(77, 22)
        Me.lblPaginasLote.TabIndex = 15
        Me.lblPaginasLote.Text = "Label9"
        Me.lblPaginasLote.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLote
        '
        Me.lblLote.BackColor = System.Drawing.Color.White
        Me.lblLote.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblLote.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLote.Location = New System.Drawing.Point(102, 33)
        Me.lblLote.Name = "lblLote"
        Me.lblLote.Size = New System.Drawing.Size(77, 22)
        Me.lblLote.TabIndex = 14
        Me.lblLote.Text = "Label9"
        Me.lblLote.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboTipoLote
        '
        Me.cboTipoLote.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboTipoLote.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoLote.FormattingEnabled = True
        Me.cboTipoLote.Location = New System.Drawing.Point(273, 31)
        Me.cboTipoLote.Name = "cboTipoLote"
        Me.cboTipoLote.Size = New System.Drawing.Size(113, 28)
        Me.cboTipoLote.TabIndex = 13
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(396, 37)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 16)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Páginas:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(204, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 16)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Tipo Lote:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 16)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Lote:"
        '
        'cmdAyuda
        '
        Me.cmdAyuda.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAyuda.Location = New System.Drawing.Point(572, 0)
        Me.cmdAyuda.Name = "cmdAyuda"
        Me.cmdAyuda.Size = New System.Drawing.Size(26, 29)
        Me.cmdAyuda.TabIndex = 16
        Me.cmdAyuda.Text = "?"
        Me.cmdAyuda.UseVisualStyleBackColor = True
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.AllowUserToResizeRows = False
        Me.dgv.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colidDocumento, Me.colPagina, Me.colNombre, Me.colNHC})
        Me.dgv.Location = New System.Drawing.Point(11, 299)
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        Me.dgv.RowHeadersWidth = 25
        Me.dgv.RowTemplate.ReadOnly = True
        Me.dgv.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv.Size = New System.Drawing.Size(598, 390)
        Me.dgv.TabIndex = 2
        Me.dgv.Tag = "1"
        '
        'colidDocumento
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colidDocumento.DefaultCellStyle = DataGridViewCellStyle1
        Me.colidDocumento.HeaderText = "idDocumento"
        Me.colidDocumento.Name = "colidDocumento"
        Me.colidDocumento.ReadOnly = True
        '
        'colPagina
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colPagina.DefaultCellStyle = DataGridViewCellStyle2
        Me.colPagina.HeaderText = "Página"
        Me.colPagina.Name = "colPagina"
        Me.colPagina.ReadOnly = True
        '
        'colNombre
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colNombre.DefaultCellStyle = DataGridViewCellStyle3
        Me.colNombre.HeaderText = "Nombre"
        Me.colNombre.Name = "colNombre"
        Me.colNombre.ReadOnly = True
        '
        'colNHC
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colNHC.DefaultCellStyle = DataGridViewCellStyle4
        Me.colNHC.HeaderText = "NHC"
        Me.colNHC.Name = "colNHC"
        Me.colNHC.ReadOnly = True
        '
        'menuDocumentos
        '
        Me.menuDocumentos.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSustituirImagen, Me.mnuEliminarImagen, Me.mnuRotaImagen, Me.RotarPágina90ToolStripMenuItem, Me.mnuOriginalMalEstado, Me.InsertarPáginaToolStripMenuItem})
        Me.menuDocumentos.Name = "menuDocumentos"
        Me.menuDocumentos.Size = New System.Drawing.Size(195, 136)
        '
        'mnuSustituirImagen
        '
        Me.mnuSustituirImagen.Name = "mnuSustituirImagen"
        Me.mnuSustituirImagen.Size = New System.Drawing.Size(194, 22)
        Me.mnuSustituirImagen.Text = "&Sustituir página (S)"
        '
        'mnuEliminarImagen
        '
        Me.mnuEliminarImagen.Name = "mnuEliminarImagen"
        Me.mnuEliminarImagen.Size = New System.Drawing.Size(194, 22)
        Me.mnuEliminarImagen.Text = "&Eliminar página (4)"
        '
        'mnuRotaImagen
        '
        Me.mnuRotaImagen.Name = "mnuRotaImagen"
        Me.mnuRotaImagen.Size = New System.Drawing.Size(194, 22)
        Me.mnuRotaImagen.Text = "&Rotar página 90 (+)"
        '
        'RotarPágina90ToolStripMenuItem
        '
        Me.RotarPágina90ToolStripMenuItem.Name = "RotarPágina90ToolStripMenuItem"
        Me.RotarPágina90ToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.RotarPágina90ToolStripMenuItem.Text = "Rotar página -90 (-)"
        '
        'mnuOriginalMalEstado
        '
        Me.mnuOriginalMalEstado.Name = "mnuOriginalMalEstado"
        Me.mnuOriginalMalEstado.Size = New System.Drawing.Size(194, 22)
        Me.mnuOriginalMalEstado.Text = "&Original mal estado (2)"
        '
        'InsertarPáginaToolStripMenuItem
        '
        Me.InsertarPáginaToolStripMenuItem.Name = "InsertarPáginaToolStripMenuItem"
        Me.InsertarPáginaToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.InsertarPáginaToolStripMenuItem.Text = "Insertar página (I)"
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth4Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'tstTipoPresentacion
        '
        Me.tstTipoPresentacion.AutoSize = False
        Me.tstTipoPresentacion.BackColor = System.Drawing.SystemColors.Control
        Me.tstTipoPresentacion.Dock = System.Windows.Forms.DockStyle.None
        Me.tstTipoPresentacion.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbImagen1, Me.tsbImagen2, Me.tsbImagenMini, Me.ToolStripSeparator3})
        Me.tstTipoPresentacion.Location = New System.Drawing.Point(0, 0)
        Me.tstTipoPresentacion.Margin = New System.Windows.Forms.Padding(5)
        Me.tstTipoPresentacion.Name = "tstTipoPresentacion"
        Me.tstTipoPresentacion.Size = New System.Drawing.Size(124, 45)
        Me.tstTipoPresentacion.Stretch = True
        Me.tstTipoPresentacion.TabIndex = 4
        Me.tstTipoPresentacion.Text = "ToolStrip1"
        '
        'tsbImagen1
        '
        Me.tsbImagen1.CheckOnClick = True
        Me.tsbImagen1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbImagen1.Image = Global.Digitalización.My.Resources.Resources.Imagen1_32
        Me.tsbImagen1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbImagen1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImagen1.Name = "tsbImagen1"
        Me.tsbImagen1.Size = New System.Drawing.Size(32, 42)
        Me.tsbImagen1.Text = "ToolStripButton13"
        Me.tsbImagen1.ToolTipText = "Mostrar una imagen"
        '
        'tsbImagen2
        '
        Me.tsbImagen2.CheckOnClick = True
        Me.tsbImagen2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbImagen2.Image = Global.Digitalización.My.Resources.Resources.Imagen2_32
        Me.tsbImagen2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbImagen2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImagen2.Name = "tsbImagen2"
        Me.tsbImagen2.Size = New System.Drawing.Size(32, 42)
        Me.tsbImagen2.Text = "Mostrar dos imágenes"
        '
        'tsbImagenMini
        '
        Me.tsbImagenMini.CheckOnClick = True
        Me.tsbImagenMini.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbImagenMini.Image = Global.Digitalización.My.Resources.Resources.ImagenMini_32
        Me.tsbImagenMini.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbImagenMini.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImagenMini.Name = "tsbImagenMini"
        Me.tsbImagenMini.Size = New System.Drawing.Size(33, 42)
        Me.tsbImagenMini.Text = "ToolStripButton13"
        Me.tsbImagenMini.ToolTipText = "Mostrar miniaturas"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 45)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 45)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 45)
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 45)
        '
        'tstTipoAjuste
        '
        Me.tstTipoAjuste.AutoSize = False
        Me.tstTipoAjuste.BackColor = System.Drawing.SystemColors.Control
        Me.tstTipoAjuste.Dock = System.Windows.Forms.DockStyle.None
        Me.tstTipoAjuste.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbAjuste1, Me.tsbAjuste2, Me.tsbAjuste3, Me.tsbAjuste4, Me.ToolStripSeparator7})
        Me.tstTipoAjuste.Location = New System.Drawing.Point(121, 0)
        Me.tstTipoAjuste.Margin = New System.Windows.Forms.Padding(5)
        Me.tstTipoAjuste.Name = "tstTipoAjuste"
        Me.tstTipoAjuste.Size = New System.Drawing.Size(162, 45)
        Me.tstTipoAjuste.Stretch = True
        Me.tstTipoAjuste.TabIndex = 5
        Me.tstTipoAjuste.Text = "ToolStrip1"
        '
        'tsbAjuste1
        '
        Me.tsbAjuste1.CheckOnClick = True
        Me.tsbAjuste1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbAjuste1.Image = Global.Digitalización.My.Resources.Resources.Ajuste1
        Me.tsbAjuste1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbAjuste1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAjuste1.Name = "tsbAjuste1"
        Me.tsbAjuste1.Size = New System.Drawing.Size(31, 42)
        Me.tsbAjuste1.Text = "ToolStripButton13"
        Me.tsbAjuste1.ToolTipText = "Ajustar a la proporcion de la imagen"
        '
        'tsbAjuste2
        '
        Me.tsbAjuste2.CheckOnClick = True
        Me.tsbAjuste2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbAjuste2.Image = Global.Digitalización.My.Resources.Resources.Ajuste2
        Me.tsbAjuste2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbAjuste2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAjuste2.Name = "tsbAjuste2"
        Me.tsbAjuste2.Size = New System.Drawing.Size(31, 42)
        Me.tsbAjuste2.Text = "ToolStripButton13"
        Me.tsbAjuste2.ToolTipText = "Ajustar la imagen a lo ancho"
        '
        'tsbAjuste3
        '
        Me.tsbAjuste3.CheckOnClick = True
        Me.tsbAjuste3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbAjuste3.Image = Global.Digitalización.My.Resources.Resources.Ajuste3
        Me.tsbAjuste3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbAjuste3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAjuste3.Name = "tsbAjuste3"
        Me.tsbAjuste3.Size = New System.Drawing.Size(31, 42)
        Me.tsbAjuste3.Text = "ToolStripButton13"
        Me.tsbAjuste3.ToolTipText = "Ajustar la imagen a lo alto"
        '
        'tsbAjuste4
        '
        Me.tsbAjuste4.CheckOnClick = True
        Me.tsbAjuste4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbAjuste4.Image = Global.Digitalización.My.Resources.Resources.Ajuste4
        Me.tsbAjuste4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbAjuste4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAjuste4.Name = "tsbAjuste4"
        Me.tsbAjuste4.Size = New System.Drawing.Size(31, 42)
        Me.tsbAjuste4.Text = "ToolStripButton13"
        Me.tsbAjuste4.ToolTipText = "Ajustar la imagen a su proporción original"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 45)
        '
        'pnlPresentacion1
        '
        Me.pnlPresentacion1.AutoScroll = True
        Me.pnlPresentacion1.Controls.Add(Me.IMGeditPrincipal)
        Me.pnlPresentacion1.Location = New System.Drawing.Point(0, 44)
        Me.pnlPresentacion1.Name = "pnlPresentacion1"
        Me.pnlPresentacion1.Size = New System.Drawing.Size(105, 73)
        Me.pnlPresentacion1.TabIndex = 6
        '
        'IMGeditPrincipal
        '
        Me.IMGeditPrincipal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.IMGeditPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.IMGeditPrincipal.Name = "IMGeditPrincipal"
        Me.IMGeditPrincipal.Size = New System.Drawing.Size(105, 73)
        Me.IMGeditPrincipal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.IMGeditPrincipal.TabIndex = 12
        Me.IMGeditPrincipal.TabStop = False
        '
        'pnlPresentacion2
        '
        Me.pnlPresentacion2.AutoScroll = True
        Me.pnlPresentacion2.Controls.Add(Me.imgEditDerecha)
        Me.pnlPresentacion2.Controls.Add(Me.ImgEditIzquierda)
        Me.pnlPresentacion2.Location = New System.Drawing.Point(12, 179)
        Me.pnlPresentacion2.Name = "pnlPresentacion2"
        Me.pnlPresentacion2.Size = New System.Drawing.Size(432, 314)
        Me.pnlPresentacion2.TabIndex = 8
        Me.pnlPresentacion2.Visible = False
        '
        'imgEditDerecha
        '
        Me.imgEditDerecha.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.imgEditDerecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imgEditDerecha.Location = New System.Drawing.Point(327, 3)
        Me.imgEditDerecha.Name = "imgEditDerecha"
        Me.imgEditDerecha.Size = New System.Drawing.Size(105, 73)
        Me.imgEditDerecha.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.imgEditDerecha.TabIndex = 14
        Me.imgEditDerecha.TabStop = False
        '
        'ImgEditIzquierda
        '
        Me.ImgEditIzquierda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ImgEditIzquierda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ImgEditIzquierda.Location = New System.Drawing.Point(3, 3)
        Me.ImgEditIzquierda.Name = "ImgEditIzquierda"
        Me.ImgEditIzquierda.Size = New System.Drawing.Size(105, 73)
        Me.ImgEditIzquierda.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ImgEditIzquierda.TabIndex = 13
        Me.ImgEditIzquierda.TabStop = False
        '
        'pnlPresentacion3
        '
        Me.pnlPresentacion3.AutoScroll = True
        Me.pnlPresentacion3.Location = New System.Drawing.Point(281, 62)
        Me.pnlPresentacion3.Name = "pnlPresentacion3"
        Me.pnlPresentacion3.Size = New System.Drawing.Size(105, 73)
        Me.pnlPresentacion3.TabIndex = 9
        Me.pnlPresentacion3.Visible = False
        '
        'tstMoverRegistros
        '
        Me.tstMoverRegistros.AutoSize = False
        Me.tstMoverRegistros.BackColor = System.Drawing.SystemColors.Control
        Me.tstMoverRegistros.Dock = System.Windows.Forms.DockStyle.None
        Me.tstMoverRegistros.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRegistroPrimero, Me.tsbRegistroAnterior, Me.stsBuscaPagina, Me.tsbRegistroSiguiente, Me.tsbRegistroUltimo})
        Me.tstMoverRegistros.Location = New System.Drawing.Point(576, 0)
        Me.tstMoverRegistros.Margin = New System.Windows.Forms.Padding(5)
        Me.tstMoverRegistros.Name = "tstMoverRegistros"
        Me.tstMoverRegistros.Size = New System.Drawing.Size(216, 45)
        Me.tstMoverRegistros.Stretch = True
        Me.tstMoverRegistros.TabIndex = 10
        Me.tstMoverRegistros.Text = "ToolStrip1"
        '
        'tsbRegistroPrimero
        '
        Me.tsbRegistroPrimero.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbRegistroPrimero.Image = Global.Digitalización.My.Resources.Resources.registro_primero_32
        Me.tsbRegistroPrimero.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbRegistroPrimero.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRegistroPrimero.Name = "tsbRegistroPrimero"
        Me.tsbRegistroPrimero.Size = New System.Drawing.Size(36, 42)
        Me.tsbRegistroPrimero.Text = "tsbRegistroPrimero"
        Me.tsbRegistroPrimero.ToolTipText = "Primera página"
        '
        'tsbRegistroAnterior
        '
        Me.tsbRegistroAnterior.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbRegistroAnterior.Image = Global.Digitalización.My.Resources.Resources.registro_anterior_32
        Me.tsbRegistroAnterior.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbRegistroAnterior.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRegistroAnterior.Name = "tsbRegistroAnterior"
        Me.tsbRegistroAnterior.Size = New System.Drawing.Size(36, 42)
        Me.tsbRegistroAnterior.Text = "tsbRegistroAnterior"
        Me.tsbRegistroAnterior.ToolTipText = "Página anterior"
        '
        'stsBuscaPagina
        '
        Me.stsBuscaPagina.AutoSize = False
        Me.stsBuscaPagina.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
        Me.stsBuscaPagina.Name = "stsBuscaPagina"
        Me.stsBuscaPagina.Size = New System.Drawing.Size(40, 29)
        Me.stsBuscaPagina.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.stsBuscaPagina.ToolTipText = "Introduzca el número de página a buscar y pulse intro"
        '
        'tsbRegistroSiguiente
        '
        Me.tsbRegistroSiguiente.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbRegistroSiguiente.Image = Global.Digitalización.My.Resources.Resources.registro_siguiente_32
        Me.tsbRegistroSiguiente.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbRegistroSiguiente.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRegistroSiguiente.Name = "tsbRegistroSiguiente"
        Me.tsbRegistroSiguiente.Size = New System.Drawing.Size(36, 42)
        Me.tsbRegistroSiguiente.Text = "tsbRegistroAnterior"
        Me.tsbRegistroSiguiente.ToolTipText = "Siguiente página"
        '
        'tsbRegistroUltimo
        '
        Me.tsbRegistroUltimo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbRegistroUltimo.Image = Global.Digitalización.My.Resources.Resources.registro_ultimo_32
        Me.tsbRegistroUltimo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbRegistroUltimo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRegistroUltimo.Name = "tsbRegistroUltimo"
        Me.tsbRegistroUltimo.Size = New System.Drawing.Size(36, 42)
        Me.tsbRegistroUltimo.Text = "tsbRegistroAnterior"
        Me.tsbRegistroUltimo.ToolTipText = "Ultima página"
        '
        'tsbImagenUna
        '
        Me.tsbImagenUna.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbImagenUna.Image = Global.Digitalización.My.Resources.Resources.Imagen2_32
        Me.tsbImagenUna.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbImagenUna.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImagenUna.Name = "tsbImagenUna"
        Me.tsbImagenUna.Size = New System.Drawing.Size(32, 42)
        Me.tsbImagenUna.Text = "ToolStripButton1"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.AutoSize = False
        Me.ToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(32, 32)
        Me.ToolStripButton4.Text = "ToolStripButton1"
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.AutoSize = False
        Me.ToolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton5.Image = CType(resources.GetObject("ToolStripButton5.Image"), System.Drawing.Image)
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(32, 32)
        Me.ToolStripButton5.Text = "ToolStripButton1"
        '
        'ToolStripButton6
        '
        Me.ToolStripButton6.AutoSize = False
        Me.ToolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton6.Image = CType(resources.GetObject("ToolStripButton6.Image"), System.Drawing.Image)
        Me.ToolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton6.Name = "ToolStripButton6"
        Me.ToolStripButton6.Size = New System.Drawing.Size(32, 32)
        Me.ToolStripButton6.Text = "ToolStripButton1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = Global.Digitalización.My.Resources.Resources.Imagen1_32
        Me.ToolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(32, 42)
        Me.ToolStripButton1.Text = "ToolStripButton1"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = Global.Digitalización.My.Resources.Resources.ImagenMini_32
        Me.ToolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(33, 42)
        Me.ToolStripButton2.Text = "ToolStripButton1"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Image = Global.Digitalización.My.Resources.Resources.Imagen1_32
        Me.ToolStripButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(32, 42)
        Me.ToolStripButton3.Text = "ToolStripButton3"
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton7.Image = Global.Digitalización.My.Resources.Resources.ImagenMini_32
        Me.ToolStripButton7.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Size = New System.Drawing.Size(33, 42)
        Me.ToolStripButton7.Text = "ToolStripButton3"
        '
        'ToolStripButton8
        '
        Me.ToolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton8.Image = Global.Digitalización.My.Resources.Resources.Imagen2_32
        Me.ToolStripButton8.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton8.Name = "ToolStripButton8"
        Me.ToolStripButton8.Size = New System.Drawing.Size(32, 42)
        Me.ToolStripButton8.Text = "ToolStripButton3"
        '
        'ToolStripButton9
        '
        Me.ToolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton9.Image = Global.Digitalización.My.Resources.Resources.Imagen1_32
        Me.ToolStripButton9.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton9.Name = "ToolStripButton9"
        Me.ToolStripButton9.Size = New System.Drawing.Size(32, 42)
        Me.ToolStripButton9.Text = "ToolStripButton3"
        '
        'ToolStripButton10
        '
        Me.ToolStripButton10.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton10.Image = Global.Digitalización.My.Resources.Resources.ImagenMini_32
        Me.ToolStripButton10.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton10.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton10.Name = "ToolStripButton10"
        Me.ToolStripButton10.Size = New System.Drawing.Size(33, 42)
        Me.ToolStripButton10.Text = "ToolStripButton10"
        '
        'ToolStripButton11
        '
        Me.ToolStripButton11.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton11.Image = Global.Digitalización.My.Resources.Resources.Imagen2_32
        Me.ToolStripButton11.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton11.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton11.Name = "ToolStripButton11"
        Me.ToolStripButton11.Size = New System.Drawing.Size(32, 42)
        Me.ToolStripButton11.Text = "ToolStripButton10"
        '
        'ToolStripButton12
        '
        Me.ToolStripButton12.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton12.Image = Global.Digitalización.My.Resources.Resources.Imagen1_32
        Me.ToolStripButton12.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton12.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton12.Name = "ToolStripButton12"
        Me.ToolStripButton12.Size = New System.Drawing.Size(32, 42)
        Me.ToolStripButton12.Text = "ToolStripButton10"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(291, 22)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(255, 15)
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar1.TabIndex = 11
        '
        'lblProgressBar
        '
        Me.lblProgressBar.BackColor = System.Drawing.Color.Transparent
        Me.lblProgressBar.ForeColor = System.Drawing.Color.Black
        Me.lblProgressBar.Location = New System.Drawing.Point(390, 0)
        Me.lblProgressBar.Name = "lblProgressBar"
        Me.lblProgressBar.Size = New System.Drawing.Size(54, 22)
        Me.lblProgressBar.TabIndex = 12
        Me.lblProgressBar.Text = "Label9"
        Me.lblProgressBar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmDigitalizacionTwain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1418, 737)
        Me.Controls.Add(Me.lblProgressBar)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.pnlPresentacion3)
        Me.Controls.Add(Me.tstMoverRegistros)
        Me.Controls.Add(Me.tstTipoAjuste)
        Me.Controls.Add(Me.pnlPresentacion2)
        Me.Controls.Add(Me.tstTipoPresentacion)
        Me.Controls.Add(Me.pnlPresentacion1)
        Me.Controls.Add(Me.Panel1)
        Me.KeyPreview = True
        Me.Name = "frmDigitalizacionTwain"
        Me.Text = "Digitalización iScan"
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        Me.Panel1.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.nudGrados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tstAccionesDocumentos.ResumeLayout(False)
        Me.tstAccionesDocumentos.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menuDocumentos.ResumeLayout(False)
        Me.tstTipoPresentacion.ResumeLayout(False)
        Me.tstTipoPresentacion.PerformLayout()
        Me.tstTipoAjuste.ResumeLayout(False)
        Me.tstTipoAjuste.PerformLayout()
        Me.pnlPresentacion1.ResumeLayout(False)
        CType(Me.IMGeditPrincipal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPresentacion2.ResumeLayout(False)
        CType(Me.imgEditDerecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImgEditIzquierda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tstMoverRegistros.ResumeLayout(False)
        Me.tstMoverRegistros.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtNHC As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lstNHC As System.Windows.Forms.ListBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmdCerrarLote As LibreriaCadenaProduccion.Controles.Botones.CtrlBotonGrande
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboTipoLote As System.Windows.Forms.ComboBox
    Friend WithEvents lblLote As System.Windows.Forms.Label
    Friend WithEvents lblNombreDocumento As System.Windows.Forms.Label
    Friend WithEvents lblPaginaDocumento As System.Windows.Forms.Label
    Friend WithEvents lblIdDocumento As System.Windows.Forms.Label
    Friend WithEvents lblPaginasLote As System.Windows.Forms.Label
    Friend WithEvents colidDocumento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPagina As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNHC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents menuDocumentos As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuSustituirImagen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEliminarImagen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRotaImagen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuOriginalMalEstado As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents tstTipoPresentacion As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbImagenUna As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton6 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton8 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton9 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton12 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton11 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton10 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbImagen1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbImagen2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbImagenMini As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tstTipoAjuste As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbAjuste1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbAjuste2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbAjuste3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbAjuste4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents pnlPresentacion1 As System.Windows.Forms.Panel
    Friend WithEvents pnlPresentacion2 As System.Windows.Forms.Panel
    Friend WithEvents pnlPresentacion3 As System.Windows.Forms.Panel
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents cmdDigitalizar As System.Windows.Forms.Button
    Friend WithEvents tstAccionesDocumentos As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbAccion1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbAccion2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbAccion3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbAccion4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripProgressBar1 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents IMGeditPrincipal As System.Windows.Forms.PictureBox
    Friend WithEvents ImgEditIzquierda As System.Windows.Forms.PictureBox
    Friend WithEvents imgEditDerecha As System.Windows.Forms.PictureBox
    Friend WithEvents tstMoverRegistros As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbRegistroPrimero As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbRegistroUltimo As System.Windows.Forms.ToolStripButton
    Friend WithEvents stsBuscaPagina As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tsbRegistroAnterior As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbRegistroSiguiente As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblLotesUsuario As System.Windows.Forms.Label
    Friend WithEvents cmdGuardar As System.Windows.Forms.Button
    Friend WithEvents tsbAccion5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdGuardarDocumentos As LibreriaCadenaProduccion.Controles.Botones.CtrlBotonGrande
    Friend WithEvents tsbAccion6 As System.Windows.Forms.ToolStripButton
    Friend WithEvents tstPorcentajeNegro As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents cmdSincronizar As LibreriaCadenaProduccion.Controles.Botones.CtrlBotonGrande
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents lblProgressBar As System.Windows.Forms.Label
    Friend WithEvents InsertarPáginaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdPorcentajeNegro As System.Windows.Forms.Button
    Friend WithEvents cmdRecargarLista As System.Windows.Forms.Button
    Friend WithEvents nudGrados As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents RotarPágina90ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsbAccion7 As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdAyuda As System.Windows.Forms.Button
    Friend WithEvents chkPerfiles As CheckBox
End Class
