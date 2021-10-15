Public NotInheritable Class frmAcerca

    Dim var_aplicacion_nombre As String = ""
    Dim var_aplicacion_version As String = ""

    Sub New(ByVal aplicacion_nombre As String, ByVal aplicacion_version As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        var_aplicacion_nombre = aplicacion_nombre
        var_aplicacion_version = aplicacion_version
    End Sub

    Private Sub frmAcerca_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Establezca el título del formulario.
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Me.Text = String.Format("Acerca de {0}", ApplicationTitle)
        ' Inicialice todo el texto mostrado en el cuadro Acerca de.

        '    cuadro de diálogo propiedades del proyecto (bajo el menú "Proyecto").
        Me.LabelProductName.Text = var_aplicacion_nombre
        Me.LabelVersion.Text = "Versión " & var_aplicacion_version
        Me.LabelCopyright.Text = "Gedsa 2008"
        Me.LabelCompanyName.Text = "Gedsa"
        Me.TextBoxDescription.Text = "Aplicación para la digitalización de documentos."
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Me.Close()
    End Sub

    Private Sub AxImgEdit1_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AxImgEdit1.Close

    End Sub

    Private Sub LabelProductName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelProductName.Click

    End Sub
End Class
