<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDigitalizacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDigitalizacion))
        Me.pbCerrarLote = New System.Windows.Forms.ProgressBar
        Me.CtrlBotonMediano2 = New LibreriaCadenaProduccion.Controles.Botones.CtrlBotonMediano
        Me.cmbCerrarLote = New LibreriaCadenaProduccion.Controles.Botones.CtrlBotonMediano
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pbCerrarLote
        '
        Me.pbCerrarLote.Location = New System.Drawing.Point(6, 19)
        Me.pbCerrarLote.Name = "pbCerrarLote"
        Me.pbCerrarLote.Size = New System.Drawing.Size(553, 31)
        Me.pbCerrarLote.TabIndex = 5
        '
        'CtrlBotonMediano2
        '
        Me.CtrlBotonMediano2.BackColor = System.Drawing.Color.Transparent
        Me.CtrlBotonMediano2.EnabledBoton = True
        Me.CtrlBotonMediano2.Location = New System.Drawing.Point(416, 56)
        Me.CtrlBotonMediano2.Name = "CtrlBotonMediano2"
        Me.CtrlBotonMediano2.pImagenMouseEnter = CType(resources.GetObject("CtrlBotonMediano2.pImagenMouseEnter"), System.Drawing.Image)
        Me.CtrlBotonMediano2.pImagenMouseLeave = CType(resources.GetObject("CtrlBotonMediano2.pImagenMouseLeave"), System.Drawing.Image)
        Me.CtrlBotonMediano2.pImagenMouseOver = CType(resources.GetObject("CtrlBotonMediano2.pImagenMouseOver"), System.Drawing.Image)
        Me.CtrlBotonMediano2.Size = New System.Drawing.Size(121, 35)
        Me.CtrlBotonMediano2.TabIndex = 3
        Me.CtrlBotonMediano2.TextoBoton = "Seleccionar Nuevo lote"
        '
        'cmbCerrarLote
        '
        Me.cmbCerrarLote.BackColor = System.Drawing.Color.Transparent
        Me.cmbCerrarLote.EnabledBoton = True
        Me.cmbCerrarLote.Location = New System.Drawing.Point(262, 56)
        Me.cmbCerrarLote.Name = "cmbCerrarLote"
        Me.cmbCerrarLote.pImagenMouseEnter = CType(resources.GetObject("cmbCerrarLote.pImagenMouseEnter"), System.Drawing.Image)
        Me.cmbCerrarLote.pImagenMouseLeave = CType(resources.GetObject("cmbCerrarLote.pImagenMouseLeave"), System.Drawing.Image)
        Me.cmbCerrarLote.pImagenMouseOver = CType(resources.GetObject("cmbCerrarLote.pImagenMouseOver"), System.Drawing.Image)
        Me.cmbCerrarLote.Size = New System.Drawing.Size(121, 35)
        Me.cmbCerrarLote.TabIndex = 2
        Me.cmbCerrarLote.TextoBoton = "Cerrar Lote"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.pbCerrarLote)
        Me.GroupBox1.Controls.Add(Me.CtrlBotonMediano2)
        Me.GroupBox1.Controls.Add(Me.cmbCerrarLote)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 22)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(565, 102)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        '
        'BackgroundWorker1
        '
        '
        'frmDigitalizacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 661)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmDigitalizacion"
        Me.Text = "frmDigitalizacion"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmbCerrarLote As LibreriaCadenaProduccion.Controles.Botones.CtrlBotonMediano
    Friend WithEvents CtrlBotonMediano2 As LibreriaCadenaProduccion.Controles.Botones.CtrlBotonMediano
    Friend WithEvents pbCerrarLote As System.Windows.Forms.ProgressBar
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
End Class
