Public Class CreateWarehouseItemServices
    Private _repo As New PropsFields.whItems_props_fields
    Dim customMsg As New customMessageBox
    Private _kpiRepo As New List(Of PropsFields.SELECTED_KPI)

    Public Sub Execute(whItem As PropsFields.whItems_props_fields)
        Try
            _repo = whItem
            Dim warehouseItemModel As New WarehouseItemModel
            Dim id As Integer = warehouseItemModel.saved(_repo, _kpiRepo)

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Public Sub initialize_kpiData(kpiData As List(Of PropsFields.SELECTED_KPI))
        Try
            _kpiRepo = kpiData
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Public Function ExecuteWithReturnId(whItem As PropsFields.whItems_props_fields) As Integer
        Try
            _repo = whItem
            Dim warehouseItemModel As New WarehouseItemModel
            Dim id As Integer = warehouseItemModel.saved(_repo, _kpiRepo)
            Return id
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

    End Function
End Class
