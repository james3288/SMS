<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FWHtoWH
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
        Me.dgvData = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.UpdatePlateNoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateRequestorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateDriverToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateSupplierToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyAndPasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DriverToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PlateNoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DrDateColumnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SupplierColumnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RequestorColumnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WhToWhToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvData
        '
        Me.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvData.Location = New System.Drawing.Point(0, 0)
        Me.dgvData.Name = "dgvData"
        Me.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvData.Size = New System.Drawing.Size(1187, 507)
        Me.dgvData.TabIndex = 0
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UpdatePlateNoToolStripMenuItem, Me.UpdateRequestorToolStripMenuItem, Me.UpdateDriverToolStripMenuItem, Me.UpdateSupplierToolStripMenuItem, Me.CopyAndPasteToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(217, 114)
        '
        'UpdatePlateNoToolStripMenuItem
        '
        Me.UpdatePlateNoToolStripMenuItem.Name = "UpdatePlateNoToolStripMenuItem"
        Me.UpdatePlateNoToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.UpdatePlateNoToolStripMenuItem.Text = "Update Plate No."
        '
        'UpdateRequestorToolStripMenuItem
        '
        Me.UpdateRequestorToolStripMenuItem.Name = "UpdateRequestorToolStripMenuItem"
        Me.UpdateRequestorToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.UpdateRequestorToolStripMenuItem.Text = "Update Requestor"
        '
        'UpdateDriverToolStripMenuItem
        '
        Me.UpdateDriverToolStripMenuItem.Name = "UpdateDriverToolStripMenuItem"
        Me.UpdateDriverToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.UpdateDriverToolStripMenuItem.Text = "Update Driver"
        '
        'UpdateSupplierToolStripMenuItem
        '
        Me.UpdateSupplierToolStripMenuItem.Name = "UpdateSupplierToolStripMenuItem"
        Me.UpdateSupplierToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.UpdateSupplierToolStripMenuItem.Text = "Update Supplier"
        '
        'CopyAndPasteToolStripMenuItem
        '
        Me.CopyAndPasteToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DriverToolStripMenuItem, Me.PlateNoToolStripMenuItem, Me.DrDateColumnToolStripMenuItem, Me.SupplierColumnToolStripMenuItem, Me.RequestorColumnToolStripMenuItem})
        Me.CopyAndPasteToolStripMenuItem.Name = "CopyAndPasteToolStripMenuItem"
        Me.CopyAndPasteToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.CopyAndPasteToolStripMenuItem.Text = "Copy and Paste to Column"
        '
        'DriverToolStripMenuItem
        '
        Me.DriverToolStripMenuItem.Name = "DriverToolStripMenuItem"
        Me.DriverToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.DriverToolStripMenuItem.Text = "Driver Column"
        '
        'PlateNoToolStripMenuItem
        '
        Me.PlateNoToolStripMenuItem.Name = "PlateNoToolStripMenuItem"
        Me.PlateNoToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.PlateNoToolStripMenuItem.Text = "Plate No. Column"
        '
        'DrDateColumnToolStripMenuItem
        '
        Me.DrDateColumnToolStripMenuItem.Name = "DrDateColumnToolStripMenuItem"
        Me.DrDateColumnToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.DrDateColumnToolStripMenuItem.Text = "Dr Date Column"
        '
        'SupplierColumnToolStripMenuItem
        '
        Me.SupplierColumnToolStripMenuItem.Name = "SupplierColumnToolStripMenuItem"
        Me.SupplierColumnToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.SupplierColumnToolStripMenuItem.Text = "Supplier Column"
        '
        'RequestorColumnToolStripMenuItem
        '
        Me.RequestorColumnToolStripMenuItem.Name = "RequestorColumnToolStripMenuItem"
        Me.RequestorColumnToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.RequestorColumnToolStripMenuItem.Text = "Requestor Column"
        '
        'WhToWhToolStripMenuItem
        '
        Me.WhToWhToolStripMenuItem.Name = "WhToWhToolStripMenuItem"
        Me.WhToWhToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.WhToWhToolStripMenuItem.Text = "Update WH to WH"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.dgvData)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1187, 507)
        Me.Panel1.TabIndex = 5
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.btnOK)
        Me.Panel2.Controls.Add(Me.txtSearch)
        Me.Panel2.Location = New System.Drawing.Point(467, 218)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(412, 130)
        Me.Panel2.TabIndex = 1
        Me.Panel2.Visible = False
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.BackgroundImage = Global.SUPPLY.My.Resources.Resources.close_button
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(385, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(22, 22)
        Me.Button1.TabIndex = 362
        Me.Button1.UseVisualStyleBackColor = False
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOK.ForeColor = System.Drawing.Color.White
        Me.btnOK.Location = New System.Drawing.Point(293, 78)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(89, 32)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = False
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(46, 42)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(336, 20)
        Me.txtSearch.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Button3)
        Me.Panel3.Controls.Add(Me.Panel5)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.Button2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 507)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1187, 53)
        Me.Panel3.TabIndex = 6
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.DodgerBlue
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Location = New System.Drawing.Point(853, 9)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(158, 32)
        Me.Button3.TabIndex = 368
        Me.Button3.Text = "UPDATE WH TO WH"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.DarkGray
        Me.Panel5.Location = New System.Drawing.Point(114, 15)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(26, 26)
        Me.Panel5.TabIndex = 367
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(146, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(18, 13)
        Me.Label2.TabIndex = 366
        Me.Label2.Text = "IN"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.Location = New System.Drawing.Point(32, 15)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(26, 26)
        Me.Panel4.TabIndex = 365
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(64, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 364
        Me.Label1.Text = "OUT"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.DodgerBlue
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(1017, 9)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(158, 32)
        Me.Button2.TabIndex = 363
        Me.Button2.Text = "UPDATE"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'FWHtoWH
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1187, 560)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FWHtoWH"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FWHtoWH"
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvData As DataGridView
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents UpdatePlateNoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UpdateRequestorToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UpdateDriverToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnOK As Button
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Button2 As Button
    Friend WithEvents UpdateSupplierToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CopyAndPasteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DriverToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PlateNoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DrDateColumnToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SupplierColumnToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RequestorColumnToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents WhToWhToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Button3 As Button
End Class
