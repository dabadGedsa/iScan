
Imports System.ComponentModel
Imports System.Drawing
Imports cons = libreriacadenaproduccion.Controles.Constantes
Imports img = libreriacadenaproduccion.My.Resources

Namespace Controles
    Namespace Botones

''' <summary>
''' Esta es la clase base de los controles de tipo boton, de ella heredan todos los
''' controles de este mismo tipo o de funcionalidad similar.
''' Si el control heredado se crea dinámicamente (en ejecución), es necesario
''' definir sus nuevos atributos en el constructor.
''' </summary>
''' <remarks></remarks>
''' 

        Public Class ctrlBotonBase

            'Declaración de atributos privados

            Private imagenMouseEnter As Image
            Private imagenMouseLeave As Image
            Private imagenMouseOver As Image

            Public Sub New()

                InitializeComponent()
                Call inicializarControl()
               
            End Sub

#Region "Propiedades del control"

            <Category(cons.PROP_CATEG_GENE), Description("Texto asociado al control."), Browsable(True)> _
            Public Property TextoBoton() As String
                Get
                    Return Me.Button1.Text
                End Get
                Set(ByVal value As String)
                    Me.Button1.Text = value
                End Set
            End Property

            <Category(cons.PROP_CATEG_GENE), Description("Indica si el control está habilitado."), Browsable(True)> _
            Public Property EnabledBoton() As Boolean
                Get
                    Return Me.Button1.Enabled
                End Get
                Set(ByVal value As Boolean)
                    Me.Button1.Enabled = value
                End Set
            End Property

            <Category(cons.PROP_CATEG_GENE), Description("Imagen que aparece en el control cuando se situa el mouse sobre él."), Browsable(True)> _
            Public Property pImagenMouseEnter() As Image
                Get
                    Return Me.imagenMouseEnter
                End Get
                Set(ByVal value As Image)
                    Me.imagenMouseEnter = value
                End Set
            End Property


            <Category(cons.PROP_CATEG_GENE), Description("Imagen que aparece en el control cuando se situa el mouse sobre él."), Browsable(True)> _
            Public Property pImagenMouseOver() As Image
                Get
                    Return Me.imagenMouseOver
                End Get
                Set(ByVal value As Image)
                    Me.imagenMouseOver = value
                End Set
            End Property

            <Category(cons.PROP_CATEG_GENE), Description("Imagen que aparece cuando el mouse no se encuentra sobre él."), Browsable(True)> _
            Public Property pImagenMouseLeave() As Image
                Get
                    Return Me.imagenMouseLeave
                End Get
                Set(ByVal value As Image)
                    Me.imagenMouseLeave = value
                End Set
            End Property

#End Region

#Region "Eventos del control"

            <Category(cons.EVEN_CATEG_GENE), Description("Tiene lugar cuando se hace click en el control."), Browsable(True)> _
            Public Shadows Event eClick As EventHandler
            Protected Overridable Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

                RaiseEvent eClick(Me, EventArgs.Empty)

            End Sub

            <Category(cons.EVEN_CATEG_GENE), Description("Tiene lugar cuando el mouse permanece quieto dentro del control durante un tiempo."), Browsable(True)> _
            Public Event _MouseOver As EventHandler
            Protected Overridable Sub Button1_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.MouseHover

                Me.Button1.BackgroundImage = img.cmbenter
                RaiseEvent _MouseOver(Me, EventArgs.Empty)

            End Sub

            <Category(cons.EVEN_CATEG_GENE), Description("Tiene lugar cuando el mouse entra en la parte visible del control."), Browsable(True)> _
            Public Event eMouseEnter As EventHandler
            Protected Overridable Sub Button1_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.MouseEnter

                Me.Button1.BackgroundImage = img.cmdMouseEnter
                RaiseEvent eMouseEnter(Me, EventArgs.Empty)

            End Sub

            <Category(cons.EVEN_CATEG_GENE), Description("Tiene lugar cuando el mouse ya no está en la parte visible del control."), Browsable(True)> _
            Public Event eMouseLeave As EventHandler
            Protected Overridable Sub Button1_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.MouseLeave

                Me.Button1.BackgroundImage = Me.imagenMouseLeave
                RaiseEvent eMouseLeave(Me, EventArgs.Empty)

            End Sub

#End Region

#Region "Procedimientos y funciones"

            Private Sub inicializarControl()

                Me.imagenMouseOver = img.cmdMouseEnter
                Me.imagenMouseEnter = img.cmbenter
                Me.imagenMouseLeave = img.cmdMouseLeave


            End Sub

#End Region

        End Class

    End Namespace
End Namespace
