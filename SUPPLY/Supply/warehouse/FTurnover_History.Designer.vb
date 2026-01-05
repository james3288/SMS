<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FTurnover_History
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
        Me.cmbType1 = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbTurnoverfrom = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cmbTurnoverto = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbType2 = New System.Windows.Forms.ComboBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblItemDesc = New System.Windows.Forms.Label()
        Me.lblItemName = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtqty = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtreceiver = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.lvl_turnover_list = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.dtp_turnover = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtTurnoverby = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtnotedby = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtcondition = New System.Windows.Forms.TextBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.RemoveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbType1
        '
        Me.cmbType1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbType1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbType1.FormattingEnabled = True
        Me.cmbType1.Items.AddRange(New Object() {"WAREHOUSE", "PROJECT", "PERSONAL"})
        Me.cmbType1.Location = New System.Drawing.Point(5, 27)
        Me.cmbType1.Name = "cmbType1"
        Me.cmbType1.Size = New System.Drawing.Size(249, 26)
        Me.cmbType1.TabIndex = 455
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(2, 6)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(101, 16)
        Me.Label11.TabIndex = 456
        Me.Label11.Text = "Turnover from:"
        '
        'cmbTurnoverfrom
        '
        Me.cmbTurnoverfrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTurnoverfrom.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTurnoverfrom.FormattingEnabled = True
        Me.cmbTurnoverfrom.Items.AddRange(New Object() {"YES", "NO"})
        Me.cmbTurnoverfrom.Location = New System.Drawing.Point(5, 59)
        Me.cmbTurnoverfrom.Name = "cmbTurnoverfrom"
        Me.cmbTurnoverfrom.Size = New System.Drawing.Size(249, 26)
        Me.cmbTurnoverfrom.TabIndex = 457
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.cmbTurnoverfrom)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.cmbType1)
        Me.Panel1.Location = New System.Drawing.Point(10, 152)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(257, 97)
        Me.Panel1.TabIndex = 461
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.cmbTurnoverto)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.cmbType2)
        Me.Panel2.Location = New System.Drawing.Point(10, 252)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(257, 97)
        Me.Panel2.TabIndex = 462
        '
        'cmbTurnoverto
        '
        Me.cmbTurnoverto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTurnoverto.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTurnoverto.FormattingEnabled = True
        Me.cmbTurnoverto.Items.AddRange(New Object() {"YES", "NO"})
        Me.cmbTurnoverto.Location = New System.Drawing.Point(5, 59)
        Me.cmbTurnoverto.Name = "cmbTurnoverto"
        Me.cmbTurnoverto.Size = New System.Drawing.Size(249, 26)
        Me.cmbTurnoverto.TabIndex = 457
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(2, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 16)
        Me.Label1.TabIndex = 456
        Me.Label1.Text = "Turnover to:"
        '
        'cmbType2
        '
        Me.cmbType2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbType2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbType2.FormattingEnabled = True
        Me.cmbType2.Items.AddRange(New Object() {"WAREHOUSE", "PROJECT", "PERSONAL"})
        Me.cmbType2.Location = New System.Drawing.Point(5, 27)
        Me.cmbType2.Name = "cmbType2"
        Me.cmbType2.Size = New System.Drawing.Size(249, 26)
        Me.cmbType2.TabIndex = 455
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.lblItemDesc)
        Me.Panel3.Controls.Add(Me.lblItemName)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Location = New System.Drawing.Point(10, 52)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(257, 97)
        Me.Panel3.TabIndex = 463
        '
        'lblItemDesc
        '
        Me.lblItemDesc.AutoSize = True
        Me.lblItemDesc.BackColor = System.Drawing.Color.Transparent
        Me.lblItemDesc.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItemDesc.ForeColor = System.Drawing.Color.Black
        Me.lblItemDesc.Location = New System.Drawing.Point(19, 55)
        Me.lblItemDesc.Name = "lblItemDesc"
        Me.lblItemDesc.Size = New System.Drawing.Size(14, 18)
        Me.lblItemDesc.TabIndex = 457
        Me.lblItemDesc.Text = "*"
        '
        'lblItemName
        '
        Me.lblItemName.AutoSize = True
        Me.lblItemName.BackColor = System.Drawing.Color.Transparent
        Me.lblItemName.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItemName.ForeColor = System.Drawing.Color.Black
        Me.lblItemName.Location = New System.Drawing.Point(19, 30)
        Me.lblItemName.Name = "lblItemName"
        Me.lblItemName.Size = New System.Drawing.Size(14, 18)
        Me.lblItemName.TabIndex = 457
        Me.lblItemName.Text = "*"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(2, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(111, 16)
        Me.Label2.TabIndex = 456
        Me.Label2.Text = "Item Description"
        '
        'txtqty
        '
        Me.txtqty.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtqty.Location = New System.Drawing.Point(81, 388)
        Me.txtqty.Name = "txtqty"
        Me.txtqty.Size = New System.Drawing.Size(186, 26)
        Me.txtqty.TabIndex = 464
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(45, 393)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 16)
        Me.Label3.TabIndex = 465
        Me.Label3.Text = "Qty:"
        '
        'txtreceiver
        '
        Me.txtreceiver.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtreceiver.Location = New System.Drawing.Point(81, 420)
        Me.txtreceiver.Name = "txtreceiver"
        Me.txtreceiver.Size = New System.Drawing.Size(186, 26)
        Me.txtreceiver.TabIndex = 466
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(12, 426)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 16)
        Me.Label4.TabIndex = 467
        Me.Label4.Text = "Receiver:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(10, 517)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(257, 39)
        Me.btnSave.TabIndex = 468
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'lvl_turnover_list
        '
        Me.lvl_turnover_list.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11, Me.ColumnHeader12, Me.ColumnHeader6})
        Me.lvl_turnover_list.ContextMenuStrip = Me.ContextMenuStrip1
        Me.lvl_turnover_list.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvl_turnover_list.FullRowSelect = True
        Me.lvl_turnover_list.GridLines = True
        Me.lvl_turnover_list.HideSelection = False
        Me.lvl_turnover_list.Location = New System.Drawing.Point(273, 12)
        Me.lvl_turnover_list.Name = "lvl_turnover_list"
        Me.lvl_turnover_list.Size = New System.Drawing.Size(898, 624)
        Me.lvl_turnover_list.TabIndex = 469
        Me.lvl_turnover_list.UseCompatibleStateImageBehavior = False
        Me.lvl_turnover_list.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "id"
        Me.ColumnHeader1.Width = 0
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Type"
        Me.ColumnHeader2.Width = 150
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Turnover from"
        Me.ColumnHeader3.Width = 150
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Type"
        Me.ColumnHeader4.Width = 150
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Turnover to"
        Me.ColumnHeader5.Width = 150
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Qty"
        Me.ColumnHeader8.Width = 150
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Receiver"
        Me.ColumnHeader9.Width = 150
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Turnover By"
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Noted by"
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "Date Turnover"
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Condition"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditToolStripMenuItem, Me.RemoveToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(153, 70)
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'dtp_turnover
        '
        Me.dtp_turnover.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_turnover.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_turnover.Location = New System.Drawing.Point(118, 17)
        Me.dtp_turnover.Name = "dtp_turnover"
        Me.dtp_turnover.Size = New System.Drawing.Size(148, 26)
        Me.dtp_turnover.TabIndex = 470
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(11, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(101, 16)
        Me.Label5.TabIndex = 471
        Me.Label5.Text = "Date Turnover:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(12, 458)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 16)
        Me.Label6.TabIndex = 473
        Me.Label6.Text = "Turnover by:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtTurnoverby
        '
        Me.txtTurnoverby.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTurnoverby.Location = New System.Drawing.Point(105, 452)
        Me.txtTurnoverby.Name = "txtTurnoverby"
        Me.txtTurnoverby.Size = New System.Drawing.Size(162, 26)
        Me.txtTurnoverby.TabIndex = 472
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(28, 490)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(68, 16)
        Me.Label7.TabIndex = 475
        Me.Label7.Text = "Noted by:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtnotedby
        '
        Me.txtnotedby.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnotedby.Location = New System.Drawing.Point(105, 484)
        Me.txtnotedby.Name = "txtnotedby"
        Me.txtnotedby.Size = New System.Drawing.Size(162, 26)
        Me.txtnotedby.TabIndex = 474
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(8, 361)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(73, 16)
        Me.Label8.TabIndex = 477
        Me.Label8.Text = "Condition:"
        '
        'txtcondition
        '
        Me.txtcondition.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcondition.Location = New System.Drawing.Point(81, 356)
        Me.txtcondition.Name = "txtcondition"
        Me.txtcondition.Size = New System.Drawing.Size(186, 26)
        Me.txtcondition.TabIndex = 476
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(10, 562)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(257, 39)
        Me.btnCancel.TabIndex = 479
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        Me.btnCancel.Visible = False
        '
        'RemoveToolStripMenuItem
        '
        Me.RemoveToolStripMenuItem.Name = "RemoveToolStripMenuItem"
        Me.RemoveToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.RemoveToolStripMenuItem.Text = "Remove"
        '
        'FTurnover_History
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1183, 648)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtcondition)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtnotedby)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtTurnoverby)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.dtp_turnover)
        Me.Controls.Add(Me.lvl_turnover_list)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtreceiver)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtqty)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FTurnover_History"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FTurnover_History"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmbType1 As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents cmbTurnoverfrom As ComboBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents cmbTurnoverto As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbType2 As ComboBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents txtqty As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtreceiver As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents lvl_turnover_list As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents ColumnHeader9 As ColumnHeader
    Friend WithEvents lblItemDesc As Label
    Friend WithEvents lblItemName As Label
    Friend WithEvents dtp_turnover As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtTurnoverby As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtnotedby As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtcondition As TextBox
    Friend WithEvents ColumnHeader10 As ColumnHeader
    Friend WithEvents ColumnHeader11 As ColumnHeader
    Friend WithEvents ColumnHeader12 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnCancel As Button
    Friend WithEvents RemoveToolStripMenuItem As ToolStripMenuItem
End Class
