
Imports System.ComponentModel
Imports System.Windows.Forms
Imports cons = libreriacadenaproduccion.Controles.Constantes

Namespace Controles
    Namespace Combos

        Public Class CtrlComboBox

            'Declaración de atributos privados

            Private esDeBusqueda As Boolean
            Private nomColumnaBD As String
            Private requerido As Boolean

            Public Sub New()

                InitializeComponent()
                Call inicializarControl()

            End Sub

#Region "Propiedades del control"

            <Category(cons.PROP_CATEG_GENE), Description("Indica el estilo del combo")> _
            Public Property _Style() As ComboBoxStyle
                Get
                    Return Me.ComboBox1.DropDownStyle
                End Get
                Set(ByVal value As ComboBoxStyle)
                    Me.ComboBox1.DropDownStyle = value
                End Set
            End Property

            <Category(cons.PROP_CATEG_GENE), Description("Indica el texto que tendra el combo")> _
            Public Property _TextoComboBox() As String
                Get
                    Return Me.ComboBox1.Text
                End Get
                Set(ByVal value As String)
                    Me.ComboBox1.Text = value
                End Set
            End Property

            <Category(cons.PROP_CATEG_GENE), Description("Añadir un nuevo item al combo"), Browsable(False)> _
            Public WriteOnly Property _ItemsAdd() As Object
                Set(ByVal value As Object)
                    Me.ComboBox1.Items.Add(value)
                End Set
            End Property

            <Category(cons.PROP_CATEG_GENE), Description("Obtener un item del combo"), Browsable(False)> _
            Public ReadOnly Property _Items(ByVal numItem As Integer) As Object
                Get
                    Return Me.ComboBox1.Items(numItem)
                End Get
            End Property

            <Category(cons.PROP_CATEG_GENE), Description("Obtiene el item seleccionado"), Browsable(False)> _
            Public Property _SelectedItem() As Object
                Get
                    Return Me.ComboBox1.SelectedItem
                End Get
                Set(ByVal value As Object)
                    Me.ComboBox1.SelectedItem = value
                End Set
            End Property

            <Category(cons.PROP_CATEG_GENE), Description("Obtiene el item seleccionado"), Browsable(False)> _
            Public Property _SelectedIndex() As Integer
                Get
                    Return Me.ComboBox1.SelectedIndex
                End Get
                Set(ByVal value As Integer)
                    Try
                        Me.ComboBox1.SelectedIndex = value
                    Catch ex As Exception
                        'MessageBox.Show("Se ha accedico a la posición 0 del vector de items del ctrlComboBox y no hay un item en esta posición")
                    End Try
                End Set
            End Property

            <Category(cons.PROP_CATEG_GENE), Description("elimina un elemento de la lista"), Browsable(False)> _
            Public WriteOnly Property _ItemsRemove() As Object
                Set(ByVal value As Object)
                    Me.ComboBox1.Items.Remove(value)
                End Set
            End Property

            <Category(cons.PROP_CATEG_GENE), Description("Indica si el campo es requerido")> _
            Public Property _Requerido() As Boolean
                Get
                    Return Me.requerido
                End Get
                Set(ByVal value As Boolean)
                    Me.requerido = value
                    _cambiarColor()
                End Set
            End Property

            <Category(cons.PROP_CATEG_GENE)> _
            Public Property _Enabled() As Boolean
                Get
                    Return Me.ComboBox1.Enabled
                End Get
                Set(ByVal value As Boolean)
                    Me.ComboBox1.Enabled = value
                End Set
            End Property

#End Region

#Region "Propiedades para consultas"

            <Category(cons.PROP_CATEG_CONS), Description("Item.Nombre"), Browsable(True)> _
            Public Property _itemNombre() As String
                Get
                    Return Me.nomColumnaBD
                End Get
                Set(ByVal value As String)
                    Me.nomColumnaBD = value
                End Set
            End Property

            <Category(cons.PROP_CATEG_CONS), Description("Indica si el combo se va a utilizar en un panel de busqueda"), Browsable(True)> _
            Public Property _EsDeBusqueda() As Boolean
                Get
                    Return Me.esDeBusqueda
                End Get
                Set(ByVal value As Boolean)
                    Me.esDeBusqueda = value
                End Set
            End Property

#End Region

#Region "Eventos del control"

            <Category(cons.EVEN_CATEG_GENE), Description("Ocurre cuando cambia el item seleccionado"), Browsable(True)> _
            Public Event eSelectedIndexChanged As EventHandler
            Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
                RaiseEvent eSelectedIndexChanged(Me, EventArgs.Empty)
            End Sub

            Private Sub CtrlComboBox_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

                If Me._EsDeBusqueda = True Then
                    If Not Me.ComboBox1.Items.Contains("...") Then
                        Me.ComboBox1.Items.Add("...")
                        Me.ComboBox1.SelectedIndex = 0
                    End If
                End If

            End Sub

            <Category(cons.EVEN_CATEG_GENE), Description(""), Browsable(True)> _
            Public Event eTextChanged As EventHandler
            Private Sub ComboBox1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.TextChanged
                RaiseEvent eTextChanged(Me, EventArgs.Empty)
            End Sub

#End Region

#Region "Procedimientos y funciones"

            Private Sub inicializarControl()

                Me.esDeBusqueda = False
                Me.nomColumnaBD = ""
                Me.requerido = False

            End Sub

            Public Function _ObtenerIdSelectedItem() As Object

                Dim id As Object
                Try
                    id = Me.ComboBox1.SelectedItem.obtenerId()
                Catch ex As Exception
                    Return Nothing
                End Try

                Return id

            End Function

            Public Sub _ItemsClear()
                Me.ComboBox1.Items.Clear()
                If Me._EsDeBusqueda = True Then
                    Me.ComboBox1.Items.Add("...")
                    Me.ComboBox1.SelectedIndex = 0
                End If
            End Sub

            Public Function _ItemsCount() As Integer
                Return Me.ComboBox1.Items.Count
            End Function

            Private Sub _cambiarColor()
                If Me.requerido = True Then
                    ComboBox1.BackColor = Color.Pink
                ElseIf Me.requerido = False Then
                    ComboBox1.BackColor = Color.White
                End If
            End Sub

#End Region

#Region "Clases internas"



#End Region

        End Class


    End Namespace
End Namespace

