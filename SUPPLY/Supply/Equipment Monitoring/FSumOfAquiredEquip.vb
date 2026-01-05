Public Class FSumOfAquiredEquip
    Private Sub FSumOfAquiredEquip_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim as_of(0) As Microsoft.Reporting.WinForms.ReportParameter
        as_of(0) = New Microsoft.Reporting.WinForms.ReportParameter("as_of_date", FSummary_of_AcquiredEquipment.dtp_dateTo.Text.ToString)
        ReportViewer1.LocalReport.SetParameters(as_of)

        Me.ReportViewer1.RefreshReport()
        Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
    End Sub
End Class