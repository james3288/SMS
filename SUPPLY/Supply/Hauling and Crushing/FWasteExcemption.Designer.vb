<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FWasteExcemption
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
        Me.components = New System.ComponentModel.Container()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.lvlListOfAggregates = New System.Windows.Forms.ListView()
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.CMS_lvlListOfAggregates = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CheckSelectedItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UncheckSelectedItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMS_lvlListOfAggregates.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(625, 527)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(174, 33)
        Me.btnSave.TabIndex = 459
        Me.btnSave.Text = "Generate"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'lvlListOfAggregates
        '
        Me.lvlListOfAggregates.CheckBoxes = True
        Me.lvlListOfAggregates.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader2, Me.ColumnHeader3})
        Me.lvlListOfAggregates.ContextMenuStrip = Me.CMS_lvlListOfAggregates
        Me.lvlListOfAggregates.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvlListOfAggregates.FullRowSelect = True
        Me.lvlListOfAggregates.Location = New System.Drawing.Point(12, 12)
        Me.lvlListOfAggregates.Name = "lvlListOfAggregates"
        Me.lvlListOfAggregates.Size = New System.Drawing.Size(787, 506)
        Me.lvlListOfAggregates.TabIndex = 458
        Me.lvlListOfAggregates.UseCompatibleStateImageBehavior = False
        Me.lvlListOfAggregates.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Item Name"
        Me.ColumnHeader2.Width = 380
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Remarks"
        Me.ColumnHeader3.Width = 396
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(12, 530)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(70, 17)
        Me.CheckBox1.TabIndex = 460
        Me.CheckBox1.Text = "Select All"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'CMS_lvlListOfAggregates
        '
        Me.CMS_lvlListOfAggregates.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CheckSelectedItemToolStripMenuItem, Me.UncheckSelectedItemToolStripMenuItem})
        Me.CMS_lvlListOfAggregates.Name = "CMS_lvlListOfAggregates"
        Me.CMS_lvlListOfAggregates.Size = New System.Drawing.Size(195, 48)
        '
        'CheckSelectedItemToolStripMenuItem
        '
        Me.CheckSelectedItemToolStripMenuItem.Name = "CheckSelectedItemToolStripMenuItem"
        Me.CheckSelectedItemToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.CheckSelectedItemToolStripMenuItem.Text = "Check Selected Item"
        '
        'UncheckSelectedItemToolStripMenuItem
        '
        Me.UncheckSelectedItemToolStripMenuItem.Name = "UncheckSelectedItemToolStripMenuItem"
        Me.UncheckSelectedItemToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.UncheckSelectedItemToolStripMenuItem.Text = "Uncheck Selected Item"
        '
        'FWasteExcemption
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(811, 573)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.lvlListOfAggregates)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FWasteExcemption"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FWasteExcemption"
        Me.CMS_lvlListOfAggregates.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnSave As Button
    Friend WithEvents lvlListOfAggregates As ListView
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents CMS_lvlListOfAggregates As ContextMenuStrip
    Friend WithEvents CheckSelectedItemToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UncheckSelectedItemToolStripMenuItem As ToolStripMenuItem
End Class
