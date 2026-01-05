

Public Class FWithdrawnItems
    Public dateWithdrawnUI,
        releasedByUI,
        receivedByUI,
        partialQtyUI,
        amountUI,
        unitsUI,
        otherCategoryUI,
        tireSerialNoUI As New class_placeholder5

    Private employeeModel, withdrawalPriceModel As New ModelNew.Model
    Dim cBgWorkerChecker As Timer
    Private customMsg As New customMessageBox
    Private cRowColor As New FWithdrawalList.RowColor
    Public partiallyWithdrawnId As Integer
    Public saveStatus As Integer
    Public cWhId As Integer
    Public cEdit As Boolean
    Public isForTire As Boolean

    Private cListOfWithdrawalPrice As New List(Of PropsFields.withdrawal_props_fields)
    Public cPartiallyWithdrawnStorage As New PARTIALLY_WITHDRAWN_PROPS
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btnAddSerial.Click
        FTireSerial.forWithdrawn = True
        FTireSerial.ShowDialog()
    End Sub

    Private cOthersCategory As New OTHERSCATEGORY
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

#Region "CORE"
    Public Class PARTIALLY_WITHDRAWN_PROPS
        Public Property withdrawn_id As Integer
        Public Property partiallyWithdrawnId As Integer
        Public Property partialQty As Double
        Public Property releasedBy As String
        Public Property receivedBy As String
        Public Property status As String
        Public Property price As Double
        Public Property ws_id As Integer
        Public Property units As String
        Public Property serial_id As Integer
        Public Property dateWithdrawn As DateTime

    End Class
#End Region

    Private Sub FWithdrawnItems_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        dateWithdrawnUI.king_placeholder_datepicker("", dtpDateWithdrawn,
                                                    Panel8,
                                                    My.Resources.received)

        releasedByUI.king_placeholder_textbox("Released By...",
                                              txtReleasedBy,
                                              Nothing,
                                              Panel8,
                                              My.Resources.received,,
                                              releasedByUI.cCustomColor.Custom1)

        receivedByUI.king_placeholder_textbox("Received By...",
                                              txtReceived,
                                              Nothing,
                                              Panel8,
                                              My.Resources.received,,
                                              receivedByUI.cCustomColor.Custom1)

        partialQtyUI.king_placeholder_textbox("Partial Quantity...",
                                              txQtyPartiallyWithdrawn,
                                              Nothing,
                                              Panel8,
                                              My.Resources.received,
                                              True,
                                              partialQtyUI.cCustomColor.Custom1)

        amountUI.king_placeholder_textbox("Amount/Price...",
                                          txtAmount,
                                          Nothing, Panel8,
                                          My.Resources.received,
                                          True,
                                          amountUI.cCustomColor.Custom1)

        unitsUI.king_placeholder_textbox("Units...",
                                         txtUnits,
                                         Nothing,
                                         Panel8,
                                         My.Resources.received,
                                         False,
                                         unitsUI.cCustomColor.Custom1)



        tireSerialNoUI.king_placeholder_textbox("serial No...",
                                                txtSerialNo,
                                                Nothing,
                                                Panel8,
                                                My.Resources.received,
                                                False,
                                                tireSerialNoUI.cCustomColor.Custom1)



        employeeModel.clearParameter()

        Dim cv As New ColumnValues

        loadingPanel.Visible = True

        _initializing(cCol.forEmployees,
                      cv.getValues(),
                      employeeModel,
                      createWithdrawalBgWorker)

        Dim cv2 As New ColumnValues
        cv2.add("wh_id", cWhId)

        _initializing(cCol.forWithdrawalPrice,
                      cv2.getValues(),
                      withdrawalPriceModel,
                      createWithdrawalBgWorker)

        cBgWorkerChecker = BgWorkersCheckerFn(AddressOf SuccessfullyDone, createWithdrawalBgWorker)
    End Sub

    Private Sub btnWithdraw_Click(sender As Object, e As EventArgs) Handles btnWithdraw.Click
#Region "FILTER"
        If releasedByUI.ifBlankTexbox() Or
            receivedByUI.ifBlankTexbox() Or
            partialQtyUI.ifBlankTexbox() Then

            customMsg.message("error", "You must fillup some blank fields...", "SUPPLY INFO:")
            Exit Sub
        ElseIf amountUI.ifBlankTexbox() Then
            If Not saveStatus = SaveBtn.Update Then
                customMsg.message("error", "You must fillup some blank fields...", "SUPPLY INFO:")
                Exit Sub
            End If
        End If

#End Region

        'If FWithdrawalList.isForTire() Then
        '    FTireSerial.forCreateWithdrawal = True
        '    FTireSerial.ShowDialog()
        '    Exit Sub
        'End If

        Dim message As String = IIf(saveStatus = SaveBtn.Save,
                                    "Are you sure you want to withdraw this selected items?",
                                    "Are you sure you want to update this selected items?")
        Dim id As Integer

        If customMsg.messageYesNo(message, "SUPPLY INFO:") Then

            For Each row As ListViewItem In FWithdrawalList.lvlwithdrawalList.Items
                If row.Selected Then

#Region "INITIALIZE"
                    Dim ws_info_id As Integer = ifBlankReplaceToZero(row.SubItems(15).Text)
                    Dim ws_id As Integer = ifBlankReplaceToZero(row.Text)
                    Dim rs_id As Integer = ifBlankReplaceToZero(row.SubItems(16).Text)
                    Dim selectedWithdrawnId As Integer = ifBlankReplaceToZero(FWithdrawalList.lvlwithdrawalList.SelectedItems(0).SubItems(22).Text)
                    Dim qtyReleased As Double = FWithdrawalList.lvlwithdrawalList.SelectedItems(0).SubItems(5).Text

                    Dim partiallyWithdrawnQty As Double = ifBlankReplaceToZero(FWithdrawalList.countPartiallyWithdrawn(ws_id))
                    Dim partiallyWithdrawnId As Integer = ifBlankReplaceToZero(FWithdrawalList.lvlwithdrawalList.SelectedItems(0).SubItems(23).Text)
#End Region

#Region "CHECK IF QTY WITHDRAWN EXCEED"
                    If saveStatus = SaveBtn.Save Then
                        If partiallyWithdrawnQty + CDbl(txQtyPartiallyWithdrawn.Text) > qtyReleased Then
                            customMsg.message("error", "quantity exceed...", "SUPPLY INFO")
                            Exit Sub
                        End If
                    End If

#End Region

#Region "UPDATE APPROVED_BY,CHECKED_BY"
                    If saveStatus = SaveBtn.Save Then
                        Dim cc As New ColumnValuesObj

                        cc.add("approved_by", txtReleasedBy.Text)
                        cc.add("checked_by", txtReceived.Text)
                        cc.setCondition($"po_id = {ws_info_id}")

                        cc.updateQuery("dbPO")
                    End If
#End Region


                    If saveStatus = SaveBtn.Save Then

#Region "SAVE PARTIALLY WITHDRAWN"
                        If selectedWithdrawnId > 0 Then

                            Dim cc1 As New ColumnValuesObj
                            With cPartiallyWithdrawnStorage
                                .withdrawn_id = selectedWithdrawnId
                                .partialQty = partialQtyUI.tbox.Text
                                .releasedBy = txtReleasedBy.Text
                                .receivedBy = txtReceived.Text
                                .partiallyWithdrawnId = 0
                                .status = SaveBtn.Save
                                .price = txtAmount.Text
                                .ws_id = ws_id
                                .units = txtUnits.Text
                                .dateWithdrawn = Date.Parse(dtpDateWithdrawn.Text)
                            End With

                            id = insert_update_dbwithdrawal_partially_withdrawn_new(cPartiallyWithdrawnStorage)

                        End If
#End Region

                    ElseIf saveStatus = SaveBtn.Update Then

#Region "UPDATE PARTIALLY WITHDRAWN"
                        Dim cc1 As New ColumnValuesObj

                        id = insert_update_dbwithdrawal_partially_withdrawn(selectedWithdrawnId,
                                      partialQtyUI.tbox.Text,
                                      txtReleasedBy.Text,
                                      txtReceived.Text,
                                      partiallyWithdrawnId,
                                      SaveBtn.Update,
                                      0,
                                      ws_id,
                                      txtUnits.Text)
#End Region

                    End If

#Region "LOAD AGAIN"
                    With FWithdrawalList
                        .loadingStat = FWithdrawalList.LoadingStatus.partiallyWithdrawn
                        .cPartiallyWithdrawnId = id
                        .loadWhItems()
                    End With
#End Region


                End If
            Next

            If saveStatus = SaveBtn.Save Then
                customMsg.message("info", "Successfully withdrawn...", "SUPPLY INFO:")
            End If


            Me.Close()
            'FWithdrawalList.btnSearch.PerformClick()

#Region "RELOAD WITHOUT REFRESH"

#End Region
        End If

    End Sub

    Private Function insert_update_dbwithdrawal_partially_withdrawn_new(partialWithdrawn As PARTIALLY_WITHDRAWN_PROPS) As Integer
        Dim cc As New ColumnValuesObj

        Dim id As Integer
        With partialWithdrawn
            If .status = SaveBtn.Update Then

                cc.add("released_by", .releasedBy)
                cc.add("received_by", .releasedBy)
                cc.add("user_updated", pub_user_id)
                cc.add("date_time_updated", Date.Parse(Now))
                cc.add("units", .units)

                cc.setCondition($"partially_withdrawn_id = { .partiallyWithdrawnId}")

                cc.updateQuery("dbwithdrawal_partially_withdrawn")

                id = .partiallyWithdrawnId
            Else

                cc.add("withdrawn_id", .withdrawn_id)
                cc.add("partially_withdrawn_qty", .partialQty)
                cc.add("released_by", .releasedBy)
                cc.add("received_by", .receivedBy)
                cc.add("date_partially_withdrawn", Date.Parse(.dateWithdrawn))
                cc.add("user_id", pub_user_id)
                cc.add("dateLog", Date.Parse(Now))
                cc.add("units", .units)
                cc.add("serial_id", .serial_id)

                id = cc.insertQuery_and_return_id("dbwithdrawal_partially_withdrawn")

                'update amount/price
                Dim cc2 As New ColumnValuesObj
                cc2.add("unit_price", .price)
                cc2.add("amount", .price * .partialQty)

                cc2.setCondition($"po_det_id = { .ws_id}")
                cc2.updateQuery("dbPO_details")

            End If


        End With

        Return id

    End Function

    Private Function insert_update_dbwithdrawal_partially_withdrawn(param_withdrawn_id As Integer,
                                                        param_partialQty As Double,
                                                        param_released_by As String,
                                                        param_received_by As String,
                                                        Optional param_partiallyWithdrawnId As Integer = 0,
                                                        Optional param_status As Integer = 0,
                                                        Optional param_price As Double = 0,
                                                        Optional param_ws_id As Integer = 0,
                                                        Optional param_units As String = "") As Integer
        Dim cc As New ColumnValuesObj

        Dim id As Integer
        If param_status = SaveBtn.Update Then

            cc.add("released_by", param_released_by)
            cc.add("received_by", param_received_by)
            cc.add("user_updated", pub_user_id)
            cc.add("date_time_updated", Date.Parse(Now))
            cc.add("units", param_units)

            cc.setCondition($"partially_withdrawn_id = {param_partiallyWithdrawnId}")

            cc.updateQuery("dbwithdrawal_partially_withdrawn")

            id = param_partiallyWithdrawnId
        Else

            cc.add("withdrawn_id", param_withdrawn_id)
            cc.add("partially_withdrawn_qty", param_partialQty)
            cc.add("released_by", param_released_by)
            cc.add("received_by", param_received_by)
            cc.add("date_partially_withdrawn", Date.Parse(dtpDateWithdrawn.Text))
            cc.add("user_id", pub_user_id)
            cc.add("dateLog", Date.Parse(Now))
            cc.add("units", param_units)

            id = cc.insertQuery_and_return_id("dbwithdrawal_partially_withdrawn")

            'update amount/price
            Dim cc2 As New ColumnValuesObj
            cc2.add("unit_price", param_price)
            cc2.add("amount", param_price * param_partialQty)

            cc2.setCondition($"po_det_id = {param_ws_id}")
            cc2.updateQuery("dbPO_details")

        End If


        Return id

    End Function



    Private Function isWithdrawnId_exist(param_WithdrawnId As Integer) As Boolean
        Dim c As New ColumnValuesObj

        c.setCondition($"withdrawn_id = {param_WithdrawnId}")
        c.addColumn("withdrawn_id")
        Dim data = c.selectQuery_and_return_data("dbwithdrawn_items")

        If data.count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub SuccessfullyDone()

        Results.cListOfEmployees = CType(employeeModel.cData, List(Of PropsFields.employee_props_fields))
        cListOfWithdrawalPrice = CType(withdrawalPriceModel.cData, List(Of PropsFields.withdrawal_props_fields))

        Dim listOfEmployees As New List(Of String)
        For Each row In cListOfEmployees
            listOfEmployees.Add(row.employee)
        Next

        Dim listOfPrices As New List(Of String)
        For Each row In cListOfWithdrawalPrice
            listOfPrices.Add(row.unit_price)
        Next

        releasedByUI.AutoCompleteData = listOfEmployees
        releasedByUI.set_autocomplete()

        receivedByUI.AutoCompleteData = listOfEmployees
        receivedByUI.set_autocomplete()

        amountUI.AutoCompleteData = listOfPrices
        amountUI.set_autocomplete()

        loadingPanel.Visible = False

        If partiallyWithdrawnId > 0 Then
            Dim aa As New List(Of PropsFields.partiallyWithdrawn_props_fields)
            aa = FWithdrawalList.ListOfPartiallyWithdrawn().Where(Function(x) x.partially_withdrawn_id = partiallyWithdrawnId).ToList()

            If aa.Count > 0 Then
                txtReleasedBy.Text = aa(0).released_by
                releasedByUI.resetBgColor()

                txtReceived.Text = aa(0).received_by
                receivedByUI.resetBgColor()

                txQtyPartiallyWithdrawn.Text = aa(0).partially_withdrawn_qty
                partialQtyUI.resetBgColor()

                txtUnits.Text = aa(0).units
                unitsUI.resetBgColor()
            End If
        End If

        'for tire 
        If isForTire Then
            txtSerialNo.Enabled = True
            btnAddSerial.Enabled = True
        End If
    End Sub

    Private Sub FWithdrawnItems_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Me.Dispose()
    End Sub
End Class