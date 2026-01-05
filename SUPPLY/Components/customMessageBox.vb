Public Class customMessageBox

    Public Sub message(errStatus As String, message As String, msgTitle As String)

        Select Case errStatus
            Case "error"
                MessageBox.Show(message, msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Case "warning"
                MessageBox.Show(message, msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Case "info"
                MessageBox.Show(message, msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

        End Select

    End Sub

    Public Function ErrorMessage(Optional ex As Exception = Nothing)
        MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)

    End Function

    Public Function messageYesNo(message As String, msgTitle As String, Optional msgBoxIcon As MessageBoxIcon = MessageBoxIcon.Question)
        If MessageBox.Show(message, msgTitle, MessageBoxButtons.YesNo, msgBoxIcon) = DialogResult.Yes Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function messageYesNoCancel(message As String, msgTitle As String, Optional msgBoxIcon As MessageBoxIcon = MessageBoxIcon.Question) As Integer
        Dim msgResult = MessageBox.Show(message, msgTitle, MessageBoxButtons.YesNoCancel, msgBoxIcon)

        If msgResult = DialogResult.Yes Then
            Return msgResult
        ElseIf msgResult = DialogResult.No Then
            Return msgResult
        Else
            Return DialogResult.Cancel
        End If
    End Function

End Class
