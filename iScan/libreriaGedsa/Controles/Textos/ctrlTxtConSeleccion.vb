Imports System.Windows.Forms
Imports System.ComponentModel
Imports cons = libreriacadenaproduccion.Controles.Constantes

Namespace Controles
    Namespace Textos

        Public Class ctrlTxtConSeleccion

            'Declaración de atributos privados

            Private MostrarIndicador As Boolean

            Public Sub New()

                InitializeComponent()
                Call inicializarControl()

            End Sub

#Region "Propiedades del control"

            'PROPIEDADES DEL GROUPBOX

            <Category(cons.PROP_CATEG_GENE), Description("Texto del GroupBox."), Browsable(True)> _
            Public Property _TextoGroupBox() As String
                Get
                    Return Me.GroupBox1.Text
                End Get
                Set(ByVal value As String)
                    Me.GroupBox1.Text = value
                End Set
            End Property

            'PROPIEDADES DEL COMBOBOX

            <Category(cons.PROP_CATEG_GENE), Description("Indica el texto que tendra el combo"), Browsable(True)> _
            Public Property _TextoComboBox() As String
                Get
                    Return Me.cmbSeleccion._TextoComboBox
                End Get
                Set(ByVal value As String)
                    Me.cmbSeleccion._TextoComboBox = value
                End Set
            End Property

            <Category(cons.PROP_CATEG_GENE), Description("Obtiene el item seleccionado"), Browsable(False)> _
            Public Property _SelectedItem() As Object
                Get
                    Return Me.cmbSeleccion._SelectedItem
                End Get
                Set(ByVal value As Object)
                    Me.cmbSeleccion._SelectedItem = value
                End Set
            End Property

            <Category(cons.PROP_CATEG_GENE), Description("Obtiene el item seleccionado"), Browsable(False)> _
            Public Property _SelectedIndex() As Integer
                Get
                    Return Me.cmbSeleccion._SelectedIndex
                End Get
                Set(ByVal value As Integer)
                    Me.cmbSeleccion._SelectedIndex = value
                End Set
            End Property

            <Category(cons.PROP_CATEG_GENE), Description("Añadir un nuevo item al combo"), Browsable(False)> _
            Public WriteOnly Property _ItemsAdd() As Object
                Set(ByVal value As Object)
                    Me.cmbSeleccion._ItemsAdd = value
                End Set
            End Property

            <Category(cons.PROP_CATEG_GENE), Description("Item.Nombre"), Browsable(True)> _
            Public Property _ComboBoxItemNombre() As String
                Get
                    Return Me.cmbSeleccion._itemNombre
                End Get
                Set(ByVal value As String)
                    Me.cmbSeleccion._itemNombre = value
                End Set
            End Property

            'PROPIEDADES DEL TEXTBOX

            <Category(cons.PROP_CATEG_GENE), Description("Texto del TextBox."), Browsable(True)> _
            Public Property _TextoTextBox() As String
                Get
                    Return Me.CtrlTextBox1._TextoTextBox
                End Get
                Set(ByVal value As String)
                    Me.CtrlTextBox1._TextoTextBox = value
                End Set
            End Property

            <Category(cons.PROP_CATEG_CONS), Description("Indica si el textbox tiene un identificador."), Browsable(True)> _
            Public Property _esIdentificador() As Boolean
                Get
                    Return Me.CtrlTextBox1._esIdentificador
                End Get
                Set(ByVal value As Boolean)
                    If value = True Then Me.CtrlTextBox1._EsNumerico = True 'Si es un identificador, el TextBox es numerico 
                    Me.CtrlTextBox1._esIdentificador = value
                End Set
            End Property

            <Category(cons.PROP_CATEG_GENE), Description("Item.Nombre"), Browsable(True)> _
            Public Property _TextBoxValor() As String
                Get
                    Return Me.CtrlTextBox1._valor
                End Get
                Set(ByVal value As String)
                    Me.CtrlTextBox1._valor = value
                End Set
            End Property

            <Category(cons.PROP_CATEG_GENE), Description("Item.Nombre"), Browsable(True)> _
            Public Property _TextBoxItemNombre() As String
                Get
                    Return Me.CtrlTextBox1._itemNombre
                End Get
                Set(ByVal value As String)
                    Me.CtrlTextBox1._itemNombre = value
                End Set
            End Property

            'PROPIEDADES DEL BOTON

            <Category(cons.PROP_CATEG_GENE), Description("Imagen que se mostrará en el botón."), Browsable(True)> _
                Public Property _ImagenBoton() As Image
                Get
                    Return Me.pbImagen.BackgroundImage
                End Get
                Set(ByVal value As Image)
                    Me.pbImagen.BackgroundImage = value
                End Set
            End Property

            'PROPIEDADES DEL INDICADOR

            <Category(cons.PROP_CATEG_GENE), Description(""), Browsable(True)> _
            Public Property _MostarIndicador() As Boolean
                Get
                    Return Me.MostrarIndicador

                End Get
                Set(ByVal value As Boolean)
                    Me.MostrarIndicador = value

                    If Me.MostrarIndicador = True Then
                        Me.Indicador.Visible = True
                    Else
                        Me.Indicador.Visible = False
                    End If
                End Set
            End Property

#End Region

#Region "Eventos del control"

            <Category(cons.EVEN_CATEG_GENE), Description(""), Browsable(True)> _
            Public Event botonPulsado(ByVal idtipoContacto As Integer)
            Private Sub pbimagen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbImagen.Click
                RaiseEvent botonPulsado(Me.cmbSeleccion._SelectedIndex)
            End Sub

            Private Sub cmbSeleccion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSeleccion.eSelectedIndexChanged

                'Me.CtrlTextBox1._TextoTextBox = ""
                'Me.CtrlTextBox1._valor = 0

            End Sub

            <Category(cons.EVEN_CATEG_GENE), Description("Ocurre cuando el texto cambia"), Browsable(True)> _
            Public Event eTextChanged As EventHandler
            Private Sub CtrlTextBox1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CtrlTextBox1.eTextChanged
                RaiseEvent eTextChanged(Me, EventArgs.Empty)
            End Sub

#End Region

#Region "Procedimientos y funciones"

            Private Sub inicializarControl()

                Me.MostrarIndicador = False
                Me.pbImagen.BackgroundImageLayout = ImageLayout.Center
                Me.cmbSeleccion._SelectedIndex = 0
                Me.cmbSeleccion._ItemsClear()
                Me.cmbSeleccion._ItemsAdd = "Entidad"
                Me.cmbSeleccion._ItemsAdd = "Contacto Personal"

            End Sub

#End Region

#Region "Clases internas"



#End Region

        End Class

    End Namespace
End Namespace
