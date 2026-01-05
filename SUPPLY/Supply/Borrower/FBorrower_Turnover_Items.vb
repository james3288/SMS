Imports System.Data.SqlClient
Imports System.Data.Sql

Public Class FBorrower_Turnover_Items

    Dim rowind As Integer
    Dim old_qty_to_be_received As Integer
    Public txtname As String

    Public listboxname As String
    Private Sub DataGridView1_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles DataGridView1.CellBeginEdit

        Try

            rowind = Format(get_datagrid_rowindex)
            old_qty_to_be_received = check_if_numeric(DataGridView1.Rows(Format(rowind)).Cells("Column4").Value)

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Public Function get_datagrid_rowindex() As Integer

        For i As Integer = 0 To Me.DataGridView1.SelectedCells.Count - 1
            get_datagrid_rowindex = Me.DataGridView1.SelectedCells.Item(i).RowIndex
        Next
    End Function

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit

        If if_numeric(DataGridView1.Rows(rowind).Cells("column4").Value) = False Then

            MessageBox.Show("desired qty must numeric.", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
            DataGridView1.Rows(rowind).Cells("column4").Value = old_qty_to_be_received

            Exit Sub

        End If

        Dim des_qty As Integer = IIf(if_numeric(DataGridView1.Rows(rowind).Cells("column4").Value) = False, 0, DataGridView1.Rows(rowind).Cells("column4").Value)
        Dim act_qty As Integer = check_if_numeric(DataGridView1.Rows(rowind).Cells("column3").Value)

        If act_qty < des_qty Then
            MessageBox.Show("qty to be returned must not exceed on the actual qty.", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
            DataGridView1.Rows(rowind).Cells("column4").Value = old_qty_to_be_received
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim count As Integer

        For i = 0 To DataGridView1.Rows.Count - 1
            count += 1
        Next

        If count = 0 Then
            MessageBox.Show("No item found...", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        If MessageBox.Show("Are you sure you want to return this item?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim to_items_id As Integer = insert_to_borrower_turnover_info()

            With DataGridView1
                For i = 0 To .Rows.Count - 1
                    Dim br_tr_det_id As Integer = .Rows(i).Cells("Column7").Value
                    Dim qty_to_be_received As Integer = .Rows(i).Cells("Column4").Value
                    Dim item_stat As String = .Rows(i).Cells("Column5").Value
                    Dim rs_id As Integer = .Rows(i).Cells("Column8").Value

                    If .Rows(i).Cells("column6").Value = True Then
                        insert_to_dbborrower_turnover_details(br_tr_det_id, to_items_id, qty_to_be_received, item_stat, rs_id)
                    End If
                Next

            End With

            MessageBox.Show("Item was successfully turnover...", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        FBorrower_History.load_borrower_history()
        Me.Close()

    End Sub

    Public Sub insert_to_dbborrower_turnover_details(ByVal br_tr_det_id As Integer, ByVal to_items_id As Integer, ByVal qty As Integer, ByVal item_stat As String, ByVal req_id As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_borrower_new", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 7)
            newCMD.Parameters.AddWithValue("@br_tr_det_id", br_tr_det_id)
            newCMD.Parameters.AddWithValue("@to_items_id", to_items_id)
            newCMD.Parameters.AddWithValue("@qty", qty)

            If rs_id <> 0 Then
                newCMD.Parameters.AddWithValue("@rs_id", rs_id)
            Else
                newCMD.Parameters.AddWithValue("@rs_id", req_id)
            End If

            newCMD.Parameters.AddWithValue("@item_stat", item_stat)
            newCMD.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
            GC.Collect()

        End Try
    End Sub

    Public Function insert_to_borrower_turnover_info() As Integer
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Dim return_from_and_to As String = ""

        'For Each row As ListViewItem In lvlMultipleCustodian.Items
        '    return_from_and_to &= row.Text & ":" & row.SubItems(1).Text & ":" & row.SubItems(2).Text & ","
        'Next

        For Each row As String In list_returnFrom.Items
            return_from_and_to &= row & ":" & "RETURN FROM,"
        Next

        For Each row As String In list_ReturnTo.Items
            return_from_and_to &= row & ":" & "RETURN TO,"
        Next

        return_from_and_to = remove_last_character(return_from_and_to)

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_borrower_new", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 6)

            newCMD.Parameters.AddWithValue("@return_from_to", return_from_and_to)
            'newCMD.Parameters.AddWithValue("@condition_of_item", cmbCondition.Text)
            newCMD.Parameters.AddWithValue("@receiver", txtReceiver.Text)
            newCMD.Parameters.AddWithValue("@date_turnover", Date.Parse(dtpdateturnover.Text))
            newCMD.Parameters.AddWithValue("@turonver_by", txtturnoverby.Text)
            newCMD.Parameters.AddWithValue("@date_noted", Date.Parse(dtpDateNoted.Text))
            newCMD.Parameters.AddWithValue("@noted_by", txtNotedBy.Text)

            insert_to_borrower_turnover_info = newCMD.ExecuteScalar()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
            GC.Collect()

        End Try
    End Function

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub cmbChargesType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbChargesType.SelectedIndexChanged
        FProjectIncharge.load_all(cmbChargesDesc, 1, cmbChargesType.Text)
    End Sub

    Private Sub btnAddTempCustodian_Click(sender As Object, e As EventArgs) Handles btnAddTempCustodian.Click
        If cmbReturnType.Text = "RETURN FROM" Then
            list_returnFrom.Items.Add(cmbChargesType.Text & ":" & cmbChargesDesc.Text)

        ElseIf cmbReturnType.Text = "RETURN TO"
            list_ReturnTo.Items.Add(cmbChargesType.Text & ":" & cmbChargesDesc.Text)
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Dim return_from_to As String = ""

        For Each row As String In list_returnFrom.Items
            return_from_to &= row & ":" & "RETURN FROM,"
        Next

        For Each row As String In list_ReturnTo.Items
            return_from_to &= row & ":" & "RETURN TO,"
        Next
        return_from_to = remove_last_character(return_from_to)

        MsgBox(return_from_to)

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub txtReceiver_TextChanged(sender As Object, e As EventArgs) Handles txtReceiver.TextChanged
        Try
            If txtReceiver.Text = "" Then
                lbox_return_details.Visible = False
            Else
                With lbox_return_details
                    .Location = New System.Drawing.Point(txtReceiver.Location.X, txtReceiver.Location.Y + txtReceiver.Height)
                    .Visible = True
                    .Items.Clear()
                    .Width = txtReceiver.Width
                End With

                get_receiver(txtReceiver.Text, 0)
            End If
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub get_receiver(ByVal value As String, ByVal n As Integer)
        Dim sqL As New SQLcon
        Dim newcmd As SqlCommand
        Dim newdr As SqlDataReader
        Dim count As Integer = 0

        Try
            sqL.connection.Open()

            newcmd = New SqlCommand("proc_borrower_new", sqL.connection)
            newcmd.Parameters.Clear()
            newcmd.CommandType = CommandType.StoredProcedure

            If n = 0 Then
                newcmd.Parameters.AddWithValue("@n", 11)
                newcmd.Parameters.AddWithValue("@value", value)
            ElseIf n = 1 Then
                newcmd.Parameters.AddWithValue("@n", 12)
                newcmd.Parameters.AddWithValue("@value", value)
            ElseIf n = 2 Then
                newcmd.Parameters.AddWithValue("@n", 13)
                newcmd.Parameters.AddWithValue("@value", value)
            End If

            newdr = newcmd.ExecuteReader

            While newdr.Read

                If n = 0 Then
                    lbox_return_details.Items.Add(newdr.Item("receiver").ToString)
                    count += 1
                ElseIf n = 1 Then
                    lbox_return_details.Items.Add(newdr.Item("turnover_by").ToString)
                    count += 1
                ElseIf n = 2 Then
                    lbox_return_details.Items.Add(newdr.Item("noted_by").ToString)
                    count += 1
                End If

            End While

            If count > 0 Then
                lbox_return_details.Visible = True
            Else
                lbox_return_details.Visible = False
            End If

            newdr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqL.connection.Close()
            GC.Collect()

        End Try
    End Sub

    Private Sub txtturnoverby_TextChanged(sender As Object, e As EventArgs) Handles txtturnoverby.TextChanged
        Try
            If txtturnoverby.Text = "" Then
                lbox_return_details.Visible = False
            Else
                With lbox_return_details
                    .Location = New System.Drawing.Point(txtturnoverby.Location.X, txtturnoverby.Location.Y + txtturnoverby.Height)
                    .Visible = True
                    .Items.Clear()
                    .Width = txtturnoverby.Width
                End With

                get_receiver(txtturnoverby.Text, 1)
            End If
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtNotedBy_TextChanged(sender As Object, e As EventArgs) Handles txtNotedBy.TextChanged
        Try
            If txtNotedBy.Text = "" Then
                lbox_return_details.Visible = False
            Else
                With lbox_return_details
                    .Location = New System.Drawing.Point(txtNotedBy.Location.X, txtNotedBy.Location.Y + txtNotedBy.Height)
                    .Visible = True
                    .Items.Clear()
                    .Width = txtNotedBy.Width
                End With

                get_receiver(txtNotedBy.Text, 2)
            End If
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub lbox_return_details_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbox_return_details.SelectedIndexChanged

    End Sub

    Private Sub lbox_return_details_KeyDown(sender As Object, e As KeyEventArgs) Handles lbox_return_details.KeyDown
        If e.KeyCode = Keys.Enter Then
            For Each ctr As Control In Panel1.Controls
                If ctr.Name = txtname Then
                    ctr.Text = lbox_return_details.SelectedItem.ToString
                    ctr.Focus()
                End If
            Next
            lbox_return_details.Visible = False
        End If
    End Sub

    Private Sub lbox_return_details_DoubleClick(sender As Object, e As EventArgs) Handles lbox_return_details.DoubleClick
        If lbox_return_details.SelectedItems.Count > 0 Then
            For Each ctr As Control In Panel1.Controls
                If ctr.Name = txtname Then
                    ctr.Text = lbox_return_details.SelectedItem.ToString
                    ctr.Focus()
                End If
            Next

            lbox_return_details.Visible = False
        End If
    End Sub

    Private Sub txtReceiver_KeyDown(sender As Object, e As KeyEventArgs) Handles txtReceiver.KeyDown
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Enter Then

            If lbox_return_details.Visible = True Then
                If lbox_return_details.Items.Count > 0 Then
                    lbox_return_details.Focus()
                    lbox_return_details.SelectedIndex = 0

                End If

            End If
        End If
    End Sub

    Private Sub txtturnoverby_KeyDown(sender As Object, e As KeyEventArgs) Handles txtturnoverby.KeyDown
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Enter Then

            If lbox_return_details.Visible = True Then
                If lbox_return_details.Items.Count > 0 Then
                    lbox_return_details.Focus()
                    lbox_return_details.SelectedIndex = 0

                End If

            End If
        End If
    End Sub

    Private Sub txtNotedBy_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNotedBy.KeyDown
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Enter Then

            If lbox_return_details.Visible = True Then
                If lbox_return_details.Items.Count > 0 Then
                    lbox_return_details.Focus()
                    lbox_return_details.SelectedIndex = 0

                End If

            End If
        End If
    End Sub

    Private Sub txtReceiver_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtReceiver.GotFocus, cmbReturnType.GotFocus, cmbChargesType.GotFocus, cmbChargesDesc.GotFocus, txtReceiver.GotFocus _
      , dtpdateturnover.GotFocus, txtturnoverby.GotFocus, dtpDateNoted.GotFocus, txtNotedBy.GotFocus

        If txtReceiver.Focused Then
            txtname = txtReceiver.Name
            txtReceiver.SelectAll()
        ElseIf txtturnoverby.Focused Then
            txtname = txtturnoverby.Name
            txtturnoverby.SelectAll()
        ElseIf txtNotedBy.Focused Then
            txtname = txtNotedBy.Name
            txtNotedBy.SelectAll()
        End If

        lbox_return_details.Visible = False
    End Sub

    Private Sub list_returnFrom_SelectedIndexChanged(sender As Object, e As EventArgs) Handles list_returnFrom.SelectedIndexChanged

    End Sub

    Private Sub list_returnFrom_MouseDown(sender As Object, e As MouseEventArgs) Handles list_returnFrom.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            listboxname = list_returnFrom.Name
        End If
    End Sub
    Private Sub list_ReturnTo_MouseDown(sender As Object, e As MouseEventArgs) Handles list_ReturnTo.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            listboxname = list_ReturnTo.Name
        End If
    End Sub

    Private Sub RemoveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveToolStripMenuItem.Click
        If listboxname = "list_returnFrom" Then
            list_returnFrom.Items.Remove(list_returnFrom.SelectedItem)

        ElseIf listboxname = "list_ReturnTo" Then
            list_ReturnTo.Items.Remove(list_ReturnTo.SelectedItem)

        Else

        End If
    End Sub
End Class