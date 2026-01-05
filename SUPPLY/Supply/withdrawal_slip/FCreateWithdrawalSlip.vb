
Imports System.Data.SqlClient
Imports SUPPLY.class_placeholder5
Imports SUPPLY.FCreateDeliveryReceipt
Imports SUPPLY.PropsFields

Public Class FCreateWithdrawalSlip
    Private dateIssuedUI, dateNeededUI, issuedByUI, chargesUI, whLocationUI, rsNoUI As New class_placeholder5
    Private rsNoUI2 As New class_placeholder5
    Public wsNoUI, wsQtyUI, amountUI, unitUI, supplierUI, termsUI, tireSerialNoUI, otherCategoryUI As New class_placeholder5
    Dim c As New WithdrawalItems
    Private cListOfWithrawalItems As New List(Of withdrawalRow)

    Public wsNew As New customWsProps
    Private dgvcol_old As New withdrawalRow
    Private customDgv As New CustomGridview
    Private dgvCol As New customHeaderProps
    Dim cBgWorkerChecker As Timer
    Private supplierModel, employeeModel, serialNoModel As New ModelNew.Model
    Private rowCounter As Integer = 1
    Private customMsg As New customMessageBox
    Private edited As New List(Of withdrawalRow)
    Public saveStatus As Integer
    Public cWsInfoId As Integer
    Public cWsId As Integer
    Private cOthersCategory As New OTHERSCATEGORY
    Public cTireSerialStore As New PropsFields.tireSerialView_props_fields
    Private wr As New withdrawalRow

    Public updateWithdrawalStorage As New Create_withdrawal_slip_for_warehouseing_fields
    Public isCreateWithdrawalFromNewRsForm As Boolean
    Public isEdit As Boolean
    Private isEditFromDatagridView As Boolean

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Const CS_DROPSHADOW As Integer = &H20000
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ClassStyle = cp.ClassStyle Or CS_DROPSHADOW
            Return cp
        End Get
    End Property

    Public Class withdrawalRow
        Public Property wsNo As String
        Public Property qty As Double
        'Public Property supplier As String
        Public Property unit As String
        Public Property unit_price As Double
        Public Property amount As Double
        'Public Property terms As String
        Public Property col_id As Integer
        Public Property serial_id As Integer
        Public Property tireCategory As String

    End Class

    Public Class customWsProps
        Inherits PropsFields.withdrawal_props_fields

        Public Property units As String
        Public Property whLocation As String
        Public Property rsQty_remaining As Double

    End Class

    Public Class customHeaderProps
        Public ReadOnly Property WSNO As String = "WS NO"
        Public ReadOnly Property QTY As String = "QTY"
        Public ReadOnly Property UNITS As String = "UNITS"
        Public ReadOnly Property UNIT_PRICE As String = "UNIT PRICE"
        Public ReadOnly Property AMOUNT As String = "AMOUNT"
        'Public ReadOnly Property SUPPLIER As String = "SUPPLIER"
        Public ReadOnly Property ITEM_DESC As String = "ITEM DESCRIPTION"
        Public ReadOnly Property RR_NO As String = "RR NO."
        Public ReadOnly Property POSITION As String = "POSITION"
        Public ReadOnly Property REMAINING_BALANCE As String = "REM.BALANCE"
        Public ReadOnly Property SERIAL_NO As String = "SERIAL NO."

    End Class

    Public ReadOnly Property getListOfWithrawalItems() As List(Of withdrawalRow)
        Get
            Return cListOfWithrawalItems
        End Get
    End Property

    Private Sub CreateWithdrawalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateWithdrawalToolStripMenuItem.Click
        btnSaveWithdrawal.Text = "Save"
        openPanelCreateWithdrawal()
    End Sub
    Private Sub openPanelCreateWithdrawal()

        For Each ctr As Control In Panel6.Controls
            If ctr.Name = NameOf(Panel7) Then
                ctr.Visible = True
            Else
                ctr.Enabled = False
            End If
        Next

        For Each ctr As Control In Panel2.Controls
            ctr.Enabled = False
        Next

        If Not isEdit Then
            unitUI.tbox.Text = wsNew.units
            unitUI.resetBgColor()
        End If

        'txtTerms.Text = "30 days"
        If edited.Count = 0 Then
            otherCategoryUI.cBox.SelectedIndex = 0
            otherCategoryUI.cBox.Focus()
            otherCategoryUI.resetBgColor()
        End If

    End Sub
    Private Sub panelBoxClose()
        For Each ctr As Control In Panel6.Controls
            If ctr.Name = NameOf(Panel7) Then
                ctr.Visible = False
            Else
                ctr.Enabled = True
            End If
        Next

        For Each ctr As Control In Panel3.Controls
            If isEdit Then
                Panel8.Enabled = False
            Else
                ctr.Enabled = True
            End If

        Next

        For Each ctr As Control In Panel2.Controls
            ctr.Enabled = True
        Next

        Panel7.Visible = False
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSaveWithdrawal.Click
        Try
            Dim dgvRow As New withdrawalRow

#Region "+ FILTER"
            If wsNoUI.ifBlankTexbox() Or
                wsQtyUI.ifBlankTexbox() Or
                unitUI.ifBlankTexbox() Or
                amountUI.ifBlankTexbox() Then
                'supplierUI.ifBlankTexbox() Or
                'termsUI.ifBlankTexbox() Then

                If Not isEdit Then
                    customMsg.message("error", "You must fill up the requirements field first to proceed the transaction...", "SUPPLY INFO:")
                    Exit Sub
                End If

            ElseIf wsQtyUI.tbox.Text = 0 Then
                customMsg.message("error", "quantity must not be zero...", "SUPPLY INFO:")
                Exit Sub
            End If

#End Region

            With dgvRow
                If isEditFromDatagridView Then
                    If edited.Count > 0 Then
                        Dim selectedRow = DataGridView1.SelectedRows(0)
                        Dim oldQty As Double = selectedRow.Cells(NameOf(dgvRow.qty)).Value

#Region "==> UPDATE"
#Region "FILTER"
                        Dim totalQtyAddedInRows As Double
                        Dim totalQtyAddedInRowsWithSerial As Double = getTotalQtyAddedinRowsWithSerial(txtQty.Text,
                                                                                                       cTireSerialStore.serial_id,
                                                                                                       True,
                                                                                                       oldQty)

                        Dim tire = Results.rListOfTireSerialNoView.FirstOrDefault(Function(x) x.serial_id = cTireSerialStore.serial_id)


                        If tire?.remaining_balance < totalQtyAddedInRowsWithSerial And
                            cmbOthersCategory.Text = cOthersCategory.TIRE_STORAGE Then

                            customMsg.message("error", "you are exceeded to the tire remaining balance!", "SUPPLY INFO:")
                            Exit Sub
                        End If

                        totalQtyAddedInRows = getTotalQtyAddedinRows(wsQtyUI.tbox.Text, True, oldQty)

                        If totalQtyAddedInRows > wsNew.rsQty_remaining And Not isEdit Then
                            customMsg.message("error", "you are exceeded to the limit!", "SUPPLY INFO:")
                            Exit Sub
                        End If

#End Region
                        Dim index As Integer = cListOfWithrawalItems.FindIndex(Function(x) x.col_id = edited(0).col_id)

                        With cListOfWithrawalItems(index)

                            .wsNo = wsNoUI.tbox.Text
                            .qty = wsQtyUI.tbox.Text
                            .unit = unitUI.tbox.Text
                            .unit_price = amountUI.tbox.Text
                            .amount = .unit_price * .qty
                            .serial_id = cTireSerialStore.serial_id

                        End With
#End Region
                        isEditFromDatagridView = False
                    End If
                Else
#Region "==> SAVE"

#Region "+ FILTER"
                    Dim totalQtyAddedinRowsWithSerial As Double = getTotalQtyAddedinRowsWithSerial(CDbl(txtQty.Text),
                                                                                                   cTireSerialStore.serial_id)

                    If cTireSerialStore.remaining_balance < totalQtyAddedinRowsWithSerial And
                        cmbOthersCategory.Text = cOthersCategory.FOR_TIRE_STOCKING Then

                        customMsg.message("error", "you are exceeded to the tire remaining balance!", "SUPPLY INFO:")
                        Exit Sub
                    End If

                    If getTotalQtyAddedinRows(wsQtyUI.tbox.Text) > wsNew.rsQty_remaining Then
                        customMsg.message("error", "you are exceeded to the limit!", "SUPPLY INFO:")
                        Exit Sub
                    End If

#End Region
                    .wsNo = wsNoUI.tbox.Text
                    .qty = wsQtyUI.tbox.Text
                    .unit = unitUI.tbox.Text
                    .unit_price = FormatNumber(CDbl(amountUI.tbox.Text).ToString())
                    .amount = FormatNumber(CDbl(.unit_price * .qty).ToString())
                    .col_id = rowCounter
                    .serial_id = cTireSerialStore.serial_id
                    .tireCategory = cmbOthersCategory.Text

                    cListOfWithrawalItems.Add(dgvRow)
#End Region
                End If
            End With

            DataGridView1.DataSource = Nothing
            DataGridView1.DataSource = cListOfWithrawalItems

            rowCounter += 1

            panelBoxClose()
            setCustomGridview()

            Utilities.datagridviewSpecificRowFocus(DataGridView1, cListOfWithrawalItems.Count, NameOf(withdrawalRow.col_id))

            issuedByUI.tbox.Focus()
            issuedByUI.resetBgColor()
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
    Private Sub RemoveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveToolStripMenuItem.Click
        Try
            Dim col_id As Integer = DataGridView1.SelectedRows(0).Cells(NameOf(dgvcol_old.col_id)).Value

            cListOfWithrawalItems = cListOfWithrawalItems.Where(Function(x) Not x.col_id = col_id).ToList()
            DataGridView1.DataSource = Nothing
            DataGridView1.DataSource = cListOfWithrawalItems

            If DataGridView1.Rows.Count = 0 Then
                customMsg.message("warning", "we need to restart the form to avoid errors...", "SUPPLY INFO:")
                Me.Dispose()
            Else
                setCustomGridview()
            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

    End Sub
    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        Try
            Dim col_id As Integer = DataGridView1.SelectedRows(0).Cells(NameOf(dgvcol_old.col_id)).Value

            edited = cListOfWithrawalItems.Where(Function(x) x.col_id = col_id).ToList()

            If edited.Count > 0 Then
                wsNoUI.tbox.Text = edited(0).wsNo
                wsNoUI.resetBgColor()

                wsQtyUI.tbox.Text = edited(0).qty
                wsQtyUI.resetBgColor()
                wsQtyUI.tbox.ReadOnly = True

                unitUI.tbox.Text = edited(0).unit
                unitUI.resetBgColor()

                amountUI.tbox.Text = edited(0).unit_price
                amountUI.resetBgColor()

                cTireSerialStore.serial_id = edited(0).serial_id

                If edited(0).serial_id > 0 Then

                    If Results.rListOfTireSerialNoView.Count > 0 Then
                        Dim tire = Results.rListOfTireSerialNoView.FirstOrDefault(Function(x) x.serial_id = edited(0).serial_id)

                        cmbOthersCategory.SelectedIndex = 1
                        txtSerialNo.Text = tire.serial_no
                        lblTireRemaining.Text = $"remaining: {tire.remaining_balance}"

                        'Results.rListOfTireSerialNoView.Where(Function(x)
                        '                                          Return x.serial_id = edited(0).serial_id
                        '                                      End Function).ToList()(0).serial_no

                        tireSerialNoUI.resetBgColor()
                    Else
                        cmbOthersCategory.SelectedIndex = 0
                    End If
                End If

                isEditFromDatagridView = True
                btnSaveWithdrawal.Text = "Update (Ctrl + S)"
                openPanelCreateWithdrawal()

            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub btnFinalSave_Click(sender As Object, e As EventArgs) Handles btnFinalSave.Click

        If isEdit Then
            updateWithdrawalNow()
        Else
            createWithdrawalNow()
        End If


    End Sub

    Private Sub createWithdrawalNow()
        Dim newSQLcon As New SQLcon
        Dim transaction As SqlTransaction = Nothing
        Dim _ws_details_id_for_rs_specific_row_focus As Integer

        Try
#Region "FILTER"
            If issuedByUI.ifBlankTexbox() Then
                customMsg.message("error", "fillup issued by please!", "SUPPLY INFO:")
                Exit Sub
            End If
#End Region
            'update withdrawal
            If saveStatus = SaveBtn.Update Then
                If customMsg.messageYesNo("Are you sure you want to update this selected data?", "SUPPLY INFO:", MessageBoxIcon.Question) Then

#Region "PO INFO"
                    Dim cc As New ColumnValuesObj
                    cc.add("po_date", Date.Parse(dtpDateIssued.Text).Date())
                    cc.add("date_needed", Date.Parse(dtpDateNeeded.Text).Date())
                    cc.add("user_id", pub_user_id)
                    cc.add("date_log_updated", Date.Parse(Now))
                    cc.add("issued_by", txtIssuedBy.Text)

                    cc.setCondition($"po_id = {cWsInfoId}")
                    cc.updateQuery("dbPO")
#End Region

#Region "LOAD AGAIN"
                    With FWithdrawalList
                        .loadingStat = FWithdrawalList.LoadingStatus.withdrawalReleased
                        .cPartiallyWithdrawnId = cWsInfoId
                        .loadWhItems()
                    End With
#End Region
                    FWithdrawalList.isEdit = True
                    FWithdrawalList.cWsId = cWsId
                    FWithdrawalList.btnSearch.PerformClick()

                    Me.Close()

                End If
                Exit Sub
            End If

            'insert withdrawal
            If cListOfWithrawalItems.Count > 0 Then

                If customMsg.messageYesNo("Are you sure you want to release withdrawal now?", "SUPPLY INFO:") Then
                    'insert
                    'first: ws info
                    newSQLcon.connection.Open()
                    transaction = newSQLcon.connection.BeginTransaction()

#Region "WS INFO"
                    Dim cc As New ColumnValuesObj
                    cc.add("po_date", Date.Parse(dtpDateIssued.Text).Date())
                    cc.add("rs_no", txtRsNo.Text)
                    cc.add("instructor", "For pick-up")
                    cc.add("charge_type", "ADFIL")
                    cc.add("date_needed", Date.Parse(dtpDateNeeded.Text).Date())
                    cc.add("user_id", pub_user_id)
                    cc.add("date_log", Date.Parse(Now))
                    cc.add("dr_option", "WITHOUT DR")
                    cc.add("issued_by", txtIssuedBy.Text)

                    Dim ws_id As Integer = cc.insertQueryRollBack_and_return_id("dbPO",
                                                                                newSQLcon,
                                                                                transaction)

                    'Dim ws_id As Integer = cc.insertQuery_and_return_id("dbPO")
#End Region
                    'second: ws details
#Region "WS DETAILS"
                    For Each row As DataGridViewRow In DataGridView1.Rows
                        'Dim supplier = cListOfSupplier.Where(Function(x) x.supplierName.ToUpper() = row.Cells(NameOf(dgvcol_old.supplier)).Value().ToString.ToUpper()).ToList()

                        Dim cc1 As New ColumnValuesObj
                        With cc1

                            .add("po_id", ws_id)
                            .add("wh_id", wsNew.wh_id)
                            .add("po_no", row.Cells(NameOf(dgvcol_old.wsNo)).Value)
                            .add("qty", row.Cells(NameOf(dgvcol_old.qty)).Value)
                            .add("unit", row.Cells(NameOf(dgvcol_old.unit)).Value)
                            .add("unit_price", row.Cells(NameOf(dgvcol_old.unit_price)).Value)
                            .add("amount", row.Cells(NameOf(dgvcol_old.amount)).Value)
                            .add("rs_id", wsNew.rs_id)
                            .add("user_id_logs", pub_user_id)
                            .add("selected", "TRUE")
                            '.add("serial_id", row.Cells(NameOf(dgvcol_old.serial_id)).Value)
                            .add("tire_category", row.Cells(NameOf(dgvcol_old.tireCategory)).Value)

                            'Dim ws_details_id As Integer = cc1.insertQuery_and_return_id("dbPO_details")
                            Dim ws_details_id As Integer = cc1.insertQueryRollBack_and_return_id("dbPO_details",
                                                                newSQLcon,
                                                                transaction)

                            _ws_details_id_for_rs_specific_row_focus = ws_details_id

                            'insert also into dbwithdrawn_items table

#Region "WITHDRAWN ITEMS"
                            Dim cc2 As New ColumnValuesObj
                            Dim _w As New PropsFields.withdrawn_props_fields

                            With cc2
                                .add(NameOf(_w.rs_id), wsNew.rs_id)
                                .add(NameOf(_w.ws_id), ws_details_id)
                                .add(NameOf(_w.date_log_withdrawn), Date.Parse(Now))
                                .add(NameOf(_w.date_withdrawn), Date.Parse(Now))
                                .add(NameOf(_w.status), 1)

                                'Dim withdrawn_id As Integer = cc2.insertQuery_and_return_id("dbwithdrawn_items")
                                Dim withdrawn_id As Integer = cc2.insertQueryRollBack_and_return_id("dbwithdrawn_items",
                                                                newSQLcon,
                                                                transaction)
                            End With
#End Region

                        End With
                    Next
#End Region

                    transaction.Commit()

                    If isCreateWithdrawalFromNewRsForm Then

                        With FRequesitionFormForDR
                            .getNewDrModel().cRsId = _ws_details_id_for_rs_specific_row_focus
                            .getNewDrModel().isCreateWithdrawalForWarehousing = True

                            .txtSearch.Text = txtRsNo.Text
                            .btnSearch.PerformClick()
                        End With
                        Me.Dispose()

                    Else
                        FRequistionForm.loadStat = FRequistionForm.LoadingStatus.partiallyWithdrawn
                        FRequistionForm.loadWhItems()
                        FRequistionForm.btnSearch.PerformClick()
                    End If

                End If
            Else
                customMsg.message("error", "Create a withdrawal first to proceed releasing transaction...", "SUPPLY INFO:")
            End If
        Catch ex As Exception
            If transaction IsNot Nothing Then
                transaction.Rollback()
            End If
            customMsg.ErrorMessage(ex)
        Finally
            newSQLcon.connection.Close()
            Me.Close()
        End Try
    End Sub

    Private Sub updateWithdrawalNow()
        Dim newSQLcon As New SQLcon
        Dim transaction As SqlTransaction = Nothing

        Try

            If cListOfWithrawalItems.Count > 0 Then

                If customMsg.messageYesNo("Are you sure you want to update withdrawal now?", "SUPPLY INFO:") Then

                    newSQLcon.connection.Open()
                    transaction = newSQLcon.connection.BeginTransaction()
#Region "WS DETAILS"
                    For Each row As DataGridViewRow In DataGridView1.Rows
                        'Dim supplier = cListOfSupplier.Where(Function(x) x.supplierName.ToUpper() = row.Cells(NameOf(dgvcol_old.supplier)).Value().ToString.ToUpper()).ToList()

                        Dim cc1 As New ColumnValuesObj
                        With cc1

                            .add("po_no", row.Cells(NameOf(dgvcol_old.wsNo)).Value)
                            .add("qty", row.Cells(NameOf(dgvcol_old.qty)).Value)
                            .add("unit", row.Cells(NameOf(dgvcol_old.unit)).Value)
                            .add("unit_price", row.Cells(NameOf(dgvcol_old.unit_price)).Value)
                            .add("amount", row.Cells(NameOf(dgvcol_old.amount)).Value)
                            .add("user_id_update_logs", pub_user_id)
                            .add("serial_id", row.Cells(NameOf(dgvcol_old.serial_id)).Value)

                            .setCondition($"po_det_id = {updateWithdrawalStorage.ws_id}")

                            Dim ws_details_result As Boolean = cc1.updateQueryRollBack_and_return_true("dbPO_details",
                                                                newSQLcon,
                                                                transaction)

                        End With
                    Next
#End Region

                    transaction.Commit()

                    FWithdrawalList.cWsId = cWsId
                    FWithdrawalList.btnSearch.PerformClick()
                End If
            Else
                customMsg.message("error", "Must have atleast 1 row inside datagrid...", "SUPPLY INFO:")
            End If

        Catch ex As Exception
            If transaction IsNot Nothing Then
                transaction.Rollback()
            End If
            customMsg.ErrorMessage(ex)
        Finally
            newSQLcon.connection.Close()
            Me.Close()
            Me.Dispose()
        End Try
    End Sub



    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        FTireSerial.forCreateWithdrawal = True
        FTireSerial.ShowDialog()
    End Sub

    Private Function getTotalQtyAddedinRows(qty As Double,
                                            Optional isUpdate As Boolean = False,
                                            Optional oldQty As Double = 0) As Double

        If cListOfWithrawalItems.Count > 0 Then
            For Each row In cListOfWithrawalItems
                getTotalQtyAddedinRows += row.qty
            Next
        End If


        If isUpdate Then
            getTotalQtyAddedinRows = (getTotalQtyAddedinRows - oldQty)
            getTotalQtyAddedinRows += qty
        Else
            getTotalQtyAddedinRows += qty
            Return getTotalQtyAddedinRows
        End If
    End Function

    Private Sub cmbOthersCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbOthersCategory.SelectedIndexChanged

        'If cmbOthersCategory.Text = cOthersCategory.NOT_APPLICABLE Then
        '    enableDisableTireSerial(False)

        '    If isEdit Then
        '        txtQty.Enabled = False
        '    Else
        '        txtQty.Enabled = True
        '    End If

        'ElseIf cmbOthersCategory.Text = cOthersCategory.TIRE_STORAGE Then
        '    enableDisableTireSerial(True)
        'End If

    End Sub

    Private Function getTotalQtyAddedinRowsWithSerial(qty As Double,
                                                      serial_id As Integer,
                                                      Optional isUpdate As Boolean = False,
                                                        Optional oldQty As Double = 0) As Double
        If cListOfWithrawalItems.Count > 0 Then
            For Each row In cListOfWithrawalItems
                If row.serial_id = serial_id Then
                    getTotalQtyAddedinRowsWithSerial += row.qty
                End If
            Next
        End If

        If isUpdate And getTotalQtyAddedinRowsWithSerial <> 0 Then
            getTotalQtyAddedinRowsWithSerial = (getTotalQtyAddedinRowsWithSerial - oldQty)
            getTotalQtyAddedinRowsWithSerial += qty
        Else
            getTotalQtyAddedinRowsWithSerial += qty
            Return getTotalQtyAddedinRowsWithSerial
        End If

    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Dispose()
    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        If DataGridView1.SelectedRows.Count > 0 Then
            For Each item As ToolStripMenuItem In ContextMenuStrip1.Items
                item.Enabled = True
            Next
        Else
            For Each item As ToolStripMenuItem In ContextMenuStrip1.Items
                If item.Name = NameOf(CreateWithdrawalToolStripMenuItem) Then
                    item.Enabled = True
                Else
                    item.Enabled = False
                End If
            Next
        End If

        If isEdit Then
            CreateWithdrawalToolStripMenuItem.Enabled = False
        Else
            CreateWithdrawalToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub btnReleaseNow_Click(sender As Object, e As EventArgs) Handles btnReleaseNow.Click
        btnSaveWithdrawal.Text = "Save (Ctrl + S)"

        btnReleaseNow.Focus()
        issuedByUI.resetBgColor()

        openPanelCreateWithdrawal()

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        panelBoxClose()

        wsQtyUI.tbox.ReadOnly = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        c.addItems()
    End Sub

    Private Sub FCreateWithdrawalSlip_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'UI
        rsNoUI.king_placeholder_textbox("RS No...", txtRsNo, Nothing, Panel8, My.Resources.received,, rsNoUI.cCustomColor.Custom1)
        rsNoUI.tbox.ReadOnly = True

        dateIssuedUI.king_placeholder_datepicker("", dtpDateIssued, Panel8, My.Resources.received, dateIssuedUI.cCustomColor.Custom1)
        dateNeededUI.king_placeholder_datepicker("", dtpDateNeeded, Panel8, My.Resources.received, dateNeededUI.cCustomColor.Custom1)

        issuedByUI.king_placeholder_textbox("Issued By...", txtIssuedBy, Nothing, Panel8, My.Resources.received,, issuedByUI.cCustomColor.Custom1)
        chargesUI.king_placeholder_textbox("Charges...", txtCharges, Nothing, Panel8, My.Resources.received,, chargesUI.cCustomColor.Custom1)
        chargesUI.tbox.ReadOnly = True
        whLocationUI.king_placeholder_textbox("WHS Location...", txtWhLocation, Nothing, Panel8, My.Resources.received,, whLocationUI.cCustomColor.Custom1)
        whLocationUI.tbox.ReadOnly = True

        wsNoUI.king_placeholder_textbox("Ws No...", txtWsNo, Nothing, Panel7, My.Resources.received,, wsNoUI.cCustomColor.Custom1)
        wsQtyUI.king_placeholder_textbox("Quantity...", txtQty, Nothing, Panel7, My.Resources.received, True, wsQtyUI.cCustomColor.Custom1)
        unitUI.king_placeholder_textbox("Unit...", txtUnit, Nothing, Panel7, My.Resources.received,, unitUI.cCustomColor.Custom1)
        amountUI.king_placeholder_textbox("Amount...", txtAmount, Nothing, Panel7, My.Resources.received, True, amountUI.cCustomColor.Custom1)

        otherCategoryUI.king_placeholder_combobox("Category...", cmbOthersCategory, Nothing, Panel7, My.Resources.received, otherCategoryUI.cCustomColor.Custom1)
        tireSerialNoUI.king_placeholder_textbox("serial No...", txtSerialNo, Nothing, Panel7, My.Resources.received, False, tireSerialNoUI.cCustomColor.Custom1)

        cmbOthersCategory.Items.Add(cOthersCategory.NOT_APPLICABLE)
        cmbOthersCategory.Items.Add(cOthersCategory.TIRE_STORAGE)





        'supplierUI.king_placeholder_textbox("Supplier...", txtSupplier, Nothing, Panel7, My.Resources.received)
        'termsUI.king_placeholder_textbox("Terms...", txtTerms, Nothing, Panel7, My.Resources.received)

        'init dummy data
        'With wsNew
        '    .ws_qty = 300
        '    .units = "pcs"
        '    .rs_no = "2392324"
        '    .charges = "WHS BAAN"
        '    .whLocation = "Butuan City"
        'End With

        loadSomeData()


        customDgv.customDatagridview(DataGridView1, "#011526")
        lblReleased.ForeColor = ColorTranslator.FromHtml("#BF3952")
        lblRsQty.ForeColor = ColorTranslator.FromHtml("#BF3952")
        lblBalance.ForeColor = ColorTranslator.FromHtml("#BF3952")


        'movable panel
        Dim myPanel As New MovablePanel

        myPanel.addPanel(Panel1)
        myPanel.addPanel(Panel4)

        myPanel.initializeForm(Me)
        myPanel.addPanelEventHandler()
    End Sub

    Private Sub loadSomeData()

        supplierModel.clearParameter()
        employeeModel.clearParameter()

        Dim cv As New ColumnValues

        loadingPanel.Visible = True

        _initializing(cCol.forSupplier,
                      cv.getValues(),
                      supplierModel,
                      createWithdrawalBgWorker)

        _initializing(cCol.forEmployees,
                      cv.getValues(),
                      employeeModel,
                      createWithdrawalBgWorker)

        _initializing(cCol.forTireSerialNo,
                          cv.getValues(),
                          serialNoModel,
                          createWithdrawalBgWorker)

        cBgWorkerChecker = BgWorkersCheckerFn(AddressOf SuccessfullyDone, createWithdrawalBgWorker)
    End Sub
    Private Sub SuccessfullyDone()

        Results.cListOfSupplier = CType(supplierModel.cData, List(Of PropsFields.supplier_props_fields))
        Results.cListOfEmployees = CType(employeeModel.cData, List(Of PropsFields.employee_props_fields))
        Results.rListOfTireSerialNo = TryCast(serialNoModel.cData, List(Of PropsFields.tireSerial_props_fields))

        loadingPanel.Visible = False

        Dim listOfEmployees As New List(Of String)
        For Each row In cListOfEmployees
            listOfEmployees.Add(row.employee)
        Next

        Dim listOfSupplier As New List(Of String)
        For Each row In cListOfSupplier
            listOfSupplier.Add(row.supplierName)
        Next

        issuedByUI.AutoCompleteData = listOfEmployees
        issuedByUI.set_autocomplete()

        supplierUI.AutoCompleteData = listOfSupplier
        supplierUI.set_autocomplete()

        tireSerialNoUI.AutoCompleteData = Results.rListOfTireSerialNo.Select(Function(x) x.serial_no).ToList()
        tireSerialNoUI.set_autocomplete()

        chargesUI.tbox.Text = wsNew.charges
        chargesUI.resetBgColor()

        whLocationUI.tbox.Text = wsNew.whLocation
        whLocationUI.resetBgColor()

        rsNoUI.tbox.Text = wsNew.rs_no
        rsNoUI.resetBgColor()

        If saveStatus = SaveBtn.Update Then
            issuedByUI.tbox.Text = wsNew.issued_by
            issuedByUI.resetBgColor()
        End If


        If isEdit Then
            Dim wsRow As New withdrawalRow
            With updateWithdrawalStorage
                Panel8.Enabled = False

                wsRow.wsNo = .ws_no
                wsRow.qty = .ws_qty
                wsRow.unit = .unit
                wsRow.unit_price = .price
                wsRow.amount = .price * .ws_qty
                wsRow.col_id = 1
                wsRow.serial_id = .serial_id

                cListOfWithrawalItems.Add(wsRow)

                DataGridView1.DataSource = cListOfWithrawalItems
            End With
        End If
    End Sub
    Private Sub setCustomGridview()

        With customDgv

            'readonly cells
            .subcustomDatagridviewSettings("ReadOnlyCells", DataGridView1, 1)
            .subcustomDatagridviewSettings("ReadOnlyCells", DataGridView1, 2)
            .subcustomDatagridviewSettings("ReadOnlyCells", DataGridView1, 3)
            .subcustomDatagridviewSettings("ReadOnlyCells", DataGridView1, 4)

            .subcustomDatagridviewSettings("headerTextOnly", DataGridView1, 0,, dgvCol.WSNO)
            .subcustomDatagridviewSettings("headerTextOnly", DataGridView1, 1,, dgvCol.QTY)
            '.subcustomDatagridviewSettings("headerTextOnly", DataGridView1, 2,, dgvCol.SUPPLIER)
            .subcustomDatagridviewSettings("headerTextOnly", DataGridView1, 2,, dgvCol.UNITS)
            .subcustomDatagridviewSettings("headerTextOnly", DataGridView1, 3,, dgvCol.UNIT_PRICE)
            .subcustomDatagridviewSettings("headerTextOnly", DataGridView1, 4,, dgvCol.AMOUNT)

            'hide columns
            For Each col As DataGridViewColumn In DataGridView1.Columns
                If col.Name = NameOf(wr.col_id) Then
                    col.Visible = False
                Else
                    col.Visible = True
                End If
            Next
        End With

        customDgv.autoSizeColumn(DataGridView1, True)

    End Sub

    Private Sub FCreateWithdrawalSlip_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Me.Dispose()
    End Sub

    Private Sub FCreateWithdrawalSlip_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then

        ElseIf e.Control And e.KeyCode = Keys.R Then
            btnReleaseNow.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.S Then
            If Panel7.Visible = True Then
                btnSaveWithdrawal.PerformClick()
            Else
                btnFinalSave.PerformClick()
            End If

        ElseIf e.Control And e.KeyCode = Keys.X Then
            panelBoxClose()
        End If
    End Sub

    Interface IWithdrawalItems
        Sub initialize(mainPanel As Panel)
        Function Items() As Panel
        Function myTextbox() As TextBox
        Sub addItems()


    End Interface
    Private Class WithdrawalItems
        Implements IWithdrawalItems
        Private cMainPanel As New Panel
        Public flowLayoutPanel As New FlowLayoutPanel

        Public Sub initialize(mainPanel As Panel) Implements IWithdrawalItems.initialize

            cMainPanel = mainPanel

            mainPanel.Controls.Add(Items)
            'mainPanel.Controls.Add(Items)


        End Sub

        Public Function Items() As Panel Implements IWithdrawalItems.Items

            Dim panelNew As New Panel
            panelNew.Width = cMainPanel.Width
            panelNew.Height = 80
            panelNew.BackColor = Color.Gray
            panelNew.Dock = DockStyle.Top

            Dim data1 As New List(Of String)
            data1.Add("king")
            data1.Add("james")

            Dim aa = New MyTextBox()
            aa.AutoCompleteData = data1

            aa.setAutoComplete()

            panelNew.Controls.Add(aa.customPanel)
            Return panelNew

        End Function

        Sub addItems() Implements IWithdrawalItems.addItems

            cMainPanel.Controls.Add(Items)
            'Application.DoEvents()
        End Sub

        Public Function myTextbox() As TextBox Implements IWithdrawalItems.myTextbox

            Dim t As New MyTextBox(300, "hello world")
            'myTextbox = t

            Return t
        End Function

    End Class
    Private Sub enableDisableTireSerial(enableDisable As Boolean)
        Try
            txtSerialNo.Clear()
            txtSerialNo.ReadOnly = enableDisable
            Button4.Enabled = enableDisable

            lblTireRemaining.Text = "remaining: 0"

            If enableDisable Then
                Button4.PerformClick()
            End If

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
    Class MyTextBox
        Inherits TextBox

        Dim panel As New Panel
        Dim ui As New class_placeholder4
        Dim pict As New PictureBox
        Dim placeholder As String = "textboxhere..."
        Private cAutocomplete As New List(Of String)
        Public Property AutoCompleteData As Object
            Get
                Return cAutocomplete ' Retrieve the value of the field
            End Get
            Set(value As Object)
                cAutocomplete = value ' Assign the value to the field
            End Set
        End Property

        Sub New(Optional width As Integer = 210, Optional param_placeholder As String = "", Optional param_data As List(Of String) = Nothing)
            placeholder = param_placeholder
            panel.BackColor = Color.Gray
            panel.Width = width
            panel.Height = 30
            panel.BackColor = Color.White

            pict.Location = New Point(5, 5)
            pict.Image = My.Resources.received
            pict.Width = 40

            cAutocomplete = param_data

            TextboxDesign()

            panel.Controls.Add(Me)
            panel.Controls.Add(pict)
        End Sub

        Public Function customPanel()
            Return panel
        End Function

        Private Sub TextboxDesign()
            Me.Text = "hello"
            Me.BackColor = Color.White
            Me.Location = New Point(pict.Width, 6)
            Me.Width = panel.Width - 50
            Me.BorderStyle = BorderStyle.None
            Me.Font = New Font("Century Gothic", 10, FontStyle.Regular)
            Me.Name = "hello"

        End Sub

        Private Sub leaved() Handles Me.Leave
            If Me.Text = placeholder Or Me.Text = "" Then
                Me.Text = placeholder
                'Me.Font = New Font("Century Gothic", 10, FontStyle.Italic)         
                Me.ForeColor = Color.Gray
            End If

        End Sub

        Private Sub gotFocused() Handles Me.GotFocus
            If Me.Text = placeholder Or Me.Text = "" Then
                Me.Clear()
                Me.ForeColor = Color.Black
                Me.Font = New Font("Century Gothic", 10, FontStyle.Regular)
            End If

        End Sub

        Public Sub setAutoComplete()
            Dim searchlist As New AutoCompleteStringCollection

            Dim cListOfData = cAutocomplete

            For Each row In cListOfData
                searchlist.Add(row)
            Next

            Me.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            Me.AutoCompleteSource = AutoCompleteSource.CustomSource
            Me.AutoCompleteCustomSource = searchlist

        End Sub
    End Class

End Class