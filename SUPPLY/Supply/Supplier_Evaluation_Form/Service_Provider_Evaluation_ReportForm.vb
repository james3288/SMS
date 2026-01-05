Public Class Service_Provider_Evaluation_ReportForm
    Private Sub Service_Provider_Evaluation_ReportForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim company_name(0) As Microsoft.Reporting.WinForms.ReportParameter
        company_name(0) = New Microsoft.Reporting.WinForms.ReportParameter("CompanyName", SupplierEvaluationFormForm.sup_name.Text)
        ReportViewer1.LocalReport.SetParameters(company_name)

        Dim ProductSupplied(0) As Microsoft.Reporting.WinForms.ReportParameter
        ProductSupplied(0) = New Microsoft.Reporting.WinForms.ReportParameter("ProductSupplied", SupplierEvaluationFormForm.TextBox1.Text)
        ReportViewer1.LocalReport.SetParameters(ProductSupplied)

        Dim date_period(0) As Microsoft.Reporting.WinForms.ReportParameter
        date_period(0) = New Microsoft.Reporting.WinForms.ReportParameter("EvaluationDatePeriod", SupplierEvaluationFormForm.eva_date_period.Text)
        ReportViewer1.LocalReport.SetParameters(date_period)



        Dim delivies_no(0) As Microsoft.Reporting.WinForms.ReportParameter
        delivies_no(0) = New Microsoft.Reporting.WinForms.ReportParameter("NoDeliveries", SupplierEvaluationFormForm.no_deliveries.Text)
        ReportViewer1.LocalReport.SetParameters(delivies_no)

        Dim Rating_1(0) As Microsoft.Reporting.WinForms.ReportParameter
        Rating_1(0) = New Microsoft.Reporting.WinForms.ReportParameter("Rating_1", SupplierEvaluationFormForm.TextBox4.Text)
        ReportViewer1.LocalReport.SetParameters(Rating_1)

        Dim Rating_2(0) As Microsoft.Reporting.WinForms.ReportParameter
        Rating_2(0) = New Microsoft.Reporting.WinForms.ReportParameter("Rating_2", SupplierEvaluationFormForm.TextBox5.Text)
        ReportViewer1.LocalReport.SetParameters(Rating_2)

        Dim Rating_3(0) As Microsoft.Reporting.WinForms.ReportParameter
        Rating_3(0) = New Microsoft.Reporting.WinForms.ReportParameter("Rating_3", SupplierEvaluationFormForm.TextBox6.Text)
        ReportViewer1.LocalReport.SetParameters(Rating_3)

        Dim Rating_4(0) As Microsoft.Reporting.WinForms.ReportParameter
        Rating_4(0) = New Microsoft.Reporting.WinForms.ReportParameter("Rating_4", SupplierEvaluationFormForm.TextBox7.Text)
        ReportViewer1.LocalReport.SetParameters(Rating_4)

        Dim Rating_5(0) As Microsoft.Reporting.WinForms.ReportParameter
        Rating_5(0) = New Microsoft.Reporting.WinForms.ReportParameter("Rating_5", SupplierEvaluationFormForm.TextBox8.Text)
        ReportViewer1.LocalReport.SetParameters(Rating_5)

        Dim Rating_6(0) As Microsoft.Reporting.WinForms.ReportParameter
        Rating_6(0) = New Microsoft.Reporting.WinForms.ReportParameter("Rating_6", SupplierEvaluationFormForm.TextBox9.Text)
        ReportViewer1.LocalReport.SetParameters(Rating_6)


        Dim Score_1(0) As Microsoft.Reporting.WinForms.ReportParameter
        Score_1(0) = New Microsoft.Reporting.WinForms.ReportParameter("Score_1", SupplierEvaluationFormForm.TextBox10.Text)
        ReportViewer1.LocalReport.SetParameters(Score_1)

        Dim Score_2(0) As Microsoft.Reporting.WinForms.ReportParameter
        Score_2(0) = New Microsoft.Reporting.WinForms.ReportParameter("Score_2", SupplierEvaluationFormForm.TextBox11.Text)
        ReportViewer1.LocalReport.SetParameters(Score_2)

        Dim Score_3(0) As Microsoft.Reporting.WinForms.ReportParameter
        Score_3(0) = New Microsoft.Reporting.WinForms.ReportParameter("Score_3", SupplierEvaluationFormForm.TextBox12.Text)
        ReportViewer1.LocalReport.SetParameters(Score_3)

        Dim Score_4(0) As Microsoft.Reporting.WinForms.ReportParameter
        Score_4(0) = New Microsoft.Reporting.WinForms.ReportParameter("Score_4", SupplierEvaluationFormForm.TextBox13.Text)
        ReportViewer1.LocalReport.SetParameters(Score_4)

        Dim Score_5(0) As Microsoft.Reporting.WinForms.ReportParameter
        Score_5(0) = New Microsoft.Reporting.WinForms.ReportParameter("Score_5", SupplierEvaluationFormForm.TextBox14.Text)
        ReportViewer1.LocalReport.SetParameters(Score_5)

        Dim Score_6(0) As Microsoft.Reporting.WinForms.ReportParameter
        Score_6(0) = New Microsoft.Reporting.WinForms.ReportParameter("Score_6", SupplierEvaluationFormForm.TextBox15.Text)
        ReportViewer1.LocalReport.SetParameters(Score_6)

        Dim Total(0) As Microsoft.Reporting.WinForms.ReportParameter
        Total(0) = New Microsoft.Reporting.WinForms.ReportParameter("Total", SupplierEvaluationFormForm.total_score.Text)
        ReportViewer1.LocalReport.SetParameters(Total)


        Dim remarks(0) As Microsoft.Reporting.WinForms.ReportParameter
        remarks(0) = New Microsoft.Reporting.WinForms.ReportParameter("remarks", SupplierEvaluationFormForm.TextBox16.Text)
        ReportViewer1.LocalReport.SetParameters(remarks)

        Dim EvaluatedBy(0) As Microsoft.Reporting.WinForms.ReportParameter
        EvaluatedBy(0) = New Microsoft.Reporting.WinForms.ReportParameter("EvaluatedBy", SupplierEvaluationFormForm.evaluated_by.Text)
        ReportViewer1.LocalReport.SetParameters(EvaluatedBy)

        Dim ApprovedBy(0) As Microsoft.Reporting.WinForms.ReportParameter
        ApprovedBy(0) = New Microsoft.Reporting.WinForms.ReportParameter("ApprovedBy", SupplierEvaluationFormForm.approved_by.Text)
        ReportViewer1.LocalReport.SetParameters(ApprovedBy)

        Dim DateCom(0) As Microsoft.Reporting.WinForms.ReportParameter
        DateCom(0) = New Microsoft.Reporting.WinForms.ReportParameter("DateCom", SupplierEvaluationFormForm.date_com.Text)
        ReportViewer1.LocalReport.SetParameters(DateCom)

        Dim ComTo(0) As Microsoft.Reporting.WinForms.ReportParameter
        ComTo(0) = New Microsoft.Reporting.WinForms.ReportParameter("ComTo", SupplierEvaluationFormForm.com_to.Text)
        ReportViewer1.LocalReport.SetParameters(ComTo)

        Dim relayed(0) As Microsoft.Reporting.WinForms.ReportParameter
        relayed(0) = New Microsoft.Reporting.WinForms.ReportParameter("relayed", SupplierEvaluationFormForm.checkbox_relayed.ToString)
        ReportViewer1.LocalReport.SetParameters(relayed)

        If SupplierEvaluationFormForm.CheckBox2.Checked = True Then
            Dim final_evaluation_date As String
            final_evaluation_date = SupplierEvaluationFormForm.DateTimePicker4.Value.ToString("MMMM dd, yyyy")

            Dim eva_date(0) As Microsoft.Reporting.WinForms.ReportParameter
            eva_date(0) = New Microsoft.Reporting.WinForms.ReportParameter("eva_date", final_evaluation_date)
            ReportViewer1.LocalReport.SetParameters(eva_date)
        Else
            Dim final_evaluation_date2 As String
            final_evaluation_date2 = ""

            Dim eva_date(0) As Microsoft.Reporting.WinForms.ReportParameter
            eva_date(0) = New Microsoft.Reporting.WinForms.ReportParameter("eva_date", final_evaluation_date2)
            ReportViewer1.LocalReport.SetParameters(eva_date)

        End If




        Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class