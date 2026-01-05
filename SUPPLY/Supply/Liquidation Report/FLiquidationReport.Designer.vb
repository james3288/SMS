<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FLiquidationReport
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.DTP_search_liquidation = New System.Windows.Forms.DateTimePicker()
        Me.txtTypeofCharge = New System.Windows.Forms.TextBox()
        Me.LlbTitleAllowanceSummary = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel_Cancelled_Remarks = New System.Windows.Forms.Panel()
        Me.txtCancelledRemarks = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnSaveCancelled = New System.Windows.Forms.Button()
        Me.lbleRemarks = New System.Windows.Forms.Label()
        Me.Panel_date_duration = New System.Windows.Forms.Panel()
        Me.btnExit_panel_duration = New System.Windows.Forms.Button()
        Me.lblTo_date = New System.Windows.Forms.Label()
        Me.btnSearchDuration = New System.Windows.Forms.Button()
        Me.DTP_to = New System.Windows.Forms.DateTimePicker()
        Me.lblFrom_date = New System.Windows.Forms.Label()
        Me.DtpickerFrom = New System.Windows.Forms.DateTimePicker()
        Me.lvlLiquidationReport = New System.Windows.Forms.ListView()
        Me.Id = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.DateRequest = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TypeOfRequest = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Consolidated_title = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Type_of_Purchase = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Ws_or_Cash_Invoice = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Rs_no = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Type_of_Charges = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Charge_to = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.location = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.jo_no = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Item_name = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Item_desc = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Quantity = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Unit = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Amount = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Purpose = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Conducted_by = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Date_needed = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Requested_by = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.User_Login_Save = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Date_Login = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.update_login = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.update_date = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.status_cancel = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cancelled_remarks = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.tors_ca_id = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblConsolidated_account = New System.Windows.Forms.Label()
        Me.cmbConsolidated_account = New System.Windows.Forms.ComboBox()
        Me.cmbTypeOfChargesName = New System.Windows.Forms.ComboBox()
        Me.LblTypeOfCharges = New System.Windows.Forms.Label()
        Me.txtItemName = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtConducted_by = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtws_cash_voice = New System.Windows.Forms.TextBox()
        Me.ws_no_cash_voice = New System.Windows.Forms.Label()
        Me.cmbtype_of_purchase = New System.Windows.Forms.ComboBox()
        Me.type_of_purchasing = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.txtRequestBy = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.DTPTimeNeeded = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtPurpose = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtUnit = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtQty = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtItemDesc = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtJOno = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtLoc = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbTOR_sub = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.cmbTypeofCharge = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtRSno = New System.Windows.Forms.TextBox()
        Me.lblItemName = New System.Windows.Forms.Label()
        Me.cmbRequestType = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.DTPReq = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblSearchByCategory = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.cmbSearch = New System.Windows.Forms.ComboBox()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip_Cancel = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportToExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TotalLitersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CvExportToExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TotalAmountToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel_Cancelled_Remarks.SuspendLayout()
        Me.Panel_date_duration.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel3, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel5, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1303, 1030)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 289.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Panel4, 1, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(1297, 37)
        Me.TableLayoutPanel3.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.DTP_search_liquidation)
        Me.Panel1.Controls.Add(Me.txtTypeofCharge)
        Me.Panel1.Controls.Add(Me.LlbTitleAllowanceSummary)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1002, 31)
        Me.Panel1.TabIndex = 167
        '
        'DTP_search_liquidation
        '
        Me.DTP_search_liquidation.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_search_liquidation.Location = New System.Drawing.Point(527, 5)
        Me.DTP_search_liquidation.Name = "DTP_search_liquidation"
        Me.DTP_search_liquidation.Size = New System.Drawing.Size(264, 26)
        Me.DTP_search_liquidation.TabIndex = 365
        Me.DTP_search_liquidation.Visible = False
        '
        'txtTypeofCharge
        '
        Me.txtTypeofCharge.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTypeofCharge.Location = New System.Drawing.Point(21, 4)
        Me.txtTypeofCharge.Name = "txtTypeofCharge"
        Me.txtTypeofCharge.Size = New System.Drawing.Size(241, 24)
        Me.txtTypeofCharge.TabIndex = 134
        Me.txtTypeofCharge.Visible = False
        '
        'LlbTitleAllowanceSummary
        '
        Me.LlbTitleAllowanceSummary.AutoSize = True
        Me.LlbTitleAllowanceSummary.BackColor = System.Drawing.Color.Transparent
        Me.LlbTitleAllowanceSummary.Font = New System.Drawing.Font("Gill Sans Ultra Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LlbTitleAllowanceSummary.ForeColor = System.Drawing.Color.White
        Me.LlbTitleAllowanceSummary.Location = New System.Drawing.Point(245, 7)
        Me.LlbTitleAllowanceSummary.Name = "LlbTitleAllowanceSummary"
        Me.LlbTitleAllowanceSummary.Size = New System.Drawing.Size(265, 26)
        Me.LlbTitleAllowanceSummary.TabIndex = 133
        Me.LlbTitleAllowanceSummary.Text = "LIQUIDATION REPORT"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.GroupBox2)
        Me.Panel4.Controls.Add(Me.btnExit)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(1011, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(283, 31)
        Me.Panel4.TabIndex = 168
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Panel6)
        Me.GroupBox2.Location = New System.Drawing.Point(22, -5)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(227, 34)
        Me.GroupBox2.TabIndex = 389
        Me.GroupBox2.TabStop = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(6, 12)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(85, 15)
        Me.Label16.TabIndex = 388
        Me.Label16.Text = "Color Legend:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(113, 12)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(63, 15)
        Me.Label13.TabIndex = 387
        Me.Label13.Text = "Cancelled"
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.OrangeRed
        Me.Panel6.Location = New System.Drawing.Point(97, 10)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(15, 17)
        Me.Panel6.TabIndex = 366
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.Transparent
        Me.btnExit.BackgroundImage = Global.SUPPLY.My.Resources.Resources.close_button
        Me.btnExit.FlatAppearance.BorderSize = 0
        Me.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit.Location = New System.Drawing.Point(255, 5)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(22, 22)
        Me.btnExit.TabIndex = 386
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Panel3, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel2, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 46)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1297, 926)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Panel_Cancelled_Remarks)
        Me.Panel3.Controls.Add(Me.Panel_date_duration)
        Me.Panel3.Controls.Add(Me.lvlLiquidationReport)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(253, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1041, 920)
        Me.Panel3.TabIndex = 1
        '
        'Panel_Cancelled_Remarks
        '
        Me.Panel_Cancelled_Remarks.BackgroundImage = Global.SUPPLY.My.Resources.Resources.bg_line
        Me.Panel_Cancelled_Remarks.Controls.Add(Me.txtCancelledRemarks)
        Me.Panel_Cancelled_Remarks.Controls.Add(Me.Button1)
        Me.Panel_Cancelled_Remarks.Controls.Add(Me.btnSaveCancelled)
        Me.Panel_Cancelled_Remarks.Controls.Add(Me.lbleRemarks)
        Me.Panel_Cancelled_Remarks.Location = New System.Drawing.Point(361, 162)
        Me.Panel_Cancelled_Remarks.Name = "Panel_Cancelled_Remarks"
        Me.Panel_Cancelled_Remarks.Size = New System.Drawing.Size(319, 139)
        Me.Panel_Cancelled_Remarks.TabIndex = 400
        Me.Panel_Cancelled_Remarks.Visible = False
        '
        'txtCancelledRemarks
        '
        Me.txtCancelledRemarks.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCancelledRemarks.Location = New System.Drawing.Point(17, 38)
        Me.txtCancelledRemarks.Multiline = True
        Me.txtCancelledRemarks.Name = "txtCancelledRemarks"
        Me.txtCancelledRemarks.Size = New System.Drawing.Size(286, 57)
        Me.txtCancelledRemarks.TabIndex = 361
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.BackgroundImage = Global.SUPPLY.My.Resources.Resources.close_button
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(287, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(20, 20)
        Me.Button1.TabIndex = 360
        Me.Button1.UseVisualStyleBackColor = False
        '
        'btnSaveCancelled
        '
        Me.btnSaveCancelled.BackColor = System.Drawing.Color.DarkGray
        Me.btnSaveCancelled.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveCancelled.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnSaveCancelled.Location = New System.Drawing.Point(189, 101)
        Me.btnSaveCancelled.Name = "btnSaveCancelled"
        Me.btnSaveCancelled.Size = New System.Drawing.Size(114, 27)
        Me.btnSaveCancelled.TabIndex = 361
        Me.btnSaveCancelled.Text = "Save"
        Me.btnSaveCancelled.UseVisualStyleBackColor = False
        '
        'lbleRemarks
        '
        Me.lbleRemarks.AutoSize = True
        Me.lbleRemarks.BackColor = System.Drawing.Color.Transparent
        Me.lbleRemarks.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbleRemarks.ForeColor = System.Drawing.SystemColors.Control
        Me.lbleRemarks.Location = New System.Drawing.Point(14, 15)
        Me.lbleRemarks.Name = "lbleRemarks"
        Me.lbleRemarks.Size = New System.Drawing.Size(76, 17)
        Me.lbleRemarks.TabIndex = 1
        Me.lbleRemarks.Text = "Remarks:"
        '
        'Panel_date_duration
        '
        Me.Panel_date_duration.BackgroundImage = Global.SUPPLY.My.Resources.Resources.bg_line
        Me.Panel_date_duration.Controls.Add(Me.btnExit_panel_duration)
        Me.Panel_date_duration.Controls.Add(Me.lblTo_date)
        Me.Panel_date_duration.Controls.Add(Me.btnSearchDuration)
        Me.Panel_date_duration.Controls.Add(Me.DTP_to)
        Me.Panel_date_duration.Controls.Add(Me.lblFrom_date)
        Me.Panel_date_duration.Controls.Add(Me.DtpickerFrom)
        Me.Panel_date_duration.Location = New System.Drawing.Point(361, 320)
        Me.Panel_date_duration.Name = "Panel_date_duration"
        Me.Panel_date_duration.Size = New System.Drawing.Size(319, 181)
        Me.Panel_date_duration.TabIndex = 399
        Me.Panel_date_duration.Visible = False
        '
        'btnExit_panel_duration
        '
        Me.btnExit_panel_duration.BackColor = System.Drawing.Color.Transparent
        Me.btnExit_panel_duration.BackgroundImage = Global.SUPPLY.My.Resources.Resources.close_button
        Me.btnExit_panel_duration.FlatAppearance.BorderSize = 0
        Me.btnExit_panel_duration.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnExit_panel_duration.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnExit_panel_duration.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit_panel_duration.Location = New System.Drawing.Point(287, 4)
        Me.btnExit_panel_duration.Name = "btnExit_panel_duration"
        Me.btnExit_panel_duration.Size = New System.Drawing.Size(20, 20)
        Me.btnExit_panel_duration.TabIndex = 360
        Me.btnExit_panel_duration.UseVisualStyleBackColor = False
        '
        'lblTo_date
        '
        Me.lblTo_date.AutoSize = True
        Me.lblTo_date.BackColor = System.Drawing.Color.Transparent
        Me.lblTo_date.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTo_date.ForeColor = System.Drawing.SystemColors.Control
        Me.lblTo_date.Location = New System.Drawing.Point(19, 75)
        Me.lblTo_date.Name = "lblTo_date"
        Me.lblTo_date.Size = New System.Drawing.Size(32, 17)
        Me.lblTo_date.TabIndex = 3
        Me.lblTo_date.Text = "To:"
        '
        'btnSearchDuration
        '
        Me.btnSearchDuration.BackColor = System.Drawing.Color.DarkGray
        Me.btnSearchDuration.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearchDuration.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnSearchDuration.Location = New System.Drawing.Point(193, 136)
        Me.btnSearchDuration.Name = "btnSearchDuration"
        Me.btnSearchDuration.Size = New System.Drawing.Size(114, 27)
        Me.btnSearchDuration.TabIndex = 23
        Me.btnSearchDuration.Text = "Search"
        Me.btnSearchDuration.UseVisualStyleBackColor = False
        '
        'DTP_to
        '
        Me.DTP_to.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_to.Location = New System.Drawing.Point(16, 95)
        Me.DTP_to.Name = "DTP_to"
        Me.DTP_to.Size = New System.Drawing.Size(291, 23)
        Me.DTP_to.TabIndex = 20
        '
        'lblFrom_date
        '
        Me.lblFrom_date.AutoSize = True
        Me.lblFrom_date.BackColor = System.Drawing.Color.Transparent
        Me.lblFrom_date.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFrom_date.ForeColor = System.Drawing.SystemColors.Control
        Me.lblFrom_date.Location = New System.Drawing.Point(18, 15)
        Me.lblFrom_date.Name = "lblFrom_date"
        Me.lblFrom_date.Size = New System.Drawing.Size(49, 17)
        Me.lblFrom_date.TabIndex = 1
        Me.lblFrom_date.Text = "From:"
        '
        'DtpickerFrom
        '
        Me.DtpickerFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpickerFrom.Location = New System.Drawing.Point(16, 35)
        Me.DtpickerFrom.Name = "DtpickerFrom"
        Me.DtpickerFrom.Size = New System.Drawing.Size(291, 23)
        Me.DtpickerFrom.TabIndex = 19
        '
        'lvlLiquidationReport
        '
        Me.lvlLiquidationReport.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Id, Me.DateRequest, Me.TypeOfRequest, Me.Consolidated_title, Me.Type_of_Purchase, Me.Ws_or_Cash_Invoice, Me.Rs_no, Me.Type_of_Charges, Me.Charge_to, Me.location, Me.jo_no, Me.Item_name, Me.Item_desc, Me.Quantity, Me.Unit, Me.Amount, Me.Purpose, Me.Conducted_by, Me.Date_needed, Me.Requested_by, Me.User_Login_Save, Me.Date_Login, Me.update_login, Me.update_date, Me.status_cancel, Me.cancelled_remarks, Me.tors_ca_id})
        Me.lvlLiquidationReport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvlLiquidationReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvlLiquidationReport.FullRowSelect = True
        Me.lvlLiquidationReport.GridLines = True
        Me.lvlLiquidationReport.HideSelection = False
        Me.lvlLiquidationReport.Location = New System.Drawing.Point(0, 0)
        Me.lvlLiquidationReport.Name = "lvlLiquidationReport"
        Me.lvlLiquidationReport.Size = New System.Drawing.Size(1041, 920)
        Me.lvlLiquidationReport.TabIndex = 1
        Me.lvlLiquidationReport.UseCompatibleStateImageBehavior = False
        Me.lvlLiquidationReport.View = System.Windows.Forms.View.Details
        '
        'Id
        '
        Me.Id.Text = "Id"
        Me.Id.Width = 0
        '
        'DateRequest
        '
        Me.DateRequest.Text = "Date Request"
        Me.DateRequest.Width = 120
        '
        'TypeOfRequest
        '
        Me.TypeOfRequest.Text = "Type of Request"
        Me.TypeOfRequest.Width = 230
        '
        'Consolidated_title
        '
        Me.Consolidated_title.Text = "Consolidated Title"
        Me.Consolidated_title.Width = 230
        '
        'Type_of_Purchase
        '
        Me.Type_of_Purchase.Text = "Type of Purchase"
        Me.Type_of_Purchase.Width = 120
        '
        'Ws_or_Cash_Invoice
        '
        Me.Ws_or_Cash_Invoice.Text = "Ws/Cash Invoice"
        Me.Ws_or_Cash_Invoice.Width = 120
        '
        'Rs_no
        '
        Me.Rs_no.Text = "Rs no."
        Me.Rs_no.Width = 120
        '
        'Type_of_Charges
        '
        Me.Type_of_Charges.Text = "Type of Charges"
        Me.Type_of_Charges.Width = 160
        '
        'Charge_to
        '
        Me.Charge_to.Text = "Charge to"
        Me.Charge_to.Width = 110
        '
        'location
        '
        Me.location.Text = "Location"
        Me.location.Width = 170
        '
        'jo_no
        '
        Me.jo_no.Text = "J.O. No."
        Me.jo_no.Width = 80
        '
        'Item_name
        '
        Me.Item_name.Text = "Item Name"
        Me.Item_name.Width = 200
        '
        'Item_desc
        '
        Me.Item_desc.Text = "Item Description"
        Me.Item_desc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Item_desc.Width = 150
        '
        'Quantity
        '
        Me.Quantity.Text = "Quantity"
        '
        'Unit
        '
        Me.Unit.Text = "Unit"
        Me.Unit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Unit.Width = 70
        '
        'Amount
        '
        Me.Amount.Text = "Amount"
        Me.Amount.Width = 150
        '
        'Purpose
        '
        Me.Purpose.Text = "Purpose"
        Me.Purpose.Width = 200
        '
        'Conducted_by
        '
        Me.Conducted_by.Text = "Conducted by"
        Me.Conducted_by.Width = 110
        '
        'Date_needed
        '
        Me.Date_needed.Text = "Date Needed"
        Me.Date_needed.Width = 110
        '
        'Requested_by
        '
        Me.Requested_by.Text = "Requested by"
        Me.Requested_by.Width = 150
        '
        'User_Login_Save
        '
        Me.User_Login_Save.Text = "User Login Save"
        Me.User_Login_Save.Width = 150
        '
        'Date_Login
        '
        Me.Date_Login.Text = "Date Login"
        Me.Date_Login.Width = 100
        '
        'update_login
        '
        Me.update_login.Text = "Update Login"
        Me.update_login.Width = 150
        '
        'update_date
        '
        Me.update_date.Text = "Update Date"
        Me.update_date.Width = 120
        '
        'status_cancel
        '
        Me.status_cancel.Text = "Cancelled Status"
        Me.status_cancel.Width = 120
        '
        'cancelled_remarks
        '
        Me.cancelled_remarks.Text = "Cancelled Remarks"
        Me.cancelled_remarks.Width = 120
        '
        'tors_ca_id
        '
        Me.tors_ca_id.Text = "tors_ca_id"
        Me.tors_ca_id.Width = 0
        '
        'Panel2
        '
        Me.Panel2.AutoScroll = True
        Me.Panel2.Controls.Add(Me.lblConsolidated_account)
        Me.Panel2.Controls.Add(Me.cmbConsolidated_account)
        Me.Panel2.Controls.Add(Me.cmbTypeOfChargesName)
        Me.Panel2.Controls.Add(Me.LblTypeOfCharges)
        Me.Panel2.Controls.Add(Me.txtItemName)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.txtConducted_by)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.txtws_cash_voice)
        Me.Panel2.Controls.Add(Me.ws_no_cash_voice)
        Me.Panel2.Controls.Add(Me.cmbtype_of_purchase)
        Me.Panel2.Controls.Add(Me.type_of_purchasing)
        Me.Panel2.Controls.Add(Me.Label19)
        Me.Panel2.Controls.Add(Me.btnSave)
        Me.Panel2.Controls.Add(Me.txtRequestBy)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.DTPTimeNeeded)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.txtPurpose)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.txtAmount)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.txtUnit)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.txtQty)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.txtItemDesc)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.txtJOno)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.txtLoc)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.cmbTOR_sub)
        Me.Panel2.Controls.Add(Me.Label23)
        Me.Panel2.Controls.Add(Me.cmbTypeofCharge)
        Me.Panel2.Controls.Add(Me.Label15)
        Me.Panel2.Controls.Add(Me.txtRSno)
        Me.Panel2.Controls.Add(Me.lblItemName)
        Me.Panel2.Controls.Add(Me.cmbRequestType)
        Me.Panel2.Controls.Add(Me.Label14)
        Me.Panel2.Controls.Add(Me.DTPReq)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(244, 920)
        Me.Panel2.TabIndex = 2
        '
        'lblConsolidated_account
        '
        Me.lblConsolidated_account.AutoSize = True
        Me.lblConsolidated_account.BackColor = System.Drawing.Color.Transparent
        Me.lblConsolidated_account.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConsolidated_account.ForeColor = System.Drawing.Color.White
        Me.lblConsolidated_account.Location = New System.Drawing.Point(0, 126)
        Me.lblConsolidated_account.Name = "lblConsolidated_account"
        Me.lblConsolidated_account.Size = New System.Drawing.Size(84, 15)
        Me.lblConsolidated_account.TabIndex = 466
        Me.lblConsolidated_account.Text = "Account Title:"
        '
        'cmbConsolidated_account
        '
        Me.cmbConsolidated_account.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbConsolidated_account.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbConsolidated_account.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbConsolidated_account.FormattingEnabled = True
        Me.cmbConsolidated_account.Location = New System.Drawing.Point(0, 144)
        Me.cmbConsolidated_account.Name = "cmbConsolidated_account"
        Me.cmbConsolidated_account.Size = New System.Drawing.Size(241, 24)
        Me.cmbConsolidated_account.TabIndex = 465
        '
        'cmbTypeOfChargesName
        '
        Me.cmbTypeOfChargesName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTypeOfChargesName.FormattingEnabled = True
        Me.cmbTypeOfChargesName.Location = New System.Drawing.Point(0, 313)
        Me.cmbTypeOfChargesName.Name = "cmbTypeOfChargesName"
        Me.cmbTypeOfChargesName.Size = New System.Drawing.Size(241, 24)
        Me.cmbTypeOfChargesName.TabIndex = 7
        '
        'LblTypeOfCharges
        '
        Me.LblTypeOfCharges.AutoSize = True
        Me.LblTypeOfCharges.BackColor = System.Drawing.Color.Transparent
        Me.LblTypeOfCharges.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTypeOfCharges.ForeColor = System.Drawing.Color.White
        Me.LblTypeOfCharges.Location = New System.Drawing.Point(0, 297)
        Me.LblTypeOfCharges.Name = "LblTypeOfCharges"
        Me.LblTypeOfCharges.Size = New System.Drawing.Size(101, 15)
        Me.LblTypeOfCharges.TabIndex = 464
        Me.LblTypeOfCharges.Text = "Type of Charges:"
        '
        'txtItemName
        '
        Me.txtItemName.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemName.Location = New System.Drawing.Point(0, 480)
        Me.txtItemName.Name = "txtItemName"
        Me.txtItemName.Size = New System.Drawing.Size(241, 24)
        Me.txtItemName.TabIndex = 11
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(0, 464)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(71, 15)
        Me.Label12.TabIndex = 463
        Me.Label12.Text = "Item Name:"
        '
        'txtConducted_by
        '
        Me.txtConducted_by.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConducted_by.ForeColor = System.Drawing.Color.Gray
        Me.txtConducted_by.Location = New System.Drawing.Point(1, 734)
        Me.txtConducted_by.Name = "txtConducted_by"
        Me.txtConducted_by.Size = New System.Drawing.Size(241, 24)
        Me.txtConducted_by.TabIndex = 17
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(0, 717)
        Me.Label11.Margin = New System.Windows.Forms.Padding(10, 0, 10, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(84, 15)
        Me.Label11.TabIndex = 461
        Me.Label11.Text = "Conducted by"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtws_cash_voice
        '
        Me.txtws_cash_voice.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtws_cash_voice.Location = New System.Drawing.Point(0, 228)
        Me.txtws_cash_voice.Name = "txtws_cash_voice"
        Me.txtws_cash_voice.Size = New System.Drawing.Size(241, 24)
        Me.txtws_cash_voice.TabIndex = 5
        '
        'ws_no_cash_voice
        '
        Me.ws_no_cash_voice.AutoSize = True
        Me.ws_no_cash_voice.BackColor = System.Drawing.Color.Transparent
        Me.ws_no_cash_voice.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ws_no_cash_voice.ForeColor = System.Drawing.Color.White
        Me.ws_no_cash_voice.Location = New System.Drawing.Point(0, 212)
        Me.ws_no_cash_voice.Name = "ws_no_cash_voice"
        Me.ws_no_cash_voice.Size = New System.Drawing.Size(136, 15)
        Me.ws_no_cash_voice.TabIndex = 459
        Me.ws_no_cash_voice.Text = "Ws # or Cash Voucher:"
        '
        'cmbtype_of_purchase
        '
        Me.cmbtype_of_purchase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbtype_of_purchase.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbtype_of_purchase.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbtype_of_purchase.FormattingEnabled = True
        Me.cmbtype_of_purchase.Items.AddRange(New Object() {"CASH", "WITHDRAWN"})
        Me.cmbtype_of_purchase.Location = New System.Drawing.Point(0, 186)
        Me.cmbtype_of_purchase.Name = "cmbtype_of_purchase"
        Me.cmbtype_of_purchase.Size = New System.Drawing.Size(241, 24)
        Me.cmbtype_of_purchase.TabIndex = 4
        '
        'type_of_purchasing
        '
        Me.type_of_purchasing.AutoSize = True
        Me.type_of_purchasing.BackColor = System.Drawing.Color.Transparent
        Me.type_of_purchasing.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.type_of_purchasing.ForeColor = System.Drawing.Color.White
        Me.type_of_purchasing.Location = New System.Drawing.Point(0, 169)
        Me.type_of_purchasing.Name = "type_of_purchasing"
        Me.type_of_purchasing.Size = New System.Drawing.Size(108, 15)
        Me.type_of_purchasing.TabIndex = 457
        Me.type_of_purchasing.Text = "Type of Purchase:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label19.Location = New System.Drawing.Point(4, 889)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(181, 15)
        Me.Label19.TabIndex = 456
        Me.Label19.Text = "Ctrl + S for shorcut Save/Update"
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.DarkGray
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnSave.Location = New System.Drawing.Point(1, 852)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(241, 35)
        Me.btnSave.TabIndex = 20
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'txtRequestBy
        '
        Me.txtRequestBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRequestBy.ForeColor = System.Drawing.Color.Gray
        Me.txtRequestBy.Location = New System.Drawing.Point(1, 824)
        Me.txtRequestBy.Name = "txtRequestBy"
        Me.txtRequestBy.Size = New System.Drawing.Size(241, 24)
        Me.txtRequestBy.TabIndex = 19
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(1, 806)
        Me.Label10.Margin = New System.Windows.Forms.Padding(10, 0, 10, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(87, 15)
        Me.Label10.TabIndex = 410
        Me.Label10.Text = "Requested by:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DTPTimeNeeded
        '
        Me.DTPTimeNeeded.CustomFormat = ""
        Me.DTPTimeNeeded.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPTimeNeeded.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPTimeNeeded.Location = New System.Drawing.Point(1, 778)
        Me.DTPTimeNeeded.Margin = New System.Windows.Forms.Padding(10, 3, 3, 3)
        Me.DTPTimeNeeded.Name = "DTPTimeNeeded"
        Me.DTPTimeNeeded.Size = New System.Drawing.Size(241, 24)
        Me.DTPTimeNeeded.TabIndex = 18
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(1, 761)
        Me.Label9.Margin = New System.Windows.Forms.Padding(10, 0, 10, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(82, 15)
        Me.Label9.TabIndex = 408
        Me.Label9.Text = "Date Needed:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPurpose
        '
        Me.txtPurpose.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPurpose.Location = New System.Drawing.Point(1, 690)
        Me.txtPurpose.Name = "txtPurpose"
        Me.txtPurpose.Size = New System.Drawing.Size(241, 24)
        Me.txtPurpose.TabIndex = 16
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(1, 672)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 15)
        Me.Label8.TabIndex = 406
        Me.Label8.Text = "Purpose:"
        '
        'txtAmount
        '
        Me.txtAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmount.Location = New System.Drawing.Point(0, 645)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(241, 24)
        Me.txtAmount.TabIndex = 15
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(0, 628)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 15)
        Me.Label3.TabIndex = 404
        Me.Label3.Text = "Amount:"
        '
        'txtUnit
        '
        Me.txtUnit.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUnit.Location = New System.Drawing.Point(0, 603)
        Me.txtUnit.Name = "txtUnit"
        Me.txtUnit.Size = New System.Drawing.Size(241, 24)
        Me.txtUnit.TabIndex = 14
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(0, 587)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(32, 15)
        Me.Label7.TabIndex = 402
        Me.Label7.Text = "Unit:"
        '
        'txtQty
        '
        Me.txtQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQty.Location = New System.Drawing.Point(0, 561)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.Size = New System.Drawing.Size(241, 24)
        Me.txtQty.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(0, 546)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 15)
        Me.Label6.TabIndex = 400
        Me.Label6.Text = "Quantity:"
        '
        'txtItemDesc
        '
        Me.txtItemDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemDesc.Location = New System.Drawing.Point(0, 521)
        Me.txtItemDesc.Name = "txtItemDesc"
        Me.txtItemDesc.Size = New System.Drawing.Size(241, 24)
        Me.txtItemDesc.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(0, 505)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(103, 15)
        Me.Label5.TabIndex = 398
        Me.Label5.Text = "Item Description:"
        '
        'txtJOno
        '
        Me.txtJOno.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtJOno.Location = New System.Drawing.Point(0, 437)
        Me.txtJOno.Name = "txtJOno"
        Me.txtJOno.Size = New System.Drawing.Size(241, 24)
        Me.txtJOno.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(0, 422)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 15)
        Me.Label2.TabIndex = 396
        Me.Label2.Text = "J.O No."
        '
        'txtLoc
        '
        Me.txtLoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLoc.Location = New System.Drawing.Point(0, 396)
        Me.txtLoc.Name = "txtLoc"
        Me.txtLoc.Size = New System.Drawing.Size(241, 24)
        Me.txtLoc.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(0, 381)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 15)
        Me.Label4.TabIndex = 394
        Me.Label4.Text = "Location:"
        '
        'cmbTOR_sub
        '
        Me.cmbTOR_sub.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTOR_sub.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbTOR_sub.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTOR_sub.FormattingEnabled = True
        Me.cmbTOR_sub.Items.AddRange(New Object() {"SUPPLY", "EQUIPMENT", "PROJECT", "OTHERS"})
        Me.cmbTOR_sub.Location = New System.Drawing.Point(0, 100)
        Me.cmbTOR_sub.Name = "cmbTOR_sub"
        Me.cmbTOR_sub.Size = New System.Drawing.Size(241, 24)
        Me.cmbTOR_sub.TabIndex = 3
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.White
        Me.Label23.Location = New System.Drawing.Point(0, 84)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(32, 15)
        Me.Label23.TabIndex = 392
        Me.Label23.Text = "Sub:"
        '
        'cmbTypeofCharge
        '
        Me.cmbTypeofCharge.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTypeofCharge.FormattingEnabled = True
        Me.cmbTypeofCharge.Items.AddRange(New Object() {"ADFIL", "OUTSOURCE"})
        Me.cmbTypeofCharge.Location = New System.Drawing.Point(0, 356)
        Me.cmbTypeofCharge.Name = "cmbTypeofCharge"
        Me.cmbTypeofCharge.Size = New System.Drawing.Size(241, 24)
        Me.cmbTypeofCharge.TabIndex = 8
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(0, 340)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(65, 15)
        Me.Label15.TabIndex = 390
        Me.Label15.Text = "Charge to:"
        '
        'txtRSno
        '
        Me.txtRSno.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRSno.Location = New System.Drawing.Point(0, 270)
        Me.txtRSno.Name = "txtRSno"
        Me.txtRSno.Size = New System.Drawing.Size(241, 24)
        Me.txtRSno.TabIndex = 6
        '
        'lblItemName
        '
        Me.lblItemName.AutoSize = True
        Me.lblItemName.BackColor = System.Drawing.Color.Transparent
        Me.lblItemName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItemName.ForeColor = System.Drawing.Color.White
        Me.lblItemName.Location = New System.Drawing.Point(0, 254)
        Me.lblItemName.Name = "lblItemName"
        Me.lblItemName.Size = New System.Drawing.Size(53, 15)
        Me.lblItemName.TabIndex = 360
        Me.lblItemName.Text = "R.S. No.:"
        '
        'cmbRequestType
        '
        Me.cmbRequestType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRequestType.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbRequestType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbRequestType.FormattingEnabled = True
        Me.cmbRequestType.Items.AddRange(New Object() {"SUPPLY", "EQUIPMENT", "PROJECT", "OTHERS"})
        Me.cmbRequestType.Location = New System.Drawing.Point(0, 59)
        Me.cmbRequestType.Name = "cmbRequestType"
        Me.cmbRequestType.Size = New System.Drawing.Size(241, 24)
        Me.cmbRequestType.TabIndex = 2
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(0, 42)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(100, 15)
        Me.Label14.TabIndex = 358
        Me.Label14.Text = "Type of Request:"
        '
        'DTPReq
        '
        Me.DTPReq.CustomFormat = ""
        Me.DTPReq.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPReq.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPReq.Location = New System.Drawing.Point(0, 15)
        Me.DTPReq.Margin = New System.Windows.Forms.Padding(10, 3, 3, 3)
        Me.DTPReq.Name = "DTPReq"
        Me.DTPReq.Size = New System.Drawing.Size(241, 26)
        Me.DTPReq.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 15)
        Me.Label1.TabIndex = 356
        Me.Label1.Text = "Date Request:"
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.TableLayoutPanel4)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(3, 978)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1297, 49)
        Me.Panel5.TabIndex = 2
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 2
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.GroupBox1, 1, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(1297, 49)
        Me.TableLayoutPanel4.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblSearchByCategory)
        Me.GroupBox1.Controls.Add(Me.btnSearch)
        Me.GroupBox1.Controls.Add(Me.cmbSearch)
        Me.GroupBox1.Controls.Add(Me.txtSearch)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(253, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1041, 43)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'lblSearchByCategory
        '
        Me.lblSearchByCategory.AutoSize = True
        Me.lblSearchByCategory.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSearchByCategory.ForeColor = System.Drawing.Color.White
        Me.lblSearchByCategory.Location = New System.Drawing.Point(3, 15)
        Me.lblSearchByCategory.Name = "lblSearchByCategory"
        Me.lblSearchByCategory.Size = New System.Drawing.Size(68, 15)
        Me.lblSearchByCategory.TabIndex = 361
        Me.lblSearchByCategory.Text = "Search By:"
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.DarkGray
        Me.btnSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnSearch.Location = New System.Drawing.Point(500, 9)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(131, 27)
        Me.btnSearch.TabIndex = 22
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'cmbSearch
        '
        Me.cmbSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSearch.FormattingEnabled = True
        Me.cmbSearch.Items.AddRange(New Object() {"Date Request", "Type of Request", "Type of Purchase", "Ws or Cv", "Rs no.", "Type of Charges", "Charge to", "Location", "Jo no.", "Item Name", "Item Description", "Date"})
        Me.cmbSearch.Location = New System.Drawing.Point(76, 9)
        Me.cmbSearch.Name = "cmbSearch"
        Me.cmbSearch.Size = New System.Drawing.Size(151, 26)
        Me.cmbSearch.TabIndex = 20
        '
        'txtSearch
        '
        Me.txtSearch.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(233, 9)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(264, 26)
        Me.txtSearch.TabIndex = 21
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.ToolStrip_Cancel, Me.ExportToExcelToolStripMenuItem, Me.TotalLitersToolStripMenuItem, Me.CvExportToExcelToolStripMenuItem, Me.TotalAmountToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(178, 158)
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Enabled = False
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.DeleteToolStripMenuItem.Text = "delete"
        '
        'ToolStrip_Cancel
        '
        Me.ToolStrip_Cancel.Name = "ToolStrip_Cancel"
        Me.ToolStrip_Cancel.Size = New System.Drawing.Size(177, 22)
        Me.ToolStrip_Cancel.Text = "Cancel"
        '
        'ExportToExcelToolStripMenuItem
        '
        Me.ExportToExcelToolStripMenuItem.Enabled = False
        Me.ExportToExcelToolStripMenuItem.Name = "ExportToExcelToolStripMenuItem"
        Me.ExportToExcelToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.ExportToExcelToolStripMenuItem.Text = "export to excel"
        '
        'TotalLitersToolStripMenuItem
        '
        Me.TotalLitersToolStripMenuItem.Enabled = False
        Me.TotalLitersToolStripMenuItem.Name = "TotalLitersToolStripMenuItem"
        Me.TotalLitersToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.TotalLitersToolStripMenuItem.Text = "total liters"
        '
        'CvExportToExcelToolStripMenuItem
        '
        Me.CvExportToExcelToolStripMenuItem.Name = "CvExportToExcelToolStripMenuItem"
        Me.CvExportToExcelToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.CvExportToExcelToolStripMenuItem.Text = "cv # export to excel"
        '
        'TotalAmountToolStripMenuItem
        '
        Me.TotalAmountToolStripMenuItem.Name = "TotalAmountToolStripMenuItem"
        Me.TotalAmountToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.TotalAmountToolStripMenuItem.Text = "Total Amount"
        '
        'SaveFileDialog1
        '
        '
        'FLiquidationReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SUPPLY.My.Resources.Resources.bg_line
        Me.ClientSize = New System.Drawing.Size(1303, 1030)
        Me.ContextMenuStrip = Me.ContextMenuStrip1
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.KeyPreview = True
        Me.Name = "FLiquidationReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "FLiquidationReport"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel_Cancelled_Remarks.ResumeLayout(False)
        Me.Panel_Cancelled_Remarks.PerformLayout()
        Me.Panel_date_duration.ResumeLayout(False)
        Me.Panel_date_duration.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents lvlLiquidationReport As ListView
    Friend WithEvents Id As ColumnHeader
    Friend WithEvents DateRequest As ColumnHeader
    Friend WithEvents TypeOfRequest As ColumnHeader
    Friend WithEvents Consolidated_title As ColumnHeader
    Friend WithEvents Type_of_Purchase As ColumnHeader
    Friend WithEvents Ws_or_Cash_Invoice As ColumnHeader
    Friend WithEvents Rs_no As ColumnHeader
    Friend WithEvents Type_of_Charges As ColumnHeader
    Friend WithEvents Panel1 As Panel
    Friend WithEvents LlbTitleAllowanceSummary As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents btnExit As Button
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents Charge_to As ColumnHeader
    Friend WithEvents location As ColumnHeader
    Friend WithEvents jo_no As ColumnHeader
    Friend WithEvents Item_name As ColumnHeader
    Friend WithEvents Item_desc As ColumnHeader
    Friend WithEvents txtTypeofCharge As TextBox
    Friend WithEvents Quantity As ColumnHeader
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblSearchByCategory As Label
    Friend WithEvents btnSearch As Button
    Friend WithEvents cmbSearch As ComboBox
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents DTP_search_liquidation As DateTimePicker
    Friend WithEvents Panel_date_duration As Panel
    Friend WithEvents btnExit_panel_duration As Button
    Friend WithEvents lblTo_date As Label
    Friend WithEvents btnSearchDuration As Button
    Friend WithEvents DTP_to As DateTimePicker
    Friend WithEvents lblFrom_date As Label
    Friend WithEvents DtpickerFrom As DateTimePicker
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents DTPReq As DateTimePicker
    Friend WithEvents Label14 As Label
    Friend WithEvents cmbRequestType As ComboBox
    Friend WithEvents lblItemName As Label
    Friend WithEvents txtRSno As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents cmbTypeofCharge As ComboBox
    Friend WithEvents Label23 As Label
    Friend WithEvents cmbTOR_sub As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtLoc As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtJOno As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtItemDesc As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtQty As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtUnit As TextBox
    Friend WithEvents txtAmount As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Unit As ColumnHeader
    Friend WithEvents txtws_cash_voice As TextBox
    Friend WithEvents ws_no_cash_voice As Label
    Friend WithEvents cmbtype_of_purchase As ComboBox
    Friend WithEvents type_of_purchasing As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Amount As ColumnHeader
    Friend WithEvents ExportToExcelToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents TotalLitersToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CvExportToExcelToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Panel5 As Panel
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents Purpose As ColumnHeader
    Friend WithEvents Conducted_by As ColumnHeader
    Friend WithEvents Date_needed As ColumnHeader
    Friend WithEvents cmbTypeOfChargesName As ComboBox
    Friend WithEvents LblTypeOfCharges As Label
    Friend WithEvents txtItemName As TextBox
    Friend WithEvents txtConducted_by As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents txtRequestBy As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents DTPTimeNeeded As DateTimePicker
    Friend WithEvents Label9 As Label
    Friend WithEvents txtPurpose As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Requested_by As ColumnHeader
    Friend WithEvents User_Login_Save As ColumnHeader
    Friend WithEvents Date_Login As ColumnHeader
    Friend WithEvents update_login As ColumnHeader
    Friend WithEvents TotalAmountToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents update_date As ColumnHeader
    Friend WithEvents ToolStrip_Cancel As ToolStripMenuItem
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Label13 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Panel_Cancelled_Remarks As Panel
    Friend WithEvents txtCancelledRemarks As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents btnSaveCancelled As Button
    Friend WithEvents lbleRemarks As Label
    Friend WithEvents status_cancel As ColumnHeader
    Friend WithEvents lblConsolidated_account As Label
    Friend WithEvents cmbConsolidated_account As ComboBox
    Friend WithEvents cancelled_remarks As ColumnHeader
    Friend WithEvents tors_ca_id As ColumnHeader
End Class
