Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class class_agg_remaining_balance
    Public Property wh_id As Integer
    Public my_prev_balance As Double
    Public supplier_recepient As String
    Public myBalanceNow As Double
    Public dr_qty_using_wsno As Double
    Public cListOfStockCard As New List(Of agg_data)

    Private whid As Integer
    Private cDateFrom As DateTime
    Private cDateTo As DateTime

    Private trd As Threading.Thread


    'SET PREVIOUS BALANCE 
    Public Sub prev_balance()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            Dim query As String = "SELECT a.balance FROM dbPrevious_stock_card a WHERE a.wh_id = " & wh_id

            newCMD = New SqlCommand(query, newSQ.connection)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                my_prev_balance = newDR.Item("balance").ToString()
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    'GET AGGREGATES DATA
    Public Sub aggregates_data(wh_id As Integer, Datefrom As DateTime, DateTo As DateTime)

        whid = wh_id
        cDateFrom = Datefrom
        cDateTo = DateTo

        trd = New Threading.Thread(AddressOf get_aggregates_data)
        trd.Start()
        trd.Join()

    End Sub
    Private Sub get_aggregates_data()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_execute_tempstockcard2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 11)
            newCMD.Parameters.AddWithValue("@wh_id", whid)
            newCMD.Parameters.AddWithValue("@date_from", cDatefrom)
            newCMD.Parameters.AddWithValue("@date_to", cDateTo)

            'warehouse_location(wh_id)

            newDR = newCMD.ExecuteReader

            Dim a(20) As String
            Dim rowcount As Integer = 0

            While newDR.Read
                Dim ws_no As String = newDR.Item("WS_NO").ToString
                Dim rs_no As String = newDR.Item("rs_no").ToString

                Dim newSc As New agg_data
                With newSc

                    If newDR.Item("WITHDRAWN").ToString = "NO" Then
                        GoTo proceedhere
                    End If

                    If newDR.Item("stat").ToString = "" And newDR.Item("dr_no").ToString = "" Then
                        GoTo proceedhere

                    ElseIf newDR.Item("stat").ToString = "" And newDR.Item("dr_no").ToString <> "" Then
                        .drno_invoice = newDR.Item("dr_no").ToString
                        .rr_no = "N/A"
                        .ws_no = "N/A"
                    End If

                    .drdate = Format(Date.Parse(newDR.Item("date").ToString), "MM/dd/yyyy")
                    .rs_no = newDR.Item("rs_no").ToString

                    Dim stat As String = newDR.Item("stat").ToString

                    .drno_invoice = newDR.Item("dr_no").ToString.ToUpper
                    .ws_no = newDR.Item("WS_NO").ToString.ToUpper
                    '.rr_no = IIf(newDR.Item("RR_NO").ToString.ToUpper = "", "N/A", newDR.Item("RR_NO").ToString.ToUpper)
                    .rr_no = newDR.Item("RR_NO").ToString

                    .sorting = newDR.Item("SORTING").ToString
                    .type_of_purchasing = newDR.Item("type_of_purchasing").ToString
                    .inout = newDR.Item("IN_OUT").ToString
                    .type_of_delivery = newDR.Item("type_of_delivery").ToString
                    .stat = newDR.Item("stat").ToString

                    If newDR.Item("IN_OUT").ToString = "OUT" Then
                        .supp_recipient = newDR.Item("SOURCE_WH").ToString

                        If newDR.Item("SORTING").ToString = "A" Then
                            .qty_in = 0

                            '_rs_no = .rs_no
                            '_ws_no = .ws_no

                            'count_qty_dr_using_ws_no()
                            '--COUNT DR QTY USING WSNO------------------------------
                            Dim tr4 As Threading.Thread
                            Dim dr_qty_using_wsno_dict As New Dictionary(Of String, String)

                            dr_qty_using_wsno_dict.Add("_rs_no", .rs_no)
                            dr_qty_using_wsno_dict.Add("_ws_no", .ws_no)

                            tr4 = New Threading.Thread(AddressOf get_qty_using_wsno)
                            tr4.Start(dr_qty_using_wsno_dict)
                            tr4.Join()
                            '-------------------------------------------------------

                            Dim count_qty_dr As Double = dr_qty_using_wsno
                            .qty_out = CDbl(newDR.Item("qty_OUT").ToString) - count_qty_dr

                            If count_qty_dr = 0 Then
                                .qty_out = CDbl(newDR.Item("qty_OUT").ToString)
                            Else
                                .qty_out = count_qty_dr & "/" & CDbl(newDR.Item("qty_OUT").ToString)
                            End If

                            'RS->WS->NO DR (OUT)
                            If .stat = "OUT WITH RS AND WS BUT NO DR" And .drno_invoice = "" Then
                                .drno_invoice = "N/A"
                            End If

                        ElseIf newDR.Item("SORTING").ToString = "B" Then

                            If .stat = "" And .drno_invoice = "N/A" Then 'NO RS->NO DR (create transaction from items -> OUT)
                                .supp_recipient = newDR.Item("agg_supplier").ToString
                            ElseIf .stat = "" And .drno_invoice <> "N/A" Then
                                .supp_recipient = newDR.Item("agg_supplier").ToString
                            End If

                            .qty_in = 0
                            .qty_out = newDR.Item("qty_OUT").ToString

                        End If

                        'THIS CODE IS FOR RS->PO->RR->DR IN
                    ElseIf newDR.Item("IN_OUT").ToString = "IN" Then
                        If newDR.Item("type_of_purchasing").ToString = "PURCHASE ORDER" Then 'RS->PO->RR->DR
                            'supplier_recepient()

                            '------GET SUPPLIER/RECEPIENT------------
                            Dim aaa As New Dictionary(Of String, String)

                            aaa.Add("dr_no", .drno_invoice)
                            aaa.Add("stat", .stat)
                            aaa.Add("type_of_purchasing", .type_of_purchasing)
                            aaa.Add("supprec", newDR.Item("r2").ToString)
                            aaa.Add("dr_items_id", IIf(newDR.Item("dr_items_id").ToString = "", 0, newDR.Item("dr_items_id").ToString))

                            Dim t3 As Threading.Thread
                            t3 = New Threading.Thread(AddressOf get_supp_recepient)
                            t3.Start(aaa)
                            t3.Join()
                            '-----------------------------------------

                            .supp_recipient = supplier_recepient


                        ElseIf newDR.Item("type_of_purchasing").ToString = "DR" And .stat = "IN WITH RS AND RR BUT WITH DR" Then 'RS->DR
                            '------GET SUPPLIER/RECEPIENT------------
                            'Dim aaa As New Dictionary(Of String, String)

                            'aaa.Add("dr_no", .drno_invoice)
                            'aaa.Add("stat", .stat)
                            'aaa.Add("type_of_purchasing", .type_of_purchasing)
                            'aaa.Add("supprec", newDR.Item("r2").ToString)
                            'aaa.Add("dr_items_id", IIf(newDR.Item("dr_items_id").ToString = "", 0, newDR.Item("dr_items_id").ToString))

                            'Dim t4 As Threading.Thread
                            't4 = New Threading.Thread(AddressOf get_supp_recepient)
                            't4.Start(aaa)
                            't4.Join()

                            .supp_recipient = newDR.Item("agg_supplier").ToString

                            '-----------------------------------------
                        Else

                            .supp_recipient = newDR.Item("SOURCE_WH").ToString
                        End If

                        .qty_in = newDR.Item("qty_IN").ToString
                        .qty_out = 0

                    ElseIf newDR.Item("IN_OUT").ToString = "OTHERS" Then

                    End If

                    If .qty_out = "" Then
                        .qty_out = 0
                    End If

                    If .qty_in = "" Then
                        .qty_in = 0
                    End If

                    .remarks = newDR.Item("remarks").ToString

                    'THIS CODE IS FOR OUT AND IN WITHOUR RS AND DR
                    If .rs_no.Contains("N/A") And .drno_invoice.Contains("N/A") Or .rs_no.Contains("n/a") And .drno_invoice.Contains("n/a") Then
                        If .inout = "IN" Then

                            .supp_recipient = newDR.Item("r2").ToString
                        ElseIf .inout = "OUT" Then
                            '.supp_recipient = newDR.Item("SOURCE_WH").ToString 'newDR.Item("r").ToString
                            .ws_no = "-"
                        End If
                    End If
                    '--------------------------------------

                    'THIS CODE IS FOR IN WITHOUT RS BUT WITH DR
                    If .rs_no.Contains("N/A") And .drno_invoice <> "" Or .rs_no.Contains("N/A") And Not .drno_invoice.Contains("N/A") Then
                        If .inout = "IN" Then
                            '.supp_recipient = newDR.Item("r2").ToString
                            .supp_recipient = newDR.Item("agg_supplier").ToString
                            .ws_no = "-"
                        ElseIf .inout = "OUT" Then
                            '.supp_recipient = newDR.Item("SOURCE_WH").ToString
                            .ws_no = "-"
                        End If
                    End If


                    'THIS CODE IS FOR SUPPLIER RECEPIENT ONLY/ OVERWRITE TANAN SUPPRECEPIENT SA TAAS PINAAGI ANI NGA CODE, tungod ky naglibog nko sa code dli nalang nako deleton sa taas

                    cListOfStockCard.Add(newSc)

                    rowcount += 1
                End With
proceedhere:

            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    'GET SUPPLIER/SOURCE
    Private Function get_supp_recepient2()

    End Function
    Private Function get_supp_recepient(data As Dictionary(Of String, String)) As String

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_execute_tempstockcard2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            If data("stat") = "IN WITH RS AND RR BUT WITH DR" Then
                newCMD.Parameters.AddWithValue("@n", 19)
            ElseIf data("stat") = "IN WITH RS AND RR BUT NO DR" Then
                newCMD.Parameters.AddWithValue("@n", 191)
            End If

            newCMD.Parameters.AddWithValue("@dr_no", data("dr_no"))
            newCMD.Parameters.AddWithValue("@dr_items_id", data("dr_items_id"))
            newDR = newCMD.ExecuteReader

            While newDR.Read
                If data("stat") = "IN WITH RS AND RR BUT WITH DR" And data("type_of_purchasing") = "PURCHASE ORDER" Then
                    supplier_recepient = newDR.Item("Supp_Rec").ToString
                ElseIf data("stat") = "IN WITH RS AND RR BUT WITH DR" And data("type_of_purchasing") = "DR" Then
                    'supplier_recepient = "wait a miinute"
                ElseIf data("stat") = "IN WITH RS AND RR BUT NO DR" And data("type_of_purchasing") = "PURCHASE ORDER" Then
                    supplier_recepient = newDR.Item("Supp_Rec").ToString
                Else
                    supplier_recepient = newDR.Item("Supp_Rec").ToString
                End If

            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function

    'GET DR QY USING WSNO
    Private Sub get_qty_using_wsno(dr_qty_using_wsno_dict As Dictionary(Of String, String))
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_execute_tempstockcard2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 12)
            newCMD.Parameters.AddWithValue("@ws_no", dr_qty_using_wsno_dict("_ws_no"))
            newCMD.Parameters.AddWithValue("@rs_no", dr_qty_using_wsno_dict("_rs_no"))

            newDR = newCMD.ExecuteReader

            While newDR.Read
                If newDR.Item("qty").ToString = "" Then
                    dr_qty_using_wsno = 0
                Else
                    dr_qty_using_wsno = CDbl(newDR.Item("qty").ToString)
                End If

            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Public Sub get_balances()
        Try
            myBalanceNow = 0
            Dim result As Double

            For Each row In cListOfStockCard
                '8 - IN
                '9 - OUT

                If row.qty_in = 0 Then
                    Dim out As String

                    If IsNumeric(row.qty_out) Then
                        out = row.qty_out

                    Else

                        Dim sp() As String = row.qty_out.Split("/")

                        If CDbl(sp(0)) < CDbl(sp(1)) Then
                            out = (CDbl(sp(1)) - CDbl(sp(0)))
                        Else
                            out = 0
                        End If
                    End If

                    result = CDbl(CStr(result)) - CDbl(out)
                    'row.cells(10).value = FormatNumber(CDbl(CStr(Result)), 2,,, TriState.True)

                ElseIf CDbl(row.qty_in) > 0 Then
                    result = FormatNumber(result, 2,,, TriState.True) + CDbl(CStr(row.qty_in))
                    'row.cells(10).value = FormatNumber(CDbl(CStr(Result)), 2,,, TriState.True)
                End If
            Next

            myBalanceNow = result
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    'WAREHOUSE LOCATION
    Public Function warehouse_location(wh_id As Integer) As wh_loc

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        warehouse_location = New wh_loc

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_execute_tempstockcard2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 9)
            newCMD.Parameters.AddWithValue("@wh_id", wh_id)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                With warehouse_location
                    .item_name = newDR.Item("ITEM_NAME").ToString
                    .location = newDR.Item("LOCATION").ToString
                    .reoderpoint = newDR.Item("REORDER_POINT").ToString
                End With

            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

        Return warehouse_location
    End Function

    'GET DR DATA USING RRNO DATA
    Public Function get_rr_data(rr_no As String) As List(Of agg_rr_data)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        get_rr_data = New List(Of agg_rr_data)

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_execute_tempstockcard2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 20)
            newCMD.Parameters.AddWithValue("@rr_no", rr_no)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                Dim rr_data As New agg_rr_data

                With rr_data
                    .dr_date = Date.Parse(newDR.Item("dr_date").ToString)
                    .dr_no = newDR.Item("dr_no").ToString
                    .rr_no = newDR.Item("rr_no").ToString
                    .dr_qty = IIf(newDR.Item("qty").ToString = "", 0, newDR.Item("qty").ToString)
                    .dr_items_id = IIf(newDR.Item("dr_items_id").ToString = "", 0, newDR.Item("dr_items_id").ToString)

                    get_rr_data.Add(rr_data)
                End With
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function
    Public Class wh_loc
        Public Property item_name As String
        Public Property location As String
        Public Property reoderpoint As String
    End Class

    Public Class agg_data
        Public Property drdate As DateTime
        Public Property rs_no As String
        Public Property drno_invoice As String
        Public Property rr_no As String
        Public Property ws_no As String
        Public Property supp_recipient As String
        Public Property qty_in As String
        Public Property qty_out As String
        Public Property balance As Double
        Public Property remarks As String
        Public Property sorting As String
        Public Property type_of_purchasing As String
        Public Property inout As String
        Public Property type_of_delivery As String
        Public Property stat As String

    End Class

    Public Class agg_rr_data
        Public Property dr_items_id As Integer
        Public Property dr_no As String

        Public Property rr_no As String
        Public Property dr_qty As Double
        Public Property dr_date As DateTime

    End Class
End Class
