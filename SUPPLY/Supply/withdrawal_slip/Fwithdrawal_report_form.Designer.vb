<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fwithdrawal_report_form
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
        Me.sum_withdrawn_itemBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Fwithdrawal_dataset = New SUPPLY.Fwithdrawal_dataset()
        Me.project_code_tableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.sum_withdrawn_itemBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Fwithdrawal_dataset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.project_code_tableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "sum_withdraw_datasets"
        ReportDataSource1.Value = Me.sum_withdrawn_itemBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "SUPPLY.Fwithdraw_Report.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(943, 591)
        Me.ReportViewer1.TabIndex = 0
        '
        'sum_withdrawn_itemBindingSource
        '
        Me.sum_withdrawn_itemBindingSource.DataMember = "sum_withdrawn_item"
        Me.sum_withdrawn_itemBindingSource.DataSource = Me.Fwithdrawal_dataset
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
        'Fwithdrawal_report_form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(943, 591)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "Fwithdrawal_report_form"
        Me.Text = "Fwithdrawal_report_form"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.sum_withdrawn_itemBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Fwithdrawal_dataset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.project_code_tableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents sum_withdrawn_itemBindingSource As BindingSource
    Friend WithEvents Fwithdrawal_dataset As Fwithdrawal_dataset
    Friend WithEvents project_code_tableBindingSource As BindingSource
End Class
