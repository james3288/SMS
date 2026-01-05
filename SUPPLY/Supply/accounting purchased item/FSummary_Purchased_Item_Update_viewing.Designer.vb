<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FSummary_Purchased_Item_Update_viewing
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
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.DS_PurchasedUpdateBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSet_Purchased_Items_Update = New SUPPLY.DataSet_Purchased_Items_Update()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        CType(Me.DS_PurchasedUpdateBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet_Purchased_Items_Update, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DS_PurchasedUpdateBindingSource
        '
        Me.DS_PurchasedUpdateBindingSource.DataMember = "DS_PurchasedUpdate"
        Me.DS_PurchasedUpdateBindingSource.DataSource = Me.DataSet_Purchased_Items_Update
        '
        'DataSet_Purchased_Items_Update
        '
        Me.DataSet_Purchased_Items_Update.DataSetName = "DataSet_Purchased_Items_Update"
        Me.DataSet_Purchased_Items_Update.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DataSet1"
        ReportDataSource1.Value = Me.DS_PurchasedUpdateBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "SUPPLY.Report_Purchased_Item_Update.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(763, 449)
        Me.ReportViewer1.TabIndex = 0
        '
        'FSummary_Purchased_Item_Update_viewing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(763, 449)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "FSummary_Purchased_Item_Update_viewing"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Report"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DS_PurchasedUpdateBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet_Purchased_Items_Update, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents DS_PurchasedUpdateBindingSource As BindingSource
    Friend WithEvents DataSet_Purchased_Items_Update As DataSet_Purchased_Items_Update
End Class
