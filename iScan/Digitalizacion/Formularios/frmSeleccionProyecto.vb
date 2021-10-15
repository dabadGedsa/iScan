Imports AccesoDatos = libreriacadenaproduccion.Datos.GeneralSQL.clsAccesoDatosSQL
Imports datosLote = libreriacadenaproduccion.Datos.Produccion.cadenaproduccion.clsAccesoDatosLote

Public Class frmSeleccionProyecto



    Public Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
    End Sub


    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub


    Private Sub frmSeleccionProyecto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Cargamos todos los registros de los hospitales

        acciones_refresca()

        

    End Sub



#Region "Carga Informacion de Lote de proyecto"

    ''' <summary>
    ''' Refresca el combobox de los proyectos
    ''' </summary>
    ''' <remarks></remarks>
    Sub proyectos_refresca()

        cmbLote.Enabled = False
        cmbSeleccionar.Enabled = False
        lblLotesdisponibles.Text = "Lotes disponibles"

        'Limpiamos los proyectos que existan en el combo
        cmbProyecto.Items.Clear()
        cmbProyecto.Refresh()

        Me.cmbProyecto.Items.Add("")

        Dim proyecto As LibreriaCadenaProduccion.Entidades.clsProyecto

        Try
            For Each registro As DataRow In AccesoDatos.ObtenerListadoParaValorParametro("Proyectos p,configuracionproyecto cp", " p.idProyecto, p.Nombre,cp.rutaimagenes, ISNULL(ServidorBaseDatos,'NAN') AS ServidorBaseDatos, ISNULL(UsuarioBaseDatos,'NAN') AS UsuarioBaseDatos,  ISNULL(ClaveBaseDatos,'NAN') AS ClaveBaseDatos, ISNULL( NombreBaseDatos,'NAN') AS NombreBaseDatos", "Activo", 1, My.Settings.cadenaConexion, "p.idProyecto", "cp.idProyecto", "p.idProyecto").Rows
                proyecto = New LibreriaCadenaProduccion.Entidades.clsProyecto(registro.Item("idproyecto").ToString(), registro.Item("nombre").ToString(), registro.Item("rutaimagenes").ToString, libCifrado.clsCifrado.desencriptarCadenaConFormato(registro.Item("ServidorBaseDAtos").ToString, "vecGedsa", "claGedsa"), libCifrado.clsCifrado.desencriptarCadenaConFormato(registro.Item("UsuarioBaseDatos").ToString, "vecGedsa", "claGedsa"), libCifrado.clsCifrado.desencriptarCadenaConFormato(registro.Item("ClaveBaseDatos").ToString, "vecGedsa", "claGedsa"), libCifrado.clsCifrado.desencriptarCadenaConFormato(registro.Item("NombreBaseDatos").ToString, "vecGedsa", "claGedsa"))

                If proyecto._CodigoProyecto = My.Settings.proyecto Then
                    Me.cmbProyecto.Items.Add(proyecto)
                    Me.cmbProyecto.SelectedItem = proyecto
                End If
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try

    End Sub

    ''' <summary>
    ''' Esta funcion se encarga de actualizar el comboBox de los lotes, correspondientes
    ''' al proyecto seleccionado
    ''' </summary>
    ''' <remarks></remarks>
    Sub lotes_refresca()

        If cmbProyecto.SelectedIndex > 0 Then


            'Limbiamos los lotes que puedan existir
            cmbLote.Items.Clear()

            cmbLote.Items.Add("")

            Dim lote As LibreriaCadenaProduccion.Entidades.ClsLote
            Dim tablaLotes As DataTable = Nothing

            If cmbProyecto.SelectedItem._obtenerCadenaConexionProyecto = "NAN" Then
                MessageBox.Show("No hay una base de datos definida para este proyecto")
                Exit Sub
            End If

            'en funcion de la accion q ha seleccionado el usuario cargamos el listado de lotes 
            Select Case cmbAccion.SelectedItem._idAccion
                Case frmContenedorMDI.Accion.digitalizar
                    tablaLotes = datosLote.ObtenerLoteParaDigitalizar(frmContenedorMDI.oProyecto._CodigoProyecto, frmContenedorMDI.oUsuario._login, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto)
                Case frmContenedorMDI.Accion.verificar
                    tablaLotes = datosLote.ObtenerLoteParaVerificar(frmContenedorMDI.oProyecto._CodigoProyecto, frmContenedorMDI.oUsuario._login, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto)
                Case frmContenedorMDI.Accion.corregir
                    tablaLotes = datosLote.ObtenerLoteParaCorregirDIGI(frmContenedorMDI.oProyecto._CodigoProyecto, frmContenedorMDI.oUsuario._login, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto)
                Case frmContenedorMDI.Accion.indizar
                    tablaLotes = datosLote.ObtenerLoteParaIndizacion(frmContenedorMDI.oProyecto._CodigoProyecto, frmContenedorMDI.oUsuario._login, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto)
                Case frmContenedorMDI.Accion.corregirPAED
                    tablaLotes = datosLote.ObtenerLoteParaCorreccionPAED(frmContenedorMDI.oProyecto._CodigoProyecto, frmContenedorMDI.oUsuario._login, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto)

              

            End Select



            lblLotesdisponibles.Text = "Lotes para " & Me.cmbAccion.SelectedItem._descripcion.ToString & ": " & tablaLotes.Rows.Count

            If tablaLotes.Rows.Count > 0 Then
                For Each registro As DataRow In tablaLotes.Rows

                    lote = New LibreriaCadenaProduccion.Entidades.ClsLote(registro.Item("idLote").ToString, frmContenedorMDI.oProyecto._CodigoProyecto, registro.Item("fechalote").ToString)
                    lote._asignado = registro.Item("Asignado").ToString

                    If cmbAccion.SelectedItem._idAccion = frmContenedorMDI.Accion.indizar Then
                        lote._servicio = registro.Item("idservicio").ToString.Trim
                        lote._tipoDocumento = registro.Item("idtipoDocumento").ToString.Trim
                    Else
                        lote._servicio = ""
                        lote._tipoDocumento = ""
                        If cmbAccion.SelectedItem._idaccion = frmContenedorMDI.Accion.digitalizar Then
                            If IsDBNull(registro.Item("numeroPosiciones")) Then lote._posiciones = 0 Else lote._posiciones = registro.Item("numeroPosiciones")
                        End If
                    End If

                    Me.cmbLote.Items.Add(lote)

                Next
            End If
        End If

    End Sub

    Sub acciones_refresca()

        cmbLote.Enabled = False
        cmbSeleccionar.Enabled = False


        'Limpiamos los proyectos que existan en el combo
        Me.cmbAccion.Items.Clear()
        Me.cmbAccion.Refresh()


        Dim accion As LibreriaCadenaProduccion.Entidades.clsAccion

        Try
            For Each registro As DataRow In AccesoDatos.ObtenerListadoParaValorParametro("acciones", "idAccion,descripcion", "(IdAccion IN (SELECT idAccion FROM ROLacciones WHERE idRol ", frmContenedorMDI.oUsuario._idRol & "))", My.Settings.cadenaConexion, , , ).Rows
                accion = New LibreriaCadenaProduccion.Entidades.clsAccion()
                accion._descripcion = registro.Item("Descripcion")
                accion._idAccion = registro.Item("idAccion")
                Me.cmbAccion.Items.Add(accion)
                If accion._idAccion = frmContenedorMDI.oUsuario._idUltimaAccion Then
                    Me.cmbAccion.SelectedItem = accion
                    frmContenedorMDI.oFuncionAplicacion = Me.cmbAccion.SelectedItem._idAccion
                End If
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try

    End Sub

#End Region

    Private Sub cmbProyecto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbProyecto.SelectedIndexChanged
        If cmbProyecto.SelectedIndex > 0 Then
            frmContenedorMDI.oProyecto = Me.cmbProyecto.SelectedItem

            lotes_refresca()
            'Cargamos los lotes y habilitamos la seleccion de los mismos
            cmbLote.Enabled = True

        Else
            'Vaciamos el componente hacemos enabled  = false
            frmContenedorMDI.oProyecto = Nothing

            'Limpiamos el combo de los lotes
            cmbLote.Items.Clear()

            cmbLote.Enabled = False
        End If
    End Sub

    Private Sub cmbSeleccionarLote_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLote.SelectedIndexChanged
        If cmbLote.SelectedIndex <= 0 Then
            cmbSeleccionar.Enabled = False
        Else
            cmbSeleccionar.Enabled = True
        End If
    End Sub


    Private Sub cmbAccion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAccion.SelectedIndexChanged

        If Not IsNothing(Me.cmbAccion.SelectedItem) Then

            frmContenedorMDI.oFuncionAplicacion = Me.cmbAccion.SelectedItem._idAccion

            If Me.cmbAccion.SelectedItem._idAccion <> 6 And Me.cmbAccion.SelectedItem._idAccion <> 8 And Me.cmbAccion.SelectedItem._idAccion <> 9 And Me.cmbAccion.SelectedItem._idAccion <> 7 Then
                Me.cmbSeleccionar.Enabled = False

                Me.lblLotesdisponibles.Visible = True
                Me.lblSeleccionLote.Visible = True
                Me.lblSeleccionProyecto.Visible = True
                Me.cmbProyecto.Visible = True
                Me.cmbLote.Visible = True

                proyectos_refresca()
            Else
                Me.cmbSeleccionar.Enabled = True
                Me.lblLotesdisponibles.Visible = False
                Me.lblSeleccionLote.Visible = False
                Me.lblSeleccionProyecto.Visible = False
                Me.cmbProyecto.Visible = False
                Me.cmbProyecto.Items.Clear()
                Me.cmbLote.Visible = False
                Me.cmbLote.Items.Clear()
            End If
        End If

    End Sub

    Private Sub cmbSeleccionar_eClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSeleccionar.eClick

        If Me.cmbAccion.SelectedItem._idaccion = 6 Or Me.cmbAccion.SelectedItem._idaccion = 8 Or Me.cmbAccion.SelectedItem._idaccion = 7 Or Me.cmbAccion.SelectedItem._idaccion = 9 Then 'estamos en modo administrador 

            Me.Close()

        ElseIf Me.cmbLote.Text <> "" Then 'no estamos en modo administra y hay un lote seleccionado 

            frmContenedorMDI.oLote = Me.cmbLote.SelectedItem

            'si ya esta asignado al usuario nos pasamos la actualizacion de la asignación  
            If frmContenedorMDI.oLote._asignado <> "1" Then
                'asignacion del lote al usuario derificación 

                Select Case cmbAccion.SelectedItem._idAccion
                    Case frmContenedorMDI.Accion.digitalizar
                        If datosLote.AsignarLoteParaDigitalizar(frmContenedorMDI.oUsuario._login, frmContenedorMDI.oLote._idlote, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto) = 0 Then
                            Exit Sub
                        End If
                    Case frmContenedorMDI.Accion.verificar
                        If datosLote.AsignarLoteVerificacion(frmContenedorMDI.oUsuario._login, frmContenedorMDI.oLote._idlote, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto) = 0 Then
                            Exit Sub
                        End If
                    Case frmContenedorMDI.Accion.corregir
                        If datosLote.AsignarLoteCorreccionDIGI(frmContenedorMDI.oUsuario._login, frmContenedorMDI.oLote._idlote, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto) = 0 Then
                            Exit Sub
                        End If
                    Case frmContenedorMDI.Accion.indizar
                        If datosLote.AsignarLoteIndizacion(frmContenedorMDI.oUsuario._login, frmContenedorMDI.oLote._idlote, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto) = 0 Then
                            Exit Sub
                        End If
                    Case frmContenedorMDI.Accion.corregirPAED
                        If datosLote.AsignarLoteCorreccionPAED(frmContenedorMDI.oUsuario._login, frmContenedorMDI.oLote._idlote, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto) = 0 Then
                            Exit Sub
                        End If

                End Select
            End If

            Me.Close()
        Else
            MessageBox.Show("No ha seleccionado un lote, seleccione un lote del desplegable.")

        End If
    End Sub

End Class