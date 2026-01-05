Public Class FCreateReceiving

    Private rsNoUI,
        dateReceivedUI,
        dateSubmittedUI,
        supplierUI,
        invoiceUI,
        poNoUI,
        rrNoUI,
        soNoUI,
        receivedByUI,
        checkedByUI,
        plateNoUI,
        tireOptionUI,
        serialNoUI,
        rrQuantityUI,
        unitUI,
        unitPriceUI,
        operatorUI,
        sourceUI,
        rrItemDescUI As New class_placeholder5
    Public isSerialNoFocus As Boolean


    Private customMsg As New customMessageBox
    Private customDgv As New CustomGridview

    Public cRsId As Integer
    Public cPoDetId As Integer
    Public cRrItemId As Integer

    Public cRsNo As String
    Public poQtyLeft, rsQtyForCashLeft As Double

    Public isEdit, isEditNew As Boolean

    Private CREATERECEIVINGMODEL As New CreateReceivingModel
    Private cOthersCategory As New OTHERSCATEGORY
    Public cTireSerialStore As New PropsFields.tireSerial_props_fields
    Public rrDataForEdit As New PropsFields.Receiving_row
    Public rrDataForEditNew As New ReceivingModel.COLUMNS

    Public NEWRSDRMODEL As New RSDRModel
    Public cn As New PropsFields.Receiving_row
    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Const CS_DROPSHADOW As Integer = &H20000
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ClassStyle = cp.ClassStyle Or CS_DROPSHADOW
            Return cp
        End Get
    End Property
    Public ReadOnly Property GET_CREATERECEIVINGMODEL() As CreateReceivingModel
        Get
            Return CREATERECEIVINGMODEL
        End Get
    End Property
    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        If isEdit Then
            REMOVEFROMTHELISTToolStripMenuItem.Enabled = False
            setReceiving_toolStripItem.Enabled = False
            UPDATERECEIVINGDETAILSToolStripMenuItem.Enabled = True
        Else
            REMOVEFROMTHELISTToolStripMenuItem.Enabled = True
            setReceiving_toolStripItem.Enabled = True
            UPDATERECEIVINGDETAILSToolStripMenuItem.Enabled = False

            enableDisable_tireContextMenu()
        End If
    End Sub


    Private Sub enableDisable_tireContextMenu()
        If cmbTireOption.Text = cOthersCategory.FOR_TIRE_STOCKING Then
            Dim selectedRow = DataGridView1.SelectedRows(0)

            If selectedRow.Cells(NameOf(cn.level)).Value = "parent" Or
                selectedRow.Cells(NameOf(cn.level)).Value = "" Then

                SETTIRESERIALNOToolStripMenuItem.Enabled = True
                REMOVESERIALNOToolStripMenuItem.Enabled = False

            ElseIf selectedRow.Cells(NameOf(cn.level)).Value = "child" Then

                SETTIRESERIALNOToolStripMenuItem.Enabled = False
                REMOVESERIALNOToolStripMenuItem.Enabled = True

            End If
        Else
            SETTIRESERIALNOToolStripMenuItem.Enabled = False
        End If
    End Sub


    Private Sub UPDATERECEIVINGDETAILSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UPDATERECEIVINGDETAILSToolStripMenuItem.Click
        Try
            Dim cn As New PropsFields.Receiving_row
            Dim selectedRow = DataGridView1.SelectedRows(0)

            With selectedRow
                txtRrQty.Text = .Cells(NameOf(cn.rr_qty)).Value
                txtUnits.Text = .Cells(NameOf(cn.unit)).Value
                txtUniPrice.Text = .Cells(NameOf(cn.unit_price)).Value
            End With

            Panel6.Visible = True
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try


    End Sub

    Private Sub cmbTireOption_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTireOption.SelectedIndexChanged
        If cmbTireOption.Text = cOthersCategory.FOR_TIRE_STOCKING Then
            btnSerial.Enabled = True
            btnRemoveTireSerial.Enabled = True
        Else
            btnSerial.Enabled = False
            btnRemoveTireSerial.Enabled = False
        End If
    End Sub

    Private Sub REMOVEFROMTHELISTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles REMOVEFROMTHELISTToolStripMenuItem.Click

        If DataGridView1.Rows.Count <= 1 Then
            customMsg.message("error", "Unable to remove if only one row left!", "SUPPLY INFO:")
            Exit Sub
        End If

        If DataGridView1.SelectedRows.Count = 0 Then
            customMsg.message("error", "Please select a row to remove.", "SUPPLY INFO:")
            Exit Sub
        End If

        ' Get the selected row
        Dim row As DataGridViewRow = DataGridView1.SelectedRows(0)
        Dim typeOfPurchasing As String = row.Cells(NameOf(cn.typeOfPurchasing)).Value

        If typeOfPurchasing = cTypeOfPurchasing.CASH_WITH_RR Then
            remove_row_for_cashWithRR()
        Else
            remove_row_for_poWithRR()
        End If

        lblTotalAmount.Text = FormatNumber(GET_CREATERECEIVINGMODEL().calculateTotalAmount(DataGridView1)).ToString()

    End Sub

    Private Sub SETTIRESERIALNOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SETTIRESERIALNOToolStripMenuItem.Click
        Try
            Dim selectedRow = DataGridView1.SelectedRows(0)
            Dim isAlreadySet As Boolean = CREATERECEIVINGMODEL.isSerialNoAlreadySet(selectedRow.Cells(NameOf(cn.po_det_id)).Value)

            If isAlreadySet Then

                With FAddTireSerialNo
                    .isAlreadySet = True

                    .GET_ADDTIRESERIALNOMODEL().cTIRE.tire_details = selectedRow.Cells(NameOf(cn.item_description)).Value
                    .GET_ADDTIRESERIALNOMODEL().cTIRE.tire_qty = selectedRow.Cells(NameOf(cn.rr_qty)).Value
                    .GET_ADDTIRESERIALNOMODEL().cTIRE.po_det_id = selectedRow.Cells(NameOf(cn.po_det_id)).Value

                    FAddTireSerialNo.isEdit = True
                    FAddTireSerialNo.btnProceed.Text = "Update"
                    FAddTireSerialNo.ShowDialog()

                End With
            Else
                With FAddTireSerialNo.GET_ADDTIRESERIALNOMODEL().cTIRE

                    .tire_details = selectedRow.Cells(NameOf(cn.item_description)).Value
                    .tire_qty = selectedRow.Cells(NameOf(cn.rr_qty)).Value
                    .po_det_id = selectedRow.Cells(NameOf(cn.po_det_id)).Value

                    FAddTireSerialNo.ShowDialog()
                End With
            End If

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        MsgBox(CREATERECEIVINGMODEL.getListOfReceivingSerialNo().Count)
    End Sub

    Private Sub REMOVESERIALNOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles REMOVESERIALNOToolStripMenuItem.Click

        Dim selectedRow = DataGridView1.SelectedRows(0)
        CREATERECEIVINGMODEL.removeSerialNo(selectedRow.Cells(NameOf(cn.po_det_id)).Value,
                                            selectedRow.Cells(NameOf(cn.other_id)).Value)

        FAddTireSerialNo.displayToCreateReceivingDatagridView()

    End Sub

    Private Sub FCreateReceiving_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then

        ElseIf e.Control And e.KeyCode = Keys.R Then
            setReceiving_toolStripItem.PerformClick()

        ElseIf e.Control And e.KeyCode = Keys.S Then
            If Panel6.Visible = True Then
                btnUpdate.PerformClick()
            Else
                btnCreateReceiving.PerformClick()
            End If

        ElseIf e.Control And e.KeyCode = Keys.X Then
            panelBoxClose()
        End If
    End Sub

    Private Sub remove_row_for_cashWithRR()
        Dim row As DataGridViewRow = DataGridView1.SelectedRows(0)
        Dim rsId As Integer = Convert.ToInt32(row.Cells(NameOf(cn.rs_id)).Value)

        ' Remove from the source list
        Dim model = FRequesitionFormForDR.getNewDrModel()
        model.RawRrRows = model.RawRrRows.Where(Function(x) x.rs_id <> rsId).ToList()

        ' Refresh the DataGridView
        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = model.RawRrRows
        model.customizeGridViewForRr(DataGridView1)

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub remove_row_for_poWithRR()
        Dim row As DataGridViewRow = DataGridView1.SelectedRows(0)
        Dim poDetId As Integer = Convert.ToInt32(row.Cells(NameOf(cn.po_det_id)).Value)

        ' Remove from the source list
        Dim model = FRequesitionFormForDR.getNewDrModel()
        model.RawRrRows = model.RawRrRows.Where(Function(x) x.po_det_id <> poDetId).ToList()

        ' Refresh the DataGridView
        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = model.RawRrRows
        model.customizeGridViewForRr(DataGridView1)
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
#Region "FILTER"
            If rrQuantityUI.isBlankTextBox() And isEditNew = False Then
                rrQuantityUI.tbox.Focus()
                ErrorMessage(rrQuantityUI.placeHolder)
                Exit Sub

            ElseIf unitUI.isBlankTextBox() Then
                unitUI.tbox.Focus()
                ErrorMessage(unitUI.placeHolder)
                Exit Sub

            ElseIf unitPriceUI.isBlankTextBox() Then
                unitPriceUI.tbox.Focus()
                ErrorMessage(unitPriceUI.placeHolder)
                Exit Sub

            ElseIf rrItemDescUI.isBlankTextBox() Then
                rrItemDescUI.tbox.Focus()
                ErrorMessage(rrItemDescUI.placeHolder)
                Exit Sub

            End If
#End Region
            Dim NEWDRMODEL = FRequesitionFormForDR.getNewDrModel()
            Dim row = DataGridView1.SelectedRows(0)

            'for update rr item details
            If isEdit Then
                Dim newUpdateRrRow As New PropsFields.Receiving_row
                With newUpdateRrRow
                    .po_det_id = 0
                    .rr_qty = txtRrQty.Text
                    .unit = txtUnits.Text
                    .unit_price = txtUniPrice.Text
                    .amount = CDbl(txtUniPrice.Text) * CDbl(txtRrQty.Text)
                    .rr_item_description = txtRrItemDesc.Text
                    .level = "parent"
                End With

                NEWRSDRMODEL.updateRRrowForEdit(newUpdateRrRow, DataGridView1)
                lblTotalAmount.Text = FormatNumber(GET_CREATERECEIVINGMODEL().calculateTotalAmount(DataGridView1)).ToString()

                Panel6.Visible = False
                Exit Sub

            ElseIf isEditNew Then
                Dim newUpdateRrRow As New PropsFields.Receiving_row
                With newUpdateRrRow
                    .po_det_id = 0
                    .rr_qty = txtRrQty.Text
                    .unit = txtUnits.Text
                    .unit_price = txtUniPrice.Text
                    .amount = CDbl(txtUniPrice.Text) * CDbl(txtRrQty.Text)
                    .rr_item_description = txtRrItemDesc.Text
                    .level = "parent"
                End With

                CREATERECEIVINGMODEL.updateRRrowForEdit(newUpdateRrRow, DataGridView1)
                lblTotalAmount.Text = FormatNumber(GET_CREATERECEIVINGMODEL().calculateTotalAmount(DataGridView1)).ToString()

                Panel6.Visible = False
                Exit Sub
            End If

            Dim updateRrRow As New PropsFields.Receiving_row
            With updateRrRow
                .po_det_id = row.Cells(NameOf(.po_det_id)).Value
                .rs_id = row.Cells(NameOf(.rs_id)).Value
                .rr_qty = txtRrQty.Text
                .unit = txtUnits.Text
                .unit_price = txtUniPrice.Text
                .amount = CDbl(txtUniPrice.Text) * CDbl(txtRrQty.Text)
                .rr_item_description = txtRrItemDesc.Text
                .level = "parent"
            End With

            NEWDRMODEL.updateRRrow(updateRrRow, DataGridView1)
            lblTotalAmount.Text = FormatNumber(GET_CREATERECEIVINGMODEL().calculateTotalAmount(DataGridView1)).ToString()

            Panel6.Visible = False
            DataGridView1.Focus()
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        panelBoxClose()
    End Sub
    Private Sub panelBoxClose()
        Panel6.Visible = False
    End Sub
    Private Sub UPDATEPOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles setReceiving_toolStripItem.Click
        Try

            Dim selectedRow = DataGridView1.SelectedRows(0)
            Panel6.Visible = True
            txtRrItemDesc.Focus()

            If isEditNew Then
                txtRrItemDesc.Text = selectedRow.Cells(NameOf(cn.rr_item_description)).Value

                txtRrQty.Text = selectedRow.Cells(NameOf(cn.rr_qty)).Value
                'txtRrQty.Enabled = False

                txtUnits.Text = selectedRow.Cells(NameOf(cn.unit)).Value
                txtUniPrice.Text = selectedRow.Cells(NameOf(cn.unit_price)).Value

                If Not isAuthenticatedWithoutMessage(auth) And
                    Not Utilities.isNotRestrictedTo(cDepartments.PURCHASING) Then

                    txtUniPrice.Enabled = False
                Else
                    txtUniPrice.Enabled = True
                End If
            Else
                txtRrItemDesc.Text = selectedRow.Cells(NameOf(cn.item_description)).Value
                txtRrQty.Text = selectedRow.Cells(NameOf(cn.rr_qty)).Value
                txtUnits.Text = selectedRow.Cells(NameOf(cn.unit)).Value
                txtUniPrice.Text = selectedRow.Cells(NameOf(cn.unit_price)).Value

            End If

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub


    Private Function tireStockingFilter()
        If isEditNew Then
            Return False
            Exit Function
        End If

        If cTireSerialStore.tire_position_id = 0 And
                   cmbTireOption.Text = cOthersCategory.FOR_TIRE_STOCKING Then

            customMsg.message("error", "You must select a tire position to procceed saving...", "SUPPLY INFO:")
            txtSerialNo.Focus()
            Return True
        End If
    End Function

    Private Sub createReceivingServices()

        If customMsg.messageYesNo("Are you sure you want to create receiving?", "SUPPLY INFO:", MessageBoxIcon.Question) Then
            Dim createrrfordr As New CreateReceivingServices
            Dim _rrfordrStorage As New PropsFields.Create_receiving_for_dr_props_fields
            Dim _rr_detailsStorage As New List(Of PropsFields.Receiving_row)
            Dim _cn As New PropsFields.Receiving_row

            Dim _receivingSerialNo = CREATERECEIVINGMODEL.getListOfReceivingSerialNo
            Dim _serialNos As New List(Of AddTireSerialNoModel.TIRE)

#Region "SETTING UP RR INFO"
            With _rrfordrStorage

#Region "SUPPLIER"
                Dim suppliers = CREATERECEIVINGMODEL.getSuppliers().FirstOrDefault(Function(x)
                                                                                       Return x.supplierName.ToUpper() = txtSupplier.Text.ToUpper()
                                                                                   End Function)

                If suppliers IsNot Nothing Then
                    .supplier_id = suppliers.supplier_id
                End If
#End Region
                .rs_no = txtRsNo.Text
                .date_received = Date.Parse(dtpDateReceived.Text)
                .date_submitted = Date.Parse(dtpDateSubmitted.Text)
                .supplier = txtSupplier.Text
                .invoice_no = txtInvoiceNo.Text
                .rr_no = txtRRNo.Text
                .soNo = txtSoNo.Text
                .received_by = txtReceivedBy.Text
                .checked_by = txtCheckedBy.Text
                .plateNo = txtPlateNo.Text
                .tireOption = cmbTireOption.Text
                .inoutsource = txtSource.Text
                .driver = txtOperator.Text
                .user_id = pub_user_id

            End With
#End Region

#Region "SETTING UP RR DETAILS IN DATAGRIDVIEW"
            For Each row As DataGridViewRow In DataGridView1.Rows
                If row.Cells(NameOf(cn.level)).Value = "parent" Then
                    Dim _rr_detail As New PropsFields.Receiving_row
                    With _rr_detail

                        .po_det_id = row.Cells(NameOf(_cn.po_det_id)).Value
                        .item_description = row.Cells(NameOf(_cn.item_description)).Value
                        .po_no = row.Cells(NameOf(_cn.po_no)).Value
                        .po_qty_balance = row.Cells(NameOf(_cn.po_qty_balance)).Value
                        .rr_qty = row.Cells(NameOf(_cn.rr_qty)).Value
                        .unit = row.Cells(NameOf(_cn.unit)).Value
                        .unit_price = row.Cells(NameOf(_cn.unit_price)).Value
                        .rs_id = row.Cells(NameOf(_cn.rs_id)).Value
                        .rr_item_description = row.Cells(NameOf(_cn.rr_item_description)).Value

                    End With

                    _rr_detailsStorage.Add(_rr_detail)

                    Dim result = _receivingSerialNo.FirstOrDefault(Function(x) x.po_det_id = _rr_detail.po_det_id)
                    _serialNos = result?.receivingWithSerialNo

                End If

            Next
#End Region

            createrrfordr.initializeTireSerial(cTireSerialStore)
            createrrfordr.initializeListOfTireSerialNo(_serialNos)

            Dim rr_details_id As Integer = createrrfordr.ExecuteWithReturnId(_rrfordrStorage,, _rr_detailsStorage)

            If rr_details_id > 0 Then
                customMsg.message("info", "Receiving successfully created...", "SUPPLY INFO:")

                FRequesitionFormForDR.getNewDrModel().isCreateReceiving = True
                FRequesitionFormForDR.getNewDrModel().cRsId = rr_details_id
                FRequesitionFormForDR.btnSearch.PerformClick()
                Me.Dispose()
            Else
                Utilities.SomethingWentWrong("creating receiving order")
            End If
        End If

    End Sub

    Private Sub updateReceivingServices(rr_info_id As Integer, rr_item_id As Integer)

        If customMsg.messageYesNo("Are you sure you want to update receiving?", "SUPPLY INFO:", MessageBoxIcon.Question) Then
            Dim updater As New UpdateReceivingServices
            Dim _rrfordrStorage As New PropsFields.Create_receiving_for_dr_props_fields
            Dim _rr_detailsStorage As New List(Of PropsFields.Receiving_row)
            Dim _cn As New PropsFields.Receiving_row

#Region "SETTING UP RR INFO"
            With _rrfordrStorage

#Region "SUPPLIER"
                Dim suppliers = CREATERECEIVINGMODEL.getSuppliers().FirstOrDefault(Function(x)
                                                                                       Return x.supplierName.ToUpper() = txtSupplier.Text.ToUpper()
                                                                                   End Function)

                If suppliers IsNot Nothing Then
                    .supplier_id = suppliers.supplier_id
                End If
#End Region
                .rs_no = txtRsNo.Text
                .date_received = Date.Parse(dtpDateReceived.Text)
                .date_submitted = Date.Parse(dtpDateSubmitted.Text)
                .supplier = txtSupplier.Text
                .invoice_no = txtInvoiceNo.Text
                .rr_no = txtRRNo.Text
                .soNo = txtSoNo.Text
                .received_by = txtReceivedBy.Text
                .checked_by = txtCheckedBy.Text
                .plateNo = txtPlateNo.Text
                .rr_info_id = rr_info_id
                .rr_item_id = rr_item_id
                .user_id = pub_user_id
                .inoutsource = txtSource.Text
                .driver = txtOperator.Text

            End With
#End Region

#Region "SETTING UP RR DETAILS IN DATAGRIDVIEW"
            For Each row As DataGridViewRow In DataGridView1.Rows
                Dim _rr_detail As New PropsFields.Receiving_row
                With _rr_detail

                    .item_description = row.Cells(NameOf(_cn.item_description)).Value
                    .po_no = row.Cells(NameOf(_cn.po_no)).Value
                    .rr_qty = row.Cells(NameOf(_cn.rr_qty)).Value
                    .unit = row.Cells(NameOf(_cn.unit)).Value
                    .unit_price = row.Cells(NameOf(_cn.unit_price)).Value
                    .rr_item_description = row.Cells(NameOf(_cn.rr_item_description)).Value

                End With

                _rr_detailsStorage.Add(_rr_detail)
            Next
#End Region

            Dim rr_details_result As Boolean = updater.ExecuteWithReturnBoolean(_rrfordrStorage,
                                                                                _rr_detailsStorage)
            If rr_details_result = True Then

                customMsg.message("info", "Receiving successfully updated...", "SUPPLY INFO:")

                FReceivingReportListNew.getNEWRRMODEL().isCreateReceiving = True
                FReceivingReportListNew.getNEWRRMODEL().cRr_item_id = rr_item_id
                FReceivingReportListNew.btnSearch.PerformClick()
                Me.Dispose()

            Else
                Utilities.SomethingWentWrong("creating receiving order")
            End If
        End If

    End Sub
    Private Sub btnCreateReceiving_Click(sender As Object, e As EventArgs) Handles btnCreateReceiving.Click
        'MsgBox(cTireSerialStore.tire_position_id)

        Try
#Region "FILTER"
            With CREATERECEIVINGMODEL
                .add_fields_for_filter_rr_info(supplierUI)
                .add_fields_for_filter_rr_info(invoiceUI)
                .add_fields_for_filter_rr_info(rrNoUI)
                .add_fields_for_filter_rr_info(soNoUI)
                .add_fields_for_filter_rr_info(receivedByUI)
                .add_fields_for_filter_rr_info(checkedByUI)
                .add_fields_for_filter_rr_info(plateNoUI)
                .add_fields_for_filter_rr_info(sourceUI)
                .add_fields_for_filter_rr_info(operatorUI)

                '.add_fields_for_filter_rr_info(tireOptionUI)
                '.add_fields_for_filter_rr_info(serialNoUI)

                If tireStockingFilter() Then
                    Exit Sub
                End If

                Dim filterResult As Boolean = .rr_fields_filter_before_save()

                If filterResult = True Then
                    Exit Sub
                End If

                If .rr_row_detail_filter_before_save(DataGridView1) Then
                    Exit Sub
                End If
            End With
#End Region

#Region "UPDATE"
            If isEditNew Then
                Dim rr_item_id As Integer = rrDataForEditNew.rr_item_id
                Dim rr_info_id As Integer = rrDataForEditNew.rr_info_id

                updateReceivingServices(rr_info_id, rr_item_id)

                Exit Sub
            End If
#End Region

#Region "SAVE"
            createReceivingServices()
#End Region

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles btnRemoveTireSerial.Click
        cTireSerialStore.tire_position_id = 0
        serialNoUI.refresh()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Dispose()
    End Sub

    Private Sub FCreateReceiving_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        customDgv.customDatagridview(DataGridView1)
        initializeUI()

        CREATERECEIVINGMODEL.execute(loadingPanel)

        CREATERECEIVINGMODEL.initialize_employeesData(receivedByUI)
        CREATERECEIVINGMODEL.initialize_employeesData(checkedByUI)
        CREATERECEIVINGMODEL.initialize_driver(operatorUI)

        CREATERECEIVINGMODEL.initialize_suppliers(supplierUI)
        CREATERECEIVINGMODEL.initialize_plateNo(plateNoUI)
        CREATERECEIVINGMODEL.initialize_units(unitUI)

        CREATERECEIVINGMODEL.initializeData()

        'this logic is for edit receiving
        If isEdit Then
            NEWRSDRMODEL.DisplayRrDataToRrDatagridview(DataGridView1, rrDataForEdit)
        End If


        'edit came from receiving form
        If isEditNew Then
            With CREATERECEIVINGMODEL
                .initialize_datagrid(DataGridView1)

                .rrDataForEditNew = rrDataForEditNew

                .add_ui(txtRsNo.Name, rsNoUI)
                .add_ui(dtpDateReceived.Name, dateReceivedUI)
                .add_ui(dtpDateSubmitted.Name, dateSubmittedUI)
                .add_ui(txtSupplier.Name, supplierUI)
                .add_ui(txtReceivedBy.Name, receivedByUI)
                .add_ui(txtCheckedBy.Name, checkedByUI)
                .add_ui(txtSerialNo.Name, serialNoUI)
                .add_ui(txtInvoiceNo.Name, invoiceUI)
                .add_ui(txtRRNo.Name, rrNoUI)
                .add_ui(txtPlateNo.Name, plateNoUI)
                .add_ui(txtSoNo.Name, soNoUI)
                .add_ui(txtSerialNo.Name, serialNoUI)
                .add_ui(cmbTireOption.Name, tireOptionUI)
                .add_ui(txtSource.Name, sourceUI)
                .add_ui(txtOperator.Name, operatorUI)

                .isEdit = True

                btnSerial.Enabled = False
                btnRemoveTireSerial.Enabled = False

            End With
        End If

        'movable panel
        Dim myPanel As New MovablePanel

        myPanel.addPanel(Panel1)
        myPanel.addPanel(Panel4)

        myPanel.initializeForm(Me)
        myPanel.addPanelEventHandler()

        lblTotalAmount.Text = FormatNumber(GET_CREATERECEIVINGMODEL().
                                           calculateTotalAmount(DataGridView1)).ToString()
    End Sub

    Private Sub initializeUI()
        Try

            Dim fontFamily As New Dictionary(Of String, String)
            fontFamily.Add("fontName", cFontsFamily.bombardier)
            fontFamily.Add("fontSize", 12)

            Dim source As New List(Of String)
            source.Add("Insource")
            source.Add("Outsource")


            rsNoUI.king_placeholder_textbox("Rs No...",
                                              txtRsNo,
                                              Nothing,
                                              Panel3,
                                              My.Resources.received,
                                              False,,,,
                                              True,
                                              fontFamily)

            dateReceivedUI.king_placeholder_datepicker("",
                                                       dtpDateReceived,
                                                       Panel3,
                                                       My.Resources.received, ,
                                                       fontFamily)

            dateSubmittedUI.king_placeholder_datepicker("",
                                           dtpDateSubmitted,
                                           Panel3,
                                           My.Resources.received, ,
                                           fontFamily)

            supplierUI.king_placeholder_textbox("Supplier...",
                                  txtSupplier,
                                  Nothing,
                                  Panel3,
                                  My.Resources.received,
                                  False,,,,,
                                  fontFamily)

            invoiceUI.king_placeholder_textbox("Invoice No...",
                      txtInvoiceNo,
                      Nothing,
                      Panel3,
                      My.Resources.received,
                      False,,,,,
                      fontFamily)

            'poNoUI.king_placeholder_textbox("PO No...",
            '          txtPoNo,
            '          Nothing,
            '          Panel3,
            '          My.Resources.received,
            '          False,,,,,
            '          fontFamily)

            rrNoUI.king_placeholder_textbox("RR No...",
                      txtRRNo,
                      Nothing,
                      Panel3,
                      My.Resources.received,
                      False,,,,,
                      fontFamily)

            soNoUI.king_placeholder_textbox("SO No...",
                      txtSoNo,
                      Nothing,
                      Panel3,
                      My.Resources.received,
                      False,,,,,
                      fontFamily)

            receivedByUI.king_placeholder_textbox("Received By...",
                      txtReceivedBy,
                      Nothing,
                      Panel3,
                      My.Resources.received,
                      False,,,,,
                      fontFamily)

            checkedByUI.king_placeholder_textbox("Checked By...",
                      txtCheckedBy,
                      Nothing,
                      Panel3,
                      My.Resources.received,
                      False,,,,,
                      fontFamily)

            plateNoUI.king_placeholder_textbox("Plate No...",
                      txtPlateNo,
                      Nothing,
                      Panel3,
                      My.Resources.received,
                      False,,,,,
                      fontFamily)

            operatorUI.king_placeholder_textbox("Operator/Driver...",
                        txtOperator,
                        Nothing,
                        Panel3,
                        My.Resources.received,
                        False,,,,
                        False,
                        fontFamily)

            sourceUI.king_placeholder_textbox("Insource/Outsource...",
                        txtSource,
                        source,
                        Panel3,
                        My.Resources.received,
                        False,,,,
                        False,
                        fontFamily)

            tireOptionUI.king_placeholder_combobox("Tire Option",
                                                   cmbTireOption,
                                                   Nothing,
                                                   Panel3,
                                                   My.Resources.received,,,,
                                                   fontFamily)

            serialNoUI.king_placeholder_textbox("Serial No...",
                                                txtSerialNo,
                                                Nothing,
                                                Panel3,
                                                My.Resources.received,
                                                False,,,,
                                                True,
                                                fontFamily)


            rrQuantityUI.king_placeholder_textbox("RR Quantity...",
                                                txtRrQty,
                                                Nothing,
                                                Panel6,
                                                My.Resources.received,
                                                True,,,,
                                                False,
                                                fontFamily)

            unitUI.king_placeholder_textbox("Unit...",
                                                txtUnits,
                                                Nothing,
                                                Panel6,
                                                My.Resources.received,
                                                False,,,,
                                                False,
                                                fontFamily)

            unitPriceUI.king_placeholder_textbox("Unit Price...",
                                                txtUniPrice,
                                                Nothing,
                                                Panel6,
                                                My.Resources.received,
                                                True,,,,
                                                False,
                                                fontFamily)

            rrItemDescUI.king_placeholder_textbox("RR Item Description...",
                                                  txtRrItemDesc,
                                                  Nothing,
                                                  Panel6,
                                                  My.Resources.received,
                                                  False,,,,
                                                  False,
                                                  fontFamily)


            'tire options
            cmbTireOption.Items.Add(cOthersCategory.NOT_APPLICABLE)
            cmbTireOption.Items.Add(cOthersCategory.FOR_TIRE_STOCKING)

            'rsNo
            txtRsNo.Text = cRsNo

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

    End Sub

    Private Sub txtSerialNo_GotFocus(sender As Object, e As EventArgs) Handles txtSerialNo.GotFocus
        If cmbTireOption.Text = cOthersCategory.FOR_TIRE_STOCKING Then
            showSerialPanel()
        End If

    End Sub


    Private Sub btnKpi_Click(sender As Object, e As EventArgs) Handles btnSerial.Click
        isSerialNoFocus = True
        FTireSerial.forCreateReceiving = True
        FTireSerial.ShowDialog()
    End Sub

    Private Sub showSerialPanel()
        If Not isSerialNoFocus And cTireSerialStore.serial_no Is Nothing Then
            isSerialNoFocus = True
            FTireSerial.forCreateReceiving = True
            FTireSerial.ShowDialog()
        End If

    End Sub

    Private Sub txtSerialNo_Leave(sender As Object, e As EventArgs) Handles txtSerialNo.Leave
        isSerialNoFocus = False
    End Sub

    Private Sub DataGridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles DataGridView1.KeyDown
        If e.KeyCode = Keys.Left Then
            txtSupplier.Focus()
        End If
    End Sub


End Class