Namespace Controles
    Namespace Labels

        <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
        Partial Class ctrlTituloPanel
            Inherits libreriacadenaproduccion.Controles.Labels.ctrlLabelBase

            'Form reemplaza a Dispose para limpiar la lista de componentes.
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
                Me.SuspendLayout()
                '
                'Label1
                '
                Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                Me.Label1.ForeColor = System.Drawing.Color.White
                Me.Label1.Location = New System.Drawing.Point(14, 9)
                Me.Label1.Size = New System.Drawing.Size(119, 20)
                Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
                '
                'ctrlTituloPanel
                '
                Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
                Me.BackgroundImage = My.Resources.Resources.tituloPaneles
                Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
                Me.DoubleBuffered = True
                Me.Name = "ctrlTituloPanel"
                Me.Padding = New System.Windows.Forms.Padding(10, 0, 10, 10)
                Me.Size = New System.Drawing.Size(146, 39)
                Me.ResumeLayout(False)
                Me.PerformLayout()

            End Sub

        End Class
    End Namespace
End Namespace