<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ctrlIndizacionLaRibera
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblModoEdicion = New System.Windows.Forms.Label()
        Me.lblGECI = New System.Windows.Forms.Label()
        Me.cmdActo = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtPaciente = New System.Windows.Forms.TextBox()
        Me.lvwPacientes = New System.Windows.Forms.ListView()
        Me.HISTORIA = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.NOMBRE = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.DNI = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CIP = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtCIP = New System.Windows.Forms.TextBox()
        Me.cmbTipoActo = New System.Windows.Forms.ComboBox()
        Me.txtDNI = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblCodDocumento = New System.Windows.Forms.Label()
        Me.cmb_codigo_doc = New System.Windows.Forms.ComboBox()
        Me.txtCodigoDoc = New System.Windows.Forms.TextBox()
        Me.SD = New System.Windows.Forms.CheckBox()
        Me.UCSI = New System.Windows.Forms.CheckBox()
        Me.ConInf = New System.Windows.Forms.CheckBox()
        Me.pnlCambio = New System.Windows.Forms.Panel()
        Me.mTxtFechaDia = New System.Windows.Forms.MaskedTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblservicio_descripcion = New System.Windows.Forms.Label()
        Me.mtxtfechaTerminio = New System.Windows.Forms.MaskedTextBox()
        Me.mtxtFEchainicio = New System.Windows.Forms.MaskedTextBox()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.TipoActo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CodigoActo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.EPISODIO = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.LITSERVICIO = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.FECHAINICIO = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.FECHAFIN = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SERVICIO = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.AREA = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.idServicio = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.NHC = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.servicioGEDSA = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lblservicio = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblpagina = New System.Windows.Forms.Label()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.txtPagVinculada = New System.Windows.Forms.TextBox()
        Me.txtServicio = New System.Windows.Forms.TextBox()
        Me.cmbIncidencias = New System.Windows.Forms.ComboBox()
        Me.chkIncidencia = New System.Windows.Forms.CheckBox()
        Me.txtNumHistoria = New System.Windows.Forms.TextBox()
        Me.txtNumicu = New System.Windows.Forms.TextBox()
        Me.chkPagVinculada = New System.Windows.Forms.CheckBox()
        Me.cmbServicios = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lblNumHistoria = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblModoEdicion)
        Me.GroupBox1.Controls.Add(Me.lblGECI)
        Me.GroupBox1.Controls.Add(Me.cmdActo)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtPaciente)
        Me.GroupBox1.Controls.Add(Me.lvwPacientes)
        Me.GroupBox1.Controls.Add(Me.txtCIP)
        Me.GroupBox1.Controls.Add(Me.cmbTipoActo)
        Me.GroupBox1.Controls.Add(Me.txtDNI)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.lblCodDocumento)
        Me.GroupBox1.Controls.Add(Me.cmb_codigo_doc)
        Me.GroupBox1.Controls.Add(Me.txtCodigoDoc)
        Me.GroupBox1.Controls.Add(Me.SD)
        Me.GroupBox1.Controls.Add(Me.UCSI)
        Me.GroupBox1.Controls.Add(Me.ConInf)
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
        Me.GroupBox1.Controls.Add(Me.txtNumHistoria)
        Me.GroupBox1.Controls.Add(Me.txtNumicu)
        Me.GroupBox1.Controls.Add(Me.chkPagVinculada)
        Me.GroupBox1.Controls.Add(Me.cmbServicios)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.lblNumHistoria)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(565, 326)
        Me.GroupBox1.TabIndex = 148
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Indizacion"
        '
        'lblModoEdicion
        '
        Me.lblModoEdicion.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblModoEdicion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModoEdicion.ForeColor = System.Drawing.Color.OrangeRed
        Me.lblModoEdicion.Location = New System.Drawing.Point(456, 290)
        Me.lblModoEdicion.Name = "lblModoEdicion"
        Me.lblModoEdicion.Size = New System.Drawing.Size(53, 35)
        Me.lblModoEdicion.TabIndex = 208
        Me.lblModoEdicion.Text = "MODO EDICIÓN"
        Me.lblModoEdicion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblModoEdicion.Visible = False
        '
        'lblGECI
        '
        Me.lblGECI.AutoSize = True
        Me.lblGECI.ForeColor = System.Drawing.Color.Blue
        Me.lblGECI.Location = New System.Drawing.Point(65, 0)
        Me.lblGECI.Name = "lblGECI"
        Me.lblGECI.Size = New System.Drawing.Size(32, 13)
        Me.lblGECI.TabIndex = 207
        Me.lblGECI.Text = "GECI"
        '
        'cmdActo
        '
        Me.cmdActo.Location = New System.Drawing.Point(10, 91)
        Me.cmdActo.Name = "cmdActo"
        Me.cmdActo.Size = New System.Drawing.Size(52, 21)
        Me.cmdActo.TabIndex = 206
        Me.cmdActo.Text = "Acto:"
        Me.cmdActo.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(9, 119)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(57, 13)
        Me.Label8.TabIndex = 205
        Me.Label8.Text = "Cod. Acto:"
        '
        'Button1
        '
        Me.Button1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(512, 290)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(47, 29)
        Me.Button1.TabIndex = 204
        Me.Button1.Text = "Editar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(355, 46)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(27, 13)
        Me.Label7.TabIndex = 203
        Me.Label7.Text = "CIP:"
        '
        'txtPaciente
        '
        Me.txtPaciente.AcceptsReturn = True
        Me.txtPaciente.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtPaciente.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPaciente.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPaciente.Location = New System.Drawing.Point(67, 67)
        Me.txtPaciente.MaxLength = 0
        Me.txtPaciente.Name = "txtPaciente"
        Me.txtPaciente.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPaciente.Size = New System.Drawing.Size(216, 20)
        Me.txtPaciente.TabIndex = 202
        Me.txtPaciente.TabStop = False
        '
        'lvwPacientes
        '
        Me.lvwPacientes.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.HISTORIA, Me.NOMBRE, Me.DNI, Me.CIP})
        Me.lvwPacientes.FullRowSelect = True
        Me.lvwPacientes.GridLines = True
        Me.lvwPacientes.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lvwPacientes.HideSelection = False
        Me.lvwPacientes.Location = New System.Drawing.Point(296, 66)
        Me.lvwPacientes.Name = "lvwPacientes"
        Me.lvwPacientes.Size = New System.Drawing.Size(263, 110)
        Me.lvwPacientes.TabIndex = 8
        Me.lvwPacientes.UseCompatibleStateImageBehavior = False
        Me.lvwPacientes.Visible = False
        '
        'HISTORIA
        '
        Me.HISTORIA.DisplayIndex = 3
        Me.HISTORIA.Text = "NHC"
        Me.HISTORIA.Width = 70
        '
        'NOMBRE
        '
        Me.NOMBRE.Text = "Nombre"
        Me.NOMBRE.Width = 200
        '
        'DNI
        '
        Me.DNI.DisplayIndex = 0
        Me.DNI.Text = "DNI"
        '
        'CIP
        '
        Me.CIP.DisplayIndex = 2
        Me.CIP.Text = "CIP"
        Me.CIP.Width = 0
        '
        'txtCIP
        '
        Me.txtCIP.AcceptsReturn = True
        Me.txtCIP.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCIP.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCIP.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCIP.Location = New System.Drawing.Point(392, 43)
        Me.txtCIP.MaxLength = 0
        Me.txtCIP.Name = "txtCIP"
        Me.txtCIP.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtCIP.Size = New System.Drawing.Size(167, 20)
        Me.txtCIP.TabIndex = 200
        Me.txtCIP.TabStop = False
        '
        'cmbTipoActo
        '
        Me.cmbTipoActo.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTipoActo.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbTipoActo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoActo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbTipoActo.Location = New System.Drawing.Point(67, 91)
        Me.cmbTipoActo.Name = "cmbTipoActo"
        Me.cmbTipoActo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbTipoActo.Size = New System.Drawing.Size(216, 21)
        Me.cmbTipoActo.TabIndex = 6
        '
        'txtDNI
        '
        Me.txtDNI.AcceptsReturn = True
        Me.txtDNI.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtDNI.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDNI.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDNI.Location = New System.Drawing.Point(228, 43)
        Me.txtDNI.MaxLength = 0
        Me.txtDNI.Name = "txtDNI"
        Me.txtDNI.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDNI.Size = New System.Drawing.Size(88, 20)
        Me.txtDNI.TabIndex = 3
        Me.txtDNI.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(193, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(29, 13)
        Me.Label4.TabIndex = 201
        Me.Label4.Text = "DNI:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 163)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 199
        Me.Label3.Text = "Página:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCodDocumento
        '
        Me.lblCodDocumento.AutoSize = True
        Me.lblCodDocumento.BackColor = System.Drawing.Color.Transparent
        Me.lblCodDocumento.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblCodDocumento.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCodDocumento.Location = New System.Drawing.Point(149, 22)
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
        Me.cmb_codigo_doc.Location = New System.Drawing.Point(259, 19)
        Me.cmb_codigo_doc.Name = "cmb_codigo_doc"
        Me.cmb_codigo_doc.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmb_codigo_doc.Size = New System.Drawing.Size(300, 21)
        Me.cmb_codigo_doc.TabIndex = 197
        Me.cmb_codigo_doc.TabStop = False
        '
        'txtCodigoDoc
        '
        Me.txtCodigoDoc.AcceptsReturn = True
        Me.txtCodigoDoc.BackColor = System.Drawing.SystemColors.Window
        Me.txtCodigoDoc.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCodigoDoc.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCodigoDoc.Location = New System.Drawing.Point(212, 19)
        Me.txtCodigoDoc.MaxLength = 3
        Me.txtCodigoDoc.Name = "txtCodigoDoc"
        Me.txtCodigoDoc.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtCodigoDoc.Size = New System.Drawing.Size(41, 20)
        Me.txtCodigoDoc.TabIndex = 1
        '
        'SD
        '
        Me.SD.Cursor = System.Windows.Forms.Cursors.Default
        Me.SD.ForeColor = System.Drawing.SystemColors.ControlText
        Me.SD.Location = New System.Drawing.Point(493, 82)
        Me.SD.Name = "SD"
        Me.SD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SD.Size = New System.Drawing.Size(116, 15)
        Me.SD.TabIndex = 194
        Me.SD.TabStop = False
        Me.SD.Text = "Sin documentos"
        Me.SD.UseVisualStyleBackColor = False
        Me.SD.Visible = False
        '
        'UCSI
        '
        Me.UCSI.Cursor = System.Windows.Forms.Cursors.Default
        Me.UCSI.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UCSI.Location = New System.Drawing.Point(493, 112)
        Me.UCSI.Name = "UCSI"
        Me.UCSI.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UCSI.Size = New System.Drawing.Size(62, 15)
        Me.UCSI.TabIndex = 193
        Me.UCSI.TabStop = False
        Me.UCSI.Text = "UCSI"
        Me.UCSI.UseVisualStyleBackColor = False
        Me.UCSI.Visible = False
        '
        'ConInf
        '
        Me.ConInf.BackColor = System.Drawing.SystemColors.Control
        Me.ConInf.Cursor = System.Windows.Forms.Cursors.Default
        Me.ConInf.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ConInf.Location = New System.Drawing.Point(493, 94)
        Me.ConInf.Name = "ConInf"
        Me.ConInf.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ConInf.Size = New System.Drawing.Size(106, 22)
        Me.ConInf.TabIndex = 191
        Me.ConInf.TabStop = False
        Me.ConInf.Text = "Hoja evolución"
        Me.ConInf.UseVisualStyleBackColor = False
        Me.ConInf.Visible = False
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
        Me.mTxtFechaDia.Location = New System.Drawing.Point(68, 19)
        Me.mTxtFechaDia.Mask = "00/00/0000"
        Me.mTxtFechaDia.Name = "mTxtFechaDia"
        Me.mTxtFechaDia.Size = New System.Drawing.Size(74, 20)
        Me.mTxtFechaDia.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(10, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 188
        Me.Label2.Text = "F. doc:"
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
        Me.mtxtfechaTerminio.Location = New System.Drawing.Point(205, 141)
        Me.mtxtfechaTerminio.Mask = "00/00/0000"
        Me.mtxtfechaTerminio.Name = "mtxtfechaTerminio"
        Me.mtxtfechaTerminio.Size = New System.Drawing.Size(77, 20)
        Me.mtxtfechaTerminio.TabIndex = 10
        '
        'mtxtFEchainicio
        '
        Me.mtxtFEchainicio.Location = New System.Drawing.Point(83, 141)
        Me.mtxtFEchainicio.Mask = "00/00/0000"
        Me.mtxtFEchainicio.Name = "mtxtFEchainicio"
        Me.mtxtFEchainicio.Size = New System.Drawing.Size(79, 20)
        Me.mtxtFEchainicio.TabIndex = 9
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.TipoActo, Me.CodigoActo, Me.EPISODIO, Me.LITSERVICIO, Me.FECHAINICIO, Me.FECHAFIN, Me.SERVICIO, Me.AREA, Me.idServicio, Me.NHC, Me.servicioGEDSA})
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(10, 179)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(553, 112)
        Me.ListView1.TabIndex = 9
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'TipoActo
        '
        Me.TipoActo.Text = "Tipo"
        Me.TipoActo.Width = 30
        '
        'CodigoActo
        '
        Me.CodigoActo.Text = "Codigo Acto"
        Me.CodigoActo.Width = 130
        '
        'EPISODIO
        '
        Me.EPISODIO.Text = "Episodio"
        Me.EPISODIO.Width = 40
        '
        'LITSERVICIO
        '
        Me.LITSERVICIO.Text = "Servicio"
        Me.LITSERVICIO.Width = 180
        '
        'FECHAINICIO
        '
        Me.FECHAINICIO.Text = "F. Inicio"
        Me.FECHAINICIO.Width = 70
        '
        'FECHAFIN
        '
        Me.FECHAFIN.Text = "F. Fin"
        Me.FECHAFIN.Width = 70
        '
        'SERVICIO
        '
        Me.SERVICIO.Text = "SERVICIO"
        Me.SERVICIO.Width = 0
        '
        'AREA
        '
        Me.AREA.Text = "AREA"
        Me.AREA.Width = 0
        '
        'idServicio
        '
        Me.idServicio.Text = "idServicio"
        Me.idServicio.Width = 0
        '
        'NHC
        '
        Me.NHC.Text = "NHC"
        Me.NHC.Width = 0
        '
        'servicioGEDSA
        '
        Me.servicioGEDSA.Text = "servicioGEDSA"
        Me.servicioGEDSA.Width = 0
        '
        'lblservicio
        '
        Me.lblservicio.AutoSize = True
        Me.lblservicio.Location = New System.Drawing.Point(456, 279)
        Me.lblservicio.Name = "lblservicio"
        Me.lblservicio.Size = New System.Drawing.Size(0, 13)
        Me.lblservicio.TabIndex = 182
        Me.lblservicio.Visible = False
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
        Me.lblpagina.Location = New System.Drawing.Point(58, 163)
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
        Me.txtServicio.Location = New System.Drawing.Point(89, 297)
        Me.txtServicio.MaxLength = 4
        Me.txtServicio.Name = "txtServicio"
        Me.txtServicio.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtServicio.Size = New System.Drawing.Size(41, 20)
        Me.txtServicio.TabIndex = 12
        '
        'cmbIncidencias
        '
        Me.cmbIncidencias.BackColor = System.Drawing.SystemColors.Window
        Me.cmbIncidencias.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbIncidencias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbIncidencias.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbIncidencias.Location = New System.Drawing.Point(358, 283)
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
        Me.chkIncidencia.Location = New System.Drawing.Point(255, 286)
        Me.chkIncidencia.Name = "chkIncidencia"
        Me.chkIncidencia.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkIncidencia.Size = New System.Drawing.Size(97, 17)
        Me.chkIncidencia.TabIndex = 157
        Me.chkIncidencia.TabStop = False
        Me.chkIncidencia.Text = "Incidencia:"
        Me.chkIncidencia.UseVisualStyleBackColor = False
        Me.chkIncidencia.Visible = False
        '
        'txtNumHistoria
        '
        Me.txtNumHistoria.AcceptsReturn = True
        Me.txtNumHistoria.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtNumHistoria.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNumHistoria.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtNumHistoria.Location = New System.Drawing.Point(68, 43)
        Me.txtNumHistoria.MaxLength = 0
        Me.txtNumHistoria.Name = "txtNumHistoria"
        Me.txtNumHistoria.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtNumHistoria.Size = New System.Drawing.Size(88, 20)
        Me.txtNumHistoria.TabIndex = 2
        '
        'txtNumicu
        '
        Me.txtNumicu.AcceptsReturn = True
        Me.txtNumicu.BackColor = System.Drawing.Color.White
        Me.txtNumicu.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNumicu.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtNumicu.Location = New System.Drawing.Point(67, 117)
        Me.txtNumicu.MaxLength = 0
        Me.txtNumicu.Name = "txtNumicu"
        Me.txtNumicu.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtNumicu.Size = New System.Drawing.Size(137, 20)
        Me.txtNumicu.TabIndex = 7
        '
        'chkPagVinculada
        '
        Me.chkPagVinculada.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.chkPagVinculada.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkPagVinculada.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkPagVinculada.Location = New System.Drawing.Point(375, 267)
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
        Me.cmbServicios.Location = New System.Drawing.Point(136, 297)
        Me.cmbServicios.Name = "cmbServicios"
        Me.cmbServicios.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbServicios.Size = New System.Drawing.Size(300, 21)
        Me.cmbServicios.TabIndex = 160
        Me.cmbServicios.TabStop = False
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
        Me.Label17.Location = New System.Drawing.Point(9, 69)
        Me.Label17.Name = "Label17"
        Me.Label17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label17.Size = New System.Drawing.Size(47, 13)
        Me.Label17.TabIndex = 169
        Me.Label17.Text = "Nombre:"
        '
        'lblNumHistoria
        '
        Me.lblNumHistoria.AutoSize = True
        Me.lblNumHistoria.BackColor = System.Drawing.Color.Transparent
        Me.lblNumHistoria.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblNumHistoria.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblNumHistoria.Location = New System.Drawing.Point(10, 46)
        Me.lblNumHistoria.Name = "lblNumHistoria"
        Me.lblNumHistoria.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblNumHistoria.Size = New System.Drawing.Size(33, 13)
        Me.lblNumHistoria.TabIndex = 168
        Me.lblNumHistoria.Text = "NHC:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(9, 144)
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
        Me.Label6.Location = New System.Drawing.Point(170, 144)
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
        Me.Label10.Location = New System.Drawing.Point(40, 297)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label10.Size = New System.Drawing.Size(48, 13)
        Me.Label10.TabIndex = 161
        Me.Label10.Text = "Servicio:"
        '
        'ctrlIndizacionLaRibera
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "ctrlIndizacionLaRibera"
        Me.Size = New System.Drawing.Size(565, 326)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Public WithEvents txtPagVinculada As System.Windows.Forms.TextBox
    Public WithEvents txtServicio As System.Windows.Forms.TextBox
    Public WithEvents cmbIncidencias As System.Windows.Forms.ComboBox
    Public WithEvents chkIncidencia As System.Windows.Forms.CheckBox
    Public WithEvents txtNumHistoria As System.Windows.Forms.TextBox
    Public WithEvents txtNumicu As System.Windows.Forms.TextBox
    Public WithEvents chkPagVinculada As System.Windows.Forms.CheckBox
    Public WithEvents cmbServicios As System.Windows.Forms.ComboBox
    Public WithEvents Label13 As System.Windows.Forms.Label
    Public WithEvents Label17 As System.Windows.Forms.Label
    Public WithEvents lblNumHistoria As System.Windows.Forms.Label
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
    Friend WithEvents pnlCambio As System.Windows.Forms.Panel
    Public WithEvents ConInf As System.Windows.Forms.CheckBox
    Friend WithEvents LITSERVICIO As System.Windows.Forms.ColumnHeader
    Friend WithEvents TipoActo As System.Windows.Forms.ColumnHeader
    Public WithEvents UCSI As System.Windows.Forms.CheckBox
    Public WithEvents SD As System.Windows.Forms.CheckBox
    Public WithEvents lblCodDocumento As System.Windows.Forms.Label
    Public WithEvents cmb_codigo_doc As System.Windows.Forms.ComboBox
    Public WithEvents txtCodigoDoc As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents lvwPacientes As ListView
    Public WithEvents txtCIP As TextBox
    Public WithEvents cmbTipoActo As ComboBox
    Public WithEvents txtDNI As TextBox
    Public WithEvents Label4 As Label
    Friend WithEvents CodigoActo As ColumnHeader
    Friend WithEvents idServicio As ColumnHeader
    Friend WithEvents DNI As ColumnHeader
    Friend WithEvents NOMBRE As ColumnHeader
    Friend WithEvents CIP As ColumnHeader
    Friend WithEvents HISTORIA As ColumnHeader
    Public WithEvents txtPaciente As TextBox
    Public WithEvents Label7 As Label
    Friend WithEvents Button1 As Button
    Public WithEvents Label8 As Label
    Friend WithEvents servicioGEDSA As ColumnHeader
    Friend WithEvents cmdActo As Button
    Friend WithEvents lblGECI As Label
    Friend WithEvents lblModoEdicion As Label
End Class
