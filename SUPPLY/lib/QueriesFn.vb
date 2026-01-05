Imports System.Data.SqlClient
Imports System.Windows.Forms.AxHost
Imports SUPPLY.class_main_rs_qty
Imports SUPPLY.PropsFields

Public Class QueriesFn
    Public cDict As New Dictionary(Of String, Object)
    Public cStoredProcedure As String
    Public cWhatColumn As Integer
    Private cColumn As New ColumnEnum
    Private customMsg As New customMessageBox

#Region "EU"
    Public Function _get_eu() As List(Of PropsFields.eus_data_fields)
        _get_eu = New List(Of PropsFields.eus_data_fields)

        Dim SQ As New SQLcon
        Dim newSQ As New SQLcon

        Try
            Dim c As New class_query

            'LOOP THE PARAMETER GIVEN INTO class_query parameter
            c.cParameters = cDict
            c.addParameters()

            Dim reader As SqlDataReader = c.sql_data(cStoredProcedure, SQ.connection)

            While reader.Read
                Dim _eus As New PropsFields.eus_data_fields
                With _eus

                    Select Case cWhatColumn
                        Case cColumn.forEu_Project_DateFrom_DateTo

                            .equip_category = reader.Item("equipType").ToString

                        Case cColumn.forActive_Projects

                            'fields here

                    End Select


                    _get_eu.Add(_eus)
                End With

            End While

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        Finally
            SQ.connection.Close()
        End Try
    End Function

#End Region

#Region "PROJECTS"
    Public Function _getProjects() As List(Of PropsFields.project_maintenance_fields)
        _getProjects = New List(Of PropsFields.project_maintenance_fields)

        Dim SQ As New SQLcon
        Dim newSQ As New SQLcon

        Try
            Dim c As New class_query

            'LOOP THE PARAMETER GIVEN INTO class_query parameter
            c.cParameters = cDict
            c.addParameters()

            Dim reader As SqlDataReader = c.sql_data(cStoredProcedure, SQ.connection1)

            While reader.Read
                Dim _projects As New PropsFields.project_maintenance_fields
                With _projects

                    Select Case cWhatColumn

                        Case cColumn.forActive_Projects

                            'fields here
                            Dim duration As Double
                            Dim cDatefrom As DateTime = DateConverter(reader.Item("datefrom").ToString)
                            Dim cDateto As DateTime = DateConverter(reader.Item("dateto").ToString)
                            Dim cDateCompletion As DateTime = DateConverter(reader.Item("date_completion").ToString)
                            Dim cDateClose As DateTime = IIf(cDateCompletion = Date.Parse("1990-01-01"), cDateCompletion, cDateCompletion.AddMonths(3))

                            duration = cDateto.Subtract(cDatefrom).TotalDays

                            Dim days_left As Double
                            days_left = IIf(cDateClose = Date.Parse("1990-01-01"), 0, FormatNumber(cDateClose.Subtract(Date.Parse(Now)).TotalDays, 2,,, TriState.True))

                            .proj_id = reader.Item("proj_id").ToString
                            .proj_desc = reader.Item("project_desc").ToString
                            .contract_id = reader.Item("Contract_id").ToString
                            .contract_name = reader.Item("contract_name").ToString
                            .datefrom = Format(cDatefrom, "MM/dd/yyyy")
                            .dateto = Format(cDateto, "MM/dd/yyyy")
                            .duration = reader.Item("project_duration").ToString 'duration,
                            .days_left = days_left
                            .date_close = cDateClose
                            .project_engineer = reader.Item("project_engineer").ToString
                            .date_completion = cDateCompletion
                            .dateCloseOpen = reader.Item("set_completion").ToString

                    End Select


                    _getProjects.Add(_projects)
                End With

            End While

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        Finally
            SQ.connection.Close()
        End Try
    End Function
#End Region

#Region "WAREHOUSE ITEM & PROPER NAMES"
    Public Function _getWhItem_ProperNames() As List(Of PropsFields.whItems_properName_fields)
        _getWhItem_ProperNames = New List(Of PropsFields.whItems_properName_fields)

        Dim SQ As New SQLcon
        Dim newSQ As New SQLcon

        Try
            Dim c As New class_query

            'LOOP THE PARAMETER GIVEN INTO class_query parameter
            c.cParameters = cDict
            c.addParameters()

            Dim reader As SqlDataReader = c.sql_data(cStoredProcedure, SQ.connection, 400)

            While reader.Read
                Dim _whProperNames As New PropsFields.whItems_properName_fields
                With _whProperNames

                    Select Case cWhatColumn

                        Case cColumn.forWhItem_ProperNames

                            .wh_pn_id = reader.Item("wh_pn_id").ToString
                            .item_name = reader.Item("item_name").ToString
                            .item_desc = reader.Item("item_desc").ToString
                            .units = reader.Item("units").ToString
                            .type_of_request = reader.Item("type_of_request").ToString
                            .department = reader.Item(NameOf(.department)).ToString
                            .userLog = reader.Item(NameOf(.userLog)).ToString
                            .updateUserLog = reader.Item(NameOf(.updateUserLog)).ToString

                    End Select

                    _getWhItem_ProperNames.Add(_whProperNames)
                End With

            End While

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        Finally
            SQ.connection.Close()
        End Try
    End Function

    Public Function _getWhItems() As List(Of PropsFields.whItems_props_fields)
        _getWhItems = New List(Of PropsFields.whItems_props_fields)

        Dim SQ As New SQLcon
        Dim newSQ As New SQLcon

        Try
            Dim c As New class_query

            'LOOP THE PARAMETER GIVEN INTO class_query parameter
            For Each pair As KeyValuePair(Of String, Object) In cDict
                c.add_parameter(pair.Key, pair.Value)
            Next

            Dim reader As SqlDataReader = c.sql_data(cStoredProcedure, SQ.connection, 400)

            While reader.Read
                Dim _whItems As New PropsFields.whItems_props_fields
                With _whItems

                    Select Case cWhatColumn

                        Case cColumn.forWhItems

                            .wh_pn_id = IIf(reader.Item("wh_pn_id").ToString = "", 0, reader.Item("wh_pn_id").ToString)
                            .wh_id = reader.Item("wh_id").ToString
                            .item_name = reader.Item("whItem").ToString
                            .item_desc = reader.Item("whItemDesc").ToString
                            .classification = reader.Item("whClass").ToString
                            .type_of_item = reader.Item("tor_desc").ToString & " - " & reader.Item("tor_sub_desc").ToString
                            .warehouse_area = reader.Item("wh_area").ToString
                            .specific_loc = reader.Item("whSpecificLoc").ToString
                            .incharge = reader.Item("wh_incharge").ToString
                            .reorder_point = IIf(reader.Item("whReorderPoint").ToString = "", 0, reader.Item("whReorderPoint").ToString)
                            .default_price = IIf(reader.Item("default_price").ToString = "", 0, reader.Item("default_price").ToString)
                            .units = reader.Item("unit").ToString
                            .inout = reader.Item("in_out_desc").ToString
                            .set_det_id = IIf(reader.Item("set_det_id").ToString = "", 0, reader.Item("set_det_id").ToString)
                            .division = reader.Item("division").ToString
                            .Turnover = reader.Item("turnover").ToString
                            .incharge_id = IIf(reader.Item("incharge_id").ToString = "", 0, reader.Item("incharge_id").ToString)
                            .disable = IIf(reader.Item("disable_item").ToString = "", 0, reader.Item("disable_item").ToString)
                            .proper_item_name = reader.Item("proper_item_name").ToString
                            .proper_item_desc = reader.Item("proper_item_desc").ToString
                            .quarry = reader.Item("quarry").ToString
                            .quarry_id = Utilities.ifBlankReplaceToZero(reader.Item("quarry_id").ToString)
                            .wh_area_id = IIf(reader.Item(NameOf(.wh_area_id)).ToString = "", 0, reader.Item(NameOf(.wh_area_id)).ToString)
                            .whArea_category = reader.Item(NameOf(.whArea_category)).ToString
                            .kpi_id = Utilities.ifBlankReplaceToZero(reader.Item(NameOf(.kpi_id)).ToString)
                            .kpi = reader.Item(NameOf(.kpi)).ToString
                            .consolidated_account_id = Utilities.ifBlankReplaceToZero(reader.Item(NameOf(.consolidated_account_id)).ToString)

                    End Select


                    _getWhItems.Add(_whItems)
                End With

            End While

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        Finally
            SQ.connection.Close()
        End Try
    End Function

    Public Function _getWhIncharge() As List(Of PropsFields.incharge_fields)
        _getWhIncharge = New List(Of PropsFields.incharge_fields)

        Dim SQ As New SQLcon
        Dim newSQ As New SQLcon

        Try
            Dim c As New class_query

            'LOOP THE PARAMETER GIVEN INTO class_query parameter
            For Each pair As KeyValuePair(Of String, Object) In cDict
                c.add_parameter(pair.Key, pair.Value)
            Next

            Dim reader As SqlDataReader = c.sql_data(cStoredProcedure, SQ.connection)

            While reader.Read
                Dim _whIncharge As New PropsFields.incharge_fields
                With _whIncharge

                    Select Case cWhatColumn

                        Case cColumn.forWhIncharge

                            .incharge_id = reader.Item("incharge_id").ToString
                            .firstname = reader.Item("fname").ToString
                            .lastname = reader.Item("lname").ToString

                    End Select


                    _getWhIncharge.Add(_whIncharge)
                End With

            End While

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        Finally
            SQ.connection.Close()
        End Try
    End Function

    Public Function _getAggregatesPrices() As List(Of PropsFields.aggregatesPrices_props_fields)
        _getAggregatesPrices = New List(Of PropsFields.aggregatesPrices_props_fields)

        Dim SQ As New SQLcon
        Dim newSQ As New SQLcon

        Try
            Dim c As New class_query

            'LOOP THE PARAMETER GIVEN INTO class_query parameter
            c.cParameters = cDict
            c.addParameters()

            Dim reader As SqlDataReader = c.sql_data(cStoredProcedure, SQ.connection, 400)

            While reader.Read
                Dim _aggregatesPrices As New PropsFields.aggregatesPrices_props_fields
                With _aggregatesPrices

                    Select Case cWhatColumn

                        Case cColumn.forAggPrices

                            .aggPricingId = reader.Item(NameOf(.aggPricingId)).ToString
                            .wh_id = reader.Item(NameOf(.wh_id)).ToString
                            .zoning_price = reader.Item(NameOf(.zoning_price)).ToString
                            .zoning_area_category = reader.Item(NameOf(.zoning_area_category)).ToString
                            .zoning_area_id = Utilities.ifBlankReplaceToZero(reader.Item(NameOf(.zoning_area_id)).ToString)
                            .zoning_source_category = reader.Item(NameOf(.zoning_source_category)).ToString
                            .zoning_source_id = Utilities.ifBlankReplaceToZero(reader.Item(NameOf(.zoning_source_id)).ToString)

                    End Select


                    _getAggregatesPrices.Add(_aggregatesPrices)
                End With

            End While

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        Finally
            SQ.connection.Close()
        End Try
    End Function

    Public Function _ListViewDisplay() As List(Of ListViewItem)
        _ListViewDisplay = New List(Of ListViewItem)

        Dim data = From Wh_Item In FWarehouseItems.cResult
                   Group Join Incharge In FWarehouseItems.cResult2 On Wh_Item.incharge_id Equals Incharge.incharge_id Into WhItem_InchargeGroup = Group
                   From final In WhItem_InchargeGroup.DefaultIfEmpty()
                   Select
                     Wh_Item.wh_id,
                       Wh_Item.item_name,
                       Wh_Item.item_desc,
                       Wh_Item.classification,
                       Wh_Item.type_of_item,
                       Wh_Item.warehouse_area,
                       Wh_Item.specific_loc,
                       Wh_Item.incharge,
                       Wh_Item.reorder_point,
                       Wh_Item.default_price,
                       Wh_Item.units,
                       Wh_Item.inout,
                       Wh_Item.set_det_id,
                       Wh_Item.division,
                       Wh_Item.Turnover,
                       final?.firstname,
                       final?.lastname,
                       Wh_Item.incharge_id,
                       Wh_Item.disable,
                       Wh_Item.proper_item_name,
                       Wh_Item.proper_item_desc,
                       Wh_Item.wh_pn_id

        Dim a(15) As String


        For Each row In Results.cResult

            a(0) = row.wh_id
            a(1) = row.item_name
            a(2) = $"{row.item_desc}"
            a(3) = row.classification '$"{row.lastname}, {row.firstname}"
            a(4) = row.type_of_item
            a(5) = row.warehouse_area
            a(6) = row.specific_loc
            a(7) = "" 'IIf(row.incharge_id = 0, $"({row.incharge})", $"{row.lastname}, {row.firstname}")
            a(8) = row.reorder_point
            a(9) = row.default_price
            a(10) = row.units
            a(11) = row.inout
            a(12) = row.set_det_id
            a(13) = row.division
            a(14) = row.Turnover
            a(15) = row.disable

            Dim lvl As New ListViewItem(a)

            If row.disable = 1 Then
                lvl.BackColor = ColorTranslator.FromHtml("#D4836D")
                lvl.ForeColor = Color.White
            End If

            'lvlItemList.Items.Add(lvl)
            _ListViewDisplay.Add(lvl)

            'continuehere2:

        Next

    End Function

#End Region

#Region "WAREHOUSE/STOCKPILE AREA"
    Public Function _getWhArea_StockPileArea() As List(Of PropsFields.whArea_stockpile_props_fields)
        _getWhArea_StockPileArea = New List(Of PropsFields.whArea_stockpile_props_fields)

        Dim SQ As New SQLcon
        Dim newSQ As New SQLcon

        Try
            Dim c As New class_query

            'LOOP THE PARAMETER GIVEN INTO class_query parameter
            c.cParameters = cDict
            c.addParameters()

            Dim reader As SqlDataReader = c.sql_data(cStoredProcedure, SQ.connection)

            While reader.Read
                Dim _whAreaStockpile As New PropsFields.whArea_stockpile_props_fields
                With _whAreaStockpile

                    Select Case cWhatColumn

                        Case cColumn.forWareHouseStockpileArea

                            .wh_area_id = reader.Item("wh_area_id").ToString
                            .wh_area = reader.Item("wh_area").ToString
                            .wh_incharge = reader.Item("wh_incharge").ToString
                            .wh_location = reader.Item("wh_location").ToString
                            .wh_options = reader.Item("wh_options").ToString
                            .wh_area_proper_name = Utilities.ifNothingReplaceToBlank(reader.Item(NameOf(.wh_area_proper_name)).ToString)

                    End Select


                    _getWhArea_StockPileArea.Add(_whAreaStockpile)
                End With

            End While

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        Finally
            SQ.connection.Close()
        End Try
    End Function

    Public Function _getAll_WhIncharge() As List(Of PropsFields.inchargeNew_fields)
        _getAll_WhIncharge = New List(Of PropsFields.inchargeNew_fields)

        Dim SQ As New SQLcon
        Dim newSQ As New SQLcon

        Try
            Dim c As New class_query

            'LOOP THE PARAMETER GIVEN INTO class_query parameter
            For Each pair As KeyValuePair(Of String, Object) In cDict
                c.add_parameter(pair.Key, pair.Value)
            Next

            Dim reader As SqlDataReader = c.sql_data(cStoredProcedure, SQ.connection)

            While reader.Read
                Dim _inchargeNew As New PropsFields.inchargeNew_fields
                With _inchargeNew

                    Select Case cWhatColumn

                        Case cColumn.forWhInchargeNew

                            .wh_area_incharge_id = reader.Item(NameOf(_inchargeNew.wh_area_incharge_id)).ToString
                            .wh_area = reader.Item(NameOf(_inchargeNew.wh_area)).ToString
                            .whIncharge = reader.Item(NameOf(_inchargeNew.whIncharge)).ToString
                            .wh_area_id = Utilities.ifBlankReplaceToZero(reader.Item(NameOf(_inchargeNew.wh_area_id)).ToString)
                            .incharge_id = reader.Item(NameOf(_inchargeNew.incharge_id)).ToString

                    End Select

                    _getAll_WhIncharge.Add(_inchargeNew)
                End With

            End While

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        Finally
            SQ.connection.Close()
        End Try
    End Function

#End Region

#Region "DR ITEMS"
    Public Function _getDrItems() As List(Of PropsFields.dr_props_fields)
        _getDrItems = New List(Of PropsFields.dr_props_fields)

        Dim NOTAPPLICABLE As String = "N/A"
        Dim stat As String = ""

        Dim SQ As New SQLcon
        Dim newSQ As New SQLcon

        Try
            Dim c As New class_query

            'LOOP THE PARAMETER GIVEN INTO class_query parameter
            c.cParameters = cDict
            c.addParameters()

            Dim reader As SqlDataReader = c.sql_data(cStoredProcedure, SQ.connection, 500)

            While reader.Read
                Dim _drItems As New PropsFields.dr_props_fields
                With _drItems

                    Select Case cWhatColumn

                        Case cColumn.forDrSearch, cColumn.forDrWithoutRsSearch

                            'fields here

                            .dr_item_id = reader.Item("dr_items_id").ToString
                            .rs_no = reader.Item("rs_no").ToString
                            .requestor = reader.Item("requestor").ToString
                            .dr_date = IIf(reader.Item("dr_date").ToString = "", Date.Parse("1990-01-01"), reader.Item("dr_date").ToString)
                            .rs_date = IIf(reader.Item("rs_date").ToString = "", Date.Parse("1990-01-01"), reader.Item("rs_date").ToString)
                            .dr_no = reader.Item("dr_no").ToString
                            .plateno = reader.Item("plate_no").ToString
                            .driver = reader.Item("operator").ToString
                            .inout = reader.Item("IN_OUT").ToString

                            '11/14/24 - issue:
                            'ws: make a condition to filter WS_NO
                            Select Case .inout.ToUpper()
                                Case "IN", "OTHERS"
                                    .ws_no = NOTAPPLICABLE
                                Case "OUT"
                                    If .rs_no.ToUpper = NOTAPPLICABLE Then
                                        .ws_no = NOTAPPLICABLE
                                    Else
                                        .ws_no = reader.Item("ws_no").ToString
                                    End If
                            End Select


                            .rr_no = reader.Item("rr_no").ToString
                            .item_name = reader.Item("item_name").ToString
                            .item_desc = reader.Item("item_desc").ToString
                            .unit = reader.Item("unit").ToString
                            .dr_source = reader.Item("dr_source").ToString
                            .concession_ticket = reader.Item("concession_ticket_no").ToString
                            .dr_qty = Utilities.ifBlankReplaceToZero(reader.Item("qty").ToString)
                            .price = Utilities.ifBlankReplaceToZero(reader.Item("price").ToString)
                            .total_amount = IIf(IsNumeric(reader.Item("total_amount").ToString), reader.Item("total_amount").ToString, 0)
                            .supplier = reader.Item("supplier").ToString
                            .checked_by = reader.Item("check_by").ToString.ToUpper
                            .received_by = reader.Item("received_by").ToString.ToUpper
                            .remarks = reader.Item("remarks").ToString
                            .input_user = reader.Item("users").ToString
                            .rs_id = Utilities.ifBlankReplaceToZero(reader.Item("rs_id").ToString)
                            .po_no = reader.Item("po_no").ToString
                            .dr_option = "WITH DR"
                            .source2 = reader.Item("source").ToString
                            .date_submitted = IIf(IsDate(reader.Item("date_submitted").ToString), reader.Item("date_submitted").ToString, Date.Parse("1990-01-01"))
                            stat = reader.Item("rs_no").ToString
                            .wh_id = Utilities.ifBlankReplaceToZero(reader.Item("wh_id").ToString)
                            .requestor_without_rs = reader.Item("wh_area").ToString
                            .wh_pn_id = Utilities.ifBlankReplaceToZero(reader.Item("wh_pn_id").ToString)
                            .wh_options = reader.Item("wh_options").ToString
                            .quarry = reader.Item("quarry").ToString
                            .dr_date_log = Utilities.DateConverter(reader.Item(NameOf(.dr_date_log)).ToString)
                            .wh_area_id = Utilities.ifBlankReplaceToZero(reader.Item("wh_area_id").ToString)
                            .whArea_category = reader.Item("whArea_category").ToString
                            .category_for_projectsite = reader.Item(NameOf(.category_for_projectsite)).ToString
                            .projectsite_id = Utilities.ifBlankReplaceToZero(reader.Item(NameOf(.projectsite_id)).ToString)
                            .specific_location = reader.Item(NameOf(.specific_location)).ToString
                            .rs_no_orig = reader.Item(NameOf(.rs_no_orig)).ToString
                            .type_of_requestor = reader.Item(NameOf(.type_of_requestor)).ToString
                            .requestor_id = Utilities.ifBlankReplaceToZero(reader.Item(NameOf(.requestor_id)).ToString)

                            Select Case cWhatColumn
                                Case cCol.forDrSearch, cCol.forDrWithoutRsSearch

                                    .dr_info_id = Utilities.ifBlankReplaceToZero(reader("dr_info_id").ToString)
                                    .par_rr_item_id = Utilities.ifBlankReplaceToZero(reader("par_rr_item_id").ToString)

                            End Select
                    End Select


                    _getDrItems.Add(_drItems)
                End With

            End While

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        Finally
            SQ.connection.Close()
        End Try
    End Function

    Public Function _getDrWsItems() As List(Of PropsFields.dr_ws_props_fields)
        _getDrWsItems = New List(Of PropsFields.dr_ws_props_fields)

        Dim NOTAPPLICABLE As String = "N/A"
        Dim stat As String = ""

        Dim SQ As New SQLcon
        Dim newSQ As New SQLcon

        Try
            Dim c As New class_query

            'LOOP THE PARAMETER GIVEN INTO class_query parameter
            For Each pair As KeyValuePair(Of String, Object) In cDict
                c.add_parameter(pair.Key, pair.Value)
            Next

            Dim reader As SqlDataReader = c.sql_data(cStoredProcedure, SQ.connection, 200)

            While reader.Read
                Dim _drWsItems As New PropsFields.dr_ws_props_fields
                With _drWsItems

                    Select Case cWhatColumn

                        Case cColumn.forDrWsSearch

                            'fields here

                            .ws_id = reader.Item("po_det_id").ToString
                            .ws_info_id = reader.Item("po_id").ToString
                            .rs_no = reader.Item("rs_no").ToString
                            .requestor = reader.Item("requestor").ToString
                            .ws_date = reader.Item("ws_date").ToString
                            .rs_date = reader.Item("rs_date").ToString
                            .dr_no = reader.Item("dr_no").ToString
                            .plateno = reader.Item("plate_no").ToString
                            .driver = reader.Item("operator").ToString
                            .po_no = reader.Item("ws_no").ToString
                            .rr_no = reader.Item("rr_no").ToString
                            .item_name = reader.Item("item_name").ToString
                            .item_desc = reader.Item("item_desc").ToString
                            .unit = reader.Item("unit").ToString
                            .ws_source = reader.Item("ws_source").ToString
                            .concession_ticket = reader.Item("concession_ticket").ToString
                            .ws_qty = reader.Item("ws_qty").ToString
                            .price = reader.Item("price").ToString
                            .total_amount = reader.Item("total_amount").ToString
                            .supplier = reader.Item("supplier").ToString
                            .checked_by = reader.Item("checked_by").ToString
                            .approved_by = reader.Item("approved_by").ToString
                            .remarks = reader.Item("remarks").ToString
                            .users = reader.Item("users").ToString
                            .rs_id = reader.Item("rs_id").ToString
                            .inout = reader.Item("IN_OUT").ToString
                            .dr_option = reader.Item("dr_option").ToString
                            .ws_no = reader.Item("ws_no").ToString
                            .withdrawn_by = reader.Item("checked_by").ToString.ToUpper
                            .wh_id = reader.Item("wh_id").ToString
                            .source2 = reader.Item("source2").ToString
                            .wh_pn_id = IIf(reader.Item("wh_pn_id").ToString = "", 0, reader.Item("wh_pn_id").ToString)
                            .quarry = reader.Item("quarry").ToString
                    End Select

                    _getDrWsItems.Add(_drWsItems)
                End With

            End While

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        Finally
            SQ.connection.Close()
        End Try
    End Function

    Public Function _getDrPoItems() As List(Of PropsFields.dr_po_props_fields)
        _getDrPoItems = New List(Of PropsFields.dr_po_props_fields)

        Dim SQ As New SQLcon
        Dim newSQ As New SQLcon

        Try
            Dim c As New class_query

            'LOOP THE PARAMETER GIVEN INTO class_query parameter
            For Each pair As KeyValuePair(Of String, Object) In cDict
                c.add_parameter(pair.Key, pair.Value)
            Next

            Dim reader As SqlDataReader = c.sql_data(cStoredProcedure, SQ.connection, 200)

            While reader.Read
                Dim _drPoItems As New PropsFields.dr_po_props_fields
                With _drPoItems

                    Select Case cWhatColumn

                        Case cColumn.forDrPoSearch

                            'fields here
                            .po_no = reader.Item("po_no").ToString
                            .wh_id = reader.Item("wh_id").ToString
                            .item_name = reader.Item("item_name").ToString
                            .item_desc = reader.Item("item_desc").ToString
                            .rs_id = reader.Item("rs_id").ToString
                            .po_date = Utilities.DateConverter(reader.Item("po_date").ToString)
                            .inout = reader.Item("IN_OUT").ToString
                            .type_of_purchasing = reader.Item("type_of_purchasing").ToString
                            .dr_option = cDrCategory.WITHOUT_DR

                    End Select

                    _getDrPoItems.Add(_drPoItems)
                End With

            End While

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        Finally
            SQ.connection.Close()
        End Try
    End Function

    Public Function _getOperatorDriver() As List(Of PropsFields.operator_driver_props_fields)
        _getOperatorDriver = New List(Of PropsFields.operator_driver_props_fields)

        Dim SQ As New SQLcon
        Dim newSQ As New SQLcon

        Try
            Dim c As New class_query

            'LOOP THE PARAMETER GIVEN INTO class_query parameter
            For Each pair As KeyValuePair(Of String, Object) In cDict
                c.add_parameter(pair.Key, pair.Value)
            Next

            Dim reader As SqlDataReader = c.sql_data(cStoredProcedure, SQ.connection)

            While reader.Read
                Dim _operatorDriver As New PropsFields.operator_driver_props_fields
                With _operatorDriver

                    Select Case cWhatColumn

                        Case cColumn.forOperatorDriver
                            .operator_id = reader.Item("operator_id").ToString
                            .operator_name = reader.Item("operator_name").ToString
                            .position = reader.Item("position").ToString

                    End Select

                    _getOperatorDriver.Add(_operatorDriver)
                End With

            End While

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        Finally
            SQ.connection.Close()
        End Try
    End Function

    Public Function _getSupplier() As List(Of PropsFields.supplier_props_fields)
        _getSupplier = New List(Of PropsFields.supplier_props_fields)

        Dim SQ As New SQLcon
        Dim newSQ As New SQLcon

        Try
            Dim c As New class_query

            'LOOP THE PARAMETER GIVEN INTO class_query parameter
            For Each pair As KeyValuePair(Of String, Object) In cDict
                c.add_parameter(pair.Key, pair.Value)
            Next

            Dim reader As SqlDataReader = c.sql_data(cStoredProcedure, SQ.connection)

            While reader.Read
                Dim _supplier As New PropsFields.supplier_props_fields
                With _supplier

                    Select Case cWhatColumn

                        Case cColumn.forSupplier

                            .supplier_id = reader.Item("Supplier_Id").ToString
                            .supplierName = reader.Item("Supplier_Name").ToString
                            .supplierLocation = reader.Item("Supplier_Location").ToString
                            .terms = reader.Item(NameOf(_supplier.terms)).ToString

                    End Select

                    _getSupplier.Add(_supplier)
                End With

            End While

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        Finally
            SQ.connection.Close()
        End Try
    End Function

    Public Function _getDrForDr() As List(Of PropsFields.dr_for_dr_props_fields)
        _getDrForDr = New List(Of PropsFields.dr_for_dr_props_fields)


        Dim SQ As New SQLcon
        Dim newSQ As New SQLcon

        Try
            Dim c As New class_query

            'LOOP THE PARAMETER GIVEN INTO class_query parameter
            c.cParameters = cDict
            c.addParameters()

            Dim reader As SqlDataReader = c.sql_data(cStoredProcedure, SQ.connection, 500)

            While reader.Read
                Dim _drItems As New PropsFields.dr_for_dr_props_fields
                With _drItems

                    Select Case cWhatColumn

                        Case cColumn.forDrDr

                            .dr_item_id = reader.Item(NameOf(.dr_item_id)).ToString
                            .dr_info_id = reader.Item(NameOf(.dr_info_id)).ToString
                            .rs_id = reader.Item(NameOf(.rs_id)).ToString
                            .dr_no = reader.Item(NameOf(.dr_no)).ToString
                            .ws_no = reader.Item(NameOf(.ws_no)).ToString
                            .dr_date = reader.Item(NameOf(.dr_date)).ToString
                            .dr_qty = reader.Item(NameOf(.dr_qty)).ToString
                            .price = Utilities.ifBlankReplaceToZero(reader.Item(NameOf(.price)).ToString)
                            .remarks = reader.Item(NameOf(.remarks)).ToString
                            .user_id = Utilities.ifBlankReplaceToZero(reader.Item(NameOf(.user_id)).ToString)
                            .date_log = Utilities.DateConverter(reader.Item(NameOf(.date_log)).ToString)
                            .date_submitted = Utilities.DateConverter(reader.Item(NameOf(.date_submitted)).ToString)
                            .wh_id = Utilities.ifBlankReplaceToZero(reader.Item(NameOf(.wh_id)).ToString)
                            .rr_no = reader.Item(NameOf(.rr_no)).ToString
                    End Select

                    _getDrForDr.Add(_drItems)
                End With

            End While

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        Finally
            SQ.connection.Close()

        End Try
    End Function
#Region "EMPLOYEES"
    Public Function _getEmployees() As List(Of PropsFields.employee_props_fields)
        _getEmployees = New List(Of PropsFields.employee_props_fields)

        Dim SQ As New SQLcon
        Dim newSQ As New SQLcon

        Try
            Dim c As New class_query

            'LOOP THE PARAMETER GIVEN INTO class_query parameter
            For Each pair As KeyValuePair(Of String, Object) In cDict
                c.add_parameter(pair.Key, pair.Value)
            Next

            Dim reader As SqlDataReader = c.sql_data(cStoredProcedure, SQ.connection)

            While reader.Read
                Dim _employees As New PropsFields.employee_props_fields
                With _employees

                    Select Case cWhatColumn

                        Case cColumn.forEmployees

                            .person_id = reader.Item("person_id").ToString
                            .employee = reader.Item("Employee").ToString
                            .position = reader.Item("Position").ToString
                            .employee_id = reader.Item(NameOf(.employee_id)).ToString
                    End Select

                    _getEmployees.Add(_employees)
                End With

            End While

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        Finally
            SQ.connection.Close()
        End Try
    End Function

#End Region

#Region "CHARGES INFO"
    Public Function _getChargesInfo() As List(Of PropsFields.charges_info_props_fields)
        _getChargesInfo = New List(Of PropsFields.charges_info_props_fields)

        Dim SQ As New SQLcon
        Dim newSQ As New SQLcon

        Try
            Dim c As New class_query

            'LOOP THE PARAMETER GIVEN INTO class_query parameter
            For Each pair As KeyValuePair(Of String, Object) In cDict
                c.add_parameter(pair.Key, pair.Value)
            Next

            Dim reader As SqlDataReader = c.sql_data(cStoredProcedure, SQ.connection)

            While reader.Read
                Dim _chargesInfo As New PropsFields.charges_info_props_fields
                With _chargesInfo

                    Select Case cWhatColumn

                        Case cColumn.forChargesInfo

                            .charges_id = reader.Item("id").ToString
                            .charges_desc = reader.Item("charges").ToString
                            .category = reader.Item("type_of_charges").ToString


                    End Select

                    _getChargesInfo.Add(_chargesInfo)
                End With

            End While

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        Finally
            SQ.connection.Close()
        End Try
    End Function

#End Region
#End Region

#Region "RS"
    Public Function _getRsId() As List(Of Integer)
        _getRsId = New List(Of Integer)

        Dim SQ As New SQLcon
        Dim newSQ As New SQLcon

        Try
            Dim c As New class_query

            'LOOP THE PARAMETER GIVEN INTO class_query parameter
            c.cParameters = cDict
            c.addParameters()

            Dim reader As SqlDataReader = c.sql_data(cStoredProcedure, SQ.connection)

            While reader.Read
                Dim rs_id As Integer

                Select Case cWhatColumn

                    Case cColumn.forRsIdByWhId

                        rs_id = reader.Item("rs_id").ToString
                End Select

                _getRsId.Add(rs_id)

            End While

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        Finally
            SQ.connection.Close()
        End Try
    End Function
    Public Function _get_mainRs() As List(Of PropsFields.main_rsdata_props_fields)
        _get_mainRs = New List(Of PropsFields.main_rsdata_props_fields)

        Dim SQ As New SQLcon
        Dim newSQ As New SQLcon

        Try
            Dim c As New class_query

            'LOOP THE PARAMETER GIVEN INTO class_query parameter
            c.cParameters = cDict
            c.addParameters()

            Dim reader As SqlDataReader = c.sql_data(cStoredProcedure, SQ.connection)

            While reader.Read
                Dim data As New main_rsdata_props_fields

                Select Case cWhatColumn

                    Case cColumn.forMainRsCRH, cColumn.forMainRsSubCRH2

                        With data
                            .rs_id = reader.Item(NameOf(.rs_id)).ToString
                            .main_rs_qty_id = reader.Item(NameOf(.main_rs_qty_id)).ToString
                            .main_rs_qty = reader.Item(NameOf(.main_rs_qty)).ToString
                            .rs_no = reader.Item(NameOf(.rs_no)).ToString
                            .open_close_qty = Utilities.ifBlankReplaceToZero(reader.Item(NameOf(.open_close_qty)).ToString)
                            'IIf(reader.Item("open_close").ToString = "", 0, reader.Item("open_close").ToString)
                        End With



                    Case cColumn.forMainRsSubCRH
                        With data
                            .main_rs_qty_id = reader.Item(NameOf(.main_rs_qty_id)).ToString
                            .rs_id = Utilities.ifBlankReplaceToZero(reader.Item(NameOf(.rs_id)).ToString)

                        End With

                    Case cColumn.forMainRsCRH2
                        With data
                            .main_rs_qty_id = reader.Item(NameOf(.main_rs_qty_id)).ToString
                            .main_rs_qty = reader.Item(NameOf(.main_rs_qty)).ToString
                            .rs_no = reader.Item(NameOf(.rs_no)).ToString
                            .open_close_qty = Utilities.ifBlankReplaceToZero(reader.Item(NameOf(.open_close_qty)).ToString)
                        End With
                End Select

                _get_mainRs.Add(data)

            End While

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        Finally
            SQ.connection.Close()

        End Try
    End Function

    Public Function _getRSCRH() As List(Of PropsFields.rsdata_props_fields)
        _getRSCRH = New List(Of PropsFields.rsdata_props_fields)

        Dim SQ As New SQLcon
        Dim newSQ As New SQLcon

        Try
            Dim c As New class_query

            'LOOP THE PARAMETER GIVEN INTO class_query parameter
            c.cParameters = cDict
            c.addParameters()

            Dim reader As SqlDataReader = c.sql_data(cStoredProcedure, SQ.connection, 400)

            While reader.Read
                Dim data As New PropsFields.rsdata_props_fields

                Select Case cWhatColumn

                    Case cColumn.forRsCRH
                        With data
                            .rs_id = reader.Item(NameOf(.rs_id)).ToString
                            .rs_date = Utilities.DateConverter(reader.Item(NameOf(.rs_date)).ToString)
                            .date_needed = Utilities.DateConverter(reader.Item(NameOf(.date_needed)).ToString)
                            .rs_no = reader.Item(NameOf(.rs_no)).ToString
                            .wh_id = reader.Item(NameOf(.wh_id)).ToString
                            .rs_items = reader.Item(NameOf(.rs_items)).ToString
                            .inout = reader.Item(NameOf(.inout)).ToString
                            .item_name = reader.Item(NameOf(.item_name)).ToString
                            .item_desc = reader.Item(NameOf(.item_desc)).ToString
                            .wh_location = reader.Item(NameOf(.wh_location)).ToString
                            .charges = reader.Item(NameOf(.charges)).ToString
                            .type_of_purchasing = reader.Item(NameOf(.type_of_purchasing)).ToString
                            .request_type = reader.Item("typeRequest").ToString
                            .process = reader.Item(NameOf(.process)).ToString
                            .rs_qty = reader.Item(NameOf(.rs_qty)).ToString
                            .type_of_request = reader.Item(NameOf(.type_of_request)).ToString
                            .users = reader.Item(NameOf(.users)).ToString
                            .cons_item = reader.Item(NameOf(.cons_item)).ToString
                            .cons_item_desc = reader.Item(NameOf(.cons_item_desc)).ToString
                            .qty_takeoff_desc = reader.Item(NameOf(.qty_takeoff_desc)).ToString
                            .job_order_no = reader.Item(NameOf(.job_order_no)).ToString
                            .unit = reader.Item(NameOf(.unit)).ToString
                            .location = reader.Item(NameOf(.location)).ToString
                            .date_log = Utilities.DateConverter(reader.Item(NameOf(.date_log)).ToString)
                            .type_of_charges = reader.Item(NameOf(.type_of_charges)).ToString
                            .requested_by = reader.Item(NameOf(.requested_by)).ToString
                            .wh_area = reader.Item(NameOf(.wh_area)).ToString
                            .unit2 = reader.Item(NameOf(.unit2)).ToString
                            .source = reader.Item(NameOf(.source)).ToString
                            .purpose = reader.Item(NameOf(.purpose)).ToString
                            .item_checked_log = Utilities.DateConverter(reader.Item(NameOf(.item_checked_log)).ToString)
                            .wh_pn_id = Utilities.ifBlankReplaceToZero(reader.Item("wh_pn_id").ToString)
                        End With

                End Select

                _getRSCRH.Add(data)

            End While

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        Finally
            SQ.connection.Close()
        End Try
    End Function
    Public Function _getRS_forDR() As List(Of PropsFields.rs_for_dr_props_fields)
        _getRS_forDR = New List(Of PropsFields.rs_for_dr_props_fields)

        Dim SQ As New SQLcon
        Dim newSQ As New SQLcon

        Try
            Dim c As New class_query

            'LOOP THE PARAMETER GIVEN INTO class_query parameter
            c.cParameters = cDict
            c.addParameters()

            Dim reader As SqlDataReader = c.sql_data(cStoredProcedure, SQ.connection, 400)

            While reader.Read
                Dim data As New PropsFields.rs_for_dr_props_fields

                Select Case cWhatColumn

                    Case cColumn.forRsDr
                        With data
                            .rs_id = reader.Item(NameOf(.rs_id)).ToString
                            .rs_no = reader.Item(NameOf(.rs_no)).ToString
                            .rs_date = Utilities.DateConverter(reader.Item(NameOf(.rs_date)).ToString)
                            .date_needed = Utilities.DateConverter(reader.Item(NameOf(.date_needed)).ToString)
                            .rs_qty = Utilities.ifBlankReplaceToZero(reader.Item(NameOf(.rs_qty)).ToString)
                            .unit_from_rs = reader.Item(NameOf(.unit_from_rs)).ToString
                            .purpose = reader.Item(NameOf(.purpose)).ToString
                            .inout = reader.Item(NameOf(.inout)).ToString
                            .wh_id = Utilities.ifBlankReplaceToZero(reader.Item(NameOf(.wh_id)).ToString)
                            .type_of_purchasing = reader.Item(NameOf(.type_of_purchasing)).ToString
                            .user_id = Utilities.ifBlankReplaceToZero(reader.Item(NameOf(.user_id)).ToString)
                            .requested_by = reader.Item(NameOf(.requested_by)).ToString
                            .item_checked_log = Utilities.DateConverter(reader.Item(NameOf(.item_checked_log)).ToString)
                            .wh_pn_id = Utilities.ifBlankReplaceToZero(reader.Item(NameOf(.wh_pn_id)).ToString)
                            .process = reader.Item(NameOf(.process)).ToString
                            .type_of_charges = reader.Item(NameOf(.type_of_charges)).ToString
                            .charges_id = Utilities.ifBlankReplaceToZero(reader.Item(NameOf(.charges_id)).ToString)
                            .tor_sub_id = Utilities.ifBlankReplaceToZero(reader.Item(NameOf(.tor_sub_id)).ToString)
                            .tors_ca_id = Utilities.ifBlankReplaceToZero(reader.Item(NameOf(.tors_ca_id)).ToString)
                            .wh_pn_id_for_rs = Utilities.ifBlankReplaceToZero(reader.Item(NameOf(.wh_pn_id_for_rs)).ToString)
                            .date_log = Utilities.DateConverter(reader.Item(NameOf(.date_log)).ToString)
                            .rs_items = reader.Item(NameOf(.rs_items)).ToString
                            .location = reader.Item(NameOf(.location)).ToString
                            .noted_by = reader.Item(NameOf(.noted_by)).ToString
                            .item_checked_user = Utilities.ifBlankReplaceToZero(reader.Item(NameOf(.item_checked_user)).ToString)
                            .whItem = reader.Item(NameOf(.whItem)).ToString
                            .whItemDesc = reader.Item(NameOf(.whItemDesc)).ToString
                            .division = reader.Item(NameOf(.division)).ToString
                            .job_order_no = reader.Item(NameOf(.job_order_no)).ToString
                            .remarks_for_emd = reader.Item(NameOf(.remarks_for_emd)).ToString
                            .amount = ifBlankReplaceToZero(reader.Item(NameOf(.amount))).ToString
                            .price = ifBlankReplaceToZero(reader.Item(NameOf(.price))).ToString
                            .user_id_updated = ifBlankReplaceToZero(reader.Item(NameOf(.user_id_updated)).ToString)
                            .date_log_updated = Utilities.DateConverter(reader.Item(NameOf(.date_log_updated)).ToString)

                        End With

                End Select

                _getRS_forDR.Add(data)

            End While

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        Finally
            SQ.connection.Close()
        End Try
    End Function
#End Region

#Region "PURCHASE ORDER"
    Public Function _getPurchaseOrder() As List(Of PropsFields.purchase_order_props_fields)
        _getPurchaseOrder = New List(Of PropsFields.purchase_order_props_fields)

        Dim SQ As New SQLcon
        Dim newSQ As New SQLcon

        Try
            Dim c As New class_query

            'LOOP THE PARAMETER GIVEN INTO class_query parameter
            c.cParameters = cDict
            c.addParameters()

            Dim reader As SqlDataReader = c.sql_data(cStoredProcedure, SQ.connection, 400)

            While reader.Read
                Dim _po As New PropsFields.purchase_order_props_fields
                With _po

                    Select Case cWhatColumn

                        Case cColumn.forPurchaseOrder

                            .po_det_id = IIf(reader.Item("po_det_id").ToString = "", 0, reader.Item("po_det_id").ToString)
                            .po_no = reader.Item("po_no").ToString
                            .rs_no = reader.Item("rs_no").ToString
                            .po_date = IIf(reader.Item("po_date").ToString = "", "1990-01-01", reader.Item("po_date").ToString)
                            .Supplier_Name = reader.Item("Supplier_Name").ToString
                            .Item_Name = reader.Item("Item_Name").ToString
                            .Item_Desc = reader.Item("Item_desc").ToString
                            .qty = reader.Item("qty").ToString
                            .unit = reader.Item("unit").ToString
                            .unit_price = IIf(reader.Item("unit_price").ToString = "", 0, reader.Item("unit_price").ToString)
                            .total_amount = IIf(reader.Item("total_amount").ToString = "", 0, reader.Item("total_amount").ToString)
                            .instructions = reader.Item("instructions").ToString
                            .address = reader.Item("address").ToString
                            .terms = reader.Item("terms").ToString
                            .charges = reader.Item("charges").ToString
                            .date_needed = IIf(reader.Item("date_needed").ToString = "", "1990-01-01", reader.Item("date_needed").ToString)
                            .prepared_by = reader.Item("prepared_by").ToString
                            .checked_by = reader.Item("checked_by").ToString
                            .approved_by = reader.Item("approved_by").ToString
                            .rs_id = IIf(reader.Item("rs_id").ToString = "", 0, reader.Item("rs_id").ToString)
                            .selected = reader.Item("selected").ToString
                            .po_id = IIf(reader.Item("po_id").ToString = "", 0, reader.Item("po_id").ToString)
                            .inout = reader.Item("IN_OUT").ToString
                            .print_stats = reader.Item("print_stats").ToString
                            .orig_date_printed = IIf(reader.Item("print_date_logss").ToString = "", "1990-01-01", reader.Item("print_date_logss").ToString)
                            .updated_date_printed = IIf(reader.Item("print_date_update").ToString = "", "1990-01-01", reader.Item("print_date_update").ToString)
                            .user_logs = reader.Item("userss").ToString
                            .lead_time_rs_to_po = IIf(reader.Item("lead_time_rs_to_po").ToString = "", 0, reader.Item("lead_time_rs_to_po").ToString)

                            .rs_date = IIf(reader.Item("date_req").ToString = "", "1990-01-01", reader.Item("date_req").ToString)                        'DATE_REQ TO RS DATE FROM STORED BY MAKI
                            .type_of_request = reader.Item("type_of_request").ToString 'new added column (02/05/24) - king
                            .user_update_log = reader.Item("user_update_log").ToString
                            .requestor = reader.Item("requestor").ToString
                            .cancel_po = IIf(reader.Item("cancel_status").ToString = "", 0, reader.Item("cancel_status").ToString)
                            .wh_pn_id = IIf(reader.Item("wh_pn_id").ToString = "", 0, reader.Item("wh_pn_id").ToString)

                    End Select

                    _getPurchaseOrder.Add(_po)
                End With

            End While

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        Finally
            SQ.connection.Close()

        End Try
    End Function

    Public Function _getPurchaseOrderForDR() As List(Of PropsFields.po_for_dr_props_fields)
        _getPurchaseOrderForDR = New List(Of PropsFields.po_for_dr_props_fields)

        Dim SQ As New SQLcon
        Dim newSQ As New SQLcon

        Try
            Dim c As New class_query

            'LOOP THE PARAMETER GIVEN INTO class_query parameter
            c.cParameters = cDict
            c.addParameters()

            Dim reader As SqlDataReader = c.sql_data(cStoredProcedure, SQ.connection, 400)

            While reader.Read
                Dim _po As New PropsFields.po_for_dr_props_fields
                With _po

                    Select Case cWhatColumn

                        Case cColumn.forPoDr

                            .po_det_id = reader.Item(NameOf(.po_det_id)).ToString
                            .rs_id = reader.Item(NameOf(.rs_id)).ToString
                            .po_qty = reader.Item(NameOf(.po_qty)).ToString
                            .po_no = reader.Item(NameOf(.po_no)).ToString
                            .remarks = reader.Item(NameOf(.remarks)).ToString
                            .user_id = Utilities.ifBlankReplaceToZero(reader.Item(NameOf(.user_id)).ToString)
                            .dr_option = reader.Item(NameOf(.dr_option)).ToString
                            .user_id_logs = Utilities.ifBlankReplaceToZero(reader.Item(NameOf(.user_id_logs)).ToString)
                            .user_id_update_logs = Utilities.ifBlankReplaceToZero(reader.Item(NameOf(.user_id_update_logs)).ToString)
                            .date_log = Utilities.DateConverter(reader.Item(NameOf(.date_log)).ToString)
                            .date_log_updated = Utilities.DateConverter(reader.Item(NameOf(.date_log_updated)).ToString)
                            .tax_category = reader.Item(NameOf(.tax_category)).ToString
                            .vat_value = reader.Item(NameOf(.vat_value)).ToString
                            .unit_price = Utilities.ifBlankReplaceToZero(reader.Item(NameOf(.unit_price)).ToString)
                            .po_date = Utilities.DateConverter(reader.Item(NameOf(.po_date)).ToString)
                            .supplier_id = Utilities.ifBlankReplaceToZero(reader.Item(NameOf(.supplier_id)).ToString)
                            .po_cancel_status = Utilities.ifBlankReplaceToZero(reader.Item("cancel_status").ToString)
                            .units = reader.Item(NameOf(.units)).ToString
                    End Select

                    _getPurchaseOrderForDR.Add(_po)
                End With

            End While

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        Finally
            SQ.connection.Close()
        End Try
    End Function
#End Region

#Region "WITHDRAWAL"
    Public Function _getWithdrawal() As List(Of PropsFields.withdrawal_props_fields)
        _getWithdrawal = New List(Of PropsFields.withdrawal_props_fields)

        Dim SQ As New SQLcon

        Try
            Dim c As New class_query

            'LOOP THE PARAMETER GIVEN INTO class_query parameter
            c.cParameters = cDict
            c.addParameters()

            Dim reader As SqlDataReader = c.sql_data(cStoredProcedure, SQ.connection, 400)

            While reader.Read

                Select Case cWhatColumn

                    Case cColumn.forWithdrawal
                        Dim _ws As New PropsFields.withdrawal_props_fields
                        With _ws

                            .ws_id = reader.Item("ws_id").ToString
                            .ws_no = reader.Item("ws_no").ToString
                            .rs_no = reader.Item("rs_no").ToString
                            .ws_date = Utilities.DateConverter(reader.Item("ws_date").ToString)
                            .item_name = reader.Item("item_name").ToString
                            .item_desc = reader.Item("item_desc").ToString
                            .rs_qty = Utilities.ifBlankReplaceToZero(reader.Item("rs_qty").ToString)
                            .ws_qty = Utilities.ifBlankReplaceToZero(reader.Item("ws_qty").ToString)
                            .qty_withdrawn = IIf(reader.Item("qty_withdrawn").ToString = "", 0, reader.Item("qty_withdrawn").ToString)
                            .unit = reader.Item("unit").ToString
                            .unit_price = Utilities.ifBlankReplaceToZero(reader.Item("unit_price").ToString)
                            .amount = Utilities.ifBlankReplaceToZero(reader.Item("amount").ToString)
                            .withdrawn_from = reader.Item("withdrawn_from").ToString
                            .withdrawn_by = reader.Item("withdrawn_by").ToString
                            .released_by = reader.Item("released_by").ToString
                            .charges = reader.Item("charges").ToString
                            .ws_info_id = reader.Item("ws_info_id").ToString
                            .rs_id = reader.Item("rs_id").ToString
                            .wh_id = reader.Item("wh_id").ToString
                            .remarks = reader.Item("remarks").ToString
                            .dr_option = reader.Item("dr_option").ToString
                            .purpose = reader.Item("purpose").ToString
                            .withdrawn_id = IIf(reader.Item("withdrawn_id").ToString = "", 0, reader.Item("withdrawn_id").ToString)
                            .status = reader.Item("stat").ToString
                            .wh_pn_id = IIf(reader.Item("wh_pn_id").ToString = "", 0, reader.Item("wh_pn_id").ToString)
                            .withdrawn_status = reader.Item(NameOf(.withdrawn_status)).ToString
                            .date_needed = Utilities.DateConverter(reader.Item(NameOf(.date_needed)).ToString)
                            .issued_by = reader.Item(NameOf(.issued_by)).ToString
                            .users = reader.Item(NameOf(.users)).ToString
                            .ws_date_log = Utilities.DateConverter(reader.Item(NameOf(.ws_date_log)).ToString)
                            .serial_id = Utilities.ifBlankReplaceToZero(reader.Item(NameOf(.serial_id)).ToString)
                            .division = reader.Item(NameOf(.division)).ToString
                            .tire_category = reader.Item(NameOf(.tire_category)).ToString

                            _getWithdrawal.Add(_ws)
                        End With

                    Case cColumn.forWithdrawalPrice
                        Dim _ws As New PropsFields.withdrawal_props_fields
                        With _ws
                            .item_name = reader.Item(NameOf(.item_name)).ToString
                            .item_desc = reader.Item(NameOf(.item_desc)).ToString
                            .unit_price = reader.Item(NameOf(.unit_price)).ToString
                            .wh_id = Utilities.ifBlankReplaceToZero(reader.Item(NameOf(.wh_id)).ToString)

                            _getWithdrawal.Add(_ws)
                        End With

                End Select

            End While

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        Finally
            SQ.connection.Close()


        End Try
    End Function

    Public Function _getWithdrawnItems() As List(Of PropsFields.withdrawn_props_fields)
        _getWithdrawnItems = New List(Of PropsFields.withdrawn_props_fields)

        Dim SQ As New SQLcon
        Dim newSQ As New SQLcon

        Try
            Dim c As New class_query

            'LOOP THE PARAMETER GIVEN INTO class_query parameter
            c.cParameters = cDict
            c.addParameters()

            Dim reader As SqlDataReader = c.sql_data(cStoredProcedure, SQ.connection, 400)

            While reader.Read

                Select Case cWhatColumn

                    Case cColumn.forWithdrawn
                        Dim _ws As New PropsFields.withdrawn_props_fields
                        With _ws
                            .withdrawn_id = reader.Item(NameOf(_ws.withdrawn_id)).ToString
                            .rs_id = reader.Item(NameOf(_ws.rs_id)).ToString
                            .ws_id = reader.Item(NameOf(_ws.ws_id)).ToString
                            .date_log_withdrawn = DateConverter(reader.Item(NameOf(_ws.date_log_withdrawn)).ToString)
                            .date_withdrawn = DateConverter(reader.Item(NameOf(_ws.date_withdrawn)).ToString)
                            .status = reader.Item(NameOf(_ws.status)).ToString

                        End With

                        _getWithdrawnItems.Add(_ws)
                End Select

            End While

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        Finally
            SQ.connection.Close()
        End Try
    End Function

    Public Function _getPartiallyWithdrawnItems() As List(Of PropsFields.partiallyWithdrawn_props_fields)
        _getPartiallyWithdrawnItems = New List(Of PropsFields.partiallyWithdrawn_props_fields)

        Dim SQ As New SQLcon
        Dim newSQ As New SQLcon

        Try
            Dim c As New class_query

            'LOOP THE PARAMETER GIVEN INTO class_query parameter
            c.cParameters = cDict
            c.addParameters()

            Dim reader As SqlDataReader = c.sql_data(cStoredProcedure, SQ.connection, 0)

            While reader.Read

                Select Case cWhatColumn

                    Case cColumn.forPartiallyWithdrawn
                        Dim _ws As New PropsFields.partiallyWithdrawn_props_fields
                        With _ws
                            .partially_withdrawn_id = reader.Item(NameOf(_ws.partially_withdrawn_id).ToString)
                            .withdrawn_id = reader.Item(NameOf(_ws.withdrawn_id)).ToString
                            .partially_withdrawn_qty = reader.Item(NameOf(_ws.partially_withdrawn_qty)).ToString
                            .released_by = reader.Item(NameOf(_ws.released_by)).ToString
                            .received_by = reader.Item(NameOf(_ws.received_by)).ToString
                            .user_id = reader.Item(NameOf(_ws.user_id)).ToString
                            .dateLog = DateConverter(reader.Item(NameOf(_ws.dateLog)).ToString)
                            .date_partially_withdrawn = DateConverter(reader.Item(NameOf(_ws.date_partially_withdrawn)).ToString)
                            .status = reader.Item(NameOf(_ws.status)).ToString()
                            .users = reader.Item(NameOf(.users)).ToString()
                            .units = reader.Item(NameOf(.units)).ToString()
                            .serial_id = Utilities.ifBlankReplaceToZero(reader.Item(NameOf(.serial_id)).ToString)
                        End With

                        _getPartiallyWithdrawnItems.Add(_ws)

                End Select

            End While

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        Finally
            SQ.connection.Close()
        End Try
    End Function

    Public Function _getPartiallyReleasedWithdrawnItems() As List(Of PropsFields.partiallyReleasedWithdrawal_props_fields)
        _getPartiallyReleasedWithdrawnItems = New List(Of PropsFields.partiallyReleasedWithdrawal_props_fields)

        Dim SQ As New SQLcon
        Dim newSQ As New SQLcon

        Try
            Dim c As New class_query

            'LOOP THE PARAMETER GIVEN INTO class_query parameter
            c.cParameters = cDict
            c.addParameters()

            Dim reader As SqlDataReader = c.sql_data(cStoredProcedure, SQ.connection, 0)

            While reader.Read

                Select Case cWhatColumn

                    Case cColumn.forPartiallyReleasedWithdrawal
                        Dim _ws As New PropsFields.partiallyReleasedWithdrawal_props_fields
                        With _ws
                            .partially_withdrawn_id = reader.Item(NameOf(_ws.partially_withdrawn_id).ToString)
                            .withdrawn_id = ifBlankReplaceToZero(reader.Item(NameOf(_ws.withdrawn_id)).ToString)
                            .partially_withdrawn_qty = ifBlankReplaceToZero(reader.Item(NameOf(_ws.partially_withdrawn_qty)).ToString)
                            .released_by = reader.Item(NameOf(_ws.released_by)).ToString
                            .received_by = reader.Item(NameOf(_ws.received_by)).ToString
                            .user_id = ifBlankReplaceToZero(reader.Item(NameOf(_ws.user_id)).ToString)
                            .dateLog = DateConverter(reader.Item(NameOf(_ws.dateLog)).ToString)
                            .partiallyWithdrawnDate = DateConverter(reader.Item(NameOf(_ws.partiallyWithdrawnDate)).ToString)
                            .status = reader.Item(NameOf(_ws.status)).ToString()
                            .deleted_status = reader.Item(NameOf(_ws.deleted_status)).ToString()
                            .rs_id = ifBlankReplaceToZero(reader.Item(NameOf(_ws.rs_id)).ToString())
                            .ws_id = ifBlankReplaceToZero(reader.Item(NameOf(_ws.ws_id)).ToString())
                            .dateLogWithdrawn = DateConverter(reader.Item(NameOf(_ws.dateLogWithdrawn)).ToString)
                            .dateWithdrawn = DateConverter(reader.Item(NameOf(_ws.dateWithdrawn)).ToString)
                            .status = reader.Item(NameOf(_ws.status)).ToString()

                            _getPartiallyReleasedWithdrawnItems.Add(_ws)

                        End With
                End Select

            End While

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        Finally
            SQ.connection.Close()
        End Try
    End Function

    Public Function _getWithdrawalForDR() As List(Of PropsFields.ws_for_dr_props_fields)
        _getWithdrawalForDR = New List(Of PropsFields.ws_for_dr_props_fields)

        Dim SQ As New SQLcon

        Try
            Dim c As New class_query

            'LOOP THE PARAMETER GIVEN INTO class_query parameter
            c.cParameters = cDict
            c.addParameters()

            Dim reader As SqlDataReader = c.sql_data(cStoredProcedure, SQ.connection, 400)

            While reader.Read

                Select Case cWhatColumn

                    Case cColumn.forWsDr
                        Dim _ws As New PropsFields.ws_for_dr_props_fields
                        With _ws

                            .ws_id = reader.Item(NameOf(.ws_id)).ToString
                            .rs_id = reader.Item(NameOf(.rs_id)).ToString
                            .ws_qty = reader.Item(NameOf(.ws_qty)).ToString
                            .isQtyWithdrawn = Utilities.ifBlankReplaceToZero(reader.Item(NameOf(.isQtyWithdrawn)).ToString)
                            .ws_no = reader.Item(NameOf(.ws_no)).ToString
                            .remarks = reader.Item(NameOf(.remarks)).ToString
                            .user_id = Utilities.ifBlankReplaceToZero(reader.Item(NameOf(.user_id)).ToString)
                            .dr_option = reader.Item(NameOf(.dr_option)).ToString
                            .user_id_logs = Utilities.ifBlankReplaceToZero(reader.Item(NameOf(.user_id_logs)).ToString)
                            .user_id_update_logs = Utilities.ifBlankReplaceToZero(reader.Item(NameOf(.user_id_update_logs)).ToString)
                            .date_log = Utilities.DateConverter(reader.Item(NameOf(.date_log)).ToString)
                            .date_log_updated = Utilities.DateConverter(reader.Item(NameOf(.date_log_updated)).ToString)
                            .ws_date = Utilities.DateConverter(reader.Item(NameOf(.ws_date)).ToString)
                            .price = Utilities.ifBlankReplaceToZero(reader.Item(NameOf(.price)).ToString)

                            _getWithdrawalForDR.Add(_ws)
                        End With

                End Select

            End While

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        Finally
            SQ.connection.Close()
        End Try
    End Function

#End Region

#Region "RECEIVING"
    Public Function _getReceiving() As List(Of PropsFields.receiving_props_fields)
        _getReceiving = New List(Of PropsFields.receiving_props_fields)

        Dim SQ As New SQLcon
        Dim newSQ As New SQLcon

        Try
            Dim c As New class_query

            'LOOP THE PARAMETER GIVEN INTO class_query parameter
            c.cParameters = cDict
            c.addParameters()

            Dim reader As SqlDataReader = c.sql_data(cStoredProcedure, SQ.connection)

            While reader.Read
                Dim _rr As New PropsFields.receiving_props_fields
                With _rr

                    Select Case cWhatColumn

                        Case cColumn.forReceiving

                            .rr_item_id = reader.Item("rr_item_id").ToString
                            .rr_info_id = IIf(reader.Item("rr_info_id").ToString = "", 0, reader.Item("rr_info_id").ToString)
                            .rs_id = reader.Item("rs_id").ToString
                            .rr_no = reader.Item("rr_no").ToString
                            .po_det_id = IIf(reader.Item("po_det_id").ToString = "", 0, reader.Item("po_det_id").ToString)
                            .rs_no = reader.Item("rs_no").ToString
                            .invoice_no = reader.Item("invoice_no").ToString
                            .supplier = reader.Item("supplier").ToString
                            .date_received = IIf(reader.Item("date_received").ToString = "", Date.Parse("1990-01-01").ToString, reader.Item("date_received").ToString)
                            .rr_qty = reader.Item("rr_qty").ToString
                            .price = reader.Item("price").ToString
                            .item_desc = reader.Item("item_description").ToString
                            .charges = reader.Item("CHARGES").ToString
                            .remarks = reader.Item("remarks").ToString
                            .wh_id = IIf(reader.Item("wh_id").ToString = "", 0, reader.Item("wh_id").ToString)
                            .type_of_purchasing = reader.Item("type_of_purchasing").ToString
                            .checked_by = reader.Item("checked_by").ToString
                            .received_by = reader.Item("received_by").ToString
                            .unit = reader.Item("unit").ToString
                            .date_submitted = IIf(reader.Item("date_submitted").ToString = "", Date.Parse("1990-01-01"), reader.Item("date_submitted").ToString)
                            .wh_pn_id = IIf(reader.Item("wh_pn_id").ToString = "", 0, reader.Item("wh_pn_id").ToString)

                        Case cColumn.forRrDr

                            .rr_item_id = Utilities.ifBlankReplaceToZero(reader.Item(NameOf(.rr_item_id)).ToString)
                            .rr_info_id = Utilities.ifBlankReplaceToZero(reader.Item(NameOf(.rr_info_id)).ToString)
                            .rr_no = reader.Item(NameOf(.rr_no)).ToString
                            .rr_qty = Utilities.ifBlankReplaceToZero(reader.Item(NameOf(.rr_qty)).ToString)
                            .price = reader.Item(NameOf(.price)).ToString
                            .date_received = Utilities.DateConverter(reader.Item(NameOf(.date_received)).ToString)
                            .date_log = Utilities.DateConverter(reader.Item(NameOf(.date_log)).ToString)
                            .rr_no = reader.Item(NameOf(.rr_no)).ToString
                            .po_det_id = Utilities.ifBlankReplaceToZero(reader.Item(NameOf(.po_det_id)).ToString)
                            .rs_id = reader.Item(NameOf(.rs_id)).ToString
                            .supplier = reader.Item(NameOf(.supplier)).ToString
                            .rr_item_desc = reader.Item(NameOf(.rr_item_desc)).ToString
                            .unit = reader.Item(NameOf(.unit)).ToString
                            .price = reader.Item(NameOf(.price)).ToString
                            .updatedAt = Utilities.DateConverter(reader.Item(NameOf(.updatedAt)).ToString)
                            .updatedById = Utilities.ifBlankReplaceToZero(reader.Item(NameOf(.updatedById)).ToString)
                            .user_id = Utilities.ifBlankReplaceToZero(reader.Item(NameOf(.user_id)).ToString)

                        Case cColumn.forRrWithDetails

                            .rr_item_id = Utilities.ifBlankReplaceToZero(reader.Item(NameOf(.rr_item_id)).ToString)
                            .rr_info_id = Utilities.ifBlankReplaceToZero(reader.Item(NameOf(.rr_info_id)).ToString)
                            .rr_no = reader.Item(NameOf(.rr_no)).ToString
                            .rr_qty = Utilities.ifBlankReplaceToZero(reader.Item(NameOf(.rr_qty)).ToString)
                            .price = reader.Item(NameOf(.price)).ToString
                            .date_received = Utilities.DateConverter(reader.Item(NameOf(.date_received)).ToString)
                            .date_log = Utilities.DateConverter(reader.Item(NameOf(.date_log)).ToString)
                            .rr_no = reader.Item(NameOf(.rr_no)).ToString
                            .po_det_id = reader.Item(NameOf(.po_det_id)).ToString
                            .rs_id = reader.Item(NameOf(.rs_id)).ToString
                            .supplier = reader.Item(NameOf(.supplier)).ToString
                            .invoice_no = reader.Item(NameOf(.invoice_no)).ToString
                            .remarks = reader.Item(NameOf(.remarks)).ToString
                            .date_submitted = Utilities.DateConverter(reader.Item(NameOf(.date_submitted)).ToString)
                            .serial_id = Utilities.ifBlankReplaceToZero(reader.Item(NameOf(.serial_id)).ToString)
                            .checked_by = reader.Item(NameOf(.checked_by)).ToString
                            .received_by = reader.Item(NameOf(.received_by)).ToString
                            .plateNo = reader.Item(NameOf(.plateNo)).ToString
                            .soNo = reader.Item(NameOf(.soNo)).ToString
                            .unit = reader.Item(NameOf(.unit)).ToString
                            .driver = reader.Item(NameOf(.driver)).ToString
                            .source = reader.Item(NameOf(.source)).ToString
                            .rr_item_desc = reader.Item(NameOf(.rr_item_desc)).ToString
                            .rr_item_sub_id = Utilities.ifBlankReplaceToZero(reader.Item(NameOf(.rr_item_sub_id)).ToString)
                            .updatedAt = Utilities.DateConverter(reader.Item(NameOf(.updatedAt)).ToString)
                            .updatedById = Utilities.ifBlankReplaceToZero(reader.Item(NameOf(.updatedById)).ToString)
                            .user_id = Utilities.ifBlankReplaceToZero(reader.Item(NameOf(.user_id)).ToString)
                    End Select

                    _getReceiving.Add(_rr)
                End With

            End While

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        Finally
            SQ.connection.Close()

        End Try
    End Function

#End Region

#Region "REQUISITION"
    Public Function _getRs() As List(Of PropsFields.rs_props_fields)
        _getRs = New List(Of PropsFields.rs_props_fields)

        Dim SQ As New SQLcon
        Dim newSQ As New SQLcon

        Try
            Dim c As New class_query

            'LOOP THE PARAMETER GIVEN INTO class_query parameter
            c.cParameters = cDict
            c.addParameters()

            Dim reader As SqlDataReader = c.sql_data(cStoredProcedure, SQ.connection)

            While reader.Read
                Dim _rs As New PropsFields.rs_props_fields
                With _rs

                    Select Case cWhatColumn

                        Case cColumn.forRequisition

                            .rs_id = reader.Item("rs_id").ToString
                            .rs_date = DateConverter(reader.Item("rs_date").ToString)
                            .date_needed = DateConverter(reader.Item("date_needed").ToString)
                            .rs_no = reader.Item("rs_no").ToString
                            .wh_id = reader.Item("wh_id").ToString
                            .rs_items = reader.Item("rs_items").ToString
                            .inout = reader.Item("inout").ToString
                            .item_name = reader.Item("item_name").ToString
                            .item_desc = reader.Item("item_desc").ToString
                            .wh_location = reader.Item("wh_location").ToString
                            .charges = reader.Item("charges").ToString
                            .type_of_purchasing = reader.Item("type_of_purchasing").ToString
                            .request_type = reader.Item("typeRequest").ToString
                            .process = reader.Item("process").ToString
                            .rs_qty = reader.Item("rs_qty").ToString
                            .type_of_request = reader.Item("type_of_request").ToString
                            .users = reader.Item("users").ToString
                            .cons_item = reader.Item("cons_item").ToString
                            .cons_item_desc = reader.Item("cons_item_desc").ToString
                            .qty_takeoff_desc = reader.Item("qty_takeoff_desc").ToString
                            .job_order_no = reader.Item("job_order_no").ToString
                            .unit = reader.Item("unit").ToString
                            .location = reader.Item("location").ToString
                            .date_log = DateConverter(reader.Item("date_log").ToString)
                            .type_of_charges = reader.Item("type_of_charges").ToString
                            .requested_by = reader.Item("requested_by").ToString
                            .wh_area = reader.Item("wh_area").ToString
                            .unit2 = reader.Item("unit2").ToString
                            .source = reader.Item("source").ToString
                            .purpose = reader.Item("purpose").ToString
                            .item_checked_log = IIf(IsDate(reader.Item("item_checked_log").ToString), reader.Item("item_checked_log").ToString, Date.Parse("1990-01-01"))
                            .wh_pn_id = IIf(reader.Item("wh_pn_id").ToString = "", 0, reader.Item("wh_pn_id").ToString)

                    End Select

                    _getRs.Add(_rs)
                End With

            End While

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        Finally
            SQ.connection.Close()
        End Try
    End Function

#End Region

#Region "HRMS"
    Public Function _getEmployeeData() As List(Of PropsFields.employee_props_fields)
        _getEmployeeData = New List(Of PropsFields.employee_props_fields)

        Dim SQ As New SQLcon
        Dim newSQ As New SQLcon

        Try
            Dim c As New class_query

            'LOOP THE PARAMETER GIVEN INTO class_query parameter
            c.cParameters = cDict
            c.addParameters()

            Dim reader As SqlDataReader = c.sql_data(cStoredProcedure, SQ.connection, 500)

            While reader.Read
                Dim _employees As New PropsFields.employee_props_fields
                With _employees

                    Select Case cWhatColumn

                        Case cColumn.forEmployeeData

                            'fields here
                            .employee_id = reader.Item(NameOf(_employees.employee_id)).ToString
                            .last_name = reader.Item(NameOf(_employees.last_name)).ToString
                            .first_name = reader.Item(NameOf(_employees.first_name)).ToString
                            .middle_name = reader.Item(NameOf(_employees.middle_name)).ToString
                            .ext_name = reader.Item(NameOf(_employees.ext_name)).ToString
                            .designation = reader.Item(NameOf(_employees.designation)).ToString
                            .department = reader.Item(NameOf(_employees.department)).ToString
                            .status_name = reader.Item(NameOf(_employees.status_name)).ToString

                    End Select


                    _getEmployeeData.Add(_employees)
                End With

            End While

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        Finally
            SQ.connection.Close()
        End Try
    End Function
#End Region

#Region "SMS USERS"
    Public Function _getSMSUsers() As List(Of PropsFields.smsUsers_props_fields)
        _getSMSUsers = New List(Of PropsFields.smsUsers_props_fields)

        Dim SQ As New SQLcon
        Dim newSQ As New SQLcon

        Try
            Dim c As New class_query

            c.cParameters = cDict
            c.addParameters()

            Dim reader As SqlDataReader = c.sql_data(cStoredProcedure, SQ.connection, 500)

            While reader.Read
                Dim _smsUsers As New PropsFields.smsUsers_props_fields
                With _smsUsers

                    Select Case cWhatColumn

                        Case cColumn.forSmsUsers

                            'fields here
                            .user_id = reader.Item(NameOf(_smsUsers.user_id)).ToString
                            .fName = reader.Item(NameOf(_smsUsers.fName)).ToString
                            .lName = reader.Item(NameOf(_smsUsers.lName)).ToString
                            .username = reader.Item(NameOf(_smsUsers.username)).ToString
                            .ip_Address = reader.Item(NameOf(_smsUsers.ip_Address)).ToString
                            .restriction = reader.Item(NameOf(_smsUsers.restriction)).ToString
                            .access = reader.Item(NameOf(_smsUsers.access)).ToString
                            .auth = reader.Item(NameOf(_smsUsers.auth)).ToString
                            .password = reader.Item(NameOf(_smsUsers.password)).ToString
                            .employee_id = IIf(reader.Item(NameOf(_smsUsers.employee_id)).ToString = "", 0, reader.Item(NameOf(_smsUsers.employee_id)).ToString)
                    End Select

                    _getSMSUsers.Add(_smsUsers)
                End With

            End While

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        Finally
            SQ.connection.Close()
        End Try
    End Function

#End Region

#Region "EQUIPMENT"
    Public Function getEquipment() As List(Of PropsFields.equipment_props_fields)
        getEquipment = New List(Of PropsFields.equipment_props_fields)

        Dim SQ As New SQLcon
        Dim newSQ As New SQLcon

        Try
            Dim c As New class_query

            c.cParameters = cDict
            c.addParameters()

            Dim reader As SqlDataReader = c.sql_data(cStoredProcedure, SQ.connection, 500)

            While reader.Read
                Dim _equipment As New PropsFields.equipment_props_fields
                With _equipment

                    Select Case cWhatColumn


                    End Select

                    getEquipment.Add(_equipment)
                End With

            End While

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        Finally
            SQ.connection.Close()
        End Try
    End Function
#End Region

#Region "CHARGES"
    Public Function getAllCharges() As List(Of PropsFields.AllCharges)
        getAllCharges = New List(Of PropsFields.AllCharges)

        Dim SQ As New SQLcon
        Dim newSQ As New SQLcon

        Try
            Dim c As New class_query

            c.cParameters = cDict
            c.addParameters()

            Dim reader As SqlDataReader = c.sql_data(cStoredProcedure, SQ.connection, 500)

            While reader.Read
                Dim _allCharges As New PropsFields.AllCharges
                With _allCharges

                    .charges_id = reader.Item("id").ToString
                    .charges = reader.Item("charges").ToString
                    .charges_category = reader.Item("type_of_charges").ToString
                    .specific_location = reader.Item(NameOf(.specific_location)).ToString

                    getAllCharges.Add(_allCharges)

                End With

            End While

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        Finally
            SQ.connection.Close()
        End Try
    End Function

    Public Function getSearchByCharges() As List(Of PropsFields.byCharges)
        getSearchByCharges = New List(Of PropsFields.byCharges)

        Dim SQ As New SQLcon
        Dim newSQ As New SQLcon

        Try
            Dim c As New class_query

            c.cParameters = cDict
            c.addParameters()

            Dim reader As SqlDataReader = c.sql_data(cStoredProcedure, SQ.connection, 500)

            While reader.Read
                Dim _searchByCharges As New PropsFields.byCharges
                With _searchByCharges

                    .rsId = Utilities.ifBlankReplaceToZero(reader.Item(NameOf(_searchByCharges.rsId)).ToString)
                    .rsNo = reader.Item(NameOf(_searchByCharges.rsNo)).ToString
                    .item_desc_from_item_checked = reader.Item(NameOf(_searchByCharges.item_desc_from_item_checked)).ToString
                    .item_desc_from_rs = reader.Item(NameOf(_searchByCharges.item_desc_from_rs)).ToString
                    .qty = Utilities.ifBlankReplaceToZero(reader.Item(NameOf(_searchByCharges.qty)).ToString)
                    .amount = reader.Item(NameOf(_searchByCharges.amount)).ToString
                    .price = Utilities.ifBlankReplaceToZero(reader.Item(NameOf(_searchByCharges.price)).ToString)
                    .rs_date = Utilities.DateConverter(reader.Item(NameOf(_searchByCharges.rs_date)).ToString)
                    .wh_id = Utilities.ifBlankReplaceToZero(reader.Item(NameOf(_searchByCharges.wh_id)).ToString)
                    .type_of_purchasing = reader.Item(NameOf(_searchByCharges.type_of_purchasing)).ToString

                    getSearchByCharges.Add(_searchByCharges)

                End With

            End While

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        Finally
            SQ.connection.Close()
        End Try
    End Function

    Public Function getSearchByRequestedBy() As List(Of PropsFields.byCharges)
        getSearchByRequestedBy = New List(Of PropsFields.byCharges)

        Dim SQ As New SQLcon
        Dim newSQ As New SQLcon

        Try
            Dim c As New class_query

            c.cParameters = cDict
            c.addParameters()

            Dim reader As SqlDataReader = c.sql_data(cStoredProcedure, SQ.connection, 500)

            While reader.Read
                Dim _searchByRequestedBy As New PropsFields.byCharges
                With _searchByRequestedBy

                    Select Case cWhatColumn

                        Case cColumn.forSearchByRequestedBy
                            .rsId = Utilities.ifBlankReplaceToZero(reader.Item(NameOf(_searchByRequestedBy.rsId)).ToString)
                            .rsNo = reader.Item(NameOf(_searchByRequestedBy.rsNo)).ToString
                            .item_desc_from_item_checked = reader.Item(NameOf(_searchByRequestedBy.item_desc_from_item_checked)).ToString
                            .item_desc_from_rs = reader.Item(NameOf(_searchByRequestedBy.item_desc_from_rs)).ToString
                            .qty = Utilities.ifBlankReplaceToZero(reader.Item(NameOf(_searchByRequestedBy.qty)).ToString)
                            .amount = reader.Item(NameOf(_searchByRequestedBy.amount)).ToString
                            .price = Utilities.ifBlankReplaceToZero(reader.Item(NameOf(_searchByRequestedBy.price)).ToString)
                            .rs_date = Utilities.DateConverter(reader.Item(NameOf(_searchByRequestedBy.rs_date)).ToString)
                            .wh_id = Utilities.ifBlankReplaceToZero(reader.Item(NameOf(_searchByRequestedBy.wh_id)).ToString)
                            .type_of_purchasing = reader.Item(NameOf(_searchByRequestedBy.type_of_purchasing)).ToString
                            .requested_by = reader.Item(NameOf(_searchByRequestedBy.requested_by)).ToString

                            getSearchByRequestedBy.Add(_searchByRequestedBy)
                    End Select

                End With

            End While

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        Finally
            SQ.connection.Close()
        End Try
    End Function

    Public Function getSearchByOthers() As List(Of PropsFields.byCharges)
        getSearchByOthers = New List(Of PropsFields.byCharges)

        Dim SQ As New SQLcon
        Dim newSQ As New SQLcon

        Try
            Dim c As New class_query

            c.cParameters = cDict
            c.addParameters()

            Dim reader As SqlDataReader = c.sql_data(cStoredProcedure, SQ.connection, 500)

            While reader.Read
                Dim _searchByCharges As New PropsFields.byCharges
                With _searchByCharges

                    .rsId = Utilities.ifBlankReplaceToZero(reader.Item(NameOf(_searchByCharges.rsId)).ToString)
                    .rsNo = reader.Item(NameOf(_searchByCharges.rsNo)).ToString
                    .item_desc_from_item_checked = reader.Item(NameOf(_searchByCharges.item_desc_from_item_checked)).ToString
                    .item_desc_from_rs = reader.Item(NameOf(_searchByCharges.item_desc_from_rs)).ToString
                    .qty = Utilities.ifBlankReplaceToZero(reader.Item(NameOf(_searchByCharges.qty)).ToString)
                    .amount = reader.Item(NameOf(_searchByCharges.amount)).ToString
                    .price = Utilities.ifBlankReplaceToZero(reader.Item(NameOf(_searchByCharges.price)).ToString)
                    .rs_date = Utilities.DateConverter(reader.Item(NameOf(_searchByCharges.rs_date)).ToString)
                    .wh_id = Utilities.ifBlankReplaceToZero(reader.Item(NameOf(_searchByCharges.wh_id)).ToString)
                    .type_of_purchasing = reader.Item(NameOf(_searchByCharges.type_of_purchasing)).ToString

                    getSearchByOthers.Add(_searchByCharges)

                End With

            End While

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        Finally
            SQ.connection.Close()
        End Try
    End Function

    Public Function getMultipleCharges() As List(Of PropsFields.MultipleCharges)
        getMultipleCharges = New List(Of PropsFields.MultipleCharges)

        Dim SQ As New SQLcon
        Dim newSQ As New SQLcon

        Try
            Dim c As New class_query
            c.cParameters = cDict
            c.addParameters()

            Dim reader As SqlDataReader = c.sql_data(cStoredProcedure, SQ.connection, 500)

            While reader.Read
                Dim _multipleCharges As New PropsFields.MultipleCharges
                With _multipleCharges

                    .charges_id = reader.Item(NameOf(_multipleCharges.charges_id)).ToString
                    .all_charges_id = Utilities.ifBlankReplaceToZero(reader.Item(NameOf(_multipleCharges.all_charges_id)).ToString)
                    .charges_category = reader.Item(NameOf(_multipleCharges.charges_category)).ToString
                    .rs_id = Utilities.ifBlankReplaceToZero(reader.Item(NameOf(_multipleCharges.rs_id)).ToString)
                    .temp_code_id = Utilities.ifBlankReplaceToZero(reader.Item(NameOf(.temp_code_id)).ToString)
                    .createdAt = Utilities.DateConverter(reader.Item(NameOf(_multipleCharges.createdAt)).ToString)

                    getMultipleCharges.Add(_multipleCharges)

                End With

            End While

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        Finally
            SQ.connection.Close()
        End Try
    End Function
#End Region

#Region "TIRE POSITION"
    Public Function getTirePosition() As List(Of PropsFields.tirePosition_props_fields)
        getTirePosition = New List(Of PropsFields.tirePosition_props_fields)

        Dim SQ As New SQLcon
        Dim newSQ As New SQLcon

        Try
            Dim c As New class_query

            c.cParameters = cDict
            c.addParameters()

            Dim reader As SqlDataReader = c.sql_data(cStoredProcedure, SQ.connection, 500)

            While reader.Read
                Dim _allTirePosition As New PropsFields.tirePosition_props_fields
                With _allTirePosition

                    .tire_position_id = reader.Item(NameOf(.tire_position_id)).ToString
                    .position = reader.Item(NameOf(.position)).ToString

                    getTirePosition.Add(_allTirePosition)
                End With

            End While

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        Finally
            SQ.connection.Close()
        End Try
    End Function

    Public Function getTireSerialNo() As List(Of PropsFields.tireSerial_props_fields)
        getTireSerialNo = New List(Of PropsFields.tireSerial_props_fields)

        Dim SQ As New SQLcon
        Dim newSQ As New SQLcon

        Try
            Dim c As New class_query

            c.cParameters = cDict
            c.addParameters()

            Dim reader As SqlDataReader = c.sql_data(cStoredProcedure, SQ.connection, 500)

            While reader.Read
                Dim _allTireSerialNo As New PropsFields.tireSerial_props_fields
                With _allTireSerialNo

                    .tire_position_id = reader.Item(NameOf(.tire_position_id)).ToString
                    .serial_id = reader.Item(NameOf(.serial_id)).ToString
                    .serial_no = reader.Item(NameOf(.serial_no)).ToString
                    .rr_items_id = reader.Item(NameOf(.rr_items_id)).ToString

                    getTireSerialNo.Add(_allTireSerialNo)
                End With

            End While

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        Finally
            SQ.connection.Close()
        End Try
    End Function

    Public Function getTireSerialNoView() As List(Of PropsFields.tireSerialView_props_fields)
        getTireSerialNoView = New List(Of PropsFields.tireSerialView_props_fields)

        Dim SQ As New SQLcon
        Dim newSQ As New SQLcon

        Try
            Dim c As New class_query

            c.cParameters = cDict
            c.addParameters()

            Dim reader As SqlDataReader = c.sql_data(cStoredProcedure, SQ.connection, 500)

            While reader.Read
                Dim _allTireSerialNo As New PropsFields.tireSerialView_props_fields
                With _allTireSerialNo

                    '.tire_position_id = reader.Item(NameOf(.tire_position_id)).ToString
                    .serial_id = reader.Item(NameOf(.serial_id)).ToString
                    .serial_no = reader.Item(NameOf(.serial_no)).ToString
                    .remaining_balance = Utilities.ifBlankReplaceToZero(reader.Item(NameOf(.remaining_balance)).ToString)
                    .item_name = reader.Item(NameOf(.item_name)).ToString
                    .item_desc = reader.Item(NameOf(.item_desc)).ToString
                    .rr_no = reader.Item(NameOf(.rr_no)).ToString
                    .position = reader.Item(NameOf(.position)).ToString
                    .properName = reader.Item(NameOf(.properName)).ToString
                    .units = reader.Item(NameOf(.units)).ToString
                    .amounts = FormatNumber(Utilities.ifBlankReplaceToZero(reader.Item(NameOf(.amounts)).ToString).ToString())

                    getTireSerialNoView.Add(_allTireSerialNo)

                End With

            End While

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        Finally
            SQ.connection.Close()
        End Try
    End Function
#End Region

#Region "TYPE OF REQUEST"
    Public Function getTypeOfRequest() As List(Of PropsFields.TypeOfRequest)
        getTypeOfRequest = New List(Of PropsFields.TypeOfRequest)

        Dim SQ As New SQLcon
        Dim newSQ As New SQLcon

        Try
            Dim c As New class_query

            c.cParameters = cDict
            c.addParameters()

            Dim reader As SqlDataReader = c.sql_data(cStoredProcedure, SQ.connection, 500)

            While reader.Read
                Dim _typeOfRequest As New PropsFields.TypeOfRequest
                With _typeOfRequest

                    .tor_id = reader.Item(NameOf(.tor_id)).ToString
                    .tor_sub_id = reader.Item(NameOf(.tor_sub_id)).ToString
                    .tor_sub_desc = reader.Item(NameOf(.tor_sub_desc)).ToString
                    .tor_desc = reader.Item(NameOf(.tor_desc)).ToString

                    getTypeOfRequest.Add(_typeOfRequest)
                End With

            End While

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        Finally
            SQ.connection.Close()
        End Try
    End Function

    Public Function getConsolidatedAccount() As List(Of PropsFields.Consolidated_Account)
        getConsolidatedAccount = New List(Of PropsFields.Consolidated_Account)

        Dim SQ As New SQLcon
        Dim newSQ As New SQLcon

        Try
            Dim c As New class_query

            c.cParameters = cDict
            c.addParameters()

            Dim reader As SqlDataReader = c.sql_data(cStoredProcedure, SQ.connection, 500)

            While reader.Read
                Dim _consolidatedAccount As New PropsFields.Consolidated_Account
                With _consolidatedAccount

                    .tor_sub_id = reader.Item(NameOf(.tor_sub_id)).ToString
                    .tor_id = reader.Item(NameOf(.tor_id)).ToString
                    .consolidated_account_id = reader.Item(NameOf(.consolidated_account_id)).ToString
                    .category = reader.Item(NameOf(.category)).ToString
                    .codes = reader.Item(NameOf(.codes)).ToString
                    .tor_sub_desc = reader.Item(NameOf(.tor_sub_desc)).ToString
                    .tor_desc = reader.Item(NameOf(.tor_desc)).ToString
                    .tors_ca_id = reader.Item(NameOf(.tors_ca_id)).ToString

                    getConsolidatedAccount.Add(_consolidatedAccount)
                End With

            End While

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        Finally
            SQ.connection.Close()
        End Try
    End Function
#End Region

#Region "QUANTITY TAKE OFF"
    Public Function getQTO_details() As List(Of PropsFields.QTO_details)
        getQTO_details = New List(Of PropsFields.QTO_details)

        Dim SQ As New SQLcon
        Dim newSQ As New SQLcon

        Try
            Dim c As New class_query

            c.cParameters = cDict
            c.addParameters()

            Dim reader As SqlDataReader = c.sql_data(cStoredProcedure, SQ.connection, 500)

            While reader.Read
                Dim _qto_details As New PropsFields.QTO_details
                With _qto_details

                    .rs_item_details_id = reader.Item(NameOf(.rs_item_details_id)).ToString
                    .rs_id = reader.Item(NameOf(.rs_id)).ToString
                    .details = reader.Item(NameOf(.details)).ToString

                    getQTO_details.Add(_qto_details)
                End With

            End While

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        Finally
            SQ.connection.Close()
        End Try
    End Function
#End Region

#Region "CANCELLED TRANSACTION"
    Public Function getCancelledTransaction() As List(Of PropsFields.CancelledTransaction)
        getCancelledTransaction = New List(Of PropsFields.CancelledTransaction)

        Dim SQ As New SQLcon
        Dim newSQ As New SQLcon

        Try
            Dim c As New class_query

            c.cParameters = cDict
            c.addParameters()

            Dim reader As SqlDataReader = c.sql_data(cStoredProcedure, SQ.connection, 500)

            While reader.Read
                Dim _cancelledTransaction As New PropsFields.CancelledTransaction
                With _cancelledTransaction

                    .id = Utilities.ifBlankReplaceToZero(reader.Item(NameOf(.id)).ToString)
                    .trans = reader.Item(NameOf(.trans)).ToString
                    .trans_id = Utilities.ifBlankReplaceToZero(reader.Item(NameOf(.trans_id)).ToString)
                    .remarks = reader.Item(NameOf(.remarks)).ToString

                    getCancelledTransaction.Add(_cancelledTransaction)
                End With

            End While

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        Finally
            SQ.connection.Close()
        End Try
    End Function
#End Region
End Class
