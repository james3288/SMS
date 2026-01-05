Public Class FBorrower_Set_Item_No
    Private Sub btnSet_Click(sender As Object, e As EventArgs) Handles btnSet.Click

        Dim rr_item_id As Integer = CInt(FListofBorrowerItem.lvlBorrowerItem.SelectedItems(0).Text)
        Dim query As String = "UPDATE dbreceiving_items_sub SET item_no = " & CInt(txtset.Text) & " WHERE rr_item_sub_id = " & rr_item_id
        UPDATE_INSERT_DELETE_QUERY(query, 0, "UPDATE")
        Me.Close()
        FListofBorrowerItem.btnBMsearch.PerformClick()

    End Sub
End Class