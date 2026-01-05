Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class Class_SC_Hauling
    Dim SCH As SC_Hauling_Data

    Sub New(SCH1 As SC_Hauling_Data)
        SCH = SCH1
    End Sub

    Public Structure SC_Hauling_Data

        Dim wh_id As Integer
        Dim personal_temp_name As String

        Dim item_name As String
        Dim item_desc As String
        Dim classification As String
        Dim wh_area As String

        Dim date_from As DateTime
        Dim date_to As DateTime
        Dim lvl As ListView
        Dim user_id As Integer
        Dim lbl_prev_balance As Label
        Dim intended As String
        Dim rowindex As Integer


    End Structure

    Public Function temp_name_exist(tempname As String) As Boolean
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_stock_card_for_hauling_and_crushing", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 1)
            newCMD.Parameters.AddWithValue("@personal_temp_tbl", tempname)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                If newDR.Item("obj_id").ToString = "" Then
                    temp_name_exist = False
                Else
                    temp_name_exist = True
                End If

            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function

    Public Function create_temp_table(tempname As String)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Try

            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_stock_card_for_hauling_and_crushing", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 2)
            newCMD.Parameters.AddWithValue("@personal_temp_tbl", tempname)
            newCMD.ExecuteNonQuery()


        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function

    Public Sub select_tbl_for_out_in(rs_id As Integer, inout As String, n As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_stock_card_for_hauling_and_crushing", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", n)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                If inout = "OUT" Then

                    insert_tbl_for_out_in(convert_to_int(newDR.Item("rs_id").ToString),
                                  convert_to_int(newDR.Item("po_det_id").ToString),
                                  convert_to_int(newDR.Item("qty").ToString),
                                  convert_string_to_date(newDR.Item("po_date").ToString),
                                  SCH.user_id,
                                  inout
                                  )

                ElseIf inout = "IN" Then
                    insert_tbl_for_out_in(convert_to_int(newDR.Item("rs_id").ToString),
                                 convert_to_int(newDR.Item("rr_item_id").ToString),
                                 convert_to_int(newDR.Item("desired_qty").ToString),
                                 convert_string_to_date(newDR.Item("date_received").ToString),
                                 SCH.user_id,
                                 inout
                                 )

                End If

            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Private Function convert_to_int(value As String) As Double
        If IsNumeric(value) Then
            convert_to_int = value
        Else
            convert_to_int = 0
        End If
    End Function
    Private Function convert_string_to_date(value As String) As DateTime
        If IsDate(value) Then
            convert_string_to_date = value
        Else
            convert_string_to_date = "1990-01-01"
        End If
    End Function

    Public Sub insert_tbl_for_out_in(rs_id As Integer, po_det_rr_id As Integer, qty As Double, po_rr_date As DateTime, user_id As Integer, inout As String)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_stock_card_for_hauling_and_crushing", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 1)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)
            newCMD.Parameters.AddWithValue("@po_det_rr_id", po_det_rr_id)
            newCMD.Parameters.AddWithValue("@qty", qty)
            newCMD.Parameters.AddWithValue("@po_rr_date", po_rr_date)
            newCMD.Parameters.AddWithValue("@user_id", user_id)
            newCMD.Parameters.AddWithValue("@inout", inout)
            newCMD.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Public Sub from_rs(inout As String)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_stock_card_for_hauling_and_crushing", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            Dim wh_id As Integer

            If SCH.intended = "STOCKCARD" Then
                newCMD.Parameters.AddWithValue("@date_from", Date.Parse(SCH.date_from).AddDays(-1))
                wh_id = get_wh_id()
            ElseIf SCH.intended = "WAREHOUSE ITEM" Then
                newCMD.Parameters.AddWithValue("@date_from", Date.Parse(SCH.date_from))
                wh_id = SCH.wh_id
            End If

            newCMD.Parameters.AddWithValue("@n", 4)
            newCMD.Parameters.AddWithValue("@wh_id", wh_id)
            newCMD.Parameters.AddWithValue("@inout", inout)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                If inout = "OUT" Then
                    select_tbl_for_out_in(newDR.Item("rs_id").ToString, inout, 2)
                ElseIf inout = "IN" Then
                    select_tbl_for_out_in(newDR.Item("rs_id").ToString, inout, 3)
                End If

            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Public Function get_wh_id() As Integer
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_stock_card_for_hauling_and_crushing", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 5)
            newCMD.Parameters.AddWithValue("@item_name", SCH.item_name)
            newCMD.Parameters.AddWithValue("@item_desc", SCH.item_desc)
            newCMD.Parameters.AddWithValue("@wh_area", SCH.wh_area)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                get_wh_id = newDR.Item("wh_id").ToString
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function

    Public Sub st_delete()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_stock_card_for_hauling_and_crushing", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.Parameters.AddWithValue("@n", 6)
            newCMD.Parameters.AddWithValue("@user_id", SCH.user_id)

            newCMD.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Public Function prev_balance() As Double
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_stock_card_for_hauling_and_crushing", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 7)

            If SCH.intended = "STOCKCARD" Then
                newCMD.Parameters.AddWithValue("@date_from", Date.Parse(SCH.date_from).AddDays(-1))

            ElseIf SCH.intended = "WAREHOUSE ITEM" Then
                newCMD.Parameters.AddWithValue("@date_from", Date.Parse(SCH.date_from))

            End If

            newCMD.Parameters.AddWithValue("@user_id", SCH.user_id)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                If newDR.Item("inout").ToString = "OUT" Then
                    prev_balance -= newDR.Item("qty").ToString

                ElseIf newDR.Item("inout").ToString = "IN" Then
                    prev_balance += newDR.Item("qty").ToString

                End If

            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function

    Public Function prev_balance_from_excel() As Decimal
        Dim wh_id As Integer

        If SCH.intended = "STOCKCARD" Then
            wh_id = get_wh_id()
        ElseIf SCH.intended = "WAREHOUSE ITEM" Then
            wh_id = SCH.wh_id
        End If

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_stock_card_for_hauling_and_crushing", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 8)
            newCMD.Parameters.AddWithValue("@wh_id", wh_id)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                prev_balance_from_excel = newDR.Item("balance").ToString
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function

    Public Sub prev_balance_in_label()

        With SCH.lbl_prev_balance
            If .InvokeRequired Then
                .Invoke(Sub()
                            .Text = prev_balance() + prev_balance_from_excel()
                        End Sub)
            Else
                .Text = prev_balance() + prev_balance_from_excel()
            End If
        End With
        'c_search.prev_balance +c_search.prev_balance_from_excel
    End Sub
    Public Sub prev_balance_in_label_new()

        With SCH.lbl_prev_balance
            If .InvokeRequired Then
                .Invoke(Sub()
                            .Text = prev_balance_in_label2()
                        End Sub)
            Else
                .Text = prev_balance_in_label2()
            End If
        End With
        'c_search.prev_balance +c_search.prev_balance_from_excel
    End Sub

    Public Function prev_balance_in_label1() As Double
        With SCH.lbl_prev_balance
            prev_balance_in_label1 = prev_balance() + prev_balance_from_excel()
        End With
    End Function

    Public Function prev_balance_in_label2() As Decimal
        With SCH.lbl_prev_balance
            'MsgBox(+prev_balance_from_excel() & vbCrLf & prev_balance_out_in("IN") & vbCrLf & prev_balance_out_in("OUT"))



            prev_balance_in_label2 = (prev_balance_out_in("IN") + prev_balance_from_excel()) - prev_balance_out_in("OUT")


            'Dim bal_in As Decimal = prev_balance_out_in("IN")
            'Dim prev_bal_from_excel As Decimal = prev_balance_from_excel()
            'Dim bal_out As Decimal = prev_balance_out_in("OUT")

            'Dim balance As Decimal = (bal_in + prev_bal_from_excel) - bal_out

            'SCH.lvl.Items(SCH.rowindex).SubItems(4).Text = balance
        End With
    End Function

    Public Sub arrange_balance()
        With SCH.lvl
            If .InvokeRequired Then
                .Invoke(Sub()
                            Dim countitems As Integer = .Items.Count - 1
                            Dim balance As Decimal = CDec(SCH.lbl_prev_balance.Text)

                            For i = 0 To countitems
                                If .Items(i).SubItems(14).Text = "OUT" Then
                                    .Items(i).SubItems(10).Text = balance - CDec(.Items(i).SubItems(9).Text)
                                    balance = balance - CDec(.Items(i).SubItems(9).Text)
                                Else
                                    .Items(i).SubItems(10).Text = balance + CDec(.Items(i).SubItems(8).Text)
                                    balance = balance + CDec(.Items(i).SubItems(8).Text)
                                End If
                            Next
                        End Sub)
            Else
                Dim countitems As Integer = .Items.Count - 1
                Dim balance As Decimal = CDec(SCH.lbl_prev_balance.Text)

                For i = 0 To countitems
                    If .Items(i).SubItems(14).Text = "OUT" Then
                        .Items(i).SubItems(10).Text = balance - CDec(.Items(i).SubItems(9).Text)
                        balance = balance - CDec(.Items(i).SubItems(9).Text)
                    Else
                        .Items(i).SubItems(10).Text = balance + CDec(.Items(i).SubItems(8).Text)
                        balance = balance + CDec(.Items(i).SubItems(8).Text)
                    End If
                Next
            End If
        End With

    End Sub

    Public Sub rem_balance(prev_balance As Double)
        'SCH.lvl.Items(SCH.rowindex).SubItems(4).Text = prev_balance
        Dim bal_in As Decimal = prev_balance_out_in1("IN")
        Dim prev_bal_from_excel As Decimal = prev_balance_from_excel()
        Dim bal_out As Decimal = prev_balance_out_in1("OUT")

        Dim balance As Decimal = (bal_in + prev_bal_from_excel) - bal_out

        SCH.lvl.Items(SCH.rowindex).SubItems(4).Text = balance

    End Sub

    Public Function prev_balance_out_in(inout As String) As Decimal
        Dim wh_id As Integer = get_wh_id()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_stock_card_for_hauling_and_crushing", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 9)
            newCMD.Parameters.AddWithValue("@wh_id", wh_id)
            newCMD.Parameters.AddWithValue("@date_from", Date.Parse(SCH.date_from).AddDays(-1))
            newDR = newCMD.ExecuteReader

            While newDR.Read
                If newDR.Item("type_of_purchasing").ToString = "PURCHASE ORDER" And newDR.Item("po_det_id").ToString = "" Then

                Else
                    If newDR.Item("IN_OUT").ToString = inout Then

                        If newDR.Item("withdrawn_id").ToString = "" Then
                        Else
                            prev_balance_out_in += newDR.Item("qty").ToString
                        End If

                    End If

                End If
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function
    Public Function prev_balance_out_in1(inout As String) As Double
        Dim wh_id As Integer = SCH.wh_id
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_stock_card_for_hauling_and_crushing", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 9)
            newCMD.Parameters.AddWithValue("@wh_id", wh_id)
            newCMD.Parameters.AddWithValue("@date_from", Date.Parse(SCH.date_from))
            newDR = newCMD.ExecuteReader

            While newDR.Read
                If newDR.Item("type_of_purchasing").ToString = "PURCHASE ORDER" And newDR.Item("po_det_id").ToString = "" Then

                Else
                    If newDR.Item("IN_OUT").ToString = inout Then

                        If newDR.Item("withdrawn_id").ToString = "" Then
                        Else
                            prev_balance_out_in1 += newDR.Item("qty").ToString
                        End If

                    End If

                End If
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function

    Public Sub stock_card()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Dim wh_id As Integer = get_wh_id()

        With SCH.lvl
            If .InvokeRequired Then
                .Invoke(Sub()
                            SCH.lvl.Items.Clear()
                        End Sub)
            Else
                SCH.lvl.Items.Clear()
            End If
        End With

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_stock_card_for_hauling_and_crushing", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 10)
            newCMD.Parameters.AddWithValue("@wh_id", wh_id)
            newCMD.Parameters.AddWithValue("@date_from", Date.Parse(SCH.date_from))
            newCMD.Parameters.AddWithValue("@date_to", Date.Parse(SCH.date_to))
            newDR = newCMD.ExecuteReader

            While newDR.Read
                Dim a(16) As String
                a(0) = newDR.Item("rs_id").ToString
                a(2) = Format(Date.Parse(newDR.Item("po_date").ToString), "MM/dd/yyyy")
                a(3) = newDR.Item("rs_no").ToString
                a(4) = newDR.Item("invoice_no").ToString
                a(5) = newDR.Item("rr_no").ToString
                a(6) = newDR.Item("ws_no").ToString
                a(7) = "supplier"

                Select Case newDR.Item("IN_OUT").ToString
                    Case "OUT"
                        a(9) = newDR.Item("qty").ToString
                    Case "IN"
                        a(6) = ""
                        a(8) = newDR.Item("qty").ToString
                End Select

                a(10) = 0
                a(11) = "" 'remarks 
                a(14) = newDR.Item("IN_OUT").ToString

                Dim lvl As New ListViewItem(a)

                With SCH.lvl
                    If .InvokeRequired Then
                        .Invoke(Sub()
                                    If newDR.Item("IN_OUT").ToString = "OUT" Then
                                        lvl.BackColor = Color.LightGreen
                                    Else
                                        lvl.BackColor = Color.LightYellow
                                    End If

                                    SCH.lvl.Items.Add(lvl)
                                End Sub)
                    Else
                        If newDR.Item("IN_OUT").ToString = "OUT" Then
                            lvl.BackColor = Color.LightGreen
                        Else
                            lvl.BackColor = Color.LightYellow
                        End If

                        SCH.lvl.Items.Add(lvl)
                    End If
                End With
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub


End Class
