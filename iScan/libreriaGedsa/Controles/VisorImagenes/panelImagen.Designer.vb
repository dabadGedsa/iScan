<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class panelImagen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(panelImagen))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.btnRotacion = New System.Windows.Forms.ToolStripButton
        Me.btnZoom = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.btnBrillo = New System.Windows.Forms.ToolStripButton
        Me.btnContraste = New System.Windows.Forms.ToolStripButton
        Me.btnSuave = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.btnAceptar = New System.Windows.Forms.ToolStripButton
        Me.btnCancelar = New System.Windows.Forms.ToolStripButton
        Me.obj_imagen = New System.Windows.Forms.PictureBox
        Me.ToolStrip1.SuspendLayout()
        CType(Me.obj_imagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnRotacion, Me.btnZoom, Me.ToolStripSeparator1, Me.btnBrillo, Me.btnContraste, Me.btnSuave, Me.ToolStripSeparator2, Me.btnAceptar, Me.btnCancelar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(411, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnRotacion
        '
        Me.btnRotacion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnRotacion.Image = CType(resources.GetObject("btnRotacion.Image"), System.Drawing.Image)
        Me.btnRotacion.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRotacion.Name = "btnRotacion"
        Me.btnRotacion.Size = New System.Drawing.Size(23, 22)
        Me.btnRotacion.Text = "Rotar 90º"
        '
        'btnZoom
        '
        Me.btnZoom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnZoom.Image = CType(resources.GetObject("btnZoom.Image"), System.Drawing.Image)
        Me.btnZoom.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnZoom.Name = "btnZoom"
        Me.btnZoom.Size = New System.Drawing.Size(23, 22)
        Me.btnZoom.Text = "Modo Zoom"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'btnBrillo
        '
        Me.btnBrillo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnBrillo.Image = CType(resources.GetObject("btnBrillo.Image"), System.Drawing.Image)
        Me.btnBrillo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnBrillo.Name = "btnBrillo"
        Me.btnBrillo.Size = New System.Drawing.Size(23, 22)
        Me.btnBrillo.Text = "Cambio de brillo de imagen"
        '
        'btnContraste
        '
        Me.btnContraste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnContraste.Image = CType(resources.GetObject("btnContraste.Image"), System.Drawing.Image)
        Me.btnContraste.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnContraste.Name = "btnContraste"
        Me.btnContraste.Size = New System.Drawing.Size(23, 22)
        Me.btnContraste.Text = "Cambio de contraste"
        '
        'btnSuave
        '
        Me.btnSuave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSuave.Image = CType(resources.GetObject("btnSuave.Image"), System.Drawing.Image)
        Me.btnSuave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSuave.Name = "btnSuave"
        Me.btnSuave.Size = New System.Drawing.Size(23, 22)
        Me.btnSuave.Text = "Suavizado"
        Me.btnSuave.Visible = False
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'btnAceptar
        '
        Me.btnAceptar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Image)
        Me.btnAceptar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(23, 22)
        Me.btnAceptar.Text = "ToolStripButton1"
        '
        'btnCancelar
        '
        Me.btnCancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(23, 22)
        Me.btnCancelar.Text = "Cancelar"
        '
        'obj_imagen
        '
        Me.obj_imagen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.obj_imagen.Location = New System.Drawing.Point(0, 25)
        Me.obj_imagen.Name = "obj_imagen"
        Me.obj_imagen.Size = New System.Drawing.Size(411, 337)
        Me.obj_imagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.obj_imagen.TabIndex = 1
        Me.obj_imagen.TabStop = False
        '
        'panelImagen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.obj_imagen)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "panelImagen"
        Me.Size = New System.Drawing.Size(411, 362)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.obj_imagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnRotacion As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnBrillo As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnContraste As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnZoom As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSuave As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnCancelar As System.Windows.Forms.ToolStripButton
    Public WithEvents obj_imagen As System.Windows.Forms.PictureBox
    Friend WithEvents btnAceptar As System.Windows.Forms.ToolStripButton

End Class
