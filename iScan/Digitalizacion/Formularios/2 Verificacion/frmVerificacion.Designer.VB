Imports libreriacadenaproduccion

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVerificacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVerificacion))
        Me.PictureBox1 = New AxImgeditLibCtl.AxImgEdit
        Me.grdDocumentos = New System.Windows.Forms.DataGridView
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.btnSig = New System.Windows.Forms.Button
        Me.btnAnt = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.CtrlBotonGrande1 = New LibreriaCadenaProduccion.Controles.Botones.CtrlBotonGrande
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDocumentos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PictureBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.OcxState = CType(resources.GetObject("PictureBox1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.PictureBox1.Size = New System.Drawing.Size(471, 550)
        Me.PictureBox1.TabIndex = 100
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Tag = "100"
        '
        'grdDocumentos
        '
        Me.grdDocumentos.AllowUserToAddRows = False
        Me.grdDocumentos.AllowUserToDeleteRows = False
        Me.grdDocumentos.AllowUserToResizeRows = False
        Me.grdDocumentos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdDocumentos.Location = New System.Drawing.Point(480, 0)
        Me.grdDocumentos.Name = "grdDocumentos"
        Me.grdDocumentos.ReadOnly = True
        Me.grdDocumentos.RowHeadersWidth = 25
        Me.grdDocumentos.RowTemplate.ReadOnly = True
        Me.grdDocumentos.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdDocumentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdDocumentos.Size = New System.Drawing.Size(535, 478)
        Me.grdDocumentos.TabIndex = 1
        Me.grdDocumentos.Tag = "1"
        '
        'ListBox1
        '
        Me.ListBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Items.AddRange(New Object() {"Sin incidencia     Num0    Mal digi.            Num7    Girar             +", "FIP incorrecto    Num1   Solapados      " & Global.Microsoft.VisualBasic.ChrW(9) & "Num9   Sin caratula    x            ", "Fuera de sitio    Num3    Carat. Camb.    N         Zoom              *", "Para Borrar        Num4    BC. Erroneo      U        ", "Docs Desor.       Num6    Fmt. no valido   V", "   "})
        Me.ListBox1.Location = New System.Drawing.Point(604, 486)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(411, 69)
        Me.ListBox1.TabIndex = 9
        Me.ListBox1.Tag = "9"
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.btnSig)
        Me.GroupBox4.Controls.Add(Me.btnAnt)
        Me.GroupBox4.Location = New System.Drawing.Point(480, 484)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(49, 69)
        Me.GroupBox4.TabIndex = 8
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Imagen"
        '
        'btnSig
        '
        Me.btnSig.Location = New System.Drawing.Point(22, 15)
        Me.btnSig.Name = "btnSig"
        Me.btnSig.Size = New System.Drawing.Size(20, 45)
        Me.btnSig.TabIndex = 14
        Me.btnSig.Tag = "14"
        Me.btnSig.Text = ">"
        Me.btnSig.UseVisualStyleBackColor = True
        '
        'btnAnt
        '
        Me.btnAnt.Location = New System.Drawing.Point(5, 15)
        Me.btnAnt.Name = "btnAnt"
        Me.btnAnt.Size = New System.Drawing.Size(18, 45)
        Me.btnAnt.TabIndex = 13
        Me.btnAnt.Tag = "13"
        Me.btnAnt.Text = "<"
        Me.btnAnt.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.CtrlBotonGrande1)
        Me.GroupBox2.Location = New System.Drawing.Point(532, 484)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(66, 69)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Lote"
        '
        'CtrlBotonGrande1
        '
        Me.CtrlBotonGrande1.BackColor = System.Drawing.Color.Transparent
        Me.CtrlBotonGrande1.EnabledBoton = True
        Me.CtrlBotonGrande1.Location = New System.Drawing.Point(3, 19)
        Me.CtrlBotonGrande1.Name = "CtrlBotonGrande1"
        Me.CtrlBotonGrande1.pImagenMouseEnter = CType(resources.GetObject("CtrlBotonGrande1.pImagenMouseEnter"), System.Drawing.Image)
        Me.CtrlBotonGrande1.pImagenMouseLeave = CType(resources.GetObject("CtrlBotonGrande1.pImagenMouseLeave"), System.Drawing.Image)
        Me.CtrlBotonGrande1.pImagenMouseOver = CType(resources.GetObject("CtrlBotonGrande1.pImagenMouseOver"), System.Drawing.Image)
        Me.CtrlBotonGrande1.Size = New System.Drawing.Size(59, 41)
        Me.CtrlBotonGrande1.TabIndex = 50
        Me.CtrlBotonGrande1.Tag = "50"
        Me.CtrlBotonGrande1.TextoBoton = "Cerrar Lote"
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Controls.Add(Me.PictureBox1)
        Me.PictureBox2.Location = New System.Drawing.Point(3, 3)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(471, 550)
        Me.PictureBox2.TabIndex = 101
        Me.PictureBox2.TabStop = False
        '
        'frmVerificacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1016, 559)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.grdDocumentos)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "frmVerificacion"
        Me.Text = "Verificacion Digi"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDocumentos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PictureBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAnt As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents grdDocumentos As System.Windows.Forms.DataGridView
    Friend WithEvents btnSig As System.Windows.Forms.Button
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents CtrlBotonGrande1 As libreriacadenaproduccion.Controles.Botones.CtrlBotonGrande
    Friend WithEvents PictureBox1 As AxImgeditLibCtl.AxImgEdit
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    'Friend WithEvents PictureBox1 As AxImgeditLibCtl.AxImgEdit

End Class
