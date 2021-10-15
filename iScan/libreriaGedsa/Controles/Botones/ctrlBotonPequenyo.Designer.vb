Namespace Controles
    Namespace Botones

        <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
        Partial Class ctrlBotonPequenyo
            Inherits libreriacadenaproduccion.Controles.Botones.ctrlBotonBase

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
                'Button1
                '
                Me.Button1.FlatAppearance.BorderSize = 0
                Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
                Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
                Me.Button1.Size = New System.Drawing.Size(70, 20)
                '
                'ctrlBotonPequenyo
                '
                Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
                Me.Name = "ctrlBotonPequenyo"
                Me.pImagenMouseEnter = My.Resources.Resources.cmdMouseEnter
                Me.pImagenMouseLeave = My.Resources.Resources.cmdMouseLeave
                Me.Size = New System.Drawing.Size(70, 20)
                Me.ResumeLayout(False)

            End Sub

        End Class



    End Namespace
End Namespace