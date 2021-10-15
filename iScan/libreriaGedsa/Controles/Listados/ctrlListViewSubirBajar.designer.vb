Namespace Controles
    Namespace Listados

        <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
        Partial Class CtrlListViewSubirBajar
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
                Me.ctrlSubir = New System.Windows.Forms.Button
                Me.ListViewSubirBajar = New System.Windows.Forms.ListView
                Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
                Me.ctrlBajar = New System.Windows.Forms.Button
                Me.SuspendLayout()
                '
                'ctrlSubir
                '
                Me.ctrlSubir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
                Me.ctrlSubir.BackgroundImage = My.Resources.Resources.cmdSubir
                Me.ctrlSubir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
                Me.ctrlSubir.Location = New System.Drawing.Point(327, 24)
                Me.ctrlSubir.Name = "ctrlSubir"
                Me.ctrlSubir.Size = New System.Drawing.Size(19, 22)
                Me.ctrlSubir.TabIndex = 27
                Me.ctrlSubir.UseVisualStyleBackColor = True
                '
                'ListViewSubirBajar
                '
                Me.ListViewSubirBajar.AllowDrop = True
                Me.ListViewSubirBajar.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                            Or System.Windows.Forms.AnchorStyles.Left) _
                            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
                Me.ListViewSubirBajar.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3})
                Me.ListViewSubirBajar.FullRowSelect = True
                Me.ListViewSubirBajar.GridLines = True
                Me.ListViewSubirBajar.HideSelection = False
                Me.ListViewSubirBajar.Location = New System.Drawing.Point(0, 0)
                Me.ListViewSubirBajar.MultiSelect = False
                Me.ListViewSubirBajar.Name = "ListViewSubirBajar"
                Me.ListViewSubirBajar.Size = New System.Drawing.Size(321, 334)
                Me.ListViewSubirBajar.Sorting = System.Windows.Forms.SortOrder.Ascending
                Me.ListViewSubirBajar.TabIndex = 26
                Me.ListViewSubirBajar.UseCompatibleStateImageBehavior = False
                Me.ListViewSubirBajar.View = System.Windows.Forms.View.Details
                '
                'ColumnHeader3
                '
                Me.ColumnHeader3.Text = "Posición"
                '
                'ctrlBajar
                '
                Me.ctrlBajar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
                Me.ctrlBajar.BackgroundImage = My.Resources.Resources.cmdBajar
                Me.ctrlBajar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
                Me.ctrlBajar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
                Me.ctrlBajar.Location = New System.Drawing.Point(327, 53)
                Me.ctrlBajar.Name = "ctrlBajar"
                Me.ctrlBajar.Size = New System.Drawing.Size(19, 22)
                Me.ctrlBajar.TabIndex = 28
                Me.ctrlBajar.UseVisualStyleBackColor = True
                '
                'CtrlListViewSubirBajar
                '
                Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
                Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
                Me.BackColor = System.Drawing.Color.Transparent
                Me.Controls.Add(Me.ctrlBajar)
                Me.Controls.Add(Me.ctrlSubir)
                Me.Controls.Add(Me.ListViewSubirBajar)
                Me.Name = "CtrlListViewSubirBajar"
                Me.Size = New System.Drawing.Size(349, 334)
                Me.ResumeLayout(False)

            End Sub
            Protected WithEvents ctrlBajar As System.Windows.Forms.Button
            Protected WithEvents ctrlSubir As System.Windows.Forms.Button
            Protected WithEvents ListViewSubirBajar As System.Windows.Forms.ListView
            Protected WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader

        End Class


    End Namespace
End Namespace
