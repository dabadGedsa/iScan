<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPreparacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPreparacion))
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Historia 12356")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Historia 12357")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Lote 001", New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2})
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Lote 002")
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Colección 001", New System.Windows.Forms.TreeNode() {TreeNode3, TreeNode4})
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Caja 001", New System.Windows.Forms.TreeNode() {TreeNode5})
        Dim TreeNode7 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Colección 001")
        Dim TreeNode8 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Caja 002", New System.Windows.Forms.TreeNode() {TreeNode7})
        Me.splGeneral = New System.Windows.Forms.SplitContainer()
        Me.lblError = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboServicio = New System.Windows.Forms.ComboBox()
        Me.cboTipoDocumento = New System.Windows.Forms.ComboBox()
        Me.chkBloquear = New System.Windows.Forms.CheckBox()
        Me.lblTipoLote = New System.Windows.Forms.Label()
        Me.PB_OK = New System.Windows.Forms.PictureBox()
        Me.PB_KO = New System.Windows.Forms.PictureBox()
        Me.lblUserPistoleado = New System.Windows.Forms.Label()
        Me.lblHistoria = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblLote = New System.Windows.Forms.Label()
        Me.lblColeccion = New System.Windows.Forms.Label()
        Me.lblCaja = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.pnlGeneral1 = New System.Windows.Forms.Panel()
        Me.lblUsuario = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.trvGeneral = New System.Windows.Forms.TreeView()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.splGeneral.Panel1.SuspendLayout()
        Me.splGeneral.Panel2.SuspendLayout()
        Me.splGeneral.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PB_OK, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PB_KO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlGeneral1.SuspendLayout()
        Me.SuspendLayout()
        '
        'splGeneral
        '
        Me.splGeneral.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splGeneral.Location = New System.Drawing.Point(0, 0)
        Me.splGeneral.Name = "splGeneral"
        '
        'splGeneral.Panel1
        '
        Me.splGeneral.Panel1.Controls.Add(Me.lblError)
        Me.splGeneral.Panel1.Controls.Add(Me.Panel1)
        Me.splGeneral.Panel1.Controls.Add(Me.pnlGeneral1)
        Me.splGeneral.Panel1MinSize = 600
        '
        'splGeneral.Panel2
        '
        Me.splGeneral.Panel2.Controls.Add(Me.trvGeneral)
        Me.splGeneral.Size = New System.Drawing.Size(1402, 863)
        Me.splGeneral.SplitterDistance = 1033
        Me.splGeneral.TabIndex = 6
        '
        'lblError
        '
        Me.lblError.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblError.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblError.ForeColor = System.Drawing.Color.Red
        Me.lblError.Location = New System.Drawing.Point(0, 753)
        Me.lblError.Name = "lblError"
        Me.lblError.Size = New System.Drawing.Size(1033, 110)
        Me.lblError.TabIndex = 16
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.cboServicio)
        Me.Panel1.Controls.Add(Me.cboTipoDocumento)
        Me.Panel1.Controls.Add(Me.chkBloquear)
        Me.Panel1.Controls.Add(Me.lblTipoLote)
        Me.Panel1.Controls.Add(Me.PB_OK)
        Me.Panel1.Controls.Add(Me.PB_KO)
        Me.Panel1.Controls.Add(Me.lblUserPistoleado)
        Me.Panel1.Controls.Add(Me.lblHistoria)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.lblLote)
        Me.Panel1.Controls.Add(Me.lblColeccion)
        Me.Panel1.Controls.Add(Me.lblCaja)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Location = New System.Drawing.Point(12, 92)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(690, 658)
        Me.Panel1.TabIndex = 13
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(95, 139)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(95, 25)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "Servicio:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(21, 89)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(172, 25)
        Me.Label7.TabIndex = 24
        Me.Label7.Text = "Tipo documento:"
        '
        'cboServicio
        '
        Me.cboServicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboServicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboServicio.FormattingEnabled = True
        Me.cboServicio.Location = New System.Drawing.Point(196, 136)
        Me.cboServicio.Name = "cboServicio"
        Me.cboServicio.Size = New System.Drawing.Size(478, 33)
        Me.cboServicio.TabIndex = 23
        '
        'cboTipoDocumento
        '
        Me.cboTipoDocumento.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboTipoDocumento.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoDocumento.FormattingEnabled = True
        Me.cboTipoDocumento.Location = New System.Drawing.Point(194, 86)
        Me.cboTipoDocumento.Name = "cboTipoDocumento"
        Me.cboTipoDocumento.Size = New System.Drawing.Size(478, 33)
        Me.cboTipoDocumento.TabIndex = 22
        '
        'chkBloquear
        '
        Me.chkBloquear.AutoSize = True
        Me.chkBloquear.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkBloquear.Location = New System.Drawing.Point(532, 352)
        Me.chkBloquear.Name = "chkBloquear"
        Me.chkBloquear.Size = New System.Drawing.Size(130, 33)
        Me.chkBloquear.TabIndex = 21
        Me.chkBloquear.Text = "Bloquear"
        Me.chkBloquear.UseVisualStyleBackColor = True
        '
        'lblTipoLote
        '
        Me.lblTipoLote.BackColor = System.Drawing.SystemColors.Control
        Me.lblTipoLote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTipoLote.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoLote.ForeColor = System.Drawing.Color.Blue
        Me.lblTipoLote.Location = New System.Drawing.Point(194, 339)
        Me.lblTipoLote.Name = "lblTipoLote"
        Me.lblTipoLote.Size = New System.Drawing.Size(332, 51)
        Me.lblTipoLote.TabIndex = 19
        Me.lblTipoLote.Text = "Historias"
        Me.lblTipoLote.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PB_OK
        '
        Me.PB_OK.Image = CType(resources.GetObject("PB_OK.Image"), System.Drawing.Image)
        Me.PB_OK.Location = New System.Drawing.Point(18, 546)
        Me.PB_OK.Name = "PB_OK"
        Me.PB_OK.Size = New System.Drawing.Size(511, 27)
        Me.PB_OK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PB_OK.TabIndex = 3
        Me.PB_OK.TabStop = False
        Me.PB_OK.Visible = False
        '
        'PB_KO
        '
        Me.PB_KO.Image = CType(resources.GetObject("PB_KO.Image"), System.Drawing.Image)
        Me.PB_KO.Location = New System.Drawing.Point(18, 546)
        Me.PB_KO.Name = "PB_KO"
        Me.PB_KO.Size = New System.Drawing.Size(511, 27)
        Me.PB_KO.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PB_KO.TabIndex = 18
        Me.PB_KO.TabStop = False
        Me.PB_KO.Visible = False
        '
        'lblUserPistoleado
        '
        Me.lblUserPistoleado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblUserPistoleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!)
        Me.lblUserPistoleado.Location = New System.Drawing.Point(196, 12)
        Me.lblUserPistoleado.Name = "lblUserPistoleado"
        Me.lblUserPistoleado.Size = New System.Drawing.Size(331, 51)
        Me.lblUserPistoleado.TabIndex = 16
        Me.lblUserPistoleado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblHistoria
        '
        Me.lblHistoria.BackColor = System.Drawing.SystemColors.Control
        Me.lblHistoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblHistoria.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHistoria.Location = New System.Drawing.Point(193, 481)
        Me.lblHistoria.Name = "lblHistoria"
        Me.lblHistoria.Size = New System.Drawing.Size(331, 51)
        Me.lblHistoria.TabIndex = 7
        Me.lblHistoria.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(45, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(157, 42)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Usuario:"
        '
        'lblLote
        '
        Me.lblLote.BackColor = System.Drawing.SystemColors.Control
        Me.lblLote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLote.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLote.Location = New System.Drawing.Point(193, 411)
        Me.lblLote.Name = "lblLote"
        Me.lblLote.Size = New System.Drawing.Size(332, 51)
        Me.lblLote.TabIndex = 6
        Me.lblLote.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblColeccion
        '
        Me.lblColeccion.BackColor = System.Drawing.SystemColors.Control
        Me.lblColeccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblColeccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColeccion.Location = New System.Drawing.Point(196, 265)
        Me.lblColeccion.Name = "lblColeccion"
        Me.lblColeccion.Size = New System.Drawing.Size(331, 51)
        Me.lblColeccion.TabIndex = 5
        Me.lblColeccion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCaja
        '
        Me.lblCaja.BackColor = System.Drawing.SystemColors.Control
        Me.lblCaja.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCaja.Location = New System.Drawing.Point(195, 191)
        Me.lblCaja.Name = "lblCaja"
        Me.lblCaja.Size = New System.Drawing.Size(332, 51)
        Me.lblCaja.TabIndex = 4
        Me.lblCaja.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(45, 485)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(154, 42)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Historia:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(99, 416)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 42)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Lote:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 274)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(193, 42)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Colección:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(97, 195)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 42)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Caja:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(18, 343)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(184, 42)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Tipo Lote:"
        '
        'pnlGeneral1
        '
        Me.pnlGeneral1.AutoSize = True
        Me.pnlGeneral1.Controls.Add(Me.lblUsuario)
        Me.pnlGeneral1.Controls.Add(Me.txtCodigo)
        Me.pnlGeneral1.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlGeneral1.Location = New System.Drawing.Point(0, 0)
        Me.pnlGeneral1.Name = "pnlGeneral1"
        Me.pnlGeneral1.Size = New System.Drawing.Size(1033, 77)
        Me.pnlGeneral1.TabIndex = 7
        '
        'lblUsuario
        '
        Me.lblUsuario.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsuario.ForeColor = System.Drawing.Color.Maroon
        Me.lblUsuario.Location = New System.Drawing.Point(0, 0)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(1033, 17)
        Me.lblUsuario.TabIndex = 8
        Me.lblUsuario.Text = "Usuario conectado"
        Me.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblUsuario.Visible = False
        '
        'txtCodigo
        '
        Me.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo.Location = New System.Drawing.Point(12, 12)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(527, 62)
        Me.txtCodigo.TabIndex = 12
        Me.txtCodigo.Text = "Posicione el cursor"
        Me.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'trvGeneral
        '
        Me.trvGeneral.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.trvGeneral.Dock = System.Windows.Forms.DockStyle.Fill
        Me.trvGeneral.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.trvGeneral.Indent = 50
        Me.trvGeneral.Location = New System.Drawing.Point(0, 0)
        Me.trvGeneral.Name = "trvGeneral"
        TreeNode1.ForeColor = System.Drawing.Color.DimGray
        TreeNode1.Name = "Historia"
        TreeNode1.Text = "Historia 12356"
        TreeNode2.ForeColor = System.Drawing.Color.DimGray
        TreeNode2.Name = "Historia"
        TreeNode2.Text = "Historia 12357"
        TreeNode3.ForeColor = System.Drawing.Color.Black
        TreeNode3.Name = "Lote"
        TreeNode3.Text = "Lote 001"
        TreeNode4.ForeColor = System.Drawing.Color.Black
        TreeNode4.Name = "Lote"
        TreeNode4.Text = "Lote 002"
        TreeNode5.ForeColor = System.Drawing.Color.Green
        TreeNode5.Name = "Coleccion"
        TreeNode5.Text = "Colección 001"
        TreeNode6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        TreeNode6.Name = "Caja"
        TreeNode6.Text = "Caja 001"
        TreeNode7.ForeColor = System.Drawing.Color.Green
        TreeNode7.Name = "Coleccion"
        TreeNode7.Text = "Colección 001"
        TreeNode8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        TreeNode8.Name = "Caja"
        TreeNode8.Text = "Caja 002"
        Me.trvGeneral.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode6, TreeNode8})
        Me.trvGeneral.Size = New System.Drawing.Size(365, 863)
        Me.trvGeneral.TabIndex = 2
        '
        'Timer1
        '
        Me.Timer1.Interval = 200
        '
        'frmPreparacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1402, 863)
        Me.Controls.Add(Me.splGeneral)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPreparacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Preparación Lotes"
        Me.splGeneral.Panel1.ResumeLayout(False)
        Me.splGeneral.Panel1.PerformLayout()
        Me.splGeneral.Panel2.ResumeLayout(False)
        Me.splGeneral.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PB_OK, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PB_KO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlGeneral1.ResumeLayout(False)
        Me.pnlGeneral1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents splGeneral As System.Windows.Forms.SplitContainer
    Friend WithEvents trvGeneral As System.Windows.Forms.TreeView
    Friend WithEvents pnlGeneral1 As System.Windows.Forms.Panel
    Friend WithEvents lblUsuario As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblCaja As System.Windows.Forms.Label
    Friend WithEvents lblHistoria As System.Windows.Forms.Label
    Friend WithEvents lblLote As System.Windows.Forms.Label
    Friend WithEvents lblColeccion As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblError As System.Windows.Forms.Label
    Friend WithEvents lblUserPistoleado As System.Windows.Forms.Label
    Friend WithEvents PB_KO As System.Windows.Forms.PictureBox
    Friend WithEvents PB_OK As System.Windows.Forms.PictureBox
    Friend WithEvents lblTipoLote As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents chkBloquear As System.Windows.Forms.CheckBox
    Friend WithEvents cboServicio As ComboBox
    Friend WithEvents cboTipoDocumento As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
End Class
