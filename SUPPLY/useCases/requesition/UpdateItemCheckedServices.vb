Public Class UpdateItemCheckedServices

    Private _repo As New PropsFields.item_checked_props_fields
    Dim customMsg As New customMessageBox
    Public Function ExecuteWithReturnTrue(itemChecked As PropsFields.item_checked_props_fields) As Boolean
        Try
            _repo = itemChecked
            Dim itemCheckedModel As New ItemCheckedModel
            Dim isUpdated As Boolean = itemCheckedModel.update(_repo)

            Return isUpdated
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

    End Function
End Class
