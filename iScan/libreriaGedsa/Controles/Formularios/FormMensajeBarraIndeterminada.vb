Namespace Controles
    Namespace Formularios

        Public Enum estilo
            estilo1 = 1
            estilo2 = 2
        End Enum

        Public Class FormMensajeBarraIndeterminada

            Private estiloImagen As estilo

            Public Sub New(ByVal mensaje As String)

                ' Llamada necesaria para el Diseñador de Windows Forms.
                InitializeComponent()

                ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

                Me.LabelMensaje.Text = mensaje
                Me.estiloImagen = estilo.estilo1

            End Sub

            Public Property _EstiloImagen() As estilo
                Get
                    Return Me.estiloImagen
                End Get

                Set(ByVal value As estilo)

                    Select Case value

                        Case estilo.estilo1
                            Me.PictureBox.Image = My.Resources.SGG_ProgessBar_2
                            Me.PictureBox.SizeMode = Windows.Forms.PictureBoxSizeMode.StretchImage
                            Me.PictureBox.Location = New Point(34, 100)
                            Me.PictureBox.Size = New System.Drawing.Size(387, 25)
                            Me.Invalidate()

                        Case estilo.estilo2
                            Me.PictureBox.Image = My.Resources.progressbar4
                            Me.PictureBox.SizeMode = Windows.Forms.PictureBoxSizeMode.StretchImage
                            Me.PictureBox.Location = New Point(124, 104)
                            Me.PictureBox.Size = New System.Drawing.Size(210, 21)
                            Me.Invalidate()

                    End Select

                End Set

            End Property

        End Class

    End Namespace
End Namespace
