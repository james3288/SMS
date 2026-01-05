<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FCreateCharges
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
        Me.lvlListofCharges = New System.Windows.Forms.ListView()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lvlList = New System.Windows.Forms.ListView()
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cmbTypeofCharge = New System.Windows.Forms.ComboBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.lbl_bs_status = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lvlListofCharges
        '
        Me.lvlListofCharges.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader1})
        Me.lvlListofCharges.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvlListofCharges.FullRowSelect = True
        Me.lvlListofCharges.GridLines = True
        Me.lvlListofCharges.HideSelection = False
        Me.lvlListofCharges.Location = New System.Drawing.Point(12, 38)
        Me.lvlListofCharges.Name = "lvlListofCharges"
        Me.lvlListofCharges.Size = New System.Drawing.Size(538, 169)
        Me.lvlListofCharges.TabIndex = 1
        Me.lvlListofCharges.UseCompatibleStateImageBehavior = False
        Me.lvlListofCharges.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Charge_id"
        Me.ColumnHeader3.Width = 62
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Charges Name"
        Me.ColumnHeader4.Width = 269
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Type"
        Me.ColumnHeader1.Width = 203
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(199, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Request Intended for this project:"
        '
        'lvlList
        '
        Me.lvlList.CheckBoxes = True
        Me.lvlList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader2, Me.ColumnHeader5, Me.ColumnHeader6})
        Me.lvlList.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvlList.FullRowSelect = True
        Me.lvlList.GridLines = True
        Me.lvlList.HideSelection = False
        Me.lvlList.Location = New System.Drawing.Point(12, 274)
        Me.lvlList.Name = "lvlList"
        Me.lvlList.Size = New System.Drawing.Size(538, 267)
        Me.lvlList.TabIndex = 3
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
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(9, 226)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(110, 16)
        Me.Label15.TabIndex = 391
        Me.Label15.Text = "Where to Charge:"
        '
        'cmbTypeofCharge
        '
        Me.cmbTypeofCharge.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTypeofCharge.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTypeofCharge.FormattingEnabled = True
        Me.cmbTypeofCharge.Items.AddRange(New Object() {"PROJECT", "PERSONAL", "EQUIPMENT", "MAINOFFICE", "WAREHOUSE", "OTHERS"})
        Me.cmbTypeofCharge.Location = New System.Drawing.Point(12, 244)
        Me.cmbTypeofCharge.Name = "cmbTypeofCharge"
        Me.cmbTypeofCharge.Size = New System.Drawing.Size(335, 24)
        Me.cmbTypeofCharge.TabIndex = 390
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(405, 547)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(144, 31)
        Me.btnSave.TabIndex = 392
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'lbl_bs_status
        '
        Me.lbl_bs_status.AutoSize = True
        Me.lbl_bs_status.Location = New System.Drawing.Point(428, 244)
        Me.lbl_bs_status.Name = "lbl_bs_status"
        Me.lbl_bs_status.Size = New System.Drawing.Size(68, 13)
        Me.lbl_bs_status.TabIndex = 393
        Me.lbl_bs_status.Text = "lbl_bs_status"
        '
        'FCreateCharges
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(564, 586)
        Me.Controls.Add(Me.lbl_bs_status)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.cmbTypeofCharge)
        Me.Controls.Add(Me.lvlList)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lvlListofCharges)
        Me.Name = "FCreateCharges"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FCreateCharges"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lvlListofCharges As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lvlList As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cmbTypeofCharge As System.Windows.Forms.ComboBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents lbl_bs_status As System.Windows.Forms.Label
End Class
