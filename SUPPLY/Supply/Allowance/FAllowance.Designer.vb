<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FAllowance
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
        Me.components = New System.ComponentModel.Container()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.lvlAllowance = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblSearchByCategory = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.cmbSearch = New System.Windows.Forms.ComboBox()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.txtAmount_Salary = New System.Windows.Forms.TextBox()
        Me.lblAmount_Salary = New System.Windows.Forms.Label()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.DTP_Allowance = New System.Windows.Forms.DateTimePicker()
        Me.lblDesignation = New System.Windows.Forms.Label()
        Me.lblCancel = New System.Windows.Forms.Label()
        Me.cmbDesignation = New System.Windows.Forms.ComboBox()
        Me.lblProjectWorksite = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.lblVoucher = New System.Windows.Forms.Label()
        Me.cmbProjectWorksite = New System.Windows.Forms.ComboBox()
        Me.lblName = New System.Windows.Forms.Label()
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.txtVoucher = New System.Windows.Forms.TextBox()
        Me.lblLocation = New System.Windows.Forms.Label()
        Me.txtLocation = New System.Windows.Forms.TextBox()
        Me.lblAmount = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.DTP_search_Allowance = New System.Windows.Forms.DateTimePicker()
        Me.cmbSearch_Project_WorkSite = New System.Windows.Forms.ComboBox()
        Me.LlbTitleAllowanceSummary = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1366, 658)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel3, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel3, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 53)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1360, 602)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 1
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.lvlAllowance, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.GroupBox1, 0, 1)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(253, 3)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(1104, 596)
        Me.TableLayoutPanel3.TabIndex = 1
        '
        'lvlAllowance
        '
        Me.lvlAllowance.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9})
        Me.lvlAllowance.ContextMenuStrip = Me.ContextMenuStrip1
        Me.lvlAllowance.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvlAllowance.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvlAllowance.FullRowSelect = True
        Me.lvlAllowance.GridLines = True
        Me.lvlAllowance.HideSelection = False
        Me.lvlAllowance.Location = New System.Drawing.Point(3, 3)
        Me.lvlAllowance.Name = "lvlAllowance"
        Me.lvlAllowance.Size = New System.Drawing.Size(1098, 530)
        Me.lvlAllowance.TabIndex = 0
        Me.lvlAllowance.UseCompatibleStateImageBehavior = False
        Me.lvlAllowance.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Id"
        Me.ColumnHeader1.Width = 0
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Date"
        Me.ColumnHeader2.Width = 150
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Project Worksite"
        Me.ColumnHeader3.Width = 200
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Location"
        Me.ColumnHeader4.Width = 200
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Name"
        Me.ColumnHeader5.Width = 250
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Designation"
        Me.ColumnHeader6.Width = 150
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Voucher No."
        Me.ColumnHeader7.Width = 150
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Amount"
        Me.ColumnHeader8.Width = 150
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Amount Salary"
        Me.ColumnHeader9.Width = 160
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblSearchByCategory)
        Me.GroupBox1.Controls.Add(Me.btnSearch)
        Me.GroupBox1.Controls.Add(Me.cmbSearch)
        Me.GroupBox1.Controls.Add(Me.txtSearch)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(3, 539)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1098, 54)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'lblSearchByCategory
        '
        Me.lblSearchByCategory.AutoSize = True
        Me.lblSearchByCategory.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSearchByCategory.ForeColor = System.Drawing.Color.White
        Me.lblSearchByCategory.Location = New System.Drawing.Point(3, 23)
        Me.lblSearchByCategory.Name = "lblSearchByCategory"
        Me.lblSearchByCategory.Size = New System.Drawing.Size(68, 15)
        Me.lblSearchByCategory.TabIndex = 361
        Me.lblSearchByCategory.Text = "Search By:"
        '
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(501, 19)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(131, 27)
        Me.btnSearch.TabIndex = 11
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'cmbSearch
        '
        Me.cmbSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSearch.FormattingEnabled = True
        Me.cmbSearch.Items.AddRange(New Object() {"Date", "Project Work Site", "Name", "Voucher", "Plate No."})
        Me.cmbSearch.Location = New System.Drawing.Point(76, 19)
        Me.cmbSearch.Name = "cmbSearch"
        Me.cmbSearch.Size = New System.Drawing.Size(151, 26)
        Me.cmbSearch.TabIndex = 9
        '
        'txtSearch
        '
        Me.txtSearch.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(233, 19)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(264, 26)
        Me.txtSearch.TabIndex = 10
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.txtName)
        Me.Panel3.Controls.Add(Me.PictureBox2)
        Me.Panel3.Controls.Add(Me.txtAmount_Salary)
        Me.Panel3.Controls.Add(Me.lblAmount_Salary)
        Me.Panel3.Controls.Add(Me.lblDate)
        Me.Panel3.Controls.Add(Me.DTP_Allowance)
        Me.Panel3.Controls.Add(Me.lblDesignation)
        Me.Panel3.Controls.Add(Me.lblCancel)
        Me.Panel3.Controls.Add(Me.cmbDesignation)
        Me.Panel3.Controls.Add(Me.lblProjectWorksite)
        Me.Panel3.Controls.Add(Me.btnSave)
        Me.Panel3.Controls.Add(Me.lblVoucher)
        Me.Panel3.Controls.Add(Me.cmbProjectWorksite)
        Me.Panel3.Controls.Add(Me.lblName)
        Me.Panel3.Controls.Add(Me.txtAmount)
        Me.Panel3.Controls.Add(Me.txtVoucher)
        Me.Panel3.Controls.Add(Me.lblLocation)
        Me.Panel3.Controls.Add(Me.txtLocation)
        Me.Panel3.Controls.Add(Me.lblAmount)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(244, 596)
        Me.Panel3.TabIndex = 2
        '
        'txtName
        '
        Me.txtName.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.Location = New System.Drawing.Point(3, 162)
        Me.txtName.Name = "txtName"
        Me.txtName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtName.Size = New System.Drawing.Size(205, 26)
        Me.txtName.TabIndex = 4
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = Global.SUPPLY.My.Resources.Resources.Plus_sign
        Me.PictureBox2.Location = New System.Drawing.Point(206, 162)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(32, 26)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 431
        Me.PictureBox2.TabStop = False
        '
        'txtAmount_Salary
        '
        Me.txtAmount_Salary.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmount_Salary.Location = New System.Drawing.Point(3, 354)
        Me.txtAmount_Salary.Name = "txtAmount_Salary"
        Me.txtAmount_Salary.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtAmount_Salary.Size = New System.Drawing.Size(231, 26)
        Me.txtAmount_Salary.TabIndex = 8
        '
        'lblAmount_Salary
        '
        Me.lblAmount_Salary.AutoSize = True
        Me.lblAmount_Salary.BackColor = System.Drawing.Color.Transparent
        Me.lblAmount_Salary.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAmount_Salary.ForeColor = System.Drawing.Color.White
        Me.lblAmount_Salary.Location = New System.Drawing.Point(3, 335)
        Me.lblAmount_Salary.Name = "lblAmount_Salary"
        Me.lblAmount_Salary.Size = New System.Drawing.Size(106, 16)
        Me.lblAmount_Salary.TabIndex = 393
        Me.lblAmount_Salary.Text = "Amount Salary:"
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.BackColor = System.Drawing.Color.Transparent
        Me.lblDate.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.ForeColor = System.Drawing.Color.White
        Me.lblDate.Location = New System.Drawing.Point(3, 3)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(41, 16)
        Me.lblDate.TabIndex = 135
        Me.lblDate.Text = "Date:"
        '
        'DTP_Allowance
        '
        Me.DTP_Allowance.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_Allowance.Location = New System.Drawing.Point(3, 22)
        Me.DTP_Allowance.Name = "DTP_Allowance"
        Me.DTP_Allowance.Size = New System.Drawing.Size(232, 22)
        Me.DTP_Allowance.TabIndex = 1
        '
        'lblDesignation
        '
        Me.lblDesignation.AutoSize = True
        Me.lblDesignation.BackColor = System.Drawing.Color.Transparent
        Me.lblDesignation.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDesignation.ForeColor = System.Drawing.Color.White
        Me.lblDesignation.Location = New System.Drawing.Point(3, 191)
        Me.lblDesignation.Name = "lblDesignation"
        Me.lblDesignation.Size = New System.Drawing.Size(87, 16)
        Me.lblDesignation.TabIndex = 139
        Me.lblDesignation.Text = "Designation:"
        '
        'lblCancel
        '
        Me.lblCancel.AutoSize = True
        Me.lblCancel.BackColor = System.Drawing.Color.Transparent
        Me.lblCancel.Font = New System.Drawing.Font("Arial Narrow", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblCancel.Location = New System.Drawing.Point(3, 435)
        Me.lblCancel.Name = "lblCancel"
        Me.lblCancel.Size = New System.Drawing.Size(104, 16)
        Me.lblCancel.TabIndex = 392
        Me.lblCancel.Text = "Press ESC to Cancel"
        '
        'cmbDesignation
        '
        Me.cmbDesignation.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDesignation.FormattingEnabled = True
        Me.cmbDesignation.Location = New System.Drawing.Point(3, 210)
        Me.cmbDesignation.Name = "cmbDesignation"
        Me.cmbDesignation.Size = New System.Drawing.Size(231, 26)
        Me.cmbDesignation.TabIndex = 5
        '
        'lblProjectWorksite
        '
        Me.lblProjectWorksite.AutoSize = True
        Me.lblProjectWorksite.BackColor = System.Drawing.Color.Transparent
        Me.lblProjectWorksite.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProjectWorksite.ForeColor = System.Drawing.Color.White
        Me.lblProjectWorksite.Location = New System.Drawing.Point(3, 47)
        Me.lblProjectWorksite.Name = "lblProjectWorksite"
        Me.lblProjectWorksite.Size = New System.Drawing.Size(116, 16)
        Me.lblProjectWorksite.TabIndex = 136
        Me.lblProjectWorksite.Text = "Project/Worksite:"
        '
        'btnSave
        '
        Me.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(3, 392)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(231, 40)
        Me.btnSave.TabIndex = 9
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'lblVoucher
        '
        Me.lblVoucher.AutoSize = True
        Me.lblVoucher.BackColor = System.Drawing.Color.Transparent
        Me.lblVoucher.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVoucher.ForeColor = System.Drawing.Color.White
        Me.lblVoucher.Location = New System.Drawing.Point(3, 239)
        Me.lblVoucher.Name = "lblVoucher"
        Me.lblVoucher.Size = New System.Drawing.Size(85, 16)
        Me.lblVoucher.TabIndex = 140
        Me.lblVoucher.Text = "Voucher No:"
        '
        'cmbProjectWorksite
        '
        Me.cmbProjectWorksite.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbProjectWorksite.FormattingEnabled = True
        Me.cmbProjectWorksite.Location = New System.Drawing.Point(3, 66)
        Me.cmbProjectWorksite.Name = "cmbProjectWorksite"
        Me.cmbProjectWorksite.Size = New System.Drawing.Size(231, 26)
        Me.cmbProjectWorksite.TabIndex = 2
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.BackColor = System.Drawing.Color.Transparent
        Me.lblName.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.ForeColor = System.Drawing.Color.White
        Me.lblName.Location = New System.Drawing.Point(3, 143)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(49, 16)
        Me.lblName.TabIndex = 138
        Me.lblName.Text = "Name:"
        '
        'txtAmount
        '
        Me.txtAmount.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmount.Location = New System.Drawing.Point(3, 306)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtAmount.Size = New System.Drawing.Size(231, 26)
        Me.txtAmount.TabIndex = 7
        '
        'txtVoucher
        '
        Me.txtVoucher.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVoucher.Location = New System.Drawing.Point(3, 258)
        Me.txtVoucher.Name = "txtVoucher"
        Me.txtVoucher.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtVoucher.Size = New System.Drawing.Size(231, 26)
        Me.txtVoucher.TabIndex = 6
        '
        'lblLocation
        '
        Me.lblLocation.AutoSize = True
        Me.lblLocation.BackColor = System.Drawing.Color.Transparent
        Me.lblLocation.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLocation.ForeColor = System.Drawing.Color.White
        Me.lblLocation.Location = New System.Drawing.Point(3, 95)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Size = New System.Drawing.Size(67, 16)
        Me.lblLocation.TabIndex = 137
        Me.lblLocation.Text = "Location:"
        '
        'txtLocation
        '
        Me.txtLocation.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLocation.Location = New System.Drawing.Point(3, 114)
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtLocation.Size = New System.Drawing.Size(231, 26)
        Me.txtLocation.TabIndex = 3
        '
        'lblAmount
        '
        Me.lblAmount.AutoSize = True
        Me.lblAmount.BackColor = System.Drawing.Color.Transparent
        Me.lblAmount.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAmount.ForeColor = System.Drawing.Color.White
        Me.lblAmount.Location = New System.Drawing.Point(3, 287)
        Me.lblAmount.Name = "lblAmount"
        Me.lblAmount.Size = New System.Drawing.Size(61, 16)
        Me.lblAmount.TabIndex = 141
        Me.lblAmount.Text = "Amount:"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.DTP_search_Allowance)
        Me.Panel1.Controls.Add(Me.cmbSearch_Project_WorkSite)
        Me.Panel1.Controls.Add(Me.LlbTitleAllowanceSummary)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1360, 44)
        Me.Panel1.TabIndex = 1
        '
        'DTP_search_Allowance
        '
        Me.DTP_search_Allowance.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_search_Allowance.Location = New System.Drawing.Point(881, 15)
        Me.DTP_search_Allowance.Name = "DTP_search_Allowance"
        Me.DTP_search_Allowance.Size = New System.Drawing.Size(264, 26)
        Me.DTP_search_Allowance.TabIndex = 364
        Me.DTP_search_Allowance.Visible = False
        '
        'cmbSearch_Project_WorkSite
        '
        Me.cmbSearch_Project_WorkSite.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSearch_Project_WorkSite.FormattingEnabled = True
        Me.cmbSearch_Project_WorkSite.Location = New System.Drawing.Point(600, 15)
        Me.cmbSearch_Project_WorkSite.Name = "cmbSearch_Project_WorkSite"
        Me.cmbSearch_Project_WorkSite.Size = New System.Drawing.Size(264, 26)
        Me.cmbSearch_Project_WorkSite.TabIndex = 363
        Me.cmbSearch_Project_WorkSite.Visible = False
        '
        'LlbTitleAllowanceSummary
        '
        Me.LlbTitleAllowanceSummary.AutoSize = True
        Me.LlbTitleAllowanceSummary.BackColor = System.Drawing.Color.Transparent
        Me.LlbTitleAllowanceSummary.Font = New System.Drawing.Font("Gill Sans Ultra Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LlbTitleAllowanceSummary.ForeColor = System.Drawing.Color.White
        Me.LlbTitleAllowanceSummary.Location = New System.Drawing.Point(251, 19)
        Me.LlbTitleAllowanceSummary.Name = "LlbTitleAllowanceSummary"
        Me.LlbTitleAllowanceSummary.Size = New System.Drawing.Size(290, 26)
        Me.LlbTitleAllowanceSummary.TabIndex = 132
        Me.LlbTitleAllowanceSummary.Text = "ALLOWANCE SUMMARY"
        '
        'FAllowance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SUPPLY.My.Resources.Resources.bg_line
        Me.ClientSize = New System.Drawing.Size(1366, 658)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "FAllowance"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FAllowance"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents DTP_Allowance As DateTimePicker
    Friend WithEvents lblDate As Label
    Friend WithEvents lblProjectWorksite As Label
    Friend WithEvents cmbProjectWorksite As ComboBox
    Friend WithEvents lblLocation As Label
    Friend WithEvents txtLocation As TextBox
    Friend WithEvents lblName As Label
    Friend WithEvents txtName As TextBox
    Friend WithEvents lblDesignation As Label
    Friend WithEvents lvlAllowance As ListView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblCancel As Label
    Friend WithEvents lblSearchByCategory As Label
    Friend WithEvents btnSearch As Button
    Friend WithEvents cmbSearch As ComboBox
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents LlbTitleAllowanceSummary As Label
    Friend WithEvents lblVoucher As Label
    Friend WithEvents txtVoucher As TextBox
    Friend WithEvents lblAmount As Label
    Friend WithEvents txtAmount As TextBox
    Friend WithEvents btnSave As Button
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents cmbSearch_Project_WorkSite As ComboBox
    Friend WithEvents DTP_search_Allowance As DateTimePicker
    Friend WithEvents cmbDesignation As ComboBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents txtAmount_Salary As TextBox
    Friend WithEvents lblAmount_Salary As Label
    Friend WithEvents ColumnHeader9 As ColumnHeader
    Friend WithEvents PictureBox2 As PictureBox
End Class
