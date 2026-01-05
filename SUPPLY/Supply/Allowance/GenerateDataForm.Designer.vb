<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GenerateDataForm
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
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbSelectCat = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblDateCurRange = New System.Windows.Forms.Label()
        Me.lblDatePrevRange = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DTP_PrevTo = New System.Windows.Forms.DateTimePicker()
        Me.DTP_PrevFrom = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.DTP_CurTo = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DTP_CurFrom = New System.Windows.Forms.DateTimePicker()
        Me.lblAmount = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.listview1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Plant & Equipment", "Project-Based", "Project-Based (local)", "General", "JQG-2go", "-", "General / Plant & Equipment / JQG-2go", "Project-Based / Project-Based (local)"})
        Me.ComboBox1.Location = New System.Drawing.Point(25, 396)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(295, 26)
        Me.ComboBox1.TabIndex = 628
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DarkOrange
        Me.Label8.Location = New System.Drawing.Point(135, 378)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(152, 13)
        Me.Label8.TabIndex = 627
        Me.Label8.Text = "(Based on Employee Category)"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(21, 375)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(121, 18)
        Me.Label7.TabIndex = 626
        Me.Label7.Text = "Select Category"
        '
        'cmbSelectCat
        '
        Me.cmbSelectCat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSelectCat.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSelectCat.FormattingEnabled = True
        Me.cmbSelectCat.Items.AddRange(New Object() {"ADMIN", "EQUIP", "OPERATION", "PROJECT"})
        Me.cmbSelectCat.Location = New System.Drawing.Point(560, 447)
        Me.cmbSelectCat.Name = "cmbSelectCat"
        Me.cmbSelectCat.Size = New System.Drawing.Size(296, 26)
        Me.cmbSelectCat.TabIndex = 625
        Me.cmbSelectCat.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DarkOrange
        Me.Label6.Location = New System.Drawing.Point(342, 430)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(291, 14)
        Me.Label6.TabIndex = 624
        Me.Label6.Text = "If no category is selected, all categories will be displayed."
        '
        'lblDateCurRange
        '
        Me.lblDateCurRange.AutoSize = True
        Me.lblDateCurRange.Location = New System.Drawing.Point(483, 6)
        Me.lblDateCurRange.Name = "lblDateCurRange"
        Me.lblDateCurRange.Size = New System.Drawing.Size(88, 13)
        Me.lblDateCurRange.TabIndex = 623
        Me.lblDateCurRange.Text = "lblDateCurRange"
        Me.lblDateCurRange.Visible = False
        '
        'lblDatePrevRange
        '
        Me.lblDatePrevRange.AutoSize = True
        Me.lblDatePrevRange.Location = New System.Drawing.Point(366, 6)
        Me.lblDatePrevRange.Name = "lblDatePrevRange"
        Me.lblDatePrevRange.Size = New System.Drawing.Size(94, 13)
        Me.lblDatePrevRange.TabIndex = 622
        Me.lblDatePrevRange.Text = "lblDatePrevRange"
        Me.lblDatePrevRange.Visible = False
        '
        'Button1
        '
        Me.Button1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Button1.BackColor = System.Drawing.Color.MediumTurquoise
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(186, 435)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(134, 35)
        Me.Button1.TabIndex = 615
        Me.Button1.Text = "View Report"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Button3.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(25, 435)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(134, 35)
        Me.Button3.TabIndex = 629
        Me.Button3.Text = "Search"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(32, 87)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 16)
        Me.Label4.TabIndex = 487
        Me.Label4.Text = "DateTo:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(32, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 16)
        Me.Label5.TabIndex = 486
        Me.Label5.Text = "Date From:"
        '
        'DTP_PrevTo
        '
        Me.DTP_PrevTo.CustomFormat = "MMMM/yyyy"
        Me.DTP_PrevTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_PrevTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_PrevTo.Location = New System.Drawing.Point(33, 106)
        Me.DTP_PrevTo.Name = "DTP_PrevTo"
        Me.DTP_PrevTo.Size = New System.Drawing.Size(232, 26)
        Me.DTP_PrevTo.TabIndex = 2
        '
        'DTP_PrevFrom
        '
        Me.DTP_PrevFrom.CustomFormat = "MMMM/yyyy"
        Me.DTP_PrevFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_PrevFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_PrevFrom.Location = New System.Drawing.Point(33, 45)
        Me.DTP_PrevFrom.Name = "DTP_PrevFrom"
        Me.DTP_PrevFrom.Size = New System.Drawing.Size(232, 26)
        Me.DTP_PrevFrom.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(92, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(159, 18)
        Me.Label2.TabIndex = 620
        Me.Label2.Text = "Previous Date Range"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.DTP_PrevTo)
        Me.Panel2.Controls.Add(Me.DTP_PrevFrom)
        Me.Panel2.Location = New System.Drawing.Point(25, 27)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(296, 153)
        Me.Panel2.TabIndex = 621
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(36, 87)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 16)
        Me.Label3.TabIndex = 483
        Me.Label3.Text = "DateTo:"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.DTP_CurTo)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.DTP_CurFrom)
        Me.Panel1.Location = New System.Drawing.Point(25, 210)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(296, 153)
        Me.Panel1.TabIndex = 619
        '
        'DTP_CurTo
        '
        Me.DTP_CurTo.CustomFormat = "MMMM/yyyy"
        Me.DTP_CurTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_CurTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_CurTo.Location = New System.Drawing.Point(37, 106)
        Me.DTP_CurTo.Name = "DTP_CurTo"
        Me.DTP_CurTo.Size = New System.Drawing.Size(232, 26)
        Me.DTP_CurTo.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(36, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 16)
        Me.Label1.TabIndex = 482
        Me.Label1.Text = "Date From:"
        '
        'DTP_CurFrom
        '
        Me.DTP_CurFrom.CustomFormat = "MMMM/yyyy"
        Me.DTP_CurFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_CurFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_CurFrom.Location = New System.Drawing.Point(37, 45)
        Me.DTP_CurFrom.Name = "DTP_CurFrom"
        Me.DTP_CurFrom.Size = New System.Drawing.Size(232, 26)
        Me.DTP_CurFrom.TabIndex = 3
        '
        'lblAmount
        '
        Me.lblAmount.AutoSize = True
        Me.lblAmount.BackColor = System.Drawing.Color.Transparent
        Me.lblAmount.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAmount.ForeColor = System.Drawing.Color.White
        Me.lblAmount.Location = New System.Drawing.Point(95, 199)
        Me.lblAmount.Name = "lblAmount"
        Me.lblAmount.Size = New System.Drawing.Size(150, 18)
        Me.lblAmount.TabIndex = 618
        Me.lblAmount.Text = "Current Date Range"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.BackgroundImage = Global.SUPPLY.My.Resources.Resources.close_button
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(789, 1)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(23, 22)
        Me.Button2.TabIndex = 617
        Me.Button2.UseVisualStyleBackColor = False
        '
        'btnSubmit
        '
        Me.btnSubmit.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnSubmit.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnSubmit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSubmit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSubmit.Location = New System.Drawing.Point(396, 445)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(134, 35)
        Me.btnSubmit.TabIndex = 614
        Me.btnSubmit.Text = "Search"
        Me.btnSubmit.UseVisualStyleBackColor = False
        Me.btnSubmit.Visible = False
        '
        'listview1
        '
        Me.listview1.AllowColumnReorder = True
        Me.listview1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader1})
        Me.listview1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.listview1.FullRowSelect = True
        Me.listview1.GridLines = True
        Me.listview1.HideSelection = False
        Me.listview1.Location = New System.Drawing.Point(352, 29)
        Me.listview1.Name = "listview1"
        Me.listview1.Size = New System.Drawing.Size(450, 393)
        Me.listview1.TabIndex = 630
        Me.listview1.UseCompatibleStateImageBehavior = False
        Me.listview1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Charges"
        Me.ColumnHeader2.Width = 81
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "No person"
        Me.ColumnHeader3.Width = 78
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "amount"
        Me.ColumnHeader4.Width = 89
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "no person"
        Me.ColumnHeader5.Width = 92
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "amount"
        Me.ColumnHeader6.Width = 150
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Type"
        '
        'GenerateDataForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SUPPLY.My.Resources.Resources.bg_line
        Me.ClientSize = New System.Drawing.Size(817, 481)
        Me.Controls.Add(Me.listview1)
        Me.Controls.Add(Me.lblAmount)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cmbSelectCat)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblDateCurRange)
        Me.Controls.Add(Me.lblDatePrevRange)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btnSubmit)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "GenerateDataForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GenerateDataForm"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents cmbSelectCat As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents lblDateCurRange As Label
    Friend WithEvents lblDatePrevRange As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents DTP_PrevTo As DateTimePicker
    Friend WithEvents DTP_PrevFrom As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents DTP_CurTo As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents DTP_CurFrom As DateTimePicker
    Friend WithEvents lblAmount As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents btnSubmit As Button
    Friend WithEvents listview1 As ListView
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents ColumnHeader1 As ColumnHeader
End Class
