Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class class_aggregates_obj
    Public Class charges_object
        Private cCharges As String
        Private trd, trd2 As Threading.Thread
        Public done As Boolean
        Structure sCharges

            Dim charges As String
            Dim rs_id As Integer
            Dim rs_no As String
            Dim item_name As String
            Dim item_desc As String
            Dim TypeOfPurchasing As String
            Dim inout As String

        End Structure
        Public cListOfCharges As New List(Of sCharges)
        Public Sub _initialize(charges As String)
            cCharges = charges
            cListOfCharges.Clear()

            trd = New Threading.Thread(AddressOf get_charges)
            trd.Start()
            trd.Join()
            done = True
            'get_charges()
        End Sub

        Private Sub get_charges()
            Dim newSQ As New SQLcon
            Dim newCMD As SqlCommand
            Dim newDR As SqlDataReader

            Try
                newSQ.connection.Open()
                newCMD = New SqlCommand("proc_aggregates_general_request2", newSQ.connection)
                newCMD.Parameters.Clear()
                newCMD.CommandType = CommandType.StoredProcedure

                newCMD.Parameters.AddWithValue("@n", 9)
                newCMD.Parameters.AddWithValue("@charges", cCharges)
                newCMD.CommandTimeout = 200

                newDR = newCMD.ExecuteReader

                Dim charges1 As New sCharges

                While newDR.Read
                    With charges1
                        .charges = newDR.Item("charges").ToString
                        .rs_id = newDR.Item("rs_id").ToString
                        .rs_no = newDR.Item("rs_no").ToString
                        .item_name = newDR.Item("whItem").ToString
                        .item_desc = newDR.Item("whItemDesc").ToString
                        .TypeOfPurchasing = newDR.Item("type_of_purchasing").ToString
                        .inout = newDR.Item("IN_OUT").ToString

                        cListOfCharges.Add(charges1)
                    End With

                End While

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                newSQ.connection.Close()
            End Try
        End Sub

    End Class

    Public Class rs_object

        Private cRs_id As Integer
        Public cInout As String
        Public cTypeOfPurchasing As String
        Public cCharges As String

        Public trd, trd1 As Threading.Thread

        Structure rs
            Dim rs_id As Integer
            Dim rs_no As String
            Dim rs_qty As Double
            Dim inout As String
            Dim type_of_purchasing As String
            Dim wsObj As ws_object
            Dim drObj As dr_object
            Dim rrObj As rr_object
            Dim poObj As po_object
            Dim item As String
            Dim requestor As String
            Dim rs_date As DateTime

        End Structure

        Public cListOfRS As New List(Of rs)
        Public Sub _initialize(dict As Dictionary(Of String, Object))

            cListOfRS.Clear()
            Dim result As Object = Nothing
            cRs_id = IIf(dict.TryGetValue("rs_id", result) = True, CInt(result), 0)
            cInout = IIf(dict.TryGetValue("inout", result) = True, CStr(result), "")
            cCharges = IIf(dict.TryGetValue("charges", result) = True, CStr(result), "")
            cTypeOfPurchasing = IIf(dict.TryGetValue("type_of_purchasing", result) = True, CStr(result), "")

            'get rs data
            trd = New Threading.Thread(AddressOf get_rs)
            trd.Start()
            trd.Join()

        End Sub

        Private Sub get_rs()
            Dim newSQ As New SQLcon
            Dim newCMD As SqlCommand
            Dim newDR As SqlDataReader

            Try
                newSQ.connection.Open()
                newCMD = New SqlCommand("proc_aggregates_general_request2", newSQ.connection)
                newCMD.Parameters.Clear()
                newCMD.CommandType = CommandType.StoredProcedure

                newCMD.Parameters.AddWithValue("@n", 1)
                newCMD.Parameters.AddWithValue("@rs_id", cRs_id)
                newDR = newCMD.ExecuteReader

                Dim rs1 As New rs
                Dim listoftrd As New List(Of Threading.Thread)

                While newDR.Read

                    rs1.rs_id = newDR.Item("rs_id").ToString
                    rs1.rs_no = newDR.Item("rs_no").ToString
                    rs1.inout = newDR.Item("IN_OUT").ToString
                    rs1.rs_qty = newDR.Item("qty").ToString
                    rs1.type_of_purchasing = newDR.Item("type_of_purchasing").ToString
                    rs1.item = newDR.Item("item_name").ToString & " - " & newDR.Item("item_desc").ToString
                    rs1.requestor = cCharges
                    rs1.rs_date = IIf(IsDate(newDR.Item("date_request").ToString), newDR.Item("date_request").ToString, "1990-01-01")


                    Select Case newDR.Item("IN_OUT").ToString
                        Case "OUT"
                            Dim ws As New ws_object
                            Dim dr As New dr_object
                            Dim dict As New Dictionary(Of String, Object)

                            dict.Add("ws_no", "")
                            dict.Add("rs_id", cRs_id)
                            dict.Add("inout", newDR.Item("IN_OUT").ToString)
                            dict.Add("type_of_purchasing", newDR.Item("type_of_purchasing").ToString)

                            trd1 = New Threading.Thread(AddressOf ws._initialize)
                            trd1.Start(dict)
                            'trd1.Join()
                            listoftrd.Add(trd1)

                            rs1.wsObj = ws
                            cListOfRS.Add(rs1)

                        Case "OTHERS", "IN"
                            If newDR.Item("type_of_purchasing").ToString = "DR" Then
                                Dim dr As New dr_object
                                Dim dict As New Dictionary(Of String, Object)

                                dict.Add("rs_no", newDR.Item("rs_no").ToString)
                                dict.Add("ws_no", "")
                                dict.Add("rs_id", cRs_id)
                                dict.Add("inout", newDR.Item("IN_OUT").ToString)
                                dict.Add("type_of_purchasing", newDR.Item("type_of_purchasing").ToString)

                                trd1 = New Threading.Thread(AddressOf dr._initialize)
                                trd1.Start(dict)
                                'trd1.Join()
                                listoftrd.Add(trd1)

                                rs1.drObj = dr
                                cListOfRS.Add(rs1)
                                '.drObj = dr

                            ElseIf newDR.Item("type_of_purchasing").ToString = "CASH WITH RR" Then
                                Dim rr As New rr_object
                                Dim dict As New Dictionary(Of String, Object)

                                dict.Add("rr_no", "")
                                dict.Add("rs_id", cRs_id)
                                dict.Add("inout", newDR.Item("IN_OUT").ToString)
                                dict.Add("type_of_purchasing", newDR.Item("type_of_purchasing").ToString)

                                trd1 = New Threading.Thread(AddressOf rr._initialize)
                                trd1.Start(dict)
                                ' trd1.Join()
                                listoftrd.Add(trd1)

                                rs1.rrObj = rr
                                cListOfRS.Add(rs1)

                            ElseIf newDR.Item("type_of_purchasing").ToString = "PURCHASE ORDER" Then
                                Dim po As New po_object
                                Dim dict As New Dictionary(Of String, Object)

                                dict.Add("rs_id", cRs_id)
                                dict.Add("inout", newDR.Item("IN_OUT").ToString)
                                dict.Add("type_of_purchasing", newDR.Item("type_of_purchasing").ToString)

                                trd1 = New Threading.Thread(AddressOf po._initialize)
                                trd1.Start(dict)
                                'trd1.Join()
                                listoftrd.Add(trd1)

                                rs1.poObj = po
                                cListOfRS.Add(rs1)
                            End If
                    End Select
                End While

                For Each thread In listoftrd
                    thread.Join()
                Next


            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                newSQ.connection.Close()
            End Try
        End Sub
    End Class

    Public Class ws_object
        Private cRs_id As Integer
        Private trd, trd1, trd2 As Threading.Thread
        Private cInOut As String
        Private cTypeOfPurchasing As String
        Structure ws
            Dim ws_id As Integer
            Dim ws_qty As Double
            Dim ws_no As String
            Dim dr_option As String
            Dim ws_date As DateTime

            Dim drObj As dr_object
        End Structure

        Public cListOfWS As New List(Of ws)

        Public Sub _initialize(dict As Dictionary(Of String, Object))

            cListOfWS.Clear()

            Dim result As Object = Nothing
            cRs_id = IIf(dict.TryGetValue("rs_id", result) = True, CInt(result), 0)
            cInout = IIf(dict.TryGetValue("inout", result) = True, CStr(result), 0)
            cTypeOfPurchasing = IIf(dict.TryGetValue("type_of_purchasing", result) = True, CStr(result), 0)

            trd = New Threading.Thread(AddressOf get_ws)
            trd.Start()
            trd.Join()

        End Sub

        Private Sub get_ws()
            Dim newSQ As New SQLcon
            Dim newCMD As SqlCommand
            Dim newDR As SqlDataReader

            Try
                newSQ.connection.Open()
                newCMD = New SqlCommand("proc_aggregates_general_request2", newSQ.connection)
                newCMD.Parameters.Clear()
                newCMD.CommandType = CommandType.StoredProcedure

                newCMD.Parameters.AddWithValue("@n", 2)
                newCMD.Parameters.AddWithValue("@rs_id", cRs_id)
                newCMD.Parameters.AddWithValue("@inout", cInOut)
                newDR = newCMD.ExecuteReader

                Dim ws1 As New ws

                While newDR.Read
                    With ws1
                        .ws_id = newDR.Item("ws_id").ToString
                        .ws_no = newDR.Item("ws_no").ToString
                        .ws_qty = newDR.Item("ws_qty").ToString
                        .dr_option = newDR.Item("dr_option").ToString
                        .ws_date = IIf(IsDate(newDR.Item("ws_date").ToString), newDR.Item("ws_date").ToString, "1990-01-01")

                        Dim dr As New dr_object

                        Dim dict As New Dictionary(Of String, Object)

                        dict.Add("ws_no", .ws_no)
                        dict.Add("rs_id", cRs_id)
                        dict.Add("inout", "OUT")
                        dict.Add("type_of_purchasing", "")

                        trd2 = New Threading.Thread(AddressOf dr._initialize)
                        trd2.Start(dict)

                        .drObj = dr
                    End With

                    cListOfWS.Add(ws1)
                End While

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                newSQ.connection.Close()
            End Try
        End Sub
    End Class

    Public Class dr_object
        Private cWsNo As String
        Private cRs_id As Integer
        Private cInOut As String
        Private cTypeOfPurchasing As String
        Private cRr_item_id As Integer
        Private cRr_no As String
        Private cRs_No As String

        Structure dr
            Dim dr_items_id As Integer
            Dim dr_no As String
            Dim dr_qty As Double
            Dim ws_no As String
            Dim rs_id As Integer
            Dim inout As String
            Dim rs_no As String
            Dim dr_date As DateTime

        End Structure

        Private trd As Threading.Thread

        Public cListOfDr As New List(Of dr)
        Public Sub _initialize(dict As Dictionary(Of String, Object))
            cListOfDr.Clear()

            Dim result As Object = Nothing

            cWsNo = IIf(dict.TryGetValue("ws_no", result) = True, CStr(result), "")
            cRs_id = IIf(dict.TryGetValue("rs_id", result) = True, CInt(result), 0)
            cInOut = IIf(dict.TryGetValue("inout", result) = True, CStr(result), "")
            cTypeOfPurchasing = IIf(dict.TryGetValue("type_of_purchasing", result) = True, CStr(result), "")
            cRr_item_id = IIf(dict.TryGetValue("rr_item_id", result) = True, CInt(result), 0)
            cRr_no = IIf(dict.TryGetValue("rr_no", result) = True, CStr(result), "")
            cRs_No = IIf(dict.TryGetValue("rs_no", result) = True, CStr(result), "")

            trd = New Threading.Thread(AddressOf get_dr)
            trd.Start()
            trd.Join()

        End Sub

        Private Sub get_dr()
            Dim newSQ As New SQLcon
            Dim newCMD As SqlCommand
            Dim newDR As SqlDataReader

            Try
                newSQ.connection.Open()
                newCMD = New SqlCommand("proc_aggregates_general_request2", newSQ.connection)
                newCMD.Parameters.Clear()
                newCMD.CommandType = CommandType.StoredProcedure

                With newCMD.Parameters
                    Select Case cInOut
                        Case "OUT"
                            .AddWithValue("@n", 3)
                            .AddWithValue("@ws_no", cWsNo)
                            .AddWithValue("@rs_id", cRs_id)

                        Case "OTHERS", "IN"
                            If cTypeOfPurchasing = "DR" Then

                                .AddWithValue("@n", 4)
                                .AddWithValue("@rs_id", cRs_id)

                            ElseIf cTypeOfPurchasing = "CASH WITH RR" Or cTypeOfPurchasing = "PURCHASE ORDER" Then

                                .AddWithValue("@n", 6)
                                .AddWithValue("@rr_item_id", cRr_item_id)
                                .AddWithValue("@rr_no", cRr_no)
                                .AddWithValue("@rs_id", cRs_id)

                            End If

                    End Select
                End With

                newDR = newCMD.ExecuteReader

                Dim dr1 As New dr

                While newDR.Read
                    With dr1

                        .dr_items_id = newDR.Item("dr_items_id").ToString
                        .dr_no = newDR.Item("dr_no").ToString
                        .dr_qty = newDR.Item("dr_qty").ToString
                        .ws_no = newDR.Item("ws_no").ToString
                        .rs_id = newDR.Item("rs_id").ToString
                        .inout = newDR.Item("IN_OUT").ToString
                        .rs_no = cRs_No
                        .dr_date = IIf(IsDate(newDR.Item("dr_date").ToString), newDR.Item("dr_date").ToString, "1990-01-01")

                    End With

                    cListOfDr.Add(dr1)
                End While

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                newSQ.connection.Close()
            End Try
        End Sub
    End Class

    Public Class rr_object

        Private cRRNo As String
        Private cRs_id As Integer
        Private cInOut As String
        Private cTypeOfPurchasing As String
        Private cPo_det_id As Integer

        Private trd As Threading.Thread
        Structure rr
            Dim rr_item_id As Integer
            Dim rr_no As String
            Dim rr_qty As Double
            Dim drObj As dr_object
            Dim rr_date As DateTime

        End Structure

        Public cListOfRR As New List(Of rr)
        Public Sub _initialize(dict As Dictionary(Of String, Object))
            cListOfRR.Clear()

            Dim result As Object = Nothing

            cRRNo = IIf(dict.TryGetValue("rr_no", result) = True, CStr(result), "")
            cRs_id = IIf(dict.TryGetValue("rs_id", result) = True, CInt(result), 0)
            cInOut = IIf(dict.TryGetValue("inout", result) = True, CStr(result), "")
            cTypeOfPurchasing = IIf(dict.TryGetValue("type_of_purchasing", result) = True, CStr(result), "")
            cPo_det_id = IIf(dict.TryGetValue("po_det_id", result) = True, CInt(result), 0)

            trd = New Threading.Thread(AddressOf get_rr)
            trd.Start()
            trd.Join()

        End Sub

        Private Sub get_rr()
            Dim newSQ As New SQLcon
            Dim newCMD As SqlCommand
            Dim newDR As SqlDataReader

            Try
                newSQ.connection.Open()
                newCMD = New SqlCommand("proc_aggregates_general_request2", newSQ.connection)
                newCMD.Parameters.Clear()
                newCMD.CommandType = CommandType.StoredProcedure

                Select Case cInOut
                    Case "IN", "OTHERS"
                        If cTypeOfPurchasing = "CASH WITH RR" Then
                            newCMD.Parameters.AddWithValue("@n", 5)
                            newCMD.Parameters.AddWithValue("@rs_id", cRs_id)

                        ElseIf cTypeOfPurchasing = "PURCHASE ORDER" Then
                            newCMD.Parameters.AddWithValue("@n", 8)
                            newCMD.Parameters.AddWithValue("@po_det_id", cPo_det_id)
                        End If
                End Select

                newDR = newCMD.ExecuteReader

                Dim rr1 As New rr

                While newDR.Read
                    With rr1
                        .rr_item_id = newDR.Item("rr_item_id").ToString
                        .rr_qty = newDR.Item("desired_qty").ToString
                        .rr_no = newDR.Item("rr_no").ToString
                        .rr_date = IIf(IsDate(newDR.Item("date_received").ToString), newDR.Item("date_received").ToString, "1990-01-01")

                        Dim dr As New dr_object

                        Dim dict As New Dictionary(Of String, Object)

                        dict.Add("rr_no", .rr_no)
                        dict.Add("rr_item_id", .rr_item_id)
                        dict.Add("inout", cInOut)
                        dict.Add("rs_id", cRs_id)
                        dict.Add("type_of_purchasing", cTypeOfPurchasing)

                        trd = New Threading.Thread(AddressOf dr._initialize)
                        trd.Start(dict)
                        trd.Join()

                        .drObj = dr
                    End With

                    cListOfRR.Add(rr1)
                End While

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                newSQ.connection.Close()
            End Try
        End Sub
    End Class

    Public Class po_object
        Private cRs_id As Integer
        Private trd, trd1, trd2 As Threading.Thread
        Private cInOut As String
        Private cTypeOfPurchasing As String
        Structure po
            Dim po_det_id As Integer
            Dim po_qty As Double
            Dim po_no As String
            Dim dr_option As String
            Dim rrObj As rr_object
            Dim inout As String
            Dim po_date As DateTime

        End Structure

        Public cListOfPo As New List(Of po)

        Public Sub _initialize(dict As Dictionary(Of String, Object))

            cListOfPo.Clear()

            Dim result As Object = Nothing
            cRs_id = IIf(dict.TryGetValue("rs_id", result) = True, CInt(result), 0)
            cInOut = IIf(dict.TryGetValue("inout", result) = True, CStr(result), 0)
            cTypeOfPurchasing = IIf(dict.TryGetValue("type_of_purchasing", result) = True, CStr(result), 0)

            trd = New Threading.Thread(AddressOf get_po)
            trd.Start()
            trd.Join()

        End Sub

        Private Sub get_po()
            Dim newSQ As New SQLcon
            Dim newCMD As SqlCommand
            Dim newDR As SqlDataReader

            Try
                newSQ.connection.Open()
                newCMD = New SqlCommand("proc_aggregates_general_request2", newSQ.connection)
                newCMD.Parameters.Clear()
                newCMD.CommandType = CommandType.StoredProcedure

                newCMD.Parameters.AddWithValue("@n", 7)
                newCMD.Parameters.AddWithValue("@rs_id", cRs_id)
                newCMD.Parameters.AddWithValue("@inout", cInOut)
                newDR = newCMD.ExecuteReader

                Dim po1 As New po

                While newDR.Read
                    With po1
                        .po_det_id = newDR.Item("po_det_id").ToString
                        .po_no = newDR.Item("po_no").ToString
                        .po_qty = newDR.Item("po_qty").ToString
                        .inout = cInOut
                        .po_date = IIf(IsDate(newDR.Item("po_date").ToString), newDR.Item("po_date").ToString, "1990-01-01")

                        Dim rr As New rr_object

                        Dim dict As New Dictionary(Of String, Object)

                        dict.Add("po_det_id", .po_det_id)
                        dict.Add("rs_id", cRs_id)
                        dict.Add("inout", cInOut)
                        dict.Add("type_of_purchasing", cTypeOfPurchasing)

                        trd2 = New Threading.Thread(AddressOf rr._initialize)
                        trd2.Start(dict)
                        trd2.Join()

                        .rrObj = rr
                    End With

                    cListOfPo.Add(po1)
                End While

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                newSQ.connection.Close()
            End Try
        End Sub
    End Class

    Public Class main_rs_object
        Private cRequestor As String
        Private trd As Threading.Thread
        Public done As Boolean
        Structure main_rs
            Dim charges As String
            Dim rs_no As String
            Dim main_qty As Double

        End Structure

        Public cListOfMainQty As New List(Of main_rs)
        Public Sub _initialize(requestor As String)
            cRequestor = requestor
            trd = New Threading.Thread(AddressOf get_main_rs)
            trd.Start()
            trd.Join()

            done = True

        End Sub

        Private Sub get_main_rs()
            Dim newSQ As New SQLcon
            Dim newCMD As SqlCommand
            Dim newDR As SqlDataReader
            Try
                newSQ.connection.Open()
                newCMD = New SqlCommand("proc_aggregates_general_request2", newSQ.connection)
                newCMD.Parameters.Clear()
                newCMD.CommandType = CommandType.StoredProcedure

                newCMD.Parameters.AddWithValue("@n", 10)
                newCMD.Parameters.AddWithValue("@charges", cRequestor)
                newDR = newCMD.ExecuteReader

                Dim newMainRS As New main_rs

                While newDR.Read
                    With newMainRS
                        .charges = newDR.Item("charges").ToString
                        .rs_no = newDR.Item("rs_no").ToString
                        .main_qty = IIf(IsNumeric(newDR.Item("main_rs_qty").ToString), newDR.Item("main_rs_qty").ToString, 0)

                        cListOfMainQty.Add(newMainRS)
                    End With
                End While

            Catch ex As Exception
                MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                newSQ.connection.Close()
            End Try
        End Sub
    End Class

    Public Class _AGGREGATES_
        Private cRs_id As Integer
        Private cInout As String
        Private cTypeOfPurchasing As String
        Private AggObj As Object
        Private cRsObj As rs_object

        Private cTotal_Withdrawal As Double
        Private cTotal_PO As Double
        Private cTotal_RR As Double
        Private cTotal_DR As Double

        Private ccRSNo As String
        Private ccRSQty As Double
        Private ccInout As String

        Private trd, trd2, trd3 As Threading.Thread
        Structure stockpile
            Dim rs_no As String
            Dim po_no As String
            Dim rr_no As String
            Dim ws_no As String
            Dim dr_no As String
            Dim qty As Double
            Dim sorting As String
            Dim inout As String
            Dim type_of_purchasing As String
            Dim total As Double
            Dim remaining As Double
            Dim items As String
            Dim requestor As String
            Dim rs_date As DateTime

        End Structure

        Structure agg_rem_balance
            Dim rs_no As String
            Dim rs_qty As Double
            Dim ws_po_qty As Double
            Dim rr_qty As Double
            Dim dr_qty As Double
            Dim balance As Double
            Dim items As String
            Dim requestor As String
            Dim inout As String
            Dim type_of_purchasing As String


        End Structure

        Public cListOfAggregates As New List(Of stockpile)
        Public cListOfRemainingBalance As New List(Of agg_rem_balance)
        Public Sub _initialize(rs As rs_object)
            cRsObj = rs

            trd = New Threading.Thread(AddressOf get_aggregates_rs)
            trd.Start()
            trd.Join()

            'get_aggregates_rs()
        End Sub

        Private Sub get_aggregates_rs()
            Dim ListRs = cRsObj.cListOfRS
            Dim newSp As New stockpile
            Dim newArB As New agg_rem_balance


            For Each row In ListRs
                With newSp
                    .rs_no = row.rs_no
                    .qty = row.rs_qty
                    .inout = row.inout
                    .type_of_purchasing = row.type_of_purchasing
                    .sorting = "A"
                    .items = row.item
                    .requestor = row.requestor
                    .rs_date = row.rs_date

                    cListOfAggregates.Add(newSp)

                End With

                Select Case row.inout
                    Case "OUT"
                        trd2 = New Threading.Thread(AddressOf _withdrawal)
                        trd2.Start(row.wsObj)
                        trd2.Join()

                        Dim newsp1 As New stockpile
                        With newsp1
                            .inout = row.rs_qty & " - " & CDbl(cTotal_Withdrawal)
                            .sorting = "G"
                            .remaining = CDbl(row.rs_qty) - FormatNumber(CDbl(cTotal_Withdrawal), 2,,, TriState.False)


                            If .remaining > 0 Then
                                With newArB
                                    .rs_no = row.rs_no
                                    .rs_qty = row.rs_qty
                                    .ws_po_qty = cTotal_Withdrawal
                                    .balance = CDbl(row.rs_qty) - FormatNumber(CDbl(cTotal_Withdrawal), 2,,, TriState.False)
                                    .inout = row.inout
                                    .type_of_purchasing = row.type_of_purchasing
                                    .items = row.item
                                    .requestor = row.requestor
                                End With

                                cListOfRemainingBalance.Add(newArB)
                            End If
                        End With

                        cListOfAggregates.Add(newsp1)


                    Case "IN", "OTHERS"

                        If row.type_of_purchasing = "DR" Then

                            ccRSQty = row.rs_qty
                            ccRSNo = rs_no
                            ccInout = row.inout

                            trd2 = New Threading.Thread(AddressOf _delivery)
                            trd2.Start(row.drObj)
                            trd2.Join()

                            Dim newsp1 As New stockpile
                            With newsp1
                                .inout = row.rs_qty & " - " & cTotal_DR
                                .sorting = "EE"
                                .remaining = CDbl(row.rs_qty) - CDbl(cTotal_DR)

                                If .remaining > 0 Then
                                    With newArB
                                        .rs_no = row.rs_no
                                        .rs_qty = row.rs_qty
                                        .dr_qty = cTotal_DR
                                        .balance = CDbl(row.rs_qty) - CDbl(cTotal_DR)
                                        .inout = row.inout
                                        .type_of_purchasing = row.type_of_purchasing
                                        .items = row.item
                                        .requestor = row.requestor
                                    End With

                                    cListOfRemainingBalance.Add(newArB)
                                End If
                            End With

                            cListOfAggregates.Add(newsp1)

                        ElseIf row.type_of_purchasing = "CASH WITH RR" Then
                            trd2 = New Threading.Thread(AddressOf _receiving)
                            trd2.Start(row.rrObj)
                            trd2.Join()


                            Dim newsp1 As New stockpile
                            With newsp1
                                .inout = row.rs_qty & " - " & cTotal_RR
                                .sorting = "G"
                                .remaining = CDbl(row.rs_qty) - CDbl(cTotal_RR)

                                If .remaining > 0 Then
                                    With newArB
                                        .rs_no = row.rs_no
                                        .rs_qty = row.rs_qty
                                        .rr_qty = cTotal_RR
                                        .balance = CDbl(row.rs_qty) - CDbl(cTotal_RR)
                                        .inout = row.inout
                                        .type_of_purchasing = row.type_of_purchasing
                                        .items = row.item
                                        .requestor = row.requestor
                                    End With

                                    cListOfRemainingBalance.Add(newArB)
                                End If
                            End With

                            cListOfAggregates.Add(newsp1)

                        ElseIf row.type_of_purchasing = "PURCHASE ORDER" Then
                            trd2 = New Threading.Thread(AddressOf _Purchase_Order)
                            trd2.Start(row.poObj)
                            trd2.Join()


                            Dim newsp1 As New stockpile
                            With newsp1
                                .inout = cTotal_PO & " - " & cTotal_RR
                                .sorting = "F"
                                .remaining = CDbl(cTotal_PO) - CDbl(cTotal_RR)
                                .items = row.item
                            End With

                            cListOfAggregates.Add(newsp1)

                            Dim newsp2 As New stockpile
                            With newsp2
                                .inout = row.rs_qty & " - " & cTotal_PO
                                .sorting = "H"
                                .remaining = CDbl(row.rs_qty) - CDbl(cTotal_PO)

                                If .remaining > 0 Then
                                    With newArB
                                        .rs_no = row.rs_no
                                        .rs_qty = row.rs_qty
                                        .ws_po_qty = cTotal_PO
                                        .rr_qty = cTotal_RR
                                        .dr_qty = cTotal_DR
                                        .inout = row.inout
                                        .type_of_purchasing = row.type_of_purchasing
                                        .items = row.item
                                        .requestor = row.requestor
                                    End With
                                    cListOfRemainingBalance.Add(newArB)
                                End If
                            End With

                            cListOfAggregates.Add(newsp2)

                        End If
                End Select

            Next
        End Sub

        Private Sub _withdrawal(wsObj As ws_object)
            Dim listWs = wsObj.cListOfWS
            Dim newSp As New stockpile

            For Each row In listWs
                With newSp
                    .ws_no = row.ws_no
                    .qty = row.ws_qty
                    .inout = "OUT"
                    .type_of_purchasing = "WITHDRAWAL"
                    .sorting = "B"
                    .items = "-"
                    .rs_date = row.ws_date

                    cListOfAggregates.Add(newSp)

                    If row.dr_option = "WITH DR" Then

                        ccRSQty = row.ws_qty
                        ccRSNo = rs_no
                        ccInout = .inout

                        trd2 = New Threading.Thread(AddressOf _delivery)
                        trd2.Start(row.drObj)
                        trd2.Join()

                        '_delivery(row.drObj, row.ws_qty, .inout)
                    End If

                    cTotal_Withdrawal += row.ws_qty

                End With
            Next
        End Sub

        Private Sub _delivery(drObj As dr_object) ', mother_qty As Double, Optional mother_inout As String = "", Optional rs_no As String = "")
            Dim listDR = drObj.cListOfDr
            Dim newSP As New stockpile
            Dim total As Double
            Dim dRs_no As String

            For Each row In listDR
                With newSP

                    .dr_no = row.dr_no
                    .qty = row.dr_qty
                    .sorting = "D"
                    .inout = row.inout
                    .items = "-"
                    .rs_date = row.dr_date

                    cListOfAggregates.Add(newSP)
                    dRs_no = row.rs_no

                    If ccInout = "OUT" Then
                        If .inout = "OUT" Then
                            total += CDbl(row.dr_qty)
                        End If
                    Else
                        total += CDbl(row.dr_qty)
                    End If

                End With
            Next

            Dim newSP1 As New stockpile
            newSP1.rs_no = dRs_no
            newSP1.inout = ccRSQty & " - " & total
            newSP1.total = ccRSQty - total
            newSP1.sorting = "E"

            cListOfAggregates.Add(newSP1)
            cTotal_DR += total

        End Sub

        Private Sub _receiving(rrObject As rr_object)
            Dim listRR = rrObject.cListOfRR

            Dim newSP As New stockpile

            For Each row In listRR
                With newSP
                    .rr_no = row.rr_no
                    .qty = row.rr_qty
                    .sorting = "C"
                    .items = "-"
                    .rs_date = row.rr_date

                    cListOfAggregates.Add(newSP)

                    ccRSQty = row.rr_qty
                    ccRSNo = ""
                    ccInout = ""

                    trd2 = New Threading.Thread(AddressOf _delivery)
                    trd2.Start(row.drObj)
                    trd2.Join()

                    '_delivery(row.drObj, row.rr_qty)
                    cTotal_RR += row.rr_qty
                End With

            Next

        End Sub

        Private Sub _Purchase_Order(poObject As po_object)
            Dim listPO = poObject.cListOfPo

            Dim newSP As New stockpile

            For Each row In listPO
                With newSP
                    .po_no = row.po_no
                    .qty = row.po_qty
                    .sorting = "B"
                    .inout = row.inout
                    .items = "-"
                    .rs_date = row.po_date

                    cListOfAggregates.Add(newSP)
                    cTotal_PO += row.po_qty

                    trd3 = New Threading.Thread(AddressOf _receiving)
                    trd3.Start(row.rrObj)
                    trd3.Join()

                    '_receiving(row.rrObj)
                End With
            Next

        End Sub
    End Class
End Class



