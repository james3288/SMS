Public Class WithdrawalListModel
    Private cListView As New ListView
    Private cDgv As New DataGridView
    Private cSearchBy As String
    Private cSearch As String
    Private cDateFrom As DateTime
    Private cDateTo As DateTime

    Private customMsg As New customMessageBox
    Private cLoadingPanel As New Panel

    Private serialNoViewModel,
        whItemsModel,
        employeesModel,
        withdrawalModel,
        withdrawnModel,
        partiallyWithdrawnModel As New ModelNew.Model

    Private cListOfTireSerial As New List(Of PropsFields.tireSerialView_props_fields)
    Private cListOfWarehouseItems As New List(Of PropsFields.whItems_props_fields)
    Private cListOfEmployees As New List(Of PropsFields.employee_props_fields)
    Private cListOfWithdrawal As New List(Of PropsFields.withdrawal_props_fields)
    Private cListOfWithdrawnItems As New List(Of PropsFields.withdrawn_props_fields)
    Private cListOfPartiallyWithdrawn As New List(Of PropsFields.partiallyWithdrawn_props_fields)
    Private cListOfWithdrawalFinal As New List(Of COLUMNS)

    Private cBgWorkerChecker, cBgWorkerChecker2 As New Timer
    Public cSearchByEnum As New searchByEnum

#Region "ENTITIES"
    Public Class searchByEnum
        Public ReadOnly Property search_by_ws_no As String = "Search by WS No."
        Public ReadOnly Property search_by_rs_no As String = "Search by RS No."
        Public ReadOnly Property search_by_charges As String = "Search by Charges"
        Public ReadOnly Property search_by_items As String = "Search by Items"
        Public ReadOnly Property search_by_users As String = "Search by Users"
        Public ReadOnly Property search_by_withdrawn_by As String = "Search by withdrawn by"
        Public ReadOnly Property search_released_by As String = "Search by released by"
        Public ReadOnly Property search_by_date_issued As String = "Search by Date Issued"
        Public ReadOnly Property search_by_date_withdrawn As String = "Search by Date Withdrawn"
        Public ReadOnly Property search_by_issued_by As String = "Search by Issued by"
        Public ReadOnly Property search_by_received_by As String = "Search by Received by"
        Public ReadOnly Property search_by_released_by As String = "Search by Released by"
    End Class

    Public Class COLUMNS
        Inherits PropsFields.withdrawal_props_fields
        Public Property level As String

    End Class
#End Region
#Region "INITIALIZE"
    Public Sub initialize_loadingPanel(loadingPanel As Panel)
        Try
            cLoadingPanel = loadingPanel
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
    Public Sub initialize_listview(lvl As ListView)
        cListView = lvl
    End Sub
    Public Sub initialize_dataGridView(dgv As DataGridView)
        cDgv = dgv
    End Sub
    Public Sub initialize_search(searchBy As String, search As String)
        Try
            cSearchBy = searchBy
            cSearch = search
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
    Private Sub initialize_searchBy()
        Dim values As New ColumnValues
        values.add("searchby", cSearchBy)
        values.add("search", cSearch)
        values.add("nn", "true")

        Select Case cSearchBy
            Case cSearchByEnum.search_by_date_issued,
             cSearchByEnum.search_by_issued_by,
             cSearchByEnum.search_by_received_by,
             cSearchByEnum.search_by_released_by,
             cSearchByEnum.search_by_date_withdrawn,
             cSearchByEnum.search_by_date_issued

                values.add("date_range", "true")
                values.add("datefrom", cDateFrom)
                values.add("dateto", cDateTo)

        End Select

        _initializing(cCol.forWithdrawal,
          values.getValues(),
          withdrawalModel,
          withdrawalBgWorker)

        _initializing(cCol.forPartiallyWithdrawn,
                        values.getValues(),
                        partiallyWithdrawnModel,
                        withdrawalBgWorker)

        _initializing(cCol.forWithdrawn,
                         values.getValues(),
                         withdrawnModel,
                         withdrawalBgWorker)

    End Sub
    Public Sub initialize_data()
        Try
            cLoadingPanel.Visible = True

            Dim serialNoValues, whItemValues, employeeValues As New ColumnValues

            _initializing(cCol.forTireSerialNoView,
                                   serialNoValues.getValues(),
                                   serialNoViewModel,
                                   withdrawalListBgWorker)

            _initializing(cCol.forWhItems,
                   whItemValues.getValues(),
                   whItemsModel,
                   withdrawalListBgWorker)

            _initializing(cCol.forEmployees,
                          employeeValues.getValues(),
                          employeesModel,
                          withdrawalListBgWorker)

            cBgWorkerChecker = BgWorkersCheckerFn(AddressOf initialize_data_done, withdrawalListBgWorker)

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
#End Region

#Region "SUCCESSFULLY DONE"
    Private Sub initialize_data_done()
        Try
            cLoadingPanel.Visible = True

            cListOfWarehouseItems = CType(whItemsModel.cData, List(Of PropsFields.whItems_props_fields))
            cListOfTireSerial = TryCast(serialNoViewModel.cData, List(Of PropsFields.tireSerialView_props_fields))
            cListOfEmployees = CType(employeesModel.cData, List(Of PropsFields.employee_props_fields))

            cLoadingPanel.Visible = False
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub searchBy_done()
        Try
            cListOfWithdrawal = CType(withdrawalModel.cData, List(Of PropsFields.withdrawal_props_fields))
            cListOfWithdrawnItems = CType(withdrawnModel.cData, List(Of PropsFields.withdrawn_props_fields))
            cListOfPartiallyWithdrawn = CType(partiallyWithdrawnModel.cData, List(Of PropsFields.partiallyWithdrawn_props_fields))

            cLoadingPanel.Visible = False

            previewToDataGridView()
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
#End Region

#Region "LOGIC"
    Public Sub execute_searchBy()
        Try
            cLoadingPanel.Visible = True
            initialize_searchBy()
            cBgWorkerChecker2 = BgWorkersCheckerFn(AddressOf searchBy_done, withdrawalBgWorker)

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Function withdrawal_logic()
        Try
            For Each row In cListOfWithdrawal
                withdrawal_row(row)
            Next

            cDgv.DataSource = cListOfWithdrawalFinal
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function


#End Region

#Region "ROWS"
    Private Sub withdrawal_row(row As PropsFields.withdrawal_props_fields)
        Try

            Dim withdrawalStorage As New COLUMNS

            With withdrawalStorage
                .ws_id = row.ws_id
                .ws_no = row.ws_no
                .rs_no = row.rs_no
                .ws_date = row.ws_date
                .item_name = row.item_name
                .ws_qty = row.ws_qty
                .unit = row.unit
                .unit_price = Utilities.ifBlankReplaceToZero(row.unit_price)
                .amount = FormatNumber(Utilities.ifBlankReplaceToZero(row.amount), 2,, TriState.True)
                .item_desc = row.item_desc
                .withdrawn_from = row.withdrawn_from
                .withdrawn_by = row.withdrawn_by
                .released_by = row.released_by
                .charges = row.charges
                .ws_info_id = row.ws_info_id
                .rs_id = row.rs_id
                .wh_id = row.wh_id
                .remarks = row.remarks
                .dr_option = row.dr_option
                .purpose = row.purpose
                .issued_by = row.issued_by
                .users = row.users
                .division = row.division
                .serial_id = row.serial_id
                .tire_category = row.tire_category
                .level = "parent"

                Dim withdrawnData = cListOfWithdrawnItems.FirstOrDefault(Function(x) x.ws_id = row.ws_id)

                If withdrawnData IsNot Nothing Then
                    .status = IIf(withdrawnData?.status = "", "- released", "- withdrawn")
                    .withdrawn_id = withdrawnData?.withdrawn_id
                End If

            End With

            cListOfWithdrawalFinal.Add(withdrawalStorage)

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
#End Region

#Region "PREVIEW"
    Private Sub previewToListView()
        Try

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub previewToDataGridView()
        Try
            withdrawal_logic()
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
#End Region


End Class
