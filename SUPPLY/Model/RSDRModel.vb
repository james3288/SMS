Imports System.ComponentModel
Imports SUPPLY.class_charges
Imports SUPPLY.PropsFields
Imports SUPPLY.pubEnum

Public Class RSDRModel
    Private rsForDrModel,
        wsForDrModel,
        drForDrModel,
        poForDrModel,
        allChargesModel,
        properNamingModel,
        whItemsModel,
        typeOfRequestModel,
        userModel,
        rrForDrModel,
        mainRsDrModel,
        mainRsSubDrModel,
        ConsolidationAccountModel,
        AggregatesPricesModel,
        partiallyReleasedWithdrawnModel,
        withdrawnModel,
        cancelledTransactionModel,
        supplierModel As New ModelNew.Model

    Public rsDrBackgroundWorker, othersBackgroundWorker As New List(Of BackgroundWorker)
    Dim cBgWorkerChecker, cBgWorkerChecker2 As Timer
    Private cSearch, cSearchBy As String
    Private cDgv As New DataGridView

    Private cListOfRsForDr As New List(Of PropsFields.rs_for_dr_props_fields)
    Private cListOfWsForDr As New List(Of PropsFields.ws_for_dr_props_fields)
    Private cListOfPoForDr As New List(Of PropsFields.po_for_dr_props_fields)
    Private cListOfDrForDr As New List(Of PropsFields.dr_for_dr_props_fields)
    Private cListOfAllCharges As New List(Of PropsFields.AllCharges)
    Private cListOfWarehouseItems As New List(Of PropsFields.whItems_props_fields)
    Private cListOfProperNames As New List(Of PropsFields.whItems_properName_fields)
    Private cListOfTypeOfRequest As New List(Of PropsFields.TypeOfRequest)
    Private cListOfUsers As New List(Of PropsFields.smsUsers_props_fields)
    Private cListOfConsolidationAccount As New List(Of PropsFields.Consolidated_Account)
    Private cListOfAggregatesPrices As New List(Of PropsFields.aggregatesPrices_props_fields)
    Private cListOfPartiallyReleasedWithdrawn As New List(Of PropsFields.partiallyReleasedWithdrawal_props_fields)
    Private cListOfCancelledTransaction As New List(Of PropsFields.CancelledTransaction)
    Private cListOfSuppliers As New List(Of PropsFields.supplier_props_fields)

    Private cListOfReceiving As New List(Of PropsFields.receiving_props_fields)
    Private cListOfMainRs As New List(Of PropsFields.main_rsdata_props_fields)
    Private clistOfMainRsSub As New List(Of PropsFields.main_rsdata_props_fields)
    Private cListOfRsData As New List(Of PropsFields.rsdata_props_fields)
    Private listOfRsDatas As New List(Of COLUMNS)
    Private listOfRsDatasForCharges As New List(Of COLUMNS)

    Public listOfCuratedRsDatas As New List(Of CURATED_RS)


    Private cListOfRsLeft As New List(Of MAIN_RS_LEFT)
    Private customMsg As New customMessageBox

    Private customDatagrid,
        customDatagridForPo,
        customDatagridForRr As New CustomGridview

    Private cLevel As New ROWLEVEL
    Private cLoadingPanel As New Panel
    Private cSearchPanel As New Panel

    Private _rsQuantityLeft As Double
    Private isClosedQty As Boolean
    Public isItemChecked As Boolean
    Public isRemovedItemChecked As Boolean
    Public isUpdate As Boolean
    Public isCreateRsAndAddCharges As Boolean
    Public isCreateWithdrawal, isUpdateWithdrawal As Boolean
    Public isCreatePurchasedOrder As Boolean
    Public isCreateReceiving As Boolean
    Public isCreateWithdrawalForWarehousing As Boolean
    Public isCreateDr As Boolean
    Public isCancelRs, isCancelPo, isCancelWs As Boolean
    Public isUpdateRsQtyOnly As Boolean

    Public cRsId As Integer

    Public isSearchByCharges As Boolean
    Public isDone As Boolean

    Public cn As New COLUMNS
    Public RawPoRows As New List(Of PropsFields.Purchase_Order_Row)
    Public RawRrRows As New List(Of PropsFields.Receiving_row)
    Public cRsColumnSettings As New ColumnSettingsLib

#Region "CORE ENTITIES"
    Public Class ROWLEVEL
        Public ReadOnly Property main_rs As String = "main-rs"
        Public ReadOnly Property sub_rs As String = "sub-rs"
        Public ReadOnly Property ws As String = "ws"
        Public ReadOnly Property po As String = "po"
        Public ReadOnly Property rr As String = "rr"
        Public ReadOnly Property dr_out As String = "ws-dr-out"
        Public ReadOnly Property dr_in As String = "ws-dr-in"
        Public ReadOnly Property dr_others As String = "dr-others"
        Public ReadOnly Property total_delivered_row As String = "total-delivered-row"
        Public ReadOnly Property total_received_row As String = "total-received-row"
        Public ReadOnly Property pw As String = "partially-withdrawn"


    End Class
    Public Class COLUMNS
        Public Property rs_id As String
        Public Property rs_no As String
        Public Property ws_no As String
        Public Property rr_no As String
        Public Property dr_no As String
        Public Property rs_ws_po_rr_dr_date As String
        Public Property date_needed As String
        Public Property jobOrderNo As String
        Public Property type_of_purchasing As String
        Public Property item_desc As String
        Public Property proper_names As String
        Public Property itemCheckedTo As String
        Public Property rs_qty As String
        Public Property po_cv_ws_qty_released As String
        Public Property rr_ws_qty_received As String
        Public Property dr_qty As String
        Public Property price As String
        Public Property amount As String
        Public Property units As String
        Public Property purpose As String
        Public Property type_of_request As String
        Public Property inOut As String
        Public Property po_cv_status As String
        Public Property rr_status As String
        Public Property ws_status As String
        Public Property quarry As String
        Public Property source As String
        Public Property charges As String
        Public Property location As String
        Public Property wh_id As String
        Public Property date_log As String
        Public Property type_of_charges As String
        Public Property supplier As String
        Public Property remarks As String
        Public Property remarks_for_emd As String
        Public Property users As String
        Public Property requested_by As String
        Public Property dr_option As String
        Public Property dr_items_id As String
        Public Property item_checked_log As String
        Public Property level As String
        Public Property division As String
        Public Property main_rs_qty_id As Integer
        Public Property other_id As Integer
        Public Property rs_id_for_rr As Integer
        Public Property wh_pn_id_for_rs As Integer
        Public Property po_cancel_status As String
        Public Property updatedBy As String
        Public Property dateLogUpdated As String
    End Class
    Private Class MAIN_RS_LEFT
        Public Property main_rs_qty_id As Integer
        Public Property rsNo As String
        Public Property balance As Double
        Public Property isOpen As Boolean

    End Class
    Public Class CURATED_RS
        Public Property rsId As Integer
        Public Property listOfRs As List(Of COLUMNS)
    End Class

#End Region

#Region "INITIALIZE AND PREVIEW"

    Public Sub initialize_searchPanel(searchPanel As Panel)
        cSearchPanel = searchPanel
    End Sub
    Public Sub initialize(searchBy As String,
                          search As String,
                          Optional dgv As DataGridView = Nothing)

        cSearch = search
        cSearchBy = searchBy
        cDgv = dgv

        customDatagrid.customDatagridview(cDgv,,, 10)
    End Sub

    Private Sub clearInitialModels()
        Try

            allChargesModel.clearParameter()
            properNamingModel.clearParameter()
            whItemsModel.clearParameter()
            typeOfRequestModel.clearParameter()
            userModel.clearParameter()
            ConsolidationAccountModel.clearParameter()
            AggregatesPricesModel.clearParameter()
            cancelledTransactionModel.clearParameter()
            supplierModel.clearParameter()

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
    Public Sub execute_initialize(Optional loadingPanel As Panel = Nothing)
        Try
            clearInitialModels()

            Dim allChargesValues,
                propernameValues,
                warehouseItemsVlaues,
                typeofrequestvalues,
                consolidationValues,
                usersValues,
                areaStockpileValues,
                priceZoning,
                cancelledTransactionValues,
                supplierValues As New ColumnValues

            consolidationValues.add("crud", 7)
            consolidationValues.add("search", "")

            cLoadingPanel = loadingPanel
            cLoadingPanel.Visible = True
            cSearchPanel.Enabled = False

            _initializing(cCol.forAllCharges,
                          allChargesValues.getValues(),
                          allChargesModel,
                          othersBackgroundWorker)

            _initializing(cCol.forWhItem_ProperNames,
                          propernameValues.getValues(),
                          properNamingModel,
                          othersBackgroundWorker)

            _initializing(cCol.forWhItems,
                    warehouseItemsVlaues.getValues(),
                    whItemsModel,
                    othersBackgroundWorker)

            _initializing(cCol.forTypeOfRequest,
                      typeofrequestvalues.getValues(),
                      typeOfRequestModel,
                      othersBackgroundWorker)

            _initializing(cCol.forSmsUsers,
                      usersValues.getValues(),
                      userModel,
                      othersBackgroundWorker)

            _initializing(cCol.forConsolidationAccount,
                      consolidationValues.getValues(),
                      ConsolidationAccountModel,
                      othersBackgroundWorker)

            _initializing(cCol.forAggPrices,
                          priceZoning.getValues(),
                          AggregatesPricesModel,
                          othersBackgroundWorker)

            _initializing(cCol.forCancelRs,
                          cancelledTransactionValues.getValues(),
                          cancelledTransactionModel,
                          othersBackgroundWorker)

            _initializing(cCol.forSupplier,
                          supplierValues.getValues(),
                          supplierModel,
                          othersBackgroundWorker)

            cBgWorkerChecker2 = BgWorkersCheckerFn(AddressOf SuccessfullyInitialize, othersBackgroundWorker)
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
    Public Sub execute()
        Try
            clearModels()
            cDgv.DataSource = Nothing
            cLoadingPanel.Visible = True
            cSearchPanel.Enabled = False

            Dim rsValues,
                mainRsValues,
                mainRsSubValues,
                wsValues,
                rrValues,
                drValues,
                poValues,
                partiallyWithdrawnValues As New ColumnValues


            rsValues.add("n", 1)
            rsValues.add("search", cSearch)
            rsValues.add("searchBy", cSearchBy)

            wsValues.add("n", 2)
            wsValues.add("search", cSearch)
            wsValues.add("searchBy", cSearchBy)

            poValues.add("n", 4)
            poValues.add("search", cSearch)
            poValues.add("searchBy", cSearchBy)

            drValues.add("n", 3)
            drValues.add("search", cSearch)
            drValues.add("searchBy", cSearchBy)

            rrValues.add("n", 5)
            rrValues.add("search", cSearch)
            rrValues.add("searchBy", cSearchBy)

            mainRsValues.add("n", 7)
            mainRsValues.add("search", cSearch)

            mainRsSubValues.add("n", 6)
            mainRsSubValues.add("search", cSearch)

            partiallyWithdrawnValues.add("search", cSearch)
            partiallyWithdrawnValues.add("searchBy", cSearchBy)


            'FOR MAIN RS
            _initializing(cCol.forMainRsCRH2,
                mainRsValues.getValues(),
                mainRsDrModel,
                rsDrBackgroundWorker)

            'FOR SUB MAIN RS
            _initializing(cCol.forMainRsSubCRH2,
                mainRsSubValues.getValues(),
                mainRsSubDrModel,
                rsDrBackgroundWorker)

            'FOR SUB RS
            _initializing(cCol.forRsDr,
                rsValues.getValues(),
                rsForDrModel,
                rsDrBackgroundWorker)

            'FOR WITHDRAWAL
            _initializing(cCol.forWsDr,
                wsValues.getValues(),
                wsForDrModel,
                rsDrBackgroundWorker)

            'FOR PO
            _initializing(cCol.forPoDr,
                poValues.getValues(),
                poForDrModel,
                rsDrBackgroundWorker)

            'FOR RR
            _initializing(cCol.forRrDr,
                rrValues.getValues(),
                rrForDrModel,
                rsDrBackgroundWorker)

            'FOR DR
            _initializing(cCol.forDrDr,
                drValues.getValues(),
                drForDrModel,
                rsDrBackgroundWorker)

            'FOR PARTIAL RELEASED/WITHDRAWN
            _initializing(cCol.forPartiallyReleasedWithdrawal,
                                 partiallyWithdrawnValues.getValues(),
                                 partiallyReleasedWithdrawnModel,
                                 WhItemsBgWorker)

            'reload this initialization for cancelling rs
            If isCancelRs Or isCancelPo Or isCancelWs Then
                Dim cancelledTransactionValues As New ColumnValues

                cListOfCancelledTransaction.Clear()
                cancelledTransactionModel.clearParameter()

                _initializing(cCol.forCancelRs,
                         cancelledTransactionValues.getValues(),
                         cancelledTransactionModel,
                         othersBackgroundWorker)
            End If


            cBgWorkerChecker = BgWorkersCheckerFn(AddressOf SuccessfullyDone, rsDrBackgroundWorker)

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
    Private Sub SuccessfullyInitialize()
        Try
            cListOfAllCharges = TryCast(allChargesModel.cData, List(Of PropsFields.AllCharges))
            cListOfProperNames = TryCast(properNamingModel.cData, List(Of PropsFields.whItems_properName_fields))
            cListOfWarehouseItems = TryCast(whItemsModel.cData, List(Of PropsFields.whItems_props_fields))
            cListOfTypeOfRequest = TryCast(typeOfRequestModel.cData, List(Of PropsFields.TypeOfRequest))
            cListOfUsers = TryCast(userModel.cData, List(Of PropsFields.smsUsers_props_fields))
            cListOfConsolidationAccount = TryCast(ConsolidationAccountModel.cData, List(Of PropsFields.Consolidated_Account))
            cListOfAggregatesPrices = TryCast(AggregatesPricesModel.cData, List(Of PropsFields.aggregatesPrices_props_fields))
            cListOfCancelledTransaction = TryCast(cancelledTransactionModel.cData, List(Of PropsFields.CancelledTransaction))
            cListOfSuppliers = TryCast(supplierModel.cData, List(Of PropsFields.supplier_props_fields))

            cLoadingPanel.Visible = False
            cSearchPanel.Enabled = True
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
    Private Sub SuccessfullyDone()
        Try
            cListOfRsForDr = TryCast(rsForDrModel.cData, List(Of PropsFields.rs_for_dr_props_fields))
            cListOfPoForDr = TryCast(poForDrModel.cData, List(Of PropsFields.po_for_dr_props_fields))
            cListOfWsForDr = TryCast(wsForDrModel.cData, List(Of PropsFields.ws_for_dr_props_fields))
            cListOfDrForDr = TryCast(drForDrModel.cData, List(Of PropsFields.dr_for_dr_props_fields))
            cListOfMainRs = TryCast(mainRsDrModel.cData, List(Of PropsFields.main_rsdata_props_fields))
            clistOfMainRsSub = TryCast(mainRsSubDrModel.cData, List(Of PropsFields.main_rsdata_props_fields))
            cListOfReceiving = TryCast(rrForDrModel.cData, List(Of PropsFields.receiving_props_fields))
            cListOfPartiallyReleasedWithdrawn = TryCast(partiallyReleasedWithdrawnModel.cData, List(Of PropsFields.partiallyReleasedWithdrawal_props_fields))

            'for cancel rs
            If isCancelRs Or isCancelPo Or isCancelWs Then
                cListOfCancelledTransaction = TryCast(cancelledTransactionModel.cData, List(Of PropsFields.CancelledTransaction))
            End If

            If cListOfRsForDr.Count = 0 Then
                customMsg.message("error", $"No rs no: {cSearch} has been found in the database...", "SUPPLY INFO:")
                reset()
                Exit Sub
            End If

            preview()
            reset()

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
    Private Sub preview()
        Dim rsData = getRsData()

        If rsData.Count > 0 Then
            RefactorAndPreview(rsData)
        End If
    End Sub

    Private Sub reset()
        cLoadingPanel.Visible = False
        cSearchPanel.Enabled = True
        isCancelRs = False
        isCancelPo = False
        isCancelWs = False
    End Sub

    Private Sub RefactorAndPreview(rsData As List(Of PropsFields.rs_for_dr_props_fields))

#Region "RESET"
        cListOfRsLeft.Clear()
        listOfRsDatas.Clear()
        _rsQuantityLeft = 0
        isClosedQty = False
#End Region

#Region "NAA NAY MGA MAIN RS NA ROWS"
        For Each mainRs In cListOfMainRs

            Dim _subRsDatas = clistOfMainRsSub.Where(Function(x) x.main_rs_qty_id = mainRs.main_rs_qty_id).ToList()

            Dim mainRsRow = MAINRS_ROW(, mainRs)

            listOfRsDatas.Add(mainRsRow)
            _rsQuantityLeft = mainRs.main_rs_qty

            For Each subRs In _subRsDatas
                Dim _subRs = rsData.FirstOrDefault(Function(x) x.rs_id = subRs.rs_id)

                'core logic
                businessLogic(_subRs,
                              mainRs.main_rs_qty_id)
            Next

#Region "MAIN RS LEFT STORAGE"
            Dim _rsLeft As New MAIN_RS_LEFT
            With _rsLeft
                .main_rs_qty_id = mainRs.main_rs_qty_id
                .rsNo = mainRs.rs_no
                .balance = _rsQuantityLeft
                .isOpen = IIf(mainRs.open_close_qty = 1, True, False)
            End With

            cListOfRsLeft.Add(_rsLeft)
#End Region

            _rsQuantityLeft = 0
        Next

#End Region

#Region "SPLIT ROW"
        Dim splitRow = SPLIT_ROW()
        listOfRsDatas.Add(splitRow)
        _rsQuantityLeft = 0
#End Region

#Region "WALA PAY MAIN RS NA ROWS"
        For Each rsRow In rsData
            Dim subRs = clistOfMainRsSub.FirstOrDefault(Function(x) x.rs_id = rsRow.rs_id)
            If subRs Is Nothing Then
                businessLogic(rsRow)
            End If
        Next
#End Region


        '<== for seach by charges ==>
        If isSearchByCharges Then
            Dim _curatedRs As New CURATED_RS

            ' Create a new independent copy of listOfRsDatas
            Dim _listOfRs As New List(Of COLUMNS)(listOfRsDatas)

            With _curatedRs
                .rsId = Utilities.ifBlankReplaceToZero(cSearch)
                .listOfRs = _listOfRs
            End With

            listOfCuratedRsDatas.Add(_curatedRs)

            isDone = False
            Exit Sub
        End If

        If listOfRsDatas.Count > 0 Then
            cDgv.DataSource = listOfRsDatas

            customizeGridView()

            'got focus if item checked
            If isItemChecked Or isRemovedItemChecked Or isCancelRs Or isCancelPo Or isCancelWs Then
                resetItemCheckedAndFocusRow()

                'got focus if update
            ElseIf isUpdate Then
                focusRowAfterUpdate()
                isUpdate = False

            ElseIf isCreateRsAndAddCharges Then
                focusRowAfterUpdate()
                isCreateRsAndAddCharges = False

            ElseIf isCreateWithdrawal Then
                focusRowAfterUpdate()
                isCreateWithdrawal = False

            ElseIf isCreatePurchasedOrder Then
                focusRowAfterUpdate()
                isCreatePurchasedOrder = False

            ElseIf isCreateReceiving Then
                focusRowAfterUpdate()
                isCreateReceiving = False

            ElseIf isCreateWithdrawalForWarehousing Then
                focusRowAfterUpdate()
                isCreateWithdrawalForWarehousing = False

            ElseIf isCreateWithdrawal Then
                focusRowAfterUpdate()
                isCreateWithdrawal = False

            ElseIf isUpdateRsQtyOnly Then
                focusRowAfterUpdate()
                isUpdateRsQtyOnly = False
            End If
        End If

    End Sub
#End Region

#Region "BUSINESS LOGIC"
    Private Sub businessLogic(rsRow As PropsFields.rs_for_dr_props_fields,
                              Optional main_rs_qty_id As Integer = 0)

        Try
            Dim _droption As String = ""

#Region "RS ROW"
            ADD_RS_ROW(rsRow, main_rs_qty_id)
#End Region

#Region "WS AND PO ROW"
            If rsRow IsNot Nothing Then
                If rsRow.inout = cInOut._OUT Then

                    ADD_WS_ROW(rsRow)

                ElseIf rsRow.inout = cInOut._OTHERS Or rsRow.inout = cInOut._IN Then

                    ADD_PO_CASH_WITH_RR_ROW(rsRow)

                End If
            End If
#End Region

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Public Sub clearModels()

        rsForDrModel.clearParameter()
        wsForDrModel.clearParameter()
        drForDrModel.clearParameter()
        allChargesModel.clearParameter()
        properNamingModel.clearParameter()
        whItemsModel.clearParameter()
        typeOfRequestModel.clearParameter()
        userModel.clearParameter()
        poForDrModel.clearParameter()
        rrForDrModel.clearParameter()
        mainRsDrModel.clearParameter()
        mainRsSubDrModel.clearParameter()
        partiallyReleasedWithdrawnModel.clearParameter()

        cListOfRsForDr.Clear()
        cListOfWsForDr.Clear()
        cListOfPoForDr.Clear()
        cListOfDrForDr.Clear()

        cListOfReceiving.Clear()
        cListOfMainRs.Clear()
        clistOfMainRsSub.Clear()
        cListOfRsData.Clear()
        listOfRsDatas.Clear()
        cListOfPartiallyReleasedWithdrawn.Clear()



    End Sub

    Private Sub resetItemCheckedAndFocusRow()
        Utilities.datagridviewSpecificRowFocus(cDgv, cRsId, NameOf(cn.rs_id))

        isItemChecked = False
        isRemovedItemChecked = False

        cRsId = 0
    End Sub

    Private Sub focusRowAfterUpdate()
        Utilities.datagridviewSpecificRowFocus(cDgv, cRsId, NameOf(cn.rs_id))
        cRsId = 0
    End Sub

#End Region

#Region "DATAGRIDVIEW ROWS"

    Private Function MAINRS_ROW(Optional rsRow As PropsFields.rs_for_dr_props_fields = Nothing,
                                Optional mainRsRow As PropsFields.main_rsdata_props_fields = Nothing) As COLUMNS
        Try

            Dim listOfSubMainRs = clistOfMainRsSub.Where(Function(x) x.main_rs_qty_id = mainRsRow.main_rs_qty_id).ToList()
            MAINRS_ROW = New COLUMNS

            With MAINRS_ROW
                .rs_id = mainRsRow.main_rs_qty_id
                .rs_no = mainRsRow.rs_no
#Region "RS QTY"
                If mainRsRow.open_close_qty = 1 Then
                    .rs_qty = "MAIN RS: OPEN"
                    isClosedQty = True
                Else
                    .rs_qty = $"MAIN RS: {mainRsRow.main_rs_qty}"
                    isClosedQty = False
                End If

#End Region

                .level = "main-rs"
            End With
            Return MAINRS_ROW
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

    End Function
    Private Function RS_ROW(rsRow As PropsFields.rs_for_dr_props_fields,
                            Optional main_rs_qty_id As Integer = 0) As COLUMNS
        RS_ROW = New COLUMNS

        Try
            If rsRow IsNot Nothing Then
                With RS_ROW
                    .rs_id = rsRow.rs_id
                    .rs_no = rsRow.rs_no
                    .rs_ws_po_rr_dr_date = rsRow.rs_date
                    .date_needed = rsRow.date_needed
                    .jobOrderNo = rsRow.job_order_no
                    .item_desc = $"{Utilities.isItemChecked(rsRow.wh_id)} {rsRow.rs_items}" '{oldWarehouseItemName(rsRow)}
                    .proper_names = $"{checkBox()} {rsRow.rs_properName}"
                    .itemCheckedTo = rsRow.itemCheckedTo
                    .rs_qty = rsRow.rs_qty
                    .units = rsRow.unit
                    .purpose = rsRow.purpose
                    .type_of_purchasing = rsRow.type_of_purchasing
                    .type_of_request = rsRow.type_of_request
                    .inOut = rsRow.inout
                    .charges = rsRow.charges
                    .wh_id = rsRow.wh_id
                    .date_log = is1990(rsRow.date_log)
                    .type_of_charges = rsRow.process
                    .users = rsRow.users
                    .requested_by = rsRow.requested_by
                    .item_checked_log = is1990(rsRow.item_checked_log)
                    .main_rs_qty_id = main_rs_qty_id
                    .level = cLevel.sub_rs
                    .division = rsRow.division
                    .wh_pn_id_for_rs = rsRow.wh_pn_id_for_rs
                    .remarks_for_emd = rsRow.remarks_for_emd
#Region "LOCATION"
                    Dim location = cListOfWarehouseItems.FirstOrDefault(Function(x) x.wh_id = .wh_id)
                    If location IsNot Nothing Then
                        .location = location.specific_loc
                    End If
#End Region
                    .price = FormatNumber(rsRow.price).ToString()
                    .updatedBy = getUsers(cListOfUsers, rsRow.user_id_updated)
                    .dateLogUpdated = is1990(Utilities.DateConverter(rsRow.date_log_updated))

#Region "AMOUNT FOR CASH WITH OR WITHOUT RR"
                    If rsRow.price <> 0 Then
                        .amount = FormatNumber(rsRow.price * rsRow.rs_qty).ToString()
                    Else
                        .amount = FormatNumber(rsRow.amount).ToString()
                    End If
#End Region

                End With
            End If


        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Private Function WS_ROW(rsRow As PropsFields.rs_for_dr_props_fields,
                              wsPoRow As PropsFields.ws_for_dr_props_fields) As COLUMNS

        WS_ROW = New COLUMNS

        Try
            With WS_ROW
                .rs_id = wsPoRow.ws_id
                .rs_no = rsRow.rs_no
                .ws_no = wsPoRow.ws_no
                .rs_ws_po_rr_dr_date = wsPoRow.ws_date
                .po_cv_ws_qty_released = wsPoRow.ws_qty
                .rr_ws_qty_received = IIf(wsPoRow.isQtyWithdrawn, wsPoRow.ws_qty, "pending")
                .price = FormatNumber(wsPoRow.price).ToString()
                .units = rsRow.unit

#Region "WITHDRAWAL STATUS"
                If rsRow.division = cDivision.WAREHOUSING_AND_SUPPLY Then
                    .ws_status = IIf(wsPoRow.isQtyWithdrawn, "released", "")
                Else
                    .ws_status = IIf(wsPoRow.isQtyWithdrawn, "withdrawn", "")
                End If
#End Region

                .charges = rsRow.charges
                .wh_id = wsPoRow.wh_id
                .date_log = wsPoRow.date_log
                .type_of_purchasing = rsRow.type_of_purchasing
                .inOut = rsRow.inout
                .item_desc = $"{rsRow.rs_items} {oldWarehouseItemName(rsRow)}"
                .proper_names = rsRow.item_desc
#Region "USER"
                Dim users = cListOfUsers.FirstOrDefault(Function(x) x.user_id = wsPoRow.user_id)
                If users IsNot Nothing Then
                    .users = $"{users.lName}, {users.fName}"
                End If
#End Region
                .requested_by = rsRow.requested_by
                .dr_option = wsPoRow.dr_option
                .level = cLevel.ws
                .other_id = rsRow.rs_id
                .division = rsRow.division
                .wh_id = rsRow.wh_id
                .updatedBy = getUsers(cListOfUsers, wsPoRow.user_id_update_logs)
                .dateLogUpdated = is1990(wsPoRow.date_log_updated)
            End With

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Private Function PW_ROW(rsRow As PropsFields.rs_for_dr_props_fields,
                            wsRow As PropsFields.ws_for_dr_props_fields,
                            pwRow As PropsFields.partiallyReleasedWithdrawal_props_fields) As COLUMNS
        PW_ROW = New COLUMNS
        Try
            With PW_ROW
                .rs_id = pwRow.partially_withdrawn_id
                .rs_ws_po_rr_dr_date = pwRow.dateWithdrawn
                .date_needed = "-"
                .rs_no = "-"
                .ws_no = wsRow.ws_no
                .jobOrderNo = "-"
                .item_desc = oldWarehouseItemName(rsRow)
                .proper_names = rsRow.item_desc
                .rr_ws_qty_received = pwRow.partially_withdrawn_qty
                .units = rsRow.unit
                .date_log = pwRow.dateLogWithdrawn

#Region "USER"
                Dim user = cListOfSmsUsers.FirstOrDefault(Function(x) x.user_id = pwRow.user_id)
                If user IsNot Nothing Then
                    .users = $"{user.lName}, {user.fName}"
                End If
#End Region
                .level = cLevel.pw
                .other_id = wsRow.ws_id
            End With
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Private Function PO_ROW(rsRow As PropsFields.rs_for_dr_props_fields,
                            PoRow As PropsFields.po_for_dr_props_fields) As COLUMNS

        PO_ROW = New COLUMNS

        Try
            With PO_ROW
                .rs_id = PoRow.po_det_id
                .rs_no = rsRow.rs_no
                .ws_no = PoRow.po_no
                .rs_ws_po_rr_dr_date = PoRow.po_date
                .po_cv_ws_qty_released = PoRow.po_qty
                .rr_ws_qty_received = "-"

#Region "PRICE"
                If PoRow.tax_category = "" Then
                    .price = PoRow.unit_price
                Else
                    .price = calculateTax(PoRow.tax_category, PoRow.unit_price, PoRow.vat_value)
                End If

#End Region

                .units = rsRow.unit
                .po_cv_status = "released"
                .charges = rsRow.charges
                .wh_id = PoRow.wh_id
                .date_log = PoRow.date_log
                .type_of_purchasing = rsRow.type_of_purchasing
                .inOut = rsRow.inout
                .users = useUser(PoRow.user_id)
                .requested_by = rsRow.requested_by
                .level = cLevel.po
                .other_id = rsRow.rs_id
                .item_desc = $"{rsRow.rs_items} {oldWarehouseItemName(rsRow)}"
                .proper_names = rsRow.item_desc
                .division = rsRow.division
                .po_cancel_status = PoRow.po_cancel_status
                .supplier = getSupplierById(PoRow.supplier_id)
                .updatedBy = getUsers(cListOfUsers, PoRow.user_id_update_logs)
                .dateLogUpdated = is1990(Utilities.DateConverter(PoRow.date_log_updated))
                .users = getUsers(cListOfUsers, PoRow.user_id)

            End With

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Private Function RR_ROW(rsRow As PropsFields.rs_for_dr_props_fields, rrRow As PropsFields.receiving_props_fields) As COLUMNS
        Try
            RR_ROW = New COLUMNS

            With RR_ROW
                .rs_id = rrRow.rr_item_id
                .rs_no = rsRow.rs_no
                .ws_no = "-"
                .rr_no = rrRow.rr_no
                .rs_ws_po_rr_dr_date = rrRow.date_received
                .po_cv_ws_qty_released = "-"
                .rr_ws_qty_received = rrRow.rr_qty
                .price = rrRow.price
                .units = rrRow.unit
                .rr_status = "received"
                .charges = rsRow.charges
                .wh_id = rsRow.wh_id
                .date_log = rrRow.date_log
                .type_of_purchasing = rsRow.type_of_purchasing
                .inOut = rsRow.inout
                .users = getUsers(cListOfUsers, rrRow.user_id)
                .requested_by = rsRow.requested_by
                .level = cLevel.rr
                .other_id = rrRow.po_det_id
                .item_desc = rrRow.rr_item_desc '$"{rsRow.rs_items} {oldWarehouseItemName(rsRow)}"
                .proper_names = rsRow.item_desc
                .division = rsRow.division
                .rs_id_for_rr = rsRow.rs_id
                .updatedBy = getUsers(cListOfUsers, rrRow.updatedById)
                .dateLogUpdated = is1990(rrRow.updatedAt)

            End With
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Private Function RR_CASH_WITH_RR_ROW(rsRow As PropsFields.rs_for_dr_props_fields, rrRow As PropsFields.receiving_props_fields) As COLUMNS
        Try
            RR_CASH_WITH_RR_ROW = New COLUMNS

            With RR_CASH_WITH_RR_ROW
                .rs_id = rrRow.rr_item_id
                .rs_no = rsRow.rs_no
                .ws_no = "-"
                .rr_no = rrRow.rr_no
                .rs_ws_po_rr_dr_date = rrRow.date_received
                .po_cv_ws_qty_released = "-"
                .rr_ws_qty_received = rrRow.rr_qty
                .price = rrRow.price
                .units = rrRow.unit
                .rr_status = "received"
                .charges = rsRow.charges
                .wh_id = rsRow.wh_id
                .date_log = rrRow.date_log
                .type_of_purchasing = rsRow.type_of_purchasing
                .inOut = rsRow.inout
                .users = useUser(rrRow.user_id)
                .requested_by = rsRow.requested_by
                .level = cLevel.rr
                .other_id = rrRow.rs_id
                .item_desc = $"{rsRow.rs_items} {oldWarehouseItemName(rsRow)}"
                .proper_names = rsRow.item_desc
                .users = getUsers(cListOfUsers, rrRow.user_id)

            End With
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Private Function DR_ROW(rsRow As PropsFields.rs_for_dr_props_fields,
                       Optional wsPoRow As PropsFields.ws_for_dr_props_fields = Nothing,
                       Optional drRow As PropsFields.dr_for_dr_props_fields = Nothing,
                       Optional level As String = "",
                       Optional rrRow As PropsFields.receiving_props_fields = Nothing) As COLUMNS
        Try
            DR_ROW = New COLUMNS

            With DR_ROW
                .rs_id = drRow.dr_item_id
                .rs_no = "-"
                .dr_no = drRow.dr_no
                .ws_no = "-"
                .wh_id = rsRow.wh_id
                .charges = rsRow.charges
                .source = "coming soon..."
                .quarry = "coming soon.."

#Region "ITEMS / CHARGES / SOURCE / QUARRY"
                If level = cLevel.dr_out Then

                    Dim items = useItems(drRow.wh_id)

                    If items IsNot Nothing Then
                        'items
                        .item_desc = $"{rsRow.item_desc}"

                        'charges
                        .charges = rsRow.charges

                        'source
                        .source = useStockPile(items.whArea_category, items.wh_area_id)

                        'quarry
                        .quarry = useQuarry(items.quarry_id)
                    End If

                    'reflect wsno in dr
                    If wsPoRow IsNot Nothing Then .ws_no = wsPoRow.ws_no

                ElseIf level = cLevel.dr_in Or level = cLevel.dr_others Then

                    Dim items = useItems(drRow.wh_id)

                    If items IsNot Nothing Then
                        'item desc
                        .wh_id = items.wh_id
                        .item_desc = $"{items.item_desc}"

                        'charges
                        If level = cLevel.dr_in Then
                            .charges = useStockPile(items.whArea_category, items.wh_area_id)

                        ElseIf level = cLevel.dr_others Then

                            '.charges = useStockPile(Nothing, 0, rsRow, rrRow, level)
                            .charges = rsRow.charges
                        End If

                        'quarry
                        .quarry = useQuarry(items.quarry_id)

                        'source
                        If level = cLevel.dr_others Then
                            '.source = useStockPile(items.whArea_category, items.wh_area_id, rsRow, rrRow)

                            'if waste
                            If items.item_desc.ToUpper().Contains("WASTE") Then
                                .source = useStockPile(items.whArea_category, items.wh_area_id, rsRow, rrRow)
                            Else
                                .source = "-"
                            End If
                        Else
                            .source = "-"
                        End If
                    End If

                    'reflect rr no
                    If rrRow IsNot Nothing Then .rr_no = rrRow.rr_no

                End If


#End Region

                .dr_qty = drRow.dr_qty
#Region "PRICE"
                Dim price As Double = FormatNumber(Utilities.ifBlankReplaceToZero(drRow.price)).ToString()
                .price = price
#End Region
                .amount = FormatNumber(CDbl(.dr_qty) * CDbl(.price)).ToString()
                .units = rsRow.unit
                .inOut = IIf(level = cLevel.dr_in, cInOut._IN, rsRow.inout)
                .remarks = drRow.remarks
                .rs_ws_po_rr_dr_date = drRow.dr_date
                .users = useUser(drRow.user_id)
                .requested_by = rsRow.requested_by

                .dr_option = "DR"
                .dr_items_id = drRow.dr_item_id
                .date_log = is1990(drRow.date_log)
                .level = level

#Region "ITEM DESCRIPTION"
                If .inOut = cInOut._OUT Then
                    .item_desc = $"{minusSign()} {rsRow.rs_items} {oldWarehouseItemName(rsRow)}"

                ElseIf .inOut = cInOut._IN Then
                    .item_desc = $"{plusSign()} {rsRow.rs_items} {oldWarehouseItemName(rsRow)}"
                Else
                    .item_desc = $"{rsRow.rs_items} {oldWarehouseItemName(rsRow)}"
                End If
#End Region

                .proper_names = rsRow.item_desc

#Region "OTHER ID"
                Select Case rsRow.inout
                    Case cInOut._OUT
                        .other_id = wsPoRow.ws_id
                    Case cInOut._IN, cInOut._OTHERS
                        If rsRow.type_of_purchasing = cTypeOfPurchasing.PURCHASE_ORDER Then
                            .other_id = rrRow.rr_item_id
                        Else
                            .other_id = rsRow.rs_id
                        End If
                End Select
#End Region

            End With
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Private Function SPLIT_ROW() As COLUMNS
        SPLIT_ROW = New COLUMNS
        With SPLIT_ROW
            .rs_id = "-"
            .rs_no = "-"
            .ws_no = "-"
            .rr_no = "-"
            .dr_no = "-"
            .rs_ws_po_rr_dr_date = "-"
            .date_needed = "-"
            .jobOrderNo = "-"
            .item_desc = "-"
            .rs_qty = "-"
            .po_cv_ws_qty_released = "-"
            .rr_ws_qty_received = "-"
            .dr_qty = "-"
            .price = "-"
            .units = "-"
            .purpose = "-"
            .type_of_request = "-"
            .inOut = "-"
            .po_cv_status = "-"
            .rr_status = "-"
            .ws_status = "-"
            .quarry = "-"
            .source = "-"
            .charges = "-"
            .location = "-"
            .wh_id = "-"
            .date_log = "-"
            .type_of_charges = "-"
            .type_of_purchasing = "-"
            .remarks = "-"
            .users = "-"
            .requested_by = "-"
            .dr_option = "-"
            .dr_items_id = "-"
            .item_checked_log = "-"
            .proper_names = "-"
            .level = "split-row"
        End With
        Return SPLIT_ROW
    End Function

    Private Function TOTAL_DELIVERED_ROW(totalDrDelivered As Double,
                                         Optional totalReceived As Double = 0,
                                         Optional status As String = "") As COLUMNS
        Try
            TOTAL_DELIVERED_ROW = New COLUMNS

            With TOTAL_DELIVERED_ROW
                .rs_qty = $"QTY LEFT: {_rsQuantityLeft}"
                .dr_qty = $"DELIVERED: {totalDrDelivered}"
                .rr_ws_qty_received = $"{status}: +{totalReceived}"
                .level = cLevel.total_delivered_row
            End With

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Private Function TOTAL_WITHDRAWN_ROW(totalWithdrawn As Double,
                                         Optional totalReceived As Double = 0) As COLUMNS
        Try
            TOTAL_WITHDRAWN_ROW = New COLUMNS

            With TOTAL_WITHDRAWN_ROW
                .rr_ws_qty_received = $"WITDRAWN: {totalWithdrawn}"
                .level = cLevel.total_delivered_row
            End With

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Private Function TOTAL_RECEIVED_ROW(totalDrReceived As Double) As COLUMNS
        Try
            TOTAL_RECEIVED_ROW = New COLUMNS

            With TOTAL_RECEIVED_ROW
                .rr_ws_qty_received = $"RECEIVED: +{totalDrReceived}"
                .level = cLevel.total_received_row
            End With

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Private Function TOTAL_DELIVERED(rsRow As PropsFields.rs_for_dr_props_fields,
                                     drRow As PropsFields.dr_for_dr_props_fields) As Func(Of Double)

        Dim totaldelivered As Double

        Try
            If rsRow.inout = cInOut._OUT Or
                rsRow.inout = cInOut._IN Or
                rsRow.inout = cInOut._OTHERS Then

                Return Function()
                           totaldelivered += drRow.dr_qty
                           Return totaldelivered
                       End Function

            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

    End Function

    Private Function TOTAL_RECEIVED(rsRow As PropsFields.rs_for_dr_props_fields,
                                     rrRow As PropsFields.receiving_props_fields) As Func(Of Double)

        Dim totalReceived As Double

        Try
            If rsRow.inout = cInOut._OUT Or
                rsRow.inout = cInOut._IN Or
                rsRow.inout = cInOut._OTHERS Then

                Return Function()
                           totalReceived += rrRow.rr_qty
                           Return totalReceived
                       End Function

            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

    End Function

    Private Function TOTAL_WITHDRAW(rsRow As PropsFields.rs_for_dr_props_fields,
                                    wsRow As PropsFields.ws_for_dr_props_fields) As Func(Of Double)

        Dim totalWithdrawn As Double

        Try
            If rsRow.inout = cInOut._OUT Or
                rsRow.inout = cInOut._IN Or
                rsRow.inout = cInOut._OTHERS Then
                Return Function()
                           totalWithdrawn += wsRow.ws_qty
                           Return totalWithdrawn
                       End Function

            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Private Function RS_QUANTITY_LEFT(rsRow As PropsFields.rs_for_dr_props_fields) As Func(Of Double)

        Dim totalQuantityLeft As Double

        Try
            If rsRow.inout = cInOut._OUT Or
                rsRow.inout = cInOut._IN Or
                rsRow.inout = cInOut._OTHERS Then

                Return Function()
                           totalQuantityLeft -= rsRow.rs_qty
                           Return totalQuantityLeft
                       End Function

            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

    End Function
#End Region

#Region "DATAGRIDVIEW ROWS FROM OTHER FORMS"
    Public Sub DisplayRsDataToPoDatagridview(dgv As DataGridView, rsNo As String)
        Try
            RawPoRows.Clear()
            For Each row In listOfRsDatas
                If row.level = cLevel.sub_rs And
                    row.rs_no = rsNo And
                    row.type_of_purchasing = cTypeOfPurchasing.PURCHASE_ORDER Then

                    Dim remainingBalance As Double = row.rs_qty - getPurchasedAggregates(row.rs_id)

                    If remainingBalance > 0 Then
                        Dim _rawPoRows As New PropsFields.Purchase_Order_Row

                        With _rawPoRows
                            .rs_id = row.rs_id
                            .item_description = row.item_desc
                            .poNo = getAutoIncrementPoNo()
                            .wh_id = row.wh_id
                            .rs_qty_balance = remainingBalance
                            .qty = remainingBalance
                            .charges = row.charges
                            .unit = row.units
                            .proper_naming = row.proper_names
                            .unit_price = 0
                            .amount = 0
                            .price_with_tax = 0
                            .tax_category = "N/A"
                            .tax_value = 0
                            .terms = "60 days"
                        End With

                        RawPoRows.Add(_rawPoRows)
                    End If

                End If
            Next

            dgv.DataSource = RawPoRows
            customizeGridViewForPo(dgv)

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
    Public Sub DisplayPoDataToRrDatagridview(dgv As DataGridView, rsNo As String)
        Try
            RawRrRows.Clear()
            For Each row In listOfRsDatas
                If row.level = cLevel.po And
                    row.rs_no = rsNo Then

                    Dim po_det_id As Integer = row.rs_id
                    Dim remainingBalance As Double = row.po_cv_ws_qty_released - getReceivedAggregates(po_det_id)
                    Dim po_no As String = row.ws_no

                    If remainingBalance > 0 Then
                        Dim _rawRrRows As New PropsFields.Receiving_row

                        With _rawRrRows
                            .po_det_id = po_det_id
                            .item_description = row.item_desc
                            .po_qty_balance = remainingBalance
                            .rs_id = row.other_id
                            .po_no = po_no
                            .rr_qty = remainingBalance
                            .unit = row.units
                            .unit_price = row.price
                            .amount = Utilities.ifBlankReplaceToZero(row.price) * remainingBalance
                        End With

                        RawRrRows.Add(_rawRrRows)
                    End If

                End If
            Next

            dgv.DataSource = RawRrRows
            customizeGridViewForRr(dgv)

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
    Public Sub DisplayRsCashDataToRrDatagridview(dgv As DataGridView, rsNo As String)
        Try
            RawRrRows.Clear()
            For Each row In listOfRsDatas
                If row.level = cLevel.sub_rs And
                    row.rs_no = rsNo And row.type_of_purchasing = cTypeOfPurchasing.CASH_WITH_RR Then

                    Dim rs_id As Integer = row.rs_id
                    Dim remainingBalance As Double = row.rs_qty - getReceivedAggregatesCashWithRR(rs_id)

                    If remainingBalance > 0 Then
                        Dim _rawRrRows As New PropsFields.Receiving_row

                        With _rawRrRows
                            .item_description = row.item_desc
                            .po_qty_balance = remainingBalance
                            .rs_id = row.rs_id
                            .po_no = "-"
                            .typeOfPurchasing = row.type_of_purchasing
                        End With

                        RawRrRows.Add(_rawRrRows)
                    End If

                End If
            Next

            dgv.DataSource = RawRrRows
            customizeGridViewForRr(dgv)

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
    Public Sub DisplayRrDataToRrDatagridview(dgv As DataGridView, rrData As PropsFields.Receiving_row)
        Try
            RawRrRows.Clear()

            RawRrRows.Add(rrData)
            dgv.DataSource = RawRrRows
            customizeGridViewForRr(dgv)

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
    Public Sub refactorAndPreviewIncludingSerialNo(receivingRows As List(Of PropsFields.Receiving_row),
                                                   receivingSerialNoRow As List(Of CreateReceivingModel.Receiving_SerialNo),
                                                   newDgv As DataGridView)
        Try
            Dim newRawRrRows As New List(Of PropsFields.Receiving_row)
            For Each row In receivingRows
                Dim _rawRr As New PropsFields.Receiving_row
                With _rawRr
                    .po_det_id = row.po_det_id
                    .po_no = row.po_no
                    .rs_id = row.rs_id
                    .item_description = row.item_description
                    .rr_qty = row.rr_qty
                    .amount = row.amount
                    .po_qty_balance = row.po_qty_balance
                    .typeOfPurchasing = row.typeOfPurchasing
                    .unit = row.unit
                    .unit_price = row.unit_price
                    .level = "parent"
                End With

                newRawRrRows.Add(_rawRr)

                For Each row2 In receivingSerialNoRow
                    If row2.po_det_id = row.po_det_id Then
                        For Each row3 In row2.receivingWithSerialNo
                            Dim _rawRrSub As New PropsFields.Receiving_row
                            With _rawRrSub
                                .po_det_id = row.po_det_id
                                .item_description = $"SERIAL NO: {row3.tire_serial_no}"
                                .level = "child"
                                .other_id = row3.tire_index
                            End With

                            newRawRrRows.Add(_rawRrSub)
                        Next
                    End If
                Next
            Next

            newDgv.DataSource = Nothing
            newDgv.DataSource = newRawRrRows

            customizeGridViewForRr(newDgv)
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
#End Region

#Region "CUSTOMIZE SOMETHING"
    Private Sub customizeGridView()
        Try
            customDatagrid.readonlyAllCells(cDgv)

            For Each row As DataGridViewRow In cDgv.Rows
                If row.Cells(NameOf(cn.level)).Value = cLevel.sub_rs Then
                    row.DefaultCellStyle.BackColor = cRsRowColor.MainSubRS
                    row.DefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#DFD0B8") 'Color.White
                    row.Height = 40
                    row.DefaultCellStyle.Font = New Font(cFontsFamily.bombardier, 12, FontStyle.Regular)

                ElseIf row.Cells(NameOf(cn.level)).Value = cLevel.ws Or
                    row.Cells(NameOf(cn.level)).Value = cLevel.po Then

                    row.DefaultCellStyle.BackColor = cRsRowColor.WsPo
                    row.DefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#DFDFDF")

                ElseIf row.Cells(NameOf(cn.level)).Value = cLevel.pw Then
                    row.DefaultCellStyle.BackColor = cRsRowColor.Pw
                    row.DefaultCellStyle.ForeColor = Color.Black

                ElseIf row.Cells(NameOf(cn.level)).Value = cLevel.dr_out Then

                    row.DefaultCellStyle.BackColor = cRsRowColor.Dr
                    row.DefaultCellStyle.ForeColor = Color.Black

                ElseIf row.Cells(NameOf(cn.level)).Value = cLevel.dr_in Or
                    row.Cells(NameOf(cn.level)).Value = cLevel.dr_others Then

                    row.DefaultCellStyle.BackColor = cRsRowColor.Dr_sts
                    row.DefaultCellStyle.ForeColor = Color.Black

                ElseIf row.Cells(NameOf(cn.level)).Value = cLevel.rr Then

                    row.DefaultCellStyle.BackColor = cRsRowColor.Rr
                    row.DefaultCellStyle.ForeColor = Color.Black

                ElseIf row.Cells(NameOf(cn.level)).Value = cLevel.main_rs Then

                    row.DefaultCellStyle.BackColor = cRsRowColor.MainRs
                    row.DefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#DFD0B8") 'Color.Black
                    row.Height = 40
                    row.DefaultCellStyle.Font = New Font(cFontsFamily.bombardier, 13, FontStyle.Regular)

                ElseIf row.Cells(NameOf(cn.level)).Value = "split-row" Then
                    row.DefaultCellStyle.BackColor = cRsRowColor.rowSplitter 'ColorTranslator.FromHtml("#303642") 'Color.Blue
                    row.DefaultCellStyle.ForeColor = Color.WhiteSmoke

                ElseIf row.Cells(NameOf(cn.level)).Value = cLevel.total_delivered_row Then
                    row.DefaultCellStyle.BackColor = cRsRowColor.totalRow 'ColorTranslator.FromHtml("#DFEDD1") 'Color.Orange
                    row.DefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#DFD0B8")

                ElseIf row.Cells(NameOf(cn.level)).Value = cLevel.total_received_row Then
                    row.DefaultCellStyle.BackColor = Color.OrangeRed
                    row.DefaultCellStyle.ForeColor = Color.White
                End If
            Next

            'for cancel rs, po and ws row color
            For Each row As DataGridViewRow In cDgv.Rows
                If row.Cells(NameOf(cn.level)).Value = cLevel.sub_rs Then
                    Dim isCancelled = cListOfCancelledTransaction.FirstOrDefault(Function(x)
                                                                                     Return x.trans_id = CInt(row.Cells(NameOf(cn.rs_id)).Value) And x.trans = "RS"
                                                                                 End Function)

                    If isCancelled IsNot Nothing Then
                        row.DefaultCellStyle.BackColor = Color.Red
                        row.DefaultCellStyle.ForeColor = Color.White
                    End If

                ElseIf row.Cells(NameOf(cn.level)).Value = cLevel.po Then
                    Dim isCancelled = cListOfCancelledTransaction.FirstOrDefault(Function(x)
                                                                                     Return x.trans_id = CInt(row.Cells(NameOf(cn.rs_id)).Value) And x.trans = "PO"
                                                                                 End Function)

                    Dim cancelledPo As Boolean = row.Cells(NameOf(cn.po_cancel_status)).Value

                    If isCancelled IsNot Nothing Or cancelledPo = True Then
                        row.DefaultCellStyle.BackColor = Color.Red
                        row.DefaultCellStyle.ForeColor = Color.White
                    End If

                ElseIf row.Cells(NameOf(cn.level)).Value = cLevel.ws Then

                    Dim isCancelled As Boolean = row.Cells(NameOf(cn.po_cancel_status)).Value
                    Dim transId As Integer = CInt(row.Cells(NameOf(cn.rs_id)).Value)

                    Dim cancelResult = isCancelledDataFor(transId, "WS", isCancelled)

                    If cancelResult Then
                        row.DefaultCellStyle.BackColor = Color.Red
                        row.DefaultCellStyle.ForeColor = Color.White
                    End If

                    'If isCancelled IsNot Nothing Or cancelledPo = True Then
                    '    row.DefaultCellStyle.BackColor = Color.Red
                    '    row.DefaultCellStyle.ForeColor = Color.White
                    'End If
                End If
            Next

            cDgv.Columns(NameOf(cn.rs_id)).HeaderText = "RS_ID/WS_ID/PO_DET_ID/RR_ITEM_ID/DR_ITEM_ID"
            cDgv.Columns(NameOf(cn.rs_no)).HeaderText = "RS NO."
            cDgv.Columns(NameOf(cn.ws_no)).HeaderText = "WS NO."
            cDgv.Columns(NameOf(cn.rr_no)).HeaderText = "RR NO."
            cDgv.Columns(NameOf(cn.dr_no)).HeaderText = "DR NO."
            cDgv.Columns(NameOf(cn.rs_ws_po_rr_dr_date)).HeaderText = "RS/WS/PO/RR/DR DATE"
            cDgv.Columns(NameOf(cn.rs_ws_po_rr_dr_date)).HeaderText = "RS/WS/PO/RR/DR DATE"
            cDgv.Columns(NameOf(cn.date_needed)).HeaderText = "DATE NEEDED"
            cDgv.Columns(NameOf(cn.jobOrderNo)).HeaderText = "JOB ORDER"
            cDgv.Columns(NameOf(cn.item_desc)).HeaderText = "RS ITEM DESCRIPTION"
            cDgv.Columns(NameOf(cn.rs_qty)).HeaderText = "RS QTY"
            cDgv.Columns(NameOf(cn.po_cv_ws_qty_released)).HeaderText = "PO/CV/WS RELEASED"
            cDgv.Columns(NameOf(cn.rr_ws_qty_received)).HeaderText = "RR/WS RECEIVED"
            cDgv.Columns(NameOf(cn.dr_qty)).HeaderText = "DR QTY"
            cDgv.Columns(NameOf(cn.price)).HeaderText = "PRICE"
            cDgv.Columns(NameOf(cn.units)).HeaderText = "UNITS"
            cDgv.Columns(NameOf(cn.purpose)).HeaderText = "PURPOSE"
            cDgv.Columns(NameOf(cn.type_of_request)).HeaderText = "TYPE OF REQUEST"
            cDgv.Columns(NameOf(cn.inOut)).HeaderText = "IN/OUT"
            cDgv.Columns(NameOf(cn.po_cv_status)).HeaderText = "PO/CV STATUS"
            cDgv.Columns(NameOf(cn.rr_status)).HeaderText = "RR STATUS"
            cDgv.Columns(NameOf(cn.ws_status)).HeaderText = "WS STATUS"
            cDgv.Columns(NameOf(cn.quarry)).HeaderText = "QUARRY CODE"
            cDgv.Columns(NameOf(cn.source)).HeaderText = "SOURCE"
            cDgv.Columns(NameOf(cn.charges)).HeaderText = "CHARGES/REQUESTOR"
            cDgv.Columns(NameOf(cn.location)).HeaderText = "LOCATION"
            cDgv.Columns(NameOf(cn.wh_id)).HeaderText = "WH_ID"
            cDgv.Columns(NameOf(cn.date_log)).HeaderText = "DATE_LOG"
            cDgv.Columns(NameOf(cn.type_of_charges)).HeaderText = "TYPE OF CHARGES"
            cDgv.Columns(NameOf(cn.type_of_purchasing)).HeaderText = "TYPE OF PURCHASING"
            cDgv.Columns(NameOf(cn.remarks)).HeaderText = "REMARKS"
            cDgv.Columns(NameOf(cn.users)).HeaderText = "INPUTTED USERS/ITEM CHECK USERS"
            cDgv.Columns(NameOf(cn.requested_by)).HeaderText = "REQUESTED BY"
            cDgv.Columns(NameOf(cn.dr_option)).HeaderText = "DR OPTION"
            cDgv.Columns(NameOf(cn.dr_items_id)).HeaderText = "DR_ITEMS_ID"
            cDgv.Columns(NameOf(cn.item_checked_log)).HeaderText = "ITEM CHECKED LOG"
            cDgv.Columns(NameOf(cn.level)).HeaderText = "LEVEL"
            cDgv.Columns(NameOf(cn.proper_names)).HeaderText = "DESIRED PROPER NAMES FROM USER"
            cDgv.Columns(NameOf(cn.remarks_for_emd)).HeaderText = "REMARKS FOR EMD"
            cDgv.Columns(NameOf(cn.itemCheckedTo)).HeaderText = "ITEM CHECKED TO"
            cDgv.Columns(NameOf(cn.amount)).HeaderText = "AMOUNT"
            cDgv.Columns(NameOf(cn.supplier)).HeaderText = "SUPPLIER"
            cDgv.Columns(NameOf(cn.updatedBy)).HeaderText = "UPDATED BY"
            cDgv.Columns(NameOf(cn.dateLogUpdated)).HeaderText = "DATE LOG UPDATED"


            'hide columns
            For Each column As DataGridViewColumn In cDgv.Columns
                If column.Name = NameOf(cn.level) Then
                    column.Visible = True
                ElseIf column.Name = NameOf(cn.main_rs_qty_id) Then
                    column.Visible = False
                    'ElseIf column.Name = NameOf(cn.other_id) Then
                    '    column.Visible = False
                Else
                    column.Visible = True
                End If
            Next

            ' Only horizontal lines
            cDgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical

            ' Only vertical lines
            cDgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal

            'width
            cDgv.Columns(NameOf(cn.item_desc)).Width = 400
            cDgv.Columns(NameOf(cn.proper_names)).Width = 350
            cDgv.Columns(NameOf(cn.rs_qty)).Width = 300
            cDgv.Columns(NameOf(cn.itemCheckedTo)).Width = 400
            cDgv.Columns(NameOf(cn.purpose)).Width = 350
            cDgv.Columns(NameOf(cn.charges)).Width = 400
            cDgv.Columns(NameOf(cn.updatedBy)).Width = 350
            cDgv.Columns(NameOf(cn.dateLogUpdated)).Width = 250
            cDgv.Columns(NameOf(cn.item_checked_log)).Width = 250
            cDgv.Columns(NameOf(cn.users)).Width = 350


            'disable resize
            cDgv.AllowUserToResizeRows = False

            customDatagrid.customHeader(cDgv)


            'for show/hide column desired from user
            Dim listOfColumnName = cRsColumnSettings.getListofColumnName()
            If listOfColumnName.Count > 0 Then
                'make visible all to false first
                For Each col As DataGridViewColumn In cDgv.Columns
                    col.Visible = False
                Next

                For Each columnName In listOfColumnName
                    cDgv.Columns(columnName).Visible = True
                Next
            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Public Sub customizeGridViewForPo(dgv As DataGridView)
        Try
            Dim cn2 As New PropsFields.Purchase_Order_Row

            'rename columns
            dgv.Columns(NameOf(cn2.rs_id)).HeaderText = "RS_ID"
            dgv.Columns(NameOf(cn2.supplier)).HeaderText = "SUPPLIER"
            dgv.Columns(NameOf(cn2.wh_id)).HeaderText = "WH ID"
            dgv.Columns(NameOf(cn2.item_description)).HeaderText = "ITEM DESCRIPTION"
            dgv.Columns(NameOf(cn2.poNo)).HeaderText = "PO NO."
            dgv.Columns(NameOf(cn2.terms)).HeaderText = "TERMS"
            dgv.Columns(NameOf(cn2.rs_qty_balance)).HeaderText = "RS QTY BALANCE"
            dgv.Columns(NameOf(cn2.qty)).HeaderText = "PO QTY."
            dgv.Columns(NameOf(cn2.amount)).HeaderText = "AMOUNT"
            dgv.Columns(NameOf(cn2.unit)).HeaderText = "UNIT"
            dgv.Columns(NameOf(cn2.unit_price)).HeaderText = "UNIT PRICE"
            dgv.Columns(NameOf(cn2.tax_category)).HeaderText = "TAX CATEGORY"
            dgv.Columns(NameOf(cn2.tax_value)).HeaderText = "TAX (VAT/EWT)"
            dgv.Columns(NameOf(cn2.price_with_tax)).HeaderText = "PRICE WITH TAX"
            dgv.Columns(NameOf(cn2.charges)).HeaderText = "CHARGES"

            customDatagridForPo.customDatagridview(dgv,, 34)

            'alternate rows
            customDatagridForPo.subcustomDatagridviewSettings2("alternateRowStyle", dgv)

            'readonly
            customDatagridForPo.readonlyAllCells(dgv)

            customDatagridForPo.customHeader(dgv)

            'column width
            dgv.Columns(NameOf(cn2.item_description)).Width = 400

            'hide
            dgv.Columns(NameOf(cn2.user_id)).Visible = False
            dgv.Columns(NameOf(cn2.supplier_id)).Visible = False



        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Public Sub customizeGridViewForRr(dgv As DataGridView, Optional isEditRr As Boolean = False)
        Try
            Dim cn2 As New PropsFields.Receiving_row
            'rename columns
            dgv.Columns(NameOf(cn2.rs_id)).HeaderText = "RS_ID"

            dgv.Columns(NameOf(cn2.item_description)).HeaderText = "ITEM DESCRIPTION"
            dgv.Columns(NameOf(cn2.rr_item_description)).HeaderText = "RR ITEM DESCRIPTION"
            dgv.Columns(NameOf(cn2.po_qty_balance)).HeaderText = "PO QTY BALANCE"
            dgv.Columns(NameOf(cn2.rr_qty)).HeaderText = "RR QTY."
            dgv.Columns(NameOf(cn2.unit)).HeaderText = "UNIT"
            dgv.Columns(NameOf(cn2.unit_price)).HeaderText = "UNIT PRICE"
            dgv.Columns(NameOf(cn2.po_no)).HeaderText = "PO NO."
            dgv.Columns(NameOf(cn2.po_det_id)).HeaderText = "PO_DET_ID"

            customDatagridForRr.customDatagridview(dgv,, 34)

            'alternate rows
            'customDatagridForRr.subcustomDatagridviewSettings2("alternateRowStyle", dgv)

            'readonly
            customDatagridForRr.readonlyAllCells(dgv)

            'column width
            dgv.Columns(NameOf(cn2.item_description)).Width = 300
            dgv.Columns(NameOf(cn2.rr_item_description)).Width = 300

            'hide columns
            If isEditRr Then
                dgv.Columns(NameOf(cn2.po_qty_balance)).Visible = False
                dgv.Columns(NameOf(cn2.po_det_id)).Visible = False
            End If

            'customize row color 
            For Each row As DataGridViewRow In dgv.Rows
                If row.Cells("level").Value = "parent" Then
                    row.DefaultCellStyle.BackColor = cRsRowColor.MainSubRS
                    row.DefaultCellStyle.ForeColor = Color.White

                ElseIf row.Cells("level").Value = "child" Then
                    row.DefaultCellStyle.BackColor = cRsRowColor.Dr
                    row.DefaultCellStyle.Font = New Font(cFontsFamily.bombardier, 11, FontStyle.Regular)
                    row.Height = 21

                End If
            Next

            'disable resize rows
            dgv.AllowUserToResizeRows = False

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
#End Region

#Region "PUBLIC GET"
    Public ReadOnly Property getLevel() As ROWLEVEL
        Get
            Return cLevel
        End Get
    End Property

    Public Function getAutoIncrementPoNo() As Integer
        Try
            If pubPoNo = "" Then
                Return 0
            Else
                'pubPoNo = Utilities.ifBlankReplaceToZero(pubPoNo) + 1
                Return pubPoNo
            End If

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

    End Function

    Private Function getRRData(poRow As PropsFields.po_for_dr_props_fields) As List(Of PropsFields.receiving_props_fields)
        Try
            If cListOfReceiving.Count > 0 Then
                Dim refactoredReceiving = cListOfReceiving.Where(Function(x) x.rr_no.ToUpper() IsNot "N/A" And
                                                                x.po_det_id = poRow.po_det_id).ToList()

                Return refactoredReceiving

            Else
                Return Nothing
            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Private Function getRRForCashWithRRData(rsRow As PropsFields.rs_for_dr_props_fields) As List(Of PropsFields.receiving_props_fields)
        Try
            If cListOfReceiving.Count > 0 Then
                Dim refactoredReceiving = cListOfReceiving.Where(Function(x) x.rr_no.ToUpper() IsNot "N/A" And
                                                                x.rs_id = rsRow.rs_id).ToList()

                Return refactoredReceiving
            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Private Function getDrData(rsRow As PropsFields.rs_for_dr_props_fields) As List(Of PropsFields.dr_for_dr_props_fields)
        getDrData = New List(Of PropsFields.dr_for_dr_props_fields)

        Try
            If cListOfDrForDr.Count > 0 Then
                Dim refactoredDr = cListOfDrForDr.Where(Function(x) x.rs_id = rsRow.rs_id).ToList()

                Return refactoredDr

            End If


        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

    End Function

    Private Function getPartiallyReleasedWithdrawn(rsRow As PropsFields.rs_for_dr_props_fields,
                                                   wsRow As PropsFields.ws_for_dr_props_fields) As List(Of PropsFields.partiallyReleasedWithdrawal_props_fields)
        Try
            getPartiallyReleasedWithdrawn = New List(Of PropsFields.partiallyReleasedWithdrawal_props_fields)


            If cListOfPartiallyReleasedWithdrawn.Count > 0 Then
                Dim refactoredData = cListOfPartiallyReleasedWithdrawn.Where(Function(x) x.ws_id = wsRow.ws_id And x.deleted_status <> "deleted").ToList()

                Return refactoredData

            End If

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Public Function getMainRsRemainingBalance(main_rs_qty_id As Integer) As String
        Try
            Dim mainRsRemainingBalance = cListOfRsLeft.FirstOrDefault(Function(x) x.main_rs_qty_id = main_rs_qty_id)

            If mainRsRemainingBalance IsNot Nothing Then
                If mainRsRemainingBalance.isOpen Then
                    Return "open"
                Else
                    Return mainRsRemainingBalance.balance
                End If
            Else
                Return -1
            End If

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

    End Function

    Public Function getRsRemainingBalance(rs_id As Integer) As Double
        Try
            Dim rsData = cListOfRsForDr.FirstOrDefault(Function(x) x.rs_id = rs_id)
            Dim rsQty As Double = rsData?.rs_qty

            Dim rsRemainingBalance As Double
            If rsData.type_of_purchasing = cTypeOfPurchasing.WITHDRAWAL Then
                Dim countWithdrawnDatas = getWithdrawnAggregates(rs_id)

                rsRemainingBalance = rsQty - countWithdrawnDatas

                Return rsRemainingBalance

            ElseIf rsData.type_of_purchasing = cTypeOfPurchasing.PURCHASE_ORDER Then
                Dim countPurchasedDatas = getPurchasedAggregates(rs_id)

                rsRemainingBalance = rsQty - countPurchasedDatas

                Return rsRemainingBalance

            ElseIf rsData.type_of_purchasing = cTypeOfPurchasing.DR Then
                Dim countDeliveredDatas = getDeliveredAggregates(rsData.inout, rsData.rs_id)

                rsRemainingBalance = rsQty - countDeliveredDatas

                Return rsRemainingBalance
            Else
                Return rsQty
            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Public Function getWithdrawalDataByWsIdAndLevel(wsId As Integer, level As String) As COLUMNS
        Try
            If listOfRsDatas.Count > 0 Then
                getWithdrawalDataByWsIdAndLevel = listOfRsDatas.FirstOrDefault(Function(x)
                                                                                   Return x.rs_id = CStr(wsId) And
                                                                                            x.level = level
                                                                               End Function)

                Return getWithdrawalDataByWsIdAndLevel
            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Public Function getReceivingDataByRrItemIdAndLevel(rrItemId As Integer, level As String) As COLUMNS
        Try
            If listOfRsDatas.Count > 0 Then
                getReceivingDataByRrItemIdAndLevel = listOfRsDatas.FirstOrDefault(Function(x)
                                                                                      Return x.rs_id = CStr(rrItemId) And
                                                                                                x.level = level
                                                                                  End Function)

                Return getReceivingDataByRrItemIdAndLevel
            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Public Function getRequesitionByRsIdAndLevel(rsId As Integer, level As String) As COLUMNS
        Try
            If listOfRsDatas.Count > 0 Then
                getRequesitionByRsIdAndLevel = listOfRsDatas.FirstOrDefault(Function(x)
                                                                                Return x.rs_id = CStr(rsId) And
                                                                                                x.level = level
                                                                            End Function)

                Return getRequesitionByRsIdAndLevel
            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Public Function getWithdrawnAggregates(rs_id As Integer) As Double
        Try
            For Each row In listOfRsDatas
                If row.other_id = rs_id Then
                    getWithdrawnAggregates += Utilities.ifBlankReplaceToZero(row.po_cv_ws_qty_released)
                End If
            Next
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Public Function getWithdrawnPartially(wsId As Integer) As Double
        Try
            For Each row In listOfRsDatas
                If row.other_id = wsId Then
                    getWithdrawnPartially += Utilities.ifBlankReplaceToZero(row.rr_ws_qty_received)
                End If
            Next
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function


    Public Function getPurchasedAggregates(rs_id As Integer) As Double
        Try
            For Each row In listOfRsDatas
                If row.other_id = rs_id Then
                    getPurchasedAggregates += row.po_cv_ws_qty_released
                End If
            Next
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Public Function getReceivedAggregates(po_det_id As Integer) As Double
        Try
            For Each row In listOfRsDatas
                If row.other_id = po_det_id Then
                    getReceivedAggregates += row.rr_ws_qty_received
                End If
            Next
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Public Function getReceivedAggregatesCashWithRR(rs_id As Integer) As Double
        Try
            For Each row In listOfRsDatas
                If row.other_id = rs_id Then
                    getReceivedAggregatesCashWithRR += Utilities.ifBlankReplaceToZero(row.rr_ws_qty_received)
                End If
            Next
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Private Function getRsMultipleCharges(rsId As Integer) As List(Of PropsFields.AllCharges)
        getRsMultipleCharges = New List(Of PropsFields.AllCharges)
        Try
            Dim multipleCharges As New Model_Dynamic_Select

            Dim table As String = "dbMultipleCharges a" 'table
            Dim condition As String = $"a.rs_id = {rsId}" 'conditions

            'columns
            multipleCharges.join_columns("a.all_charges_id,")
            multipleCharges.join_columns("a.rs_id,")
            multipleCharges.join_columns("a.type_name")


            'end columns

            'initialize data
            multipleCharges._initialize(table,
                                        condition,
                                        multipleCharges.cJoinColumns,
                                        multipleCharges.cJoining)

            Dim chargesData As New List(Of Object) 'create a list of ojbect 
            chargesData = multipleCharges.select_query() 'get data

            'loop data to get values
            For Each row In chargesData
                Dim n As Integer = 0
                Dim _chargesStorage As New PropsFields.AllCharges

                For Each kvp As KeyValuePair(Of String, Object) In row
                    If kvp.Key = "all_charges_id" Then
                        _chargesStorage.charges_id = kvp.Value.ToString()
                    ElseIf kvp.Key = "type_name" Then
                        _chargesStorage.charges_category = kvp.Value.ToString()
                    ElseIf kvp.Key = "rs_id" Then
                        _chargesStorage.rs_id = kvp.Value.ToString()
                    End If
                Next
                getRsMultipleCharges.Add(_chargesStorage)
            Next

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function
    Private Function getUnits(rs As PropsFields.rs_for_dr_props_fields, Optional defaultUnits As String = "")
        Try
            If rs.type_of_purchasing = cTypeOfPurchasing.CASH_WITH_RR Or
                rs.type_of_purchasing = cTypeOfPurchasing.CASH_WITHOUT_RR Then

                Return rs.unit_from_rs

            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function
    Private Function getRsData() As List(Of PropsFields.rs_for_dr_props_fields)
        Try
            getRsData = New List(Of PropsFields.rs_for_dr_props_fields)
            'refactor first
            Dim refactoredRs = getRefactoredRs()

            For Each row In refactoredRs
                Dim _rsData As New PropsFields.rs_for_dr_props_fields
                With _rsData
                    .rs_id = row.rs_id
                    .rs_no = row.rs_no
                    .rs_date = row.rs_date
                    .date_needed = row.date_needed
                    .rs_items = row.rs_items

#Region "PROPER NAMES FOR ITEM"
                    If row.wh_pn_id_for_rs > 0 Then
                        Dim propername = getProperNameBy_wh_pn_id_for_rs(row)

                        If propername IsNot Nothing Then

                            .rs_properName = $"{propername.item_name} - {propername.item_desc}"
                            '.unit = propername.units
                        End If
                    Else
                        Dim whitems = getWarehouseItemByWhId(row)
                        If whitems IsNot Nothing Then
                            .rs_properName = "waiting..." '$"{whitems.item_name} - {whitems.item_desc}"
                            '.unit = whitems.units
                            'Else
                            '    .unit = getUnits(row)
                        End If
                    End If


#End Region

#Region "FOR ITEM CHECK DETAILS"
                    If row.wh_id > 0 Then
                        Dim propername = getProperNameByWhPnId(row)
                        Dim whitemsOldName = getWarehouseItemByWhId(row)

                        If propername IsNot Nothing Then
                            If whitemsOldName IsNot Nothing Then
                                .itemCheckedTo = $"{whitemsOldName?.item_name} - {whitemsOldName?.item_desc} → {propername.item_name} - {propername.item_desc}"
                            Else
                                .itemCheckedTo = $"→ {propername.item_name} - {propername.item_desc}"
                            End If
                        End If
                    End If
#End Region

                    .rs_qty = row.rs_qty
                    .purpose = row.purpose
                    .type_of_request = getTypeOfRequestWithAccountTitle(row)
                    .inout = row.inout
#Region "CHARGES"
                    Dim charges = getCharges(row)
                    .charges = charges
                    'If charges IsNot Nothing Then
                    '    .charges = charges.charges
                    'End If
#End Region

                    .tors_ca_id = row.tors_ca_id
                    .location = row.location
                    .wh_id = row.wh_id
                    .date_log = row.date_log
                    .type_of_purchasing = row.type_of_purchasing
                    .source = "coming soon..."
#Region "USERS"
                    Dim userInputted, itemCheckedUser As String
                    userInputted = getUsers(cListOfUsers, row.user_id)

                    itemCheckedUser = getUsers(cListOfUsers, row.item_checked_user)

                    .users = $"{userInputted} / {itemCheckedUser}"
#End Region
                    .requested_by = row.requested_by
                    .item_checked_log = row.item_checked_log
                    .wh_pn_id = row.wh_pn_id
                    .wh_pn_id_for_rs = row.wh_pn_id_for_rs
                    .whItem = row.whItem
                    .whItemDesc = row.whItemDesc
                    .division = row.division
                    .job_order_no = row.job_order_no
                    .remarks_for_emd = row.remarks_for_emd
                    .price = row.price
                    .amount = row.amount
                    .user_id_updated = row.user_id_updated
                    .date_log_updated = row.date_log_updated
                    .unit = row.unit_from_rs

                End With

                getRsData.Add(_rsData)
            Next

            Return getRsData
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

    End Function

    Private Function getWsPoData(rsRow As PropsFields.rs_for_dr_props_fields)
        Try
            Select Case rsRow.inout
                Case cInOut._OUT
                    If cListOfWsForDr.Count > 0 Then
                        Dim refactoredWsPo = cListOfWsForDr.Where(Function(x) x.rs_id = rsRow.rs_id).ToList()

                        Return TryCast(refactoredWsPo, List(Of PropsFields.ws_for_dr_props_fields))
                    End If
                Case cInOut._IN, cInOut._OTHERS
                    If cListOfPoForDr.Count > 0 Then
                        Dim refactoredWsPo = cListOfPoForDr.Where(Function(x) x.rs_id = rsRow.rs_id).ToList()

                        Return TryCast(refactoredWsPo, List(Of PropsFields.po_for_dr_props_fields))
                    End If

            End Select
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Public Function getDeliveredAggregates(inOut As String, Optional id As Integer = 0) As Double
        Try
            Select Case inOut
                Case cInOut._OUT
                    For Each row In listOfRsDatas
                        If row.level = cLevel.dr_out And row.other_id = id Then
                            getDeliveredAggregates += row.dr_qty
                        End If
                    Next
                Case cInOut._IN, cInOut._OTHERS
                    For Each row In listOfRsDatas
                        If row.level = cLevel.dr_in And row.other_id = id OrElse
                            row.level = cLevel.dr_others And row.other_id = id Then

                            getDeliveredAggregates += row.dr_qty
                        End If
                    Next
            End Select
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Public ReadOnly Property getListOfRsForDr() As List(Of PropsFields.rs_for_dr_props_fields)
        Get
            Return cListOfRsForDr
        End Get
    End Property

    Public ReadOnly Property getConsolidationAccount() As List(Of PropsFields.Consolidated_Account)
        Get
            Return cListOfConsolidationAccount
        End Get
    End Property

    Public ReadOnly Property getTypeOfRequest() As List(Of PropsFields.TypeOfRequest)
        Get
            Return cListOfTypeOfRequest
        End Get
    End Property

    Public ReadOnly Property getProperNaming() As List(Of PropsFields.whItems_properName_fields)
        Get
            Return cListOfProperNames
        End Get
    End Property

    Public ReadOnly Property getListOfRsDatas() As List(Of COLUMNS)
        Get
            Return listOfRsDatas
        End Get
    End Property

    Public ReadOnly Property getListOfReceiving() As List(Of PropsFields.receiving_props_fields)
        Get
            Return cListOfReceiving
        End Get
    End Property

    Public ReadOnly Property getMainRsSub() As List(Of PropsFields.main_rsdata_props_fields)
        Get
            Return clistOfMainRsSub
        End Get
    End Property

    Public ReadOnly Property getMainRs() As List(Of PropsFields.main_rsdata_props_fields)
        Get
            Return cListOfMainRs
        End Get
    End Property

    Public Function isCancelled(id As Integer, transaction As String) As Object
        Try
            Dim rsCancelled As New ColumnValuesObj
            rsCancelled.addColumn("id")
            rsCancelled.addColumn("trans")
            rsCancelled.addColumn("trans_id")
            rsCancelled.addColumn("remarks")

            rsCancelled.setCondition($"trans_id = {id} and trans = '{transaction}'")

            Dim datas = rsCancelled.selectQuery_and_return_data("dbCancelledTransaction", False,, cTableNameType.supply_table)

            Return datas
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Private Function getSupplierById(supplierId As Integer) As String
        Try
            If cListOfSuppliers.Count > 0 Then
                Return cListOfSuppliers.FirstOrDefault(Function(x) x.supplier_id = supplierId).supplierName
            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Private Function getUpdateBy(user_id As Integer) As String
        Try

        Catch ex As Exception

        End Try
    End Function


#End Region

#Region "PRIVATE GET"
    Private Function isCancelledDataFor(transId As Integer,
                                        transaction As String,
                                        cancelledStatus As Boolean) As Boolean
        Try
            Dim isCancelled = cListOfCancelledTransaction.FirstOrDefault(Function(x)
                                                                             Return x.trans_id = transId And x.trans = transaction
                                                                         End Function)



            If isCancelled IsNot Nothing Or cancelledStatus = True Then
                Return True
            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function
#End Region

#Region "HOOKS"
    Private Function useUser(user_id As Integer) As String

        Try
            Dim users = cListOfUsers.FirstOrDefault(Function(x) x.user_id = user_id)
            If users IsNot Nothing Then
                useUser = $"{users.lName}, {users.fName}"
            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

    End Function

    Private Function useQuarry(quarry_id As Integer) As String
        Try
            Dim quarry = cListOfAllCharges.FirstOrDefault(Function(x)
                                                              Return x.charges_category.ToUpper() = "WAREHOUSE" And
                                                                 x.charges_id = quarry_id
                                                          End Function)

            If quarry IsNot Nothing Then
                useQuarry = quarry.charges
            End If

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Private Function useStockPile(category As String, id As Integer,
                                  Optional rsRow As PropsFields.rs_for_dr_props_fields = Nothing,
                                  Optional rrRow As PropsFields.receiving_props_fields = Nothing,
                                  Optional level As String = "") As String
        Try

#Region "FOR DR/PURCHASE ORDER TRANSACTION"
            If rsRow IsNot Nothing Then
                If rsRow.type_of_purchasing = cTypeOfPurchasing.PURCHASE_ORDER Then
                    Return rrRow.supplier
                    Exit Function
                End If
            End If

#End Region

#Region "FOR DR/IN TRANSACTION"
            Dim stockpile = cListOfAllCharges.FirstOrDefault(Function(x)
                                                                 Return x.charges_category.ToUpper() = category.ToUpper() And
                                                                 x.charges_id = id
                                                             End Function)

            If stockpile IsNot Nothing Then
                Return stockpile.charges
            End If
#End Region


        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Private Function useItems(wh_id As Integer) As PropsFields.whItems_props_fields
        Try
            useItems = cListOfWarehouseItems.FirstOrDefault(Function(x) x.wh_id = wh_id)
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function


#End Region

#Region "CRUD"
    Public Function removeItemChecked() As Boolean
        Try
            Dim row = cDgv.SelectedRows(0)
            Dim rs_id As Integer = row.Cells(NameOf(cn.rs_id)).Value
            Dim typeOfPurchasing As String = row.Cells(NameOf(cn.type_of_purchasing)).Value
            Dim inout As String = row.Cells(NameOf(cn.inOut)).Value

#Region "FILTER"

            If Not isAuthenticatedWithoutMessage(auth) Then
                If typeOfPurchasing.ToUpper() = cTypeOfPurchasing.WITHDRAWAL Then
                    Dim ws As Double = getWithdrawnAggregates(rs_id)

                    If ws > 0 Then
                        customMsg.message("error", "Unable to remove item checked, when some items already withdrawn...", "SUPPLY INFO:")
                        Return False
                    End If

                ElseIf typeOfPurchasing.ToUpper() = cTypeOfPurchasing.PURCHASE_ORDER Then
                    Dim po As Double = getPurchasedAggregates(rs_id)

                    If po > 0 Then
                        customMsg.message("error", "Unable to remove item checked, when some items already purchased...", "SUPPLY INFO:")
                        Return False
                    End If

                ElseIf typeOfPurchasing.ToUpper = cTypeOfPurchasing.DR Then
                    Dim delivered As Double = getDeliveredAggregates(inout, rs_id)

                    If delivered > 0 Then
                        customMsg.message("error", "Unable to remove item checked, when some items already delivered...", "SUPPLY INFO:")
                        Return False
                    End If
                End If
            End If

#End Region
            If customMsg.messageYesNo("Are you sure you want to remove item checked?", "SUPPLY INFO:", MessageBoxIcon.Question) Then
                'execute remove
                Dim cc As New ColumnValuesObj
                cc.add("IN_OUT", Nothing)
                cc.add("type_of_purchasing", Nothing)
                cc.add("remarks", Nothing)
                cc.add("warehouse_checker_id", Nothing)
                cc.add("item_checked_log", Nothing)
                cc.add("wh_incharge", Nothing)
                cc.add("approved_by", Nothing)
                cc.add("wh_id", Nothing)

                cc.setCondition($"rs_id = {rs_id}")
                removeItemChecked = cc.updateQuery_return_true("dbrequisition_slip")
                isRemovedItemChecked = True
                cRsId = rs_id
            End If


            'cc.add("IN_OUT", .inOut)
            'cc.add("remarks", .remarks)
            'cc.add("type_of_purchasing", .typeOfPurchasing)
            'cc.add("warehouse_checker_id", .user_id)
            'cc.add("item_checked_log", Date.Parse(Now))
            'cc.add("wh_incharge", .warehouseIncharge)
            'cc.add("approved_by", .approved_by)
            'cc.add("wh_id", .wh_id)
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Public Function removeRequisition(row As COLUMNS) As Boolean
        Try
            Dim cc As New ColumnValuesObj
            Dim deleteRsServices As New DeleteRequesitionSlipServices
            Select Case row.inOut
                Case cInOut._OUT

                    Dim wsReleased = getWithdrawnAggregates(row.rs_id)

                    If wsReleased > 0 Then
                        customMsg.message("error", "naa na mga withdrawal", "SUPPLY EXCEPINFO:")
                    Else
                        removeRequisition = deleteRsServices.ExecuteWithReturnBoolean(row)
                    End If

                Case cInOut._IN, cInOut._OTHERS
                    If row.type_of_purchasing = cTypeOfPurchasing.PURCHASE_ORDER Then
                        Dim po = getPurchasedAggregates(row.rs_id)

                        If po > 0 Then
                            customMsg.message("error", "naa na mga po", "SUPPLY EXCEPINFO:")
                        Else
                            removeRequisition = deleteRsServices.ExecuteWithReturnBoolean(row)
                        End If

                    ElseIf row.type_of_purchasing = cTypeOfPurchasing.CASH_WITH_RR Then
                        Dim rr = getReceivedAggregatesCashWithRR(row.rs_id)

                        If rr > 0 Then
                            customMsg.message("error", "naa na mga rr", "SUPPLY EXCEPINFO:")
                        Else
                            removeRequisition = deleteRsServices.ExecuteWithReturnBoolean(row)
                        End If

                    ElseIf row.type_of_purchasing = cTypeOfPurchasing.CASH_WITHOUT_RR Then

                        removeRequisition = deleteRsServices.ExecuteWithReturnBoolean(row)

                    ElseIf row.type_of_purchasing = cTypeOfPurchasing.DR Then
                        Dim dr = getDeliveredAggregates(row.inOut, row.rs_id)

                        If dr > 0 Then
                            customMsg.message("error", "naa na mga dr", "SUPPLY EXCEPINFO:")
                        Else
                            removeRequisition = deleteRsServices.ExecuteWithReturnBoolean(row)
                        End If
                    End If

                Case ""
                    If row.type_of_purchasing = "" Then
                        removeRequisition = deleteRsServices.ExecuteWithReturnBoolean(row)
                    End If
            End Select

            Return removeRequisition

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function


    Public Sub addProperNamesToListOfProperNames(item As whItems_properName_fields)
        cListOfProperNames.Add(item)
    End Sub
#End Region

#Region "CRUD FOR PO FORM"
    Public Sub updatePOrow(poRowUpdate As PropsFields.Purchase_Order_Row, dgv As DataGridView)
        Try
            Dim rowIndex As Integer = RawPoRows.FindIndex(Function(x) x.rs_id = poRowUpdate.rs_id)

            If CDbl(RawPoRows(rowIndex).rs_qty_balance) < CDbl(poRowUpdate.qty) Then
                customMsg.message("error", "The purchase order quantity cannot be greater than the RS quantity left...", "SUPPLY INFO:")
                Utilities.datagridviewSpecificRowFocus(dgv, poRowUpdate.rs_id, "rs_id")
                Exit Sub
            End If

            With poRowUpdate
                RawPoRows(rowIndex).supplier = .supplier
                RawPoRows(rowIndex).poNo = .poNo
                RawPoRows(rowIndex).qty = .qty
                RawPoRows(rowIndex).unit = .unit
                RawPoRows(rowIndex).unit_price = FormatNumber(.unit_price).ToString
                RawPoRows(rowIndex).amount = FormatNumber(.amount).ToString
                RawPoRows(rowIndex).price_with_tax = .price_with_tax
                RawPoRows(rowIndex).tax_category = .tax_category
                RawPoRows(rowIndex).tax_value = .tax_value
                RawPoRows(rowIndex).terms = .terms
            End With

            dgv.DataSource = Nothing
            dgv.DataSource = RawPoRows
            customizeGridViewForPo(dgv)

            Utilities.datagridviewSpecificRowFocus(dgv, poRowUpdate.rs_id, "rs_id")

            'If Row IsNot Nothing Then
            '    rowIndex = RawPoRows.Where(Function(x) x.rs_id = poRowUpdate.rs_id).ToList().IndexOf(Row)
            'End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
#End Region

#Region "CRUD FOR RR FORM"
    Public Sub updateRRrow(rrRowUpdate As PropsFields.Receiving_row, dgv As DataGridView)
        Try
            Dim rowIndex As Integer
            If rrRowUpdate.po_det_id = 0 Then
                'for cash with rr
                rowIndex = RawRrRows.FindIndex(Function(x) x.rs_id = rrRowUpdate.rs_id)
            Else
                rowIndex = RawRrRows.FindIndex(Function(x) x.po_det_id = rrRowUpdate.po_det_id)
            End If

            If CDbl(RawRrRows(rowIndex).po_qty_balance) < CDbl(rrRowUpdate.rr_qty) Then
                customMsg.message("error", "The receiving quantity cannot be greater than the PO quantity left...", "SUPPLY INFO:")
                Utilities.datagridviewSpecificRowFocus(dgv, rrRowUpdate.po_det_id, "po_det_id")
                Exit Sub
            End If

            With rrRowUpdate
                RawRrRows(rowIndex).rr_qty = .rr_qty
                RawRrRows(rowIndex).unit = .unit
                RawRrRows(rowIndex).unit_price = FormatNumber(.unit_price).ToString
                RawRrRows(rowIndex).amount = FormatNumber(.amount).ToString
                RawRrRows(rowIndex).level = .level
                RawRrRows(rowIndex).rr_item_description = .rr_item_description
            End With

            dgv.DataSource = Nothing
            dgv.DataSource = RawRrRows
            'customizeGridViewForPo(dgv)
            customizeGridViewForRr(dgv)

            If rrRowUpdate.po_det_id > 0 Then
                Utilities.datagridviewSpecificRowFocus(dgv, rrRowUpdate.po_det_id, "po_det_id")
            Else
                'for cash with rr focus
                Utilities.datagridviewSpecificRowFocus(dgv, rrRowUpdate.rs_id, "rs_id")
            End If


            'If Row IsNot Nothing Then
            '    rowIndex = RawPoRows.Where(Function(x) x.rs_id = poRowUpdate.rs_id).ToList().IndexOf(Row)
            'End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Public Sub updateRRrowForEdit(rrRowUpdate As PropsFields.Receiving_row, dgv As DataGridView)
        Try
            With rrRowUpdate
                RawRrRows(0).rr_item_description = .rr_item_description
                RawRrRows(0).rr_qty = .rr_qty
                RawRrRows(0).unit = .unit
                RawRrRows(0).unit_price = FormatNumber(.unit_price).ToString
                RawRrRows(0).amount = FormatNumber(.amount).ToString
            End With

            dgv.DataSource = Nothing
            dgv.DataSource = RawRrRows
            'customizeGridViewForPo(dgv)
            customizeGridViewForRr(dgv)


        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub


#End Region

#Region "UTILITIES"
    Private Function oldWarehouseItemName(rs As PropsFields.rs_for_dr_props_fields) As String
        Try
            If rs.wh_id > 0 Then
                Return $"({rs.whItem} - {rs.whItemDesc})"
            Else
                Return ""
            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function
    Public Function getRefactoredRs() As List(Of PropsFields.rs_for_dr_props_fields)
        getRefactoredRs = cListOfRsForDr.Where(Function(x) Not String.IsNullOrEmpty(x.rs_items) And
                                                        Not String.IsNullOrEmpty(x.purpose) And
                                                        Not String.IsNullOrEmpty(x.unit_from_rs)).ToList()

        Return getRefactoredRs
    End Function
    Private Function getCharges(row As PropsFields.rs_for_dr_props_fields) As String
        getCharges = ""

        Dim allChargesIds = getRsMultipleCharges(row.rs_id)

        For Each chargesId In allChargesIds
            Dim charges = cListOfAllCharges.FirstOrDefault(Function(x)
                                                               Return x.charges_category.ToUpper() = chargesId.charges_category.ToUpper() And
                                                               x.charges_id = chargesId.charges_id
                                                           End Function)

            If charges IsNot Nothing Then
                getCharges &= $"{charges.charges},"
            End If
        Next

        getCharges = removeLastCharacter(getCharges)

    End Function
    Public Function getChargesByRsId(rsId As Integer) As String
        getChargesByRsId = ""

        Dim allChargesIds = getRsMultipleCharges(rsId)

        For Each chargesId In allChargesIds
            Dim charges = cListOfAllCharges.FirstOrDefault(Function(x)
                                                               Return x.charges_category.ToUpper() = chargesId.charges_category.ToUpper() And
                                                               x.charges_id = chargesId.charges_id
                                                           End Function)

            If charges IsNot Nothing Then
                getChargesByRsId &= $"{charges.charges},"
            End If
        Next

        getChargesByRsId = removeLastCharacter(getChargesByRsId)

    End Function
    Public Function getProperNameByWhPnId(row As PropsFields.rs_for_dr_props_fields)
        Dim propername = cListOfProperNames.FirstOrDefault(Function(x) x.wh_pn_id = row.wh_pn_id)

        Return propername
    End Function

    Public Function getProperNameBy_wh_pn_id_for_rs(row As PropsFields.rs_for_dr_props_fields)
        Dim propername = cListOfProperNames.FirstOrDefault(Function(x) x.wh_pn_id = row.wh_pn_id_for_rs)

        Return propername
    End Function
    Private Function getWarehouseItemByWhId(row As PropsFields.rs_for_dr_props_fields)
        Dim whitems = cListOfWarehouseItems.FirstOrDefault(Function(x) x.wh_id = row.wh_id)

        Return whitems
    End Function
    Private Function getTypeOfRequestWithAccountTitle(row As PropsFields.rs_for_dr_props_fields) As String
        Try
#Region "TYPE OF REQUEST"

            Dim listofconsolidation = cListOfConsolidationAccount
            Dim consolidation As New PropsFields.Consolidated_Account
            Dim typeofrequest As New PropsFields.TypeOfRequest

            If row.tors_ca_id <> 0 Then
                consolidation = listofconsolidation.FirstOrDefault(Function(x) x.tors_ca_id = row.tors_ca_id)

                If consolidation IsNot Nothing Then
                    getTypeOfRequestWithAccountTitle = $"{consolidation.tor_desc} / {consolidation.tor_sub_desc}" &
                                IIf(consolidation.tors_ca_id <> 0, $" / {consolidation.category} ({consolidation.codes})", "")
                End If
            Else
                typeofrequest = cListOfTypeOfRequest.FirstOrDefault(Function(x) x.tor_sub_id = row.tor_sub_id)

                If typeofrequest IsNot Nothing Then
                    getTypeOfRequestWithAccountTitle = $"{typeofrequest.tor_desc} / {typeofrequest.tor_sub_desc}"
                End If
            End If
#End Region

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function
    Private Function removeLastCharacter(word As String) As String
        Try
            If word.Length > 0 Then
                removeLastCharacter = word.Remove(word.Length - 1, 1)
            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function
    Public Function copyAllRsChargesFromThisRsId(rsId As Integer) As List(Of PropsFields.AllCharges)
        Try
            copyAllRsChargesFromThisRsId = getRsMultipleCharges(rsId)
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

    End Function
    Public Sub clearListOfrsData()
        listOfRsDatas.Clear()
    End Sub
#End Region

#Region "RS ROWS"
    Private Sub ADD_RS_ROW(rsRow As PropsFields.rs_for_dr_props_fields,
                           main_rs_qty_id As Integer)

        Dim rsColumn = RS_ROW(rsRow, main_rs_qty_id)
        listOfRsDatas.Add(rsColumn)

#Region "QUANTITY LEFT CALCULATION"
        If Not isClosedQty Then
            If rsRow IsNot Nothing Then
                _rsQuantityLeft -= rsRow.rs_qty
            End If

        End If

#End Region

    End Sub

#End Region

#Region "WITHDRAWAL SLIP ROWS"

    Private Sub ADD_WS_ROW(rsRow As PropsFields.rs_for_dr_props_fields)
        Dim _droption As String = ""

        Dim wsDatas = TryCast(getWsPoData(rsRow), List(Of PropsFields.ws_for_dr_props_fields))
        Dim _totalWithdrawn As Double
        If wsDatas IsNot Nothing Then
            For Each wsRow In wsDatas

#Region "TOTAL WITHDRAW"
                Dim drWithdrawn = TOTAL_WITHDRAW(rsRow, wsRow)

                Dim wsColumn = WS_ROW(rsRow, wsRow)
                listOfRsDatas.Add(wsColumn)
#End Region

                'for partial released | this function is intended for warehousing
                ADD_PARTIAL_RELEASED_WITHDRAWN(rsRow, wsRow)
                _totalWithdrawn += drWithdrawn()

#Region "WS -> DR ROWS"
                If wsRow.dr_option = "WITH DR" Then 'WITH DR
                    WITH_DR_ROW(rsRow, wsRow, _totalWithdrawn)

                ElseIf wsRow.dr_option = "WITHOUT DR" Then 'WITHOUT DR
                    _droption = wsRow.dr_option
                End If
#End Region

            Next
        End If

    End Sub

    Public Sub ADD_PARTIAL_RELEASED_WITHDRAWN(rsRow As PropsFields.rs_for_dr_props_fields, wsRow As PropsFields.ws_for_dr_props_fields)
        Dim partiallyreleasedwithdrawnDatas = getPartiallyReleasedWithdrawn(rsRow, wsRow)

        For Each pwRow In partiallyreleasedwithdrawnDatas

            Dim pwColumn = PW_ROW(rsRow, wsRow, pwRow)
            listOfRsDatas.Add(pwColumn)
        Next
    End Sub

    Private Sub WITH_DR_ROW(rsRow As PropsFields.rs_for_dr_props_fields,
                        wsRow As PropsFields.ws_for_dr_props_fields,
                            totalWithdrawn As Double)

        Dim totalDrDelivered As Double = _WS_DR_ROW(rsRow, wsRow)

#Region "TOTAL DELIVERED ROW"
        If totalDrDelivered > 0 Then
            Dim drColumnNew = TOTAL_DELIVERED_ROW(totalDrDelivered, totalWithdrawn, "WITHDRAWN")
            listOfRsDatas.Add(drColumnNew)
        End If
#End Region
    End Sub

    Private Function _WS_DR_ROW(rsRow As PropsFields.rs_for_dr_props_fields,
                           wsRow As PropsFields.ws_for_dr_props_fields) As Double

        Dim drDatas = getDrData(rsRow)
        Dim _totalDelivered As Double

        If drDatas IsNot Nothing Then

            For Each drRow In drDatas.Where(Function(x) x.ws_no = wsRow.ws_no).ToList()

                Dim drDelivered = TOTAL_DELIVERED(rsRow, drRow)

#Region "DR ROW"
                Dim drColumn = DR_ROW(rsRow, wsRow, drRow, cLevel.dr_out)
                listOfRsDatas.Add(drColumn)
#End Region

#Region "FOR STOCKPILE TO STOCKPILE"
                STOCKPILE_TO_STOCKPILE_ROW(rsRow, wsRow, drRow)
#End Region

                _totalDelivered += drDelivered()
            Next
        End If

        _WS_DR_ROW = _totalDelivered
    End Function

    Private Sub STOCKPILE_TO_STOCKPILE_ROW(rsRow As PropsFields.rs_for_dr_props_fields,
                                           wsRow As PropsFields.ws_for_dr_props_fields,
                                           drRow As PropsFields.dr_for_dr_props_fields)
        'is stockpile to stockpile ?
        Dim isStockpileToStockpile As Boolean = cListOfDrForDr.Where(Function(x) x.dr_no = drRow.dr_no).ToList().Count() = 2

        If isStockpileToStockpile Then 'true

            Dim DRINDATA = cListOfDrForDr.FirstOrDefault(Function(x) Not x.dr_item_id = drRow.dr_item_id And x.dr_no = drRow.dr_no)
            Dim drColumnIn = DR_ROW(rsRow, wsRow, DRINDATA, cLevel.dr_in)
            listOfRsDatas.Add(drColumnIn)

        End If
    End Sub
#End Region

#Region "PURCHASE ORDER ROWS"
    Private Sub ADD_PO_CASH_WITH_RR_ROW(rsRow As PropsFields.rs_for_dr_props_fields)

        If rsRow.type_of_purchasing = cTypeOfPurchasing.PURCHASE_ORDER Then

            Dim poDatas = TryCast(getWsPoData(rsRow), List(Of PropsFields.po_for_dr_props_fields))
            _PO_ROW(rsRow)

        ElseIf rsRow.type_of_purchasing = cTypeOfPurchasing.CASH_WITH_RR Then

            _RS_RR_ROW(rsRow)

        Else

            _RS_DR_ROW(rsRow)

        End If
    End Sub

    Private Sub _RS_DR_ROW(rsRow As PropsFields.rs_for_dr_props_fields)

        Dim drDatas = getDrData(rsRow).Where(Function(x) x.rs_id = rsRow.rs_id).ToList()

#Region "DR ROWS"
        Dim _totalDelivered As Double

        If drDatas IsNot Nothing Then

            For Each drRow In drDatas
                Dim drDelivered = TOTAL_DELIVERED(rsRow, drRow)

                Dim drColumn = DR_ROW(rsRow, Nothing, drRow, cLevel.dr_others)
                listOfRsDatas.Add(drColumn)

                _totalDelivered += drDelivered()
            Next
        End If

        If drDatas.Count > 0 Then
            Dim drColumnNew = TOTAL_DELIVERED_ROW(_totalDelivered,, "OTHERS")
            listOfRsDatas.Add(drColumnNew)
        End If

#End Region

    End Sub

    Private Sub _RS_RR_ROW(rsRow As PropsFields.rs_for_dr_props_fields)

#Region "RECEIVING ROWS"
        Dim rrDatas = getRRForCashWithRRData(rsRow)
        'Dim _totalReceived As Double

        If rrDatas IsNot Nothing Then
            For Each rrRow In rrDatas
                Dim drReceived = TOTAL_RECEIVED(rsRow, rrRow)

                Dim rrColumn = RR_CASH_WITH_RR_ROW(rsRow, rrRow)
                listOfRsDatas.Add(rrColumn)
            Next
        End If
#End Region
    End Sub

    Private Sub _PO_ROW(rsRow As PropsFields.rs_for_dr_props_fields)
        Dim poDatas = TryCast(getWsPoData(rsRow), List(Of PropsFields.po_for_dr_props_fields))

        If poDatas IsNot Nothing Then
            For Each poRow In poDatas

#Region "PO ROW"
                Dim poColumn = PO_ROW(rsRow, poRow)
                listOfRsDatas.Add(poColumn)

                _PO_RR_ROW(rsRow, poRow)
#End Region
            Next
        End If
    End Sub

    Private Sub _PO_RR_ROW(rsRow As PropsFields.rs_for_dr_props_fields,
                        poRow As PropsFields.po_for_dr_props_fields)

        Dim rrDatas = getRRData(poRow)

        Dim _totalReceived As Double

        If rrDatas IsNot Nothing Then
            For Each rrRow In rrDatas.Where(Function(x)
                                                Return x.rs_id = rsRow.rs_id
                                            End Function).ToList()
#Region "RR ROW"
                Dim rrColumn = RR_ROW(rsRow, rrRow)
                listOfRsDatas.Add(rrColumn)

                _totalReceived += rrRow.rr_qty
                _RR_DR_ROW(rsRow, rrRow, _totalReceived)
#End Region

            Next
        End If
    End Sub

    Private Sub _RR_DR_ROW(rsRow As PropsFields.rs_for_dr_props_fields,
                           rrRow As PropsFields.receiving_props_fields,
                           totalReceived As Double)
#Region "DR ROWS"
        Dim drReceived = TOTAL_RECEIVED(rsRow, rrRow)
        Dim poDrDatas = getDrData(rsRow).Where(Function(x)
                                                   Return x.rr_no = rrRow.rr_no
                                               End Function).ToList()

        Dim _totalDelivered As Double

        If poDrDatas IsNot Nothing Then
            For Each drRow In poDrDatas

                Dim drDelivered = TOTAL_DELIVERED(rsRow, drRow)

#Region "DR ROW"
                Dim drColumn = DR_ROW(rsRow, Nothing, drRow, cLevel.dr_others, rrRow)
                listOfRsDatas.Add(drColumn)
#End Region
                _totalDelivered += drDelivered()
            Next
        End If

        If rsRow.division = cDivision.CRUSHING_AND_HAULING And
                        poDrDatas.Count > 0 Then

            Dim drColumnDelivered = TOTAL_DELIVERED_ROW(_totalDelivered, totalReceived, "RECEIVED")
            listOfRsDatas.Add(drColumnDelivered)
        End If
#End Region
    End Sub
#End Region

#Region "LOAD SEARCH BY CHARGES"
    Public Sub loadAllRsByCharges()

        Dim merged = listOfCuratedRsDatas.SelectMany(Function(c) c.listOfRs).ToList()

        cDgv.DataSource = merged?.Where(Function(x) Not x.level = "split-row").ToList()
        customizeGridView()
    End Sub
#End Region
End Class
