<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRequestorList
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
        Me.lvlProject = New System.Windows.Forms.ListView()
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lvlProject
        '
        Me.lvlProject.CheckBoxes = True
        Me.lvlProject.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader5})
        Me.lvlProject.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvlProject.FullRowSelect = True
        Me.lvlProject.Location = New System.Drawing.Point(12, 12)
        Me.lvlProject.Name = "lvlProject"
        Me.lvlProject.Size = New System.Drawing.Size(355, 386)
        Me.lvlProject.TabIndex = 9
        Me.lvlProject.UseCompatibleStateImageBehavior = False
        Me.lvlProject.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Projects"
        Me.ColumnHeader5.Width = 349
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 411)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(355, 34)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "Search"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'FRequestorList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(379, 459)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lvlProject)
        Me.Name = "FRequestorList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FRequestorList"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lvlProject As ListView
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents Button1 As Button
End Class
