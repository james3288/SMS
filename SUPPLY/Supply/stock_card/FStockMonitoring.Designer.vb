<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FStockMonitoring
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FStockMonitoring))
        Me.lvlStockPile = New System.Windows.Forms.ListView()
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SelectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CheckedAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UnchekedAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmbItems = New System.Windows.Forms.ComboBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.tig_next = New System.Windows.Forms.Timer(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.ListView2 = New System.Windows.Forms.ListView()
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.pboxHeader = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblTotalMixedBould200300Found = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblTotalMixed = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblTotalMixedAgg = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lbl38Gravel = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblOversizeG1 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblG1 = New System.Windows.Forms.Label()
        Me.lblTotal_finesand = New System.Windows.Forms.Label()
        Me.lblTotal_34 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.ListView3 = New System.Windows.Forms.ListView()
        Me.col_wh_id = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_items = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_problem = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_qty = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ListView4 = New System.Windows.Forms.ListView()
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader14 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pboxHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvlStockPile
        '
        Me.lvlStockPile.CheckBoxes = True
        Me.lvlStockPile.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader5})
        Me.lvlStockPile.ContextMenuStrip = Me.ContextMenuStrip1
        Me.lvlStockPile.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvlStockPile.FullRowSelect = True
        Me.lvlStockPile.Location = New System.Drawing.Point(12, 56)
        Me.lvlStockPile.Name = "lvlStockPile"
        Me.lvlStockPile.Size = New System.Drawing.Size(358, 411)
        Me.lvlStockPile.TabIndex = 7
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
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(268, 567)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(102, 30)
        Me.Button1.TabIndex = 15
        Me.Button1.Text = "Start"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmbItems
        '
        Me.cmbItems.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbItems.FormattingEnabled = True
        Me.cmbItems.Items.AddRange(New Object() {"Oversize G-1", "3/4 GRAVEL", "Fine Sand", "G-1", "3/8 GRAVEL", "Mixed Aggregates", "Mixed", "Mixed/Boulders/200/300/foundation fill", "ITEM 104"})
        Me.cmbItems.Location = New System.Drawing.Point(1215, 129)
        Me.cmbItems.Name = "cmbItems"
        Me.cmbItems.Size = New System.Drawing.Size(152, 26)
        Me.cmbItems.TabIndex = 16
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(1215, 161)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(96, 23)
        Me.Button2.TabIndex = 17
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader11})
        Me.ListView1.FullRowSelect = True
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(376, 56)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(787, 234)
        Me.ListView1.TabIndex = 18
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "wh_id"
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "items"
        Me.ColumnHeader2.Width = 200
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "wharea"
        Me.ColumnHeader3.Width = 200
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.DisplayIndex = 4
        Me.ColumnHeader4.Text = "Balance"
        Me.ColumnHeader4.Width = 107
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.DisplayIndex = 3
        Me.ColumnHeader11.Text = "Source"
        Me.ColumnHeader11.Width = 221
        '
        'Timer1
        '
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = Global.SUPPLY.My.Resources.Resources.PVtR
        Me.PictureBox1.Location = New System.Drawing.Point(113, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(72, 50)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 19
        Me.PictureBox1.TabStop = False
        '
        'tig_next
        '
        Me.tig_next.Interval = 1000
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(89, 505)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 16)
        Me.Label2.TabIndex = 426
        Me.Label2.Text = "Date To:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(70, 476)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 16)
        Me.Label1.TabIndex = 425
        Me.Label1.Text = "Date From:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpTo
        '
        Me.dtpTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpTo.Location = New System.Drawing.Point(151, 502)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(219, 22)
        Me.dtpTo.TabIndex = 424
        '
        'dtpFrom
        '
        Me.dtpFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFrom.Location = New System.Drawing.Point(151, 473)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(219, 22)
        Me.dtpFrom.TabIndex = 423
        '
        'ListView2
        '
        Me.ListView2.BackColor = System.Drawing.Color.LemonChiffon
        Me.ListView2.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader12})
        Me.ListView2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView2.FullRowSelect = True
        Me.ListView2.Location = New System.Drawing.Point(1215, 195)
        Me.ListView2.Name = "ListView2"
        Me.ListView2.Size = New System.Drawing.Size(235, 171)
        Me.ListView2.TabIndex = 427
        Me.ListView2.UseCompatibleStateImageBehavior = False
        Me.ListView2.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "3/4 GRAVEL"
        Me.ColumnHeader6.Width = 99
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "FINE SAND"
        Me.ColumnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader7.Width = 122
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "G-1"
        Me.ColumnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader8.Width = 116
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.DisplayIndex = 5
        Me.ColumnHeader9.Text = "Stock Pile"
        Me.ColumnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader9.Width = 149
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.DisplayIndex = 3
        Me.ColumnHeader10.Text = "Oversize G-1"
        Me.ColumnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader10.Width = 162
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.DisplayIndex = 4
        Me.ColumnHeader12.Text = "3/8 GRAVEL"
        Me.ColumnHeader12.Width = 122
        '
        'pboxHeader
        '
        Me.pboxHeader.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.pboxHeader.BackgroundImage = CType(resources.GetObject("pboxHeader.BackgroundImage"), System.Drawing.Image)
        Me.pboxHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pboxHeader.InitialImage = Nothing
        Me.pboxHeader.Location = New System.Drawing.Point(0, 0)
        Me.pboxHeader.Name = "pboxHeader"
        Me.pboxHeader.Size = New System.Drawing.Size(1175, 44)
        Me.pboxHeader.TabIndex = 428
        Me.pboxHeader.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Location = New System.Drawing.Point(6, 6)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(196, 71)
        Me.Panel1.TabIndex = 429
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(4, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 37)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Loading..."
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Location = New System.Drawing.Point(659, 189)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(209, 84)
        Me.Panel2.TabIndex = 430
        Me.Panel2.Visible = False
        '
        'Button3
        '
        Me.Button3.Enabled = False
        Me.Button3.Location = New System.Drawing.Point(1002, 681)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(161, 30)
        Me.Button3.TabIndex = 431
        Me.Button3.Text = "Calculate"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.lblTotalMixedBould200300Found)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.lblTotalMixed)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.lblTotalMixedAgg)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.lbl38Gravel)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.lblOversizeG1)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.lblG1)
        Me.GroupBox1.Controls.Add(Me.lblTotal_finesand)
        Me.GroupBox1.Controls.Add(Me.lblTotal_34)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(1215, 380)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(784, 144)
        Me.GroupBox1.TabIndex = 432
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Total"
        '
        'lblTotalMixedBould200300Found
        '
        Me.lblTotalMixedBould200300Found.AutoSize = True
        Me.lblTotalMixedBould200300Found.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalMixedBould200300Found.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalMixedBould200300Found.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblTotalMixedBould200300Found.Location = New System.Drawing.Point(272, 107)
        Me.lblTotalMixedBould200300Found.Name = "lblTotalMixedBould200300Found"
        Me.lblTotalMixedBould200300Found.Size = New System.Drawing.Size(15, 16)
        Me.lblTotalMixedBould200300Found.TabIndex = 441
        Me.lblTotalMixedBould200300Found.Text = "0"
        Me.lblTotalMixedBould200300Found.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(262, 84)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(249, 16)
        Me.Label13.TabIndex = 440
        Me.Label13.Text = "Mixed/Boulders/200/300/foundation fill"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalMixed
        '
        Me.lblTotalMixed.AutoSize = True
        Me.lblTotalMixed.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalMixed.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalMixed.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblTotalMixed.Location = New System.Drawing.Point(181, 107)
        Me.lblTotalMixed.Name = "lblTotalMixed"
        Me.lblTotalMixed.Size = New System.Drawing.Size(15, 16)
        Me.lblTotalMixed.TabIndex = 439
        Me.lblTotalMixed.Text = "0"
        Me.lblTotalMixed.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(171, 84)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(47, 16)
        Me.Label12.TabIndex = 438
        Me.Label12.Text = "Mixed"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalMixedAgg
        '
        Me.lblTotalMixedAgg.AutoSize = True
        Me.lblTotalMixedAgg.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalMixedAgg.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalMixedAgg.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblTotalMixedAgg.Location = New System.Drawing.Point(36, 107)
        Me.lblTotalMixedAgg.Name = "lblTotalMixedAgg"
        Me.lblTotalMixedAgg.Size = New System.Drawing.Size(15, 16)
        Me.lblTotalMixedAgg.TabIndex = 437
        Me.lblTotalMixedAgg.Text = "0"
        Me.lblTotalMixedAgg.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(26, 84)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(123, 16)
        Me.Label11.TabIndex = 436
        Me.Label11.Text = "Mixed Aggregates"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl38Gravel
        '
        Me.lbl38Gravel.AutoSize = True
        Me.lbl38Gravel.BackColor = System.Drawing.Color.Transparent
        Me.lbl38Gravel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl38Gravel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbl38Gravel.Location = New System.Drawing.Point(568, 54)
        Me.lbl38Gravel.Name = "lbl38Gravel"
        Me.lbl38Gravel.Size = New System.Drawing.Size(15, 16)
        Me.lbl38Gravel.TabIndex = 435
        Me.lbl38Gravel.Text = "0"
        Me.lbl38Gravel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(558, 31)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 16)
        Me.Label8.TabIndex = 434
        Me.Label8.Text = "3/8 Gravel"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblOversizeG1
        '
        Me.lblOversizeG1.AutoSize = True
        Me.lblOversizeG1.BackColor = System.Drawing.Color.Transparent
        Me.lblOversizeG1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOversizeG1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblOversizeG1.Location = New System.Drawing.Point(398, 54)
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
        Me.Label9.Location = New System.Drawing.Point(390, 31)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 16)
        Me.Label9.TabIndex = 432
        Me.Label9.Text = "Oversize G-1"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblG1
        '
        Me.lblG1.AutoSize = True
        Me.lblG1.BackColor = System.Drawing.Color.Transparent
        Me.lblG1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblG1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblG1.Location = New System.Drawing.Point(279, 54)
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
        Me.lblTotal_finesand.Location = New System.Drawing.Point(138, 54)
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
        Me.lblTotal_34.Location = New System.Drawing.Point(36, 54)
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
        Me.Label6.Location = New System.Drawing.Point(276, 31)
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
        Me.Label5.Location = New System.Drawing.Point(130, 31)
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
        Me.Label4.Location = New System.Drawing.Point(26, 31)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 16)
        Me.Label4.TabIndex = 426
        Me.Label4.Text = "3/4 Gravel:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(835, 681)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(161, 30)
        Me.Button4.TabIndex = 433
        Me.Button4.Text = "Abort"
        Me.Button4.UseVisualStyleBackColor = True
        Me.Button4.Visible = False
        '
        'btnClear
        '
        Me.btnClear.Enabled = False
        Me.btnClear.Location = New System.Drawing.Point(160, 567)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(102, 30)
        Me.btnClear.TabIndex = 434
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'ListView3
        '
        Me.ListView3.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.col_wh_id, Me.col_items, Me.col_problem, Me.col_qty})
        Me.ListView3.FullRowSelect = True
        Me.ListView3.HideSelection = False
        Me.ListView3.Location = New System.Drawing.Point(376, 329)
        Me.ListView3.Name = "ListView3"
        Me.ListView3.Size = New System.Drawing.Size(787, 138)
        Me.ListView3.TabIndex = 437
        Me.ListView3.UseCompatibleStateImageBehavior = False
        Me.ListView3.View = System.Windows.Forms.View.Details
        '
        'col_wh_id
        '
        Me.col_wh_id.Text = "wh_id"
        '
        'col_items
        '
        Me.col_items.Text = "Items"
        Me.col_items.Width = 230
        '
        'col_problem
        '
        Me.col_problem.DisplayIndex = 3
        Me.col_problem.Text = "Problem"
        Me.col_problem.Width = 375
        '
        'col_qty
        '
        Me.col_qty.DisplayIndex = 2
        Me.col_qty.Text = "qty"
        Me.col_qty.Width = 105
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(379, 313)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(288, 13)
        Me.Label7.TabIndex = 438
        Me.Label7.Text = "Items that not include in total cause of spelling and spacing:"
        '
        'ListView4
        '
        Me.ListView4.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader13, Me.ColumnHeader14})
        Me.ListView4.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ListView4.FullRowSelect = True
        Me.ListView4.HideSelection = False
        Me.ListView4.Location = New System.Drawing.Point(376, 502)
        Me.ListView4.Name = "ListView4"
        Me.ListView4.Size = New System.Drawing.Size(787, 173)
        Me.ListView4.TabIndex = 439
        Me.ListView4.UseCompatibleStateImageBehavior = False
        Me.ListView4.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "Item Name"
        Me.ColumnHeader13.Width = 400
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.Text = "Total"
        Me.ColumnHeader14.Width = 230
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial Black", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(378, 479)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(50, 20)
        Me.Label10.TabIndex = 440
        Me.Label10.Text = "Total:"
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(268, 531)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(102, 30)
        Me.Button5.TabIndex = 441
        Me.Button5.Text = "Select Aggregates"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'FStockMonitoring
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SUPPLY.My.Resources.Resources.line_div
        Me.ClientSize = New System.Drawing.Size(1175, 733)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.ListView4)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.ListView3)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pboxHeader)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpTo)
        Me.Controls.Add(Me.dtpFrom)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.cmbItems)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lvlStockPile)
        Me.Controls.Add(Me.ListView2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FStockMonitoring"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FStockMonitoring"
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pboxHeader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lvlStockPile As ListView
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents Button1 As Button
    Friend WithEvents cmbItems As ComboBox
    Friend WithEvents Button2 As Button
    Friend WithEvents ListView1 As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents Timer1 As Timer
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents tig_next As Timer
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dtpTo As DateTimePicker
    Friend WithEvents dtpFrom As DateTimePicker
    Friend WithEvents ListView2 As ListView
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents ColumnHeader9 As ColumnHeader
    Friend WithEvents ColumnHeader10 As ColumnHeader
    Friend WithEvents pboxHeader As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Button3 As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblOversizeG1 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents lblG1 As Label
    Friend WithEvents lblTotal_finesand As Label
    Friend WithEvents lblTotal_34 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents ColumnHeader11 As ColumnHeader
    Friend WithEvents ColumnHeader12 As ColumnHeader
    Friend WithEvents lbl38Gravel As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Button4 As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents SelectAllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CheckedAllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UnchekedAllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ListView3 As ListView
    Friend WithEvents col_wh_id As ColumnHeader
    Friend WithEvents col_items As ColumnHeader
    Friend WithEvents Label7 As Label
    Friend WithEvents col_problem As ColumnHeader
    Friend WithEvents col_qty As ColumnHeader
    Friend WithEvents lblTotalMixedAgg As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents lblTotalMixed As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents lblTotalMixedBould200300Found As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents ListView4 As ListView
    Friend WithEvents ColumnHeader13 As ColumnHeader
    Friend WithEvents ColumnHeader14 As ColumnHeader
    Friend WithEvents Label10 As Label
    Friend WithEvents Button5 As Button
End Class
