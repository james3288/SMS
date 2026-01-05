<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FBorrower_Turnover
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
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbTypeofCharge = New System.Windows.Forms.ComboBox
        Me.txtReturnTo = New System.Windows.Forms.TextBox
        Me.cmbReturnTo = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtTypeOfMat = New System.Windows.Forms.TextBox
        Me.txtQty = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtTurnoverLocation = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtReceiver = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.dtpdateturnover = New System.Windows.Forms.DateTimePicker
        Me.Label8 = New System.Windows.Forms.Label
        Me.dtpDateNoted = New System.Windows.Forms.DateTimePicker
        Me.txtturnoverby = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtNotedBy = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.btnSave = New System.Windows.Forms.Button
        Me.cmbTurnoverTo = New System.Windows.Forms.ComboBox
        Me.cmbTurnoverLocation = New System.Windows.Forms.ComboBox
        Me.lbl_fi_id = New System.Windows.Forms.Label
        Me.lbl_bs_no = New System.Windows.Forms.Label
        Me.lbl_bs_turnover_id = New System.Windows.Forms.Label
        Me.lbl_bs_id = New System.Windows.Forms.Label
        Me.cmbCondition = New System.Windows.Forms.ComboBox
        Me.btn_picbox1 = New System.Windows.Forms.Button
        Me.btn_picbox2 = New System.Windows.Forms.Button
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.lvlList = New System.Windows.Forms.ListView
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader5 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader6 = New System.Windows.Forms.ColumnHeader
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(20, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 15)
        Me.Label2.TabIndex = 398
        Me.Label2.Text = "Return From:"
        '
        'cmbTypeofCharge
        '
        Me.cmbTypeofCharge.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTypeofCharge.Enabled = False
        Me.cmbTypeofCharge.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbTypeofCharge.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTypeofCharge.FormattingEnabled = True
        Me.cmbTypeofCharge.Location = New System.Drawing.Point(23, 76)
        Me.cmbTypeofCharge.Name = "cmbTypeofCharge"
        Me.cmbTypeofCharge.Size = New System.Drawing.Size(216, 24)
        Me.cmbTypeofCharge.TabIndex = 1
        '
        'txtReturnTo
        '
        Me.txtReturnTo.Enabled = False
        Me.txtReturnTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReturnTo.Location = New System.Drawing.Point(23, 112)
        Me.txtReturnTo.Name = "txtReturnTo"
        Me.txtReturnTo.Size = New System.Drawing.Size(183, 24)
        Me.txtReturnTo.TabIndex = 2
        '
        'cmbReturnTo
        '
        Me.cmbReturnTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbReturnTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbReturnTo.FormattingEnabled = True
        Me.cmbReturnTo.Location = New System.Drawing.Point(678, 114)
        Me.cmbReturnTo.Name = "cmbReturnTo"
        Me.cmbReturnTo.Size = New System.Drawing.Size(216, 24)
        Me.cmbReturnTo.TabIndex = 3
        Me.cmbReturnTo.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(20, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(176, 15)
        Me.Label1.TabIndex = 401
        Me.Label1.Text = "Type of materials/Items/Brand"
        '
        'txtTypeOfMat
        '
        Me.txtTypeOfMat.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTypeOfMat.Location = New System.Drawing.Point(23, 31)
        Me.txtTypeOfMat.Name = "txtTypeOfMat"
        Me.txtTypeOfMat.Size = New System.Drawing.Size(216, 24)
        Me.txtTypeOfMat.TabIndex = 0
        '
        'txtQty
        '
        Me.txtQty.Enabled = False
        Me.txtQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQty.Location = New System.Drawing.Point(55, 168)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.Size = New System.Drawing.Size(184, 24)
        Me.txtQty.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(20, 172)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 15)
        Me.Label3.TabIndex = 403
        Me.Label3.Text = "Qty:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(20, 198)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(105, 15)
        Me.Label4.TabIndex = 405
        Me.Label4.Text = "Condition of item:"
        '
        'txtTurnoverLocation
        '
        Me.txtTurnoverLocation.Enabled = False
        Me.txtTurnoverLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTurnoverLocation.Location = New System.Drawing.Point(23, 297)
        Me.txtTurnoverLocation.Name = "txtTurnoverLocation"
        Me.txtTurnoverLocation.Size = New System.Drawing.Size(216, 24)
        Me.txtTurnoverLocation.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(23, 246)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 15)
        Me.Label5.TabIndex = 409
        Me.Label5.Text = "Turnover Location:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(297, 39)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 15)
        Me.Label6.TabIndex = 411
        Me.Label6.Text = "Receiver:"
        '
        'txtReceiver
        '
        Me.txtReceiver.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReceiver.Location = New System.Drawing.Point(297, 58)
        Me.txtReceiver.Name = "txtReceiver"
        Me.txtReceiver.Size = New System.Drawing.Size(216, 24)
        Me.txtReceiver.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(295, 87)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(86, 15)
        Me.Label7.TabIndex = 413
        Me.Label7.Text = "Date Turnover"
        '
        'dtpdateturnover
        '
        Me.dtpdateturnover.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpdateturnover.Location = New System.Drawing.Point(297, 105)
        Me.dtpdateturnover.Name = "dtpdateturnover"
        Me.dtpdateturnover.Size = New System.Drawing.Size(216, 22)
        Me.dtpdateturnover.TabIndex = 10
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(295, 177)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 15)
        Me.Label8.TabIndex = 415
        Me.Label8.Text = "Date Noted:"
        '
        'dtpDateNoted
        '
        Me.dtpDateNoted.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDateNoted.Location = New System.Drawing.Point(297, 195)
        Me.dtpDateNoted.Name = "dtpDateNoted"
        Me.dtpDateNoted.Size = New System.Drawing.Size(216, 22)
        Me.dtpDateNoted.TabIndex = 12
        '
        'txtturnoverby
        '
        Me.txtturnoverby.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtturnoverby.Location = New System.Drawing.Point(297, 150)
        Me.txtturnoverby.Name = "txtturnoverby"
        Me.txtturnoverby.Size = New System.Drawing.Size(216, 24)
        Me.txtturnoverby.TabIndex = 11
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(294, 132)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(76, 15)
        Me.Label9.TabIndex = 416
        Me.Label9.Text = "Turnover by:"
        '
        'txtNotedBy
        '
        Me.txtNotedBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNotedBy.Location = New System.Drawing.Point(297, 242)
        Me.txtNotedBy.Name = "txtNotedBy"
        Me.txtNotedBy.Size = New System.Drawing.Size(216, 24)
        Me.txtNotedBy.TabIndex = 13
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(295, 224)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(60, 15)
        Me.Label10.TabIndex = 418
        Me.Label10.Text = "Noted By:"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(297, 279)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(216, 32)
        Me.btnSave.TabIndex = 14
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'cmbTurnoverTo
        '
        Me.cmbTurnoverTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbTurnoverTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTurnoverTo.FormattingEnabled = True
        Me.cmbTurnoverTo.Location = New System.Drawing.Point(678, 162)
        Me.cmbTurnoverTo.Name = "cmbTurnoverTo"
        Me.cmbTurnoverTo.Size = New System.Drawing.Size(216, 24)
        Me.cmbTurnoverTo.TabIndex = 8
        Me.cmbTurnoverTo.Visible = False
        '
        'cmbTurnoverLocation
        '
        Me.cmbTurnoverLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTurnoverLocation.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbTurnoverLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTurnoverLocation.FormattingEnabled = True
        Me.cmbTurnoverLocation.Location = New System.Drawing.Point(23, 264)
        Me.cmbTurnoverLocation.Name = "cmbTurnoverLocation"
        Me.cmbTurnoverLocation.Size = New System.Drawing.Size(216, 24)
        Me.cmbTurnoverLocation.TabIndex = 6
        '
        'lbl_fi_id
        '
        Me.lbl_fi_id.AutoSize = True
        Me.lbl_fi_id.Location = New System.Drawing.Point(688, 26)
        Me.lbl_fi_id.Name = "lbl_fi_id"
        Me.lbl_fi_id.Size = New System.Drawing.Size(45, 13)
        Me.lbl_fi_id.TabIndex = 423
        Me.lbl_fi_id.Text = "Label11"
        '
        'lbl_bs_no
        '
        Me.lbl_bs_no.AutoSize = True
        Me.lbl_bs_no.Location = New System.Drawing.Point(688, 42)
        Me.lbl_bs_no.Name = "lbl_bs_no"
        Me.lbl_bs_no.Size = New System.Drawing.Size(45, 13)
        Me.lbl_bs_no.TabIndex = 424
        Me.lbl_bs_no.Text = "Label11"
        '
        'lbl_bs_turnover_id
        '
        Me.lbl_bs_turnover_id.AutoSize = True
        Me.lbl_bs_turnover_id.Location = New System.Drawing.Point(688, 59)
        Me.lbl_bs_turnover_id.Name = "lbl_bs_turnover_id"
        Me.lbl_bs_turnover_id.Size = New System.Drawing.Size(13, 13)
        Me.lbl_bs_turnover_id.TabIndex = 425
        Me.lbl_bs_turnover_id.Text = "0"
        '
        'lbl_bs_id
        '
        Me.lbl_bs_id.AutoSize = True
        Me.lbl_bs_id.Location = New System.Drawing.Point(691, 86)
        Me.lbl_bs_id.Name = "lbl_bs_id"
        Me.lbl_bs_id.Size = New System.Drawing.Size(13, 13)
        Me.lbl_bs_id.TabIndex = 426
        Me.lbl_bs_id.Text = "0"
        '
        'cmbCondition
        '
        Me.cmbCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCondition.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbCondition.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCondition.FormattingEnabled = True
        Me.cmbCondition.Items.AddRange(New Object() {"Functional", "Defective"})
        Me.cmbCondition.Location = New System.Drawing.Point(23, 216)
        Me.cmbCondition.Name = "cmbCondition"
        Me.cmbCondition.Size = New System.Drawing.Size(216, 24)
        Me.cmbCondition.TabIndex = 5
        '
        'btn_picbox1
        '
        Me.btn_picbox1.BackColor = System.Drawing.SystemColors.Control
        Me.btn_picbox1.FlatAppearance.BorderSize = 0
        Me.btn_picbox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_picbox1.Image = Global.SUPPLY.My.Resources.Resources.Plus_sign
        Me.btn_picbox1.Location = New System.Drawing.Point(241, 74)
        Me.btn_picbox1.Name = "btn_picbox1"
        Me.btn_picbox1.Size = New System.Drawing.Size(29, 24)
        Me.btn_picbox1.TabIndex = 2
        Me.btn_picbox1.UseVisualStyleBackColor = False
        '
        'btn_picbox2
        '
        Me.btn_picbox2.BackColor = System.Drawing.SystemColors.Control
        Me.btn_picbox2.FlatAppearance.BorderSize = 0
        Me.btn_picbox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_picbox2.Image = Global.SUPPLY.My.Resources.Resources.Plus_sign
        Me.btn_picbox2.Location = New System.Drawing.Point(241, 296)
        Me.btn_picbox2.Name = "btn_picbox2"
        Me.btn_picbox2.Size = New System.Drawing.Size(29, 24)
        Me.btn_picbox2.TabIndex = 7
        Me.btn_picbox2.UseVisualStyleBackColor = False
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(774, 5)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(120, 95)
        Me.ListBox1.TabIndex = 430
        '
        'lvlList
        '
        Me.lvlList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader2, Me.ColumnHeader5, Me.ColumnHeader6})
        Me.lvlList.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvlList.FullRowSelect = True
        Me.lvlList.GridLines = True
        Me.lvlList.HideSelection = False
        Me.lvlList.Location = New System.Drawing.Point(23, 75)
        Me.lvlList.Name = "lvlList"
        Me.lvlList.Size = New System.Drawing.Size(216, 87)
        Me.lvlList.TabIndex = 431
        Me.lvlList.UseCompatibleStateImageBehavior = False
        Me.lvlList.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "proj_id"
        Me.ColumnHeader2.Width = 62
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Project Desc"
        Me.ColumnHeader5.Width = 269
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Type"
        Me.ColumnHeader6.Width = 203
        '
        'FBorrower_Turnover
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(539, 362)
        Me.Controls.Add(Me.lvlList)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.btn_picbox2)
        Me.Controls.Add(Me.btn_picbox1)
        Me.Controls.Add(Me.cmbCondition)
        Me.Controls.Add(Me.lbl_bs_id)
        Me.Controls.Add(Me.lbl_bs_turnover_id)
        Me.Controls.Add(Me.lbl_bs_no)
        Me.Controls.Add(Me.lbl_fi_id)
        Me.Controls.Add(Me.cmbTurnoverLocation)
        Me.Controls.Add(Me.cmbTurnoverTo)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtNotedBy)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtturnoverby)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.dtpDateNoted)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.dtpdateturnover)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtReceiver)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtTurnoverLocation)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtQty)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtTypeOfMat)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbReturnTo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbTypeofCharge)
        Me.Controls.Add(Me.txtReturnTo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FBorrower_Turnover"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FBorrower_Turnover"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbTypeofCharge As System.Windows.Forms.ComboBox
    Friend WithEvents txtReturnTo As System.Windows.Forms.TextBox
    Friend WithEvents cmbReturnTo As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTypeOfMat As System.Windows.Forms.TextBox
    Friend WithEvents txtQty As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTurnoverLocation As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtReceiver As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtpdateturnover As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dtpDateNoted As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtturnoverby As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtNotedBy As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents cmbTurnoverTo As System.Windows.Forms.ComboBox
    Friend WithEvents cmbTurnoverLocation As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_fi_id As System.Windows.Forms.Label
    Friend WithEvents lbl_bs_no As System.Windows.Forms.Label
    Friend WithEvents lbl_bs_turnover_id As System.Windows.Forms.Label
    Friend WithEvents lbl_bs_id As System.Windows.Forms.Label
    Friend WithEvents cmbCondition As System.Windows.Forms.ComboBox
    Friend WithEvents btn_picbox1 As System.Windows.Forms.Button
    Friend WithEvents btn_picbox2 As System.Windows.Forms.Button
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents lvlList As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
End Class
