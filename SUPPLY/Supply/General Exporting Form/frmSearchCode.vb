Public Class frmSearchCode
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        ExportingRecordForm.generate_records(ExportingRecordForm.search_code, Date.Now, Date.Now, Date.Now, Date.Now, txtSearch.Text, "", "")
        Me.Close()
    End Sub
End Class