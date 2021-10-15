Namespace Controles
    Namespace Botones

        <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
        Partial Class ctrlBotonBase
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
                Me.Button1 = New System.Windows.Forms.Button
                Me.SuspendLayout()
                '
                'Button1
                '
                Me.Button1.BackColor = System.Drawing.Color.Transparent
                Me.Button1.BackgroundImage = My.Resources.Resources.cmdMouseLeave
                Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
                Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
                Me.Button1.Dock = System.Windows.Forms.DockStyle.Fill
                Me.Button1.FlatAppearance.BorderSize = 0
                Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
                Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
                Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
                Me.Button1.Location = New System.Drawing.Point(0, 0)
                Me.Button1.Name = "Button1"
                Me.Button1.Size = New System.Drawing.Size(111, 43)
                Me.Button1.TabIndex = 1
                Me.Button1.Text = "Button1"
                Me.Button1.UseVisualStyleBackColor = False
                '
                'ctrlBotonBase
                '
                Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
                Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
                Me.BackColor = System.Drawing.Color.Transparent
                Me.Controls.Add(Me.Button1)
                Me.Name = "ctrlBotonBase"
                Me.Size = New System.Drawing.Size(111, 43)
                Me.ResumeLayout(False)

            End Sub
            Protected WithEvents Button1 As System.Windows.Forms.Button

        End Class

    End Namespace
End Namespace