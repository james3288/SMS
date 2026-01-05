<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formAccountTitle
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.listViewRequest = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.PickSubToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblID = New System.Windows.Forms.Label()
        Me.lblDescPick = New System.Windows.Forms.Label()
        Me.lblDataCount = New System.Windows.Forms.Label()
        Me.lblHeaderTitle = New System.Windows.Forms.Label()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.lblCategory = New System.Windows.Forms.Label()
        Me.txtCategory = New System.Windows.Forms.TextBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.txtSaveType = New System.Windows.Forms.TextBox()
        Me.lblSaveType = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lblSearchType = New System.Windows.Forms.Label()
        Me.cmbSearchType = New System.Windows.Forms.ComboBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.txtDesc = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.listViewRequest)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.lblID)
        Me.Panel1.Controls.Add(Me.lblDescPick)
        Me.Panel1.Controls.Add(Me.lblDataCount)
        Me.Panel1.Controls.Add(Me.lblHeaderTitle)
        Me.Panel1.Controls.Add(Me.btnExit)
        Me.Panel1.Location = New System.Drawing.Point(14, 8)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1060, 577)
        Me.Panel1.TabIndex = 366
        '
        'listViewRequest
        '
        Me.listViewRequest.AllowColumnReorder = True
        Me.listViewRequest.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader5, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader6})
        Me.listViewRequest.ContextMenuStrip = Me.ContextMenuStrip1
        Me.listViewRequest.Font = New System.Drawing.Font("Bombardier", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.listViewRequest.FullRowSelect = True
        Me.listViewRequest.GridLines = True
        Me.listViewRequest.HideSelection = False
        Me.listViewRequest.Location = New System.Drawing.Point(2, 26)
        Me.listViewRequest.Name = "listViewRequest"
        Me.listViewRequest.Size = New System.Drawing.Size(1053, 522)
        Me.listViewRequest.TabIndex = 370
        Me.listViewRequest.UseCompatibleStateImageBehavior = False
        Me.listViewRequest.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Id"
        Me.ColumnHeader1.Width = 40
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.DisplayIndex = 2
        Me.ColumnHeader5.Text = "Type of Request"
        Me.ColumnHeader5.Width = 250
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.DisplayIndex = 3
        Me.ColumnHeader2.Text = "Decription"
        Me.ColumnHeader2.Width = 250
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.DisplayIndex = 4
        Me.ColumnHeader3.Text = "Date Created"
        Me.ColumnHeader3.Width = 100
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.DisplayIndex = 5
        Me.ColumnHeader4.Text = "User Created"
        Me.ColumnHeader4.Width = 157
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.DisplayIndex = 1
        Me.ColumnHeader6.Text = "Type of Request Sub"
        Me.ColumnHeader6.Width = 250
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PickSubToolStripMenuItem, Me.UpdateToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(120, 70)
        '
        'PickSubToolStripMenuItem
        '
        Me.PickSubToolStripMenuItem.BackgroundImage = Global.SUPPLY.My.Resources.Resources.request
        Me.PickSubToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PickSubToolStripMenuItem.Name = "PickSubToolStripMenuItem"
        Me.PickSubToolStripMenuItem.Size = New System.Drawing.Size(119, 22)
        Me.PickSubToolStripMenuItem.Text = "Pick Sub"
        '
        'UpdateToolStripMenuItem
        '
        Me.UpdateToolStripMenuItem.BackgroundImage = Global.SUPPLY.My.Resources.Resources.transfer
        Me.UpdateToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.UpdateToolStripMenuItem.Name = "UpdateToolStripMenuItem"
        Me.UpdateToolStripMenuItem.Size = New System.Drawing.Size(119, 22)
        Me.UpdateToolStripMenuItem.Text = "Update"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.BackgroundImage = Global.SUPPLY.My.Resources.Resources.remove_icon
        Me.DeleteToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(119, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Bombardier", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(6, 551)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 16)
        Me.Label1.TabIndex = 369
        Me.Label1.Text = "Selected Desc:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblID
        '
        Me.lblID.AutoSize = True
        Me.lblID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblID.ForeColor = System.Drawing.Color.White
        Me.lblID.Location = New System.Drawing.Point(284, 552)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(75, 13)
        Me.lblID.TabIndex = 368
        Me.lblID.Text = "Sub Pick ID"
        '
        'lblDescPick
        '
        Me.lblDescPick.AutoSize = True
        Me.lblDescPick.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescPick.ForeColor = System.Drawing.Color.White
        Me.lblDescPick.Location = New System.Drawing.Point(111, 553)
        Me.lblDescPick.Name = "lblDescPick"
        Me.lblDescPick.Size = New System.Drawing.Size(91, 13)
        Me.lblDescPick.TabIndex = 367
        Me.lblDescPick.Text = "Sub Pick Desc"
        Me.lblDescPick.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDataCount
        '
        Me.lblDataCount.AutoSize = True
        Me.lblDataCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDataCount.ForeColor = System.Drawing.Color.White
        Me.lblDataCount.Location = New System.Drawing.Point(616, 553)
        Me.lblDataCount.Name = "lblDataCount"
        Me.lblDataCount.Size = New System.Drawing.Size(71, 13)
        Me.lblDataCount.TabIndex = 365
        Me.lblDataCount.Text = "Data Count"
        '
        'lblHeaderTitle
        '
        Me.lblHeaderTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblHeaderTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblHeaderTitle.Font = New System.Drawing.Font("Bombardier", 17.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeaderTitle.ForeColor = System.Drawing.Color.White
        Me.lblHeaderTitle.Location = New System.Drawing.Point(55, 2)
        Me.lblHeaderTitle.Name = "lblHeaderTitle"
        Me.lblHeaderTitle.Size = New System.Drawing.Size(940, 25)
        Me.lblHeaderTitle.TabIndex = 364
        Me.lblHeaderTitle.Text = "TYPE OF REQUEST"
        Me.lblHeaderTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.Transparent
        Me.btnExit.BackgroundImage = Global.SUPPLY.My.Resources.Resources.close_button
        Me.btnExit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExit.FlatAppearance.BorderSize = 0
        Me.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit.Location = New System.Drawing.Point(1035, 3)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(20, 20)
        Me.btnExit.TabIndex = 362
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnSearch.BackColor = System.Drawing.Color.LightSalmon
        Me.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.Font = New System.Drawing.Font("Bombardier", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(756, 45)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(296, 35)
        Me.btnSearch.TabIndex = 497
        Me.btnSearch.Text = "Search"
        Me.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnSave.BackColor = System.Drawing.Color.Cyan
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Bombardier", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(756, 5)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(296, 35)
        Me.btnSave.TabIndex = 20
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Panel6)
        Me.Panel2.Controls.Add(Me.Panel5)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.btnSearch)
        Me.Panel2.Controls.Add(Me.btnSave)
        Me.Panel2.Location = New System.Drawing.Point(11, 591)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1063, 128)
        Me.Panel2.TabIndex = 367
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.Black
        Me.Panel6.Controls.Add(Me.lblCategory)
        Me.Panel6.Controls.Add(Me.txtCategory)
        Me.Panel6.Location = New System.Drawing.Point(6, 84)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(452, 34)
        Me.Panel6.TabIndex = 499
        '
        'lblCategory
        '
        Me.lblCategory.AutoSize = True
        Me.lblCategory.BackColor = System.Drawing.Color.Transparent
        Me.lblCategory.Font = New System.Drawing.Font("Bombardier", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCategory.ForeColor = System.Drawing.Color.White
        Me.lblCategory.Location = New System.Drawing.Point(8, 9)
        Me.lblCategory.Name = "lblCategory"
        Me.lblCategory.Size = New System.Drawing.Size(78, 18)
        Me.lblCategory.TabIndex = 22
        Me.lblCategory.Text = "Category:"
        '
        'txtCategory
        '
        Me.txtCategory.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.txtCategory.Location = New System.Drawing.Point(137, 4)
        Me.txtCategory.Name = "txtCategory"
        Me.txtCategory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtCategory.Size = New System.Drawing.Size(310, 26)
        Me.txtCategory.TabIndex = 21
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Black
        Me.Panel5.Controls.Add(Me.txtSaveType)
        Me.Panel5.Controls.Add(Me.lblSaveType)
        Me.Panel5.Location = New System.Drawing.Point(756, 84)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(296, 34)
        Me.Panel5.TabIndex = 500
        Me.Panel5.Visible = False
        '
        'txtSaveType
        '
        Me.txtSaveType.Font = New System.Drawing.Font("Arial", 11.0!)
        Me.txtSaveType.Location = New System.Drawing.Point(103, 4)
        Me.txtSaveType.Name = "txtSaveType"
        Me.txtSaveType.ReadOnly = True
        Me.txtSaveType.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtSaveType.Size = New System.Drawing.Size(120, 24)
        Me.txtSaveType.TabIndex = 500
        '
        'lblSaveType
        '
        Me.lblSaveType.AutoSize = True
        Me.lblSaveType.BackColor = System.Drawing.Color.Transparent
        Me.lblSaveType.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSaveType.ForeColor = System.Drawing.Color.White
        Me.lblSaveType.Location = New System.Drawing.Point(8, 8)
        Me.lblSaveType.Name = "lblSaveType"
        Me.lblSaveType.Size = New System.Drawing.Size(95, 17)
        Me.lblSaveType.TabIndex = 499
        Me.lblSaveType.Text = "Insert Type:"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Black
        Me.Panel4.Controls.Add(Me.lblSearchType)
        Me.Panel4.Controls.Add(Me.cmbSearchType)
        Me.Panel4.Location = New System.Drawing.Point(6, 6)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(452, 34)
        Me.Panel4.TabIndex = 499
        '
        'lblSearchType
        '
        Me.lblSearchType.AutoSize = True
        Me.lblSearchType.BackColor = System.Drawing.Color.Transparent
        Me.lblSearchType.Font = New System.Drawing.Font("Bombardier", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSearchType.ForeColor = System.Drawing.Color.White
        Me.lblSearchType.Location = New System.Drawing.Point(9, 8)
        Me.lblSearchType.Name = "lblSearchType"
        Me.lblSearchType.Size = New System.Drawing.Size(103, 18)
        Me.lblSearchType.TabIndex = 499
        Me.lblSearchType.Text = "Search Type:"
        '
        'cmbSearchType
        '
        Me.cmbSearchType.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSearchType.FormattingEnabled = True
        Me.cmbSearchType.Items.AddRange(New Object() {"Request", "Request Sub", "Account Title"})
        Me.cmbSearchType.Location = New System.Drawing.Point(138, 4)
        Me.cmbSearchType.Name = "cmbSearchType"
        Me.cmbSearchType.Size = New System.Drawing.Size(308, 26)
        Me.cmbSearchType.TabIndex = 498
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Black
        Me.Panel3.Controls.Add(Me.lblDescription)
        Me.Panel3.Controls.Add(Me.txtDesc)
        Me.Panel3.Location = New System.Drawing.Point(6, 45)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(452, 34)
        Me.Panel3.TabIndex = 498
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.BackColor = System.Drawing.Color.Transparent
        Me.lblDescription.Font = New System.Drawing.Font("Bombardier", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescription.ForeColor = System.Drawing.Color.White
        Me.lblDescription.Location = New System.Drawing.Point(8, 9)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(95, 18)
        Me.lblDescription.TabIndex = 22
        Me.lblDescription.Text = "Description:"
        '
        'txtDesc
        '
        Me.txtDesc.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.txtDesc.Location = New System.Drawing.Point(139, 4)
        Me.txtDesc.Name = "txtDesc"
        Me.txtDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDesc.Size = New System.Drawing.Size(308, 26)
        Me.txtDesc.TabIndex = 21
        '
        'formAccountTitle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SUPPLY.My.Resources.Resources.bg_line
        Me.ClientSize = New System.Drawing.Size(1086, 731)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "formAccountTitle"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "formAccountTitle"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents lblID As Label
    Friend WithEvents lblDescPick As Label
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents PickSubToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UpdateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents lblDataCount As Label
    Friend WithEvents lblHeaderTitle As Label
    Friend WithEvents btnExit As Button
    Friend WithEvents btnSearch As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents lblCategory As Label
    Friend WithEvents txtCategory As TextBox
    Friend WithEvents Panel5 As Panel
    Friend WithEvents txtSaveType As TextBox
    Friend WithEvents lblSaveType As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents lblSearchType As Label
    Friend WithEvents cmbSearchType As ComboBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents lblDescription As Label
    Friend WithEvents txtDesc As TextBox
    Friend WithEvents listViewRequest As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
End Class
