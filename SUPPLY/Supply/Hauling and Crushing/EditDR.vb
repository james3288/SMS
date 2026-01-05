Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class EditDR
    Dim operator_id As Integer

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If MessageBox.Show("Are you sure you want to update selected data?", "DR Info:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim selectedrow As Integer = FDRLIST.lvl_drList.SelectedItems(0).Text

            For Each row As ListViewItem In FDRLIST.lvl_drList.Items
                If row.Selected = True Then
                    Select Case editspecificdr
                        'update dr date
                        Case "date"
                            update_specific_column_from_dr(row.Index, row.Text, "date")

                        Case "date-submitted"
                            update_specific_column_from_dr(row.Index, row.Text, "date-submitted")

                        'update operator 
                        Case "operator"
                            update_specific_column_from_dr(row.Index, row.Text, "operator")

                        Case "price"
                            update_specific_column_from_dr(row.Index, row.Text, "price")

                        Case "received by"
                            update_specific_column_from_dr(row.Index, row.Text, "received by")

                        Case "Concession"
                            update_specific_column_from_dr(row.Index, row.Text, "Concession")

                        Case "drno"
                            update_specific_column_from_dr(row.Index, row.Text, "drno")

                        Case "plateno"
                            update_specific_column_from_dr(row.Index, row.Text, "plateno")

                        Case "supplier"
                            update_specific_column_from_dr(row.Index, row.Text, "supplier")


                    End Select
                End If
            Next
        End If

    End Sub

    Private Sub update_specific_column_from_dr(rowindex As Integer, dr_item_id As Integer, whatcolumn As String)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_Delivery_Receipt", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            Select Case whatcolumn
                Case "date"
                    newCMD.Parameters.AddWithValue("@n", 47)
                    newCMD.Parameters.AddWithValue("@date", Date.Parse(dtpDrDate.Text))
                    FDRLIST.lvl_drList.Items(rowindex).SubItems(3).Text = Format(Date.Parse(dtpDrDate.Text), "MM/dd/yyyy")

                Case "date-submitted"
                    newCMD.Parameters.AddWithValue("@n", 477)
                    newCMD.Parameters.AddWithValue("@dateSubmitted", Date.Parse(dtpDrDate.Text))
                    FDRLIST.lvl_drList.Items(rowindex).SubItems(31).Text = Format(Date.Parse(dtpDrDate.Text), "MM/dd/yyyy")

                Case "operator"
                    newCMD.Parameters.AddWithValue("@n", 48)
                    newCMD.Parameters.AddWithValue("@operator_id", operator_id)
                    FDRLIST.lvl_drList.Items(rowindex).SubItems(9).Text = cmbOperator.Text
                Case "price"
                    newCMD.Parameters.AddWithValue("@n", 49)
                    newCMD.Parameters.AddWithValue("@price", txtSpecificColumn.Text)
                    FDRLIST.lvl_drList.Items(rowindex).SubItems(27).Text = txtSpecificColumn.Text

                    If FDRLIST.lvl_drList.Items(rowindex).SubItems(16).Text = "OUT" Then
                        'FDRLIST.lvl_drList.Items(rowindex).SubItems(28).Text = FormatNumber(CDbl(FDRLIST.lvl_drList.Items(rowindex).SubItems(26).Text) * CDbl(FDRLIST.lvl_drList.Items(rowindex).SubItems(27).Text), 2,, TriState.True)
                        MessageBox.Show("The item that you've trying to edit is from withdrawal." & vbCrLf & "You may go to withdrawal form to edit the data exactly.", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    Else
                        FDRLIST.lvl_drList.Items(rowindex).SubItems(28).Text = FormatNumber(CDbl(FDRLIST.lvl_drList.Items(rowindex).SubItems(6).Text) * CDbl(FDRLIST.lvl_drList.Items(rowindex).SubItems(27).Text), 2,, TriState.True)
                    End If
                Case "received by"
                    newCMD.Parameters.AddWithValue("@n", 50)
                    newCMD.Parameters.AddWithValue("@receivedby", txtSpecificColumn.Text)
                    FDRLIST.lvl_drList.Items(rowindex).SubItems(13).Text = txtSpecificColumn.Text

                Case "Concession"
                    newCMD.Parameters.AddWithValue("@n", 51)
                    newCMD.Parameters.AddWithValue("@con_ticket_no", txtSpecificColumn.Text)
                    FDRLIST.lvl_drList.Items(rowindex).SubItems(8).Text = txtSpecificColumn.Text

                Case "drno"
                    newCMD.Parameters.AddWithValue("@n", 52)
                    newCMD.Parameters.AddWithValue("@dr_no", txtSpecificColumn.Text)
                    FDRLIST.lvl_drList.Items(rowindex).SubItems(1).Text = txtSpecificColumn.Text

                Case "plateno"
                    newCMD.Parameters.AddWithValue("@n", 53)
                    newCMD.Parameters.AddWithValue("@plate_no", txtSpecificColumn.Text)
                    FDRLIST.lvl_drList.Items(rowindex).SubItems(24).Text = txtSpecificColumn.Text

                Case "supplier"
                    newCMD.Parameters.AddWithValue("@n", 54)
                    newCMD.Parameters.AddWithValue("@supplier", txtSpecificColumn.Text)
                    FDRLIST.lvl_drList.Items(rowindex).SubItems(22).Text = txtSpecificColumn.Text

            End Select

            newCMD.Parameters.AddWithValue("@dr_item_id", dr_item_id)
            newCMD.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub

    Private Sub cmbOperator_GotFocus(sender As Object, e As EventArgs) Handles cmbOperator.GotFocus
        sender.DroppedDown = True
    End Sub

    Private Sub cmbOperator_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbOperator.SelectedIndexChanged
        Dim sqlcon As New SQLcon
        Dim sqldr As SqlDataReader
        Dim cmd As SqlCommand

        Try
            sqlcon.connection1.Open()
            publicquery = "SELECT  TOP 1 a.operator_id FROM eus.dbo.dboperator a WHERE a.operator_name = '" & cmbOperator.Text & "'"
            cmd = New SqlCommand(publicquery, sqlcon.connection1)
            sqldr = cmd.ExecuteReader
            While sqldr.Read
                operator_id = sqldr.Item("operator_id").ToString
            End While
            sqldr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            sqlcon.connection1.Close()

        End Try

    End Sub

    Private Sub txtSpecificColumn_TextChanged(sender As Object, e As EventArgs) Handles txtSpecificColumn.TextChanged
        If editspecificdr = "received by" Then
            Dim txtbox As TextBox = sender

            If txtbox.Text = "" Then
                lboxUnit.Location = New System.Drawing.Point(txtbox.Location.X + 10, txtbox.Location.Y + txtbox.Height + 10)
                lboxUnit.Visible = False
            Else
                lboxUnit.Visible = True
                With lboxUnit
                    .Location = New System.Drawing.Point(txtbox.Location.X + 10, txtbox.Location.Y + txtbox.Height + 10)
                    .Visible = True
                    .Items.Clear()
                    .Width = txtbox.Width
                End With

                get_dr_info("txtreceivedby", txtbox.Text, txtbox)
            End If

        ElseIf editspecificdr = "plateno" Then
            Dim txtbox As TextBox = sender

            If txtbox.Text = "" Then
                lboxUnit.Location = New System.Drawing.Point(txtbox.Location.X + 10, txtbox.Location.Y + txtbox.Height + 10)
                lboxUnit.Visible = False
            Else
                lboxUnit.Visible = True
                With lboxUnit
                    .Location = New System.Drawing.Point(txtbox.Location.X + 10, txtbox.Location.Y + txtbox.Height + 10)
                    .Visible = True
                    .Items.Clear()
                    .Width = txtbox.Width
                End With

                get_plate_no(txtSpecificColumn.Text)
            End If

        ElseIf editspecificdr = "supplier" Then
            Dim txtbox As TextBox = sender

            If txtbox.Text = "" Then
                lboxUnit.Location = New System.Drawing.Point(txtbox.Location.X + 10, txtbox.Location.Y + txtbox.Height + 10)
                lboxUnit.Visible = False
            Else
                lboxUnit.Visible = True
                With lboxUnit
                    .Location = New System.Drawing.Point(txtbox.Location.X + 10, txtbox.Location.Y + txtbox.Height + 10)
                    .Visible = True
                    .Items.Clear()
                    .Width = txtbox.Width
                End With

                get_supplier(txtSpecificColumn.Text)
            End If
        Else

        End If
    End Sub
    Private Sub lboxUnit_KeyDown(sender As Object, e As KeyEventArgs) Handles lboxUnit.KeyDown
        If e.KeyCode = Keys.Enter Then
            If lboxUnit.Items.Count > 0 Then

                txtSpecificColumn.Text = lboxUnit.SelectedItem.ToString
                txtSpecificColumn.Focus()
                lboxUnit.Visible = False
                lboxUnit.Items.Clear()
                Exit Sub

            End If
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
    Public Sub get_plate_no(search As String)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        lboxUnit.Items.Clear()

        Dim counter As Integer = 0

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_Delivery_Receipt1", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.Parameters.AddWithValue("@n", 3)
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
    End Sub

    Public Sub get_supplier(search As String)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        lboxUnit.Items.Clear()

        Dim counter As Integer = 0

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_Delivery_Receipt1", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.Parameters.AddWithValue("@n", 4)
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
    End Sub
    Private Sub lboxUnit_DoubleClick(sender As Object, e As EventArgs) Handles lboxUnit.DoubleClick
        If lboxUnit.Items.Count > 0 Then

            txtSpecificColumn.Text = lboxUnit.SelectedItem.ToString
            txtSpecificColumn.Focus()
            lboxUnit.Visible = False
            lboxUnit.Items.Clear()
            Exit Sub
        End If
    End Sub

    Private Sub txtSpecificColumn_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSpecificColumn.KeyDown
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Enter Then

            If lboxUnit.Visible = True Then
                If lboxUnit.Items.Count > 0 Then
                    lboxUnit.Focus()
                    lboxUnit.SelectedIndex = 0
                End If
            End If
        End If

    End Sub

    Private Sub lboxUnit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lboxUnit.SelectedIndexChanged

    End Sub

    Private Sub EditDR_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class