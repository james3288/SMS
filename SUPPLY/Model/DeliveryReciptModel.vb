Imports System.ComponentModel
Imports System.Data.SqlClient
Imports SUPPLY.FCreateDeliveryReceipt

Public Class DeliveryReciptModel
    Private employeeModel, supplierModel, properNamesModel As New ModelNew.Model
    Public createWsBgWorker As New List(Of BackgroundWorker)
    Private customDatagrid As New CustomGridview

    Dim cBgWorkerChecker As Timer
    Private cSearch As String
    Private cDgv As New DataGridView

    Private cLoadingPanel As New Panel
    Private customMsg As New customMessageBox

    Private cListOfDrDataRepo As New List(Of PropsFields.dr_list_props_fields)

    Private cWsRepo As New List(Of PropsFields.dr_ws_props_fields)
    Private cPoRepo As New List(Of PropsFields.dr_po_props_fields)


#Region "CORE ENTITIES"

#End Region

#Region "INITIALIZE AND PREVIEW"
    Public Sub initialize_ws(wsData As List(Of PropsFields.dr_ws_props_fields))
        cWsRepo = wsData
    End Sub

    Public Sub initialize_po(poData As List(Of PropsFields.dr_po_props_fields))
        cPoRepo = poData
    End Sub
    ' Public Sub initialize(searchBy As String,
    '                       search As String,
    '                       Optional dgv As DataGridView = Nothing)
    '     cSearch = search
    '     cDgv = dgv

    '     customDatagrid.customDatagridview(cDgv,,, 10)
    ' End Sub

    '  Public Sub execute_initialize(Optional loadingPanel As Panel = Nothing)
    '      Try


    '          Dim allChargesValues,
    '              propernameValues,
    '              warehouseItemsVlaues,
    '              typeofrequestvalues,
    '              consolidationValues,
    '              usersValues,
    '              areaStockpileValues,
    '              priceZoning As New ColumnValues

    '          consolidationValues.add("crud", 7)
    '          consolidationValues.add("search", "")

    '          cLoadingPanel = loadingPanel
    '          cLoadingPanel.Visible = True

    '          _initializing(cCol.forAllCharges,
    '                        allChargesValues.getValues(),
    '                        allChargesModel,
    '                        othersBackgroundWorker)

    '          cBgWorkerChecker2 = BgWorkersCheckerFn(AddressOf SuccessfullyInitialize, othersBackgroundWorker)
    '      Catch ex As Exception
    '          customMsg.ErrorMessage(ex)
    '      End Try
    '  End Sub

    ' private sub Preview()

    ' End Sub
#End Region

#Region "SUCCESSFULLY INITIALIZE"
    ' Private Sub SuccessfullyInitialize()
    '     Try
    '         cListOfAllCharges = TryCast(allChargesModel.cData, List(Of PropsFields.AllCharges))        
    '         cLoadingPanel.Visible = False

    '     Catch ex As Exception
    '         customMsg.ErrorMessage(ex)
    '     End Try
    ' End Sub
#End Region

#Region "BUSINESS LOGIC"

#End Region

#Region "DATAGRIDVIEW ROWS"

#End Region

#Region "DATAGRIDVIEW ROWS FROM OTHER FORMS"

#End Region

#Region "CUSTOMIZE SOMETHING"

#End Region

#Region "PUBLIC GET"

#End Region

#Region "PRIVATE GET"
    Private Function getWsInfo(drData As PropsFields.dr_list_props_fields) As Integer
        Try
            Dim cc As New ColumnValuesObj
            Dim builder As New SelectBuilder

            Dim joinClause As New List(Of String)
            joinClause.Add("LEFT JOIN dbPO b on b.po_id = a.po_id")

            Dim columns As New List(Of String)
            columns.Add("b.po_id")

            Dim dSelect As PropsFields.SelectDynamic = builder.setDefaultTable("dbPO_details").
                setMyAlias("a").
                setColumns(columns).
                setMultipleTable(True).
                setJoinClause(joinClause).
                setCondition($"a.rs_id = {drData.rs_id}").Build()

            Dim _select As New ColumnValuesObj
            Dim resultData As Object = _select.selectQuery_builder_pattern(dSelect)

            If resultData IsNot Nothing Then
                Return resultData(0)("po_id").ToString
            End If

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Private Function getRrItemId(drData As PropsFields.dr_list_props_fields) As Integer
        Try
            Dim cc As New ColumnValuesObj
            Dim builder As New SelectBuilder

            Dim joinClause As New List(Of String)
            joinClause.Add("LEFT JOIN dbreceiving_items b on b.rr_item_id = a.rr_item_id")

            Dim columns As New List(Of String)
            columns.Add("b.rr_item_id")

            Dim dSelect As PropsFields.SelectDynamic = builder.setDefaultTable("dbreceiving_item_partially").
                setMyAlias("a").
                setColumns(columns).
                setMultipleTable(True).
                setJoinClause(joinClause).
                setCondition($"a.par_rr_item_id = {drData.par_rr_item_id}").Build()

            Dim _select As New ColumnValuesObj
            Dim resultData As Object = _select.selectQuery_builder_pattern(dSelect)

            If resultData.count > 0 Then
                Dim resultId As Integer = Utilities.ifBlankReplaceToZero(resultData(0)("rr_item_id")?.ToString)
                Return resultId
            End If

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Private Function getRrInfoId(rrItemId As Integer) As Integer
        Try
            Dim cc As New ColumnValuesObj
            Dim builder As New SelectBuilder

            Dim joinClause As New List(Of String)
            joinClause.Add("LEFT JOIN dbreceiving_info b on b.rr_info_id = a.rr_info_id")

            Dim columns As New List(Of String)
            columns.Add("b.rr_info_id")

            Dim dSelect As PropsFields.SelectDynamic = builder.setDefaultTable("dbreceiving_items").
                setMyAlias("a").
                setColumns(columns).
                setMultipleTable(True).
                setJoinClause(joinClause).
                setCondition($"a.rr_item_id = {rrItemId}").Build()

            Dim _select As New ColumnValuesObj
            Dim resultData As Object = _select.selectQuery_builder_pattern(dSelect)

            If resultData.count > 0 Then
                Dim resultId As Integer = Utilities.ifBlankReplaceToZero(resultData(0)("rr_info_id")?.ToString)
                Return resultId
            End If

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

#End Region

#Region "UTILITIES"

#End Region

#Region "CRUD"
    Public Function save_dr_info(drInfo As PropsFields.create_dr_info_fields,
                                Optional sqlCon As SQLcon = Nothing,
                                Optional transaction As SqlTransaction = Nothing) As Integer
        Try
            Dim drInfoValues As New ColumnValuesObj
            With drInfoValues
                .add("date", Date.Parse(drInfo.dr_date))
                .add("date_submitted", drInfo.date_submitted)
                .add("equipListID", drInfo.equipListId)
                .add("operator_id", drInfo.operator_id)
                .add("concession_ticket_no", drInfo.concession)
                .add("checkedBy", drInfo.checkedBy)
                .add("date_log", drInfo.dateLog)
                .add("options", drInfo.options)
                .add("remarks", drInfo.remarks)
                .add("supplier_id", drInfo.supplier_id)
                .add("price", drInfo.price)

                If drInfo.typeOfPurchasing = cTypeOfPurchasing.WITHDRAWAL Then
                    .add("ws_no", drInfo.wsNo)
                ElseIf drInfo.typeOfPurchasing = cTypeOfPurchasing.PURCHASE_ORDER Then
                    .add("rr_no", drInfo.rrNo)
                End If

                save_dr_info = drInfoValues.insertQueryRollBack_and_return_id("dbDeliveryReport_info", sqlCon, transaction)
                Return save_dr_info

            End With
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Public Function save_dr_details(dr_info_id As Integer,
                                    drDetails As PropsFields.create_dr_info_fields,
                                    Optional sqlCon As SQLcon = Nothing,
                                    Optional transaction As SqlTransaction = Nothing) As Integer

        Try
            Dim drDetailsValues As New ColumnValuesObj
            With drDetailsValues
                .add("dr_info_id", dr_info_id)
                .add("dr_no", drDetails.drNo)
                .add("category", drDetails.stockpile_source)
                .add("source_id", drDetails.stockpileAreaId)
                .add("wh_id", drDetails.wh_id)
                .add("qty", drDetails.drQty)

                If drDetails.typeOfPurchasing = cTypeOfPurchasing.WITHDRAWAL Then
                    .add("rs_id", drDetails.rsId)
                ElseIf drDetails.typeOfPurchasing = cTypeOfPurchasing.PURCHASE_ORDER Then
                    .add("rs_id", drDetails.rsId)
                End If

                .add("in_to_stockcard", drDetails.in_to_stockard)
                .add("user_id", drDetails.user_id)

                save_dr_details = drDetailsValues.insertQueryRollBack_and_return_id("dbDeliveryReport_items", sqlCon, transaction)

            End With
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Public Function deleteDeliveryReceipt(drData As PropsFields.dr_list_props_fields,
                                          Optional listOfDrData As List(Of PropsFields.dr_list_props_fields) = Nothing) As Boolean
        Try
            cListOfDrDataRepo = listOfDrData

            'for stockpile to stockpile
            Dim isStockpileToStockpile As Boolean = getDrDataByDrNo(drData.dr_no).Count > 1

            If isStockpileToStockpile Then
                Dim message As String = "this data is stockpile to stockpile transaction, if you remove this data, all related transaction will be also deleted! Do you want procceed?"

                If customMsg.messageYesNo(message, "SUPPLY INFO:") Then
                    deleteDeliveryReceipt = executeDeleteStockpileToStockpileDr(drData)
                End If
                Exit Function
            End If

            'withdrawal with dr and with rs
            If drData.dr_no.ToUpper() <> cNotApplicable And
                drData.rs_no.ToUpper() <> cNotApplicable And
                drData.inout = cInOut._OUT Then

                MsgBox("withdrawal with dr and with rs")
                deleteDeliveryReceipt = executeDeleteDrData(drData)

                'withdrawal without dr but with rs
            ElseIf drData.dr_no.ToUpper() = cNotApplicable And
                drData.rs_no.ToUpper <> cNotApplicable And
                drData.inout = cInOut._OUT Then

                MsgBox("withdrawal without dr but with rs")
                deleteDeliveryReceipt = executeDeleteWsWithoutDrData(drData)

                'withdrawal without rs but with dr
            ElseIf drData.dr_no.ToUpper() <> cNotApplicable And
                drData.rs_no.ToUpper() = cNotApplicable And
                drData.inout = cInOut._OUT Then

                MsgBox("withdrawal without rs but with dr")
                deleteDeliveryReceipt = executeDeleteOutWithOrWithoutDrAndRs(drData)

                'withdrawal without rs and without dr
            ElseIf drData.dr_no.ToUpper() = cNotApplicable And
                drData.rs_no.ToUpper() = cNotApplicable And
                drData.inout = cInOut._OUT Then

                deleteDeliveryReceipt = executeDeleteOutWithOrWithoutDrAndRs(drData)

                'others with dr and rs
            ElseIf drData.dr_no.ToUpper() <> cNotApplicable And
                drData.rs_no.ToUpper() <> cNotApplicable And
                drData.inout = cInOut._OTHERS Then

                MsgBox("others with dr and rs")
                deleteDeliveryReceipt = executeDeleteOthersOrInWithOrWithoutDrAndRs(drData, False)

                'others without dr and without rs
            ElseIf drData.dr_no.ToUpper() = cNotApplicable And
                drData.rs_no.ToUpper() = cNotApplicable And
                drData.inout = cInOut._OTHERS Then

                MsgBox("others without dr and without rs")
                deleteDeliveryReceipt = executeDeleteOthersOrInWithOrWithoutDrAndRs(drData, True)

                'others with dr and without rs
            ElseIf drData.dr_no.ToUpper() <> cNotApplicable And
                drData.rs_no.ToUpper() = cNotApplicable And
                drData.inout = cInOut._OTHERS Then

                MsgBox("others with dr and without rs")
                deleteDeliveryReceipt = executeDeleteOthersOrInWithOrWithoutDrAndRs(drData, True)

                'in with dr and rs
            ElseIf drData.dr_no.ToUpper() <> cNotApplicable And
                drData.rs_no.ToUpper() <> cNotApplicable And
                drData.inout = cInOut._IN Then

                MsgBox("in with dr and rs")
                deleteDeliveryReceipt = executeDeleteOthersOrInWithOrWithoutDrAndRs(drData, False)


                'in without dr and without rs
            ElseIf drData.dr_no.ToUpper() = cNotApplicable And
                drData.rs_no.ToUpper() = cNotApplicable And
                drData.inout = cInOut._IN Then

                MsgBox("in without dr and without rs")
                deleteDeliveryReceipt = executeDeleteOthersOrInWithOrWithoutDrAndRs(drData, True)

                'in with dr and without rs 
            ElseIf drData.dr_no.ToUpper() <> cNotApplicable And
                drData.rs_no.ToUpper() = cNotApplicable And
                drData.inout = cInOut._IN Then

                MsgBox("in with dr and without rs ")
                deleteDeliveryReceipt = executeDeleteOthersOrInWithOrWithoutDrAndRs(drData, True)

            End If

            Return deleteDeliveryReceipt

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Private Function executeDeleteDrData(drData As PropsFields.dr_list_props_fields) As Boolean

        Try
            Dim lot As New ListOfTables

            lot.addTable("dbDeliveryReport_items", $"dr_items_id = {drData.dr_item_id}")
            lot.addTable("dbDeliveryReport_info", $"dr_info_id = {drData.dr_info_id}")

            Dim cc As New ColumnValuesObj
            cc.deleteDataUsingRollback(lot.getListOfTables)

            Return True

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
            Return False
        End Try
    End Function

    Private Function executeDeleteOthersOrInWithOrWithoutDrAndRs(drData As PropsFields.dr_list_props_fields,
                                               isWithoutRs As Boolean) As Boolean

        Try
            Dim lot As New ListOfTables
            Dim rrItemId As Integer = getRrItemId(drData)
            Dim rrInfoId As Integer = getRrInfoId(rrItemId)

            lot.addTable("dbreceiving_item_partially", $"par_rr_item_id = {drData.par_rr_item_id}")
            lot.addTable("dbreceiving_items", $"rr_item_id = {rrItemId}")
            lot.addTable("dbreceiving_info", $"rr_info_id = {rrInfoId}")
            lot.addTable("dbDeliveryReport_items", $"dr_items_id = {drData.dr_item_id}")
            lot.addTable("dbDeliveryReport_info", $"dr_info_id = {drData.dr_info_id}")

            If isWithoutRs Then
                lot.addTable("dbrequisition_slip", $"rs_id = {drData.rs_id}")
            End If

            Dim cc As New ColumnValuesObj
            cc.deleteDataUsingRollback(lot.getListOfTables)

            Return True

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
            Return False
        End Try
    End Function
    Private Function executeDeleteStockpileToStockpileDr(drData As PropsFields.dr_list_props_fields) As Boolean
        Try
            Dim lot As New ListOfTables

            For Each row In getDrDataByDrNo(drData.dr_no)
                If row.inout = cInOut._OUT Then

                    lot.addTable("dbDeliveryReport_items", $"dr_items_id = {row.dr_item_id}")
                    lot.addTable("dbDeliveryReport_info", $"dr_info_id = {row.dr_info_id}")

                ElseIf row.inout = cInOut._IN Then
                    Dim rrItemId As Integer = getRrItemId(row)
                    Dim rrInfoId As Integer = getRrInfoId(rrItemId)

                    lot.addTable("dbreceiving_item_partially", $"par_rr_item_id = {row.par_rr_item_id}")
                    lot.addTable("dbreceiving_items", $"rr_item_id = {rrItemId}")
                    lot.addTable("dbreceiving_info", $"rr_info_id = {rrInfoId}")
                    lot.addTable("dbDeliveryReport_items", $"dr_items_id = {row.dr_item_id}")
                    lot.addTable("dbDeliveryReport_info", $"dr_info_id = {row.dr_info_id}")
                End If
            Next

            Dim cc As New ColumnValuesObj
            cc.deleteDataUsingRollback(lot.getListOfTables)

            Return True

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
            Return False
        End Try
    End Function


    Private Function executeDeleteDrDataInWithoutRs(drData As PropsFields.dr_list_props_fields,
                                               isWithoutRs As Boolean) As Boolean

        Try
            Dim lot As New ListOfTables

            lot.addTable("dbDeliveryReport_items", $"dr_items_id = {drData.dr_item_id}")
            lot.addTable("dbDeliveryReport_info", $"dr_info_id = {drData.dr_info_id}")

            Dim cc As New ColumnValuesObj
            cc.deleteDataUsingRollback(lot.getListOfTables)

            Return True

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
            Return False
        End Try
    End Function

    Private Function executeDeleteWsWithoutDrData(drData As PropsFields.dr_list_props_fields) As Boolean

        Try
            Dim lot As New ListOfTables
            Dim wsInfo As Integer = 0

            If cWsRepo IsNot Nothing Then
                wsInfo = cWsRepo.FirstOrDefault(Function(x) x.ws_id = drData.dr_item_id).ws_info_id
            End If

            lot.addTable("dbPO_details", $"po_det_id = {drData.dr_item_id}")
            lot.addTable("dbPO", $"po_id = {wsInfo}")

            Dim cc As New ColumnValuesObj
            cc.deleteDataUsingRollback(lot.getListOfTables)

            Return True

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
            Return False
        End Try
    End Function

    Private Function executeDeleteOutWithOrWithoutDrAndRs(drData As PropsFields.dr_list_props_fields) As Boolean

        Try
            Dim lot As New ListOfTables
            Dim wsInfo As Integer = getWsInfo(drData)


            If drData IsNot Nothing Then
                lot.addTable("dbDeliveryReport_items", $"dr_items_id = {drData.dr_item_id}")
                lot.addTable("dbDeliveryReport_info", $"dr_info_id = {drData.dr_info_id}")
                lot.addTable("dbPO_details", $"rs_id = {drData.rs_id}")
                lot.addTable("dbPO", $"po_id = {wsInfo}")
                lot.addTable("dbrequisition_slip", $"rs_id = {drData.rs_id}")

                Dim cc As New ColumnValuesObj
                cc.deleteDataUsingRollback(lot.getListOfTables)

            End If

            Return True

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
            Return False
        End Try
    End Function

    Public Function getDrDataByDrNo(drNo As String) As List(Of PropsFields.dr_list_props_fields)

        If cListOfDrDataRepo IsNot Nothing Then
            Return cListOfDrDataRepo.Where(Function(x)
                                               Return x.dr_no = drNo And Not x.dr_no.ToUpper().Contains("N/A")
                                           End Function).ToList()
        End If

    End Function

#End Region

End Class
