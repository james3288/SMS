Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class class_new_dr
    Private cDateFrom As DateTime
    Private cDateTo As DateTime
    Private cSearchBy As String
    Private cSearch As String
    Private cDateRange As Boolean = False
    Private cWh_id As Integer

    Public trd, trd2, trd3, trd4 As Threading.Thread
    Public stat As String
    Private trd5 As Threading.Thread
    Public cListOfDrWithourRs_Dr As New List(Of dr)

    Private NOTAPPLICABLE As String = "N/A"
    Structure dr

        Dim dr_date As DateTime
        Dim dr_item_id As Integer
        Dim rs_no As String
        Dim requestor As String
        Dim rs_date As DateTime
        Dim dr_no As String
        Dim plateno As String
        Dim driver As String
        Dim ws_no As String
        Dim rr_no As String
        Dim item_name As String
        Dim item_desc As String
        Dim unit As String
        Dim dr_source As String
        Dim concession_ticket As String
        Dim dr_qty As Double
        Dim price As Double
        Dim total_amount As Double
        Dim supplier As String
        Dim checked_by As String
        Dim received_by As String
        Dim approved_by As String
        Dim withdrawn_by As String
        Dim remarks As String
        Dim input_user As String
        Dim inout As String
        Dim rs_id As Integer
        Dim po_no As String
        Dim po_det_id As Integer
        Dim dr_option As String
        Dim date_reported As DateTime
        Dim requestor_category As String
        Dim wh_id As Integer
        Dim source2 As String
        Dim date_submitted As DateTime
        Dim requestor_without_rs As String


    End Structure

    Structure reported_list

        Dim reported_dr_id As Integer
        Dim dr_item_id As Integer
        Dim dr_option As String
        Dim date_reported As DateTime
        Dim date_served As DateTime
        Dim reported_by As String
        Dim reported_user As String

    End Structure

    Structure dr_qty
        Dim dr_date As DateTime
        Dim dr_qty As Double
        Dim inout As String

    End Structure
    Public cListOfDr As New List(Of dr)
    Public cListOfDriver As New List(Of String)
    Public cListOfReportedDR As New List(Of reported_list)
    Public cListOfdrqty As New List(Of dr_qty)
    Public cPrev_dr_qty As Double

    'GET DR DATA WITHOUT RS AND DR
    Public Sub dr_data_without_rs_dr(datefrom As DateTime, dateto As DateTime)
        cDateFrom = datefrom
        cDateTo = dateto

        trd5 = New Threading.Thread(AddressOf get_dr_data_without_rs_dr)
        trd5.Start()
        trd5.Join()

    End Sub

    Private Sub get_dr_data_without_rs_dr()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR1 As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_dr_list3", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 12)
            newCMD.Parameters.AddWithValue("@datefrom", cDateFrom)
            newCMD.Parameters.AddWithValue("@dateto", cDateTo)

            newDR1 = newCMD.ExecuteReader

            While newDR1.Read
                Dim abcd As New dr
                With abcd
                    .dr_item_id = newDR1.Item("dr_items_id").ToString
                    .rs_no = newDR1.Item("rs_no").ToString
                    .requestor = newDR1.Item("requestor").ToString
                    .dr_date = newDR1.Item("dr_date").ToString
                    .rs_date = newDR1.Item("rs_date").ToString
                    .dr_no = newDR1.Item("dr_no").ToString
                    .plateno = newDR1.Item("plateno").ToString
                    .driver = newDR1.Item("driver").ToString
                    .ws_no = "N/A"
                    .rr_no = "N/A"
                    .item_name = newDR1.Item("item_name").ToString
                    .item_desc = newDR1.Item("item_desc").ToString
                    .unit = newDR1.Item("unit").ToString
                    .dr_source = newDR1.Item("dr_source").ToString
                    .withdrawn_by = "-"
                    .concession_ticket = newDR1.Item("concession_ticket_no").ToString
                    .dr_qty = newDR1.Item("qty").ToString
                    .price = IIf(newDR1.Item("price").ToString = "", 0, newDR1.Item("price").ToString)
                    .supplier = newDR1.Item("supplier").ToString
                    .checked_by = newDR1.Item("checkedBy").ToString
                    .received_by = newDR1.Item("receivedby").ToString
                    .remarks = newDR1.Item("remarks").ToString
                    .input_user = newDR1.Item("users").ToString
                    .inout = newDR1.Item("IN_OUT").ToString
                    .dr_option = newDR1.Item("options").ToString
                    .requestor_category = newDR1.Item("type_of_request").ToString
                    .total_amount = .price * .dr_qty
                    .wh_id = newDR1.Item("wh_id").ToString
                    .rs_id = newDR1.Item("rs_id").ToString


                    If newDR1.Item("date_submitted").ToString = "" Then
                        .date_submitted = Date.Parse("1990-01-01").ToString
                    Else
                        .date_submitted = newDR1.Item("date_submitted").ToString
                    End If



                    cListOfDrWithourRs_Dr.Add(abcd)
                End With

            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub


    Public Sub _initialize(datefrom As DateTime, dateto As DateTime, searchby As String, Optional search As String = "", Optional daterange As Boolean = False, Optional wh_id As Integer = 0)
        cDateFrom = datefrom
        cDateTo = dateto
        cSearchBy = searchby
        cSearch = search
        cDateRange = daterange
        cWh_id = wh_id

        trd = New Threading.Thread(AddressOf get_dr)
        trd.Name = "tr_get_dr"
        trd.Start()

        trd2 = New Threading.Thread(AddressOf get_reported_dr)
        trd2.Name = "tr_get_reported_dr"
        trd2.Start()

    End Sub

    Public Sub _initialize_previous_balance(datefrom As DateTime, dateto As DateTime, searchby As String, Optional search As String = "", Optional daterange As Boolean = False, Optional wh_id As Integer = 0)
        cDateFrom = datefrom
        cDateTo = dateto
        cSearchBy = searchby
        cSearch = search
        cDateRange = daterange
        cWh_id = wh_id

        cPrev_dr_qty = 0
        cListOfdrqty.Clear()

        trd4 = New Threading.Thread(AddressOf get_prev_balance)
        trd4.Start()

    End Sub

    Private Sub get_dr()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Dim newD As New dr
        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_dr_list2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.CommandTimeout = 300

            If cSearchBy = "DATE RANGE" Then
                newCMD.Parameters.AddWithValue("@n", 3)
                newCMD.Parameters.AddWithValue("@date_from", cDateFrom)
                newCMD.Parameters.AddWithValue("@date_to", cDateTo)
            ElseIf cSearchBy = "WH_ID" Then
                newCMD.Parameters.AddWithValue("@n", 52)
                newCMD.Parameters.AddWithValue("@wh_id", cWh_id)
                newCMD.Parameters.AddWithValue("@date_from", cDateFrom)
                newCMD.Parameters.AddWithValue("@date_to", cDateTo)

            ElseIf cSearchBy = "IN/OUT" Then
                newCMD.Parameters.AddWithValue("@n", 54)
                newCMD.Parameters.AddWithValue("@search", cSearch)
                newCMD.Parameters.AddWithValue("@date_from", cDateFrom)
                newCMD.Parameters.AddWithValue("@date_to", cDateTo)

            Else
                Dim n As Integer = IIf(cDateRange = False, 5555, 51) '5
                newCMD.Parameters.AddWithValue("@n", n)
                newCMD.Parameters.AddWithValue("@date_from", cDateFrom)
                newCMD.Parameters.AddWithValue("@date_to", cDateTo)

                newCMD.Parameters.AddWithValue("@searchby", cSearchBy)
                newCMD.Parameters.AddWithValue("@search", cSearch)
            End If

            newDR = newCMD.ExecuteReader

            While newDR.Read

                newD.dr_item_id = newDR.Item("dr_items_id").ToString
                newD.rs_no = newDR.Item("rs_no").ToString
                newD.requestor = newDR.Item("requestor").ToString
                newD.dr_date = IIf(newDR.Item("dr_date").ToString = "", Date.Parse("1990-01-01"), newDR.Item("dr_date").ToString)
                newD.rs_date = IIf(newDR.Item("rs_date").ToString = "", Date.Parse("1990-01-01"), newDR.Item("rs_date").ToString)
                newD.dr_no = newDR.Item("dr_no").ToString
                newD.plateno = newDR.Item("plate_no").ToString
                newD.driver = newDR.Item("operator").ToString
                newD.inout = newDR.Item("IN_OUT").ToString

                '11/14/24 - issue:
                'ws: make a condition to filter WS_NO
                Select Case newD.inout.ToUpper()
                    Case "IN", "OTHERS"
                        newD.ws_no = NOTAPPLICABLE
                    Case "OUT"
                        If newD.rs_no.ToUpper = NOTAPPLICABLE Then
                            newD.ws_no = NOTAPPLICABLE
                        Else
                            newD.ws_no = newDR.Item("ws_no").ToString
                        End If
                End Select


                newD.rr_no = newDR.Item("rr_no").ToString
                newD.item_name = newDR.Item("item_name").ToString
                newD.item_desc = newDR.Item("item_desc").ToString
                newD.unit = newDR.Item("unit").ToString
                newD.dr_source = newDR.Item("dr_source").ToString
                newD.concession_ticket = newDR.Item("concession_ticket_no").ToString
                newD.dr_qty = newDR.Item("qty").ToString
                newD.price = IIf(IsNumeric(newDR.Item("price").ToString), newDR.Item("price").ToString, 0)
                newD.total_amount = IIf(IsNumeric(newDR.Item("total_amount").ToString), newDR.Item("total_amount").ToString, 0)
                newD.supplier = newDR.Item("supplier").ToString
                newD.checked_by = newDR.Item("check_by").ToString.ToUpper
                newD.received_by = newDR.Item("received_by").ToString.ToUpper
                newD.remarks = newDR.Item("remarks").ToString
                newD.input_user = newDR.Item("users").ToString
                newD.rs_id = newDR.Item("rs_id").ToString
                newD.po_no = newDR.Item("po_no").ToString
                newD.dr_option = "WITH DR"
                newD.source2 = newDR.Item("source").ToString
                newD.date_submitted = IIf(IsDate(newDR.Item("date_submitted").ToString), newDR.Item("date_submitted").ToString, Date.Parse("1990-01-01"))
                stat = newDR.Item("rs_no").ToString
                newD.wh_id = IIf(newDR.Item("wh_id").ToString = "", 0, newDR.Item("wh_id").ToString)
                newD.requestor_without_rs = newDR.Item("wh_area").ToString

                cListOfDr.Add(newD)

                Module_public_var.pub_stat = newD.plateno

            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Private Sub get_prev_balance()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Dim newD_qty As New dr_qty
        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_dr_list2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.CommandTimeout = 300

            newCMD.Parameters.AddWithValue("@n", 53)
            newCMD.Parameters.AddWithValue("@date_from", cDateFrom)
            newCMD.Parameters.AddWithValue("@date_to", cDateTo)
            newCMD.Parameters.AddWithValue("@wh_id", cWh_id)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                With newD_qty
                    .dr_date = newDR.Item("dr_date").ToString
                    .dr_qty = newDR.Item("qty").ToString
                    .inout = newDR.Item("IN_OUT").ToString
                End With

                cListOfdrqty.Add(newD_qty)
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub


    Private Sub get_reported_dr()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Dim newD As New reported_list
        Try
            If cSearchBy = "DATE RANGE" Then

                newSQ.connection.Open()
                newCMD = New SqlCommand("proc_dr_list2", newSQ.connection)
                newCMD.Parameters.Clear()
                newCMD.CommandType = CommandType.StoredProcedure

                newCMD.Parameters.AddWithValue("@n", 10)
                newCMD.Parameters.AddWithValue("@date_from", cDateFrom)
                newCMD.Parameters.AddWithValue("@date_to", cDateTo)
                newDR = newCMD.ExecuteReader

                While newDR.Read
                    newD.reported_dr_id = newDR.Item("reported_dr_id").ToString
                    newD.dr_item_id = newDR.Item("dr_items_id").ToString
                    newD.dr_option = newDR.Item("dr_option").ToString
                    newD.date_reported = Date.Parse(newDR.Item("date_reported").ToString)
                    newD.date_served = Date.Parse(newDR.Item("date_served").ToString)
                    newD.reported_user = newDR.Item("users").ToString

                    cListOfReportedDR.Add(newD)
                End While

            End If

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub



End Class
