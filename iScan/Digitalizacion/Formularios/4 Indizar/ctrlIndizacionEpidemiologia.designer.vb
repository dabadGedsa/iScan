<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlIndizacionEpidemiologia

    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblCodDocumento = New System.Windows.Forms.Label
        Me.cmb_codigo_doc = New System.Windows.Forms.ComboBox
        Me.txtCodigoDoc = New System.Windows.Forms.TextBox
        Me.SD = New System.Windows.Forms.CheckBox
        Me.UCSI = New System.Windows.Forms.CheckBox
        Me.txtICUOrion = New System.Windows.Forms.TextBox
        Me.ConInf = New System.Windows.Forms.CheckBox
        Me.Area1 = New System.Windows.Forms.TextBox
        Me.pnlCambio = New System.Windows.Forms.Panel
        Me.mTxtFechaDia = New System.Windows.Forms.MaskedTextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblservicio_descripcion = New System.Windows.Forms.Label
        Me.mtxtfechaTerminio = New System.Windows.Forms.MaskedTextBox
        Me.mtxtFEchainicio = New System.Windows.Forms.MaskedTextBox
        Me.ListView1 = New System.Windows.Forms.ListView
        Me.NHC = New System.Windows.Forms.ColumnHeader
        Me.EPISODIO = New System.Windows.Forms.ColumnHeader
        Me.LITSERVICIO = New System.Windows.Forms.ColumnHeader
        Me.FECHAINICIO = New System.Windows.Forms.ColumnHeader
        Me.FECHAFIN = New System.Windows.Forms.ColumnHeader
        Me.SERVICIO = New System.Windows.Forms.ColumnHeader
        Me.AREA = New System.Windows.Forms.ColumnHeader
        Me.Orion = New System.Windows.Forms.ColumnHeader
        Me.lblservicio = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblpagina = New System.Windows.Forms.Label
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox
        Me.txtPagVinculada = New System.Windows.Forms.TextBox
        Me.txtServicio = New System.Windows.Forms.TextBox
        Me.cmbIncidencias = New System.Windows.Forms.ComboBox
        Me.chkIncidencia = New System.Windows.Forms.CheckBox
        Me.txtPaciente = New System.Windows.Forms.TextBox
        Me.txtNumHistoria = New System.Windows.Forms.TextBox
        Me.txtNumicu = New System.Windows.Forms.TextBox
        Me.chkPagVinculada = New System.Windows.Forms.CheckBox
        Me.cmbServicios = New System.Windows.Forms.ComboBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.lblNumHistoria = New System.Windows.Forms.Label
        Me.lblIcutec = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblCodDocumento)
        Me.GroupBox1.Controls.Add(Me.cmb_codigo_doc)
        Me.GroupBox1.Controls.Add(Me.txtCodigoDoc)
        Me.GroupBox1.Controls.Add(Me.SD)
        Me.GroupBox1.Controls.Add(Me.UCSI)
        Me.GroupBox1.Controls.Add(Me.txtICUOrion)
        Me.GroupBox1.Controls.Add(Me.ConInf)
        Me.GroupBox1.Controls.Add(Me.Area1)
        Me.GroupBox1.Controls.Add(Me.pnlCambio)
        Me.GroupBox1.Controls.Add(Me.mTxtFechaDia)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.lblservicio_descripcion)
        Me.GroupBox1.Controls.Add(Me.mtxtfechaTerminio)
        Me.GroupBox1.Controls.Add(Me.mtxtFEchainicio)
        Me.GroupBox1.Controls.Add(Me.ListView1)
        Me.GroupBox1.Controls.Add(Me.lblservicio)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lblpagina)
        Me.GroupBox1.Controls.Add(Me.RichTextBox1)
        Me.GroupBox1.Controls.Add(Me.txtPagVinculada)
        Me.GroupBox1.Controls.Add(Me.txtServicio)
        Me.GroupBox1.Controls.Add(Me.cmbIncidencias)
        Me.GroupBox1.Controls.Add(Me.chkIncidencia)
        Me.GroupBox1.Controls.Add(Me.txtPaciente)
        Me.GroupBox1.Controls.Add(Me.txtNumHistoria)
        Me.GroupBox1.Controls.Add(Me.txtNumicu)
        Me.GroupBox1.Controls.Add(Me.chkPagVinculada)
        Me.GroupBox1.Controls.Add(Me.cmbServicios)
        Me.GroupBox1.Controls.Add(Me.Label26)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.lblNumHistoria)
        Me.GroupBox1.Controls.Add(Me.lblIcutec)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(524, 326)
        Me.GroupBox1.TabIndex = 148
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Indizacion"
        '
        'lblCodDocumento
        '
        Me.lblCodDocumento.AutoSize = True
        Me.lblCodDocumento.BackColor = System.Drawing.Color.Transparent
        Me.lblCodDocumento.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblCodDocumento.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCodDocumento.Location = New System.Drawing.Point(23, 306)
        Me.lblCodDocumento.Name = "lblCodDocumento"
        Me.lblCodDocumento.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblCodDocumento.Size = New System.Drawing.Size(57, 13)
        Me.lblCodDocumento.TabIndex = 198
        Me.lblCodDocumento.Text = "Tipo. Doc:"
        '
        'cmb_codigo_doc
        '
        Me.cmb_codigo_doc.BackColor = System.Drawing.SystemColors.Window
        Me.cmb_codigo_doc.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmb_codigo_doc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_codigo_doc.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmb_codigo_doc.Location = New System.Drawing.Point(133, 303)
        Me.cmb_codigo_doc.Name = "cmb_codigo_doc"
        Me.cmb_codigo_doc.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmb_codigo_doc.Size = New System.Drawing.Size(191, 21)
        Me.cmb_codigo_doc.TabIndex = 197
        Me.cmb_codigo_doc.TabStop = False
        '
        'txtCodigoDoc
        '
        Me.txtCodigoDoc.AcceptsReturn = True
        Me.txtCodigoDoc.BackColor = System.Drawing.SystemColors.Window
        Me.txtCodigoDoc.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCodigoDoc.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCodigoDoc.Location = New System.Drawing.Point(86, 303)
        Me.txtCodigoDoc.MaxLength = 3
        Me.txtCodigoDoc.Name = "txtCodigoDoc"
        Me.txtCodigoDoc.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtCodigoDoc.Size = New System.Drawing.Size(41, 20)
        Me.txtCodigoDoc.TabIndex = 5
        '
        'SD
        '
        Me.SD.Cursor = System.Windows.Forms.Cursors.Default
        Me.SD.ForeColor = System.Drawing.SystemColors.ControlText
        Me.SD.Location = New System.Drawing.Point(388, 13)
        Me.SD.Name = "SD"
        Me.SD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SD.Size = New System.Drawing.Size(116, 15)
        Me.SD.TabIndex = 194
        Me.SD.TabStop = False
        Me.SD.Text = "Sin documentos"
        Me.SD.UseVisualStyleBackColor = False
        '
        'UCSI
        '
        Me.UCSI.Cursor = System.Windows.Forms.Cursors.Default
        Me.UCSI.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UCSI.Location = New System.Drawing.Point(326, 13)
        Me.UCSI.Name = "UCSI"
        Me.UCSI.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UCSI.Size = New System.Drawing.Size(62, 15)
        Me.UCSI.TabIndex = 193
        Me.UCSI.TabStop = False
        Me.UCSI.Text = "UCSI"
        Me.UCSI.UseVisualStyleBackColor = False
        '
        'txtICUOrion
        '
        Me.txtICUOrion.AcceptsReturn = True
        Me.txtICUOrion.BackColor = System.Drawing.Color.White
        Me.txtICUOrion.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtICUOrion.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtICUOrion.Location = New System.Drawing.Point(326, 65)
        Me.txtICUOrion.MaxLength = 0
        Me.txtICUOrion.Name = "txtICUOrion"
        Me.txtICUOrion.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtICUOrion.Size = New System.Drawing.Size(88, 20)
        Me.txtICUOrion.TabIndex = 192
        Me.txtICUOrion.TabStop = False
        '
        'ConInf
        '
        Me.ConInf.BackColor = System.Drawing.SystemColors.Control
        Me.ConInf.Cursor = System.Windows.Forms.Cursors.Default
        Me.ConInf.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ConInf.Location = New System.Drawing.Point(204, 13)
        Me.ConInf.Name = "ConInf"
        Me.ConInf.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ConInf.Size = New System.Drawing.Size(106, 22)
        Me.ConInf.TabIndex = 191
        Me.ConInf.TabStop = False
        Me.ConInf.Text = "Hoja evolución"
        Me.ConInf.UseVisualStyleBackColor = False
        '
        'Area1
        '
        Me.Area1.AcceptsReturn = True
        Me.Area1.BackColor = System.Drawing.SystemColors.Window
        Me.Area1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Area1.Enabled = False
        Me.Area1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Area1.Location = New System.Drawing.Point(86, 281)
        Me.Area1.MaxLength = 4
        Me.Area1.Name = "Area1"
        Me.Area1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Area1.Size = New System.Drawing.Size(41, 20)
        Me.Area1.TabIndex = 6
        Me.Area1.TabStop = False
        '
        'pnlCambio
        '
        Me.pnlCambio.BackColor = System.Drawing.Color.Lime
        Me.pnlCambio.Location = New System.Drawing.Point(7, 297)
        Me.pnlCambio.Name = "pnlCambio"
        Me.pnlCambio.Size = New System.Drawing.Size(16, 20)
        Me.pnlCambio.TabIndex = 190
        '
        'mTxtFechaDia
        '
        Me.mTxtFechaDia.Location = New System.Drawing.Point(119, 11)
        Me.mTxtFechaDia.Mask = "00/00/0000"
        Me.mTxtFechaDia.Name = "mTxtFechaDia"
        Me.mTxtFechaDia.Size = New System.Drawing.Size(79, 20)
        Me.mTxtFechaDia.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(10, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(103, 13)
        Me.Label2.TabIndex = 188
        Me.Label2.Text = "Fecha digitalización:"
        '
        'lblservicio_descripcion
        '
        Me.lblservicio_descripcion.AutoSize = True
        Me.lblservicio_descripcion.Location = New System.Drawing.Point(339, 265)
        Me.lblservicio_descripcion.Name = "lblservicio_descripcion"
        Me.lblservicio_descripcion.Size = New System.Drawing.Size(0, 13)
        Me.lblservicio_descripcion.TabIndex = 186
        '
        'mtxtfechaTerminio
        '
        Me.mtxtfechaTerminio.Location = New System.Drawing.Point(213, 65)
        Me.mtxtfechaTerminio.Mask = "00/00/0000"
        Me.mtxtfechaTerminio.Name = "mtxtfechaTerminio"
        Me.mtxtfechaTerminio.Size = New System.Drawing.Size(77, 20)
        Me.mtxtfechaTerminio.TabIndex = 185
        '
        'mtxtFEchainicio
        '
        Me.mtxtFEchainicio.Location = New System.Drawing.Point(84, 65)
        Me.mtxtFEchainicio.Mask = "00/00/0000"
        Me.mtxtFEchainicio.Name = "mtxtFEchainicio"
        Me.mtxtFEchainicio.Size = New System.Drawing.Size(79, 20)
        Me.mtxtFEchainicio.TabIndex = 184
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.NHC, Me.EPISODIO, Me.LITSERVICIO, Me.FECHAINICIO, Me.FECHAFIN, Me.SERVICIO, Me.AREA, Me.Orion})
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(13, 90)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(504, 161)
        Me.ListView1.TabIndex = 183
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'NHC
        '
        Me.NHC.Text = "NHC"
        Me.NHC.Width = 0
        '
        'EPISODIO
        '
        Me.EPISODIO.Text = "EPISODIO"
        Me.EPISODIO.Width = 97
        '
        'LITSERVICIO
        '
        Me.LITSERVICIO.Text = "SERVICIO"
        Me.LITSERVICIO.Width = 180
        '
        'FECHAINICIO
        '
        Me.FECHAINICIO.Text = "INICIO"
        Me.FECHAINICIO.Width = 90
        '
        'FECHAFIN
        '
        Me.FECHAFIN.Text = "FIN"
        Me.FECHAFIN.Width = 90
        '
        'SERVICIO
        '
        Me.SERVICIO.Text = "SERVICIO"
        Me.SERVICIO.Width = 130
        '
        'AREA
        '
        Me.AREA.Text = "AREA"
        '
        'Orion
        '
        Me.Orion.Text = "Orion"
        '
        'lblservicio
        '
        Me.lblservicio.AutoSize = True
        Me.lblservicio.Location = New System.Drawing.Point(314, 122)
        Me.lblservicio.Name = "lblservicio"
        Me.lblservicio.Size = New System.Drawing.Size(0, 13)
        Me.lblservicio.TabIndex = 182
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(465, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(10, 13)
        Me.Label1.TabIndex = 181
        Me.Label1.Text = " "
        '
        'lblpagina
        '
        Me.lblpagina.AutoSize = True
        Me.lblpagina.Location = New System.Drawing.Point(420, 66)
        Me.lblpagina.Name = "lblpagina"
        Me.lblpagina.Size = New System.Drawing.Size(39, 13)
        Me.lblpagina.TabIndex = 180
        Me.lblpagina.Text = "Label3"
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(359, 290)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(145, 24)
        Me.RichTextBox1.TabIndex = 179
        Me.RichTextBox1.Text = ""
        Me.RichTextBox1.Visible = False
        '
        'txtPagVinculada
        '
        Me.txtPagVinculada.AcceptsReturn = True
        Me.txtPagVinculada.BackColor = System.Drawing.SystemColors.Window
        Me.txtPagVinculada.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPagVinculada.Enabled = False
        Me.txtPagVinculada.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPagVinculada.Location = New System.Drawing.Point(442, 133)
        Me.txtPagVinculada.MaxLength = 0
        Me.txtPagVinculada.Name = "txtPagVinculada"
        Me.txtPagVinculada.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPagVinculada.Size = New System.Drawing.Size(33, 20)
        Me.txtPagVinculada.TabIndex = 154
        Me.txtPagVinculada.TabStop = False
        Me.txtPagVinculada.Visible = False
        '
        'txtServicio
        '
        Me.txtServicio.AcceptsReturn = True
        Me.txtServicio.BackColor = System.Drawing.SystemColors.Window
        Me.txtServicio.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtServicio.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtServicio.Location = New System.Drawing.Point(86, 257)
        Me.txtServicio.MaxLength = 4
        Me.txtServicio.Name = "txtServicio"
        Me.txtServicio.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtServicio.Size = New System.Drawing.Size(41, 20)
        Me.txtServicio.TabIndex = 4
        '
        'cmbIncidencias
        '
        Me.cmbIncidencias.BackColor = System.Drawing.SystemColors.Window
        Me.cmbIncidencias.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbIncidencias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbIncidencias.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbIncidencias.Location = New System.Drawing.Point(359, 264)
        Me.cmbIncidencias.Name = "cmbIncidencias"
        Me.cmbIncidencias.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbIncidencias.Size = New System.Drawing.Size(158, 21)
        Me.cmbIncidencias.TabIndex = 158
        Me.cmbIncidencias.TabStop = False
        Me.cmbIncidencias.Visible = False
        '
        'chkIncidencia
        '
        Me.chkIncidencia.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.chkIncidencia.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkIncidencia.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkIncidencia.Location = New System.Drawing.Point(256, 267)
        Me.chkIncidencia.Name = "chkIncidencia"
        Me.chkIncidencia.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkIncidencia.Size = New System.Drawing.Size(97, 17)
        Me.chkIncidencia.TabIndex = 157
        Me.chkIncidencia.TabStop = False
        Me.chkIncidencia.Text = "Incidencia:"
        Me.chkIncidencia.UseVisualStyleBackColor = False
        Me.chkIncidencia.Visible = False
        '
        'txtPaciente
        '
        Me.txtPaciente.AcceptsReturn = True
        Me.txtPaciente.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtPaciente.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPaciente.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPaciente.Location = New System.Drawing.Point(342, 38)
        Me.txtPaciente.MaxLength = 0
        Me.txtPaciente.Name = "txtPaciente"
        Me.txtPaciente.ReadOnly = True
        Me.txtPaciente.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPaciente.Size = New System.Drawing.Size(175, 20)
        Me.txtPaciente.TabIndex = 146
        Me.txtPaciente.TabStop = False
        '
        'txtNumHistoria
        '
        Me.txtNumHistoria.AcceptsReturn = True
        Me.txtNumHistoria.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtNumHistoria.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNumHistoria.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtNumHistoria.Location = New System.Drawing.Point(174, 37)
        Me.txtNumHistoria.MaxLength = 0
        Me.txtNumHistoria.Name = "txtNumHistoria"
        Me.txtNumHistoria.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtNumHistoria.Size = New System.Drawing.Size(88, 20)
        Me.txtNumHistoria.TabIndex = 0
        Me.txtNumHistoria.TabStop = False
        '
        'txtNumicu
        '
        Me.txtNumicu.AcceptsReturn = True
        Me.txtNumicu.BackColor = System.Drawing.Color.White
        Me.txtNumicu.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNumicu.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtNumicu.Location = New System.Drawing.Point(41, 38)
        Me.txtNumicu.MaxLength = 0
        Me.txtNumicu.Name = "txtNumicu"
        Me.txtNumicu.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtNumicu.Size = New System.Drawing.Size(88, 20)
        Me.txtNumicu.TabIndex = 1
        Me.txtNumicu.TabStop = False
        '
        'chkPagVinculada
        '
        Me.chkPagVinculada.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.chkPagVinculada.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkPagVinculada.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkPagVinculada.Location = New System.Drawing.Point(369, 241)
        Me.chkPagVinculada.Name = "chkPagVinculada"
        Me.chkPagVinculada.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkPagVinculada.Size = New System.Drawing.Size(81, 17)
        Me.chkPagVinculada.TabIndex = 155
        Me.chkPagVinculada.TabStop = False
        Me.chkPagVinculada.Text = "Vinculada"
        Me.chkPagVinculada.UseVisualStyleBackColor = False
        Me.chkPagVinculada.Visible = False
        '
        'cmbServicios
        '
        Me.cmbServicios.BackColor = System.Drawing.SystemColors.Window
        Me.cmbServicios.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbServicios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbServicios.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbServicios.Location = New System.Drawing.Point(134, 257)
        Me.cmbServicios.Name = "cmbServicios"
        Me.cmbServicios.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbServicios.Size = New System.Drawing.Size(190, 21)
        Me.cmbServicios.TabIndex = 160
        Me.cmbServicios.TabStop = False
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label26.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label26.Location = New System.Drawing.Point(130, 281)
        Me.Label26.Name = "Label26"
        Me.Label26.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label26.Size = New System.Drawing.Size(109, 13)
        Me.Label26.TabIndex = 171
        Me.Label26.Text = "Desc. T.Doc. Cliente:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(392, 136)
        Me.Label13.Name = "Label13"
        Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label13.Size = New System.Drawing.Size(44, 13)
        Me.Label13.TabIndex = 170
        Me.Label13.Text = "P. Vinc:"
        Me.Label13.Visible = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(272, 38)
        Me.Label17.Name = "Label17"
        Me.Label17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label17.Size = New System.Drawing.Size(52, 13)
        Me.Label17.TabIndex = 169
        Me.Label17.Text = "Paciente:"
        '
        'lblNumHistoria
        '
        Me.lblNumHistoria.AutoSize = True
        Me.lblNumHistoria.BackColor = System.Drawing.Color.Transparent
        Me.lblNumHistoria.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblNumHistoria.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblNumHistoria.Location = New System.Drawing.Point(135, 41)
        Me.lblNumHistoria.Name = "lblNumHistoria"
        Me.lblNumHistoria.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblNumHistoria.Size = New System.Drawing.Size(33, 13)
        Me.lblNumHistoria.TabIndex = 168
        Me.lblNumHistoria.Text = "NHC:"
        '
        'lblIcutec
        '
        Me.lblIcutec.AutoSize = True
        Me.lblIcutec.BackColor = System.Drawing.Color.Transparent
        Me.lblIcutec.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblIcutec.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblIcutec.Location = New System.Drawing.Point(10, 44)
        Me.lblIcutec.Name = "lblIcutec"
        Me.lblIcutec.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblIcutec.Size = New System.Drawing.Size(28, 13)
        Me.lblIcutec.TabIndex = 167
        Me.lblIcutec.Text = "ICU:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(10, 68)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(68, 13)
        Me.Label5.TabIndex = 164
        Me.Label5.Text = "Fecha Inicio:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(171, 68)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(36, 13)
        Me.Label6.TabIndex = 163
        Me.Label6.Text = "F. Fin:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(38, 257)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label10.Size = New System.Drawing.Size(48, 13)
        Me.Label10.TabIndex = 161
        Me.Label10.Text = "Servicio:"
        '
        'ctrlIndizacionEpidemiologia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "ctrlIndizacionEpidemiologia"
        Me.Size = New System.Drawing.Size(524, 326)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Public WithEvents txtPagVinculada As System.Windows.Forms.TextBox
    Public WithEvents txtServicio As System.Windows.Forms.TextBox
    Public WithEvents cmbIncidencias As System.Windows.Forms.ComboBox
    Public WithEvents chkIncidencia As System.Windows.Forms.CheckBox
    Public WithEvents txtPaciente As System.Windows.Forms.TextBox
    Public WithEvents txtNumHistoria As System.Windows.Forms.TextBox
    Public WithEvents txtNumicu As System.Windows.Forms.TextBox
    Public WithEvents chkPagVinculada As System.Windows.Forms.CheckBox
    Public WithEvents cmbServicios As System.Windows.Forms.ComboBox
    Public WithEvents Label13 As System.Windows.Forms.Label
    Public WithEvents Label17 As System.Windows.Forms.Label
    Public WithEvents lblNumHistoria As System.Windows.Forms.Label
    Public WithEvents lblIcutec As System.Windows.Forms.Label
    Public WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents lblpagina As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblservicio As System.Windows.Forms.Label
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents mtxtFEchainicio As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mtxtfechaTerminio As System.Windows.Forms.MaskedTextBox
    Friend WithEvents NHC As System.Windows.Forms.ColumnHeader
    Friend WithEvents EPISODIO As System.Windows.Forms.ColumnHeader
    Friend WithEvents SERVICIO As System.Windows.Forms.ColumnHeader
    Friend WithEvents FECHAINICIO As System.Windows.Forms.ColumnHeader
    Friend WithEvents FECHAFIN As System.Windows.Forms.ColumnHeader
    Friend WithEvents AREA As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblservicio_descripcion As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents mTxtFechaDia As System.Windows.Forms.MaskedTextBox
    Public WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents pnlCambio As System.Windows.Forms.Panel
    Public WithEvents Area1 As System.Windows.Forms.TextBox
    Public WithEvents ConInf As System.Windows.Forms.CheckBox
    Friend WithEvents LITSERVICIO As System.Windows.Forms.ColumnHeader
    Friend WithEvents Orion As System.Windows.Forms.ColumnHeader
    Public WithEvents txtICUOrion As System.Windows.Forms.TextBox
    Public WithEvents UCSI As System.Windows.Forms.CheckBox
    Public WithEvents SD As System.Windows.Forms.CheckBox
    Public WithEvents lblCodDocumento As System.Windows.Forms.Label
    Public WithEvents cmb_codigo_doc As System.Windows.Forms.ComboBox
    Public WithEvents txtCodigoDoc As System.Windows.Forms.TextBox

End Class
