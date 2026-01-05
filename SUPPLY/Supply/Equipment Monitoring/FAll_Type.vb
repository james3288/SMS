Public Class FAll_Type
    Private Sub FAll_Type_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim as_of(0) As Microsoft.Reporting.WinForms.ReportParameter
        as_of(0) = New Microsoft.Reporting.WinForms.ReportParameter("as_of_date", FIncome_statement.DateTimePicker2.Text.ToString)
        ReportViewer1.LocalReport.SetParameters(as_of)

        Me.ReportViewer1.RefreshReport()
        Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
    End Sub
End Class