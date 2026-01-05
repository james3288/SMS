Public Class GetWarehouseItemServices

    Private customMsg As New customMessageBox
    Public Function ExecuteAndReturnData(id As Integer) As List(Of PropsFields.whItems_props_fields)
        Try
            Dim warehouseItemModel As New WarehouseItemModel

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

    End Function
End Class
