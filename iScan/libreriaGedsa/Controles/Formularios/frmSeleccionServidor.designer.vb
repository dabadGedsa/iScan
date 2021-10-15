
Namespace Controles
    Namespace Formularios



        <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
        Partial Class frmSeleccionServidor
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
                Me.Label1 = New System.Windows.Forms.Label
                Me.cmdServidores = New System.Windows.Forms.ComboBox
                Me.Label3 = New System.Windows.Forms.Label
                Me.Label4 = New System.Windows.Forms.Label
                Me.txtUser = New System.Windows.Forms.TextBox
                Me.txtPsw = New System.Windows.Forms.TextBox
                Me.cmdConectar = New System.Windows.Forms.Button
                Me.Label5 = New System.Windows.Forms.Label
                Me.GroupBox1 = New System.Windows.Forms.GroupBox
                Me.GroupBox2 = New System.Windows.Forms.GroupBox
                Me.btnProbarConexxion = New System.Windows.Forms.Button
                Me.GroupBox3 = New System.Windows.Forms.GroupBox
                Me.cmbBD = New System.Windows.Forms.ComboBox
                Me.GroupBox1.SuspendLayout()
                Me.GroupBox2.SuspendLayout()
                Me.GroupBox3.SuspendLayout()
                Me.SuspendLayout()
                '
                'Label1
                '
                Me.Label1.AutoSize = True
                Me.Label1.Location = New System.Drawing.Point(21, 30)
                Me.Label1.Name = "Label1"
                Me.Label1.Size = New System.Drawing.Size(212, 13)
                Me.Label1.TabIndex = 0
                Me.Label1.Text = "Seleccione o escriba el nombre del servidor"
                '
                'cmdServidores
                '
                Me.cmdServidores.FormattingEnabled = True
                Me.cmdServidores.Location = New System.Drawing.Point(24, 58)
                Me.cmdServidores.Name = "cmdServidores"
                Me.cmdServidores.Size = New System.Drawing.Size(273, 21)
                Me.cmdServidores.TabIndex = 1
                '
                'Label3
                '
                Me.Label3.AutoSize = True
                Me.Label3.Location = New System.Drawing.Point(22, 37)
                Me.Label3.Name = "Label3"
                Me.Label3.Size = New System.Drawing.Size(83, 13)
                Me.Label3.TabIndex = 3
                Me.Label3.Text = "Nombre Usuario"
                '
                'Label4
                '
                Me.Label4.AutoSize = True
                Me.Label4.Location = New System.Drawing.Point(22, 73)
                Me.Label4.Name = "Label4"
                Me.Label4.Size = New System.Drawing.Size(61, 13)
                Me.Label4.TabIndex = 4
                Me.Label4.Text = "Contraseña"
                '
                'txtUser
                '
                Me.txtUser.Location = New System.Drawing.Point(129, 34)
                Me.txtUser.Name = "txtUser"
                Me.txtUser.Size = New System.Drawing.Size(159, 20)
                Me.txtUser.TabIndex = 5
                '
                'txtPsw
                '
                Me.txtPsw.Location = New System.Drawing.Point(129, 73)
                Me.txtPsw.Name = "txtPsw"
                Me.txtPsw.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
                Me.txtPsw.Size = New System.Drawing.Size(159, 20)
                Me.txtPsw.TabIndex = 6
                '
                'cmdConectar
                '
                Me.cmdConectar.Location = New System.Drawing.Point(193, 66)
                Me.cmdConectar.Name = "cmdConectar"
                Me.cmdConectar.Size = New System.Drawing.Size(105, 28)
                Me.cmdConectar.TabIndex = 7
                Me.cmdConectar.Text = "Conectar"
                Me.cmdConectar.UseVisualStyleBackColor = True
                '
                'Label5
                '
                Me.Label5.AutoSize = True
                Me.Label5.Location = New System.Drawing.Point(22, 25)
                Me.Label5.Name = "Label5"
                Me.Label5.Size = New System.Drawing.Size(141, 13)
                Me.Label5.TabIndex = 8
                Me.Label5.Text = "Nombre de la Base de datos"
                '
                'GroupBox1
                '
                Me.GroupBox1.Controls.Add(Me.cmdServidores)
                Me.GroupBox1.Controls.Add(Me.Label1)
                Me.GroupBox1.Location = New System.Drawing.Point(21, 12)
                Me.GroupBox1.Name = "GroupBox1"
                Me.GroupBox1.Size = New System.Drawing.Size(326, 100)
                Me.GroupBox1.TabIndex = 10
                Me.GroupBox1.TabStop = False
                Me.GroupBox1.Text = "Seleccione el servidor de datos"
                '
                'GroupBox2
                '
                Me.GroupBox2.Controls.Add(Me.btnProbarConexxion)
                Me.GroupBox2.Controls.Add(Me.Label3)
                Me.GroupBox2.Controls.Add(Me.Label4)
                Me.GroupBox2.Controls.Add(Me.txtPsw)
                Me.GroupBox2.Controls.Add(Me.txtUser)
                Me.GroupBox2.Location = New System.Drawing.Point(21, 133)
                Me.GroupBox2.Name = "GroupBox2"
                Me.GroupBox2.Size = New System.Drawing.Size(326, 144)
                Me.GroupBox2.TabIndex = 11
                Me.GroupBox2.TabStop = False
                Me.GroupBox2.Text = "Login del Servidor"
                '
                'btnProbarConexxion
                '
                Me.btnProbarConexxion.Location = New System.Drawing.Point(193, 110)
                Me.btnProbarConexxion.Name = "btnProbarConexxion"
                Me.btnProbarConexxion.Size = New System.Drawing.Size(95, 28)
                Me.btnProbarConexxion.TabIndex = 10
                Me.btnProbarConexxion.Text = "Probar conexión"
                Me.btnProbarConexxion.UseVisualStyleBackColor = True
                '
                'GroupBox3
                '
                Me.GroupBox3.Controls.Add(Me.cmbBD)
                Me.GroupBox3.Controls.Add(Me.Label5)
                Me.GroupBox3.Controls.Add(Me.cmdConectar)
                Me.GroupBox3.Location = New System.Drawing.Point(21, 296)
                Me.GroupBox3.Name = "GroupBox3"
                Me.GroupBox3.Size = New System.Drawing.Size(326, 112)
                Me.GroupBox3.TabIndex = 11
                Me.GroupBox3.TabStop = False
                Me.GroupBox3.Text = "Tabla del servidor"
                '
                'cmbBD
                '
                Me.cmbBD.FormattingEnabled = True
                Me.cmbBD.Location = New System.Drawing.Point(169, 22)
                Me.cmbBD.Name = "cmbBD"
                Me.cmbBD.Size = New System.Drawing.Size(128, 21)
                Me.cmbBD.TabIndex = 2
                '
                'frmSeleccionServidor
                '
                Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
                Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
                Me.ClientSize = New System.Drawing.Size(373, 431)
                Me.Controls.Add(Me.GroupBox2)
                Me.Controls.Add(Me.GroupBox3)
                Me.Controls.Add(Me.GroupBox1)
                Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
                Me.MaximizeBox = False
                Me.Name = "frmSeleccionServidor"
                Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
                Me.Text = "SELECCION SERVIDOR"
                Me.GroupBox1.ResumeLayout(False)
                Me.GroupBox1.PerformLayout()
                Me.GroupBox2.ResumeLayout(False)
                Me.GroupBox2.PerformLayout()
                Me.GroupBox3.ResumeLayout(False)
                Me.GroupBox3.PerformLayout()
                Me.ResumeLayout(False)

            End Sub
            Friend WithEvents Label1 As System.Windows.Forms.Label
            Friend WithEvents cmdServidores As System.Windows.Forms.ComboBox
            Friend WithEvents Label3 As System.Windows.Forms.Label
            Friend WithEvents Label4 As System.Windows.Forms.Label
            Friend WithEvents txtUser As System.Windows.Forms.TextBox
            Friend WithEvents txtPsw As System.Windows.Forms.TextBox
            Friend WithEvents cmdConectar As System.Windows.Forms.Button
            Friend WithEvents Label5 As System.Windows.Forms.Label
            Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
            Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
            Friend WithEvents btnProbarConexxion As System.Windows.Forms.Button
            Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
            Friend WithEvents cmbBD As System.Windows.Forms.ComboBox
        End Class


    End Namespace
End Namespace
