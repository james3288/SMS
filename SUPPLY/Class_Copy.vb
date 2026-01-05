Public Class Class_Copy
    Sub New()

    End Sub

    Public Function calc_cut_request(lvl As ListView, rs_no As String) As Decimal
        Dim sum As Decimal

        For Each row As ListViewItem In lvl.Items
            If row.BackColor = Color.DarkGreen Then
                If row.SubItems(1).Text = rs_no Then
                    sum += row.SubItems(5).Text
                End If
            End If
        Next

        calc_cut_request = sum
    End Function

    Public Function get_remaining_balance(main_rs_qty_id As Integer, rs_no As String) As Double
        Dim remaining_b As New class_main_rs_qty

        Dim listofmainrs = remaining_b.LISTOFMAINRS(rs_no)
        Dim listofmainrs_sub = remaining_b.LISTOFMAINRS_SUB(rs_no)

        Dim remaining_balance As Double = remaining_b.copy_get_remaining_balance(listofmainrs, listofmainrs_sub, FRequistionForm.cAggregates, main_rs_qty_id)

        Return remaining_balance
    End Function

End Class
