Imports System.ComponentModel
Imports System.Data.SqlClient

Public Class CreatePurchaseOrderForDrModel
    Private employeeModel, supplierModel, properNamesModel As New ModelNew.Model
    Public createWsBgWorker As New List(Of BackgroundWorker)
    Dim cBgWorkerChecker As Timer

    Private cListOfEmployees As New List(Of PropsFields.employee_props_fields)
    Private cListOfProperNames As New List(Of PropsFields.whItems_properName_fields)
    Private cListOfSuppliers As New List(Of PropsFields.supplier_props_fields)
    Private cLoadingPanel As New Panel
    Private customMsg As New customMessageBox

    Private cListOfUI As New List(Of class_placeholder5)
    Private cUnitsUI, cSupplierUI As New class_placeholder5
    Private cListOfFields As New List(Of class_placeholder5)

    Private customDatagrid As New CustomGridview

    Public isEditAll As Boolean
    Private customDatagridForPo As New CustomGridview

    Private clistOfPreparedBy As New List(Of Integer)
    Private cListOfCheckedBy As New List(Of Integer)
    Private cListOfApprovedBy As New List(Of Integer)

    Public Class POROW_PARAM
        Public Property poRow As New PropsFields.Purchase_Order_Row
        Public Property listOfPoRow As New List(Of PropsFields.Purchase_Order_Row)
        Public Property datagrid As New DataGridView
        Public Property isEditAllPo As Boolean
    End Class

    'get
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
    Public Sub initialize_units(ui As class_placeholder5)
        cUnitsUI = ui
    End Sub
    Public Sub initialize_suppliers(ui As class_placeholder5)
        cSupplierUI = ui
    End Sub

    'default prepared by, approved by and checked by
    Private Sub defaultPoClerk()
        Try
            clistOfPreparedBy.Add(7611)
            clistOfPreparedBy.Add(7767)
            clistOfPreparedBy.Add(4856)
            clistOfPreparedBy.Add(6090)

            cListOfCheckedBy.Add(5147)
            cListOfApprovedBy.Add(5384)

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
    Public Sub initializeData()
        Try
            clear()

            cLoadingPanel.Visible = True
            Dim employeeValues,
                supplierValues,
                propernameValues As New ColumnValues

            defaultPoClerk()

#Region "EMPLOYEES"
            _initializing(cCol.forEmployees,
                     employeeValues.getValues(),
                     employeeModel,
                     createWsBgWorker)
#End Region

#Region "SUPPLIER"
            _initializing(cCol.forSupplier,
                     supplierValues.getValues(),
                     supplierModel,
                     createWsBgWorker)
#End Region

#Region "PROPER NAMES"
            _initializing(cCol.forWhItem_ProperNames,
                     propernameValues.getValues(),
                     properNamesModel,
                     createWsBgWorker)
#End Region

            cBgWorkerChecker = BgWorkersCheckerFn(AddressOf SuccessfullyDone, createWsBgWorker)
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

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
    Private Sub SuccessfullyDone()
        Try
            cListOfEmployees = TryCast(employeeModel.cData, List(Of PropsFields.employee_props_fields))
            cListOfSuppliers = TryCast(supplierModel.cData, List(Of PropsFields.supplier_props_fields))
            cListOfProperNames = TryCast(properNamesModel.cData, List(Of PropsFields.whItems_properName_fields))

            cLoadingPanel.Visible = False

            loadEmployees()
            loadUnits()
            loadSuppliers()

            'for edit purchase order


        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub



    Private Function getPurchasingEmployeeList(list As List(Of Integer)) As List(Of String)
        Try
            getPurchasingEmployeeList = New List(Of String)

            For Each row In cListOfEmployees
                Dim result = list.FirstOrDefault(Function(x) x = row.employee_id)

                If result > 0 Then
                    getPurchasingEmployeeList.Add(row.employee)
                End If
            Next

            Return getPurchasingEmployeeList
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    'load to ui
    Private Sub loadEmployees()
        Try
            Dim l As New List(Of String)

            For Each row In cListOfEmployees
                l.Add(row.employee)
            Next

            For Each ui In cListOfUI
                If ui.tbox.Name = "txtPreparedBy" Then
                    ui.AutoCompleteData = getPurchasingEmployeeList(clistOfPreparedBy)
                    ui.set_autocomplete()

                ElseIf ui.tbox.Name = "txtCheckedBy" Then
                    ui.AutoCompleteData = getPurchasingEmployeeList(cListOfCheckedBy)
                    ui.set_autocomplete()

                ElseIf ui.tbox.Name = "txtApprovedBy" Then
                    ui.AutoCompleteData = getPurchasingEmployeeList(cListOfApprovedBy)
                    ui.set_autocomplete()
                Else
                    ui.AutoCompleteData = l
                    ui.set_autocomplete()
                End If
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

    'handle filter for datagridview
    Public Function po_row_detail_filter_before_save(dgv As DataGridView) As Boolean
        Try
            Dim _cn_ As New PropsFields.Purchase_Order_Row

            For Each row As DataGridViewRow In dgv.Rows
                Dim isEmpty As Boolean = False
                Dim columnStr As String = ""

                If row.Cells(NameOf(_cn_.qty)).Value = "" Then
                    columnStr = "PO QTY"
                    isEmpty = True

                ElseIf row.Cells(NameOf(_cn_.poNo)).Value = "" Then
                    columnStr = "PO NO."
                    isEmpty = True

                ElseIf row.Cells(NameOf(_cn_.unit_price)).Value = "" Then
                    columnStr = "UNI PRICE"
                    isEmpty = True
                End If

                If isEmpty Then
                    customMsg.message("error", $"{columnStr} MUST NOT BE EMPTY!", "SUPPLY INFO:")
                    Utilities.datagridviewSpecificRowFocus(dgv, row.Cells(NameOf(_cn_.rs_id)).Value, NameOf(_cn_.rs_id))
                    po_row_detail_filter_before_save = True
                    Exit For
                End If
            Next

            Return po_row_detail_filter_before_save
        Catch ex As Exception

        End Try
    End Function

    'handle filter for textbox and combobox 
    Public Sub add_fields_for_filter_po_info(ui As class_placeholder5)
        Try
            cListOfFields.Add(ui)
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Public Function po_fields_filter_before_save() As Boolean
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
            Return po_fields_filter_before_save
        End If


    End Function

    'CRUD
    Public Function save_purchaseOrder_info(po_info As PropsFields.Create_purchaseOrder_for_dr_props_fields,
                                    Optional sqlCon As SQLcon = Nothing,
                                    Optional transaction As SqlTransaction = Nothing) As Integer
        Try

            With po_info

                Dim cc As New ColumnValuesObj
                cc.add("rs_no", .rs_no)
                cc.add("instructor", .instruction)
                cc.add("po_date", .po_date)
                cc.add("date_needed", .date_needed)
                cc.add("prepared_by", .prepared_by)
                cc.add("checked_by", .checked_by)
                cc.add("approved_by", .approved_by)
                cc.add("user_id", .user_id)
                cc.add("date_log", .date_log)
                cc.add("dr_option", "WITHOUT DR")
                cc.add("remarks", .remarks)

                save_purchaseOrder_info = cc.insertQueryRollBack_and_return_id("dbPO", sqlCon, transaction)
            End With

            Return save_purchaseOrder_info

        Catch ex As Exception
            If transaction IsNot Nothing Then
                transaction.Rollback()
            End If
            customMsg.ErrorMessage(ex)
        End Try

    End Function

    Public Function update_purchaseOrder_info(po_info As PropsFields.Create_purchaseOrder_for_dr_props_fields,
                                    Optional sqlCon As SQLcon = Nothing,
                                    Optional transaction As SqlTransaction = Nothing) As Boolean
        Try

            With po_info

                Dim cc As New ColumnValuesObj

                cc.add("instructor", .instruction)
                cc.add("po_date", .po_date)
                cc.add("date_needed", .date_needed)
                cc.add("prepared_by", .prepared_by)
                cc.add("checked_by", .checked_by)
                cc.add("approved_by", .approved_by)
                cc.add("remarks", .remarks)
                cc.add("date_log_updated", Date.Parse(Now))

                cc.setCondition($"po_id = {po_info.po_id}")

                update_purchaseOrder_info = cc.updateQueryRollBack_and_return_true("dbPO", sqlCon, transaction)
            End With

            Return update_purchaseOrder_info

        Catch ex As Exception
            If transaction IsNot Nothing Then
                transaction.Rollback()
            End If
            customMsg.ErrorMessage(ex)
        End Try

    End Function

    Public Function save_purchaseOrder_details(po_info_id As Integer, po_details As PropsFields.Create_purchaseOrder_for_dr_props_fields,
                                            Optional sqlCon As SQLcon = Nothing,
                                            Optional transaction As SqlTransaction = Nothing) As Integer
        Try
            With po_details

                Dim cc As New ColumnValuesObj
                cc.add("po_id", po_info_id)
                cc.add("supplier_id", .supplier_id)
                cc.add("po_no", .po_no)
                cc.add("terms", .terms)
                cc.add("qty", .po_qty)
                cc.add("unit", .units)
                cc.add("amount", .unit_price)
                cc.add("rs_id", .rs_id)
                cc.add("tax_category", .tax_category)
                cc.add("vat_value", .vat_value)
                cc.add("unit_price", .unit_price)
                cc.add("selected", "TRUE")

                save_purchaseOrder_details = cc.insertQueryRollBack_and_return_id("dbPO_details", sqlCon, transaction)
            End With

            Return save_purchaseOrder_details

        Catch ex As Exception
            If transaction IsNot Nothing Then
                transaction.Rollback()
            End If

            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Public Function save_multiple_purchaseOrder_details(po_info_id As Integer,
                                                        po_details As List(Of PropsFields.Purchase_Order_Row),
                                                        Optional sqlCon As SQLcon = Nothing,
                                                        Optional transaction As SqlTransaction = Nothing) As Integer
        Try
            Dim poNo As String = ""

            For Each row In po_details

                Dim cc As New ColumnValuesObj
                cc.add("po_id", CInt(Utilities.ifBlankReplaceToZero(po_info_id)))
                cc.add("supplier_id", CInt(Utilities.ifBlankReplaceToZero(row.supplier_id)))
                cc.add("po_no", row.poNo)
                cc.add("terms", row.terms)
                cc.add("qty", CDbl(Utilities.ifBlankReplaceToZero(row.qty)))
                cc.add("unit", row.unit)
                cc.add("amount", CDbl(Utilities.ifBlankReplaceToZero(row.unit_price)))
                cc.add("rs_id", CInt(Utilities.ifBlankReplaceToZero(row.rs_id)))
                cc.add("tax_category", row.tax_category)
                cc.add("vat_value", CDbl(Utilities.ifBlankReplaceToZero(row.tax_value)))
                cc.add("unit_price", CDbl(Utilities.ifBlankReplaceToZero(row.unit_price)))
                cc.add("selected", "TRUE")

                save_multiple_purchaseOrder_details = cc.insertQueryRollBack_and_return_id("dbPO_details", sqlCon, transaction)
                poNo = row.poNo
            Next

            pubPoNo = poNo '<-- store temporarily for auto increment po for the next transaction
            Return save_multiple_purchaseOrder_details


        Catch ex As Exception
            If transaction IsNot Nothing Then
                transaction.Rollback()
            End If

            customMsg.ErrorMessage(ex)
        End Try
    End Function
    Public Function update_multiple_purchaseOrder_details(po_details As List(Of PropsFields.Purchase_Order_Row),
                                                        Optional sqlCon As SQLcon = Nothing,
                                                        Optional transaction As SqlTransaction = Nothing) As Boolean
        Try

            For Each row In po_details

                Dim cc As New ColumnValuesObj

                cc.add("supplier_id", CInt(Utilities.ifBlankReplaceToZero(row.supplier_id)))
                cc.add("po_no", row.poNo)
                cc.add("terms", row.terms)
                cc.add("qty", CDbl(Utilities.ifBlankReplaceToZero(row.qty)))
                cc.add("unit", row.unit)
                cc.add("amount", CDbl(Utilities.ifBlankReplaceToZero(row.unit_price)))
                cc.add("tax_category", row.tax_category)
                cc.add("vat_value", CDbl(Utilities.ifBlankReplaceToZero(row.tax_value)))
                cc.add("unit_price", CDbl(Utilities.ifBlankReplaceToZero(row.unit_price)))
                cc.add("user_id_update_logs", pub_user_id)
                cc.setCondition($"po_det_id = {row.po_det_id}")

                update_multiple_purchaseOrder_details = cc.updateQueryRollBack_and_return_true("dbPO_details", sqlCon, transaction)

            Next

            Return update_multiple_purchaseOrder_details

        Catch ex As Exception
            If transaction IsNot Nothing Then
                transaction.Rollback()
            End If

            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Public Function remove_item_from_the_list(dgv As DataGridView)
        Try
            dgv.Rows.RemoveAt(dgv.SelectedRows(0).Index)
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

    End Function

    Public Function withdraw_aggregates(rs_id As Integer, ws_id As Integer) As Integer
        Try
            Dim cc As New ColumnValuesObj
            cc.add("rs_id", rs_id)
            cc.add("ws_id", ws_id)
            cc.add("date_log_withdrawn", Date.Parse(Now))

            withdraw_aggregates = cc.insertQuery_and_return_id("dbwithdrawn_items")

            Return withdraw_aggregates

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Public Sub updatePOrowForEdit(poRowUpdate As CreatePurchaseOrderForDrModel.POROW_PARAM)
        Try


            With poRowUpdate
                Dim rowIndex As Integer = .listOfPoRow.FindIndex(Function(x) x.rs_id = poRowUpdate.poRow.rs_id)

                .listOfPoRow(rowIndex).supplier = .poRow.supplier
                .listOfPoRow(rowIndex).poNo = .poRow.poNo
                .listOfPoRow(rowIndex).qty = .poRow.qty
                .listOfPoRow(rowIndex).unit = .poRow.unit
                .listOfPoRow(rowIndex).unit_price = FormatNumber(.poRow.unit_price).ToString
                .listOfPoRow(rowIndex).amount = FormatNumber(.poRow.amount).ToString
                .listOfPoRow(rowIndex).price_with_tax = .poRow.price_with_tax
                .listOfPoRow(rowIndex).tax_category = .poRow.tax_category
                .listOfPoRow(rowIndex).tax_value = .poRow.tax_value
                .listOfPoRow(rowIndex).terms = .poRow.terms

                .datagrid.DataSource = Nothing
                .datagrid.DataSource = .listOfPoRow
            End With

            customizeGridViewForPo(poRowUpdate.datagrid)

            Utilities.datagridviewSpecificRowFocus(poRowUpdate.datagrid, poRowUpdate.poRow.rs_id, "rs_id")

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub


    'CUSTOMIZE SOMETHING
    Public Sub customizeGridViewForPo(dgv As DataGridView)
        Try
            Dim cn2 As New PropsFields.Purchase_Order_Row

            'rename columns
            dgv.Columns(NameOf(cn2.rs_id)).HeaderText = "RS_ID"
            dgv.Columns(NameOf(cn2.supplier)).HeaderText = "SUPPLIER"
            dgv.Columns(NameOf(cn2.wh_id)).HeaderText = "WH ID"
            dgv.Columns(NameOf(cn2.item_description)).HeaderText = "ITEM DESCRIPTION"
            dgv.Columns(NameOf(cn2.poNo)).HeaderText = "PO NO."
            dgv.Columns(NameOf(cn2.terms)).HeaderText = "TERMS"
            dgv.Columns(NameOf(cn2.rs_qty_balance)).HeaderText = "RS QTY BALANCE"
            dgv.Columns(NameOf(cn2.qty)).HeaderText = "PO QTY."
            dgv.Columns(NameOf(cn2.amount)).HeaderText = "AMOUNT"
            dgv.Columns(NameOf(cn2.unit)).HeaderText = "UNIT"
            dgv.Columns(NameOf(cn2.unit_price)).HeaderText = "UNIT PRICE"
            dgv.Columns(NameOf(cn2.tax_category)).HeaderText = "TAX CATEGORY"
            dgv.Columns(NameOf(cn2.tax_value)).HeaderText = "TAX (VAT/EWT)"
            dgv.Columns(NameOf(cn2.price_with_tax)).HeaderText = "PRICE WITH TAX"
            dgv.Columns(NameOf(cn2.charges)).HeaderText = "CHARGES"

            customDatagridForPo.customDatagridview(dgv,, 38)

            'alternate rows
            customDatagridForPo.subcustomDatagridviewSettings2("alternateRowStyle", dgv)

            'readonly
            customDatagridForPo.readonlyAllCells(dgv)

            customDatagridForPo.customHeader(dgv)

            'column width
            dgv.Columns(NameOf(cn2.item_description)).Width = 400

            'hide
            dgv.Columns(NameOf(cn2.user_id)).Visible = False
            dgv.Columns(NameOf(cn2.supplier_id)).Visible = False
            dgv.Columns(NameOf(cn2.wh_id)).Visible = False



        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
End Class
