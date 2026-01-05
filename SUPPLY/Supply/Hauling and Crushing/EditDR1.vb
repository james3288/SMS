Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class EditDR1
    Dim operator_id As Integer
    Public othercharges As New Model._Mod_Charges
    Public cListOfChargesInfo As New List(Of Model._Mod_Charges.charges_info)

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If MessageBox.Show("Are you sure you want to update selected data?", "DR Info:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim selectedrow As Integer = IIf(FDRLIST1.lvl_drList.SelectedItems(0).Text = "", 0, FDRLIST1.lvl_drList.SelectedItems(0).Text)

            'loop for dr listview in fdrlist1 form
            For Each row As ListViewItem In FDRLIST1.lvl_drList.Items
                If row.Selected = True Then
                    If row.BackColor = Color.DarkGreen Then 'DARKGREEN
                        'walay labot'
                        MessageBox.Show("RS row is not applicable for editing items..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                    ElseIf row.BackColor = Color.LightGreen Then 'LIGHTGREEN
                        'walay labot'
                        'MessageBox.Show("WITHDRAWAL row is not applicable for editing items..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                        Select Case editspecificdr
                        'update dr date
                            Case "price"
                                update_specific_column_from_dr(row.Index, row.Text, "price")
                            Case "wsno"
                                update_specific_column_from_dr(row.Index, row.Text, "wsno")
                            Case "drdate"
                                update_specific_column_from_dr(row.Index, row.Text, "wsdate")
                            Case "remarks"
                                update_specific_column_from_dr(row.Index, row.Text, "wsremarks")
                            Case "withdrawnby"
                                update_specific_column_from_dr(row.Index, row.Text, "withdrawnby")
                            Case Else
                                MessageBox.Show("not applicable for editing items..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        End Select

                    ElseIf row.BackColor = Color.LightYellow Then 'LIGHTYELLOW
                        Select Case editspecificdr
                        'update dr date
                            Case "date"
                                update_specific_column_from_dr(row.Index, row.Text, "date")
                        'update operator 
                            Case "operator"
                                update_specific_column_from_dr(row.Index, row.Text, "operator")
                         'update price 
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
                            Case "drdate"
                                update_specific_column_from_dr(row.Index, row.Text, "drdate")
                            Case "remarks"
                                update_specific_column_from_dr(row.Index, row.Text, "remarks")
                            Case "checkedby"
                                update_specific_column_from_dr(row.Index, row.Text, "checkedby")
                            Case "remarks"
                                update_specific_column_from_dr(row.Index, row.Text, "remarks")
                            Case "requestor"
                                update_specific_column_from_dr(row.Index, row.Text, "requestor")
                            Case "quarryarea"
                                Dim dr_item_id As Integer = row.Text
                                Dim specific_column As String = txtSpecificColumn.Text

                                update_specific_column_from_dr2(dr_item_id, specific_column, row.Index)
                            Case "drdatesubmitted"
                                update_specific_column_from_dr(row.Index, row.Text, "drdatesubmitted")
                            Case "drdatelog"
                                update_specific_column_from_dr(row.Index, row.Text, "drdatelog")
                            Case "in/out"
                                update_in_out_exclusive_for_dr_without_rs(row.SubItems(15).Text, cmbOperator.Text, row.Index)
                            Case "qty"
                                update_qty_exclusive_for_no_dr_and_rs(row.Text, row.SubItems(15).Text, IIf(IsNumeric(txtSpecificColumn.Text), txtSpecificColumn.Text, 0), row.Index)
                            Case "rs_id"
                                Dim dr_item_id As Integer = row.Text
                                Dim rs_id As Integer = txtSpecificColumn.Text

                                updateRsIdForDr(dr_item_id, rs_id, row.Index)
                        End Select

                    End If

                End If
            Next
        End If

    End Sub

    '5/27/24 (king)
    Private Sub update_in_out_exclusive_for_dr_without_rs(rs_id As Integer, inOut As String, rowindex As Integer)
        Try
            Dim update_inout As New Model_King_Dynamic_Update

            Dim columnValues As New Dictionary(Of String, Object)()
            columnValues.Add("IN_OUT", inOut)

            update_inout.UpdateData("dbrequisition_slip", columnValues, $"rs_id = {rs_id}")

            'MessageBox.Show("Successfully updated...", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()

            FDRLIST1.lvl_drList.Items(rowindex).SubItems(16).Text = cmbOperator.Text

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub update_qty_exclusive_for_no_dr_and_rs(dr_item_id As Integer, rs_id As Integer, qty As Double, rowindex As Integer)
        Try
            'for dr qty update
            Dim update_qty_for_dr As New Model_King_Dynamic_Update
            Dim columnValues As New Dictionary(Of String, Object)()
            columnValues.Add("qty", qty)

            update_qty_for_dr.UpdateData("dbDeliveryReport_items", columnValues, $"dr_items_id = {dr_item_id}")

            'for rs qty update
            Dim update_qty_for_rs As New Model_King_Dynamic_Update
            Dim columnValues2 As New Dictionary(Of String, Object)()
            columnValues2.Add("qty", qty)

            update_qty_for_rs.UpdateData("dbrequisition_slip", columnValues2, $"rs_id = {rs_id}")

            Select Case FDRLIST1.lvl_drList.SelectedItems(0).SubItems(15).Text
                Case "IN", "OTHERS"
                    FDRLIST1.lvl_drList.Items(rowindex).SubItems(6).Text = txtSpecificColumn.Text
                Case "OUT"
                    FDRLIST1.lvl_drList.Items(rowindex).SubItems(16).Text = txtSpecificColumn.Text
            End Select

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '06/12/24 king 
    Private Sub updateRsIdForDr(dr_item_id As Integer, rs_id As Integer, rowindex As Integer)
        Dim updateRsId As New Model_King_Dynamic_Update

        Dim columnValues As New Dictionary(Of String, Object)()
        columnValues.Add("rs_id", rs_id)
        Dim tableName As String = "dbDeliveryReport_items"
        Dim conditions As String = $"dr_items_id = {dr_item_id}"

        updateRsId.UpdateData(tableName, columnValues, conditions)

        FDRLIST1.lvl_drList.Items(rowindex).SubItems(15).Text = txtSpecificColumn.Text
    End Sub

    'sept.9,2023(king)
    Private Sub update_specific_column_from_dr2(dr_item_id As Integer, specific_column As String, row_index As Integer)

        othercharges.clear_parameter()
        othercharges.parameter("@n", 3)

        'initialize involed variables first
        Dim exist As Integer = 0
        Dim id As Integer = 0
        Dim category As String = ""

        'check if charges exist in LISTOFCHARGES
        For Each row1 In othercharges.LISTOFCHARGES()
            If row1.charges_desc.ToUpper() = specific_column.ToUpper() Then
                id = row1.charges_id
                category = row1.category
                exist += 1
                Exit For
            End If
        Next

        If exist > 0 Then
            'initialize dynamic model function
            Dim _update_ As New Model_King_Dynamic_Update


            'initialize columns to update into dynamic functions
            Dim columnValues As New Dictionary(Of String, Object)()
            columnValues.Add("category", category)
            columnValues.Add("source_id", id)

            _update_.UpdateData("dbDeliveryReport_items", columnValues, $"dr_items_id={dr_item_id }")

            'update specific column only
            FDRLIST1.lvl_drList.Items(row_index).SubItems(36).Text = specific_column

            'select rows
            listfocus(FDRLIST1.lvl_drList, row_index)
        Else
            MessageBox.Show("Unable to save data, charges is not found in Charges List..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub update_specific_column_from_dr(rowindex As Integer, dr_item_id As Integer, whatcolumn As String)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_Delivery_Receipt3", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            Select Case whatcolumn
                Case "date"
                    newCMD.Parameters.AddWithValue("@n", 47)
                    newCMD.Parameters.AddWithValue("@date", Date.Parse(dtpDrDate.Text))
                    FDRLIST1.lvl_drList.Items(rowindex).SubItems(3).Text = Format(Date.Parse(dtpDrDate.Text), "MM/dd/yyyy")

                Case "operator"
                    With newCMD.Parameters
                        If FDRLIST1.check_operator_id_if_null(dr_item_id) = "null" Then
                            .AddWithValue("@n", 60)
                            .AddWithValue("@outsource_operator", cmbOperator.Text)
                        ElseIf FDRLIST1.check_operator_id_if_null(dr_item_id) = "not-null" Then
                            .AddWithValue("@n", 48)
                            .AddWithValue("@operator_id", operator_id)
                        End If
                    End With

                    FDRLIST1.lvl_drList.Items(rowindex).SubItems(9).Text = cmbOperator.Text

                Case "price"

                    If FDRLIST1.lvl_drList.Items(rowindex).SubItems(16).Text = "OUT" Then
                        'FDRLIST.lvl_drList.Items(rowindex).SubItems(28).Text = FormatNumber(CDbl(FDRLIST.lvl_drList.Items(rowindex).SubItems(26).Text) * CDbl(FDRLIST.lvl_drList.Items(rowindex).SubItems(27).Text), 2,, TriState.True)

                        If FDRLIST1.lvl_drList.Items(rowindex).BackColor = Color.LightGreen Then
                            'Intended for editing price ddto sa withdrawal
                            Dim po_det_id As Integer = dr_item_id

                            newCMD.Parameters.AddWithValue("@price", txtSpecificColumn.Text)
                            newCMD.Parameters.AddWithValue("@n", 61)
                            newCMD.Parameters.AddWithValue("@po_det_id", po_det_id)

                            Dim get_po_det_id As Integer = newCMD.ExecuteNonQuery()

                            FDRLIST1.btnSearch.PerformClick()
                            listfocus(FDRLIST1.lvl_drList, get_po_det_id)

                            Me.Close()
                            Exit Sub
                        Else
                            MessageBox.Show("The item that you've trying to edit is from withdrawal." & vbCrLf & "You may go to withdrawal form " & vbCrLf & "or select the withdrawal rows to edit the data.", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Exit Sub
                        End If
                    Else
                        FDRLIST1.lvl_drList.Items(rowindex).SubItems(27).Text = FormatNumber(CDbl(txtSpecificColumn.Text), 2,,, TriState.True)
                        FDRLIST1.lvl_drList.Items(rowindex).SubItems(28).Text = FormatNumber(CDbl(FDRLIST1.lvl_drList.Items(rowindex).SubItems(6).Text) * CDbl(FDRLIST1.lvl_drList.Items(rowindex).SubItems(27).Text), 2,, TriState.True)
                    End If

                    newCMD.Parameters.AddWithValue("@price", txtSpecificColumn.Text)
                    newCMD.Parameters.AddWithValue("@n", 49)

                Case "received by"
                    newCMD.Parameters.AddWithValue("@n", 50)
                    newCMD.Parameters.AddWithValue("@receivedby", txtSpecificColumn.Text)
                    FDRLIST1.lvl_drList.Items(rowindex).SubItems(13).Text = txtSpecificColumn.Text

                Case "Concession"
                    newCMD.Parameters.AddWithValue("@n", 51)
                    newCMD.Parameters.AddWithValue("@con_ticket_no", txtSpecificColumn.Text)
                    FDRLIST1.lvl_drList.Items(rowindex).SubItems(8).Text = txtSpecificColumn.Text

                Case "drno"
                    newCMD.Parameters.AddWithValue("@n", 52)
                    newCMD.Parameters.AddWithValue("@dr_no", txtSpecificColumn.Text)
                    FDRLIST1.lvl_drList.Items(rowindex).SubItems(1).Text = txtSpecificColumn.Text

                Case "plateno"
                    newCMD.Parameters.AddWithValue("@n", 53)
                    newCMD.Parameters.AddWithValue("@plate_no", txtSpecificColumn.Text)
                    FDRLIST1.lvl_drList.Items(rowindex).SubItems(24).Text = txtSpecificColumn.Text

                Case "supplier"
                    newCMD.Parameters.AddWithValue("@n", 54)
                    newCMD.Parameters.AddWithValue("@supplier", txtSpecificColumn.Text)
                    FDRLIST1.lvl_drList.Items(rowindex).SubItems(22).Text = txtSpecificColumn.Text

                Case "drdate"
                    newCMD.Parameters.AddWithValue("@n", 55)
                    'newCMD.Parameters.AddWithValue("@date", Date.Parse(dtpDrDate.Text))
                    FDRLIST1.lvl_drList.Items(rowindex).SubItems(3).Text = Format(Date.Parse(dtpDrDate.Text), "MM/dd/yyyy")

                Case "remarks"
                    newCMD.Parameters.AddWithValue("@n", 56)
                    newCMD.Parameters.AddWithValue("@remarks", txtSpecificColumn.Text)
                    FDRLIST1.lvl_drList.Items(rowindex).SubItems(21).Text = txtSpecificColumn.Text

                Case "checkedby"
                    newCMD.Parameters.AddWithValue("@n", 57)
                    newCMD.Parameters.AddWithValue("@checked_by", txtSpecificColumn.Text)
                    FDRLIST1.lvl_drList.Items(rowindex).SubItems(12).Text = txtSpecificColumn.Text

                Case "wsno"
                    Dim po_det_id As Integer = dr_item_id
                    Dim old_ws_no As String = FDRLIST1.lvl_drList.SelectedItems(0).SubItems(19).Text

                    newCMD.Parameters.AddWithValue("@n", 62)
                    newCMD.Parameters.AddWithValue("@old_ws_no", old_ws_no)
                    newCMD.Parameters.AddWithValue("@ws_no", txtSpecificColumn.Text)
                    newCMD.Parameters.AddWithValue("@po_det_id", po_det_id)
                    newCMD.ExecuteNonQuery()
                    Me.Dispose()
                    FDRLIST1.btnSearch.PerformClick()
                    Exit Sub

                Case "wsdate"
                    Dim po_det_id As Integer = dr_item_id

                    newCMD.Parameters.AddWithValue("@n", 63)
                    newCMD.Parameters.AddWithValue("@date", Date.Parse(dtpDrDate.Text))
                    newCMD.Parameters.AddWithValue("@po_det_id", po_det_id)
                    newCMD.ExecuteNonQuery()
                    Me.Dispose()
                    FDRLIST1.btnSearch.PerformClick()
                    Exit Sub

                Case "wsremarks"
                    Dim po_det_id As Integer = dr_item_id

                    newCMD.Parameters.AddWithValue("@n", 64)
                    newCMD.Parameters.AddWithValue("@remarks", txtSpecificColumn.Text)
                    newCMD.Parameters.AddWithValue("@po_det_id", po_det_id)
                    newCMD.ExecuteNonQuery()

                    Me.Dispose()
                    FDRLIST1.btnSearch.PerformClick()

                    Exit Sub

                Case "withdrawnby"
                    Dim po_det_id As Integer = dr_item_id

                    newCMD.Parameters.AddWithValue("@n", 65)
                    newCMD.Parameters.AddWithValue("@withdrawnby", txtSpecificColumn.Text)
                    newCMD.Parameters.AddWithValue("@po_det_id", po_det_id)
                    newCMD.ExecuteNonQuery()

                    Me.Dispose()
                    FDRLIST1.btnSearch.PerformClick()

                    Exit Sub

                Case "requestor"
                    Dim rs_id As Integer = FDRLIST1.lvl_drList.SelectedItems(0).SubItems(15).Text

                    newCMD.Parameters.AddWithValue("@n", 66)
                    newCMD.Parameters.AddWithValue("@rs_id", rs_id)
                    newCMD.Parameters.AddWithValue("@dr_item_id", dr_item_id)
                    newCMD.Parameters.AddWithValue("@requestor", txtSpecificColumn.Text)

                    newCMD.ExecuteNonQuery()

                    Exit Sub

                Case "drdatesubmitted"
                    newCMD.Parameters.AddWithValue("@n", 68)
                    newCMD.Parameters.AddWithValue("@drdatesubmitted", Date.Parse(dtpDrDate.Text))
                    FDRLIST1.lvl_drList.Items(rowindex).SubItems(37).Text = Format(Date.Parse(dtpDrDate.Text), "MM/dd/yyyy")
                    newCMD.Parameters.AddWithValue("@dr_item_id", dr_item_id)
                    newCMD.ExecuteNonQuery()

                    Exit Sub

                Case "drdatelog"
                    newCMD.Parameters.AddWithValue("@n", 69)
                    newCMD.Parameters.AddWithValue("@drdatelog", Date.Parse(dtpDrDate.Text))
                    'FDRLIST1.lvl_drList.Items(rowindex).SubItems(37).Text = Format(Date.Parse(dtpDrDate.Text), "MM/dd/yyyy")
                    newCMD.Parameters.AddWithValue("@dr_item_id", dr_item_id)
                    newCMD.ExecuteNonQuery()

                    Exit Sub

            End Select

            newCMD.Parameters.AddWithValue("@date", Date.Parse(dtpDrDate.Text))
            newCMD.Parameters.AddWithValue("@dr_item_id", dr_item_id)
            newCMD.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub
    Private Sub udpate_ws_no_in_dr_first()
        With FDRLIST1
            Dim count As Integer
            Dim ws_no As String = .lvl_drList.SelectedItems(0).SubItems(19).Text

            For Each row As ListViewItem In .lvl_drList.Items
                If row.BackColor = Color.LightYellow Then
                    If row.SubItems(19).Text = ws_no Then
                        count += 1
                    End If
                End If
            Next

            If count > 0 Then
                If MessageBox.Show("there are " & count & " DR affected, do you still want to update?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                    For Each row As ListViewItem In .lvl_drList.Items
                        If row.BackColor = Color.LightYellow Then
                            If row.SubItems(19).Text = ws_no Then
                                'update ws no sa dr
                                Dim dr_item_id As Integer = row.Text

                            End If
                        End If
                    Next
                End If
            End If

        End With


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
        If editspecificdr = "received by" Then 'received by
            Dim txtbox As TextBox = sender

            If txtbox.Text = "" Then
                lboxUnit.Location = New System.Drawing.Point(txtbox.Location.X + 10, txtbox.Location.Y + txtbox.Height + 10)
                lboxUnit.Visible = False
            Else
                lboxUnit.Visible = True
                With lboxUnit
                    .BringToFront()
                    .Location = New System.Drawing.Point(txtbox.Location.X + 10, txtbox.Location.Y + txtbox.Height + 10)
                    .Visible = True
                    .Items.Clear()
                    .Width = txtbox.Width
                End With

                get_dr_info("txtreceivedby", txtbox.Text, txtbox)
            End If

        ElseIf editspecificdr = "plateno" Then 'plateno
            Dim txtbox As TextBox = sender

            If txtbox.Text = "" Then
                lboxUnit.Location = New System.Drawing.Point(txtbox.Location.X + 10, txtbox.Location.Y + txtbox.Height + 10)
                lboxUnit.Visible = False
            Else
                lboxUnit.Visible = True
                With lboxUnit
                    .BringToFront()
                    .Location = New System.Drawing.Point(txtbox.Location.X + 10, txtbox.Location.Y + txtbox.Height + 10)
                    .Visible = True
                    .Items.Clear()
                    .Width = txtbox.Width
                End With

                get_plate_no(txtSpecificColumn.Text)
            End If

        ElseIf editspecificdr = "supplier" Then 'supplier
            Dim txtbox As TextBox = sender

            If txtbox.Text = "" Then

                lboxUnit.Location = New System.Drawing.Point(txtbox.Location.X + 10, txtbox.Location.Y + txtbox.Height + 10)
                lboxUnit.Visible = False
            Else
                lboxUnit.Visible = True
                With lboxUnit
                    .BringToFront()
                    .Location = New System.Drawing.Point(txtbox.Location.X + 10, txtbox.Location.Y + txtbox.Height + 10)
                    .Visible = True
                    .Items.Clear()
                    .Width = txtbox.Width
                End With

                get_supplier(txtSpecificColumn.Text)
            End If

        ElseIf editspecificdr = "requestor" Then 'requestor
            Dim txtbox As TextBox = sender

            If txtbox.Text = "" Then

                lboxUnit.Location = New System.Drawing.Point(txtbox.Location.X + 10, txtbox.Location.Y + txtbox.Height + 10)
                lboxUnit.Visible = False
            Else
                lboxUnit.Visible = True
                With lboxUnit
                    .BringToFront()
                    .Location = New System.Drawing.Point(txtbox.Location.X + 10, txtbox.Location.Y + txtbox.Height + 10)
                    .Visible = True
                    .Items.Clear()
                    .Width = txtbox.Width
                End With

                get_requestor("WAREHOUSE", txtSpecificColumn.Text)
            End If

        ElseIf editspecificdr = "quarryarea" Then



        Else

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
    Public Sub get_requestor(type_of_requestor As String, requestor As String)
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
            newCMD.Parameters.AddWithValue("@n", 8)
            newCMD.Parameters.AddWithValue("@search", requestor)
            newCMD.Parameters.AddWithValue("@category", type_of_requestor)

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

    Private Sub lboxUnit_KeyDown(sender As Object, e As KeyEventArgs) Handles lboxUnit.KeyDown
        If e.KeyCode = Keys.Enter Then
            If lboxUnit.Items.Count > 0 Then

                txtSpecificColumn.Text = lboxUnit.SelectedItem.ToString
                txtSpecificColumn.Focus()
                lboxUnit.Visible = False
                lboxUnit.Items.Clear()
                Exit Sub

            End If
        ElseIf e.KeyCode = Keys.Back Then
            'txtSpecificColumn.Focus()
            'Dim n As Integer = txtSpecificColumn.Text.Length
            'Dim a As String = txtSpecificColumn.Text
            'txtSpecificColumn.Text = a.Substring(0, n - 1)
            txtSpecificColumn.Focus()

        ElseIf e.KeyCode = Keys.Up Then
            If lboxUnit.SelectedIndex = 0 Then
                txtSpecificColumn.Focus()
            End If
        End If
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

    Private Sub EditDR1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class