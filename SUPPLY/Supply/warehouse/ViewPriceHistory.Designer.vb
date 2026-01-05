<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewPriceHistory
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
        Me.lvlViewPriceHistory = New System.Windows.Forms.ListView()
        Me.wh_id = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Item_Name = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Item_description = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Date_Received = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Unit = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Unit_Price = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lblwh_id = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lvlViewPriceHistory
        '
        Me.lvlViewPriceHistory.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.wh_id, Me.Item_Name, Me.Item_description, Me.Date_Received, Me.Unit, Me.Unit_Price})
        Me.lvlViewPriceHistory.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvlViewPriceHistory.FullRowSelect = True
        Me.lvlViewPriceHistory.GridLines = True
        Me.lvlViewPriceHistory.HideSelection = False
        Me.lvlViewPriceHistory.Location = New System.Drawing.Point(12, 12)
        Me.lvlViewPriceHistory.Name = "lvlViewPriceHistory"
        Me.lvlViewPriceHistory.Size = New System.Drawing.Size(755, 389)
        Me.lvlViewPriceHistory.TabIndex = 1
        Me.lvlViewPriceHistory.UseCompatibleStateImageBehavior = False
        Me.lvlViewPriceHistory.View = System.Windows.Forms.View.Details
        '
        'wh_id
        '
        Me.wh_id.Text = "wh_id"
        Me.wh_id.Width = 50
        '
        'Item_Name
        '
        Me.Item_Name.Text = "Item Name"
        Me.Item_Name.Width = 150
        '
        'Item_description
        '
        Me.Item_description.Text = "Item Description"
        Me.Item_description.Width = 180
        '
        'Date_Received
        '
        Me.Date_Received.Text = "Date Received"
        Me.Date_Received.Width = 120
        '
        'Unit
        '
        Me.Unit.Text = "Unit"
        Me.Unit.Width = 100
        '
        'Unit_Price
        '
        Me.Unit_Price.Text = "Unit Price"
        Me.Unit_Price.Width = 150
        '
        'lblwh_id
        '
        Me.lblwh_id.AutoSize = True
        Me.lblwh_id.Location = New System.Drawing.Point(817, 51)
        Me.lblwh_id.Name = "lblwh_id"
        Me.lblwh_id.Size = New System.Drawing.Size(35, 13)
        Me.lblwh_id.TabIndex = 2
        Me.lblwh_id.Text = "wh_id"
        '
        'ViewPriceHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SUPPLY.My.Resources.Resources.bg_line
        Me.ClientSize = New System.Drawing.Size(779, 412)
        Me.Controls.Add(Me.lblwh_id)
        Me.Controls.Add(Me.lvlViewPriceHistory)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "ViewPriceHistory"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ViewPriceHistory"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lvlViewPriceHistory As ListView
    Friend WithEvents wh_id As ColumnHeader
    Friend WithEvents Item_Name As ColumnHeader
    Friend WithEvents Item_description As ColumnHeader
    Friend WithEvents Date_Received As ColumnHeader
    Friend WithEvents lblwh_id As Label
    Friend WithEvents Unit As ColumnHeader
    Friend WithEvents Unit_Price As ColumnHeader
End Class
