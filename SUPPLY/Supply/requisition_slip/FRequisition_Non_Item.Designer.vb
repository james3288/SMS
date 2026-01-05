<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FRequisition_Non_Item
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FRequisition_Non_Item))
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cmbTypeOfChargesName = New System.Windows.Forms.ComboBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.grpStatus = New System.Windows.Forms.GroupBox()
        Me.lblAccountTitle = New System.Windows.Forms.Label()
        Me.cmbAccountTitle = New System.Windows.Forms.ComboBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.cmbTOR_sub = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.cmbRequestType = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtApprovedby = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtRequestBy = New System.Windows.Forms.TextBox()
        Me.txtNotedBy = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.DTPTimeNeeded = New System.Windows.Forms.DateTimePicker()
        Me.txtPurpose = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtUnit = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtQty = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtItemDesc = New System.Windows.Forms.TextBox()
        Me.txtLoc = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtJOno = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DTPReq = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtRSno = New System.Windows.Forms.TextBox()
        Me.lblItemName = New System.Windows.Forms.Label()
        Me.cmbTypeofCharge = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pboxHeader = New System.Windows.Forms.PictureBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cmbCash_wrr_worr = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.lbl_rs_id = New System.Windows.Forms.Label()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lblRemarksForEmd = New System.Windows.Forms.Label()
        Me.txtRemarksForEmd = New System.Windows.Forms.TextBox()
        Me.lblPrice = New System.Windows.Forms.Label()
        Me.txtPrice = New System.Windows.Forms.TextBox()
        Me.grpStatus.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pboxHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(9, 263)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(103, 15)
        Me.Label5.TabIndex = 1148
        Me.Label5.Text = "Item Description:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label19.Location = New System.Drawing.Point(437, 618)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(181, 15)
        Me.Label19.TabIndex = 1145
        Me.Label19.Text = "Ctrl + S for shorcut Save/Update"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(9, 393)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(101, 15)
        Me.Label15.TabIndex = 1143
        Me.Label15.Text = "Type of Charges:"
        '
        'cmbTypeOfChargesName
        '
        Me.cmbTypeOfChargesName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTypeOfChargesName.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbTypeOfChargesName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTypeOfChargesName.FormattingEnabled = True
        Me.cmbTypeOfChargesName.Location = New System.Drawing.Point(9, 411)
        Me.cmbTypeOfChargesName.Name = "cmbTypeOfChargesName"
        Me.cmbTypeOfChargesName.Size = New System.Drawing.Size(296, 24)
        Me.cmbTypeOfChargesName.TabIndex = 6
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(9, 581)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(610, 34)
        Me.btnSave.TabIndex = 21
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'grpStatus
        '
        Me.grpStatus.BackColor = System.Drawing.Color.Transparent
        Me.grpStatus.Controls.Add(Me.lblAccountTitle)
        Me.grpStatus.Controls.Add(Me.cmbAccountTitle)
        Me.grpStatus.Controls.Add(Me.PictureBox4)
        Me.grpStatus.Controls.Add(Me.cmbTOR_sub)
        Me.grpStatus.Controls.Add(Me.Label23)
        Me.grpStatus.Controls.Add(Me.PictureBox1)
        Me.grpStatus.Controls.Add(Me.cmbRequestType)
        Me.grpStatus.Controls.Add(Me.Label14)
        Me.grpStatus.Location = New System.Drawing.Point(9, 59)
        Me.grpStatus.Name = "grpStatus"
        Me.grpStatus.Size = New System.Drawing.Size(296, 153)
        Me.grpStatus.TabIndex = 1149
        Me.grpStatus.TabStop = False
        '
        'lblAccountTitle
        '
        Me.lblAccountTitle.AutoSize = True
        Me.lblAccountTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblAccountTitle.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccountTitle.ForeColor = System.Drawing.Color.White
        Me.lblAccountTitle.Location = New System.Drawing.Point(9, 92)
        Me.lblAccountTitle.Name = "lblAccountTitle"
        Me.lblAccountTitle.Size = New System.Drawing.Size(84, 15)
        Me.lblAccountTitle.TabIndex = 1155
        Me.lblAccountTitle.Text = "Account Title:"
        '
        'cmbAccountTitle
        '
        Me.cmbAccountTitle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAccountTitle.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbAccountTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAccountTitle.FormattingEnabled = True
        Me.cmbAccountTitle.Items.AddRange(New Object() {"CASH WITH RR", "CASH WITHOUT RR"})
        Me.cmbAccountTitle.Location = New System.Drawing.Point(12, 111)
        Me.cmbAccountTitle.Name = "cmbAccountTitle"
        Me.cmbAccountTitle.Size = New System.Drawing.Size(271, 24)
        Me.cmbAccountTitle.TabIndex = 362
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = Global.SUPPLY.My.Resources.Resources.Plus_sign
        Me.PictureBox4.Location = New System.Drawing.Point(291, 46)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(26, 23)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox4.TabIndex = 361
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'cmbTOR_sub
        '
        Me.cmbTOR_sub.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTOR_sub.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbTOR_sub.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTOR_sub.FormattingEnabled = True
        Me.cmbTOR_sub.Items.AddRange(New Object() {"SUPPLY", "EQUIPMENT", "PROJECT", "OTHERS"})
        Me.cmbTOR_sub.Location = New System.Drawing.Point(115, 48)
        Me.cmbTOR_sub.Name = "cmbTOR_sub"
        Me.cmbTOR_sub.Size = New System.Drawing.Size(168, 24)
        Me.cmbTOR_sub.TabIndex = 2
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.White
        Me.Label23.Location = New System.Drawing.Point(77, 52)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(32, 15)
        Me.Label23.TabIndex = 360
        Me.Label23.Text = "Sub:"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.SUPPLY.My.Resources.Resources.Plus_sign
        Me.PictureBox1.Location = New System.Drawing.Point(291, 16)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(26, 23)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 358
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'cmbRequestType
        '
        Me.cmbRequestType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRequestType.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbRequestType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbRequestType.FormattingEnabled = True
        Me.cmbRequestType.Items.AddRange(New Object() {"SUPPLY", "EQUIPMENT", "PROJECT", "OTHERS"})
        Me.cmbRequestType.Location = New System.Drawing.Point(115, 18)
        Me.cmbRequestType.Name = "cmbRequestType"
        Me.cmbRequestType.Size = New System.Drawing.Size(168, 24)
        Me.cmbRequestType.TabIndex = 1
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(9, 23)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(100, 15)
        Me.Label14.TabIndex = 354
        Me.Label14.Text = "Type of Request:"
        '
        'txtApprovedby
        '
        Me.txtApprovedby.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtApprovedby.ForeColor = System.Drawing.Color.Gray
        Me.txtApprovedby.Location = New System.Drawing.Point(319, 546)
        Me.txtApprovedby.Name = "txtApprovedby"
        Me.txtApprovedby.Size = New System.Drawing.Size(299, 24)
        Me.txtApprovedby.TabIndex = 20
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(317, 528)
        Me.Label13.Margin = New System.Windows.Forms.Padding(10, 0, 10, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(80, 15)
        Me.Label13.TabIndex = 1142
        Me.Label13.Text = "Approved by:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtRequestBy
        '
        Me.txtRequestBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRequestBy.ForeColor = System.Drawing.Color.Gray
        Me.txtRequestBy.Location = New System.Drawing.Point(319, 457)
        Me.txtRequestBy.Name = "txtRequestBy"
        Me.txtRequestBy.Size = New System.Drawing.Size(299, 24)
        Me.txtRequestBy.TabIndex = 18
        '
        'txtNotedBy
        '
        Me.txtNotedBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNotedBy.ForeColor = System.Drawing.Color.Gray
        Me.txtNotedBy.Location = New System.Drawing.Point(319, 501)
        Me.txtNotedBy.Name = "txtNotedBy"
        Me.txtNotedBy.Size = New System.Drawing.Size(299, 24)
        Me.txtNotedBy.TabIndex = 19
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(316, 483)
        Me.Label11.Margin = New System.Windows.Forms.Padding(10, 0, 10, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(59, 15)
        Me.Label11.TabIndex = 1140
        Me.Label11.Text = "Noted by:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(316, 438)
        Me.Label10.Margin = New System.Windows.Forms.Padding(10, 0, 10, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(87, 15)
        Me.Label10.TabIndex = 1139
        Me.Label10.Text = "Requested by:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(316, 392)
        Me.Label9.Margin = New System.Windows.Forms.Padding(10, 0, 10, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(82, 15)
        Me.Label9.TabIndex = 1138
        Me.Label9.Text = "Date Needed:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DTPTimeNeeded
        '
        Me.DTPTimeNeeded.CustomFormat = ""
        Me.DTPTimeNeeded.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPTimeNeeded.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPTimeNeeded.Location = New System.Drawing.Point(320, 410)
        Me.DTPTimeNeeded.Margin = New System.Windows.Forms.Padding(10, 3, 3, 3)
        Me.DTPTimeNeeded.Name = "DTPTimeNeeded"
        Me.DTPTimeNeeded.Size = New System.Drawing.Size(298, 24)
        Me.DTPTimeNeeded.TabIndex = 17
        '
        'txtPurpose
        '
        Me.txtPurpose.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPurpose.Location = New System.Drawing.Point(318, 326)
        Me.txtPurpose.Multiline = True
        Me.txtPurpose.Name = "txtPurpose"
        Me.txtPurpose.Size = New System.Drawing.Size(300, 64)
        Me.txtPurpose.TabIndex = 16
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(317, 309)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 15)
        Me.Label8.TabIndex = 1137
        Me.Label8.Text = "Purpose:"
        '
        'txtUnit
        '
        Me.txtUnit.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUnit.Location = New System.Drawing.Point(318, 149)
        Me.txtUnit.Name = "txtUnit"
        Me.txtUnit.Size = New System.Drawing.Size(300, 24)
        Me.txtUnit.TabIndex = 12
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(318, 133)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(32, 15)
        Me.Label7.TabIndex = 1136
        Me.Label7.Text = "Unit:"
        '
        'txtQty
        '
        Me.txtQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQty.Location = New System.Drawing.Point(318, 107)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.Size = New System.Drawing.Size(300, 24)
        Me.txtQty.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(318, 89)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 15)
        Me.Label6.TabIndex = 1135
        Me.Label6.Text = "Quantity:"
        '
        'txtItemDesc
        '
        Me.txtItemDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemDesc.Location = New System.Drawing.Point(9, 281)
        Me.txtItemDesc.Multiline = True
        Me.txtItemDesc.Name = "txtItemDesc"
        Me.txtItemDesc.Size = New System.Drawing.Size(296, 63)
        Me.txtItemDesc.TabIndex = 4
        '
        'txtLoc
        '
        Me.txtLoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLoc.Location = New System.Drawing.Point(9, 501)
        Me.txtLoc.Name = "txtLoc"
        Me.txtLoc.Size = New System.Drawing.Size(296, 24)
        Me.txtLoc.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(9, 483)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 15)
        Me.Label4.TabIndex = 1134
        Me.Label4.Text = "Location:"
        '
        'txtJOno
        '
        Me.txtJOno.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtJOno.Location = New System.Drawing.Point(318, 62)
        Me.txtJOno.Name = "txtJOno"
        Me.txtJOno.Size = New System.Drawing.Size(300, 24)
        Me.txtJOno.TabIndex = 10
        Me.txtJOno.Text = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(317, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 15)
        Me.Label2.TabIndex = 1132
        Me.Label2.Text = "J.O No.:"
        '
        'DTPReq
        '
        Me.DTPReq.CustomFormat = ""
        Me.DTPReq.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPReq.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPReq.Location = New System.Drawing.Point(9, 546)
        Me.DTPReq.Margin = New System.Windows.Forms.Padding(10, 3, 3, 3)
        Me.DTPReq.Name = "DTPReq"
        Me.DTPReq.Size = New System.Drawing.Size(296, 24)
        Me.DTPReq.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(9, 528)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 15)
        Me.Label1.TabIndex = 1131
        Me.Label1.Text = "Date Request:"
        '
        'txtRSno
        '
        Me.txtRSno.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRSno.Location = New System.Drawing.Point(9, 365)
        Me.txtRSno.Name = "txtRSno"
        Me.txtRSno.Size = New System.Drawing.Size(296, 24)
        Me.txtRSno.TabIndex = 5
        '
        'lblItemName
        '
        Me.lblItemName.AutoSize = True
        Me.lblItemName.BackColor = System.Drawing.Color.Transparent
        Me.lblItemName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItemName.ForeColor = System.Drawing.Color.White
        Me.lblItemName.Location = New System.Drawing.Point(9, 347)
        Me.lblItemName.Name = "lblItemName"
        Me.lblItemName.Size = New System.Drawing.Size(53, 15)
        Me.lblItemName.TabIndex = 1130
        Me.lblItemName.Text = "R.S. No.:"
        '
        'cmbTypeofCharge
        '
        Me.cmbTypeofCharge.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTypeofCharge.FormattingEnabled = True
        Me.cmbTypeofCharge.Items.AddRange(New Object() {"ADFIL", "OUTSOURCE"})
        Me.cmbTypeofCharge.Location = New System.Drawing.Point(9, 456)
        Me.cmbTypeofCharge.Name = "cmbTypeofCharge"
        Me.cmbTypeofCharge.Size = New System.Drawing.Size(296, 24)
        Me.cmbTypeofCharge.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(9, 438)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 15)
        Me.Label3.TabIndex = 1151
        Me.Label3.Text = "Charge to:"
        '
        'pboxHeader
        '
        Me.pboxHeader.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.pboxHeader.BackgroundImage = CType(resources.GetObject("pboxHeader.BackgroundImage"), System.Drawing.Image)
        Me.pboxHeader.InitialImage = Nothing
        Me.pboxHeader.Location = New System.Drawing.Point(0, 0)
        Me.pboxHeader.Name = "pboxHeader"
        Me.pboxHeader.Size = New System.Drawing.Size(637, 41)
        Me.pboxHeader.TabIndex = 1152
        Me.pboxHeader.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(9, 215)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(39, 15)
        Me.Label12.TabIndex = 1154
        Me.Label12.Text = "Cash:"
        '
        'cmbCash_wrr_worr
        '
        Me.cmbCash_wrr_worr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCash_wrr_worr.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbCash_wrr_worr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCash_wrr_worr.FormattingEnabled = True
        Me.cmbCash_wrr_worr.Items.AddRange(New Object() {"CASH WITH RR", "CASH WITHOUT RR"})
        Me.cmbCash_wrr_worr.Location = New System.Drawing.Point(9, 234)
        Me.cmbCash_wrr_worr.Name = "cmbCash_wrr_worr"
        Me.cmbCash_wrr_worr.Size = New System.Drawing.Size(296, 24)
        Me.cmbCash_wrr_worr.TabIndex = 3
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(316, 218)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(54, 15)
        Me.Label16.TabIndex = 1156
        Me.Label16.Text = "Amount:"
        '
        'txtAmount
        '
        Me.txtAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmount.Location = New System.Drawing.Point(318, 233)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.ReadOnly = True
        Me.txtAmount.Size = New System.Drawing.Size(300, 24)
        Me.txtAmount.TabIndex = 14
        '
        'lbl_rs_id
        '
        Me.lbl_rs_id.AutoSize = True
        Me.lbl_rs_id.BackColor = System.Drawing.Color.Transparent
        Me.lbl_rs_id.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_rs_id.ForeColor = System.Drawing.Color.White
        Me.lbl_rs_id.Location = New System.Drawing.Point(408, 12)
        Me.lbl_rs_id.Name = "lbl_rs_id"
        Me.lbl_rs_id.Size = New System.Drawing.Size(36, 15)
        Me.lbl_rs_id.TabIndex = 1158
        Me.lbl_rs_id.Text = "rs_id"
        Me.lbl_rs_id.Visible = False
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.Transparent
        Me.btnExit.BackgroundImage = Global.SUPPLY.My.Resources.Resources.close_button
        Me.btnExit.FlatAppearance.BorderSize = 0
        Me.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit.Location = New System.Drawing.Point(596, 12)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(22, 22)
        Me.btnExit.TabIndex = 1159
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(480, 12)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(47, 15)
        Me.Label17.TabIndex = 1160
        Me.Label17.Text = "J.O No."
        Me.Label17.Visible = False
        '
        'lblRemarksForEmd
        '
        Me.lblRemarksForEmd.AutoSize = True
        Me.lblRemarksForEmd.BackColor = System.Drawing.Color.Transparent
        Me.lblRemarksForEmd.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRemarksForEmd.ForeColor = System.Drawing.Color.White
        Me.lblRemarksForEmd.Location = New System.Drawing.Point(317, 264)
        Me.lblRemarksForEmd.Name = "lblRemarksForEmd"
        Me.lblRemarksForEmd.Size = New System.Drawing.Size(109, 15)
        Me.lblRemarksForEmd.TabIndex = 1161
        Me.lblRemarksForEmd.Text = "Remarks for Emd:"
        '
        'txtRemarksForEmd
        '
        Me.txtRemarksForEmd.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRemarksForEmd.Location = New System.Drawing.Point(318, 281)
        Me.txtRemarksForEmd.Name = "txtRemarksForEmd"
        Me.txtRemarksForEmd.Size = New System.Drawing.Size(300, 24)
        Me.txtRemarksForEmd.TabIndex = 15
        '
        'lblPrice
        '
        Me.lblPrice.AutoSize = True
        Me.lblPrice.BackColor = System.Drawing.Color.Transparent
        Me.lblPrice.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrice.ForeColor = System.Drawing.Color.White
        Me.lblPrice.Location = New System.Drawing.Point(318, 178)
        Me.lblPrice.Name = "lblPrice"
        Me.lblPrice.Size = New System.Drawing.Size(40, 15)
        Me.lblPrice.TabIndex = 1162
        Me.lblPrice.Text = "Price:"
        '
        'txtPrice
        '
        Me.txtPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrice.Location = New System.Drawing.Point(318, 193)
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.Size = New System.Drawing.Size(300, 24)
        Me.txtPrice.TabIndex = 13
        '
        'FRequisition_Non_Item
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SUPPLY.My.Resources.Resources.bg_line
        Me.ClientSize = New System.Drawing.Size(627, 642)
        Me.Controls.Add(Me.txtPrice)
        Me.Controls.Add(Me.lblPrice)
        Me.Controls.Add(Me.txtRemarksForEmd)
        Me.Controls.Add(Me.lblRemarksForEmd)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.lbl_rs_id)
        Me.Controls.Add(Me.txtAmount)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.cmbCash_wrr_worr)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.pboxHeader)
        Me.Controls.Add(Me.cmbTypeofCharge)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.cmbTypeOfChargesName)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.grpStatus)
        Me.Controls.Add(Me.txtApprovedby)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtRequestBy)
        Me.Controls.Add(Me.txtNotedBy)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.DTPTimeNeeded)
        Me.Controls.Add(Me.txtPurpose)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtUnit)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtQty)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtItemDesc)
        Me.Controls.Add(Me.txtLoc)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtJOno)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DTPReq)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtRSno)
        Me.Controls.Add(Me.lblItemName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "FRequisition_Non_Item"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FRequisition_Non_Item"
        Me.grpStatus.ResumeLayout(False)
        Me.grpStatus.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pboxHeader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label5 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents cmbTypeOfChargesName As ComboBox
    Friend WithEvents btnSave As Button
    Friend WithEvents grpStatus As GroupBox
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents cmbTOR_sub As ComboBox
    Friend WithEvents Label23 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents cmbRequestType As ComboBox
    Friend WithEvents Label14 As Label
    Friend WithEvents txtApprovedby As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtRequestBy As TextBox
    Friend WithEvents txtNotedBy As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents DTPTimeNeeded As DateTimePicker
    Friend WithEvents txtPurpose As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtUnit As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtQty As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtItemDesc As TextBox
    Friend WithEvents txtLoc As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtJOno As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents DTPReq As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents txtRSno As TextBox
    Friend WithEvents lblItemName As Label
    Friend WithEvents cmbTypeofCharge As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents pboxHeader As PictureBox
    Friend WithEvents Label12 As Label
    Friend WithEvents cmbCash_wrr_worr As ComboBox
    Friend WithEvents Label16 As Label
    Friend WithEvents txtAmount As TextBox
    Friend WithEvents lbl_rs_id As Label
    Friend WithEvents btnExit As Button
    Friend WithEvents Label17 As Label
    Friend WithEvents lblRemarksForEmd As Label
    Friend WithEvents txtRemarksForEmd As TextBox
    Friend WithEvents lblPrice As Label
    Friend WithEvents txtPrice As TextBox
    Friend WithEvents lblAccountTitle As Label
    Friend WithEvents cmbAccountTitle As ComboBox
End Class
