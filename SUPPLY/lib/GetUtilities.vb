Module GetUtilities

    'get users
    Private customMsg As New customMessageBox
    Public Function getUsers(listOfUsers As List(Of PropsFields.smsUsers_props_fields), userId As Integer) As String
        Try
            If listOfUsers.Count > 0 Then
                Dim user = listOfUsers.FirstOrDefault(Function(x) x.user_id = userId)
                If user IsNot Nothing Then
                    getUsers = $"{user.lName}, {user.fName}"
                End If
            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function
End Module
