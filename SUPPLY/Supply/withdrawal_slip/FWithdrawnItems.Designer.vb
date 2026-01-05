<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FWithdrawnItems
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.loadingPanel = New System.Windows.Forms.Panel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.txtUnits = New System.Windows.Forms.TextBox()
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.txQtyPartiallyWithdrawn = New System.Windows.Forms.TextBox()
        Me.txtReceived = New System.Windows.Forms.TextBox()
        Me.btnWithdraw = New System.Windows.Forms.Button()
        Me.dtpDateWithdrawn = New System.Windows.Forms.DateTimePicker()
        Me.txtReleasedBy = New System.Windows.Forms.TextBox()
        Me.btnAddSerial = New System.Windows.Forms.Button()
        Me.lblTireRemaining = New System.Windows.Forms.Label()
        Me.txtSerialNo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.loadingPanel.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel8.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BackgroundImage = Global.SUPPLY.My.Resources.Resources.bg_line
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.loadingPanel)
        Me.Panel1.Controls.Add(Me.btnExit)
        Me.Panel1.Controls.Add(Me.lblTitle)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(448, 59)
        Me.Panel1.TabIndex = 11
        '
        'loadingPanel
        '
        Me.loadingPanel.BackColor = System.Drawing.Color.Transparent
        Me.loadingPanel.Controls.Add(Me.Label12)
        Me.loadingPanel.Controls.Add(Me.PictureBox1)
        Me.loadingPanel.Location = New System.Drawing.Point(3, 8)
        Me.loadingPanel.Name = "loadingPanel"
        Me.loadingPanel.Size = New System.Drawing.Size(261, 42)
        Me.loadingPanel.TabIndex = 421
        Me.loadingPanel.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(47, 11)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(204, 19)
        Me.Label12.TabIndex = 1
        Me.Label12.Text = "Fetching data, please wait..."
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.SUPPLY.My.Resources.Resources.spinner
        Me.PictureBox1.Location = New System.Drawing.Point(4, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(33, 33)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.BackColor = System.Drawing.Color.Transparent
        Me.btnExit.BackgroundImage = Global.SUPPLY.My.Resources.Resources.close_button
        Me.btnExit.FlatAppearance.BorderSize = 0
        Me.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit.Location = New System.Drawing.Point(412, 19)
        Me.btnExit.Margin = New System.Windows.Forms.Padding(3, 3, 10, 3)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(22, 22)
        Me.btnExit.TabIndex = 422
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblTitle.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(10, 18)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(83, 22)
        Me.lblTitle.TabIndex = 423
        Me.lblTitle.Text = "Withdraw"
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.Transparent
        Me.Panel8.Controls.Add(Me.lblTireRemaining)
        Me.Panel8.Controls.Add(Me.btnAddSerial)
        Me.Panel8.Controls.Add(Me.Label6)
        Me.Panel8.Controls.Add(Me.txtSerialNo)
        Me.Panel8.Controls.Add(Me.Label5)
        Me.Panel8.Controls.Add(Me.Label4)
        Me.Panel8.Controls.Add(Me.Label3)
        Me.Panel8.Controls.Add(Me.Label2)
        Me.Panel8.Controls.Add(Me.Label1)
        Me.Panel8.Controls.Add(Me.txtUnits)
        Me.Panel8.Controls.Add(Me.txtAmount)
        Me.Panel8.Controls.Add(Me.txQtyPartiallyWithdrawn)
        Me.Panel8.Controls.Add(Me.txtReceived)
        Me.Panel8.Controls.Add(Me.btnWithdraw)
        Me.Panel8.Controls.Add(Me.dtpDateWithdrawn)
        Me.Panel8.Controls.Add(Me.txtReleasedBy)
        Me.Panel8.Location = New System.Drawing.Point(7, 65)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(429, 483)
        Me.Panel8.TabIndex = 12
        '
        'txtUnits
        '
        Me.txtUnits.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUnits.Location = New System.Drawing.Point(187, 324)
        Me.txtUnits.Name = "txtUnits"
        Me.txtUnits.Size = New System.Drawing.Size(221, 26)
        Me.txtUnits.TabIndex = 4
        '
        'txtAmount
        '
        Me.txtAmount.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmount.Location = New System.Drawing.Point(187, 378)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(221, 26)
        Me.txtAmount.TabIndex = 5
        '
        'txQtyPartiallyWithdrawn
        '
        Me.txQtyPartiallyWithdrawn.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txQtyPartiallyWithdrawn.Location = New System.Drawing.Point(273, 269)
        Me.txQtyPartiallyWithdrawn.Name = "txQtyPartiallyWithdrawn"
        Me.txQtyPartiallyWithdrawn.Size = New System.Drawing.Size(135, 26)
        Me.txQtyPartiallyWithdrawn.TabIndex = 3
        '
        'txtReceived
        '
        Me.txtReceived.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReceived.Location = New System.Drawing.Point(187, 214)
        Me.txtReceived.Name = "txtReceived"
        Me.txtReceived.Size = New System.Drawing.Size(221, 26)
        Me.txtReceived.TabIndex = 2
        '
        'btnWithdraw
        '
        Me.btnWithdraw.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnWithdraw.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnWithdraw.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnWithdraw.Location = New System.Drawing.Point(25, 431)
        Me.btnWithdraw.Name = "btnWithdraw"
        Me.btnWithdraw.Size = New System.Drawing.Size(383, 32)
        Me.btnWithdraw.TabIndex = 6
        Me.btnWithdraw.Text = "Withdraw"
        Me.btnWithdraw.UseVisualStyleBackColor = False
        '
        'dtpDateWithdrawn
        '
        Me.dtpDateWithdrawn.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDateWithdrawn.Location = New System.Drawing.Point(187, 28)
        Me.dtpDateWithdrawn.Name = "dtpDateWithdrawn"
        Me.dtpDateWithdrawn.Size = New System.Drawing.Size(221, 20)
        Me.dtpDateWithdrawn.TabIndex = 0
        '
        'txtReleasedBy
        '
        Me.txtReleasedBy.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReleasedBy.Location = New System.Drawing.Point(187, 161)
        Me.txtReleasedBy.Name = "txtReleasedBy"
        Me.txtReleasedBy.Size = New System.Drawing.Size(221, 26)
        Me.txtReleasedBy.TabIndex = 1
        '
        'btnAddSerial
        '
        Me.btnAddSerial.BackColor = System.Drawing.Color.Transparent
        Me.btnAddSerial.BackgroundImage = Global.SUPPLY.My.Resources.Resources.Plus_sign
        Me.btnAddSerial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAddSerial.Enabled = False
        Me.btnAddSerial.FlatAppearance.BorderSize = 0
        Me.btnAddSerial.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnAddSerial.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnAddSerial.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddSerial.Location = New System.Drawing.Point(388, 74)
        Me.btnAddSerial.Name = "btnAddSerial"
        Me.btnAddSerial.Size = New System.Drawing.Size(20, 20)
        Me.btnAddSerial.TabIndex = 453
        Me.btnAddSerial.UseVisualStyleBackColor = False
        '
        'lblTireRemaining
        '
        Me.lblTireRemaining.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTireRemaining.BackColor = System.Drawing.Color.DarkOliveGreen
        Me.lblTireRemaining.Enabled = False
        Me.lblTireRemaining.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTireRemaining.ForeColor = System.Drawing.Color.GreenYellow
        Me.lblTireRemaining.Location = New System.Drawing.Point(146, 112)
        Me.lblTireRemaining.Name = "lblTireRemaining"
        Me.lblTireRemaining.Padding = New System.Windows.Forms.Padding(3)
        Me.lblTireRemaining.Size = New System.Drawing.Size(262, 25)
        Me.lblTireRemaining.TabIndex = 454
        Me.lblTireRemaining.Text = "remaining: 0"
        Me.lblTireRemaining.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSerialNo
        '
        Me.txtSerialNo.Enabled = False
        Me.txtSerialNo.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSerialNo.Location = New System.Drawing.Point(187, 71)
        Me.txtSerialNo.Name = "txtSerialNo"
        Me.txtSerialNo.Size = New System.Drawing.Size(184, 26)
        Me.txtSerialNo.TabIndex = 452
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Bombardier", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.GreenYellow
        Me.Label1.Location = New System.Drawing.Point(22, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 16)
        Me.Label1.TabIndex = 456
        Me.Label1.Text = "DATE WITHDRAWN:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Bombardier", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.GreenYellow
        Me.Label2.Location = New System.Drawing.Point(22, 166)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 16)
        Me.Label2.TabIndex = 457
        Me.Label2.Text = "RELEASED BY:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Bombardier", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.GreenYellow
        Me.Label3.Location = New System.Drawing.Point(22, 219)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 16)
        Me.Label3.TabIndex = 458
        Me.Label3.Text = "RECEIVED BY:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Bombardier", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.GreenYellow
        Me.Label4.Location = New System.Drawing.Point(22, 274)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(139, 16)
        Me.Label4.TabIndex = 459
        Me.Label4.Text = "PARTIAL QTY WITHDRAW:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Bombardier", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.GreenYellow
        Me.Label5.Location = New System.Drawing.Point(61, 329)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 16)
        Me.Label5.TabIndex = 460
        Me.Label5.Text = "UNITS:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Bombardier", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.GreenYellow
        Me.Label6.Location = New System.Drawing.Point(48, 383)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 16)
        Me.Label6.TabIndex = 461
        Me.Label6.Text = "AMOUNT:"
        '
        'FWithdrawnItems
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SUPPLY.My.Resources.Resources.eus_bg_03
        Me.ClientSize = New System.Drawing.Size(448, 571)
        Me.Controls.Add(Me.Panel8)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FWithdrawnItems"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FWithdrawnItems"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.loadingPanel.ResumeLayout(False)
        Me.loadingPanel.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents loadingPanel As Panel
    Friend WithEvents Label12 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Panel8 As Panel
    Friend WithEvents btnWithdraw As Button
    Friend WithEvents dtpDateWithdrawn As DateTimePicker
    Friend WithEvents txtReleasedBy As TextBox
    Friend WithEvents txtReceived As TextBox
    Friend WithEvents btnExit As Button
    Friend WithEvents txQtyPartiallyWithdrawn As TextBox
    Friend WithEvents txtAmount As TextBox
    Friend WithEvents lblTitle As Label
    Friend WithEvents txtUnits As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnAddSerial As Button
    Friend WithEvents lblTireRemaining As Label
    Friend WithEvents txtSerialNo As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
End Class
