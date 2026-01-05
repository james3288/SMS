<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditDR1
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
        Me.txtSpecificColumn = New System.Windows.Forms.TextBox()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.cmbOperator = New System.Windows.Forms.ComboBox()
        Me.dtpDrDate = New System.Windows.Forms.DateTimePicker()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.lboxUnit = New System.Windows.Forms.ListBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtSpecificColumn
        '
        Me.txtSpecificColumn.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSpecificColumn.Location = New System.Drawing.Point(48, 11)
        Me.txtSpecificColumn.Name = "txtSpecificColumn"
        Me.txtSpecificColumn.Size = New System.Drawing.Size(259, 26)
        Me.txtSpecificColumn.TabIndex = 0
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.cmbOperator)
        Me.FlowLayoutPanel1.Controls.Add(Me.Panel1)
        Me.FlowLayoutPanel1.Controls.Add(Me.dtpDrDate)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnUpdate)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(3, 12)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(320, 159)
        Me.FlowLayoutPanel1.TabIndex = 5
        '
        'cmbOperator
        '
        Me.cmbOperator.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOperator.FormattingEnabled = True
        Me.cmbOperator.Location = New System.Drawing.Point(3, 3)
        Me.cmbOperator.Name = "cmbOperator"
        Me.cmbOperator.Size = New System.Drawing.Size(310, 28)
        Me.cmbOperator.TabIndex = 1
        '
        'dtpDrDate
        '
        Me.dtpDrDate.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDrDate.Location = New System.Drawing.Point(3, 89)
        Me.dtpDrDate.Name = "dtpDrDate"
        Me.dtpDrDate.Size = New System.Drawing.Size(310, 22)
        Me.dtpDrDate.TabIndex = 2
        '
        'btnUpdate
        '
        Me.btnUpdate.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.Location = New System.Drawing.Point(3, 117)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(310, 34)
        Me.btnUpdate.TabIndex = 3
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'lboxUnit
        '
        Me.lboxUnit.FormattingEnabled = True
        Me.lboxUnit.Location = New System.Drawing.Point(12, 188)
        Me.lboxUnit.Name = "lboxUnit"
        Me.lboxUnit.Size = New System.Drawing.Size(250, 82)
        Me.lboxUnit.TabIndex = 6
        Me.lboxUnit.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtSpecificColumn)
        Me.Panel1.Location = New System.Drawing.Point(3, 37)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(310, 46)
        Me.Panel1.TabIndex = 4
        '
        'EditDR1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(328, 179)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.lboxUnit)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "EditDR1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "EditDR1"
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents txtSpecificColumn As TextBox
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents cmbOperator As ComboBox
    Friend WithEvents dtpDrDate As DateTimePicker
    Friend WithEvents btnUpdate As Button
    Friend WithEvents lboxUnit As ListBox
    Friend WithEvents Panel1 As Panel
End Class
