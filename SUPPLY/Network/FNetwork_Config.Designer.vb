<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FNetwork_Config
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FNetwork_Config))
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.txtDatabaseName = New System.Windows.Forms.TextBox()
        Me.txtServer = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.pboxSave = New System.Windows.Forms.PictureBox()
        Me.pboxHeader = New System.Windows.Forms.PictureBox()
        Me.PanelBSForm_btnExit = New System.Windows.Forms.Button()
        Me.cmbsource = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.pboxSave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pboxHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Trebuchet MS", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(339, 326)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 20)
        Me.Label6.TabIndex = 209
        Me.Label6.Text = "Save"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(73, 276)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 18)
        Me.Label4.TabIndex = 207
        Me.Label4.Text = "Password :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(70, 227)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 18)
        Me.Label3.TabIndex = 206
        Me.Label3.Text = "Username :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(40, 178)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 18)
        Me.Label2.TabIndex = 205
        Me.Label2.Text = "Database Name :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(89, 129)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 18)
        Me.Label1.TabIndex = 204
        Me.Label1.Text = "Server :"
        '
        'txtPassword
        '
        Me.txtPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.Location = New System.Drawing.Point(147, 270)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(35)
        Me.txtPassword.Size = New System.Drawing.Size(274, 26)
        Me.txtPassword.TabIndex = 200
        '
        'txtUsername
        '
        Me.txtUsername.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsername.Location = New System.Drawing.Point(147, 221)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(274, 26)
        Me.txtUsername.TabIndex = 199
        '
        'txtDatabaseName
        '
        Me.txtDatabaseName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDatabaseName.Location = New System.Drawing.Point(147, 172)
        Me.txtDatabaseName.Name = "txtDatabaseName"
        Me.txtDatabaseName.Size = New System.Drawing.Size(274, 26)
        Me.txtDatabaseName.TabIndex = 198
        '
        'txtServer
        '
        Me.txtServer.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtServer.Location = New System.Drawing.Point(147, 123)
        Me.txtServer.Name = "txtServer"
        Me.txtServer.Size = New System.Drawing.Size(274, 26)
        Me.txtServer.TabIndex = 197
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(24, 13)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(185, 22)
        Me.Label15.TabIndex = 203
        Me.Label15.Text = "Network Configuration"
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.Transparent
        Me.btnExit.FlatAppearance.BorderSize = 0
        Me.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit.Location = New System.Drawing.Point(432, 12)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(20, 20)
        Me.btnExit.TabIndex = 202
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'pboxSave
        '
        Me.pboxSave.BackColor = System.Drawing.Color.Transparent
        Me.pboxSave.BackgroundImage = Global.SUPPLY.My.Resources.Resources.button_close
        Me.pboxSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pboxSave.Location = New System.Drawing.Point(296, 317)
        Me.pboxSave.Name = "pboxSave"
        Me.pboxSave.Padding = New System.Windows.Forms.Padding(20, 12, 0, 0)
        Me.pboxSave.Size = New System.Drawing.Size(125, 40)
        Me.pboxSave.TabIndex = 208
        Me.pboxSave.TabStop = False
        '
        'pboxHeader
        '
        Me.pboxHeader.BackgroundImage = CType(resources.GetObject("pboxHeader.BackgroundImage"), System.Drawing.Image)
        Me.pboxHeader.Location = New System.Drawing.Point(0, 0)
        Me.pboxHeader.Name = "pboxHeader"
        Me.pboxHeader.Size = New System.Drawing.Size(464, 41)
        Me.pboxHeader.TabIndex = 201
        Me.pboxHeader.TabStop = False
        '
        'PanelBSForm_btnExit
        '
        Me.PanelBSForm_btnExit.BackColor = System.Drawing.Color.Transparent
        Me.PanelBSForm_btnExit.BackgroundImage = Global.SUPPLY.My.Resources.Resources.close_button
        Me.PanelBSForm_btnExit.FlatAppearance.BorderSize = 0
        Me.PanelBSForm_btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.PanelBSForm_btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.PanelBSForm_btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.PanelBSForm_btnExit.Location = New System.Drawing.Point(432, 12)
        Me.PanelBSForm_btnExit.Name = "PanelBSForm_btnExit"
        Me.PanelBSForm_btnExit.Size = New System.Drawing.Size(22, 20)
        Me.PanelBSForm_btnExit.TabIndex = 438
        Me.PanelBSForm_btnExit.UseVisualStyleBackColor = False
        '
        'cmbsource
        '
        Me.cmbsource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbsource.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbsource.FormattingEnabled = True
        Me.cmbsource.Items.AddRange(New Object() {"EUS", "SUPPLY"})
        Me.cmbsource.Location = New System.Drawing.Point(147, 74)
        Me.cmbsource.Name = "cmbsource"
        Me.cmbsource.Size = New System.Drawing.Size(274, 26)
        Me.cmbsource.TabIndex = 439
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(72, 80)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 18)
        Me.Label5.TabIndex = 440
        Me.Label5.Text = "DB Source:"
        '
        'FNetwork_Config
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SUPPLY.My.Resources.Resources.eus_bg_03
        Me.ClientSize = New System.Drawing.Size(462, 392)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cmbsource)
        Me.Controls.Add(Me.PanelBSForm_btnExit)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.pboxSave)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.txtDatabaseName)
        Me.Controls.Add(Me.txtServer)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.pboxHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FNetwork_Config"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FNetwork_Config"
        CType(Me.pboxSave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pboxHeader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents pboxSave As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtUsername As System.Windows.Forms.TextBox
    Friend WithEvents txtDatabaseName As System.Windows.Forms.TextBox
    Friend WithEvents txtServer As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents pboxHeader As System.Windows.Forms.PictureBox
    Friend WithEvents PanelBSForm_btnExit As System.Windows.Forms.Button
    Friend WithEvents cmbsource As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
