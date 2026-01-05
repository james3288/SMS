<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FProject_maintenance
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FProject_maintenance))
        Me.txt_search = New System.Windows.Forms.TextBox()
        Me.btn_close = New System.Windows.Forms.Button()
        Me.btn_save = New System.Windows.Forms.Button()
        Me.txtlocation = New System.Windows.Forms.TextBox()
        Me.lbl_location = New System.Windows.Forms.Label()
        Me.txtprojectdesc = New System.Windows.Forms.TextBox()
        Me.lbl_projectdesc = New System.Windows.Forms.Label()
        Me.pnl_projectdesc = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbDateClose = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dtpDateCompletion = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dtpDateTo = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dtpDateFrom = New System.Windows.Forms.DateTimePicker()
        Me.txtBudgetaryamount = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtContractamount = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtProjectengineer = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtProjectduration = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtContractName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtContractId = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DeteleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cms_projectdesc = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lvl_projectDesc = New System.Windows.Forms.ListView()
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label15 = New System.Windows.Forms.Label()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.pboxHeader = New System.Windows.Forms.PictureBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.cmbActiveEnactive = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.loadingPanel = New System.Windows.Forms.Panel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.debounce = New System.Windows.Forms.Timer(Me.components)
        Me.pnl_projectdesc.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.cms_projectdesc.SuspendLayout()
        CType(Me.pboxHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.loadingPanel.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txt_search
        '
        Me.txt_search.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_search.Location = New System.Drawing.Point(59, 8)
        Me.txt_search.Name = "txt_search"
        Me.txt_search.Size = New System.Drawing.Size(294, 26)
        Me.txt_search.TabIndex = 413
        '
        'btn_close
        '
        Me.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_close.Location = New System.Drawing.Point(429, 6)
        Me.btn_close.Name = "btn_close"
        Me.btn_close.Size = New System.Drawing.Size(19, 24)
        Me.btn_close.TabIndex = 397
        Me.btn_close.Text = "x"
        Me.btn_close.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_close.UseVisualStyleBackColor = True
        '
        'btn_save
        '
        Me.btn_save.Location = New System.Drawing.Point(360, 349)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(87, 27)
        Me.btn_save.TabIndex = 9
        Me.btn_save.Text = "Save"
        Me.btn_save.UseVisualStyleBackColor = True
        '
        'txtlocation
        '
        Me.txtlocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtlocation.Location = New System.Drawing.Point(9, 101)
        Me.txtlocation.Name = "txtlocation"
        Me.txtlocation.Size = New System.Drawing.Size(208, 21)
        Me.txtlocation.TabIndex = 2
        '
        'lbl_location
        '
        Me.lbl_location.AutoSize = True
        Me.lbl_location.Location = New System.Drawing.Point(8, 85)
        Me.lbl_location.Name = "lbl_location"
        Me.lbl_location.Size = New System.Drawing.Size(51, 13)
        Me.lbl_location.TabIndex = 406
        Me.lbl_location.Text = "Location:"
        '
        'txtprojectdesc
        '
        Me.txtprojectdesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtprojectdesc.Location = New System.Drawing.Point(9, 52)
        Me.txtprojectdesc.Name = "txtprojectdesc"
        Me.txtprojectdesc.Size = New System.Drawing.Size(208, 21)
        Me.txtprojectdesc.TabIndex = 1
        '
        'lbl_projectdesc
        '
        Me.lbl_projectdesc.AutoSize = True
        Me.lbl_projectdesc.Location = New System.Drawing.Point(8, 36)
        Me.lbl_projectdesc.Name = "lbl_projectdesc"
        Me.lbl_projectdesc.Size = New System.Drawing.Size(99, 13)
        Me.lbl_projectdesc.TabIndex = 397
        Me.lbl_projectdesc.Text = "Project Description:"
        '
        'pnl_projectdesc
        '
        Me.pnl_projectdesc.BackColor = System.Drawing.SystemColors.Menu
        Me.pnl_projectdesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_projectdesc.Controls.Add(Me.GroupBox1)
        Me.pnl_projectdesc.Controls.Add(Me.txtBudgetaryamount)
        Me.pnl_projectdesc.Controls.Add(Me.Label6)
        Me.pnl_projectdesc.Controls.Add(Me.txtContractamount)
        Me.pnl_projectdesc.Controls.Add(Me.Label7)
        Me.pnl_projectdesc.Controls.Add(Me.txtProjectengineer)
        Me.pnl_projectdesc.Controls.Add(Me.Label4)
        Me.pnl_projectdesc.Controls.Add(Me.txtProjectduration)
        Me.pnl_projectdesc.Controls.Add(Me.Label5)
        Me.pnl_projectdesc.Controls.Add(Me.txtContractName)
        Me.pnl_projectdesc.Controls.Add(Me.Label2)
        Me.pnl_projectdesc.Controls.Add(Me.txtContractId)
        Me.pnl_projectdesc.Controls.Add(Me.Label3)
        Me.pnl_projectdesc.Controls.Add(Me.btn_close)
        Me.pnl_projectdesc.Controls.Add(Me.btn_save)
        Me.pnl_projectdesc.Controls.Add(Me.txtlocation)
        Me.pnl_projectdesc.Controls.Add(Me.lbl_location)
        Me.pnl_projectdesc.Controls.Add(Me.txtprojectdesc)
        Me.pnl_projectdesc.Controls.Add(Me.lbl_projectdesc)
        Me.pnl_projectdesc.Location = New System.Drawing.Point(392, 164)
        Me.pnl_projectdesc.Name = "pnl_projectdesc"
        Me.pnl_projectdesc.Size = New System.Drawing.Size(453, 386)
        Me.pnl_projectdesc.TabIndex = 412
        Me.pnl_projectdesc.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbDateClose)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.dtpDateCompletion)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.dtpDateTo)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.dtpDateFrom)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 230)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(429, 113)
        Me.GroupBox1.TabIndex = 419
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Project Duration"
        '
        'cmbDateClose
        '
        Me.cmbDateClose.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDateClose.FormattingEnabled = True
        Me.cmbDateClose.Items.AddRange(New Object() {"Date Close", "Date Open"})
        Me.cmbDateClose.Location = New System.Drawing.Point(6, 77)
        Me.cmbDateClose.Name = "cmbDateClose"
        Me.cmbDateClose.Size = New System.Drawing.Size(186, 21)
        Me.cmbDateClose.TabIndex = 7
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(7, 61)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(26, 13)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = "Set:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(223, 61)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(88, 13)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "Date Completion:"
        '
        'dtpDateCompletion
        '
        Me.dtpDateCompletion.Location = New System.Drawing.Point(222, 78)
        Me.dtpDateCompletion.Name = "dtpDateCompletion"
        Me.dtpDateCompletion.Size = New System.Drawing.Size(186, 20)
        Me.dtpDateCompletion.TabIndex = 4
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(223, 15)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(23, 13)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "To:"
        '
        'dtpDateTo
        '
        Me.dtpDateTo.Enabled = False
        Me.dtpDateTo.Location = New System.Drawing.Point(222, 32)
        Me.dtpDateTo.Name = "dtpDateTo"
        Me.dtpDateTo.Size = New System.Drawing.Size(186, 20)
        Me.dtpDateTo.TabIndex = 2
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(7, 15)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(33, 13)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "From:"
        '
        'dtpDateFrom
        '
        Me.dtpDateFrom.Enabled = False
        Me.dtpDateFrom.Location = New System.Drawing.Point(6, 32)
        Me.dtpDateFrom.Name = "dtpDateFrom"
        Me.dtpDateFrom.Size = New System.Drawing.Size(186, 20)
        Me.dtpDateFrom.TabIndex = 0
        '
        'txtBudgetaryamount
        '
        Me.txtBudgetaryamount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBudgetaryamount.Location = New System.Drawing.Point(236, 201)
        Me.txtBudgetaryamount.Name = "txtBudgetaryamount"
        Me.txtBudgetaryamount.Size = New System.Drawing.Size(208, 21)
        Me.txtBudgetaryamount.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(233, 185)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(97, 13)
        Me.Label6.TabIndex = 418
        Me.Label6.Text = "Budgetary Amount:"
        '
        'txtContractamount
        '
        Me.txtContractamount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContractamount.Location = New System.Drawing.Point(236, 151)
        Me.txtContractamount.Name = "txtContractamount"
        Me.txtContractamount.Size = New System.Drawing.Size(208, 21)
        Me.txtContractamount.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(233, 135)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(89, 13)
        Me.Label7.TabIndex = 417
        Me.Label7.Text = "Contract Amount:"
        '
        'txtProjectengineer
        '
        Me.txtProjectengineer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProjectengineer.Location = New System.Drawing.Point(236, 101)
        Me.txtProjectengineer.Name = "txtProjectengineer"
        Me.txtProjectengineer.Size = New System.Drawing.Size(208, 21)
        Me.txtProjectengineer.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(233, 85)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 13)
        Me.Label4.TabIndex = 414
        Me.Label4.Text = "Project Engineer:"
        '
        'txtProjectduration
        '
        Me.txtProjectduration.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProjectduration.Location = New System.Drawing.Point(236, 52)
        Me.txtProjectduration.Name = "txtProjectduration"
        Me.txtProjectduration.Size = New System.Drawing.Size(208, 21)
        Me.txtProjectduration.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(233, 36)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 13)
        Me.Label5.TabIndex = 413
        Me.Label5.Text = "Project Duration:"
        '
        'txtContractName
        '
        Me.txtContractName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContractName.Location = New System.Drawing.Point(9, 201)
        Me.txtContractName.Name = "txtContractName"
        Me.txtContractName.Size = New System.Drawing.Size(208, 21)
        Me.txtContractName.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 185)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 13)
        Me.Label2.TabIndex = 410
        Me.Label2.Text = "Contract Name:"
        '
        'txtContractId
        '
        Me.txtContractId.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContractId.Location = New System.Drawing.Point(9, 151)
        Me.txtContractId.Name = "txtContractId"
        Me.txtContractId.Size = New System.Drawing.Size(208, 21)
        Me.txtContractId.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 135)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 13)
        Me.Label3.TabIndex = 409
        Me.Label3.Text = "Contract ID:"
        '
        'DeteleToolStripMenuItem
        '
        Me.DeteleToolStripMenuItem.Name = "DeteleToolStripMenuItem"
        Me.DeteleToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.DeteleToolStripMenuItem.Text = "Delete"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'AddToolStripMenuItem
        '
        Me.AddToolStripMenuItem.Name = "AddToolStripMenuItem"
        Me.AddToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.AddToolStripMenuItem.Text = "Add"
        '
        'cms_projectdesc
        '
        Me.cms_projectdesc.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeteleToolStripMenuItem})
        Me.cms_projectdesc.Name = "cms_projectdesc"
        Me.cms_projectdesc.Size = New System.Drawing.Size(108, 70)
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Location"
        Me.ColumnHeader3.Width = 180
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Project Description"
        Me.ColumnHeader2.Width = 250
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Id"
        Me.ColumnHeader1.Width = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(12, 690)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 16)
        Me.Label1.TabIndex = 414
        Me.Label1.Text = "Search"
        '
        'lvl_projectDesc
        '
        Me.lvl_projectDesc.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11, Me.ColumnHeader12, Me.ColumnHeader13})
        Me.lvl_projectDesc.ContextMenuStrip = Me.cms_projectdesc
        Me.lvl_projectDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvl_projectDesc.FullRowSelect = True
        Me.lvl_projectDesc.GridLines = True
        Me.lvl_projectDesc.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvl_projectDesc.HideSelection = False
        Me.lvl_projectDesc.Location = New System.Drawing.Point(10, 46)
        Me.lvl_projectDesc.Name = "lvl_projectDesc"
        Me.lvl_projectDesc.Size = New System.Drawing.Size(1259, 629)
        Me.lvl_projectDesc.TabIndex = 411
        Me.lvl_projectDesc.UseCompatibleStateImageBehavior = False
        Me.lvl_projectDesc.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Contract ID"
        Me.ColumnHeader4.Width = 180
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Contract Name"
        Me.ColumnHeader5.Width = 180
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Project Duration"
        Me.ColumnHeader6.Width = 300
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Project Engineer"
        Me.ColumnHeader7.Width = 180
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Contract Amount"
        Me.ColumnHeader8.Width = 0
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Budgetary Amount"
        Me.ColumnHeader9.Width = 0
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Actual Amount"
        Me.ColumnHeader10.Width = 0
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.DisplayIndex = 11
        Me.ColumnHeader11.Text = "Date Close"
        Me.ColumnHeader11.Width = 200
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.DisplayIndex = 10
        Me.ColumnHeader12.Text = "Date Completion"
        Me.ColumnHeader12.Width = 200
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "Completion Type"
        Me.ColumnHeader13.Width = 150
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(16, 9)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(166, 22)
        Me.Label15.TabIndex = 408
        Me.Label15.Text = "Project Maintenance"
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.Transparent
        Me.btnExit.BackgroundImage = Global.SUPPLY.My.Resources.Resources.close_button
        Me.btnExit.FlatAppearance.BorderSize = 0
        Me.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit.Location = New System.Drawing.Point(1249, 11)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(20, 20)
        Me.btnExit.TabIndex = 410
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'pboxHeader
        '
        Me.pboxHeader.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.pboxHeader.BackgroundImage = CType(resources.GetObject("pboxHeader.BackgroundImage"), System.Drawing.Image)
        Me.pboxHeader.InitialImage = Nothing
        Me.pboxHeader.Location = New System.Drawing.Point(0, -1)
        Me.pboxHeader.Name = "pboxHeader"
        Me.pboxHeader.Size = New System.Drawing.Size(1283, 41)
        Me.pboxHeader.TabIndex = 409
        Me.pboxHeader.TabStop = False
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(951, 681)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 35)
        Me.Button1.TabIndex = 415
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(1188, 682)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(81, 35)
        Me.Button2.TabIndex = 416
        Me.Button2.Text = "Preview"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'cmbActiveEnactive
        '
        Me.cmbActiveEnactive.FormattingEnabled = True
        Me.cmbActiveEnactive.Location = New System.Drawing.Point(413, 8)
        Me.cmbActiveEnactive.Name = "cmbActiveEnactive"
        Me.cmbActiveEnactive.Size = New System.Drawing.Size(242, 21)
        Me.cmbActiveEnactive.TabIndex = 417
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.cmbActiveEnactive)
        Me.Panel1.Controls.Add(Me.txt_search)
        Me.Panel1.Location = New System.Drawing.Point(68, 681)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(832, 45)
        Me.Panel1.TabIndex = 418
        '
        'loadingPanel
        '
        Me.loadingPanel.BackColor = System.Drawing.Color.Transparent
        Me.loadingPanel.Controls.Add(Me.Label12)
        Me.loadingPanel.Controls.Add(Me.PictureBox1)
        Me.loadingPanel.Location = New System.Drawing.Point(238, -2)
        Me.loadingPanel.Name = "loadingPanel"
        Me.loadingPanel.Size = New System.Drawing.Size(271, 42)
        Me.loadingPanel.TabIndex = 419
        Me.loadingPanel.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(43, 11)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(204, 19)
        Me.Label12.TabIndex = 1
        Me.Label12.Text = "Fetching data, please wait..."
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.SUPPLY.My.Resources.Resources.spinner
        Me.PictureBox1.Location = New System.Drawing.Point(4, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(33, 33)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'debounce
        '
        Me.debounce.Interval = 500
        '
        'FProject_maintenance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SUPPLY.My.Resources.Resources.eus_bg_03
        Me.ClientSize = New System.Drawing.Size(1281, 729)
        Me.Controls.Add(Me.loadingPanel)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.pnl_projectdesc)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lvl_projectDesc)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.pboxHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FProject_maintenance"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FProject_maintenance"
        Me.pnl_projectdesc.ResumeLayout(False)
        Me.pnl_projectdesc.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.cms_projectdesc.ResumeLayout(False)
        CType(Me.pboxHeader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.loadingPanel.ResumeLayout(False)
        Me.loadingPanel.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txt_search As TextBox
    Friend WithEvents btn_close As Button
    Friend WithEvents btn_save As Button
    Friend WithEvents txtlocation As TextBox
    Friend WithEvents lbl_location As Label
    Friend WithEvents txtprojectdesc As TextBox
    Friend WithEvents lbl_projectdesc As Label
    Friend WithEvents pnl_projectdesc As Panel
    Friend WithEvents DeteleToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents cms_projectdesc As ContextMenuStrip
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents Label1 As Label
    Friend WithEvents lvl_projectDesc As ListView
    Friend WithEvents btnExit As Button
    Friend WithEvents Label15 As Label
    Friend WithEvents pboxHeader As PictureBox
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents ColumnHeader9 As ColumnHeader
    Friend WithEvents txtBudgetaryamount As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtContractamount As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtProjectengineer As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtProjectduration As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtContractName As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtContractId As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents ColumnHeader10 As ColumnHeader
    Friend WithEvents Button2 As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label9 As Label
    Friend WithEvents dtpDateTo As DateTimePicker
    Friend WithEvents Label8 As Label
    Friend WithEvents dtpDateFrom As DateTimePicker
    Friend WithEvents ColumnHeader11 As ColumnHeader
    Friend WithEvents Label10 As Label
    Friend WithEvents dtpDateCompletion As DateTimePicker
    Friend WithEvents ColumnHeader12 As ColumnHeader
    Friend WithEvents cmbDateClose As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents ColumnHeader13 As ColumnHeader
    Friend WithEvents cmbActiveEnactive As ComboBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents loadingPanel As Panel
    Friend WithEvents Label12 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents debounce As Timer
End Class
