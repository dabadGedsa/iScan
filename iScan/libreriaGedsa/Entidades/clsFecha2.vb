Namespace Entidades
    Public Class clsFecha2
        Inherits Windows.Forms.MaskedTextBox

        Dim fecha As Date
        Dim var_comprobar As Boolean = False

        Property fnc_comprobar()
            Get
                Return var_comprobar
            End Get
            Set(ByVal value)
                var_comprobar = value
            End Set
        End Property

        ''' <summary>
        ''' Asignamos lod atos al elemento seleccionado
        ''' </summary>
        ''' <remarks></remarks>
        Sub New()
            Me.Mask = "00/00/0000"
            Me.ValidatingType = System.Type.GetType("System.Date")
        End Sub

        Private Sub clsFecha2_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Enter
            If IsDate(Text) Then
                fecha = CDate(Text)
                Me.Mask = "00/00/00"
                Me.Text = Format(fecha, "dd/MM/yy")
            Else
                Me.Mask = "00/00/00"
            End If
            'Application.DoEvents()
            Me.SelectAll()
        End Sub



        Public WriteOnly Property fnc_asigna() As String
            Set(ByVal value As String)

                If value = "01/01/1985" OrElse value = "01/01/85" OrElse value = "  /  /" Then
                    Me.Text = "  /  /"
                Else
                    If IsDate(value) Then
                        If Me.Mask = "00/00/0000" Then
                            Me.Text = Format(CDate(value), "dd/MM/yyyy")
                        Else
                            Me.Text = Format(CDate(value), "dd/MM/yy")
                        End If

                    Else
                        MsgBox("El valor introducido no es una fecha", MsgBoxStyle.Critical, "Incidencia de aplicacion")
                    End If
                End If

                'Application.DoEvents()
                Me.SelectAll()
            End Set
        End Property

        Private Sub clsFecha2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
            SelectAll()
        End Sub

        Private Sub clsFecha2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Leave

            'If Not var_comprobar Then

            '    If Not IsDate(Me.Text) Then
            '        Me.Focus()
            '        Me.SelectAll()
            '        BackColor = Color.Red
            '        MsgBox("La fecha introducida no es correcta", MsgBoxStyle.Critical, "Incidencia de aplicacion")
            '        Exit Sub
            '    End If

            'End If
            If Not Text = "  /  /" Then
                If IsDate(Text) Then
                    fecha = CDate(Text)
                    Me.Mask = "00/00/0000"
                    Me.Text = Format(fecha, "dd/MM/yyyy")
                Else
                    Me.Mask = "00/00/0000"
                End If
                Me.BackColor = Nothing
            End If




        End Sub
    End Class

End Namespace
