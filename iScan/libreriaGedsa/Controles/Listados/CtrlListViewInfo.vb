Imports System.Windows.Forms

Namespace Controles
    Namespace Listados


        Public Class CtrlListViewInfo


            Public ReadOnly Property _Items() As ListView.ListViewItemCollection
                Get
                    Return Me.ListViewInfo.Items
                End Get
            End Property


            Public Sub _añadirMensaje(ByVal mensaje As String, ByVal color As Color, ByVal numIcono As Integer)

                Dim item As ListViewItem

                item = New ListViewItem(" " & mensaje, numIcono)
                item.ForeColor = color
                item.ToolTipText = item.Text

                Me.ListViewInfo.Items.Add(item)
                item.EnsureVisible()

                Me.ListViewInfo.Refresh()

            End Sub


            Private Sub CtrlListViewInfo_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
                Me.ListViewInfo.Columns(0).Width = Me.ListViewInfo.Width - 50
            End Sub


        End Class

    End Namespace
End Namespace