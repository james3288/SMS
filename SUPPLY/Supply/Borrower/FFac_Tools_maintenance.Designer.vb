<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FFac_Tools_maintenance
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
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblItemName = New System.Windows.Forms.Label()
        Me.cmbItemName = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbItem_desc = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtrsno = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtQty = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtUnit = New System.Windows.Forms.TextBox()
        Me.cmbType = New System.Windows.Forms.ComboBox()
        Me.cmbSub = New System.Windows.Forms.ComboBox()
        Me.cmbIn = New System.Windows.Forms.ComboBox()
        Me.cmb_factools = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lbox = New System.Windows.Forms.ListBox()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.FlowLayoutPanel1.Controls.Add(Me.lblItemName)
        Me.FlowLayoutPanel1.Controls.Add(Me.cmbItemName)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label1)
        Me.FlowLayoutPanel1.Controls.Add(Me.cmbItem_desc)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label2)
        Me.FlowLayoutPanel1.Controls.Add(Me.txtrsno)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label3)
        Me.FlowLayoutPanel1.Controls.Add(Me.txtQty)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label4)
        Me.FlowLayoutPanel1.Controls.Add(Me.txtUnit)
        Me.FlowLayoutPanel1.Controls.Add(Me.cmbType)
        Me.FlowLayoutPanel1.Controls.Add(Me.cmbSub)
        Me.FlowLayoutPanel1.Controls.Add(Me.cmbIn)
        Me.FlowLayoutPanel1.Controls.Add(Me.cmb_factools)
        Me.FlowLayoutPanel1.Controls.Add(Me.Button1)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(12, 12)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(245, 425)
        Me.FlowLayoutPanel1.TabIndex = 441
        '
        'lblItemName
        '
        Me.lblItemName.AutoSize = True
        Me.lblItemName.BackColor = System.Drawing.Color.Transparent
        Me.lblItemName.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItemName.ForeColor = System.Drawing.Color.White
        Me.lblItemName.Location = New System.Drawing.Point(3, 0)
        Me.lblItemName.Name = "lblItemName"
        Me.lblItemName.Size = New System.Drawing.Size(81, 16)
        Me.lblItemName.TabIndex = 134
        Me.lblItemName.Text = "Item Name:"
        '
        'cmbItemName
        '
        Me.cmbItemName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbItemName.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbItemName.FormattingEnabled = True
        Me.cmbItemName.Location = New System.Drawing.Point(3, 19)
        Me.cmbItemName.Name = "cmbItemName"
        Me.cmbItemName.Size = New System.Drawing.Size(236, 26)
        Me.cmbItemName.TabIndex = 433
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 16)
        Me.Label1.TabIndex = 434
        Me.Label1.Text = "Item Desc."
        '
        'cmbItem_desc
        '
        Me.cmbItem_desc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbItem_desc.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbItem_desc.FormattingEnabled = True
        Me.cmbItem_desc.Location = New System.Drawing.Point(3, 67)
        Me.cmbItem_desc.Name = "cmbItem_desc"
        Me.cmbItem_desc.Size = New System.Drawing.Size(236, 26)
        Me.cmbItem_desc.TabIndex = 435
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(3, 96)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 16)
        Me.Label2.TabIndex = 436
        Me.Label2.Text = "rs_no"
        '
        'txtrsno
        '
        Me.txtrsno.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtrsno.Location = New System.Drawing.Point(3, 115)
        Me.txtrsno.Name = "txtrsno"
        Me.txtrsno.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtrsno.Size = New System.Drawing.Size(240, 26)
        Me.txtrsno.TabIndex = 437
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(3, 144)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 16)
        Me.Label3.TabIndex = 439
        Me.Label3.Text = "Qty"
        '
        'txtQty
        '
        Me.txtQty.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQty.Location = New System.Drawing.Point(3, 163)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtQty.Size = New System.Drawing.Size(240, 26)
        Me.txtQty.TabIndex = 440
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(3, 192)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 16)
        Me.Label4.TabIndex = 441
        Me.Label4.Text = "Unit"
        '
        'txtUnit
        '
        Me.txtUnit.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUnit.Location = New System.Drawing.Point(3, 211)
        Me.txtUnit.Name = "txtUnit"
        Me.txtUnit.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtUnit.Size = New System.Drawing.Size(239, 26)
        Me.txtUnit.TabIndex = 442
        '
        'cmbType
        '
        Me.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbType.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbType.FormattingEnabled = True
        Me.cmbType.Location = New System.Drawing.Point(3, 245)
        Me.cmbType.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.cmbType.Name = "cmbType"
        Me.cmbType.Size = New System.Drawing.Size(239, 26)
        Me.cmbType.TabIndex = 443
        '
        'cmbSub
        '
        Me.cmbSub.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSub.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSub.FormattingEnabled = True
        Me.cmbSub.Items.AddRange(New Object() {"Equipment Request", "Construction Materials", "Admin and Misc. Request"})
        Me.cmbSub.Location = New System.Drawing.Point(3, 281)
        Me.cmbSub.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.cmbSub.Name = "cmbSub"
        Me.cmbSub.Size = New System.Drawing.Size(239, 26)
        Me.cmbSub.TabIndex = 444
        '
        'cmbIn
        '
        Me.cmbIn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbIn.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbIn.FormattingEnabled = True
        Me.cmbIn.Items.AddRange(New Object() {"IN", "OTHERS"})
        Me.cmbIn.Location = New System.Drawing.Point(3, 317)
        Me.cmbIn.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.cmbIn.Name = "cmbIn"
        Me.cmbIn.Size = New System.Drawing.Size(239, 26)
        Me.cmbIn.TabIndex = 445
        '
        'cmb_factools
        '
        Me.cmb_factools.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_factools.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmb_factools.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_factools.FormattingEnabled = True
        Me.cmb_factools.Items.AddRange(New Object() {"FACILITIES", "TOOLS", "N/A"})
        Me.cmb_factools.Location = New System.Drawing.Point(3, 353)
        Me.cmb_factools.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.cmb_factools.Name = "cmb_factools"
        Me.cmb_factools.Size = New System.Drawing.Size(240, 23)
        Me.cmb_factools.TabIndex = 446
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(3, 386)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(240, 34)
        Me.Button1.TabIndex = 438
        Me.Button1.Text = "Save"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lbox
        '
        Me.lbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbox.FormattingEnabled = True
        Me.lbox.ItemHeight = 18
        Me.lbox.Location = New System.Drawing.Point(402, 59)
        Me.lbox.Name = "lbox"
        Me.lbox.Size = New System.Drawing.Size(232, 94)
        Me.lbox.TabIndex = 442
        '
        'FFac_Tools_maintenance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SUPPLY.My.Resources.Resources.eus_bg_03
        Me.ClientSize = New System.Drawing.Size(263, 449)
        Me.Controls.Add(Me.lbox)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Name = "FFac_Tools_maintenance"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FFac_Tools_maintenance"
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents lblItemName As Label
    Friend WithEvents lbox As ListBox
    Friend WithEvents cmbItemName As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbItem_desc As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtrsno As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents txtQty As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtUnit As TextBox
    Friend WithEvents cmbType As ComboBox
    Friend WithEvents cmbSub As ComboBox
    Friend WithEvents cmbIn As ComboBox
    Friend WithEvents cmb_factools As ComboBox
End Class
