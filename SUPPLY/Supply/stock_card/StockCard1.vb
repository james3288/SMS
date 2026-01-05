Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.ComponentModel
Imports System.Windows.Markup

Public Class StockCard1
    Dim rs_id_count As Integer
    Dim counter1 As Integer
    Dim thread, thread1 As System.Threading.Thread
    Dim b As Integer
    Dim beginning_balance1, beginning_balance2 As Decimal
    Dim sortColumn As Integer = -1
    Dim abortsearching As Boolean
    Dim crs_data As New Class_SC_Hauling.SC_Hauling_Data

    Dim trd1, trd2, trd3, trd4, trd5 As Threading.Thread

    Private rs As New Model._Mod_RS
    Private po As New Model._Mod_Purchase_Order
    Private ws As New Model._Mod_Withdrawal
    Private rr As New Model._Mod_RR

    Private cListOfrs As New List(Of Model._Mod_RS.rs_fields)
    Private cListOfpo As New List(Of Model._Mod_Purchase_Order.Purchase_Order_Field)
    Private cListOfws As New List(Of Model._Mod_Withdrawal.Withdrawal_Fields)
    Private cListOfrr As New List(Of Model._Mod_RR.rr_fields)

    Private cListOfStockCard As New List(Of stockcard_fields)
    Private cListOfListView As New List(Of ListViewItem)
    Public cWh_id As Integer

    Private cListOfRsId As New List(Of Integer)
    Private cListOfListViewItem As New List(Of ListViewItem)
    Private poModel, wsModel, rrModel, rsModel, prevBalanceModel, resultModel As New ModelNew.Model
    Private cPrevBalance As Double
    Private cListOfStockCardNew As New List(Of stockcard_fields)
    Dim prevBalance As Double

    Dim cBgWorkerChecker As Timer
    Private Class stockcard_fields
        Public Property rs_id As Integer
        Public Property stDate As DateTime
        Public Property rs_no As String
        Public Property invoice As String
        Public Property rr_no As String
        Public Property ws_no As String
        Public Property supp_recepient As String
        Public Property inout_qty As Decimal
        Public Property out_qty As Decimal
        Public Property in_qty As Decimal
        Public Property balance As Decimal
        Public Property inout As String
        Public Property remarks As String
        Public Property status As String

    End Class
    Public Sub new_stockcard_search()

        lvlStockCard.Items.Clear()
        cListOfrs.Clear()
        cListOfpo.Clear()
        cListOfrr.Clear()
        cListOfws.Clear()
        cListOfStockCard.Clear()
        cListOfListView.Clear()

        BackgroundWorker1.WorkerSupportsCancellation = True
        BackgroundWorker1.RunWorkerAsync()


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        'b = 0
        ''dtgStockCard.Rows.Clear()
        ''dtgStockCard.Visible = False
        'Label4.Text = 0
        'lvlStockCard.Items.Clear()
        'lvlStockCard.Visible = False
        'Panel8.Visible = False

        ''beginning_balance1 = get_beginning_balance(TextBox1.Text)


        ''beginning_balance1 = beginning_balance2
        ''load_rs_rs_id1(5, TextBox1.Text, "")


        ''********DONT DETE******
        'load_stock_card_using_stored()
        'thread = New System.Threading.Thread(AddressOf search_using_rs1)
        'thread.Start()
        'Timer1.Start()
        ''***********************


        ''With crs_data

        ''    .item_name = cmbItemName.Text
        ''    .item_desc = cmbItem_desc.Text
        ''    .classification = cmbclassification.Text
        ''    .date_from = Date.Parse(dtpfrom.Text)
        ''    .date_to = Date.Parse(dtpto.Text)
        ''    .lvl = lvlStockCard
        ''    .user_id = pub_user_id
        ''    .wh_area = cmbWareHouse.Text

        ''End With

        ''Dim c_search As New Class_SC_Hauling(crs_data)

        ''Panel7.Visible = True
        ''lblRecords.Text = "Initializing balance..."
        ''thread = New System.Threading.Thread(AddressOf c_search.stock_card)
        ''thread.Start()
        ''Timer1.Start()

        Dim ee As New StockCardModel

        ee._initialize(186, lvlStockCard, Label4, "listview")
        ee.loadStockcard()

    End Sub


    Public Sub loadStockcard(wh_id As Integer)
        cListOfStockCardNew.Clear()
        cListOfListViewItem.Clear()

        rsModel.clearParameter()
        poModel.clearParameter()
        wsModel.clearParameter()
        rrModel.clearParameter()
        prevBalanceModel.clearParameter()
        Panel7.Visible = True


        Dim cv1 As New ColumnValues
        cv1.add("search", wh_id)
        cv1.add("searchby", "Search by wh_id")

        _initializing(cCol.forRequisition,
                        cv1.getValues(),
                        rsModel,
                        stockCardBgWorker)

        _initializing(cCol.forPurchaseOrder,
                        cv1.getValues(),
                        poModel,
                        stockCardBgWorker)

        _initializing(cCol.forWithdrawal,
                      cv1.getValues(),
                      wsModel,
                      stockCardBgWorker)

        _initializing(cCol.forReceiving,
                      cv1.getValues(),
                      rrModel,
                      stockCardBgWorker)

        _initializing(cCol.forPrevBalance,
                        cv1.getValues(),
                        prevBalanceModel,
                        stockCardBgWorker)

        cBgWorkerChecker = BgWorkersCheckerFn(AddressOf SuccessfullyDone, stockCardBgWorker)

    End Sub

    Private Sub SuccessfullyDone()

        cListOfPurchaseOrder = TryCast(poModel.cData, List(Of PropsFields.purchase_order_props_fields))
        cListOfWithdrawal = TryCast(wsModel.cData, List(Of PropsFields.withdrawal_props_fields))
        cListOfReceiving = TryCast(rrModel.cData, List(Of PropsFields.receiving_props_fields))
        cListOfRequisition = TryCast(rsModel.cData, List(Of PropsFields.rs_props_fields))
        cPrevBalance = CType(prevBalanceModel.cData, Double)

        PreviewResult()

        Panel7.Visible = False

    End Sub

    Private Function getStockCardDatas() As Dictionary(Of String, Object)
        getStockCardDatas = New Dictionary(Of String, Object)

        'rs 
        For Each rowRs In cListOfRequisition
            Dim stf As New stockcard_fields

            With stf
                'for po
                If rowRs.inout = "IN" Then
                    For Each rowPo In cListOfPurchaseOrder
                        If rowRs.rs_id = rowPo.rs_id Then

                            'for receiving
                            For Each rowRr In cListOfReceiving
                                If rowRr.rs_id = rowRs.rs_id Then
                                    'add rows
                                    rowReceiving(rowRr, rowRs.inout)
                                End If
                            Next
                        End If

                    Next

                    'for ws
                ElseIf rowRs.inout = "OUT" Then
                    For Each rowWs In cListOfWithdrawal
                        If rowWs.rs_id = rowRs.rs_id Then
                            'if withdrawn
                            If Not rowWs.withdrawn_id = 0 Then
                                'add rows
                                rowWithdrawal(rowWs, rowRs.inout)
                            End If

                        End If
                    Next
                    'for cash with rr
                ElseIf rowRs.type_of_purchasing.ToUpper() = "CASH WITH RR" Then
                    For Each rowRr In cListOfReceiving
                        If rowRr.rs_id = rowRs.rs_id Then
                            'add rows
                        End If
                    Next
                End If
            End With
        Next

        'result 
        Dim result = From aa In cListOfStockCardNew
                     Select aa Order By aa.stDate, aa.rs_id Ascending

        Dim stockCardDatas As New List(Of stockcard_fields)
        Dim remainingBalance As Decimal = cPrevBalance

        For Each rowResult In result
            Dim a(20) As String
            Dim sf As New stockcard_fields

            With rowResult

                If .inout = "OUT" Then
                    remainingBalance -= .out_qty
                ElseIf .inout = "IN" Then
                    remainingBalance += .in_qty
                End If

                sf.rs_id = .rs_id
                sf.stDate = .stDate
                sf.rs_no = .rs_no
                sf.rr_no = .rr_no
                sf.ws_no = .ws_no
                sf.supp_recepient = .supp_recepient
                sf.in_qty = .in_qty
                sf.out_qty = .out_qty
                sf.balance = remainingBalance
                sf.rs_id = .rs_id
                sf.inout = .inout

                stockCardDatas.Add(sf)
            End With
        Next

        getStockCardDatas.Add("datas", stockCardDatas)
        getStockCardDatas.Add("remainingBalance", remainingBalance)

        Return getStockCardDatas
    End Function

    Private Sub PreviewResult()

        lvlStockCard.Items.Clear()
        Dim id As Integer

        Dim stockCardDic As New Dictionary(Of String, Object)
        stockCardDic = getStockCardDatas()

        For Each rowResult As stockcard_fields In stockCardDic("datas")
            Dim a(20) As String

            With rowResult

                a(0) = .rs_id
                a(2) = .stDate
                a(3) = .rs_no
                a(5) = .rr_no
                a(6) = .ws_no
                a(7) = .supp_recepient
                a(8) = IIf(.in_qty = 0, "-", .in_qty)
                a(9) = IIf(.out_qty = 0, "-", .out_qty)
                a(10) = .balance
                a(13) = .rs_id
                a(14) = .inout

                Dim lvl As New ListViewItem(a)
                If .inout = "OUT" Then
                    lvl.BackColor = Color.LightGreen
                ElseIf .inout = "IN" Then
                    lvl.BackColor = Color.LightYellow
                End If
                cListOfListViewItem.Add(lvl)
                id = .rs_id
            End With
        Next

        Label4.Text = cPrevBalance
        lvlStockCard.Items.AddRange(cListOfListViewItem.ToArray)

        listfocus(lvlStockCard, id)
    End Sub

    Private Sub rowReceiving(data As PropsFields.receiving_props_fields,
                             Optional inout As String = "")


        Dim c As New stockcard_fields
        With c
            .rs_id = data.rs_id
            .stDate = data.date_received
            .rs_no = data.rs_no
            .rr_no = data.rr_no
            .supp_recepient = data.supplier
            .inout_qty = data.rr_qty
            .in_qty = data.rr_qty
            .inout = inout
            .rs_id = data.rs_id
        End With

        cListOfStockCardNew.Add(c)
    End Sub

    Private Sub rowWithdrawal(data As PropsFields.withdrawal_props_fields,
                              Optional inout As String = "")


        Dim c As New stockcard_fields
        With c
            .rs_id = data.rs_id
            .stDate = data.ws_date
            .rs_no = data.rs_no
            .ws_no = data.ws_no
            .supp_recepient = data.charges
            .inout_qty = data.ws_qty
            .out_qty = data.ws_qty
            .inout = inout
            .balance = prevBalance
            .rs_id = data.rs_id
        End With

        cListOfStockCardNew.Add(c)
    End Sub
    Private Sub rs_threading()

        rs.clear_parameter()
        rs.parameter("@n", 1)
        rs.parameter("@wh_id", cWh_id)

        rs.cStoreProcedureName = "PROC_STOCKCARD_SUPPLY"
        cListOfrs = rs.LISTOFRS

    End Sub
    Private Sub po_threading()

        po.clear_parameter()
        po.parameter("@n", 2)
        po.parameter("@wh_id", cWh_id)
        po.parameter("@typeofpurchasing", "PURCHASE ORDER")

        po.cStoreProcedureName = "PROC_STOCKCARD_SUPPLY"
        cListOfpo = po.LISTOFPURCHASEORDER


    End Sub
    Private Sub ws_threading()

        ws.clear_parameter()
        ws.parameter("@n", 3)
        ws.parameter("@wh_id", cWh_id)

        ws.cStoreProcedureName = "PROC_STOCKCARD_SUPPLY"
        cListOfws = ws.LISTOFWITHDRAWAL


    End Sub
    Private Sub rr_threading()

        rr.clear_parameter()
        rr.parameter("@n", 4)
        rr.parameter("@wh_id", cWh_id)

        rr.cStoreProcedureName = "PROC_STOCKCARD_SUPPLY"
        cListOfrr = rr.LISTOFRR


    End Sub

    Private Function get_wh_item_info(wh_id As Integer) As String
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_execute_tempstockcard4", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure
            newCMD.Parameters.AddWithValue("@n", 9)
            newCMD.Parameters.AddWithValue("@wh_id", wh_id)
            newDR = newCMD.ExecuteReader

            While newDR.Read
                get_wh_item_info = newDR.Item("item_info").ToString
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Function
    Private Sub load_stock_card_using_stored()
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim wh_id As Integer = get_wh_id_using_wharea(cmbItemName.Text, cmbItem_desc.Text, cmbWareHouse.Text, cmbclassification.Text)

        lblitem_name.Text = get_wh_item_info(wh_id)

        ListBox1.Items.Clear()

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_execute_tempstockcard4", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 7)
            newCMD.Parameters.AddWithValue("@wh_id", wh_id)
            newCMD.Parameters.AddWithValue("@datefrom", Date.Parse(dtpfrom.Text))
            newCMD.Parameters.AddWithValue("@dateto", Date.Parse(dtpto.Text))
            newCMD.CommandTimeout = 100
            newDR = newCMD.ExecuteReader
            Dim a(22) As String

            While newDR.Read
                'Dim sDate As DateTime
                'If newDR.Item("date_received").ToString = "" Then
                '    sDate = Date.Parse("1990-01-01")
                'Else
                '    sDate = newDR.Item("date_received").ToString
                'End If

                'a(0) = newDR.Item("rs_id").ToString
                'a(2) = sDate
                'a(3) = newDR.Item("rs_no").ToString
                'a(6) = newDR.Item("ws_no").ToString
                'a(7) = "" 'newDR.Item("CHARGES").ToString

                'If newDR.Item("IN_OUT").ToString = "OUT" Then
                '    a(8) = ""
                '    a(9) = newDR.Item("qty").ToString
                'ElseIf newDR.Item("IN_OUT").ToString = "IN" Then
                '    a(8) = newDR.Item("qty").ToString
                '    a(9) = ""
                'End If

                'a(10) = newDR.Item("balance").ToString
                'a(13) = newDR.Item("rs_id").ToString

                'Dim lvl As New ListViewItem(a)
                'lvlStockCard.Items.Add(lvl)
                ListBox1.Items.Add(newDR.Item("rs_id".ToString))
                rs_id_count += 1
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            lblRecords.Text = rs_id_count.ToString("N0") & " record(s) found..."
            newSQ.connection.Close()
        End Try


    End Sub
    Private Function get_beginning_balance(wh_id As Integer) As Decimal
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_execute_tempstockcard4", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 6)
            newCMD.Parameters.AddWithValue("@wh_id", wh_id)
            newDR = newCMD.ExecuteReader
            Dim a(10) As String

            While newDR.Read
                get_beginning_balance = newDR.Item("balance").ToString
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try


    End Function

    Private Function get_beginning_balance1(wh_id As Integer) As Decimal
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_execute_tempstockcard4", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 8)
            newCMD.Parameters.AddWithValue("@wh_id", wh_id)
            newCMD.Parameters.AddWithValue("@datefrom", Date.Parse(dtpfrom.Text).AddDays(-1))
            newDR = newCMD.ExecuteReader
            Dim a(10) As String

            While newDR.Read
                get_beginning_balance1 = newDR.Item("balance").ToString
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try


    End Function
    Public Sub search_using_rs1()
        Try
            Dim rs_percent As Integer
            Dim n As Integer
            'If Integer.TryParse((rs_id_count / 100), n) Then
            '    rs_percent = rs_id_count / 100
            'Else
            '    rs_percent = 1
            'End If

            rs_percent = 1

            If ProgressBar1.InvokeRequired Then
                ProgressBar1.Invoke(Sub()
                                        ProgressBar1.Value = 0
                                        'ProgressBar1.Maximum = (rs_percent * 100)
                                        ProgressBar1.Maximum = rs_id_count
                                    End Sub)

            Else
                ProgressBar1.Value = 0
                'ProgressBar1.Maximum = (rs_percent * 100)
                ProgressBar1.Maximum = rs_id_count
            End If

            For i = 0 To ListBox1.Items.Count - 1

                load_rs_new2(ListBox1.Items(i))

                If ProgressBar1.InvokeRequired Then
                    ProgressBar1.Invoke(Sub()
                                            If ProgressBar1.Value = rs_id_count Then ' 100 Then
                                            Else
                                                ProgressBar1.Value += CDbl(rs_percent)
                                            End If

                                        End Sub)
                Else
                    ProgressBar1.Value += CDbl(rs_percent)
                End If

            Next

            If ProgressBar1.InvokeRequired Then
                ProgressBar1.Invoke(Sub() ProgressBar1.Value = ProgressBar1.Maximum)
            Else
                ProgressBar1.Value = ProgressBar1.Maximum
            End If

            rs_id_count = 0
            counter1 = 0
            'thread.Abort()
        Catch ex As Exception
            If TypeOf ex Is System.Threading.ThreadAbortException Then
                MessageBox.Show("Search Aborted..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                'If FlowLayoutPanel1.InvokeRequired Then
                '    FlowLayoutPanel1.Invoke(Sub() FlowLayoutPanel1.Enabled = True)
                'Else
                '    FlowLayoutPanel1.Enabled = True
                'End If

                Return
                Exit Sub
            End If

            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub search_using_rs2()
        Try
            Dim rs_percent As Integer
            Dim n As Integer
            'If Integer.TryParse((rs_id_count / 100), n) Then
            '    rs_percent = rs_id_count / 100
            'Else
            '    rs_percent = 1
            'End If

            rs_percent = 1

            If ProgressBar1.InvokeRequired Then
                ProgressBar1.Invoke(Sub()
                                        ProgressBar1.Value = 0
                                        'ProgressBar1.Maximum = (rs_percent * 100)
                                        ProgressBar1.Maximum = rs_id_count
                                    End Sub)

            Else
                ProgressBar1.Value = 0
                'ProgressBar1.Maximum = (rs_percent * 100)
                ProgressBar1.Maximum = rs_id_count
            End If

            For i = 0 To ListBox2.Items.Count - 1

                load_rs_new3(ListBox2.Items(i))

                If ProgressBar1.InvokeRequired Then
                    ProgressBar1.Invoke(Sub()
                                            If ProgressBar1.Value = rs_id_count Then ' 100 Then
                                            Else
                                                ProgressBar1.Value += CDbl(rs_percent)
                                            End If

                                        End Sub)
                Else
                    ProgressBar1.Value += CDbl(rs_percent)
                End If

            Next

            If ProgressBar1.InvokeRequired Then
                ProgressBar1.Invoke(Sub() ProgressBar1.Value = ProgressBar1.Maximum)
            Else
                ProgressBar1.Value = ProgressBar1.Maximum
            End If

            rs_id_count = 0
            counter1 = 0
            'thread.Abort()
        Catch ex As Exception
            If TypeOf ex Is System.Threading.ThreadAbortException Then
                MessageBox.Show("Search Aborted..", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                'If FlowLayoutPanel1.InvokeRequired Then
                '    FlowLayoutPanel1.Invoke(Sub() FlowLayoutPanel1.Enabled = True)
                'Else
                '    FlowLayoutPanel1.Enabled = True
                'End If

                Return
                Exit Sub
            End If

            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub



    Private Sub load_rs_new2(rs_id As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_execute_tempstockcard4", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 1)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)

            newDR = newCMD.ExecuteReader
            Dim a(50) As String

            While newDR.Read

                If newDR.Item("type_of_purchasing").ToString = "DR" Then
                    If newDR.Item("IN_OUT").ToString = "OTHERS" Or newDR.Item("IN_OUT").ToString = "IN" Then

                    Else
                        GoTo proceedhere
                    End If
                End If

                Dim date_needed As DateTime
                If IsDate(newDR.Item("date_needed").ToString) = True Then
                    date_needed = newDR.Item("date_needed").ToString
                Else
                    date_needed = "1990-01-01"
                End If

                counter1 += 1

                'total_rs_qty += a(5)

                'thread = New System.Threading.Thread(AddressOf load_ws)
                'thread.Start(a(0))         

                a(2) = Format(Date.Parse(newDR.Item("date_req").ToString), "MM/dd/yyyy")
                a(3) = newDR.Item("rs_no").ToString

                'If dtgStockCard.InvokeRequired Then
                '    dtgStockCard.Invoke(Sub()
                '                            dtgStockCard.Rows.Add(a)
                '                            dtgStockCard.Rows(b).DefaultCellStyle.BackColor = Color.DarkGreen
                '                            dtgStockCard.Rows(b).DefaultCellStyle.ForeColor = Color.White
                '                            dtgStockCard.Rows(b).DefaultCellStyle.Font = New Font("arial", 12, FontStyle.Bold)
                '                        End Sub)
                'Else
                '    dtgStockCard.Rows.Add(a)
                '    dtgStockCard.Rows(b).DefaultCellStyle.BackColor = Color.DarkGreen
                '    dtgStockCard.Rows(b).DefaultCellStyle.ForeColor = Color.White
                '    dtgStockCard.Rows(b).DefaultCellStyle.Font = New Font("arial", 12, FontStyle.Bold)
                'End If

                b += 1

                If Label7.InvokeRequired Then
                    Label7.Invoke(Sub() Label7.Text = a(2))
                Else
                    Label7.Text = a(2)
                End If

                If newDR.Item("type_of_purchasing").ToString = "CASH WITH RR" Then
                    load_rr1(newDR.Item("rs_id").ToString)
                Else
                    load_po_ws(newDR.Item("rs_id").ToString, newDR.Item("IN_OUT").ToString)
                End If
proceedhere:

            End While

        Catch ex As Exception
            If TypeOf ex Is System.Threading.ThreadAbortException Then
                MessageBox.Show("Search Aborted.. load_rs_new2", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
                Exit Sub
            End If

            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Private Sub load_rs_new3(rs_id As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader


        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_execute_tempstockcard4", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 1)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)

            newDR = newCMD.ExecuteReader
            Dim a(50) As String

            While newDR.Read

                If newDR.Item("type_of_purchasing").ToString = "DR" Then
                    If newDR.Item("IN_OUT").ToString = "OTHERS" Or newDR.Item("IN_OUT").ToString = "IN" Then

                    Else
                        GoTo proceedhere
                    End If
                End If

                Dim date_needed As DateTime
                If IsDate(newDR.Item("date_needed").ToString) = True Then
                    date_needed = newDR.Item("date_needed").ToString
                Else
                    date_needed = "1990-01-01"
                End If

                counter1 += 1

                'total_rs_qty += a(5)

                'thread = New System.Threading.Thread(AddressOf load_ws)
                'thread.Start(a(0))         

                'a(2) = Format(Date.Parse(newDR.Item("date_req").ToString), "MM/dd/yyyy")
                'a(3) = newDR.Item("rs_no").ToString

                b += 1

                If Label7.InvokeRequired Then
                    Label7.Invoke(Sub() Label7.Text = a(4))
                Else
                    Label7.Text = a(4)
                End If

                If newDR.Item("type_of_purchasing").ToString = "CASH WITH RR" Then
                    load_rr2(newDR.Item("rs_id").ToString)
                Else
                    load_po_ws1(newDR.Item("rs_id").ToString)
                End If
proceedhere:

            End While

        Catch ex As Exception
            If TypeOf ex Is System.Threading.ThreadAbortException Then
                MessageBox.Show("Search Aborted.. load_rs_new2", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
                Exit Sub
            End If

            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub
    Private Sub load_po_ws(rs_id As Integer, inout As String)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_execute_tempstockcard4", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            If inout = "OUT" Then
                newCMD.Parameters.AddWithValue("@n", 10) '3
            Else
                newCMD.Parameters.AddWithValue("@n", 3)
            End If

            newCMD.Parameters.AddWithValue("@rs_id", rs_id)

            If dtpfrom.InvokeRequired Then
                dtpfrom.Invoke(Sub()
                                   newCMD.Parameters.AddWithValue("@datefrom", Date.Parse(dtpfrom.Text))
                                   newCMD.Parameters.AddWithValue("@dateto", Date.Parse(dtpto.Text))
                               End Sub)
            Else
                newCMD.Parameters.AddWithValue("@datefrom", Date.Parse(dtpfrom.Text))
                newCMD.Parameters.AddWithValue("@dateto", Date.Parse(dtpto.Text))
            End If


            newDR = newCMD.ExecuteReader
            Dim a(50) As String

            While newDR.Read
                'DR-IN
                If newDR.Item("type_of_purchasing").ToString = "DR" And newDR.Item("IN_OUT").ToString = "IN" Then
                    GoTo proceedhere1
                End If

                'IN-PO
                If newDR.Item("IN_OUT").ToString = "IN" And newDR.Item("type_of_purchasing").ToString = "PURCHASE ORDER" Then
                    GoTo proceedhere
                End If

                'IN-CASH
                If newDR.Item("IN_OUT").ToString = "IN" And newDR.Item("type_of_purchasing").ToString = "CASH" Then
                    GoTo proceedhere
                End If

                'OTHERS-PO
                If newDR.Item("IN_OUT").ToString = "OTHERS" And newDR.Item("type_of_purchasing").ToString = "PURCHASE ORDER" Then
                    GoTo proceedhere1
                End If

                'OTHERS-CASH
                If newDR.Item("IN_OUT").ToString = "OTHERS" And newDR.Item("type_of_purchasing").ToString = "CASH" Then
                    GoTo proceedhere1
                End If


                If newDR.Item("IN_OUT").ToString = "OUT" Then
                    If newDR.Item("withdrawn_status").ToString = "withdrawn" Then
                        'padayon
                    Else
                        GoTo proceedhere1
                    End If
                End If

                Dim po_date As DateTime
                If newDR.Item("date_req").ToString = "" Then
                    po_date = Date.Parse("1990-01-01")
                Else
                    po_date = newDR.Item("po_date").ToString
                End If


                a(0) = newDR.Item("rs_id").ToString
                a(2) = po_date
                a(3) = newDR.Item("rs_no").ToString
                a(6) = newDR.Item("ws_no").ToString
                a(7) = newDR.Item("CHARGES").ToString
                a(9) = newDR.Item("po_qty").ToString
                a(13) = newDR.Item("rs_id").ToString
                a(14) = newDR.Item("IN_OUT").ToString

                'beginning_balance1 = beginning_balance1 - CDec(newDR.Item("po_qty").ToString)
                'a(10) = beginning_balance1

                'a(10) = newDR.Item("balance").ToString

                If lvlStockCard.InvokeRequired Then
                    lvlStockCard.Invoke(Sub()
                                            ' dtgStockCard.Rows.Add(a)
                                            Dim lvl As New ListViewItem(a)
                                            lvl.BackColor = Color.LightGreen
                                            lvlStockCard.Items.Add(lvl)
                                        End Sub)
                Else
                    'dtgStockCard.Rows.Add(a)
                    Dim lvl As New ListViewItem(a)
                    lvl.BackColor = Color.LightGreen
                    lvlStockCard.Items.Add(lvl)
                End If

                b += 1

                'lvlrequisitionlist.Items(counter1).BackColor = Color.LightGreen
                'lvlrequisitionlist.Items(counter1).ForeColor = Color.Black
                'lvlrequisitionlist.Items(counter1).Font = New Font(New FontFamily("Arial"), 10, FontStyle.Bold)

                counter1 += 1

proceedhere:

                If Label7.InvokeRequired Then
                    Label7.Invoke(Sub() Label7.Text = newDR.Item("rs_id").ToString & " " & newDR.Item("items").ToString)
                Else
                    Label7.Text = newDR.Item("rs_id").ToString & " " & newDR.Item("items").ToString
                End If

                'load_dr5(a(0), a(36))
                'load_dr6(a(0), a(36), a(15))
                load_rr(newDR.Item("po_det_id").ToString)

proceedhere1:

            End While

        Catch ex As Exception
            If TypeOf ex Is System.Threading.ThreadAbortException Then
                Return
                Exit Sub
            End If

            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub

    Private Sub load_po_ws1(rs_id As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_execute_tempstockcard4", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 3)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)

            newDR = newCMD.ExecuteReader
            Dim a(50) As String

            While newDR.Read
                If newDR.Item("type_of_purchasing").ToString = "DR" And newDR.Item("IN_OUT").ToString = "IN" Then
                    GoTo proceedhere
                End If

                If newDR.Item("type_of_purchasing").ToString = "CASH" Or newDR.Item("type_of_purchasing").ToString = "PURCHASE ORDER" Then
                    GoTo proceedhere
                End If


                If newDR.Item("IN_OUT").ToString = "OUT" Then
                    If newDR.Item("withdrawn_status").ToString = "withdrawn" Then
                        'padayon
                    Else
                        GoTo proceedhere
                    End If
                End If

                Dim po_date As DateTime
                If newDR.Item("date_req").ToString = "" Then
                    po_date = Date.Parse("1990-01-01")
                Else
                    po_date = newDR.Item("po_date").ToString
                End If

                If po_date >= Date.Parse(dtpfrom.Text) Then
                    GoTo proceedhere
                End If

                a(0) = newDR.Item("rs_id").ToString
                a(2) = po_date
                a(3) = newDR.Item("rs_no").ToString
                a(6) = newDR.Item("ws_no").ToString
                a(7) = newDR.Item("CHARGES").ToString
                a(9) = newDR.Item("po_qty").ToString
                a(13) = newDR.Item("rs_id").ToString

                'beginning_balance2 = beginning_balance2 - CDec(newDR.Item("po_qty").ToString)
                'a(10) = beginning_balance2

                If lvlStockCard.InvokeRequired Then
                    lvlStockCard.Invoke(Sub()
                                            ' dtgStockCard.Rows.Add(a)
                                            Dim lvl As New ListViewItem(a)
                                            lvl.BackColor = Color.LightGreen
                                            lvlStockCard.Items.Add(lvl)
                                        End Sub)
                Else
                    'dtgStockCard.Rows.Add(a)
                    Dim lvl As New ListViewItem(a)
                    lvl.BackColor = Color.LightGreen
                    lvlStockCard.Items.Add(lvl)
                End If

                b += 1

                If Label7.InvokeRequired Then
                    Label7.Invoke(Sub() Label7.Text = newDR.Item("items").ToString)
                Else
                    Label7.Text = newDR.Item("items").ToString
                End If

                counter1 += 1

proceedhere:
                load_rr3(newDR.Item("po_det_id").ToString)

            End While

        Catch ex As Exception
            If TypeOf ex Is System.Threading.ThreadAbortException Then
                Return
                Exit Sub
            End If

            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub
    Private Sub load_rr(po_det_id As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_execute_tempstockcard4", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 4)
            newCMD.Parameters.AddWithValue("@po_det_id", po_det_id)
            newCMD.CommandTimeout = 100

            newDR = newCMD.ExecuteReader
            Dim a(45) As String

            While newDR.Read

                Dim date_received As DateTime
                If newDR.Item("date_received").ToString = "" Then
                    date_received = Date.Parse("1990-01-01")
                Else
                    date_received = newDR.Item("date_received").ToString
                End If


                a(0) = newDR.Item("rs_id").ToString
                a(2) = date_received
                a(3) = newDR.Item("rs_no").ToString
                a(4) = newDR.Item("invoice_no").ToString
                a(5) = newDR.Item("rr_no").ToString
                a(7) = newDR.Item("SUPPLIER").ToString
                a(8) = newDR.Item("qty").ToString
                a(13) = newDR.Item("rs_id").ToString
                a(14) = newDR.Item("IN_OUT").ToString
                'beginning_balance1 = beginning_balance1 + CDec(newDR.Item("qty").ToString)
                'a(10) = beginning_balance1
                a(10) = CDec(newDR.Item("balance").ToString)

                If lvlStockCard.InvokeRequired Then
                    lvlStockCard.Invoke(Sub()
                                            'dtgStockCard.Rows.Add(a)
                                            Dim lvl As New ListViewItem(a)
                                            lvl.BackColor = Color.LightYellow
                                            lvlStockCard.Items.Add(lvl)
                                        End Sub)
                Else
                    'dtgStockCard.Rows.Add(a)
                    Dim lvl As New ListViewItem(a)
                    lvl.BackColor = Color.LightYellow
                    lvlStockCard.Items.Add(lvl)
                End If

                b += 1

                If Label7.InvokeRequired Then
                    Label7.Invoke(Sub() Label7.Text = date_received)
                Else
                    Label7.Text = date_received
                End If

            End While

        Catch ex As Exception
            If TypeOf ex Is System.Threading.ThreadAbortException Then
                Return
                Exit Sub
            End If

            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub
    Private Sub load_rr3(po_det_id As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_execute_tempstockcard4", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 4)
            newCMD.Parameters.AddWithValue("@po_det_id", po_det_id)
            newCMD.CommandTimeout = 100

            newDR = newCMD.ExecuteReader
            Dim a(45) As String

            While newDR.Read

                Dim date_received As DateTime
                If newDR.Item("date_received").ToString = "" Then
                    date_received = Date.Parse("1990-01-01")
                Else
                    date_received = newDR.Item("date_received").ToString
                End If

                If date_received >= Date.Parse(dtpfrom.Text) Then
                    GoTo proceedhere
                End If

                a(0) = newDR.Item("rs_id").ToString
                a(2) = date_received
                a(3) = newDR.Item("rs_no").ToString
                a(4) = newDR.Item("invoice_no").ToString
                a(5) = newDR.Item("rr_no").ToString
                a(7) = newDR.Item("SUPPLIER").ToString
                a(8) = newDR.Item("qty").ToString
                a(13) = newDR.Item("rs_id").ToString

                'beginning_balance1 = beginning_balance1 + CDec(newDR.Item("qty").ToString)
                'a(10) = beginning_balance1

                If lvlStockCard.InvokeRequired Then
                    lvlStockCard.Invoke(Sub()
                                            'dtgStockCard.Rows.Add(a)
                                            Dim lvl As New ListViewItem(a)
                                            lvl.BackColor = Color.LightYellow
                                            lvlStockCard.Items.Add(lvl)
                                        End Sub)
                Else
                    'dtgStockCard.Rows.Add(a)
                    Dim lvl As New ListViewItem(a)
                    lvl.BackColor = Color.LightYellow
                    lvlStockCard.Items.Add(lvl)
                End If

                b += 1

                If Label7.InvokeRequired Then
                    Label7.Invoke(Sub() Label7.Text = a(4))
                Else
                    Label7.Text = a(4)
                End If

proceedhere:

            End While

        Catch ex As Exception
            If TypeOf ex Is System.Threading.ThreadAbortException Then
                Return
                Exit Sub
            End If

            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub
    Private Sub load_rr1(rs_id As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_execute_tempstockcard4", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 2)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)
            newCMD.CommandTimeout = 100

            newDR = newCMD.ExecuteReader
            Dim a(45) As String

            While newDR.Read

                Dim date_received As DateTime
                If newDR.Item("date_received").ToString = "" Then
                    date_received = Date.Parse("1990-01-01")
                Else
                    date_received = newDR.Item("date_received").ToString
                End If

                a(2) = date_received
                a(3) = newDR.Item("rs_no").ToString
                a(4) = newDR.Item("invoice_no").ToString
                a(5) = newDR.Item("rr_no").ToString
                a(7) = newDR.Item("SUPPLIER").ToString
                a(8) = newDR.Item("qty").ToString
                a(13) = newDR.Item("rs_id").ToString
                a(14) = newDR.Item("IN_OUT").ToString

                'beginning_balance1 = beginning_balance1 + CDec(newDR.Item("qty").ToString)
                'a(10) = beginning_balance1

                If lvlStockCard.InvokeRequired Then
                    lvlStockCard.Invoke(Sub()
                                            'dtgStockCard.Rows.Add(a)
                                            Dim lvl As New ListViewItem(a)
                                            lvl.BackColor = Color.LightYellow
                                            lvlStockCard.Items.Add(lvl)
                                        End Sub)
                Else
                    'dtgStockCard.Rows.Add(a)
                    Dim lvl As New ListViewItem(a)
                    lvl.BackColor = Color.LightYellow
                    lvlStockCard.Items.Add(lvl)
                End If

                b += 1

                If Label7.InvokeRequired Then
                    Label7.Invoke(Sub() Label7.Text = newDR.Item("whItem").ToString & " - " & newDR.Item("item_desc").ToString)
                Else
                    Label7.Text = newDR.Item("whItem").ToString & " - " & newDR.Item("item_desc").ToString
                End If

            End While

        Catch ex As Exception
            If TypeOf ex Is System.Threading.ThreadAbortException Then
                Return
                Exit Sub
            End If
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub

    Private Sub load_rr2(rs_id As Integer)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_execute_tempstockcard4", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", 2)
            newCMD.Parameters.AddWithValue("@rs_id", rs_id)
            newCMD.CommandTimeout = 100

            newDR = newCMD.ExecuteReader
            Dim a(45) As String

            While newDR.Read

                Dim date_received As DateTime
                If newDR.Item("date_received").ToString = "" Then
                    date_received = Date.Parse("1990-01-01")
                Else
                    date_received = newDR.Item("date_received").ToString
                End If

                If date_received >= Date.Parse(dtpfrom.Text) Then
                    GoTo proceedhere
                End If

                a(2) = date_received
                a(3) = newDR.Item("rs_no").ToString
                a(4) = newDR.Item("invoice_no").ToString
                a(5) = newDR.Item("rr_no").ToString
                a(7) = newDR.Item("SUPPLIER").ToString
                a(8) = newDR.Item("qty").ToString
                a(13) = newDR.Item("rs_id").ToString

                'beginning_balance2 = beginning_balance2 + CDec(newDR.Item("qty").ToString)
                'a(10) = beginning_balance2

                If lvlStockCard.InvokeRequired Then
                    lvlStockCard.Invoke(Sub()
                                            'dtgStockCard.Rows.Add(a)
                                            Dim lvl As New ListViewItem(a)
                                            lvl.BackColor = Color.LightYellow
                                            lvlStockCard.Items.Add(lvl)
                                        End Sub)
                Else
                    'dtgStockCard.Rows.Add(a)
                    Dim lvl As New ListViewItem(a)
                    lvl.BackColor = Color.LightYellow
                    lvlStockCard.Items.Add(lvl)
                End If

                b += 1

                If Label7.InvokeRequired Then
                    Label7.Invoke(Sub() Label7.Text = newDR.Item("whItem").ToString & " - " & newDR.Item("item_desc").ToString)
                Else
                    Label7.Text = newDR.Item("whItem").ToString & " - " & newDR.Item("item_desc").ToString
                End If

proceedhere:

            End While

        Catch ex As Exception
            If TypeOf ex Is System.Threading.ThreadAbortException Then
                Return
                Exit Sub
            End If
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Sub
    Public Sub load_rs_rs_id1(n As Integer, search As String, items As String)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        ListBox1.Items.Clear()

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_execute_tempstockcard4", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", n)
            newCMD.Parameters.AddWithValue("@rs_no", search)
            newCMD.Parameters.AddWithValue("@datefrom", Date.Parse(dtpfrom.Text))
            newCMD.Parameters.AddWithValue("@dateto", Date.Parse(dtpto.Text))

            newDR = newCMD.ExecuteReader

            While newDR.Read
                ListBox1.Items.Add(newDR.Item("rs_id").ToString)
                rs_id_count += 1
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
            lblRecords.Text = rs_id_count.ToString("N0") & " record(s) found..."

        End Try
    End Sub
    Public Sub load_rs_rs_id2(n As Integer, search As String, items As String)
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        ListBox2.Items.Clear()
        Dim datebefore As DateTime = Date.Parse(dtpfrom.Text).AddDays(-1)
        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_execute_tempstockcard4", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@n", n)
            newCMD.Parameters.AddWithValue("@rs_no", search)
            newCMD.Parameters.AddWithValue("@datefrom", Date.Parse("1900-01-01"))
            newCMD.Parameters.AddWithValue("@dateto", datebefore)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                ListBox2.Items.Add(newDR.Item("rs_id").ToString)
                rs_id_count += 1
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
            lblRecords.Text = rs_id_count.ToString("N0") & " record(s) found..."

        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Not thread.IsAlive Then
            Timer1.Stop()
            Panel7.Visible = False
            'dtgStockCard.Visible = True
            'lvlStockCard.Visible = True
            sort_listview(2)

            'For Each row As ListViewItem In lvlStockCard.Items
            '    If row.SubItems(8).Text = "" Then
            '        'out
            '        Dim bal As Decimal
            '        bal = beginning_balance1 - row.SubItems(9).Text
            '        beginning_balance1 = beginning_balance1 - CDec(row.SubItems(9).Text)

            '        row.SubItems(10).Text = bal

            '    End If

            '    If row.SubItems(9).Text = "" Then
            '        'int 
            '        Dim bal As Decimal
            '        bal = beginning_balance1 + row.SubItems(8).Text
            '        beginning_balance1 = beginning_balance1 + CDec(row.SubItems(8).Text)

            '        row.SubItems(10).Text = bal
            '    End If


            'Next

            'thread1 = New Threading.Thread(AddressOf threading_stock)
            'thread1.Start()

            'Dim wh_id As Integer = get_wh_id_using_wharea(cmbItemName.Text, cmbItem_desc.Text, cmbWareHouse.Text, cmbclassification.Text)
            'Label4.Text = get_beginning_balance1(wh_id)

            get_previous_stock_card_balance()
            'arrange_balance1()

        Else
            Panel7.Visible = True

        End If
    End Sub



    Private Function get_stock_card_balance(dateto As DateTime) As Decimal
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("proc_get_stock_card_balance", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.StoredProcedure

            newCMD.Parameters.AddWithValue("@dateto", dateto)
            newCMD.Parameters.AddWithValue("@wh_id", 99)

            newDR = newCMD.ExecuteReader
            Dim a(10) As String

            While newDR.Read
                get_stock_card_balance = IIf(newDR.Item("balance").ToString = "", 0, newDR.Item("balance").ToString)
            End While

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try


    End Function
    Private Sub sort_listview(n As Integer)

        ' If current column is not the previously clicked column
        ' Add
        If Not n = sortColumn Then

            ' Set the sort column to the new column
            sortColumn = n

            'Default to ascending sort order
            lvlStockCard.Sorting = SortOrder.Ascending

        Else

            'Flip the sort order
            If lvlStockCard.Sorting = SortOrder.Ascending Then
                lvlStockCard.Sorting = SortOrder.Descending
            Else
                lvlStockCard.Sorting = SortOrder.Ascending
            End If
        End If

        'Set the ListviewItemSorter property to a new ListviewItemComparer object
        Me.lvlStockCard.ListViewItemSorter = New ListViewItemComparer(n, lvlStockCard.Sorting)

        ' Call the sort method to manually sort
        lvlStockCard.Sort()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        abortsearching = True

        Try
            If abortsearching = True Then
                If thread.IsAlive Then
                    thread.Abort()
                End If
            End If

        Catch ex As Exception
            If TypeOf ex Is System.Threading.ThreadAbortException Then
                Return
                Exit Sub
            End If

            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If Not thread.IsAlive Then
            Timer2.Stop()
            Panel7.Visible = False
            'dtgStockCard.Visible = True
            lvlStockCard.Visible = True
            sort_listview(2)

            For Each row As ListViewItem In lvlStockCard.Items
                If row.SubItems(8).Text = "" Then
                    'out
                    Dim bal As Decimal
                    bal = beginning_balance2 - row.SubItems(9).Text
                    beginning_balance2 = beginning_balance2 - CDec(row.SubItems(9).Text)

                    'row.SubItems(10).Text = bal

                End If

                If row.SubItems(9).Text = "" Then
                    'int 
                    Dim bal As Decimal
                    bal = beginning_balance2 + row.SubItems(8).Text
                    beginning_balance2 = beginning_balance2 + CDec(row.SubItems(8).Text)

                    'row.SubItems(10).Text = bal
                End If

            Next

            MsgBox(beginning_balance2)
            'lvlStockCard.Items.Clear()
            'Button1.PerformClick()
        Else
            Panel7.Visible = True

        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub arrange_balance1()
        Dim d As Integer = lvlStockCard.Items.Count - 1
        Dim counter1 As Integer
        Dim gg As Decimal = CDec(Label4.Text)

        For i = 0 To d
            If lvlStockCard.Items(i).SubItems(14).Text = "OUT" Then
                lvlStockCard.Items(i).SubItems(10).Text = gg - CDec(lvlStockCard.Items(i).SubItems(9).Text)
                gg = gg - CDec(lvlStockCard.Items(i).SubItems(9).Text)
            Else
                lvlStockCard.Items(i).SubItems(10).Text = gg + CDec(lvlStockCard.Items(i).SubItems(8).Text)
                gg = gg + CDec(lvlStockCard.Items(i).SubItems(8).Text)
            End If
        Next
    End Sub
    Private Sub arrange_balance()
        Dim d As Integer = lvlStockCard.Items.Count - 1
        Dim counter1 As Integer
        Dim gg As Decimal

        For i = 0 To lvlStockCard.Items.Count - 1
            'MsgBox(lvlStockCard.Items(d).SubItems(10).Text)
            If counter1 = 0 Then
                If lvlStockCard.Items(d).SubItems(14).Text = "OUT" Then
                    gg = CDec(lvlStockCard.Items(d).SubItems(10).Text) - CDec(lvlStockCard.Items(d).SubItems(9).Text)
                    lvlStockCard.Items(d).SubItems(10).Text = FormatNumber(CDec(lvlStockCard.Items(d).SubItems(10).Text), 2,,, TriState.True)

                ElseIf lvlStockCard.Items(d).SubItems(14).Text = "IN" Then
                    gg = CDec(lvlStockCard.Items(d).SubItems(10).Text) + CDec(lvlStockCard.Items(d).SubItems(8).Text)
                    lvlStockCard.Items(d).SubItems(10).Text = FormatNumber(CDec(lvlStockCard.Items(d).SubItems(10).Text), 2,,, TriState.True)

                End If
            Else
                If lvlStockCard.Items(d).SubItems(14).Text = "OUT" Then
                    lvlStockCard.Items(d).SubItems(10).Text = FormatNumber(gg, 2,,, TriState.True)
                    gg += CDec(lvlStockCard.Items(d).SubItems(9).Text)

                ElseIf lvlStockCard.Items(d).SubItems(14).Text = "IN" Then
                    lvlStockCard.Items(d).SubItems(10).Text = FormatNumber(gg, 2,,, TriState.True)
                    gg -= CDec(lvlStockCard.Items(d).SubItems(8).Text)
                End If

            End If
            d -= 1
            counter1 += 1
        Next

        'Dim wh_id As Integer = get_wh_id_using_wharea(cmbItemName.Text, cmbItem_desc.Text, cmbWareHouse.Text, cmbclassification.Text)
        'Label4.Text = get_beginning_balance1(wh_id)

    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        Panel8.Visible = True
        cmbforClassification.SelectedIndex = 1
        cmbforClassification.Enabled = True
        cmbclassification.Enabled = True
        cmbforClassification.Focus()
        FStockCard.load_clasifications(cmbclassification)

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Panel8.Visible = False
    End Sub

    Private Sub cmbItemName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbItemName.SelectedIndexChanged
        FMaterials_ToolsTurnOverTextFields.get_WhItemDesc(cmbItemName.Text, 0, cmbItem_desc)
    End Sub

    Private Sub cmbItem_desc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbItem_desc.SelectedIndexChanged

    End Sub



    Private Sub StockCard1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_warehouse()
        FMaterials_ToolsTurnOverTextFields.get_whItem(0, cmbItemName)

        ListBox1.Location = New Point(100000, 10000)
        ListBox2.Location = New Point(100000, 10000)

    End Sub
    Sub load_warehouse()
        cmbWareHouse.Items.Clear()

        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader

        Try
            newSQ.connection.Open()
            newCMD = New SqlCommand("select DISTINCT wh_area from dbwh_area ORDER BY wh_area ASC", newSQ.connection)
            newCMD.Parameters.Clear()
            newCMD.CommandType = CommandType.Text
            newDR = newCMD.ExecuteReader
            While newDR.Read
                cmbWareHouse.Items.Add(newDR("wh_area").ToString)
            End While

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            newSQ.connection.Close()
        End Try
    End Sub
    Private Sub threading_stock()
        If lvlStockCard.InvokeRequired Then
            lvlStockCard.Invoke(Sub()
                                    For Each row As ListViewItem In lvlStockCard.Items
                                        row.SubItems(10).Text = get_stock_card_balance(Date.Parse(row.SubItems(2).Text))
                                    Next
                                End Sub)
        Else
            For Each row As ListViewItem In lvlStockCard.Items
                row.SubItems(10).Text = get_stock_card_balance(Date.Parse(row.SubItems(2).Text))
            Next
        End If
    End Sub

    Private Sub cmbItem_desc_GotFocus(sender As Object, e As EventArgs) Handles cmbItem_desc.GotFocus
        sender.DroppedDown = True
    End Sub

    Private Sub cmbItemName_GotFocus(sender As Object, e As EventArgs) Handles cmbItemName.GotFocus
        sender.DroppedDown = True
    End Sub

    Private Sub cmbWareHouse_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbWareHouse.SelectedIndexChanged

    End Sub

    Private Sub cmbItemName_Leave(sender As Object, e As EventArgs) Handles cmbItemName.Leave
        sender.DroppedDown = False
    End Sub

    Private Sub cmbItem_desc_Leave(sender As Object, e As EventArgs) Handles cmbItem_desc.Leave
        sender.DroppedDown = False
    End Sub

    Private Sub cmbWareHouse_GotFocus(sender As Object, e As EventArgs) Handles cmbWareHouse.GotFocus
        sender.DroppedDown = True
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Dispose()

    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click


    End Sub
    Private Sub get_previous_stock_card_balance()
        With crs_data

            .item_name = cmbItemName.Text
            .item_desc = cmbItem_desc.Text
            .classification = cmbclassification.Text
            .date_from = Date.Parse(dtpfrom.Text)
            .date_to = Date.Parse(dtpto.Text)
            .lvl = lvlStockCard
            .user_id = pub_user_id
            .wh_area = cmbWareHouse.Text
            .lbl_prev_balance = Label4
            .intended = "STOCKCARD"
        End With

        Panel7.Visible = True
        lblRecords.Text = "Initializing balance..."
        thread = New Threading.Thread(AddressOf get_prev_balance)
        thread.Start()
        Timer4.Start()


    End Sub
    Private Sub get_prev_balance1()
        Dim c_search As New Class_SC_Hauling(crs_data)
    End Sub



    Private Sub get_prev_balance()
        Dim c_search As New Class_SC_Hauling(crs_data)


        'DONT DELETE ****************
        'c_search.st_delete()
        'c_search.from_rs("OUT")
        'c_search.from_rs("IN")
        'c_search.prev_balance_in_label()
        'c_search.arrange_balance()
        '******************************

        c_search.prev_balance_in_label_new()
        c_search.arrange_balance()

        'arrange_balance1()
        'Label4.Text = c_search.prev_balance + c_search.prev_balance_from_excel
    End Sub

    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer4.Tick

        If Not thread.IsAlive Then
            Panel7.Visible = False
            lvlStockCard.Visible = True
        End If

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        button_click_name = "searchbystockcard"
        FListOfItems.ShowDialog()

    End Sub

    Private Sub BackgroundWorker2_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        Dim SortRs = From _rs In cListOfrs
                     Select _rs Order By _rs.rs_date, _rs.rs_no Ascending

        Dim SortPo = From _po In cListOfpo
                     Select _po Order By _po.po_date, _po.po_no Ascending

        Dim SortWs = From _ws In cListOfws
                     Select _ws Order By _ws.ws_date, _ws.ws_no Ascending

        Dim SortRr = From _rr In cListOfrr
                     Select _rr Order By _rr.date_received, _rr.rr_no Ascending


        For Each row In SortRs
            'RS
            Dim _rs As New stockcard_fields
            With _rs
                .rs_id = row.rs_id
                .stDate = row.rs_date
                .rs_no = row.rs_no
                .invoice = "-"
                .rr_no = "-"
                .ws_no = "-"
                .supp_recepient = row.charges
                .inout_qty = row.rs_qty
                .inout = row.inout
                .remarks = "rs"

                'cListOfStockCard.Add(_rs)
            End With

            'IN
            If row.inout = "IN" Then
                If row.type_of_purchasing = "PURCHASE ORDER" Then
#Region "IN WITH PO AND RR"
                    For Each po_row In SortPo

                        If row.rs_id = po_row.rs_id Then

                            Dim _po As New stockcard_fields
                            With _po
                                .rs_id = po_row.rs_id
                                .stDate = po_row.po_date
                                .rs_no = row.rs_no
                                .invoice = "-"
                                .rr_no = "-"
                                .ws_no = "-"
                                .supp_recepient = "-"
                                .inout_qty = po_row.qty
                                .inout = row.inout
                                .remarks = "po"

                            End With

                            'RECEIVING
                            For Each row_rr In SortRr
                                If po_row.po_det_id = row_rr.po_det_id Then
                                    Dim _rr As New stockcard_fields
                                    With _rr
                                        .rs_id = row_rr.rs_id
                                        .stDate = row_rr.date_received
                                        .rs_no = row.rs_no
                                        .invoice = row_rr.invoice_no
                                        .rr_no = row_rr.rr_no
                                        .ws_no = "-"
                                        .supp_recepient = row_rr.supplier
                                        .inout_qty = row_rr.rr_qty
                                        .inout = row.inout
                                        .remarks = "rr"
                                        .status = row.type_of_purchasing
                                    End With

                                    cListOfStockCard.Add(_rr)
                                End If
                            Next
                        End If
                    Next
#End Region
                ElseIf row.type_of_purchasing = "CASH WITH RR" Or row.type_of_purchasing = "CASH" Then
#Region "CASH WITH RR"
                    'RECEIVING
                    For Each row_rr In SortRr
                        If row.rs_id = row_rr.rs_id Then
                            Dim _rr As New stockcard_fields
                            With _rr
                                .rs_id = row_rr.rs_id
                                .stDate = row_rr.date_received
                                .rs_no = row.rs_no
                                .invoice = row_rr.invoice_no
                                .rr_no = row_rr.rr_no
                                .ws_no = "-"
                                .supp_recepient = row_rr.supplier
                                .inout_qty = row_rr.rr_qty
                                .inout = row.inout
                                .remarks = "rr"
                                .status = row.type_of_purchasing

                            End With

                            cListOfStockCard.Add(_rr)
                        End If
                    Next
#End Region
                End If
#Region "OUT"
            ElseIf row.inout = "OUT" Then
                    For Each ws_row In SortWs

                    If row.rs_id = ws_row.rs_id Then
                        Dim _ws As New stockcard_fields
                        With _ws
                            .rs_id = ws_row.rs_id
                            .stDate = ws_row.ws_date
                            .rs_no = row.rs_no
                            .invoice = "-"
                            .rr_no = "-"
                            .ws_no = ws_row.ws_no
                            .supp_recepient = row.charges
                            .inout_qty = ws_row.ws_qty
                            .inout = row.inout
                            .remarks = "out"
                            .status = ws_row.status

                            cListOfStockCard.Add(_ws)
                        End With
                    End If

                Next
            End If
#End Region
        Next


        '<-- get previous balance
        Dim prev_balance As New Model_Dynamic_Select
        prev_balance._initialize("dbPrevious_stock_card", $"wh_id={cWh_id}", "balance")

        Dim balances As Decimal

        Dim data = prev_balance.getList()
        For Each row In data
            For Each kvp As KeyValuePair(Of String, Object) In row
                'MsgBox($"{kvp.Key}: {kvp.Value.ToString()}")
                balances = IIf(kvp.Value.ToString = "", 0, kvp.Value.ToString)
            Next
        Next  '-- end get previous balance -->

        'reflect previouse balance sa label4
        If Label4.InvokeRequired Then
            Label4.Invoke(Sub()
                              Label4.Text = balances
                          End Sub)
        Else
            Label4.Text = balances
        End If

        'SORT DATA FIRST 
        Dim final = From aa In cListOfStockCard
                    Select aa Order By aa.stDate, aa.rs_id Ascending

        For Each row In final
            Dim a(12) As String

            a(0) = row.rs_id
            a(2) = row.stDate
            a(3) = row.rs_no
            a(4) = row.invoice
            a(5) = row.rr_no
            a(6) = row.ws_no
            a(7) = row.supp_recepient.ToUpper()

            If row.status = "WITHDRAWAL RELEASED" Then 'kini wala pa na withdraw pero na buhatan na og ws, dili ni maapil sa stockcard
                GoTo proceedhere
            End If

            If row.inout = "IN" Then
                a(8) = row.inout_qty
                a(9) = "-"
                balances = balances + CDec(row.inout_qty)

            ElseIf row.inout = "OUT" Then
                a(8) = "-"
                a(9) = row.inout_qty
                balances = balances - CDec(row.inout_qty)

            End If

            a(10) = balances
            a(11) = row.status
            a(12) = row.inout



            Dim lvl As New ListViewItem(a)
            If row.inout = "OUT" Then
                lvl.BackColor = Color.LightGreen
                lvl.ForeColor = Color.Black
                lvl.Font = New Font("Century Gothic", 11, FontStyle.Regular)
            Else
                lvl.BackColor = Color.LightYellow
                lvl.ForeColor = Color.Black
                lvl.Font = New Font("Century Gothic", 11, FontStyle.Regular)
            End If

            cListOfListView.Add(lvl)
proceedhere:
        Next

        If lvlStockCard.InvokeRequired Then
            lvlStockCard.Invoke(Sub()
                                    lvlStockCard.Items.AddRange(cListOfListView.ToArray)
                                    Panel7.Visible = False
                                End Sub)
        Else
            lvlStockCard.Items.AddRange(cListOfListView.ToArray)
            Panel7.Visible = False
        End If


    End Sub

    Public Function get_wh_id_using_wharea(item_name As String, item_desc As String, wh_area As String, classification As String) As Integer
        Dim newSQ As New SQLcon
        Dim newCMD As SqlCommand
        Dim newDR As SqlDataReader
        Dim query As String = ""

        Try
            newSQ.connection.Open()

            If cmbforClassification.Text = "YES" Then
                query = "SELECT a.wh_id,b.wh_area,a.whItem,a.whItemDesc,whClass FROM dbwarehouse_items a "
                query &= "LEFT JOIN dbwh_area b "
                query &= "On b.wh_area_id = a.whArea "
                query &= "WHERE a.whItem = '" & item_name & "' "
                query &= "And a.whItemDesc = '" & item_desc & "' "
                query &= "And b.wh_area = '" & wh_area & "' "
                query &= "And a.whClass = '" & classification & "'"

            ElseIf cmbforClassification.Text = "NO" Then
                query = "SELECT a.wh_id,b.wh_area,a.whItem,a.whItemDesc,whClass FROM dbwarehouse_items a "
                query &= "LEFT JOIN dbwh_area b "
                query &= "On b.wh_area_id = a.whArea "
                query &= "WHERE a.whItem = '" & item_name & "' "
                query &= "And a.whItemDesc = '" & item_desc & "' "
                query &= "And b.wh_area = '" & wh_area & "'"

            End If


            newCMD = New SqlCommand(query, newSQ.connection)
            'newCMD.Parameters.Clear()
            'newCMD.CommandType = CommandType.StoredProcedure

            'newCMD.Parameters.AddWithValue("@n", 15)  
            'newCMD.Parameters.AddWithValue("@item_name", item_name)
            'newCMD.Parameters.AddWithValue("@item_desc", item_desc)
            'newCMD.Parameters.AddWithValue("@wh_area_name", wh_area)

            newDR = newCMD.ExecuteReader

            While newDR.Read
                get_wh_id_using_wharea = newDR.Item("wh_id").ToString
            End While
            newDR.Close()

        Catch ex As Exception
            MessageBox.Show("Error MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSQ.connection.Close()
        End Try

    End Function

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        trd1 = New Threading.Thread(AddressOf rs_threading)
        trd1.Start()
        trd1.Join()

        trd2 = New Threading.Thread(AddressOf po_threading)
        trd2.Start()
        trd2.Join()

        trd3 = New Threading.Thread(AddressOf ws_threading)
        trd3.Start()
        trd3.Join()

        trd4 = New Threading.Thread(AddressOf rr_threading)
        trd4.Start()
        trd4.Join()

    End Sub

    Private Sub cmbWareHouse_Leave(sender As Object, e As EventArgs) Handles cmbWareHouse.Leave
        sender.DroppedDown = False
    End Sub
    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        'MsgBox($"rs:{cListOfrs.Count}, po: {cListOfpo.Count}, ws:{cListOfws.Count }")

        BackgroundWorker2.WorkerSupportsCancellation = True
        BackgroundWorker2.RunWorkerAsync()

    End Sub
End Class