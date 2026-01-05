<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FUpdateItemNameDesc
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.FindRelatedItemsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Col_Check = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Col_Wh_Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_Item_Name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_Item_Desc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rs_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Col_Check, Me.Col_Wh_Id, Me.Column2, Me.Col_Item_Name, Me.Col_Item_Desc, Me.rs_id})
        Me.DataGridView1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.DataGridView1.Location = New System.Drawing.Point(4, 5)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(1044, 428)
        Me.DataGridView1.TabIndex = 0
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FindRelatedItemsToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(172, 26)
        '
        'FindRelatedItemsToolStripMenuItem
        '
        Me.FindRelatedItemsToolStripMenuItem.Name = "FindRelatedItemsToolStripMenuItem"
        Me.FindRelatedItemsToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.FindRelatedItemsToolStripMenuItem.Text = "Find Related Items"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(876, 438)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(172, 33)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Update"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Col_Check
        '
        Me.Col_Check.HeaderText = "check"
        Me.Col_Check.Name = "Col_Check"
        Me.Col_Check.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Col_Check.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Col_Wh_Id
        '
        Me.Col_Wh_Id.HeaderText = "wh_id"
        Me.Col_Wh_Id.Name = "Col_Wh_Id"
        '
        'Column2
        '
        Me.Column2.HeaderText = "Previous Name"
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 250
        '
        'Col_Item_Name
        '
        Me.Col_Item_Name.HeaderText = "Item Name"
        Me.Col_Item_Name.Name = "Col_Item_Name"
        Me.Col_Item_Name.Width = 250
        '
        'Col_Item_Desc
        '
        Me.Col_Item_Desc.HeaderText = "Item Description"
        Me.Col_Item_Desc.Name = "Col_Item_Desc"
        Me.Col_Item_Desc.Width = 300
        '
        'rs_id
        '
        Me.rs_id.HeaderText = "rs_id"
        Me.rs_id.Name = "rs_id"
        '
        'FUpdateItemNameDesc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1053, 475)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DataGridView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FUpdateItemNameDesc"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Updating Item Name and Description"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button1 As Button
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents FindRelatedItemsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Col_Check As DataGridViewCheckBoxColumn
    Friend WithEvents Col_Wh_Id As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Col_Item_Name As DataGridViewTextBoxColumn
    Friend WithEvents Col_Item_Desc As DataGridViewTextBoxColumn
    Friend WithEvents rs_id As DataGridViewTextBoxColumn
End Class
