Imports System.Drawing
Imports System

Namespace Componentes


    Public Class ImageComboItem

        Private forecolor As Color = Color.FromKnownColor(KnownColor.Transparent)
        Private mark As Boolean = False
        Private imageIndex As Integer = -1
        Private tag As Object = Nothing
        Private text As String = Nothing

        Private o As Object = Nothing

        Public Sub New()

        End Sub

        Public Sub New(ByVal o As Object, ByVal imageIndex As Integer)
            Me.o = o
            Me.imageIndex = imageIndex

        End Sub

        Public Sub New(ByVal text As String)
            Me.text = text

        End Sub

        Public Sub New(ByVal text As String, ByVal imageindex As Integer)
            Me.text = text
            Me.imageIndex = imageindex

        End Sub

        Public Sub New(ByVal text As String, ByVal imageindex As Integer, ByVal Mark As Boolean)
            Me.text = text
            Me.imageIndex = imageindex
            Me.mark = Mark

        End Sub

        Public Sub New(ByVal text As String, ByVal imageindex As Integer, ByVal mark As Boolean, ByVal forecolor As Color)
            Me.text = text
            Me.imageIndex = imageindex
            Me.mark = mark
            Me.forecolor = forecolor

        End Sub

        Public Sub New(ByVal text As String, ByVal imageindex As Integer, ByVal mark As Boolean, ByVal forecolor As Color, ByVal tag As Object)
            Me.text = text
            Me.imageIndex = imageindex
            Me.mark = mark
            Me.forecolor = forecolor
            Me.tag = tag

        End Sub

        Public Property ItemP() As Object
            Get
                Return Me.o

            End Get
            Set(ByVal value As Object)
                Me.o = value

            End Set
        End Property

        Public Property ForeColorP() As Color
            Get
                Return Me.forecolor

            End Get
            Set(ByVal value As Color)
                Me.forecolor = value

            End Set
        End Property

        Public Property ImageIndexP() As Integer
            Get
                Return Me.imageIndex

            End Get
            Set(ByVal value As Integer)
                Me.imageIndex = value

            End Set
        End Property

        Public Property MarkP() As Boolean
            Get
                Return Me.mark

            End Get
            Set(ByVal value As Boolean)
                Me.mark = value

            End Set
        End Property

        Public Property TagP() As Object
            Get
                Return Me.tag

            End Get
            Set(ByVal value As Object)
                Me.tag = value

            End Set
        End Property

        Public Property TextP() As String
            Get
                Return Me.text

            End Get
            Set(ByVal value As String)
                Me.text = value

            End Set
        End Property

        Public Overrides Function toString() As String
            Return Me.text

        End Function




    End Class

End Namespace