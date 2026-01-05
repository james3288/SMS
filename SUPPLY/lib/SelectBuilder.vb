Public Class SelectBuilder
    Private _select As New PropsFields.SelectDynamic

    Public Function setDefaultTable(tableName As String) As SelectBuilder
        _select.defaultTable = tableName
        Return Me
    End Function

    Public Function setMultipleTable(mt As Boolean) As SelectBuilder
        _select.isMultipleTable = mt
        Return Me
    End Function

    Public Function setMyAlias(myAlias As String) As SelectBuilder
        _select.myAlias = myAlias
        Return Me
    End Function

    Public Function setDbSource(dbsource As String) As SelectBuilder
        _select.dbSource = dbsource
        Return Me
    End Function
    Public Function setJoinClause(joinClause As List(Of String)) As SelectBuilder
        _select.joinClause = joinClause
        Return Me
    End Function

    Public Function setCondition(condition As String) As SelectBuilder
        _select.condition = condition
        Return Me
    End Function

    Public Function setColumns(columns As List(Of String)) As SelectBuilder
        _select.columns = columns
        Return Me
    End Function

    Public Function Build() As PropsFields.SelectDynamic
        Return _select
    End Function


End Class
