Namespace Controles
    Namespace Formularios

        <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
        Partial Class FormMensajeBarraIndeterminada
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
                Me.GroupBox1 = New System.Windows.Forms.GroupBox
                Me.LabelMensaje = New System.Windows.Forms.Label
                Me.PictureBox = New System.Windows.Forms.PictureBox
                Me.GroupBox1.SuspendLayout()
                CType(Me.PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
                Me.SuspendLayout()
                '
                'GroupBox1
                '
                Me.GroupBox1.Controls.Add(Me.PictureBox)
                Me.GroupBox1.Controls.Add(Me.LabelMensaje)
                Me.GroupBox1.Location = New System.Drawing.Point(2, -4)
                Me.GroupBox1.Name = "GroupBox1"
                Me.GroupBox1.Size = New System.Drawing.Size(458, 155)
                Me.GroupBox1.TabIndex = 4
                Me.GroupBox1.TabStop = False
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
                'PictureBox
                '
                Me.PictureBox.Image = Global.libreriacadenaproduccion.My.Resources.Resources.progressbar4
                Me.PictureBox.Location = New System.Drawing.Point(124, 104)
                Me.PictureBox.Name = "PictureBox"
                Me.PictureBox.Size = New System.Drawing.Size(210, 21)
                Me.PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
                Me.PictureBox.TabIndex = 2
                Me.PictureBox.TabStop = False
                '
                'FormMensajeBarraIndeterminada
                '
                Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
                Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
                Me.ClientSize = New System.Drawing.Size(462, 153)
                Me.Controls.Add(Me.GroupBox1)
                Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
                Me.Name = "FormMensajeBarraIndeterminada"
                Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
                Me.Text = "FormMensajeBarraIndeterminada"
                Me.GroupBox1.ResumeLayout(False)
                Me.GroupBox1.PerformLayout()
                CType(Me.PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
                Me.ResumeLayout(False)

            End Sub
            Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
            Friend WithEvents LabelMensaje As System.Windows.Forms.Label
            Friend WithEvents PictureBox As System.Windows.Forms.PictureBox
        End Class

    End Namespace
End Namespace
