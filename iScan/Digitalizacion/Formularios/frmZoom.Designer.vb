<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmZoom
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
        Me.ImageControl1 = New libreriacadenaproduccion.Controles.VisorImagenes.ImageControl
        Me.SuspendLayout()
        '
        'ImageControl1
        '
        Me.ImageControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ImageControl1.Image = Nothing
        Me.ImageControl1.initialimage = Nothing
        Me.ImageControl1.Location = New System.Drawing.Point(0, 0)
        Me.ImageControl1.Name = "ImageControl1"
        Me.ImageControl1.Origin = New System.Drawing.Point(0, 0)
        Me.ImageControl1.PanButton = System.Windows.Forms.MouseButtons.Left
        Me.ImageControl1.PanMode = True
        Me.ImageControl1.PosicionScrollHorizontal = 0
        Me.ImageControl1.PosicionScrollVertical = 0
        Me.ImageControl1.ScrollbarsVisible = True
        Me.ImageControl1.Size = New System.Drawing.Size(927, 475)
        Me.ImageControl1.StretchImageToFit = False
        Me.ImageControl1.TabIndex = 0
        Me.ImageControl1.ZoomFactor = 1
        Me.ImageControl1.ZoomOnMouseWheel = True
        '
        'frmZoom
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(927, 475)
        Me.Controls.Add(Me.ImageControl1)
        Me.Name = "frmZoom"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Visor de Imagenes"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ImageControl1 As libreriacadenaproduccion.Controles.VisorImagenes.ImageControl
End Class
