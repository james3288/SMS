<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FPreviousStockCard
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FPreviousStockCard))
        Me.lvList = New System.Windows.Forms.ListView()
        Me.Psc_id = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Date1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Rs_no = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Invoice_no = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Receiving_no = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Ws_no = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TypeOfRequest = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Status = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Supplier_Recipient = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Item_name = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.list_Item_desc = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.In_Out = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Balance = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Remarks = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.type_of_charge = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.type_Of_purchase = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.pboxHeader = New System.Windows.Forms.PictureBox()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.gboxSearch = New System.Windows.Forms.GroupBox()
        Me.cmbSearchByCategory = New System.Windows.Forms.ComboBox()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.lblSearchByCategory = New System.Windows.Forms.Label()
        Me.Btn_for_PreviousStockCard = New System.Windows.Forms.Button()
        Me.DTP_PSC = New System.Windows.Forms.DateTimePicker()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        CType(Me.pboxHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.gboxSearch.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvList
        '
        Me.lvList.BackColor = System.Drawing.SystemColors.Window
        Me.lvList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Psc_id, Me.Date1, Me.Rs_no, Me.Invoice_no, Me.Receiving_no, Me.Ws_no, Me.TypeOfRequest, Me.Status, Me.Supplier_Recipient, Me.Item_name, Me.list_Item_desc, Me.In_Out, Me.Balance, Me.Remarks, Me.type_of_charge, Me.type_Of_purchase, Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.lvList.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvList.FullRowSelect = True
        Me.lvList.GridLines = True
        Me.lvList.HideSelection = False
        Me.lvList.Location = New System.Drawing.Point(12, 49)
        Me.lvList.Name = "lvList"
        Me.lvList.Size = New System.Drawing.Size(1808, 730)
        Me.lvList.TabIndex = 18
        Me.lvList.UseCompatibleStateImageBehavior = False
        Me.lvList.View = System.Windows.Forms.View.Details
        '
        'Psc_id
        '
        Me.Psc_id.Text = "Psc_id"
        '
        'Date1
        '
        Me.Date1.Text = "Date"
        Me.Date1.Width = 100
        '
        'Rs_no
        '
        Me.Rs_no.Text = "Rs_no"
        Me.Rs_no.Width = 100
        '
        'Invoice_no
        '
        Me.Invoice_no.Text = "Invoice_no"
        Me.Invoice_no.Width = 100
        '
        'Receiving_no
        '
        Me.Receiving_no.Text = "Receiving_no"
        Me.Receiving_no.Width = 100
        '
        'Ws_no
        '
        Me.Ws_no.Text = "Ws_no"
        Me.Ws_no.Width = 100
        '
        'TypeOfRequest
        '
        Me.TypeOfRequest.Text = "Type of Request"
        Me.TypeOfRequest.Width = 120
        '
        'Status
        '
        Me.Status.Text = "Status"
        Me.Status.Width = 80
        '
        'Supplier_Recipient
        '
        Me.Supplier_Recipient.Text = "Supplier/Recipient"
        Me.Supplier_Recipient.Width = 150
        '
        'Item_name
        '
        Me.Item_name.Text = "Item Name"
        Me.Item_name.Width = 220
        '
        'list_Item_desc
        '
        Me.list_Item_desc.Text = "Item Desc."
        Me.list_Item_desc.Width = 220
        '
        'In_Out
        '
        Me.In_Out.Text = "In/Out"
        Me.In_Out.Width = 80
        '
        'Balance
        '
        Me.Balance.Text = "Balance"
        Me.Balance.Width = 80
        '
        'Remarks
        '
        Me.Remarks.Text = "Remarks"
        Me.Remarks.Width = 242
        '
        'type_of_charge
        '
        Me.type_of_charge.Text = "Type of Charge"
        Me.type_of_charge.Width = 0
        '
        'type_Of_purchase
        '
        Me.type_Of_purchase.Text = "type_of_purchase"
        Me.type_Of_purchase.Width = 0
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "tor_sub_id"
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "wh_area"
        Me.ColumnHeader2.Width = 250
        '
        'pboxHeader
        '
        Me.pboxHeader.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.pboxHeader.BackgroundImage = CType(resources.GetObject("pboxHeader.BackgroundImage"), System.Drawing.Image)
        Me.pboxHeader.InitialImage = Nothing
        Me.pboxHeader.Location = New System.Drawing.Point(-2, -5)
        Me.pboxHeader.Name = "pboxHeader"
        Me.pboxHeader.Size = New System.Drawing.Size(1742, 48)
        Me.pboxHeader.TabIndex = 385
        Me.pboxHeader.TabStop = False
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.Transparent
        Me.btnExit.BackgroundImage = CType(resources.GetObject("btnExit.BackgroundImage"), System.Drawing.Image)
        Me.btnExit.FlatAppearance.BorderSize = 0
        Me.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit.Location = New System.Drawing.Point(1693, 10)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(24, 25)
        Me.btnExit.TabIndex = 386
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(108, 48)
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
        'gboxSearch
        '
        Me.gboxSearch.BackColor = System.Drawing.Color.Transparent
        Me.gboxSearch.Controls.Add(Me.cmbSearchByCategory)
        Me.gboxSearch.Controls.Add(Me.txtSearch)
        Me.gboxSearch.Controls.Add(Me.btnSearch)
        Me.gboxSearch.Controls.Add(Me.lblSearchByCategory)
        Me.gboxSearch.Location = New System.Drawing.Point(11, 834)
        Me.gboxSearch.Name = "gboxSearch"
        Me.gboxSearch.Size = New System.Drawing.Size(721, 52)
        Me.gboxSearch.TabIndex = 396
        Me.gboxSearch.TabStop = False
        '
        'cmbSearchByCategory
        '
        Me.cmbSearchByCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSearchByCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbSearchByCategory.FormattingEnabled = True
        Me.cmbSearchByCategory.Items.AddRange(New Object() {"Date", "Rs_no", "Invoice_no", "Receiving_no", "Ws_no", "Item_name", "Item Desc"})
        Me.cmbSearchByCategory.Location = New System.Drawing.Point(70, 19)
        Me.cmbSearchByCategory.Name = "cmbSearchByCategory"
        Me.cmbSearchByCategory.Size = New System.Drawing.Size(179, 21)
        Me.cmbSearchByCategory.TabIndex = 15
        '
        'txtSearch
        '
        Me.txtSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(255, 18)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(308, 23)
        Me.txtSearch.TabIndex = 16
        '
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(569, 16)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(144, 27)
        Me.btnSearch.TabIndex = 17
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'lblSearchByCategory
        '
        Me.lblSearchByCategory.AutoSize = True
        Me.lblSearchByCategory.BackColor = System.Drawing.Color.Transparent
        Me.lblSearchByCategory.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSearchByCategory.ForeColor = System.Drawing.Color.White
        Me.lblSearchByCategory.Location = New System.Drawing.Point(-57, 22)
        Me.lblSearchByCategory.Name = "lblSearchByCategory"
        Me.lblSearchByCategory.Size = New System.Drawing.Size(121, 15)
        Me.lblSearchByCategory.TabIndex = 399
        Me.lblSearchByCategory.Text = "Search by Category:"
        '
        'Btn_for_PreviousStockCard
        '
        Me.Btn_for_PreviousStockCard.Location = New System.Drawing.Point(9, 6)
        Me.Btn_for_PreviousStockCard.Name = "Btn_for_PreviousStockCard"
        Me.Btn_for_PreviousStockCard.Size = New System.Drawing.Size(117, 31)
        Me.Btn_for_PreviousStockCard.TabIndex = 397
        Me.Btn_for_PreviousStockCard.Text = "Previous Stack Card"
        Me.Btn_for_PreviousStockCard.UseVisualStyleBackColor = True
        '
        'DTP_PSC
        '
        Me.DTP_PSC.Location = New System.Drawing.Point(884, 857)
        Me.DTP_PSC.Name = "DTP_PSC"
        Me.DTP_PSC.Size = New System.Drawing.Size(200, 20)
        Me.DTP_PSC.TabIndex = 398
        Me.DTP_PSC.Visible = False
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "wh_id"
        '
        'FPreviousStockCard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SUPPLY.My.Resources.Resources.bg_line
        Me.ClientSize = New System.Drawing.Size(1806, 998)
        Me.Controls.Add(Me.DTP_PSC)
        Me.Controls.Add(Me.gboxSearch)
        Me.Controls.Add(Me.Btn_for_PreviousStockCard)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.lvList)
        Me.Controls.Add(Me.pboxHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "FPreviousStockCard"
        Me.Text = "FPreviousStockCard"
        CType(Me.pboxHeader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.gboxSearch.ResumeLayout(False)
        Me.gboxSearch.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lvList As System.Windows.Forms.ListView
    Friend WithEvents Psc_id As System.Windows.Forms.ColumnHeader
    Friend WithEvents Date1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Rs_no As System.Windows.Forms.ColumnHeader
    Friend WithEvents Invoice_no As System.Windows.Forms.ColumnHeader
    Friend WithEvents Receiving_no As System.Windows.Forms.ColumnHeader
    Friend WithEvents Ws_no As System.Windows.Forms.ColumnHeader
    Friend WithEvents TypeOfRequest As System.Windows.Forms.ColumnHeader
    Friend WithEvents Status As System.Windows.Forms.ColumnHeader
    Friend WithEvents Supplier_Recipient As System.Windows.Forms.ColumnHeader
    Friend WithEvents Item_name As System.Windows.Forms.ColumnHeader
    Friend WithEvents In_Out As System.Windows.Forms.ColumnHeader
    Friend WithEvents pboxHeader As System.Windows.Forms.PictureBox
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents Balance As System.Windows.Forms.ColumnHeader
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Remarks As System.Windows.Forms.ColumnHeader
    Friend WithEvents gboxSearch As System.Windows.Forms.GroupBox
    Friend WithEvents cmbSearchByCategory As System.Windows.Forms.ComboBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents lblSearchByCategory As System.Windows.Forms.Label
    Friend WithEvents list_Item_desc As System.Windows.Forms.ColumnHeader
    Friend WithEvents type_of_charge As System.Windows.Forms.ColumnHeader
    Friend WithEvents type_Of_purchase As System.Windows.Forms.ColumnHeader
    Friend WithEvents Btn_for_PreviousStockCard As System.Windows.Forms.Button
    Friend WithEvents DTP_PSC As System.Windows.Forms.DateTimePicker
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
End Class
