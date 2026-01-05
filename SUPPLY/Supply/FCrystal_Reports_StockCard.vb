Public Class FCrystal_Reports_StockCard

    Private Sub FCrystal_Reports_StockCard_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Dim item_name(0) As Microsoft.Reporting.WinForms.ReportParameter
        'item_name(0) = New Microsoft.Reporting.WinForms.ReportParameter("item_name_label_par", FStockCard.lblitem_name.Text.ToString)
        'ReportViewer1.LocalReport.SetParameters(item_name)

        'Dim reOrderPoint(0) As Microsoft.Reporting.WinForms.ReportParameter
        'reOrderPoint(0) = New Microsoft.Reporting.WinForms.ReportParameter("reOrderPoint_par", FStockCard.lblReOrderPoint.Text.ToString)
        'ReportViewer1.LocalReport.SetParameters(reOrderPoint)

        'Dim location_wh(0) As Microsoft.Reporting.WinForms.ReportParameter
        'location_wh(0) = New Microsoft.Reporting.WinForms.ReportParameter("location_par", FStockCard.lbl_location.Text.ToString)
        'ReportViewer1.LocalReport.SetParameters(location_wh)

        'Dim bal(0) As Microsoft.Reporting.WinForms.ReportParameter
        'bal(0) = New Microsoft.Reporting.WinForms.ReportParameter("bal_par", FStockCard.lblBalance.Text.ToString)
        'ReportViewer1.LocalReport.SetParameters(bal)

        'Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        'Me.ReportViewer1.RefreshReport()

    End Sub

    Private Sub dtDataBindingSource_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtDataBindingSource.CurrentChanged

    End Sub
End Class