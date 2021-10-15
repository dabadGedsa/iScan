<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmModificarRango
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
        Me.pnl_registro = New System.Windows.Forms.GroupBox
        Me.txtHasta = New System.Windows.Forms.NumericUpDown
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtDesde = New System.Windows.Forms.NumericUpDown
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtNHC = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.CtrlBotonPequenyo1 = New LibreriaCadenaProduccion.Controles.Botones.ctrlBotonPequenyo
        Me.pnl_registro.SuspendLayout()
        CType(Me.txtHasta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDesde, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnl_registro
        '
        Me.pnl_registro.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnl_registro.Controls.Add(Me.txtHasta)
        Me.pnl_registro.Controls.Add(Me.Label8)
        Me.pnl_registro.Controls.Add(Me.txtDesde)
        Me.pnl_registro.Controls.Add(Me.Label7)
        Me.pnl_registro.Controls.Add(Me.txtNHC)
        Me.pnl_registro.Controls.Add(Me.Label1)
        Me.pnl_registro.Location = New System.Drawing.Point(11, 12)
        Me.pnl_registro.Name = "pnl_registro"
        Me.pnl_registro.Size = New System.Drawing.Size(371, 44)
        Me.pnl_registro.TabIndex = 103
        Me.pnl_registro.TabStop = False
        '
        'txtHasta
        '
        Me.txtHasta.Location = New System.Drawing.Point(290, 14)
        Me.txtHasta.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.txtHasta.Name = "txtHasta"
        Me.txtHasta.Size = New System.Drawing.Size(63, 20)
        Me.txtHasta.TabIndex = 147
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(251, 17)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(33, 13)
        Me.Label8.TabIndex = 149
        Me.Label8.Text = "hasta"
        '
        'txtDesde
        '
        Me.txtDesde.Location = New System.Drawing.Point(183, 14)
        Me.txtDesde.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.txtDesde.Name = "txtDesde"
        Me.txtDesde.Size = New System.Drawing.Size(62, 20)
        Me.txtDesde.TabIndex = 146
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(139, 17)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 13)
        Me.Label7.TabIndex = 148
        Me.Label7.Text = "Desde"
        '
        'txtNHC
        '
        Me.txtNHC.Location = New System.Drawing.Point(48, 14)
        Me.txtNHC.Name = "txtNHC"
        Me.txtNHC.Size = New System.Drawing.Size(75, 20)
        Me.txtNHC.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 50
        Me.Label1.Text = "NHC"
        '
        'CtrlBotonPequenyo1
        '
        Me.CtrlBotonPequenyo1.BackColor = System.Drawing.Color.Transparent
        Me.CtrlBotonPequenyo1.EnabledBoton = True
        Me.CtrlBotonPequenyo1.Location = New System.Drawing.Point(269, 73)
        Me.CtrlBotonPequenyo1.Name = "CtrlBotonPequenyo1"
        Me.CtrlBotonPequenyo1.pImagenMouseEnter = Nothing
        Me.CtrlBotonPequenyo1.pImagenMouseLeave = Nothing
        Me.CtrlBotonPequenyo1.pImagenMouseOver = Nothing
        Me.CtrlBotonPequenyo1.Size = New System.Drawing.Size(113, 33)
        Me.CtrlBotonPequenyo1.TabIndex = 8
        Me.CtrlBotonPequenyo1.TextoBoton = "Modificar"
        '
        'frmModificarRango
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(394, 118)
        Me.Controls.Add(Me.CtrlBotonPequenyo1)
        Me.Controls.Add(Me.pnl_registro)
        Me.Name = "frmModificarRango"
        Me.Text = "Modificar rango de páginas"
        Me.pnl_registro.ResumeLayout(False)
        Me.pnl_registro.PerformLayout()
        CType(Me.txtHasta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDesde, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnl_registro As System.Windows.Forms.GroupBox
    Friend WithEvents txtNHC As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CtrlBotonPequenyo1 As LibreriaCadenaProduccion.Controles.Botones.ctrlBotonPequenyo
    Friend WithEvents txtHasta As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtDesde As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
