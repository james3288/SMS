<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FAddSupplier
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
        Me.Panel_Supplier = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtTerms = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btn_Update = New System.Windows.Forms.Button()
        Me.txt_SupplierLocation = New System.Windows.Forms.TextBox()
        Me.lbl_SupplierLocation = New System.Windows.Forms.Label()
        Me.lbl_SupplierName = New System.Windows.Forms.Label()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.txt_SupplierName = New System.Windows.Forms.TextBox()
        Me.lvList = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CMS_lvList = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel_Supplier.SuspendLayout()
        Me.CMS_lvList.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel_Supplier
        '
        Me.Panel_Supplier.BackgroundImage = Global.SUPPLY.My.Resources.Resources.bg_line
        Me.Panel_Supplier.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel_Supplier.Controls.Add(Me.Label6)
        Me.Panel_Supplier.Controls.Add(Me.ComboBox2)
        Me.Panel_Supplier.Controls.Add(Me.Label5)
        Me.Panel_Supplier.Controls.Add(Me.TextBox2)
        Me.Panel_Supplier.Controls.Add(Me.Button1)
        Me.Panel_Supplier.Controls.Add(Me.TextBox1)
        Me.Panel_Supplier.Controls.Add(Me.ComboBox1)
        Me.Panel_Supplier.Controls.Add(Me.Label4)
        Me.Panel_Supplier.Controls.Add(Me.txtTerms)
        Me.Panel_Supplier.Controls.Add(Me.Label1)
        Me.Panel_Supplier.Controls.Add(Me.Label13)
        Me.Panel_Supplier.Controls.Add(Me.btn_Update)
        Me.Panel_Supplier.Controls.Add(Me.txt_SupplierLocation)
        Me.Panel_Supplier.Controls.Add(Me.lbl_SupplierLocation)
        Me.Panel_Supplier.Controls.Add(Me.lbl_SupplierName)
        Me.Panel_Supplier.Controls.Add(Me.btnAdd)
        Me.Panel_Supplier.Controls.Add(Me.txt_SupplierName)
        Me.Panel_Supplier.Controls.Add(Me.lvList)
        Me.Panel_Supplier.Location = New System.Drawing.Point(3, 3)
        Me.Panel_Supplier.Name = "Panel_Supplier"
        Me.Panel_Supplier.Size = New System.Drawing.Size(471, 627)
        Me.Panel_Supplier.TabIndex = 424
        Me.Panel_Supplier.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(23, 517)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(125, 17)
        Me.Label6.TabIndex = 401
        Me.Label6.Text = "Vat Percentage:"
        '
        'ComboBox2
        '
        Me.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox2.Enabled = False
        Me.ComboBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Items.AddRange(New Object() {"VAT (Value Added Tax)", "EWT (Expanded Withholding Tax)"})
        Me.ComboBox2.Location = New System.Drawing.Point(150, 482)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(307, 24)
        Me.ComboBox2.TabIndex = 400
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(41, 484)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(107, 17)
        Me.Label5.TabIndex = 399
        Me.Label5.Text = "Vat Category:"
        '
        'TextBox2
        '
        Me.TextBox2.Enabled = False
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(150, 514)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(307, 23)
        Me.TextBox2.TabIndex = 398
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(378, 344)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(84, 29)
        Me.Button1.TabIndex = 397
        Me.Button1.Text = "Search"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(150, 347)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(222, 23)
        Me.TextBox1.TabIndex = 396
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Supplier Name", "Supplier Location", "Terms"})
        Me.ComboBox1.Location = New System.Drawing.Point(5, 346)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(139, 24)
        Me.ComboBox1.TabIndex = 395
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(3, 326)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 17)
        Me.Label4.TabIndex = 394
        Me.Label4.Text = "Search by:"
        '
        'txtTerms
        '
        Me.txtTerms.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTerms.Location = New System.Drawing.Point(150, 452)
        Me.txtTerms.Name = "txtTerms"
        Me.txtTerms.Size = New System.Drawing.Size(307, 23)
        Me.txtTerms.TabIndex = 392
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(90, 455)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 17)
        Me.Label1.TabIndex = 393
        Me.Label1.Text = "Terms:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(16, 26)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(209, 13)
        Me.Label13.TabIndex = 391
        Me.Label13.Text = "Note: Double Click on list to select an item."
        '
        'btn_Update
        '
        Me.btn_Update.Enabled = False
        Me.btn_Update.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Update.Location = New System.Drawing.Point(314, 544)
        Me.btn_Update.Name = "btn_Update"
        Me.btn_Update.Size = New System.Drawing.Size(143, 36)
        Me.btn_Update.TabIndex = 4
        Me.btn_Update.Text = "Update"
        Me.btn_Update.UseVisualStyleBackColor = True
        '
        'txt_SupplierLocation
        '
        Me.txt_SupplierLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_SupplierLocation.Location = New System.Drawing.Point(150, 423)
        Me.txt_SupplierLocation.Name = "txt_SupplierLocation"
        Me.txt_SupplierLocation.Size = New System.Drawing.Size(307, 23)
        Me.txt_SupplierLocation.TabIndex = 2
        '
        'lbl_SupplierLocation
        '
        Me.lbl_SupplierLocation.AutoSize = True
        Me.lbl_SupplierLocation.BackColor = System.Drawing.Color.Transparent
        Me.lbl_SupplierLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_SupplierLocation.ForeColor = System.Drawing.Color.White
        Me.lbl_SupplierLocation.Location = New System.Drawing.Point(8, 426)
        Me.lbl_SupplierLocation.Name = "lbl_SupplierLocation"
        Me.lbl_SupplierLocation.Size = New System.Drawing.Size(140, 17)
        Me.lbl_SupplierLocation.TabIndex = 390
        Me.lbl_SupplierLocation.Text = "Supplier Location:"
        '
        'lbl_SupplierName
        '
        Me.lbl_SupplierName.AutoSize = True
        Me.lbl_SupplierName.BackColor = System.Drawing.Color.Transparent
        Me.lbl_SupplierName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_SupplierName.ForeColor = System.Drawing.Color.White
        Me.lbl_SupplierName.Location = New System.Drawing.Point(29, 397)
        Me.lbl_SupplierName.Name = "lbl_SupplierName"
        Me.lbl_SupplierName.Size = New System.Drawing.Size(119, 17)
        Me.lbl_SupplierName.TabIndex = 389
        Me.lbl_SupplierName.Text = "Supplier Name:"
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(150, 544)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(158, 36)
        Me.btnAdd.TabIndex = 3
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'txt_SupplierName
        '
        Me.txt_SupplierName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_SupplierName.Location = New System.Drawing.Point(150, 394)
        Me.txt_SupplierName.Name = "txt_SupplierName"
        Me.txt_SupplierName.Size = New System.Drawing.Size(307, 23)
        Me.txt_SupplierName.TabIndex = 0
        '
        'lvList
        '
        Me.lvList.BackColor = System.Drawing.SystemColors.Window
        Me.lvList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.lvList.ContextMenuStrip = Me.CMS_lvList
        Me.lvList.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvList.FullRowSelect = True
        Me.lvList.GridLines = True
        Me.lvList.HideSelection = False
        Me.lvList.Location = New System.Drawing.Point(5, 48)
        Me.lvList.Name = "lvList"
        Me.lvList.Size = New System.Drawing.Size(457, 271)
        Me.lvList.TabIndex = 7
        Me.lvList.UseCompatibleStateImageBehavior = False
        Me.lvList.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Supplier Id"
        Me.ColumnHeader1.Width = 0
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Supplier Name"
        Me.ColumnHeader2.Width = 170
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Supplier Location"
        Me.ColumnHeader3.Width = 290
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Terms"
        Me.ColumnHeader4.Width = 200
        '
        'CMS_lvList
        '
        Me.CMS_lvList.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.CMS_lvList.Name = "ContextMenuStrip1"
        Me.CMS_lvList.Size = New System.Drawing.Size(107, 48)
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(106, 22)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(106, 22)
        Me.DeleteToolStripMenuItem.Text = "delete"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(609, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 425
        Me.Label2.Text = "Label2"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(609, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 426
        Me.Label3.Text = "Label3"
        '
        'FAddSupplier
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(473, 620)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel_Supplier)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FAddSupplier"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FAddSupplier"
        Me.Panel_Supplier.ResumeLayout(False)
        Me.Panel_Supplier.PerformLayout()
        Me.CMS_lvList.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel_Supplier As System.Windows.Forms.Panel
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btn_Update As System.Windows.Forms.Button
    Friend WithEvents txt_SupplierLocation As System.Windows.Forms.TextBox
    Friend WithEvents lbl_SupplierLocation As System.Windows.Forms.Label
    Friend WithEvents lbl_SupplierName As System.Windows.Forms.Label
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents txt_SupplierName As System.Windows.Forms.TextBox
    Friend WithEvents lvList As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents CMS_lvList As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtTerms As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents Label5 As Label
End Class
