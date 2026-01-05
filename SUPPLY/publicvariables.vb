Module publicvariables
    Public publicquery As String

    Public wh_id As Integer
    Public charge_to_id, charge_to_id1 As Integer
    Public return_to_id, return_to_id1 As Integer

    Public charge_to_selection As Integer
    Public public_rs_id As Integer
    Public public_fac_tools As String

    'fpreviousstockard form
    Public id_supplier_receipient As Integer
    Public PSC_wh_id As Integer
    Public publicquery_Psc As String

    'if 1 - to frequestfields form
    'if 2 - to fpreviousstockcard form 
    Public charge_to_destination As Integer

    'if 1 - to frequestfields form
    'if 2 - to fpreviousstockcard form 
    Public wh_item_destination As Integer

    Public receiving_n As Integer
    Public receiving_inout As String

    Public po_edit As Integer
    Public po_no As String
    Public rs_no As String
    Public chargeto_name As String
    Public suppliers_id As Integer
    Public cvINFO_id As Integer
    Public rs_id As Integer
    Public qty As Integer
    Public type_purchasing As String
    Public ws_item_id As Integer
    Public type_charges As String

    Public rr_status As String

    Public pub_rs_id As Integer

    Public pub_user_id, uname, fname, lname, restriction, access, gender, username, password, auth, employee_id As String
    Public department As String = ""

    Public listofturnovercharges As New List(Of String)

    Public from_old_item_or_new_item As Integer = 0

    Public whouse_rs_selection As Boolean = False

    Public target_location_project As String
    Public public_rowind As Integer

    Public pub_po_det_id As Integer
    Public pub_wh_id As Integer


    Public pub_button_name As String

    Public dr_month_export As DateTime

    Public pub_qto_id As Integer

    Public bol_withdrawal_edit As Boolean = False

    Public requisition_wh_id As Integer
    Public requisition_item_name As String
    Public requisition_item_desc As String

    Public pub_main_rs_qty As Decimal
    Public pub_main_rs_qty_left As Decimal

    Public pub_rs_id2 As Integer
    Public pub_ws_id2 As Integer

    Public crusher_receiving As Integer
    Public crusher_total_qty_received As Decimal

    Public pub_rs_main_qty As Decimal

    'Accident Report
    Public get_acc_id As Integer
    Public boolean_acc_report As Boolean

    Public pub_search_by_charges As Integer

    Public c1 As Integer

    Public wh_id_for_dr As Integer
    Public pub_items_for_dr As String

    'LIST OF AGGREGATES NOT INCLUDE IN THE SUMMARY OF HAULED AGGREGATES 
    Public cListOfExemptedAggregates As New List(Of class_summary_of_hauled_agg.SELECTEDITEMS)

    'FILTER LIST OF TEXTBOX and COMBOBOX
    Public filterListofTextbox_combobox As New Dictionary(Of Object, String)

    'LIST OF DR IN DRLIST2
    Public pub_List_of_Dr


    'LIST OF RS AGGREGATES MONITORING
    Public pub_list_of_agg_monitoring As New List(Of class_aggregates_monitoring.rs_monitoring_agg)
    Public pub_cbcb As Integer


    'FOR LISTFOCUS RSID
    Public rs_id_for_listfocus As Integer

    Public pubPoNo As String

    Public pubBlankTextFieldName As String = ""
End Module
