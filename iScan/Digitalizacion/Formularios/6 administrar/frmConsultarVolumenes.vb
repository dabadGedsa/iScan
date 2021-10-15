
Imports datosSQL = LibreriaCadenaProduccion.Datos.GeneralSQL.clsAccesoDatosSQL

Public Class frmConsultarVolumenes

    Private cadenaconexionproyecto As String

    Public Sub New(ByVal cadenaconexion As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.cadenaconexionproyecto = cadenaconexion

    End Sub


    Private Sub frmConsultarVolumenes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.DataGridView1.DataSource = datosSQL.ejecutarSQLDirectaTable("SELECT lv.idlote AS LOTE, l.nombre AS VOLUMEN, l.fechaCreacion  FROM   LOTESVOLUMEN lv INNER JOIN VOLUMEN l ON lv.idVolumen = l.idVolumen", cadenaconexionproyecto)


    End Sub
End Class