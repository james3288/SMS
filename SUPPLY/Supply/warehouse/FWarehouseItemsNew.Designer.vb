<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FWarehouseItemsNew
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
        Me.debounce_new = New System.Windows.Forms.Timer(Me.components)
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditWarehouseAreaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditProperNamingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditQuarryCodeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditKPIToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditZoningPriceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveWarehouseAreaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveQuarryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveProperNamingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreateNewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewStockCardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreateTransactionForDRToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FOROUTWITHOURRSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FORINWITHOUTRSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FOROTHERSWITHOUTRSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnWhStockpileQuarryArea = New System.Windows.Forms.Button()
        Me.btnAddProperName = New System.Windows.Forms.Button()
        Me.btnListOfWhItem = New System.Windows.Forms.Button()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.cmbSearchBy = New System.Windows.Forms.ComboBox()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.loadingPanel = New System.Windows.Forms.Panel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.lblProperName = New System.Windows.Forms.Label()
        Me.Panel3.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.loadingPanel.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'debounce_new
        '
        Me.debounce_new.Interval = 2000
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.DataGridView1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 59)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1135, 477)
        Me.Panel3.TabIndex = 15
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(1135, 477)
        Me.DataGridView1.TabIndex = 0
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditToolStripMenuItem, Me.RemoveToolStripMenuItem, Me.CreateNewToolStripMenuItem, Me.ViewStockCardToolStripMenuItem, Me.CreateTransactionForDRToolStripMenuItem, Me.RefreshToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(208, 158)
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditWarehouseAreaToolStripMenuItem, Me.EditProperNamingToolStripMenuItem, Me.EditQuarryCodeToolStripMenuItem, Me.EditKPIToolStripMenuItem, Me.EditToolStripMenuItem1, Me.EditZoningPriceToolStripMenuItem, Me.RemoveToolStripMenuItem1})
        Me.EditToolStripMenuItem.Image = Global.SUPPLY.My.Resources.Resources.request
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'EditWarehouseAreaToolStripMenuItem
        '
        Me.EditWarehouseAreaToolStripMenuItem.Name = "EditWarehouseAreaToolStripMenuItem"
        Me.EditWarehouseAreaToolStripMenuItem.Size = New System.Drawing.Size(265, 22)
        Me.EditWarehouseAreaToolStripMenuItem.Text = "Edit Warehouse/Stockpile Area"
        '
        'EditProperNamingToolStripMenuItem
        '
        Me.EditProperNamingToolStripMenuItem.Name = "EditProperNamingToolStripMenuItem"
        Me.EditProperNamingToolStripMenuItem.Size = New System.Drawing.Size(265, 22)
        Me.EditProperNamingToolStripMenuItem.Text = "Edit Proper Naming"
        '
        'EditQuarryCodeToolStripMenuItem
        '
        Me.EditQuarryCodeToolStripMenuItem.Name = "EditQuarryCodeToolStripMenuItem"
        Me.EditQuarryCodeToolStripMenuItem.Size = New System.Drawing.Size(265, 22)
        Me.EditQuarryCodeToolStripMenuItem.Text = "Edit Quarry Code"
        '
        'EditKPIToolStripMenuItem
        '
        Me.EditKPIToolStripMenuItem.Name = "EditKPIToolStripMenuItem"
        Me.EditKPIToolStripMenuItem.Size = New System.Drawing.Size(265, 22)
        Me.EditKPIToolStripMenuItem.Text = "Edit Key Performance Indicator (KPI)"
        '
        'EditToolStripMenuItem1
        '
        Me.EditToolStripMenuItem1.Name = "EditToolStripMenuItem1"
        Me.EditToolStripMenuItem1.Size = New System.Drawing.Size(265, 22)
        Me.EditToolStripMenuItem1.Text = "Edit All"
        '
        'EditZoningPriceToolStripMenuItem
        '
        Me.EditZoningPriceToolStripMenuItem.Name = "EditZoningPriceToolStripMenuItem"
        Me.EditZoningPriceToolStripMenuItem.Size = New System.Drawing.Size(265, 22)
        Me.EditZoningPriceToolStripMenuItem.Text = "Edit Zoning Price"
        '
        'RemoveToolStripMenuItem1
        '
        Me.RemoveToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RemoveWarehouseAreaToolStripMenuItem, Me.RemoveQuarryToolStripMenuItem, Me.RemoveProperNamingToolStripMenuItem})
        Me.RemoveToolStripMenuItem1.Name = "RemoveToolStripMenuItem1"
        Me.RemoveToolStripMenuItem1.Size = New System.Drawing.Size(265, 22)
        Me.RemoveToolStripMenuItem1.Text = "Remove"
        '
        'RemoveWarehouseAreaToolStripMenuItem
        '
        Me.RemoveWarehouseAreaToolStripMenuItem.Name = "RemoveWarehouseAreaToolStripMenuItem"
        Me.RemoveWarehouseAreaToolStripMenuItem.Size = New System.Drawing.Size(265, 22)
        Me.RemoveWarehouseAreaToolStripMenuItem.Text = "Remove  Warehouse/Stockpile  Area"
        '
        'RemoveQuarryToolStripMenuItem
        '
        Me.RemoveQuarryToolStripMenuItem.Name = "RemoveQuarryToolStripMenuItem"
        Me.RemoveQuarryToolStripMenuItem.Size = New System.Drawing.Size(265, 22)
        Me.RemoveQuarryToolStripMenuItem.Text = "Remove Quarry"
        '
        'RemoveProperNamingToolStripMenuItem
        '
        Me.RemoveProperNamingToolStripMenuItem.Name = "RemoveProperNamingToolStripMenuItem"
        Me.RemoveProperNamingToolStripMenuItem.Size = New System.Drawing.Size(265, 22)
        Me.RemoveProperNamingToolStripMenuItem.Text = "Remove Proper Naming"
        '
        'RemoveToolStripMenuItem
        '
        Me.RemoveToolStripMenuItem.Image = Global.SUPPLY.My.Resources.Resources.remove_icon
        Me.RemoveToolStripMenuItem.Name = "RemoveToolStripMenuItem"
        Me.RemoveToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.RemoveToolStripMenuItem.Text = "Remove"
        '
        'CreateNewToolStripMenuItem
        '
        Me.CreateNewToolStripMenuItem.Image = Global.SUPPLY.My.Resources.Resources.done
        Me.CreateNewToolStripMenuItem.Name = "CreateNewToolStripMenuItem"
        Me.CreateNewToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.CreateNewToolStripMenuItem.Text = "Create New"
        '
        'ViewStockCardToolStripMenuItem
        '
        Me.ViewStockCardToolStripMenuItem.Name = "ViewStockCardToolStripMenuItem"
        Me.ViewStockCardToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.ViewStockCardToolStripMenuItem.Text = "View StockCard"
        '
        'CreateTransactionForDRToolStripMenuItem
        '
        Me.CreateTransactionForDRToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FOROUTWITHOURRSToolStripMenuItem, Me.FORINWITHOUTRSToolStripMenuItem, Me.FOROTHERSWITHOUTRSToolStripMenuItem})
        Me.CreateTransactionForDRToolStripMenuItem.Name = "CreateTransactionForDRToolStripMenuItem"
        Me.CreateTransactionForDRToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.CreateTransactionForDRToolStripMenuItem.Text = "Create Transaction for DR"
        '
        'FOROUTWITHOURRSToolStripMenuItem
        '
        Me.FOROUTWITHOURRSToolStripMenuItem.Name = "FOROUTWITHOURRSToolStripMenuItem"
        Me.FOROUTWITHOURRSToolStripMenuItem.Size = New System.Drawing.Size(212, 22)
        Me.FOROUTWITHOURRSToolStripMenuItem.Text = "FOR OUT WITHOUR RS"
        '
        'FORINWITHOUTRSToolStripMenuItem
        '
        Me.FORINWITHOUTRSToolStripMenuItem.Name = "FORINWITHOUTRSToolStripMenuItem"
        Me.FORINWITHOUTRSToolStripMenuItem.Size = New System.Drawing.Size(212, 22)
        Me.FORINWITHOUTRSToolStripMenuItem.Text = "FOR IN WITHOUT RS"
        '
        'FOROTHERSWITHOUTRSToolStripMenuItem
        '
        Me.FOROTHERSWITHOUTRSToolStripMenuItem.Name = "FOROTHERSWITHOUTRSToolStripMenuItem"
        Me.FOROTHERSWITHOUTRSToolStripMenuItem.Size = New System.Drawing.Size(212, 22)
        Me.FOROTHERSWITHOUTRSToolStripMenuItem.Text = "FOR OTHERS WITHOUT RS"
        '
        'RefreshToolStripMenuItem
        '
        Me.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem"
        Me.RefreshToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.RefreshToolStripMenuItem.Text = "Refresh"
        '
        'Panel2
        '
        Me.Panel2.BackgroundImage = Global.SUPPLY.My.Resources.Resources.bg_line
        Me.Panel2.Controls.Add(Me.btnWhStockpileQuarryArea)
        Me.Panel2.Controls.Add(Me.btnAddProperName)
        Me.Panel2.Controls.Add(Me.btnListOfWhItem)
        Me.Panel2.Controls.Add(Me.Panel5)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 536)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1135, 56)
        Me.Panel2.TabIndex = 14
        '
        'btnWhStockpileQuarryArea
        '
        Me.btnWhStockpileQuarryArea.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnWhStockpileQuarryArea.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnWhStockpileQuarryArea.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnWhStockpileQuarryArea.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnWhStockpileQuarryArea.Location = New System.Drawing.Point(263, 7)
        Me.btnWhStockpileQuarryArea.Name = "btnWhStockpileQuarryArea"
        Me.btnWhStockpileQuarryArea.Size = New System.Drawing.Size(107, 42)
        Me.btnWhStockpileQuarryArea.TabIndex = 425
        Me.btnWhStockpileQuarryArea.Text = "WH/STOCKPILE/QUARRY AREA"
        Me.btnWhStockpileQuarryArea.UseVisualStyleBackColor = False
        '
        'btnAddProperName
        '
        Me.btnAddProperName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnAddProperName.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnAddProperName.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddProperName.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddProperName.Location = New System.Drawing.Point(147, 7)
        Me.btnAddProperName.Name = "btnAddProperName"
        Me.btnAddProperName.Size = New System.Drawing.Size(110, 42)
        Me.btnAddProperName.TabIndex = 424
        Me.btnAddProperName.Text = "ADD PROPER NAMES"
        Me.btnAddProperName.UseVisualStyleBackColor = False
        '
        'btnListOfWhItem
        '
        Me.btnListOfWhItem.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnListOfWhItem.BackColor = System.Drawing.Color.YellowGreen
        Me.btnListOfWhItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnListOfWhItem.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnListOfWhItem.Location = New System.Drawing.Point(10, 7)
        Me.btnListOfWhItem.Name = "btnListOfWhItem"
        Me.btnListOfWhItem.Size = New System.Drawing.Size(131, 42)
        Me.btnListOfWhItem.TabIndex = 423
        Me.btnListOfWhItem.Text = "PREVIEW LIST OF WAREHOUSE ITEMS"
        Me.btnListOfWhItem.UseVisualStyleBackColor = False
        '
        'Panel5
        '
        Me.Panel5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel5.BackColor = System.Drawing.Color.Transparent
        Me.Panel5.Controls.Add(Me.btnSearch)
        Me.Panel5.Controls.Add(Me.cmbSearchBy)
        Me.Panel5.Controls.Add(Me.txtSearch)
        Me.Panel5.Location = New System.Drawing.Point(402, 6)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(720, 44)
        Me.Panel5.TabIndex = 422
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.Olive
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.Font = New System.Drawing.Font("Bombardier", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(613, 4)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(93, 30)
        Me.btnSearch.TabIndex = 12
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'cmbSearchBy
        '
        Me.cmbSearchBy.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmbSearchBy.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbSearchBy.FormattingEnabled = True
        Me.cmbSearchBy.Location = New System.Drawing.Point(76, 7)
        Me.cmbSearchBy.Name = "cmbSearchBy"
        Me.cmbSearchBy.Size = New System.Drawing.Size(255, 21)
        Me.cmbSearchBy.TabIndex = 11
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.txtSearch.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(387, 9)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(203, 26)
        Me.txtSearch.TabIndex = 10
        '
        'loadingPanel
        '
        Me.loadingPanel.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.loadingPanel.BackColor = System.Drawing.Color.Transparent
        Me.loadingPanel.Controls.Add(Me.Label12)
        Me.loadingPanel.Controls.Add(Me.PictureBox1)
        Me.loadingPanel.Location = New System.Drawing.Point(607, 6)
        Me.loadingPanel.Name = "loadingPanel"
        Me.loadingPanel.Size = New System.Drawing.Size(249, 42)
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
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BackgroundImage = Global.SUPPLY.My.Resources.Resources.bg_line
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.loadingPanel)
        Me.Panel1.Controls.Add(Me.lblProperName)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1135, 59)
        Me.Panel1.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.GreenYellow
        Me.Label2.Location = New System.Drawing.Point(14, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(222, 15)
        Me.Label2.TabIndex = 441
        Me.Label2.Text = "PROPER NAME CHOSEN BY THE USER:"
        Me.Label2.Visible = False
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.Controls.Add(Me.Button1)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Controls.Add(Me.PictureBox2)
        Me.Panel4.Location = New System.Drawing.Point(862, 6)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(270, 44)
        Me.Panel4.TabIndex = 425
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.BackgroundImage = Global.SUPPLY.My.Resources.Resources.close_button
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(226, 11)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 3, 10, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(22, 22)
        Me.Button1.TabIndex = 424
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Bombardier", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.SpringGreen
        Me.Label1.Location = New System.Drawing.Point(48, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(154, 24)
        Me.Label1.TabIndex = 422
        Me.Label1.Text = "WAREHOUSE ITEMS"
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.PictureBox2.Image = Global.SUPPLY.My.Resources.Resources.reg_button
        Me.PictureBox2.Location = New System.Drawing.Point(3, 3)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(39, 40)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 423
        Me.PictureBox2.TabStop = False
        '
        'lblProperName
        '
        Me.lblProperName.AutoSize = True
        Me.lblProperName.Font = New System.Drawing.Font("Bombardier", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProperName.ForeColor = System.Drawing.Color.LimeGreen
        Me.lblProperName.Location = New System.Drawing.Point(26, 32)
        Me.lblProperName.Name = "lblProperName"
        Me.lblProperName.Size = New System.Drawing.Size(15, 18)
        Me.lblProperName.TabIndex = 440
        Me.lblProperName.Text = "*"
        Me.lblProperName.Visible = False
        '
        'FWarehouseItemsNew
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1135, 592)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FWarehouseItemsNew"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FWarehouseItemsNew"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel3.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.loadingPanel.ResumeLayout(False)
        Me.loadingPanel.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents debounce_new As Timer
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RemoveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CreateNewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label12 As Label
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents loadingPanel As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents cmbSearchBy As ComboBox
    Friend WithEvents EditWarehouseAreaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditProperNamingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditQuarryCodeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditKPIToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Button1 As Button
    Friend WithEvents EditToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ViewStockCardToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditZoningPriceToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RemoveToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents RemoveWarehouseAreaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RemoveQuarryToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnListOfWhItem As Button
    Friend WithEvents btnSearch As Button
    Friend WithEvents lblProperName As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents CreateTransactionForDRToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FOROUTWITHOURRSToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FORINWITHOUTRSToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FOROTHERSWITHOUTRSToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RemoveProperNamingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RefreshToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnAddProperName As Button
    Friend WithEvents btnWhStockpileQuarryArea As Button
End Class
