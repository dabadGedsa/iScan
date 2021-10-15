Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports datosSQL = LibreriaCadenaProduccion.Datos.GeneralSQL.clsAccesoDatosSQL
Imports GenCode128
Imports accesodatos = LibreriaCadenaProduccion.Datos.GeneralSQL.clsAccesoDatosSQL
Imports System.IO


Public Class frmConsultarEstadosCartulas

    'estrucutura utilizada para crear la consulta de busqueda 
    Public Structure elementoBusqueda
        Public Nombre As String
        Public valor As String
        Public valor2 As String
        Public texto As Integer
        Public Fecha As Integer
        'rangofecha sera 0 no 1 es rango 2 anterior 3 posterior
        Public RangoFecha As Integer
    End Structure


    Dim cadenaconexioncaratulas As String = "Data Source=kroniko;Initial Catalog=PRODUCCIONVGDIARIO ;User ID=sa;password=sa2003"

    Private Sub frmConsultarEstadosCartulas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim servicio As LibreriaCadenaProduccion.Entidades.ClsServicio

        'inicializar el combo con los servicios 

        For Each registro As DataRow In accesodatos.ejecutarSQLDirectaTable("SELECT  [idServicio],[Abreviatura] FROM [produccionvgdiario].[dbo].[SERVICIOS]", cadenaconexioncaratulas).Rows


            servicio = New LibreriaCadenaProduccion.Entidades.ClsServicio(registro.Item("idServicio"), registro.Item("Abreviatura"))
            Me.cmbServicios.Items.Add(servicio)


        Next

    End Sub


    Private Sub CrystalReportViewer2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer2.Load
        Dim reporte As New crpPeticiones

        Me.CrystalReportViewer2.ReportSource = reporte
        Me.CrystalReportViewer2.Zoom(2)


    End Sub


    Private Sub CtrlBotonMediano2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CtrlBotonMediano4.eClick

        Dim parametros As New Collection
        Dim elemento As elementoBusqueda = Nothing
        Dim faltandatos As Boolean = False
        Dim strsql As String
        Dim datosporcumplimentar As String = ""


        If Me.txtSIP.Text = "" Then
            datosporcumplimentar = " sip "
            faltandatos = True
        End If

        If cmbServicios.Text = "" Then
            datosporcumplimentar = " servicio "
            faltandatos = True
        End If

        If dtpFechaCita.Text = Date.Today Then
            datosporcumplimentar = " FechaCita "
            faltandatos = True
        End If


        If Not faltandatos Then

            strsql = "INSERT INTO  PETICIONESDIARIAS ([FechaCita],[servicio],[SIP]) VALUES ('" & Me.dtpFechaCita.Text & "','" & Me.cmbServicios.Text & "','" & Me.txtSIP.Text & "')"
            accesodatos.ejecutarSQLDirecta(strsql, cadenaconexioncaratulas)

        Else
            MessageBox.Show("Faltan datos por cumplimentar " & datosporcumplimentar)
        End If




        Call obtenerResultadosBusqueda(Me.dtpFechaCita.Text, Me.txtSIP.Text, Me.cmbServicios.Text)

    End Sub


    Private Sub obtenerResultadosBusqueda(ByVal fechaCita As String, ByVal sip As String, ByVal servicio As String)

        Dim datosPeticiones As DataTable
        Dim strsql As String

        strsql = "select * from PETICIONESDIARIAS  where Left(Convert(varchar, fechacita, 103), 10)  =  '" & fechaCita & "' order by servicio "
        datosPeticiones = accesodatos.ejecutarSQLDirectaTable(strsql, cadenaconexioncaratulas)


        Me.DataGridView2.DataSource = datosPeticiones
        Me.DataGridView2.Refresh()

    End Sub



    Private Sub CtrlBotonMediano3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CtrlBotonMediano3.eClick
        Dim cr As New crpPeticiones
        Dim informe As New DatosPeticiones
        Dim tablaInforme As DataTable = informe.Tables(0)

        Dim sip As String
        Dim servicio As String
        Dim encontrada As String
        Dim numcaja As Integer
        Dim preparada As String
        Dim digitalizada As String
        Dim entregada As String
        Dim fechacita As String
        Dim idlote As Integer
        Dim datos As DataTable
        Dim datos2 As DataTable
        Dim datos3 As DataTable
        Dim datos4 As DataTable
        Dim datos5 As DataTable

        Try




            'cabeceraCodigoBarras = accesodatos.ponerCaracterEnBlanco(accesodatos.ejecutarSQLDirectaDataRow("SELECT inicioBarcode FROM  configuracionBarcode where idproyecto = 6906", My.Settings.cadenaConexion).Item(0))
            If Me.DataGridView2.Rows.Count = 0 Then
                MessageBox.Show("No han seleccionado ninguna petición para consultar el estado.")
                Exit Sub
            End If



            'Creamos la caratual para cada uno de los datos de la consulta 
            For Each registro As DataRow In CType(Me.DataGridView2.DataSource, DataTable).Rows


                fechacita = registro.Item(0)
                sip = registro.Item(2)
                servicio = registro.Item(1)

                'vamos a ver si esta buscada y si la encontramos en que caja esta 
                datos = accesodatos.ejecutarSQLDirectaTable("SELECT  [NO ENCONTRADA],[NUMCAJA] FROM [produccionvgdiario].[dbo].[LISTADOSBUSQUEDAPORESPECIALIDAD] where [SERVICIO] like '%" & servicio & "%'and [SIP] = " & sip, cadenaconexioncaratulas)

                If datos.Rows.Count > 0 Then
                    Try


                        Debug.Print(datos.Rows(0).Item("NUMCAJA").ToString)

                        encontrada = datos.Rows(0).Item("NO ENCONTRADA").ToString
                        If encontrada.ToLower = "false" Then
                            encontrada = "Encontrada"

                        End If

                        Try
                            numcaja = datos.Rows(0).Item("NUMCAJA").ToString
                        Catch ex As Exception
                            'esto es por si el numero de caja no es un numero
                            numcaja = 0
                        End Try

                        If encontrada.ToLower = "true" Then
                            encontrada = "NO enc"
                            numcaja = 0
                        End If

                    Catch ex As Exception
                        encontrada = "-"
                        numcaja = 0
                    End Try
                Else
                    encontrada = " Sin listado"
                    numcaja = 0
                End If

                Debug.Print("select * from [produccionvgdiario].[dbo].[FIP] where sip = '%" & sip & "%' and servicio like '%" & servicio & "%' and fechainicio is not null  and fechatermino is not null")
                datos2 = accesodatos.ejecutarSQLDirectaTable("select * from [produccionvgdiario].[dbo].[FIP] where sip like '%" & sip & "%' and servicio like '%" & servicio & "%' and fechainicio is not null  and fechatermino is not null", cadenaconexioncaratulas)

                If datos2.Rows.Count > 0 Then

                    preparada = "Si"
                Else
                    preparada = "No"
                End If



                datos3 = accesodatos.ejecutarSQLDirectaTable("select * from [produccionvgdiario].[dbo].[FIP] f,[produccionvgdiario].[dbo].[documentos] d where  f.numhistoria = d.numhistoria and f.sip like '%" & sip & "%'  and f.servicio = d.codservicioubicado and f.servicio like '%" & servicio & "%' ", cadenaconexioncaratulas)

                If datos3.Rows.Count > 0 Then
                    digitalizada = "si"
                Else
                    digitalizada = "No"
                End If

                idlote = 0
                If digitalizada = "si" Then
                    datos5 = accesodatos.ejecutarSQLDirectaTable("select d.idlote  from [produccionvgdiario].[dbo].[documentos]d,[produccionvgdiario].[dbo].[FIP] f  where   d.codservicioubicado = f.servicio and d.numhistoria = f.numhistoria and d.codservicioubicado like '%" & servicio & "%' and f.sip like '" & sip & "'", cadenaconexioncaratulas)
                    idlote = datos5.Rows(0).Item(0)

                End If

                datos4 = accesodatos.ejecutarSQLDirectaTable("select *  from [produccionvgdiario].[dbo].[documentos]d,[produccionvgdiario].[dbo].[FIP] f ,[produccionvgdiario].[dbo].[lotesDVD] l where  d.idlote = l.idlote   and d.codservicioubicado = f.servicio and d.numhistoria = f.numhistoria and d.codservicioubicado like '%" & servicio & "%' and f.sip like '" & sip & "'", cadenaconexioncaratulas)


                If datos4.Rows.Count > 0 Then
                    entregada = "si"
                Else
                    entregada = "No"
                End If

                tablaInforme.Rows.Add(sip, servicio, encontrada, numcaja, preparada, digitalizada, entregada, idlote)
            Next


            cr.SetDataSource(tablaInforme)

            CrystalReportViewer2.ReportSource = cr

            CrystalReportViewer2.Zoom(1)





        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

    End Sub






    Public Shared Function ImageToByte(ByVal img As Image) As Byte()
        Dim sTemp As String = Path.GetTempFileName()
        Dim fs As New System.IO.FileStream(sTemp, FileMode.OpenOrCreate, FileAccess.ReadWrite)
        img.Save(fs, System.Drawing.Imaging.ImageFormat.Png)
        fs.Position = 0
        '
        Dim imgLength As Integer = CInt(fs.Length)
        Dim bytes(0 To imgLength - 1) As Byte
        fs.Read(bytes, 0, imgLength)
        fs.Close()
        Return bytes



    End Function


    Private Sub CtrlBotonMediano1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)


        For Each Control As System.Windows.Forms.Control In Me.GroupBox1.Controls


            Select Case Control.GetType.ToString

                Case "System.Windows.Forms.TextBox"

                    Control.Text = ""

                Case "System.Windows.Forms.ComboBox"


                    Control.Text = ""


            End Select

        Next


    End Sub


    Private Sub CtrlBotonMediano4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CtrlBotonMediano4.eClick

    End Sub


    Private Sub dtpFechaCita_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFechaCita.ValueChanged
        Call obtenerResultadosBusqueda(Me.dtpFechaCita.Text, Me.txtSIP.Text, Me.cmbServicios.Text)
    End Sub
End Class