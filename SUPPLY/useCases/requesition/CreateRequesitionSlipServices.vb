Public Class CreateRequesitionSlipServices
    Private _repo As New PropsFields.Create_Requesition_Slip
    Dim customMsg As New customMessageBox
    Public Sub Execute(rsData As PropsFields.Create_Requesition_Slip)
        Try
            _repo = rsData
            'Dim warehouseItemModel As New WarehouseItemModel
            Dim CREATERSMODEL As New CreateRsModel
            Dim id As Integer = CREATERSMODEL.save_requisition(_repo)

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Public Function ExecuteWithReturnId(rsData As PropsFields.Create_Requesition_Slip) As Integer
        Try
            _repo = rsData
            Dim CREATERSMODEL As New CreateRsModel
            Dim id As Integer = CREATERSMODEL.save_requisition(_repo)

            'insert type of request
            executeTypeOfRequestWithAccountTitle(id, _repo.tors_ca_id)

            Return id
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

    End Function

    Public Function ExecuteNoAccountTitleWithReturnId(rsData As PropsFields.Create_Requesition_Slip) As Integer
        Try
            _repo = rsData
            Dim CREATERSMODEL As New CreateRsModel
            Dim id As Integer = CREATERSMODEL.save_requisition(_repo)

            'insert type of request
            executeTypeOfRequestWithNoAccountTitle(id, _repo.tor_sub_id)

            Return id
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

    End Function

    Public Function ExecuteCopyCharges(chargesStorage As List(Of PropsFields.AllCharges), rsId As Integer)
        Try

            Dim crateCharges As New CreateRequesitionSlipChargesServices

            For Each row In chargesStorage
                Dim _charges As New PropsFields.AllCharges
                With _charges
                    .charges_id = row.charges_id
                    .charges_category = row.charges_category
                    .rs_id = row.rs_id
                End With

                Dim result As Integer = crateCharges.ExecuteWithReturnId(_charges, rsId)
            Next

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

    End Function


    Private Sub executeTypeOfRequestWithAccountTitle(rs_id As Integer, tors_ca_id As Integer)
        Try
            Dim CREATERSMODEL As New CreateRsModel
            CREATERSMODEL.save_typeOfRequest(rs_id, tors_ca_id)

        Catch ex As Exception
            customMsg.ErrorMessage()
        End Try
    End Sub

    Private Sub executeTypeOfRequestWithNoAccountTitle(rs_id As Integer, tor_sub_id As Integer)
        Try
            Dim CREATERSMODEL As New CreateRsModel
            CREATERSMODEL.save_typeOfRequest_sub_only(rs_id, tor_sub_id)

        Catch ex As Exception
            customMsg.ErrorMessage()
        End Try
    End Sub

End Class
