<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FPOFORM
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FPOFORM))
        Me.dgvPOList = New System.Windows.Forms.DataGridView()
        Me.Column13 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_rs_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_inout = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_typeofreq = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CMS_dgvPOList = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SplitQuantityToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChargesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PastePONoByBatchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyTermsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasteTermsByBatchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtChargeTo = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblChargeToID = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lblTypeOfReq = New System.Windows.Forms.Label()
        Me.lblInOut = New System.Windows.Forms.Label()
        Me.lblReqType = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.pboxHeader = New System.Windows.Forms.PictureBox()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.lblTypeOfCharge = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbox_List = New System.Windows.Forms.ListBox()
        Me.FileSystemWatcher1 = New System.IO.FileSystemWatcher()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblItemName = New System.Windows.Forms.Label()
        Me.cmbBrand = New System.Windows.Forms.ComboBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtsplitqty = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.txtRequestor = New System.Windows.Forms.TextBox()
        Me.cmb_driver = New System.Windows.Forms.ComboBox()
        Me.lbl_type_of_purchasing = New System.Windows.Forms.Label()
        Me.pnl_prices = New System.Windows.Forms.Panel()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.lvl_prices = New System.Windows.Forms.ListView()
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label5 = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DTPTrans = New System.Windows.Forms.DateTimePicker()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtRsNo = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtInstructions = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.DTPdateneeded = New System.Windows.Forms.DateTimePicker()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtPrepared_by = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtChecked_by = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtApproved_by = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cmbdr_option = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.lblRsID = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.btnProceedtoRR = New System.Windows.Forms.Button()
        CType(Me.dgvPOList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMS_dgvPOList.SuspendLayout()
        CType(Me.pboxHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FileSystemWatcher1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnl_prices.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvPOList
        '
        Me.dgvPOList.AllowUserToAddRows = False
        Me.dgvPOList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPOList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column13, Me.Column1, Me.Column2, Me.Column3, Me.Column11, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column8, Me.Column9, Me.Column10, Me.col_rs_id, Me.Column14, Me.col_inout, Me.col_typeofreq, Me.Column12})
        Me.dgvPOList.ContextMenuStrip = Me.CMS_dgvPOList
        Me.dgvPOList.Location = New System.Drawing.Point(238, 74)
        Me.dgvPOList.Name = "dgvPOList"
        Me.dgvPOList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPOList.Size = New System.Drawing.Size(1094, 656)
        Me.dgvPOList.TabIndex = 11
        '
        'Column13
        '
        Me.Column13.HeaderText = "Select"
        Me.Column13.Name = "Column13"
        '
        'Column1
        '
        Me.Column1.HeaderText = "Supplier/Recepient"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column1.Width = 300
        '
        'Column2
        '
        Me.Column2.HeaderText = "wh_id"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "Item Name"
        Me.Column3.Name = "Column3"
        Me.Column3.Width = 150
        '
        'Column11
        '
        Me.Column11.HeaderText = "Description"
        Me.Column11.Name = "Column11"
        Me.Column11.Width = 300
        '
        'Column4
        '
        Me.Column4.HeaderText = "PO No/CV No/WS No"
        Me.Column4.Name = "Column4"
        '
        'Column5
        '
        Me.Column5.HeaderText = "Terms"
        Me.Column5.Name = "Column5"
        '
        'Column6
        '
        Me.Column6.HeaderText = "Qty"
        Me.Column6.Name = "Column6"
        '
        'Column7
        '
        Me.Column7.HeaderText = "Unit"
        Me.Column7.Name = "Column7"
        '
        'Column8
        '
        Me.Column8.HeaderText = "Unit Price"
        Me.Column8.Name = "Column8"
        '
        'Column9
        '
        Me.Column9.HeaderText = "Amount"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        '
        'Column10
        '
        Me.Column10.HeaderText = "po_det_id"
        Me.Column10.Name = "Column10"
        '
        'col_rs_id
        '
        Me.col_rs_id.HeaderText = "rs_id"
        Me.col_rs_id.Name = "col_rs_id"
        '
        'Column14
        '
        Me.Column14.HeaderText = "lof_id"
        Me.Column14.Name = "Column14"
        '
        'col_inout
        '
        Me.col_inout.HeaderText = "INOUT"
        Me.col_inout.Name = "col_inout"
        '
        'col_typeofreq
        '
        Me.col_typeofreq.HeaderText = "Type of Request"
        Me.col_typeofreq.Name = "col_typeofreq"
        '
        'Column12
        '
        Me.Column12.HeaderText = "Charge To"
        Me.Column12.Name = "Column12"
        '
        'CMS_dgvPOList
        '
        Me.CMS_dgvPOList.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SplitQuantityToolStripMenuItem, Me.ChargesToolStripMenuItem, Me.CopyToolStripMenuItem, Me.PastePONoByBatchToolStripMenuItem, Me.SelectAllToolStripMenuItem, Me.CopyTermsToolStripMenuItem, Me.PasteTermsByBatchToolStripMenuItem})
        Me.CMS_dgvPOList.Name = "CMS_dgvPOList"
        Me.CMS_dgvPOList.Size = New System.Drawing.Size(193, 158)
        '
        'SplitQuantityToolStripMenuItem
        '
        Me.SplitQuantityToolStripMenuItem.Name = "SplitQuantityToolStripMenuItem"
        Me.SplitQuantityToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.SplitQuantityToolStripMenuItem.Text = "Split Quantity"
        '
        'ChargesToolStripMenuItem
        '
        Me.ChargesToolStripMenuItem.Name = "ChargesToolStripMenuItem"
        Me.ChargesToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.ChargesToolStripMenuItem.Text = "Add Supplier"
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.CopyToolStripMenuItem.Text = "Copy PO No."
        '
        'PastePONoByBatchToolStripMenuItem
        '
        Me.PastePONoByBatchToolStripMenuItem.Name = "PastePONoByBatchToolStripMenuItem"
        Me.PastePONoByBatchToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.PastePONoByBatchToolStripMenuItem.Text = "Paste PO No. by batch"
        '
        'SelectAllToolStripMenuItem
        '
        Me.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem"
        Me.SelectAllToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.SelectAllToolStripMenuItem.Text = "Select All"
        '
        'CopyTermsToolStripMenuItem
        '
        Me.CopyTermsToolStripMenuItem.Name = "CopyTermsToolStripMenuItem"
        Me.CopyTermsToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.CopyTermsToolStripMenuItem.Text = "Copy Terms"
        '
        'PasteTermsByBatchToolStripMenuItem
        '
        Me.PasteTermsByBatchToolStripMenuItem.Name = "PasteTermsByBatchToolStripMenuItem"
        Me.PasteTermsByBatchToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.PasteTermsByBatchToolStripMenuItem.Text = "Paste Terms By Batch"
        '
        'txtChargeTo
        '
        Me.txtChargeTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChargeTo.Location = New System.Drawing.Point(1387, 290)
        Me.txtChargeTo.Multiline = True
        Me.txtChargeTo.Name = "txtChargeTo"
        Me.txtChargeTo.ReadOnly = True
        Me.txtChargeTo.Size = New System.Drawing.Size(216, 81)
        Me.txtChargeTo.TabIndex = 410
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(1384, 273)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 15)
        Me.Label8.TabIndex = 417
        Me.Label8.Text = "Charge to:"
        '
        'lblChargeToID
        '
        Me.lblChargeToID.AutoSize = True
        Me.lblChargeToID.Location = New System.Drawing.Point(422, 121)
        Me.lblChargeToID.Name = "lblChargeToID"
        Me.lblChargeToID.Size = New System.Drawing.Size(13, 13)
        Me.lblChargeToID.TabIndex = 428
        Me.lblChargeToID.Text = "0"
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.BackColor = System.Drawing.Color.Transparent
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.Color.LimeGreen
        Me.lblTotal.Location = New System.Drawing.Point(320, 45)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(45, 24)
        Me.lblTotal.TabIndex = 429
        Me.lblTotal.Text = "0.00"
        '
        'lblTypeOfReq
        '
        Me.lblTypeOfReq.AutoSize = True
        Me.lblTypeOfReq.Location = New System.Drawing.Point(422, 101)
        Me.lblTypeOfReq.Name = "lblTypeOfReq"
        Me.lblTypeOfReq.Size = New System.Drawing.Size(13, 13)
        Me.lblTypeOfReq.TabIndex = 430
        Me.lblTypeOfReq.Text = "0"
        '
        'lblInOut
        '
        Me.lblInOut.AutoSize = True
        Me.lblInOut.Location = New System.Drawing.Point(422, 145)
        Me.lblInOut.Name = "lblInOut"
        Me.lblInOut.Size = New System.Drawing.Size(0, 13)
        Me.lblInOut.TabIndex = 432
        '
        'lblReqType
        '
        Me.lblReqType.AutoSize = True
        Me.lblReqType.Location = New System.Drawing.Point(422, 113)
        Me.lblReqType.Name = "lblReqType"
        Me.lblReqType.Size = New System.Drawing.Size(0, 13)
        Me.lblReqType.TabIndex = 431
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(16, 11)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(298, 22)
        Me.Label15.TabIndex = 433
        Me.Label15.Text = "PURCHASE ORDER/WITHDRAWAL FORM"
        '
        'pboxHeader
        '
        Me.pboxHeader.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.pboxHeader.BackgroundImage = CType(resources.GetObject("pboxHeader.BackgroundImage"), System.Drawing.Image)
        Me.pboxHeader.InitialImage = Nothing
        Me.pboxHeader.Location = New System.Drawing.Point(0, 1)
        Me.pboxHeader.Name = "pboxHeader"
        Me.pboxHeader.Size = New System.Drawing.Size(1454, 41)
        Me.pboxHeader.TabIndex = 434
        Me.pboxHeader.TabStop = False
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.Transparent
        Me.btnExit.BackgroundImage = Global.SUPPLY.My.Resources.Resources.close_button
        Me.btnExit.FlatAppearance.BorderSize = 0
        Me.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit.Location = New System.Drawing.Point(1304, 11)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(22, 20)
        Me.btnExit.TabIndex = 435
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'lblTypeOfCharge
        '
        Me.lblTypeOfCharge.AutoSize = True
        Me.lblTypeOfCharge.Location = New System.Drawing.Point(318, 121)
        Me.lblTypeOfCharge.Name = "lblTypeOfCharge"
        Me.lblTypeOfCharge.Size = New System.Drawing.Size(39, 13)
        Me.lblTypeOfCharge.TabIndex = 436
        Me.lblTypeOfCharge.Text = "Label2"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.LimeGreen
        Me.Label2.Location = New System.Drawing.Point(234, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 24)
        Me.Label2.TabIndex = 437
        Me.Label2.Text = "TOTAL :"
        '
        'lbox_List
        '
        Me.lbox_List.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbox_List.FormattingEnabled = True
        Me.lbox_List.ItemHeight = 18
        Me.lbox_List.Location = New System.Drawing.Point(264, 145)
        Me.lbox_List.Name = "lbox_List"
        Me.lbox_List.Size = New System.Drawing.Size(120, 94)
        Me.lbox_List.TabIndex = 439
        Me.lbox_List.Visible = False
        '
        'FileSystemWatcher1
        '
        Me.FileSystemWatcher1.EnableRaisingEvents = True
        Me.FileSystemWatcher1.SynchronizingObject = Me
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblItemName)
        Me.Panel1.Controls.Add(Me.cmbBrand)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Location = New System.Drawing.Point(516, 162)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(231, 134)
        Me.Panel1.TabIndex = 440
        Me.Panel1.Visible = False
        '
        'lblItemName
        '
        Me.lblItemName.AutoSize = True
        Me.lblItemName.Location = New System.Drawing.Point(10, 41)
        Me.lblItemName.Name = "lblItemName"
        Me.lblItemName.Size = New System.Drawing.Size(0, 13)
        Me.lblItemName.TabIndex = 397
        '
        'cmbBrand
        '
        Me.cmbBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBrand.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBrand.FormattingEnabled = True
        Me.cmbBrand.Items.AddRange(New Object() {"CASH", "PURCHASE ORDER"})
        Me.cmbBrand.Location = New System.Drawing.Point(11, 64)
        Me.cmbBrand.Name = "cmbBrand"
        Me.cmbBrand.Size = New System.Drawing.Size(211, 24)
        Me.cmbBrand.TabIndex = 396
        '
        'Button2
        '
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(206, 3)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(22, 23)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "x"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(147, 97)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Select"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(264, 755)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 441
        Me.Button3.Text = "Button3"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.txtsplitqty)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Button4)
        Me.Panel2.Controls.Add(Me.Button5)
        Me.Panel2.Location = New System.Drawing.Point(516, 321)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(231, 114)
        Me.Panel2.TabIndex = 442
        Me.Panel2.Visible = False
        '
        'txtsplitqty
        '
        Me.txtsplitqty.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsplitqty.Location = New System.Drawing.Point(8, 49)
        Me.txtsplitqty.Name = "txtsplitqty"
        Me.txtsplitqty.Size = New System.Drawing.Size(216, 24)
        Me.txtsplitqty.TabIndex = 424
        Me.txtsplitqty.Text = "0"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(5, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 15)
        Me.Label4.TabIndex = 425
        Me.Label4.Text = "Enter qty:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(0, 13)
        Me.Label3.TabIndex = 397
        '
        'Button4
        '
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Location = New System.Drawing.Point(206, 3)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(22, 23)
        Me.Button4.TabIndex = 1
        Me.Button4.Text = "x"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(150, 79)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 23)
        Me.Button5.TabIndex = 0
        Me.Button5.Text = "OK"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'txtRequestor
        '
        Me.txtRequestor.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRequestor.Location = New System.Drawing.Point(531, 572)
        Me.txtRequestor.Name = "txtRequestor"
        Me.txtRequestor.Size = New System.Drawing.Size(216, 24)
        Me.txtRequestor.TabIndex = 448
        '
        'cmb_driver
        '
        Me.cmb_driver.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_driver.FormattingEnabled = True
        Me.cmb_driver.Location = New System.Drawing.Point(531, 500)
        Me.cmb_driver.Name = "cmb_driver"
        Me.cmb_driver.Size = New System.Drawing.Size(216, 26)
        Me.cmb_driver.TabIndex = 447
        '
        'lbl_type_of_purchasing
        '
        Me.lbl_type_of_purchasing.AutoSize = True
        Me.lbl_type_of_purchasing.Location = New System.Drawing.Point(1375, 251)
        Me.lbl_type_of_purchasing.Name = "lbl_type_of_purchasing"
        Me.lbl_type_of_purchasing.Size = New System.Drawing.Size(39, 13)
        Me.lbl_type_of_purchasing.TabIndex = 449
        Me.lbl_type_of_purchasing.Text = "Label5"
        '
        'pnl_prices
        '
        Me.pnl_prices.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_prices.Controls.Add(Me.Button6)
        Me.pnl_prices.Controls.Add(Me.lvl_prices)
        Me.pnl_prices.Controls.Add(Me.Label5)
        Me.pnl_prices.Location = New System.Drawing.Point(763, 165)
        Me.pnl_prices.Name = "pnl_prices"
        Me.pnl_prices.Size = New System.Drawing.Size(368, 246)
        Me.pnl_prices.TabIndex = 457
        Me.pnl_prices.Visible = False
        '
        'Button6
        '
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.Location = New System.Drawing.Point(341, 3)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(22, 23)
        Me.Button6.TabIndex = 397
        Me.Button6.Text = "x"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'lvl_prices
        '
        Me.lvl_prices.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader1, Me.ColumnHeader9})
        Me.lvl_prices.FullRowSelect = True
        Me.lvl_prices.GridLines = True
        Me.lvl_prices.HideSelection = False
        Me.lvl_prices.Location = New System.Drawing.Point(9, 36)
        Me.lvl_prices.Name = "lvl_prices"
        Me.lvl_prices.Size = New System.Drawing.Size(347, 198)
        Me.lvl_prices.TabIndex = 396
        Me.lvl_prices.UseCompatibleStateImageBehavior = False
        Me.lvl_prices.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "wh_id"
        Me.ColumnHeader7.Width = 0
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Item Name"
        Me.ColumnHeader8.Width = 151
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Unit"
        Me.ColumnHeader1.Width = 88
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Prices per Unit"
        Me.ColumnHeader9.Width = 100
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "PRICES"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.FlowLayoutPanel1.Controls.Add(Me.Label1)
        Me.FlowLayoutPanel1.Controls.Add(Me.DTPTrans)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label14)
        Me.FlowLayoutPanel1.Controls.Add(Me.txtRsNo)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label6)
        Me.FlowLayoutPanel1.Controls.Add(Me.txtInstructions)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label11)
        Me.FlowLayoutPanel1.Controls.Add(Me.DTPdateneeded)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label10)
        Me.FlowLayoutPanel1.Controls.Add(Me.txtPrepared_by)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label9)
        Me.FlowLayoutPanel1.Controls.Add(Me.txtChecked_by)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label12)
        Me.FlowLayoutPanel1.Controls.Add(Me.txtApproved_by)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label16)
        Me.FlowLayoutPanel1.Controls.Add(Me.cmbdr_option)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label17)
        Me.FlowLayoutPanel1.Controls.Add(Me.txtRemarks)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label18)
        Me.FlowLayoutPanel1.Controls.Add(Me.ComboBox2)
        Me.FlowLayoutPanel1.Controls.Add(Me.TextBox1)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnSave)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label19)
        Me.FlowLayoutPanel1.Controls.Add(Me.lblRsID)
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(7, 48)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(225, 643)
        Me.FlowLayoutPanel1.TabIndex = 458
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 15)
        Me.Label1.TabIndex = 416
        Me.Label1.Text = "P.O. Date:"
        '
        'DTPTrans
        '
        Me.DTPTrans.CustomFormat = ""
        Me.DTPTrans.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPTrans.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPTrans.Location = New System.Drawing.Point(10, 18)
        Me.DTPTrans.Margin = New System.Windows.Forms.Padding(10, 3, 3, 3)
        Me.DTPTrans.Name = "DTPTrans"
        Me.DTPTrans.Size = New System.Drawing.Size(206, 26)
        Me.DTPTrans.TabIndex = 1
        '
        'Label14
        '
        Me.Label14.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(3, 47)
        Me.Label14.Margin = New System.Windows.Forms.Padding(3, 0, 20, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(50, 15)
        Me.Label14.TabIndex = 423
        Me.Label14.Text = "R.S. No."
        '
        'txtRsNo
        '
        Me.txtRsNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRsNo.Location = New System.Drawing.Point(3, 65)
        Me.txtRsNo.Name = "txtRsNo"
        Me.txtRsNo.ReadOnly = True
        Me.txtRsNo.Size = New System.Drawing.Size(213, 24)
        Me.txtRsNo.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(3, 97)
        Me.Label6.Margin = New System.Windows.Forms.Padding(3, 5, 3, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 15)
        Me.Label6.TabIndex = 424
        Me.Label6.Text = "Instruction:"
        '
        'txtInstructions
        '
        Me.txtInstructions.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInstructions.Location = New System.Drawing.Point(3, 115)
        Me.txtInstructions.Multiline = True
        Me.txtInstructions.Name = "txtInstructions"
        Me.txtInstructions.Size = New System.Drawing.Size(213, 65)
        Me.txtInstructions.TabIndex = 3
        Me.txtInstructions.Text = "For pick-up"
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(3, 183)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(82, 15)
        Me.Label11.TabIndex = 425
        Me.Label11.Text = "Date Needed:"
        '
        'DTPdateneeded
        '
        Me.DTPdateneeded.CustomFormat = ""
        Me.DTPdateneeded.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPdateneeded.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPdateneeded.Location = New System.Drawing.Point(10, 201)
        Me.DTPdateneeded.Margin = New System.Windows.Forms.Padding(10, 3, 3, 3)
        Me.DTPdateneeded.Name = "DTPdateneeded"
        Me.DTPdateneeded.Size = New System.Drawing.Size(203, 26)
        Me.DTPdateneeded.TabIndex = 4
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(3, 230)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(79, 15)
        Me.Label10.TabIndex = 422
        Me.Label10.Text = "Prepared by:"
        '
        'txtPrepared_by
        '
        Me.txtPrepared_by.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrepared_by.Location = New System.Drawing.Point(3, 248)
        Me.txtPrepared_by.Name = "txtPrepared_by"
        Me.txtPrepared_by.Size = New System.Drawing.Size(213, 24)
        Me.txtPrepared_by.TabIndex = 5
        Me.txtPrepared_by.Text = "Licayan, Katreena Rose D."
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(3, 275)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(76, 15)
        Me.Label9.TabIndex = 421
        Me.Label9.Text = "Checked by:"
        '
        'txtChecked_by
        '
        Me.txtChecked_by.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChecked_by.Location = New System.Drawing.Point(3, 293)
        Me.txtChecked_by.Name = "txtChecked_by"
        Me.txtChecked_by.Size = New System.Drawing.Size(213, 24)
        Me.txtChecked_by.TabIndex = 6
        Me.txtChecked_by.Text = "Cupay, Mercy Fe"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(3, 320)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(80, 15)
        Me.Label12.TabIndex = 426
        Me.Label12.Text = "Approved by:"
        '
        'txtApproved_by
        '
        Me.txtApproved_by.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtApproved_by.Location = New System.Drawing.Point(3, 338)
        Me.txtApproved_by.Name = "txtApproved_by"
        Me.txtApproved_by.Size = New System.Drawing.Size(213, 24)
        Me.txtApproved_by.TabIndex = 7
        Me.txtApproved_by.Text = "Joseph Q. Gorme"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(3, 365)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(95, 15)
        Me.Label16.TabIndex = 430
        Me.Label16.Text = "Delivery Option:"
        '
        'cmbdr_option
        '
        Me.cmbdr_option.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbdr_option.FormattingEnabled = True
        Me.cmbdr_option.Items.AddRange(New Object() {"WITH DR", "WITHOUT DR"})
        Me.cmbdr_option.Location = New System.Drawing.Point(3, 383)
        Me.cmbdr_option.Name = "cmbdr_option"
        Me.cmbdr_option.Size = New System.Drawing.Size(213, 26)
        Me.cmbdr_option.TabIndex = 8
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(3, 412)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(63, 16)
        Me.Label17.TabIndex = 432
        Me.Label17.Text = "Remarks:"
        '
        'txtRemarks
        '
        Me.txtRemarks.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRemarks.Location = New System.Drawing.Point(3, 431)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(213, 46)
        Me.txtRemarks.TabIndex = 9
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(3, 480)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(87, 16)
        Me.Label18.TabIndex = 433
        Me.Label18.Text = "Tax Category:"
        '
        'ComboBox2
        '
        Me.ComboBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Items.AddRange(New Object() {"VAT (Value Added Tax)", "EWT (Expanded Withholding Tax)"})
        Me.ComboBox2.Location = New System.Drawing.Point(3, 499)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(213, 26)
        Me.ComboBox2.TabIndex = 464
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(3, 531)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(213, 24)
        Me.TextBox1.TabIndex = 465
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(3, 561)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(213, 37)
        Me.btnSave.TabIndex = 466
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label19.Location = New System.Drawing.Point(3, 601)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(181, 15)
        Me.Label19.TabIndex = 467
        Me.Label19.Text = "Ctrl + S for shorcut Save/Update"
        '
        'lblRsID
        '
        Me.lblRsID.AutoSize = True
        Me.lblRsID.Location = New System.Drawing.Point(3, 616)
        Me.lblRsID.Name = "lblRsID"
        Me.lblRsID.Size = New System.Drawing.Size(41, 13)
        Me.lblRsID.TabIndex = 468
        Me.lblRsID.Text = "lblRsID"
        Me.lblRsID.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(596, 46)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(14, 18)
        Me.Label7.TabIndex = 459
        Me.Label7.Text = "*"
        Me.Label7.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(467, 46)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(122, 18)
        Me.Label13.TabIndex = 460
        Me.Label13.Text = "Type of Delivery:"
        Me.Label13.Visible = False
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(301, 513)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox1.TabIndex = 428
        '
        'btnProceedtoRR
        '
        Me.btnProceedtoRR.Location = New System.Drawing.Point(7, 697)
        Me.btnProceedtoRR.Name = "btnProceedtoRR"
        Me.btnProceedtoRR.Size = New System.Drawing.Size(225, 33)
        Me.btnProceedtoRR.TabIndex = 461
        Me.btnProceedtoRR.Text = "Proceed to Receiving"
        Me.btnProceedtoRR.UseMnemonic = False
        Me.btnProceedtoRR.UseVisualStyleBackColor = True
        Me.btnProceedtoRR.Visible = False
        '
        'FPOFORM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SUPPLY.My.Resources.Resources.eus_bg_03
        Me.ClientSize = New System.Drawing.Size(1345, 790)
        Me.Controls.Add(Me.btnProceedtoRR)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.pnl_prices)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.dgvPOList)
        Me.Controls.Add(Me.lblTypeOfCharge)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.pboxHeader)
        Me.Controls.Add(Me.lblInOut)
        Me.Controls.Add(Me.lblReqType)
        Me.Controls.Add(Me.lblTypeOfReq)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.lblChargeToID)
        Me.Controls.Add(Me.txtChargeTo)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.lbox_List)
        Me.Controls.Add(Me.txtRequestor)
        Me.Controls.Add(Me.cmb_driver)
        Me.Controls.Add(Me.lbl_type_of_purchasing)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "FPOFORM"
        Me.Text = " "
        CType(Me.dgvPOList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMS_dgvPOList.ResumeLayout(False)
        CType(Me.pboxHeader, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FileSystemWatcher1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnl_prices.ResumeLayout(False)
        Me.pnl_prices.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvPOList As System.Windows.Forms.DataGridView
    Friend WithEvents txtChargeTo As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblChargeToID As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents lblTypeOfReq As System.Windows.Forms.Label
    Friend WithEvents lblInOut As System.Windows.Forms.Label
    Friend WithEvents lblReqType As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents pboxHeader As System.Windows.Forms.PictureBox
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents lblTypeOfCharge As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbox_List As System.Windows.Forms.ListBox
    Friend WithEvents FileSystemWatcher1 As System.IO.FileSystemWatcher
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents cmbBrand As System.Windows.Forms.ComboBox
    Friend WithEvents lblItemName As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents CMS_dgvPOList As ContextMenuStrip
    Friend WithEvents SplitQuantityToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents txtsplitqty As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtRequestor As TextBox
    Friend WithEvents cmb_driver As ComboBox
    Friend WithEvents lbl_type_of_purchasing As Label
    Friend WithEvents pnl_prices As System.Windows.Forms.Panel
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents lvl_prices As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ChargesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CopyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PastePONoByBatchToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SelectAllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label7 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents btnProceedtoRR As Button
    Friend WithEvents CopyTermsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PasteTermsByBatchToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Column13 As DataGridViewCheckBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column11 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents Column10 As DataGridViewTextBoxColumn
    Friend WithEvents col_rs_id As DataGridViewTextBoxColumn
    Friend WithEvents Column14 As DataGridViewTextBoxColumn
    Friend WithEvents col_inout As DataGridViewTextBoxColumn
    Friend WithEvents col_typeofreq As DataGridViewTextBoxColumn
    Friend WithEvents Column12 As DataGridViewTextBoxColumn
    Friend WithEvents Label1 As Label
    Friend WithEvents DTPTrans As DateTimePicker
    Friend WithEvents Label14 As Label
    Friend WithEvents txtRsNo As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtInstructions As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents DTPdateneeded As DateTimePicker
    Friend WithEvents Label10 As Label
    Friend WithEvents txtPrepared_by As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtChecked_by As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtApproved_by As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents cmbdr_option As ComboBox
    Friend WithEvents Label17 As Label
    Friend WithEvents txtRemarks As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents btnSave As Button
    Friend WithEvents Label19 As Label
    Friend WithEvents lblRsID As Label
End Class
