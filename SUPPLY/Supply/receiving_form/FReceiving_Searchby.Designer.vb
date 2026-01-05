<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FReceiving_Searchby
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FReceiving_Searchby))
        Me.pboxHeader = New System.Windows.Forms.PictureBox()
        Me.btnExit_panel_duration = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmbCharges = New System.Windows.Forms.ComboBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpto = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpfrom = New System.Windows.Forms.DateTimePicker()
        Me.cmbMode = New System.Windows.Forms.ComboBox()
        Me.txtItem = New System.Windows.Forms.TextBox()
        CType(Me.pboxHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'pboxHeader
        '
        Me.pboxHeader.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.pboxHeader.BackgroundImage = CType(resources.GetObject("pboxHeader.BackgroundImage"), System.Drawing.Image)
        Me.pboxHeader.InitialImage = Nothing
        Me.pboxHeader.Location = New System.Drawing.Point(0, 0)
        Me.pboxHeader.Name = "pboxHeader"
        Me.pboxHeader.Size = New System.Drawing.Size(328, 43)
        Me.pboxHeader.TabIndex = 326
        Me.pboxHeader.TabStop = False
        '
        'btnExit_panel_duration
        '
        Me.btnExit_panel_duration.BackColor = System.Drawing.Color.Transparent
        Me.btnExit_panel_duration.BackgroundImage = Global.SUPPLY.My.Resources.Resources.close_button
        Me.btnExit_panel_duration.FlatAppearance.BorderSize = 0
        Me.btnExit_panel_duration.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnExit_panel_duration.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnExit_panel_duration.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit_panel_duration.Location = New System.Drawing.Point(292, 10)
        Me.btnExit_panel_duration.Name = "btnExit_panel_duration"
        Me.btnExit_panel_duration.Size = New System.Drawing.Size(20, 20)
        Me.btnExit_panel_duration.TabIndex = 361
        Me.btnExit_panel_duration.UseVisualStyleBackColor = False
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(54, 49)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(233, 20)
        Me.txtSearch.TabIndex = 410
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.cmbCharges)
        Me.Panel1.Controls.Add(Me.btnSearch)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.cmbMode)
        Me.Panel1.Controls.Add(Me.txtItem)
        Me.Panel1.Controls.Add(Me.txtSearch)
        Me.Panel1.Location = New System.Drawing.Point(0, 49)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(317, 346)
        Me.Panel1.TabIndex = 412
        '
        'cmbCharges
        '
        Me.cmbCharges.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbCharges.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCharges.FormattingEnabled = True
        Me.cmbCharges.Location = New System.Drawing.Point(54, 8)
        Me.cmbCharges.Name = "cmbCharges"
        Me.cmbCharges.Size = New System.Drawing.Size(233, 24)
        Me.cmbCharges.TabIndex = 415
        '
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(54, 280)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(233, 36)
        Me.btnSearch.TabIndex = 414
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.BackgroundImage = Global.SUPPLY.My.Resources.Resources.bg_line
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.dtpto)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.dtpfrom)
        Me.GroupBox2.Enabled = False
        Me.GroupBox2.Location = New System.Drawing.Point(54, 154)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(233, 115)
        Me.GroupBox2.TabIndex = 413
        Me.GroupBox2.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(12, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(27, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "To:"
        '
        'dtpto
        '
        Me.dtpto.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpto.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpto.Location = New System.Drawing.Point(15, 77)
        Me.dtpto.Name = "dtpto"
        Me.dtpto.Size = New System.Drawing.Size(209, 22)
        Me.dtpto.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(12, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 16)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "From:"
        '
        'dtpfrom
        '
        Me.dtpfrom.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpfrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfrom.Location = New System.Drawing.Point(15, 34)
        Me.dtpfrom.Name = "dtpfrom"
        Me.dtpfrom.Size = New System.Drawing.Size(209, 22)
        Me.dtpfrom.TabIndex = 5
        '
        'cmbMode
        '
        Me.cmbMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbMode.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMode.FormattingEnabled = True
        Me.cmbMode.Items.AddRange(New Object() {"ENABLE", "DISABLE"})
        Me.cmbMode.Location = New System.Drawing.Point(54, 124)
        Me.cmbMode.Name = "cmbMode"
        Me.cmbMode.Size = New System.Drawing.Size(233, 24)
        Me.cmbMode.TabIndex = 412
        '
        'txtItem
        '
        Me.txtItem.Location = New System.Drawing.Point(54, 87)
        Me.txtItem.Name = "txtItem"
        Me.txtItem.Size = New System.Drawing.Size(233, 20)
        Me.txtItem.TabIndex = 411
        '
        'FReceiving_Searchby
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SUPPLY.My.Resources.Resources.bg_line
        Me.ClientSize = New System.Drawing.Size(321, 407)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnExit_panel_duration)
        Me.Controls.Add(Me.pboxHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FReceiving_Searchby"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FReceiving_Searchby"
        CType(Me.pboxHeader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pboxHeader As PictureBox
    Friend WithEvents btnExit_panel_duration As Button
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents txtItem As TextBox
    Friend WithEvents cmbMode As ComboBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents dtpto As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents dtpfrom As DateTimePicker
    Friend WithEvents btnSearch As Button
    Friend WithEvents cmbCharges As ComboBox
End Class
