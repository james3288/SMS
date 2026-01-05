Partial Class DataSet_all_type
    Partial Public Class DataTable1DataTable
        Private Sub DataTable1DataTable_ColumnChanging(sender As Object, e As DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.Net_Revenue_WithoutColumn.ColumnName) Then

            End If

        End Sub

    End Class
End Class
