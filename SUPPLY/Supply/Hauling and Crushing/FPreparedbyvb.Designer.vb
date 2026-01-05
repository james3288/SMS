<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FPreparedbyvb
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
        Me.BtnPreview = New System.Windows.Forms.Button()
        Me.txtnoted = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPrepared = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtpMonthOf = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbl_job_position_prepared_by = New System.Windows.Forms.Label()
        Me.lbl_noted_by = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'BtnPreview
        '
        Me.BtnPreview.BackColor = System.Drawing.Color.Transparent
        Me.BtnPreview.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPreview.Location = New System.Drawing.Point(12, 171)
        Me.BtnPreview.Name = "BtnPreview"
        Me.BtnPreview.Size = New System.Drawing.Size(243, 32)
        Me.BtnPreview.TabIndex = 159
        Me.BtnPreview.Text = "Preview"
        Me.BtnPreview.UseVisualStyleBackColor = False
        '
        'txtnoted
        '
        Me.txtnoted.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnoted.Location = New System.Drawing.Point(15, 83)
        Me.txtnoted.Name = "txtnoted"
        Me.txtnoted.Size = New System.Drawing.Size(240, 26)
        Me.txtnoted.TabIndex = 163
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(12, 64)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(163, 16)
        Me.Label4.TabIndex = 162
        Me.Label4.Text = "Noted and Verified by:"
        '
        'txtPrepared
        '
        Me.txtPrepared.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrepared.Location = New System.Drawing.Point(15, 28)
        Me.txtPrepared.Name = "txtPrepared"
        Me.txtPrepared.Size = New System.Drawing.Size(240, 26)
        Me.txtPrepared.TabIndex = 160
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(12, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(98, 16)
        Me.Label7.TabIndex = 161
        Me.Label7.Text = "Prepared by:"
        '
        'dtpMonthOf
        '
        Me.dtpMonthOf.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpMonthOf.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpMonthOf.Location = New System.Drawing.Point(12, 136)
        Me.dtpMonthOf.Name = "dtpMonthOf"
        Me.dtpMonthOf.Size = New System.Drawing.Size(243, 26)
        Me.dtpMonthOf.TabIndex = 164
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(12, 116)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 16)
        Me.Label1.TabIndex = 165
        Me.Label1.Text = "Month of:"
        '
        'lbl_job_position_prepared_by
        '
        Me.lbl_job_position_prepared_by.AutoSize = True
        Me.lbl_job_position_prepared_by.Location = New System.Drawing.Point(378, 63)
        Me.lbl_job_position_prepared_by.Name = "lbl_job_position_prepared_by"
        Me.lbl_job_position_prepared_by.Size = New System.Drawing.Size(66, 13)
        Me.lbl_job_position_prepared_by.TabIndex = 166
        Me.lbl_job_position_prepared_by.Text = "prepared_by"
        Me.lbl_job_position_prepared_by.Visible = False
        '
        'lbl_noted_by
        '
        Me.lbl_noted_by.AutoSize = True
        Me.lbl_noted_by.Location = New System.Drawing.Point(378, 116)
        Me.lbl_noted_by.Name = "lbl_noted_by"
        Me.lbl_noted_by.Size = New System.Drawing.Size(51, 13)
        Me.lbl_noted_by.TabIndex = 167
        Me.lbl_noted_by.Text = "noted_by"
        Me.lbl_noted_by.Visible = False
        '
        'FPreparedbyvb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(273, 215)
        Me.Controls.Add(Me.lbl_noted_by)
        Me.Controls.Add(Me.lbl_job_position_prepared_by)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpMonthOf)
        Me.Controls.Add(Me.BtnPreview)
        Me.Controls.Add(Me.txtnoted)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtPrepared)
        Me.Controls.Add(Me.Label7)
        Me.Name = "FPreparedbyvb"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FPreparedbyvb"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnPreview As Button
    Friend WithEvents txtnoted As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtPrepared As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents dtpMonthOf As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents lbl_job_position_prepared_by As Label
    Friend WithEvents lbl_noted_by As Label
End Class
