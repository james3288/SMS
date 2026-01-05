<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FBorrowerMultipleCharges
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
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cmbTypeofCharge = New System.Windows.Forms.ComboBox()
        Me.lvlList = New System.Windows.Forms.ListView()
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(405, 331)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(144, 31)
        Me.btnSave.TabIndex = 396
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(9, 10)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(110, 16)
        Me.Label15.TabIndex = 395
        Me.Label15.Text = "Where to Charge:"
        '
        'cmbTypeofCharge
        '
        Me.cmbTypeofCharge.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTypeofCharge.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTypeofCharge.FormattingEnabled = True
        Me.cmbTypeofCharge.Items.AddRange(New Object() {"PROJECT", "PERSONAL", "EQUIPMENT", "MAINOFFICE", "WAREHOUSE", "OTHERS"})
        Me.cmbTypeofCharge.Location = New System.Drawing.Point(12, 28)
        Me.cmbTypeofCharge.Name = "cmbTypeofCharge"
        Me.cmbTypeofCharge.Size = New System.Drawing.Size(335, 24)
        Me.cmbTypeofCharge.TabIndex = 394
        '
        'lvlList
        '
        Me.lvlList.CheckBoxes = True
        Me.lvlList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader2, Me.ColumnHeader5, Me.ColumnHeader6})
        Me.lvlList.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvlList.FullRowSelect = True
        Me.lvlList.GridLines = True
        Me.lvlList.HideSelection = False
        Me.lvlList.Location = New System.Drawing.Point(12, 58)
        Me.lvlList.Name = "lvlList"
        Me.lvlList.Size = New System.Drawing.Size(538, 267)
        Me.lvlList.TabIndex = 393
        Me.lvlList.UseCompatibleStateImageBehavior = False
        Me.lvlList.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "proj_id"
        Me.ColumnHeader2.Width = 62
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Project Desc"
        Me.ColumnHeader5.Width = 269
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Type"
        Me.ColumnHeader6.Width = 203
        '
        'FBorrowerMultipleCharges
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(564, 373)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.cmbTypeofCharge)
        Me.Controls.Add(Me.lvlList)
        Me.Name = "FBorrowerMultipleCharges"
        Me.Text = "FBorrowerMultipleCharges"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnSave As Button
    Friend WithEvents Label15 As Label
    Friend WithEvents cmbTypeofCharge As ComboBox
    Friend WithEvents lvlList As ListView
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
End Class
