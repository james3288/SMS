Public Class CreateRequesitionSlipChargesServices

    Private _repo As New PropsFields.AllCharges
    Dim customMsg As New customMessageBox
    Public Function ExecuteWithReturnId(charges As PropsFields.AllCharges,
                                        Optional rs_id As Integer = 0) As Integer
        Try
            _repo = charges
            Dim CREATERSMODEL As New CreateRsModel
            Dim id As Integer = CREATERSMODEL.save_charges(_repo, rs_id)
            Return id
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

    End Function
End Class
