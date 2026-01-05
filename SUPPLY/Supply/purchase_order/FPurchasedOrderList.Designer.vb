<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FPurchasedOrderList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FPurchasedOrderList))
        Me.Label15 = New System.Windows.Forms.Label()
        Me.pboxHeader = New System.Windows.Forms.PictureBox()
        Me.lvlpurchasedOrderList = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader22 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader19 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader14 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader15 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader16 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader17 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader18 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_rs_id = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader21 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_po_id = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader24 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader25 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_print_status = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader27 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader28 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader29 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader30 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_type_of_request = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_user_update_log = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader31 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_proper_name = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_price_with_tax = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_tax_category = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CMB_lvlpurchasedOrderList = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditQtyOnlyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditQtyAuthToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CalculateQtyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintPOToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportPOToExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.ListJobOrderNo = New System.Windows.Forms.ListBox()
        Me.gboxSearch = New System.Windows.Forms.GroupBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.cmbSearchByCategory = New System.Windows.Forms.ComboBox()
        Me.lblSearchByCategory = New System.Windows.Forms.Label()
        Me.dtpSearchPoDATE = New System.Windows.Forms.DateTimePicker()
        Me.panel_fdate = New System.Windows.Forms.Panel()
        Me.btn_panelExt = New System.Windows.Forms.Button()
        Me.lbl_to = New System.Windows.Forms.Label()
        Me.lbl_From = New System.Windows.Forms.Label()
        Me.btn_view = New System.Windows.Forms.Button()
        Me.DTP_dateTo = New System.Windows.Forms.DateTimePicker()
        Me.DTP_dateFrom = New System.Windows.Forms.DateTimePicker()
        Me.Timer_panelmvemEnt = New System.Windows.Forms.Timer(Me.components)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblRecords = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.BW_search = New System.ComponentModel.BackgroundWorker()
        Me.BW_export_to_excel_by_dateLog_price = New System.ComponentModel.BackgroundWorker()
        CType(Me.pboxHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMB_lvlpurchasedOrderList.SuspendLayout()
        Me.gboxSearch.SuspendLayout()
        Me.panel_fdate.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(12, 9)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(167, 22)
        Me.Label15.TabIndex = 357
        Me.Label15.Text = "Purchased Order List"
        '
        'pboxHeader
        '
        Me.pboxHeader.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.pboxHeader.BackgroundImage = CType(resources.GetObject("pboxHeader.BackgroundImage"), System.Drawing.Image)
        Me.pboxHeader.InitialImage = Nothing
        Me.pboxHeader.Location = New System.Drawing.Point(0, 0)
        Me.pboxHeader.Name = "pboxHeader"
        Me.pboxHeader.Size = New System.Drawing.Size(203, 41)
        Me.pboxHeader.TabIndex = 358
        Me.pboxHeader.TabStop = False
        '
        'lvlpurchasedOrderList
        '
        Me.lvlpurchasedOrderList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader22, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader19, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11, Me.ColumnHeader12, Me.ColumnHeader13, Me.ColumnHeader14, Me.ColumnHeader15, Me.ColumnHeader16, Me.ColumnHeader17, Me.ColumnHeader18, Me.col_rs_id, Me.ColumnHeader21, Me.col_po_id, Me.ColumnHeader24, Me.ColumnHeader25, Me.col_print_status, Me.ColumnHeader27, Me.ColumnHeader28, Me.ColumnHeader29, Me.ColumnHeader30, Me.col_type_of_request, Me.col_user_update_log, Me.ColumnHeader31, Me.col_proper_name, Me.col_price_with_tax, Me.col_tax_category})
        Me.lvlpurchasedOrderList.ContextMenuStrip = Me.CMB_lvlpurchasedOrderList
        Me.lvlpurchasedOrderList.Font = New System.Drawing.Font("Bombardier", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvlpurchasedOrderList.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lvlpurchasedOrderList.FullRowSelect = True
        Me.lvlpurchasedOrderList.GridLines = True
        Me.lvlpurchasedOrderList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvlpurchasedOrderList.HideSelection = False
        Me.lvlpurchasedOrderList.Location = New System.Drawing.Point(16, 47)
        Me.lvlpurchasedOrderList.Name = "lvlpurchasedOrderList"
        Me.lvlpurchasedOrderList.Size = New System.Drawing.Size(1338, 618)
        Me.lvlpurchasedOrderList.TabIndex = 359
        Me.lvlpurchasedOrderList.UseCompatibleStateImageBehavior = False
        Me.lvlpurchasedOrderList.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "po_det_id"
        Me.ColumnHeader1.Width = 120
        '
        'ColumnHeader22
        '
        Me.ColumnHeader22.Text = "PO No/CV No"
        Me.ColumnHeader22.Width = 100
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "RS No."
        Me.ColumnHeader2.Width = 120
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "PO/CV Date"
        Me.ColumnHeader3.Width = 180
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Supplier"
        Me.ColumnHeader4.Width = 180
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Item Name"
        Me.ColumnHeader5.Width = 280
        '
        'ColumnHeader19
        '
        Me.ColumnHeader19.DisplayIndex = 7
        Me.ColumnHeader19.Text = "PO Description/Warehouse Description"
        Me.ColumnHeader19.Width = 270
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.DisplayIndex = 8
        Me.ColumnHeader6.Text = "Quantity"
        Me.ColumnHeader6.Width = 110
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.DisplayIndex = 9
        Me.ColumnHeader7.Text = "Unit"
        Me.ColumnHeader7.Width = 120
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.DisplayIndex = 10
        Me.ColumnHeader8.Text = "Unit Price (original)"
        Me.ColumnHeader8.Width = 120
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.DisplayIndex = 13
        Me.ColumnHeader9.Text = "Total Amount"
        Me.ColumnHeader9.Width = 120
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.DisplayIndex = 14
        Me.ColumnHeader10.Text = "Status"
        Me.ColumnHeader10.Width = 130
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.DisplayIndex = 15
        Me.ColumnHeader11.Text = "Instructions"
        Me.ColumnHeader11.Width = 150
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.DisplayIndex = 16
        Me.ColumnHeader12.Text = "Address"
        Me.ColumnHeader12.Width = 150
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.DisplayIndex = 17
        Me.ColumnHeader13.Text = "Terms"
        Me.ColumnHeader13.Width = 100
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.DisplayIndex = 18
        Me.ColumnHeader14.Text = "Charge_to"
        Me.ColumnHeader14.Width = 150
        '
        'ColumnHeader15
        '
        Me.ColumnHeader15.DisplayIndex = 19
        Me.ColumnHeader15.Text = "Date Needed"
        Me.ColumnHeader15.Width = 150
        '
        'ColumnHeader16
        '
        Me.ColumnHeader16.DisplayIndex = 20
        Me.ColumnHeader16.Text = "Prepared_by"
        Me.ColumnHeader16.Width = 150
        '
        'ColumnHeader17
        '
        Me.ColumnHeader17.DisplayIndex = 21
        Me.ColumnHeader17.Text = "Check_by"
        Me.ColumnHeader17.Width = 150
        '
        'ColumnHeader18
        '
        Me.ColumnHeader18.DisplayIndex = 22
        Me.ColumnHeader18.Text = "Approved_by"
        Me.ColumnHeader18.Width = 150
        '
        'col_rs_id
        '
        Me.col_rs_id.DisplayIndex = 23
        Me.col_rs_id.Text = "rs_id"
        '
        'ColumnHeader21
        '
        Me.ColumnHeader21.DisplayIndex = 24
        Me.ColumnHeader21.Text = "Status"
        Me.ColumnHeader21.Width = 100
        '
        'col_po_id
        '
        Me.col_po_id.DisplayIndex = 25
        Me.col_po_id.Text = "po_id"
        '
        'ColumnHeader24
        '
        Me.ColumnHeader24.DisplayIndex = 26
        Me.ColumnHeader24.Text = "in/out"
        '
        'ColumnHeader25
        '
        Me.ColumnHeader25.DisplayIndex = 27
        Me.ColumnHeader25.Text = "Lead time RS to PO"
        Me.ColumnHeader25.Width = 150
        '
        'col_print_status
        '
        Me.col_print_status.DisplayIndex = 28
        Me.col_print_status.Text = "Print Status"
        Me.col_print_status.Width = 120
        '
        'ColumnHeader27
        '
        Me.ColumnHeader27.DisplayIndex = 29
        Me.ColumnHeader27.Text = "Original Date Printed"
        Me.ColumnHeader27.Width = 140
        '
        'ColumnHeader28
        '
        Me.ColumnHeader28.DisplayIndex = 30
        Me.ColumnHeader28.Text = "Updated Date Printed"
        Me.ColumnHeader28.Width = 140
        '
        'ColumnHeader29
        '
        Me.ColumnHeader29.DisplayIndex = 31
        Me.ColumnHeader29.Text = "User Logs"
        Me.ColumnHeader29.Width = 140
        '
        'ColumnHeader30
        '
        Me.ColumnHeader30.DisplayIndex = 32
        Me.ColumnHeader30.Text = "RS Date"
        '
        'col_type_of_request
        '
        Me.col_type_of_request.DisplayIndex = 33
        Me.col_type_of_request.Text = "Type of Request"
        Me.col_type_of_request.Width = 200
        '
        'col_user_update_log
        '
        Me.col_user_update_log.DisplayIndex = 34
        Me.col_user_update_log.Text = "User Update Log"
        '
        'ColumnHeader31
        '
        Me.ColumnHeader31.DisplayIndex = 35
        Me.ColumnHeader31.Text = "Requestor"
        '
        'col_proper_name
        '
        Me.col_proper_name.DisplayIndex = 6
        Me.col_proper_name.Text = "Proper Naming"
        Me.col_proper_name.Width = 250
        '
        'col_price_with_tax
        '
        Me.col_price_with_tax.DisplayIndex = 11
        Me.col_price_with_tax.Text = "Price (With Tax)"
        Me.col_price_with_tax.Width = 100
        '
        'col_tax_category
        '
        Me.col_tax_category.DisplayIndex = 12
        Me.col_tax_category.Text = "Tax Category"
        Me.col_tax_category.Width = 200
        '
        'CMB_lvlpurchasedOrderList
        '
        Me.CMB_lvlpurchasedOrderList.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteToolStripMenuItem, Me.EditToolStripMenuItem, Me.CalculateQtyToolStripMenuItem, Me.PrintPOToolStripMenuItem, Me.ExportPOToExcelToolStripMenuItem, Me.RefreshToolStripMenuItem})
        Me.CMB_lvlpurchasedOrderList.Name = "CMB_lvlpurchasedOrderList"
        Me.CMB_lvlpurchasedOrderList.Size = New System.Drawing.Size(172, 136)
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditToolStripMenuItem1, Me.EditQtyOnlyToolStripMenuItem, Me.EditQtyAuthToolStripMenuItem, Me.EditAllToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'EditToolStripMenuItem1
        '
        Me.EditToolStripMenuItem1.Enabled = False
        Me.EditToolStripMenuItem1.Name = "EditToolStripMenuItem1"
        Me.EditToolStripMenuItem1.Size = New System.Drawing.Size(180, 22)
        Me.EditToolStripMenuItem1.Text = "Edit"
        '
        'EditQtyOnlyToolStripMenuItem
        '
        Me.EditQtyOnlyToolStripMenuItem.Enabled = False
        Me.EditQtyOnlyToolStripMenuItem.Name = "EditQtyOnlyToolStripMenuItem"
        Me.EditQtyOnlyToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.EditQtyOnlyToolStripMenuItem.Text = "Edit Qty Only"
        '
        'EditQtyAuthToolStripMenuItem
        '
        Me.EditQtyAuthToolStripMenuItem.Name = "EditQtyAuthToolStripMenuItem"
        Me.EditQtyAuthToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.EditQtyAuthToolStripMenuItem.Text = "Edit Qty (Auth)"
        Me.EditQtyAuthToolStripMenuItem.Visible = False
        '
        'EditAllToolStripMenuItem
        '
        Me.EditAllToolStripMenuItem.Name = "EditAllToolStripMenuItem"
        Me.EditAllToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.EditAllToolStripMenuItem.Text = "Edit All"
        '
        'CalculateQtyToolStripMenuItem
        '
        Me.CalculateQtyToolStripMenuItem.Name = "CalculateQtyToolStripMenuItem"
        Me.CalculateQtyToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.CalculateQtyToolStripMenuItem.Text = "Calculate qty"
        '
        'PrintPOToolStripMenuItem
        '
        Me.PrintPOToolStripMenuItem.Name = "PrintPOToolStripMenuItem"
        Me.PrintPOToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.PrintPOToolStripMenuItem.Text = "Print P.O"
        '
        'ExportPOToExcelToolStripMenuItem
        '
        Me.ExportPOToExcelToolStripMenuItem.Name = "ExportPOToExcelToolStripMenuItem"
        Me.ExportPOToExcelToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.ExportPOToExcelToolStripMenuItem.Text = "Export PO to Excel"
        '
        'RefreshToolStripMenuItem
        '
        Me.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem"
        Me.RefreshToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.RefreshToolStripMenuItem.Text = "Refresh"
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.Transparent
        Me.btnExit.BackgroundImage = Global.SUPPLY.My.Resources.Resources.close_button
        Me.btnExit.FlatAppearance.BorderSize = 0
        Me.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit.Location = New System.Drawing.Point(1287, 11)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(20, 20)
        Me.btnExit.TabIndex = 360
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'ListJobOrderNo
        '
        Me.ListJobOrderNo.FormattingEnabled = True
        Me.ListJobOrderNo.Location = New System.Drawing.Point(1494, 609)
        Me.ListJobOrderNo.Name = "ListJobOrderNo"
        Me.ListJobOrderNo.Size = New System.Drawing.Size(163, 56)
        Me.ListJobOrderNo.TabIndex = 361
        '
        'gboxSearch
        '
        Me.gboxSearch.BackColor = System.Drawing.Color.Transparent
        Me.gboxSearch.Controls.Add(Me.btnSearch)
        Me.gboxSearch.Controls.Add(Me.txtSearch)
        Me.gboxSearch.Controls.Add(Me.cmbSearchByCategory)
        Me.gboxSearch.Controls.Add(Me.lblSearchByCategory)
        Me.gboxSearch.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gboxSearch.ForeColor = System.Drawing.Color.White
        Me.gboxSearch.Location = New System.Drawing.Point(12, 681)
        Me.gboxSearch.Name = "gboxSearch"
        Me.gboxSearch.Size = New System.Drawing.Size(810, 46)
        Me.gboxSearch.TabIndex = 362
        Me.gboxSearch.TabStop = False
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.Color.Black
        Me.btnSearch.Location = New System.Drawing.Point(659, 10)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(144, 30)
        Me.btnSearch.TabIndex = 3
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'txtSearch
        '
        Me.txtSearch.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(390, 15)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(264, 22)
        Me.txtSearch.TabIndex = 2
        '
        'cmbSearchByCategory
        '
        Me.cmbSearchByCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbSearchByCategory.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSearchByCategory.FormattingEnabled = True
        Me.cmbSearchByCategory.Items.AddRange(New Object() {"Search by PO No.", "Search by RS No.", "Search by PO Date", "Search by Charge To", "Search by Item Description", "Filter by MOnth/Year", "Filter by Date Log", "Filter by Date Log and Price", "Search by Item Name", "Search by Supplier", "View all PO For Print/Printed", "Export By Date Log and Price"})
        Me.cmbSearchByCategory.Location = New System.Drawing.Point(127, 13)
        Me.cmbSearchByCategory.Name = "cmbSearchByCategory"
        Me.cmbSearchByCategory.Size = New System.Drawing.Size(223, 24)
        Me.cmbSearchByCategory.TabIndex = 1
        '
        'lblSearchByCategory
        '
        Me.lblSearchByCategory.AutoSize = True
        Me.lblSearchByCategory.Location = New System.Drawing.Point(7, 17)
        Me.lblSearchByCategory.Name = "lblSearchByCategory"
        Me.lblSearchByCategory.Size = New System.Drawing.Size(51, 15)
        Me.lblSearchByCategory.TabIndex = 0
        Me.lblSearchByCategory.Text = "Search:"
        '
        'dtpSearchPoDATE
        '
        Me.dtpSearchPoDATE.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpSearchPoDATE.Location = New System.Drawing.Point(1494, 722)
        Me.dtpSearchPoDATE.Name = "dtpSearchPoDATE"
        Me.dtpSearchPoDATE.Size = New System.Drawing.Size(239, 22)
        Me.dtpSearchPoDATE.TabIndex = 363
        Me.dtpSearchPoDATE.Visible = False
        '
        'panel_fdate
        '
        Me.panel_fdate.BackColor = System.Drawing.Color.Transparent
        Me.panel_fdate.Controls.Add(Me.btn_panelExt)
        Me.panel_fdate.Controls.Add(Me.lbl_to)
        Me.panel_fdate.Controls.Add(Me.lbl_From)
        Me.panel_fdate.Controls.Add(Me.btn_view)
        Me.panel_fdate.Controls.Add(Me.DTP_dateTo)
        Me.panel_fdate.Controls.Add(Me.DTP_dateFrom)
        Me.panel_fdate.Location = New System.Drawing.Point(606, 333)
        Me.panel_fdate.Name = "panel_fdate"
        Me.panel_fdate.Size = New System.Drawing.Size(290, 195)
        Me.panel_fdate.TabIndex = 364
        '
        'btn_panelExt
        '
        Me.btn_panelExt.BackColor = System.Drawing.Color.Transparent
        Me.btn_panelExt.BackgroundImage = Global.SUPPLY.My.Resources.Resources.close_button
        Me.btn_panelExt.FlatAppearance.BorderSize = 0
        Me.btn_panelExt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btn_panelExt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btn_panelExt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_panelExt.Location = New System.Drawing.Point(252, 14)
        Me.btn_panelExt.Name = "btn_panelExt"
        Me.btn_panelExt.Size = New System.Drawing.Size(20, 20)
        Me.btn_panelExt.TabIndex = 361
        Me.btn_panelExt.UseVisualStyleBackColor = False
        '
        'lbl_to
        '
        Me.lbl_to.AutoSize = True
        Me.lbl_to.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_to.ForeColor = System.Drawing.Color.White
        Me.lbl_to.Location = New System.Drawing.Point(14, 83)
        Me.lbl_to.Name = "lbl_to"
        Me.lbl_to.Size = New System.Drawing.Size(28, 16)
        Me.lbl_to.TabIndex = 14
        Me.lbl_to.Text = "TO"
        '
        'lbl_From
        '
        Me.lbl_From.AutoSize = True
        Me.lbl_From.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_From.ForeColor = System.Drawing.Color.White
        Me.lbl_From.Location = New System.Drawing.Point(14, 19)
        Me.lbl_From.Name = "lbl_From"
        Me.lbl_From.Size = New System.Drawing.Size(50, 16)
        Me.lbl_From.TabIndex = 13
        Me.lbl_From.Text = "FROM"
        '
        'btn_view
        '
        Me.btn_view.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_view.Location = New System.Drawing.Point(199, 150)
        Me.btn_view.Name = "btn_view"
        Me.btn_view.Size = New System.Drawing.Size(73, 30)
        Me.btn_view.TabIndex = 12
        Me.btn_view.Text = "View"
        Me.btn_view.UseVisualStyleBackColor = True
        '
        'DTP_dateTo
        '
        Me.DTP_dateTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_dateTo.Location = New System.Drawing.Point(17, 112)
        Me.DTP_dateTo.Name = "DTP_dateTo"
        Me.DTP_dateTo.Size = New System.Drawing.Size(255, 22)
        Me.DTP_dateTo.TabIndex = 11
        '
        'DTP_dateFrom
        '
        Me.DTP_dateFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_dateFrom.Location = New System.Drawing.Point(17, 48)
        Me.DTP_dateFrom.Name = "DTP_dateFrom"
        Me.DTP_dateFrom.Size = New System.Drawing.Size(255, 22)
        Me.DTP_dateFrom.TabIndex = 10
        '
        'Timer_panelmvemEnt
        '
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Location = New System.Drawing.Point(641, 731)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(144, 25)
        Me.Button1.TabIndex = 365
        Me.Button1.Text = "Search"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'Panel3
        '
        Me.Panel3.BackgroundImage = CType(resources.GetObject("Panel3.BackgroundImage"), System.Drawing.Image)
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.lblRecords)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.Button2)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.PictureBox2)
        Me.Panel3.Controls.Add(Me.ProgressBar1)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Location = New System.Drawing.Point(22, 56)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(677, 271)
        Me.Panel3.TabIndex = 419
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
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.OliveDrab
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.ForeColor = System.Drawing.Color.Transparent
        Me.Button2.Location = New System.Drawing.Point(597, 242)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 420
        Me.Button2.Text = "Abort"
        Me.Button2.UseVisualStyleBackColor = False
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
        'BW_search
        '
        '
        'BW_export_to_excel_by_dateLog_price
        '
        '
        'FPurchasedOrderList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SUPPLY.My.Resources.Resources.bg_line
        Me.ClientSize = New System.Drawing.Size(1371, 756)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.panel_fdate)
        Me.Controls.Add(Me.gboxSearch)
        Me.Controls.Add(Me.ListJobOrderNo)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.lvlpurchasedOrderList)
        Me.Controls.Add(Me.dtpSearchPoDATE)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.pboxHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FPurchasedOrderList"
        Me.Padding = New System.Windows.Forms.Padding(9)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "FPurchasedOrderList"
        CType(Me.pboxHeader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMB_lvlpurchasedOrderList.ResumeLayout(False)
        Me.gboxSearch.ResumeLayout(False)
        Me.gboxSearch.PerformLayout()
        Me.panel_fdate.ResumeLayout(False)
        Me.panel_fdate.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents pboxHeader As System.Windows.Forms.PictureBox
    Friend WithEvents lvlpurchasedOrderList As System.Windows.Forms.ListView
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ListJobOrderNo As System.Windows.Forms.ListBox
    Friend WithEvents gboxSearch As System.Windows.Forms.GroupBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents cmbSearchByCategory As System.Windows.Forms.ComboBox
    Friend WithEvents lblSearchByCategory As System.Windows.Forms.Label
    Friend WithEvents dtpSearchPoDATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents panel_fdate As System.Windows.Forms.Panel
    Friend WithEvents lbl_to As System.Windows.Forms.Label
    Friend WithEvents lbl_From As System.Windows.Forms.Label
    Friend WithEvents btn_view As System.Windows.Forms.Button
    Friend WithEvents DTP_dateTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTP_dateFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents btn_panelExt As System.Windows.Forms.Button
    Friend WithEvents Timer_panelmvemEnt As System.Windows.Forms.Timer
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader14 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader15 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader16 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader17 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader18 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader19 As System.Windows.Forms.ColumnHeader
    Friend WithEvents CMB_lvlpurchasedOrderList As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents col_rs_id As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader21 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader22 As System.Windows.Forms.ColumnHeader
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents col_po_id As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader24 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader25 As ColumnHeader
    Friend WithEvents CalculateQtyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Button1 As Button
    Friend WithEvents col_print_status As ColumnHeader
    Friend WithEvents PrintPOToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ColumnHeader27 As ColumnHeader
    Friend WithEvents ColumnHeader28 As ColumnHeader
    Friend WithEvents ColumnHeader29 As ColumnHeader
    Friend WithEvents EditToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents EditQtyOnlyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Panel3 As Panel
    Friend WithEvents lblRecords As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents Label7 As Label
    Friend WithEvents BW_search As System.ComponentModel.BackgroundWorker
    Friend WithEvents ExportPOToExcelToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ColumnHeader30 As ColumnHeader
    Friend WithEvents col_type_of_request As ColumnHeader
    Friend WithEvents col_user_update_log As ColumnHeader
    Friend WithEvents ColumnHeader31 As ColumnHeader
    Friend WithEvents BW_export_to_excel_by_dateLog_price As System.ComponentModel.BackgroundWorker
    Friend WithEvents EditQtyAuthToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditAllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents col_proper_name As ColumnHeader
    Friend WithEvents col_price_with_tax As ColumnHeader
    Friend WithEvents col_tax_category As ColumnHeader
    Friend WithEvents RefreshToolStripMenuItem As ToolStripMenuItem
End Class
