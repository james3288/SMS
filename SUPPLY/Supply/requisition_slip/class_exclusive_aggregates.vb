Imports System.ComponentModel
Imports System.Data.SqlClient
Public Class class_exclusive_aggregates

    'backgroundworker
    Private rs_bg As New BackgroundWorker
    Private ws_bg As New BackgroundWorker
    Private ws2_bg As New BackgroundWorker
    Private dr_bg As New BackgroundWorker
    Private dr2_bg As New BackgroundWorker
    Private po_bg As New BackgroundWorker
    Private rr_bg As New BackgroundWorker

    Private checker_bg As New BackgroundWorker
    Private checker_bg2 As New BackgroundWorker

    'components
    Private cLview As New ListView

    'variables
    Private cSearch As String
    Private cSearchBy As String
    Private bRs, bWs, bDr, bPo, bRr As Boolean

    'list
    Private cListOfRS As New List(Of rsdata)
    Private cListOfWs As New List(Of wsdata)
    Private cListOfDr As New List(Of drdata)
    Private cListOfPo As New List(Of podata)
    Private cListOfRr As New List(Of rrdata)

    Private cListOfListViewItem As New List(Of ListViewItem)
    Dim cListOfDrItemId As New List(Of Integer)


    Public ReadOnly Property LISTOFRS
        Get
            Return cListOfRS
        End Get
    End Property

    Public ReadOnly Property LISTOFWS
        Get
            Return cListOfWs
        End Get
    End Property

    Public ReadOnly Property LISTOFPO
        Get
            Return cListOfPo
        End Get
    End Property

    Public ReadOnly Property LISTOFDR
        Get
            Return cListOfDr
        End Get
    End Property

    Public ReadOnly Property LISTOFRR
        Get
            Return cListOfRr
        End Get
    End Property

    Public ReadOnly Property LISTOFDRITEMID

        Get
            Return cListOfDrItemId
        End Get
    End Property

    Sub New()
        AddHandler rs_bg.DoWork, AddressOf rs_DoWork
        AddHandler rs_bg.RunWorkerCompleted, AddressOf rs_RunWorkerCompleted

        AddHandler ws_bg.DoWork, AddressOf ws_DoWork
        AddHandler ws_bg.RunWorkerCompleted, AddressOf ws_RunWorkerCompleted

        AddHandler ws2_bg.DoWork, AddressOf ws2_DoWork

        AddHandler dr_bg.DoWork, AddressOf dr_DoWork
        AddHandler dr_bg.RunWorkerCompleted, AddressOf dr_RunWorkerCompleted

        AddHandler dr2_bg.DoWork, AddressOf dr_DoWork

        AddHandler po_bg.DoWork, AddressOf po_DoWork
        AddHandler po_bg.RunWorkerCompleted, AddressOf po_RunWorkerCompleted

        AddHandler rr_bg.DoWork, AddressOf rr_DoWork
        AddHandler rr_bg.RunWorkerCompleted, AddressOf rr_RunWorkerCompleted

        AddHandler checker_bg.DoWork, AddressOf checker_DoWork
        AddHandler checker_bg.RunWorkerCompleted, AddressOf checker_RunWorkerCompleted

        AddHandler checker_bg2.DoWork, AddressOf checker2_DoWork
        AddHandler checker_bg2.RunWorkerCompleted, AddressOf checker2_RunWorkerCompleted

    End Sub
    Public Sub _initialize(Optional search As String = "", Optional listview As ListView = Nothing)
        cSearch = search
        cListOfRS.Clear()
        cListOfWs.Clear()
        cListOfDr.Clear()
        cListOfPo.Clear()
        cListOfRr.Clear()

        cListOfListViewItem.Clear()

        cLview = listview

        rs_bg.WorkerSupportsCancellation = True
        rs_bg.RunWorkerAsync()

        ws_bg.WorkerSupportsCancellation = True
        ws_bg.RunWorkerAsync()

        dr_bg.WorkerSupportsCancellation = True
        dr_bg.RunWorkerAsync()

        po_bg.WorkerSupportsCancellation = True
        po_bg.RunWorkerAsync()

        rr_bg.WorkerSupportsCancellation = True
        rr_bg.RunWorkerAsync()

        checker_bg.WorkerSupportsCancellation = True
        checker_bg.RunWorkerAsync()
    End Sub

    Public Sub _initialize2(Optional search As String = "", Optional searchby As String = "", Optional enable_date_range As Boolean = False)
        cSearch = search
        cSearchBy = searchby

        cListOfRS.Clear()
        cListOfWs.Clear()
        cListOfDr.Clear()
        cListOfPo.Clear()
        cListOfRr.Clear()

        Select Case cSearchBy
            Case "RS NO"
                dr2_bg.WorkerSupportsCancellation = True
                dr2_bg.RunWorkerAsync()

                ws2_bg.WorkerSupportsCancellation = True
                ws2_bg.RunWorkerAsync()

        End Select

        checker_bg2.WorkerSupportsCancellation = True
        checker_bg2.RunWorkerAsync()
    End Sub
    'WORK
    'RS DOWORK
    Private Sub rs_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs)
        Dim trd As Threading.Thread
        trd = New Threading.Thread(AddressOf get_rs)
        trd.Start()
        trd.Join()

    End Sub
    Private Sub rs_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs)
        bRs = True
    End Sub

    'WS DO WORK
    Private Sub ws_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs)
        Dim trd As Threading.Thread
        trd = New Threading.Thread(AddressOf get_ws)
        trd.Start()
        trd.Join()

    End Sub

    Private Sub ws2_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs)
        Dim trd As Threading.Thread
        trd = New Threading.Thread(AddressOf get_ws2)
        trd.Start()
        trd.Join()

    End Sub
    Private Sub ws_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs)
        bWs = True
    End Sub

    'DR DO WORK
    Private Sub dr_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs)
        Dim trd As Threading.Thread
        trd = New Threading.Thread(AddressOf get_dr)
        trd.Start()
        trd.Join()

    End Sub
    Private Sub dr_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs)
        bDr = True
    End Sub

    Private Sub dr2_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs)
        Dim trd As Threading.Thread
        trd = New Threading.Thread(AddressOf get_dr2)
        trd.Start()
        trd.Join()

    End Sub

    'PO DO WORK
    Private Sub po_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs)
        Dim trd As Threading.Thread
        trd = New Threading.Thread(AddressOf get_po)
        trd.Start()
        trd.Join()

    End Sub
    Private Sub po_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs)
        bPo = True
    End Sub

    'RR DO WORK
    Private Sub rr_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs)
        Dim trd As Threading.Thread
        trd = New Threading.Thread(AddressOf get_rr)
        trd.Start()
        trd.Join()

    End Sub
    Private Sub rr_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs)
        bRr = True
    End Sub

    'CHECKER DO WORK
    Private Sub checker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs)
        Dim trd As Threading.Thread
        trd = New Threading.Thread(AddressOf get_finished)
        trd.Start()
        trd.Join()

    End Sub
    Private Sub checker_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs)
        'MsgBox(cListOfRS.Count & vbCrLf & cListOfWs.Count & vbCrLf & cListOfDr.Count & vbCrLf & cListOfPo.Count & vbCrLf & cListOfRr.Count)

        Dim mainrsqty As New class_main_rs_qty

        '<== FINAL VIEWING TO LISTVIEW
        mainrsqty._initialize3(cSearch, Me, cLview) '===>
        'display()

    End Sub

    Private Sub checker2_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs)
        Dim trd As Threading.Thread
        trd = New Threading.Thread(AddressOf get_finished2)
        trd.Start()
        trd.Join()

    End Sub
    Private Sub checker2_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs)
        MsgBox(cListOfDr.Count & vbCrLf & cListOfWs.Count)
    End Sub


    'DISPLAY

    Private Function checkIfExistInListOfDr(dr_item_id As Integer) As Integer
        'store the dr_item_id in tempStorage
        cListOfDrItemId.ForEach(Sub(id As Integer)
                                    If id = dr_item_id Then
                                        checkIfExistInListOfDr += 1
                                        Exit Sub
                                    End If
                                End Sub)
    End Function

    Private Sub display()
        Dim sortedrs = From RS In cListOfRS
                       Select RS Order By RS.rs_date, RS.item_desc Ascending

        Dim sortws = From WS In cListOfWs
                     Select WS Order By WS.ws_date Ascending

        Dim sortdr = From DR In cListOfDr
                     Select DR Order By DR.dr_date Ascending

        Dim sortpo = From PO In cListOfPo
                     Select PO Order By PO.po_date Ascending

        Dim sortRR = From RR In cListOfRr
                     Select RR Order By RR.date_received Ascending


        For Each req In sortedrs
            '==> RS
            Dim a(40) As String
            With req

                If .inout = "IN" And .type_of_purchasing = "DR" And .request_type = "" And .process = "" Then
                Else
                    a(0) = .rs_id
                    a(1) = .rs_no
                    a(2) = .rs_date
                    a(3) = .job_order_no
                    a(4) = $"{req.rs_items} ({req.item_name } - {req.item_desc })"
                    a(5) = .rs_qty
                    a(6) = .unit
                    a(7) = .date_needed
                    a(8) = .type_of_request
                    a(9) = .inout
                    a(13) = .charges
                    a(14) = .location
                    a(15) = .wh_id
                    a(16) = .date_log
                    a(17) = .type_of_charges
                    a(18) = .type_of_purchasing
                    a(24) = .users
                    a(28) = .requested_by
                    a(29) = .cons_item
                    a(30) = .cons_item_desc
                    a(33) = .wh_area
                    a(37) = .qty_takeoff_desc
                    a(48) = .item_checked_log

                    Dim lvl As New ListViewItem(a)
                    lvl.BackColor = Color.DarkGreen
                    lvl.ForeColor = Color.White
                    lvl.Font = New Font(New FontFamily("Arial"), 10, FontStyle.Bold)

                    cListOfListViewItem.Add(lvl)
                End If
            End With

            'RS ==> WITHDRAWAL
            If req.inout = "OUT" And req.type_of_purchasing = "WITHDRAWAL" Then

                For Each withraw In sortws
                    Dim b(50) As String
                    If withraw.rs_id = req.rs_id And withraw.wh_id = req.wh_id Then
                        With withraw
                            b(0) = .rs_id
                            b(1) = req.rs_no
                            b(2) = .ws_date
                            b(3) = "-"
                            b(4) = $"{req.item_name } - {req.item_desc}"
                            b(5) = "-"
                            b(6) = req.unit2.ToLower
                            b(7) = "-"
                            b(9) = .inout
                            b(10) = "-"
                            b(11) = "-"
                            b(12) = IIf(.qty_withdrawn = 0, "pending", IIf(.qty_withdrawn > 0 And .qty_withdrawn < .ws_qty, "partially withdrawn", "withdrawn"))
                            b(13) = req.charges
                            b(14) = "-"
                            b(15) = req.wh_id
                            b(16) = .date_log
                            b(19) = .remarks
                            b(22) = .ws_qty
                            b(23) = .qty_withdrawn
                            b(24) = .users
                            b(28) = req.requested_by
                            b(29) = req.cons_item
                            b(30) = req.cons_item_desc
                            b(33) = req.wh_area
                            b(36) = .ws_no
                            b(41) = .dr_option
                            b(43) = FormatNumber(.price, 2,,, TriState.False)

                            Dim lvl2 As New ListViewItem(b)
                            lvl2.BackColor = Color.LightGreen
                            lvl2.Font = New Font(New FontFamily("Arial"), 10, FontStyle.Bold)

                            cListOfListViewItem.Add(lvl2)

                        End With
                    End If

                    'RS ==> WS ==> DR
                    For Each dr In sortdr
                        Dim c(50) As String
                        If withraw.ws_no = dr.ws_no And dr.rs_id = req.rs_id And req.wh_id = dr.wh_id Then
                            With dr
                                c(0) = .rs_id
                                c(1) = req.rs_no
                                c(2) = .dr_date
                                c(3) = "-"
                                c(4) = $"- { req.item_desc}"
                                c(5) = "-"
                                c(6) = .unit.ToLower
                                c(7) = "-"
                                c(9) = .inout
                                c(14) = "-"
                                c(13) = "OUT FROM: " & .wh_area
                                c(15) = .wh_id
                                c(16) = "-"
                                c(19) = .remarks
                                c(21) = .dr_no
                                c(22) = "-"
                                c(23) = "-"
                                c(24) = .users
                                c(28) = req.requested_by
                                c(29) = req.cons_item
                                c(30) = req.cons_item_desc
                                c(32) = .dr_qty
                                c(33) = .wh_area
                                c(36) = withraw.ws_no
                                c(41) = "DR"
                                c(42) = .dr_items_id
                                c(43) = FormatNumber(.price, 2,, TriState.False)


                                'check if dr_item_id exist in cListOfDrItemId
                                Dim result As Integer = checkIfExistInListOfDr(.dr_items_id)
                                If result = 0 Then
                                    Dim lvl2 As New ListViewItem(c)
                                    lvl2.BackColor = Color.LightYellow
                                    lvl2.Font = New Font(New FontFamily("Arial"), 10, FontStyle.Italic)

                                    cListOfListViewItem.Add(lvl2)
                                    cListOfDrItemId.Add(.dr_items_id)
                                End If


                                'RS==> WS ==> -DR == > +DR | check if wh to wh 
                                For Each dr2 In sortdr
                                    Dim d(50) As String

                                    If dr2.dr_no = dr.dr_no And dr2.dr_items_id <> dr.dr_items_id And dr2.ws_no = dr.ws_no And dr2.inout = "IN" Then
                                        With dr2
                                            d(0) = dr2.rs_id
                                            d(1) = req.rs_no
                                            d(2) = .dr_date
                                            d(3) = "-"
                                            d(4) = $"+ { dr2.items }"
                                            d(5) = "-"
                                            d(6) = dr2.unit.ToLower
                                            d(7) = "-"
                                            d(9) = .inout
                                            d(13) = "IN TO: " & dr2.wh_area
                                            d(14) = "-"
                                            d(15) = dr2.wh_id
                                            d(16) = "-"
                                            d(19) = .remarks
                                            d(21) = dr2.dr_no
                                            d(22) = "-"
                                            d(23) = "-"
                                            d(24) = .users
                                            d(28) = req.requested_by
                                            d(29) = req.cons_item
                                            d(30) = req.cons_item_desc
                                            d(32) = .dr_qty
                                            d(33) = req.wh_area
                                            d(36) = withraw.ws_no
                                            d(41) = "DR"
                                            d(42) = dr2.dr_items_id
                                            d(43) = FormatNumber(dr2.price, 2,, TriState.False)

                                            'check if dr_item_id exist in cListOfDrItemId
                                            Dim result1 As Integer = checkIfExistInListOfDr(dr2.dr_items_id)
                                            If result1 = 0 Then
                                                Dim lvl3 As New ListViewItem(d)
                                                lvl3.BackColor = Color.LightYellow
                                                lvl3.Font = New Font(New FontFamily("Arial"), 10, FontStyle.Italic)

                                                cListOfListViewItem.Add(lvl3)
                                                cListOfDrItemId.Add(dr2.dr_items_id)
                                            End If

                                        End With
                                    End If
                                Next

                            End With
                        End If
                    Next
                Next

                'RS ==> OTHERS OR IN AND PURCHASEORDER
            ElseIf req.inout = "OTHERS" And req.type_of_purchasing = "PURCHASE ORDER" Or req.inout = "IN" And req.type_of_purchasing = "PURCHASE ORDER" Then
                For Each p In sortpo
                    Dim e(50) As String

                    If req.rs_id = p.rs_id Then
                        With p
                            e(0) = .rs_id
                            e(1) = req.rs_no
                            e(2) = .po_date
                            e(4) = $"- { req.rs_items}"
                            e(6) = req.unit2.ToLower
                            e(5) = "-"
                            e(9) = .inout
                            e(10) = "released"
                            e(11) = "-"
                            e(12) = "-"
                            e(13) = req.charges
                            e(14) = "-"
                            e(15) = req.wh_id
                            e(16) = .date_log
                            e(19) = .remarks
                            e(22) = .qty
                            e(23) = "-"
                            e(24) = .users
                            e(28) = req.requested_by
                            e(29) = req.cons_item
                            e(30) = req.cons_item_desc
                            e(33) = req.wh_area
                            e(36) = .po_no
                            e(41) = .dr_option

                            Dim lvl4 As New ListViewItem(e)
                            lvl4.BackColor = Color.LightGreen
                            cListOfListViewItem.Add(lvl4)
                        End With

                        'RS ==> OTHERS/IN ==> RR
                        For Each rr In sortRR
                            Dim f(40) As String
                            If p.po_det_id = rr.po_det_id Then
                                With rr
                                    f(0) = .rs_id
                                    f(1) = req.rs_no
                                    f(2) = .date_received
                                    f(4) = $"- { req.rs_items}"
                                    f(5) = "-"
                                    f(6) = .unit.ToLower
                                    f(9) = req.inout
                                    f(10) = "-"
                                    f(11) = "received"
                                    f(12) = "-"
                                    f(13) = req.charges
                                    f(14) = "-"
                                    f(15) = req.wh_id
                                    f(16) = .date_log
                                    f(19) = .remarks
                                    f(23) = .qty
                                    f(24) = .users
                                    f(28) = req.requested_by
                                    f(29) = req.cons_item
                                    f(30) = req.cons_item_desc
                                    f(33) = req.wh_area
                                    f(36) = .rr_no

                                    Dim lvl5 As New ListViewItem(f)
                                    lvl5.BackColor = Color.LightPink
                                    cListOfListViewItem.Add(lvl5)
                                End With

                                'RS ==> OTHERS/IN ==> RR ==> DR
                                For Each dr In sortdr
                                    Dim g(50) As String
                                    If dr.rr_no = rr.rr_no And dr.rs_id = req.rs_id Then
                                        With dr
                                            g(0) = .rs_id
                                            g(1) = req.rs_no
                                            g(2) = .dr_date
                                            g(3) = "-"
                                            g(4) = $"- { req.rs_items}"
                                            g(5) = "-"
                                            g(6) = .unit.ToLower
                                            g(9) = req.inout
                                            g(13) = req.charges
                                            g(14) = "-"
                                            g(15) = .wh_id
                                            g(16) = "-"
                                            g(19) = .remarks
                                            g(21) = .dr_no
                                            g(22) = "-"
                                            g(23) = "-"
                                            g(24) = dr.users
                                            g(28) = req.requested_by
                                            g(29) = req.cons_item
                                            g(30) = req.cons_item_desc
                                            g(32) = .dr_qty
                                            g(33) = req.wh_area
                                            g(36) = .rr_no
                                            g(41) = "DR"
                                            g(42) = .dr_items_id
                                            g(43) = FormatNumber(.price, 2,, TriState.False)

                                            'check if dr_item_id exist in cListOfDrItemId
                                            Dim result2 As Integer = checkIfExistInListOfDr(dr.dr_items_id)
                                            If result2 = 0 Then

                                                Dim lvl6 As New ListViewItem(g)
                                                lvl6.BackColor = Color.LightYellow
                                                lvl6.Font = New Font(New FontFamily("Arial"), 10, FontStyle.Italic)
                                                cListOfListViewItem.Add(lvl6)

                                                cListOfDrItemId.Add(dr.dr_items_id)
                                            End If

                                        End With
                                    End If
                                Next
                            End If
                        Next
                    End If
                Next

            ElseIf req.inout = "OTHERS" And req.type_of_purchasing = "DR" Or
                req.inout = "IN" And req.type_of_purchasing = "DR" And req.process <> "" And req.unit <> "" And req.type_of_request <> "" Then

                'RS OTHERS =>= DR
                For Each dr In sortdr
                    Dim h(50) As String
                    If dr.rs_id = req.rs_id Then
                        With dr
                            h(0) = .rs_id
                            h(1) = req.rs_no
                            h(2) = .dr_date
                            h(3) = "-"
                            h(4) = $"- { req.rs_items}"
                            h(5) = "-"
                            h(6) = .unit.ToLower
                            h(9) = req.inout
                            h(13) = req.charges
                            h(14) = "-"
                            h(15) = .wh_id
                            h(16) = "-"
                            h(19) = .remarks
                            h(21) = .dr_no
                            h(22) = "-"
                            h(23) = "-"
                            h(24) = dr.users
                            h(28) = req.requested_by
                            h(29) = req.cons_item
                            h(30) = req.cons_item_desc
                            h(32) = .dr_qty
                            h(33) = req.wh_area
                            h(36) = "-"
                            h(43) = FormatNumber(.price, 2,, TriState.False)

                            'check if dr_item_id exist in cListOfDrItemId
                            Dim result3 As Integer = checkIfExistInListOfDr(dr.dr_items_id)
                            If result3 = 0 Then
                                Dim lvl7 As New ListViewItem(h)
                                lvl7.BackColor = Color.LightYellow
                                lvl7.Font = New Font(New FontFamily("Arial"), 10, FontStyle.Italic)
                                cListOfListViewItem.Add(lvl7)

                                cListOfDrItemId.Add(dr.dr_items_id)
                            End If

                        End With
                    End If
                Next

            End If
        Next

        If cLview.InvokeRequired Then
            cLview.Invoke(Sub()
                              cLview.Items.AddRange(cListOfListViewItem.ToArray)
                          End Sub)
        Else
            cLview.Items.AddRange(cListOfListViewItem.ToArray)
        End If
    End Sub

    'GET DATA HERE
    Private Sub get_rs()

        Dim SQ As New SQLcon
        Dim newSQ As New SQLcon

        Try
            Dim c As New class_query
            c.add_parameter("@n", 1)
            c.add_parameter("search", cSearch)

            Dim reader As SqlDataReader = c.sql_data("PROC_AGGREGATES", SQ.connection)

            While reader.Read
                Dim rs As New rsdata
                With rs
                    .rs_id = reader.Item("rs_id").ToString
                    .rs_date = datechecker(reader.Item("rs_date").ToString)
                    .date_needed = datechecker(reader.Item("date_needed").ToString)
                    .rs_no = reader.Item("rs_no").ToString
                    .wh_id = reader.Item("wh_id").ToString
                    .rs_items = reader.Item("rs_items").ToString
                    .inout = reader.Item("inout").ToString
                    .item_name = reader.Item("item_name").ToString
                    .item_desc = reader.Item("item_desc").ToString
                    .wh_location = reader.Item("wh_location").ToString
                    .charges = reader.Item("charges").ToString
                    .type_of_purchasing = reader.Item("type_of_purchasing").ToString
                    .request_type = reader.Item("typeRequest").ToString
                    .process = reader.Item("process").ToString
                    .rs_qty = reader.Item("rs_qty").ToString
                    .type_of_request = reader.Item("type_of_request").ToString
                    .users = reader.Item("users").ToString
                    .cons_item = reader.Item("cons_item").ToString
                    .cons_item_desc = reader.Item("cons_item_desc").ToString
                    .qty_takeoff_desc = reader.Item("qty_takeoff_desc").ToString
                    .job_order_no = reader.Item("job_order_no").ToString
                    .unit = reader.Item("unit").ToString
                    .location = reader.Item("location").ToString
                    .date_log = datechecker(reader.Item("date_log").ToString)
                    .type_of_charges = reader.Item("type_of_charges").ToString
                    .requested_by = reader.Item("requested_by").ToString
                    .wh_area = reader.Item("wh_area").ToString
                    .unit2 = reader.Item("unit2").ToString
                    .source = reader.Item("source").ToString
                    .purpose = reader.Item("purpose").ToString
                    .item_checked_log = IIf(IsDate(reader.Item("item_checked_log").ToString), reader.Item("item_checked_log").ToString, Date.Parse("1990-01-01"))
                    .wh_pn_id = IIf(reader.Item("wh_pn_id").ToString = "", 0, reader.Item("wh_pn_id").ToString)

                    cListOfRS.Add(rs)
                End With
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub
    Private Sub get_ws()

        Dim SQ As New SQLcon
        Dim newSQ As New SQLcon

        Try
            Dim c As New class_query
            c.add_parameter("@n", 3)
            c.add_parameter("search", cSearch)

            Dim reader As SqlDataReader = c.sql_data("PROC_AGGREGATES", SQ.connection)

            While reader.Read
                Dim ws As New wsdata
                With ws
                    .rs_id = reader.Item("rs_id").ToString
                    .ws_id = reader.Item("ws_id").ToString
                    .ws_no = reader.Item("ws_no").ToString
                    .ws_qty = reader.Item("qty").ToString
                    .ws_date = datechecker(reader.Item("ws_date").ToString)
                    .inout = reader.Item("inout").ToString
                    .qty_withdrawn = IIf(reader.Item("qty_withdrawn").ToString = "", 0, reader.Item("qty_withdrawn").ToString)
                    .price = IIf(reader.Item("price").ToString = "", 0, reader.Item("price").ToString)
                    .unit = reader.Item("unit").ToString
                    .date_log = datechecker(reader.Item("date_log").ToString)
                    .remarks = reader.Item("remarks").ToString
                    .users = reader.Item("users").ToString
                    .dr_option = reader.Item("dr_option").ToString
                    .wh_id = reader.Item("wh_id").ToString
                    cListOfWs.Add(ws)
                End With
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub
    Private Sub get_ws2()

        Dim SQ As New SQLcon
        Dim newSQ As New SQLcon

        Try
            Dim c As New class_query

            Select Case cSearchBy
                Case "RS NO"
                    c.add_parameter("@n", 3)
                    c.add_parameter("search", cSearch)

            End Select

            Dim reader As SqlDataReader = c.sql_data("PROC_AGGREGATES", SQ.connection)

            While reader.Read
                Dim ws As New wsdata
                With ws
                    .rs_id = reader.Item("rs_id").ToString
                    .ws_id = reader.Item("ws_id").ToString
                    .ws_no = reader.Item("ws_no").ToString
                    .ws_qty = reader.Item("qty").ToString
                    .ws_date = datechecker(reader.Item("ws_date").ToString)
                    .inout = reader.Item("inout").ToString
                    .qty_withdrawn = IIf(reader.Item("qty_withdrawn").ToString = "", 0, reader.Item("qty_withdrawn").ToString)
                    .price = IIf(reader.Item("price").ToString = "", 0, reader.Item("price").ToString)
                    .unit = reader.Item("unit").ToString
                    .date_log = datechecker(reader.Item("date_log").ToString)
                    .remarks = reader.Item("remarks").ToString
                    .users = reader.Item("users").ToString
                    .dr_option = reader.Item("dr_option").ToString

                    cListOfWs.Add(ws)
                End With
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub
    Private Sub get_dr()

        Dim SQ As New SQLcon
        Dim newSQ As New SQLcon

        Try
            Dim c As New class_query
            c.add_parameter("@n", 2)
            c.add_parameter("search", cSearch)

            Dim reader As SqlDataReader = c.sql_data("PROC_AGGREGATES", SQ.connection)

            While reader.Read
                Dim dr As New drdata
                With dr
                    .dr_items_id = reader.Item("dr_items_id").ToString
                    .dr_date = reader.Item("dr_date").ToString
                    .date_log = datechecker(reader.Item("date_log").ToString)
                    .dr_no = reader.Item("dr_no").ToString
                    .dr_qty = reader.Item("dr_qty").ToString
                    .rs_no = reader.Item("rs_no").ToString
                    .rs_id = reader.Item("rs_id").ToString
                    .inout = reader.Item("inout").ToString
                    .ws_no = reader.Item("ws_no").ToString
                    .rr_no = reader.Item("rr_no").ToString
                    .wh_area = reader.Item("wh_area").ToString
                    .price = reader.Item("price").ToString
                    .unit = reader.Item("unit").ToString
                    .wh_id = reader.Item("wh_id").ToString
                    .remarks = reader.Item("remarks").ToString
                    .users = reader.Item("users").ToString
                    .items = reader.Item("item_desc").ToString
                    cListOfDr.Add(dr)
                End With
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub
    Private Sub get_dr2()

        Dim SQ As New SQLcon
        Dim newSQ As New SQLcon

        Try
            Dim c As New class_query

            Select Case cSearchBy
                Case "RS NO"
                    c.add_parameter("@n", 2)
                    c.add_parameter("search", cSearch)
            End Select

            Dim reader As SqlDataReader = c.sql_data("PROC_AGGREGATES", SQ.connection)

            While reader.Read
                Dim dr As New drdata
                With dr
                    .dr_items_id = reader.Item("dr_items_id").ToString
                    .dr_date = reader.Item("dr_date").ToString
                    .date_log = datechecker(reader.Item("date_log").ToString)
                    .dr_no = reader.Item("dr_no").ToString
                    .dr_qty = reader.Item("dr_qty").ToString
                    .rs_no = reader.Item("rs_no").ToString
                    .rs_id = reader.Item("rs_id").ToString
                    .inout = reader.Item("inout").ToString
                    .ws_no = reader.Item("ws_no").ToString
                    .rr_no = reader.Item("rr_no").ToString
                    .wh_area = reader.Item("wh_area").ToString
                    .price = reader.Item("price").ToString
                    .unit = reader.Item("unit").ToString
                    .wh_id = reader.Item("wh_id").ToString
                    .remarks = reader.Item("remarks").ToString
                    .users = reader.Item("users").ToString

                    cListOfDr.Add(dr)
                End With
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub
    Private Sub get_po()

        Dim SQ As New SQLcon
        Dim newSQ As New SQLcon

        Try
            Dim c As New class_query
            c.add_parameter("@n", 4)
            c.add_parameter("search", cSearch)

            Dim reader As SqlDataReader = c.sql_data("PROC_AGGREGATES", SQ.connection)

            While reader.Read
                Dim po As New podata
                With po
                    .rs_id = reader.Item("rs_id").ToString
                    .po_det_id = reader.Item("po_det_id").ToString
                    .po_no = reader.Item("po_no").ToString
                    .qty = reader.Item("qty").ToString
                    .po_date = datechecker(reader.Item("po_date").ToString)
                    .inout = reader.Item("inout").ToString
                    .unit = reader.Item("unit").ToString
                    .date_log = datechecker(reader.Item("date_log").ToString)
                    .remarks = reader.Item("remarks").ToString
                    .users = reader.Item("users").ToString
                    .dr_option = reader.Item("dr_option").ToString

                    cListOfPo.Add(po)
                End With
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub
    Private Sub get_rr()

        Dim SQ As New SQLcon
        Dim newSQ As New SQLcon

        Try
            Dim c As New class_query
            c.add_parameter("@n", 5)
            c.add_parameter("search", cSearch)

            Dim reader As SqlDataReader = c.sql_data("PROC_AGGREGATES", SQ.connection)

            While reader.Read
                Dim rr As New rrdata
                With rr
                    .rs_id = reader.Item("rs_id").ToString
                    .rr_item_id = reader.Item("rr_item_id").ToString
                    .date_received = datechecker(reader.Item("date_received").ToString)
                    .rr_no = reader.Item("rr_no").ToString
                    .qty = reader.Item("qty").ToString
                    .po_det_id = reader.Item("po_det_id").ToString
                    .unit = reader.Item("unit").ToString
                    .date_log = datechecker(reader.Item("date_log").ToString)
                    .remarks = reader.Item("remarks").ToString
                    .users = reader.Item("users").ToString

                    cListOfRr.Add(rr)
                End With
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub
    Private Sub get_finished()
        While True
            Threading.Thread.Sleep(100)
            If bRs = True And bWs = True And bDr = True And bPo = True And bRr = True Then
                Exit While
            End If
        End While
    End Sub

    Private Sub get_finished2()
        While True
            Threading.Thread.Sleep(100)

            If Not rs_bg.IsBusy = True And Not ws_bg.IsBusy = True And Not po_bg.IsBusy = True And Not dr_bg.IsBusy = True _
                And Not rr_bg.IsBusy = True And Not dr2_bg.IsBusy = True And Not ws2_bg.IsBusy = True Then
                Exit While
            End If
        End While
    End Sub


    'FUNCTIONS
    Private Function datechecker(d As String)
        If IsDate(d) Then
            Return Date.Parse(d)
        Else
            Return Date.Parse("1990-01-01")
        End If

    End Function


    'CLASS HERE
    Public Class rsdata
        Public Property rs_id As Integer
        Public Property rs_date As DateTime
        Public Property date_needed As DateTime
        Public Property date_log As DateTime
        Public Property rs_no As String
        Public Property wh_id As Integer
        Public Property rs_items As String
        Public Property inout As String
        Public Property item_name As String
        Public Property type_of_purchasing As String
        Public Property request_type As String
        Public Property item_desc As String
        Public Property wh_location As String
        Public Property charges As String
        Public Property rs_qty As Double
        Public Property process As String
        Public Property unit As String
        Public Property type_of_request As String
        Public Property users As String
        Public Property cons_item As String
        Public Property cons_item_desc As String
        Public Property qty_takeoff_desc As String
        Public Property job_order_no As String
        Public Property location As String
        Public Property type_of_charges As String
        Public Property requested_by As String
        Public Property wh_area As String
        Public Property unit2 As String
        Public Property source As String
        Public Property purpose As String
        Public Property item_checked_log As DateTime
        Public Property wh_pn_id As Integer


    End Class
    Public Class wsdata
        Public Property ws_id As Integer
        Public Property rs_id As Integer
        Public Property ws_no As String
        Public Property ws_qty As Double
        Public Property ws_date As DateTime
        Public Property date_log As DateTime
        Public Property inout As String
        Public Property qty_withdrawn As Double
        Public Property price As Double
        Public Property unit As String
        Public Property remarks As String
        Public Property users As String
        Public Property dr_option As String
        Public Property wh_id As Integer


    End Class
    Public Class drdata
        Public Property dr_items_id As Integer
        Public Property dr_date As DateTime
        Public Property date_log As DateTime
        Public Property dr_no As String
        Public Property dr_qty As Double
        Public Property rs_no As String
        Public Property ws_no As String
        Public Property rs_id As Integer
        Public Property inout As String
        Public Property rr_no As String
        Public Property users As String
        Public Property wh_area As String
        Public Property price As String
        Public Property unit As String
        Public Property wh_id As Integer
        Public Property remarks As String
        Public Property concession As String
        Public Property driver As String
        Public Property address As String
        Public Property checked_by As String
        Public Property received_by As String
        Public Property dr_info_id As String
        Public Property items As String


    End Class
    Public Class podata
        Public Property rs_id As Integer
        Public Property po_det_id As Integer
        Public Property po_no As String
        Public Property qty As Double
        Public Property po_date As DateTime
        Public Property date_log As DateTime
        Public Property inout As String
        Public Property unit As String
        Public Property remarks As String
        Public Property users As String
        Public Property dr_option As String
    End Class
    Public Class rrdata
        Public Property rs_id As Integer
        Public Property rr_item_id As Integer
        Public Property date_received As DateTime
        Public Property date_log As DateTime
        Public Property rr_no As String
        Public Property qty As Double
        Public Property po_det_id As Integer
        Public Property unit As String
        Public Property remarks As String
        Public Property users As String
    End Class

    'STRUCTURE HERE

End Class
