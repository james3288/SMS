Imports System.Data.SqlClient
Imports System.Windows

Public Class ColumnValuesObj
    Private cValues As New Dictionary(Of String, Object)
    Private cJoinClauses As New List(Of String)
    Private cColumns As New List(Of String)
    Private cCondition As String = ""
    Private cCustomMsg As New customMessageBox
    Private cListOfTables As New List(Of PropsFields.SMSTables)

    Public Sub addTableAndCondition(tableName As String, condition As String)
        Dim _table As New PropsFields.SMSTables
        With _table
            .table = tableName
            .condtion = condition
        End With

        cListOfTables.Add(_table)
    End Sub

    Public Sub add(key As String, value As Object)
        cValues.Add(key, value)
    End Sub

    Public Sub addColumn(colValue As String)
        cColumns.Add(colValue)
    End Sub

    Public Sub parameterToUpdate(key As String, value As Object)
        cValues.Add(key, value)
    End Sub

    Public Sub addJoinClause(clause As String)
        cJoinClauses.Add(clause)
    End Sub

    Public Sub setCondition(condition As String)
        cCondition = condition
    End Sub

    Public Function getValues()
        Return cValues
    End Function
    Public ReadOnly Property getListOfTables()
        Get
            Return cListOfTables
        End Get
    End Property
    Public Function getJoinClauses()
        Return cJoinClauses
    End Function

    Public Function getCondition()
        Return cCondition
    End Function

    Public Sub clearParameter()
        cValues = New Dictionary(Of String, Object)
        cJoinClauses = New List(Of String)
    End Sub

    Public Sub clearListOfTables()
        cListOfTables.Clear()
    End Sub

    Public Sub selectQuery(Optional firstTable As String = "",
                           Optional multipleTable As Boolean = False,
                           Optional myAlias As String = "",
                           Optional tableNameType As String = ""
                           )

        Dim c As New Model_Dynamic_Select

        Dim table As String = $"{firstTable}" 'table
        Dim condition As String = $"{cCondition}" 'conditions

        c.setTableNameType(tableNameType)
        c.select_query_joinTable(table, cColumns, myAlias, cJoinClauses, cCondition)

    End Sub

    Public Function selectQuery_builder_pattern(builder As PropsFields.SelectDynamic) As Object

        Dim c As New Model_Dynamic_Select
        c.setTableNameType(builder.dbSource)
        Return c.select_query_joinTable(builder.defaultTable,
                                 builder.columns,
                                 builder.myAlias,
                                 builder.joinClause,
                                 builder.condition)


    End Function

    Public Function selectQuery_and_return_data(Optional firstTable As String = "",
                           Optional multipleTable As Boolean = False,
                           Optional myAlias As String = "",
                           Optional tableNameType As String = ""
                           )

        Dim c As New Model_Dynamic_Select

        Dim table As String = $"{firstTable}" 'table
        Dim condition As String = $"{cCondition}" 'conditions

        c.setTableNameType(tableNameType)
        selectQuery_and_return_data = c.select_query_joinTable(table, cColumns, myAlias, cJoinClauses, cCondition)

    End Function


    Public Sub updateQuery(Optional firstTable As String = "", Optional multipleTable As Boolean = False)

        Dim c As New Model_King_Dynamic_Update()

        If cCondition = "" Then
            cCustomMsg.message("error", "you must set a where condition first...", "SUPPLY INFO:")
            Exit Sub
        End If

        If multipleTable = True Then
            c.UpdateDataByTableJoin($"{firstTable}", cValues, cCondition, cJoinClauses)
        Else
            c.UpdateData(firstTable, cValues, cCondition)
        End If

    End Sub

    Public Function updateQuery_return_true(Optional firstTable As String = "",
                                            Optional multipleTable As Boolean = False) As Boolean

        Dim c As New Model_King_Dynamic_Update()

        If cCondition = "" Then
            cCustomMsg.message("error", "you must set a where condition first...", "SUPPLY INFO:")
            Exit Function
        End If

        updateQuery_return_true = c.UpdateData_and_return_true(firstTable, cValues, cCondition)

    End Function

    Public Sub deleteData(Optional table As String = "")
        Dim c As New Model_King_Dynamic_Update()

        c.DeleteData(table, cCondition)

    End Sub

    Public Sub deleteDataUsingRollback(listOfTable As List(Of PropsFields.SMSTables))
        Dim transaction As SqlTransaction = Nothing
        Dim c As New Model_King_Dynamic_Update()
        Dim SQCon As New SQLcon
        Try

            SQCon.connection.Open()

            transaction = SQCon.connection.BeginTransaction()

            For Each table In listOfTable
                Dim deleteQuery As String = $"DELETE FROM {table.table} WHERE {table.condtion}"
                Dim deleteCommand As New SqlCommand(deleteQuery, SQCon.connection, transaction)

                deleteCommand.ExecuteNonQuery()
            Next

            transaction.Commit()

        Catch ex As Exception
            transaction.Rollback()
            cCustomMsg.ErrorMessage(ex)
        Finally
            SQCon.connection.Close()
        End Try
    End Sub

    Public Sub insertQuery(Optional firstTable As String = "")
        Dim c As New Model_King_Dynamic_Update()

        c.InsertData(firstTable, cValues)
    End Sub

    Public Function insertQuery_and_return_id(Optional firstTable As String = "") As Integer
        Dim c As New Model_King_Dynamic_Update()

        insertQuery_and_return_id = c.InsertData_and_return_id(firstTable, cValues)
    End Function

    Public Function insertQueryRollBack_and_return_id(Optional firstTable As String = "",
                                                      Optional SQCON As SQLcon = Nothing,
                                                      Optional TRANSACTION As SqlTransaction = Nothing) As Integer
        Dim c As New Model_King_Dynamic_Update()

        insertQueryRollBack_and_return_id = c.InsertDataWithRollBack_and_return_id(firstTable,
                                                                                   cValues,
                                                                                   SQCON,
                                                                                   TRANSACTION)
    End Function

    Public Function updateQueryRollBack_and_return_true(Optional firstTable As String = "",
                                                  Optional SQCON As SQLcon = Nothing,
                                                  Optional TRANSACTION As SqlTransaction = Nothing) As Boolean
        Dim c As New Model_King_Dynamic_Update()

        If cCondition = "" Then
            cCustomMsg.message("error", "you must set a where condition first...", "SUPPLY INFO:")
            Exit Function
        End If

        updateQueryRollBack_and_return_true = c.UpdatetDataWithRollBack_and_return_true(firstTable,
                                                                                   cValues,
                                                                                   cCondition,
                                                                                   SQCON,
                                                                                   TRANSACTION)
    End Function

End Class
