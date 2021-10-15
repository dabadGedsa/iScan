Public Class frmMandoScaner

    Private scaner As AxScanLibCtl.AxImgScan
    Private controlScaner As clsControlScaner
   

    Public Sub New(ByRef ctrlScaner As AxScanLibCtl.AxImgScan)

        ' Llamada necesaria para el Disenyador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicializacion despu?s de la llamada a InitializeComponent().
        Try


            Me.scaner = ctrlScaner
            Me.controlScaner = New clsControlScaner(Me.scaner)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub





    Private Sub frmMandoScaner_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        inicializarDatos()

    End Sub


    Private Sub inicializarDatos()


        Me.cmbTipoArchivo.DataSource = System.Enum.GetValues(GetType(clsControlScaner.tipoArchivo))
        Me.cmbTipoArchivo.SelectedItem = Me.cmbTipoArchivo.Items(0)
        Me.cmbCalidadExp.DataSource = System.Enum.GetValues(GetType(clsControlScaner.calidadExploracion))
        Me.cmbTipoImagen.DataSource = System.Enum.GetValues(GetType(clsControlScaner.tipoImagen))
        Me.cmbTipoPagina.DataSource = System.Enum.GetValues(GetType(clsControlScaner.TipoPagina))
        Me.cmbcompresion.DataSource = System.Enum.GetValues(GetType(clsControlScaner.compresion))
        'Dim caracteristicas As ScanLibCtl.CompTypeConstants

    End Sub

    Private Sub cmbTipoArchivo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoArchivo.SelectedIndexChanged
        If Not IsNothing(Me.cmbTipoArchivo.SelectedItem) Then
            Dim TipoArchivoid As clsControlScaner.tipoArchivo = CType(Me.cmbTipoArchivo.SelectedValue, clsControlScaner.tipoArchivo)

            If Not My.Settings.PermitirDigitalizarNoTiff Then
                If TipoArchivoid <> clsControlScaner.tipoArchivo.TIFF Then
                    MessageBox.Show("Este proyecto no permite digitalizar en un formato distinto de TIFF")
                    Me.cmbTipoArchivo.SelectedItem = Me.cmbTipoArchivo.Items(0)
                End If
            End If
        End If

    End Sub

    Private Sub cmbCalidadExp_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCalidadExp.SelectedIndexChanged

    End Sub

    Private Sub cmbTipoImagen_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoImagen.SelectedIndexChanged

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        clsControlScaner.AplicarConfiguracion(CType(Me.cmbTipoArchivo.SelectedValue, clsControlScaner.tipoArchivo), CType(Me.cmbTipoImagen.SelectedValue, clsControlScaner.tipoImagen), CType(Me.cmbTipoPagina.SelectedValue, clsControlScaner.TipoPagina), CType(Me.cmbCalidadExp.SelectedValue, clsControlScaner.calidadExploracion), CType(Me.cmbcompresion.SelectedValue, clsControlScaner.compresion))
        Me.Close()
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub
End Class