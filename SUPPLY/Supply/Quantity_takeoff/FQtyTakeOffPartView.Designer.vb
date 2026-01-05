<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FQtyTakeOffPartView
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
        Me.components = New System.ComponentModel.Container()
        Me.lvlPartCategory = New System.Windows.Forms.ListView()
        Me.id = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.part_category = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.name_category = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtPart = New System.Windows.Forms.TextBox()
        Me.lblPart = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.txtNameCategory = New System.Windows.Forms.TextBox()
        Me.btn_save = New System.Windows.Forms.Button()
        Me.btn_search = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.lbl_search = New System.Windows.Forms.Label()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvlPartCategory
        '
        Me.lvlPartCategory.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.id, Me.part_category, Me.name_category})
        Me.lvlPartCategory.ContextMenuStrip = Me.ContextMenuStrip1
        Me.lvlPartCategory.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvlPartCategory.FullRowSelect = True
        Me.lvlPartCategory.GridLines = True
        Me.lvlPartCategory.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvlPartCategory.HideSelection = False
        Me.lvlPartCategory.Location = New System.Drawing.Point(12, 68)
        Me.lvlPartCategory.Name = "lvlPartCategory"
        Me.lvlPartCategory.Size = New System.Drawing.Size(556, 306)
        Me.lvlPartCategory.TabIndex = 4
        Me.lvlPartCategory.UseCompatibleStateImageBehavior = False
        Me.lvlPartCategory.View = System.Windows.Forms.View.Details
        '
        'id
        '
        Me.id.Text = "Id"
        Me.id.Width = 0
        '
        'part_category
        '
        Me.part_category.Text = "Part Category"
        Me.part_category.Width = 150
        '
        'name_category
        '
        Me.name_category.Text = "Name"
        Me.name_category.Width = 400
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(108, 48)
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'txtPart
        '
        Me.txtPart.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPart.Location = New System.Drawing.Point(68, 8)
        Me.txtPart.Name = "txtPart"
        Me.txtPart.Size = New System.Drawing.Size(371, 23)
        Me.txtPart.TabIndex = 1
        '
        'lblPart
        '
        Me.lblPart.AutoSize = True
        Me.lblPart.BackColor = System.Drawing.Color.Transparent
        Me.lblPart.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPart.ForeColor = System.Drawing.Color.White
        Me.lblPart.Location = New System.Drawing.Point(9, 11)
        Me.lblPart.Name = "lblPart"
        Me.lblPart.Size = New System.Drawing.Size(40, 16)
        Me.lblPart.TabIndex = 419
        Me.lblPart.Text = "Part:"
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.BackColor = System.Drawing.Color.Transparent
        Me.lblName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.ForeColor = System.Drawing.Color.White
        Me.lblName.Location = New System.Drawing.Point(9, 37)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(53, 16)
        Me.lblName.TabIndex = 420
        Me.lblName.Text = "Name:"
        '
        'txtNameCategory
        '
        Me.txtNameCategory.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNameCategory.Location = New System.Drawing.Point(68, 34)
        Me.txtNameCategory.Name = "txtNameCategory"
        Me.txtNameCategory.Size = New System.Drawing.Size(371, 23)
        Me.txtNameCategory.TabIndex = 2
        '
        'btn_save
        '
        Me.btn_save.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_save.Location = New System.Drawing.Point(443, 7)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(125, 52)
        Me.btn_save.TabIndex = 3
        Me.btn_save.Text = "Save"
        Me.btn_save.UseVisualStyleBackColor = True
        '
        'btn_search
        '
        Me.btn_search.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_search.Location = New System.Drawing.Point(326, 385)
        Me.btn_search.Name = "btn_search"
        Me.btn_search.Size = New System.Drawing.Size(115, 24)
        Me.btn_search.TabIndex = 6
        Me.btn_search.Text = "Search"
        Me.btn_search.UseVisualStyleBackColor = True
        '
        'txtSearch
        '
        Me.txtSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(75, 386)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(246, 22)
        Me.txtSearch.TabIndex = 5
        '
        'lbl_search
        '
        Me.lbl_search.AutoSize = True
        Me.lbl_search.BackColor = System.Drawing.Color.Transparent
        Me.lbl_search.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_search.ForeColor = System.Drawing.Color.White
        Me.lbl_search.Location = New System.Drawing.Point(12, 389)
        Me.lbl_search.Name = "lbl_search"
        Me.lbl_search.Size = New System.Drawing.Size(61, 16)
        Me.lbl_search.TabIndex = 466
        Me.lbl_search.Text = "Search:"
        '
        'FQtyTakeOffPartView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SUPPLY.My.Resources.Resources.bg_line
        Me.ClientSize = New System.Drawing.Size(580, 419)
        Me.Controls.Add(Me.btn_search)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.lbl_search)
        Me.Controls.Add(Me.btn_save)
        Me.Controls.Add(Me.txtNameCategory)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.txtPart)
        Me.Controls.Add(Me.lblPart)
        Me.Controls.Add(Me.lvlPartCategory)
        Me.KeyPreview = True
        Me.Name = "FQtyTakeOffPartView"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FQtyTakeOffPartView"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lvlPartCategory As ListView
    Friend WithEvents id As ColumnHeader
    Friend WithEvents part_category As ColumnHeader
    Friend WithEvents name_category As ColumnHeader
    Friend WithEvents txtPart As TextBox
    Friend WithEvents lblPart As Label
    Friend WithEvents lblName As Label
    Friend WithEvents txtNameCategory As TextBox
    Friend WithEvents btn_save As Button
    Friend WithEvents btn_search As Button
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents lbl_search As Label
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
End Class
