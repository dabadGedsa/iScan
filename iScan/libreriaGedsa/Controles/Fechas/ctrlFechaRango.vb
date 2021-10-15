
Imports System.ComponentModel
Imports cons = libreriacadenaproduccion.Controles.Constantes

Namespace Controles
    Namespace Fechas

        Public Class CtrlFechaRango

            'Declaración de atributos privados

            'primeraCarga -> para evitar que se ejecuten determinadas funciones
            'mientras se está creando el control (InitializeComponent)
            Private primeraCarga As Boolean
            Private modificado As Boolean
            Private nomColumnaBD As String 'nombre del campo en la base de datos 

            Enum rango
                NoEsRango = 0
                EsRango = 1
                Anterior = 2
                Posterior = 3
            End Enum

            Public Sub New()

                Me.primeraCarga = True
                InitializeComponent()
                Me.primeraCarga = False
                Call inicializarControl()

            End Sub

#Region "Propiedades del control"

            <Category(cons.PROP_CATEG_GENE), Description("Primera fecha del inervalo"), Browsable(True)> _
                    Public Property _Fecha1() As DateTime
                Get
                    Return Me.dtpFecha1.Value
                End Get
                Set(ByVal value As DateTime)
                    Me.dtpFecha1.Value = value
                End Set
            End Property

            <Category(cons.PROP_CATEG_GENE), Description("Segunda fecha del intervalo"), Browsable(True)> _
                Public Property _Fecha2() As DateTime
                Get
                    Return Me.dtpFecha2.Value
                End Get
                Set(ByVal value As DateTime)
                    Me.dtpFecha2.Value = value
                End Set
            End Property

            <Category(cons.PROP_CATEG_GENE), Description("Item.Nombre"), Browsable(True)> _
            Public Property _itemNombre() As String
                Get
                    Return Me.nomColumnaBD
                End Get
                Set(ByVal value As String)
                    Me.nomColumnaBD = value
                End Set
            End Property

            <Category(cons.PROP_CATEG_GENE), Description("Texto para el groupbox"), Browsable(True)> _
                Public Property _texto() As String
                Get
                    Return Me.GroupBox1.Text
                End Get
                Set(ByVal value As String)
                    Me.GroupBox1.Text = value
                End Set
            End Property

            Private _rangoFecha As rango = rango.NoEsRango
            <Category(cons.PROP_CATEG_GENE), Description("Item.RangoFecha"), Browsable(True)> _
            Public Property _ItemRangoFecha() As rango
                Get
                    Return Me._rangoFecha
                End Get
                Set(ByVal value As rango)
                    Me._rangoFecha = value
                End Set
            End Property

            <Category(cons.PROP_CATEG_GENE), Description("Indica si se ha modificado o no la fecha"), Browsable(True)> _
            Public Property _modificado() As Boolean
                Get
                    Return Me.modificado
                End Get
                Set(ByVal value As Boolean)
                    Me.modificado = value
                End Set
            End Property

#End Region

#Region "Eventos del control"

            'Tipo de búsqueda (igual a, rango, ...)
            Private Sub cmbTipo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTipo.SelectedIndexChanged
                Me._ItemRangoFecha = Me.cmbTipo.SelectedIndex
                If Me.cmbTipo.SelectedIndex = 1 Then
                    fecha2Enabled(True)
                Else : fecha2Enabled(False)
                End If
            End Sub

            'Eventos Fecha1
            Private Sub dtpFecha1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpFecha1.ValueChanged

                If dtpFecha1.Value <> DateTime.Now Then
                    Me.chkFecha1.Checked = False

                    If Me.primeraCarga = False Then
                        Me.pnlFecha1.Visible = False
                        modificado = True
                    End If

                End If

            End Sub

            Private Sub chkFecha1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkFecha1.CheckedChanged
                If Me.chkFecha1.Checked = True Then
                    Me.pnlFecha1.Visible = False
                    Me.dtpFecha1.Value = DateTime.Now
                    modificado = True
                Else
                    Me._clear()
                    modificado = False
                End If
            End Sub

            'Eventos Fecha2
            Private Sub dtpFecha2_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpFecha2.ValueChanged
                If dtpFecha2.Value <> DateTime.Now Then
                    Me.chkFecha2.Checked = False
                    If Me.primeraCarga = False Then Me.pnlFecha2.Visible = False 'al iniciarse no carga ninguna fecha
                    Me.primeraCarga = False
                End If
            End Sub
            Private Sub chkFecha2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkFecha2.CheckedChanged
                If Me.chkFecha2.Checked = True Then
                    Me.pnlFecha2.Visible = False
                    Me.dtpFecha2.Value = DateTime.Now
                End If
            End Sub

#End Region

#Region "Procedimientos y funciones"

            Private Sub inicializarControl()

                Me.nomColumnaBD = ""
                Me.modificado = False
                Me.cmbTipo.SelectedIndex = 0
                Me.ToolTip1.SetToolTip(Me.GroupBox1, "Seleccione las casillas para marcar la fecha actual.")
                Me.ToolTip1.SetToolTip(Me, "Seleccione las casillas para marcar la fecha actual.")
                fecha2Enabled(False)

            End Sub

            Public Sub _clear()
                Me.cmbTipo.SelectedIndex = 0
                Me.pnlFecha1.Visible = True
                Me.chkFecha1.Checked = False
                fecha2Enabled(False)
                modificado = False
            End Sub

            'Habilita/Deshabilita el campo Fecha2
            Private Sub fecha2Enabled(ByVal enable As Boolean)

                If enable = True Then
                    Me.dtpFecha2.Enabled = True
                    Me.chkFecha2.Enabled = True
                Else
                    Me.dtpFecha2.Enabled = False
                    Me.chkFecha2.Enabled = False
                End If

                Me.pnlFecha2.Visible = True
                Me.chkFecha2.Checked = False

                If Me.dtpFecha2.Enabled = True Then
                    Me.pnlFecha2.BackColor = Color.White
                Else : Me.pnlFecha2.BackColor = System.Drawing.SystemColors.Control
                End If

            End Sub

#End Region

#Region "Clases internas"



#End Region

        End Class

    End Namespace
End Namespace
