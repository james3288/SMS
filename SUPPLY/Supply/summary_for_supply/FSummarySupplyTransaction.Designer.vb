<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FSummarySupplyTransaction
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle29 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle27 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle28 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FSummarySupplyTransaction))
        Me.cms_FRecvngReportLst = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.gboxSearch = New System.Windows.Forms.GroupBox()
        Me.btnView = New System.Windows.Forms.Button()
        Me.cmbSearch1 = New System.Windows.Forms.ComboBox()
        Me.lblSearchByCategory = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.cmbSearch = New System.Windows.Forms.ComboBox()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.dtgSummarySupply = New System.Windows.Forms.DataGridView()
        Me.No = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_rs_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_rs_date = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_po_date = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_ws_date = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_unit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_item_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_received_qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_requestor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_po_no_and_ws_no = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_rs_no = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_rr_no = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_date_of_rr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_date_needed = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_unit_price = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_amount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_charges = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_lead_time_rs_to_po = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_lead_time_po_to_rr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_supplier = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_remarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_type_of_request = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_invoice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_so_no = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_hauler = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_plate_no = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rs_to_ws = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rs_to_po = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.po_to_rr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rs_to_rr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.terms = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NEEDED_RECEIVED = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DATE_LOG_REQUEST = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DATE_LOG_RECEIVED = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Job_order_no = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Location = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Purpose = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.panel_daterange_req = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSearch1 = New System.Windows.Forms.Button()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.panel_dateRange_Log = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnSearch2 = New System.Windows.Forms.Button()
        Me.dtp_dateTo_Log = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtp_dateFrom_Log = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.pboxHeader = New System.Windows.Forms.PictureBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.panel_chargeTo = New System.Windows.Forms.Panel()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.ComboBox4 = New System.Windows.Forms.ComboBox()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btnSearch3 = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cms_FRecvngReportLst.SuspendLayout()
        Me.gboxSearch.SuspendLayout()
        CType(Me.dtgSummarySupply, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel_daterange_req.SuspendLayout()
        Me.panel_dateRange_Log.SuspendLayout()
        CType(Me.pboxHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.panel_chargeTo.SuspendLayout()
        Me.SuspendLayout()
        '
        'cms_FRecvngReportLst
        '
        Me.cms_FRecvngReportLst.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.ExportToolStripMenuItem})
        Me.cms_FRecvngReportLst.Name = "cms_FRecvngReportLst"
        Me.cms_FRecvngReportLst.Size = New System.Drawing.Size(153, 70)
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'ExportToolStripMenuItem
        '
        Me.ExportToolStripMenuItem.Name = "ExportToolStripMenuItem"
        Me.ExportToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ExportToolStripMenuItem.Text = "Export to Excel"
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.Transparent
        Me.btnExit.BackgroundImage = Global.SUPPLY.My.Resources.Resources.close_button
        Me.btnExit.FlatAppearance.BorderSize = 0
        Me.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit.Location = New System.Drawing.Point(367, 3)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(20, 20)
        Me.btnExit.TabIndex = 354
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'txtSearch
        '
        Me.txtSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(358, 15)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(264, 23)
        Me.txtSearch.TabIndex = 355
        '
        'gboxSearch
        '
        Me.gboxSearch.BackColor = System.Drawing.Color.Transparent
        Me.gboxSearch.Controls.Add(Me.btnView)
        Me.gboxSearch.Controls.Add(Me.cmbSearch1)
        Me.gboxSearch.Controls.Add(Me.lblSearchByCategory)
        Me.gboxSearch.Controls.Add(Me.btnSearch)
        Me.gboxSearch.Controls.Add(Me.cmbSearch)
        Me.gboxSearch.Controls.Add(Me.txtSearch)
        Me.gboxSearch.Location = New System.Drawing.Point(3, 3)
        Me.gboxSearch.Name = "gboxSearch"
        Me.gboxSearch.Size = New System.Drawing.Size(913, 48)
        Me.gboxSearch.TabIndex = 356
        Me.gboxSearch.TabStop = False
        '
        'btnView
        '
        Me.btnView.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnView.Location = New System.Drawing.Point(765, 12)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(143, 29)
        Me.btnView.TabIndex = 365
        Me.btnView.Text = "View Progress Report"
        Me.btnView.UseVisualStyleBackColor = True
        '
        'cmbSearch1
        '
        Me.cmbSearch1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSearch1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSearch1.FormattingEnabled = True
        Me.cmbSearch1.Items.AddRange(New Object() {"CONSTRUCTION MATERIALS", "ADMIN AND MISC. REQUEST", "EQUIPMENT REQUEST"})
        Me.cmbSearch1.Location = New System.Drawing.Point(914, 15)
        Me.cmbSearch1.Name = "cmbSearch1"
        Me.cmbSearch1.Size = New System.Drawing.Size(223, 23)
        Me.cmbSearch1.TabIndex = 358
        '
        'lblSearchByCategory
        '
        Me.lblSearchByCategory.AutoSize = True
        Me.lblSearchByCategory.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSearchByCategory.ForeColor = System.Drawing.Color.White
        Me.lblSearchByCategory.Location = New System.Drawing.Point(6, 19)
        Me.lblSearchByCategory.Name = "lblSearchByCategory"
        Me.lblSearchByCategory.Size = New System.Drawing.Size(122, 15)
        Me.lblSearchByCategory.TabIndex = 357
        Me.lblSearchByCategory.Text = "Search By Category:"
        '
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(628, 12)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(131, 27)
        Me.btnSearch.TabIndex = 356
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'cmbSearch
        '
        Me.cmbSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSearch.FormattingEnabled = True
        Me.cmbSearch.Items.AddRange(New Object() {"DATE REQUEST", "REQUEST TYPE", "PENDING REQUEST", "RS NO.", "ALL", "LATE SERVED", "CANCELLED", "DATE NEEDED EXCEED", "DATE EXPORTED", "PURCHASED ORDER W/O RR", "CHARGE TO", "LATE RS LOG AND PO LOG"})
        Me.cmbSearch.Location = New System.Drawing.Point(129, 15)
        Me.cmbSearch.Name = "cmbSearch"
        Me.cmbSearch.Size = New System.Drawing.Size(223, 23)
        Me.cmbSearch.TabIndex = 356
        '
        'btnRefresh
        '
        Me.btnRefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefresh.ForeColor = System.Drawing.Color.OliveDrab
        Me.btnRefresh.Location = New System.Drawing.Point(1201, 3)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(84, 30)
        Me.btnRefresh.TabIndex = 361
        Me.btnRefresh.Text = "REFRESH"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'dtgSummarySupply
        '
        Me.dtgSummarySupply.AllowUserToAddRows = False
        Me.dtgSummarySupply.AllowUserToDeleteRows = False
        Me.dtgSummarySupply.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Red
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgSummarySupply.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dtgSummarySupply.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgSummarySupply.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.No, Me.col_rs_id, Me.col_rs_date, Me.col_po_date, Me.col_ws_date, Me.col_qty, Me.col_unit, Me.col_item_name, Me.col_received_qty, Me.col_requestor, Me.col_po_no_and_ws_no, Me.col_rs_no, Me.col_rr_no, Me.col_date_of_rr, Me.col_date_needed, Me.col_unit_price, Me.col_amount, Me.col_charges, Me.col_lead_time_rs_to_po, Me.col_lead_time_po_to_rr, Me.col_supplier, Me.col_remarks, Me.col_type_of_request, Me.col_invoice, Me.col_so_no, Me.col_hauler, Me.col_plate_no, Me.col_status, Me.col_type, Me.rs_to_ws, Me.rs_to_po, Me.po_to_rr, Me.rs_to_rr, Me.terms, Me.NEEDED_RECEIVED, Me.DATE_LOG_REQUEST, Me.DATE_LOG_RECEIVED, Me.Job_order_no, Me.Location, Me.Purpose})
        Me.dtgSummarySupply.ContextMenuStrip = Me.cms_FRecvngReportLst
        Me.dtgSummarySupply.Cursor = System.Windows.Forms.Cursors.Default
        DataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle29.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle29.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle29.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle29.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle29.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle29.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgSummarySupply.DefaultCellStyle = DataGridViewCellStyle29
        Me.dtgSummarySupply.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtgSummarySupply.Location = New System.Drawing.Point(3, 63)
        Me.dtgSummarySupply.Name = "dtgSummarySupply"
        Me.dtgSummarySupply.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgSummarySupply.Size = New System.Drawing.Size(1288, 426)
        Me.dtgSummarySupply.TabIndex = 362
        '
        'No
        '
        Me.No.HeaderText = "No."
        Me.No.Name = "No"
        Me.No.ReadOnly = True
        Me.No.Width = 40
        '
        'col_rs_id
        '
        Me.col_rs_id.HeaderText = "rsID"
        Me.col_rs_id.Name = "col_rs_id"
        Me.col_rs_id.ReadOnly = True
        Me.col_rs_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.col_rs_id.Visible = False
        Me.col_rs_id.Width = 50
        '
        'col_rs_date
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.col_rs_date.DefaultCellStyle = DataGridViewCellStyle2
        Me.col_rs_date.HeaderText = "R.S. DATE"
        Me.col_rs_date.Name = "col_rs_date"
        Me.col_rs_date.ReadOnly = True
        Me.col_rs_date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.col_rs_date.Width = 150
        '
        'col_po_date
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.col_po_date.DefaultCellStyle = DataGridViewCellStyle3
        Me.col_po_date.HeaderText = "PO/WS. DATE"
        Me.col_po_date.Name = "col_po_date"
        Me.col_po_date.ReadOnly = True
        Me.col_po_date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.col_po_date.Width = 150
        '
        'col_ws_date
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.col_ws_date.DefaultCellStyle = DataGridViewCellStyle4
        Me.col_ws_date.HeaderText = "RR_ITEM_ID"
        Me.col_ws_date.Name = "col_ws_date"
        Me.col_ws_date.ReadOnly = True
        Me.col_ws_date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.col_ws_date.Visible = False
        Me.col_ws_date.Width = 50
        '
        'col_qty
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.col_qty.DefaultCellStyle = DataGridViewCellStyle5
        Me.col_qty.HeaderText = "QUANTITY REQUESTED"
        Me.col_qty.Name = "col_qty"
        Me.col_qty.ReadOnly = True
        Me.col_qty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'col_unit
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.col_unit.DefaultCellStyle = DataGridViewCellStyle6
        Me.col_unit.HeaderText = "UNIT"
        Me.col_unit.Name = "col_unit"
        Me.col_unit.ReadOnly = True
        Me.col_unit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'col_item_name
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.col_item_name.DefaultCellStyle = DataGridViewCellStyle7
        Me.col_item_name.HeaderText = "ITEM NAME"
        Me.col_item_name.Name = "col_item_name"
        Me.col_item_name.ReadOnly = True
        Me.col_item_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.col_item_name.Width = 150
        '
        'col_received_qty
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.col_received_qty.DefaultCellStyle = DataGridViewCellStyle8
        Me.col_received_qty.HeaderText = "RECEIVED/WITHDRAWN QTY"
        Me.col_received_qty.Name = "col_received_qty"
        Me.col_received_qty.ReadOnly = True
        Me.col_received_qty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.col_received_qty.Width = 130
        '
        'col_requestor
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.col_requestor.DefaultCellStyle = DataGridViewCellStyle9
        Me.col_requestor.HeaderText = "REQUESTOR"
        Me.col_requestor.Name = "col_requestor"
        Me.col_requestor.ReadOnly = True
        Me.col_requestor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'col_po_no_and_ws_no
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.col_po_no_and_ws_no.DefaultCellStyle = DataGridViewCellStyle10
        Me.col_po_no_and_ws_no.HeaderText = "P.O. NO/W.S NO"
        Me.col_po_no_and_ws_no.Name = "col_po_no_and_ws_no"
        Me.col_po_no_and_ws_no.ReadOnly = True
        Me.col_po_no_and_ws_no.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'col_rs_no
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.col_rs_no.DefaultCellStyle = DataGridViewCellStyle11
        Me.col_rs_no.HeaderText = "R.S. NO"
        Me.col_rs_no.Name = "col_rs_no"
        Me.col_rs_no.ReadOnly = True
        Me.col_rs_no.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'col_rr_no
        '
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.col_rr_no.DefaultCellStyle = DataGridViewCellStyle12
        Me.col_rr_no.HeaderText = "R.R. NO"
        Me.col_rr_no.Name = "col_rr_no"
        Me.col_rr_no.ReadOnly = True
        Me.col_rr_no.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'col_date_of_rr
        '
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.col_date_of_rr.DefaultCellStyle = DataGridViewCellStyle13
        Me.col_date_of_rr.HeaderText = "DATE OF RR"
        Me.col_date_of_rr.Name = "col_date_of_rr"
        Me.col_date_of_rr.ReadOnly = True
        Me.col_date_of_rr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.col_date_of_rr.Width = 130
        '
        'col_date_needed
        '
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.col_date_needed.DefaultCellStyle = DataGridViewCellStyle14
        Me.col_date_needed.HeaderText = "PO DATE  NEEDED"
        Me.col_date_needed.Name = "col_date_needed"
        Me.col_date_needed.ReadOnly = True
        '
        'col_unit_price
        '
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.col_unit_price.DefaultCellStyle = DataGridViewCellStyle15
        Me.col_unit_price.HeaderText = "UNIT PRICE"
        Me.col_unit_price.Name = "col_unit_price"
        Me.col_unit_price.ReadOnly = True
        Me.col_unit_price.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.col_unit_price.Width = 130
        '
        'col_amount
        '
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.col_amount.DefaultCellStyle = DataGridViewCellStyle16
        Me.col_amount.HeaderText = "AMOUNT"
        Me.col_amount.Name = "col_amount"
        Me.col_amount.ReadOnly = True
        Me.col_amount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.col_amount.Visible = False
        '
        'col_charges
        '
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.col_charges.DefaultCellStyle = DataGridViewCellStyle17
        Me.col_charges.HeaderText = "CHARGES"
        Me.col_charges.Name = "col_charges"
        Me.col_charges.ReadOnly = True
        Me.col_charges.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.col_charges.Width = 130
        '
        'col_lead_time_rs_to_po
        '
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.col_lead_time_rs_to_po.DefaultCellStyle = DataGridViewCellStyle18
        Me.col_lead_time_rs_to_po.HeaderText = "LEAD TIME R.S. TO P.O."
        Me.col_lead_time_rs_to_po.Name = "col_lead_time_rs_to_po"
        Me.col_lead_time_rs_to_po.ReadOnly = True
        Me.col_lead_time_rs_to_po.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'col_lead_time_po_to_rr
        '
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.col_lead_time_po_to_rr.DefaultCellStyle = DataGridViewCellStyle19
        Me.col_lead_time_po_to_rr.HeaderText = "LEAD TIME P.O. TO R.R."
        Me.col_lead_time_po_to_rr.Name = "col_lead_time_po_to_rr"
        Me.col_lead_time_po_to_rr.ReadOnly = True
        '
        'col_supplier
        '
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.col_supplier.DefaultCellStyle = DataGridViewCellStyle20
        Me.col_supplier.HeaderText = "SUPPLIER"
        Me.col_supplier.Name = "col_supplier"
        Me.col_supplier.ReadOnly = True
        Me.col_supplier.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.col_supplier.Width = 130
        '
        'col_remarks
        '
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.col_remarks.DefaultCellStyle = DataGridViewCellStyle21
        Me.col_remarks.HeaderText = "REMARKS"
        Me.col_remarks.Name = "col_remarks"
        Me.col_remarks.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.col_remarks.Width = 250
        '
        'col_type_of_request
        '
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.col_type_of_request.DefaultCellStyle = DataGridViewCellStyle22
        Me.col_type_of_request.HeaderText = "TYPE OF REQUEST"
        Me.col_type_of_request.Name = "col_type_of_request"
        Me.col_type_of_request.ReadOnly = True
        Me.col_type_of_request.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.col_type_of_request.Width = 130
        '
        'col_invoice
        '
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.col_invoice.DefaultCellStyle = DataGridViewCellStyle23
        Me.col_invoice.HeaderText = "D.R, T.R, O.R/INVOICE"
        Me.col_invoice.Name = "col_invoice"
        Me.col_invoice.ReadOnly = True
        Me.col_invoice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'col_so_no
        '
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.col_so_no.DefaultCellStyle = DataGridViewCellStyle24
        Me.col_so_no.HeaderText = "S.O. NO"
        Me.col_so_no.Name = "col_so_no"
        Me.col_so_no.ReadOnly = True
        Me.col_so_no.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'col_hauler
        '
        DataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.col_hauler.DefaultCellStyle = DataGridViewCellStyle25
        Me.col_hauler.HeaderText = "HAULER"
        Me.col_hauler.Name = "col_hauler"
        Me.col_hauler.ReadOnly = True
        Me.col_hauler.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'col_plate_no
        '
        DataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.col_plate_no.DefaultCellStyle = DataGridViewCellStyle26
        Me.col_plate_no.HeaderText = "PLATE NO"
        Me.col_plate_no.Name = "col_plate_no"
        Me.col_plate_no.ReadOnly = True
        Me.col_plate_no.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'col_status
        '
        DataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.col_status.DefaultCellStyle = DataGridViewCellStyle27
        Me.col_status.HeaderText = "STATUS"
        Me.col_status.Name = "col_status"
        Me.col_status.ReadOnly = True
        Me.col_status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'col_type
        '
        DataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.col_type.DefaultCellStyle = DataGridViewCellStyle28
        Me.col_type.HeaderText = "TYPE"
        Me.col_type.Name = "col_type"
        Me.col_type.ReadOnly = True
        Me.col_type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.col_type.Width = 150
        '
        'rs_to_ws
        '
        Me.rs_to_ws.HeaderText = "RS. to WS."
        Me.rs_to_ws.Name = "rs_to_ws"
        Me.rs_to_ws.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.rs_to_ws.Visible = False
        '
        'rs_to_po
        '
        Me.rs_to_po.HeaderText = "RS. to PO."
        Me.rs_to_po.Name = "rs_to_po"
        Me.rs_to_po.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.rs_to_po.Visible = False
        '
        'po_to_rr
        '
        Me.po_to_rr.HeaderText = "PO. to RR."
        Me.po_to_rr.Name = "po_to_rr"
        Me.po_to_rr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.po_to_rr.Visible = False
        '
        'rs_to_rr
        '
        Me.rs_to_rr.HeaderText = "RS. to RR."
        Me.rs_to_rr.Name = "rs_to_rr"
        Me.rs_to_rr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.rs_to_rr.Visible = False
        '
        'terms
        '
        Me.terms.HeaderText = "TERMS (days)"
        Me.terms.Name = "terms"
        Me.terms.ReadOnly = True
        Me.terms.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'NEEDED_RECEIVED
        '
        Me.NEEDED_RECEIVED.HeaderText = "NEEDED_RECEIVED"
        Me.NEEDED_RECEIVED.Name = "NEEDED_RECEIVED"
        Me.NEEDED_RECEIVED.ReadOnly = True
        Me.NEEDED_RECEIVED.Width = 30
        '
        'DATE_LOG_REQUEST
        '
        Me.DATE_LOG_REQUEST.HeaderText = "DATE LOG REQUEST"
        Me.DATE_LOG_REQUEST.Name = "DATE_LOG_REQUEST"
        Me.DATE_LOG_REQUEST.ReadOnly = True
        Me.DATE_LOG_REQUEST.Visible = False
        '
        'DATE_LOG_RECEIVED
        '
        Me.DATE_LOG_RECEIVED.HeaderText = "DATE LOG RECEIVED"
        Me.DATE_LOG_RECEIVED.Name = "DATE_LOG_RECEIVED"
        Me.DATE_LOG_RECEIVED.ReadOnly = True
        Me.DATE_LOG_RECEIVED.Visible = False
        '
        'Job_order_no
        '
        Me.Job_order_no.HeaderText = "Job order no"
        Me.Job_order_no.Name = "Job_order_no"
        Me.Job_order_no.Visible = False
        '
        'Location
        '
        Me.Location.HeaderText = "Location"
        Me.Location.Name = "Location"
        Me.Location.Visible = False
        '
        'Purpose
        '
        Me.Purpose.HeaderText = "Purpose"
        Me.Purpose.Name = "Purpose"
        '
        'panel_daterange_req
        '
        Me.panel_daterange_req.BackgroundImage = Global.SUPPLY.My.Resources.Resources.bg_line
        Me.panel_daterange_req.Controls.Add(Me.Label7)
        Me.panel_daterange_req.Controls.Add(Me.ComboBox1)
        Me.panel_daterange_req.Controls.Add(Me.Label3)
        Me.panel_daterange_req.Controls.Add(Me.Button1)
        Me.panel_daterange_req.Controls.Add(Me.Label1)
        Me.panel_daterange_req.Controls.Add(Me.btnSearch1)
        Me.panel_daterange_req.Controls.Add(Me.dtpEndDate)
        Me.panel_daterange_req.Controls.Add(Me.Label2)
        Me.panel_daterange_req.Controls.Add(Me.dtpStartDate)
        Me.panel_daterange_req.Location = New System.Drawing.Point(99, 146)
        Me.panel_daterange_req.Name = "panel_daterange_req"
        Me.panel_daterange_req.Size = New System.Drawing.Size(324, 186)
        Me.panel_daterange_req.TabIndex = 363
        Me.panel_daterange_req.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.Control
        Me.Label7.Location = New System.Drawing.Point(117, 7)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 17)
        Me.Label7.TabIndex = 363
        Me.Label7.Text = "PO Date"
        '
        'ComboBox1
        '
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"COMPLETED", "PARTIALLY COMPLETED", "WAITING FOR WS", "WAITING FOR PO AND RR", "WAITING FOR WS", "WAITING FOR RR", "ALL"})
        Me.ComboBox1.Location = New System.Drawing.Point(16, 276)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(291, 28)
        Me.ComboBox1.TabIndex = 362
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.Control
        Me.Label3.Location = New System.Drawing.Point(21, 250)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 17)
        Me.Label3.TabIndex = 361
        Me.Label3.Text = "Status:"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.BackgroundImage = Global.SUPPLY.My.Resources.Resources.close_button
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(287, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(20, 20)
        Me.Button1.TabIndex = 360
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(21, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 17)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "To:"
        '
        'btnSearch1
        '
        Me.btnSearch1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch1.Location = New System.Drawing.Point(193, 142)
        Me.btnSearch1.Name = "btnSearch1"
        Me.btnSearch1.Size = New System.Drawing.Size(114, 27)
        Me.btnSearch1.TabIndex = 358
        Me.btnSearch1.Text = "Search"
        Me.btnSearch1.UseVisualStyleBackColor = True
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(16, 105)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(291, 23)
        Me.dtpEndDate.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(19, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "From:"
        '
        'dtpStartDate
        '
        Me.dtpStartDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpStartDate.Location = New System.Drawing.Point(16, 45)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(291, 23)
        Me.dtpStartDate.TabIndex = 0
        '
        'panel_dateRange_Log
        '
        Me.panel_dateRange_Log.BackgroundImage = Global.SUPPLY.My.Resources.Resources.bg_line
        Me.panel_dateRange_Log.Controls.Add(Me.Label8)
        Me.panel_dateRange_Log.Controls.Add(Me.ComboBox2)
        Me.panel_dateRange_Log.Controls.Add(Me.Label4)
        Me.panel_dateRange_Log.Controls.Add(Me.Button3)
        Me.panel_dateRange_Log.Controls.Add(Me.Label5)
        Me.panel_dateRange_Log.Controls.Add(Me.btnSearch2)
        Me.panel_dateRange_Log.Controls.Add(Me.dtp_dateTo_Log)
        Me.panel_dateRange_Log.Controls.Add(Me.Label6)
        Me.panel_dateRange_Log.Controls.Add(Me.dtp_dateFrom_Log)
        Me.panel_dateRange_Log.Location = New System.Drawing.Point(444, 146)
        Me.panel_dateRange_Log.Name = "panel_dateRange_Log"
        Me.panel_dateRange_Log.Size = New System.Drawing.Size(324, 186)
        Me.panel_dateRange_Log.TabIndex = 364
        Me.panel_dateRange_Log.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.Control
        Me.Label8.Location = New System.Drawing.Point(97, 7)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(130, 17)
        Me.Label8.TabIndex = 364
        Me.Label8.Text = "Posted Received"
        '
        'ComboBox2
        '
        Me.ComboBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Items.AddRange(New Object() {"COMPLETED", "PARTIALLY COMPLETED", "WAITING FOR WS", "WAITING FOR PO AND RR", "WAITING FOR WS", "WAITING FOR RR", "ALL"})
        Me.ComboBox2.Location = New System.Drawing.Point(16, 276)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(291, 28)
        Me.ComboBox2.TabIndex = 362
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.Control
        Me.Label4.Location = New System.Drawing.Point(21, 250)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 17)
        Me.Label4.TabIndex = 361
        Me.Label4.Text = "Status:"
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Transparent
        Me.Button3.BackgroundImage = Global.SUPPLY.My.Resources.Resources.close_button
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Location = New System.Drawing.Point(287, 4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(20, 20)
        Me.Button3.TabIndex = 360
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.Control
        Me.Label5.Location = New System.Drawing.Point(21, 80)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 17)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "To:"
        '
        'btnSearch2
        '
        Me.btnSearch2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch2.Location = New System.Drawing.Point(193, 143)
        Me.btnSearch2.Name = "btnSearch2"
        Me.btnSearch2.Size = New System.Drawing.Size(114, 27)
        Me.btnSearch2.TabIndex = 358
        Me.btnSearch2.Text = "Search"
        Me.btnSearch2.UseVisualStyleBackColor = True
        '
        'dtp_dateTo_Log
        '
        Me.dtp_dateTo_Log.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_dateTo_Log.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_dateTo_Log.Location = New System.Drawing.Point(16, 106)
        Me.dtp_dateTo_Log.Name = "dtp_dateTo_Log"
        Me.dtp_dateTo_Log.Size = New System.Drawing.Size(291, 23)
        Me.dtp_dateTo_Log.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.Control
        Me.Label6.Location = New System.Drawing.Point(19, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 17)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "From:"
        '
        'dtp_dateFrom_Log
        '
        Me.dtp_dateFrom_Log.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_dateFrom_Log.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_dateFrom_Log.Location = New System.Drawing.Point(16, 46)
        Me.dtp_dateFrom_Log.Name = "dtp_dateFrom_Log"
        Me.dtp_dateFrom_Log.Size = New System.Drawing.Size(291, 23)
        Me.dtp_dateFrom_Log.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.Control
        Me.Label9.Location = New System.Drawing.Point(297, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(64, 48)
        Me.Label9.TabIndex = 366
        Me.Label9.Text = "Filter"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pboxHeader
        '
        Me.pboxHeader.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.pboxHeader.BackgroundImage = CType(resources.GetObject("pboxHeader.BackgroundImage"), System.Drawing.Image)
        Me.pboxHeader.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pboxHeader.InitialImage = Nothing
        Me.pboxHeader.Location = New System.Drawing.Point(0, 0)
        Me.pboxHeader.Name = "pboxHeader"
        Me.pboxHeader.Size = New System.Drawing.Size(1288, 54)
        Me.pboxHeader.TabIndex = 325
        Me.pboxHeader.TabStop = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.dtgSummarySupply, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(9, 9)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1294, 572)
        Me.TableLayoutPanel1.TabIndex = 367
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 930.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.btnRefresh, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.gboxSearch, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 495)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1288, 54)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.TableLayoutPanel3)
        Me.Panel1.Controls.Add(Me.pboxHeader)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1288, 54)
        Me.Panel1.TabIndex = 363
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 3
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.TableLayoutPanel4, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label15, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label10, 0, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(1288, 54)
        Me.TableLayoutPanel3.TabIndex = 367
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 3
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.btnExit, 2, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Label9, 1, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Panel4, 0, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(891, 3)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(394, 48)
        Me.TableLayoutPanel4.TabIndex = 328
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.TextBox1)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(3, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(288, 42)
        Me.Panel4.TabIndex = 367
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(20, 10)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(265, 22)
        Me.TextBox1.TabIndex = 365
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(253, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(224, 22)
        Me.Label15.TabIndex = 323
        Me.Label15.Text = "Summary Supply Transaction"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label10.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(3, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(244, 54)
        Me.Label10.TabIndex = 329
        Me.Label10.Text = "Summary Supply Transaction"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'panel_chargeTo
        '
        Me.panel_chargeTo.BackgroundImage = Global.SUPPLY.My.Resources.Resources.bg_line
        Me.panel_chargeTo.Controls.Add(Me.TextBox2)
        Me.panel_chargeTo.Controls.Add(Me.ComboBox4)
        Me.panel_chargeTo.Controls.Add(Me.ComboBox3)
        Me.panel_chargeTo.Controls.Add(Me.Label12)
        Me.panel_chargeTo.Controls.Add(Me.Button2)
        Me.panel_chargeTo.Controls.Add(Me.Label13)
        Me.panel_chargeTo.Controls.Add(Me.btnSearch3)
        Me.panel_chargeTo.Controls.Add(Me.Label14)
        Me.panel_chargeTo.Location = New System.Drawing.Point(780, 146)
        Me.panel_chargeTo.Name = "panel_chargeTo"
        Me.panel_chargeTo.Size = New System.Drawing.Size(326, 186)
        Me.panel_chargeTo.TabIndex = 369
        Me.panel_chargeTo.Visible = False
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TextBox2.Location = New System.Drawing.Point(20, 51)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(287, 26)
        Me.TextBox2.TabIndex = 364
        '
        'ComboBox4
        '
        Me.ComboBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox4.FormattingEnabled = True
        Me.ComboBox4.Location = New System.Drawing.Point(20, 103)
        Me.ComboBox4.Name = "ComboBox4"
        Me.ComboBox4.Size = New System.Drawing.Size(289, 28)
        Me.ComboBox4.TabIndex = 363
        '
        'ComboBox3
        '
        Me.ComboBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Items.AddRange(New Object() {"COMPLETED", "PARTIALLY COMPLETED", "WAITING FOR WS", "WAITING FOR PO AND RR", "WAITING FOR WS", "WAITING FOR RR", "ALL"})
        Me.ComboBox3.Location = New System.Drawing.Point(16, 276)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(291, 28)
        Me.ComboBox3.TabIndex = 362
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.Control
        Me.Label12.Location = New System.Drawing.Point(21, 250)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(59, 17)
        Me.Label12.TabIndex = 361
        Me.Label12.Text = "Status:"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.BackgroundImage = Global.SUPPLY.My.Resources.Resources.close_button
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(287, 4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(20, 20)
        Me.Button2.TabIndex = 360
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.Control
        Me.Label13.Location = New System.Drawing.Point(17, 25)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(89, 17)
        Me.Label13.TabIndex = 3
        Me.Label13.Text = "Charge To:"
        '
        'btnSearch3
        '
        Me.btnSearch3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch3.Location = New System.Drawing.Point(193, 143)
        Me.btnSearch3.Name = "btnSearch3"
        Me.btnSearch3.Size = New System.Drawing.Size(114, 27)
        Me.btnSearch3.TabIndex = 358
        Me.btnSearch3.Text = "Search"
        Me.btnSearch3.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.Control
        Me.Label14.Location = New System.Drawing.Point(21, 80)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(78, 17)
        Me.Label14.TabIndex = 1
        Me.Label14.Text = "Category:"
        '
        'FSummarySupplyTransaction
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SUPPLY.My.Resources.Resources.bg_line
        Me.ClientSize = New System.Drawing.Size(1312, 590)
        Me.Controls.Add(Me.panel_chargeTo)
        Me.Controls.Add(Me.panel_dateRange_Log)
        Me.Controls.Add(Me.panel_daterange_req)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FSummarySupplyTransaction"
        Me.Padding = New System.Windows.Forms.Padding(9)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "FReceivingReportList"
        Me.cms_FRecvngReportLst.ResumeLayout(False)
        Me.gboxSearch.ResumeLayout(False)
        Me.gboxSearch.PerformLayout()
        CType(Me.dtgSummarySupply, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel_daterange_req.ResumeLayout(False)
        Me.panel_daterange_req.PerformLayout()
        Me.panel_dateRange_Log.ResumeLayout(False)
        Me.panel_dateRange_Log.PerformLayout()
        CType(Me.pboxHeader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.panel_chargeTo.ResumeLayout(False)
        Me.panel_chargeTo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents cms_FRecvngReportLst As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents gboxSearch As System.Windows.Forms.GroupBox
    Friend WithEvents cmbSearch As System.Windows.Forms.ComboBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents lblSearchByCategory As System.Windows.Forms.Label
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents dtgSummarySupply As System.Windows.Forms.DataGridView
    Friend WithEvents cmbSearch1 As System.Windows.Forms.ComboBox
    Friend WithEvents panel_daterange_req As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents btnSearch1 As Button
    Friend WithEvents dtpEndDate As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents dtpStartDate As DateTimePicker
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btnView As System.Windows.Forms.Button
    Friend WithEvents ExportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents panel_dateRange_Log As Panel
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents btnSearch2 As Button
    Friend WithEvents dtp_dateTo_Log As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents dtp_dateFrom_Log As DateTimePicker
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents pboxHeader As System.Windows.Forms.PictureBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents No As DataGridViewTextBoxColumn
    Friend WithEvents col_rs_id As DataGridViewTextBoxColumn
    Friend WithEvents col_rs_date As DataGridViewTextBoxColumn
    Friend WithEvents col_po_date As DataGridViewTextBoxColumn
    Friend WithEvents col_ws_date As DataGridViewTextBoxColumn
    Friend WithEvents col_qty As DataGridViewTextBoxColumn
    Friend WithEvents col_unit As DataGridViewTextBoxColumn
    Friend WithEvents col_item_name As DataGridViewTextBoxColumn
    Friend WithEvents col_received_qty As DataGridViewTextBoxColumn
    Friend WithEvents col_requestor As DataGridViewTextBoxColumn
    Friend WithEvents col_po_no_and_ws_no As DataGridViewTextBoxColumn
    Friend WithEvents col_rs_no As DataGridViewTextBoxColumn
    Friend WithEvents col_rr_no As DataGridViewTextBoxColumn
    Friend WithEvents col_date_of_rr As DataGridViewTextBoxColumn
    Friend WithEvents col_date_needed As DataGridViewTextBoxColumn
    Friend WithEvents col_unit_price As DataGridViewTextBoxColumn
    Friend WithEvents col_amount As DataGridViewTextBoxColumn
    Friend WithEvents col_charges As DataGridViewTextBoxColumn
    Friend WithEvents col_lead_time_rs_to_po As DataGridViewTextBoxColumn
    Friend WithEvents col_lead_time_po_to_rr As DataGridViewTextBoxColumn
    Friend WithEvents col_supplier As DataGridViewTextBoxColumn
    Friend WithEvents col_remarks As DataGridViewTextBoxColumn
    Friend WithEvents col_type_of_request As DataGridViewTextBoxColumn
    Friend WithEvents col_invoice As DataGridViewTextBoxColumn
    Friend WithEvents col_so_no As DataGridViewTextBoxColumn
    Friend WithEvents col_hauler As DataGridViewTextBoxColumn
    Friend WithEvents col_plate_no As DataGridViewTextBoxColumn
    Friend WithEvents col_status As DataGridViewTextBoxColumn
    Friend WithEvents col_type As DataGridViewTextBoxColumn
    Friend WithEvents rs_to_ws As DataGridViewTextBoxColumn
    Friend WithEvents rs_to_po As DataGridViewTextBoxColumn
    Friend WithEvents po_to_rr As DataGridViewTextBoxColumn
    Friend WithEvents rs_to_rr As DataGridViewTextBoxColumn
    Friend WithEvents terms As DataGridViewTextBoxColumn
    Friend WithEvents NEEDED_RECEIVED As DataGridViewTextBoxColumn
    Friend WithEvents DATE_LOG_REQUEST As DataGridViewTextBoxColumn
    Friend WithEvents DATE_LOG_RECEIVED As DataGridViewTextBoxColumn
    Friend WithEvents Job_order_no As DataGridViewTextBoxColumn
    Friend WithEvents Location As DataGridViewTextBoxColumn
    Friend WithEvents Purpose As DataGridViewTextBoxColumn
    Friend WithEvents panel_chargeTo As Panel
    Friend WithEvents ComboBox4 As ComboBox
    Friend WithEvents ComboBox3 As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Label13 As Label
    Friend WithEvents btnSearch3 As Button
    Friend WithEvents Label14 As Label
    Friend WithEvents TextBox2 As TextBox
End Class
