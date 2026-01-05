<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PO_report_view
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
        Me.Po_dataset = New SUPPLY.Po_dataset()
        Me.Po_datatableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.Po_dataset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Po_datatableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "po_dataset"
        ReportDataSource1.Value = Me.Po_datatableBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "SUPPLY.PO_print_report.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(730, 525)
        Me.ReportViewer1.TabIndex = 0
        '
        'Po_dataset
        '
        Me.Po_dataset.DataSetName = "Po_dataset"
        Me.Po_dataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Po_datatableBindingSource
        '
        Me.Po_datatableBindingSource.DataMember = "Po_datatable"
        Me.Po_datatableBindingSource.DataSource = Me.Po_dataset
        '
        'PO_report_view
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(730, 525)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "PO_report_view"
        Me.Text = "PO_report_view"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.Po_dataset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Po_datatableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents Po_datatableBindingSource As BindingSource
    Friend WithEvents Po_dataset As Po_dataset
End Class
