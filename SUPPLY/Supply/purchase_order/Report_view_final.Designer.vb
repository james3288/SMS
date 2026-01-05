<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Report_view_multi_print
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
        Me.DataSet4 = New SUPPLY.DataSet4()
        Me.Po_dataset_finalBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.DataSet4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Po_dataset_finalBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "Inside_dataset_po"
        ReportDataSource1.Value = Me.Po_dataset_finalBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "SUPPLY.report_view_fina.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(720, 410)
        Me.ReportViewer1.TabIndex = 0
        '
        'DataSet4
        '
        Me.DataSet4.DataSetName = "DataSet4"
        Me.DataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Po_dataset_finalBindingSource
        '
        Me.Po_dataset_finalBindingSource.DataMember = "Po_dataset_final"
        Me.Po_dataset_finalBindingSource.DataSource = Me.DataSet4
        '
        'Report_view_multi_print
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(720, 410)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "Report_view_multi_print"
        Me.Text = "Report Viewer"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataSet4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Po_dataset_finalBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents Po_dataset_finalBindingSource As BindingSource
    Friend WithEvents DataSet4 As DataSet4
End Class
