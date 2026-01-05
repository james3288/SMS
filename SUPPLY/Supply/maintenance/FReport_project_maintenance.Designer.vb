<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FReport_project_maintenance
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
        Me.DTP_proj_maintenanceBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSet3 = New SUPPLY.DataSet3()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.DataSet3BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.DTP_proj_maintenanceBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet3BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DTP_proj_maintenanceBindingSource
        '
        Me.DTP_proj_maintenanceBindingSource.DataMember = "DTP_proj_maintenance"
        Me.DTP_proj_maintenanceBindingSource.DataSource = Me.DataSet3
        '
        'DataSet3
        '
        Me.DataSet3.DataSetName = "DataSet3"
        Me.DataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DataSet2"
        ReportDataSource1.Value = Me.DTP_proj_maintenanceBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "SUPPLY.Report_project_maintenance.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(1316, 614)
        Me.ReportViewer1.TabIndex = 0
        '
        'DataSet3BindingSource
        '
        Me.DataSet3BindingSource.DataSource = Me.DataSet3
        Me.DataSet3BindingSource.Position = 0
        '
        'FReport_project_maintenance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1316, 614)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "FReport_project_maintenance"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DTP_proj_maintenanceBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet3BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents DataSet3 As DataSet3
    Friend WithEvents DataSet3BindingSource As BindingSource
    Friend WithEvents DTP_proj_maintenanceBindingSource As BindingSource
End Class
