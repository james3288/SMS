<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Service_Provider_Evaluation_ReportForm
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
        Me.dt_risk_proj_equp_otherBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSet_Summary_Progress_Report_Revised = New SUPPLY.DataSet_Summary_Progress_Report_Revised()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        CType(Me.dt_risk_proj_equp_otherBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet_Summary_Progress_Report_Revised, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dt_risk_proj_equp_otherBindingSource
        '
        Me.dt_risk_proj_equp_otherBindingSource.DataMember = "dt_risk_proj_equp_other"
        Me.dt_risk_proj_equp_otherBindingSource.DataSource = Me.DataSet_Summary_Progress_Report_Revised
        '
        'DataSet_Summary_Progress_Report_Revised
        '
        Me.DataSet_Summary_Progress_Report_Revised.DataSetName = "DataSet_Summary_Progress_Report_Revised"
        Me.DataSet_Summary_Progress_Report_Revised.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DataSet1"
        ReportDataSource1.Value = Me.dt_risk_proj_equp_otherBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "SUPPLY.Evaluation_View_Service_Provider.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(821, 466)
        Me.ReportViewer1.TabIndex = 0
        '
        'Service_Provider_Evaluation_ReportForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(821, 466)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "Service_Provider_Evaluation_ReportForm"
        Me.Text = "Service_Provider_Evaluation_ReportForm"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dt_risk_proj_equp_otherBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet_Summary_Progress_Report_Revised, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents dt_risk_proj_equp_otherBindingSource As BindingSource
    Friend WithEvents DataSet_Summary_Progress_Report_Revised As DataSet_Summary_Progress_Report_Revised
End Class
