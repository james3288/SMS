<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FAccidentReport_page2
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
        Me.gboxRootCauseAnalysis = New System.Windows.Forms.GroupBox()
        Me.lvlManagementSysDef = New System.Windows.Forms.ListView()
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvlUnsafeConditions = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvlUnsafeActs = New System.Windows.Forms.ListView()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.panel_RootCauseAnalysis = New System.Windows.Forms.Panel()
        Me.lblRootCauseAnalysis = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.gboxRootCauseAnalysis.SuspendLayout()
        Me.panel_RootCauseAnalysis.SuspendLayout()
        Me.SuspendLayout()
        '
        'gboxRootCauseAnalysis
        '
        Me.gboxRootCauseAnalysis.BackColor = System.Drawing.Color.Transparent
        Me.gboxRootCauseAnalysis.Controls.Add(Me.lvlManagementSysDef)
        Me.gboxRootCauseAnalysis.Controls.Add(Me.lvlUnsafeConditions)
        Me.gboxRootCauseAnalysis.Controls.Add(Me.lvlUnsafeActs)
        Me.gboxRootCauseAnalysis.Controls.Add(Me.panel_RootCauseAnalysis)
        Me.gboxRootCauseAnalysis.Location = New System.Drawing.Point(7, 7)
        Me.gboxRootCauseAnalysis.Name = "gboxRootCauseAnalysis"
        Me.gboxRootCauseAnalysis.Size = New System.Drawing.Size(1093, 565)
        Me.gboxRootCauseAnalysis.TabIndex = 5
        Me.gboxRootCauseAnalysis.TabStop = False
        '
        'lvlManagementSysDef
        '
        Me.lvlManagementSysDef.CheckBoxes = True
        Me.lvlManagementSysDef.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader2})
        Me.lvlManagementSysDef.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvlManagementSysDef.GridLines = True
        Me.lvlManagementSysDef.Location = New System.Drawing.Point(728, 52)
        Me.lvlManagementSysDef.Name = "lvlManagementSysDef"
        Me.lvlManagementSysDef.Size = New System.Drawing.Size(355, 493)
        Me.lvlManagementSysDef.TabIndex = 384
        Me.lvlManagementSysDef.UseCompatibleStateImageBehavior = False
        Me.lvlManagementSysDef.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Management System Deficiencies"
        Me.ColumnHeader2.Width = 350
        '
        'lvlUnsafeConditions
        '
        Me.lvlUnsafeConditions.CheckBoxes = True
        Me.lvlUnsafeConditions.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.lvlUnsafeConditions.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvlUnsafeConditions.GridLines = True
        Me.lvlUnsafeConditions.Location = New System.Drawing.Point(367, 52)
        Me.lvlUnsafeConditions.Name = "lvlUnsafeConditions"
        Me.lvlUnsafeConditions.Size = New System.Drawing.Size(355, 493)
        Me.lvlUnsafeConditions.TabIndex = 383
        Me.lvlUnsafeConditions.UseCompatibleStateImageBehavior = False
        Me.lvlUnsafeConditions.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Unsafe Conditions"
        Me.ColumnHeader1.Width = 350
        '
        'lvlUnsafeActs
        '
        Me.lvlUnsafeActs.CheckBoxes = True
        Me.lvlUnsafeActs.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3})
        Me.lvlUnsafeActs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvlUnsafeActs.GridLines = True
        Me.lvlUnsafeActs.Location = New System.Drawing.Point(6, 52)
        Me.lvlUnsafeActs.Name = "lvlUnsafeActs"
        Me.lvlUnsafeActs.Size = New System.Drawing.Size(355, 493)
        Me.lvlUnsafeActs.TabIndex = 382
        Me.lvlUnsafeActs.UseCompatibleStateImageBehavior = False
        Me.lvlUnsafeActs.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Unsafe Acts"
        Me.ColumnHeader3.Width = 350
        '
        'panel_RootCauseAnalysis
        '
        Me.panel_RootCauseAnalysis.BackgroundImage = Global.SUPPLY.My.Resources.Resources.header_line
        Me.panel_RootCauseAnalysis.Controls.Add(Me.lblRootCauseAnalysis)
        Me.panel_RootCauseAnalysis.Location = New System.Drawing.Point(3, 8)
        Me.panel_RootCauseAnalysis.Name = "panel_RootCauseAnalysis"
        Me.panel_RootCauseAnalysis.Size = New System.Drawing.Size(1086, 38)
        Me.panel_RootCauseAnalysis.TabIndex = 381
        '
        'lblRootCauseAnalysis
        '
        Me.lblRootCauseAnalysis.AutoSize = True
        Me.lblRootCauseAnalysis.BackColor = System.Drawing.Color.Transparent
        Me.lblRootCauseAnalysis.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRootCauseAnalysis.ForeColor = System.Drawing.Color.White
        Me.lblRootCauseAnalysis.Location = New System.Drawing.Point(432, 12)
        Me.lblRootCauseAnalysis.Name = "lblRootCauseAnalysis"
        Me.lblRootCauseAnalysis.Size = New System.Drawing.Size(198, 19)
        Me.lblRootCauseAnalysis.TabIndex = 377
        Me.lblRootCauseAnalysis.Text = "ROOT CAUSE ANALYSIS"
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(7, 578)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(147, 32)
        Me.btnSave.TabIndex = 6
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'FAccidentReport_page2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SUPPLY.My.Resources.Resources.bg_line
        Me.ClientSize = New System.Drawing.Size(1109, 622)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.gboxRootCauseAnalysis)
        Me.Name = "FAccidentReport_page2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FAccidentReport_page2"
        Me.gboxRootCauseAnalysis.ResumeLayout(False)
        Me.panel_RootCauseAnalysis.ResumeLayout(False)
        Me.panel_RootCauseAnalysis.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gboxRootCauseAnalysis As GroupBox
    Friend WithEvents lvlUnsafeActs As ListView
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents panel_RootCauseAnalysis As Panel
    Friend WithEvents lblRootCauseAnalysis As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents lvlManagementSysDef As ListView
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents lvlUnsafeConditions As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
End Class
