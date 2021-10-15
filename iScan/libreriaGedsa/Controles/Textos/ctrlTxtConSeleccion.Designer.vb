Namespace Controles
    Namespace Textos

        <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
        Partial Class ctrlTxtConSeleccion
            Inherits System.Windows.Forms.UserControl

            'UserControl reemplaza a Dispose para limpiar la lista de componentes.
            <System.Diagnostics.DebuggerNonUserCode()> _
            Protected Overrides Sub Dispose(ByVal disposing As Boolean)
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
                End If
                MyBase.Dispose(disposing)
            End Sub

            'Requerido por el Diseñador de Windows Forms
            Private components As System.ComponentModel.IContainer

            'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
            'Se puede modificar usando el Diseñador de Windows Forms.  
            'No lo modifique con el editor de código.
            <System.Diagnostics.DebuggerStepThrough()> _
            Private Sub InitializeComponent()
                Me.components = New System.ComponentModel.Container
                Me.GroupBox1 = New System.Windows.Forms.GroupBox
                Me.cmbSeleccion = New libreriacadenaproduccion.Controles.Combos.CtrlComboBox
                Me.pbImagen = New System.Windows.Forms.PictureBox
                Me.Label2 = New System.Windows.Forms.Label
                Me.Label1 = New System.Windows.Forms.Label
                Me.CtrlTextBox1 = New libreriacadenaproduccion.Controles.Textos.ctrlTextBox
                Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
                Me.Indicador = New libreriacadenaproduccion.Controles.Indicadores.ctrlIndicador
                Me.GroupBox1.SuspendLayout()
                CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
                Me.SuspendLayout()
                '
                'GroupBox1
                '
                Me.GroupBox1.Controls.Add(Me.cmbSeleccion)
                Me.GroupBox1.Controls.Add(Me.pbImagen)
                Me.GroupBox1.Controls.Add(Me.Label2)
                Me.GroupBox1.Controls.Add(Me.Label1)
                Me.GroupBox1.Controls.Add(Me.CtrlTextBox1)
                Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
                Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
                Me.GroupBox1.Name = "GroupBox1"
                Me.GroupBox1.Size = New System.Drawing.Size(327, 58)
                Me.GroupBox1.TabIndex = 0
                Me.GroupBox1.TabStop = False
                Me.GroupBox1.Text = "Contacto"
                '
                'cmbSeleccion
                '
                Me.cmbSeleccion._Enabled = True
                Me.cmbSeleccion._EsDeBusqueda = True
                Me.cmbSeleccion._itemNombre = ""
                Me.cmbSeleccion._Requerido = False
                Me.cmbSeleccion._SelectedIndex = 0
                Me.cmbSeleccion._SelectedItem = "..."
                Me.cmbSeleccion._Style = System.Windows.Forms.ComboBoxStyle.DropDownList
                Me.cmbSeleccion._TextoComboBox = "..."
                Me.cmbSeleccion.AutoSize = True
                Me.cmbSeleccion.Location = New System.Drawing.Point(12, 31)
                Me.cmbSeleccion.Name = "cmbSeleccion"
                Me.cmbSeleccion.Size = New System.Drawing.Size(119, 24)
                Me.cmbSeleccion.TabIndex = 80
                '
                'pbImagen
                '
                Me.pbImagen.BackColor = System.Drawing.Color.Transparent
                Me.pbImagen.Image = My.Resources.Resources.zoom
                Me.pbImagen.Location = New System.Drawing.Point(298, 31)
                Me.pbImagen.Name = "pbImagen"
                Me.pbImagen.Size = New System.Drawing.Size(23, 20)
                Me.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
                Me.pbImagen.TabIndex = 79
                Me.pbImagen.TabStop = False
                '
                'Label2
                '
                Me.Label2.AutoSize = True
                Me.Label2.Location = New System.Drawing.Point(134, 13)
                Me.Label2.Name = "Label2"
                Me.Label2.Size = New System.Drawing.Size(47, 13)
                Me.Label2.TabIndex = 4
                Me.Label2.Text = "Nombre:"
                '
                'Label1
                '
                Me.Label1.AutoSize = True
                Me.Label1.Location = New System.Drawing.Point(9, 13)
                Me.Label1.Name = "Label1"
                Me.Label1.Size = New System.Drawing.Size(31, 13)
                Me.Label1.TabIndex = 3
                Me.Label1.Text = "Tipo:"
                '
                'CtrlTextBox1
                '
                Me.CtrlTextBox1._Enabled = True
                Me.CtrlTextBox1._EsCodigoBarras = False
                Me.CtrlTextBox1._esIdentificador = False
                Me.CtrlTextBox1._itemNombre = ""
                Me.CtrlTextBox1._Multiline = False
                Me.CtrlTextBox1._Requerido = False
                Me.CtrlTextBox1._SoloLectura = True
                Me.CtrlTextBox1._SoloNumeros = "False"
                Me.CtrlTextBox1._TextoTextBox = ""
                Me.CtrlTextBox1._valor = 0
                Me.CtrlTextBox1.BackColor = System.Drawing.Color.Transparent
                Me.CtrlTextBox1.Location = New System.Drawing.Point(137, 31)
                Me.CtrlTextBox1.Name = "CtrlTextBox1"
                Me.CtrlTextBox1.Size = New System.Drawing.Size(155, 20)
                Me.CtrlTextBox1.TabIndex = 1
                '
                'Indicador
                '
                Me.Indicador._AsociarComboBox = Nothing
                Me.Indicador._AsociarTextBox = Me.CtrlTextBox1
                Me.Indicador.BackColor = System.Drawing.Color.Transparent
                Me.Indicador.Location = New System.Drawing.Point(2, 15)
                Me.Indicador.Name = "Indicador"
                Me.Indicador.Size = New System.Drawing.Size(10, 10)
                Me.Indicador.TabIndex = 1
                Me.Indicador.Visible = False
                '
                'ctrlTxtConSeleccion
                '
                Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
                Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
                Me.BackColor = System.Drawing.Color.Transparent
                Me.Controls.Add(Me.Indicador)
                Me.Controls.Add(Me.GroupBox1)
                Me.Name = "ctrlTxtConSeleccion"
                Me.Size = New System.Drawing.Size(327, 58)
                Me.GroupBox1.ResumeLayout(False)
                Me.GroupBox1.PerformLayout()
                CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).EndInit()
                Me.ResumeLayout(False)

            End Sub
            Protected WithEvents GroupBox1 As System.Windows.Forms.GroupBox
            Protected WithEvents CtrlTextBox1 As libreriacadenaproduccion.Controles.Textos.ctrlTextBox
            Protected WithEvents Label2 As System.Windows.Forms.Label
            Protected WithEvents Label1 As System.Windows.Forms.Label
            Protected WithEvents pbImagen As System.Windows.Forms.PictureBox
            Protected WithEvents cmbSeleccion As libreriacadenaproduccion.Controles.Combos.CtrlComboBox
            Protected WithEvents Indicador As libreriacadenaproduccion.Controles.Indicadores.ctrlIndicador
            Protected WithEvents ToolTip1 As System.Windows.Forms.ToolTip

        End Class

    End Namespace
End Namespace