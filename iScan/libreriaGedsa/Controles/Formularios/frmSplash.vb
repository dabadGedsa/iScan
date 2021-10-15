Imports System.Drawing.Drawing2D
Imports datosUsu = libreriacadenaproduccion.Datos.GeneralSQL.clsAccesoDatosSQL
Imports libreriacadenaproduccion.Entidades


Public Class frmSplash
    Inherits System.Windows.Forms.Form

    'Modificar estas variables para la consulta de usuario, no tocar nada mas

    Private Const tablaUsuarios = "Cuentas"
    Private Const nombreCampoUsuario = "Usuario"
    Private Const nombreCampoContraseña = "Pass"
    Private Const nombreCampoId = "Id"
    Private Const cadenaConexion = ""
    Dim usuario As ClsUsuario = Nothing






#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Timer1 As System.Timers.Timer
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TxtClave As System.Windows.Forms.TextBox
    Friend WithEvents TxtUsuario As System.Windows.Forms.TextBox
    Friend WithEvents lblerror As System.Windows.Forms.Label
    Friend WithEvents cmbAceptar As System.Windows.Forms.Button
    Friend WithEvents timerRecordar As System.Timers.Timer
    Friend WithEvents tmrFadeOut As System.Windows.Forms.Timer
    Friend WithEvents cmdSalir As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSplash))
        Me.Timer1 = New System.Timers.Timer
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.lblerror = New System.Windows.Forms.Label
        Me.TxtClave = New System.Windows.Forms.TextBox
        Me.TxtUsuario = New System.Windows.Forms.TextBox
        Me.cmbAceptar = New System.Windows.Forms.Button
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.cmdSalir = New System.Windows.Forms.Button
        Me.timerRecordar = New System.Timers.Timer
        Me.tmrFadeOut = New System.Windows.Forms.Timer(Me.components)
        CType(Me.Timer1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.timerRecordar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.SynchronizingObject = Me
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.ErrorImage = CType(resources.GetObject("PictureBox1.ErrorImage"), System.Drawing.Image)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.InitialImage = CType(resources.GetObject("PictureBox1.InitialImage"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(8, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(472, 376)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 21
        Me.PictureBox1.TabStop = False
        '
        'lblerror
        '
        Me.lblerror.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblerror.ForeColor = System.Drawing.Color.Firebrick
        Me.lblerror.Location = New System.Drawing.Point(224, 336)
        Me.lblerror.Name = "lblerror"
        Me.lblerror.Size = New System.Drawing.Size(128, 40)
        Me.lblerror.TabIndex = 9
        Me.lblerror.Text = "La clave o nombre de usuario introducidos no son correctos."
        Me.lblerror.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblerror.Visible = False
        '
        'TxtClave
        '
        Me.TxtClave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtClave.Location = New System.Drawing.Point(64, 328)
        Me.TxtClave.Name = "TxtClave"
        Me.TxtClave.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtClave.Size = New System.Drawing.Size(152, 20)
        Me.TxtClave.TabIndex = 12
        '
        'TxtUsuario
        '
        Me.TxtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtUsuario.Location = New System.Drawing.Point(64, 304)
        Me.TxtUsuario.Name = "TxtUsuario"
        Me.TxtUsuario.Size = New System.Drawing.Size(152, 20)
        Me.TxtUsuario.TabIndex = 10
        '
        'cmbAceptar
        '
        Me.cmbAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbAceptar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAceptar.Location = New System.Drawing.Point(240, 304)
        Me.cmbAceptar.Name = "cmbAceptar"
        Me.cmbAceptar.Size = New System.Drawing.Size(88, 29)
        Me.cmbAceptar.TabIndex = 14
        Me.cmbAceptar.Text = "Aceptar"
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(16, 328)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(40, 16)
        Me.Label14.TabIndex = 19
        Me.Label14.Text = "Clave"
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(16, 304)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(48, 16)
        Me.Label15.TabIndex = 18
        Me.Label15.Text = "Usuario"
        '
        'cmdSalir
        '
        Me.cmdSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdSalir.Location = New System.Drawing.Point(456, 16)
        Me.cmdSalir.Name = "cmdSalir"
        Me.cmdSalir.Size = New System.Drawing.Size(16, 16)
        Me.cmdSalir.TabIndex = 22
        Me.cmdSalir.Text = "X"
        '
        'timerRecordar
        '
        Me.timerRecordar.Enabled = True
        Me.timerRecordar.Interval = 3000
        Me.timerRecordar.SynchronizingObject = Me
        '
        'tmrFadeOut
        '
        Me.tmrFadeOut.Interval = 10
        '
        'frmSplash
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.HighlightText
        Me.ClientSize = New System.Drawing.Size(488, 392)
        Me.Controls.Add(Me.cmdSalir)
        Me.Controls.Add(Me.lblerror)
        Me.Controls.Add(Me.TxtClave)
        Me.Controls.Add(Me.TxtUsuario)
        Me.Controls.Add(Me.cmbAceptar)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.PictureBox1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmSplash"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.Timer1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.timerRecordar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region




    Private Sub cmbAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAceptar.Click



        Dim clave As String
        Dim usuario As ClsUsuario = Nothing

        clave = Me.TxtClave.Text.Trim
        If Me.TxtUsuario.Text <> "" And Me.TxtClave.Text <> "" Then

            Dim resultadoUsuarios As DataTable = datosUsu.ejecutarSQLDirecta("Selec * from " & tablaUsuarios & " where " & nombreCampoUsuario & "='" & Me.TxtUsuario.Text & "' and " & nombreCampoContraseña & "='" & nombreCampoContraseña & "'", cadenaConexion).Tables(0)


            If resultadoUsuarios.Rows.Count > 0 Then
                Me.usuario = New ClsUsuario(resultadoUsuarios.Rows(0).Item(nombreCampoId), resultadoUsuarios.Rows(0).Item(nombreCampoUsuario))

            Else


            End If




        Else 'faltan campos por cumplimentar
            Me.lblerror.Visible = True
        End If



    End Sub




    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click

        Me.DialogResult = Windows.Forms.DialogResult.Abort
        tmrFadeOut.Enabled = True
        tmrFadeOut.Start()
    End Sub


    Private Sub tmrFadeOut_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmrFadeOut.Tick
        Me.Opacity = Me.Opacity - 0.01
        If Me.Opacity = 0 Then
            Me.Close()
        End If
    End Sub

   
End Class
