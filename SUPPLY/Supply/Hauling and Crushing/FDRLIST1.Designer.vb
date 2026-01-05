<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FDRLIST1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FDRLIST1))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblWait = New System.Windows.Forms.Label()
        Me.ProgressBar2 = New System.Windows.Forms.ProgressBar()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpto = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpfrom = New System.Windows.Forms.DateTimePicker()
        Me.cmbSortBy = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbEnableDateRange = New System.Windows.Forms.ComboBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtItems = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbINOUT = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtItemDesc = New System.Windows.Forms.TextBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lblRecords = New System.Windows.Forms.Label()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Label7 = New System.Windows.Forms.Label()
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
        Me.CMS_lvlDRList = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditInfoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditDescriptionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CalculateQtyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.INToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OUTToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SampleDeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SortByToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WSNOToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WSNOToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.GenerateReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CheckSelectedToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.UncheckSelectedsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UnselectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditPriceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExemptionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditOperatorDriverToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PriceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReceivedByToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DRNOToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PlateNOToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SupplierToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DRDateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemarksToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CheckedByToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SourceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RequestorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WSNOToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.WithdrawnByToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DRWHTOWHToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StockpileQuaryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DateSubmittedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DateLogToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.INOUTToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QTYToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RSIDToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportToExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemovedReportedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SortToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ItemDescToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SourceToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.OperatorDriverToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SupplierToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DRDateServedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PlateNoToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.RequestorToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UnreportedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemovedSelectedItemsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer3 = New System.Windows.Forms.Timer(Me.components)
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorker2 = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorker3 = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorker4 = New System.ComponentModel.BackgroundWorker()
        Me.bw_search_without_rs_dr = New System.ComponentModel.BackgroundWorker()
        Me.bw_check_if_done = New System.ComponentModel.BackgroundWorker()
        Me.bw_display = New System.ComponentModel.BackgroundWorker()
        Me.BW_edit_wh_to_wh = New System.ComponentModel.BackgroundWorker()
        Me.BW_Loading = New System.ComponentModel.BackgroundWorker()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMS_lvlDRList.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = Global.SUPPLY.My.Resources.Resources.header_line1
        Me.Panel1.Controls.Add(Me.lblWait)
        Me.Panel1.Controls.Add(Me.ProgressBar2)
        Me.Panel1.Controls.Add(Me.btnExit)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1401, 37)
        Me.Panel1.TabIndex = 0
        '
        'lblWait
        '
        Me.lblWait.AutoSize = True
        Me.lblWait.BackColor = System.Drawing.Color.Transparent
        Me.lblWait.Font = New System.Drawing.Font("Arial Narrow", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWait.ForeColor = System.Drawing.Color.Yellow
        Me.lblWait.Location = New System.Drawing.Point(76, 12)
        Me.lblWait.Name = "lblWait"
        Me.lblWait.Size = New System.Drawing.Size(107, 23)
        Me.lblWait.TabIndex = 420
        Me.lblWait.Text = "Please wait..."
        Me.lblWait.Visible = False
        '
        'ProgressBar2
        '
        Me.ProgressBar2.Location = New System.Drawing.Point(263, 19)
        Me.ProgressBar2.Name = "ProgressBar2"
        Me.ProgressBar2.Size = New System.Drawing.Size(1092, 10)
        Me.ProgressBar2.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.ProgressBar2.TabIndex = 418
        Me.ProgressBar2.Visible = False
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
        Me.btnExit.Location = New System.Drawing.Point(1373, 11)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(20, 20)
        Me.btnExit.TabIndex = 388
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackgroundImage = Global.SUPPLY.My.Resources.Resources.bg_line
        Me.Panel2.Controls.Add(Me.GroupBox3)
        Me.Panel2.Controls.Add(Me.GroupBox2)
        Me.Panel2.Controls.Add(Me.cmbSortBy)
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 37)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(263, 659)
        Me.Panel2.TabIndex = 1
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.PictureBox1)
        Me.GroupBox3.Controls.Add(Me.PictureBox4)
        Me.GroupBox3.Font = New System.Drawing.Font("Arial Black", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.Yellow
        Me.GroupBox3.Location = New System.Drawing.Point(7, 439)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(248, 100)
        Me.GroupBox3.TabIndex = 14
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "COLOR LEGEND"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(39, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(201, 39)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "WITHDRAWAL WITHOUT DR (OUT)"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(39, 69)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(25, 16)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "DR"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.LightGreen
        Me.PictureBox1.Location = New System.Drawing.Point(13, 31)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(20, 17)
        Me.PictureBox1.TabIndex = 10
        Me.PictureBox1.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.LightYellow
        Me.PictureBox4.Location = New System.Drawing.Point(13, 67)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(20, 17)
        Me.PictureBox4.TabIndex = 12
        Me.PictureBox4.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackgroundImage = Global.SUPPLY.My.Resources.Resources.bg_line
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.dtpto)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.dtpfrom)
        Me.GroupBox2.Enabled = False
        Me.GroupBox2.Location = New System.Drawing.Point(7, 245)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(248, 108)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(7, 59)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(26, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "To:"
        '
        'dtpto
        '
        Me.dtpto.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpto.Location = New System.Drawing.Point(9, 76)
        Me.dtpto.Name = "dtpto"
        Me.dtpto.Size = New System.Drawing.Size(231, 20)
        Me.dtpto.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(6, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 16)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "From:"
        '
        'dtpfrom
        '
        Me.dtpfrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfrom.Location = New System.Drawing.Point(9, 35)
        Me.dtpfrom.Name = "dtpfrom"
        Me.dtpfrom.Size = New System.Drawing.Size(231, 20)
        Me.dtpfrom.TabIndex = 5
        '
        'cmbSortBy
        '
        Me.cmbSortBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSortBy.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSortBy.FormattingEnabled = True
        Me.cmbSortBy.Items.AddRange(New Object() {"RS NO", "DR NO", "WS NO", "DRIVER", "PLATE NO", "UNIT", "ITEM DESCRIPTION", "CONSESSION TICKET", "REQUESTOR", "SOURCE", "REMARKS", "SUPPLIER", "DATE RANGE", "WH_ID", "WITHOUT RS AND DR", "IN/OUT"})
        Me.cmbSortBy.Location = New System.Drawing.Point(7, 7)
        Me.cmbSortBy.Name = "cmbSortBy"
        Me.cmbSortBy.Size = New System.Drawing.Size(248, 26)
        Me.cmbSortBy.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.BackgroundImage = Global.SUPPLY.My.Resources.Resources.bg_line
        Me.GroupBox1.Controls.Add(Me.cmbEnableDateRange)
        Me.GroupBox1.Controls.Add(Me.btnSearch)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtItems)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cmbINOUT)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtItemDesc)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 39)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(248, 371)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        '
        'cmbEnableDateRange
        '
        Me.cmbEnableDateRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEnableDateRange.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEnableDateRange.FormattingEnabled = True
        Me.cmbEnableDateRange.Items.AddRange(New Object() {"ENABLE DATE RANGE", "DISABLE DATE RANGE"})
        Me.cmbEnableDateRange.Location = New System.Drawing.Point(5, 175)
        Me.cmbEnableDateRange.Name = "cmbEnableDateRange"
        Me.cmbEnableDateRange.Size = New System.Drawing.Size(235, 26)
        Me.cmbEnableDateRange.TabIndex = 9
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(6, 323)
        Me.btnSearch.Margin = New System.Windows.Forms.Padding(170, 3, 5, 3)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(235, 33)
        Me.btnSearch.TabIndex = 7
        Me.btnSearch.Text = "Search (ENTER)"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(5, 57)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 16)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Items:"
        '
        'txtItems
        '
        Me.txtItems.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItems.Location = New System.Drawing.Point(6, 76)
        Me.txtItems.Name = "txtItems"
        Me.txtItems.Size = New System.Drawing.Size(235, 26)
        Me.txtItems.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(6, 105)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 16)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "In/Out:"
        '
        'cmbINOUT
        '
        Me.cmbINOUT.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbINOUT.FormattingEnabled = True
        Me.cmbINOUT.Items.AddRange(New Object() {"IN", "OUT", "OTHERS"})
        Me.cmbINOUT.Location = New System.Drawing.Point(6, 124)
        Me.cmbINOUT.Name = "cmbINOUT"
        Me.cmbINOUT.Size = New System.Drawing.Size(235, 26)
        Me.cmbINOUT.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(3, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Search:"
        '
        'txtItemDesc
        '
        Me.txtItemDesc.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemDesc.Location = New System.Drawing.Point(5, 28)
        Me.txtItemDesc.Name = "txtItemDesc"
        Me.txtItemDesc.Size = New System.Drawing.Size(236, 26)
        Me.txtItemDesc.TabIndex = 2
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'Timer2
        '
        Me.Timer2.Interval = 1000
        '
        'Panel5
        '
        Me.Panel5.BackgroundImage = Global.SUPPLY.My.Resources.Resources.bg_line
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel5.Location = New System.Drawing.Point(1380, 37)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(21, 659)
        Me.Panel5.TabIndex = 3
        '
        'Panel3
        '
        Me.Panel3.BackgroundImage = Global.SUPPLY.My.Resources.Resources.bg_line
        Me.Panel3.Controls.Add(Me.ListBox1)
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Controls.Add(Me.lvl_drList)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(263, 37)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1117, 659)
        Me.Panel3.TabIndex = 4
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(588, 362)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(120, 238)
        Me.ListBox1.TabIndex = 418
        '
        'Panel4
        '
        Me.Panel4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Panel4.BackgroundImage = CType(resources.GetObject("Panel4.BackgroundImage"), System.Drawing.Image)
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.lblRecords)
        Me.Panel4.Controls.Add(Me.Button6)
        Me.Panel4.Controls.Add(Me.Label8)
        Me.Panel4.Controls.Add(Me.PictureBox2)
        Me.Panel4.Controls.Add(Me.ProgressBar1)
        Me.Panel4.Controls.Add(Me.Label7)
        Me.Panel4.Location = New System.Drawing.Point(20, 67)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(677, 271)
        Me.Panel4.TabIndex = 419
        Me.Panel4.Visible = False
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
        Me.lblRecords.Text = "Waiting..."
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
        Me.ProgressBar1.MarqueeAnimationSpeed = 200
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
        'lvl_drList
        '
        Me.lvl_drList.CheckBoxes = True
        Me.lvl_drList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.col_dr_id, Me.col_dr_no, Me.col_rs_no, Me.col_dr_date, Me.col_item_name, Me.col_source, Me.col_qty_in_others, Me.col_unit, Me.col_concession, Me.col_driver, Me.col_requestor, Me.col_address, Me.col_checked_by, Me.col_received_by, Me.col_dr_info_id, Me.col_rs_id, Me.col_inout, Me.col_time_from, Me.col_time_to, Me.col_ws_no_po_no, Me.col_par_rr_item_id, Me.col_remarks, Me.col_supplier, Me.col_user, Me.col_plateno, Me.col_rrno, Me.col_qty_out, Me.col_price, Me.col_total_amount, Me.col_item_desc, Me.col_date_request, Me.col_dr_option, Me.col_row, Me.col_withdrawn_by, Me.col_reported_by, Me.col_wh_id, Me.col_source2, Me.col_dateSubmitted})
        Me.lvl_drList.ContextMenuStrip = Me.CMS_lvlDRList
        Me.lvl_drList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvl_drList.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvl_drList.FullRowSelect = True
        Me.lvl_drList.HideSelection = False
        Me.lvl_drList.Location = New System.Drawing.Point(0, 0)
        Me.lvl_drList.Name = "lvl_drList"
        Me.lvl_drList.Size = New System.Drawing.Size(1117, 659)
        Me.lvl_drList.TabIndex = 5
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
        Me.col_rs_no.Width = 200
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
        Me.col_source.Text = "Source"
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
        Me.col_source2.Text = "Stockpile/ Quary Code"
        '
        'col_dateSubmitted
        '
        Me.col_dateSubmitted.Text = "Date Submitted"
        Me.col_dateSubmitted.Width = 180
        '
        'CMS_lvlDRList
        '
        Me.CMS_lvlDRList.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditInfoToolStripMenuItem, Me.EditDescriptionToolStripMenuItem, Me.CalculateQtyToolStripMenuItem, Me.SampleDeleteToolStripMenuItem, Me.SortByToolStripMenuItem, Me.GenerateReportToolStripMenuItem, Me.SelectToolStripMenuItem, Me.EditPriceToolStripMenuItem, Me.ExemptionToolStripMenuItem, Me.EditToolStripMenuItem, Me.LoadToolStripMenuItem, Me.ExportToExcelToolStripMenuItem, Me.RemovedReportedToolStripMenuItem, Me.SortToolStripMenuItem, Me.RemovedSelectedItemsToolStripMenuItem})
        Me.CMS_lvlDRList.Name = "CMS_lvlDRList"
        Me.CMS_lvlDRList.Size = New System.Drawing.Size(213, 334)
        '
        'EditInfoToolStripMenuItem
        '
        Me.EditInfoToolStripMenuItem.Name = "EditInfoToolStripMenuItem"
        Me.EditInfoToolStripMenuItem.Size = New System.Drawing.Size(212, 22)
        Me.EditInfoToolStripMenuItem.Text = "Edit Info"
        '
        'EditDescriptionToolStripMenuItem
        '
        Me.EditDescriptionToolStripMenuItem.Name = "EditDescriptionToolStripMenuItem"
        Me.EditDescriptionToolStripMenuItem.Size = New System.Drawing.Size(212, 22)
        Me.EditDescriptionToolStripMenuItem.Text = "Edit Description"
        '
        'CalculateQtyToolStripMenuItem
        '
        Me.CalculateQtyToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.INToolStripMenuItem, Me.OUTToolStripMenuItem})
        Me.CalculateQtyToolStripMenuItem.Name = "CalculateQtyToolStripMenuItem"
        Me.CalculateQtyToolStripMenuItem.Size = New System.Drawing.Size(212, 22)
        Me.CalculateQtyToolStripMenuItem.Text = "Calculate Qty"
        '
        'INToolStripMenuItem
        '
        Me.INToolStripMenuItem.Name = "INToolStripMenuItem"
        Me.INToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
        Me.INToolStripMenuItem.Text = "IN/OTHERS"
        '
        'OUTToolStripMenuItem
        '
        Me.OUTToolStripMenuItem.Name = "OUTToolStripMenuItem"
        Me.OUTToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
        Me.OUTToolStripMenuItem.Text = "OUT"
        '
        'SampleDeleteToolStripMenuItem
        '
        Me.SampleDeleteToolStripMenuItem.Name = "SampleDeleteToolStripMenuItem"
        Me.SampleDeleteToolStripMenuItem.Size = New System.Drawing.Size(212, 22)
        Me.SampleDeleteToolStripMenuItem.Text = "sample delete"
        '
        'SortByToolStripMenuItem
        '
        Me.SortByToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WSNOToolStripMenuItem, Me.WSNOToolStripMenuItem1})
        Me.SortByToolStripMenuItem.Name = "SortByToolStripMenuItem"
        Me.SortByToolStripMenuItem.Size = New System.Drawing.Size(212, 22)
        Me.SortByToolStripMenuItem.Text = "Sort by"
        '
        'WSNOToolStripMenuItem
        '
        Me.WSNOToolStripMenuItem.Name = "WSNOToolStripMenuItem"
        Me.WSNOToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
        Me.WSNOToolStripMenuItem.Text = "RS NO"
        '
        'WSNOToolStripMenuItem1
        '
        Me.WSNOToolStripMenuItem1.Name = "WSNOToolStripMenuItem1"
        Me.WSNOToolStripMenuItem1.Size = New System.Drawing.Size(112, 22)
        Me.WSNOToolStripMenuItem1.Text = "WS NO"
        '
        'GenerateReportToolStripMenuItem
        '
        Me.GenerateReportToolStripMenuItem.Name = "GenerateReportToolStripMenuItem"
        Me.GenerateReportToolStripMenuItem.Size = New System.Drawing.Size(212, 22)
        Me.GenerateReportToolStripMenuItem.Text = "Generate Report"
        '
        'SelectToolStripMenuItem
        '
        Me.SelectToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CheckSelectedToolStripMenuItem1, Me.UncheckSelectedsToolStripMenuItem, Me.SelectAllToolStripMenuItem, Me.UnselectAllToolStripMenuItem})
        Me.SelectToolStripMenuItem.Name = "SelectToolStripMenuItem"
        Me.SelectToolStripMenuItem.Size = New System.Drawing.Size(212, 22)
        Me.SelectToolStripMenuItem.Text = "Select"
        '
        'CheckSelectedToolStripMenuItem1
        '
        Me.CheckSelectedToolStripMenuItem1.Name = "CheckSelectedToolStripMenuItem1"
        Me.CheckSelectedToolStripMenuItem1.Size = New System.Drawing.Size(167, 22)
        Me.CheckSelectedToolStripMenuItem1.Text = "Check Selected"
        '
        'UncheckSelectedsToolStripMenuItem
        '
        Me.UncheckSelectedsToolStripMenuItem.Name = "UncheckSelectedsToolStripMenuItem"
        Me.UncheckSelectedsToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.UncheckSelectedsToolStripMenuItem.Text = "Uncheck Selected"
        '
        'SelectAllToolStripMenuItem
        '
        Me.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem"
        Me.SelectAllToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.SelectAllToolStripMenuItem.Text = "Select All"
        '
        'UnselectAllToolStripMenuItem
        '
        Me.UnselectAllToolStripMenuItem.Name = "UnselectAllToolStripMenuItem"
        Me.UnselectAllToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.UnselectAllToolStripMenuItem.Text = "Unselect All"
        '
        'EditPriceToolStripMenuItem
        '
        Me.EditPriceToolStripMenuItem.Name = "EditPriceToolStripMenuItem"
        Me.EditPriceToolStripMenuItem.Size = New System.Drawing.Size(212, 22)
        Me.EditPriceToolStripMenuItem.Text = "Edit Price and Received By"
        Me.EditPriceToolStripMenuItem.Visible = False
        '
        'ExemptionToolStripMenuItem
        '
        Me.ExemptionToolStripMenuItem.Name = "ExemptionToolStripMenuItem"
        Me.ExemptionToolStripMenuItem.Size = New System.Drawing.Size(212, 22)
        Me.ExemptionToolStripMenuItem.Text = "Exemption"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditOperatorDriverToolStripMenuItem, Me.PriceToolStripMenuItem, Me.ReceivedByToolStripMenuItem, Me.ConToolStripMenuItem, Me.DRNOToolStripMenuItem, Me.PlateNOToolStripMenuItem, Me.SupplierToolStripMenuItem, Me.DRDateToolStripMenuItem, Me.RemarksToolStripMenuItem, Me.CheckedByToolStripMenuItem, Me.SourceToolStripMenuItem, Me.RequestorToolStripMenuItem, Me.WSNOToolStripMenuItem2, Me.WithdrawnByToolStripMenuItem, Me.DRWHTOWHToolStripMenuItem, Me.StockpileQuaryToolStripMenuItem, Me.DateSubmittedToolStripMenuItem, Me.DateLogToolStripMenuItem, Me.INOUTToolStripMenuItem, Me.QTYToolStripMenuItem, Me.RSIDToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(212, 22)
        Me.EditToolStripMenuItem.Text = "Edit DR"
        '
        'EditOperatorDriverToolStripMenuItem
        '
        Me.EditOperatorDriverToolStripMenuItem.Name = "EditOperatorDriverToolStripMenuItem"
        Me.EditOperatorDriverToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.EditOperatorDriverToolStripMenuItem.Text = "> Operator/Driver"
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
        'ConToolStripMenuItem
        '
        Me.ConToolStripMenuItem.Name = "ConToolStripMenuItem"
        Me.ConToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.ConToolStripMenuItem.Text = "> Concession Ticket"
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
        'SupplierToolStripMenuItem
        '
        Me.SupplierToolStripMenuItem.Name = "SupplierToolStripMenuItem"
        Me.SupplierToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.SupplierToolStripMenuItem.Text = "> Supplier"
        '
        'DRDateToolStripMenuItem
        '
        Me.DRDateToolStripMenuItem.Name = "DRDateToolStripMenuItem"
        Me.DRDateToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.DRDateToolStripMenuItem.Text = "> DR/WS Date"
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
        'WSNOToolStripMenuItem2
        '
        Me.WSNOToolStripMenuItem2.Name = "WSNOToolStripMenuItem2"
        Me.WSNOToolStripMenuItem2.Size = New System.Drawing.Size(201, 22)
        Me.WSNOToolStripMenuItem2.Text = "> WS NO"
        '
        'WithdrawnByToolStripMenuItem
        '
        Me.WithdrawnByToolStripMenuItem.Name = "WithdrawnByToolStripMenuItem"
        Me.WithdrawnByToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.WithdrawnByToolStripMenuItem.Text = "> Withdrawn By"
        '
        'DRWHTOWHToolStripMenuItem
        '
        Me.DRWHTOWHToolStripMenuItem.Name = "DRWHTOWHToolStripMenuItem"
        Me.DRWHTOWHToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.DRWHTOWHToolStripMenuItem.Text = "> DR (WH TO WH)"
        '
        'StockpileQuaryToolStripMenuItem
        '
        Me.StockpileQuaryToolStripMenuItem.Name = "StockpileQuaryToolStripMenuItem"
        Me.StockpileQuaryToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.StockpileQuaryToolStripMenuItem.Text = "> Stockpile/Quary Code"
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
        'INOUTToolStripMenuItem
        '
        Me.INOUTToolStripMenuItem.Name = "INOUTToolStripMenuItem"
        Me.INOUTToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.INOUTToolStripMenuItem.Text = "> IN/OUT"
        '
        'QTYToolStripMenuItem
        '
        Me.QTYToolStripMenuItem.Name = "QTYToolStripMenuItem"
        Me.QTYToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.QTYToolStripMenuItem.Text = "> QTY"
        '
        'RSIDToolStripMenuItem
        '
        Me.RSIDToolStripMenuItem.Name = "RSIDToolStripMenuItem"
        Me.RSIDToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.RSIDToolStripMenuItem.Text = "> RS ID"
        '
        'LoadToolStripMenuItem
        '
        Me.LoadToolStripMenuItem.Name = "LoadToolStripMenuItem"
        Me.LoadToolStripMenuItem.Size = New System.Drawing.Size(212, 22)
        Me.LoadToolStripMenuItem.Text = "load"
        '
        'ExportToExcelToolStripMenuItem
        '
        Me.ExportToExcelToolStripMenuItem.Name = "ExportToExcelToolStripMenuItem"
        Me.ExportToExcelToolStripMenuItem.Size = New System.Drawing.Size(212, 22)
        Me.ExportToExcelToolStripMenuItem.Text = "Export to Excel"
        '
        'RemovedReportedToolStripMenuItem
        '
        Me.RemovedReportedToolStripMenuItem.Name = "RemovedReportedToolStripMenuItem"
        Me.RemovedReportedToolStripMenuItem.Size = New System.Drawing.Size(212, 22)
        Me.RemovedReportedToolStripMenuItem.Text = "removed reported"
        '
        'SortToolStripMenuItem
        '
        Me.SortToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ItemDescToolStripMenuItem, Me.SourceToolStripMenuItem1, Me.OperatorDriverToolStripMenuItem, Me.SupplierToolStripMenuItem1, Me.DRDateServedToolStripMenuItem, Me.PlateNoToolStripMenuItem1, Me.RequestorToolStripMenuItem1, Me.ReportedToolStripMenuItem, Me.UnreportedToolStripMenuItem})
        Me.SortToolStripMenuItem.Name = "SortToolStripMenuItem"
        Me.SortToolStripMenuItem.Size = New System.Drawing.Size(212, 22)
        Me.SortToolStripMenuItem.Text = "Sort"
        '
        'ItemDescToolStripMenuItem
        '
        Me.ItemDescToolStripMenuItem.Name = "ItemDescToolStripMenuItem"
        Me.ItemDescToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.ItemDescToolStripMenuItem.Text = "Item Desc"
        '
        'SourceToolStripMenuItem1
        '
        Me.SourceToolStripMenuItem1.Name = "SourceToolStripMenuItem1"
        Me.SourceToolStripMenuItem1.Size = New System.Drawing.Size(157, 22)
        Me.SourceToolStripMenuItem1.Text = "Source"
        '
        'OperatorDriverToolStripMenuItem
        '
        Me.OperatorDriverToolStripMenuItem.Name = "OperatorDriverToolStripMenuItem"
        Me.OperatorDriverToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.OperatorDriverToolStripMenuItem.Text = "Operator/Driver"
        '
        'SupplierToolStripMenuItem1
        '
        Me.SupplierToolStripMenuItem1.Name = "SupplierToolStripMenuItem1"
        Me.SupplierToolStripMenuItem1.Size = New System.Drawing.Size(157, 22)
        Me.SupplierToolStripMenuItem1.Text = "Supplier"
        '
        'DRDateServedToolStripMenuItem
        '
        Me.DRDateServedToolStripMenuItem.Name = "DRDateServedToolStripMenuItem"
        Me.DRDateServedToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.DRDateServedToolStripMenuItem.Text = "DR Date Served"
        '
        'PlateNoToolStripMenuItem1
        '
        Me.PlateNoToolStripMenuItem1.Name = "PlateNoToolStripMenuItem1"
        Me.PlateNoToolStripMenuItem1.Size = New System.Drawing.Size(157, 22)
        Me.PlateNoToolStripMenuItem1.Text = "Plate No."
        '
        'RequestorToolStripMenuItem1
        '
        Me.RequestorToolStripMenuItem1.Name = "RequestorToolStripMenuItem1"
        Me.RequestorToolStripMenuItem1.Size = New System.Drawing.Size(157, 22)
        Me.RequestorToolStripMenuItem1.Text = "Requestor"
        '
        'ReportedToolStripMenuItem
        '
        Me.ReportedToolStripMenuItem.Name = "ReportedToolStripMenuItem"
        Me.ReportedToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.ReportedToolStripMenuItem.Text = "Reported"
        '
        'UnreportedToolStripMenuItem
        '
        Me.UnreportedToolStripMenuItem.Name = "UnreportedToolStripMenuItem"
        Me.UnreportedToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.UnreportedToolStripMenuItem.Text = "Unreported"
        '
        'RemovedSelectedItemsToolStripMenuItem
        '
        Me.RemovedSelectedItemsToolStripMenuItem.Name = "RemovedSelectedItemsToolStripMenuItem"
        Me.RemovedSelectedItemsToolStripMenuItem.Size = New System.Drawing.Size(212, 22)
        Me.RemovedSelectedItemsToolStripMenuItem.Text = "Removed Selected Items"
        '
        'Timer3
        '
        Me.Timer3.Interval = 1000
        '
        'BackgroundWorker1
        '
        '
        'BackgroundWorker2
        '
        '
        'BackgroundWorker3
        '
        '
        'BackgroundWorker4
        '
        '
        'bw_search_without_rs_dr
        '
        '
        'bw_check_if_done
        '
        '
        'bw_display
        '
        '
        'BW_edit_wh_to_wh
        '
        '
        'BW_Loading
        '
        '
        'FDRLIST1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SUPPLY.My.Resources.Resources.bg_line
        Me.ClientSize = New System.Drawing.Size(1401, 696)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "FDRLIST1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FDRLIST1"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMS_lvlDRList.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents cmbSortBy As ComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtItems As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cmbINOUT As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtItemDesc As TextBox
    Friend WithEvents btnSearch As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Timer2 As Timer
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents dtpto As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents dtpfrom As DateTimePicker
    Friend WithEvents btnExit As Button
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents lblRecords As Label
    Friend WithEvents Button6 As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents Label7 As Label
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
    Friend WithEvents Timer3 As Timer
    Friend WithEvents Label10 As Label
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents CMS_lvlDRList As ContextMenuStrip
    Friend WithEvents EditInfoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditDescriptionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CalculateQtyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SampleDeleteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SortByToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WSNOToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WSNOToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents GenerateReportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SelectToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CheckSelectedToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents UncheckSelectedsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SelectAllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditPriceToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExemptionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditOperatorDriverToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PriceToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReceivedByToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ConToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DRNOToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PlateNOToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SupplierToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LoadToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExportToExcelToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DRDateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RemarksToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CheckedByToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents INToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OUTToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SourceToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RequestorToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WSNOToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents WithdrawnByToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents BackgroundWorker2 As System.ComponentModel.BackgroundWorker
    Friend WithEvents cmbEnableDateRange As ComboBox
    Friend WithEvents col_withdrawn_by As ColumnHeader
    Friend WithEvents RemovedReportedToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents col_reported_by As ColumnHeader
    Friend WithEvents BackgroundWorker3 As System.ComponentModel.BackgroundWorker
    Friend WithEvents ProgressBar2 As ProgressBar
    Friend WithEvents SortToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ItemDescToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SourceToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents OperatorDriverToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SupplierToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents DRDateServedToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PlateNoToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents RequestorToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ReportedToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UnreportedToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UnselectAllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BackgroundWorker4 As System.ComponentModel.BackgroundWorker
    Friend WithEvents bw_search_without_rs_dr As System.ComponentModel.BackgroundWorker
    Friend WithEvents bw_check_if_done As System.ComponentModel.BackgroundWorker
    Friend WithEvents bw_display As System.ComponentModel.BackgroundWorker
    Friend WithEvents col_wh_id As ColumnHeader
    Friend WithEvents RemovedSelectedItemsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents col_source2 As ColumnHeader
    Friend WithEvents DRWHTOWHToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StockpileQuaryToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BW_edit_wh_to_wh As System.ComponentModel.BackgroundWorker
    Friend WithEvents BW_Loading As System.ComponentModel.BackgroundWorker
    Friend WithEvents lblWait As Label
    Friend WithEvents col_dateSubmitted As ColumnHeader
    Friend WithEvents DateSubmittedToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents DateLogToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents INOUTToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents QTYToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RSIDToolStripMenuItem As ToolStripMenuItem
End Class
