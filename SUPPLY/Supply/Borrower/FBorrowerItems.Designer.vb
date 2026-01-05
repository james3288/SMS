<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FBorrowerItems
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
        Me.lvlFacTools = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader5 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader6 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader7 = New System.Windows.Forms.ColumnHeader
        Me.lbl_Fac_tools = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'lvlFacTools
        '
        Me.lvlFacTools.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7})
        Me.lvlFacTools.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvlFacTools.FullRowSelect = True
        Me.lvlFacTools.GridLines = True
        Me.lvlFacTools.HideSelection = False
        Me.lvlFacTools.Location = New System.Drawing.Point(12, 14)
        Me.lvlFacTools.Name = "lvlFacTools"
        Me.lvlFacTools.Size = New System.Drawing.Size(894, 466)
        Me.lvlFacTools.TabIndex = 393
        Me.lvlFacTools.UseCompatibleStateImageBehavior = False
        Me.lvlFacTools.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "id"
        Me.ColumnHeader1.Width = 50
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Facilities/Tools"
        Me.ColumnHeader2.Width = 300
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Specification"
        Me.ColumnHeader3.Width = 216
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Remarks"
        Me.ColumnHeader4.Width = 200
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Available"
        Me.ColumnHeader5.Width = 73
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Borrowed"
        Me.ColumnHeader6.Width = 79
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Total # of Item"
        Me.ColumnHeader7.Width = 112
        '
        'lbl_Fac_tools
        '
        Me.lbl_Fac_tools.AutoSize = True
        Me.lbl_Fac_tools.Location = New System.Drawing.Point(1033, 56)
        Me.lbl_Fac_tools.Name = "lbl_Fac_tools"
        Me.lbl_Fac_tools.Size = New System.Drawing.Size(39, 13)
        Me.lbl_Fac_tools.TabIndex = 394
        Me.lbl_Fac_tools.Text = "Label1"
        '
        'FBorrowerItems
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(919, 492)
        Me.Controls.Add(Me.lbl_Fac_tools)
        Me.Controls.Add(Me.lvlFacTools)
        Me.Name = "FBorrowerItems"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FBorrowerItems"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lvlFacTools As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lbl_Fac_tools As System.Windows.Forms.Label
End Class
