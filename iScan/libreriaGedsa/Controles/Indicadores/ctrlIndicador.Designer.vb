Namespace Controles

    Namespace Indicadores

        <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
        Partial Class ctrlIndicador
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
                Me.ImagenIndicador = New System.Windows.Forms.PictureBox
                CType(Me.ImagenIndicador, System.ComponentModel.ISupportInitialize).BeginInit()
                Me.SuspendLayout()
                '
                'ImagenIndicador
                '
                Me.ImagenIndicador.BackColor = System.Drawing.Color.Transparent
                Me.ImagenIndicador.Image = My.Resources.Resources.bullet_red
                Me.ImagenIndicador.Location = New System.Drawing.Point(0, 0)
                Me.ImagenIndicador.Name = "ImagenIndicador"
                Me.ImagenIndicador.Size = New System.Drawing.Size(10, 10)
                Me.ImagenIndicador.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
                Me.ImagenIndicador.TabIndex = 94
                Me.ImagenIndicador.TabStop = False
                '
                'ctrlIndicador
                '
                Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
                Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
                Me.BackColor = System.Drawing.Color.Transparent
                Me.Controls.Add(Me.ImagenIndicador)
                Me.Name = "ctrlIndicador"
                Me.Size = New System.Drawing.Size(10, 10)
                CType(Me.ImagenIndicador, System.ComponentModel.ISupportInitialize).EndInit()
                Me.ResumeLayout(False)

            End Sub
            Protected WithEvents ImagenIndicador As System.Windows.Forms.PictureBox

        End Class

    End Namespace

End Namespace