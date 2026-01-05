<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class canvas_report_FORMVIEW
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
        Me.canvas_tableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Canvas_Datasets = New SUPPLY.Canvas_Datasets()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        CType(Me.canvas_tableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Canvas_Datasets, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'canvas_tableBindingSource
        '
        Me.canvas_tableBindingSource.DataMember = "canvas_table"
        Me.canvas_tableBindingSource.DataSource = Me.Canvas_Datasets
        '
        'Canvas_Datasets
        '
        Me.Canvas_Datasets.DataSetName = "Canvas_Datasets"
        Me.Canvas_Datasets.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DataSet1_rdlc_canvas"
        ReportDataSource1.Value = Me.canvas_tableBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "SUPPLY.canvas_temp_RDLC.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(706, 473)
        Me.ReportViewer1.TabIndex = 0
        '
        'canvas_report_FORMVIEW
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(706, 473)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "canvas_report_FORMVIEW"
        Me.Text = "canvas_report_FORMVIEW"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.canvas_tableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Canvas_Datasets, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents canvas_tableBindingSource As BindingSource
    Friend WithEvents Canvas_Datasets As Canvas_Datasets
End Class
