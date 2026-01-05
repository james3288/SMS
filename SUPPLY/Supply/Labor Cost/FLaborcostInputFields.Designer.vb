<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FLaborcostInputFields
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FLaborcostInputFields))
        Me.pboxHeader = New System.Windows.Forms.PictureBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmb_projdesc = New System.Windows.Forms.ComboBox()
        Me.cmb_category = New System.Windows.Forms.ComboBox()
        Me.txt_amount = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtp_datefrom = New System.Windows.Forms.DateTimePicker()
        Me.dtp_dateto = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btn_save = New System.Windows.Forms.Button()
        CType(Me.pboxHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pboxHeader
        '
        Me.pboxHeader.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.pboxHeader.BackgroundImage = CType(resources.GetObject("pboxHeader.BackgroundImage"), System.Drawing.Image)
        Me.pboxHeader.InitialImage = Nothing
        Me.pboxHeader.Location = New System.Drawing.Point(-2, -1)
        Me.pboxHeader.Name = "pboxHeader"
        Me.pboxHeader.Size = New System.Drawing.Size(258, 41)
        Me.pboxHeader.TabIndex = 385
        Me.pboxHeader.TabStop = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.BackgroundImage = Global.SUPPLY.My.Resources.Resources.close_button
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(215, 7)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(23, 22)
        Me.Button1.TabIndex = 388
        Me.Button1.UseVisualStyleBackColor = False
        '
        'cmb_projdesc
        '
        Me.cmb_projdesc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_projdesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_projdesc.FormattingEnabled = True
        Me.cmb_projdesc.Location = New System.Drawing.Point(23, 88)
        Me.cmb_projdesc.Name = "cmb_projdesc"
        Me.cmb_projdesc.Size = New System.Drawing.Size(208, 24)
        Me.cmb_projdesc.TabIndex = 1
        '
        'cmb_category
        '
        Me.cmb_category.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_category.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_category.FormattingEnabled = True
        Me.cmb_category.Items.AddRange(New Object() {"Labor", "Temp. Facilities", "Subsidenced Allowance", "Material Testing"})
        Me.cmb_category.Location = New System.Drawing.Point(23, 146)
        Me.cmb_category.Name = "cmb_category"
        Me.cmb_category.Size = New System.Drawing.Size(208, 24)
        Me.cmb_category.TabIndex = 2
        '
        'txt_amount
        '
        Me.txt_amount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_amount.Location = New System.Drawing.Point(23, 204)
        Me.txt_amount.Name = "txt_amount"
        Me.txt_amount.Size = New System.Drawing.Size(208, 22)
        Me.txt_amount.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(20, 69)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 16)
        Me.Label1.TabIndex = 392
        Me.Label1.Text = "Project Description"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(20, 127)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 16)
        Me.Label2.TabIndex = 393
        Me.Label2.Text = "Category"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(20, 185)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 16)
        Me.Label3.TabIndex = 394
        Me.Label3.Text = "Amount"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(20, 241)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 16)
        Me.Label4.TabIndex = 395
        Me.Label4.Text = "Date From"
        '
        'dtp_datefrom
        '
        Me.dtp_datefrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_datefrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_datefrom.Location = New System.Drawing.Point(23, 260)
        Me.dtp_datefrom.Name = "dtp_datefrom"
        Me.dtp_datefrom.Size = New System.Drawing.Size(208, 22)
        Me.dtp_datefrom.TabIndex = 4
        '
        'dtp_dateto
        '
        Me.dtp_dateto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_dateto.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_dateto.Location = New System.Drawing.Point(23, 316)
        Me.dtp_dateto.Name = "dtp_dateto"
        Me.dtp_dateto.Size = New System.Drawing.Size(208, 22)
        Me.dtp_dateto.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(20, 297)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 16)
        Me.Label5.TabIndex = 397
        Me.Label5.Text = "Date To"
        '
        'btn_save
        '
        Me.btn_save.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_save.Location = New System.Drawing.Point(153, 344)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(78, 40)
        Me.btn_save.TabIndex = 6
        Me.btn_save.Text = "Save"
        Me.btn_save.UseVisualStyleBackColor = True
        '
        'FLaborcostInputFields
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SUPPLY.My.Resources.Resources.bg_line
        Me.ClientSize = New System.Drawing.Size(255, 395)
        Me.Controls.Add(Me.btn_save)
        Me.Controls.Add(Me.dtp_dateto)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.dtp_datefrom)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txt_amount)
        Me.Controls.Add(Me.cmb_category)
        Me.Controls.Add(Me.cmb_projdesc)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.pboxHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FLaborcostInputFields"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FLaborcostInputFields"
        Me.TopMost = True
        CType(Me.pboxHeader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pboxHeader As PictureBox
    Friend WithEvents Button1 As Button
    Friend WithEvents cmb_projdesc As ComboBox
    Friend WithEvents cmb_category As ComboBox
    Friend WithEvents txt_amount As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents dtp_datefrom As DateTimePicker
    Friend WithEvents dtp_dateto As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents btn_save As Button
End Class
