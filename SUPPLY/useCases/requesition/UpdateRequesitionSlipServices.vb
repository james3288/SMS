Public Class UpdateRequesitionSlipServices
    Private _repo As New PropsFields.Create_Requesition_Slip
    Dim customMsg As New customMessageBox
    Public Function ExecuteWithReturnTrue(rsData As PropsFields.Create_Requesition_Slip) As Boolean
        Try
            _repo = rsData
            Dim CREATERSMODEL As New CreateRsModel
            Dim result As Boolean = CREATERSMODEL.update_requisition(_repo)

            If isHaveNoAccountTitleSub() Then
                'logic here
                executeTypeOfRequest_withoutAcountTitleSub(rsData.rs_id, _repo.tor_sub_id)
                Return result
                Exit Function
            End If

            'update type of request
            executeTypeOfRequest(rsData.rs_id, _repo.tors_ca_id)

bypasshere:
            Return result
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

    End Function

    Private Function isHaveNoAccountTitleSub() As Boolean
        Try
            If _repo.tor_sub_id > 0 And _repo.tors_ca_id = 0 Then
                Return True
            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function
    Private Sub executeTypeOfRequest_withoutAcountTitleSub(rs_id As Integer, tor_sub_id As Integer)
        Try
            Dim CREATERSMODEL As New CreateRsModel
            CREATERSMODEL.update_typeOfRequest_without_accountTitleSub(rs_id, tor_sub_id)

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub executeTypeOfRequest(rs_id As Integer, tors_ca_id As Integer)
        Try
            Dim CREATERSMODEL As New CreateRsModel
            CREATERSMODEL.update_typeOfRequest(rs_id, tors_ca_id)

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
End Class
