Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles

Namespace Componentes
    Public Class CtrlCheckBox

        Public Class CheckComboBoxItem

            Dim _checkState As Boolean = False
            Dim _text As String

            Public Sub New(ByVal texto As String, ByVal estadoini As Boolean)
                _checkState = estadoini
                _text = texto
            End Sub

            Property estado() As Boolean
                Get
                    Return Me._checkState
                End Get
                Set(ByVal value As Boolean)
                    Me._checkState = value
                End Set
            End Property

            Property text() As String
                Get
                    Return Me._text
                End Get
                Set(ByVal value As String)
                    Me._text = value
                End Set
            End Property

            Public Overrides Function ToString() As String

                Return Me._text
            End Function

        End Class



        Partial Public Class CheckComboBox
            Inherits ComboBox

            Private Sub InitializeComponent()
                Me.DrawMode = Windows.Forms.DrawMode.OwnerDrawFixed

                Me.SelectedText = "texto"
            End Sub


            Public Sub comboDrawItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles Me.DrawItem

                If e.Index = -1 Then
                    Return 'comprobar que el indice es valido 
                End If

                'comproabar que es un item de los check si no lo es escribimos un string 
                If Me.Items(e.Index).GetType.Name.ToString Is "CheckComboBoxItem" Then

                    e.Graphics.DrawString(Items(e.Index).ToString, Me.Font, Brushes.Black, New Point(e.Bounds.X, e.Bounds.Y))
                    Return
                End If

                Dim box As CheckComboBoxItem

                box = Me.Items(e.Index)

                CheckBoxRenderer.RenderMatchingApplicationState = True
                CheckBoxRenderer.DrawCheckBox(e.Graphics, Me.ClientRectangle.Location, e.Bounds, box.text, Me.Font, TextFormatFlags.HorizontalCenter, False, box.estado)

            End Sub

            Public Sub comboSelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.SelectedIndexChanged

            End Sub

        End Class





    End Class

End Namespace

