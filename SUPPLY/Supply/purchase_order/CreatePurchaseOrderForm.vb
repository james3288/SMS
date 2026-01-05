Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Runtime.InteropServices
Imports Microsoft.Office.Interop.Excel
Imports SUPPLY.PropsFields
Imports SUPPLY.pubEnum


Public Class CreatePurchaseOrderForm

    Private rsNoUI,
        poDateUI,
        dateNeededUI,
        supplierUI,
        remarksUI,
        instructionUI,
        preparedByUI,
        checkedByUI,
        approvedByUI,
        poNoUI,
        poQtyUI,
        unitsUI,
        unitPriceUI,
        termsUI,
        taxCategoryUI,
        taxValueUI As New class_placeholder5
    Private customMsg As New customMessageBox
    Public cRsId As Integer
    Private CREATEPOFORDRMODEL As New CreatePurchaseOrderForDrModel
    Public isEditAll As Boolean
    Public suplier_address = ""
    Public sup_po_address = ""
    Public unique_rs = ""
    Public unique_charge_all = ""
    Public po_recomendataion1 As String
    Public po_final_recomendation As String
    Public all_podet_id_for_print As String
    Public all_podet_id_printed As String
    Public choices_update_print As String
    Public terms As String

    Private forPrint_allCharges As String
    Public requestor_m As String

    Public supplier_po As String
    Public SQ As New SQLcon
    Public CMD As SqlCommand
    Public DR As SqlDataReader

    Public all_charges As String

    Public cmbdr_option As String = ""
    Public isForPrint_FromPOList As Boolean = False
    Public isForRsNo_FromPOList As String = ""
    Public isForDateNeeded_FromPOList As Date
    Public isForTrans_FromPOList As Date

    Public isFromRequestionFormForDR As Boolean
    Public isEditAllPo, isReprintPo As Boolean

    Public cPoInfoData As New Model._Mod_Purchase_Order.Purchase_Order_Field
    Public cPoDetailsData As New PropsFields.Purchase_Order_Row
    Private customDatagridForPo As New CustomGridview
    Private RawPoRowsEdit As New List(Of PropsFields.Purchase_Order_Row)
    Public cInstructionFromPOList As String
    Public cPrintList As String

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Const CS_DROPSHADOW As Integer = &H20000
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ClassStyle = cp.ClassStyle Or CS_DROPSHADOW
            Return cp
        End Get
    End Property
    Private Sub REMOVEFROMTHELISTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles REMOVEFROMTHELISTToolStripMenuItem.Click
        'CREATEPOFORDRMODEL.remove_item_from_the_list(DataGridView1)

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
        Dim rs_id As Integer = Convert.ToInt32(row.Cells("rs_id").Value)

        ' Remove from the source list
        Dim model = FRequesitionFormForDR.getNewDrModel()
        model.RawPoRows = model.RawPoRows.Where(Function(x) x.rs_id <> rs_id).ToList()

        ' Refresh the DataGridView
        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = model.RawPoRows
        model.customizeGridViewForPo(DataGridView1)



    End Sub

    Private Sub CreatePurchaseOrderForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If customMsg.messageYesNo("Are you sure you want exit?", "SUPPLY INFO:", MessageBoxIcon.Question) Then
                Me.Dispose()
            End If
        ElseIf e.Control And e.KeyCode = Keys.R And Panel6.Visible = True Then
            btnUpdate.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.S Then
            btnCreatePurchaseOrder.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.X And Panel6.Visible = True Then
            Panel6.Visible = False
        ElseIf e.Control And e.KeyCode = Keys.G Then
            showPanel()
        End If
    End Sub

    Private customDatagridview As New CustomGridview
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

#Region "FILTER"
        If poNoUI.isBlankTextBox() Then
            poNoUI.tbox.Focus()
            ErrorMessage(poNoUI.placeHolder)
            Exit Sub

        ElseIf supplierUI.isBlankTextBox() Then
            supplierUI.tbox.Focus()
            ErrorMessage(supplierUI.placeHolder)
            Exit Sub

        ElseIf poQtyUI.isBlankTextBox() Then
            poQtyUI.tbox.Focus()
            ErrorMessage(poQtyUI.placeHolder)
            Exit Sub

        ElseIf unitsUI.isBlankTextBox() Then
            unitsUI.tbox.Focus()
            ErrorMessage(unitsUI.placeHolder)
            Exit Sub

        ElseIf unitPriceUI.isBlankTextBox() Then
            unitPriceUI.tbox.Focus()
            ErrorMessage(unitPriceUI.placeHolder)
            Exit Sub

        ElseIf termsUI.isBlankTextBox() Then
            termsUI.tbox.Focus()
            ErrorMessage(termsUI.placeHolder)
            Exit Sub

        ElseIf taxCategoryUI.isBlankComboBox() Then
            taxCategoryUI.cBox.Focus()
            ErrorMessage(taxCategoryUI.placeHolder)
            Exit Sub

        End If

#End Region

        If CheckBox1.Checked Then
            For Each row As DataGridViewRow In DataGridView1.Rows
                updateRows(row, True)
            Next
        Else
            Dim row = DataGridView1.SelectedRows(0)
            updateRows(row)
        End If

        Panel6.Visible = False
    End Sub

    Private Sub updateRows(row As DataGridViewRow, Optional isChecked As Boolean = False)
        Try
            Dim updatePoRow As New PropsFields.Purchase_Order_Row
            With updatePoRow

                .rs_id = row.Cells("rs_id").Value
                .supplier = txtSupplier.Text
                .poNo = txtPoNo.Text

                .qty = IIf(isChecked = True, row.Cells(NameOf(.qty)).Value, txtPoQty.Text)
                .unit = IIf(isChecked = True, row.Cells(NameOf(.unit)).Value, txtUnits.Text)
                .unit_price = IIf(isChecked = True, row.Cells(NameOf(.unit_price)).Value, txtUniPrice.Text)
                .amount = IIf(isChecked = True, row.Cells(NameOf(.amount)).Value, .qty * .unit_price)

                .terms = txtTerms.Text
                .price_with_tax = IIf(isChecked = True, row.Cells(NameOf(.price_with_tax)).Value, lblTaxValue.Text)
                .tax_category = IIf(isChecked = True, row.Cells(NameOf(.tax_category)).Value, cmbTaxCategory.Text)
                .tax_value = IIf(isChecked = True, row.Cells(NameOf(.tax_value)).Value, txtTaxValue.Text)
                .supplier = txtSupplier.Text

                pubPoNo = txtPoNo.Text
            End With

            If isEditAllPo Then
                Dim _props As New CreatePurchaseOrderForDrModel.POROW_PARAM
                _props.poRow = updatePoRow
                _props.listOfPoRow = RawPoRowsEdit
                _props.datagrid = DataGridView1
                _props.isEditAllPo = isEditAllPo

                CREATEPOFORDRMODEL.updatePOrowForEdit(_props)
            Else
                Dim NEWDRMODEL = FRequesitionFormForDR.getNewDrModel()
                NEWDRMODEL.updatePOrow(updatePoRow, DataGridView1)
            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Public cRsNo As String
    Public rsQtyLeft As Double


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Panel6.Visible = False
    End Sub

    Private Sub UPDATEPOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UPDATEPOToolStripMenuItem.Click
        If isEditAllPo Then
            showPanelForEdit()
            Exit Sub
        End If

        showPanel()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'pubPoNo = txtPoNo.Text + 1
        'preparing_print_po()

        get_supply_addres()


    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Datagridview2.Rows.Clear()
        Panel7.Visible = False
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        'Dim rsFirstLetter As String = txtRsNo.Text.Substring(0, 1)
        'get_po_details()
        'getChargesType()
        'get_supply_addres()
        'If rsFirstLetter = "J" Then
        '    'PO_preview_report_jqg()
        'ElseIf rsFirstLetter = "B" Then
        '    'PO_preview_report_bbc()

        'Else
        '    PO_preview_report_adfil()
        'End If

    End Sub

    Private Sub showPanel()
        Panel6.Visible = True
        txtPoNo.Text = pubPoNo
        'txtPoNo.Text = IIf(pubPoNo = "" Or pubPoNo Is Nothing, 0, pubPoNo + 1)
        Dim cn = cPoDetailsData

        Dim selectedRow = DataGridView1.SelectedRows(0)

        With selectedRow
            txtSupplier.Text = .Cells(NameOf(cn.supplier)).Value
            txtPoNo.Text = .Cells(NameOf(cn.poNo)).Value
            txtPoQty.Text = .Cells(NameOf(cn.qty)).Value
            txtUnits.Text = .Cells(NameOf(cn.unit)).Value
            txtUniPrice.Text = .Cells(NameOf(cn.unit_price)).Value
            txtTerms.Text = .Cells(NameOf(cn.terms)).Value
            cmbTaxCategory.Text = .Cells(NameOf(cn.tax_category)).Value
            txtTaxValue.Text = .Cells(NameOf(cn.tax_value)).Value
        End With

        txtSupplier.Focus()
    End Sub

    Private Sub showPanelForEdit()

        Panel6.Visible = True
        txtSupplier.Text = cPoInfoData.Supplier_Name
        txtPoNo.Text = cPoInfoData.po_no
        txtPoQty.Text = cPoInfoData.qty
        txtPoQty.Enabled = False
        txtUnits.Text = cPoInfoData.unit
        txtUniPrice.Text = cPoInfoData.unit_price
        txtTerms.Text = cPoInfoData.terms

        cmbTaxCategory.Text = cPoInfoData.tax_category
        txtTaxValue.Text = cPoInfoData.vat_value
        lblTaxValue.Text = getTaxAndCalculate(cPoInfoData.tax_category, cPoInfoData.unit_price, cPoInfoData.vat_value)

        txtSupplier.Focus()
    End Sub
    Private Sub cmbTaxCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTaxCategory.SelectedIndexChanged

        If cmbTaxCategory.Text = cTaxCategory.NOT_APPLICABLE Then
            txtTaxValue.Text = 0
            txtTaxValue.ReadOnly = True
        Else
            txtTaxValue.ReadOnly = False
        End If
        txtTaxValue.Focus()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Dispose()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim rsFirstLetter As String = txtRsNo.Text.Substring(0, 1)
        get_po_details()
        getChargesType()
        get_supply_addres()
        get_Allcharges()

        'J is for JQG
        If rsFirstLetter = "J" Then
            'PO_preview_report_jqg()
            rePrintPo("JQG")

            'B is for BBC
        ElseIf rsFirstLetter = "B" Then
            'PO_preview_report_bbc()
            rePrintPo("BBC")
        Else
            'default for ADFIL
            'PO_preview_report_adfil()
            rePrintPo("ADFIL")
        End If
    End Sub

    Private Sub btnCreatePurchaseOrder_Click(sender As Object, e As EventArgs) Handles btnCreatePurchaseOrder.Click
        Try

#Region "FILTER"
            With CREATEPOFORDRMODEL
                .add_fields_for_filter_po_info(rsNoUI)
                .add_fields_for_filter_po_info(remarksUI)
                .add_fields_for_filter_po_info(instructionUI)
                .add_fields_for_filter_po_info(preparedByUI)
                .add_fields_for_filter_po_info(checkedByUI)
                .add_fields_for_filter_po_info(approvedByUI)

                If .po_fields_filter_before_save() Then
                    Exit Sub
                End If

                If .po_row_detail_filter_before_save(DataGridView1) Then
                    Exit Sub
                End If
            End With
#End Region
            If isEditAllPo Then
                udpdateAllPoData()
                Exit Sub
            End If

            If customMsg.messageYesNo("Are you sure you want to create purchase order?", "SUPPLY INFO:", MessageBoxIcon.Question) Then
                Dim createpofordr As New CreatePurchaseOrderServices
                Dim _pofordrStorage As New PropsFields.Create_purchaseOrder_for_dr_props_fields
                Dim _po_detailsStorage As New List(Of PropsFields.Purchase_Order_Row)
                Dim _cn As New PropsFields.Purchase_Order_Row

                With _pofordrStorage

                    .po_date = dtpPoDate.Text
                    .date_needed = dtpDateNeeded.Text
                    .rs_no = txtRsNo.Text
                    .date_log = Date.Parse(Now)
                    .remarks = txtRemarks.Text
                    .instruction = txtInstruction.Text
                    .prepared_by = txtPreparedBy.Text
                    .checked_by = txtCheckedBy.Text
                    .approved_by = txtApprovedBy.Text

                    '.po_no = txtPoNo.Text
                    '.po_qty = txtPoQty.Text
                    '.units = txtUnits.Text
                    '.unit_price = txtUniPrice.Text
                    '.terms = txtTerms.Text
                    '.rs_id = cRsId
                    '.tax_category = cmbTaxCategory.Text
                    '.vat_value = txtTaxValue.Text
                    '.user_id = pub_user_id


#Region "PRICE WITH TAX"
                    Dim priceWithTax As Double = calculateTax(cmbTaxCategory.Text,
                                                                 IIf(unitPriceUI.isBlankTextBox(), 0, unitPriceUI.tbox.Text),
                                                                  IIf(taxValueUI.isBlankTextBox(), 0, taxValueUI.tbox.Text))

                    .unit_price = priceWithTax
#End Region

                End With

#Region "SETTING UP PO DETAILS IN DATAGRIDVIEW"
                For Each row As DataGridViewRow In DataGridView1.Rows
                    Dim _po_detail As New PropsFields.Purchase_Order_Row
                    With _po_detail

#Region "SUPPLIER"
                        Dim suppliers = CREATEPOFORDRMODEL.getSuppliers().FirstOrDefault(Function(x)
                                                                                             Return x.supplierName.ToUpper() = row.Cells(NameOf(_cn.supplier)).Value.ToUpper()
                                                                                         End Function)
                        .supplier_id = suppliers.supplier_id
#End Region
                        .rs_id = row.Cells(NameOf(_cn.rs_id)).Value
                        .poNo = row.Cells(NameOf(_cn.poNo)).Value
                        .unit = row.Cells(NameOf(_cn.unit)).Value
                        .qty = row.Cells(NameOf(_cn.qty)).Value
                        .unit_price = row.Cells(NameOf(_cn.unit_price)).Value
                        .terms = row.Cells(NameOf(_cn.terms)).Value
                        .tax_category = row.Cells(NameOf(_cn.tax_category)).Value
                        .tax_value = row.Cells(NameOf(_cn.tax_value)).Value
                        .user_id = pub_user_id
                        .supplier = row.Cells(NameOf(_cn.supplier)).Value

                    End With

                    _po_detailsStorage.Add(_po_detail)
                Next
#End Region

                Dim po_details_id As Integer = createpofordr.ExecuteWithReturnId(_pofordrStorage,, _po_detailsStorage)
                If po_details_id > 0 Then
                    customMsg.message("info", "Purchased order successfully created...", "SUPPLY INFO:")
                    pubPoNo = txtPoNo.Text + 1

#Region "PRINT PO"
                    Dim printPo As New PrintPurchaseOrderServices
                    If toPrintPurchaseOrder() Then

                        Dim printResult As Boolean = printPo.ExecutePrintedWithReturnTrue(po_details_id)
                        If printResult Then
                            'for mak2x function RDLC here <=====
                            'customMsg.message("warning", "printing coming soon...", "SUPPLY INFO:")
                            preparing_print_po()
                            Exit Sub
                        Else
                            customMsg.message("error", "there is something wrong in printing po!", "SUPPLY EXCEPINFO:")
                        End If
                    Else
                        printPo.ExecuteForPrintingWithReturnTrue(po_details_id)
                    End If
#End Region


                    FRequesitionFormForDR.getNewDrModel().isCreatePurchasedOrder = True
                    FRequesitionFormForDR.getNewDrModel().cRsId = po_details_id
                    FRequesitionFormForDR.btnSearch.PerformClick()
                    Me.Dispose()

                Else
                    Utilities.SomethingWentWrong("creating purchase order")
                End If
            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
    Private Sub udpdateAllPoData()
        Try
            If customMsg.messageYesNo("Are you sure you want to update purchase order?", "SUPPLY INFO:", MessageBoxIcon.Question) Then
                Dim updatePoForDr As New UpdatePurchaseOrderServices
                Dim _pofordrStorage As New PropsFields.Create_purchaseOrder_for_dr_props_fields
                Dim _po_detailsStorage As New List(Of PropsFields.Purchase_Order_Row)
                Dim _cn As New PropsFields.Purchase_Order_Row

                With _pofordrStorage

                    .po_date = dtpPoDate.Text
                    .date_needed = dtpDateNeeded.Text
                    .rs_no = txtRsNo.Text
                    .date_log = Date.Parse(Now)
                    .remarks = txtRemarks.Text
                    .instruction = txtInstruction.Text
                    .prepared_by = txtPreparedBy.Text
                    .checked_by = txtCheckedBy.Text
                    .approved_by = txtApprovedBy.Text
                    .po_id = cPoInfoData.po_id

#Region "PRICE WITH TAX"
                    Dim priceWithTax As Double = calculateTax(cmbTaxCategory.Text,
                                                                 IIf(unitPriceUI.isBlankTextBox(), 0, unitPriceUI.tbox.Text),
                                                                  IIf(taxValueUI.isBlankTextBox(), 0, taxValueUI.tbox.Text))

                    .unit_price = priceWithTax
#End Region

                End With

#Region "SETTING UP PO DETAILS IN DATAGRIDVIEW"
                For Each row As DataGridViewRow In DataGridView1.Rows
                    Dim _po_detail As New PropsFields.Purchase_Order_Row
                    With _po_detail

#Region "SUPPLIER"
                        Dim suppliers = CREATEPOFORDRMODEL.getSuppliers().FirstOrDefault(Function(x)
                                                                                             Return x.supplierName.ToUpper() = row.Cells(NameOf(_cn.supplier)).Value.ToUpper()
                                                                                         End Function)
                        .supplier_id = suppliers.supplier_id
#End Region
                        .rs_id = row.Cells(NameOf(_cn.rs_id)).Value
                        .poNo = row.Cells(NameOf(_cn.poNo)).Value
                        .unit = row.Cells(NameOf(_cn.unit)).Value
                        .qty = row.Cells(NameOf(_cn.qty)).Value
                        .unit_price = row.Cells(NameOf(_cn.unit_price)).Value
                        .terms = row.Cells(NameOf(_cn.terms)).Value
                        .tax_category = row.Cells(NameOf(_cn.tax_category)).Value
                        .tax_value = row.Cells(NameOf(_cn.tax_value)).Value
                        .user_id = pub_user_id
                        .supplier = row.Cells(NameOf(_cn.supplier)).Value
                        .po_det_id = row.Cells(NameOf(_cn.po_det_id)).Value

                    End With

                    _po_detailsStorage.Add(_po_detail)
                Next
#End Region

                Dim poDetailsResult As Boolean = updatePoForDr.ExecuteWithReturnBoolean(_pofordrStorage,, _po_detailsStorage)
                If poDetailsResult Then
                    customMsg.message("info", "Purchased order successfully updated...", "SUPPLY INFO:")

                    FPurchasedOrderList.isEditAllPo = True
                    FPurchasedOrderList.cPoDetId = cPoInfoData.po_det_id
                    FPurchasedOrderList.btnSearch.PerformClick()

                    Me.Dispose()
                Else
                    Utilities.SomethingWentWrong("updating purchase order")
                End If
            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
    Private Function toPrintPurchaseOrder() As Boolean
        Try
            If customMsg.messageYesNo("Do you want to print the PO too?", "SUPPLY INFO:", MessageBoxIcon.Question) Then
                Return True
            End If

            Return False

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Private Sub CreatePurchaseOrderForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        initializeUI()
        customDatagridview.customDatagridview(DataGridView1)

        CREATEPOFORDRMODEL.execute(loadingPanel)

        CREATEPOFORDRMODEL.initialize_employeesData(preparedByUI)
        CREATEPOFORDRMODEL.initialize_employeesData(checkedByUI)
        CREATEPOFORDRMODEL.initialize_employeesData(approvedByUI)

        CREATEPOFORDRMODEL.initialize_units(unitsUI)
        CREATEPOFORDRMODEL.initialize_suppliers(supplierUI)

        CREATEPOFORDRMODEL.initializeData()

        'movable panel
        Dim myPanel As New MovablePanel

        myPanel.addPanel(Panel1)
        myPanel.addPanel(Panel4)

        myPanel.initializeForm(Me)
        myPanel.addPanelEventHandler()

    End Sub

    Private Sub initializeUI()
        Try

            Dim fontFamily As New Dictionary(Of String, String)
            fontFamily.Add("fontName", cFontsFamily.bombardier)
            fontFamily.Add("fontSize", 12)

            rsNoUI.king_placeholder_textbox("Rs No...",
                                              txtRsNo,
                                              Nothing,
                                              Panel2,
                                              My.Resources.received,
                                              True,,,,,
                                              fontFamily)

            poDateUI.king_placeholder_datepicker("",
                                                 dtpPoDate,
                                                 Panel2,
                                                 My.Resources.received,,
                                                 fontFamily)

            dateNeededUI.king_placeholder_datepicker("",
                                                 dtpDateNeeded,
                                                 Panel2,
                                                 My.Resources.received,,
                                                 fontFamily)


            remarksUI.king_placeholder_multipleLine_textbox("Remarks...",
                                                            txtRemarks,
                                                            Nothing,
                                                            Panel2,
                                                            My.Resources.received,
                                                            False,,,,
                                                            fontFamily)


            instructionUI.king_placeholder_multipleLine_textbox("Instruction...",
                                                            txtInstruction,
                                                            Nothing,
                                                            Panel2,
                                                            My.Resources.received,
                                                            False,,,,
                                                            fontFamily)

            preparedByUI.king_placeholder_textbox("Prepared By...",
                                             txtPreparedBy,
                                             Nothing,
                                             Panel2,
                                             My.Resources.received,
                                             False,,,,,
                                             fontFamily)

            checkedByUI.king_placeholder_textbox("Checked By...",
                                          txtCheckedBy,
                                          Nothing,
                                          Panel2,
                                          My.Resources.received,
                                          False,,,,,
                                          fontFamily)

            approvedByUI.king_placeholder_textbox("Approved By...",
                                    txtApprovedBy,
                                    Nothing,
                                    Panel2,
                                    My.Resources.received,
                                    False,,,,,
                                    fontFamily)


            supplierUI.king_placeholder_textbox("Supplier...",
                                                txtSupplier,
                                                Nothing,
                                                Panel6,
                                                My.Resources.received,
                                                False,,,,,
                                                fontFamily)

            poNoUI.king_placeholder_textbox("PO No...",
                                    txtPoNo,
                                    Nothing,
                                    Panel6,
                                    My.Resources.received,
                                    False,,,,,
                                    fontFamily)

            poQtyUI.king_placeholder_textbox("PO Quantity...",
                                 txtPoQty,
                                 Nothing,
                                 Panel6,
                                 My.Resources.received,
                                 True,,,,,
                                 fontFamily)

            unitsUI.king_placeholder_textbox("Units...",
                                 txtUnits,
                                 Nothing,
                                 Panel6,
                                 My.Resources.received,
                                 False,,,,,
                                 fontFamily)

            unitPriceUI.king_placeholder_textbox("Unit Price...",
                               txtUniPrice,
                               Nothing,
                               Panel6,
                               My.Resources.received,
                               True,,,,,
                               fontFamily)

            termsUI.king_placeholder_textbox("Terms...",
                               txtTerms,
                               Nothing,
                               Panel6,
                               My.Resources.received,
                               False,,,,,
                               fontFamily)

            taxCategoryUI.king_placeholder_combobox("Tax Category...",
                                                    cmbTaxCategory,
                                                    Nothing,
                                                    Panel6,
                                                    My.Resources.received,,,,
                                                    fontFamily)

            taxValueUI.king_placeholder_textbox("0",
                               txtTaxValue,
                               Nothing,
                               Panel6,
                               My.Resources.received,
                               True,,,,,
                               fontFamily)

            'set rsno and rs_id
            txtRsNo.Text = cRsNo
            txtRsNo.Focus()

            'vat categories
            cmbTaxCategory.Items.Add(cTaxCategory.NOT_APPLICABLE)
            cmbTaxCategory.Items.Add(cTaxCategory.VAT)
            cmbTaxCategory.Items.Add(cTaxCategory.EWT)

            'instruction
            txtInstruction.Text = "For pick-up"

            'defalut purchasing clerk
            txtCheckedBy.Text = "CUPAY, MERCY FE G. "
            txtApprovedBy.Text = "GORME, JOSEPH Q. "

            'diri ka magbutang
            If isForPrint_FromPOList = True Then
                txtRsNo.Text = isForRsNo_FromPOList
                dtpPoDate.Text = isForTrans_FromPOList
                dtpDateNeeded.Text = isForDateNeeded_FromPOList

            End If

            If isEditAllPo Then
                With cPoInfoData
                    txtRsNo.Text = .rs_no
                    dtpPoDate.Text = .po_date
                    dtpDateNeeded.Text = .date_needed
                    txtRemarks.Text = .remarks
                    txtInstruction.Text = .instructions
                    txtPreparedBy.Text = .prepared_by
                    txtCheckedBy.Text = .checked_by
                    txtApprovedBy.Text = .approved_by

                    Dim _rawPoRows As New PropsFields.Purchase_Order_Row

                    With _rawPoRows
                        .rs_id = cPoInfoData.rs_id
                        .item_description = cPoInfoData.Item_Desc
                        .supplier = cPoInfoData.Supplier_Name
                        .terms = cPoInfoData.terms
                        .poNo = cPoInfoData.po_no
                        .wh_id = cPoInfoData.wh_id
                        .rs_qty_balance = "-"
                        .qty = cPoInfoData.qty
                        .unit = cPoInfoData.unit
                        .unit_price = cPoInfoData.unit_price
                        .amount = cPoInfoData.qty * cPoInfoData.unit_price
                        .charges = cPoInfoData.charges
                        .proper_naming = cPoInfoData.properName
                        .tax_category = cPoInfoData.tax_category
                        .tax_value = Utilities.ifBlankReplaceToZero(cPoInfoData.vat_value)

                        .price_with_tax = getTaxAndCalculate(cPoInfoData.tax_category,
                           cPoInfoData.unit_price,
                            cPoInfoData.vat_value)
                        .po_det_id = cPoInfoData.po_det_id
                    End With

                    RawPoRowsEdit.Add(_rawPoRows)
                    DataGridView1.DataSource = RawPoRowsEdit
                    CREATEPOFORDRMODEL.customizeGridViewForPo(DataGridView1)

                    btnCreatePurchaseOrder.Text = "UPDATE PURCHASE ORDER (CTRL + S)"
                End With
            ElseIf isReprintPo Then
                txtInstruction.Text = cInstructionFromPOList
            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub txtSupplier_TextChanged(sender As Object, e As EventArgs) Handles txtSupplier.TextChanged
        setSUpplierTerms()
    End Sub

    Private Sub txtTaxValue_Leave(sender As Object, e As EventArgs) Handles txtTaxValue.Leave
        Try

            If unitPriceUI.isBlankTextBox() Then
                customMsg.message("error", "unit price must fill before inputting tax value...", "SUPPLY INFO:")
                txtUniPrice.Text = 0
                txtUniPrice.Focus()
                Exit Sub
            Else
                calcTax(cmbTaxCategory.Text,
                             IIf(unitPriceUI.isBlankTextBox(), 0, unitPriceUI.tbox.Text),
                              IIf(taxValueUI.isBlankTextBox(), 0, taxValueUI.tbox.Text))
            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub txtUniPrice_Leave(sender As Object, e As EventArgs) Handles txtUniPrice.Leave
        calcTax(cmbTaxCategory.Text,
                             IIf(unitPriceUI.isBlankTextBox(), 0, unitPriceUI.tbox.Text),
                              IIf(taxValueUI.isBlankTextBox(), 0, taxValueUI.tbox.Text))
    End Sub

    Private Sub calcTax(vat_category As String, unit_price As Double, taxValue As Double)
        Try
            lblTaxValue.Text = FormatNumber(calculateTax(vat_category, unit_price, taxValue)).ToString()

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Public Function getTaxAndCalculate(vat_category As String, unit_price As Double, taxValue As Double) As Double
        Try
            Return FormatNumber(calculateTax(vat_category, unit_price, taxValue)).ToString()

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function




#Region "FOR PRINT PO"
    Private Sub preparing_print_po()
        Dim poRowsModel = FRequesitionFormForDR.getNewDrModel().RawPoRows
        Dim rsFirstLetter As String = txtRsNo.Text.Substring(0, 1)
        'FPurchasedOrderList.all_rs_no = ""
        'FPurchasedOrderList.all_rs_no = txtRsNo.Text
        For Each row In poRowsModel
            Dim cleanProperNaming As String = row.proper_naming

            Dim checkChars As Char() = {
                ChrW(&H2713), ' ✓
                ChrW(&H2714), ' ✔
                ChrW(&H2611), ' ☑
                ChrW(&H2612), ' ☒
                ChrW(&H2610)  ' ☐ 
            }

            For Each ch As Char In checkChars
                cleanProperNaming = cleanProperNaming.Replace(ch.ToString(), "")
            Next

            cleanProperNaming = cleanProperNaming.Trim()

            Datagridview2.Rows.Add(True,
                           row.supplier,
                           row.wh_id,
                           row.item_description,
                           row.item_description,
                           row.poNo,
                           row.terms,
                           row.qty,
                           row.unit,
                           row.unit_price,
                           row.amount,
                           "",
                           row.rs_id,
                           "",
                           "",
                           "Purchased Order",
                           row.charges,
                           cleanProperNaming)
        Next
        Panel7.Visible = True
        get_Allcharges()
    End Sub

    Public Sub PO_preview_report_adfil()

        'col - 17: item description  change to proper name

        unique_charge_all = ""
        Dim Po_data As New System.Data.DataTable()
        Dim values_charge_all_part2 As List(Of String) = New List(Of String)
        Dim i As Integer = 0

        With Po_data
            .Columns.Add("Description")
            .Columns.Add("Qty")
            .Columns.Add("Unit")
            .Columns.Add("UnitPrice")
            .Columns.Add("Amount")
        End With

        For Each row2 As DataGridViewRow In Datagridview2.Rows
            Dim propername As String

            If Not isForPrint_FromPOList Then
                propername = getProperName(row2.Cells("col_rs_id").Value)
            Else
                propername = getProperNameFromPoList(row2.Cells("col_po_det_id").Value)
            End If

            If row2.Cells(0).Value = True Then
                i = 1
                If row2.Cells(9).Value = "0.00" Then
                    'row2.Cells(9).Value = "-"
                    Dim zeros As String = "0"
                    Dim stringToInteger As Integer = Convert.ToInt32(zeros)
                    row2.Cells(9).Value = stringToInteger

                End If

                If row2.Cells(10).Value = "0.00" Then
                    'row2.Cells(10).Value = "-"
                    Dim zeros As String = "0"
                    Dim stringToInteger As Integer = Convert.ToInt32(zeros)
                    row2.Cells(10).Value = stringToInteger
                End If

                Po_data.Rows.Add(propername, 'propername
                                row2.Cells(7).Value, 'qty
                                row2.Cells(8).Value, 'unit
                                row2.Cells(9).Value, 'unit price
                                row2.Cells(10).Value) 'amount

                supplier_po = row2.Cells(1).Value
                terms = row2.Cells(6).Value
                'charge_tos = row2.Cells(16).Value
                values_charge_all_part2.Add(row2.Cells(16).Value)

            End If

        Next

        'pag kuha sa all charge gikan grid
        Dim result2 As List(Of String) = values_charge_all_part2.Distinct().ToList

        For Each element2 As String In result2
            unique_charge_all = unique_charge_all + " / " + element2.ToString
        Next

        FPurchasedOrderList.all_charge_to = ""
        Dim iii = unique_charge_all.IndexOf("/")
        FPurchasedOrderList.all_charge_to = unique_charge_all.Substring(iii + 1)

        If i = 1 Then
            Dim view_po_print As New DataView(Po_data)
            PO_report_view.ReportViewer1.LocalReport.DataSources.Item(0).Value = view_po_print
            PO_report_view.ShowDialog()
            PO_report_view.Dispose()
            Me.Dispose()
            suplier_address = ""

            'for refreshing data from FRequesitionFormForDR
            If isFromRequestionFormForDR Then
                FRequesitionFormForDR.btnSearch.PerformClick()
            End If
        ElseIf i = 0 Then
            MsgBox("You don't have selected data")
        End If

    End Sub

    Public Sub rePrintPo(reprintBy As String)

        'col - 17: item description  change to proper name

        unique_charge_all = ""
        Dim Po_data As New System.Data.DataTable()
        Dim values_charge_all_part2 As List(Of String) = New List(Of String)
        Dim i As Integer = 0

        With Po_data
            .Columns.Add("Description")
            .Columns.Add("Qty")
            .Columns.Add("Unit")
            .Columns.Add("UnitPrice")
            .Columns.Add("Amount")
        End With

        For Each row2 As DataGridViewRow In Datagridview2.Rows
            Dim propername As String

            If Not isForPrint_FromPOList Then
                propername = getProperName(row2.Cells("col_rs_id").Value)
            Else
                propername = getProperNameFromPoList(row2.Cells("col_po_det_id").Value)
            End If

            If row2.Cells(0).Value = True Then
                i = 1
                If row2.Cells(9).Value = "0.00" Then
                    'row2.Cells(9).Value = "-"
                    Dim zeros As String = "0"
                    Dim stringToInteger As Integer = Convert.ToInt32(zeros)
                    row2.Cells(9).Value = stringToInteger

                End If

                If row2.Cells(10).Value = "0.00" Then
                    'row2.Cells(10).Value = "-"
                    Dim zeros As String = "0"
                    Dim stringToInteger As Integer = Convert.ToInt32(zeros)
                    row2.Cells(10).Value = stringToInteger
                End If

                Po_data.Rows.Add(propername, 'propername
                                row2.Cells(7).Value, 'qty
                                row2.Cells(8).Value, 'unit
                                row2.Cells(9).Value, 'unit price
                                row2.Cells(10).Value) 'amount

                supplier_po = row2.Cells(1).Value
                terms = row2.Cells(6).Value
                'charge_tos = row2.Cells(16).Value
                values_charge_all_part2.Add(row2.Cells(16).Value)

            End If

        Next

        'pag kuha sa all charge gikan grid
        Dim result2 As List(Of String) = values_charge_all_part2.Distinct().ToList

        For Each element2 As String In result2
            unique_charge_all = unique_charge_all + " / " + element2.ToString
        Next

        FPurchasedOrderList.all_charge_to = ""
        Dim iii = unique_charge_all.IndexOf("/")
        FPurchasedOrderList.all_charge_to = unique_charge_all.Substring(iii + 1)

        If i = 1 Then
            Dim view_po_print As New DataView(Po_data)
            If reprintBy = "ADFIL" Then
                PO_report_view.ReportViewer1.LocalReport.DataSources.Item(0).Value = view_po_print
                PO_report_view.ShowDialog()
                PO_report_view.Dispose()

            ElseIf reprintBy = "BBC" Then
                PO_report_view_bbc.ReportViewer1.LocalReport.DataSources.Item(0).Value = view_po_print
                PO_report_view_bbc.ShowDialog()
                PO_report_view_bbc.Dispose()

            ElseIf reprintBy = "JQG" Then
                PO_report_view_jqg.ReportViewer1.LocalReport.DataSources.Item(0).Value = view_po_print
                PO_report_view_jqg.ShowDialog()
                PO_report_view_jqg.Dispose()

            End If

            Me.Dispose()
            suplier_address = ""

            'for refreshing data from FRequesitionFormForDR
            If isFromRequestionFormForDR Then
                FRequesitionFormForDR.btnSearch.PerformClick()
            End If
        ElseIf i = 0 Then
            MsgBox("You don't have selected data")
        End If

    End Sub

    Private Function getProperName(rsId As Integer) As String
        Try
            Dim rsModel = FRequesitionFormForDR.getNewDrModel()
            Dim refactoredListOfRs = rsModel.getRefactoredRs()

            Dim rsRow = refactoredListOfRs.FirstOrDefault(Function(x) x.rs_id = rsId)
            Dim propername = rsModel.getProperNameByWhPnId(rsRow)

            If propername IsNot Nothing Then
                getProperName = $"{propername.item_name} - {propername.item_desc}"
            End If

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Private Function getProperNameFromPoList(poDetId As Integer) As String

        Try
            Dim poData = FPurchasedOrderList.getListOfPo().FirstOrDefault(Function(x) x.po_det_id = poDetId)

            If poData IsNot Nothing Then
                Dim propername = Results.cListOfProperNaming?.FirstOrDefault(Function(x) x.wh_pn_id = poData.wh_pn_id)

                If propername IsNot Nothing Then
                    getProperNameFromPoList = $"{propername.item_name} - {propername.item_desc}"
                End If
            End If

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Public Sub PO_preview_report_bbc()
        unique_charge_all = ""
        Dim Po_data As New System.Data.DataTable()
        Dim values_charge_all_part2 As List(Of String) = New List(Of String)
        Dim i As Integer = 0
        With Po_data
            .Columns.Add("Description")
            .Columns.Add("Qty")
            .Columns.Add("Unit")
            .Columns.Add("UnitPrice")
            .Columns.Add("Amount")

        End With
        For Each row2 As DataGridViewRow In Datagridview2.Rows
            If row2.Cells(0).Value = True Then
                i = 1
                If row2.Cells(9).Value = "0.00" Then
                    'row2.Cells(9).Value = "-"
                    Dim zeros As String = "0"
                    Dim stringToInteger As Integer = Convert.ToInt32(zeros)
                    row2.Cells(9).Value = stringToInteger

                End If
                If row2.Cells(10).Value = "0.00" Then
                    'row2.Cells(10).Value = "-"
                    Dim zeros As String = "0"
                    Dim stringToInteger As Integer = Convert.ToInt32(zeros)
                    row2.Cells(10).Value = stringToInteger
                End If
                Po_data.Rows.Add(row2.Cells(17).Value, row2.Cells(7).Value,
                       row2.Cells(8).Value, row2.Cells(9).Value, row2.Cells(10).Value)
                supplier_po = row2.Cells(1).Value
                terms = row2.Cells(6).Value
                'charge_tos = row2.Cells(16).Value
                values_charge_all_part2.Add(row2.Cells(16).Value)

            End If

        Next
        'pag kuha sa all charge gikan grid
        Dim result2 As List(Of String) = values_charge_all_part2.Distinct().ToList
        For Each element2 As String In result2
            unique_charge_all = unique_charge_all + " / " + element2.ToString
        Next

        FPurchasedOrderList.all_charge_to = ""
        Dim iii = unique_charge_all.IndexOf("/")
        FPurchasedOrderList.all_charge_to = unique_charge_all.Substring(iii + 1)


        If i = 1 Then
            Dim view_po_print As New DataView(Po_data)
            PO_report_view_bbc.ReportViewer1.LocalReport.DataSources.Item(0).Value = view_po_print
            PO_report_view_bbc.ShowDialog()
            PO_report_view_bbc.Dispose()
            suplier_address = ""
            Me.Dispose()
        ElseIf i = 0 Then
            MsgBox("You don't have selected data")
        End If

    End Sub


    Public Sub PO_preview_report_jqg()
        unique_charge_all = ""
        Dim Po_data As New System.Data.DataTable()
        Dim values_charge_all_part2 As List(Of String) = New List(Of String)
        Dim i As Integer = 0
        With Po_data
            .Columns.Add("Description")
            .Columns.Add("Qty")
            .Columns.Add("Unit")
            .Columns.Add("UnitPrice")
            .Columns.Add("Amount")

        End With
        For Each row2 As DataGridViewRow In Datagridview2.Rows
            If row2.Cells(0).Value = True Then
                i = 1
                If row2.Cells(9).Value = "0.00" Then
                    'row2.Cells(9).Value = "-"
                    Dim zeros As String = "0"
                    Dim stringToInteger As Integer = Convert.ToInt32(zeros)
                    row2.Cells(9).Value = stringToInteger

                End If
                If row2.Cells(10).Value = "0.00" Then
                    'row2.Cells(10).Value = "-"
                    Dim zeros As String = "0"
                    Dim stringToInteger As Integer = Convert.ToInt32(zeros)
                    row2.Cells(10).Value = stringToInteger
                End If
                Po_data.Rows.Add(row2.Cells(17).Value, row2.Cells(7).Value,
                       row2.Cells(8).Value, row2.Cells(9).Value, row2.Cells(10).Value)
                supplier_po = row2.Cells(1).Value
                terms = row2.Cells(6).Value
                'charge_tos = row2.Cells(16).Value
                values_charge_all_part2.Add(row2.Cells(16).Value)

            End If

        Next
        'pag kuha sa all charge gikan grid
        Dim result2 As List(Of String) = values_charge_all_part2.Distinct().ToList
        For Each element2 As String In result2
            unique_charge_all = unique_charge_all + " / " + element2.ToString
        Next

        FPurchasedOrderList.all_charge_to = ""
        Dim iii = unique_charge_all.IndexOf("/")
        FPurchasedOrderList.all_charge_to = unique_charge_all.Substring(iii + 1)


        If i = 1 Then
            Dim view_po_print As New DataView(Po_data)
            PO_report_view_jqg.ReportViewer1.LocalReport.DataSources.Item(0).Value = view_po_print
            PO_report_view_jqg.ShowDialog()
            PO_report_view_jqg.Dispose()
            suplier_address = ""
            Me.Dispose()
        ElseIf i = 0 Then
            MsgBox("You don't have selected data")
        End If

    End Sub

    Public Sub get_supply_addres()
        suplier_address = ""
        Dim newSQ As New SQLcon
        Dim newdr As SqlDataReader
        Dim newcmd As SqlCommand
        Try
            newSQ.connection.Open()
            If cPrintList = "FromPOList" Then
                publicquery = "SELECT TOP 1 b.Supplier_Location FROM dbPO_details a INNER JOIN dbSupplier b ON a.supplier_id = b.Supplier_Id WHERE a.po_no = '" & sup_po_address & "' AND b.Supplier_Location NOT IN ('N/A', 'n/a')"
                cPrintList = ""
            Else
                'MsgBox(txtSupplier.Text)
                publicquery = "SELECT Supplier_Location FROM dbSupplier WHERE Supplier_Name LIKE '%" & txtSupplier.Text & "%'"
                cPrintList = ""
            End If

            newcmd = New SqlCommand(publicquery, newSQ.connection)
            newdr = newcmd.ExecuteReader

            While newdr.Read
                suplier_address = newdr.Item("Supplier_Location").ToString()
            End While
            newdr.Close()
            newSQ.connection.Close()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub get_po_details()
        Dim newSQ As New SQLcon
        Dim newdr As SqlDataReader
        Dim newcmd As SqlCommand
        Try
            newSQ.connection.Open()
            publicquery = "SELECT * FROM dbrequisition_slip WHERE rs_no = '" & txtRsNo.Text & "'"
            newcmd = New SqlCommand(publicquery, newSQ.connection)
            newdr = newcmd.ExecuteReader
            While newdr.Read
                requestor_m = newdr.Item("requested_by").ToString
            End While
            newdr.Close()
            newSQ.connection.Close()
        Catch ex As Exception

        End Try

        'getdata_printing()
        'getdata_printed()
        'update_if_for_print()
        'update_if_already_Printed()

    End Sub
#End Region



    Public Sub getdata_printing()
        Dim single_id_det As String
        Dim all_single_det As String
        Dim print_stat As String = "FOR PRINTING"
        Dim id_printing As String

        For Each drv As DataGridViewRow In Datagridview2.Rows
            If drv.Cells(0).Value = True Then
                single_id_det = single_id_det + "," + drv.Cells(11).Value
            End If
        Next
        all_single_det = single_id_det.Remove(0, 1)

        Dim newSQ As New SQLcon
        Dim newdr As SqlDataReader
        Dim newcmd As SqlCommand
        Try
            newSQ.connection.Open()
            publicquery = "SELECT po_det_id FROM dbPO_details WHERE po_det_id IN (" + all_single_det + ") and print_status = '" & print_stat & "'"
            newcmd = New SqlCommand(publicquery, newSQ.connection)
            newdr = newcmd.ExecuteReader
            While newdr.Read
                id_printing = id_printing + "," + newdr.Item("po_det_id").ToString
            End While
            all_podet_id_for_print = id_printing.Remove(0, 1)
            '' MsgBox(all_podet_id_for_print)
            newdr.Close()
            newSQ.connection.Close()
        Catch ex As Exception

        End Try
    End Sub


    Private Sub getAllCharges()
        forPrint_allCharges = ""
        Dim uniqueValues As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)

        For Each row As DataGridViewRow In Datagridview2.Rows
            If Not row.IsNewRow Then
                Dim cellValue As String = If(row.Cells(16).Value, "").ToString().Trim()

                If cellValue <> "" Then
                    For Each part As String In cellValue.Split(","c)
                        uniqueValues.Add(part.Trim())
                    Next
                End If
            End If
        Next
        forPrint_allCharges = String.Join(",", uniqueValues.ToArray())

    End Sub



    Public Sub getChargesType()
        Dim sql As New SQLcon
        Dim cmd As New SqlCommand
        Dim rsIdValue As Integer
        Dim finalrsid As Integer
        For Each row As DataGridViewRow In Datagridview2.Rows
            If row.Cells(0).Value = True Then
                rsIdValue = row.Cells("col_rs_id").Value.ToString()
            End If
        Next
        finalrsid = rsIdValue
        sql.connection.Open()
        Try
            cmd.Connection = sql.connection
            cmd.CommandText = "SELECT distinct type_name  FROM dbMultipleCharges 
                               WHERE rs_id = '" & finalrsid & "'"
            Using reader As SqlDataReader = cmd.ExecuteReader()
                If reader.HasRows Then
                    While reader.Read()
                        Dim result As String = reader.GetString(0)
                        lblRsID.Text = result
                    End While
                Else
                    MsgBox("No data found.")
                End If
            End Using

        Catch ex As Exception
            MsgBox(ex.Message)

        Finally
            sql.connection.Close()
        End Try
    End Sub

    Private Sub get_Allcharges()
        all_charges = ""
        Dim uniqueValues As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
        For Each row As DataGridViewRow In Datagridview2.Rows
            If Not row.IsNewRow Then
                Dim cellValue As String = If(row.Cells(16).Value, "").ToString().Trim()
                If cellValue <> "" Then
                    For Each part As String In cellValue.Split(","c)
                        uniqueValues.Add(part.Trim())
                    Next
                End If
            End If
        Next
        all_charges = String.Join(",", uniqueValues.ToArray())
    End Sub

    Private Sub txtSupplier_Leave(sender As Object, e As EventArgs) Handles txtSupplier.Leave
        setSUpplierTerms()
    End Sub

    Private Sub setSUpplierTerms()
        Try
            Dim supplier = CREATEPOFORDRMODEL.
                                getSuppliers().
                                FirstOrDefault(Function(x)
                                                   Return x.supplierName.ToUpper() = txtSupplier.Text.ToUpper()
                                               End Function)

            If supplier IsNot Nothing Then
                txtTerms.Text = supplier.terms
            End If

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
End Class