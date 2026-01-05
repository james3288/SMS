Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class class_ws
    Private cDateFrom As DateTime
    Private cDateTo As DateTime
    Private cSearchBy As String
    Private cSearch As String
    Private cWh_id As Integer
    Private cDateRange As Boolean = False

    Public trd, trd2, trd3 As Threading.Thread
    Public stat As String

    Structure ws

        Dim ws_id As Integer
        Dim ws_no As String
        Dim rs_no As String
        Dim requestor As String
        Dim ws_date As DateTime
        Dim rs_date As DateTime
        Dim dr_no As String
        Dim plateno As String
        Dim driver As String
        Dim po_no As String
        Dim rr_no As String
        Dim item_name As String
        Dim item_desc As String
        Dim unit As String
        Dim ws_source As String
        Dim concession_ticket As String
        Dim ws_qty As Double
        Dim price As Double
        Dim total_amount As Double
        Dim supplier As String
        Dim checked_by As String
        Dim approved_by As String
        Dim withdrawn_by As String
        Dim remarks As String
        Dim users As String
        Dim rs_id As Integer
        Dim inout As String
        Dim dr_option As String
        Dim wh_id As Integer
        Dim source2 As String

    End Structure
    Structure ws_qty
        Dim ws_date As DateTime
        Dim ws_qty As Double
        Dim inout As String

    End Structure

    Public cListOfWs As New List(Of ws)
    Public cListOfWs_qty As New List(Of ws_qty)
    Public cws_qty As Double

    'FOR HAULING INITIATE
    Public Sub _initialize(datefrom As DateTime, dateto As DateTime, searchby As String, Optional search As String = "", Optional daterange As Boolean = False, Optional wh_id As Integer = 0)

        cDateFrom = datefrom
        cDateTo = dateto
        cSearchBy = searchby
        cSearch = search
        cDateRange = daterange
        cWh_id = wh_id

        trd = New Threading.Thread(AddressOf get_ws_without_dr)
        trd.Name = "tr_get_ws_without_dr"
        trd.Start()
    End Sub

    Public Sub _initialize_previous_balance(datefrom As DateTime, dateto As DateTime, searchby As String, Optional search As String = "", Optional daterange As Boolean = False, Optional wh_id As Integer = 0)

        cDateFrom = datefrom
        cDateTo = dateto
        cSearchBy = searchby
        cSearch = search
        cDateRange = daterange
        cWh_id = wh_id
        cListOfWs_qty.Clear()

        trd3 = New Threading.Thread(AddressOf get_ws_previous_qty_withour_dr)
        trd3.Start()

    End Sub

    Private Sub get_ws_without_dr()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Dim newWs As New ws
        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_dr_list2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            Select Case cSearchBy
                Case "DATE RANGE"
                    newCMD.Parameters.AddWithValue("@n", 4)
                    newCMD.Parameters.AddWithValue("@date_from", cDateFrom)
                    newCMD.Parameters.AddWithValue("@date_to", cDateTo)
                Case "IN/OUT"
                    newCMD.Parameters.AddWithValue("@n", 55)
                    newCMD.Parameters.AddWithValue("@search", cSearch)
                    newCMD.Parameters.AddWithValue("@date_from", cDateFrom)
                    newCMD.Parameters.AddWithValue("@date_to", cDateTo)
                Case "WH_ID"
                    newCMD.Parameters.AddWithValue("@n", 62)
                    newCMD.Parameters.AddWithValue("@wh_id", cWh_id)
                    newCMD.Parameters.AddWithValue("@date_from", cDateFrom)
                    newCMD.Parameters.AddWithValue("@date_to", cDateTo)

                Case Else
                    Dim n As Integer = IIf(cDateRange = False, 6, 61)
                    newCMD.Parameters.AddWithValue("@n", n)
                    newCMD.Parameters.AddWithValue("@searchby", cSearchBy)
                    newCMD.Parameters.AddWithValue("@search", cSearch)

                    newCMD.Parameters.AddWithValue("@date_from", cDateFrom)
                    newCMD.Parameters.AddWithValue("@date_to", cDateTo)
            End Select

            newDR = newCMD.ExecuteReader

            While newDR.Read
                With newWs
                    .ws_id = newDR.Item("po_det_id").ToString
                    .rs_no = newDR.Item("rs_no").ToString
                    .requestor = newDR.Item("requestor").ToString
                    .ws_date = newDR.Item("ws_date").ToString
                    .rs_date = newDR.Item("rs_date").ToString
                    .dr_no = newDR.Item("dr_no").ToString
                    .plateno = newDR.Item("plate_no").ToString
                    .driver = newDR.Item("operator").ToString
                    .po_no = newDR.Item("ws_no").ToString
                    .rr_no = newDR.Item("rr_no").ToString
                    .item_name = newDR.Item("item_name").ToString
                    .item_desc = newDR.Item("item_desc").ToString
                    .unit = newDR.Item("unit").ToString
                    .ws_source = newDR.Item("ws_source").ToString
                    .concession_ticket = newDR.Item("concession_ticket").ToString
                    .ws_qty = newDR.Item("ws_qty").ToString
                    .price = newDR.Item("price").ToString
                    .total_amount = newDR.Item("total_amount").ToString
                    .supplier = newDR.Item("supplier").ToString
                    .checked_by = newDR.Item("checked_by").ToString
                    .approved_by = newDR.Item("approved_by").ToString
                    .remarks = newDR.Item("remarks").ToString
                    .users = newDR.Item("users").ToString
                    .rs_id = newDR.Item("rs_id").ToString
                    .inout = newDR.Item("IN_OUT").ToString
                    .dr_option = newDR.Item("dr_option").ToString
                    .ws_no = newDR.Item("ws_no").ToString
                    .withdrawn_by = newDR.Item("checked_by").ToString.ToUpper
                    .wh_id = newDR.Item("wh_id").ToString
                    .source2 = newDR.Item("source2").ToString

                    stat = .ws_id

                    cListOfWs.Add(newWs)

                    Module_public_var.pub_stat = newWs.plateno
                End With



            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    'FOR STOCKCARD INITIATE
    Public Sub get_ws_previous_qty_withour_dr()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Dim newWs_qty As New ws_qty
        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_dr_list2", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 63)
            newCMD.Parameters.AddWithValue("@wh_id", cWh_id)
            newCMD.Parameters.AddWithValue("@date_from", cDateFrom)
            newCMD.Parameters.AddWithValue("@date_to", cDateTo)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                With newWs_qty
                    .ws_date = newDR.Item("po_date").ToString
                    .ws_qty = newDR.Item("ws_qty").ToString
                    .inout = newDR.Item("IN_OUT").ToString
                End With

                cListOfWs_qty.Add(newWs_qty)
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Private Sub get_ws()

    End Sub
End Class
