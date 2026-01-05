Public Class voucher_input
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Allowance_sum.txtVoucher.Text = txt_voucher.Text
        Allowance_sum.save_sum_allawance()
        Me.Close()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
End Class