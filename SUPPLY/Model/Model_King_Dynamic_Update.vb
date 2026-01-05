Imports System.Data.SqlClient
Imports System.Linq
Imports System.Web.Util
Imports System.Windows
Public Class Model_King_Dynamic_Update
    'DYNAMIC DELETE
    Public Sub DeleteData(tableName As String, condition As String)
        Dim newSQ As New SQLcon
        Try
            newSQ.connection.Open()

            ' Define your DELETE query with a WHERE clause based on the condition
            Dim deleteQuery As String = $"DELETE FROM {tableName} WHERE {condition}"
            Dim deleteCommand As New SqlCommand(deleteQuery, newSQ.connection)

            ' Execute the DELETE command
            deleteCommand.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Public Sub DeleteDataUsingRollBack(tableName As String, condition As String, sq As SQLcon, transaction As SqlTransaction)

        Try
            ' Define your DELETE query with a WHERE clause based on the condition
            Dim deleteQuery As String = $"DELETE FROM {tableName} WHERE {condition}"
            Dim deleteCommand As New SqlCommand(deleteQuery, sq.connection, transaction)

            ' Execute the DELETE command
            deleteCommand.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'DYNAMIC INSERT
    Public Sub InsertData(tableName As String, columnValues As Dictionary(Of String, Object))
        Dim newSQ As New SQLcon
        Try
            newSQ.connection.Open()

            ' Define your INSERT query with placeholders for parameters
            Dim insertQuery As String = $"INSERT INTO {tableName} ({GetInsertColumns(columnValues)}) VALUES ({GetInsertValues(columnValues)})"
            Dim insertCommand As New SqlCommand(insertQuery, newSQ.connection)

            ' Add parameters for each column value
            For Each kvp As KeyValuePair(Of String, Object) In columnValues
                insertCommand.Parameters.AddWithValue($"@{kvp.Key}", check_paramater(kvp.Value))
            Next

            ' Execute the INSERT command
            insertCommand.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Public Function InsertData_and_return_id(tableName As String, columnValues As Dictionary(Of String, Object)) As Integer
        Dim newSQ As New SQLcon
        Try
            newSQ.connection.Open()

            ' Define your INSERT query with placeholders for parameters
            Dim insertQuery As String = $"SET NOCOUNT ON INSERT INTO {tableName} ({GetInsertColumns(columnValues)}) VALUES ({GetInsertValues(columnValues)}) SELECT SCOPE_IDENTITY()"
            Dim insertCommand As New SqlCommand(insertQuery, newSQ.connection)

            ' Add parameters for each column value
            For Each kvp As KeyValuePair(Of String, Object) In columnValues
                insertCommand.Parameters.AddWithValue($"@{kvp.Key}", check_paramater(kvp.Value))
            Next

            ' Execute the INSERT command
            InsertData_and_return_id = insertCommand.ExecuteScalar()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function

    'ROLLBACK
    Public Function InsertDataWithRollBack_and_return_id(tableName As String,
                                                         columnValues As Dictionary(Of String, Object),
                                                         Optional SQConnection As SQLcon = Nothing,
                                                         Optional transaction As SqlTransaction = Nothing) As Integer
        'Dim newSQ As New SQLcon
        Try
            ' Define your INSERT query with placeholders for parameters
            Dim insertQuery As String = $"SET NOCOUNT ON INSERT INTO {tableName} ({GetInsertColumns(columnValues)}) VALUES ({GetInsertValues(columnValues)}) SELECT SCOPE_IDENTITY()"
            Dim insertCommand As New SqlCommand(insertQuery, SQConnection.connection, transaction)

            ' Add parameters for each column value
            For Each kvp As KeyValuePair(Of String, Object) In columnValues
                insertCommand.Parameters.AddWithValue($"@{kvp.Key}", check_paramater(kvp.Value))
            Next

            ' Execute the INSERT command
            InsertDataWithRollBack_and_return_id = insertCommand.ExecuteScalar()
        Catch ex As Exception
            'apply rollback if its failed to execute
            If transaction IsNot Nothing Then
                transaction.Rollback()
            End If
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Public Function UpdatetDataWithRollBack_and_return_true(tableName As String,
                                                         columnValues As Dictionary(Of String, Object),
                                                         condition As String,
                                                         Optional SQConnection As SQLcon = Nothing,
                                                         Optional transaction As SqlTransaction = Nothing) As Integer
        'Dim newSQ As New SQLcon
        Try
            Dim updateQuery As String = $"UPDATE {tableName} SET {GetUpdateColumns(columnValues)} WHERE {condition}"
            Dim updateCommand As New SqlCommand(updateQuery, SQConnection.connection, transaction)

            ' Add parameters for each column value
            For Each kvp As KeyValuePair(Of String, Object) In columnValues
                updateCommand.Parameters.AddWithValue($"@{kvp.Key}", check_paramater(kvp.Value))
            Next

            updateCommand.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            'apply rollback if its failed to execute
            If transaction IsNot Nothing Then
                transaction.Rollback()
            End If
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    'DYNAMIC UPDATE
    Public Sub UpdateData(tableName As String, columnValues As Dictionary(Of String, Object), condition As String)
        Dim newSQ As New SQLcon
        Try
            newSQ.connection.Open()
            Dim updateQuery As String = $"UPDATE {tableName} SET {GetUpdateColumns(columnValues)} WHERE {condition}"
            Dim updateCommand As New SqlCommand(updateQuery, newSQ.connection)

            For Each kvp As KeyValuePair(Of String, Object) In columnValues
                updateCommand.Parameters.AddWithValue($"@{kvp.Key}", check_paramater(kvp.Value))
            Next

            updateCommand.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub

    Public Function UpdateData_and_return_true(tableName As String, columnValues As Dictionary(Of String, Object), condition As String) As Boolean
        Dim newSQ As New SQLcon
        Try
            newSQ.connection.Open()
            Dim updateQuery As String = $"UPDATE {tableName} SET {GetUpdateColumns(columnValues)} WHERE {condition}"
            Dim updateCommand As New SqlCommand(updateQuery, newSQ.connection)

            For Each kvp As KeyValuePair(Of String, Object) In columnValues
                updateCommand.Parameters.AddWithValue($"@{kvp.Key}", check_paramater(kvp.Value))
            Next

            updateCommand.ExecuteNonQuery()
            UpdateData_and_return_true = True
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            UpdateData_and_return_true = False
        Finally
            newSQ.connection.Close()
        End Try

    End Function
    Public Sub UpdateDataByTableJoin(tableName As String, columnValues As Dictionary(Of String, Object), condition As String, joinClauses As List(Of String))
        Dim newSQ As New SQLcon
        Try
            newSQ.connection.Open()

            ' Start building the UPDATE query with the "FROM" and the main table alias
            Dim updateQuery As String = $"UPDATE a SET {GetUpdateColumns(columnValues)}"

            ' Add the "FROM" clause with alias (if needed)
            updateQuery &= $" FROM {tableName} a" ' Here, "a" is the alias for the table

            ' Add the JOIN clauses
            If joinClauses IsNot Nothing AndAlso joinClauses.Count > 0 Then
                For Each joinClause As String In joinClauses
                    updateQuery &= " " & joinClause ' Add each join clause (INNER, LEFT, etc.)
                Next
            End If

            ' Add the WHERE condition
            updateQuery &= $" WHERE {condition}"

            ' Prepare the SQL command with the query
            Dim updateCommand As New SqlCommand(updateQuery, newSQ.connection)

            ' Add parameters for each column-value pair
            For Each kvp As KeyValuePair(Of String, Object) In columnValues
                updateCommand.Parameters.AddWithValue($"@{kvp.Key}", check_paramater(kvp.Value))
            Next

            ' Execute the query
            updateCommand.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub
    Private Function GetInsertColumns(columnValues As Dictionary(Of String, Object)) As String
        Dim columnNames As New List(Of String)

        For Each kvp As KeyValuePair(Of String, Object) In columnValues
            columnNames.Add(kvp.Key)
        Next

        ' Convert the list of column names to an array of strings and join them with commas
        Return String.Join(", ", columnNames.ToArray())

    End Function

    Private Function GetInsertValues(columnValues As Dictionary(Of String, Object)) As String
        Dim valuePlaceholders As New List(Of String)

        For Each kvp As KeyValuePair(Of String, Object) In columnValues
            valuePlaceholders.Add($"@{kvp.Key}")
        Next

        ' Convert the list of value placeholders to a comma-separated string
        Return String.Join(", ", valuePlaceholders.ToArray())

    End Function

    Private Function GetUpdateColumns(columnValues As Dictionary(Of String, Object)) As String
        Dim updateColumns As List(Of String) = columnValues.Select(Function(kvp)
                                                                       If kvp.Value Is Nothing Then
                                                                           Return $"{kvp.Key} = NULL"
                                                                       Else
                                                                           Return $"{kvp.Key} = @{kvp.Key}"
                                                                       End If
                                                                   End Function).ToList()
        Return String.Join(", ", updateColumns.ToArray())

    End Function

    Private Function check_paramater(data As Object)
        'If TypeOf data Is String Then
        '    Dim str As String = data
        '    Return str
        'ElseIf TypeOf data Is Integer Then
        '    Dim int As Integer = data
        '    Return int
        'ElseIf TypeOf data Is Double Then
        '    Dim doub As Double = data
        '    Return doub
        'ElseIf TypeOf data Is DateTime Then
        '    Dim datetime As DateTime = Date.Parse(data)
        '    Return datetime
        'End If


        If data Is Nothing Then
            Return DBNull.Value
        End If

        If TypeOf data Is String Then
            Return CStr(data)
        ElseIf TypeOf data Is Integer Then
            Return CInt(data)
        ElseIf TypeOf data Is Double Then
            Return CDbl(data)
        ElseIf TypeOf data Is DateTime Then
            Return CDate(data)
        Else
            ' Default: just return the original or convert to DBNull if needed
            Return data
        End If

    End Function

    Public Function setColumnValues(value As String) As Dictionary(Of String, Object)

    End Function

End Class
