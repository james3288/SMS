Public Class Report_view_multi_print
    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Supplier(0) As Microsoft.Reporting.WinForms.ReportParameter
        Supplier(0) = New Microsoft.Reporting.WinForms.ReportParameter("Supplier", FPurchasedOrderList.supply_name.ToString)
        ReportViewer1.LocalReport.SetParameters(Supplier)

        Dim po_no(0) As Microsoft.Reporting.WinForms.ReportParameter
        po_no(0) = New Microsoft.Reporting.WinForms.ReportParameter("po_no", FPurchasedOrderList.po.ToString)
        ReportViewer1.LocalReport.SetParameters(po_no)



        Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Me.ReportViewer1.RefreshReport()
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class