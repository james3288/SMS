Public Class equipment_consolidated_ReportForm
    Private Sub equipment_consolidated_ReportForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Dim FinanceHead(0) As Microsoft.Reporting.WinForms.ReportParameter
        'FinanceHead(0) = New Microsoft.Reporting.WinForms.ReportParameter("FinanceHead", FIncome_statement.ComboBox2.Text.ToString)
        'ReportViewer1.LocalReport.SetParameters(FinanceHead)

        'Dim EquipDeptHead(0) As Microsoft.Reporting.WinForms.ReportParameter
        'EquipDeptHead(0) = New Microsoft.Reporting.WinForms.ReportParameter("EquipDeptHead", FIncome_statement.ComboBox3.Text.ToString)
        'ReportViewer1.LocalReport.SetParameters(EquipDeptHead)

        'Dim EquipDivHead(0) As Microsoft.Reporting.WinForms.ReportParameter
        'EquipDivHead(0) = New Microsoft.Reporting.WinForms.ReportParameter("EquipDivHead", FIncome_statement.ComboBox4.Text.ToString)
        'ReportViewer1.LocalReport.SetParameters(EquipDivHead)

        'Dim ExecutiveVicePres(0) As Microsoft.Reporting.WinForms.ReportParameter
        'ExecutiveVicePres(0) = New Microsoft.Reporting.WinForms.ReportParameter("ExecutiveVicePres", FIncome_statement.ComboBox5.Text.ToString)
        'ReportViewer1.LocalReport.SetParameters(ExecutiveVicePres)

        Dim DateFrom(0) As Microsoft.Reporting.WinForms.ReportParameter
        DateFrom(0) = New Microsoft.Reporting.WinForms.ReportParameter("DateFrom", FIncome_statement.DateTimePicker1.Text.ToString)
        ReportViewer1.LocalReport.SetParameters(DateFrom)

        Dim DateTo(0) As Microsoft.Reporting.WinForms.ReportParameter
        DateTo(0) = New Microsoft.Reporting.WinForms.ReportParameter("DateTo", FIncome_statement.DateTimePicker2.Text.ToString)
        ReportViewer1.LocalReport.SetParameters(DateTo)

        Me.ReportViewer1.RefreshReport()
        Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
    End Sub
End Class