Imports System.Data.Common
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Web.SessionState
Imports System.Windows
Imports System.Windows.Controls
Imports SUPPLY.ModelNew
Imports SUPPLY.ReceivingModel
Imports SUPPLY.RSDRModel

Public Class FRequesitionFormForDR
    Dim SQLcon As New SQLcon
    Dim sqldr As SqlDataReader
    Dim NEWDRMODEL As New RSDRModel
    Public searchUI As New class_placeholder5
    Private customMsg As New customMessageBox
    Public isItemChecked As Boolean
    Dim boolProcEditCopy As Boolean = False
    Public cRsId As Integer

    Private CDR As New FCreateDeliveryReceipt
    Private cn As New RSDRModel.COLUMNS
    Private customDataGrid As New CustomGridview
    Public cListOfShowColumn As New List(Of String)
    Private cDr_transaction As String
    Public ReadOnly Property getNewDrModel() As RSDRModel
        Get
            Return NEWDRMODEL
        End Get
    End Property

    'purpose of this is to disable item-check if search by charges
    Public isSearchByCharges As Boolean = False
    Public isSearchByRequestedBy As Boolean = False


    Private Sub FRequesitionFormForDR_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        NEWDRMODEL.initialize_searchPanel(Panel11)
        NEWDRMODEL.execute_initialize(loadingPanel)

        Dim fontFamily As New Dictionary(Of String, String)
        fontFamily.Add("fontName", cFontsFamily.bombardier)
        fontFamily.Add("fontSize", 12)

        searchUI.king_placeholder_textbox("Search RS...",
                                          txtSearch,
                                          Nothing,
                                          Panel11,
                                          My.Resources.received,
                                          False,
                                          searchUI.cCustomColor.Custom1,,,, fontFamily)


        'color legend
        panel_color_legend_main.BackColor = cRsRowColor.MainRs
        panel_color_legend_sub.BackColor = cRsRowColor.MainSubRS
        panel_color_legend_withdrawal_po.BackColor = cRsRowColor.WsPo
        panel_color_legend_receiving.BackColor = cRsRowColor.Rr
        panel_color_legend_dr.BackColor = cRsRowColor.Dr
        panel_color_legend_total.BackColor = cRsRowColor.totalRow


    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        'reset this to false to enable some items in contextmenu
        isSearchByCharges = False
        isSearchByRequestedBy = False

        NEWDRMODEL.initialize("SEARCH BY RS", txtSearch.Text, DataGridView1)
        NEWDRMODEL.execute()

    End Sub

    Private Sub CreateNewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateNewToolStripMenuItem.Click
        Dim cn = NEWDRMODEL.cn

        If DataGridView1.Rows.Count > 0 Then

            Dim selectedRow = DataGridView1.SelectedRows(0)
            Dim main_rs_qty_id As Integer = selectedRow.Cells(NameOf(cn.main_rs_qty_id)).Value
            Dim remainingBalance = NEWDRMODEL.getMainRsRemainingBalance(main_rs_qty_id)

            ' showCreateRsForm()
            If remainingBalance = "open" Then
                showCreateRsWithSelectedItemForm()
            ElseIf remainingBalance = 0 Then
                customMsg.message("error", "all quantity has been consume!", "SUPPLY INFO:")
            ElseIf remainingBalance > 0 Then
                showCreateRsWithSelectedItemForm(remainingBalance)
            ElseIf remainingBalance < 0 Then
                showCreateRsWithSelectedItemForm(remainingBalance)
            End If
        Else
            showCreateRsForm()
        End If


    End Sub


    Private Sub RsCopy(rs_id As Integer)
        Dim rsData = NEWDRMODEL.getListOfRsForDr().FirstOrDefault(Function(x)
                                                                      Return x.rs_id = rs_id
                                                                  End Function)

        Dim copyRsCharges = NEWDRMODEL.copyAllRsChargesFromThisRsId(rs_id)

        With FCreateRSForm
            .isCopy = True
            .ccopyRsData = rsData
            .copyRsChargesStorage = copyRsCharges
            .ShowDialog()
        End With
    End Sub

    Private Sub RsDefault(remaining_quantity As Double)
        With FCreateRSForm
            .cRSRemainingQuantity = remaining_quantity
            .ShowDialog()
        End With
    End Sub

    Private Sub showCreateRsWithSelectedItemForm(Optional remainingQty As Double = 0)

        Try
            Dim messagebox As String = "Do you want to copy the rs data? or create a new one." & vbCrLf &
                "YES: COPY" & vbCrLf & "NO: CREATE"

            Dim messagebox2 As String = "YES: for Purchase Order/Withdrawal transaction" & vbCrLf & "NO: for Cash with Receiving"

            Dim cn = NEWDRMODEL.cn
            Dim row = DataGridView1.SelectedRows(0)

            If customMsg.messageYesNo(messagebox, "SUPPLY INFO:", MessageBoxIcon.Question) Then

                'Logic for copy | rs with Purchase Order / Withdrawal
                Dim msgBoxResult = customMsg.messageYesNoCancel(messagebox2, "SUPPLY INFO:", MessageBoxIcon.Question)
                If msgBoxResult = DialogResult.Yes Then

                    If row.Cells(NameOf(cn.level)).Value = NEWDRMODEL.getLevel.sub_rs Then
                        RsCopy(row.Cells(NameOf(cn.rs_id)).Value)
                    Else
                        customMsg.message("error", "click the RS row to proceed on this transaction...", "SUPPLY INFO:")
                    End If
                ElseIf msgBoxResult = DialogResult.No Then
                    'Logic for copy | cash rs with Receiving
                    boolProcEditCopy = True 'para sa button mailhan kung edit or copy bah
                    If editCash() Then
                        Exit Sub
                    Else
                        customMsg.message("error", "unable to copy datas, this row is not for cash transaction!", "SMS INFO:")
                    End If

                End If
            Else
                'Logic for default | rs with Purchase Order / Withdrawal
                Dim msgBoxResult = customMsg.messageYesNoCancel(messagebox2, "SUPPLY INFO:", MessageBoxIcon.Question)
                If msgBoxResult = DialogResult.Yes Then
                    RsDefault(remainingQty)

                ElseIf msgBoxResult = DialogResult.No Then
                    'Logic default | for cash rs with Receiving
                    FRequisition_Non_Item.ShowDialog()
                End If

            End If

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub showCreateRsForm()
        Try
            Dim messagebox As String = "YES: for Purchase Order/Withdrawal transaction" & vbCrLf & "NO: for Cash with Receiving"

            Dim cn = NEWDRMODEL.cn

            'Logic for default | rs with Purchase Order / Withdrawal
            Dim msgResult = customMsg.messageYesNoCancel(messagebox, "SUPPLY INFO:", MessageBoxIcon.Question)
            If msgResult = DialogResult.Yes Then
                RsDefault(0)
            ElseIf msgResult = DialogResult.No Then
                'Logic default | for cash rs with Receiving
                FRequisition_Non_Item.ShowDialog()

            End If

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
    Private Sub loadTypeOfRequest()
        Try
            Dim distinctToR = NEWDRMODEL.getTypeOfRequest().Select(Function(x) x.tor_desc).Distinct().ToList()
            With FRequestField
                .cmbRequestType.Items.Clear()
                .cmbTOR_sub.Items.Clear()

                For Each tor In distinctToR
                    .cmbRequestType.Items.Add(tor)
                Next

                For Each tor_sub In NEWDRMODEL.getTypeOfRequest()
                    .cmbTOR_sub.Items.Add(tor_sub.tor_sub_desc)
                Next
            End With
        Catch ex As Exception

        End Try

    End Sub


    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        Try

            If DataGridView1.Rows.Count > 0 Then
                Dim cn = NEWDRMODEL.cn
                Dim row = DataGridView1.SelectedRows(0)

                Dim main_rs_qty_id As Integer = row.Cells(NameOf(cn.main_rs_qty_id)).Value
                Dim typeOfPurchasing As String = row.Cells(NameOf(cn.type_of_purchasing)).Value

                If row.DefaultCellStyle.BackColor = cRsRowColor.MainSubRS Then 'Sub RS Row
                    disableAllItems()

                    enableDisableItems(CreateNewToolStripMenuItem.Name)
                    enableDisableItems(EditToolStripMenuItem.Name)
                    enableDisableItems(RemoveToolStripMenuItem.Name)
                    enableDisableItems(AddMoreChargesToolStripMenuItem.Name)
                    enableDisableItems(CancelToolStripMenuItem.Name)
                    enableDisableItems(CreateMainRSQuantityToolStripMenuItem.Name)

                    Utilities.enableDisableToolStrip(RSToolStripMenuItem, True)
                    Utilities.enableDisableToolStrip(POToolStripMenuItem, False)
                    Utilities.enableDisableToolStrip(WSToolStripMenuItem, False)


                    If typeOfPurchasing = cTypeOfPurchasing.WITHDRAWAL Then
                        enableDisableItems(CreateWithdrawalToolStripMenuItem.Name)
                        enableDisableItems(RemovedItemCheckedToolStripMenuItem.Name)

                    ElseIf typeOfPurchasing = cTypeOfPurchasing.PURCHASE_ORDER Then
                        enableDisableItems(CreatePurchaseOrderToolStripMenuItem.Name)
                        enableDisableItems(RemovedItemCheckedToolStripMenuItem.Name)

                    ElseIf typeOfPurchasing = cTypeOfPurchasing.CASH_WITH_RR Then
                        enableDisableItems(CreateReceivingToolStripMenuItem.Name)

                    ElseIf typeOfPurchasing = cTypeOfPurchasing.DR Then
                        enableDisableItems(CreateDeliveryReceiptToolStripMenuItem.Name)
                        enableDisableItems(RemovedItemCheckedToolStripMenuItem.Name)

                        'dr context
                        Utilities.enableDisableToolStrip(QuarryToStockpileToolStripMenuItem, True)
                        Utilities.enableDisableToolStrip(QuarryToProjectToolStripMenuItem, True)
                        Utilities.enableDisableToolStrip(OutsourceToStockpileToolStripMenuItem, False)
                        Utilities.enableDisableToolStrip(StockpileToStockpileToolStripMenuItem, False)
                        Utilities.enableDisableToolStrip(StockpileToProjectToolStripMenuItem, False)
                        Utilities.enableDisableToolStrip(WasteDisposalAndOthersToolStripMenuItem, True)

                    Else
                        enableDisableItems(ItemCheckingToolStripMenuItem.Name)
                    End If

                    If isSearchByCharges Or isSearchByRequestedBy Then
                        disableItems(ItemCheckingToolStripMenuItem)
                        disableItems(RemovedItemCheckedToolStripMenuItem)
                        disableItems(AddMoreChargesToolStripMenuItem)
                        disableItems(CreateMainRSQuantityToolStripMenuItem)
                        disableItems(CreateReceivingToolStripMenuItem)
                        disableItems(CreatePurchaseOrderToolStripMenuItem)
                        disableItems(CreateDeliveryReceiptToolStripMenuItem)
                        disableItems(CreateWithdrawalToolStripMenuItem)

                    End If


                ElseIf row.DefaultCellStyle.BackColor = cRsRowColor.WsPo Then 'WS/PO Row

                    disableAllItems()

                    If typeOfPurchasing = cTypeOfPurchasing.PURCHASE_ORDER Then
                        enableDisableItems(CreateReceivingToolStripMenuItem.Name)
                        enableDisableItems(CancelToolStripMenuItem.Name)

                        Utilities.enableDisableToolStrip(RSToolStripMenuItem, False)
                        Utilities.enableDisableToolStrip(POToolStripMenuItem, True)
                        Utilities.enableDisableToolStrip(WSToolStripMenuItem, False)

                    ElseIf typeOfPurchasing = cTypeOfPurchasing.WITHDRAWAL Then
                        enableDisableItems(CreateDeliveryReceiptToolStripMenuItem.Name)
                        enableDisableItems(CancelToolStripMenuItem.Name)

                        Utilities.enableDisableToolStrip(RSToolStripMenuItem, False)
                        Utilities.enableDisableToolStrip(POToolStripMenuItem, False)
                        Utilities.enableDisableToolStrip(WSToolStripMenuItem, True)

                        'dr context
                        Utilities.enableDisableToolStrip(QuarryToStockpileToolStripMenuItem, False)
                        Utilities.enableDisableToolStrip(QuarryToProjectToolStripMenuItem, False)
                        Utilities.enableDisableToolStrip(OutsourceToStockpileToolStripMenuItem, False)
                        Utilities.enableDisableToolStrip(WasteDisposalAndOthersToolStripMenuItem, False)
                        Utilities.enableDisableToolStrip(StockpileToStockpileToolStripMenuItem, True)
                        Utilities.enableDisableToolStrip(StockpileToProjectToolStripMenuItem, True)
                    End If


                ElseIf row.DefaultCellStyle.BackColor = cRsRowColor.Rr Then 'RR Row

                    disableAllItems()
                    enableDisableItems(CreateDeliveryReceiptToolStripMenuItem.Name)

                ElseIf row.DefaultCellStyle.BackColor = Color.Red Then 'Cancel Row

                    disableAllItems()
                    enableDisableItems(CancelToolStripMenuItem.Name)

                    If row.Cells(NameOf(cn.level)).Value = NEWDRMODEL.getLevel().po Then
                        Utilities.enableDisableToolStrip(RSToolStripMenuItem, False)
                        Utilities.enableDisableToolStrip(WSToolStripMenuItem, False)
                        Utilities.enableDisableToolStrip(POToolStripMenuItem, True)

                    ElseIf row.Cells(NameOf(cn.level)).Value = NEWDRMODEL.getLevel().sub_rs Then
                        Utilities.enableDisableToolStrip(RSToolStripMenuItem, True)
                        Utilities.enableDisableToolStrip(POToolStripMenuItem, False)
                        Utilities.enableDisableToolStrip(WSToolStripMenuItem, False)

                    ElseIf row.Cells(NameOf(cn.level)).Value = NEWDRMODEL.getLevel().ws Then
                        Utilities.enableDisableToolStrip(RSToolStripMenuItem, False)
                        Utilities.enableDisableToolStrip(POToolStripMenuItem, False)
                        Utilities.enableDisableToolStrip(WSToolStripMenuItem, True)

                    End If


                Else
                    disableAllItems()
                    enableDisableItems(Nothing)
                End If

            Else
                disableAllItems()
            End If

            enableDisableItems(SearchByToolStripMenuItem.Name)
            enableDisableItems(CreateNewToolStripMenuItem.Name)
            enableDisableItems(RefreshToolStripMenuItem.Name)
            enableDisableItems(ColumnSettingsToolStripMenuItem.Name)

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub enableDisableItems(itemName As String)
        Try
            For Each item As ToolStripMenuItem In ContextMenuStrip1.Items
                If item.Name = itemName Then
                    item.Enabled = True
                End If
            Next
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
    Private Sub disableItems(item As ToolStripMenuItem)
        item.Enabled = False
    End Sub

    Private Sub enableItems(item As ToolStripMenuItem)
        item.Enabled = True
    End Sub

    Private Sub disableAllItems()
        For Each item As ToolStripMenuItem In ContextMenuStrip1.Items
            item.Enabled = False
        Next
    End Sub

    Private Sub disableSpecificContextMenuItem(item As ToolStripMenuItem)

        item.Enabled = False

    End Sub

    Private Sub CreateWithdrawalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateWithdrawalToolStripMenuItem.Click
        Dim row = DataGridView1.SelectedRows(0)

        If row.Cells(NameOf(NEWDRMODEL.cn.division)).Value = cDivision.WAREHOUSING_AND_SUPPLY Then

            createWithdrawalForWarehousing()

        ElseIf row.Cells(NameOf(NEWDRMODEL.cn.division)).Value = cDivision.CRUSHING_AND_HAULING Then

            createWithdrawalForHauling()

        End If
    End Sub

    Private Sub createWithdrawalForWarehousing()
        Try
            Dim row = DataGridView1.SelectedRows(0)
            Dim wh_id2 As Integer = row.Cells(NameOf(NEWDRMODEL.cn.wh_id)).Value

            'check for warehousing or hauling
            Dim whId As Integer = row.Cells(NameOf(NEWDRMODEL.cn.wh_id)).Value
            Dim whItems As New List(Of PropsFields.whItems_props_fields)
            Dim rs_id As Integer = row.Cells(NameOf(NEWDRMODEL.cn.rs_id)).Value
            Dim cn = NEWDRMODEL.cn

            If row.Cells(NameOf(cn.division)).Value = cDivision.WAREHOUSING_AND_SUPPLY And
                row.Cells(NameOf(cn.inOut)).Value = cInOut._OUT Then

                Dim rsQty As Double = row.Cells(NameOf(cn.rs_qty)).Value
                Dim QtyWithdrawn_released As Double = NEWDRMODEL.getWithdrawnAggregates(rs_id)

                With FCreateWithdrawalSlip
                    .isCreateWithdrawalFromNewRsForm = True

                    .wsNew.rs_id = rs_id
                    .wsNew.charges = row.Cells(NameOf(cn.charges)).Value
                    .wsNew.rs_no = row.Cells(NameOf(cn.rs_no)).Value
                    .wsNew.units = row.Cells(NameOf(cn.units)).Value
                    .wsNew.whLocation = row.Cells(NameOf(cn.location)).Value
                    .wsNew.wh_id = whId
                    .wsNew.rsQty_remaining = rsQty - QtyWithdrawn_released

                    .lblRsQty.Text = rsQty
                    .lblReleased.Text = QtyWithdrawn_released
                    .lblBalance.Text = rsQty - QtyWithdrawn_released

                    .txtUnit.Text = row.Cells(NameOf(cn.units)).Value

                    If (rsQty - QtyWithdrawn_released) <= 0 Then
                        .Label5.Visible = True
                    Else
                        .Label5.Visible = False
                    End If

                    .saveStatus = SaveBtn.Save

                End With

                FCreateWithdrawalSlip.ShowDialog()

                Exit Sub
            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
            Exit Sub
        End Try

    End Sub

    Private Sub createWithdrawalForHauling()
        Try
            Dim row = DataGridView1.SelectedRows(0)
            Dim cn = NEWDRMODEL.cn

            Dim rs_id As Integer = row.Cells(NameOf(cn.rs_id)).Value
            Dim rsNo As String = row.Cells(NameOf(cn.rs_no)).Value

            Dim withdrawnAggregates = NEWDRMODEL.getWithdrawnAggregates(rs_id)
            Dim rsQty As Double = row.Cells(NameOf(cn.rs_qty)).Value

            With FCreateWithdrawalSlipForDr
                .cRsId = rs_id
                .cRsNo = rsNo
                .rsQtyLeft = rsQty - withdrawnAggregates
                .cUnit = row.Cells(NameOf(cn.units)).Value

                .Label2.Text = $"{row.Cells(NameOf(cn.proper_names)).Value}".ToUpper()
                .Label13.Text = $"RS BALANCE: {rsQty - withdrawnAggregates} {row.Cells(NameOf(cn.units)).Value}"

                .ShowDialog()

            End With

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub CreatePurchaseOrderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreatePurchaseOrderToolStripMenuItem.Click
        Try
            Dim row = DataGridView1.SelectedRows(0)

            Dim rs_id As Integer = row.Cells(NameOf(NEWDRMODEL.cn.rs_id)).Value
            Dim rsNo As String = row.Cells(NameOf(NEWDRMODEL.cn.rs_no)).Value

            Dim purchasedAggregates = NEWDRMODEL.getPurchasedAggregates(rs_id)
            Dim rsQty As Double = row.Cells(NameOf(NEWDRMODEL.cn.rs_qty)).Value

            With CreatePurchaseOrderForm
                .cRsId = rs_id
                .cRsNo = rsNo
                .rsQtyLeft = rsQty - purchasedAggregates
                .isFromRequestionFormForDR = True

#Region "FILTER"
                If .rsQtyLeft <= 0 Then
                    customMsg.message("error", "all po quantity has been released...", "SUPPLY INFO:")
                    Exit Sub
                End If
#End Region

                .Label2.Text = $"{row.Cells(NameOf(NEWDRMODEL.cn.proper_names)).Value}".ToUpper()
                .Label13.Text = $"RS BALANCE: {rsQty - purchasedAggregates} {row.Cells(NameOf(NEWDRMODEL.cn.units)).Value}"


#Region "add all rs to datagridview in createPurchaseOrderForm"
                NEWDRMODEL.DisplayRsDataToPoDatagridview(CreatePurchaseOrderForm.DataGridView1, rsNo)
#End Region

                .ShowDialog()
            End With

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub CreateReceivingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateReceivingToolStripMenuItem.Click
        Try
            Dim selectedRow = DataGridView1.SelectedRows(0)
            Dim rs_id As Integer = selectedRow.Cells(NameOf(cn.other_id)).Value
            Dim poNo As String = selectedRow.Cells(NameOf(cn.ws_no)).Value
            Dim po_det_id As Integer = selectedRow.Cells(NameOf(cn.rs_id)).Value
            Dim rsNo As String = selectedRow.Cells(NameOf(cn.rs_no)).Value
            Dim receivedAggregates = NEWDRMODEL.getReceivedAggregates(po_det_id)
            Dim poQty As Double = selectedRow.Cells(NameOf(cn.po_cv_ws_qty_released)).Value

            Dim rs_id_for_cash_with_rr As Integer = selectedRow.Cells(NameOf(cn.rs_id)).Value

            With FCreateReceiving

#Region "CASH WITH RR"
                Dim rsRow = NEWDRMODEL.getListOfRsDatas.FirstOrDefault(Function(x) CStr(x.rs_id) = CStr(rs_id_for_cash_with_rr))
                rsNo = rsRow?.rs_no
                Dim isReceivingForCashWithRR = isCreateReceivingForCash(rsRow)
                If isReceivingForCashWithRR Then Exit Sub
#End Region

                .cRsId = rs_id
                .cPoDetId = po_det_id
                .cRsNo = rsNo

                .poQtyLeft = poQty - receivedAggregates

                If .poQtyLeft <= 0 Then
                    customMsg.message("error", "all receiving qty has been released!", "SUPPLY INFO:")
                    Exit Sub
                End If

                '.Label2.Text = $"{row.Cells(NameOf(NEWDRMODEL.cn.proper_names)).Value}".ToUpper()
                '.Label13.Text = $"RS BALANCE: {rsQty - purchasedAggregates} {row.Cells(NameOf(NEWDRMODEL.cn.units)).Value}"

#Region "add all po to datagridview in createReceiving"
                Dim dgv = FCreateReceiving.DataGridView1
                NEWDRMODEL.DisplayPoDataToRrDatagridview(dgv, rsNo)
                FCreateReceiving.lblTotalAmount.Text = FCreateReceiving.GET_CREATERECEIVINGMODEL().calculateTotalAmount(dgv)
#End Region

                .ShowDialog()
            End With

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Function isCreateReceivingForCash(rsRow As RSDRModel.COLUMNS) As Boolean

        Dim receivedAggregatesCashWithRR = NEWDRMODEL.getReceivedAggregatesCashWithRR(rsRow.rs_id)

        If rsRow.type_of_purchasing = cTypeOfPurchasing.CASH_WITH_RR Then

            With FCreateReceiving
                .cRsId = rsRow.rs_id
                .cRsNo = rsRow.rs_no
                .rsQtyForCashLeft = rsRow.rs_qty - receivedAggregatesCashWithRR

                If .rsQtyForCashLeft <= 0 Then
                    customMsg.message("error", "all receiving qty has been released!", "SUPPLY INFO:")
                    isCreateReceivingForCash = False
                    Exit Function
                End If

                NEWDRMODEL.DisplayRsCashDataToRrDatagridview(FCreateReceiving.DataGridView1, rsRow.rs_no)
                isCreateReceivingForCash = True
                .ShowDialog()
            End With
        End If
    End Function



    Private Sub createDeliveryReceipt()
        Try
            If Not isForCrushingAndHauling() Then
                Exit Sub
            End If

            CDR = New FCreateDeliveryReceipt
            Dim deliveredAggregates = getDeliveredAggregates()

            Dim selectedRow = DataGridView1.SelectedRows(0)
            Dim level As String = selectedRow.Cells(NameOf(cn.level)).Value

            Select Case selectedRow.Cells(NameOf(cn.level)).Value

                Case NEWDRMODEL.getLevel.ws
                    Dim wsId As Integer = selectedRow.Cells(NameOf(cn.rs_id)).Value

                    Dim wsRow = NEWDRMODEL.getWithdrawalDataByWsIdAndLevel(wsId, level)
                    createDrForWithdrawal(wsRow)

                Case NEWDRMODEL.getLevel.rr
                    Dim rrItemId As Integer = selectedRow.Cells(NameOf(cn.rs_id)).Value

                    Dim rrRow = NEWDRMODEL.getReceivingDataByRrItemIdAndLevel(rrItemId, level)
                    createDrForReceiving(rrRow)

                Case NEWDRMODEL.getLevel.sub_rs
                    Dim rsId As Integer = selectedRow.Cells(NameOf(cn.rs_id)).Value

                    Dim rsRow = NEWDRMODEL.getRequesitionByRsIdAndLevel(rsId, level)
                    createDrForRsDirectToDR(rsRow)

            End Select

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub createDrForWithdrawal(wsRow As RSDRModel.COLUMNS)

        If isPendingWithdrawal(wsRow.rr_ws_qty_received) Then
            Exit Sub
        End If

        Dim deliveredAggregates = getDeliveredAggregates()

        With CDR
            .ReleasedQty = wsRow.rr_ws_qty_received

            .DeliveredQty = deliveredAggregates

            With .cStockpileOut

                .wh_id = wsRow.wh_id
                .charges = wsRow.charges
                .typeOfPurchasing = wsRow.type_of_purchasing
                .rs_id = wsRow.other_id
                .wsNoRrNo = wsRow.ws_no
                .rsNo = wsRow.rs_no
                .units = wsRow.units

            End With

            .cTypeOfPurchasing1 = wsRow.type_of_purchasing
            .cWithDr = True
            .cDrOption = DROptions.out_with_rs
            .cTransaction = cDr_transaction

            If isFullyDelivered(.ReleasedQty, .DeliveredQty) Then
                Exit Sub
            End If
        End With

        showDeliveryReceipt()
    End Sub

    Private Sub createDrForReceiving(rrRow As RSDRModel.COLUMNS)

        Dim deliveredAggregates = getDeliveredAggregates()

        With CDR
            With .cStockpileIn

                .wh_id = rrRow.wh_id
                .charges = rrRow.charges
                .typeOfPurchasing = rrRow.type_of_purchasing
                .units = rrRow.units
                .wsNoRrNo = rrRow.rr_no

                If rrRow.type_of_purchasing = cTypeOfPurchasing.PURCHASE_ORDER Then
                    Dim receiving = NEWDRMODEL.getListOfReceiving().FirstOrDefault(Function(x)
                                                                                       Return x.rr_no = rrRow.rr_no
                                                                                   End Function)
                    If receiving IsNot Nothing Then

                        .supplier = receiving.supplier
                        .rs_id = rrRow.rs_id_for_rr

                    End If
                End If

            End With

            .ReleasedQty = rrRow.rr_ws_qty_received

            .DeliveredQty = deliveredAggregates

            '.cStockpileIn.wsNoRrNo = rrRow.rr_no

            .cDrOption = DROptions.in_with_rs_po_rr

            .cStockpileIn.defaultPrice = rrRow.price

            .cTypeOfPurchasing1 = rrRow.type_of_purchasing

            .cWithDr = True

            If isFullyDelivered(.ReleasedQty, .DeliveredQty) Then
                Exit Sub
            End If

            showDeliveryReceipt()

        End With
    End Sub

    Private Sub createDrForRsDirectToDR(rsRow As RSDRModel.COLUMNS)

        Dim deliveredAggregates = getDeliveredAggregates()

        With CDR
            With .cStockpileIn
                .wh_id = rsRow.wh_id
                .charges = rsRow.charges
                .typeOfPurchasing = rsRow.type_of_purchasing
                .units = rsRow.units
                .rsNo = rsRow.rs_no
                .rs_id = rsRow.rs_id
            End With

            .cTypeOfPurchasing1 = rsRow.type_of_purchasing

            .ReleasedQty = rsRow.rs_qty

            .DeliveredQty = deliveredAggregates

            .cStockpileIn.wsNoRrNo = rsRow.rs_no

            .cWithDr = True

            .cTransaction = cDr_transaction

            'correcting DR OPTIONS
            If rsRow.inOut = cInOut._OTHERS Then
                .cDrOption = DROptions.others_with_rs
            ElseIf rsRow.inOut = cInOut._IN Then
                .cDrOption = DROptions.in_with_rs
            End If

            Dim mainRsSub = NEWDRMODEL.getMainRsSub().FirstOrDefault(Function(x)
                                                                         Return x.rs_id = rsRow.rs_id
                                                                     End Function)

            If mainRsSub IsNot Nothing Then
                Dim mainRs = NEWDRMODEL.getMainRs().FirstOrDefault(Function(x)
                                                                       Return x.main_rs_qty_id = mainRsSub.main_rs_qty_id
                                                                   End Function)
                If mainRs IsNot Nothing Then
                    If mainRs.open_close_qty = 1 Then
                        .cOpened = True
                    End If
                End If
            End If

            If isFullyDelivered(.ReleasedQty, .DeliveredQty) Then
                Exit Sub
            End If

            showDeliveryReceipt()

        End With
    End Sub


    Private Sub createDeliveryReceipt2()
        Try
            CDR = New FCreateDeliveryReceipt
            Dim deliveredAggregates = getDeliveredAggregates()

            With CDR
                If DataGridView1.Rows.Count > 0 Then

                    Dim selectedRow = DataGridView1.SelectedRows(0)
                    Dim TYPEOFPURCHASING As String = selectedRow.Cells(NameOf(cn.type_of_purchasing)).Value

                    If TYPEOFPURCHASING = cTypeOfPurchasing.WITHDRAWAL Then

                        If isPendingWithdrawal(selectedRow.Cells(NameOf(cn.rr_ws_qty_received)).Value) Then
                            Exit Sub
                        End If

                        .ReleasedQty = selectedRow.Cells(NameOf(cn.rr_ws_qty_received)).Value

                        .DeliveredQty = deliveredAggregates

                        With .cStockpileOut

                            .wh_id = selectedRow.Cells(NameOf(cn.wh_id)).Value
                            .charges = selectedRow.Cells(NameOf(cn.charges)).Value
                            .typeOfPurchasing = TYPEOFPURCHASING
                            .rs_id = selectedRow.Cells(NameOf(cn.other_id)).Value
                            .wsNoRrNo = selectedRow.Cells(NameOf(cn.ws_no)).Value

#Region "WS/RR No."
                            Select Case TYPEOFPURCHASING
                                Case cTypeOfPurchasing.WITHDRAWAL

                                    .wsNoRrNo = selectedRow.Cells(NameOf(cn.ws_no)).Value

                                Case cTypeOfPurchasing.PURCHASE_ORDER, cTypeOfPurchasing.CASH_WITH_RR

                                    .wsNoRrNo = selectedRow.Cells(NameOf(cn.rr_no)).Value

                            End Select
#End Region

                            .rsNo = selectedRow.Cells(NameOf(cn.rs_no)).Value
                            .units = selectedRow.Cells(NameOf(cn.units)).Value

                        End With

                        .cTypeOfPurchasing1 = TYPEOFPURCHASING
                        .cWithDr = True
                        .cDrOption = DROptions.out_with_rs

                        If isFullyDelivered(.ReleasedQty, .DeliveredQty) Then
                            Exit Sub
                        End If

                        showDeliveryReceipt()

                    Else

                        With .cStockpileIn
                            .wh_id = selectedRow.Cells(NameOf(cn.wh_id)).Value
                            .charges = selectedRow.Cells(NameOf(cn.charges)).Value
                            .typeOfPurchasing = TYPEOFPURCHASING
                            .units = selectedRow.Cells(NameOf(cn.units)).Value

                            If TYPEOFPURCHASING = cTypeOfPurchasing.PURCHASE_ORDER Then
                                Dim receiving = NEWDRMODEL.getListOfReceiving().FirstOrDefault(Function(x)
                                                                                                   Return x.rr_no = selectedRow.Cells(NameOf(cn.rr_no)).Value
                                                                                               End Function)

                                If receiving IsNot Nothing Then
                                    .supplier = receiving.supplier
                                    .rs_id = receiving.rs_id  'selectedRow.Cells(NameOf(cn.other_id)).Value
                                    .wsNoRrNo = receiving.rr_no
                                End If
                            End If

                        End With

                        If TYPEOFPURCHASING = cTypeOfPurchasing.DR And
                                selectedRow.DefaultCellStyle.BackColor = cRsRowColor.MainSubRS Then

                            .ReleasedQty = selectedRow.Cells(NameOf(cn.rs_qty)).Value

                            .DeliveredQty = deliveredAggregates

                            .cStockpileIn.wsNoRrNo = selectedRow.Cells(NameOf(cn.rs_no)).Value

#Region "DR OPTIONS"
                            If selectedRow.Cells(NameOf(cn.inOut)).Value = cInOut._OTHERS Then
                                .cDrOption = DROptions.others_with_rs

                            ElseIf selectedRow.Cells(NameOf(cn.inOut)).Value = cInOut._IN Then
                                .cDrOption = DROptions.in_with_rs
                            End If
#End Region

#Region "OPEN/CLOSED QTY"
                            Dim mainRsSub = NEWDRMODEL.getMainRsSub().FirstOrDefault(Function(x)
                                                                                         Return x.rs_id = selectedRow.Cells(NameOf(cn.rs_id)).Value
                                                                                     End Function)

                            If mainRsSub IsNot Nothing Then
                                Dim mainRs = NEWDRMODEL.getMainRs().FirstOrDefault(Function(x) x.main_rs_qty_id = mainRsSub.main_rs_qty_id)
                                If mainRs IsNot Nothing Then
                                    If mainRs.open_close_qty = 1 Then
                                        .cOpened = True
                                    End If
                                End If
                            End If
#End Region

                        ElseIf TYPEOFPURCHASING = cTypeOfPurchasing.PURCHASE_ORDER And
                               selectedRow.DefaultCellStyle.BackColor = cRsRowColor.Rr Then

                            .ReleasedQty = selectedRow.Cells(NameOf(cn.rr_ws_qty_received)).Value

                            .DeliveredQty = deliveredAggregates

                            .cStockpileIn.wsNoRrNo = selectedRow.Cells(NameOf(cn.rr_no)).Value

#Region "DR OPTIONS"
                            .cDrOption = DROptions.in_with_rs_po_rr
#End Region

#Region "DEFAULT PRICE"
                            .cStockpileIn.defaultPrice = selectedRow.Cells(NameOf(cn.price)).Value
#End Region

                        End If

                        .cTypeOfPurchasing1 = TYPEOFPURCHASING
                        .cWithDr = True

                        If isFullyDelivered(.ReleasedQty, .DeliveredQty) Then
                            Exit Sub
                        End If

                        '.ShowDialog()
                        showDeliveryReceipt()

                    End If

                End If

            End With

        Catch ex As Exception
            Dim cc As New customMessageBox
            cc.ErrorMessage(ex)
        End Try
    End Sub

    Private Function isPendingWithdrawal(ws_withdrawn As String) As Boolean
        If ws_withdrawn = "pending" Then
            customMsg.message("error", "this transaction has not been withdrawn yet!", "SUPPLY INFO:")
            Return True
        Else
            Return False
        End If
    End Function

    Private Function isFullyDelivered(releasedQty As Double, deliveredQty As Double) As Boolean
        If (releasedQty - deliveredQty) <= 0 Then
            customMsg.message("error", "all dr has been delivered!", "SUPPLY INFO:")
            Return True
        Else
            Return False
        End If
    End Function
    Private Sub showDeliveryReceipt()
        CDR.Activate()
        CDR.MdiParent = FMain
        CDR.Dock = DockStyle.Fill
        CDR.Show()
    End Sub

    Private Sub ItemCheckingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ItemCheckingToolStripMenuItem.Click
        Try
#Region "FILTER"
            Dim selectedRow = DataGridView1.SelectedRows(0)
            If selectedRow.Cells(NameOf(cn.wh_pn_id_for_rs)).Value = 0 Then
                customMsg.message("error", "unable to item-checked, you must set the proper name first..", "SUPPLY INFO:")
                Exit Sub
            End If
#End Region

            For Each child As Form In FMain.MdiChildren
                If TypeOf child Is FWarehouseItemsNew Then
                    child.Dispose()
                End If
            Next

            With FWarehouseItemsNew
                .fromRequesitionFormForDR = True
                .btnListOfWhItem.Enabled = False
                .MdiParent = Nothing
                .getWhItemsModel().cWhPnId = selectedRow.Cells(NameOf(cn.wh_pn_id_for_rs)).Value
                .getWhItemsModel().isItemChecked = True
                .WindowState = FormWindowState.Normal

                Dim rs = NEWDRMODEL.getListOfRsForDr.FirstOrDefault(Function(x) x.rs_id = selectedRow.Cells(NameOf(cn.rs_id)).Value)

                Dim propername = NEWDRMODEL.getProperNameBy_wh_pn_id_for_rs(rs)

                .Label2.Visible = True
                .lblProperName.Text = $"- {propername?.item_name} - {propername?.item_desc}".ToUpper()
                .lblProperName.Visible = True
                .ShowDialog()
            End With

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub RemovedItemCheckedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemovedItemCheckedToolStripMenuItem.Click
        Try
#Region "FILTER"
            Dim selectedRow = DataGridView1.SelectedRows(0)

            If Not Utilities.isAuthenticatedWithoutMessage(auth) Then
                If selectedRow.Cells(NameOf(cn.type_of_purchasing)).Value = cTypeOfPurchasing.PURCHASE_ORDER Then

                    Dim rs_id As Integer = selectedRow.Cells(NameOf(NEWDRMODEL.cn.rs_id)).Value
                    Dim purchased = getPurchasedAggregates(rs_id)

                    If purchased > 0 Then
                        customMsg.message("error", "Cannot item-checked — some items are already purchased!.", "SUPPLY INFO:")
                        Exit Sub
                    End If

                ElseIf selectedRow.Cells(NameOf(cn.type_of_purchasing)).Value = cTypeOfPurchasing.WITHDRAWAL Then
                    Dim rs_id As Integer = selectedRow.Cells(NameOf(NEWDRMODEL.cn.rs_id)).Value
                    Dim withdraw = getWithdrawnAggregates(rs_id)

                    If withdraw > 0 Then
                        customMsg.message("error", "Cannot item-checked — some items are already withdrawn.", "SUPPLY INFO:")
                        Exit Sub
                    End If

                ElseIf selectedRow.Cells(NameOf(cn.type_of_purchasing)).Value = cTypeOfPurchasing.DR Then
                    Dim rs_id As Integer = selectedRow.Cells(NameOf(NEWDRMODEL.cn.rs_id)).Value

                    Dim delivered = getDeliveredAggregates(rs_id,
                                                               selectedRow.Cells(NameOf(cn.inOut)).Value)

                    If delivered > 0 Then
                        customMsg.message("error", "Cannot item-checked — some items are already delivered.", "SUPPLY INFO:")
                        Exit Sub
                    End If
                End If
            End If

#End Region
            Dim removeditemchecked As Boolean = NEWDRMODEL.removeItemChecked()

            If removeditemchecked = True Then
                customMsg.message("info", "item checked successfully removed...", "SUPPLY INFO:")
                btnSearch.PerformClick()
            Else
                customMsg.message("error", "there's something wrong with removing item checked...", "SUPPLY INFO:")
            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
    Public Sub get_Frequisition_non_item_Data(ByVal rs_id As Integer)
        Try
            SQLcon.connection.Open()
            Dim sqlcomm As New SqlCommand
            Dim newDr As SqlDataReader

            sqlcomm.Connection = SQLcon.connection
            sqlcomm.CommandText = "sp_crud_Requisition_Non_Item"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", 28)
            sqlcomm.Parameters.AddWithValue("@rs_id", rs_id)

            newDr = sqlcomm.ExecuteReader

            While newDr.Read

                With FRequisition_Non_Item
                    .txtItemDesc.Text = newDr.Item("item_desc").ToString
                    .txtLoc.Text = newDr.Item("location").ToString
                    .txtJOno.Text = newDr.Item("job_order_no").ToString
                    .txtUnit.Text = newDr.Item("unit").ToString
                    .txtPrice.Text = newDr.Item("price").ToString
                    .txtAmount.Text = newDr.Item("amount").ToString
                    .txtApprovedby.Text = newDr.Item("approved_by").ToString
                    .txtNotedBy.Text = newDr.Item("noted_by").ToString
                    .txtRemarksForEmd.Text = newDr.Item("remarks_emd_purposed").ToString
                    .cmbTypeOfChargesName.Text = newDr.Item("typeOfCharges").ToString
                    .cmbTypeofCharge.Text = newDr.Item("chargeTo").ToString
                End With

            End While
            newDr.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
        End Try

    End Sub
    Public Function get_Frequisition_non_item_charge_to(ByVal x As String, ByVal y As String, ByVal n As Integer) As String
        Dim newSqlcon As New SQLcon
        Try
            Dim Newsqlcomm As New SqlCommand
            Dim newDr1 As SqlDataReader

            newSqlcon.connection.Open()
            Newsqlcomm.Connection = SQLcon.connection
            Newsqlcomm.CommandText = "sp_crud_Requisition_Non_Item"
            Newsqlcomm.CommandType = CommandType.StoredProcedure
            If n = 1 Then
                Newsqlcomm.Parameters.AddWithValue("@n", 6)
                Newsqlcomm.Parameters.AddWithValue("@type_name", x)
                Newsqlcomm.Parameters.AddWithValue("@charge_to_id", CInt(y))
            ElseIf n = 2 Then
                Newsqlcomm.Parameters.AddWithValue("@n", 7)
                Newsqlcomm.Parameters.AddWithValue("@wh_area_id", CInt(y))
            ElseIf n = 3 Then
                Newsqlcomm.Parameters.AddWithValue("@n", 8)
                Newsqlcomm.Parameters.AddWithValue("@proj_id", CInt(y))
            ElseIf n = 4 Then
                Newsqlcomm.Parameters.AddWithValue("@n", 9)
                Newsqlcomm.Parameters.AddWithValue("@equipListID", CInt(y))
            End If

            newDr1 = Newsqlcomm.ExecuteReader

            While newDr1.Read
                If n = 1 Then
                    get_Frequisition_non_item_charge_to = newDr1.Item("charge_to").ToString
                ElseIf n = 2 Then
                    get_Frequisition_non_item_charge_to = newDr1.Item("wh_area").ToString
                ElseIf n = 3 Then
                    get_Frequisition_non_item_charge_to = newDr1.Item("project_desc").ToString
                ElseIf n = 4 Then
                    get_Frequisition_non_item_charge_to = newDr1.Item("plate_no").ToString
                End If
            End While
            newDr1.Close()

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            newSqlcon.connection.Close()
        End Try
    End Function
    Public Sub get_Frequisition_non_item_multicharges_data(ByVal x As Integer)
        Try
            SQLcon.connection.Open()
            Dim sqlcomm As New SqlCommand
            Dim newDr As SqlDataReader
            Dim type_name As String = ""
            Dim all_charges_id As Integer

            sqlcomm.Connection = SQLcon.connection
            sqlcomm.CommandText = "sp_crud_Requisition_Non_Item"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", 5)
            sqlcomm.Parameters.AddWithValue("@rs_id", x)

            newDr = sqlcomm.ExecuteReader

            While newDr.Read
                type_name = newDr.Item("type_name").ToString
                all_charges_id = newDr.Item("all_charges_id").ToString
            End While
            newDr.Close()


            If type_name.Equals("WAREHOUSE") Then
                With FRequisition_Non_Item
                    .cmbTypeOfChargesName.Text = type_name
                    .cmbTypeofCharge.Text = get_Frequisition_non_item_charge_to("WAREHOUSE", all_charges_id, 2)
                End With
            ElseIf type_name.Equals("PROJECT") Then
                With FRequisition_Non_Item
                    .cmbTypeOfChargesName.Text = type_name
                    .cmbTypeofCharge.Text = get_Frequisition_non_item_charge_to("PROJECT", all_charges_id, 3)
                End With
            ElseIf type_name.Equals("EQUIPMENT") Then
                With FRequisition_Non_Item
                    .cmbTypeOfChargesName.Text = type_name
                    .cmbTypeofCharge.Text = get_Frequisition_non_item_charge_to("EQUIPMENT", all_charges_id, 4)
                End With
            ElseIf type_name.Equals("") Then
                MsgBox("Please contact to IT Personnel")
            Else
                With FRequisition_Non_Item
                    .cmbTypeOfChargesName.Text = type_name
                    .cmbTypeofCharge.Text = get_Frequisition_non_item_charge_to(type_name, all_charges_id, 1)
                End With
            End If

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLcon.connection.Close()
        End Try
    End Sub
    Public Function _getId_v1(ByVal n As Integer, ByVal valueID As Integer, Optional value As String = "") As Integer
        Dim Sql_conn As New SQLcon
        Dim dr As SqlDataReader

        Try
            Sql_conn.connection.Open()
            Dim sqlcomm As New SqlCommand
            sqlcomm.Connection = Sql_conn.connection
            sqlcomm.CommandText = "sp_crud_Requisition_Non_Item"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", n)
            sqlcomm.Parameters.AddWithValue("@valueID", valueID)
            sqlcomm.Parameters.AddWithValue("@value", value)
            dr = sqlcomm.ExecuteReader
            While dr.Read
                If String.IsNullOrEmpty(dr.Item(0).ToString) Then
                    _getId_v1 = 0
                Else
                    _getId_v1 = dr.Item(0).ToString
                End If
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Sql_conn.connection.Close()
        End Try
        Return _getId_v1
    End Function
    Public Function _getValue(ByVal n As Integer, ByVal valueID As Integer) As String
        Dim Sql_conn As New SQLcon
        Dim dr As SqlDataReader
        Dim result As String = ""

        Try
            Sql_conn.connection.Open()
            Dim sqlcomm As New SqlCommand
            sqlcomm.Connection = Sql_conn.connection
            sqlcomm.CommandText = "sp_crud_Requisition_Non_Item"
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@n", n)
            sqlcomm.Parameters.AddWithValue("@valueID", valueID)

            dr = sqlcomm.ExecuteReader
            While dr.Read
                result = dr.Item(0).ToString
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Sql_conn.connection.Close()
        End Try
        Return result
    End Function
    Private Function editCash() As Boolean
        Dim selectedRows = DataGridView1.SelectedRows(0)
        Dim typeOfPurchase As String = selectedRows.Cells(NameOf(cn.type_of_purchasing)).Value

        If typeOfPurchase = "CASH WITH RR" Or typeOfPurchase = "CASH WITHOUT RR" Then
            FRequisition_Non_Item.Show() 'show form
            With FRequisition_Non_Item
                Dim rs_id As Integer = CInt(selectedRows.Cells(NameOf(cn.rs_id)).Value)
                get_Frequisition_non_item_Data(rs_id)

                Dim value As String = selectedRows.Cells(NameOf(cn.type_of_request)).Value
                Dim parts() As String = value.Split("/"c).Select(Function(x) x.Trim()).ToArray()

                .cmbRequestType.Text = parts(0)
                .cmbTOR_sub.Text = parts(1)

                If parts.Length = 2 Then
                    .cmbAccountTitle.Text = ""
                Else
                    '****consolidated account****
                    Dim tors_ca_id As Integer = _getId_v1(30, rs_id)
                    Dim accountTitle As String = _getValue(31, tors_ca_id)
                    .cmbAccountTitle.Text = accountTitle
                    '****************************
                End If

                .cmbCash_wrr_worr.Text = selectedRows.Cells(NameOf(cn.type_of_purchasing)).Value
                .txtRSno.Text = selectedRows.Cells(NameOf(cn.rs_no)).Value
                .DTPReq.Value = selectedRows.Cells(NameOf(cn.rs_ws_po_rr_dr_date)).Value
                .txtQty.Text = selectedRows.Cells(NameOf(cn.rs_qty)).Value
                .txtPurpose.Text = selectedRows.Cells(NameOf(cn.purpose)).Value
                .DTPTimeNeeded.Value = selectedRows.Cells(NameOf(cn.date_needed)).Value
                .txtRequestBy.Text = selectedRows.Cells(NameOf(cn.requested_by)).Value
                .lbl_rs_id.Text = rs_id
                .cmbRequestType.Focus()

                If boolProcEditCopy = False Then ' para sa copy og edit
                    .btnSave.Text = "Update"
                Else
                    .btnSave.Text = "Save"
                End If
                boolProcEditCopy = False 'back to default

            End With

            Return True
        End If

        Return False
    End Function

    Private Sub EditAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditAllToolStripMenuItem.Click
        Try
            boolProcEditCopy = False 'para sa button mailhan kung edit or copy bah
            If editCash() Then
                Exit Sub
            End If

            Dim cn = NEWDRMODEL.cn
            Dim row = DataGridView1.SelectedRows(0)
            Dim rs_id As Integer = row.Cells(NameOf(cn.rs_id)).Value
            Dim rsData = NEWDRMODEL.getListOfRsForDr().FirstOrDefault(Function(x) x.rs_id = rs_id)

            Dim rsRemainingBalance As Double = NEWDRMODEL.getRsRemainingBalance(rs_id)

            With FCreateRSForm

                .isEditAll = True
                .ccopyRsData = rsData
                .cRSRemainingQuantity = rsRemainingBalance
                .btnSave.Text = "Update RS"
                .ShowDialog()

            End With
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Dispose()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        FRequisition_Non_Item.ShowDialog()
    End Sub

    Private Sub QuarryToStockpileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuarryToStockpileToolStripMenuItem.Click
        Try
            cDr_transaction = cCrushingAndHaulingTransaction.QUARRY_TO_STOCKPILE
            createDeliveryReceipt()

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

#Region "UTILITIES"
    Private Function getDeliveredAggregates() As Double
        Try
            Dim row = DataGridView1.SelectedRows(0)
            Dim rowColor = row.DefaultCellStyle.BackColor
            Dim inOut As String = row.Cells(NameOf(NEWDRMODEL.cn.inOut)).Value

            Select Case rowColor
                Case cRsRowColor.MainSubRS
                    Dim rs_id As Integer = row.Cells(NameOf(NEWDRMODEL.cn.rs_id)).Value

                    getDeliveredAggregates = NEWDRMODEL.getDeliveredAggregates(inOut, rs_id)

                Case cRsRowColor.WsPo
                    Dim ws_po_det_id As Integer = row.Cells(NameOf(NEWDRMODEL.cn.rs_id)).Value

                    getDeliveredAggregates = NEWDRMODEL.getDeliveredAggregates(inOut, ws_po_det_id)

                Case cRsRowColor.Rr
                    Dim rr_item_id As Integer = row.Cells(NameOf(NEWDRMODEL.cn.rs_id)).Value

                    getDeliveredAggregates = NEWDRMODEL.getDeliveredAggregates(inOut, rr_item_id)

            End Select

            Return getDeliveredAggregates
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function
    Private Sub RemoveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveToolStripMenuItem.Click
        Try

            Dim selectedRow = DataGridView1.SelectedRows(0)

            Dim rsRow = NEWDRMODEL.getListOfRsDatas().FirstOrDefault(Function(x) x.rs_id = selectedRow.Cells(NameOf(cn.rs_id)).Value And
                                                                         x.level = selectedRow.Cells(NameOf(cn.level)).Value)

            If customMsg.messageYesNo("Are you sure you want delete this rs?", "SUPPLY INFO:", MessageBoxIcon.Question) Then
                Dim deleteResult = NEWDRMODEL.removeRequisition(rsRow)

                If deleteResult Then
                    customMsg.message("info", "Successfully removed...", "SUPPLY INFO:")

                    Dim rsDatas = NEWDRMODEL.getListOfRsDatas().Where(Function(x) x.rs_id <> rsRow.rs_id And
                                                                          rsRow.level = NEWDRMODEL.getLevel.sub_rs).ToList()
                    'DataGridView1.DataSource = rsDatas

                    btnSearch.PerformClick()
                End If
            End If


        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
    Private Sub AddMoreChargesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddMoreChargesToolStripMenuItem.Click
        Try
            Dim rsId As Integer = DataGridView1.SelectedRows(0).Cells(NameOf(cn.rs_id)).Value
            With FCreateChargesNew
                .getCreateChargesModel().initialize_rsId(rsId)
                .ShowDialog()
            End With

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
    Private Function getPurchasedAggregates(rs_id As Integer) As Double
        Try
            getPurchasedAggregates = NEWDRMODEL.getPurchasedAggregates(rs_id)

            Return getPurchasedAggregates

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Private Function getReceivedAggregates(po_det_id As Integer) As Double
        Try
            getReceivedAggregates = NEWDRMODEL.getReceivedAggregates(po_det_id)

            Return getReceivedAggregates

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Private Function getWithdrawnAggregates(rs_id As Integer) As Double
        Try
            getWithdrawnAggregates = NEWDRMODEL.getWithdrawnAggregates(rs_id)

            Return getWithdrawnAggregates

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Private Function getWithdrawnPartially(wsId As Integer) As Double
        Try
            getWithdrawnPartially = NEWDRMODEL.getWithdrawnPartially(wsId)

            Return getWithdrawnPartially

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Private Function getDeliveredAggregates(rs_id As Integer, inOut As String) As Double
        Try
            getDeliveredAggregates = NEWDRMODEL.getDeliveredAggregates(inOut, rs_id)

            Return getDeliveredAggregates
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function


    Private Sub CancelToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CancelToolStripMenuItem1.Click
        If Utilities.isAuthenticated(auth) Then
            cancelRs()
        End If
    End Sub

    Private Sub UndoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UndoToolStripMenuItem.Click
        If Utilities.isAuthenticated(auth) Then
            uncancelRs()
        End If
    End Sub

    Private Sub SearchByToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SearchByToolStripMenuItem.Click
        FRequesitionSearchBy.ShowDialog()
    End Sub

    Private Sub CreateMainRSQuantityToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateMainRSQuantityToolStripMenuItem.Click
        Dim selectedRow = DataGridView1.SelectedRows(0)

        If selectedRow.Cells(NameOf(cn.division)).Value = cDivision.CRUSHING_AND_HAULING Then
            FMainRS_New.isCreateMainRsQty = True
            FMainRS_New.ShowDialog()
        Else
            customMsg.message("error", $"this transaction is not applicable in {cDivision.WAREHOUSING_AND_SUPPLY}", "SMS INFO:")
        End If


    End Sub
    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                btnSearch.PerformClick()
            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub CancelPOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelPOToolStripMenuItem.Click
        cancelPo()
    End Sub

    Private Sub UndoToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles UndoToolStripMenuItem1.Click
        uncancelPo()
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        Try
            NEWDRMODEL.initialize_searchPanel(Panel11)
            NEWDRMODEL.execute_initialize(loadingPanel)
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub


#End Region
#Region "CANCEL TRANSACTION"
    Private Sub cancelRs()
        Try
            Dim selectedRow = DataGridView1.SelectedRows(0)

#Region "FILTER"

            If selectedRow.Cells(NameOf(cn.type_of_purchasing)).Value = cTypeOfPurchasing.PURCHASE_ORDER Then

                Dim rs_id As Integer = selectedRow.Cells(NameOf(NEWDRMODEL.cn.rs_id)).Value
                Dim purchased = getPurchasedAggregates(rs_id)

                If purchased > 0 Then
                    customMsg.message("error", "Cannot cancel RS — some items are already purchased!.", "SUPPLY INFO:")
                    Exit Sub
                End If

            ElseIf selectedRow.Cells(NameOf(cn.type_of_purchasing)).Value = cTypeOfPurchasing.WITHDRAWAL Then
                Dim rs_id As Integer = selectedRow.Cells(NameOf(NEWDRMODEL.cn.rs_id)).Value
                Dim withdraw = getWithdrawnAggregates(rs_id)

                If withdraw > 0 Then
                    customMsg.message("error", "Cannot cancel RS — some items are already withdrawn.", "SUPPLY INFO:")
                    Exit Sub
                End If

            ElseIf selectedRow.Cells(NameOf(cn.type_of_purchasing)).Value = cTypeOfPurchasing.DR Then
                Dim rs_id As Integer = selectedRow.Cells(NameOf(NEWDRMODEL.cn.rs_id)).Value

                Dim delivered = getDeliveredAggregates(rs_id,
                                                       selectedRow.Cells(NameOf(cn.inOut)).Value)

                If delivered > 0 Then
                    customMsg.message("error", "Cannot cancel RS — some aggregates are already delivered.", "SUPPLY INFO:")
                    Exit Sub
                End If
            End If
#End Region
            Dim resultData = NEWDRMODEL.isCancelled(selectedRow.Cells(NameOf(cn.rs_id)).Value, "RS")

            If resultData.count > 0 Then
                Dim _cancelled As New PropsFields.CancelledTransaction

                For Each row In resultData
                    _cancelled.id = row("id")
                    _cancelled.trans = row("trans")
                    _cancelled.trans_id = row("trans_id")
                    _cancelled.remarks = row("remarks")

                Next

                With FCancelServicesForm

                    .cCancelStorage = _cancelled
                    .btnCancel.Text = "Update Remarks"
                    .cUpdateCancelForRs = True
                    .ShowDialog()

                End With

            Else
                With FCancelServicesForm
                    .btnCancel.Text = "Cancel"
                    .cCancelForRs = True
                    .ShowDialog()
                End With

            End If

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

    End Sub

    Private Sub uncancelRs()
        Try
            If customMsg.messageYesNo("Are you sure you want to undo rs?", "SUPPLY INFO:") Then

                Dim undoCancel As New ColumnValuesObj
                Dim selectedRow = DataGridView1.SelectedRows(0)
                Dim rs_id As Integer = selectedRow.Cells(NameOf(cn.rs_id)).Value

                undoCancel.setCondition($"trans_id = {rs_id}")
                undoCancel.deleteData("dbCancelledTransaction")

                NEWDRMODEL.isCancelRs = True
                NEWDRMODEL.cRsId = rs_id

                btnSearch.PerformClick()

            End If

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub cancelPo()
        Try
            Dim selectedRow = DataGridView1.SelectedRows(0)
#Region "FILTER"

            If selectedRow.Cells(NameOf(cn.type_of_purchasing)).Value = cTypeOfPurchasing.PURCHASE_ORDER Then

                Dim po_det_id As Integer = selectedRow.Cells(NameOf(NEWDRMODEL.cn.rs_id)).Value
                Dim received = getReceivedAggregates(po_det_id)

                If received > 0 Then
                    customMsg.message("error", "Cannot cancel PO — some items are already received!.", "SUPPLY INFO:")
                    Exit Sub
                End If
            End If
#End Region
            Dim resultData = NEWDRMODEL.isCancelled(selectedRow.Cells(NameOf(cn.rs_id)).Value, "PO")

            If resultData.count > 0 Then
                Dim _cancelled As New PropsFields.CancelledTransaction

                For Each row In resultData
                    _cancelled.id = row("id")
                    _cancelled.trans = row("trans")
                    _cancelled.trans_id = row("trans_id")
                    _cancelled.remarks = row("remarks")
                Next

                With FCancelServicesForm

                    .cCancelStorage = _cancelled
                    .btnCancel.Text = "Update Remarks"
                    .cUpdateCancelForPo = True
                    .ShowDialog()

                End With

            Else
                With FCancelServicesForm
                    .btnCancel.Text = "Cancel"
                    .cCancelForPo = True
                    .ShowDialog()
                End With

            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub cancelWs()
        Try
            Dim selectedRow = DataGridView1.SelectedRows(0)
#Region "FILTER"

            If selectedRow.Cells(NameOf(cn.type_of_purchasing)).Value = cTypeOfPurchasing.WITHDRAWAL Then

                Dim ws_id As Integer = selectedRow.Cells(NameOf(NEWDRMODEL.cn.rs_id)).Value
                Dim withdrawn = getWithdrawnPartially(ws_id)

                If withdrawn > 0 Then
                    customMsg.message("error", "Cannot cancel WS — some items are already withdrawn!.", "SUPPLY INFO:")
                    Exit Sub
                End If
            End If
#End Region
            Dim resultData = NEWDRMODEL.isCancelled(selectedRow.Cells(NameOf(cn.rs_id)).Value, "WS")

            If resultData.count > 0 Then
                Dim _cancelled As New PropsFields.CancelledTransaction

                For Each row In resultData
                    _cancelled.id = row("id")
                    _cancelled.trans = row("trans")
                    _cancelled.trans_id = row("trans_id")
                    _cancelled.remarks = row("remarks")
                Next

                With FCancelServicesForm

                    .cCancelStorage = _cancelled
                    .btnCancel.Text = "Update Remarks"
                    .cUpdateCancelForWs = True
                    .ShowDialog()

                End With

            Else
                With FCancelServicesForm
                    .btnCancel.Text = "Cancel"
                    .cCancelForWs = True
                    .ShowDialog()
                End With

            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub unCancelWs()
        Try
            If customMsg.messageYesNo("Are you sure you want to undo ws?", "SUPPLY INFO:") Then

                Dim undoCancel As New ColumnValuesObj
                Dim selectedRow = DataGridView1.SelectedRows(0)
                Dim wsId As Integer = selectedRow.Cells(NameOf(cn.rs_id)).Value

                undoCancel.setCondition($"trans_id = {wsId} and trans = 'WS'")
                undoCancel.deleteData("dbCancelledTransaction")

                NEWDRMODEL.isCancelWs = True
                NEWDRMODEL.cRsId = wsId

                btnSearch.PerformClick()

            End If

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub


    Private Sub uncancelPo()
        Try
            If customMsg.messageYesNo("Are you sure you want to undo po?", "SUPPLY INFO:") Then

                Dim undoCancel As New ColumnValuesObj
                Dim undoCancel2 As New ColumnValuesObj

                Dim selectedRow = DataGridView1.SelectedRows(0)
                Dim poDetId As Integer = selectedRow.Cells(NameOf(cn.rs_id)).Value

                undoCancel2.add("cancel_status", Nothing)
                undoCancel2.setCondition($"po_det_id = {poDetId}")
                undoCancel2.updateQuery("dbPO_details")

                undoCancel.setCondition($"trans_id = {poDetId}")
                undoCancel.deleteData("dbCancelledTransaction")

                NEWDRMODEL.isCancelPo = True
                NEWDRMODEL.cRsId = poDetId

                btnSearch.PerformClick()

            End If

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub EditRSQtyForCuttingOfRSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditRSQtyForCuttingOfRSToolStripMenuItem.Click
        Try
            Dim selectedRow = DataGridView1.SelectedRows(0)
            Dim rsData = NEWDRMODEL.getListOfRsForDr().FirstOrDefault(Function(x)
                                                                          Return x.rs_id = selectedRow.Cells(NameOf(cn.rs_id)).Value
                                                                      End Function)

            If isOnwerOfSelectedRsData() OrElse Utilities.isAuthenticatedWithoutMessage(auth) Then

                If selectedRow.Cells(NameOf(cn.level)).Value = NEWDRMODEL.getLevel().sub_rs Then
                    With FEditRSQtyOnly

                        .cRsQty = rsData.rs_qty  'selectedRow.Cells(NameOf(cn.rs_qty)).Value
                        .cUnit = rsData.unit_from_rs
                        .cRsId = selectedRow.Cells(NameOf(cn.rs_id)).Value

                        .ShowDialog()
                    End With
                Else
                    customMsg.message("error", "select an RS row to proceed to this transaction!", "SMS INFO:")
                End If

            Else
                customMsg.message("error", "You are not the owner of this data!", "SMS INFO:")
            End If

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub CancelWSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelWSToolStripMenuItem.Click
        cancelWs()
    End Sub

    Private Sub UndoToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles UndoToolStripMenuItem2.Click
        unCancelWs()
    End Sub

#End Region

#Region "PUBLIC GET"
    Public Function isOnwerOfSelectedRsData()
        Try
            Dim cn = getNewDrModel().cn
            Dim rsId As Integer = DataGridView1.SelectedRows(0).Cells(NameOf(cn.rs_id)).Value

            Dim rsData = getRsDataByRsId(rsId)

            If Utilities.isOnwerOfData(rsData.user_id) OrElse
                Utilities.isAuthenticatedWithoutMessage(auth) Then

                Return True

            Else
                Return False

            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Private Function getRsDataByRsId(rsId As Integer) As PropsFields.rs_for_dr_props_fields
        Try
            Dim model = getNewDrModel()
            Dim rsdata = model.getListOfRsForDr().FirstOrDefault(Function(x) x.rs_id = rsId)

            Return rsdata
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Private Sub ColumnSettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ColumnSettingsToolStripMenuItem.Click
        Try
            Dim listOfColumnSettings As New List(Of PropsFields.columnSettings)

            With FColumnSettings
                customDataGrid.customDatagridview(.DataGridView1)
                customDataGrid.autoSizeColumn(.DataGridView1, True)

                For Each col As DataGridViewColumn In DataGridView1.Columns
                    Dim colSettings As New PropsFields.columnSettings

                    With colSettings
                        .displayIndex = col.DisplayIndex.ToString()
                        .headerText = col.HeaderText
                        .headerName = col.Name
                    End With

                    listOfColumnSettings.Add(colSettings)
                Next

                .isFromRsForm = True
                .DataGridView1.DataSource = listOfColumnSettings

                customDatagridView(.DataGridView1)
                .ShowDialog()
            End With
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

    End Sub

    Private Sub customDatagridView(dgv As DataGridView)
        Try
            Dim cn3 As New PropsFields.columnSettings

            ''hide columns
            'For Each column As DataGridViewColumn In dgv.Columns
            '    If column.Name = NameOf(cn3.headerName) Then
            '        column.Visible = False
            '    Else
            '        column.Visible = True
            '    End If
            'Next

            Dim chkCol As New DataGridViewCheckBoxColumn() With {
                  .Name = "Select",                ' column’s internal name
                  .HeaderText = "Select",          ' what shows in the header
                  .Width = 50,                     ' optional sizing
                  .ReadOnly = False             ' allow the user to check/uncheck
                  }

            dgv.Columns.Add(chkCol)

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub




#End Region
#Region "UTILITY HELPER"
    Private Function isForCrushingAndHauling() As Boolean
        Try
            Dim selectedRow = DataGridView1.SelectedRows(0)

            If selectedRow.Cells(NameOf(cn.division)).Value = cDivision.CRUSHING_AND_HAULING Then
                Return True
            Else
                Return False
                customMsg.message("error", "this transaction is not applicable in creating DR!", "SUPPLY INFO:")
            End If

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

    End Function

    Private Sub QuarryToProjectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuarryToProjectToolStripMenuItem.Click
        Try
            cDr_transaction = cCrushingAndHaulingTransaction.QUARRY_TO_PROJECT
            createDeliveryReceipt()

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub StockpileToStockpileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StockpileToStockpileToolStripMenuItem.Click
        Try
            cDr_transaction = cCrushingAndHaulingTransaction.STOCKPILE_TO_STOCKPILE
            createDeliveryReceipt()
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub StockpileToProjectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StockpileToProjectToolStripMenuItem.Click
        Try
            cDr_transaction = cCrushingAndHaulingTransaction.STOCKPILE_TO_PROJECT
            createDeliveryReceipt()
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub WasteDisposalAndOthersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WasteDisposalAndOthersToolStripMenuItem.Click
        Try
            cDr_transaction = cCrushingAndHaulingTransaction.WASTE_DISPOSAL_AND_OTHERS
            createDeliveryReceipt()

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

#End Region

End Class