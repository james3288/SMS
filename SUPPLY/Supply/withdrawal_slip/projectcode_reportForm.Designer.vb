<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class projectcode_reportForm
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
        Me.Fwithdrawal_dataset = New SUPPLY.Fwithdrawal_dataset()
        Me.project_code_tableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.Fwithdrawal_dataset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.project_code_tableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "projectcode_DataSet1"
        ReportDataSource1.Value = Me.project_code_tableBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "SUPPLY.Projectcode_Report.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(819, 508)
        Me.ReportViewer1.TabIndex = 0
        '
        'Fwithdrawal_dataset
        '
        Me.Fwithdrawal_dataset.DataSetName = "Fwithdrawal_dataset"
        Me.Fwithdrawal_dataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'project_code_tableBindingSource
        '
        Me.project_code_tableBindingSource.DataMember = "project_code_table"
        Me.project_code_tableBindingSource.DataSource = Me.Fwithdrawal_dataset
        '
        'projectcode_reportForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(819, 508)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "projectcode_reportForm"
        Me.Text = "projectcode_reportForm"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.Fwithdrawal_dataset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.project_code_tableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents project_code_tableBindingSource As BindingSource
    Friend WithEvents Fwithdrawal_dataset As Fwithdrawal_dataset
End Class
