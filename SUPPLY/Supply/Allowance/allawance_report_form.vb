Public Class allawance_report_form
    Private Sub allawance_report_form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim total_adfilchargecode(0) As Microsoft.Reporting.WinForms.ReportParameter
        total_adfilchargecode(0) = New Microsoft.Reporting.WinForms.ReportParameter("total_adfilchargecode", Allowance_sum.total_adfilchargecode)
        ReportViewer1.LocalReport.SetParameters(total_adfilchargecode)

        Dim total_projectcode(0) As Microsoft.Reporting.WinForms.ReportParameter
        total_projectcode(0) = New Microsoft.Reporting.WinForms.ReportParameter("total_projectcode", Allowance_sum.total_projectcode)
        ReportViewer1.LocalReport.SetParameters(total_projectcode)

        Dim AllowancePeriod(0) As Microsoft.Reporting.WinForms.ReportParameter
        AllowancePeriod(0) = New Microsoft.Reporting.WinForms.ReportParameter("AllowancePeriod", Allowance_sum.dateperiod.Text)
        ReportViewer1.LocalReport.SetParameters(AllowancePeriod)

        Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class