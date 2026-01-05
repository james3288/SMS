<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FWithdrawalList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FWithdrawalList))
        Me.btnExit = New System.Windows.Forms.Button()
        Me.cms_FWithdrawalList = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditInfoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditWithdrawnItemsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditReleaseItemsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WithdrawnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CancelWithdrawToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CalculateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportToExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewStockcardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.pboxHeader = New System.Windows.Forms.PictureBox()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnWithdrawalReport = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.cmbSearchByCategory = New System.Windows.Forms.ComboBox()
        Me.lblSearchByCategory = New System.Windows.Forms.Label()
        Me.ListJobOrderNo = New System.Windows.Forms.ListBox()
        Me.dtpSearchDateWthdrawn = New System.Windows.Forms.DateTimePicker()
        Me.btn_view = New System.Windows.Forms.Button()
        Me.btn_paneLExt = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DTP_dateTO = New System.Windows.Forms.DateTimePicker()
        Me.DTP_dateFROM = New System.Windows.Forms.DateTimePicker()
        Me.panel_fdate = New System.Windows.Forms.Panel()
        Me.txtSearchWithDateRange = New System.Windows.Forms.TextBox()
        Me.Timer_panelMvment = New System.Windows.Forms.Timer(Me.components)
        Me.lvlwithdrawalList = New System.Windows.Forms.ListView()
        Me.col_ws_id = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_ws_no = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_rs_no = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_date_withdrawn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_item_name = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_qty = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_unit = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_unit_price = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_amount = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_item_desc = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_withdrawn_from = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_withdrwan_received_by = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_released_by = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_status = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_charge_to = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_ws_info_id = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_rs_id = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ws_po_no = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_wh_id = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_remarks = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_dr_option = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_purpose = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_withdrawn_id = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_partially_withdrawn_id = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_issued_by = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_user = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_division = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_serial_id = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_tire_category = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtItemSearch = New System.Windows.Forms.TextBox()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblRecords = New System.Windows.Forms.Label()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.BW_Search = New System.ComponentModel.BackgroundWorker()
        Me.loadingPanel = New System.Windows.Forms.Panel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.cms_FWithdrawalList.SuspendLayout()
        CType(Me.pboxHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel_fdate.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.loadingPanel.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.BackColor = System.Drawing.Color.Transparent
        Me.btnExit.BackgroundImage = Global.SUPPLY.My.Resources.Resources.close_button
        Me.btnExit.FlatAppearance.BorderSize = 0
        Me.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit.Location = New System.Drawing.Point(1287, 10)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(20, 20)
        Me.btnExit.TabIndex = 358
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'cms_FWithdrawalList
        '
        Me.cms_FWithdrawalList.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.WithdrawnToolStripMenuItem, Me.CancelWithdrawToolStripMenuItem, Me.CalculateToolStripMenuItem, Me.ExportToExcelToolStripMenuItem, Me.ViewStockcardToolStripMenuItem})
        Me.cms_FWithdrawalList.Name = "cms_FWithdrawalList"
        Me.cms_FWithdrawalList.Size = New System.Drawing.Size(236, 158)
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditInfoToolStripMenuItem, Me.EditDetailsToolStripMenuItem, Me.EditWithdrawnItemsToolStripMenuItem, Me.EditReleaseItemsToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(235, 22)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'EditInfoToolStripMenuItem
        '
        Me.EditInfoToolStripMenuItem.Name = "EditInfoToolStripMenuItem"
        Me.EditInfoToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.EditInfoToolStripMenuItem.Text = "Edit All"
        '
        'EditDetailsToolStripMenuItem
        '
        Me.EditDetailsToolStripMenuItem.Enabled = False
        Me.EditDetailsToolStripMenuItem.Name = "EditDetailsToolStripMenuItem"
        Me.EditDetailsToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.EditDetailsToolStripMenuItem.Text = "Edit Details"
        '
        'EditWithdrawnItemsToolStripMenuItem
        '
        Me.EditWithdrawnItemsToolStripMenuItem.Name = "EditWithdrawnItemsToolStripMenuItem"
        Me.EditWithdrawnItemsToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.EditWithdrawnItemsToolStripMenuItem.Text = "Edit Withdrawn Items"
        '
        'EditReleaseItemsToolStripMenuItem
        '
        Me.EditReleaseItemsToolStripMenuItem.Name = "EditReleaseItemsToolStripMenuItem"
        Me.EditReleaseItemsToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.EditReleaseItemsToolStripMenuItem.Text = "Edit Release Items Info"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(235, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'WithdrawnToolStripMenuItem
        '
        Me.WithdrawnToolStripMenuItem.Name = "WithdrawnToolStripMenuItem"
        Me.WithdrawnToolStripMenuItem.Size = New System.Drawing.Size(235, 22)
        Me.WithdrawnToolStripMenuItem.Text = "Withdraw"
        '
        'CancelWithdrawToolStripMenuItem
        '
        Me.CancelWithdrawToolStripMenuItem.Name = "CancelWithdrawToolStripMenuItem"
        Me.CancelWithdrawToolStripMenuItem.Size = New System.Drawing.Size(235, 22)
        Me.CancelWithdrawToolStripMenuItem.Text = "Cancel Withdraw"
        '
        'CalculateToolStripMenuItem
        '
        Me.CalculateToolStripMenuItem.Name = "CalculateToolStripMenuItem"
        Me.CalculateToolStripMenuItem.Size = New System.Drawing.Size(235, 22)
        Me.CalculateToolStripMenuItem.Text = "calculate"
        '
        'ExportToExcelToolStripMenuItem
        '
        Me.ExportToExcelToolStripMenuItem.Name = "ExportToExcelToolStripMenuItem"
        Me.ExportToExcelToolStripMenuItem.Size = New System.Drawing.Size(235, 22)
        Me.ExportToExcelToolStripMenuItem.Text = "Export to Excel"
        '
        'ViewStockcardToolStripMenuItem
        '
        Me.ViewStockcardToolStripMenuItem.Name = "ViewStockcardToolStripMenuItem"
        Me.ViewStockcardToolStripMenuItem.Size = New System.Drawing.Size(235, 22)
        Me.ViewStockcardToolStripMenuItem.Text = "View Stockcard (Warehousing)"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(17, 10)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(128, 22)
        Me.Label15.TabIndex = 355
        Me.Label15.Text = "Withdrawal List"
        '
        'pboxHeader
        '
        Me.pboxHeader.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.pboxHeader.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pboxHeader.BackgroundImage = Global.SUPPLY.My.Resources.Resources.bg_line
        Me.pboxHeader.InitialImage = Nothing
        Me.pboxHeader.Location = New System.Drawing.Point(1, 1)
        Me.pboxHeader.Name = "pboxHeader"
        Me.pboxHeader.Size = New System.Drawing.Size(1334, 41)
        Me.pboxHeader.TabIndex = 356
        Me.pboxHeader.TabStop = False
        '
        'dtpFrom
        '
        Me.dtpFrom.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFrom.Location = New System.Drawing.Point(843, 687)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(144, 29)
        Me.dtpFrom.TabIndex = 5
        Me.dtpFrom.Visible = False
        '
        'dtpTo
        '
        Me.dtpTo.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTo.Location = New System.Drawing.Point(992, 687)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(144, 29)
        Me.dtpTo.TabIndex = 4
        Me.dtpTo.Visible = False
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.YellowGreen
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.Color.Black
        Me.btnSearch.Location = New System.Drawing.Point(561, 4)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(113, 30)
        Me.btnSearch.TabIndex = 6
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'btnWithdrawalReport
        '
        Me.btnWithdrawalReport.BackColor = System.Drawing.Color.YellowGreen
        Me.btnWithdrawalReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnWithdrawalReport.ForeColor = System.Drawing.Color.Black
        Me.btnWithdrawalReport.Location = New System.Drawing.Point(691, 4)
        Me.btnWithdrawalReport.Name = "btnWithdrawalReport"
        Me.btnWithdrawalReport.Size = New System.Drawing.Size(115, 30)
        Me.btnWithdrawalReport.TabIndex = 363
        Me.btnWithdrawalReport.Text = "Generate Report"
        Me.btnWithdrawalReport.UseVisualStyleBackColor = False
        '
        'txtSearch
        '
        Me.txtSearch.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.ForeColor = System.Drawing.Color.DimGray
        Me.txtSearch.Location = New System.Drawing.Point(373, 8)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(166, 29)
        Me.txtSearch.TabIndex = 2
        '
        'cmbSearchByCategory
        '
        Me.cmbSearchByCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSearchByCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbSearchByCategory.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSearchByCategory.FormattingEnabled = True
        Me.cmbSearchByCategory.Location = New System.Drawing.Point(119, 6)
        Me.cmbSearchByCategory.Name = "cmbSearchByCategory"
        Me.cmbSearchByCategory.Size = New System.Drawing.Size(205, 26)
        Me.cmbSearchByCategory.TabIndex = 1
        '
        'lblSearchByCategory
        '
        Me.lblSearchByCategory.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblSearchByCategory.AutoSize = True
        Me.lblSearchByCategory.ForeColor = System.Drawing.Color.White
        Me.lblSearchByCategory.Location = New System.Drawing.Point(9, 14)
        Me.lblSearchByCategory.Name = "lblSearchByCategory"
        Me.lblSearchByCategory.Size = New System.Drawing.Size(59, 13)
        Me.lblSearchByCategory.TabIndex = 0
        Me.lblSearchByCategory.Text = "Search By:"
        '
        'ListJobOrderNo
        '
        Me.ListJobOrderNo.FormattingEnabled = True
        Me.ListJobOrderNo.Location = New System.Drawing.Point(1376, 121)
        Me.ListJobOrderNo.Name = "ListJobOrderNo"
        Me.ListJobOrderNo.Size = New System.Drawing.Size(163, 56)
        Me.ListJobOrderNo.TabIndex = 360
        '
        'dtpSearchDateWthdrawn
        '
        Me.dtpSearchDateWthdrawn.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpSearchDateWthdrawn.Location = New System.Drawing.Point(814, 791)
        Me.dtpSearchDateWthdrawn.Name = "dtpSearchDateWthdrawn"
        Me.dtpSearchDateWthdrawn.Size = New System.Drawing.Size(239, 22)
        Me.dtpSearchDateWthdrawn.TabIndex = 361
        Me.dtpSearchDateWthdrawn.Visible = False
        '
        'btn_view
        '
        Me.btn_view.BackColor = System.Drawing.Color.YellowGreen
        Me.btn_view.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_view.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_view.Image = CType(resources.GetObject("btn_view.Image"), System.Drawing.Image)
        Me.btn_view.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_view.Location = New System.Drawing.Point(47, 226)
        Me.btn_view.Name = "btn_view"
        Me.btn_view.Size = New System.Drawing.Size(250, 41)
        Me.btn_view.TabIndex = 362
        Me.btn_view.Text = "View"
        Me.btn_view.UseVisualStyleBackColor = False
        '
        'btn_paneLExt
        '
        Me.btn_paneLExt.BackColor = System.Drawing.Color.Transparent
        Me.btn_paneLExt.BackgroundImage = Global.SUPPLY.My.Resources.Resources.close_button
        Me.btn_paneLExt.FlatAppearance.BorderSize = 0
        Me.btn_paneLExt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btn_paneLExt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btn_paneLExt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_paneLExt.Location = New System.Drawing.Point(277, 14)
        Me.btn_paneLExt.Name = "btn_paneLExt"
        Me.btn_paneLExt.Size = New System.Drawing.Size(20, 20)
        Me.btn_paneLExt.TabIndex = 362
        Me.btn_paneLExt.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(14, 95)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 16)
        Me.Label1.TabIndex = 363
        Me.Label1.Text = "TO"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(14, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 16)
        Me.Label2.TabIndex = 362
        Me.Label2.Text = "FROM"
        '
        'DTP_dateTO
        '
        Me.DTP_dateTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_dateTO.Location = New System.Drawing.Point(47, 120)
        Me.DTP_dateTO.Name = "DTP_dateTO"
        Me.DTP_dateTO.Size = New System.Drawing.Size(247, 22)
        Me.DTP_dateTO.TabIndex = 1
        '
        'DTP_dateFROM
        '
        Me.DTP_dateFROM.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_dateFROM.Location = New System.Drawing.Point(47, 56)
        Me.DTP_dateFROM.Name = "DTP_dateFROM"
        Me.DTP_dateFROM.Size = New System.Drawing.Size(247, 22)
        Me.DTP_dateFROM.TabIndex = 0
        '
        'panel_fdate
        '
        Me.panel_fdate.BackColor = System.Drawing.Color.Transparent
        Me.panel_fdate.Controls.Add(Me.txtSearchWithDateRange)
        Me.panel_fdate.Controls.Add(Me.btn_view)
        Me.panel_fdate.Controls.Add(Me.btn_paneLExt)
        Me.panel_fdate.Controls.Add(Me.Label1)
        Me.panel_fdate.Controls.Add(Me.Label2)
        Me.panel_fdate.Controls.Add(Me.DTP_dateTO)
        Me.panel_fdate.Controls.Add(Me.DTP_dateFROM)
        Me.panel_fdate.Location = New System.Drawing.Point(449, 263)
        Me.panel_fdate.Name = "panel_fdate"
        Me.panel_fdate.Size = New System.Drawing.Size(316, 298)
        Me.panel_fdate.TabIndex = 362
        '
        'txtSearchWithDateRange
        '
        Me.txtSearchWithDateRange.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearchWithDateRange.Location = New System.Drawing.Point(47, 172)
        Me.txtSearchWithDateRange.Name = "txtSearchWithDateRange"
        Me.txtSearchWithDateRange.Size = New System.Drawing.Size(250, 26)
        Me.txtSearchWithDateRange.TabIndex = 364
        '
        'Timer_panelMvment
        '
        '
        'lvlwithdrawalList
        '
        Me.lvlwithdrawalList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.col_ws_id, Me.col_ws_no, Me.col_rs_no, Me.col_date_withdrawn, Me.col_item_name, Me.col_qty, Me.col_unit, Me.col_unit_price, Me.col_amount, Me.col_item_desc, Me.col_withdrawn_from, Me.col_withdrwan_received_by, Me.col_released_by, Me.col_status, Me.col_charge_to, Me.col_ws_info_id, Me.col_rs_id, Me.ws_po_no, Me.col_wh_id, Me.col_remarks, Me.col_dr_option, Me.col_purpose, Me.col_withdrawn_id, Me.col_partially_withdrawn_id, Me.col_issued_by, Me.col_user, Me.col_division, Me.col_serial_id, Me.col_tire_category})
        Me.lvlwithdrawalList.ContextMenuStrip = Me.cms_FWithdrawalList
        Me.lvlwithdrawalList.Font = New System.Drawing.Font("Bombardier", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvlwithdrawalList.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lvlwithdrawalList.FullRowSelect = True
        Me.lvlwithdrawalList.GridLines = True
        Me.lvlwithdrawalList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvlwithdrawalList.HideSelection = False
        Me.lvlwithdrawalList.Location = New System.Drawing.Point(13, 57)
        Me.lvlwithdrawalList.Name = "lvlwithdrawalList"
        Me.lvlwithdrawalList.Size = New System.Drawing.Size(1307, 618)
        Me.lvlwithdrawalList.TabIndex = 363
        Me.lvlwithdrawalList.UseCompatibleStateImageBehavior = False
        Me.lvlwithdrawalList.View = System.Windows.Forms.View.Details
        '
        'col_ws_id
        '
        Me.col_ws_id.Text = "ID"
        Me.col_ws_id.Width = 0
        '
        'col_ws_no
        '
        Me.col_ws_no.Text = "WS No."
        Me.col_ws_no.Width = 120
        '
        'col_rs_no
        '
        Me.col_rs_no.Text = "RS No."
        Me.col_rs_no.Width = 120
        '
        'col_date_withdrawn
        '
        Me.col_date_withdrawn.Text = "Date Withdrawn/Date Issued"
        Me.col_date_withdrawn.Width = 180
        '
        'col_item_name
        '
        Me.col_item_name.Text = "Item Name"
        Me.col_item_name.Width = 200
        '
        'col_qty
        '
        Me.col_qty.DisplayIndex = 6
        Me.col_qty.Text = "Quantity"
        Me.col_qty.Width = 70
        '
        'col_unit
        '
        Me.col_unit.DisplayIndex = 7
        Me.col_unit.Text = "Unit"
        Me.col_unit.Width = 80
        '
        'col_unit_price
        '
        Me.col_unit_price.DisplayIndex = 8
        Me.col_unit_price.Text = "Unit Price"
        Me.col_unit_price.Width = 100
        '
        'col_amount
        '
        Me.col_amount.DisplayIndex = 9
        Me.col_amount.Text = "Amount"
        Me.col_amount.Width = 120
        '
        'col_item_desc
        '
        Me.col_item_desc.DisplayIndex = 5
        Me.col_item_desc.Text = "Item Description"
        Me.col_item_desc.Width = 296
        '
        'col_withdrawn_from
        '
        Me.col_withdrawn_from.Text = "Withdrawn From"
        Me.col_withdrawn_from.Width = 210
        '
        'col_withdrwan_received_by
        '
        Me.col_withdrwan_received_by.DisplayIndex = 12
        Me.col_withdrwan_received_by.Text = "Withdrawn/Received By"
        Me.col_withdrwan_received_by.Width = 210
        '
        'col_released_by
        '
        Me.col_released_by.DisplayIndex = 13
        Me.col_released_by.Text = "Released By"
        Me.col_released_by.Width = 210
        '
        'col_status
        '
        Me.col_status.DisplayIndex = 14
        Me.col_status.Text = "Status"
        Me.col_status.Width = 200
        '
        'col_charge_to
        '
        Me.col_charge_to.DisplayIndex = 15
        Me.col_charge_to.Text = "Charge To"
        Me.col_charge_to.Width = 150
        '
        'col_ws_info_id
        '
        Me.col_ws_info_id.DisplayIndex = 16
        Me.col_ws_info_id.Text = "ws_info_id"
        Me.col_ws_info_id.Width = 0
        '
        'col_rs_id
        '
        Me.col_rs_id.DisplayIndex = 17
        Me.col_rs_id.Text = "rs_id"
        Me.col_rs_id.Width = 50
        '
        'ws_po_no
        '
        Me.ws_po_no.DisplayIndex = 18
        Me.ws_po_no.Text = "po no"
        Me.ws_po_no.Width = 0
        '
        'col_wh_id
        '
        Me.col_wh_id.DisplayIndex = 19
        Me.col_wh_id.Text = "wh_id"
        '
        'col_remarks
        '
        Me.col_remarks.DisplayIndex = 20
        Me.col_remarks.Text = "Remarks"
        Me.col_remarks.Width = 350
        '
        'col_dr_option
        '
        Me.col_dr_option.DisplayIndex = 21
        Me.col_dr_option.Text = "DR OPTION"
        Me.col_dr_option.Width = 150
        '
        'col_purpose
        '
        Me.col_purpose.DisplayIndex = 22
        Me.col_purpose.Text = "Purpose"
        '
        'col_withdrawn_id
        '
        Me.col_withdrawn_id.DisplayIndex = 23
        Me.col_withdrawn_id.Text = "withdrawn_id"
        '
        'col_partially_withdrawn_id
        '
        Me.col_partially_withdrawn_id.DisplayIndex = 24
        Me.col_partially_withdrawn_id.Text = "partially_withdrawn_id"
        '
        'col_issued_by
        '
        Me.col_issued_by.DisplayIndex = 11
        Me.col_issued_by.Text = "Issued By"
        Me.col_issued_by.Width = 150
        '
        'col_user
        '
        Me.col_user.Text = "Users"
        Me.col_user.Width = 150
        '
        'col_division
        '
        Me.col_division.Text = "Division"
        Me.col_division.Width = 150
        '
        'col_serial_id
        '
        Me.col_serial_id.Text = "serial_id"
        '
        'col_tire_category
        '
        Me.col_tire_category.Text = "Tire Category"
        Me.col_tire_category.Width = 200
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.FlowLayoutPanel1.Controls.Add(Me.Panel1)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(13, 681)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(824, 51)
        Me.FlowLayoutPanel1.TabIndex = 364
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtSearch)
        Me.Panel1.Controls.Add(Me.cmbSearchByCategory)
        Me.Panel1.Controls.Add(Me.lblSearchByCategory)
        Me.Panel1.Controls.Add(Me.btnWithdrawalReport)
        Me.Panel1.Controls.Add(Me.btnSearch)
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(821, 47)
        Me.Panel1.TabIndex = 419
        '
        'txtItemSearch
        '
        Me.txtItemSearch.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemSearch.ForeColor = System.Drawing.Color.DimGray
        Me.txtItemSearch.Location = New System.Drawing.Point(1141, 686)
        Me.txtItemSearch.Name = "txtItemSearch"
        Me.txtItemSearch.Size = New System.Drawing.Size(166, 29)
        Me.txtItemSearch.TabIndex = 3
        Me.txtItemSearch.Text = "Items..."
        Me.txtItemSearch.Visible = False
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(1154, 137)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(120, 238)
        Me.ListBox1.TabIndex = 412
        '
        'Panel3
        '
        Me.Panel3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Panel3.BackgroundImage = CType(resources.GetObject("Panel3.BackgroundImage"), System.Drawing.Image)
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.lblRecords)
        Me.Panel3.Controls.Add(Me.Button6)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.PictureBox2)
        Me.Panel3.Controls.Add(Me.ProgressBar1)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Location = New System.Drawing.Point(41, 104)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(677, 271)
        Me.Panel3.TabIndex = 418
        Me.Panel3.Visible = False
        '
        'lblRecords
        '
        Me.lblRecords.BackColor = System.Drawing.Color.Transparent
        Me.lblRecords.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecords.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblRecords.Location = New System.Drawing.Point(252, 5)
        Me.lblRecords.Name = "lblRecords"
        Me.lblRecords.Size = New System.Drawing.Size(410, 26)
        Me.lblRecords.TabIndex = 424
        Me.lblRecords.Text = "0"
        Me.lblRecords.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.OliveDrab
        Me.Button6.ForeColor = System.Drawing.Color.Transparent
        Me.Button6.Location = New System.Drawing.Point(597, 242)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(75, 23)
        Me.Button6.TabIndex = 421
        Me.Button6.Text = "Abort"
        Me.Button6.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(249, 68)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(330, 136)
        Me.Label8.TabIndex = 419
        Me.Label8.Text = """ Patience is not the ability to wait, but the ability to keep a good attitude wh" &
    "ile waiting."" " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "- Programmer KJ"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(0, 1)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(228, 202)
        Me.PictureBox2.TabIndex = 418
        Me.PictureBox2.TabStop = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(3, 243)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(591, 22)
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar1.TabIndex = 417
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(-1, 210)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(673, 30)
        Me.Label7.TabIndex = 415
        Me.Label7.Text = "Waiting..."
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'BW_Search
        '
        '
        'loadingPanel
        '
        Me.loadingPanel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.loadingPanel.BackColor = System.Drawing.Color.Transparent
        Me.loadingPanel.Controls.Add(Me.Label12)
        Me.loadingPanel.Controls.Add(Me.PictureBox1)
        Me.loadingPanel.Location = New System.Drawing.Point(211, 0)
        Me.loadingPanel.Name = "loadingPanel"
        Me.loadingPanel.Size = New System.Drawing.Size(1043, 38)
        Me.loadingPanel.TabIndex = 422
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
        'FWithdrawalList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SUPPLY.My.Resources.Resources.bg_line
        Me.ClientSize = New System.Drawing.Size(1332, 744)
        Me.Controls.Add(Me.loadingPanel)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.txtItemSearch)
        Me.Controls.Add(Me.dtpTo)
        Me.Controls.Add(Me.dtpFrom)
        Me.Controls.Add(Me.panel_fdate)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.dtpSearchDateWthdrawn)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.pboxHeader)
        Me.Controls.Add(Me.lvlwithdrawalList)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.ListJobOrderNo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FWithdrawalList"
        Me.Padding = New System.Windows.Forms.Padding(9)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "FWithdrawnList"
        Me.cms_FWithdrawalList.ResumeLayout(False)
        CType(Me.pboxHeader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel_fdate.ResumeLayout(False)
        Me.panel_fdate.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.loadingPanel.ResumeLayout(False)
        Me.loadingPanel.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents pboxHeader As System.Windows.Forms.PictureBox
    Friend WithEvents cms_FWithdrawalList As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblSearchByCategory As System.Windows.Forms.Label
    Friend WithEvents cmbSearchByCategory As System.Windows.Forms.ComboBox
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents ListJobOrderNo As System.Windows.Forms.ListBox
    Friend WithEvents dtpSearchDateWthdrawn As System.Windows.Forms.DateTimePicker
    Friend WithEvents btn_view As System.Windows.Forms.Button
    Friend WithEvents btn_paneLExt As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DTP_dateTO As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTP_dateFROM As System.Windows.Forms.DateTimePicker
    Friend WithEvents panel_fdate As System.Windows.Forms.Panel
    Friend WithEvents Timer_panelMvment As System.Windows.Forms.Timer
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WithdrawnToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CancelWithdrawToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnWithdrawalReport As System.Windows.Forms.Button
    Friend WithEvents lvlwithdrawalList As System.Windows.Forms.ListView
    Friend WithEvents col_ws_id As System.Windows.Forms.ColumnHeader
    Friend WithEvents col_ws_no As System.Windows.Forms.ColumnHeader
    Friend WithEvents col_rs_no As System.Windows.Forms.ColumnHeader
    Friend WithEvents col_date_withdrawn As System.Windows.Forms.ColumnHeader
    Friend WithEvents col_item_name As System.Windows.Forms.ColumnHeader
    Friend WithEvents col_qty As System.Windows.Forms.ColumnHeader
    Friend WithEvents col_unit As System.Windows.Forms.ColumnHeader
    Friend WithEvents col_unit_price As System.Windows.Forms.ColumnHeader
    Friend WithEvents col_amount As System.Windows.Forms.ColumnHeader
    Friend WithEvents col_item_desc As System.Windows.Forms.ColumnHeader
    Friend WithEvents col_withdrawn_from As System.Windows.Forms.ColumnHeader
    Friend WithEvents col_withdrwan_received_by As System.Windows.Forms.ColumnHeader
    Friend WithEvents col_released_by As System.Windows.Forms.ColumnHeader
    Friend WithEvents col_status As System.Windows.Forms.ColumnHeader
    Friend WithEvents col_charge_to As System.Windows.Forms.ColumnHeader
    Friend WithEvents col_ws_info_id As System.Windows.Forms.ColumnHeader
    Friend WithEvents col_rs_id As System.Windows.Forms.ColumnHeader
    Friend WithEvents ws_po_no As System.Windows.Forms.ColumnHeader
    Friend WithEvents CalculateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents dtpFrom As DateTimePicker
    Friend WithEvents dtpTo As DateTimePicker
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents txtItemSearch As TextBox
    Friend WithEvents col_wh_id As ColumnHeader
    Friend WithEvents col_remarks As ColumnHeader
    Friend WithEvents ExportToExcelToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents lblRecords As Label
    Friend WithEvents Button6 As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents Label7 As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents EditInfoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditDetailsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents col_dr_option As ColumnHeader
    Friend WithEvents col_purpose As ColumnHeader
    Friend WithEvents BW_Search As System.ComponentModel.BackgroundWorker
    Friend WithEvents Panel1 As Panel
    Friend WithEvents loadingPanel As Panel
    Friend WithEvents Label12 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents col_withdrawn_id As ColumnHeader
    Friend WithEvents col_partially_withdrawn_id As ColumnHeader
    Friend WithEvents col_issued_by As ColumnHeader
    Friend WithEvents EditWithdrawnItemsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditReleaseItemsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents txtSearchWithDateRange As TextBox
    Friend WithEvents col_user As ColumnHeader
    Friend WithEvents ViewStockcardToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents col_division As ColumnHeader
    Friend WithEvents col_serial_id As ColumnHeader
    Friend WithEvents col_tire_category As ColumnHeader
End Class
