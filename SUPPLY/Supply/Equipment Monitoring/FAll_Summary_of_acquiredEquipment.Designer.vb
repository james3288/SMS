<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FAll_Summary_of_acquiredEquipment
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
        Me.lvl_all_acquiredEquipment = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btn_viewReport = New System.Windows.Forms.Button()
        Me.dtp_dateTo = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtp_dateFrom = New System.Windows.Forms.DateTimePicker()
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'lvl_all_acquiredEquipment
        '
        Me.lvl_all_acquiredEquipment.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.lvl_all_acquiredEquipment.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvl_all_acquiredEquipment.FullRowSelect = True
        Me.lvl_all_acquiredEquipment.GridLines = True
        Me.lvl_all_acquiredEquipment.HideSelection = False
        Me.lvl_all_acquiredEquipment.Location = New System.Drawing.Point(12, 12)
        Me.lvl_all_acquiredEquipment.MultiSelect = False
        Me.lvl_all_acquiredEquipment.Name = "lvl_all_acquiredEquipment"
        Me.lvl_all_acquiredEquipment.Size = New System.Drawing.Size(655, 214)
        Me.lvl_all_acquiredEquipment.TabIndex = 0
        Me.lvl_all_acquiredEquipment.UseCompatibleStateImageBehavior = False
        Me.lvl_all_acquiredEquipment.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Category"
        Me.ColumnHeader1.Width = 211
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Equipment Type"
        Me.ColumnHeader2.Width = 160
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Number of Units"
        Me.ColumnHeader3.Width = 160
        '
        'btn_viewReport
        '
        Me.btn_viewReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_viewReport.Location = New System.Drawing.Point(464, 232)
        Me.btn_viewReport.Name = "btn_viewReport"
        Me.btn_viewReport.Size = New System.Drawing.Size(92, 36)
        Me.btn_viewReport.TabIndex = 1
        Me.btn_viewReport.Text = "View Report"
        Me.btn_viewReport.UseVisualStyleBackColor = True
        '
        'dtp_dateTo
        '
        Me.dtp_dateTo.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_dateTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_dateTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_dateTo.Location = New System.Drawing.Point(308, 236)
        Me.dtp_dateTo.Name = "dtp_dateTo"
        Me.dtp_dateTo.Size = New System.Drawing.Size(147, 26)
        Me.dtp_dateTo.TabIndex = 142
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(242, 241)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 16)
        Me.Label5.TabIndex = 143
        Me.Label5.Text = "Date To:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(9, 241)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 16)
        Me.Label3.TabIndex = 141
        Me.Label3.Text = "Date From:"
        '
        'dtp_dateFrom
        '
        Me.dtp_dateFrom.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_dateFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_dateFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_dateFrom.Location = New System.Drawing.Point(89, 236)
        Me.dtp_dateFrom.Name = "dtp_dateFrom"
        Me.dtp_dateFrom.Size = New System.Drawing.Size(147, 26)
        Me.dtp_dateFrom.TabIndex = 140
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Acquisition Cost"
        Me.ColumnHeader4.Width = 114
        '
        'FAll_Summary_of_acquiredEquipment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(679, 277)
        Me.Controls.Add(Me.dtp_dateTo)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dtp_dateFrom)
        Me.Controls.Add(Me.btn_viewReport)
        Me.Controls.Add(Me.lvl_all_acquiredEquipment)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FAll_Summary_of_acquiredEquipment"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "All Summary of Acquired Equipment"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lvl_all_acquiredEquipment As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents btn_viewReport As Button
    Friend WithEvents dtp_dateTo As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents dtp_dateFrom As DateTimePicker
    Friend WithEvents ColumnHeader4 As ColumnHeader
End Class
