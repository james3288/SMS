<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FBorrowerSlip
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FBorrowerSlip))
        Me.btnExit = New System.Windows.Forms.Button
        Me.pboxHeader = New System.Windows.Forms.PictureBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.dtpDateBorrow = New System.Windows.Forms.DateTimePicker
        Me.Label15 = New System.Windows.Forms.Label
        Me.cmbTypeofCharge = New System.Windows.Forms.ComboBox
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.cmbChargeTo = New System.Windows.Forms.ComboBox
        Me.txtChargeTo = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtPurpose = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtBorrowedby = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtpDateReturn = New System.Windows.Forms.DateTimePicker
        Me.txtNotedBy = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtApprovedBy = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.lvlFacTools = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader6 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.btnFac_Save = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.cmbTypeofreturn = New System.Windows.Forms.ComboBox
        Me.lbox_getdata = New System.Windows.Forms.ListBox
        Me.txtBs_no = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        CType(Me.pboxHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.Transparent
        Me.btnExit.BackgroundImage = CType(resources.GetObject("btnExit.BackgroundImage"), System.Drawing.Image)
        Me.btnExit.FlatAppearance.BorderSize = 0
        Me.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit.Location = New System.Drawing.Point(793, 10)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(20, 20)
        Me.btnExit.TabIndex = 389
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'pboxHeader
        '
        Me.pboxHeader.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.pboxHeader.BackgroundImage = CType(resources.GetObject("pboxHeader.BackgroundImage"), System.Drawing.Image)
        Me.pboxHeader.InitialImage = Nothing
        Me.pboxHeader.Location = New System.Drawing.Point(-3, 0)
        Me.pboxHeader.Name = "pboxHeader"
        Me.pboxHeader.Size = New System.Drawing.Size(831, 41)
        Me.pboxHeader.TabIndex = 388
        Me.pboxHeader.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(9, 101)
        Me.Label9.Margin = New System.Windows.Forms.Padding(10, 0, 10, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(81, 15)
        Me.Label9.TabIndex = 391
        Me.Label9.Text = "Date Borrow:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpDateBorrow
        '
        Me.dtpDateBorrow.CustomFormat = ""
        Me.dtpDateBorrow.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDateBorrow.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDateBorrow.Location = New System.Drawing.Point(9, 118)
        Me.dtpDateBorrow.Margin = New System.Windows.Forms.Padding(10, 3, 3, 3)
        Me.dtpDateBorrow.Name = "dtpDateBorrow"
        Me.dtpDateBorrow.Size = New System.Drawing.Size(216, 24)
        Me.dtpDateBorrow.TabIndex = 390
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(6, 154)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(91, 15)
        Me.Label15.TabIndex = 395
        Me.Label15.Text = "Type of Charge"
        '
        'cmbTypeofCharge
        '
        Me.cmbTypeofCharge.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTypeofCharge.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbTypeofCharge.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTypeofCharge.FormattingEnabled = True
        Me.cmbTypeofCharge.Items.AddRange(New Object() {"ADFIL", "SHOPS", "PROJECT", "EQUIPMENT", "WAREHOUSE"})
        Me.cmbTypeofCharge.Location = New System.Drawing.Point(9, 172)
        Me.cmbTypeofCharge.Name = "cmbTypeofCharge"
        Me.cmbTypeofCharge.Size = New System.Drawing.Size(216, 24)
        Me.cmbTypeofCharge.TabIndex = 392
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.Image = Global.SUPPLY.My.Resources.Resources.Plus_sign
        Me.PictureBox3.Location = New System.Drawing.Point(199, 224)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(26, 23)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 399
        Me.PictureBox3.TabStop = False
        '
        'cmbChargeTo
        '
        Me.cmbChargeTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbChargeTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbChargeTo.FormattingEnabled = True
        Me.cmbChargeTo.Location = New System.Drawing.Point(692, 47)
        Me.cmbChargeTo.Name = "cmbChargeTo"
        Me.cmbChargeTo.Size = New System.Drawing.Size(121, 23)
        Me.cmbChargeTo.TabIndex = 396
        Me.cmbChargeTo.Visible = False
        '
        'txtChargeTo
        '
        Me.txtChargeTo.Enabled = False
        Me.txtChargeTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChargeTo.Location = New System.Drawing.Point(9, 223)
        Me.txtChargeTo.Name = "txtChargeTo"
        Me.txtChargeTo.Size = New System.Drawing.Size(184, 24)
        Me.txtChargeTo.TabIndex = 397
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(9, 205)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 15)
        Me.Label3.TabIndex = 398
        Me.Label3.Text = "Charge to:"
        '
        'txtPurpose
        '
        Me.txtPurpose.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPurpose.Location = New System.Drawing.Point(9, 276)
        Me.txtPurpose.Name = "txtPurpose"
        Me.txtPurpose.Size = New System.Drawing.Size(216, 24)
        Me.txtPurpose.TabIndex = 400
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(9, 258)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 15)
        Me.Label4.TabIndex = 401
        Me.Label4.Text = "Purpose:"
        '
        'txtBorrowedby
        '
        Me.txtBorrowedby.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBorrowedby.Location = New System.Drawing.Point(9, 336)
        Me.txtBorrowedby.Name = "txtBorrowedby"
        Me.txtBorrowedby.Size = New System.Drawing.Size(216, 24)
        Me.txtBorrowedby.TabIndex = 402
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(9, 314)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 15)
        Me.Label1.TabIndex = 403
        Me.Label1.Text = "Borrowed by:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(9, 417)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 15)
        Me.Label2.TabIndex = 405
        Me.Label2.Text = "Date of return:"
        '
        'dtpDateReturn
        '
        Me.dtpDateReturn.CustomFormat = ""
        Me.dtpDateReturn.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDateReturn.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDateReturn.Location = New System.Drawing.Point(9, 436)
        Me.dtpDateReturn.Margin = New System.Windows.Forms.Padding(10, 3, 3, 3)
        Me.dtpDateReturn.Name = "dtpDateReturn"
        Me.dtpDateReturn.Size = New System.Drawing.Size(216, 24)
        Me.dtpDateReturn.TabIndex = 406
        '
        'txtNotedBy
        '
        Me.txtNotedBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNotedBy.Location = New System.Drawing.Point(9, 492)
        Me.txtNotedBy.Name = "txtNotedBy"
        Me.txtNotedBy.Size = New System.Drawing.Size(216, 24)
        Me.txtNotedBy.TabIndex = 407
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(9, 474)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 15)
        Me.Label5.TabIndex = 408
        Me.Label5.Text = "Noted by:"
        '
        'txtApprovedBy
        '
        Me.txtApprovedBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtApprovedBy.Location = New System.Drawing.Point(9, 546)
        Me.txtApprovedBy.Name = "txtApprovedBy"
        Me.txtApprovedBy.Size = New System.Drawing.Size(216, 24)
        Me.txtApprovedBy.TabIndex = 409
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(9, 528)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 15)
        Me.Label6.TabIndex = 410
        Me.Label6.Text = "Approved by:"
        '
        'lvlFacTools
        '
        Me.lvlFacTools.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader6, Me.ColumnHeader3})
        Me.lvlFacTools.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvlFacTools.FullRowSelect = True
        Me.lvlFacTools.GridLines = True
        Me.lvlFacTools.HideSelection = False
        Me.lvlFacTools.Location = New System.Drawing.Point(235, 72)
        Me.lvlFacTools.Name = "lvlFacTools"
        Me.lvlFacTools.Size = New System.Drawing.Size(578, 554)
        Me.lvlFacTools.TabIndex = 411
        Me.lvlFacTools.UseCompatibleStateImageBehavior = False
        Me.lvlFacTools.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "id"
        Me.ColumnHeader1.Width = 50
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Qty"
        Me.ColumnHeader2.Width = 160
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Item Desc"
        Me.ColumnHeader6.Width = 361
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "fac_tools_id"
        '
        'btnFac_Save
        '
        Me.btnFac_Save.Location = New System.Drawing.Point(9, 587)
        Me.btnFac_Save.Name = "btnFac_Save"
        Me.btnFac_Save.Size = New System.Drawing.Size(216, 39)
        Me.btnFac_Save.TabIndex = 412
        Me.btnFac_Save.Text = "Save"
        Me.btnFac_Save.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(8, 11)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(115, 22)
        Me.Label7.TabIndex = 413
        Me.Label7.Text = "Borrower Slip"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(9, 363)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 15)
        Me.Label8.TabIndex = 414
        Me.Label8.Text = "Type of return:"
        '
        'cmbTypeofreturn
        '
        Me.cmbTypeofreturn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTypeofreturn.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbTypeofreturn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTypeofreturn.FormattingEnabled = True
        Me.cmbTypeofreturn.Items.AddRange(New Object() {"By Date", "By Project"})
        Me.cmbTypeofreturn.Location = New System.Drawing.Point(9, 385)
        Me.cmbTypeofreturn.Name = "cmbTypeofreturn"
        Me.cmbTypeofreturn.Size = New System.Drawing.Size(216, 24)
        Me.cmbTypeofreturn.TabIndex = 415
        '
        'lbox_getdata
        '
        Me.lbox_getdata.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbox_getdata.FormattingEnabled = True
        Me.lbox_getdata.ItemHeight = 16
        Me.lbox_getdata.Location = New System.Drawing.Point(972, 499)
        Me.lbox_getdata.Name = "lbox_getdata"
        Me.lbox_getdata.Size = New System.Drawing.Size(216, 68)
        Me.lbox_getdata.TabIndex = 416
        Me.lbox_getdata.Visible = False
        '
        'txtBs_no
        '
        Me.txtBs_no.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBs_no.Location = New System.Drawing.Point(9, 72)
        Me.txtBs_no.Name = "txtBs_no"
        Me.txtBs_no.Size = New System.Drawing.Size(216, 24)
        Me.txtBs_no.TabIndex = 417
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(9, 54)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 15)
        Me.Label10.TabIndex = 418
        Me.Label10.Text = "BS_No."
        '
        'FBorrowerSlip
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SUPPLY.My.Resources.Resources.eus_bg_03
        Me.ClientSize = New System.Drawing.Size(825, 636)
        Me.Controls.Add(Me.txtBs_no)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.lbox_getdata)
        Me.Controls.Add(Me.cmbTypeofreturn)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnFac_Save)
        Me.Controls.Add(Me.lvlFacTools)
        Me.Controls.Add(Me.txtApprovedBy)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtNotedBy)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.dtpDateReturn)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtBorrowedby)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtPurpose)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.cmbChargeTo)
        Me.Controls.Add(Me.txtChargeTo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.cmbTypeofCharge)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.dtpDateBorrow)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.pboxHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FBorrowerSlip"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FBorrowerSlip"
        CType(Me.pboxHeader, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents pboxHeader As System.Windows.Forms.PictureBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dtpDateBorrow As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cmbTypeofCharge As System.Windows.Forms.ComboBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents cmbChargeTo As System.Windows.Forms.ComboBox
    Friend WithEvents txtChargeTo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPurpose As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtBorrowedby As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpDateReturn As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtNotedBy As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtApprovedBy As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lvlFacTools As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnFac_Save As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbTypeofreturn As System.Windows.Forms.ComboBox
    Friend WithEvents lbox_getdata As System.Windows.Forms.ListBox
    Friend WithEvents txtBs_no As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
End Class
