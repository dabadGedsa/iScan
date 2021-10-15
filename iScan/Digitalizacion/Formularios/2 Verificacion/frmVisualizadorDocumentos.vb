
Imports libreriacadenaproduccion.Datos.GeneralSQL

Public Class frmVisualizadorDocumentos

    '#Region "Variables de principal"
    '    'Dim hospital as
    '    Dim hospital As String = "26"

    '    Dim lote_numero As String = "8"
    '    Dim lote_fecha As String = "16/05/2008"
    '    Dim lote_tipo As String = "N1B"

    '    Dim proyecto_numero As String = "9999"

    '    Dim oConfiguracion As DataTable


    '#End Region

    '#Region "Eventos de GRID"


    '    Sub actualizaImagen()


    '    End Sub

    '    Private Sub DataGridView1_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.RowEnter

    '        'Actualizamos la foto de la imagen

    '        actualizaImagen()

    '    End Sub

    '    Private Sub DataGridView1_RowPrePaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles DataGridView1.RowPrePaint

    '        Try
    '            Dim theRow As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
    '            If theRow.Cells("Incidencia").Value.ToString() = "1" AndAlso theRow.Cells("IncidenciaHist").Value.ToString() = "1" Then theRow.DefaultCellStyle.BackColor = Color.Honeydew
    '            If theRow.Cells("Incidencia").Value.ToString() = "1" AndAlso theRow.Cells("IncidenciaHist").Value.ToString() = "0" Then theRow.DefaultCellStyle.BackColor = Color.MistyRose
    '        Catch ex As Exception

    '        End Try

    '    End Sub

    '    ''' <summary>
    '    ''' Refresco de la grid
    '    ''' </summary>
    '    ''' <remarks></remarks>
    '    'Sub refrescarGrid()

    '    '    Dim sql As String = "Select ID,Pagina,ID_lote,NomArchivoTIF,CodigoLote,Incidencia,CorregidoDigi,IncidenciaHist,NumICU,NumHistoria,CodServicioUbicado,VerificadoDigi,BarcodeDet,Insertado from Documentos where Hospital=" & hospital & " and CodigoLote=" & lote_numero & " and FechaLote='" & lote_fecha & "' and Tipolote='" & lote_tipo & "' and Proyecto='" & proyecto_numero & "'"
    '    '    Dim dt As DataTable = clsAccesoDatosSQL.consultaDatatable(sql, My.Settings.cadenaConexion)
    '    '    DataGridView1.DataSource = dt

    '    '    'Ocultamos las columnas que no se tengan que ver
    '    '    DataGridView1.Columns("ID").Visible = False

    '    'End Sub

    '#End Region

    '    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

    '        Dim sql As String = "Select ID,Pagina,ID_lote,NomArchivoTIF,CodigoLote,Incidencia,CorregidoDigi,IncidenciaHist,NumICU,NumHistoria,CodServicioUbicado,VerificadoDigi,BarcodeDet,Insertado from Documentos where Hospital=" & hospital & " and CodigoLote=" & lote_numero & " and FechaLote='" & lote_fecha & "' and Tipolote='" & lote_tipo & "' and Proyecto='" & proyecto_numero & "' order by Pagina ASC"
    '        Dim dt As DataTable = clsAccesoDatosSQL.consultaDatatable(sql, My.Settings.cadenaConexion)

    '        DataGridView1.DataSource = dt

    '        'DataGridView1.Item(0,
    '    End Sub

    '    Private Sub frmVisualizadorDocumentos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    '        'Primero cargamos la configuracion que previamente se tendria que cargar en otra pantalla
    '        oConfiguracion = clsAccesoDatosSQL.consultaDatatable("SELECT * from configuracion WHERE proyecto='" & proyecto_numero & "'", My.Settings.cadenaConexion)

    '        If oConfiguracion.Rows.Count > 0 Then
    '            refrescarGrid()
    '        Else
    '            MsgBox("No se pudo cargar la configuración referente al proyecto: " & proyecto_numero, MsgBoxStyle.Critical, "Incidencia de aplicacion")
    '        End If


    '    End Sub

    '    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    '    End Sub

    Private Sub DataGridView1_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.RowEnter

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click

    End Sub

    Private Sub frmVisualizadorDocumentos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub StatusStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles StatusStrip1.ItemClicked

    End Sub
End Class