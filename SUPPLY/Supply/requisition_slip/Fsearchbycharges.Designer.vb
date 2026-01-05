<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Fsearchbycharges
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Fsearchbycharges))
        Me.lvlSearchCharges = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_RRPrice = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_TypeOfPurchasing = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SelectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UnselectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowRRPriceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmbProject = New System.Windows.Forms.ComboBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.dtpdatefrom = New System.Windows.Forms.DateTimePicker()
        Me.dtpdateto = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbGenerateProject = New System.Windows.Forms.ComboBox()
        Me.txtChargesSearch = New System.Windows.Forms.TextBox()
        Me.txtItemSearch = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.btnEndProcess = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Timer3 = New System.Windows.Forms.Timer(Me.components)
        Me.cmbProject1 = New System.Windows.Forms.ComboBox()
        Me.timer_thread = New System.Windows.Forms.Timer(Me.components)
        Me.timer_thread1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbByDate = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.timer_thread2 = New System.Windows.Forms.Timer(Me.components)
        Me.timer_thread3 = New System.Windows.Forms.Timer(Me.components)
        Me.timer_thread4 = New System.Windows.Forms.Timer(Me.components)
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorker2 = New System.ComponentModel.BackgroundWorker()
        Me.BW_rrPrice = New System.ComponentModel.BackgroundWorker()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvlSearchCharges
        '
        Me.lvlSearchCharges.CheckBoxes = True
        Me.lvlSearchCharges.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.col_RRPrice, Me.col_TypeOfPurchasing})
        Me.lvlSearchCharges.ContextMenuStrip = Me.ContextMenuStrip1
        Me.lvlSearchCharges.FullRowSelect = True
        Me.lvlSearchCharges.HideSelection = False
        Me.lvlSearchCharges.Location = New System.Drawing.Point(12, 48)
        Me.lvlSearchCharges.Name = "lvlSearchCharges"
        Me.lvlSearchCharges.Size = New System.Drawing.Size(671, 460)
        Me.lvlSearchCharges.TabIndex = 0
        Me.lvlSearchCharges.UseCompatibleStateImageBehavior = False
        Me.lvlSearchCharges.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "RS_NO"
        Me.ColumnHeader1.Width = 144
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Item Desc. From Item Check"
        Me.ColumnHeader2.Width = 226
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.DisplayIndex = 4
        Me.ColumnHeader3.Text = "RS Date"
        Me.ColumnHeader3.Width = 146
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.DisplayIndex = 5
        Me.ColumnHeader4.Text = "wh_id"
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.DisplayIndex = 6
        Me.ColumnHeader5.Text = "rs_id"
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.DisplayIndex = 7
        Me.ColumnHeader6.Text = "PROJECT"
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.DisplayIndex = 2
        Me.ColumnHeader7.Text = "Item Desc. From RS"
        Me.ColumnHeader7.Width = 150
        '
        'col_RRPrice
        '
        Me.col_RRPrice.DisplayIndex = 3
        Me.col_RRPrice.Text = "Price/Amount"
        Me.col_RRPrice.Width = 200
        '
        'col_TypeOfPurchasing
        '
        Me.col_TypeOfPurchasing.Text = "Type Of Purchasing"
        Me.col_TypeOfPurchasing.Width = 200
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SelectAllToolStripMenuItem, Me.UnselectAllToolStripMenuItem, Me.ShowRRPriceToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(150, 70)
        '
        'SelectAllToolStripMenuItem
        '
        Me.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem"
        Me.SelectAllToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.SelectAllToolStripMenuItem.Text = "Select All"
        '
        'UnselectAllToolStripMenuItem
        '
        Me.UnselectAllToolStripMenuItem.Name = "UnselectAllToolStripMenuItem"
        Me.UnselectAllToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.UnselectAllToolStripMenuItem.Text = "Unselect All"
        '
        'ShowRRPriceToolStripMenuItem
        '
        Me.ShowRRPriceToolStripMenuItem.Name = "ShowRRPriceToolStripMenuItem"
        Me.ShowRRPriceToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.ShowRRPriceToolStripMenuItem.Text = "Show RR Price"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.OliveDrab
        Me.Button1.Enabled = False
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(378, 46)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(114, 30)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Load"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'cmbProject
        '
        Me.cmbProject.Enabled = False
        Me.cmbProject.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbProject.FormattingEnabled = True
        Me.cmbProject.Location = New System.Drawing.Point(108, 13)
        Me.cmbProject.Name = "cmbProject"
        Me.cmbProject.Size = New System.Drawing.Size(264, 24)
        Me.cmbProject.TabIndex = 2
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.OliveDrab
        Me.Button2.Enabled = False
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(378, 14)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(114, 27)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "Search"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.OliveDrab
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Location = New System.Drawing.Point(378, 82)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(114, 27)
        Me.Button3.TabIndex = 9
        Me.Button3.Text = "Load DR"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'dtpdatefrom
        '
        Me.dtpdatefrom.Enabled = False
        Me.dtpdatefrom.Location = New System.Drawing.Point(108, 139)
        Me.dtpdatefrom.Name = "dtpdatefrom"
        Me.dtpdatefrom.Size = New System.Drawing.Size(264, 20)
        Me.dtpdatefrom.TabIndex = 5
        '
        'dtpdateto
        '
        Me.dtpdateto.Enabled = False
        Me.dtpdateto.Location = New System.Drawing.Point(108, 167)
        Me.dtpdateto.Name = "dtpdateto"
        Me.dtpdateto.Size = New System.Drawing.Size(264, 20)
        Me.dtpdateto.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(12, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Loading...."
        Me.Label1.Visible = False
        '
        'cmbGenerateProject
        '
        Me.cmbGenerateProject.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbGenerateProject.FormattingEnabled = True
        Me.cmbGenerateProject.Items.AddRange(New Object() {"Generate by All Project", "Generate by Specific project", "Generate by RS No.", "Generate by DR No.", "Generate by WS No."})
        Me.cmbGenerateProject.Location = New System.Drawing.Point(458, 12)
        Me.cmbGenerateProject.Name = "cmbGenerateProject"
        Me.cmbGenerateProject.Size = New System.Drawing.Size(224, 24)
        Me.cmbGenerateProject.TabIndex = 8
        '
        'txtChargesSearch
        '
        Me.txtChargesSearch.Enabled = False
        Me.txtChargesSearch.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChargesSearch.ForeColor = System.Drawing.Color.Gray
        Me.txtChargesSearch.Location = New System.Drawing.Point(864, 431)
        Me.txtChargesSearch.Name = "txtChargesSearch"
        Me.txtChargesSearch.Size = New System.Drawing.Size(264, 25)
        Me.txtChargesSearch.TabIndex = 13
        '
        'txtItemSearch
        '
        Me.txtItemSearch.Enabled = False
        Me.txtItemSearch.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemSearch.ForeColor = System.Drawing.Color.Gray
        Me.txtItemSearch.Location = New System.Drawing.Point(108, 74)
        Me.txtItemSearch.Name = "txtItemSearch"
        Me.txtItemSearch.Size = New System.Drawing.Size(264, 25)
        Me.txtItemSearch.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(9, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Requestor/Project:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(17, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 13)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Type of Charges:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(68, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Items:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(46, 142)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 13)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Date From:"
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.OliveDrab
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.ForeColor = System.Drawing.Color.White
        Me.Button4.Location = New System.Drawing.Point(378, 115)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(114, 44)
        Me.Button4.TabIndex = 10
        Me.Button4.Text = "EXPORT DR"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.BackgroundImage = Global.SUPPLY.My.Resources.Resources.line_div
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.ProgressBar1)
        Me.Panel3.Controls.Add(Me.btnEndProcess)
        Me.Panel3.Controls.Add(Me.PictureBox1)
        Me.Panel3.Location = New System.Drawing.Point(178, 201)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(304, 160)
        Me.Panel3.TabIndex = 418
        Me.Panel3.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.White
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(41, 14)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(199, 13)
        Me.Label7.TabIndex = 420
        Me.Label7.Text = "Please wait, process has been aborted..."
        Me.Label7.Visible = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.ForeColor = System.Drawing.Color.OliveDrab
        Me.ProgressBar1.Location = New System.Drawing.Point(13, 122)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(274, 22)
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar1.TabIndex = 418
        '
        'btnEndProcess
        '
        Me.btnEndProcess.BackColor = System.Drawing.Color.Salmon
        Me.btnEndProcess.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEndProcess.ForeColor = System.Drawing.Color.Transparent
        Me.btnEndProcess.Location = New System.Drawing.Point(246, 9)
        Me.btnEndProcess.Name = "btnEndProcess"
        Me.btnEndProcess.Size = New System.Drawing.Size(49, 22)
        Me.btnEndProcess.TabIndex = 419
        Me.btnEndProcess.Text = "Abort"
        Me.btnEndProcess.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(8, 9)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(287, 141)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 416
        Me.PictureBox1.TabStop = False
        '
        'Timer1
        '
        '
        'Timer2
        '
        Me.Timer2.Interval = 1000
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(786, 392)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 13)
        Me.Label6.TabIndex = 420
        Me.Label6.Text = "Label6"
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(864, 115)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(120, 238)
        Me.ListBox1.TabIndex = 421
        '
        'Timer3
        '
        Me.Timer3.Interval = 1000
        '
        'cmbProject1
        '
        Me.cmbProject1.Enabled = False
        Me.cmbProject1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbProject1.FormattingEnabled = True
        Me.cmbProject1.Location = New System.Drawing.Point(108, 43)
        Me.cmbProject1.Name = "cmbProject1"
        Me.cmbProject1.Size = New System.Drawing.Size(264, 24)
        Me.cmbProject1.TabIndex = 3
        '
        'timer_thread
        '
        Me.timer_thread.Interval = 1000
        '
        'timer_thread1
        '
        Me.timer_thread1.Interval = 1000
        '
        'GroupBox1
        '
        Me.GroupBox1.BackgroundImage = Global.SUPPLY.My.Resources.Resources.bg_line
        Me.GroupBox1.Controls.Add(Me.cmbByDate)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.cmbProject1)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.cmbProject)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.dtpdatefrom)
        Me.GroupBox1.Controls.Add(Me.Button4)
        Me.GroupBox1.Controls.Add(Me.dtpdateto)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtItemSearch)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(186, 511)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(498, 207)
        Me.GroupBox1.TabIndex = 422
        Me.GroupBox1.TabStop = False
        '
        'cmbByDate
        '
        Me.cmbByDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbByDate.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbByDate.FormattingEnabled = True
        Me.cmbByDate.Items.AddRange(New Object() {"BY DATE RANGE", "BY DATE FROM THE BEGINNING", "BY SPECIFIC REQUESTOR"})
        Me.cmbByDate.Location = New System.Drawing.Point(108, 107)
        Me.cmbByDate.Name = "cmbByDate"
        Me.cmbByDate.Size = New System.Drawing.Size(264, 24)
        Me.cmbByDate.TabIndex = 20
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(56, 170)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(49, 13)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Date To:"
        '
        'timer_thread2
        '
        Me.timer_thread2.Interval = 1000
        '
        'timer_thread3
        '
        Me.timer_thread3.Interval = 1000
        '
        'timer_thread4
        '
        Me.timer_thread4.Interval = 1000
        '
        'BackgroundWorker1
        '
        '
        'BackgroundWorker2
        '
        '
        'BW_rrPrice
        '
        '
        'Fsearchbycharges
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SUPPLY.My.Resources.Resources.bg_line
        Me.ClientSize = New System.Drawing.Size(697, 724)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.txtChargesSearch)
        Me.Controls.Add(Me.cmbGenerateProject)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lvlSearchCharges)
        Me.Controls.Add(Me.GroupBox1)
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Fsearchbycharges"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Fsearchbycharges"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lvlSearchCharges As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents Button1 As Button
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents SelectAllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UnselectAllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents cmbProject As ComboBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents dtpdatefrom As DateTimePicker
    Friend WithEvents dtpdateto As DateTimePicker
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbGenerateProject As ComboBox
    Friend WithEvents txtChargesSearch As TextBox
    Friend WithEvents txtItemSearch As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Button4 As Button
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents Panel3 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Timer2 As Timer
    Friend WithEvents btnEndProcess As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents Timer3 As Timer
    Friend WithEvents cmbProject1 As ComboBox
    Friend WithEvents timer_thread As Timer
    Friend WithEvents timer_thread1 As Timer
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents cmbByDate As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents timer_thread2 As Timer
    Friend WithEvents timer_thread3 As Timer
    Friend WithEvents timer_thread4 As Timer
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents BackgroundWorker2 As System.ComponentModel.BackgroundWorker
    Friend WithEvents col_RRPrice As ColumnHeader
    Friend WithEvents ShowRRPriceToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents col_TypeOfPurchasing As ColumnHeader
    Friend WithEvents BW_rrPrice As System.ComponentModel.BackgroundWorker
End Class
