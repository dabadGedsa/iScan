Imports libreriacadenaproduccion.Controles.Indicadores

Namespace Controles
    Namespace Fechas

        <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
        Partial Class ctrlFechaNormal
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
                Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctrlFechaNormal))
                Me.GroupBox1 = New System.Windows.Forms.GroupBox
                Me.CtrlIndicador1 = New libreriacadenaproduccion.Controles.Indicadores.ctrlIndicador
                Me.pnlFecha = New System.Windows.Forms.Panel
                Me.chkFecha = New System.Windows.Forms.CheckBox
                Me.dtpFecha = New System.Windows.Forms.DateTimePicker
                Me.GroupBox1.SuspendLayout()
                Me.SuspendLayout()
                '
                'GroupBox1
                '
                Me.GroupBox1.Controls.Add(Me.CtrlIndicador1)
                Me.GroupBox1.Controls.Add(Me.pnlFecha)
                Me.GroupBox1.Controls.Add(Me.chkFecha)
                Me.GroupBox1.Controls.Add(Me.dtpFecha)
                Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
                Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
                Me.GroupBox1.Name = "GroupBox1"
                Me.GroupBox1.Size = New System.Drawing.Size(133, 69)
                Me.GroupBox1.TabIndex = 4
                Me.GroupBox1.TabStop = False
                Me.GroupBox1.Text = "GroupBox1"
                '
                'CtrlIndicador1
                '
                Me.CtrlIndicador1._AsociarComboBox = Nothing
                Me.CtrlIndicador1._AsociarTextBox = Nothing
                Me.CtrlIndicador1.BackColor = System.Drawing.Color.Transparent
                Me.CtrlIndicador1.Location = New System.Drawing.Point(0, 19)
                Me.CtrlIndicador1.Name = "CtrlIndicador1"
                Me.CtrlIndicador1.pImagen = CType(resources.GetObject("CtrlIndicador1.pImagen"), System.Drawing.Image)
                Me.CtrlIndicador1.Size = New System.Drawing.Size(10, 10)
                Me.CtrlIndicador1.TabIndex = 5
                '
                'pnlFecha
                '
                Me.pnlFecha.BackColor = System.Drawing.Color.White
                Me.pnlFecha.Location = New System.Drawing.Point(14, 21)
                Me.pnlFecha.Name = "pnlFecha"
                Me.pnlFecha.Size = New System.Drawing.Size(73, 16)
                Me.pnlFecha.TabIndex = 5
                '
                'chkFecha
                '
                Me.chkFecha.AutoSize = True
                Me.chkFecha.Location = New System.Drawing.Point(11, 41)
                Me.chkFecha.Name = "chkFecha"
                Me.chkFecha.Size = New System.Drawing.Size(76, 17)
                Me.chkFecha.TabIndex = 4
                Me.chkFecha.Text = "Día actual"
                Me.chkFecha.UseVisualStyleBackColor = True
                '
                'dtpFecha
                '
                Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
                Me.dtpFecha.Location = New System.Drawing.Point(11, 19)
                Me.dtpFecha.Name = "dtpFecha"
                Me.dtpFecha.Size = New System.Drawing.Size(98, 20)
                Me.dtpFecha.TabIndex = 3
                '
                'ctrlFechaNormal
                '
                Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
                Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
                Me.BackColor = System.Drawing.Color.Transparent
                Me.Controls.Add(Me.GroupBox1)
                Me.Name = "ctrlFechaNormal"
                Me.Size = New System.Drawing.Size(133, 69)
                Me.GroupBox1.ResumeLayout(False)
                Me.GroupBox1.PerformLayout()
                Me.ResumeLayout(False)

            End Sub
            Protected WithEvents chkFecha As System.Windows.Forms.CheckBox
            Protected WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
            Protected WithEvents CtrlIndicador1 As libreriacadenaproduccion.Controles.Indicadores.ctrlIndicador
            Protected WithEvents GroupBox1 As System.Windows.Forms.GroupBox
            Protected WithEvents pnlFecha As System.Windows.Forms.Panel

        End Class

    End Namespace
End Namespace
