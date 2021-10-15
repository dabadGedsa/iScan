Namespace Controles
    Namespace Listados

        <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
        Partial Class CtrlListViewInfo
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
                Me.components = New System.ComponentModel.Container
                Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CtrlListViewInfo))
                Me.ListViewInfo = New System.Windows.Forms.ListView
                Me.ImageListInfo = New System.Windows.Forms.ImageList(Me.components)
                Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
                Me.SuspendLayout()
                '
                'ListViewInfo
                '
                Me.ListViewInfo.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
                Me.ListViewInfo.Dock = System.Windows.Forms.DockStyle.Fill
                Me.ListViewInfo.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
                Me.ListViewInfo.Location = New System.Drawing.Point(0, 0)
                Me.ListViewInfo.Name = "ListViewInfo"
                Me.ListViewInfo.ShowItemToolTips = True
                Me.ListViewInfo.Size = New System.Drawing.Size(150, 150)
                Me.ListViewInfo.SmallImageList = Me.ImageListInfo
                Me.ListViewInfo.TabIndex = 0
                Me.ListViewInfo.UseCompatibleStateImageBehavior = False
                Me.ListViewInfo.View = System.Windows.Forms.View.Details
                '
                'ImageListInfo
                '
                Me.ImageListInfo.ImageStream = CType(resources.GetObject("ImageListInfo.ImageStream"), System.Windows.Forms.ImageListStreamer)
                Me.ImageListInfo.TransparentColor = System.Drawing.Color.Transparent
                Me.ImageListInfo.Images.SetKeyName(0, "_information.png")
                Me.ImageListInfo.Images.SetKeyName(1, "_ok.png")
                Me.ImageListInfo.Images.SetKeyName(2, "_warning.png")
                Me.ImageListInfo.Images.SetKeyName(3, "_error.png")
                '
                'CtrlListViewInfo
                '
                Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
                Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
                Me.Controls.Add(Me.ListViewInfo)
                Me.Name = "CtrlListViewInfo"
                Me.ResumeLayout(False)

            End Sub
            Friend WithEvents ListViewInfo As System.Windows.Forms.ListView
            Friend WithEvents ImageListInfo As System.Windows.Forms.ImageList
            Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader

        End Class

    End Namespace
End Namespace