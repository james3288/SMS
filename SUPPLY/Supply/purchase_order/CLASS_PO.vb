Imports System.ComponentModel
Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class CLASS_PO
    Public cListOfrrPo As New List(Of received_po)
    Public cListOfmultiplePo As New List(Of multiple_po)
    Public cListOfUnits As New List(Of String)
    Public cListOfPO As New List(Of po_data)

    Private cN As Integer
    Private cSearchBy As String
    Private cSearch As String
    Private bw_search As New BackgroundWorker
    Private bw_units As New BackgroundWorker
    Private cListview As New ListView
    Private cLoading As New Panel
    Private cLabel As New Label


    Private cUnit As New class_placeholder4
    Sub New()

        '------ADD HANDLER HERE----------
        'SEARCH ANY ITEMS
        AddHandler bw_search.DoWork, AddressOf bw_search_DoWork
        AddHandler bw_search.RunWorkerCompleted, AddressOf bw_search_RunWorkerCompleted

        'LOAD UNITS
        AddHandler bw_units.DoWork, AddressOf bw_units_DoWork
        AddHandler bw_units.RunWorkerCompleted, AddressOf bw_units_RunWorkerCompleted
        '-----END HANDLER HERE-------------
    End Sub
    'EXIST RR
    Public Sub is_exist_in_rr(po_det_id As Integer)
        cListOfrrPo.Clear()

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_edit_po", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 1)
            newCMD.Parameters.AddWithValue("@po_det_id", po_det_id)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                Dim r As New received_po
                With r
                    .po_det_id = newDR.Item("po_det_id").ToString
                    .totalcount = newDR.Item("totalcount").ToString
                End With

                cListOfrrPo.Add(r)
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    'MULTIPLE PO
    Public Sub is_multiple_po(rs_id As Integer)
        cListOfmultiplePo.Clear()

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_edit_po", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 2)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)
            newDR = newCMD.ExecuteReader


            While newDR.Read
                Dim m As New multiple_po
                With m
                    .rs_id = newDR.Item("rs_id").ToString
                    .totalcount = newDR.Item("totalcount").ToString
                End With
                cListOfmultiplePo.Add(m)
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    'GET RS QTY
    Public Function get_rs_qty(rs_id As Integer) As Double
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_edit_po", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 3)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)
            newDR = newCMD.ExecuteReader


            While newDR.Read
                get_rs_qty = newDR.Item("qty").ToString
            End While

            Return get_rs_qty
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function

    'UPDATE RS QTY
    Public Sub update_rs_qty(rs_id As Integer, desired_qty As Double, unit As String)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_edit_po", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 4)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)
            newCMD.Parameters.AddWithValue("@desired_qty", desired_qty)
            newCMD.Parameters.AddWithValue("@unit_now", unit)

            newCMD.ExecuteNonQuery()
            MessageBox.Show("RS quantity was successfully updated..", "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Information)


        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    'UPDATE PO QTY
    Public Sub update_po_qty(po_det_id As Integer, desired_qty As Double, unit As String)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_edit_po", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 5)
            newCMD.Parameters.AddWithValue("@po_det_id", po_det_id)
            newCMD.Parameters.AddWithValue("@desired_qty", desired_qty)
            newCMD.Parameters.AddWithValue("@unit_now", unit)

            newCMD.ExecuteNonQuery()
            MessageBox.Show("PO quantity was successfully updated..", "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    'INITIALIZE UNITS
    Public Function units(Optional txtUnit As class_placeholder4 = Nothing, Optional label As Label = Nothing) As List(Of String)
        Try
            cUnit = txtUnit
            cLabel = label

            bw_units.WorkerSupportsCancellation = True
            bw_units.RunWorkerAsync()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function
    'GET UNITS QUERY
    Private Sub get_units()
        cListOfUnits.Clear()

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_edit_po", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 6)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                cListOfUnits.Add(newDR.Item("unit").ToString)
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub


    'INITIALIZE FOR PO LIST
    Public Sub po_list(n As Integer, searchby As String, search As String, Optional listview As ListView = Nothing, Optional loading As Panel = Nothing)
        Try
            cN = n
            cSearchBy = searchby
            cSearch = search
            cListview = listview
            cLoading = loading

            cLoading.Visible = True
            'run bw_search here
            bw_search.WorkerSupportsCancellation = True
            bw_search.RunWorkerAsync()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    'GET PO LIST QUERY
    Private Sub get_po_list()
        Dim SQ As New SQLcon
        Dim newSQ As New SQLcon
        'Dim newCMD As SqlCommand
        'Dim reader As SqlDataReader

        cListOfPO.Clear()

        Try
            Dim c As New class_query

            c.add_parameter("@n", cN)
            c.add_parameter("@searchby", cSearchBy)
            c.add_parameter("@search", cSearch)

            Dim reader As SqlDataReader = c.sql_data("po_query_new2", SQ.connection)

            'SQ.connection.Open()
            'newCMD = New SqlCommand("proc_edit_po", SQ.connection)
            'newCMD.Parameters.Clear()
            'newCMD.CommandType = CommandType.StoredProcedure
            'newCMD.Parameters.AddWithValue("@n", cN)
            ''newCMD.Parameters.AddWithValue("@searchby", cSearchBy)
            'newCMD.Parameters.AddWithValue("@search", cSearch)

            'reader = newCMD.ExecuteReader

            While reader.Read
                Dim podata As New po_data
                With podata
                    .po_det_id = reader.Item("po_det_id").ToString
                    .po_no = reader.Item("po_no").ToString
                    .rs_no = reader.Item("rs_no").ToString
                    .po_date = IIf(reader.Item("po_date").ToString = "", "1990-01-01", reader.Item("po_date").ToString)
                    .Supplier_Name = reader.Item("Supplier_Name").ToString
                    .Item_Name = reader.Item("Item_Name").ToString
                    .Item_Desc = reader.Item("Item_desc").ToString
                    .qty = reader.Item("qty").ToString
                    .unit = reader.Item("unit").ToString
                    .unit_price = IIf(reader.Item("unit_price").ToString = "", 0, reader.Item("unit_price").ToString)
                    .total_amount = IIf(reader.Item("total_amount").ToString = "", 0, reader.Item("total_amount").ToString)
                    .instructions = reader.Item("instructions").ToString
                    .address = reader.Item("address").ToString
                    .terms = reader.Item("terms").ToString
                    .charges = reader.Item("charges").ToString
                    .date_needed = IIf(reader.Item("date_needed").ToString = "", "1990-01-01", reader.Item("date_needed").ToString)
                    .prepared_by = reader.Item("prepared_by").ToString
                    .checked_by = reader.Item("checked_by").ToString
                    .approved_by = reader.Item("approved_by").ToString
                    .rs_id = IIf(reader.Item("rs_id").ToString = "", 0, reader.Item("rs_id").ToString)
                    .selected = reader.Item("selected").ToString
                    .po_id = IIf(reader.Item("po_id").ToString = "", 0, reader.Item("po_id").ToString)
                    .inout = reader.Item("IN_OUT").ToString
                    .print_stats = reader.Item("print_stats").ToString
                    .orig_date_printed = IIf(reader.Item("print_date_logss").ToString = "", "1990-01-01", reader.Item("print_date_logss").ToString)
                    .updated_date_printed = IIf(reader.Item("print_date_update").ToString = "", "1990-01-01", reader.Item("print_date_update").ToString)
                    .user_logs = reader.Item("userss").ToString
                    .lead_time_rs_to_po = IIf(reader.Item("lead_time_rs_to_po").ToString = "", 0, reader.Item("lead_time_rs_to_po").ToString)
                End With

                cListOfPO.Add(podata)
            End While
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try

    End Sub

    'UNITS HANDLER
    Private Sub bw_units_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs)
        Dim trd As Threading.Thread
        trd = New Threading.Thread(AddressOf get_units)
        trd.Start()
        trd.Join()
    End Sub
    Private Sub bw_units_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs)

        Dim units As New AutoCompleteStringCollection

        Dim cListOfData = cListOfUnits
        For Each row In cListOfData
            units.Add(row)
        Next

        cUnit.tbox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cUnit.tbox.AutoCompleteSource = AutoCompleteSource.CustomSource
        cUnit.tbox.AutoCompleteCustomSource = units

        cLabel.Visible = False
    End Sub

    'SEARCH HANDLER
    Private Sub bw_search_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs)
        Dim trd As Threading.Thread
        trd = New Threading.Thread(AddressOf get_po_list)
        trd.Start()
        trd.Join()
    End Sub

    Private Sub bw_search_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs)
        display_po()
        cLoading.Visible = False
    End Sub

    Private Sub display_po()
        cListview.Items.Clear()
        Dim listoflistview As New List(Of ListViewItem)

        For Each row In cListOfPO
            Dim a(28) As String

            a(0) = row.po_det_id
            a(1) = row.po_no
            a(2) = row.rs_no
            a(3) = row.po_date
            a(4) = row.Supplier_Name
            a(5) = row.Item_Name
            a(6) = row.Item_Desc
            a(7) = row.qty
            a(8) = row.unit
            a(9) = row.unit_price
            a(10) = row.total_amount
            a(12) = row.instructions
            a(13) = row.address
            a(14) = row.terms
            a(15) = row.charges
            a(16) = row.date_needed
            a(17) = row.prepared_by
            a(18) = row.checked_by
            a(19) = row.approved_by
            a(20) = row.rs_id
            a(21) = row.selected
            a(22) = row.po_id
            a(23) = row.inout
            a(24) = IIf(row.lead_time_rs_to_po < 0, row.lead_time_rs_to_po & " - check po_date", IIf(row.lead_time_rs_to_po > 1, row.lead_time_rs_to_po & " days", row.lead_time_rs_to_po & " day"))
            a(25) = row.print_stats
            a(26) = IIf(row.orig_date_printed = "1990-01-01", "-", row.orig_date_printed)
            a(27) = IIf(row.updated_date_printed = "1990-01-01", "-", row.updated_date_printed)
            a(28) = row.user_logs

            Dim lvl As New ListViewItem(a)
            listoflistview.Add(lvl)
        Next

        cListview.Items.AddRange(listoflistview.ToArray)
    End Sub
    Public Class po_data
        Public Property po_det_id As Integer
        Public Property po_no As String
        Public Property rs_no As String
        Public Property po_date As DateTime
        Public Property Supplier_Name As String
        Public Property Item_Name As String
        Public Property Item_Desc As String
        Public Property qty As Double
        Public Property unit As String
        Public Property unit_price As Double
        Public Property total_amount As Double
        Public Property instructions As String
        Public Property address As String
        Public Property terms As String
        Public Property rs_id As Integer
        Public Property charges As String
        Public Property date_needed As DateTime
        Public Property prepared_by As String
        Public Property checked_by As String
        Public Property approved_by As String
        Public Property selected As String
        Public Property po_id As String
        Public Property inout As String
        Public Property lead_time_rs_to_po As Double
        Public Property print_stats As String
        Public Property orig_date_printed As DateTime
        Public Property updated_date_printed As DateTime
        Public Property user_logs As String

    End Class

    Public Class received_po
        Public Property po_det_id As Integer
        Public Property totalcount As Integer

    End Class

    Public Class multiple_po
        Public Property rs_id As Integer
        Public Property totalcount As Integer

    End Class
End Class
