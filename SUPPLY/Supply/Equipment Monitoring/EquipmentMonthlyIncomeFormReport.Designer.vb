<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EquipmentMonthlyIncomeFormReport
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
        Me.DataTable2BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSet_Arrival_Equip_Rental = New SUPPLY.DataSet_Arrival_Equip_Rental()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.DataTable3BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.DataTable2BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet_Arrival_Equip_Rental, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable3BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataTable2BindingSource
        '
        Me.DataTable2BindingSource.DataMember = "DataTable2"
        Me.DataTable2BindingSource.DataSource = Me.DataSet_Arrival_Equip_Rental
        '
        'DataSet_Arrival_Equip_Rental
        '
        Me.DataSet_Arrival_Equip_Rental.DataSetName = "DataSet_Arrival_Equip_Rental"
        Me.DataSet_Arrival_Equip_Rental.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DataSet2"
        ReportDataSource1.Value = Me.DataTable3BindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "SUPPLY.equipment_monthly_income_Statement_revise.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(819, 534)
        Me.ReportViewer1.TabIndex = 0
        '
        'DataTable3BindingSource
        '
        Me.DataTable3BindingSource.DataMember = "DataTable3"
        Me.DataTable3BindingSource.DataSource = Me.DataSet_Arrival_Equip_Rental
        '
        'EquipmentMonthlyIncomeFormReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(819, 534)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "EquipmentMonthlyIncomeFormReport"
        Me.Text = "EquipmentMonthlyIncomeFormReport"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataTable2BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet_Arrival_Equip_Rental, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable3BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents DataTable2BindingSource As BindingSource
    Friend WithEvents DataSet_Arrival_Equip_Rental As DataSet_Arrival_Equip_Rental
    Friend WithEvents DataTable3BindingSource As BindingSource
End Class
