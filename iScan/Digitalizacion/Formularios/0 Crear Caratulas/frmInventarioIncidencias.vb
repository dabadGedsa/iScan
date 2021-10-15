Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports datosSQL = LibreriaCadenaProduccion.Datos.GeneralSQL.clsAccesoDatosSQL
Imports GenCode128
Imports accesodatos = LibreriaCadenaProduccion.Datos.GeneralSQL.clsAccesoDatosSQL
Imports System.IO


Public Class frmInventarioHistoriasSinSIPNIF

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

    Private Sub frmInventarioHistoriasSinSIPNIF_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim servicio As LibreriaCadenaProduccion.Entidades.ClsServicio
        Dim estados As clsEstado

        'inicializar el combo con los servicios 

        For Each registro As DataRow In accesodatos.ejecutarSQLDirectaTable("SELECT  [idServicio],[Abreviatura] FROM [produccionvgdiario].[dbo].[SERVICIOS]", cadenaconexioncaratulas).Rows

            servicio = New LibreriaCadenaProduccion.Entidades.ClsServicio(registro.Item("idServicio"), registro.Item("Abreviatura"))
            Me.cmbServicios.Items.Add(servicio)

        Next

        'estados = New clsEstado

        For Each registro As DataRow In accesodatos.ejecutarSQLDirectaTable("SELECT  [idestado],[descripcion] FROM [produccionvgdiario].[dbo].[ESTADOSINCIDENCIA]", cadenaconexioncaratulas).Rows

            estados = New clsEstado(registro.Item("idestado"), registro.Item("descripcion"))
            Me.cmbEstado.Items.Add(estados)

        Next


    End Sub




    Private Sub CtrlBotonMediano2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CtrlBotonMediano2.eClick
        Dim parametros As New Collection
        Dim elemento As elementoBusqueda = Nothing



        elemento = leerParametroEntrada(Me.txtNumhistoria, "Numhistoria", 0, 0)
        If Not IsNothing(elemento.valor) Then parametros.Add(elemento)
        elemento = Nothing

        elemento = leerParametroEntrada(Me.txtNumcaja, "Numcaja", 1, 0)
        If Not IsNothing(elemento.valor) Then parametros.Add(elemento)
        elemento = Nothing

        elemento = leerParametroEntrada(Me.cmbEstado, "EstadoIncidencia", 1, 0)
        If Not IsNothing(elemento.valor) Then parametros.Add(elemento)
        elemento = Nothing

        elemento = leerParametroEntrada(Me.cmbServicios, "servicio", 1, 0)
        If Not IsNothing(elemento.valor) Then parametros.Add(elemento)
        elemento = Nothing

        Call obtenerResultadosBusqueda(parametros)

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


    Private Sub obtenerResultadosBusqueda(ByVal param As Collection)


        Try


            'MUY IMPORTANTE 
            'para que funcione bien la funcion de busqueda si no se ha seleccionado ningún parametro para 
            'la consulta tendremos que liberar el espacio de memoria del vector parametros para la 
            'funcon seleccionDocumentos detecte que no hay ningún parámetro 
            If param.Count = 0 Then param = Nothing

            Application.DoEvents()

            'inicializar el listview de los documentos

            If Me.DataGridView2.Rows.Count > 0 Then
                '  Me.DataGridView2.Rows.Clear()
            Else
                Me.DataGridView2.Refresh()
            End If



            seleccionHistorias(Me.DataGridView2, param)

            Me.DataGridView2.Refresh()
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
                strSQL = "SELECT [NumHistoria],[Servicio],[idIncidencia],[NumCaja],[EstadoIncidencia]FROM [produccionvgdiario].[dbo].[INCIDENCIASSIP]"

            Else
                strSQL = "SELECT [NumHistoria],[Servicio],[idIncidencia],[NumCaja],[EstadoIncidencia]FROM [produccionvgdiario].[dbo].[INCIDENCIASSIP] WHERE "
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

            Me.DataGridView2.DataSource = datosSQL.ejecutarSQLDirectaTable(strSQL, "Data Source=kroniko;Initial Catalog=PRODUCCIONVGDIARIO ;User ID=sa;password=sa2003")

        Catch ex As Exception
            MessageBox.Show("Error " & ex.Message.ToString)
        End Try



    End Sub



 


    Private Sub CtrlBotonMediano1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CtrlBotonMediano1.eClick


        For Each Control As System.Windows.Forms.Control In Me.GroupBox1.Controls


            Select Case Control.GetType.ToString

                Case "System.Windows.Forms.TextBox"

                    Control.Text = ""

                Case "System.Windows.Forms.ComboBox"


                    Control.Text = ""


            End Select

        Next


    End Sub




    Private Sub Insertar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

    End Sub

    Private Sub modificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

    End Sub
End Class