Public Class ColumnValues
    Private cValues As New Dictionary(Of String, String)

    Public Sub add(key As String, value As String)
        cValues.Add(key, value)
    End Sub

    Public Function getValues()
        Return cValues
    End Function

    Public Sub clearParameter()
        cValues = New Dictionary(Of String, String)
    End Sub
End Class
