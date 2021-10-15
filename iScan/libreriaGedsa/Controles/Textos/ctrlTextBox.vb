
Imports System.ComponentModel
Imports cons = libreriacadenaproduccion.Controles.Constantes

Namespace Controles
    Namespace Textos

        Public Class ctrlTextBox

            'Declaración de atributos privados

            Private nomColumnaBD As String
            Private esNumerico As Boolean
            Private valor As Integer
            Private esIdentificador As Boolean
            Private soloNumeros As Boolean
            Private soloLetras As Boolean
            Private esCodigoBarras As Boolean
            Private textoRequerido As Boolean

            'Para evitar que aparezca el cursor en el TextBox, creamos un nuevo
            'control al que se le pasa el foco.
            'Dim quitar As New Label

            Public Sub New()

                InitializeComponent()
                Call inicializarControl()

            End Sub

#Region "Propiedades del control"



            <Category(cons.PROP_CATEG_GENE), Description("Texto del TextBox."), Browsable(True)> _
            Public Property _TextoTextBox() As String
                Get
                    Return Me.TextBox1.Text
                End Get
                Set(ByVal value As String)
                    Me.TextBox1.Text = value
                End Set
            End Property

            <Category(cons.PROP_CATEG_GENE), Description("El TextBox sólo admite números."), Browsable(True)> _
            Public Property _SoloNumeros() As Boolean
                Get
                    Return Me.soloNumeros
                End Get
                Set(ByVal value As Boolean)
                    Me.soloNumeros = value
                End Set
            End Property

            <Category(cons.PROP_CATEG_GENE), Description("El TextBox sólo admite letras."), Browsable(True)> _
            Public Property _SoloLetras() As Boolean
                Get
                    Return Me.soloLetras
                End Get
                Set(ByVal value As Boolean)
                    Me.soloLetras = value
                End Set
            End Property

            <Category(cons.PROP_CATEG_GENE), Description("El contenido del TextBox es un código de barras."), Browsable(True)> _
            Public Property _EsCodigoBarras() As Boolean
                Get
                    Return Me.esCodigoBarras
                End Get
                Set(ByVal value As Boolean)
                    Me.esCodigoBarras = value
                    If Me.esCodigoBarras = True Then
                        Me.TextBox1.MaxLength = 13
                    Else
                        Me.TextBox1.MaxLength = 1000
                    End If
                End Set
            End Property

            <Category(cons.PROP_CATEG_GENE), Description("El TextBox es de sólo lectura."), Browsable(True)> _
            Public Property _SoloLectura() As Boolean
                Get
                    Return Me.TextBox1.ReadOnly
                End Get
                Set(ByVal value As Boolean)
                    Me.TextBox1.ReadOnly = value
                    If value = True Then
                        Me.TextBox1.BackColor = Color.MistyRose
                    Else
                        Me.TextBox1.BackColor = Color.White
                    End If
                End Set
            End Property

            <Category(cons.PROP_CATEG_GENE), Description("El TextBox admite múltiples lineas."), Browsable(True)> _
            Public Property _Multiline() As Boolean
                Get
                    Return Me.TextBox1.Multiline
                End Get
                Set(ByVal value As Boolean)
                    Me.TextBox1.Multiline = value
                End Set
            End Property

            <Category(cons.PROP_CATEG_GENE), Description("Habilitar/deshabilitar el TextBox."), Browsable(True)> _
            Public Property _Enabled() As Boolean
                Get
                    Return Me.TextBox1.Enabled
                End Get
                Set(ByVal value As Boolean)
                    Me.TextBox1.Enabled = value
                End Set
            End Property

            <Category(cons.PROP_CATEG_GENE), Description("Indica si el campo es requerido."), Browsable(True)> _
            Public Property _Requerido() As Boolean
                Get
                    Return Me.textoRequerido
                End Get
                Set(ByVal value As Boolean)
                    Me.textoRequerido = value
                    Call cambiarColor()
                End Set
            End Property

            <Category(cons.PROP_CATEG_GENE), Description("Indica si se trata de un campo de contraseña con *."), Browsable(True)> _
            Public Property _Contrasenya() As Boolean
                Get
                    If Me.TextBox1.PasswordChar = "*" Then
                        Return True
                    Else
                        Return False
                    End If
                End Get
                Set(ByVal value As Boolean)
                    If value = True Then
                        Me.TextBox1.PasswordChar = "*"
                    Else
                        Me.TextBox1.PasswordChar = ""
                    End If
                End Set
            End Property

#End Region

#Region "Propiedades para las consultas"

            <Category(cons.PROP_CATEG_CONS), Description("Indica si el contenido del TextBox son números."), Browsable(True)> _
            Public Property _EsNumerico() As Boolean
                Get
                    Return Me.esNumerico
                End Get
                Set(ByVal value As Boolean)
                    Me.esNumerico = value
                End Set
            End Property

            <Category(cons.PROP_CATEG_CONS), Description("Nombre de la columna de la base de datos."), Browsable(True)> _
            Public Property _itemNombre() As String
                Get
                    Return Me.nomColumnaBD
                End Get
                Set(ByVal value As String)
                    Me.nomColumnaBD = value
                End Set
            End Property

            <Category(cons.PROP_CATEG_CONS), Description("Indica si el textbox tiene un identificador."), Browsable(True)> _
            Public Property _esIdentificador() As Boolean
                Get
                    Return Me.esIdentificador
                End Get
                Set(ByVal value As Boolean)
                    If value = True Then Me.esNumerico = True 'Si es un identificador, el TextBox es numerico 
                    Me.esIdentificador = value
                End Set
            End Property

            <Category(cons.PROP_CATEG_CONS), Description("Valor del indice que identifica al campo."), Browsable(True)> _
           Public Property _valor() As Integer
                Get
                    Return Me.valor
                End Get
                Set(ByVal value As Integer)
                    Me.valor = value
                End Set
            End Property

#End Region

#Region "Eventos del control"

            <Category(cons.EVEN_CATEG_GENE), Description("Ocurre cuando el texto cambia"), Browsable(True)> _
            Public Event eTextChanged As EventHandler
            Private Sub TextBox1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

                Me.ToolTip1.SetToolTip(Me.TextBox1, Me.TextBox1.Text)
                RaiseEvent eTextChanged(Me, EventArgs.Empty)

            End Sub

            Private Sub TextBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.Enter, MyBase.Enter

                Me.TextBox1.BackColor = Color.RoyalBlue
                Me.TextBox1.ForeColor = Color.White

                'quitar.Focus()
                'Call TextBox1_Leave(Me, EventArgs.Empty)

            End Sub

            Private Sub TextBox1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.Leave, MyBase.Leave

                Me.TextBox1.BackColor = Color.White
                Me.TextBox1.ForeColor = Color.Black

                'Reemplazar los carácteres 11 y 12 por ceros.
                'Esto es para que busque siempre la primera página que es la que identifica al documento 
                If Me.esCodigoBarras = True And TextBox1.Text.Length > 12 Then
                    TextBox1.Text = TextBox1.Text.Substring(0, 10) & "00" & TextBox1.Text.Chars(12)
                End If

            End Sub

            Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress

                If Me.soloNumeros = True Or Me.esCodigoBarras = True Then

                    'Sólo se aceptan números
                    If Char.IsDigit(e.KeyChar) Then
                        e.Handled = False
                    ElseIf Char.IsControl(e.KeyChar) Then
                        e.Handled = False
                    Else
                        e.Handled = True
                    End If

                ElseIf Me.soloLetras = True Then

                    'Sólo se aceptan letras
                    If Char.IsLetter(e.KeyChar) Then
                        e.Handled = False
                    ElseIf Char.IsControl(e.KeyChar) Then
                        e.Handled = False
                    ElseIf Char.IsSeparator(e.KeyChar) Then
                        e.Handled = False
                    Else
                        e.Handled = True
                    End If

                End If

            End Sub

#End Region

#Region "Procedimientos y funciones"

            Private Sub inicializarControl()

                Me.nomColumnaBD = ""
                Me.soloNumeros = False
                Me.soloLetras = False
                Me.esCodigoBarras = False
                Me.textoRequerido = False
                Me._EsNumerico = False

                'Me.Controls.Add(quitar)
                'quitar.Parent = Me
                'quitar.Location = New Point(100, 100)

            End Sub

            'Si el campo es requerido se le cambia el color
            Private Sub cambiarColor()
                If Me.textoRequerido = True Then
                    TextBox1.BackColor = Color.MistyRose
                ElseIf Me.textoRequerido = False Then
                    TextBox1.BackColor = Color.White
                End If
            End Sub

#End Region

#Region "Clases internas"



#End Region

        End Class


    End Namespace
End Namespace

