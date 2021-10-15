
Imports System.ComponentModel
Imports cons = libreriacadenaproduccion.Controles.Constantes

Namespace Controles
    Namespace Labels

        Public Class ctrlLabelIntermitente

            'Declaración de atributos privados
            Private intermEnable As Boolean

            Public Sub New()
                MyBase.new()

                InitializeComponent()

                intermEnable = False
                reloj.Interval = 1000

            End Sub

#Region "Propiedades del control"

            <Category(cons.PROP_CATEG_GENE), Description("Intervalo para la intermitencia del control."), Browsable(True)> _
                Public Property pIntervalo() As Integer
                Get
                    Return Me.reloj.Interval
                End Get
                Set(ByVal value As Integer)
                    Me.reloj.Interval = value
                End Set
            End Property

            <Category(cons.PROP_CATEG_GENE), Description("Activa la intermitencia del control."), Browsable(True)> _
            Public Property pIntermitenciaEnable() As Boolean
                Get
                    Return Me.intermEnable
                End Get
                Set(ByVal value As Boolean)
                    Me.intermEnable = value
                    If Me.intermEnable = True Then
                        Me.reloj.Start()
                    Else
                        Label1.Visible = True
                        Me.reloj.Stop()
                    End If
                End Set
            End Property

#End Region

#Region "Eventos del control"

            <Category(cons.EVEN_CATEG_GENE), Description("Tiene lugar cuando se oculta el texto."), Browsable(True)> _
            Public Event eTextoOculto As EventHandler

            <Category(cons.EVEN_CATEG_GENE), Description("Tiene lugar cuando ha transcurrido el intervalo de tiempo especificado."), Browsable(True)> _
            Public Event eRelojTick As EventHandler
            Private Sub reloj_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles reloj.Tick

                If Me.Label1.Visible = True Then
                    Me.Label1.Visible = False
                    RaiseEvent eTextoOculto(Me, EventArgs.Empty)
                Else
                    Me.Label1.Visible = True
                End If

            End Sub

#End Region

#Region "Procedimentos y funciones"



#End Region

        End Class

    End Namespace
End Namespace
