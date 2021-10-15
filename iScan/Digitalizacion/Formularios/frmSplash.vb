Imports System.Drawing.Drawing2D
Imports datos = libreriacadenaproduccion.Datos.GeneralSQL.clsAccesoDatosSQL
Imports DatosMDB = libreriacadenaproduccion.Datos.GeneralAccess.ClsAccesoDatosAccess
Imports LibreriaCadenaProduccion.Entidades
Imports System.Configuration
Imports System.Management
Imports System


Public Class frmSplash
    Inherits System.Windows.Forms.Form



    Private Const valorVectorPublico As String = "vecPubli"
    Private Const valorClavePublico As String = "claPubli"

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
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TxtClave As System.Windows.Forms.TextBox
    Friend WithEvents TxtUsuario As System.Windows.Forms.TextBox
    Friend WithEvents lblerror As System.Windows.Forms.Label
    Friend WithEvents cmbAceptar As System.Windows.Forms.Button
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Version As System.Windows.Forms.Label
    Friend WithEvents cmdSalir As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSplash))
        Me.lblerror = New System.Windows.Forms.Label
        Me.TxtClave = New System.Windows.Forms.TextBox
        Me.TxtUsuario = New System.Windows.Forms.TextBox
        Me.cmbAceptar = New System.Windows.Forms.Button
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.cmdSalir = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.Version = New System.Windows.Forms.Label
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblerror
        '
        Me.lblerror.BackColor = System.Drawing.Color.Transparent
        Me.lblerror.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblerror.ForeColor = System.Drawing.Color.Firebrick
        Me.lblerror.Location = New System.Drawing.Point(224, 336)
        Me.lblerror.Name = "lblerror"
        Me.lblerror.Size = New System.Drawing.Size(128, 47)
        Me.lblerror.TabIndex = 9
        Me.lblerror.Text = "La clave o usuario introducidos no son correctos."
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
        Me.TxtClave.TabIndex = 2
        Me.TxtClave.Tag = "2"
        '
        'TxtUsuario
        '
        Me.TxtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtUsuario.Location = New System.Drawing.Point(64, 304)
        Me.TxtUsuario.Name = "TxtUsuario"
        Me.TxtUsuario.Size = New System.Drawing.Size(152, 20)
        Me.TxtUsuario.TabIndex = 1
        Me.TxtUsuario.Tag = "1"
        '
        'cmbAceptar
        '
        Me.cmbAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbAceptar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAceptar.Location = New System.Drawing.Point(240, 304)
        Me.cmbAceptar.Name = "cmbAceptar"
        Me.cmbAceptar.Size = New System.Drawing.Size(88, 29)
        Me.cmbAceptar.TabIndex = 3
        Me.cmbAceptar.Tag = "3"
        Me.cmbAceptar.Text = "Aceptar"
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(16, 328)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(40, 16)
        Me.Label14.TabIndex = 19
        Me.Label14.Text = "Clave"
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Transparent
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
        Me.cmdSalir.Location = New System.Drawing.Point(462, 7)
        Me.cmdSalir.Name = "cmdSalir"
        Me.cmdSalir.Size = New System.Drawing.Size(16, 16)
        Me.cmdSalir.TabIndex = 5
        Me.cmdSalir.Tag = "5"
        Me.cmdSalir.Text = "X"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 130)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(466, 101)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Hospital Público Universitario De La Ribera"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox2
        '
        Me.PictureBox2.BackgroundImage = CType(resources.GetObject("PictureBox2.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.InitialImage = CType(resources.GetObject("PictureBox2.InitialImage"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(488, 392)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 23
        Me.PictureBox2.TabStop = False
        '
        'Version
        '
        Me.Version.AutoSize = True
        Me.Version.Location = New System.Drawing.Point(12, 267)
        Me.Version.Name = "Version"
        Me.Version.Size = New System.Drawing.Size(99, 14)
        Me.Version.TabIndex = 26
        Me.Version.Text = "V 10.6  04/03/2020"
        '
        'frmSplash
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.HighlightText
        Me.ClientSize = New System.Drawing.Size(488, 392)
        Me.Controls.Add(Me.Version)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdSalir)
        Me.Controls.Add(Me.lblerror)
        Me.Controls.Add(Me.TxtClave)
        Me.Controls.Add(Me.TxtUsuario)
        Me.Controls.Add(Me.cmbAceptar)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.PictureBox2)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmSplash"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub frmSplash_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim m As String = "" 'si los dejas en blanco se puede dar el caso que coincidan al dar los dos error de lectura, es dificil pero puede pasar 
        Dim mXML As String = ""

        Try

            'If Not IO.File.Exists("cd.xml") Then
            '    MessageBox.Show("Error, No se puede acceder al archivo de configuración. La aplicación se cerrará ")
            '    Application.Exit()
            'Else
            ''If My.Application.IsNetworkDeployed Then
            ''    Version.Text = " Versión. " & System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString()
            ''Else
            Version.Text = " Versión. " & My.Application.Info.Version.ToString()
                ''End If

                My.Settings.Item("cadenaconexion") = libCifrado.clsCifrado.desencriptarCadenaConFormato(My.Settings.cadenaConexion, "vecGedss", "claGedss")

                ' ''Dim registrada As Boolean = False
                ' ''m = leerMacEquipo()

                ' ''registrada = encontrada(m)

                ' If Not registrada Then
                'MessageBox.Show("Este equipo no tiene licencia para utilizar este software.")
                'Application.Exit()
                'Dim _frmlicencias As New frmLicencia
                '_frmlicencias.ShowDialog()

                'mXML = libCifrado.clsCifrado.desencriptarCadenaConFormato(libCifrado.clsCifrado.leerCodigoXML("cd.xml"), "vecGedsa", "claGedsa")

                'If m <> mXML Or m = "" Then
                '    MessageBox.Show("No se ha introducido una licencia valida por lo que la aplicación se cerrará.")
                '    Application.Exit()
                'Else
                '    Call ComprobarConexiones()
                '    TxtUsuario.Text = Environment.UserName
                '    'Me.fo()
                '    Application.DoEvents()
                'End If
                'Else
                'inicializamos la cadena de conxion 


                Call ComprobarConexiones()
                TxtUsuario.Text = Environment.UserName
                'Me.fo()
                Application.DoEvents()

                'If Not comprobarVerisiones() Then
            '    MessageBox.Show("La version del programa no es correcta. Contacte con departamento informática. ")
            '    Application.Exit()
            'End If

            'End If
            'End If

        Catch ex As Exception

            'Dim _frmlicencias As New frmLicencia
            '_frmlicencias.ShowDialog()

            'mXML = libCifrado.clsCifrado.desencriptarCadenaConFormato(libCifrado.clsCifrado.leerCodigoXML("cd.xml"), "vecGedsa", "claGedsa")

            'If Not registrada Then
            MessageBox.Show("No se ha introducido una licencia valida por lo que la aplicación se cerrará.")
            Application.Exit()
            'End If

        End Try

    End Sub

    Private Function comprobarVerisiones() As Boolean

        Dim tabla As DataTable

        tabla = datos.ObtenerListadoParaValorParametro("controlversiones", "idproyecto,version", "idproyecto", My.Settings.proyecto, My.Settings.cadenaConexion)

        'If tabla.Rows.Count > 0 Then

        '    If Trim(Application.ProductVersion) = Trim(tabla.Rows(0).Item("version").ToString) Then
        '        Debug.Print(Application.ProductVersion)
        '        Return True
        '    Else
        '        Return False
        '    End If

        'Else
        '    Return False
        'End If

    End Function


    Private Function encontrada(ByVal m As String) As Boolean

        Dim tabla As DataTable

        tabla = datos.ObtenerListado("controllicencias", "keycode", My.Settings.cadenaConexion)


        For Each registro As DataRow In tabla.Rows
            If Trim(m) = libCifrado.clsCifrado.desencriptarCadenaConFormato(Trim(registro.Item("keycode").ToString), "vecGedsa", "claGedsa") Then
                Return True
            End If
        Next

        'si llega aqui es porque no ha encontrado nada nos salimos del bucle
        Return False

    End Function


#Region "Control de los eventos del formulario"




    Private Sub cmbAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAceptar.Click

        Dim fila As DataRow
        Dim id As Integer = 0
        Dim res As DialogResult = Windows.Forms.DialogResult.Abort
        Dim usuario As LibreriaCadenaProduccion.Entidades.ClsUsuario

        If Me.TxtUsuario.Text <> "" And Me.TxtClave.Text <> "" Then

            Dim resultadoUsuarios As DataTable = datos.ejecutarSQLDirecta("SELECT idUsuario,NomUsuario,Nombre,Apellidos,idRol,idUltimaAccion from USUARIOS  where NomUsuario ='" & Me.TxtUsuario.Text & "' and clave  ='" & Me.TxtClave.Text.Trim & "'", My.Settings.cadenaConexion).Tables(0)

            If resultadoUsuarios.Rows.Count > 0 Then

                Try
                    listaTipoLotes = cargaTipoLotes(My.Settings.proyecto, My.Settings.cadenaConexion)

                    fila = resultadoUsuarios.Rows(0)

                    'inicializamos los datos para el usuario de la aplicacion 

                    usuario = New LibreriaCadenaProduccion.Entidades.ClsUsuario(CInt(fila.Item("idUsuario")), fila.Item("NomUsuario"))

                    usuario._apellidos = fila.Item("Apellidos").ToString
                    usuario._idRol = fila.Item("idRol")
                    usuario._idUltimaAccion = fila.Item("idUltimaAccion")
                    usuario._nombre = fila.Item("Nombre").ToString


                    'asignamos el nuevo usuario al formulario principal 
                    frmContenedorMDI.oUsuario = usuario
                    res = Windows.Forms.DialogResult.OK

                Catch ex As Exception
                    MessageBox.Show("Error, compruebe que el usuario tiene un rol asociado ")
                End Try

            Else

                Me.lblerror.Visible = True

            End If

        Else 'faltan campos por cumplimentar

            Me.lblerror.Visible = True

        End If

        If res = Windows.Forms.DialogResult.OK Then
            Me.DialogResult = res
            Me.Close()
        End If

    End Sub


    Private Sub TxtClave_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtClave.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.cmbAceptar_Click(Nothing, Nothing)
        End If
    End Sub


    Private Sub Txt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtClave.TextChanged, TxtUsuario.TextChanged
        Me.lblerror.Visible = False
    End Sub


    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click

        Me.DialogResult = DialogResult.Abort

    End Sub



#End Region


    Private Sub ComprobarConexiones()

        'comprobar conexiones a la base de datos access en configuracion es la correcta
        If datos.probarConexion(My.Settings.cadenaConexion) = False Then

            MessageBox.Show("Error la base de datos a la que se pretende conectar no corresponde a la utilizadar por la aplicación. La aplicación se cerrará.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Application.Exit()

        Else
            'formulario de solicitar la conexion: pedir servidor cadena conexion 
        End If


    End Sub


    Private Function leerMacEquipo() As String

        Dim mc As ManagementClass = New ManagementClass("Win32_NetworkAdapterConfiguration")
        Dim moc As ManagementObjectCollection = mc.GetInstances()

        Dim direccionMAC As String = ""

        For Each mo As ManagementObject In moc

            If CType(mo("IPEnabled"), Boolean) = True Then

                direccionMAC = mo("MacAddress").ToString()

                mo.Dispose()
                Exit For

            End If

        Next

        Return direccionMAC

    End Function


    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click

    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Version.Click

    End Sub
End Class
