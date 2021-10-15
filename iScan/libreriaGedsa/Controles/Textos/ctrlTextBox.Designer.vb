Namespace Controles
    Namespace Textos

        <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
        Partial Class ctrlTextBox
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
                Me.TextBox1 = New System.Windows.Forms.TextBox
                Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
                Me.SuspendLayout()
                '
                'TextBox1
                '
                Me.TextBox1.Cursor = System.Windows.Forms.Cursors.Arrow
                Me.TextBox1.Dock = System.Windows.Forms.DockStyle.Fill
                Me.TextBox1.Location = New System.Drawing.Point(0, 0)
                Me.TextBox1.Name = "TextBox1"
                Me.TextBox1.Size = New System.Drawing.Size(150, 20)
                Me.TextBox1.TabIndex = 0
                Me.TextBox1.TabStop = False
                '
                'ctrlTextBox
                '
                Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
                Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
                Me.BackColor = System.Drawing.Color.Transparent
                Me.Controls.Add(Me.TextBox1)
                Me.Name = "ctrlTextBox"
                Me.Size = New System.Drawing.Size(150, 20)
                Me.ResumeLayout(False)
                Me.PerformLayout()

            End Sub
            Protected WithEvents TextBox1 As System.Windows.Forms.TextBox
            Protected WithEvents ToolTip1 As System.Windows.Forms.ToolTip

        End Class
    End Namespace
End Namespace
