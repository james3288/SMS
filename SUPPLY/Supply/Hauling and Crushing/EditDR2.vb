Public Class EditDR2

    Public whatToEdit As String
    Public editedValue As String

    Dim cBgWorkerChecker As Timer
    Private operatorModel, supplierModel, employeeModel, chargesInfoModel As New ModelNew.Model
    Private searchUI, dateUI As New class_placeholder4
    Private customMsg As New customMessageBox

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        If customMsg.messageYesNo("Are you sure you want update selected items?", "SUPPLY INFO:") Then

            For Each row As ListViewItem In FDRLIST2.lvl_drList.Items
                If row.Selected Then
                    Dim drInfoId As Integer = row.SubItems(14).Text

                    update_specific_column_from_dr(row.Index,
                                                   row.Text,
                                                   whatToEdit,
                                                   drInfoId)
                End If
            Next

            'customMsg.message("info", "dr/ws date was successfully updated!", "SUPPLY INFO:")
            Me.Dispose()
        End If
    End Sub

    Private Sub EditDR2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        searchUI.king_placeholder_textbox(whatToEdit, txtSearch, Nothing, Panel1, My.Resources.received,)
        dateUI.king_placeholder_datepicker(whatToEdit, dtpDate, Panel1, My.Resources.received)

        Select Case whatToEdit
            Case cDrSearchBy.DRIVER
                Dim cv As New ColumnValues

                operatorModel.clearParameter()
                loadingPanel.Visible = True

                _initializing(cCol.forOperatorDriver, cv.getValues(), operatorModel, drBgWorker)
                cBgWorkerChecker = BgWorkersCheckerFn(AddressOf SuccessfullyDone, drBgWorker)

            Case cDrSearchBy.SUPPLIER
                Dim cv As New ColumnValues

                supplierModel.clearParameter()
                loadingPanel.Visible = True

                _initializing(cCol.forSupplier, cv.getValues(), supplierModel, drBgWorker)
                cBgWorkerChecker = BgWorkersCheckerFn(AddressOf SuccessfullyDone, drBgWorker)

            Case "price", cDrSearchBy.QTY
                searchUI.set_numbers_only(True)
                dtpDate.Enabled = False
                searchUI.tbox.Text = editedValue

            Case cDrSearchBy.RECEIVED_BY, cDrSearchBy.CHECKED_BY
                Dim cv As New ColumnValues

                employeeModel.clearParameter()
                loadingPanel.Visible = True

                _initializing(cCol.forEmployees, cv.getValues(), employeeModel, drBgWorker)
                cBgWorkerChecker = BgWorkersCheckerFn(AddressOf SuccessfullyDone, drBgWorker)

            Case cDrSearchBy.CHARGES_INFO, cDrSearchBy.PLATE_NO

                Dim cv As New ColumnValues

                chargesInfoModel.clearParameter()
                loadingPanel.Visible = True

                _initializing(cCol.forChargesInfo, cv.getValues(), chargesInfoModel, drBgWorker)
                cBgWorkerChecker = BgWorkersCheckerFn(AddressOf SuccessfullyDone, drBgWorker)

            Case cDrSearchBy.DR_WS_DATE, cDrSearchBy.DATE_SUBMITTED, cDrSearchBy.DATE_LOG

                searchUI.tbox.Enabled = False
                dtpDate.Enabled = True
                dtpDate.Text = IIf(editedValue = "", Date.Parse(Now), editedValue)

            Case cDrSearchBy.CONSESSION, cDrSearchBy.DRNO, cDrSearchBy.REMARKS
                searchUI.tbox.Enabled = True
                dtpDate.Enabled = False
                searchUI.tbox.Text = editedValue

        End Select
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Dispose()
    End Sub


    Private Sub SuccessfullyDone()

        Select Case whatToEdit
            Case cDrSearchBy.DRIVER

                cListOfOperatorDriver = TryCast(operatorModel.cData, List(Of PropsFields.operator_driver_props_fields))
                searchUI.AutoCompleteData = cListOfOperatorDriver.Select(Function(x) x.operator_name).ToList()
                searchUI.tbox.Text = editedValue

                dtpDate.Enabled = False

            Case cDrSearchBy.SUPPLIER

                cListOfSupplier = TryCast(supplierModel.cData, List(Of PropsFields.supplier_props_fields))
                searchUI.AutoCompleteData = cListOfSupplier.Select(Function(x) x.supplierName).ToList()
                searchUI.tbox.Text = editedValue


                dtpDate.Enabled = False

            Case cDrSearchBy.RECEIVED_BY, cDrSearchBy.CHECKED_BY

                cListOfEmployees = TryCast(employeeModel.cData, List(Of PropsFields.employee_props_fields))
                searchUI.AutoCompleteData = cListOfEmployees.Select(Function(x) x.employee).ToList()
                searchUI.tbox.Text = editedValue

                dtpDate.Enabled = False

            Case cDrSearchBy.CHARGES_INFO

                cListOfChargesInfo = TryCast(chargesInfoModel.cData, List(Of PropsFields.charges_info_props_fields))
                searchUI.AutoCompleteData = cListOfChargesInfo.Select(Function(x) x.charges_desc).ToList()
                searchUI.tbox.Text = editedValue

                dtpDate.Enabled = False

            Case cDrSearchBy.PLATE_NO

                cListOfChargesInfo = TryCast(chargesInfoModel.cData, List(Of PropsFields.charges_info_props_fields))
                searchUI.AutoCompleteData = cListOfChargesInfo.Where(Function(x) x.category = "EQUIPMENT").Select(Function(x) x.charges_desc).ToList()
                searchUI.tbox.Text = editedValue

                dtpDate.Enabled = False



        End Select

        searchUI.set_autocomplete()

        loadingPanel.Visible = False
    End Sub

    Private Sub update_specific_column_from_dr(rowindex As Integer,
                                               dr_item_id As Integer,
                                               whatcolumn As String,
                                               Optional drInfoId As Integer = 0)

        Dim defaultLeftJoin As String = "LEFT JOIN dbDeliveryReport_items b ON b.dr_info_id = a.dr_info_id"
        Dim firstTable As String = "dbDeliveryReport_info"
        Try
            Select Case whatcolumn
                Case cDrSearchBy.DR_WS_DATE

                    Dim cv As New ColumnValuesObj

                    cv.setCondition($"dr_items_id = {dr_item_id}")
                    cv.addJoinClause(defaultLeftJoin)

                    cv.parameterToUpdate("date", Date.Parse(dtpDate.Value))

                    cv.updateQuery(firstTable, True)

                    updateSelectedItemsInListView(rowindex, 3, Format(Date.Parse(dtpDate.Text), "MM/dd/yyyy"), dr_item_id)


                Case cDrSearchBy.DRIVER

                    Dim selected = cListOfOperatorDriver.Where(Function(x) $"{x.operator_name.ToUpper()}" = txtSearch.Text.ToUpper()).Select(Function(x) x.operator_id).ToList()
                    Dim operator_id As Integer

                    If selected.Count > 0 Then
                        operator_id = selected(0)
                    End If

                    Dim cv As New ColumnValuesObj

                    cv.setCondition($"dr_items_id = {dr_item_id}")
                    cv.addJoinClause(defaultLeftJoin)


                    If operator_id = 0 Then
                        If customMsg.messageYesNo("Operator/Driver was not found in the database," & vbCrLf & "if you want to continue, kindly click yes to save outsource driver!", "SUPPLY INFO") Then
                            cv.parameterToUpdate("operator_outsource", txtSearch.Text)
                            cv.parameterToUpdate("operator_id", 0)
                        Else
                            Exit Sub
                        End If
                    Else
                        cv.parameterToUpdate("operator_id", operator_id)
                    End If

                    cv.updateQuery(firstTable, True)

                    updateSelectedItemsInListView(rowindex, 9, txtSearch.Text, dr_item_id)

                Case "price"

                    If isOutWithoutDr(rowindex) Then
                        Dim msg As String = "The item you are editing is classified as a withdrawal without a DR. To update the price, please use the Withdrawal List form"
                        customMsg.message("error", msg, "SMS INFO:")
                        Exit Sub
                    End If

                    Dim price As Double = ifBlankReplaceToZero(txtSearch.Text)
                    updatePriceBy(drInfoId, price, rowindex)

                    'customMsg.message("warning", "this transaction is temporarily disabled...", "SUPPLY INFO:")

                    'With FDRLIST2
                    '    If .lvl_drList.Items(rowindex).SubItems(16).Text = "OUT" Then
                    '        If .lvl_drList.Items(rowindex).BackColor = Color.LightGreen Then
                    '            'Intended for editing price ddto sa withdrawal
                    '            Dim po_det_id As Integer = dr_item_id

                    '            MessageBox.Show("The item that you've trying to edit is from withdrawal." & vbCrLf & "You may go to withdrawal form " & vbCrLf & "or select the withdrawal rows to edit the data.", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    '            Exit Sub
                    '        Else
                    '            Dim cv As New ColumnValuesObj
                    '            cv.setCondition($"dr_items_id = {dr_item_id}")
                    '            cv.addJoinClause(defaultLeftJoin)

                    '            cv.parameterToUpdate("price", CDbl(txtSearch.Text))

                    '            cv.updateQuery(firstTable, True)

                    '            updateSelectedItemsInListView(rowindex, 27, txtSearch.Text, dr_item_id)
                    '            .lvl_drList.Items(rowindex).SubItems(28).Text = FormatNumber(CDbl(.lvl_drList.Items(rowindex).SubItems(26).Text) * CDbl(.lvl_drList.Items(rowindex).SubItems(27).Text), 2,, TriState.True)

                    '        End If
                    '    Else

                    '    End If
                    'End With


                Case cDrSearchBy.RECEIVED_BY
                    Dim cv As New ColumnValuesObj

                    cv.setCondition($"dr_items_id = {dr_item_id}")
                    cv.addJoinClause(defaultLeftJoin)

                    cv.parameterToUpdate("receivedby", txtSearch.Text)

                    cv.updateQuery(firstTable, True)

                    updateSelectedItemsInListView(rowindex, 13, txtSearch.Text, dr_item_id)

                Case cDrSearchBy.CHECKED_BY
                    Dim cv As New ColumnValuesObj

                    cv.setCondition($"dr_items_id = {dr_item_id}")
                    cv.addJoinClause(defaultLeftJoin)

                    cv.parameterToUpdate("checkedBy", txtSearch.Text)

                    cv.updateQuery(firstTable, True)

                    updateSelectedItemsInListView(rowindex, 12, txtSearch.Text, dr_item_id)

                Case cDrSearchBy.CONSESSION
                    Dim cv As New ColumnValuesObj

                    cv.setCondition($"dr_items_id = {dr_item_id}")
                    cv.addJoinClause(defaultLeftJoin)

                    cv.parameterToUpdate("concession_ticket_no", txtSearch.Text)

                    cv.updateQuery(firstTable, True)

                    updateSelectedItemsInListView(rowindex, 8, txtSearch.Text, dr_item_id)

                Case cDrSearchBy.DRNO
                    Dim cv As New ColumnValuesObj

                    cv.setCondition($"dr_items_id = {dr_item_id}")
                    'cv.addJoinClause(defaultLeftJoin)

                    cv.parameterToUpdate("dr_no", txtSearch.Text)

                    cv.updateQuery("dbDeliveryReport_items", False)

                    updateSelectedItemsInListView(rowindex, 1, txtSearch.Text, dr_item_id)

                Case cDrSearchBy.DATE_SUBMITTED
                    Dim cv As New ColumnValuesObj

                    cv.setCondition($"dr_items_id = {dr_item_id}")
                    cv.addJoinClause(defaultLeftJoin)

                    cv.parameterToUpdate("date_submitted", Date.Parse(dtpDate.Value))

                    cv.updateQuery(firstTable, True)

                    updateSelectedItemsInListView(rowindex, 37, Format(Date.Parse(dtpDate.Text), "MM/dd/yyyy"), dr_item_id)

                Case cDrSearchBy.REMARKS
                    Dim cv As New ColumnValuesObj

                    cv.setCondition($"dr_items_id = {dr_item_id}")
                    cv.addJoinClause(defaultLeftJoin)

                    cv.parameterToUpdate("remarks", txtSearch.Text)

                    cv.updateQuery(firstTable, True)

                    updateSelectedItemsInListView(rowindex, 21, txtSearch.Text, dr_item_id)

                Case cDrSearchBy.SUPPLIER
                    Dim selected = cListOfSupplier.Where(Function(x) $"{x.supplierName.ToUpper()}" = txtSearch.Text.ToUpper()).Select(Function(x) x.supplier_id).ToList()
                    Dim supplier_id As Integer

                    If selected.Count > 0 Then
                        supplier_id = selected(0)
                    Else
                        customMsg.message("error", "No supplier has been found in the database, kindly check the spelling or naming!", "SUPPLY INFO:")
                        Exit Sub
                    End If

                    Dim cv As New ColumnValuesObj
                    cv.setCondition($"dr_items_id = {dr_item_id}")
                    cv.addJoinClause(defaultLeftJoin)

                    cv.parameterToUpdate("supplier_id", supplier_id)

                    cv.updateQuery(firstTable, True)

                    updateSelectedItemsInListView(rowindex, 22, txtSearch.Text, dr_item_id)

                Case cDrSearchBy.QTY

                    Dim inout As String = FDRLIST2.lvl_drList.SelectedItems(0).SubItems(FDRLIST2.col_inout.Index).Text

                    Dim cv As New ColumnValuesObj
                    cv.setCondition($"dr_items_id = {dr_item_id}")
                    cv.parameterToUpdate("qty", CDbl(txtSearch.Text))

                    cv.updateQuery("dbDeliveryReport_items", False)

                    updateSelectedItemsInListView(rowindex,
                                                  IIf(inout = cInOut._OUT,
                                                      FDRLIST2.col_qty_out.Index,
                                                      FDRLIST2.col_qty_in_others.Index),
                                                  txtSearch.Text,
                                                  dr_item_id)

                Case cDrSearchBy.PLATE_NO

                    Dim equipments = cListOfChargesInfo.FirstOrDefault(Function(x)
                                                                           Return x.category = "EQUIPMENT" And
                                                                           x.charges_desc.ToUpper() = txtSearch.Text.ToUpper()
                                                                       End Function)

                    If equipments IsNot Nothing Then
                        Dim cv As New ColumnValuesObj

                        cv.setCondition($"dr_items_id = {dr_item_id}")
                        cv.addJoinClause(defaultLeftJoin)

                        If equipments.charges_id = 0 Then
                            If customMsg.messageYesNo("plateNo was not found in the database," & vbCrLf & "if you want to continue, kindly click yes to save outsource plate No!", "SUPPLY INFO") Then
                                cv.parameterToUpdate("plate_no_outsource", txtSearch.Text)
                                cv.parameterToUpdate("equipListID", 0)
                            Else
                                Exit Sub
                            End If
                        Else
                            cv.parameterToUpdate("equipListID", equipments.charges_id)
                        End If

                        cv.updateQuery(firstTable, True)

                        updateSelectedItemsInListView(rowindex, 24, txtSearch.Text, dr_item_id)
                    End If
                    'If selected.Count > 0 Then
                    '    operator_id = selected(0)
                    'End If


            End Select


        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

    End Sub

    Private Sub updateSelectedItemsInListView(rowIndex As Integer, colIndex As Integer, values As String, idToFocus As Integer)

        With FDRLIST2
            .lvl_drList.Items(rowIndex).SubItems(colIndex).Text = values
            listfocus(FDRLIST2.lvl_drList, idToFocus)
        End With


    End Sub




    Private Sub EditDR2_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Me.Dispose()
    End Sub

#Region "UTILITIES"

    Private Sub setPriceAndTotalAmount(rowIndex As Integer,
                                       columnIndex As Integer,
                                       qty As Double,
                                       price As Double)
        Try
            With FDRLIST2
                .lvl_drList.Items(rowIndex).SubItems(columnIndex).Text = FormatNumber(qty * price, 2,, TriState.True)
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Function isOutWithoutDr(rowIndex As Integer) As Boolean
        Try
            Dim row = FDRLIST2.lvl_drList.Items(rowIndex)

            If row.SubItems(16).Text = cInOut._OUT And
                row.BackColor = Color.LightGreen Then

                Return True
            End If

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function


    Private Sub setPriceTotalAmountColumnBy(rowIndex As Integer, price As Double)
        Try
            With FDRLIST2
                Dim qty_in_others As Double = ifBlankReplaceToZero(.lvl_drList.Items(rowIndex).SubItems(6).Text)
                Dim qty_out As Double = ifBlankReplaceToZero(.lvl_drList.Items(rowIndex).SubItems(26).Text)
                'Dim price As Double = ifBlankReplaceToZero(.lvl_drList.Items(rowIndex).SubItems(27).Text)
                Dim inOut As String = .lvl_drList.Items(rowIndex).SubItems(16).Text

                Select Case inOut
                    Case cInOut._OTHERS, cInOut._IN
                        .lvl_drList.Items(rowIndex).SubItems(27).Text = price
                        setPriceAndTotalAmount(rowIndex, 28, qty_in_others, price)

                    Case cInOut._OUT
                        .lvl_drList.Items(rowIndex).SubItems(27).Text = price
                        setPriceAndTotalAmount(rowIndex, 28, qty_out, price)
                End Select

            End With

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
#End Region

#Region "CRUD"
    Private Sub updatePriceBy(drInfoId As Integer, price As Double, Optional rowIndex As Integer = 0)
        Try
            Dim updatePrice As New ColumnValuesObj
            updatePrice.add("price", price)
            updatePrice.setCondition($"dr_info_id = {drInfoId}")

            Dim result As Boolean = updatePrice.updateQuery_return_true("dbDeliveryReport_info")

            setPriceTotalAmountColumnBy(rowIndex, price)
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

    End Sub
#End Region
End Class