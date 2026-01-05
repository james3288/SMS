Public Class AllowanceReportFormNew
    Private Sub AllowanceReportFormNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim total_adfilchargecode(0) As Microsoft.Reporting.WinForms.ReportParameter
        'total_adfilchargecode(0) = New Microsoft.Reporting.WinForms.ReportParameter("total_adfilchargecode", Allowance_sum.total_adfilchargecode)
        'ReportViewer1.LocalReport.SetParameters(total_adfilchargecode)

        'Dim total_projectcode(0) As Microsoft.Reporting.WinForms.ReportParameter
        'total_projectcode(0) = New Microsoft.Reporting.WinForms.ReportParameter("total_projectcode", Allowance_sum.total_projectcode)
        'ReportViewer1.LocalReport.SetParameters(total_projectcode)

        Dim lblDatePrevRange(0) As Microsoft.Reporting.WinForms.ReportParameter
        lblDatePrevRange(0) = New Microsoft.Reporting.WinForms.ReportParameter("lblDatePrevRange", GenerateDataForm.lblDatePrevRange.Text)
        ReportViewer1.LocalReport.SetParameters(lblDatePrevRange)

        Dim lblDateCurRange(0) As Microsoft.Reporting.WinForms.ReportParameter
        lblDateCurRange(0) = New Microsoft.Reporting.WinForms.ReportParameter("lblDateCurRange", GenerateDataForm.lblDateCurRange.Text)
        ReportViewer1.LocalReport.SetParameters(lblDateCurRange)

        Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class