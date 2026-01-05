Imports System.Security.Cryptography.Xml
Imports System.Web.UI.WebControls

Public Class PropsFields

    Public Class project_maintenance_fields
        Public Property proj_id As Integer
        Public Property datefrom As DateTime
        Public Property dateto As DateTime
        Public Property proj_desc As String
        Public Property location As String
        Public Property contract_id As String
        Public Property contract_name As String
        Public Property project_engineer As String
        Public Property contract_amount As Double
        Public Property budgetary_amount As Double
        Public Property duration As String
        Public Property days_left As Double
        Public Property date_completion As DateTime
        Public Property date_close As DateTime
        Public Property dateCloseOpen As String


    End Class
    Public Class eus_data_fields
        Public Property eu_id As Integer
        Public Property equipListID As Integer
        Public Property eu_date As String
        Public Property plate_no As String
        Public Property project As String
        Public Property time_start As DateTime
        Public Property time_end As DateTime
        Public Property RunHour As Double
        Public Property operator_driver As String
        Public Property trip As Double
        Public Property distance As Double
        Public Property remarks As String
        Public Property no_of_trips As Double
        Public Property user_ip As String
        Public Property type_of_equipment As String
        Public Property rate As Double
        Public Property user_log As String
        Public Property equip_category As String
        Public Property date_updated As String

    End Class

    Public Class whItems_properName_fields

        Public Property wh_pn_id As Integer
        Public Property item_name As String
        Public Property item_desc As String
        Public Property units As String
        Public Property type_of_request As String
        Public Property department As String
        Public Property userLog As String
        Public Property updateUserLog As String


    End Class

    Class incharge_fields
        Public Property incharge_id As Integer
        Public Property firstname As String
        Public Property lastname As String

    End Class

    Class inchargeNew_fields
        Public Property wh_area_incharge_id As Integer
        Public Property wh_area As String
        Public Property whIncharge As String
        Public Property wh_area_id As Integer
        Public Property incharge_id As Integer

    End Class

    Public Class whItems_props_fields
        Inherits whItems_properName_fields

        Public Property wh_id As Integer
        Public Property classification As String
        Public Property type_of_item As String
        Public Property warehouse_area As String
        Public Property specific_loc As String
        Public Property incharge As String
        Public Property reorder_point As Integer
        Public Property default_price As Double
        Public Property set_det_id As Integer
        Public Property division As String
        Public Property Turnover As String
        Public Property inout As String
        Public Property incharge_id As Integer
        Public Property disable As Integer
        Public Property proper_item_name As String
        Public Property proper_item_desc As String
        'Public Property wh_pn_id As Integer
        Public Property quarry As String
        Public Property quarry_id As Integer
        Public Property wh_area_id As Integer
        Public Property whArea_category As String
        Public Property kpi_id As Integer
        Public Property kpi As String
        Public Property tsp_id As Integer
        Public Property consolidated_account_id As Integer

    End Class


    Public Class dr_props_fields
        Public Property dr_date As DateTime
        Public Property dr_item_id As Integer
        Public Property rs_no As String
        Public Property requestor As String
        Public Property rs_date As DateTime
        Public Property dr_no As String
        Public Property plateno As String
        Public Property driver As String
        Public Property ws_no As String
        Public Property rr_no As String
        Public Property item_name As String
        Public Property item_desc As String
        Public Property unit As String
        Public Property dr_source As String
        Public Property concession_ticket As String
        Public Property dr_qty As Double
        Public Property price As Double
        Public Property total_amount As Double
        Public Property supplier As String
        Public Property checked_by As String
        Public Property received_by As String
        Public Property approved_by As String
        Public Property withdrawn_by As String
        Public Property remarks As String
        Public Property input_user As String
        Public Property inout As String
        Public Property rs_id As Integer
        Public Property po_no As String
        Public Property po_det_id As Integer
        Public Property dr_option As String
        Public Property date_reported As DateTime
        Public Property requestor_category As String
        Public Property wh_id As Integer
        Public Property source2 As String
        Public Property date_submitted As DateTime
        Public Property requestor_without_rs As String
        Public Property wh_pn_id As Integer
        Public Property dr_info_id As Integer
        Public Property wh_options As String
        Public Property quarry As String
        Public Property dr_date_log As DateTime
        Public Property whArea_category As String
        Public Property wh_area_id As Integer
        Public Property category_for_projectsite As String
        Public Property projectsite_id As Integer
        Public Property specific_location As String
        Public Property rs_no_orig As String
        Public Property type_of_requestor As String
        Public Property requestor_id As Integer
        Public Property par_rr_item_id As Integer

    End Class

    Public Class dr_for_dr_props_fields
        Inherits dr_props_fields
        Public Property date_log As DateTime
        Public Property user_id As Integer

    End Class

    Public Class dr_ws_props_fields
        Public Property ws_id As Integer
        Public Property ws_info_id As Integer
        Public Property ws_no As String
        Public Property rs_no As String
        Public Property requestor As String
        Public Property ws_date As DateTime
        Public Property rs_date As DateTime
        Public Property dr_no As String
        Public Property plateno As String
        Public Property driver As String
        Public Property po_no As String
        Public Property rr_no As String
        Public Property item_name As String
        Public Property item_desc As String
        Public Property unit As String
        Public Property ws_source As String
        Public Property concession_ticket As String
        Public Property ws_qty As Double
        Public Property price As Double
        Public Property total_amount As Double
        Public Property supplier As String
        Public Property checked_by As String
        Public Property approved_by As String
        Public Property withdrawn_by As String
        Public Property remarks As String
        Public Property users As String
        Public Property rs_id As Integer
        Public Property inout As String
        Public Property dr_option As String
        Public Property wh_id As Integer
        Public Property wh_pn_id As Integer
        Public Property source2 As String
        Public Property quarry As String

        Public Property serial_id As Integer

    End Class

    Class ws_for_dr_props_fields
        Inherits dr_ws_props_fields
        Public Property isQtyWithdrawn As Integer
        Public Property user_id As Integer
        Public Property user_id_logs As Integer
        Public Property user_id_update_logs As Integer
        Public Property date_log As DateTime
        Public Property date_log_updated As DateTime

    End Class

    Public Class dr_po_props_fields
        Public Property po_no As String
        Public Property wh_id As Integer
        Public Property item_name As String
        Public Property item_desc As String
        Public Property rs_id As Integer
        Public Property po_date As DateTime
        Public Property inout As String
        Public Property type_of_purchasing As String
        Public Property dr_option As String
        Public Property tax_category As String
        Public Property vat_value As String
        Public Property unit_price As Double
        Public Property units As String
        Public Property supplier_id As Integer
        Public Property po_cancel_status As Integer

    End Class
    Public Class po_for_dr_props_fields
        Inherits dr_po_props_fields
        Public Property po_det_id As Integer
        Public Property po_qty As Double
        Public Property remarks As String
        Public Property user_id As Integer
        Public Property user_id_logs As Integer
        Public Property user_id_update_logs As Integer
        Public Property date_log As DateTime
        Public Property date_log_updated As DateTime

    End Class

    Public Class dr_list_props_fields

        Public Property dr_item_id As Integer
        Public Property rs_no As String
        Public Property requestor As String
        Public Property dr_date As DateTime
        Public Property date_request As DateTime
        Public Property dr_no As String
        Public Property plateno As String
        Public Property driver As String
        Public Property ws_po_no As String
        Public Property rr_no As String
        Public Property item_name As String
        Public Property item_desc As String
        Public Property unit As String
        Public Property source As String
        Public Property concession_ticket As String
        Public Property dr_qty As Double
        Public Property price As Double
        Public Property total_amount As Double
        Public Property supplier As String
        Public Property checked_by As String
        Public Property received_by As String
        Public Property withdrawn_by As String
        Public Property remarks As String
        Public Property user As String
        Public Property inout As String
        Public Property dr_option As String
        Public Property rs_id As Integer
        Public Property approved_by As String
        Public Property wh_id As Integer
        Public Property wh_pn_id As Integer
        Public Property source2 As String
        Public Property date_submitted As DateTime
        Public Property requestor_without_rs As String
        Public Property dr_info_id As Integer
        Public Property wh_options As String
        Public Property quarry As String
        Public Property wh_area_id As Integer
        Public Property whArea_category As String
        Public Property category_for_projectsite As String
        Public Property projectsite_id As Integer
        Public Property specific_location As String
        Public Property rs_no_orig As String
        Public Property others_source As String
        Public Property type_of_requestor As String
        Public Property requestor_id As Integer
        Public Property par_rr_item_id As Integer

    End Class

    Public Class dr_wh_to_wh_pros_fields
        Public Property dr_item_id As Integer
        Public Property dr_date As DateTime
        Public Property rs_no As String
        Public Property dr_no As String
        Public Property ws_po_no As String
        Public Property rr_no As String
        Public Property item_name As String
        Public Property dr_qty As Double
        Public Property price As Double
        Public Property unit As String
        Public Property requestor As String
        Public Property concession_ticket As String
        Public Property inout As String
        Public Property user As String
        Public Property driver As String
        Public Property plateno As String
        Public Property checked_by As String
        Public Property received_by As String
        Public Property withdrawn_by As String
        Public Property date_request As DateTime
        Public Property supplier As String
        Public Property wh_id As Integer
        Public Property rs_id As Integer
        Public Property remarks As String
        Public Property dr_info_id As Integer

    End Class

    Public Class operator_driver_props_fields

        Public Property operator_id As Integer
        Public Property operator_name As String
        Public Property position As String

    End Class

    Public Class supplier_props_fields

        Public Property supplier_id As Integer
        Public Property supplierName As String
        Public Property supplierLocation As String
        Public Property terms As String

    End Class

    Public Class employee_props_fields
        Public Property person_id As Integer
        Public Property employee As String
        Public Property position As String
        Public Property employee_id As Integer
        Public Property last_name As String
        Public Property first_name As String
        Public Property middle_name As String
        Public Property ext_name As String
        Public Property designation As String
        Public Property department As String
        Public Property status_name As String

    End Class

    Class charges_info_props_fields
        Public Property charges_id As Integer
        Public Property charges_desc As String
        Public Property category As String

    End Class

    Class purchase_order_props_fields
        Public Property po_det_id As Integer
        Public Property po_no As String
        Public Property rs_no As String
        Public Property po_date As DateTime
        Public Property Supplier_Name As String
        Public Property Item_Name As String
        Public Property Item_Desc As String
        Public Property qty As Double
        Public Property unit As String
        Public Property unit_price As Double
        Public Property total_amount As Double
        Public Property instructions As String
        Public Property address As String
        Public Property terms As String
        Public Property rs_id As Integer
        Public Property charges As String
        Public Property date_needed As DateTime
        Public Property prepared_by As String
        Public Property checked_by As String
        Public Property approved_by As String
        Public Property selected As String
        Public Property po_id As String
        Public Property inout As String
        Public Property lead_time_rs_to_po As Double
        Public Property print_stats As String
        Public Property orig_date_printed As DateTime
        Public Property updated_date_printed As DateTime
        Public Property user_logs As String
        Public Property rs_date As DateTime
        Public Property type_of_request As String

        Public Property rs_purpose As String
        Public Property wh_id As Integer
        Public Property remarks As String
        Public Property requestor As String
        Property user_update_log As String
        Property cancel_po As Integer
        Property wh_pn_id As Integer
    End Class

    Class withdrawal_props_fields
        Public Property ws_id As Integer
        Public Property ws_no As String
        Public Property rs_no As String
        Public Property ws_date As DateTime
        Public Property item_name As String
        Public Property item_desc As String
        Public Property rs_qty As Double
        Public Property ws_qty As Double
        Public Property qty_withdrawn As Double
        Public Property unit As String
        Public Property unit_price As Double
        Public Property amount As Double
        Public Property withdrawn_by As String
        Public Property withdrawn_from As String
        Public Property released_by As String
        Public Property charges As String
        Public Property ws_info_id As Integer
        Public Property rs_id As Integer
        Public Property wh_id As Integer
        Public Property remarks As String
        Public Property dr_option As String
        Public Property purpose As String
        Public Property withdrawn_id As Integer
        Public Property status As String
        Public Property wh_pn_id As Integer
        Public Property issued_by As String
        Public Property withdrawn_status As String
        Public Property date_needed As DateTime
        Public Property users As String
        Public Property ws_date_log As DateTime
        Public Property serial_id As Integer
        Public Property division As String
        Public Property tire_category As String

    End Class

    Class receiving_props_fields
        Public Property rr_item_id As Integer
        Public Property rr_info_id As Integer
        Public Property rr_no As String
        Public Property po_det_id As Integer
        Public Property rs_no As String
        Public Property po_cv_no As String
        Public Property invoice_no As String
        Public Property supplier As String
        Public Property date_received As DateTime
        Public Property rr_qty As Double
        Public Property price As String
        Public Property item_name As String
        Public Property item_desc As String
        Public Property remarks As String
        Public Property type_of_purchasing As String
        Public Property total_amount As String
        Public Property status As String
        Public Property sorting As String
        Public Property charges As String
        Public Property wh_id As Integer
        Public Property inout As String
        Public Property checked_by As String
        Public Property received_by As String
        Public Property rs_purpose As String
        Public Property unit As String
        Public Property rs_id As Integer
        Public Property lead_time As String
        Public Property date_submitted As DateTime
        Public Property wh_pn_id As Integer
        Public Property date_log As DateTime
        Public Property user_id As Integer
        Public Property serial_id As Integer
        Public Property plateNo As String
        Public Property soNo As String
        Public Property driver As String
        Public Property source As String
        Public Property rr_item_desc As String
        Public Property rr_item_sub_id As Integer
        Public Property updatedAt As DateTime
        Public Property updatedById As Integer
    End Class

    Class rs_props_fields
        Public Property rs_id As Integer
        Public Property rs_date As DateTime
        Public Property date_needed As DateTime
        Public Property date_log As DateTime
        Public Property rs_no As String
        Public Property wh_id As Integer
        Public Property rs_items As String
        Public Property inout As String
        Public Property item_name As String
        Public Property type_of_purchasing As String
        Public Property request_type As String
        Public Property item_desc As String
        Public Property wh_location As String
        Public Property charges As String
        Public Property rs_qty As Double
        Public Property process As String
        Public Property unit As String
        Public Property type_of_request As String
        Public Property users As String
        Public Property cons_item As String
        Public Property cons_item_desc As String
        Public Property qty_takeoff_desc As String
        Public Property job_order_no As String
        Public Property location As String
        Public Property type_of_charges As String
        Public Property requested_by As String
        Public Property wh_area As String
        Public Property unit2 As String
        Public Property source As String
        Public Property purpose As String
        Public Property item_checked_log As DateTime
        Public Property wh_pn_id As Integer
        Public Property noted_by As String
        Public Property remarks_for_emd As String
        Public Property item_checked_user As Integer
        Public Property whItem As String
        Public Property whItemDesc As String
        Public Property division As String
        Public Property amount As Double
        Public Property price As Double
        Public Property rs_properName As String
        Public Property itemCheckedTo As String
        Public Property user_id_updated As Integer
        Public Property date_log_updated As DateTime

    End Class

    Class rs_for_dr_props_fields
        Inherits rs_props_fields
        Public Property unit_from_rs As String
        Public Property user_id As Integer
        Public Property charges_id As Integer
        Public Property tor_sub_id As Integer
        Public Property tors_ca_id As Integer
        Public Property wh_pn_id_for_rs As Integer
        Public Property ws_no As String

    End Class

    Class whArea_stockpile_props_fields
        Public Property wh_area_id As Integer
        Public Property wh_area As String
        Public Property wh_area_proper_name As String
        Public Property wh_incharge As String
        Public Property wh_location As String
        Public Property wh_options As String

    End Class

    Class smsUsers_props_fields
        Public Property user_id As Integer
        Public Property fName As String
        Public Property lName As String
        Public Property username As String
        Public Property password As String
        Public Property restriction As String
        Public Property ip_Address As String
        Public Property access As String
        Public Property employee_id As Integer
        Public Property auth As String


    End Class

    Class usersData
        Inherits PropsFields.smsUsers_props_fields
        Public Property department As String
        Public Property status_name As String
        Public Property designation As String

    End Class

    'Class employee_props_fields

    'End Class

    Class withdrawn_props_fields
        Public Property withdrawn_id As Integer
        Public Property rs_id As Integer
        Public Property ws_id As Integer
        Public Property date_log_withdrawn As DateTime
        Public Property date_withdrawn As DateTime
        Public Property status As String

    End Class

    Class withdrawal_released_props_fields
        Inherits withdrawn_props_fields
    End Class

    Class partiallyWithdrawn_props_fields
        Public Property partially_withdrawn_id As Integer
        Public Property withdrawn_id As Integer
        Public Property partially_withdrawn_qty As Double
        Public Property released_by As String
        Public Property received_by As String
        Public Property date_partially_withdrawn As DateTime
        Public Property user_id As Integer
        Public Property dateLog As DateTime
        Public Property status As String
        Public Property users As String
        Public Property units As String
        Public Property serial_id As Integer

    End Class


    Class partiallyReleasedWithdrawal_props_fields
        Public Property partially_withdrawn_id As Integer
        Public Property withdrawn_id As Integer
        Public Property rs_no As String
        Public Property released_by As String
        Public Property received_by As String
        Public Property partially_withdrawn_qty As Double
        Public Property partiallyWithdrawnDate As DateTime
        Public Property user_id As Integer
        Public Property dateLog As DateTime
        Public Property dateTimeDeleted As DateTime
        Public Property deleted_status As String
        Public Property rs_id As Integer
        Public Property ws_id As Integer
        Public Property dateLogWithdrawn As DateTime
        Public Property dateWithdrawn As DateTime
        Public Property status As String

    End Class

    Public Class rsdata_props_fields
        Public Property rs_id As Integer
        Public Property rs_date As DateTime
        Public Property date_needed As DateTime
        Public Property date_log As DateTime
        Public Property rs_no As String
        Public Property wh_id As Integer
        Public Property rs_items As String
        Public Property inout As String
        Public Property item_name As String
        Public Property type_of_purchasing As String
        Public Property request_type As String
        Public Property item_desc As String
        Public Property wh_location As String
        Public Property charges As String
        Public Property rs_qty As Double
        Public Property process As String
        Public Property unit As String
        Public Property type_of_request As String
        Public Property users As String
        Public Property cons_item As String
        Public Property cons_item_desc As String
        Public Property qty_takeoff_desc As String
        Public Property job_order_no As String
        Public Property location As String
        Public Property type_of_charges As String
        Public Property requested_by As String
        Public Property wh_area As String
        Public Property unit2 As String
        Public Property source As String
        Public Property purpose As String
        Public Property item_checked_log As DateTime
        Public Property wh_pn_id As Integer


    End Class

    Public Class rrdata_props_fields
        Public Property rs_id As Integer
        Public Property rr_item_id As Integer
        Public Property date_received As DateTime
        Public Property date_log As DateTime
        Public Property rr_no As String
        Public Property qty As Double
        Public Property po_det_id As Integer
        Public Property unit As String
        Public Property remarks As String
        Public Property users As String
    End Class

    Public Class main_rsdata_props_fields
        Public Property main_rs_qty_id As Integer
        Public Property main_rs_qty As Double
        Public Property rs_no As String
        Public Property open_close_qty As Double
        Public Property rs_id As Integer

    End Class

    Public Class create_dr_props_fields
        Public Property id As Integer
        Public Property dr_date As DateTime
        Public Property date_submitted As DateTime
        Public Property drNo As String
        Public Property driver As String
        Public Property plateNo As String
        Public Property items As String
        Public Property stockpile_source As String
        Public Property stockpile_recepient As String
        Public Property recepient_id As Integer
        Public Property recepient_category As String
        Public Property recepient_for_screening As String
        Public Property concession As String
        Public Property drQty As Double
        Public Property price As Double
        Public Property checkedBy As String
        Public Property receivedBy As String
        Public Property wh_id As Integer
        Public Property inout As String
        Public Property transaction As Integer
        Public Property stockpileAreaId As Integer
        Public Property remarks As String
        Public Property supplier As String
        Public Property dr_transaction As String


    End Class

    Public Class create_dr_info_fields
        Inherits create_dr_props_fields
        Public Property equipListId As Integer
        Public Property operator_id As Integer
        Public Property dateLog As DateTime
        Public Property options As String
        Public Property supplier_id As Integer
        Public Property wsNo As String
        Public Property rrNo As String
        Public Property rsId As Integer
        Public Property in_to_stockard As String
        Public Property user_id As Integer
        Public Property typeOfPurchasing As String

    End Class

    Public Class equipment_props_fields
        Public Property equipListID As Integer
        Public Property Equip_Type As String
        Public Property PlateNo As String

    End Class

    Public Class AllCharges
        Public Property charges_id As Integer
        Public Property charges As String
        Public Property charges_category As String
        Public Property specific_location As String
        Public Property rs_id As Integer

    End Class

    Public Class whItemsFinal
        Public Property wh_id As Integer
        Public Property item_name
        Public Property item_desc As String
        Public Property proper_item_name As String
        Public Property proper_item_desc As String
        Public Property kpi As String
        Public Property type_of_item As String
        Public Property consolidation_account As String
        Public Property classification As String
        Public Property whArea_category As String
        Public Property warehouse_area As String
        Public Property quarry As String
        Public Property specific_loc As String
        Public Property incharge As String
        Public Property reorder_point As Double
        Public Property default_price As Double
        Public Property units As String
        Public Property inout As String
        Public Property set_det_id As Integer
        Public Property division As String
        Public Property Turnover As String
        Public Property firstname As String
        Public Property lastname As String
        Public Property incharge_id As Integer
        Public Property disable As String
        Public Property wh_pn_id As Integer
        Public Property wh_area_id As Integer
        Public Property quarry_id As Integer


    End Class

    Public Class editWhItems_props_fields
        Inherits whItemsFinal
        Public Property kpi_id As Integer
        Public Property quarry_id As Integer
        Public Property consolidated_account_id As Integer


    End Class

    Public Class aggregatesPrices_props_fields
        Public Property aggPricingId As Integer
        Public Property wh_id As Integer
        Public Property zoning_area_category As String
        Public Property zoning_price As Double
        Public Property zoning_area_id As Integer
        Public Property zoning_source_category As String
        Public Property zoning_source_id As Integer


    End Class

    Public Class PROPS_AGG_PRICES
        Inherits aggregatesPrices_props_fields
        Public Property zoning_source As String
        Public Property zoning_area As String

    End Class

    Public Class rsFormParam_props_fields
        Public Property search As String
        Public Property searchby As String
        Public Property id As Integer
        Public Property lvl As ListView

    End Class

    Public Class tirePosition_props_fields
        Public Property tire_position_id As Integer
        Public Property position As String

    End Class

    Public Class tireSerial_props_fields

        Public Property serial_id As Integer
        Public Property rr_items_id As Integer
        Public Property tire_position_id As Integer
        Public Property serial_no As String

    End Class

    Public Class tireSerialView_props_fields
        Inherits tireSerial_props_fields

        Public Property item_name As String
        Public Property item_desc As String
        Public Property properName As String
        Public Property rr_no As String
        Public Property serialNo As String
        Public Property position As String
        Public Property remaining_balance As Double
        Public Property units As String
        Public Property amounts As Decimal

    End Class

    Public Class KPIprops_fields
        Public Property kpi_id As Integer
        Public Property indicator As String
        Public Property lead_time_days As Double
        Public Property lead_time_category As String

    End Class

    Public Class MultipleKPIprops_fields
        Inherits KPIprops_fields
        Public Property wh_id As Integer

    End Class

    Public Class item_checked_props_fields
        Public Property rs_id As Integer
        Public Property wh_id As Integer
        Public Property inOut As String
        Public Property typeOfPurchasing As String
        Public Property remarks As String
        Public Property user_id As Integer
        Public Property date_log As DateTime
        Public Property warehouseIncharge As String
        Public Property approved_by As String


    End Class

    Public Class Create_Requesition_Slip
        Inherits rs_for_dr_props_fields
        Public Property tors_ca_id As Integer
    End Class

    Public Class Create_withdrawal_slip_for_dr_props_fields
        Inherits ws_for_dr_props_fields
        Public Property supplier_id As Integer
        Public Property date_needed As DateTime
        Public Property released_by As String


    End Class

    Public Class Create_withdrawal_slip_for_warehouseing_fields
        Inherits ws_for_dr_props_fields
        Public Property released_by As String
        Public Property issued_by As String
        Public Property date_needed As DateTime
        Public Property date_issued As DateTime
    End Class

    Public Class Create_purchaseOrder_for_dr_props_fields
        Inherits po_for_dr_props_fields
        Public Property rs_no As String
        Public Property date_needed As DateTime
        Public Property supplier_id As Integer
        Public Property instruction As String
        Public Property prepared_by As String
        Public Property checked_by As String
        Public Property approved_by As String
        Public Property units As String
        Public Property unit_price As Double
        Public Property terms As String
        Public Property po_id As Integer

    End Class

    Public Class Create_receiving_for_dr_props_fields
        Inherits receiving_props_fields
        Public Property supplier_id As Integer
        Public Property soNo As String
        Public Property plateNo As String
        Public Property tireOption As String
        Public Property inoutsource As String
        Public Property driver As String
    End Class

    Public Class Purchase_Order_Row
        Public Property rs_id As Integer
        Public Property supplier As String
        Public Property wh_id As Integer
        Public Property item_description As String
        Public Property poNo As String
        Public Property terms As String
        Public Property rs_qty_balance As String
        Public Property qty As String
        Public Property unit As String
        Public Property unit_price As String
        Public Property amount As String
        Public Property price_with_tax As String
        Public Property tax_category As String
        Public Property tax_value As String
        Public Property user_id As Integer
        Public Property supplier_id As Integer
        Public Property charges As String

        Public Property proper_naming As String
        Public Property po_det_id As Integer

    End Class

    Public Class Receiving_row
        Public Property po_det_id As Integer
        Public Property item_description As String
        Public Property rr_item_description As String
        Public Property po_no As String
        'Public Property rr_no As String
        Public Property po_qty_balance As String
        Public Property rr_qty As String
        Public Property unit As String
        Public Property unit_price As String
        Public Property amount As String
        Public Property rs_id As Integer
        Public Property typeOfPurchasing As String
        Public Property level As String
        Public Property other_id As Integer


    End Class

    Public Class SelectDynamic
        Public Property defaultTable As String
        Public Property isMultipleTable As Boolean
        Public Property myAlias As String
        Public Property dbSource As String
        Public Property joinClause As List(Of String)
        Public Property condition As String
        Public Property columns As List(Of String)

        Public Overrides Function ToString() As String
            Dim joinClauseNew As String = If(joinClause IsNot Nothing, String.Join($" {vbCrLf}", joinClause.ToArray()), "")
            Dim columnsNew As String = If(columns IsNot Nothing, String.Join($", ", columns.ToArray()), "")

            Return $"Default Table: {defaultTable} { vbCrLf } Columns: {columnsNew} Multiple Table: {isMultipleTable} {vbCrLf} Alias: {myAlias} {vbCrLf} Source: {dbSource} {vbCrLf} Join Clause: {joinClauseNew} {vbCrLf} Condition: {condition}"
        End Function
    End Class

    Public Class TypeOfRequest
        Public Property tor_sub_id As Integer
        Public Property tor_id As Integer
        Public Property tor_sub_desc As String
        Public Property tor_desc As String
        Public Property tors_ca_id As Integer
    End Class

    Public Class Consolidated_Account
        Inherits TypeOfRequest
        Public Property consolidated_account_id As Integer
        Public Property category As String
        Public Property codes As String

    End Class

    Public Class SMSTables
        Public Property table As String
        Public Property condtion As String
    End Class

    Public Class MultipleCharges
        Public Property charges_id As Integer
        Public Property all_charges_id As Integer
        Public Property charges_category As String
        Public Property rs_id As Integer
        Public Property temp_code_id As Integer
        Public Property createdAt As DateTime

    End Class

    Public Class QTO_details
        Public Property rs_id As Integer
        Public Property rs_item_details_id As Integer
        Public Property details As String

    End Class

    Public Class CancelledTransaction
        Public Property id As Integer
        Public Property trans As String
        Public Property trans_id As Integer
        Public Property remarks As String


    End Class

    Public Class byCharges
        Public Property rsId As Integer
        Public Property rsNo As String
        Public Property item_desc_from_item_checked As String
        Public Property item_desc_from_rs As String

        Public Property item_desc As String
        Public Property qty As Double
        Public Property price As Double
        Public Property amount As Double
        Public Property rs_date As DateTime
        Public Property wh_id As Integer
        Public Property rs_id As Integer
        Public Property type_of_purchasing As String
        Public Property requested_by As String


    End Class

    Public Class SELECTED_KPI
        Public Property kpi_id As Integer
        Public Property tor_id As Integer

    End Class

    Public Class columnSettings
        Public Property displayIndex As Integer
        Public Property headerText As String
        Public Property headerName As String

    End Class
End Class
