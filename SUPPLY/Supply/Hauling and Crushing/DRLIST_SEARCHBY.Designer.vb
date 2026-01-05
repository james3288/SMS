<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DRLIST_SEARCHBY
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
        Me.cmbSortBy = New System.Windows.Forms.ComboBox()
        Me.cmbEnableDateRange = New System.Windows.Forms.ComboBox()
        Me.txtItems = New System.Windows.Forms.TextBox()
        Me.cmbINOUT = New System.Windows.Forms.ComboBox()
        Me.txtItemDesc = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dtpto = New System.Windows.Forms.DateTimePicker()
        Me.dtpfrom = New System.Windows.Forms.DateTimePicker()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbSortBy
        '
        Me.cmbSortBy.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmbSortBy.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSortBy.FormattingEnabled = True
        Me.cmbSortBy.Items.AddRange(New Object() {"RS NO", "DR NO", "WS NO", "DRIVER", "PLATE NO", "UNIT", "ITEM DESCRIPTION", "CONSESSION TICKET", "REQUESTOR", "SOURCE", "REMARKS", "SUPPLIER", "DATE RANGE", "WH_ID", "WITHOUT RS AND DR", "IN/OUT", "DR_ITEMS_ID"})
        Me.cmbSortBy.Location = New System.Drawing.Point(71, 47)
        Me.cmbSortBy.Name = "cmbSortBy"
        Me.cmbSortBy.Size = New System.Drawing.Size(236, 26)
        Me.cmbSortBy.TabIndex = 2
        '
        'cmbEnableDateRange
        '
        Me.cmbEnableDateRange.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmbEnableDateRange.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEnableDateRange.FormattingEnabled = True
        Me.cmbEnableDateRange.Items.AddRange(New Object() {"ENABLE DATE RANGE", "DISABLE DATE RANGE"})
        Me.cmbEnableDateRange.Location = New System.Drawing.Point(71, 243)
        Me.cmbEnableDateRange.Name = "cmbEnableDateRange"
        Me.cmbEnableDateRange.Size = New System.Drawing.Size(235, 26)
        Me.cmbEnableDateRange.TabIndex = 13
        '
        'txtItems
        '
        Me.txtItems.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItems.Location = New System.Drawing.Point(72, 144)
        Me.txtItems.Name = "txtItems"
        Me.txtItems.Size = New System.Drawing.Size(235, 26)
        Me.txtItems.TabIndex = 11
        '
        'cmbINOUT
        '
        Me.cmbINOUT.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbINOUT.FormattingEnabled = True
        Me.cmbINOUT.Items.AddRange(New Object() {"IN", "OUT", "OTHERS"})
        Me.cmbINOUT.Location = New System.Drawing.Point(72, 192)
        Me.cmbINOUT.Name = "cmbINOUT"
        Me.cmbINOUT.Size = New System.Drawing.Size(235, 26)
        Me.cmbINOUT.TabIndex = 12
        '
        'txtItemDesc
        '
        Me.txtItemDesc.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemDesc.Location = New System.Drawing.Point(71, 96)
        Me.txtItemDesc.Name = "txtItemDesc"
        Me.txtItemDesc.Size = New System.Drawing.Size(236, 26)
        Me.txtItemDesc.TabIndex = 10
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(43, 390)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(263, 35)
        Me.btnSearch.TabIndex = 362
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = Global.SUPPLY.My.Resources.Resources.eus_bg_03
        Me.Panel1.Controls.Add(Me.dtpto)
        Me.Panel1.Controls.Add(Me.dtpfrom)
        Me.Panel1.Controls.Add(Me.btnExit)
        Me.Panel1.Controls.Add(Me.btnSearch)
        Me.Panel1.Controls.Add(Me.cmbEnableDateRange)
        Me.Panel1.Controls.Add(Me.txtItems)
        Me.Panel1.Controls.Add(Me.cmbINOUT)
        Me.Panel1.Controls.Add(Me.txtItemDesc)
        Me.Panel1.Controls.Add(Me.cmbSortBy)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(345, 466)
        Me.Panel1.TabIndex = 363
        '
        'dtpto
        '
        Me.dtpto.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpto.Location = New System.Drawing.Point(71, 342)
        Me.dtpto.Name = "dtpto"
        Me.dtpto.Size = New System.Drawing.Size(235, 20)
        Me.dtpto.TabIndex = 415
        '
        'dtpfrom
        '
        Me.dtpfrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfrom.Location = New System.Drawing.Point(71, 295)
        Me.dtpfrom.Name = "dtpfrom"
        Me.dtpfrom.Size = New System.Drawing.Size(235, 20)
        Me.dtpfrom.TabIndex = 414
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.BackColor = System.Drawing.Color.Transparent
        Me.btnExit.BackgroundImage = Global.SUPPLY.My.Resources.Resources.close_button
        Me.btnExit.FlatAppearance.BorderSize = 0
        Me.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit.Location = New System.Drawing.Point(313, 12)
        Me.btnExit.Margin = New System.Windows.Forms.Padding(3, 3, 10, 3)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(22, 22)
        Me.btnExit.TabIndex = 413
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'DRLIST_SEARCHBY
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(345, 466)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "DRLIST_SEARCHBY"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DRLIST_SEARCHBY"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cmbSortBy As ComboBox
    Friend WithEvents cmbEnableDateRange As ComboBox
    Friend WithEvents txtItems As TextBox
    Friend WithEvents cmbINOUT As ComboBox
    Friend WithEvents txtItemDesc As TextBox
    Friend WithEvents btnSearch As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnExit As Button
    Friend WithEvents dtpto As DateTimePicker
    Friend WithEvents dtpfrom As DateTimePicker
End Class
