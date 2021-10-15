<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmScaner
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

    'Requerido por el Disenyador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Disenyador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Disenyador de Windows Forms.  
    'No lo modifique con el editor de c?digo.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmScaner))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.AxImgEdit1 = New AxImgeditLibCtl.AxImgEdit
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.RtbMensajes = New System.Windows.Forms.RichTextBox
        Me.lblPaginaActual = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton
        Me.tscmbConfigurar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton
        Me.AxImgScan1 = New AxScanLibCtl.AxImgScan
        Me.ListView1 = New System.Windows.Forms.ListView
        Me.Pagina = New System.Windows.Forms.ColumnHeader
        Me.nomArchivoTIF = New System.Windows.Forms.ColumnHeader
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cmbRotar = New System.Windows.Forms.Button
        Me.btRedigi = New System.Windows.Forms.Button
        Me.chkDesplzIncidencia = New System.Windows.Forms.CheckBox
        Me.pgOperaciones = New System.Windows.Forms.ProgressBar
        Me.cmdSustituir = New System.Windows.Forms.Button
        Me.btnEliminar = New System.Windows.Forms.Button
        Me.bntAnyadir = New System.Windows.Forms.Button
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.btnSig = New System.Windows.Forms.Button
        Me.btnAnt = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.CtrlBotonGrande1 = New LibreriaCadenaProduccion.Controles.Botones.CtrlBotonGrande
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.AxImgEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.AxImgScan1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.AxImgEdit1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(1016, 639)
        Me.SplitContainer1.SplitterDistance = 537
        Me.SplitContainer1.TabIndex = 0
        '
        'AxImgEdit1
        '
        Me.AxImgEdit1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AxImgEdit1.Location = New System.Drawing.Point(0, 0)
        Me.AxImgEdit1.Name = "AxImgEdit1"
        Me.AxImgEdit1.OcxState = CType(resources.GetObject("AxImgEdit1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxImgEdit1.Size = New System.Drawing.Size(537, 639)
        Me.AxImgEdit1.TabIndex = 0
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.Panel1)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.ListView1)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Panel2)
        Me.SplitContainer2.Size = New System.Drawing.Size(475, 639)
        Me.SplitContainer2.SplitterDistance = 300
        Me.SplitContainer2.TabIndex = 10
        '
        'Panel1
        '
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.ToolStrip1)
        Me.Panel1.Controls.Add(Me.AxImgScan1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(475, 300)
        Me.Panel1.TabIndex = 10
        '
        'GroupBox1
        '
        Me.GroupBox1.BackgroundImage = Global.correccionDigi.My.Resources.Resources.barraMenu1
        Me.GroupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GroupBox1.Controls.Add(Me.RtbMensajes)
        Me.GroupBox1.Controls.Add(Me.lblPaginaActual)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 43)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(475, 257)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Propiedades"
        '
        'RtbMensajes
        '
        Me.RtbMensajes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RtbMensajes.Location = New System.Drawing.Point(6, 39)
        Me.RtbMensajes.Name = "RtbMensajes"
        Me.RtbMensajes.ReadOnly = True
        Me.RtbMensajes.Size = New System.Drawing.Size(463, 200)
        Me.RtbMensajes.TabIndex = 10
        Me.RtbMensajes.Text = ""
        '
        'lblPaginaActual
        '
        Me.lblPaginaActual.AutoSize = True
        Me.lblPaginaActual.Location = New System.Drawing.Point(175, 21)
        Me.lblPaginaActual.Name = "lblPaginaActual"
        Me.lblPaginaActual.Size = New System.Drawing.Size(51, 13)
        Me.lblPaginaActual.TabIndex = 2
        Me.lblPaginaActual.Text = "n_pagina"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(148, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Siguiente Pagina a digitalizar: "
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.BackgroundImage = Global.correccionDigi.My.Resources.Resources.barrainf
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripButton3, Me.ToolStripButton2, Me.tscmbConfigurar, Me.ToolStripButton4})
        Me.ToolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(475, 43)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.ToolStripButton1.Image = Global.correccionDigi.My.Resources.Resources.forward
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(83, 40)
        Me.ToolStripButton1.Text = "Digitalizar"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.ToolStripButton3.Image = Global.correccionDigi.My.Resources.Resources.editdelete
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(116, 40)
        Me.ToolStripButton3.Text = "Parar Digitalizar "
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.ToolStripButton2.Image = Global.correccionDigi.My.Resources.Resources._exit
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(99, 40)
        Me.ToolStripButton2.Text = "Desconectar "
        '
        'tscmbConfigurar
        '
        Me.tscmbConfigurar.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.tscmbConfigurar.Image = CType(resources.GetObject("tscmbConfigurar.Image"), System.Drawing.Image)
        Me.tscmbConfigurar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tscmbConfigurar.Name = "tscmbConfigurar"
        Me.tscmbConfigurar.Size = New System.Drawing.Size(107, 40)
        Me.tscmbConfigurar.Text = "Configuracion"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(75, 24)
        Me.ToolStripButton4.Text = "Caratula"
        '
        'AxImgScan1
        '
        Me.AxImgScan1.Enabled = True
        Me.AxImgScan1.Location = New System.Drawing.Point(437, 82)
        Me.AxImgScan1.Name = "AxImgScan1"
        Me.AxImgScan1.OcxState = CType(resources.GetObject("AxImgScan1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxImgScan1.Size = New System.Drawing.Size(32, 32)
        Me.AxImgScan1.TabIndex = 0
        '
        'ListView1
        '
        Me.ListView1.AutoArrange = False
        Me.ListView1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Pagina, Me.nomArchivoTIF})
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView1.FullRowSelect = True
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(0, 0)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(475, 252)
        Me.ListView1.TabIndex = 7
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'Pagina
        '
        Me.Pagina.Text = "Pagina"
        Me.Pagina.Width = 120
        '
        'nomArchivoTIF
        '
        Me.nomArchivoTIF.Text = "nomArchivoTIF"
        Me.nomArchivoTIF.Width = 1000
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.GroupBox5)
        Me.Panel2.Controls.Add(Me.GroupBox2)
        Me.Panel2.Controls.Add(Me.GroupBox4)
        Me.Panel2.Controls.Add(Me.GroupBox3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 252)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(475, 83)
        Me.Panel2.TabIndex = 8
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.Controls.Add(Me.PictureBox1)
        Me.GroupBox5.Location = New System.Drawing.Point(405, 9)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(70, 70)
        Me.GroupBox5.TabIndex = 110
        Me.GroupBox5.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.correccionDigi.My.Resources.Resources.forward
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(6, 16)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(57, 49)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.cmbRotar)
        Me.GroupBox2.Controls.Add(Me.btRedigi)
        Me.GroupBox2.Controls.Add(Me.chkDesplzIncidencia)
        Me.GroupBox2.Controls.Add(Me.pgOperaciones)
        Me.GroupBox2.Controls.Add(Me.cmdSustituir)
        Me.GroupBox2.Controls.Add(Me.btnEliminar)
        Me.GroupBox2.Controls.Add(Me.bntAnyadir)
        Me.GroupBox2.Location = New System.Drawing.Point(15, 11)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(314, 69)
        Me.GroupBox2.TabIndex = 109
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Documentos"
        '
        'cmbRotar
        '
        Me.cmbRotar.Location = New System.Drawing.Point(245, 15)
        Me.cmbRotar.Name = "cmbRotar"
        Me.cmbRotar.Size = New System.Drawing.Size(63, 23)
        Me.cmbRotar.TabIndex = 16
        Me.cmbRotar.Text = "Rotar"
        Me.cmbRotar.UseVisualStyleBackColor = True
        '
        'btRedigi
        '
        Me.btRedigi.Location = New System.Drawing.Point(121, 15)
        Me.btRedigi.Name = "btRedigi"
        Me.btRedigi.Size = New System.Drawing.Size(60, 23)
        Me.btRedigi.TabIndex = 15
        Me.btRedigi.Text = "Redigi"
        Me.btRedigi.UseVisualStyleBackColor = True
        '
        'chkDesplzIncidencia
        '
        Me.chkDesplzIncidencia.AutoSize = True
        Me.chkDesplzIncidencia.Location = New System.Drawing.Point(6, 46)
        Me.chkDesplzIncidencia.Name = "chkDesplzIncidencia"
        Me.chkDesplzIncidencia.Size = New System.Drawing.Size(88, 17)
        Me.chkDesplzIncidencia.TabIndex = 14
        Me.chkDesplzIncidencia.Text = "Sel.  escaner"
        Me.chkDesplzIncidencia.UseVisualStyleBackColor = True
        '
        'pgOperaciones
        '
        Me.pgOperaciones.Location = New System.Drawing.Point(116, 43)
        Me.pgOperaciones.Name = "pgOperaciones"
        Me.pgOperaciones.Size = New System.Drawing.Size(192, 19)
        Me.pgOperaciones.TabIndex = 13
        '
        'cmdSustituir
        '
        Me.cmdSustituir.Location = New System.Drawing.Point(181, 15)
        Me.cmdSustituir.Name = "cmdSustituir"
        Me.cmdSustituir.Size = New System.Drawing.Size(63, 23)
        Me.cmdSustituir.TabIndex = 12
        Me.cmdSustituir.Text = "Sustituir"
        Me.cmdSustituir.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Location = New System.Drawing.Point(61, 15)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(60, 23)
        Me.btnEliminar.TabIndex = 11
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'bntAnyadir
        '
        Me.bntAnyadir.Location = New System.Drawing.Point(7, 15)
        Me.bntAnyadir.Name = "bntAnyadir"
        Me.bntAnyadir.Size = New System.Drawing.Size(55, 23)
        Me.bntAnyadir.TabIndex = 10
        Me.bntAnyadir.Text = "Anyadir"
        Me.bntAnyadir.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.btnSig)
        Me.GroupBox4.Controls.Add(Me.btnAnt)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 10)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(61, 69)
        Me.GroupBox4.TabIndex = 108
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Imagen"
        '
        'btnSig
        '
        Me.btnSig.Location = New System.Drawing.Point(29, 16)
        Me.btnSig.Name = "btnSig"
        Me.btnSig.Size = New System.Drawing.Size(25, 45)
        Me.btnSig.TabIndex = 14
        Me.btnSig.Text = ">"
        Me.btnSig.UseVisualStyleBackColor = True
        '
        'btnAnt
        '
        Me.btnAnt.Location = New System.Drawing.Point(5, 16)
        Me.btnAnt.Name = "btnAnt"
        Me.btnAnt.Size = New System.Drawing.Size(25, 45)
        Me.btnAnt.TabIndex = 13
        Me.btnAnt.Text = "<"
        Me.btnAnt.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.CtrlBotonGrande1)
        Me.GroupBox3.Location = New System.Drawing.Point(335, 10)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(70, 70)
        Me.GroupBox3.TabIndex = 107
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Lote"
        '
        'CtrlBotonGrande1
        '
        Me.CtrlBotonGrande1.BackColor = System.Drawing.Color.Transparent
        Me.CtrlBotonGrande1.EnabledBoton = True
        Me.CtrlBotonGrande1.Location = New System.Drawing.Point(5, 19)
        Me.CtrlBotonGrande1.Name = "CtrlBotonGrande1"
        Me.CtrlBotonGrande1.pImagenMouseEnter = Nothing
        Me.CtrlBotonGrande1.pImagenMouseLeave = Nothing
        Me.CtrlBotonGrande1.pImagenMouseOver = Nothing
        Me.CtrlBotonGrande1.Size = New System.Drawing.Size(59, 41)
        Me.CtrlBotonGrande1.TabIndex = 50
        Me.CtrlBotonGrande1.Tag = "50"
        Me.CtrlBotonGrande1.TextoBoton = "Cerrar Lote"
        '
        'frmScaner
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1016, 639)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmScaner"
        Me.Text = "frmScaner"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.AxImgEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.AxImgScan1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents AxImgEdit1 As AxImgeditLibCtl.AxImgEdit
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents Pagina As System.Windows.Forms.ColumnHeader
    Friend WithEvents nomArchivoTIF As System.Windows.Forms.ColumnHeader
    Friend WithEvents AxImgScan1 As AxScanLibCtl.AxImgScan
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents tscmbConfigurar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblPaginaActual As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chkDesplzIncidencia As System.Windows.Forms.CheckBox
    Friend WithEvents pgOperaciones As System.Windows.Forms.ProgressBar
    Friend WithEvents cmdSustituir As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents bntAnyadir As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSig As System.Windows.Forms.Button
    Friend WithEvents btnAnt As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents CtrlBotonGrande1 As LibreriaCadenaProduccion.Controles.Botones.CtrlBotonGrande
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents RtbMensajes As System.Windows.Forms.RichTextBox
    Friend WithEvents btRedigi As System.Windows.Forms.Button
    Friend WithEvents cmbRotar As System.Windows.Forms.Button
End Class
