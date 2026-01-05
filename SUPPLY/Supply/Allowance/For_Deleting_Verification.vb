Public Class For_Deleting_Verification
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If TextBox1.Text = "akoikawno" Then
            For Each row As ListViewItem In Allowance_sum.lvlAllowance.Items
                If row.Selected = True Then
                    Allowance_sum.deleted_to_store_data()
                    Allowance_sum.Deletedata_allwancesum()
                    row.Remove()
                End If
            Next
            MessageBox.Show("Successfully Deleted...", "EUS Info:", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Else
            MsgBox("Incorect Passcode, Please Contact IT-PROGRAMMER")
        End If

    End Sub
End Class