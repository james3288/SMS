Public Class deleteWarehouseItemServices
    Private _repo As New PropsFields.whItems_props_fields
    Dim customMsg As New customMessageBox
    Public Function Execute(wh_id As Integer) As Boolean
        Try
            Dim whId As Integer = wh_id
            Dim warehouseItemModel As New WarehouseItemModel
            Dim deleteResult As Boolean = warehouseItemModel.delete(wh_id)

            Return deleteResult

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function
End Class
