Public Class Freportviewer_ListOfWarehouseItems
    Private Sub Freportviewer_ListOfWarehouseItems_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim par_UpdatedAsOf(0) As Microsoft.Reporting.WinForms.ReportParameter
        par_UpdatedAsOf(0) = New Microsoft.Reporting.WinForms.ReportParameter("par_UpdatedAsOf", Date.Now)
        ReportViewer1.LocalReport.SetParameters(par_UpdatedAsOf)

        Dim par_Loc(0) As Microsoft.Reporting.WinForms.ReportParameter
        par_Loc(0) = New Microsoft.Reporting.WinForms.ReportParameter("par_Loc", FWarehouseItemsNew.txtSearch.Text.ToString.ToUpper)
        ReportViewer1.LocalReport.SetParameters(par_Loc)

        Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class