Public Class FEquipment_Monthly_Cost_Report_typeofequip_Form
    Private Sub FEquipment_Monthly_Cost_Report_typeofequip_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dates(0) As Microsoft.Reporting.WinForms.ReportParameter
        dates(0) = New Microsoft.Reporting.WinForms.ReportParameter("dates", FIncome_statement.DateTimePicker1.Text.ToString)
        ReportViewer1.LocalReport.SetParameters(dates)

        'Dim as_of(0) As Microsoft.Reporting.WinForms.ReportParameter
        'as_of(0) = New Microsoft.Reporting.WinForms.ReportParameter("as_of_date", FIncome_statement.DateTimePicker2.Text.ToString)
        'ReportViewer1.LocalReport.SetParameters(as_of)

        'Dim date_from_par(0) As Microsoft.Reporting.WinForms.ReportParameter
        'date_from_par(0) = New Microsoft.Reporting.WinForms.ReportParameter("from_date_par", FIncome_statement.DateTimePicker1.Text.ToString)
        'ReportViewer1.LocalReport.SetParameters(date_from_par)

        Dim date_format_m(0) As Microsoft.Reporting.WinForms.ReportParameter
        date_format_m(0) = New Microsoft.Reporting.WinForms.ReportParameter("date_format_m", FIncome_statement.Label21.Text.ToString)
        ReportViewer1.LocalReport.SetParameters(date_format_m)

        Dim category_par(0) As Microsoft.Reporting.WinForms.ReportParameter
        category_par(0) = New Microsoft.Reporting.WinForms.ReportParameter("category_par", FIncome_statement.cmb_category.Text.ToString)
        ReportViewer1.LocalReport.SetParameters(category_par)

        Dim equip_type_par(0) As Microsoft.Reporting.WinForms.ReportParameter
        equip_type_par(0) = New Microsoft.Reporting.WinForms.ReportParameter("equip_type_par", FIncome_statement.cmb_equiptype.Text.ToString)
        ReportViewer1.LocalReport.SetParameters(equip_type_par)

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

        Me.ReportViewer1.RefreshReport()
        Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
    End Sub
End Class