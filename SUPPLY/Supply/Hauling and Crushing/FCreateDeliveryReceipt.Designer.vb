<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FCreateDeliveryReceipt
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FCreateDeliveryReceipt))
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CreateWithdrawalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RecepientToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyThisRecepientToAllRowsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyFor5RowsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HideLeftPanelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HideToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AutofillToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.debounce_new = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.loadingPanel = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnFinalSave = New System.Windows.Forms.Button()
        Me.Panel19 = New System.Windows.Forms.Panel()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.Panel18 = New System.Windows.Forms.Panel()
        Me.lblRequestor = New System.Windows.Forms.Label()
        Me.lblQty = New System.Windows.Forms.Label()
        Me.Panel17 = New System.Windows.Forms.Panel()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.Panel20 = New System.Windows.Forms.Panel()
        Me.lblStockpile = New System.Windows.Forms.Label()
        Me.lblQuarry = New System.Windows.Forms.Label()
        Me.lblItems = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.txtSearchItems = New System.Windows.Forms.TextBox()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.lblTransaction = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.lblToBeDelivered = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel15 = New System.Windows.Forms.Panel()
        Me.lblWithdrawn = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel16 = New System.Windows.Forms.Panel()
        Me.lblDelivered = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtReceivedBy = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.picStoS = New System.Windows.Forms.PictureBox()
        Me.txtPrice = New System.Windows.Forms.TextBox()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.txtCheckedBy = New System.Windows.Forms.TextBox()
        Me.txtConsession = New System.Windows.Forms.TextBox()
        Me.cmbDrOptions = New System.Windows.Forms.ComboBox()
        Me.txtDrQty = New System.Windows.Forms.TextBox()
        Me.btnReleaseNow = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDrNo = New System.Windows.Forms.TextBox()
        Me.dtpDateSubmitted = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDriver = New System.Windows.Forms.TextBox()
        Me.txtPlateNo = New System.Windows.Forms.TextBox()
        Me.dtpDrDate = New System.Windows.Forms.DateTimePicker()
        Me.txtSupplier = New System.Windows.Forms.TextBox()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel10.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.loadingPanel.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel19.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel18.SuspendLayout()
        Me.Panel17.SuspendLayout()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel20.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.Panel11.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        Me.Panel13.SuspendLayout()
        Me.Panel14.SuspendLayout()
        Me.Panel15.SuspendLayout()
        Me.Panel16.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel8.SuspendLayout()
        CType(Me.picStoS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CreateWithdrawalToolStripMenuItem, Me.RemoveToolStripMenuItem, Me.EditToolStripMenuItem, Me.RecepientToolStripMenuItem, Me.CopyThisRecepientToAllRowsToolStripMenuItem, Me.CopyToolStripMenuItem, Me.HideLeftPanelToolStripMenuItem, Me.AutofillToolStripMenuItem, Me.RefreshToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(234, 202)
        '
        'CreateWithdrawalToolStripMenuItem
        '
        Me.CreateWithdrawalToolStripMenuItem.Name = "CreateWithdrawalToolStripMenuItem"
        Me.CreateWithdrawalToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.CreateWithdrawalToolStripMenuItem.Text = "Create Withdrawal"
        '
        'RemoveToolStripMenuItem
        '
        Me.RemoveToolStripMenuItem.Name = "RemoveToolStripMenuItem"
        Me.RemoveToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.RemoveToolStripMenuItem.Text = "Remove"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'RecepientToolStripMenuItem
        '
        Me.RecepientToolStripMenuItem.Name = "RecepientToolStripMenuItem"
        Me.RecepientToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.RecepientToolStripMenuItem.Text = "Recepient"
        '
        'CopyThisRecepientToAllRowsToolStripMenuItem
        '
        Me.CopyThisRecepientToAllRowsToolStripMenuItem.Name = "CopyThisRecepientToAllRowsToolStripMenuItem"
        Me.CopyThisRecepientToAllRowsToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.CopyThisRecepientToAllRowsToolStripMenuItem.Text = "Copy this recepient to all rows"
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyFor5RowsToolStripMenuItem})
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.CopyToolStripMenuItem.Text = "Copy"
        '
        'CopyFor5RowsToolStripMenuItem
        '
        Me.CopyFor5RowsToolStripMenuItem.Name = "CopyFor5RowsToolStripMenuItem"
        Me.CopyFor5RowsToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.CopyFor5RowsToolStripMenuItem.Text = "Copy for 5 rows"
        '
        'HideLeftPanelToolStripMenuItem
        '
        Me.HideLeftPanelToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShowToolStripMenuItem, Me.HideToolStripMenuItem})
        Me.HideLeftPanelToolStripMenuItem.Name = "HideLeftPanelToolStripMenuItem"
        Me.HideLeftPanelToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.HideLeftPanelToolStripMenuItem.Text = "Left Panel"
        '
        'ShowToolStripMenuItem
        '
        Me.ShowToolStripMenuItem.Name = "ShowToolStripMenuItem"
        Me.ShowToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.ShowToolStripMenuItem.Text = "Show"
        '
        'HideToolStripMenuItem
        '
        Me.HideToolStripMenuItem.Name = "HideToolStripMenuItem"
        Me.HideToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.HideToolStripMenuItem.Text = "Hide"
        '
        'AutofillToolStripMenuItem
        '
        Me.AutofillToolStripMenuItem.Name = "AutofillToolStripMenuItem"
        Me.AutofillToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.AutofillToolStripMenuItem.Text = "autofill"
        '
        'RefreshToolStripMenuItem
        '
        Me.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem"
        Me.RefreshToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.RefreshToolStripMenuItem.Text = "Refresh"
        '
        'debounce_new
        '
        Me.debounce_new.Interval = 500
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = Global.SUPPLY.My.Resources.Resources.bg_line
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Panel10)
        Me.Panel1.Controls.Add(Me.loadingPanel)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1555, 44)
        Me.Panel1.TabIndex = 15
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(352, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(45, 30)
        Me.Button1.TabIndex = 437
        Me.Button1.Text = "Fill"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'Panel10
        '
        Me.Panel10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel10.BackColor = System.Drawing.Color.Transparent
        Me.Panel10.Controls.Add(Me.btnClose)
        Me.Panel10.Controls.Add(Me.PictureBox1)
        Me.Panel10.Controls.Add(Me.Label4)
        Me.Panel10.Location = New System.Drawing.Point(980, 1)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(561, 39)
        Me.Panel10.TabIndex = 425
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
        Me.btnClose.Location = New System.Drawing.Point(524, 7)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(3, 3, 10, 3)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(22, 22)
        Me.btnClose.TabIndex = 432
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.PictureBox1.Image = Global.SUPPLY.My.Resources.Resources.equipment_monitoring
        Me.PictureBox1.Location = New System.Drawing.Point(5, -1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(39, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 424
        Me.PictureBox1.TabStop = False
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Bombardier", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.SpringGreen
        Me.Label4.Location = New System.Drawing.Point(46, 5)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(282, 30)
        Me.Label4.TabIndex = 422
        Me.Label4.Text = "CREATE DELIVERY RECEIPT"
        '
        'loadingPanel
        '
        Me.loadingPanel.BackColor = System.Drawing.Color.Transparent
        Me.loadingPanel.Controls.Add(Me.Label3)
        Me.loadingPanel.Controls.Add(Me.PictureBox2)
        Me.loadingPanel.Location = New System.Drawing.Point(12, 2)
        Me.loadingPanel.Name = "loadingPanel"
        Me.loadingPanel.Size = New System.Drawing.Size(301, 35)
        Me.loadingPanel.TabIndex = 421
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(43, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(204, 19)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Fetching data, please wait..."
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.SUPPLY.My.Resources.Resources.spinner
        Me.PictureBox2.Location = New System.Drawing.Point(4, 1)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(33, 33)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 0
        Me.PictureBox2.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.BackgroundImage = Global.SUPPLY.My.Resources.Resources.eus_bg_03
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.btnFinalSave)
        Me.Panel2.Controls.Add(Me.Panel19)
        Me.Panel2.Controls.Add(Me.Panel18)
        Me.Panel2.Controls.Add(Me.Panel17)
        Me.Panel2.Controls.Add(Me.Panel20)
        Me.Panel2.Controls.Add(Me.lblItems)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 937)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1555, 63)
        Me.Panel2.TabIndex = 16
        '
        'btnFinalSave
        '
        Me.btnFinalSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFinalSave.BackColor = System.Drawing.Color.YellowGreen
        Me.btnFinalSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFinalSave.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFinalSave.Image = CType(resources.GetObject("btnFinalSave.Image"), System.Drawing.Image)
        Me.btnFinalSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFinalSave.Location = New System.Drawing.Point(1295, 10)
        Me.btnFinalSave.Name = "btnFinalSave"
        Me.btnFinalSave.Size = New System.Drawing.Size(246, 40)
        Me.btnFinalSave.TabIndex = 459
        Me.btnFinalSave.Text = "Save (Ctrl + S)"
        Me.btnFinalSave.UseVisualStyleBackColor = False
        '
        'Panel19
        '
        Me.Panel19.BackColor = System.Drawing.Color.Transparent
        Me.Panel19.Controls.Add(Me.PictureBox5)
        Me.Panel19.Location = New System.Drawing.Point(659, 3)
        Me.Panel19.Name = "Panel19"
        Me.Panel19.Size = New System.Drawing.Size(70, 56)
        Me.Panel19.TabIndex = 458
        '
        'PictureBox5
        '
        Me.PictureBox5.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.PictureBox5.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(6, 5)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(57, 45)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox5.TabIndex = 448
        Me.PictureBox5.TabStop = False
        '
        'Panel18
        '
        Me.Panel18.BackColor = System.Drawing.Color.Transparent
        Me.Panel18.Controls.Add(Me.lblRequestor)
        Me.Panel18.Controls.Add(Me.lblQty)
        Me.Panel18.Location = New System.Drawing.Point(734, 6)
        Me.Panel18.Name = "Panel18"
        Me.Panel18.Size = New System.Drawing.Size(544, 50)
        Me.Panel18.TabIndex = 457
        '
        'lblRequestor
        '
        Me.lblRequestor.AutoSize = True
        Me.lblRequestor.BackColor = System.Drawing.Color.Transparent
        Me.lblRequestor.Font = New System.Drawing.Font("Bombardier", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRequestor.ForeColor = System.Drawing.Color.Lime
        Me.lblRequestor.Location = New System.Drawing.Point(3, 25)
        Me.lblRequestor.Name = "lblRequestor"
        Me.lblRequestor.Size = New System.Drawing.Size(76, 18)
        Me.lblRequestor.TabIndex = 450
        Me.lblRequestor.Text = "loading..."
        '
        'lblQty
        '
        Me.lblQty.AutoSize = True
        Me.lblQty.BackColor = System.Drawing.Color.Transparent
        Me.lblQty.Font = New System.Drawing.Font("Bombardier", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQty.ForeColor = System.Drawing.Color.Yellow
        Me.lblQty.Location = New System.Drawing.Point(3, 4)
        Me.lblQty.Name = "lblQty"
        Me.lblQty.Size = New System.Drawing.Size(65, 18)
        Me.lblQty.TabIndex = 449
        Me.lblQty.Text = "waiting..."
        '
        'Panel17
        '
        Me.Panel17.BackColor = System.Drawing.Color.Transparent
        Me.Panel17.Controls.Add(Me.PictureBox7)
        Me.Panel17.Controls.Add(Me.PictureBox6)
        Me.Panel17.Location = New System.Drawing.Point(293, 4)
        Me.Panel17.Name = "Panel17"
        Me.Panel17.Size = New System.Drawing.Size(167, 56)
        Me.Panel17.TabIndex = 456
        '
        'PictureBox7
        '
        Me.PictureBox7.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.PictureBox7.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox7.Image = CType(resources.GetObject("PictureBox7.Image"), System.Drawing.Image)
        Me.PictureBox7.Location = New System.Drawing.Point(6, 5)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(57, 45)
        Me.PictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox7.TabIndex = 448
        Me.PictureBox7.TabStop = False
        '
        'PictureBox6
        '
        Me.PictureBox6.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.PictureBox6.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(67, 14)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(94, 35)
        Me.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox6.TabIndex = 444
        Me.PictureBox6.TabStop = False
        '
        'Panel20
        '
        Me.Panel20.BackColor = System.Drawing.Color.Transparent
        Me.Panel20.Controls.Add(Me.lblStockpile)
        Me.Panel20.Controls.Add(Me.lblQuarry)
        Me.Panel20.Location = New System.Drawing.Point(15, 2)
        Me.Panel20.Name = "Panel20"
        Me.Panel20.Size = New System.Drawing.Size(275, 57)
        Me.Panel20.TabIndex = 455
        '
        'lblStockpile
        '
        Me.lblStockpile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblStockpile.BackColor = System.Drawing.Color.Transparent
        Me.lblStockpile.Font = New System.Drawing.Font("Bombardier", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStockpile.ForeColor = System.Drawing.Color.Lime
        Me.lblStockpile.Location = New System.Drawing.Point(13, 31)
        Me.lblStockpile.Name = "lblStockpile"
        Me.lblStockpile.Size = New System.Drawing.Size(259, 16)
        Me.lblStockpile.TabIndex = 450
        Me.lblStockpile.Text = "STOCKPILE: loading..."
        Me.lblStockpile.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblQuarry
        '
        Me.lblQuarry.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblQuarry.BackColor = System.Drawing.Color.Transparent
        Me.lblQuarry.Font = New System.Drawing.Font("Bombardier", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQuarry.ForeColor = System.Drawing.Color.Yellow
        Me.lblQuarry.Location = New System.Drawing.Point(13, 10)
        Me.lblQuarry.Name = "lblQuarry"
        Me.lblQuarry.Size = New System.Drawing.Size(258, 16)
        Me.lblQuarry.TabIndex = 449
        Me.lblQuarry.Text = "QUARRY: loading..."
        Me.lblQuarry.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblItems
        '
        Me.lblItems.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblItems.AutoSize = True
        Me.lblItems.BackColor = System.Drawing.Color.Transparent
        Me.lblItems.Font = New System.Drawing.Font("Bombardier", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItems.ForeColor = System.Drawing.Color.YellowGreen
        Me.lblItems.Location = New System.Drawing.Point(464, 27)
        Me.lblItems.Name = "lblItems"
        Me.lblItems.Size = New System.Drawing.Size(70, 16)
        Me.lblItems.TabIndex = 454
        Me.lblItems.Text = "loading..."
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Panel5)
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 44)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1555, 893)
        Me.Panel3.TabIndex = 17
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Panel7)
        Me.Panel5.Controls.Add(Me.Panel6)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(301, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1254, 893)
        Me.Panel5.TabIndex = 1
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.Panel12)
        Me.Panel7.Controls.Add(Me.Panel11)
        Me.Panel7.Controls.Add(Me.DataGridView1)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel7.Location = New System.Drawing.Point(0, 43)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(1254, 850)
        Me.Panel7.TabIndex = 1
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.SystemColors.Control
        Me.Panel12.BackgroundImage = Global.SUPPLY.My.Resources.Resources.bg_line
        Me.Panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel12.Controls.Add(Me.Label5)
        Me.Panel12.Controls.Add(Me.Button4)
        Me.Panel12.Controls.Add(Me.Button5)
        Me.Panel12.Location = New System.Drawing.Point(849, 65)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(344, 354)
        Me.Panel12.TabIndex = 424
        Me.Panel12.Visible = False
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.GreenYellow
        Me.Label5.Location = New System.Drawing.Point(248, 328)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 16)
        Me.Label5.TabIndex = 428
        Me.Label5.Text = "Close (Ctrl + X)"
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button4.Location = New System.Drawing.Point(37, 261)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(278, 41)
        Me.Button4.TabIndex = 20
        Me.Button4.Text = "Save"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button5.BackColor = System.Drawing.Color.Transparent
        Me.Button5.BackgroundImage = Global.SUPPLY.My.Resources.Resources.close_button
        Me.Button5.FlatAppearance.BorderSize = 0
        Me.Button5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Location = New System.Drawing.Point(311, 7)
        Me.Button5.Margin = New System.Windows.Forms.Padding(3, 3, 10, 3)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(22, 22)
        Me.Button5.TabIndex = 413
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Panel11.BackgroundImage = Global.SUPPLY.My.Resources.Resources.eus_bg_03
        Me.Panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel11.Controls.Add(Me.Label22)
        Me.Panel11.Controls.Add(Me.Label20)
        Me.Panel11.Controls.Add(Me.PictureBox3)
        Me.Panel11.Controls.Add(Me.Button3)
        Me.Panel11.Controls.Add(Me.txtSearchItems)
        Me.Panel11.Controls.Add(Me.DataGridView2)
        Me.Panel11.Location = New System.Drawing.Point(42, 54)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(766, 458)
        Me.Panel11.TabIndex = 425
        Me.Panel11.Visible = False
        '
        'Label22
        '
        Me.Label22.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.GreenYellow
        Me.Label22.Location = New System.Drawing.Point(14, 5)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(320, 16)
        Me.Label22.TabIndex = 438
        Me.Label22.Text = "* Please select the stockpile area you want to transfer"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Bombardier", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.GreenYellow
        Me.Label20.Location = New System.Drawing.Point(65, 44)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(59, 18)
        Me.Label20.TabIndex = 416
        Me.Label20.Text = "SEARCH:"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.Image = Global.SUPPLY.My.Resources.Resources.spinner
        Me.PictureBox3.Location = New System.Drawing.Point(556, 39)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(33, 33)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 415
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.BackColor = System.Drawing.Color.Transparent
        Me.Button3.BackgroundImage = Global.SUPPLY.My.Resources.Resources.close_button
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Location = New System.Drawing.Point(725, 15)
        Me.Button3.Margin = New System.Windows.Forms.Padding(3, 3, 10, 3)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(22, 22)
        Me.Button3.TabIndex = 414
        Me.Button3.UseVisualStyleBackColor = False
        '
        'txtSearchItems
        '
        Me.txtSearchItems.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearchItems.Location = New System.Drawing.Point(177, 43)
        Me.txtSearchItems.Name = "txtSearchItems"
        Me.txtSearchItems.Size = New System.Drawing.Size(369, 26)
        Me.txtSearchItems.TabIndex = 16
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(9, 85)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.Size = New System.Drawing.Size(746, 354)
        Me.DataGridView2.TabIndex = 0
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(1254, 850)
        Me.DataGridView1.TabIndex = 16
        '
        'Panel6
        '
        Me.Panel6.BackgroundImage = Global.SUPPLY.My.Resources.Resources.eus_bg_03
        Me.Panel6.Controls.Add(Me.Panel13)
        Me.Panel6.Controls.Add(Me.Panel14)
        Me.Panel6.Controls.Add(Me.Panel15)
        Me.Panel6.Controls.Add(Me.Panel16)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1254, 43)
        Me.Panel6.TabIndex = 0
        '
        'Panel13
        '
        Me.Panel13.BackColor = System.Drawing.Color.Transparent
        Me.Panel13.Controls.Add(Me.lblTransaction)
        Me.Panel13.Controls.Add(Me.Label7)
        Me.Panel13.Location = New System.Drawing.Point(15, 6)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(385, 31)
        Me.Panel13.TabIndex = 448
        '
        'lblTransaction
        '
        Me.lblTransaction.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblTransaction.AutoSize = True
        Me.lblTransaction.BackColor = System.Drawing.Color.Transparent
        Me.lblTransaction.Font = New System.Drawing.Font("Bombardier", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTransaction.ForeColor = System.Drawing.Color.Gold
        Me.lblTransaction.Location = New System.Drawing.Point(92, 4)
        Me.lblTransaction.Name = "lblTransaction"
        Me.lblTransaction.Size = New System.Drawing.Size(78, 21)
        Me.lblTransaction.TabIndex = 438
        Me.lblTransaction.Text = "loading..."
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.GreenYellow
        Me.Label7.Location = New System.Drawing.Point(11, 6)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(78, 16)
        Me.Label7.TabIndex = 437
        Me.Label7.Text = "Transaction:"
        '
        'Panel14
        '
        Me.Panel14.BackColor = System.Drawing.Color.Transparent
        Me.Panel14.Controls.Add(Me.lblToBeDelivered)
        Me.Panel14.Controls.Add(Me.Label9)
        Me.Panel14.Location = New System.Drawing.Point(609, 7)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(244, 30)
        Me.Panel14.TabIndex = 447
        '
        'lblToBeDelivered
        '
        Me.lblToBeDelivered.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblToBeDelivered.AutoSize = True
        Me.lblToBeDelivered.BackColor = System.Drawing.Color.Transparent
        Me.lblToBeDelivered.Font = New System.Drawing.Font("Bombardier", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblToBeDelivered.ForeColor = System.Drawing.Color.Gold
        Me.lblToBeDelivered.Location = New System.Drawing.Point(109, 2)
        Me.lblToBeDelivered.Name = "lblToBeDelivered"
        Me.lblToBeDelivered.Size = New System.Drawing.Size(84, 24)
        Me.lblToBeDelivered.TabIndex = 446
        Me.lblToBeDelivered.Text = "waiting..."
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.GreenYellow
        Me.Label9.Location = New System.Drawing.Point(10, 7)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(96, 16)
        Me.Label9.TabIndex = 445
        Me.Label9.Text = "to be delivered:"
        '
        'Panel15
        '
        Me.Panel15.BackColor = System.Drawing.Color.Transparent
        Me.Panel15.Controls.Add(Me.lblWithdrawn)
        Me.Panel15.Controls.Add(Me.Label11)
        Me.Panel15.Location = New System.Drawing.Point(401, 6)
        Me.Panel15.Name = "Panel15"
        Me.Panel15.Size = New System.Drawing.Size(202, 32)
        Me.Panel15.TabIndex = 443
        '
        'lblWithdrawn
        '
        Me.lblWithdrawn.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblWithdrawn.AutoSize = True
        Me.lblWithdrawn.BackColor = System.Drawing.Color.Transparent
        Me.lblWithdrawn.Font = New System.Drawing.Font("Bombardier", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWithdrawn.ForeColor = System.Drawing.Color.Gold
        Me.lblWithdrawn.Location = New System.Drawing.Point(76, 2)
        Me.lblWithdrawn.Name = "lblWithdrawn"
        Me.lblWithdrawn.Size = New System.Drawing.Size(85, 24)
        Me.lblWithdrawn.TabIndex = 440
        Me.lblWithdrawn.Text = "loading..."
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.GreenYellow
        Me.Label11.Location = New System.Drawing.Point(5, 7)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(65, 16)
        Me.Label11.TabIndex = 439
        Me.Label11.Text = "Released:"
        '
        'Panel16
        '
        Me.Panel16.BackColor = System.Drawing.Color.Transparent
        Me.Panel16.Controls.Add(Me.lblDelivered)
        Me.Panel16.Controls.Add(Me.Label13)
        Me.Panel16.Location = New System.Drawing.Point(871, 7)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Size = New System.Drawing.Size(312, 30)
        Me.Panel16.TabIndex = 449
        '
        'lblDelivered
        '
        Me.lblDelivered.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblDelivered.AutoSize = True
        Me.lblDelivered.BackColor = System.Drawing.Color.Transparent
        Me.lblDelivered.Font = New System.Drawing.Font("Bombardier", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDelivered.ForeColor = System.Drawing.Color.Gold
        Me.lblDelivered.Location = New System.Drawing.Point(91, 1)
        Me.lblDelivered.Name = "lblDelivered"
        Me.lblDelivered.Size = New System.Drawing.Size(85, 24)
        Me.lblDelivered.TabIndex = 446
        Me.lblDelivered.Text = "loading..."
        '
        'Label13
        '
        Me.Label13.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.GreenYellow
        Me.Label13.Location = New System.Drawing.Point(23, 6)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(62, 16)
        Me.Label13.TabIndex = 445
        Me.Label13.Text = "delivered:"
        '
        'Panel4
        '
        Me.Panel4.BackgroundImage = Global.SUPPLY.My.Resources.Resources.bg_line
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.Panel8)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(301, 893)
        Me.Panel4.TabIndex = 0
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.Transparent
        Me.Panel8.Controls.Add(Me.Label21)
        Me.Panel8.Controls.Add(Me.txtReceivedBy)
        Me.Panel8.Controls.Add(Me.Label19)
        Me.Panel8.Controls.Add(Me.Label18)
        Me.Panel8.Controls.Add(Me.Label17)
        Me.Panel8.Controls.Add(Me.Label16)
        Me.Panel8.Controls.Add(Me.Label15)
        Me.Panel8.Controls.Add(Me.Label14)
        Me.Panel8.Controls.Add(Me.Label12)
        Me.Panel8.Controls.Add(Me.Label10)
        Me.Panel8.Controls.Add(Me.Label8)
        Me.Panel8.Controls.Add(Me.Label6)
        Me.Panel8.Controls.Add(Me.CheckBox1)
        Me.Panel8.Controls.Add(Me.picStoS)
        Me.Panel8.Controls.Add(Me.txtPrice)
        Me.Panel8.Controls.Add(Me.txtRemarks)
        Me.Panel8.Controls.Add(Me.txtCheckedBy)
        Me.Panel8.Controls.Add(Me.txtConsession)
        Me.Panel8.Controls.Add(Me.cmbDrOptions)
        Me.Panel8.Controls.Add(Me.txtDrQty)
        Me.Panel8.Controls.Add(Me.btnReleaseNow)
        Me.Panel8.Controls.Add(Me.Label1)
        Me.Panel8.Controls.Add(Me.txtDrNo)
        Me.Panel8.Controls.Add(Me.dtpDateSubmitted)
        Me.Panel8.Controls.Add(Me.Label2)
        Me.Panel8.Controls.Add(Me.txtDriver)
        Me.Panel8.Controls.Add(Me.txtPlateNo)
        Me.Panel8.Controls.Add(Me.dtpDrDate)
        Me.Panel8.Controls.Add(Me.txtSupplier)
        Me.Panel8.Location = New System.Drawing.Point(12, 5)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(279, 851)
        Me.Panel8.TabIndex = 10
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Bombardier", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.GreenYellow
        Me.Label21.Location = New System.Drawing.Point(12, 451)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(70, 15)
        Me.Label21.TabIndex = 448
        Me.Label21.Text = "RECEIVED BY:"
        '
        'txtReceivedBy
        '
        Me.txtReceivedBy.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReceivedBy.Location = New System.Drawing.Point(49, 476)
        Me.txtReceivedBy.Name = "txtReceivedBy"
        Me.txtReceivedBy.Size = New System.Drawing.Size(217, 26)
        Me.txtReceivedBy.TabIndex = 9
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Bombardier", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.GreenYellow
        Me.Label19.Location = New System.Drawing.Point(3, 683)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(70, 15)
        Me.Label19.TabIndex = 446
        Me.Label19.Text = "DR QUANTITY:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Bombardier", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.GreenYellow
        Me.Label18.Location = New System.Drawing.Point(12, 625)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(37, 15)
        Me.Label18.TabIndex = 445
        Me.Label18.Text = "DR NO:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Bombardier", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.GreenYellow
        Me.Label17.Location = New System.Drawing.Point(13, 567)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(37, 15)
        Me.Label17.TabIndex = 444
        Me.Label17.Text = "PRICE:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Bombardier", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.GreenYellow
        Me.Label16.Location = New System.Drawing.Point(12, 509)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(54, 15)
        Me.Label16.TabIndex = 443
        Me.Label16.Text = "REMARKS:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Bombardier", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.GreenYellow
        Me.Label15.Location = New System.Drawing.Point(12, 393)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(68, 15)
        Me.Label15.TabIndex = 442
        Me.Label15.Text = "CHECKED BY:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Bombardier", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.GreenYellow
        Me.Label14.Location = New System.Drawing.Point(12, 335)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(119, 15)
        Me.Label14.TabIndex = 441
        Me.Label14.Text = "CONCESSION TICKET NO:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Bombardier", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.GreenYellow
        Me.Label12.Location = New System.Drawing.Point(12, 277)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(55, 15)
        Me.Label12.TabIndex = 440
        Me.Label12.Text = "SUPPLIER:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Bombardier", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.GreenYellow
        Me.Label10.Location = New System.Drawing.Point(9, 115)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(95, 15)
        Me.Label10.TabIndex = 439
        Me.Label10.Text = "DRIVER/OPERATOR:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Bombardier", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.GreenYellow
        Me.Label8.Location = New System.Drawing.Point(9, 57)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(55, 15)
        Me.Label8.TabIndex = 438
        Me.Label8.Text = "PLATE NO:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Bombardier", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.GreenYellow
        Me.Label6.Location = New System.Drawing.Point(12, 4)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 15)
        Me.Label6.TabIndex = 437
        Me.Label6.Text = "DR OPTION:"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Enabled = False
        Me.CheckBox1.Font = New System.Drawing.Font("Bombardier", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.ForeColor = System.Drawing.Color.YellowGreen
        Me.CheckBox1.Location = New System.Drawing.Point(16, 752)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(163, 22)
        Me.CheckBox1.TabIndex = 14
        Me.CheckBox1.Text = "Stockpile to stockpile"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'picStoS
        '
        Me.picStoS.BackColor = System.Drawing.Color.Transparent
        Me.picStoS.Image = Global.SUPPLY.My.Resources.Resources.icon_cp_plus_drop
        Me.picStoS.Location = New System.Drawing.Point(234, 749)
        Me.picStoS.Name = "picStoS"
        Me.picStoS.Size = New System.Drawing.Size(33, 29)
        Me.picStoS.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picStoS.TabIndex = 436
        Me.picStoS.TabStop = False
        '
        'txtPrice
        '
        Me.txtPrice.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrice.Location = New System.Drawing.Point(47, 592)
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.Size = New System.Drawing.Size(217, 26)
        Me.txtPrice.TabIndex = 11
        '
        'txtRemarks
        '
        Me.txtRemarks.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRemarks.Location = New System.Drawing.Point(49, 534)
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(217, 26)
        Me.txtRemarks.TabIndex = 10
        '
        'txtCheckedBy
        '
        Me.txtCheckedBy.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCheckedBy.Location = New System.Drawing.Point(49, 418)
        Me.txtCheckedBy.Name = "txtCheckedBy"
        Me.txtCheckedBy.Size = New System.Drawing.Size(217, 26)
        Me.txtCheckedBy.TabIndex = 8
        '
        'txtConsession
        '
        Me.txtConsession.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConsession.Location = New System.Drawing.Point(49, 360)
        Me.txtConsession.Name = "txtConsession"
        Me.txtConsession.Size = New System.Drawing.Size(217, 26)
        Me.txtConsession.TabIndex = 7
        '
        'cmbDrOptions
        '
        Me.cmbDrOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbDrOptions.FormattingEnabled = True
        Me.cmbDrOptions.Location = New System.Drawing.Point(49, 29)
        Me.cmbDrOptions.Name = "cmbDrOptions"
        Me.cmbDrOptions.Size = New System.Drawing.Size(218, 21)
        Me.cmbDrOptions.TabIndex = 1
        '
        'txtDrQty
        '
        Me.txtDrQty.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDrQty.Location = New System.Drawing.Point(47, 708)
        Me.txtDrQty.Name = "txtDrQty"
        Me.txtDrQty.Size = New System.Drawing.Size(216, 26)
        Me.txtDrQty.TabIndex = 13
        '
        'btnReleaseNow
        '
        Me.btnReleaseNow.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnReleaseNow.BackColor = System.Drawing.Color.YellowGreen
        Me.btnReleaseNow.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReleaseNow.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReleaseNow.Image = CType(resources.GetObject("btnReleaseNow.Image"), System.Drawing.Image)
        Me.btnReleaseNow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReleaseNow.Location = New System.Drawing.Point(12, 785)
        Me.btnReleaseNow.Name = "btnReleaseNow"
        Me.btnReleaseNow.Size = New System.Drawing.Size(254, 37)
        Me.btnReleaseNow.TabIndex = 15
        Me.btnReleaseNow.Text = "Deliver (Ctrl + R)"
        Me.btnReleaseNow.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Bombardier", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.GreenYellow
        Me.Label1.Location = New System.Drawing.Point(9, 225)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 15)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "DATE SUBMITTED:"
        '
        'txtDrNo
        '
        Me.txtDrNo.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDrNo.Location = New System.Drawing.Point(47, 650)
        Me.txtDrNo.Name = "txtDrNo"
        Me.txtDrNo.Size = New System.Drawing.Size(216, 26)
        Me.txtDrNo.TabIndex = 12
        '
        'dtpDateSubmitted
        '
        Me.dtpDateSubmitted.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDateSubmitted.Location = New System.Drawing.Point(47, 250)
        Me.dtpDateSubmitted.Name = "dtpDateSubmitted"
        Me.dtpDateSubmitted.Size = New System.Drawing.Size(219, 20)
        Me.dtpDateSubmitted.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Bombardier", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.GreenYellow
        Me.Label2.Location = New System.Drawing.Point(9, 173)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 15)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "DR DATE:"
        '
        'txtDriver
        '
        Me.txtDriver.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDriver.Location = New System.Drawing.Point(49, 140)
        Me.txtDriver.Name = "txtDriver"
        Me.txtDriver.Size = New System.Drawing.Size(217, 26)
        Me.txtDriver.TabIndex = 3
        '
        'txtPlateNo
        '
        Me.txtPlateNo.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPlateNo.Location = New System.Drawing.Point(49, 82)
        Me.txtPlateNo.Name = "txtPlateNo"
        Me.txtPlateNo.Size = New System.Drawing.Size(217, 26)
        Me.txtPlateNo.TabIndex = 2
        '
        'dtpDrDate
        '
        Me.dtpDrDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDrDate.Location = New System.Drawing.Point(49, 198)
        Me.dtpDrDate.Name = "dtpDrDate"
        Me.dtpDrDate.Size = New System.Drawing.Size(217, 20)
        Me.dtpDrDate.TabIndex = 4
        '
        'txtSupplier
        '
        Me.txtSupplier.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSupplier.Location = New System.Drawing.Point(49, 302)
        Me.txtSupplier.Name = "txtSupplier"
        Me.txtSupplier.Size = New System.Drawing.Size(217, 26)
        Me.txtSupplier.TabIndex = 6
        '
        'FCreateDeliveryReceipt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1555, 1000)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "FCreateDeliveryReceipt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FCreateDeliveryReceipt"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.loadingPanel.ResumeLayout(False)
        Me.loadingPanel.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel19.ResumeLayout(False)
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel18.ResumeLayout(False)
        Me.Panel18.PerformLayout()
        Me.Panel17.ResumeLayout(False)
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel20.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel12.ResumeLayout(False)
        Me.Panel12.PerformLayout()
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.Panel13.ResumeLayout(False)
        Me.Panel13.PerformLayout()
        Me.Panel14.ResumeLayout(False)
        Me.Panel14.PerformLayout()
        Me.Panel15.ResumeLayout(False)
        Me.Panel15.PerformLayout()
        Me.Panel16.ResumeLayout(False)
        Me.Panel16.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        CType(Me.picStoS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents CreateWithdrawalToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RemoveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents debounce_new As Timer
    Friend WithEvents RecepientToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CopyThisRecepientToAllRowsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CopyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CopyFor5RowsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents picStoS As PictureBox
    Friend WithEvents txtPrice As TextBox
    Friend WithEvents txtRemarks As TextBox
    Friend WithEvents txtCheckedBy As TextBox
    Friend WithEvents txtConsession As TextBox
    Friend WithEvents cmbDrOptions As ComboBox
    Friend WithEvents txtDrQty As TextBox
    Friend WithEvents btnReleaseNow As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtDrNo As TextBox
    Friend WithEvents dtpDateSubmitted As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents txtDriver As TextBox
    Friend WithEvents txtPlateNo As TextBox
    Friend WithEvents dtpDrDate As DateTimePicker
    Friend WithEvents txtSupplier As TextBox
    Friend WithEvents Panel10 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents loadingPanel As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Panel11 As Panel
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents Button3 As Button
    Friend WithEvents txtSearchItems As TextBox
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents Panel12 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Panel13 As Panel
    Friend WithEvents lblTransaction As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Panel14 As Panel
    Friend WithEvents lblToBeDelivered As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Panel15 As Panel
    Friend WithEvents lblWithdrawn As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Panel16 As Panel
    Friend WithEvents lblDelivered As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents btnFinalSave As Button
    Friend WithEvents Panel19 As Panel
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents Panel18 As Panel
    Friend WithEvents lblRequestor As Label
    Friend WithEvents lblQty As Label
    Friend WithEvents Panel17 As Panel
    Friend WithEvents PictureBox7 As PictureBox
    Friend WithEvents PictureBox6 As PictureBox
    Friend WithEvents Panel20 As Panel
    Friend WithEvents lblStockpile As Label
    Friend WithEvents lblQuarry As Label
    Friend WithEvents lblItems As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents btnClose As Button
    Friend WithEvents HideLeftPanelToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ShowToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HideToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label20 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents txtReceivedBy As TextBox
    Friend WithEvents AutofillToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RefreshToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label22 As Label
End Class
