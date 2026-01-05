<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FTireSerial
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FTireSerial))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnReleaseNow = New System.Windows.Forms.Button()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.txtSearchItems = New System.Windows.Forms.TextBox()
        Me.dgvTirePosition = New System.Windows.Forms.DataGridView()
        Me.debounce_new = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTirePosition, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = Global.SUPPLY.My.Resources.Resources.bg_line
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.btnReleaseNow)
        Me.Panel1.Controls.Add(Me.PictureBox3)
        Me.Panel1.Controls.Add(Me.txtSearchItems)
        Me.Panel1.Controls.Add(Me.dgvTirePosition)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(910, 416)
        Me.Panel1.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Bombardier", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.GreenYellow
        Me.Label4.Location = New System.Drawing.Point(45, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 16)
        Me.Label4.TabIndex = 509
        Me.Label4.Text = "SERIAL NO:"
        '
        'btnReleaseNow
        '
        Me.btnReleaseNow.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnReleaseNow.BackColor = System.Drawing.Color.YellowGreen
        Me.btnReleaseNow.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReleaseNow.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReleaseNow.Image = CType(resources.GetObject("btnReleaseNow.Image"), System.Drawing.Image)
        Me.btnReleaseNow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReleaseNow.Location = New System.Drawing.Point(734, 364)
        Me.btnReleaseNow.Name = "btnReleaseNow"
        Me.btnReleaseNow.Size = New System.Drawing.Size(166, 37)
        Me.btnReleaseNow.TabIndex = 417
        Me.btnReleaseNow.Text = "OK"
        Me.btnReleaseNow.UseVisualStyleBackColor = False
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.Image = Global.SUPPLY.My.Resources.Resources.spinner
        Me.PictureBox3.Location = New System.Drawing.Point(479, 19)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(33, 33)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 416
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'txtSearchItems
        '
        Me.txtSearchItems.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearchItems.Location = New System.Drawing.Point(185, 23)
        Me.txtSearchItems.Name = "txtSearchItems"
        Me.txtSearchItems.Size = New System.Drawing.Size(287, 26)
        Me.txtSearchItems.TabIndex = 17
        '
        'dgvTirePosition
        '
        Me.dgvTirePosition.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvTirePosition.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTirePosition.Location = New System.Drawing.Point(8, 59)
        Me.dgvTirePosition.Name = "dgvTirePosition"
        Me.dgvTirePosition.Size = New System.Drawing.Size(890, 292)
        Me.dgvTirePosition.TabIndex = 1
        '
        'debounce_new
        '
        Me.debounce_new.Interval = 500
        '
        'FTireSerial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(910, 416)
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.Name = "FTireSerial"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FTireSerial"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTirePosition, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents dgvTirePosition As DataGridView
    Friend WithEvents txtSearchItems As TextBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents btnReleaseNow As Button
    Friend WithEvents debounce_new As Timer
    Friend WithEvents Label4 As Label
End Class
