Public Class CustomSaved
    Private paramData As New Dictionary(Of String, Object)
    Private customMsg As New customMessageBox

    Public Sub addParameter(key As Object, value As String)
        Try
            paramData.Add(key, value)
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Public ReadOnly Property getParamData() As Dictionary(Of String, Object)
        Get
            Return paramData
        End Get
    End Property


End Class
