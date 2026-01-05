<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FPurchaseOrder
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
        Me.components = New System.ComponentModel.Container
        Me.btnExit = New System.Windows.Forms.Button
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtTerms = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtAddress = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.DTPTrans = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtPoNo = New System.Windows.Forms.TextBox
        Me.lblItemName = New System.Windows.Forms.Label
        Me.txtRsNo = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.dgPurchaseOrder = New System.Windows.Forms.DataGridView
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.rs_id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmbSupplier = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtInstructions = New System.Windows.Forms.TextBox
        Me.lblTotal = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtPrepared_by = New System.Windows.Forms.TextBox
        Me.txtChargeTo = New System.Windows.Forms.TextBox
        Me.DTPdateneeded = New System.Windows.Forms.DateTimePicker
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtChecked_by = New System.Windows.Forms.TextBox
        Me.txtApproved_by = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.btnSave = New System.Windows.Forms.Button
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.lblChargeToID = New System.Windows.Forms.Label
        Me.lblTypeOfReq = New System.Windows.Forms.Label
        Me.lblPoId = New System.Windows.Forms.Label
        Me.Panel_Supplier = New System.Windows.Forms.Panel
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtTerm = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.btn_Update = New System.Windows.Forms.Button
        Me.txt_SupplierLocation = New System.Windows.Forms.TextBox
        Me.lbl_SupplierLocation = New System.Windows.Forms.Label
        Me.lbl_SupplierName = New System.Windows.Forms.Label
        Me.Button3 = New System.Windows.Forms.Button
        Me.btnAdd = New System.Windows.Forms.Button
        Me.txt_SupplierName = New System.Windows.Forms.TextBox
        Me.lvList = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.CMS_lvList = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.lblReqType = New System.Windows.Forms.Label
        Me.lblInOut = New System.Windows.Forms.Label
        Me.lbox_data = New System.Windows.Forms.ListBox
        CType(Me.dgPurchaseOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel_Supplier.SuspendLayout()
        Me.CMS_lvList.SuspendLayout()
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
        Me.btnExit.Location = New System.Drawing.Point(940, 12)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(20, 20)
        Me.btnExit.TabIndex = 323
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(12, 9)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(171, 22)
        Me.Label15.TabIndex = 325
        Me.Label15.Text = "Purchase Order Form"
        '
        'txtTerms
        '
        Me.txtTerms.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTerms.Location = New System.Drawing.Point(399, 135)
        Me.txtTerms.Name = "txtTerms"
        Me.txtTerms.Size = New System.Drawing.Size(216, 24)
        Me.txtTerms.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(350, 140)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 15)
        Me.Label4.TabIndex = 361
        Me.Label4.Text = "Terms:"
        '
        'txtAddress
        '
        Me.txtAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddress.Location = New System.Drawing.Point(399, 102)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(216, 24)
        Me.txtAddress.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(338, 107)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 15)
        Me.Label3.TabIndex = 359
        Me.Label3.Text = "Address:"
        '
        'DTPTrans
        '
        Me.DTPTrans.CustomFormat = ""
        Me.DTPTrans.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPTrans.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPTrans.Location = New System.Drawing.Point(88, 102)
        Me.DTPTrans.Margin = New System.Windows.Forms.Padding(10, 3, 3, 3)
        Me.DTPTrans.Name = "DTPTrans"
        Me.DTPTrans.Size = New System.Drawing.Size(216, 26)
        Me.DTPTrans.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(26, 108)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 15)
        Me.Label1.TabIndex = 355
        Me.Label1.Text = "P.O. Date:"
        '
        'txtPoNo
        '
        Me.txtPoNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPoNo.Location = New System.Drawing.Point(88, 69)
        Me.txtPoNo.Name = "txtPoNo"
        Me.txtPoNo.Size = New System.Drawing.Size(216, 24)
        Me.txtPoNo.TabIndex = 1
        '
        'lblItemName
        '
        Me.lblItemName.AutoSize = True
        Me.lblItemName.BackColor = System.Drawing.Color.Transparent
        Me.lblItemName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItemName.ForeColor = System.Drawing.Color.White
        Me.lblItemName.Location = New System.Drawing.Point(40, 74)
        Me.lblItemName.Name = "lblItemName"
        Me.lblItemName.Size = New System.Drawing.Size(46, 15)
        Me.lblItemName.TabIndex = 353
        Me.lblItemName.Text = "P.O No."
        '
        'txtRsNo
        '
        Me.txtRsNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRsNo.Location = New System.Drawing.Point(88, 139)
        Me.txtRsNo.Name = "txtRsNo"
        Me.txtRsNo.ReadOnly = True
        Me.txtRsNo.Size = New System.Drawing.Size(216, 24)
        Me.txtRsNo.TabIndex = 3
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(36, 143)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(50, 15)
        Me.Label14.TabIndex = 384
        Me.Label14.Text = "R.S. No."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(339, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 15)
        Me.Label2.TabIndex = 357
        Me.Label2.Text = "Supplier:"
        '
        'dgPurchaseOrder
        '
        Me.dgPurchaseOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgPurchaseOrder.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column2, Me.rs_id})
        Me.dgPurchaseOrder.Location = New System.Drawing.Point(18, 268)
        Me.dgPurchaseOrder.Name = "dgPurchaseOrder"
        Me.dgPurchaseOrder.Size = New System.Drawing.Size(942, 260)
        Me.dgPurchaseOrder.TabIndex = 386
        '
        'Column1
        '
        Me.Column1.FillWeight = 1.0!
        Me.Column1.Frozen = True
        Me.Column1.HeaderText = "wh_id"
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 50
        '
        'Column3
        '
        Me.Column3.HeaderText = "Description"
        Me.Column3.Name = "Column3"
        Me.Column3.Width = 500
        '
        'Column4
        '
        Me.Column4.HeaderText = "Qty."
        Me.Column4.Name = "Column4"
        Me.Column4.Width = 60
        '
        'Column5
        '
        Me.Column5.HeaderText = "Unit"
        Me.Column5.Name = "Column5"
        '
        'Column6
        '
        Me.Column6.HeaderText = "Unit Price"
        Me.Column6.Name = "Column6"
        Me.Column6.Width = 104
        '
        'Column7
        '
        Me.Column7.HeaderText = "Amount"
        Me.Column7.Name = "Column7"
        Me.Column7.Width = 135
        '
        'Column2
        '
        Me.Column2.HeaderText = "po_item_id"
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 50
        '
        'rs_id
        '
        Me.rs_id.HeaderText = "rs_id"
        Me.rs_id.Name = "rs_id"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(608, 549)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(132, 24)
        Me.Label5.TabIndex = 387
        Me.Label5.Text = "Total Amount :"
        '
        'cmbSupplier
        '
        Me.cmbSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbSupplier.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSupplier.FormattingEnabled = True
        Me.cmbSupplier.Items.AddRange(New Object() {"Columbia Corp."})
        Me.cmbSupplier.Location = New System.Drawing.Point(399, 69)
        Me.cmbSupplier.Name = "cmbSupplier"
        Me.cmbSupplier.Size = New System.Drawing.Size(184, 24)
        Me.cmbSupplier.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(15, 174)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 15)
        Me.Label6.TabIndex = 390
        Me.Label6.Text = "Instruction:"
        '
        'txtInstructions
        '
        Me.txtInstructions.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInstructions.Location = New System.Drawing.Point(88, 172)
        Me.txtInstructions.Multiline = True
        Me.txtInstructions.Name = "txtInstructions"
        Me.txtInstructions.Size = New System.Drawing.Size(216, 65)
        Me.txtInstructions.TabIndex = 4
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.BackColor = System.Drawing.Color.Transparent
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.Color.LimeGreen
        Me.lblTotal.Location = New System.Drawing.Point(748, 550)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(45, 24)
        Me.lblTotal.TabIndex = 388
        Me.lblTotal.Text = "0.00"
        '
        'PictureBox1
        '
        Me.PictureBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.PictureBox1.BackColor = System.Drawing.Color.LightGray
        Me.PictureBox1.InitialImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(18, 246)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(942, 27)
        Me.PictureBox1.TabIndex = 394
        Me.PictureBox1.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.LightGray
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(416, 253)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(149, 16)
        Me.Label7.TabIndex = 395
        Me.Label7.Text = "Purchase Order Item"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(331, 172)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 15)
        Me.Label8.TabIndex = 357
        Me.Label8.Text = "Charge to:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(663, 110)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(79, 15)
        Me.Label10.TabIndex = 361
        Me.Label10.Text = "Prepared by:"
        '
        'txtPrepared_by
        '
        Me.txtPrepared_by.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrepared_by.Location = New System.Drawing.Point(744, 105)
        Me.txtPrepared_by.Name = "txtPrepared_by"
        Me.txtPrepared_by.Size = New System.Drawing.Size(216, 24)
        Me.txtPrepared_by.TabIndex = 10
        '
        'txtChargeTo
        '
        Me.txtChargeTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChargeTo.Location = New System.Drawing.Point(399, 167)
        Me.txtChargeTo.Name = "txtChargeTo"
        Me.txtChargeTo.ReadOnly = True
        Me.txtChargeTo.Size = New System.Drawing.Size(216, 24)
        Me.txtChargeTo.TabIndex = 8
        '
        'DTPdateneeded
        '
        Me.DTPdateneeded.CustomFormat = ""
        Me.DTPdateneeded.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPdateneeded.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPdateneeded.Location = New System.Drawing.Point(744, 69)
        Me.DTPdateneeded.Margin = New System.Windows.Forms.Padding(10, 3, 3, 3)
        Me.DTPdateneeded.Name = "DTPdateneeded"
        Me.DTPdateneeded.Size = New System.Drawing.Size(216, 26)
        Me.DTPdateneeded.TabIndex = 9
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(659, 76)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(82, 15)
        Me.Label11.TabIndex = 396
        Me.Label11.Text = "Date Needed:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(666, 143)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(76, 15)
        Me.Label9.TabIndex = 361
        Me.Label9.Text = "Checked by:"
        '
        'txtChecked_by
        '
        Me.txtChecked_by.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChecked_by.Location = New System.Drawing.Point(744, 137)
        Me.txtChecked_by.Name = "txtChecked_by"
        Me.txtChecked_by.Size = New System.Drawing.Size(216, 24)
        Me.txtChecked_by.TabIndex = 11
        '
        'txtApproved_by
        '
        Me.txtApproved_by.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtApproved_by.Location = New System.Drawing.Point(744, 168)
        Me.txtApproved_by.Name = "txtApproved_by"
        Me.txtApproved_by.Size = New System.Drawing.Size(216, 24)
        Me.txtApproved_by.TabIndex = 12
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(662, 174)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(80, 15)
        Me.Label12.TabIndex = 398
        Me.Label12.Text = "Approved by:"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(744, 200)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(216, 37)
        Me.btnSave.TabIndex = 400
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = Global.SUPPLY.My.Resources.Resources.Plus_sign
        Me.PictureBox2.Location = New System.Drawing.Point(589, 70)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(26, 23)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 402
        Me.PictureBox2.TabStop = False
        '
        'lblChargeToID
        '
        Me.lblChargeToID.AutoSize = True
        Me.lblChargeToID.Location = New System.Drawing.Point(1043, 67)
        Me.lblChargeToID.Name = "lblChargeToID"
        Me.lblChargeToID.Size = New System.Drawing.Size(13, 13)
        Me.lblChargeToID.TabIndex = 403
        Me.lblChargeToID.Text = "0"
        '
        'lblTypeOfReq
        '
        Me.lblTypeOfReq.AutoSize = True
        Me.lblTypeOfReq.Location = New System.Drawing.Point(1101, 68)
        Me.lblTypeOfReq.Name = "lblTypeOfReq"
        Me.lblTypeOfReq.Size = New System.Drawing.Size(13, 13)
        Me.lblTypeOfReq.TabIndex = 403
        Me.lblTypeOfReq.Text = "0"
        '
        'lblPoId
        '
        Me.lblPoId.AutoSize = True
        Me.lblPoId.Location = New System.Drawing.Point(1143, 67)
        Me.lblPoId.Name = "lblPoId"
        Me.lblPoId.Size = New System.Drawing.Size(13, 13)
        Me.lblPoId.TabIndex = 404
        Me.lblPoId.Text = "0"
        '
        'Panel_Supplier
        '
        Me.Panel_Supplier.BackgroundImage = Global.SUPPLY.My.Resources.Resources.bg_line
        Me.Panel_Supplier.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel_Supplier.Controls.Add(Me.Label16)
        Me.Panel_Supplier.Controls.Add(Me.txtTerm)
        Me.Panel_Supplier.Controls.Add(Me.Label13)
        Me.Panel_Supplier.Controls.Add(Me.btn_Update)
        Me.Panel_Supplier.Controls.Add(Me.txt_SupplierLocation)
        Me.Panel_Supplier.Controls.Add(Me.lbl_SupplierLocation)
        Me.Panel_Supplier.Controls.Add(Me.lbl_SupplierName)
        Me.Panel_Supplier.Controls.Add(Me.Button3)
        Me.Panel_Supplier.Controls.Add(Me.btnAdd)
        Me.Panel_Supplier.Controls.Add(Me.txt_SupplierName)
        Me.Panel_Supplier.Controls.Add(Me.lvList)
        Me.Panel_Supplier.Location = New System.Drawing.Point(242, 9)
        Me.Panel_Supplier.Name = "Panel_Supplier"
        Me.Panel_Supplier.Size = New System.Drawing.Size(471, 460)
        Me.Panel_Supplier.TabIndex = 405
        Me.Panel_Supplier.Visible = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(91, 389)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(58, 17)
        Me.Label16.TabIndex = 393
        Me.Label16.Text = "Terms:"
        '
        'txtTerm
        '
        Me.txtTerm.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTerm.Location = New System.Drawing.Point(155, 383)
        Me.txtTerm.Name = "txtTerm"
        Me.txtTerm.Size = New System.Drawing.Size(307, 23)
        Me.txtTerm.TabIndex = 392
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(16, 26)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(209, 13)
        Me.Label13.TabIndex = 391
        Me.Label13.Text = "Note: Double Click on list to select an item."
        '
        'btn_Update
        '
        Me.btn_Update.Enabled = False
        Me.btn_Update.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Update.Location = New System.Drawing.Point(317, 410)
        Me.btn_Update.Name = "btn_Update"
        Me.btn_Update.Size = New System.Drawing.Size(145, 36)
        Me.btn_Update.TabIndex = 4
        Me.btn_Update.Text = "Update"
        Me.btn_Update.UseVisualStyleBackColor = True
        '
        'txt_SupplierLocation
        '
        Me.txt_SupplierLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_SupplierLocation.Location = New System.Drawing.Point(155, 354)
        Me.txt_SupplierLocation.Name = "txt_SupplierLocation"
        Me.txt_SupplierLocation.Size = New System.Drawing.Size(307, 23)
        Me.txt_SupplierLocation.TabIndex = 2
        '
        'lbl_SupplierLocation
        '
        Me.lbl_SupplierLocation.AutoSize = True
        Me.lbl_SupplierLocation.BackColor = System.Drawing.Color.Transparent
        Me.lbl_SupplierLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_SupplierLocation.ForeColor = System.Drawing.Color.White
        Me.lbl_SupplierLocation.Location = New System.Drawing.Point(9, 360)
        Me.lbl_SupplierLocation.Name = "lbl_SupplierLocation"
        Me.lbl_SupplierLocation.Size = New System.Drawing.Size(140, 17)
        Me.lbl_SupplierLocation.TabIndex = 390
        Me.lbl_SupplierLocation.Text = "Supplier Location:"
        '
        'lbl_SupplierName
        '
        Me.lbl_SupplierName.AutoSize = True
        Me.lbl_SupplierName.BackColor = System.Drawing.Color.Transparent
        Me.lbl_SupplierName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_SupplierName.ForeColor = System.Drawing.Color.White
        Me.lbl_SupplierName.Location = New System.Drawing.Point(30, 328)
        Me.lbl_SupplierName.Name = "lbl_SupplierName"
        Me.lbl_SupplierName.Size = New System.Drawing.Size(119, 17)
        Me.lbl_SupplierName.TabIndex = 389
        Me.lbl_SupplierName.Text = "Supplier Name:"
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Transparent
        Me.Button3.BackgroundImage = Global.SUPPLY.My.Resources.Resources.close_button
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Location = New System.Drawing.Point(444, 8)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(20, 20)
        Me.Button3.TabIndex = 388
        Me.Button3.UseVisualStyleBackColor = False
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(155, 410)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(159, 36)
        Me.btnAdd.TabIndex = 3
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'txt_SupplierName
        '
        Me.txt_SupplierName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_SupplierName.Location = New System.Drawing.Point(155, 325)
        Me.txt_SupplierName.Name = "txt_SupplierName"
        Me.txt_SupplierName.Size = New System.Drawing.Size(307, 23)
        Me.txt_SupplierName.TabIndex = 0
        '
        'lvList
        '
        Me.lvList.BackColor = System.Drawing.SystemColors.Window
        Me.lvList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.lvList.ContextMenuStrip = Me.CMS_lvList
        Me.lvList.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvList.FullRowSelect = True
        Me.lvList.GridLines = True
        Me.lvList.HideSelection = False
        Me.lvList.Location = New System.Drawing.Point(5, 48)
        Me.lvList.Name = "lvList"
        Me.lvList.Size = New System.Drawing.Size(457, 271)
        Me.lvList.TabIndex = 7
        Me.lvList.UseCompatibleStateImageBehavior = False
        Me.lvList.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Supplier Id"
        Me.ColumnHeader1.Width = 0
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Supplier Name"
        Me.ColumnHeader2.Width = 170
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Supplier Location"
        Me.ColumnHeader3.Width = 290
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Terms"
        '
        'CMS_lvList
        '
        Me.CMS_lvList.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.CMS_lvList.Name = "ContextMenuStrip1"
        Me.CMS_lvList.Size = New System.Drawing.Size(107, 48)
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(106, 22)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(106, 22)
        Me.DeleteToolStripMenuItem.Text = "delete"
        '
        'lblReqType
        '
        Me.lblReqType.AutoSize = True
        Me.lblReqType.Location = New System.Drawing.Point(1074, 118)
        Me.lblReqType.Name = "lblReqType"
        Me.lblReqType.Size = New System.Drawing.Size(0, 13)
        Me.lblReqType.TabIndex = 406
        '
        'lblInOut
        '
        Me.lblInOut.AutoSize = True
        Me.lblInOut.Location = New System.Drawing.Point(1074, 139)
        Me.lblInOut.Name = "lblInOut"
        Me.lblInOut.Size = New System.Drawing.Size(0, 13)
        Me.lblInOut.TabIndex = 406
        '
        'lbox_data
        '
        Me.lbox_data.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbox_data.FormattingEnabled = True
        Me.lbox_data.ItemHeight = 16
        Me.lbox_data.Location = New System.Drawing.Point(1046, 283)
        Me.lbox_data.Name = "lbox_data"
        Me.lbox_data.Size = New System.Drawing.Size(216, 68)
        Me.lbox_data.TabIndex = 407
        Me.lbox_data.Visible = False
        '
        'FPurchaseOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SUPPLY.My.Resources.Resources.bg_line
        Me.ClientSize = New System.Drawing.Size(980, 592)
        Me.Controls.Add(Me.lbox_data)
        Me.Controls.Add(Me.lblInOut)
        Me.Controls.Add(Me.lblReqType)
        Me.Controls.Add(Me.lblPoId)
        Me.Controls.Add(Me.Panel_Supplier)
        Me.Controls.Add(Me.lblTypeOfReq)
        Me.Controls.Add(Me.lblChargeToID)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtApproved_by)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.DTPdateneeded)
        Me.Controls.Add(Me.dgPurchaseOrder)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.cmbSupplier)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtInstructions)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtRsNo)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtChecked_by)
        Me.Controls.Add(Me.txtPrepared_by)
        Me.Controls.Add(Me.txtTerms)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtChargeTo)
        Me.Controls.Add(Me.txtAddress)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DTPTrans)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtPoNo)
        Me.Controls.Add(Me.lblItemName)
        Me.Controls.Add(Me.btnExit)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FPurchaseOrder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        CType(Me.dgPurchaseOrder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel_Supplier.ResumeLayout(False)
        Me.Panel_Supplier.PerformLayout()
        Me.CMS_lvList.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtTerms As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DTPTrans As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPoNo As System.Windows.Forms.TextBox
    Friend WithEvents lblItemName As System.Windows.Forms.Label
    Friend WithEvents txtRsNo As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgPurchaseOrder As System.Windows.Forms.DataGridView
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbSupplier As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtInstructions As System.Windows.Forms.TextBox
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtPrepared_by As System.Windows.Forms.TextBox
    Friend WithEvents txtChargeTo As System.Windows.Forms.TextBox
    Friend WithEvents DTPdateneeded As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtChecked_by As System.Windows.Forms.TextBox
    Friend WithEvents txtApproved_by As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents lblChargeToID As System.Windows.Forms.Label
    Friend WithEvents lblTypeOfReq As System.Windows.Forms.Label
    Friend WithEvents lblPoId As System.Windows.Forms.Label
    Friend WithEvents Panel_Supplier As System.Windows.Forms.Panel
    Friend WithEvents btn_Update As System.Windows.Forms.Button
    Friend WithEvents txt_SupplierLocation As System.Windows.Forms.TextBox
    Friend WithEvents lbl_SupplierLocation As System.Windows.Forms.Label
    Friend WithEvents lbl_SupplierName As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents txt_SupplierName As System.Windows.Forms.TextBox
    Friend WithEvents lvList As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents CMS_lvList As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rs_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblReqType As System.Windows.Forms.Label
    Friend WithEvents lblInOut As System.Windows.Forms.Label
    Friend WithEvents lbox_data As System.Windows.Forms.ListBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtTerm As System.Windows.Forms.TextBox
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
End Class
