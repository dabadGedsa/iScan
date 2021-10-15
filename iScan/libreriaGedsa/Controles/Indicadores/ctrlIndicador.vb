
Imports System.ComponentModel
Imports cons = libreriacadenaproduccion.Controles.Constantes

Namespace Controles
    Namespace Indicadores

        Public Class ctrlIndicador

            'Declaración de atributos privados

            Private WithEvents ComponenteTexto As libreriacadenaproduccion.Controles.Textos.ctrlTextBox
            Private WithEvents ComponenteCombo As libreriacadenaproduccion.Controles.Combos.CtrlComboBox

#Region "Propiedades del control"

            <Category(cons.PROP_CATEG_GENE), Description("TextBox al que está asociado el indicador."), Browsable(True)> _
            Public Property _AsociarTextBox() As libreriacadenaproduccion.Controles.Textos.ctrlTextBox
                Get
                    Return Me.ComponenteTexto
                End Get
                Set(ByVal value As libreriacadenaproduccion.Controles.Textos.ctrlTextBox)
                    Me.ComponenteTexto = value
                End Set
            End Property

            <Category(cons.PROP_CATEG_GENE), Description("ComboBox al que está asociado el indicador."), Browsable(True)> _
            Public Property _AsociarComboBox() As libreriacadenaproduccion.Controles.Combos.CtrlComboBox
                Get
                    Return Me.ComponenteCombo
                End Get
                Set(ByVal value As libreriacadenaproduccion.Controles.Combos.CtrlComboBox)
                    Me.ComponenteCombo = value
                End Set
            End Property

            <Category(cons.PROP_CATEG_GENE), Description("Imagen que se mostrará en el indicador."), Browsable(True)> _
            Public Property pImagen() As Image
                Get
                    Return Me.ImagenIndicador.Image
                End Get
                Set(ByVal value As Image)
                    Me.ImagenIndicador.Image = value
                End Set
            End Property

#End Region

#Region "Eventos del control"

            Public Sub eventoTextBox(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComponenteTexto.eTextChanged

                'Dim TextBox As ctrlTextBox
                'TextBox = ComponenteTexto

                If Me.ComponenteTexto._TextoTextBox.Equals("") = False Then
                    Me.ImagenIndicador.Image = My.Resources.bullet_green
                Else
                    Me.ImagenIndicador.Image = My.Resources.bullet_red
                End If

            End Sub

            Public Sub eventoComboBox(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComponenteCombo.eTextChanged

                'Dim ComboBox As CtrlComboBox
                'ComboBox = ComponenteCombo

                If Me.ComponenteCombo._TextoComboBox.Equals("") = False Or Me.ComponenteCombo._TextoComboBox.Equals("...") = False Then
                    Me.ImagenIndicador.Image = My.Resources.bullet_green
                Else
                    Me.ImagenIndicador.Image = My.Resources.bullet_red
                End If

            End Sub

#End Region

#Region "Procedimientos y funciones"

            Private Sub inicializarControl()

            End Sub

#End Region

#Region "Clases internas"



#End Region

        End Class

    End Namespace

End Namespace
