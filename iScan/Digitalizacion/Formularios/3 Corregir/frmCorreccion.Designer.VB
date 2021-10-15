<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCorreccion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCorreccion))
        Me.grdDocumentos = New System.Windows.Forms.DataGridView
        Me.pnl_registro = New System.Windows.Forms.GroupBox
        Me.chkSeleccionar_escaner = New System.Windows.Forms.CheckBox
        Me.txtNumIcu = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtfechaFin = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.CtrlBotonPequenyo2 = New LibreriaCadenaProduccion.Controles.Botones.ctrlBotonPequenyo
        Me.txtFechaInicio = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtNHC = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.pgOperaciones = New System.Windows.Forms.ProgressBar
        Me.cmdSustituir = New System.Windows.Forms.Button
        Me.btnEliminar = New System.Windows.Forms.Button
        Me.bntAnyadir = New System.Windows.Forms.Button
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.btnSig = New System.Windows.Forms.Button
        Me.btnAnt = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.CtrlBotonGrande1 = New LibreriaCadenaProduccion.Controles.Botones.CtrlBotonGrande
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New AxImgeditLibCtl.AxImgEdit
        CType(Me.grdDocumentos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl_registro.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PictureBox2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdDocumentos
        '
        Me.grdDocumentos.AllowUserToAddRows = False
        Me.grdDocumentos.AllowUserToDeleteRows = False
        Me.grdDocumentos.AllowUserToResizeColumns = False
        Me.grdDocumentos.AllowUserToResizeRows = False
        Me.grdDocumentos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdDocumentos.Location = New System.Drawing.Point(480, 67)
        Me.grdDocumentos.MultiSelect = False
        Me.grdDocumentos.Name = "grdDocumentos"
        Me.grdDocumentos.ReadOnly = True
        Me.grdDocumentos.RowHeadersWidth = 25
        Me.grdDocumentos.RowTemplate.ReadOnly = True
        Me.grdDocumentos.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdDocumentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdDocumentos.Size = New System.Drawing.Size(535, 408)
        Me.grdDocumentos.TabIndex = 1
        Me.grdDocumentos.Tag = "1"
        '
        'pnl_registro
        '
        Me.pnl_registro.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnl_registro.Controls.Add(Me.chkSeleccionar_escaner)
        Me.pnl_registro.Controls.Add(Me.txtNumIcu)
        Me.pnl_registro.Controls.Add(Me.Label6)
        Me.pnl_registro.Controls.Add(Me.txtfechaFin)
        Me.pnl_registro.Controls.Add(Me.Label5)
        Me.pnl_registro.Controls.Add(Me.CtrlBotonPequenyo2)
        Me.pnl_registro.Controls.Add(Me.txtFechaInicio)
        Me.pnl_registro.Controls.Add(Me.Label4)
        Me.pnl_registro.Controls.Add(Me.txtNHC)
        Me.pnl_registro.Controls.Add(Me.Label1)
        Me.pnl_registro.Controls.Add(Me.Label2)
        Me.pnl_registro.Location = New System.Drawing.Point(480, -2)
        Me.pnl_registro.Name = "pnl_registro"
        Me.pnl_registro.Size = New System.Drawing.Size(535, 63)
        Me.pnl_registro.TabIndex = 102
        Me.pnl_registro.TabStop = False
        '
        'chkSeleccionar_escaner
        '
        Me.chkSeleccionar_escaner.AutoSize = True
        Me.chkSeleccionar_escaner.Location = New System.Drawing.Point(31, 40)
        Me.chkSeleccionar_escaner.Name = "chkSeleccionar_escaner"
        Me.chkSeleccionar_escaner.Size = New System.Drawing.Size(124, 17)
        Me.chkSeleccionar_escaner.TabIndex = 114
        Me.chkSeleccionar_escaner.Text = "Seleccionar Escaner"
        Me.chkSeleccionar_escaner.UseVisualStyleBackColor = True
        '
        'txtNumIcu
        '
        Me.txtNumIcu.Location = New System.Drawing.Point(118, 13)
        Me.txtNumIcu.Name = "txtNumIcu"
        Me.txtNumIcu.Size = New System.Drawing.Size(62, 20)
        Me.txtNumIcu.TabIndex = 113
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(93, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(22, 13)
        Me.Label6.TabIndex = 112
        Me.Label6.Text = "Icu"
        '
        'txtfechaFin
        '
        Me.txtfechaFin.Location = New System.Drawing.Point(316, 13)
        Me.txtfechaFin.Name = "txtfechaFin"
        Me.txtfechaFin.Size = New System.Drawing.Size(62, 20)
        Me.txtfechaFin.TabIndex = 111
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(286, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 13)
        Me.Label5.TabIndex = 110
        Me.Label5.Text = "F. fin"
        '
        'CtrlBotonPequenyo2
        '
        Me.CtrlBotonPequenyo2.BackColor = System.Drawing.Color.Transparent
        Me.CtrlBotonPequenyo2.EnabledBoton = True
        Me.CtrlBotonPequenyo2.Location = New System.Drawing.Point(461, 16)
        Me.CtrlBotonPequenyo2.Name = "CtrlBotonPequenyo2"
        Me.CtrlBotonPequenyo2.pImagenMouseEnter = CType(resources.GetObject("CtrlBotonPequenyo2.pImagenMouseEnter"), System.Drawing.Image)
        Me.CtrlBotonPequenyo2.pImagenMouseLeave = CType(resources.GetObject("CtrlBotonPequenyo2.pImagenMouseLeave"), System.Drawing.Image)
        Me.CtrlBotonPequenyo2.pImagenMouseOver = CType(resources.GetObject("CtrlBotonPequenyo2.pImagenMouseOver"), System.Drawing.Image)
        Me.CtrlBotonPequenyo2.Size = New System.Drawing.Size(63, 20)
        Me.CtrlBotonPequenyo2.TabIndex = 109
        Me.CtrlBotonPequenyo2.TextoBoton = "M Rango"
        '
        'txtFechaInicio
        '
        Me.txtFechaInicio.Location = New System.Drawing.Point(219, 13)
        Me.txtFechaInicio.Name = "txtFechaInicio"
        Me.txtFechaInicio.Size = New System.Drawing.Size(67, 20)
        Me.txtFechaInicio.TabIndex = 52
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(191, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(26, 13)
        Me.Label4.TabIndex = 51
        Me.Label4.Text = "F.ini"
        '
        'txtNHC
        '
        Me.txtNHC.Location = New System.Drawing.Point(31, 13)
        Me.txtNHC.Name = "txtNHC"
        Me.txtNHC.Size = New System.Drawing.Size(56, 20)
        Me.txtNHC.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(1, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 50
        Me.Label1.Text = "NHC"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(42, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(25, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "ICU"
        Me.Label2.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.pgOperaciones)
        Me.GroupBox1.Controls.Add(Me.cmdSustituir)
        Me.GroupBox1.Controls.Add(Me.btnEliminar)
        Me.GroupBox1.Controls.Add(Me.bntAnyadir)
        Me.GroupBox1.Location = New System.Drawing.Point(547, 483)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(250, 69)
        Me.GroupBox1.TabIndex = 106
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Documentos"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(120, 15)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(46, 23)
        Me.Button1.TabIndex = 14
        Me.Button1.Text = "Mover"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'pgOperaciones
        '
        Me.pgOperaciones.Location = New System.Drawing.Point(7, 43)
        Me.pgOperaciones.Name = "pgOperaciones"
        Me.pgOperaciones.Size = New System.Drawing.Size(237, 19)
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
        Me.bntAnyadir.Text = "Añadir"
        Me.bntAnyadir.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.btnSig)
        Me.GroupBox4.Controls.Add(Me.btnAnt)
        Me.GroupBox4.Location = New System.Drawing.Point(480, 482)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(61, 69)
        Me.GroupBox4.TabIndex = 104
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
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.CtrlBotonGrande1)
        Me.GroupBox2.Location = New System.Drawing.Point(803, 482)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(70, 70)
        Me.GroupBox2.TabIndex = 103
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Lote"
        '
        'CtrlBotonGrande1
        '
        Me.CtrlBotonGrande1.BackColor = System.Drawing.Color.Transparent
        Me.CtrlBotonGrande1.EnabledBoton = True
        Me.CtrlBotonGrande1.Location = New System.Drawing.Point(5, 19)
        Me.CtrlBotonGrande1.Name = "CtrlBotonGrande1"
        Me.CtrlBotonGrande1.pImagenMouseEnter = CType(resources.GetObject("CtrlBotonGrande1.pImagenMouseEnter"), System.Drawing.Image)
        Me.CtrlBotonGrande1.pImagenMouseLeave = CType(resources.GetObject("CtrlBotonGrande1.pImagenMouseLeave"), System.Drawing.Image)
        Me.CtrlBotonGrande1.pImagenMouseOver = CType(resources.GetObject("CtrlBotonGrande1.pImagenMouseOver"), System.Drawing.Image)
        Me.CtrlBotonGrande1.Size = New System.Drawing.Size(59, 41)
        Me.CtrlBotonGrande1.TabIndex = 50
        Me.CtrlBotonGrande1.Tag = "50"
        Me.CtrlBotonGrande1.TextoBoton = "Cerrar Lote"
        '
        'ListBox1
        '
        Me.ListBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Items.AddRange(New Object() {"Sin incidencia     Num0    ", "FIP incorrecto    Num1      ", "Fuera de sitio    Num3    ", "Para Borrar        Num4   ", "Docs Desor.       Num6   ", "Mal digi.             Num7", "Solapados          Num9  ", "Girar                   +", "Zoom                 *", "Carat. Camb.    N        ", "Elim. Docum.     Sup.      ", "Añadir Doc.       Ins.", "in caratula         x", "BC. Erroneo      U", "Fmt. no valido   V", "Editar FIP           F", "Programa Scan   S", "Programa Edita   E ", "Copiar Imagen   C", "Fichero Correg. Enter"})
        Me.ListBox1.Location = New System.Drawing.Point(878, 484)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(137, 69)
        Me.ListBox1.TabIndex = 108
        Me.ListBox1.Tag = "9"
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
        'frmCorreccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1016, 559)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.pnl_registro)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.grdDocumentos)
        Me.Name = "frmCorreccion"
        Me.Text = "Correccion Digi"
        CType(Me.grdDocumentos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl_registro.ResumeLayout(False)
        Me.pnl_registro.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PictureBox2.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdDocumentos As System.Windows.Forms.DataGridView
    Friend WithEvents PictureBox1 As AxImgeditLibCtl.AxImgEdit
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents pnl_registro As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNHC As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents bntAnyadir As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSig As System.Windows.Forms.Button
    Friend WithEvents btnAnt As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents CtrlBotonGrande1 As LibreriaCadenaProduccion.Controles.Botones.CtrlBotonGrande
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents cmdSustituir As System.Windows.Forms.Button
    Friend WithEvents pgOperaciones As System.Windows.Forms.ProgressBar
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtFechaInicio As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CtrlBotonPequenyo2 As LibreriaCadenaProduccion.Controles.Botones.ctrlBotonPequenyo
    Friend WithEvents txtfechaFin As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtNumIcu As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents chkSeleccionar_escaner As System.Windows.Forms.CheckBox
    'Friend WithEvents PictureBox1 As AxImgeditLibCtl.AxImgEdit

End Class
