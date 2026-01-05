Imports System.ComponentModel
Imports System.Windows
Imports OfficeOpenXml.ExcelErrorValue

Public Class StockCardModel
    Private cListOfStockCard As New List(Of stockcard_fields)
    Private cListOfListView As New List(Of ListViewItem)
    Public cWh_id As Integer

    Private cListOfRsId As New List(Of Integer)
    Private cListOfListViewItem As New List(Of ListViewItem)

    Private poModel,
        wsModel,
        rrModel,
        rsModel,
        prevBalanceModel,
        withdrawnModel,
        partiallyWithdrawnModel,
        cancelledTransactionModel As New ModelNew.Model

    Private cPrevBalance As Double
    Private cListOfStockCardNew As New List(Of stockcard_fields)
    Private cListOfWithdrawnItems As New List(Of PropsFields.withdrawn_props_fields)
    Private cListOfPartiallyWithdrawn As New List(Of PropsFields.partiallyWithdrawn_props_fields)
    Private cListOfCancelledTransaction As New List(Of PropsFields.CancelledTransaction)

    Dim prevBalance As Double
    Public stockCardDic As New Dictionary(Of String, Object)
    Dim cBgWorkerChecker As Timer

    Private m As New myEnum
    Public cData As Object

    Private cWhId As Integer
    Private cListView As New ListView
    Private cDatagridview As New DataGridView
    Private cBegBalance, cRemBalance As New Label
    Private cWhatView As String
    Private customGridview As New CustomGridview
    Private cLoadingPanel As New Panel
    Private cLoading2 As New PictureBox
    Private customMsg As New customMessageBox
    Private Class stockcard_fields
        Public Property rs_id As Integer
        Public Property stDate As DateTime
        Public Property rs_no As String
        Public Property invoice As String
        Public Property rr_no As String
        Public Property ws_no As String
        Public Property supp_recepient As String
        Public Property inout_qty As Decimal
        Public Property in_qty As Decimal
        Public Property out_qty As Decimal
        Public Property balance As Decimal
        Public Property inout As String
        Public Property remarks As String
        Public Property status As String
        Public Property type_of_purchasing As String
        Public Property withdrawn_status As String

    End Class

    Private Class myEnum
        Public ReadOnly Property remainingBalance As String = "remainingBalance"
        Public ReadOnly Property datas As String = "datas"

    End Class

    ''' <summary>
    ''' (wh_id, listview/datagridview, beginning  balance, whatview, rem.balance, loadingpanel).
    ''' </summary>
    ''' <returns>void</returns>
    Public Sub _initialize(paramWhId As Integer,
                           viewing As Object,
                           Optional beginningBalanceLabel As Label = Nothing,
                           Optional view As String = "",
                           Optional remBalanceLabel As Label = Nothing,
                           Optional loadingPanel As Panel = Nothing
                           )
        cWhId = paramWhId
        cBegBalance = beginningBalanceLabel
        cRemBalance = remBalanceLabel
        cLoadingPanel = loadingPanel

        cWhatView = view

        If view = "listview" Then
            cListView = viewing
        ElseIf view = "datagridview" Then
            cDatagridview = viewing
        End If
    End Sub

    Public Sub _initialize2(props As Dictionary(Of String, Object))

        cWhId = props("wh_id")
        cBegBalance = CType(props("beginningBalance"), Label)
        cRemBalance = CType(props("remBalance"), Label)
        cLoadingPanel = CType(props("loading"), Panel)
        cLoading2 = CType(props("loading2"), PictureBox)

        cWhatView = CStr(props("view"))

        If CStr(props("view")) = "listview" Then
            cListView = CType(props("listview"), ListView)

        ElseIf CStr(props("view")) = "datagridview" Then
            cDatagridview = CType(props("datagridview"), DataGridView)

        End If
    End Sub



    Public Sub loadStockcard()

        cListOfStockCardNew.Clear()
        cListOfListViewItem.Clear()
        cListOfCancelledTransaction.Clear()

        rsModel.clearParameter()
        poModel.clearParameter()
        wsModel.clearParameter()
        rrModel.clearParameter()
        prevBalanceModel.clearParameter()
        withdrawnModel.clearParameter()
        partiallyWithdrawnModel.clearParameter()
        cancelledTransactionModel.clearParameter()

        cLoadingPanel.Visible = True
        cLoading2.Visible = True

        Dim cv1, cancelledTransactionValues As New ColumnValues
        cv1.add("search", cWhId)
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

        _initializing(cCol.forWithdrawn,
                          cv1.getValues(),
                          withdrawnModel,
                          stockCardBgWorker)

        _initializing(cCol.forPartiallyWithdrawn,
                    cv1.getValues(),
                    partiallyWithdrawnModel,
                    stockCardBgWorker)

        _initializing(cCol.forCancelRs,
                         cancelledTransactionValues.getValues(),
                         cancelledTransactionModel,
                         stockCardBgWorker)



        cBgWorkerChecker = BgWorkersCheckerFn(AddressOf SuccessfullyDone, stockCardBgWorker)

    End Sub

    Private Sub SuccessfullyDone()

        cListOfPurchaseOrder = TryCast(poModel.cData, List(Of PropsFields.purchase_order_props_fields))
        cListOfWithdrawal = TryCast(wsModel.cData, List(Of PropsFields.withdrawal_props_fields))
        cListOfReceiving = TryCast(rrModel.cData, List(Of PropsFields.receiving_props_fields))
        cListOfRequisition = TryCast(rsModel.cData, List(Of PropsFields.rs_props_fields))
        cPrevBalance = CType(prevBalanceModel.cData, Double)

        cListOfWithdrawnItems = CType(withdrawnModel.cData, List(Of PropsFields.withdrawn_props_fields))
        cListOfPartiallyWithdrawn = CType(partiallyWithdrawnModel.cData, List(Of PropsFields.partiallyWithdrawn_props_fields))
        cListOfCancelledTransaction = CType(cancelledTransactionModel.cData, List(Of PropsFields.CancelledTransaction))

        PreviewResult()
        'storeData()
        cLoadingPanel.Visible = False
        cLoading2.Visible = False

    End Sub

    Private Function getStockCardDatas() As Dictionary(Of String, Object)
        getStockCardDatas = New Dictionary(Of String, Object)

        'rs 
        For Each rowRs In cListOfRequisition
            Dim stf As New stockcard_fields

            With stf
                'for po
                If rowRs.inout = "IN" Then
                    'if cash with rr
                    If rowRs.type_of_purchasing.ToUpper() = "CASH WITH RR" Then
                        'for receiving
                        For Each rowRr In cListOfReceiving
                            If rowRr.rs_id = rowRs.rs_id Then
                                'add rows
                                rowReceiving(rowRr, rowRs.inout, rowRs.type_of_purchasing)
                            End If
                        Next
                    Else
                        'if with po and rr
                        For Each rowPo In cListOfPurchaseOrder
                            If rowRs.rs_id = rowPo.rs_id Then

                                'for receiving
                                For Each rowRr In cListOfReceiving
                                    If rowRr.rs_id = rowRs.rs_id Then
                                        'add rows
                                        rowReceiving(rowRr, rowRs.inout, rowRs.type_of_purchasing)
                                    End If
                                Next
                            End If
                        Next
                    End If

                    'for ws
                ElseIf rowRs.inout = "OUT" Then

                    For Each rowWs In cListOfWithdrawal
                        If rowWs.rs_id = rowRs.rs_id Then
                            'if withdrawn
                            If Not rowWs.withdrawn_id = 0 Then

                                'cancelled ws
                                If isCancelWithdrawal(rowWs) Then
                                    GoTo proceedhereForCancelledWS
                                End If

                                Dim status As Integer = ifBlankReplaceToZero(rowWs.withdrawn_status)

                                    rowWithdrawal(rowWs,
                                                rowRs.inout,
                                                rowRs.type_of_purchasing,
                                                status)

                                    'add partially withdrawn
                                    If status = 1 Then
                                        For Each partialWs In cListOfPartiallyWithdrawn
                                            If rowWs.withdrawn_id = partialWs.withdrawn_id And Not partialWs.status = "deleted" Then

                                                rowPartiallyWithdrawn(partialWs,
                                                                  rowWs.ws_no,
                                                                  rowRs.type_of_purchasing,
                                                                  rowWs.rs_id,
                                                                  rowWs.charges)
                                            End If
                                        Next
                                    End If

proceedhereForCancelledWS:
                                End If
                            End If
                    Next
                    'for cash with rr
                    'ElseIf rowRs.type_of_purchasing.ToUpper() = "CASH WITH RR" Then
                    '    For Each rowRr In cListOfReceiving
                    '        If rowRr.rs_id = rowRs.rs_id Then
                    '            'add rows

                    '        End If
                    '    Next
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

                If .inout = cInOut._OUT Then
                    'remainingBalance -= .out_qty
                    If .withdrawn_status = 0 Then
                        remainingBalance -= .out_qty
                    End If
                ElseIf .inout = cInOut._PARTIAL Then
                    remainingBalance -= .out_qty

                ElseIf .inout = cInOut._IN Then
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
                sf.type_of_purchasing = .type_of_purchasing

                stockCardDatas.Add(sf)
            End With
        Next

        getStockCardDatas.Add(m.datas, stockCardDatas)
        getStockCardDatas.Add(m.remainingBalance, remainingBalance)

        Return getStockCardDatas
    End Function

    Private Sub PreviewResult()


        If cWhatView = "listview" Then
            cListView.Items.Clear()
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
                    If .inout = cInOut._OUT Then
                        lvl.BackColor = Color.LightGreen
                    ElseIf .inout = cInOut._IN Then
                        lvl.BackColor = Color.LightYellow
                    ElseIf .inout = cInOut._PARTIAL Then
                        lvl.BackColor = Color.LightBlue
                    End If

                    cListOfListViewItem.Add(lvl)
                    id = .rs_id
                End With

            Next

            cBegBalance.Text = cPrevBalance
            cListView.Items.AddRange(cListOfListViewItem.ToArray)

            listfocus(cListView, id)

        ElseIf cWhatView = "datagridview" Then
            cDatagridview.Rows.Clear()

            Dim stockCardDic As New Dictionary(Of String, Object)
            stockCardDic = getStockCardDatas()

            Dim data As New List(Of stockcard_fields)
            data = stockCardDic(m.datas)

            cBegBalance.Text = cPrevBalance
            cRemBalance.Text = stockCardDic(m.remainingBalance)

            cDatagridview.DataSource = data
            setCustomGridview()

            For Each row As DataGridViewRow In cDatagridview.Rows
                If row.Cells("inout").Value = cInOut._OUT Then
                    row.DefaultCellStyle.BackColor = Color.LightGreen

                ElseIf row.Cells("inout").Value = cInOut._IN Then
                    row.DefaultCellStyle.BackColor = Color.LightYellow

                ElseIf row.Cells("inout").Value = cInOut._PARTIAL Then
                    row.DefaultCellStyle.BackColor = Color.LightBlue

                End If
            Next

            ' Ensure that the DataGridView has rows before trying to focus on the last one
            If cDatagridview.Rows.Count > 0 Then
                ' Set the current cell to the last row, first column (or any other column you want)
                cDatagridview.CurrentCell = cDatagridview.Rows(cDatagridview.Rows.Count - 1).Cells(0)

                ' Optionally, make the row selected
                cDatagridview.Rows(cDatagridview.Rows.Count - 1).Selected = True
            End If

        End If


    End Sub

    Private Sub storeData()

        stockCardDic = getStockCardDatas()
        MsgBox(stockCardDic(m.remainingBalance))

    End Sub

    Public Function getStockCardBalance() As Double
        stockCardDic = getStockCardDatas()
        getStockCardBalance = stockCardDic(m.remainingBalance)
    End Function

    Private Sub rowReceiving(data As PropsFields.receiving_props_fields,
                         Optional inout As String = "",
                         Optional typeOfPurchasing As String = "")


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
            .type_of_purchasing = typeOfPurchasing

        End With

        cListOfStockCardNew.Add(c)
    End Sub

    Private Sub rowWithdrawal(data As PropsFields.withdrawal_props_fields,
                              Optional inout As String = "",
                              Optional typeOfPurchasing As String = "",
                              Optional withdrawn_status As Integer = 0)


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
            .type_of_purchasing = typeOfPurchasing
            .withdrawn_status = withdrawn_status

        End With

        If withdrawn_status = 0 Then
            cListOfStockCardNew.Add(c)
        End If


    End Sub

    Private Sub rowPartiallyWithdrawn(data As PropsFields.partiallyWithdrawn_props_fields,
                                      Optional wsNo As String = "",
                                      Optional typeOfPurchasing As String = "",
                                      Optional rs_id As Integer = 0,
                                      Optional charges As String = "")
        Dim c As New stockcard_fields
        With c
            .rs_id = rs_id
            .stDate = data.date_partially_withdrawn
            .rs_no = "-"
            .ws_no = wsNo
            .supp_recepient = charges
            .inout_qty = 0
            .out_qty = data.partially_withdrawn_qty
            .inout = cInOut._PARTIAL
            .balance = prevBalance
            .type_of_purchasing = typeOfPurchasing

        End With

        cListOfStockCardNew.Add(c)
    End Sub
    Private Sub setCustomGridview()

        With customGridview
            .customDatagridview(cDatagridview)

            'hide colums
            .customDatagridviewHideColumn(cDatagridview, "remarks", False)
            .customDatagridviewHideColumn(cDatagridview, "status", False)
            .customDatagridviewHideColumn(cDatagridview, "invoice", False)
            .customDatagridviewHideColumn(cDatagridview, "inout_qty", False)
            .customDatagridviewHideColumn(cDatagridview, "withdrawn_status", False)


            '.customDatagridviewHideColumn(DataGridView1, "colorLegend", False)

            'change headertext name

            .subcustomDatagridviewSettings("headerTextOnly", cDatagridview, 0,, "RSID")
            .subcustomDatagridviewSettings("headerTextOnly", cDatagridview, 1,, "DATE")
            .subcustomDatagridviewSettings("headerTextOnly", cDatagridview, 2,, "RS NO")
            .subcustomDatagridviewSettings("headerTextOnly", cDatagridview, 4,, "RR NO")
            .subcustomDatagridviewSettings("headerTextOnly", cDatagridview, 5,, "WS NO")
            .subcustomDatagridviewSettings("headerText", cDatagridview, 6, 250, "SUPPLIER/RECEPIENT")
            .subcustomDatagridviewSettings("headerTextOnly", cDatagridview, 8,, "IN")
            .subcustomDatagridviewSettings("headerTextOnly", cDatagridview, 9,, "OUT")
            .subcustomDatagridviewSettings("headerTextOnly", cDatagridview, 10,, "BALANCE")
            .subcustomDatagridviewSettings("headerTextOnly", cDatagridview, 11,, "IN/OUT")

            'readonly
            For Each column As DataGridViewColumn In cDatagridview.Columns
                column.ReadOnly = True
            Next

        End With

    End Sub

#Region "PRIVATE GET"
    Private Function isCancelledDataFor(transId As Integer,
                                        transaction As String) As Boolean
        Try
            Dim isCancelled = cListOfCancelledTransaction.FirstOrDefault(Function(x)
                                                                             Return x.trans_id = transId And x.trans = transaction
                                                                         End Function)



            If isCancelled IsNot Nothing Then
                Return True
            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function
#End Region

#Region "UTILITIES"
    Private Function isCancelWithdrawal(row As PropsFields.withdrawal_props_fields) As Boolean
        Try

            Dim transId As Integer = CInt(row.ws_id)

            Dim cancelResult = isCancelledDataFor(transId, "WS")

            If cancelResult Then
                Return True
            End If

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function
#End Region

End Class
