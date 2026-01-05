Public Class Class_RR
    Public Function total_received(rs_id As Integer, lvl As ListView) As Decimal
        For Each row As ListViewItem In lvl.Items
            If row.Text = rs_id Then
                If row.BackColor = Color.LightPink Then
                    total_received += row.SubItems(23).Text
                End If
            End If
        Next

    End Function

    Public Function total_received_po(po_det_id As Integer, lvl As ListView) As Decimal
        For Each row As ListViewItem In lvl.Items
            If row.BackColor = Color.LightPink Then
                If row.SubItems(35).Text = po_det_id Then
                    total_received_po += row.SubItems(23).Text
                End If
            End If

        Next

    End Function

    Public Function po_qty(lvl As ListView) As Decimal
        po_qty = lvl.SelectedItems(0).SubItems(22).Text
    End Function

End Class
