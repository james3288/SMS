Public Class UpdateWarehouseItemServices
    Private _repo As New PropsFields.whItems_props_fields
    Dim customMsg As New customMessageBox
    Public Function ExecuteWithReturnBoolean(whItem As PropsFields.whItems_props_fields, id As Integer) As Boolean
        Try
            _repo = whItem
            Dim warehouseItemModel As New WarehouseItemModel
            Dim result As Boolean = warehouseItemModel.update(_repo, id)
            Return result
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

    End Function
End Class
