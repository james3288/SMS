<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FProjectIncharge
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
        Me.btnOk = New System.Windows.Forms.Button()
        Me.lvlListofCharges = New System.Windows.Forms.ListView()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lblItemName = New System.Windows.Forms.Label()
        Me.btnView = New System.Windows.Forms.Button()
        Me.lbl_rs_id = New System.Windows.Forms.Label()
        Me.lbl_sign = New System.Windows.Forms.Label()
        Me.cmbTypeOfCharge = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(426, 458)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(129, 29)
        Me.btnOk.TabIndex = 1
        Me.btnOk.Text = "OK"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'lvlListofCharges
        '
        Me.lvlListofCharges.CheckBoxes = True
        Me.lvlListofCharges.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader1})
        Me.lvlListofCharges.FullRowSelect = True
        Me.lvlListofCharges.GridLines = True
        Me.lvlListofCharges.HideSelection = False
        Me.lvlListofCharges.Location = New System.Drawing.Point(17, 102)
        Me.lvlListofCharges.Name = "lvlListofCharges"
        Me.lvlListofCharges.Size = New System.Drawing.Size(538, 350)
        Me.lvlListofCharges.TabIndex = 0
        Me.lvlListofCharges.UseCompatibleStateImageBehavior = False
        Me.lvlListofCharges.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "proj_id"
        Me.ColumnHeader3.Width = 62
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Project Desc"
        Me.ColumnHeader4.Width = 269
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Type"
        Me.ColumnHeader1.Width = 203
        '
        'lblItemName
        '
        Me.lblItemName.AutoSize = True
        Me.lblItemName.BackColor = System.Drawing.Color.DarkGray
        Me.lblItemName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItemName.ForeColor = System.Drawing.Color.White
        Me.lblItemName.Location = New System.Drawing.Point(14, 7)
        Me.lblItemName.Name = "lblItemName"
        Me.lblItemName.Size = New System.Drawing.Size(93, 15)
        Me.lblItemName.TabIndex = 398
        Me.lblItemName.Text = "List of Charges"
        '
        'btnView
        '
        Me.btnView.Location = New System.Drawing.Point(17, 458)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(86, 29)
        Me.btnView.TabIndex = 399
        Me.btnView.Text = "View"
        Me.btnView.UseVisualStyleBackColor = True
        '
        'lbl_rs_id
        '
        Me.lbl_rs_id.AutoSize = True
        Me.lbl_rs_id.Location = New System.Drawing.Point(711, 44)
        Me.lbl_rs_id.Name = "lbl_rs_id"
        Me.lbl_rs_id.Size = New System.Drawing.Size(13, 13)
        Me.lbl_rs_id.TabIndex = 400
        Me.lbl_rs_id.Text = "0"
        '
        'lbl_sign
        '
        Me.lbl_sign.AutoSize = True
        Me.lbl_sign.Location = New System.Drawing.Point(685, 83)
        Me.lbl_sign.Name = "lbl_sign"
        Me.lbl_sign.Size = New System.Drawing.Size(39, 13)
        Me.lbl_sign.TabIndex = 401
        Me.lbl_sign.Text = "Label1"
        '
        'cmbTypeOfCharge
        '
        Me.cmbTypeOfCharge.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTypeOfCharge.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbTypeOfCharge.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTypeOfCharge.FormattingEnabled = True
        Me.cmbTypeOfCharge.Items.AddRange(New Object() {"PROJECT", "EQUIPMENT", "PERSONAL", "MAINOFFICE", "WAREHOUSE", "OTHERS", "COMPANY", "DIVISION", "DEPARTMENT", "SECTION", "SHOPS", "MOBILE CRUSHER", "CRUSHER PLANT", "BATCHING PLANT", "WAREHOUSES", "FABRICATION", "BUNKHOUSE", "OTHERS_NEW", "PROPERTY CODES"})
        Me.cmbTypeOfCharge.Location = New System.Drawing.Point(115, 38)
        Me.cmbTypeOfCharge.Name = "cmbTypeOfCharge"
        Me.cmbTypeOfCharge.Size = New System.Drawing.Size(435, 24)
        Me.cmbTypeOfCharge.TabIndex = 402
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(12, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 15)
        Me.Label1.TabIndex = 403
        Me.Label1.Text = "Type of Charge :"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.Panel1.Location = New System.Drawing.Point(-3, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(569, 29)
        Me.Panel1.TabIndex = 404
        '
        'txtSearch
        '
        Me.txtSearch.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(115, 68)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(435, 26)
        Me.txtSearch.TabIndex = 405
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(53, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 15)
        Me.Label2.TabIndex = 406
        Me.Label2.Text = "Search :"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(291, 458)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(129, 29)
        Me.Button1.TabIndex = 407
        Me.Button1.Text = "Update Charges"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'FProjectIncharge
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(562, 494)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbTypeOfCharge)
        Me.Controls.Add(Me.lbl_sign)
        Me.Controls.Add(Me.lbl_rs_id)
        Me.Controls.Add(Me.btnView)
        Me.Controls.Add(Me.lblItemName)
        Me.Controls.Add(Me.lvlListofCharges)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.Panel1)
        Me.KeyPreview = True
        Me.Name = "FProjectIncharge"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FProjectIncharge"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents lvlListofCharges As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblItemName As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnView As System.Windows.Forms.Button
    Friend WithEvents lbl_rs_id As System.Windows.Forms.Label
    Friend WithEvents lbl_sign As System.Windows.Forms.Label
    Friend WithEvents cmbTypeOfCharge As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button1 As Button
End Class
