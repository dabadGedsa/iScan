Imports System.Drawing
Imports System


Namespace Componentes



    Public Class ComboImagen
        Inherits System.Windows.Forms.ComboBox

        Private imgs As New Windows.Forms.ImageList

        Public Sub New()
            Me.DrawMode = Windows.Forms.DrawMode.OwnerDrawFixed

        End Sub

        Public Property ImageList() As Windows.Forms.ImageList
            Get
                Return imgs

            End Get
            Set(ByVal value As Windows.Forms.ImageList)
                imgs = value

            End Set
        End Property

        Protected Overrides Sub OnDrawItem(ByVal e As Windows.Forms.DrawItemEventArgs)
            e.DrawBackground()
            e.DrawFocusRectangle()

            If e.Index < 0 Then
                e.Graphics.DrawString(Me.Text, e.Font, New SolidBrush(e.ForeColor), e.Bounds.Left + imgs.ImageSize.Width, e.Bounds.Top)

            Else

                If TypeOf Me.Items(e.Index) Is ImageComboItem Then
                    Dim item As ImageComboItem = Me.Items(e.Index)

                    Dim forecolor As Color

                    If item.ForeColorP <> Color.FromKnownColor(KnownColor.Transparent) Then
                        forecolor = item.ForeColorP

                    Else
                        forecolor = e.ForeColor

                    End If

                    If item.ImageIndexP <> -1 Then
                        Me.ImageList.Draw(e.Graphics, e.Bounds.Left, e.Bounds.Top, item.ImageIndexP)
                        e.Graphics.DrawString(item.TextP, Font, New SolidBrush(forecolor), e.Bounds.Left + imgs.ImageSize.Width, e.Bounds.Top)

                    Else
                        e.Graphics.DrawString(item.TextP, Font, New SolidBrush(forecolor), e.Bounds.Left + imgs.ImageSize.Width, e.Bounds.Top)

                    End If

                Else
                    e.Graphics.DrawString(Me.Items(e.Index).ToString, e.Font, New SolidBrush(e.ForeColor), e.Bounds.Left + imgs.ImageSize.Width, e.Bounds.Top)

                End If


            End If

            MyBase.OnDrawItem(e)

        End Sub



    End Class

End Namespace