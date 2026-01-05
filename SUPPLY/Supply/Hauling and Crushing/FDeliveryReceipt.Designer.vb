<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FDeliveryReceipt
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
        Me.CMS_dgv_dr_list = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SplitQtyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddSourceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProjectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OthersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EquipmentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UnselectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopySourceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.bw_get_supplier = New System.ComponentModel.BackgroundWorker()
        Me.bw_get_operator = New System.ComponentModel.BackgroundWorker()
        Me.bw_get_type_of_charges = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorker3 = New System.ComponentModel.BackgroundWorker()
        Me.bw_check_if_done = New System.ComponentModel.BackgroundWorker()
        Me.bw_display_balance_out = New System.ComponentModel.BackgroundWorker()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.txtsplitqty = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.dgv_dr_list = New System.Windows.Forms.DataGridView()
        Me.col_checkbox = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.col_dr_no = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_source = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_category = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_item_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_rs_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_dr_item_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_wh_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_select = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_ws_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_qty_withdrawn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_price = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rr_item_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BW_initializeData = New System.ComponentModel.BackgroundWorker()
        Me.BW_loadingEffects = New System.ComponentModel.BackgroundWorker()
        Me.BW_get_aggregates_balances = New System.ComponentModel.BackgroundWorker()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.cmbTransaction = New System.Windows.Forms.ComboBox()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.cmbTypeofCharge = New System.Windows.Forms.ComboBox()
        Me.txtChargeTo = New System.Windows.Forms.TextBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.dtpDateSubmitted = New System.Windows.Forms.DateTimePicker()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cmbRRNo = New System.Windows.Forms.ComboBox()
        Me.txtprice = New System.Windows.Forms.TextBox()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.txtDriver = New System.Windows.Forms.TextBox()
        Me.cmbWsNo_PoNo = New System.Windows.Forms.ComboBox()
        Me.lboxUnit = New System.Windows.Forms.ListBox()
        Me.cmbDrOptions = New System.Windows.Forms.ComboBox()
        Me.cmbOptions = New System.Windows.Forms.ComboBox()
        Me.list_box = New System.Windows.Forms.ListBox()
        Me.txtreceivedby = New System.Windows.Forms.TextBox()
        Me.txtcheckedby = New System.Windows.Forms.TextBox()
        Me.txtconcession = New System.Windows.Forms.TextBox()
        Me.cmbSupplier = New System.Windows.Forms.ComboBox()
        Me.txtrsno = New System.Windows.Forms.TextBox()
        Me.txtPlateNo = New System.Windows.Forms.TextBox()
        Me.dtpDRDate = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbl_dr_info_id = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.cmbChargeTo = New System.Windows.Forms.ComboBox()
        Me.cmbOperator = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.loadingPanel = New System.Windows.Forms.Panel()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.CMS_dgv_dr_list.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel8.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        CType(Me.dgv_dr_list, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel9.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.loadingPanel.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CMS_dgv_dr_list
        '
        Me.CMS_dgv_dr_list.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SplitQtyToolStripMenuItem, Me.AddSourceToolStripMenuItem, Me.SelectToolStripMenuItem, Me.UnselectToolStripMenuItem, Me.CopySourceToolStripMenuItem})
        Me.CMS_dgv_dr_list.Name = "CMS_dgv_dr_list"
        Me.CMS_dgv_dr_list.Size = New System.Drawing.Size(137, 114)
        '
        'SplitQtyToolStripMenuItem
        '
        Me.SplitQtyToolStripMenuItem.Name = "SplitQtyToolStripMenuItem"
        Me.SplitQtyToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.SplitQtyToolStripMenuItem.Text = "Split Qty"
        '
        'AddSourceToolStripMenuItem
        '
        Me.AddSourceToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProjectToolStripMenuItem, Me.OthersToolStripMenuItem, Me.EquipmentToolStripMenuItem})
        Me.AddSourceToolStripMenuItem.Name = "AddSourceToolStripMenuItem"
        Me.AddSourceToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.AddSourceToolStripMenuItem.Text = "Add Source"
        '
        'ProjectToolStripMenuItem
        '
        Me.ProjectToolStripMenuItem.Name = "ProjectToolStripMenuItem"
        Me.ProjectToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.ProjectToolStripMenuItem.Text = "Project"
        '
        'OthersToolStripMenuItem
        '
        Me.OthersToolStripMenuItem.Name = "OthersToolStripMenuItem"
        Me.OthersToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.OthersToolStripMenuItem.Text = "Others"
        '
        'EquipmentToolStripMenuItem
        '
        Me.EquipmentToolStripMenuItem.Name = "EquipmentToolStripMenuItem"
        Me.EquipmentToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.EquipmentToolStripMenuItem.Text = "Equipment"
        '
        'SelectToolStripMenuItem
        '
        Me.SelectToolStripMenuItem.Name = "SelectToolStripMenuItem"
        Me.SelectToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.SelectToolStripMenuItem.Text = "Select All"
        '
        'UnselectToolStripMenuItem
        '
        Me.UnselectToolStripMenuItem.Name = "UnselectToolStripMenuItem"
        Me.UnselectToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.UnselectToolStripMenuItem.Text = "Unselect All"
        '
        'CopySourceToolStripMenuItem
        '
        Me.CopySourceToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyToolStripMenuItem, Me.PasteToolStripMenuItem})
        Me.CopySourceToolStripMenuItem.Name = "CopySourceToolStripMenuItem"
        Me.CopySourceToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.CopySourceToolStripMenuItem.Text = "Source"
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(102, 22)
        Me.CopyToolStripMenuItem.Text = "Copy"
        '
        'PasteToolStripMenuItem
        '
        Me.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem"
        Me.PasteToolStripMenuItem.Size = New System.Drawing.Size(102, 22)
        Me.PasteToolStripMenuItem.Text = "Paste"
        '
        'bw_get_supplier
        '
        '
        'bw_get_operator
        '
        '
        'bw_get_type_of_charges
        '
        '
        'BackgroundWorker1
        '
        '
        'BackgroundWorker3
        '
        '
        'bw_check_if_done
        '
        '
        'bw_display_balance_out
        '
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Black
        Me.Panel3.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(304, 45)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1237, 708)
        Me.Panel3.TabIndex = 2
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.BackgroundImage = Global.SUPPLY.My.Resources.Resources.bg_line
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel4, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel5, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1237, 708)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Black
        Me.Panel4.BackgroundImage = Global.SUPPLY.My.Resources.Resources.eus_bg_03
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(3, 665)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1231, 40)
        Me.Panel4.TabIndex = 1
        '
        'Panel5
        '
        Me.Panel5.BackgroundImage = Global.SUPPLY.My.Resources.Resources.bg_line
        Me.Panel5.Controls.Add(Me.Panel8)
        Me.Panel5.Controls.Add(Me.Panel6)
        Me.Panel5.Controls.Add(Me.dgv_dr_list)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(3, 3)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1231, 656)
        Me.Panel5.TabIndex = 2
        '
        'Panel8
        '
        Me.Panel8.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Panel8.BackColor = System.Drawing.Color.Black
        Me.Panel8.Controls.Add(Me.PictureBox1)
        Me.Panel8.Location = New System.Drawing.Point(11, 28)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(638, 204)
        Me.Panel8.TabIndex = 418
        Me.Panel8.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Black
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Image = Global.SUPPLY.My.Resources.Resources.loading7
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(638, 204)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 422
        Me.PictureBox1.TabStop = False
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.txtsplitqty)
        Me.Panel6.Controls.Add(Me.Label14)
        Me.Panel6.Controls.Add(Me.Label15)
        Me.Panel6.Controls.Add(Me.Button4)
        Me.Panel6.Controls.Add(Me.Button5)
        Me.Panel6.Location = New System.Drawing.Point(508, 210)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(231, 114)
        Me.Panel6.TabIndex = 100
        Me.Panel6.Visible = False
        '
        'txtsplitqty
        '
        Me.txtsplitqty.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsplitqty.Location = New System.Drawing.Point(8, 49)
        Me.txtsplitqty.Name = "txtsplitqty"
        Me.txtsplitqty.Size = New System.Drawing.Size(216, 24)
        Me.txtsplitqty.TabIndex = 100
        Me.txtsplitqty.Text = "0"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(5, 32)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(60, 15)
        Me.Label14.TabIndex = 425
        Me.Label14.Text = "Enter qty:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(10, 41)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(0, 13)
        Me.Label15.TabIndex = 397
        '
        'Button4
        '
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Location = New System.Drawing.Point(206, 3)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(22, 23)
        Me.Button4.TabIndex = 100
        Me.Button4.Text = "x"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(150, 79)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 23)
        Me.Button5.TabIndex = 100
        Me.Button5.Text = "OK"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'dgv_dr_list
        '
        Me.dgv_dr_list.AllowUserToAddRows = False
        Me.dgv_dr_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_dr_list.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_checkbox, Me.col_dr_no, Me.col_source, Me.col_category, Me.col_qty, Me.col_item_name, Me.col_rs_id, Me.col_dr_item_id, Me.col_wh_id, Me.col_select, Me.col_ws_id, Me.col_qty_withdrawn, Me.col_price, Me.rr_item_id})
        Me.dgv_dr_list.ContextMenuStrip = Me.CMS_dgv_dr_list
        Me.dgv_dr_list.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_dr_list.Location = New System.Drawing.Point(0, 0)
        Me.dgv_dr_list.Name = "dgv_dr_list"
        Me.dgv_dr_list.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_dr_list.Size = New System.Drawing.Size(1231, 656)
        Me.dgv_dr_list.TabIndex = 21
        '
        'col_checkbox
        '
        Me.col_checkbox.HeaderText = "Select"
        Me.col_checkbox.Name = "col_checkbox"
        Me.col_checkbox.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col_checkbox.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'col_dr_no
        '
        Me.col_dr_no.HeaderText = "DR NO"
        Me.col_dr_no.Name = "col_dr_no"
        '
        'col_source
        '
        Me.col_source.HeaderText = "Source"
        Me.col_source.Name = "col_source"
        Me.col_source.ReadOnly = True
        Me.col_source.Width = 300
        '
        'col_category
        '
        Me.col_category.HeaderText = "Category"
        Me.col_category.Name = "col_category"
        '
        'col_qty
        '
        Me.col_qty.HeaderText = "Quantity"
        Me.col_qty.Name = "col_qty"
        Me.col_qty.ReadOnly = True
        Me.col_qty.Width = 250
        '
        'col_item_name
        '
        Me.col_item_name.HeaderText = "Item Name-Description"
        Me.col_item_name.Name = "col_item_name"
        Me.col_item_name.ReadOnly = True
        Me.col_item_name.Width = 350
        '
        'col_rs_id
        '
        Me.col_rs_id.HeaderText = "RS_ID"
        Me.col_rs_id.Name = "col_rs_id"
        Me.col_rs_id.ReadOnly = True
        '
        'col_dr_item_id
        '
        Me.col_dr_item_id.HeaderText = "DR_ITEM_ID"
        Me.col_dr_item_id.Name = "col_dr_item_id"
        Me.col_dr_item_id.ReadOnly = True
        '
        'col_wh_id
        '
        Me.col_wh_id.HeaderText = "wh_id"
        Me.col_wh_id.Name = "col_wh_id"
        Me.col_wh_id.ReadOnly = True
        '
        'col_select
        '
        Me.col_select.HeaderText = "Selection"
        Me.col_select.Name = "col_select"
        Me.col_select.Visible = False
        Me.col_select.Width = 200
        '
        'col_ws_id
        '
        Me.col_ws_id.HeaderText = "ws_id"
        Me.col_ws_id.Name = "col_ws_id"
        Me.col_ws_id.ReadOnly = True
        '
        'col_qty_withdrawn
        '
        Me.col_qty_withdrawn.HeaderText = "Qty Withdrawn"
        Me.col_qty_withdrawn.Name = "col_qty_withdrawn"
        Me.col_qty_withdrawn.Width = 150
        '
        'col_price
        '
        Me.col_price.HeaderText = "Price"
        Me.col_price.Name = "col_price"
        '
        'rr_item_id
        '
        Me.rr_item_id.HeaderText = "rr_item_id"
        Me.rr_item_id.Name = "rr_item_id"
        '
        'BW_initializeData
        '
        '
        'BW_loadingEffects
        '
        '
        'BW_get_aggregates_balances
        '
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Black
        Me.Panel2.BackgroundImage = Global.SUPPLY.My.Resources.Resources.bg_line
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.Label19)
        Me.Panel2.Controls.Add(Me.Panel7)
        Me.Panel2.Controls.Add(Me.lbl_dr_info_id)
        Me.Panel2.Controls.Add(Me.btnSave)
        Me.Panel2.Controls.Add(Me.cmbChargeTo)
        Me.Panel2.Controls.Add(Me.cmbOperator)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 45)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(304, 708)
        Me.Panel2.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(19, 653)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 100
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label19.Location = New System.Drawing.Point(114, 624)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(181, 15)
        Me.Label19.TabIndex = 456
        Me.Label19.Text = "Ctrl + S for shorcut Save/Update"
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.Transparent
        Me.Panel7.Controls.Add(Me.cmbTransaction)
        Me.Panel7.Controls.Add(Me.Panel9)
        Me.Panel7.Controls.Add(Me.dtpDateSubmitted)
        Me.Panel7.Controls.Add(Me.Label13)
        Me.Panel7.Controls.Add(Me.cmbRRNo)
        Me.Panel7.Controls.Add(Me.txtprice)
        Me.Panel7.Controls.Add(Me.txtRemarks)
        Me.Panel7.Controls.Add(Me.txtDriver)
        Me.Panel7.Controls.Add(Me.cmbWsNo_PoNo)
        Me.Panel7.Controls.Add(Me.lboxUnit)
        Me.Panel7.Controls.Add(Me.cmbDrOptions)
        Me.Panel7.Controls.Add(Me.cmbOptions)
        Me.Panel7.Controls.Add(Me.list_box)
        Me.Panel7.Controls.Add(Me.txtreceivedby)
        Me.Panel7.Controls.Add(Me.txtcheckedby)
        Me.Panel7.Controls.Add(Me.txtconcession)
        Me.Panel7.Controls.Add(Me.cmbSupplier)
        Me.Panel7.Controls.Add(Me.txtrsno)
        Me.Panel7.Controls.Add(Me.txtPlateNo)
        Me.Panel7.Controls.Add(Me.dtpDRDate)
        Me.Panel7.Controls.Add(Me.Label1)
        Me.Panel7.Location = New System.Drawing.Point(12, 6)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(289, 568)
        Me.Panel7.TabIndex = 428
        '
        'cmbTransaction
        '
        Me.cmbTransaction.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbTransaction.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTransaction.FormattingEnabled = True
        Me.cmbTransaction.Items.AddRange(New Object() {"", "Stockpile to Stockpile"})
        Me.cmbTransaction.Location = New System.Drawing.Point(45, 537)
        Me.cmbTransaction.Name = "cmbTransaction"
        Me.cmbTransaction.Size = New System.Drawing.Size(238, 24)
        Me.cmbTransaction.TabIndex = 19
        '
        'Panel9
        '
        Me.Panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel9.Controls.Add(Me.cmbTypeofCharge)
        Me.Panel9.Controls.Add(Me.txtChargeTo)
        Me.Panel9.Controls.Add(Me.PictureBox3)
        Me.Panel9.Location = New System.Drawing.Point(4, 169)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(279, 73)
        Me.Panel9.TabIndex = 438
        '
        'cmbTypeofCharge
        '
        Me.cmbTypeofCharge.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTypeofCharge.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbTypeofCharge.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTypeofCharge.FormattingEnabled = True
        Me.cmbTypeofCharge.Items.AddRange(New Object() {"PROJECT", "EQUIPMENT", "WAREHOUSE", "OTHERS"})
        Me.cmbTypeofCharge.Location = New System.Drawing.Point(41, 6)
        Me.cmbTypeofCharge.Name = "cmbTypeofCharge"
        Me.cmbTypeofCharge.Size = New System.Drawing.Size(229, 24)
        Me.cmbTypeofCharge.TabIndex = 7
        '
        'txtChargeTo
        '
        Me.txtChargeTo.Enabled = False
        Me.txtChargeTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChargeTo.Location = New System.Drawing.Point(40, 40)
        Me.txtChargeTo.Name = "txtChargeTo"
        Me.txtChargeTo.ReadOnly = True
        Me.txtChargeTo.Size = New System.Drawing.Size(201, 24)
        Me.txtChargeTo.TabIndex = 8
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.Image = Global.SUPPLY.My.Resources.Resources.Plus_sign
        Me.PictureBox3.Location = New System.Drawing.Point(247, 40)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(22, 23)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 420
        Me.PictureBox3.TabStop = False
        '
        'dtpDateSubmitted
        '
        Me.dtpDateSubmitted.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDateSubmitted.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDateSubmitted.Location = New System.Drawing.Point(141, 73)
        Me.dtpDateSubmitted.Name = "dtpDateSubmitted"
        Me.dtpDateSubmitted.Size = New System.Drawing.Size(144, 22)
        Me.dtpDateSubmitted.TabIndex = 3
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(1, 76)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(101, 16)
        Me.Label13.TabIndex = 436
        Me.Label13.Text = "Date Submitted:"
        '
        'cmbRRNo
        '
        Me.cmbRRNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRRNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbRRNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbRRNo.FormattingEnabled = True
        Me.cmbRRNo.Location = New System.Drawing.Point(45, 345)
        Me.cmbRRNo.Name = "cmbRRNo"
        Me.cmbRRNo.Size = New System.Drawing.Size(239, 24)
        Me.cmbRRNo.TabIndex = 13
        '
        'txtprice
        '
        Me.txtprice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtprice.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtprice.Location = New System.Drawing.Point(45, 506)
        Me.txtprice.Name = "txtprice"
        Me.txtprice.Size = New System.Drawing.Size(239, 22)
        Me.txtprice.TabIndex = 18
        Me.txtprice.Text = "0"
        '
        'txtRemarks
        '
        Me.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRemarks.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRemarks.Location = New System.Drawing.Point(45, 473)
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(239, 22)
        Me.txtRemarks.TabIndex = 17
        '
        'txtDriver
        '
        Me.txtDriver.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDriver.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDriver.Location = New System.Drawing.Point(46, 140)
        Me.txtDriver.Name = "txtDriver"
        Me.txtDriver.Size = New System.Drawing.Size(239, 22)
        Me.txtDriver.TabIndex = 6
        '
        'cmbWsNo_PoNo
        '
        Me.cmbWsNo_PoNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbWsNo_PoNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbWsNo_PoNo.FormattingEnabled = True
        Me.cmbWsNo_PoNo.Location = New System.Drawing.Point(46, 313)
        Me.cmbWsNo_PoNo.Name = "cmbWsNo_PoNo"
        Me.cmbWsNo_PoNo.Size = New System.Drawing.Size(238, 24)
        Me.cmbWsNo_PoNo.TabIndex = 12
        '
        'lboxUnit
        '
        Me.lboxUnit.FormattingEnabled = True
        Me.lboxUnit.Location = New System.Drawing.Point(306, 329)
        Me.lboxUnit.Name = "lboxUnit"
        Me.lboxUnit.Size = New System.Drawing.Size(161, 69)
        Me.lboxUnit.TabIndex = 429
        Me.lboxUnit.Visible = False
        '
        'cmbDrOptions
        '
        Me.cmbDrOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbDrOptions.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDrOptions.FormattingEnabled = True
        Me.cmbDrOptions.Items.AddRange(New Object() {"W/ DR", "W/O DR"})
        Me.cmbDrOptions.Location = New System.Drawing.Point(203, 9)
        Me.cmbDrOptions.Name = "cmbDrOptions"
        Me.cmbDrOptions.Size = New System.Drawing.Size(82, 24)
        Me.cmbDrOptions.TabIndex = 1
        '
        'cmbOptions
        '
        Me.cmbOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbOptions.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOptions.FormattingEnabled = True
        Me.cmbOptions.Items.AddRange(New Object() {"IN", "OUT", "OTHERS"})
        Me.cmbOptions.Location = New System.Drawing.Point(46, 9)
        Me.cmbOptions.Name = "cmbOptions"
        Me.cmbOptions.Size = New System.Drawing.Size(92, 24)
        Me.cmbOptions.TabIndex = 0
        '
        'list_box
        '
        Me.list_box.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.list_box.FormattingEnabled = True
        Me.list_box.ItemHeight = 16
        Me.list_box.Location = New System.Drawing.Point(299, 370)
        Me.list_box.Name = "list_box"
        Me.list_box.Size = New System.Drawing.Size(216, 68)
        Me.list_box.TabIndex = 426
        Me.list_box.Visible = False
        '
        'txtreceivedby
        '
        Me.txtreceivedby.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtreceivedby.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtreceivedby.Location = New System.Drawing.Point(45, 442)
        Me.txtreceivedby.Name = "txtreceivedby"
        Me.txtreceivedby.Size = New System.Drawing.Size(239, 22)
        Me.txtreceivedby.TabIndex = 16
        '
        'txtcheckedby
        '
        Me.txtcheckedby.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtcheckedby.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcheckedby.Location = New System.Drawing.Point(46, 410)
        Me.txtcheckedby.Name = "txtcheckedby"
        Me.txtcheckedby.Size = New System.Drawing.Size(238, 22)
        Me.txtcheckedby.TabIndex = 15
        '
        'txtconcession
        '
        Me.txtconcession.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtconcession.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtconcession.Location = New System.Drawing.Point(46, 378)
        Me.txtconcession.Name = "txtconcession"
        Me.txtconcession.Size = New System.Drawing.Size(238, 22)
        Me.txtconcession.TabIndex = 14
        '
        'cmbSupplier
        '
        Me.cmbSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbSupplier.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSupplier.FormattingEnabled = True
        Me.cmbSupplier.Location = New System.Drawing.Point(46, 281)
        Me.cmbSupplier.Name = "cmbSupplier"
        Me.cmbSupplier.Size = New System.Drawing.Size(238, 24)
        Me.cmbSupplier.TabIndex = 11
        '
        'txtrsno
        '
        Me.txtrsno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtrsno.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtrsno.Location = New System.Drawing.Point(46, 251)
        Me.txtrsno.Name = "txtrsno"
        Me.txtrsno.ReadOnly = True
        Me.txtrsno.Size = New System.Drawing.Size(239, 22)
        Me.txtrsno.TabIndex = 10
        '
        'txtPlateNo
        '
        Me.txtPlateNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPlateNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPlateNo.Location = New System.Drawing.Point(46, 108)
        Me.txtPlateNo.Name = "txtPlateNo"
        Me.txtPlateNo.Size = New System.Drawing.Size(239, 22)
        Me.txtPlateNo.TabIndex = 5
        '
        'dtpDRDate
        '
        Me.dtpDRDate.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDRDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDRDate.Location = New System.Drawing.Point(96, 42)
        Me.dtpDRDate.Name = "dtpDRDate"
        Me.dtpDRDate.Size = New System.Drawing.Size(189, 22)
        Me.dtpDRDate.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(6, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Date:"
        '
        'lbl_dr_info_id
        '
        Me.lbl_dr_info_id.AutoSize = True
        Me.lbl_dr_info_id.Location = New System.Drawing.Point(44, 438)
        Me.lbl_dr_info_id.Name = "lbl_dr_info_id"
        Me.lbl_dr_info_id.Size = New System.Drawing.Size(13, 13)
        Me.lbl_dr_info_id.TabIndex = 427
        Me.lbl_dr_info_id.Text = "0"
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(10, 580)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(285, 41)
        Me.btnSave.TabIndex = 20
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'cmbChargeTo
        '
        Me.cmbChargeTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbChargeTo.FormattingEnabled = True
        Me.cmbChargeTo.Location = New System.Drawing.Point(175, 653)
        Me.cmbChargeTo.Name = "cmbChargeTo"
        Me.cmbChargeTo.Size = New System.Drawing.Size(121, 23)
        Me.cmbChargeTo.TabIndex = 100
        Me.cmbChargeTo.Visible = False
        '
        'cmbOperator
        '
        Me.cmbOperator.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOperator.FormattingEnabled = True
        Me.cmbOperator.Location = New System.Drawing.Point(118, 679)
        Me.cmbOperator.Name = "cmbOperator"
        Me.cmbOperator.Size = New System.Drawing.Size(180, 24)
        Me.cmbOperator.TabIndex = 100
        Me.cmbOperator.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.BackgroundImage = Global.SUPPLY.My.Resources.Resources.eus_bg_03
        Me.Panel1.Controls.Add(Me.loadingPanel)
        Me.Panel1.Controls.Add(Me.btnExit)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1541, 45)
        Me.Panel1.TabIndex = 0
        '
        'btnExit
        '
        Me.btnExit.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnExit.BackColor = System.Drawing.Color.Transparent
        Me.btnExit.BackgroundImage = Global.SUPPLY.My.Resources.Resources.close_button
        Me.btnExit.FlatAppearance.BorderSize = 0
        Me.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit.Location = New System.Drawing.Point(1504, 12)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(20, 20)
        Me.btnExit.TabIndex = 389
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'loadingPanel
        '
        Me.loadingPanel.BackColor = System.Drawing.Color.Transparent
        Me.loadingPanel.BackgroundImage = Global.SUPPLY.My.Resources.Resources.eus_bg_03
        Me.loadingPanel.Controls.Add(Me.Label20)
        Me.loadingPanel.Controls.Add(Me.PictureBox4)
        Me.loadingPanel.Location = New System.Drawing.Point(21, 6)
        Me.loadingPanel.Name = "loadingPanel"
        Me.loadingPanel.Size = New System.Drawing.Size(264, 31)
        Me.loadingPanel.TabIndex = 429
        Me.loadingPanel.Visible = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label20.Location = New System.Drawing.Point(43, 5)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(204, 19)
        Me.Label20.TabIndex = 1
        Me.Label20.Text = "Fetching data, please wait..."
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = Global.SUPPLY.My.Resources.Resources.spinner
        Me.PictureBox4.Location = New System.Drawing.Point(0, -3)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(38, 37)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox4.TabIndex = 0
        Me.PictureBox4.TabStop = False
        '
        'FDeliveryReceipt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1541, 753)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "FDeliveryReceipt"
        Me.Text = "FDeliveryReceipt"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.CMS_dgv_dr_list.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        CType(Me.dgv_dr_list, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.loadingPanel.ResumeLayout(False)
        Me.loadingPanel.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents btnSave As Button
    Friend WithEvents txtreceivedby As TextBox
    Friend WithEvents txtcheckedby As TextBox
    Friend WithEvents txtconcession As TextBox
    Friend WithEvents cmbSupplier As ComboBox
    Friend WithEvents txtrsno As TextBox
    Friend WithEvents cmbOperator As ComboBox
    Friend WithEvents txtPlateNo As TextBox
    Friend WithEvents dtpDRDate As DateTimePicker
    Friend WithEvents Panel4 As Panel
    Friend WithEvents CMS_dgv_dr_list As ContextMenuStrip
    Friend WithEvents SplitQtyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddSourceToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProjectToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OthersToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Panel5 As Panel
    Friend WithEvents dgv_dr_list As DataGridView
    Friend WithEvents Panel6 As Panel
    Friend WithEvents txtsplitqty As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents cmbChargeTo As ComboBox
    Friend WithEvents list_box As ListBox
    Friend WithEvents lbl_dr_info_id As Label
    Friend WithEvents Panel7 As Panel
    Friend WithEvents SelectToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UnselectToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label16 As Label
    Friend WithEvents cmbOptions As ComboBox
    Friend WithEvents cmbDrOptions As ComboBox
    Friend WithEvents EquipmentToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CopySourceToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CopyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PasteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents lboxUnit As ListBox
    Friend WithEvents cmbWsNo_PoNo As ComboBox
    Friend WithEvents txtDriver As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents txtRemarks As TextBox
    Friend WithEvents txtprice As TextBox
    Friend WithEvents cmbRRNo As ComboBox
    Friend WithEvents Button1 As Button
    Friend WithEvents col_checkbox As DataGridViewCheckBoxColumn
    Friend WithEvents col_dr_no As DataGridViewTextBoxColumn
    Friend WithEvents col_source As DataGridViewTextBoxColumn
    Friend WithEvents col_category As DataGridViewTextBoxColumn
    Friend WithEvents col_qty As DataGridViewTextBoxColumn
    Friend WithEvents col_item_name As DataGridViewTextBoxColumn
    Friend WithEvents col_rs_id As DataGridViewTextBoxColumn
    Friend WithEvents col_dr_item_id As DataGridViewTextBoxColumn
    Friend WithEvents col_wh_id As DataGridViewTextBoxColumn
    Friend WithEvents col_select As DataGridViewTextBoxColumn
    Friend WithEvents col_ws_id As DataGridViewTextBoxColumn
    Friend WithEvents col_qty_withdrawn As DataGridViewTextBoxColumn
    Friend WithEvents col_price As DataGridViewTextBoxColumn
    Friend WithEvents rr_item_id As DataGridViewTextBoxColumn
    Friend WithEvents bw_get_supplier As System.ComponentModel.BackgroundWorker
    Friend WithEvents bw_get_operator As System.ComponentModel.BackgroundWorker
    Friend WithEvents bw_get_type_of_charges As System.ComponentModel.BackgroundWorker
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents BackgroundWorker3 As System.ComponentModel.BackgroundWorker
    Friend WithEvents bw_check_if_done As System.ComponentModel.BackgroundWorker
    Friend WithEvents bw_display_balance_out As System.ComponentModel.BackgroundWorker
    Friend WithEvents Panel8 As Panel
    Friend WithEvents btnExit As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents dtpDateSubmitted As DateTimePicker
    Friend WithEvents Label13 As Label
    Friend WithEvents BW_initializeData As System.ComponentModel.BackgroundWorker
    Friend WithEvents BW_loadingEffects As System.ComponentModel.BackgroundWorker
    Friend WithEvents Panel9 As Panel
    Friend WithEvents cmbTypeofCharge As ComboBox
    Friend WithEvents txtChargeTo As TextBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents cmbTransaction As ComboBox
    Friend WithEvents BW_get_aggregates_balances As System.ComponentModel.BackgroundWorker
    Friend WithEvents loadingPanel As Panel
    Friend WithEvents Label20 As Label
    Friend WithEvents PictureBox4 As PictureBox
End Class
