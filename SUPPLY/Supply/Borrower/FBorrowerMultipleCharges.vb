Public Class FBorrowerMultipleCharges
    Private Sub cmbTypeofCharge_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTypeofCharge.SelectedIndexChanged
        FProjectIncharge.load_all(lvlList, 0, cmbTypeofCharge.Text)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        For Each item As ListViewItem In lvlList.Items
            If item.Checked = True Then
                listofturnovercharges.Add(item.Text & "-" & item.SubItems(2).Text)
            End If
        Next

    End Sub
End Class