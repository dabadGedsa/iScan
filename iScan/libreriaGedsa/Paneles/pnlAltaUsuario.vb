Imports System.Windows.Forms
Imports libreriacadenaproduccion.Entidades.ClsUsuario
Imports datos = libreriacadenaproduccion.Datos.GeneralSQL.clsAccesoDatosSQL
Imports System.Collections

Public Class pnlAltaUsuario
    Dim conexion As String
    Dim accion As Modo



    Public Enum Modo
        nuevo_usuario = 0
        modificar_usuario = 1
    End Enum




#Region "Contructores"

    Public Sub New(ByVal modo As Modo, ByVal CadenaConexionAlServidor As String)


        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        conexion = CadenaConexionAlServidor
        accion = modo

        If modo = pnlAltaUsuario.Modo.modificar_usuario Then

            Me.cmbUsuarios.Visible = True
            Me.lblUsuarioModificar.Visible = True

            Me.cargarComboUsuarios()


        End If


    End Sub


#End Region

#Region "Funciones"

    Private Sub cargarComboUsuarios()


        Me.cmbUsuarios.Items.Clear()

        For Each registro As DataRow In Datos.GeneralSQL.clsAccesoDatosSQL.ObtenerListado("Cuentas", "*", conexion).Rows

            Dim usuAux As New Entidades.ClsUsuario(IIf(registro.Item("id").Equals(System.DBNull.Value), "", registro.Item("id")), IIf(registro.Item("nombre").Equals(System.DBNull.Value), "", registro.Item("nombre")), IIf(registro.Item("apellidos").Equals(System.DBNull.Value), "", registro.Item("apellidos")), IIf(registro.Item("nomusuario").Equals(System.DBNull.Value), "", registro.Item("nomusuario")), IIf(registro.Item("clave").Equals(System.DBNull.Value), "", registro.Item("clave")), Integer.Parse(registro.Item("Cargo")))

            Me.cmbUsuarios.Items.Add(usuAux)


        Next



    End Sub

    Private Function camposRellenados() As Boolean

        For Each control As Control In Me.grbDatosPersonales.Controls

            If TypeOf control Is TextBox Then
                If control.Text = "" Then
                    Return False
                End If
            End If

        Next


        For Each control As Control In Me.gprDatosCuenta.Controls

            If TypeOf control Is TextBox Then
                If control.Text = "" Then
                    Return False
                End If
            End If

        Next
        Return True

    End Function



    Private Function passworCorrecto() As Boolean
        Return Me.txtPass.Text.Equals(Me.txtRepitePass.Text)
    End Function


    Private Function limpiarCampos() As Boolean

        For Each control As Control In Me.grbDatosPersonales.Controls

            If TypeOf control Is TextBox Then
                control.Text = ""
            End If

        Next


        For Each control As Control In Me.gprDatosCuenta.Controls

            If TypeOf control Is TextBox Then
                control.Text = ""
            End If

        Next
        Return True

    End Function


#End Region




    Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click

        If Me.camposRellenados() Then

            If Me.passworCorrecto() Then

                If Me.accion = Modo.nuevo_usuario Then ' nuevo usuario

                    Dim listaParametrosParaNuevo As New SortedList(Of String, libreriacadenaproduccion.Entidades.clsItem)


                    listaParametrosParaNuevo.Add("id", New Entidades.clsItem("id", 1 + Integer.Parse(Datos.GeneralSQL.clsAccesoDatosSQL.ObtenerListado("cuentas", "Max(id)", conexion).Rows(0).Item(0))))
                    listaParametrosParaNuevo.Add("Nombre", New Entidades.clsItem("Nombre", Me.txtNombre.Text))
                    listaParametrosParaNuevo.Add("Apellidos", New Entidades.clsItem("Apellidos", Me.txtApellidos.Text))
                    listaParametrosParaNuevo.Add("NomUsuario", New Entidades.clsItem("NomUsuario", Me.txtUsu.Text))
                    listaParametrosParaNuevo.Add("Cargo", New Entidades.clsItem("Cargo", Me.txtCargo.Text))
                    listaParametrosParaNuevo.Add("Clave", New Entidades.clsItem("Clave", Me.txtPass.Text))
                    listaParametrosParaNuevo.Add("FechaAlta", New Entidades.clsItem("FechaAlta", Date.Now.ToShortDateString()))

                    If Datos.GeneralSQL.clsAccesoDatosSQL.insertarRegistro("Cuentas", listaParametrosParaNuevo, conexion) Then
                        MessageBox.Show("La insercion se ha realizado correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.limpiarCampos()

                    Else
                        MessageBox.Show("Ha habido un error en la insercion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If








                Else 'modificar usuario
                    Dim listaParametrosParaModificar As New SortedList(Of String, libreriacadenaproduccion.Entidades.clsItem)

                    listaParametrosParaModificar.Add("id", New Entidades.clsItem("id", CType(Me.cmbUsuarios.SelectedItem, Entidades.ClsUsuario)._id))
                    listaParametrosParaModificar.Add("Nombre", New Entidades.clsItem("Nombre", Me.txtNombre.Text))
                    listaParametrosParaModificar.Add("Apellidos", New Entidades.clsItem("Apellidos", Me.txtApellidos.Text))
                    listaParametrosParaModificar.Add("NomUsuario", New Entidades.clsItem("NomUsuario", Me.txtUsu.Text))
                    listaParametrosParaModificar.Add("Cargo", New Entidades.clsItem("Cargo", Me.txtCargo.Text))
                    listaParametrosParaModificar.Add("Clave", New Entidades.clsItem("Clave", Me.txtPass.Text))




                    Dim listaParametrosParaFiltro As New SortedList(Of String, libreriacadenaproduccion.Entidades.clsItem)
                    listaParametrosParaFiltro.Add("id", New Entidades.clsItem("id", CType(Me.cmbUsuarios.SelectedItem, Entidades.ClsUsuario)._id, Entidades.clsItem.tipoOperador._igual))

                    If Datos.GeneralSQL.clsAccesoDatosSQL.actualizarTabla("Cuentas", listaParametrosParaModificar, listaParametrosParaFiltro, conexion) Then
                        MessageBox.Show("La actualizacion se ha realizado correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.limpiarCampos()
                        Me.cargarComboUsuarios()
                    Else
                        MessageBox.Show("Ha habido un error en la actualizacion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                End If





            Else
                MessageBox.Show("El password debe ser identico en los dos campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Debes rellenar todos los campos antes de continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If




    End Sub

    Private Sub cmbUsuarios_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbUsuarios.SelectedIndexChanged


        Me.txtNombre.Text = CType(Me.cmbUsuarios.SelectedItem, Entidades.ClsUsuario)._nombre
        Me.txtApellidos.Text = CType(Me.cmbUsuarios.SelectedItem, Entidades.ClsUsuario)._apellidos
        Me.txtCargo.Text = CType(Me.cmbUsuarios.SelectedItem, Entidades.ClsUsuario)._cargo
        Me.txtUsu.Text = CType(Me.cmbUsuarios.SelectedItem, Entidades.ClsUsuario)._login
        Me.txtPass.Text = CType(Me.cmbUsuarios.SelectedItem, Entidades.ClsUsuario)._clave



    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Me.Parent.Dispose() ' se supone ke siempre ira contenido en un formulario, asi con esto, lo cerramos
    End Sub


End Class
