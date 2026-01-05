Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Windows
Public Class Model_Dynamic_Select

    Private cTableName As String
    Private cJoin As String
    Private cCondition As String
    Private cQuery As String
    Private cListView As New ListView
    Private cColumns As String
    Public cJoinColumns As String
    Public cJoining As String
    Private cConnection As String
    Private cTableNameType As New tableNameType

    Sub New()
        cJoinColumns = ""
    End Sub

    Public Sub setTableNameType(tableNameType As String)
        cConnection = tableNameType
    End Sub

    Public Sub _initialize(Optional tablename As String = "",
                           Optional condition As String = "",
                           Optional columns As String = "*",
                           Optional join As String = "",
                           Optional paramConnection As String = "")

        cTableName = tablename
        cCondition = condition
        cColumns = columns
        cJoin = join
        cConnection = paramConnection

    End Sub
    Public Function select_query() As List(Of Object)
        select_query = New List(Of Object)

        Dim SQ As New SQLcon
        Dim newSQ As New SQLcon
        Dim newCMD As New SqlCommand
        Dim dr As SqlDataReader

        Try
            If cConnection = cTableNameType.eus_table Then
                SQ.connection1.Open()
            Else
                SQ.connection.Open()
            End If

            ' Your dynamic query
            Dim selectQuery As String = $"SELECT {cColumns} FROM {cTableName} {cJoin} WHERE {cCondition}"

            newCMD = New SqlCommand(selectQuery, IIf(cConnection = cTableNameType.eus_table, SQ.connection1, SQ.connection))

            dr = newCMD.ExecuteReader()

            While dr.Read()
                Dim dic As New Dictionary(Of String, Object)

                For columnIndex As Integer = 0 To dr.FieldCount - 1
                    Dim columnName As String = dr.GetName(columnIndex)
                    Dim columnValue As Object = dr.GetValue(columnIndex)

                    ' Add the column name and value to the dictionary

                    dic.Add(columnName, columnValue)
                Next
                select_query.Add(dic)

            End While
            dr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally

            If cConnection = cTableNameType.eus_table Then
                SQ.connection1.Close()
            Else
                SQ.connection.Close()
            End If
        End Try
    End Function

    Public Function select_query_joinTable(tableName As String,
                                           columnValues As List(Of String),
                                           Optional tableAlias As String = "",
                                           Optional joinClauses As List(Of String) = Nothing,
                                           Optional condition As String = "") As List(Of Object)

        select_query_joinTable = New List(Of Object)

        Dim newSQ As New SQLcon
        Dim newCMD As New SqlCommand
        Dim dr As SqlDataReader

        Try
            If cConnection = cTableNameType.eus_table Then
                newSQ.connection1.Open()
            Else
                newSQ.connection.Open()
            End If

            ' Start building the UPDATE query with the "FROM" and the main table alias
            Dim query As String = $"SELECT {GetUpdateColumns(columnValues)}"

            ' Add the "FROM" clause with alias (if needed)
            query &= $" FROM {tableName} {tableAlias}" ' Here, "a" is the alias for the table

            ' Add the JOIN clauses
            If joinClauses IsNot Nothing AndAlso joinClauses.Count > 0 Then
                For Each joinClause As String In joinClauses
                    query &= " " & joinClause ' Add each join clause (INNER, LEFT, etc.)
                Next
            End If

            ' Add the WHERE condition
            query &= $" WHERE {condition}"

            ' Prepare the SQL command with the query
            Dim updateCommand As New SqlCommand(query, IIf(cConnection = cTableNameType.eus_table, newSQ.connection1, newSQ.connection))
            dr = updateCommand.ExecuteReader()

            While dr.Read()
                Dim dic As New Dictionary(Of String, Object)

                For columnIndex As Integer = 0 To dr.FieldCount - 1
                    Dim columnName As String = dr.GetName(columnIndex)
                    Dim columnValue As Object = dr.GetValue(columnIndex)

                    ' Add the column name and value to the dictionary

                    dic.Add(columnName, columnValue)
                Next
                select_query_joinTable.Add(dic)

            End While
            dr.Close()


        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function

    Private Function GetUpdateColumns(columnValues As List(Of String)) As String
        Dim updateColumns As List(Of String) = columnValues.Select(Function(value)
                                                                       Return $"{value}"
                                                                   End Function).ToList()
        Return String.Join(", ", updateColumns.ToArray())

    End Function
    Public Function getList() As List(Of Object)
        getList = select_query()
    End Function
    Public Sub display(Optional ListView As ListView = Nothing, Optional no_of_column As Integer = 0)
        cListView = ListView
        cListView.Items.Clear()

        Dim l As New List(Of Object)
        l = select_query()

        For Each row In l
            Dim n As Integer = 0
            Dim a(no_of_column) As String

            For Each kvp As KeyValuePair(Of String, Object) In row
                'MsgBox($"{kvp.Key}: {kvp.Value.ToString()}")
                a(n) = kvp.Value.ToString()

                If n = no_of_column Then
                    Dim lvl As New ListViewItem(a)
                    cListView.Items.Add(lvl)
                    Exit For
                End If

                n += 1
            Next
        Next
    End Sub

    Public Function join_columns(columnName As String)
        cJoinColumns &= columnName & vbCrLf
    End Function

    Public Function joining(joinName As String)
        cJoining &= joinName & vbCrLf
    End Function
End Class
