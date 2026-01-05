<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FAdd_Set_Name
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
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSet_name = New System.Windows.Forms.TextBox()
        Me.btnSave_Set_Name = New System.Windows.Forms.Button()
        Me.lvl_Set_Name = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CMS_lvlSet_Name = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.lblCancel = New System.Windows.Forms.Label()
        Me.CMS_lvlSet_Name.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(7, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 22)
        Me.Label1.TabIndex = 393
        Me.Label1.Text = "Add Set Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(6, 278)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 16)
        Me.Label2.TabIndex = 393
        Me.Label2.Text = "Set Name:"
        '
        'txtSet_name
        '
        Me.txtSet_name.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSet_name.Location = New System.Drawing.Point(86, 275)
        Me.txtSet_name.Name = "txtSet_name"
        Me.txtSet_name.Size = New System.Drawing.Size(267, 22)
        Me.txtSet_name.TabIndex = 1
        '
        'btnSave_Set_Name
        '
        Me.btnSave_Set_Name.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave_Set_Name.Location = New System.Drawing.Point(9, 303)
        Me.btnSave_Set_Name.Name = "btnSave_Set_Name"
        Me.btnSave_Set_Name.Size = New System.Drawing.Size(344, 29)
        Me.btnSave_Set_Name.TabIndex = 2
        Me.btnSave_Set_Name.Text = "Save"
        Me.btnSave_Set_Name.UseVisualStyleBackColor = True
        '
        'lvl_Set_Name
        '
        Me.lvl_Set_Name.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.lvl_Set_Name.ContextMenuStrip = Me.CMS_lvlSet_Name
        Me.lvl_Set_Name.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvl_Set_Name.FullRowSelect = True
        Me.lvl_Set_Name.GridLines = True
        Me.lvl_Set_Name.HideSelection = False
        Me.lvl_Set_Name.Location = New System.Drawing.Point(9, 41)
        Me.lvl_Set_Name.Name = "lvl_Set_Name"
        Me.lvl_Set_Name.Size = New System.Drawing.Size(344, 228)
        Me.lvl_Set_Name.TabIndex = 393
        Me.lvl_Set_Name.UseCompatibleStateImageBehavior = False
        Me.lvl_Set_Name.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ID"
        Me.ColumnHeader1.Width = 0
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Set Name"
        Me.ColumnHeader2.Width = 400
        '
        'CMS_lvlSet_Name
        '
        Me.CMS_lvlSet_Name.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.CMS_lvlSet_Name.Name = "CMS_lvlSet_items"
        Me.CMS_lvlSet_Name.Size = New System.Drawing.Size(108, 48)
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.SUPPLY.My.Resources.Resources.header_line
        Me.PictureBox1.Location = New System.Drawing.Point(-1, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(364, 10)
        Me.PictureBox1.TabIndex = 394
        Me.PictureBox1.TabStop = False
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.Transparent
        Me.btnExit.BackgroundImage = Global.SUPPLY.My.Resources.Resources.close_button
        Me.btnExit.FlatAppearance.BorderSize = 0
        Me.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit.Location = New System.Drawing.Point(333, 9)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(20, 20)
        Me.btnExit.TabIndex = 3
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'lblCancel
        '
        Me.lblCancel.AutoSize = True
        Me.lblCancel.BackColor = System.Drawing.Color.Transparent
        Me.lblCancel.Font = New System.Drawing.Font("Arial Narrow", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblCancel.Location = New System.Drawing.Point(6, 335)
        Me.lblCancel.Name = "lblCancel"
        Me.lblCancel.Size = New System.Drawing.Size(104, 16)
        Me.lblCancel.TabIndex = 395
        Me.lblCancel.Text = "Press ESC to Cancel"
        '
        'FAdd_Set_Name
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SUPPLY.My.Resources.Resources.line_div_below
        Me.ClientSize = New System.Drawing.Size(362, 353)
        Me.Controls.Add(Me.lblCancel)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lvl_Set_Name)
        Me.Controls.Add(Me.btnSave_Set_Name)
        Me.Controls.Add(Me.txtSet_name)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "FAdd_Set_Name"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FAdd_Set_Name"
        Me.CMS_lvlSet_Name.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtSet_name As TextBox
    Friend WithEvents btnSave_Set_Name As Button
    Friend WithEvents lvl_Set_Name As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents CMS_lvlSet_Name As ContextMenuStrip
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btnExit As Button
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents lblCancel As Label
End Class
