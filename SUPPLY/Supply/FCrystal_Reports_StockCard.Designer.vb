<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FCrystal_Reports_StockCard
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
        Me.dtDataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSet1 = New SUPPLY.DataSet1()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.DataSetStock_Card = New SUPPLY.DataSetStock_Card()
        Me.dtDataStockCardBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.dtDataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSetStock_Card, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtDataStockCardBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtDataBindingSource
        '
        Me.dtDataBindingSource.DataMember = "dtData"
        Me.dtDataBindingSource.DataSource = Me.DataSet1
        '
        'DataSet1
        '
        Me.DataSet1.DataSetName = "DataSet1"
        Me.DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DataSetStock_card"
        ReportDataSource1.Value = Me.dtDataStockCardBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "SUPPLY.ReportStock_card.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(1316, 865)
        Me.ReportViewer1.TabIndex = 0
        Me.ReportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.FullPage
        '
        'DataSetStock_Card
        '
        Me.DataSetStock_Card.DataSetName = "DataSetStock_Card"
        Me.DataSetStock_Card.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'dtDataStockCardBindingSource
        '
        Me.dtDataStockCardBindingSource.DataMember = "dtDataStockCard"
        Me.dtDataStockCardBindingSource.DataSource = Me.DataSetStock_Card
        '
        'FCrystal_Reports_StockCard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1316, 865)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "FCrystal_Reports_StockCard"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FCrystal_Reports_StockCard"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dtDataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSetStock_Card, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtDataStockCardBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents dtDataBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DataSet1 As SUPPLY.DataSet1
    Friend WithEvents dtDataStockCardBindingSource As BindingSource
    Friend WithEvents DataSetStock_Card As DataSetStock_Card
End Class
