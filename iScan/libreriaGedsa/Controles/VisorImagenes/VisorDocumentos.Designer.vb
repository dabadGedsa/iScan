Namespace Controles
    Namespace VisorImagenes

        <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
        Partial Class VisorDocumentos
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
                Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VisorDocumentos))
                Me.ToolStripImagen = New System.Windows.Forms.ToolStrip
                Me.tstAmpliarSeleccion = New System.Windows.Forms.ToolStripButton
                Me.tstAmpliarImagen = New System.Windows.Forms.ToolStripButton
                Me.tstReducirImagen = New System.Windows.Forms.ToolStripButton
                Me.tstAjustarImagen = New System.Windows.Forms.ToolStripButton
                Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
                Me.ToolStripButtonRotarImagen = New System.Windows.Forms.ToolStripButton
                Me.tstHerramientaMano = New System.Windows.Forms.ToolStripButton
                Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
                Me.lblNavegacionImagenes = New System.Windows.Forms.Label
                Me.BotonAtrasTodo = New libreriacadenaproduccion.Controles.Botones.ctrlBotonPequenyo
                Me.BotonAtras = New libreriacadenaproduccion.Controles.Botones.ctrlBotonPequenyo
                Me.BotonAdelante = New libreriacadenaproduccion.Controles.Botones.ctrlBotonPequenyo
                Me.BotonAdelanteTodo = New libreriacadenaproduccion.Controles.Botones.ctrlBotonPequenyo
                Me.ImageControl1 = New libreriacadenaproduccion.Controles.VisorImagenes.ImageControl
                Me.ToolStripImagen.SuspendLayout()
                Me.SuspendLayout()
                '
                'ToolStripImagen
                '
                Me.ToolStripImagen.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
                Me.ToolStripImagen.AutoSize = False
                Me.ToolStripImagen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
                Me.ToolStripImagen.Dock = System.Windows.Forms.DockStyle.None
                Me.ToolStripImagen.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstAmpliarSeleccion, Me.tstAmpliarImagen, Me.tstReducirImagen, Me.tstAjustarImagen, Me.ToolStripSeparator1, Me.ToolStripButtonRotarImagen, Me.tstHerramientaMano, Me.ToolStripSeparator2})
                Me.ToolStripImagen.Location = New System.Drawing.Point(0, 0)
                Me.ToolStripImagen.Name = "ToolStripImagen"
                Me.ToolStripImagen.Size = New System.Drawing.Size(623, 29)
                Me.ToolStripImagen.TabIndex = 5
                Me.ToolStripImagen.Text = "ToolStrip1"
                '
                'tstAmpliarSeleccion
                '
                Me.tstAmpliarSeleccion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
                Me.tstAmpliarSeleccion.Image = CType(resources.GetObject("tstAmpliarSeleccion.Image"), System.Drawing.Image)
                Me.tstAmpliarSeleccion.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
                Me.tstAmpliarSeleccion.ImageTransparentColor = System.Drawing.Color.Magenta
                Me.tstAmpliarSeleccion.Name = "tstAmpliarSeleccion"
                Me.tstAmpliarSeleccion.Size = New System.Drawing.Size(28, 26)
                Me.tstAmpliarSeleccion.Text = "Ampliar Selección"
                '
                'tstAmpliarImagen
                '
                Me.tstAmpliarImagen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
                Me.tstAmpliarImagen.Image = CType(resources.GetObject("tstAmpliarImagen.Image"), System.Drawing.Image)
                Me.tstAmpliarImagen.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
                Me.tstAmpliarImagen.ImageTransparentColor = System.Drawing.Color.Magenta
                Me.tstAmpliarImagen.Name = "tstAmpliarImagen"
                Me.tstAmpliarImagen.Size = New System.Drawing.Size(28, 26)
                Me.tstAmpliarImagen.Text = "Ampliar Imagen"
                '
                'tstReducirImagen
                '
                Me.tstReducirImagen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
                Me.tstReducirImagen.Image = CType(resources.GetObject("tstReducirImagen.Image"), System.Drawing.Image)
                Me.tstReducirImagen.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
                Me.tstReducirImagen.ImageTransparentColor = System.Drawing.Color.Magenta
                Me.tstReducirImagen.Name = "tstReducirImagen"
                Me.tstReducirImagen.Size = New System.Drawing.Size(28, 26)
                Me.tstReducirImagen.Text = "Reducir Imagen"
                '
                'tstAjustarImagen
                '
                Me.tstAjustarImagen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
                Me.tstAjustarImagen.Image = CType(resources.GetObject("tstAjustarImagen.Image"), System.Drawing.Image)
                Me.tstAjustarImagen.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
                Me.tstAjustarImagen.ImageTransparentColor = System.Drawing.Color.Magenta
                Me.tstAjustarImagen.Name = "tstAjustarImagen"
                Me.tstAjustarImagen.Size = New System.Drawing.Size(28, 26)
                Me.tstAjustarImagen.Text = "Ajustar Imagen "
                '
                'ToolStripSeparator1
                '
                Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
                Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
                '
                'ToolStripButtonRotarImagen
                '
                Me.ToolStripButtonRotarImagen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
                Me.ToolStripButtonRotarImagen.Image = CType(resources.GetObject("ToolStripButtonRotarImagen.Image"), System.Drawing.Image)
                Me.ToolStripButtonRotarImagen.ImageTransparentColor = System.Drawing.Color.Magenta
                Me.ToolStripButtonRotarImagen.Name = "ToolStripButtonRotarImagen"
                Me.ToolStripButtonRotarImagen.Size = New System.Drawing.Size(23, 26)
                Me.ToolStripButtonRotarImagen.Text = "Rotar Imagen"
                '
                'tstHerramientaMano
                '
                Me.tstHerramientaMano.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
                Me.tstHerramientaMano.Image = CType(resources.GetObject("tstHerramientaMano.Image"), System.Drawing.Image)
                Me.tstHerramientaMano.ImageTransparentColor = System.Drawing.Color.Magenta
                Me.tstHerramientaMano.Name = "tstHerramientaMano"
                Me.tstHerramientaMano.Size = New System.Drawing.Size(23, 26)
                Me.tstHerramientaMano.Text = "Mover"
                '
                'ToolStripSeparator2
                '
                Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
                Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
                '
                'lblNavegacionImagenes
                '
                Me.lblNavegacionImagenes.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
                Me.lblNavegacionImagenes.AutoSize = True
                Me.lblNavegacionImagenes.Location = New System.Drawing.Point(13, 741)
                Me.lblNavegacionImagenes.Name = "lblNavegacionImagenes"
                Me.lblNavegacionImagenes.Size = New System.Drawing.Size(75, 13)
                Me.lblNavegacionImagenes.TabIndex = 20
                Me.lblNavegacionImagenes.Text = "Imagen 0 de 0"
                '
                'BotonAtrasTodo
                '
                Me.BotonAtrasTodo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
                Me.BotonAtrasTodo.BackColor = System.Drawing.Color.Transparent
                Me.BotonAtrasTodo.EnabledBoton = True
                Me.BotonAtrasTodo.Location = New System.Drawing.Point(13, 716)
                Me.BotonAtrasTodo.Name = "BotonAtrasTodo"
                Me.BotonAtrasTodo.pImagenMouseEnter = CType(resources.GetObject("BotonAtrasTodo.pImagenMouseEnter"), System.Drawing.Image)
                Me.BotonAtrasTodo.pImagenMouseLeave = CType(resources.GetObject("BotonAtrasTodo.pImagenMouseLeave"), System.Drawing.Image)
                Me.BotonAtrasTodo.pImagenMouseOver = CType(resources.GetObject("BotonAtrasTodo.pImagenMouseOver"), System.Drawing.Image)
                Me.BotonAtrasTodo.Size = New System.Drawing.Size(73, 22)
                Me.BotonAtrasTodo.TabIndex = 21
                Me.BotonAtrasTodo.TextoBoton = "<<"
                '
                'BotonAtras
                '
                Me.BotonAtras.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
                Me.BotonAtras.BackColor = System.Drawing.Color.Transparent
                Me.BotonAtras.EnabledBoton = True
                Me.BotonAtras.Location = New System.Drawing.Point(92, 716)
                Me.BotonAtras.Name = "BotonAtras"
                Me.BotonAtras.pImagenMouseEnter = CType(resources.GetObject("BotonAtras.pImagenMouseEnter"), System.Drawing.Image)
                Me.BotonAtras.pImagenMouseLeave = CType(resources.GetObject("BotonAtras.pImagenMouseLeave"), System.Drawing.Image)
                Me.BotonAtras.pImagenMouseOver = CType(resources.GetObject("BotonAtras.pImagenMouseOver"), System.Drawing.Image)
                Me.BotonAtras.Size = New System.Drawing.Size(73, 22)
                Me.BotonAtras.TabIndex = 22
                Me.BotonAtras.TextoBoton = "<"
                '
                'BotonAdelante
                '
                Me.BotonAdelante.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
                Me.BotonAdelante.BackColor = System.Drawing.Color.Transparent
                Me.BotonAdelante.EnabledBoton = True
                Me.BotonAdelante.Location = New System.Drawing.Point(171, 716)
                Me.BotonAdelante.Name = "BotonAdelante"
                Me.BotonAdelante.pImagenMouseEnter = CType(resources.GetObject("BotonAdelante.pImagenMouseEnter"), System.Drawing.Image)
                Me.BotonAdelante.pImagenMouseLeave = CType(resources.GetObject("BotonAdelante.pImagenMouseLeave"), System.Drawing.Image)
                Me.BotonAdelante.pImagenMouseOver = CType(resources.GetObject("BotonAdelante.pImagenMouseOver"), System.Drawing.Image)
                Me.BotonAdelante.Size = New System.Drawing.Size(73, 22)
                Me.BotonAdelante.TabIndex = 23
                Me.BotonAdelante.TextoBoton = ">"
                '
                'BotonAdelanteTodo
                '
                Me.BotonAdelanteTodo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
                Me.BotonAdelanteTodo.BackColor = System.Drawing.Color.Transparent
                Me.BotonAdelanteTodo.EnabledBoton = True
                Me.BotonAdelanteTodo.Location = New System.Drawing.Point(250, 716)
                Me.BotonAdelanteTodo.Name = "BotonAdelanteTodo"
                Me.BotonAdelanteTodo.pImagenMouseEnter = CType(resources.GetObject("BotonAdelanteTodo.pImagenMouseEnter"), System.Drawing.Image)
                Me.BotonAdelanteTodo.pImagenMouseLeave = CType(resources.GetObject("BotonAdelanteTodo.pImagenMouseLeave"), System.Drawing.Image)
                Me.BotonAdelanteTodo.pImagenMouseOver = CType(resources.GetObject("BotonAdelanteTodo.pImagenMouseOver"), System.Drawing.Image)
                Me.BotonAdelanteTodo.Size = New System.Drawing.Size(73, 22)
                Me.BotonAdelanteTodo.TabIndex = 24
                Me.BotonAdelanteTodo.TextoBoton = ">>"
                '
                'ImageControl1
                '
                Me.ImageControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                            Or System.Windows.Forms.AnchorStyles.Left) _
                            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
                Me.ImageControl1.Image = Nothing
                Me.ImageControl1.initialimage = Nothing
                Me.ImageControl1.Location = New System.Drawing.Point(0, 29)
                Me.ImageControl1.Name = "ImageControl1"
                Me.ImageControl1.Origin = New System.Drawing.Point(0, 0)
                Me.ImageControl1.PanButton = System.Windows.Forms.MouseButtons.Left
                Me.ImageControl1.PanMode = True
                Me.ImageControl1.PosicionScrollHorizontal = 0
                Me.ImageControl1.PosicionScrollVertical = 0
                Me.ImageControl1.ScrollbarsVisible = True
                Me.ImageControl1.Size = New System.Drawing.Size(623, 672)
                Me.ImageControl1.StretchImageToFit = False
                Me.ImageControl1.TabIndex = 25
                Me.ImageControl1.ZoomFactor = 1
                Me.ImageControl1.ZoomOnMouseWheel = True
                '
                'VisorDocumentos
                '
                Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
                Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
                Me.BackColor = System.Drawing.Color.Transparent
                Me.Controls.Add(Me.ImageControl1)
                Me.Controls.Add(Me.lblNavegacionImagenes)
                Me.Controls.Add(Me.BotonAtrasTodo)
                Me.Controls.Add(Me.BotonAtras)
                Me.Controls.Add(Me.BotonAdelante)
                Me.Controls.Add(Me.BotonAdelanteTodo)
                Me.Controls.Add(Me.ToolStripImagen)
                Me.Name = "VisorDocumentos"
                Me.Size = New System.Drawing.Size(623, 763)
                Me.ToolStripImagen.ResumeLayout(False)
                Me.ToolStripImagen.PerformLayout()
                Me.ResumeLayout(False)
                Me.PerformLayout()

            End Sub
            Friend WithEvents ToolStripImagen As System.Windows.Forms.ToolStrip
            Friend WithEvents tstAmpliarSeleccion As System.Windows.Forms.ToolStripButton
            Friend WithEvents tstAmpliarImagen As System.Windows.Forms.ToolStripButton
            Friend WithEvents tstReducirImagen As System.Windows.Forms.ToolStripButton
            Friend WithEvents tstAjustarImagen As System.Windows.Forms.ToolStripButton
            Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
            Friend WithEvents ToolStripButtonRotarImagen As System.Windows.Forms.ToolStripButton
            Friend WithEvents tstHerramientaMano As System.Windows.Forms.ToolStripButton
            Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
            Friend WithEvents lblNavegacionImagenes As System.Windows.Forms.Label
            Friend WithEvents BotonAtrasTodo As libreriacadenaproduccion.Controles.Botones.ctrlBotonPequenyo
            Friend WithEvents BotonAtras As libreriacadenaproduccion.Controles.Botones.ctrlBotonPequenyo
            Friend WithEvents BotonAdelante As libreriacadenaproduccion.Controles.Botones.ctrlBotonPequenyo
            Friend WithEvents BotonAdelanteTodo As libreriacadenaproduccion.Controles.Botones.ctrlBotonPequenyo
            Friend WithEvents ImageControl1 As libreriacadenaproduccion.Controles.VisorImagenes.ImageControl

        End Class

    End Namespace

End Namespace