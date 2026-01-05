Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class FBorrower_return_items
    Public txtname As String
    Private Sub Label4_Click(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

    Private Sub cmbCondition_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

    Private Sub cmbChargesType_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbChargesType.SelectedIndexChanged
        FProjectIncharge.load_all(cmbChargesDesc, 1, cmbChargesType.Text)
    End Sub

    Private Sub btnAddTempCustodian_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddTempCustodian.Click
        Dim a(10) As String

        a(0) = cmbChargesType.Text
        a(1) = cmbChargesDesc.Text
        a(2) = cmbReturnType.Text

        Dim lvl As New ListViewItem(a)
        lvlMultipleCustodian.Items.Add(lvl)
    End Sub

    Private Sub RemoveToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles RemoveToolStripMenuItem.Click
        For Each row As ListViewItem In lvlMultipleCustodian.Items
            If row.Selected = True Then
                row.Remove()

            End If
        Next
    End Sub

    Private Sub btnReturnthisItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReturnthisItem.Click

        If MessageBox.Show("Are you sure you want to return this item?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Dim to_items_id As Integer = insert_to_borrower_turnover_info()

            For Each row As ListViewItem In FBorrower_Details.lvl_Return_items.Items
                insert_to_dbborrower_turnover_details(row.Text, to_items_id, row.SubItems(2).Text, row.SubItems(4).Text, row.SubItems(5).Text)
            Next

            Me.Close()

            FBorrower_Details.Close()
            FRequistionForm.btnSearch.PerformClick()
            listfocus(FRequistionForm.lvlrequisitionlist, rs_id)

        Else
            Return
        End If

        'FListofBorrowerItem.btnBMsearch.PerformClick()
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
        End Try

    End Sub

    Public Function insert_to_borrower_turnover_info() As Integer
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Dim return_from_and_to As String = ""

        For Each row As ListViewItem In lvlMultipleCustodian.Items
            return_from_and_to &= row.Text & ":" & row.SubItems(1).Text & ":" & row.SubItems(2).Text & ","
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
        End Try
    End Function

    Private Sub FBorrower_return_items_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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

    Private Sub txtReceiver_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtReceiver.KeyDown, txtturnoverby.KeyDown, txtNotedBy.KeyDown
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Enter Then

            If lbox_return_details.Visible = True Then
                If lbox_return_details.Items.Count > 0 Then
                    lbox_return_details.Focus()
                    lbox_return_details.SelectedIndex = 0

                End If

            End If
        End If
    End Sub

    Private Sub txtReceiver_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtReceiver.TextChanged
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
        End Try
    End Sub

    Private Sub txtturnoverby_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtturnoverby.TextChanged
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

    Private Sub lbox_return_details_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbox_return_details.DoubleClick
        If lbox_return_details.SelectedItems.Count > 0 Then
            For Each ctr As Control In Me.Controls
                If ctr.Name = txtname Then
                    ctr.Text = lbox_return_details.SelectedItem.ToString
                    ctr.Focus()
                End If
            Next

            lbox_return_details.Visible = False
        End If
    End Sub

    Private Sub lbox_return_details_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lbox_return_details.KeyDown
        If e.KeyCode = Keys.Enter Then
            For Each ctr As Control In Me.Controls
                If ctr.Name = txtname Then
                    ctr.Text = lbox_return_details.SelectedItem.ToString
                    ctr.Focus()
                End If
            Next
            lbox_return_details.Visible = False
        End If
    End Sub

    Private Sub txtNotedBy_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNotedBy.TextChanged
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
End Class