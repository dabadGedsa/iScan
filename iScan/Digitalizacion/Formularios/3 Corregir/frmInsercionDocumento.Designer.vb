<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInsercionDocumento
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInsercionDocumento))
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New AxImgeditLibCtl.AxImgEdit
        Me.txtRutaImagen = New System.Windows.Forms.TextBox
        Me.cmdCArgarImagen = New System.Windows.Forms.Button
        Me.btnInsertarDocumento = New System.Windows.Forms.Button
        Me.txtNumIcu = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtNHC = New System.Windows.Forms.TextBox
        Me.txtServicio = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.pnl_Documento = New System.Windows.Forms.GroupBox
        Me.txtHasta = New System.Windows.Forms.NumericUpDown
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtDesde = New System.Windows.Forms.NumericUpDown
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmdPrevisualizacion = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtApellido2 = New System.Windows.Forms.TextBox
        Me.txtApellido = New System.Windows.Forms.TextBox
        Me.txtNombre = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rdbInsertarCartula = New System.Windows.Forms.RadioButton
        Me.rdbInsertarDocumento = New System.Windows.Forms.RadioButton
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.pgOperaciones = New System.Windows.Forms.ProgressBar
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PictureBox2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl_Documento.SuspendLayout()
        CType(Me.txtHasta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDesde, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Controls.Add(Me.PictureBox1)
        Me.PictureBox2.Location = New System.Drawing.Point(10, 12)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(402, 437)
        Me.PictureBox2.TabIndex = 102
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.OcxState = CType(resources.GetObject("PictureBox1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.PictureBox1.Size = New System.Drawing.Size(402, 437)
        Me.PictureBox1.TabIndex = 100
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Tag = "100"
        '
        'txtRutaImagen
        '
        Me.txtRutaImagen.Location = New System.Drawing.Point(48, 24)
        Me.txtRutaImagen.Name = "txtRutaImagen"
        Me.txtRutaImagen.Size = New System.Drawing.Size(114, 20)
        Me.txtRutaImagen.TabIndex = 105
        '
        'cmdCArgarImagen
        '
        Me.cmdCArgarImagen.Location = New System.Drawing.Point(17, 23)
        Me.cmdCArgarImagen.Name = "cmdCArgarImagen"
        Me.cmdCArgarImagen.Size = New System.Drawing.Size(25, 20)
        Me.cmdCArgarImagen.TabIndex = 103
        Me.cmdCArgarImagen.Text = "..."
        Me.cmdCArgarImagen.UseVisualStyleBackColor = True
        '
        'btnInsertarDocumento
        '
        Me.btnInsertarDocumento.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnInsertarDocumento.Location = New System.Drawing.Point(441, 115)
        Me.btnInsertarDocumento.Name = "btnInsertarDocumento"
        Me.btnInsertarDocumento.Size = New System.Drawing.Size(95, 31)
        Me.btnInsertarDocumento.TabIndex = 119
        Me.btnInsertarDocumento.Text = "Insertar"
        Me.btnInsertarDocumento.UseVisualStyleBackColor = True
        '
        'txtNumIcu
        '
        Me.txtNumIcu.Location = New System.Drawing.Point(61, 73)
        Me.txtNumIcu.Name = "txtNumIcu"
        Me.txtNumIcu.Size = New System.Drawing.Size(101, 20)
        Me.txtNumIcu.TabIndex = 128
        Me.txtNumIcu.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(30, 77)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(25, 13)
        Me.Label5.TabIndex = 126
        Me.Label5.Text = "ICU"
        Me.Label5.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(24, 100)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 13)
        Me.Label4.TabIndex = 129
        Me.Label4.Text = "SERV"
        Me.Label4.Visible = False
        '
        'txtNHC
        '
        Me.txtNHC.Location = New System.Drawing.Point(61, 49)
        Me.txtNHC.Name = "txtNHC"
        Me.txtNHC.Size = New System.Drawing.Size(101, 20)
        Me.txtNHC.TabIndex = 127
        Me.txtNHC.Visible = False
        '
        'txtServicio
        '
        Me.txtServicio.Location = New System.Drawing.Point(61, 96)
        Me.txtServicio.Name = "txtServicio"
        Me.txtServicio.Size = New System.Drawing.Size(101, 20)
        Me.txtServicio.TabIndex = 130
        Me.txtServicio.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(25, 54)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(30, 13)
        Me.Label6.TabIndex = 131
        Me.Label6.Text = "NHC"
        Me.Label6.Visible = False
        '
        'pnl_Documento
        '
        Me.pnl_Documento.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnl_Documento.Controls.Add(Me.txtHasta)
        Me.pnl_Documento.Controls.Add(Me.Label8)
        Me.pnl_Documento.Controls.Add(Me.txtDesde)
        Me.pnl_Documento.Controls.Add(Me.Label7)
        Me.pnl_Documento.Controls.Add(Me.cmdPrevisualizacion)
        Me.pnl_Documento.Controls.Add(Me.Label3)
        Me.pnl_Documento.Controls.Add(Me.Label2)
        Me.pnl_Documento.Controls.Add(Me.Label1)
        Me.pnl_Documento.Controls.Add(Me.txtApellido2)
        Me.pnl_Documento.Controls.Add(Me.txtApellido)
        Me.pnl_Documento.Controls.Add(Me.txtNombre)
        Me.pnl_Documento.Controls.Add(Me.Label6)
        Me.pnl_Documento.Controls.Add(Me.txtServicio)
        Me.pnl_Documento.Controls.Add(Me.txtNHC)
        Me.pnl_Documento.Controls.Add(Me.Label4)
        Me.pnl_Documento.Controls.Add(Me.Label5)
        Me.pnl_Documento.Controls.Add(Me.txtNumIcu)
        Me.pnl_Documento.Controls.Add(Me.btnInsertarDocumento)
        Me.pnl_Documento.Controls.Add(Me.cmdCArgarImagen)
        Me.pnl_Documento.Controls.Add(Me.txtRutaImagen)
        Me.pnl_Documento.Location = New System.Drawing.Point(10, 483)
        Me.pnl_Documento.Name = "pnl_Documento"
        Me.pnl_Documento.Size = New System.Drawing.Size(552, 154)
        Me.pnl_Documento.TabIndex = 118
        Me.pnl_Documento.TabStop = False
        Me.pnl_Documento.Text = "Información de Documento"
        '
        'txtHasta
        '
        Me.txtHasta.Location = New System.Drawing.Point(168, 123)
        Me.txtHasta.Name = "txtHasta"
        Me.txtHasta.Size = New System.Drawing.Size(63, 20)
        Me.txtHasta.TabIndex = 138
        Me.txtHasta.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(129, 125)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(33, 13)
        Me.Label8.TabIndex = 145
        Me.Label8.Text = "hasta"
        Me.Label8.Visible = False
        '
        'txtDesde
        '
        Me.txtDesde.Location = New System.Drawing.Point(61, 123)
        Me.txtDesde.Name = "txtDesde"
        Me.txtDesde.Size = New System.Drawing.Size(62, 20)
        Me.txtDesde.TabIndex = 137
        Me.txtDesde.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(26, 125)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(36, 13)
        Me.Label7.TabIndex = 144
        Me.Label7.Text = "desde"
        Me.Label7.Visible = False
        '
        'cmdPrevisualizacion
        '
        Me.cmdPrevisualizacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrevisualizacion.Location = New System.Drawing.Point(332, 115)
        Me.cmdPrevisualizacion.Name = "cmdPrevisualizacion"
        Me.cmdPrevisualizacion.Size = New System.Drawing.Size(103, 31)
        Me.cmdPrevisualizacion.TabIndex = 143
        Me.cmdPrevisualizacion.Text = "Previsualizacion"
        Me.cmdPrevisualizacion.UseVisualStyleBackColor = True
        Me.cmdPrevisualizacion.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(178, 85)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 142
        Me.Label3.Text = "Apellido 2"
        Me.Label3.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(179, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 141
        Me.Label2.Text = "Apellido 1"
        Me.Label2.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(180, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 140
        Me.Label1.Text = "Nombre"
        Me.Label1.Visible = False
        '
        'txtApellido2
        '
        Me.txtApellido2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtApellido2.Location = New System.Drawing.Point(235, 82)
        Me.txtApellido2.Name = "txtApellido2"
        Me.txtApellido2.Size = New System.Drawing.Size(301, 20)
        Me.txtApellido2.TabIndex = 139
        Me.txtApellido2.Visible = False
        '
        'txtApellido
        '
        Me.txtApellido.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtApellido.Location = New System.Drawing.Point(235, 55)
        Me.txtApellido.Name = "txtApellido"
        Me.txtApellido.Size = New System.Drawing.Size(301, 20)
        Me.txtApellido.TabIndex = 138
        Me.txtApellido.Visible = False
        '
        'txtNombre
        '
        Me.txtNombre.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNombre.Location = New System.Drawing.Point(235, 27)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(301, 20)
        Me.txtNombre.TabIndex = 137
        Me.txtNombre.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.rdbInsertarCartula)
        Me.GroupBox1.Controls.Add(Me.rdbInsertarDocumento)
        Me.GroupBox1.Location = New System.Drawing.Point(421, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(146, 72)
        Me.GroupBox1.TabIndex = 135
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tipo de inserción"
        '
        'rdbInsertarCartula
        '
        Me.rdbInsertarCartula.AutoSize = True
        Me.rdbInsertarCartula.Location = New System.Drawing.Point(9, 44)
        Me.rdbInsertarCartula.Name = "rdbInsertarCartula"
        Me.rdbInsertarCartula.Size = New System.Drawing.Size(101, 17)
        Me.rdbInsertarCartula.TabIndex = 1
        Me.rdbInsertarCartula.Text = "Insertar caratula"
        Me.rdbInsertarCartula.UseVisualStyleBackColor = True
        Me.rdbInsertarCartula.Visible = False
        '
        'rdbInsertarDocumento
        '
        Me.rdbInsertarDocumento.AutoSize = True
        Me.rdbInsertarDocumento.Checked = True
        Me.rdbInsertarDocumento.Location = New System.Drawing.Point(9, 21)
        Me.rdbInsertarDocumento.Name = "rdbInsertarDocumento"
        Me.rdbInsertarDocumento.Size = New System.Drawing.Size(116, 17)
        Me.rdbInsertarDocumento.TabIndex = 0
        Me.rdbInsertarDocumento.TabStop = True
        Me.rdbInsertarDocumento.Text = "Insertar documento"
        Me.rdbInsertarDocumento.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(428, 94)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(136, 17)
        Me.CheckBox1.TabIndex = 136
        Me.CheckBox1.Text = "Añadir al final de la lista"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'pgOperaciones
        '
        Me.pgOperaciones.Location = New System.Drawing.Point(10, 455)
        Me.pgOperaciones.Name = "pgOperaciones"
        Me.pgOperaciones.Size = New System.Drawing.Size(552, 19)
        Me.pgOperaciones.TabIndex = 137
        '
        'frmInsercionDocumento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(574, 649)
        Me.Controls.Add(Me.pgOperaciones)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.pnl_Documento)
        Me.Controls.Add(Me.PictureBox2)
        Me.Name = "frmInsercionDocumento"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Inserción de documento"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PictureBox2.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl_Documento.ResumeLayout(False)
        Me.pnl_Documento.PerformLayout()
        CType(Me.txtHasta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDesde, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As AxImgeditLibCtl.AxImgEdit
    Friend WithEvents txtRutaImagen As System.Windows.Forms.TextBox
    Friend WithEvents cmdCArgarImagen As System.Windows.Forms.Button
    Friend WithEvents btnInsertarDocumento As System.Windows.Forms.Button
    Friend WithEvents txtNumIcu As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtNHC As System.Windows.Forms.TextBox
    Friend WithEvents txtServicio As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents pnl_Documento As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rdbInsertarCartula As System.Windows.Forms.RadioButton
    Friend WithEvents rdbInsertarDocumento As System.Windows.Forms.RadioButton
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtApellido2 As System.Windows.Forms.TextBox
    Friend WithEvents txtApellido As System.Windows.Forms.TextBox
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents cmdPrevisualizacion As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtDesde As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtHasta As System.Windows.Forms.NumericUpDown
    Friend WithEvents pgOperaciones As System.Windows.Forms.ProgressBar
End Class
