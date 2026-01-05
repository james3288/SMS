Public Class FSummary_Purchased_Item_Update_viewing
    Private Sub FSummary_Purchased_Item_Update_viewing_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim date_from(0) As Microsoft.Reporting.WinForms.ReportParameter
        date_from(0) = New Microsoft.Reporting.WinForms.ReportParameter("date_from_par", Summary_Purchased_Item.dtp_poDate_From.Text.ToString)
        ReportViewer1.LocalReport.SetParameters(date_from)

        Dim date_to(0) As Microsoft.Reporting.WinForms.ReportParameter
        date_to(0) = New Microsoft.Reporting.WinForms.ReportParameter("date_to_par", Summary_Purchased_Item.dtp_poDate_To.Text.ToString)
        ReportViewer1.LocalReport.SetParameters(date_to)

        'Dim cat_par(0) As Microsoft.Reporting.WinForms.ReportParameter
        'cat_par(0) = New Microsoft.Reporting.WinForms.ReportParameter("category_par", Summary_Purchased_Item.cmb_supplierName2.Text.ToString)
        'ReportViewer1.LocalReport.SetParameters(cat_par)

        Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Me.ReportViewer1.RefreshReport()

    End Sub

End Class