<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNuevaCabeceraBarcode
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNuevaCabeceraBarcode))
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtCabeceraBarcode = New System.Windows.Forms.TextBox
        Me.cmdAceptar = New LibreriaCadenaProduccion.Controles.Botones.CtrlBotonMediano
        Me.cmdCancelar = New LibreriaCadenaProduccion.Controles.Botones.CtrlBotonMediano
        Me.Label2 = New System.Windows.Forms.Label
        Me.nudlongitudCodigoBarras = New System.Windows.Forms.NumericUpDown
        CType(Me.nudlongitudCodigoBarras, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(30, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(122, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Cabecera Código Barras"
        '
        'txtCabeceraBarcode
        '
        Me.txtCabeceraBarcode.Location = New System.Drawing.Point(168, 37)
        Me.txtCabeceraBarcode.Name = "txtCabeceraBarcode"
        Me.txtCabeceraBarcode.Size = New System.Drawing.Size(78, 20)
        Me.txtCabeceraBarcode.TabIndex = 1
        '
        'cmdAceptar
        '
        Me.cmdAceptar.BackColor = System.Drawing.Color.Transparent
        Me.cmdAceptar.EnabledBoton = True
        Me.cmdAceptar.Location = New System.Drawing.Point(130, 129)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.pImagenMouseEnter = CType(resources.GetObject("cmdAceptar.pImagenMouseEnter"), System.Drawing.Image)
        Me.cmdAceptar.pImagenMouseLeave = CType(resources.GetObject("cmdAceptar.pImagenMouseLeave"), System.Drawing.Image)
        Me.cmdAceptar.pImagenMouseOver = CType(resources.GetObject("cmdAceptar.pImagenMouseOver"), System.Drawing.Image)
        Me.cmdAceptar.Size = New System.Drawing.Size(80, 21)
        Me.cmdAceptar.TabIndex = 2
        Me.cmdAceptar.TextoBoton = "Aceptar"
        '
        'cmdCancelar
        '
        Me.cmdCancelar.BackColor = System.Drawing.Color.Transparent
        Me.cmdCancelar.EnabledBoton = True
        Me.cmdCancelar.Location = New System.Drawing.Point(225, 129)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.pImagenMouseEnter = CType(resources.GetObject("cmdCancelar.pImagenMouseEnter"), System.Drawing.Image)
        Me.cmdCancelar.pImagenMouseLeave = CType(resources.GetObject("cmdCancelar.pImagenMouseLeave"), System.Drawing.Image)
        Me.cmdCancelar.pImagenMouseOver = CType(resources.GetObject("cmdCancelar.pImagenMouseOver"), System.Drawing.Image)
        Me.cmdCancelar.Size = New System.Drawing.Size(80, 21)
        Me.cmdCancelar.TabIndex = 3
        Me.cmdCancelar.TextoBoton = "Cancelar"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(30, 82)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(115, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Longitud código barras"
        '
        'nudlongitudCodigoBarras
        '
        Me.nudlongitudCodigoBarras.Location = New System.Drawing.Point(168, 80)
        Me.nudlongitudCodigoBarras.Name = "nudlongitudCodigoBarras"
        Me.nudlongitudCodigoBarras.Size = New System.Drawing.Size(42, 20)
        Me.nudlongitudCodigoBarras.TabIndex = 5
        '
        'frmNuevaCabeceraBarcode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(317, 163)
        Me.Controls.Add(Me.nudlongitudCodigoBarras)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.txtCabeceraBarcode)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmNuevaCabeceraBarcode"
        Me.Text = "Nueva Cabecera Barcode"
        CType(Me.nudlongitudCodigoBarras, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCabeceraBarcode As System.Windows.Forms.TextBox
    Friend WithEvents cmdAceptar As LibreriaCadenaProduccion.Controles.Botones.CtrlBotonMediano
    Friend WithEvents cmdCancelar As LibreriaCadenaProduccion.Controles.Botones.CtrlBotonMediano
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents nudlongitudCodigoBarras As System.Windows.Forms.NumericUpDown
End Class
