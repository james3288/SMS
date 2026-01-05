Imports System.ComponentModel
Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class FEditPrice
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtPrice.TextChanged

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        For Each row As ListViewItem In FDRLIST.lvl_drList.Items

            If row.Selected = True Then
                Dim newSQ As New SQLcon
                Dim newCMD As SqlCommand
                Dim t1, t2, t3 As String
                Try
                    newSQ.connection.Open()
                    newCMD = New SqlCommand("proc_Delivery_Receipt", newSQ.connection)
                    newCMD.Parameters.Clear()
                    newCMD.CommandType = CommandType.StoredProcedure

                    newCMD.Parameters.AddWithValue("@n", 44)
                    newCMD.Parameters.AddWithValue("@price", txtPrice.Text)
                    newCMD.Parameters.AddWithValue("@receivedby", txtreceivedby.Text)
                    newCMD.Parameters.AddWithValue("@dr_item_id", row.Text)

                    t1 = row.SubItems(27).Text
                    t3 = row.SubItems(28).Text
                    t2 = row.SubItems(13).Text

                    newCMD.ExecuteNonQuery()

                    row.SubItems(27).Text = FormatNumber(CDbl(txtPrice.Text), 2,,, TriState.True)

                    If row.SubItems(16).Text = "OUT" Then
                        row.SubItems(28).Text = FormatNumber(CDbl(txtPrice.Text) * CDbl(row.SubItems(26).Text), 2,,, TriState.True)
                    Else
                        row.SubItems(28).Text = FormatNumber(CDbl(txtPrice.Text) * CDbl(row.SubItems(6).Text), 2,,, TriState.True)
                    End If

                    row.SubItems(13).Text = txtreceivedby.Text

                    Me.Close()

                Catch ex As Exception
                    MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    row.SubItems(27).Text = t1
                    row.SubItems(28).Text = t3
                    row.SubItems(13).Text = t2
                Finally
                    newSQ.connection.Close()
                    End Try

            End If
        Next
    End Sub

    Private Sub TextBox1_TextChanged_1(sender As Object, e As EventArgs) Handles txtreceivedby.TextChanged
        Dim txtbox As TextBox = sender

        If txtbox.Text = "" Then
            lboxUnit.Location = New System.Drawing.Point(txtbox.Location.X, txtbox.Location.Y + txtbox.Height)
            lboxUnit.Visible = False
        Else
            lboxUnit.Visible = True
            With lboxUnit
                .Location = New System.Drawing.Point(txtbox.Location.X, txtbox.Location.Y + txtbox.Height)
                .Visible = True
                .Items.Clear()
                .Width = txtbox.Width
            End With

            get_dr_info(sender.name, txtbox.Text, txtbox)
        End If


    End Sub

    Public Function get_dr_info(field As String, search As String, txtbox As TextBox)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        lboxUnit.Items.Clear()

        Dim counter As Integer = 0

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_Delivery_Receipt", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.Parameters.AddWithValue("@n", 13)
            newCMD.Parameters.AddWithValue("@field", field)
            newCMD.Parameters.AddWithValue("@search", search)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                lboxUnit.Items.Add(newDR.Item(0).ToString)
                counter += 1
            End While

            If counter = 0 Then
                lboxUnit.Visible = False
            End If

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function

    Private Sub lboxUnit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lboxUnit.SelectedIndexChanged

    End Sub

    Private Sub lboxUnit_KeyDown(sender As Object, e As KeyEventArgs) Handles lboxUnit.KeyDown
        If e.KeyCode = Keys.Enter Then
            If lboxUnit.Items.Count > 0 Then

                txtreceivedby.Text = lboxUnit.SelectedItem.ToString
                txtreceivedby.Focus()
                lboxUnit.Visible = False
                lboxUnit.Items.Clear()
                Exit Sub

            End If
        End If

    End Sub

    Private Sub lboxUnit_DoubleClick(sender As Object, e As EventArgs) Handles lboxUnit.DoubleClick
        If lboxUnit.Items.Count > 0 Then

            txtreceivedby.Text = lboxUnit.SelectedItem.ToString
            txtreceivedby.Focus()
            lboxUnit.Visible = False
            lboxUnit.Items.Clear()
            Exit Sub

        End If
    End Sub

    Private Sub txtreceivedby_KeyDown(sender As Object, e As KeyEventArgs) Handles txtreceivedby.KeyDown
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Enter Then

            If lboxUnit.Visible = True Then
                If lboxUnit.Items.Count > 0 Then
                    lboxUnit.Focus()
                    lboxUnit.SelectedIndex = 0
                End If
            End If
        End If

    End Sub
End Class