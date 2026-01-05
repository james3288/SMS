Module pubEnum
    Public Class ColumnEnum
        Public ReadOnly Property forEu_EquipType_DateFrom_DateTo As Integer = 1
        Public ReadOnly Property forEu_Project_DateFrom_DateTo As Integer = 2
        Public ReadOnly Property forEu_Project As Integer = 3
        Public ReadOnly Property forActive_Projects As Integer = 4
        Public ReadOnly Property forWhItem_ProperNames As Integer = 5
        Public ReadOnly Property forWhItems As Integer = 6
        Public ReadOnly Property forWhIncharge As Integer = 7
        Public ReadOnly Property forDisplayResult As Integer = 8
        Public ReadOnly Property forDrSearch As Integer = 9
        Public ReadOnly Property forDrWsSearch As Integer = 10
        Public ReadOnly Property forDrPoSearch As Integer = 11
        Public ReadOnly Property forOperatorDriver As Integer = 12
        Public ReadOnly Property forSupplier As Integer = 13
        Public ReadOnly Property forEmployees As Integer = 14
        Public ReadOnly Property forChargesInfo As Integer = 15
        Public ReadOnly Property forRsIdByWhId As Integer = 16
        Public ReadOnly Property forPurchaseOrder As Integer = 17
        Public ReadOnly Property forWithdrawal As Integer = 18
        Public ReadOnly Property forReceiving As Integer = 19
        Public ReadOnly Property forRequisition As Integer = 20
        Public ReadOnly Property forPrevBalance As Integer = 21
        Public ReadOnly Property forResult As Integer = 22
        Public ReadOnly Property forDrWithoutRsSearch As Integer = 23
        Public ReadOnly Property forWareHouseStockpileArea As Integer = 24
        Public ReadOnly Property forEmployeeData As Integer = 25
        Public ReadOnly Property forSmsUsers As Integer = 26
        Public ReadOnly Property forWhInchargeNew As Integer = 27
        Public ReadOnly Property forWithdrawn As Integer = 28
        Public ReadOnly Property forPartiallyWithdrawn As Integer = 29
        Public ReadOnly Property forWithdrawalPrice As Integer = 30
        Public ReadOnly Property forRsCRH As Integer = 31
        Public ReadOnly Property forMainRsCRH As Integer = 32
        Public ReadOnly Property forMainRsSubCRH As Integer = 33
        Public ReadOnly Property forPlateNo As Integer = 34
        Public ReadOnly Property forAllCharges As Integer = 35
        Public ReadOnly Property forAggPrices As Integer = 36
        Public ReadOnly Property forTirePosition As Integer = 37
        Public ReadOnly Property forTireSerialNo As Integer = 38
        Public ReadOnly Property forTireSerialNoView As Integer = 39
        Public ReadOnly Property forKPIView As Integer = 40
        Public ReadOnly Property forTypeOfRequest As Integer = 41
        Public ReadOnly Property forConsolidationAccount As Integer = 42
        Public ReadOnly Property forRsDr As Integer = 43
        Public ReadOnly Property forWsDr As Integer = 44
        Public ReadOnly Property forDrDr As Integer = 45
        Public ReadOnly Property forPoDr As Integer = 46
        Public ReadOnly Property forRrDr As Integer = 47
        Public ReadOnly Property forMainRsCRH2 As Integer = 48
        Public ReadOnly Property forMainRsSubCRH2 As Integer = 49
        Public ReadOnly Property forPartiallyReleasedWithdrawal As Integer = 50
        Public ReadOnly Property forRrWithDetails As Integer = 51
        Public ReadOnly Property forMultipleCharges As Integer = 52
        Public ReadOnly Property forMultipleKPI As Integer = 53
        Public ReadOnly Property forQTODetails As Integer = 54
        Public ReadOnly Property forCancelRs As Integer = 55
        Public ReadOnly Property forSearchByCharges As Integer = 56
        Public ReadOnly Property forSearchByChargesWithDateRange As Integer = 57
        Public ReadOnly Property forRsLocations As Integer = 58
        Public ReadOnly Property forSearchByRequestedBy As Integer = 59

    End Class

    Public Class StoredProcedureEnum
        Public ReadOnly Property PROC_EU_SEARCH1 As String = "PROC_EU_SEARCH1"
        Public ReadOnly Property PROC_ACTIVE_PROJECTS As String = "proc_project_duration"
        Public ReadOnly Property PROC_WHITEM_PROPERNAMING As String = "proc_whItem_properNaming"
        Public ReadOnly Property PROC_WAREHOUSE_ITEMS As String = "proc_get_data_from_warehouse1"
        Public ReadOnly Property PROC_DRLIST2 As String = "proc_dr_list2"
        Public ReadOnly Property PROC_DRLIST3 As String = "proc_dr_list3"
        Public ReadOnly Property PROC_DRLIST4 As String = "proc_dr_list4"
        Public ReadOnly Property PROC_DELIVERY_RECEIPT4 As String = "proc_Delivery_Receipt4"
        Public ReadOnly Property PROC_PO_QUERY_NEW2 As String = "po_query_new2"
        Public ReadOnly Property PROC_RECEIVING_CRUD_NEW6 As String = "proc_receiving_crud_new6"
        Public ReadOnly Property PROC_AGGREGATES As String = "PROC_AGGREGATES"
        Public ReadOnly Property PROC_WH_ITEMS_CRUD As String = "proc_wh_items_crud"
        Public ReadOnly Property PROC_USERS As String = "proc_users"
        Public ReadOnly Property PROC_MAIN_RS_QTY As String = "proc_main_rs_qty"
        Public ReadOnly Property PROC_TIRES As String = "proc_tires"
        Public ReadOnly Property PROC_TYPE_OF_REQUEST As String = "proc_type_of_request"
        Public ReadOnly Property PROC_DR_LIST5 As String = "proc_dr_list5"




    End Class

    Public Class ParameterName
        Public ReadOnly Property PROJECT As String = "project"
        Public ReadOnly Property DATEFROM As String = "dateFrom"
        Public ReadOnly Property DATETO As String = "dateTo"
        Public ReadOnly Property SEARCH As String = "search"
        Public ReadOnly Property SEARCH_BY As String = "searchby"

    End Class

    Public Class IsActiveEnum
        Public ReadOnly Property ACTIVE As String = "active"
        Public ReadOnly Property ENACTIVE As String = "enactive"
        Public ReadOnly Property ALL As String = "all"

    End Class

    Public Class triggeredEnum
        Public ReadOnly Property SAVE As String = "save"
        Public ReadOnly Property UPDATE As String = "update"
    End Class

    Public Class ExportToExcelHeaderEnum
        Public ReadOnly Property ITEM As String = "ITEM"
        Public ReadOnly Property ITEM_DESC As String = "ITEM DESCRIPTION"
        Public ReadOnly Property TYPE_OF_REQUEST As String = "TYPE OR REQUEST"
        Public ReadOnly Property UNIT As String = "UNIT"

    End Class

    Public Class SearchByEnum
        Public ReadOnly Property SEARCH_BY_ITEM_NAME As String = "Search by Item Name"
        Public ReadOnly Property SEARCH_BY_ITEM_DESC As String = "Search by Item Description"
        Public ReadOnly Property SEARCH_BY_SPECIFIC_LOC As String = "Search by Specific Location"
        Public ReadOnly Property SEARCH_BY_WAREHOUSE_AREA As String = "Search by Warehouse Area/Stockpile"
        Public ReadOnly Property SEARCH_BY_RETURNED_ITEM As String = "Search by Returned Item"
        Public ReadOnly Property SEARCH_BY_WAREHOUSE_INCHARGE As String = "Search by Warehouse Incharge"
        Public ReadOnly Property SEARCH_BY_DISABLED_ITEM As String = "Search by Disabled Item"
        Public ReadOnly Property SEARCH_BY_PROPER_NAMING As String = "Search by Proper Naming"
        Public ReadOnly Property SEARCH_BY_WH_ID As String = "Search by WH_ID"
        Public ReadOnly Property SEARCH_BY_KPI As String = "Search by KPI"
        Public ReadOnly Property SEARCH_BY_WH_PN_ID As String = "Search by WH_PN_ID"
        Public ReadOnly Property CLASSIFICATION As String = "Search by Classification"





    End Class

    Public Class DrSearchEnum
        Public ReadOnly Property RSNO As String = "RS NO"
        Public ReadOnly Property DRNO As String = "DR NO"
        Public ReadOnly Property WSNO As String = "WS NO"
        Public ReadOnly Property DRIVER As String = "DRIVER"
        Public ReadOnly Property PLATE_NO As String = "PLATE NO"
        Public ReadOnly Property UNIT As String = "UNIT"
        Public ReadOnly Property ITEM_DESC As String = "ITEM DESCRIPTION"
        Public ReadOnly Property CONSESSION As String = "CONSESSION TICKET"
        Public ReadOnly Property REQUESTOR As String = "REQUESTOR"
        Public ReadOnly Property SOURCE As String = "SOURCE"
        Public ReadOnly Property REMARKS As String = "REMARKS"
        Public ReadOnly Property SUPPLIER As String = "SUPPLIER"
        Public ReadOnly Property DATE_RANGE As String = "DATE RANGE"
        Public ReadOnly Property WH_ID As String = "WH_ID"
        Public ReadOnly Property WITHOUT_RS_AND_DR As String = "WITHOUT RS AND DR"
        Public ReadOnly Property IN_OUT As String = "IN/OUT"
        Public ReadOnly Property ENABLE_DATE_RANGE As String = "ENABLE DATE RANGE"
        Public ReadOnly Property DISABLE_DATE_RANGE As String = "DISABLE DATE RANGE"
        Public ReadOnly Property RECEIVED_BY As String = "RECEIVED BY"
        Public ReadOnly Property EMPLOYEES As String = "EMPLOYEES"
        Public ReadOnly Property CHARGES_INFO As String = "CHARGES INFO"
        Public ReadOnly Property DR_WS_DATE As String = "DR WS DATE"
        Public ReadOnly Property DATE_LOG As String = "DATE LOG"
        Public ReadOnly Property DATE_SUBMITTED As String = "DATE SUBMITTED"
        Public ReadOnly Property QTY As String = "QTY"
        Public ReadOnly Property CHECKED_BY As String = "CHECKED BY"
        Public ReadOnly Property DR_ITEMS_ID As String = "DR_ITEMS_ID"



    End Class

    Public Class INOutEnum
        Public _IN As String = "IN"
        Public _OUT As String = "OUT"
        Public _OUT_RELEASED As String = "OUT - RELEASED"
        Public _PARTIAL As String = "OUT - PARTIAL"
        Public _OTHERS As String = "OTHERS"
    End Class

    Public Class WarehouseOptionsEnum
        Public WAREHOUSE As String = "WAREHOUSE"
        Public STOCKPILE As String = "STOCKPILE"
        Public QUARRY As String = "QUARRY"
        Public ON_SITE_STORAGE As String = "ON-SITE STORAGE"
        Public PROJECT As String = "PROJECT"

    End Class

    Public Class DivisionEnum
        Public CRUSHING_AND_HAULING As String = "CRUSHING AND HAULING"
        Public WAREHOUSING_AND_SUPPLY As String = "WAREHOUSING AND SUPPLY"
    End Class

    Public Class TypeOfRequestEnum
        Public MAJOR As String = "Construction Materials - Major Request"
        Public MINOR As String = "Construction Materials - Minor Request"
    End Class

    Public Class EmployeeStatusEnum
        Public REGULAR As String = "REGULAR"
        Public PROJECT_BASE As String = "PROJECT BASED"
        Public RETIRED As String = "RETIRED"
        Public UNDER_PROBATIONARY As String = "UNDER PROBATIONARY"
        Public SEPARATED As String = "SEPARATED"

    End Class

    Public Class TypeOfPurchasingEnum
        Public PURCHASE_ORDER As String = "PURCHASE ORDER"
        Public WITHDRAWAL As String = "WITHDRAWAL"
        Public CASH_WITH_RR As String = "CASH WITH RR"
        Public CASH_WITHOUT_RR As String = "CASH WITHOUT RR"

        Public DR As String = "DR"
    End Class

    Public Class fontsCollectionEnum
        Public arial As String = "Arial"
        Public bombardier As String = "Bombardier"
    End Class

    Public Class DrCategory
        Public WITH_DR As String = "WITH DR"
        Public WITHOUT_DR As String = "WITHOUT DR"
    End Class

    Public Enum SaveBtn
        Update
        Save
    End Enum

    Public Enum FieldsProperty
        textBox
        comboBox
        dateTimePicker
    End Enum

    Public Enum DisableEnable
        disableFieldsForEdit
        enableFieldsAfterEdit
        withDr
        withoutDr
    End Enum

    Public Enum DROptions
        out_with_rs
        out_without_rs
        in_without_rs
        others_without_rs
        in_with_rs
        others_with_rs
        in_with_rs_po_rr
    End Enum

    Public Class RSRowColor
        Public ReadOnly Property MainRs As Color = ColorTranslator.FromHtml("#222831") 'Color.Lime
        Public ReadOnly Property MainSubRS As Color = Color.Black 'ColorTranslator.FromHtml("#393E46") 'Color.DarkGreen
        Public ReadOnly Property WsPo As Color = ColorTranslator.FromHtml("#948979") 'Color.LightGreen
        Public ReadOnly Property Rr As Color = ColorTranslator.FromHtml("#DFD0B8") 'ColorTranslator.FromHtml("#FDDB87") 'Color.LightPink
        Public ReadOnly Property Dr As Color = Color.LightYellow
        Public ReadOnly Property Pw As Color = ColorTranslator.FromHtml("#DFDFDF")
        Public ReadOnly Property Dr_sts As Color = Color.LightYellow 'ColorTranslator.FromHtml("#DCD7C9") 'Color.LightCyan
        Public ReadOnly Property rowSplitter As Color = ColorTranslator.FromHtml("#282E39") 'ColorTranslator.FromHtml("#A0A0A0")
        Public ReadOnly Property totalRow As Color = ColorTranslator.FromHtml("#282E39") 'ColorTranslator.FromHtml("#282E39")
    End Class

    Public Class RSRowColor_Supply
        Public ReadOnly Property Rs As Color = Color.DarkGreen
        Public ReadOnly Property WsPo As Color = Color.LightGreen
        Public ReadOnly Property Rr As Color = Color.LightYellow

    End Class

    Public Class DrListRowColor
        Public ReadOnly Property outWithDR As Color = ColorTranslator.FromHtml("#FDDB87")
        Public ReadOnly Property outWithoutDR As Color = Color.LightGreen
        Public ReadOnly Property othersDR As Color = ColorTranslator.FromHtml("#D2E7DD")
        Public ReadOnly Property inDR As Color = Color.LightYellow
    End Class

    Public Class OTHERSCATEGORY
        Public ReadOnly Property NOT_APPLICABLE As String = "NOT APPLICABLE"
        Public ReadOnly Property FOR_TIRE_STOCKING As String = "FOR TIRE STOCKING"
        Public ReadOnly Property TIRE_STORAGE As String = "TIRE STORAGE"

    End Class

    Public Class TAX_CATEGORY
        Public ReadOnly Property NOT_APPLICABLE As String = "N/A"
        Public ReadOnly Property VAT As String = "VAT (Value Added Tax)"
        Public ReadOnly Property EWT As String = "EWT (Expanded Withholding Tax)"

    End Class

    Public Class COLOR_SCHEME
        Public ReadOnly Property CUSTOM1 As String = "CUSTOM1"
        Public ReadOnly Property CUSTOM2 As String = "CUSTOM2"

    End Class

    Public Class USER_AUTHENTICATION
        Public ReadOnly Property ADMIN As String = "ADMIN"
        Public ReadOnly Property GUESS As String = "GUESS"
        Public ReadOnly Property SUPER_USER As String = "SUPER_USER"
    End Class

    Public Class DEPARTMENTS
        Public ReadOnly Property CRUSHING_AND_HAULING As String = "CRUSHING AND HAULING"
        Public ReadOnly Property WAREHOUSING As String = "WAREHOUSING"
        Public ReadOnly Property PURCHASING As String = "PURCHASING"
        Public ReadOnly Property EQUIPMENT_MONITORING As String = "EQUIPMENT MONITORING"
        Public ReadOnly Property FAD As String = "FINANCE AUDIT DEPARTMENT"


    End Class

    Public Class CRUSHING_AND_HAULING_TRANSACTION
        Public ReadOnly Property QUARRY_TO_STOCKPILE As String = "quarry-to-stockpile"
        Public ReadOnly Property QUARRY_TO_PROJECT As String = "quarry-to-project"
        Public ReadOnly Property OUTSOURCE_TO_STOCKPILE As String = "outsource-to-stockpile"
        Public ReadOnly Property STOCKPILE_TO_STOCKPILE As String = "stockpile-to-stockpile"
        Public ReadOnly Property STOCKPILE_TO_PROJECT As String = "stockpile-to-project"
        Public ReadOnly Property WASTE_DISPOSAL_AND_OTHERS As String = "waste-disposal-and-others"

    End Class



    Public storeProc As New StoredProcedureEnum
    Public cCol As New ColumnEnum
    Public paramName As New ParameterName
    Public cIsActive As New IsActiveEnum
    Public cTriggered As New triggeredEnum
    Public cExcelToSQLHeader As New ExportToExcelHeaderEnum
    Public cSearchBy As New SearchByEnum
    Public cDrSearchBy As New DrSearchEnum
    Public cInOut As New INOutEnum
    Public cWarehouseOption As New WarehouseOptionsEnum
    Public cDivision As New DivisionEnum
    Public cTypeOfRequest As New TypeOfRequestEnum
    Public cEmployeeStatus As New EmployeeStatusEnum
    Public cTypeOfPurchasing As New TypeOfPurchasingEnum
    Public cFontsFamily As New fontsCollectionEnum
    Public cFieldsProp As New FieldsProperty
    Public cDbName As New tableNameType
    Public cRsRowColor As New RSRowColor
    Public cDrListColor As New DrListRowColor
    Public cRsRowColor_Supply As New RSRowColor_Supply
    Public cTaxCategory As New TAX_CATEGORY
    Public cDrCategory As New DrCategory
    Public cUserAuthentication As New USER_AUTHENTICATION
    Public cDepartments As New DEPARTMENTS
    Public cCrushingAndHaulingTransaction As New CRUSHING_AND_HAULING_TRANSACTION

    Public ReadOnly Property cNotApplicable As String = "N/A"
End Module
