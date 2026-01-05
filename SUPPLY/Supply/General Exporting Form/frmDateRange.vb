Public Class frmDateRange
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        ExportingRecordForm.generate_records(ExportingRecordForm.search_code, dtpStartDate.Text, dtpEndDate.Text, dtpStartDate.Text, dtpEndDate.Text, "", TextBox1.Text, TextBox2.Text)
        Me.Close()
    End Sub

    Private Sub frmDateRange_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class