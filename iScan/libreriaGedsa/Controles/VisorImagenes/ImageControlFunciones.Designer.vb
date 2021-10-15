<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImageControlFunciones
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        Me.pnlBotonera = New System.Windows.Forms.Panel
        Me.btnDecrementarContraste = New System.Windows.Forms.Button
        Me.btnAumentarContraste = New System.Windows.Forms.Button
        Me.btnDecrementarBrillo = New System.Windows.Forms.Button
        Me.btnAumentarBrillo = New System.Windows.Forms.Button
        Me.btnRotarDerecha = New System.Windows.Forms.Button
        Me.btnRotarIzquierda = New System.Windows.Forms.Button
        Me.ImageControl1 = New libreriacadenaproduccion.Controles.VisorImagenes.ImageControl
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.pnlBotonera.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlBotonera
        '
        Me.pnlBotonera.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.pnlBotonera.Controls.Add(Me.btnDecrementarContraste)
        Me.pnlBotonera.Controls.Add(Me.btnAumentarContraste)
        Me.pnlBotonera.Controls.Add(Me.btnDecrementarBrillo)
        Me.pnlBotonera.Controls.Add(Me.btnAumentarBrillo)
        Me.pnlBotonera.Controls.Add(Me.btnRotarDerecha)
        Me.pnlBotonera.Controls.Add(Me.btnRotarIzquierda)
        Me.pnlBotonera.Location = New System.Drawing.Point(0, 3)
        Me.pnlBotonera.Name = "pnlBotonera"
        Me.pnlBotonera.Size = New System.Drawing.Size(443, 29)
        Me.pnlBotonera.TabIndex = 1
        '
        'btnDecrementarContraste
        '
        Me.btnDecrementarContraste.Location = New System.Drawing.Point(275, 0)
        Me.btnDecrementarContraste.Name = "btnDecrementarContraste"
        Me.btnDecrementarContraste.Size = New System.Drawing.Size(49, 25)
        Me.btnDecrementarContraste.TabIndex = 8
        Me.btnDecrementarContraste.Text = "Cd"
        Me.btnDecrementarContraste.UseVisualStyleBackColor = True
        '
        'btnAumentarContraste
        '
        Me.btnAumentarContraste.Location = New System.Drawing.Point(220, 0)
        Me.btnAumentarContraste.Name = "btnAumentarContraste"
        Me.btnAumentarContraste.Size = New System.Drawing.Size(49, 25)
        Me.btnAumentarContraste.TabIndex = 7
        Me.btnAumentarContraste.Text = "Ca"
        Me.btnAumentarContraste.UseVisualStyleBackColor = True
        '
        'btnDecrementarBrillo
        '
        Me.btnDecrementarBrillo.Location = New System.Drawing.Point(165, 0)
        Me.btnDecrementarBrillo.Name = "btnDecrementarBrillo"
        Me.btnDecrementarBrillo.Size = New System.Drawing.Size(49, 25)
        Me.btnDecrementarBrillo.TabIndex = 6
        Me.btnDecrementarBrillo.Text = "Bd"
        Me.btnDecrementarBrillo.UseVisualStyleBackColor = True
        '
        'btnAumentarBrillo
        '
        Me.btnAumentarBrillo.Location = New System.Drawing.Point(110, 0)
        Me.btnAumentarBrillo.Name = "btnAumentarBrillo"
        Me.btnAumentarBrillo.Size = New System.Drawing.Size(49, 25)
        Me.btnAumentarBrillo.TabIndex = 5
        Me.btnAumentarBrillo.Text = "Ba"
        Me.btnAumentarBrillo.UseVisualStyleBackColor = True
        '
        'btnRotarDerecha
        '
        Me.btnRotarDerecha.Location = New System.Drawing.Point(55, 0)
        Me.btnRotarDerecha.Name = "btnRotarDerecha"
        Me.btnRotarDerecha.Size = New System.Drawing.Size(49, 25)
        Me.btnRotarDerecha.TabIndex = 4
        Me.btnRotarDerecha.Text = "Rde"
        Me.btnRotarDerecha.UseVisualStyleBackColor = True
        '
        'btnRotarIzquierda
        '
        Me.btnRotarIzquierda.Location = New System.Drawing.Point(0, 0)
        Me.btnRotarIzquierda.Name = "btnRotarIzquierda"
        Me.btnRotarIzquierda.Size = New System.Drawing.Size(49, 25)
        Me.btnRotarIzquierda.TabIndex = 3
        Me.btnRotarIzquierda.Text = "RIz"
        Me.btnRotarIzquierda.UseVisualStyleBackColor = True
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
        Me.ImageControl1.ScrollbarsVisible = True
        Me.ImageControl1.Size = New System.Drawing.Size(443, 404)
        Me.ImageControl1.StretchImageToFit = False
        Me.ImageControl1.TabIndex = 3
        Me.ImageControl1.ZoomFactor = 1
        Me.ImageControl1.ZoomOnMouseWheel = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.pnlBotonera)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.ImageControl1)
        Me.SplitContainer1.Size = New System.Drawing.Size(443, 443)
        Me.SplitContainer1.SplitterDistance = 35
        Me.SplitContainer1.TabIndex = 4
        '
        'ImageControlFunciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "ImageControlFunciones"
        Me.Size = New System.Drawing.Size(443, 443)
        Me.pnlBotonera.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlBotonera As System.Windows.Forms.Panel
    Friend WithEvents btnDecrementarContraste As System.Windows.Forms.Button
    Friend WithEvents btnAumentarContraste As System.Windows.Forms.Button
    Friend WithEvents btnDecrementarBrillo As System.Windows.Forms.Button
    Friend WithEvents btnAumentarBrillo As System.Windows.Forms.Button
    Friend WithEvents btnRotarDerecha As System.Windows.Forms.Button
    Friend WithEvents btnRotarIzquierda As System.Windows.Forms.Button
    Friend WithEvents ImageControl1 As libreriacadenaproduccion.Controles.VisorImagenes.ImageControl
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer

End Class
