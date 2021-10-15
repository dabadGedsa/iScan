Imports System.Data.SqlClient
Imports System.Data
Imports accesoDatos = LibreriaCadenaProduccion.Datos.GeneralSQL.clsAccesoDatosSQL



Public Class frmIsertarDatosFIPBD


    Public Sub New(ByVal cadenaconexion As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        Me.cadenaconexion = cadenaconexion
    End Sub


    Private cadenaconexion As String

    Private Sub frmIsertarDatosFIPBD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

        
            Dim servicio As LibreriaCadenaProduccion.Entidades.ClsServicio

            For Each registro As DataRow In accesoDatos.ejecutarSQLDirectaTable("SELECT  [idServicio],[Abreviatura] FROM [produccionvgdiario].[dbo].[SERVICIOS] order by [Abreviatura]", cadenaconexion).Rows


                servicio = New LibreriaCadenaProduccion.Entidades.ClsServicio(registro.Item("idServicio"), registro.Item("Abreviatura"))
                Me.cmbServicios.Items.Add(servicio)


            Next
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

    End Sub




    Private Sub CtrlBotonInsertarRegistro2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CtrlBotonMediano2.eClick



      


    End Sub



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim cadenaBasedatosDestino As String = "Data Source=kroniko;Initial Catalog=PRODUCCIONVGDIARIO ;User ID=sa;password=sa2003"
        Dim datosoriginales As DataTable


        Dim strSQL As String = "SELECT top 1  numhistoria FROM [produccionvgdiario].[dbo].[FIP] order by numhistoria desc"

        datosoriginales = accesoDatos.ejecutarSQLDirectaTable(strSQL, cadenaBasedatosDestino)


        Me.txtNumhistoria.Text = datosoriginales.Rows(0).Item(0) + 1

    End Sub
End Class