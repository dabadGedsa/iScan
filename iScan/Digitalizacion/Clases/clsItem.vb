Imports datos = LibreriaCadenaProduccion.Datos.GeneralSQL.clsAccesoDatosSQL

''' <summary>
''' Esta clase es utilizada para la generacion de formularios dinamica
''' </summary>
''' <remarks></remarks>
Public Class clsItem

    Function contenedor_control_busca(ByRef contenedor As System.Windows.Forms.Control.ControlCollection, ByVal nombre As String) As Control
        'Buscamos en el contenedor el nombre del elmento si no lo encontrma
        Dim control As System.Collections.Generic.List(Of Control) = _
        (From tmp_control As Control In contenedor Where tmp_control.Name.ToLower = nombre.ToLower).ToList

        If control.Count > 0 Then
            Return control(0)
        Else
            Return Nothing
        End If
    End Function

    ''' <summary>
    ''' Obtención de los datos de las tablas
    ''' </summary>
    ''' <param name="contenedor"></param>
    ''' <param name="tabla"></param>
    ''' <param name="condicion"></param>
    ''' <remarks></remarks>
    Sub contenedor_mantenimiento_obtener(ByRef contenedor As System.Windows.Forms.Control.ControlCollection, ByVal tabla As String, ByVal condicion As String, ByVal cadenaConexion As String)

        'Leo todos los objetos y obtengo el valor de la base de datos

        Dim sql_query As String = "SELECT "
        Dim contador As Integer = 0

        'Recorro todos los elementos del panel y segun sea un tipo u otro genero la SQL
        For i As Integer = 0 To contenedor.Count - 1

            Select Case contenedor(i).GetType.FullName
                'Case "System.Windows.Forms.Label"

                Case "System.Windows.Forms.CheckBox", "System.Windows.Forms.ComboBox", "System.Windows.Forms.TextBox", "System.Windows.Forms.DateTimePicker"
                    If contador > 0 Then sql_query &= ", "
                    sql_query &= contenedor(i).Name
                    contador += 1
            End Select

        Next

        sql_query &= " from " & tabla & " " & condicion

        'MsgBox(sql_query)

        Dim dt As DataTable = datos.ejecutarSQLDirectaTable(sql_query, cadenaConexion)
        If dt IsNot Nothing Then
            If dt.Rows.Count > 0 Then

                For i As Integer = 0 To contenedor.Count - 1
                    Try
                        Select Case contenedor(i).GetType.FullName
                            Case "System.Windows.Forms.Label"

                            Case "System.Windows.Forms.CheckBox"
                                CType(contenedor(i), CheckBox).Checked = dt.Rows(i).Item(contenedor(i).Name)
                            Case "System.Windows.Forms.TextBox"
                                contenedor(i).Text = dt.Rows(0).Item(contenedor(i).Name).ToString()
                            Case "System.Windows.Forms.ComboBox"

                            Case "System.Windows.Forms.DateTimePicker"
                                CType(contenedor(i), DateTimePicker).Value = dt.Rows(0).Item(contenedor(i).Name).ToString()

                                'TextBox3.AppendText(dt.Rows(0).Item(contenedor(i).Name).ToString() & vbCrLf)

                        End Select
                        'contenedor(i).Text = dt.Rows(0).Item(contenedor(i).Name).ToString()
                    Catch ex As Exception
                        MsgBox("No existe el cambo '" & contenedor(i).Name & "' en la base de datos, elimine o modifique el control con ese nombre." & vbCrLf, MsgBoxStyle.Critical, "Incidencia de aplicacion")
                    End Try

                Next

            End If
        End If

    End Sub

    Function contenedor_mantenimiento_update(ByRef contenedor As System.Windows.Forms.Control.ControlCollection, ByVal tabla As String, ByVal condicion As String) As String

        Dim sql_query As String = "UPDATE " & tabla & " SET "
        Dim contador As Integer = 0

        'Recorro todos los elementos del panel y segun sea un tipo u otro genero la SQL
        For i As Integer = 0 To contenedor.Count - 1

            Select Case contenedor(i).GetType.FullName

                Case "System.Windows.Forms.DateTimePicker"

                    If contador > 0 Then sql_query &= ", "

                    sql_query &= contenedor(i).Name & " = '" & Format(CType(contenedor(i), DateTimePicker).Value, "dd/MM/yyyy") & "'"
                    contador += 1

                Case "System.Windows.Forms.Label"

                Case "System.Windows.Forms.CheckBox"
                    If contador > 0 Then sql_query &= ", "

                    If CType(contenedor(i), CheckBox).Checked Then
                        sql_query &= contenedor(i).Name & " = '1'"
                    Else
                        sql_query &= contenedor(i).Name & " = '0'"
                    End If
                    contador += 1

                Case "System.Windows.Forms.TextBox"
                    If contador > 0 Then sql_query &= ", "

                    sql_query &= contenedor(i).Name & " = '" & contenedor(i).Text & "'"
                    contador += 1
                Case "System.Windows.Forms.ComboBox"
                    'En el combo box podríamos hacer que cogiera el valor identificativo
                    If contador > 0 Then sql_query &= ", "

                    sql_query &= contenedor(i).Name & " = '" & contenedor(i).Text & "'"
                    contador += 1
            End Select

        Next

        sql_query &= condicion

        If contador > 0 Then
            Return sql_query
        Else
            Return Nothing
        End If

    End Function

    Function contenedor_mantenimiento_insert(ByRef contenedor As System.Windows.Forms.Control.ControlCollection, ByVal tabla As String) As String

        Dim sql_query As String = "INSERT into " & tabla & " ("
        Dim contador As Integer = 0

        Dim valores As String = ""

        'Recorro todos los elementos del panel y segun sea un tipo u otro genero la SQL
        For i As Integer = 0 To contenedor.Count - 1

            Select Case contenedor(i).GetType.FullName
                Case "System.Windows.Forms.Label"

                Case "System.Windows.Forms.DateTimePicker"

                    If contador > 0 Then
                        sql_query &= ", "
                        valores &= ", "
                    End If

                    sql_query &= contenedor(i).Name
                    valores &= "'" & Format(CType(contenedor(i), DateTimePicker).Value, "dd/MM/yyyy") & "'"

                    contador += 1
                Case "System.Windows.Forms.CheckBox"
                    If contador > 0 Then
                        sql_query &= ", "
                        valores &= ", "
                    End If

                    sql_query &= contenedor(i).Name

                    If CType(contenedor(i), CheckBox).Checked Then
                        valores &= "'1'"
                        'sql_query &= contenedor(i).Name & " = '1'"
                    Else
                        valores &= "'0'"
                        'sql_query &= contenedor(i).Name & " = '0'"
                    End If
                    contador += 1

                Case "System.Windows.Forms.TextBox"
                    If contador > 0 Then
                        sql_query &= ", "
                        valores &= ", "
                    End If

                    sql_query &= contenedor(i).Name
                    'sql_query &= contenedor(i).Name & " = '" & contenedor(i).Text & "'"
                    valores &= "'" & contenedor(i).Text & "'"
                    contador += 1
                Case "System.Windows.Forms.ComboBox"
                    'En el combo box podríamos hacer que cogiera el valor identificativo
                    If contador > 0 Then
                        sql_query &= ", "
                        valores &= ", "
                    End If
                    sql_query &= contenedor(i).Name
                    valores &= "'" & contenedor(i).Text & "'"

                    'sql_query &= contenedor(i).Name & " = '" & contenedor(i).Text & "'"
                    contador += 1
            End Select

        Next

        sql_query &= ") VALUES (" & valores & ")"

        If contador > 0 Then
            Return sql_query
        Else
            Return Nothing
        End If

    End Function

End Class
