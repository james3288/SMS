Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Threading

Public Class Class_StockCard_Hauling
    Dim item_name As String
    Dim item_desc As String
    Dim classification As String
    Dim swh1 As search_wh_data
    Public th2 As Threading.Thread

    Sub New(swh As search_wh_data)
        swh1 = swh
    End Sub

    Public Structure search_wh_data

        Dim item_name As String
        Dim item_desc As String
        Dim classification As String
        Dim date_from As DateTime
        Dim date_to As DateTime
        Dim lvl As ListView

    End Structure
    Public Function thread_status() As String
        ' Dim th As Threading.Thread = th2
        If IsNothing(th2) Then
        Else
            If th2.IsAlive Then
                thread_status = "alive"
            ElseIf Not th2.IsAlive Then
                thread_status = "not alive"
            End If
        End If

    End Function
    Public Function get_wh_id() As Integer
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_stock_monitoring", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 2)
            newCMD.Parameters.AddWithValue("@item_name", swh1.item_name)
            newCMD.Parameters.AddWithValue("@item_desc", swh1.item_desc)
            newCMD.Parameters.AddWithValue("@classification", swh1.classification)
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

    Public Sub stock_card_for_hauling_and_crushing(n As Integer)

        th2 = New Threading.Thread(AddressOf view_stock_card)
        th2.SetApartmentState(ApartmentState.MTA)
        th2.Start(n)

    End Sub

    Private Sub view_stock_card(n As Integer)
        If swh1.lvl.InvokeRequired Then
            swh1.lvl.Invoke(Sub()
                                swh1.lvl.Items.Clear()
                            End Sub)
        Else
            swh1.lvl.Items.Clear()
        End If

        Dim wh_id As Integer = get_wh_id()

        If wh_id = 0 Then
            Exit Sub
        End If

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_execute_tempstockcard2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.CommandTimeout = 0

            newCMD.Parameters.AddWithValue("@n", n)
            newCMD.Parameters.AddWithValue("@wh_id", wh_id)
            newCMD.Parameters.AddWithValue("@date_from", swh1.date_from)
            newCMD.Parameters.AddWithValue("@date_to", swh1.date_to)

            newDR = newCMD.ExecuteReader

            Dim a(20) As String
            Dim rowcount As Integer = 0
            While newDR.Read
                Dim ws_no As String = newDR.Item("WS_NO").ToString
                Dim rs_no As String = newDR.Item("rs_no").ToString

                Select Case n
                    Case 5
                        If newDR.Item("dr_option").ToString = "WITH DR" And newDR.Item("DR").ToString = "PARENT DR" Then
                            GoTo proceedhere1
                        End If

                        a(2) = Format(Date.Parse(newDR.Item("DATE_Withdrawn_received").ToString), "MM/dd/yyyy")
                        a(3) = IIf(newDR.Item("rs_no").ToString = "", "N/A", newDR.Item("rs_no").ToString)
                        a(4) = IIf(newDR.Item("dr_no_invoice_no").ToString = "", "N/A", newDR.Item("dr_no_invoice_no").ToString)
                        a(6) = IIf(newDR.Item("WS_no").ToString = "", "N/A", newDR.Item("WS_no").ToString)

                        If newDR.Item("IN_OUT").ToString = "OUT" Then

                            a(7) = newDR.Item("SOURCE_WH").ToString
                            a(8) = ""
                            a(9) = newDR.Item("desired_qty").ToString

                        ElseIf newDR.Item("IN_OUT").ToString = "IN" Then

                            a(4) = newDR.Item("dr_no_invoice_no").ToString
                            a(7) = newDR.Item("SOURCE_WH").ToString
                            a(8) = newDR.Item("desired_qty").ToString
                            a(9) = ""

                        End If
                        a(11) = newDR.Item("remarks").ToString

                        Dim lvl1 As New ListViewItem(a)
                        'swh1.lvl.Items.Add(lvl1)
                        InvokeRequiredList(swh1.lvl, lvl1)

proceedhere1:

                    Case 11
                        If newDR.Item("WITHDRAWN").ToString = "NO" Then
                            GoTo proceedhere
                        End If

                        If newDR.Item("stat").ToString = "" And newDR.Item("dr_no").ToString = "" Then
                            GoTo proceedhere

                        ElseIf newDR.Item("stat").ToString = "" And newDR.Item("dr_no").ToString <> "" Then
                            a(4) = newDR.Item("dr_no").ToString
                            a(5) = "N/A"
                            a(6) = "N/A"
                        End If

                        a(2) = Format(Date.Parse(newDR.Item("date").ToString), "MM/dd/yyyy")
                        a(3) = newDR.Item("rs_no").ToString

                        Dim stat As String = newDR.Item("stat").ToString

                        a(4) = newDR.Item("dr_no").ToString.ToUpper
                        a(5) = newDR.Item("RR_NO").ToString.ToUpper
                        a(6) = newDR.Item("WS_NO").ToString.ToUpper

                        a(5) = IIf(newDR.Item("RR_NO").ToString.ToUpper = "", "N/A", newDR.Item("RR_NO").ToString.ToUpper)

                        If newDR.Item("IN_OUT").ToString = "OUT" Then
                            a(7) = newDR.Item("SOURCE_WH").ToString

                            If newDR.Item("SORTING").ToString = "A" Then
                                a(8) = ""

                                a(9) = CDbl(newDR.Item("qty_OUT").ToString) - count_qty_dr_using_ws_no(ws_no, rs_no, 12)

                                'example 12/8 so, 8-12 = -4 therefore,  dili pde mag negative
                                If a(9) < 0 Then
                                    'beginning_balance = beginning_balance - 0
                                Else
                                    'beginning_balance = beginning_balance - CDbl(a(9))
                                End If

                                If count_qty_dr_using_ws_no(ws_no, rs_no, 12) = 0 Then
                                    a(9) = CDbl(newDR.Item("qty_OUT").ToString)
                                Else
                                    a(9) = count_qty_dr_using_ws_no(ws_no, rs_no, 12) & "/" & CDbl(newDR.Item("qty_OUT").ToString)
                                End If

                                'a(10) = FormatNumber(beginning_balance,,, TriState.True)

                            Else
                                a(8) = ""
                                a(9) = newDR.Item("qty_OUT").ToString

                            End If

                        ElseIf newDR.Item("IN_OUT").ToString = "IN" Then
                            If newDR.Item("type_of_purchasing").ToString = "PURCHASE ORDER" Then
                                a(7) = get_supp_recepient(newDR.Item("dr_no").ToString)
                            Else
                                a(7) = newDR.Item("SOURCE_WH").ToString
                            End If

                            a(8) = newDR.Item("qty_IN").ToString
                            a(9) = ""

                        End If

                        a(11) = newDR.Item("remarks").ToString

                        Dim lvl1 As New ListViewItem(a)
                        'swh1.lvl.Items.Add(lvl1)
                        InvokeRequiredList(swh1.lvl, lvl1)

                        If newDR.Item("SORTING").ToString = "A" Then
                            If newDR.Item("type_of_delivery").ToString = "WITHOUT DR" Then
                            Else

                                If swh1.lvl.InvokeRequired Then
                                    swh1.lvl.Invoke(Sub()
                                                        swh1.lvl.Items(rowcount).BackColor = Color.LightBlue
                                                        swh1.lvl.Items(rowcount).ForeColor = Color.Black
                                                    End Sub)
                                Else
                                    swh1.lvl.Items(rowcount).BackColor = Color.LightBlue
                                    swh1.lvl.Items(rowcount).ForeColor = Color.Black
                                End If

                            End If
                        End If

                        rowcount += 1
proceedhere:
                End Select
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
            'calculate_remaining_balance()
        End Try

    End Sub
    Private Sub InvokeRequiredList(listview As ListView, lvl As ListViewItem)

        If listview.InvokeRequired Then
            listview.Invoke(Sub() listview.Items.Add(lvl))
        Else
            listview.Items.Add(lvl)
        End If

    End Sub

    Public Function count_qty_dr_using_ws_no(ws_no As String, rs_no As String, n As Integer) As Double
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_execute_tempstockcard2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", n)
            newCMD.Parameters.AddWithValue("@ws_no", ws_no)
            newCMD.Parameters.AddWithValue("@rs_no", rs_no)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                If newDR.Item("qty").ToString = "" Then
                    count_qty_dr_using_ws_no = 0
                Else
                    count_qty_dr_using_ws_no = CDbl(newDR.Item("qty").ToString)
                End If

            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function

    Private Function get_supp_recepient(dr_no As String) As String

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_execute_tempstockcard2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 19)
            newCMD.Parameters.AddWithValue("@dr_no", dr_no)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                get_supp_recepient = newDR.Item("Supp_Rec").ToString
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function
End Class
