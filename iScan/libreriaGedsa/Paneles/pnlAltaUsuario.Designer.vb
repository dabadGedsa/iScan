<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class pnlAltaUsuario
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
        Me.gprDatosCuenta = New System.Windows.Forms.GroupBox
        Me.lbl5 = New System.Windows.Forms.Label
        Me.txtCargo = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtUsu = New System.Windows.Forms.TextBox
        Me.txtRepitePass = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtPass = New System.Windows.Forms.TextBox
        Me.grbDatosPersonales = New System.Windows.Forms.GroupBox
        Me.txtNombre = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtApellidos = New System.Windows.Forms.TextBox
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.cmdAceptar = New System.Windows.Forms.Button
        Me.cmbUsuarios = New System.Windows.Forms.ComboBox
        Me.lblUsuarioModificar = New System.Windows.Forms.Label
        Me.gprDatosCuenta.SuspendLayout()
        Me.grbDatosPersonales.SuspendLayout()
        Me.SuspendLayout()
        '
        'gprDatosCuenta
        '
        Me.gprDatosCuenta.Controls.Add(Me.lbl5)
        Me.gprDatosCuenta.Controls.Add(Me.txtCargo)
        Me.gprDatosCuenta.Controls.Add(Me.Label3)
        Me.gprDatosCuenta.Controls.Add(Me.txtUsu)
        Me.gprDatosCuenta.Controls.Add(Me.txtRepitePass)
        Me.gprDatosCuenta.Controls.Add(Me.Label4)
        Me.gprDatosCuenta.Controls.Add(Me.Label5)
        Me.gprDatosCuenta.Controls.Add(Me.txtPass)
        Me.gprDatosCuenta.Location = New System.Drawing.Point(285, 26)
        Me.gprDatosCuenta.Name = "gprDatosCuenta"
        Me.gprDatosCuenta.Size = New System.Drawing.Size(259, 150)
        Me.gprDatosCuenta.TabIndex = 13
        Me.gprDatosCuenta.TabStop = False
        Me.gprDatosCuenta.Text = "Datos Cuenta"
        '
        'lbl5
        '
        Me.lbl5.AutoSize = True
        Me.lbl5.Location = New System.Drawing.Point(37, 51)
        Me.lbl5.Name = "lbl5"
        Me.lbl5.Size = New System.Drawing.Size(35, 13)
        Me.lbl5.TabIndex = 10
        Me.lbl5.Text = "Cargo"
        '
        'txtCargo
        '
        Me.txtCargo.Location = New System.Drawing.Point(210, 48)
        Me.txtCargo.MaxLength = 2
        Me.txtCargo.Name = "txtCargo"
        Me.txtCargo.Size = New System.Drawing.Size(32, 20)
        Me.txtCargo.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(37, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Nombre Usuario"
        '
        'txtUsu
        '
        Me.txtUsu.Location = New System.Drawing.Point(142, 19)
        Me.txtUsu.MaxLength = 50
        Me.txtUsu.Name = "txtUsu"
        Me.txtUsu.Size = New System.Drawing.Size(100, 20)
        Me.txtUsu.TabIndex = 5
        '
        'txtRepitePass
        '
        Me.txtRepitePass.Location = New System.Drawing.Point(142, 110)
        Me.txtRepitePass.MaxLength = 50
        Me.txtRepitePass.Name = "txtRepitePass"
        Me.txtRepitePass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtRepitePass.Size = New System.Drawing.Size(100, 20)
        Me.txtRepitePass.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(37, 82)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Password"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(37, 113)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Repita passord"
        '
        'txtPass
        '
        Me.txtPass.Location = New System.Drawing.Point(142, 79)
        Me.txtPass.MaxLength = 50
        Me.txtPass.Name = "txtPass"
        Me.txtPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPass.Size = New System.Drawing.Size(100, 20)
        Me.txtPass.TabIndex = 7
        '
        'grbDatosPersonales
        '
        Me.grbDatosPersonales.Controls.Add(Me.txtNombre)
        Me.grbDatosPersonales.Controls.Add(Me.Label1)
        Me.grbDatosPersonales.Controls.Add(Me.Label2)
        Me.grbDatosPersonales.Controls.Add(Me.txtApellidos)
        Me.grbDatosPersonales.Location = New System.Drawing.Point(13, 26)
        Me.grbDatosPersonales.Name = "grbDatosPersonales"
        Me.grbDatosPersonales.Size = New System.Drawing.Size(232, 124)
        Me.grbDatosPersonales.TabIndex = 12
        Me.grbDatosPersonales.TabStop = False
        Me.grbDatosPersonales.Text = "Datos Personales"
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(70, 19)
        Me.txtNombre.MaxLength = 50
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(133, 20)
        Me.txtNombre.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nombre"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Apellidos"
        '
        'txtApellidos
        '
        Me.txtApellidos.Location = New System.Drawing.Point(70, 64)
        Me.txtApellidos.MaxLength = 50
        Me.txtApellidos.Name = "txtApellidos"
        Me.txtApellidos.Size = New System.Drawing.Size(133, 20)
        Me.txtApellidos.TabIndex = 3
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Location = New System.Drawing.Point(469, 182)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancelar.TabIndex = 14
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Location = New System.Drawing.Point(388, 182)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(75, 23)
        Me.cmdAceptar.TabIndex = 15
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'cmbUsuarios
        '
        Me.cmbUsuarios.FormattingEnabled = True
        Me.cmbUsuarios.Location = New System.Drawing.Point(113, 3)
        Me.cmbUsuarios.Name = "cmbUsuarios"
        Me.cmbUsuarios.Size = New System.Drawing.Size(132, 21)
        Me.cmbUsuarios.TabIndex = 16
        Me.cmbUsuarios.Visible = False
        '
        'lblUsuarioModificar
        '
        Me.lblUsuarioModificar.AutoSize = True
        Me.lblUsuarioModificar.Location = New System.Drawing.Point(10, 6)
        Me.lblUsuarioModificar.Name = "lblUsuarioModificar"
        Me.lblUsuarioModificar.Size = New System.Drawing.Size(97, 13)
        Me.lblUsuarioModificar.TabIndex = 4
        Me.lblUsuarioModificar.Text = "Usuario a modificar"
        Me.lblUsuarioModificar.Visible = False
        '
        'pnlAltaUsuario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblUsuarioModificar)
        Me.Controls.Add(Me.cmbUsuarios)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.gprDatosCuenta)
        Me.Controls.Add(Me.grbDatosPersonales)
        Me.Name = "pnlAltaUsuario"
        Me.Size = New System.Drawing.Size(556, 216)
        Me.gprDatosCuenta.ResumeLayout(False)
        Me.gprDatosCuenta.PerformLayout()
        Me.grbDatosPersonales.ResumeLayout(False)
        Me.grbDatosPersonales.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gprDatosCuenta As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtUsu As System.Windows.Forms.TextBox
    Friend WithEvents txtRepitePass As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPass As System.Windows.Forms.TextBox
    Friend WithEvents grbDatosPersonales As System.Windows.Forms.GroupBox
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtApellidos As System.Windows.Forms.TextBox
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents lbl5 As System.Windows.Forms.Label
    Friend WithEvents txtCargo As System.Windows.Forms.TextBox
    Friend WithEvents cmbUsuarios As System.Windows.Forms.ComboBox
    Friend WithEvents lblUsuarioModificar As System.Windows.Forms.Label

End Class
