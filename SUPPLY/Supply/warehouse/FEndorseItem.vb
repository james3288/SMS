Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class FEndorseItem

    Dim txtname As String
    Private Sub lvlEndorseItems_DoubleClick(sender As Object, e As EventArgs) Handles lvlEndorseItems.DoubleClick
        Dim wh_id As Integer
        Dim balance As Double
        Dim total_request As Double
        Dim total_qty_from_requestor As Double

        wh_id = lvlEndorseItems.SelectedItems(0).SubItems(1).Text

        With FListOfItems

            Dim qty_from_prev_stock_card As Double = .get_qty_from_dbPrevious_stock_card(wh_id)

            balance = FormatNumber(.get_wh_item_balance2(wh_id) + qty_from_prev_stock_card, , TriState.True) 'get_wh_item_balance(dr.Item("wh_id").ToString)
            total_request = .get_total_qty_requested_and_not_withdrawn_yet(wh_id, 1) '1 - total requested
            total_qty_from_requestor = FormatNumber(.get_total_qty_requested_and_not_withdrawn_yet(wh_id, 2),, TriState.True) '2 -total qty from requestor

        End With


        'txt_balanceNew.Text = CDbl(lvlWarehouseItem.SelectedItems(0).SubItems(4).Text) - CDbl(lvlWarehouseItem.SelectedItems(0).SubItems(6).Text)
        'txt_reorderPoint.Text = lvlWarehouseItem.SelectedItems(0).SubItems(8).Text
        'txtrequestqty.Text = FRequistionForm.lvlrequisitionlist.SelectedItems(0).SubItems(5).Text

        txt_balanceNew.Text = balance - total_qty_from_requestor
        txt_reorderPoint.Text = lvlEndorseItems.SelectedItems(0).SubItems(4).Text
        txtrequestqty.Text = FRequistionForm.lvlrequisitionlist.SelectedItems(0).SubItems(5).Text
        pnl_newqty.Visible = True

    End Sub
    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click

        pnl_newqty.Visible = False

    End Sub
    Public Sub type_of_req(ByVal in_out As String)

        With cmb_typeof_pucrchasing
            .Items.Clear()

            If in_out = "IN" Or in_out = "OTHERS" Then

                .Items.Add("CASH")
                .Items.Add("PURCHASE ORDER")
                .Items.Add("DR")
                .Items.Add("N/A")

                'txtWhIncharge.Text = "Vanessa Fabe Piedad"
                txtWhIncharge.Enabled = True
            ElseIf in_out = "OUT" Then
                .Items.Add("WITHDRAWAL")
                'txtWhIncharge.Text = "Vanessa Fabe Piedad"
                txtWhIncharge.Enabled = False


            End If

        End With

    End Sub

    Private Sub cmb_inOut_New_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_inOut_New.SelectedIndexChanged
        type_of_req(cmb_inOut_New.Text)
    End Sub

    Private Sub txtApproved_by_TextChanged(sender As Object, e As EventArgs) Handles txtApproved_by.TextChanged
        Try
            If txtApproved_by.Text = "" Then
                'lboxUnit.Location = New System.Drawing.Point(txtApproved_by.Bounds.Left, txtApproved_by.Bounds.Bottom)
                With lboxUnit
                    .Visible = False

                End With
            Else
                With lboxUnit
                    .Parent = pnl_newqty
                    .BringToFront()
                    .Enabled = True
                    .Location = New System.Drawing.Point(txtApproved_by.Bounds.Left, txtApproved_by.Bounds.Bottom)
                    .Visible = True
                    .Items.Clear()
                    .Width = txtApproved_by.Width
                End With

                Dim query As String = "SELECT DISTINCT approved_by FROM dbrequisition_slip WHERE approved_by LIKE '%" & txtApproved_by.Text & "%'"
                lboxUnit.Items.Clear()

                SELECT_QUERY3(query, lboxUnit)
                If lboxUnit.Items.Count > 0 Then
                Else
                    lboxUnit.Visible = False
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub lboxUnit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lboxUnit.SelectedIndexChanged

    End Sub

    Private Sub lboxUnit_KeyDown(sender As Object, e As KeyEventArgs) Handles lboxUnit.KeyDown
        If e.KeyCode = Keys.Back Then
            lboxUnit.Visible = False

            For Each ctr As Control In pnl_newqty.Controls
                If TypeOf ctr Is TextBox Then
                    If ctr.Name = txtname Then
                        ctr.Focus()

                    End If
                End If

            Next
        ElseIf e.KeyCode = Keys.Enter Then
            ' lboxUnit.SelectedIndex = 0

            For Each ctr As Control In pnl_newqty.Controls
                If TypeOf ctr Is TextBox Then
                    If ctr.Name = txtname Then
                        ctr.Text = lboxUnit.SelectedItem.ToString
                        ctr.Focus()
                    End If
                End If

            Next

            lboxUnit.Visible = False
        End If

    End Sub

    Private Sub txtApproved_by_GotFocus(sender As Object, e As EventArgs) Handles txtApproved_by.GotFocus
        txtname = txtApproved_by.Name
    End Sub

    Private Sub lboxUnit_DoubleClick(sender As Object, e As EventArgs) Handles lboxUnit.DoubleClick

        For Each ctr As Control In pnl_newqty.Controls
            If TypeOf ctr Is TextBox Then
                If ctr.Name = txtname Then
                    ctr.Text = lboxUnit.SelectedItem.ToString
                    ctr.Focus()
                End If
            End If
        Next

        lboxUnit.Visible = False
    End Sub

    Private Sub txtApproved_by_KeyDown(sender As Object, e As KeyEventArgs) Handles txtApproved_by.KeyDown
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Enter Then

            If lboxUnit.Visible = True Then
                If lboxUnit.Items.Count > 0 Then
                    lboxUnit.Focus()
                    lboxUnit.SelectedIndex = 0

                End If

            End If
        End If
    End Sub

    Private Sub btn_ok_Click(sender As Object, e As EventArgs) Handles btn_ok.Click
        If cmb_inOut_New.Text = "" Then

            MessageBox.Show("Select IN,OUT or OTHERS on the combobox first..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        ElseIf cmb_typeof_pucrchasing.Text = "" Then

            MessageBox.Show("Select WITHDRAWAL,CASH,PURCHASE ORDER,N/A on the combobox first..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        ElseIf cmb_factools.Text = "" Then

            MessageBox.Show("Select tools,facilities or N/A on the combobox first..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        End If

        If CInt(txt_balanceNew.Text) < CInt(txtrequestqty.Text) Then
            If cmb_inOut_New.Text = "IN" Or cmb_inOut_New.Text = "OTHERS" Then
                'continue...
            Else

                If CInt(txt_balanceNew.Text) = CInt(txt_reorderPoint.Text) Then
                    MessageBox.Show("Warning: " & vbCrLf & "Reorder point was already achieved", "Supply Info:", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                    If MessageBox.Show("Insufficient quantity," & vbCrLf & "are you still want to proceed?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Error) = DialogResult.Yes Then
                        'continue...
                    Else
                        Exit Sub
                    End If
                End If
            End If
        End If

        For Each ctr As Control In pnl_newqty.Controls
            If TypeOf ctr Is TextBox Or TypeOf ctr Is ComboBox Then
                If ctr.Text = "" Then
                    MessageBox.Show("Pls fill up some blank in the fields..", "SUPPLY INFO.", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End If
        Next

        Dim rs_id As Integer = FRequistionForm.lvlrequisitionlist.SelectedItems(0).Text
        item_checking_function(lvlEndorseItems.SelectedItems(0).SubItems(1).Text, cmb_inOut_New.Text, cmb_typeof_pucrchasing.Text, txt_remarks.Text, rs_id)


        Dim query As String = "SELECT main_sub FROM dbrequisition_slip WHERE rs_id = " & rs_id
        Dim main_sub As String = get_specific_column_value(query, 0)

        If main_sub = "SUB" Then

        ElseIf main_sub = "" Then
            If cmb_factools.Text = "FACILITIES" Or cmb_factools.Text = "TOOLS" Then
                Dim query1 As String = "UPDATE dbrequisition_slip SET main_sub = '" & "MAIN" & "', wh_incharge = '" & txtWhIncharge.Text & "',approved_by = '" & txtApproved_by.Text & "',warehouse_checker_id = " & pub_user_id & " WHERE rs_id = " & rs_id
                UPDATE_INSERT_DELETE_QUERY(query1, 0, "UPDATE")
            Else
                Dim query1 As String = "UPDATE dbrequisition_slip SET wh_incharge = '" & txtWhIncharge.Text & "',approved_by = '" & txtApproved_by.Text & "',warehouse_checker_id = " & pub_user_id & " WHERE rs_id = " & rs_id
                UPDATE_INSERT_DELETE_QUERY(query1, 0, "UPDATE")
            End If
        End If

        Me.Close()

        FRequistionForm.btnSearch.PerformClick()
        listfocus(FRequistionForm.lvlrequisitionlist, rs_id)
    End Sub

    Private Sub item_checking_function(wh_id As Integer, inout As String, typeofpurchasing As String, remarks1 As String, rs_id As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_QTO_maintenance", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 14)
            newCMD.Parameters.AddWithValue("@wh_id", wh_id)
            newCMD.Parameters.AddWithValue("@inout", inout)
            newCMD.Parameters.AddWithValue("@typeofpurchasing", typeofpurchasing)
            newCMD.Parameters.AddWithValue("@remarks1", remarks1)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)

            newCMD.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub

    Public Sub FEndorseItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListView1.Items.Clear()

        delete_temp_suggested_items()
        suggested_items()
        display_suggested_items()

    End Sub
    Private Sub display_suggested_items()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newdr As SqlDataReader
        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_requisition_search_item", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 9)
            newCMD.Parameters.AddWithValue("@user_id", pub_user_id)
            newdr = newCMD.ExecuteReader
            Dim a(10) As String
            While newdr.Read

                a(1) = newdr.Item("wh_id").ToString
                a(2) = newdr.Item("item_name").ToString
                a(3) = newdr.Item("item_desc").ToString
                a(5) = newdr.Item("wh_area").ToString
                a(6) = newdr.Item("whClass").ToString

                Dim lvl As New ListViewItem(a)
                ListView1.Items.Add(lvl)
            End While
            newdr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub



    Private Sub Button2_Click(sender As Object, e As EventArgs)
        'For Each row As ListViewItem In ListView1.Items
        '    h(row.Text, row.SubItems(1).Text, row.SubItems(2).Text)
        'Next

    End Sub

    Private Sub suggested_items()

        Dim item_desc_array() As String
        Dim item_name As String
        Dim from_wh As String

        from_wh = lvlEndorseItems.Items(0).SubItems(7).Text
        item_desc_array = lvlEndorseItems.Items(0).SubItems(3).Text.Split(" ")
        item_name = lvlEndorseItems.Items(0).SubItems(2).Text

        If from_wh = "no" Then
            Exit Sub
        End If

        For Each str As String In item_desc_array
            Dim newSQ As New SQLcon
            Dim newCMD As SqlCommand
            Dim newdr As SqlDataReader
            Try
                newSQ.connection.Open()
                newCMD = New SqlCommand("proc_requisition_search_item", newSQ.connection)
                newCMD.Parameters.Clear()
                newCMD.CommandType = CommandType.StoredProcedure

                newCMD.Parameters.AddWithValue("@n", 7)

                newCMD.Parameters.AddWithValue("@item_desc", str)
                newCMD.Parameters.AddWithValue("@item_name", item_name)
                newdr = newCMD.ExecuteReader
                Dim a(10) As String
                While newdr.Read

                    a(1) = newdr.Item("wh_id").ToString
                    a(2) = newdr.Item("whItem").ToString
                    a(3) = newdr.Item("whItemDesc").ToString

                    Dim lvl As New ListViewItem(a)
                    ListView1.Items.Add(lvl)
                End While
                newdr.Close()


            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                newSQ.connection.Close()
            End Try

            For Each row As ListViewItem In ListView1.Items
                insert_temp_suggested_items(row.SubItems(1).Text, row.SubItems(2).Text, row.SubItems(3).Text)
            Next
            ListView1.Items.Clear()
        Next

    End Sub

    Public Sub ClearArray(ByRef StrArray As String())
        For iK As Int16 = 0 To StrArray.Length - 1
            StrArray(iK) = ""
        Next
    End Sub

    Private Sub insert_temp_suggested_items(wh_id As Integer, item_name As String, item_desc As String)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_requisition_search_item", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 5)
            newCMD.Parameters.AddWithValue("@user_id", pub_user_id)
            newCMD.Parameters.AddWithValue("@wh_id", wh_id)
            newCMD.Parameters.AddWithValue("@item_name", item_name)
            newCMD.Parameters.AddWithValue("@item_desc", item_desc)

            newCMD.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Public Sub delete_temp_suggested_items()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_requisition_search_item", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 8)
            newCMD.Parameters.AddWithValue("@user_id", pub_user_id)

            newCMD.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        delete_temp_suggested_items()
        'suggested_items()
        'display_suggested_items()

    End Sub
End Class