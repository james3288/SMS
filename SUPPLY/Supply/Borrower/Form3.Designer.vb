<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3
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
        Me.btn_proceed = New System.Windows.Forms.Button()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.panel_btn_close = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtset = New System.Windows.Forms.TextBox()
        Me.btnSet = New System.Windows.Forms.Button()
        Me.gboxBorrowerMonitoringSearch = New System.Windows.Forms.GroupBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.btnBMsearch = New System.Windows.Forms.Button()
        Me.cmbSearchBy = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Panel5.SuspendLayout()
        Me.gboxBorrowerMonitoringSearch.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_proceed
        '
        Me.btn_proceed.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_proceed.Location = New System.Drawing.Point(339, 113)
        Me.btn_proceed.Name = "btn_proceed"
        Me.btn_proceed.Size = New System.Drawing.Size(124, 34)
        Me.btn_proceed.TabIndex = 443
        Me.btn_proceed.Text = "Proceed"
        Me.btn_proceed.UseVisualStyleBackColor = True
        '
        'Panel5
        '
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.panel_btn_close)
        Me.Panel5.Controls.Add(Me.Label1)
        Me.Panel5.Controls.Add(Me.txtset)
        Me.Panel5.Controls.Add(Me.btnSet)
        Me.Panel5.Location = New System.Drawing.Point(72, 113)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(211, 136)
        Me.Panel5.TabIndex = 444
        Me.Panel5.Visible = False
        '
        'panel_btn_close
        '
        Me.panel_btn_close.Location = New System.Drawing.Point(174, 3)
        Me.panel_btn_close.Name = "panel_btn_close"
        Me.panel_btn_close.Size = New System.Drawing.Size(32, 23)
        Me.panel_btn_close.TabIndex = 3
        Me.panel_btn_close.Text = "x"
        Me.panel_btn_close.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.panel_btn_close.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Item No."
        '
        'txtset
        '
        Me.txtset.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtset.Location = New System.Drawing.Point(13, 50)
        Me.txtset.Name = "txtset"
        Me.txtset.Size = New System.Drawing.Size(183, 22)
        Me.txtset.TabIndex = 1
        Me.txtset.Text = "0"
        '
        'btnSet
        '
        Me.btnSet.Location = New System.Drawing.Point(13, 83)
        Me.btnSet.Name = "btnSet"
        Me.btnSet.Size = New System.Drawing.Size(183, 38)
        Me.btnSet.TabIndex = 0
        Me.btnSet.Text = "Set"
        Me.btnSet.UseVisualStyleBackColor = True
        '
        'gboxBorrowerMonitoringSearch
        '
        Me.gboxBorrowerMonitoringSearch.BackColor = System.Drawing.Color.Transparent
        Me.gboxBorrowerMonitoringSearch.Controls.Add(Me.ComboBox1)
        Me.gboxBorrowerMonitoringSearch.Controls.Add(Me.btnBMsearch)
        Me.gboxBorrowerMonitoringSearch.Controls.Add(Me.cmbSearchBy)
        Me.gboxBorrowerMonitoringSearch.Controls.Add(Me.Label20)
        Me.gboxBorrowerMonitoringSearch.Location = New System.Drawing.Point(63, 33)
        Me.gboxBorrowerMonitoringSearch.Name = "gboxBorrowerMonitoringSearch"
        Me.gboxBorrowerMonitoringSearch.Size = New System.Drawing.Size(747, 47)
        Me.gboxBorrowerMonitoringSearch.TabIndex = 445
        Me.gboxBorrowerMonitoringSearch.TabStop = False
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBox1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(304, 14)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(278, 24)
        Me.ComboBox1.TabIndex = 440
        '
        'btnBMsearch
        '
        Me.btnBMsearch.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBMsearch.Location = New System.Drawing.Point(588, 13)
        Me.btnBMsearch.Name = "btnBMsearch"
        Me.btnBMsearch.Size = New System.Drawing.Size(144, 25)
        Me.btnBMsearch.TabIndex = 439
        Me.btnBMsearch.Text = "Search"
        Me.btnBMsearch.UseVisualStyleBackColor = True
        '
        'cmbSearchBy
        '
        Me.cmbSearchBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSearchBy.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbSearchBy.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSearchBy.FormattingEnabled = True
        Me.cmbSearchBy.Items.AddRange(New Object() {"FACILITIES", "TOOLS"})
        Me.cmbSearchBy.Location = New System.Drawing.Point(131, 14)
        Me.cmbSearchBy.Name = "cmbSearchBy"
        Me.cmbSearchBy.Size = New System.Drawing.Size(167, 24)
        Me.cmbSearchBy.TabIndex = 396
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(7, 18)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(121, 15)
        Me.Label20.TabIndex = 399
        Me.Label20.Text = "Search by Category:"
        '
        'Form3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(802, 261)
        Me.Controls.Add(Me.gboxBorrowerMonitoringSearch)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.btn_proceed)
        Me.Name = "Form3"
        Me.Text = "Form3"
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.gboxBorrowerMonitoringSearch.ResumeLayout(False)
        Me.gboxBorrowerMonitoringSearch.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_proceed As Button
    Friend WithEvents Panel5 As Panel
    Friend WithEvents panel_btn_close As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtset As TextBox
    Friend WithEvents btnSet As Button
    Friend WithEvents gboxBorrowerMonitoringSearch As GroupBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents btnBMsearch As Button
    Friend WithEvents cmbSearchBy As ComboBox
    Friend WithEvents Label20 As Label
End Class
