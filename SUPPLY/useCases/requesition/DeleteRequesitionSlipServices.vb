Public Class DeleteRequesitionSlipServices

    Dim customMsg As New customMessageBox

    Public Function ExecuteWithReturnBoolean(rsData As RSDRModel.COLUMNS) As Boolean
        Try
            Dim remove_rs As New CreateRsModel

            Dim removed As Boolean = remove_rs.remove_requesition(rsData)

            Return removed

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

End Class
