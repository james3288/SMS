Interface CustomListView

    Sub addColumns(columnName As ColumnHeader)
    Sub initializeListView(paramLvl As ListView)
    Sub rearrangeTabIndex()

End Interface

Public Class ListTabIndex
    Implements CustomListView
    Private cCustomMsg As New customMessageBox
    Private Property listview As New ListView
    Private cListOfColName As New List(Of ColumnHeader)

    Public Sub initializeListView(paramLvl As ListView) Implements CustomListView.initializeListView
        listview = paramLvl
    End Sub

    Public Sub rearrangeTabIndex() Implements CustomListView.rearrangeTabIndex
        Try
            For Each columnHeader As ColumnHeader In cListOfColName
                columnHeader.DisplayIndex = cListOfColName.IndexOf(columnHeader)
            Next
        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try
    End Sub

    Public Sub addColumns(colName As ColumnHeader) Implements CustomListView.addColumns
        Try
            cListOfColName.Add(colName)
        Catch ex As Exception
            cCustomMsg.ErrorMessage(ex)
        End Try

    End Sub


End Class
