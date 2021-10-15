
Imports System.ComponentModel
Imports cons = libreriacadenaproduccion.Controles.Constantes

Namespace Controles
    Namespace Fechas

        Public Class ctrlFechaNormal

            'Declaración de atributos privados

            Private primeraCarga As Boolean = True
            Private nomColumnaBD As String
            Private campoObligatorio As Boolean
            Private fecha As String
            Private panelVisible As Boolean

            Public Sub New()

                InitializeComponent()
                Call inicializarControl()

            End Sub

#Region "Propiedades del control"

            <Category(cons.PROP_CATEG_GENE), Description("Indica si hay una fecha seleccionada"), Browsable(True)> _
            Public Property _Clear() As Boolean
                Get
                    Return Me.panelVisible
                End Get
                Set(ByVal value As Boolean)
                    Me.pnlFecha.Visible = value
                    Me.panelVisible = value
                End Set
            End Property

            <Category(cons.PROP_CATEG_GENE), Description("Fecha introducida en el control"), Browsable(True)> _
            Public Property _Fecha() As DateTime
                Get
                    Return Me.dtpFecha.Value
                End Get
                Set(ByVal value As DateTime)
                    Me.dtpFecha.Value = value
                End Set
            End Property

            <Category(cons.PROP_CATEG_GENE), Description("Fecha introducida en el control"), Browsable(False)> _
            Public ReadOnly Property _FechaFormateadaMySQL() As String
                Get
                    Return Format(Me.dtpFecha.Value, "yyyy-MM-dd hh:mm:ss")
                End Get
            End Property

            <Category(cons.PROP_CATEG_GENE), Description("es el nombre del item en la base de datos: documentos.fechaCreacion,documentos.fechaRecepcion"), Browsable(True)> _
            Public Property _itemNombre() As String
                Get
                    Return Me.nomColumnaBD
                End Get
                Set(ByVal value As String)
                    Me.nomColumnaBD = value
                End Set
            End Property

            <Category(cons.PROP_CATEG_GENE), Description("es el nombre del item en la base de datos: documentos.fechaCreacion,documentos.fechaRecepcion"), Browsable(True)> _
            Public Property _Text() As String
                Get
                    Return Me.GroupBox1.Text
                End Get
                Set(ByVal value As String)
                    Me.GroupBox1.Text = value
                End Set
            End Property

            <Category(cons.PROP_CATEG_GENE), Description("es el nombre del item en la base de datos: documentos.fechaCreacion,documentos.fechaRecepcion"), Browsable(True)> _
            Public Property _EsObligatorio() As Boolean
                Get
                    Return Me.campoObligatorio
                End Get
                Set(ByVal value As Boolean)
                    Me.campoObligatorio = value
                    Me.CtrlIndicador1.Visible = value
                End Set
            End Property

#End Region

#Region "Eventos del control"

            <Category(cons.EVEN_CATEG_GENE), Description("controlar que se ha seleccionado checkbox asociado al datatimepiker"), Browsable(True)> _
            Private Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkFecha.CheckedChanged
                If Me.chkFecha.Checked = True Then
                    Me.pnlFecha.Visible = False
                    Me.panelVisible = False
                    Me.dtpFecha.Value = DateTime.Now
                    If _EsObligatorio = True Then
                        Me.CtrlIndicador1.pImagen = My.Resources.bullet_green
                    End If
                End If
            End Sub

            <Category(cons.EVEN_CATEG_GENE), Description("controlar que el valor del datatimePikerCambie"), Browsable(True)> _
            Private Sub DateTimePicker1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpFecha.ValueChanged
                If dtpFecha.Value <> DateTime.Now Then
                    Me.chkFecha.Checked = False
                    If Me.primeraCarga = False Then
                        Me.pnlFecha.Visible = False
                        Me.panelVisible = False
                        If _EsObligatorio = True Then
                            Me.CtrlIndicador1.pImagen = My.Resources.bullet_green
                        End If
                    End If

                    Me.primeraCarga = False

                End If
            End Sub

#End Region

#Region "Procedimientos y funciones"

            Private Sub inicializarControl()

                Me.nomColumnaBD = ""
                Me.campoObligatorio = False

            End Sub

            Public Sub _inicializar()
                Me.pnlFecha.Visible = False
                Me.panelVisible = False
            End Sub

#End Region

#Region "Clases internas"



#End Region

        End Class


    End Namespace
End Namespace

