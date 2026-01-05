Imports System.ComponentModel

Module _init_

    Public Sub _initializing(Optional n As Integer = 0,
                             Optional paramValues As Dictionary(Of String, String) = Nothing,
                             Optional paramModel As ModelNew.Model = Nothing,
                             Optional paramBgWorker As List(Of BackgroundWorker) = Nothing,
                             Optional paramLabel As Label = Nothing)

        Select Case n
#Region "PROJECTS"
            Case cCol.forActive_Projects
                With paramModel
                    .cStoredProcedure = storeProc.PROC_ACTIVE_PROJECTS
                    .cWhatColumn = cCol.forActive_Projects

                    .parameter("@n", 3)
                    .parameter($"@{paramName.SEARCH}", paramValues("project"))

                    Dim bgw As New BackgroundWorker
                    bgw = .onProcessing()

                    paramBgWorker.Add(bgw)
                End With
#End Region

#Region "FOR WAREHOUSE"
            Case cCol.forWhItem_ProperNames
                With paramModel
                    .cStoredProcedure = storeProc.PROC_WHITEM_PROPERNAMING
                    .cWhatColumn = cCol.forWhItem_ProperNames

                    .parameter("@n", 1)

                    Dim bgw As New BackgroundWorker
                    bgw = .onProcessing()

                    paramBgWorker.Add(bgw)
                End With

            Case cCol.forWhItems
                With paramModel
                    .cStoredProcedure = storeProc.PROC_WAREHOUSE_ITEMS
                    .cWhatColumn = cCol.forWhItems

                    .parameter("@n", 4)

                    Dim bgw As New BackgroundWorker
                    bgw = .onProcessing()

                    paramBgWorker.Add(bgw)
                End With

            Case cCol.forAggPrices
                With paramModel
                    .cStoredProcedure = storeProc.PROC_WAREHOUSE_ITEMS
                    .cWhatColumn = cCol.forAggPrices

                    .parameter("@n", 6)

                    Dim bgw As New BackgroundWorker
                    bgw = .onProcessing()

                    paramBgWorker.Add(bgw)
                End With

            Case cCol.forWhIncharge
                With paramModel
                    .cStoredProcedure = storeProc.PROC_WAREHOUSE_ITEMS
                    .cWhatColumn = cCol.forWhIncharge

                    .parameter("@n", 5)

                    Dim bgw As New BackgroundWorker
                    bgw = .onProcessing()

                    paramBgWorker.Add(bgw)
                End With
#End Region

#Region "DR"
            Case cCol.forDisplayResult
                With paramModel

                    .cWhatColumn = cCol.forDisplayResult

                    Dim bgw As New BackgroundWorker
                    bgw = .onProcessing()

                    paramBgWorker.Add(bgw)
                End With

            Case cCol.forDrSearch
                With paramModel
                    .cStoredProcedure = storeProc.PROC_DRLIST2
                    .cWhatColumn = cCol.forDrSearch

                    Select Case paramValues("date_enable")
                        Case cDrSearchBy.DISABLE_DATE_RANGE
                            If paramValues.ContainsKey("=") Then
                                .parameter("@n", 5556)
                            Else
                                .parameter("@n", 5555)
                            End If


                        Case cDrSearchBy.ENABLE_DATE_RANGE
                            .parameter("@n", 51)
                        Case cDrSearchBy.DATE_RANGE
                            .parameter("@n", 3)
                    End Select

                    .parameter("@searchby", paramValues("searchby"))
                    .parameter("@search", paramValues("search"))
                    .parameter("@date_from", paramValues("date_from"))
                    .parameter("@date_to", paramValues("date_to"))

                    Dim bgw As New BackgroundWorker
                    bgw = .onProcessing(cCol.forDrSearch, paramLabel)

                    paramBgWorker.Add(bgw)
                End With

            Case cCol.forDrWithoutRsSearch
                With paramModel
                    .cStoredProcedure = storeProc.PROC_DRLIST2
                    .cWhatColumn = cCol.forDrWithoutRsSearch

                    .parameter("@n", 33)

                    .parameter("@date_from", paramValues("date_from"))
                    .parameter("@date_to", paramValues("date_to"))

                    Dim bgw As New BackgroundWorker
                    bgw = .onProcessing()

                    paramBgWorker.Add(bgw)
                End With
            Case cCol.forDrWsSearch
                With paramModel
                    .cStoredProcedure = storeProc.PROC_DRLIST2
                    .cWhatColumn = cCol.forDrWsSearch

                    Select Case paramValues("date_enable")
                        Case cDrSearchBy.DISABLE_DATE_RANGE
                            .parameter("@n", 6)
                        Case cDrSearchBy.ENABLE_DATE_RANGE
                            .parameter("@n", 61)
                        Case cDrSearchBy.DATE_RANGE
                            .parameter("@n", 4)
                    End Select

                    .parameter("@searchby", paramValues("searchby"))
                    .parameter("@search", paramValues("search"))
                    .parameter("@date_from", paramValues("date_from"))
                    .parameter("@date_to", paramValues("date_to"))

                    Dim bgw As New BackgroundWorker
                    bgw = .onProcessing()

                    paramBgWorker.Add(bgw)
                End With

            Case cCol.forDrPoSearch
                With paramModel
                    .cStoredProcedure = storeProc.PROC_DRLIST2
                    .cWhatColumn = cCol.forDrPoSearch

                    .parameter("@n", 7)
                    .parameter("@searchby", paramValues("searchby"))
                    .parameter("@search", paramValues("search"))
                    .parameter("@date_from", paramValues("date_from"))
                    .parameter("@date_to", paramValues("date_to"))

                    Dim bgw As New BackgroundWorker
                    bgw = .onProcessing()

                    paramBgWorker.Add(bgw)
                End With

            Case cCol.forDrDr
                With paramModel
                    .cStoredProcedure = storeProc.PROC_DR_LIST5
                    .cWhatColumn = cCol.forDrDr

                    .parameter("@n", paramValues("n"))
                    .parameter("@search", paramValues("search"))
                    .parameter("@searchBy", paramValues("searchBy"))

                    Dim bgw As New BackgroundWorker
                    bgw = .onProcessing()

                    paramBgWorker.Add(bgw)
                End With
#End Region

#Region "FOR OPERATOR/DRIVER"
            Case cCol.forOperatorDriver
                With paramModel
                    .cStoredProcedure = storeProc.PROC_DRLIST2
                    .cWhatColumn = cCol.forOperatorDriver

                    .parameter("@n", 64)

                    Dim bgw As New BackgroundWorker
                    bgw = .onProcessing()

                    paramBgWorker.Add(bgw)
                End With

#End Region

#Region "FOR SUPPLIER"
            Case cCol.forSupplier
                With paramModel
                    .cStoredProcedure = storeProc.PROC_DRLIST2
                    .cWhatColumn = cCol.forSupplier

                    .parameter("@n", 65)

                    Dim bgw As New BackgroundWorker
                    bgw = .onProcessing()

                    paramBgWorker.Add(bgw)
                End With
#End Region

#Region "FOR EMPLOYEES"
            Case cCol.forEmployees

                With paramModel
                    .cStoredProcedure = storeProc.PROC_DRLIST4
                    .cWhatColumn = cCol.forEmployees

                    .parameter("@n", 1)

                    Dim bgw As New BackgroundWorker
                    bgw = .onProcessing()

                    paramBgWorker.Add(bgw)
                End With
#End Region

#Region "FOR CHARGES"
            Case cCol.forChargesInfo

                With paramModel
                    .cStoredProcedure = storeProc.PROC_DELIVERY_RECEIPT4
                    .cWhatColumn = cCol.forChargesInfo

                    .parameter("@n", 3)

                    Dim bgw As New BackgroundWorker
                    bgw = .onProcessing()

                    paramBgWorker.Add(bgw)
                End With
#End Region

#Region "PURCHASE ORDER"
            Case cCol.forPurchaseOrder
                With paramModel
                    .cStoredProcedure = storeProc.PROC_PO_QUERY_NEW2
                    .cWhatColumn = cCol.forPurchaseOrder

                    If paramValues.ContainsKey("po-for-dr") Then
                        .parameter("@n", 57)
                    Else
                        .parameter("@n", 5)
                    End If

                    .parameter("@searchby", paramValues("searchby"))
                    .parameter("@search", paramValues("search"))
                    .parameter("@typeofpurchasing", "PURCHASE ORDER")

                    Dim bgw As New BackgroundWorker
                    bgw = .onProcessing(cCol.forPurchaseOrder, paramLabel)

                    paramBgWorker.Add(bgw)
                End With

            Case cCol.forPoDr
                With paramModel
                    .cStoredProcedure = storeProc.PROC_DR_LIST5
                    .cWhatColumn = cCol.forPoDr
                    .parameter("@n", paramValues("n")) '4
                    .parameter("@search", paramValues("search"))
                    .parameter("@searchBy", paramValues("searchBy"))

                    Dim bgw As New BackgroundWorker
                    bgw = .onProcessing()

                    paramBgWorker.Add(bgw)
                End With
#End Region

#Region "WITHDRAWAL"
            Case cCol.forWithdrawal
                With paramModel
                    .cStoredProcedure = storeProc.PROC_PO_QUERY_NEW2
                    .cWhatColumn = cCol.forWithdrawal

                    If paramValues.ContainsKey("nn") Then ' this line is for searching except with ids
                        If paramValues.ContainsKey("date_range") Then 'this line is for searching date range

                            .parameter("@datefrom", Date.Parse(paramValues("datefrom")))
                            .parameter("@dateto", Date.Parse(paramValues("dateto")))
                            .parameter("@n", 661)

                        Else 'without date range

                            .parameter("@n", 6)

                        End If

                    Else 'this line is for searching with ids
                        .parameter("@n", 66)
                    End If

                    .parameter("@searchby", paramValues("searchby"))
                    .parameter("@search", paramValues("search"))

                    Dim bgw As New BackgroundWorker
                    bgw = .onProcessing(cCol.forWithdrawal, paramLabel)

                    paramBgWorker.Add(bgw)
                End With

            Case cCol.forWithdrawn
                With paramModel
                    .cStoredProcedure = storeProc.PROC_PO_QUERY_NEW2
                    .cWhatColumn = cCol.forWithdrawn

                    .parameter("@n", 67)

                    Dim bgw As New BackgroundWorker
                    bgw = .onProcessing()

                    paramBgWorker.Add(bgw)
                End With

            Case cCol.forPartiallyWithdrawn
                With paramModel
                    .cStoredProcedure = storeProc.PROC_PO_QUERY_NEW2
                    .cWhatColumn = cCol.forPartiallyWithdrawn

                    .parameter("@n", 68)

                    Dim bgw As New BackgroundWorker
                    bgw = .onProcessing()

                    paramBgWorker.Add(bgw)
                End With

            Case cCol.forPartiallyReleasedWithdrawal
                With paramModel
                    .cStoredProcedure = storeProc.PROC_DR_LIST5
                    .cWhatColumn = cCol.forPartiallyReleasedWithdrawal

                    .parameter("@n", 8)
                    .parameter("@search", paramValues("search"))
                    .parameter("@searchBy", paramValues("searchBy"))


                    Dim bgw As New BackgroundWorker
                    bgw = .onProcessing()

                    paramBgWorker.Add(bgw)
                End With

            Case cCol.forWithdrawalPrice
                With paramModel
                    .cStoredProcedure = storeProc.PROC_PO_QUERY_NEW2
                    .cWhatColumn = cCol.forWithdrawalPrice

                    .parameter("@n", 69)
                    .parameter("@wh_id", paramValues("wh_id"))

                    Dim bgw As New BackgroundWorker
                    bgw = .onProcessing()

                    paramBgWorker.Add(bgw)
                End With

            Case cCol.forWsDr
                With paramModel
                    .cStoredProcedure = storeProc.PROC_DR_LIST5
                    .cWhatColumn = cCol.forWsDr

                    .parameter("@n", paramValues("n"))
                    .parameter("@search", paramValues("search"))
                    .parameter("@searchBy", paramValues("searchBy"))

                    Dim bgw As New BackgroundWorker
                    bgw = .onProcessing()

                    paramBgWorker.Add(bgw)
                End With
#End Region

#Region "RECEIVING"
            Case cCol.forReceiving
                With paramModel
                    .cStoredProcedure = storeProc.PROC_RECEIVING_CRUD_NEW6
                    .cWhatColumn = cCol.forReceiving

                    .parameter("@n", 66)
                    .parameter("@searchby", paramValues("searchby"))
                    .parameter("@search", paramValues("search"))

                    Dim bgw As New BackgroundWorker
                    bgw = .onProcessing()

                    paramBgWorker.Add(bgw)
                End With

            Case cCol.forRrDr
                With paramModel
                    .cStoredProcedure = storeProc.PROC_DR_LIST5
                    .cWhatColumn = cCol.forRrDr

                    .parameter("@n", paramValues("n"))
                    .parameter("@search", paramValues("search"))
                    .parameter("@searchBy", paramValues("searchBy"))

                    Dim bgw As New BackgroundWorker
                    bgw = .onProcessing()

                    paramBgWorker.Add(bgw)
                End With

            Case cCol.forRrWithDetails
                With paramModel
                    .cStoredProcedure = storeProc.PROC_DR_LIST5
                    .cWhatColumn = cCol.forRrWithDetails

                    .parameter("@n", paramValues("n"))
                    .parameter("@search", paramValues("search"))

                    Dim bgw As New BackgroundWorker
                    bgw = .onProcessing()

                    paramBgWorker.Add(bgw)
                End With
#End Region

#Region "REQUISITION"
            Case cCol.forRequisition
                With paramModel
                    .cStoredProcedure = storeProc.PROC_AGGREGATES
                    .cWhatColumn = cCol.forRequisition

                    .parameter("@n", 12)
                    .parameter("@search", paramValues("search"))

                    Dim bgw As New BackgroundWorker
                    bgw = .onProcessing()

                    paramBgWorker.Add(bgw)
                End With

            Case cCol.forRsCRH
                With paramModel
                    .cStoredProcedure = storeProc.PROC_AGGREGATES
                    .cWhatColumn = cCol.forRsCRH

                    'for search items by date enable
                    If paramValues.ContainsKey("dateEnable") And paramValues.ContainsKey("searchby") Then
                        .parameter("@dateFrom", paramValues("dateFrom"))
                        .parameter("@dateTo", paramValues("dateTo"))
                        .parameter("@searchby", paramValues("searchby"))
                        .parameter("@search", paramValues("search"))
                        .parameter("@n", 121)
                    Else
                        .parameter("@n", 1)
                        .parameter("@search", paramValues("search"))
                    End If

                    Dim bgw As New BackgroundWorker
                    bgw = .onProcessing(cCol.forRsCRH, paramLabel)

                    paramBgWorker.Add(bgw)
                End With

            Case cCol.forMainRsCRH

                With paramModel
                    .cStoredProcedure = storeProc.PROC_MAIN_RS_QTY
                    .cWhatColumn = cCol.forMainRsCRH

                    .parameter("@n", 5)
                    .parameter("@rs_no", paramValues("rs_no"))

                    Dim bgw As New BackgroundWorker
                    bgw = .onProcessing(cCol.forMainRsCRH, paramLabel)

                    paramBgWorker.Add(bgw)
                End With

            Case cCol.forMainRsCRH2
                With paramModel
                    .cStoredProcedure = storeProc.PROC_DR_LIST5
                    .cWhatColumn = cCol.forMainRsCRH2

                    .parameter("@n", paramValues("n"))
                    .parameter("@search", paramValues("search"))

                    Dim bgw As New BackgroundWorker
                    bgw = .onProcessing()

                    paramBgWorker.Add(bgw)
                End With

            Case cCol.forMainRsSubCRH
                With paramModel
                    .cStoredProcedure = storeProc.PROC_MAIN_RS_QTY
                    .cWhatColumn = cCol.forMainRsSubCRH

                    If .getParameter.ContainsKey("") Then

                    End If


                    .parameter("@n", 6)
                    .parameter("@rs_no", paramValues("rs_no"))

                    Dim bgw As New BackgroundWorker
                    bgw = .onProcessing()

                    paramBgWorker.Add(bgw)
                End With

            Case cCol.forMainRsSubCRH2
                With paramModel
                    .cStoredProcedure = storeProc.PROC_DR_LIST5
                    .cWhatColumn = cCol.forMainRsSubCRH2

                    .parameter("@n", paramValues("n"))
                    .parameter("@search", paramValues("search"))

                    Dim bgw As New BackgroundWorker
                    bgw = .onProcessing()

                    paramBgWorker.Add(bgw)
                End With

            Case cCol.forRsDr
                With paramModel
                    .cStoredProcedure = storeProc.PROC_DR_LIST5
                    .cWhatColumn = cCol.forRsDr

                    .parameter("@n", paramValues("n"))
                    .parameter("@search", paramValues("search"))
                    .parameter("@searchBy", paramValues("searchBy"))

                    Dim bgw As New BackgroundWorker
                    bgw = .onProcessing()

                    paramBgWorker.Add(bgw)
                End With

            Case cCol.forRsLocations
                With paramModel
                    .cWhatColumn = cCol.forRsLocations

                    Dim bgw As New BackgroundWorker
                    bgw = .onProcessing()

                    paramBgWorker.Add(bgw)
                End With

#End Region

#Region "PREVIOUS BALANCE FOR STOCKARD"
            Case cCol.forPrevBalance
                With paramModel

                    .cWhatColumn = cCol.forPrevBalance
                    .parameter("search", paramValues("search"))

                    Dim bgw As New BackgroundWorker
                    bgw = .onProcessing()

                    paramBgWorker.Add(bgw)
                End With


#End Region

#Region "WAREHOUSE AREA/STOCKPILE"
            Case cCol.forWareHouseStockpileArea
                With paramModel
                    .cStoredProcedure = storeProc.PROC_WH_ITEMS_CRUD
                    .cWhatColumn = cCol.forWareHouseStockpileArea
                    .parameter("crud", paramValues("crud"))
                    .parameter("search", paramValues("search"))

                    Dim bgw As New BackgroundWorker
                    bgw = .onProcessing()

                    paramBgWorker.Add(bgw)
                End With

            Case cCol.forWhInchargeNew
                With paramModel
                    .cStoredProcedure = storeProc.PROC_WH_ITEMS_CRUD
                    .cWhatColumn = cCol.forWhInchargeNew
                    .parameter("crud", paramValues("crud"))

                    Dim bgw As New BackgroundWorker
                    bgw = .onProcessing()

                    paramBgWorker.Add(bgw)
                End With
#End Region

#Region "HRMS"
            Case cCol.forEmployeeData
                With paramModel
                    .cStoredProcedure = storeProc.PROC_USERS
                    .cWhatColumn = cCol.forEmployeeData

                    .parameter("n", 2)

                    Dim bgw As New BackgroundWorker
                    bgw = .onProcessing()

                    paramBgWorker.Add(bgw)
                End With
#End Region

#Region "SMS USERS"
            Case cCol.forSmsUsers
                With paramModel
                    .cStoredProcedure = storeProc.PROC_USERS
                    .cWhatColumn = cCol.forSmsUsers

                    .parameter("n", 3)

                    Dim bgw As New BackgroundWorker
                    bgw = .onProcessing()

                    paramBgWorker.Add(bgw)
                End With
#End Region

#Region "EQUIPMENT"
            Case cCol.forPlateNo
                With paramModel
                    .cWhatColumn = cCol.forPlateNo

                    Dim bgw As New BackgroundWorker
                    bgw = .onProcessing()

                    paramBgWorker.Add(bgw)
                End With
#End Region

#Region "CHARGES"
            Case cCol.forAllCharges
                With paramModel
                    .cStoredProcedure = storeProc.PROC_DELIVERY_RECEIPT4
                    .cWhatColumn = cCol.forAllCharges

                    .parameter("@n", 3)
                    '.parameter("@search", paramValues("search"))

                    Dim bgw As New BackgroundWorker
                    bgw = .onProcessing()

                    paramBgWorker.Add(bgw)
                End With

            Case cCol.forMultipleCharges
                With paramModel
                    .cStoredProcedure = storeProc.PROC_DELIVERY_RECEIPT4
                    .cWhatColumn = cCol.forMultipleCharges

                    .parameter("@n", 4)
                    .parameter("@rs_id", paramValues("rs_id"))

                    Dim bgw As New BackgroundWorker
                    bgw = .onProcessing()

                    paramBgWorker.Add(bgw)
                End With

            Case cCol.forSearchByCharges
                With paramModel
                    .cStoredProcedure = storeProc.PROC_DR_LIST5
                    .cWhatColumn = cCol.forSearchByCharges

                    '.parameter("@n", 12)
                    '.parameter("@searchBy", paramValues("searchBy"))
                    '.parameter("@search", paramValues("search"))
                    '.parameter("@items", paramValues("items"))

                    .parameter("@n", 14)
                    .parameter("@category", paramValues("category"))
                    .parameter("@chargesId", paramValues("chargesId"))
                    .parameter("@items", paramValues("items"))

                    Dim bgw As New BackgroundWorker
                    bgw = .onProcessing()

                    paramBgWorker.Add(bgw)
                End With

            Case cCol.forSearchByChargesWithDateRange
                With paramModel
                    .cStoredProcedure = storeProc.PROC_DR_LIST5
                    .cWhatColumn = cCol.forSearchByChargesWithDateRange

                    .parameter("@n", 13)
                    .parameter("@searchBy", paramValues("searchBy"))
                    .parameter("@search", paramValues("search"))
                    .parameter("@items", paramValues("items"))
                    .parameter("@dateFrom", paramValues("dateFrom"))
                    .parameter("@dateTo", paramValues("dateTo"))

                    Dim bgw As New BackgroundWorker
                    bgw = .onProcessing()

                    paramBgWorker.Add(bgw)
                End With

#End Region

#Region "REQUESTED BY"
            Case cCol.forSearchByRequestedBy
                With paramModel
                    .cStoredProcedure = storeProc.PROC_DR_LIST5
                    .cWhatColumn = cCol.forSearchByRequestedBy

                    .parameter("@n", 15)
                    .parameter("@searchBy", paramValues("searchBy"))
                    .parameter("@search", paramValues("search"))
                    .parameter("@items", paramValues("items"))

                    Dim bgw As New BackgroundWorker
                    bgw = .onProcessing()

                    paramBgWorker.Add(bgw)
                End With
#End Region

#Region "TIRE POSITION/TIRE SERIAL NO"
            Case cCol.forTirePosition
                With paramModel

                    .cStoredProcedure = storeProc.PROC_TIRES
                    .cWhatColumn = cCol.forTirePosition

                    .parameter("@n", 1)

                    Dim bgw As New BackgroundWorker
                    bgw = .onProcessing()

                    paramBgWorker.Add(bgw)
                End With

            Case cCol.forTireSerialNo
                With paramModel

                    .cStoredProcedure = storeProc.PROC_TIRES
                    .cWhatColumn = cCol.forTireSerialNo

                    .parameter("@n", 2)

                    Dim bgw As New BackgroundWorker
                    bgw = .onProcessing()

                    paramBgWorker.Add(bgw)
                End With

            Case cCol.forTireSerialNoView
                With paramModel

                    .cStoredProcedure = storeProc.PROC_TIRES
                    .cWhatColumn = cCol.forTireSerialNoView

                    .parameter("@n", 3)

                    Dim bgw As New BackgroundWorker
                    bgw = .onProcessing()

                    paramBgWorker.Add(bgw)
                End With
#End Region

#Region "KPI"
            Case cCol.forKPIView
                With paramModel
                    .cWhatColumn = cCol.forKPIView

                    Dim bgw As New BackgroundWorker
                    bgw = .onProcessing()

                    paramBgWorker.Add(bgw)
                End With

            Case cCol.forMultipleKPI
                With paramModel
                    .cWhatColumn = cCol.forMultipleKPI

                    Dim bgw As New BackgroundWorker
                    bgw = .onProcessing()

                    paramBgWorker.Add(bgw)
                End With
#End Region

#Region "TYPE OF REQUEST | CONSOLIDATED ACCOUNT TITLE"
            Case cCol.forTypeOfRequest
                With paramModel
                    .cStoredProcedure = storeProc.PROC_TYPE_OF_REQUEST
                    .cWhatColumn = cCol.forTypeOfRequest

                    .parameter("@n", 5)
                    '.parameter("@search", paramValues("search"))

                    Dim bgw As New BackgroundWorker
                    bgw = .onProcessing()

                    paramBgWorker.Add(bgw)
                End With

            Case cCol.forConsolidationAccount
                With paramModel
                    .cStoredProcedure = storeProc.PROC_TYPE_OF_REQUEST
                    .cWhatColumn = cCol.forConsolidationAccount

                    .parameter("@n", 4)
                    '.parameter("@search", paramValues("search"))

                    Dim bgw As New BackgroundWorker
                    bgw = .onProcessing()

                    paramBgWorker.Add(bgw)
                End With
#End Region

#Region "QUANTITY TAKE OFF"
            Case cCol.forQTODetails
                With paramModel
                    .cStoredProcedure = storeProc.PROC_DR_LIST5
                    .cWhatColumn = cCol.forQTODetails

                    .parameter("@n", 10)
                    '.parameter("@search", paramValues("search"))

                    Dim bgw As New BackgroundWorker
                    bgw = .onProcessing()

                    paramBgWorker.Add(bgw)
                End With
#End Region

#Region "CANCELLED"
            Case cCol.forCancelRs
                With paramModel
                    .cStoredProcedure = storeProc.PROC_DR_LIST5
                    .cWhatColumn = cCol.forCancelRs

                    .parameter("@n", 11)

                    Dim bgw As New BackgroundWorker
                    bgw = .onProcessing()

                    paramBgWorker.Add(bgw)
                End With
#End Region

        End Select
    End Sub
End Module
