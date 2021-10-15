Imports System.Data.SqlClient
Imports System.Data
Imports accesoDatos = LibreriaCadenaProduccion.Datos.GeneralSQL.clsAccesoDatosSQL
Imports datosSQL = LibreriaCadenaProduccion.Datos.GeneralSQL.clsAccesoDatosSQL


Public Class frmBuscarDatosFIPBD


    Public Sub New(ByVal cadenaconexion As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        Me.cadenaconexion = cadenaconexion
    End Sub

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



    Private cadenaconexion As String

    Private Sub frmBuscarDatosFIPBD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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




    Private Sub CtrlBotonInsertarRegistro2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)



        Dim strSQL As String
        Dim conexion As SqlConnection = Nothing
        Dim comando As SqlCommand
        Dim MyTrans As SqlTransaction = Nothing
        Dim correcto As Boolean = True


        Dim fechanacimiento, servicio As String
        Dim fechaInicio As String

        'determinar los campos obligatorios 

        If Me.txtNumhistoria.Text = "" Then
            MessageBox.Show("ERROR, no se puede actualizar los datos, para crear un registro es obligatorio introducir un numero de historia ")
            Exit Sub
        End If

        fechaInicio = accesoDatos.PonerNulo(Me.txtFechaInicio.Text)
        servicio = accesoDatos.PonerNulo(Me.cmbServicios.Text)



        Try


            conexion = New SqlConnection(cadenaconexion)
            conexion.Open()

            MyTrans = conexion.BeginTransaction()

            strSQL = "Insert into FIP (NumHistoria,servicio,FechaInicio) values ('" & Me.txtNumhistoria.Text & "'," & servicio & "," & fechaInicio & ")"
            comando = New SqlCommand(strSQL, conexion)
            comando.Transaction = MyTrans
            comando.ExecuteNonQuery()


            strSQL = "Insert into FIPINSERTADOS (NumHistoria,idusuario) values ('" & Me.txtNumhistoria.Text & "','" & frmContenedorMDI.oUsuario._id & "')"
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

        Dim cadenaBasedatosDestino As String = "Data Source=kroniko;Initial Catalog=PRODUCCIONVGDIARIO ;User ID=sa;password=cd2009g3"
        Dim datosoriginales As DataTable


        Dim strSQL As String = "SELECT top 1  numhistoria FROM [produccionvgdiario].[dbo].[FIP] order by numhistoria desc"

        datosoriginales = accesoDatos.ejecutarSQLDirectaTable(strSQL, cadenaBasedatosDestino)


        Me.txtNumhistoria.Text = datosoriginales.Rows(0).Item(0) + 1

    End Sub





    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim parametros As New Collection
        Dim elemento As elementoBusqueda = Nothing
        Dim datos3 As DataTable
        Dim registro As DataRow
        Dim datos5 As DataTable


        elemento = leerParametroEntrada(Me.txtNumhistoria, "Numhistoria", 0, 0)
        If Not IsNothing(elemento.valor) Then parametros.Add(elemento)
        elemento = Nothing




        elemento = leerParametroEntrada(Me.txtFechaInicio, "fechaInicio", 1, 1)
        If Not IsNothing(elemento.valor) Then parametros.Add(elemento)
        elemento = Nothing


        'elemento = leerParametroEntrada(Me.txtt, "telefono", 1, 0)
        'If Not IsNothing(elemento.valor) Then parametros.Add(elemento)
        'elemento = Nothing


        elemento = leerParametroEntrada(Me.cmbServicios, "servicio", 1, 0)
        If Not IsNothing(elemento.valor) Then parametros.Add(elemento)
        elemento = Nothing

        Call obtenerResultadosBusqueda(parametros)

        'si obtenemos un solo registro vamos a consultar el estado de la historia

    End Sub


    Private Sub obtenerResultadosBusqueda(ByVal param As Collection)


        Try


            'MUY IMPORTANTE 
            'para que funcione bien la funcion de busqueda si no se ha seleccionado ningún parametro para 
            'la consulta tendremos que liberar el espacio de memoria del vector parametros para la 
            'funcon seleccionDocumentos detecte que no hay ningún parámetro 
            If param.Count = 0 Then param = Nothing

            Application.DoEvents()

            'inicializar el listview de los documentos

            If Me.DataGridView1.Rows.Count > 0 Then
                '  Me.DataGridView2.Rows.Clear()
            Else
                Me.DataGridView1.Refresh()
            End If



            seleccionHistorias(Me.DataGridView1, param)

            Me.DataGridView1.Refresh()
            Application.DoEvents()

        Catch ex As Exception
            MessageBox.Show("Error " & ex.Message)
        End Try

    End Sub



    Private Sub seleccionHistorias(ByRef resultados As DataGridView, ByVal parametros As Collection)

        Dim dtDocumentos As New DataTable
        Dim strSQL As String


        Dim contador As Integer = 0
        Dim cont As Integer = 0
        Dim algunaCoincidencia As Integer = 0
        Dim año As String

        Try


            If IsNothing(parametros) = True Then 'no hay parametros para la busqueda, lo seleccionamos absolutamente todo 
                ' 
                strSQL = "SELECT [NumHistoria],[FechaInicio],[servicio],[identificador] FROM [produccionvgdiario].[dbo].[FIP]"

            Else
                strSQL = "SELECT [NumHistoria],[FechaInicio],[servicio],[identificador] FROM [produccionvgdiario].[dbo].[FIP] WHERE "
                'iniciamos el recorrido del vector para añadir parametros a la busqueda 

                For Each item As elementoBusqueda In parametros

                    If cont = 0 Then 'solo hay un parametro para la busqueda y no hay que poner un and 

                        If item.texto = 0 Then 'el parametro que introduciomos es un entero 
                            strSQL = strSQL & item.Nombre & " = " & item.valor
                        Else
                            If item.Fecha = 0 Then 'el parametro que introduciomos es texto 
                                strSQL = strSQL & item.Nombre & " like '%" & item.valor & "%' "
                            Else 'el parametro que introduciomos es una fecha
                                If IsNothing(item.RangoFecha) = False Then
                                    Select Case item.RangoFecha
                                        'las instrucciones comentadas son las correctas para un servidor SQL 
                                        Case 0 'igual 
                                            strSQL = strSQL & " Left(Convert(varchar, " & item.Nombre & ", 103), 10)  = '" & item.valor & "' "
                                            'strSQL = strSQL & " date( " & item.Nombre & ") = '" & Mid(item.valor, 7, 4) & "-" & Mid(item.valor, 4, 2) & "-" & Mid(item.valor, 1, 2) & "'"
                                        Case 1 'entre
                                            'strSQL = strSQL & " Left(Convert(varchar, " & item.Nombre & ", 103), 10)  >= '" & item.valor & "' and"
                                            'strSQL = strSQL & " Left(Convert(varchar, " & item.Nombre & ", 103), 10)  <= '" & item.valor2 & "'"
                                            strSQL = strSQL & " date( " & item.Nombre & ") >= '" & Mid(item.valor, 7, 4) & "-" & Mid(item.valor, 4, 2) & "-" & Mid(item.valor, 1, 2) & "' and "
                                            strSQL = strSQL & " date( " & item.Nombre & ") <= '" & Mid(item.valor2, 7, 4) & "-" & Mid(item.valor2, 4, 2) & "-" & Mid(item.valor2, 1, 2) & "'"
                                        Case 2 'anterior
                                            'strSQL = strSQL & " Left(Convert(varchar, " & item.Nombre & ", 103), 10) <= '" & item.valor & "'"
                                            strSQL = strSQL & " date( " & item.Nombre & ") <= '" & Mid(item.valor, 7, 4) & "-" & Mid(item.valor, 4, 2) & "-" & Mid(item.valor, 1, 2) & " '"
                                        Case 3 'posterior
                                            'strSQL = strSQL & " Left(Convert(varchar, " & item.Nombre & ", 103), 10) >= '" & item.valor & "'"
                                            strSQL = strSQL & " date( " & item.Nombre & ") >= '" & Mid(item.valor, 7, 4) & "-" & Mid(item.valor, 4, 2) & "-" & Mid(item.valor, 1, 2) & " '"
                                    End Select
                                Else
                                    strSQL = strSQL & " LEFT(CONVERT(varchar," & item.Nombre & ",103),10) = '" & item.valor & "'"
                                End If

                            End If
                        End If
                        cont += 1 'incrementamos el contador para indicar que hay más de un parámetro 
                    Else 'hay mas de un parametro para la busqueda
                        If item.texto = 0 Then
                            strSQL = strSQL & " and " & item.Nombre & " = " & item.valor
                        Else
                            If item.Fecha = 0 Then
                                strSQL = strSQL & " and " & item.Nombre & " like '%" & item.valor & "%'"
                            Else
                                If IsNothing(item.RangoFecha) = False Then
                                    Select Case item.RangoFecha
                                        'las instrucciones comentadas son las correctas para un servidor SQL 
                                        Case 0 'igual 
                                            strSQL = strSQL & " and " & " Left(Convert(varchar, " & item.Nombre & ", 103), 10)  = '" & item.valor & "' "
                                            'strSQL = strSQL & " and date( " & item.Nombre & ") = '" & Mid(item.valor, 7, 4) & "-" & Mid(item.valor, 4, 2) & "-" & Mid(item.valor, 1, 2) & "'"
                                        Case 1 'entre
                                            'strSQL = strSQL & " Left(Convert(varchar, " & item.Nombre & ", 103), 10)  >= '" & item.valor & "' and"
                                            'strSQL = strSQL & " Left(Convert(varchar, " & item.Nombre & ", 103), 10)  <= '" & item.valor2 & "'"
                                            strSQL = strSQL & " and date( " & item.Nombre & ") >= '" & Mid(item.valor, 7, 4) & "-" & Mid(item.valor, 4, 2) & "-" & Mid(item.valor, 1, 2) & "' and "
                                            strSQL = strSQL & " date( " & item.Nombre & ") <= '" & Mid(item.valor2, 7, 4) & "-" & Mid(item.valor2, 4, 2) & "-" & Mid(item.valor2, 1, 2) & "'"
                                        Case 2 'anterior
                                            'strSQL = strSQL & " Left(Convert(varchar, " & item.Nombre & ", 103), 10) <= '" & item.valor & "'"
                                            strSQL = strSQL & " and date( " & item.Nombre & ") <= '" & Mid(item.valor, 7, 4) & "-" & Mid(item.valor, 4, 2) & "-" & Mid(item.valor, 1, 2) & " '"
                                        Case 3 'posterior
                                            'strSQL = strSQL & " Left(Convert(varchar, " & item.Nombre & ", 103), 10) >= '" & item.valor & "'"
                                            strSQL = strSQL & " and date( " & item.Nombre & ") >= '" & Mid(item.valor, 7, 4) & "-" & Mid(item.valor, 4, 2) & "-" & Mid(item.valor, 1, 2) & " '"
                                    End Select
                                End If
                            End If
                        End If
                    End If

                Next

            End If



            strSQL = strSQL & " order by numhistoria"

            Debug.Print(strSQL)

            Me.DataGridView1.DataSource = datosSQL.ejecutarSQLDirectaTable(strSQL, "Data Source=kroniko;Initial Catalog=PRODUCCIONVGDIARIO ;User ID=sa;password=sa2003")

            If Not IsNothing(Me.DataGridView1.Columns("identificador")) Then
                Me.DataGridView1.Columns("identificador").Visible = False
            End If

        Catch ex As Exception
            MessageBox.Show("Error " & ex.Message.ToString)
        End Try



    End Sub

    Private Function leerParametroEntrada(ByVal control As System.Windows.Forms.TextBox, ByVal nombreColTablaBD As String, ByVal texto As Integer, ByVal fecha As Integer)

        Dim elemento As elementoBusqueda

        If control.Text <> "" Then
            With elemento
                .Nombre = nombreColTablaBD
                .valor = control.Text
                .texto = texto
                .Fecha = fecha
            End With
            Return elemento
        Else
            Return Nothing
        End If

    End Function


    Private Function leerParametroEntrada(ByVal control As System.Windows.Forms.ComboBox, ByVal nombreColTablaBD As String, ByVal texto As Integer, ByVal fecha As Integer)

        Dim elemento As elementoBusqueda

        If Not IsNothing(control.SelectedItem) And control.Text <> "" Then
            With elemento
                .Nombre = nombreColTablaBD
                .valor = control.SelectedItem.ToString
                .texto = texto
                .Fecha = fecha
            End With
            Return elemento
        Else
            Return Nothing
        End If

    End Function


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        For Each Control As System.Windows.Forms.Control In Me.GroupBox1.Controls


            Select Case Control.GetType.ToString

                Case "System.Windows.Forms.TextBox"

                    Control.Text = ""

                Case "System.Windows.Forms.ComboBox"


                    Control.Text = ""


            End Select

        Next
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub
End Class