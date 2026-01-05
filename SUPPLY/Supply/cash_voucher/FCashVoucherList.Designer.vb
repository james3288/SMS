<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FCashVoucherList
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
        Me.gboxSearch = New System.Windows.Forms.GroupBox()
        Me.lblSearchByCategory = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.cmbSearch = New System.Windows.Forms.ComboBox()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lvlvoucherlist = New System.Windows.Forms.ListView()
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader17 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader14 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cms_CashVoucherList = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.panel_cv_date_to_from = New System.Windows.Forms.Panel()
        Me.btn_view = New System.Windows.Forms.Button()
        Me.btn_paneLExt = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Dtp_cv_dateto = New System.Windows.Forms.DateTimePicker()
        Me.Dtp_cv_datefrom = New System.Windows.Forms.DateTimePicker()
        Me.dtp_cv_date = New System.Windows.Forms.DateTimePicker()
        Me.ColumnHeader15 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.gboxSearch.SuspendLayout()
        Me.cms_CashVoucherList.SuspendLayout()
        Me.panel_cv_date_to_from.SuspendLayout()
        CType(Me.btn_paneLExt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gboxSearch
        '
        Me.gboxSearch.BackColor = System.Drawing.Color.Transparent
        Me.gboxSearch.Controls.Add(Me.lblSearchByCategory)
        Me.gboxSearch.Controls.Add(Me.btnSearch)
        Me.gboxSearch.Controls.Add(Me.cmbSearch)
        Me.gboxSearch.Controls.Add(Me.txtSearch)
        Me.gboxSearch.Location = New System.Drawing.Point(9, 515)
        Me.gboxSearch.Name = "gboxSearch"
        Me.gboxSearch.Size = New System.Drawing.Size(768, 47)
        Me.gboxSearch.TabIndex = 360
        Me.gboxSearch.TabStop = False
        '
        'lblSearchByCategory
        '
        Me.lblSearchByCategory.AutoSize = True
        Me.lblSearchByCategory.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSearchByCategory.ForeColor = System.Drawing.Color.White
        Me.lblSearchByCategory.Location = New System.Drawing.Point(6, 19)
        Me.lblSearchByCategory.Name = "lblSearchByCategory"
        Me.lblSearchByCategory.Size = New System.Drawing.Size(122, 15)
        Me.lblSearchByCategory.TabIndex = 357
        Me.lblSearchByCategory.Text = "Search By Category:"
        '
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(628, 13)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(131, 27)
        Me.btnSearch.TabIndex = 356
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'cmbSearch
        '
        Me.cmbSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSearch.FormattingEnabled = True
        Me.cmbSearch.Items.AddRange(New Object() {"Search by RS No.", "Search by CV No.", "Search by CV Date", "Search by Item Description", "Filter by Month/Year"})
        Me.cmbSearch.Location = New System.Drawing.Point(129, 15)
        Me.cmbSearch.Name = "cmbSearch"
        Me.cmbSearch.Size = New System.Drawing.Size(223, 24)
        Me.cmbSearch.TabIndex = 356
        '
        'txtSearch
        '
        Me.txtSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(358, 16)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(264, 22)
        Me.txtSearch.TabIndex = 355
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.Transparent
        Me.btnExit.BackgroundImage = Global.SUPPLY.My.Resources.Resources.close_button
        Me.btnExit.FlatAppearance.BorderSize = 0
        Me.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit.Location = New System.Drawing.Point(1281, 11)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(20, 20)
        Me.btnExit.TabIndex = 359
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(14, 15)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(145, 22)
        Me.Label15.TabIndex = 357
        Me.Label15.Text = "Cash Voucher List"
        '
        'lvlvoucherlist
        '
        Me.lvlvoucherlist.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader13, Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader11, Me.ColumnHeader17, Me.ColumnHeader8, Me.ColumnHeader14, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader4, Me.ColumnHeader12, Me.ColumnHeader15})
        Me.lvlvoucherlist.ContextMenuStrip = Me.cms_CashVoucherList
        Me.lvlvoucherlist.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvlvoucherlist.FullRowSelect = True
        Me.lvlvoucherlist.GridLines = True
        Me.lvlvoucherlist.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvlvoucherlist.HideSelection = False
        Me.lvlvoucherlist.Location = New System.Drawing.Point(13, 53)
        Me.lvlvoucherlist.Name = "lvlvoucherlist"
        Me.lvlvoucherlist.Size = New System.Drawing.Size(1286, 453)
        Me.lvlvoucherlist.TabIndex = 358
        Me.lvlvoucherlist.UseCompatibleStateImageBehavior = False
        Me.lvlvoucherlist.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "ID"
        Me.ColumnHeader13.Width = 0
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "C.V. Date"
        Me.ColumnHeader1.Width = 130
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "R.S. No"
        Me.ColumnHeader2.Width = 130
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "C.V. No"
        Me.ColumnHeader3.Width = 130
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Item Description"
        Me.ColumnHeader11.Width = 250
        '
        'ColumnHeader17
        '
        Me.ColumnHeader17.Text = "Paid To"
        Me.ColumnHeader17.Width = 200
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Charge To"
        Me.ColumnHeader8.Width = 250
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.Text = "Qty Request"
        Me.ColumnHeader14.Width = 100
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Qty Received"
        Me.ColumnHeader5.Width = 100
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Amount"
        Me.ColumnHeader6.Width = 120
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Total"
        Me.ColumnHeader7.Width = 130
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Received by"
        Me.ColumnHeader9.Width = 0
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "rs_id"
        Me.ColumnHeader10.Width = 0
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Status"
        Me.ColumnHeader4.Width = 150
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "in/out"
        '
        'cms_CashVoucherList
        '
        Me.cms_CashVoucherList.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.cms_CashVoucherList.Name = "cms_CashVoucherList"
        Me.cms_CashVoucherList.Size = New System.Drawing.Size(113, 48)
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'panel_cv_date_to_from
        '
        Me.panel_cv_date_to_from.BackColor = System.Drawing.Color.Transparent
        Me.panel_cv_date_to_from.Controls.Add(Me.btn_view)
        Me.panel_cv_date_to_from.Controls.Add(Me.btn_paneLExt)
        Me.panel_cv_date_to_from.Controls.Add(Me.Label1)
        Me.panel_cv_date_to_from.Controls.Add(Me.Label2)
        Me.panel_cv_date_to_from.Controls.Add(Me.Dtp_cv_dateto)
        Me.panel_cv_date_to_from.Controls.Add(Me.Dtp_cv_datefrom)
        Me.panel_cv_date_to_from.Location = New System.Drawing.Point(611, 163)
        Me.panel_cv_date_to_from.Name = "panel_cv_date_to_from"
        Me.panel_cv_date_to_from.Size = New System.Drawing.Size(281, 180)
        Me.panel_cv_date_to_from.TabIndex = 364
        '
        'btn_view
        '
        Me.btn_view.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_view.Location = New System.Drawing.Point(195, 135)
        Me.btn_view.Name = "btn_view"
        Me.btn_view.Size = New System.Drawing.Size(73, 30)
        Me.btn_view.TabIndex = 375
        Me.btn_view.Text = "View"
        Me.btn_view.UseVisualStyleBackColor = True
        '
        'btn_paneLExt
        '
        Me.btn_paneLExt.BackColor = System.Drawing.Color.Transparent
        Me.btn_paneLExt.BackgroundImage = Global.SUPPLY.My.Resources.Resources.close_button
        Me.btn_paneLExt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_paneLExt.Location = New System.Drawing.Point(246, 8)
        Me.btn_paneLExt.Name = "btn_paneLExt"
        Me.btn_paneLExt.Size = New System.Drawing.Size(22, 22)
        Me.btn_paneLExt.TabIndex = 374
        Me.btn_paneLExt.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(10, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 20)
        Me.Label1.TabIndex = 373
        Me.Label1.Text = "To"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(10, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 16)
        Me.Label2.TabIndex = 372
        Me.Label2.Text = "FROM"
        '
        'Dtp_cv_dateto
        '
        Me.Dtp_cv_dateto.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dtp_cv_dateto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dtp_cv_dateto.Location = New System.Drawing.Point(13, 104)
        Me.Dtp_cv_dateto.Name = "Dtp_cv_dateto"
        Me.Dtp_cv_dateto.Size = New System.Drawing.Size(255, 22)
        Me.Dtp_cv_dateto.TabIndex = 371
        '
        'Dtp_cv_datefrom
        '
        Me.Dtp_cv_datefrom.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dtp_cv_datefrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dtp_cv_datefrom.Location = New System.Drawing.Point(13, 36)
        Me.Dtp_cv_datefrom.Name = "Dtp_cv_datefrom"
        Me.Dtp_cv_datefrom.Size = New System.Drawing.Size(255, 22)
        Me.Dtp_cv_datefrom.TabIndex = 370
        '
        'dtp_cv_date
        '
        Me.dtp_cv_date.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_cv_date.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_cv_date.Location = New System.Drawing.Point(367, 760)
        Me.dtp_cv_date.Name = "dtp_cv_date"
        Me.dtp_cv_date.Size = New System.Drawing.Size(200, 22)
        Me.dtp_cv_date.TabIndex = 363
        '
        'ColumnHeader15
        '
        Me.ColumnHeader15.Text = "Type Of Purchase"
        Me.ColumnHeader15.Width = 100
        '
        'FCashVoucherList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SUPPLY.My.Resources.Resources.eus_bg_03
        Me.ClientSize = New System.Drawing.Size(1313, 576)
        Me.Controls.Add(Me.panel_cv_date_to_from)
        Me.Controls.Add(Me.dtp_cv_date)
        Me.Controls.Add(Me.gboxSearch)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.lvlvoucherlist)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FCashVoucherList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.gboxSearch.ResumeLayout(False)
        Me.gboxSearch.PerformLayout()
        Me.cms_CashVoucherList.ResumeLayout(False)
        Me.panel_cv_date_to_from.ResumeLayout(False)
        Me.panel_cv_date_to_from.PerformLayout()
        CType(Me.btn_paneLExt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gboxSearch As System.Windows.Forms.GroupBox
    Friend WithEvents lblSearchByCategory As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents cmbSearch As System.Windows.Forms.ComboBox
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lvlvoucherlist As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader17 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents cms_CashVoucherList As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents panel_cv_date_to_from As System.Windows.Forms.Panel
    Friend WithEvents btn_view As System.Windows.Forms.Button
    Friend WithEvents btn_paneLExt As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Dtp_cv_dateto As System.Windows.Forms.DateTimePicker
    Friend WithEvents Dtp_cv_datefrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_cv_date As System.Windows.Forms.DateTimePicker
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader14 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader15 As System.Windows.Forms.ColumnHeader
End Class
