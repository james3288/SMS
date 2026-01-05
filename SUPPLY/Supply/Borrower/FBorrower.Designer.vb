<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FBorrower
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FBorrower))
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.pboxHeader = New System.Windows.Forms.PictureBox()
        Me.PanelFAC = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbFacToolsType = New System.Windows.Forms.ComboBox()
        Me.fac_btnClose = New System.Windows.Forms.Button()
        Me.FAC_btnSave = New System.Windows.Forms.Button()
        Me.FAC_listview = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CMS_FAC_listview = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FAC_txtfac_name = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PanelBrand = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbFacToolsType1 = New System.Windows.Forms.ComboBox()
        Me.brand_btnClose = New System.Windows.Forms.Button()
        Me.Brand_cmbfac_name = New System.Windows.Forms.ComboBox()
        Me.brand_btnSave = New System.Windows.Forms.Button()
        Me.Brand_Listview = New System.Windows.Forms.ListView()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CMS_Brand_Listview = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.brand_txtBrand = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnAddFacName = New System.Windows.Forms.Button()
        Me.btnAddBrand = New System.Windows.Forms.Button()
        CType(Me.pboxHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelFAC.SuspendLayout()
        Me.CMS_FAC_listview.SuspendLayout()
        Me.PanelBrand.SuspendLayout()
        Me.CMS_Brand_Listview.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(11, 8)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(129, 22)
        Me.Label7.TabIndex = 416
        Me.Label7.Text = "Borrower Form"
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.Transparent
        Me.btnExit.BackgroundImage = CType(resources.GetObject("btnExit.BackgroundImage"), System.Drawing.Image)
        Me.btnExit.FlatAppearance.BorderSize = 0
        Me.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit.Location = New System.Drawing.Point(404, 12)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(20, 20)
        Me.btnExit.TabIndex = 415
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'pboxHeader
        '
        Me.pboxHeader.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.pboxHeader.BackgroundImage = CType(resources.GetObject("pboxHeader.BackgroundImage"), System.Drawing.Image)
        Me.pboxHeader.InitialImage = Nothing
        Me.pboxHeader.Location = New System.Drawing.Point(0, -3)
        Me.pboxHeader.Name = "pboxHeader"
        Me.pboxHeader.Size = New System.Drawing.Size(466, 41)
        Me.pboxHeader.TabIndex = 414
        Me.pboxHeader.TabStop = False
        '
        'PanelFAC
        '
        Me.PanelFAC.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.PanelFAC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelFAC.Controls.Add(Me.Label4)
        Me.PanelFAC.Controls.Add(Me.cmbFacToolsType)
        Me.PanelFAC.Controls.Add(Me.fac_btnClose)
        Me.PanelFAC.Controls.Add(Me.FAC_btnSave)
        Me.PanelFAC.Controls.Add(Me.FAC_listview)
        Me.PanelFAC.Controls.Add(Me.FAC_txtfac_name)
        Me.PanelFAC.Controls.Add(Me.Label1)
        Me.PanelFAC.Location = New System.Drawing.Point(8, 75)
        Me.PanelFAC.Name = "PanelFAC"
        Me.PanelFAC.Size = New System.Drawing.Size(421, 366)
        Me.PanelFAC.TabIndex = 417
        Me.PanelFAC.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 16)
        Me.Label4.TabIndex = 396
        Me.Label4.Text = "Types"
        '
        'cmbFacToolsType
        '
        Me.cmbFacToolsType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFacToolsType.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFacToolsType.FormattingEnabled = True
        Me.cmbFacToolsType.Items.AddRange(New Object() {"FACILITIES", "TOOLS", "ADD-ON"})
        Me.cmbFacToolsType.Location = New System.Drawing.Point(10, 34)
        Me.cmbFacToolsType.Name = "cmbFacToolsType"
        Me.cmbFacToolsType.Size = New System.Drawing.Size(275, 28)
        Me.cmbFacToolsType.TabIndex = 395
        '
        'fac_btnClose
        '
        Me.fac_btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fac_btnClose.Location = New System.Drawing.Point(395, 3)
        Me.fac_btnClose.Name = "fac_btnClose"
        Me.fac_btnClose.Size = New System.Drawing.Size(21, 24)
        Me.fac_btnClose.TabIndex = 394
        Me.fac_btnClose.Text = "x"
        Me.fac_btnClose.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.fac_btnClose.UseVisualStyleBackColor = True
        '
        'FAC_btnSave
        '
        Me.FAC_btnSave.Location = New System.Drawing.Point(290, 326)
        Me.FAC_btnSave.Name = "FAC_btnSave"
        Me.FAC_btnSave.Size = New System.Drawing.Size(100, 29)
        Me.FAC_btnSave.TabIndex = 3
        Me.FAC_btnSave.Text = "Save"
        Me.FAC_btnSave.UseVisualStyleBackColor = True
        '
        'FAC_listview
        '
        Me.FAC_listview.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader6})
        Me.FAC_listview.ContextMenuStrip = Me.CMS_FAC_listview
        Me.FAC_listview.FullRowSelect = True
        Me.FAC_listview.GridLines = True
        Me.FAC_listview.HideSelection = False
        Me.FAC_listview.Location = New System.Drawing.Point(10, 119)
        Me.FAC_listview.Name = "FAC_listview"
        Me.FAC_listview.Size = New System.Drawing.Size(380, 201)
        Me.FAC_listview.TabIndex = 2
        Me.FAC_listview.UseCompatibleStateImageBehavior = False
        Me.FAC_listview.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "fac_id"
        Me.ColumnHeader1.Width = 0
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Facilities Name"
        Me.ColumnHeader2.Width = 221
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Types"
        Me.ColumnHeader6.Width = 154
        '
        'CMS_FAC_listview
        '
        Me.CMS_FAC_listview.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.CMS_FAC_listview.Name = "CMS_FAC_listview"
        Me.CMS_FAC_listview.Size = New System.Drawing.Size(108, 48)
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
        'FAC_txtfac_name
        '
        Me.FAC_txtfac_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FAC_txtfac_name.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FAC_txtfac_name.Location = New System.Drawing.Point(10, 84)
        Me.FAC_txtfac_name.Name = "FAC_txtfac_name"
        Me.FAC_txtfac_name.Size = New System.Drawing.Size(277, 26)
        Me.FAC_txtfac_name.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 65)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Falicities Name"
        '
        'PanelBrand
        '
        Me.PanelBrand.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.PanelBrand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelBrand.Controls.Add(Me.Label5)
        Me.PanelBrand.Controls.Add(Me.cmbFacToolsType1)
        Me.PanelBrand.Controls.Add(Me.brand_btnClose)
        Me.PanelBrand.Controls.Add(Me.Brand_cmbfac_name)
        Me.PanelBrand.Controls.Add(Me.brand_btnSave)
        Me.PanelBrand.Controls.Add(Me.Brand_Listview)
        Me.PanelBrand.Controls.Add(Me.brand_txtBrand)
        Me.PanelBrand.Controls.Add(Me.Label3)
        Me.PanelBrand.Controls.Add(Me.Label2)
        Me.PanelBrand.Location = New System.Drawing.Point(8, 75)
        Me.PanelBrand.Name = "PanelBrand"
        Me.PanelBrand.Size = New System.Drawing.Size(421, 404)
        Me.PanelBrand.TabIndex = 418
        Me.PanelBrand.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(8, 4)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 16)
        Me.Label5.TabIndex = 398
        Me.Label5.Text = "Types"
        '
        'cmbFacToolsType1
        '
        Me.cmbFacToolsType1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFacToolsType1.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFacToolsType1.FormattingEnabled = True
        Me.cmbFacToolsType1.Items.AddRange(New Object() {"FACILITIES", "TOOLS", "ADD-ON"})
        Me.cmbFacToolsType1.Location = New System.Drawing.Point(10, 22)
        Me.cmbFacToolsType1.Name = "cmbFacToolsType1"
        Me.cmbFacToolsType1.Size = New System.Drawing.Size(275, 28)
        Me.cmbFacToolsType1.TabIndex = 397
        '
        'brand_btnClose
        '
        Me.brand_btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.brand_btnClose.Location = New System.Drawing.Point(395, 3)
        Me.brand_btnClose.Name = "brand_btnClose"
        Me.brand_btnClose.Size = New System.Drawing.Size(21, 24)
        Me.brand_btnClose.TabIndex = 395
        Me.brand_btnClose.Text = "x"
        Me.brand_btnClose.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.brand_btnClose.UseVisualStyleBackColor = True
        '
        'Brand_cmbfac_name
        '
        Me.Brand_cmbfac_name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Brand_cmbfac_name.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Brand_cmbfac_name.FormattingEnabled = True
        Me.Brand_cmbfac_name.Location = New System.Drawing.Point(11, 72)
        Me.Brand_cmbfac_name.Name = "Brand_cmbfac_name"
        Me.Brand_cmbfac_name.Size = New System.Drawing.Size(275, 28)
        Me.Brand_cmbfac_name.TabIndex = 5
        '
        'brand_btnSave
        '
        Me.brand_btnSave.Location = New System.Drawing.Point(305, 364)
        Me.brand_btnSave.Name = "brand_btnSave"
        Me.brand_btnSave.Size = New System.Drawing.Size(101, 29)
        Me.brand_btnSave.TabIndex = 3
        Me.brand_btnSave.Text = "Save"
        Me.brand_btnSave.UseVisualStyleBackColor = True
        '
        'Brand_Listview
        '
        Me.Brand_Listview.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5})
        Me.Brand_Listview.ContextMenuStrip = Me.CMS_Brand_Listview
        Me.Brand_Listview.FullRowSelect = True
        Me.Brand_Listview.GridLines = True
        Me.Brand_Listview.HideSelection = False
        Me.Brand_Listview.Location = New System.Drawing.Point(12, 156)
        Me.Brand_Listview.Name = "Brand_Listview"
        Me.Brand_Listview.Size = New System.Drawing.Size(394, 201)
        Me.Brand_Listview.TabIndex = 2
        Me.Brand_Listview.UseCompatibleStateImageBehavior = False
        Me.Brand_Listview.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "fac_id"
        Me.ColumnHeader3.Width = 0
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Facilities Name"
        Me.ColumnHeader4.Width = 171
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Brand"
        Me.ColumnHeader5.Width = 250
        '
        'CMS_Brand_Listview
        '
        Me.CMS_Brand_Listview.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditToolStripMenuItem1, Me.DeleteToolStripMenuItem1})
        Me.CMS_Brand_Listview.Name = "CMS_Brand_Listview"
        Me.CMS_Brand_Listview.Size = New System.Drawing.Size(108, 48)
        '
        'EditToolStripMenuItem1
        '
        Me.EditToolStripMenuItem1.Name = "EditToolStripMenuItem1"
        Me.EditToolStripMenuItem1.Size = New System.Drawing.Size(107, 22)
        Me.EditToolStripMenuItem1.Text = "Edit"
        '
        'DeleteToolStripMenuItem1
        '
        Me.DeleteToolStripMenuItem1.Name = "DeleteToolStripMenuItem1"
        Me.DeleteToolStripMenuItem1.Size = New System.Drawing.Size(107, 22)
        Me.DeleteToolStripMenuItem1.Text = "Delete"
        '
        'brand_txtBrand
        '
        Me.brand_txtBrand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.brand_txtBrand.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.brand_txtBrand.Location = New System.Drawing.Point(10, 121)
        Me.brand_txtBrand.Name = "brand_txtBrand"
        Me.brand_txtBrand.Size = New System.Drawing.Size(277, 26)
        Me.brand_txtBrand.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(106, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Falicities Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 103)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Brand"
        '
        'btnAddFacName
        '
        Me.btnAddFacName.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddFacName.Location = New System.Drawing.Point(8, 43)
        Me.btnAddFacName.Name = "btnAddFacName"
        Me.btnAddFacName.Size = New System.Drawing.Size(132, 26)
        Me.btnAddFacName.TabIndex = 419
        Me.btnAddFacName.Text = "Add Facility Name"
        Me.btnAddFacName.UseVisualStyleBackColor = True
        '
        'btnAddBrand
        '
        Me.btnAddBrand.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddBrand.Location = New System.Drawing.Point(143, 43)
        Me.btnAddBrand.Name = "btnAddBrand"
        Me.btnAddBrand.Size = New System.Drawing.Size(132, 26)
        Me.btnAddBrand.TabIndex = 420
        Me.btnAddBrand.Text = "Add Brand"
        Me.btnAddBrand.UseVisualStyleBackColor = True
        '
        'FBorrower
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SUPPLY.My.Resources.Resources.line_div
        Me.ClientSize = New System.Drawing.Size(439, 487)
        Me.Controls.Add(Me.btnAddFacName)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnAddBrand)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.PanelBrand)
        Me.Controls.Add(Me.PanelFAC)
        Me.Controls.Add(Me.pboxHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "FBorrower"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FBorrower"
        CType(Me.pboxHeader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelFAC.ResumeLayout(False)
        Me.PanelFAC.PerformLayout()
        Me.CMS_FAC_listview.ResumeLayout(False)
        Me.PanelBrand.ResumeLayout(False)
        Me.PanelBrand.PerformLayout()
        Me.CMS_Brand_Listview.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents pboxHeader As System.Windows.Forms.PictureBox
    Friend WithEvents PanelFAC As System.Windows.Forms.Panel
    Friend WithEvents FAC_btnSave As System.Windows.Forms.Button
    Friend WithEvents FAC_listview As System.Windows.Forms.ListView
    Friend WithEvents FAC_txtfac_name As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents PanelBrand As System.Windows.Forms.Panel
    Friend WithEvents Brand_cmbfac_name As System.Windows.Forms.ComboBox
    Friend WithEvents brand_btnSave As System.Windows.Forms.Button
    Friend WithEvents Brand_Listview As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents brand_txtBrand As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnAddFacName As System.Windows.Forms.Button
    Friend WithEvents btnAddBrand As System.Windows.Forms.Button
    Friend WithEvents fac_btnClose As System.Windows.Forms.Button
    Friend WithEvents brand_btnClose As System.Windows.Forms.Button
    Friend WithEvents CMS_FAC_listview As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CMS_Brand_Listview As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbFacToolsType As System.Windows.Forms.ComboBox
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbFacToolsType1 As System.Windows.Forms.ComboBox
End Class
