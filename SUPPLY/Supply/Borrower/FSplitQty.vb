Public Class FSplitQty
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim a(22) As String


        With FBorrower_Details.lvlBorrowerItem

            If CDbl(.SelectedItems(0).SubItems(2).Text) < CDbl(txtsplitqty.Text) Then
                MessageBox.Show("your desired qty must not greater than the actual qty...", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub

            ElseIf CDbl(txtsplitqty.Text) = 0 Then
                MessageBox.Show("zero is not applicable...", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub

            ElseIf CDbl(txtsplitqty.Text) = CDbl(.SelectedItems(0).SubItems(2).Text)
                MessageBox.Show("must not be equal...", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub

            End If

            a(0) = .SelectedItems(0).Text
            a(1) = .SelectedItems(0).SubItems(1).Text
            a(2) = CDbl(txtsplitqty.Text)
            a(3) = .SelectedItems(0).SubItems(3).Text
            a(4) = .SelectedItems(0).SubItems(4).Text
            a(5) = .SelectedItems(0).SubItems(5).Text
            a(6) = .SelectedItems(0).SubItems(6).Text
            a(7) = .SelectedItems(0).SubItems(7).Text
            a(8) = .SelectedItems(0).SubItems(8).Text
            a(9) = .SelectedItems(0).SubItems(9).Text
            a(10) = .SelectedItems(0).SubItems(10).Text

            a(11) = .SelectedItems(0).SubItems(11).Text
            a(12) = .SelectedItems(0).SubItems(12).Text
            a(13) = .SelectedItems(0).SubItems(13).Text
            a(14) = .SelectedItems(0).SubItems(14).Text
            a(15) = .SelectedItems(0).SubItems(15).Text
            a(16) = .SelectedItems(0).SubItems(16).Text
            a(17) = .SelectedItems(0).SubItems(17).Text
            a(18) = .SelectedItems(0).SubItems(18).Text

            Dim lvl As New ListViewItem(a)
            ' .Items.Insert(.SelectedItems(0).Index + 1, lvl)
            .Items.Add(lvl)
            .SelectedItems(0).SubItems(2).Text = CDbl(.SelectedItems(0).SubItems(2).Text) - CDbl(txtsplitqty.Text)
        End With

        Button4.PerformClick()

    End Sub
End Class