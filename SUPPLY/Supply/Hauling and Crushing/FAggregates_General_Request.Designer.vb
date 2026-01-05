<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FAggregates_General_Request
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FAggregates_General_Request))
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SelectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeselectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CalculateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GenerateAllProjectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SetAggregatesNameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtCharges = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.cmbSearchby = New System.Windows.Forms.ComboBox()
        Me.cmbProject = New System.Windows.Forms.ComboBox()
        Me.cmbAggregates = New System.Windows.Forms.ComboBox()
        Me.dtpfrom = New System.Windows.Forms.DateTimePicker()
        Me.dtpto = New System.Windows.Forms.DateTimePicker()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.panel_listview = New System.Windows.Forms.Panel()
        Me.panel_for_listview = New System.Windows.Forms.Panel()
        Me.lvlAllRs = New System.Windows.Forms.ListView()
        Me.row_wh_id = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.row_item_desc = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.row_rs_qty = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.row_purpose = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.row_rs_no = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.row_charges = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.row_dr_option = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.row_type_of_aggregates = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.row_qty_withdrawn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.row_rs_balance = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.row_dr_delivered = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.row_rs_date = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.row_type_of_purchasing = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.row_inout = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.row_rs_id = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.row_ws_balance = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.panel_loading = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.panel_for_loading = New System.Windows.Forms.Panel()
        Me.lblLoadingInfo = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.panel_listview.SuspendLayout()
        Me.panel_for_listview.SuspendLayout()
        Me.panel_loading.SuspendLayout()
        Me.panel_for_loading.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SelectAllToolStripMenuItem, Me.DeselectAllToolStripMenuItem, Me.CalculateToolStripMenuItem, Me.GenerateAllProjectToolStripMenuItem, Me.RemoveToolStripMenuItem, Me.SetAggregatesNameToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(189, 136)
        '
        'SelectAllToolStripMenuItem
        '
        Me.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem"
        Me.SelectAllToolStripMenuItem.Size = New System.Drawing.Size(188, 22)
        Me.SelectAllToolStripMenuItem.Text = "Select All"
        '
        'DeselectAllToolStripMenuItem
        '
        Me.DeselectAllToolStripMenuItem.Name = "DeselectAllToolStripMenuItem"
        Me.DeselectAllToolStripMenuItem.Size = New System.Drawing.Size(188, 22)
        Me.DeselectAllToolStripMenuItem.Text = "Deselect All"
        '
        'CalculateToolStripMenuItem
        '
        Me.CalculateToolStripMenuItem.Name = "CalculateToolStripMenuItem"
        Me.CalculateToolStripMenuItem.Size = New System.Drawing.Size(188, 22)
        Me.CalculateToolStripMenuItem.Text = "Calculate"
        '
        'GenerateAllProjectToolStripMenuItem
        '
        Me.GenerateAllProjectToolStripMenuItem.Name = "GenerateAllProjectToolStripMenuItem"
        Me.GenerateAllProjectToolStripMenuItem.Size = New System.Drawing.Size(188, 22)
        Me.GenerateAllProjectToolStripMenuItem.Text = "Generate All Project"
        '
        'RemoveToolStripMenuItem
        '
        Me.RemoveToolStripMenuItem.Name = "RemoveToolStripMenuItem"
        Me.RemoveToolStripMenuItem.Size = New System.Drawing.Size(188, 22)
        Me.RemoveToolStripMenuItem.Text = "Remove"
        '
        'SetAggregatesNameToolStripMenuItem
        '
        Me.SetAggregatesNameToolStripMenuItem.Name = "SetAggregatesNameToolStripMenuItem"
        Me.SetAggregatesNameToolStripMenuItem.Size = New System.Drawing.Size(188, 22)
        Me.SetAggregatesNameToolStripMenuItem.Text = "Set Aggregates Name"
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(1155, 10)
        Me.btnSearch.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(119, 28)
        Me.btnSearch.TabIndex = 1
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtCharges
        '
        Me.txtCharges.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCharges.ForeColor = System.Drawing.Color.Gray
        Me.txtCharges.Location = New System.Drawing.Point(1242, 16)
        Me.txtCharges.Name = "txtCharges"
        Me.txtCharges.Size = New System.Drawing.Size(140, 25)
        Me.txtCharges.TabIndex = 400
        Me.txtCharges.Visible = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackgroundImage = Global.SUPPLY.My.Resources.Resources.bg_line
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.panel_listview, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1500, 732)
        Me.TableLayoutPanel1.TabIndex = 402
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = Global.SUPPLY.My.Resources.Resources.bg_line
        Me.Panel1.Controls.Add(Me.FlowLayoutPanel1)
        Me.Panel1.Controls.Add(Me.txtCharges)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 670)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1494, 59)
        Me.Panel1.TabIndex = 1
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.BackgroundImage = Global.SUPPLY.My.Resources.Resources.bg_line
        Me.FlowLayoutPanel1.Controls.Add(Me.cmbSearchby)
        Me.FlowLayoutPanel1.Controls.Add(Me.cmbProject)
        Me.FlowLayoutPanel1.Controls.Add(Me.cmbAggregates)
        Me.FlowLayoutPanel1.Controls.Add(Me.dtpfrom)
        Me.FlowLayoutPanel1.Controls.Add(Me.dtpto)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnSearch)
        Me.FlowLayoutPanel1.Controls.Add(Me.Button1)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(7, 7)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(1478, 47)
        Me.FlowLayoutPanel1.TabIndex = 405
        '
        'cmbSearchby
        '
        Me.cmbSearchby.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSearchby.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSearchby.FormattingEnabled = True
        Me.cmbSearchby.Items.AddRange(New Object() {"Search by Specific Aggregates", "Search by Project Only"})
        Me.cmbSearchby.Location = New System.Drawing.Point(3, 10)
        Me.cmbSearchby.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.cmbSearchby.Name = "cmbSearchby"
        Me.cmbSearchby.Size = New System.Drawing.Size(230, 28)
        Me.cmbSearchby.TabIndex = 410
        '
        'cmbProject
        '
        Me.cmbProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProject.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbProject.FormattingEnabled = True
        Me.cmbProject.Location = New System.Drawing.Point(239, 10)
        Me.cmbProject.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.cmbProject.Name = "cmbProject"
        Me.cmbProject.Size = New System.Drawing.Size(265, 28)
        Me.cmbProject.TabIndex = 403
        '
        'cmbAggregates
        '
        Me.cmbAggregates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAggregates.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAggregates.FormattingEnabled = True
        Me.cmbAggregates.Location = New System.Drawing.Point(510, 10)
        Me.cmbAggregates.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.cmbAggregates.Name = "cmbAggregates"
        Me.cmbAggregates.Size = New System.Drawing.Size(227, 28)
        Me.cmbAggregates.TabIndex = 409
        '
        'dtpfrom
        '
        Me.dtpfrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpfrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfrom.Location = New System.Drawing.Point(743, 10)
        Me.dtpfrom.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.dtpfrom.Name = "dtpfrom"
        Me.dtpfrom.Size = New System.Drawing.Size(200, 26)
        Me.dtpfrom.TabIndex = 407
        '
        'dtpto
        '
        Me.dtpto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpto.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpto.Location = New System.Drawing.Point(949, 10)
        Me.dtpto.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.dtpto.Name = "dtpto"
        Me.dtpto.Size = New System.Drawing.Size(200, 26)
        Me.dtpto.TabIndex = 408
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(1280, 10)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(119, 28)
        Me.Button1.TabIndex = 402
        Me.Button1.Text = "Calculate"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'panel_listview
        '
        Me.panel_listview.Controls.Add(Me.panel_for_listview)
        Me.panel_listview.Controls.Add(Me.panel_loading)
        Me.panel_listview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panel_listview.Location = New System.Drawing.Point(3, 3)
        Me.panel_listview.Name = "panel_listview"
        Me.panel_listview.Size = New System.Drawing.Size(1494, 661)
        Me.panel_listview.TabIndex = 2
        '
        'panel_for_listview
        '
        Me.panel_for_listview.Controls.Add(Me.lvlAllRs)
        Me.panel_for_listview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panel_for_listview.Location = New System.Drawing.Point(0, 49)
        Me.panel_for_listview.Name = "panel_for_listview"
        Me.panel_for_listview.Size = New System.Drawing.Size(1494, 612)
        Me.panel_for_listview.TabIndex = 3
        '
        'lvlAllRs
        '
        Me.lvlAllRs.CheckBoxes = True
        Me.lvlAllRs.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.row_wh_id, Me.row_item_desc, Me.row_rs_qty, Me.row_purpose, Me.row_rs_no, Me.row_charges, Me.row_dr_option, Me.row_type_of_aggregates, Me.row_qty_withdrawn, Me.row_rs_balance, Me.row_dr_delivered, Me.row_rs_date, Me.row_type_of_purchasing, Me.row_inout, Me.row_rs_id, Me.row_ws_balance})
        Me.lvlAllRs.ContextMenuStrip = Me.ContextMenuStrip1
        Me.lvlAllRs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvlAllRs.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvlAllRs.FullRowSelect = True
        Me.lvlAllRs.GridLines = True
        Me.lvlAllRs.HideSelection = False
        Me.lvlAllRs.Location = New System.Drawing.Point(0, 0)
        Me.lvlAllRs.Name = "lvlAllRs"
        Me.lvlAllRs.Size = New System.Drawing.Size(1494, 612)
        Me.lvlAllRs.TabIndex = 1
        Me.lvlAllRs.UseCompatibleStateImageBehavior = False
        Me.lvlAllRs.View = System.Windows.Forms.View.Details
        '
        'row_wh_id
        '
        Me.row_wh_id.Text = "wh_id"
        Me.row_wh_id.Width = 78
        '
        'row_item_desc
        '
        Me.row_item_desc.Text = "ITEM DESCRIPTION"
        Me.row_item_desc.Width = 350
        '
        'row_rs_qty
        '
        Me.row_rs_qty.Text = "RS QTY"
        '
        'row_purpose
        '
        Me.row_purpose.Text = "PURPOSE"
        Me.row_purpose.Width = 350
        '
        'row_rs_no
        '
        Me.row_rs_no.Text = "RS NO"
        Me.row_rs_no.Width = 150
        '
        'row_charges
        '
        Me.row_charges.Text = "CHARGES"
        Me.row_charges.Width = 250
        '
        'row_dr_option
        '
        Me.row_dr_option.Text = "DR OPTION"
        Me.row_dr_option.Width = 200
        '
        'row_type_of_aggregates
        '
        Me.row_type_of_aggregates.Text = "TYPE OF AGGREGATES"
        Me.row_type_of_aggregates.Width = 200
        '
        'row_qty_withdrawn
        '
        Me.row_qty_withdrawn.Text = "QTY WITHDRAWN"
        Me.row_qty_withdrawn.Width = 100
        '
        'row_rs_balance
        '
        Me.row_rs_balance.Text = "RS BALANCE"
        Me.row_rs_balance.Width = 100
        '
        'row_dr_delivered
        '
        Me.row_dr_delivered.Text = "DR DELIVERED"
        Me.row_dr_delivered.Width = 100
        '
        'row_rs_date
        '
        Me.row_rs_date.Text = "RS DATE"
        Me.row_rs_date.Width = 200
        '
        'row_type_of_purchasing
        '
        Me.row_type_of_purchasing.Text = "TYPE OF PURCHASING"
        '
        'row_inout
        '
        Me.row_inout.Text = "IN/OUT"
        '
        'row_rs_id
        '
        Me.row_rs_id.Text = "rs_id"
        '
        'row_ws_balance
        '
        Me.row_ws_balance.Text = "WITHDRAWAL BALANCE"
        Me.row_ws_balance.Width = 100
        '
        'panel_loading
        '
        Me.panel_loading.BackgroundImage = Global.SUPPLY.My.Resources.Resources.eus_bg_03
        Me.panel_loading.Controls.Add(Me.Label1)
        Me.panel_loading.Controls.Add(Me.panel_for_loading)
        Me.panel_loading.Dock = System.Windows.Forms.DockStyle.Top
        Me.panel_loading.Location = New System.Drawing.Point(0, 0)
        Me.panel_loading.Name = "panel_loading"
        Me.panel_loading.Size = New System.Drawing.Size(1494, 49)
        Me.panel_loading.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.YellowGreen
        Me.Label1.Location = New System.Drawing.Point(1056, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(416, 23)
        Me.Label1.TabIndex = 421
        Me.Label1.Text = "BALANCE MONITORING FOR AGGREGATES"
        '
        'panel_for_loading
        '
        Me.panel_for_loading.BackColor = System.Drawing.Color.Transparent
        Me.panel_for_loading.Controls.Add(Me.lblLoadingInfo)
        Me.panel_for_loading.Controls.Add(Me.PictureBox2)
        Me.panel_for_loading.Location = New System.Drawing.Point(19, -3)
        Me.panel_for_loading.Name = "panel_for_loading"
        Me.panel_for_loading.Size = New System.Drawing.Size(722, 52)
        Me.panel_for_loading.TabIndex = 420
        Me.panel_for_loading.Visible = False
        '
        'lblLoadingInfo
        '
        Me.lblLoadingInfo.AutoSize = True
        Me.lblLoadingInfo.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoadingInfo.ForeColor = System.Drawing.Color.Yellow
        Me.lblLoadingInfo.Location = New System.Drawing.Point(65, 16)
        Me.lblLoadingInfo.Name = "lblLoadingInfo"
        Me.lblLoadingInfo.Size = New System.Drawing.Size(277, 23)
        Me.lblLoadingInfo.TabIndex = 420
        Me.lblLoadingInfo.Text = "Initializing data for a moment..."
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(3, 3)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(56, 48)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 419
        Me.PictureBox2.TabStop = False
        '
        'FAggregates_General_Request
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SUPPLY.My.Resources.Resources.bg_line
        Me.ClientSize = New System.Drawing.Size(1500, 732)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FAggregates_General_Request"
        Me.Text = "FAggregates_General_Request"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.panel_listview.ResumeLayout(False)
        Me.panel_for_listview.ResumeLayout(False)
        Me.panel_loading.ResumeLayout(False)
        Me.panel_loading.PerformLayout()
        Me.panel_for_loading.ResumeLayout(False)
        Me.panel_for_loading.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnSearch As Button
    Friend WithEvents txtCharges As TextBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents cmbProject As ComboBox
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents SelectAllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeselectAllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CalculateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents dtpfrom As DateTimePicker
    Friend WithEvents dtpto As DateTimePicker
    Friend WithEvents cmbAggregates As ComboBox
    Friend WithEvents cmbSearchby As ComboBox
    Friend WithEvents GenerateAllProjectToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents panel_listview As Panel
    Friend WithEvents panel_for_listview As Panel
    Friend WithEvents lvlAllRs As ListView
    Friend WithEvents row_wh_id As ColumnHeader
    Friend WithEvents row_item_desc As ColumnHeader
    Friend WithEvents row_rs_qty As ColumnHeader
    Friend WithEvents row_purpose As ColumnHeader
    Friend WithEvents row_rs_no As ColumnHeader
    Friend WithEvents row_charges As ColumnHeader
    Friend WithEvents row_dr_option As ColumnHeader
    Friend WithEvents row_type_of_aggregates As ColumnHeader
    Friend WithEvents row_qty_withdrawn As ColumnHeader
    Friend WithEvents row_rs_balance As ColumnHeader
    Friend WithEvents row_dr_delivered As ColumnHeader
    Friend WithEvents row_rs_date As ColumnHeader
    Friend WithEvents row_type_of_purchasing As ColumnHeader
    Friend WithEvents row_inout As ColumnHeader
    Friend WithEvents panel_loading As Panel
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents row_rs_id As ColumnHeader
    Friend WithEvents panel_for_loading As Panel
    Friend WithEvents lblLoadingInfo As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents RemoveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents row_ws_balance As ColumnHeader
    Friend WithEvents SetAggregatesNameToolStripMenuItem As ToolStripMenuItem
End Class
