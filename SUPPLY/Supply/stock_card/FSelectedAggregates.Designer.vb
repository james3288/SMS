<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FSelectedAggregates
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FSelectedAggregates))
        Me.lvlSelectedAggregates = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnView = New System.Windows.Forms.Button()
        Me.cmbWareHouse = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lvlStockPile = New System.Windows.Forms.ListView()
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SelectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CheckedAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UnchekedAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Timer3 = New System.Windows.Forms.Timer(Me.components)
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Timer4 = New System.Windows.Forms.Timer(Me.components)
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.tmr_checker = New System.Windows.Forms.Timer(Me.components)
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Timer5 = New System.Windows.Forms.Timer(Me.components)
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.pboxHeader = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblG1 = New System.Windows.Forms.Label()
        Me.lblTotal_finesand = New System.Windows.Forms.Label()
        Me.lblTotal_34 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Timer6 = New System.Windows.Forms.Timer(Me.components)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lblOversizeG1 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pboxHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvlSelectedAggregates
        '
        Me.lvlSelectedAggregates.CheckBoxes = True
        Me.lvlSelectedAggregates.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.lvlSelectedAggregates.FullRowSelect = True
        Me.lvlSelectedAggregates.Location = New System.Drawing.Point(1183, 12)
        Me.lvlSelectedAggregates.Name = "lvlSelectedAggregates"
        Me.lvlSelectedAggregates.Size = New System.Drawing.Size(306, 161)
        Me.lvlSelectedAggregates.TabIndex = 0
        Me.lvlSelectedAggregates.UseCompatibleStateImageBehavior = False
        Me.lvlSelectedAggregates.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "id"
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Items"
        Me.ColumnHeader2.Width = 150
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Source"
        Me.ColumnHeader3.Width = 266
        '
        'btnView
        '
        Me.btnView.Location = New System.Drawing.Point(1354, 191)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(133, 29)
        Me.btnView.TabIndex = 1
        Me.btnView.Text = "View"
        Me.btnView.UseVisualStyleBackColor = True
        '
        'cmbWareHouse
        '
        Me.cmbWareHouse.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbWareHouse.FormattingEnabled = True
        Me.cmbWareHouse.Location = New System.Drawing.Point(1183, 437)
        Me.cmbWareHouse.Name = "cmbWareHouse"
        Me.cmbWareHouse.Size = New System.Drawing.Size(304, 26)
        Me.cmbWareHouse.TabIndex = 4
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(149, 531)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(219, 29)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Start"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lvlStockPile
        '
        Me.lvlStockPile.CheckBoxes = True
        Me.lvlStockPile.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader5})
        Me.lvlStockPile.ContextMenuStrip = Me.ContextMenuStrip1
        Me.lvlStockPile.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvlStockPile.FullRowSelect = True
        Me.lvlStockPile.Location = New System.Drawing.Point(10, 50)
        Me.lvlStockPile.Name = "lvlStockPile"
        Me.lvlStockPile.Size = New System.Drawing.Size(358, 411)
        Me.lvlStockPile.TabIndex = 6
        Me.lvlStockPile.UseCompatibleStateImageBehavior = False
        Me.lvlStockPile.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Stockpile/Warehouse"
        Me.ColumnHeader5.Width = 349
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SelectAllToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(106, 26)
        '
        'SelectAllToolStripMenuItem
        '
        Me.SelectAllToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CheckedAllToolStripMenuItem, Me.UnchekedAllToolStripMenuItem})
        Me.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem"
        Me.SelectAllToolStripMenuItem.Size = New System.Drawing.Size(105, 22)
        Me.SelectAllToolStripMenuItem.Text = "Select"
        '
        'CheckedAllToolStripMenuItem
        '
        Me.CheckedAllToolStripMenuItem.Name = "CheckedAllToolStripMenuItem"
        Me.CheckedAllToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.CheckedAllToolStripMenuItem.Text = "Checked All"
        '
        'UnchekedAllToolStripMenuItem
        '
        Me.UnchekedAllToolStripMenuItem.Name = "UnchekedAllToolStripMenuItem"
        Me.UnchekedAllToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.UnchekedAllToolStripMenuItem.Text = "Uncheked All"
        '
        'dtpTo
        '
        Me.dtpTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpTo.Location = New System.Drawing.Point(149, 503)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(219, 22)
        Me.dtpTo.TabIndex = 10
        '
        'dtpFrom
        '
        Me.dtpFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFrom.Location = New System.Drawing.Point(149, 474)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(219, 22)
        Me.dtpFrom.TabIndex = 9
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(1354, 332)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(133, 41)
        Me.Button2.TabIndex = 11
        Me.Button2.Text = "teg kuha sa data sa database"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'ListView1
        '
        Me.ListView1.BackColor = System.Drawing.Color.LemonChiffon
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader4, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9})
        Me.ListView1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView1.FullRowSelect = True
        Me.ListView1.Location = New System.Drawing.Point(374, 50)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(787, 411)
        Me.ListView1.TabIndex = 12
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "3/4 GRAVEL"
        Me.ColumnHeader4.Width = 111
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "FINE SAND"
        Me.ColumnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader6.Width = 145
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "G-1"
        Me.ColumnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader7.Width = 177
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Stock Pile"
        Me.ColumnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader8.Width = 173
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(1183, 226)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(165, 147)
        Me.ListBox1.TabIndex = 13
        '
        'Timer2
        '
        Me.Timer2.Interval = 1000
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(1183, 411)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(304, 20)
        Me.TextBox1.TabIndex = 14
        '
        'Timer3
        '
        Me.Timer3.Interval = 1000
        '
        'ComboBox1
        '
        Me.ComboBox1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"3/4 GRAVEL", "Fine Sand", "G-1", "Oversize G-1"})
        Me.ComboBox1.Location = New System.Drawing.Point(1183, 379)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(304, 26)
        Me.ComboBox1.TabIndex = 15
        '
        'Timer4
        '
        Me.Timer4.Interval = 1000
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(1354, 261)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(133, 29)
        Me.Button3.TabIndex = 16
        Me.Button3.Text = "teg reset sa variable"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(1354, 296)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(133, 29)
        Me.Button4.TabIndex = 17
        Me.Button4.Text = "Teg Add sa listview"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'tmr_checker
        '
        Me.tmr_checker.Interval = 1000
        '
        'Panel3
        '
        Me.Panel3.BackgroundImage = Global.SUPPLY.My.Resources.Resources.bg_line
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.PictureBox1)
        Me.Panel3.Location = New System.Drawing.Point(334, 236)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(295, 152)
        Me.Panel3.TabIndex = 419
        Me.Panel3.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Green
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(238, 8)
        Me.Label7.Name = "Label7"
        Me.Label7.Padding = New System.Windows.Forms.Padding(3)
        Me.Label7.Size = New System.Drawing.Size(50, 19)
        Me.Label7.TabIndex = 418
        Me.Label7.Text = "ABORT"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(15, 121)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 16)
        Me.Label3.TabIndex = 417
        Me.Label3.Text = "Initializing..."
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(4, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(287, 141)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 416
        Me.PictureBox1.TabStop = False
        '
        'Timer5
        '
        Me.Timer5.Interval = 1000
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(1354, 226)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(133, 29)
        Me.Button5.TabIndex = 420
        Me.Button5.Text = "Teg set sa stockpile"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(68, 477)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 16)
        Me.Label1.TabIndex = 421
        Me.Label1.Text = "Date From:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(87, 506)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 16)
        Me.Label2.TabIndex = 422
        Me.Label2.Text = "Date To:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.BackColor = System.Drawing.Color.Transparent
        Me.btnExit.BackgroundImage = Global.SUPPLY.My.Resources.Resources.close_button
        Me.btnExit.FlatAppearance.BorderSize = 0
        Me.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit.Location = New System.Drawing.Point(1475, 9)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(20, 20)
        Me.btnExit.TabIndex = 424
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'pboxHeader
        '
        Me.pboxHeader.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.pboxHeader.BackgroundImage = CType(resources.GetObject("pboxHeader.BackgroundImage"), System.Drawing.Image)
        Me.pboxHeader.InitialImage = Nothing
        Me.pboxHeader.Location = New System.Drawing.Point(0, 0)
        Me.pboxHeader.Name = "pboxHeader"
        Me.pboxHeader.Size = New System.Drawing.Size(998, 44)
        Me.pboxHeader.TabIndex = 423
        Me.pboxHeader.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.lblOversizeG1)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.lblG1)
        Me.GroupBox1.Controls.Add(Me.lblTotal_finesand)
        Me.GroupBox1.Controls.Add(Me.lblTotal_34)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(377, 474)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(784, 85)
        Me.GroupBox1.TabIndex = 425
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Total"
        '
        'lblG1
        '
        Me.lblG1.AutoSize = True
        Me.lblG1.BackColor = System.Drawing.Color.Transparent
        Me.lblG1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblG1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblG1.Location = New System.Drawing.Point(470, 50)
        Me.lblG1.Name = "lblG1"
        Me.lblG1.Size = New System.Drawing.Size(15, 16)
        Me.lblG1.TabIndex = 431
        Me.lblG1.Text = "0"
        Me.lblG1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotal_finesand
        '
        Me.lblTotal_finesand.AutoSize = True
        Me.lblTotal_finesand.BackColor = System.Drawing.Color.Transparent
        Me.lblTotal_finesand.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal_finesand.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblTotal_finesand.Location = New System.Drawing.Point(249, 50)
        Me.lblTotal_finesand.Name = "lblTotal_finesand"
        Me.lblTotal_finesand.Size = New System.Drawing.Size(15, 16)
        Me.lblTotal_finesand.TabIndex = 430
        Me.lblTotal_finesand.Text = "0"
        Me.lblTotal_finesand.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotal_34
        '
        Me.lblTotal_34.AutoSize = True
        Me.lblTotal_34.BackColor = System.Drawing.Color.Transparent
        Me.lblTotal_34.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal_34.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblTotal_34.Location = New System.Drawing.Point(30, 50)
        Me.lblTotal_34.Name = "lblTotal_34"
        Me.lblTotal_34.Size = New System.Drawing.Size(15, 16)
        Me.lblTotal_34.TabIndex = 429
        Me.lblTotal_34.Text = "0"
        Me.lblTotal_34.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(457, 27)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(33, 16)
        Me.Label6.TabIndex = 428
        Me.Label6.Text = "G-1:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(236, 27)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 16)
        Me.Label5.TabIndex = 427
        Me.Label5.Text = "Fine Sand:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(17, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 16)
        Me.Label4.TabIndex = 426
        Me.Label4.Text = "3/4 Gravel:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Timer6
        '
        Me.Timer6.Interval = 1000
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Oversize G-1"
        Me.ColumnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader9.Width = 177
        '
        'lblOversizeG1
        '
        Me.lblOversizeG1.AutoSize = True
        Me.lblOversizeG1.BackColor = System.Drawing.Color.Transparent
        Me.lblOversizeG1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOversizeG1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblOversizeG1.Location = New System.Drawing.Point(670, 50)
        Me.lblOversizeG1.Name = "lblOversizeG1"
        Me.lblOversizeG1.Size = New System.Drawing.Size(15, 16)
        Me.lblOversizeG1.TabIndex = 433
        Me.lblOversizeG1.Text = "0"
        Me.lblOversizeG1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(657, 27)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 16)
        Me.Label9.TabIndex = 432
        Me.Label9.Text = "Oversize G-1"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FSelectedAggregates
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SUPPLY.My.Resources.Resources.eus_bg_03
        Me.ClientSize = New System.Drawing.Size(1505, 571)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.pboxHeader)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.dtpTo)
        Me.Controls.Add(Me.dtpFrom)
        Me.Controls.Add(Me.lvlStockPile)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cmbWareHouse)
        Me.Controls.Add(Me.btnView)
        Me.Controls.Add(Me.lvlSelectedAggregates)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FSelectedAggregates"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FSelectedAggregates"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pboxHeader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lvlSelectedAggregates As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents btnView As Button
    Friend WithEvents cmbWareHouse As ComboBox
    Friend WithEvents Button1 As Button
    Friend WithEvents lvlStockPile As ListView
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents SelectAllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CheckedAllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UnchekedAllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents dtpTo As DateTimePicker
    Friend WithEvents dtpFrom As DateTimePicker
    Friend WithEvents Button2 As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents ListView1 As ListView
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents Timer2 As Timer
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Timer3 As Timer
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Timer4 As Timer
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents tmr_checker As Timer
    Friend WithEvents Panel3 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents Timer5 As Timer
    Friend WithEvents Button5 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnExit As Button
    Friend WithEvents pboxHeader As PictureBox
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblG1 As Label
    Friend WithEvents lblTotal_finesand As Label
    Friend WithEvents lblTotal_34 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Timer6 As Timer
    Friend WithEvents ColumnHeader9 As ColumnHeader
    Friend WithEvents lblOversizeG1 As Label
    Friend WithEvents Label9 As Label
End Class
