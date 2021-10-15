<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditarFIP
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEditarFIP))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmbServicios = New System.Windows.Forms.ComboBox
        Me.txtFechaInicio = New System.Windows.Forms.TextBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtNumhistoria = New System.Windows.Forms.TextBox
        Me.CtrlBotonMediano2 = New LibreriaCadenaProduccion.Controles.Botones.CtrlBotonMediano
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cmbServicios)
        Me.GroupBox1.Controls.Add(Me.txtFechaInicio)
        Me.GroupBox1.Controls.Add(Me.Label28)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtNumhistoria)
        Me.GroupBox1.Controls.Add(Me.CtrlBotonMediano2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(510, 172)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(18, 74)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(93, 44)
        Me.Label6.TabIndex = 44
        Me.Label6.Text = "Fecha documento (dd/mm/yyyy)"
        '
        'cmbServicios
        '
        Me.cmbServicios.FormattingEnabled = True
        Me.cmbServicios.Location = New System.Drawing.Point(307, 26)
        Me.cmbServicios.Name = "cmbServicios"
        Me.cmbServicios.Size = New System.Drawing.Size(153, 21)
        Me.cmbServicios.TabIndex = 43
        '
        'txtFechaInicio
        '
        Me.txtFechaInicio.Location = New System.Drawing.Point(120, 71)
        Me.txtFechaInicio.Name = "txtFechaInicio"
        Me.txtFechaInicio.Size = New System.Drawing.Size(116, 20)
        Me.txtFechaInicio.TabIndex = 42
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(256, 29)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(45, 13)
        Me.Label28.TabIndex = 41
        Me.Label28.Text = "Servicio"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "NHC"
        '
        'txtNumhistoria
        '
        Me.txtNumhistoria.Location = New System.Drawing.Point(80, 23)
        Me.txtNumhistoria.Name = "txtNumhistoria"
        Me.txtNumhistoria.Size = New System.Drawing.Size(156, 20)
        Me.txtNumhistoria.TabIndex = 21
        '
        'CtrlBotonMediano2
        '
        Me.CtrlBotonMediano2.BackColor = System.Drawing.Color.Transparent
        Me.CtrlBotonMediano2.EnabledBoton = True
        Me.CtrlBotonMediano2.Location = New System.Drawing.Point(350, 112)
        Me.CtrlBotonMediano2.Name = "CtrlBotonMediano2"
        Me.CtrlBotonMediano2.pImagenMouseEnter = CType(resources.GetObject("CtrlBotonMediano2.pImagenMouseEnter"), System.Drawing.Image)
        Me.CtrlBotonMediano2.pImagenMouseLeave = CType(resources.GetObject("CtrlBotonMediano2.pImagenMouseLeave"), System.Drawing.Image)
        Me.CtrlBotonMediano2.pImagenMouseOver = CType(resources.GetObject("CtrlBotonMediano2.pImagenMouseOver"), System.Drawing.Image)
        Me.CtrlBotonMediano2.Size = New System.Drawing.Size(110, 28)
        Me.CtrlBotonMediano2.TabIndex = 20
        Me.CtrlBotonMediano2.TextoBoton = "Modificar Datos"
        '
        'frmEditarFIP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(528, 193)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmEditarFIP"
        Me.Text = "frmEditarFIP"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbServicios As System.Windows.Forms.ComboBox
    Friend WithEvents txtFechaInicio As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNumhistoria As System.Windows.Forms.TextBox
    Friend WithEvents CtrlBotonMediano2 As LibreriaCadenaProduccion.Controles.Botones.CtrlBotonMediano
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
