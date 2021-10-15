<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmContenedorMDI
    Inherits System.Windows.Forms.Form

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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmContenedorMDI))
        Me.BarraInferior = New System.Windows.Forms.StatusStrip()
        Me.lblReloj = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblNombrePie = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblRol = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabelConexion = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CorreccionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CerrarSesiónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TimerFinLicencia = New System.Windows.Forms.Timer(Me.components)
        Me.BarraInferior.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BarraInferior
        '
        Me.BarraInferior.AutoSize = False
        Me.BarraInferior.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.BarraInferior.BackgroundImage = Global.Digitalización.My.Resources.Resources.barrainf
        Me.BarraInferior.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BarraInferior.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblReloj, Me.lblNombrePie, Me.lblRol, Me.ToolStripStatusLabelConexion})
        Me.BarraInferior.Location = New System.Drawing.Point(0, 557)
        Me.BarraInferior.Name = "BarraInferior"
        Me.BarraInferior.Size = New System.Drawing.Size(871, 23)
        Me.BarraInferior.TabIndex = 4
        Me.BarraInferior.Text = "StatusStrip1"
        '
        'lblReloj
        '
        Me.lblReloj.Name = "lblReloj"
        Me.lblReloj.Size = New System.Drawing.Size(0, 18)
        '
        'lblNombrePie
        '
        Me.lblNombrePie.Name = "lblNombrePie"
        Me.lblNombrePie.Size = New System.Drawing.Size(0, 18)
        '
        'lblRol
        '
        Me.lblRol.Name = "lblRol"
        Me.lblRol.Size = New System.Drawing.Size(0, 18)
        '
        'ToolStripStatusLabelConexion
        '
        Me.ToolStripStatusLabelConexion.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripStatusLabelConexion.Name = "ToolStripStatusLabelConexion"
        Me.ToolStripStatusLabelConexion.Size = New System.Drawing.Size(0, 18)
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivoToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(871, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ArchivoToolStripMenuItem
        '
        Me.ArchivoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CorreccionToolStripMenuItem, Me.ToolStripMenuItem1, Me.SalirToolStripMenuItem, Me.CerrarSesiónToolStripMenuItem})
        Me.ArchivoToolStripMenuItem.Name = "ArchivoToolStripMenuItem"
        Me.ArchivoToolStripMenuItem.Size = New System.Drawing.Size(60, 20)
        Me.ArchivoToolStripMenuItem.Text = "&Archivo"
        '
        'CorreccionToolStripMenuItem
        '
        Me.CorreccionToolStripMenuItem.Name = "CorreccionToolStripMenuItem"
        Me.CorreccionToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.CorreccionToolStripMenuItem.Text = "Correccion"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(177, 6)
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.SalirToolStripMenuItem.Text = "&Salir"
        '
        'CerrarSesiónToolStripMenuItem
        '
        Me.CerrarSesiónToolStripMenuItem.Name = "CerrarSesiónToolStripMenuItem"
        Me.CerrarSesiónToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.CerrarSesiónToolStripMenuItem.Text = "Seleccionar acción"
        '
        'TimerFinLicencia
        '
        Me.TimerFinLicencia.Interval = 60000
        '
        'frmContenedorMDI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(871, 580)
        Me.Controls.Add(Me.BarraInferior)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmContenedorMDI"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Indización"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BarraInferior.ResumeLayout(False)
        Me.BarraInferior.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ArchivoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents BarraInferior As System.Windows.Forms.StatusStrip
    Friend WithEvents lblReloj As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblNombrePie As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblRol As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabelConexion As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents CorreccionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CerrarSesiónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TimerFinLicencia As System.Windows.Forms.Timer
End Class
