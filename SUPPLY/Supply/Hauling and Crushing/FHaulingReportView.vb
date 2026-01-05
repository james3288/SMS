Public Class FHaulingReportView
    Dim ccustomMsg As New customMessageBox
    Private Sub FHaulingReportView_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim date_hauled(0) As Microsoft.Reporting.WinForms.ReportParameter
        date_hauled(0) = New Microsoft.Reporting.WinForms.ReportParameter("date_hauled", dr_month_export)
        ReportViewer1.LocalReport.SetParameters(date_hauled)

        Dim prepared_by(0) As Microsoft.Reporting.WinForms.ReportParameter
        prepared_by(0) = New Microsoft.Reporting.WinForms.ReportParameter("prepared_by", FPreparedbyvb.txtPrepared.Text)
        ReportViewer1.LocalReport.SetParameters(prepared_by)

        Dim note_by(0) As Microsoft.Reporting.WinForms.ReportParameter
        note_by(0) = New Microsoft.Reporting.WinForms.ReportParameter("noted_by", FPreparedbyvb.txtnoted.Text)
        ReportViewer1.LocalReport.SetParameters(note_by)

        Dim pre_job_position(0) As Microsoft.Reporting.WinForms.ReportParameter
        pre_job_position(0) = New Microsoft.Reporting.WinForms.ReportParameter("pre_job_position", FPreparedbyvb.lbl_job_position_prepared_by.Text)
        ReportViewer1.LocalReport.SetParameters(pre_job_position)

        Dim noted_job_position(0) As Microsoft.Reporting.WinForms.ReportParameter
        noted_job_position(0) = New Microsoft.Reporting.WinForms.ReportParameter("noted_job_position", FPreparedbyvb.lbl_noted_by.Text)
        ReportViewer1.LocalReport.SetParameters(noted_job_position)


        Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class