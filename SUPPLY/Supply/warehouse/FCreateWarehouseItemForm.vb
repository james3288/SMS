Imports System.Web.SessionState

Public Class FCreateWarehouseItemForm
    Private DivisionUI,
        TurnoverUI,
        ItemNameUI,
        ItemDescUI,
        ClassificationUI,
        WhAreaUI,
        TypeOfRequestUI,
        TypeOfRequestSubUI,
        ConsolidationUI,
        inOthersUI,
        specificLocUI,
        ReorderPointUI,
        DefaultPriceUI,
        ProperNameUI,
        WhAreaStockpileUI,
        quarryUI,
        UnitsUI,
        kpiUI As New class_placeholder5
    Public isEdit As Boolean
    Public kpiId_selected As String

    'Private save As String = "Save Items"
    'Private update As String = "Update Items"
    Public whitemStorage As New PropsFields.whItems_props_fields
    Public cListOfSelectedKPI As New List(Of PropsFields.SELECTED_KPI)

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Const CS_DROPSHADOW As Integer = &H20000
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ClassStyle = cp.ClassStyle Or CS_DROPSHADOW
            Return cp
        End Get
    End Property

    Private Class SaveUpdate
        Public ReadOnly Property save As String = "Create Item"
        Public ReadOnly Property update As String = "Update Item"

    End Class

    Private cSaveUpdate As New SaveUpdate
    Private Sub btnKpi_Click(sender As Object, e As EventArgs) Handles btnKpi.Click
        'FKeyPerformanceIndicator.isFromWarehouseItemNew = True
        'FKeyPerformanceIndicator.ShowDialog()
        Try
            cListOfSelectedKPI.Clear()
            txtKPI.Clear()
            FkeyPerformanceIndicatorNew.ShowDialog()
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub


    Private Sub btnQuarry_Click(sender As Object, e As EventArgs) Handles btnQuarry.Click
        With FWarehouseAreaNew
            .isFromCreateWarehouseItem_quarry = True
            .ShowDialog()
        End With
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If btnSave.Text = cSaveUpdate.save Then
            save_update(cSaveUpdate.save)
            FkeyPerformanceIndicatorNew.DataGridView2.Rows.Clear()
        Else
            save_update(cSaveUpdate.update)
        End If

    End Sub

    Private Sub save_update(saveUpdate As String)
        Try
#Region "FILTER"
            Dim whAreaErrorMessage As String = "you must select a warehouse area to proceed saving!"
            Dim whQuarryErrorMessage As String = "you must select quarry area to proceed saving!"
            Dim whProperNameErrorMessage As String = "you must select proper name to proceed saving!"
            Dim typeOfRequestSubErrorMessage As String = "you msut select an account title to proceed saving, do you still want to proceed?"
            Dim messageTitle As String = "SUPPLY INFO:"
            'Dim generalErrorMessage As String = "fill the blank in the fields"
            Dim kpiErrorMessage As String = "you must select atleast 1 KPI!"

            Dim consolidationData = FWarehouseItemsNew.
                getWhItemsModel().
                getConsolidationAccount().
                Where(Function(x)
                          Return $"{x.category} ({x.codes})".ToUpper() = cmbConsolidationAccount.Text.ToUpper()
                      End Function).
                ToList().FirstOrDefault()

            If consolidationData IsNot Nothing Then
                whitemStorage.consolidated_account_id = consolidationData.consolidated_account_id
            End If

            If saveUpdate = cSaveUpdate.save Then
                If cListOfSelectedKPI.Count = 0 Or cListOfSelectedKPI Is Nothing Then
                    customMsg.message("error", kpiErrorMessage, "SMS INFO:")
                    Exit Sub
                End If

                'filter for some textfields and combobox fields
                If ClassificationUI.ifBlankTexbox() Then
                    generalErrorMessageForTextBox(ClassificationUI)
                    Exit Sub
                ElseIf specificLocUI.ifBlankTexbox() Then
                    generalErrorMessageForTextBox(specificLocUI)
                    Exit Sub
                ElseIf ReorderPointUI.ifBlankTexbox() Then
                    generalErrorMessageForTextBox(ReorderPointUI)
                    Exit Sub
                ElseIf DefaultPriceUI.ifBlankTexbox() Then
                    generalErrorMessageForTextBox(DefaultPriceUI)
                    Exit Sub
                ElseIf UnitsUI.ifBlankTexbox() Then
                    generalErrorMessageForTextBox(UnitsUI)
                    Exit Sub
                ElseIf DivisionUI.ifBlankCombobox() Then
                    generalErrorMessageForComboBox(DivisionUI)
                    Exit Sub
                ElseIf TurnoverUI.ifBlankCombobox() Then
                    generalErrorMessageForComboBox(TurnoverUI)
                    Exit Sub
                End If

                'filter for warehouse area / stockpile
                If whitemStorage.wh_area_id = 0 Then
                    'disable temporary
                    'customMsg.message("error", whAreaErrorMessage, messageTitle)
                    'Exit Sub

                    'filter for proper names
                ElseIf whitemStorage.wh_pn_id = 0 Then
                    customMsg.message("error", whProperNameErrorMessage, messageTitle)
                    Exit Sub

                End If

                Select Case cmbDivision.Text
                    Case cDivision.CRUSHING_AND_HAULING

                        'filter for quarry
                        'disable temporary
                        'If whitemStorage.quarry_id = 0 Then
                        '    customMsg.message("error", whQuarryErrorMessage, messageTitle)
                        '    Exit Sub
                        'End If
                End Select

            End If



#End Region

#Region "SERVICES"
            Dim createItems As New CreateWarehouseItemServices
            Dim updateItems As New UpdateWarehouseItemServices

            With whitemStorage
                .division = cmbDivision.Text
                .Turnover = cmbTurnover.Text
                .inout = cmbInOut.Text
                .specific_loc = txtSpecificLocation.Text
                .reorder_point = txtReorderPoint.Text
                .default_price = txtDefaultPrice.Text
                .units = txtUnit.Text
            End With

            Dim id As Integer
            Dim isUpdate As Boolean
            Dim wh_id As Integer

            If saveUpdate = cSaveUpdate.save Then
                If customMsg.messageYesNo("Are you sure you want to save this item?", "SUPPLY INFO:", MessageBoxIcon.Question) Then
                    createItems.initialize_kpiData(cListOfSelectedKPI)
                    id = createItems.ExecuteWithReturnId(whitemStorage)
                Else
                    Exit Sub
                End If

            ElseIf saveUpdate = cSaveUpdate.update Then
                If customMsg.messageYesNo("Are you sure you want to update this item?", "SUPPLY INFO:", MessageBoxIcon.Question) Then
                    wh_id = FWarehouseItemsNew.DataGridView1.SelectedRows(0).Cells("wh_id").Value
                    isUpdate = updateItems.ExecuteWithReturnBoolean(whitemStorage, wh_id)
                Else
                    Exit Sub
                End If
            End If

#End Region

#Region "RELOAD"
            If id > 0 And saveUpdate = cSaveUpdate.save Then
                customMsg.message("info", "Successfully Saved!", messageTitle)
                FWarehouseItemsNew.getWhItemsModel().isSaved = True
                FWarehouseItemsNew.getWhItemsModel().setRowId = id
                FWarehouseItemsNew.getWhItemsModel().getWarehouseItems("")


            ElseIf id = 0 And saveUpdate = cSaveUpdate.update Then
                customMsg.message("info", "Successfully Updated!", messageTitle)
                FWarehouseItemsNew.getWhItemsModel().isUpdate = True
                FWarehouseItemsNew.getWhItemsModel().setRowId = wh_id
                FWarehouseItemsNew.getWhItemsModel().getWarehouseItems("")

            Else
                customMsg.message("error", "Something went wrong when saving!", messageTitle)
            End If

#End Region
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub generalErrorMessageForTextBox(fields As class_placeholder5)
        customMsg.message("error", $"you must fill the field {fields.tbox.Name}!", "SMS INFO:")
        fields.tbox.Focus()
    End Sub

    Private Sub generalErrorMessageForComboBox(fields As class_placeholder5)
        customMsg.message("error", $"you must fill the field {fields.cBox.Name}!", "SMS INFO:")
        fields.cBox.Focus()
    End Sub

    Private Sub btnWhArea_Click(sender As Object, e As EventArgs) Handles btnWhArea.Click
        If customMsg.messageYesNo("YES: for Stockpile/Warehouse Area" & vbCrLf & "NO: for Project Sites and Others", "SUPPLY INFO:") Then

            With FWarehouseAreaNew
                .isFromCreateWarehouseItem_whArea = True
                .ShowDialog()
            End With
        Else
            With FCharge_To
                .forStockpileLocation = True
                .ShowDialog()
            End With

        End If
    End Sub

    Private Sub btnClassification_Click(sender As Object, e As EventArgs) Handles btnClassification.Click
        FWarehouseClassification.isFromCreateWarehouseItem = True
        FWarehouseClassification.ShowDialog()
    End Sub

    Private Sub btnProperName_Click(sender As Object, e As EventArgs) Handles btnProperName.Click
        FLinkToProperNaming.isFromCreateWarehouseItem = True
        FLinkToProperNaming.ShowDialog()
    End Sub



    Private Sub cmbTypeOfRequestSub_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTypeOfRequestSub.SelectedIndexChanged
        Dim typeofrequestSub = getTypeOfRequestSub()
        Dim tor_sub_id As Integer = typeofrequestSub.tor_sub_id

        If tor_sub_id > 0 Then
            cmbConsolidationAccount.Items.Clear()
            cmbConsolidationAccount.SelectedIndex = -1
            ConsolidationUI.cBox.Text = ConsolidationUI.placeHolder

            ' Refresh control to ensure UI update
            cmbConsolidationAccount.Refresh()

            loadConsolidationAccount(tor_sub_id)

        End If
    End Sub



    Private Sub cmbTypeOfRequest_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTypeOfRequest.SelectedIndexChanged
        loadTypeOfRequestSub(cmbTypeOfRequest.Text)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FkeyPerformanceIndicatorNew.DataGridView2.Rows.Clear()
        Me.Dispose()
    End Sub

    Private Sub cmbDivision_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDivision.SelectedIndexChanged
        If cmbDivision.Text.ToUpper() = cDivision.WAREHOUSING_AND_SUPPLY Then
            warehousing_crushing(True)
        Else
            warehousing_crushing(False)
        End If
    End Sub

    Private customMsg As New customMessageBox

    Private Sub FCreateWarehouseItemForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim fontFamily As New Dictionary(Of String, String)
            fontFamily.Add("fontName", cFontsFamily.bombardier)
            fontFamily.Add("fontSize", 12)

            DivisionUI.king_placeholder_combobox("Division...",
                                                 cmbDivision,
                                                 Nothing,
                                                 Panel2,
                                                 My.Resources.received,,,,
                                                 fontFamily)

            TurnoverUI.king_placeholder_combobox("Turnover...",
                                                 cmbTurnover,
                                                 Nothing,
                                                 Panel2,
                                                 My.Resources.received,,,,
                                                 fontFamily)

            TypeOfRequestUI.king_placeholder_combobox("Type of request...",
                                                cmbTypeOfRequest,
                                                Nothing,
                                                Panel2,
                                                My.Resources.received,,,,
                                                fontFamily
                                                )

            TypeOfRequestSubUI.king_placeholder_combobox("Type of Request Sub...",
                                    cmbTypeOfRequestSub,
                                    Nothing,
                                    Panel2,
                                    My.Resources.received,,,,
                                    fontFamily
                                    )

            ConsolidationUI.king_placeholder_combobox("Consolidation Account...",
                                    cmbConsolidationAccount,
                                    Nothing,
                                    Panel2,
                                    My.Resources.received,,,,
                                    fontFamily
                                    )

            ProperNameUI.king_placeholder_textbox("Proper Names...",
                        txtProperName,
                        Nothing,
                        Panel2,
                        My.Resources.received,
                        False,,,,,
                        fontFamily)

            ProperNameUI.readOnlyTextBox(True)


            ClassificationUI.king_placeholder_textbox("Classification...",
                        txtWhClassificationAndOthers,
                        Nothing,
                        Panel2,
                        My.Resources.received,
                        False,,,,, fontFamily)
            ClassificationUI.readOnlyTextBox(True)

            WhAreaStockpileUI.king_placeholder_textbox("WH Area/Stockpile/Project Site...",
                        txtWhAreaQuarryAreaProjectSite,
                        Nothing,
                        Panel2,
                        My.Resources.received,
                        False,,,,, fontFamily)
            WhAreaStockpileUI.readOnlyTextBox(True)

            quarryUI.king_placeholder_textbox("Quarry Code...",
                        txtQuarry,
                        Nothing,
                        Panel2,
                        My.Resources.received,
                        False,,,,, fontFamily)
            quarryUI.readOnlyTextBox(True)

            kpiUI.king_placeholder_textbox("Key performance indicator...",
                        txtKPI,
                        Nothing,
                        Panel2,
                        My.Resources.received,
                        False,,,,, fontFamily)
            kpiUI.readOnlyTextBox(True)

            inOthersUI.king_placeholder_combobox("IN/OTHERS...",
                                    cmbInOut,
                                    Nothing,
                                    Panel2,
                                    My.Resources.received,,,, fontFamily
                                    )

            specificLocUI.king_placeholder_textbox("Specific Location...",
                        txtSpecificLocation,
                        Nothing,
                        Panel2,
                        My.Resources.received,
                        False,,,,, fontFamily)

            ReorderPointUI.king_placeholder_textbox("Reorder Point...",
                      txtReorderPoint,
                      Nothing,
                      Panel2,
                      My.Resources.received,
                      True,,,,, fontFamily)

            DefaultPriceUI.king_placeholder_textbox("Default Price...",
                      txtDefaultPrice,
                      Nothing,
                      Panel2,
                      My.Resources.received,
                      True,,,,, fontFamily)

            UnitsUI.king_placeholder_textbox("Units..",
                      txtUnit,
                      Nothing,
                      Panel2,
                      My.Resources.received,
                      False,,,,, fontFamily)

            cmbDivision.Items.Add(cDivision.WAREHOUSING_AND_SUPPLY)
            cmbDivision.Items.Add(cDivision.CRUSHING_AND_HAULING)

            cmbTurnover.Items.Add("YES")
            cmbTurnover.Items.Add("NO")

            cmbInOut.Items.Add("OTHERS")
            cmbInOut.Items.Add("IN")

            loadTypeOfRequest()

            If isEdit Then
                editWarehouseItem()
            End If

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

    Private Sub loadTypeOfRequest()
        Dim listOfTypeOfRequest As New List(Of PropsFields.TypeOfRequest)
        listOfTypeOfRequest = FWarehouseItemsNew.getWhItemsModel().getTypeOfRequest

        For Each row In listOfTypeOfRequest.Select(Function(x) x.tor_desc).Distinct().ToList()
            cmbTypeOfRequest.Items.Add(row)
        Next
    End Sub

    Private Sub loadTypeOfRequestSub(typeOfRequest As String)
        cmbTypeOfRequestSub.Items.Clear()

        Dim listOfTypeOfRequest As New List(Of PropsFields.TypeOfRequest)
        listOfTypeOfRequest = FWarehouseItemsNew.getWhItemsModel().getTypeOfRequest

        For Each row In listOfTypeOfRequest.Where(Function(x) x.tor_desc.ToUpper() = typeOfRequest.ToUpper()).ToList()
            cmbTypeOfRequestSub.Items.Add(row.tor_sub_desc)
        Next
    End Sub

    Private Sub loadConsolidationAccount(tor_sub_id As Integer)
        cmbConsolidationAccount.Items.Clear()

        Dim listOfConsolidationAccount As New List(Of PropsFields.Consolidated_Account)
        listOfConsolidationAccount = FWarehouseItemsNew.getWhItemsModel().getConsolidationAccount

        For Each row In listOfConsolidationAccount.Where(Function(x) x.tor_sub_id = tor_sub_id).ToList()
            cmbConsolidationAccount.Items.Add($"{row.category} ({row.codes})")
        Next

        cmbConsolidationAccount.SelectedIndex = -1
    End Sub
    Private Sub warehousing_crushing(isWarehousing As Boolean)
        If isWarehousing Then
            txtQuarry.Enabled = False
            btnQuarry.Enabled = False
            whitemStorage.quarry_id = 0
            quarryUI.tbox.Clear()
            quarryUI.refresh()

        Else
            txtQuarry.Enabled = True
            btnQuarry.Enabled = True
            whitemStorage.wh_area_id = 0
            WhAreaStockpileUI.tbox.Clear()
            WhAreaStockpileUI.refresh()
        End If

    End Sub

    Private Sub editWarehouseItem()
        btnSave.Text = cSaveUpdate.update

        Dim wh_id As Integer = FWarehouseItemsNew.DataGridView1.SelectedRows(0).Cells("wh_id").Value
        Dim editData = FWarehouseItemsNew.getWhItemsModel().getSpecificItemForEdit(wh_id)

        With editData
            whitemStorage.division = .division
            cmbDivision.Text = .division

            whitemStorage.Turnover = .Turnover
            cmbTurnover.Text = .Turnover

            whitemStorage.wh_pn_id = .wh_pn_id
            whitemStorage.proper_item_name = .proper_item_name
            whitemStorage.proper_item_desc = .proper_item_desc
            txtProperName.Text = .proper_item_desc

            whitemStorage.classification = .classification
            txtWhClassificationAndOthers.Text = .classification

            whitemStorage.wh_area_id = .wh_area_id
            txtWhAreaQuarryAreaProjectSite.Text = .warehouse_area
            whitemStorage.whArea_category = .whArea_category

            whitemStorage.quarry_id = .quarry_id
            whitemStorage.quarry = .quarry
            txtQuarry.Text = .quarry

            whitemStorage.kpi_id = .kpi_id
            txtKPI.Text = .kpi

            whitemStorage.specific_loc = .specific_loc
            txtSpecificLocation.Text = .specific_loc

            whitemStorage.reorder_point = .reorder_point
            txtReorderPoint.Text = .reorder_point

            whitemStorage.default_price = .default_price
            txtDefaultPrice.Text = .default_price

            whitemStorage.units = .units
            txtUnit.Text = .units

            whitemStorage.item_name = .item_name
            whitemStorage.item_desc = .item_desc

            'consolidation
            Dim listOfConsolidationAccount As New List(Of PropsFields.Consolidated_Account)
            listOfConsolidationAccount = FWarehouseItemsNew.getWhItemsModel().getConsolidationAccount

            Dim consolidation = listOfConsolidationAccount.FirstOrDefault(Function(x) x.consolidated_account_id = .consolidated_account_id)
            If consolidation IsNot Nothing Then
                cmbTypeOfRequest.Text = consolidation.tor_desc
                cmbTypeOfRequestSub.Text = consolidation.tor_sub_desc
                cmbConsolidationAccount.Text = $"{consolidation.category} ({consolidation.codes})"
            End If

            'disable some parts of item data
            btnProperName.Enabled = False
            btnWhArea.Enabled = False
            btnQuarry.Enabled = False
            btnKpi.Enabled = False

        End With
    End Sub

#Region "PRIVATE GET"
    Private Function getTypeOfRequestSub() As PropsFields.TypeOfRequest
        Try
            Dim dataResult = FWarehouseItemsNew.
                                getWhItemsModel().
                                getTypeOfRequest().
                                FirstOrDefault(Function(x)
                                                   Return x.tor_sub_desc.ToUpper() = cmbTypeOfRequestSub.Text.ToUpper() And
                                                                                    x.tor_desc.ToUpper() = cmbTypeOfRequest.Text.ToUpper()
                                               End Function)
            If dataResult IsNot Nothing Then
                getTypeOfRequestSub = dataResult
            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function
#End Region
End Class