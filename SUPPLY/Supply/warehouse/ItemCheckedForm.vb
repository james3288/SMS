Imports SUPPLY.KeyPerformanceIndicatorModel
Imports SUPPLY.PropsFields
Imports System.Windows.Controls

Public Class ItemCheckedForm
    Private remainingBalanceUI,
        inOutUI,
        typeOfPurchasingUI,
        requestedQtyUI,
        requestedByUI,
        facilitiesToolsUI,
        remarksUI,
        warehouseInchargeUI,
        approvedByUI As New class_placeholder5

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Const CS_DROPSHADOW As Integer = &H20000
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ClassStyle = cp.ClassStyle Or CS_DROPSHADOW
            Return cp
        End Get
    End Property

    Private Sub btnSetItemCheck_Click(sender As Object, e As EventArgs) Handles btnSetItemCheck.Click
        Try
#Region "FILTER"
            If remainingBalanceUI.isBlankTextBox() Then
                'remainingBalanceUI.tbox.Focus()
                'Utilities.ErrorMessage(remainingBalanceUI.placeHolder)
                'Exit Sub

            ElseIf inOutUI.isBlankComboBox() Then
                inOutUI.cBox.Focus()
                Utilities.ErrorMessage(inOutUI.placeHolder)
                Exit Sub

            ElseIf typeOfPurchasingUI.isBlankComboBox() Then
                typeOfPurchasingUI.cBox.Focus()
                Utilities.ErrorMessage(typeOfPurchasingUI.placeHolder)
                Exit Sub

            ElseIf requestedQtyUI.isBlankTextBox() Then
                requestedQtyUI.tbox.Focus()
                Utilities.ErrorMessage(requestedQtyUI.placeHolder)
                Exit Sub

            ElseIf facilitiesToolsUI.isBlankComboBox() Then
                facilitiesToolsUI.cBox.Focus()
                Utilities.ErrorMessage(facilitiesToolsUI.placeHolder)
                Exit Sub

            ElseIf remarksUI.isBlankTextBox() Then
                remarksUI.tbox.Focus()
                Utilities.ErrorMessage(remarksUI.placeHolder)
                Exit Sub

            ElseIf warehouseInchargeUI.isBlankTextBox() Then
                warehouseInchargeUI.tbox.Focus()
                Utilities.ErrorMessage(warehouseInchargeUI.placeHolder)
                Exit Sub

            ElseIf approvedByUI.isBlankTextBox() Then
                approvedByUI.tbox.Focus()
                Utilities.ErrorMessage(approvedByUI.placeHolder)
                Exit Sub
            End If

            'If remainingBalanceUI.tbox.Text <= 0 Then
            '    remainingBalanceUI.tbox.Focus()
            '    Utilities.ErrorMessage(remainingBalanceUI.placeHolder)
            '    Exit Sub
            'End If

#End Region
            If customMsg.messageYesNo("Are you sure you want to item checked this item?", "SUPPY INFO:") Then
                Dim itemCheckedData As New PropsFields.item_checked_props_fields
                Dim rs_id As Integer = FRequesitionFormForDR.DataGridView1.SelectedRows(0).Cells("rs_id").Value
                Dim wh_id As Integer = FWarehouseItemsNew.DataGridView1.SelectedRows(0).Cells("wh_id").Value

                With itemCheckedData
                    .rs_id = rs_id
                    .wh_id = wh_id
                    .inOut = cmbInOut.Text
                    .remarks = txtRemarks.Text
                    .typeOfPurchasing = cmbTypeOfPurchasing.Text
                    .user_id = pub_user_id
                    .warehouseIncharge = txtWarehouseIncharge.Text
                    .approved_by = txtApprovedBy.Text
                End With

                Dim updateItemChecked As New UpdateItemCheckedServices
                Dim result As Boolean = updateItemChecked.ExecuteWithReturnTrue(itemCheckedData)

                If result Then
                    Me.Dispose()
                    FWarehouseItemsNew.Dispose()
                    FRequesitionFormForDR.getNewDrModel().cRsId = rs_id
                    FRequesitionFormForDR.getNewDrModel().isItemChecked = True
                    FRequesitionFormForDR.btnSearch.PerformClick()
                Else
                    customMsg.message("error", "there is something wrong with item checking...", "SUPPLY INFO:")
                    Exit Sub
                End If
            End If

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Public cRsQuantityFromRsForm As Double

    Private Sub cmbInOut_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbInOut.SelectedIndexChanged
        If cmbInOut.Text = cInOut._OUT Then
            cmbTypeOfPurchasing.Items.Clear()
            cmbTypeOfPurchasing.Items.Add(cTypeOfPurchasing.WITHDRAWAL)

        ElseIf cmbInOut.Text = cInOut._IN Or cmbInOut.Text = cInOut._OTHERS Then
            cmbTypeOfPurchasing.Items.Clear()
            cmbTypeOfPurchasing.Items.Add(cTypeOfPurchasing.PURCHASE_ORDER)
            cmbTypeOfPurchasing.Items.Add(cTypeOfPurchasing.DR)

        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Dispose()
    End Sub

    Private customMsg As New customMessageBox
    Private cListOfEmployees As New List(Of PropsFields.smsUsers_props_fields)
    Private Sub ItemCheckedForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'cmbTypeOfPurchasing.Items.Add(cTypeOfPurchasing.WITHDRAWAL)
        'cmbTypeOfPurchasing.Items.Add(cTypeOfPurchasing.PURCHASE_ORDER)
        'cmbTypeOfPurchasing.Items.Add(cTypeOfPurchasing.DR)

        btnSetItemCheck.Enabled = False

        cmbInOut.Items.Add(cInOut._OUT)
        cmbInOut.Items.Add(cInOut._IN)
        cmbInOut.Items.Add(cInOut._OTHERS)

        cRsQuantityFromRsForm = Utilities.ifBlankReplaceToZero(FRequesitionFormForDR.DataGridView1.SelectedRows(0).
                                                               Cells(NameOf(PropsFields.rsdata_props_fields.rs_qty)).Value)
        initializeUI()

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


            remainingBalanceUI.king_placeholder_textbox("Remaining Balance...",
                                              txtRemainingBalance,
                                              Nothing,
                                              Panel2,
                                              My.Resources.received,
                                              True,,,, True,
                                              fontFamily)

            inOutUI.king_placeholder_combobox("IN/OUT...",
                                           cmbInOut,
                                           Nothing,
                                           Panel2,
                                           My.Resources.received,,,,
                                           fontFamily)

            typeOfPurchasingUI.king_placeholder_combobox("Type of Purchasing...",
                                       cmbTypeOfPurchasing,
                                       Nothing,
                                       Panel2,
                                       My.Resources.received,,,,
                                       fontFamily)

            requestedQtyUI.king_placeholder_textbox("Requested Quantity...",
                                            txtRequestedQty,
                                            Nothing,
                                            Panel2,
                                            My.Resources.received,
                                            False,,,,,
                                            fontFamily)


            facilitiesToolsUI.king_placeholder_combobox("Facilities/Tools...",
                                       cmbFacilitiesTools,
                                       Nothing,
                                       Panel2,
                                       My.Resources.received,,,,
                                       fontFamily)

            remarksUI.king_placeholder_textbox("Remarks...",
                                txtRemarks,
                                Nothing,
                                Panel2,
                                My.Resources.received,
                                False,,,,,
                                fontFamily)

            warehouseInchargeUI.king_placeholder_textbox("Warehouse Incharge...",
                               txtWarehouseIncharge,
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


            initializeData()
        Catch ex As Exception
            customMsg.ErrorMessage(ex)

        Finally
            btnSetItemCheck.Enabled = True
        End Try
    End Sub

    Private Sub initializeData()
        Try

#Region "EMPLOYEES"
            Dim employees = FWarehouseItemsNew.getWhItemsModel().getEmployees()
            Dim listOfEmployees As New List(Of String)
            If employees.Count > 0 Then
                For Each emp In employees
                    listOfEmployees.Add($"{emp.last_name}, {emp.first_name} {emp.middle_name}")
                Next
            End If


            warehouseInchargeUI.AutoCompleteData = listOfEmployees
            warehouseInchargeUI.set_autocomplete()

            approvedByUI.AutoCompleteData = listOfEmployees
            approvedByUI.set_autocomplete()
#End Region

#Region "RS QUANTITY"
            txtRequestedQty.Text = cRsQuantityFromRsForm
#End Region


        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub


End Class