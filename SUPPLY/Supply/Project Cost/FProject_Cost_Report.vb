Public Class FProject_Cost_Report
    Private Sub FProject_Cost_Report_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim par_project_desc1(0) As Microsoft.Reporting.WinForms.ReportParameter
        par_project_desc1(0) = New Microsoft.Reporting.WinForms.ReportParameter("par_project_desc", FProjectCost.ComboBox2.Text.ToString)
        ReportViewer1.LocalReport.SetParameters(par_project_desc1)

        Dim par_location(0) As Microsoft.Reporting.WinForms.ReportParameter
        par_location(0) = New Microsoft.Reporting.WinForms.ReportParameter("par_location", FProjectCost.Label2.Text.ToString)
        ReportViewer1.LocalReport.SetParameters(par_location)

        Dim par_project_eng(0) As Microsoft.Reporting.WinForms.ReportParameter
        par_project_eng(0) = New Microsoft.Reporting.WinForms.ReportParameter("par_project_engineer", FProjectCost.Label3.Text.ToString)
        ReportViewer1.LocalReport.SetParameters(par_project_eng)


        Dim par_preparedby(0) As Microsoft.Reporting.WinForms.ReportParameter
        par_preparedby(0) = New Microsoft.Reporting.WinForms.ReportParameter("par_preparedby", FProjectCost.txt_preparedby.Text.ToString)
        ReportViewer1.LocalReport.SetParameters(par_preparedby)

        Dim par_verifiedby(0) As Microsoft.Reporting.WinForms.ReportParameter
        par_verifiedby(0) = New Microsoft.Reporting.WinForms.ReportParameter("par_verifiedby", FProjectCost.txt_approvedby.Text.ToString)
        ReportViewer1.LocalReport.SetParameters(par_verifiedby)

        Me.ReportViewer1.RefreshReport()
        Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
    End Sub
End Class