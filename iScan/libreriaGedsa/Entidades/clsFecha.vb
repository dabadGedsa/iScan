Imports System.Windows.Forms

Namespace Entidades


    ''' <summary>
    ''' Nombre: Control Fecha para indización
    ''' Autor:  J.Medrano
    ''' Descripcion:
    '''     Devido a que el control fecha no se asemeja al de visual 6, para una mayor productividad
    '''     se ha reecho.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class clsFecha
        Inherits Windows.Forms.TextBox

        Dim var_dia As String = ""
        Dim var_mes As String = ""
        Dim var_anio As String = ""

        Dim var_zona As Integer = 0

        Dim var_fecha_larga As Boolean = True
        Private var_control_fecha As Boolean = True

        Private var_fecha_digitos As Integer

        Property p_fecha_control() As Boolean
            Get
                Return var_control_fecha
            End Get
            Set(ByVal value As Boolean)
                var_control_fecha = value
            End Set
        End Property

        Property p_fecha_larga() As Boolean
            Get
                Return var_fecha_larga
            End Get
            Set(ByVal value As Boolean)
                var_fecha_larga = value
                If var_fecha_larga Then
                    var_fecha_digitos = 4
                Else
                    var_fecha_digitos = 2
                End If
            End Set
        End Property

        Property p_fecha_value() As Date
            Get
                Try
                    Return CDate(Me.Text)
                Catch ex As Exception
                    Return CDate("01/01/1900")
                End Try
            End Get

            Set(ByVal value As Date)
                'If var_fecha_larga Then

                var_dia = Format(value.Day, "00")
                var_mes = Format(value.Month, "00")
                var_anio = Format(value.Year, "0000")

                Me.Text = Format(value, "dd/MM/yyyy")
                'Else
                'Me.Text = Format(value, "dd/MM/yy")

            End Set
        End Property

        Sub New()
            var_dia = ""
            var_mes = ""
            var_anio = ""
            p_fecha_larga = False
            fnc_fecha_mostrar()
            fnc_zona_selecciona(0)
        End Sub

        Function fnc_fecha_mostrar(Optional ByVal tmp_zona As String = "") As String
            Select Case tmp_zona
                Case 0
                    Return Format(CInt(var_dia), "00")
                Case 1
                    Return Format(CInt(var_mes), "00")
                Case 2
                    Return Format(CInt(var_anio), "".PadLeft(var_fecha_digitos, "0"))
                Case Else
                    Dim tmpDia As String = "__", tmpMes As String = "__", tmpAnio As String
                    tmpDia = var_dia.PadLeft(2, "_"c) 'Format(CInt(var_dia), "00")
                    tmpMes = var_mes.PadLeft(2, "_"c) 'Format(CInt(var_mes), "00")
                    tmpAnio = var_anio.PadLeft(var_fecha_digitos, "_"c) 'Format(CInt(var_anio), "0000")
                    Return tmpDia & "/" & tmpMes & "/" & tmpAnio
            End Select
        End Function

        ''' <summary>
        ''' Muestra el valor de la fecha con el formato determinado que seleccionamos
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function fnc_fecha_string(ByVal formatoLargo As Boolean) As String
            Dim filtro As String = "dd/MM/yy"
            If formatoLargo Then filtro = "dd/MM/yyyy"

            If IsDate(Me.Text) Then
                Dim fecha As Date = CDate(Me.Text)
                Return Format(fecha, filtro)
            Else
                Return "-1"
            End If
        End Function


        Public Sub fecha_anade(ByVal numero As Char, ByVal zona As Integer)
            'Segun la posicion a la que se encuentre 
            Select Case zona
                Case 0

                    If var_dia.Length >= 2 Then
                        var_dia = numero
                    ElseIf var_dia.Length = 1 Then
                        var_dia &= numero
                        var_zona += 1
                        fnc_zona_selecciona(var_zona)
                    Else
                        var_dia &= numero
                    End If

                Case 1
                    If var_mes.Length >= 2 Then
                        var_mes = numero
                    ElseIf var_mes.Length = 1 Then
                        var_mes &= numero
                        var_zona += 1
                        fnc_zona_selecciona(var_zona)
                    Else
                        var_mes &= numero
                    End If
                Case 2
                    If var_anio.Length >= var_fecha_digitos Then
                        var_anio = numero
                    Else
                        var_anio &= numero
                    End If
            End Select
        End Sub

        ''' <summary>
        ''' Eliminacion de los datos de una zona determinada
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub fnc_zona_eliminar(ByVal tmpzona As Integer)
            Select Case tmpzona
                Case 0
                    var_dia = ""
                Case 1
                    var_mes = ""
                Case 2
                    var_anio = ""
            End Select
            Me.Text = fnc_fecha_mostrar()
            fnc_zona_selecciona(var_zona)
        End Sub

        Public Sub fnc_zona_selecciona(ByVal zona As Integer)
            Me.Focus()
            Select Case zona
                Case 0
                    Me.Select(0, 2)
                Case 1
                    Me.Select(3, 2)
                Case 2
                    Me.Select(6, Me.Text.Length - 6)
            End Select

        End Sub

        Private Sub clsFecha_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
            e.Handled = True
            Select Case e.KeyCode
                Case Keys.Right

                    If var_zona < 2 Then
                        var_zona += 1
                        fnc_zona_selecciona(var_zona)
                        'fnc_zona_eliminar(var_zona)
                    Else
                        fnc_zona_selecciona(2)
                        'fnc_zona_eliminar(2)
                    End If
                Case Keys.Left
                    If SelectionStart > 0 Then
                        var_zona -= 1
                        fnc_zona_selecciona(var_zona)
                        'fnc_zona_eliminar(var_zona)
                    Else
                        fnc_zona_selecciona(0)
                        'fnc_zona_eliminar(0)
                    End If
                Case Keys.Delete
                    fnc_zona_eliminar(var_zona)
            End Select
        End Sub

        Private Sub clsFecha_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
            e.Handled = True
            Select Case Asc(e.KeyChar)
                Case 48 To 57
                    fecha_anade(e.KeyChar, var_zona)
                    Me.Text = fnc_fecha_mostrar()
                    fnc_zona_selecciona(var_zona)
            End Select
        End Sub

        Private Sub clsFecha_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus

            If IsDate(Me.Text) Then
                If var_fecha_larga Then
                    Me.Text = Format(CDate(Me.Text), "dd/MM/yyyy")
                Else
                    Me.Text = Format(CDate(Me.Text), "dd/MM/yy")
                End If
            End If

            var_zona = 0
            fnc_zona_selecciona(var_zona)
        End Sub

        Private Sub clsFecha_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Leave
            'Comprobamos si la fecha es correcta
            If var_control_fecha Then
                If Not IsDate(Me.Text) Then
                    MsgBox("La fecha introducida no tiene valor correcto", MsgBoxStyle.Critical, "Incidencia de aplicacion")
                    Me.SelectAll()
                    Me.Focus()
                Else
                    Me.Text = fnc_fecha_string(True)
                End If
            End If

        End Sub

        Sub fnc_zona_seleccion_click(ByVal num_caracter As Integer)
            Select Case num_caracter
                Case 0 To 1
                    var_zona = 0
                Case 2 To 4
                    var_zona = 1
                Case Else
                    var_zona = 2
            End Select
            fnc_zona_selecciona(var_zona)
        End Sub

        Private Sub clsFecha_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
            fnc_zona_seleccion_click(Me.SelectionStart)
        End Sub
    End Class


End Namespace
