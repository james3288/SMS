<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class allawance_report_form
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
        Me.allowance_dataSet = New SUPPLY.allowance_dataSet()
        Me.report_datatableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.allowance_dataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.report_datatableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource2.Name = "DataSet1"
        ReportDataSource2.Value = Me.report_datatableBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "SUPPLY.Allowance_report.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(833, 483)
        Me.ReportViewer1.TabIndex = 0
        '
        'allowance_dataSet
        '
        Me.allowance_dataSet.DataSetName = "allowance_dataSet"
        Me.allowance_dataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'report_datatableBindingSource
        '
        Me.report_datatableBindingSource.DataMember = "report_datatable"
        Me.report_datatableBindingSource.DataSource = Me.allowance_dataSet
        '
        'allawance_report_form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(833, 483)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "allawance_report_form"
        Me.Text = "allawance_report_form"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.allowance_dataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.report_datatableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents report_datatableBindingSource As BindingSource
    Friend WithEvents allowance_dataSet As allowance_dataSet
End Class
