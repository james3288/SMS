
Imports System.Windows.Documents
Imports Microsoft.Office.Interop.Excel
Imports SUPPLY.Interfaces
Imports SUPPLY.KeyPerformanceIndicatorModel


Public Class FWarehouseAreaNew
    Private whAreaModel As New WarehouseAreaModel

    Private customDgv As New CustomGridview

    Public whAreaUI, whAreaOldUI, inchargeUI, locationUI, searchUI, whOptionUI, searchInchargeUI As New class_placeholder5
    Private cn As New PropsFields.whArea_stockpile_props_fields
    Public charge_to_id As Integer
    Private cSearch As String
    Private isEdit, isEdit2 As Boolean
    Public cId As Integer
    Public isFromWarehouseItem,
        isEditItemFromWarehouseItemNew,
        isEditQuarryFromWarehouseItemNew,
        isFromCreateWarehouseItem_whArea,
        isFromCreateWarehouseItem_quarry,
        isFromCreateDeliveryReceipt_addRecepient As Boolean
    Public cListOfPendingDr As New List(Of PropsFields.create_dr_props_fields)
    Public cDgv As New DataGridView
    Public forDrWithoutRs As Integer

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Const CS_DROPSHADOW As Integer = &H20000
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ClassStyle = cp.ClassStyle Or CS_DROPSHADOW
            Return cp
        End Get
    End Property


    Private Sub CreateNewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateNewToolStripMenuItem.Click
        showHidePanel(True)
        'For Each ctr As Control In Me.Controls
        '    If TypeOf ctr Is Panel Then

        '        Dim pnl As Panel = CType(ctr, Panel)

        '        If pnl.Name = Panel3.Name Then
        '            For Each ctr2 As Control In Panel3.Controls
        '                If ctr2.Name = Panel6.Name Then
        '                    ctr2.Visible = True
        '                Else
        '                    ctr2.Enabled = False
        '                End If
        '            Next
        '        Else
        '            ctr.Enabled = False
        '        End If

        '    Else
        '        ctr.Enabled = False
        '    End If
        'Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        showHidePanel(False)
    End Sub

    Private Sub cmbWarehouseOptions_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbWarehouseOptions.SelectedIndexChanged

        If cmbWarehouseOptions.Text.ToUpper() = cWarehouseOption.WAREHOUSE.ToUpper() Then
            txtWharea.Enabled = False
            txtWhAreaOld.Focus()

            If Not isEdit = True Then
                FCharge_To.btnSearch.Enabled = False
                FCharge_To.txt_Search.Enabled = False
                FCharge_To.forSaveWarehouseProperNameNew = True
                FCharge_To.ShowDialog()
            Else
                isEdit = False
            End If

        Else
            txtWharea.Enabled = False
            txtWhAreaOld.Enabled = True
            txtWhAreaOld.Focus()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Dispose()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub RemoveProperWarehouseAreaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveProperWarehouseAreaToolStripMenuItem.Click
        Try
            Dim selectedRow = DataGridView1.SelectedRows(0)
            Dim wh_area_id As Integer = selectedRow.Cells(NameOf(cn.wh_area_id)).Value
            Dim whArea As String = selectedRow.Cells(NameOf(cn.wh_area)).Value

            Dim result As Boolean = whAreaModel.removeLinkWarehouseArea(wh_area_id)

            Dim value As New PropsFields.whArea_stockpile_props_fields
            value.wh_area_proper_name = ""
            value.wh_options = ""
            value.wh_area = whArea
            value.wh_incharge = ""
            If result Then
                whAreaModel.reloadItemsWithoutRefreshNew(wh_area_id,
                                                         "remove_proper_wharea",
                                                         value,
                                                         0)
            Else
                customMsg.message("error", "there is something wrong in removing proper warehouse name!", "SMS INFO:")
            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub btnSaveCharges_Click(sender As Object, e As EventArgs) Handles btnSaveCharges.Click
        Dim checkIfWarehouseExist As New List(Of PropsFields.whArea_stockpile_props_fields)

#Region "FILTER"
        If cmbWarehouseOptions.Text.ToUpper() = cWarehouseOption.WAREHOUSE.ToUpper() Then
            If charge_to_id = 0 Then
                customMsg.message("error", "You must select a proper warehouse name first to proceed saving...", "SUPPLY INFO:")
                Exit Sub
            Else
                checkIfWarehouseExist = whAreaModel.getClistOfWhArea().Where(Function(x)
                                                                                 Return x.wh_area_proper_name.ToUpper() = txtWharea.Text.ToUpper()
                                                                             End Function).ToList()

                If checkIfWarehouseExist.Count > 0 Then
                    'If Not customMsg.messageYesNo("This proper warehouse name already exist, do you still want to proceed?...", "SUPPLY INFO:", MessageBoxIcon.Question) Then
                    '    Exit Sub
                    'End If
                    customMsg.message("error", "This proper warehouse name already exist", "SMS INFO:")
                    Exit Sub
                End If
            End If
        Else
            charge_to_id = 0
        End If
#End Region

        Dim createWhArea As New PropsFields.whArea_stockpile_props_fields

        With createWhArea
            .wh_area = txtWhAreaOld.Text
            .wh_location = txtWarehouseLoc.Text
            .wh_options = cmbWarehouseOptions.Text

            Dim wh_area_id As Integer = DataGridView1.SelectedRows(0).Cells(NameOf(cn.wh_area_id)).Value
            If isEdit2 Then

                If customMsg.messageYesNo("Are you sure you want to update this data?", "SUPPLY INFO:", MessageBoxIcon.Question) Then
                    Dim result As Boolean = whAreaModel.update(createWhArea,
                             charge_to_id,
                             wh_area_id)

                    If result = True Then
                        customMsg.message("info", "Successfully Updated...", "SUPPLY INFO:")


                        Dim values As New PropsFields.whArea_stockpile_props_fields

                        values.wh_options = cmbWarehouseOptions.Text
                        values.wh_area = txtWhAreaOld.Text
                        values.wh_area_proper_name = txtWharea.Text

                        whAreaModel.reloadItemsWithoutRefreshNew(wh_area_id, "add_proper_wharea", values)

                        isEdit = False
                        btnSaveCharges.Text = "Save"
                    Else
                        customMsg.message("error", "There is something wrong when saving datas..", "SUPPLY INFO:")
                    End If
                End If

            Else
                Dim result As Integer = whAreaModel.saved(createWhArea, charge_to_id)

                If result > 0 Then
                    customMsg.message("info", "Successfully Saved...", "SUPPLY INFO:")
                    With whAreaModel
                        .setRowFocus = True
                        .setRowId = result
                        .getWareHouseArea()
                    End With
                Else
                    customMsg.message("error", "There is something wrong when saving datas..", "SUPPLY INFO:")
                End If
            End If

        End With

    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        If isEditItemFromWarehouseItemNew Or
            isEditQuarryFromWarehouseItemNew Or
            isFromCreateWarehouseItem_whArea Or
            isFromCreateWarehouseItem_quarry Or
            isFromCreateDeliveryReceipt_addRecepient Then

            disableAllItemsFromContextMenu(ContextMenuStrip1)
        End If
    End Sub

    Private Sub RemoveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveToolStripMenuItem.Click
        Dim id As Integer = DataGridView1.SelectedRows(0).Cells(NameOf(cn.wh_area_id)).Value

        If customMsg.messageYesNo("Are you sure you want to remove this data?", "SUPPLY INFO:", MessageBoxIcon.Information) Then
            If isAuthenticated(auth) Then
                whAreaModel.delete(id)
                whAreaModel.getWareHouseArea()
            End If
        End If

    End Sub

    Private Sub debounce_new_Tick(sender As Object, e As EventArgs) Handles debounce_new.Tick
        debounce_new.Stop()

        whAreaModel.searchWarehouseArea(cSearch)

        loadingPanel.Visible = False
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged

        cSearch = IIf(searchUI.placeHolder = txtSearch.Text, "", searchUI.tbox.Text)

    End Sub

    Private customMsg As New customMessageBox

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        Dim id As Integer = DataGridView1.SelectedRows(0).Cells(NameOf(cn.wh_area_id)).Value
        isEdit2 = True
        btnSaveCharges.Text = "Update"

        Dim data = whAreaModel.getClistOfWhArea().Where(Function(x) x.wh_area_id = id).ToList()

        If data.Count > 0 Then
            With data(0)
                txtWharea.Text = .wh_area_proper_name
                whAreaUI.resetBgColor()

                txtWhAreaOld.Text = .wh_area
                whAreaOldUI.resetBgColor()

                txtWarehouseLoc.Text = .wh_location
                locationUI.resetBgColor()
                txtWarehouseLoc.Focus()

                cmbWarehouseOptions.Text = .wh_options
                whOptionUI.resetBgColor()

                charge_to_id = whAreaModel.getCharges_id(.wh_area_proper_name)

                showHidePanel(True)

            End With
        End If
    End Sub

    Public ReadOnly Property getWhAreaModel As WarehouseAreaModel
        Get
            Return whAreaModel
        End Get
    End Property
    Private Sub AddInchargeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddInchargeToolStripMenuItem.Click


        If DataGridView1.SelectedRows(0).Cells(NameOf(cn.wh_options)).Value = cWarehouseOption.WAREHOUSE Or
            DataGridView1.SelectedRows(0).Cells(NameOf(cn.wh_options)).Value = cWarehouseOption.STOCKPILE Or
            DataGridView1.SelectedRows(0).Cells(NameOf(cn.wh_options)).Value = cWarehouseOption.QUARRY Then

            ListOfEmployeesForm.whAreaId = DataGridView1.SelectedRows(0).Cells(NameOf(cn.wh_area_id)).Value
            ListOfEmployeesForm.ShowDialog()
        Else
            customMsg.message("error", "this function is only applicable in warehouse area...", "SUPPLY INFO:")

        End If


    End Sub



    Private Sub FWarehouseAreaNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        customDgv.customDatagridview(DataGridView1, "#011526")

        whAreaModel.initialize(DataGridView1)
        whAreaModel.getWareHouseArea("")

        'UI
        whAreaUI.king_placeholder_textbox("Warehouse Area Proper Name...",
                                          txtWharea,
                                          Nothing,
                                          Panel6,
                                          My.Resources.received,,
                                          whAreaUI.cCustomColor.Custom1)

        whAreaOldUI.king_placeholder_textbox("Warehouse Area/Stockpile/Quarry...",
                                             txtWhAreaOld,
                                             Nothing,
                                             Panel6,
                                             My.Resources.received,,
                                             whAreaOldUI.cCustomColor.Custom1)

        'inchargeUI.king_placeholder_textbox("Warehouse Area Incharge...", txtWhIncharge, Nothing, Panel3, My.Resources.received)
        locationUI.king_placeholder_textbox("Locaiton...",
                                            txtWarehouseLoc,
                                            Nothing,
                                            Panel6,
                                            My.Resources.received,,
                                            locationUI.cCustomColor.Custom1)

        whOptionUI.king_placeholder_combobox("Select Option",
                                             cmbWarehouseOptions,
                                             Nothing,
                                             Panel6,
                                             My.Resources.received,,
                                             whOptionUI.cCustomColor.Custom1)

        searchUI.king_placeholder_textbox("Search here...",
                                          txtSearch,
                                          Nothing,
                                          Panel2,
                                          My.Resources.received,,
                                          searchUI.cCustomColor.Custom1)

        whOptionUI.cBox.Items.Clear()
        whOptionUI.cBox.Items.Add(cWarehouseOption.QUARRY)
        whOptionUI.cBox.Items.Add(cWarehouseOption.STOCKPILE)
        whOptionUI.cBox.Items.Add(cWarehouseOption.WAREHOUSE)
        'whOptionUI.cBox.Items.Add(cWarehouseOption.ON_SITE_STORAGE)

        'movable panel
        Dim myPanel As New MovablePanel

        myPanel.addPanel(Panel1)
        myPanel.addPanel(Panel4)

        myPanel.initializeForm(Me)
        myPanel.addPanelEventHandler()

    End Sub
    Private Sub showHidePanel(value As Boolean)
        For Each ctr As Control In Me.Controls
            If TypeOf ctr Is Panel Then

                Dim pnl As Panel = CType(ctr, Panel)

                If pnl.Name = Panel3.Name Then
                    For Each ctr2 As Control In Panel3.Controls
                        If ctr2.Name = Panel6.Name Then
                            ctr2.Visible = value
                        Else
                            ctr2.Enabled = Not value
                        End If
                    Next
                Else
                    ctr.Enabled = Not value
                End If

            Else
                ctr.Enabled = Not value
            End If
        Next

    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = 17 Then
            Exit Sub
        End If

        If txtSearch.TextLength > 0 Then
            loadingPanel.Visible = True
            debounce_new.Start()
        Else
            loadingPanel.Visible = True
            cSearch = ""
            debounce_new.Start()

        End If
    End Sub

    Private Sub DataGridView1_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView1.DoubleClick

        Try
            If isEditItemFromWarehouseItemNew Then

                If customMsg.messageYesNo("Are you sure you want to update warehouse area / stockpile area to this selected item?", "SUPPLY INFO:") Then
                    Dim cn_whAreaStockpile As New PropsFields.whItemsFinal
                    Dim selectedRow = DataGridView1.SelectedRows(0)

                    Dim wh_id As Integer = FWarehouseItemsNew.DataGridView1.SelectedRows(0).Cells(NameOf(cn_whAreaStockpile.wh_id)).Value
                    Dim wh_area_id As Integer = selectedRow.Cells(NameOf(cn.wh_area_id)).Value
                    Dim warehouse_area_properName As String = selectedRow.Cells(NameOf(cn.wh_area_proper_name)).Value
                    Dim warehouse_area As String = selectedRow.Cells(NameOf(cn.wh_area)).Value
                    Dim incharge As String = selectedRow.Cells(NameOf(cn.wh_incharge)).Value
                    Dim warehouseOption As String = selectedRow.Cells(NameOf(cn.wh_options)).Value
                    Dim division As String = FWarehouseItemsNew.DataGridView1.SelectedRows(0).Cells(NameOf(cn_whAreaStockpile.division)).Value

                    If warehouseOption = cWarehouseOption.WAREHOUSE Or
                        warehouseOption = cWarehouseOption.STOCKPILE Then

                        If whAreaModel.updateWarehouseAreaStockpileFromWarehouseItem(wh_area_id, wh_id) Then

                            With cn_whAreaStockpile
                                .wh_area_id = wh_area_id
                                .warehouse_area = refactorWarehouseArea(warehouse_area, division, warehouse_area_properName)
                                .incharge = incharge
                                .whArea_category = Utilities.convertWarehouseToWarehouseStockpile(warehouseOption)
                            End With

                            FWarehouseItemsNew.getWhItemsModel().reloadItemsWithoutRefreshNew(wh_id,
                                                                                              NameOf(cn_whAreaStockpile.wh_area_id),
                                                                                              cn_whAreaStockpile)

                            Me.Dispose()
                        Else
                            customMsg.message("error", "something went wrong with ware area / stockpile area update...", "SUPPLY INFO:")
                            Exit Sub
                        End If
                    Else
                        customMsg.message("error", "this warehouse area / stockpile area is not yet set for category", "SUPPLY INFO:")
                    End If

                End If

            ElseIf isEditQuarryFromWarehouseItemNew Then

                If customMsg.messageYesNo("Are you sure you want to update quarry code area to this selected item?", "SUPPLY INFO:") Then
                    Dim cn_quarry As New PropsFields.whItemsFinal
                    Dim selectedRow = DataGridView1.SelectedRows(0)

                    Dim wh_id As Integer = FWarehouseItemsNew.DataGridView1.SelectedRows(0).Cells("wh_id").Value
                    Dim wh_area_id As Integer = selectedRow.Cells(NameOf(cn.wh_area_id)).Value
                    Dim quarry_area As String = selectedRow.Cells(NameOf(cn.wh_area)).Value

                    Dim warehouseOption As String = selectedRow.Cells(NameOf(cn.wh_options)).Value

                    If warehouseOption = cWarehouseOption.QUARRY Then
                        If whAreaModel.updateQuarryFromWarehouseItem(wh_area_id, wh_id) Then

                            Dim value As New PropsFields.whItemsFinal
                            With value
                                .wh_area_id = wh_area_id
                                .quarry = quarry_area
                            End With

                            'FWarehouseItemsNew.getWhItemsModel().reloadItemsWithoutRefresh(wh_id, NameOf(cn_quarry.quarry), quarry_area)
                            FWarehouseItemsNew.getWhItemsModel().reloadItemsWithoutRefreshNew(wh_id, NameOf(cn_quarry.quarry), value)
                            Me.Dispose()
                        Else
                            customMsg.message("error", "something went wrong with warehouse area / stockpile area update...", "SUPPLY INFO:")
                            Exit Sub
                        End If
                    Else
                        customMsg.message("error", "this transaction is intended to update quarry code!", "SUPPLY INFO:")
                    End If

                End If

            ElseIf isFromCreateWarehouseItem_whArea Then

                With FCreateWarehouseItemForm.whitemStorage
                    Dim warehouseOption As String = DataGridView1.SelectedRows(0).Cells(NameOf(cn.wh_options)).Value

                    If warehouseOption = cWarehouseOption.WAREHOUSE Then
                        .wh_area_id = DataGridView1.SelectedRows(0).Cells(NameOf(cn.wh_area_id)).Value


                        FCreateWarehouseItemForm.txtWhAreaQuarryAreaProjectSite.Text = DataGridView1.SelectedRows(0).Cells(NameOf(cn.wh_area_proper_name)).Value
                        .whArea_category = cWarehouseOption.WAREHOUSE
                        FCreateWarehouseItemForm.txtWhAreaQuarryAreaProjectSite.Focus()

                        Me.Dispose()

                    ElseIf warehouseOption = cWarehouseOption.STOCKPILE Then
                        .wh_area_id = DataGridView1.SelectedRows(0).Cells(NameOf(cn.wh_area_id)).Value
                        FCreateWarehouseItemForm.txtWhAreaQuarryAreaProjectSite.Text = DataGridView1.SelectedRows(0).Cells(NameOf(cn.wh_area)).Value
                        .whArea_category = cWarehouseOption.WAREHOUSE
                        FCreateWarehouseItemForm.txtWhAreaQuarryAreaProjectSite.Focus()

                        Me.Dispose()
                    Else
                        customMsg.message("error", "this warehouse area / stockpile area is not yet set for stockpile options", "SUPPLY INFO:")
                    End If

                End With

            ElseIf isFromCreateWarehouseItem_quarry Then

                With FCreateWarehouseItemForm.whitemStorage
                    Dim warehouseOption As String = DataGridView1.SelectedRows(0).Cells(NameOf(cn.wh_options)).Value

                    If warehouseOption = cWarehouseOption.QUARRY Then
                        .quarry_id = DataGridView1.SelectedRows(0).Cells(NameOf(cn.wh_area_id)).Value
                        FCreateWarehouseItemForm.txtQuarry.Text = DataGridView1.SelectedRows(0).Cells(NameOf(cn.wh_area)).Value
                        '.whArea_category = cWarehouseOption.WAREHOUSE
                        FCreateWarehouseItemForm.txtQuarry.Focus()

                        Me.Dispose()
                    Else
                        customMsg.message("error", "this warehouse area / stockpile area is not yet set for quarry options", "SUPPLY INFO:")
                    End If

                End With

            ElseIf isFromCreateDeliveryReceipt_addRecepient Then

                Dim id As Integer = cId
                Dim aggregatesTransaction As New AggregatesTransactionFlow

                If cListOfPendingDr.Count > 0 Then
                    Dim selectedRow = DataGridView1.SelectedRows(0)

                    If selectedRow.Cells(NameOf(cn.wh_options)).Value = "" Then
                        customMsg.message("error", "you are not allowed to select this area if the category is blank!", "SMS INFO:")
                        Exit Sub
                    End If

                    Dim index As Integer = cListOfPendingDr.FindIndex(Function(x) x.id = id)
                    Dim requestor As String = selectedRow.Cells(NameOf(cn.wh_area)).Value

                    With cListOfPendingDr(index)
                        .recepient_id = DataGridView1.SelectedRows(0).Cells(NameOf(cn.wh_area_id)).Value
                        .recepient_category = "WAREHOUSE"
                        .recepient_for_screening = requestor

                        'for pricing
                        If forDrWithoutRs = DROptions.in_with_rs Or
                            forDrWithoutRs = DROptions.others_with_rs Then

                            '.price = FRequistionForm.GetCDR.getSpecificPrice(.stockpile_recepient, lvList.SelectedItems(0).SubItems(1).Text)
                            FRequistionForm.GetCDR.lblRequestor.Text = aggregatesTransaction.requestorLabel(requestor)

                        Else
                            If forDrWithoutRs = DROptions.out_without_rs Then
                                '.price = FCreateDeliveryReceipt.getSpecificPrice(lvList.SelectedItems(0).SubItems(1).Text, .stockpile_source)
                                FCreateDeliveryReceipt.lblRequestor.Text = aggregatesTransaction.requestorLabel(requestor)
                                .price = FCreateDeliveryReceipt.getSpecificPrice(requestor, .stockpile_source)

                            ElseIf forDrWithoutRs = DROptions.others_without_rs Or
                                forDrWithoutRs = DROptions.in_without_rs Then
                                Dim warehouseItemSelectedRow = FWarehouseItemsNew.DataGridView1.SelectedRows(0)
                                Dim whCn = FWarehouseItemsNew.cn
                                Dim drRequestor = warehouseItemSelectedRow.Cells(NameOf(whCn.warehouse_area)).Value

                                '.price = FCreateDeliveryReceipt.getSpecificPrice(.stockpile_recepient, lvList.SelectedItems(0).SubItems(1).Text)
                                .price = FCreateDeliveryReceipt.getSpecificPrice(drRequestor, selectedRow.Cells(NameOf(cn.wh_area)).Value)

                                FCreateDeliveryReceipt.lblQuarry.Text = aggregatesTransaction.quarryLabel("N/A")
                                FCreateDeliveryReceipt.lblStockpile.Text = aggregatesTransaction.sourceLabel(selectedRow.Cells(NameOf(cn.wh_area)).Value)

                            End If

                        End If

                    End With

                    cDgv.Refresh()
                End If

                Me.Dispose()
            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

    End Sub

    Private Function refactorWarehouseArea(whArea As String,
                                           division As String,
                                           Optional warehouse_area_properName As String = "") As String
        Try
            If division = cDivision.WAREHOUSING_AND_SUPPLY Then
                refactorWarehouseArea = $"{whArea} ({warehouse_area_properName})"
            Else
                refactorWarehouseArea = $"{whArea}"
            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

End Class