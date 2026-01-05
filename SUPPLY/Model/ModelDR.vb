
Imports System.ComponentModel
Imports System.IO
Imports System.Web.SessionState


Public Class ModelDR

#Region "VARIABLES"
    Private rsModel,
        poModel,
        wsModel,
        drModel,
        mainRsModel,
        mainRsSubModel,
        rrModel,
        cAllChargesModel,
        whAreaStockpileModel As New ModelNew.Model

    Dim cBgWorkerChecker As Timer

    Private cListOfRs As New List(Of PropsFields.rsdata_props_fields)
    Private cListOfPo As New List(Of PropsFields.purchase_order_props_fields)
    Private cListOfRr As New List(Of PropsFields.receiving_props_fields)
    Private cListOfWs As New List(Of PropsFields.withdrawal_props_fields)
    Private cListOfDr As New List(Of PropsFields.dr_props_fields)
    Private cListOfMainRs As New List(Of PropsFields.main_rsdata_props_fields)
    Private cListOfMainRsSub As New List(Of PropsFields.main_rsdata_props_fields)
    Private cListOfAllCharges As New List(Of PropsFields.AllCharges)
    Private cListOfWhArea As New List(Of PropsFields.whArea_stockpile_props_fields)

    Private cListOfListviewItem As New List(Of ListViewItem)
    Public cListOfWsReleasedItems As New List(Of PropsFields.withdrawn_props_fields)
    Private cPanel As Panel
    Private cOldLoadingPanel As Panel
    Private cProgressBar As ProgressBar
    Private cListview As New ListView
    Private cRsLabel, cWsLabel, cPoLabel, cDrLabel, cMainRsLabel As Label
    Private cRsSearchButton As New Button
    Private cContextMenuStrip As New ContextMenuStrip

    Dim search, searchBy As String
    Dim dateEnable As Boolean
    Dim cDateFrom, cdateTo As DateTime

    Private customMsg As New customMessageBox

    'variables
    Dim bR1, br2, br3 As Boolean
    Dim cRS_No As String
    Dim cRemaining_Balance As Double
    Dim cTotal_Dr, cTotal_Dr2 As Double
    Dim cTotal_RR As Double
    Dim cToBeDisplay As Boolean
    Dim cOpenCloseQty As Double
    Dim cRsId As Integer

    Private loadingWorker As New BackgroundWorker
    Private displayWorker As New BackgroundWorker

    Private cSomeComponents As New ColumnValuesObj

    Public Enum ModelNames
        all = 0
        rsModel = 1
        poModel = 2
        wsModel = 3
        mainRsModel = 4
        mainRsSubModel = 5
        rrModel = 6

    End Enum
#End Region

#Region "INITIALIZE"

    Sub New()
        AddHandler loadingWorker.DoWork, AddressOf loadingWorker_DoWork
        AddHandler displayWorker.DoWork, AddressOf displayWorker_DoWork

        AddHandler displayWorker.RunWorkerCompleted, AddressOf displayWorker_RunWorkerCompleted
        'AddHandler loadingWorker.RunWorkerCompleted, AddressOf loadingWorker_RunWorkerCompleted
    End Sub
    Public Sub initialize(Optional param As Dictionary(Of String, Object) = Nothing)
        Try
            If param.ContainsKey("search") Then
                search = CType(param("search"), String)
            End If

            If param.ContainsKey("searchby") Then
                searchBy = CType(param("searchby"), String)
            End If

            If param.ContainsKey("listview") Then
                cListview = TryCast(param("listview"), ListView)
            End If

            If param.ContainsKey("panel") Then
                cPanel = New Panel
                cPanel = TryCast(param("panel"), Panel)
            End If

            If param.ContainsKey("oldLoadingPanel") Then
                cOldLoadingPanel = New Panel
                cOldLoadingPanel = CType(param("oldLoadingPanel"), Panel)
            End If

            If param.ContainsKey("progressbar") Then
                cProgressBar = New ProgressBar
                cProgressBar = TryCast(param("progressbar"), ProgressBar)
            End If

            If param.ContainsKey("rsLabel") Then
                cRsLabel = New Label
                cRsLabel = CType(param("rsLabel"), Label)
            End If

            If param.ContainsKey("wsLabel") Then
                cWsLabel = New Label
                cWsLabel = TryCast(param("wsLabel"), Label)
            End If

            If param.ContainsKey("poLabel") Then
                cPoLabel = New Label
                cPoLabel = TryCast(param("poLabel"), Label)
            End If

            If param.ContainsKey("drLabel") Then
                cDrLabel = New Label
                cDrLabel = TryCast(param("drLabel"), Label)
            End If

            If param.ContainsKey("mainRsLabel") Then
                cMainRsLabel = New Label
                cMainRsLabel = TryCast(param("mainRsLabel"), Label)
            End If

            If param.ContainsKey("btnSearch") Then
                cRsSearchButton = New Button
                cRsSearchButton = TryCast(param("btnSearch"), Button)
            End If

            If param.ContainsKey("contextMenuStrip") Then
                cContextMenuStrip = New ContextMenuStrip
                cContextMenuStrip = TryCast(param("contextMenuStrip"), ContextMenuStrip)
            End If


            If param.ContainsKey("dateEnable") And param.ContainsKey("searchby") Then
                dateEnable = CType(param(NameOf(dateEnable)), Boolean)
                searchBy = CType(param("searchby"), String)
                search = CType(param("search"), String)

                If dateEnable = True Then
                    cDateFrom = Date.Parse(param("dateFrom"))
                    cdateTo = Date.Parse(param("dateTo"))
                End If
            End If

            clear()

            cSomeComponents.add(GetType(Button).ToString, cRsSearchButton)
            cSomeComponents.add(GetType(ContextMenuStrip).ToString, cContextMenuStrip)
            cSomeComponents.add("loadingPanel", cOldLoadingPanel)

            loadingWorker.WorkerSupportsCancellation = True
            loadingWorker.RunWorkerAsync()

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try


    End Sub
#End Region

#Region "GET"
    Public ReadOnly Property GetListOfRR As List(Of PropsFields.receiving_props_fields)
        Get
            Return cListOfRr
        End Get

    End Property

    Public ReadOnly Property GetListOfDR As List(Of PropsFields.dr_props_fields)
        Get
            Return cListOfDr
        End Get

    End Property

    Public Property GetListOfMainRs As List(Of PropsFields.main_rsdata_props_fields)
        Get
            Return cListOfMainRs
        End Get
        Set(value As List(Of PropsFields.main_rsdata_props_fields))
            cListOfMainRs = value
        End Set

    End Property

    Public Property GetListOfMainRsSub As List(Of PropsFields.main_rsdata_props_fields)
        Get
            Return cListOfMainRsSub
        End Get
        Set(value As List(Of PropsFields.main_rsdata_props_fields))
            cListOfMainRsSub = value
        End Set
    End Property

    Public ReadOnly Property GetListOfRs As List(Of PropsFields.rsdata_props_fields)
        Get
            Return cListOfRs
        End Get
    End Property

    Public ReadOnly Property GetListOfWithdrawal As List(Of PropsFields.withdrawal_props_fields)
        Get
            Return cListOfWs
        End Get
    End Property
#End Region

#Region "WORKER"
    Private Sub loadingWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs)
        loadingPanel(True)

    End Sub

    Private Sub displayWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs)

        Select Case searchBy
            Case FRequistionForm.cSearchByItemE.item_name
                previewRsOnly()
            Case Else
                previewDr()
        End Select

    End Sub

    Private Sub displayWorker_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs)
        loadingPanel(False)

    End Sub
#End Region

#Region "EXECUTE"
    Public Sub execute(Optional n As Integer = 0)

        Dim rsVal As New ColumnValues
        Dim wsVal As New ColumnValues
        Dim drVal As New ColumnValues
        Dim mainRsVal As New ColumnValues
        Dim poVal As New ColumnValues
        Dim rrVal As New ColumnValues

        wsVal.add("searchby", FWithdrawalList.cSearchByEnum.search_by_rs_no)
        wsVal.add("search", search)
        wsVal.add("nn", "true")

        rsVal.add("search", search)

        drVal.add("searchby", "RS NO")
        drVal.add("search", search)
        drVal.add("date_from", Date.Parse(Now))
        drVal.add("date_to", Date.Parse(Now))
        drVal.add("date_enable", "DISABLE DATE RANGE")
        drVal.add("=", "true")

        poVal.add("searchby", "Search by RS No.")
        poVal.add("search", search)
        poVal.add("po-for-dr", "true")

        rrVal.add("searchby", "Search by RS No.")
        rrVal.add("search", search)
        rrVal.add("rr-for-dr", "true")

        mainRsVal.add("rs_no", search)

        Dim warehouseAreaVal As New ColumnValues
        warehouseAreaVal.add("crud", 7)
        warehouseAreaVal.add("search", "")

        Dim allChargeVal As New ColumnValues

        cOldLoadingPanel.Visible = True

        Select Case n
            Case ModelNames.all
                _init_._initializing(cCol.forRsCRH,
                rsVal.getValues(),
                rsModel,
                searchRsBgWorker,
                cRsLabel)

                _init_._initializing(cCol.forWithdrawal,
                                     wsVal.getValues(),
                                     wsModel,
                                     searchRsBgWorker,
                                     cWsLabel)

                _init_._initializing(cCol.forPurchaseOrder,
                                         poVal.getValues(),
                                         poModel,
                                         searchRsBgWorker,
                                         cPoLabel)

                _init_._initializing(cCol.forReceiving,
                                     rrVal.getValues(),
                                     rrModel,
                                     searchRsBgWorker)

                _init_._initializing(cCol.forDrSearch,
                                     drVal.getValues(),
                                     drModel,
                                     searchRsBgWorker,
                                     cDrLabel)

                _init_._initializing(cCol.forMainRsCRH,
                                     mainRsVal.getValues(),
                                     mainRsModel,
                                     searchRsBgWorker,
                                     cMainRsLabel)

                _init_._initializing(cCol.forMainRsSubCRH,
                                     mainRsVal.getValues(),
                                     mainRsSubModel,
                                     searchRsBgWorker)

                _init_._initializing(cCol.forAllCharges,
                                      allChargeVal.getValues(),
                                      cAllChargesModel,
                                      searchRsBgWorker)

                _init_._initializing(cCol.forWareHouseStockpileArea,
                      warehouseAreaVal.getValues(),
                      whAreaStockpileModel,
                      searchRsBgWorker)

            Case ModelNames.mainRsSubModel

                _init_._initializing(cCol.forMainRsSubCRH,
                                     mainRsVal.getValues(),
                                     mainRsSubModel,
                                     searchRsBgWorker)

        End Select


        cBgWorkerChecker = BgWorkersCheckerFn(AddressOf RsSuccessfullyDone, searchRsBgWorker)
    End Sub
    Public Sub execute_by_items()
        Dim rsVal As New ColumnValues

        'for searching date enable
        If dateEnable = True Then
            rsVal.add("dateEnable", True)
            rsVal.add("dateFrom", cDateFrom)
            rsVal.add("dateTo", cdateTo)
            rsVal.add("searchby", searchBy)
            rsVal.add("search", search)

        End If

        cOldLoadingPanel.Visible = True

        _init_._initializing(cCol.forRsCRH,
                             rsVal.getValues(),
                             rsModel,
                             searchRsBgWorker,
                             cRsLabel)


        cBgWorkerChecker = BgWorkersCheckerFn(AddressOf RsOnlySuccessfullyDone, searchRsBgWorker)

    End Sub

#End Region

#Region "DONE"
    Private Sub RsSuccessfullyDone()
        Try
            cListOfRs = TryCast(rsModel.cData, List(Of PropsFields.rsdata_props_fields))
            cListOfWs = TryCast(wsModel.cData, List(Of PropsFields.withdrawal_props_fields))
            cListOfDr = TryCast(drModel.cData, List(Of PropsFields.dr_props_fields))
            cListOfPo = TryCast(poModel.cData, List(Of PropsFields.purchase_order_props_fields))
            cListOfRr = TryCast(rrModel.cData, List(Of PropsFields.receiving_props_fields))
            cListOfMainRs = TryCast(mainRsModel.cData, List(Of PropsFields.main_rsdata_props_fields))
            cListOfMainRsSub = TryCast(mainRsSubModel.cData, List(Of PropsFields.main_rsdata_props_fields))
            cListOfAllCharges = TryCast(cAllChargesModel.cData, List(Of PropsFields.AllCharges))
            cListOfWhArea = TryCast(whAreaStockpileModel.cData, List(Of PropsFields.whArea_stockpile_props_fields))

            displayWorker.WorkerSupportsCancellation = True
            displayWorker.RunWorkerAsync()

            'loadingPanel(False)

            If cOldLoadingPanel IsNot Nothing Then
                cOldLoadingPanel.Visible = False
                cRsLabel.Visible = False
                cWsLabel.Visible = False
                cDrLabel.Visible = False
                cPoLabel.Visible = False
                cMainRsLabel.Visible = False
            End If

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub RsOnlySuccessfullyDone()
        Try
            cListOfRs = CType(rsModel.cData, List(Of PropsFields.rsdata_props_fields))

            displayWorker.WorkerSupportsCancellation = True
            displayWorker.RunWorkerAsync()

            If cOldLoadingPanel IsNot Nothing Then
                cOldLoadingPanel.Visible = False
                cRsLabel.Visible = False
                cWsLabel.Visible = False
                cDrLabel.Visible = False
                cPoLabel.Visible = False
                cMainRsLabel.Visible = False
            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub


#End Region

#Region "PREVIEW"
    Private Sub previewDr()

        For Each mainRs In cListOfMainRs

            cRemaining_Balance = mainRs.main_rs_qty
            Dim bb(50) As String
            bb(0) = mainRs.main_rs_qty_id
            bb(1) = mainRs.rs_no
            bb(5) = IIf(mainRs.open_close_qty = 1, "OPEN QTY", mainRs.main_rs_qty)
            bb(37) = "Main RS Qty:"

            Dim lvl As New ListViewItem(bb)
            lvl = customListviewItem(Color.Lime, bb, FontStyle.Bold, 12, Color.Black)

            cListOfListviewItem.Add(lvl) '==> MAIN RS (LIME)

            For Each mainRsSub In cListOfMainRsSub
                If mainRsSub.main_rs_qty_id = mainRs.main_rs_qty_id Then
                    For Each aggdata In cListOfRs
                        If aggdata.rs_id = mainRsSub.rs_id Then
                            cTotal_Dr = 0
                            cTotal_RR = 0
                            cTotal_Dr2 = 0

                            sub_rs(aggdata.rs_id,
                                   IIf(mainRs.open_close_qty = 1,
                                       "OPEN QTY", "CLOSE QTY")) '==> SUB RS (DARK GREEN)

                        End If
                    Next

                    'BALANCE SA MAIN RS
                    Dim c(50) As String
                    c(0) = "-"
                    c(4) = "-"
                    ' c(5) = "=> " & IIf(mainqty.open_close_qty = 1, "N/A", cRemaining_Balance)
                    c(5) = "=> " & IIf(mainRs.open_close_qty = 1, "N/A", Math.Round(cRemaining_Balance, 6))
                    c(32) = cTotal_Dr2 + cTotal_Dr
                    c(37) = "Remaining Balance:"

                    Dim lvl3 As New ListViewItem(c)
                    lvl3 = customListviewItem(Color.White, c, FontStyle.Bold, 12, Color.DarkGreen)

                    cListOfListviewItem.Add(lvl3) '==> REMAINING BALANCE (WHITE)
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
        cListOfListviewItem.Add(lvl2)
        cTotal_Dr2 = 0
        cTotal_RR = 0

        'MGA WALA PA NA SETUP OG MAINRS NGA ITEMS
        For Each RS In cListOfRs
            Dim i As Integer = 0

            For Each aggsub In cListOfMainRsSub
                If aggsub.rs_id = RS.rs_id Then
                    i += 1
                End If
            Next

            If i = 0 Then
                sub_rs(RS.rs_id)
            End If
        Next

        If cListview.InvokeRequired Then
            cListview.Invoke(Sub()
                                 cListview.Items.AddRange(cListOfListviewItem.ToArray)
                             End Sub)
        Else
            cListview.Items.AddRange(cListOfListviewItem.ToArray)
        End If

        disableEnableWhileLoading(cSomeComponents.getValues(), True)

    End Sub

    Private Sub previewRsOnly()
        For Each row In cListOfRs
            Dim trd As Threading.Thread
            trd = New Threading.Thread(AddressOf sub_rs)
            trd.Start(row.rs_id)
            'sub_rs(row.rs_id)
        Next

        If cListview.InvokeRequired Then
            cListview.Invoke(Sub()
                                 cListview.Items.AddRange(cListOfListviewItem.ToArray)
                                 loadingPanel(False)
                             End Sub)
        Else
            cListview.Items.AddRange(cListOfListviewItem.ToArray)
            loadingPanel(False)
        End If

        disableEnableWhileLoading(cSomeComponents.getValues(), True)
    End Sub

    Private Sub sub_rs(rs_id As Integer, Optional openclose As String = "")

        Dim sortedrs = From RS In cListOfRs
                       Select RS Order By RS.rs_date, RS.item_desc Ascending

        Dim sortws = From WS In cListOfWs
                     Select WS Order By WS.ws_date Ascending

        Dim sortpo = From PO In cListOfPo
                     Select PO Order By PO.po_date Ascending

        For Each req In sortedrs
            Dim rsProperName As String = getProperNameUsingWhId(req.wh_id)

            If rs_id = req.rs_id Then

 #Region "==> RS"
                '==> RS
                Dim a(50) As String

                With req
                    Dim wh_pn_id As Integer = Utilities.ifBlankReplaceToZero(.wh_pn_id)
                    Dim properNameWithoutWhId = Results.cListOfProperNaming.Where(Function(x) x.wh_pn_id = wh_pn_id).ToList()

                    Dim shouldProcessRsRow As Boolean = False
                    Dim shouldProcessDrRow As Boolean = False
                    Dim shouldDeductBalance As Boolean = False

                    With req
                        'IN (DR) -> RS
                        If Not .inout = cInOut._IN AndAlso
                           Not .type_of_purchasing = cTypeOfPurchasing.DR AndAlso
                           Not String.IsNullOrEmpty(.request_type) AndAlso
                           Not String.IsNullOrEmpty(.process) Then

                            shouldProcessRsRow = True
                            shouldDeductBalance = True

                            'IN OR OTHERS
                        ElseIf .inout = cInOut._IN OrElse .inout = cInOut._OTHERS Then

                            'RS -> DR (with balance)
                            If .type_of_purchasing = cTypeOfPurchasing.DR AndAlso
                               Not String.IsNullOrEmpty(.request_type) AndAlso
                               Not String.IsNullOrEmpty(.process) Then

                                shouldProcessRsRow = True
                                shouldProcessDrRow = True
                                shouldDeductBalance = True

                                'RS
                            ElseIf .type_of_purchasing = cTypeOfPurchasing.PURCHASE_ORDER Then
                                shouldProcessRsRow = True
                            End If

                        ElseIf Not String.Equals(.rs_no, "N/A", StringComparison.OrdinalIgnoreCase) Then
                            shouldProcessRsRow = True
                        End If

                        If shouldProcessRsRow Then
                            forRsRow(req, openclose)
                        End If

                        If shouldProcessDrRow Then
                            forDrRow(Nothing, req, Nothing)
                        End If

                        If shouldDeductBalance Then
                            cRemaining_Balance -= .rs_qty
                        End If

                    End With

                    'If Not .inout = cInOut._IN And
                    '    Not .type_of_purchasing = cTypeOfPurchasing.DR And
                    '    Not .request_type = "" And
                    '    Not .process = "" Then

                    '    forRsRow(req, openclose)
                    '    cRemaining_Balance -= req.rs_qty

                    'ElseIf .inout = cInOut._IN Or .inout = cInOut._OTHERS Then

                    '    If .type_of_purchasing = cTypeOfPurchasing.DR And
                    '        .request_type <> "" And
                    '        .process <> "" Then

                    '        forRsRow(req, openclose)
                    '        forDrRow(Nothing, req, Nothing)

                    '        cRemaining_Balance -= req.rs_qty

                    '    ElseIf .type_of_purchasing = cTypeOfPurchasing.PURCHASE_ORDER Then
                    '        forRsRow(req, openclose)
                    '    End If

                    'Else
                    '    If Not req.rs_no.ToUpper() = "N/A" Then
                    '        forRsRow(req, openclose)
                    '    End If

                    'End If

                End With
#End Region

                Select Case req.inout
                    Case cInOut._OUT
                        'RS ==> WITHDRAWAL
                        Dim sortWsNew = sortws.Where(Function(x) x.rs_id = req.rs_id And x.wh_id = req.wh_id).ToList()

                        If sortWsNew.Count > 0 Then
                            For Each withraw In sortWsNew
                                Dim b(50) As String

                                forWithdrawalRow(withraw, req)

                                'WS ===> DR
                                forDrRow(withraw, req)

                            Next
                        End If

                    Case cInOut._IN, cInOut._OTHERS

                        'RS ===> IN OR OTHERS
                        If req.type_of_purchasing = cTypeOfPurchasing.DR Then 'DR
                            'forDrRow(Nothing, req, Nothing)

                        ElseIf req.type_of_purchasing = cTypeOfPurchasing.PURCHASE_ORDER Then 'PURCHASEORDER

                            Dim sortPoNew = sortpo.Where(Function(x) x.rs_id = req.rs_id).ToList()
                            If sortPoNew.Count > 0 Then

                                For Each poNew In sortPoNew
                                    Dim c(50) As String

                                    'RS ===> PO
                                    forPurchaseOrderRow(poNew,, req)


                                Next
                            End If
                        End If
                End Select
            End If
        Next

    End Sub
#End Region

#Region "BUSINESS LOGIC"
    Private Sub forRsRow(Optional param_rs As PropsFields.rsdata_props_fields = Nothing, Optional openclose As String = "")

        With param_rs
            Dim a(50) As String
            Dim wh_pn_id As Integer = Utilities.ifBlankReplaceToZero(.wh_pn_id)
            Dim properNameWithoutWhId = Results.cListOfProperNaming.Where(Function(x) x.wh_pn_id = wh_pn_id).ToList()

            a(0) = .rs_id
            a(1) = .rs_no
            a(2) = .rs_date
            a(3) = .job_order_no
#Region "PROPERNAMING"
            a(4) = Utilities.formatProperNamingNew_RS_WS_RR_DR(wh_pn_id,
                                                                .wh_id,
                                                                .rs_items,
                                                                .item_desc)
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
            lvl = customListviewItem(cRsRowColor.MainSubRS, a, FontStyle.Bold, 12, Color.White)

            cListOfListviewItem.Add(lvl)
        End With

    End Sub

    Private Sub forWithdrawalRow(Optional param_ws As PropsFields.withdrawal_props_fields = Nothing,
                                 Optional param_rs As PropsFields.rsdata_props_fields = Nothing)

        Dim rsProperName As String = getProperNameUsingWhId(param_rs.wh_id)
        'Dim wsReleased = cListOfWsReleasedItems.Where(Function(x) x.ws_id = param_ws.ws_id).ToList()
        'Dim status As String

        'If wsReleased.Count > 0 Then
        '    status = "withdrawn"
        'Else
        '    status = "pending"
        'End If

        Dim b(50) As String

        With param_ws
            b(0) = .rs_id
            b(1) = param_rs.rs_no
            b(2) = .ws_date
            b(3) = "-"
            b(4) = $"{ param_rs.item_desc } ({rsProperName})" '$"{IIf(rsProperName = "", $"{param_rs.item_name } - {param_rs.item_desc }", $"{rsProperName}")}"
            b(5) = "-"
            b(6) = param_rs.unit2.ToLower
            b(7) = "-"
            b(9) = param_rs.inout
            b(10) = "-"
            b(11) = "-"
            b(12) = IIf(.qty_withdrawn = 0, "pending", IIf(.qty_withdrawn > 0 And .qty_withdrawn < .ws_qty, "partially withdrawn", "withdrawn"))
            b(13) = param_rs.charges
            b(14) = "-"
            b(15) = param_rs.wh_id
            b(16) = param_ws.ws_date_log
            b(18) = param_rs.type_of_purchasing
            b(19) = .remarks
            b(20) = param_rs.source
            b(22) = .ws_qty
            b(23) = .qty_withdrawn
            b(24) = .users
            b(28) = param_rs.requested_by
            b(29) = param_rs.cons_item
            b(30) = param_rs.cons_item_desc
            b(33) = param_rs.wh_area
            b(36) = .ws_no
            b(41) = .dr_option
            b(43) = FormatNumber(.unit_price, 2,,, TriState.False)

            Dim lvl As New ListViewItem
            lvl = customListviewItem(cRsRowColor.WsPo, b, FontStyle.Regular, 11, Color.Black)

            cListOfListviewItem.Add(lvl)
        End With

    End Sub

    Private Sub forPurchaseOrderRow(Optional param_po As PropsFields.purchase_order_props_fields = Nothing,
                                    Optional param_rr As PropsFields.receiving_props_fields = Nothing,
                                    Optional param_rs As PropsFields.rsdata_props_fields = Nothing)

        Dim b(50) As String
        Dim rsProperName As String = getProperNameUsingWhId(param_rs.wh_id)

        With param_po
            b(0) = .rs_id
            b(1) = param_rs.rs_no
            b(2) = .po_date
            b(3) = "-"
            b(4) = $"{param_rs.item_desc} ({rsProperName})"
            b(5) = "-"
            b(6) = param_po.unit.ToLower
            b(7) = "-"
            b(9) = param_po.inout
            b(10) = "-"
            b(11) = "-"
            b(12) = "released"
            b(13) = param_po.charges
            b(14) = "-"
            b(15) = param_rs.wh_id
            b(16) = "date logs here"
            b(18) = param_rs.type_of_purchasing
            b(19) = .remarks
            b(20) = "-"
            b(22) = .qty
            b(23) = "-"
            b(24) = .user_logs
            b(28) = param_rs.requested_by
            b(29) = param_rs.cons_item
            b(30) = param_rs.cons_item_desc
            b(33) = param_rs.wh_area
            b(35) = param_po.po_det_id
            b(36) = param_po.po_no
            b(41) = "-"
            b(43) = param_po.unit_price 'FormatNumber(.price, 2,,, TriState.False)

            Dim lvl As New ListViewItem
            lvl = customListviewItem(cRsRowColor.WsPo, b, FontStyle.Regular, 11, Color.Black)

            cListOfListviewItem.Add(lvl)

            'PO ===> RR
            forReceivingRow(param_po, param_rs)
        End With
    End Sub

    Private Sub forReceivingRow(Optional param_po As PropsFields.purchase_order_props_fields = Nothing,
                                Optional param_rs As PropsFields.rsdata_props_fields = Nothing)

        Dim rsProperName As String = getProperNameUsingWhId(param_rs.wh_id)

        Dim sortRR = From RR In cListOfRr
                     Select RR Order By RR.date_received Ascending

        Dim b(50) As String

        Dim sorRRNew = sortRR.Where(Function(x) x.po_det_id = param_po.po_det_id).ToList()

        If sorRRNew.Count > 0 Then
            For Each rr In sorRRNew
                b(0) = param_rs.rs_id
                b(1) = param_rs.rs_no
                b(2) = rr.date_received
                b(3) = "-"
                b(4) = $"{param_rs.item_desc} ({ rsProperName })"
                b(5) = "-"
                b(6) = param_po.unit.ToLower
                b(7) = "-"
                b(9) = param_rs.inout
                b(10) = "-"
                b(11) = "-"
                b(12) = "received"
                b(13) = param_rs.charges
                b(14) = "-"
                b(15) = param_rs.wh_id
                b(16) = "date log here"
                b(18) = param_rs.type_of_purchasing
                b(19) = rr.remarks
                b(20) = "-"
                b(22) = "-"
                b(23) = rr.rr_qty
                b(24) = "User here"
                b(28) = param_rs.requested_by
                b(29) = param_rs.cons_item
                b(30) = param_rs.cons_item_desc
                b(33) = param_rs.wh_area
                b(35) = rr.rr_item_id
                b(36) = rr.rr_no
                b(41) = "-"
                b(43) = rr.price 'FormatNumber(.price, 2,,, TriState.False)

                Dim lvl As New ListViewItem
                lvl = customListviewItem(cRsRowColor.Rr, b, FontStyle.Regular, 11, Color.Black)

                cListOfListviewItem.Add(lvl)
                cTotal_RR += rr.rr_qty

                'RR ===> DR
                forDrRow(, param_rs, rr)
            Next
        End If

    End Sub

    Private Sub forDrRow(Optional param_ws As PropsFields.withdrawal_props_fields = Nothing,
                         Optional param_rs As PropsFields.rsdata_props_fields = Nothing,
                         Optional param_rr As PropsFields.receiving_props_fields = Nothing)

        '********** NOTE **************

        ' stockpile: OUT: row.source
        ' requestor: IN: row.requestor_without_rs
        ' quary source: row.source2

        '*****************************


        Dim sortDrNew As New List(Of PropsFields.dr_props_fields)

        Dim sortdr = From A In cListOfDr
                     Select A Order By A.dr_date, A.dr_no, A.dr_item_id Ascending

        If param_ws IsNot Nothing Then
            sortDrNew = sortdr.Where(Function(x) x.ws_no = param_ws.ws_no And x.rs_id = param_ws.rs_id).ToList()
        End If

        If param_rr IsNot Nothing Then
            sortDrNew = sortdr.Where(Function(x) x.rr_no = param_rr.rr_no And x.rs_id = param_rr.rs_id).ToList()
        End If

        If param_rr Is Nothing And param_ws Is Nothing And param_rs IsNot Nothing Then
            sortDrNew = sortdr.Where(Function(x) x.rs_id = param_rs.rs_id).ToList()
        End If

        Dim rsProperName As String = getProperNameUsingWhId(param_rs.wh_id)

        If sortDrNew.Count > 0 Then


            For Each row In sortDrNew


                Dim c(50) As String

                c(0) = row.rs_id
                c(1) = row.rs_no
                c(2) = row.dr_date
                c(3) = "-"
                c(4) = $"- {row.item_desc} ({rsProperName})"
                c(5) = "-"
                c(6) = row.unit.ToLower()
                c(7) = "-"
                c(9) = row.inout
                c(15) = row.wh_id
                c(16) = row.dr_date_log
                c(19) = row.remarks
                c(21) = row.dr_no
                c(24) = row.input_user
                c(28) = param_rs.requested_by
                c(29) = param_rs.cons_item
                c(30) = param_rs.cons_item_desc
                c(32) = row.dr_qty
                c(33) = row.quarry
                c(36) = row.ws_no
                c(41) = row.dr_option
                c(42) = row.dr_item_id
                c(43) = row.price

                If param_ws IsNot Nothing Then
                    c(36) = row.ws_no
                ElseIf param_rr IsNot Nothing Then
                    c(13) = param_rr.charges
                    c(36) = row.rr_no
                End If

                Dim isWithdrawalWithDr As Boolean

                Select Case param_rs.inout
                    Case cInOut._OUT
                        If row.dr_option = "WITH DR" Then
                            isWithdrawalWithDr = True
                        End If
                End Select
                If isWithdrawalWithDr Then

#Region "SOURCE"
                    c(20) = $"{row.quarry} - {getSourceFromWarehouseArea(row.wh_area_id)}"
#End Region

#Region "CHARGES"

#End Region


                End If



                Dim lvl As New ListViewItem
                lvl = customListviewItem(cRsRowColor.Dr, c, FontStyle.Regular, 11, Color.Black)

                cListOfListviewItem.Add(lvl)
                cTotal_Dr += row.dr_qty

                'checking if this are stockpile to stockpile
                If row.inout = cInOut._OUT Then
                    Dim drInData = cListOfDr.Where(Function(x) x.dr_no = row.dr_no And x.inout = cInOut._IN).ToList()

                    If drInData.Count > 0 Then 'if stockpile to stockpile
                        Dim cc(50) As String
                        Dim rsProperName2 As String = getProperNameUsingWhId(drInData(0).wh_id)


                        cc(0) = drInData(0).rs_id
                        cc(1) = drInData(0).rs_no
                        cc(2) = drInData(0).dr_date
                        cc(3) = "-"
                        cc(4) = $"+ {drInData(0).item_desc} ({rsProperName2})"
                        cc(5) = "-"
                        cc(6) = drInData(0).unit.ToLower()
                        cc(7) = "-"
                        cc(9) = drInData(0).inout
#Region "CHARGES"
                        cc(13) = row.requestor 'drInData(0).requestor_without_rs
#End Region

                        cc(15) = drInData(0).wh_id
                        cc(16) = drInData(0).dr_date_log
                        cc(19) = drInData(0).remarks

#Region "SOURCE"
                        cc(20) = c(20)
#End Region

                        cc(21) = drInData(0).dr_no
                        cc(24) = drInData(0).input_user
                        cc(28) = param_rs.requested_by
                        cc(29) = param_rs.cons_item
                        cc(30) = param_rs.cons_item_desc
                        cc(32) = drInData(0).dr_qty
                        cc(33) = "-"
                        cc(36) = drInData(0).ws_no
                        cc(41) = row.dr_option
                        cc(42) = drInData(0).dr_item_id
                        cc(43) = drInData(0).price

                        If param_ws IsNot Nothing Then
                            c(36) = row.ws_no
                        ElseIf param_rr IsNot Nothing Then
                            c(36) = row.rr_no
                        End If

                        Dim lvl2 As New ListViewItem
                        lvl2 = customListviewItem(cRsRowColor.Dr_sts, cc, FontStyle.Regular, 11, Color.Black)

                        cListOfListviewItem.Add(lvl2)
                    End If
                End If
                'Next
            Next
        End If

        'for rr balance
        If param_rr IsNot Nothing Then
            Dim dd As String()
            dd = Utilities.addSlashToColumn(cListview.Columns.Count - 1)
            dd(23) = $"RR: +{cTotal_RR}"

                        Dim lvl3 As New ListViewItem
            lvl3 = customListviewItem(Color.LightYellow, dd, FontStyle.Bold, 11, Color.DarkGreen)
            cListOfListviewItem.Add(lvl3)
        End If

    End Sub

    Public Function getRemainingBalance(main_rs_qty_id As Integer) As Double

        Dim mainRs = cListOfMainRs.Where(Function(x) x.main_rs_qty_id = main_rs_qty_id).ToList()
        Dim mainRsQty As Double

        If mainRs.Count > 0 Then
            mainRsQty = mainRs(0).main_rs_qty
        End If

        Dim mainRsSub = cListOfMainRsSub.Where(Function(x) x.main_rs_qty_id = main_rs_qty_id).ToList()

        If mainRsSub.Count > 0 Then
            For Each subRs In mainRsSub
                For Each req In cListOfRs
                    If subRs.rs_id = req.rs_id Then
#Region "==> RS"
                        '==> RS
                        Dim a(50) As String

                        With req

                            If Not .inout = cInOut._IN And
                                Not .type_of_purchasing = cTypeOfPurchasing.DR And
                                Not .request_type = "" And
                                Not .process = "" Then

                                'forRsRow(req, openclose)
                                getRemainingBalance += req.rs_qty
                            ElseIf .inout = cInOut._IN Or .inout = cInOut._OTHERS Then

                                If .type_of_purchasing = cTypeOfPurchasing.DR And
                                    .request_type <> "" And
                                    .process <> "" Then

                                    'forRsRow(req, openclose)
                                    getRemainingBalance += req.rs_qty

                                ElseIf .type_of_purchasing = cTypeOfPurchasing.PURCHASE_ORDER Then
                                    'forRsRow(req, openclose)
                                    getRemainingBalance += req.rs_qty
                                End If

                            Else
                                If Not req.rs_no.ToUpper() = "N/A" Then
                                    'forRsRow(req, openclose)
                                    getRemainingBalance += req.rs_qty
                                End If

                            End If
                        End With
#End Region
                    End If
                Next
            Next
        End If

        Return mainRsQty - getRemainingBalance

    End Function

    Private Function getSourceFromAllCharges(category As String, id As Integer) As String
        Try
            Dim sourceArea = cListOfAllCharges.FirstOrDefault(Function(x)
                                                                  Return x.charges_category.ToUpper() = category.ToUpper() And
                                                                          x.charges_id = id
                                                              End Function)

            If sourceArea IsNot Nothing Then
                getSourceFromAllCharges = sourceArea.charges
            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Private Function getSourceFromWarehouseArea(id As Integer) As String
        Dim sourceArea = cListOfWhArea.FirstOrDefault(Function(x)
                                                          Return x.wh_area_id = id
                                                      End Function)

        If sourceArea IsNot Nothing Then
            getSourceFromWarehouseArea = $"{sourceArea.wh_area}"
        End If
    End Function
#End Region

#Region "OTHERS"

    Public Sub loadingPanel(Optional onOff As Boolean = False)
        If cPanel.InvokeRequired Then
            cPanel.Invoke(Sub()
                              cPanel.Visible = onOff
                              cRsSearchButton.Enabled = Not onOff
                          End Sub)
        Else
            cPanel.Visible = onOff
            cRsSearchButton.Enabled = Not onOff
        End If

    End Sub
    Public Sub clear()

        rsModel.clearParameter()
        poModel.clearParameter()
        wsModel.clearParameter()
        drModel.clearParameter()
        rrModel.clearParameter()
        cSomeComponents.clearParameter()

        mainRsModel.clearParameter()
        mainRsSubModel.clearParameter()

        cAllChargesModel.clearParameter()
        whAreaStockpileModel.clearParameter()

        cListOfListviewItem.Clear()
        cListview.Items.Clear()

        If cRsLabel IsNot Nothing Then
            initializingLabel(cRsLabel, "RS")
        End If

        If cWsLabel IsNot Nothing Then
            initializingLabel(cWsLabel, "WS")
        End If

        If cPoLabel IsNot Nothing Then
            initializingLabel(cPoLabel, "PO")
        End If

        If cDrLabel IsNot Nothing Then
            initializingLabel(cDrLabel, "DR")
        End If

        If cMainRsLabel IsNot Nothing Then
            initializingLabel(cMainRsLabel, "MRS")
        End If

    End Sub

    Private Sub initializingLabel(label As Label,
                                  caption As String)
        label.Visible = True
        label.ForeColor = Color.Black
        label.Font = New Font(cFontsFamily.arial, 10, FontStyle.Bold)
        label.Text = $"{caption}: □□□□□ %"
        label.BackColor = Color.Orange

    End Sub
#End Region

End Class
