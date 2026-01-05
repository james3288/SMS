Public Class ListOfTables
    Private cListOfTable As New List(Of PropsFields.SMSTables)
    Private customMsg As New customMessageBox


    Public ReadOnly Property getListOfTables As List(Of PropsFields.SMSTables)
        Get
            Return cListOfTable
        End Get
    End Property

    Public Sub addTable(table As String, condition As String)
        Try
            Dim smsTables As New PropsFields.SMSTables

            With smsTables
                .table = table
                .condtion = condition
            End With

            cListOfTable.Add(smsTables)

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

End Class
