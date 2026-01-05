Imports Microsoft.Reporting.WinForms

Public Class ReportSummaryPurchasedItem

    Private Sub ReportSummaryPurchasedItem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Me.ReportViewer1.RefreshReport()
    End Sub

End Class