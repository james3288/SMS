<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FEditPrice
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
        Me.txtPrice = New System.Windows.Forms.TextBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtreceivedby = New System.Windows.Forms.TextBox()
        Me.lboxUnit = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'txtPrice
        '
        Me.txtPrice.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrice.Location = New System.Drawing.Point(12, 25)
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.Size = New System.Drawing.Size(172, 26)
        Me.txtPrice.TabIndex = 0
        Me.txtPrice.Text = "0"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(12, 112)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(172, 30)
        Me.btnSave.TabIndex = 4
        Me.btnSave.Text = "Update"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Price:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Received By:"
        '
        'txtreceivedby
        '
        Me.txtreceivedby.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtreceivedby.Location = New System.Drawing.Point(12, 78)
        Me.txtreceivedby.Name = "txtreceivedby"
        Me.txtreceivedby.Size = New System.Drawing.Size(172, 26)
        Me.txtreceivedby.TabIndex = 1
        '
        'lboxUnit
        '
        Me.lboxUnit.FormattingEnabled = True
        Me.lboxUnit.Location = New System.Drawing.Point(12, 148)
        Me.lboxUnit.Name = "lboxUnit"
        Me.lboxUnit.Size = New System.Drawing.Size(172, 56)
        Me.lboxUnit.TabIndex = 3
        Me.lboxUnit.Visible = False
        '
        'FEditPrice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(196, 164)
        Me.Controls.Add(Me.lboxUnit)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtreceivedby)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtPrice)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FEditPrice"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FEditPrice"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtPrice As TextBox
    Friend WithEvents btnSave As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtreceivedby As TextBox
    Friend WithEvents lboxUnit As ListBox
End Class
