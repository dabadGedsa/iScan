<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCreacionDVD
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCreacionDVD))
        Me.dgvCompilacion = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.pizarra = New System.Windows.Forms.RichTextBox
        Me.pgbProgreso = New System.Windows.Forms.ProgressBar
        Me.cmdGenerarDVD = New System.Windows.Forms.Button
        Me.lblprogreso = New System.Windows.Forms.Label
        Me.fbdRtuaDVD = New System.Windows.Forms.FolderBrowserDialog
        Me.rtbficheroTXT = New System.Windows.Forms.RichTextBox
        Me.lblprogresolotes = New System.Windows.Forms.Label
        Me.pgbprogresolotes = New System.Windows.Forms.ProgressBar
        Me.cmbListado = New System.Windows.Forms.Button
        CType(Me.dgvCompilacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvCompilacion
        '
        Me.dgvCompilacion.AllowUserToAddRows = False
        Me.dgvCompilacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCompilacion.Location = New System.Drawing.Point(16, 19)
        Me.dgvCompilacion.Name = "dgvCompilacion"
        Me.dgvCompilacion.RowHeadersVisible = False
        Me.dgvCompilacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCompilacion.Size = New System.Drawing.Size(101, 588)
        Me.dgvCompilacion.TabIndex = 13
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgvCompilacion)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(149, 613)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "SELECCIONAR LOTES "
        '
        'pizarra
        '
        Me.pizarra.Location = New System.Drawing.Point(167, 22)
        Me.pizarra.Name = "pizarra"
        Me.pizarra.Size = New System.Drawing.Size(387, 237)
        Me.pizarra.TabIndex = 17
        Me.pizarra.Text = ""
        '
        'pgbProgreso
        '
        Me.pgbProgreso.Location = New System.Drawing.Point(572, 234)
        Me.pgbProgreso.Name = "pgbProgreso"
        Me.pgbProgreso.Size = New System.Drawing.Size(305, 25)
        Me.pgbProgreso.TabIndex = 18
        '
        'cmdGenerarDVD
        '
        Me.cmdGenerarDVD.Image = CType(resources.GetObject("cmdGenerarDVD.Image"), System.Drawing.Image)
        Me.cmdGenerarDVD.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdGenerarDVD.Location = New System.Drawing.Point(788, 41)
        Me.cmdGenerarDVD.Name = "cmdGenerarDVD"
        Me.cmdGenerarDVD.Size = New System.Drawing.Size(76, 78)
        Me.cmdGenerarDVD.TabIndex = 16
        Me.cmdGenerarDVD.Text = "GENERAR DVD"
        Me.cmdGenerarDVD.UseVisualStyleBackColor = True
        '
        'lblprogreso
        '
        Me.lblprogreso.AutoSize = True
        Me.lblprogreso.Location = New System.Drawing.Point(569, 205)
        Me.lblprogreso.Name = "lblprogreso"
        Me.lblprogreso.Size = New System.Drawing.Size(108, 13)
        Me.lblprogreso.TabIndex = 19
        Me.lblprogreso.Text = "Progreso compilación"
        '
        'rtbficheroTXT
        '
        Me.rtbficheroTXT.Location = New System.Drawing.Point(167, 265)
        Me.rtbficheroTXT.Name = "rtbficheroTXT"
        Me.rtbficheroTXT.ReadOnly = True
        Me.rtbficheroTXT.Size = New System.Drawing.Size(710, 354)
        Me.rtbficheroTXT.TabIndex = 20
        Me.rtbficheroTXT.Text = ""
        '
        'lblprogresolotes
        '
        Me.lblprogresolotes.AutoSize = True
        Me.lblprogresolotes.Location = New System.Drawing.Point(569, 138)
        Me.lblprogresolotes.Name = "lblprogresolotes"
        Me.lblprogresolotes.Size = New System.Drawing.Size(108, 13)
        Me.lblprogresolotes.TabIndex = 22
        Me.lblprogresolotes.Text = "Progreso compilación"
        '
        'pgbprogresolotes
        '
        Me.pgbprogresolotes.Location = New System.Drawing.Point(572, 167)
        Me.pgbprogresolotes.Name = "pgbprogresolotes"
        Me.pgbprogresolotes.Size = New System.Drawing.Size(305, 25)
        Me.pgbprogresolotes.TabIndex = 21
        '
        'cmbListado
        '
        Me.cmbListado.Image = CType(resources.GetObject("cmbListado.Image"), System.Drawing.Image)
        Me.cmbListado.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmbListado.Location = New System.Drawing.Point(689, 41)
        Me.cmbListado.Name = "cmbListado"
        Me.cmbListado.Size = New System.Drawing.Size(83, 78)
        Me.cmbListado.TabIndex = 23
        Me.cmbListado.Text = "CONSULTAR VOLUMENES"
        Me.cmbListado.UseVisualStyleBackColor = True
        '
        'frmCreacionDVD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(889, 637)
        Me.Controls.Add(Me.cmbListado)
        Me.Controls.Add(Me.lblprogresolotes)
        Me.Controls.Add(Me.pgbprogresolotes)
        Me.Controls.Add(Me.rtbficheroTXT)
        Me.Controls.Add(Me.lblprogreso)
        Me.Controls.Add(Me.pgbProgreso)
        Me.Controls.Add(Me.pizarra)
        Me.Controls.Add(Me.cmdGenerarDVD)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmCreacionDVD"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CREACION DVD"
        CType(Me.dgvCompilacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvCompilacion As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents pizarra As System.Windows.Forms.RichTextBox
    Friend WithEvents pgbProgreso As System.Windows.Forms.ProgressBar
    Friend WithEvents cmdGenerarDVD As System.Windows.Forms.Button
    Friend WithEvents lblprogreso As System.Windows.Forms.Label
    Friend WithEvents fbdRtuaDVD As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents rtbficheroTXT As System.Windows.Forms.RichTextBox
    Friend WithEvents lblprogresolotes As System.Windows.Forms.Label
    Friend WithEvents pgbprogresolotes As System.Windows.Forms.ProgressBar
    Friend WithEvents cmbListado As System.Windows.Forms.Button
End Class
