<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCorreccionEpidemiologia
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCorreccionEpidemiologia))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.IMGeditPrincipal = New AxImgeditLibCtl.AxImgEdit
        Me.labelescribeme = New LibreriaCadenaProduccion.Controles.Labels.ctrlLabelBase
        Me.CtrlBotonMediano1 = New LibreriaCadenaProduccion.Controles.Botones.CtrlBotonMediano
        Me.CtrlPorcentajeCorreccion1 = New Digitalización.ctrlPorcentajeCorreccion
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IMGeditPrincipal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(539, 0)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(464, 618)
        Me.DataGridView1.TabIndex = 0
        '
        'IMGeditPrincipal
        '
        Me.IMGeditPrincipal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.IMGeditPrincipal.CausesValidation = False
        Me.IMGeditPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.IMGeditPrincipal.Name = "IMGeditPrincipal"
        Me.IMGeditPrincipal.OcxState = CType(resources.GetObject("IMGeditPrincipal.OcxState"), System.Windows.Forms.AxHost.State)
        Me.IMGeditPrincipal.Size = New System.Drawing.Size(533, 677)
        Me.IMGeditPrincipal.TabIndex = 4
        Me.IMGeditPrincipal.TabStop = False
        Me.IMGeditPrincipal.Tag = "100"
        '
        'labelescribeme
        '
        Me.labelescribeme.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.labelescribeme.AutoSize = True
        Me.labelescribeme.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.labelescribeme.BackColor = System.Drawing.Color.Transparent
        Me.labelescribeme.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelescribeme.Location = New System.Drawing.Point(544, 647)
        Me.labelescribeme.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.labelescribeme.Name = "labelescribeme"
        Me.labelescribeme.Size = New System.Drawing.Size(23, 18)
        Me.labelescribeme.TabIndex = 7
        Me.labelescribeme.textoLabel = " "
        '
        'CtrlBotonMediano1
        '
        Me.CtrlBotonMediano1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CtrlBotonMediano1.BackColor = System.Drawing.Color.Transparent
        Me.CtrlBotonMediano1.EnabledBoton = True
        Me.CtrlBotonMediano1.Location = New System.Drawing.Point(901, 624)
        Me.CtrlBotonMediano1.Name = "CtrlBotonMediano1"
        Me.CtrlBotonMediano1.pImagenMouseEnter = CType(resources.GetObject("CtrlBotonMediano1.pImagenMouseEnter"), System.Drawing.Image)
        Me.CtrlBotonMediano1.pImagenMouseLeave = CType(resources.GetObject("CtrlBotonMediano1.pImagenMouseLeave"), System.Drawing.Image)
        Me.CtrlBotonMediano1.pImagenMouseOver = CType(resources.GetObject("CtrlBotonMediano1.pImagenMouseOver"), System.Drawing.Image)
        Me.CtrlBotonMediano1.Size = New System.Drawing.Size(90, 30)
        Me.CtrlBotonMediano1.TabIndex = 6
        Me.CtrlBotonMediano1.TextoBoton = "Cerrar Lote"
        '
        'CtrlPorcentajeCorreccion1
        '
        Me.CtrlPorcentajeCorreccion1.Location = New System.Drawing.Point(544, 573)
        Me.CtrlPorcentajeCorreccion1.Name = "CtrlPorcentajeCorreccion1"
        Me.CtrlPorcentajeCorreccion1.Size = New System.Drawing.Size(173, 104)
        Me.CtrlPorcentajeCorreccion1.TabIndex = 5
        Me.CtrlPorcentajeCorreccion1.Visible = False
        '
        'frmCorreccionEpidemiologia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1003, 677)
        Me.Controls.Add(Me.labelescribeme)
        Me.Controls.Add(Me.CtrlBotonMediano1)
        Me.Controls.Add(Me.CtrlPorcentajeCorreccion1)
        Me.Controls.Add(Me.IMGeditPrincipal)
        Me.Controls.Add(Me.DataGridView1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCorreccionEpidemiologia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "-= Corrección indización =-"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IMGeditPrincipal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents IMGeditPrincipal As AxImgeditLibCtl.AxImgEdit
    Friend WithEvents CtrlPorcentajeCorreccion1 As Digitalización.ctrlPorcentajeCorreccion
    Friend WithEvents CtrlBotonMediano1 As LibreriaCadenaProduccion.Controles.Botones.CtrlBotonMediano
    Friend WithEvents labelescribeme As LibreriaCadenaProduccion.Controles.Labels.ctrlLabelBase
End Class
