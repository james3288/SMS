Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class class_stock_card_for_hauling
    Private cWh_id As Integer
    Private cDateFrom As DateTime
    Private cDateTo As DateTime

    Public trd, trd2, trd3, trd4, trd5, trd6, trd7, trd8, trd9 As Threading.Thread
    Public _rs_no, _ws_no, _dr_no, _rs_no2, _ws_no2 As String
    Public _supplier_recepient As String
    Public _dr_qty_using_ws_no, _dr_qty_using_ws_no2 As Double
    Public prev_balance As Double
    Private sStockCardData As Boolean = False
    Private sStockCardQty As Boolean = False
    Public cItem_name As String
    Public cLocation As String
    Public cReorderPoint As String



    Structure sc

        Dim drdate As DateTime
        Dim rs_no As String
        Dim drno_invoice As String
        Dim rr_no As String
        Dim ws_no As String
        Dim supp_recipient As String
        Dim qty_in As String
        Dim qty_out As String
        Dim balance As Double
        Dim remarks As String
        Dim sorting As String

    End Structure

    Structure counted_dr
        Dim _dr_count As String
        Dim rs_id As Integer
    End Structure

    Structure prev_bal
        Dim qty_in As Double
        Dim qty_out As String
        Dim rs_no As String
        Dim ws_no As String
        Dim inout As String
        Dim dr_date As DateTime
        Dim sorting As String

    End Structure

    Public cListOfStockCard As New List(Of sc)
    Public cListOfDr_counted As New List(Of counted_dr)
    Public cListOfQty As New List(Of prev_bal)
    Public Sub _initialize(wh_id As Integer, datefrom As DateTime, dateto As DateTime)
        cListOfStockCard.Clear()

        cWh_id = wh_id
        cDateFrom = datefrom
        cDateTo = dateto

        trd = New Threading.Thread(AddressOf get_aggregates_data)
        trd.Start()

    End Sub

    Public Sub _initialize_qty(wh_id As Integer, datefrom As DateTime, dateto As DateTime)
        cListOfQty.Clear()

        trd4 = New Threading.Thread(AddressOf get_prev_balance)
        trd4.Start()

    End Sub

    Public Sub _initialize_prev_balance()
        prev_balance = 0
        trd6 = New Threading.Thread(AddressOf get_prev_item_balance)
        trd6.Start()

    End Sub

    Public Sub _initialize_try()
        trd7 = New Threading.Thread(AddressOf try_lng)
        trd7.Start()

    End Sub

    Public Sub _initialize_balance(wh_id As Integer, datefrom As DateTime, dateto As DateTime)
        cWh_id = wh_id
        cDateFrom = datefrom
        cDateTo = dateto

        trd9 = New Threading.Thread(AddressOf get_balance)
        trd9.Start()
        trd9.Join()

    End Sub

    Public Sub _initialize_warehouse_location()
        trd8 = New Threading.Thread(AddressOf warehouse_location)
        trd8.Start()

    End Sub
    Private Sub get_prev_balance()

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Dim newSc As New prev_bal
        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_execute_tempstockcard2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 11)
            newCMD.Parameters.AddWithValue("@wh_id", cWh_id)
            newCMD.Parameters.AddWithValue("@date_from", Date.Parse("2001-01-01"))
            newCMD.Parameters.AddWithValue("@date_to", cDateFrom.AddDays(-1))

            'warehouse_location(wh_id)

            newDR = newCMD.ExecuteReader

            Dim a(20) As String
            Dim rowcount As Integer = 0

            While newDR.Read

                With newSc
                    .rs_no = newDR.Item("rs_no").ToString
                    .ws_no = newDR.Item("WS_NO").ToString.ToUpper
                    .inout = newDR.Item("IN_OUT").ToString
                    .dr_date = Format(Date.Parse(newDR.Item("date").ToString), "MM/dd/yyyy")
                    .sorting = newDR.Item("SORTING").ToString

                    If newDR.Item("WITHDRAWN").ToString = "NO" Then
                        GoTo proceedhere
                    End If

                    If newDR.Item("stat").ToString = "" And newDR.Item("dr_no").ToString = "" Then
                        GoTo proceedhere
                    End If

                    If newDR.Item("IN_OUT").ToString = "OUT" Then
                        If newDR.Item("SORTING").ToString = "A" Then
                            .qty_in = 0

                            _rs_no2 = .rs_no
                            _ws_no2 = .ws_no

                            count_qty_dr_using_ws_no2()

                            Dim count_qty_dr As Double = _dr_qty_using_ws_no2
                            .qty_out = CDbl(newDR.Item("qty_OUT").ToString) - count_qty_dr

                            If count_qty_dr = 0 Then
                                .qty_out = CDbl(newDR.Item("qty_OUT").ToString)
                            Else
                                .qty_out = count_qty_dr & "/" & CDbl(newDR.Item("qty_OUT").ToString)
                            End If
                        Else
                            .qty_in = 0
                            .qty_out = newDR.Item("qty_OUT").ToString

                        End If

                    ElseIf newDR.Item("IN_OUT").ToString = "IN" Then

                        .qty_in = newDR.Item("qty_IN").ToString
                        .qty_out = 0

                    End If
                    cListOfQty.Add(newSc)
                End With
proceedhere:

            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
            sStockCardQty = True
        End Try
    End Sub

    Private Sub get_aggregates_data()

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Dim newSc As New sc
        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_execute_tempstockcard2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 11)
            newCMD.Parameters.AddWithValue("@wh_id", cWh_id)
            newCMD.Parameters.AddWithValue("@date_from", cDateFrom)
            newCMD.Parameters.AddWithValue("@date_to", cDateTo)

            'warehouse_location(wh_id)

            newDR = newCMD.ExecuteReader

            Dim a(20) As String
            Dim rowcount As Integer = 0

            While newDR.Read
                Dim ws_no As String = newDR.Item("WS_NO").ToString
                Dim rs_no As String = newDR.Item("rs_no").ToString

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
                    .rr_no = IIf(newDR.Item("RR_NO").ToString.ToUpper = "", "N/A", newDR.Item("RR_NO").ToString.ToUpper)
                    .sorting = newDR.Item("SORTING").ToString

                    If newDR.Item("IN_OUT").ToString = "OUT" Then
                        .supp_recipient = newDR.Item("SOURCE_WH").ToString

                        If newDR.Item("SORTING").ToString = "A" Then
                            .qty_in = 0

                            _rs_no = .rs_no
                            _ws_no = .ws_no

                            count_qty_dr_using_ws_no()

                            Dim count_qty_dr As Double = _dr_qty_using_ws_no
                            .qty_out = CDbl(newDR.Item("qty_OUT").ToString) - count_qty_dr

                            If count_qty_dr = 0 Then
                                .qty_out = CDbl(newDR.Item("qty_OUT").ToString)
                            Else
                                .qty_out = count_qty_dr & "/" & CDbl(newDR.Item("qty_OUT").ToString)
                            End If
                        Else
                            .qty_in = 0
                            .qty_out = newDR.Item("qty_OUT").ToString

                        End If

                    ElseIf newDR.Item("IN_OUT").ToString = "IN" Then
                        If newDR.Item("type_of_purchasing").ToString = "PURCHASE ORDER" Then
                            supplier_recepient()
                            .supp_recipient = _supplier_recepient
                        Else

                            .supp_recipient = newDR.Item("SOURCE_WH").ToString
                        End If

                        .qty_in = newDR.Item("qty_IN").ToString
                        .qty_out = 0

                    End If

                    .remarks = newDR.Item("remarks").ToString
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
            sStockCardData = True
        End Try
    End Sub

    Public Function count_qty_dr_using_ws_no() As Double
        trd2 = New Threading.Thread(AddressOf get_dr_qty_using_ws_no)
        trd2.Start()
        trd2.Join()
    End Function

    Public Function count_qty_dr_using_ws_no2() As Double
        trd5 = New Threading.Thread(AddressOf get_dr_qty_using_ws_no2)
        trd5.Start()
        trd5.Join()
    End Function

    Public Function supplier_recepient() As Double
        trd3 = New Threading.Thread(AddressOf get_supp_recepient)
        trd3.Start()
        trd3.Join()

    End Function

    Private Sub get_dr_qty_using_ws_no2()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_execute_tempstockcard2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 12)
            newCMD.Parameters.AddWithValue("@ws_no", _ws_no2)
            newCMD.Parameters.AddWithValue("@rs_no", _rs_no2)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                If newDR.Item("qty").ToString = "" Then
                    _dr_qty_using_ws_no2 = 0
                Else
                    _dr_qty_using_ws_no2 = CDbl(newDR.Item("qty").ToString)
                End If

            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Private Sub get_dr_qty_using_ws_no()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_execute_tempstockcard2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 12)
            newCMD.Parameters.AddWithValue("@ws_no", _ws_no)
            newCMD.Parameters.AddWithValue("@rs_no", _rs_no)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                If newDR.Item("qty").ToString = "" Then
                    _dr_qty_using_ws_no = 0
                Else
                    _dr_qty_using_ws_no = CDbl(newDR.Item("qty").ToString)
                End If

            End While

            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Private Sub get_supp_recepient()

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_execute_tempstockcard2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 19)
            newCMD.Parameters.AddWithValue("@dr_no", _dr_no)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                _supplier_recepient = newDR.Item("Supp_Rec").ToString
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub


    Public Function get_prev_item_balance(wh_id As Integer) As Double
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            Dim query As String = "SELECT a.balance FROM dbPrevious_stock_card a WHERE a.wh_id = " & cWh_id

            newCMD = New SqlCommand(query, newSQ.connection)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                prev_balance = newDR.Item("balance").ToString()
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function

    Public Sub try_lng()


        While True
            If Not trd4 Is Nothing Then
                If Not trd4.IsAlive Then
                    Exit While
                End If
            End If

        End While

        While True
            If Not trd Is Nothing Then
                If Not trd.IsAlive Then
                    Exit While
                End If
            End If
        End While

        'MsgBox("hello")


        sStockCardQty = False
        sStockCardData = False
    End Sub

    Public Sub thread_warehouse_location()
        While True
            If Not trd8 Is Nothing Then
                If Not trd8.IsAlive Then
                    Exit While
                End If
            End If

        End While

        While True
            If Not trd8 Is Nothing Then
                If Not trd8.IsAlive Then
                    Exit While
                End If
            End If
        End While



    End Sub

    Private Sub warehouse_location(wh_id As Integer)

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_execute_tempstockcard2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 9)
            newCMD.Parameters.AddWithValue("@wh_id", cWh_id)

            newDR = newCMD.ExecuteReader

            While newDR.Read

                cItem_name = newDR.Item("ITEM_NAME").ToString
                cLocation = newDR.Item("LOCATION").ToString
                cReorderPoint = newDR.Item("REORDER_POINT").ToString

            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub

    Private Sub get_balance()

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Dim newSc As New prev_bal
        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_execute_tempstockcard2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 11)
            newCMD.Parameters.AddWithValue("@wh_id", cWh_id)
            newCMD.Parameters.AddWithValue("@date_from", cDateFrom)
            newCMD.Parameters.AddWithValue("@date_to", cDateTo)

            'warehouse_location(wh_id)

            newDR = newCMD.ExecuteReader

            Dim a(20) As String
            Dim rowcount As Integer = 0

            While newDR.Read

                With newSc
                    .rs_no = newDR.Item("rs_no").ToString
                    .ws_no = newDR.Item("WS_NO").ToString.ToUpper
                    .inout = newDR.Item("IN_OUT").ToString
                    .dr_date = Format(Date.Parse(newDR.Item("date").ToString), "MM/dd/yyyy")
                    .sorting = newDR.Item("SORTING").ToString

                    If newDR.Item("WITHDRAWN").ToString = "NO" Then
                        GoTo proceedhere
                    End If

                    If newDR.Item("stat").ToString = "" And newDR.Item("dr_no").ToString = "" Then
                        GoTo proceedhere
                    End If

                    If newDR.Item("IN_OUT").ToString = "OUT" Then
                        If newDR.Item("SORTING").ToString = "A" Then
                            .qty_in = 0

                            _rs_no2 = .rs_no
                            _ws_no2 = .ws_no

                            count_qty_dr_using_ws_no2()

                            Dim count_qty_dr As Double = _dr_qty_using_ws_no2
                            .qty_out = CDbl(newDR.Item("qty_OUT").ToString) - count_qty_dr

                            If count_qty_dr = 0 Then
                                .qty_out = CDbl(newDR.Item("qty_OUT").ToString)
                            Else
                                .qty_out = count_qty_dr & "/" & CDbl(newDR.Item("qty_OUT").ToString)
                            End If
                        Else
                            .qty_in = 0
                            .qty_out = newDR.Item("qty_OUT").ToString

                        End If

                    ElseIf newDR.Item("IN_OUT").ToString = "IN" Then

                        .qty_in = newDR.Item("qty_IN").ToString
                        .qty_out = 0

                    End If
                    cListOfQty.Add(newSc)
                End With
proceedhere:

            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
            sStockCardQty = True
        End Try
    End Sub


End Class
