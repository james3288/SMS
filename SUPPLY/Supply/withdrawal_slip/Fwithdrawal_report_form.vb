Public Class Fwithdrawal_report_form
    Private Sub Fwithdrawal_report_form_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class