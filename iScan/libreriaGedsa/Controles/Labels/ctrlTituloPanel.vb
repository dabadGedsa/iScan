
Imports System.ComponentModel
Imports cons = libreriacadenaproduccion.Controles.Constantes

Namespace Controles
    Namespace Labels

        Public Class ctrlTituloPanel

            'Declaración de atributos privados

            Private posicionCentro As Integer
            Private tamanyoAnterior As Integer
            Private textoAnterior As String

            Public Enum posicionTitulo
                izquierda
                centro
                derecha
            End Enum
            Private pos As posicionTitulo

            Public Sub New()
                MyBase.New()

                MyBase.primeraCarga = True
                InitializeComponent()
                MyBase.primeraCarga = False
                Call inicializarControl()

            End Sub

#Region "Propiedades del control"

            <Category(cons.PROP_CATEG_GENE), Description("Posición del control en la pantalla. Se emplea para saber la dirección en la que crecerá texto."), Browsable(True)> _
            Public Property posicion() As posicionTitulo
                Get
                    Return Me.pos
                End Get
                Set(ByVal value As posicionTitulo)
                    Me.pos = value
                End Set
            End Property

#End Region

#Region "Eventos del control"

            'Cambiar la posición del control cuando cambie su tamaño
            Protected Overrides Sub ctrlLabelBase_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs)
                MyBase.ctrlLabelBase_SizeChanged(sender, e)

                'Evitamos que cambie la posición cuando se está creando el control (InitialiceComponent())
                If MyBase.primeraCarga = False Then

                    'Cambiar la posición sólo si el texto ha cambiado
                    If Me.textoAnterior.Equals(Me.textoLabel) = False Then

                        Select Case pos
                            Case posicionTitulo.izquierda
                                'Posición: no cambia

                            Case posicionTitulo.centro
                                'Posición: tomamos como referencia el centro del control
                                Me.Location = New Point(Me.posicionCentro - (Me.Width / 2), Me.Location.Y)

                            Case posicionTitulo.derecha
                                'Posición: la actual menos lo que ha crecido el panel
                                Me.Location = New Point(Me.Location.X - (Me.Width - tamanyoAnterior), Me.Location.Y)

                        End Select

                    End If

                End If

                Me.tamanyoAnterior = Me.Width
                Me.textoAnterior = Me.textoLabel

            End Sub

            'Después de haber cambiado el tamaño (y por tanto la posición del control), guardamos la nueva posición
            Protected Overrides Sub ctrlLabelBase_LocationChanged(ByVal sender As Object, ByVal e As System.EventArgs)
                MyBase.ctrlLabelBase_LocationChanged(sender, e)

                Me.posicionCentro = Me.Location.X + (Me.Width / 2)

            End Sub

#End Region

#Region "Procedimientos y funciones"

            Private Sub inicializarControl()

                pos = posicionTitulo.centro
                Me.tamanyoAnterior = Me.Width
                Me.textoAnterior = Me.textoLabel

            End Sub

#End Region

        End Class

    End Namespace
End Namespace
