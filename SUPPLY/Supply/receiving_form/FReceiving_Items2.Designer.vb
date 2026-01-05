<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FReceiving_Items2
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.rs_no = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_sub_item_desc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_po_qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_desired_qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_qty_received = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_price = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_unit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_po_det_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_rr_item_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_rs_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Main_Sub = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_selection = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_number = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.DataGridView1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.79661!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.20339!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1267, 643)
        Me.TableLayoutPanel1.TabIndex = 10
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.rs_no, Me.col_sub_item_desc, Me.col_po_qty, Me.col_desired_qty, Me.col_qty_received, Me.col_price, Me.col_unit, Me.col_po_det_id, Me.col_rr_item_id, Me.col_rs_id, Me.Main_Sub, Me.col_selection, Me.col_number})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.Padding = New System.Windows.Forms.Padding(3)
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(3, 3)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(1261, 590)
        Me.DataGridView1.TabIndex = 1
        '
        'rs_no
        '
        Me.rs_no.HeaderText = "rs_no"
        Me.rs_no.Name = "rs_no"
        Me.rs_no.Visible = False
        '
        'col_sub_item_desc
        '
        Me.col_sub_item_desc.HeaderText = "Sub Item Description"
        Me.col_sub_item_desc.Name = "col_sub_item_desc"
        Me.col_sub_item_desc.Width = 400
        '
        'col_po_qty
        '
        Me.col_po_qty.HeaderText = "Quantity to be received"
        Me.col_po_qty.Name = "col_po_qty"
        '
        'col_desired_qty
        '
        Me.col_desired_qty.HeaderText = "Input Desired Quantity to be received"
        Me.col_desired_qty.Name = "col_desired_qty"
        '
        'col_qty_received
        '
        Me.col_qty_received.HeaderText = "Total QTY Received"
        Me.col_qty_received.Name = "col_qty_received"
        '
        'col_price
        '
        Me.col_price.HeaderText = "Price"
        Me.col_price.Name = "col_price"
        Me.col_price.Width = 300
        '
        'col_unit
        '
        Me.col_unit.HeaderText = "Unit"
        Me.col_unit.Name = "col_unit"
        '
        'col_po_det_id
        '
        Me.col_po_det_id.HeaderText = "po_det_id"
        Me.col_po_det_id.Name = "col_po_det_id"
        Me.col_po_det_id.Visible = False
        '
        'col_rr_item_id
        '
        Me.col_rr_item_id.HeaderText = "rr_item_id/rr_item_sub_id"
        Me.col_rr_item_id.Name = "col_rr_item_id"
        Me.col_rr_item_id.Visible = False
        '
        'col_rs_id
        '
        Me.col_rs_id.HeaderText = "rs_id"
        Me.col_rs_id.Name = "col_rs_id"
        Me.col_rs_id.Visible = False
        '
        'Main_Sub
        '
        Me.Main_Sub.HeaderText = "Main_Sub"
        Me.Main_Sub.Name = "Main_Sub"
        Me.Main_Sub.Visible = False
        '
        'col_selection
        '
        Me.col_selection.HeaderText = "Selection"
        Me.col_selection.Name = "col_selection"
        '
        'col_number
        '
        Me.col_number.HeaderText = "#"
        Me.col_number.Name = "col_number"
        Me.col_number.Visible = False
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 4
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1401.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.btnSave, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Button3, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Button4, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 599)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1261, 41)
        Me.TableLayoutPanel2.TabIndex = 2
        '
        'btnSave
        '
        Me.btnSave.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnSave.Location = New System.Drawing.Point(303, 3)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(144, 35)
        Me.btnSave.TabIndex = 10
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button3.Enabled = False
        Me.Button3.Location = New System.Drawing.Point(153, 3)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(144, 35)
        Me.Button3.TabIndex = 11
        Me.Button3.Text = "Insert Row"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button4.Enabled = False
        Me.Button4.Location = New System.Drawing.Point(3, 3)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(144, 35)
        Me.Button4.TabIndex = 12
        Me.Button4.Text = "Remove Rows"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'FReceiving_Items2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1267, 643)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "FReceiving_Items2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FReceiving_Items2"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents btnSave As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents rs_no As DataGridViewTextBoxColumn
    Friend WithEvents col_sub_item_desc As DataGridViewTextBoxColumn
    Friend WithEvents col_po_qty As DataGridViewTextBoxColumn
    Friend WithEvents col_desired_qty As DataGridViewTextBoxColumn
    Friend WithEvents col_qty_received As DataGridViewTextBoxColumn
    Friend WithEvents col_price As DataGridViewTextBoxColumn
    Friend WithEvents col_unit As DataGridViewTextBoxColumn
    Friend WithEvents col_po_det_id As DataGridViewTextBoxColumn
    Friend WithEvents col_rr_item_id As DataGridViewTextBoxColumn
    Friend WithEvents col_rs_id As DataGridViewTextBoxColumn
    Friend WithEvents Main_Sub As DataGridViewTextBoxColumn
    Friend WithEvents col_selection As DataGridViewTextBoxColumn
    Friend WithEvents col_number As DataGridViewTextBoxColumn
End Class
