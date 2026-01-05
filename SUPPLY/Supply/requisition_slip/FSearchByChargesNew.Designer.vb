<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FSearchByChargesNew
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
        Me.lvlSearchCharges = New System.Windows.Forms.ListView()
        Me.colRsNo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colItemDescriptionFromItemChecked = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colRsDate = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colWhId = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colRsId = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCharges = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colItemDescFromRs = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colRRPrice = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colTypeOfPurchasing = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CMS_searchByChargesLvl = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SelectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UndoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnProceed = New System.Windows.Forms.Button()
        Me.loadingPanel = New System.Windows.Forms.Panel()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TchargesChecker = New System.Windows.Forms.Timer(Me.components)
        Me.TchargesExecuter = New System.Windows.Forms.Timer(Me.components)
        Me.colRequestedBy = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CMS_searchByChargesLvl.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.loadingPanel.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvlSearchCharges
        '
        Me.lvlSearchCharges.CheckBoxes = True
        Me.lvlSearchCharges.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colRsNo, Me.colItemDescriptionFromItemChecked, Me.colRsDate, Me.colWhId, Me.colRsId, Me.colCharges, Me.colItemDescFromRs, Me.colRRPrice, Me.colTypeOfPurchasing, Me.colRequestedBy})
        Me.lvlSearchCharges.ContextMenuStrip = Me.CMS_searchByChargesLvl
        Me.lvlSearchCharges.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvlSearchCharges.Font = New System.Drawing.Font("Bombardier", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvlSearchCharges.FullRowSelect = True
        Me.lvlSearchCharges.HideSelection = False
        Me.lvlSearchCharges.Location = New System.Drawing.Point(0, 0)
        Me.lvlSearchCharges.Name = "lvlSearchCharges"
        Me.lvlSearchCharges.Size = New System.Drawing.Size(1250, 568)
        Me.lvlSearchCharges.TabIndex = 1
        Me.lvlSearchCharges.UseCompatibleStateImageBehavior = False
        Me.lvlSearchCharges.View = System.Windows.Forms.View.Details
        '
        'colRsNo
        '
        Me.colRsNo.Text = "RS NO."
        Me.colRsNo.Width = 144
        '
        'colItemDescriptionFromItemChecked
        '
        Me.colItemDescriptionFromItemChecked.Text = "ITEM DESCRIPTION FROM ITEM CHECK"
        Me.colItemDescriptionFromItemChecked.Width = 226
        '
        'colRsDate
        '
        Me.colRsDate.DisplayIndex = 4
        Me.colRsDate.Text = "RS DATE"
        Me.colRsDate.Width = 146
        '
        'colWhId
        '
        Me.colWhId.DisplayIndex = 5
        Me.colWhId.Text = "WH_ID"
        '
        'colRsId
        '
        Me.colRsId.DisplayIndex = 6
        Me.colRsId.Text = "RS_ID"
        '
        'colCharges
        '
        Me.colCharges.DisplayIndex = 7
        Me.colCharges.Text = "PROJECT/CHARGES"
        Me.colCharges.Width = 150
        '
        'colItemDescFromRs
        '
        Me.colItemDescFromRs.DisplayIndex = 2
        Me.colItemDescFromRs.Text = "ITEM DESCRIPTION FROM RS"
        Me.colItemDescFromRs.Width = 150
        '
        'colRRPrice
        '
        Me.colRRPrice.DisplayIndex = 3
        Me.colRRPrice.Text = "PRICE/AMOUNT"
        Me.colRRPrice.Width = 200
        '
        'colTypeOfPurchasing
        '
        Me.colTypeOfPurchasing.Text = "TYPE OF PURCHASING"
        Me.colTypeOfPurchasing.Width = 200
        '
        'CMS_searchByChargesLvl
        '
        Me.CMS_searchByChargesLvl.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SelectToolStripMenuItem})
        Me.CMS_searchByChargesLvl.Name = "CMS_searchByChargesLvl"
        Me.CMS_searchByChargesLvl.Size = New System.Drawing.Size(106, 26)
        '
        'SelectToolStripMenuItem
        '
        Me.SelectToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SelectAllToolStripMenuItem, Me.UndoToolStripMenuItem})
        Me.SelectToolStripMenuItem.Name = "SelectToolStripMenuItem"
        Me.SelectToolStripMenuItem.Size = New System.Drawing.Size(105, 22)
        Me.SelectToolStripMenuItem.Text = "Select"
        '
        'SelectAllToolStripMenuItem
        '
        Me.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem"
        Me.SelectAllToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
        Me.SelectAllToolStripMenuItem.Text = "Select All"
        '
        'UndoToolStripMenuItem
        '
        Me.UndoToolStripMenuItem.Name = "UndoToolStripMenuItem"
        Me.UndoToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
        Me.UndoToolStripMenuItem.Text = "Undo"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.btnProceed)
        Me.Panel1.Controls.Add(Me.loadingPanel)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 568)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1250, 45)
        Me.Panel1.TabIndex = 2
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.SUPPLY.My.Resources.Resources.PVtR
        Me.PictureBox1.Location = New System.Drawing.Point(994, 6)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(47, 34)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 434
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(710, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 433
        Me.Label1.Text = "Label1"
        '
        'btnProceed
        '
        Me.btnProceed.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnProceed.BackColor = System.Drawing.Color.YellowGreen
        Me.btnProceed.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProceed.Font = New System.Drawing.Font("Bombardier", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProceed.Image = Global.SUPPLY.My.Resources.Resources.logout
        Me.btnProceed.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnProceed.Location = New System.Drawing.Point(1047, 5)
        Me.btnProceed.Name = "btnProceed"
        Me.btnProceed.Size = New System.Drawing.Size(191, 35)
        Me.btnProceed.TabIndex = 431
        Me.btnProceed.Text = "PROCEED"
        Me.btnProceed.UseVisualStyleBackColor = False
        '
        'loadingPanel
        '
        Me.loadingPanel.BackColor = System.Drawing.Color.Black
        Me.loadingPanel.Controls.Add(Me.Label20)
        Me.loadingPanel.Controls.Add(Me.PictureBox4)
        Me.loadingPanel.Location = New System.Drawing.Point(12, 6)
        Me.loadingPanel.Name = "loadingPanel"
        Me.loadingPanel.Size = New System.Drawing.Size(264, 31)
        Me.loadingPanel.TabIndex = 430
        Me.loadingPanel.Visible = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label20.Location = New System.Drawing.Point(43, 5)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(204, 19)
        Me.Label20.TabIndex = 1
        Me.Label20.Text = "Fetching data, please wait..."
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = Global.SUPPLY.My.Resources.Resources.spinner
        Me.PictureBox4.Location = New System.Drawing.Point(0, -3)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(38, 37)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox4.TabIndex = 0
        Me.PictureBox4.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lvlSearchCharges)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1250, 568)
        Me.Panel2.TabIndex = 3
        '
        'TchargesChecker
        '
        Me.TchargesChecker.Interval = 800
        '
        'TchargesExecuter
        '
        Me.TchargesExecuter.Interval = 800
        '
        'colRequestedBy
        '
        Me.colRequestedBy.Text = "Requested By"
        Me.colRequestedBy.Width = 200
        '
        'FSearchByChargesNew
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1250, 613)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FSearchByChargesNew"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FSearchByChargesNew"
        Me.CMS_searchByChargesLvl.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.loadingPanel.ResumeLayout(False)
        Me.loadingPanel.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lvlSearchCharges As ListView
    Friend WithEvents colRsNo As ColumnHeader
    Friend WithEvents colItemDescriptionFromItemChecked As ColumnHeader
    Friend WithEvents colRsDate As ColumnHeader
    Friend WithEvents colWhId As ColumnHeader
    Friend WithEvents colRsId As ColumnHeader
    Friend WithEvents colCharges As ColumnHeader
    Friend WithEvents colItemDescFromRs As ColumnHeader
    Friend WithEvents colRRPrice As ColumnHeader
    Friend WithEvents colTypeOfPurchasing As ColumnHeader
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents loadingPanel As Panel
    Friend WithEvents Label20 As Label
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents CMS_searchByChargesLvl As ContextMenuStrip
    Friend WithEvents SelectToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SelectAllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UndoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnProceed As Button
    Friend WithEvents TchargesChecker As Timer
    Friend WithEvents Label1 As Label
    Friend WithEvents TchargesExecuter As Timer
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents colRequestedBy As ColumnHeader
End Class
