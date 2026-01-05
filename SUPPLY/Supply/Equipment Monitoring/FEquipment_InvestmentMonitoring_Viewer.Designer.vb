<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FEquipment_InvestmentMonitoring_Viewer
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
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.DS_EquipInvMonitoringBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSet_Equip_Investment_Monitoring = New SUPPLY.DataSet_Equip_Investment_Monitoring()
        CType(Me.DS_EquipInvMonitoringBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet_Equip_Investment_Monitoring, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DS_Equip_Investment_Monitoring"
        ReportDataSource1.Value = Me.DS_EquipInvMonitoringBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "SUPPLY.Report_Equip_Investment_Monitoring.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(854, 420)
        Me.ReportViewer1.TabIndex = 0
        '
        'DS_EquipInvMonitoringBindingSource
        '
        Me.DS_EquipInvMonitoringBindingSource.DataMember = "DS_EquipInvMonitoring"
        Me.DS_EquipInvMonitoringBindingSource.DataSource = Me.DataSet_Equip_Investment_Monitoring
        '
        'DataSet_Equip_Investment_Monitoring
        '
        Me.DataSet_Equip_Investment_Monitoring.DataSetName = "DataSet_Equip_Investment_Monitoring"
        Me.DataSet_Equip_Investment_Monitoring.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'FEquipment_InvestmentMonitoring_Viewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(854, 420)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "FEquipment_InvestmentMonitoring_Viewer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FEquipment_InvestmentMonitoring_Viewer"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DS_EquipInvMonitoringBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet_Equip_Investment_Monitoring, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents DS_EquipInvMonitoringBindingSource As BindingSource
    Friend WithEvents DataSet_Equip_Investment_Monitoring As DataSet_Equip_Investment_Monitoring
End Class
