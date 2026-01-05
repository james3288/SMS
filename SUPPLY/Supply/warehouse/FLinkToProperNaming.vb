
Public Class FLinkToProperNaming
    Private itemNameUI, itemDescUI, searchUI As New class_placeholder4
    Private properNameModel As New ModelNew.Model
    Dim cBgWorkerChecker As Timer
    Private cResult As New List(Of PropsFields.whItems_properName_fields)
    Private customGridview As New CustomGridview
    Dim cSearch As String
    Dim customMsgBox As New customMessageBox

    Public isFromWareHouse, isFromWareHouseItemNew As Boolean
    Public isFromWareHouse_link_btn As Boolean
    Public isFromRequestFields, isFromRequestFields2 As Boolean
    Public isFromRequisitionFormEdit As Boolean
    Public isFromCreateWarehouseItem As Boolean
    Public isCreateNewProperNames, isCreateNewProperNames2 As Boolean

    Public isViewing As Boolean
    Private customMsg As New customMessageBox

    Private itemNameNewUI, itemDescNewUI, unitsUI, typeOfRequestUI As New class_placeholder4
    Private cWh_pn_id As Integer
    Private cn As New PropsFields.whItems_properName_fields
    Private TypeOfRequestModel As New ModelNew.Model
    Private cListOfTypeOfRequest As New List(Of PropsFields.TypeOfRequest)


    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Const CS_DROPSHADOW As Integer = &H20000
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ClassStyle = cp.ClassStyle Or CS_DROPSHADOW
            Return cp
        End Get
    End Property

    Private Class customHeaderProps
        Public ReadOnly Property ITEM_NAME As String = "ITEM NAME"
        Public ReadOnly Property ITEM_DESCRIPTION As String = "ITEM DESCRIPTION"
        Public ReadOnly Property UNITS As String = "UNITS"
        Public ReadOnly Property TYPE_OF_REQUEST As String = "TYPE OF REQUEST"
        Public ReadOnly Property PROVIDED_BY As String = "PROVIDED BY"


    End Class

    Private cHp As New customHeaderProps
    Private cHp2 As New PropsFields.whItems_properName_fields

    Private Sub FLinkToProperNaming_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'itemNameUI.king_placeholder_textbox("item name...", txtItemName, Nothing, Panel1, My.Resources.received,)
        'itemDescUI.king_placeholder_textbox("item desc...", txtItemDesc, Nothing, Panel1, My.Resources.received,)
        itemDescUI.king_placeholder_textbox("search here...", txtSearch, Nothing, Panel1, My.Resources.received,)
        customGridview.customDatagridview(DataGridView1,, 28)


        itemNameNewUI.king_placeholder_textbox("Item Name...", txtItemName, Nothing, Panel2, My.Resources.received,)
        itemDescNewUI.king_placeholder_textbox("Item Description...", txtItemDesc, Nothing, Panel2, My.Resources.received,)
        unitsUI.king_placeholder_textbox("Units...", txtUnits, Nothing, Panel2, My.Resources.received,)
        typeOfRequestUI.king_placeholder_combobox("Type of Request...", cmbTypeOfRequest, Nothing, Panel2, My.Resources.received)

        'typeofrequest
        typeOfRequestUI.cBox.Items.Add(cTypeOfRequest.MAJOR)
        typeOfRequestUI.cBox.Items.Add(cTypeOfRequest.MINOR)

        getWhProperNaming()

        'movable panel
        Dim myPanel As New MovablePanel
        myPanel.addPanel(Panel1)

        myPanel.initializeForm(Me)
        myPanel.addPanelEventHandler()

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        If isFromRequestFields2 Then
            FCreateRSForm.createRsStorage.wh_pn_id_for_rs = -1
            Me.Dispose()

        ElseIf isCreateNewProperNames Then
            'FWarehouseItemsNew.loadItems()
            Me.Dispose()

        ElseIf isCreateNewProperNames2 Then
            Me.Dispose()

        Else
            Me.Dispose()
        End If
    End Sub

    Private Sub getWhProperNaming()

        properNameModel.clearParameter()
        TypeOfRequestModel.clearParameter()

        loadingPanel.Visible = True

        Dim values As New Dictionary(Of String, String)

        _initializing(cCol.forWhItem_ProperNames,
                      values, properNameModel,
                      whItemsProperNameBgWorker)


        _initializing(cCol.forTypeOfRequest,
                          values,
                          TypeOfRequestModel,
                          whItemsProperNameBgWorker)

        cBgWorkerChecker = BgWorkersCheckerFn(AddressOf SuccessfullyDone, whItemsProperNameBgWorker)


        searchUI.resetTextFields()
        searchUI.tbox.Focus()

    End Sub



    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        cSearch = txtSearch.Text


    End Sub

    Private Sub debounce_new_Tick(sender As Object, e As EventArgs) Handles debounce_new.Tick
        debounce_new.Stop()

        Dim searchResult As New List(Of PropsFields.whItems_properName_fields)
        searchResult = cResult.Where(Function(x)
                                         Dim output As String = x.item_name.ToUpper() & " " & x.item_desc.ToUpper()
                                         Return output.Contains(cSearch.ToUpper)
                                     End Function).OrderBy(Function(x) x.item_desc).ToList()

        DataGridView1.DataSource = refactorAndPreview(searchResult)

        If searchResult.Count > 0 Then
            setCustomGridview()
        End If

        loadingPanel.Visible = False


    End Sub

    Private Function refactorAndPreview(datas As List(Of PropsFields.whItems_properName_fields)) As List(Of PropsFields.whItems_properName_fields)
        Try
            refactorAndPreview = New List(Of PropsFields.whItems_properName_fields)
            If datas IsNot Nothing Then

                For Each row In datas
                    Dim _properName As New PropsFields.whItems_properName_fields
                    With _properName
                        .wh_pn_id = row.wh_pn_id
                        .item_name = row.item_name
                        .item_desc = row.item_desc
                        .units = row.units
                        .type_of_request = row.type_of_request
                        .department = row.department
                        .userLog = Utilities.getUserCompleteNameFromHrmsData(Utilities.ifBlankReplaceToZero(row.userLog))
                        .updateUserLog = Utilities.getUserCompleteNameFromHrmsData(Utilities.ifBlankReplaceToZero(row.updateUserLog))

                    End With

                    refactorAndPreview.Add(_properName)
                Next
            End If

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Private Sub setCustomGridview()

        With customGridview

            .autoSizeColumn(DataGridView1, False)

            DataGridView1.Columns(NameOf(cn.item_name)).HeaderText = cHp.ITEM_NAME
            DataGridView1.Columns(NameOf(cn.item_name)).Width = 250

            DataGridView1.Columns(NameOf(cn.item_desc)).HeaderText = cHp.ITEM_DESCRIPTION
            DataGridView1.Columns(NameOf(cn.item_desc)).Width = 250

            DataGridView1.Columns(NameOf(cn.units)).HeaderText = cHp.UNITS
            DataGridView1.Columns(NameOf(cn.units)).Width = 100

            DataGridView1.Columns(NameOf(cn.type_of_request)).HeaderText = cHp.TYPE_OF_REQUEST
            DataGridView1.Columns(NameOf(cn.type_of_request)).Width = 200

            DataGridView1.Columns(NameOf(cn.department)).HeaderText = cHp.PROVIDED_BY
            DataGridView1.Columns(NameOf(cn.department)).Width = 200

        End With

    End Sub


    Private Sub SuccessfullyDone()
        cResult = TryCast(properNameModel.cData, List(Of PropsFields.whItems_properName_fields))
        cListOfTypeOfRequest = TryCast(TypeOfRequestModel.cData, List(Of PropsFields.TypeOfRequest))

        'get the data result

        DataGridView1.DataSource = refactorAndPreview(cResult)

        If cResult.Count > 0 Then
            setCustomGridview()
            selectedRows(DataGridView1, 0, cWh_pn_id)
        End If

        'update also the main list of proper naming
        Results.cListOfProperNaming = cResult

        ''display to gridview or listview
        'displayResult()

        'done loading

        loadingPanel.Visible = False

        loadTypeOfRequestInComboBox(cmbTypeOfRequest)

    End Sub
    Private Sub loadTypeOfRequestInComboBox(cmb As ComboBox)
        Try
            'load type of request
            cmb.Items.Clear()
            Dim typeofrequestDatas As New List(Of String)

            For Each row In cListOfTypeOfRequest
                typeofrequestDatas.Add($"{row.tor_desc} - {row.tor_sub_desc}")
            Next

            cmb.Items.AddRange(typeofrequestDatas.ToArray)
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If btnSave.Text = "Save" Then
                If customMsgBox.messageYesNo("Are you sure you want to save this item?", "SUPPLY INFO:") Then
                    Dim cc As New ColumnValuesObj
                    cc.add("item_name", IIf(itemNameNewUI.ifBlankTexbox(), "", txtItemName.Text))
                    cc.add("item_desc", IIf(itemDescNewUI.ifBlankTexbox(), "", txtItemDesc.Text))
                    cc.add("units", IIf(unitsUI.ifBlankTexbox(), "", txtUnits.Text))
                    cc.add("type_of_request", cmbTypeOfRequest.Text)
                    cc.add("department", department)
                    cc.add("userLog", pub_user_id)
                    cc.add("createdAt", Date.Parse(Now))

                    cWh_pn_id = cc.insertQuery_and_return_id("dbwarehouse_items_proper_name")

#Region "add to RSDRModel | cListOfProperNames"
                    Dim _properName As New PropsFields.whItems_properName_fields
                    With _properName
                        .item_name = txtItemName.Text
                        .item_desc = txtItemDesc.Text
                        .units = txtUnits.Text
                        .type_of_request = cmbTypeOfRequest.Text
                    End With
                    FRequesitionFormForDR.getNewDrModel().addProperNamesToListOfProperNames(_properName)
#End Region

                    getWhProperNaming()
                    panelBoxClose()

                End If
            Else
                If customMsgBox.messageYesNo("Are you sure you want to update this item?", "SUPPLY INFO:") Then
                    Dim wh_pn_id As Integer = DataGridView1.SelectedRows(0).Cells(NameOf(cHp2.wh_pn_id)).Value
                    cWh_pn_id = wh_pn_id

                    Dim cc As New ColumnValuesObj
                    cc.add("item_name", txtItemName.Text)
                    cc.add("item_desc", txtItemDesc.Text)
                    cc.add("units", txtUnits.Text)
                    cc.add("type_of_request", cmbTypeOfRequest.Text)
                    cc.add("updateUserLog", pub_user_id)
                    cc.add("updatedAt", Date.Parse(Now))

                    cc.setCondition($"wh_pn_id = {wh_pn_id}")
                    cc.updateQuery("dbwarehouse_items_proper_name")

                    getWhProperNaming()
                    panelBoxClose()

                End If

            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        If isFromRequestFields2 Or
            isFromCreateWarehouseItem Or
            isFromWareHouseItemNew Then

            disableAllItemsFromContextMenu(ContextMenuStrip1)
        End If
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        If isAuthenticated(auth) Then
            If customMsg.messageYesNo("Are you sure you want to remove this data?", "SMS INFO:", MessageBoxIcon.Question) Then
                Dim deleteProperName As New ColumnValuesObj
                Dim selectedRow = DataGridView1.SelectedRows(0)

                Dim wh_pn_id As Integer = selectedRow.Cells(NameOf(cn.wh_pn_id)).Value
                With deleteProperName
                    .setCondition($"wh_pn_id = {wh_pn_id}")
                    .deleteData("dbwarehouse_items_proper_name")
                End With

                getWhProperNaming()
            End If
        End If
    End Sub

    Private Sub loadingPanel_Paint(sender As Object, e As PaintEventArgs) Handles loadingPanel.Paint

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If txtSearch.TextLength > 0 Then
            loadingPanel.Visible = True
            debounce_new.Start()
        Else
            loadingPanel.Visible = True
            cSearch = ""
            debounce_new.Start()

        End If
    End Sub



    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        With DataGridView1.SelectedRows(0)

            itemNameNewUI.resetTextFields()
            itemDescNewUI.resetTextFields()
            unitsUI.resetTextFields()
            typeOfRequestUI.resetTextFields()
            btnSave.Text = "Save"

            searchBoxLocation(DataGridView1, 0, Panel2)
            itemNameNewUI.tbox.Focus()
        End With

    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        With DataGridView1.SelectedRows(0)

            txtItemName.Text = .Cells(NameOf(cHp2.item_name)).Value
            txtItemDesc.Text = .Cells(NameOf(cHp2.item_desc)).Value
            txtUnits.Text = .Cells(NameOf(cHp2.units)).Value
            cmbTypeOfRequest.Text = .Cells(NameOf(cHp2.type_of_request)).Value
            btnSave.Text = "Update"

            searchBoxLocation(DataGridView1, 0, Panel2)
            itemNameNewUI.tbox.Focus()
        End With



    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        panelBoxClose()
    End Sub

    Private Sub panelBoxClose()
        Panel2.Visible = False
        itemNameNewUI.resetTextFields()
        itemDescNewUI.resetTextFields()
        unitsUI.resetTextFields()


    End Sub

    Private Sub DataGridView1_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView1.DoubleClick

        If isViewing Or isCreateNewProperNames Or isCreateNewProperNames2 Then
            Exit Sub
        End If

        If customMsgBox.messageYesNo("Are you sure you want to link this to selected items?", "SUPPLY INFO:") Then

            Try
                If isFromWareHouse Then
                    Dim wh_id As Integer = 0
                    For Each row As ListViewItem In FWarehouseItems.lvlItemList.SelectedItems

                        Dim wh_pn_id As Integer = DataGridView1.SelectedRows(0).Cells("wh_pn_id").Value
                        'update
                        Dim c As New Model_King_Dynamic_Update()
                        Dim cc As New ColumnValuesObj
                        cc.clearParameter()

                        cc.add("wh_pn_id", wh_pn_id)

                        c.UpdateData("dbwarehouse_items", cc.getValues(), $"wh_id = {row.Text}")
                        wh_id = row.Text
                    Next

                    customMsgBox.message("info", "Successfully updated...", "SUPPLY INFO:")
                    FWarehouseItems.linkTriggered = True
                    FWarehouseItems.cWh_id = wh_id

                    FWarehouseItems.loadWhItems()

                    Me.Dispose()

                ElseIf isFromWareHouseItemNew Then
                    Dim cn_properName As New PropsFields.whItemsFinal
                    Dim selectedRow = DataGridView1.SelectedRows(0)
                    Dim selectedRowFromWarehouseItem = FWarehouseItemsNew.DataGridView1.SelectedRows(0)

                    Dim wh_id As Integer = selectedRowFromWarehouseItem.Cells(NameOf(cn_properName.wh_id)).Value
                    Dim itemDesc = FWarehouseItemsNew.getWhItemsModel().getListOfItems().FirstOrDefault(Function(x) x.wh_id = wh_id) 'selectedRowFromWarehouseItem.Cells(NameOf(cn_properName.item_desc)).Value

                    Dim properName_info As String = selectedRow.Cells(NameOf(cn.item_name)).Value
                    Dim properName_desc As String = selectedRow.Cells(NameOf(cn.item_desc)).Value
                    Dim wh_pn_id As Integer = selectedRow.Cells(NameOf(cn.wh_pn_id)).Value

                    Dim result As Boolean = FWarehouseItemsNew.getWhItemsModel().updateProperNameFromWarehouseItem(wh_pn_id, wh_id)
                    If result Then
                        customMsg.message("info", "Successfully updated...", "SUPPLY INFO:")

                        'FWarehouseItemsNew.getWhItemsModel().setRowId = wh_id
                        'FWarehouseItemsNew.getWhItemsModel().isEdit = True
                        'FWarehouseItemsNew.getWhItemsModel().getWarehouseItems("")

                        With cn_properName
                            .item_name = $"{itemDesc?.item_name}{Utilities.withProperName(properName_info)}"
                            .item_desc = $"{itemDesc?.item_desc}{Utilities.withProperName(properName_desc)}"
                            .wh_pn_id = wh_pn_id
                        End With

                        FWarehouseItemsNew.getWhItemsModel().reloadItemsWithoutRefreshNew(wh_id,
                                                                                      NameOf(cn_properName.proper_item_desc),
                                                                                      cn_properName)

                        Me.Dispose()
                        FCreateWarehouseItemForm.txtProperName.Focus()
                    Else
                        customMsg.message("error", "Something went wrong with updating data...", "SUPPLY INFO:")
                    End If

                ElseIf isFromWareHouse_link_btn Then

                    With FWarehouseItems
                        .txtItemName.Text = DataGridView1.SelectedRows(0).Cells("item_name").Value
                        .txtItemName.ReadOnly = True

                        .txtDesc.Text = DataGridView1.SelectedRows(0).Cells("item_desc").Value
                        .txtDesc.ReadOnly = True

                        .txtUnit.Text = DataGridView1.SelectedRows(0).Cells("units").Value
                        .txtUnit.ReadOnly = True

                    End With

                    Me.Dispose()

                ElseIf isFromRequestFields Then

                    With FRequestField
                        .lblProperNaming.Text = $"{DataGridView1.SelectedRows(0).Cells("item_name").Value} - {DataGridView1.SelectedRows(0).Cells("item_desc").Value}"
                        .txtUnit.Text = DataGridView1.SelectedRows(0).Cells("units").Value
                    End With

                    Me.Dispose()

                ElseIf isFromRequestFields2 Then
                    With FCreateRSForm
                        Dim row = DataGridView1.SelectedRows(0)
                        .txtProperName.Text = $"{row.Cells(NameOf(cn.item_name)).Value} - {row.Cells(NameOf(cn.item_desc)).Value}"
                        .txtUnits.Text = row.Cells(NameOf(cn.units)).Value

                        .createRsStorage.wh_pn_id_for_rs = row.Cells(NameOf(cn.wh_pn_id)).Value
                    End With

                    Me.Dispose()

                ElseIf isFromRequisitionFormEdit Then

                    Dim wh_pn_id As Integer = DataGridView1.SelectedRows(0).Cells("wh_pn_id").Value
                    Dim rs_id As Integer = FRequistionForm.lvlrequisitionlist.SelectedItems(0).Text

                    'update
                    Dim cc As New ColumnValuesObj
                    cc.clearParameter()

                    cc.add("wh_pn_id", wh_pn_id)
                    cc.setCondition($"rs_id = {rs_id}")
                    cc.updateQuery("dbrequisition_slip")

                    'c.UpdateData("dbrequisition_slip", cc.getValues(), $"rs_id = {rs_id}")

                    FRequistionForm.btnSearch.PerformClick()

                    Me.Dispose()

                ElseIf isFromCreateWarehouseItem Then
                    With FCreateWarehouseItemForm.whitemStorage
                        .wh_pn_id = DataGridView1.SelectedRows(0).Cells(NameOf(cn.wh_pn_id)).Value
                        .item_name = DataGridView1.SelectedRows(0).Cells(NameOf(cn.item_name)).Value
                        .item_desc = DataGridView1.SelectedRows(0).Cells(NameOf(cn.item_desc)).Value

                        FCreateWarehouseItemForm.txtProperName.Text = DataGridView1.SelectedRows(0).Cells(NameOf(cn.item_desc)).Value
                    End With
                    Me.Dispose()

                End If
            Catch ex As Exception
                customMsgBox.ErrorMessage(ex)
            End Try


        End If
    End Sub

    Private Sub FLinkToProperNaming_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Me.Dispose()
    End Sub
End Class