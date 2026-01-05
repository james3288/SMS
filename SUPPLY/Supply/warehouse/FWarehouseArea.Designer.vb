<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FWarehouseArea
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FWarehouseArea))
        Me.lvlWhareaList = New System.Windows.Forms.ListView()
        Me.col_wh_area_id = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_wh_stockpile_area = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_incharge = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_wh_location = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_options = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_whArea_properName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddInchargeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LinkToProperWarehouseNameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtWharea = New System.Windows.Forms.TextBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.txtWarehouseLoc = New System.Windows.Forms.TextBox()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.loadingPanel = New System.Windows.Forms.Panel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.cmbWarehouseOptions = New System.Windows.Forms.ComboBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.pleaseWaitLabel = New System.Windows.Forms.Label()
        Me.txtSearchIncharge = New System.Windows.Forms.TextBox()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.col_incharge_id = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_incharge_name = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnSaveCharges = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.debounce_new = New System.Windows.Forms.Timer(Me.components)
        Me.searchIncharge_debounce = New System.Windows.Forms.Timer(Me.components)
        Me.ContextMenuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.loadingPanel.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvlWhareaList
        '
        Me.lvlWhareaList.BackColor = System.Drawing.Color.DimGray
        Me.lvlWhareaList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.col_wh_area_id, Me.col_wh_stockpile_area, Me.col_incharge, Me.col_wh_location, Me.col_options, Me.col_whArea_properName})
        Me.lvlWhareaList.ContextMenuStrip = Me.ContextMenuStrip1
        Me.lvlWhareaList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvlWhareaList.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvlWhareaList.ForeColor = System.Drawing.SystemColors.InactiveCaption
        Me.lvlWhareaList.FullRowSelect = True
        Me.lvlWhareaList.HideSelection = False
        Me.lvlWhareaList.Location = New System.Drawing.Point(0, 0)
        Me.lvlWhareaList.Name = "lvlWhareaList"
        Me.lvlWhareaList.Size = New System.Drawing.Size(871, 510)
        Me.lvlWhareaList.TabIndex = 3
        Me.lvlWhareaList.UseCompatibleStateImageBehavior = False
        Me.lvlWhareaList.View = System.Windows.Forms.View.Details
        '
        'col_wh_area_id
        '
        Me.col_wh_area_id.Text = "w_area_id"
        Me.col_wh_area_id.Width = 0
        '
        'col_wh_stockpile_area
        '
        Me.col_wh_stockpile_area.Text = "Wh/Qry Area"
        Me.col_wh_stockpile_area.Width = 250
        '
        'col_incharge
        '
        Me.col_incharge.Text = "Wh/Qry Incharge"
        Me.col_incharge.Width = 250
        '
        'col_wh_location
        '
        Me.col_wh_location.Text = "Wh/Qry Loc."
        Me.col_wh_location.Width = 250
        '
        'col_options
        '
        Me.col_options.Text = "Options"
        Me.col_options.Width = 200
        '
        'col_whArea_properName
        '
        Me.col_whArea_properName.Text = "Warehouse Area Proper Name"
        Me.col_whArea_properName.Width = 150
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditToolStripMenuItem, Me.RemoveToolStripMenuItem, Me.AddInchargeToolStripMenuItem, Me.LinkToProperWarehouseNameToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(246, 92)
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Image = Global.SUPPLY.My.Resources.Resources.request
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'RemoveToolStripMenuItem
        '
        Me.RemoveToolStripMenuItem.Image = Global.SUPPLY.My.Resources.Resources.remove_icon
        Me.RemoveToolStripMenuItem.Name = "RemoveToolStripMenuItem"
        Me.RemoveToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.RemoveToolStripMenuItem.Text = "Remove"
        '
        'AddInchargeToolStripMenuItem
        '
        Me.AddInchargeToolStripMenuItem.Image = CType(resources.GetObject("AddInchargeToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AddInchargeToolStripMenuItem.Name = "AddInchargeToolStripMenuItem"
        Me.AddInchargeToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.AddInchargeToolStripMenuItem.Text = "Add Incharge"
        '
        'LinkToProperWarehouseNameToolStripMenuItem
        '
        Me.LinkToProperWarehouseNameToolStripMenuItem.Name = "LinkToProperWarehouseNameToolStripMenuItem"
        Me.LinkToProperWarehouseNameToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.LinkToProperWarehouseNameToolStripMenuItem.Text = "Link to Proper Warehouse Name"
        '
        'txtWharea
        '
        Me.txtWharea.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWharea.Location = New System.Drawing.Point(59, 78)
        Me.txtWharea.Name = "txtWharea"
        Me.txtWharea.Size = New System.Drawing.Size(255, 26)
        Me.txtWharea.TabIndex = 2
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Location = New System.Drawing.Point(145, 186)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(169, 32)
        Me.btnSave.TabIndex = 4
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnEdit
        '
        Me.btnEdit.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEdit.Location = New System.Drawing.Point(59, 186)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(80, 32)
        Me.btnEdit.TabIndex = 5
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = False
        '
        'txtWarehouseLoc
        '
        Me.txtWarehouseLoc.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWarehouseLoc.Location = New System.Drawing.Point(59, 131)
        Me.txtWarehouseLoc.Name = "txtWarehouseLoc"
        Me.txtWarehouseLoc.Size = New System.Drawing.Size(255, 26)
        Me.txtWarehouseLoc.TabIndex = 3
        '
        'txtSearch
        '
        Me.txtSearch.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(749, 11)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(437, 26)
        Me.txtSearch.TabIndex = 8
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BackgroundImage = Global.SUPPLY.My.Resources.Resources.bg_line
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.loadingPanel)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1198, 59)
        Me.Panel1.TabIndex = 9
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Controls.Add(Me.PictureBox2)
        Me.Panel4.Location = New System.Drawing.Point(761, 6)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(434, 44)
        Me.Panel4.TabIndex = 425
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.SpringGreen
        Me.Label1.Location = New System.Drawing.Point(47, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(367, 32)
        Me.Label1.TabIndex = 422
        Me.Label1.Text = "WAREHOUSE / STOCKPILE"
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.PictureBox2.Image = Global.SUPPLY.My.Resources.Resources.reg_button
        Me.PictureBox2.Location = New System.Drawing.Point(5, 2)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(39, 40)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 423
        Me.PictureBox2.TabStop = False
        '
        'loadingPanel
        '
        Me.loadingPanel.BackColor = System.Drawing.Color.Transparent
        Me.loadingPanel.Controls.Add(Me.Label12)
        Me.loadingPanel.Controls.Add(Me.PictureBox1)
        Me.loadingPanel.Location = New System.Drawing.Point(3, 8)
        Me.loadingPanel.Name = "loadingPanel"
        Me.loadingPanel.Size = New System.Drawing.Size(301, 42)
        Me.loadingPanel.TabIndex = 421
        Me.loadingPanel.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(43, 11)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(204, 19)
        Me.Label12.TabIndex = 1
        Me.Label12.Text = "Fetching data, please wait..."
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.SUPPLY.My.Resources.Resources.spinner
        Me.PictureBox1.Location = New System.Drawing.Point(4, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(33, 33)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.BackgroundImage = Global.SUPPLY.My.Resources.Resources.bg_line
        Me.Panel2.Controls.Add(Me.txtSearch)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 569)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1198, 44)
        Me.Panel2.TabIndex = 10
        '
        'Panel3
        '
        Me.Panel3.BackgroundImage = Global.SUPPLY.My.Resources.Resources.bg_line
        Me.Panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel3.Controls.Add(Me.cmbWarehouseOptions)
        Me.Panel3.Controls.Add(Me.txtWharea)
        Me.Panel3.Controls.Add(Me.txtWarehouseLoc)
        Me.Panel3.Controls.Add(Me.btnSave)
        Me.Panel3.Controls.Add(Me.btnEdit)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(0, 59)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(327, 510)
        Me.Panel3.TabIndex = 11
        '
        'cmbWarehouseOptions
        '
        Me.cmbWarehouseOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbWarehouseOptions.FormattingEnabled = True
        Me.cmbWarehouseOptions.Location = New System.Drawing.Point(59, 30)
        Me.cmbWarehouseOptions.Name = "cmbWarehouseOptions"
        Me.cmbWarehouseOptions.Size = New System.Drawing.Size(255, 21)
        Me.cmbWarehouseOptions.TabIndex = 1
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Panel6)
        Me.Panel5.Controls.Add(Me.lvlWhareaList)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(327, 59)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(871, 510)
        Me.Panel5.TabIndex = 12
        '
        'Panel6
        '
        Me.Panel6.BackgroundImage = Global.SUPPLY.My.Resources.Resources.bg_line
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.pleaseWaitLabel)
        Me.Panel6.Controls.Add(Me.txtSearchIncharge)
        Me.Panel6.Controls.Add(Me.ListView1)
        Me.Panel6.Controls.Add(Me.btnSaveCharges)
        Me.Panel6.Controls.Add(Me.Button2)
        Me.Panel6.Location = New System.Drawing.Point(152, 73)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(377, 412)
        Me.Panel6.TabIndex = 424
        Me.Panel6.Visible = False
        '
        'pleaseWaitLabel
        '
        Me.pleaseWaitLabel.AutoSize = True
        Me.pleaseWaitLabel.BackColor = System.Drawing.Color.Transparent
        Me.pleaseWaitLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pleaseWaitLabel.Location = New System.Drawing.Point(15, 16)
        Me.pleaseWaitLabel.Name = "pleaseWaitLabel"
        Me.pleaseWaitLabel.Size = New System.Drawing.Size(69, 13)
        Me.pleaseWaitLabel.TabIndex = 421
        Me.pleaseWaitLabel.Text = "please wait..."
        '
        'txtSearchIncharge
        '
        Me.txtSearchIncharge.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearchIncharge.Location = New System.Drawing.Point(53, 39)
        Me.txtSearchIncharge.Name = "txtSearchIncharge"
        Me.txtSearchIncharge.Size = New System.Drawing.Size(304, 26)
        Me.txtSearchIncharge.TabIndex = 420
        '
        'ListView1
        '
        Me.ListView1.CheckBoxes = True
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.col_incharge_id, Me.col_incharge_name})
        Me.ListView1.FullRowSelect = True
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(17, 77)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(340, 265)
        Me.ListView1.TabIndex = 419
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'col_incharge_id
        '
        Me.col_incharge_id.Text = "incharge_id"
        Me.col_incharge_id.Width = 110
        '
        'col_incharge_name
        '
        Me.col_incharge_name.Text = "Incharge Name"
        Me.col_incharge_name.Width = 220
        '
        'btnSaveCharges
        '
        Me.btnSaveCharges.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnSaveCharges.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSaveCharges.Location = New System.Drawing.Point(17, 357)
        Me.btnSaveCharges.Name = "btnSaveCharges"
        Me.btnSaveCharges.Size = New System.Drawing.Size(340, 32)
        Me.btnSaveCharges.TabIndex = 418
        Me.btnSaveCharges.Text = "Save"
        Me.btnSaveCharges.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.BackgroundImage = Global.SUPPLY.My.Resources.Resources.close_button
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(346, 7)
        Me.Button2.Margin = New System.Windows.Forms.Padding(3, 3, 10, 3)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(22, 22)
        Me.Button2.TabIndex = 413
        Me.Button2.UseVisualStyleBackColor = False
        '
        'debounce_new
        '
        Me.debounce_new.Interval = 500
        '
        'searchIncharge_debounce
        '
        Me.searchIncharge_debounce.Interval = 500
        '
        'FWarehouseArea
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1198, 613)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FWarehouseArea"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FWarehouseArea"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.loadingPanel.ResumeLayout(False)
        Me.loadingPanel.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lvlWhareaList As System.Windows.Forms.ListView
    Friend WithEvents col_wh_area_id As System.Windows.Forms.ColumnHeader
    Friend WithEvents col_wh_stockpile_area As System.Windows.Forms.ColumnHeader
    Friend WithEvents col_incharge As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtWharea As System.Windows.Forms.TextBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents txtWarehouseLoc As System.Windows.Forms.TextBox
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents loadingPanel As Panel
    Friend WithEvents Label12 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents debounce_new As Timer
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RemoveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents cmbWarehouseOptions As ComboBox
    Friend WithEvents Panel6 As Panel
    Friend WithEvents btnSaveCharges As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents ListView1 As ListView
    Friend WithEvents col_incharge_id As ColumnHeader
    Friend WithEvents col_incharge_name As ColumnHeader
    Friend WithEvents AddInchargeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents txtSearchIncharge As TextBox
    Friend WithEvents searchIncharge_debounce As Timer
    Friend WithEvents pleaseWaitLabel As Label
    Friend WithEvents LinkToProperWarehouseNameToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents col_whArea_properName As ColumnHeader
    Friend WithEvents col_wh_location As ColumnHeader
    Friend WithEvents col_options As ColumnHeader
End Class
