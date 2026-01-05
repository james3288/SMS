Public Class EquipmentCulmulativeStatementFormReport
    Private Sub EquipmentCulmulativeStatementFormReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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


        Dim TotalMonthJan(0) As Microsoft.Reporting.WinForms.ReportParameter
        TotalMonthJan(0) = New Microsoft.Reporting.WinForms.ReportParameter("TotalMonthJan", FIncome_statement.monthArray(0).ToString)
        ReportViewer1.LocalReport.SetParameters(TotalMonthJan)

        Dim TotalMonthFeb(0) As Microsoft.Reporting.WinForms.ReportParameter
        TotalMonthFeb(0) = New Microsoft.Reporting.WinForms.ReportParameter("TotalMonthFeb", FIncome_statement.monthArray(1).ToString)
        ReportViewer1.LocalReport.SetParameters(TotalMonthFeb)

        Dim TotalMonthMarch(0) As Microsoft.Reporting.WinForms.ReportParameter
        TotalMonthMarch(0) = New Microsoft.Reporting.WinForms.ReportParameter("TotalMonthMarch", FIncome_statement.monthArray(2).ToString)
        ReportViewer1.LocalReport.SetParameters(TotalMonthMarch)

        Dim TotalMonthApril(0) As Microsoft.Reporting.WinForms.ReportParameter
        TotalMonthApril(0) = New Microsoft.Reporting.WinForms.ReportParameter("TotalMonthApril", FIncome_statement.monthArray(3).ToString)
        ReportViewer1.LocalReport.SetParameters(TotalMonthApril)

        Dim TotalMonthMay(0) As Microsoft.Reporting.WinForms.ReportParameter
        TotalMonthMay(0) = New Microsoft.Reporting.WinForms.ReportParameter("TotalMonthMay", FIncome_statement.monthArray(4).ToString)
        ReportViewer1.LocalReport.SetParameters(TotalMonthMay)


        Dim TotalMonthJune(0) As Microsoft.Reporting.WinForms.ReportParameter
        TotalMonthJune(0) = New Microsoft.Reporting.WinForms.ReportParameter("TotalMonthJune", FIncome_statement.monthArray(5).ToString)
        ReportViewer1.LocalReport.SetParameters(TotalMonthJune)

        Dim TotalMonthJuly(0) As Microsoft.Reporting.WinForms.ReportParameter
        TotalMonthJuly(0) = New Microsoft.Reporting.WinForms.ReportParameter("TotalMonthJuly", FIncome_statement.monthArray(6).ToString)
        ReportViewer1.LocalReport.SetParameters(TotalMonthJuly)

        Dim TotalMonthAug(0) As Microsoft.Reporting.WinForms.ReportParameter
        TotalMonthAug(0) = New Microsoft.Reporting.WinForms.ReportParameter("TotalMonthAug", FIncome_statement.monthArray(7).ToString)
        ReportViewer1.LocalReport.SetParameters(TotalMonthAug)

        Dim TotalMonthSept(0) As Microsoft.Reporting.WinForms.ReportParameter
        TotalMonthSept(0) = New Microsoft.Reporting.WinForms.ReportParameter("TotalMonthSept", FIncome_statement.monthArray(8).ToString)
        ReportViewer1.LocalReport.SetParameters(TotalMonthSept)

        Dim TotalMonthOct(0) As Microsoft.Reporting.WinForms.ReportParameter
        TotalMonthOct(0) = New Microsoft.Reporting.WinForms.ReportParameter("TotalMonthOct", FIncome_statement.monthArray(9).ToString)
        ReportViewer1.LocalReport.SetParameters(TotalMonthOct)

        Dim TotalMonthNov(0) As Microsoft.Reporting.WinForms.ReportParameter
        TotalMonthNov(0) = New Microsoft.Reporting.WinForms.ReportParameter("TotalMonthNov", FIncome_statement.monthArray(10).ToString)
        ReportViewer1.LocalReport.SetParameters(TotalMonthNov)

        Dim TotalMonthDec(0) As Microsoft.Reporting.WinForms.ReportParameter
        TotalMonthDec(0) = New Microsoft.Reporting.WinForms.ReportParameter("TotalMonthDec", FIncome_statement.monthArray(11).ToString)
        ReportViewer1.LocalReport.SetParameters(TotalMonthDec)



        'OPERATION TOTAL EXPENCES
        Dim TotalOperationJan(0) As Microsoft.Reporting.WinForms.ReportParameter
        TotalOperationJan(0) = New Microsoft.Reporting.WinForms.ReportParameter("TotalOperationJan", FIncome_statement.monthArrayOperation(0).ToString)
        ReportViewer1.LocalReport.SetParameters(TotalOperationJan)

        Dim TotalOperationFeb(0) As Microsoft.Reporting.WinForms.ReportParameter
        TotalOperationFeb(0) = New Microsoft.Reporting.WinForms.ReportParameter("TotalOperationFeb", FIncome_statement.monthArrayOperation(1).ToString)
        ReportViewer1.LocalReport.SetParameters(TotalOperationFeb)

        Dim TotalOperationMar(0) As Microsoft.Reporting.WinForms.ReportParameter
        TotalOperationMar(0) = New Microsoft.Reporting.WinForms.ReportParameter("TotalOperationMar", FIncome_statement.monthArrayOperation(2).ToString)
        ReportViewer1.LocalReport.SetParameters(TotalOperationMar)

        Dim TotalOperationApril(0) As Microsoft.Reporting.WinForms.ReportParameter
        TotalOperationApril(0) = New Microsoft.Reporting.WinForms.ReportParameter("TotalOperationApril", FIncome_statement.monthArrayOperation(3).ToString)
        ReportViewer1.LocalReport.SetParameters(TotalOperationApril)

        Dim TotalOperationMay(0) As Microsoft.Reporting.WinForms.ReportParameter
        TotalOperationMay(0) = New Microsoft.Reporting.WinForms.ReportParameter("TotalOperationMay", FIncome_statement.monthArrayOperation(4).ToString)
        ReportViewer1.LocalReport.SetParameters(TotalOperationMay)

        Dim TotalOperationJun(0) As Microsoft.Reporting.WinForms.ReportParameter
        TotalOperationJun(0) = New Microsoft.Reporting.WinForms.ReportParameter("TotalOperationJun", FIncome_statement.monthArrayOperation(5).ToString)
        ReportViewer1.LocalReport.SetParameters(TotalOperationJun)

        Dim TotalOperationJul(0) As Microsoft.Reporting.WinForms.ReportParameter
        TotalOperationJul(0) = New Microsoft.Reporting.WinForms.ReportParameter("TotalOperationJul", FIncome_statement.monthArrayOperation(6).ToString)
        ReportViewer1.LocalReport.SetParameters(TotalOperationJul)

        Dim TotalOperationAug(0) As Microsoft.Reporting.WinForms.ReportParameter
        TotalOperationAug(0) = New Microsoft.Reporting.WinForms.ReportParameter("TotalOperationAug", FIncome_statement.monthArrayOperation(7).ToString)
        ReportViewer1.LocalReport.SetParameters(TotalOperationAug)

        Dim TotalOperationSep(0) As Microsoft.Reporting.WinForms.ReportParameter
        TotalOperationSep(0) = New Microsoft.Reporting.WinForms.ReportParameter("TotalOperationSep", FIncome_statement.monthArrayOperation(8).ToString)
        ReportViewer1.LocalReport.SetParameters(TotalOperationSep)

        Dim TotalOperationOct(0) As Microsoft.Reporting.WinForms.ReportParameter
        TotalOperationOct(0) = New Microsoft.Reporting.WinForms.ReportParameter("TotalOperationOct", FIncome_statement.monthArrayOperation(9).ToString)
        ReportViewer1.LocalReport.SetParameters(TotalOperationOct)

        Dim TotalOperationNov(0) As Microsoft.Reporting.WinForms.ReportParameter
        TotalOperationNov(0) = New Microsoft.Reporting.WinForms.ReportParameter("TotalOperationNov", FIncome_statement.monthArrayOperation(10).ToString)
        ReportViewer1.LocalReport.SetParameters(TotalOperationNov)

        Dim TotalOperationDec(0) As Microsoft.Reporting.WinForms.ReportParameter
        TotalOperationDec(0) = New Microsoft.Reporting.WinForms.ReportParameter("TotalOperationDec", FIncome_statement.monthArrayOperation(11).ToString)
        ReportViewer1.LocalReport.SetParameters(TotalOperationDec)


        Me.ReportViewer1.RefreshReport()
        Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
    End Sub
End Class