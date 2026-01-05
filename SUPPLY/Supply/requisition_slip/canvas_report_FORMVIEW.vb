Public Class canvas_report_FORMVIEW
    Private Sub canvas_report_FORMVIEW_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim supplier_1(0) As Microsoft.Reporting.WinForms.ReportParameter
        supplier_1(0) = New Microsoft.Reporting.WinForms.ReportParameter("supplier_1", Canvas_Report_req.TextBox1.Text.ToString)
        ReportViewer1.LocalReport.SetParameters(supplier_1)

        Dim supplier_2(0) As Microsoft.Reporting.WinForms.ReportParameter
        supplier_2(0) = New Microsoft.Reporting.WinForms.ReportParameter("supplier_2", Canvas_Report_req.TextBox2.Text.ToString)
        ReportViewer1.LocalReport.SetParameters(supplier_2)

        Dim supplier_3(0) As Microsoft.Reporting.WinForms.ReportParameter
        supplier_3(0) = New Microsoft.Reporting.WinForms.ReportParameter("supplier_3", Canvas_Report_req.TextBox3.Text.ToString)
        ReportViewer1.LocalReport.SetParameters(supplier_3)

        Dim dates(0) As Microsoft.Reporting.WinForms.ReportParameter
        dates(0) = New Microsoft.Reporting.WinForms.ReportParameter("dates", Canvas_Report_req.canvas_date.Text.ToString)
        ReportViewer1.LocalReport.SetParameters(dates)

        Dim purpose(0) As Microsoft.Reporting.WinForms.ReportParameter
        purpose(0) = New Microsoft.Reporting.WinForms.ReportParameter("purpose", Canvas_Report_req.purpose_txt.Text.ToString)
        ReportViewer1.LocalReport.SetParameters(purpose)

        Dim canvasby(0) As Microsoft.Reporting.WinForms.ReportParameter
        canvasby(0) = New Microsoft.Reporting.WinForms.ReportParameter("canvasby", Canvas_Report_req.canvasbys.Text.ToString)
        ReportViewer1.LocalReport.SetParameters(canvasby)

        Dim appve_by(0) As Microsoft.Reporting.WinForms.ReportParameter
        appve_by(0) = New Microsoft.Reporting.WinForms.ReportParameter("appve_by", Canvas_Report_req.appve_by.Text.ToString)
        ReportViewer1.LocalReport.SetParameters(appve_by)

        Dim remarks1(0) As Microsoft.Reporting.WinForms.ReportParameter
        remarks1(0) = New Microsoft.Reporting.WinForms.ReportParameter("remarks1", Canvas_Report_req.remarks1.Text.ToString)
        ReportViewer1.LocalReport.SetParameters(remarks1)

        Dim remarks2(0) As Microsoft.Reporting.WinForms.ReportParameter
        remarks2(0) = New Microsoft.Reporting.WinForms.ReportParameter("remarks2", Canvas_Report_req.remarks2.Text.ToString)
        ReportViewer1.LocalReport.SetParameters(remarks2)

        Dim remarks3(0) As Microsoft.Reporting.WinForms.ReportParameter
        remarks3(0) = New Microsoft.Reporting.WinForms.ReportParameter("remarks3", Canvas_Report_req.remarks3.Text.ToString)
        ReportViewer1.LocalReport.SetParameters(remarks3)


        Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Me.ReportViewer1.RefreshReport()


    End Sub

    Private Sub canvas_tableBindingSource_CurrentChanged(sender As Object, e As EventArgs) Handles canvas_tableBindingSource.CurrentChanged

    End Sub
End Class