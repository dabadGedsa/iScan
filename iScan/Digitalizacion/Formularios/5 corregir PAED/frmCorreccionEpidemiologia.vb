Imports datos = LibreriaCadenaProduccion.Datos.GeneralSQL.clsAccesoDatosSQL
Imports accesoDatosLotes = LibreriaCadenaProduccion.Datos.Produccion.cadenaproduccion.clsAccesoDatosLote
Imports accesoDatosProduccion = LibreriaCadenaProduccion.Datos.Produccion.clsAccesoDatosProduccion


Public Class frmCorreccionEpidemiologia
    Private porcentaje As Integer
    Private docusporcentaje As Integer
    Private rutaImagenes

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        ' Me.CtrlPorcentajeCorreccion1.anyadirInstancia(Me)
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.labelescribeme.textoLabel = "Lote = " & frmContenedorMDI.oLote._idlote & " Proyecto = " & frmContenedorMDI.oLote._codigoproyecto
        Me.rutaImagenes = accesoDatosProduccion.ObtenerRutaImagenes(frmContenedorMDI.oProyecto._CodigoProyecto, _
                          frmContenedorMDI.oLote._idlote, My.Settings.cadenaConexion)
        Me.DataGridView1.Focus()

    End Sub

    Public Sub inicializarDataGrid(ByVal porcentaje As Integer)
        Try
            Me.porcentaje = porcentaje
            Me.labelescribeme.textoLabel = "Lote = " & frmContenedorMDI.oLote._idlote & " Proyecto = " & frmContenedorMDI.oLote._codigoproyecto & " Porcentaje= " & porcentaje
            Dim dato As New DataTable
            Dim listaIdentificadoresDocumento As DataTable
            Dim rnd As Random
            Dim j As Integer
            Dim datoaux As New DataTable
            Dim datosAuxiliares As New DataTable
            Dim reg As DataRow

            listaIdentificadoresDocumento = datos.ObtenerListadoParaValorParametro("documentos", "pagina", "idlote", frmContenedorMDI.oLote._idlote, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto, , , "pagina")
            Dim cantidadDocumentos As Integer = listaIdentificadoresDocumento.Rows.Count
            Me.docusporcentaje = cantidadDocumentos




            'aqui tienes la cantidad de documentos que tienes que sacar 
            'ahora hay que hacer una lista aleatoria de los iddocumentos
            Try

                cantidadDocumentos = obtenerDocumentos(cantidadDocumentos)
                datoaux = datos.ObtenerDataSet(frmContenedorMDI.oLote._idlote, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto).Tables(0)
                rnd = New Random
                dato = datoaux.Clone
                For i As Integer = 0 To cantidadDocumentos - 1
                    j = rnd.Next(datoaux.Rows(i).Item("pagina"), listaIdentificadoresDocumento.Rows.Count - 1)
                    Debug.Print(j)
                    dato.ImportRow(datoaux.Rows(j))
                Next


            Catch ex As Exception
                MessageBox.Show("Error al obtener los lotes " & ex.Message.ToString)
            End Try




            Me.DataGridView1.DataSource = dato
            ' Me.DataGridView1.DataMember = "Documentos"
            'Me.DataGridView1.Columns(0).Visible = False
            'Me.DataGridView1.Columns(6).Visible = False
            Dim rutaImagen As String = Me.rutaImagenes & "\" & Me.DataGridView1.Rows(0).Cells("nomarchivotif").Value
            Me.mostrarImagen(rutaImagen)
        Catch ex As Exception
            MessageBox.Show("Error al actualizar el GRID " & ex.Message.ToString)
        End Try
    End Sub

    Public Function obtenerDocumentos(ByVal cantidaddocumentos As Integer)
        Dim numerodocumentos As Integer = 1

        Select Case cantidaddocumentos
            Case 1 To 8
                numerodocumentos = 2
            Case 9 To 15
                numerodocumentos = 3
            Case 16 To 25
                numerodocumentos = 5
            Case 26 To 50
                numerodocumentos = 8
            Case 51 To 90
                numerodocumentos = 13
            Case 91 To 150
                numerodocumentos = 20
            Case 151 To 280
                numerodocumentos = 32
            Case 281 To 500
                numerodocumentos = 50
            Case 501 To 1200
                numerodocumentos = 80
            Case Is > 1201
                numerodocumentos = 125
        End Select


        Return numerodocumentos
    End Function


    Public Sub mostrarImagen(ByVal ruta As String)

        Try
            If IO.File.Exists(ruta) Then
                With Me.IMGeditPrincipal
                    .ClearDisplay()
                    .Image = ""
                    .Image = ruta
                    .FitTo(1)
                    .Display()
                    .Refresh()
                End With
            Else
                MessageBox.Show("La ruta seleccionada no existe")
            End If
        Catch ex As Exception
            ' MessageBox.Show("Error al cargar la imagen")
            mostrarImagen(ruta)
        End Try
    End Sub
    Private Sub IMGeditPrincipal_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IMGeditPrincipal.Close

    End Sub

    Private Sub DataGridView1_RowLeave(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.RowLeave

    End Sub

    Private Sub DataGridView1_CellLeave(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellLeave
        Try
            Me.DataGridView1.EndEdit()
            Dim i As Integer = e.ColumnIndex
            Dim nombre As String = Me.DataGridView1.Columns(e.ColumnIndex).Name
            Dim iddocumento As Integer = Me.DataGridView1.Rows(e.RowIndex).Cells("iddocumento").Value
            Dim valorinicial As String = ""
            Dim valorfinal As String = ""


            'Modificamos solo en la tabla documentos
            If (nombre = "tipodocumento") Then

                valorinicial = datos.ejecutarSQLDirectaDataRow("select tipodocumento from documentos where iddocumento = " & iddocumento, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto).Item("tipodocumento").ToString
                valorfinal = Me.DataGridView1.Rows(e.RowIndex).Cells("tipodocumento").Value
                Debug.Print("valor inicial -->" & valorinicial)
                Debug.Print("valor final --> " & valorfinal)
                If Trim(valorfinal) <> (valorinicial) Then
                    If Not datos.ejecutaSQLEjecucion("Update documentos set tipodocumento = " & valorfinal & " where iddocumento = " & iddocumento, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto, , True) Then
                        'si no se puede actualizar en la base de datos lo dejamos como estaba 

                        Me.DataGridView1.Rows(e.RowIndex).Cells("tipodocumento").Value = valorinicial
                    End If
                    Me.persistirLogModificacionesPAED(iddocumento, nombre, valorinicial, valorfinal)
                End If

            End If
            'es el numero de historia asi que modificamos en la tabla documentos
            If (nombre = "numhistoria") Then

                valorinicial = datos.ejecutarSQLDirectaDataRow("select numhistoria from documentos where iddocumento = " & iddocumento, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto).Item("numhistoria").ToString
                valorfinal = Me.DataGridView1.Rows(e.RowIndex).Cells("numhistoria").Value
                If Trim(valorfinal) <> Trim(valorinicial) Then
                    If Not datos.ejecutaSQLEjecucion("Update documentos set numHistoria = " & valorfinal & " where iddocumento = " & iddocumento, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto, , True) Then
                        'si no se puede actualizar en la base de datos lo dejamos como estaba 
                        Me.DataGridView1.Rows(e.RowIndex).Cells("numhistoria").Value = valorinicial
                    End If
                    Me.persistirLogModificacionesPAED(iddocumento, nombre, valorinicial, valorfinal)
                End If
            End If
            'Es el nombre modificamos en fip

            If (nombre = "numicu") Then
                valorinicial = datos.ejecutarSQLDirectaDataRow("select numicu from documentos where iddocumento = " & iddocumento, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto).Item("numicu").ToString
                valorfinal = Me.DataGridView1.Rows(e.RowIndex).Cells("numIcu").Value
                If Trim(valorfinal) <> Trim(valorinicial) Then
                    If Not datos.ejecutaSQLEjecucion("Update documentos set numicu = '" & valorfinal & "' where iddocumento = " & iddocumento, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto, , True) Then
                        'si no se puede actualizar en la base de datos lo dejamos como estaba 
                        Me.DataGridView1.Rows(e.RowIndex).Cells("numIcu").Value = valorinicial
                    End If
                    Me.persistirLogModificacionesPAED(iddocumento, nombre, valorinicial, valorfinal)
                End If
            End If

            If (nombre = "codserviciopaed") Then
                valorinicial = datos.ejecutarSQLDirectaDataRow("select codserviciopaed from documentos where iddocumento = " & iddocumento, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto).Item("codserviciopaed").ToString
                valorfinal = Me.DataGridView1.Rows(e.RowIndex).Cells("codserviciopaed").Value
                If Trim(valorfinal) <> Trim(valorinicial) Then
                    If Not datos.ejecutaSQLEjecucion("Update documentos set codserviciopaed = '" & valorfinal & "' where iddocumento = " & iddocumento, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto, , True) Then
                        'si no se puede actualizar en la base de datos lo dejamos como estaba 
                        Me.DataGridView1.Rows(e.RowIndex).Cells("codserviciopaed").Value = valorinicial
                    End If
                    Me.persistirLogModificacionesPAED(iddocumento, nombre, valorinicial, valorfinal)
                End If
            End If

            If (nombre = "fechainicio") Then
                valorinicial = datos.ejecutarSQLDirectaDataRow("select fechainicio from documentos where iddocumento = " & iddocumento, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto).Item("fechainicio").ToString
                valorfinal = Me.DataGridView1.Rows(e.RowIndex).Cells("fechainicio").Value
                If Trim(valorfinal) <> Trim(valorinicial) Then
                    If Not datos.ejecutaSQLEjecucion("Update documentos set fechainicio = '" & valorfinal & "' where iddocumento = " & iddocumento, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto, , True) Then
                        'si no se puede actualizar en la base de datos lo dejamos como estaba 
                        Me.DataGridView1.Rows(e.RowIndex).Cells("fechainicio").Value = valorinicial
                    End If
                    Me.persistirLogModificacionesPAED(iddocumento, nombre, valorinicial, valorfinal)
                End If
            End If

            '
            If (nombre = "fechaTermino") Then
                valorinicial = datos.ejecutarSQLDirectaDataRow("select fechatermino from documentos where iddocumento = " & iddocumento, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto).Item("fechatermino").ToString
                valorfinal = Me.DataGridView1.Rows(e.RowIndex).Cells("fechatermino").Value
                If Trim(valorfinal) <> Trim(valorinicial) Then
                    If Not datos.ejecutaSQLEjecucion("Update documentos set fechatermino = '" & valorfinal & "' where iddocumento = " & iddocumento, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto, , True) Then
                        'si no se puede actualizar en la base de datos lo dejamos como estaba 
                        Me.DataGridView1.Rows(e.RowIndex).Cells("fechatermino").Value = valorinicial
                    End If
                    Me.persistirLogModificacionesPAED(iddocumento, nombre, valorinicial, valorfinal)
                End If
            End If

            Me.DataGridView1.Refresh()
        Catch ex As Exception

        End Try
    End Sub
    ''' <summary>
    ''' Método que permitirar cerrar el lote
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CtrlBotonMediano1_eClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CtrlBotonMediano1.eClick


        If accesoDatosLotes.CerrarLoteCorreccionPAED(frmContenedorMDI.oUsuario._login, frmContenedorMDI.oLote._idlote, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto) Then
            datos.ejecutarSQLDirecta("Update lotes set porcentajecorreccion = " & Me.porcentaje & " where idlote = " & frmContenedorMDI.oLote._idlote, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto)

            'inicializamos los datos 
            If Not IsNothing(frmContenedorMDI.oDocumento) Then frmContenedorMDI.oDocumento = Nothing
            If Not IsNothing(frmContenedorMDI.oFuncionAplicacion) Then frmContenedorMDI.oFuncionAplicacion = Nothing
            If Not IsNothing(frmContenedorMDI.oLote) Then frmContenedorMDI.oLote = Nothing
            If Not IsNothing(frmContenedorMDI.oProyecto) Then frmContenedorMDI.oProyecto = Nothing

            Me.Close()

        Else
            MessageBox.Show("no se ha podido cerrar el lote consulte con el encargado  ")
        End If


    End Sub

    Private Sub frmCorreccionEpidemiologia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub


    ''' <summary>
    ''' PERSISTENCIA MODIFICACIONES CORRECCION INDIZACION 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Function persistirLogModificacionesPAED(ByVal iddocumento As String, ByVal campoModificacio As String, ByVal valorini As String, ByVal valorfin As String)

        Dim strSQl As String = "INSERT INTO LOGCORRECCIONPAED (iddocumento,campomodificado,valorinicial,valorfinal,usuario) VALUES  (" & iddocumento & ",'" & campoModificacio & "','" & valorini & "','" & valorfin & "','" & frmContenedorMDI.oUsuario._id.ToString & "' )"
        If datos.ejecutaSQLEjecucion(strSQl, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto) Then
            Return True
        Else
            Return False
        End If

    End Function



    Private Sub DataGridView1_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.RowEnter
        Try
            Dim rutaImagen As String = Me.rutaImagenes & "\" & Me.DataGridView1.Rows(e.RowIndex).Cells("nomarchivotif").Value
            Me.mostrarImagen(rutaImagen)
        Catch ex As Exception
            MessageBox.Show("Error al cargar la imagen " + ex.ToString)
        End Try
    End Sub
End Class