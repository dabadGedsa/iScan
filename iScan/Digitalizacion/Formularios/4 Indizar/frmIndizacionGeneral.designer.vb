<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmIndizacionGeneral
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Disenyador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Disenyador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Disenyador de Windows Forms.  
    'No lo modifique con el editor de c?digo.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIndizacionGeneral))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.CtrlBotonGrande2 = New LibreriaCadenaProduccion.Controles.Botones.CtrlBotonGrande()
        Me.CtrlBotonGrande1 = New LibreriaCadenaProduccion.Controles.Botones.CtrlBotonGrande()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.idDocumento = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.idLote = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Pagina = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.nomArchivoTIF = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Numhistoria = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.FechaDoc = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.fechaInicio = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.fechaTermino = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Serv = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.tipoDocumento = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CIP = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.DNI = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Paciente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.tipoActo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.codigoActo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.BarCodeDet = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.incidencia = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Eliminada = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Indizada = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.primera = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContenidoEn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ErrorEnvio = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SIP = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Indizado = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.IMGeditPrincipal = New AxImgeditLibCtl.AxImgEdit()
        Me.ImgEditLupa = New AxImgeditLibCtl.AxImgEdit()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.CtrlIndizacionEpidemiologia1 = New Digitalización.ctrlIndizacionLaRibera()
        Me.GroupBox2.SuspendLayout()
        CType(Me.IMGeditPrincipal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImgEditLupa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.CtrlBotonGrande2)
        Me.GroupBox2.Controls.Add(Me.CtrlBotonGrande1)
        Me.GroupBox2.Location = New System.Drawing.Point(869, 667)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(140, 70)
        Me.GroupBox2.TabIndex = 116
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Lote"
        '
        'CtrlBotonGrande2
        '
        Me.CtrlBotonGrande2.BackColor = System.Drawing.Color.Transparent
        Me.CtrlBotonGrande2.EnabledBoton = True
        Me.CtrlBotonGrande2.Location = New System.Drawing.Point(15, 19)
        Me.CtrlBotonGrande2.Margin = New System.Windows.Forms.Padding(4)
        Me.CtrlBotonGrande2.Name = "CtrlBotonGrande2"
        Me.CtrlBotonGrande2.pImagenMouseEnter = CType(resources.GetObject("CtrlBotonGrande2.pImagenMouseEnter"), System.Drawing.Image)
        Me.CtrlBotonGrande2.pImagenMouseLeave = CType(resources.GetObject("CtrlBotonGrande2.pImagenMouseLeave"), System.Drawing.Image)
        Me.CtrlBotonGrande2.pImagenMouseOver = CType(resources.GetObject("CtrlBotonGrande2.pImagenMouseOver"), System.Drawing.Image)
        Me.CtrlBotonGrande2.Size = New System.Drawing.Size(54, 41)
        Me.CtrlBotonGrande2.TabIndex = 51
        Me.CtrlBotonGrande2.TabStop = False
        Me.CtrlBotonGrande2.Tag = "50"
        Me.CtrlBotonGrande2.TextoBoton = "Guardar"
        '
        'CtrlBotonGrande1
        '
        Me.CtrlBotonGrande1.BackColor = System.Drawing.Color.Transparent
        Me.CtrlBotonGrande1.EnabledBoton = True
        Me.CtrlBotonGrande1.Location = New System.Drawing.Point(75, 19)
        Me.CtrlBotonGrande1.Margin = New System.Windows.Forms.Padding(4)
        Me.CtrlBotonGrande1.Name = "CtrlBotonGrande1"
        Me.CtrlBotonGrande1.pImagenMouseEnter = CType(resources.GetObject("CtrlBotonGrande1.pImagenMouseEnter"), System.Drawing.Image)
        Me.CtrlBotonGrande1.pImagenMouseLeave = CType(resources.GetObject("CtrlBotonGrande1.pImagenMouseLeave"), System.Drawing.Image)
        Me.CtrlBotonGrande1.pImagenMouseOver = CType(resources.GetObject("CtrlBotonGrande1.pImagenMouseOver"), System.Drawing.Image)
        Me.CtrlBotonGrande1.Size = New System.Drawing.Size(59, 41)
        Me.CtrlBotonGrande1.TabIndex = 50
        Me.CtrlBotonGrande1.TabStop = False
        Me.CtrlBotonGrande1.Tag = "50"
        Me.CtrlBotonGrande1.TextoBoton = "Cerrar Lote"
        '
        'ListView1
        '
        Me.ListView1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView1.AutoArrange = False
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.idDocumento, Me.idLote, Me.Pagina, Me.nomArchivoTIF, Me.Numhistoria, Me.FechaDoc, Me.fechaInicio, Me.fechaTermino, Me.Serv, Me.tipoDocumento, Me.CIP, Me.DNI, Me.Paciente, Me.tipoActo, Me.codigoActo, Me.BarCodeDet, Me.incidencia, Me.Eliminada, Me.Indizada, Me.primera, Me.ContenidoEn, Me.ErrorEnvio, Me.SIP})
        Me.ListView1.FullRowSelect = True
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(445, 354)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(564, 135)
        Me.ListView1.TabIndex = 6
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'Numhistoria
        '
        Me.Numhistoria.Text = "NHC"
        '
        'FechaDoc
        '
        Me.FechaDoc.DisplayIndex = 6
        Me.FechaDoc.Text = "F. Documento"
        Me.FechaDoc.Width = 80
        '
        'fechaInicio
        '
        Me.fechaInicio.DisplayIndex = 16
        Me.fechaInicio.Text = "Fecha Inicio"
        '
        'fechaTermino
        '
        Me.fechaTermino.DisplayIndex = 17
        Me.fechaTermino.Text = "Fecha Termino"
        '
        'Serv
        '
        Me.Serv.Text = "Servicio"
        '
        'tipoDocumento
        '
        Me.tipoDocumento.DisplayIndex = 5
        '
        'CIP
        '
        Me.CIP.DisplayIndex = 11
        Me.CIP.Text = "CIP"
        '
        'DNI
        '
        Me.DNI.DisplayIndex = 12
        Me.DNI.Text = "DNI"
        '
        'Paciente
        '
        Me.Paciente.DisplayIndex = 15
        Me.Paciente.Text = "Paciente"
        '
        'tipoActo
        '
        Me.tipoActo.Text = "Tipo Acto"
        '
        'codigoActo
        '
        Me.codigoActo.Text = "codigoActo"
        '
        'BarCodeDet
        '
        Me.BarCodeDet.DisplayIndex = 7
        Me.BarCodeDet.Text = "BarCodeDet"
        Me.BarCodeDet.Width = 80
        '
        'incidencia
        '
        Me.incidencia.DisplayIndex = 9
        '
        'Eliminada
        '
        Me.Eliminada.DisplayIndex = 10
        Me.Eliminada.Text = "Eliminada"
        '
        'Indizada
        '
        Me.Indizada.Text = "Indizada"
        '
        'primera
        '
        Me.primera.Text = "primera"
        '
        'ContenidoEn
        '
        Me.ContenidoEn.Text = "ContenidoEn"
        '
        'ErrorEnvio
        '
        Me.ErrorEnvio.Text = "ErrorEnvio"
        '
        'SIP
        '
        Me.SIP.Text = "SIP"
        '
        'Indizado
        '
        Me.Indizado.Text = "Indizada"
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RichTextBox1.ForeColor = System.Drawing.Color.Red
        Me.RichTextBox1.Location = New System.Drawing.Point(445, 667)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(418, 47)
        Me.RichTextBox1.TabIndex = 117
        Me.RichTextBox1.Text = ""
        '
        'IMGeditPrincipal
        '
        Me.IMGeditPrincipal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IMGeditPrincipal.Location = New System.Drawing.Point(1, 4)
        Me.IMGeditPrincipal.Name = "IMGeditPrincipal"
        Me.IMGeditPrincipal.OcxState = CType(resources.GetObject("IMGeditPrincipal.OcxState"), System.Windows.Forms.AxHost.State)
        Me.IMGeditPrincipal.Size = New System.Drawing.Size(438, 710)
        Me.IMGeditPrincipal.TabIndex = 0
        Me.IMGeditPrincipal.TabStop = False
        Me.IMGeditPrincipal.Tag = "100"
        '
        'ImgEditLupa
        '
        Me.ImgEditLupa.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ImgEditLupa.Location = New System.Drawing.Point(445, 495)
        Me.ImgEditLupa.Name = "ImgEditLupa"
        Me.ImgEditLupa.OcxState = CType(resources.GetObject("ImgEditLupa.OcxState"), System.Windows.Forms.AxHost.State)
        Me.ImgEditLupa.Size = New System.Drawing.Size(564, 166)
        Me.ImgEditLupa.TabIndex = 131
        Me.ImgEditLupa.TabStop = False
        Me.ImgEditLupa.Tag = "100"
        '
        'Button2
        '
        Me.Button2.Image = Global.Digitalización.My.Resources.Resources.zoom
        Me.Button2.Location = New System.Drawing.Point(1, 4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(31, 23)
        Me.Button2.TabIndex = 120
        Me.Button2.UseVisualStyleBackColor = True
        '
        'CtrlIndizacionEpidemiologia1
        '
        Me.CtrlIndizacionEpidemiologia1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CtrlIndizacionEpidemiologia1.Location = New System.Drawing.Point(445, 12)
        Me.CtrlIndizacionEpidemiologia1.Margin = New System.Windows.Forms.Padding(4)
        Me.CtrlIndizacionEpidemiologia1.Name = "CtrlIndizacionEpidemiologia1"
        Me.CtrlIndizacionEpidemiologia1.Size = New System.Drawing.Size(565, 336)
        Me.CtrlIndizacionEpidemiologia1.TabIndex = 0
        '
        'frmIndizacionGeneral
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1016, 716)
        Me.Controls.Add(Me.ImgEditLupa)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.IMGeditPrincipal)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.CtrlIndizacionEpidemiologia1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "frmIndizacionGeneral"
        Me.Text = "Hospital Virgen de la Salud - Indización"
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.IMGeditPrincipal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImgEditLupa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents IMGeditPrincipal As AxImgeditLibCtl.AxImgEdit
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents CtrlBotonGrande1 As LibreriaCadenaProduccion.Controles.Botones.CtrlBotonGrande
    Friend WithEvents CtrlIndizacionEpidemiologia1 As Digitalización.ctrlIndizacionLaRibera
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents idDocumento As System.Windows.Forms.ColumnHeader
    Friend WithEvents idLote As System.Windows.Forms.ColumnHeader
    Friend WithEvents Pagina As System.Windows.Forms.ColumnHeader
    Friend WithEvents nomArchivoTIF As System.Windows.Forms.ColumnHeader
    Friend WithEvents tipoDocumento As System.Windows.Forms.ColumnHeader
    Friend WithEvents incidencia As System.Windows.Forms.ColumnHeader
    Friend WithEvents Indizado As System.Windows.Forms.ColumnHeader
    Friend WithEvents Numicu As System.Windows.Forms.ColumnHeader
    Friend WithEvents Servicio As System.Windows.Forms.ColumnHeader
    Friend WithEvents area As System.Windows.Forms.ColumnHeader
    Friend WithEvents nombre As System.Windows.Forms.ColumnHeader
    Friend WithEvents apellido1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents apellido2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents Numhistoria As System.Windows.Forms.ColumnHeader
    Friend WithEvents FechaDoc As System.Windows.Forms.ColumnHeader
    Friend WithEvents BarCodeDet As System.Windows.Forms.ColumnHeader
    Friend WithEvents Serv As System.Windows.Forms.ColumnHeader
    Friend WithEvents Eliminada As System.Windows.Forms.ColumnHeader
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents CtrlBotonGrande2 As LibreriaCadenaProduccion.Controles.Botones.CtrlBotonGrande
    Friend WithEvents CIP As ColumnHeader
    Friend WithEvents DNI As ColumnHeader
    Friend WithEvents tipoActo As ColumnHeader
    Friend WithEvents Paciente As ColumnHeader
    Friend WithEvents codigoActo As ColumnHeader
    Friend WithEvents fechaInicio As ColumnHeader
    Friend WithEvents fechaTermino As ColumnHeader
    Friend WithEvents Indizada As ColumnHeader
    Friend WithEvents primera As ColumnHeader
    Friend WithEvents ImgEditLupa As AxImgeditLibCtl.AxImgEdit
    Friend WithEvents ContenidoEn As ColumnHeader
    Friend WithEvents ErrorEnvio As ColumnHeader
    Friend WithEvents SIP As ColumnHeader
End Class
