Imports accesoDatos = LibreriaCadenaProduccion.Datos.GeneralSQL.clsAccesoDatosSQL
Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient


Public Class frmEditarFIP


    Public Sub New(ByVal idregistro As Integer, ByVal cadenaconexionCatalogarlo As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.idRegistro = idregistro
        Me.cadenaconexion = cadenaconexionCatalogarlo


    End Sub

    Dim idRegistro As Integer
    Dim cadenaconexion As String



    Private Sub frmEditarFIP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inicizalizar_datos()
    End Sub



    Private Sub inicizalizar_datos()

        Dim dr As DataRow 'datos registro 1
        Dim abrevServicio As String
        Dim servicio As LibreriaCadenaProduccion.Entidades.ClsServicio


        dr = accesoDatos.ejecutarSQLDirectaDataRow("SELECT  [NumHistoria],[FechaInicio],[servicio] FROM [FIP] WHERE identificador = " & idRegistro, cadenaconexion)


        Me.txtNumhistoria.Text = accesoDatos.ponerCaracterEnBlanco(dr.Item("NumHistoria"))
        Me.txtFechaInicio.Text = accesoDatos.ponerCaracterEnBlanco(dr.Item("fechainicio"))
        abrevServicio = accesoDatos.ponerCaracterEnBlanco(dr("Servicio"))


        For Each registro As DataRow In accesoDatos.ejecutarSQLDirectaTable("SELECT  [idServicio],[Abreviatura] FROM [produccionvgdiario].[dbo].[SERVICIOS] order by [Abreviatura]", cadenaconexion).Rows


            servicio = New LibreriaCadenaProduccion.Entidades.ClsServicio(registro.Item("idServicio"), registro.Item("Abreviatura"))
            Me.cmbServicios.Items.Add(servicio)

            If Trim(abrevServicio) = servicio._codServicio Then
                Me.cmbServicios.SelectedItem = servicio
            End If

        Next



    End Sub



    Private Sub CtrlBotonModificarDatos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CtrlBotonMediano2.eClick

        Dim ListaValores As String = ""
        Dim condiciones As String = "identificador = " & idRegistro

        Dim strSQL As String
        Dim conexion As SqlConnection = Nothing
        Dim comando As SqlCommand
        Dim MyTrans As SqlTransaction = Nothing
        Dim correcto As Boolean = True


        ListaValores = "Numhistoria = '" & Me.txtNumhistoria.Text & "'"
        ListaValores = ListaValores & ", fechaInicio = '" & Me.txtfechainicio.Text & "'"
        ListaValores = ListaValores & ",servicio ='" & Me.cmbServicios.Text & "'"



        Try


            conexion = New SqlConnection(cadenaconexion)
            conexion.Open()

            MyTrans = conexion.BeginTransaction()

            strSQL = "update FIP SET " & ListaValores & "  WHERE " & condiciones
            comando = New SqlCommand(strSQL, conexion)
            comando.Transaction = MyTrans
            comando.ExecuteNonQuery()


            strSQL = "Insert into FIPmodificados (identificador,NumHistoria,idusuario) values ('" & Me.idRegistro & "','" & Me.txtNumhistoria.Text & "'," & frmContenedorMDI.oUsuario._id & ")"
            comando = New SqlCommand(strSQL, conexion)
            comando.Transaction = MyTrans
            comando.ExecuteNonQuery()


            MyTrans.Commit()

        Catch ex As SqlException
            MessageBox.Show("ERROR los datos no se han modificado, compruebe que los datos introducidos son correctos ." & ex.Message.ToString, "ERROR")

            If Not IsNothing(MyTrans) Then
                MyTrans.Rollback()
            End If

            correcto = False
        Finally
            If conexion.State = ConnectionState.Open Then
                conexion.Close()
            End If

        End Try

        If correcto Then
            MessageBox.Show("Los datos han sido modificados correctamente")
            Me.Close()
        End If




    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim cadenaBasedatosDestino As String = "Data Source=kroniko;Initial Catalog=PRODUCCIONVGDIARIO ;User ID=sa;password=sa2003"
        Dim datosoriginales As DataTable


        Dim strSQL As String = "SELECT top 1  numhistoria FROM [produccionvgdiario].[dbo].[FIP] order by numhistoria desc"

        datosoriginales = accesoDatos.ejecutarSQLDirectaTable(strSQL, cadenaBasedatosDestino)


        Me.txtNumhistoria.Text = datosoriginales.Rows(0).Item(0) + 1

    End Sub



   
End Class