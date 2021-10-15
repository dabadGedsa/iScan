<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLicencia
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtcodigoProducto = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbActivar = New System.Windows.Forms.Button
        Me.txtLicencia = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdAceptar = New System.Windows.Forms.Button
        Me.lbllicencia = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lbllicencia)
        Me.GroupBox1.Controls.Add(Me.txtcodigoProducto)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmbActivar)
        Me.GroupBox1.Controls.Add(Me.txtLicencia)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmdAceptar)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(416, 329)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Control Licencia"
        '
        'txtcodigoProducto
        '
        Me.txtcodigoProducto.Location = New System.Drawing.Point(30, 223)
        Me.txtcodigoProducto.Name = "txtcodigoProducto"
        Me.txtcodigoProducto.Size = New System.Drawing.Size(354, 20)
        Me.txtcodigoProducto.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(29, 192)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Código Producto"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(26, 143)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(365, 39)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Si no dispone de licencia puede adquirirla enviando el siguiente código de produc" & _
            "to a su proveedor"
        '
        'cmbActivar
        '
        Me.cmbActivar.Location = New System.Drawing.Point(309, 89)
        Me.cmbActivar.Name = "cmbActivar"
        Me.cmbActivar.Size = New System.Drawing.Size(75, 23)
        Me.cmbActivar.TabIndex = 4
        Me.cmbActivar.Text = "Activar"
        Me.cmbActivar.UseVisualStyleBackColor = True
        '
        'txtLicencia
        '
        Me.txtLicencia.Location = New System.Drawing.Point(30, 92)
        Me.txtLicencia.Name = "txtLicencia"
        Me.txtLicencia.Size = New System.Drawing.Size(268, 20)
        Me.txtLicencia.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(27, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(365, 51)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Este equipo no tiene licencia para utilizar este software.   Si dispone de una li" & _
            "cencia escriba el código de esta en el siguitente recuadro y pulse boton activar" & _
            ""
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Location = New System.Drawing.Point(296, 293)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(88, 30)
        Me.cmdAceptar.TabIndex = 0
        Me.cmdAceptar.Text = "Aceptar "
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'lbllicencia
        '
        Me.lbllicencia.AutoSize = True
        Me.lbllicencia.ForeColor = System.Drawing.Color.Red
        Me.lbllicencia.Location = New System.Drawing.Point(32, 119)
        Me.lbllicencia.Name = "lbllicencia"
        Me.lbllicencia.Size = New System.Drawing.Size(165, 13)
        Me.lbllicencia.TabIndex = 8
        Me.lbllicencia.Text = "El código de licencia no es valido"
        Me.lbllicencia.Visible = False
        '
        'frmLicencia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(435, 353)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmLicencia"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbActivar As System.Windows.Forms.Button
    Friend WithEvents txtLicencia As System.Windows.Forms.TextBox
    Friend WithEvents txtcodigoProducto As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbllicencia As System.Windows.Forms.Label
End Class
