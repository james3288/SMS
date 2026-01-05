<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FMonthlyProjectCost
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
        Me.Label15 = New System.Windows.Forms.Label()
        Me.btn_preview = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel = New System.Windows.Forms.Panel()
        Me.Lbx_namelist = New System.Windows.Forms.ListBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.btn_proceed = New System.Windows.Forms.Button()
        Me.txt_approvedby = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_preparedby = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DTG_MontlyProjectCost = New System.Windows.Forms.DataGridView()
        Me.ProjectCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ACTUAL_TOTAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ACTUAL_MATERIALS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ACTUAL_EQPT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ACTUAL_MISC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ACTUAL_LABOR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BUDGETARY_TOTAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BUD_MATERIAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BUD_EQPT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BUD_LABOR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BUD_MISC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PAE_TOTAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PAE_MAT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PAE_EQPT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PAE_LABOR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PAE_MISC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PROJECT_ACCOPM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel.SuspendLayout()
        CType(Me.DTG_MontlyProjectCost, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(11, 9)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(167, 22)
        Me.Label15.TabIndex = 325
        Me.Label15.Text = "Monthly Project Cost"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_preview
        '
        Me.btn_preview.Location = New System.Drawing.Point(12, 861)
        Me.btn_preview.Name = "btn_preview"
        Me.btn_preview.Size = New System.Drawing.Size(92, 30)
        Me.btn_preview.TabIndex = 328
        Me.btn_preview.Text = "Preview"
        Me.btn_preview.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(1352, 861)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(92, 30)
        Me.Button1.TabIndex = 329
        Me.Button1.Text = "Print"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Panel
        '
        Me.Panel.BackColor = System.Drawing.Color.Transparent
        Me.Panel.Controls.Add(Me.Lbx_namelist)
        Me.Panel.Controls.Add(Me.Button3)
        Me.Panel.Controls.Add(Me.btn_proceed)
        Me.Panel.Controls.Add(Me.txt_approvedby)
        Me.Panel.Controls.Add(Me.Label4)
        Me.Panel.Controls.Add(Me.txt_preparedby)
        Me.Panel.Controls.Add(Me.Label5)
        Me.Panel.Location = New System.Drawing.Point(631, 357)
        Me.Panel.Name = "Panel"
        Me.Panel.Size = New System.Drawing.Size(266, 184)
        Me.Panel.TabIndex = 330
        Me.Panel.Visible = False
        '
        'Lbx_namelist
        '
        Me.Lbx_namelist.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbx_namelist.FormattingEnabled = True
        Me.Lbx_namelist.ItemHeight = 16
        Me.Lbx_namelist.Location = New System.Drawing.Point(277, 50)
        Me.Lbx_namelist.Name = "Lbx_namelist"
        Me.Lbx_namelist.Size = New System.Drawing.Size(227, 68)
        Me.Lbx_namelist.TabIndex = 138
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Transparent
        Me.Button3.BackgroundImage = Global.SUPPLY.My.Resources.Resources.close_button
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Location = New System.Drawing.Point(223, 3)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(23, 22)
        Me.Button3.TabIndex = 135
        Me.Button3.UseVisualStyleBackColor = False
        '
        'btn_proceed
        '
        Me.btn_proceed.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_proceed.Location = New System.Drawing.Point(148, 140)
        Me.btn_proceed.Name = "btn_proceed"
        Me.btn_proceed.Size = New System.Drawing.Size(98, 32)
        Me.btn_proceed.TabIndex = 3
        Me.btn_proceed.Text = "Proceed"
        Me.btn_proceed.UseVisualStyleBackColor = True
        '
        'txt_approvedby
        '
        Me.txt_approvedby.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_approvedby.Location = New System.Drawing.Point(19, 103)
        Me.txt_approvedby.Name = "txt_approvedby"
        Me.txt_approvedby.Size = New System.Drawing.Size(227, 22)
        Me.txt_approvedby.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(16, 84)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 13)
        Me.Label4.TabIndex = 135
        Me.Label4.Text = "Approved by:"
        '
        'txt_preparedby
        '
        Me.txt_preparedby.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_preparedby.Location = New System.Drawing.Point(19, 50)
        Me.txt_preparedby.Name = "txt_preparedby"
        Me.txt_preparedby.Size = New System.Drawing.Size(227, 22)
        Me.txt_preparedby.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(19, 31)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 13)
        Me.Label5.TabIndex = 135
        Me.Label5.Text = "Prepared by:"
        '
        'DTG_MontlyProjectCost
        '
        Me.DTG_MontlyProjectCost.AllowUserToAddRows = False
        Me.DTG_MontlyProjectCost.AllowUserToDeleteRows = False
        Me.DTG_MontlyProjectCost.AllowUserToOrderColumns = True
        Me.DTG_MontlyProjectCost.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DTG_MontlyProjectCost.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ProjectCode, Me.ACTUAL_TOTAL, Me.ACTUAL_MATERIALS, Me.ACTUAL_EQPT, Me.ACTUAL_MISC, Me.ACTUAL_LABOR, Me.BUDGETARY_TOTAL, Me.BUD_MATERIAL, Me.BUD_EQPT, Me.BUD_LABOR, Me.BUD_MISC, Me.PAE_TOTAL, Me.PAE_MAT, Me.PAE_EQPT, Me.PAE_LABOR, Me.PAE_MISC, Me.PROJECT_ACCOPM})
        Me.DTG_MontlyProjectCost.Location = New System.Drawing.Point(15, 55)
        Me.DTG_MontlyProjectCost.Name = "DTG_MontlyProjectCost"
        Me.DTG_MontlyProjectCost.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DTG_MontlyProjectCost.Size = New System.Drawing.Size(1309, 790)
        Me.DTG_MontlyProjectCost.TabIndex = 331
        '
        'ProjectCode
        '
        Me.ProjectCode.HeaderText = "PROJECT CODE"
        Me.ProjectCode.Name = "ProjectCode"
        Me.ProjectCode.ReadOnly = True
        '
        'ACTUAL_TOTAL
        '
        Me.ACTUAL_TOTAL.HeaderText = "ACTUAL(TOTAL)"
        Me.ACTUAL_TOTAL.Name = "ACTUAL_TOTAL"
        Me.ACTUAL_TOTAL.ReadOnly = True
        '
        'ACTUAL_MATERIALS
        '
        Me.ACTUAL_MATERIALS.HeaderText = "ACTUAL(MATERIALS)"
        Me.ACTUAL_MATERIALS.Name = "ACTUAL_MATERIALS"
        Me.ACTUAL_MATERIALS.ReadOnly = True
        '
        'ACTUAL_EQPT
        '
        Me.ACTUAL_EQPT.HeaderText = "ACTUAL(EQPT)"
        Me.ACTUAL_EQPT.Name = "ACTUAL_EQPT"
        Me.ACTUAL_EQPT.ReadOnly = True
        '
        'ACTUAL_MISC
        '
        Me.ACTUAL_MISC.HeaderText = "ACTUAL(MISC.)"
        Me.ACTUAL_MISC.Name = "ACTUAL_MISC"
        Me.ACTUAL_MISC.ReadOnly = True
        '
        'ACTUAL_LABOR
        '
        Me.ACTUAL_LABOR.HeaderText = "ACTUAL(LABOR)"
        Me.ACTUAL_LABOR.Name = "ACTUAL_LABOR"
        Me.ACTUAL_LABOR.ReadOnly = True
        '
        'BUDGETARY_TOTAL
        '
        Me.BUDGETARY_TOTAL.HeaderText = "BUDGETARY(TOTAL)"
        Me.BUDGETARY_TOTAL.Name = "BUDGETARY_TOTAL"
        Me.BUDGETARY_TOTAL.ReadOnly = True
        '
        'BUD_MATERIAL
        '
        Me.BUD_MATERIAL.HeaderText = "BUDGETARY(MATERIAL)"
        Me.BUD_MATERIAL.Name = "BUD_MATERIAL"
        Me.BUD_MATERIAL.ReadOnly = True
        '
        'BUD_EQPT
        '
        Me.BUD_EQPT.HeaderText = "BUDGETARY(EQPT)"
        Me.BUD_EQPT.Name = "BUD_EQPT"
        Me.BUD_EQPT.ReadOnly = True
        '
        'BUD_LABOR
        '
        Me.BUD_LABOR.HeaderText = "BUDGETARY(LABOR)"
        Me.BUD_LABOR.Name = "BUD_LABOR"
        Me.BUD_LABOR.ReadOnly = True
        '
        'BUD_MISC
        '
        Me.BUD_MISC.HeaderText = "BUDGETARY(MISC)"
        Me.BUD_MISC.Name = "BUD_MISC"
        Me.BUD_MISC.ReadOnly = True
        '
        'PAE_TOTAL
        '
        Me.PAE_TOTAL.HeaderText = "PAE TOTAL"
        Me.PAE_TOTAL.Name = "PAE_TOTAL"
        Me.PAE_TOTAL.ReadOnly = True
        '
        'PAE_MAT
        '
        Me.PAE_MAT.HeaderText = "PAE MATERIAL"
        Me.PAE_MAT.Name = "PAE_MAT"
        Me.PAE_MAT.ReadOnly = True
        '
        'PAE_EQPT
        '
        Me.PAE_EQPT.HeaderText = "PAE EQPT"
        Me.PAE_EQPT.Name = "PAE_EQPT"
        Me.PAE_EQPT.ReadOnly = True
        '
        'PAE_LABOR
        '
        Me.PAE_LABOR.HeaderText = "PAE LABOR"
        Me.PAE_LABOR.Name = "PAE_LABOR"
        Me.PAE_LABOR.ReadOnly = True
        '
        'PAE_MISC
        '
        Me.PAE_MISC.HeaderText = "PAE MISC"
        Me.PAE_MISC.Name = "PAE_MISC"
        Me.PAE_MISC.ReadOnly = True
        '
        'PROJECT_ACCOPM
        '
        Me.PROJECT_ACCOPM.HeaderText = "PROJECT ACCOMP"
        Me.PROJECT_ACCOPM.Name = "PROJECT_ACCOPM"
        '
        'FMonthlyProjectCost
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SUPPLY.My.Resources.Resources.bg_line
        Me.ClientSize = New System.Drawing.Size(1455, 903)
        Me.Controls.Add(Me.Panel)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btn_preview)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.DTG_MontlyProjectCost)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FMonthlyProjectCost"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FMonthlyProjectCost"
        Me.Panel.ResumeLayout(False)
        Me.Panel.PerformLayout()
        CType(Me.DTG_MontlyProjectCost, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label15 As Label
    Friend WithEvents btn_preview As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Panel As Panel
    Friend WithEvents Lbx_namelist As ListBox
    Friend WithEvents Button3 As Button
    Friend WithEvents btn_proceed As Button
    Friend WithEvents txt_approvedby As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txt_preparedby As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents DTG_MontlyProjectCost As DataGridView
    Friend WithEvents ProjectCode As DataGridViewTextBoxColumn
    Friend WithEvents ACTUAL_TOTAL As DataGridViewTextBoxColumn
    Friend WithEvents ACTUAL_MATERIALS As DataGridViewTextBoxColumn
    Friend WithEvents ACTUAL_EQPT As DataGridViewTextBoxColumn
    Friend WithEvents ACTUAL_MISC As DataGridViewTextBoxColumn
    Friend WithEvents ACTUAL_LABOR As DataGridViewTextBoxColumn
    Friend WithEvents BUDGETARY_TOTAL As DataGridViewTextBoxColumn
    Friend WithEvents BUD_MATERIAL As DataGridViewTextBoxColumn
    Friend WithEvents BUD_EQPT As DataGridViewTextBoxColumn
    Friend WithEvents BUD_LABOR As DataGridViewTextBoxColumn
    Friend WithEvents BUD_MISC As DataGridViewTextBoxColumn
    Friend WithEvents PAE_TOTAL As DataGridViewTextBoxColumn
    Friend WithEvents PAE_MAT As DataGridViewTextBoxColumn
    Friend WithEvents PAE_EQPT As DataGridViewTextBoxColumn
    Friend WithEvents PAE_LABOR As DataGridViewTextBoxColumn
    Friend WithEvents PAE_MISC As DataGridViewTextBoxColumn
    Friend WithEvents PROJECT_ACCOPM As DataGridViewTextBoxColumn
End Class
