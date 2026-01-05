<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FRequesitionFormForDR
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FRequesitionFormForDR))
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RemoveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditRSQtyForCuttingOfRSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreateNewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreateWithdrawalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreatePurchaseOrderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreateReceivingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreateDeliveryReceiptToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QuarryToStockpileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QuarryToProjectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OutsourceToStockpileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StockpileToStockpileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StockpileToProjectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ItemCheckingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemovedItemCheckedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddMoreChargesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CancelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CancelToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.UndoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.POToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CancelPOToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UndoToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.WSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CancelWSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UndoToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SearchByToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreateMainRSQuantityToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ColumnSettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.panel_color_legend_receiving = New System.Windows.Forms.Panel()
        Me.panel_color_legend_total = New System.Windows.Forms.Panel()
        Me.lblDRrr = New System.Windows.Forms.Label()
        Me.panel_color_legend_dr = New System.Windows.Forms.Panel()
        Me.lblWithdrawal = New System.Windows.Forms.Label()
        Me.lblRS = New System.Windows.Forms.Label()
        Me.panel_color_legend_withdrawal_po = New System.Windows.Forms.Panel()
        Me.lblMainRS = New System.Windows.Forms.Label()
        Me.panel_color_legend_sub = New System.Windows.Forms.Panel()
        Me.panel_color_legend_main = New System.Windows.Forms.Panel()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.loadingPanel = New System.Windows.Forms.Panel()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.WasteDisposalAndOthersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel3.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.loadingPanel.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.DataGridView1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 56)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1324, 586)
        Me.Panel3.TabIndex = 5
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(1324, 586)
        Me.DataGridView1.TabIndex = 3
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RemoveToolStripMenuItem, Me.EditToolStripMenuItem, Me.CreateNewToolStripMenuItem, Me.CreateWithdrawalToolStripMenuItem, Me.CreatePurchaseOrderToolStripMenuItem, Me.CreateReceivingToolStripMenuItem, Me.CreateDeliveryReceiptToolStripMenuItem, Me.ItemCheckingToolStripMenuItem, Me.RemovedItemCheckedToolStripMenuItem, Me.AddMoreChargesToolStripMenuItem, Me.CancelToolStripMenuItem, Me.SearchByToolStripMenuItem, Me.CreateMainRSQuantityToolStripMenuItem, Me.RefreshToolStripMenuItem, Me.ColumnSettingsToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(204, 356)
        '
        'RemoveToolStripMenuItem
        '
        Me.RemoveToolStripMenuItem.Image = Global.SUPPLY.My.Resources.Resources.remove_icon
        Me.RemoveToolStripMenuItem.Name = "RemoveToolStripMenuItem"
        Me.RemoveToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.RemoveToolStripMenuItem.Text = "Remove"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditAllToolStripMenuItem, Me.EditRSQtyForCuttingOfRSToolStripMenuItem})
        Me.EditToolStripMenuItem.Image = Global.SUPPLY.My.Resources.Resources.request
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'EditAllToolStripMenuItem
        '
        Me.EditAllToolStripMenuItem.Name = "EditAllToolStripMenuItem"
        Me.EditAllToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.EditAllToolStripMenuItem.Text = "Edit All"
        '
        'EditRSQtyForCuttingOfRSToolStripMenuItem
        '
        Me.EditRSQtyForCuttingOfRSToolStripMenuItem.Name = "EditRSQtyForCuttingOfRSToolStripMenuItem"
        Me.EditRSQtyForCuttingOfRSToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.EditRSQtyForCuttingOfRSToolStripMenuItem.Text = "Edit RS Qty"
        '
        'CreateNewToolStripMenuItem
        '
        Me.CreateNewToolStripMenuItem.Image = Global.SUPPLY.My.Resources.Resources.done
        Me.CreateNewToolStripMenuItem.Name = "CreateNewToolStripMenuItem"
        Me.CreateNewToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.CreateNewToolStripMenuItem.Text = "Create Requesition"
        '
        'CreateWithdrawalToolStripMenuItem
        '
        Me.CreateWithdrawalToolStripMenuItem.Name = "CreateWithdrawalToolStripMenuItem"
        Me.CreateWithdrawalToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.CreateWithdrawalToolStripMenuItem.Text = "Create Withdrawal"
        '
        'CreatePurchaseOrderToolStripMenuItem
        '
        Me.CreatePurchaseOrderToolStripMenuItem.Name = "CreatePurchaseOrderToolStripMenuItem"
        Me.CreatePurchaseOrderToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.CreatePurchaseOrderToolStripMenuItem.Text = "Create Purchase Order"
        '
        'CreateReceivingToolStripMenuItem
        '
        Me.CreateReceivingToolStripMenuItem.Name = "CreateReceivingToolStripMenuItem"
        Me.CreateReceivingToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.CreateReceivingToolStripMenuItem.Text = "Create Receiving"
        '
        'CreateDeliveryReceiptToolStripMenuItem
        '
        Me.CreateDeliveryReceiptToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.QuarryToStockpileToolStripMenuItem, Me.QuarryToProjectToolStripMenuItem, Me.OutsourceToStockpileToolStripMenuItem, Me.StockpileToStockpileToolStripMenuItem, Me.StockpileToProjectToolStripMenuItem, Me.WasteDisposalAndOthersToolStripMenuItem})
        Me.CreateDeliveryReceiptToolStripMenuItem.Name = "CreateDeliveryReceiptToolStripMenuItem"
        Me.CreateDeliveryReceiptToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.CreateDeliveryReceiptToolStripMenuItem.Text = "Create Delivery Receipt"
        '
        'QuarryToStockpileToolStripMenuItem
        '
        Me.QuarryToStockpileToolStripMenuItem.Name = "QuarryToStockpileToolStripMenuItem"
        Me.QuarryToStockpileToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.QuarryToStockpileToolStripMenuItem.Text = "Quarry to Stockpile"
        '
        'QuarryToProjectToolStripMenuItem
        '
        Me.QuarryToProjectToolStripMenuItem.Name = "QuarryToProjectToolStripMenuItem"
        Me.QuarryToProjectToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.QuarryToProjectToolStripMenuItem.Text = "Quarry to Project"
        '
        'OutsourceToStockpileToolStripMenuItem
        '
        Me.OutsourceToStockpileToolStripMenuItem.Name = "OutsourceToStockpileToolStripMenuItem"
        Me.OutsourceToStockpileToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.OutsourceToStockpileToolStripMenuItem.Text = "Outsource to Stockpile"
        '
        'StockpileToStockpileToolStripMenuItem
        '
        Me.StockpileToStockpileToolStripMenuItem.Name = "StockpileToStockpileToolStripMenuItem"
        Me.StockpileToStockpileToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.StockpileToStockpileToolStripMenuItem.Text = "Stockpile to Stockpile"
        '
        'StockpileToProjectToolStripMenuItem
        '
        Me.StockpileToProjectToolStripMenuItem.Name = "StockpileToProjectToolStripMenuItem"
        Me.StockpileToProjectToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.StockpileToProjectToolStripMenuItem.Text = "Stockpile to Project"
        '
        'ItemCheckingToolStripMenuItem
        '
        Me.ItemCheckingToolStripMenuItem.Name = "ItemCheckingToolStripMenuItem"
        Me.ItemCheckingToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.ItemCheckingToolStripMenuItem.Text = "Item Checking"
        '
        'RemovedItemCheckedToolStripMenuItem
        '
        Me.RemovedItemCheckedToolStripMenuItem.Name = "RemovedItemCheckedToolStripMenuItem"
        Me.RemovedItemCheckedToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.RemovedItemCheckedToolStripMenuItem.Text = "Removed Item Checked"
        '
        'AddMoreChargesToolStripMenuItem
        '
        Me.AddMoreChargesToolStripMenuItem.Name = "AddMoreChargesToolStripMenuItem"
        Me.AddMoreChargesToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.AddMoreChargesToolStripMenuItem.Text = "Add More Charges"
        '
        'CancelToolStripMenuItem
        '
        Me.CancelToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RSToolStripMenuItem, Me.POToolStripMenuItem, Me.WSToolStripMenuItem})
        Me.CancelToolStripMenuItem.Name = "CancelToolStripMenuItem"
        Me.CancelToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.CancelToolStripMenuItem.Text = "Cancel"
        '
        'RSToolStripMenuItem
        '
        Me.RSToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CancelToolStripMenuItem1, Me.UndoToolStripMenuItem})
        Me.RSToolStripMenuItem.Name = "RSToolStripMenuItem"
        Me.RSToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.RSToolStripMenuItem.Text = "RS"
        '
        'CancelToolStripMenuItem1
        '
        Me.CancelToolStripMenuItem1.Name = "CancelToolStripMenuItem1"
        Me.CancelToolStripMenuItem1.Size = New System.Drawing.Size(126, 22)
        Me.CancelToolStripMenuItem1.Text = "Cancel RS"
        '
        'UndoToolStripMenuItem
        '
        Me.UndoToolStripMenuItem.Name = "UndoToolStripMenuItem"
        Me.UndoToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
        Me.UndoToolStripMenuItem.Text = "Undo"
        '
        'POToolStripMenuItem
        '
        Me.POToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CancelPOToolStripMenuItem, Me.UndoToolStripMenuItem1})
        Me.POToolStripMenuItem.Name = "POToolStripMenuItem"
        Me.POToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.POToolStripMenuItem.Text = "PO"
        '
        'CancelPOToolStripMenuItem
        '
        Me.CancelPOToolStripMenuItem.Name = "CancelPOToolStripMenuItem"
        Me.CancelPOToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.CancelPOToolStripMenuItem.Text = "Cancel PO"
        '
        'UndoToolStripMenuItem1
        '
        Me.UndoToolStripMenuItem1.Name = "UndoToolStripMenuItem1"
        Me.UndoToolStripMenuItem1.Size = New System.Drawing.Size(129, 22)
        Me.UndoToolStripMenuItem1.Text = "Undo"
        '
        'WSToolStripMenuItem
        '
        Me.WSToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CancelWSToolStripMenuItem, Me.UndoToolStripMenuItem2})
        Me.WSToolStripMenuItem.Name = "WSToolStripMenuItem"
        Me.WSToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.WSToolStripMenuItem.Text = "WS"
        '
        'CancelWSToolStripMenuItem
        '
        Me.CancelWSToolStripMenuItem.Name = "CancelWSToolStripMenuItem"
        Me.CancelWSToolStripMenuItem.Size = New System.Drawing.Size(130, 22)
        Me.CancelWSToolStripMenuItem.Text = "Cancel WS"
        '
        'UndoToolStripMenuItem2
        '
        Me.UndoToolStripMenuItem2.Name = "UndoToolStripMenuItem2"
        Me.UndoToolStripMenuItem2.Size = New System.Drawing.Size(130, 22)
        Me.UndoToolStripMenuItem2.Text = "Undo"
        '
        'SearchByToolStripMenuItem
        '
        Me.SearchByToolStripMenuItem.Name = "SearchByToolStripMenuItem"
        Me.SearchByToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.SearchByToolStripMenuItem.Text = "Search By"
        '
        'CreateMainRSQuantityToolStripMenuItem
        '
        Me.CreateMainRSQuantityToolStripMenuItem.Name = "CreateMainRSQuantityToolStripMenuItem"
        Me.CreateMainRSQuantityToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.CreateMainRSQuantityToolStripMenuItem.Text = "Create Main RS Quantity"
        '
        'RefreshToolStripMenuItem
        '
        Me.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem"
        Me.RefreshToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.RefreshToolStripMenuItem.Text = "Refresh"
        '
        'ColumnSettingsToolStripMenuItem
        '
        Me.ColumnSettingsToolStripMenuItem.Name = "ColumnSettingsToolStripMenuItem"
        Me.ColumnSettingsToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.ColumnSettingsToolStripMenuItem.Text = "Column Settings"
        '
        'Panel2
        '
        Me.Panel2.BackgroundImage = Global.SUPPLY.My.Resources.Resources.bg_line
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.Panel11)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 642)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1324, 50)
        Me.Panel2.TabIndex = 4
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Transparent
        Me.Panel4.Controls.Add(Me.Label13)
        Me.Panel4.Controls.Add(Me.Label12)
        Me.Panel4.Controls.Add(Me.panel_color_legend_receiving)
        Me.Panel4.Controls.Add(Me.panel_color_legend_total)
        Me.Panel4.Controls.Add(Me.lblDRrr)
        Me.Panel4.Controls.Add(Me.panel_color_legend_dr)
        Me.Panel4.Controls.Add(Me.lblWithdrawal)
        Me.Panel4.Controls.Add(Me.lblRS)
        Me.Panel4.Controls.Add(Me.panel_color_legend_withdrawal_po)
        Me.Panel4.Controls.Add(Me.lblMainRS)
        Me.Panel4.Controls.Add(Me.panel_color_legend_sub)
        Me.Panel4.Controls.Add(Me.panel_color_legend_main)
        Me.Panel4.Location = New System.Drawing.Point(9, 10)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(797, 31)
        Me.Panel4.TabIndex = 424
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Bombardier", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(451, 9)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(121, 16)
        Me.Label13.TabIndex = 11
        Me.Label13.Text = "RECEIVING FOR DR"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Bombardier", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(616, 9)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(180, 16)
        Me.Label12.TabIndex = 9
        Me.Label12.Text = "TOTAL/REMAINING BALANCE"
        '
        'panel_color_legend_receiving
        '
        Me.panel_color_legend_receiving.BackColor = System.Drawing.Color.LightPink
        Me.panel_color_legend_receiving.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panel_color_legend_receiving.Location = New System.Drawing.Point(429, 6)
        Me.panel_color_legend_receiving.Name = "panel_color_legend_receiving"
        Me.panel_color_legend_receiving.Size = New System.Drawing.Size(19, 18)
        Me.panel_color_legend_receiving.TabIndex = 10
        '
        'panel_color_legend_total
        '
        Me.panel_color_legend_total.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.panel_color_legend_total.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panel_color_legend_total.Location = New System.Drawing.Point(594, 6)
        Me.panel_color_legend_total.Name = "panel_color_legend_total"
        Me.panel_color_legend_total.Size = New System.Drawing.Size(19, 18)
        Me.panel_color_legend_total.TabIndex = 8
        '
        'lblDRrr
        '
        Me.lblDRrr.AutoSize = True
        Me.lblDRrr.Font = New System.Drawing.Font("Bombardier", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDRrr.ForeColor = System.Drawing.Color.White
        Me.lblDRrr.Location = New System.Drawing.Point(370, 9)
        Me.lblDRrr.Name = "lblDRrr"
        Me.lblDRrr.Size = New System.Drawing.Size(23, 16)
        Me.lblDRrr.TabIndex = 7
        Me.lblDRrr.Text = "DR"
        '
        'panel_color_legend_dr
        '
        Me.panel_color_legend_dr.BackColor = System.Drawing.Color.LightYellow
        Me.panel_color_legend_dr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panel_color_legend_dr.Location = New System.Drawing.Point(348, 6)
        Me.panel_color_legend_dr.Name = "panel_color_legend_dr"
        Me.panel_color_legend_dr.Size = New System.Drawing.Size(19, 18)
        Me.panel_color_legend_dr.TabIndex = 6
        '
        'lblWithdrawal
        '
        Me.lblWithdrawal.AutoSize = True
        Me.lblWithdrawal.Font = New System.Drawing.Font("Bombardier", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWithdrawal.ForeColor = System.Drawing.Color.White
        Me.lblWithdrawal.Location = New System.Drawing.Point(226, 9)
        Me.lblWithdrawal.Name = "lblWithdrawal"
        Me.lblWithdrawal.Size = New System.Drawing.Size(107, 16)
        Me.lblWithdrawal.TabIndex = 5
        Me.lblWithdrawal.Text = "WITHDRAWAL/PO"
        '
        'lblRS
        '
        Me.lblRS.AutoSize = True
        Me.lblRS.Font = New System.Drawing.Font("Bombardier", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRS.ForeColor = System.Drawing.Color.White
        Me.lblRS.Location = New System.Drawing.Point(156, 9)
        Me.lblRS.Name = "lblRS"
        Me.lblRS.Size = New System.Drawing.Size(23, 16)
        Me.lblRS.TabIndex = 3
        Me.lblRS.Text = "RS"
        '
        'panel_color_legend_withdrawal_po
        '
        Me.panel_color_legend_withdrawal_po.BackColor = System.Drawing.Color.LightGreen
        Me.panel_color_legend_withdrawal_po.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panel_color_legend_withdrawal_po.Location = New System.Drawing.Point(204, 6)
        Me.panel_color_legend_withdrawal_po.Name = "panel_color_legend_withdrawal_po"
        Me.panel_color_legend_withdrawal_po.Size = New System.Drawing.Size(19, 18)
        Me.panel_color_legend_withdrawal_po.TabIndex = 4
        '
        'lblMainRS
        '
        Me.lblMainRS.AutoSize = True
        Me.lblMainRS.Font = New System.Drawing.Font("Bombardier", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMainRS.ForeColor = System.Drawing.Color.White
        Me.lblMainRS.Location = New System.Drawing.Point(39, 9)
        Me.lblMainRS.Name = "lblMainRS"
        Me.lblMainRS.Size = New System.Drawing.Size(87, 16)
        Me.lblMainRS.TabIndex = 1
        Me.lblMainRS.Text = "MAIN RS QTY"
        '
        'panel_color_legend_sub
        '
        Me.panel_color_legend_sub.BackColor = System.Drawing.Color.DarkGreen
        Me.panel_color_legend_sub.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panel_color_legend_sub.Location = New System.Drawing.Point(134, 6)
        Me.panel_color_legend_sub.Name = "panel_color_legend_sub"
        Me.panel_color_legend_sub.Size = New System.Drawing.Size(19, 18)
        Me.panel_color_legend_sub.TabIndex = 2
        '
        'panel_color_legend_main
        '
        Me.panel_color_legend_main.BackColor = System.Drawing.Color.Lime
        Me.panel_color_legend_main.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panel_color_legend_main.Location = New System.Drawing.Point(17, 6)
        Me.panel_color_legend_main.Name = "panel_color_legend_main"
        Me.panel_color_legend_main.Size = New System.Drawing.Size(19, 18)
        Me.panel_color_legend_main.TabIndex = 0
        '
        'Panel11
        '
        Me.Panel11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel11.BackColor = System.Drawing.Color.Transparent
        Me.Panel11.Controls.Add(Me.Label10)
        Me.Panel11.Controls.Add(Me.btnSearch)
        Me.Panel11.Controls.Add(Me.txtSearch)
        Me.Panel11.Location = New System.Drawing.Point(710, 4)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(602, 41)
        Me.Panel11.TabIndex = 426
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Bombardier", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.GreenYellow
        Me.Label10.Location = New System.Drawing.Point(53, 12)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(43, 16)
        Me.Label10.TabIndex = 452
        Me.Label10.Text = "RS NO:"
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnSearch.BackgroundImage = Global.SUPPLY.My.Resources.Resources.eus_bg_03
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.Font = New System.Drawing.Font("Bombardier", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.Color.White
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearch.Location = New System.Drawing.Point(429, 4)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(163, 33)
        Me.btnSearch.TabIndex = 425
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.txtSearch.Location = New System.Drawing.Point(140, 10)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(242, 20)
        Me.txtSearch.TabIndex = 4
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = Global.SUPPLY.My.Resources.Resources.eus_bg_03
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.loadingPanel)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1324, 56)
        Me.Panel1.TabIndex = 3
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = Global.SUPPLY.My.Resources.Resources.reg_button
        Me.PictureBox2.Location = New System.Drawing.Point(912, 7)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(39, 40)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 432
        Me.PictureBox2.TabStop = False
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.Color.Transparent
        Me.btnClose.BackgroundImage = Global.SUPPLY.My.Resources.Resources.close_button
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Location = New System.Drawing.Point(1276, 17)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(3, 3, 10, 3)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(22, 22)
        Me.btnClose.TabIndex = 431
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Bombardier", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.SpringGreen
        Me.Label1.Location = New System.Drawing.Point(954, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(195, 30)
        Me.Label1.TabIndex = 430
        Me.Label1.Text = "REQUISITION FORM"
        '
        'loadingPanel
        '
        Me.loadingPanel.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.loadingPanel.BackColor = System.Drawing.Color.Transparent
        Me.loadingPanel.BackgroundImage = Global.SUPPLY.My.Resources.Resources.eus_bg_03
        Me.loadingPanel.Controls.Add(Me.Label20)
        Me.loadingPanel.Controls.Add(Me.PictureBox4)
        Me.loadingPanel.Location = New System.Drawing.Point(628, 11)
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
        'WasteDisposalAndOthersToolStripMenuItem
        '
        Me.WasteDisposalAndOthersToolStripMenuItem.Name = "WasteDisposalAndOthersToolStripMenuItem"
        Me.WasteDisposalAndOthersToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.WasteDisposalAndOthersToolStripMenuItem.Text = "Waste Disposal and Others"
        '
        'FRequesitionFormForDR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1324, 692)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FRequesitionFormForDR"
        Me.Text = "FRequesitionFormForDR"
        Me.Panel3.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.loadingPanel.ResumeLayout(False)
        Me.loadingPanel.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents loadingPanel As Panel
    Friend WithEvents Label20 As Label
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents panel_color_legend_receiving As Panel
    Friend WithEvents panel_color_legend_total As Panel
    Friend WithEvents lblDRrr As Label
    Friend WithEvents panel_color_legend_dr As Panel
    Friend WithEvents lblWithdrawal As Label
    Friend WithEvents lblRS As Label
    Friend WithEvents panel_color_legend_withdrawal_po As Panel
    Friend WithEvents lblMainRS As Label
    Friend WithEvents panel_color_legend_sub As Panel
    Friend WithEvents panel_color_legend_main As Panel
    Friend WithEvents btnSearch As Button
    Friend WithEvents Panel11 As Panel
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RemoveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CreateNewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CreateWithdrawalToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CreatePurchaseOrderToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CreateReceivingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CreateDeliveryReceiptToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ItemCheckingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RemovedItemCheckedToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditAllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnClose As Button
    Friend WithEvents AddMoreChargesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CancelToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RSToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CancelToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents UndoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label10 As Label
    Friend WithEvents SearchByToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CreateMainRSQuantityToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents POToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CancelPOToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UndoToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents RefreshToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditRSQtyForCuttingOfRSToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WSToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CancelWSToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UndoToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents ColumnSettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents QuarryToStockpileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents QuarryToProjectToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OutsourceToStockpileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StockpileToStockpileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StockpileToProjectToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WasteDisposalAndOthersToolStripMenuItem As ToolStripMenuItem
End Class
