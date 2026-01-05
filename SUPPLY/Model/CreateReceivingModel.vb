Imports System.ComponentModel
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic.Logging

Public Class CreateReceivingModel
    Private employeeModel, supplierModel, properNamesModel, plateNoModel, operatorDriverModel As New ModelNew.Model
    Public createRRBgWorker As New List(Of BackgroundWorker)
    Dim cBgWorkerChecker As Timer

    Private cListOfEmployees As New List(Of PropsFields.employee_props_fields)
    Private cListOfSuppliers As New List(Of PropsFields.supplier_props_fields)
    Private cListOfProperNames As New List(Of PropsFields.whItems_properName_fields)
    Private cListOfDrivers As New List(Of PropsFields.operator_driver_props_fields)
    Private clistOfPlateNo As New List(Of PropsFields.equipment_props_fields)
    Private cListOfUI As New List(Of class_placeholder5)
    Private cUnitsUI, cSupplierUI, cPlateNoUI, cDriverUI As New class_placeholder5

    Private cLoadingPanel As New Panel
    Private customMsg As New customMessageBox
    Private cListOfFields As New List(Of class_placeholder5)
    Public isEdit As Boolean
    Public rrDataForEditNew As New ReceivingModel.COLUMNS
    Public cListOfReceivingUI As New List(Of RECEIVING_UI)

    Private cDgv As New DataGridView
    Private RawRrRows As New List(Of PropsFields.Receiving_row)
    Dim rsDrModel As New RSDRModel
    Private cn As New PropsFields.Receiving_row

    Public cUserId As Integer
    Private cListOfReceivingSerialNo As New List(Of Receiving_SerialNo)

#Region "CORE"
    Public Class RECEIVING_UI
        Public Property ui_name As String
        Public Property ui As class_placeholder5
    End Class

    Public Class Receiving_SerialNo
        Public Property receivingWithSerialNo As List(Of AddTireSerialNoModel.TIRE)
        Public Property po_det_id As Integer

    End Class
#End Region

    'get
    Public ReadOnly Property getListOfReceivingSerialNo() As List(Of Receiving_SerialNo)
        Get
            Return cListOfReceivingSerialNo
        End Get

    End Property

    Public ReadOnly Property getSuppliers() As List(Of PropsFields.supplier_props_fields)
        Get
            Return cListOfSuppliers
        End Get

    End Property

    'execute
    Public Sub execute(Optional loadingPanel As Panel = Nothing)
        Try
            cLoadingPanel = loadingPanel
            initializeData()
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    'initialize
    Public Sub initialize_employeesData(ui As class_placeholder5)
        cListOfUI.Add(ui)
    End Sub
    Public Sub initialize_driver(ui As class_placeholder5)
        cDriverUI = ui
    End Sub
    Public Sub initialize_units(ui As class_placeholder5)
        cUnitsUI = ui
    End Sub
    Public Sub initialize_suppliers(ui As class_placeholder5)
        cSupplierUI = ui
    End Sub
    Public Sub initialize_plateNo(ui As class_placeholder5)
        cPlateNoUI = ui
    End Sub
    Public Sub initializeData()
        Try
            clear()
            cLoadingPanel.Visible = True
            Dim employeeValues,
                supplierValues,
                propernameValues,
                plateNoValues,
                driverValues As New ColumnValues

#Region "EMPLOYEES"
            _initializing(cCol.forEmployees,
                     employeeValues.getValues(),
                     employeeModel,
                     createRRBgWorker)
#End Region

#Region "SUPPLIER"
            _initializing(cCol.forSupplier,
                     supplierValues.getValues(),
                     supplierModel,
                     createRRBgWorker)
#End Region

#Region "PLATE NO"
            _initializing(cCol.forPlateNo,
                          plateNoValues.getValues(),
                          plateNoModel,
                          createRRBgWorker)
#End Region

#Region "DRIVER"
            _initializing(cCol.forOperatorDriver,
                          driverValues.getValues(),
                          operatorDriverModel,
                          createRRBgWorker)
#End Region

#Region "PROPER NAMES"
            _initializing(cCol.forWhItem_ProperNames,
                     propernameValues.getValues(),
                     properNamesModel,
                     createRRBgWorker)
#End Region

            cBgWorkerChecker = BgWorkersCheckerFn(AddressOf SuccessfullyDone, createRRBgWorker)
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
    Public Sub initialize_receiving_ui(ui As RECEIVING_UI)
        Try
            cListOfReceivingUI.Add(ui)
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
    Public Sub add_ui(name As String, ui As class_placeholder5)
        Try
            Dim newReceivingUI As New RECEIVING_UI
            newReceivingUI.ui_name = name
            newReceivingUI.ui = ui

            initialize_receiving_ui(newReceivingUI)

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
    Public Sub initialize_datagrid(dgv As DataGridView)
        Try
            cDgv = dgv
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    'clear
    Private Sub clear()
        Try
            employeeModel.clearParameter()
            supplierModel.clearParameter()
            properNamesModel.clearParameter()
            plateNoModel.clearParameter()
            operatorDriverModel.clearParameter()

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
    Private Sub SuccessfullyDone()
        Try
            cListOfEmployees = TryCast(employeeModel.cData, List(Of PropsFields.employee_props_fields))
            cListOfSuppliers = TryCast(supplierModel.cData, List(Of PropsFields.supplier_props_fields))
            cListOfEquipments = TryCast(plateNoModel.cData, List(Of PropsFields.equipment_props_fields))
            cListOfProperNames = TryCast(properNamesModel.cData, List(Of PropsFields.whItems_properName_fields))
            cListOfDrivers = TryCast(operatorDriverModel.cData, List(Of PropsFields.operator_driver_props_fields))

            cLoadingPanel.Visible = False

            loadEmployees()
            loadUnits()
            loadSuppliers()
            loadPlateNo()
            loadDriver()

            If isEdit Then
                loadDataForEdit()
            End If

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    'load to ui
    Private Sub loadEmployees()
        Try
            Dim l As New List(Of String)

            For Each row In cListOfEmployees
                l.Add(row.employee)
            Next

            For Each ui In cListOfUI
                ui.AutoCompleteData = l
                ui.set_autocomplete()
            Next

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
    Private Sub loadUnits()
        Try
            Dim l As New List(Of String)

            For Each row In cListOfProperNames
                l.Add(row.units)
            Next

            cUnitsUI.AutoCompleteData = l
            cUnitsUI.set_autocomplete()

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
    Private Sub loadSuppliers()
        Try
            Dim l As New List(Of String)

            For Each row In cListOfSuppliers
                l.Add(row.supplierName)
            Next

            cSupplierUI.AutoCompleteData = l
            cSupplierUI.set_autocomplete()

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
    Private Sub loadPlateNo()
        Try
            Dim l As New List(Of String)

            For Each row In cListOfEquipments
                l.Add(row.PlateNo)
            Next

            cPlateNoUI.AutoCompleteData = l
            cPlateNoUI.set_autocomplete()

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub loadDriver()
        Try
            Dim l As New List(Of String)

            For Each row In cListOfDrivers
                l.Add(row.operator_name)
            Next

            cDriverUI.AutoCompleteData = l
            cDriverUI.set_autocomplete()

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
    Private Sub loadDataForEdit()
        Try
            Dim createReceivingForm = FCreateReceiving

            For Each ui In cListOfReceivingUI
                With createReceivingForm
                    Select Case ui.ui_name
                        Case .txtRsNo.Name
                            ui.ui.tbox.Text = rrDataForEditNew.rs_no
                        Case .dtpDateReceived.Name
                            ui.ui.cDatePicker.Text = rrDataForEditNew.date_received
                        Case .dtpDateSubmitted.Name
                            ui.ui.cDatePicker.Text = Utilities.DateConverter(rrDataForEditNew.date_submitted)
                        Case .txtSupplier.Name
                            ui.ui.tbox.Text = rrDataForEditNew.supplier
                        Case .txtInvoiceNo.Name
                            ui.ui.tbox.Text = rrDataForEditNew.invoice_no
                        Case .txtRRNo.Name
                            ui.ui.tbox.Text = rrDataForEditNew.rr_no
                        Case .txtReceivedBy.Name
                            ui.ui.tbox.Text = rrDataForEditNew.received_by
                        Case .txtCheckedBy.Name
                            ui.ui.tbox.Text = rrDataForEditNew.checked_by
                        Case .txtInvoiceNo.Name
                            ui.ui.tbox.Text = rrDataForEditNew.invoice_no
                        Case .txtRRNo.Name
                            ui.ui.tbox.Text = rrDataForEditNew.rr_no
                        Case .txtPlateNo.Name
                            ui.ui.tbox.Text = rrDataForEditNew.plateNo
                        Case .txtSoNo.Name
                            ui.ui.tbox.Text = rrDataForEditNew.soNo
                        Case .txtSerialNo.Name
                            ui.ui.tbox.Enabled = False
                        Case .cmbTireOption.Name
                            ui.ui.cBox.Enabled = False
                        Case .txtSource.Name
                            ui.ui.tbox.Text = rrDataForEditNew.source
                        Case .txtOperator.Name
                            ui.ui.tbox.Text = rrDataForEditNew.driver
                    End Select
                End With
            Next

            DisplayRrDataToRrDatagridview()
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    'handle filter for datagridview
    Public Function rr_row_detail_filter_before_save(dgv As DataGridView) As Boolean
        Try
            Dim _cn_ As New PropsFields.Receiving_row

            For Each row As DataGridViewRow In dgv.Rows
                If row.Cells("level").Value = "parent" Then
                    Dim isEmpty As Boolean = False
                    Dim columnStr As String = ""

                    If row.Cells(NameOf(_cn_.rr_qty)).Value = "" Then
                        columnStr = "RR QTY"
                        isEmpty = True

                    ElseIf row.Cells(NameOf(_cn_.unit)).Value = "" Then
                        columnStr = "UNIT"
                        isEmpty = True

                    ElseIf row.Cells(NameOf(_cn_.unit_price)).Value = "" Then
                        columnStr = "UNIT PRICE"
                        isEmpty = True
                    End If

                    If isEmpty Then
                        customMsg.message("error", $"{columnStr} MUST NOT BE EMPTY!", "SUPPLY INFO:")
                        Utilities.datagridviewSpecificRowFocus(dgv, row.Cells(NameOf(_cn_.po_det_id)).Value, NameOf(_cn_.po_det_id))
                        rr_row_detail_filter_before_save = True
                        Exit For
                    End If
                End If
            Next

            Return rr_row_detail_filter_before_save
        Catch ex As Exception

        End Try
    End Function
    'handle filter for textbox and combobox 
    Public Sub add_fields_for_filter_rr_info(ui As class_placeholder5)
        Try
            cListOfFields.Add(ui)
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
    Public Function rr_fields_filter_before_save() As Boolean
        Dim countError As Integer = 0
        For Each ui As class_placeholder5 In cListOfFields
            If ui.tbox IsNot Nothing Then
                If ui.isBlankTextBox() Then
                    ui.tbox.Focus()
                    ErrorMessage(ui.placeHolder)
                    countError += 1
                    Exit For
                End If

            ElseIf ui.cBox IsNot Nothing Then
                If ui.isBlankComboBox() Then
                    ui.cBox.Focus()
                    ErrorMessage(ui.placeHolder)
                    countError += 1
                    Exit For
                End If
            End If
        Next

        If countError > 0 Then
            Return True
        End If


    End Function
    'crud
#Region "CRUD"
    Public Function save_receiving_info(po_info As PropsFields.Create_receiving_for_dr_props_fields,
                                    Optional sqlCon As SQLcon = Nothing,
                                    Optional transaction As SqlTransaction = Nothing) As Integer
        Try

            With po_info

                Dim cc As New ColumnValuesObj
                cc.add("rr_no", .rr_no)
                cc.add("invoice_no", .invoice_no)
                cc.add("supplier_id", .supplier_id)
                cc.add("po_no", .po_cv_no)
                cc.add("rs_no", .rs_no)
                cc.add("date_received", .date_received)
                cc.add("received_by", .received_by)
                cc.add("checked_by", .checked_by)
                cc.add("received_status", "PENDING")
                cc.add("so_no", .soNo)
                cc.add("plateno", .plateNo)
                cc.add("date_log", Date.Parse(Now))
                cc.add("user_id", pub_user_id)
                cc.add("date_submitted", .date_submitted)
                cc.add("insource_outsource", .inoutsource)
                cc.add("operator_name", .driver)

                save_receiving_info = cc.insertQueryRollBack_and_return_id("dbreceiving_info", sqlCon, transaction)
            End With

            Return save_receiving_info

        Catch ex As Exception
            If transaction IsNot Nothing Then
                transaction.Rollback()
            End If
            customMsg.ErrorMessage(ex)
        End Try

    End Function
    Public Function update_receiving_info(po_info As PropsFields.Create_receiving_for_dr_props_fields,
                                    Optional sqlCon As SQLcon = Nothing,
                                    Optional transaction As SqlTransaction = Nothing) As Boolean

        Try

            With po_info

                Dim cc As New ColumnValuesObj
                cc.add("rr_no", .rr_no)
                cc.add("invoice_no", .invoice_no)
                cc.add("supplier_id", .supplier_id)
                cc.add("date_received", .date_received)
                cc.add("received_by", .received_by)
                cc.add("checked_by", .checked_by)
                cc.add("so_no", "N/A")
                cc.add("plateno", "N/A")
                cc.add("date_submitted", .date_submitted)
                cc.add("operator_name", .driver)
                cc.add("insource_outsource", .inoutsource)

                cc.setCondition($"rr_info_id = {po_info.rr_info_id}")

                update_receiving_info = cc.updateQueryRollBack_and_return_true("dbreceiving_info", sqlCon, transaction)
            End With

            Return update_receiving_info

        Catch ex As Exception
            If transaction IsNot Nothing Then
                transaction.Rollback()
            End If
            customMsg.ErrorMessage(ex)
        End Try
    End Function
    Public Function save_multiple_receiving_details(rr_info_id As Integer,
                                                        rr_details As List(Of PropsFields.Receiving_row),
                                                        Optional sqlCon As SQLcon = Nothing,
                                                        Optional transaction As SqlTransaction = Nothing) As Integer
        Try
            Dim rr_items_id As Integer
            For Each row In rr_details

                Dim dbReceivingItems As New ColumnValuesObj
                With dbReceivingItems
                    .add("rr_info_id", CInt(Utilities.ifBlankReplaceToZero(rr_info_id)))
                    .add("qty", CDbl(Utilities.ifBlankReplaceToZero(row.rr_qty)))
                    .add("rs_id", CDbl(Utilities.ifBlankReplaceToZero(row.rs_id)))
                    .add("po_det_id", CDbl(Utilities.ifBlankReplaceToZero(row.po_det_id)))
                    .add("selected", "Include")

                    rr_items_id = .insertQueryRollBack_and_return_id("dbreceiving_items", sqlCon, transaction)

                End With

                Dim dbReceivingPartially As New ColumnValuesObj
                With dbReceivingPartially
                    .add("rr_item_id", rr_items_id)
                    .add("desired_qty", row.rr_qty)

                    Dim par_rr_item_id As Integer = .insertQueryRollBack_and_return_id("dbreceiving_item_partially", sqlCon, transaction)
                End With

                Dim dbReceivingItemSub As New ColumnValuesObj
                With dbReceivingItemSub
                    .add("rr_item_id", rr_items_id)
                    .add("item_desc", row.rr_item_description)
                    .add("qty", row.rr_qty)
                    .add("amount", Utilities.converToDouble(row.unit_price))
                    .add("unit", row.unit)
                    .add("selected", "Include")

                    Dim rr_item_sub_id As Integer = .insertQueryRollBack_and_return_id("dbreceiving_items_sub", sqlCon, transaction)
                End With
            Next

            Return rr_items_id

        Catch ex As Exception
            If transaction IsNot Nothing Then
                transaction.Rollback()
            End If

            customMsg.ErrorMessage(ex)
        End Try
    End Function
    Public Function update_multiple_receiving_details(rr_item_id As Integer,
                                                        rr_details As List(Of PropsFields.Receiving_row),
                                                        Optional sqlCon As SQLcon = Nothing,
                                                        Optional transaction As SqlTransaction = Nothing) As Boolean
        Try
            Dim rr_items_result As Boolean
            For Each row In rr_details

                Dim dbReceivingItems As New ColumnValuesObj
                With dbReceivingItems

                    .add("qty", CDbl(Utilities.ifBlankReplaceToZero(row.rr_qty)))
                    .add("updatedAt", Date.Parse(Now))
                    .add("updatedById", cUserId)

                    .setCondition($"rr_item_id = {rr_item_id}")

                    rr_items_result = .updateQueryRollBack_and_return_true("dbreceiving_items",
                                                                           sqlCon,
                                                                           transaction)
                End With

                Dim dbReceivingItemSub As New ColumnValuesObj

                With dbReceivingItemSub
                    .add("item_desc", row.rr_item_description)
                    .add("amount", Utilities.converToDouble(row.unit_price))
                    .add("unit", row.unit)
                    .setCondition($"rr_item_id = {rr_item_id}")

                    Dim rr_item_sub_boolean As Boolean = .updateQueryRollBack_and_return_true("dbreceiving_items_sub",
                                                                                              sqlCon,
                                                                                              transaction)

                End With
            Next

            Return rr_items_result

        Catch ex As Exception
            If transaction IsNot Nothing Then
                transaction.Rollback()
            End If

            customMsg.ErrorMessage(ex)
        End Try
    End Function
    Public Sub addSerialNo(rows As List(Of AddTireSerialNoModel.TIRE),
                           po_det_id As Integer)
        Try
            Dim _addSerialNo As New Receiving_SerialNo
            With _addSerialNo
                .receivingWithSerialNo = rows
                .po_det_id = po_det_id
            End With

            cListOfReceivingSerialNo.Add(_addSerialNo)

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Public Sub updateSerialNo(po_det_id As Integer,
                              updatedReceivingWithSerialNo As List(Of AddTireSerialNoModel.TIRE))
        Try
            Dim dataIndex As Integer = cListOfReceivingSerialNo.FindIndex(Function(x) x.po_det_id = po_det_id)
            cListOfReceivingSerialNo(dataIndex).receivingWithSerialNo = updatedReceivingWithSerialNo

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Public Sub removeSerialNo(po_det_id As Integer, index_id As Integer)
        Try
            Dim data = cListOfReceivingSerialNo.FirstOrDefault(Function(x) x.po_det_id = po_det_id)

            Dim row = data?.receivingWithSerialNo.FirstOrDefault(Function(x) x.tire_index = index_id)

            data?.receivingWithSerialNo.Remove(row)

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
    Public Function save_tire_serial(tireDataStorage As PropsFields.tireSerial_props_fields,
                                    Optional sqlCon As SQLcon = Nothing,
                                    Optional transaction As SqlTransaction = Nothing) As Integer
        Try
            With tireDataStorage
                Dim cc As New ColumnValuesObj

                cc.add("rr_items_id", .rr_items_id)
                cc.add("tire_position_id", .tire_position_id)
                cc.add("serial_no", .serial_no)

                save_tire_serial = cc.insertQueryRollBack_and_return_id("dbSerial", sqlCon, transaction)

            End With
        Catch ex As Exception
            If transaction IsNot Nothing Then
                transaction.Rollback()
            End If

            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Public Function save_tire_serialNew(tireDatas As List(Of AddTireSerialNoModel.TIRE),
                                        tireDataStorage As PropsFields.tireSerial_props_fields,
                                        Optional sqlCon As SQLcon = Nothing,
                                        Optional transaction As SqlTransaction = Nothing) As Integer
        Try
            'With tireDataStorage
            '    Dim cc As New ColumnValuesObj

            '    cc.add("rr_items_id", .rr_items_id)
            '    cc.add("tire_position_id", .tire_position_id)
            '    cc.add("serial_no", .serial_no)

            '    save_tire_serial = cc.insertQueryRollBack_and_return_id("dbSerial", sqlCon, transaction)

            'End With
            For Each tire In tireDatas
                Dim cc As New ColumnValuesObj

                cc.add("rr_items_id", tireDataStorage.rr_items_id)
                cc.add("tire_position_id", tireDataStorage.tire_position_id)
                cc.add("serial_no", tire.tire_serial_no)

                save_tire_serialNew = cc.insertQueryRollBack_and_return_id("dbSerial", sqlCon, transaction)
            Next
        Catch ex As Exception
            If transaction IsNot Nothing Then
                transaction.Rollback()
            End If

            customMsg.ErrorMessage(ex)
        End Try
    End Function
    Public Function remove_receiving(po_info As ReceivingModel.COLUMNS) As Boolean
        Try

            Dim lot As New ListOfTables
            If Not isRrItemOnlyOneLeft(po_info.rr_info_id) Then
                lot.addTable("dbreceiving_items", $"rr_item_id = {po_info.rr_item_id}")
                lot.addTable("dbreceiving_item_partially", $"rr_item_id = {po_info.rr_item_id}")
                lot.addTable("dbreceiving_items_sub", $"rr_item_id = {po_info.rr_item_id}")
            Else
                lot.addTable("dbreceiving_info", $"rr_info_id = {po_info.rr_info_id}")
                lot.addTable("dbreceiving_items", $"rr_item_id = {po_info.rr_item_id}")
                lot.addTable("dbreceiving_item_partially", $"rr_item_id = {po_info.rr_item_id}")
                lot.addTable("dbreceiving_items_sub", $"rr_item_id = {po_info.rr_item_id}")
            End If


            Dim cc As New ColumnValuesObj
            cc.deleteDataUsingRollback(lot.getListOfTables)

            Return True
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
            Return False
        End Try

    End Function

    Private Function isTireOnlyOneLeft(rr_item_id As Integer) As Boolean
        Try
            Dim dynamicEditRR As New Model_Dynamic_Select

            Dim table As String = "dbSerial a" 'table
            Dim condition As String = $"a.rr_items_id = {rr_item_id}" 'conditions

            'columns
            dynamicEditRR.join_columns("a.serial_id,")
            dynamicEditRR.join_columns("a.serial_no")
            'end columns

            'initialize data
            dynamicEditRR._initialize(table, condition, dynamicEditRR.cJoinColumns, dynamicEditRR.cJoining)

            Dim rrData As New List(Of Object) 'create a list of ojbect 
            rrData = dynamicEditRR.select_query() 'get data

            If rrData.Count = 1 Then
                Return True
            End If

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Private Function isRrItemOnlyOneLeft(rr_info_id As Integer) As Boolean
        Try
            Dim dynamicEditRR As New Model_Dynamic_Select

            Dim table As String = "dbreceiving_items a" 'table
            Dim condition As String = $"a.rr_info_id = {rr_info_id}" 'conditions

            'columns
            dynamicEditRR.join_columns("a.rr_item_id")
            'end columns

            'initialize data
            dynamicEditRR._initialize(table, condition, dynamicEditRR.cJoinColumns, dynamicEditRR.cJoining)

            Dim rrData As New List(Of Object) 'create a list of ojbect 
            rrData = dynamicEditRR.select_query() 'get data

            If rrData.Count = 1 Then
                Return True
            End If

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function
    Public Function remove_receiving_including_tireSerial(po_info As ReceivingModel.COLUMNS) As Boolean
        Try
            If Not isTireOnlyOneLeft(po_info.rr_item_id) Then
                Dim lot As New ListOfTables
                lot.addTable("dbSerial", $"serial_id = {po_info.serial_id}")

                Dim cc As New ColumnValuesObj
                cc.deleteDataUsingRollback(lot.getListOfTables)
            Else
                Dim lot As New ListOfTables
                lot.addTable("dbreceiving_info", $"rr_info_id = {po_info.rr_info_id}")
                lot.addTable("dbreceiving_items", $"rr_item_id = {po_info.rr_item_id}")
                lot.addTable("dbreceiving_item_partially", $"rr_item_id = {po_info.rr_item_id}")
                lot.addTable("dbreceiving_items_sub", $"rr_item_id = {po_info.rr_item_id}")
                lot.addTable("dbSerial", $"rr_items_id = {po_info.rr_item_id}")

                Dim cc As New ColumnValuesObj
                cc.deleteDataUsingRollback(lot.getListOfTables)
            End If


            Return True
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
            Return False
        End Try

    End Function
    Public Function isForTire(po_info As ReceivingModel.COLUMNS) As Boolean

    End Function

    Public Function remove_item_from_the_list(dgv As DataGridView)
        Try
            dgv.Rows.RemoveAt(dgv.SelectedRows(0).Index)
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

    End Function
    Public Sub updateRRrowForEdit(rrRowUpdate As PropsFields.Receiving_row, dgv As DataGridView)
        Try
            With rrRowUpdate
                RawRrRows(0).rr_qty = .rr_qty
                RawRrRows(0).unit = .unit
                RawRrRows(0).unit_price = FormatNumber(.unit_price).ToString
                RawRrRows(0).amount = FormatNumber(.amount).ToString
                RawRrRows(0).rr_item_description = .rr_item_description
            End With

            dgv.DataSource = Nothing
            dgv.DataSource = RawRrRows

            'customizeGridViewForPo(dgv)
            rsDrModel.customizeGridViewForRr(cDgv, True)

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
#End Region

#Region "PREVIEW"
    Public Sub DisplayRrDataToRrDatagridview()
        Try
            RawRrRows.Clear()

            Dim _rawRrRows As New PropsFields.Receiving_row
            With _rawRrRows

                .po_det_id = rrDataForEditNew.po_det_id
                .item_description = rrDataForEditNew.item_desc
                .po_qty_balance = 0
                .rr_qty = rrDataForEditNew.rr_qty
                .rs_id = rrDataForEditNew.rs_id
                .po_no = rrDataForEditNew.po_cv_no
                .unit = rrDataForEditNew.unit
                .unit_price = rrDataForEditNew.price
                .amount = .unit_price * .rr_qty
                .unit = rrDataForEditNew.unit
                .rr_item_description = rrDataForEditNew.rr_item_desc

            End With

            RawRrRows.Add(_rawRrRows)

            cDgv.DataSource = RawRrRows
            rsDrModel.customizeGridViewForRr(cDgv, True)

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
    'Public Sub refactorAndPreviewIncludingSerialNo(receivingRows As List(Of PropsFields.Receiving_row), dgv As DataGridView)
    '    Try
    '        Dim newRawRrRows As New List(Of PropsFields.Receiving_row)
    '        For Each row In receivingRows
    '            Dim _rawRr As New PropsFields.Receiving_row
    '            With _rawRr
    '                .po_det_id = row.po_det_id
    '                .po_no = row.po_no
    '                .rs_id = row.rs_id
    '                .item_description = row.item_description
    '                .rr_qty = row.rr_qty
    '                .po_qty_balance = row.po_qty_balance
    '                .typeOfPurchasing = row.typeOfPurchasing
    '                .unit = row.unit
    '                .unit_price = row.unit_price
    '                .level = "parent"
    '            End With

    '            newRawRrRows.Add(_rawRr)

    '            For Each row2 In cListOfReceivingSerialNo
    '                If row2.po_det_id = row.po_det_id Then
    '                    For Each row3 In row2.receivingWithSerialNo
    '                        Dim _rawRrSub As New PropsFields.Receiving_row
    '                        With _rawRrSub
    '                            .item_description = row3.tire_serial_no
    '                            .level = "child"
    '                        End With

    '                        newRawRrRows.Add(_rawRrSub)
    '                    Next
    '                End If
    '            Next
    '        Next

    '        dgv.DataSource = Nothing
    '        dgv.DataSource = newRawRrRows

    '    Catch ex As Exception
    '        customMsg.ErrorMessage(ex)
    '    End Try
    'End Sub
#End Region

#Region "UTILITIES"
    Public Function isSerialNoAlreadySet(po_det_id As Integer) As Boolean
        Dim data = cListOfReceivingSerialNo.FirstOrDefault(Function(x) x.po_det_id = po_det_id)

        If data IsNot Nothing Then
            Return True
        End If

    End Function

    Public Function currentReceivingSerialNo(po_det_id As Integer) As List(Of AddTireSerialNoModel.TIRE)
        Try
            Dim data = cListOfReceivingSerialNo.FirstOrDefault(Function(x) x.po_det_id = po_det_id)

            Return data?.receivingWithSerialNo

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Public Function calculateTotalAmount(dgv As DataGridView) As Double
        Try
            For Each row As DataGridViewRow In dgv.Rows
                calculateTotalAmount += Utilities.ifBlankReplaceToZero(row.Cells(NameOf(cn.amount)).Value)
            Next
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function
#End Region



End Class
