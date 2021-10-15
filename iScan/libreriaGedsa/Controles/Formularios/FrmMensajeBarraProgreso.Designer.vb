Namespace Controles
    Namespace Formularios

        <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
        Partial Class FrmMensajeBarraProgreso
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
                Me.progressBarAsignacion = New System.Windows.Forms.ProgressBar
                Me.LabelMensaje = New System.Windows.Forms.Label
                Me.LabelPorcentaje = New System.Windows.Forms.Label
                Me.GroupBox1 = New System.Windows.Forms.GroupBox
                Me.GroupBox1.SuspendLayout()
                Me.SuspendLayout()
                '
                'progressBarAsignacion
                '
                Me.progressBarAsignacion.Location = New System.Drawing.Point(32, 103)
                Me.progressBarAsignacion.Name = "progressBarAsignacion"
                Me.progressBarAsignacion.Size = New System.Drawing.Size(388, 23)
                Me.progressBarAsignacion.Step = 1
                Me.progressBarAsignacion.TabIndex = 0
                '
                'LabelMensaje
                '
                Me.LabelMensaje.AutoSize = True
                Me.LabelMensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                Me.LabelMensaje.Location = New System.Drawing.Point(29, 38)
                Me.LabelMensaje.Name = "LabelMensaje"
                Me.LabelMensaje.Size = New System.Drawing.Size(95, 26)
                Me.LabelMensaje.TabIndex = 1
                Me.LabelMensaje.Text = "mensaje"
                '
                'LabelPorcentaje
                '
                Me.LabelPorcentaje.AutoSize = True
                Me.LabelPorcentaje.Location = New System.Drawing.Point(31, 87)
                Me.LabelPorcentaje.Name = "LabelPorcentaje"
                Me.LabelPorcentaje.Size = New System.Drawing.Size(24, 13)
                Me.LabelPorcentaje.TabIndex = 2
                Me.LabelPorcentaje.Text = "0 %"
                '
                'GroupBox1
                '
                Me.GroupBox1.Controls.Add(Me.LabelPorcentaje)
                Me.GroupBox1.Controls.Add(Me.progressBarAsignacion)
                Me.GroupBox1.Controls.Add(Me.LabelMensaje)
                Me.GroupBox1.Location = New System.Drawing.Point(2, -4)
                Me.GroupBox1.Name = "GroupBox1"
                Me.GroupBox1.Size = New System.Drawing.Size(458, 155)
                Me.GroupBox1.TabIndex = 3
                Me.GroupBox1.TabStop = False
                '
                'FrmMensajeBarraProgreso
                '
                Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
                Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
                Me.ClientSize = New System.Drawing.Size(462, 153)
                Me.Controls.Add(Me.GroupBox1)
                Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
                Me.Name = "FrmMensajeBarraProgreso"
                Me.ShowIcon = False
                Me.ShowInTaskbar = False
                Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
                Me.Text = "FrmEsperaAsignacionEpisodios"
                Me.GroupBox1.ResumeLayout(False)
                Me.GroupBox1.PerformLayout()
                Me.ResumeLayout(False)

            End Sub
            Friend WithEvents progressBarAsignacion As System.Windows.Forms.ProgressBar
            Friend WithEvents LabelMensaje As System.Windows.Forms.Label
            Friend WithEvents LabelPorcentaje As System.Windows.Forms.Label
            Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        End Class

    End Namespace
End Namespace