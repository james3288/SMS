Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class FBulkRequest
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If btnSave.Text = "Save" Then
            If check_if_exist("dbBulk_Request", "rs_no", txtRsNo.Text, 0) > 0 Then
                MessageBox.Show("RS No was already saved...", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtRsNo.Focus()

                Exit Sub
            End If

            If MessageBox.Show("Are you sure want to save this data?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim newSQ As New SQLcon
                Dim newCMD As SqlCommand

                Try
                    newSQ.connection.Open()
                    newCMD = New SqlCommand("proc_bulk_request", newSQ.connection)
                    newCMD.Parameters.Clear()
                    newCMD.CommandType = CommandType.StoredProcedure

                    newCMD.Parameters.AddWithValue("@n", 1)
                    newCMD.Parameters.AddWithValue("@rs_no", txtRsNo.Text)
                    newCMD.Parameters.AddWithValue("@bulk_qty", CDbl(txtBulkQty.Text))

                    Dim id As Integer = newCMD.ExecuteScalar()

                    'search 
                    search_rs_no(txtRsNo.Text)
                    listfocus(lvlListofBulkItems, id)
                    btnSave.Text = "Save"

                Catch ex As Exception
                    MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    newSQ.connection.Close()
                End Try
            End If

        ElseIf btnSave.Text = "Update" Then
            If MessageBox.Show("Are you sure want to update this data?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim newSQ As New SQLcon
                Dim newCMD As SqlCommand

                Try
                    newSQ.connection.Open()
                    newCMD = New SqlCommand("proc_bulk_request", newSQ.connection)
                    newCMD.Parameters.Clear()
                    newCMD.CommandType = CommandType.StoredProcedure

                    newCMD.Parameters.AddWithValue("@n", 3)

                    newCMD.Parameters.AddWithValue("@rs_no", txtRsNo.Text)
                    newCMD.Parameters.AddWithValue("@bulk_rs_id", Val(lvlListofBulkItems.SelectedItems(0).Text))
                    newCMD.Parameters.AddWithValue("@bulk_qty", CDbl(txtBulkQty.Text))

                    Dim id As Integer = Val(lvlListofBulkItems.SelectedItems(0).Text)
                    newCMD.ExecuteNonQuery()
                    'search 
                    search_rs_no(txtRsNo.Text)
                    listfocus(lvlListofBulkItems, id)
                    btnSave.Text = "Save"

                    txtSearchRSNO.Enabled = True
                    lvlListofBulkItems.Enabled = True

                    txtRsNo.Clear()
                    txtBulkQty.Clear()


                Catch ex As Exception
                    MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    newSQ.connection.Close()

                End Try
            End If
        End If



    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtSearchRSNO.TextChanged

    End Sub

    Public Sub search_rs_no(rs_no As String)
        lvlListofBulkItems.Items.Clear()

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_bulk_request", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 2)
            newCMD.Parameters.AddWithValue("@rs_no", txtSearchRSNO.Text)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                Dim a(5) As String
                a(0) = newDR.Item("bulk_rs_id").ToString
                a(1) = newDR.Item("rs_no").ToString
                a(2) = FormatNumber(CDbl(newDR.Item("bulk_qty").ToString), "0,000.00")
                a(3) = CDbl(newDR.Item("bulk_qty").ToString) - bulk_request_qty_left(newDR.Item("rs_no").ToString)
                a(3) = FormatNumber(CDbl(a(3)), "0,000.00")

                Dim lvl As New ListViewItem(a)
                lvlListofBulkItems.Items.Add(lvl)

            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE:  " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub
    Public Function bulk_request_qty_left(rs_no As String) As Double
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_execute_tempstockcard2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 4)
            newCMD.Parameters.AddWithValue("@rs_no", rs_no)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                If newDR.Item("dr_option").ToString = "WITH DR" And newDR.Item("WITHDRAWN_ITEM").ToString <> "" Then
                    If newDR.Item("DR_NO").ToString = "" Then

                    Else
                        bulk_request_qty_left += CDbl(newDR.Item("PO_WS_QTY").ToString)
                    End If

                ElseIf newDR.Item("dr_option").ToString = "WITHOUT DR" And newDR.Item("WITHDRAWN_ITEM").ToString <> "" Then

                    If newDR.Item("DR_NO").ToString = "" Then

                    Else

                    End If

                End If

            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        txtSearchRSNO.Enabled = False
        lvlListofBulkItems.Enabled = False

        txtRsNo.Text = lvlListofBulkItems.SelectedItems(0).SubItems(1).Text
        txtBulkQty.Text = lvlListofBulkItems.SelectedItems(0).SubItems(2).Text
        btnSave.Text = "Update"

    End Sub

    Private Sub txtSearchRSNO_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearchRSNO.KeyDown

        If e.KeyCode = Keys.Enter Then
            search_rs_no(txtSearchRSNO.Text)
        End If
    End Sub
End Class