<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FCreateRSForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FCreateRSForm))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.loadingPanel = New System.Windows.Forms.Panel()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnAutoFill = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNotedBy = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.txtRequestedBy = New System.Windows.Forms.TextBox()
        Me.txtRemarksFromEMD = New System.Windows.Forms.TextBox()
        Me.txtPurpose = New System.Windows.Forms.TextBox()
        Me.txtUnits = New System.Windows.Forms.TextBox()
        Me.txtQty = New System.Windows.Forms.TextBox()
        Me.txtJoNo = New System.Windows.Forms.TextBox()
        Me.dtpDateNeeded = New System.Windows.Forms.DateTimePicker()
        Me.dtpRsDate = New System.Windows.Forms.DateTimePicker()
        Me.txtLocation = New System.Windows.Forms.TextBox()
        Me.cmbTypeOfCharges = New System.Windows.Forms.ComboBox()
        Me.txtRsNo = New System.Windows.Forms.TextBox()
        Me.btnProperName = New System.Windows.Forms.PictureBox()
        Me.txtProperName = New System.Windows.Forms.TextBox()
        Me.txtItemDescription = New System.Windows.Forms.TextBox()
        Me.cmbConsolidationAccount = New System.Windows.Forms.ComboBox()
        Me.cmbTypeOfRequestSub = New System.Windows.Forms.ComboBox()
        Me.cmbTypeOfRequest = New System.Windows.Forms.ComboBox()
        Me.Panel1.SuspendLayout()
        Me.loadingPanel.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnProperName, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BackgroundImage = Global.SUPPLY.My.Resources.Resources.eus_bg_03
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.loadingPanel)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(761, 59)
        Me.Panel1.TabIndex = 15
        '
        'loadingPanel
        '
        Me.loadingPanel.BackColor = System.Drawing.Color.Transparent
        Me.loadingPanel.BackgroundImage = Global.SUPPLY.My.Resources.Resources.eus_bg_03
        Me.loadingPanel.Controls.Add(Me.Label20)
        Me.loadingPanel.Controls.Add(Me.PictureBox4)
        Me.loadingPanel.Location = New System.Drawing.Point(12, 12)
        Me.loadingPanel.Name = "loadingPanel"
        Me.loadingPanel.Size = New System.Drawing.Size(264, 31)
        Me.loadingPanel.TabIndex = 430
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
        'Panel4
        '
        Me.Panel4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.Controls.Add(Me.Button1)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Controls.Add(Me.PictureBox2)
        Me.Panel4.Location = New System.Drawing.Point(337, 6)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(414, 44)
        Me.Panel4.TabIndex = 425
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
        Me.Button1.Location = New System.Drawing.Point(376, 11)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 3, 10, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(22, 22)
        Me.Button1.TabIndex = 424
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Bombardier", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.SpringGreen
        Me.Label1.Location = New System.Drawing.Point(51, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(175, 24)
        Me.Label1.TabIndex = 422
        Me.Label1.Text = "CREATE REQUESITION"
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.PictureBox2.Image = Global.SUPPLY.My.Resources.Resources.reg_button
        Me.PictureBox2.Location = New System.Drawing.Point(6, 3)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(39, 40)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 423
        Me.PictureBox2.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.BackgroundImage = Global.SUPPLY.My.Resources.Resources.bg_line
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.btnAutoFill)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.Label14)
        Me.Panel2.Controls.Add(Me.Label16)
        Me.Panel2.Controls.Add(Me.Label18)
        Me.Panel2.Controls.Add(Me.Label19)
        Me.Panel2.Controls.Add(Me.Label21)
        Me.Panel2.Controls.Add(Me.Label22)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.txtNotedBy)
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Controls.Add(Me.btnSave)
        Me.Panel2.Controls.Add(Me.txtRequestedBy)
        Me.Panel2.Controls.Add(Me.txtRemarksFromEMD)
        Me.Panel2.Controls.Add(Me.txtPurpose)
        Me.Panel2.Controls.Add(Me.txtUnits)
        Me.Panel2.Controls.Add(Me.txtQty)
        Me.Panel2.Controls.Add(Me.txtJoNo)
        Me.Panel2.Controls.Add(Me.dtpDateNeeded)
        Me.Panel2.Controls.Add(Me.dtpRsDate)
        Me.Panel2.Controls.Add(Me.txtLocation)
        Me.Panel2.Controls.Add(Me.cmbTypeOfCharges)
        Me.Panel2.Controls.Add(Me.txtRsNo)
        Me.Panel2.Controls.Add(Me.btnProperName)
        Me.Panel2.Controls.Add(Me.txtProperName)
        Me.Panel2.Controls.Add(Me.txtItemDescription)
        Me.Panel2.Controls.Add(Me.cmbConsolidationAccount)
        Me.Panel2.Controls.Add(Me.cmbTypeOfRequestSub)
        Me.Panel2.Controls.Add(Me.cmbTypeOfRequest)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 59)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(761, 669)
        Me.Panel2.TabIndex = 16
        '
        'btnAutoFill
        '
        Me.btnAutoFill.BackColor = System.Drawing.Color.Green
        Me.btnAutoFill.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAutoFill.Font = New System.Drawing.Font("Bombardier", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAutoFill.ForeColor = System.Drawing.Color.White
        Me.btnAutoFill.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAutoFill.Location = New System.Drawing.Point(59, 586)
        Me.btnAutoFill.Name = "btnAutoFill"
        Me.btnAutoFill.Size = New System.Drawing.Size(127, 39)
        Me.btnAutoFill.TabIndex = 443
        Me.btnAutoFill.Text = "AUTO FILL"
        Me.btnAutoFill.UseVisualStyleBackColor = False
        Me.btnAutoFill.Visible = False
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Bombardier", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.GreenYellow
        Me.Label12.Location = New System.Drawing.Point(378, 508)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(156, 16)
        Me.Label12.TabIndex = 442
        Me.Label12.Text = "PROPER ITEM DESCRIPTION:"
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Bombardier", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.GreenYellow
        Me.Label14.Location = New System.Drawing.Point(378, 397)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(128, 16)
        Me.Label14.TabIndex = 440
        Me.Label14.Text = "RS ITEM DESCRIPTION:"
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Bombardier", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.GreenYellow
        Me.Label16.Location = New System.Drawing.Point(378, 288)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(115, 16)
        Me.Label16.TabIndex = 438
        Me.Label16.Text = "REMARKS FOR EMD:"
        '
        'Label18
        '
        Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Bombardier", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.GreenYellow
        Me.Label18.Location = New System.Drawing.Point(378, 187)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(60, 16)
        Me.Label18.TabIndex = 436
        Me.Label18.Text = "PURPOSE:"
        '
        'Label19
        '
        Me.Label19.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Bombardier", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.GreenYellow
        Me.Label19.Location = New System.Drawing.Point(378, 132)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(64, 16)
        Me.Label19.TabIndex = 435
        Me.Label19.Text = "NOTED BY:"
        '
        'Label21
        '
        Me.Label21.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Bombardier", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.GreenYellow
        Me.Label21.Location = New System.Drawing.Point(378, 73)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(92, 16)
        Me.Label21.TabIndex = 434
        Me.Label21.Text = "REQUESTED BY:"
        '
        'Label22
        '
        Me.Label22.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Bombardier", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.GreenYellow
        Me.Label22.Location = New System.Drawing.Point(378, 14)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(42, 16)
        Me.Label22.TabIndex = 433
        Me.Label22.Text = "UNITS:"
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Bombardier", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.GreenYellow
        Me.Label11.Location = New System.Drawing.Point(20, 513)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(81, 16)
        Me.Label11.TabIndex = 432
        Me.Label11.Text = "RS QUANTITY:"
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Bombardier", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.GreenYellow
        Me.Label10.Location = New System.Drawing.Point(20, 455)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(71, 16)
        Me.Label10.TabIndex = 431
        Me.Label10.Text = "JOB ORDER:"
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Bombardier", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.GreenYellow
        Me.Label9.Location = New System.Drawing.Point(20, 397)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(63, 16)
        Me.Label9.TabIndex = 430
        Me.Label9.Text = "LOCATION:"
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Bombardier", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.GreenYellow
        Me.Label8.Location = New System.Drawing.Point(20, 341)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 16)
        Me.Label8.TabIndex = 429
        Me.Label8.Text = "RS NO:"
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Bombardier", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.GreenYellow
        Me.Label7.Location = New System.Drawing.Point(20, 289)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(110, 16)
        Me.Label7.TabIndex = 428
        Me.Label7.Text = "TYPE OF CHARGES:"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Bombardier", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.GreenYellow
        Me.Label6.Location = New System.Drawing.Point(20, 235)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(124, 16)
        Me.Label6.TabIndex = 427
        Me.Label6.Text = "ACCOUNT TITLE (SUB)"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Bombardier", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.GreenYellow
        Me.Label5.Location = New System.Drawing.Point(20, 181)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(95, 16)
        Me.Label5.TabIndex = 426
        Me.Label5.Text = "ACCOUNT TITLE:"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Bombardier", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.GreenYellow
        Me.Label4.Location = New System.Drawing.Point(20, 129)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(110, 16)
        Me.Label4.TabIndex = 425
        Me.Label4.Text = "TYPE OF REQUEST:"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Bombardier", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.GreenYellow
        Me.Label3.Location = New System.Drawing.Point(20, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 16)
        Me.Label3.TabIndex = 424
        Me.Label3.Text = "DATE NEEDED:"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Bombardier", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.GreenYellow
        Me.Label2.Location = New System.Drawing.Point(20, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 16)
        Me.Label2.TabIndex = 423
        Me.Label2.Text = "DATE REQUEST:"
        '
        'txtNotedBy
        '
        Me.txtNotedBy.Font = New System.Drawing.Font("Bombardier", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNotedBy.Location = New System.Drawing.Point(418, 157)
        Me.txtNotedBy.Name = "txtNotedBy"
        Me.txtNotedBy.ReadOnly = True
        Me.txtNotedBy.Size = New System.Drawing.Size(311, 24)
        Me.txtNotedBy.TabIndex = 13
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = Global.SUPPLY.My.Resources.Resources.remove_icon
        Me.PictureBox1.Location = New System.Drawing.Point(707, 533)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(26, 23)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 395
        Me.PictureBox1.TabStop = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.Green
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Bombardier", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(380, 586)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(349, 39)
        Me.btnSave.TabIndex = 18
        Me.btnSave.Text = "Create Requesition"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'txtRequestedBy
        '
        Me.txtRequestedBy.Font = New System.Drawing.Font("Bombardier", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRequestedBy.Location = New System.Drawing.Point(418, 100)
        Me.txtRequestedBy.Name = "txtRequestedBy"
        Me.txtRequestedBy.ReadOnly = True
        Me.txtRequestedBy.Size = New System.Drawing.Size(311, 24)
        Me.txtRequestedBy.TabIndex = 12
        '
        'txtRemarksFromEMD
        '
        Me.txtRemarksFromEMD.Font = New System.Drawing.Font("Bombardier", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRemarksFromEMD.Location = New System.Drawing.Point(418, 317)
        Me.txtRemarksFromEMD.Multiline = True
        Me.txtRemarksFromEMD.Name = "txtRemarksFromEMD"
        Me.txtRemarksFromEMD.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtRemarksFromEMD.Size = New System.Drawing.Size(311, 61)
        Me.txtRemarksFromEMD.TabIndex = 15
        '
        'txtPurpose
        '
        Me.txtPurpose.Font = New System.Drawing.Font("Bombardier", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPurpose.Location = New System.Drawing.Point(418, 216)
        Me.txtPurpose.Multiline = True
        Me.txtPurpose.Name = "txtPurpose"
        Me.txtPurpose.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtPurpose.Size = New System.Drawing.Size(311, 56)
        Me.txtPurpose.TabIndex = 14
        '
        'txtUnits
        '
        Me.txtUnits.Font = New System.Drawing.Font("Bombardier", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUnits.Location = New System.Drawing.Point(418, 40)
        Me.txtUnits.Name = "txtUnits"
        Me.txtUnits.ReadOnly = True
        Me.txtUnits.Size = New System.Drawing.Size(311, 24)
        Me.txtUnits.TabIndex = 11
        '
        'txtQty
        '
        Me.txtQty.Font = New System.Drawing.Font("Bombardier", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQty.Location = New System.Drawing.Point(59, 538)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.ReadOnly = True
        Me.txtQty.Size = New System.Drawing.Size(311, 24)
        Me.txtQty.TabIndex = 10
        '
        'txtJoNo
        '
        Me.txtJoNo.Font = New System.Drawing.Font("Bombardier", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtJoNo.Location = New System.Drawing.Point(59, 480)
        Me.txtJoNo.Name = "txtJoNo"
        Me.txtJoNo.ReadOnly = True
        Me.txtJoNo.Size = New System.Drawing.Size(311, 24)
        Me.txtJoNo.TabIndex = 9
        '
        'dtpDateNeeded
        '
        Me.dtpDateNeeded.CustomFormat = ""
        Me.dtpDateNeeded.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDateNeeded.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDateNeeded.Location = New System.Drawing.Point(59, 96)
        Me.dtpDateNeeded.Margin = New System.Windows.Forms.Padding(10, 3, 3, 3)
        Me.dtpDateNeeded.Name = "dtpDateNeeded"
        Me.dtpDateNeeded.Size = New System.Drawing.Size(311, 24)
        Me.dtpDateNeeded.TabIndex = 2
        '
        'dtpRsDate
        '
        Me.dtpRsDate.CustomFormat = ""
        Me.dtpRsDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpRsDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpRsDate.Location = New System.Drawing.Point(59, 40)
        Me.dtpRsDate.Margin = New System.Windows.Forms.Padding(10, 3, 3, 3)
        Me.dtpRsDate.Name = "dtpRsDate"
        Me.dtpRsDate.Size = New System.Drawing.Size(311, 24)
        Me.dtpRsDate.TabIndex = 1
        '
        'txtLocation
        '
        Me.txtLocation.Font = New System.Drawing.Font("Bombardier", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLocation.Location = New System.Drawing.Point(59, 422)
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.ReadOnly = True
        Me.txtLocation.Size = New System.Drawing.Size(311, 24)
        Me.txtLocation.TabIndex = 8
        '
        'cmbTypeOfCharges
        '
        Me.cmbTypeOfCharges.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbTypeOfCharges.FormattingEnabled = True
        Me.cmbTypeOfCharges.Items.AddRange(New Object() {"ADFIL", "OUTSOURCE", "JQG", "BBC"})
        Me.cmbTypeOfCharges.Location = New System.Drawing.Point(59, 313)
        Me.cmbTypeOfCharges.Name = "cmbTypeOfCharges"
        Me.cmbTypeOfCharges.Size = New System.Drawing.Size(311, 21)
        Me.cmbTypeOfCharges.TabIndex = 6
        '
        'txtRsNo
        '
        Me.txtRsNo.Font = New System.Drawing.Font("Bombardier", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRsNo.Location = New System.Drawing.Point(59, 366)
        Me.txtRsNo.Name = "txtRsNo"
        Me.txtRsNo.ReadOnly = True
        Me.txtRsNo.Size = New System.Drawing.Size(311, 24)
        Me.txtRsNo.TabIndex = 7
        '
        'btnProperName
        '
        Me.btnProperName.BackColor = System.Drawing.Color.Transparent
        Me.btnProperName.Image = Global.SUPPLY.My.Resources.Resources.Plus_sign
        Me.btnProperName.Location = New System.Drawing.Point(677, 532)
        Me.btnProperName.Name = "btnProperName"
        Me.btnProperName.Size = New System.Drawing.Size(26, 23)
        Me.btnProperName.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnProperName.TabIndex = 394
        Me.btnProperName.TabStop = False
        '
        'txtProperName
        '
        Me.txtProperName.Font = New System.Drawing.Font("Bombardier", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProperName.Location = New System.Drawing.Point(418, 533)
        Me.txtProperName.Name = "txtProperName"
        Me.txtProperName.ReadOnly = True
        Me.txtProperName.Size = New System.Drawing.Size(248, 24)
        Me.txtProperName.TabIndex = 17
        '
        'txtItemDescription
        '
        Me.txtItemDescription.Font = New System.Drawing.Font("Bombardier", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemDescription.Location = New System.Drawing.Point(418, 426)
        Me.txtItemDescription.Multiline = True
        Me.txtItemDescription.Name = "txtItemDescription"
        Me.txtItemDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtItemDescription.Size = New System.Drawing.Size(311, 56)
        Me.txtItemDescription.TabIndex = 16
        '
        'cmbConsolidationAccount
        '
        Me.cmbConsolidationAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbConsolidationAccount.FormattingEnabled = True
        Me.cmbConsolidationAccount.Location = New System.Drawing.Point(59, 259)
        Me.cmbConsolidationAccount.Name = "cmbConsolidationAccount"
        Me.cmbConsolidationAccount.Size = New System.Drawing.Size(311, 21)
        Me.cmbConsolidationAccount.TabIndex = 5
        '
        'cmbTypeOfRequestSub
        '
        Me.cmbTypeOfRequestSub.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbTypeOfRequestSub.FormattingEnabled = True
        Me.cmbTypeOfRequestSub.Location = New System.Drawing.Point(59, 206)
        Me.cmbTypeOfRequestSub.Name = "cmbTypeOfRequestSub"
        Me.cmbTypeOfRequestSub.Size = New System.Drawing.Size(311, 21)
        Me.cmbTypeOfRequestSub.TabIndex = 4
        '
        'cmbTypeOfRequest
        '
        Me.cmbTypeOfRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbTypeOfRequest.FormattingEnabled = True
        Me.cmbTypeOfRequest.Location = New System.Drawing.Point(59, 153)
        Me.cmbTypeOfRequest.Name = "cmbTypeOfRequest"
        Me.cmbTypeOfRequest.Size = New System.Drawing.Size(311, 21)
        Me.cmbTypeOfRequest.TabIndex = 3
        '
        'FCreateRSForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(761, 728)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FCreateRSForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "FCreateRSForm"
        Me.Panel1.ResumeLayout(False)
        Me.loadingPanel.ResumeLayout(False)
        Me.loadingPanel.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnProperName, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents cmbConsolidationAccount As ComboBox
    Friend WithEvents cmbTypeOfRequestSub As ComboBox
    Friend WithEvents cmbTypeOfRequest As ComboBox
    Friend WithEvents txtItemDescription As TextBox
    Friend WithEvents btnProperName As PictureBox
    Friend WithEvents txtProperName As TextBox
    Friend WithEvents txtLocation As TextBox
    Friend WithEvents cmbTypeOfCharges As ComboBox
    Friend WithEvents txtRsNo As TextBox
    Friend WithEvents dtpRsDate As DateTimePicker
    Friend WithEvents dtpDateNeeded As DateTimePicker
    Friend WithEvents txtRequestedBy As TextBox
    Friend WithEvents txtRemarksFromEMD As TextBox
    Friend WithEvents txtPurpose As TextBox
    Friend WithEvents txtUnits As TextBox
    Friend WithEvents txtQty As TextBox
    Friend WithEvents txtJoNo As TextBox
    Friend WithEvents btnSave As Button
    Friend WithEvents loadingPanel As Panel
    Friend WithEvents Label20 As Label
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents txtNotedBy As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents btnAutoFill As Button
End Class
