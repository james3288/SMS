Public Class ColumnSettingsLib
    Private cDgv As New DataGridView
    Private customMsg As New customMessageBox
    Private cListOfColumnName As New List(Of String)
    Public Sub setDatagridview(dgv As DataGridView)
        cDgv = dgv
    End Sub
    Public Sub hideColumn(columnName As String)
        Try
            cDgv.Columns(columnName).Visible = False
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

    End Sub
    Public Sub ShowColumn(columnName As String)
        Try
            cDgv.Columns(columnName).Visible = True
            cListOfColumnName.Add(columnName)

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Public ReadOnly Property getListofColumnName() As List(Of String)
        Get
            Return cListOfColumnName
        End Get
    End Property

    Public Sub clear()
        cListOfColumnName.Clear()
    End Sub
End Class
