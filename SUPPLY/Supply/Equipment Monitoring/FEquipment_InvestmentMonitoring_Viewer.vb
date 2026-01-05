Public Class FEquipment_InvestmentMonitoring_Viewer
    Private Sub FEquipment_InvestmentMonitoring_Viewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim date_from(0) As Microsoft.Reporting.WinForms.ReportParameter
        date_from(0) = New Microsoft.Reporting.WinForms.ReportParameter("date_from_par", FEquipment_InvestmentMonitoring.dtp_datefrom.Text.ToString)
        ReportViewer1.LocalReport.SetParameters(date_from)

        Dim date_to(0) As Microsoft.Reporting.WinForms.ReportParameter
        date_to(0) = New Microsoft.Reporting.WinForms.ReportParameter("date_to_par", FEquipment_InvestmentMonitoring.dtp_dateTo.Text.ToString)
        ReportViewer1.LocalReport.SetParameters(date_to)

        Dim equip_type(0) As Microsoft.Reporting.WinForms.ReportParameter
        equip_type(0) = New Microsoft.Reporting.WinForms.ReportParameter("equip_type_par", FEquipment_InvestmentMonitoring.cmb_equip_type.Text.ToString)
        ReportViewer1.LocalReport.SetParameters(equip_type)

        Dim equip_cat(0) As Microsoft.Reporting.WinForms.ReportParameter
        equip_cat(0) = New Microsoft.Reporting.WinForms.ReportParameter("category_par", FEquipment_InvestmentMonitoring.cmb_searchby.Text.ToString)
        ReportViewer1.LocalReport.SetParameters(equip_cat)

        Me.ReportViewer1.RefreshReport()
        Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
    End Sub
End Class