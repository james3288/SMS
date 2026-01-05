Imports System.ComponentModel
Imports SUPPLY.PropsFields

Public Class FCreateWithdrawalSlipForDr
    Private customMsg As New customMessageBox
    Private rsNoUI,
            wsDateUI,
            supplierUI,
            deliveryOptionUI,
            remarksUI,
            releasedByUI,
            withdrawnByUI,
            wsNoUI,
            wsQtyUI,
            unitsUI,
            unitPriceUI As New class_placeholder5

    Public isEdit As Boolean
    Public updateWithdrawalStorage As New Create_withdrawal_slip_for_dr_props_fields

    Private CREATEWSLIPFORDRMODEL As New CreateWithdrawalSlipForDrModel
    Public cRsId As Integer
    Public cRsNo As String
    Public rsQtyLeft As Double

    Private Sub cmbDeliveryOption_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDeliveryOption.SelectedIndexChanged
        If Not isWithDR() Then
            txtUniPrice.Enabled = True
        Else
            unitPriceUI.refresh()
            txtUniPrice.Enabled = False
        End If
    End Sub

    Public cUnit As String

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Const CS_DROPSHADOW As Integer = &H20000
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ClassStyle = cp.ClassStyle Or CS_DROPSHADOW
            Return cp
        End Get
    End Property

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Dispose()
    End Sub

    Private Sub FCreateWithdrawalSlipForDr_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        initializeUI()

        CREATEWSLIPFORDRMODEL.execute(loadingPanel)

        CREATEWSLIPFORDRMODEL.initialize_employeesData(releasedByUI)
        CREATEWSLIPFORDRMODEL.initialize_employeesData(withdrawnByUI)
        CREATEWSLIPFORDRMODEL.initialize_units(unitsUI)
        CREATEWSLIPFORDRMODEL.initialize_suppliers(supplierUI)

        CREATEWSLIPFORDRMODEL.initializeData()


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

            wsDateUI.king_placeholder_datepicker("",
                                                 dtpWsDate,
                                                 Panel2,
                                                 My.Resources.received,,
                                                 fontFamily)

            supplierUI.king_placeholder_textbox("Supplier...",
                                                txtSupplier,
                                                Nothing,
                                                Panel2,
                                                My.Resources.received,
                                                False,,,,,
                                                fontFamily)

            deliveryOptionUI.king_placeholder_combobox("Delivery Option...",
                                                       cmbDeliveryOption,
                                                       Nothing,
                                                       Panel2,
                                                       My.Resources.received,,,,
                                                       fontFamily)

            remarksUI.king_placeholder_multipleLine_textbox("Remarks...",
                                                            txtRemarks,
                                                            Nothing,
                                                            Panel2,
                                                            My.Resources.received,
                                                            False,,,,
                                                            fontFamily)

            releasedByUI.king_placeholder_textbox("Released By...",
                                             txtReleasedBy,
                                             Nothing,
                                             Panel2,
                                             My.Resources.received,
                                             False,,,,,
                                             fontFamily)

            withdrawnByUI.king_placeholder_textbox("Withdrawn By...",
                                          txtWithdrawnBy,
                                          Nothing,
                                          Panel2,
                                          My.Resources.received,
                                          False,,,,,
                                          fontFamily)

            wsNoUI.king_placeholder_textbox("Ws No...",
                                    txtWsNo,
                                    Nothing,
                                    Panel2,
                                    My.Resources.received,
                                    False,,,,,
                                    fontFamily)

            wsQtyUI.king_placeholder_textbox("WS Quantity...",
                                    txtWsQty,
                                    Nothing,
                                    Panel2,
                                    My.Resources.received,
                                    True,,,,,
                                    fontFamily)

            unitsUI.king_placeholder_textbox("Units...",
                                 txtUnits,
                                 Nothing,
                                 Panel2,
                                 My.Resources.received,
                                 False,,,,,
                                 fontFamily)

            unitPriceUI.king_placeholder_textbox("Unit Price...",
                               txtUniPrice,
                               Nothing,
                               Panel2,
                               My.Resources.received,
                               True,,,,,
                               fontFamily)


            'set rsno and rs_id
            txtRsNo.Text = cRsNo
            txtUnits.Text = cUnit
            txtWsQty.Text = rsQtyLeft

            txtRsNo.Focus()

            If isEdit Then
                editWithdrawal()
            End If

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

    End Sub


    Private Sub btnCreateWitthdrawal_Click(sender As Object, e As EventArgs) Handles btnCreateWitthdrawal.Click
        Try

#Region "FILTER"


            If deliveryOptionUI.isBlankComboBox() Then
                deliveryOptionUI.tbox.Focus()
                ErrorMessage(deliveryOptionUI.placeHolder)
                Exit Sub

            ElseIf remarksUI.isBlankTextBox() Then
                remarksUI.tbox.Focus()
                ErrorMessage(remarksUI.placeHolder)
                Exit Sub

            ElseIf releasedByUI.isBlankTextBox() Then
                releasedByUI.tbox.Focus()
                ErrorMessage(releasedByUI.placeHolder)
                Exit Sub

            ElseIf withdrawnByUI.isBlankTextBox() Then
                withdrawnByUI.tbox.Focus()
                ErrorMessage(withdrawnByUI.placeHolder)
                Exit Sub

            ElseIf wsNoUI.isBlankTextBox() Then
                wsNoUI.tbox.Focus()
                ErrorMessage(wsNoUI.placeHolder)
                Exit Sub

            ElseIf wsQtyUI.isBlankTextBox() Then
                wsQtyUI.tbox.Focus()
                ErrorMessage(wsQtyUI.placeHolder)
                Exit Sub

            ElseIf unitsUI.isBlankTextBox() Then
                unitsUI.tbox.Focus()
                ErrorMessage(unitsUI.placeHolder)
                Exit Sub

            ElseIf unitPriceUI.isBlankTextBox() Then
                If Not isWithDR() Then
                    unitPriceUI.tbox.Focus()
                    ErrorMessage(unitPriceUI.placeHolder)
                    Exit Sub
                End If
            End If

            If rsQtyLeft < CDbl(txtWsQty.Text) And isEdit = False Then
                customMsg.message("error", "The withdrawal quantity cannot be greater than the RS quantity left...", "SUPPLY INFO:")
                Exit Sub
            End If
#End Region

            If isEdit Then
                UpdateWithdrawalNow()
            Else
                CreateWithdrawalNow()
            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try


    End Sub
    Private Sub UpdateWithdrawalNow()
        Try
            If customMsg.messageYesNo("Are you sure you want to update withdrawal slip?", "SUPPLY INFO:", MessageBoxIcon.Question) Then
                Dim updatewsfordr As New UpdateWithdrawalForDrServices

                With updateWithdrawalStorage

                    .ws_date = dtpWsDate.Text
                    .rs_no = txtRsNo.Text
                    .withdrawn_by = txtWithdrawnBy.Text
                    .released_by = txtReleasedBy.Text
                    .user_id = pub_user_id
                    .date_log = Date.Parse(Now)
                    .dr_option = cmbDeliveryOption.Text
                    .remarks = txtRemarks.Text
                    .ws_no = txtWsNo.Text
                    .ws_qty = txtWsQty.Text
                    .unit = txtUnits.Text
                    .price = txtUniPrice.Text

                End With
                Dim ws_info_result As Boolean = updatewsfordr.ExecuteWithReturnTrue(updateWithdrawalStorage)

                If ws_info_result Then
                    customMsg.message("info", "Withdrawal Slip successfully updated...", "SUPPLY INFO:")
                    FWithdrawalList.cWsId = updateWithdrawalStorage.ws_id
                    FWithdrawalList.btnSearch.PerformClick()

                    Me.Dispose()
                Else
                    Utilities.SomethingWentWrong("creating withdrawal slip")
                End If
            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub CreateWithdrawalNow()
        Try
            If customMsg.messageYesNo("Are you sure you want to create withdrawal slip?", "SUPPLY INFO:", MessageBoxIcon.Question) Then
                Dim createwsfordr As New CreateWithdrawalForDrServices
                Dim _wsfordrStorage As New PropsFields.Create_withdrawal_slip_for_dr_props_fields

                With _wsfordrStorage
                    .ws_date = dtpWsDate.Text
                    .rs_no = txtRsNo.Text
                    .withdrawn_by = txtWithdrawnBy.Text
                    .released_by = txtReleasedBy.Text
                    .user_id = pub_user_id
                    .date_log = Date.Parse(Now)
                    .dr_option = cmbDeliveryOption.Text
                    .remarks = txtRemarks.Text
                    .ws_no = txtWsNo.Text
                    .ws_qty = txtWsQty.Text
                    .unit = txtUnits.Text
                    .price = Utilities.ifBlankReplaceToZero(txtUniPrice.Text)
                    .rs_id = cRsId

#Region "SUPPLIER"
                    Dim suppliers = CREATEWSLIPFORDRMODEL.getSuppliers().FirstOrDefault(Function(x)
                                                                                            Return x.supplierName.ToUpper() = txtSupplier.Text.ToUpper()
                                                                                        End Function)
                    '.supplier_id = suppliers.supplier_id
#End Region
                End With


                Dim ws_details_id As Integer = createwsfordr.ExecuteWithReturnId(_wsfordrStorage)

                If ws_details_id > 0 Then
                    customMsg.message("info", "Withdrawal Slip successfully created...", "SUPPLY INFO:")
                    withdrawNow(cRsId, ws_details_id)

                    FRequesitionFormForDR.getNewDrModel().isCreateWithdrawal = True
                    FRequesitionFormForDR.getNewDrModel().cRsId = ws_details_id
                    FRequesitionFormForDR.btnSearch.PerformClick()
                    Me.Dispose()

                Else
                    Utilities.SomethingWentWrong("creating withdrawal slip")
                End If
            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub



    Private Sub withdrawNow(rs_id As Integer, ws_id As Integer)
        Try
            If customMsg.messageYesNo("Do you want to withdraw that aggregates also?", "SUPPLY INFO:") Then
                Dim createwsfordr As New CreateWithdrawalForDrServices

                Dim withdrawn_id As Integer = createwsfordr.ExecuteWithdraw(rs_id, ws_id)
                If withdrawn_id = 0 Then
                    Utilities.SomethingWentWrong("withdrawal transaction")
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub editWithdrawal()
        Try
            With updateWithdrawalStorage

                txtRsNo.Text = .rs_no
                dtpWsDate.Text = .ws_date
                txtSupplier.Text = .supplier
                cmbDeliveryOption.Text = .dr_option
                txtRemarks.Text = .remarks
                txtReleasedBy.Text = .released_by
                txtWithdrawnBy.Text = .withdrawn_by
                txtWsNo.Text = .ws_no
                txtWsQty.Text = .ws_qty
                txtUnits.Text = .unit
                txtUniPrice.Text = .price

                txtReleasedBy.Enabled = False
                txtSupplier.Enabled = False
                txtWsQty.Enabled = False

                btnCreateWitthdrawal.Text = "Update Withdrawal"
            End With
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

#Region "UTILITIES"
    Private Function isWithDR() As Boolean
        If cmbDeliveryOption.Text = cDrCategory.WITH_DR Then
            Return True
        ElseIf cmbDeliveryOption.Text = cDrCategory.WITHOUT_DR Then
            Return False
        End If
    End Function
#End Region
End Class