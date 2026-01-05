<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FWithdrawalSlip
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
        Me.Label15 = New System.Windows.Forms.Label()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.txtChargeto = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtLocation = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtWSNo = New System.Windows.Forms.TextBox()
        Me.lblItemName = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtRSNo = New System.Windows.Forms.TextBox()
        Me.DTPDateWithdraw = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.dgWithdrawItems = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rs_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.txtWithdrawby = New System.Windows.Forms.TextBox()
        Me.lbl_withdraw = New System.Windows.Forms.Label()
        Me.txtReleasedby = New System.Windows.Forms.TextBox()
        Me.txtWithdrawFrom = New System.Windows.Forms.TextBox()
        Me.lbl_released = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lbl_withdrawInfoID = New System.Windows.Forms.Label()
        Me.lblRs_no = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.lblchargeTo_id = New System.Windows.Forms.Label()
        Me.Panel_chargeTo = New System.Windows.Forms.Panel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lvList = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txt_Search = New System.Windows.Forms.TextBox()
        Me.lvlSearchItem = New System.Windows.Forms.Label()
        Me.FWithdrawalSlip_ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.lbox_withdrawby = New System.Windows.Forms.ListBox()
        Me.Timer_panelmvemEnt = New System.Windows.Forms.Timer(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtProcess = New System.Windows.Forms.TextBox()
        Me.lbl_ws_info_id = New System.Windows.Forms.Label()
        Me.lbl_reqID = New System.Windows.Forms.Label()
        Me.txtReqID = New System.Windows.Forms.TextBox()
        Me.cmb_chargeto = New System.Windows.Forms.ComboBox()
        Me.lbl_rs_id = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgWithdrawItems, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel_chargeTo.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(12, 10)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(127, 22)
        Me.Label15.TabIndex = 361
        Me.Label15.Text = "Withdrawal Slip"
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.Transparent
        Me.btnExit.BackgroundImage = Global.SUPPLY.My.Resources.Resources.close_button
        Me.btnExit.FlatAppearance.BorderSize = 0
        Me.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit.Location = New System.Drawing.Point(648, 10)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(20, 20)
        Me.btnExit.TabIndex = 362
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'txtChargeto
        '
        Me.txtChargeto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChargeto.Location = New System.Drawing.Point(868, 449)
        Me.txtChargeto.Name = "txtChargeto"
        Me.txtChargeto.ReadOnly = True
        Me.txtChargeto.Size = New System.Drawing.Size(216, 24)
        Me.txtChargeto.TabIndex = 2
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(800, 454)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 15)
        Me.Label8.TabIndex = 364
        Me.Label8.Text = "Charge to:"
        '
        'txtLocation
        '
        Me.txtLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLocation.Location = New System.Drawing.Point(94, 89)
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.Size = New System.Drawing.Size(216, 24)
        Me.txtLocation.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(26, 93)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 15)
        Me.Label4.TabIndex = 365
        Me.Label4.Text = "Location:"
        '
        'txtWSNo
        '
        Me.txtWSNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWSNo.Location = New System.Drawing.Point(94, 55)
        Me.txtWSNo.Name = "txtWSNo"
        Me.txtWSNo.Size = New System.Drawing.Size(216, 24)
        Me.txtWSNo.TabIndex = 1
        '
        'lblItemName
        '
        Me.lblItemName.AutoSize = True
        Me.lblItemName.BackColor = System.Drawing.Color.Transparent
        Me.lblItemName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItemName.ForeColor = System.Drawing.Color.White
        Me.lblItemName.Location = New System.Drawing.Point(41, 60)
        Me.lblItemName.Name = "lblItemName"
        Me.lblItemName.Size = New System.Drawing.Size(53, 15)
        Me.lblItemName.TabIndex = 368
        Me.lblItemName.Text = "W.S. No."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(41, 127)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 15)
        Me.Label1.TabIndex = 368
        Me.Label1.Text = "R.S. No."
        '
        'txtRSNo
        '
        Me.txtRSNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRSNo.Location = New System.Drawing.Point(94, 122)
        Me.txtRSNo.Name = "txtRSNo"
        Me.txtRSNo.Size = New System.Drawing.Size(216, 24)
        Me.txtRSNo.TabIndex = 4
        '
        'DTPDateWithdraw
        '
        Me.DTPDateWithdraw.CustomFormat = ""
        Me.DTPDateWithdraw.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPDateWithdraw.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPDateWithdraw.Location = New System.Drawing.Point(440, 54)
        Me.DTPDateWithdraw.Margin = New System.Windows.Forms.Padding(10, 3, 3, 3)
        Me.DTPDateWithdraw.Name = "DTPDateWithdraw"
        Me.DTPDateWithdraw.Size = New System.Drawing.Size(216, 26)
        Me.DTPDateWithdraw.TabIndex = 5
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(355, 60)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(82, 15)
        Me.Label11.TabIndex = 398
        Me.Label11.Text = "Date Needed:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.LightGray
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(298, 195)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 15)
        Me.Label2.TabIndex = 401
        Me.Label2.Text = "Withdraw Items"
        '
        'PictureBox1
        '
        Me.PictureBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.PictureBox1.BackColor = System.Drawing.Color.LightGray
        Me.PictureBox1.InitialImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(16, 190)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(648, 27)
        Me.PictureBox1.TabIndex = 400
        Me.PictureBox1.TabStop = False
        '
        'dgWithdrawItems
        '
        Me.dgWithdrawItems.AllowUserToAddRows = False
        Me.dgWithdrawItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgWithdrawItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column5, Me.Column2, Me.Column3, Me.Column4, Me.Column7, Me.Column6, Me.rs_id, Me.Column8})
        Me.dgWithdrawItems.Location = New System.Drawing.Point(16, 212)
        Me.dgWithdrawItems.Name = "dgWithdrawItems"
        Me.dgWithdrawItems.Size = New System.Drawing.Size(648, 260)
        Me.dgWithdrawItems.TabIndex = 399
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
        'Column5
        '
        Me.Column5.HeaderText = ""
        Me.Column5.Name = "Column5"
        Me.Column5.Width = 50
        '
        'Column2
        '
        Me.Column2.HeaderText = "Quantity"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 50
        '
        'Column3
        '
        Me.Column3.HeaderText = "Unit"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column3.Width = 50
        '
        'Column4
        '
        Me.Column4.HeaderText = "Item Name"
        Me.Column4.Name = "Column4"
        Me.Column4.Width = 150
        '
        'Column7
        '
        Me.Column7.HeaderText = "Description"
        Me.Column7.Name = "Column7"
        Me.Column7.Visible = False
        Me.Column7.Width = 200
        '
        'Column6
        '
        Me.Column6.HeaderText = "Charge To"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 200
        '
        'rs_id
        '
        Me.rs_id.HeaderText = "rs_id"
        Me.rs_id.Name = "rs_id"
        Me.rs_id.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'Column8
        '
        Me.Column8.HeaderText = "ws_item_id"
        Me.Column8.Name = "Column8"
        Me.Column8.Visible = False
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(575, 478)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(89, 37)
        Me.btnSave.TabIndex = 402
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'txtWithdrawby
        '
        Me.txtWithdrawby.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWithdrawby.Location = New System.Drawing.Point(440, 122)
        Me.txtWithdrawby.Name = "txtWithdrawby"
        Me.txtWithdrawby.Size = New System.Drawing.Size(216, 24)
        Me.txtWithdrawby.TabIndex = 7
        '
        'lbl_withdraw
        '
        Me.lbl_withdraw.AutoSize = True
        Me.lbl_withdraw.BackColor = System.Drawing.Color.Transparent
        Me.lbl_withdraw.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_withdraw.ForeColor = System.Drawing.Color.White
        Me.lbl_withdraw.Location = New System.Drawing.Point(356, 128)
        Me.lbl_withdraw.Name = "lbl_withdraw"
        Me.lbl_withdraw.Size = New System.Drawing.Size(81, 15)
        Me.lbl_withdraw.TabIndex = 408
        Me.lbl_withdraw.Text = "Withdraw by:"
        '
        'txtReleasedby
        '
        Me.txtReleasedby.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReleasedby.Location = New System.Drawing.Point(440, 155)
        Me.txtReleasedby.Name = "txtReleasedby"
        Me.txtReleasedby.Size = New System.Drawing.Size(216, 24)
        Me.txtReleasedby.TabIndex = 8
        '
        'txtWithdrawFrom
        '
        Me.txtWithdrawFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWithdrawFrom.Location = New System.Drawing.Point(440, 89)
        Me.txtWithdrawFrom.Name = "txtWithdrawFrom"
        Me.txtWithdrawFrom.Size = New System.Drawing.Size(216, 24)
        Me.txtWithdrawFrom.TabIndex = 6
        '
        'lbl_released
        '
        Me.lbl_released.AutoSize = True
        Me.lbl_released.BackColor = System.Drawing.Color.Transparent
        Me.lbl_released.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_released.ForeColor = System.Drawing.Color.White
        Me.lbl_released.Location = New System.Drawing.Point(358, 161)
        Me.lbl_released.Name = "lbl_released"
        Me.lbl_released.Size = New System.Drawing.Size(79, 15)
        Me.lbl_released.TabIndex = 407
        Me.lbl_released.Text = "Released by:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(340, 94)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(97, 15)
        Me.Label10.TabIndex = 406
        Me.Label10.Text = "Withdraw From:"
        '
        'lbl_withdrawInfoID
        '
        Me.lbl_withdrawInfoID.AutoSize = True
        Me.lbl_withdrawInfoID.Location = New System.Drawing.Point(960, 54)
        Me.lbl_withdrawInfoID.Name = "lbl_withdrawInfoID"
        Me.lbl_withdrawInfoID.Size = New System.Drawing.Size(87, 13)
        Me.lbl_withdrawInfoID.TabIndex = 409
        Me.lbl_withdrawInfoID.Text = "lblwthdrwINFOID"
        '
        'lblRs_no
        '
        Me.lblRs_no.AutoSize = True
        Me.lblRs_no.Location = New System.Drawing.Point(960, 89)
        Me.lblRs_no.Name = "lblRs_no"
        Me.lblRs_no.Size = New System.Drawing.Size(48, 13)
        Me.lblRs_no.TabIndex = 410
        Me.lblRs_no.Text = "lblRs_no"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = Global.SUPPLY.My.Resources.Resources.Plus_sign
        Me.PictureBox2.Location = New System.Drawing.Point(1090, 449)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(26, 23)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 411
        Me.PictureBox2.TabStop = False
        '
        'lblchargeTo_id
        '
        Me.lblchargeTo_id.AutoSize = True
        Me.lblchargeTo_id.Location = New System.Drawing.Point(960, 122)
        Me.lblchargeTo_id.Name = "lblchargeTo_id"
        Me.lblchargeTo_id.Size = New System.Drawing.Size(77, 13)
        Me.lblchargeTo_id.TabIndex = 412
        Me.lblchargeTo_id.Text = "lblchargeTo_id"
        '
        'Panel_chargeTo
        '
        Me.Panel_chargeTo.BackColor = System.Drawing.Color.Transparent
        Me.Panel_chargeTo.BackgroundImage = Global.SUPPLY.My.Resources.Resources.bg_line
        Me.Panel_chargeTo.Controls.Add(Me.Label13)
        Me.Panel_chargeTo.Controls.Add(Me.lvList)
        Me.Panel_chargeTo.Controls.Add(Me.Button1)
        Me.Panel_chargeTo.Controls.Add(Me.txt_Search)
        Me.Panel_chargeTo.Controls.Add(Me.lvlSearchItem)
        Me.Panel_chargeTo.Location = New System.Drawing.Point(1245, 105)
        Me.Panel_chargeTo.Name = "Panel_chargeTo"
        Me.Panel_chargeTo.Size = New System.Drawing.Size(479, 398)
        Me.Panel_chargeTo.TabIndex = 413
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(20, 33)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(209, 13)
        Me.Label13.TabIndex = 417
        Me.Label13.Text = "Note: Double Click on list to select an item."
        '
        'lvList
        '
        Me.lvList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.lvList.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvList.FullRowSelect = True
        Me.lvList.GridLines = True
        Me.lvList.Location = New System.Drawing.Point(12, 56)
        Me.lvList.Name = "lvList"
        Me.lvList.Size = New System.Drawing.Size(456, 287)
        Me.lvList.TabIndex = 393
        Me.lvList.UseCompatibleStateImageBehavior = False
        Me.lvList.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Id"
        Me.ColumnHeader1.Width = 0
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Charge To"
        Me.ColumnHeader2.Width = 450
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.BackgroundImage = Global.SUPPLY.My.Resources.Resources.close_button
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(448, 8)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(20, 20)
        Me.Button1.TabIndex = 416
        Me.Button1.UseVisualStyleBackColor = False
        '
        'txt_Search
        '
        Me.txt_Search.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Search.Location = New System.Drawing.Point(111, 358)
        Me.txt_Search.Name = "txt_Search"
        Me.txt_Search.Size = New System.Drawing.Size(357, 23)
        Me.txt_Search.TabIndex = 415
        '
        'lvlSearchItem
        '
        Me.lvlSearchItem.AutoSize = True
        Me.lvlSearchItem.BackColor = System.Drawing.Color.Transparent
        Me.lvlSearchItem.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvlSearchItem.ForeColor = System.Drawing.Color.White
        Me.lvlSearchItem.Location = New System.Drawing.Point(9, 357)
        Me.lvlSearchItem.Name = "lvlSearchItem"
        Me.lvlSearchItem.Size = New System.Drawing.Size(99, 22)
        Me.lvlSearchItem.TabIndex = 414
        Me.lvlSearchItem.Text = "Search Item"
        '
        'FWithdrawalSlip_ToolTip
        '
        Me.FWithdrawalSlip_ToolTip.IsBalloon = True
        Me.FWithdrawalSlip_ToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        '
        'lbox_withdrawby
        '
        Me.lbox_withdrawby.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbox_withdrawby.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbox_withdrawby.FormattingEnabled = True
        Me.lbox_withdrawby.ItemHeight = 16
        Me.lbox_withdrawby.Location = New System.Drawing.Point(963, 275)
        Me.lbox_withdrawby.Name = "lbox_withdrawby"
        Me.lbox_withdrawby.Size = New System.Drawing.Size(216, 52)
        Me.lbox_withdrawby.TabIndex = 414
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(1008, 354)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 415
        Me.Label3.Text = "Label3"
        '
        'txtProcess
        '
        Me.txtProcess.Location = New System.Drawing.Point(977, 380)
        Me.txtProcess.Name = "txtProcess"
        Me.txtProcess.Size = New System.Drawing.Size(100, 20)
        Me.txtProcess.TabIndex = 417
        '
        'lbl_ws_info_id
        '
        Me.lbl_ws_info_id.AutoSize = True
        Me.lbl_ws_info_id.Location = New System.Drawing.Point(990, 433)
        Me.lbl_ws_info_id.Name = "lbl_ws_info_id"
        Me.lbl_ws_info_id.Size = New System.Drawing.Size(39, 13)
        Me.lbl_ws_info_id.TabIndex = 418
        Me.lbl_ws_info_id.Text = "Label5"
        '
        'lbl_reqID
        '
        Me.lbl_reqID.AutoSize = True
        Me.lbl_reqID.Location = New System.Drawing.Point(998, 490)
        Me.lbl_reqID.Name = "lbl_reqID"
        Me.lbl_reqID.Size = New System.Drawing.Size(39, 13)
        Me.lbl_reqID.TabIndex = 419
        Me.lbl_reqID.Text = "Label5"
        '
        'txtReqID
        '
        Me.txtReqID.Location = New System.Drawing.Point(1079, 158)
        Me.txtReqID.Name = "txtReqID"
        Me.txtReqID.Size = New System.Drawing.Size(100, 20)
        Me.txtReqID.TabIndex = 420
        '
        'cmb_chargeto
        '
        Me.cmb_chargeto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_chargeto.FormattingEnabled = True
        Me.cmb_chargeto.Location = New System.Drawing.Point(956, 212)
        Me.cmb_chargeto.Name = "cmb_chargeto"
        Me.cmb_chargeto.Size = New System.Drawing.Size(121, 24)
        Me.cmb_chargeto.TabIndex = 416
        '
        'lbl_rs_id
        '
        Me.lbl_rs_id.AutoSize = True
        Me.lbl_rs_id.Location = New System.Drawing.Point(881, 54)
        Me.lbl_rs_id.Name = "lbl_rs_id"
        Me.lbl_rs_id.Size = New System.Drawing.Size(13, 13)
        Me.lbl_rs_id.TabIndex = 421
        Me.lbl_rs_id.Text = "0"
        '
        'FWithdrawalSlip
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SUPPLY.My.Resources.Resources.bg_line
        Me.ClientSize = New System.Drawing.Size(684, 535)
        Me.Controls.Add(Me.lbl_rs_id)
        Me.Controls.Add(Me.txtReqID)
        Me.Controls.Add(Me.lbl_reqID)
        Me.Controls.Add(Me.lbl_ws_info_id)
        Me.Controls.Add(Me.txtProcess)
        Me.Controls.Add(Me.cmb_chargeto)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lbox_withdrawby)
        Me.Controls.Add(Me.Panel_chargeTo)
        Me.Controls.Add(Me.lblchargeTo_id)
        Me.Controls.Add(Me.lblRs_no)
        Me.Controls.Add(Me.lbl_withdrawInfoID)
        Me.Controls.Add(Me.txtWithdrawby)
        Me.Controls.Add(Me.lbl_withdraw)
        Me.Controls.Add(Me.txtReleasedby)
        Me.Controls.Add(Me.txtWithdrawFrom)
        Me.Controls.Add(Me.lbl_released)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.dgWithdrawItems)
        Me.Controls.Add(Me.DTPDateWithdraw)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtRSNo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtWSNo)
        Me.Controls.Add(Me.lblItemName)
        Me.Controls.Add(Me.txtLocation)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtChargeto)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.PictureBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FWithdrawalSlip"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FWithdrawalSlip"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgWithdrawItems, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel_chargeTo.ResumeLayout(False)
        Me.Panel_chargeTo.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents txtChargeto As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtLocation As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtWSNo As System.Windows.Forms.TextBox
    Friend WithEvents lblItemName As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtRSNo As System.Windows.Forms.TextBox
    Friend WithEvents DTPDateWithdraw As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents dgWithdrawItems As System.Windows.Forms.DataGridView
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents txtWithdrawby As System.Windows.Forms.TextBox
    Friend WithEvents lbl_withdraw As System.Windows.Forms.Label
    Friend WithEvents txtReleasedby As System.Windows.Forms.TextBox
    Friend WithEvents txtWithdrawFrom As System.Windows.Forms.TextBox
    Friend WithEvents lbl_released As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lbl_withdrawInfoID As System.Windows.Forms.Label
    Friend WithEvents lblRs_no As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents lblchargeTo_id As System.Windows.Forms.Label
    Friend WithEvents Panel_chargeTo As System.Windows.Forms.Panel
    Friend WithEvents lvList As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvlSearchItem As System.Windows.Forms.Label
    Friend WithEvents txt_Search As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents FWithdrawalSlip_ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lbox_withdrawby As System.Windows.Forms.ListBox
    Friend WithEvents Timer_panelmvemEnt As System.Windows.Forms.Timer
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtProcess As System.Windows.Forms.TextBox
    Friend WithEvents lbl_ws_info_id As System.Windows.Forms.Label
    Friend WithEvents lbl_reqID As System.Windows.Forms.Label
    Friend WithEvents txtReqID As System.Windows.Forms.TextBox
    Friend WithEvents cmb_chargeto As System.Windows.Forms.ComboBox
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rs_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lbl_rs_id As System.Windows.Forms.Label
End Class
