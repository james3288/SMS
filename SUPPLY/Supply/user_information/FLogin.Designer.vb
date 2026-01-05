<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FLogin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FLogin))
        Me.lblCancel = New System.Windows.Forms.Label()
        Me.lblSignIn = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.lblChngePw = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pboxIconPw = New System.Windows.Forms.PictureBox()
        Me.pboxIconUname = New System.Windows.Forms.PictureBox()
        Me.pboxCancel = New System.Windows.Forms.PictureBox()
        Me.pboxSignIn = New System.Windows.Forms.PictureBox()
        Me.pboxPw = New System.Windows.Forms.PictureBox()
        Me.pboxUname = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.loadingPanel = New System.Windows.Forms.Panel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.PictureBox21 = New System.Windows.Forms.PictureBox()
        CType(Me.pboxIconPw, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pboxIconUname, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pboxCancel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pboxSignIn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pboxPw, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pboxUname, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.loadingPanel.SuspendLayout()
        CType(Me.PictureBox21, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblCancel
        '
        Me.lblCancel.AutoSize = True
        Me.lblCancel.BackColor = System.Drawing.Color.Transparent
        Me.lblCancel.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCancel.Location = New System.Drawing.Point(394, 264)
        Me.lblCancel.Name = "lblCancel"
        Me.lblCancel.Size = New System.Drawing.Size(51, 20)
        Me.lblCancel.TabIndex = 23
        Me.lblCancel.Text = "Cancel"
        '
        'lblSignIn
        '
        Me.lblSignIn.AutoSize = True
        Me.lblSignIn.BackColor = System.Drawing.Color.Transparent
        Me.lblSignIn.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSignIn.Location = New System.Drawing.Point(269, 264)
        Me.lblSignIn.Name = "lblSignIn"
        Me.lblSignIn.Size = New System.Drawing.Size(54, 20)
        Me.lblSignIn.TabIndex = 24
        Me.lblSignIn.Text = "Sign In"
        '
        'txtPassword
        '
        Me.txtPassword.BackColor = System.Drawing.Color.White
        Me.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.ForeColor = System.Drawing.Color.Gray
        Me.txtPassword.Location = New System.Drawing.Point(117, 206)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(364, 24)
        Me.txtPassword.TabIndex = 22
        Me.txtPassword.Text = "Password"
        '
        'txtUsername
        '
        Me.txtUsername.BackColor = System.Drawing.Color.White
        Me.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtUsername.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsername.ForeColor = System.Drawing.Color.Gray
        Me.txtUsername.Location = New System.Drawing.Point(117, 156)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(364, 24)
        Me.txtUsername.TabIndex = 21
        Me.txtUsername.Text = "Username"
        '
        'lblChngePw
        '
        Me.lblChngePw.AutoSize = True
        Me.lblChngePw.BackColor = System.Drawing.Color.Transparent
        Me.lblChngePw.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChngePw.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.lblChngePw.Location = New System.Drawing.Point(77, 266)
        Me.lblChngePw.Name = "lblChngePw"
        Me.lblChngePw.Size = New System.Drawing.Size(58, 16)
        Me.lblChngePw.TabIndex = 16
        Me.lblChngePw.Text = "Register"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.YellowGreen
        Me.Label2.Location = New System.Drawing.Point(184, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(315, 20)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Just sign in and we’ll send you on your way! "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(181, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(193, 37)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "SMS Log-in"
        '
        'pboxIconPw
        '
        Me.pboxIconPw.BackColor = System.Drawing.Color.Transparent
        Me.pboxIconPw.BackgroundImage = CType(resources.GetObject("pboxIconPw.BackgroundImage"), System.Drawing.Image)
        Me.pboxIconPw.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.pboxIconPw.Location = New System.Drawing.Point(91, 205)
        Me.pboxIconPw.Name = "pboxIconPw"
        Me.pboxIconPw.Size = New System.Drawing.Size(22, 26)
        Me.pboxIconPw.TabIndex = 20
        Me.pboxIconPw.TabStop = False
        '
        'pboxIconUname
        '
        Me.pboxIconUname.BackColor = System.Drawing.Color.Transparent
        Me.pboxIconUname.BackgroundImage = CType(resources.GetObject("pboxIconUname.BackgroundImage"), System.Drawing.Image)
        Me.pboxIconUname.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.pboxIconUname.Location = New System.Drawing.Point(91, 155)
        Me.pboxIconUname.Name = "pboxIconUname"
        Me.pboxIconUname.Size = New System.Drawing.Size(22, 26)
        Me.pboxIconUname.TabIndex = 19
        Me.pboxIconUname.TabStop = False
        '
        'pboxCancel
        '
        Me.pboxCancel.BackColor = System.Drawing.Color.Transparent
        Me.pboxCancel.BackgroundImage = CType(resources.GetObject("pboxCancel.BackgroundImage"), System.Drawing.Image)
        Me.pboxCancel.Location = New System.Drawing.Point(362, 254)
        Me.pboxCancel.Name = "pboxCancel"
        Me.pboxCancel.Size = New System.Drawing.Size(121, 37)
        Me.pboxCancel.TabIndex = 15
        Me.pboxCancel.TabStop = False
        '
        'pboxSignIn
        '
        Me.pboxSignIn.BackColor = System.Drawing.Color.Transparent
        Me.pboxSignIn.BackgroundImage = CType(resources.GetObject("pboxSignIn.BackgroundImage"), System.Drawing.Image)
        Me.pboxSignIn.Location = New System.Drawing.Point(234, 254)
        Me.pboxSignIn.Name = "pboxSignIn"
        Me.pboxSignIn.Size = New System.Drawing.Size(121, 37)
        Me.pboxSignIn.TabIndex = 14
        Me.pboxSignIn.TabStop = False
        '
        'pboxPw
        '
        Me.pboxPw.BackColor = System.Drawing.Color.Transparent
        Me.pboxPw.BackgroundImage = CType(resources.GetObject("pboxPw.BackgroundImage"), System.Drawing.Image)
        Me.pboxPw.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.pboxPw.Location = New System.Drawing.Point(80, 197)
        Me.pboxPw.Name = "pboxPw"
        Me.pboxPw.Size = New System.Drawing.Size(403, 42)
        Me.pboxPw.TabIndex = 13
        Me.pboxPw.TabStop = False
        '
        'pboxUname
        '
        Me.pboxUname.BackColor = System.Drawing.Color.Transparent
        Me.pboxUname.BackgroundImage = CType(resources.GetObject("pboxUname.BackgroundImage"), System.Drawing.Image)
        Me.pboxUname.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.pboxUname.Location = New System.Drawing.Point(80, 147)
        Me.pboxUname.Name = "pboxUname"
        Me.pboxUname.Size = New System.Drawing.Size(403, 42)
        Me.pboxUname.TabIndex = 12
        Me.pboxUname.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PictureBox1.Location = New System.Drawing.Point(12, 29)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(120, 112)
        Me.PictureBox1.TabIndex = 11
        Me.PictureBox1.TabStop = False
        '
        'loadingPanel
        '
        Me.loadingPanel.BackColor = System.Drawing.Color.Transparent
        Me.loadingPanel.Controls.Add(Me.Label12)
        Me.loadingPanel.Controls.Add(Me.PictureBox21)
        Me.loadingPanel.Location = New System.Drawing.Point(138, 95)
        Me.loadingPanel.Name = "loadingPanel"
        Me.loadingPanel.Size = New System.Drawing.Size(374, 42)
        Me.loadingPanel.TabIndex = 422
        Me.loadingPanel.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(43, 11)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(204, 19)
        Me.Label12.TabIndex = 1
        Me.Label12.Text = "Fetching data, please wait..."
        '
        'PictureBox21
        '
        Me.PictureBox21.Image = Global.SUPPLY.My.Resources.Resources.spinner
        Me.PictureBox21.Location = New System.Drawing.Point(4, 5)
        Me.PictureBox21.Name = "PictureBox21"
        Me.PictureBox21.Size = New System.Drawing.Size(33, 33)
        Me.PictureBox21.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox21.TabIndex = 0
        Me.PictureBox21.TabStop = False
        '
        'FLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SUPPLY.My.Resources.Resources.login_bg_01
        Me.ClientSize = New System.Drawing.Size(524, 311)
        Me.Controls.Add(Me.loadingPanel)
        Me.Controls.Add(Me.lblCancel)
        Me.Controls.Add(Me.lblSignIn)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.pboxIconPw)
        Me.Controls.Add(Me.pboxIconUname)
        Me.Controls.Add(Me.lblChngePw)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pboxCancel)
        Me.Controls.Add(Me.pboxSignIn)
        Me.Controls.Add(Me.pboxPw)
        Me.Controls.Add(Me.pboxUname)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "FLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FLogin"
        CType(Me.pboxIconPw, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pboxIconUname, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pboxCancel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pboxSignIn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pboxPw, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pboxUname, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.loadingPanel.ResumeLayout(False)
        Me.loadingPanel.PerformLayout()
        CType(Me.PictureBox21, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblCancel As System.Windows.Forms.Label
    Friend WithEvents lblSignIn As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtUsername As System.Windows.Forms.TextBox
    Friend WithEvents pboxIconPw As System.Windows.Forms.PictureBox
    Friend WithEvents pboxIconUname As System.Windows.Forms.PictureBox
    Friend WithEvents lblChngePw As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pboxCancel As System.Windows.Forms.PictureBox
    Friend WithEvents pboxSignIn As System.Windows.Forms.PictureBox
    Friend WithEvents pboxPw As System.Windows.Forms.PictureBox
    Friend WithEvents pboxUname As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents loadingPanel As Panel
    Friend WithEvents Label12 As Label
    Friend WithEvents PictureBox21 As PictureBox
End Class
