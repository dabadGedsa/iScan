
Imports System.ComponentModel
Imports System.Windows.Forms
Imports cons = libreriacadenaproduccion.Controles.Constantes

Namespace Controles
    Namespace Listados

        Public Class CtrlListViewSubirBajar

            'Declaración de atributos privados

            Private anchuraColumnaPosicion As Integer
            Private mostrarPosicion As Boolean

            Public Sub New()

                InitializeComponent()
                Call inicializarControl()

            End Sub

#Region "Propiedades del control"

            <Category(cons.PROP_CATEG_GENE), Description(""), Browsable(True)> _
            Public Property pOcultarPosicion() As Boolean
                Get
                    Return Me.mostrarPosicion
                End Get
                Set(ByVal value As Boolean)
                    If value = True Then
                        Me.ListViewSubirBajar.Columns(0).Width = 0
                    Else
                        Me.ListViewSubirBajar.Columns(0).Width = Me.anchuraColumnaPosicion
                    End If
                    Me.mostrarPosicion = value
                End Set
            End Property

            <Category(cons.PROP_CATEG_GENE), Description("Devuelve la lista de todos los items del listview"), Browsable(True)> _
            Public ReadOnly Property ObtenerLista() As ListView.ListViewItemCollection
                Get
                    Return Me.ListViewSubirBajar.Items
                End Get
            End Property

            <Category(cons.PROP_CATEG_GENE), Description("Limpia los items que había en el listview y asigna la nueva lista"), Browsable(False)> _
            Public WriteOnly Property AsignarLista() As ListViewItem()
                Set(ByVal value As ListViewItem())

                    Dim indice As Integer = 1

                    Me.ListViewSubirBajar.Items.Clear()

                    For Each item As ListViewItem In value
                        Me.añadirItemConPosicion(item)
                    Next

                End Set
            End Property

            <Category(cons.PROP_CATEG_GENE), Description("Modo de visualización del listview"), Browsable(True)> _
            Public Property ModoVisualizacion() As View
                Get
                    Return Me.ListViewSubirBajar.View
                End Get
                Set(ByVal value As View)
                    Me.ListViewSubirBajar.View = value
                End Set
            End Property

            <Category(cons.PROP_CATEG_GENE), Description("Obtiene el item seleccionado en el listview. El primer elemento del item será la posición. Si no hay ningún elemento seleccionado devuelve nothing"), Browsable(False)> _
            Public ReadOnly Property ObtenerElementoSeleccionado() As ListViewItem
                Get
                    If Me.ListViewSubirBajar.SelectedItems.Count > 0 Then
                        Return Me.ListViewSubirBajar.SelectedItems(0)
                    Else
                        Return Nothing
                    End If
                End Get
            End Property

            <Category(cons.PROP_CATEG_GENE), Description("Devuelve la lista de columnas del listview. La primera columna será la de la posición"), Browsable(False)> _
            Public ReadOnly Property ObtenerColumnas() As ListView.ColumnHeaderCollection
                Get
                    Return Me.ListViewSubirBajar.Columns
                End Get
            End Property

            <Category(cons.PROP_CATEG_GENE), Description("Muestra u oculta los botones para subir y bajar"), Browsable(True)> _
            Public Property _VerBotones() As Boolean
                Get
                    Return Me.ctrlSubir.Visible
                End Get
                Set(ByVal value As Boolean)

                    If Me.ctrlBajar.Visible <> value Then
                        Me.ctrlSubir.Visible = value
                        Me.ctrlBajar.Visible = value

                        If value = True Then
                            Me.ListViewSubirBajar.Width = Me.ListViewSubirBajar.Width - (Me.ctrlBajar.Width + 5)
                        Else
                            Me.ListViewSubirBajar.Width = Me.ListViewSubirBajar.Width + (Me.ctrlBajar.Width + 5)
                        End If
                    End If

                End Set
            End Property

            <Category(cons.PROP_CATEG_GENE), Description("Muestra u oculta la columna posición"), Browsable(True)> _
            Public Property _VerPosicion() As Boolean
                Get
                    Return (Me.mostrarPosicion)
                End Get
                Set(ByVal value As Boolean)
                    If value Then
                        For Each item As ListViewItem In Me.ListViewSubirBajar.Items
                            item.Text = item.Name
                        Next
                        Me.ListViewSubirBajar.Columns(0).Text = "Posición"
                    Else
                        For Each item As ListViewItem In Me.ListViewSubirBajar.Items
                            item.Text = ""
                        Next
                        Me.ListViewSubirBajar.Columns(0).Text = ""
                    End If
                    Me.mostrarPosicion = value
                End Set
            End Property

            <Category(cons.PROP_CATEG_GENE), Description("Asigna un imageList para el listview en todas las vistas"), Browsable(True)> _
            Public Property _listaImagenes() As ImageList
                Get
                    Return Me.ListViewSubirBajar.SmallImageList
                End Get
                Set(ByVal value As ImageList)
                    Me.ListViewSubirBajar.SmallImageList = value
                    Me.ListViewSubirBajar.LargeImageList = value
                    Me.ListViewSubirBajar.StateImageList = value
                End Set
            End Property

#End Region

#Region "Eventos del control"

            Private Sub ctrlSubir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctrlSubir.Click

                Dim itemSeleccionado As ListViewItem
                Dim itemAnterior As ListViewItem

                ' Si hay mas de un elemento en la lista y hay algun elemento seleccionado:
                If (Me.ListViewSubirBajar.SelectedItems.Count > 0) And (Me.ListViewSubirBajar.Items.Count > 1) Then
                    ' Si el elemento seleccionado no ocupa la primera posicion
                    If Me.ListViewSubirBajar.SelectedItems(0).Index <> 0 Then

                        ' Intercambio el valor de la columna posicion entre el item seleccionado y el posterior
                        itemAnterior = Me.ListViewSubirBajar.Items(Me.ListViewSubirBajar.SelectedItems(0).Index - 1)
                        itemSeleccionado = Me.ListViewSubirBajar.SelectedItems(0)

                        itemAnterior.Name = itemAnterior.Name + 1
                        itemSeleccionado.Name = itemSeleccionado.Name - 1

                        If Me.mostrarPosicion Then
                            itemAnterior.Text = itemAnterior.Text + 1
                            itemSeleccionado.Text = itemSeleccionado.Text - 1
                        End If

                        Me.ListViewSubirBajar.Sort()

                    End If
                End If

            End Sub

            Private Sub ctrlBajar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctrlBajar.Click

                Dim itemSeleccionado As ListViewItem
                Dim itemPosterior As ListViewItem

                ' Si hay mas de un elemento en la lista y hay algun elemento seleccionado:
                If (Me.ListViewSubirBajar.SelectedItems.Count > 0) And (Me.ListViewSubirBajar.Items.Count > 1) Then
                    ' Si el elemento seleccionado no ocupa la última posicion
                    If Me.ListViewSubirBajar.SelectedItems(0).Index < Me.ListViewSubirBajar.Items.Count - 1 Then

                        ' Intercambio el valor de la columna posicion entre el item seleccionado y el posterior
                        itemPosterior = Me.ListViewSubirBajar.Items(Me.ListViewSubirBajar.SelectedItems(0).Index + 1)
                        itemSeleccionado = Me.ListViewSubirBajar.SelectedItems(0)

                        itemPosterior.Name = itemPosterior.Name - 1
                        itemSeleccionado.Name = itemSeleccionado.Name + 1

                        If Me.mostrarPosicion Then
                            itemPosterior.Text = itemPosterior.Text - 1
                            itemSeleccionado.Text = itemSeleccionado.Text + 1
                        End If

                        Me.ListViewSubirBajar.Sort()

                    End If
                End If

            End Sub

            <Category(cons.EVEN_CATEG_GENE), Description("Se produce al cambiar de índice."), Browsable(True)> _
            Public Event _indiceListViewCambiado As EventHandler
            Private Sub ListViewSubirBajar_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewSubirBajar.SelectedIndexChanged
                RaiseEvent _indiceListViewCambiado(sender, e)
            End Sub

            <Category(cons.EVEN_CATEG_GENE), Description("Arrastrar y soltar"), Browsable(True)> _
            Public Event eDragEnter As DragEventHandler
            Private Sub ListViewSubirBajar_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles ListViewSubirBajar.DragEnter
                RaiseEvent eDragEnter(Me, e)
            End Sub

            <Category(cons.EVEN_CATEG_GENE), Description("Arrastrar y soltar"), Browsable(True)> _
            Public Event eDragDrop As DragEventHandler
            Private Sub ListViewSubirBajar_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles ListViewSubirBajar.DragDrop
                RaiseEvent eDragDrop(Me, e)
            End Sub

#End Region

#Region "Procedimientos y funciones"

            Private Sub inicializarControl()

                Me.anchuraColumnaPosicion = 60
                Me.mostrarPosicion = True
                Me.ListViewSubirBajar.ListViewItemSorter = New ComparadorEnteros()

            End Sub

            Public Sub _limpiarListView()
                Me.ListViewSubirBajar.Items.Clear()
            End Sub

            ' Hay que cargar las columnas si se quiere visualizar la información en modo "details"
            Public Sub asignarColumnas(ByVal listaColumnas As String())

                Me.ListViewSubirBajar.Columns.Clear()

                If Me.mostrarPosicion Then
                    Me.ListViewSubirBajar.Columns.Add("Posición", 60)
                Else
                    Me.ListViewSubirBajar.Columns.Add("", 60)
                End If

                For Each col As String In listaColumnas
                    Me.ListViewSubirBajar.Columns.Add(col)
                Next

            End Sub

            Public Sub asignarColumnas(ByVal listaColumnas As ColumnHeader())

                If listaColumnas IsNot Nothing Then
                    Me.ListViewSubirBajar.Columns.Clear()

                    If Me.mostrarPosicion Then
                        Me.ListViewSubirBajar.Columns.Add("Posición", 60)
                    Else
                        Me.ListViewSubirBajar.Columns.Add("", 60)
                    End If

                    Me.ListViewSubirBajar.Columns.AddRange(listaColumnas)
                End If

            End Sub

            Public Function obtenerElemento(ByVal indice As Integer) As ListViewItem

                If (indice >= 0) And (indice < Me.ListViewSubirBajar.Items.Count) Then
                    Return Me.ListViewSubirBajar.Items(indice)
                Else
                    Return Nothing
                End If

            End Function

            Public Sub añadirElemento(ByVal item As ListViewItem)

                If item IsNot Nothing Then
                    Me.añadirItemConPosicion(item)
                End If

            End Sub

            Public Sub eliminarElemento(ByVal indice As Integer)

                If (indice >= 0) And (indice < Me.ListViewSubirBajar.Items.Count) Then
                    Me.ListViewSubirBajar.Items(indice).Remove()
                    Me.recalcularPosicion()
                End If

            End Sub

            Private Sub recalcularPosicion()

                Dim posicion As Integer = 1

                For Each item As ListViewItem In Me.ListViewSubirBajar.Items
                    If Me.mostrarPosicion Then
                        item.Text = posicion
                        item.Name = posicion
                    Else
                        item.Text = ""
                        item.Name = posicion
                    End If
                    posicion += 1
                Next

            End Sub

            Private Sub añadirItemConPosicion(ByVal item As ListViewItem)

                Dim itemNuevo As ListViewItem

                If Me.mostrarPosicion Then
                    itemNuevo = New ListViewItem(Me.ListViewSubirBajar.Items.Count + 1)
                Else
                    itemNuevo = New ListViewItem("")
                End If

                itemNuevo.Name = Me.ListViewSubirBajar.Items.Count + 1
                itemNuevo.ImageIndex = item.ImageIndex

                For Each subitem As ListViewItem.ListViewSubItem In item.SubItems
                    'si aqui añadimos un .name y el nombre de la columna luego es mas facil de localizar
                    itemNuevo.SubItems.Add(subitem.Text)
                    Try
                        itemNuevo.SubItems(itemNuevo.SubItems.Count - 1).Name = subitem.Name
                    Catch ex As Exception

                    End Try
                Next

                Me.ListViewSubirBajar.Items.Add(itemNuevo)

            End Sub

#End Region

#Region "Clases internas"

            Private Class ComparadorEnteros
                Implements IComparer

                Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements System.Collections.IComparer.Compare

                    Dim valorX As Integer = Integer.Parse(CType(x, ListViewItem).Name)
                    Dim valorY As Integer = Integer.Parse(CType(y, ListViewItem).Name)

                    If valorX = valorY Then Return 0
                    If valorX > valorY Then Return 1
                    If valorX < valorY Then Return -1

                End Function

            End Class

#End Region

        End Class

    End Namespace
End Namespace