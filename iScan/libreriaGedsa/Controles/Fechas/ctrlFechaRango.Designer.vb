Namespace Controles
    Namespace Fechas

        <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
        Partial Class CtrlFechaRango
            Inherits System.Windows.Forms.UserControl

            'UserControl reemplaza a Dispose para limpiar la lista de componentes.
            <System.Diagnostics.DebuggerNonUserCode()> _
            Protected Overrides Sub Dispose(ByVal disposing As Boolean)
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
                End If
                MyBase.Dispose(disposing)
            End Sub

            'Requerido por el Diseñador de Windows Forms
            Private components As System.ComponentModel.IContainer

            'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
            'Se puede modificar usando el Diseñador de Windows Forms.  
            'No lo modifique con el editor de código.
            <System.Diagnostics.DebuggerStepThrough()> _
            Private Sub InitializeComponent()
                Me.components = New System.ComponentModel.Container
                Me.GroupBox1 = New System.Windows.Forms.GroupBox
                Me.cmbTipo = New System.Windows.Forms.ComboBox
                Me.Label1 = New System.Windows.Forms.Label
                Me.pnlFecha2 = New System.Windows.Forms.Panel
                Me.chkFecha2 = New System.Windows.Forms.CheckBox
                Me.dtpFecha2 = New System.Windows.Forms.DateTimePicker
                Me.pnlFecha1 = New System.Windows.Forms.Panel
                Me.chkFecha1 = New System.Windows.Forms.CheckBox
                Me.dtpFecha1 = New System.Windows.Forms.DateTimePicker
                Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
                Me.GroupBox1.SuspendLayout()
                Me.SuspendLayout()
                '
                'GroupBox1
                '
                Me.GroupBox1.Controls.Add(Me.cmbTipo)
                Me.GroupBox1.Controls.Add(Me.Label1)
                Me.GroupBox1.Controls.Add(Me.pnlFecha2)
                Me.GroupBox1.Controls.Add(Me.chkFecha2)
                Me.GroupBox1.Controls.Add(Me.dtpFecha2)
                Me.GroupBox1.Controls.Add(Me.pnlFecha1)
                Me.GroupBox1.Controls.Add(Me.chkFecha1)
                Me.GroupBox1.Controls.Add(Me.dtpFecha1)
                Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
                Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
                Me.GroupBox1.Name = "GroupBox1"
                Me.GroupBox1.Size = New System.Drawing.Size(350, 49)
                Me.GroupBox1.TabIndex = 103
                Me.GroupBox1.TabStop = False
                Me.GroupBox1.Text = "GroupBox1"
                '
                'cmbTipo
                '
                Me.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
                Me.cmbTipo.Items.AddRange(New Object() {"Igual a", "Entre", "Anterior", "Posterior"})
                Me.cmbTipo.Location = New System.Drawing.Point(6, 19)
                Me.cmbTipo.Name = "cmbTipo"
                Me.cmbTipo.Size = New System.Drawing.Size(78, 21)
                Me.cmbTipo.TabIndex = 110
                '
                'Label1
                '
                Me.Label1.AutoSize = True
                Me.Label1.Location = New System.Drawing.Point(215, 23)
                Me.Label1.Name = "Label1"
                Me.Label1.Size = New System.Drawing.Size(12, 13)
                Me.Label1.TabIndex = 109
                Me.Label1.Text = "y"
                '
                'pnlFecha2
                '
                Me.pnlFecha2.BackColor = System.Drawing.Color.White
                Me.pnlFecha2.Location = New System.Drawing.Point(238, 24)
                Me.pnlFecha2.Name = "pnlFecha2"
                Me.pnlFecha2.Size = New System.Drawing.Size(61, 10)
                Me.pnlFecha2.TabIndex = 108
                '
                'chkFecha2
                '
                Me.chkFecha2.AutoSize = True
                Me.chkFecha2.Location = New System.Drawing.Point(327, 22)
                Me.chkFecha2.Name = "chkFecha2"
                Me.chkFecha2.Size = New System.Drawing.Size(15, 14)
                Me.chkFecha2.TabIndex = 107
                Me.chkFecha2.UseVisualStyleBackColor = True
                '
                'dtpFecha2
                '
                Me.dtpFecha2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
                Me.dtpFecha2.Location = New System.Drawing.Point(235, 19)
                Me.dtpFecha2.Name = "dtpFecha2"
                Me.dtpFecha2.Size = New System.Drawing.Size(86, 20)
                Me.dtpFecha2.TabIndex = 106
                '
                'pnlFecha1
                '
                Me.pnlFecha1.BackColor = System.Drawing.Color.White
                Me.pnlFecha1.Location = New System.Drawing.Point(103, 24)
                Me.pnlFecha1.Name = "pnlFecha1"
                Me.pnlFecha1.Size = New System.Drawing.Size(61, 10)
                Me.pnlFecha1.TabIndex = 105
                '
                'chkFecha1
                '
                Me.chkFecha1.AutoSize = True
                Me.chkFecha1.Location = New System.Drawing.Point(192, 22)
                Me.chkFecha1.Name = "chkFecha1"
                Me.chkFecha1.Size = New System.Drawing.Size(15, 14)
                Me.chkFecha1.TabIndex = 104
                Me.chkFecha1.UseVisualStyleBackColor = True
                '
                'dtpFecha1
                '
                Me.dtpFecha1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
                Me.dtpFecha1.Location = New System.Drawing.Point(100, 19)
                Me.dtpFecha1.Name = "dtpFecha1"
                Me.dtpFecha1.Size = New System.Drawing.Size(86, 20)
                Me.dtpFecha1.TabIndex = 103
                '
                'CtrlFechaRango
                '
                Me.AllowDrop = True
                Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
                Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
                Me.BackColor = System.Drawing.Color.Transparent
                Me.Controls.Add(Me.GroupBox1)
                Me.Name = "CtrlFechaRango"
                Me.Size = New System.Drawing.Size(350, 49)
                Me.GroupBox1.ResumeLayout(False)
                Me.GroupBox1.PerformLayout()
                Me.ResumeLayout(False)

            End Sub
            Protected WithEvents GroupBox1 As System.Windows.Forms.GroupBox
            Protected WithEvents cmbTipo As System.Windows.Forms.ComboBox
            Protected WithEvents Label1 As System.Windows.Forms.Label
            Protected WithEvents pnlFecha2 As System.Windows.Forms.Panel
            Protected WithEvents chkFecha2 As System.Windows.Forms.CheckBox
            Protected WithEvents dtpFecha2 As System.Windows.Forms.DateTimePicker
            Protected WithEvents pnlFecha1 As System.Windows.Forms.Panel
            Protected WithEvents chkFecha1 As System.Windows.Forms.CheckBox
            Protected WithEvents dtpFecha1 As System.Windows.Forms.DateTimePicker
            Protected WithEvents ToolTip1 As System.Windows.Forms.ToolTip

        End Class

    End Namespace
End Namespace