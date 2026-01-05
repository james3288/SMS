<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FAggregates_General_Request2
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
        Me.lvlProject = New System.Windows.Forms.ListView()
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SelectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectAllToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.UnselectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnLoadProject = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.tig_next = New System.Windows.Forms.Timer(Me.components)
        Me.cmbItems = New System.Windows.Forms.ComboBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer3 = New System.Windows.Forms.Timer(Me.components)
        Me.tig_next2 = New System.Windows.Forms.Timer(Me.components)
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.ListView2 = New System.Windows.Forms.ListView()
        Me.ColumnHeader14 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader15 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader16 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader17 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader18 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader19 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader20 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader21 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader22 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cms_listview2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ExportRSToExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tig_next3 = New System.Windows.Forms.Timer(Me.components)
        Me.tig_next4 = New System.Windows.Forms.Timer(Me.components)
        Me.tig_check_sa_rs = New System.Windows.Forms.Timer(Me.components)
        Me.tig_calculate = New System.Windows.Forms.Timer(Me.components)
        Me.tig_total = New System.Windows.Forms.Timer(Me.components)
        Me.ContextMenuStrip1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.cms_listview2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvlProject
        '
        Me.lvlProject.CheckBoxes = True
        Me.lvlProject.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader5})
        Me.lvlProject.ContextMenuStrip = Me.ContextMenuStrip1
        Me.lvlProject.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvlProject.FullRowSelect = True
        Me.lvlProject.Location = New System.Drawing.Point(8, 9)
        Me.lvlProject.Name = "lvlProject"
        Me.lvlProject.Size = New System.Drawing.Size(303, 386)
        Me.lvlProject.TabIndex = 8
        Me.lvlProject.UseCompatibleStateImageBehavior = False
        Me.lvlProject.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Projects"
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
        Me.SelectAllToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SelectAllToolStripMenuItem1, Me.UnselectAllToolStripMenuItem})
        Me.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem"
        Me.SelectAllToolStripMenuItem.Size = New System.Drawing.Size(105, 22)
        Me.SelectAllToolStripMenuItem.Text = "Select"
        '
        'SelectAllToolStripMenuItem1
        '
        Me.SelectAllToolStripMenuItem1.Name = "SelectAllToolStripMenuItem1"
        Me.SelectAllToolStripMenuItem1.Size = New System.Drawing.Size(136, 22)
        Me.SelectAllToolStripMenuItem1.Text = "Select All"
        '
        'UnselectAllToolStripMenuItem
        '
        Me.UnselectAllToolStripMenuItem.Name = "UnselectAllToolStripMenuItem"
        Me.UnselectAllToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.UnselectAllToolStripMenuItem.Text = "Unselect All"
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader10, Me.ColumnHeader11, Me.ColumnHeader12, Me.ColumnHeader13})
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ListView1.FullRowSelect = True
        Me.ListView1.Location = New System.Drawing.Point(0, 0)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(1179, 334)
        Me.ListView1.TabIndex = 19
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "rs_id"
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "PROJECT"
        Me.ColumnHeader7.Width = 147
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "ITEMS"
        Me.ColumnHeader8.Width = 300
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "RS QTY"
        Me.ColumnHeader9.Width = 110
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "RS NO"
        Me.ColumnHeader1.Width = 96
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "MAIN"
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "STATUS"
        Me.ColumnHeader3.Width = 94
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "QTY WITHDRAWN"
        Me.ColumnHeader4.Width = 136
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "RELEASED"
        Me.ColumnHeader10.Width = 129
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "BALANCE"
        Me.ColumnHeader11.Width = 133
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "Date Request"
        Me.ColumnHeader12.Width = 100
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "Item Desc."
        '
        'btnLoadProject
        '
        Me.btnLoadProject.Location = New System.Drawing.Point(8, 437)
        Me.btnLoadProject.Name = "btnLoadProject"
        Me.btnLoadProject.Size = New System.Drawing.Size(304, 32)
        Me.btnLoadProject.TabIndex = 20
        Me.btnLoadProject.Text = "1. GENERATE PROJECT RS"
        Me.btnLoadProject.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        '
        'tig_next
        '
        Me.tig_next.Interval = 1000
        '
        'cmbItems
        '
        Me.cmbItems.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbItems.FormattingEnabled = True
        Me.cmbItems.Items.AddRange(New Object() {"Oversize G-1", "3/4 GRAVEL", "Fine Sand", "G-1", "3/8 GRAVEL", "Screen Sand"})
        Me.cmbItems.Location = New System.Drawing.Point(135, 185)
        Me.cmbItems.Name = "cmbItems"
        Me.cmbItems.Size = New System.Drawing.Size(152, 26)
        Me.cmbItems.TabIndex = 22
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Location = New System.Drawing.Point(42, 141)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(209, 84)
        Me.Panel2.TabIndex = 431
        Me.Panel2.Visible = False
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
        'Timer2
        '
        '
        'Timer3
        '
        '
        'tig_next2
        '
        Me.tig_next2.Interval = 1000
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(69, 159)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(218, 20)
        Me.TextBox1.TabIndex = 434
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(155, 121)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(132, 32)
        Me.Button2.TabIndex = 435
        Me.Button2.Text = "Load"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Button9)
        Me.Panel3.Controls.Add(Me.TextBox2)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.Button3)
        Me.Panel3.Controls.Add(Me.Panel2)
        Me.Panel3.Controls.Add(Me.lvlProject)
        Me.Panel3.Controls.Add(Me.btnLoadProject)
        Me.Panel3.Controls.Add(Me.Panel5)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(322, 837)
        Me.Panel3.TabIndex = 436
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(82, 402)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(75, 23)
        Me.Button9.TabIndex = 21
        Me.Button9.Text = "try"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(163, 404)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(148, 20)
        Me.TextBox2.TabIndex = 446
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 411)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 443
        Me.Label1.Text = "Label1"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(8, 475)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(303, 32)
        Me.Button3.TabIndex = 437
        Me.Button3.Text = "2. CALCULATE"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Button8)
        Me.Panel5.Controls.Add(Me.Button5)
        Me.Panel5.Controls.Add(Me.cmbItems)
        Me.Panel5.Controls.Add(Me.Button7)
        Me.Panel5.Controls.Add(Me.TextBox1)
        Me.Panel5.Controls.Add(Me.Button6)
        Me.Panel5.Controls.Add(Me.Button2)
        Me.Panel5.Controls.Add(Me.Button1)
        Me.Panel5.Controls.Add(Me.ComboBox1)
        Me.Panel5.Controls.Add(Me.Button4)
        Me.Panel5.Location = New System.Drawing.Point(8, 513)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(303, 312)
        Me.Panel5.TabIndex = 445
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(135, 255)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(152, 32)
        Me.Button8.TabIndex = 444
        Me.Button8.Text = "Load to rs to listview2"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(135, 217)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(152, 32)
        Me.Button5.TabIndex = 440
        Me.Button5.Text = "Load"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(155, 16)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(132, 23)
        Me.Button7.TabIndex = 442
        Me.Button7.Text = "load to rs form"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(7, 121)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(142, 23)
        Me.Button6.TabIndex = 441
        Me.Button6.Text = "Remove og walay labot"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(155, 45)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(132, 32)
        Me.Button1.TabIndex = 436
        Me.Button1.Text = "Load Main RS 2"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"G1", "Sand", "Oversized", "G-1"})
        Me.ComboBox1.Location = New System.Drawing.Point(7, 185)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(123, 26)
        Me.ComboBox1.TabIndex = 439
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(155, 83)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(132, 32)
        Me.Button4.TabIndex = 438
        Me.Button4.Text = "Load 4"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.ListView2)
        Me.Panel4.Controls.Add(Me.ListView1)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(322, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1179, 837)
        Me.Panel4.TabIndex = 437
        '
        'ListView2
        '
        Me.ListView2.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader14, Me.ColumnHeader15, Me.ColumnHeader16, Me.ColumnHeader17, Me.ColumnHeader18, Me.ColumnHeader19, Me.ColumnHeader20, Me.ColumnHeader21, Me.ColumnHeader22})
        Me.ListView2.ContextMenuStrip = Me.cms_listview2
        Me.ListView2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView2.FullRowSelect = True
        Me.ListView2.HideSelection = False
        Me.ListView2.Location = New System.Drawing.Point(0, 334)
        Me.ListView2.Name = "ListView2"
        Me.ListView2.Size = New System.Drawing.Size(1179, 503)
        Me.ListView2.TabIndex = 20
        Me.ListView2.UseCompatibleStateImageBehavior = False
        Me.ListView2.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.Text = "RS_NO"
        Me.ColumnHeader14.Width = 200
        '
        'ColumnHeader15
        '
        Me.ColumnHeader15.Text = "FINE SAND"
        Me.ColumnHeader15.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader15.Width = 0
        '
        'ColumnHeader16
        '
        Me.ColumnHeader16.Text = "G-1"
        Me.ColumnHeader16.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader16.Width = 0
        '
        'ColumnHeader17
        '
        Me.ColumnHeader17.Text = "3/4 GRAVEL"
        Me.ColumnHeader17.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader17.Width = 0
        '
        'ColumnHeader18
        '
        Me.ColumnHeader18.Text = "3/8 GRAVEL"
        Me.ColumnHeader18.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader18.Width = 0
        '
        'ColumnHeader19
        '
        Me.ColumnHeader19.Text = "SCREEN SAND"
        Me.ColumnHeader19.Width = 0
        '
        'ColumnHeader20
        '
        Me.ColumnHeader20.Text = "PROJECT"
        Me.ColumnHeader20.Width = 200
        '
        'ColumnHeader21
        '
        Me.ColumnHeader21.Text = "Items"
        Me.ColumnHeader21.Width = 200
        '
        'ColumnHeader22
        '
        Me.ColumnHeader22.Text = "Balance"
        Me.ColumnHeader22.Width = 200
        '
        'cms_listview2
        '
        Me.cms_listview2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExportRSToExcelToolStripMenuItem})
        Me.cms_listview2.Name = "cms_listview2"
        Me.cms_listview2.Size = New System.Drawing.Size(169, 26)
        '
        'ExportRSToExcelToolStripMenuItem
        '
        Me.ExportRSToExcelToolStripMenuItem.Name = "ExportRSToExcelToolStripMenuItem"
        Me.ExportRSToExcelToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.ExportRSToExcelToolStripMenuItem.Text = "Export RS to excel"
        '
        'tig_next3
        '
        Me.tig_next3.Interval = 1000
        '
        'tig_next4
        '
        Me.tig_next4.Interval = 1000
        '
        'tig_check_sa_rs
        '
        Me.tig_check_sa_rs.Interval = 1000
        '
        'tig_calculate
        '
        Me.tig_calculate.Interval = 2000
        '
        'tig_total
        '
        Me.tig_total.Interval = 2000
        '
        'FAggregates_General_Request2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1501, 837)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Name = "FAggregates_General_Request2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FAggregates_General_Request2"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.cms_listview2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lvlProject As ListView
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ListView1 As ListView
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents ColumnHeader9 As ColumnHeader
    Friend WithEvents btnLoadProject As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents tig_next As Timer
    Friend WithEvents cmbItems As ComboBox
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Timer2 As Timer
    Friend WithEvents Timer3 As Timer
    Friend WithEvents tig_next2 As Timer
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader10 As ColumnHeader
    Friend WithEvents ColumnHeader11 As ColumnHeader
    Friend WithEvents ColumnHeader12 As ColumnHeader
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents tig_next3 As Timer
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents ColumnHeader13 As ColumnHeader
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents tig_next4 As Timer
    Friend WithEvents Label1 As Label
    Friend WithEvents tig_check_sa_rs As Timer
    Friend WithEvents ListView2 As ListView
    Friend WithEvents ColumnHeader14 As ColumnHeader
    Friend WithEvents ColumnHeader15 As ColumnHeader
    Friend WithEvents ColumnHeader16 As ColumnHeader
    Friend WithEvents ColumnHeader17 As ColumnHeader
    Friend WithEvents ColumnHeader18 As ColumnHeader
    Friend WithEvents ColumnHeader19 As ColumnHeader
    Friend WithEvents ColumnHeader20 As ColumnHeader
    Friend WithEvents Button8 As Button
    Friend WithEvents tig_calculate As Timer
    Friend WithEvents cms_listview2 As ContextMenuStrip
    Friend WithEvents ExportRSToExcelToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Panel5 As Panel
    Friend WithEvents tig_total As Timer
    Friend WithEvents Button9 As Button
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents SelectAllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SelectAllToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents UnselectAllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ColumnHeader21 As ColumnHeader
    Friend WithEvents ColumnHeader22 As ColumnHeader
End Class
