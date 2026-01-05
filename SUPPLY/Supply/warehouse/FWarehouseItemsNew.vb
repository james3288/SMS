Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports Microsoft.Office.Interop.Excel
Imports SUPPLY.KeyPerformanceIndicatorModel

Public Class FWarehouseItemsNew

    Private whItemsModel As New WarehouseItemModel
    Private customMsg As New customMessageBox
    Private customDgv As New CustomGridview
    Private cSearch, cSearchByString As String
    Private searchUI, searchByUI As New class_placeholder5
    Private cSearchBy As New SearchByEnum
    Public cn As New PropsFields.whItemsFinal
    Public AggregatesPricesForm As New FAggregatesPrices
    Public fromRequesitionFormForDR As Boolean
    Public publicId As Integer
    Dim model1 As New KeyPerformanceIndicatorModel()
    Public isCreateAggregatesWithoutRs As Boolean

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Const CS_DROPSHADOW As Integer = &H20000
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ClassStyle = cp.ClassStyle Or CS_DROPSHADOW
            Return cp
        End Get
    End Property

    Public ReadOnly Property getWhItemsModel() As WarehouseItemModel
        Get
            Return whItemsModel
        End Get
    End Property

    Private Sub FWarehouseItemsNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        cmbSearchBy.Items.Add(cSearchBy.SEARCH_BY_ITEM_NAME)
        cmbSearchBy.Items.Add(cSearchBy.SEARCH_BY_ITEM_DESC)
        cmbSearchBy.Items.Add(cSearchBy.SEARCH_BY_PROPER_NAMING)
        cmbSearchBy.Items.Add(cSearchBy.SEARCH_BY_WAREHOUSE_AREA)
        cmbSearchBy.Items.Add(cSearchBy.SEARCH_BY_WAREHOUSE_INCHARGE)
        cmbSearchBy.Items.Add(cSearchBy.SEARCH_BY_KPI)
        cmbSearchBy.Items.Add(cSearchBy.SEARCH_BY_WH_ID)
        cmbSearchBy.Items.Add(cSearchBy.CLASSIFICATION)

        displayKpiCategory()

        Dim fontFamily As New Dictionary(Of String, String)
        fontFamily.Add("fontName", cFontsFamily.bombardier)
        fontFamily.Add("fontSize", 12)


        searchUI.king_placeholder_textbox("Search here...",
                                          txtSearch,
                                          Nothing,
                                          Panel5,
                                          My.Resources.received,
                                          False,,,,,
                                          fontFamily)

        searchByUI.king_placeholder_combobox("Search by...",
                                             cmbSearchBy,
                                             Nothing,
                                             Panel5,
                                             My.Resources.received,,,,
                                             fontFamily)


        customDgv.customDatagridview(DataGridView1, "#011526", 31)
        whItemsModel.initialize(DataGridView1, loadingPanel)

        If whItemsModel.isItemChecked Then
            cmbSearchBy.Enabled = False
            txtSearch.Enabled = False
        End If

        'movable panel
        If whItemsModel.isItemChecked Or
            isCreateAggregatesWithoutRs Then

            Dim myPanel As New MovablePanel

            myPanel.addPanel(Panel1)
            myPanel.addPanel(Panel4)

            myPanel.initializeForm(Me)
            myPanel.addPanelEventHandler()
        End If

        loadItems()

        'for aggregates without rs transaction
        If isCreateAggregatesWithoutRs Then
            btnListOfWhItem.Enabled = False
            btnAddProperName.Enabled = False
            btnWhStockpileQuarryArea.Enabled = False
        End If


    End Sub

    Public Sub loadItems()
        Try
            whItemsModel.getWarehouseItems("")

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub debounce_new_Tick(sender As Object, e As EventArgs) Handles debounce_new.Tick
        debounce_new.Stop()

        If cSearch.Length > 3 Then
            whItemsModel.searchWarehouseArea(cSearch, cSearchByString)
        Else
            If cmbSearchBy.Text = cSearchBy.SEARCH_BY_PROPER_NAMING Then
                whItemsModel.searchWarehouseArea(cSearch, cSearchByString)
            End If
        End If

        loadingPanel.Visible = False
    End Sub

    Private Sub EditWarehouseAreaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditWarehouseAreaToolStripMenuItem.Click

        If customMsg.messageYesNo("YES: for Stockpile/Warehouse Area" & vbCrLf & "NO: for Project Sites and Others", "SUPPLY INFO:") Then
            If Not isLoading() Then
                FWarehouseAreaNew.isEditQuarryFromWarehouseItemNew = False
                FWarehouseAreaNew.isEditItemFromWarehouseItemNew = True
                FWarehouseAreaNew.ShowDialog()
            End If
        Else
            With FCharge_To
                If Not isLoading() Then
                    .forWhItemsProjectSiteAndOthers = True
                    .ShowDialog()
                End If
            End With
        End If

    End Sub

    Private Sub EditProperNamingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditProperNamingToolStripMenuItem.Click
        If Not isLoading() Then
            FLinkToProperNaming.isFromWareHouseItemNew = True
            FLinkToProperNaming.ShowDialog()
        End If

    End Sub

    Private Sub EditQuarryCodeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditQuarryCodeToolStripMenuItem.Click
        If DataGridView1.SelectedRows(0).Cells(NameOf(cn.division)).Value = cDivision.CRUSHING_AND_HAULING Then
            If Not isLoading() Then
                FWarehouseAreaNew.isEditItemFromWarehouseItemNew = False
                FWarehouseAreaNew.isEditQuarryFromWarehouseItemNew = True
                FWarehouseAreaNew.ShowDialog()
            End If
        Else
            customMsg.message("error", "quarry code is not applicable in warehousing!", "SUPPLY INFO:")
        End If

    End Sub

    Private Sub EditKPIToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditKPIToolStripMenuItem.Click
        'If Not isLoading() Then
        '    FKeyPerformanceIndicator.isFromWareHouseNew = True
        '    FKeyPerformanceIndicator.ShowDialog()
        'End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Dispose()
    End Sub

    Private Sub CreateNewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateNewToolStripMenuItem.Click
        If Not isLoading() Then
            FCreateWarehouseItemForm.ShowDialog()
        End If

    End Sub

    Private Sub EditToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem1.Click
        If Not isLoading() Then
            With FCreateWarehouseItemForm
                .isEdit = True
                .txtProperName.Enabled = False
                .txtQuarry.Enabled = False
                .txtWhAreaQuarryAreaProjectSite.Enabled = False
                .txtQuarry.Enabled = False
                .txtKPI.Enabled = False

                .ShowDialog()
            End With

        End If

    End Sub

    Private Sub RemoveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveToolStripMenuItem.Click
        'customMsg.message("error", "This feature is not applicable at this momment...", "SUPPLY INFO")
        If customMsg.messageYesNo("Are you sure you want to remove this item?", "SUPPLY INFO:", MessageBoxIcon.Question) Then

            If isAuthenticated(auth) Then
                deleteItem()
            End If

        End If
    End Sub
    Private Sub deleteItem()
        Try
            Dim selectedRow = DataGridView1.SelectedRows(0)
            Dim wh_id As Integer = selectedRow.Cells(NameOf(cn.wh_id)).Value

            Dim deleteItem As New deleteWarehouseItemServices
            Dim removeResult As Boolean = deleteItem.Execute(wh_id)

            If removeResult Then
                customMsg.message("info", "item successfully removed...", "SUPPLY INFO:")

                If DataGridView1.CurrentRow IsNot Nothing Then

                    whItemsModel.isRemoved = True
                    'whItemsModel.initialize_whItemsOnly(cSearchByString, cSearch)
                    removeFromListOfWhItems(wh_id)
                End If
            Else
                customMsg.message("error", "there is something wrong with deleting items...", "SUPPLY INFO:")
            End If

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
    Private Sub removeFromListOfWhItems(wh_id As Integer)
        Try

            Dim items = whItemsModel.getFinalDatas()
            Dim removeData = items.FirstOrDefault(Function(x) x.wh_id = wh_id)
            items.Remove(removeData)

            Dim items2 = whItemsModel.getListOfItems()
            Dim removeData2 = items2.FirstOrDefault(Function(x) x.wh_id = wh_id)
            items2.Remove(removeData2)

            Dim itemsNew = whItemsModel.getFinalDatas()
            itemsNew = items

            DataGridView1.DataSource = Nothing
            DataGridView1.DataSource = items

            whItemsModel.customizeDagrid()
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged

        cSearch = IIf(searchUI.placeHolder = txtSearch.Text, "", searchUI.tbox.Text)
        cSearchByString = cmbSearchBy.Text

    End Sub

    Private Sub ViewStockCardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewStockCardToolStripMenuItem.Click

        With FStockCard3
            Dim selectedRow = DataGridView1.SelectedRows(0)

            If selectedRow.Cells(NameOf(cn.division)).Value = cDivision.WAREHOUSING_AND_SUPPLY Then
                Dim wh_id As Integer = selectedRow.Cells(NameOf(cn.wh_id)).Value
                Dim data = whItemsModel.getListOfItemsFinal().FirstOrDefault(Function(x) x.wh_id = wh_id) 'Results.cResult.Where(Function(x) x.wh_id = wh_id).ToList()

                .loadStockCard(wh_id)
                .Text = $"{data?.item_name} - {data?.item_desc} ({ data?.warehouse_area })"
                .ShowDialog()

            Else
                'customMsg.message("error", "this transaction is for warehousing and supply only", "SMS INFO:")
                Dim wh_id As Integer = selectedRow.Cells(NameOf(cn.wh_id)).Value

                With FStockCard
                    .lblitem_name.Text = "waiting..."
                    .lbl_location.Text = "waiting..."
                    .lbl_status.Visible = False

                    .FlowLayoutPanel1.Visible = False

                    .searchAggregatesByWhId(wh_id, Date.Parse("2001-01-01"), Date.Parse(Now))
                    .Show()
                End With
            End If



        End With
    End Sub

    Private Sub EditZoningPriceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditZoningPriceToolStripMenuItem.Click
        Try

            Dim selectedRow = DataGridView1.SelectedRows(0)

            If selectedRow.Cells(NameOf(cn.division)).Value = cDivision.CRUSHING_AND_HAULING Then
                'Dim selected As ListViewItem = lvlItemList.SelectedItems(0)
                Dim wh_id As Integer = selectedRow.Cells(NameOf(cn.wh_id)).Value
                Dim itemDesc As String = selectedRow.Cells(NameOf(cn.item_desc)).Value

                AggregatesPricesForm = New FAggregatesPrices(wh_id)
                With AggregatesPricesForm
                    .Label2.Text = $"{itemDesc}"
                    .ShowDialog()
                End With

            Else
                customMsg.message("error", "this transaction is not applicable in warehousing...", "SUPPLY INFO:")
            End If


        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub RemoveWarehouseAreaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveWarehouseAreaToolStripMenuItem.Click
        Try
            Dim wh_id As Integer = DataGridView1.SelectedRows(0).Cells(NameOf(cn.wh_id)).Value

            Dim result As Boolean = whItemsModel.removeWarehouseArea(wh_id)
            If result Then
                'whItemsModel.isUpdate = True
                'whItemsModel.setRowId = wh_id
                'whItemsModel.getWarehouseItems("")
                Dim emptyWhItem As New PropsFields.whItemsFinal
                With emptyWhItem
                    .whArea_category = ""
                    .wh_area_id = 0
                    .warehouse_area = ""
                    .incharge = ""
                End With

                whItemsModel.reloadItemsWithoutRefreshNew(wh_id,
                                                            NameOf(cn.wh_area_id),
                                                            emptyWhItem)
            Else
                customMsg.message("error", "Something went by updating warehouse area / stockpile", "SUPPLY INFO:")
            End If


        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub RemoveQuarryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveQuarryToolStripMenuItem.Click
        Try
            Dim wh_id As Integer = DataGridView1.SelectedRows(0).Cells(NameOf(cn.wh_id)).Value

            Dim result As Boolean = whItemsModel.removeQuarry(wh_id)
            If result Then
                whItemsModel.isUpdate = True
                whItemsModel.setRowId = wh_id

                Dim value As New PropsFields.whItemsFinal
                With value
                    .wh_area_id = 0
                    .quarry = ""
                End With

                'FWarehouseItemsNew.getWhItemsModel().reloadItemsWithoutRefresh(wh_id, NameOf(cn_quarry.quarry), quarry_area)
                getWhItemsModel().reloadItemsWithoutRefreshNew(wh_id, NameOf(cn.quarry), value)
            Else
                customMsg.message("error", "Something went by updating quarry", "SUPPLY INFO:")
            End If


        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        Try
            If e.KeyCode = 17 Then
                Exit Sub
            End If

            If e.KeyCode = Keys.Enter Then
                btnSearch.PerformClick()
            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

        'If txtSearch.TextLength > 0 Then
        '    loadingPanel.Visible = True
        '    debounce_new.Start()
        'Else
        '    loadingPanel.Visible = True
        '    cSearch = ""
        '    debounce_new.Start()

        'End If
    End Sub

    Private Function isLoading() As Boolean

        If loadingPanel.Visible = True Then
            customMsg.message("error", "please wait for data initialization...", "SUPPLY INFO:")
            Return True
        End If

    End Function

    Public Sub view_ListOfWarehouseItems()
        Dim dt As New System.Data.DataTable()

        With dt
            .Columns.Add("item")
            .Columns.Add("classification")
            .Columns.Add("specLocation")
        End With

        For i = 0 To DataGridView1.Rows.Count - 1
            dt.Rows.Add(DataGridView1.Rows(i).Cells(NameOf(cn.item_desc)).Value,
                        DataGridView1.Rows(i).Cells(NameOf(cn.classification)).Value,
                        DataGridView1.Rows(i).Cells(NameOf(cn.specific_loc)).Value)
            'MsgBox(DataGridView1.Rows(i).Cells(NameOf(cn.specific_loc)).Value)
        Next

        Dim view As New DataView(dt)
        Freportviewer_ListOfWarehouseItems.ReportViewer1.LocalReport.DataSources.Item(0).Value = view
        Freportviewer_ListOfWarehouseItems.ShowDialog()
        Freportviewer_ListOfWarehouseItems.Dispose()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnListOfWhItem.Click
        view_ListOfWarehouseItems()
    End Sub

    Private Sub cmbSearchBy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSearchBy.SelectedIndexChanged
        cSearchByString = cmbSearchBy.Text
        txtSearch.Focus()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If Not isLoading() Then
            If isCreateAggregatesWithoutRs Then
                whItemsModel.isSearchForAggregates = True
            End If

            If searchUI.ifBlankTexbox() Then
                customMsg.message("error", "you are not allowed to search empty!", "SMS INFO:")
                Exit Sub
            End If

            whItemsModel.searchWarehouseArea(cSearch, cSearchByString)
        End If

    End Sub

    Private Sub FOROUTWITHOURRSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FOROUTWITHOURRSToolStripMenuItem.Click
        Try
            Dim selectedItem = DataGridView1.SelectedRows(0)
            Dim division As String = selectedItem.Cells(NameOf(cn.division)).Value

            If isForHaulingAndCrushing(division) Then

                With FCreateDeliveryReceipt
                    .ReleasedQty = 0

                    .DeliveredQty = 0

                    With .cStockpileOut

                        .wh_id = selectedItem.Cells(NameOf(cn.wh_id)).Value
                        .typeOfPurchasing = cTypeOfPurchasing.WITHDRAWAL
                        .charges = ""
                        .units = selectedItem.Cells(NameOf(cn.units)).Value
                    End With

                    .cTypeOfPurchasing1 = cTypeOfPurchasing.WITHDRAWAL
                    .cWithDr = False
                    .cDrOption = DROptions.out_without_rs
                    '.CheckBox1.Enabled = False

                    .ShowDialog()
                End With
            Else
                customMsg.message("error", "this transaction is not applicable for DR", "SMS INFO")
            End If

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub FORINWITHOUTRSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FORINWITHOUTRSToolStripMenuItem.Click
        Try
            Dim selectedItem = DataGridView1.SelectedRows(0)
            Dim division As String = selectedItem.Cells(NameOf(cn.division)).Value

            If isForHaulingAndCrushing(division) Then
                With FCreateDeliveryReceipt
                    .ReleasedQty = 0
                    .DeliveredQty = 0

                    With .cStockpileIn
                        .wh_id = selectedItem.Cells(NameOf(cn.wh_id)).Value
                        .typeOfPurchasing = cTypeOfPurchasing.DR
                        .units = selectedItem.Cells(NameOf(cn.units)).Value
                        .itemName = selectedItem.Cells(NameOf(cn.proper_item_desc)).Value
                    End With

                    .cTypeOfPurchasing1 = cTypeOfPurchasing.DR
                    .cWithDr = False

                    .cDrOption = DROptions.in_without_rs

                    .ShowDialog()

                End With
            Else
                customMsg.message("error", "this transaction is not applicable for DR", "SMS INFO")

            End If


        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub FOROTHERSWITHOUTRSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FOROTHERSWITHOUTRSToolStripMenuItem.Click
        Try
            Dim selectedRow = DataGridView1.SelectedRows(0)
            Dim division As String = selectedRow.Cells(NameOf(cn.division)).Value

            If isForHaulingAndCrushing(division) Then
                With FCreateDeliveryReceipt
                    .ReleasedQty = 0

                    .DeliveredQty = 0

                    With .cStockpileIn
                        .wh_id = selectedRow.Cells(NameOf(cn.wh_id)).Value
                        .typeOfPurchasing = cTypeOfPurchasing.DR
                        .units = selectedRow.Cells(NameOf(cn.units)).Value
                        .charges = selectedRow.Cells(NameOf(cn.warehouse_area)).Value
                        .stockpile = "waiting..."
                        .quarry = "waiting..."
                        .itemName = selectedRow.Cells(NameOf(cn.item_desc)).Value
                    End With

                    .cTypeOfPurchasing1 = cTypeOfPurchasing.DR
                    .cWithDr = False
                    .cDrOption = DROptions.others_without_rs


                    .ShowDialog()
                End With
            Else
                customMsg.message("error", "this transaction is not applicable for DR", "SMS INFO")
            End If

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        Try
            If isCreateAggregatesWithoutRs Then
                Utilities.disableAllItemsFromContextMenu(ContextMenuStrip1)
                Utilities.enableDisableToolStrip(CreateTransactionForDRToolStripMenuItem, True)

            ElseIf fromRequesitionFormForDR Then
                Utilities.disableAllItemsFromContextMenu(ContextMenuStrip1)
            Else

                If DataGridView1.Rows.Count = 0 Then
                    Utilities.disableAllItemsFromContextMenu(ContextMenuStrip1)
                Else
                    Utilities.enableDisableToolStrip(CreateTransactionForDRToolStripMenuItem, True)
                    Utilities.enableDisableToolStrip(EditToolStripMenuItem, True)
                    Utilities.enableDisableToolStrip(RemoveToolStripMenuItem, True)
                    Utilities.enableDisableToolStrip(CreateNewToolStripMenuItem, True)
                    Utilities.enableDisableToolStrip(ViewStockCardToolStripMenuItem, True)
                End If

                Utilities.enableDisableToolStrip(CreateTransactionForDRToolStripMenuItem, False)
                Utilities.enableDisableToolStrip(RefreshToolStripMenuItem, True)

            End If

            Utilities.enableDisableToolStrip(CreateNewToolStripMenuItem, True)
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try


    End Sub

    Private Sub RemoveProperNamingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveProperNamingToolStripMenuItem.Click
        Try
            Dim wh_id As Integer = DataGridView1.SelectedRows(0).Cells(NameOf(cn.wh_id)).Value

            Dim result As Boolean = whItemsModel.removeProperNaming(wh_id)
            If result Then
                Dim value As New PropsFields.whItemsFinal
                whItemsModel.reloadItemsWithoutRefreshNew(wh_id, "remove_proper_name", value, 0)
                'whItemsModel.isUpdate = True
                'whItemsModel.setRowId = wh_id
                'whItemsModel.getWarehouseItems("")
            Else
                customMsg.message("error", "Something went by updating quarry", "SUPPLY INFO:")
            End If


        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        loadItems()
    End Sub

    Private Sub btnAddProperName_Click(sender As Object, e As EventArgs) Handles btnAddProperName.Click
        Try
            If Utilities.isNotRestrictedTo(cDepartments.PURCHASING) Or
                Utilities.isNotRestrictedTo(cDepartments.EQUIPMENT_MONITORING) Or
                isAuthenticatedWithoutMessage(auth) Then

                FLinkToProperNaming.isCreateNewProperNames = True
                FLinkToProperNaming.ShowDialog()

            Else
                customMsg.message("error", "You are not allowed to this transaction", "SMS INFO:")
            End If

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub btnWhStockpileQuarryArea_Click(sender As Object, e As EventArgs) Handles btnWhStockpileQuarryArea.Click
        Try
            If Utilities.isNotRestrictedTo(cDepartments.WAREHOUSING) Or
           Utilities.isNotRestrictedTo(cDepartments.CRUSHING_AND_HAULING) Or
           isAuthenticatedWithoutMessage(auth) Then

                FWarehouseAreaNew.ShowDialog()
            Else
                customMsg.message("error", "you are not allowed to this transaction!", "SMS INFO:")
            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub DataGridView1_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView1.DoubleClick
        If fromRequesitionFormForDR = True Then
            If customMsg.messageYesNo("Are you sure you want to item checked?", "SUPPLY INFO:") Then
                ItemCheckedForm.ShowDialog()
            End If
        End If
    End Sub

    Private Sub CreateTransactionForDRToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateTransactionForDRToolStripMenuItem.Click

    End Sub

    Public Sub displayKpiCategory()
        Dim SQ As New SQLcon
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader
        Dim public_query As String
        Try
            SQ.connection.Open()
            public_query = "SELECT lead_time_category, MIN(kpi_id) AS kpi_id
                            FROM dbKeyPerformanceIndicator
                            GROUP BY lead_time_category
                            ORDER BY MIN(kpi_id) ASC"
            cmd = New SqlCommand(public_query, SQ.connection)
            dr = cmd.ExecuteReader

            If dr.HasRows Then
                EditKPIToolStripMenuItem.DropDownItems.Clear()
                While dr.Read()
                    Dim categoryName As String = dr("lead_time_category").ToString()
                    Dim leadCategory As New ToolStripMenuItem(categoryName)
                    AddHandler leadCategory.Click,
                Sub(senderObj, eArgs)
                    model1.kpi_category = categoryName.ToString()

                    If Not isLoading() Then
                        FKeyPerformanceIndicator.isFromWareHouseNew = True
                        FKeyPerformanceIndicator.ShowDialog()
                    End If
                End Sub

                    EditKPIToolStripMenuItem.DropDownItems.Add(leadCategory)
                End While
            Else

                SQ.connection.Close()
            End If

        Catch ex As Exception
            MessageBox.Show("ERROR MESSAGE: " & vbCrLf & vbCrLf & ex.StackTrace() & vbCrLf & vbCrLf & Err.Description, "EUS INFO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If SQ.connection.State = ConnectionState.Open Then SQ.connection.Close()
        End Try
    End Sub

#Region "UTILITIES"
    Private Function isForHaulingAndCrushing(value As String) As Boolean
        Try

            If value.ToUpper() = cDivision.CRUSHING_AND_HAULING Then
                Return True
            End If

            Return False
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function
#End Region
End Class