Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Windows.Interop
Imports CrystalDecisions.[Shared].Json
Imports Microsoft.Office.Interop.Excel
Imports OfficeOpenXml.ExcelErrorValue
Imports SUPPLY.Interfaces
Imports SUPPLY.KeyPerformanceIndicatorModel
Imports SUPPLY.spire

Public Class WarehouseItemModel
    Implements IWarehouseItem
    Private whItemsModel,
        WhInchargeModel,
        DisplayResultModel,
        ProperNamingModel,
        WhInchargeNewModel,
        EmployeeModel,
        AllChargesModel,
        WhAreaStockpileModel,
        TypeOfRequestModel,
        ConsolidationAccountModel,
        MultipleKPIModel As New ModelNew.Model

    Dim cBgWorkerChecker, cBgWorkerDisplayResult As Timer
    Private customMsg As New customMessageBox

    Private cListOfItems As New List(Of PropsFields.whItems_props_fields)
    Public cListOfIncharge As New List(Of PropsFields.inchargeNew_fields)
    Private cListOfEmployees As New List(Of PropsFields.employee_props_fields)
    Private cListOfProperName As New List(Of PropsFields.whItems_properName_fields)
    Private cListOfAllCharges As New List(Of PropsFields.AllCharges)
    Private finalDatas As New List(Of PropsFields.whItemsFinal)
    Private cListOfWhArea As New List(Of PropsFields.whArea_stockpile_props_fields)
    Private cListOfTypeOfRequest As New List(Of PropsFields.TypeOfRequest)
    Private cListOfConsolidationAccount As New List(Of PropsFields.Consolidated_Account)
    Private cListOfItemsFinal As New List(Of PropsFields.whItemsFinal)
    Private cListOfMultipleKPI As New List(Of PropsFields.MultipleKPIprops_fields)

    Dim cSearch As String = ""
    Private dgView As New DataGridView
    Private cLoadingPanel As New Panel
    Private rowFocus As Boolean
    Private rowId As Integer
    Public cWhPnId As Integer


    Private cn As New PropsFields.whItemsFinal
    Dim customDgv As New CustomGridview
    Private cSearchBy As New SearchByEnum
    Private cSearchByNew, cSearchNew As String
    Public isEdit, isSaved, isUpdate, isItemChecked, isRemoved As Boolean
    Public isSearchForAggregates As Boolean

    Public Property setRowId As Integer
        Get
            Return rowId
        End Get
        Set(value As Integer)
            rowId = value
        End Set
    End Property

    'get/set

    Public Class KPI_storage
        Public Property wh_id As Integer
        Public Property indicator As String
        Public Property lead_time_category As String

    End Class
#Region "GET"
    Public ReadOnly Property getTypeOfRequest() As List(Of PropsFields.TypeOfRequest)
        Get
            Return cListOfTypeOfRequest
        End Get

    End Property
    Public ReadOnly Property getEmployees() As List(Of PropsFields.employee_props_fields)
        Get
            Return cListOfEmployees
        End Get

    End Property
    Public ReadOnly Property getConsolidationAccount() As List(Of PropsFields.Consolidated_Account)
        Get
            Return cListOfConsolidationAccount
        End Get

    End Property

    Public Property getListOfItemsFinal() As List(Of PropsFields.whItemsFinal)
        Get
            Return cListOfItemsFinal
        End Get
        Set(value As List(Of PropsFields.whItemsFinal))
            cListOfItemsFinal = value
        End Set
    End Property

    Public Property getFinalDatas() As List(Of PropsFields.whItemsFinal)
        Get
            Return finalDatas
        End Get
        Set(value As List(Of PropsFields.whItemsFinal))
            finalDatas = value
        End Set
    End Property

    Public ReadOnly Property getListOfItems() As List(Of PropsFields.whItems_props_fields)
        Get
            Return cListOfItems
        End Get

    End Property

#End Region
    Public Function delete(wh_id As Integer) As Boolean Implements IWarehouseItem.delete
        Try

            Dim lot As New ListOfTables

            lot.addTable("dbwarehouse_items", $"wh_id = {wh_id}")
            lot.addTable("dbWarehouseItems_dbKPI", $"wh_id = {wh_id}")

            Dim cc As New ColumnValuesObj
            cc.deleteDataUsingRollback(lot.getListOfTables)

            Return True

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Public Sub initialize(Optional dgv As DataGridView = Nothing, Optional loadingPanel As Panel = Nothing) Implements IWarehouseItem.initialize
        dgView = dgv
        cLoadingPanel = loadingPanel
    End Sub

    Public Function saved(whitem As PropsFields.whItems_props_fields, selectedKPI As List(Of PropsFields.SELECTED_KPI)) As Integer Implements IWarehouseItem.saved
        Dim newSQLcon As New SQLcon
        Dim transaction As SqlTransaction = Nothing
        Try
            newSQLcon.connection.Open()
            transaction = newSQLcon.connection.BeginTransaction()

            With whitem

                Dim cc As New ColumnValuesObj
                cc.add("division", .division)
                cc.add("whItem", .item_name)
                cc.add("whItemDesc", .item_desc)
                cc.add("whClass", .classification)
                cc.add("whArea", .wh_area_id)
                cc.add("whReorderPoint", .reorder_point)
                cc.add("default_price", .default_price)
                cc.add("unit", .units)

                'If .consolidated_account_id = 0 Then
                '    cc.add("tsp_id", .tsp_id)
                'Else
                '    cc.add("tsp_id", .tsp_id)
                '    cc.add("consolidated_id", .consolidated_account_id)
                'End If

                cc.add("set_det_id", 0)
                cc.add("turnover", .Turnover)
                cc.add("incharge_id", 0)
                cc.add("disable_item", .disable)
                cc.add("wh_pn_id", .wh_pn_id)
                cc.add("quarry_id", .quarry_id)
                cc.add("whArea_category", .whArea_category)
                cc.add("kpi_id", .kpi_id)
                cc.add("whSpecificLoc", .specific_loc)
                cc.add("user_id", pub_user_id)
                cc.add("createdAt", Date.Parse(Now))
                cc.add("linkProperNameBy", pub_user_id)

                'saved = cc.insertQuery_and_return_id("dbwarehouse_items")
                Dim wh_id As Integer = cc.insertQueryRollBack_and_return_id("dbwarehouse_items", newSQLcon, transaction)

                'add kpi data here
                For Each kpi In selectedKPI
                    Dim saveKPI As New ColumnValuesObj
                    With saveKPI
                        .add("wh_id", wh_id)
                        .add("kpi_id", kpi.kpi_id)
                        .add("tor_id", kpi.tor_id)

                        .insertQueryRollBack_and_return_id("dbWarehouseItems_dbKPI", newSQLcon, transaction)
                    End With
                Next
                transaction.Commit()

                Return wh_id
            End With

        Catch ex As Exception
            If transaction IsNot Nothing Then
                transaction.Rollback()
            End If

            customMsg.ErrorMessage(ex)
        Finally
            newSQLcon.connection.Close()
        End Try
    End Function

    Public Function update(whitem As PropsFields.whItems_props_fields, id As Integer) As Boolean Implements IWarehouseItem.update
        With whitem

            Dim cc As New ColumnValuesObj
            cc.add("division", .division)
            cc.add("whItem", .item_name)
            cc.add("whItemDesc", .item_desc)
            cc.add("whClass", .classification)
            cc.add("whArea", .wh_area_id)
            cc.add("whReorderPoint", .reorder_point)
            cc.add("default_price", .default_price)
            cc.add("unit", .units)
            'cc.add("tsp_id", .tsp_id)
            'cc.add("consolidated_id", .consolidated_account_id)
            'cc.add("set_det_id", 0)
            cc.add("turnover", .Turnover)
            cc.add("incharge_id", 0)
            cc.add("disable_item", .disable)
            cc.add("whArea_category", .whArea_category)
            cc.add("whSpecificLoc", .specific_loc)
            cc.add("updated_by", pub_user_id)
            cc.add("updatedAt", Date.Parse(Now))

            cc.setCondition($"wh_id = {id}")

            update = cc.updateQuery_return_true("dbwarehouse_items")

        End With

        Return update
    End Function

    Public Function initialize_whItemsOnly(searchBy As String, search As String)
        Try
            cSearchByNew = searchBy
            cSearchNew = search

            Dim whItemsValues As New ColumnValues

            cLoadingPanel.Visible = True

            whItemsModel.clearParameter()

            _initializing(cCol.forWhItems,
                            whItemsValues.getValues(),
                            whItemsModel,
                            WhItemsBgWorker)

            cBgWorkerChecker = BgWorkersCheckerFn(AddressOf SuccessfullyDoneWhItemOnly, WhItemsBgWorker)
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Public Function getWarehouseItems(search As String) As List(Of PropsFields.whItems_props_fields) Implements IWarehouseItem.getWarehouseItems
        Try

            whItemsModel.clearParameter()
            WhInchargeModel.clearParameter()
            ProperNamingModel.clearParameter()
            WhInchargeNewModel.clearParameter()
            EmployeeModel.clearParameter()
            AllChargesModel.clearParameter()
            WhAreaStockpileModel.clearParameter()
            ConsolidationAccountModel.clearParameter()
            TypeOfRequestModel.clearParameter()
            MultipleKPIModel.clearParameter()

            cLoadingPanel.Visible = True

            Dim cv, cv2 As New ColumnValues
            cv.add("crud", 7)
            cv.add("search", "")

            Dim values As New Dictionary(Of String, String)
            Dim cv3 As New ColumnValues
            cv3.add("crud", "8")


            _initializing(cCol.forWhItems,
                    values,
                    whItemsModel,
                    WhItemsBgWorker)

            _initializing(cCol.forWhItem_ProperNames,
                          values,
                          ProperNamingModel,
                          WhItemsBgWorker)

            _initializing(cCol.forWhInchargeNew,
                          cv3.getValues(),
                          WhInchargeNewModel,
                          WhItemsBgWorker)

            _initializing(cCol.forEmployeeData,
                          cv3.getValues(),
                          EmployeeModel,
                          WhItemsBgWorker)

            _initializing(cCol.forAllCharges,
                            cv3.getValues(),
                            AllChargesModel,
                            WhItemsBgWorker)

            _initializing(cCol.forWareHouseStockpileArea,
                      cv.getValues(),
                      WhAreaStockpileModel,
                      WhItemsBgWorker)

            _initializing(cCol.forTypeOfRequest,
                      cv.getValues(),
                      TypeOfRequestModel,
                      WhItemsBgWorker)

            _initializing(cCol.forConsolidationAccount,
                      cv.getValues(),
                      ConsolidationAccountModel,
                      WhItemsBgWorker)

            _initializing(cCol.forMultipleKPI,
                      cv2.getValues(),
                      MultipleKPIModel,
                      WhItemsBgWorker)

            cBgWorkerChecker = BgWorkersCheckerFn(AddressOf SuccessfullyDone, WhItemsBgWorker)
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try


    End Function

    Private Sub SuccessfullyDone()
        Try
            cListOfItems = TryCast(whItemsModel.cData, List(Of PropsFields.whItems_props_fields))
            cListOfIncharge = TryCast(WhInchargeNewModel.cData, List(Of PropsFields.inchargeNew_fields))
            cListOfEmployees = TryCast(EmployeeModel.cData, List(Of PropsFields.employee_props_fields))
            cListOfProperName = TryCast(ProperNamingModel.cData, List(Of PropsFields.whItems_properName_fields))
            cListOfAllCharges = TryCast(AllChargesModel.cData, List(Of PropsFields.AllCharges))
            cListOfWhArea = TryCast(WhAreaStockpileModel.cData, List(Of PropsFields.whArea_stockpile_props_fields))
            cListOfTypeOfRequest = TryCast(TypeOfRequestModel.cData, List(Of PropsFields.TypeOfRequest))
            cListOfConsolidationAccount = TryCast(ConsolidationAccountModel.cData, List(Of PropsFields.Consolidated_Account))
            cListOfMultipleKPI = TryCast(MultipleKPIModel.cData, List(Of PropsFields.MultipleKPIprops_fields))

            If isEdit Or isSaved Or isUpdate Then
                searchWarehouseArea(setRowId, cSearchBy.SEARCH_BY_WH_ID)
            End If

            If isItemChecked Then
                searchWarehouseArea(cWhPnId, cSearchBy.SEARCH_BY_WH_PN_ID)
            End If

            cLoadingPanel.Visible = False

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
    Private Sub SuccessfullyDoneWhItemOnly()
        Try
            cListOfItems = TryCast(whItemsModel.cData, List(Of PropsFields.whItems_props_fields))

            searchWarehouseArea(cSearchNew, cSearchByNew)
            cLoadingPanel.Visible = False

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Function refactorToFinalData(row As PropsFields.whItems_props_fields) As PropsFields.whItemsFinal
        Try
            refactorToFinalData = New PropsFields.whItemsFinal
            Dim specificArea As String = getSpecificArea(row.wh_area_id,
                                                         row.whArea_category,
                                                         row.wh_area_id)

            With refactorToFinalData
                .wh_id = row.wh_id
                .item_name = $"{row.item_name}" & IIf(row.wh_pn_id = 0, "", $" → {row.proper_item_name}")
                .item_desc = $"{row.item_desc}" & IIf(row.wh_pn_id = 0, "", $" → {row.proper_item_desc}")

                .classification = row.classification
                .type_of_item = row.type_of_item

                'warehouse area
                .warehouse_area = IIf(specificArea IsNot Nothing,
                                              specificArea, row.warehouse_area)

                .specific_loc = row.specific_loc
                'incharge
                .incharge = getWarehouseIncharge(row.wh_area_id)

                .reorder_point = row.reorder_point
                .default_price = row.default_price
                .units = row.units
                .inout = row.inout
                .set_det_id = row.set_det_id
                .division = row.division
                .Turnover = row.Turnover
                .disable = row.disable
                .proper_item_name = row.proper_item_name
                .proper_item_desc = row.proper_item_desc
                .wh_pn_id = row.wh_pn_id
                .quarry = row.quarry
                .wh_area_id = row.wh_area_id
                .whArea_category = convertWarehouseToWarehouseStockpile(row.whArea_category)
                '.kpi = row.kpi

#Region "CONSOLIDATED ACCOUNT TITLE"
                'consolidation
                Dim consolidaton = getConsolidatedData(row.consolidated_account_id)

                If consolidaton IsNot Nothing Then
                    .type_of_item = $"{consolidaton.tor_desc} - {consolidaton.tor_sub_desc}"
                    .consolidation_account = $"{consolidaton.category} ({consolidaton.codes})"
                Else
                    .type_of_item = $"{row.type_of_item}"
                End If

#End Region

#Region "MULTIPLE KPI"
                .kpi = getMultipleKPIByWhId(row.wh_id)
#End Region


            End With

            Return refactorToFinalData
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Private Function refactorEditFinalData(row As PropsFields.whItems_props_fields) As PropsFields.editWhItems_props_fields
        refactorEditFinalData = New PropsFields.editWhItems_props_fields
        Try

            With refactorEditFinalData
                .division = row.division
                .Turnover = row.Turnover
                .item_name = row.item_name
                .item_desc = row.item_desc

                'type of request
                Dim consolidaton = getConsolidatedData(row.consolidated_account_id)
                If consolidaton IsNot Nothing Then
                    .consolidation_account = $"{consolidaton.category} ({consolidaton.codes})"
                    .consolidated_account_id = consolidaton.consolidated_account_id
                End If

                'warehouse item proper name
                Dim propernaming = cListOfProperName.FirstOrDefault(Function(x) x.wh_pn_id = row.wh_pn_id)
                If propernaming IsNot Nothing Then
                    .wh_pn_id = propernaming.wh_pn_id
                    .proper_item_desc = propernaming.item_desc
                    .proper_item_name = propernaming.item_name
                End If

                .classification = row.classification

                'warehouse area / project site / stockpile / quarry
                Select Case row.whArea_category

                    Case cWarehouseOption.WAREHOUSE
                        Dim whArea = cListOfWhArea.FirstOrDefault(Function(x) x.wh_area_id = row.wh_area_id)
                        If whArea IsNot Nothing Then
                            .wh_area_id = whArea.wh_area_id

                            If whArea.wh_options = cWarehouseOption.WAREHOUSE Then 'if warehouse area, use wh_area_proper_name as warehouse area
                                .warehouse_area = whArea.wh_area_proper_name
                            ElseIf whArea.wh_options = cWarehouseOption.STOCKPILE Then 'if stockpile, use wh_area as stockpile area
                                .warehouse_area = whArea.wh_area
                            End If
                            .whArea_category = cWarehouseOption.WAREHOUSE
                        End If

                        'quarry
                        Dim quarryArea = cListOfWhArea.FirstOrDefault(Function(x) x.wh_area_id = row.quarry_id)
                        If quarryArea IsNot Nothing Then
                            .quarry_id = quarryArea.wh_area_id
                            .quarry = quarryArea.wh_area
                        End If

                    Case cWarehouseOption.PROJECT
                        Dim project = cListOfAllCharges.FirstOrDefault(Function(x)
                                                                           Return x.charges_category = cWarehouseOption.PROJECT And
                                                                           x.charges_id = row.wh_area_id
                                                                       End Function)
                        If project IsNot Nothing Then
                            .wh_area_id = project.charges_id
                            .warehouse_area = project.charges
                            .whArea_category = cWarehouseOption.PROJECT
                        End If
                End Select



                'kpi
                .kpi_id = row.kpi_id
                .kpi = row.kpi

                'consolidation
                .consolidated_account_id = row.consolidated_account_id

                .specific_loc = row.specific_loc
                .reorder_point = row.reorder_point
                .default_price = row.default_price
                .units = row.units

            End With

            Return refactorEditFinalData
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Private Function getConsolidatedData(consolidated_id As Integer) As PropsFields.Consolidated_Account
        'consolidation
        Dim dataResult = cListOfConsolidationAccount.FirstOrDefault(Function(x) x.consolidated_account_id = consolidated_id)
        If dataResult IsNot Nothing Then
            Return dataResult
        Else
            Return Nothing
        End If
    End Function

    Public Sub preview(datas As List(Of PropsFields.whItemsFinal))
        If datas.Count > 0 Then
            cListOfItemsFinal = datas

            dgView.DataSource = Nothing
            dgView.DataSource = cListOfItemsFinal
            dgView.Refresh()

            customizeDagrid()

            If rowFocus Then
                customDgv.rowFocus(dgView, NameOf(cn.wh_id), rowId)
            End If

            cLoadingPanel.Visible = False
        Else
            dgView.DataSource = Nothing
            customMsg.message("error", "no data has been found!", "SMS INFO:")
        End If
    End Sub

    Public Sub preview_by_hauling_and_aggregates(datas As List(Of PropsFields.whItemsFinal))
        If datas.Count > 0 Then
            cListOfItemsFinal = datas.Where(Function(x) x.division.ToUpper() = cDivision.CRUSHING_AND_HAULING).ToList()

            dgView.DataSource = Nothing
            dgView.DataSource = cListOfItemsFinal
            dgView.Refresh()

            customizeDagrid()

            If rowFocus Then
                customDgv.rowFocus(dgView, NameOf(cn.wh_id), rowId)
            End If

            cLoadingPanel.Visible = False
        Else
            dgView.DataSource = Nothing
        End If
    End Sub

    Private Function getWarehouseIncharge(whAreaId As Integer) As String
        Try
            Dim listOfincharge = cListOfIncharge.Where(Function(x) x.wh_area_id = whAreaId).ToList()

            If listOfincharge.Count > 0 Then
                getWarehouseIncharge = String.Join(",", listOfincharge.Select(Function(x) x.whIncharge).ToArray())
            End If

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Private Function getQuarry() As String
        ' Dim quarry = cListOfAllCharges.Where(Function(x) )
    End Function

    Private Function searchDatas(searchBy As String, search As String) As List(Of PropsFields.whItems_props_fields)
        Try
            searchDatas = New List(Of PropsFields.whItems_props_fields)
            Dim wh_areas As New List(Of PropsFields.whArea_stockpile_props_fields)
            Dim wh_incharges As New List(Of PropsFields.inchargeNew_fields)

            'exclusive for warehouse area
            If searchBy = cSearchBy.SEARCH_BY_WAREHOUSE_AREA Then
                wh_areas = cListOfWhArea.Where(Function(x) $"{x.wh_area} {x.wh_area_proper_name}".ToUpper().Contains(search.ToUpper())).ToList()

                'exclusive for incharge
            ElseIf searchBy = cSearchBy.SEARCH_BY_WAREHOUSE_INCHARGE Then
                wh_incharges = cListOfIncharge.Where(Function(x) $"{x.whIncharge}".ToUpper().Contains(search.ToUpper())).ToList()

                'exclusive for wh_pn_id
            ElseIf searchBy = cSearchBy.SEARCH_BY_WH_PN_ID Then
                Dim isExist = cListOfItems.FirstOrDefault(Function(x) x.wh_pn_id = CInt(search))

                If isExist Is Nothing Then
                    Return searchDatas
                End If
            End If

            searchDatas = cListOfItems.Where(Function(x)
                                                 Dim concatSearch As String = ""
                                                 Select Case searchBy
                                                     Case cSearchBy.SEARCH_BY_ITEM_NAME
                                                         concatSearch = $"{x.item_name}".ToUpper()
                                                         Return concatSearch.Contains(search.ToUpper())

                                                     Case cSearchBy.SEARCH_BY_ITEM_DESC
                                                         concatSearch = $"{x.item_desc}".ToUpper()
                                                         Return concatSearch.Contains(search.ToUpper())

                                                     Case cSearchBy.SEARCH_BY_PROPER_NAMING
                                                         concatSearch = $"{x.proper_item_name} {x.proper_item_desc}".ToUpper()
                                                         Return concatSearch.Contains(search.ToUpper())

                                                     Case cSearchBy.SEARCH_BY_WAREHOUSE_AREA
                                                         If wh_areas.Count > 0 Then
                                                             Return x.wh_area_id = wh_areas(0).wh_area_id
                                                         End If

                                                     Case cSearchBy.SEARCH_BY_WAREHOUSE_INCHARGE
                                                         If wh_incharges.Count > 0 Then
                                                             Return x.wh_area_id = wh_incharges(0).wh_area_id
                                                         End If

                                                     Case cSearchBy.SEARCH_BY_KPI
                                                         concatSearch = $"{x.kpi}".ToUpper()
                                                         Return concatSearch.Contains(search.ToUpper())

                                                     Case cSearchBy.SEARCH_BY_WH_ID
                                                         Return x.wh_id = CInt(search)

                                                     Case cSearchBy.SEARCH_BY_WH_PN_ID
                                                         Return x.wh_pn_id = CInt(search)

                                                     Case cSearchBy.CLASSIFICATION
                                                         concatSearch = $"{x.classification}".ToUpper()
                                                         Return concatSearch.Contains(search.ToUpper())

                                                 End Select

                                             End Function).ToList()

            Return searchDatas
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Public Sub searchWarehouseArea(search As String, Optional searchBy As String = "") Implements IWarehouseItem.searchWarehouseItems
        Try
            cLoadingPanel.Visible = True
            If Not search = Nothing Or Not search = "" Then
                finalDatas = Nothing
                finalDatas = New List(Of PropsFields.whItemsFinal)

                'refactor
                Dim _searchDatas = searchDatas(searchBy, search)

                If _searchDatas.Count > 0 Then
                    For Each row In _searchDatas
                        finalDatas.Add(refactorToFinalData(row))
                    Next

                    'for searching data | crushing and hauling only
                    If isSearchForAggregates Then
                        preview_by_hauling_and_aggregates(finalDatas)
                        Exit Sub
                    End If

                    preview(finalDatas)
                Else
                    customMsg.message("error", "No item has been found!", "SMS INFO:")
                End If

                cLoadingPanel.Visible = False

                If isEdit Then
                    isEdit = False
                End If

                If isRemoved Then
                    isRemoved = False
                End If

                If isEdit Then
                    isEdit = False
                End If

                If isSaved Then
                    isSaved = False
                End If

                If isUpdate Then
                    isUpdate = False
                End If
            Else
                dgView.DataSource = Nothing
            End If

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    'function get
#Region "FUNCTION"
    Private Function getSpecificArea(id As Integer,
                                     category As String,
                                     Optional whAreaId As Integer = 0) As String

        Dim data = cListOfAllCharges.Where(Function(x) x.charges_id = id And x.charges_category.ToUpper() = category.ToUpper()).DefaultIfEmpty().FirstOrDefault()

        If data IsNot Nothing Then

            If data.charges_category.ToUpper() = cWarehouseOption.WAREHOUSE Then
                Dim data2 = cListOfWhArea.Where(Function(x) x.wh_area_id = whAreaId).DefaultIfEmpty().FirstOrDefault()

                If data2 IsNot Nothing Then
                    If data2.wh_options = cWarehouseOption.WAREHOUSE Then
                        getSpecificArea = $"{data2.wh_area} ({data2.wh_area_proper_name})"
                    Else
                        getSpecificArea = $"{data2.wh_area}"
                    End If
                Else
                    getSpecificArea = data2.wh_area
                End If
            Else
                getSpecificArea = data.charges
            End If

        End If
    End Function

    Public Function getSpecificItemForEdit(id As Integer) As PropsFields.editWhItems_props_fields
        Try
            Dim rawData = cListOfItems.FirstOrDefault(Function(x) x.wh_id = id)

            If rawData IsNot Nothing Then
                getSpecificItemForEdit = refactorEditFinalData(rawData)
            End If

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

#End Region

#Region "CRUD"
    Public Function updateProperNameFromWarehouseItem(wh_pn_id As Integer, wh_id As Integer) As Boolean
        Try
            Dim cc As New ColumnValuesObj
            cc.add("wh_pn_id", wh_pn_id)
            cc.add("linkProperNameBy", pub_user_id)

            cc.setCondition($"wh_id = {wh_id}")

            updateProperNameFromWarehouseItem = cc.updateQuery_return_true("dbwarehouse_items")

            Return updateProperNameFromWarehouseItem
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function
    Public Function updateKPIFromWareItem(kpi_id As Integer, wh_id As Integer) As Boolean
        Try
            Dim cc As New ColumnValuesObj
            cc.add("kpi_id", kpi_id)
            cc.setCondition($"wh_id = {wh_id}")

            updateKPIFromWareItem = cc.updateQuery_return_true("dbwarehouse_items")

            Return updateKPIFromWareItem
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function
    Public Function removeWarehouseArea(wh_id As Integer) As Boolean
        Try
            Dim cc As New ColumnValuesObj
            cc.add("whArea", 0)
            cc.add($"{NameOf(cn.whArea_category)}", "")
            cc.setCondition($"wh_id = {wh_id}")

            removeWarehouseArea = cc.updateQuery_return_true("dbwarehouse_items")

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Public Function removeQuarry(wh_id As Integer) As Boolean
        Try
            Dim cc As New ColumnValuesObj
            cc.add("quarry_id", 0)
            cc.setCondition($"wh_id = {wh_id}")

            removeQuarry = cc.updateQuery_return_true("dbwarehouse_items")

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Public Function removeProperNaming(wh_id As Integer) As Boolean
        Try
            Dim cc As New ColumnValuesObj
            cc.add("wh_pn_id", 0)
            cc.setCondition($"wh_id = {wh_id}")

            removeProperNaming = cc.updateQuery_return_true("dbwarehouse_items")

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function
    'item check function
    Public Sub setItemChecked(rs_id As Integer, wh_id As Integer)
        Try
            Dim cc As New ColumnValuesObj
            cc.add("wh_id", wh_id)

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Public Sub addMultipleKPI(KPI As PropsFields.MultipleKPIprops_fields)
        Try
            cListOfMultipleKPI.Add(KPI)
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
#End Region
    'customize
#Region "CUSTOMISE"
    Public Sub customizeDagrid()
        Try

            'hide columns
            For Each col As DataGridViewColumn In dgView.Columns
                If col.Name = NameOf(cn.wh_area_id) Or
                    col.Name = NameOf(cn.proper_item_name) Or
                    col.Name = NameOf(cn.proper_item_desc) Or
                    col.Name = NameOf(cn.disable) Or
                    col.Name = NameOf(cn.incharge_id) Or
                    col.Name = NameOf(cn.lastname) Or
                    col.Name = NameOf(cn.firstname) Or
                    col.Name = NameOf(cn.set_det_id) Or
                    col.Name = NameOf(cn.inout) Or
                    col.Name = NameOf(cn.consolidation_account) Or
                    col.Name = NameOf(cn.type_of_item) Then

                    col.Visible = False
                Else
                    col.Visible = True
                End If
            Next

            'customize column width 
            For Each col As DataGridViewColumn In dgView.Columns
                If col.Name = NameOf(cn.item_name) Or
                    col.Name = NameOf(cn.item_desc) Then
                    col.Width = 200
                End If
            Next

            For Each row As DataGridViewRow In dgView.Rows
                If Not row.Cells(NameOf(cn.wh_pn_id)).Value = 0 Then
                    row.DefaultCellStyle.ForeColor = Color.Black
                Else
                    row.DefaultCellStyle.ForeColor = Color.Gray
                End If
            Next

            customDgv.readonlyAllCells(dgView)
            customDgv.autoSizeColumn(dgView, False)
            customDgv.isDisableResizeRowHeight(dgView)

            customDgv.subcustomDatagridviewSettings("alternateRowStyle", dgView,,,,,,, "#DFEDD1", "#5E7075")

            'rename column header
            If dgView.Rows.Count > 0 Then
                dgView.Columns(NameOf(cn.wh_id)).HeaderText = "WH ID"
                dgView.Columns(NameOf(cn.item_name)).HeaderText = "ITEM NAME"
                dgView.Columns(NameOf(cn.item_desc)).HeaderText = "ITEM DESCRIPTION"
                dgView.Columns(NameOf(cn.proper_item_name)).HeaderText = "PROPER ITEM NAME"
                dgView.Columns(NameOf(cn.proper_item_desc)).HeaderText = "PROPER ITEM DESCRIPTION"
                dgView.Columns(NameOf(cn.kpi)).HeaderText = "KEY PERFORMANCE INDICATOR (KPI)"
                dgView.Columns(NameOf(cn.classification)).HeaderText = "CLASSIFICATION"
                dgView.Columns(NameOf(cn.warehouse_area)).HeaderText = "WAREHOUSE/STOCKPILE AREA/PROJECT SITE"
                dgView.Columns(NameOf(cn.quarry)).HeaderText = "QUARRY AREA"
                dgView.Columns(NameOf(cn.specific_loc)).HeaderText = "SPECIFIC LOCATION"
                dgView.Columns(NameOf(cn.incharge)).HeaderText = "INCHARGE"
                dgView.Columns(NameOf(cn.reorder_point)).HeaderText = "REORDER POINT"
                dgView.Columns(NameOf(cn.default_price)).HeaderText = "DEFAULT PRICE"
                dgView.Columns(NameOf(cn.units)).HeaderText = "UNITS"
                dgView.Columns(NameOf(cn.division)).HeaderText = "DIVISION"
                dgView.Columns(NameOf(cn.Turnover)).HeaderText = "TURNOVER"
                dgView.Columns(NameOf(cn.whArea_category)).HeaderText = "CATEGORY"
            End If


            'dgView.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#1A1A1A")
            'dgView.ColumnHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#FEF9EC")

            customDgv.customHeader(dgView)

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
#End Region

#Region "UTILITIES"
    Public Sub reloadItemsWithoutRefresh(wh_id As Integer,
                                          whatToUpdate As String,
                                          value As String,
                                          Optional id As Integer = 0)

        Dim data = FWarehouseItemsNew.getWhItemsModel().getListOfItemsFinal()

        Dim index As Integer = data.FindIndex(Function(x) x.wh_id = wh_id)

        With data(index)
            Select Case whatToUpdate
                Case NameOf(cn.kpi)

                    .kpi = value

                Case NameOf(cn.quarry)
                    .quarry = value

                Case NameOf(cn.warehouse_area)
                    .warehouse_area = value

            End Select

        End With

        FWarehouseItemsNew.DataGridView1.DataSource = Nothing
        FWarehouseItemsNew.DataGridView1.DataSource = data
        customizeDagrid()

        Utilities.datagridviewSpecificRowFocus(dgView, wh_id, "wh_id")
        'data(index)
    End Sub

    Public Sub reloadItemsWithoutRefreshNew(wh_id As Integer,
                                          whatToUpdate As String,
                                          value As PropsFields.whItemsFinal,
                                          Optional id As Integer = 0)

        Dim data = FWarehouseItemsNew.getWhItemsModel().getListOfItemsFinal()
        Dim data2 = FWarehouseItemsNew.getWhItemsModel().getListOfItems()

        Dim index As Integer = data.FindIndex(Function(x) x.wh_id = wh_id)
        Dim index2 As Integer = data2.FindIndex(Function(x) x.wh_id = wh_id)

        With data(index)

            Select Case whatToUpdate
                Case NameOf(cn.kpi)
                    .kpi = value.kpi

                    data2(index2).kpi = value.kpi

                Case NameOf(cn.quarry)
                    .quarry = value.quarry

                    data2(index2).quarry_id = value.quarry_id
                    data2(index2).quarry = value.quarry

                Case NameOf(cn.warehouse_area)
                    .warehouse_area = value.warehouse_area
                    .whArea_category = value.whArea_category

                    data2(index2).wh_area_id = value.wh_area_id
                    data2(index2).warehouse_area = value.warehouse_area
                    data2(index2).whArea_category = value.whArea_category

                Case NameOf(cn.wh_area_id)
                    .wh_area_id = value.wh_area_id
                    .incharge = value.incharge
                    .warehouse_area = value.warehouse_area
                    .whArea_category = value.whArea_category

                    data2(index2).wh_area_id = value.wh_area_id
                    data2(index2).incharge = value.incharge
                    data2(index2).warehouse_area = value.warehouse_area
                    data2(index2).whArea_category = value.whArea_category

                Case NameOf(cn.proper_item_desc)
                    .wh_pn_id = value.wh_pn_id
                    .item_name = $"{value.item_name}"
                    .item_desc = value.item_desc

                    'data2(index2).wh_pn_id = value.wh_pn_id
                    'data2(index2).item_name = value.item_name
                    'data2(index2).item_desc = value.item_desc

                Case "remove_proper_name"
                    Dim whItem = cListOfItems.FirstOrDefault(Function(x) x.wh_id = wh_id)

                    data2(index2).wh_pn_id = 0

                    .wh_pn_id = value.wh_pn_id
                    .item_name = $"{whItem.item_name}"
                    .item_desc = $"{whItem.item_desc}"

            End Select

        End With

        dgView.DataSource = Nothing
        dgView.DataSource = data
        cListOfItems = data2
        finalDatas = data

        customizeDagrid()

        Utilities.datagridviewSpecificRowFocus(dgView, wh_id, "wh_id")
        'data(index)
    End Sub

    Public Function getMultipleKPIByWhId(wh_id As Integer) As String
        Try

            Dim data = cListOfMultipleKPI?.Where(Function(x) x.wh_id = wh_id).ToList()
            getMultipleKPIByWhId = ""

            Dim _mk As New KPI_storage
            For Each row In data
                getMultipleKPIByWhId &= row.indicator & "/"
            Next

            If getMultipleKPIByWhId.Length > 0 Then
                getMultipleKPIByWhId = getMultipleKPIByWhId.Substring(0, getMultipleKPIByWhId.Length - 1)
            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

    End Function

    Public Function getMultipleKPIFromMkStorage(wh_id As Integer) As String
        Try
            getMultipleKPIFromMkStorage = ""
            getMultipleKPIFromMkStorage = removeLastCharacter(getMultipleKPIFromMkStorage)
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

    End Function

    Public Function getMultipleKPIFromMkStorageAndUpdate(new_mkpi As KPI_storage) As String
        Try
            getMultipleKPIFromMkStorageAndUpdate = ""
            'remove that existing mkpi
            Dim remove_mk = cListOfMultipleKPI.FirstOrDefault(Function(x) x.wh_id = new_mkpi.wh_id And
                                                                  x.lead_time_category = new_mkpi.lead_time_category)
            cListOfMultipleKPI.Remove(remove_mk)

            'add the new kpi
            Dim _mkpi As New PropsFields.MultipleKPIprops_fields
            With _mkpi
                .wh_id = new_mkpi.wh_id
                .indicator = new_mkpi.indicator
                .lead_time_category = new_mkpi.lead_time_category
            End With

            cListOfMultipleKPI.Add(_mkpi)

            'retreive again
            getMultipleKPIFromMkStorageAndUpdate = getMultipleKPIByWhId(new_mkpi.wh_id)

            'reload
            reloadItemsWithoutRefresh(new_mkpi.wh_id, NameOf(cn.kpi), getMultipleKPIFromMkStorageAndUpdate)

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function


#End Region

End Class
