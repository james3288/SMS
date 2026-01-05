Public Class deleteChargesServices
    Dim customMsg As New customMessageBox
    Public Function ExecuteWithReturnBoolean(charges_id As Integer) As Boolean
        Try
            Dim CREATECHARGESMODEL As New CreateChargesModel
            Dim deleteResult As Boolean = CREATECHARGESMODEL.deleteCharges(charges_id)
            Return deleteResult
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

    End Function
End Class
