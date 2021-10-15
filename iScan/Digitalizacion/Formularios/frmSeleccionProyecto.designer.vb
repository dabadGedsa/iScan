<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSeleccionProyecto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSeleccionProyecto))
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbProyecto = New System.Windows.Forms.ComboBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblSeleccionProyecto = New System.Windows.Forms.Label
        Me.cmbAccion = New System.Windows.Forms.ComboBox
        Me.lblLotesdisponibles = New System.Windows.Forms.Label
        Me.cmbSeleccionar = New LibreriaCadenaProduccion.Controles.Botones.CtrlBotonGrande
        Me.lblSeleccionLote = New System.Windows.Forms.Label
        Me.cmbLote = New System.Windows.Forms.ComboBox
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(143, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Seleccione acción a realizar:"
        '
        'cmbProyecto
        '
        Me.cmbProyecto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProyecto.FormattingEnabled = True
        Me.cmbProyecto.Location = New System.Drawing.Point(165, 74)
        Me.cmbProyecto.Name = "cmbProyecto"
        Me.cmbProyecto.Size = New System.Drawing.Size(300, 21)
        Me.cmbProyecto.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblSeleccionProyecto)
        Me.GroupBox1.Controls.Add(Me.cmbAccion)
        Me.GroupBox1.Controls.Add(Me.lblLotesdisponibles)
        Me.GroupBox1.Controls.Add(Me.cmbSeleccionar)
        Me.GroupBox1.Controls.Add(Me.lblSeleccionLote)
        Me.GroupBox1.Controls.Add(Me.cmbLote)
        Me.GroupBox1.Controls.Add(Me.cmbProyecto)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(489, 172)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Seleccion de proyecto"
        '
        'lblSeleccionProyecto
        '
        Me.lblSeleccionProyecto.AutoSize = True
        Me.lblSeleccionProyecto.Location = New System.Drawing.Point(17, 74)
        Me.lblSeleccionProyecto.Name = "lblSeleccionProyecto"
        Me.lblSeleccionProyecto.Size = New System.Drawing.Size(111, 13)
        Me.lblSeleccionProyecto.TabIndex = 9
        Me.lblSeleccionProyecto.Text = "Seleccionar Proyecto:"
        '
        'cmbAccion
        '
        Me.cmbAccion.FormattingEnabled = True
        Me.cmbAccion.Location = New System.Drawing.Point(165, 33)
        Me.cmbAccion.Name = "cmbAccion"
        Me.cmbAccion.Size = New System.Drawing.Size(188, 21)
        Me.cmbAccion.TabIndex = 8
        '
        'lblLotesdisponibles
        '
        Me.lblLotesdisponibles.AutoSize = True
        Me.lblLotesdisponibles.Location = New System.Drawing.Point(162, 145)
        Me.lblLotesdisponibles.Name = "lblLotesdisponibles"
        Me.lblLotesdisponibles.Size = New System.Drawing.Size(88, 13)
        Me.lblLotesdisponibles.TabIndex = 7
        Me.lblLotesdisponibles.Text = "Lotes disponibles"
        '
        'cmbSeleccionar
        '
        Me.cmbSeleccionar.BackColor = System.Drawing.Color.Transparent
        Me.cmbSeleccionar.EnabledBoton = True
        Me.cmbSeleccionar.Location = New System.Drawing.Point(381, 112)
        Me.cmbSeleccionar.Name = "cmbSeleccionar"
        Me.cmbSeleccionar.pImagenMouseEnter = CType(resources.GetObject("cmbSeleccionar.pImagenMouseEnter"), System.Drawing.Image)
        Me.cmbSeleccionar.pImagenMouseLeave = CType(resources.GetObject("cmbSeleccionar.pImagenMouseLeave"), System.Drawing.Image)
        Me.cmbSeleccionar.pImagenMouseOver = CType(resources.GetObject("cmbSeleccionar.pImagenMouseOver"), System.Drawing.Image)
        Me.cmbSeleccionar.Size = New System.Drawing.Size(84, 24)
        Me.cmbSeleccionar.TabIndex = 6
        Me.cmbSeleccionar.TextoBoton = "Seleccionar"
        '
        'lblSeleccionLote
        '
        Me.lblSeleccionLote.AutoSize = True
        Me.lblSeleccionLote.Location = New System.Drawing.Point(17, 114)
        Me.lblSeleccionLote.Name = "lblSeleccionLote"
        Me.lblSeleccionLote.Size = New System.Drawing.Size(86, 13)
        Me.lblSeleccionLote.TabIndex = 5
        Me.lblSeleccionLote.Text = "Seleccionar lote:"
        '
        'cmbLote
        '
        Me.cmbLote.FormattingEnabled = True
        Me.cmbLote.Location = New System.Drawing.Point(165, 112)
        Me.cmbLote.Name = "cmbLote"
        Me.cmbLote.Size = New System.Drawing.Size(188, 21)
        Me.cmbLote.TabIndex = 4
        '
        'frmSeleccionProyecto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(513, 195)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmSeleccionProyecto"
        Me.Text = "Selección de proyecto"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbProyecto As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblLotesdisponibles As System.Windows.Forms.Label
    Friend WithEvents cmbSeleccionar As libreriacadenaproduccion.Controles.Botones.CtrlBotonGrande
    Friend WithEvents lblSeleccionLote As System.Windows.Forms.Label
    Friend WithEvents cmbLote As System.Windows.Forms.ComboBox
    Friend WithEvents lblSeleccionProyecto As System.Windows.Forms.Label
    Friend WithEvents cmbAccion As System.Windows.Forms.ComboBox
End Class
