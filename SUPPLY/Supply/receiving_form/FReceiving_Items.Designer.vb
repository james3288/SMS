<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FReceiving_Items
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.col_sub_item_desc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_po_qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_unit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_price = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_selection = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_po_det_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_rr_item_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_desired_qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_qty_received = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_rs_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Main_Sub = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rs_no = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.FindRelatedItemsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
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
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1324, 652)
        Me.TableLayoutPanel1.TabIndex = 9
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_sub_item_desc, Me.col_po_qty, Me.col_unit, Me.col_price, Me.col_selection, Me.col_po_det_id, Me.col_rr_item_id, Me.col_desired_qty, Me.col_qty_received, Me.col_rs_id, Me.Main_Sub, Me.rs_no})
        Me.DataGridView1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(3, 3)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(1318, 599)
        Me.DataGridView1.TabIndex = 1
        '
        'col_sub_item_desc
        '
        Me.col_sub_item_desc.HeaderText = "Sub Item Description"
        Me.col_sub_item_desc.Name = "col_sub_item_desc"
        Me.col_sub_item_desc.Width = 300
        '
        'col_po_qty
        '
        Me.col_po_qty.HeaderText = "Quantity to be received"
        Me.col_po_qty.Name = "col_po_qty"
        '
        'col_unit
        '
        Me.col_unit.HeaderText = "Unit"
        Me.col_unit.Name = "col_unit"
        '
        'col_price
        '
        Me.col_price.HeaderText = "Price"
        Me.col_price.Name = "col_price"
        Me.col_price.Width = 300
        '
        'col_selection
        '
        Me.col_selection.HeaderText = "Selection"
        Me.col_selection.Name = "col_selection"
        '
        'col_po_det_id
        '
        Me.col_po_det_id.HeaderText = "po_det_id"
        Me.col_po_det_id.Name = "col_po_det_id"
        Me.col_po_det_id.Visible = False
        '
        'col_rr_item_id
        '
        Me.col_rr_item_id.HeaderText = "rr_item_id"
        Me.col_rr_item_id.Name = "col_rr_item_id"
        Me.col_rr_item_id.Visible = False
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
        'col_rs_id
        '
        Me.col_rs_id.HeaderText = "rs_id"
        Me.col_rs_id.Name = "col_rs_id"
        '
        'Main_Sub
        '
        Me.Main_Sub.HeaderText = "Main_Sub"
        Me.Main_Sub.Name = "Main_Sub"
        '
        'rs_no
        '
        Me.rs_no.HeaderText = "rs_no"
        Me.rs_no.Name = "rs_no"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FindRelatedItemsToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(172, 26)
        '
        'FindRelatedItemsToolStripMenuItem
        '
        Me.FindRelatedItemsToolStripMenuItem.Name = "FindRelatedItemsToolStripMenuItem"
        Me.FindRelatedItemsToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.FindRelatedItemsToolStripMenuItem.Text = "Find Related Items"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 6
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 145.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 119.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 122.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1205.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Button2, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Button3, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Button4, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Button1, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Button5, 4, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 608)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1318, 41)
        Me.TableLayoutPanel2.TabIndex = 2
        '
        'Button2
        '
        Me.Button2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button2.Location = New System.Drawing.Point(303, 3)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(139, 35)
        Me.Button2.TabIndex = 10
        Me.Button2.Text = "Save"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Dock = System.Windows.Forms.DockStyle.Fill
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
        Me.Button4.Location = New System.Drawing.Point(3, 3)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(144, 35)
        Me.Button4.TabIndex = 12
        Me.Button4.Text = "Remove Rows"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(448, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(113, 35)
        Me.Button1.TabIndex = 13
        Me.Button1.Text = "PO DET"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(567, 3)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(116, 35)
        Me.Button5.TabIndex = 14
        Me.Button5.Text = "SUPLIER ID"
        Me.Button5.UseVisualStyleBackColor = True
        Me.Button5.Visible = False
        '
        'FReceiving_Items
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SUPPLY.My.Resources.Resources.eus_bg_03
        Me.ClientSize = New System.Drawing.Size(1324, 652)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "FReceiving_Items"
        Me.Text = "FReceiving_Items"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents FindRelatedItemsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents col_sub_item_desc As DataGridViewTextBoxColumn
    Friend WithEvents col_po_qty As DataGridViewTextBoxColumn
    Friend WithEvents col_unit As DataGridViewTextBoxColumn
    Friend WithEvents col_price As DataGridViewTextBoxColumn
    Friend WithEvents col_selection As DataGridViewTextBoxColumn
    Friend WithEvents col_po_det_id As DataGridViewTextBoxColumn
    Friend WithEvents col_rr_item_id As DataGridViewTextBoxColumn
    Friend WithEvents col_desired_qty As DataGridViewTextBoxColumn
    Friend WithEvents col_qty_received As DataGridViewTextBoxColumn
    Friend WithEvents col_rs_id As DataGridViewTextBoxColumn
    Friend WithEvents Main_Sub As DataGridViewTextBoxColumn
    Friend WithEvents rs_no As DataGridViewTextBoxColumn
    Friend WithEvents Button1 As Button
    Friend WithEvents Button5 As Button
End Class
