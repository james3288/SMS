Imports System.ComponentModel
Imports Microsoft.Office.Interop.Excel

Public Class ReceivingModel
    Private rsForDrModel,
        poForDrModel,
        allChargesModel,
        properNamingModel,
        whItemsModel,
        typeOfRequestModel,
        userModel,
        rrForDrModel,
        ConsolidationAccountModel,
        withdrawnModel,
        supplierModel,
        tireSerialNoViewModel As New ModelNew.Model

    Private cSearch As String
    Private cDgv As New DataGridView
    Private customMsg As New customMessageBox

    Private customDatagrid,
        customDatagridForPo,
        customDatagridForRr As New CustomGridview

    Private cLevel As New ROWLEVEL
    Private cLoadingPanel As New Panel

    Public rrBackgroundWorker,
        othersBackgroundWorker As New List(Of BackgroundWorker)
    Dim cBgWorkerChecker, cBgWorkerChecker2 As Timer

    Private cListOfPoForDr As New List(Of PropsFields.po_for_dr_props_fields)
    Private cListOfAllCharges As New List(Of PropsFields.AllCharges)
    Private cListOfWarehouseItems As New List(Of PropsFields.whItems_props_fields)
    Private cListOfProperNames As New List(Of PropsFields.whItems_properName_fields)
    Private cListOfTypeOfRequest As New List(Of PropsFields.TypeOfRequest)
    Private cListOfUsers As New List(Of PropsFields.smsUsers_props_fields)
    Private cListOfConsolidationAccount As New List(Of PropsFields.Consolidated_Account)
    Private cListOfSuppliers As New List(Of PropsFields.supplier_props_fields)
    Private cListOfRsForDr As New List(Of PropsFields.rs_for_dr_props_fields)
    Private cListOfReceiving As New List(Of PropsFields.receiving_props_fields)
    Private cListOfRsData As New List(Of PropsFields.rsdata_props_fields)
    Private cListOfTireSerialNoViews As New List(Of PropsFields.tireSerialView_props_fields)

    Public isCreateReceiving, isUpdateReceiving As Boolean

    Private listOfRrDatas As New List(Of COLUMNS)
    Public cn As New COLUMNS

    Public cRr_item_id, cRrItemSubId As Integer
    Private cGrandTotal As Double
    Private cSearchBarPanel As New Panel
    Public cRsColumnSettings As New ColumnSettingsLib
#Region "CORE ENTITIES"
    Public Class COLUMNS
        Public Property rr_item_id As Integer
        Public Property rr_info_id As Integer
        Public Property rr_no As String
        Public Property po_det_id As Integer
        Public Property rs_no As String
        Public Property po_cv_no As String
        Public Property invoice_no As String
        Public Property supplier As String
        Public Property date_received As DateTime
        Public Property po_qty As Double
        Public Property rr_qty As Double
        Public Property price As String
        Public Property total_amount As String
        Public Property unit As String
        Public Property item_name As String
        Public Property item_desc As String
        Public Property rr_item_desc As String
        Public Property tire_serialNo As String
        Public Property remarks As String
        Public Property type_of_purchasing As String
        Public Property status As String
        Public Property sorting As String
        Public Property charges As String
        Public Property wh_id As Integer
        Public Property inout As String
        Public Property checked_by As String
        Public Property received_by As String
        Public Property rs_purpose As String
        Public Property rs_id As Integer
        Public Property lead_time As String
        Public Property date_submitted As String
        Public Property wh_pn_id As Integer
        Public Property serial_id As Integer
        Public Property level As String
        Public Property division As String
        Public Property plateNo As String
        Public Property soNo As String
        Public Property source As String
        Public Property driver As String
        Public Property rr_item_sub_id As Integer
        Public Property updatedBy As String
        Public Property updatedAt As String
        Public Property dateLog As String
        Public Property user_inputted As String


    End Class

    Public Class ROWLEVEL
        Public ReadOnly Property rs As String = "rs"
        Public ReadOnly Property po As String = "po"
        Public ReadOnly Property rr As String = "rr"
        Public ReadOnly Property gt As String = "grand_total"


    End Class
#End Region

#Region "INITIALIZE AND PREVIEW"
    Public Sub initialize(searchBy As String,
                      search As String,
                      Optional dgv As DataGridView = Nothing)
        cSearch = search
        cDgv = dgv

        customDatagrid.customDatagridview(cDgv,,, 10)
    End Sub

    Public Sub initialize_searchBarPanel(searchBarPanel As Panel)
        cSearchBarPanel = searchBarPanel
    End Sub

    Public Sub execute_initialize(Optional loadingPanel As Panel = Nothing)
        Try

            Dim allChargesValues,
                propernameValues,
                warehouseItemsVlaues,
                typeofrequestvalues,
                consolidationValues,
                usersValues,
                areaStockpileValues,
                priceZoning,
                tireSerialNoViewValues As New ColumnValues

            consolidationValues.add("crud", 7)
            consolidationValues.add("search", "")

            cLoadingPanel = loadingPanel
            cLoadingPanel.Visible = True
            cSearchBarPanel.Enabled = False

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

            _initializing(cCol.forTireSerialNoView,
                      tireSerialNoViewValues.getValues(),
                      tireSerialNoViewModel,
                      othersBackgroundWorker)


            cBgWorkerChecker2 = BgWorkersCheckerFn(AddressOf SuccessfullyInitialize, othersBackgroundWorker)
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub


#End Region

#Region "EXECUTE"
    Public Sub execute()
        Try
            clearModels()
            cDgv.DataSource = Nothing
            cLoadingPanel.Visible = True
            cSearchBarPanel.Enabled = False

            Dim rsValues,
                rrValues,
                poValues,
                supplierValues As New ColumnValues

            rsValues.add("n", 1)
            rsValues.add("search", cSearch)
            rsValues.add("searchBy", FRequesitionSearchBy.cSearchByEnum.searchByRs)

            poValues.add("n", 4)
            poValues.add("search", cSearch)
            poValues.add("searchBy", FRequesitionSearchBy.cSearchByEnum.searchByRs)

            rrValues.add("n", 9)
            rrValues.add("search", cSearch)

            _initializing(cCol.forRsDr,
                rsValues.getValues(),
                rsForDrModel,
                rrBackgroundWorker)

            _initializing(cCol.forPoDr,
                poValues.getValues(),
                poForDrModel,
                rrBackgroundWorker)

            _initializing(cCol.forRrWithDetails,
                rrValues.getValues(),
                rrForDrModel,
                rrBackgroundWorker)

            _initializing(cCol.forSupplier,
                          supplierValues.getValues(),
                          supplierModel,
                          rrBackgroundWorker)

            cBgWorkerChecker = BgWorkersCheckerFn(AddressOf SuccessfullyDone, rrBackgroundWorker)

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
#End Region

#Region "SUCCESSFULLY DONE"

    Private Sub SuccessfullyInitialize()
        Try
            cListOfAllCharges = TryCast(allChargesModel.cData, List(Of PropsFields.AllCharges))
            cListOfProperNames = TryCast(properNamingModel.cData, List(Of PropsFields.whItems_properName_fields))
            cListOfWarehouseItems = TryCast(whItemsModel.cData, List(Of PropsFields.whItems_props_fields))
            cListOfTypeOfRequest = TryCast(typeOfRequestModel.cData, List(Of PropsFields.TypeOfRequest))
            cListOfUsers = TryCast(userModel.cData, List(Of PropsFields.smsUsers_props_fields))
            cListOfConsolidationAccount = TryCast(ConsolidationAccountModel.cData, List(Of PropsFields.Consolidated_Account))
            cListOfTireSerialNoViews = TryCast(tireSerialNoViewModel.cData, List(Of PropsFields.tireSerialView_props_fields))

            cLoadingPanel.Visible = False
            cSearchBarPanel.Enabled = True

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
    Private Sub SuccessfullyDone()
        Try
            cListOfRsForDr = TryCast(rsForDrModel.cData, List(Of PropsFields.rs_for_dr_props_fields))
            cListOfPoForDr = TryCast(poForDrModel.cData, List(Of PropsFields.po_for_dr_props_fields))
            cListOfReceiving = TryCast(rrForDrModel.cData, List(Of PropsFields.receiving_props_fields))
            cListOfSuppliers = TryCast(supplierModel.cData, List(Of PropsFields.supplier_props_fields))

            preview()

            cLoadingPanel.Visible = False
            cSearchBarPanel.Enabled = True
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

#End Region

#Region "CLEAR"
    Public Sub clearModels()

        allChargesModel.clearParameter()
        properNamingModel.clearParameter()
        whItemsModel.clearParameter()
        typeOfRequestModel.clearParameter()
        userModel.clearParameter()
        supplierModel.clearParameter()

        rsForDrModel.clearParameter()
        poForDrModel.clearParameter()
        rrForDrModel.clearParameter()

        cListOfSuppliers.Clear()
        cListOfReceiving.Clear()

        cListOfRsForDr.Clear()
        cListOfPoForDr.Clear()
        cListOfReceiving.Clear()
        cListOfSuppliers.Clear()
        listOfRrDatas.Clear()


    End Sub
#End Region

#Region "PREVIEW"
    Private Sub preview()
        cGrandTotal = 0
        Dim rsData = getRsData()

        If rsData.Count > 0 Then

            For Each rs In rsData
                businessLogic(rs)
            Next

            'add row for grand total
            Dim grandTotalRow = GRAND_TOTAL_ROW(cGrandTotal)
            listOfRrDatas.Add(grandTotalRow)
        End If

        If listOfRrDatas.Count > 0 Then
            cDgv.DataSource = listOfRrDatas
            customizeGridView()

            'got focus
            If isCreateReceiving Then
                focusRowAfterUpdate(cDgv)
                isCreateReceiving = False


            ElseIf isUpdateReceiving Then
                focusRowAfterUpdateQty(cDgv)
                isUpdateReceiving = False

            End If
        End If

    End Sub

#End Region

#Region "BUSINESS LOGIC"
    Private Sub businessLogic(rsRow As PropsFields.rs_for_dr_props_fields)
        Try
#Region "REQUISITION ROWS"
            Dim rsColumn = RS_ROW(rsRow)
            'listOfRrDatas.Add(rsColumn)

            If rsRow.inout = cInOut._OTHERS Or rsRow.inout = cInOut._IN Then
                Dim wsDatas = TryCast(getWsPoData(rsRow), List(Of PropsFields.ws_for_dr_props_fields))

                If rsRow.type_of_purchasing = cTypeOfPurchasing.PURCHASE_ORDER Then
                    Dim poDatas = TryCast(getWsPoData(rsRow), List(Of PropsFields.po_for_dr_props_fields))

                    If poDatas IsNot Nothing Then
                        For Each poRow In poDatas

#Region "PURCHASE ORDER ROWS"
                            Dim poColumn = PO_ROW(rsRow, poRow)
                            listOfRrDatas.Add(poColumn)
#End Region

#Region "RECEIVING ROWS | PURCHASE ORDER"
                            Dim rrDatas = getRRData(poRow)?.Where(Function(x) x.rs_id = rsRow.rs_id).ToList()
                            Dim totalReceived As Double

                            If rrDatas?.Count > 0 Then
                                For Each rrRow In rrDatas
                                    Dim received = TOTAL_RECEIVED(rrRow)

                                    Dim rrColumn = RR_ROW(rsRow, rrRow, poRow)
                                    listOfRrDatas.Add(rrColumn)

                                    totalReceived += received()
                                Next

                                If rrDatas.Count > 0 Then
                                    Dim totalRow = TOTAL_ROW(totalReceived)
                                    listOfRrDatas.Add(totalRow)
                                End If

                                'add grand total
                                cGrandTotal += totalReceived
                            End If
#End Region

                        Next
                    End If

                ElseIf rsRow.type_of_purchasing = cTypeOfPurchasing.CASH_WITH_RR Then

#Region "RECEIVING ROWS | CASH WITH RR"
                    Dim rrDatas = TryCast(getRRdataForCashWithRR(rsRow), List(Of PropsFields.receiving_props_fields))
                    Dim totalReceived As Double

                    If rrDatas IsNot Nothing Then
                        For Each rrRow In rrDatas
                            Dim received = TOTAL_RECEIVED(rrRow)

                            Dim rrColumn = RR_ROW(rsRow, rrRow)
                            listOfRrDatas.Add(rrColumn)

                            totalReceived += received()
                        Next

                        If rrDatas.Count > 0 Then
                            Dim totalRow = TOTAL_ROW(totalReceived)
                            listOfRrDatas.Add(totalRow)
                        End If

                        'add grand total
                        cGrandTotal += totalReceived
                    End If
#End Region

                End If

            End If

#End Region

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
#End Region

#Region "GET"
    Public ReadOnly Property getListOfRrDatas() As List(Of COLUMNS)
        Get
            Return listOfRrDatas
        End Get
    End Property

    Public ReadOnly Property getListOfReceiving() As List(Of PropsFields.receiving_props_fields)
        Get
            Return cListOfReceiving
        End Get
    End Property
    Private Function getRsData() As List(Of PropsFields.rs_for_dr_props_fields)
        Try
            getRsData = New List(Of PropsFields.rs_for_dr_props_fields)
            'refactor first
            Dim refactoredRs = cListOfRsForDr.Where(Function(x) Not x.rs_no.ToUpper() = "N/A" And
                                                        x.inout <> cInOut._OUT).ToList()

            For Each row In refactoredRs
                If row.type_of_purchasing = cTypeOfPurchasing.PURCHASE_ORDER Or
                    row.type_of_purchasing = cTypeOfPurchasing.CASH_WITH_RR Then

                    Dim _rsData As New PropsFields.rs_for_dr_props_fields

                    With _rsData
                        .rs_id = row.rs_id
                        .rs_no = row.rs_no
                        .rs_date = row.rs_date
                        .date_needed = row.date_needed
                        .rs_items = row.rs_items
#Region "PROPER NAMES FOR ITEM"
                        If .wh_pn_id > 0 Then
                            Dim propername = cListOfProperNames.FirstOrDefault(Function(x) x.wh_pn_id = row.wh_pn_id)
                            If propername IsNot Nothing Then
                                .item_desc = $"{propername.item_name} - {propername.item_desc}"
                                .unit = propername.units
                            End If
                        Else
                            Dim whitems = cListOfWarehouseItems.FirstOrDefault(Function(x) x.wh_id = row.wh_id)
                            If whitems IsNot Nothing Then
                                .item_desc = $"{whitems.item_name} - {whitems.item_desc}"
                                .unit = whitems.units
                            End If
                        End If
#End Region
                        .rs_qty = row.rs_qty
                        .purpose = row.purpose
#Region "TYPE OF REQUEST"

                        Dim listofconsolidation = cListOfConsolidationAccount
                        Dim consolidation As New PropsFields.Consolidated_Account
                        Dim typeofrequest As New PropsFields.TypeOfRequest

                        If row.tors_ca_id <> 0 Then
                            consolidation = listofconsolidation.FirstOrDefault(Function(x) x.tors_ca_id = row.tors_ca_id)

                            If consolidation IsNot Nothing Then
                                .type_of_request = $"{consolidation.tor_desc} | {consolidation.tor_sub_desc}" &
                                    IIf(consolidation.tors_ca_id <> 0, $" | {consolidation.category} ({consolidation.codes})", "")
                            End If
                        Else
                            typeofrequest = cListOfTypeOfRequest.FirstOrDefault(Function(x) x.tor_sub_id = row.tor_sub_id)

                            If typeofrequest IsNot Nothing Then
                                .type_of_request = $"{typeofrequest.tor_desc} | {typeofrequest.tor_sub_desc}"
                            End If
                        End If
#End Region
                        .inout = row.inout
#Region "CHARGES"
                        Dim charges = cListOfAllCharges.FirstOrDefault(Function(x)
                                                                           Return x.charges_category.ToUpper() = row.type_of_charges.ToUpper() And
                                                                           x.charges_id = row.charges_id
                                                                       End Function)

                        If charges IsNot Nothing Then
                            .charges = charges.charges
                        End If
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

                    End With

                    getRsData.Add(_rsData)
                End If

            Next

            Return getRsData
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

    End Function
    Private Function getWsPoData(rsRow As PropsFields.rs_for_dr_props_fields)
        Try
            Select Case rsRow.inout
                Case cInOut._IN, cInOut._OTHERS
                    If cListOfPoForDr.Count > 0 Then
                        Dim refactoredPo = cListOfPoForDr.Where(Function(x) x.rs_id = rsRow.rs_id).ToList()

                        Return TryCast(refactoredPo, List(Of PropsFields.po_for_dr_props_fields))
                    End If

            End Select
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
            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function
    Private Function getRRdataForCashWithRR(rsRow As PropsFields.rs_for_dr_props_fields) As List(Of PropsFields.receiving_props_fields)
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
#End Region

#Region "DATAGRIDVIEW ROWS"
    Private Function RS_ROW(rsRow As PropsFields.rs_for_dr_props_fields) As COLUMNS
        RS_ROW = New COLUMNS

        Try
            With RS_ROW
                .rs_id = rsRow.rs_id
                .rs_no = rsRow.rs_no
                .item_desc = $"{Utilities.isItemChecked(rsRow.wh_id)} {rsRow.rs_items} {oldWarehouseItemName(rsRow)}"
                .unit = rsRow.unit
                .rs_purpose = rsRow.purpose
                .type_of_purchasing = rsRow.type_of_purchasing
                .inout = rsRow.inout
                .charges = rsRow.charges
                .wh_id = rsRow.wh_id
                .level = cLevel.rs
                .division = rsRow.division
            End With

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Private Function PO_ROW(rsRow As PropsFields.rs_for_dr_props_fields, PoRow As PropsFields.po_for_dr_props_fields) As COLUMNS
        PO_ROW = New COLUMNS

        Try
            With PO_ROW
                .po_det_id = PoRow.po_det_id
                .rs_id = PoRow.po_det_id
                .rs_no = rsRow.rs_no
                .po_cv_no = PoRow.po_no
                .date_received = PoRow.po_date
                .po_qty = PoRow.po_qty

#Region "PRICE"
                If PoRow.tax_category = "" Then
                    .price = PoRow.unit_price
                Else
                    .price = calculateTax(PoRow.tax_category, PoRow.unit_price, PoRow.vat_value)
                End If

#End Region
                .supplier = getSupplier(PoRow, cListOfSuppliers)
                .unit = PoRow.units
                .charges = rsRow.charges
                .wh_id = PoRow.wh_id
                .type_of_purchasing = rsRow.type_of_purchasing
                .inout = rsRow.inout
                .level = cLevel.po
                .item_desc = $"{rsRow.rs_items} {oldWarehouseItemName(rsRow)}"
                .division = rsRow.division

            End With

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Private Function RR_ROW(rsRow As PropsFields.rs_for_dr_props_fields,
                            rrRow As PropsFields.receiving_props_fields,
                            Optional poRow As PropsFields.po_for_dr_props_fields = Nothing) As COLUMNS
        Try

            RR_ROW = New COLUMNS

            With RR_ROW
                .rs_id = rrRow.rr_item_id
                .rs_no = rsRow.rs_no
                .rr_no = rrRow.rr_no
                .date_received = rrRow.date_received
                .rr_qty = rrRow.rr_qty
                .price = FormatNumber(Utilities.ifBlankReplaceToZero(rrRow.price)).ToString()
                .total_amount = FormatNumber(getTotalReceived(Utilities.ifBlankReplaceToZero(rrRow.price), rrRow.rr_qty)).ToString()
                .unit = rrRow.unit
                .charges = rsRow.charges
                .wh_id = rsRow.wh_id
                .type_of_purchasing = rsRow.type_of_purchasing
                .inout = rsRow.inout
                .level = cLevel.rr
                .item_desc = $"{rsRow.rs_items} {oldWarehouseItemName(rsRow)}"
                .tire_serialNo = "-"
                .invoice_no = rrRow.invoice_no
                .remarks = rrRow.remarks
                .date_submitted = Utilities.is1990(rrRow.date_submitted)

                .supplier = rrRow.supplier
                .rs_purpose = rsRow.purpose
                .rr_item_id = rrRow.rr_item_id
                .received_by = rrRow.received_by
                .checked_by = rrRow.checked_by
                .plateNo = rrRow.plateNo
                .rr_no = rrRow.rr_no
                .soNo = rrRow.soNo
                .unit = rrRow.unit
                .rr_info_id = rrRow.rr_info_id
                .division = rsRow.division

                .driver = rrRow.driver
                .source = rrRow.source
                .rr_item_desc = rrRow.rr_item_desc
                .rr_item_sub_id = rrRow.rr_item_sub_id
#Region "FOR TIRE"
                If rrRow.serial_id > 0 Then
                    .serial_id = rrRow.serial_id
                    .rr_qty = 1
                    .tire_serialNo = getSerialInfo(rrRow.serial_id)
                    .total_amount = FormatNumber(getTotalReceived(Utilities.ifBlankReplaceToZero(rrRow.price), 1)).ToString()

                End If

#End Region

                If rsRow.type_of_purchasing = cTypeOfPurchasing.CASH_WITH_RR Then
                    .lead_time = Utilities.DateDifference(rrRow.date_received, rsRow.rs_date)
                Else
                    If Not poRow Is Nothing Then
                        .po_cv_no = poRow.po_no
                        .lead_time = Utilities.DateDifference(rrRow.date_received, poRow.po_date)
                    End If
                End If

                .updatedBy = getUsers(cListOfUsers, rrRow.updatedById)
                .updatedAt = is1990(Utilities.DateConverter(rrRow.updatedAt))
                .user_inputted = getUsers(cListOfUsers, rrRow.user_id)
                .dateLog = is1990(Utilities.DateConverter(rrRow.date_log))

            End With
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Private Function TOTAL_ROW(totalAmount) As COLUMNS
        Try
            TOTAL_ROW = New COLUMNS

            With TOTAL_ROW
                .supplier = "SUB TOTAL"
                .total_amount = FormatNumber(totalAmount).ToString()
            End With

            Return TOTAL_ROW
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Private Function GRAND_TOTAL_ROW(totalAmount) As COLUMNS
        Try
            GRAND_TOTAL_ROW = New COLUMNS

            With GRAND_TOTAL_ROW
                .supplier = "GRAND TOTAL"
                .total_amount = FormatNumber(totalAmount).ToString()
                .level = cLevel.gt
            End With

            Return GRAND_TOTAL_ROW
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Private Function TOTAL_RECEIVED(rrRow As PropsFields.receiving_props_fields) As Func(Of Double)

        Try
            Dim totalReceived As Double
            Return Function()
                       totalReceived += getTotalReceived(rrRow.price, isForTireChangeQtyToOne(rrRow))
                       Return totalReceived
                   End Function
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

    End Function


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

    Private Function getSupplier(poRow As PropsFields.po_for_dr_props_fields, listOfSuppliers As List(Of PropsFields.supplier_props_fields)) As String
        Try
            Dim supplier = listOfSuppliers.FirstOrDefault(Function(x) x.supplier_id = poRow.supplier_id)

            If supplier IsNot Nothing Then
                getSupplier = supplier.supplierName
            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Private Function getSerialInfo(serial_id As Integer) As String
        Try
            Dim tireSerial = cListOfTireSerialNoViews.FirstOrDefault(Function(x) x.serial_id = serial_id)

            If tireSerial IsNot Nothing Then
                getSerialInfo = $"{tireSerial.serial_no} | {tireSerial.position}"
            Else
                getSerialInfo = "-"
            End If

            Return getSerialInfo
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Private Function getTotalReceived(price As String, quantity As Double) As Double
        Try
            If Not price = "" Or Not price Is Nothing Then
                If IsNumeric(price) Then
                    getTotalReceived = price * quantity
                End If
            End If
        Catch ex As Exception

        End Try
    End Function
    Private Sub focusRowAfterUpdate(dgv As DataGridView)
        Utilities.datagridviewSpecificRowFocus(dgv, cRr_item_id, NameOf(cn.rr_item_id))
        cRr_item_id = 0
    End Sub
    Private Sub focusRowAfterUpdateQty(dgv As DataGridView)
        Utilities.datagridviewSpecificRowFocus(dgv, cRrItemSubId, NameOf(cn.rr_item_sub_id))
        cRrItemSubId = 0
    End Sub

    Private Function isForTireChangeQtyToOne(rrRow As PropsFields.receiving_props_fields) As Double
        Try
            If rrRow.serial_id > 0 Then
                Return 1
            Else
                Return rrRow.rr_qty
            End If
        Catch ex As Exception

        End Try

    End Function

#End Region

#Region "CUSTOMIZE SOMETHING"
    Private Sub customizeGridView()
        Try
            customDatagrid.readonlyAllCells(cDgv)

            For Each row As DataGridViewRow In cDgv.Rows
                If row.Cells(NameOf(cn.level)).Value = cLevel.rs Then
                    row.DefaultCellStyle.BackColor = cRsRowColor.MainSubRS
                    row.DefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#DFD0B8")

                ElseIf row.Cells(NameOf(cn.level)).Value = cLevel.po Then
                    row.DefaultCellStyle.BackColor = cRsRowColor.WsPo
                    row.DefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#DFDFDF")

                ElseIf row.Cells(NameOf(cn.level)).Value = cLevel.rr Then
                    row.DefaultCellStyle.BackColor = cRsRowColor.Rr
                    row.DefaultCellStyle.ForeColor = Color.Black

                ElseIf row.Cells(NameOf(cn.level)).Value = cLevel.gt Then
                    row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#282E39")
                    row.DefaultCellStyle.ForeColor = Color.White
                End If
            Next


            'rename columns
            cDgv.Columns(NameOf(cn.rr_item_id)).HeaderText = "RR_ITEM_ID"
            cDgv.Columns(NameOf(cn.rr_info_id)).HeaderText = "RR_INFO_ID"
            cDgv.Columns(NameOf(cn.rs_no)).HeaderText = "RS NO."
            cDgv.Columns(NameOf(cn.rr_no)).HeaderText = "RR NO."
            cDgv.Columns(NameOf(cn.po_cv_no)).HeaderText = "PO NO."
            cDgv.Columns(NameOf(cn.item_desc)).HeaderText = "ITEM DESCRIPTION"
            cDgv.Columns(NameOf(cn.tire_serialNo)).HeaderText = "SERIAL/TIRE"
            cDgv.Columns(NameOf(cn.date_received)).HeaderText = "DATE RECEIVED"
            cDgv.Columns(NameOf(cn.date_submitted)).HeaderText = "DATE SUBMITEED"
            cDgv.Columns(NameOf(cn.rr_qty)).HeaderText = "RR QTY"
            cDgv.Columns(NameOf(cn.po_qty)).HeaderText = "PO QTY"
            cDgv.Columns(NameOf(cn.supplier)).HeaderText = "SUPPLIER"
            cDgv.Columns(NameOf(cn.invoice_no)).HeaderText = "INVOICE NO."
            cDgv.Columns(NameOf(cn.price)).HeaderText = "PRICE"
            cDgv.Columns(NameOf(cn.remarks)).HeaderText = "REMARKS"
            cDgv.Columns(NameOf(cn.type_of_purchasing)).HeaderText = "TYPE OF PURCHASING"
            cDgv.Columns(NameOf(cn.total_amount)).HeaderText = "TOTAL AMOUNT"
            cDgv.Columns(NameOf(cn.status)).HeaderText = "STATUS"
            cDgv.Columns(NameOf(cn.charges)).HeaderText = "CHARGES"
            cDgv.Columns(NameOf(cn.wh_id)).HeaderText = "WH_ID"
            cDgv.Columns(NameOf(cn.inout)).HeaderText = "IN/OTHERS"
            cDgv.Columns(NameOf(cn.inout)).HeaderText = "IN/OTHERS"
            cDgv.Columns(NameOf(cn.checked_by)).HeaderText = "CHECKED BY"
            cDgv.Columns(NameOf(cn.received_by)).HeaderText = "RECEIVED BY"
            cDgv.Columns(NameOf(cn.rs_purpose)).HeaderText = "RS PURPOSE"
            cDgv.Columns(NameOf(cn.unit)).HeaderText = "UNITS"
            cDgv.Columns(NameOf(cn.lead_time)).HeaderText = "LEAD TIME"
            cDgv.Columns(NameOf(cn.division)).HeaderText = "DIVISION"
            cDgv.Columns(NameOf(cn.plateNo)).HeaderText = "PLATE NO"
            cDgv.Columns(NameOf(cn.soNo)).HeaderText = "SO NO"
            cDgv.Columns(NameOf(cn.source)).HeaderText = "INSOURCE/OUTSOURCE"
            cDgv.Columns(NameOf(cn.driver)).HeaderText = "DRIVER"
            cDgv.Columns(NameOf(cn.rr_item_desc)).HeaderText = "RR ITEM DESCRIPTION"
            cDgv.Columns(NameOf(cn.updatedAt)).HeaderText = "UPDATED AT"
            cDgv.Columns(NameOf(cn.updatedBy)).HeaderText = "UPDATED BY"
            cDgv.Columns(NameOf(cn.dateLog)).HeaderText = "DATE INPUTTED"
            cDgv.Columns(NameOf(cn.user_inputted)).HeaderText = "INPUTTED BY"


            'hide columns
            cDgv.Columns(NameOf(cn.po_det_id)).Visible = False
            cDgv.Columns(NameOf(cn.item_name)).Visible = False
            cDgv.Columns(NameOf(cn.sorting)).Visible = False
            cDgv.Columns(NameOf(cn.rs_id)).Visible = False
            cDgv.Columns(NameOf(cn.wh_pn_id)).Visible = False
            cDgv.Columns(NameOf(cn.level)).Visible = False


            ' Only horizontal lines
            cDgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical

            ' Only vertical lines
            cDgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal

            'width


            'disable resize
            cDgv.AllowUserToResizeRows = False

            customDatagrid.customHeader(cDgv)
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
#End Region
End Class
