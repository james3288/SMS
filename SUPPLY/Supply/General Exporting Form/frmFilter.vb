Public Class frmFilter
    Private Sub frmFilter_Load(sender As Object, e As EventArgs)
        '      Select Case distinct [typeRequest]
        'From [supply_db].[dbo].[dbrequisition_slip]
        'Where typeRequest Is Not null
        'And typeRequest <> ''
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        ExportingRecordForm.generate_records(ExportingRecordForm.search_code, dtpStartDate.Text, dtpEndDate.Text, DateTimePicker1.Text, DateTimePicker2.Text, "", TextBox1.Text, TextBox3.Text)
        Me.Close()
    End Sub
End Class