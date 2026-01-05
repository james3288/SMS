<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FchangePassword
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FchangePassword))
        Me.lblUsername = New System.Windows.Forms.Label
        Me.txtUsername = New System.Windows.Forms.TextBox
        Me.lblOldpassword = New System.Windows.Forms.Label
        Me.txtOldpassword = New System.Windows.Forms.TextBox
        Me.lblNewpassword = New System.Windows.Forms.Label
        Me.txtNewpassword = New System.Windows.Forms.TextBox
        Me.lblConfirmedPass = New System.Windows.Forms.Label
        Me.txtConfirmedpass = New System.Windows.Forms.TextBox
        Me.lblTitle = New System.Windows.Forms.Label
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.pboxSave = New System.Windows.Forms.PictureBox
        Me.lblSave = New System.Windows.Forms.Label
        Me.btnExit = New System.Windows.Forms.Button
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pboxSave, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblUsername
        '
        Me.lblUsername.AutoSize = True
        Me.lblUsername.BackColor = System.Drawing.Color.Transparent
        Me.lblUsername.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsername.ForeColor = System.Drawing.Color.White
        Me.lblUsername.Location = New System.Drawing.Point(85, 107)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(83, 16)
        Me.lblUsername.TabIndex = 0
        Me.lblUsername.Text = "Username:"
        '
        'txtUsername
        '
        Me.txtUsername.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsername.Location = New System.Drawing.Point(174, 104)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(244, 23)
        Me.txtUsername.TabIndex = 1
        '
        'lblOldpassword
        '
        Me.lblOldpassword.AutoSize = True
        Me.lblOldpassword.BackColor = System.Drawing.Color.Transparent
        Me.lblOldpassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOldpassword.ForeColor = System.Drawing.Color.White
        Me.lblOldpassword.Location = New System.Drawing.Point(61, 145)
        Me.lblOldpassword.Name = "lblOldpassword"
        Me.lblOldpassword.Size = New System.Drawing.Size(108, 16)
        Me.lblOldpassword.TabIndex = 2
        Me.lblOldpassword.Text = "Old Password:"
        '
        'txtOldpassword
        '
        Me.txtOldpassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOldpassword.Location = New System.Drawing.Point(174, 138)
        Me.txtOldpassword.Name = "txtOldpassword"
        Me.txtOldpassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtOldpassword.Size = New System.Drawing.Size(244, 23)
        Me.txtOldpassword.TabIndex = 3
        '
        'lblNewpassword
        '
        Me.lblNewpassword.AutoSize = True
        Me.lblNewpassword.BackColor = System.Drawing.Color.Transparent
        Me.lblNewpassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNewpassword.ForeColor = System.Drawing.Color.White
        Me.lblNewpassword.Location = New System.Drawing.Point(54, 177)
        Me.lblNewpassword.Name = "lblNewpassword"
        Me.lblNewpassword.Size = New System.Drawing.Size(114, 16)
        Me.lblNewpassword.TabIndex = 4
        Me.lblNewpassword.Text = "New Password:"
        '
        'txtNewpassword
        '
        Me.txtNewpassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNewpassword.Location = New System.Drawing.Point(174, 170)
        Me.txtNewpassword.Name = "txtNewpassword"
        Me.txtNewpassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtNewpassword.Size = New System.Drawing.Size(244, 23)
        Me.txtNewpassword.TabIndex = 5
        '
        'lblConfirmedPass
        '
        Me.lblConfirmedPass.AutoSize = True
        Me.lblConfirmedPass.BackColor = System.Drawing.Color.Transparent
        Me.lblConfirmedPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConfirmedPass.ForeColor = System.Drawing.Color.White
        Me.lblConfirmedPass.Location = New System.Drawing.Point(14, 209)
        Me.lblConfirmedPass.Name = "lblConfirmedPass"
        Me.lblConfirmedPass.Size = New System.Drawing.Size(154, 16)
        Me.lblConfirmedPass.TabIndex = 6
        Me.lblConfirmedPass.Text = "Confirmed Password:"
        '
        'txtConfirmedpass
        '
        Me.txtConfirmedpass.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConfirmedpass.Location = New System.Drawing.Point(174, 202)
        Me.txtConfirmedpass.Name = "txtConfirmedpass"
        Me.txtConfirmedpass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtConfirmedpass.Size = New System.Drawing.Size(244, 23)
        Me.txtConfirmedpass.TabIndex = 7
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(26, 45)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(188, 25)
        Me.lblTitle.TabIndex = 9
        Me.lblTitle.Text = "Change Password"
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.SystemColors.Control
        Me.PictureBox3.BackgroundImage = CType(resources.GetObject("PictureBox3.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(0, -1)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(432, 15)
        Me.PictureBox3.TabIndex = 392
        Me.PictureBox3.TabStop = False
        '
        'pboxSave
        '
        Me.pboxSave.BackColor = System.Drawing.Color.Transparent
        Me.pboxSave.BackgroundImage = CType(resources.GetObject("pboxSave.BackgroundImage"), System.Drawing.Image)
        Me.pboxSave.Location = New System.Drawing.Point(300, 236)
        Me.pboxSave.Name = "pboxSave"
        Me.pboxSave.Size = New System.Drawing.Size(118, 37)
        Me.pboxSave.TabIndex = 393
        Me.pboxSave.TabStop = False
        '
        'lblSave
        '
        Me.lblSave.AutoSize = True
        Me.lblSave.BackColor = System.Drawing.Color.Transparent
        Me.lblSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSave.Location = New System.Drawing.Point(337, 248)
        Me.lblSave.Name = "lblSave"
        Me.lblSave.Size = New System.Drawing.Size(44, 16)
        Me.lblSave.TabIndex = 394
        Me.lblSave.Text = "Save"
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.Transparent
        Me.btnExit.BackgroundImage = CType(resources.GetObject("btnExit.BackgroundImage"), System.Drawing.Image)
        Me.btnExit.FlatAppearance.BorderSize = 0
        Me.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit.Location = New System.Drawing.Point(402, 20)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(23, 21)
        Me.btnExit.TabIndex = 404
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'FchangePassword
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SUPPLY.My.Resources.Resources.bg_line
        Me.ClientSize = New System.Drawing.Size(432, 289)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.lblSave)
        Me.Controls.Add(Me.pboxSave)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.txtConfirmedpass)
        Me.Controls.Add(Me.lblConfirmedPass)
        Me.Controls.Add(Me.txtNewpassword)
        Me.Controls.Add(Me.lblNewpassword)
        Me.Controls.Add(Me.txtOldpassword)
        Me.Controls.Add(Me.lblOldpassword)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.lblUsername)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "FchangePassword"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FchangePassword"
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pboxSave, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblUsername As System.Windows.Forms.Label
    Friend WithEvents txtUsername As System.Windows.Forms.TextBox
    Friend WithEvents lblOldpassword As System.Windows.Forms.Label
    Friend WithEvents txtOldpassword As System.Windows.Forms.TextBox
    Friend WithEvents lblNewpassword As System.Windows.Forms.Label
    Friend WithEvents txtNewpassword As System.Windows.Forms.TextBox
    Friend WithEvents lblConfirmedPass As System.Windows.Forms.Label
    Friend WithEvents txtConfirmedpass As System.Windows.Forms.TextBox
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents pboxSave As System.Windows.Forms.PictureBox
    Friend WithEvents lblSave As System.Windows.Forms.Label
    Friend WithEvents btnExit As System.Windows.Forms.Button
End Class
