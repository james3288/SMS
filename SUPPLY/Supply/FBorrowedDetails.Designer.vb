<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FBorrowedDetails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FBorrowedDetails))
        Me.lvList = New System.Windows.Forms.ListView
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader5 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader6 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader7 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader8 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader9 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader10 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader11 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader12 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader13 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader14 = New System.Windows.Forms.ColumnHeader
        Me.CMS_lvList = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ItemReturnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.pnlReturnBox = New System.Windows.Forms.Panel
        Me.btnExit = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.txtReturnby = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.DTPdateReturn = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.pboxHeader = New System.Windows.Forms.PictureBox
        Me.btnExit2 = New System.Windows.Forms.Button
        Me.gboxSearch = New System.Windows.Forms.GroupBox
        Me.dtpsearchdatereq = New System.Windows.Forms.DateTimePicker
        Me.cmbSearchByCategory = New System.Windows.Forms.ComboBox
        Me.btnSearch = New System.Windows.Forms.Button
        Me.txtSearch = New System.Windows.Forms.TextBox
        Me.lblSearchByCategory = New System.Windows.Forms.Label
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ColumnHeader15 = New System.Windows.Forms.ColumnHeader
        Me.CMS_lvList.SuspendLayout()
        Me.pnlReturnBox.SuspendLayout()
        CType(Me.pboxHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gboxSearch.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvList
        '
        Me.lvList.BackColor = System.Drawing.SystemColors.Window
        Me.lvList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11, Me.ColumnHeader12, Me.ColumnHeader3, Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader13, Me.ColumnHeader14, Me.ColumnHeader15})
        Me.lvList.ContextMenuStrip = Me.CMS_lvList
        Me.lvList.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvList.FullRowSelect = True
        Me.lvList.GridLines = True
        Me.lvList.HideSelection = False
        Me.lvList.Location = New System.Drawing.Point(12, 59)
        Me.lvList.Name = "lvList"
        Me.lvList.Size = New System.Drawing.Size(1407, 560)
        Me.lvList.TabIndex = 8
        Me.lvList.UseCompatibleStateImageBehavior = False
        Me.lvList.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "id"
        Me.ColumnHeader4.Width = 0
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Item Type"
        Me.ColumnHeader5.Width = 200
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Specification"
        Me.ColumnHeader6.Width = 200
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Item Details"
        Me.ColumnHeader7.Width = 200
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Qty"
        Me.ColumnHeader8.Width = 80
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Borrowed for"
        Me.ColumnHeader9.Width = 200
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Borrowed by"
        Me.ColumnHeader10.Width = 200
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Date Borrowed"
        Me.ColumnHeader11.Width = 200
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "Date of return"
        Me.ColumnHeader12.Width = 180
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Date Returned"
        Me.ColumnHeader3.Width = 150
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Status"
        Me.ColumnHeader1.Width = 100
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "No. of day used"
        Me.ColumnHeader2.Width = 100
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "rr_item_id"
        Me.ColumnHeader13.Width = 100
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.Text = "bs_no"
        '
        'CMS_lvList
        '
        Me.CMS_lvList.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ItemReturnToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.CMS_lvList.Name = "CMS_lvList"
        Me.CMS_lvList.Size = New System.Drawing.Size(137, 70)
        '
        'ItemReturnToolStripMenuItem
        '
        Me.ItemReturnToolStripMenuItem.Name = "ItemReturnToolStripMenuItem"
        Me.ItemReturnToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ItemReturnToolStripMenuItem.Text = "Item Return"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'pnlReturnBox
        '
        Me.pnlReturnBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.pnlReturnBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlReturnBox.Controls.Add(Me.btnExit)
        Me.pnlReturnBox.Controls.Add(Me.btnSave)
        Me.pnlReturnBox.Controls.Add(Me.txtReturnby)
        Me.pnlReturnBox.Controls.Add(Me.Label4)
        Me.pnlReturnBox.Controls.Add(Me.DTPdateReturn)
        Me.pnlReturnBox.Controls.Add(Me.Label1)
        Me.pnlReturnBox.Location = New System.Drawing.Point(564, 269)
        Me.pnlReturnBox.Name = "pnlReturnBox"
        Me.pnlReturnBox.Size = New System.Drawing.Size(261, 210)
        Me.pnlReturnBox.TabIndex = 9
        Me.pnlReturnBox.Visible = False
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.Transparent
        Me.btnExit.BackgroundImage = Global.SUPPLY.My.Resources.Resources.close_button
        Me.btnExit.FlatAppearance.BorderSize = 0
        Me.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit.Location = New System.Drawing.Point(233, 7)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(22, 22)
        Me.btnExit.TabIndex = 386
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(24, 150)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(215, 37)
        Me.btnSave.TabIndex = 364
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'txtReturnby
        '
        Me.txtReturnby.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReturnby.Location = New System.Drawing.Point(24, 104)
        Me.txtReturnby.Name = "txtReturnby"
        Me.txtReturnby.Size = New System.Drawing.Size(216, 24)
        Me.txtReturnby.TabIndex = 362
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(24, 86)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 15)
        Me.Label4.TabIndex = 363
        Me.Label4.Text = "Returned by:"
        '
        'DTPdateReturn
        '
        Me.DTPdateReturn.CustomFormat = ""
        Me.DTPdateReturn.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPdateReturn.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPdateReturn.Location = New System.Drawing.Point(24, 41)
        Me.DTPdateReturn.Margin = New System.Windows.Forms.Padding(10, 3, 3, 3)
        Me.DTPdateReturn.Name = "DTPdateReturn"
        Me.DTPdateReturn.Size = New System.Drawing.Size(216, 26)
        Me.DTPdateReturn.TabIndex = 356
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(24, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 15)
        Me.Label1.TabIndex = 357
        Me.Label1.Text = "Date Returned:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(17, 10)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(139, 22)
        Me.Label15.TabIndex = 323
        Me.Label15.Text = "Borrower Details"
        '
        'pboxHeader
        '
        Me.pboxHeader.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.pboxHeader.BackgroundImage = CType(resources.GetObject("pboxHeader.BackgroundImage"), System.Drawing.Image)
        Me.pboxHeader.InitialImage = Nothing
        Me.pboxHeader.Location = New System.Drawing.Point(1, 1)
        Me.pboxHeader.Name = "pboxHeader"
        Me.pboxHeader.Size = New System.Drawing.Size(1430, 41)
        Me.pboxHeader.TabIndex = 324
        Me.pboxHeader.TabStop = False
        '
        'btnExit2
        '
        Me.btnExit2.BackColor = System.Drawing.Color.Transparent
        Me.btnExit2.BackgroundImage = Global.SUPPLY.My.Resources.Resources.close_button
        Me.btnExit2.FlatAppearance.BorderSize = 0
        Me.btnExit2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnExit2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnExit2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit2.Location = New System.Drawing.Point(1397, 10)
        Me.btnExit2.Name = "btnExit2"
        Me.btnExit2.Size = New System.Drawing.Size(22, 22)
        Me.btnExit2.TabIndex = 387
        Me.btnExit2.UseVisualStyleBackColor = False
        '
        'gboxSearch
        '
        Me.gboxSearch.BackColor = System.Drawing.Color.Transparent
        Me.gboxSearch.Controls.Add(Me.dtpsearchdatereq)
        Me.gboxSearch.Controls.Add(Me.cmbSearchByCategory)
        Me.gboxSearch.Controls.Add(Me.btnSearch)
        Me.gboxSearch.Controls.Add(Me.txtSearch)
        Me.gboxSearch.Controls.Add(Me.lblSearchByCategory)
        Me.gboxSearch.Location = New System.Drawing.Point(12, 625)
        Me.gboxSearch.Name = "gboxSearch"
        Me.gboxSearch.Size = New System.Drawing.Size(782, 46)
        Me.gboxSearch.TabIndex = 398
        Me.gboxSearch.TabStop = False
        '
        'dtpsearchdatereq
        '
        Me.dtpsearchdatereq.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpsearchdatereq.Location = New System.Drawing.Point(991, 14)
        Me.dtpsearchdatereq.Name = "dtpsearchdatereq"
        Me.dtpsearchdatereq.Size = New System.Drawing.Size(239, 22)
        Me.dtpsearchdatereq.TabIndex = 400
        '
        'cmbSearchByCategory
        '
        Me.cmbSearchByCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSearchByCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbSearchByCategory.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSearchByCategory.FormattingEnabled = True
        Me.cmbSearchByCategory.Items.AddRange(New Object() {"Search by Item Details"})
        Me.cmbSearchByCategory.Location = New System.Drawing.Point(131, 14)
        Me.cmbSearchByCategory.Name = "cmbSearchByCategory"
        Me.cmbSearchByCategory.Size = New System.Drawing.Size(223, 24)
        Me.cmbSearchByCategory.TabIndex = 396
        '
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(629, 13)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(144, 25)
        Me.btnSearch.TabIndex = 398
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtSearch
        '
        Me.txtSearch.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(360, 15)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(264, 22)
        Me.txtSearch.TabIndex = 397
        '
        'lblSearchByCategory
        '
        Me.lblSearchByCategory.AutoSize = True
        Me.lblSearchByCategory.BackColor = System.Drawing.Color.Transparent
        Me.lblSearchByCategory.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSearchByCategory.ForeColor = System.Drawing.Color.White
        Me.lblSearchByCategory.Location = New System.Drawing.Point(7, 19)
        Me.lblSearchByCategory.Name = "lblSearchByCategory"
        Me.lblSearchByCategory.Size = New System.Drawing.Size(121, 15)
        Me.lblSearchByCategory.TabIndex = 399
        Me.lblSearchByCategory.Text = "Search by Category:"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'ColumnHeader15
        '
        Me.ColumnHeader15.Text = "borrower_slid_id"
        '
        'FBorrowedDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SUPPLY.My.Resources.Resources.eus_bg_03
        Me.ClientSize = New System.Drawing.Size(1611, 808)
        Me.Controls.Add(Me.gboxSearch)
        Me.Controls.Add(Me.btnExit2)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.pnlReturnBox)
        Me.Controls.Add(Me.lvList)
        Me.Controls.Add(Me.pboxHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FBorrowedDetails"
        Me.Text = "FBorrowedDetails"
        Me.CMS_lvList.ResumeLayout(False)
        Me.pnlReturnBox.ResumeLayout(False)
        Me.pnlReturnBox.PerformLayout()
        CType(Me.pboxHeader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gboxSearch.ResumeLayout(False)
        Me.gboxSearch.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lvList As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents pnlReturnBox As System.Windows.Forms.Panel
    Friend WithEvents DTPdateReturn As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtReturnby As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CMS_lvList As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ItemReturnToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents pboxHeader As System.Windows.Forms.PictureBox
    Friend WithEvents btnExit2 As System.Windows.Forms.Button
    Friend WithEvents gboxSearch As System.Windows.Forms.GroupBox
    Friend WithEvents dtpsearchdatereq As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbSearchByCategory As System.Windows.Forms.ComboBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents lblSearchByCategory As System.Windows.Forms.Label
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColumnHeader14 As System.Windows.Forms.ColumnHeader
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColumnHeader15 As System.Windows.Forms.ColumnHeader
End Class
