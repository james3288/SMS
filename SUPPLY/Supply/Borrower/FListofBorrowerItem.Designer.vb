<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FListofBorrowerItem
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
        Me.lvlBorrowerItem = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CMS_lvl = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CreateBorrowerSlipToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SetItemNoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewHistoryOfThisItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SetItemNameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnBMsearch = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.btn_proceed = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.cmbSearchBy = New System.Windows.Forms.ComboBox()
        Me.CMS_lvl.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvlBorrowerItem
        '
        Me.lvlBorrowerItem.CheckBoxes = True
        Me.lvlBorrowerItem.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader12, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11, Me.ColumnHeader13})
        Me.lvlBorrowerItem.ContextMenuStrip = Me.CMS_lvl
        Me.lvlBorrowerItem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvlBorrowerItem.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvlBorrowerItem.FullRowSelect = True
        Me.lvlBorrowerItem.GridLines = True
        Me.lvlBorrowerItem.HideSelection = False
        Me.lvlBorrowerItem.Location = New System.Drawing.Point(3, 3)
        Me.lvlBorrowerItem.Name = "lvlBorrowerItem"
        Me.lvlBorrowerItem.Size = New System.Drawing.Size(1522, 745)
        Me.lvlBorrowerItem.TabIndex = 2
        Me.lvlBorrowerItem.UseCompatibleStateImageBehavior = False
        Me.lvlBorrowerItem.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "rs_id"
        Me.ColumnHeader1.Width = 100
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "RS No."
        Me.ColumnHeader2.Width = 300
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "PO/CV No"
        Me.ColumnHeader3.Width = 103
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "RR No"
        Me.ColumnHeader4.Width = 205
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Item Name"
        Me.ColumnHeader5.Width = 400
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Item No."
        Me.ColumnHeader6.Width = 100
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Qty"
        Me.ColumnHeader7.Width = 100
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Available"
        Me.ColumnHeader8.Width = 107
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "Reserved"
        Me.ColumnHeader12.Width = 107
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "rr_item_id"
        Me.ColumnHeader9.Width = 0
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Borrowed"
        Me.ColumnHeader10.Width = 150
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Defective"
        Me.ColumnHeader11.Width = 150
        '
        'CMS_lvl
        '
        Me.CMS_lvl.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CreateBorrowerSlipToolStripMenuItem, Me.SetItemNoToolStripMenuItem, Me.ViewDetailsToolStripMenuItem, Me.ViewHistoryOfThisItemToolStripMenuItem, Me.SetItemNameToolStripMenuItem})
        Me.CMS_lvl.Name = "CMS_lvl"
        Me.CMS_lvl.Size = New System.Drawing.Size(204, 114)
        '
        'CreateBorrowerSlipToolStripMenuItem
        '
        Me.CreateBorrowerSlipToolStripMenuItem.Name = "CreateBorrowerSlipToolStripMenuItem"
        Me.CreateBorrowerSlipToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.CreateBorrowerSlipToolStripMenuItem.Text = "Create Borrower Slip"
        Me.CreateBorrowerSlipToolStripMenuItem.Visible = False
        '
        'SetItemNoToolStripMenuItem
        '
        Me.SetItemNoToolStripMenuItem.Name = "SetItemNoToolStripMenuItem"
        Me.SetItemNoToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.SetItemNoToolStripMenuItem.Text = "Set Item No."
        '
        'ViewDetailsToolStripMenuItem
        '
        Me.ViewDetailsToolStripMenuItem.Name = "ViewDetailsToolStripMenuItem"
        Me.ViewDetailsToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.ViewDetailsToolStripMenuItem.Text = "View Details"
        '
        'ViewHistoryOfThisItemToolStripMenuItem
        '
        Me.ViewHistoryOfThisItemToolStripMenuItem.Name = "ViewHistoryOfThisItemToolStripMenuItem"
        Me.ViewHistoryOfThisItemToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.ViewHistoryOfThisItemToolStripMenuItem.Text = "View History of this item"
        '
        'SetItemNameToolStripMenuItem
        '
        Me.SetItemNameToolStripMenuItem.Name = "SetItemNameToolStripMenuItem"
        Me.SetItemNameToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.SetItemNameToolStripMenuItem.Text = "Set Item Name"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel3, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.13233!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.867671!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1534, 813)
        Me.TableLayoutPanel1.TabIndex = 7
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.lvlBorrowerItem, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1528, 751)
        Me.TableLayoutPanel2.TabIndex = 3
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 5
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 255.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 550.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 117.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 456.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.btnBMsearch, 3, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label20, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btn_proceed, 4, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.ComboBox1, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.cmbSearchBy, 1, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 760)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(1528, 50)
        Me.TableLayoutPanel3.TabIndex = 4
        '
        'btnBMsearch
        '
        Me.btnBMsearch.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnBMsearch.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBMsearch.Location = New System.Drawing.Point(958, 12)
        Me.btnBMsearch.Name = "btnBMsearch"
        Me.btnBMsearch.Size = New System.Drawing.Size(111, 25)
        Me.btnBMsearch.TabIndex = 440
        Me.btnBMsearch.Text = "Search"
        Me.btnBMsearch.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(26, 17)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(121, 15)
        Me.Label20.TabIndex = 400
        Me.Label20.Text = "Search by Category:"
        '
        'btn_proceed
        '
        Me.btn_proceed.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_proceed.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_proceed.Location = New System.Drawing.Point(1075, 12)
        Me.btn_proceed.Name = "btn_proceed"
        Me.btn_proceed.Size = New System.Drawing.Size(124, 26)
        Me.btn_proceed.TabIndex = 444
        Me.btn_proceed.Text = "Proceed"
        Me.btn_proceed.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBox1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(408, 13)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(544, 24)
        Me.ComboBox1.TabIndex = 441
        '
        'cmbSearchBy
        '
        Me.cmbSearchBy.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbSearchBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSearchBy.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbSearchBy.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSearchBy.FormattingEnabled = True
        Me.cmbSearchBy.Items.AddRange(New Object() {"FACILITIES", "TOOLS", "SPECIFIC ITEM"})
        Me.cmbSearchBy.Location = New System.Drawing.Point(153, 12)
        Me.cmbSearchBy.Name = "cmbSearchBy"
        Me.cmbSearchBy.Size = New System.Drawing.Size(249, 26)
        Me.cmbSearchBy.TabIndex = 401
        '
        'FListofBorrowerItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1534, 813)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.KeyPreview = True
        Me.Name = "FListofBorrowerItem"
        Me.Text = "FListofBorrowerItem"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.CMS_lvl.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lvlBorrowerItem As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents CMS_lvl As ContextMenuStrip
    Friend WithEvents CreateBorrowerSlipToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents SetItemNoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ViewDetailsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ColumnHeader9 As ColumnHeader
    Friend WithEvents ColumnHeader10 As ColumnHeader
    Friend WithEvents ColumnHeader11 As ColumnHeader
    Friend WithEvents ViewHistoryOfThisItemToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents Label20 As Label
    Friend WithEvents cmbSearchBy As ComboBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents btnBMsearch As Button
    Friend WithEvents btn_proceed As Button
    Friend WithEvents SetItemNameToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader13 As ColumnHeader
End Class
