<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FReceivingReportList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FReceivingReportList))
        Me.Label15 = New System.Windows.Forms.Label()
        Me.pboxHeader = New System.Windows.Forms.PictureBox()
        Me.lvlreceivingreportlist = New System.Windows.Forms.ListView()
        Me.col_rr_item_id = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_rrNo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_po_cv_no = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_rs_no = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_invoice_no = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_supplier_name = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_rr_date = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_received_by = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_checked_by = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_qty = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_item_name = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_item_description = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_remarks = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_status = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_type = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_charges = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_rs_id = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_rr_info_id = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_total_amount = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_grand_total = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_qty_received = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_lead_time_po_to_rr = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_price = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_wh_id = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_inout = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_dr_qty = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader27 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader28 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_rs_purpose = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_unit = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_date_submitted = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_rs_date = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cms_FRecvngReportLst = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditInfoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreateDRToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreateNewItemsAndUpdateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportToExcelFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.lblSearchByCategory = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.cmbSearch = New System.Windows.Forms.ComboBox()
        Me.DTP_search = New System.Windows.Forms.DateTimePicker()
        Me.Panel_date_duration = New System.Windows.Forms.Panel()
        Me.btnExit_panel_duration = New System.Windows.Forms.Button()
        Me.lblTo_date = New System.Windows.Forms.Label()
        Me.btnSearchDuration = New System.Windows.Forms.Button()
        Me.DTP_to = New System.Windows.Forms.DateTimePicker()
        Me.lblFrom_date = New System.Windows.Forms.Label()
        Me.DtpickerFrom = New System.Windows.Forms.DateTimePicker()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblRecords = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.cmb_type_of_request = New System.Windows.Forms.ComboBox()
        Me.cmbDivision = New System.Windows.Forms.ComboBox()
        Me.txtItem = New System.Windows.Forms.TextBox()
        Me.ListBox2 = New System.Windows.Forms.ListBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Timer3 = New System.Windows.Forms.Timer(Me.components)
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader29 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader30 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader31 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.timer_store_item_lbox1 = New System.Windows.Forms.Timer(Me.components)
        Me.ListBox3 = New System.Windows.Forms.ListBox()
        Me.timer_store_item_listview = New System.Windows.Forms.Timer(Me.components)
        Me.timer_back_rr_item_lbox = New System.Windows.Forms.Timer(Me.components)
        Me.timer_sort_item_lbox = New System.Windows.Forms.Timer(Me.components)
        Me.timer_export_excel = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.bw_get_rr_data = New System.ComponentModel.BackgroundWorker()
        Me.bw_check_if_finish = New System.ComponentModel.BackgroundWorker()
        Me.bw_get_po_data = New System.ComponentModel.BackgroundWorker()
        Me.bw_compile_data = New System.ComponentModel.BackgroundWorker()
        Me.bw_get_supplier_data = New System.ComponentModel.BackgroundWorker()
        Me.bw_get_items = New System.ComponentModel.BackgroundWorker()
        Me.bw_check_if_done_supp_items = New System.ComponentModel.BackgroundWorker()
        Me.bw_type_charges_name = New System.ComponentModel.BackgroundWorker()
        Me.col_serial_id = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        CType(Me.pboxHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cms_FRecvngReportLst.SuspendLayout()
        Me.Panel_date_duration.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(17, 10)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(172, 22)
        Me.Label15.TabIndex = 323
        Me.Label15.Text = "Receiving Report List"
        '
        'pboxHeader
        '
        Me.pboxHeader.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.pboxHeader.BackgroundImage = CType(resources.GetObject("pboxHeader.BackgroundImage"), System.Drawing.Image)
        Me.pboxHeader.InitialImage = Nothing
        Me.pboxHeader.Location = New System.Drawing.Point(0, 1)
        Me.pboxHeader.Name = "pboxHeader"
        Me.pboxHeader.Size = New System.Drawing.Size(1322, 41)
        Me.pboxHeader.TabIndex = 325
        Me.pboxHeader.TabStop = False
        '
        'lvlreceivingreportlist
        '
        Me.lvlreceivingreportlist.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.col_rr_item_id, Me.col_rrNo, Me.col_po_cv_no, Me.col_rs_no, Me.col_invoice_no, Me.col_supplier_name, Me.col_rr_date, Me.col_received_by, Me.col_checked_by, Me.col_qty, Me.col_item_name, Me.col_item_description, Me.col_remarks, Me.col_status, Me.col_type, Me.col_charges, Me.col_rs_id, Me.col_rr_info_id, Me.col_total_amount, Me.col_grand_total, Me.col_qty_received, Me.col_lead_time_po_to_rr, Me.col_price, Me.col_wh_id, Me.col_inout, Me.col_dr_qty, Me.ColumnHeader27, Me.ColumnHeader28, Me.col_rs_purpose, Me.col_unit, Me.col_date_submitted, Me.col_rs_date, Me.col_serial_id})
        Me.lvlreceivingreportlist.ContextMenuStrip = Me.cms_FRecvngReportLst
        Me.lvlreceivingreportlist.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvlreceivingreportlist.FullRowSelect = True
        Me.lvlreceivingreportlist.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvlreceivingreportlist.HideSelection = False
        Me.lvlreceivingreportlist.Location = New System.Drawing.Point(12, 57)
        Me.lvlreceivingreportlist.Name = "lvlreceivingreportlist"
        Me.lvlreceivingreportlist.Size = New System.Drawing.Size(1280, 453)
        Me.lvlreceivingreportlist.TabIndex = 353
        Me.lvlreceivingreportlist.UseCompatibleStateImageBehavior = False
        Me.lvlreceivingreportlist.View = System.Windows.Forms.View.Details
        '
        'col_rr_item_id
        '
        Me.col_rr_item_id.Text = "ID"
        Me.col_rr_item_id.Width = 0
        '
        'col_rrNo
        '
        Me.col_rrNo.Text = "RR No."
        Me.col_rrNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.col_rrNo.Width = 120
        '
        'col_po_cv_no
        '
        Me.col_po_cv_no.Text = "PO and CV No."
        Me.col_po_cv_no.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.col_po_cv_no.Width = 120
        '
        'col_rs_no
        '
        Me.col_rs_no.Text = "RS No."
        Me.col_rs_no.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.col_rs_no.Width = 120
        '
        'col_invoice_no
        '
        Me.col_invoice_no.Text = "Invoice No"
        Me.col_invoice_no.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.col_invoice_no.Width = 130
        '
        'col_supplier_name
        '
        Me.col_supplier_name.Text = "Supplier's Name"
        Me.col_supplier_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.col_supplier_name.Width = 250
        '
        'col_rr_date
        '
        Me.col_rr_date.Text = "RR Date"
        Me.col_rr_date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.col_rr_date.Width = 230
        '
        'col_received_by
        '
        Me.col_received_by.Text = "Received By"
        Me.col_received_by.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.col_received_by.Width = 0
        '
        'col_checked_by
        '
        Me.col_checked_by.Text = "Checked By"
        Me.col_checked_by.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.col_checked_by.Width = 0
        '
        'col_qty
        '
        Me.col_qty.Text = "Quantity"
        Me.col_qty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.col_qty.Width = 120
        '
        'col_item_name
        '
        Me.col_item_name.Text = "Item Name"
        Me.col_item_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.col_item_name.Width = 150
        '
        'col_item_description
        '
        Me.col_item_description.Text = "Item(s) Description"
        Me.col_item_description.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.col_item_description.Width = 350
        '
        'col_remarks
        '
        Me.col_remarks.Text = "Remarks"
        Me.col_remarks.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.col_remarks.Width = 130
        '
        'col_status
        '
        Me.col_status.Text = "Status"
        Me.col_status.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.col_status.Width = 150
        '
        'col_type
        '
        Me.col_type.Text = "Type"
        Me.col_type.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.col_type.Width = 170
        '
        'col_charges
        '
        Me.col_charges.Text = "Charge To"
        Me.col_charges.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.col_charges.Width = 150
        '
        'col_rs_id
        '
        Me.col_rs_id.Text = "rs_id"
        Me.col_rs_id.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.col_rs_id.Width = 0
        '
        'col_rr_info_id
        '
        Me.col_rr_info_id.Text = "rr_info_id"
        Me.col_rr_info_id.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.col_rr_info_id.Width = 0
        '
        'col_total_amount
        '
        Me.col_total_amount.Text = "Total Amount"
        Me.col_total_amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.col_total_amount.Width = 150
        '
        'col_grand_total
        '
        Me.col_grand_total.Text = "Total"
        Me.col_grand_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.col_grand_total.Width = 0
        '
        'col_qty_received
        '
        Me.col_qty_received.Text = "Qty Received"
        Me.col_qty_received.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.col_qty_received.Width = 0
        '
        'col_lead_time_po_to_rr
        '
        Me.col_lead_time_po_to_rr.Text = "Lead time PO to RR"
        Me.col_lead_time_po_to_rr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.col_lead_time_po_to_rr.Width = 150
        '
        'col_price
        '
        Me.col_price.Text = "Price"
        Me.col_price.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.col_price.Width = 200
        '
        'col_wh_id
        '
        Me.col_wh_id.Text = "wh_id"
        Me.col_wh_id.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'col_inout
        '
        Me.col_inout.Text = "IN/OUT"
        Me.col_inout.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'col_dr_qty
        '
        Me.col_dr_qty.Text = "DR QTY"
        Me.col_dr_qty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.col_dr_qty.Width = 120
        '
        'ColumnHeader27
        '
        Me.ColumnHeader27.Text = "Checked By"
        Me.ColumnHeader27.Width = 120
        '
        'ColumnHeader28
        '
        Me.ColumnHeader28.Text = "Received By"
        Me.ColumnHeader28.Width = 120
        '
        'col_rs_purpose
        '
        Me.col_rs_purpose.Text = "RS-Purpose"
        '
        'col_unit
        '
        Me.col_unit.Text = "Unit"
        Me.col_unit.Width = 200
        '
        'col_date_submitted
        '
        Me.col_date_submitted.Text = "Date Submitted"
        Me.col_date_submitted.Width = 200
        '
        'col_rs_date
        '
        Me.col_rs_date.Text = "RS Date"
        Me.col_rs_date.Width = 130
        '
        'cms_FRecvngReportLst
        '
        Me.cms_FRecvngReportLst.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.EditInfoToolStripMenuItem, Me.CreateDRToolStripMenuItem, Me.CreateNewItemsAndUpdateToolStripMenuItem, Me.ExportToExcelFileToolStripMenuItem, Me.EditAllToolStripMenuItem})
        Me.cms_FRecvngReportLst.Name = "cms_FRecvngReportLst"
        Me.cms_FRecvngReportLst.Size = New System.Drawing.Size(232, 158)
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(231, 22)
        Me.EditToolStripMenuItem.Text = "Edit Item Description"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(231, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'EditInfoToolStripMenuItem
        '
        Me.EditInfoToolStripMenuItem.Name = "EditInfoToolStripMenuItem"
        Me.EditInfoToolStripMenuItem.Size = New System.Drawing.Size(231, 22)
        Me.EditInfoToolStripMenuItem.Text = "Edit Info"
        '
        'CreateDRToolStripMenuItem
        '
        Me.CreateDRToolStripMenuItem.Name = "CreateDRToolStripMenuItem"
        Me.CreateDRToolStripMenuItem.Size = New System.Drawing.Size(231, 22)
        Me.CreateDRToolStripMenuItem.Text = "Create DR"
        '
        'CreateNewItemsAndUpdateToolStripMenuItem
        '
        Me.CreateNewItemsAndUpdateToolStripMenuItem.Name = "CreateNewItemsAndUpdateToolStripMenuItem"
        Me.CreateNewItemsAndUpdateToolStripMenuItem.Size = New System.Drawing.Size(231, 22)
        Me.CreateNewItemsAndUpdateToolStripMenuItem.Text = "Create New Items and Update"
        '
        'ExportToExcelFileToolStripMenuItem
        '
        Me.ExportToExcelFileToolStripMenuItem.Name = "ExportToExcelFileToolStripMenuItem"
        Me.ExportToExcelFileToolStripMenuItem.Size = New System.Drawing.Size(231, 22)
        Me.ExportToExcelFileToolStripMenuItem.Text = "Export to Excel File"
        '
        'EditAllToolStripMenuItem
        '
        Me.EditAllToolStripMenuItem.Name = "EditAllToolStripMenuItem"
        Me.EditAllToolStripMenuItem.Size = New System.Drawing.Size(231, 22)
        Me.EditAllToolStripMenuItem.Text = "Edit All"
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.Transparent
        Me.btnExit.BackgroundImage = Global.SUPPLY.My.Resources.Resources.close_button
        Me.btnExit.FlatAppearance.BorderSize = 0
        Me.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit.Location = New System.Drawing.Point(1287, 12)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(20, 20)
        Me.btnExit.TabIndex = 354
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'txtSearch
        '
        Me.txtSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(783, 11)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(230, 23)
        Me.txtSearch.TabIndex = 2
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(1149, 331)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(131, 27)
        Me.Button2.TabIndex = 360
        Me.Button2.Text = "Search2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'dtpTo
        '
        Me.dtpTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpTo.Location = New System.Drawing.Point(239, 40)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(230, 23)
        Me.dtpTo.TabIndex = 5
        '
        'dtpFrom
        '
        Me.dtpFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFrom.Location = New System.Drawing.Point(3, 40)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(230, 23)
        Me.dtpFrom.TabIndex = 4
        '
        'lblSearchByCategory
        '
        Me.lblSearchByCategory.AutoSize = True
        Me.lblSearchByCategory.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSearchByCategory.ForeColor = System.Drawing.Color.White
        Me.lblSearchByCategory.Location = New System.Drawing.Point(3, 8)
        Me.lblSearchByCategory.Name = "lblSearchByCategory"
        Me.lblSearchByCategory.Padding = New System.Windows.Forms.Padding(0, 7, 0, 0)
        Me.lblSearchByCategory.Size = New System.Drawing.Size(122, 22)
        Me.lblSearchByCategory.TabIndex = 357
        Me.lblSearchByCategory.Text = "Search By Category:"
        '
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(474, 38)
        Me.btnSearch.Margin = New System.Windows.Forms.Padding(2, 1, 0, 0)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(131, 27)
        Me.btnSearch.TabIndex = 6
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'cmbSearch
        '
        Me.cmbSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSearch.FormattingEnabled = True
        Me.cmbSearch.Items.AddRange(New Object() {"Search By Charges", "Search By Invoice No.", "Search By Items", "Search By PO and CV No", "Search By RR No", "Search By RS No", "Search By Supplier"})
        Me.cmbSearch.Location = New System.Drawing.Point(131, 11)
        Me.cmbSearch.Name = "cmbSearch"
        Me.cmbSearch.Size = New System.Drawing.Size(204, 23)
        Me.cmbSearch.TabIndex = 1
        '
        'DTP_search
        '
        Me.DTP_search.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_search.Location = New System.Drawing.Point(370, 811)
        Me.DTP_search.Name = "DTP_search"
        Me.DTP_search.Size = New System.Drawing.Size(264, 22)
        Me.DTP_search.TabIndex = 358
        Me.DTP_search.Visible = False
        '
        'Panel_date_duration
        '
        Me.Panel_date_duration.BackgroundImage = Global.SUPPLY.My.Resources.Resources.bg_line
        Me.Panel_date_duration.Controls.Add(Me.btnExit_panel_duration)
        Me.Panel_date_duration.Controls.Add(Me.lblTo_date)
        Me.Panel_date_duration.Controls.Add(Me.btnSearchDuration)
        Me.Panel_date_duration.Controls.Add(Me.DTP_to)
        Me.Panel_date_duration.Controls.Add(Me.lblFrom_date)
        Me.Panel_date_duration.Controls.Add(Me.DtpickerFrom)
        Me.Panel_date_duration.Location = New System.Drawing.Point(515, 192)
        Me.Panel_date_duration.Name = "Panel_date_duration"
        Me.Panel_date_duration.Size = New System.Drawing.Size(319, 181)
        Me.Panel_date_duration.TabIndex = 359
        Me.Panel_date_duration.Visible = False
        '
        'btnExit_panel_duration
        '
        Me.btnExit_panel_duration.BackColor = System.Drawing.Color.Transparent
        Me.btnExit_panel_duration.BackgroundImage = Global.SUPPLY.My.Resources.Resources.close_button
        Me.btnExit_panel_duration.FlatAppearance.BorderSize = 0
        Me.btnExit_panel_duration.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnExit_panel_duration.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnExit_panel_duration.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit_panel_duration.Location = New System.Drawing.Point(287, 4)
        Me.btnExit_panel_duration.Name = "btnExit_panel_duration"
        Me.btnExit_panel_duration.Size = New System.Drawing.Size(20, 20)
        Me.btnExit_panel_duration.TabIndex = 360
        Me.btnExit_panel_duration.UseVisualStyleBackColor = False
        '
        'lblTo_date
        '
        Me.lblTo_date.AutoSize = True
        Me.lblTo_date.BackColor = System.Drawing.Color.Transparent
        Me.lblTo_date.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTo_date.ForeColor = System.Drawing.SystemColors.Control
        Me.lblTo_date.Location = New System.Drawing.Point(21, 69)
        Me.lblTo_date.Name = "lblTo_date"
        Me.lblTo_date.Size = New System.Drawing.Size(32, 17)
        Me.lblTo_date.TabIndex = 3
        Me.lblTo_date.Text = "To:"
        '
        'btnSearchDuration
        '
        Me.btnSearchDuration.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearchDuration.Location = New System.Drawing.Point(193, 136)
        Me.btnSearchDuration.Name = "btnSearchDuration"
        Me.btnSearchDuration.Size = New System.Drawing.Size(114, 27)
        Me.btnSearchDuration.TabIndex = 358
        Me.btnSearchDuration.Text = "Search"
        Me.btnSearchDuration.UseVisualStyleBackColor = True
        '
        'DTP_to
        '
        Me.DTP_to.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_to.Location = New System.Drawing.Point(16, 95)
        Me.DTP_to.Name = "DTP_to"
        Me.DTP_to.Size = New System.Drawing.Size(291, 23)
        Me.DTP_to.TabIndex = 2
        '
        'lblFrom_date
        '
        Me.lblFrom_date.AutoSize = True
        Me.lblFrom_date.BackColor = System.Drawing.Color.Transparent
        Me.lblFrom_date.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFrom_date.ForeColor = System.Drawing.SystemColors.Control
        Me.lblFrom_date.Location = New System.Drawing.Point(19, 14)
        Me.lblFrom_date.Name = "lblFrom_date"
        Me.lblFrom_date.Size = New System.Drawing.Size(49, 17)
        Me.lblFrom_date.TabIndex = 1
        Me.lblFrom_date.Text = "From:"
        '
        'DtpickerFrom
        '
        Me.DtpickerFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpickerFrom.Location = New System.Drawing.Point(16, 35)
        Me.DtpickerFrom.Name = "DtpickerFrom"
        Me.DtpickerFrom.Size = New System.Drawing.Size(291, 23)
        Me.DtpickerFrom.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.BackgroundImage = CType(resources.GetObject("Panel3.BackgroundImage"), System.Drawing.Image)
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.lblRecords)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.Button1)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.PictureBox2)
        Me.Panel3.Controls.Add(Me.ProgressBar1)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Location = New System.Drawing.Point(40, 84)
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
        Me.lblRecords.Location = New System.Drawing.Point(512, 2)
        Me.lblRecords.Name = "lblRecords"
        Me.lblRecords.Size = New System.Drawing.Size(78, 26)
        Me.lblRecords.TabIndex = 422
        Me.lblRecords.Text = "0"
        Me.lblRecords.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(594, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 421
        Me.Label1.Text = "record(s) found"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.OliveDrab
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ForeColor = System.Drawing.Color.Transparent
        Me.Button1.Location = New System.Drawing.Point(597, 242)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 420
        Me.Button1.Text = "Abort"
        Me.Button1.UseVisualStyleBackColor = False
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
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.ProgressBar1.TabIndex = 417
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(5, 210)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(667, 30)
        Me.Label7.TabIndex = 415
        Me.Label7.Text = "Waiting..."
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(1149, 82)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(131, 121)
        Me.ListBox1.TabIndex = 419
        '
        'Timer2
        '
        Me.Timer2.Interval = 1000
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.FlowLayoutPanel1.Controls.Add(Me.lblSearchByCategory)
        Me.FlowLayoutPanel1.Controls.Add(Me.cmbSearch)
        Me.FlowLayoutPanel1.Controls.Add(Me.cmb_type_of_request)
        Me.FlowLayoutPanel1.Controls.Add(Me.cmbDivision)
        Me.FlowLayoutPanel1.Controls.Add(Me.txtSearch)
        Me.FlowLayoutPanel1.Controls.Add(Me.txtItem)
        Me.FlowLayoutPanel1.Controls.Add(Me.dtpFrom)
        Me.FlowLayoutPanel1.Controls.Add(Me.dtpTo)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnSearch)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(12, 521)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Padding = New System.Windows.Forms.Padding(0, 8, 0, 0)
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(1449, 45)
        Me.FlowLayoutPanel1.TabIndex = 420
        '
        'cmb_type_of_request
        '
        Me.cmb_type_of_request.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_type_of_request.FormattingEnabled = True
        Me.cmb_type_of_request.Location = New System.Drawing.Point(341, 11)
        Me.cmb_type_of_request.Name = "cmb_type_of_request"
        Me.cmb_type_of_request.Size = New System.Drawing.Size(215, 23)
        Me.cmb_type_of_request.TabIndex = 358
        Me.cmb_type_of_request.Visible = False
        '
        'cmbDivision
        '
        Me.cmbDivision.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDivision.FormattingEnabled = True
        Me.cmbDivision.Items.AddRange(New Object() {"WAREHOUSING AND SUPPLY", "CRUSHING AND HAULING"})
        Me.cmbDivision.Location = New System.Drawing.Point(562, 11)
        Me.cmbDivision.Name = "cmbDivision"
        Me.cmbDivision.Size = New System.Drawing.Size(215, 23)
        Me.cmbDivision.TabIndex = 359
        Me.cmbDivision.Visible = False
        '
        'txtItem
        '
        Me.txtItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItem.Location = New System.Drawing.Point(1019, 11)
        Me.txtItem.Name = "txtItem"
        Me.txtItem.Size = New System.Drawing.Size(200, 23)
        Me.txtItem.TabIndex = 3
        Me.txtItem.Visible = False
        '
        'ListBox2
        '
        Me.ListBox2.FormattingEnabled = True
        Me.ListBox2.Location = New System.Drawing.Point(1298, 87)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.Size = New System.Drawing.Size(120, 121)
        Me.ListBox2.TabIndex = 421
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(1149, 376)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(131, 27)
        Me.Button3.TabIndex = 422
        Me.Button3.Text = "Search3"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Timer3
        '
        Me.Timer3.Interval = 1000
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader29, Me.ColumnHeader30, Me.ColumnHeader31})
        Me.ListView1.FullRowSelect = True
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(1298, 214)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(163, 208)
        Me.ListView1.TabIndex = 423
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader29
        '
        Me.ColumnHeader29.Width = 74
        '
        'ColumnHeader30
        '
        Me.ColumnHeader30.Width = 73
        '
        'timer_store_item_lbox1
        '
        Me.timer_store_item_lbox1.Interval = 300
        '
        'ListBox3
        '
        Me.ListBox3.FormattingEnabled = True
        Me.ListBox3.Location = New System.Drawing.Point(1149, 206)
        Me.ListBox3.Name = "ListBox3"
        Me.ListBox3.Size = New System.Drawing.Size(131, 121)
        Me.ListBox3.TabIndex = 424
        '
        'timer_store_item_listview
        '
        Me.timer_store_item_listview.Interval = 300
        '
        'timer_back_rr_item_lbox
        '
        Me.timer_back_rr_item_lbox.Interval = 300
        '
        'timer_sort_item_lbox
        '
        Me.timer_sort_item_lbox.Interval = 300
        '
        'timer_export_excel
        '
        Me.timer_export_excel.Interval = 300
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.BackgroundImage = Global.SUPPLY.My.Resources.Resources.bg_line
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Button4)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(21, 423)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(367, 75)
        Me.Panel1.TabIndex = 425
        Me.Panel1.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(94, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(140, 13)
        Me.Label3.TabIndex = 422
        Me.Label3.Text = "Process has been aborted..."
        Me.Label3.Visible = False
        '
        'Button4
        '
        Me.Button4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Button4.BackColor = System.Drawing.Color.Red
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.Transparent
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button4.Location = New System.Drawing.Point(339, 4)
        Me.Button4.Margin = New System.Windows.Forms.Padding(0)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(22, 24)
        Me.Button4.TabIndex = 421
        Me.Button4.Text = "x"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button4.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = Global.SUPPLY.My.Resources.Resources.turn_over
        Me.PictureBox1.Location = New System.Drawing.Point(16, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(72, 50)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 417
        Me.PictureBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(93, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(268, 23)
        Me.Label2.TabIndex = 416
        Me.Label2.Text = "Waiting..."
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'bw_get_rr_data
        '
        '
        'bw_check_if_finish
        '
        '
        'bw_get_po_data
        '
        '
        'bw_compile_data
        '
        '
        'bw_get_supplier_data
        '
        '
        'bw_get_items
        '
        '
        'bw_check_if_done_supp_items
        '
        '
        'bw_type_charges_name
        '
        '
        'col_serial_id
        '
        Me.col_serial_id.Text = "serial_id"
        '
        'FReceivingReportList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SUPPLY.My.Resources.Resources.bg_line
        Me.ClientSize = New System.Drawing.Size(1473, 579)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ListBox3)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.ListBox2)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel_date_duration)
        Me.Controls.Add(Me.DTP_search)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.lvlreceivingreportlist)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.pboxHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FReceivingReportList"
        Me.Padding = New System.Windows.Forms.Padding(9)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "FReceivingReportList"
        CType(Me.pboxHeader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cms_FRecvngReportLst.ResumeLayout(False)
        Me.Panel_date_duration.ResumeLayout(False)
        Me.Panel_date_duration.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents pboxHeader As System.Windows.Forms.PictureBox
    Friend WithEvents lvlreceivingreportlist As System.Windows.Forms.ListView
    Friend WithEvents col_rrNo As System.Windows.Forms.ColumnHeader
    Friend WithEvents col_po_cv_no As System.Windows.Forms.ColumnHeader
    Friend WithEvents col_rs_no As System.Windows.Forms.ColumnHeader
    Friend WithEvents col_invoice_no As System.Windows.Forms.ColumnHeader
    Friend WithEvents col_supplier_name As System.Windows.Forms.ColumnHeader
    Friend WithEvents col_rr_date As System.Windows.Forms.ColumnHeader
    Friend WithEvents col_received_by As System.Windows.Forms.ColumnHeader
    Friend WithEvents col_checked_by As System.Windows.Forms.ColumnHeader
    Friend WithEvents col_qty As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents cms_FRecvngReportLst As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents col_item_description As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents cmbSearch As System.Windows.Forms.ComboBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents col_remarks As System.Windows.Forms.ColumnHeader
    Friend WithEvents col_status As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblSearchByCategory As System.Windows.Forms.Label
    Friend WithEvents DTP_search As System.Windows.Forms.DateTimePicker
    Friend WithEvents Panel_date_duration As System.Windows.Forms.Panel
    Friend WithEvents DtpickerFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblTo_date As System.Windows.Forms.Label
    Friend WithEvents DTP_to As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFrom_date As System.Windows.Forms.Label
    Friend WithEvents btnSearchDuration As System.Windows.Forms.Button
    Friend WithEvents btnExit_panel_duration As System.Windows.Forms.Button
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents col_rr_item_id As System.Windows.Forms.ColumnHeader
    Friend WithEvents col_type As System.Windows.Forms.ColumnHeader
    Friend WithEvents col_item_name As System.Windows.Forms.ColumnHeader
    Friend WithEvents col_charges As System.Windows.Forms.ColumnHeader
    Friend WithEvents col_rs_id As System.Windows.Forms.ColumnHeader
    Friend WithEvents col_rr_info_id As System.Windows.Forms.ColumnHeader
    Friend WithEvents col_total_amount As ColumnHeader
    Friend WithEvents col_grand_total As ColumnHeader
    Friend WithEvents col_qty_received As ColumnHeader
    Friend WithEvents EditInfoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents col_lead_time_po_to_rr As ColumnHeader
    Friend WithEvents dtpTo As DateTimePicker
    Friend WithEvents dtpFrom As DateTimePicker
    Friend WithEvents col_price As ColumnHeader
    Friend WithEvents CreateDRToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents col_wh_id As ColumnHeader
    Friend WithEvents col_inout As ColumnHeader
    Friend WithEvents col_dr_qty As ColumnHeader
    Friend WithEvents CreateNewItemsAndUpdateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExportToExcelFileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents Label7 As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents Timer2 As Timer
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents txtItem As TextBox
    Friend WithEvents lblRecords As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents ColumnHeader27 As ColumnHeader
    Friend WithEvents ColumnHeader28 As ColumnHeader
    Friend WithEvents ListBox2 As ListBox
    Friend WithEvents Button3 As Button
    Friend WithEvents Timer3 As Timer
    Friend WithEvents cmb_type_of_request As ComboBox
    Friend WithEvents ListView1 As ListView
    Friend WithEvents ColumnHeader29 As ColumnHeader
    Friend WithEvents ColumnHeader30 As ColumnHeader
    Friend WithEvents timer_store_item_lbox1 As Timer
    Friend WithEvents ListBox3 As ListBox
    Friend WithEvents timer_store_item_listview As Timer
    Friend WithEvents timer_back_rr_item_lbox As Timer
    Friend WithEvents timer_sort_item_lbox As Timer
    Friend WithEvents ColumnHeader31 As ColumnHeader
    Friend WithEvents cmbDivision As ComboBox
    Friend WithEvents col_rs_purpose As ColumnHeader
    Friend WithEvents timer_export_excel As Timer
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Button4 As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents col_unit As ColumnHeader
    Friend WithEvents bw_get_rr_data As System.ComponentModel.BackgroundWorker
    Friend WithEvents bw_check_if_finish As System.ComponentModel.BackgroundWorker
    Friend WithEvents bw_get_po_data As System.ComponentModel.BackgroundWorker
    Friend WithEvents bw_compile_data As System.ComponentModel.BackgroundWorker
    Friend WithEvents bw_get_supplier_data As System.ComponentModel.BackgroundWorker
    Friend WithEvents bw_get_items As System.ComponentModel.BackgroundWorker
    Friend WithEvents bw_check_if_done_supp_items As System.ComponentModel.BackgroundWorker
    Friend WithEvents bw_type_charges_name As System.ComponentModel.BackgroundWorker
    Friend WithEvents col_date_submitted As ColumnHeader
    Friend WithEvents col_rs_date As ColumnHeader
    Friend WithEvents EditAllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents col_serial_id As ColumnHeader
End Class
