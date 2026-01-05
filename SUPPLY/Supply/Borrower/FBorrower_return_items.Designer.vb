<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FBorrower_return_items
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
        Me.btnAddTempCustodian = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbChargesDesc = New System.Windows.Forms.ComboBox()
        Me.cmbChargesType = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lvlMultipleCustodian = New System.Windows.Forms.ListView()
        Me.ColumnHeader17 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader18 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CMS_lvlMultipleCustodian = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RemoveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmbReturnType = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNotedBy = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtturnoverby = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dtpDateNoted = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtpdateturnover = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtReceiver = New System.Windows.Forms.TextBox()
        Me.btnReturnthisItem = New System.Windows.Forms.Button()
        Me.lbox_return_details = New System.Windows.Forms.ListBox()
        Me.CMS_lvlMultipleCustodian.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAddTempCustodian
        '
        Me.btnAddTempCustodian.Location = New System.Drawing.Point(283, 125)
        Me.btnAddTempCustodian.Name = "btnAddTempCustodian"
        Me.btnAddTempCustodian.Size = New System.Drawing.Size(29, 24)
        Me.btnAddTempCustodian.TabIndex = 512
        Me.btnAddTempCustodian.Text = "+"
        Me.btnAddTempCustodian.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(10, 109)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(238, 14)
        Me.Label2.TabIndex = 510
        Me.Label2.Text = "Custodian/Warehouse/Project and Others:"
        '
        'cmbChargesDesc
        '
        Me.cmbChargesDesc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbChargesDesc.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbChargesDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbChargesDesc.FormattingEnabled = True
        Me.cmbChargesDesc.Location = New System.Drawing.Point(13, 126)
        Me.cmbChargesDesc.Name = "cmbChargesDesc"
        Me.cmbChargesDesc.Size = New System.Drawing.Size(264, 23)
        Me.cmbChargesDesc.TabIndex = 509
        '
        'cmbChargesType
        '
        Me.cmbChargesType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbChargesType.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbChargesType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbChargesType.FormattingEnabled = True
        Me.cmbChargesType.Items.AddRange(New Object() {"PROJECT", "EQUIPMENT", "PERSONAL", "MAINOFFICE", "WAREHOUSE", "OTHERS"})
        Me.cmbChargesType.Location = New System.Drawing.Point(12, 80)
        Me.cmbChargesType.Name = "cmbChargesType"
        Me.cmbChargesType.Size = New System.Drawing.Size(300, 23)
        Me.cmbChargesType.TabIndex = 508
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(11, 63)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(97, 14)
        Me.Label14.TabIndex = 507
        Me.Label14.Text = "Select Category:"
        '
        'lvlMultipleCustodian
        '
        Me.lvlMultipleCustodian.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvlMultipleCustodian.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader17, Me.ColumnHeader18, Me.ColumnHeader1})
        Me.lvlMultipleCustodian.ContextMenuStrip = Me.CMS_lvlMultipleCustodian
        Me.lvlMultipleCustodian.FullRowSelect = True
        Me.lvlMultipleCustodian.Location = New System.Drawing.Point(327, 35)
        Me.lvlMultipleCustodian.Name = "lvlMultipleCustodian"
        Me.lvlMultipleCustodian.Size = New System.Drawing.Size(586, 403)
        Me.lvlMultipleCustodian.TabIndex = 515
        Me.lvlMultipleCustodian.UseCompatibleStateImageBehavior = False
        Me.lvlMultipleCustodian.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader17
        '
        Me.ColumnHeader17.Text = "Type of charges"
        Me.ColumnHeader17.Width = 129
        '
        'ColumnHeader18
        '
        Me.ColumnHeader18.Text = "Charges"
        Me.ColumnHeader18.Width = 233
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Return Type"
        Me.ColumnHeader1.Width = 197
        '
        'CMS_lvlMultipleCustodian
        '
        Me.CMS_lvlMultipleCustodian.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RemoveToolStripMenuItem})
        Me.CMS_lvlMultipleCustodian.Name = "CMS_lvlMultipleCustodian"
        Me.CMS_lvlMultipleCustodian.Size = New System.Drawing.Size(118, 26)
        '
        'RemoveToolStripMenuItem
        '
        Me.RemoveToolStripMenuItem.Name = "RemoveToolStripMenuItem"
        Me.RemoveToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.RemoveToolStripMenuItem.Text = "Remove"
        '
        'cmbReturnType
        '
        Me.cmbReturnType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbReturnType.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbReturnType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbReturnType.FormattingEnabled = True
        Me.cmbReturnType.Items.AddRange(New Object() {"RETURN FROM", "RETURN TO"})
        Me.cmbReturnType.Location = New System.Drawing.Point(12, 35)
        Me.cmbReturnType.Name = "cmbReturnType"
        Me.cmbReturnType.Size = New System.Drawing.Size(300, 23)
        Me.cmbReturnType.TabIndex = 517
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(11, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 14)
        Me.Label1.TabIndex = 516
        Me.Label1.Text = "Return Type:"
        '
        'txtNotedBy
        '
        Me.txtNotedBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNotedBy.Location = New System.Drawing.Point(12, 358)
        Me.txtNotedBy.Name = "txtNotedBy"
        Me.txtNotedBy.Size = New System.Drawing.Size(300, 24)
        Me.txtNotedBy.TabIndex = 522
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(10, 340)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(60, 15)
        Me.Label10.TabIndex = 527
        Me.Label10.Text = "Noted By:"
        '
        'txtturnoverby
        '
        Me.txtturnoverby.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtturnoverby.Location = New System.Drawing.Point(12, 266)
        Me.txtturnoverby.Name = "txtturnoverby"
        Me.txtturnoverby.Size = New System.Drawing.Size(300, 24)
        Me.txtturnoverby.TabIndex = 520
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(9, 248)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(76, 15)
        Me.Label9.TabIndex = 526
        Me.Label9.Text = "Turnover by:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(10, 293)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 15)
        Me.Label8.TabIndex = 525
        Me.Label8.Text = "Date Noted:"
        '
        'dtpDateNoted
        '
        Me.dtpDateNoted.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDateNoted.Location = New System.Drawing.Point(12, 311)
        Me.dtpDateNoted.Name = "dtpDateNoted"
        Me.dtpDateNoted.Size = New System.Drawing.Size(300, 22)
        Me.dtpDateNoted.TabIndex = 521
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(10, 203)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(86, 15)
        Me.Label7.TabIndex = 524
        Me.Label7.Text = "Date Turnover"
        '
        'dtpdateturnover
        '
        Me.dtpdateturnover.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpdateturnover.Location = New System.Drawing.Point(12, 221)
        Me.dtpdateturnover.Name = "dtpdateturnover"
        Me.dtpdateturnover.Size = New System.Drawing.Size(300, 22)
        Me.dtpdateturnover.TabIndex = 519
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(12, 156)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 15)
        Me.Label6.TabIndex = 523
        Me.Label6.Text = "Receiver:"
        '
        'txtReceiver
        '
        Me.txtReceiver.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReceiver.Location = New System.Drawing.Point(12, 174)
        Me.txtReceiver.Name = "txtReceiver"
        Me.txtReceiver.Size = New System.Drawing.Size(300, 24)
        Me.txtReceiver.TabIndex = 518
        '
        'btnReturnthisItem
        '
        Me.btnReturnthisItem.Location = New System.Drawing.Point(12, 396)
        Me.btnReturnthisItem.Name = "btnReturnthisItem"
        Me.btnReturnthisItem.Size = New System.Drawing.Size(300, 42)
        Me.btnReturnthisItem.TabIndex = 528
        Me.btnReturnthisItem.Text = "Turnover"
        Me.btnReturnthisItem.UseVisualStyleBackColor = True
        '
        'lbox_return_details
        '
        Me.lbox_return_details.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbox_return_details.FormattingEnabled = True
        Me.lbox_return_details.ItemHeight = 15
        Me.lbox_return_details.Location = New System.Drawing.Point(630, 266)
        Me.lbox_return_details.Name = "lbox_return_details"
        Me.lbox_return_details.Size = New System.Drawing.Size(263, 139)
        Me.lbox_return_details.TabIndex = 529
        Me.lbox_return_details.Visible = False
        '
        'FBorrower_return_items
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SUPPLY.My.Resources.Resources.eus_bg_03
        Me.ClientSize = New System.Drawing.Size(926, 454)
        Me.Controls.Add(Me.lbox_return_details)
        Me.Controls.Add(Me.btnReturnthisItem)
        Me.Controls.Add(Me.txtNotedBy)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtturnoverby)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.dtpDateNoted)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.dtpdateturnover)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtReceiver)
        Me.Controls.Add(Me.cmbReturnType)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lvlMultipleCustodian)
        Me.Controls.Add(Me.btnAddTempCustodian)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbChargesDesc)
        Me.Controls.Add(Me.cmbChargesType)
        Me.Controls.Add(Me.Label14)
        Me.Name = "FBorrower_return_items"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FBorrower_return_items"
        Me.CMS_lvlMultipleCustodian.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnAddTempCustodian As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbChargesDesc As ComboBox
    Friend WithEvents cmbChargesType As ComboBox
    Friend WithEvents Label14 As Label
    Friend WithEvents lvlMultipleCustodian As ListView
    Friend WithEvents ColumnHeader17 As ColumnHeader
    Friend WithEvents ColumnHeader18 As ColumnHeader
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents cmbReturnType As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtNotedBy As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtturnoverby As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents dtpDateNoted As DateTimePicker
    Friend WithEvents Label7 As Label
    Friend WithEvents dtpdateturnover As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents txtReceiver As TextBox
    Friend WithEvents btnReturnthisItem As Button
    Friend WithEvents CMS_lvlMultipleCustodian As ContextMenuStrip
    Friend WithEvents RemoveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents lbox_return_details As System.Windows.Forms.ListBox
End Class
