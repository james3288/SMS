<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FAggregates_Exemption
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
        Me.lvl_agg_excemption = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'lvl_agg_excemption
        '
        Me.lvl_agg_excemption.CheckBoxes = True
        Me.lvl_agg_excemption.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.lvl_agg_excemption.HideSelection = False
        Me.lvl_agg_excemption.Location = New System.Drawing.Point(12, 12)
        Me.lvl_agg_excemption.Name = "lvl_agg_excemption"
        Me.lvl_agg_excemption.Size = New System.Drawing.Size(422, 583)
        Me.lvl_agg_excemption.TabIndex = 0
        Me.lvl_agg_excemption.UseCompatibleStateImageBehavior = False
        Me.lvl_agg_excemption.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Item Name"
        Me.ColumnHeader1.Width = 176
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Item Description"
        Me.ColumnHeader2.Width = 240
        '
        'FAggregates_Exemption
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(448, 639)
        Me.Controls.Add(Me.lvl_agg_excemption)
        Me.Name = "FAggregates_Exemption"
        Me.Text = "FAggregates_Exemption"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lvl_agg_excemption As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
End Class
