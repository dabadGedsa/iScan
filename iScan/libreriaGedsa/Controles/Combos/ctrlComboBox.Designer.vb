Namespace Controles
    Namespace Combos

        <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
        Partial Class CtrlComboBox
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
                Me.ComboBox1 = New System.Windows.Forms.ComboBox
                Me.SuspendLayout()
                '
                'ComboBox1
                '
                Me.ComboBox1.Dock = System.Windows.Forms.DockStyle.Fill
                Me.ComboBox1.FormattingEnabled = True
                Me.ComboBox1.Location = New System.Drawing.Point(0, 0)
                Me.ComboBox1.Name = "ComboBox1"
                Me.ComboBox1.Size = New System.Drawing.Size(150, 21)
                Me.ComboBox1.TabIndex = 0
                '
                'CtrlComboBox
                '
                Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
                Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
                Me.AutoSize = True
                Me.Controls.Add(Me.ComboBox1)
                Me.Name = "CtrlComboBox"
                Me.Size = New System.Drawing.Size(150, 21)
                Me.ResumeLayout(False)

            End Sub
            Protected WithEvents ComboBox1 As System.Windows.Forms.ComboBox

        End Class

    End Namespace
End Namespace
