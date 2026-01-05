Public Class FEquipment_cost_report_viewer
    Private Sub FEquipment_cost_report_viewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim month_year_from(0) As Microsoft.Reporting.WinForms.ReportParameter
        month_year_from(0) = New Microsoft.Reporting.WinForms.ReportParameter("month_year_from", FEquipment_cost_report.eu_date_from.Text.ToString)
        ReportViewer1.LocalReport.SetParameters(month_year_from)

        Dim month_year_to(0) As Microsoft.Reporting.WinForms.ReportParameter
        month_year_to(0) = New Microsoft.Reporting.WinForms.ReportParameter("month_year_to", FEquipment_cost_report.eu_date_to.Text.ToString)
        ReportViewer1.LocalReport.SetParameters(month_year_to)

        Dim prepared_by(0) As Microsoft.Reporting.WinForms.ReportParameter
        prepared_by(0) = New Microsoft.Reporting.WinForms.ReportParameter("prepared_by", FEquipment_cost_report.txt_preparedby.Text.ToString)
        ReportViewer1.LocalReport.SetParameters(prepared_by)

        Dim approved_by(0) As Microsoft.Reporting.WinForms.ReportParameter
        approved_by(0) = New Microsoft.Reporting.WinForms.ReportParameter("approved_by", FEquipment_cost_report.txt_approvedby.Text.ToString)
        ReportViewer1.LocalReport.SetParameters(approved_by)

        Dim head(0) As Microsoft.Reporting.WinForms.ReportParameter
        head(0) = New Microsoft.Reporting.WinForms.ReportParameter("head", FEquipment_cost_report.Label6.Text.ToString)
        ReportViewer1.LocalReport.SetParameters(head)


        Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Me.ReportViewer1.RefreshReport()

    End Sub

    Private Sub ReportViewer1_Load(sender As Object, e As EventArgs) Handles ReportViewer1.Load

    End Sub
End Class