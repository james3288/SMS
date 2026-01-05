<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FSummary_of_AcquiredEquipment
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.panel3 = New System.Windows.Forms.Panel()
        Me.dtp_dateTo = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.dtp_dateFrom = New System.Windows.Forms.DateTimePicker()
        Me.lvl_summary_of_acquiredEquipment = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cmb_equipmentType = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmb_category = New System.Windows.Forms.ComboBox()
        Me.lbl_category = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btn_viewReport = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.panel3.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1322, 663)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.panel3)
        Me.Panel1.Controls.Add(Me.lvl_summary_of_acquiredEquipment)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1316, 609)
        Me.Panel1.TabIndex = 0
        '
        'panel3
        '
        Me.panel3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.panel3.Controls.Add(Me.dtp_dateTo)
        Me.panel3.Controls.Add(Me.Label5)
        Me.panel3.Controls.Add(Me.Button2)
        Me.panel3.Controls.Add(Me.Label3)
        Me.panel3.Controls.Add(Me.Button3)
        Me.panel3.Controls.Add(Me.dtp_dateFrom)
        Me.panel3.Location = New System.Drawing.Point(533, 178)
        Me.panel3.Name = "panel3"
        Me.panel3.Size = New System.Drawing.Size(250, 199)
        Me.panel3.TabIndex = 4
        Me.panel3.Visible = False
        '
        'dtp_dateTo
        '
        Me.dtp_dateTo.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_dateTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_dateTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_dateTo.Location = New System.Drawing.Point(15, 126)
        Me.dtp_dateTo.Name = "dtp_dateTo"
        Me.dtp_dateTo.Size = New System.Drawing.Size(221, 26)
        Me.dtp_dateTo.TabIndex = 139
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(12, 107)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 16)
        Me.Label5.TabIndex = 139
        Me.Label5.Text = "Date To:"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.BackgroundImage = Global.SUPPLY.My.Resources.Resources.close_button
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(213, 12)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(23, 22)
        Me.Button2.TabIndex = 138
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(12, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 16)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Date From:"
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(159, 158)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(77, 32)
        Me.Button3.TabIndex = 14
        Me.Button3.Text = "Search"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'dtp_dateFrom
        '
        Me.dtp_dateFrom.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_dateFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_dateFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_dateFrom.Location = New System.Drawing.Point(15, 69)
        Me.dtp_dateFrom.Name = "dtp_dateFrom"
        Me.dtp_dateFrom.Size = New System.Drawing.Size(221, 26)
        Me.dtp_dateFrom.TabIndex = 15
        '
        'lvl_summary_of_acquiredEquipment
        '
        Me.lvl_summary_of_acquiredEquipment.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8})
        Me.lvl_summary_of_acquiredEquipment.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvl_summary_of_acquiredEquipment.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvl_summary_of_acquiredEquipment.FullRowSelect = True
        Me.lvl_summary_of_acquiredEquipment.GridLines = True
        Me.lvl_summary_of_acquiredEquipment.HideSelection = False
        Me.lvl_summary_of_acquiredEquipment.Location = New System.Drawing.Point(0, 0)
        Me.lvl_summary_of_acquiredEquipment.MultiSelect = False
        Me.lvl_summary_of_acquiredEquipment.Name = "lvl_summary_of_acquiredEquipment"
        Me.lvl_summary_of_acquiredEquipment.Size = New System.Drawing.Size(1316, 609)
        Me.lvl_summary_of_acquiredEquipment.TabIndex = 0
        Me.lvl_summary_of_acquiredEquipment.UseCompatibleStateImageBehavior = False
        Me.lvl_summary_of_acquiredEquipment.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Category"
        Me.ColumnHeader1.Width = 160
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Type of Equipment"
        Me.ColumnHeader2.Width = 210
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Plate No."
        Me.ColumnHeader3.Width = 210
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Date Acquired"
        Me.ColumnHeader4.Width = 150
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Model/Brand"
        Me.ColumnHeader5.Width = 180
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Serial No."
        Me.ColumnHeader6.Width = 180
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Supplier"
        Me.ColumnHeader7.Width = 210
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Acquisition Cost"
        Me.ColumnHeader8.Width = 150
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Panel2, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel4, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 618)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1316, 42)
        Me.TableLayoutPanel2.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.cmb_equipmentType)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.cmb_category)
        Me.Panel2.Controls.Add(Me.lbl_category)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1210, 36)
        Me.Panel2.TabIndex = 2
        '
        'cmb_equipmentType
        '
        Me.cmb_equipmentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_equipmentType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmb_equipmentType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_equipmentType.FormattingEnabled = True
        Me.cmb_equipmentType.Location = New System.Drawing.Point(428, 3)
        Me.cmb_equipmentType.Name = "cmb_equipmentType"
        Me.cmb_equipmentType.Size = New System.Drawing.Size(222, 24)
        Me.cmb_equipmentType.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(294, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(125, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Equipment Type:"
        '
        'cmb_category
        '
        Me.cmb_category.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_category.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmb_category.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_category.FormattingEnabled = True
        Me.cmb_category.Location = New System.Drawing.Point(93, 3)
        Me.cmb_category.Name = "cmb_category"
        Me.cmb_category.Size = New System.Drawing.Size(183, 24)
        Me.cmb_category.TabIndex = 1
        '
        'lbl_category
        '
        Me.lbl_category.AutoSize = True
        Me.lbl_category.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_category.Location = New System.Drawing.Point(9, 6)
        Me.lbl_category.Name = "lbl_category"
        Me.lbl_category.Size = New System.Drawing.Size(75, 16)
        Me.lbl_category.TabIndex = 0
        Me.lbl_category.Text = "Category:"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btn_viewReport)
        Me.Panel4.Location = New System.Drawing.Point(1219, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(94, 36)
        Me.Panel4.TabIndex = 3
        '
        'btn_viewReport
        '
        Me.btn_viewReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_viewReport.Location = New System.Drawing.Point(3, 0)
        Me.btn_viewReport.Name = "btn_viewReport"
        Me.btn_viewReport.Size = New System.Drawing.Size(91, 36)
        Me.btn_viewReport.TabIndex = 14
        Me.btn_viewReport.Text = "View Report"
        Me.btn_viewReport.UseVisualStyleBackColor = True
        '
        'FSummary_of_AcquiredEquipment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1322, 663)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "FSummary_of_AcquiredEquipment"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Summary of Acquired Equipment"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.panel3.ResumeLayout(False)
        Me.panel3.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lvl_summary_of_acquiredEquipment As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents panel3 As Panel
    Friend WithEvents dtp_dateTo As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents dtp_dateFrom As DateTimePicker
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents cmb_equipmentType As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cmb_category As ComboBox
    Friend WithEvents lbl_category As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents btn_viewReport As Button
End Class
