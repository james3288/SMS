Imports System.Net.Configuration
Imports System.Windows.Controls

Public Class FCreateRSForm

    Private typeOfRequestUI,
        typeOfRequestSubUI,
        consolidationUI,
        properNameUI,
        itemDescFromRsUI,
        rsNoUI,
        typeOfChargesUI,
        locationUI,
        dateRequestUI,
        dateNeededUI,
        joNoUI,
        rsQuantityUI,
        unitsUI,
        purposeUI,
        remarksForEMDUI,
        requestedByUI,
        notedByUI As New class_placeholder5

    Public createRsStorage, updateRsStorage As New PropsFields.Create_Requesition_Slip
    Public copyRsChargesStorage As New List(Of PropsFields.AllCharges)

    Private customMsg As New customMessageBox
    Private CREATERSMODEL As New CreateRsModel

    Public cSelectedChargesStorage As New List(Of PropsFields.AllCharges)
    Public cRsNoStorageForCreatingCharges As String
    Public cRSRemainingQuantity As Double

    Public isCopy, isEditAll As Boolean
    Public ccopyRsData As New PropsFields.rs_for_dr_props_fields

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

    Private Sub btnAutoFill_Click(sender As Object, e As EventArgs) Handles btnAutoFill.Click
        Try
            Dim rsNo As String = Utilities.getRandomFiveDigitNumber()

            dtpRsDate.Text = Date.Parse(Now)
            dtpDateNeeded.Text = Date.Parse(Now).AddDays(5)

            cmbTypeOfRequest.Text = "Construction Materials"
            cmbTypeOfRequestSub.Text = "Others"
            cmbTypeOfCharges.Text = "ADFIL"

            txtRsNo.Text = $"rs-{rsNo}"
            txtLocation.Text = "Butuan City"
            txtJoNo.Text = "N/A"
            txtQty.Text = 2
            txtUnits.Text = "pcs"
            txtRequestedBy.Text = "UAYAN, KING JAMES P."
            txtNotedBy.Text = "UAYAN, KING JAMES P."
            txtPurpose.Text = $"for testing purpose {rsNo}"
            txtRemarksFromEMD.Text = "N/A"
            txtItemDescription.Text = $"for testing {rsNo}"

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Dim tors_ca_id As Integer = CREATERSMODEL.get_tors_ca_id(cmbTypeOfRequest.Text,
                                                             cmbTypeOfRequestSub.Text,
                                                             cmbConsolidationAccount.Text)

            Dim tor_sub_id As Integer = CREATERSMODEL.get_tor_sub_id(cmbTypeOfRequest.Text,
                                                             cmbTypeOfRequestSub.Text)

            Dim accountTitleDatas = CREATERSMODEL.getConsolidationAccountByTorSubId(tor_sub_id)
#Region "FILTER"
            If typeOfRequestUI.isBlankComboBox() Then
                typeOfRequestUI.cBox.Focus()
                CREATERSMODEL.ErrorMessage(typeOfRequestUI.placeHolder)
                Exit Sub

            ElseIf typeOfRequestSubUI.isBlankComboBox() Then
                typeOfRequestSubUI.cBox.Focus()
                CREATERSMODEL.ErrorMessage(typeOfRequestSubUI.placeHolder)
                Exit Sub

                'ElseIf consolidationUI.isBlankComboBox() Then
                '    consolidationUI.cBox.Focus()
                '    CREATERSMODEL.ErrorMessage(consolidationUI.placeHolder)
                '    Exit Sub

            ElseIf typeOfChargesUI.isBlankComboBox() Then
                typeOfChargesUI.cBox.Focus()
                CREATERSMODEL.ErrorMessage(typeOfChargesUI.placeHolder)
                Exit Sub

            ElseIf rsNoUI.isBlankTextBox() Then
                rsNoUI.tbox.Focus()
                CREATERSMODEL.ErrorMessage(rsNoUI.placeHolder)
                Exit Sub

            ElseIf locationUI.isBlankTextBox() Then
                locationUI.tbox.Focus()
                CREATERSMODEL.ErrorMessage(locationUI.placeHolder)
                Exit Sub

                'ElseIf rsQuantityUI.isBlankTextBox() Or txtQty.Text = 0 Then

                '    rsQuantityUI.tbox.Focus()
                '    CREATERSMODEL.ErrorMessage(rsQuantityUI.placeHolder)
                '    Exit Sub

            ElseIf unitsUI.isBlankTextBox() Then
                unitsUI.tbox.Focus()
                CREATERSMODEL.ErrorMessage(unitsUI.placeHolder)
                Exit Sub

            ElseIf requestedByUI.isBlankTextBox() Then
                requestedByUI.tbox.Focus()
                CREATERSMODEL.ErrorMessage(requestedByUI.placeHolder)
                Exit Sub

            ElseIf purposeUI.isBlankTextBox() Then
                purposeUI.tbox.Focus()
                CREATERSMODEL.ErrorMessage(purposeUI.placeHolder)
                Exit Sub

            ElseIf remarksForEMDUI.isBlankTextBox() Then
                remarksForEMDUI.tbox.Focus()
                CREATERSMODEL.ErrorMessage(remarksForEMDUI.placeHolder)
                Exit Sub

            ElseIf itemDescFromRsUI.isBlankTextBox() Then
                itemDescFromRsUI.tbox.Focus()
                CREATERSMODEL.ErrorMessage(itemDescFromRsUI.placeHolder)
                Exit Sub

            ElseIf properNameUI.isBlankTextBox() Or createRsStorage.wh_pn_id_for_rs <= 0 Then
                If Not isEditAll Then
                    CREATERSMODEL.ErrorMessage(properNameUI.placeHolder)
                    properNameUI.tbox.Focus()
                    Exit Sub
                End If
            End If

            If tor_sub_id <> 0 And tors_ca_id = 0 And accountTitleDatas.Count > 0 Then
                'If Not customMsg.messageYesNo("the account title has not been selected, still want to continue?", "SUPPLY INFO:", MessageBoxIcon.Stop) Then
                '    Exit Sub
                'End If
                customMsg.message("error", "the account title (sub) has not been selected!", "SUPPLY INFO:")
                Exit Sub

            ElseIf tor_sub_id = 0 And tors_ca_id = 0 Then
                customMsg.message("error", "you must select type of request/sub to proceed the transaction...", "SUPPLY INFO:")
                Exit Sub
            End If

#End Region

            If isEditAll Then
                'If CDbl(txtQty.Text) < cRSRemainingQuantity Or cRSRemainingQuantity = 0 Then
                '    customMsg.message("error", $"Invalid input: the new quantity must be greater than the existing one.", "SUPPLY INFO:")
                '    Exit Sub
                'End If

                'if admin or authenticated, continue...
                If isAuthenticatedWithoutMessage(auth) OrElse FRequesitionFormForDR.isOnwerOfSelectedRsData() Then
                    GoTo Bypass
                Else
                    customMsg.message("error", "you are not allowed to edit if you are not an owner of this data!", "SMS INFO")
                    Exit Sub
                End If

                'unable to proceed if already withdrawn/received or delivered
                If isUpdateFilter() Then
                    Exit Sub
                End If

Bypass:

                Dim row = FRequesitionFormForDR.DataGridView1.SelectedRows(0)
                Dim rs_id As Integer = row.Cells("rs_id").Value

                With updateRsStorage

                    .rs_id = rs_id
                    .rs_no = txtRsNo.Text
                    .rs_date = Utilities.DateConverter(dtpRsDate.Text)
                    .job_order_no = ""
                    .location = txtLocation.Text
                    .item_desc = txtItemDescription.Text
                    .rs_qty = txtQty.Text
                    .unit = txtUnits.Text
                    .type_of_request = cmbTypeOfRequest.Text
                    .process = cmbTypeOfCharges.Text
                    .purpose = txtPurpose.Text
                    .date_needed = Utilities.DateConverter(dtpDateNeeded.Text)
                    .requested_by = txtRequestedBy.Text
                    .noted_by = txtNotedBy.Text
                    .date_log = Date.Parse(Now)
                    .user_id = pub_user_id
                    .remarks_for_emd = txtRemarksFromEMD.Text
                    .tors_ca_id = tors_ca_id
                    .tor_sub_id = tor_sub_id
                    .wh_pn_id_for_rs = createRsStorage.wh_pn_id_for_rs
                    .job_order_no = txtJoNo.Text
                End With

                updateServices(updateRsStorage)

                Exit Sub
            End If

            With createRsStorage

                .rs_no = txtRsNo.Text
                .rs_date = Utilities.DateConverter(dtpRsDate.Text)
                .job_order_no = ""
                .location = txtLocation.Text
                .item_desc = txtItemDescription.Text
                .rs_qty = txtQty.Text
                .unit = txtUnits.Text
                .type_of_request = cmbTypeOfRequest.Text
                .process = cmbTypeOfCharges.Text
                .purpose = txtPurpose.Text
                .date_needed = Utilities.DateConverter(dtpDateNeeded.Text)
                .requested_by = txtRequestedBy.Text
                .noted_by = txtNotedBy.Text
                .date_log = Date.Parse(Now)
                .user_id = pub_user_id
                .remarks_for_emd = txtRemarksFromEMD.Text
                .tors_ca_id = tors_ca_id
                .tor_sub_id = tor_sub_id
                .job_order_no = txtJoNo.Text
            End With

            saveServices(createRsStorage)

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Function isUpdateFilter() As Boolean
        Try
            Dim selectedRow = FRequesitionFormForDR.DataGridView1.SelectedRows(0)
            Dim drModel = FRequesitionFormForDR.getNewDrModel()
            Dim cn = drModel.cn
            Dim rsId As Integer = selectedRow.Cells(NameOf(cn.rs_id)).Value
            Dim inOut As String = selectedRow.Cells(NameOf(cn.inOut)).Value

            Select Case selectedRow.Cells(NameOf(cn.type_of_purchasing)).Value
                Case cTypeOfPurchasing.PURCHASE_ORDER
                    If drModel.getPurchasedAggregates(rsId) > 0 Then
                        customMsg.message("error", "can't proceed update if already been purchased! please contact the Administrator!", "SMS INFO:")
                        Return True
                    End If

                Case cTypeOfPurchasing.WITHDRAWAL
                    If drModel.getWithdrawnAggregates(rsId) > 0 Then
                        customMsg.message("error", "can't proceed update if already been withdrawn! please contact the Administrator!", "SMS INFO:")
                        Return True
                    End If

                Case cTypeOfPurchasing.DR
                    If drModel.getDeliveredAggregates(inOut, rsId) > 0 Then
                        customMsg.message("error", "can't proceed update if already been delivered! please contact the Administrator!", "SMS INFO:")
                        Return True
                    End If
            End Select
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Private Sub saveServices(rsStorage As PropsFields.Create_Requesition_Slip)
        Try
            If customMsg.messageYesNo("Are you sure you want save this data?", "SUPPLY INFO:", MessageBoxIcon.Question) Then

                Dim createRs As New CreateRequesitionSlipServices
                Dim rs_id As Integer = 0

                If rsStorage.tors_ca_id <> 0 And rsStorage.tor_sub_id <> 0 Then

                    rs_id = createRs.ExecuteWithReturnId(rsStorage)

                ElseIf rsStorage.tors_ca_id = 0 And rsStorage.tor_sub_id <> 0 Then

                    rs_id = createRs.ExecuteNoAccountTitleWithReturnId(rsStorage)

                End If


                If rs_id > 0 Then
                    customMsg.message("info", "Requesition data successfully saved...", "SUPPLY INFO:")

                    If isCopy Then
                        createRs.ExecuteCopyCharges(copyRsChargesStorage, rs_id)

                        FRequesitionFormForDR.getNewDrModel().cRsId = rs_id
                        FRequesitionFormForDR.getNewDrModel().isCreateRsAndAddCharges = True

                        FRequesitionFormForDR.txtSearch.Text = rsStorage.rs_no
                        FRequesitionFormForDR.searchUI.resetBgColor()
                        FRequesitionFormForDR.btnSearch.PerformClick()
                        Me.Dispose()
                    Else
                        showCreateChargesForm(rsStorage, rs_id)
                    End If
                Else
                    customMsg.message("error", "something went wrong in saving rs...", "SUPPLY INFO:")
                End If
            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub showCreateChargesForm(rsStorage As PropsFields.Create_Requesition_Slip,
                                      rs_id As Integer)

        If isChargesWithSameRs(rs_id, rsStorage.rs_no) Then
            With FRequesitionFormForDR
                .getNewDrModel().cRsId = rs_id
                .getNewDrModel().isCreateRsAndAddCharges = True
                .txtSearch.Text = rsStorage.rs_no
                .searchUI.resetBgColor()

                .btnSearch.PerformClick()
            End With
            Exit Sub
        End If


        With FCreateChargesNew
            .isCreateCharges_fromCreateRsForm = True
            .getCreateChargesModel().initialize_rsId(rs_id)
            .getCreateChargesModel().initialize_rsNo(rsStorage.rs_no)
            .ShowDialog()
        End With
    End Sub

    Private Function isChargesWithSameRs(rsId As Integer, rsNo As String) As Boolean
        Try
            If cSelectedChargesStorage IsNot Nothing And
                cSelectedChargesStorage.Count > 0 And
                rsNo = txtRsNo.Text Then

                Dim createCharges As New CreateRequesitionSlipChargesServices
                Dim result As Integer
                For Each row In cSelectedChargesStorage
                    result = createCharges.ExecuteWithReturnId(row, rsId)
                Next

                If result > 0 Then
                    Return True
                End If
            End If

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Private Sub updateServices(rsStorage As PropsFields.Create_Requesition_Slip)
        Try
            If customMsg.messageYesNo("Are you sure you want update this data?", "SUPPLY INFO:", MessageBoxIcon.Question) Then

                Dim updateRs As New UpdateRequesitionSlipServices
                Dim result As Boolean = updateRs.ExecuteWithReturnTrue(rsStorage)
                'Dim rs_id As Integer = updateRs.ExecuteWithReturnId(rsStorage)

                If result = True Then
                    customMsg.message("info", "Requesition data successfully updated...", "SUPPLY INFO:")
                    Me.Dispose()

                    'reload rsdata 
                    FRequesitionFormForDR.getNewDrModel().cRsId = rsStorage.rs_id
                    FRequesitionFormForDR.getNewDrModel().isUpdate = True
                    FRequesitionFormForDR.btnSearch.PerformClick()
                Else
                    customMsg.message("error", "something went wrong in updating rs...", "SUPPLY INFO:")
                End If
            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Try
            properNameUI.refresh()
            createRsStorage.wh_pn_id_for_rs = 0

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
    Private Sub btnProperName_Click(sender As Object, e As EventArgs) Handles btnProperName.Click
        showProperNamingForm()
    End Sub

    Private Sub showProperNamingForm()
        Try
            With FLinkToProperNaming
                .isFromRequestFields2 = True

                .ShowDialog()
            End With
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub cmbTypeOfRequestSub_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTypeOfRequestSub.SelectedIndexChanged

        CREATERSMODEL.initialize_consolidationAccount(cmbConsolidationAccount)
        Dim tor_sub_id As Integer = CREATERSMODEL.get_tor_sub_id(cmbTypeOfRequest.Text,
                                                                 cmbTypeOfRequestSub.Text)

        If tor_sub_id > 0 Then
            cmbConsolidationAccount.Items.Clear()
            cmbConsolidationAccount.SelectedIndex = -1
            consolidationUI.cBox.Text = consolidationUI.placeHolder

            ' Refresh control to ensure UI update
            cmbConsolidationAccount.Refresh()

            CREATERSMODEL.loadConsolidationAccount(tor_sub_id)

        End If
    End Sub


    Private Sub cmbTypeOfRequest_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTypeOfRequest.SelectedIndexChanged
        Try

            CREATERSMODEL.initialize_typeOfRequestSub(cmbTypeOfRequestSub)
            CREATERSMODEL.loadTypeOfRequestSub(cmbTypeOfRequest.Text)

            'reset consolidation
            cmbConsolidationAccount.Items.Clear()
            cmbConsolidationAccount.Text = ""

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
    Private Sub FCreateRSForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            loadUI()
            loadSpecificDataToEveryFields()
            CREATERSMODEL.initialize_typeOfRequest(cmbTypeOfRequest)
            CREATERSMODEL.initialize_employeesData(requestedByUI)
            CREATERSMODEL.initialize_employeesData(notedByUI)

            CREATERSMODEL.initialize_units(unitsUI)
            CREATERSMODEL.initialize_location(locationUI)

            CREATERSMODEL.execute(loadingPanel)

            'movable panel
            Dim myPanel As New MovablePanel

            myPanel.addPanel(Panel1)
            myPanel.addPanel(Panel4)

            myPanel.initializeForm(Me)
            myPanel.addPanelEventHandler()
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

    End Sub

    Private Sub loadUI()
        Try
            Dim fontFamily As New Dictionary(Of String, String)
            fontFamily.Add("fontName", cFontsFamily.bombardier)
            fontFamily.Add("fontSize", 12)

            typeOfRequestUI.king_placeholder_combobox("Type of request...",
                                                 cmbTypeOfRequest,
                                                 Nothing,
                                                 Panel2,
                                                 My.Resources.received,,,
                                                 typeOfRequestUI.cCustomColor.Custom1,
                                                 fontFamily)

            typeOfRequestSubUI.king_placeholder_combobox("Type of request/Sub...",
                                         cmbTypeOfRequestSub,
                                         Nothing,
                                         Panel2,
                                         My.Resources.received,,,
                                         typeOfRequestSubUI.cCustomColor.Custom1,
                                         fontFamily)

            consolidationUI.king_placeholder_combobox("Consolidation Account...",
                                    cmbConsolidationAccount,
                                    Nothing,
                                    Panel2,
                                    My.Resources.received,,,
                                    consolidationUI.cCustomColor.Custom1,
                                    fontFamily)

            properNameUI.king_placeholder_textbox("Proper Name...",
                                    txtProperName,
                                    Nothing,
                                    Panel2,
                                    My.Resources.received,
                                    False,,,
                                    properNameUI.cCustomColor.Custom1,
                                    True,
                                    fontFamily)

            itemDescFromRsUI.king_placeholder_multipleLine_textbox("Item Description From Rs...",
                                                                   txtItemDescription,
                                                                   Nothing,
                                                                   Panel2,
                                                                   My.Resources.received,
                                                                   False,,,
                                                                   itemDescFromRsUI.cCustomColor.Custom1,
                                                                   fontFamily)

            rsNoUI.king_placeholder_textbox("RS No...",
                            txtRsNo,
                            Nothing,
                            Panel2,
                            My.Resources.received,
                            False,,,
                            properNameUI.cCustomColor.Custom1,
                            False,
                            fontFamily)

            typeOfChargesUI.king_placeholder_combobox("Type of charges...",
                            cmbTypeOfCharges,
                            Nothing,
                            Panel2,
                            My.Resources.received,,,,
                            fontFamily)

            locationUI.king_placeholder_textbox("Location...",
                       txtLocation,
                       Nothing,
                       Panel2,
                       My.Resources.received,
                       False,,,
                       locationUI.cCustomColor.Custom1,
                       False,
                       fontFamily)

            dateRequestUI.king_placeholder_datepicker("Date Request...",
                                                      dtpRsDate,
                                                      Panel2,
                                                      My.Resources.received,
                                                      dateRequestUI.cCustomColor.Custom1,
                                                      fontFamily)

            dateNeededUI.king_placeholder_datepicker("Date Needed...",
                                              dtpDateNeeded,
                                              Panel2,
                                              My.Resources.received,
                                              dateNeededUI.cCustomColor.Custom1,
                                              fontFamily)

            joNoUI.king_placeholder_textbox("Joborder #...",
                               txtJoNo,
                               Nothing,
                               Panel2,
                               My.Resources.received,
                               False,,,
                               joNoUI.cCustomColor.Custom1,
                               False,
                               fontFamily)

            rsQuantityUI.king_placeholder_textbox("RS Quantity...",
                       txtQty,
                       Nothing,
                       Panel2,
                       My.Resources.received,
                       True,,,, False, fontFamily)

            unitsUI.king_placeholder_textbox("Units...",
                       txtUnits,
                       Nothing,
                       Panel2,
                       My.Resources.received,
                       False,,,
                       unitsUI.cCustomColor.Custom1,
                       False,
                       fontFamily)


            purposeUI.king_placeholder_multipleLine_textbox("Purpose...",
                                                                   txtPurpose,
                                                                   Nothing,
                                                                   Panel2,
                                                                   My.Resources.received,
                                                                   False,,,
                                                                   purposeUI.cCustomColor.Custom1,
                                                                   fontFamily)


            remarksForEMDUI.king_placeholder_multipleLine_textbox("Remarks for EMD...",
                                                                   txtRemarksFromEMD,
                                                                   Nothing,
                                                                   Panel2,
                                                                   My.Resources.received,
                                                                   False,,,
                                                                   remarksForEMDUI.cCustomColor.Custom1,
                                                                   fontFamily)


            requestedByUI.king_placeholder_textbox("Requested By...",
               txtRequestedBy,
               Nothing,
               Panel2,
               My.Resources.received,
               False,,,
               requestedByUI.cCustomColor.Custom1,
               False,
               fontFamily)


            notedByUI.king_placeholder_textbox("Noted By...",
               txtNotedBy,
               Nothing,
               Panel2,
               My.Resources.received,
               False,,,
               notedByUI.cCustomColor.Custom1,
               False,
               fontFamily)

            txtRsNo.Focus()

            'for administrator only
            If auth.ToUpper() = cUserAuthentication.ADMIN.ToUpper() Then
                btnAutoFill.Visible = True
            Else
                btnAutoFill.Visible = False
            End If

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
    Private Sub loadSpecificDataToEveryFields()

        'load specific data every textbox here
        If isCopy Or isEditAll Then
            With ccopyRsData
                dtpRsDate.Text = .rs_date
                dtpDateNeeded.Text = .date_needed
                txtRsNo.Text = .rs_no
                txtLocation.Text = .location
                txtJoNo.Text = .job_order_no
                txtUnits.Text = .unit
                txtRequestedBy.Text = .requested_by
                txtNotedBy.Text = .noted_by
                txtPurpose.Text = .purpose
                txtRemarksFromEMD.Text = .remarks_for_emd
                txtItemDescription.Text = .rs_items
                cmbTypeOfCharges.Text = .process

#Region "PROPER NAMES"
                Dim listofpn = FRequesitionFormForDR.getNewDrModel().getProperNaming()
                Dim propername = listofpn.FirstOrDefault(Function(x) x.wh_pn_id = .wh_pn_id_for_rs)

                If propername IsNot Nothing Then
                    createRsStorage.wh_pn_id_for_rs = propername.wh_pn_id
                    txtProperName.Text = $"{propername.item_name} - {propername.item_desc}"
                End If
#End Region

#Region "TYPE OF REQUEST"
                Dim listofconsolidation = FRequesitionFormForDR.getNewDrModel().getConsolidationAccount()
                Dim typeofrequest = FRequesitionFormForDR.getNewDrModel().getTypeOfRequest()
                Dim consolidation, _typeofrequest

                If .tors_ca_id <> 0 Then 'for account title
                    consolidation = TryCast(listofconsolidation, List(Of PropsFields.Consolidated_Account))
                    consolidation = listofconsolidation.FirstOrDefault(Function(x) x.tors_ca_id = .tors_ca_id)

                    If consolidation IsNot Nothing Then
                        cmbTypeOfRequest.Text = consolidation.tor_desc
                        cmbTypeOfRequestSub.Text = consolidation.tor_sub_desc
                        cmbConsolidationAccount.Text = $"{consolidation.category} ({consolidation.codes})"
                    End If

                Else 'for old ways | type of request and sub
                    _typeofrequest = TryCast(typeofrequest, List(Of PropsFields.TypeOfRequest))
                    _typeofrequest = typeofrequest.FirstOrDefault(Function(x) x.tor_sub_id = .tor_sub_id)

                    If _typeofrequest IsNot Nothing Then
                        cmbTypeOfRequest.Text = _typeofrequest.tor_desc
                        cmbTypeOfRequestSub.Text = _typeofrequest.tor_sub_desc
                    End If
                End If
#End Region

#Region "UNITS"
                txtUnits.Text = .unit_from_rs
#End Region

#Region "RS QUANTITY"
                If isCopy Then
                    txtQty.Text = .rs_qty
                ElseIf isEditAll Then
                    txtQty.Text = cRSRemainingQuantity
                End If
#End Region

            End With
        End If
    End Sub

    Private Sub txtProperName_GotFocus(sender As Object, e As EventArgs) Handles txtProperName.GotFocus
        If createRsStorage.wh_pn_id_for_rs = 0 Then
            showProperNamingForm()
        End If

    End Sub

    Private Sub txtProperName_Leave(sender As Object, e As EventArgs) Handles txtProperName.Leave
        If createRsStorage.wh_pn_id_for_rs = -1 Then
            createRsStorage.wh_pn_id_for_rs = 0
        End If
    End Sub

    Private Sub FCreateRSForm_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Me.Dispose()
    End Sub
#Region "UTILITIES"

#End Region

End Class