Imports System.Windows.Forms


Namespace Ordenacion

    Public Class ClsComparadorItemsListView
        Implements IComparer


        Private _indiceColumna As Integer
        Private _tipoOrdenacion As SortOrder
        Private _comparacion As tipoComparacion


        Public Enum tipoComparacion

            enteros = 1
            cadenas = 2
            fechas = 3

        End Enum


        Public Sub New()

            Me._indiceColumna = 0
            Me._tipoOrdenacion = SortOrder.Ascending
            Me._comparacion = tipoComparacion.cadenas

        End Sub


        Public Sub New(ByVal indiceColumna As Integer, ByVal tipoOrdenacion As SortOrder, ByVal comparacion As tipoComparacion)

            Me._indiceColumna = indiceColumna
            Me._tipoOrdenacion = tipoOrdenacion
            Me._comparacion = comparacion

        End Sub


        Public Property tipoOrdenacion() As SortOrder
            Get
                Return Me._tipoOrdenacion
            End Get
            Set(ByVal value As SortOrder)
                Me._tipoOrdenacion = value
            End Set
        End Property


        Public Property comparacion() As tipoComparacion
            Get
                Return Me._comparacion
            End Get
            Set(ByVal value As tipoComparacion)
                Me._comparacion = value
            End Set
        End Property


        Public Property indiceColumna() As Integer
            Get
                Return Me._indiceColumna
            End Get
            Set(ByVal value As Integer)
                Me._indiceColumna = value
            End Set
        End Property


        Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements System.Collections.IComparer.Compare

            Dim intX As Integer
            Dim intY As Integer

            Dim fecX As DateTime
            Dim fecY As DateTime

            Dim res As Integer = 0

            Dim comparadorObjetos As New CaseInsensitiveComparer()

            ' Si el tipo de ordenacion es "none" entonces no ordenamos 
            If Me._tipoOrdenacion = SortOrder.None Then Return 0

            ' Realizamos la comparación según el tipo de objetos
            Select Case Me._comparacion

                Case tipoComparacion.cadenas

                    res = comparadorObjetos.Compare(CType(x, ListViewItem).SubItems(Me._indiceColumna).Text, CType(y, ListViewItem).SubItems(Me._indiceColumna).Text)

                Case tipoComparacion.enteros

                    intX = 0
                    intY = 0

                    Integer.TryParse(CType(x, ListViewItem).SubItems(Me._indiceColumna).Text, intX)
                    Integer.TryParse(CType(y, ListViewItem).SubItems(Me._indiceColumna).Text, intY)

                    res = comparadorObjetos.Compare(intX, intY)

                Case tipoComparacion.fechas

                    fecX = DateTime.MinValue
                    fecY = DateTime.MinValue

                    DateTime.TryParse(CType(x, ListViewItem).SubItems(Me._indiceColumna).Text, fecX)
                    DateTime.TryParse(CType(y, ListViewItem).SubItems(Me._indiceColumna).Text, fecY)

                    res = comparadorObjetos.Compare(fecX, fecY)

            End Select

            ' Si el orden es descendente hay que invertir el resultado
            If Me._tipoOrdenacion = SortOrder.Ascending Then
                Return res
            Else
                Return -res
            End If

        End Function


    End Class

End Namespace
