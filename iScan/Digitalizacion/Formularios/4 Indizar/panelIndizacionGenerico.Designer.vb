<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class panelIndizacionGenerico
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtPagVinculada = New System.Windows.Forms.TextBox
        Me.txtTipoEpisodio = New System.Windows.Forms.TextBox
        Me.txtServicio = New System.Windows.Forms.TextBox
        Me.cmbTipoIncidencias = New System.Windows.Forms.ComboBox
        Me.chkIncidencia = New System.Windows.Forms.CheckBox
        Me.txtPaciente = New System.Windows.Forms.TextBox
        Me.txtNumHistoria = New System.Windows.Forms.TextBox
        Me.txtIcuTec = New System.Windows.Forms.TextBox
        Me.txtFinicioHospital = New System.Windows.Forms.TextBox
        Me.txtFfinHospital = New System.Windows.Forms.TextBox
        Me.chkPagVinculada = New System.Windows.Forms.CheckBox
        Me.cmbTipoEpisodio = New System.Windows.Forms.ComboBox
        Me.cmbServicios = New System.Windows.Forms.ComboBox
        Me.cmb_codigo_doc = New System.Windows.Forms.ComboBox
        Me.txtCodigoDoc = New System.Windows.Forms.TextBox
        Me.lblCodDocumento = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.lblNumHistoria = New System.Windows.Forms.Label
        Me.lblIcutec = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtArea = New System.Windows.Forms.TextBox
        Me.txtServ = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtFechaTermino = New LibreriaCadenaProduccion.Entidades.clsFecha2
        Me.txtFechaInicio = New LibreriaCadenaProduccion.Entidades.clsFecha2
        Me.ClsFecha21 = New LibreriaCadenaProduccion.Entidades.clsFecha2
        Me.ClsFecha22 = New LibreriaCadenaProduccion.Entidades.clsFecha2
        Me.SuspendLayout()
        '
        'txtPagVinculada
        '
        Me.txtPagVinculada.AcceptsReturn = True
        Me.txtPagVinculada.BackColor = System.Drawing.SystemColors.Window
        Me.txtPagVinculada.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPagVinculada.Enabled = False
        Me.txtPagVinculada.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPagVinculada.Location = New System.Drawing.Point(441, 142)
        Me.txtPagVinculada.MaxLength = 0
        Me.txtPagVinculada.Name = "txtPagVinculada"
        Me.txtPagVinculada.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPagVinculada.Size = New System.Drawing.Size(33, 20)
        Me.txtPagVinculada.TabIndex = 14
        Me.txtPagVinculada.TabStop = False
        '
        'txtTipoEpisodio
        '
        Me.txtTipoEpisodio.AcceptsReturn = True
        Me.txtTipoEpisodio.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTipoEpisodio.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtTipoEpisodio.Location = New System.Drawing.Point(109, 169)
        Me.txtTipoEpisodio.MaxLength = 3
        Me.txtTipoEpisodio.Name = "txtTipoEpisodio"
        Me.txtTipoEpisodio.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTipoEpisodio.Size = New System.Drawing.Size(41, 20)
        Me.txtTipoEpisodio.TabIndex = 9
        '
        'txtServicio
        '
        Me.txtServicio.AcceptsReturn = True
        Me.txtServicio.BackColor = System.Drawing.SystemColors.Window
        Me.txtServicio.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtServicio.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtServicio.Location = New System.Drawing.Point(109, 198)
        Me.txtServicio.MaxLength = 4
        Me.txtServicio.Name = "txtServicio"
        Me.txtServicio.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtServicio.Size = New System.Drawing.Size(41, 20)
        Me.txtServicio.TabIndex = 10
        '
        'cmbTipoIncidencias
        '
        Me.cmbTipoIncidencias.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTipoIncidencias.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbTipoIncidencias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoIncidencias.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbTipoIncidencias.Location = New System.Drawing.Point(358, 228)
        Me.cmbTipoIncidencias.Name = "cmbTipoIncidencias"
        Me.cmbTipoIncidencias.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbTipoIncidencias.Size = New System.Drawing.Size(158, 21)
        Me.cmbTipoIncidencias.TabIndex = 17
        Me.cmbTipoIncidencias.TabStop = False
        '
        'chkIncidencia
        '
        Me.chkIncidencia.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.chkIncidencia.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkIncidencia.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkIncidencia.Location = New System.Drawing.Point(358, 200)
        Me.chkIncidencia.Name = "chkIncidencia"
        Me.chkIncidencia.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkIncidencia.Size = New System.Drawing.Size(97, 17)
        Me.chkIncidencia.TabIndex = 16
        Me.chkIncidencia.TabStop = False
        Me.chkIncidencia.Text = "Incidencia:"
        Me.chkIncidencia.UseVisualStyleBackColor = False
        '
        'txtPaciente
        '
        Me.txtPaciente.AcceptsReturn = True
        Me.txtPaciente.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtPaciente.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPaciente.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPaciente.Location = New System.Drawing.Point(188, 14)
        Me.txtPaciente.MaxLength = 0
        Me.txtPaciente.Name = "txtPaciente"
        Me.txtPaciente.ReadOnly = True
        Me.txtPaciente.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPaciente.Size = New System.Drawing.Size(328, 20)
        Me.txtPaciente.TabIndex = 2
        Me.txtPaciente.TabStop = False
        '
        'txtNumHistoria
        '
        Me.txtNumHistoria.AcceptsReturn = True
        Me.txtNumHistoria.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtNumHistoria.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNumHistoria.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtNumHistoria.Location = New System.Drawing.Point(40, 38)
        Me.txtNumHistoria.MaxLength = 0
        Me.txtNumHistoria.Name = "txtNumHistoria"
        Me.txtNumHistoria.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtNumHistoria.Size = New System.Drawing.Size(88, 20)
        Me.txtNumHistoria.TabIndex = 5
        Me.txtNumHistoria.TabStop = False
        '
        'txtIcuTec
        '
        Me.txtIcuTec.AcceptsReturn = True
        Me.txtIcuTec.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtIcuTec.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtIcuTec.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtIcuTec.Location = New System.Drawing.Point(40, 14)
        Me.txtIcuTec.MaxLength = 0
        Me.txtIcuTec.Name = "txtIcuTec"
        Me.txtIcuTec.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtIcuTec.Size = New System.Drawing.Size(88, 20)
        Me.txtIcuTec.TabIndex = 4
        Me.txtIcuTec.TabStop = False
        '
        'txtFinicioHospital
        '
        Me.txtFinicioHospital.AcceptsReturn = True
        Me.txtFinicioHospital.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtFinicioHospital.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtFinicioHospital.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtFinicioHospital.Location = New System.Drawing.Point(188, 39)
        Me.txtFinicioHospital.MaxLength = 0
        Me.txtFinicioHospital.Name = "txtFinicioHospital"
        Me.txtFinicioHospital.ReadOnly = True
        Me.txtFinicioHospital.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtFinicioHospital.Size = New System.Drawing.Size(65, 20)
        Me.txtFinicioHospital.TabIndex = 4
        Me.txtFinicioHospital.TabStop = False
        '
        'txtFfinHospital
        '
        Me.txtFfinHospital.AcceptsReturn = True
        Me.txtFfinHospital.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtFfinHospital.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtFfinHospital.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtFfinHospital.Location = New System.Drawing.Point(303, 39)
        Me.txtFfinHospital.MaxLength = 0
        Me.txtFfinHospital.Name = "txtFfinHospital"
        Me.txtFfinHospital.ReadOnly = True
        Me.txtFfinHospital.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtFfinHospital.Size = New System.Drawing.Size(65, 20)
        Me.txtFfinHospital.TabIndex = 5
        Me.txtFfinHospital.TabStop = False
        '
        'chkPagVinculada
        '
        Me.chkPagVinculada.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.chkPagVinculada.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkPagVinculada.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkPagVinculada.Location = New System.Drawing.Point(358, 171)
        Me.chkPagVinculada.Name = "chkPagVinculada"
        Me.chkPagVinculada.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkPagVinculada.Size = New System.Drawing.Size(81, 17)
        Me.chkPagVinculada.TabIndex = 15
        Me.chkPagVinculada.TabStop = False
        Me.chkPagVinculada.Text = "Vinculada"
        Me.chkPagVinculada.UseVisualStyleBackColor = False
        '
        'cmbTipoEpisodio
        '
        Me.cmbTipoEpisodio.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTipoEpisodio.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbTipoEpisodio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoEpisodio.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbTipoEpisodio.Location = New System.Drawing.Point(157, 169)
        Me.cmbTipoEpisodio.Name = "cmbTipoEpisodio"
        Me.cmbTipoEpisodio.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbTipoEpisodio.Size = New System.Drawing.Size(137, 21)
        Me.cmbTipoEpisodio.TabIndex = 18
        Me.cmbTipoEpisodio.TabStop = False
        '
        'cmbServicios
        '
        Me.cmbServicios.BackColor = System.Drawing.SystemColors.Window
        Me.cmbServicios.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbServicios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbServicios.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbServicios.Location = New System.Drawing.Point(157, 198)
        Me.cmbServicios.Name = "cmbServicios"
        Me.cmbServicios.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbServicios.Size = New System.Drawing.Size(190, 21)
        Me.cmbServicios.TabIndex = 19
        Me.cmbServicios.TabStop = False
        '
        'cmb_codigo_doc
        '
        Me.cmb_codigo_doc.BackColor = System.Drawing.SystemColors.Window
        Me.cmb_codigo_doc.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmb_codigo_doc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_codigo_doc.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmb_codigo_doc.Location = New System.Drawing.Point(118, 90)
        Me.cmb_codigo_doc.Name = "cmb_codigo_doc"
        Me.cmb_codigo_doc.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmb_codigo_doc.Size = New System.Drawing.Size(305, 21)
        Me.cmb_codigo_doc.TabIndex = 15
        Me.cmb_codigo_doc.TabStop = False
        '
        'txtCodigoDoc
        '
        Me.txtCodigoDoc.AcceptsReturn = True
        Me.txtCodigoDoc.BackColor = System.Drawing.SystemColors.Window
        Me.txtCodigoDoc.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCodigoDoc.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCodigoDoc.Location = New System.Drawing.Point(70, 90)
        Me.txtCodigoDoc.MaxLength = 3
        Me.txtCodigoDoc.Name = "txtCodigoDoc"
        Me.txtCodigoDoc.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtCodigoDoc.Size = New System.Drawing.Size(41, 20)
        Me.txtCodigoDoc.TabIndex = 6
        '
        'lblCodDocumento
        '
        Me.lblCodDocumento.AutoSize = True
        Me.lblCodDocumento.BackColor = System.Drawing.Color.Transparent
        Me.lblCodDocumento.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblCodDocumento.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCodDocumento.Location = New System.Drawing.Point(14, 90)
        Me.lblCodDocumento.Name = "lblCodDocumento"
        Me.lblCodDocumento.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblCodDocumento.Size = New System.Drawing.Size(57, 13)
        Me.lblCodDocumento.TabIndex = 139
        Me.lblCodDocumento.Text = "Tipo. Doc:"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label26.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label26.Location = New System.Drawing.Point(115, 74)
        Me.Label26.Name = "Label26"
        Me.Label26.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label26.Size = New System.Drawing.Size(109, 13)
        Me.Label26.TabIndex = 137
        Me.Label26.Text = "Desc. T.Doc. Cliente:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(391, 145)
        Me.Label13.Name = "Label13"
        Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label13.Size = New System.Drawing.Size(44, 13)
        Me.Label13.TabIndex = 136
        Me.Label13.Text = "P. Vinc:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(130, 19)
        Me.Label17.Name = "Label17"
        Me.Label17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label17.Size = New System.Drawing.Size(52, 13)
        Me.Label17.TabIndex = 129
        Me.Label17.Text = "Paciente:"
        '
        'lblNumHistoria
        '
        Me.lblNumHistoria.AutoSize = True
        Me.lblNumHistoria.BackColor = System.Drawing.Color.Transparent
        Me.lblNumHistoria.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblNumHistoria.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblNumHistoria.Location = New System.Drawing.Point(7, 41)
        Me.lblNumHistoria.Name = "lblNumHistoria"
        Me.lblNumHistoria.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblNumHistoria.Size = New System.Drawing.Size(33, 13)
        Me.lblNumHistoria.TabIndex = 128
        Me.lblNumHistoria.Text = "NHC:"
        '
        'lblIcutec
        '
        Me.lblIcutec.AutoSize = True
        Me.lblIcutec.BackColor = System.Drawing.Color.Transparent
        Me.lblIcutec.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblIcutec.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblIcutec.Location = New System.Drawing.Point(9, 18)
        Me.lblIcutec.Name = "lblIcutec"
        Me.lblIcutec.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblIcutec.Size = New System.Drawing.Size(28, 13)
        Me.lblIcutec.TabIndex = 127
        Me.lblIcutec.Text = "ICU:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label19.Location = New System.Drawing.Point(134, 41)
        Me.Label19.Name = "Label19"
        Me.Label19.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label19.Size = New System.Drawing.Size(48, 13)
        Me.Label19.TabIndex = 126
        Me.Label19.Text = "F.Ini Epi:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label20.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label20.Location = New System.Drawing.Point(252, 42)
        Me.Label20.Name = "Label20"
        Me.Label20.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label20.Size = New System.Drawing.Size(51, 13)
        Me.Label20.TabIndex = 125
        Me.Label20.Text = "F.Fin Epi:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(37, 131)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(68, 13)
        Me.Label5.TabIndex = 108
        Me.Label5.Text = "Fecha Inicio:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(205, 131)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(36, 13)
        Me.Label6.TabIndex = 107
        Me.Label6.Text = "F. Fin:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(37, 169)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(74, 13)
        Me.Label7.TabIndex = 106
        Me.Label7.Text = "Tipo Episodio:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(61, 198)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label10.Size = New System.Drawing.Size(48, 13)
        Me.Label10.TabIndex = 104
        Me.Label10.Text = "Servicio:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(369, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(32, 13)
        Me.Label1.TabIndex = 140
        Me.Label1.Text = "Area:"
        '
        'txtArea
        '
        Me.txtArea.AcceptsReturn = True
        Me.txtArea.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtArea.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtArea.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtArea.Location = New System.Drawing.Point(399, 39)
        Me.txtArea.MaxLength = 0
        Me.txtArea.Name = "txtArea"
        Me.txtArea.ReadOnly = True
        Me.txtArea.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtArea.Size = New System.Drawing.Size(45, 20)
        Me.txtArea.TabIndex = 141
        Me.txtArea.TabStop = False
        '
        'txtServ
        '
        Me.txtServ.AcceptsReturn = True
        Me.txtServ.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtServ.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtServ.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtServ.Location = New System.Drawing.Point(477, 39)
        Me.txtServ.MaxLength = 0
        Me.txtServ.Name = "txtServ"
        Me.txtServ.ReadOnly = True
        Me.txtServ.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtServ.Size = New System.Drawing.Size(39, 20)
        Me.txtServ.TabIndex = 142
        Me.txtServ.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(445, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(32, 13)
        Me.Label2.TabIndex = 143
        Me.Label2.Text = "Serv:"
        '
        'txtFechaTermino
        '
        Me.txtFechaTermino.fnc_comprobar = False
        Me.txtFechaTermino.Location = New System.Drawing.Point(255, 128)
        Me.txtFechaTermino.Mask = "00/00/0000"
        Me.txtFechaTermino.Name = "txtFechaTermino"
        Me.txtFechaTermino.Size = New System.Drawing.Size(72, 20)
        Me.txtFechaTermino.TabIndex = 8
        '
        'txtFechaInicio
        '
        Me.txtFechaInicio.fnc_comprobar = False
        Me.txtFechaInicio.Location = New System.Drawing.Point(111, 128)
        Me.txtFechaInicio.Mask = "00/00/0000"
        Me.txtFechaInicio.Name = "txtFechaInicio"
        Me.txtFechaInicio.Size = New System.Drawing.Size(71, 20)
        Me.txtFechaInicio.TabIndex = 7
        '
        'ClsFecha21
        '
        Me.ClsFecha21.fnc_comprobar = False
        Me.ClsFecha21.Location = New System.Drawing.Point(262, 128)
        Me.ClsFecha21.Mask = "00/00/0000"
        Me.ClsFecha21.Name = "ClsFecha21"
        Me.ClsFecha21.Size = New System.Drawing.Size(72, 20)
        Me.ClsFecha21.TabIndex = 145
        '
        'ClsFecha22
        '
        Me.ClsFecha22.fnc_comprobar = False
        Me.ClsFecha22.Location = New System.Drawing.Point(118, 128)
        Me.ClsFecha22.Mask = "00/00/0000"
        Me.ClsFecha22.Name = "ClsFecha22"
        Me.ClsFecha22.Size = New System.Drawing.Size(71, 20)
        Me.ClsFecha22.TabIndex = 144
        '
        'panelIndizacionGenerico
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ClsFecha21)
        Me.Controls.Add(Me.ClsFecha22)
        Me.Controls.Add(Me.txtServ)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtArea)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtPagVinculada)
        Me.Controls.Add(Me.txtTipoEpisodio)
        Me.Controls.Add(Me.txtServicio)
        Me.Controls.Add(Me.cmbTipoIncidencias)
        Me.Controls.Add(Me.chkIncidencia)
        Me.Controls.Add(Me.txtPaciente)
        Me.Controls.Add(Me.txtNumHistoria)
        Me.Controls.Add(Me.txtIcuTec)
        Me.Controls.Add(Me.txtFinicioHospital)
        Me.Controls.Add(Me.txtFfinHospital)
        Me.Controls.Add(Me.chkPagVinculada)
        Me.Controls.Add(Me.cmbTipoEpisodio)
        Me.Controls.Add(Me.cmbServicios)
        Me.Controls.Add(Me.cmb_codigo_doc)
        Me.Controls.Add(Me.txtCodigoDoc)
        Me.Controls.Add(Me.lblCodDocumento)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.lblNumHistoria)
        Me.Controls.Add(Me.lblIcutec)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label10)
        Me.Name = "panelIndizacionGenerico"
        Me.Size = New System.Drawing.Size(524, 263)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents txtPagVinculada As System.Windows.Forms.TextBox
    Public WithEvents txtTipoEpisodio As System.Windows.Forms.TextBox
    Public WithEvents txtServicio As System.Windows.Forms.TextBox
    Public WithEvents cmbTipoIncidencias As System.Windows.Forms.ComboBox
    Public WithEvents chkIncidencia As System.Windows.Forms.CheckBox
    Public WithEvents txtPaciente As System.Windows.Forms.TextBox
    Public WithEvents txtNumHistoria As System.Windows.Forms.TextBox
    Public WithEvents txtIcuTec As System.Windows.Forms.TextBox
    Public WithEvents txtFinicioHospital As System.Windows.Forms.TextBox
    Public WithEvents txtFfinHospital As System.Windows.Forms.TextBox
    Public WithEvents chkPagVinculada As System.Windows.Forms.CheckBox
    Public WithEvents cmbTipoEpisodio As System.Windows.Forms.ComboBox
    Public WithEvents cmbServicios As System.Windows.Forms.ComboBox
    Public WithEvents cmb_codigo_doc As System.Windows.Forms.ComboBox
    Public WithEvents txtCodigoDoc As System.Windows.Forms.TextBox
    Public WithEvents lblCodDocumento As System.Windows.Forms.Label
    Public WithEvents Label26 As System.Windows.Forms.Label
    Public WithEvents Label13 As System.Windows.Forms.Label
    Public WithEvents Label17 As System.Windows.Forms.Label
    Public WithEvents lblNumHistoria As System.Windows.Forms.Label
    Public WithEvents lblIcutec As System.Windows.Forms.Label
    Public WithEvents Label19 As System.Windows.Forms.Label
    Public WithEvents Label20 As System.Windows.Forms.Label
    Public WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents Label7 As System.Windows.Forms.Label
    Public WithEvents Label10 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents txtArea As System.Windows.Forms.TextBox
    Public WithEvents txtServ As System.Windows.Forms.TextBox
    Public WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFechaInicio As LibreriaCadenaProduccion.Entidades.clsFecha2
    Friend WithEvents txtFechaTermino As LibreriaCadenaProduccion.Entidades.clsFecha2
    Friend WithEvents ClsFecha21 As LibreriaCadenaProduccion.Entidades.clsFecha2
    Friend WithEvents ClsFecha22 As LibreriaCadenaProduccion.Entidades.clsFecha2

End Class
