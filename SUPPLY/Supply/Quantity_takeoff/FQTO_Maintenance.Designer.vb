<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FQTO_Maintenance
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
        Me.txtQTO_itemdesc = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtQTO_itemname = New System.Windows.Forms.TextBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.lvlQTOList = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CMS_QTO = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtUnit = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GBSelectExSheet = New System.Windows.Forms.GroupBox()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.ListSheets = New System.Windows.Forms.ListBox()
        Me.btnImport = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.txtMaterials = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbSearchBy = New System.Windows.Forms.ComboBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.CMS_QTO.SuspendLayout()
        Me.GBSelectExSheet.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtQTO_itemdesc
        '
        Me.txtQTO_itemdesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQTO_itemdesc.Location = New System.Drawing.Point(90, 59)
        Me.txtQTO_itemdesc.Name = "txtQTO_itemdesc"
        Me.txtQTO_itemdesc.Size = New System.Drawing.Size(253, 22)
        Me.txtQTO_itemdesc.TabIndex = 471
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(8, 62)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(81, 16)
        Me.Label7.TabIndex = 473
        Me.Label7.Text = "Item Desc:"
        '
        'txtQTO_itemname
        '
        Me.txtQTO_itemname.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQTO_itemname.Location = New System.Drawing.Point(441, 23)
        Me.txtQTO_itemname.Name = "txtQTO_itemname"
        Me.txtQTO_itemname.Size = New System.Drawing.Size(259, 22)
        Me.txtQTO_itemname.TabIndex = 470
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(12, 548)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(541, 34)
        Me.btnSave.TabIndex = 474
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'lvlQTOList
        '
        Me.lvlQTOList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5})
        Me.lvlQTOList.ContextMenuStrip = Me.CMS_QTO
        Me.lvlQTOList.FullRowSelect = True
        Me.lvlQTOList.HideSelection = False
        Me.lvlQTOList.Location = New System.Drawing.Point(12, 131)
        Me.lvlQTOList.Name = "lvlQTOList"
        Me.lvlQTOList.Size = New System.Drawing.Size(709, 363)
        Me.lvlQTOList.TabIndex = 475
        Me.lvlQTOList.UseCompatibleStateImageBehavior = False
        Me.lvlQTOList.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "id"
        Me.ColumnHeader1.Width = 0
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.DisplayIndex = 2
        Me.ColumnHeader2.Text = "Item Name"
        Me.ColumnHeader2.Width = 205
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.DisplayIndex = 3
        Me.ColumnHeader3.Text = "Description"
        Me.ColumnHeader3.Width = 243
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.DisplayIndex = 4
        Me.ColumnHeader4.Text = "unit(s)"
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.DisplayIndex = 1
        Me.ColumnHeader5.Text = "Materials"
        Me.ColumnHeader5.Width = 195
        '
        'CMS_QTO
        '
        Me.CMS_QTO.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.CMS_QTO.Name = "CMS_QTO"
        Me.CMS_QTO.Size = New System.Drawing.Size(108, 48)
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
        'txtUnit
        '
        Me.txtUnit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUnit.Location = New System.Drawing.Point(441, 60)
        Me.txtUnit.Name = "txtUnit"
        Me.txtUnit.Size = New System.Drawing.Size(259, 22)
        Me.txtUnit.TabIndex = 476
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(403, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 16)
        Me.Label1.TabIndex = 477
        Me.Label1.Text = "Unit"
        '
        'GBSelectExSheet
        '
        Me.GBSelectExSheet.Controls.Add(Me.btnExit)
        Me.GBSelectExSheet.Controls.Add(Me.ListSheets)
        Me.GBSelectExSheet.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.GBSelectExSheet.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBSelectExSheet.ForeColor = System.Drawing.Color.SlateGray
        Me.GBSelectExSheet.Location = New System.Drawing.Point(249, 197)
        Me.GBSelectExSheet.Name = "GBSelectExSheet"
        Me.GBSelectExSheet.Size = New System.Drawing.Size(239, 242)
        Me.GBSelectExSheet.TabIndex = 479
        Me.GBSelectExSheet.TabStop = False
        Me.GBSelectExSheet.Text = "Select Excel Sheets"
        Me.GBSelectExSheet.Visible = False
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.Transparent
        Me.btnExit.BackgroundImage = Global.SUPPLY.My.Resources.Resources.close_button
        Me.btnExit.FlatAppearance.BorderSize = 0
        Me.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit.Location = New System.Drawing.Point(213, 4)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(22, 22)
        Me.btnExit.TabIndex = 108
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'ListSheets
        '
        Me.ListSheets.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListSheets.ForeColor = System.Drawing.Color.Red
        Me.ListSheets.FormattingEnabled = True
        Me.ListSheets.ItemHeight = 22
        Me.ListSheets.Location = New System.Drawing.Point(5, 32)
        Me.ListSheets.Name = "ListSheets"
        Me.ListSheets.Size = New System.Drawing.Size(228, 202)
        Me.ListSheets.TabIndex = 0
        '
        'btnImport
        '
        Me.btnImport.Location = New System.Drawing.Point(559, 549)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(162, 33)
        Me.btnImport.TabIndex = 480
        Me.btnImport.Text = "Import"
        Me.btnImport.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'txtMaterials
        '
        Me.txtMaterials.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMaterials.Location = New System.Drawing.Point(90, 23)
        Me.txtMaterials.Name = "txtMaterials"
        Me.txtMaterials.Size = New System.Drawing.Size(253, 22)
        Me.txtMaterials.TabIndex = 481
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(8, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 16)
        Me.Label2.TabIndex = 482
        Me.Label2.Text = "Materials:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(352, 26)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(86, 16)
        Me.Label6.TabIndex = 472
        Me.Label6.Text = "Item Name:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtQTO_itemdesc)
        Me.GroupBox1.Controls.Add(Me.txtMaterials)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtQTO_itemname)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtUnit)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 32)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(709, 100)
        Me.GroupBox1.TabIndex = 483
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "QTY TAKE OFF ITEM SPECIFICATION"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkOrange
        Me.Label3.Location = New System.Drawing.Point(12, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(212, 15)
        Me.Label3.TabIndex = 484
        Me.Label3.Text = "Press escape to cancel saving/update"
        Me.Label3.Visible = False
        '
        'txtSearch
        '
        Me.txtSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(274, 511)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(279, 22)
        Me.txtSearch.TabIndex = 485
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(13, 513)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 16)
        Me.Label4.TabIndex = 486
        Me.Label4.Text = "Search by:"
        '
        'cmbSearchBy
        '
        Me.cmbSearchBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSearchBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSearchBy.FormattingEnabled = True
        Me.cmbSearchBy.Items.AddRange(New Object() {"MATERIALS", "ITEM NAME", "ITEM DESCRIPTION"})
        Me.cmbSearchBy.Location = New System.Drawing.Point(100, 510)
        Me.cmbSearchBy.Name = "cmbSearchBy"
        Me.cmbSearchBy.Size = New System.Drawing.Size(168, 24)
        Me.cmbSearchBy.TabIndex = 487
        '
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(559, 510)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(162, 23)
        Me.btnSearch.TabIndex = 488
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'FQTO_Maintenance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(733, 592)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.cmbSearchBy)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GBSelectExSheet)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnImport)
        Me.Controls.Add(Me.lvlQTOList)
        Me.Controls.Add(Me.GroupBox1)
        Me.KeyPreview = True
        Me.Name = "FQTO_Maintenance"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FQTO_Maintenance"
        Me.CMS_QTO.ResumeLayout(False)
        Me.GBSelectExSheet.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtQTO_itemdesc As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtQTO_itemname As TextBox
    Friend WithEvents btnSave As Button
    Friend WithEvents lvlQTOList As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents txtUnit As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents CMS_QTO As ContextMenuStrip
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GBSelectExSheet As GroupBox
    Friend WithEvents btnExit As Button
    Friend WithEvents ListSheets As ListBox
    Friend WithEvents btnImport As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents txtMaterials As TextBox
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents Label2 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbSearchBy As ComboBox
    Friend WithEvents btnSearch As Button
End Class
