<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FMonthlyProjectCost_Report
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
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.DTP_monthlyproject_costBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSet_monthlyProjectCost = New SUPPLY.DataSet_monthlyProjectCost()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        CType(Me.DTP_monthlyproject_costBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet_monthlyProjectCost, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DTP_monthlyproject_costBindingSource
        '
        Me.DTP_monthlyproject_costBindingSource.DataMember = "DTP_monthlyproject_cost"
        Me.DTP_monthlyproject_costBindingSource.DataSource = Me.DataSet_monthlyProjectCost
        '
        'DataSet_monthlyProjectCost
        '
        Me.DataSet_monthlyProjectCost.DataSetName = "DataSet_monthlyProjectCost"
        Me.DataSet_monthlyProjectCost.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DataSet"
        ReportDataSource1.Value = Me.DTP_monthlyproject_costBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "SUPPLY.Report_monthlyprojectcost.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(857, 478)
        Me.ReportViewer1.TabIndex = 0
        '
        'FMonthlyProjectCost_Report
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(857, 478)
        Me.Controls.Add(Me.ReportViewer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FMonthlyProjectCost_Report"
        Me.Text = "FMonthlyProjectCost_Report"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DTP_monthlyproject_costBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet_monthlyProjectCost, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents DTP_monthlyproject_costBindingSource As BindingSource
    Friend WithEvents DataSet_monthlyProjectCost As DataSet_monthlyProjectCost
End Class
