<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FBorrower_Turnover_Items
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbox_return_details = New System.Windows.Forms.ListBox()
        Me.txtNotedBy = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.list_ReturnTo = New System.Windows.Forms.ListBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.list_returnFrom = New System.Windows.Forms.ListBox()
        Me.CMS_remove = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RemoveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtturnoverby = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dtpDateNoted = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtpdateturnover = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtReceiver = New System.Windows.Forms.TextBox()
        Me.btnAddTempCustodian = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbChargesDesc = New System.Windows.Forms.ComboBox()
        Me.cmbReturnType = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbChargesType = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Column6 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.CMS_remove.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.67965!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1286, 738)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 317.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.DataGridView1, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1280, 732)
        Me.TableLayoutPanel2.TabIndex = 3
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lbox_return_details)
        Me.Panel1.Controls.Add(Me.txtNotedBy)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.list_ReturnTo)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.list_returnFrom)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtturnoverby)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.dtpDateNoted)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.dtpdateturnover)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.txtReceiver)
        Me.Panel1.Controls.Add(Me.btnAddTempCustodian)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.cmbChargesDesc)
        Me.Panel1.Controls.Add(Me.cmbReturnType)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.cmbChargesType)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(311, 726)
        Me.Panel1.TabIndex = 2
        '
        'lbox_return_details
        '
        Me.lbox_return_details.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lbox_return_details.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbox_return_details.FormattingEnabled = True
        Me.lbox_return_details.ItemHeight = 15
        Me.lbox_return_details.Location = New System.Drawing.Point(10, 659)
        Me.lbox_return_details.Name = "lbox_return_details"
        Me.lbox_return_details.Size = New System.Drawing.Size(263, 64)
        Me.lbox_return_details.TabIndex = 542
        Me.lbox_return_details.Visible = False
        '
        'txtNotedBy
        '
        Me.txtNotedBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNotedBy.Location = New System.Drawing.Point(9, 504)
        Me.txtNotedBy.Name = "txtNotedBy"
        Me.txtNotedBy.Size = New System.Drawing.Size(300, 24)
        Me.txtNotedBy.TabIndex = 540
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(7, 486)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(60, 15)
        Me.Label10.TabIndex = 541
        Me.Label10.Text = "Noted By:"
        '
        'list_ReturnTo
        '
        Me.list_ReturnTo.ContextMenuStrip = Me.CMS_remove
        Me.list_ReturnTo.FormattingEnabled = True
        Me.list_ReturnTo.Location = New System.Drawing.Point(6, 240)
        Me.list_ReturnTo.Name = "list_ReturnTo"
        Me.list_ReturnTo.Size = New System.Drawing.Size(301, 56)
        Me.list_ReturnTo.TabIndex = 539
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(9, 545)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(300, 36)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Return Now"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'list_returnFrom
        '
        Me.list_returnFrom.ContextMenuStrip = Me.CMS_remove
        Me.list_returnFrom.FormattingEnabled = True
        Me.list_returnFrom.Location = New System.Drawing.Point(5, 164)
        Me.list_returnFrom.Name = "list_returnFrom"
        Me.list_returnFrom.Size = New System.Drawing.Size(301, 56)
        Me.list_returnFrom.TabIndex = 538
        '
        'CMS_remove
        '
        Me.CMS_remove.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RemoveToolStripMenuItem})
        Me.CMS_remove.Name = "CMS_remove"
        Me.CMS_remove.Size = New System.Drawing.Size(118, 26)
        '
        'RemoveToolStripMenuItem
        '
        Me.RemoveToolStripMenuItem.Name = "RemoveToolStripMenuItem"
        Me.RemoveToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.RemoveToolStripMenuItem.Text = "Remove"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(3, 223)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 14)
        Me.Label4.TabIndex = 537
        Me.Label4.Text = "Return To:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(3, 148)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 14)
        Me.Label3.TabIndex = 535
        Me.Label3.Text = "Return From:"
        '
        'txtturnoverby
        '
        Me.txtturnoverby.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtturnoverby.Location = New System.Drawing.Point(8, 411)
        Me.txtturnoverby.Name = "txtturnoverby"
        Me.txtturnoverby.Size = New System.Drawing.Size(300, 24)
        Me.txtturnoverby.TabIndex = 529
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(5, 394)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(76, 15)
        Me.Label9.TabIndex = 534
        Me.Label9.Text = "Turnover by:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(6, 441)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 15)
        Me.Label8.TabIndex = 533
        Me.Label8.Text = "Date Noted:"
        '
        'dtpDateNoted
        '
        Me.dtpDateNoted.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDateNoted.Location = New System.Drawing.Point(8, 458)
        Me.dtpDateNoted.Name = "dtpDateNoted"
        Me.dtpDateNoted.Size = New System.Drawing.Size(300, 22)
        Me.dtpDateNoted.TabIndex = 530
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(5, 346)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(86, 15)
        Me.Label7.TabIndex = 532
        Me.Label7.Text = "Date Turnover"
        '
        'dtpdateturnover
        '
        Me.dtpdateturnover.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpdateturnover.Location = New System.Drawing.Point(8, 363)
        Me.dtpdateturnover.Name = "dtpdateturnover"
        Me.dtpdateturnover.Size = New System.Drawing.Size(300, 22)
        Me.dtpdateturnover.TabIndex = 528
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(6, 301)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 15)
        Me.Label6.TabIndex = 531
        Me.Label6.Text = "Receiver:"
        '
        'txtReceiver
        '
        Me.txtReceiver.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReceiver.Location = New System.Drawing.Point(8, 317)
        Me.txtReceiver.Name = "txtReceiver"
        Me.txtReceiver.Size = New System.Drawing.Size(300, 24)
        Me.txtReceiver.TabIndex = 527
        '
        'btnAddTempCustodian
        '
        Me.btnAddTempCustodian.Location = New System.Drawing.Point(277, 118)
        Me.btnAddTempCustodian.Name = "btnAddTempCustodian"
        Me.btnAddTempCustodian.Size = New System.Drawing.Size(29, 25)
        Me.btnAddTempCustodian.TabIndex = 524
        Me.btnAddTempCustodian.Text = "+"
        Me.btnAddTempCustodian.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(2, 102)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(238, 14)
        Me.Label2.TabIndex = 523
        Me.Label2.Text = "Custodian/Warehouse/Project and Others:"
        '
        'cmbChargesDesc
        '
        Me.cmbChargesDesc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbChargesDesc.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbChargesDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbChargesDesc.FormattingEnabled = True
        Me.cmbChargesDesc.Location = New System.Drawing.Point(6, 119)
        Me.cmbChargesDesc.Name = "cmbChargesDesc"
        Me.cmbChargesDesc.Size = New System.Drawing.Size(264, 23)
        Me.cmbChargesDesc.TabIndex = 522
        '
        'cmbReturnType
        '
        Me.cmbReturnType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbReturnType.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbReturnType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbReturnType.FormattingEnabled = True
        Me.cmbReturnType.Items.AddRange(New Object() {"RETURN FROM", "RETURN TO"})
        Me.cmbReturnType.Location = New System.Drawing.Point(6, 24)
        Me.cmbReturnType.Name = "cmbReturnType"
        Me.cmbReturnType.Size = New System.Drawing.Size(300, 23)
        Me.cmbReturnType.TabIndex = 521
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(5, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 14)
        Me.Label1.TabIndex = 520
        Me.Label1.Text = "Return Type:"
        '
        'cmbChargesType
        '
        Me.cmbChargesType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbChargesType.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbChargesType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbChargesType.FormattingEnabled = True
        Me.cmbChargesType.Items.AddRange(New Object() {"PROJECT", "EQUIPMENT", "PERSONAL", "MAINOFFICE", "WAREHOUSE", "OTHERS"})
        Me.cmbChargesType.Location = New System.Drawing.Point(6, 69)
        Me.cmbChargesType.Name = "cmbChargesType"
        Me.cmbChargesType.Size = New System.Drawing.Size(300, 23)
        Me.cmbChargesType.TabIndex = 519
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(5, 52)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(97, 14)
        Me.Label14.TabIndex = 518
        Me.Label14.Text = "Select Category:"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column6, Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column7, Me.Column8})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.DataGridView1.Location = New System.Drawing.Point(320, 3)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(957, 726)
        Me.DataGridView1.TabIndex = 0
        '
        'Column6
        '
        Me.Column6.HeaderText = "SELECT"
        Me.Column6.Name = "Column6"
        '
        'Column1
        '
        Me.Column1.HeaderText = "BS_NO"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 150
        '
        'Column2
        '
        Me.Column2.HeaderText = "ITEM DESC."
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 350
        '
        'Column3
        '
        Me.Column3.HeaderText = "Qty"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.HeaderText = "Qty to be returned"
        Me.Column4.Name = "Column4"
        Me.Column4.Width = 200
        '
        'Column5
        '
        Me.Column5.HeaderText = "Item status"
        Me.Column5.Items.AddRange(New Object() {"Functional", "Defective"})
        Me.Column5.Name = "Column5"
        Me.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column5.Width = 250
        '
        'Column7
        '
        Me.Column7.HeaderText = "br_tr_det_id"
        Me.Column7.Name = "Column7"
        '
        'Column8
        '
        Me.Column8.HeaderText = "rs_id"
        Me.Column8.Name = "Column8"
        '
        'FBorrower_Turnover_Items
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gray
        Me.ClientSize = New System.Drawing.Size(1286, 738)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FBorrower_Turnover_Items"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FBorrower_Turnover_Items"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.CMS_remove.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button1 As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents cmbReturnType As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbChargesType As ComboBox
    Friend WithEvents Label14 As Label
    Friend WithEvents btnAddTempCustodian As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbChargesDesc As ComboBox
    Friend WithEvents txtturnoverby As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents dtpDateNoted As DateTimePicker
    Friend WithEvents Label7 As Label
    Friend WithEvents dtpdateturnover As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents txtReceiver As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents list_ReturnTo As ListBox
    Friend WithEvents list_returnFrom As ListBox
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents txtNotedBy As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Column6 As DataGridViewCheckBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewComboBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents lbox_return_details As ListBox
    Friend WithEvents CMS_remove As ContextMenuStrip
    Friend WithEvents RemoveToolStripMenuItem As ToolStripMenuItem
End Class
