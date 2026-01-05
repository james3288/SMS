Imports Microsoft.Reporting.WinForms
Public Class FReport
    Private Sub FReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ReportViewer3.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Me.ReportViewer3.RefreshReport()
        Me.ReportViewer3.RefreshReport()
    End Sub
End Class