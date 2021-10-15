Imports datosSQl = LibreriaCadenaProduccion.Datos.GeneralSQL.clsAccesoDatosSQL


Public Class frmIndizacionLote


    Private Enum tipoDocumentacion
        GENERAL = 1
        BANCOS = 2
        GASTOS_CORRIENTES = 3
        IMPUESTOS = 4
        SEGUROS = 5
        LABORAL = 6
        FINES_FUNDACIONALES = 7
    End Enum

#Region "Clases auxiliaresa para la gestion de los expedientes y de las convocatorias "

    Private Class clsConvocatoria

        Public idconcatoria As Integer
        Public descripcionConvocatoria As String

        Public Overrides Function ToString() As String
            Return Me.descripcionConvocatoria
        End Function

    End Class


    Private Class clsExpediente

        Public idExpediente As String
        Public NombreSolicitante As String
        Public ApellidoSolicitante As String

        Public Overrides Function ToString() As String
            Return Me.idExpediente
        End Function


    End Class

#End Region


    Private Sub cmbGeneral_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbGeneral.Click

        Dim CamposConsulta As String = "Nombreconvocatoria,referencia,NombreSolicitante,idtipodocumentacion"
        Dim valoresConsulta As String = ""
        Dim correcto As Boolean = True
        Dim mensaje As String = ""
        Dim idtipodocumentacion As Integer = tipoDocumentacion.GENERAL


        If Me.cmbconvocatoria.Text = "" Then
            correcto = False
            mensaje = " convocatoria "
        End If

        If Me.cmbReferencia.Text = "" Then
            correcto = False
            mensaje = " referencia "
        End If


        If Me.txtGENERALnombre.Text = "" Then
            correcto = False
            mensaje = " nonmbre solicitante "
        End If

        If correcto Then

            valoresConsulta = "'" & cmbconvocatoria.Text & "','" & cmbReferencia.Text & "','" & txtGENERALnombre.Text & "'," & tipoDocumentacion.GENERAL
            ejecutarConsultaIndizaciondatos(CamposConsulta, valoresConsulta, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto)
        Else
            MessageBox.Show("Los datos no se actualizaran faltan por cumplimentar los datos: " & mensaje)
        End If

    End Sub

#Region "gestion de los eventos de los distintos combos de la opcion general esto es asin y asin se lo hemos contado "
    Private Sub cmbReferencia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbReferencia.SelectedIndexChanged

        Dim datosExpediente As clsExpediente


        If Not IsNothing(Me.cmbReferencia.SelectedItem) Then

            datosExpediente = Me.cmbReferencia.SelectedItem

            Me.txtGENERALnombre.Enabled = True
            Me.txtGENERALnombre.Text = datosExpediente.NombreSolicitante.ToUpper & " " & datosExpediente.ApellidoSolicitante.ToUpper

        End If

    End Sub


    Private Sub comboConvocatoria_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbconvocatoria.SelectedIndexChanged

        Dim convocatoria As clsConvocatoria
        Dim datosExpediente As clsExpediente
        Dim tablaDatosExpediente As DataTable


        Me.cmbReferencia.Items.Clear()
        Me.cmbReferencia.Refresh()

        If Not IsNothing(Me.cmbconvocatoria.SelectedItem) Then


            convocatoria = Me.cmbconvocatoria.SelectedItem

            tablaDatosExpediente = datosSQl.ejecutarSQLDirectaTable("SELECT  [idexpediente],[NombreSolicitante],[Apellido1Solicitante] FROM [PRODUCCIONSEN].[dbo].[EXPEDIENTES] where [idconvocatoria] = " & convocatoria.idconcatoria, "Data Source=libra;Initial Catalog=PRODUCCIONSEN;User ID=sa;Password=sa2003")

            If tablaDatosExpediente.Rows.Count > 0 Then

                For Each registro As DataRow In tablaDatosExpediente.Rows
                    datosExpediente = New clsExpediente

                    datosExpediente.idExpediente = registro.Item("idExpediente")
                    datosExpediente.NombreSolicitante = registro.Item("Nombresolicitante")
                    datosExpediente.ApellidoSolicitante = registro.Item("Apellido1Solicitante")

                    Me.cmbReferencia.Items.Add(datosExpediente)

                Next

            End If

        End If


    End Sub
#End Region

    Private Sub cmdbancos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBancos.Click

        Dim CamposConsulta As String = "fecha,importe,numasiento,idtipodocumentacion"
        Dim valoresConsulta As String = ""
        Dim correcto As Boolean = True
        Dim mensaje As String = ""
        Dim idtipodocumentacion As Integer = tipoDocumentacion.BANCOS

        If Me.txtBancosAsiento.Text = "" Then
            correcto = False
            mensaje = " Nº asiento"
        End If

        If Me.txtBancosFecha.Text = "" Then
            correcto = False
            mensaje = " fecha "
        End If


        If Me.txtBancosImporte.Text = "" Then
            correcto = False
            mensaje = " importe "
        End If

        If correcto Then

            valoresConsulta = "'" & Me.txtBancosFecha.Text & "','" & Me.txtBancosImporte.Text & "','" & Me.txtBancosAsiento.Text & "'," & tipoDocumentacion.BANCOS
            ejecutarConsultaIndizaciondatos(CamposConsulta, valoresConsulta, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto)
        Else
            MessageBox.Show("Los datos no se actualizaran faltan por cumplimentar los datos: " & mensaje)
        End If

    End Sub

    Private Sub cmbGastosCorrientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim CamposConsulta As String = "fecha,importe,numasiento,proveedor,idtipodocumentacion"
        Dim valoresConsulta As String = ""
        Dim correcto As Boolean = True
        Dim mensaje As String = ""
        Dim idtipodocumentacion As Integer = tipoDocumentacion.GASTOS_CORRIENTES

        If Me.txtGASTOSfecha.Text = "" Then
            correcto = False
            mensaje = " fecha "
        End If

        If Me.txtGASTOSimporte.Text = "" Then
            correcto = False
            mensaje = " importe "
        End If


        If Me.txtGASTOSnumasiento.Text = "" Then
            correcto = False
            mensaje = " numasiento "
        End If


        If Me.txtGASTOSproveedor.Text = "" Then
            correcto = False
            mensaje = " proveedor "
        End If

        If correcto Then
            valoresConsulta = "'" & Me.txtGASTOSfecha.Text & "','" & Me.txtGASTOSimporte.Text & "','" & Me.txtGASTOSnumasiento.Text & "','" & Me.txtGASTOSproveedor.Text & "'," & tipoDocumentacion.GASTOS_CORRIENTES
            ejecutarConsultaIndizaciondatos(CamposConsulta, valoresConsulta, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto)
        Else
            MessageBox.Show("Los datos no se actualizaran faltan por cumplimentar los datos: " & mensaje)
        End If
    End Sub

    Private Sub cmdImpuestos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImpuestos.Click

        Dim CamposConsulta As String = "importe,modelo,fecha,idtipodocumentacion"
        Dim valoresConsulta As String = ""
        Dim correcto As Boolean = True
        Dim mensaje As String = ""
        Dim idtipodocumentacion As Integer = tipoDocumentacion.IMPUESTOS

        If Me.txtIMPUESTOSimporte.Text = "" Then
            correcto = False
            mensaje = " importe "
        End If

        If Me.txtIMPUESTOSmodelo.Text = "" Then
            correcto = False
            mensaje = " modelo "
        End If

        If Me.txtIMPUESTOSfecha.Text = "" Then
            correcto = False
            mensaje = "fecha "
        End If

        If correcto Then
            valoresConsulta = "'" & Me.txtIMPUESTOSimporte.Text & "','" & Me.txtIMPUESTOSmodelo.Text & "','" & Me.txtIMPUESTOSfecha.Text & "'," & tipoDocumentacion.IMPUESTOS
            ejecutarConsultaIndizaciondatos(CamposConsulta, valoresConsulta, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto)
        Else
            MessageBox.Show("Los datos no se actualizaran faltan por cumplimentar los datos: " & mensaje)
        End If
    End Sub


    Private Sub cmdSEGUROS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSEGUROS.Click
        Dim CamposConsulta As String = "importe,fecha,numpoliza,companyia,numasiento,idtipodocumentacion"
        Dim valoresConsulta As String = ""
        Dim correcto As Boolean = True
        Dim mensaje As String = ""
        Dim idtipodocumentacion As Integer = tipoDocumentacion.SEGUROS


        If Me.txtSEGUROSimporte.Text = "" Then
            correcto = False
            mensaje = " importe "
        End If

        If Me.txtSEGUROSfecha.Text = "" Then
            correcto = False
            mensaje = " fecha "
        End If


        If Me.txtSEGUROSnumpoliza.Text = "" Then
            correcto = False
            mensaje = " numero de poliza "
        End If


        If Me.txtSEGUROScompanyia.Text = "" Then
            correcto = False
            mensaje = " compañia  "
        End If

        If Me.txtSEGUROSnumasiento.Text = "" Then
            correcto = False
            mensaje = " numasiento "
        End If


        If correcto Then

            valoresConsulta = "'" & Me.txtSEGUROSimporte.Text & "','" & Me.txtSEGUROSfecha.Text & "','" & Me.txtSEGUROSnumpoliza.Text & "','" & Me.txtSEGUROScompanyia.Text & "','" & Me.txtSEGUROSnumasiento.Text & "'," & tipoDocumentacion.SEGUROS
            ejecutarConsultaIndizaciondatos(CamposConsulta, valoresConsulta, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto)
        Else
            MessageBox.Show("Los datos no se actualizaran faltan por cumplimentar los datos: " & mensaje)
        End If

    End Sub


    Private Sub cmdLABORAL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLABORAL.Click
        Dim CamposConsulta As String = "nombre,dni,fecha,importe,idtipodocumentacion"
        Dim valoresConsulta As String = ""
        Dim correcto As Boolean = True
        Dim mensaje As String = ""
        Dim idtipodocumentacion As Integer = tipoDocumentacion.LABORAL


        If Me.txtLABORALnombre.Text = "" Then
            correcto = False
            mensaje = " nombre "
        End If

        If Me.txtLABORALdni.Text = "" Then
            correcto = False
            mensaje = " dni "
        End If


        If Me.txtLABORALfecha.Text = "" Then
            correcto = False
            mensaje = " fecha "
        End If


        If Me.txtLABORALimporte.Text = "" Then
            correcto = False
            mensaje = " importe  "
        End If

        
        If correcto Then

            valoresConsulta = "'" & Me.txtLABORALnombre.Text & "','" & Me.txtLABORALdni.Text & "','" & Me.txtLABORALfecha.Text & "','" & Me.txtLABORALimporte.Text & "'," & tipoDocumentacion.LABORAL
            ejecutarConsultaIndizaciondatos(CamposConsulta, valoresConsulta, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto)
        Else
            MessageBox.Show("Los datos no se actualizaran faltan por cumplimentar los datos: " & mensaje)
        End If
    End Sub


    Private Sub cmdFINES_FUNDACIONALES_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFinesFundacionales.Click

        Dim CamposConsulta As String = "numasiento,fecha,importe,nombreconvocatoria,dni,nombre,organismo,entidadOrigen,idtipodocumentacion"
        Dim valoresConsulta As String = ""
        Dim correcto As Boolean = True
        Dim mensaje As String = ""
        Dim idtipodocumentacion As Integer = tipoDocumentacion.FINES_FUNDACIONALES


        If Me.txtFUNDACIONALESnumasiento.Text = "" Then
            correcto = False
            mensaje = " numasiento "
        End If

        If Me.txtFUNDACIONALESfecha.Text = "" Then
            correcto = False
            mensaje = " fecha "
        End If


        If Me.txtFUNDACIONALESimporte.Text = "" Then
            correcto = False
            mensaje = " importe "
        End If


        If Me.txtFUNDACIONALESconvocatoria.Text = "" Then
            correcto = False
            mensaje = " convocatoria "
        End If


        If Me.txtFUNDACIONALESdni.Text = "" Then
            correcto = False
            mensaje = " dni "
        End If


        If Me.txtFUNDACIONALESnombre.Text = "" Then
            correcto = False
            mensaje = " nombre "
        End If


        If Me.txtFUNDACIONALESorganismo.Text = "" Then
            correcto = False
            mensaje = " oreganismo "
        End If


        If Me.txtFUNCIONALESentidad.Text = "" Then
            correcto = False
            mensaje = " entidad origen  "
        End If


        If correcto Then

            valoresConsulta = "'" & Me.txtFUNDACIONALESnumasiento.Text & "','" & Me.txtFUNDACIONALESfecha.Text & "','" & Me.txtFUNDACIONALESimporte.Text & "','" & Me.txtFUNDACIONALESconvocatoria.Text & "','" & Me.txtFUNDACIONALESdni.Text & "','" & Me.txtFUNDACIONALESnombre.Text & "','" & Me.txtFUNDACIONALESorganismo.Text & "','" & Me.txtFUNCIONALESentidad.Text & "'," & tipoDocumentacion.FINES_FUNDACIONALES
            ejecutarConsultaIndizaciondatos(CamposConsulta, valoresConsulta, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto)
        Else
            MessageBox.Show("Los datos no se actualizaran faltan por cumplimentar los datos: " & mensaje)
        End If


    End Sub


    Private Sub ejecutarConsultaIndizaciondatos(ByVal campos As String, ByVal valores As String, ByVal cadenaconexion As String)

        Dim campos_sep() As String = Split(campos, ",")
        Dim valores_sep() As String = Split(valores, ",")
        Dim cadenaActualizaciones As String = ""


        For i As Integer = 0 To campos_sep.Length - 1

            cadenaActualizaciones = cadenaActualizaciones & campos_sep(i) & "=" & valores_sep(i) & ","
        Next

        cadenaActualizaciones = Mid(cadenaActualizaciones, 1, cadenaActualizaciones.Length - 1)
        Dim consultaBD As String = "update lotes  set " & cadenaActualizaciones & " where idlote = " & frmContenedorMDI.oLote._idlote

        If datosSQl.ejecutaSQLEjecucion(consultaBD, cadenaconexion, , True) Then
            MessageBox.Show("Los datos se han actualizado correctamente")

        Else
            MessageBox.Show("Error los datos no se han actualizado correctamente")

        End If

    End Sub


    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged

        Select Case TabControl1.SelectedIndex + 1
            Case tipoDocumentacion.GENERAL
                Debug.Print("estamos por aqui )")
                Dim convocatorias As clsConvocatoria
                Dim tablaConvocatorias As DataTable

                tablaConvocatorias = datosSQl.ejecutarSQLDirectaTable("SELECT  idconvocatoria, descripcionconvocatoria FROM convocatorias  ", "Data Source=libra;Initial Catalog=PRODUCCIONSEN;User ID=sa;Password=sa2003")

                For Each registro As DataRow In tablaConvocatorias.Rows

                    convocatorias = New clsConvocatoria
                    convocatorias.idconcatoria = registro.Item("idconvocatoria")
                    convocatorias.descripcionConvocatoria = registro.Item("DescripcionConvocatoria")

                    Me.cmbconvocatoria.Items.Add(convocatorias)

                Next
            Case tipoDocumentacion.BANCOS

        End Select
    End Sub

    Private Sub frmIndizacionLote_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.TabControl1.SelectedIndex = 1
        Me.TabControl1.SelectedIndex = 0
    End Sub


  
 


End Class