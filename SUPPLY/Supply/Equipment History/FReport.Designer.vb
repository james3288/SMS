<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FReport
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
        Me.ReportViewer3 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.DTEquipment_historyBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSet_Equipment_History = New SUPPLY.DataSet_Equipment_History()
        CType(Me.DTEquipment_historyBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet_Equipment_History, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer3
        '
        Me.ReportViewer3.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DataSet1"
        ReportDataSource1.Value = Me.DTEquipment_historyBindingSource
        Me.ReportViewer3.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer3.LocalReport.ReportEmbeddedResource = "SUPPLY.EquipmentHistory_Report.rdlc"
        Me.ReportViewer3.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer3.Name = "ReportViewer3"
        Me.ReportViewer3.Size = New System.Drawing.Size(1071, 422)
        Me.ReportViewer3.TabIndex = 0
        '
        'DTEquipment_historyBindingSource
        '
        Me.DTEquipment_historyBindingSource.DataMember = "DTEquipment_history"
        Me.DTEquipment_historyBindingSource.DataSource = Me.DataSet_Equipment_History
        '
        'DataSet_Equipment_History
        '
        Me.DataSet_Equipment_History.DataSetName = "DataSet_Equipment_History"
        Me.DataSet_Equipment_History.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'FReport
        '
        Me.ClientSize = New System.Drawing.Size(1071, 422)
        Me.Controls.Add(Me.ReportViewer3)
        Me.Name = "FReport"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DTEquipment_historyBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet_Equipment_History, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents DataSet3 As DataSet_Equipment_History
    Friend WithEvents DTEquipmenthistoryBindingSource As BindingSource
    Friend WithEvents ReportViewer2 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents DataSet31BindingSource As BindingSource
    Friend WithEvents DataSet31 As DataSet_Equipment_History
    Friend WithEvents ReportViewer3 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents DTEquipment_historyBindingSource As BindingSource
    Friend WithEvents DataSet_Equipment_History As DataSet_Equipment_History
End Class
