Public Class FReport_Old
    Private Sub FReport_Old_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim plate_no_par(0) As Microsoft.Reporting.WinForms.ReportParameter
        plate_no_par(0) = New Microsoft.Reporting.WinForms.ReportParameter("plate_no_par", FEquipment_history.cmb_plate_no.Text.ToString)
        ReportViewer1.LocalReport.SetParameters(plate_no_par)

        Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Me.ReportViewer1.RefreshReport()
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class