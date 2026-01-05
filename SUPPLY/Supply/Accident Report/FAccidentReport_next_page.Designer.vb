<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FAccidentReport_next_page
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.gview_Unsafe_acts = New System.Windows.Forms.DataGridView()
        Me.lblUnsafe = New System.Windows.Forms.Label()
        Me.gview_unsafe_condition = New System.Windows.Forms.DataGridView()
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblUnsafe_conditions = New System.Windows.Forms.Label()
        Me.gview_mgt_syt_deficiency = New System.Windows.Forms.DataGridView()
        Me.DataGridViewCheckBoxColumn2 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblmgt_sys_deficiency = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.selects = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Unsafe_acts = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.gview_Unsafe_acts, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gview_unsafe_condition, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gview_mgt_syt_deficiency, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gview_Unsafe_acts
        '
        Me.gview_Unsafe_acts.AllowUserToAddRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gview_Unsafe_acts.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gview_Unsafe_acts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gview_Unsafe_acts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.selects, Me.Unsafe_acts, Me.Description})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.75!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gview_Unsafe_acts.DefaultCellStyle = DataGridViewCellStyle2
        Me.gview_Unsafe_acts.Location = New System.Drawing.Point(7, 26)
        Me.gview_Unsafe_acts.Name = "gview_Unsafe_acts"
        Me.gview_Unsafe_acts.Size = New System.Drawing.Size(706, 239)
        Me.gview_Unsafe_acts.TabIndex = 0
        '
        'lblUnsafe
        '
        Me.lblUnsafe.AutoSize = True
        Me.lblUnsafe.BackColor = System.Drawing.Color.Transparent
        Me.lblUnsafe.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnsafe.ForeColor = System.Drawing.Color.White
        Me.lblUnsafe.Location = New System.Drawing.Point(4, 7)
        Me.lblUnsafe.Name = "lblUnsafe"
        Me.lblUnsafe.Size = New System.Drawing.Size(91, 16)
        Me.lblUnsafe.TabIndex = 2
        Me.lblUnsafe.Text = "Unsafe Acts"
        '
        'gview_unsafe_condition
        '
        Me.gview_unsafe_condition.AllowUserToAddRows = False
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gview_unsafe_condition.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.gview_unsafe_condition.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gview_unsafe_condition.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewCheckBoxColumn1, Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gview_unsafe_condition.DefaultCellStyle = DataGridViewCellStyle4
        Me.gview_unsafe_condition.Location = New System.Drawing.Point(7, 290)
        Me.gview_unsafe_condition.Name = "gview_unsafe_condition"
        Me.gview_unsafe_condition.Size = New System.Drawing.Size(706, 239)
        Me.gview_unsafe_condition.TabIndex = 3
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.HeaderText = "Select"
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        Me.DataGridViewCheckBoxColumn1.Width = 60
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Unsafe Conditions"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 250
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Description"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 350
        '
        'lblUnsafe_conditions
        '
        Me.lblUnsafe_conditions.AutoSize = True
        Me.lblUnsafe_conditions.BackColor = System.Drawing.Color.Transparent
        Me.lblUnsafe_conditions.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnsafe_conditions.ForeColor = System.Drawing.Color.White
        Me.lblUnsafe_conditions.Location = New System.Drawing.Point(4, 271)
        Me.lblUnsafe_conditions.Name = "lblUnsafe_conditions"
        Me.lblUnsafe_conditions.Size = New System.Drawing.Size(134, 16)
        Me.lblUnsafe_conditions.TabIndex = 4
        Me.lblUnsafe_conditions.Text = "Unsafe Conditions"
        '
        'gview_mgt_syt_deficiency
        '
        Me.gview_mgt_syt_deficiency.AllowUserToAddRows = False
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gview_mgt_syt_deficiency.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.gview_mgt_syt_deficiency.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gview_mgt_syt_deficiency.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewCheckBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gview_mgt_syt_deficiency.DefaultCellStyle = DataGridViewCellStyle6
        Me.gview_mgt_syt_deficiency.Location = New System.Drawing.Point(7, 560)
        Me.gview_mgt_syt_deficiency.Name = "gview_mgt_syt_deficiency"
        Me.gview_mgt_syt_deficiency.Size = New System.Drawing.Size(706, 239)
        Me.gview_mgt_syt_deficiency.TabIndex = 5
        '
        'DataGridViewCheckBoxColumn2
        '
        Me.DataGridViewCheckBoxColumn2.HeaderText = "Select"
        Me.DataGridViewCheckBoxColumn2.Name = "DataGridViewCheckBoxColumn2"
        Me.DataGridViewCheckBoxColumn2.Width = 60
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Management System Deficiencies"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 250
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Description"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 350
        '
        'lblmgt_sys_deficiency
        '
        Me.lblmgt_sys_deficiency.AutoSize = True
        Me.lblmgt_sys_deficiency.BackColor = System.Drawing.Color.Transparent
        Me.lblmgt_sys_deficiency.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblmgt_sys_deficiency.ForeColor = System.Drawing.Color.White
        Me.lblmgt_sys_deficiency.Location = New System.Drawing.Point(4, 541)
        Me.lblmgt_sys_deficiency.Name = "lblmgt_sys_deficiency"
        Me.lblmgt_sys_deficiency.Size = New System.Drawing.Size(242, 16)
        Me.lblmgt_sys_deficiency.TabIndex = 6
        Me.lblmgt_sys_deficiency.Text = "Management System Deficiencies"
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(7, 805)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(139, 40)
        Me.btnSave.TabIndex = 7
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'selects
        '
        Me.selects.HeaderText = "Select"
        Me.selects.Name = "selects"
        Me.selects.Width = 60
        '
        'Unsafe_acts
        '
        Me.Unsafe_acts.HeaderText = "Unsafe Acts"
        Me.Unsafe_acts.Name = "Unsafe_acts"
        Me.Unsafe_acts.ReadOnly = True
        Me.Unsafe_acts.Width = 250
        '
        'Description
        '
        Me.Description.HeaderText = "Description"
        Me.Description.Name = "Description"
        Me.Description.Width = 350
        '
        'FAccidentReport_next_page
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SUPPLY.My.Resources.Resources.bg_line
        Me.ClientSize = New System.Drawing.Size(721, 849)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.lblmgt_sys_deficiency)
        Me.Controls.Add(Me.gview_mgt_syt_deficiency)
        Me.Controls.Add(Me.lblUnsafe_conditions)
        Me.Controls.Add(Me.gview_unsafe_condition)
        Me.Controls.Add(Me.lblUnsafe)
        Me.Controls.Add(Me.gview_Unsafe_acts)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "FAccidentReport_next_page"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FAccidentReport_next_page"
        CType(Me.gview_Unsafe_acts, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gview_unsafe_condition, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gview_mgt_syt_deficiency, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents gview_Unsafe_acts As DataGridView
    Friend WithEvents lblUnsafe As Label
    Friend WithEvents gview_unsafe_condition As DataGridView
    Friend WithEvents lblUnsafe_conditions As Label
    Friend WithEvents gview_mgt_syt_deficiency As DataGridView
    Friend WithEvents lblmgt_sys_deficiency As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents DataGridViewCheckBoxColumn1 As DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn2 As DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents selects As DataGridViewCheckBoxColumn
    Friend WithEvents Unsafe_acts As DataGridViewTextBoxColumn
    Friend WithEvents Description As DataGridViewTextBoxColumn
End Class
