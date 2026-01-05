Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class FTurnover_History
    Private Sub cmbType1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbType1.SelectedIndexChanged
        load_if_project_or_warehouse(cmbType1.Text, cmbTurnoverfrom)
    End Sub

    Sub load_if_project_or_warehouse(types As String, combobox As ComboBox)

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        combobox.Items.Clear()

        Try

            Dim query As String = ""

            Select Case types

                Case "WAREHOUSE"
                    newSQ.connection.Open()
                    query = "SELECT DISTINCT wh_area FROM dbwh_area ORDER BY wh_area ASC"
                    newCMD = New SqlCommand(query, newSQ.connection)

                Case "PROJECT"
                    newSQ.connection1.Open()
                    query = "SELECT DISTINCT project_desc FROM dbprojectdesc ORDER BY project_desc ASC"
                    newCMD = New SqlCommand(query, newSQ.connection1)
                Case "PERSONAL"
                    query = ""
            End Select


            newDR = newCMD.ExecuteReader

            While newDR.Read
                combobox.Items.Add(newDR.Item(0).ToString)
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
            newSQ.connection1.Close()
        End Try
    End Sub

    Private Sub cmbType2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbType2.SelectedIndexChanged
        load_if_project_or_warehouse(cmbType2.Text, cmbTurnoverto)
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If btnSave.Text = "Save" Then
            save_update_turnover_history(1)
        ElseIf btnSave.Text = "Update" Then
            save_update_turnover_history(3)
        End If


    End Sub
    Public Sub save_update_turnover_history(n As Integer)

        Dim wh_id As Integer = FListOfItems.lvlWarehouseItem.SelectedItems(0).Text

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_turnover_history", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", n)

            If n = 3 Then
                Dim th_id As Integer = lvl_turnover_list.SelectedItems(0).Text
                newCMD.Parameters.AddWithValue("@th_id", th_id)
            End If

            newCMD.Parameters.AddWithValue("@wh_id", wh_id)
            newCMD.Parameters.AddWithValue("@turnover_from_type", cmbType1.Text)
            newCMD.Parameters.AddWithValue("@turnover_from", cmbTurnoverfrom.Text)
            newCMD.Parameters.AddWithValue("@turnover_to_type", cmbType2.Text)
            newCMD.Parameters.AddWithValue("@turnover_to", cmbTurnoverto.Text)
            newCMD.Parameters.AddWithValue("@date_turnover", Date.Parse(dtp_turnover.Text))
            newCMD.Parameters.AddWithValue("@qty", txtqty.Text)
            newCMD.Parameters.AddWithValue("@turnover_by", txtTurnoverby.Text)
            newCMD.Parameters.AddWithValue("@noted_by", txtnotedby.Text)
            newCMD.Parameters.AddWithValue("@received_by", txtreceiver.Text)
            newCMD.Parameters.AddWithValue("@condition_of_items", txtcondition.Text)

            If n = 1 Then
                Dim exec As Integer = newCMD.ExecuteScalar()
                If exec > 0 Then
                    MessageBox.Show("Successfully saved...", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("there is something wrong with the query..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            ElseIf n = 3 Then
                newCMD.ExecuteNonQuery()
                MessageBox.Show("Successfully updated...", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Information)
                FListOfItems.load_turnover_items(wh_id)
                btnCancel.Visible = False
                btnSave.Text = "Save"
                lvl_turnover_list.Enabled = True

                'cmbType1.SelectedIndex = -1
                'cmbTurnoverfrom.SelectedIndex = -1
                'cmbType2.SelectedIndex = -1
                'cmbTurnoverto.SelectedIndex = -1

                txtqty.Clear()
                txtTurnoverby.Clear()
                txtnotedby.Clear()
                txtreceiver.Clear()
                txtcondition.Clear()
            End If

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE:" & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub
    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        With lvl_turnover_list
            Dim date_turnover As DateTime
            Dim item_name, item_desc, turnover_from_a, turnover_from_b, turnover_to_a, turnover_to_b, condition, receiver, turnover_by, noted_by As String
            Dim qty As Double

            turnover_from_a = .SelectedItems(0).SubItems(1).Text
            turnover_from_b = .SelectedItems(0).SubItems(2).Text
            turnover_to_a = .SelectedItems(0).SubItems(3).Text
            turnover_to_b = .SelectedItems(0).SubItems(4).Text
            qty = .SelectedItems(0).SubItems(5).Text
            receiver = .SelectedItems(0).SubItems(6).Text
            turnover_by = .SelectedItems(0).SubItems(7).Text
            noted_by = .SelectedItems(0).SubItems(8).Text
            date_turnover = Date.Parse(.SelectedItems(0).SubItems(9).Text)
            condition = .SelectedItems(0).SubItems(10).Text


            cmbType1.Text = turnover_from_a
            cmbTurnoverfrom.Text = turnover_from_b

            cmbType2.Text = turnover_to_a
            cmbTurnoverto.Text = turnover_to_b

            txtqty.Text = CDbl(qty)
            txtreceiver.Text = receiver
            txtTurnoverby.Text = turnover_by
            txtnotedby.Text = noted_by
            dtp_turnover.Text = date_turnover
            txtcondition.Text = condition

            btnSave.Text = "Update"
            btnCancel.Visible = true 
            lvl_turnover_list.Enabled = False

        End With
    End Sub

    Private Sub FTurnover_History_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        lvl_turnover_list.Enabled = True
        btnSave.Text = "Save"
        btnCancel.Visible = False
    End Sub

    Private Sub RemoveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveToolStripMenuItem.Click
        If MessageBox.Show("are you sure you wan't to remove this data?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim newSQ As New SQLcon
            Dim newCMD As SqlCommand

            Try
                newSQ.connection.Open()
                newCMD = New SqlCommand("proc_turnover_history", newSQ.connection)
                newCMD.Parameters.Clear()
                newCMD.CommandType = CommandType.StoredProcedure
                newCMD.CommandTimeout = 0

                newCMD.Parameters.AddWithValue("@n", 4)
                newCMD.Parameters.AddWithValue("@th_id", lvl_turnover_list.SelectedItems(0).Text)
                newCMD.ExecuteNonQuery()

                lvl_turnover_list.SelectedItems(0).Remove()


            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                newSQ.connection.Close()
            End Try
        End If

    End Sub
End Class