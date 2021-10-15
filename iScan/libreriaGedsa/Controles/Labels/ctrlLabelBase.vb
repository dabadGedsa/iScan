
Imports System.ComponentModel
Imports cons = libreriacadenaproduccion.Controles.Constantes

Namespace Controles
    Namespace Labels

        ''' <summary>
        ''' Esta es la clase base de los controles de tipo label, de ella heredan todos los
        ''' controles de este mismo tipo o de funcionalidad similar.
        ''' Si el control heredado se crea dinámicamente (en ejecución), es necesario
        ''' definir sus nuevos atributos en el constructor.
        ''' </summary>
        ''' <remarks></remarks>

        Public Class ctrlLabelBase

            'Declaración de atributos privados

            'primeraCarga -> para evitar que se ejecuten determinadas funciones
            'mientras se está creando el control (InitializeComponent)
            Protected primeraCarga As Boolean

            Public Sub New()

                Me.primeraCarga = True
                InitializeComponent()
                Me.primeraCarga = False

            End Sub

#Region "Propiedades del control"

            <Category(cons.PROP_CATEG_GENE), Description("Texto asociado al control."), Browsable(True)> _
            Public Property textoLabel() As String
                Get
                    Return Label1.Text
                End Get
                Set(ByVal value As String)
                    Label1.Text = value
                End Set
            End Property

#End Region

#Region "Eventos del control"

            Protected Overridable Sub Label1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.TextChanged

            End Sub

            Protected Overridable Sub ctrlLabelBase_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged

            End Sub

            Protected Overridable Sub ctrlLabelBase_LocationChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.LocationChanged

            End Sub

#End Region

#Region "Procedimientos y funciones"



#End Region

#Region "Clases internas"

#End Region

        End Class

    End Namespace
End Namespace
