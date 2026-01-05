Public Class ListofEvaluatedSupplierForm
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        SupplierEvaluationFormForm.LlbTitleAllowanceSummary.Text = "SUPPLIER EVALUATION"
        SupplierEvaluationFormForm.Label1.Text = "Product(s) Supplied:"
        SupplierEvaluationFormForm.Label41.Visible = False
        SupplierEvaluationFormForm.DateTimePicker4.Visible = False
        SupplierEvaluationFormForm.CheckBox2.Visible = False
        SupplierEvaluationFormForm.ShowDialog()

    End Sub

    Private Sub ListofEvaluatedSupplierForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SupplierEvaluationFormForm.LlbTitleAllowanceSummary.Text = "SERVICE PROVIDER EVALUATION"
        SupplierEvaluationFormForm.Label1.Text = "Task Description:"
        SupplierEvaluationFormForm.Label41.Visible = True
        SupplierEvaluationFormForm.DateTimePicker4.Visible = True
        SupplierEvaluationFormForm.CheckBox2.Visible = True
        SupplierEvaluationFormForm.CheckBox2.Checked = True
        SupplierEvaluationFormForm.ShowDialog()
    End Sub
End Class