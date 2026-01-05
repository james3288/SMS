Public Class FEquipMon_TypeOfEquip
    Private Sub FEquipMon_TypeOfEquip_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim as_of(0) As Microsoft.Reporting.WinForms.ReportParameter
        as_of(0) = New Microsoft.Reporting.WinForms.ReportParameter("as_of_date", FIncome_statement.DateTimePicker2.Text.ToString)
        ReportViewer1.LocalReport.SetParameters(as_of)

        Dim date_from_par(0) As Microsoft.Reporting.WinForms.ReportParameter
        date_from_par(0) = New Microsoft.Reporting.WinForms.ReportParameter("from_date_par", FIncome_statement.DateTimePicker1.Text.ToString)
        ReportViewer1.LocalReport.SetParameters(date_from_par)

        Dim category_par(0) As Microsoft.Reporting.WinForms.ReportParameter
        category_par(0) = New Microsoft.Reporting.WinForms.ReportParameter("category_par", FIncome_statement.cmb_category.Text.ToString)
        ReportViewer1.LocalReport.SetParameters(category_par)

        Dim equip_type_par(0) As Microsoft.Reporting.WinForms.ReportParameter
        equip_type_par(0) = New Microsoft.Reporting.WinForms.ReportParameter("equip_type_par", FIncome_statement.cmb_equiptype.Text.ToString)
        ReportViewer1.LocalReport.SetParameters(equip_type_par)

        Me.ReportViewer1.RefreshReport()
        Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
    End Sub
End Class