Module Interfaces
    Public Interface IKPI
        Function saved(kpiData As PropsFields.KPIprops_fields) As Integer
        Function update(kpiData As PropsFields.KPIprops_fields, id As Integer) As Boolean
        Sub delete(id As Integer)
    End Interface

    Public Interface IWHArea
        Function saved(whAreaData As PropsFields.whArea_stockpile_props_fields, charge_to_id As Integer) As Integer
        Function update(whAreaData As PropsFields.whArea_stockpile_props_fields, charge_to_id As Integer, id As Integer) As Boolean
        Sub searchWarehouseArea(search As String)

        Function getSpecificWhArea(id As Integer) As PropsFields.whArea_stockpile_props_fields
        Sub delete(id As Integer)
    End Interface

    Public Interface IEmployee
        Function saved(whAreaData As PropsFields.employee_props_fields, Optional whAreaId As Integer = 0) As Integer
        Function update(whAreaData As PropsFields.employee_props_fields, id As Integer) As Boolean
        Sub delete(id As Integer, whAreaId As Integer)

        Function getEmployess(searchBy As String, search As String) As List(Of PropsFields.employee_props_fields)
        Sub searchEmployees(search As String)

        Sub initialize(Optional dgv As DataGridView = Nothing, Optional whAreaId As Integer = 0)
    End Interface

    Public Interface IWarehouseItem
        Function saved(whitem As PropsFields.whItems_props_fields, kpiData As List(Of PropsFields.SELECTED_KPI)) As Integer
        Function update(whitem As PropsFields.whItems_props_fields, id As Integer) As Boolean
        Function delete(wh_id As Integer) As Boolean
        Function getWarehouseItems(search As String) As List(Of PropsFields.whItems_props_fields)
        Sub searchWarehouseItems(search As String, Optional searchBy As String = "")
        Sub initialize(Optional dgv As DataGridView = Nothing, Optional loadingPanel As Panel = Nothing)

    End Interface
End Module
