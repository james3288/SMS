<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FFacilities_Tools
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FFacilities_Tools))
        Me.Label4 = New System.Windows.Forms.Label
        Me.btnExit = New System.Windows.Forms.Button
        Me.pboxHeader = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.cmbFacTools = New System.Windows.Forms.ComboBox
        Me.txtBrandTools = New System.Windows.Forms.TextBox
        Me.lblItemName = New System.Windows.Forms.Label
        Me.lvlFacTools = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader5 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader6 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader7 = New System.Windows.Forms.ColumnHeader
        Me.CMB_lvlFacTools = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RemoveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.txtRemarks = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnRemove = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.txtSearch = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.pnlAddFacTools = New System.Windows.Forms.Panel
        Me.Button2 = New System.Windows.Forms.Button
        Me.cmbFac_type = New System.Windows.Forms.ComboBox
        Me.btnFac_Save = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtFac_desc = New System.Windows.Forms.TextBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.btnCreateBS = New System.Windows.Forms.Button
        Me.lblnote = New System.Windows.Forms.Label
        CType(Me.pboxHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMB_lvlFacTools.SuspendLayout()
        Me.pnlAddFacTools.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(12, 53)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(114, 15)
        Me.Label4.TabIndex = 363
        Me.Label4.Text = "Facilities and Tools"
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.Transparent
        Me.btnExit.BackgroundImage = CType(resources.GetObject("btnExit.BackgroundImage"), System.Drawing.Image)
        Me.btnExit.FlatAppearance.BorderSize = 0
        Me.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit.Location = New System.Drawing.Point(1159, 12)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(20, 20)
        Me.btnExit.TabIndex = 387
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'pboxHeader
        '
        Me.pboxHeader.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.pboxHeader.BackgroundImage = CType(resources.GetObject("pboxHeader.BackgroundImage"), System.Drawing.Image)
        Me.pboxHeader.InitialImage = Nothing
        Me.pboxHeader.Location = New System.Drawing.Point(-1, 1)
        Me.pboxHeader.Name = "pboxHeader"
        Me.pboxHeader.Size = New System.Drawing.Size(1195, 41)
        Me.pboxHeader.TabIndex = 386
        Me.pboxHeader.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = Global.SUPPLY.My.Resources.Resources.Plus_sign
        Me.PictureBox1.Location = New System.Drawing.Point(204, 72)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(26, 23)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 389
        Me.PictureBox1.TabStop = False
        '
        'cmbFacTools
        '
        Me.cmbFacTools.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFacTools.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbFacTools.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFacTools.FormattingEnabled = True
        Me.cmbFacTools.Items.AddRange(New Object() {"SUPPLY", "EQUIPMENT", "PROJECT", "OTHERS"})
        Me.cmbFacTools.Location = New System.Drawing.Point(15, 72)
        Me.cmbFacTools.Name = "cmbFacTools"
        Me.cmbFacTools.Size = New System.Drawing.Size(183, 24)
        Me.cmbFacTools.TabIndex = 388
        '
        'txtBrandTools
        '
        Me.txtBrandTools.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBrandTools.Location = New System.Drawing.Point(16, 125)
        Me.txtBrandTools.Name = "txtBrandTools"
        Me.txtBrandTools.Size = New System.Drawing.Size(278, 24)
        Me.txtBrandTools.TabIndex = 390
        '
        'lblItemName
        '
        Me.lblItemName.AutoSize = True
        Me.lblItemName.BackColor = System.Drawing.Color.Transparent
        Me.lblItemName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItemName.ForeColor = System.Drawing.Color.White
        Me.lblItemName.Location = New System.Drawing.Point(16, 106)
        Me.lblItemName.Name = "lblItemName"
        Me.lblItemName.Size = New System.Drawing.Size(81, 15)
        Me.lblItemName.TabIndex = 391
        Me.lblItemName.Text = "Specification"
        '
        'lvlFacTools
        '
        Me.lvlFacTools.CheckBoxes = True
        Me.lvlFacTools.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7})
        Me.lvlFacTools.ContextMenuStrip = Me.CMB_lvlFacTools
        Me.lvlFacTools.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvlFacTools.FullRowSelect = True
        Me.lvlFacTools.GridLines = True
        Me.lvlFacTools.HideSelection = False
        Me.lvlFacTools.Location = New System.Drawing.Point(313, 72)
        Me.lvlFacTools.Name = "lvlFacTools"
        Me.lvlFacTools.Size = New System.Drawing.Size(866, 401)
        Me.lvlFacTools.TabIndex = 392
        Me.lvlFacTools.UseCompatibleStateImageBehavior = False
        Me.lvlFacTools.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "id"
        Me.ColumnHeader1.Width = 50
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Facilities/Tools"
        Me.ColumnHeader2.Width = 160
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Specification"
        Me.ColumnHeader3.Width = 216
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Remarks"
        Me.ColumnHeader4.Width = 200
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Available"
        Me.ColumnHeader5.Width = 73
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Borrowed"
        Me.ColumnHeader6.Width = 79
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Total # of Item"
        Me.ColumnHeader7.Width = 84
        '
        'CMB_lvlFacTools
        '
        Me.CMB_lvlFacTools.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditToolStripMenuItem, Me.RemoveToolStripMenuItem, Me.DetailsToolStripMenuItem})
        Me.CMB_lvlFacTools.Name = "CMB_lvlFacTools"
        Me.CMB_lvlFacTools.Size = New System.Drawing.Size(118, 70)
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'RemoveToolStripMenuItem
        '
        Me.RemoveToolStripMenuItem.Name = "RemoveToolStripMenuItem"
        Me.RemoveToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.RemoveToolStripMenuItem.Text = "Remove"
        '
        'DetailsToolStripMenuItem
        '
        Me.DetailsToolStripMenuItem.Name = "DetailsToolStripMenuItem"
        Me.DetailsToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.DetailsToolStripMenuItem.Text = "Details"
        '
        'txtRemarks
        '
        Me.txtRemarks.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRemarks.Location = New System.Drawing.Point(16, 180)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(278, 51)
        Me.txtRemarks.TabIndex = 395
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(16, 162)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 15)
        Me.Label3.TabIndex = 396
        Me.Label3.Text = "Remarks"
        '
        'btnRemove
        '
        Me.btnRemove.Location = New System.Drawing.Point(16, 246)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(137, 30)
        Me.btnRemove.TabIndex = 399
        Me.btnRemove.Text = "Remove"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(159, 246)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(135, 30)
        Me.btnSave.TabIndex = 398
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'txtSearch
        '
        Me.txtSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(869, 487)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(310, 24)
        Me.txtSearch.TabIndex = 402
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(813, 492)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 15)
        Me.Label1.TabIndex = 401
        Me.Label1.Text = "Search"
        '
        'pnlAddFacTools
        '
        Me.pnlAddFacTools.Controls.Add(Me.Button2)
        Me.pnlAddFacTools.Controls.Add(Me.cmbFac_type)
        Me.pnlAddFacTools.Controls.Add(Me.btnFac_Save)
        Me.pnlAddFacTools.Controls.Add(Me.Label6)
        Me.pnlAddFacTools.Controls.Add(Me.Label5)
        Me.pnlAddFacTools.Controls.Add(Me.txtFac_desc)
        Me.pnlAddFacTools.Enabled = False
        Me.pnlAddFacTools.Location = New System.Drawing.Point(10, 290)
        Me.pnlAddFacTools.Name = "pnlAddFacTools"
        Me.pnlAddFacTools.Size = New System.Drawing.Size(284, 164)
        Me.pnlAddFacTools.TabIndex = 403
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.BackgroundImage = CType(resources.GetObject("Button2.BackgroundImage"), System.Drawing.Image)
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(247, 8)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(22, 22)
        Me.Button2.TabIndex = 407
        Me.Button2.UseVisualStyleBackColor = False
        '
        'cmbFac_type
        '
        Me.cmbFac_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFac_type.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbFac_type.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFac_type.FormattingEnabled = True
        Me.cmbFac_type.Items.AddRange(New Object() {"Facilities", "Tools"})
        Me.cmbFac_type.Location = New System.Drawing.Point(15, 39)
        Me.cmbFac_type.Name = "cmbFac_type"
        Me.cmbFac_type.Size = New System.Drawing.Size(253, 24)
        Me.cmbFac_type.TabIndex = 406
        '
        'btnFac_Save
        '
        Me.btnFac_Save.Location = New System.Drawing.Point(142, 121)
        Me.btnFac_Save.Name = "btnFac_Save"
        Me.btnFac_Save.Size = New System.Drawing.Size(126, 30)
        Me.btnFac_Save.TabIndex = 405
        Me.btnFac_Save.Text = "Save"
        Me.btnFac_Save.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(12, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(33, 15)
        Me.Label6.TabIndex = 404
        Me.Label6.Text = "Type"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(12, 66)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 15)
        Me.Label5.TabIndex = 404
        Me.Label5.Text = "Description"
        '
        'txtFac_desc
        '
        Me.txtFac_desc.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFac_desc.Location = New System.Drawing.Point(15, 84)
        Me.txtFac_desc.Name = "txtFac_desc"
        Me.txtFac_desc.Size = New System.Drawing.Size(253, 24)
        Me.txtFac_desc.TabIndex = 403
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(268, 72)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(26, 23)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 404
        Me.PictureBox2.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(1285, 132)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(13, 13)
        Me.Label2.TabIndex = 405
        Me.Label2.Text = "0"
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(236, 72)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(26, 23)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 406
        Me.PictureBox3.TabStop = False
        '
        'btnCreateBS
        '
        Me.btnCreateBS.Location = New System.Drawing.Point(313, 481)
        Me.btnCreateBS.Name = "btnCreateBS"
        Me.btnCreateBS.Size = New System.Drawing.Size(154, 30)
        Me.btnCreateBS.TabIndex = 407
        Me.btnCreateBS.Text = "Create Borrower Slip"
        Me.btnCreateBS.UseVisualStyleBackColor = True
        '
        'lblnote
        '
        Me.lblnote.AutoSize = True
        Me.lblnote.BackColor = System.Drawing.Color.Transparent
        Me.lblnote.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblnote.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblnote.Location = New System.Drawing.Point(313, 50)
        Me.lblnote.Name = "lblnote"
        Me.lblnote.Size = New System.Drawing.Size(0, 17)
        Me.lblnote.TabIndex = 408
        '
        'FFacilities_Tools
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SUPPLY.My.Resources.Resources.eus_bg_03
        Me.ClientSize = New System.Drawing.Size(1194, 527)
        Me.Controls.Add(Me.lblnote)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.pnlAddFacTools)
        Me.Controls.Add(Me.btnCreateBS)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtRemarks)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.txtBrandTools)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lvlFacTools)
        Me.Controls.Add(Me.lblItemName)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.cmbFacTools)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.pboxHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FFacilities_Tools"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "a"
        CType(Me.pboxHeader, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMB_lvlFacTools.ResumeLayout(False)
        Me.pnlAddFacTools.ResumeLayout(False)
        Me.pnlAddFacTools.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents pboxHeader As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents cmbFacTools As System.Windows.Forms.ComboBox
    Friend WithEvents txtBrandTools As System.Windows.Forms.TextBox
    Friend WithEvents lblItemName As System.Windows.Forms.Label
    Friend WithEvents lvlFacTools As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents CMB_lvlFacTools As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RemoveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlAddFacTools As System.Windows.Forms.Panel
    Friend WithEvents btnFac_Save As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtFac_desc As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbFac_type As System.Windows.Forms.ComboBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents DetailsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnCreateBS As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblnote As System.Windows.Forms.Label
End Class
