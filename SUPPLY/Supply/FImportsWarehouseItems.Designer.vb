<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FImportsWarehouseItems
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
        Me.ListSheets = New System.Windows.Forms.ListBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.lvlView = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader5 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader6 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader7 = New System.Windows.Forms.ColumnHeader
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.Button3 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'ListSheets
        '
        Me.ListSheets.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ListSheets.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListSheets.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListSheets.ForeColor = System.Drawing.Color.Black
        Me.ListSheets.FormattingEnabled = True
        Me.ListSheets.ItemHeight = 22
        Me.ListSheets.Location = New System.Drawing.Point(148, 34)
        Me.ListSheets.Name = "ListSheets"
        Me.ListSheets.Size = New System.Drawing.Size(203, 112)
        Me.ListSheets.TabIndex = 5
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(12, 35)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(130, 51)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "OPEN EXCEL FILE"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 92)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(130, 52)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "IMPORT FILES"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lvlView
        '
        Me.lvlView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7})
        Me.lvlView.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvlView.FullRowSelect = True
        Me.lvlView.GridLines = True
        Me.lvlView.HideSelection = False
        Me.lvlView.Location = New System.Drawing.Point(14, 160)
        Me.lvlView.Name = "lvlView"
        Me.lvlView.Size = New System.Drawing.Size(1174, 401)
        Me.lvlView.TabIndex = 10
        Me.lvlView.UseCompatibleStateImageBehavior = False
        Me.lvlView.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "wh_id"
        Me.ColumnHeader1.Width = 100
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Item"
        Me.ColumnHeader2.Width = 194
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Classification"
        Me.ColumnHeader3.Width = 213
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Warehouse Area"
        Me.ColumnHeader4.Width = 160
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Specific Location"
        Me.ColumnHeader5.Width = 161
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "In-Charge"
        Me.ColumnHeader6.Width = 150
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Re-Order Point"
        Me.ColumnHeader7.Width = 180
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(1056, 102)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(130, 52)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "VIEW"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'FImportsWarehouseItems
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SUPPLY.My.Resources.Resources.bg_line
        Me.ClientSize = New System.Drawing.Size(1201, 573)
        Me.Controls.Add(Me.lvlView)
        Me.Controls.Add(Me.ListSheets)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button1)
        Me.Name = "FImportsWarehouseItems"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "FImportsWarehouseItems"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ListSheets As System.Windows.Forms.ListBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lvlView As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Button3 As System.Windows.Forms.Button
End Class
