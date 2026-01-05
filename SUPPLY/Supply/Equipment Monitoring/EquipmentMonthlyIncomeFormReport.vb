Public Class EquipmentMonthlyIncomeFormReport
    Private Sub EquipmentMonthlyIncomeFormReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ReportViewer1.RefreshReport()
        Dim EquipmentCategory(0) As Microsoft.Reporting.WinForms.ReportParameter
        EquipmentCategory(0) = New Microsoft.Reporting.WinForms.ReportParameter("EquipmentCategory", FIncome_statement.cmb_category.Text.ToString)
        ReportViewer1.LocalReport.SetParameters(EquipmentCategory)

        Dim EquipmentType(0) As Microsoft.Reporting.WinForms.ReportParameter
        EquipmentType(0) = New Microsoft.Reporting.WinForms.ReportParameter("EquipmentType", FIncome_statement.cmb_equiptype.Text.ToString)
        ReportViewer1.LocalReport.SetParameters(EquipmentType)

        Dim PlateNo(0) As Microsoft.Reporting.WinForms.ReportParameter
        PlateNo(0) = New Microsoft.Reporting.WinForms.ReportParameter("PlateNo", FIncome_statement.plateNo.ToString)
        ReportViewer1.LocalReport.SetParameters(PlateNo)

        Dim FinanceHead(0) As Microsoft.Reporting.WinForms.ReportParameter
        FinanceHead(0) = New Microsoft.Reporting.WinForms.ReportParameter("FinanceHead", FIncome_statement.ComboBox2.Text.ToString)
        ReportViewer1.LocalReport.SetParameters(FinanceHead)

        Dim EquipDeptHead(0) As Microsoft.Reporting.WinForms.ReportParameter
        EquipDeptHead(0) = New Microsoft.Reporting.WinForms.ReportParameter("EquipDeptHead", FIncome_statement.ComboBox3.Text.ToString)
        ReportViewer1.LocalReport.SetParameters(EquipDeptHead)

        Dim EquipDivHead(0) As Microsoft.Reporting.WinForms.ReportParameter
        EquipDivHead(0) = New Microsoft.Reporting.WinForms.ReportParameter("EquipDivHead", FIncome_statement.ComboBox4.Text.ToString)
        ReportViewer1.LocalReport.SetParameters(EquipDivHead)

        Dim ExecutiveVicePres(0) As Microsoft.Reporting.WinForms.ReportParameter
        ExecutiveVicePres(0) = New Microsoft.Reporting.WinForms.ReportParameter("ExecutiveVicePres", FIncome_statement.ComboBox5.Text.ToString)
        ReportViewer1.LocalReport.SetParameters(ExecutiveVicePres)

        Dim DatePeriod(0) As Microsoft.Reporting.WinForms.ReportParameter
        DatePeriod(0) = New Microsoft.Reporting.WinForms.ReportParameter("DatePeriod", FIncome_statement.Label10.Text.ToString)
        ReportViewer1.LocalReport.SetParameters(DatePeriod)

        Dim DocsTitle(0) As Microsoft.Reporting.WinForms.ReportParameter
        DocsTitle(0) = New Microsoft.Reporting.WinForms.ReportParameter("DocsTitle", FIncome_statement.docs_title.ToString)
        ReportViewer1.LocalReport.SetParameters(DocsTitle)

        Dim DateRangeTitle(0) As Microsoft.Reporting.WinForms.ReportParameter
        DateRangeTitle(0) = New Microsoft.Reporting.WinForms.ReportParameter("DateRangeTitle", FIncome_statement.DateRangeTitle.ToString)
        ReportViewer1.LocalReport.SetParameters(DateRangeTitle)


        Me.ReportViewer1.RefreshReport()
        Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
    End Sub
End Class