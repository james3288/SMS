Public Class FSumOf_All_AquiredEqui_report
    Private Sub FSumOf_All_AquiredEqui_report_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim as_of(0) As Microsoft.Reporting.WinForms.ReportParameter
        as_of(0) = New Microsoft.Reporting.WinForms.ReportParameter("as_of_date", FAll_Summary_of_acquiredEquipment.dtp_dateTo.Text.ToString)
        ReportViewer1.LocalReport.SetParameters(as_of)

        Me.ReportViewer1.RefreshReport()
        Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
    End Sub
End Class