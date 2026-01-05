Imports System.ComponentModel
Imports System.Data.SqlClient
Public Class class_main_rs_qty
    'components
    Private cListView As ListView
    Private cListView2 As ListView
    Private cListOfListViewItem As New List(Of ListViewItem)
    Private cListOfListViewItem2 As New List(Of ListViewItem)
    Private cLabel As New Label
    'list
    Private cListOfMainRSQty As New List(Of main_rs)
    Private cListOfMainRs_Sub As New List(Of main_rs_sub)
    Private cListOfRS As New List(Of class_exclusive_aggregates.rsdata)
    Private cListOfWs As New List(Of class_exclusive_aggregates.wsdata)
    Private cListOfDr As New List(Of class_exclusive_aggregates.drdata)
    Private cListOfPo As New List(Of class_exclusive_aggregates.podata)
    Private cListOfRr As New List(Of class_exclusive_aggregates.rrdata)

    'variables
    Private bR1, br2, br3 As Boolean
    Private cRS_No As String
    Private cRemaining_Balance As Double
    Private cTotal_Dr, cTotal_Dr2 As Double
    Private cTotal_RR As Double
    Private cToBeDisplay As Boolean
    Public cOpenCloseQty As Double
    Private cRsId As Integer

    'backgroundworker
    Private main_rs_bg As New BackgroundWorker
    Private main_rs_sub_bg As New BackgroundWorker
    Private checker_bg As New BackgroundWorker
    Private checker2_bg As New BackgroundWorker

    Private cAgg As New class_exclusive_aggregates
    Dim cListOfDrItemId As New List(Of Integer)

    Sub New()
        cOpenCloseQty = 0

        AddHandler main_rs_bg.DoWork, AddressOf main_rs_DoWork
        AddHandler main_rs_bg.RunWorkerCompleted, AddressOf main_rs_RunWorkerCompleted

        AddHandler main_rs_sub_bg.DoWork, AddressOf main_rs_sub_DoWork
        AddHandler main_rs_sub_bg.RunWorkerCompleted, AddressOf main_rs_sub_RunWorkerCompleted

        AddHandler checker_bg.DoWork, AddressOf checker_DoWork
        AddHandler checker_bg.RunWorkerCompleted, AddressOf checker_RunWorkerCompleted

        AddHandler checker2_bg.DoWork, AddressOf checker2_DoWork
        AddHandler checker2_bg.RunWorkerCompleted, AddressOf checker2_RunWorkerCompleted
    End Sub
    '<==INITIALIZE HERE
    Public Sub _initialize(Optional RSNO As String = "", Optional listview As ListView = Nothing, Optional agg As class_exclusive_aggregates = Nothing, Optional listview2 As ListView = Nothing, Optional toBeDisplay As Boolean = False)
        cRS_No = RSNO
        cListView = listview
        cListView2 = listview2
        cToBeDisplay = toBeDisplay

        cAgg = agg

        cListOfMainRSQty.Clear()
        cListOfMainRs_Sub.Clear()

        cListOfListViewItem.Clear()
        cListOfListViewItem2.Clear()

        main_rs_bg.WorkerSupportsCancellation = True
        main_rs_bg.RunWorkerAsync()

        main_rs_sub_bg.WorkerSupportsCancellation = True
        main_rs_sub_bg.RunWorkerAsync()

        checker_bg.WorkerSupportsCancellation = True
        checker_bg.RunWorkerAsync()
    End Sub

    Public Sub _initialize2(Optional listview As ListView = Nothing)
        cListView2 = listview
        display2()

    End Sub

    Public Sub _initialize3(Optional RSNO As String = "", Optional agg As class_exclusive_aggregates = Nothing, Optional listview As ListView = Nothing)
        cListView = listview
        cRS_No = RSNO

        cListOfRS = agg.LISTOFRS
        cListOfWs = agg.LISTOFWS
        cListOfDr = agg.LISTOFDR
        cListOfRr = agg.LISTOFRR
        cListOfPo = agg.LISTOFPO

        cListOfMainRSQty.Clear()
        cListOfMainRs_Sub.Clear()

        cListOfListViewItem.Clear()
        cListOfListViewItem2.Clear()

        main_rs_bg.WorkerSupportsCancellation = True
        main_rs_bg.RunWorkerAsync()

        main_rs_sub_bg.WorkerSupportsCancellation = True
        main_rs_sub_bg.RunWorkerAsync()

        checker2_bg.WorkerSupportsCancellation = True
        checker2_bg.RunWorkerAsync()
    End Sub


    'END INITIALIZE HERE ==>

    '<== DELEGATES HERE
    Private Delegate Function ListOfMainRSDelegate() As List(Of main_rs)
    Private Delegate Function ListOfMainRS_SubDelegate() As List(Of main_rs_sub)
    Private Delegate Function ListOfOldMainRsDelegate() As Double
    'END DELEGATES HERE ==> 

    '<== FUNCTIONS AND RETURN HERE
    Public Function LISTOFMAINRS(rs_no As String) As List(Of main_rs)
        cRS_No = rs_no

        Dim MainRSInstance As ListOfMainRSDelegate = AddressOf get_main_rs2

        ' Begin the asynchronous operation
        Dim asyncResult As IAsyncResult = MainRSInstance.BeginInvoke(Nothing, Nothing)

        ' The UI thread is free to continue executing here
        ' while the asynchronous operation is running in the background

        '==> UI thread is free to execute other code <==


        ' Wait for the asynchronous operation to complete
        While Not asyncResult.IsCompleted
            Application.DoEvents()
        End While

        ' Get the result of the asynchronous operation
        LISTOFMAINRS = MainRSInstance.EndInvoke(asyncResult)
    End Function
    Public Function LISTOFMAINRS_SUB(rs_no As String) As List(Of main_rs_sub)
        cRS_No = rs_no

        Dim MainRS_Sub_Instance As ListOfMainRS_SubDelegate = AddressOf get_main_rs_sub2

        ' Begin the asynchronous operation
        Dim asyncResult As IAsyncResult = MainRS_Sub_Instance.BeginInvoke(Nothing, Nothing)

        ' The UI thread is free to continue executing here
        ' while the asynchronous operation is running in the background

        '==> UI thread is free to execute other code <==


        ' Wait for the asynchronous operation to complete
        While Not asyncResult.IsCompleted
            Application.DoEvents()
        End While

        ' Get the result of the asynchronous operation
        LISTOFMAINRS_SUB = MainRS_Sub_Instance.EndInvoke(asyncResult)
    End Function
    Public Function get_remaining_balance(listofmainrs As List(Of main_rs), listofmainrs_sub As List(Of main_rs_sub), agg As class_exclusive_aggregates, rs_id As Integer) As Double
        cAgg = agg

        Dim main_rs_qty_id As Integer = 0
        Dim counter As Integer

        '<=== GET main_rs_qty_id
        For Each mainqty In listofmainrs
            ' MAIN RS

            Dim remaining_balance As Double = 0

            For Each main_rs_sub In listofmainrs_sub
                If main_rs_sub.rs_id = rs_id Then
                    main_rs_qty_id = main_rs_sub.main_rs_qty_id
                    counter += 1
                    Exit For
                End If
            Next

            If counter > 0 Then
                Exit For
            End If
        Next '===>

        For Each mainqty In listofmainrs 'LOOP MAIN RS QTY using main_rs_qty_id get from the loop at the top
            If mainqty.main_rs_qty_id = main_rs_qty_id Then
                'MsgBox(mainqty.main_rs_qty)

                '<== initialize main rs qty to function variable
                get_remaining_balance = mainqty.main_rs_qty '==>

                '<== GET PREV LISTOF RS GENERATED FROM CLASS: class_exclusive_aggregates
                Dim listofrs As New List(Of class_exclusive_aggregates.rsdata)
                listofrs = cAgg.LISTOFRS '==>

                '<== LEFT JOIN USING LINEQ the listofrs and listofmainrs_sub to get specific main sub rs qty
                Dim query = From AA In listofmainrs_sub
                            Group Join BB In listofrs On BB.rs_id Equals AA.rs_id Into GG = Group
                            From g In GG.DefaultIfEmpty
                            Select New With {.main_rs_qty_id = AA.main_rs_qty_id, .qty = g.rs_qty} '===>

                '<=== get the remaining balance 
                For Each main_rs_sub In query

                    If main_rs_sub.main_rs_qty_id = mainqty.main_rs_qty_id Then
                        get_remaining_balance -= main_rs_sub.qty
                    End If
                Next ' ==>
                Exit For
            End If

        Next
    End Function
    Public Function copy_get_remaining_balance(listofmainrs As List(Of main_rs), listofmainrs_sub As List(Of main_rs_sub), agg As class_exclusive_aggregates, main_rs_qty_id As Integer) As Double
        cAgg = agg

        For Each mainqty In listofmainrs 'LOOP MAIN RS QTY using main_rs_qty_id
            If mainqty.main_rs_qty_id = main_rs_qty_id Then
                'MsgBox(mainqty.main_rs_qty)

                '<== initialize main rs qty to function variable
                copy_get_remaining_balance = mainqty.main_rs_qty '==>

                '<== GET PREV LISTOF RS GENERATED FROM CLASS: class_exclusive_aggregates
                Dim listofrs As New List(Of class_exclusive_aggregates.rsdata)
                listofrs = cAgg.LISTOFRS '==>

                '<== LEFT JOIN USING LINEQ the listofrs and listofmainrs_sub to get specific main sub rs qty
                Dim query = From AA In listofmainrs_sub
                            Group Join BB In listofrs On BB.rs_id Equals AA.rs_id Into GG = Group
                            From g In GG.DefaultIfEmpty
                            Select New With {.main_rs_qty_id = AA.main_rs_qty_id, .qty = g.rs_qty} '===>

                '<=== get the remaining balance 
                For Each main_rs_sub In query

                    If main_rs_sub.main_rs_qty_id = mainqty.main_rs_qty_id Then
                        copy_get_remaining_balance -= main_rs_sub.qty
                    End If
                Next ' ==>


                Exit For
            End If
        Next
    End Function
    Public Function OLD_MAIN_RS_QTY(rs_no As String, Optional label As Label = Nothing) As Double
        cRS_No = rs_no
        cLabel = label

        Dim OldmainRsQtyInstance As ListOfOldMainRsDelegate = AddressOf get_old_main_rs_qty

        ' Begin the asynchronous operation
        Dim asyncResult As IAsyncResult = OldmainRsQtyInstance.BeginInvoke(Nothing, Nothing)

        ' The UI thread is free to continue executing here
        ' while the asynchronous operation is running in the background

        '==> UI thread is free to execute other code <==      

        ' Wait for the asynchronous operation to complete
        While Not asyncResult.IsCompleted
            Application.DoEvents()
        End While

        ' Get the result of the asynchronous operation
        OLD_MAIN_RS_QTY = OldmainRsQtyInstance.EndInvoke(asyncResult)
    End Function

    'END FUNCTIONS HERE ==>


    '<== UPDATE AND INSERT METHODS
    Public Sub insert(main_rs_qty As Double, rs_no As String, openclose_qty As String)
        Dim SQ As New SQLcon
        Try
            Dim c As New class_query
            c.add_parameter("@n", 7)
            c.add_parameter("@rs_no", rs_no)
            c.add_parameter("@main_rs_qty", main_rs_qty)
            c.add_parameter("@open_qty", IIf(openclose_qty = "OPEN QTY", 1, 0))

            c.insert_update("proc_main_rs_qty", SQ.connection).ExecuteNonQuery()

            MessageBox.Show("Successfully Inserted!", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub

    Public Sub update(id As Integer, main_rs_qty As Double, openclose_qty As String)
        Dim SQ As New SQLcon
        Try
            Dim c As New class_query
            c.add_parameter("@n", 8)
            c.add_parameter("@main_rs_qty_id", id)
            c.add_parameter("@main_rs_qty", main_rs_qty)
            c.add_parameter("@open_qty", IIf(openclose_qty = "OPEN QTY", 1, 0))

            c.insert_update("proc_main_rs_qty", SQ.connection).ExecuteNonQuery()

            MessageBox.Show("Successfully Updated!", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub

    Public Sub update_sub_rs_qty(rs_id As Integer, sub_rs_qty As Double)

        Dim SQ As New SQLcon
        Dim newSQ As New SQLcon

        Try
            Dim c As New class_query
            c.add_parameter("@n", 12)
            c.add_parameter("@rs_id", rs_id)
            c.add_parameter("@sub_rs_qty", sub_rs_qty)

            c.insert_update("proc_main_rs_qty", SQ.connection).ExecuteNonQuery()
            MessageBox.Show("Succesfully Updated!", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub
    'UPDATE AND INSERT METHODS ==>

    '<== WORKER HERE
    'MAIN RS DO WORK
    Private Sub main_rs_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs)
        Dim trd As Threading.Thread
        trd = New Threading.Thread(AddressOf get_main_rs)
        trd.Start()
        trd.Join()

    End Sub
    Private Sub main_rs_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs)
        bR1 = True
    End Sub

    'MAIN RS-SUB DO WORK
    Private Sub main_rs_sub_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs)
        Dim trd As Threading.Thread
        trd = New Threading.Thread(AddressOf get_main_rs_sub)
        trd.Start()
        trd.Join()

    End Sub
    Private Sub main_rs_sub_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs)
        br2 = True
    End Sub

    'CHECKER DO WORK
    Private Sub checker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs)
        Dim trd As Threading.Thread
        trd = New Threading.Thread(AddressOf get_finished)
        trd.Start()
        trd.Join()

    End Sub
    Private Sub checker_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs)
        If cToBeDisplay = True Then
            display()
            display2()
        Else

        End If

    End Sub

    'CHECKER2 DO WORK
    Private Sub checker2_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs)
        Dim trd As Threading.Thread
        trd = New Threading.Thread(AddressOf get_finished)
        trd.Start()
        trd.Join()

    End Sub
    Private Sub checker2_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs)

        display_main_rs_with_sub()

    End Sub
    'END WORKER HERE ==>


    '<== DISPLAY HERE
    Private Sub display_main_rs_with_sub()
        For Each mainqty In cListOfMainRSQty
            Dim a(50) As String

            cRemaining_Balance = mainqty.main_rs_qty

            a(0) = mainqty.main_rs_qty_id
            a(1) = mainqty.rs_no
            a(5) = IIf(mainqty.open_close_qty = 1, "OPEN QTY", mainqty.main_rs_qty)
            a(37) = "Main RS Qty:"
            Dim lvl As New ListViewItem(a)
            lvl.BackColor = Color.Lime
            lvl.ForeColor = Color.Black
            lvl.Font = New Font(New FontFamily("Bombardier"), 12, FontStyle.Bold)

            cListOfListViewItem.Add(lvl) '==> MAIN RS (LIME)

            For Each main_rs_sub In cListOfMainRs_Sub
                If main_rs_sub.main_rs_qty_id = mainqty.main_rs_qty_id Then
                    For Each aggdata In cListOfRS
                        If aggdata.rs_id = main_rs_sub.rs_id Then
                            cTotal_Dr = 0
                            cTotal_RR = 0
                            cTotal_Dr2 = 0

                            sub_rs(aggdata.rs_id, IIf(mainqty.open_close_qty = 1, "OPEN QTY", "CLOSE QTY")) '==> SUB RS (DARK GREEN)

                        End If
                    Next

                    'BALANCE SA MAIN RS
                    Dim c(50) As String
                    c(0) = "-"
                    c(4) = "-"
                    ' c(5) = "=> " & IIf(mainqty.open_close_qty = 1, "N/A", cRemaining_Balance)
                    c(5) = "=> " & IIf(mainqty.open_close_qty = 1, "N/A", Math.Round(cRemaining_Balance, 6))
                    c(32) = cTotal_Dr2 + cTotal_Dr
                    c(37) = "Remaining Balance:"

                    Dim lvl3 As New ListViewItem(c)
                    lvl3.BackColor = Color.White
                    lvl3.ForeColor = Color.DarkGreen
                    lvl3.Font = New Font(New FontFamily("Bombardier"), 12, FontStyle.Bold)

                    cListOfListViewItem.Add(lvl3) '==> REMAINING BALANCE (WHITE)
                    cTotal_Dr = 0
                End If
            Next
        Next

        'BORDER PARA SA WALA PA NA SETUP OG MAINRS NGA ITEMS
        cTotal_RR = 0
        cTotal_Dr2 = 0
        Dim b(50) As String

        b(0) = "-"
        b(4) = "WALA PA NA SETUP NGA MGA RS NA MA BELONG SA MAIN RS"

        Dim lvl2 As New ListViewItem(b)
        lvl2.BackColor = Color.Blue
        lvl2.ForeColor = Color.White
        lvl2.Font = New Font(New FontFamily("Bombardier"), 12, FontStyle.Bold)
        cListOfListViewItem.Add(lvl2)
        cTotal_Dr2 = 0
        cTotal_RR = 0

        'MGA WALA PA NA SETUP OG MAINRS NGA ITEMS
        For Each RS In cListOfRS
            Dim i As Integer = 0

            For Each aggsub In cListOfMainRs_Sub
                If aggsub.rs_id = RS.rs_id Then
                    i += 1
                End If
            Next
            If i = 0 Then
                sub_rs(RS.rs_id)
            End If
        Next


        If cListView.InvokeRequired Then
            cListView.Invoke(Sub()
                                 cListView.Items.AddRange(cListOfListViewItem.ToArray)
                             End Sub)
        Else
            cListView.Items.AddRange(cListOfListViewItem.ToArray)
        End If

        If cListView.InvokeRequired Then
            cListView.Invoke(Sub()
                                 For Each item As ListViewItem In cListView.Items
                                     If item.BackColor = Color.DarkGreen And item.Text = CStr(rs_id_for_listfocus) Then
                                         item.Selected = True
                                         cListView.SelectedItems(0).EnsureVisible()
                                     End If
                                 Next
                             End Sub)
        Else
            For Each item As ListViewItem In cListView.Items
                If item.BackColor = Color.DarkGreen And item.Text = CStr(rs_id_for_listfocus) Then
                    item.Selected = True
                    cListView.SelectedItems(0).EnsureVisible()
                End If
            Next
        End If

    End Sub

    Private Function checkIfExistInListOfDr(dr_item_id As Integer) As Integer
        'store the dr_item_id in tempStorage
        cListOfDrItemId.ForEach(Sub(id As Integer)
                                    If id = dr_item_id Then
                                        checkIfExistInListOfDr += 1
                                        Exit Sub
                                    End If
                                End Sub)
    End Function

    Private Sub sub_rs(rs_id As Integer, Optional openclose As String = "")

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
            If rs_id = req.rs_id Then

#Region "==> RS"
                '==> RS
                Dim a(50) As String
                Dim rsProperName As String = getProperNameUsingWhId(req.wh_id)

                With req
                    Dim wh_pn_id As Integer = Utilities.ifBlankReplaceToZero(.wh_pn_id)
                    Dim properNameWithoutWhId = Results.cListOfProperNaming.Where(Function(x) x.wh_pn_id = wh_pn_id).ToList()

                    If .inout = "IN" And .type_of_purchasing = "DR" And .request_type = "" And .process = "" Then
                    Else


                        a(0) = .rs_id
                        a(1) = .rs_no
                        a(2) = .rs_date
                        a(3) = .job_order_no

#Region "PROPERNAMING"
                        a(4) = Utilities.formatProperNamingNew_RS_WS_RR_DR(wh_pn_id,
                                                                           .wh_id,
                                                                           req.rs_items,
                                                                           req.item_desc)
#End Region
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
                        a(19) = openclose
                        a(20) = .source
                        a(24) = .users
                        a(28) = .requested_by
                        a(29) = .cons_item
                        a(30) = .cons_item_desc
                        a(33) = .wh_area
                        a(37) = .qty_takeoff_desc
                        a(47) = .purpose
                        a(48) = IIf(.item_checked_log = "1990/01/01", "", .item_checked_log)
                        a(49) = .wh_pn_id

                        Dim lvl As New ListViewItem(a)
                        lvl.BackColor = Color.DarkGreen
                        lvl.ForeColor = Color.White
                        lvl.Font = New Font(New FontFamily("Bombardier"), 11, FontStyle.Bold)

                        cListOfListViewItem.Add(lvl)
                        cRemaining_Balance -= .rs_qty
                    End If
                End With
#End Region

                'RS ==> WITHDRAWAL
                If req.inout = "OUT" And req.type_of_purchasing = "WITHDRAWAL" Then

#Region "RS ==> WITHDRAWAL"
                    For Each withraw In sortws
                        Dim b(50) As String
                        If withraw.rs_id = req.rs_id And withraw.wh_id = req.wh_id Then
                            With withraw
                                b(0) = .rs_id
                                b(1) = req.rs_no
                                b(2) = .ws_date
                                b(3) = "-"
                                b(4) = $"{IIf(rsProperName = "", $"{req.item_name } - {req.item_desc }", $"{rsProperName}")}"
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
                                b(18) = req.type_of_purchasing
                                b(19) = .remarks
                                b(20) = req.source
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
                                lvl2.Font = New Font(New FontFamily("Bombardier"), 11, FontStyle.Regular)

                                cListOfListViewItem.Add(lvl2)
                            End With

                            'RS ==> WS ==> DR    
                            For Each dr In sortdr
                                Dim c(50) As String

                                Dim wh_id_from_rs As Integer = IIf(dr.wh_id = 0, 0, dr.wh_id)
                                Dim drProperName As String = getProperNameUsingWhId(wh_id_from_rs, True)

                                If withraw.ws_no = dr.ws_no And dr.rs_id = req.rs_id And req.wh_id = dr.wh_id Then
                                    With dr
                                        c(0) = .rs_id
                                        c(1) = req.rs_no
                                        c(2) = .dr_date
                                        c(3) = "-"
                                        'c(4) = $"- { req.item_desc}"
                                        c(4) = $"{IIf(drProperName = "", $"- { req.item_desc}", $"- {drProperName}")}"
                                        c(5) = "-"
                                        c(6) = .unit.ToLower
                                        c(7) = "-"
                                        c(9) = .inout
                                        c(10) = "-"
                                        c(11) = "-"
                                        c(14) = "-"
                                        c(13) = "OUT FROM: " & .wh_area
                                        c(15) = .wh_id
                                        c(16) = "-"
                                        c(19) = .remarks
                                        c(20) = req.source
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
                                        c(43) = FormatNumber(withraw.price, 2,,, TriState.False) 'FormatNumber(.price, 2,, TriState.False) update date (11/17/23)


                                        'check if dr_item_id exist in cListOfDrItemId
                                        Dim result As Integer = checkIfExistInListOfDr(.dr_items_id)
                                        If result = 0 Then
                                            Dim lvl23 As New ListViewItem(c)
                                            lvl23.BackColor = Color.LightYellow
                                            lvl23.Font = New Font(New FontFamily("Bombardier"), 11, FontStyle.Regular)

                                            cListOfListViewItem.Add(lvl23)
                                            cTotal_Dr += .dr_qty

                                            cListOfDrItemId.Add(.dr_items_id)
                                        End If



                                        'RS==> WS ==> -DR == > +DR | check if wh to wh 
                                        For Each dr2 In sortdr
                                            Dim d(50) As String

                                            Dim wh_id_from_rs2 As Integer = IIf(dr2.wh_id = 0, 0, dr2.wh_id)
                                            Dim drProperName2 As String = getProperNameUsingWhId(wh_id_from_rs2, True)

                                            If dr2.dr_no = dr.dr_no And dr2.dr_items_id <> dr.dr_items_id And dr2.ws_no = dr.ws_no And dr2.inout = "IN" Then
                                                With dr2
                                                    d(0) = dr2.rs_id
                                                    d(1) = req.rs_no
                                                    d(2) = .dr_date
                                                    d(3) = "-"
                                                    'd(4) = $"+ { dr2.items }"
                                                    d(4) = IIf(drProperName2 = "", $"+ { dr2.items }", $"+ {drProperName2}")
                                                    d(5) = "-"
                                                    d(6) = dr2.unit.ToLower
                                                    d(7) = "-"
                                                    d(9) = .inout
                                                    d(10) = "-"
                                                    d(11) = "-"
                                                    d(13) = "IN TO: " & dr2.wh_area
                                                    d(14) = "-"
                                                    d(15) = dr2.wh_id
                                                    d(16) = "-"
                                                    d(19) = .remarks
                                                    d(20) = req.source
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
                                                        lvl3.Font = New Font(New FontFamily("Bombardier"), 11, FontStyle.Regular)

                                                        cListOfListViewItem.Add(lvl3)
                                                        cListOfDrItemId.Add(dr2.dr_items_id)
                                                    End If


                                                End With
                                            End If
                                        Next
                                    End With
                                End If
                            Next
                        End If

                    Next
#End Region

                    'RS ==> OTHERS OR IN AND PURCHASEORDER
                ElseIf req.inout = "OTHERS" And req.type_of_purchasing = "PURCHASE ORDER" Or req.inout = "IN" And req.type_of_purchasing = "PURCHASE ORDER" Then

#Region "RS ==> OTHERS OR IN AND PURCHASEORDER"
                    For Each p In sortpo
                        Dim e(50) As String

                        If req.rs_id = p.rs_id Then
                            With p
                                e(0) = .rs_id
                                e(1) = req.rs_no
                                e(2) = .po_date
                                e(4) = IIf(rsProperName = "", $"- { req.rs_items}", $"- { rsProperName}")
                                'e(4) = $"- { req.rs_items}"
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
                                e(18) = req.type_of_purchasing
                                e(19) = .remarks
                                e(20) = req.source
                                e(22) = .qty
                                e(23) = "-"
                                e(24) = .users
                                e(28) = req.requested_by
                                e(29) = req.cons_item
                                e(30) = req.cons_item_desc
                                e(33) = req.wh_area
                                e(35) = .po_det_id
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
                                        f(4) = IIf(rsProperName = "", $"- { req.rs_items}", $"- { rsProperName}")
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
                                        f(20) = req.source
                                        f(23) = .qty
                                        f(24) = .users
                                        f(28) = req.requested_by
                                        f(29) = req.cons_item
                                        f(30) = req.cons_item_desc
                                        f(33) = req.wh_area
                                        f(35) = .rr_item_id
                                        f(36) = .rr_no

                                        Dim lvl5 As New ListViewItem(f)
                                        lvl5.BackColor = Color.LightPink
                                        cListOfListViewItem.Add(lvl5)

                                        cTotal_RR += .qty
                                    End With

                                    'RS ==> OTHERS/IN ==> RR ==> DR
                                    For Each dr In sortdr
                                        Dim g(50) As String

                                        Dim wh_id_from_rs2 As Integer = IIf(dr.wh_id = 0, 0, dr.wh_id)
                                        Dim drProperName2 As String = getProperNameUsingWhId(wh_id_from_rs2, True)

                                        If dr.rr_no = rr.rr_no And dr.rs_id = req.rs_id Then
                                            With dr
                                                g(0) = .rs_id
                                                g(1) = req.rs_no
                                                g(2) = .dr_date
                                                g(3) = "-"
                                                g(4) = IIf(rsProperName = "", $"- { req.rs_items}", $"- { drProperName2}")
                                                g(5) = "-"
                                                g(6) = .unit.ToLower
                                                g(9) = req.inout
                                                g(10) = "-"
                                                g(11) = "-"
                                                g(13) = req.charges
                                                g(14) = "-"
                                                g(15) = .wh_id
                                                g(16) = "-"
                                                g(19) = .remarks
                                                g(20) = req.source
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
                                                Dim result3 As Integer = checkIfExistInListOfDr(dr.dr_items_id)
                                                If result3 = 0 Then
                                                    Dim lvl6 As New ListViewItem(g)
                                                    lvl6.BackColor = Color.LightYellow
                                                    lvl6.Font = New Font(New FontFamily("Bombardier"), 11, FontStyle.Regular)
                                                    cListOfListViewItem.Add(lvl6)

                                                    cTotal_Dr += .dr_qty
                                                    cTotal_Dr2 += .dr_qty

                                                    cListOfDrItemId.Add(dr.dr_items_id)
                                                End If

                                            End With
                                        End If
                                    Next

                                    'add row for remaining balance in RR
                                    Dim gg(50) As String
                                    gg(0) = "-"
                                    gg(1) = "-"
                                    gg(4) = "-"
                                    gg(5) = "-"
                                    gg(23) = $"RR: +{cTotal_RR}"
                                    gg(32) = cTotal_Dr
                                    gg(37) = "Delivered:"

                                    Dim lvl66 As New ListViewItem(gg)
                                    lvl66.BackColor = Color.LightYellow
                                    lvl66.Font = New Font(New FontFamily("Bombardier"), 11, FontStyle.Regular)
                                    lvl66.ForeColor = Color.DarkGreen
                                    cListOfListViewItem.Add(lvl66)

                                    cTotal_Dr = 0
                                End If
                            Next
                        End If
                    Next
#End Region

                    'RS OTHERS =>= DR
                ElseIf req.inout = "OTHERS" And req.type_of_purchasing = "DR" Or
                    req.inout = "IN" And req.type_of_purchasing = "DR" And req.process <> "" And req.unit <> "" And req.type_of_request <> "" Then

#Region "RS ==> OTHERS/IN ==> DR"
                    For Each dr In sortdr
                        Dim h(50) As String
                        Dim wh_id_from_rs As Integer = IIf(dr.wh_id = 0, 0, dr.wh_id)
                        Dim drProperName As String = getProperNameUsingWhId(wh_id_from_rs, True)

                        If dr.rs_id = req.rs_id Then
                            With dr
                                h(0) = .rs_id
                                h(1) = req.rs_no
                                h(2) = .dr_date
                                h(3) = "-"
                                h(4) = IIf(drProperName = "", $"- { req.rs_items}", $"- { drProperName}")
                                h(5) = "-"
                                h(6) = .unit.ToLower
                                h(9) = req.inout
                                h(10) = "-"
                                h(11) = "-"
                                h(13) = req.charges
                                h(14) = "-"
                                h(15) = .wh_id
                                h(16) = "-"
                                h(19) = .remarks
                                h(20) = req.source
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
                                Dim result4 As Integer = checkIfExistInListOfDr(dr.dr_items_id)
                                If result4 = 0 Then
                                    Dim lvl7 As New ListViewItem(h)
                                    lvl7.BackColor = Color.LightYellow
                                    lvl7.Font = New Font(New FontFamily("Bombardier"), 11, FontStyle.Regular)
                                    cListOfListViewItem.Add(lvl7)

                                    cTotal_Dr += .dr_qty
                                    cListOfDrItemId.Add(dr.dr_items_id)
                                End If

                            End With
                        End If
                    Next

                    'add row for remaining balance in RS=>DR
                    Dim hh(50) As String
                    hh(0) = "-"
                    hh(1) = "-"
                    hh(4) = "-"
                    hh(5) = "-"
                    hh(23) = "-"
                    hh(32) = cTotal_Dr
                    hh(37) = "Delivered:"

                    Dim lvl77 As New ListViewItem(hh)
                    lvl77.BackColor = Color.LightYellow
                    lvl77.Font = New Font(New FontFamily("Bombardier"), 11, FontStyle.Regular)
                    cListOfListViewItem.Add(lvl77)

                    'cTotal_Dr = 0
#End Region

                End If
            End If
        Next

    End Sub

    'PREVIEW
    '<== display to first listview in FMainRS_New.vb
    Private Sub display()

        'SAMPLE
        'main --->  LIME
        ' - sub1 --> DARK GREEN
        ' - sub2 --> DARK GREEN
        ' - total -> WHITE


        For Each mainqty In cListOfMainRSQty
            Dim a(5) As String
            a(0) = mainqty.main_rs_qty_id
            a(1) = mainqty.rs_no
            a(2) = IIf(mainqty.open_close_qty = 0, mainqty.main_rs_qty, "♣♣♣")
            a(5) = IIf(mainqty.open_close_qty = 0, "CLOSE QTY", "OPEN QTY")

            Dim lvl As New ListViewItem(a)
            lvl.BackColor = Color.Lime
            lvl.ForeColor = Color.Black
            lvl.Font = New Font("Arial", 9, FontStyle.Bold)

            cListOfListViewItem.Add(lvl) '==> MAIN RS (LIME)

            Dim remaining_balance As Double = 0

            For Each main_rs_sub In cListOfMainRs_Sub
                If main_rs_sub.main_rs_qty_id = mainqty.main_rs_qty_id Then
                    For Each aggdata In cAgg.LISTOFRS
                        If aggdata.rs_id = main_rs_sub.rs_id Then
                            Dim b(5) As String
                            b(0) = aggdata.rs_id
                            b(1) = "-"
                            b(2) = $"{aggdata.rs_items} ({aggdata.item_name} - {aggdata.item_desc}) "
                            b(3) = aggdata.rs_qty
                            b(4) = aggdata.source

                            Dim lvl2 As New ListViewItem(b)
                            lvl2.BackColor = Color.DarkGreen
                            lvl2.ForeColor = Color.White

                            cListOfListViewItem.Add(lvl2) '==> SUB RS (DARKGREEN)

                            remaining_balance += aggdata.rs_qty
                        End If
                    Next
                End If
            Next

            '<=== GRAND TOTAL
            Dim c(4) As String
            c(0) = "-"
            c(1) = "-"
            c(2) = "Remaining Balance:"
            c(3) = IIf(mainqty.open_close_qty = 0, mainqty.main_rs_qty - remaining_balance, "N/A")

            Dim lvl3 As New ListViewItem(c)
            lvl3.BackColor = Color.White
            lvl3.ForeColor = Color.Black
            lvl3.Font = New Font("Arial", 9, FontStyle.Italic)

            remaining_balance = 0
            cListOfListViewItem.Add(lvl3) '==> END GRAND TOTAL
        Next

        If cListView.InvokeRequired Then
            cListView.Invoke(Sub()
                                 cListView.Items.AddRange(cListOfListViewItem.ToArray)
                             End Sub)
        Else
            cListView.Items.AddRange(cListOfListViewItem.ToArray)
        End If
    End Sub '==>

    '<== display to second listview in FMainRS_New.vb
    Private Sub display2()
        For Each RS In cAgg.LISTOFRS
            '<==remove tong in sa wh to wh: 
            If RS.process = "" And RS.type_of_request = "" And RS.rs_items = "" Then
                GoTo proceedhere
            End If '==>

            Dim i As Integer = 0

            '<== check if nag exist ang rs_id as cListOfMainRs_Sub
            For Each aggsub In cListOfMainRs_Sub
                If aggsub.rs_id = RS.rs_id Then
                    i += 1
                End If
            Next '==>

            '<== kung wala nag exist e display sa listview2
            If i = 0 Then
                Dim a(10) As String
                a(0) = RS.rs_id
                a(1) = RS.rs_no
                a(2) = $"{RS.rs_items} ({RS.item_name} - {RS.item_desc})"
                a(3) = RS.source
                a(4) = RS.charges
                a(5) = RS.rs_qty
                a(6) = RS.type_of_purchasing

                Dim lvl As New ListViewItem(a)
                cListOfListViewItem2.Add(lvl) '==>
            End If

proceedhere:
        Next

        If cListView2.InvokeRequired Then
            cListView2.Invoke(Sub()

                                  cListView2.Items.AddRange(cListOfListViewItem2.ToArray)
                              End Sub)
        Else
            cListView2.Items.AddRange(cListOfListViewItem2.ToArray)
        End If
    End Sub '==>
    ' END DISPLAY HERE ==>


    '<== GET DATA FROM DATABASE HERE
    Private Sub get_main_rs()

        Dim SQ As New SQLcon
        Dim newSQ As New SQLcon

        Try
            Dim c As New class_query
            c.add_parameter("@n", 5)
            c.add_parameter("@rs_no", cRS_No)

            Dim reader As SqlDataReader = c.sql_data("proc_main_rs_qty", SQ.connection)

            While reader.Read
                Dim mainrs As New main_rs
                With mainrs
                    .main_rs_qty_id = reader.Item("main_rs_qty_id").ToString
                    .main_rs_qty = reader.Item("main_rs_qty").ToString
                    .rs_no = reader.Item("rs_no").ToString
                    .open_close_qty = IIf(reader.Item("open_close").ToString = "", 0, reader.Item("open_close").ToString)

                    cListOfMainRSQty.Add(mainrs)
                End With

            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub
    Private Function get_main_rs2() As List(Of main_rs)
        get_main_rs2 = New List(Of main_rs)

        Dim SQ As New SQLcon
        Dim newSQ As New SQLcon

        Try
            Dim c As New class_query
            c.add_parameter("@n", 5)
            c.add_parameter("@rs_no", cRS_No)

            Dim reader As SqlDataReader = c.sql_data("proc_main_rs_qty", SQ.connection)

            While reader.Read
                Dim mainrs As New main_rs
                With mainrs
                    .main_rs_qty_id = reader.Item("main_rs_qty_id").ToString
                    .main_rs_qty = reader.Item("main_rs_qty").ToString
                    .rs_no = reader.Item("rs_no").ToString
                    .open_close_qty = IIf(reader.Item("open_close").ToString = "", 0, reader.Item("open_close").ToString)

                    get_main_rs2.Add(mainrs)
                End With

            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Function
    Private Sub get_main_rs_sub()

        Dim SQ As New SQLcon
        Dim newSQ As New SQLcon

        Try
            Dim c As New class_query
            c.add_parameter("@n", 6)
            c.add_parameter("@rs_no", cRS_No)

            Dim reader As SqlDataReader = c.sql_data("proc_main_rs_qty", SQ.connection)

            While reader.Read
                Dim mainrs_sub As New main_rs_sub
                With mainrs_sub
                    .main_rs_qty_id = reader.Item("main_rs_qty_id").ToString
                    .rs_id = reader.Item("rs_id").ToString

                    cListOfMainRs_Sub.Add(mainrs_sub)
                End With
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Sub
    Private Function get_main_rs_sub2() As List(Of main_rs_sub)
        get_main_rs_sub2 = New List(Of main_rs_sub)

        Dim SQ As New SQLcon
        Dim newSQ As New SQLcon

        Try
            Dim c As New class_query
            c.add_parameter("@n", 6)
            c.add_parameter("@rs_no", cRS_No)

            Dim reader As SqlDataReader = c.sql_data("proc_main_rs_qty", SQ.connection)

            While reader.Read
                Dim mainrs_sub As New main_rs_sub
                With mainrs_sub
                    .main_rs_qty_id = reader.Item("main_rs_qty_id").ToString
                    .rs_id = reader.Item("rs_id").ToString

                    get_main_rs_sub2.Add(mainrs_sub)
                End With
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try
    End Function
    Private Function get_old_main_rs_qty() As Double

        Dim SQ As New SQLcon
        Dim newSQ As New SQLcon

        Try
            Dim c As New class_query
            c.add_parameter("@n", 13)
            c.add_parameter("@rs_no", cRS_No)

            Dim reader As SqlDataReader = c.sql_data("proc_main_rs_qty", SQ.connection)

            While reader.Read
                get_old_main_rs_qty = IIf(reader.Item("main_rs_qty").ToString = "", 0, reader.Item("main_rs_qty").ToString)
                cOpenCloseQty = reader.Item("open_qty").ToString
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQ.connection.Close()
        End Try

    End Function
    Private Sub get_finished()
        While True
            Threading.Thread.Sleep(100)
            If bR1 = True And br2 = True Then
                Exit While
            End If
        End While
    End Sub

    ' END GET DATA FROM DATABASE HERE ==>

    '<== CLASS HERE
    Public Class main_rs
        Public Property main_rs_qty_id As Integer
        Public Property main_rs_qty As Double
        Public Property rs_no As String
        Public Property open_close_qty As Double
    End Class

    Public Class main_rs_sub
        Public Property rs_id As Integer
        Public Property main_rs_qty_id As Integer

    End Class
    ' END CLASS HERE ==>
End Class
