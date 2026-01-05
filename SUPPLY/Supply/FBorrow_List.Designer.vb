<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FBorrow_List
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
        Me.dgBorrowList = New System.Windows.Forms.DataGridView
        Me.btnGenerate = New System.Windows.Forms.Button
        Me.Column1 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.ID1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.fac_tools_id = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgBorrowList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgBorrowList
        '
        Me.dgBorrowList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgBorrowList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.ID1, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.fac_tools_id})
        Me.dgBorrowList.Location = New System.Drawing.Point(12, 12)
        Me.dgBorrowList.Name = "dgBorrowList"
        Me.dgBorrowList.Size = New System.Drawing.Size(828, 349)
        Me.dgBorrowList.TabIndex = 387
        '
        'btnGenerate
        '
        Me.btnGenerate.Location = New System.Drawing.Point(674, 368)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(166, 38)
        Me.btnGenerate.TabIndex = 388
        Me.btnGenerate.Text = "Generate"
        Me.btnGenerate.UseVisualStyleBackColor = True
        '
        'Column1
        '
        Me.Column1.FillWeight = 1.0!
        Me.Column1.Frozen = True
        Me.Column1.HeaderText = "ID"
        Me.Column1.Name = "Column1"
        Me.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column1.Width = 30
        '
        'ID1
        '
        Me.ID1.HeaderText = "ID1"
        Me.ID1.Name = "ID1"
        Me.ID1.Width = 50
        '
        'Column3
        '
        Me.Column3.HeaderText = "Item Tye"
        Me.Column3.Name = "Column3"
        Me.Column3.Width = 200
        '
        'Column4
        '
        Me.Column4.HeaderText = "Item Desc."
        Me.Column4.Name = "Column4"
        Me.Column4.Width = 250
        '
        'Column5
        '
        Me.Column5.HeaderText = "Actual Qty"
        Me.Column5.Name = "Column5"
        '
        'Column6
        '
        Me.Column6.HeaderText = "No. of Qty borrow"
        Me.Column6.Name = "Column6"
        Me.Column6.Width = 150
        '
        'fac_tools_id
        '
        Me.fac_tools_id.HeaderText = "fac_tools_id"
        Me.fac_tools_id.Name = "fac_tools_id"
        '
        'FBorrow_List
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(850, 415)
        Me.Controls.Add(Me.btnGenerate)
        Me.Controls.Add(Me.dgBorrowList)
        Me.Name = "FBorrow_List"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FBorrow_List"
        CType(Me.dgBorrowList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgBorrowList As System.Windows.Forms.DataGridView
    Friend WithEvents btnGenerate As System.Windows.Forms.Button
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ID1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fac_tools_id As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
