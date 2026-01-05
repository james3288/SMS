<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FReport_Old
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
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.DataSet_Equipment_History = New SUPPLY.DataSet_Equipment_History()
        Me.DTEquipment_historyBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.DataSet_Equipment_History, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DTEquipment_historyBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource2.Name = "DataSet1"
        ReportDataSource2.Value = Me.DTEquipment_historyBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "SUPPLY.EquipmentHistory_Report_old.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(1073, 508)
        Me.ReportViewer1.TabIndex = 0
        '
        'DataSet_Equipment_History
        '
        Me.DataSet_Equipment_History.DataSetName = "DataSet_Equipment_History"
        Me.DataSet_Equipment_History.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DTEquipment_historyBindingSource
        '
        Me.DTEquipment_historyBindingSource.DataMember = "DTEquipment_history"
        Me.DTEquipment_historyBindingSource.DataSource = Me.DataSet_Equipment_History
        '
        'FReport_Old
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1073, 508)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "FReport_Old"
        Me.Text = "FReport_Old"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataSet_Equipment_History, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DTEquipment_historyBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents DTEquipment_historyBindingSource As BindingSource
    Friend WithEvents DataSet_Equipment_History As DataSet_Equipment_History
End Class
