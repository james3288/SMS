Public Class Fwithdrawal_kpi_report_form
    Private Sub Fwithdrawal_kpi_report_form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim projectPercent(0) As Microsoft.Reporting.WinForms.ReportParameter
        projectPercent(0) = New Microsoft.Reporting.WinForms.ReportParameter("projectPercent", Fwithdrawal_kpi_report.txtProjectPercent.Text)
        ReportViewer1.LocalReport.SetParameters(projectPercent)

        Dim equipmentPercent(0) As Microsoft.Reporting.WinForms.ReportParameter
        equipmentPercent(0) = New Microsoft.Reporting.WinForms.ReportParameter("equipmentPercent", Fwithdrawal_kpi_report.txtEquipPercent.Text)
        ReportViewer1.LocalReport.SetParameters(equipmentPercent)

        Dim adminPercent(0) As Microsoft.Reporting.WinForms.ReportParameter
        adminPercent(0) = New Microsoft.Reporting.WinForms.ReportParameter("adminPercent", Fwithdrawal_kpi_report.txtAdminPercent.Text)
        ReportViewer1.LocalReport.SetParameters(adminPercent)

        Dim fastPercent(0) As Microsoft.Reporting.WinForms.ReportParameter
        fastPercent(0) = New Microsoft.Reporting.WinForms.ReportParameter("fastPercent", Fwithdrawal_kpi_report.txtFastMovingPercent.Text)
        ReportViewer1.LocalReport.SetParameters(fastPercent)

        Dim mediumPercent(0) As Microsoft.Reporting.WinForms.ReportParameter
        mediumPercent(0) = New Microsoft.Reporting.WinForms.ReportParameter("mediumPercent", Fwithdrawal_kpi_report.txtMediumMovingPercent.Text)
        ReportViewer1.LocalReport.SetParameters(mediumPercent)

        Dim slowPercent(0) As Microsoft.Reporting.WinForms.ReportParameter
        slowPercent(0) = New Microsoft.Reporting.WinForms.ReportParameter("slowPercent", Fwithdrawal_kpi_report.txtSlowMovingPercent.Text)
        ReportViewer1.LocalReport.SetParameters(slowPercent)


        Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class