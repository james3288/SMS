Public Class FArrival_Equip_Rental_Report
    Private Sub FArrival_Equip_Rental_Report_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim from_date(0) As Microsoft.Reporting.WinForms.ReportParameter
        from_date(0) = New Microsoft.Reporting.WinForms.ReportParameter("from_date", FIncome_statement.DateTimePicker1.Text.ToString)
        ReportViewer1.LocalReport.SetParameters(from_date)

        Dim to_date(0) As Microsoft.Reporting.WinForms.ReportParameter
        to_date(0) = New Microsoft.Reporting.WinForms.ReportParameter("to_date", FIncome_statement.DateTimePicker2.Text.ToString)
        ReportViewer1.LocalReport.SetParameters(to_date)


        Me.ReportViewer1.RefreshReport()
        Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
    End Sub
End Class