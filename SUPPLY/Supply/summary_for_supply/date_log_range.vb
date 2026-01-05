Public Class date_log_range
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub btnSearch2_Click(sender As Object, e As EventArgs) Handles btnSearch2.Click
        If FSummarySupplyTransaction.cmbSearch.Text = "LATE RS LOG AND PO LOG" Then
            FLateRsLog_PoLogView.ShowDialog()
        Else
            FProgressReport.ShowDialog()
        End If

    End Sub
End Class