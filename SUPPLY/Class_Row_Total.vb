Public Class Class_Row_Total
    Dim list_of_rs_id As String
    Sub New(lvl As ListView)
        rr_total(lvl)
    End Sub

    Private Sub rr_total(lvl As ListView)
        Dim main_rs_qty, new_rs_qty As Double

        For Each row As ListViewItem In lvl.Items
            If row.BackColor = Color.DarkGreen Then
                list_of_rs_id &= row.Text & "-"

            ElseIf row.BackColor = Color.Lime Then
                main_rs_qty = IIf(row.SubItems(5).Text = "open-qty", 0, row.SubItems(5).Text)
            End If
        Next

        If list_of_rs_id = "" Then
            Exit Sub
        End If

        list_of_rs_id = list_of_rs_id.Substring(0, list_of_rs_id.Length - 1)

        Dim aa() As String
        aa = list_of_rs_id.Split("-")

        For Each rs_id As String In aa
            'MsgBox(rs_id)
            Dim total As Decimal
            Dim po_qty As Decimal
            Dim inout As String = ""
            Dim type_of_purchasing As String = ""
            Dim rs_qty As Decimal

            For Each row As ListViewItem In lvl.Items
                If row.BackColor = Color.LightPink Then 'LIGHTPINK
                    If row.Text = rs_id Then
                        'MsgBox(rs_id & ": " & row.SubItems(23).Text)
                        total += CDec(row.SubItems(23).Text)
                    End If

                ElseIf row.BackColor = Color.LightGreen Then 'LIGHTGREEN

                    If row.Text = rs_id Then
                        total = 0
                        total += CDec(row.SubItems(23).Text)
                        po_qty = row.SubItems(22).Text
                    End If

                ElseIf row.BackColor = Color.DarkGreen Then 'DARKGREEN
                    po_qty = 0
                    If row.Text = rs_id Then
                        inout = row.SubItems(9).Text
                        type_of_purchasing = row.SubItems(18).Text
                        rs_qty = row.SubItems(5).Text
                    End If

                ElseIf row.BackColor = Color.White Then 'WHITE
                    If row.Text = rs_id Then
                        Select Case inout
                            Case "OUT"
                                row.SubItems(23).Text = total
                            Case "IN", "OTHERS"
                                If type_of_purchasing = "CASH WITH RR" Then
                                    row.SubItems(23).Text = total & " out of " & rs_qty
                                Else
                                    row.SubItems(23).Text = total & " out of " & po_qty
                                End If
                        End Select
                    End If
                End If

            Next

            'MsgBox(total_rr)
            total = 0
        Next

        'REMAINING BALANCE
        For Each row As ListViewItem In lvl.Items

            If row.BackColor = Color.Lime Then
                main_rs_qty = IIf(row.SubItems(5).Text = "open-qty", 0, row.SubItems(5).Text)

            ElseIf row.BackColor = Color.DarkGreen Then
                If main_rs_qty = 0 Then
                    new_rs_qty = row.SubItems(5).Text
                Else
                    main_rs_qty -= row.SubItems(5).Text
                End If

            ElseIf row.BackColor = Color.White Then
                If main_rs_qty = 0 Then
                    row.SubItems(5).Text = new_rs_qty
                Else
                    row.SubItems(5).Text = main_rs_qty
                End If

            End If

        Next
    End Sub

End Class
