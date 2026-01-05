Imports System.Data.SqlClient
Imports System.Data.Sql

Public Class FItem_Sets
    Private rs_no, date_req, jono, Location, item_desc, unit, typeofreq, Process, purpose, date_need, requested_by, noted_by, in_out, date_log, typeofpurchasing, main_sub As String
    Private charge_to, wh_id, qty, user_id, tor_sub_id As Integer
    Dim norecordindbBorrower_checking_items As Integer
    Private Sub FItem_Sets_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_set_items_in_combobox()

        'cmbSetsItem.Items.Clear()
        'load_wh_item_and_desc(0, "")

    End Sub
    Private Sub load_wh_item_and_desc(n As Integer, whItem As String)

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()

            Dim query As String = ""

            If n = 0 Then
                query = "SELECT DISTINCT whItem FROM dbwarehouse_items ORDER BY whItem ASC"
            ElseIf n = 1 Then
                query = "SELECT whItemDesc FROM dbwarehouse_items WHERE whItem = '" & whItem & "' ORDER BY whItem ASC"
            End If
            newCMD = New SqlCommand(query, newSQ.connection)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                If n = 0 Then
                    cmbSetsItem.Items.Add(newDR.Item("whItem").ToString)
                ElseIf n = 1 Then
                    ComboBox1.Items.Add(newDR.Item("whItemDesc").ToString)
                End If

            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub
    Private Sub load_set_items_in_combobox()

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        cmbSetsItem.Items.Clear()

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_borrower_new", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 24)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                cmbSetsItem.Items.Add(newDR.Item("set_items").ToString)
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Public Sub LOAD_set_items_in_listview(set_item_id As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim counter As Integer = 0

        ListView1.Items.Clear()

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_borrower_new", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 16) '166

            newCMD.Parameters.AddWithValue("@set_item_id", set_item_id)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                'item_set_desc(CInt(newDR.Item("set_det_id").ToString), newDR.Item("sub_details").ToString)
                list_of_item_available(CInt(newDR.Item("set_det_id").ToString), newDR.Item("sub_details").ToString)
                counter += 1

            End While
            newDR.Close()

            If counter = 0 Then
                list_of_item_available1(wh_id, ComboBox1.Text)
            End If

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub
    Public Sub list_of_item_available1(wh_id As Integer, item_name As String)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_borrower_new", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 177)
            newCMD.Parameters.AddWithValue("@wh_id", wh_id)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                Dim a(5) As String
                Dim rs_id As Integer
                Dim rr_item_sub_id As Integer = CInt(newDR.Item("rr_item_sub_id").ToString)
                Dim br_tr_det_id As Integer

                'FIRST:
                'if exist in @n=21 where rr_item_sub_id,then set rs_id
                rs_id = set_rs_id(rr_item_sub_id)

                'SECOND
                'if exist in @n=19 where rs_id = set_rs_id and rr_item_sub_id = rr_item_sub_id, then set br_tr_det_id
                br_tr_det_id = set_br_tr_det_id(rs_id, rr_item_sub_id)

                'THIRD
                If rs_id > 0 And br_tr_det_id > 0 And check_if_item_turnover(br_tr_det_id, rs_id) = True Then
                    'available
                ElseIf rs_id = 0 And br_tr_det_id = 0 And check_if_item_turnover(br_tr_det_id, rs_id) = False Then
                    'available
                ElseIf rs_id > 0 And br_tr_det_id > 0 And check_if_item_turnover(br_tr_det_id, rs_id) = False Then
                    GoTo proceedhere

                ElseIf rs_id > 0 And br_tr_det_id = 0 And check_if_item_turnover(br_tr_det_id, rs_id) = False Then
                    GoTo proceedhere

                End If

                a(0) = rr_item_sub_id
                a(1) = item_name
                a(2) = newDR.Item("item_desc").ToString
                a(3) = newDR.Item("rr_item_id").ToString

                Dim lvl As New ListViewItem(a)
                ListView1.Items.Add(lvl)

proceedhere:
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Public Sub list_of_item_available(set_det_id As Integer, item_name As String)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_borrower_new", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 17)
            newCMD.Parameters.AddWithValue("@set_det_id", set_det_id)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                Dim a(5) As String
                Dim rs_id As Integer
                Dim rr_item_sub_id As Integer = CInt(newDR.Item("rr_item_sub_id").ToString)
                Dim br_tr_det_id As Integer

                'FIRST:
                'if exist in @n=21 where rr_item_sub_id,then set rs_id
                rs_id = set_rs_id(rr_item_sub_id)

                'SECOND
                'if exist in @n=19 where rs_id = set_rs_id and rr_item_sub_id = rr_item_sub_id, then set br_tr_det_id
                br_tr_det_id = set_br_tr_det_id(rs_id, rr_item_sub_id)

                'THIRD
                If rs_id > 0 And br_tr_det_id > 0 And check_if_item_turnover(br_tr_det_id, rs_id) = True Then
                    'available
                ElseIf rs_id = 0 And br_tr_det_id = 0 And check_if_item_turnover(br_tr_det_id, rs_id) = False Then
                    'available
                ElseIf rs_id > 0 And br_tr_det_id > 0 And check_if_item_turnover(br_tr_det_id, rs_id) = False Then
                    GoTo proceedhere

                ElseIf rs_id > 0 And br_tr_det_id = 0 And check_if_item_turnover(br_tr_det_id, rs_id) = False Then
                    GoTo proceedhere

                End If

                a(0) = rr_item_sub_id
                a(1) = item_name
                a(2) = newDR.Item("item_desc").ToString
                a(3) = newDR.Item("rr_item_id").ToString

                Dim lvl As New ListViewItem(a)
                ListView1.Items.Add(lvl)

proceedhere:
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub
    Private Function check_if_item_turnover(br_tr_det_id As Integer, rs_id As Integer) As Boolean
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader


        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_borrower_new", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 20)
            newCMD.Parameters.AddWithValue("@br_tr_det_id", br_tr_det_id)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                check_if_item_turnover = True
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function

    Private Function set_rs_id(rr_item_sub_id As Integer) As Integer
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader


        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_borrower_new", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 21)
            newCMD.Parameters.AddWithValue("@rr_item_sub_id", rr_item_sub_id)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                set_rs_id = CInt(newDR.Item("rs_id").ToString)
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function
    Private Function set_br_tr_det_id(rs_id As Integer, rr_item_sub_id As Integer) As Integer
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader


        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_borrower_new", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 19)
            newCMD.Parameters.AddWithValue("@rr_item_sub_id", rr_item_sub_id)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                set_br_tr_det_id = CInt(newDR.Item("br_tr_det_id").ToString)
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function


    Public Sub item_set_desc(set_det_id As Integer, item_name As String)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader


        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_borrower_new", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 17)
            newCMD.Parameters.AddWithValue("@set_det_id", set_det_id)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                Dim a(5) As String
                Dim rs_id As Integer = CInt(FRequistionForm.lvlrequisitionlist.SelectedItems(0).Text)
                'If check_if_this_item_available(newDR.Item("rr_item_sub_id").ToString) = False Then
                '    GoTo proceedhere
                'End If

                If check_if_already_reserved(rs_id, CInt(newDR.Item("rr_item_sub_id").ToString)) > 0 Then
                    GoTo proceedhere
                End If

                If norecordindbBorrower_checking_items = 0 Then

                End If

                a(0) = newDR.Item("rr_item_sub_id").ToString
                a(1) = item_name
                a(2) = newDR.Item("item_desc").ToString
                a(3) = newDR.Item("rr_item_id").ToString
                'Dim available As Integer = FListofBorrowerItem.if_item_available(CInt(a(0)))

                'If available = 0 Then
                '    GoTo proceedhere
                'End If

                Dim lvl As New ListViewItem(a)
                ListView1.Items.Add(lvl)

proceedhere:

            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Private Sub cmbSetsItem_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSetsItem.SelectedIndexChanged
        Dim set_item_id As Integer = get_id("dbSet_Items", "set_items", cmbSetsItem.Text, 0)

        LOAD_set_items_in_listview(set_item_id)

        'ComboBox1.Items.Clear()
        'load_wh_item_and_desc(1, cmbSetsItem.Text)

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim wh_id As Integer = get_id("dbwarehouse_items", "whItem^whItemDesc", cmbSetsItem.Text & "^" & ComboBox1.Text, 2)
        LOAD_set_items_in_listview(wh_id)
    End Sub

    Public Function check_if_already_reserved1(rs_id As Integer, set_det_id As Integer) As Integer
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader


        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_borrower_new", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 23)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)
            newCMD.Parameters.AddWithValue("@set_det_id", set_det_id)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                check_if_already_reserved1 += 1
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function
    Public Function check_if_already_reserved(rs_id As Integer, rr_item_sub_id As Integer) As Integer
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader


        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_borrower_new", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 21)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)
            newCMD.Parameters.AddWithValue("@rr_item_sub_id", rr_item_sub_id)

            newDR = newCMD.ExecuteReader

            While newDR.Read

                If rs_id = CInt(newDR.Item("rs_id").ToString) Then
                    check_if_already_reserved = 1
                    Exit Function
                End If

                'first: check kung na barrow bani nga item. (NOTE:kwaon ratong pinaka updated)
                Dim query As String = "SELECT TOP 1 * FROM dbborrower_details WHERE rr_item_sub_id = " & CInt(newDR.Item("rr_item_sub_id").ToString)
                Dim br_tr_det_id As Integer = get_last_row_id(query, "br_tr_det_id", 1)

                If br_tr_det_id = 0 Then 'if zero, wala pa sukad na barrow

                Else
                    'sencond: kung na borrow, check kung na turnover na.
                    If check_if_exist("dbborrower_turnover_details", "br_tr_det_id", br_tr_det_id, 0) > 0 Then
                        'kung na turnover na
                        check_if_already_reserved = 0
                    Else
                        'na borrow pero wala pa na turnover
                        check_if_already_reserved += 1

                    End If
                    'end second
                End If
                'end first
                norecordindbBorrower_checking_items += 1
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function
    Public Function check_if_this_item_available(rr_item_sub_id As Integer) As Boolean
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader


        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_borrower_new", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 19)
            newCMD.Parameters.AddWithValue("@rr_item_sub_id", rr_item_sub_id)

            newDR = newCMD.ExecuteReader

            Dim borrowed_and_turnover As Integer

            While newDR.Read

                If check_if_turnover(newDR.Item("br_tr_det_id").ToString) > 0 Then
                    borrowed_and_turnover = 2
                Else
                    borrowed_and_turnover = 1
                End If

            End While
            newDR.Close()

            If borrowed_and_turnover = 2 Or borrowed_and_turnover = 0 Then
                check_if_this_item_available = True

            ElseIf borrowed_and_turnover = 1 Then
                check_if_this_item_available = False

            End If

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function
    Public Function check_if_turnover(br_tr_det_id As Integer) As Integer
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_borrower_new", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 20)
            newCMD.Parameters.AddWithValue("@br_tr_det_id", br_tr_det_id)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                check_if_turnover += 1

            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim rs_no As String = FRequistionForm.lvlrequisitionlist.SelectedItems(0).SubItems(1).Text
        Dim rs_id As Integer = CInt(FRequistionForm.lvlrequisitionlist.SelectedItems(0).Text)
        ListView2.Items.Clear()

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_borrower_new", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 16)
            '1 is temporary, id na sa computer set
            Dim set_item_id As Integer = get_id("dbSet_Items", "set_items", cmbSetsItem.Text, 0)
            newCMD.Parameters.AddWithValue("@set_item_id", set_item_id)
            Dim wh_id As Integer = get_id("dbwarehouse_items", "whItem^whItemDesc", cmbSetsItem.Text & "^" & ComboBox1.Text, 2)
            newCMD.Parameters.AddWithValue("@wh_id", wh_id)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                Dim a(10) As String

                a(0) = newDR.Item("set_det_id").ToString
                a(1) = newDR.Item("sub_details").ToString
                a(2) = item_qty_available(a(1), 2)
                a(3) = item_qty_available(a(1), 1)
                a(5) = newDR.Item("wh_id").ToString

                'If a(2) = "" Then
                '    a(2) = "Purchase"

                '    'If a(3) = 0 Then
                '    '    a(3) = 1
                '    'End If
                'End If

                'If a(3) = 0 Then
                'not available,so check sa kung na reserved naba ni sa kini nga rs_id

                If check_if_already_reserved1(rs_id, CInt(a(0))) > 0 Then
                    a(2) = "Already Reserved"
                    a(3) = 0
                Else
                    Dim count As Integer = 0
                    For Each row As ListViewItem In ListView1.Items
                        If row.Checked = True Then
                            If a(1) = row.SubItems(1).Text Then
                                count += 1
                                a(4) &= CInt(row.Text) & ","
                            End If
                        End If
                    Next

                    If count > 0 Then
                        a(2) = "Reserved"
                        a(3) = count
                    Else
                        a(2) = "Purchase"
                        a(3) = 1
                    End If


                End If
                'End If

                'If check_if_item_has_already_requested(a(1), rs_no) > 0 Then

                '    If MessageBox.Show("item: " & a(1) & " has already request to purchase," & vbCrLf & "do you want to proceed?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                '        a(2) = "Already Requested"
                '    Else
                '        a(2) = "Purchase"
                '    End If
                'Else
                '    If MessageBox.Show("item: " & a(1) & " has already request to purchase," & vbCrLf & "do you want to proceed?", "SUPPLY INFO:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                '        a(2) = "Already Reserved"
                '    Else
                '        a(2) = "Purchase"
                '    End If
                'End If

                'If CInt(a(3)) > 0 Then
                '    a(2) = "Reserved"
                'Else
                '    a(2) = "Purchase"
                'End If
                If a(4) = "" Then
                Else
                    a(4) = remove_last_character(a(4))
                End If

                Dim lvl As New ListViewItem(a)
                ListView2.Items.Add(lvl)

proceedhere:

            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub
    Public Function check_if_item_has_already_requested(item_name As String, rs_no As String) As Integer
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader


        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_borrower_new", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 22)
            newCMD.Parameters.AddWithValue("@rs_no", rs_no)
            newCMD.Parameters.AddWithValue("@value", item_name)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                check_if_item_has_already_requested += 1

            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function

    Public Function update_qty_if_item_has_already_requested(item_name As String, rs_no As String) As Integer
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader


        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_borrower_new", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 22)
            newCMD.Parameters.AddWithValue("@rs_no", rs_no)
            newCMD.Parameters.AddWithValue("@value", item_name)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                Dim query As String = "UPDATE dbrequisition_slip SET qty = " & CInt(newDR.Item("qty").ToString) + 1 & " WHERE rs_id = " & CInt(newDR.Item("rs_id").ToString)
                UPDATE_INSERT_DELETE_QUERY(query, 0, "UPDATE")

                update_qty_if_item_has_already_requested += 1

            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function

    Public Function item_qty_available(sub_details As String, n As Integer) As String
        Dim qty As Integer = 0
        Dim counter As Integer

        For Each row As ListViewItem In ListView1.Items
            If sub_details = row.SubItems(1).Text Then
                If row.Checked = True Then
                    If n = 1 Then
                        qty += 1
                    ElseIf n = 2 Then
                        item_qty_available = "Reserved"
                    End If
                End If
                counter += 1
            End If
        Next

        'For Each row As ListViewItem In ListView1.Items

        '    If sub_details = row.SubItems(1).Text Then
        '        If row.Checked = True Then
        '            If n = 1 Then
        '                qty += 1
        '            ElseIf n = 2 Then
        '                item_qty_available = "Reserved"
        '            End If

        '        ElseIf row.Checked = False Then
        '            If n = 1 Then
        '                qty += 1
        '            ElseIf n = 2 Then
        '                item_qty_available = "Purchase"
        '            End If
        '        End If

        '    End If
        'Next

        If qty = 0 Then
            qty = 1
        End If

        If counter = 0 Then
            qty = 0
        End If

        If n = 1 Then
            item_qty_available = qty
        End If

    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim checkingInfo_id As Integer
        Dim rs_id As Integer = CInt(FRequistionForm.lvlrequisitionlist.SelectedItems(0).Text)
        Dim rs_no As String = FRequistionForm.lvlrequisitionlist.SelectedItems(0).SubItems(1).Text

        If ListView1.Items.Count > 0 Then

            If check_if_exist("dbBorrower_checking_info", "rs_id", rs_id, 1) = 0 Then 'if dili zero, no need to insert na
                dbBorrower_checking_info(rs_id) 'insert to dbBorrower_checking_info            
            End If

            Dim query As String = "SELECT checking_info_id FROM dbBorrower_checking_info WHERE rs_id = " & rs_id
            checkingInfo_id = get_specific_column_value(query, 1) 'get id from dbBorrower_checking_info

        End If

        For Each row As ListViewItem In ListView2.Items

            If row.Checked = True Then
                If row.SubItems(2).Text = "Already Reserved" Or row.SubItems(2).Text = "Already Requested" Then
                    GoTo proceedhere
                End If

                ''checked items lng ang e insert (RESERVED)
                get_checked_item(row.SubItems(1).Text, checkingInfo_id)

                'unchecked items (PURCHASE)
                'get_unchecked_item(row.SubItems(1).Text, checkingInfo_id)

                If row.SubItems(2).Text = "Purchase" Then
                    storing_variables_from_requisition_slip()
                    item_desc = row.SubItems(1).Text

                    If update_qty_if_item_has_already_requested(item_desc, rs_no) > 0 Then

                    Else
                        'insert ni ddto sa requisition_slip table
                        insert_to_requisition_slip(CInt(row.SubItems(5).Text))
                    End If

                ElseIf row.SubItems(2).Text = "Reserved" Then
                    'insert to dbBorrower_reserved
                    'rr_item_sub_id,item_desc,qty,rs_id,rs_no

                    Dim split_id() As String
                    Dim raw_rr_item_sub_id As String = row.SubItems(4).Text

                    split_id = raw_rr_item_sub_id.Split(",")

                    For Each id As String In split_id.ToArray
                        Dim rr_item_sub_id As Integer = CInt(id)
                        Dim item_desc As String = row.SubItems(1).Text

                        insert_reserved_item(rr_item_sub_id, item_desc, 1, rs_id, rs_no)

                    Next

                End If
            End If
proceedhere:

        Next

        'update pd ang inout sa req.slip status into borrowed
        update_into_borrower(rs_id, 0)

        'storing_variables_from_requisition_slip()

        'For Each row As ListViewItem In ListView2.Items
        '    If row.Checked = True Then
        '        item_desc = row.SubItems(1).Text
        '        'insert ni ddto sa requisition_slip table
        '        insert_to_requisition_slip()
        '    End If
        'Next

        Me.Dispose()

    End Sub
    Public Sub insert_reserved_item(ByVal rr_item_sub_id As Integer, ByVal item_desc As String, qty As Integer, rs_id As Integer, rs_no As String)
        Dim newsq As New SQLcon
        Dim newcmd As SqlCommand

        Try
            newsq.connection.Open()
            publicquery = "INSERT INTO dbBorrower_reserved(rs_id, rs_no, rr_item_sub_id, item_desc,qty) VALUES ('" & rs_id & "', '" & rs_no & "', '" & rr_item_sub_id & "', '" & item_desc & "'," & qty & ")"
            newcmd = New SqlCommand(publicquery, newsq.connection)
            newcmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newsq.connection.Close()
        End Try
    End Sub

    Public Sub get_checked_item(item_name As String, checkingInfo_id As Integer)

        For Each row As ListViewItem In ListView1.Items
            If item_name = row.SubItems(1).Text Then
                If row.Checked = True Then
                    insert_borrowerchercking_items(checkingInfo_id, CInt(row.Text), row.SubItems(1).Text, 0, 1, CInt(row.SubItems(3).Text))
                End If
            End If
        Next

    End Sub

    Public Sub get_unchecked_item(item_name As String, checkingInfo_id As Integer)
        'store sa sa variable tanan data sa req_slip equal to rs_id
        storing_variables_from_requisition_slip()

        For Each row As ListViewItem In ListView1.Items
            If item_name = row.SubItems(1).Text Then
                If row.Checked = False Then
                    item_desc = row.SubItems(1).Text

                    'insert ni ddto sa requisition_slip table

                    'insert_to_requisition_slip()

                    ''insert into rs_ts_sub_property

                End If
            End If
        Next
    End Sub
    Public Function get_tor_sub_id() As Integer
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim rs_id As Integer = CInt(FRequistionForm.lvlrequisitionlist.SelectedItems(0).Text)

        Try
            newSQ.connection.Open()
            Dim query As String = "SELECT * FROM rs_tor_sub_property WHERE rs_id = " & rs_id
            newCMD = New SqlCommand(query, newSQ.connection)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                get_tor_sub_id = newDR.Item("tor_sub_id").ToString
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function
    Public Sub insert_tor_sub_id(tor_sub_id As Integer, rs_id As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Try
            newSQ.connection.Open()
            Dim query As String = "INSERT INTO rs_tor_sub_property(rs_id,tsp_id,tor_sub_id) VALUES(" & rs_id & "," & 0 & "," & tor_sub_id & ")"
            newCMD = New SqlCommand(query, newSQ.connection)
            newCMD.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub


#Region "FROM FListofBorrwerItem Code(Gibson)"

    Public Sub dbBorrower_checking_info(rs_id As Integer)
        Dim SQLconn As New SQLcon
        Dim command As SqlCommand
        Try
            SQLconn.connection.Open()

            publicquery = "INSERT INTO dbBorrower_checking_info (rs_id, rs_no) VALUES ('" & rs_id & "', '" & rs_no & "')"
            command = New SqlCommand(publicquery, SQLconn.connection)
            command.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLconn.connection.Close()
        End Try
    End Sub

    Public Sub insert_dbBorrower_checking_items()

        Dim query As String = "SELECT checking_info_id FROM dbBorrower_checking_info WHERE rs_id = " & rs_id
        Dim checkingInfo_id As Integer = get_specific_column_value(query, 1)

    End Sub

    Public Sub insert_borrowerchercking_items(ByVal checking_info_id As Integer, ByVal rrItem_sub_id As Integer, ByVal item_name As String, ByVal itemNo As String, ByVal qty As Decimal, ByVal rritem_id As Integer)
        Dim newSQLcon As New SQLcon
        Dim newCMD As SqlCommand

        Try
            'If check_if_exist("dbBorrower_checking_items", "rr_item_sub_id", rrItem_sub_id, 1) = 0 Then

            newSQLcon.connection.Open()

            publicquery = "INSERT INTO dbBorrower_checking_items (checking_info_id, rr_item_sub_id, item_name, item_no, qty, rr_item_id) VALUES ('" & checking_info_id & "', '" & rrItem_sub_id & "',"
            publicquery &= "'" & item_name & "', '" & itemNo & "', '" & qty & "', '" & rritem_id & "')"
            newCMD = New SqlCommand(publicquery, newSQLcon.connection)

            newCMD.ExecuteNonQuery()

            'End If

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQLcon.connection.Close()
        End Try

    End Sub

    Public Sub storing_variables_from_requisition_slip()

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim rs_id As Integer = CInt(FRequistionForm.lvlrequisitionlist.SelectedItems(0).Text)

        Try
            newSQ.connection.Open()
            Dim query As String = "SELECT * FROM dbrequisition_slip WHERE rs_id = " & rs_id
            newCMD = New SqlCommand(query, newSQ.connection)
            newDR = newCMD.ExecuteReader

            While newDR.Read

                rs_no = newDR.Item("rs_no").ToString
                date_req = newDR.Item("date_req").ToString
                jono = newDR.Item("job_order_no").ToString
                charge_to = CInt(newDR.Item("charge_to").ToString)
                Location = newDR.Item("location").ToString
                wh_id = CInt(newDR.Item("wh_id").ToString)
                qty = CInt(newDR.Item("qty").ToString)
                unit = newDR.Item("unit").ToString
                typeofreq = newDR.Item("typeRequest").ToString
                Process = newDR.Item("process").ToString
                purpose = newDR.Item("purpose").ToString
                date_need = newDR.Item("date_needed").ToString
                requested_by = newDR.Item("requested_by").ToString
                noted_by = newDR.Item("noted_by").ToString
                in_out = "OTHERS"
                date_log = newDR.Item("date_log").ToString
                typeofpurchasing = "PURCHASE ORDER"
                user_id = CInt(newDR.Item("user_id").ToString)

            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub

    Public Sub insert_to_requisition_slip(wh_id As Integer)

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Try
            newSQ.connection.Open()
            main_sub = "SUB"
            publicquery = "SET NOCOUNT ON;"

            publicquery = "INSERT INTO dbrequisition_slip(rs_no,date_req,job_order_no,charge_to,location,"
            publicquery &= "wh_id,item_desc,qty,unit,typeRequest,process,purpose,date_needed,requested_by,"
            publicquery &= "noted_by,IN_OUT,date_log,type_of_purchasing,user_id,remarks,main_sub)"
            publicquery &= " VALUES('" & rs_no & "','"
            publicquery &= date_req & "','" & jono & "','" & charge_to & "','"
            publicquery &= Location & "','" & wh_id & "','" & item_desc & "'," & qty & ",'" & "pc" & "','"
            publicquery &= typeofreq & "','" & Process & "','" & purpose & "','" & date_need & "','" & requested_by & "','"
            publicquery &= noted_by & "','" & "OTHERS" & "','" & date_log & "','" & typeofpurchasing & "'," & user_id & "," & 0 & ",'" & main_sub & "')"

            publicquery &= "SELECT SCOPE_IDENTITY()"

            newCMD = New SqlCommand(publicquery, newSQ.connection)
            Dim rs_id As Integer = newCMD.ExecuteScalar()

            'kini nga function insert ni xa og unsa nga type of request like MAJOR,MINOR or pang project (NOTE: og wala ni xa, dili mo display sa requisitionslip nga form)
            insert_tor_sub_id(get_tor_sub_id, rs_id)

            ''kini nga function insert sa mark facilities
            'Dim query As String = "INSERT INTO Mark_Fac_Tools(rs_id,Marker) VALUES(" & rs_id & ",'" & "FACILITIES" & "')"
            'FRequistionForm.Borrower_Marker(query, "FACILITIES")

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()

            'UPDATE para sa main rs ky naa man pd sub(sub ng naa sa taas nga ge insert)
            Dim query As String
            Dim rs_id As Integer = CInt(FRequistionForm.lvlrequisitionlist.SelectedItems(0).Text)

            query = "UPDATE dbrequisition_slip SET main_sub = '" & "MAIN" & "' WHERE rs_id = " & rs_id
            UPDATE_INSERT_DELETE_QUERY(query, 0, "UPDATE")

        End Try

    End Sub

    Public Sub update_into_borrower(ByVal rsid As Integer, ByVal n As Integer)
        Dim nwSQL As New SQLcon
        Dim nwCMD As SqlCommand
        Dim in_out As String = ""

        If n = 0 Then
            in_out = "BORROWER"
        ElseIf n = 1 Then
            in_out = "TURNOVER"
        ElseIf n = 2 Then
            in_out = "BORROWED"
        End If

        Try
            nwSQL.connection.Open()
            publicquery = "UPDATE dbrequisition_slip SET IN_OUT = '" & in_out & "'WHERE rs_id = '" & rsid & "'"
            nwCMD = New SqlCommand(publicquery, nwSQL.connection)
            nwCMD.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            nwSQL.connection.Close()
        End Try
    End Sub
#End Region

End Class