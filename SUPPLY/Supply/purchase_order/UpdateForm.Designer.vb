<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UpdateForm
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
        Me.cmbTypes = New System.Windows.Forms.ComboBox()
        Me.txtUnits = New System.Windows.Forms.TextBox()
        Me.btn_panelExt = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.txtQty = New System.Windows.Forms.TextBox()
        Me.panelTop = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.panelTop.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.panelTop)
        Me.Panel1.Controls.Add(Me.cmbTypes)
        Me.Panel1.Controls.Add(Me.txtUnits)
        Me.Panel1.Controls.Add(Me.btnUpdate)
        Me.Panel1.Controls.Add(Me.txtQty)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(315, 228)
        Me.Panel1.TabIndex = 0
        '
        'cmbTypes
        '
        Me.cmbTypes.FormattingEnabled = True
        Me.cmbTypes.Location = New System.Drawing.Point(62, 56)
        Me.cmbTypes.Name = "cmbTypes"
        Me.cmbTypes.Size = New System.Drawing.Size(222, 21)
        Me.cmbTypes.TabIndex = 364
        '
        'txtUnits
        '
        Me.txtUnits.Location = New System.Drawing.Point(62, 146)
        Me.txtUnits.Name = "txtUnits"
        Me.txtUnits.Size = New System.Drawing.Size(222, 20)
        Me.txtUnits.TabIndex = 363
        '
        'btn_panelExt
        '
        Me.btn_panelExt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_panelExt.BackColor = System.Drawing.Color.Transparent
        Me.btn_panelExt.BackgroundImage = Global.SUPPLY.My.Resources.Resources.close_button
        Me.btn_panelExt.FlatAppearance.BorderSize = 0
        Me.btn_panelExt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btn_panelExt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btn_panelExt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_panelExt.Location = New System.Drawing.Point(286, 4)
        Me.btn_panelExt.Name = "btn_panelExt"
        Me.btn_panelExt.Size = New System.Drawing.Size(22, 22)
        Me.btn_panelExt.TabIndex = 362
        Me.btn_panelExt.UseVisualStyleBackColor = False
        '
        'btnUpdate
        '
        Me.btnUpdate.FlatAppearance.BorderSize = 0
        Me.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpdate.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.Location = New System.Drawing.Point(180, 183)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(106, 31)
        Me.btnUpdate.TabIndex = 1
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'txtQty
        '
        Me.txtQty.Location = New System.Drawing.Point(62, 103)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.Size = New System.Drawing.Size(222, 20)
        Me.txtQty.TabIndex = 0
        '
        'panelTop
        '
        Me.panelTop.Controls.Add(Me.btn_panelExt)
        Me.panelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelTop.Location = New System.Drawing.Point(0, 0)
        Me.panelTop.Name = "panelTop"
        Me.panelTop.Size = New System.Drawing.Size(315, 30)
        Me.panelTop.TabIndex = 365
        '
        'UpdateForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(315, 228)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "UpdateForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "UpdateForm"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.panelTop.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnUpdate As Button
    Friend WithEvents txtQty As TextBox
    Friend WithEvents btn_panelExt As Button
    Friend WithEvents txtUnits As TextBox
    Friend WithEvents cmbTypes As ComboBox
    Friend WithEvents panelTop As Panel
End Class
