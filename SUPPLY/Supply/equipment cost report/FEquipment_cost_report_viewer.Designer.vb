<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FEquipment_cost_report_viewer
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
        Me.DT_Equipment_costBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSet_equipment_cost = New SUPPLY.DataSet_equipment_cost()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        CType(Me.DT_Equipment_costBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet_equipment_cost, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DT_Equipment_costBindingSource
        '
        Me.DT_Equipment_costBindingSource.DataMember = "DT_Equipment_cost"
        Me.DT_Equipment_costBindingSource.DataSource = Me.DataSet_equipment_cost
        '
        'DataSet_equipment_cost
        '
        Me.DataSet_equipment_cost.DataSetName = "DataSet_equipment_cost"
        Me.DataSet_equipment_cost.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DataSet1"
        ReportDataSource1.Value = Me.DT_Equipment_costBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "SUPPLY.Equipment_cost_report.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(1408, 643)
        Me.ReportViewer1.TabIndex = 0
        '
        'FEquipment_cost_report_viewer
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(1408, 643)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "FEquipment_cost_report_viewer"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DT_Equipment_costBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet_equipment_cost, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents DT_Equipment_costBindingSource As BindingSource
    Friend WithEvents DataSet_equipment_cost As DataSet_equipment_cost
End Class
