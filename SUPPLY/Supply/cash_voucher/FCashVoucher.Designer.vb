<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FCashVoucher
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
        Me.btnExit = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblItemName = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.dgCashVoucherItems = New System.Windows.Forms.DataGridView()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.wh_item = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Remarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rsid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.txtCVno = New System.Windows.Forms.TextBox()
        Me.txtReceivedby = New System.Windows.Forms.TextBox()
        Me.DTPVoucher = New System.Windows.Forms.DateTimePicker()
        Me.cmbSupplier = New System.Windows.Forms.ComboBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtRSNo = New System.Windows.Forms.TextBox()
        Me.txtChargeTo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblTotalAmount = New System.Windows.Forms.Label()
        Me.lbl_cv_info_id = New System.Windows.Forms.Label()
        Me.txtChargeToID = New System.Windows.Forms.TextBox()
        Me.lbl_rs_id = New System.Windows.Forms.Label()
        Me.panel_chargeTo = New System.Windows.Forms.Panel()
        Me.lbl_supplierID = New System.Windows.Forms.Label()
        Me.btn_update = New System.Windows.Forms.Button()
        Me.btn_save = New System.Windows.Forms.Button()
        Me.txt_location = New System.Windows.Forms.TextBox()
        Me.lbl_location = New System.Windows.Forms.Label()
        Me.txt_supplier_name = New System.Windows.Forms.TextBox()
        Me.lbl_supplier_name = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lvl_chargeto = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cms_chargeto = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmb_chargeto = New System.Windows.Forms.ComboBox()
        Me.txt_proj_equp_id = New System.Windows.Forms.TextBox()
        Me.lbox_cash_voucher = New System.Windows.Forms.ListBox()
        Me.panel_brand = New System.Windows.Forms.Panel()
        Me.btn_select = New System.Windows.Forms.Button()
        Me.cmb_brand = New System.Windows.Forms.ComboBox()
        Me.Btn_exit = New System.Windows.Forms.Button()
        Me.Timer_panel = New System.Windows.Forms.Timer(Me.components)
        Me.txt_inputnumeric = New System.Windows.Forms.TextBox()
        Me.lblTypeOfReq = New System.Windows.Forms.Label()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgCashVoucherItems, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel_chargeTo.SuspendLayout()
        Me.cms_chargeto.SuspendLayout()
        Me.panel_brand.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.Transparent
        Me.btnExit.BackgroundImage = Global.SUPPLY.My.Resources.Resources.close_button
        Me.btnExit.FlatAppearance.BorderSize = 0
        Me.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit.Location = New System.Drawing.Point(673, 7)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(20, 20)
        Me.btnExit.TabIndex = 363
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(7, 7)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(113, 22)
        Me.Label15.TabIndex = 362
        Me.Label15.Text = "Cash Voucher"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(30, 52)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(49, 15)
        Me.Label12.TabIndex = 426
        Me.Label12.Text = "Paid to:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(361, 91)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 15)
        Me.Label6.TabIndex = 436
        Me.Label6.Text = "Received by:"
        '
        'lblItemName
        '
        Me.lblItemName.AutoSize = True
        Me.lblItemName.BackColor = System.Drawing.Color.Transparent
        Me.lblItemName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItemName.ForeColor = System.Drawing.Color.White
        Me.lblItemName.Location = New System.Drawing.Point(30, 125)
        Me.lblItemName.Name = "lblItemName"
        Me.lblItemName.Size = New System.Drawing.Size(49, 15)
        Me.lblItemName.TabIndex = 435
        Me.lblItemName.Text = "C.V. No."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(353, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 15)
        Me.Label1.TabIndex = 438
        Me.Label1.Text = "Date Voucher:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.LightGray
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(318, 176)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(42, 15)
        Me.Label8.TabIndex = 442
        Me.Label8.Text = "Items"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = Global.SUPPLY.My.Resources.Resources.Plus_sign
        Me.PictureBox2.Location = New System.Drawing.Point(269, 48)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(26, 23)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 443
        Me.PictureBox2.TabStop = False
        '
        'dgCashVoucherItems
        '
        Me.dgCashVoucherItems.AllowUserToAddRows = False
        Me.dgCashVoucherItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgCashVoucherItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column5, Me.Column9, Me.Column1, Me.wh_item, Me.Column7, Me.Column8, Me.Column2, Me.Column4, Me.Column3, Me.Column6, Me.Remarks, Me.rsid})
        Me.dgCashVoucherItems.Location = New System.Drawing.Point(11, 193)
        Me.dgCashVoucherItems.Name = "dgCashVoucherItems"
        Me.dgCashVoucherItems.Size = New System.Drawing.Size(681, 260)
        Me.dgCashVoucherItems.TabIndex = 420
        '
        'Column5
        '
        Me.Column5.HeaderText = "id"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Visible = False
        Me.Column5.Width = 30
        '
        'Column9
        '
        Me.Column9.HeaderText = "Checkbox"
        Me.Column9.Name = "Column9"
        Me.Column9.Width = 60
        '
        'Column1
        '
        Me.Column1.FillWeight = 1.0!
        Me.Column1.HeaderText = "wh_id"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Visible = False
        Me.Column1.Width = 50
        '
        'wh_item
        '
        Me.wh_item.HeaderText = "Item Name"
        Me.wh_item.Name = "wh_item"
        Me.wh_item.ReadOnly = True
        Me.wh_item.Width = 130
        '
        'Column7
        '
        Me.Column7.HeaderText = "Description"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Width = 150
        '
        'Column8
        '
        Me.Column8.HeaderText = "Charge To"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Width = 130
        '
        'Column2
        '
        Me.Column2.HeaderText = "Quantity"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 60
        '
        'Column4
        '
        Me.Column4.HeaderText = "Amount"
        Me.Column4.Name = "Column4"
        '
        'Column3
        '
        Me.Column3.HeaderText = "Total"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.HeaderText = "Charge To"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Visible = False
        '
        'Remarks
        '
        Me.Remarks.HeaderText = "Remarks"
        Me.Remarks.Name = "Remarks"
        Me.Remarks.ReadOnly = True
        Me.Remarks.Visible = False
        Me.Remarks.Width = 50
        '
        'rsid
        '
        Me.rsid.HeaderText = "rsid"
        Me.rsid.Name = "rsid"
        Me.rsid.ReadOnly = True
        Me.rsid.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.PictureBox1.BackColor = System.Drawing.Color.LightGray
        Me.PictureBox1.InitialImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(11, 171)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(682, 27)
        Me.PictureBox1.TabIndex = 441
        Me.PictureBox1.TabStop = False
        '
        'txtCVno
        '
        Me.txtCVno.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCVno.Location = New System.Drawing.Point(82, 120)
        Me.txtCVno.Name = "txtCVno"
        Me.txtCVno.Size = New System.Drawing.Size(216, 24)
        Me.txtCVno.TabIndex = 417
        '
        'txtReceivedby
        '
        Me.txtReceivedby.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReceivedby.Location = New System.Drawing.Point(442, 85)
        Me.txtReceivedby.Name = "txtReceivedby"
        Me.txtReceivedby.Size = New System.Drawing.Size(216, 24)
        Me.txtReceivedby.TabIndex = 419
        '
        'DTPVoucher
        '
        Me.DTPVoucher.CustomFormat = ""
        Me.DTPVoucher.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPVoucher.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPVoucher.Location = New System.Drawing.Point(442, 48)
        Me.DTPVoucher.Margin = New System.Windows.Forms.Padding(10, 3, 3, 3)
        Me.DTPVoucher.Name = "DTPVoucher"
        Me.DTPVoucher.Size = New System.Drawing.Size(216, 26)
        Me.DTPVoucher.TabIndex = 418
        '
        'cmbSupplier
        '
        Me.cmbSupplier.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSupplier.FormattingEnabled = True
        Me.cmbSupplier.Location = New System.Drawing.Point(82, 48)
        Me.cmbSupplier.Name = "cmbSupplier"
        Me.cmbSupplier.Size = New System.Drawing.Size(184, 24)
        Me.cmbSupplier.TabIndex = 416
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(603, 473)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(89, 37)
        Me.btnSave.TabIndex = 439
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(29, 87)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 15)
        Me.Label3.TabIndex = 446
        Me.Label3.Text = "R.S. No."
        '
        'txtRSNo
        '
        Me.txtRSNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRSNo.Location = New System.Drawing.Point(82, 83)
        Me.txtRSNo.Name = "txtRSNo"
        Me.txtRSNo.Size = New System.Drawing.Size(216, 24)
        Me.txtRSNo.TabIndex = 444
        '
        'txtChargeTo
        '
        Me.txtChargeTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChargeTo.Location = New System.Drawing.Point(946, 429)
        Me.txtChargeTo.Name = "txtChargeTo"
        Me.txtChargeTo.ReadOnly = True
        Me.txtChargeTo.Size = New System.Drawing.Size(216, 24)
        Me.txtChargeTo.TabIndex = 447
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(878, 434)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 15)
        Me.Label2.TabIndex = 448
        Me.Label2.Text = "Charge to:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(8, 461)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 18)
        Me.Label4.TabIndex = 436
        Me.Label4.Text = "TOTAL:"
        '
        'lblTotalAmount
        '
        Me.lblTotalAmount.AutoSize = True
        Me.lblTotalAmount.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalAmount.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalAmount.ForeColor = System.Drawing.Color.Lime
        Me.lblTotalAmount.Location = New System.Drawing.Point(72, 460)
        Me.lblTotalAmount.Name = "lblTotalAmount"
        Me.lblTotalAmount.Size = New System.Drawing.Size(40, 19)
        Me.lblTotalAmount.TabIndex = 436
        Me.lblTotalAmount.Text = "0.00"
        '
        'lbl_cv_info_id
        '
        Me.lbl_cv_info_id.AutoSize = True
        Me.lbl_cv_info_id.Location = New System.Drawing.Point(947, 76)
        Me.lbl_cv_info_id.Name = "lbl_cv_info_id"
        Me.lbl_cv_info_id.Size = New System.Drawing.Size(56, 13)
        Me.lbl_cv_info_id.TabIndex = 449
        Me.lbl_cv_info_id.Text = "cv_info_id"
        '
        'txtChargeToID
        '
        Me.txtChargeToID.Location = New System.Drawing.Point(946, 120)
        Me.txtChargeToID.Name = "txtChargeToID"
        Me.txtChargeToID.Size = New System.Drawing.Size(100, 20)
        Me.txtChargeToID.TabIndex = 450
        '
        'lbl_rs_id
        '
        Me.lbl_rs_id.AutoSize = True
        Me.lbl_rs_id.Location = New System.Drawing.Point(949, 175)
        Me.lbl_rs_id.Name = "lbl_rs_id"
        Me.lbl_rs_id.Size = New System.Drawing.Size(29, 13)
        Me.lbl_rs_id.TabIndex = 451
        Me.lbl_rs_id.Text = "rs_id"
        '
        'panel_chargeTo
        '
        Me.panel_chargeTo.BackColor = System.Drawing.Color.Transparent
        Me.panel_chargeTo.Controls.Add(Me.lbl_supplierID)
        Me.panel_chargeTo.Controls.Add(Me.btn_update)
        Me.panel_chargeTo.Controls.Add(Me.btn_save)
        Me.panel_chargeTo.Controls.Add(Me.txt_location)
        Me.panel_chargeTo.Controls.Add(Me.lbl_location)
        Me.panel_chargeTo.Controls.Add(Me.txt_supplier_name)
        Me.panel_chargeTo.Controls.Add(Me.lbl_supplier_name)
        Me.panel_chargeTo.Controls.Add(Me.Label13)
        Me.panel_chargeTo.Controls.Add(Me.Button1)
        Me.panel_chargeTo.Controls.Add(Me.lvl_chargeto)
        Me.panel_chargeTo.Location = New System.Drawing.Point(132, 59)
        Me.panel_chargeTo.Name = "panel_chargeTo"
        Me.panel_chargeTo.Size = New System.Drawing.Size(447, 420)
        Me.panel_chargeTo.TabIndex = 452
        '
        'lbl_supplierID
        '
        Me.lbl_supplierID.AutoSize = True
        Me.lbl_supplierID.ForeColor = System.Drawing.Color.White
        Me.lbl_supplierID.Location = New System.Drawing.Point(535, 143)
        Me.lbl_supplierID.Name = "lbl_supplierID"
        Me.lbl_supplierID.Size = New System.Drawing.Size(39, 13)
        Me.lbl_supplierID.TabIndex = 461
        Me.lbl_supplierID.Text = "Label5"
        '
        'btn_update
        '
        Me.btn_update.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_update.Location = New System.Drawing.Point(286, 373)
        Me.btn_update.Name = "btn_update"
        Me.btn_update.Size = New System.Drawing.Size(146, 34)
        Me.btn_update.TabIndex = 460
        Me.btn_update.Text = "Update"
        Me.btn_update.UseVisualStyleBackColor = True
        '
        'btn_save
        '
        Me.btn_save.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_save.Location = New System.Drawing.Point(132, 373)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(146, 34)
        Me.btn_save.TabIndex = 459
        Me.btn_save.Text = "Save"
        Me.btn_save.UseVisualStyleBackColor = True
        '
        'txt_location
        '
        Me.txt_location.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_location.Location = New System.Drawing.Point(132, 347)
        Me.txt_location.Name = "txt_location"
        Me.txt_location.Size = New System.Drawing.Size(300, 22)
        Me.txt_location.TabIndex = 458
        '
        'lbl_location
        '
        Me.lbl_location.AutoSize = True
        Me.lbl_location.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_location.ForeColor = System.Drawing.Color.Transparent
        Me.lbl_location.Location = New System.Drawing.Point(11, 350)
        Me.lbl_location.Name = "lbl_location"
        Me.lbl_location.Size = New System.Drawing.Size(71, 16)
        Me.lbl_location.TabIndex = 457
        Me.lbl_location.Text = "Location:"
        '
        'txt_supplier_name
        '
        Me.txt_supplier_name.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_supplier_name.Location = New System.Drawing.Point(132, 319)
        Me.txt_supplier_name.Name = "txt_supplier_name"
        Me.txt_supplier_name.Size = New System.Drawing.Size(300, 22)
        Me.txt_supplier_name.TabIndex = 456
        '
        'lbl_supplier_name
        '
        Me.lbl_supplier_name.AutoSize = True
        Me.lbl_supplier_name.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_supplier_name.ForeColor = System.Drawing.Color.Transparent
        Me.lbl_supplier_name.Location = New System.Drawing.Point(11, 320)
        Me.lbl_supplier_name.Name = "lbl_supplier_name"
        Me.lbl_supplier_name.Size = New System.Drawing.Size(115, 16)
        Me.lbl_supplier_name.TabIndex = 455
        Me.lbl_supplier_name.Text = "Supplier Name:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(11, 16)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(209, 13)
        Me.Label13.TabIndex = 454
        Me.Label13.Text = "Note: Double Click on list to select an item."
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.BackgroundImage = Global.SUPPLY.My.Resources.Resources.close_button
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(412, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(20, 20)
        Me.Button1.TabIndex = 453
        Me.Button1.UseVisualStyleBackColor = False
        '
        'lvl_chargeto
        '
        Me.lvl_chargeto.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.lvl_chargeto.ContextMenuStrip = Me.cms_chargeto
        Me.lvl_chargeto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvl_chargeto.FullRowSelect = True
        Me.lvl_chargeto.GridLines = True
        Me.lvl_chargeto.HideSelection = False
        Me.lvl_chargeto.Location = New System.Drawing.Point(14, 44)
        Me.lvl_chargeto.Name = "lvl_chargeto"
        Me.lvl_chargeto.Size = New System.Drawing.Size(418, 267)
        Me.lvl_chargeto.TabIndex = 0
        Me.lvl_chargeto.UseCompatibleStateImageBehavior = False
        Me.lvl_chargeto.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Id"
        Me.ColumnHeader1.Width = 0
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Supplier Name"
        Me.ColumnHeader2.Width = 220
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Location"
        Me.ColumnHeader3.Width = 190
        '
        'cms_chargeto
        '
        Me.cms_chargeto.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.cms_chargeto.Name = "cms_chargeto"
        Me.cms_chargeto.Size = New System.Drawing.Size(108, 48)
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'cmb_chargeto
        '
        Me.cmb_chargeto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_chargeto.FormattingEnabled = True
        Me.cmb_chargeto.Location = New System.Drawing.Point(935, 263)
        Me.cmb_chargeto.Name = "cmb_chargeto"
        Me.cmb_chargeto.Size = New System.Drawing.Size(216, 24)
        Me.cmb_chargeto.TabIndex = 453
        '
        'txt_proj_equp_id
        '
        Me.txt_proj_equp_id.Location = New System.Drawing.Point(946, 217)
        Me.txt_proj_equp_id.Name = "txt_proj_equp_id"
        Me.txt_proj_equp_id.Size = New System.Drawing.Size(100, 20)
        Me.txt_proj_equp_id.TabIndex = 454
        '
        'lbox_cash_voucher
        '
        Me.lbox_cash_voucher.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbox_cash_voucher.FormattingEnabled = True
        Me.lbox_cash_voucher.ItemHeight = 16
        Me.lbox_cash_voucher.Location = New System.Drawing.Point(946, 293)
        Me.lbox_cash_voucher.Name = "lbox_cash_voucher"
        Me.lbox_cash_voucher.Size = New System.Drawing.Size(205, 84)
        Me.lbox_cash_voucher.TabIndex = 456
        '
        'panel_brand
        '
        Me.panel_brand.Controls.Add(Me.btn_select)
        Me.panel_brand.Controls.Add(Me.cmb_brand)
        Me.panel_brand.Controls.Add(Me.Btn_exit)
        Me.panel_brand.Location = New System.Drawing.Point(1249, 217)
        Me.panel_brand.Name = "panel_brand"
        Me.panel_brand.Size = New System.Drawing.Size(216, 100)
        Me.panel_brand.TabIndex = 457
        '
        'btn_select
        '
        Me.btn_select.Location = New System.Drawing.Point(143, 68)
        Me.btn_select.Name = "btn_select"
        Me.btn_select.Size = New System.Drawing.Size(68, 26)
        Me.btn_select.TabIndex = 460
        Me.btn_select.Text = "Select"
        Me.btn_select.UseVisualStyleBackColor = True
        '
        'cmb_brand
        '
        Me.cmb_brand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_brand.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_brand.FormattingEnabled = True
        Me.cmb_brand.Location = New System.Drawing.Point(6, 38)
        Me.cmb_brand.Name = "cmb_brand"
        Me.cmb_brand.Size = New System.Drawing.Size(205, 24)
        Me.cmb_brand.TabIndex = 459
        '
        'Btn_exit
        '
        Me.Btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_exit.Location = New System.Drawing.Point(188, 3)
        Me.Btn_exit.Name = "Btn_exit"
        Me.Btn_exit.Size = New System.Drawing.Size(23, 23)
        Me.Btn_exit.TabIndex = 458
        Me.Btn_exit.Text = "x"
        Me.Btn_exit.UseVisualStyleBackColor = True
        '
        'Timer_panel
        '
        '
        'txt_inputnumeric
        '
        Me.txt_inputnumeric.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_inputnumeric.Location = New System.Drawing.Point(342, 856)
        Me.txt_inputnumeric.Name = "txt_inputnumeric"
        Me.txt_inputnumeric.Size = New System.Drawing.Size(146, 22)
        Me.txt_inputnumeric.TabIndex = 458
        '
        'lblTypeOfReq
        '
        Me.lblTypeOfReq.AutoSize = True
        Me.lblTypeOfReq.Location = New System.Drawing.Point(949, 473)
        Me.lblTypeOfReq.Name = "lblTypeOfReq"
        Me.lblTypeOfReq.Size = New System.Drawing.Size(71, 13)
        Me.lblTypeOfReq.TabIndex = 459
        Me.lblTypeOfReq.Text = "typeofrequest"
        '
        'FCashVoucher
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SUPPLY.My.Resources.Resources.bg_line
        Me.ClientSize = New System.Drawing.Size(704, 522)
        Me.Controls.Add(Me.lblTypeOfReq)
        Me.Controls.Add(Me.panel_chargeTo)
        Me.Controls.Add(Me.panel_brand)
        Me.Controls.Add(Me.txt_inputnumeric)
        Me.Controls.Add(Me.lbox_cash_voucher)
        Me.Controls.Add(Me.txt_proj_equp_id)
        Me.Controls.Add(Me.cmb_chargeto)
        Me.Controls.Add(Me.lbl_rs_id)
        Me.Controls.Add(Me.txtChargeToID)
        Me.Controls.Add(Me.lbl_cv_info_id)
        Me.Controls.Add(Me.txtChargeTo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.txtRSNo)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.dgCashVoucherItems)
        Me.Controls.Add(Me.lblTotalAmount)
        Me.Controls.Add(Me.DTPVoucher)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtReceivedby)
        Me.Controls.Add(Me.txtCVno)
        Me.Controls.Add(Me.lblItemName)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbSupplier)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.Label15)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FCashVoucher"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FCashVoucher"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgCashVoucherItems, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel_chargeTo.ResumeLayout(False)
        Me.panel_chargeTo.PerformLayout()
        Me.cms_chargeto.ResumeLayout(False)
        Me.panel_brand.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblItemName As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents dgCashVoucherItems As System.Windows.Forms.DataGridView
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents txtCVno As System.Windows.Forms.TextBox
    Friend WithEvents txtReceivedby As System.Windows.Forms.TextBox
    Friend WithEvents DTPVoucher As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbSupplier As System.Windows.Forms.ComboBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtRSNo As System.Windows.Forms.TextBox
    Friend WithEvents txtChargeTo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblTotalAmount As System.Windows.Forms.Label
    Friend WithEvents lbl_cv_info_id As System.Windows.Forms.Label
    Friend WithEvents txtChargeToID As System.Windows.Forms.TextBox
    Friend WithEvents lbl_rs_id As System.Windows.Forms.Label
    Friend WithEvents panel_chargeTo As System.Windows.Forms.Panel
    Friend WithEvents lvl_chargeto As System.Windows.Forms.ListView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cmb_chargeto As System.Windows.Forms.ComboBox
    Friend WithEvents txt_proj_equp_id As System.Windows.Forms.TextBox
    Friend WithEvents lbox_cash_voucher As System.Windows.Forms.ListBox
    Friend WithEvents panel_brand As System.Windows.Forms.Panel
    Friend WithEvents Btn_exit As System.Windows.Forms.Button
    Friend WithEvents cmb_brand As System.Windows.Forms.ComboBox
    Friend WithEvents btn_select As System.Windows.Forms.Button
    Friend WithEvents Timer_panel As System.Windows.Forms.Timer
    Friend WithEvents txt_inputnumeric As System.Windows.Forms.TextBox
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lbl_supplier_name As System.Windows.Forms.Label
    Friend WithEvents txt_location As System.Windows.Forms.TextBox
    Friend WithEvents lbl_location As System.Windows.Forms.Label
    Friend WithEvents txt_supplier_name As System.Windows.Forms.TextBox
    Friend WithEvents btn_update As System.Windows.Forms.Button
    Friend WithEvents btn_save As System.Windows.Forms.Button
    Friend WithEvents cms_chargeto As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lbl_supplierID As System.Windows.Forms.Label
    Friend WithEvents lblTypeOfReq As System.Windows.Forms.Label
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents wh_item As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Remarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rsid As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
