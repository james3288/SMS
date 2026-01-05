<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FMaterials_ToolsTurnOverReport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FMaterials_ToolsTurnOverReport))
        Me.btnExit = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.pboxHeader = New System.Windows.Forms.PictureBox()
        Me.lvlMaterialToolsList = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cms_materialToolsTurnOver = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lbl_materialTools_ID = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.cmbSearchByCategory = New System.Windows.Forms.ComboBox()
        Me.lblSearchByCategory = New System.Windows.Forms.Label()
        Me.DTP_search = New System.Windows.Forms.DateTimePicker()
        Me.btn_inputField = New System.Windows.Forms.Button()
        Me.ListJobOrderNo = New System.Windows.Forms.ListBox()
        Me.lbl_matID = New System.Windows.Forms.Label()
        CType(Me.pboxHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cms_materialToolsTurnOver.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.Transparent
        Me.btnExit.BackgroundImage = Global.SUPPLY.My.Resources.Resources.close_button
        Me.btnExit.FlatAppearance.BorderSize = 0
        Me.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit.Location = New System.Drawing.Point(1621, 9)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(20, 20)
        Me.btnExit.TabIndex = 357
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(17, 10)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(255, 22)
        Me.Label15.TabIndex = 355
        Me.Label15.Text = "Material/Tools Turn-Over Report"
        '
        'pboxHeader
        '
        Me.pboxHeader.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.pboxHeader.BackgroundImage = CType(resources.GetObject("pboxHeader.BackgroundImage"), System.Drawing.Image)
        Me.pboxHeader.InitialImage = Nothing
        Me.pboxHeader.Location = New System.Drawing.Point(0, 0)
        Me.pboxHeader.Name = "pboxHeader"
        Me.pboxHeader.Size = New System.Drawing.Size(1938, 41)
        Me.pboxHeader.TabIndex = 356
        Me.pboxHeader.TabStop = False
        '
        'lvlMaterialToolsList
        '
        Me.lvlMaterialToolsList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader13, Me.ColumnHeader12, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11})
        Me.lvlMaterialToolsList.ContextMenuStrip = Me.cms_materialToolsTurnOver
        Me.lvlMaterialToolsList.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.lvlMaterialToolsList.FullRowSelect = True
        Me.lvlMaterialToolsList.GridLines = True
        Me.lvlMaterialToolsList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvlMaterialToolsList.HideSelection = False
        Me.lvlMaterialToolsList.Location = New System.Drawing.Point(21, 79)
        Me.lvlMaterialToolsList.Name = "lvlMaterialToolsList"
        Me.lvlMaterialToolsList.Size = New System.Drawing.Size(1620, 764)
        Me.lvlMaterialToolsList.TabIndex = 431
        Me.lvlMaterialToolsList.UseCompatibleStateImageBehavior = False
        Me.lvlMaterialToolsList.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ID"
        Me.ColumnHeader1.Width = 0
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Project Code/Name"
        Me.ColumnHeader2.Width = 230
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Type of Material"
        Me.ColumnHeader3.Width = 230
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Quantity"
        Me.ColumnHeader4.Width = 80
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Unit"
        Me.ColumnHeader5.Width = 100
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Condition of Item"
        Me.ColumnHeader6.Width = 150
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Turn-Over Location"
        Me.ColumnHeader7.Width = 180
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "WHS Area"
        Me.ColumnHeader13.Width = 150
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "Spec. Location"
        Me.ColumnHeader12.Width = 180
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Receiver"
        Me.ColumnHeader8.Width = 180
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Turned-Over Date"
        Me.ColumnHeader9.Width = 210
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Remarks"
        Me.ColumnHeader10.Width = 180
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "TypeOfItem"
        Me.ColumnHeader11.Width = 0
        '
        'cms_materialToolsTurnOver
        '
        Me.cms_materialToolsTurnOver.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.cms_materialToolsTurnOver.Name = "cms_materialToolsTurnOver"
        Me.cms_materialToolsTurnOver.Size = New System.Drawing.Size(108, 48)
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
        'lbl_materialTools_ID
        '
        Me.lbl_materialTools_ID.AutoSize = True
        Me.lbl_materialTools_ID.Location = New System.Drawing.Point(1805, 346)
        Me.lbl_materialTools_ID.Name = "lbl_materialTools_ID"
        Me.lbl_materialTools_ID.Size = New System.Drawing.Size(0, 13)
        Me.lbl_materialTools_ID.TabIndex = 436
        '
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.Color.Black
        Me.btnSearch.Location = New System.Drawing.Point(483, 863)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(129, 30)
        Me.btnSearch.TabIndex = 440
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtSearch
        '
        Me.txtSearch.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(252, 865)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(225, 26)
        Me.txtSearch.TabIndex = 439
        '
        'cmbSearchByCategory
        '
        Me.cmbSearchByCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSearchByCategory.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSearchByCategory.FormattingEnabled = True
        Me.cmbSearchByCategory.Items.AddRange(New Object() {"Search by Project Code/Name", "Search by Type of Material", "Search by Receiver", "Search by Spec. Location", "Search by Turned-Over Date"})
        Me.cmbSearchByCategory.Location = New System.Drawing.Point(21, 866)
        Me.cmbSearchByCategory.Name = "cmbSearchByCategory"
        Me.cmbSearchByCategory.Size = New System.Drawing.Size(225, 24)
        Me.cmbSearchByCategory.TabIndex = 438
        '
        'lblSearchByCategory
        '
        Me.lblSearchByCategory.AutoSize = True
        Me.lblSearchByCategory.BackColor = System.Drawing.Color.Transparent
        Me.lblSearchByCategory.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSearchByCategory.ForeColor = System.Drawing.Color.White
        Me.lblSearchByCategory.Location = New System.Drawing.Point(18, 846)
        Me.lblSearchByCategory.Name = "lblSearchByCategory"
        Me.lblSearchByCategory.Size = New System.Drawing.Size(79, 16)
        Me.lblSearchByCategory.TabIndex = 437
        Me.lblSearchByCategory.Text = "Search By"
        '
        'DTP_search
        '
        Me.DTP_search.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_search.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_search.Location = New System.Drawing.Point(1033, 1051)
        Me.DTP_search.Name = "DTP_search"
        Me.DTP_search.Size = New System.Drawing.Size(286, 26)
        Me.DTP_search.TabIndex = 441
        Me.DTP_search.Visible = False
        '
        'btn_inputField
        '
        Me.btn_inputField.Location = New System.Drawing.Point(21, 47)
        Me.btn_inputField.Name = "btn_inputField"
        Me.btn_inputField.Size = New System.Drawing.Size(163, 26)
        Me.btn_inputField.TabIndex = 400
        Me.btn_inputField.Text = "Show input Fields"
        Me.btn_inputField.UseVisualStyleBackColor = True
        '
        'ListJobOrderNo
        '
        Me.ListJobOrderNo.FormattingEnabled = True
        Me.ListJobOrderNo.Location = New System.Drawing.Point(1761, 220)
        Me.ListJobOrderNo.Name = "ListJobOrderNo"
        Me.ListJobOrderNo.Size = New System.Drawing.Size(163, 56)
        Me.ListJobOrderNo.TabIndex = 442
        '
        'lbl_matID
        '
        Me.lbl_matID.AutoSize = True
        Me.lbl_matID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_matID.Location = New System.Drawing.Point(1875, 294)
        Me.lbl_matID.Name = "lbl_matID"
        Me.lbl_matID.Size = New System.Drawing.Size(49, 16)
        Me.lbl_matID.TabIndex = 443
        Me.lbl_matID.Text = "Label1"
        '
        'FMaterials_ToolsTurnOverReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SUPPLY.My.Resources.Resources.bg_line
        Me.ClientSize = New System.Drawing.Size(1664, 907)
        Me.Controls.Add(Me.ListJobOrderNo)
        Me.Controls.Add(Me.btn_inputField)
        Me.Controls.Add(Me.cmbSearchByCategory)
        Me.Controls.Add(Me.DTP_search)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.lblSearchByCategory)
        Me.Controls.Add(Me.lbl_materialTools_ID)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.lvlMaterialToolsList)
        Me.Controls.Add(Me.lbl_matID)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.pboxHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FMaterials_ToolsTurnOverReport"
        Me.Text = "FMaterials_ToolsTurnOverReport"
        CType(Me.pboxHeader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cms_materialToolsTurnOver.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents pboxHeader As System.Windows.Forms.PictureBox
    Friend WithEvents lvlMaterialToolsList As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents cms_materialToolsTurnOver As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lbl_materialTools_ID As System.Windows.Forms.Label
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents cmbSearchByCategory As System.Windows.Forms.ComboBox
    Friend WithEvents lblSearchByCategory As System.Windows.Forms.Label
    Friend WithEvents DTP_search As System.Windows.Forms.DateTimePicker
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btn_inputField As System.Windows.Forms.Button
    Friend WithEvents ListJobOrderNo As System.Windows.Forms.ListBox
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lbl_matID As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
End Class
