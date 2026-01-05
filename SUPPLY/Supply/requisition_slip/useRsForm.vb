

Interface RSFORM
    Sub initialized(Optional param As PropsFields.rsFormParam_props_fields = Nothing)
    Function countReceivedItem(Optional index As Integer = 0) As Integer

End Interface

Public Class useRsForm
    Implements RSFORM
    Private cDatas As New PropsFields.rsFormParam_props_fields
    Private customMsg As New customMessageBox
    Public Sub initialized(Optional param As PropsFields.rsFormParam_props_fields = Nothing) Implements RSFORM.initialized
        cDatas = param
    End Sub
    Public Function countReceivedItem(Optional index As Integer = 0) As Integer Implements RSFORM.countReceivedItem
        Try
            For Each row As ListViewItem In cDatas.lvl.Items
                If row.BackColor = cRsRowColor_Supply.Rr Then
                    If row.SubItems(index).Text = cDatas.id Then
                        countReceivedItem += 1
                    End If
                End If
            Next
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function
End Class
