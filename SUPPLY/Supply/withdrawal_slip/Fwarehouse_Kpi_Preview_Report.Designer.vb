<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fwarehouse_Kpi_Preview_Report
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lblTitleHeader = New System.Windows.Forms.Label()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnsubmit = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lvlPreviewMovingCatReport = New System.Windows.Forms.ListView()
        Me.lvlPreviewTypeRequestReport = New System.Windows.Forms.ListView()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.lblTitleHeader)
        Me.Panel1.Controls.Add(Me.btnExit)
        Me.Panel1.Location = New System.Drawing.Point(9, 11)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(965, 42)
        Me.Panel1.TabIndex = 362
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.BackgroundImage = Global.SUPPLY.My.Resources.Resources.close_button
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(929, 6)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(28, 28)
        Me.Button1.TabIndex = 357
        Me.Button1.UseVisualStyleBackColor = False
        '
        'lblTitleHeader
        '
        Me.lblTitleHeader.AutoSize = True
        Me.lblTitleHeader.BackColor = System.Drawing.Color.Transparent
        Me.lblTitleHeader.Font = New System.Drawing.Font("Bombardier", 17.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitleHeader.ForeColor = System.Drawing.Color.White
        Me.lblTitleHeader.Location = New System.Drawing.Point(317, 6)
        Me.lblTitleHeader.Name = "lblTitleHeader"
        Me.lblTitleHeader.Size = New System.Drawing.Size(295, 25)
        Me.lblTitleHeader.TabIndex = 356
        Me.lblTitleHeader.Text = "WITHDRAWAL PREVIEW REPORT"
        Me.lblTitleHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.Transparent
        Me.btnExit.BackgroundImage = Global.SUPPLY.My.Resources.Resources.close_button
        Me.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnExit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExit.FlatAppearance.BorderSize = 0
        Me.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit.Location = New System.Drawing.Point(1581, 6)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(28, 28)
        Me.btnExit.TabIndex = 355
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.btnsubmit)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.lvlPreviewMovingCatReport)
        Me.Panel2.Controls.Add(Me.lvlPreviewTypeRequestReport)
        Me.Panel2.Controls.Add(Me.Button3)
        Me.Panel2.Location = New System.Drawing.Point(9, 60)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(965, 646)
        Me.Panel2.TabIndex = 363
        '
        'btnsubmit
        '
        Me.btnsubmit.Font = New System.Drawing.Font("Bombardier", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsubmit.ForeColor = System.Drawing.Color.White
        Me.btnsubmit.Location = New System.Drawing.Point(382, 596)
        Me.btnsubmit.Name = "btnsubmit"
        Me.btnsubmit.Size = New System.Drawing.Size(176, 40)
        Me.btnsubmit.TabIndex = 363
        Me.btnsubmit.Text = "Preview Report"
        Me.btnsubmit.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Bombardier", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(392, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(162, 22)
        Me.Label2.TabIndex = 359
        Me.Label2.Text = "TYPE OF REQUEST"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Bombardier", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(390, 315)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(161, 22)
        Me.Label1.TabIndex = 358
        Me.Label1.Text = "MOVING CATEGORY"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lvlPreviewMovingCatReport
        '
        Me.lvlPreviewMovingCatReport.Font = New System.Drawing.Font("Bombardier", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvlPreviewMovingCatReport.FullRowSelect = True
        Me.lvlPreviewMovingCatReport.GridLines = True
        Me.lvlPreviewMovingCatReport.Location = New System.Drawing.Point(6, 341)
        Me.lvlPreviewMovingCatReport.Name = "lvlPreviewMovingCatReport"
        Me.lvlPreviewMovingCatReport.Size = New System.Drawing.Size(951, 246)
        Me.lvlPreviewMovingCatReport.TabIndex = 357
        Me.lvlPreviewMovingCatReport.UseCompatibleStateImageBehavior = False
        Me.lvlPreviewMovingCatReport.View = System.Windows.Forms.View.Details
        '
        'lvlPreviewTypeRequestReport
        '
        Me.lvlPreviewTypeRequestReport.Font = New System.Drawing.Font("Bombardier", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvlPreviewTypeRequestReport.FullRowSelect = True
        Me.lvlPreviewTypeRequestReport.GridLines = True
        Me.lvlPreviewTypeRequestReport.Location = New System.Drawing.Point(6, 41)
        Me.lvlPreviewTypeRequestReport.Name = "lvlPreviewTypeRequestReport"
        Me.lvlPreviewTypeRequestReport.Size = New System.Drawing.Size(951, 246)
        Me.lvlPreviewTypeRequestReport.TabIndex = 356
        Me.lvlPreviewTypeRequestReport.UseCompatibleStateImageBehavior = False
        Me.lvlPreviewTypeRequestReport.View = System.Windows.Forms.View.Details
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Transparent
        Me.Button3.BackgroundImage = Global.SUPPLY.My.Resources.Resources.close_button
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Location = New System.Drawing.Point(1581, 6)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(28, 28)
        Me.Button3.TabIndex = 355
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Fwarehouse_Kpi_Preview_Report
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SUPPLY.My.Resources.Resources.bg_line
        Me.ClientSize = New System.Drawing.Size(982, 716)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Fwarehouse_Kpi_Preview_Report"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Fwarehouse_Kpi_Preview_Report"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents lblTitleHeader As Label
    Friend WithEvents btnExit As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnsubmit As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lvlPreviewMovingCatReport As ListView
    Friend WithEvents lvlPreviewTypeRequestReport As ListView
    Friend WithEvents Button3 As Button
End Class
