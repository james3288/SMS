<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class equipment_consolidated_ReportForm
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
        Me.DataTable8BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSet_Arrival_Equip_Rental = New SUPPLY.DataSet_Arrival_Equip_Rental()
        CType(Me.DataTable8BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet_Arrival_Equip_Rental, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReportViewer1.DocumentMapWidth = 42
        ReportDataSource1.Name = "DataSet1"
        ReportDataSource1.Value = Me.DataTable8BindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "SUPPLY.equipment_consolidated_report.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(484, 344)
        Me.ReportViewer1.TabIndex = 0
        '
        'DataTable8BindingSource
        '
        Me.DataTable8BindingSource.DataMember = "DataTable8"
        Me.DataTable8BindingSource.DataSource = Me.DataSet_Arrival_Equip_Rental
        '
        'DataSet_Arrival_Equip_Rental
        '
        Me.DataSet_Arrival_Equip_Rental.DataSetName = "DataSet_Arrival_Equip_Rental"
        Me.DataSet_Arrival_Equip_Rental.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'equipment_consolidated_ReportForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(484, 344)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "equipment_consolidated_ReportForm"
        Me.Text = "equipment_consolidated_ReportForm"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataTable8BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet_Arrival_Equip_Rental, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents DataTable8BindingSource As BindingSource
    Friend WithEvents DataSet_Arrival_Equip_Rental As DataSet_Arrival_Equip_Rental
End Class
