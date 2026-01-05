Imports CrystalDecisions
Imports OfficeOpenXml.ExcelErrorValue
Imports SUPPLY.PropsFields

Public Class CreateRsModel

    Private customMsg As New customMessageBox
    Private TypeOfRequestModel,
        ConsolidationAccountModel,
        employeeModel,
        ProperNamingModel,
        RsLocationModel As New ModelNew.Model

    Dim cBgWorkerChecker As Timer
    Private cListOfTypeOfRequest As New List(Of PropsFields.TypeOfRequest)
    Private cListOfConsolidationAccount As New List(Of PropsFields.Consolidated_Account)
    Private cListOfEmployees As New List(Of PropsFields.employee_props_fields)
    Private cListOfUI As New List(Of class_placeholder5)
    Private cListOfProperNaming As New List(Of PropsFields.whItems_properName_fields)
    Private cListOfRsLocations As New List(Of String)
    Private cLoadingPanel As New Panel
    Private cTypeOfRequestComboBox As New ComboBox
    Private cTypeOfRequestSubComboBox As New ComboBox
    Private cConsolidationAccountSubComboBox As New ComboBox
    Private cUnitsUI, cLocationUI As New class_placeholder5

    'GET
    Public ReadOnly Property getTypeOfRequest() As List(Of PropsFields.TypeOfRequest)
        Get
            Return cListOfTypeOfRequest
        End Get

    End Property
    Public ReadOnly Property getConsolidationAccount() As List(Of PropsFields.Consolidated_Account)
        Get
            Return cListOfConsolidationAccount
        End Get

    End Property
    Public ReadOnly Property getEmployees() As List(Of PropsFields.employee_props_fields)
        Get
            Return cListOfEmployees
        End Get

    End Property
    Public ReadOnly Property getProperNaming() As List(Of PropsFields.whItems_properName_fields)
        Get
            Return cListOfProperNaming
        End Get

    End Property

    'execute
    Public Sub execute(Optional loadingPanel As Panel = Nothing)
        Try
            cLoadingPanel = loadingPanel
            loadDatas()
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    'initialize
    Public Sub initialize_typeOfRequest(typeOfRequestCmb As ComboBox)
        Try
            cTypeOfRequestComboBox = typeOfRequestCmb
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
    Public Sub initialize_typeOfRequestSub(typeOfRequestSubCmb As ComboBox)
        Try
            cTypeOfRequestSubComboBox = typeOfRequestSubCmb
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

    End Sub
    Public Sub initialize_consolidationAccount(consolidationCmb As ComboBox)
        Try
            cConsolidationAccountSubComboBox = consolidationCmb
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

    End Sub
    Public Sub initialize_employeesData(ui As class_placeholder5)
        cListOfUI.Add(ui)
    End Sub
    Public Sub initialize_units(ui As class_placeholder5)
        cUnitsUI = ui
    End Sub

    Public Sub initialize_location(ui As class_placeholder5)
        cLocationUI = ui
    End Sub

    Private Sub loadDatas()
        Try
            Dim cv, employeeValues, propernameValues, rsLocationValues As New ColumnValues
            cv.add("crud", 7)
            cv.add("search", "")

            clear()
            cLoadingPanel.Visible = True

            _initializing(cCol.forTypeOfRequest,
                     cv.getValues(),
                     TypeOfRequestModel,
                     createRsBgWorker)

            _initializing(cCol.forConsolidationAccount,
                      cv.getValues(),
                      ConsolidationAccountModel,
                      createRsBgWorker)

            _initializing(cCol.forEmployees,
                      employeeValues.getValues(),
                      employeeModel,
                      createRsBgWorker)

            _initializing(cCol.forWhItem_ProperNames,
                          propernameValues.getValues(),
                          ProperNamingModel,
                          createRsBgWorker)

            _initializing(cCol.forRsLocations,
                          rsLocationValues.getValues(),
                          RsLocationModel,
                          createRsBgWorker)

            cBgWorkerChecker = BgWorkersCheckerFn(AddressOf SuccessfullyDone, createRsBgWorker)
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    'clear
    Private Sub clear()
        Try
            cListOfTypeOfRequest.Clear()
            cListOfConsolidationAccount.Clear()
            cListOfEmployees.Clear()
            cListOfRsLocations.Clear()

            TypeOfRequestModel.clearParameter()
            ConsolidationAccountModel.clearParameter()
            employeeModel.clearParameter()
            ProperNamingModel.clearParameter()
            RsLocationModel.clearParameter()


        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    'successfully done
    Private Sub SuccessfullyDone()
        Try
            cListOfTypeOfRequest = TryCast(TypeOfRequestModel.cData, List(Of PropsFields.TypeOfRequest))
            cListOfConsolidationAccount = TryCast(ConsolidationAccountModel.cData, List(Of PropsFields.Consolidated_Account))
            cListOfEmployees = TryCast(employeeModel.cData, List(Of PropsFields.employee_props_fields))
            cListOfProperNaming = TryCast(ProperNamingModel.cData, List(Of PropsFields.whItems_properName_fields))
            cListOfRsLocations = TryCast(RsLocationModel.cData, List(Of String))

            cLoadingPanel.Visible = False

            loadTypeOfRequest()
            loadEmployee()
            loadUnits()
            loadLocations()
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    'load to ui
    Private Sub loadTypeOfRequest()

        Try
            cTypeOfRequestComboBox.Items.Clear()
            For Each row In cListOfTypeOfRequest.Select(Function(x) x.tor_desc).Distinct().ToList()
                cTypeOfRequestComboBox.Items.Add(row)
            Next

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub loadEmployee()
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
            For Each row In cListOfProperNaming
                l.Add(row.units)
            Next

            cUnitsUI.AutoCompleteData = l
            cUnitsUI.set_autocomplete()

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub loadLocations()
        Try
            Dim l As New List(Of String)
            For Each location In cListOfRsLocations
                l.Add(location)
            Next

            cLocationUI.AutoCompleteData = l
            cLocationUI.set_autocomplete()

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Public Sub loadTypeOfRequestSub(typeOfRequest As String)
        cTypeOfRequestSubComboBox.Items.Clear()

        For Each row In cListOfTypeOfRequest.Where(Function(x) x.tor_desc.ToUpper() = typeOfRequest.ToUpper()).ToList()
            cTypeOfRequestSubComboBox.Items.Add(row.tor_sub_desc)
        Next
    End Sub

    Public Sub loadConsolidationAccount(tor_sub_id As Integer)
        cConsolidationAccountSubComboBox.Items.Clear()

        For Each row In cListOfConsolidationAccount.Where(Function(x) x.tor_sub_id = tor_sub_id).ToList()
            cConsolidationAccountSubComboBox.Items.Add($"{row.category} ({row.codes})")
        Next

        cConsolidationAccountSubComboBox.SelectedIndex = -1
    End Sub


    'hooks 
    Public Sub ErrorMessage(name As String)
        Try
            customMsg.message("error", $"{name} must not be empty!", "SUPPLY INFO:")

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Public Function get_tors_ca_id(typeOfRequest As String, typeOfRequestSub As String, consolidationAccount As String) As Integer
        Try
            Dim tor = cListOfTypeOfRequest.FirstOrDefault(Function(x) x.tor_desc.ToUpper() = typeOfRequest.ToUpper() And
                                                                                           x.tor_sub_desc.ToUpper() = typeOfRequestSub.ToUpper())

            Dim tor_sub_id As Integer
            If tor IsNot Nothing Then
                tor_sub_id = tor.tor_sub_id
            End If

            Dim consolidation = cListOfConsolidationAccount.FirstOrDefault(Function(x)
                                                                               Return x.tor_sub_id = tor_sub_id And
                                                                                           $"{x.category.ToUpper()} ({x.codes})".ToUpper() = consolidationAccount.ToUpper()
                                                                           End Function)
            If consolidation IsNot Nothing Then
                get_tors_ca_id = consolidation.tors_ca_id
                Return get_tors_ca_id
            End If

            Return 0
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Public Function get_tor_sub_id(typeOfRequest As String, typeOfRequestSub As String) As Integer
        Try
            Dim tor = cListOfTypeOfRequest.FirstOrDefault(Function(x) x.tor_desc.ToUpper() = typeOfRequest.ToUpper() And
                                                                                         x.tor_sub_desc.ToUpper() = typeOfRequestSub.ToUpper())
            If tor IsNot Nothing Then
                get_tor_sub_id = tor.tor_sub_id
            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    'CRUD
    Public Function save_requisition(rsData As PropsFields.Create_Requesition_Slip) As Integer
        Try

            With rsData

                Dim cc As New ColumnValuesObj
                cc.add($"rs_no", .rs_no)
                cc.add($"date_req", .rs_date)
                cc.add($"job_order_no", .job_order_no)
                cc.add($"location", .location)
                cc.add($"item_desc", .item_desc)
                cc.add($"qty", .rs_qty)
                cc.add("unit", .unit)
                cc.add($"typeRequest", .type_of_request)
                cc.add($"process", .process)
                cc.add($"purpose", .purpose)
                cc.add($"date_needed", .date_needed)
                cc.add($"requested_by", .requested_by)
                cc.add($"noted_by", .noted_by)
                cc.add("approved_by", "N/A")
                cc.add($"date_log", .date_log)
                cc.add($"remarks", 0)
                cc.add($"remarks1", "N/A")
                cc.add($"user_id", .user_id)
                cc.add("remarks_emd_purposed", .remarks_for_emd)
                cc.add($"wh_pn_id", .wh_pn_id_for_rs)

                save_requisition = cc.insertQuery_and_return_id("dbrequisition_slip")
            End With

            Return save_requisition

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

    End Function

    Public Function update_requisition(rsData As PropsFields.Create_Requesition_Slip) As Boolean
        Try
            customMsg.message("warning", "rs qty is not included in this update transaction, if you want to edit qty, go to Edit > Edit RS Qty", "SMS INFO:")

            With rsData

                Dim cc As New ColumnValuesObj
                cc.add($"rs_no", .rs_no)
                cc.add($"date_req", .rs_date)
                cc.add($"job_order_no", .job_order_no)
                cc.add($"location", .location)
                cc.add($"item_desc", .item_desc)
                'cc.add($"qty", .rs_qty)
                cc.add("unit", .unit)
                cc.add($"typeRequest", .type_of_request)
                cc.add($"process", .process)
                cc.add($"purpose", .purpose)
                cc.add($"date_needed", .date_needed)
                cc.add($"requested_by", .requested_by)
                cc.add($"noted_by", .noted_by)
                cc.add("approved_by", "N/A")
                cc.add($"date_log_updated", .date_log)
                cc.add($"remarks", 0)
                cc.add($"remarks1", "N/A")
                cc.add($"user_id_updated", .user_id)
                cc.add("remarks_emd_purposed", .remarks_for_emd)
                cc.add($"wh_pn_id", .wh_pn_id_for_rs)

                cc.setCondition($"rs_id = {rsData.rs_id}")

                update_requisition = cc.updateQuery_return_true("dbrequisition_slip")
            End With

            Return update_requisition

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

    End Function
    Public Function save_typeOfRequest(rs_id As Integer, tors_ca_id As Integer)
        Try
            Dim cc As New ColumnValuesObj
            cc.add("rs_id", rs_id)
            cc.add("tors_ca_id", tors_ca_id)

            save_typeOfRequest = cc.insertQuery_and_return_id("rs_tor_sub_property")

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Public Function save_typeOfRequest_sub_only(rs_id As Integer, tor_sub_id As Integer)
        Try
            Dim cc As New ColumnValuesObj
            cc.add("rs_id", rs_id)
            cc.add("tor_sub_id", tor_sub_id)

            save_typeOfRequest_sub_only = cc.insertQuery_and_return_id("rs_tor_sub_property")

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Public Function update_typeOfRequest(rs_id As Integer, tors_ca_id As Integer) As Boolean
        Try
            Dim cc As New ColumnValuesObj
            cc.add("tors_ca_id", tors_ca_id)
            cc.setCondition($"rs_id={rs_id}")

            update_typeOfRequest = cc.updateQuery_return_true("rs_tor_sub_property")

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Public Function update_typeOfRequest_without_accountTitleSub(rs_id As Integer, tor_sub_id As Integer) As Boolean
        Try
            Dim cc As New ColumnValuesObj
            cc.add("tor_sub_id", tor_sub_id)
            cc.add("tors_ca_id", 0)
            cc.setCondition($"rs_id={rs_id}")

            update_typeOfRequest_without_accountTitleSub = cc.updateQuery_return_true("rs_tor_sub_property")

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function
    Public Function save_charges(charges As PropsFields.AllCharges, Optional rs_id As Integer = 0) As Integer
        Try
            With charges
                Dim cc As New ColumnValuesObj
                cc.add($"all_charges_id", .charges_id)
                cc.add($"type_name", .charges_category)
                cc.add("rs_id", rs_id)
                cc.add("fi_id", 0)
                cc.add("createdAt", Date.Parse(Now))
                save_charges = cc.insertQuery_and_return_id("dbMultipleCharges")

            End With
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function
    Public Function remove_requesition(rsRow As RSDRModel.COLUMNS) As Boolean
        Try

            Dim lot As New ListOfTables
            lot.addTable("dbrequisition_slip", $"rs_id = {rsRow.rs_id}")
            lot.addTable("dbMultipleCharges", $"rs_id = {rsRow.rs_id}")

            Dim cc As New ColumnValuesObj
            cc.deleteDataUsingRollback(lot.getListOfTables)

            Return True
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
            Return False
        End Try

    End Function

#Region "UTILITIES"
    Public ReadOnly Property getConsolidationAccountByTorSubId(id As Integer) As List(Of PropsFields.Consolidated_Account)
        Get
            Return cListOfConsolidationAccount.Where(Function(x) x.tor_sub_id = id).ToList()
        End Get

    End Property
#End Region

End Class
