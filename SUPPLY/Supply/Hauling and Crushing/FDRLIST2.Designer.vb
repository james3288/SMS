<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FDRLIST2
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.loadingPanel = New System.Windows.Forms.Panel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnTransaction = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.othersColor = New System.Windows.Forms.Panel()
        Me.inColor = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.outWithoutDrColor = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.outColor = New System.Windows.Forms.Panel()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lvl_drList = New System.Windows.Forms.ListView()
        Me.col_dr_id = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_dr_no = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_rs_no = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_dr_date = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_item_name = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_source = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_qty_in_others = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_unit = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_concession = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_driver = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_requestor = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_address = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_checked_by = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_received_by = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_dr_info_id = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_rs_id = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_inout = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_time_from = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_time_to = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_ws_no_po_no = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_par_rr_item_id = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_remarks = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_supplier = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_user = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_plateno = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_rrno = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_qty_out = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_price = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_total_amount = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_item_desc = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_date_request = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_dr_option = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_row = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_withdrawn_by = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_reported_by = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_wh_id = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_source2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_dateSubmitted = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_wh_options = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_quarry = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_properNames = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_projectSite = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_specific_location = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_zoning_price = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SearchByToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UnselectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OperatorDriverToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PriceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReceivedByToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsessionTicketToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SupplierToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DRNOToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PlateNOToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DRWSDateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemarksToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CheckedByToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SourceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RequestorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WSNOToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WithdrawnByToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StockpileQuaryCodeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DateSubmittedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DateLogToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QTYToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DRWHTOWHToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CalculateQtyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.INOTHERSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OUTToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GenerateReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BW_edit_wh_to_wh = New System.ComponentModel.BackgroundWorker()
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.loadingPanel.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.btnExit)
        Me.Panel1.Controls.Add(Me.loadingPanel)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1401, 59)
        Me.Panel1.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Controls.Add(Me.PictureBox2)
        Me.Panel4.Location = New System.Drawing.Point(862, 6)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(453, 44)
        Me.Panel4.TabIndex = 425
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Bombardier", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.SpringGreen
        Me.Label1.Location = New System.Drawing.Point(47, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(361, 30)
        Me.Label1.TabIndex = 422
        Me.Label1.Text = "SUMMARY OF HAULED AGGREGATES"
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.PictureBox2.Image = Global.SUPPLY.My.Resources.Resources.reg_button
        Me.PictureBox2.Location = New System.Drawing.Point(5, 1)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(39, 40)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 423
        Me.PictureBox2.TabStop = False
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
        Me.btnExit.Location = New System.Drawing.Point(1338, 17)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(22, 20)
        Me.btnExit.TabIndex = 424
        Me.btnExit.UseVisualStyleBackColor = False
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
        Me.Panel2.Controls.Add(Me.btnTransaction)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.othersColor)
        Me.Panel2.Controls.Add(Me.inColor)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.outWithoutDrColor)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.outColor)
        Me.Panel2.Controls.Add(Me.btnSearch)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 699)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1401, 44)
        Me.Panel2.TabIndex = 1
        '
        'btnTransaction
        '
        Me.btnTransaction.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTransaction.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnTransaction.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTransaction.Font = New System.Drawing.Font("Bombardier", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTransaction.Location = New System.Drawing.Point(845, 5)
        Me.btnTransaction.Name = "btnTransaction"
        Me.btnTransaction.Size = New System.Drawing.Size(263, 35)
        Me.btnTransaction.TabIndex = 372
        Me.btnTransaction.Text = "CREATE TRANSACTION"
        Me.btnTransaction.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(493, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 16)
        Me.Label5.TabIndex = 371
        Me.Label5.Text = "others (DR)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(403, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 16)
        Me.Label4.TabIndex = 369
        Me.Label4.Text = "IN (DR)"
        '
        'othersColor
        '
        Me.othersColor.Location = New System.Drawing.Point(474, 16)
        Me.othersColor.Name = "othersColor"
        Me.othersColor.Size = New System.Drawing.Size(15, 16)
        Me.othersColor.TabIndex = 370
        '
        'inColor
        '
        Me.inColor.Location = New System.Drawing.Point(384, 15)
        Me.inColor.Name = "inColor"
        Me.inColor.Size = New System.Drawing.Size(15, 16)
        Me.inColor.TabIndex = 368
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(228, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(142, 16)
        Me.Label3.TabIndex = 367
        Me.Label3.Text = "withdrawal (without DR)"
        '
        'outWithoutDrColor
        '
        Me.outWithoutDrColor.Location = New System.Drawing.Point(209, 15)
        Me.outWithoutDrColor.Name = "outWithoutDrColor"
        Me.outWithoutDrColor.Size = New System.Drawing.Size(15, 16)
        Me.outWithoutDrColor.TabIndex = 366
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(69, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(124, 16)
        Me.Label2.TabIndex = 365
        Me.Label2.Text = "withdrawal (with DR)"
        '
        'outColor
        '
        Me.outColor.Location = New System.Drawing.Point(50, 15)
        Me.outColor.Name = "outColor"
        Me.outColor.Size = New System.Drawing.Size(15, 16)
        Me.outColor.TabIndex = 364
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.Font = New System.Drawing.Font("Bombardier", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(1127, 5)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(263, 35)
        Me.btnSearch.TabIndex = 363
        Me.btnSearch.Text = "SEARCH"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.lvl_drList)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 59)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1401, 640)
        Me.Panel3.TabIndex = 2
        '
        'lvl_drList
        '
        Me.lvl_drList.CheckBoxes = True
        Me.lvl_drList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.col_dr_id, Me.col_dr_no, Me.col_rs_no, Me.col_dr_date, Me.col_item_name, Me.col_source, Me.col_qty_in_others, Me.col_unit, Me.col_concession, Me.col_driver, Me.col_requestor, Me.col_address, Me.col_checked_by, Me.col_received_by, Me.col_dr_info_id, Me.col_rs_id, Me.col_inout, Me.col_time_from, Me.col_time_to, Me.col_ws_no_po_no, Me.col_par_rr_item_id, Me.col_remarks, Me.col_supplier, Me.col_user, Me.col_plateno, Me.col_rrno, Me.col_qty_out, Me.col_price, Me.col_total_amount, Me.col_item_desc, Me.col_date_request, Me.col_dr_option, Me.col_row, Me.col_withdrawn_by, Me.col_reported_by, Me.col_wh_id, Me.col_source2, Me.col_dateSubmitted, Me.col_wh_options, Me.col_quarry, Me.col_properNames, Me.col_projectSite, Me.col_specific_location, Me.col_zoning_price})
        Me.lvl_drList.ContextMenuStrip = Me.ContextMenuStrip1
        Me.lvl_drList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvl_drList.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvl_drList.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lvl_drList.FullRowSelect = True
        Me.lvl_drList.HideSelection = False
        Me.lvl_drList.Location = New System.Drawing.Point(0, 0)
        Me.lvl_drList.Name = "lvl_drList"
        Me.lvl_drList.Size = New System.Drawing.Size(1401, 640)
        Me.lvl_drList.TabIndex = 6
        Me.lvl_drList.UseCompatibleStateImageBehavior = False
        Me.lvl_drList.View = System.Windows.Forms.View.Details
        '
        'col_dr_id
        '
        Me.col_dr_id.Text = "dr_id"
        Me.col_dr_id.Width = 50
        '
        'col_dr_no
        '
        Me.col_dr_no.Text = "DR No"
        Me.col_dr_no.Width = 200
        '
        'col_rs_no
        '
        Me.col_rs_no.Text = "RS No."
        Me.col_rs_no.Width = 150
        '
        'col_dr_date
        '
        Me.col_dr_date.Text = "DR Date/ Date Served"
        Me.col_dr_date.Width = 200
        '
        'col_item_name
        '
        Me.col_item_name.Text = "Item Name"
        Me.col_item_name.Width = 200
        '
        'col_source
        '
        Me.col_source.Text = "Classification"
        Me.col_source.Width = 200
        '
        'col_qty_in_others
        '
        Me.col_qty_in_others.Text = "Qty IN/OTHERS"
        Me.col_qty_in_others.Width = 200
        '
        'col_unit
        '
        Me.col_unit.Text = "Unit"
        Me.col_unit.Width = 200
        '
        'col_concession
        '
        Me.col_concession.Text = "Concession Ticket"
        Me.col_concession.Width = 200
        '
        'col_driver
        '
        Me.col_driver.Text = "Driver"
        Me.col_driver.Width = 200
        '
        'col_requestor
        '
        Me.col_requestor.Text = "Requestor"
        Me.col_requestor.Width = 200
        '
        'col_address
        '
        Me.col_address.Text = "Address"
        Me.col_address.Width = 0
        '
        'col_checked_by
        '
        Me.col_checked_by.Text = "Checked By"
        Me.col_checked_by.Width = 200
        '
        'col_received_by
        '
        Me.col_received_by.Text = "Received By"
        Me.col_received_by.Width = 200
        '
        'col_dr_info_id
        '
        Me.col_dr_info_id.Text = "dr_info_id"
        Me.col_dr_info_id.Width = 0
        '
        'col_rs_id
        '
        Me.col_rs_id.Text = "rs_id"
        Me.col_rs_id.Width = 0
        '
        'col_inout
        '
        Me.col_inout.Text = "IN_OUT"
        Me.col_inout.Width = 200
        '
        'col_time_from
        '
        Me.col_time_from.Text = "Time From"
        Me.col_time_from.Width = 0
        '
        'col_time_to
        '
        Me.col_time_to.Text = "Time To"
        Me.col_time_to.Width = 0
        '
        'col_ws_no_po_no
        '
        Me.col_ws_no_po_no.Text = "WS NO./PO NO."
        Me.col_ws_no_po_no.Width = 150
        '
        'col_par_rr_item_id
        '
        Me.col_par_rr_item_id.Text = "par_rr_item_id"
        Me.col_par_rr_item_id.Width = 50
        '
        'col_remarks
        '
        Me.col_remarks.Text = "Remarks"
        Me.col_remarks.Width = 200
        '
        'col_supplier
        '
        Me.col_supplier.Text = "Supplier"
        Me.col_supplier.Width = 200
        '
        'col_user
        '
        Me.col_user.Text = "User"
        Me.col_user.Width = 250
        '
        'col_plateno
        '
        Me.col_plateno.Text = "Plate No."
        Me.col_plateno.Width = 150
        '
        'col_rrno
        '
        Me.col_rrno.Text = "RR NO."
        Me.col_rrno.Width = 200
        '
        'col_qty_out
        '
        Me.col_qty_out.Text = "Qty OUT"
        Me.col_qty_out.Width = 100
        '
        'col_price
        '
        Me.col_price.Text = "Price"
        Me.col_price.Width = 150
        '
        'col_total_amount
        '
        Me.col_total_amount.Text = "Total Amount"
        Me.col_total_amount.Width = 150
        '
        'col_item_desc
        '
        Me.col_item_desc.Text = "Item Description"
        Me.col_item_desc.Width = 200
        '
        'col_date_request
        '
        Me.col_date_request.Text = "Date Request"
        Me.col_date_request.Width = 150
        '
        'col_dr_option
        '
        Me.col_dr_option.Text = "DR OPTION"
        '
        'col_row
        '
        Me.col_row.Text = "row #"
        '
        'col_withdrawn_by
        '
        Me.col_withdrawn_by.Text = "Withdrawn By"
        Me.col_withdrawn_by.Width = 150
        '
        'col_reported_by
        '
        Me.col_reported_by.Text = "Reported By"
        Me.col_reported_by.Width = 200
        '
        'col_wh_id
        '
        Me.col_wh_id.Text = "wh_id"
        '
        'col_source2
        '
        Me.col_source2.Text = "Stockpile"
        Me.col_source2.Width = 200
        '
        'col_dateSubmitted
        '
        Me.col_dateSubmitted.DisplayIndex = 38
        Me.col_dateSubmitted.Text = "Date Submitted"
        Me.col_dateSubmitted.Width = 180
        '
        'col_wh_options
        '
        Me.col_wh_options.DisplayIndex = 39
        Me.col_wh_options.Text = "WH OPTIONS"
        Me.col_wh_options.Width = 100
        '
        'col_quarry
        '
        Me.col_quarry.DisplayIndex = 37
        Me.col_quarry.Text = "Quarry Code"
        Me.col_quarry.Width = 200
        '
        'col_properNames
        '
        Me.col_properNames.Text = "Proper Names"
        Me.col_properNames.Width = 200
        '
        'col_projectSite
        '
        Me.col_projectSite.Text = "Source"
        Me.col_projectSite.Width = 100
        '
        'col_specific_location
        '
        Me.col_specific_location.Text = "Specific Location"
        Me.col_specific_location.Width = 200
        '
        'col_zoning_price
        '
        Me.col_zoning_price.Text = "Zoning Area Price"
        Me.col_zoning_price.Width = 150
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SearchByToolStripMenuItem, Me.SelectToolStripMenuItem, Me.EditToolStripMenuItem, Me.CalculateQtyToolStripMenuItem, Me.GenerateReportToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(181, 158)
        '
        'SearchByToolStripMenuItem
        '
        Me.SearchByToolStripMenuItem.Name = "SearchByToolStripMenuItem"
        Me.SearchByToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.SearchByToolStripMenuItem.Text = "Search By"
        '
        'SelectToolStripMenuItem
        '
        Me.SelectToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AllToolStripMenuItem, Me.UnselectAllToolStripMenuItem})
        Me.SelectToolStripMenuItem.Name = "SelectToolStripMenuItem"
        Me.SelectToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.SelectToolStripMenuItem.Text = "Select"
        '
        'AllToolStripMenuItem
        '
        Me.AllToolStripMenuItem.Name = "AllToolStripMenuItem"
        Me.AllToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.AllToolStripMenuItem.Text = "Select All"
        '
        'UnselectAllToolStripMenuItem
        '
        Me.UnselectAllToolStripMenuItem.Name = "UnselectAllToolStripMenuItem"
        Me.UnselectAllToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.UnselectAllToolStripMenuItem.Text = "Unselect All"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OperatorDriverToolStripMenuItem, Me.PriceToolStripMenuItem, Me.ReceivedByToolStripMenuItem, Me.ConsessionTicketToolStripMenuItem, Me.SupplierToolStripMenuItem, Me.DRNOToolStripMenuItem, Me.PlateNOToolStripMenuItem, Me.DRWSDateToolStripMenuItem, Me.RemarksToolStripMenuItem, Me.CheckedByToolStripMenuItem, Me.SourceToolStripMenuItem, Me.RequestorToolStripMenuItem, Me.WSNOToolStripMenuItem, Me.WithdrawnByToolStripMenuItem, Me.StockpileQuaryCodeToolStripMenuItem, Me.DateSubmittedToolStripMenuItem, Me.DateLogToolStripMenuItem, Me.QTYToolStripMenuItem, Me.DRWHTOWHToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.EditToolStripMenuItem.Text = "Edit DR"
        '
        'OperatorDriverToolStripMenuItem
        '
        Me.OperatorDriverToolStripMenuItem.Name = "OperatorDriverToolStripMenuItem"
        Me.OperatorDriverToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.OperatorDriverToolStripMenuItem.Text = "> Operator/Driver"
        '
        'PriceToolStripMenuItem
        '
        Me.PriceToolStripMenuItem.Name = "PriceToolStripMenuItem"
        Me.PriceToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.PriceToolStripMenuItem.Text = "> Price"
        '
        'ReceivedByToolStripMenuItem
        '
        Me.ReceivedByToolStripMenuItem.Name = "ReceivedByToolStripMenuItem"
        Me.ReceivedByToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.ReceivedByToolStripMenuItem.Text = "> Received By"
        '
        'ConsessionTicketToolStripMenuItem
        '
        Me.ConsessionTicketToolStripMenuItem.Name = "ConsessionTicketToolStripMenuItem"
        Me.ConsessionTicketToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.ConsessionTicketToolStripMenuItem.Text = "> Concession Ticket"
        '
        'SupplierToolStripMenuItem
        '
        Me.SupplierToolStripMenuItem.Name = "SupplierToolStripMenuItem"
        Me.SupplierToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.SupplierToolStripMenuItem.Text = "> Supplier"
        '
        'DRNOToolStripMenuItem
        '
        Me.DRNOToolStripMenuItem.Name = "DRNOToolStripMenuItem"
        Me.DRNOToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.DRNOToolStripMenuItem.Text = "> DR NO."
        '
        'PlateNOToolStripMenuItem
        '
        Me.PlateNOToolStripMenuItem.Name = "PlateNOToolStripMenuItem"
        Me.PlateNOToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.PlateNOToolStripMenuItem.Text = "> Plate NO."
        '
        'DRWSDateToolStripMenuItem
        '
        Me.DRWSDateToolStripMenuItem.Name = "DRWSDateToolStripMenuItem"
        Me.DRWSDateToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.DRWSDateToolStripMenuItem.Text = "> DR/WS Date"
        '
        'RemarksToolStripMenuItem
        '
        Me.RemarksToolStripMenuItem.Name = "RemarksToolStripMenuItem"
        Me.RemarksToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.RemarksToolStripMenuItem.Text = "> Remarks"
        '
        'CheckedByToolStripMenuItem
        '
        Me.CheckedByToolStripMenuItem.Name = "CheckedByToolStripMenuItem"
        Me.CheckedByToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.CheckedByToolStripMenuItem.Text = "> Checked By"
        '
        'SourceToolStripMenuItem
        '
        Me.SourceToolStripMenuItem.Name = "SourceToolStripMenuItem"
        Me.SourceToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.SourceToolStripMenuItem.Text = "> Source"
        '
        'RequestorToolStripMenuItem
        '
        Me.RequestorToolStripMenuItem.Name = "RequestorToolStripMenuItem"
        Me.RequestorToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.RequestorToolStripMenuItem.Text = "> Requestor"
        '
        'WSNOToolStripMenuItem
        '
        Me.WSNOToolStripMenuItem.Name = "WSNOToolStripMenuItem"
        Me.WSNOToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.WSNOToolStripMenuItem.Text = "> WS NO"
        '
        'WithdrawnByToolStripMenuItem
        '
        Me.WithdrawnByToolStripMenuItem.Name = "WithdrawnByToolStripMenuItem"
        Me.WithdrawnByToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.WithdrawnByToolStripMenuItem.Text = "> Withdrawn By"
        '
        'StockpileQuaryCodeToolStripMenuItem
        '
        Me.StockpileQuaryCodeToolStripMenuItem.Name = "StockpileQuaryCodeToolStripMenuItem"
        Me.StockpileQuaryCodeToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.StockpileQuaryCodeToolStripMenuItem.Text = "> Stockpile/Quary Code"
        '
        'DateSubmittedToolStripMenuItem
        '
        Me.DateSubmittedToolStripMenuItem.Name = "DateSubmittedToolStripMenuItem"
        Me.DateSubmittedToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.DateSubmittedToolStripMenuItem.Text = "> Date Submitted"
        '
        'DateLogToolStripMenuItem
        '
        Me.DateLogToolStripMenuItem.Name = "DateLogToolStripMenuItem"
        Me.DateLogToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.DateLogToolStripMenuItem.Text = "> Date Log"
        '
        'QTYToolStripMenuItem
        '
        Me.QTYToolStripMenuItem.Name = "QTYToolStripMenuItem"
        Me.QTYToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.QTYToolStripMenuItem.Text = "> QTY"
        '
        'DRWHTOWHToolStripMenuItem
        '
        Me.DRWHTOWHToolStripMenuItem.Name = "DRWHTOWHToolStripMenuItem"
        Me.DRWHTOWHToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.DRWHTOWHToolStripMenuItem.Text = "> DR (WH TO WH)"
        '
        'CalculateQtyToolStripMenuItem
        '
        Me.CalculateQtyToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.INOTHERSToolStripMenuItem, Me.OUTToolStripMenuItem})
        Me.CalculateQtyToolStripMenuItem.Name = "CalculateQtyToolStripMenuItem"
        Me.CalculateQtyToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.CalculateQtyToolStripMenuItem.Text = "Calculate Qty"
        '
        'INOTHERSToolStripMenuItem
        '
        Me.INOTHERSToolStripMenuItem.Name = "INOTHERSToolStripMenuItem"
        Me.INOTHERSToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.INOTHERSToolStripMenuItem.Text = "> IN/OTHERS"
        '
        'OUTToolStripMenuItem
        '
        Me.OUTToolStripMenuItem.Name = "OUTToolStripMenuItem"
        Me.OUTToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.OUTToolStripMenuItem.Text = "> OUT"
        '
        'GenerateReportToolStripMenuItem
        '
        Me.GenerateReportToolStripMenuItem.Name = "GenerateReportToolStripMenuItem"
        Me.GenerateReportToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.GenerateReportToolStripMenuItem.Text = "Generate Report"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'BW_edit_wh_to_wh
        '
        '
        'FDRLIST2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SUPPLY.My.Resources.Resources.bg_line
        Me.ClientSize = New System.Drawing.Size(1401, 743)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FDRLIST2"
        Me.Text = "FDRLIST2"
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
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents loadingPanel As Panel
    Friend WithEvents Label12 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lvl_drList As ListView
    Friend WithEvents col_dr_id As ColumnHeader
    Friend WithEvents col_dr_no As ColumnHeader
    Friend WithEvents col_rs_no As ColumnHeader
    Friend WithEvents col_dr_date As ColumnHeader
    Friend WithEvents col_item_name As ColumnHeader
    Friend WithEvents col_source As ColumnHeader
    Friend WithEvents col_qty_in_others As ColumnHeader
    Friend WithEvents col_unit As ColumnHeader
    Friend WithEvents col_concession As ColumnHeader
    Friend WithEvents col_driver As ColumnHeader
    Friend WithEvents col_requestor As ColumnHeader
    Friend WithEvents col_address As ColumnHeader
    Friend WithEvents col_checked_by As ColumnHeader
    Friend WithEvents col_received_by As ColumnHeader
    Friend WithEvents col_dr_info_id As ColumnHeader
    Friend WithEvents col_rs_id As ColumnHeader
    Friend WithEvents col_inout As ColumnHeader
    Friend WithEvents col_time_from As ColumnHeader
    Friend WithEvents col_time_to As ColumnHeader
    Friend WithEvents col_ws_no_po_no As ColumnHeader
    Friend WithEvents col_par_rr_item_id As ColumnHeader
    Friend WithEvents col_remarks As ColumnHeader
    Friend WithEvents col_supplier As ColumnHeader
    Friend WithEvents col_user As ColumnHeader
    Friend WithEvents col_plateno As ColumnHeader
    Friend WithEvents col_rrno As ColumnHeader
    Friend WithEvents col_qty_out As ColumnHeader
    Friend WithEvents col_price As ColumnHeader
    Friend WithEvents col_total_amount As ColumnHeader
    Friend WithEvents col_item_desc As ColumnHeader
    Friend WithEvents col_date_request As ColumnHeader
    Friend WithEvents col_dr_option As ColumnHeader
    Friend WithEvents col_row As ColumnHeader
    Friend WithEvents col_withdrawn_by As ColumnHeader
    Friend WithEvents col_reported_by As ColumnHeader
    Friend WithEvents col_wh_id As ColumnHeader
    Friend WithEvents col_source2 As ColumnHeader
    Friend WithEvents col_dateSubmitted As ColumnHeader
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents SearchByToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SelectToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UnselectAllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OperatorDriverToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PriceToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReceivedByToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ConsessionTicketToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SupplierToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DRNOToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PlateNOToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DRWSDateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RemarksToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CheckedByToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SourceToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RequestorToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WSNOToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WithdrawnByToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StockpileQuaryCodeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DateSubmittedToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DateLogToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents QTYToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CalculateQtyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents INOTHERSToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OUTToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GenerateReportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnExit As Button
    Friend WithEvents Panel4 As Panel
    Friend WithEvents DRWHTOWHToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BW_edit_wh_to_wh As System.ComponentModel.BackgroundWorker
    Friend WithEvents btnSearch As Button
    Friend WithEvents col_wh_options As ColumnHeader
    Friend WithEvents col_quarry As ColumnHeader
    Friend WithEvents Label3 As Label
    Friend WithEvents outWithoutDrColor As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents outColor As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents inColor As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents othersColor As Panel
    Friend WithEvents col_properNames As ColumnHeader
    Friend WithEvents col_projectSite As ColumnHeader
    Friend WithEvents col_specific_location As ColumnHeader
    Friend WithEvents col_zoning_price As ColumnHeader
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnTransaction As Button
End Class
