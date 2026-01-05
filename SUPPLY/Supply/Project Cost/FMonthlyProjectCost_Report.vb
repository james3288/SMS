Public Class FMonthlyProjectCost_Report
    Private Sub FMonthlyProjectCost_Report_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim as_of(0) As Microsoft.Reporting.WinForms.ReportParameter
        as_of(0) = New Microsoft.Reporting.WinForms.ReportParameter("date", FMonthlyProjectCost.dto.ToString("MMMM yyyy"))
        ReportViewer1.LocalReport.SetParameters(as_of)

        Dim prepared_by(0) As Microsoft.Reporting.WinForms.ReportParameter
        prepared_by(0) = New Microsoft.Reporting.WinForms.ReportParameter("preparedby", FMonthlyProjectCost.txt_preparedby.Text.ToString)
        ReportViewer1.LocalReport.SetParameters(prepared_by)

        Dim approved_by(0) As Microsoft.Reporting.WinForms.ReportParameter
        approved_by(0) = New Microsoft.Reporting.WinForms.ReportParameter("approvedby", FMonthlyProjectCost.txt_approvedby.Text.ToString)
        ReportViewer1.LocalReport.SetParameters(approved_by)

        Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Me.ReportViewer1.RefreshReport()
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class