Imports System.ComponentModel
Imports System.Data.SqlClient

Public Class CreateWithdrawalSlipForDrModel
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

    Public Sub initializeData()
        Try
            clear()

            Dim employeeValues, supplierValues, propernameValues, tireValues As New ColumnValues
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

    'CRUD
    Public Function save_withdrawal_info(ws_info As PropsFields.Create_withdrawal_slip_for_dr_props_fields,
                                    Optional sqlCon As SQLcon = Nothing,
                                    Optional transaction As SqlTransaction = Nothing) As Integer
        Try

            With ws_info

                Dim cc As New ColumnValuesObj

                cc.add("po_date", .ws_date)
                cc.add("rs_no", .rs_no)
                'cc.add("date_needed", .date_needed)
                cc.add("checked_by", .withdrawn_by)
                cc.add("approved_by", .released_by)
                cc.add("user_id", .user_id)
                cc.add("date_log", Date.Parse(Now))
                cc.add("dr_option", .dr_option)
                cc.add("remarks", .remarks)

                save_withdrawal_info = cc.insertQueryRollBack_and_return_id("dbPO", sqlCon, transaction)
            End With

            Return save_withdrawal_info

        Catch ex As Exception
            If transaction IsNot Nothing Then
                transaction.Rollback()
            End If
            customMsg.ErrorMessage(ex)
        End Try

    End Function

    Public Function save_withdrawal_details(ws_info_id As Integer, ws_details As PropsFields.Create_withdrawal_slip_for_dr_props_fields,
                                            Optional sqlCon As SQLcon = Nothing,
                                            Optional transaction As SqlTransaction = Nothing) As Integer

        Try

            With ws_details

                Dim cc As New ColumnValuesObj

                cc.add("po_id", ws_info_id)
                cc.add("supplier_id", .supplier_id)
                cc.add("po_no", .ws_no)
                cc.add("terms", "N/A")
                cc.add("qty", .ws_qty)
                cc.add("unit", .unit)
                cc.add("unit_price", .price)
                cc.add("rs_id", .rs_id)
                cc.add("selected", "TRUE")

                save_withdrawal_details = cc.insertQueryRollBack_and_return_id("dbPO_details", sqlCon, transaction)
            End With

            Return save_withdrawal_details

        Catch ex As Exception
            If transaction IsNot Nothing Then
                transaction.Rollback()
            End If

            customMsg.ErrorMessage(ex)
        End Try


    End Function

    Public Function update_withdrawal_info(ws_info As PropsFields.Create_withdrawal_slip_for_dr_props_fields,
                                    Optional sqlCon As SQLcon = Nothing,
                                    Optional transaction As SqlTransaction = Nothing) As Boolean

        Try

            With ws_info

                Dim cc As New ColumnValuesObj

                cc.add("po_date", .ws_date)
                cc.add("rs_no", .rs_no)
                'cc.add("date_needed", .date_needed)
                cc.add("checked_by", .withdrawn_by)
                cc.add("approved_by", .released_by)
                'cc.add("user_id", .user_id)
                cc.add("date_log_updated", Date.Parse(Now))
                cc.add("dr_option", .dr_option)
                cc.add("remarks", .remarks)

                cc.setCondition($"po_id = { .ws_info_id}")

                update_withdrawal_info = cc.updateQueryRollBack_and_return_true("dbPO", sqlCon, transaction)
            End With

            Return update_withdrawal_info

        Catch ex As Exception
            If transaction IsNot Nothing Then
                transaction.Rollback()
            End If
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Public Function update_withdrawal_details(ws_info As PropsFields.Create_withdrawal_slip_for_dr_props_fields,
                                    Optional sqlCon As SQLcon = Nothing,
                                    Optional transaction As SqlTransaction = Nothing) As Boolean

        Try

            With ws_info

                Dim cc As New ColumnValuesObj

                cc.add("po_no", .ws_no)
                cc.add("terms", "N/A")
                cc.add("qty", .ws_qty)
                cc.add("unit", .unit)
                cc.add("unit_price", .price)
                cc.add("selected", "TRUE")
                cc.add("user_id_update_logs", .user_id)
                cc.setCondition($"po_det_id = { .ws_id}")

                update_withdrawal_details = cc.updateQueryRollBack_and_return_true("dbPO_details", sqlCon, transaction)
            End With

            Return update_withdrawal_details

        Catch ex As Exception
            If transaction IsNot Nothing Then
                transaction.Rollback()
            End If
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
End Class
