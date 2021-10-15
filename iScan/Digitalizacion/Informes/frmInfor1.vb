Public Class frmInfor1

    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim pp As New dts_cabecera

        Dim fecha_alta As String = "04/04/2006"
        Dim fecha_ingreso As String = "02/04/2006"
        Dim servicio As String = "GIN"
        Dim episodio As String = "2006002065"
        Dim codigo_barras As String = "09091241"
        Dim nombre_paciente As String = "ALIAGA ORTOLA, CRISTINA"
        Dim nhc As String = "091241"
        Dim hospital As String = "HOSPITAL VIRGEN DE LA VEGA"

        pp.Tables(0).Rows.Add(fecha_alta, fecha_ingreso, servicio, episodio, codigo_barras, nombre_paciente, nhc, hospital)

        ' Dim informe As New rpt_cabecera
        'informe.SetDataSource(pp)

        'CrystalReportViewer1.ReportSource = informe
    End Sub

    Private Sub frmInfor1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class