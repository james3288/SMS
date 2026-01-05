Public Class summary_date_time_picker
    Public datagridcell As DataGridView
    Public column_index As Integer
    Public row_index As Integer
    Private Sub summary_date_time_picker_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePicker1.Value = Date.Now
    End Sub
    Public Sub set_date()
        datagridcell.CurrentCell.Value = DateTimePicker1.Value.ToString("MM/dd/yyyy")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        set_date()
        Me.Close()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
End Class