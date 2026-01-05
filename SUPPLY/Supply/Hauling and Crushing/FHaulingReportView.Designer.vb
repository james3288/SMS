<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FHaulingReportView
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
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.datasetHaulingReport = New SUPPLY.datasetHaulingReport()
        Me.DTEhaulingReportBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.datasetHaulingReport, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DTEhaulingReportBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource2.Name = "DataSet1"
        ReportDataSource2.Value = Me.DTEhaulingReportBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "SUPPLY.HaulingReportFinal.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(1049, 484)
        Me.ReportViewer1.TabIndex = 0
        '
        'datasetHaulingReport
        '
        Me.datasetHaulingReport.DataSetName = "datasetHaulingReport"
        Me.datasetHaulingReport.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DTEhaulingReportBindingSource
        '
        Me.DTEhaulingReportBindingSource.DataMember = "DTEhaulingReport"
        Me.DTEhaulingReportBindingSource.DataSource = Me.datasetHaulingReport
        '
        'FHaulingReportView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1049, 484)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "FHaulingReportView"
        Me.Text = "FHaulingReportView"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.datasetHaulingReport, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DTEhaulingReportBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents DTEhaulingReportBindingSource As BindingSource
    Friend WithEvents datasetHaulingReport As datasetHaulingReport
End Class
