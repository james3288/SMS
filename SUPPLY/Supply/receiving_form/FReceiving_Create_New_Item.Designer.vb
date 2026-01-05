<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FReceiving_Create_New_Item
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lvlCreate_New_Item = New System.Windows.Forms.ListView()
        Me.col_rs_id = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_item_name = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_item_desc = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_unit = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_wh_id = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lvlCreate_New_Item
        '
        Me.lvlCreate_New_Item.CheckBoxes = True
        Me.lvlCreate_New_Item.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.col_rs_id, Me.col_item_name, Me.col_item_desc, Me.col_unit, Me.col_wh_id})
        Me.lvlCreate_New_Item.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvlCreate_New_Item.FullRowSelect = True
        Me.lvlCreate_New_Item.GridLines = True
        Me.lvlCreate_New_Item.Location = New System.Drawing.Point(12, 14)
        Me.lvlCreate_New_Item.Name = "lvlCreate_New_Item"
        Me.lvlCreate_New_Item.Size = New System.Drawing.Size(860, 477)
        Me.lvlCreate_New_Item.TabIndex = 0
        Me.lvlCreate_New_Item.UseCompatibleStateImageBehavior = False
        Me.lvlCreate_New_Item.View = System.Windows.Forms.View.Details
        '
        'col_rs_id
        '
        Me.col_rs_id.Text = "rs_id"
        Me.col_rs_id.Width = 114
        '
        'col_item_name
        '
        Me.col_item_name.Text = "Item Name"
        Me.col_item_name.Width = 301
        '
        'col_item_desc
        '
        Me.col_item_desc.Text = "Item Description"
        Me.col_item_desc.Width = 226
        '
        'col_unit
        '
        Me.col_unit.Text = "unit"
        Me.col_unit.Width = 103
        '
        'col_wh_id
        '
        Me.col_wh_id.Text = "wh_id"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(667, 500)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(205, 40)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Create and Update"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'FReceiving_Create_New_Item
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 554)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lvlCreate_New_Item)
        Me.Name = "FReceiving_Create_New_Item"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FReceiving_Create_New_Item"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lvlCreate_New_Item As ListView
    Friend WithEvents col_rs_id As ColumnHeader
    Friend WithEvents col_item_name As ColumnHeader
    Friend WithEvents col_item_desc As ColumnHeader
    Friend WithEvents Button1 As Button
    Friend WithEvents col_unit As ColumnHeader
    Friend WithEvents col_wh_id As ColumnHeader
End Class
