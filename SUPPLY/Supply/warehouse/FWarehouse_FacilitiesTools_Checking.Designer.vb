<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FWarehouse_FacilitiesTools_Checking
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
        Me.cmb_select_typeof_checking = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Group_checking = New System.Windows.Forms.GroupBox()
        Me.btn_Ok = New System.Windows.Forms.Button()
        Me.Group_checking.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmb_select_typeof_checking
        '
        Me.cmb_select_typeof_checking.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_select_typeof_checking.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_select_typeof_checking.FormattingEnabled = True
        Me.cmb_select_typeof_checking.Items.AddRange(New Object() {"Facilities/Tools Checking", "Items Checking", "Items Set"})
        Me.cmb_select_typeof_checking.Location = New System.Drawing.Point(10, 44)
        Me.cmb_select_typeof_checking.Name = "cmb_select_typeof_checking"
        Me.cmb_select_typeof_checking.Size = New System.Drawing.Size(183, 24)
        Me.cmb_select_typeof_checking.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label1.Location = New System.Drawing.Point(7, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Options:"
        '
        'Group_checking
        '
        Me.Group_checking.Controls.Add(Me.btn_Ok)
        Me.Group_checking.Controls.Add(Me.cmb_select_typeof_checking)
        Me.Group_checking.Controls.Add(Me.Label1)
        Me.Group_checking.Location = New System.Drawing.Point(2, 3)
        Me.Group_checking.Name = "Group_checking"
        Me.Group_checking.Size = New System.Drawing.Size(206, 114)
        Me.Group_checking.TabIndex = 2
        Me.Group_checking.TabStop = False
        Me.Group_checking.Text = "Checking"
        '
        'btn_Ok
        '
        Me.btn_Ok.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Ok.Location = New System.Drawing.Point(100, 74)
        Me.btn_Ok.Name = "btn_Ok"
        Me.btn_Ok.Size = New System.Drawing.Size(93, 28)
        Me.btn_Ok.TabIndex = 4
        Me.btn_Ok.Text = "OK"
        Me.btn_Ok.UseVisualStyleBackColor = True
        '
        'FWarehouse_FacilitiesTools_Checking
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(212, 120)
        Me.Controls.Add(Me.Group_checking)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FWarehouse_FacilitiesTools_Checking"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Group_checking.ResumeLayout(False)
        Me.Group_checking.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmb_select_typeof_checking As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Group_checking As System.Windows.Forms.GroupBox
    Friend WithEvents btn_Ok As System.Windows.Forms.Button
End Class
