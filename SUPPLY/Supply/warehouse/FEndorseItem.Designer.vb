<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FEndorseItem
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
        Me.lvlEndorseItems = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader15 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.pnl_newqty = New System.Windows.Forms.Panel()
        Me.txtApproved_by = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtWhIncharge = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmb_factools = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtrequestqty = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmb_typeof_pucrchasing = New System.Windows.Forms.ComboBox()
        Me.cmb_inOut_New = New System.Windows.Forms.ComboBox()
        Me.btn_ok = New System.Windows.Forms.Button()
        Me.txt_remarks = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_reorderPoint = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_balanceNew = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_close = New System.Windows.Forms.Button()
        Me.lboxUnit = New System.Windows.Forms.ListBox()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader14 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnl_newqty.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvlEndorseItems
        '
        Me.lvlEndorseItems.CheckBoxes = True
        Me.lvlEndorseItems.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader15})
        Me.lvlEndorseItems.FullRowSelect = True
        Me.lvlEndorseItems.HideSelection = False
        Me.lvlEndorseItems.Location = New System.Drawing.Point(12, 41)
        Me.lvlEndorseItems.Name = "lvlEndorseItems"
        Me.lvlEndorseItems.Size = New System.Drawing.Size(954, 232)
        Me.lvlEndorseItems.TabIndex = 1
        Me.lvlEndorseItems.UseCompatibleStateImageBehavior = False
        Me.lvlEndorseItems.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "endorse_item_id"
        Me.ColumnHeader1.Width = 0
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "wh_id"
        Me.ColumnHeader2.Width = 50
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Item Name"
        Me.ColumnHeader3.Width = 250
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Item Description"
        Me.ColumnHeader4.Width = 250
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Reorder Point"
        Me.ColumnHeader5.Width = 100
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "WH/Stockpile Area"
        Me.ColumnHeader6.Width = 150
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Source/Classification"
        Me.ColumnHeader7.Width = 150
        '
        'ColumnHeader15
        '
        Me.ColumnHeader15.Text = "from_wh"
        '
        'pnl_newqty
        '
        Me.pnl_newqty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_newqty.Controls.Add(Me.txtApproved_by)
        Me.pnl_newqty.Controls.Add(Me.Label11)
        Me.pnl_newqty.Controls.Add(Me.txtWhIncharge)
        Me.pnl_newqty.Controls.Add(Me.Label10)
        Me.pnl_newqty.Controls.Add(Me.cmb_factools)
        Me.pnl_newqty.Controls.Add(Me.Label9)
        Me.pnl_newqty.Controls.Add(Me.txtrequestqty)
        Me.pnl_newqty.Controls.Add(Me.Label8)
        Me.pnl_newqty.Controls.Add(Me.cmb_typeof_pucrchasing)
        Me.pnl_newqty.Controls.Add(Me.cmb_inOut_New)
        Me.pnl_newqty.Controls.Add(Me.btn_ok)
        Me.pnl_newqty.Controls.Add(Me.txt_remarks)
        Me.pnl_newqty.Controls.Add(Me.Label7)
        Me.pnl_newqty.Controls.Add(Me.Label6)
        Me.pnl_newqty.Controls.Add(Me.Label5)
        Me.pnl_newqty.Controls.Add(Me.txt_reorderPoint)
        Me.pnl_newqty.Controls.Add(Me.Label4)
        Me.pnl_newqty.Controls.Add(Me.txt_balanceNew)
        Me.pnl_newqty.Controls.Add(Me.Label1)
        Me.pnl_newqty.Controls.Add(Me.btn_close)
        Me.pnl_newqty.Location = New System.Drawing.Point(249, 69)
        Me.pnl_newqty.Name = "pnl_newqty"
        Me.pnl_newqty.Size = New System.Drawing.Size(308, 367)
        Me.pnl_newqty.TabIndex = 455
        Me.pnl_newqty.Visible = False
        '
        'txtApproved_by
        '
        Me.txtApproved_by.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtApproved_by.Location = New System.Drawing.Point(116, 285)
        Me.txtApproved_by.Name = "txtApproved_by"
        Me.txtApproved_by.Size = New System.Drawing.Size(176, 21)
        Me.txtApproved_by.TabIndex = 8
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(42, 290)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(71, 13)
        Me.Label11.TabIndex = 416
        Me.Label11.Text = "Approved By:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtWhIncharge
        '
        Me.txtWhIncharge.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWhIncharge.Location = New System.Drawing.Point(117, 255)
        Me.txtWhIncharge.Name = "txtWhIncharge"
        Me.txtWhIncharge.Size = New System.Drawing.Size(176, 21)
        Me.txtWhIncharge.TabIndex = 7
        Me.txtWhIncharge.Text = "Abas, Alanaica P."
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(3, 260)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(110, 13)
        Me.Label10.TabIndex = 414
        Me.Label10.Text = "Warehouse Incharge:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmb_factools
        '
        Me.cmb_factools.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_factools.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_factools.FormattingEnabled = True
        Me.cmb_factools.Items.AddRange(New Object() {"FACILITIES", "TOOLS", "N/A"})
        Me.cmb_factools.Location = New System.Drawing.Point(117, 189)
        Me.cmb_factools.Name = "cmb_factools"
        Me.cmb_factools.Size = New System.Drawing.Size(177, 23)
        Me.cmb_factools.TabIndex = 5
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(31, 194)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(78, 13)
        Me.Label9.TabIndex = 409
        Me.Label9.Text = "Facilities/Tools"
        '
        'txtrequestqty
        '
        Me.txtrequestqty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtrequestqty.Location = New System.Drawing.Point(116, 157)
        Me.txtrequestqty.Name = "txtrequestqty"
        Me.txtrequestqty.ReadOnly = True
        Me.txtrequestqty.Size = New System.Drawing.Size(177, 21)
        Me.txtrequestqty.TabIndex = 4
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(31, 161)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(78, 13)
        Me.Label8.TabIndex = 407
        Me.Label8.Text = "Requested Qty"
        '
        'cmb_typeof_pucrchasing
        '
        Me.cmb_typeof_pucrchasing.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_typeof_pucrchasing.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_typeof_pucrchasing.FormattingEnabled = True
        Me.cmb_typeof_pucrchasing.Location = New System.Drawing.Point(116, 122)
        Me.cmb_typeof_pucrchasing.Name = "cmb_typeof_pucrchasing"
        Me.cmb_typeof_pucrchasing.Size = New System.Drawing.Size(177, 23)
        Me.cmb_typeof_pucrchasing.TabIndex = 3
        '
        'cmb_inOut_New
        '
        Me.cmb_inOut_New.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_inOut_New.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_inOut_New.FormattingEnabled = True
        Me.cmb_inOut_New.Items.AddRange(New Object() {"IN", "OUT", "OTHERS"})
        Me.cmb_inOut_New.Location = New System.Drawing.Point(117, 87)
        Me.cmb_inOut_New.Name = "cmb_inOut_New"
        Me.cmb_inOut_New.Size = New System.Drawing.Size(177, 23)
        Me.cmb_inOut_New.TabIndex = 2
        '
        'btn_ok
        '
        Me.btn_ok.Location = New System.Drawing.Point(116, 321)
        Me.btn_ok.Name = "btn_ok"
        Me.btn_ok.Size = New System.Drawing.Size(177, 29)
        Me.btn_ok.TabIndex = 9
        Me.btn_ok.Text = "OK"
        Me.btn_ok.UseVisualStyleBackColor = True
        '
        'txt_remarks
        '
        Me.txt_remarks.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_remarks.Location = New System.Drawing.Point(117, 225)
        Me.txt_remarks.Name = "txt_remarks"
        Me.txt_remarks.Size = New System.Drawing.Size(176, 21)
        Me.txt_remarks.TabIndex = 6
        Me.txt_remarks.Text = "N/A"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(64, 230)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 13)
        Me.Label7.TabIndex = 403
        Me.Label7.Text = "Remarks"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 127)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(99, 13)
        Me.Label6.TabIndex = 401
        Me.Label6.Text = "Type of Purchasing"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(70, 92)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 399
        Me.Label5.Text = "In/Out"
        '
        'txt_reorderPoint
        '
        Me.txt_reorderPoint.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_reorderPoint.Location = New System.Drawing.Point(175, 54)
        Me.txt_reorderPoint.Name = "txt_reorderPoint"
        Me.txt_reorderPoint.ReadOnly = True
        Me.txt_reorderPoint.Size = New System.Drawing.Size(119, 21)
        Me.txt_reorderPoint.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(91, 58)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 13)
        Me.Label4.TabIndex = 397
        Me.Label4.Text = "Reorder Point"
        '
        'txt_balanceNew
        '
        Me.txt_balanceNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_balanceNew.Location = New System.Drawing.Point(176, 24)
        Me.txt_balanceNew.Name = "txt_balanceNew"
        Me.txt_balanceNew.ReadOnly = True
        Me.txt_balanceNew.Size = New System.Drawing.Size(119, 21)
        Me.txt_balanceNew.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(65, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 13)
        Me.Label1.TabIndex = 396
        Me.Label1.Text = "Remaining Balance"
        '
        'btn_close
        '
        Me.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_close.Location = New System.Drawing.Point(3, 2)
        Me.btn_close.Name = "btn_close"
        Me.btn_close.Size = New System.Drawing.Size(30, 27)
        Me.btn_close.TabIndex = 413
        Me.btn_close.Text = "x"
        Me.btn_close.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_close.UseVisualStyleBackColor = True
        '
        'lboxUnit
        '
        Me.lboxUnit.FormattingEnabled = True
        Me.lboxUnit.Location = New System.Drawing.Point(586, 317)
        Me.lboxUnit.Name = "lboxUnit"
        Me.lboxUnit.ScrollAlwaysVisible = True
        Me.lboxUnit.Size = New System.Drawing.Size(138, 69)
        Me.lboxUnit.TabIndex = 419
        Me.lboxUnit.Visible = False
        '
        'ListView1
        '
        Me.ListView1.CheckBoxes = True
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11, Me.ColumnHeader12, Me.ColumnHeader13, Me.ColumnHeader14})
        Me.ListView1.FullRowSelect = True
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(12, 322)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(954, 282)
        Me.ListView1.TabIndex = 456
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "endorse_item_id"
        Me.ColumnHeader8.Width = 0
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "wh_id"
        Me.ColumnHeader9.Width = 50
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Item Name"
        Me.ColumnHeader10.Width = 250
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Item Description"
        Me.ColumnHeader11.Width = 250
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "Reorder Point"
        Me.ColumnHeader12.Width = 100
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "WH/Stockpile Area"
        Me.ColumnHeader13.Width = 150
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.Text = "Source/Classification"
        Me.ColumnHeader14.Width = 150
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 293)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(172, 22)
        Me.Label2.TabIndex = 457
        Me.Label2.Text = "Suggested Items:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(152, 22)
        Me.Label3.TabIndex = 458
        Me.Label3.Text = "Selected Items:"
        '
        'FEndorseItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(978, 618)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lboxUnit)
        Me.Controls.Add(Me.pnl_newqty)
        Me.Controls.Add(Me.lvlEndorseItems)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.Label2)
        Me.Name = "FEndorseItem"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FEndorseItem"
        Me.pnl_newqty.ResumeLayout(False)
        Me.pnl_newqty.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lvlEndorseItems As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents pnl_newqty As Panel
    Friend WithEvents txtApproved_by As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtWhIncharge As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents cmb_factools As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtrequestqty As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents cmb_typeof_pucrchasing As ComboBox
    Friend WithEvents cmb_inOut_New As ComboBox
    Friend WithEvents btn_ok As Button
    Friend WithEvents txt_remarks As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txt_reorderPoint As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txt_balanceNew As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btn_close As Button
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents lboxUnit As ListBox
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents ListView1 As ListView
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents ColumnHeader9 As ColumnHeader
    Friend WithEvents ColumnHeader10 As ColumnHeader
    Friend WithEvents ColumnHeader11 As ColumnHeader
    Friend WithEvents ColumnHeader12 As ColumnHeader
    Friend WithEvents ColumnHeader13 As ColumnHeader
    Friend WithEvents ColumnHeader14 As ColumnHeader
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents ColumnHeader15 As ColumnHeader
End Class
