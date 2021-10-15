Namespace Controles
    Namespace Labels

        <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
        Partial Class ctrlLabelIntermitente
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
                Me.components = New System.ComponentModel.Container
                Me.reloj = New System.Windows.Forms.Timer(Me.components)
                Me.SuspendLayout()
                '
                'Label1
                '
                Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                Me.Label1.ForeColor = System.Drawing.Color.DarkRed
                Me.Label1.Size = New System.Drawing.Size(90, 20)
                Me.Label1.Text = "¡Atención!"
                '
                'reloj
                '
                '
                'ctrlLabelIntermitente
                '
                Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
                Me.Name = "ctrlLabelIntermitente"
                Me.Size = New System.Drawing.Size(96, 20)
                Me.textoLabel = "¡Atención!"
                Me.ResumeLayout(False)
                Me.PerformLayout()

            End Sub
            Protected WithEvents reloj As System.Windows.Forms.Timer

        End Class

    End Namespace
End Namespace