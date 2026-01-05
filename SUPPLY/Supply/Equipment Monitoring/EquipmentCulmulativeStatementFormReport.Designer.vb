<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EquipmentCulmulativeStatementFormReport
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
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource3 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.DataTable4BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSet_Arrival_Equip_Rental = New SUPPLY.DataSet_Arrival_Equip_Rental()
        Me.DataTable5BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataTable6BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.DataTable4BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet_Arrival_Equip_Rental, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable5BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable6BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DataSet1"
        ReportDataSource1.Value = Me.DataTable4BindingSource
        ReportDataSource2.Name = "DataSet2"
        ReportDataSource2.Value = Me.DataTable5BindingSource
        ReportDataSource3.Name = "DataSet3"
        ReportDataSource3.Value = Me.DataTable6BindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource3)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "SUPPLY.equipment_monthly_income_Statement_revise - Copy.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(610, 398)
        Me.ReportViewer1.TabIndex = 1
        '
        'DataTable4BindingSource
        '
        Me.DataTable4BindingSource.DataMember = "DataTable4"
        Me.DataTable4BindingSource.DataSource = Me.DataSet_Arrival_Equip_Rental
        '
        'DataSet_Arrival_Equip_Rental
        '
        Me.DataSet_Arrival_Equip_Rental.DataSetName = "DataSet_Arrival_Equip_Rental"
        Me.DataSet_Arrival_Equip_Rental.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DataTable5BindingSource
        '
        Me.DataTable5BindingSource.DataMember = "DataTable5"
        Me.DataTable5BindingSource.DataSource = Me.DataSet_Arrival_Equip_Rental
        '
        'DataTable6BindingSource
        '
        Me.DataTable6BindingSource.DataMember = "DataTable6"
        Me.DataTable6BindingSource.DataSource = Me.DataSet_Arrival_Equip_Rental
        '
        'EquipmentCulmulativeStatementFormReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(610, 398)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "EquipmentCulmulativeStatementFormReport"
        Me.Text = "EquipmentCulmulativeStatementFormReport"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataTable4BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet_Arrival_Equip_Rental, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable5BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable6BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents DataTable4BindingSource As BindingSource
    Friend WithEvents DataSet_Arrival_Equip_Rental As DataSet_Arrival_Equip_Rental
    Friend WithEvents DataTable5BindingSource As BindingSource
    Friend WithEvents DataTable6BindingSource As BindingSource
End Class
