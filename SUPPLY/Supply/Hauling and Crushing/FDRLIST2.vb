Imports System.ComponentModel
Imports System.Security.AccessControl
Imports SUPPLY.FDRLIST1
Imports SUPPLY.spire

Public Class FDRLIST2
    Private cProperNames As New Model_ProperNames
    Private cDrModel, cWsModel, cPoModel, AllChargesModel, AggregatesPricesModel As New ModelNew.Model
    Dim cBgWorkerChecker, cBgWorkerChecker2 As Timer

    Private cListOfDrListItems As New List(Of PropsFields.dr_list_props_fields)
    Private cListOfAggregatesPrices As New List(Of PropsFields.aggregatesPrices_props_fields)
    Private customGridview As New CustomGridview
    Private newAuth As New authType

    Public DistinctListOfDRRequestor, DistinctListOfDRItems
    Public whTOwh As New FWHtoWH
    Private customMsg As New customMessageBox
    Private cListOfColumnHeader As New List(Of Dictionary(Of Integer, String))
    Private cListOfColumnOrder As New List(Of Integer)
    Private cSomeComponents As New ColumnValuesObj

    Public Sub getDrDatasAndPreview(Optional searchBy As String = "",
                      Optional search As String = "",
                      Optional dateEnable As String = "",
                      Optional dateFrom As DateTime = Nothing,
                      Optional dateTo As DateTime = Nothing)

        cListOfDrListItems.Clear()
        cDrModel.clearParameter()
        cPoModel.clearParameter()
        cWsModel.clearParameter()

        cSomeComponents = New ColumnValuesObj
        cSomeComponents.add(GetType(Button).ToString, btnSearch)
        cSomeComponents.add(GetType(ToolStripMenuItem).ToString, SearchByToolStripMenuItem)
        cSomeComponents.add("loadingPanel", loadingPanel)

        disableEnableWhileLoading(cSomeComponents.getValues(), False)

        Dim cv1 As New ColumnValues
        Dim cv2 As New ColumnValues

        Select Case searchBy
            Case cDrSearchBy.RSNO,
                 cDrSearchBy.DRIVER,
                 cDrSearchBy.DRNO,
                 cDrSearchBy.CONSESSION,
                 cDrSearchBy.REQUESTOR,
                 cDrSearchBy.SOURCE,
                 cDrSearchBy.REMARKS,
                 cDrSearchBy.SUPPLIER,
                 cDrSearchBy.ITEM_DESC,
                 cDrSearchBy.PLATE_NO,
                 cDrSearchBy.UNIT,
                 cDrSearchBy.DR_ITEMS_ID,
                 cDrSearchBy.WH_ID

                cv1.add("searchby", searchBy)
                cv1.add("search", search)
                cv1.add("date_from", dateFrom)
                cv1.add("date_to", dateTo)
                cv1.add("date_enable", dateEnable)

            Case cDrSearchBy.DATE_RANGE

                cv1.add("searchby", searchBy)
                cv1.add("search", search)
                cv1.add("date_from", dateFrom)
                cv1.add("date_to", dateTo)
                cv1.add("date_enable", dateEnable)

            Case cDrSearchBy.WITHOUT_RS_AND_DR

                cv1.add("searchby", searchBy)
                cv1.add("search", search)
                cv1.add("date_enable", dateEnable)
                cv1.add("date_from", dateFrom)
                cv1.add("date_to", dateTo)

        End Select

        Dim drSearch As Integer
        If searchBy = cDrSearchBy.WITHOUT_RS_AND_DR Then
            drSearch = cCol.forDrWithoutRsSearch
        Else
            drSearch = cCol.forDrSearch
        End If

        _initializing(drSearch,
                      cv1.getValues(),
                      cDrModel,
                      drBgWorker)

        _initializing(cCol.forDrWsSearch,
                      cv1.getValues(),
                      cWsModel,
                      drBgWorker)

        _initializing(cCol.forDrPoSearch,
                      cv1.getValues(),
                      cPoModel,
                      drBgWorker)

        cBgWorkerChecker = BgWorkersCheckerFn(AddressOf SuccessfullyDone, drBgWorker)
    End Sub
    Private Sub SuccessfullyDone()

        'get the data result
        cListOfDrItems = TryCast(cDrModel.cData, List(Of PropsFields.dr_props_fields))
        cListOfDrWsItems = TryCast(cWsModel.cData, List(Of PropsFields.dr_ws_props_fields))
        cListOfDrPoItems = TryCast(cPoModel.cData, List(Of PropsFields.dr_po_props_fields))

        ''refactor and display to gridview or listview   
        refactorDataBeforeDisplay()

        'done loading
        loadingPanel.Visible = False

    End Sub

    Private Sub FDRLIST2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'customGridview.customDatagridview(DataGridView1,, 26)

#Region "REARRANGE COLUMNS IN LISTVIEW"
        Dim reArrange As New ListTabIndex
        With reArrange
            .addColumns(col_dr_id)
            .addColumns(col_rs_no)
            .addColumns(col_requestor)
            .addColumns(col_dr_date)
            .addColumns(col_date_request)
            .addColumns(col_dr_no)
            .addColumns(col_plateno)
            .addColumns(col_driver)
            .addColumns(col_rrno)
            .addColumns(col_ws_no_po_no)
            .addColumns(col_item_desc)
            .addColumns(col_quarry)
            .addColumns(col_projectSite)
            .addColumns(col_source2)
            .addColumns(col_concession)
            .addColumns(col_qty_in_others)
            .addColumns(col_qty_out)
            .addColumns(col_price)
            .addColumns(col_zoning_price)
            .addColumns(col_unit)
            .addColumns(col_properNames)
            .addColumns(col_total_amount)
            .addColumns(col_supplier)
            .addColumns(col_checked_by)
            .addColumns(col_received_by)
            .addColumns(col_remarks)
            .addColumns(col_dateSubmitted)
            .addColumns(col_specific_location)
            .addColumns(col_item_name)
            .addColumns(col_withdrawn_by)
            .addColumns(col_dr_option)
            .addColumns(col_source)         'classification
            .addColumns(col_user)
            .addColumns(col_inout)
            .addColumns(col_address)
            .addColumns(col_dr_info_id)
            .addColumns(col_par_rr_item_id)
            .addColumns(col_reported_by)
            .addColumns(col_row)
            .addColumns(col_time_to)
            .addColumns(col_wh_id)
            .addColumns(col_time_from)
            .addColumns(col_rs_id)
            .addColumns(col_wh_options)
            .addColumns(col_time_to)
        End With

        reArrange.rearrangeTabIndex()
#End Region

        cProperNames.initialize(loadingPanel)
        cProperNames.loadProperNames()

        'handles toolstripitem click
        handlesToolStripItemClick()

        outColor.BackColor = ColorTranslator.FromHtml("#FDDB87")
        outWithoutDrColor.BackColor = Color.LightGreen
        inColor.BackColor = Color.LightYellow
        othersColor.BackColor = ColorTranslator.FromHtml("#D2E7DD")

        initializeSomeDatas()
    End Sub

    Private Sub initializeSomeDatas()
        Try
            loadingPanel.Visible = True
            AllChargesModel.clearParameter()
            AggregatesPricesModel.clearParameter()

            Dim allChargesProps, aggPricesProps As New ColumnValues

            _initializing(cCol.forAllCharges,
                        allChargesProps.getValues(),
                        AllChargesModel,
                        dr2BgWorker)

            _initializing(cCol.forAggPrices,
                          aggPricesProps.getValues(),
                          AggregatesPricesModel,
                          dr2BgWorker)

            cBgWorkerChecker2 = BgWorkersCheckerFn(AddressOf SuccessfullyInitialized, dr2BgWorker)

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub SuccessfullyInitialized()
        Try
            rListOfAllCharges = TryCast(AllChargesModel.cData, List(Of PropsFields.AllCharges))
            cListOfAggregatesPrices = TryCast(AggregatesPricesModel.cData, List(Of PropsFields.aggregatesPrices_props_fields))

            loadingPanel.Visible = False
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub SearchByToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SearchByToolStripMenuItem.Click
        DRLIST_SEARCHBY.ShowDialog()
    End Sub

    Private Sub AllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllToolStripMenuItem.Click
        For Each row As ListViewItem In lvl_drList.Items
            row.Checked = True
        Next
    End Sub

    Private Sub UnselectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UnselectAllToolStripMenuItem.Click
        For Each row As ListViewItem In lvl_drList.Items
            row.Checked = False
        Next
    End Sub



    Private Sub ToolStripFunctions(sender As Object, e As EventArgs)
        With EditDR2
            Dim toolStripItem As New ToolStripMenuItem
            toolStripItem = sender

            Select Case toolStripItem.Name

                'price
                Case PriceToolStripMenuItem.Name
                    .whatToEdit = "price"
                    .editedValue = lvl_drList.SelectedItems(0).SubItems(27).Text
                    .ShowDialog()

                'driver
                Case OperatorDriverToolStripMenuItem.Name
                    .whatToEdit = cDrSearchBy.DRIVER
                    .editedValue = lvl_drList.SelectedItems(0).SubItems(9).Text
                    .ShowDialog()

                'supplier
                Case SupplierToolStripMenuItem.Name

                    If Not isAuthenticated(auth) Then
                        Exit Sub
                    End If

                    .whatToEdit = cDrSearchBy.SUPPLIER
                    .editedValue = lvl_drList.SelectedItems(0).SubItems(22).Text

                    .ShowDialog()

                'requestor
                Case RequestorToolStripMenuItem.Name
                    customMsg.message("error", "coming soon....", "SUPPLY INFO:")
                    Exit Sub
                    editRequestor()

                'source
                Case SourceToolStripMenuItem.Name
                    If Not isAuthenticated(auth) Then
                        Exit Sub
                    End If

                    charge_to_destination = 14

                    target_location_project = "FDRLIST2"
                    FDRLIST1.load_charges_category()

                    FCharge_To.ShowDialog()

                'received by
                Case ReceivedByToolStripMenuItem.Name
                    .whatToEdit = cDrSearchBy.RECEIVED_BY
                    .editedValue = lvl_drList.SelectedItems(0).SubItems(13).Text

                    .ShowDialog()

                'withdrawn by
                Case WithdrawnByToolStripMenuItem.Name

                    .whatToEdit = cDrSearchBy.EMPLOYEES
                    .editedValue = lvl_drList.SelectedItems(0).SubItems(33).Text

                    .ShowDialog()

                'checked by
                Case CheckedByToolStripMenuItem.Name

                    .whatToEdit = cDrSearchBy.CHECKED_BY
                    .editedValue = lvl_drList.SelectedItems(0).SubItems(12).Text

                    .ShowDialog()

                'stockpile/query
                Case StockpileQuaryCodeToolStripMenuItem.Name
                    If Not isAuthenticated(auth) Then
                        Exit Sub
                    End If


                    .whatToEdit = cDrSearchBy.CHARGES_INFO
                    .editedValue = lvl_drList.SelectedItems(0).SubItems(36).Text

                    .ShowDialog()

                'plateno
                Case PlateNOToolStripMenuItem.Name

                    .whatToEdit = cDrSearchBy.PLATE_NO
                    .editedValue = lvl_drList.SelectedItems(0).SubItems(24).Text

                    .ShowDialog()

                'dr/ws date
                Case DRWSDateToolStripMenuItem.Name

                    .whatToEdit = cDrSearchBy.DR_WS_DATE
                    .editedValue = lvl_drList.SelectedItems(0).SubItems(3).Text

                    .ShowDialog()


                'date submitted
                Case DateSubmittedToolStripMenuItem.Name

                    .whatToEdit = cDrSearchBy.DATE_SUBMITTED
                    .editedValue = lvl_drList.SelectedItems(0).SubItems(37).Text

                    .ShowDialog()

                'date log
                Case DateLogToolStripMenuItem.Name

                    If Not isAuthenticated(auth) Then
                        Exit Sub
                    End If

                    .whatToEdit = cDrSearchBy.DATE_LOG
                    .ShowDialog()

                'dr qty
                Case QTYToolStripMenuItem.Name

                    If Not isAuthenticated(auth) Then
                        Exit Sub
                    End If

                    .whatToEdit = cDrSearchBy.QTY

                    Dim qty As Double = editQty()

                    If Not qty = 0 Then
                        .editedValue = qty
                        .ShowDialog()
                    End If

                'consession
                Case ConsessionTicketToolStripMenuItem.Name

                    .whatToEdit = cDrSearchBy.CONSESSION
                    .editedValue = lvl_drList.SelectedItems(0).SubItems(8).Text

                    .ShowDialog()

                'drno
                Case DRNOToolStripMenuItem.Name

                    .whatToEdit = cDrSearchBy.DRNO
                    .editedValue = lvl_drList.SelectedItems(0).SubItems(1).Text

                    If Utilities.isAuthenticated(auth) Then
                        .ShowDialog()
                    End If
                'remarks
                Case RemarksToolStripMenuItem.Name

                    .whatToEdit = cDrSearchBy.REMARKS
                    .editedValue = lvl_drList.SelectedItems(0).SubItems(21).Text

                    .ShowDialog()

                Case OUTToolStripMenuItem.Name
                    Dim dr_out As Decimal

                    For Each row As ListViewItem In lvl_drList.Items
                        If row.Selected = True Then
                            dr_out += IIf(IsNumeric(row.SubItems(26).Text) = False, 0, row.SubItems(26).Text)
                        End If
                    Next

                    MessageBox.Show("CALCULATE OUT: " & vbCrLf & dr_out, "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Case INOTHERSToolStripMenuItem.Name
                    Dim dr_in As Decimal

                    For Each row As ListViewItem In lvl_drList.Items
                        If row.Selected = True Then
                            dr_in += IIf(IsNumeric(row.SubItems(6).Text) = False, 0, row.SubItems(6).Text)
                        End If
                    Next

                    MessageBox.Show("CALCULATE IN/OTHERS: " & vbCrLf & dr_in, "SUPPLY INFO", MessageBoxButtons.OK, MessageBoxIcon.Information)


            End Select

        End With
    End Sub

    Private Function editQty() As Double
        Try
            Dim dr_no As String
            Dim rs_no As String

            dr_no = lvl_drList.SelectedItems(0).SubItems(1).Text
            rs_no = lvl_drList.SelectedItems(0).SubItems(2).Text

            If rs_no.ToUpper <> "N/A" And dr_no.ToUpper <> "N/A" Then
                MessageBox.Show("This function is applicable only when there is no DR or RS number.", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return 0
            Else
                With lvl_drList.SelectedItems(0)
                    ' Ensure you are using column index if "col_qty_in_others" and "col_qty_out" are column names

                    If .SubItems(6).Text = "-" Then
                        editQty = .SubItems(26).Text
                    ElseIf .SubItems(26).Text = "-" Then
                        editQty = .SubItems(6).Text
                    End If
                End With
            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try

    End Function
    Private Sub editRequestor()
        With lvl_drList
            If .SelectedItems(0).BackColor = Color.LightYellow Then 'LIGHTYELLOW
                Dim dr As New Class_DR
                Dim inout As String = lvl_drList.SelectedItems(0).SubItems(16).Text
                Dim consession As String = lvl_drList.SelectedItems(0).SubItems(8).Text
                Dim dr_no As String = lvl_drList.SelectedItems(0).SubItems(1).Text

                If inout = "IN" Then
#Region "==> EDIT REQUEST BY IN TRANSACTION"
                    If dr.dr_exist("OUT", dr_no) > 0 Then
                        button_click_name = "RequestorToolStripMenuItem"
                        FListOfItems.cmboptions.Text = "HAULING AND CRUSHING"
                        FListOfItems.cmboptions.Enabled = False

                        FListOfItems.ShowDialog()
                    Else
                        MessageBox.Show("To edit a requestor, you can go to Requisition Form" & vbCrLf & "using right click > Create Charges.", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
#End Region

                ElseIf inout = "OUT" Then
#Region "EDIT REQUEST BY OUT TRANSACTION"
                    If dr.dr_exist("IN", dr_no) > 0 Then
                        MessageBox.Show("Please select 'IN' row to edit the requestor.", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        MessageBox.Show("To edit a requestor, you can go to Requisition Form" & vbCrLf & "using right click > Create Charges.", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
#End Region

                ElseIf inout = "OTHERS" Then
                    Dim rsNo As String = lvl_drList.SelectedItems(0).SubItems(2).Text
                    Dim drNo As String = lvl_drList.SelectedItems(0).SubItems(1).Text

                    If rsNo.ToUpper() = "N/A" And drNo.ToUpper() = "N/A" Then
#Region "EDIT OTHERS WITHOUT RS AND DR"

                        editByRequestor_othersWithoutRs()
#End Region

                    ElseIf rsNo.ToUpper() = "N/A" And drNo.ToUpper() <> "N/A" Then
#Region "EDIT OTHERS WITHOUT RS BUT WITH DR"
                        editByRequestor_othersWithoutRs()
#End Region
                    Else
                        MessageBox.Show("To edit a requestor, you can go to Requisition Form" & vbCrLf & "using right click > Create Charges.", "SUPPLY INFO:", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If

                End If

            End If
        End With
    End Sub

    Private Sub editByRequestor_othersWithoutRs()
        button_click_name = "edit requestor from drlist2 - OTHERS WITHOUT RS"
        FListOfItems.cmboptions.SelectedIndex = 1
        FListOfItems.cmboptions.Enabled = False

        Dim importantIds As New important_ids
        importantIds.rs_id = lvl_drList.SelectedItems(0).SubItems(15).Text
        FListOfItems.setIds(importantIds)

        FListOfItems.ShowDialog()
    End Sub

    Private Sub handlesToolStripItemClick()
        For Each toolStrip As ToolStripMenuItem In ContextMenuStrip1.Items

            For Each item In toolStrip.DropDownItems
                Dim subItem As New ToolStripMenuItem
                subItem = item

                AddHandler subItem.Click, AddressOf ToolStripFunctions

            Next

        Next
    End Sub


    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Dispose()
    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        'If auth = newAuth.admin Then
        '    GenerateReportToolStripMenuItem.Enabled = True

        'Else
        '    GenerateReportToolStripMenuItem.Enabled = False
        'End If

        GenerateReportToolStripMenuItem.Enabled = True
    End Sub

    Private Sub BW_edit_wh_to_wh_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BW_edit_wh_to_wh.DoWork
        FDRLIST1.editWhToWh(lvl_drList)
    End Sub

    Private Sub GenerateReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GenerateReportToolStripMenuItem.Click

        If auth.ToUpper() = cUserAuthentication.ADMIN Then
            With FSelectItemsForSummaryOFHauledAgg
                .alternateForm = True

                .ListView1.Items.Clear()
                .ListView2.Items.Clear()

                DistinctListOfDRRequestor = From row In cListOfDrListItems
                                            Select row.requestor Distinct Order By requestor Ascending

                DistinctListOfDRItems = From row In cListOfDrListItems
                                        Select row.wh_id, row.item_desc, row.requestor Distinct Order By item_desc Ascending

                For Each row In DistinctListOfDRRequestor
                    Dim a(10) As String
                    a(1) = row
                    Dim lvl As New ListViewItem(a)
                    .ListView2.Items.Add(lvl)
                Next

                .ShowDialog()

            End With
        Else
            customMsg.message("error", "you are not allowed to generate data, please contact the Administrator of this system!", "SUPPLY INFO:")
        End If

    End Sub

    Private Sub DRWHTOWHToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DRWHTOWHToolStripMenuItem.Click
        Dim inout As String = lvl_drList.SelectedItems(0).SubItems(16).Text
        Dim drNo As String = lvl_drList.SelectedItems(0).SubItems(1).Text
        Dim cListOfWhToWh As New List(Of PropsFields.dr_wh_to_wh_pros_fields)

        If inout = "IN" Then
            customMsg.message("error", "unable to edit this transaction(IN), instead select the (OUT) transaction..", "SUPPLY INFO:")
        ElseIf inout = "OTHERS" Then
            customMsg.message("error", "this data is not applicable to edit wh to wh", "SUPPLY INFO:")
        ElseIf inout = "OUT" Then
            Dim drResult = cListOfDrListItems.Where(Function(x) x.dr_no = drNo).OrderByDescending(Function(x) x.inout).ToList()

            If drResult.Count > 0 Then
                For Each dr In drResult

                    Dim drListProps As New PropsFields.dr_wh_to_wh_pros_fields
                    With drListProps
                        .dr_item_id = dr.dr_item_id
                        .dr_date = dr.dr_date
                        .rs_no = dr.rs_no
                        .dr_no = dr.dr_no
                        .ws_po_no = dr.ws_po_no
                        .dr_info_id = dr.dr_info_id
                        .rr_no = dr.rr_no
                        .item_name = $"{dr.item_name} - {dr.item_desc }"
                        .dr_qty = dr.dr_qty
                        .price = dr.price
                        .unit = dr.unit
                        '.requestor = dr.requestor
                        .concession_ticket = dr.concession_ticket
                        .inout = dr.inout
                        .user = dr.user
                        .driver = dr.driver
                        .plateno = dr.plateno
                        .checked_by = dr.checked_by
                        .received_by = dr.received_by
                        .withdrawn_by = dr.withdrawn_by
                        .supplier = dr.supplier
                        .rs_id = dr.rs_id
                        .remarks = dr.remarks
                        .dr_info_id = dr.dr_info_id
                        .wh_id = dr.wh_id
                        .price = dr.price

                        'FOR REQUESTOR --> WH TO WH FORM
                        If dr.inout = cInOut._OUT Then
                            Dim r = cListOfDrListItems.Where(Function(x) x.dr_no = .dr_no).ToList()

                            .requestor = IIf(r.Count > 1, "-", dr.requestor)

                        ElseIf dr.inout = cInOut._IN Or dr.inout = cInOut._OTHERS Then

                            .requestor = IIf(dr.requestor.ToString.ToUpper() = "N/A" Or
                            dr.requestor.ToString() = "",
                            dr.requestor_without_rs,
                            dr.requestor)

                        End If

                        cListOfWhToWh.Add(drListProps)
                    End With
                Next

                FWHtoWH.dgvData.DataSource = cListOfWhToWh
                FWHtoWH.ShowDialog()
            End If

        End If
    End Sub


    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        DRLIST_SEARCHBY.ShowDialog()
    End Sub
    Private Sub refactorDataBeforeDisplay()
        'dr items
        For Each row In cListOfDrItems
            Dim _dr As New PropsFields.dr_list_props_fields
            With _dr
                .rs_id = row.rs_id
                .dr_item_id = row.dr_item_id
                .rs_no = row.rs_no
                .requestor = row.requestor
                .dr_date = row.dr_date
                .date_request = row.rs_date  'IIf(row.inout = "IN", check_if_pair(row.dr_no, row.rs_date), row.rs_date)
                .dr_no = row.dr_no
                .plateno = row.plateno
                .driver = row.driver
                '.ws_po_no = IIf(row.inout = "OUT", row.ws_no, row.po_no)
                .ws_po_no = row.ws_no
                .rr_no = row.rr_no
                .item_name = row.item_name
                .item_desc = row.item_desc
                .unit = row.unit
                .source = row.dr_source
                .concession_ticket = row.concession_ticket
                .dr_qty = row.dr_qty
                .price = row.price
                .total_amount = row.total_amount
                .supplier = row.supplier
                .checked_by = row.checked_by
                .received_by = row.received_by
                .remarks = row.remarks
                .user = row.input_user
                .inout = row.inout
                .dr_option = row.dr_option
                .wh_id = row.wh_id
                .wh_pn_id = row.wh_pn_id
                .source2 = row.source2
                .date_submitted = row.date_submitted
                .requestor_without_rs = row.requestor_without_rs
                .dr_info_id = row.dr_info_id
                .wh_options = row.wh_options
                .quarry = row.quarry
                .wh_area_id = row.wh_area_id
                .whArea_category = row.whArea_category
                .category_for_projectsite = row.category_for_projectsite
                .projectsite_id = row.projectsite_id
                .specific_location = row.specific_location
                .rs_no_orig = row.rs_no_orig
                .others_source = row.dr_source
                .type_of_requestor = row.type_of_requestor
                .requestor_id = row.requestor_id
                .par_rr_item_id = row.par_rr_item_id

            End With


            cListOfDrListItems.Add(_dr)
        Next

        'add withdrawal without dr
        For Each row In cListOfDrWsItems
            Dim _ws As New PropsFields.dr_list_props_fields
            With _ws
                .dr_item_id = row.ws_id
                .rs_no = row.rs_no
                .requestor = row.requestor
                .dr_date = row.ws_date
                .date_request = row.rs_date
                .dr_no = row.dr_no
                .plateno = row.plateno
                .driver = row.driver
                .ws_po_no = row.ws_no
                .rr_no = row.rr_no
                .item_name = row.item_name
                .item_desc = row.item_desc
                .unit = row.unit
                .source = row.ws_source
                .concession_ticket = row.concession_ticket
                .dr_qty = row.ws_qty
                .price = row.price
                .total_amount = row.total_amount
                .supplier = row.supplier
                .checked_by = row.checked_by
                .received_by = ""
                .approved_by = row.approved_by
                .withdrawn_by = row.withdrawn_by
                .source2 = row.source2
                .remarks = row.remarks
                .user = row.users
                .inout = row.inout
                .dr_option = row.dr_option
                .wh_id = row.wh_id
                .wh_pn_id = row.wh_pn_id
                .rs_no_orig = row.rs_no
                '.quarry = row.quarry
            End With

            cListOfDrListItems.Add(_ws)
        Next

        displayToListView()
    End Sub
    Private Sub displayToListView(Optional sortby As String = "")
        '********** NOTE **************

        ' stockpile: OUT: row.source
        ' requestor: IN: row.requestor_without_rs
        ' quary source: row.source2

        '*****************************

        lvl_drList.Items.Clear()
        Dim LviewItem As New List(Of ListViewItem)

        Dim SortedListOfDelivery = From A In cListOfDrListItems
                                   Select A
                                   Order By A.dr_date,
                             A.dr_no,
                             A.dr_item_id Ascending

        For Each row In SortedListOfDelivery

            Dim a(43) As String

            a(0) = row.dr_item_id
            a(1) = row.dr_no
            a(2) = row.rs_no_orig 'row.rs_no
            a(3) = row.dr_date
            a(4) = row.item_name
            'a(5) = row.source2

#Region "DR QTY"
            Select Case row.inout
                Case "IN", "OTHERS"

                    a(6) = row.dr_qty
                    a(26) = "-"
                    'a(10) = row.requestor
                Case "OUT"

                    a(6) = "-"
                    a(26) = row.dr_qty
                    'a(10) = row.requestor
            End Select
#End Region

#Region "STOCKPILE/REQUESTOR/QUARRY/SOURCE"
            '36 - STOCKPILE
            '39 - QUARRY
            '10 - REQUESTOR
            '5 - CLASSIFICATION
            '41 - SOURCE

            Dim forRequestorWithoutRs As String = Utilities.getWarehouseAreaStockpile(row.projectsite_id, row.category_for_projectsite, row.requestor)
            Dim sourceNew As New DR_SOURCE
            Dim requestorNew As New DR_REQUESTOR
            Dim quarryNew As New DR_QUARRY
            Dim stockpileNew As New DR_STOCKPILE
            Dim classificationNew As New DR_CLASSIFICATION
            Dim zoningPriceNew As New DR_ZONING_PRICE

            classificationNew.initialize(row.rs_no, row.dr_no, row.inout)
            stockpileNew.initialize(row.rs_no, row.dr_no, row.inout)
            quarryNew.initialize(row.rs_no, row.dr_no, row.inout)
            sourceNew.initialize(row.rs_no, row.dr_no, row.inout)
            requestorNew.initialize(row.rs_no, row.dr_no, row.inout)
            zoningPriceNew.initialize(row.rs_no, row.dr_no, row.inout)

            If row.inout = cInOut._OUT Then
                Dim drResult = cListOfDrListItems.Where(Function(x) x.dr_no = row.dr_no).ToList()

#Region "CLASSIFICATION"
                'classificationNew.initialize(row.rs_no, row.dr_no, row.inout)
                a(5) = classificationNew.execute(,, row.source2)
#End Region
#Region "STOCKPILE"
                'stockpileNew.initialize(row.rs_no, row.dr_no, row.inout)
                a(36) = stockpileNew.execute(,, row.source)
#End Region
#Region "QUARRY"
                'quarryNew.initialize(row.rs_no, row.dr_no, row.inout)
                a(39) = quarryNew.execute(,, row.quarry)
#End Region
#Region "SOURCE"
                'sourceNew.initialize(row.rs_no, row.dr_no, row.inout)
                a(41) = sourceNew.execute(row.whArea_category,
                                          row.wh_area_id,
                                          row.source)
#End Region
#Region "REQUESTOR"
                'requestorNew.initialize(row.rs_no, row.dr_no, row.inout)
                requestorNew.initialize_dr_option(row.dr_option)

                a(10) = requestorNew.execute(row.type_of_requestor, row.requestor_id, row.requestor)
#End Region
#Region "ZONING PRICE"
                'zoningPriceNew.initialize(row.rs_no, row.dr_no, row.inout)
                zoningPriceNew.initialize_aggregates_prices(cListOfAggregatesPrices)
                a(43) = zoningPriceNew.execute(row.wh_id, row.source, row.requestor)
#End Region

            ElseIf row.inout = cInOut._IN Then

#Region "CLASSIFICATION"
                'classificationNew.initialize(row.rs_no, row.dr_no, row.inout)
                a(5) = classificationNew.execute(,, row.source2)
#End Region
#Region "STOCKPILE"
                'stockpileNew.initialize(row.rs_no, row.dr_no, row.inout)
                a(36) = stockpileNew.execute(,, row.source)
#End Region
#Region "QUARRY"
                'quarryNew.initialize(row.rs_no, row.dr_no, row.inout)
                a(39) = quarryNew.execute(,, row.quarry)
#End Region
#Region "REQUESTOR"
                'requestorNew.initialize(row.rs_no, row.dr_no, row.inout)
                a(10) = requestorNew.execute(,, row.requestor, row.requestor_without_rs)
#End Region
#Region "SOURCE"
                'sourceNew.initialize(row.rs_no, row.dr_no, row.inout)
                a(41) = sourceNew.execute(row.category_for_projectsite,
                                              row.projectsite_id,
                                              row.quarry)
#End Region

                If Not isDrWithoutRs(row.rs_no) Then

#Region "ZONING PRICE"
                    Dim _request As String = IIf(row.requestor.ToString.ToUpper() = "N/A" Or
                                                   row.requestor.ToString() = "",
                                                   row.requestor_without_rs,
                                                   row.requestor) 'requestor

                    'zoningPriceNew.initialize(row.rs_no, row.dr_no, row.inout)
                    zoningPriceNew.initialize_aggregates_prices(cListOfAggregatesPrices)

                    a(43) = zoningPriceNew.execute(row.wh_id, row.quarry, _request)
#End Region

                Else

#Region "ZONING PRICE"
                    'zoningPriceNew.initialize(row.rs_no, row.dr_no, row.inout)
                    zoningPriceNew.initialize_aggregates_prices(cListOfAggregatesPrices)

                    a(43) = zoningPriceNew.execute(row.wh_id,
                                           row.others_source,
                                           row.requestor_without_rs)
#End Region
                End If

            ElseIf row.inout = cInOut._OTHERS Then

#Region "CLASSIFICATION"
                'classificationNew.initialize(row.rs_no, row.dr_no, row.inout)
                a(5) = classificationNew.execute(,, row.source2)
#End Region
#Region "STOCKPILE"
                'stockpileNew.initialize(row.rs_no, row.dr_no, row.inout)
                a(36) = stockpileNew.execute(,, row.source)
#End Region
#Region "QUARRY"
                'quarryNew.initialize(row.rs_no, row.dr_no, row.inout)
                a(39) = quarryNew.execute(,, row.quarry)
#End Region
#Region "REQUESTOR"
                ' requestorNew.initialize(row.rs_no, row.dr_no, row.inout)
                a(10) = requestorNew.execute(row.whArea_category, row.wh_area_id, row.requestor)
#End Region
#Region "SOURCE"
                'sourceNew.initialize(row.rs_no, row.dr_no, row.inout)
                sourceNew.initialize_item(row.item_desc.ToUpper())
                sourceNew.initialize_category_for_projectsite(row.category_for_projectsite, row.projectsite_id)
                sourceNew.initialize_wh_option(row.wh_options)

                a(41) = sourceNew.execute(row.whArea_category, row.wh_area_id, row.quarry)
#End Region

#Region "ZONING PRICE"
                'zoningPriceNew.initialize(row.rs_no, row.dr_no, row.inout)
                zoningPriceNew.initialize_aggregates_prices(cListOfAggregatesPrices)

                a(43) = zoningPriceNew.execute(row.wh_id,
                                           row.quarry,
                                           row.requestor)
#End Region

            End If

#End Region

            a(7) = row.unit.ToString().ToLower()
            a(8) = row.concession_ticket
            a(9) = row.driver
            a(11) = ""
            a(12) = IIf(row.dr_option = "WITHOUT DR", "", row.checked_by)
            a(13) = row.received_by
            a(14) = row.dr_info_id
            a(15) = row.rs_id
            a(16) = row.inout
            a(17) = ""
            a(18) = ""
            a(19) = IIf(row.rs_no.ToUpper() = "N/A" And row.inout = "IN", "-", row.ws_po_no)
            a(21) = row.remarks
            a(22) = row.supplier
            a(23) = row.user
            a(24) = row.plateno
            a(25) = row.rr_no
            a(27) = formatNumberWithComma(row.price) 'FormatNumber(row.price, 2,,, TriState.False)
            a(28) = formatNumberWithComma(IIf(a(43) = "", row.price, a(43)) * row.dr_qty) 'FormatNumber((row.price * row.dr_qty), 2,,, TriState.False) 'row.total_amount
            a(29) = getDetailedItems(row)
            a(30) = IIf(row.rs_no.Contains("N/A"), "-", row.date_request)
            a(31) = row.dr_option
            a(33) = IIf(row.inout = "OUT", row.withdrawn_by, "")
            a(34) = "" 'row.reported_user
            a(35) = row.wh_id
            a(37) = is1990(Utilities.DateConverter(row.date_submitted))
            a(38) = row.wh_options
            a(40) = getProperNaming(row.wh_pn_id) 'IIf(propNaming = "", row.item_desc, propNaming2)
            a(42) = row.specific_location

            'format with comma
            a(43) = formatNumberWithComma(ifBlankReplaceToZero(a(43)))

#Region "row background color and font style"
            Dim lvl As New ListViewItem(a)

            lvl.BackColor = getRowColor(row)
#End Region

            LviewItem.Add(lvl)
        Next


        lvl_drList.Items.AddRange(LviewItem.ToArray())

        'custom row height
        Utilities.customListViewHeight(lvl_drList, 28)
        disableEnableWhileLoading(cSomeComponents.getValues(), True)

    End Sub
    Private Sub BW_edit_wh_to_wh_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BW_edit_wh_to_wh.RunWorkerCompleted
        whTOwh.ShowDialog()
    End Sub

    Private Function getSourceArea(sourceCategory As String, source_id As Integer) As PropsFields.AllCharges
        Try
            getSourceArea = rListOfAllCharges.FirstOrDefault(Function(x)
                                                                 Return x.charges_category.ToUpper() = sourceCategory.ToUpper() And
                                                                 x.charges_id = source_id
                                                             End Function)
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        Try
            If customMsg.messageYesNo("Are you sure you want to delete this data?", "SUPPLY INFO:", MessageBoxIcon.Question) Then
                If Utilities.isAuthenticated(auth) Then
                    deleteDr()
                End If
            End If

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub deleteDr()
        Try
            Dim deleteDr As New DeleteDeliveryReceiptServices
            Dim selectedRow = lvl_drList.SelectedItems(0)
            If cListOfDrListItems IsNot Nothing Then
                Dim drData = cListOfDrListItems.FirstOrDefault(Function(x) x.dr_item_id = selectedRow.Text)

                deleteDr.initialize_ws(cListOfDrWsItems)
                deleteDr.initialize_po(cListOfDrPoItems)

                Dim deleteResult As Boolean = deleteDr.ExecuteWithReturnBoolean(drData, cListOfDrListItems)

                If deleteResult Then
                    'lvl_drList.SelectedItems(0).Remove()
                    removeDr(drData.dr_no)
                    customMsg.message("info", "DR successfully Deleted!", "SUPPLY INFO:")
                Else
                    customMsg.message("error", "something went wrong in deleting data!", "SUPPLY INFO:")
                End If
            End If
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Sub removeDr(drNo As String, Optional dr_item_id As Integer = 0)
        Try
            Dim selectedRow = lvl_drList.SelectedItems(0)

            If selectedRow.SubItems(1).Text.ToUpper() = "N/A" And selectedRow.SubItems(2).Text.ToUpper() = "N/A" Then
                selectedRow.Remove()
                Exit Sub
            End If

            For Each row As ListViewItem In lvl_drList.Items
                If row.SubItems(1).Text = drNo Then
                    lvl_drList.Items.RemoveAt(row.Index)
                End If
            Next

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

    Private Function getRequestorArea(type_of_requestor As String,
                                      requestor_id As Integer) As PropsFields.AllCharges
        Try
            Dim requestorArea = rListOfAllCharges.FirstOrDefault(Function(x)
                                                                     Return x.charges_category.ToUpper() = type_of_requestor.ToUpper() And
                                                                 x.charges_id = requestor_id
                                                                 End Function)
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Private Sub btnTransaction_Click(sender As Object, e As EventArgs) Handles btnTransaction.Click
        Try
            For Each child As Form In FMain.MdiChildren
                If TypeOf child Is FWarehouseItemsNew Then
                    child.Dispose()
                End If
            Next

            With FWarehouseItemsNew
                '.fromRequesitionFormForDR = True
                '.btnListOfWhItem.Enabled = False
                .MdiParent = Nothing
                .WindowState = FormWindowState.Normal
                .isCreateAggregatesWithoutRs = True
                .ShowDialog()
            End With
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Sub

#Region "GET"
    Private Function getRowColor(row As PropsFields.dr_list_props_fields) As Color
        Try
            If row.dr_option = cDrCategory.WITH_DR And
                row.inout = cInOut._OUT Then
                getRowColor = ColorTranslator.FromHtml("#FDDB87")

            ElseIf row.dr_option = cDrCategory.WITHOUT_DR And
                    row.inout = cInOut._OUT Then
                getRowColor = Color.LightGreen

            ElseIf row.inout = cInOut._OTHERS Then
                getRowColor = ColorTranslator.FromHtml("#D2E7DD")

            Else
                getRowColor = Color.LightYellow
            End If

            Return getRowColor
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

    Private Function getProperNaming(wh_pn_id As Integer) As String

        Dim initializeProperNaming As New PropsFields.whItems_properName_fields

        initializeProperNaming = getProperNameUsingWhPnId2(wh_pn_id)
        Dim propNaming As String = ""

        If initializeProperNaming IsNot Nothing Then
            propNaming = initializeProperNaming.item_desc
        End If
        Return propNaming

    End Function

    Private Function getDetailedItems(row As PropsFields.dr_list_props_fields) As String
        Try
            Dim propNaming = getProperNaming(row.wh_pn_id)

            getDetailedItems = row.item_desc

            Return getDetailedItems
        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function
    Private Function getAggregatesZoningPrices(wh_id As Integer,
                                           source As String,
                                           destination As String) As PropsFields.PROPS_AGG_PRICES

        Dim zoningPrices As New List(Of PropsFields.PROPS_AGG_PRICES)

        'refactor zoning prices with details
        For Each row In cListOfAggregatesPrices.Where(Function(x) x.wh_id = wh_id).ToList()
            Dim data As New PropsFields.PROPS_AGG_PRICES
            With data
                .aggPricingId = row.aggPricingId

                'zoning source
                Dim zoningSource = rListOfAllCharges.FirstOrDefault(Function(x)
                                                                        Return x.charges_category.ToUpper() = row.zoning_source_category.ToUpper() And
                                                                        x.charges_id = row.zoning_source_id
                                                                    End Function)

                If zoningSource IsNot Nothing Then
                    .zoning_source = zoningSource.charges
                End If

                'zoning destination
                Dim zoningDestination = rListOfAllCharges.FirstOrDefault(Function(x)
                                                                             Return x.charges_category.ToUpper() = row.zoning_area_category.ToUpper() And
                                                                             x.charges_id = row.zoning_area_id
                                                                         End Function)

                If zoningSource IsNot Nothing Then
                    .zoning_area = zoningDestination.charges
                End If

                .wh_id = row.wh_id
                .zoning_price = row.zoning_price
            End With

            zoningPrices.Add(data)
        Next

        getAggregatesZoningPrices = zoningPrices.FirstOrDefault(Function(x)
                                                                    Dim zoningSource As String = IIf(x.zoning_source IsNot Nothing, x.zoning_source, "")
                                                                    Dim zoningArea As String = IIf(x.zoning_area IsNot Nothing, x.zoning_area, "")

                                                                    Return zoningSource.ToUpper() = source.ToUpper() And
                                                                    zoningArea.ToUpper() = destination.ToUpper()
                                                                End Function)

    End Function
    Private Function getZoningPrice(wh_id As Integer,
                                    source As String,
                                    destination As String) As String

        Dim zoningPrice = getAggregatesZoningPrices(wh_id, source, destination)

        If zoningPrice IsNot Nothing Then
            getZoningPrice = zoningPrice.zoning_price
        End If
    End Function

    Private Function getSourceForWasteAggregates(row As PropsFields.dr_list_props_fields) As String
        Try
            If row.whArea_category IsNot Nothing And row.whArea_category <> "" Then
                Dim waste_source = Results.rListOfAllCharges.FirstOrDefault(Function(x)
                                                                                Return x.charges_category.ToUpper() = row.whArea_category.ToUpper() And
                                                             x.charges_id = row.wh_area_id
                                                                            End Function)
                ' Return waste_source
                If waste_source IsNot Nothing Then
                    Return waste_source.charges
                End If
            End If

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function

#End Region

#Region "UTILITIES"
    Private Function renameFrom_WarehouseToStockpile(value As String)
        If value.ToUpper() = "WAREHOUSE" Then
            Return "STOCKPILE"
        End If
    End Function

    Private Function isDrWithoutRs(rsNo As String) As Boolean
        Try
            If rsNo.ToUpper() = "N/A" Then
                Return True
            End If

        Catch ex As Exception
            customMsg.ErrorMessage(ex)
        End Try
    End Function
#End Region
End Class
Public Class DR_SOURCE

    Private gRsNo As String
    Private gDrNo As String
    Private gInOut As String
    Private gTypeOfPurchasing As String
    Private gItem As String
    Private gCustomMsg As New customMessageBox
    Private gCategoryForProjectsite As String
    Private gProjectSiteId As Integer
    Private gWhOption As String

    Public Sub initialize(rsNo As String, drNo As String, inOut As String, Optional typeOfPurchasing As String = "")
        gRsNo = rsNo
        gDrNo = drNo
        gInOut = inOut
        gTypeOfPurchasing = typeOfPurchasing
    End Sub

    Public Sub initialize_item(item As String)
        gItem = item
    End Sub

    Public Sub initialize_category_for_projectsite(category As String, projectSiteId As Integer)
        gCategoryForProjectsite = category
        gProjectSiteId = projectSiteId
    End Sub

    Public Sub initialize_wh_option(category As String)
        gWhOption = category
    End Sub

    Public Function execute(Optional category As String = "",
                            Optional source_id As Integer = 0,
                            Optional source As String = "") As String
        Try
            If gInOut = cInOut._IN Then

                If isDrWithoutRs(gRsNo) Then
                    Dim newSourceArea = getSourceArea(category, source_id)
                    Return newSourceArea.charges
                Else
                    Return source
                End If

            ElseIf gInOut = cInOut._OUT Then

                If isDrWithoutRs(gRsNo) Then
                    Dim newSourceArea = getSourceArea(category, source_id)

                    If newSourceArea IsNot Nothing Then
                        'Return $"{renameFrom_WarehouseToStockpile(category)} | {newSourceArea.charges}"
                        Return newSourceArea.charges
                    Else
                        Return source
                    End If
                End If

            ElseIf gInOut = cInOut._OTHERS Then
                If Not isDrWithoutRs(gRsNo) Then

                    If gItem.ToUpper().Contains("WASTE") Then
                        'for waste disposal transfer to other project

                        If category = "" And source_id = 0 And source <> "" Then 'this transaction is for waste disposal came from quarry
                            Return source
                        Else
                            'Return ifNothingReplaceToDash(getSourceForWasteAggregates(gCategoryForProjectsite, gProjectSiteId))
                            Return ifNothingReplaceToDash(getSourceForWasteAggregates(category, source_id))

                        End If
                    Else
                        If category.ToUpper() = "OTHERS" Then
                            Return ifNothingReplaceToDash(getSourceForWasteAggregates(gCategoryForProjectsite, gProjectSiteId))
                        Else
                            Return source
                        End If

                        'If gWhOption = cWarehouseOption.QUARRY Then
                        '    'source from quarry to projects
                        '    Return ifNothingReplaceToDash(getSourceForWasteAggregates(cWarehouseOption.WAREHOUSE, source_id))
                        'Else
                        '    Return ifNothingReplaceToDash(getSourceForWasteAggregates(category, source_id))
                        'End If

                    End If
                Else
                    Dim newSourceArea = getSourceArea(gCategoryForProjectsite, gProjectSiteId)
                    If newSourceArea IsNot Nothing Then
                        ' Return $"{renameFrom_WarehouseToStockpile(gCategoryForProjectsite)} | {newSourceArea.charges}"
                        Return newSourceArea.charges
                    Else
                        Return source
                    End If

                End If
            End If

        Catch ex As Exception
            gCustomMsg.ErrorMessage(ex)
        End Try
    End Function

#Region "UTILITIES"
    Private Function isDrWithoutRs(rsNo As String) As Boolean
        Try
            If rsNo.ToUpper() = cNotApplicable Then
                Return True
            End If

        Catch ex As Exception
            gCustomMsg.ErrorMessage(ex)
        End Try
    End Function

    Private Function getSourceArea(sourceCategory As String, source_id As Integer) As PropsFields.AllCharges
        Try
            getSourceArea = rListOfAllCharges.FirstOrDefault(Function(x)
                                                                 Return x.charges_category.ToUpper() = sourceCategory.ToUpper() And
                                                                 x.charges_id = source_id
                                                             End Function)
        Catch ex As Exception
            gCustomMsg.ErrorMessage(ex)
        End Try
    End Function

    Private Function renameFrom_WarehouseToStockpile(value As String)
        If value.ToUpper() = "WAREHOUSE" Then
            Return "STOCKPILE"
        End If

        Return value
    End Function

    Private Function getSourceForWasteAggregates(category As String, source_id As Integer) As String
        Try
            If category IsNot Nothing And category <> "" Then
                Dim waste_source = Results.rListOfAllCharges.FirstOrDefault(Function(x)
                                                                                Return x.charges_category.ToUpper() = category.ToUpper() And
                                                             x.charges_id = source_id
                                                                            End Function)

                ' Return waste_source
                If waste_source IsNot Nothing Then
                    Return waste_source.charges
                End If
            End If

        Catch ex As Exception
            gCustomMsg.ErrorMessage(ex)
        End Try
    End Function

#End Region

End Class
Public Class DR_REQUESTOR

    Private gRsNo As String
    Private gDrNo As String
    Private gInOut As String
    Private gTypeOfPurchasing As String
    Private gItem As String
    Private gDrOption As String

    Private gCustomMsg As New customMessageBox

    Public Sub initialize(rsNo As String, drNo As String, inOut As String, Optional typeOfPurchasing As String = "")
        gRsNo = rsNo
        gDrNo = drNo
        gInOut = inOut
        gTypeOfPurchasing = typeOfPurchasing
    End Sub

    Public Sub initialize_dr_option(drOption As String)
        gDrOption = drOption
    End Sub
    Public Function execute(Optional category As String = "",
                            Optional requestor_id As Integer = 0,
                            Optional requestor As String = "",
                            Optional requestor_without_rs As String = "") As String

        Try
            If gInOut = cInOut._IN Then
                If isDrWithoutRs(gRsNo) Then
                    Return requestor_without_rs
                Else
                    Dim _requestor As String = IIf(requestor.ToUpper() = cNotApplicable Or
                                             requestor.ToString() = "",
                                              requestor_without_rs,
                                              requestor)

                    Return _requestor
                End If

            ElseIf gInOut = cInOut._OUT Then
                If isDrWithoutRs(gRsNo) Then
                    'Dim newSourceArea = getSourceArea(row.whArea_category, row.wh_area_id
                    Dim requestorArea = getRequestorArea(category, requestor_id)
                    '=== requestor ===                
                    If requestorArea IsNot Nothing Then
                        Return requestorArea.charges
                    Else
                        Return requestor
                    End If
                Else
                    'If gDrOption = cDrCategory.WITHOUT_DR Then
                    '    Return requestor
                    'End If
                    Return requestor
                End If

            ElseIf gInOut = cInOut._OTHERS Then
                If Not isDrWithoutRs(gRsNo) Then
                    Dim _requestor As String = IIf(requestor.ToUpper() = cNotApplicable Or
                                             requestor.ToString() = "",
                                              Utilities.getWarehouseAreaStockpile(requestor_id, category, requestor),
                                              requestor)

                    Return _requestor

                Else
                    Return Utilities.getWarehouseAreaStockpile(requestor_id, category, requestor)
                End If
            End If

        Catch ex As Exception
            gCustomMsg.ErrorMessage(ex)
        End Try
    End Function

#Region "UTILITIES"
    Private Function isDrWithoutRs(rsNo As String) As Boolean
        Try
            If rsNo.ToUpper() = cNotApplicable Then
                Return True
            End If

        Catch ex As Exception
            gCustomMsg.ErrorMessage(ex)
        End Try
    End Function

    Private Function getSourceArea(sourceCategory As String, source_id As Integer) As PropsFields.AllCharges
        Try
            getSourceArea = rListOfAllCharges.FirstOrDefault(Function(x)
                                                                 Return x.charges_category.ToUpper() = sourceCategory.ToUpper() And
                                                                 x.charges_id = source_id
                                                             End Function)
        Catch ex As Exception
            gCustomMsg.ErrorMessage(ex)
        End Try
    End Function

    Private Function renameFrom_WarehouseToStockpile(value As String)
        If value.ToUpper() = "WAREHOUSE" Then
            Return "STOCKPILE"
        End If
    End Function

    Private Function getRequestorArea(Optional category As String = "",
                                  Optional requestor_id As Integer = 0) As PropsFields.AllCharges
        Try
            Dim requestorArea = rListOfAllCharges.FirstOrDefault(Function(x)
                                                                     Return x.charges_category.ToUpper() = ifNothingReplaceToBlank(category).ToUpper() And
                                                                 x.charges_id = requestor_id
                                                                 End Function)

            Return requestorArea
        Catch ex As Exception
            gCustomMsg.ErrorMessage(ex)
        End Try
    End Function
#End Region

End Class
Public Class DR_QUARRY
    Private gRsNo As String
    Private gDrNo As String
    Private gInOut As String
    Private gTypeOfPurchasing As String
    Private gItem As String
    Private gDrOption As String

    Private gCustomMsg As New customMessageBox

    Public Sub initialize(rsNo As String, drNo As String, inOut As String, Optional typeOfPurchasing As String = "")
        gRsNo = rsNo
        gDrNo = drNo
        gInOut = inOut
        gTypeOfPurchasing = typeOfPurchasing
    End Sub

    Public Function execute(Optional category As String = "",
                            Optional quarry_id As Integer = 0,
                            Optional quarry As String = "",
                            Optional quarry_without_rs As String = "") As String

        Try
            If gInOut = cInOut._IN Then
                If Not isDrWithoutRs(gRsNo) Then
                    Return "-"
                Else
                    Return quarry
                End If

            ElseIf gInOut = cInOut._OUT Then
                If Not isDrWithoutRs(gRsNo) Then
                    Return quarry
                End If

            ElseIf gInOut = cInOut._OTHERS Then
                If Not isDrWithoutRs(gRsNo) Then
                    Return "-"
                End If
            End If

        Catch ex As Exception
            gCustomMsg.ErrorMessage(ex)
        End Try
    End Function
#Region "UTILITIES"
    Private Function isDrWithoutRs(rsNo As String) As Boolean
        Try
            If rsNo.ToUpper() = "N/A" Then
                Return True
            End If

        Catch ex As Exception
            gCustomMsg.ErrorMessage(ex)
        End Try
    End Function
#End Region

End Class
Public Class DR_STOCKPILE
    Private gRsNo As String
    Private gDrNo As String
    Private gInOut As String
    Private gTypeOfPurchasing As String
    Private gItem As String
    Private gDrOption As String

    Private gCustomMsg As New customMessageBox

    Public Sub initialize(rsNo As String, drNo As String, inOut As String, Optional typeOfPurchasing As String = "")
        gRsNo = rsNo
        gDrNo = drNo
        gInOut = inOut
        gTypeOfPurchasing = typeOfPurchasing
    End Sub

    Public Function execute(Optional category As String = "",
                            Optional stockpile_id As Integer = 0,
                            Optional stockpile As String = "",
                            Optional stockpile_without_rs As String = "") As String

        Try
            If gInOut = cInOut._IN Then
                Return "-"

            ElseIf gInOut = cInOut._OUT Then
                If Not isDrWithoutRs(gRsNo) Then
                    Return stockpile
                End If

            ElseIf gInOut = cInOut._OTHERS Then
                If Not isDrWithoutRs(gRsNo) Then
                    Return "-"
                End If
            End If

        Catch ex As Exception
            gCustomMsg.ErrorMessage(ex)
        End Try
    End Function
#Region "UTILITIES"
    Private Function isDrWithoutRs(rsNo As String) As Boolean
        Try
            If rsNo.ToUpper() = "N/A" Then
                Return True
            End If

        Catch ex As Exception
            gCustomMsg.ErrorMessage(ex)
        End Try
    End Function
#End Region

End Class
Public Class DR_CLASSIFICATION

    Private gRsNo As String
    Private gDrNo As String
    Private gInOut As String
    Private gTypeOfPurchasing As String
    Private gItem As String
    Private gDrOption As String

    Private gCustomMsg As New customMessageBox
    Public Sub initialize(rsNo As String, drNo As String, inOut As String, Optional typeOfPurchasing As String = "")
        gRsNo = rsNo
        gDrNo = drNo
        gInOut = inOut
        gTypeOfPurchasing = typeOfPurchasing
    End Sub

    Public Function execute(Optional category As String = "",
                            Optional classification_id As Integer = 0,
                            Optional classification As String = "") As String

        Try
            If gInOut = cInOut._IN Then
                Return "-"

            ElseIf gInOut = cInOut._OUT Then
                If Not isDrWithoutRs(gRsNo) Then
                    Return classification
                End If

            ElseIf gInOut = cInOut._OTHERS Then
                Return classification
            End If

        Catch ex As Exception
            gCustomMsg.ErrorMessage(ex)
        End Try
    End Function
#Region "UTILITIES"
    Private Function isDrWithoutRs(rsNo As String) As Boolean
        Try
            If rsNo.ToUpper() = "N/A" Then
                Return True
            End If

        Catch ex As Exception
            gCustomMsg.ErrorMessage(ex)
        End Try
    End Function
#End Region
End Class
Public Class DR_ZONING_PRICE

    Private gRsNo As String
    Private gDrNo As String
    Private gInOut As String
    Private gTypeOfPurchasing As String
    Private gItem As String
    Private gDrOption As String
    Private gCustomMsg As New customMessageBox
    Private gListOfAggregatesPrices As New List(Of PropsFields.aggregatesPrices_props_fields)

    Public Sub initialize(rsNo As String, drNo As String, inOut As String, Optional typeOfPurchasing As String = "")
        gRsNo = rsNo
        gDrNo = drNo
        gInOut = inOut
        gTypeOfPurchasing = typeOfPurchasing
    End Sub

    Public Sub initialize_aggregates_prices(listOfAggregatesPrices As List(Of PropsFields.aggregatesPrices_props_fields))
        gListOfAggregatesPrices = listOfAggregatesPrices
    End Sub

    Public Function execute(wh_id As Integer,
                            Optional source As String = "",
                            Optional destination As String = "") As String

        Try
            Return getZoningPrice(wh_id, source, destination)
            'If gInOut = cInOut._IN Then

            'ElseIf gInOut = cInOut._OUT Then
            '    Return getZoningPrice(wh_id, source, destination)

            'ElseIf gInOut = cInOut._OTHERS Then

            'End If

        Catch ex As Exception
            gCustomMsg.ErrorMessage(ex)
        End Try
    End Function

    Private Function getZoningPrice(wh_id As Integer,
                                    source As String,
                                    destination As String) As String

        Dim zoningPrice = getAggregatesZoningPrices(wh_id, source, destination)

        If zoningPrice IsNot Nothing Then
            getZoningPrice = zoningPrice.zoning_price
        End If
    End Function

    Private Function getAggregatesZoningPrices(wh_id As Integer,
                                           source As String,
                                           destination As String) As PropsFields.PROPS_AGG_PRICES

        Dim zoningPrices As New List(Of PropsFields.PROPS_AGG_PRICES)

        'refactor zoning prices with details
        Dim listOfAggregatesPrices = gListOfAggregatesPrices.Where(Function(x) x.wh_id = wh_id).ToList()

        For Each row In listOfAggregatesPrices
            Dim data As New PropsFields.PROPS_AGG_PRICES
            With data
                .aggPricingId = row.aggPricingId

                'zoning source
                Dim zoningSource = rListOfAllCharges.FirstOrDefault(Function(x)
                                                                        Return x.charges_category.ToUpper() = row.zoning_source_category.ToUpper() And
                                                                        x.charges_id = row.zoning_source_id
                                                                    End Function)

                If zoningSource IsNot Nothing Then
                    .zoning_source = zoningSource.charges
                End If

                'zoning destination
                Dim zoningDestination = rListOfAllCharges.FirstOrDefault(Function(x)
                                                                             Return x.charges_category.ToUpper() = row.zoning_area_category.ToUpper() And
                                                                             x.charges_id = row.zoning_area_id
                                                                         End Function)

                If zoningSource IsNot Nothing Then
                    .zoning_area = zoningDestination.charges
                End If

                .wh_id = row.wh_id
                .zoning_price = row.zoning_price
            End With

            zoningPrices.Add(data)
        Next

        getAggregatesZoningPrices = getZoningPriceBySourceAndDestination(zoningPrices, source, destination)


        Return getAggregatesZoningPrices
    End Function

#Region "UTILITIES"
    Private Function isDrWithoutRs(rsNo As String) As Boolean
        Try
            If rsNo.ToUpper() = "N/A" Then
                Return True
            End If

        Catch ex As Exception
            gCustomMsg.ErrorMessage(ex)
        End Try
    End Function

    Private Function getZoningPriceBySourceAndDestination(zoningPrices As List(Of PropsFields.PROPS_AGG_PRICES),
                                                          source As String,
                                                          destination As String)

        Return zoningPrices.FirstOrDefault(Function(x)
                                               Dim zoningSource As String = IIf(x.zoning_source IsNot Nothing, x.zoning_source, "")
                                               Dim zoningArea As String = IIf(x.zoning_area IsNot Nothing, x.zoning_area, "")

                                               Return zoningSource.ToUpper() = source.ToUpper() And
                                               zoningArea.ToUpper() = destination.ToUpper()
                                           End Function)
    End Function
#End Region
End Class