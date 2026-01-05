<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FReportViewer_ProgressReportRevised
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
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource3 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource4 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.dtMajor_RequestBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSet_Summary_Progress_Report_Revised = New SUPPLY.DataSet_Summary_Progress_Report_Revised()
        Me.dtUnserved_RequestBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dtProblemsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dt_risk_proj_equp_otherBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReportViewer2 = New Microsoft.Reporting.WinForms.ReportViewer()
        CType(Me.dtMajor_RequestBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet_Summary_Progress_Report_Revised, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtUnserved_RequestBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtProblemsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dt_risk_proj_equp_otherBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtMajor_RequestBindingSource
        '
        Me.dtMajor_RequestBindingSource.DataMember = "dtMajor_Request"
        Me.dtMajor_RequestBindingSource.DataSource = Me.DataSet_Summary_Progress_Report_Revised
        '
        'DataSet_Summary_Progress_Report_Revised
        '
        Me.DataSet_Summary_Progress_Report_Revised.DataSetName = "DataSet_Summary_Progress_Report_Revised"
        Me.DataSet_Summary_Progress_Report_Revised.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'dtUnserved_RequestBindingSource
        '
        Me.dtUnserved_RequestBindingSource.DataMember = "dtUnserved_Request"
        Me.dtUnserved_RequestBindingSource.DataSource = Me.DataSet_Summary_Progress_Report_Revised
        '
        'dtProblemsBindingSource
        '
        Me.dtProblemsBindingSource.DataMember = "dtProblems"
        Me.dtProblemsBindingSource.DataSource = Me.DataSet_Summary_Progress_Report_Revised
        '
        'dt_risk_proj_equp_otherBindingSource
        '
        Me.dt_risk_proj_equp_otherBindingSource.DataMember = "dt_risk_proj_equp_other"
        Me.dt_risk_proj_equp_otherBindingSource.DataSource = Me.DataSet_Summary_Progress_Report_Revised
        '
        'ReportViewer2
        '
        Me.ReportViewer2.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DS_MAJ"
        ReportDataSource1.Value = Me.dtMajor_RequestBindingSource
        ReportDataSource2.Name = "DS_UNSERVED"
        ReportDataSource2.Value = Me.dtUnserved_RequestBindingSource
        ReportDataSource3.Name = "DS_PROBLEMS"
        ReportDataSource3.Value = Me.dtProblemsBindingSource
        ReportDataSource4.Name = "RiskDataSetMaki"
        ReportDataSource4.Value = Me.dt_risk_proj_equp_otherBindingSource
        Me.ReportViewer2.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer2.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer2.LocalReport.DataSources.Add(ReportDataSource3)
        Me.ReportViewer2.LocalReport.DataSources.Add(ReportDataSource4)
        Me.ReportViewer2.LocalReport.ReportEmbeddedResource = "SUPPLY.ProgressReport_Output_Revised.rdlc"
        Me.ReportViewer2.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer2.Name = "ReportViewer2"
        Me.ReportViewer2.Size = New System.Drawing.Size(873, 411)
        Me.ReportViewer2.TabIndex = 1
        '
        'FReportViewer_ProgressReportRevised
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(873, 411)
        Me.Controls.Add(Me.ReportViewer2)
        Me.Name = "FReportViewer_ProgressReportRevised"
        Me.Text = "FReportViewer_ProgressReportRevised"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dtMajor_RequestBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet_Summary_Progress_Report_Revised, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtUnserved_RequestBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtProblemsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dt_risk_proj_equp_otherBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReportViewer2 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents dtMajor_RequestBindingSource As BindingSource
    Friend WithEvents DataSet_Summary_Progress_Report_Revised As DataSet_Summary_Progress_Report_Revised
    Friend WithEvents dtUnserved_RequestBindingSource As BindingSource
    Friend WithEvents dtProblemsBindingSource As BindingSource
    Friend WithEvents dt_risk_proj_equp_otherBindingSource As BindingSource
End Class
